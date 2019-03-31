
Public Class Utilities

    Public Shared Function ToTitleCase(ByVal str As String) As String
        Return str.Substring(0, 1).ToUpper() & str.ToLower().Remove(0, 1)
    End Function

End Class
