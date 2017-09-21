Public Class SyncFIFO(Of T)

    Protected  _list As List(Of T)


#Region "Constructor"

    Public Sub New()
        _list = New List(Of T)
    End Sub

    Public Sub New(ByVal collection As ICollection(Of T))
        Me.New()
        Me.Push(collection)
    End Sub

#End Region


#Region "Public Functions"

    Public Sub Push(ByVal collection As ICollection(Of T))
        SyncLock _list
            For Each t As T In collection
                Me.Push_(t)
            Next
        End SyncLock
    End Sub

    Public Sub Push(ByVal t As T)
        SyncLock _list
            Me.Push_(t)
        End SyncLock
    End Sub

    Private Sub Push_(ByVal t As T)
        SyncLock _list
            _list.Add(t)
        End SyncLock
    End Sub

    Public Function Pop() As T
        Dim t As T
        SyncLock _list
            t = Me.Remove()
        End SyncLock
        Return t
    End Function

    Public Function PopAll() As List(Of T)
        SyncLock _list
            Dim res As New List(Of T)
            While _list.Count > 0
                res.Add(Me.Remove())
            End While
            Return res
        End SyncLock
    End Function

    Public Function Count() As Integer
        SyncLock _list
            Return _list.Count
        End SyncLock
    End Function

    Public Sub Clear()
        SyncLock _list
            _list.Clear()
        End SyncLock
    End Sub

#End Region


#Region "Private Functions"

    Protected Function Remove() As T
        If _list.Count > 0 Then
            Dim t As T = _list(0)
            _list.RemoveAt(0)
            Return t
        Else
            Return Nothing
        End If
    End Function

#End Region


End Class
