Imports System.Globalization



Public Class BooleanManager


#Region "TryParse/Parse functions"

    Public Shared Function Parse(ByVal str As String) As Boolean
        Select Case str.ToUpper
            Case "TRUE", "YES", "Y", "1"
                Return True
            Case "FALSE", "NO", "N", "0"
                Return False
            Case Else
                Throw New Exception(String.Format("'{0}' is not a valid boolean", str))
        End Select
    End Function

    Public Shared Function TryParse(ByVal str As String, Optional ByRef outValue As Boolean = False) As Boolean
        Select Case str.ToUpper
            Case "TRUE", "YES", "Y", "1"
                outValue = True
            Case "FALSE", "NO", "N", "0"
                outValue = False
            Case Else
                Return False
        End Select
        Return True
    End Function

#End Region


#Region "ToString function"

    Public Shared Shadows Function ToString(ByVal b As Boolean) As String
        Return b.ToString(CultureInfo.InvariantCulture)
    End Function

#End Region


End Class
