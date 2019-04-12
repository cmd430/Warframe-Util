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
        Me.SuspendLayout()
        '
        'TabControl_PluginHost
        '
        Me.TabControl_PluginHost.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl_PluginHost.Location = New System.Drawing.Point(0, 0)
        Me.TabControl_PluginHost.Name = "TabControl_PluginHost"
        Me.TabControl_PluginHost.SelectedIndex = 0
        Me.TabControl_PluginHost.Size = New System.Drawing.Size(884, 585)
        Me.TabControl_PluginHost.TabIndex = 0
        '
        'Label_NoExtentionsLoaded
        '
        Me.Label_NoExtentionsLoaded.BackColor = System.Drawing.Color.White
        Me.Label_NoExtentionsLoaded.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_NoExtentionsLoaded.Location = New System.Drawing.Point(0, 0)
        Me.Label_NoExtentionsLoaded.Name = "Label_NoExtentionsLoaded"
        Me.Label_NoExtentionsLoaded.Size = New System.Drawing.Size(884, 585)
        Me.Label_NoExtentionsLoaded.TabIndex = 1
        Me.Label_NoExtentionsLoaded.Text = "No Extentions Loaded"
        Me.Label_NoExtentionsLoaded.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label_NoExtentionsLoaded.Visible = False
        '
        'Warframe_PluginHost
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(884, 585)
        Me.Controls.Add(Me.Label_NoExtentionsLoaded)
        Me.Controls.Add(Me.TabControl_PluginHost)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Warframe_PluginHost"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.Text = "Warframe Util"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl_PluginHost As TabControl
    Friend WithEvents Label_NoExtentionsLoaded As Label
End Class
