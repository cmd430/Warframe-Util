Imports System.ComponentModel

Public Class StatBox
    Inherits UserControl

    Private __currentText As String = ""
    Private __currentValue As Decimal = 0

    Public Sub New()
        InitializeComponent()
        Text = Name
    End Sub

    <EditorBrowsable(EditorBrowsableState.Always)>
    <Browsable(True)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    <Bindable(True)>
    <Category("Appearance")>
    Public Overrides Property Text As String
        Get
            Return __currentText
        End Get
        Set(value As String)
            __currentText = value
            StatLabel.Text = __currentText & ":"
        End Set
    End Property

    <Category("Behavior")>
    Public Property Rounding As String = "down"

    <Category("Appearance")>
    Public Property Value As String
        Get
            Return __currentValue
        End Get
        Set(value As String)
            __currentValue = value
            If __currentValue = Nothing Then
                StatValue.Text = "-"
            Else
                If Rounding = "down" Then
                    StatValue.Text = Math.Floor(__currentValue)
                ElseIf Rounding = "up" Then
                    StatValue.Text = Math.Ceiling(__currentValue)
                Else
                    StatValue.Text = __currentValue
                End If

            End If
        End Set
    End Property

End Class
