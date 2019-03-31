Imports MEFContracts.Interfaces
Imports System.ComponentModel.Composition
Imports System.Windows.Forms

<Export(GetType(IMethods))>
<ExportMetadata("Name", "EHP Calculator")>
<ExportMetadata("Description", "EHP Calculator for Warframes and Compainions")>
<ExportMetadata("Author", "Bradley 'cmd430' Treweek")>
<ExportMetadata("Version", "0.0.1")>
Public Class EHP_Calculator
    Implements IMethods

    <Import(GetType(ISettings))>
    Public Settings As ISettings


    Public Function Init(Container As TabPage) As TabPage Implements IMethods.Init
        With Settings


            '    MsgBox("Setting Value: " & .GetValue("TESTS", "test_parm").ToString())
            '    MsgBox("Setting Updated: " & .SetValue("TESTS", "test_parm", TimeString).ToString())
            '    MsgBox("Setting Value: " & .GetValue("TESTS", "test_parm").ToString())

            Container.Controls.Add(New GUI With {
                .Dock = DockStyle.Fill
            })

            Return Container
        End With
    End Function

End Class

'
' TODO have generic functions for adding base/regular hp etc that can then be called by mods 
' TODO make the EHP calculation use the result from thos functions in the correct order
' TODO make mods / warframes etc be seperate plugins