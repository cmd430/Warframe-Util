Imports MEFContracts
Imports MEFContracts.Interfaces
Imports System.ComponentModel.Composition
Imports System.ComponentModel.Composition.Hosting
Imports System.IO
Imports System.Reflection
Imports System.Text.Encoding

Public Class Warframe_PluginHost

    <Import(GetType(ISettings))>
    Public Settings As ISettings
    <Import(GetType(ILogging))>
    Public Log As ILogging

    <ImportMany()>
    Private Property Extensions As IEnumerable(Of Lazy(Of IMethods, IMeta))
    Private __container As CompositionContainer

    Public Sub New()
        SetStyle(ControlStyles.UserPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.SupportsTransparentBackColor, True)
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

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        ' Prevent Resize Lag
        Get
            Dim params As CreateParams = MyBase.CreateParams
            params.ExStyle = params.ExStyle Or &H2000000
            Return params
        End Get
    End Property

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
        Size = New Size(Settings.GetValue("Application_Prefs", "window_width", Size.Width),
                        Settings.GetValue("Application_Prefs", "window_height", Size.Height))
        Location = New Point(Settings.GetValue("Application_Prefs", "window_location_x", Location.X),
                        Settings.GetValue("Application_Prefs", "window_location_y", Location.Y))

        AddHandler ResizeEnd, Sub()
                                  Settings.SetValue("Application_Prefs", "window_width", Size.Width)
                                  Settings.SetValue("Application_Prefs", "window_height", Size.Height)
                              End Sub
        AddHandler Move, Sub()
                             Settings.SetValue("Application_Prefs", "window_location_x", Location.X)
                             Settings.SetValue("Application_Prefs", "window_location_y", Location.Y)
                         End Sub

        Try
            Dim ExtensionInfo As String = ""
            For Each i As Lazy(Of IMethods, IMeta) In Extensions
                If Not i.Metadata.Name = "" Then
                    Dim ext_tabpage = New TabPage With {
                        .Text = i.Metadata.Name.ToString()
                    }
                    ext_tabpage.Controls.Add(i.Value.Init(ext_tabpage))
                    TabControl_PluginHost.TabPages.Add(ext_tabpage)
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
            Log.Write(ExtensionInfo.TrimEnd)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Warframe_PluginHost_ResizeBegin(sender As Object, e As EventArgs) Handles Me.ResizeBegin
        '  SuspendLayout()
    End Sub

    Private Sub Warframe_PluginHost_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd
        ' ResumeLayout()
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
        Dim ExtentionName As String = Assembly.GetCallingAssembly().GetName().Name.ToString()
        Dim SettingFile As String = "Data\Settings\" & ExtentionName & ".ini"
        Dim ParamVal As String = Space$(1024)
        Dim LenParamVal As Long = GetPrivateProfileString(Section, ParamName, ParamDefault, ParamVal, Len(ParamVal), SettingFile)
        Return Left$(ParamVal, LenParamVal)
    End Function

    'Write INI Param Value to File and Return TRUE|FALSE if Value is saved
    Public Function SetValue(ByVal Section As String, ByVal ParamName As String, ByVal ParamValue As String) As Boolean Implements ISettings.SetValue
        Dim ExtentionName As String = Assembly.GetCallingAssembly().GetName().Name.ToString()
        Dim SettingFile As String = "Data\Settings\" & ExtentionName & ".ini"
        Return WritePrivateProfileString(Section, ParamName, ParamValue, SettingFile)
    End Function

End Class

<Export(GetType(ILogging))>
Public Class Logging
    Implements ILogging
    '
    ' Functions for Extentions to Write Logs
    '
    Public Function Write(ByVal Message As String, Optional ByVal Append As Boolean = False) As Boolean Implements ILogging.Write
        Dim ExtentionName As String = Assembly.GetCallingAssembly().GetName().Name.ToString()
        Dim LogFile As String = "Data\Logs\" & ExtentionName & ".log"
        Try
            If Append Then
                File.AppendAllText(LogFile, Message & vbCrLf, UTF8)
            Else
                File.WriteAllText(LogFile, Message, UTF8)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function ShowMessage(ByVal Message As String, Optional ByVal Icon As MessageBoxIcon = MessageBoxIcon.None, Optional ByVal Buttons As MessageBoxButtons = MessageBoxButtons.OK) Implements ILogging.ShowMessage
        Return MessageBox.Show(Message, Assembly.GetCallingAssembly().GetName().Name.ToString(), Buttons, Icon)
    End Function

End Class

<Export(GetType(IStorage))>
Public Class Storage
    Implements IStorage
    '
    ' Functions for Extentions to Store Data
    '

    Private Function __StoragePath(ByVal __callingAssembly As String) As String
        Return "Data\Storage\" & __callingAssembly
    End Function
    Private Function __HasStorage(ByVal __callingAssembly As String) As Boolean
        If Directory.Exists(__StoragePath(__callingAssembly)) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function StoragePath() As String Implements IStorage.StoragePath
        Return "Data\Storage\" & Assembly.GetCallingAssembly().GetName().Name.ToString()
    End Function

    Public Function HasStorage() As Boolean Implements IStorage.HasStorage
        If Directory.Exists(__StoragePath(Assembly.GetCallingAssembly().GetName().Name.ToString())) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function CreateStorage() As Boolean Implements IStorage.CreateStorage
        Dim __callingAssembly As String = Assembly.GetCallingAssembly().GetName().Name.ToString()
        Try
            If Not __HasStorage(__callingAssembly) Then
                Directory.CreateDirectory(__StoragePath(__callingAssembly))
            End If
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function DestroyStorage() As Boolean Implements IStorage.DestroyStorage
        Dim __callingAssembly As String = Assembly.GetCallingAssembly().GetName().Name.ToString()
        Try
            If __HasStorage(__callingAssembly) Then
                Directory.Delete(__StoragePath(__callingAssembly), True)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function ReadText(ByVal Path As String) As String Implements IStorage.ReadText
        Dim __callingAssembly As String = Assembly.GetCallingAssembly().GetName().Name.ToString()
        Return File.ReadAllText(__StoragePath(__callingAssembly) & "\" & Path.TrimStart("\"))
    End Function

    Public Function GetFiles(ByVal Path As String) As String() Implements IStorage.GetFiles
        Dim __callingAssembly As String = Assembly.GetCallingAssembly().GetName().Name.ToString()
        Dim basePath As String = __StoragePath(__callingAssembly) & "\"
        Dim Files As String() = Directory.GetFiles(basePath & Path.TrimStart("\"))
        Dim i As Integer = 0
        For Each file As String In Files
            Files(i) = file.Replace(basePath, "")
            i += 1
        Next
        Return Files
    End Function

    Public Function GetDirectories(ByVal Path As String) As String() Implements IStorage.GetDirectories
        Dim __callingAssembly As String = Assembly.GetCallingAssembly().GetName().Name.ToString()
        Dim basePath As String = __StoragePath(__callingAssembly) & "\"
        Dim Directories As String() = Directory.GetDirectories(basePath & Path.TrimStart("\"))
        Dim i As Integer = 0
        For Each file As String In Directories
            Directories(i) = file.Replace(basePath, "")
            i += 1
        Next
        Return Directories
    End Function

End Class