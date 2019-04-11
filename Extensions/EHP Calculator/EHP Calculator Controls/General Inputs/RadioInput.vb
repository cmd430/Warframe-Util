Imports System.ComponentModel

Public Class RadioInput
    Inherits UserControl

    Private __checkedValue As Boolean = False
    Private __currentText As String = ""
    Private __currentValue As Integer = 0
    Private __maxValue As Integer = 5
    Private __minValue As Integer = 0
    Private __incrementValue As Integer = 1

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
        Set(value As String)
            __currentText = value
            RadioButton1.Text = __currentText & ":"
        End Set
    End Property

    <Category("!Properties")>
    <DefaultValue(False)>
    <Browsable(True)>
    Public Property Checked As Boolean
        Get
            Return __checkedValue
        End Get
        Set(ByVal Value As Boolean)
            __checkedValue = Value
            RadioButton1.Checked = __checkedValue
        End Set
    End Property
    Public Event CheckedChanged As EventHandler
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Checked = sender.Checked
        If Checked Then
            Dim parentControl As Control = Me.Parent
            If parentControl Is Nothing Then Return
            For Each childControl As Control In parentControl.Controls
                If TypeOf childControl Is RadioInput Then
                    If Not childControl.Equals(Me) Then
                        TryCast(childControl, RadioInput).Checked = False
                    Else
                        RadioButton1.Checked = True
                    End If
                End If
            Next
        End If
        RaiseEvent CheckedChanged(sender, e)
    End Sub

    <Category("!Properties")>
    <DefaultValue(5)>
    <Browsable(True)>
    Public Property Maximum As Integer
        Get
            Return __maxValue
        End Get
        Set(ByVal Value As Integer)
            __maxValue = Value
            NumericUpDown1.Maximum = __maxValue
        End Set
    End Property

    <Category("!Properties")>
    <DefaultValue(0)>
    <Browsable(True)>
    Public Property Minimum As Integer
        Get
            Return __minValue
        End Get
        Set(ByVal Value As Integer)
            __minValue = Value
            NumericUpDown1.Minimum = __minValue
        End Set
    End Property

    <Category("!Properties")>
    <DefaultValue(1)>
    <Browsable(True)>
    Public Property Increment As Integer
        Get
            Return __incrementValue
        End Get
        Set(ByVal Value As Integer)
            __incrementValue = Value
            NumericUpDown1.Increment = __incrementValue
        End Set
    End Property

    <Category("!Properties")>
    <DefaultValue(0)>
    <Browsable(True)>
    Public Property Value As Integer
        Get
            Return __currentValue
        End Get
        Set(ByVal Value As Integer)
            __currentValue = Value
            NumericUpDown1.Value = __currentValue
        End Set
    End Property

End Class