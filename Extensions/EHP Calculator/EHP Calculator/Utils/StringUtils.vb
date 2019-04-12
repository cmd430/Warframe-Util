Imports System.Runtime.CompilerServices

Module StringUtils

    '
    '   Functions to Manipulate Strings
    '
    <DebuggerStepThrough()>
    <Extension()>
    Public Function ToTitleCase(ByVal str As String) As String
        Dim res As String = ""
        For Each word In str.Split(" ")
            res = res & word.Substring(0, 1).ToUpper() & word.ToLower().Remove(0, 1) & " "
        Next
        Return res.Trim()
    End Function

End Module