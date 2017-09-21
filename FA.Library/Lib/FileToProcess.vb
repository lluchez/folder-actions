Public Class FileToProcess


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
            _state = States.NotDone
            _errMsg = ""
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

    Public Sub New(file As FileInfoX)
        _srcFile = file
        _dstFile = New FileInfoX()
        _state = States.NotDone
        _errMsg = ""
    End Sub

#End Region


#Region "Public Functions"

    Public Sub MarkAsFailed(msg As String)
        _errMsg = msg
        _state = States.Failed
        _dstFile = New FileInfoX()
    End Sub

    Public Sub MarkAsNotDone()
        _errMsg = ""
        _state = States.NotDone
        _dstFile = New FileInfoX()
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


'** - - - - - - - - - - - -- - - - - - - - - - - - - - - - - -


Public Class FilesToProcess
    Inherits List(Of FileToProcess)


    Public ReadOnly Property IsProcessCompleted() As Boolean
        Get
            For Each fi As FileToProcess In Me
                If Not fi.Processeed Then Return False
            Next
            Return True
        End Get
    End Property


End Class
