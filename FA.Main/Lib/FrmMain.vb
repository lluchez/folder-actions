Imports FA
Imports FA.Library
Imports System.Text.RegularExpressions


Public Class FrmMain


#Region "Members and Constants"

    Public Const THUMB_WIDTH As Integer = 100
    Public Const THUMB_HEIGHT As Integer = 60

    Protected _lock As New Object()
    Protected WithEvents _lvListener As Gadgets.ListViewListener
    Protected _selectedFilter As Filter = Filter.Undefined
    Protected ReadOnly _errorBgColor As Color = Color.FromArgb(255, 200, 200)
    Protected _files As New List(Of FileInfoX)
    Protected _plugins As New List(Of IPluginLauncher)(New IPluginLauncher() { _
                                                        New FA.Plugin.ImagesCompressor.LauncherImgCompressor(), _
                                                        New FA.Plugin.Rename.LauncherRename(), _
                                                        New FA.Plugin.Append.LauncherAppend()
                                                    }) '  _
    Protected WithEvents _bgwThumbsLoader As New BgwThumbsLoader()
    Protected _dlgThumbsLoader As New DlgThumbsLoader()

#End Region


#Region "Properties"

    Protected _config As ConfigFA = Nothing
    Protected ReadOnly Property Config() As ConfigFA
        Get
            If (_config Is Nothing) Then _config = New ConfigFA()
            Return _config
        End Get
    End Property

    Private Property IsViewAllFilesMode() As Boolean
        Get
            Return Me.Config.ViewAllFilesOption
        End Get
        Set(ByVal value As Boolean)
            Me.Config.ViewAllFilesOption = value
        End Set
    End Property

    Private ReadOnly Property SelectedFiles() As List(Of FileInfoX)
        Get
            Dim files As New List(Of FileInfoX)
            For Each row As ListViewItem In Me.LvFiles.Items
                If row.Checked Then files.Add(_files(row.Index))
            Next
            Return files
        End Get
    End Property

    Private ReadOnly Property FilesChecked() As Integer
        Get
            Return _lvListener.CheckedItems()
        End Get
    End Property

    Private ReadOnly Property ThumbnailsView() As Boolean
        Get
            Return Me.LvFiles.View <> View.Details
        End Get
    End Property

    Private ReadOnly Property RecursiveScan() As Boolean
        Get
            Return Me.ChkRecursiveScan.Checked
        End Get
    End Property

    Private ReadOnly Property ViewHiddenFiles() As Boolean
        Get
            Return Me.Config().ViewHiddenFiles
        End Get
    End Property

#End Region


#Region "Enums (Filter and Thumbnails)"

    Enum Filter As UShort
        Undefined
        None
        Extension
        Contains
        Filter
        Regex
        Type
    End Enum

    Enum Thumbnails As Integer
        Loading
        Warning
        Count
    End Enum

    Private Sub SelectFilter(ByVal f As Filter)
        If f = _selectedFilter Then Return
        Me.TxtExtensions.Visible = (f = Filter.Extension)
        Me.TxtContains.Visible = (f = Filter.Contains)
        Me.ChkCaseSensitive.Visible = (f = Filter.Contains)
        Me.TxtFilter.Visible = (f = Filter.Filter)
        Me.TxtRegex.Visible = (f = Filter.Regex)
        Me.ComboTypes.Visible = (f = Filter.Type)
        _selectedFilter = f
    End Sub

#End Region


#Region "All Events"

#Region "Form Events (Load/Closing)"

    Private Sub FrmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        _lvListener.ReleaseHandle()
    End Sub

    Private Sub FrmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '** Init UI
        Me.InitUI()

        '** Load the Directory from the command line or the clipboard
        Dim clbTxt As String = Clipboard.GetText()
        Dim args() As String = Environment.GetCommandLineArgs()
        Dim path As String = ""
        If args.Length >= 2 Then
            path = args(1)
        ElseIf GlobalData.FileSystem.IsValidPathName(clbTxt) AndAlso IO.Path.IsPathRooted(clbTxt) Then
            path = clbTxt
        End If
        If Not String.IsNullOrWhiteSpace(path) Then
            Me.PathSelector.Path = path
            If Me.IsViewAllFilesMode() Then Me.BtnRefresh.PerformClick()
        End If
    End Sub

