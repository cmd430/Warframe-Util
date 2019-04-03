Imports System.IO
Imports System.Windows.Forms
Imports EHP_Calculator.Utilities
Imports Newtonsoft.Json.Linq

Public Class GUI

    Public Warframes As JObject = JObject.Parse(File.ReadAllText("Data\Extensions\EHP Calculator\warframes.json"))
    Public Selected_Warframe As JObject = Nothing
    Public Warframe_Stats As JObject = Nothing
    Public Rank_Bonuses As JObject = Warframes("rank")

    Public Sub New()
        InitializeComponent()

        AddHandler CheckBox_isPrime.CheckedChanged, AddressOf CheckBox_isPrime_isUmbra_CheckedChanged
        AddHandler CheckBox_isUmbra.CheckedChanged, AddressOf CheckBox_isPrime_isUmbra_CheckedChanged

        ComboBox_Warframes.SelectedIndex = 0
        For Each Warframe In Warframes("warframes")
            'Populate combobox with each warframe
            ComboBox_Warframes.Items.Add(ToTitleCase(Warframe))
        Next
    End Sub

    Private Sub ComboBox_Warframes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Warframes.SelectedIndexChanged
        If ComboBox_Warframes.SelectedIndex > 0 Then
            Selected_Warframe = JObject.Parse(File.ReadAllText("Data\Extensions\EHP Calculator\warframes\" & ComboBox_Warframes.SelectedItem.ToLower() & ".json"))
            If TypeOf Selected_Warframe.SelectToken("variants.prime", errorWhenNoMatch:=False) Is Object Then
                CheckBox_isPrime.Enabled = True
            Else
                CheckBox_isPrime.Enabled = False
            End If
            If TypeOf Selected_Warframe.SelectToken("variants.umbra", errorWhenNoMatch:=False) Is Object Then
                CheckBox_isUmbra.Enabled = True
            Else
                CheckBox_isUmbra.Enabled = False
            End If
            SelectedVariantChanged()
        Else
            Selected_Warframe = Nothing
            Warframe_Stats = Nothing
            CheckBox_isPrime.Enabled = False
            CheckBox_isUmbra.Enabled = False
            TextBox_Armor.Text = "-"
            TextBox_Health.Text = "-"
            TextBox_Shield.Text = "-"
            TextBox_Energy.Text = "-"
            TextBox_PowerStrength.Text = "-"
            TextBox_EffectiveHealth.Text = "-"
        End If
    End Sub

    Public Sub CheckBox_isPrime_isUmbra_CheckedChanged(sender As Object, e As EventArgs)
        '
        '   Enable Swapping between Normal / Prime / Umbra Frames
        '   
        '   Checks for State are inverted because .net gets the state info
        '   from after the click (makes sense)
        '
        RemoveHandler CheckBox_isPrime.CheckedChanged, AddressOf CheckBox_isPrime_isUmbra_CheckedChanged
        RemoveHandler CheckBox_isUmbra.CheckedChanged, AddressOf CheckBox_isPrime_isUmbra_CheckedChanged
        Dim Prime As CheckBox = Controls("CheckBox_isPrime")
        Dim Umbra As CheckBox = Controls("CheckBox_isUmbra")
        If sender.Name = Prime.Name Then
            If Not Prime.Checked Then
                Prime.Checked = False
            Else
                Prime.Checked = True
                Umbra.Checked = False
            End If
        ElseIf sender.Name = Umbra.Name Then
            If Not Umbra.Checked Then
                Umbra.Checked = False
            Else
                Umbra.Checked = True
                Prime.Checked = False
            End If
        End If
        AddHandler CheckBox_isPrime.CheckedChanged, AddressOf CheckBox_isPrime_isUmbra_CheckedChanged
        AddHandler CheckBox_isUmbra.CheckedChanged, AddressOf CheckBox_isPrime_isUmbra_CheckedChanged
        SelectedVariantChanged()
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
        If CheckBox_isPrime.Checked And CheckBox_isPrime.Enabled Then
            Warframe_Stats = Selected_Warframe.SelectToken("variants.prime")
        ElseIf CheckBox_isUmbra.Checked And CheckBox_isUmbra.Enabled Then
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

    Private Sub GUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub


End Class
