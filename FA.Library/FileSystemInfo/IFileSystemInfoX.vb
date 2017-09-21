Public Interface IFileSystemInfoX
    ReadOnly Property InnerObject() As IO.FileSystemInfo
    ReadOnly Property IsValid() As Boolean
    ReadOnly Property Name() As String
    ReadOnly Property FullName() As String
    ReadOnly Property Exists() As Boolean
    ReadOnly Property IsDirectory() As Boolean
    ReadOnly Property LastWriteTime() As DateTime
    ReadOnly Property LastWriteTimeFormatted() As String
    Sub Refresh()
End Interface