#End Region


#Region "Events - Buttons Click"

    'Private Sub BtnBrowse_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim di As DirectoryInfoX = GlobalData.FileSystem.FolderRequester()
    '    If di.Exists Then
    '        Me.TxtPath.Text = di.FullName
    '        If Me.IsViewAllFilesMode() Then
    '            Me.BtnRefresh.PerformClick()
    '        End If
    '    End If
    'End Sub

    Private Sub BtnBrowse_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PathSelector.PathSelected
        If Me.IsViewAllFilesMode() Then
            Me.BtnRefresh.PerformClick()
        End If
    End Sub

    Private Sub BtnApplyFilters_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnApplyFilters.Click
        SyncLock _lock
            If Me.IsViewAllFilesMode Then
                Dim files As List(Of FileInfoX) = Me.GetFilesWithFilters(_files)
                For Each row As ListViewItem In Me.LvFiles.Items
                    row.Checked = files.Contains(_files(row.Index))
                Next
                Me.UpdateProcessButton()
            Else
                Me.FillFilesListView(True)
            End If
        End SyncLock
    End Sub

    Private Sub BtnRefresh_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnRefresh.Click
        SyncLock _lock
            Me.FillFilesListView(False)
        End SyncLock
    End Sub

    Private Sub BtnSaveOptions_Click(sender As System.Object, e As System.EventArgs) Handles BtnSaveOptions.Click
        Try
            Me.Config().Recursive = Me.ChkRecursiveScan.Checked
            Me.Config().ViewHiddenFiles = Me.ChkViewHiddenFiles.Checked
            MsgBox.Info("Options have been saved for next time!")
        Catch ex As Exception
            MsgBox.Alert("Can't save the options: " & ex.Message)
        End Try
    End Sub

#End Region


#Region "Events - ListView"

    Private Sub LvFiles_ItemChecked(ByVal sender As Object, ByVal e As ItemCheckedEventArgs) Handles _lvListener.ItemChecked
        Me.UpdateProcessButton()
    End Sub

#End Region


#Region "Events - Value/Text changed/Checked"

    Private Sub TxtPath_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PathSelector.PathChanged
        Me.PathSelector.TxtPath.BackColor = Me.GetBackgroundColor(Me.ValidatePath())
        Me.UpdateViewAllFilesView()
        Me.UpdateApplyFiltersButton()
    End Sub

    Private Sub TxtExtensions_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExtensions.TextChanged
        Me.TxtExtensions.BackColor = Me.GetBackgroundColor(Me.ValidateFilterExtensions())
        Me.UpdateApplyFiltersButton()
    End Sub

    Private Sub TxtContains_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtContains.TextChanged
        Me.TxtContains.BackColor = Me.GetBackgroundColor(Me.ValidateFilterContains())
        Me.UpdateApplyFiltersButton()
    End Sub

    Private Sub TxtFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFilter.TextChanged
        Me.TxtFilter.BackColor = Me.GetBackgroundColor(Me.ValidateFilterFilters())
        Me.UpdateApplyFiltersButton()
    End Sub

    Private Sub TxtRegex_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtRegex.TextChanged
        Me.TxtRegex.BackColor = Me.GetBackgroundColor(Me.ValidateFilterRegex())
        Me.UpdateApplyFiltersButton()
    End Sub

    Private Sub ComboTypes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboTypes.SelectedIndexChanged
        Me.UpdateApplyFiltersButton()
    End Sub

#End Region


