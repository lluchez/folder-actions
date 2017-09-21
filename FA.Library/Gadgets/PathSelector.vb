Public Class PathSelector


#Region "Properties and Events"

    Public Event PathChanged(sender As Object, e As System.EventArgs)
    Public Event PathSelected(sender As Object, e As System.EventArgs)

    Public Property Path() As String
        Get
            Return Me.TxtPath.Text.Trim
        End Get
        Set(value As String)
            Me.TxtPath.Text = value.Trim
        End Set
    End Property

    Private _di As DirectoryInfoX = New EmptyDirectoryInfoX()
    Public ReadOnly Property DirectoryInfo() As DirectoryInfoX
        Get
            Return _di
            If String.IsNullOrWhiteSpace(Me.Path) Then Return New EmptyDirectoryInfoX()
            Return New DirectoryInfoX(Me.Path.Trim, True)
        End Get
    End Property

#End Region


#Region "Events"

    Private Sub BtnBrowse_Click(sender As System.Object, e As System.EventArgs) Handles BtnBrowse.Click
        Dim di As DirectoryInfoX = GlobalData.FileSystem.FolderRequester(Me.Path)
        If di.Exists Then
            Me.Path = di.FullName
            RaiseEvent PathSelected(Me, New System.EventArgs())
        End If
    End Sub

    Private Sub TxtPath_TextChanged(sender As Object, e As System.EventArgs) Handles TxtPath.TextChanged
        If String.IsNullOrWhiteSpace(Me.Path) OrElse Not GlobalData.FileSystem.IsValidPathName(Me.Path) Then
            _di = New EmptyDirectoryInfoX()
        Else
            _di = New DirectoryInfoX(Me.Path.Trim, True)
        End If
        RaiseEvent PathChanged(Me, New System.EventArgs())
    End Sub

#End Region


End Class
