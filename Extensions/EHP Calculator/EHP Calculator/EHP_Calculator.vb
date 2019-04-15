﻿Imports System.IO
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

    Public Property __Container As TabPage

    <Import(GetType(ISettings))>
    Public Settings As ISettings

    <Import(GetType(ILogging))>
    Public Log As ILogging

    <Import(GetType(IStorage))>
    Public Storage As IStorage

    Public Function Init(ByVal __container As TabPage) As Object Implements IMethods.Init
        With Me
            .__Container = __container
            .FormBorderStyle = FormBorderStyle.None
            .TopLevel = False
            .Dock = DockStyle.Fill
            .Show()
            Return Me
        End With
    End Function

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
    Private Mods As New Dictionary(Of String, Dictionary(Of String, JToken)) From {
        {"auras", New Dictionary(Of String, JToken)},
        {"survivability", New Dictionary(Of String, JToken)},
        {"miscellaneous", New Dictionary(Of String, JToken)},
        {"power_strength", New Dictionary(Of String, JToken)}
    }
    Private Misc As New Dictionary(Of String, Dictionary(Of String, JToken)) From {
        {"arcanes", New Dictionary(Of String, JToken)},
        {"focus", New Dictionary(Of String, JToken)}
    }

    Private Sub EHP_Calculator_with_GUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Storage.HasStorage() Then
            Log.ShowMessage("Missing Required Data" & vbCrLf & "Please Reinstall the Extension or Install the missing data manually", MessageBoxIcon.Error)
            __Container.Enabled = False
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
            ' Add mods
            For Each group As String In Mods.Keys
                For Each [mod] As JToken In JObject.Parse(Storage.ReadText("mods\" & group & ".json"))("mods")
                    Mods(group)([mod]("name")) = [mod]("params")
                    Dim modControl As Control = Nothing
                    Select Case [mod].SelectToken("params.type")
                        Case "radio"
                            modControl = New RadioInput With {
                                .Name = [mod]("name"),
                                .Text = ToTitleCase([mod]("name")),
                                .Maximum = [mod].SelectToken("params.rank_max"),
                                .Minimum = [mod].SelectToken("params.rank_min")
                            }
                        Case "checked"
                            modControl = New CheckedInput With {
                                .Name = [mod]("name"),
                                .Text = ToTitleCase([mod]("name")),
                                .Maximum = [mod].SelectToken("params.rank_max"),
                                .Minimum = [mod].SelectToken("params.rank_min")
                            }
                        Case "checked_dual"
                            modControl = New CheckedDualInput With {
                                .Name = [mod]("name"),
                                .Text = ToTitleCase([mod]("name")),
                                .Secondary_Text = ToTitleCase([mod].SelectToken("params.charges.label")),
                                .Maximum = [mod].SelectToken("params.rank_max"),
                                .Minimum = [mod].SelectToken("params.rank_min")
                            }
                    End Select
                    Controls.Find("CheckedGroupBox_" & group, True).FirstOrDefault.Controls.Add(modControl)
                Next
            Next
            'Add other
            For Each group As String In Misc.Keys
                For Each item As JToken In JObject.Parse(Storage.ReadText(group & "\" & group & ".json"))(group)
                    Misc(group)(item("name")) = item("params")
                    Dim miscControl As Control = Nothing
                    Select Case item.SelectToken("params.type")
                        Case "radio"
                            miscControl = New RadioInput With {
                                .Name = item("name"),
                                .Text = ToTitleCase(item("name")),
                                .Maximum = item.SelectToken("params.rank_max"),
                                .Minimum = item.SelectToken("params.rank_min")
                            }
                        Case "checked"
                            miscControl = New CheckedInput With {
                                .Name = item("name"),
                                .Text = ToTitleCase(item("name")),
                                .Maximum = item.SelectToken("params.rank_max"),
                                .Minimum = item.SelectToken("params.rank_min")
                            }
                        Case "checked_dual"
                            miscControl = New CheckedDualInput With {
                                .Name = item("name"),
                                .Text = ToTitleCase(item("name")),
                                .Secondary_Text = ToTitleCase(item.SelectToken("params.charges.label")),
                                .Maximum = item.SelectToken("params.rank_max"),
                                .Minimum = item.SelectToken("params.rank_min")
                            }
                    End Select
                    Controls.Find("CheckedGroupBox_" & group, True).FirstOrDefault.Controls.Add(miscControl)
                Next
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Failed to Load Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'debug
        Log.Write(DumpDicts)
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
            If TypeOf Selected_Warframe.SelectToken("overrides.rank", errorWhenNoMatch:=False) Is Object Then
                Warframe("overides") = Selected_Warframe.SelectToken("overrides.rank")
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

    Private Function DumpDicts() As String
        '
        '   DEBUG FUNCTION
        '
        Dim msg As String = "{" & vbCrLf
        For Each t In Mods
            msg = msg & "   """ & t.Key & """: " & "["
            For Each tt In t.Value
                Dim params As String = tt.Value.ToString
                params = System.Text.RegularExpressions.Regex.Replace(params, "\r\n", vbCrLf & "        ")
                msg = msg & vbCrLf & "      """ & tt.Key & """: " & params & ","
            Next
            msg = msg.TrimEnd(",") & vbCrLf & "   ]," & vbCrLf
        Next
        For Each t In Misc
            msg = msg & "   """ & t.Key & """: " & "["
            For Each tt In t.Value
                Dim params As String = tt.Value.ToString
                params = System.Text.RegularExpressions.Regex.Replace(params, "\r\n", vbCrLf & "        ")
                msg = msg & vbCrLf & "      """ & tt.Key & """: " & params & ","
            Next
            msg = msg.TrimEnd(",") & vbCrLf & "   ]," & vbCrLf
        Next
        msg = msg.TrimEnd(",") & vbCrLf & "}"
        Return msg
    End Function

End Class

