Public Class Interfaces

    Public Interface IMethods
        Function Init() As Object
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

End Class
