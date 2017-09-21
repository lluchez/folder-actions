Imports System.Globalization




Public Class DateTimeManager


#Region "TryParse/Parse(Exact) functions"

    Public Shared Function Parse(ByVal prompt As String) As DateTime
        Return DateTime.Parse(prompt, CultureInfo.InvariantCulture, DateTimeStyles.None)
    End Function

    Public Shared Function TryParse(ByVal prompt As String, ByRef dtOUT As DateTime) As Boolean
        Return DateTime.TryParse(prompt, CultureInfo.InvariantCulture, DateTimeStyles.None, dtOUT)
    End Function

    Public Shared Function ParseExact(ByVal prompt As String, ByVal mask As String) As DateTime
        Return DateTime.ParseExact(prompt, mask, CultureInfo.InvariantCulture, DateTimeStyles.None)
    End Function

    Public Shared Function TryParseExact(ByVal prompt As String, ByVal mask As String, ByRef dtOUT As DateTime) As Boolean
        Return DateTime.TryParseExact(prompt, mask, CultureInfo.InvariantCulture, DateTimeStyles.None, dtOUT)
    End Function

#End Region


#Region "ToString function"

    Public Shared Shadows Function ToString(ByVal dt As DateTime, ByVal mask As String) As String
        Return dt.ToString(mask, CultureInfo.InvariantCulture)
    End Function

#End Region


End Class
