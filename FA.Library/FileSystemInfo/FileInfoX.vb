Public Class FileInfoX
    Inherits FileSystemInfoX(Of IO.FileInfo)


#Region "Overrides Properties"

    Public Overrides ReadOnly Property IsDirectory As Boolean
        Get
            Return False
        End Get
    End Property

#End Region


#Region "Properties - Accessors"

    Public ReadOnly Property NameWithoutExtension() As String
        Get
            Return Me.FullName.Substring(0, Me.FullName.Length - Me.Extension.Length)
        End Get
    End Property

    Public Property Extension() As String
        Get
            Return _fsi.Extension.ToLower
        End Get
        Set(newExt As String)
            Dim newFileName As String
            Dim fileWithoutExt As String = Me.NameWithoutExtension()
            If String.IsNullOrEmpty(newExt) Then
                newFileName = fileWithoutExt
            Else
                If newExt.Chars(0) <> "."c Then newExt = "." & newExt
                newFileName = fileWithoutExt & newExt.ToLower
            End If
            _fsi = New IO.FileInfo(newFileName)
        End Set
    End Property

    Public ReadOnly Property ExtensionWithoutDot() As String
        Get
            If String.IsNullOrEmpty(_fsi.Extension) Then Return ""
            Return _fsi.Extension.Substring(1).ToLower
        End Get
    End Property

    Public ReadOnly Property DirectoryName() As String
        Get
            If _fsi Is Nothing Then Return ""
            Return _fsi.DirectoryName
        End Get
    End Property

    Public ReadOnly Property Directory() As DirectoryInfoX
        Get
            If _fsi Is Nothing Then Return Nothing
            Return New DirectoryInfoX(_fsi.Directory)
        End Get
    End Property

    Public ReadOnly Property Length() As Long
        Get
            If (Not Me.Exists) Then Return 0
            Return _fsi.Length
        End Get
    End Property

    Public ReadOnly Property LengthFormatted() As String
        Get
            Return StringManager.Conversion.SizeToString(Me.Length)
        End Get
    End Property

#End Region


#Region "Constructors"

    Public Sub New(ByVal di As DirectoryInfoX, fileName As String, Optional ByVal safe As Boolean = True)
        MyBase.New(IO.Path.Combine(di.FullName, fileName), safe)
    End Sub

    Public Sub New(ByVal fileName As String, Optional ByVal safe As Boolean = True)
        MyBase.New(fileName, safe)
    End Sub

    Public Sub New(ByVal fi As IO.FileInfo)
        MyBase.New(fi)
    End Sub

    Public Sub New()
        MyBase.New()
    End Sub

#End Region


#Region "Functions"

    Protected Overrides Function CreateFsiObject(ByVal path As String) As IO.FileInfo
        Return New IO.FileInfo(path)
    End Function

    Public Sub Delete(Optional fullName As Boolean = False)
        Try
            _fsi.Delete()
        Catch ex As Exception
            Throw New Exception(String.Format("Can't delete the file '{0}'", IIf(fullName, _fsi.FullName, _fsi.Name)))
        End Try
    End Sub

#End Region


End Class


Public Class EmptyFileInfoX
    Inherits FileInfoX

    Public Sub New()
        MyBase.New()
    End Sub

End Class