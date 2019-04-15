Imports System.Windows.Forms

Public Class Interfaces

    Public Interface IMethods
        Function Init(ByVal __container As TabPage) As Object
    End Interface

    Public Interface IMeta
        ReadOnly Property Name As String
        ReadOnly Property Description As String
        ReadOnly Property Author As String
        ReadOnly Property Version As String
    End Interface

    Public Interface ISettings
        Function GetValue(ByVal Section As String, ByVal ParamName As String, Optional ByVal ParamDefault As String = "") As String
        Function SetValue(ByVal Section As String, ByVal ParamName As String, ByVal ParamValue As String) As Boolean
    End Interface

    Public Interface ILogging
        Function Write(ByVal Message As String, Optional ByVal Append As Boolean = False) As Boolean
        Function ShowMessage(ByVal Message As String, Optional ByVal Icon As MessageBoxIcon = MessageBoxIcon.None, Optional ByVal Buttons As MessageBoxButtons = MessageBoxButtons.OK)
    End Interface

    Public Interface IStorage
        Function StoragePath() As String
        Function HasStorage() As Boolean
        Function CreateStorage() As Boolean
        Function DestroyStorage() As Boolean
        Function ReadText(ByVal Path As String) As String
        Function GetFiles(ByVal Path As String)
    End Interface

End Class
