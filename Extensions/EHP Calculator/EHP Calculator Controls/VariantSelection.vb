Imports System.ComponentModel

Public Class VariantSelection
    Inherits UserControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AddHandler CheckBox_Prime.CheckedChanged, AddressOf CheckedChanged
        AddHandler CheckBox_Umbra.CheckedChanged, AddressOf CheckedChanged
    End Sub


    Public Event SelectedVariantChanged(sender As Object, e As EventArgs)

    Private __SelectedVariant As String = "base"
    Private __AvailableVariants As String = "base"

    <Browsable(False)>
    Public Property SelectedVariant As String
        Get
            Return __SelectedVariant
        End Get
        Set(value As String)
            If value = "base" Then
                CheckBox_Prime.Checked = False
                CheckBox_Umbra.Checked = False
            ElseIf value = "prime" Then
                CheckBox_Prime.Checked = True
                CheckBox_Umbra.Checked = False
            ElseIf value = "umbra" Then
                CheckBox_Prime.Checked = False
                CheckBox_Umbra.Checked = True
            End If
            __SelectedVariant = value
        End Set
    End Property

    <Browsable(False)>
    Public Property AvailableVariants As String
        Get
            Return __AvailableVariants
        End Get
        Set(value As String)
            If value = "base" Then
                CheckBox_Prime.Enabled = False
                CheckBox_Umbra.Enabled = False
            ElseIf value = "prime" Then
                CheckBox_Prime.Enabled = True
                CheckBox_Umbra.Enabled = False
            ElseIf value = "umbra" Then
                CheckBox_Prime.Enabled = False
                CheckBox_Umbra.Enabled = True
            ElseIf value = "prime_umbra" Then
                CheckBox_Prime.Enabled = True
                CheckBox_Umbra.Enabled = True
            End If
            __AvailableVariants = value
        End Set
    End Property

    Private Shadows Sub CheckedChanged(sender As Object, e As EventArgs)
        RemoveHandler CheckBox_Prime.CheckedChanged, AddressOf CheckedChanged
        RemoveHandler CheckBox_Umbra.CheckedChanged, AddressOf CheckedChanged
        If (SelectedVariant = "prime" And sender.Name.contains("Prime")) Or (SelectedVariant = "umbra" And sender.Name.contains("Umbra")) Then
            SelectedVariant = "base"
        Else
            SelectedVariant = sender.Text.ToString().ToLower()
        End If
        RaiseEvent SelectedVariantChanged(Me, New EventArgs())
        AddHandler CheckBox_Prime.CheckedChanged, AddressOf CheckedChanged
        AddHandler CheckBox_Umbra.CheckedChanged, AddressOf CheckedChanged
    End Sub

End Class
