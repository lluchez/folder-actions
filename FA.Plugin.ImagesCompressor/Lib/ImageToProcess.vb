Imports FA.Library



Public Class ImageToProcess


#Region "Enum States"

    Public Enum States
        NotDone
        Success
        Failed
    End Enum

#End Region


#Region "Properties"

    Protected _srcFile As FileInfoX
    Public Property SourceFile() As FileInfoX
        Get
            Return _srcFile
        End Get
        Set(ByVal value As FileInfoX)
            _srcFile = value
        End Set
    End Property

    Protected _dstFile As FileInfoX
    Public Property DestinationFile() As FileInfoX
        Get
            Return _dstFile
        End Get
        Set(ByVal value As FileInfoX)
            _dstFile = value
        End Set
    End Property

    Public WriteOnly Property DestinationFileBase() As String
        Set(ByVal value As String)
            Me.DestinationFile = _srcFile.Directory.File(value)
        End Set
    End Property

    Protected _state As States
    Public ReadOnly Property State() As States
        Get
            Return _state
        End Get
    End Property

    Public ReadOnly Property Processeed() As Boolean
        Get
            Return _state = States.Success
        End Get
    End Property

    Protected _errMsg As String
    Public Property ErrorMessage() As String
        Get
            Return _errMsg
        End Get
        Set(ByVal value As String)
            _errMsg = value
        End Set
    End Property

#End Region


#Region "Constructor"

    Public Sub New(src As FileInfoX)
        Me.New(src, New FileInfoX())
    End Sub

    Public Sub New(src As FileInfoX, dest As FileInfoX)
        _srcFile = src
        _dstFile = dest
        _state = States.NotDone
        _errMsg = ""
    End Sub

#End Region


#Region "Public Functions"

    Public Sub MarkAsFailed(msg As String)
        _errMsg = msg
        _state = States.Failed
    End Sub

    Public Sub MarkAsNotDone()
        _errMsg = ""
        _state = States.NotDone
    End Sub

    Public Sub MarkAsDone()
        _state = States.Success
    End Sub

    Public Sub Refresh()
        _srcFile.Refresh()
        _dstFile.Refresh()
    End Sub

#End Region


End Class



Public Class ImagesToProcess
    Inherits List(Of ImageToProcess)

    Public ReadOnly Property IsProcessCompleted() As Boolean
        Get
            For Each fi As ImageToProcess In Me
                If Not fi.Processeed Then Return False
            Next
            Return True
        End Get
    End Property

    Public Function GetImagesToCompress(extension As String, renameMask As String, mask As String, maskParser As MaskCounterParser, counter As Integer, moveTo As DirectoryInfoX) As List(Of ImageToProcess)
        Dim images As New List(Of ImageToProcess)
        For Each fi As ImageToProcess In Me
            If Not fi.Processeed Then
                Dim di As DirectoryInfoX = fi.SourceFile.Directory
                Dim filename As String = fi.SourceFile.Name
                If moveTo.Exists Then di = moveTo
                If Not String.IsNullOrEmpty(renameMask) Then filename = maskParser.Replace(renameMask, mask, counter)
                fi.DestinationFile = New FileInfoX(di, filename)
                fi.DestinationFile.Extension = extension
                images.Add(fi)
            End If
            counter += 1
        Next
        Return images
    End Function

    Public ReadOnly Property ItemsNotDone() As IEnumerable(Of ImageToProcess)
        Get
            Dim images As New List(Of ImageToProcess)
            For Each fi As ImageToProcess In Me
                If Not fi.Processeed Then images.Add(fi)
            Next
            Return images
        End Get
    End Property

End Class