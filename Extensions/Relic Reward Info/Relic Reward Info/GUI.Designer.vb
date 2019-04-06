<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GUI
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.RadioButton_SquadMembers1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton_SquadMembers2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton_SquadMembers3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton_SquadMembers4 = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel_SquadMembers = New System.Windows.Forms.Panel()
        Me.GroupBox1.SuspendLayout()
        Me.Panel_SquadMembers.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Panel_SquadMembers)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(307, 162)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Settings"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(226, 133)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'RadioButton_SquadMembers1
        '
        Me.RadioButton_SquadMembers1.AutoSize = True
        Me.RadioButton_SquadMembers1.Checked = True
        Me.RadioButton_SquadMembers1.Location = New System.Drawing.Point(6, 16)
        Me.RadioButton_SquadMembers1.Name = "RadioButton_SquadMembers1"
        Me.RadioButton_SquadMembers1.Size = New System.Drawing.Size(31, 17)
        Me.RadioButton_SquadMembers1.TabIndex = 1
        Me.RadioButton_SquadMembers1.TabStop = True
        Me.RadioButton_SquadMembers1.Text = "1"
        Me.RadioButton_SquadMembers1.UseVisualStyleBackColor = True
        '
        'RadioButton_SquadMembers2
        '
        Me.RadioButton_SquadMembers2.AutoSize = True
        Me.RadioButton_SquadMembers2.Location = New System.Drawing.Point(43, 16)
        Me.RadioButton_SquadMembers2.Name = "RadioButton_SquadMembers2"
        Me.RadioButton_SquadMembers2.Size = New System.Drawing.Size(31, 17)
        Me.RadioButton_SquadMembers2.TabIndex = 2
        Me.RadioButton_SquadMembers2.Text = "2"
        Me.RadioButton_SquadMembers2.UseVisualStyleBackColor = True
        '
        'RadioButton_SquadMembers3
        '
        Me.RadioButton_SquadMembers3.AutoSize = True
        Me.RadioButton_SquadMembers3.Location = New System.Drawing.Point(80, 16)
        Me.RadioButton_SquadMembers3.Name = "RadioButton_SquadMembers3"
        Me.RadioButton_SquadMembers3.Size = New System.Drawing.Size(31, 17)
        Me.RadioButton_SquadMembers3.TabIndex = 3
        Me.RadioButton_SquadMembers3.Text = "3"
        Me.RadioButton_SquadMembers3.UseVisualStyleBackColor = True
        '
        'RadioButton_SquadMembers4
        '
        Me.RadioButton_SquadMembers4.AutoSize = True
        Me.RadioButton_SquadMembers4.Location = New System.Drawing.Point(117, 16)
        Me.RadioButton_SquadMembers4.Name = "RadioButton_SquadMembers4"
        Me.RadioButton_SquadMembers4.Size = New System.Drawing.Size(31, 17)
        Me.RadioButton_SquadMembers4.TabIndex = 4
        Me.RadioButton_SquadMembers4.Text = "4"
        Me.RadioButton_SquadMembers4.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Number of Squad Members"
        '
        'Panel_SquadMembers
        '
        Me.Panel_SquadMembers.Controls.Add(Me.Label1)
        Me.Panel_SquadMembers.Controls.Add(Me.RadioButton_SquadMembers2)
        Me.Panel_SquadMembers.Controls.Add(Me.RadioButton_SquadMembers4)
        Me.Panel_SquadMembers.Controls.Add(Me.RadioButton_SquadMembers1)
        Me.Panel_SquadMembers.Controls.Add(Me.RadioButton_SquadMembers3)
        Me.Panel_SquadMembers.Location = New System.Drawing.Point(6, 19)
        Me.Panel_SquadMembers.Name = "Panel_SquadMembers"
        Me.Panel_SquadMembers.Size = New System.Drawing.Size(295, 36)
        Me.Panel_SquadMembers.TabIndex = 0
        '
        'GUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "GUI"
        Me.Size = New System.Drawing.Size(509, 353)
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel_SquadMembers.ResumeLayout(False)
        Me.Panel_SquadMembers.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents RadioButton_SquadMembers4 As Windows.Forms.RadioButton
    Friend WithEvents RadioButton_SquadMembers3 As Windows.Forms.RadioButton
    Friend WithEvents RadioButton_SquadMembers2 As Windows.Forms.RadioButton
    Friend WithEvents RadioButton_SquadMembers1 As Windows.Forms.RadioButton
    Friend WithEvents Panel_SquadMembers As Windows.Forms.Panel
End Class
