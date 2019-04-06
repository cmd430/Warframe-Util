<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EHP_Calculator
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox_EffectiveHealth = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox_PowerStrength = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox_Energy = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox_Shield = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox_Health = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox_Armor = New System.Windows.Forms.TextBox()
        Me.ComboBox_Warframes = New System.Windows.Forms.ComboBox()
        Me.Warframe_VariantSelection = New EHP_Calculator_Controls.VariantSelection()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(579, 250)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 13)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Effective Health"
        '
        'TextBox_EffectiveHealth
        '
        Me.TextBox_EffectiveHealth.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_EffectiveHealth.Location = New System.Drawing.Point(668, 247)
        Me.TextBox_EffectiveHealth.Name = "TextBox_EffectiveHealth"
        Me.TextBox_EffectiveHealth.ReadOnly = True
        Me.TextBox_EffectiveHealth.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextBox_EffectiveHealth.Size = New System.Drawing.Size(97, 20)
        Me.TextBox_EffectiveHealth.TabIndex = 29
        Me.TextBox_EffectiveHealth.Text = "-"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(582, 165)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 13)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Power Strength"
        '
        'TextBox_PowerStrength
        '
        Me.TextBox_PowerStrength.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_PowerStrength.Location = New System.Drawing.Point(668, 162)
        Me.TextBox_PowerStrength.Name = "TextBox_PowerStrength"
        Me.TextBox_PowerStrength.ReadOnly = True
        Me.TextBox_PowerStrength.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextBox_PowerStrength.Size = New System.Drawing.Size(97, 20)
        Me.TextBox_PowerStrength.TabIndex = 27
        Me.TextBox_PowerStrength.Text = "-"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(623, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Energy"
        '
        'TextBox_Energy
        '
        Me.TextBox_Energy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_Energy.Location = New System.Drawing.Point(668, 117)
        Me.TextBox_Energy.Name = "TextBox_Energy"
        Me.TextBox_Energy.ReadOnly = True
        Me.TextBox_Energy.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextBox_Energy.Size = New System.Drawing.Size(97, 20)
        Me.TextBox_Energy.TabIndex = 25
        Me.TextBox_Energy.Text = "-"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(623, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Shield"
        '
        'TextBox_Shield
        '
        Me.TextBox_Shield.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_Shield.Location = New System.Drawing.Point(668, 91)
        Me.TextBox_Shield.Name = "TextBox_Shield"
        Me.TextBox_Shield.ReadOnly = True
        Me.TextBox_Shield.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextBox_Shield.Size = New System.Drawing.Size(97, 20)
        Me.TextBox_Shield.TabIndex = 23
        Me.TextBox_Shield.Text = "-"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(623, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Health"
        '
        'TextBox_Health
        '
        Me.TextBox_Health.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_Health.Location = New System.Drawing.Point(668, 65)
        Me.TextBox_Health.Name = "TextBox_Health"
        Me.TextBox_Health.ReadOnly = True
        Me.TextBox_Health.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextBox_Health.Size = New System.Drawing.Size(97, 20)
        Me.TextBox_Health.TabIndex = 21
        Me.TextBox_Health.Text = "-"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(623, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Armor"
        '
        'TextBox_Armor
        '
        Me.TextBox_Armor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_Armor.Location = New System.Drawing.Point(668, 39)
        Me.TextBox_Armor.Name = "TextBox_Armor"
        Me.TextBox_Armor.ReadOnly = True
        Me.TextBox_Armor.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextBox_Armor.Size = New System.Drawing.Size(97, 20)
        Me.TextBox_Armor.TabIndex = 19
        Me.TextBox_Armor.Text = "-"
        '
        'ComboBox_Warframes
        '
        Me.ComboBox_Warframes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Warframes.FormattingEnabled = True
        Me.ComboBox_Warframes.Items.AddRange(New Object() {"Select a Warframe"})
        Me.ComboBox_Warframes.Location = New System.Drawing.Point(12, 12)
        Me.ComboBox_Warframes.Name = "ComboBox_Warframes"
        Me.ComboBox_Warframes.Size = New System.Drawing.Size(244, 21)
        Me.ComboBox_Warframes.TabIndex = 16
        '
        'Warframe_VariantSelection
        '
        Me.Warframe_VariantSelection.AvailableVariants = "base"
        Me.Warframe_VariantSelection.Location = New System.Drawing.Point(262, 11)
        Me.Warframe_VariantSelection.MaximumSize = New System.Drawing.Size(121, 22)
        Me.Warframe_VariantSelection.MinimumSize = New System.Drawing.Size(121, 22)
        Me.Warframe_VariantSelection.Name = "Warframe_VariantSelection"
        Me.Warframe_VariantSelection.SelectedVariant = "base"
        Me.Warframe_VariantSelection.Size = New System.Drawing.Size(121, 22)
        Me.Warframe_VariantSelection.TabIndex = 31
        '
        'EHP_Calculator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(777, 468)
        Me.Controls.Add(Me.Warframe_VariantSelection)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextBox_EffectiveHealth)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextBox_PowerStrength)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextBox_Energy)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBox_Shield)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox_Health)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox_Armor)
        Me.Controls.Add(Me.ComboBox_Warframes)
        Me.Name = "EHP_Calculator"
        Me.Text = "EHP_Calculator_with_GUI"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents TextBox_EffectiveHealth As Windows.Forms.TextBox
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents TextBox_PowerStrength As Windows.Forms.TextBox
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents TextBox_Energy As Windows.Forms.TextBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents TextBox_Shield As Windows.Forms.TextBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents TextBox_Health As Windows.Forms.TextBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents TextBox_Armor As Windows.Forms.TextBox
    Friend WithEvents ComboBox_Warframes As Windows.Forms.ComboBox
    Friend WithEvents Warframe_VariantSelection As EHP_Calculator_Controls.VariantSelection
End Class
