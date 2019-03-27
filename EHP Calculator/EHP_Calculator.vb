Imports System.ComponentModel.Composition
Imports System.Windows.Forms
Imports Warframe_Util

<Export(GetType(IMethods))>
<ExportMetadata("Name", "EHP Calculator")>
<ExportMetadata("Description", "EHP Calculator for Warframes and Compainions")>
<ExportMetadata("Author", "Bradley 'cmd430' Treweek")>
<ExportMetadata("Version", "0.0.1")>
Public Class EHP_Calculator
    Implements IMethods

    Public Function Init(host As TabPage) As TabPage Implements IMethods.Init
        host.Controls.Add(New PluginGUI With {
            .Dock = DockStyle.Fill
        })
        Return host
    End Function

End Class


'
' TODO have generic functions for adding base/regular hp etc that can then be called by mods 
' TODO make the EHP calculation use the result from thos functions in the correct order
' TODO make mods / warframes etc be seperate plugins