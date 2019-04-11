Imports System.ComponentModel

Public Class CheckedInput
    Inherits UserControl

    Private __checkedValue As Boolean = False
    Private __currentText As String = ""
    Private __currentValue As Integer = 0
    Private __maxValue As Integer = 10
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
        Set(ByVal Value As String)
            __currentText = Value
            CheckBox1.Text = __currentText & ":"
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
            CheckBox1.Checked = __checkedValue
        End Set
    End Property
    Public Event CheckedChanged As EventHandler
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Checked = sender.Checked
        RaiseEvent CheckedChanged(sender, e)
    End Sub

    <Category("!Properties")>
    <DefaultValue(10)>
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
