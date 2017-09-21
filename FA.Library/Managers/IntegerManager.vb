Imports System.Globalization



Public Class IntegerManager


#Region "TryParse/Parse functions"

    Public Shared Function TryParse(ByVal str As String, Optional ByRef tmpInt As Integer = 0) As Boolean
        Return Integer.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, tmpInt)
    End Function

    Public Shared Function Parse(ByVal str As String) As Integer
        Return Integer.Parse(str, NumberStyles.Any, CultureInfo.InvariantCulture)
    End Function

#End Region


#Region "ToString function"

    Public Shared Shadows Function ToString(ByVal b As Integer) As String
        Return b.ToString(CultureInfo.InvariantCulture)
    End Function

#End Region


#Region "Base functions"

    'Public Shared Function Base10ToBase16(ByVal decValue As Integer) As String
    '    Return decValue.ToString("X")
    'End Function
    'Public Shared Function Base16ToBase10(ByVal hexValue As String) As Integer
    '    Return Integer.Parse(hexValue, System.Globalization.NumberStyles.HexNumber)
    'End Function

    'Public Shared Function Base10ToBase36(ByVal decValue As Integer) As String
    '    Return Base36.Encode(Convert.ToInt64(decValue))
    'End Function
    'Public Shared Function Base36ToBase10(ByVal b36Value As String) As Integer
    '    Return Convert.ToInt32(Base36.Decode(b36Value))
    'End Function

    'Private Class Base36

    '    Private Const Chars As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ"

    '    Public Shared Function Encode(ByVal arg As Long) As String
    '        Dim charArray As Char() = Chars.ToCharArray()
    '        Dim result As Stack(Of Char) = New Stack(Of Char)()
    '        While arg <> 0
    '            result.Push(charArray(CInt(arg Mod 36)))
    '            arg \= 36
    '        End While
    '        Return New String(result.ToArray())
    '    End Function

    '    Public Shared Function Decode(ByVal arg As String) As Long
    '        Dim rev As String = StrReverse(arg.ToUpper())
    '        Dim result As Long = 0
    '        Dim pos As Integer = 0
    '        For Each c As Char In rev
    '            result += Chars.IndexOf(c) * CLng(Math.Pow(36, pos))
    '            pos += 1
    '        Next
    '        Return result
    '    End Function

    'End Class

#End Region


End Class
