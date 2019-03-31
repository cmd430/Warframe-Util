Imports System.IO
Imports System.Windows.Forms
Imports EHP_Calculator.Utilities
Imports Newtonsoft.Json.Linq

Public Class GUI

    Public Warframes As JObject = JObject.Parse(File.ReadAllText("Data\Extensions\EHP Calculator\warframes.json"))
    Public Selected_Warframe As JObject = Nothing
    Public Warframe_Stats As JObject = Nothing

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


    Private Sub SelectedVariantChanged()
        If CheckBox_isPrime.Checked And CheckBox_isPrime.Enabled Then
            Warframe_Stats = Selected_Warframe("variants")("prime")
        ElseIf CheckBox_isUmbra.Checked And CheckBox_isUmbra.Enabled Then
            Warframe_Stats = Selected_Warframe("variants")("umbra")
        Else
            Warframe_Stats = Selected_Warframe("variants")("base")
        End If
        TextBox_Armor.Text = Warframe_Stats("armor")
        TextBox_Health.Text = Warframe_Stats("health")
        TextBox_Shield.Text = Warframe_Stats("shield")
        TextBox_Energy.Text = Warframe_Stats("energy")
        TextBox_PowerStrength.Text = Warframe_Stats("strength")
    End Sub

    Private Sub GUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub


End Class