#Region "Events - Radio changed"

    Private Sub RadioAllFiles_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioAllFiles.CheckedChanged
        Me.UpdateApplyFiltersButton()
        Me.SelectFilter(Filter.None)
    End Sub

    Private Sub RadioExtension_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioExtension.CheckedChanged
        Me.TxtExtensions.BackColor = Me.GetBackgroundColor(Me.ValidateFilterExtensions())
        Me.UpdateApplyFiltersButton()
        Me.SelectFilter(Filter.Extension)
        Me.TxtExtensions.Focus()
    End Sub

    Private Sub RadioContains_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioContains.CheckedChanged
        Me.TxtContains.BackColor = Me.GetBackgroundColor(Me.ValidateFilterContains())
        Me.UpdateApplyFiltersButton()
        Me.SelectFilter(Filter.Contains)
        Me.TxtContains.Focus()
    End Sub

    Private Sub RadioFilter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioFilter.CheckedChanged
        Me.TxtFilter.BackColor = Me.GetBackgroundColor(Me.ValidateFilterFilters())
        Me.UpdateApplyFiltersButton()
        Me.SelectFilter(Filter.Filter)
        Me.TxtFilter.Focus()
    End Sub

    Private Sub RadioRegex_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioRegex.CheckedChanged
        Me.TxtRegex.BackColor = Me.GetBackgroundColor(Me.ValidateFilterRegex())
        Me.UpdateApplyFiltersButton()
        Me.SelectFilter(Filter.Regex)
        Me.TxtRegex.Focus()
    End Sub

    Private Sub RadioType_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioType.CheckedChanged
        Me.UpdateApplyFiltersButton()
        Me.SelectFilter(Filter.Type)
        Me.ComboTypes.Focus()
    End Sub

#End Region


#Region "Events - ToolStripItem"

    Private Sub ToggleView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsiViewThumbnails.Click, TsiViewDetails.Click
        Dim loadThumbs As Boolean = False
        If Me.ThumbnailsView() Then
            Me.LvFiles.View = View.Details
            Me.TsiViewThumbnails.Enabled = True
        Else
            Me.LvFiles.View = View.LargeIcon
            Me.TsiViewThumbnails.Enabled = False
            If Me.LvFiles.LargeImageList.Images.Count > 1 Then loadThumbs = True
        End If
        Me.UpdateListViewThumbnailNames(Me.ThumbnailsView())
        Me.TsiViewDetails.Enabled = Not Me.TsiViewThumbnails.Enabled
        If loadThumbs Then Me.FillListViewLargeImagesList()
    End Sub

    Private Sub TogglePanels_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsiViewAllFiles.Click, TsiFilterOut.Click
        Me.TogglePanels(True)
    End Sub

    Private Sub TogglePanels(ByVal clickPerformed As Boolean)
        Dim switchToViewAllFiles As Boolean = (Me.GrpFilters.Top < Me.GrpFiles.Top)
        Dim grpTop As GroupBox, grpBtm As GroupBox
        If switchToViewAllFiles Then
            grpTop = Me.GrpFilters
            grpBtm = Me.GrpFiles
        Else
            grpTop = Me.GrpFiles
            grpBtm = Me.GrpFilters
        End If
        Dim topPos As Integer = grpTop.Top
        grpTop.Top = grpBtm.Top + (grpBtm.Height - grpTop.Height)
        grpBtm.Top = topPos

        Me.GrpFilters.Anchor = AnchorStyles.Left Or AnchorStyles.Right Or CType(IIf(switchToViewAllFiles, AnchorStyles.Bottom, AnchorStyles.Top), AnchorStyles)
        If clickPerformed Then Me.IsViewAllFilesMode = switchToViewAllFiles
        Me.TsiViewAllFiles.Enabled = Not switchToViewAllFiles
        Me.TsiFilterOut.Enabled = switchToViewAllFiles
        Me.UpdateViewAllFilesView()
    End Sub

    Private Sub ToolStripItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) '** Launching a Plugin
        Dim tsi As ToolStripItem = CType(sender, ToolStripItem)
        Dim parts() As String = Split(tsi.Name, "_"c), index As Integer = 0
        If parts.Length <> 2 Then Return
        If Not IntegerManager.TryParse(parts(1), index) Then Return
        Me.Hide()
        _plugins(index).ShowForm(Me.SelectedFiles)
        Application.Exit()
    End Sub

    Private Sub TsiRegAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsiRegAdd.Click
        Dim shellKeyName As String = Me.Config.ShellContextMenuText
        If String.IsNullOrEmpty(shellKeyName) Then shellKeyName = "Run Folder Actions"
        Dim newKeyName As String = Me.GetShellFolderNameForRegistryKey(shellKeyName)
        If (Not String.IsNullOrEmpty(newKeyName)) Then
            Try
                Me.Config.ShellContextMenuText = newKeyName
                Me.TsiRegDel.Enabled = True
            Catch ex As Exception
                MsgBox.Alert(String.Format("Unable to read/access the Windows registry: {0}!", ex.Message))
            End Try
        End If
    End Sub

    Private Sub TsiRegDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsiRegDel.Click
        Select Case MsgBox.AlertYesNo(String.Format("Are you sure to remove the shell association '{0}' for {1}?", Me.Config.ShellContextMenuText, MsgBox.AppName))
            Case Windows.Forms.DialogResult.Yes
                Try
                    Me.Config.ShellRemove()
                    Me.TsiRegDel.Enabled = False
                Catch ex As Exception
                    MsgBox.Alert(String.Format("Unable to remove the Sheel assotiation in Windows registry: {0}!", ex.Message))
                End Try
        End Select
    End Sub

