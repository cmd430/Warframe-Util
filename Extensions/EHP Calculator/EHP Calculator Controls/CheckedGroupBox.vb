Imports System.ComponentModel

'
' This contains code that is based on the code by `jeffb42` from codeproject
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
        AddHandler HeaderCheckBox.CheckedChanged, AddressOf EnableDisableControls
        AddHandler HeaderCheckBox.Layout, AddressOf EnableDisableControls
        AddHandler Layout, AddressOf AddCheckEventListeners
    End Sub

    <Category("!Properties")>
    <DefaultValue("")>
    <Browsable(True)>
    Public Overrides Property Text() As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal Value As String)
            MyBase.Text = Value
            HeaderCheckBox.Text = Value
        End Set
    End Property

    <Category("!Properties")>
    <DefaultValue(False)>
    <Browsable(True)>
    Public Property Checked() As Boolean
        Get
            Return HeaderCheckBox.Checked
        End Get
        Set(ByVal Value As Boolean)
            HeaderCheckBox.Checked = Value
        End Set
    End Property
    Private Sub EnableDisableControls(ByVal sender As Object, ByVal e As EventArgs)
        For Each control As Control In Controls
            If Not control Is HeaderCheckBox Then
                Try
                    control.Enabled = HeaderCheckBox.Checked
                Catch ex As Exception
                End Try
            End If
        Next control
    End Sub

    <Category("!Properties")>
    <Description("Only allow 'Limit' Items Checked")>
    <DefaultValue(False)>
    <Browsable(True)>
    Public Property Limited As Boolean = False
    <Category("!Properties")>
    <Description("Used when Limited is 'True'")>
    <DefaultValue(False)>
    <Browsable(True)>
    Public Property Limit As Integer = 2
    Public Sub AddCheckEventListeners()
        For Each control As Control In Controls
            Dim checkedInput As CheckedInput = TryCast(control, CheckedInput)
            If checkedInput IsNot Nothing Then
                AddHandler checkedInput.CheckedChanged, AddressOf ChildControlCheckChanged
            End If
        Next
    End Sub
    Private Sub ChildControlCheckChanged(ByVal sender As Object, ByVal e As EventArgs)
        If Limited Then
            Dim checkedControls As Integer = 0
            For Each control In Controls.OfType(Of CheckedInput)
                If control.Checked Then
                    checkedControls += 1
                End If
            Next
            If checkedControls = Limit Then
                For Each control In Controls.OfType(Of CheckedInput)
                    If Not control.Checked Then
                        control.Enabled = False
                    End If
                Next
            Else
                For Each control In Controls.OfType(Of CheckedInput)
                    control.Enabled = True
                Next
            End If
        End If
    End Sub

End Class