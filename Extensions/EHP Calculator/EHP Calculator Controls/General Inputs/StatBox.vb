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
    <Category("!Properties")>
    Public Overrides Property Text As String
        Get
            Return __currentText
        End Get
        Set(ByVal Value As String)
            __currentText = Value
            StatLabel.Text = __currentText & ":"
        End Set
    End Property

    <TypeConverter(GetType(EnumConverter))>
    Public Enum RoundingValues
        None
        Floor
        Ceiling
    End Enum
    <Category("!Properties")>
    <DefaultValue(RoundingValues.Floor)>
    <Browsable(True)>
    Public Property Rounding As New RoundingValues

    <Category("!Properties")>
    <DefaultValue(0)>
    <Browsable(False)>
    Public Property Value As String
        Get
            Return __currentValue
        End Get
        Set(ByVal Value As String)
            __currentValue = Value
            If __currentValue = Nothing Then
                StatValue.Text = "-"
            Else
                If Rounding = RoundingValues.None Then
                    StatValue.Text = __currentValue
                ElseIf Rounding = RoundingValues.Floor Then
                    StatValue.Text = Math.Floor(__currentValue)
                ElseIf Rounding = RoundingValues.Ceiling Then
                    StatValue.Text = Math.Ceiling(__currentValue)
                End If
            End If
        End Set
    End Property

End Class
