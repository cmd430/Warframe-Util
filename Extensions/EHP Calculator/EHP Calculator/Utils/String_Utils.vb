Imports System.Runtime.CompilerServices

Namespace Utils
    Module String_Utils

        '
        '   Functions to Manipulate Strings
        '
        Public Function ToTitleCase(ByVal str As String) As String
            Dim res As String = ""
            For Each word In str.Split(" ")
                res = res & word.Substring(0, 1).ToUpper() & word.ToLower().Remove(0, 1) & " "
            Next
            Return res.Trim()
        End Function

    End Module
End Namespace