Imports MEFContracts.Interfaces
Imports System.ComponentModel.Composition
Imports System.ComponentModel.Composition.Hosting
Imports System.IO
Imports System.Reflection

Public Class Warframe_PluginHost

    <ImportMany()>
    Private Property Extensions As IEnumerable(Of Lazy(Of IMethods, IMeta))
    Private __container As CompositionContainer

    Public Sub New()
        AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf DoResolve
        InitializeComponent()
        CreateIfMissing("Data\Extensions")
        CreateIfMissing("Data\Logs")
        CreateIfMissing("Data\Settings")
        Dim catalog As New AggregateCatalog
        catalog.Catalogs.Add(New AssemblyCatalog(GetType(Warframe_PluginHost).Assembly))
        catalog.Catalogs.Add(New DirectoryCatalog("Data\Extensions"))
        __container = New CompositionContainer(catalog)
        Try
            __container.ComposeParts(Me)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Function DoResolve(ByVal sender As Object, ByVal e As ResolveEventArgs) As Assembly
        Dim file As String = e.Name.Substring(0, InStr(e.Name, ",") - 1) & ".dll"
        If file.Contains(".resources") Then
            Return Nothing
        Else
            Return Assembly.LoadFrom("Data\Libs\" & file)
        End If
    End Function

    Private Sub CreateIfMissing(path As String)
        If Not Directory.Exists(path) Then Directory.CreateDirectory(path)
    End Sub

    Private Sub Warframe_PluginHost_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim ExtensionInfo As String = ""
            For Each i As Lazy(Of IMethods, IMeta) In Extensions
                If Not i.Metadata.Name = "" Then
                    TabControl_PluginHost.TabPages.Add(i.Value.Init(New TabPage With {
                        .Text = i.Metadata.Name.ToString()
                    }))
                    ExtensionInfo =
                        ExtensionInfo &
                        "======================================" & vbCrLf &
                        "Name: " & i.Metadata.Name.ToString() & vbCrLf &
                        "--------------------------------------" & vbCrLf &
                        "Version: " & i.Metadata.Version.ToString() & vbCrLf &
                        "Author: " & i.Metadata.Author.ToString() & vbCrLf &
                        "Description: " & i.Metadata.Description.ToString() & vbCrLf &
                        "======================================" & vbCrLf & vbCrLf & vbCrLf
                End If
            Next
            If Extensions.Count = 0 Then
                Label_NoExtentionsLoaded.Visible = True
                ExtensionInfo = "No Extensions Loaded"
            End If
            File.WriteAllText("Data\Logs\Loaded Plugins.log", ExtensionInfo.TrimEnd)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

End Class



<Export(GetType(ISettings))>
Public Class Settings
    Implements ISettings
    '
    ' Functions for Extentions to Manipulate Settings
    '
    Private Declare Unicode Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringW" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Int32
    Private Declare Unicode Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringW" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Int32, ByVal lpFileName As String) As Int32

    'Read INI File and Return Value of Param or Default if Undefined
    Public Function GetValue(ByVal Section As String, ByVal ParamName As String, Optional ByVal ParamDefault As String = "") As String Implements ISettings.GetValue
        Dim ExtentionName As String = Reflection.Assembly.GetCallingAssembly().GetName().Name.ToString()
        Dim SettingFile As String = "Data\Settings\" & ExtentionName & ".ini"
        Dim ParamVal As String = Space$(1024)
        Dim LenParamVal As Long = GetPrivateProfileString(Section, ParamName, ParamDefault, ParamVal, Len(ParamVal), SettingFile)
        Return Left$(ParamVal, LenParamVal)
    End Function

    'Write INI Param Value to File and Return TRUE|FALSE if Value is saved
    Public Function SetValue(ByVal Section As String, ByVal ParamName As String, ByVal ParamValue As String) As Boolean Implements ISettings.SetValue
        Dim ExtentionName As String = Reflection.Assembly.GetCallingAssembly().GetName().Name.ToString()
        Dim SettingFile As String = "Data\Settings\" & ExtentionName & ".ini"
        Return WritePrivateProfileString(Section, ParamName, ParamValue, SettingFile)
    End Function

End Class