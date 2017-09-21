Imports System.Windows.Forms
Imports System.Drawing


Public Class FrmPluginAbstract


#Region "Members"

    Protected _di As DirectoryInfoX = Nothing
    Protected _fis As List(Of FileInfoX) = Nothing
    Protected _ext As String = Nothing

    Protected _launcher As IPluginLauncher = Nothing

    Protected _state As State = State.Initializing
    Protected _exeMode As Boolean = True

#End Region


#Region "Enums"

    Enum State
        Initializing
        Initialized
        Processing
        Done
    End Enum

#End Region


#Region "MustOverride"

    Protected Overridable ReadOnly Property PluginName() As String
        Get
            Return _launcher.Name
        End Get
    End Property

    Public Overridable ReadOnly Property PluginID() As String
        Get
            Return _launcher.ID
        End Get
    End Property

    Protected Overridable Sub FormReady()
    End Sub

    Protected Overridable Sub FormIsClosing()
    End Sub

    Protected Overridable Function CreateLauncher() As IPluginLauncher
        Return Nothing
    End Function

#End Region


#Region "Properties"

    Protected ReadOnly Property IsProperlyInitialized() As Boolean
        Get
            Return (_fis IsNot Nothing) AndAlso (_fis.Count > 0)
        End Get
    End Property

    'Private ReadOnly Property GeneralConfig() As ConfigGeneral
    '    Get
    '        Return New ConfigGeneral()
    '    End Get
    'End Property

#End Region


#Region "Init functions"

    Public Sub Init(ByVal launcher As IPluginLauncher, ByVal files As List(Of FileInfoX), ByVal exeMode As Boolean)
        _launcher = launcher
        _fis = files
        _exeMode = exeMode

        Me.ComputeDirectory()
        Me.ComputeExtension()
    End Sub

    Protected Sub Init(ByVal di As DirectoryInfoX, ByVal exeMode As Boolean)
        If Not di.Exists Then Return

        Dim config As New ConfigGeneral()
        _di = di
        _fis = _di.GetFiles(config.Recursive, , config.ViewHiddenFiles) '** <-- ADD HERE FOR RECURSIVE AND VIEW HIDDEN FILES
        _exeMode = exeMode

        Me.ComputeExtension()
    End Sub

    Protected Sub Init()
        Dim config As New ConfigGeneral()
        Dim dlg As New DlgPathSelector()
        dlg.Recursive = config.Recursive
        dlg.IncludeHiddenFiles = config.ViewHiddenFiles
        'Dim clbTxt As String = Clipboard.GetText()
        'If GlobalData.FileSystem.IsValidPathName(clbTxt) Then dlg.PathSelector.Path = clbTxt
        If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            _di = dlg.DirectoryInfo
            _fis = dlg.Files
            Me.ComputeExtension()
        End If
    End Sub

    Protected Sub Init(ByVal exeMode As Boolean)
        Dim args() As String = Environment.GetCommandLineArgs(), files As New List(Of FileInfoX)
        For i As Integer = 1 To args.Length - 1
            Dim fsi As IFileSystemInfoX = FileSystemInfoX.Get(args(i), i = 1)
            If fsi.Exists Then
                If fsi.IsDirectory Then
                    Me.Init(CType(fsi, DirectoryInfoX), exeMode)
                    Return
                Else
                    files.Add(CType(fsi, FileInfoX))
                End If
            End If
        Next
    End Sub

#End Region


#Region "Form Events"

    Private Sub Form_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            If Me.ConfirmClosingForm() = DialogResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If
        '** Form is closing...
        Me.FormIsClosing()
    End Sub

    Protected Overridable Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '** Init the launcher
        If _launcher Is Nothing Then _launcher = Me.CreateLauncher()
        If _launcher Is Nothing Then Return '** Developer trick: To be able to view the form

        '** Init
        Me.Text = String.Format("{0} - v{1}", Me.PluginName, GlobalData.Sys.GetApplicationVersion)
        Me.Icon = _launcher.Icon
        Me.MinimumSize = Me.Size
        MsgBox.AppName = Me.PluginName

        '** Load files to process
        If _exeMode Then Me.Init(_exeMode)
        If Not Me.IsProperlyInitialized() Then
            'Me.Init(GlobalData.FileSystem.FolderRequester(), _exeMode)
            Me.Init()
            If Not Me.IsProperlyInitialized() Then
                Application.Exit()
            End If
        End If

        '** Init the form
        Me.FormReady()
        _state = State.Initialized
        Me.Activate()
    End Sub

#End Region


#Region "Private functions"

    Private Sub ComputeDirectory()
        If _di IsNot Nothing Then Return '** Already computed
        Dim di As DirectoryInfoX = Nothing
        For Each file As FileInfoX In _fis
            If (di IsNot Nothing) AndAlso (Not file.Directory.IsSame(di)) Then
                Return '** The files are not all in the same directory
            End If
            di = file.Directory
        Next
        _di = di
    End Sub

    Private Sub ComputeExtension()
        If _ext IsNot Nothing Then Return '** Already computed
        Dim ext As String = Nothing
        For Each file As FileInfoX In _fis
            If (ext IsNot Nothing) AndAlso (ext <> file.Extension) Then
                Return '** All files don't have the same extension
            End If
            ext = file.Extension
        Next
        _ext = ext
    End Sub

    Private Function ConfirmClosingForm() As DialogResult
        Select Case _state
            Case State.Initialized
                Return MsgBox.AlertYesNo(String.Format("You are about to close {1}.{0}Close the program?", vbNewLine, Me.PluginName))
            Case State.Processing
                Return MsgBox.AlertYesNo(String.Format("{1} is processing your files.{0}This will stop the process. Continue anyway?", vbNewLine, Me.PluginName))
            Case Else
                Return Windows.Forms.DialogResult.OK
        End Select
    End Function

#End Region


#Region "BgColor and Validation functions"

    Protected Function GetBackgroundColor(ByVal ok As Boolean) As Color
        Return Gadgets.Toolbox.GetBackgroundColor(ok)
    End Function

    Protected Function IsInError(ByVal color As Color) As Boolean
        Return Gadgets.Toolbox.IsInError(color)
    End Function

    Protected Function IsOk(ByVal color As Color) As Boolean
        Return Gadgets.Toolbox.IsOk(color)
    End Function

#End Region


#Region "Other functions"

    Private _fileExtensions As List(Of String) = Nothing
    Protected ReadOnly Property FileExtensions() As List(Of String)
        Get
            If _fileExtensions Is Nothing Then
                _fileExtensions = New List(Of String)
                For Each fi As FileInfoX In _fis
                    Dim ext As String = fi.Extension
                    If Not _fileExtensions.Contains(ext) Then _fileExtensions.Add(ext)
                Next
            End If
            Return _fileExtensions
        End Get
    End Property

#End Region


End Class