#End Region


#End Region


#Region "InitUI"

    Private Sub InitUI()
        '** Init
        Me.MinimumSize = Me.Size
        Me.Icon = My.Resources.Icon
        Me.Text = String.Format("{0} - Version {1}", My.Application.ApplicationName, GlobalData.Sys.GetApplicationVersion)

        '** Update gadgets
        Me.PathSelector.TxtPath.BackColor = Me.GetBackgroundColor(Me.ValidatePath())
        Me.SelectFilter(Filter.None)
        Me.ChkViewHiddenFiles.Checked = Me.Config().ViewHiddenFiles
        Me.ChkRecursiveScan.Checked = Me.Config().Recursive

        '** ListView for files
        _lvListener = New Gadgets.ListViewListener(Me.LvFiles, 1)
        _lvListener.AssignHandle(Me.LvFiles.Handle)
        Me.LvFiles.LargeImageList = New ImageList()
        Me.LvFiles.LargeImageList.ImageSize = New Size(THUMB_WIDTH, THUMB_HEIGHT)
        Me.LvFiles.LargeImageList.ColorDepth = ColorDepth.Depth24Bit

        '** Enable/disable gadgets
        Me.UpdateViewAllFilesView()
        Me.UpdateApplyFiltersButton()
        Me.UpdateProcessButton()

        '** ComboBox Types
        Me.ComboTypes.Items.AddRange(Me.Config.Types().Keys.ToArray)
        FA.Library.Gadgets.Toolbox.AdjustComboBoxWidth(Me.ComboTypes)

        '** Add items to the ToolStrip Menu and the event handler
        Dim i As Integer = 0
        For Each pLauncher As IPluginLauncher In _plugins
            Dim tsiItem As New ToolStripMenuItem()
            tsiItem.Name = String.Format("Tsi_{0:00}", i)
            tsiItem.Text = pLauncher.Name
            tsiItem.Size = New System.Drawing.Size(152, 22)
            If pLauncher.Icon IsNot Nothing Then tsiItem.Image = pLauncher.Icon.ToBitmap
            AddHandler tsiItem.Click, AddressOf ToolStripItem_Click
            Me.TsbActionSelector.DropDownItems.Add(tsiItem)
            i += 1
        Next

        '** TooStripTems
        Me.TsiFilterOut.Enabled = Me.Config().ViewAllFilesOption
        If Me.TsiFilterOut.Enabled Then Me.TogglePanels(False)
        Me.TsiViewAllFiles.Enabled = Not Me.TsiFilterOut.Enabled
        If Me.Config().CanAccessRegistry Then
            Me.TsiRegDel.Enabled = Me.Config().IsShellRegistred
        Else
            Me.TssRegistry.Visible = False
            Me.TsiRegAdd.Visible = False
            Me.TsiRegDel.Visible = False
        End If
    End Sub

