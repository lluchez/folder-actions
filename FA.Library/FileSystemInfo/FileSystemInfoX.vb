Public MustInherit Class FileSystemInfoX(Of T As IO.FileSystemInfo)
    Implements IFileSystemInfoX


#Region "Members"

    Protected _fsi As T
    Protected _ex As Exception

#End Region


#Region "Properties"

    Public ReadOnly Property InnerObject() As IO.FileSystemInfo Implements IFileSystemInfoX.InnerObject
        Get
            Return _fsi
        End Get
    End Property

    Public ReadOnly Property IsValid() As Boolean Implements IFileSystemInfoX.IsValid
        Get
            Return _fsi IsNot Nothing
        End Get
    End Property

    Public Function IsSame(ByVal fsi As T) As Boolean
        Return Me.IsSame(fsi.FullName)
    End Function

    Public Function IsSame(ByVal fsi As FileSystemInfoX(Of T)) As Boolean
        Return Me.IsSame(fsi.FullName)
    End Function

    Public Function IsSame(ByVal fsiFullpath As String) As Boolean
        Dim regex As New Text.RegularExpressions.Regex("[\\/]+$") '** To remove the last / or \ if comparing DirectoryInfo objects
        Return regex.Replace(_fsi.FullName.ToLower, "") = regex.Replace(fsiFullpath.ToLower, "")
    End Function

    Public MustOverride ReadOnly Property IsDirectory() As Boolean Implements IFileSystemInfoX.IsDirectory

#End Region


#Region "Properties - Accessors"

    Public ReadOnly Property Name() As String Implements IFileSystemInfoX.Name
        Get
            If Me.IsValid() Then Return _fsi.Name
            Return ""
        End Get
    End Property

    Public ReadOnly Property BaseName() As String
        Get
            If Not Me.IsValid() Then Return ""
            If _fsi.Extension.Length = 0 Then Return _fsi.Name
            Return _fsi.Name.Substring(0, _fsi.Name.Length - _fsi.Extension.Length)
        End Get
    End Property

    Public ReadOnly Property FullName() As String Implements IFileSystemInfoX.FullName
        Get
            If Me.IsValid() Then Return _fsi.FullName
            Return ""
        End Get
    End Property

    Public ReadOnly Property Exists() As Boolean Implements IFileSystemInfoX.Exists
        Get
            If Me.IsValid() Then Return _fsi.Exists
            Return False
        End Get
    End Property

    Public ReadOnly Property LastWriteTime() As DateTime Implements IFileSystemInfoX.LastWriteTime
        Get
            If Me.IsValid() Then Return _fsi.LastWriteTime
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property LastWriteTimeFormatted() As String Implements IFileSystemInfoX.LastWriteTimeFormatted
        Get
            If Me.IsValid() Then Return DateTimeManager.ToString(_fsi.LastWriteTime, "yyyy-MM-dd HH:mm")
            Return ""
        End Get
    End Property

    Public ReadOnly Property Visible() As Boolean
        Get
            Return (Not _fsi.Attributes.HasFlag(IO.FileAttributes.Hidden))
        End Get
    End Property

#End Region


#Region "Constructors"

    Public Sub New(ByVal folderName As String, ByVal safe As Boolean)
        Try
            _fsi = Me.CreateFsiObject(folderName)
        Catch ex As Exception
            If Not safe Then Throw ex
            _ex = ex
        End Try
    End Sub

    Public Sub New(ByVal fsi As T)
        _fsi = fsi
        _ex = Nothing
    End Sub

    Public Sub New()
        _fsi = Nothing
        _ex = New Exception("No file selected")
    End Sub

    Public Sub Update(fsi As T)
        _fsi = fsi
        _ex = Nothing
    End Sub

#End Region


#Region "Cast Functions"

    Public Shared Function CastFileList(ByVal files As IEnumerable(Of IO.FileInfo)) As List(Of FileInfoX)
        Dim list As New List(Of FileInfoX)
        For Each fi As IO.FileInfo In files
            list.Add(New FileInfoX(fi))
        Next
        Return list
    End Function

    Public Shared Function CastDirectoryList(ByVal dirs As IEnumerable(Of IO.DirectoryInfo)) As List(Of DirectoryInfoX)
        Dim list As New List(Of DirectoryInfoX)
        For Each fi As IO.DirectoryInfo In dirs
            list.Add(New DirectoryInfoX(fi))
        Next
        Return list
    End Function

#End Region


#Region "Other Functions"

    Protected MustOverride Function CreateFsiObject(ByVal path As String) As T

    Public Sub Refresh() Implements IFileSystemInfoX.Refresh
        _fsi.Refresh()
    End Sub

#End Region


End Class



Public Class FileSystemInfoX

    Public Shared Function [Get](ByVal path As String, Optional ByVal canBeDirectory As Boolean = True) As IFileSystemInfoX
        Dim iFileSystem As IFileSystemInfoX
        If canBeDirectory Then
            iFileSystem = New DirectoryInfoX(path)
            If iFileSystem.Exists Then Return iFileSystem
        End If
        Return New FileInfoX(path)
    End Function

    Public Shared Function DirectoryExists(ByVal path As String) As Boolean
        Dim di As New DirectoryInfoX(path)
        Return di.Exists
    End Function

    Public Shared Function FileExists(ByVal path As String) As Boolean
        Dim fi As New FileInfoX(path)
        Return fi.Exists
    End Function

End Class