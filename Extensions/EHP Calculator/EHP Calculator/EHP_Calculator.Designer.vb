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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.StatBox_Armor = New EHP_Calculator_Controls.StatBox()
        Me.StatBox_Health = New EHP_Calculator_Controls.StatBox()
        Me.StatBox_Shield = New EHP_Calculator_Controls.StatBox()
        Me.StatBox_EffectiveHealth = New EHP_Calculator_Controls.StatBox()
        Me.StatBox_Energy = New EHP_Calculator_Controls.StatBox()
        Me.StatBox_PowerStrength = New EHP_Calculator_Controls.StatBox()
        Me.CheckedGroupBox_Test = New EHP_Calculator_Controls.CheckedGroupBox()
        Me.CheckedInput3 = New EHP_Calculator_Controls.CheckedInput()
        Me.RadioInput1 = New EHP_Calculator_Controls.RadioInput()
        Me.CheckedInput2 = New EHP_Calculator_Controls.CheckedInput()
        Me.RadioInput2 = New EHP_Calculator_Controls.RadioInput()
        Me.CheckedInput1 = New EHP_Calculator_Controls.CheckedInput()
        Me.RadioInput3 = New EHP_Calculator_Controls.RadioInput()
        Me.CheckedGroupBox1 = New EHP_Calculator_Controls.CheckedGroupBox()
        Me.Warframe_VariantSelection = New EHP_Calculator_Controls.VariantSelection()
        Me.GroupBox1.SuspendLayout()
        Me.CheckedGroupBox_Test.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboBox_Warframes
        '
        Me.ComboBox_Warframes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Warframes.FormattingEnabled = True
        Me.ComboBox_Warframes.Items.AddRange(New Object() {"Select a Warframe"})
        Me.ComboBox_Warframes.Location = New System.Drawing.Point(12, 12)
        Me.ComboBox_Warframes.Name = "ComboBox_Warframes"
        Me.ComboBox_Warframes.Size = New System.Drawing.Size(187, 21)
        Me.ComboBox_Warframes.TabIndex = 16
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.StatBox_Armor)
        Me.GroupBox1.Controls.Add(Me.StatBox_Health)
        Me.GroupBox1.Controls.Add(Me.StatBox_Shield)
        Me.GroupBox1.Controls.Add(Me.StatBox_EffectiveHealth)
        Me.GroupBox1.Controls.Add(Me.StatBox_Energy)
        Me.GroupBox1.Controls.Add(Me.StatBox_PowerStrength)
        Me.GroupBox1.Location = New System.Drawing.Point(602, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(187, 229)
        Me.GroupBox1.TabIndex = 46
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Stats"
        '
        'StatBox_Armor
        '
        Me.StatBox_Armor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StatBox_Armor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatBox_Armor.Location = New System.Drawing.Point(6, 28)
        Me.StatBox_Armor.MaximumSize = New System.Drawing.Size(175, 20)
        Me.StatBox_Armor.MinimumSize = New System.Drawing.Size(175, 20)
        Me.StatBox_Armor.Name = "StatBox_Armor"
        Me.StatBox_Armor.Rounding = "down"
        Me.StatBox_Armor.Size = New System.Drawing.Size(175, 20)
        Me.StatBox_Armor.TabIndex = 32
        Me.StatBox_Armor.Text = "Armor"
        Me.StatBox_Armor.Value = "0"
        '
        'StatBox_Health
        '
        Me.StatBox_Health.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StatBox_Health.Location = New System.Drawing.Point(6, 54)
        Me.StatBox_Health.MaximumSize = New System.Drawing.Size(175, 20)
        Me.StatBox_Health.MinimumSize = New System.Drawing.Size(175, 20)
        Me.StatBox_Health.Name = "StatBox_Health"
        Me.StatBox_Health.Rounding = "down"
        Me.StatBox_Health.Size = New System.Drawing.Size(175, 20)
        Me.StatBox_Health.TabIndex = 33
        Me.StatBox_Health.Text = "Health"
        Me.StatBox_Health.Value = "0"
        '
        'StatBox_Shield
        '
        Me.StatBox_Shield.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StatBox_Shield.Location = New System.Drawing.Point(6, 80)
        Me.StatBox_Shield.MaximumSize = New System.Drawing.Size(175, 20)
        Me.StatBox_Shield.MinimumSize = New System.Drawing.Size(175, 20)
        Me.StatBox_Shield.Name = "StatBox_Shield"
        Me.StatBox_Shield.Rounding = "down"
        Me.StatBox_Shield.Size = New System.Drawing.Size(175, 20)
        Me.StatBox_Shield.TabIndex = 34
        Me.StatBox_Shield.Text = "Shield"
        Me.StatBox_Shield.Value = "0"
        '
        'StatBox_EffectiveHealth
        '
        Me.StatBox_EffectiveHealth.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StatBox_EffectiveHealth.Location = New System.Drawing.Point(6, 190)
        Me.StatBox_EffectiveHealth.MaximumSize = New System.Drawing.Size(175, 20)
        Me.StatBox_EffectiveHealth.MinimumSize = New System.Drawing.Size(175, 20)
        Me.StatBox_EffectiveHealth.Name = "StatBox_EffectiveHealth"
        Me.StatBox_EffectiveHealth.Rounding = "up"
        Me.StatBox_EffectiveHealth.Size = New System.Drawing.Size(175, 20)
        Me.StatBox_EffectiveHealth.TabIndex = 37
        Me.StatBox_EffectiveHealth.Text = "Effective Health"
        Me.StatBox_EffectiveHealth.Value = "0"
        '
        'StatBox_Energy
        '
        Me.StatBox_Energy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StatBox_Energy.Location = New System.Drawing.Point(6, 106)
        Me.StatBox_Energy.MaximumSize = New System.Drawing.Size(175, 20)
        Me.StatBox_Energy.MinimumSize = New System.Drawing.Size(175, 20)
        Me.StatBox_Energy.Name = "StatBox_Energy"
        Me.StatBox_Energy.Rounding = "down"
        Me.StatBox_Energy.Size = New System.Drawing.Size(175, 20)
        Me.StatBox_Energy.TabIndex = 35
        Me.StatBox_Energy.Text = "Energy"
        Me.StatBox_Energy.Value = "0"
        '
        'StatBox_PowerStrength
        '
        Me.StatBox_PowerStrength.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StatBox_PowerStrength.Location = New System.Drawing.Point(6, 132)
        Me.StatBox_PowerStrength.MaximumSize = New System.Drawing.Size(175, 20)
        Me.StatBox_PowerStrength.MinimumSize = New System.Drawing.Size(175, 20)
        Me.StatBox_PowerStrength.Name = "StatBox_PowerStrength"
        Me.StatBox_PowerStrength.Rounding = "down"
        Me.StatBox_PowerStrength.Size = New System.Drawing.Size(175, 20)
        Me.StatBox_PowerStrength.TabIndex = 36
        Me.StatBox_PowerStrength.Text = "Power Strength"
        Me.StatBox_PowerStrength.Value = "0"
        '
        'CheckedGroupBox_Test
        '
        Me.CheckedGroupBox_Test.AutoSize = True
        Me.CheckedGroupBox_Test.Checked = False
        Me.CheckedGroupBox_Test.Controls.Add(Me.CheckedInput3)
        Me.CheckedGroupBox_Test.Controls.Add(Me.RadioInput1)
        Me.CheckedGroupBox_Test.Controls.Add(Me.CheckedInput2)
        Me.CheckedGroupBox_Test.Controls.Add(Me.RadioInput2)
        Me.CheckedGroupBox_Test.Controls.Add(Me.CheckedInput1)
        Me.CheckedGroupBox_Test.Controls.Add(Me.RadioInput3)
        Me.CheckedGroupBox_Test.Location = New System.Drawing.Point(218, 202)
        Me.CheckedGroupBox_Test.Name = "CheckedGroupBox_Test"
        Me.CheckedGroupBox_Test.Size = New System.Drawing.Size(187, 229)
        Me.CheckedGroupBox_Test.TabIndex = 45
        Me.CheckedGroupBox_Test.TabStop = False
        Me.CheckedGroupBox_Test.Text = "Tests"
        '
        'CheckedInput3
        '
        Me.CheckedInput3.Checked = False
        Me.CheckedInput3.Increment = 1
        Me.CheckedInput3.Location = New System.Drawing.Point(6, 190)
        Me.CheckedInput3.Maximum = 0
        Me.CheckedInput3.MaximumSize = New System.Drawing.Size(175, 20)
        Me.CheckedInput3.Minimum = 0
        Me.CheckedInput3.MinimumSize = New System.Drawing.Size(175, 20)
        Me.CheckedInput3.Name = "CheckedInput3"
        Me.CheckedInput3.Size = New System.Drawing.Size(175, 20)
        Me.CheckedInput3.TabIndex = 44
        Me.CheckedInput3.Text = "CheckedInput3"
        Me.CheckedInput3.Value = 0
        '
        'RadioInput1
        '
        Me.RadioInput1.Checked = False
        Me.RadioInput1.Increment = 1
        Me.RadioInput1.Location = New System.Drawing.Point(6, 28)
        Me.RadioInput1.Maximum = 0
        Me.RadioInput1.MaximumSize = New System.Drawing.Size(175, 20)
        Me.RadioInput1.Minimum = 0
        Me.RadioInput1.MinimumSize = New System.Drawing.Size(175, 20)
        Me.RadioInput1.Name = "RadioInput1"
        Me.RadioInput1.Size = New System.Drawing.Size(175, 20)
        Me.RadioInput1.TabIndex = 39
        Me.RadioInput1.Text = "RadioInput1"
        Me.RadioInput1.Value = 0
        '
        'CheckedInput2
        '
        Me.CheckedInput2.Checked = False
        Me.CheckedInput2.Increment = 1
        Me.CheckedInput2.Location = New System.Drawing.Point(6, 164)
        Me.CheckedInput2.Maximum = 0
        Me.CheckedInput2.MaximumSize = New System.Drawing.Size(175, 20)
        Me.CheckedInput2.Minimum = 0
        Me.CheckedInput2.MinimumSize = New System.Drawing.Size(175, 20)
        Me.CheckedInput2.Name = "CheckedInput2"
        Me.CheckedInput2.Size = New System.Drawing.Size(175, 20)
        Me.CheckedInput2.TabIndex = 43
        Me.CheckedInput2.Text = "CheckedInput2"
        Me.CheckedInput2.Value = 0
        '
        'RadioInput2
        '
        Me.RadioInput2.Checked = False
        Me.RadioInput2.Increment = 1
        Me.RadioInput2.Location = New System.Drawing.Point(6, 54)
        Me.RadioInput2.Maximum = 0
        Me.RadioInput2.MaximumSize = New System.Drawing.Size(175, 20)
        Me.RadioInput2.Minimum = 0
        Me.RadioInput2.MinimumSize = New System.Drawing.Size(175, 20)
        Me.RadioInput2.Name = "RadioInput2"
        Me.RadioInput2.Size = New System.Drawing.Size(175, 20)
        Me.RadioInput2.TabIndex = 40
        Me.RadioInput2.Text = "RadioInput2"
        Me.RadioInput2.Value = 0
        '
        'CheckedInput1
        '
        Me.CheckedInput1.Checked = False
        Me.CheckedInput1.Increment = 1
        Me.CheckedInput1.Location = New System.Drawing.Point(6, 138)
        Me.CheckedInput1.Maximum = 0
        Me.CheckedInput1.MaximumSize = New System.Drawing.Size(175, 20)
        Me.CheckedInput1.Minimum = 0
        Me.CheckedInput1.MinimumSize = New System.Drawing.Size(175, 20)
        Me.CheckedInput1.Name = "CheckedInput1"
        Me.CheckedInput1.Size = New System.Drawing.Size(175, 20)
        Me.CheckedInput1.TabIndex = 42
        Me.CheckedInput1.Text = "CheckedInput1"
        Me.CheckedInput1.Value = 0
        '
        'RadioInput3
        '
        Me.RadioInput3.Checked = False
        Me.RadioInput3.Increment = 1
        Me.RadioInput3.Location = New System.Drawing.Point(6, 80)
        Me.RadioInput3.Maximum = 0
        Me.RadioInput3.MaximumSize = New System.Drawing.Size(175, 20)
        Me.RadioInput3.Minimum = 0
        Me.RadioInput3.MinimumSize = New System.Drawing.Size(175, 20)
        Me.RadioInput3.Name = "RadioInput3"
        Me.RadioInput3.Size = New System.Drawing.Size(175, 20)
        Me.RadioInput3.TabIndex = 41
        Me.RadioInput3.Text = "RadioInput3"
        Me.RadioInput3.Value = 0
        '
        'CheckedGroupBox1
        '
        Me.CheckedGroupBox1.Checked = False
        Me.CheckedGroupBox1.Location = New System.Drawing.Point(12, 39)
        Me.CheckedGroupBox1.Name = "CheckedGroupBox1"
        Me.CheckedGroupBox1.Size = New System.Drawing.Size(187, 46)
        Me.CheckedGroupBox1.TabIndex = 38
        Me.CheckedGroupBox1.TabStop = False
        Me.CheckedGroupBox1.Text = "Auras"
        '
        'Warframe_VariantSelection
        '
        Me.Warframe_VariantSelection.AvailableVariants = "base"
        Me.Warframe_VariantSelection.Location = New System.Drawing.Point(205, 12)
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
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CheckedGroupBox_Test)
        Me.Controls.Add(Me.CheckedGroupBox1)
        Me.Controls.Add(Me.Warframe_VariantSelection)
        Me.Controls.Add(Me.ComboBox_Warframes)
        Me.Name = "EHP_Calculator"
        Me.Text = "EHP_Calculator_with_GUI"
        Me.GroupBox1.ResumeLayout(False)
        Me.CheckedGroupBox_Test.ResumeLayout(False)
        Me.CheckedGroupBox_Test.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Friend WithEvents RadioInput1 As EHP_Calculator_Controls.RadioInput
    Friend WithEvents RadioInput2 As EHP_Calculator_Controls.RadioInput
    Friend WithEvents RadioInput3 As EHP_Calculator_Controls.RadioInput
    Friend WithEvents CheckedInput1 As EHP_Calculator_Controls.CheckedInput
    Friend WithEvents CheckedInput2 As EHP_Calculator_Controls.CheckedInput
    Friend WithEvents CheckedInput3 As EHP_Calculator_Controls.CheckedInput
    Friend WithEvents CheckedGroupBox_Test As EHP_Calculator_Controls.CheckedGroupBox
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
End Class
