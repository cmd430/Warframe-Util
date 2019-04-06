Imports System.IO
Imports System.Windows.Forms
Imports System.ComponentModel.Composition
Imports Newtonsoft.Json.Linq
Imports MEFContracts.Interfaces

<Export(GetType(IMethods))>
<ExportMetadata("Name", "EHP Calculator")>
<ExportMetadata("Description", "EHP Calculator for Warframes and Compainions")>
<ExportMetadata("Author", "Bradley 'cmd430' Treweek")>
<ExportMetadata("Version", "0.0.1")>
Public Class EHP_Calculator
    Implements IMethods

    <Import(GetType(ISettings))>
    Public Settings As ISettings

    Public Function Init() As Object Implements IMethods.Init
        With Me
            .FormBorderStyle = FormBorderStyle.None
            .TopLevel = False
            .Dock = DockStyle.Fill
            .Show()
            Return Me
        End With
    End Function

    Private Warframes As JObject = JObject.Parse(File.ReadAllText("Data\Extensions\EHP Calculator\warframes.json"))
    Private Selected_Warframe As JObject = Nothing
    Private Warframe_Stats As JObject = Nothing
    Private Rank_Bonuses As JObject = Warframes("rank")

    Private Sub New()
        InitializeComponent()

        ComboBox_Warframes.SelectedIndex = 0
        For Each Warframe In Warframes("warframes")
            'Populate combobox with each warframe
            ComboBox_Warframes.Items.Add(ToTitleCase(Warframe))
        Next
    End Sub

    Private Sub ComboBox_Warframes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Warframes.SelectedIndexChanged
        If ComboBox_Warframes.SelectedIndex > 0 Then
            Selected_Warframe = JObject.Parse(File.ReadAllText("Data\Extensions\EHP Calculator\warframes\" & ComboBox_Warframes.SelectedItem.ToLower() & ".json"))

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

            SelectedVariantChanged()
        Else
            Warframe_VariantSelection.AvailableVariants = "base"
            Warframe_VariantSelection.SelectedVariant = "base"
            Selected_Warframe = Nothing
            Warframe_Stats = Nothing
            TextBox_Armor.Text = "-"
            TextBox_Health.Text = "-"
            TextBox_Shield.Text = "-"
            TextBox_Energy.Text = "-"
            TextBox_PowerStrength.Text = "-"
            TextBox_EffectiveHealth.Text = "-"
        End If
    End Sub

    Private Function getRankedStat(ByVal Stat As String)
        Dim res As Decimal = 0
        If Stat = "armor" Then
            If TypeOf Selected_Warframe.SelectToken("overrides.rank.armor", errorWhenNoMatch:=False) Is Object Then
                res = CType(Warframe_Stats("armor"), Decimal) * CType(Selected_Warframe.SelectToken("overrides.rank.armor"), Decimal)
            Else
                res = CType(Warframe_Stats("armor"), Decimal) * CType(Rank_Bonuses("armor"), Decimal)
            End If
        End If
        If Stat = "health" Then
            If TypeOf Selected_Warframe.SelectToken("overrides.rank.health", errorWhenNoMatch:=False) Is Object Then
                res = CType(Warframe_Stats("health"), Decimal) * CType(Selected_Warframe.SelectToken("overrides.rank.health"), Decimal)
            Else
                res = CType(Warframe_Stats("health"), Decimal) * CType(Rank_Bonuses("health"), Decimal)
            End If
        End If
        If Stat = "shield" Then
            If TypeOf Selected_Warframe.SelectToken("overrides.rank.shield", errorWhenNoMatch:=False) Is Object Then
                res = CType(Warframe_Stats("shield"), Decimal) * CType(Selected_Warframe.SelectToken("overrides.rank.shield"), Decimal)
            Else
                res = CType(Warframe_Stats("shield"), Decimal) * CType(Rank_Bonuses("shield"), Decimal)
            End If
        End If
        If Stat = "energy" Then
            If TypeOf Selected_Warframe.SelectToken("overrides.rank.energy", errorWhenNoMatch:=False) Is Object Then
                res = CType(Warframe_Stats("energy"), Decimal) * CType(Selected_Warframe.SelectToken("overrides.rank.energy"), Decimal)
            Else
                res = CType(Warframe_Stats("energy"), Decimal) * CType(Rank_Bonuses("energy"), Decimal)
            End If
        End If
        If Stat = "strength" Then
            If TypeOf Selected_Warframe.SelectToken("overrides.rank.strength", errorWhenNoMatch:=False) Is Object Then
                res = CType(Warframe_Stats("strength"), Decimal) * CType(Selected_Warframe.SelectToken("overrides.rank.strength"), Decimal)
            Else
                res = CType(Warframe_Stats("strength"), Decimal) * CType(Rank_Bonuses("strength"), Decimal)
            End If
        End If
        Return Math.Round(res)
    End Function

    Private Sub SelectedVariantChanged()
        If Warframe_VariantSelection.AvailableVariants.Contains("prime") And Warframe_VariantSelection.SelectedVariant = "prime" Then
            Warframe_Stats = Selected_Warframe.SelectToken("variants.prime")
        ElseIf Warframe_VariantSelection.AvailableVariants.Contains("umbra") And Warframe_VariantSelection.SelectedVariant = "umbra" Then
            Warframe_Stats = Selected_Warframe.SelectToken("variants.umbra")
        Else
            Warframe_Stats = Selected_Warframe.SelectToken("variants.base")
        End If
        TextBox_Armor.Text = getRankedStat("armor")
        TextBox_Health.Text = getRankedStat("health")
        TextBox_Shield.Text = getRankedStat("shield")
        TextBox_Energy.Text = getRankedStat("energy")
        TextBox_PowerStrength.Text = getRankedStat("strength")
    End Sub

    Private Sub EHP_Calculator_with_GUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Warframe_VariantSelection_SelectedVariantChanged(sender As Object, e As EventArgs) Handles Warframe_VariantSelection.SelectedVariantChanged
        SelectedVariantChanged()
    End Sub

End Class