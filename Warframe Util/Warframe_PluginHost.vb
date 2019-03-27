Imports System.ComponentModel.Composition
Imports System.ComponentModel.Composition.Hosting

#Region "Interfaces"

Public Interface IMethods
    Function Init(ByVal host As TabPage) As TabPage
End Interface

Public Interface IMeta
    ReadOnly Property Name As String
    ReadOnly Property Description As String
    ReadOnly Property Author As String
    ReadOnly Property Version As String
End Interface

#End Region

Public Class Warframe_PluginHost

    Private __container As CompositionContainer

    <ImportMany()>
    Public Property Extensions As IEnumerable(Of Lazy(Of IMethods, IMeta))

    Public Sub New()
        InitializeComponent()

        Dim catalog As New AggregateCatalog
        catalog.Catalogs.Add(New AssemblyCatalog(GetType(Warframe_PluginHost).Assembly))
        catalog.Catalogs.Add(New DirectoryCatalog("Extensions"))

        __container = New CompositionContainer(catalog)

        Try
            __container.ComposeParts(Me)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Warframe_PluginHost_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            For Each i As Lazy(Of IMethods, IMeta) In Extensions
                If Not i.Metadata.Name = "" Then
                    Dim Plugin_TabPage = New TabPage With {
                        .Text = i.Metadata.Name.ToString()
                    }
                    TabControl_PluginHost.TabPages.Add(i.Value.Init(Plugin_TabPage))
                    Dim InfoItem As New ToolStripMenuItem(i.Metadata.Name.ToString())
                    AddHandler InfoItem.Click, Sub()
                                                   MessageBox.Show(
                                                   "Name: " & i.Metadata.Name.ToString() & vbCrLf &
                                                   "Version: " & i.Metadata.Version.ToString() & vbCrLf &
                                                   "Author: " & i.Metadata.Author.ToString() & vbCrLf &
                                                   "Description: " & i.Metadata.Description.ToString(),
                                                   "Extension Info")
                                               End Sub
                    ToolStripDrop_Info.DropDownItems.Add(InfoItem)
                End If
            Next
            If Extensions.Count > 0 Then
                Label_NoExtentionsLoaded.Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class