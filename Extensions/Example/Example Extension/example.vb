

Imports System.ComponentModel.Composition
Imports System.Windows.Forms
Imports MEFContracts.Interfaces

<Export(GetType(IMethods))>
<ExportMetadata("Name", "Example")>
<ExportMetadata("Description", "An Example Extension for Warframe Util")>
<ExportMetadata("Author", "Bradley 'cmd430' Treweek")>
<ExportMetadata("Version", "0.0.1")>
Public Class example
    Implements IMethods

    <Import(GetType(ISettings))>
    Public Settings As ISettings

    Public Function Init() As Object Implements IMethods.Init
        Me.FormBorderStyle = FormBorderStyle.None
        Me.TopLevel = False
        Me.Dock = DockStyle.Fill
        Me.Show()
        Return Me
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox("this is an example extension")
    End Sub

    Private Sub example_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class