Imports System.Windows.Forms

Public Class DlgPathSelector


#Region "Properties"

    Private _files As New List(Of FileInfoX)
    Public ReadOnly Property Files() As List(Of FileInfoX)
        Get
            Return _files
        End Get
    End Property

    Private _di As DirectoryInfoX = New EmptyDirectoryInfoX()
    Public ReadOnly Property DirectoryInfo() As DirectoryInfoX
        Get
            Return _di
        End Get
    End Property

#End Region


#Region "Component Properties"

    Public Property Recursive() As Boolean
        Get
            Return Me.ChkRecursiveScan.Checked
        End Get
        Set(value As Boolean)
            Me.ChkRecursiveScan.Checked = value
        End Set
    End Property

    Public Property IncludeHiddenFiles() As Boolean
        Get
            Return Me.ChkViewHiddenFiles.Checked
        End Get
        Set(value As Boolean)
            Me.ChkViewHiddenFiles.Checked = value
        End Set
    End Property

#End Region


#Region "Events"

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If Me.GetFiles() Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ChkUseMask_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkUseMask.CheckedChanged
        Me.TxtMask.Enabled = Me.ChkUseMask.Checked
    End Sub

    Private Sub DlgPathSelector_TextChanged(sender As Object, e As System.EventArgs) Handles PathSelector.TextChanged
        _di = PathSelector.DirectoryInfo
        Me.BtnOk.Enabled = _di.IsValid
    End Sub

    Private Sub DlgPathSelector_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Dim clbTxt As String = Clipboard.GetText()
        If GlobalData.FileSystem.IsValidPathName(clbTxt) Then Me.PathSelector.Path = clbTxt
    End Sub

#End Region


#Region "Private functions"

    Private Function GetFiles() As Boolean
        If Not _di.Exists() Then
            If MsgBox.AlertYesNo("This folder doesn't exist. Would you like to create it?") = Windows.Forms.DialogResult.Yes Then
                Try
                    _di = New DirectoryInfoX(IO.Directory.CreateDirectory(_di.FullName))
                Catch ex As Exception
                    MsgBox.Alert("Can't create the folder: " & ex.Message)
                    Return False
                End Try
            Else
                Return False
            End If
        End If
        Dim mask As String = "*"
        If Me.ChkUseMask.Checked Then mask = Me.TxtMask.Text
        Try
            _files = _di.GetFiles(Me.ChkRecursiveScan.Checked, mask, Me.ChkViewHiddenFiles.Checked)
            Return True
        Catch ex As System.ArgumentException
            MsgBox.Alert("Invalid mask: " & ex.Message)
        Catch ex As System.Security.SecurityException
            MsgBox.Alert("Security error: " & ex.Message)
        Catch ex As Exception
            MsgBox.Alert("Can't list the files: " & ex.Message)
        End Try
        Return False
    End Function

#End Region


End Class
