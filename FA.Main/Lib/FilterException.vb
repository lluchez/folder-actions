
Public Class FilterException
    Inherits Exception

    Public Sub New(ByVal msg As String, Optional ByVal ex As Exception = Nothing)
        MyBase.New(msg, ex)
    End Sub
End Class

