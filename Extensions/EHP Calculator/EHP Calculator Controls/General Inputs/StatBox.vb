Imports System.ComponentModel

Public Class StatBox

    Private __currentLabel As String = "StatLabel"
    Private __currentValue As Decimal = 0

    <Category("Appearance")>
    Public Property Label As String
        Get
            Return __currentLabel
        End Get
        Set(value As String)
            __currentLabel = value
            StatLabel.Text = __currentLabel & ":"
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
