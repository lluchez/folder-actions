Imports System.Text.RegularExpressions




Public Class StringManager


#Region "Functions IEnumerable(Of String)"

    Public Shared Function Join(ByVal str As IEnumerable(Of String), Optional ByVal separator As String = ",", Optional ByVal defEmptyString As String = "") As String
        Dim parts As New List(Of String)
        For Each s As String In str
            If Not String.IsNullOrEmpty(s) Then
                parts.Add(s)
            End If
        Next
        If parts.Count = 0 Then
            Return defEmptyString
        Else
            Return Join(parts.ToArray(), separator)
        End If
    End Function

#End Region


#Region "Web StringBuilder"

    Private Shared VbTabChar As Char = vbTab.Chars(0)

    Public Shared Sub StringBuilderAppend(ByVal sb As Text.StringBuilder, ByVal text As String, Optional ByVal nbVbTab As Integer = 0)
        sb.Append("".PadLeft(nbVbTab, VbTabChar) & text & vbNewLine)
    End Sub

    Public Shared Sub StringBuilderAppend(ByVal sb As Text.StringBuilder, ByVal text As String, ByVal nbVbTab As Integer, ByVal o1 As Object, Optional ByVal o2 As Object = Nothing, Optional ByVal o3 As Object = Nothing, Optional ByVal o4 As Object = Nothing, Optional ByVal o5 As Object = Nothing, Optional ByVal o6 As Object = Nothing)
        sb.AppendFormat("".PadLeft(nbVbTab, VbTabChar) & text & vbNewLine, o1, o2, o3, o4, o5, o6)
    End Sub

    Public Shared Sub StringBuilderAppend(ByVal sb As Text.StringBuilder, ByVal text As String, ByVal nbVbTab As Integer, ByVal o() As Object)
        sb.AppendFormat("".PadLeft(nbVbTab, VbTabChar) & text & vbNewLine, o)
    End Sub

#End Region


#Region "NameSpace Comparison"

    Public Class Comparison

        Public Shared Function IsEmpty(ByVal val As String) As Boolean
            Return (val Is Nothing) OrElse (val.Trim().Length = 0)
        End Function

        Public Shared Function Match(ByVal ereg As Regex, ByVal text As String) As List(Of String)
            Dim matches As New List(Of String)
            Dim m As Match = ereg.Match(text)
            For Each g As Group In m.Groups
                matches.Add(g.Value)
            Next
            Return matches
        End Function

        Public Shared Function Match(ByVal ereg As Regex, ByVal text As String, ByVal index As Integer, Optional ByVal defVal As String = Nothing) As String
            Dim m As Match = ereg.Match(text)
            If Not m.Success OrElse index < 0 OrElse index >= m.Groups.Count Then
                Return defVal
            End If
            Return m.Groups(index).Value
        End Function

    End Class

#End Region


#Region "NameSpace Conversion"

    Public Class Conversion

        Public Shared SizeUnits() As String = New String() {"bytes", "Kb", "Mb", "Gb", "Tb"}
        Public Shared Function SizeToString(ByVal size As Double) As String
            Dim iUnit As Integer = 0
            While size >= 1024 And iUnit < SizeUnits.Length
                size /= 1024
                iUnit += 1
            End While
            Return String.Format("{0:0.0}", size) & " " & SizeUnits(iUnit)
        End Function

        Private Shared _regexTrim As New Regex("^\s+|\s+$") '** Also matches new line chars
        Public Shared Function Trim(ByVal text As String) As String
            Return _regexTrim.Replace(text, "")
        End Function


        Public Class Sql

            Public Shared Function OptimizeClauseIN(ByVal values As String, ByVal fieldName As String, Optional ByVal returnNothing As Boolean = False, Optional ByVal escapeValues As Boolean = True) As String
                Return OptimizeClauseIN(values.Replace(";"c, ","c).Split(","c), fieldName, returnNothing, escapeValues)
            End Function

            Public Shared Function OptimizeClauseIN(ByVal values As IEnumerable, ByVal fieldName As String, Optional ByVal returnNothing As Boolean = False, Optional ByVal escapeValues As Boolean = True) As String
                Dim parts As New List(Of String)
                For Each obj As Object In values
                    Dim part As String = obj.ToString.Trim()
                    If part.Length > 0 Then
                        parts.Add(String.Format("[{0}]='{1}'", fieldName, CStr(IIf(escapeValues, part.Replace("'", "''"), part))))
                    End If
                Next
                If parts.Count = 0 Then
                    If returnNothing Then
                        Return Nothing
                    Else
                        Return "1=1"
                    End If
                Else
                    Return "(" & Join(parts.ToArray(), " OR ") & ")"
                End If
            End Function

        End Class


    End Class

#End Region


#Region "SimplePlurial / Plurial"

    Public Shared Function SimplePlurial(ByVal value As Integer, Optional ByVal plurialForm As String = "s", Optional ByVal singularForm As String = "") As String
        Return CStr(IIf(value > 1, plurialForm, singularForm))
    End Function

    Public Shared Function Plurial(ByVal value As Integer, Optional ByVal pattern As String = "{0} item{1}", Optional ByVal plurialForm As String = "s", Optional ByVal singularForm As String = "") As String
        Return String.Format(pattern, CStr(value), IIf(value > 1, plurialForm, singularForm))
    End Function

#End Region


#Region "Namespace Ereg(Regex)"

    Public Class Ereg

        Private Shared _regexHasOptions As New Regex("[\\/#][i]+$")
        Public Shared Function IsValidRegex(ByVal txt As String, Optional ByRef regexOUT As Regex = Nothing, Optional ByRef exOUT As Exception = Nothing) As Boolean
            Dim eregOptions As RegexOptions = RegexOptions.None
            Dim m As Match = _regexHasOptions.Match(txt)
            If m.Success Then
                Dim offset As Integer = m.Groups(0).Index ' txt.LastIndexOf("/"c)
                For i As Integer = txt.Length - 1 To offset + 1 Step -1
                    Select Case txt.Chars(i)
                        Case "i"c : eregOptions = eregOptions Or RegexOptions.IgnoreCase
                            'Case "g"c : eregOptions = eregOptions Or RegexOptions.
                    End Select
                Next
                txt = txt.Substring(0, offset)
            End If
            If txt.Length = 0 Then
                exOUT = New Exception("Empty mask")
                Return False
            End If
            Try
                regexOUT = New Regex(txt, eregOptions)
                Return True
            Catch ex As Exception
                exOUT = ex
                Return False
            End Try
        End Function

        Public Shared Function Match(ereg As Regex, txt As String, grpIdx As Integer, Optional defValue As String = "") As String
            Dim m As Match = ereg.Match(txt)
            If Not m.Success Then Return defValue
            If grpIdx < 0 Or grpIdx >= m.Groups.Count Then Return defValue
            Return m.Groups(grpIdx).Value
        End Function

    End Class

#End Region


End Class

