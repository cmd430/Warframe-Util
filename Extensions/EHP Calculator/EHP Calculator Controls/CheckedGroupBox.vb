Imports System.ComponentModel

'
' This code is based on the code by `jeffb42` from codeproject
' https://www.codeproject.com/Articles/32780/CheckGroupBox-and-RadioGroupBox
'

Public Class CheckedGroupBox
    Inherits GroupBox

    Private WithEvents HeaderCheckBox As CheckBox

    ' Add the CheckBox to the control.
    Public Sub New()
        MyBase.New()
        HeaderCheckBox = New CheckBox With {
            .Location = New Point(9, 0),
            .AutoSize = True
        }
        Text = Name
        Controls.Add(HeaderCheckBox)
    End Sub

    ' Keep the CheckBox text synced with our text.
    Public Overrides Property Text() As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal Value As String)
            MyBase.Text = Value
            HeaderCheckBox.Text = Value

        End Set
    End Property

    ' Delegate to CheckBox.Checked.
    <Category("Appearance")>
    Public Property Checked() As Boolean
        Get
            Return HeaderCheckBox.Checked
        End Get
        Set(ByVal Value As Boolean)
            HeaderCheckBox.Checked = Value
        End Set
    End Property

    ' Enable/disable contained controls.
    Private Sub EnableDisableControls()
        For Each ctl As Control In Controls
            If Not ctl Is HeaderCheckBox Then
                Try
                    ctl.Enabled = HeaderCheckBox.Checked
                Catch ex As Exception
                End Try
            End If
        Next ctl
    End Sub

    ' Enable/disable contained controls.
    Private Sub HeaderCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles HeaderCheckBox.CheckedChanged
        EnableDisableControls()
    End Sub

    ' Enable/disable contained controls.
    ' We do this here to set editability
    ' when the control is first loaded.
    Private Sub HeaderCheckBox_Layout(ByVal sender As Object, ByVal e As LayoutEventArgs) Handles HeaderCheckBox.Layout
        EnableDisableControls()
    End Sub
End Class