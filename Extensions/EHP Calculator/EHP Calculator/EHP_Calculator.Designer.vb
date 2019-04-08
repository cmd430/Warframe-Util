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
        Me.ComboBox_Warframes = New System.Windows.Forms.ComboBox()
        Me.CheckedGroupBox1 = New EHP_Calculator_Controls.CheckedGroupBox()
        Me.StatBox_EffectiveHealth = New EHP_Calculator_Controls.StatBox()
        Me.StatBox_PowerStrength = New EHP_Calculator_Controls.StatBox()
        Me.StatBox_Energy = New EHP_Calculator_Controls.StatBox()
        Me.StatBox_Shield = New EHP_Calculator_Controls.StatBox()
        Me.StatBox_Health = New EHP_Calculator_Controls.StatBox()
        Me.StatBox_Armor = New EHP_Calculator_Controls.StatBox()
        Me.Warframe_VariantSelection = New EHP_Calculator_Controls.VariantSelection()
        Me.SuspendLayout()
        '
        'ComboBox_Warframes
        '
        Me.ComboBox_Warframes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Warframes.FormattingEnabled = True
        Me.ComboBox_Warframes.Items.AddRange(New Object() {"Select a Warframe"})
        Me.ComboBox_Warframes.Location = New System.Drawing.Point(12, 12)
        Me.ComboBox_Warframes.Name = "ComboBox_Warframes"
        Me.ComboBox_Warframes.Size = New System.Drawing.Size(200, 21)
        Me.ComboBox_Warframes.TabIndex = 16
        '
        'CheckedGroupBox1
        '
        Me.CheckedGroupBox1.Checked = False
        Me.CheckedGroupBox1.Location = New System.Drawing.Point(12, 39)
        Me.CheckedGroupBox1.Name = "CheckedGroupBox1"
        Me.CheckedGroupBox1.Size = New System.Drawing.Size(200, 46)
        Me.CheckedGroupBox1.TabIndex = 38
        Me.CheckedGroupBox1.TabStop = False
        Me.CheckedGroupBox1.Text = "Auras"
        '
        'StatBox_EffectiveHealth
        '
        Me.StatBox_EffectiveHealth.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StatBox_EffectiveHealth.Label = "Effective Health"
        Me.StatBox_EffectiveHealth.Location = New System.Drawing.Point(614, 169)
        Me.StatBox_EffectiveHealth.MaximumSize = New System.Drawing.Size(175, 20)
        Me.StatBox_EffectiveHealth.MinimumSize = New System.Drawing.Size(175, 20)
        Me.StatBox_EffectiveHealth.Name = "StatBox_EffectiveHealth"
        Me.StatBox_EffectiveHealth.Rounding = "up"
        Me.StatBox_EffectiveHealth.Size = New System.Drawing.Size(175, 20)
        Me.StatBox_EffectiveHealth.TabIndex = 37
        Me.StatBox_EffectiveHealth.Value = "0"
        '
        'StatBox_PowerStrength
        '
        Me.StatBox_PowerStrength.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StatBox_PowerStrength.Label = "Power Strength"
        Me.StatBox_PowerStrength.Location = New System.Drawing.Point(614, 143)
        Me.StatBox_PowerStrength.MaximumSize = New System.Drawing.Size(175, 20)
        Me.StatBox_PowerStrength.MinimumSize = New System.Drawing.Size(175, 20)
        Me.StatBox_PowerStrength.Name = "StatBox_PowerStrength"
        Me.StatBox_PowerStrength.Rounding = "down"
        Me.StatBox_PowerStrength.Size = New System.Drawing.Size(175, 20)
        Me.StatBox_PowerStrength.TabIndex = 36
        Me.StatBox_PowerStrength.Value = "0"
        '
        'StatBox_Energy
        '
        Me.StatBox_Energy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StatBox_Energy.Label = "Energy"
        Me.StatBox_Energy.Location = New System.Drawing.Point(614, 117)
        Me.StatBox_Energy.MaximumSize = New System.Drawing.Size(175, 20)
        Me.StatBox_Energy.MinimumSize = New System.Drawing.Size(175, 20)
        Me.StatBox_Energy.Name = "StatBox_Energy"
        Me.StatBox_Energy.Rounding = "down"
        Me.StatBox_Energy.Size = New System.Drawing.Size(175, 20)
        Me.StatBox_Energy.TabIndex = 35
        Me.StatBox_Energy.Value = "0"
        '
        'StatBox_Shield
        '
        Me.StatBox_Shield.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StatBox_Shield.Label = "Shield"
        Me.StatBox_Shield.Location = New System.Drawing.Point(614, 91)
        Me.StatBox_Shield.MaximumSize = New System.Drawing.Size(175, 20)
        Me.StatBox_Shield.MinimumSize = New System.Drawing.Size(175, 20)
        Me.StatBox_Shield.Name = "StatBox_Shield"
        Me.StatBox_Shield.Rounding = "down"
        Me.StatBox_Shield.Size = New System.Drawing.Size(175, 20)
        Me.StatBox_Shield.TabIndex = 34
        Me.StatBox_Shield.Value = "0"
        '
        'StatBox_Health
        '
        Me.StatBox_Health.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StatBox_Health.Label = "Health"
        Me.StatBox_Health.Location = New System.Drawing.Point(614, 65)
        Me.StatBox_Health.MaximumSize = New System.Drawing.Size(175, 20)
        Me.StatBox_Health.MinimumSize = New System.Drawing.Size(175, 20)
        Me.StatBox_Health.Name = "StatBox_Health"
        Me.StatBox_Health.Rounding = "down"
        Me.StatBox_Health.Size = New System.Drawing.Size(175, 20)
        Me.StatBox_Health.TabIndex = 33
        Me.StatBox_Health.Value = "0"
        '
        'StatBox_Armor
        '
        Me.StatBox_Armor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StatBox_Armor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatBox_Armor.Label = "Armor"
        Me.StatBox_Armor.Location = New System.Drawing.Point(614, 39)
        Me.StatBox_Armor.MaximumSize = New System.Drawing.Size(175, 20)
        Me.StatBox_Armor.MinimumSize = New System.Drawing.Size(175, 20)
        Me.StatBox_Armor.Name = "StatBox_Armor"
        Me.StatBox_Armor.Rounding = "down"
        Me.StatBox_Armor.Size = New System.Drawing.Size(175, 20)
        Me.StatBox_Armor.TabIndex = 32
        Me.StatBox_Armor.Value = "0"
        '
        'Warframe_VariantSelection
        '
        Me.Warframe_VariantSelection.AvailableVariants = "base"
        Me.Warframe_VariantSelection.Location = New System.Drawing.Point(218, 12)
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
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(801, 559)
        Me.Controls.Add(Me.CheckedGroupBox1)
        Me.Controls.Add(Me.StatBox_EffectiveHealth)
        Me.Controls.Add(Me.StatBox_PowerStrength)
        Me.Controls.Add(Me.StatBox_Energy)
        Me.Controls.Add(Me.StatBox_Shield)
        Me.Controls.Add(Me.StatBox_Health)
        Me.Controls.Add(Me.StatBox_Armor)
        Me.Controls.Add(Me.Warframe_VariantSelection)
        Me.Controls.Add(Me.ComboBox_Warframes)
        Me.Name = "EHP_Calculator"
        Me.Text = "EHP_Calculator_with_GUI"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ComboBox_Warframes As Windows.Forms.ComboBox
    Friend WithEvents Warframe_VariantSelection As EHP_Calculator_Controls.VariantSelection
    Friend WithEvents StatBox_Armor As EHP_Calculator_Controls.StatBox
    Friend WithEvents StatBox_Health As EHP_Calculator_Controls.StatBox
    Friend WithEvents StatBox_Shield As EHP_Calculator_Controls.StatBox
    Friend WithEvents StatBox_Energy As EHP_Calculator_Controls.StatBox
    Friend WithEvents StatBox_PowerStrength As EHP_Calculator_Controls.StatBox
    Friend WithEvents StatBox_EffectiveHealth As EHP_Calculator_Controls.StatBox
    Friend WithEvents CheckedGroupBox1 As EHP_Calculator_Controls.CheckedGroupBox
End Class
