Imports System.Windows.Forms

Public Class GUI

    Private Declare Unicode Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringW" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Int32
    Private Declare Unicode Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringW" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Int32, ByVal lpFileName As String) As Int32

    Private Function GetValue(ByVal Section As String, ByVal ParamName As String, Optional ByVal ParamDefault As String = "") As String
        Dim ExtentionName As String = Reflection.Assembly.GetCallingAssembly().GetName().Name.ToString()
        Dim SettingFile As String = "Data\Settings\" & ExtentionName & ".ini"
        Dim ParamVal As String = Space$(1024)
        Dim LenParamVal As Long = GetPrivateProfileString(Section, ParamName, ParamDefault, ParamVal, Len(ParamVal), SettingFile)
        Return Strings.Left$(ParamVal, LenParamVal)
    End Function

    Private Function SetValue(ByVal Section As String, ByVal ParamName As String, ByVal ParamValue As String) As Boolean
        Dim ExtentionName As String = Reflection.Assembly.GetCallingAssembly().GetName().Name.ToString()
        Dim SettingFile As String = "Data\Settings\" & ExtentionName & ".ini"
        Return WritePrivateProfileString(Section, ParamName, ParamValue, SettingFile)
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim SquadMebers As String = Panel_SquadMembers.Controls.OfType(Of RadioButton).FirstOrDefault(Function(r) r.Checked = True).Text
        SetValue("settings", "squad_members", SquadMebers)
    End Sub

    Private Sub GUI_Load(sender As Object, e As EventArgs) Handles Me.Load
        GetValue("settings", "squad_members", "1")
    End Sub
End Class
