Imports System.IO
Imports System.Windows.Forms
Imports System.ComponentModel.Composition
Imports Newtonsoft.Json.Linq
Imports MEFContracts.Interfaces
Imports EHP_Calculator_Controls
Imports EHP_Calculator.Utils

<Export(GetType(IMethods))>
<ExportMetadata("Name", "EHP Calculator")>
<ExportMetadata("Description", "EHP Calculator for Warframes")>
<ExportMetadata("Author", "Bradley 'cmd430' Treweek")>
<ExportMetadata("Version", "0.0.1")>
Public Class EHP_Calculator
    Implements IMethods

    Private Property __container As TabPage

    <Import(GetType(ISettings))>
    Public Settings As ISettings

    <Import(GetType(ILogging))>
    Public Log As ILogging

    <Import(GetType(IStorage))>
    Public Storage As IStorage

    Public Function Init(ByVal __container As TabPage) As Object Implements IMethods.Init
        With Me
            .__container = __container
            .FormBorderStyle = FormBorderStyle.None
            .TopLevel = False
            .Dock = DockStyle.Fill
            .Show()
            Return Me
        End With
    End Function

    Private Sub MissingData()
        ' Message for any data parse errors
        Log.ShowMessage("Missing Required Data" & vbCrLf & "Please Reinstall the Extension or Install the missing data manually", MessageBoxIcon.Error)
    End Sub

    Private Warframe As New Dictionary(Of String, JObject) From {
        {"stats", Nothing},
        {"overides", Nothing},
        {"rank_multipliers", JObject.Parse(
            "{
                armor:  1,
                health: 3,
                shield: 3,
                energy: 1.5,
                strength: 1
             }"
        )}
    }
    Private Modifiers As New Dictionary(Of String, Dictionary(Of String, JToken))

    Private Sub EHP_Calculator_with_GUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Storage.HasStorage() Then
            MissingData()
            __container.Enabled = False
            Exit Sub
        End If

        AddHandler ComboBox_Warframes.SelectedIndexChanged, AddressOf SelectedWarframeChanged           ' Warframe Changed
        AddHandler Warframe_VariantSelection.SelectedVariantChanged, AddressOf SelectedWarframeChanged  ' Variant Changed
        MaxValueToggle1.Checked = Settings.GetValue("user_prefs", "default_max", False)                 ' Set/Get from User Prefs
        AddHandler MaxValueToggle1.CheckedChanged, Function() Settings.SetValue("user_prefs", "default_max", MaxValueToggle1.Checked)

        ComboBox_Warframes.SelectedIndex = 0
        For Each frame In Storage.GetFiles("warframes") 'Populate combobox with each warframe
            ComboBox_Warframes.Items.Add(ToTitleCase(Path.GetFileNameWithoutExtension(frame)))
        Next

        '
        '   TODO: turn this into a seperate reusable sub (plus optimise)
        '
        Try
            ' Add Groups
            For Each Dir As String In Storage.GetDirectories("\")
                Dir = Dir.ToLower()
                If Not Dir = "warframes" Then
                    Dim GP_Box As New CheckedGroupBox With {
                        .Name = "CheckedGroupBox_" & Dir,
                        .Text = ToTitleCase(Dir),
                        .Parent = FlowLayoutPanel1
                    }
                    Modifiers.Add(Dir, New Dictionary(Of String, JToken))
                    For Each item As JToken In JObject.Parse(Storage.ReadText(Dir & "\" & Dir & ".json"))(Dir)
                        Modifiers(Dir)(item("name")) = item("params")
                        Dim miscControl As Control = Nothing
                        Dim iterations As Integer = 0
                        If item.SelectToken("params.type") = "arcane" Then
                            GP_Box.Limited = True
                            GP_Box.Limit = 2
                            iterations = -1
                        End If
                        Do Until iterations = 1
                            Select Case item.SelectToken("control")
                                Case "RadioInput"
                                    miscControl = New RadioInput With {
                                    .Name = item("name"),
                                    .Text = ToTitleCase(item("name")),
                                    .Maximum = item.SelectToken("params.rank_max"),
                                    .Minimum = item.SelectToken("params.rank_min")
                                }
                                Case "CheckedInput"
                                    miscControl = New CheckedInput With {
                                    .Name = item("name"),
                                    .Text = ToTitleCase(item("name")),
                                    .Maximum = item.SelectToken("params.rank_max"),
                                    .Minimum = item.SelectToken("params.rank_min")
                                }
                                Case "CheckedDualInput"
                                    miscControl = New CheckedDualInput With {
                                   .Name = item("name"),
                                   .Text = ToTitleCase(item("name")),
                                   .Secondary_Text = ToTitleCase(item.SelectToken("params.charges.label")),
                                   .Maximum = item.SelectToken("params.rank_max"),
                                   .Minimum = item.SelectToken("params.rank_min")
                                }
                            End Select
                            Controls.Find("CheckedGroupBox_" & Dir, True).FirstOrDefault.Controls.Add(miscControl)
                            iterations += 1
                        Loop
                    Next
                End If
            Next
        Catch ex As Exception
            MissingData()
        End Try
    End Sub

    Private Sub SelectedWarframeChanged(sender As Object, e As EventArgs)
        If ComboBox_Warframes.SelectedIndex > 0 Then

            ' Load Data for Selected Warframe
            Dim Selected_Warframe = JObject.Parse(Storage.ReadText("warframes\" & ComboBox_Warframes.SelectedItem.ToLower() & ".json"))

            ' Enable Variant Selection for Warframe Type (Base/Prime/Umbra)
            Warframe_VariantSelection.AvailableVariants = "base"
            If TypeOf Selected_Warframe.SelectToken("variants.prime", errorWhenNoMatch:=False) Is Object Then
                Warframe_VariantSelection.AvailableVariants = "prime"
            End If
            If TypeOf Selected_Warframe.SelectToken("variants.umbra", errorWhenNoMatch:=False) Is Object Then
                Warframe_VariantSelection.AvailableVariants = "umbra"
            End If
            If TypeOf Selected_Warframe.SelectToken("variants.prime", errorWhenNoMatch:=False) Is Object And TypeOf Selected_Warframe.SelectToken("variants.umbra", errorWhenNoMatch:=False) Is Object Then
                Warframe_VariantSelection.AvailableVariants = "prime_umbra"
            End If

            ' Set the Current Base Stats to Selected Variants
            If Warframe_VariantSelection.AvailableVariants.Contains("prime") And Warframe_VariantSelection.SelectedVariant = "prime" Then
                Warframe("stats") = Selected_Warframe.SelectToken("variants.prime")
            ElseIf Warframe_VariantSelection.AvailableVariants.Contains("umbra") And Warframe_VariantSelection.SelectedVariant = "umbra" Then
                Warframe("stats") = Selected_Warframe.SelectToken("variants.umbra")
            Else
                Warframe("stats") = Selected_Warframe.SelectToken("variants.base")
            End If

            ' Set any Overides that may be present
            If TypeOf Selected_Warframe.SelectToken("overrides", errorWhenNoMatch:=False) Is Object Then
                Warframe("overides") = Selected_Warframe.SelectToken("overrides")
            Else
                Warframe("overides") = Nothing
            End If

            ' Display Stats in StatBoxs
            StatBox_Armor.Value = GetRankedStat(Warframe, "armor")
            StatBox_Health.Value = GetRankedStat(Warframe, "health")
            StatBox_Shield.Value = GetRankedStat(Warframe, "shield")
            StatBox_Energy.Value = GetRankedStat(Warframe, "energy")
            StatBox_PowerStrength.Value = GetRankedStat(Warframe, "strength")
            StatBox_EffectiveHealth.Value = GetEffectiveHealth(Warframe)
        Else
            ' No Warframe is Selected, Reset
            Warframe_VariantSelection.AvailableVariants = "base"
            Warframe_VariantSelection.SelectedVariant = "base"
            Warframe("stats") = Nothing
            Warframe("overides") = Nothing
            StatBox_Armor.Value = Nothing
            StatBox_Health.Value = Nothing
            StatBox_Shield.Value = Nothing
            StatBox_Energy.Value = Nothing
            StatBox_PowerStrength.Value = Nothing
            StatBox_EffectiveHealth.Value = Nothing
        End If
    End Sub

End Class

