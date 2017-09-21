Imports System.Globalization



Public Class DoubleManager


#Region "TryParse/Parse functions"

    Public Shared Function TryParse(ByVal str As String, Optional ByRef tmpDbl As Double = 0) As Boolean
        Return Double.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, tmpDbl)
    End Function

    Public Shared Function Parse(ByVal str As String) As Double
        Return Double.Parse(str, NumberStyles.Any, CultureInfo.InvariantCulture)
    End Function

#End Region


#Region "ToString function"

    Public Shared Shadows Function ToString(ByVal b As Double) As String
        Return b.ToString(CultureInfo.InvariantCulture)
    End Function

#End Region


End Class

