<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Warframe_PluginHost
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Warframe_PluginHost))
        Me.TabControl_PluginHost = New System.Windows.Forms.TabControl()
        Me.Label_NoExtentionsLoaded = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripButton_Settings = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripDrop_Info = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripDivider = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl_PluginHost
        '
        Me.TabControl_PluginHost.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl_PluginHost.Location = New System.Drawing.Point(0, 0)
        Me.TabControl_PluginHost.Name = "TabControl_PluginHost"
        Me.TabControl_PluginHost.SelectedIndex = 0
        Me.TabControl_PluginHost.Size = New System.Drawing.Size(795, 496)
        Me.TabControl_PluginHost.TabIndex = 0
        '
        'Label_NoExtentionsLoaded
        '
        Me.Label_NoExtentionsLoaded.BackColor = System.Drawing.Color.White
        Me.Label_NoExtentionsLoaded.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_NoExtentionsLoaded.Location = New System.Drawing.Point(0, 0)
        Me.Label_NoExtentionsLoaded.Name = "Label_NoExtentionsLoaded"
        Me.Label_NoExtentionsLoaded.Size = New System.Drawing.Size(795, 474)
        Me.Label_NoExtentionsLoaded.TabIndex = 1
        Me.Label_NoExtentionsLoaded.Text = "No Extentions Loaded"
        Me.Label_NoExtentionsLoaded.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.White
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton_Settings, Me.ToolStripDivider, Me.ToolStripDrop_Info})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 474)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(795, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripButton_Settings
        '
        Me.ToolStripButton_Settings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton_Settings.Image = CType(resources.GetObject("ToolStripButton_Settings.Image"), System.Drawing.Image)
        Me.ToolStripButton_Settings.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Settings.Name = "ToolStripButton_Settings"
        Me.ToolStripButton_Settings.ShowDropDownArrow = False
        Me.ToolStripButton_Settings.Size = New System.Drawing.Size(53, 20)
        Me.ToolStripButton_Settings.Text = "Settings"
        '
        'ToolStripDrop_Info
        '
        Me.ToolStripDrop_Info.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDrop_Info.Image = CType(resources.GetObject("ToolStripDrop_Info.Image"), System.Drawing.Image)
        Me.ToolStripDrop_Info.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDrop_Info.Name = "ToolStripDrop_Info"
        Me.ToolStripDrop_Info.Size = New System.Drawing.Size(41, 20)
        Me.ToolStripDrop_Info.Text = "Info"
        '
        'ToolStripDivider
        '
        Me.ToolStripDivider.Name = "ToolStripDivider"
        Me.ToolStripDivider.Size = New System.Drawing.Size(10, 17)
        Me.ToolStripDivider.Text = "|"
        '
        'Warframe_PluginHost
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(795, 496)
        Me.Controls.Add(Me.Label_NoExtentionsLoaded)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TabControl_PluginHost)
        Me.Name = "Warframe_PluginHost"
        Me.Text = "Warframe Util"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TabControl_PluginHost As TabControl
    Friend WithEvents Label_NoExtentionsLoaded As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripButton_Settings As ToolStripDropDownButton
    Friend WithEvents ToolStripDrop_Info As ToolStripDropDownButton
    Friend WithEvents ToolStripDivider As ToolStripStatusLabel
End Class
