Public Class DirectoryInfoX
    Inherits FileSystemInfoX(Of IO.DirectoryInfo)


#Region "Properties"

    Public Overrides ReadOnly Property IsDirectory As Boolean
        Get
            Return True
        End Get
    End Property

#End Region


#Region "Constructors"

    Public Sub New(ByVal folderName As String, Optional ByVal safe As Boolean = True)
        MyBase.New(folderName, safe)
    End Sub

    Public Sub New(ByVal di As IO.DirectoryInfo)
        MyBase.New(di)
    End Sub

    Public Sub New()
        MyBase.New()
    End Sub

#End Region


#Region "Public Functions"

    Protected Overrides Function CreateFsiObject(ByVal path As String) As IO.DirectoryInfo
        Return New IO.DirectoryInfo(path)
    End Function

    Public Function BrowseUp(ByVal levels As Integer) As DirectoryInfoX
        Dim di As IO.DirectoryInfo = _fsi
        While levels > 0
            If di.Parent Is Nothing Then Return Nothing
            di = di.Parent
            levels -= 1
        End While
        Return New DirectoryInfoX(di)
    End Function

    Public Function GetFiles(Optional recursive As Boolean = False, Optional ByVal pattern As String = "*", Optional includeHidden As Boolean = True) As List(Of FileInfoX)
        Dim list As New List(Of FileInfoX)
        If recursive Then
            For Each di As DirectoryInfoX In Me.GetDirectories()
                If includeHidden OrElse di.Visible Then
                    list.AddRange(di.GetFiles(recursive, pattern, includeHidden))
                End If
            Next
        End If
        For Each fi As FileInfoX In CastFileList(_fsi.GetFiles(pattern))
            If includeHidden OrElse fi.Visible Then
                list.Add(fi)
            End If
        Next
        Return list
    End Function

    Public Function GetDirectories(Optional ByVal pattern As String = "*") As List(Of DirectoryInfoX)
        Return CastDirectoryList(_fsi.GetDirectories(pattern))
    End Function

    Public Function File(basefilename As String) As FileInfoX
        Return New FileInfoX(IO.Path.Combine(Me.FullName, basefilename))
    End Function

#End Region


End Class


Public Class EmptyDirectoryInfoX
    Inherits DirectoryInfoX

    Public Sub New()
        MyBase.New()
    End Sub

End Class