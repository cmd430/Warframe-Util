Imports MEFContracts.Interfaces
Imports System.ComponentModel.Composition
Imports System.Windows.Forms

<Export(GetType(IMethods))>
<ExportMetadata("Name", "Relic Reward Info")>
<ExportMetadata("Description", "Get Information on the Rewards on the Relic Reward Screen")>
<ExportMetadata("Author", "Bradley 'cmd430' Treweek")>
<ExportMetadata("Version", "0.0.1")>
Public Class Relic_Reward_Info
    Implements IMethods

    <Import(GetType(ISettings))>
    Public Shared Settings As ISettings

    Public Function Init() As Object Implements IMethods.Init
        Return New GUI With {
            .Dock = DockStyle.Fill
        }
    End Function

End Class