#End Region


#Region "Filter functions"

    Private Function GetFilesWithFilters(ByVal applyFilters As Boolean) As List(Of FileInfoX)
        Return Me.GetFilesWithFilters(Me.GetFilesFromPathTextbox(), applyFilters)
    End Function

    Private Function GetFilesWithFilters(ByVal allFiles As List(Of FileInfoX), Optional ByVal applyFilters As Boolean = True) As List(Of FileInfoX)
        If (Not applyFilters) Then Return allFiles

        Dim validFiles As New List(Of FileInfoX)
        Try
            Select Case _selectedFilter

                Case Filter.Regex '** Regular Expression filter
                    Dim txt As String = Me.TxtRegex.Text, ereg As Regex = Nothing, exEreg As Exception = Nothing
                    If Not StringManager.Ereg.IsValidRegex(txt, ereg, exEreg) Then
                        Throw New FilterException(String.Format("Invalid regular expression: '{0}'", txt), exEreg)
                    End If
                    For Each fi As FileInfoX In allFiles
                        If ereg.IsMatch(fi.Name) Then validFiles.Add(fi)
                    Next

                Case Filter.Contains '** Contains Text
                    Dim caseSensitive As Boolean = Me.ChkCaseSensitive.Checked
                    Dim txt As String = Me.TxtContains.Text
                    If (Not caseSensitive) Then txt = txt.ToLower
                    For Each fi As FileInfoX In allFiles
                        If CStr(IIf(caseSensitive, fi.Name, fi.Name.ToLower)).Contains(txt) Then validFiles.Add(fi)
                    Next

                Case Filter.Extension, Filter.Type '** Filtering on the extension
                    Dim extensions As IEnumerable(Of String)
                    If _selectedFilter = Filter.Extension Then
                        extensions = GlobalData.ExtensionsSeparator.Split(Me.TxtExtensions.Text)
                    Else
                        Try
                            extensions = Me.Config.Types(Me.ComboTypes.SelectedItem.ToString)
                        Catch ex As Exception
                            Throw New FilterException("You should select an item in the dropdown", ex)
                        End Try
                    End If
                    For Each fi As FileInfoX In allFiles
                        If extensions.Contains(fi.ExtensionWithoutDot) Then validFiles.Add(fi)
                    Next

                Case Else '** All files and 
                    Return allFiles
            End Select

        Catch ex As Exception
            MsgBox.Alert(String.Format("An errror occured: {0}", ex.Message))
            Return New List(Of FileInfoX)
        End Try
        Return validFiles
    End Function

#End Region


#Region "Validate funcitons"

    Private Function ValidatePath() As Boolean
        Return Me.PathSelector.DirectoryInfo.Exists()
        'Return FileSystemInfoX.DirectoryExists(Me.TxtPath.Text)
    End Function

    Private Function ValidateFilterExtensions() As Boolean
        Return Not String.IsNullOrEmpty(Me.TxtExtensions.Text)
    End Function

    Private Function ValidateFilterContains() As Boolean
        Return Not String.IsNullOrEmpty(Me.TxtContains.Text)
    End Function

    Private Function ValidateFilterFilters() As Boolean
        Return Not String.IsNullOrEmpty(Me.TxtFilter.Text)
    End Function

    Private Function ValidateFilterRegex() As Boolean
        Return StringManager.Ereg.IsValidRegex(Me.TxtRegex.Text)
    End Function

#End Region


