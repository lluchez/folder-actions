Imports System.Text.RegularExpressions



Public Class MaskCounterParser


#Region "Members"

    Protected ReadOnly _key As String
    Protected ReadOnly _ereg As Regex

#End Region


#Region "Constructor"

    Public Sub New(Optional ByVal key As String = "cpt")
        _key = key
        _ereg = New Regex("\{" & key & "(:(\d+))?\}")
    End Sub

#End Region


#Region "GetMask"

    Public Function GetMask(ByVal mask As String, ByVal nbFiles As Integer, Optional ByVal cptStartAt As Integer = 1, Optional ByVal cptStep As Integer = 1) As String
        Dim cptMask As String = "{0}"
        Dim m As Match = _ereg.Match(mask)
        If Not m.Success Then Return "{0}"
        Dim grpMask As String = m.Groups(2).Value, valMask As Integer = 0
        If grpMask.Length > 0 AndAlso IntegerManager.TryParse(grpMask, valMask) Then
            If valMask > 0 Then
                Return Me.GetMask(valMask)
            Else
                Return Me.GetMask(grpMask)
            End If
        Else
            Return Me.GetMask(IntegerManager.ToString(nbFiles * cptStep + cptStartAt).Length)
        End If
    End Function

    Public Function GetMask(ByVal nb As Integer) As String
        Return Me.GetMask("".PadLeft(nb, "0"c))
    End Function

    Public Function GetMask(ByVal str As String) As String
        Return String.Format("{{0:{0}}}", str)
    End Function

#End Region


#Region "Replace"

    Public Function Replace(ByVal input As String, ByVal replacement As String) As String
        Return _ereg.Replace(input, replacement)
    End Function

    Public Function Replace(ByVal input As String, mask As String, ByVal replacement As Integer) As String
        Return Me.Replace(input, String.Format(mask, replacement))
    End Function

#End Region


#Region "ContainsMask"

    Public Function ContainsMask(input As String) As Boolean
        Return _ereg.IsMatch(input)
    End Function

#End Region


End Class