#Region "Update Button (Enabled/Disabled)"

    Private Function GetApplyFilterButtonState() As Boolean
        If Not Me.ValidatePath() Then Return False
        If Me.RadioAllFiles.Checked Then
            Return True
        ElseIf Me.RadioExtension.Checked Then
            Return Not Me.IsInError(Me.TxtExtensions.BackColor)
        ElseIf Me.RadioContains.Checked Then
            Return Not Me.IsInError(Me.TxtContains.BackColor)
        ElseIf Me.RadioFilter.Checked Then
            Return Not Me.IsInError(Me.TxtExtensions.BackColor)
        ElseIf Me.RadioRegex.Checked Then
            Return Not Me.IsInError(Me.TxtRegex.BackColor)
        Else
            Return Me.ComboTypes.SelectedIndex <> -1
        End If
    End Function

    Private Sub UpdateApplyFiltersButton()
        Me.BtnApplyFilters.Enabled = Me.GetApplyFilterButtonState()
    End Sub

    Private Function GetProcessButtonState() As Boolean
        Return (Me.FilesChecked > 0)
    End Function

    Private Sub UpdateProcessButton()
        Me.TsbActionSelector.Enabled = Me.GetProcessButtonState()
        Me.UpdateSelectedItemsLabel()
    End Sub

    Private Sub UpdateSelectedItemsLabel()
        If Me.FilesChecked = 0 Then
            Me.TslSelectedFiles.Text = "No items selected"
            Me.TslSelectedFiles.ForeColor = Color.Red
            Return
        ElseIf Me.FilesChecked = 1 Then
            Me.TslSelectedFiles.Text = "One item selected"
        Else
            Me.TslSelectedFiles.Text = String.Format("{0} items selected", Me.FilesChecked)
        End If
        Me.TslSelectedFiles.ForeColor = Color.Black
    End Sub

    Private Sub UpdateViewAllFilesView()
        Me.BtnRefresh.Enabled = Me.IsViewAllFilesMode AndAlso Me.ValidatePath()
    End Sub

#End Region


#Region "Files ListView functions"

    Private Sub ClearFilesListView()
        _lvListener.ClearListViewItems()
        _files.Clear()
        Me.InitListViewImageList()
        Me.TsbActionSelector.Enabled = False
    End Sub

    Private Sub FillFilesListView(ByVal applyFilters As Boolean)
        '** Clear
        Me.ClearFilesListView()

        '** Add the valid files in the List View
        Try
            Me.FillFilesListView(Me.GetFilesWithFilters(applyFilters))
        Catch ex As FilterException
            MsgBox.Alert(ex.Message) '** TO DO: Filter error message (unexpected error)
        Catch ex As Exception
            MsgBox.Alert(ex.Message) '** TO DO: Alert message (unexpected error)
        End Try
    End Sub

    Private Sub FillFilesListView(ByVal files As List(Of FileInfoX))
        _files = files
        Dim items As New List(Of ListViewItem), showThumbnailsName As Boolean = Me.ThumbnailsView()
        For Each fi As FileInfoX In files
            Dim item As New ListViewItem(Me.GetItemName(fi, showThumbnailsName), Thumbnails.Loading)
            item.Checked = True
            item.SubItems.Add(fi.Name)
            item.SubItems.Add(fi.LengthFormatted)
            item.SubItems.Add(fi.LastWriteTimeFormatted)
            items.Add(item)
            Me.TsbActionSelector.Enabled = True
        Next
        _lvListener.AddItemsToListView(items)
        If Me.ThumbnailsView() Then Me.FillListViewLargeImagesList()

        If Me.FilesChecked = 0 Then
            '** TO DO: Msg no file found!
        End If
        Me.UpdateProcessButton()
    End Sub
#End Region


#Region "Thumbnails (LargeIcons) functions"

    Private Sub InitListViewImageList()
        Me.LvFiles.LargeImageList.Images.Clear()
        Me.LvFiles.LargeImageList.Images.Add(My.Resources.ThumbLoading)
        Me.LvFiles.LargeImageList.Images.Add(My.Resources.ThumbWarning)
    End Sub

    Private Sub FillListViewLargeImagesList()
        For Each item As ListViewItem In Me.LvFiles.Items
            If item.ImageIndex = Thumbnails.Loading Then
                Dim index As Integer = item.Index, nb As Integer = Me.LvFiles.Items.Count - index
                _dlgThumbsLoader.Init(nb)
                _bgwThumbsLoader.RunWorkerAsync(New BgwThumbsLoader.DoWorkObject(_files))
                If _dlgThumbsLoader.ShowDialog() = Windows.Forms.DialogResult.Abort Then
                    _bgwThumbsLoader.CancelAsync()
                End If
                Return
            End If
        Next
    End Sub

    Private Sub UpdateListViewThumbnailNames(ByVal show As Boolean)
        Dim i As Integer = 0
        For Each fi As FileInfoX In _files
            Me.LvFiles.Items(i).Text = Me.GetItemName(fi, show)
            i += 1
        Next
    End Sub

    Private Function GetItemName(ByVal fi As FileInfoX, ByVal show As Boolean) As String
        Return CStr(IIf(show, fi.Name, ""))
    End Function

#End Region


#Region "ThumbnailsLoader functions (BackgroundWorder)"

    Private Sub BgwThumbsLoader_WorkCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles _bgwThumbsLoader.RunWorkerCompleted
        _dlgThumbsLoader.Close()
        If e.Error IsNot Nothing Then MsgBox.Alert(e.Error.Message)
    End Sub

    Private Sub BgwThumbsLoader_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles _bgwThumbsLoader.ProgressChanged
        Dim usrState As BgwThumbsLoader.UserStateObject = CType(e.UserState, BgwThumbsLoader.UserStateObject)
        _dlgThumbsLoader.NotifyItemProcessed()

        If usrState.Image Is Nothing Then
            Me.LvFiles.Items(usrState.Offset).ImageIndex = Thumbnails.Warning
        Else
            Me.LvFiles.LargeImageList.Images.Add(usrState.Image)
            Me.LvFiles.Items(usrState.Offset).ImageIndex = Me.LvFiles.LargeImageList.Images.Count - 1
        End If
    End Sub

#End Region


#Region "Private functions"

    Private Function GetFilesFromPathTextbox() As List(Of FileInfoX)
        Dim path As String = Me.PathSelector.Path
        Try
            Dim di As DirectoryInfoX = Me.PathSelector.DirectoryInfo ' Dim di As New DirectoryInfoX(path)
            If Not di.Exists Then Throw New Exception("Invalid or Inexisting directory")
            Dim f As String = "*"
            If (_selectedFilter = Filter.Filter) And (Not Me.IsViewAllFilesMode) Then f = Me.TxtFilter.Text
            Return di.GetFiles(Me.RecursiveScan, f, Me.ViewHiddenFiles)
        Catch ex As Exception
            Throw New FilterException(String.Format("Can't list the files from '{0}'", path), ex)
        End Try
    End Function

    Private Function GetBackgroundColor(ByVal ok As Boolean) As Color
        Return Gadgets.Toolbox.GetBackgroundColor(ok)
    End Function

    Private Function IsInError(ByVal color As Color) As Boolean
        Return Gadgets.Toolbox.IsInError(color)
    End Function

    Private Function GetShellFolderNameForRegistryKey(ByVal defNameKey As String) As String
        Dim nameKey As String = InputBox("Select the name that will appear in the Windows context menu", MsgBox.AppName & " - Shell registration", defNameKey).Trim()
        If nameKey.Length = 0 Then Return ""
        If New Regex("^[\w \-]{3,}$", RegexOptions.IgnoreCase).IsMatch(nameKey) Then Return nameKey
        If MsgBox.AlertYesNo("Invalid name used!" & vbNewLine & "Try again?") = Windows.Forms.DialogResult.No Then Return ""
        Return Me.GetShellFolderNameForRegistryKey(defNameKey)
    End Function

#End Region


End Class
