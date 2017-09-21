Imports FA.Library
Imports System.Text.RegularExpressions


Public Class FrmImgCompressor


#Region "Members"

    'Protected WithEvents _lvListener As Gadgets.ListViewListener

    Protected _bgwImgCompressors As New List(Of BgwCompressImages)
    Protected _dlgImgCompressor As New DlgProcessing()
    Protected _bgwDoWorkParams As BgwCompressImages.DoWorkObject
    Protected _allImages As New ImagesToProcess()
    Protected _imagesQueue As New SyncFIFO(Of ImageToProcess)

    Protected ReadOnly _eregResizePercent As New Regex("^(\d+(.\d+)?)\s?%$")
    Protected ReadOnly _eregResizeFraction As New Regex("^(\d+)/(\d+)$")

    Protected _resizeRatio As Double = 1

    Protected Const MaskCounterName As String = "cpt"
    Protected Const MaskCounter As String = "{" & MaskCounterName & "}" '** {num}
    Protected ReadOnly _maskCounterParser As New MaskCounterParser(MaskCounterName)
    Protected Const _DefMaskCounter As String = "{" & MaskCounterName & ":000}"
    Protected Const DefMaskCounter As String = "{" & MaskCounterName & ":3}"

    Private ReadOnly _lock As New Object()
    Private _bgwErrored As Boolean = False
    Private _bgwNoItemDone As Boolean = True
    Private _scrolledTo As Integer = -1
    Private _lvVisibleItems As Integer = 0

    Protected _totalSize As Long = 0
    Protected _nbFilesProcessed As Integer = 0
    Protected _exTotalSize As Long = 0
    Protected _newTotalSize As Long = 0

    'Protected Const NO_RESIZE_TEXT As String = "Don't resize"

#End Region


#Region "Properties"

#Region "Properties: Main"

    Protected _config As ConfigImgCompressor = Nothing
    Protected ReadOnly Property Config() As ConfigImgCompressor
        Get
            If (_config Is Nothing) Then _config = New ConfigImgCompressor(Me)
            Return _config
        End Get
    End Property

    Protected ReadOnly Property IsChecked(chkBox As CheckBox) As Boolean
        Get
            Return chkBox.Checked And chkBox.Enabled
        End Get
    End Property

    Protected ReadOnly Property ExtensionIsUnChanged() As Boolean
        Get
            Return Not ((Me.FileExtensions().Count <> 1) OrElse (Me.FileExtensions(0) <> Me.SelectedExtension))
        End Get
    End Property

#End Region

#Region "Properties: SelectedXXX"

    Protected ReadOnly Property SelectedImageFormat() As Imaging.ImageFormat
        Get
            Return ImageFormats.GetImageFormat(Me.CmbFormat.SelectedIndex)
        End Get
    End Property

    Protected ReadOnly Property SelectedImgFormat() As ImageFormats.Formats
        Get
            Return ImageFormats.GetFormat(Me.CmbFormat.SelectedIndex)
        End Get
    End Property

    Protected ReadOnly Property SelectedExtension() As String
        Get
            Return ImageFormats.GetExtension(Me.CmbFormat.SelectedIndex)
        End Get
    End Property

    Protected ReadOnly Property SelectedInterpolationMode() As Drawing2D.InterpolationMode
        Get
            Return ResizingModes.GetInterpolationMode(Me.CmbResizeMethod.SelectedIndex)
        End Get
    End Property

    Protected ReadOnly Property SelectedResizeMethod() As ResizingModes.Modes
        Get
            Return ResizingModes.GetMode(Me.CmbResizeMethod.SelectedIndex)
        End Get
    End Property

    Protected ReadOnly Property SelectedJpegCompressionLevel() As Integer
        Get
            Return Me.TrbCompression.Value
        End Get
    End Property

    Protected ReadOnly Property SelectedEncoderParameters() As Imaging.EncoderParameters
        Get
            Select Case Me.SelectedImgFormat()
                Case ImageFormats.Formats.Jpeg
                    Dim params As New Imaging.EncoderParameters(1)
                    params.Param(0) = New Imaging.EncoderParameter(Imaging.Encoder.Quality, CType(Me.TrbCompression.Value, Int32))
                    Return params
                Case Else
                    Return Nothing
            End Select
        End Get
    End Property

    Protected ReadOnly Property SelectedParallelThreads() As Integer
        Get
            Return IntegerManager.Parse(CStr(Me.CmbNbThreads.SelectedItem))
        End Get
    End Property

#End Region

#End Region


#Region "MustOverride (CreateLauncher)"

    Private Property _lockBgws As Object

    Protected Overrides Function CreateLauncher() As IPluginLauncher
        Return New LauncherImgCompressor()
    End Function

#End Region


#Region "Overrides (FormReady and FormIsClosing)"

    Protected Overrides Sub FormReady()
        Me.InitUI()
    End Sub

    Protected Overrides Sub FormIsClosing()
        '_lvListener.Close/Dispose()
    End Sub

#End Region


#Region "Init UI functions"

    Private Sub InitUI()
        '** ListView for files
        '_lvListener = New Gadgets.ListViewListener(Me.LvFiles, 0)
        '_lvListener.AssignHandle(Me.LvFiles.Handle)

        '** Init UI
        Me.InitCombos()
        Me.InitWithConfig()

        '** Rename pattern
        Dim baseName As String = "Photos"
        If _di.Exists() Then baseName = _di.Name
        Me.TxtRenameMask.Text = String.Format("{0} {1}", baseName, DefMaskCounter)
        Me.ChkRename.Checked = False
        'Me.UpdateCheckboxDeleteOriginal()

        '** Files
        '_lvListener.ClearListViewItems()
        Me.LvFiles.Items.Clear()
        Dim items As New List(Of ListViewItem)
        For Each fi As FileInfoX In _fis
            Dim item As New ListViewItem(fi.Name)
            item.SubItems.Add("")
            item.SubItems.Add("")
            items.Add(item)
            _allImages.Add(New ImageToProcess(fi))
            _totalSize += fi.Length
        Next
        '_lvListener.AddItemsToListView(items)
        Me.LvFiles.Items.AddRange(items.ToArray)
        Me.UpdateTotalSizeLabel()

        '** Tooltip
        Me.TtTextboxTip.SetToolTip(Me.PctRenameMask, String.Format("You can use the following '{1}', '{2}' or '{3}'.{0}It will be replaced by the value of the counter:{0}-'{1}': will handle automatically the number of digits," & _
                                                                   "{0}-'{2}' and '{3}': will fix the number of digits to 3 for instance.{0}{0}The extension will automatically be added to the file name.", _
                                                                    vbNewLine, MaskCounter, _DefMaskCounter, DefMaskCounter))
        Me.TtSaveBtnTip.SetToolTip(Me.BtnSave, String.Format("Save the following options for next time:{0}- Jpeg quality,{0}- Resizing ratio,{0}- Interpolation mode,{0}- Parallel processing", vbNewLine))
    End Sub

    Private Sub InitCombos()
        '** Combo Formats
        Me.CmbFormat.Items.Clear()
        Me.CmbFormat.Items.AddRange(ImageFormats.Names.ToArray)
        Me.CmbFormat.SelectedIndex = ImageFormats.Formats.Jpeg

        '** Combo Resize Ratio
        Me.CmbSize.Items.Clear()
        For Each i As Integer In New Integer() {8, 4, 2}
            Me.CmbSize.Items.Add(IntegerManager.ToString(i * 100) & "%")
        Next
        Dim idxNoResize As Integer = Me.CmbSize.Items.Add(ConfigImgCompressor.DEFAULT_SIZE)
        For Each i As Integer In New Integer() {2, 3, 4, 5}
            Me.CmbSize.Items.Add("1/" & IntegerManager.ToString(i))
        Next
        'Me.CmbSize.SelectedIndex = idxNoResize
        Me.CmbSize.SelectedText = Me.Config().ResizingRatio

        '** Combo Interpolation Mode (reside method)
        Me.CmbResizeMethod.Items.Clear()
        Me.CmbResizeMethod.Items.AddRange(ResizingModes.Names)

        '** Combo NbThreads
        Me.CmbNbThreads.Items.Clear()
        Dim nbCPUs As Integer = GlobalData.Sys.CountProcessors()
        If nbCPUs >= 2 Then
            For i As Integer = 2 To nbCPUs
                Me.CmbNbThreads.Items.Add(IntegerManager.ToString(i))
            Next
            Me.CmbNbThreads.SelectedItem = IntegerManager.ToString(Me.Config().ParallelThreads)
        Else
            Me.ChkParallelProcessing.Enabled = False
        End If
        Me.ChkParallelProcessing.Checked = Me.Config().EnableParallelProcessing
        Me.LlbCpuCores.Text = IntegerManager.ToString(nbCPUs)
    End Sub

    Private Sub InitWithConfig()
        Me.TrbCompression.Value = Me.Config().JpegCompression
        Me.LblCompression.Text = IntegerManager.ToString(Me.TrbCompression.Value)
        Me.CmbResizeMethod.SelectedIndex = Me.Config().InterpolationMode
    End Sub

    Private Sub UpdateTotalSizeLabel()
        Me.LblTotalSize.Text = StringManager.Conversion.SizeToString(_totalSize)
    End Sub

#End Region


#Region "Events"

#Region "Events: Combos and TrackBar"

    Private Sub CmbFormat_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles CmbFormat.SelectedIndexChanged
        Dim isJpeg As Boolean = (CmbFormat.SelectedIndex = ImageFormats.Formats.Jpeg)
        Me.PanelJpeqQuality.Visible = isJpeg
        'Me.ChkKeepDate.Enabled = isJpeg
        'Me.ChkKeepExif.Enabled = isJpeg
        Me.UpdateCheckboxDeleteOriginal()
    End Sub

    Private Sub CmbSize_TextChanged(sender As Object, e As System.EventArgs) Handles CmbSize.TextChanged
        Dim newSize As String = Me.CmbSize.Text
        _resizeRatio = 1
        If newSize <> ConfigImgCompressor.DEFAULT_SIZE Then
            Dim m As Match = _eregResizePercent.Match(newSize)
            If m.Success Then
                Dim prCent As Double = DoubleManager.Parse(m.Groups(1).Value)
                _resizeRatio = prCent / 100
            Else
                m = _eregResizeFraction.Match(newSize)
                If m.Success Then
                    Dim lVal As Integer = IntegerManager.Parse(m.Groups(1).Value), rVal As Integer = IntegerManager.Parse(m.Groups(2).Value)
                    If lVal <> 0 Then _resizeRatio = lVal / rVal
                End If
            End If
        End If
        Me.PanelInterpolationMode.Enabled = (_resizeRatio <> 1)
    End Sub

    Private Sub ChkResize_CheckedChanged(sender As System.Object, e As System.EventArgs)
        Me.PanelInterpolationMode.Visible = Visible
    End Sub

    Private Sub TrbCompression_Scroll(sender As System.Object, e As System.EventArgs) Handles TrbCompression.Scroll
        Me.LblCompression.Text = CStr(TrbCompression.Value)
    End Sub

#End Region

#Region "Events: Textboxes / Button Browse"

    Private Sub TxtRenameMask_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtRenameMask.TextChanged
        Me.ChkRename.Checked = (Me.TxtRenameMask.Text <> "")
    End Sub

    Private Sub TxtPath_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtPath.TextChanged
        Me.ChkMoveTo.Checked = (Me.TxtPath.Text <> "")
    End Sub

    Private Sub BtnBrowse_Click(sender As System.Object, e As System.EventArgs) Handles BtnBrowse.Click
        Dim di As DirectoryInfoX = GlobalData.FileSystem.FolderRequester()
        If di.Exists Then Me.TxtPath.Text = di.FullName
    End Sub

#End Region

#Region "Events: Checkboxes"

    Private Sub ChkRename_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkRename.CheckedChanged
        Me.UpdateCheckboxDeleteOriginal()
    End Sub

    Private Sub ChkMoveTo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkMoveTo.CheckedChanged
        Me.UpdateCheckboxDeleteOriginal()
    End Sub

    Private Sub ChkParallelProcessing_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkParallelProcessing.CheckedChanged
        Me.PanelParallelProcessing.Enabled = Me.ChkParallelProcessing.Checked
    End Sub

    Private Sub UpdateCheckboxDeleteOriginal()
        Me.ChkDeleteOrignal.Enabled = Me.ChkRename.Checked Or Me.ChkMoveTo.Checked Or Not Me.ExtensionIsUnChanged()
    End Sub

#End Region

#Region "Events: Button"

    Private Sub BtnProcess_Click(sender As System.Object, e As System.EventArgs) Handles BtnProcess.Click
        Try
            If Me.InitProcessAndCheck() Then
                Me.BtnProcess.Enabled = False
                Dim ts As DateTime = Now
                Me.StartCompressingImages()
                If _nbFilesProcessed = _allImages.Count Then
                    _state = State.Done
                    If Me.IsChecked(Me.ChkDeleteOrignal) Then
                        For Each item As ImageToProcess In _allImages
                            Try
                                If Not item.SourceFile.IsSame(item.DestinationFile) Then item.SourceFile.Delete()
                            Catch ex As Exception
                                MsgBox.Alert(String.Format("Unable to delete the file '{0}': {1}", item.SourceFile.Name, ex.Message))
                            End Try
                        Next
                    End If
                    Dim msg As String = "All images have been successfully compressed!{0}{0}Summary:{0}- Total size was: {1}{0}- Total size is now: {2}{0}- Compression ratio: {3} ({4}){0}- Total time: {5:mm}min{5:ss}{0}{0}The program will now terminate."
                    MsgBox.Info(String.Format(msg, vbNewLine, StringManager.Conversion.SizeToString(_exTotalSize), StringManager.Conversion.SizeToString(_newTotalSize), _
                                              Me.LblAverageCompression.Text, IIf(_newTotalSize < _exTotalSize, "gain", "lost"), (Now - ts)))
                    Application.Exit()
                End If
            End If
        Catch ex As Exception
            MsgBox.Alert(ex.Message & "!")
        End Try
        Me.BtnProcess.Enabled = True
    End Sub

    Private Sub BtnSave_Click(sender As System.Object, e As System.EventArgs) Handles BtnSave.Click
        Try
            Dim config As ConfigImgCompressor = Me.Config()
            config.ResizingRatio = CStr(Me.CmbSize.Text)
            config.JpegCompression = Me.SelectedJpegCompressionLevel
            config.InterpolationMode = Me.SelectedResizeMethod
            config.EnableParallelProcessing = Me.ChkParallelProcessing.Checked
            If config.EnableParallelProcessing Then
                config.ParallelThreads = Me.SelectedParallelThreads
            End If
            MsgBox.Info("Settings have been saved for next time!")
        Catch ex As Exception
            MsgBox.Alert(String.Format("An error occured: {0}!", ex.Message))
        End Try
    End Sub

#End Region

#Region "Events: Others"

    Private Sub LvFiles_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles LvFiles.KeyDown
        If e.KeyCode = Keys.Delete Then
            Dim lv As ListView = Me.LvFiles, nb As Integer = lv.SelectedItems.Count
            If nb > 0 Then
                If MsgBox.AlertYesNo(String.Format("Are you sure to remove from the batch list these {0} item(s)?", nb)) = Windows.Forms.DialogResult.Yes Then
                    While lv.SelectedItems.Count > 0
                        Dim item As ListViewItem = lv.SelectedItems(0), index As Integer = item.Index
                        If _allImages(index).State = ImageToProcess.States.Success Then
                            item.Selected = False
                        Else
                            lv.Items.Remove(item)
                            _totalSize -= _allImages(index).SourceFile.Length
                            _allImages.RemoveAt(index)
                        End If
                    End While
                    Me.UpdateTotalSizeLabel()
                End If
            End If
        End If
    End Sub

#End Region

#End Region


#Region "Process functions"

    Private Function InitProcessAndCheck() As Boolean
        Dim renameMask As String, mask As String, maskParser As MaskCounterParser, newDir As DirectoryInfoX
        Dim newExt As String = Me.SelectedExtension()
        Dim counter As Integer = CInt(Me.NumCounterStartAt.Value)
        If Me.ChkRename.Checked Then
            maskParser = New MaskCounterParser()
            renameMask = Me.TxtRenameMask.Text
            If Not GlobalData.FileSystem.IsValidFileName(maskParser.Replace(renameMask, "")) Then
                Throw New Exception("The mask for the counter is missing")
            End If
            mask = maskParser.GetMask(renameMask, _allImages.Count, counter)
        Else
            renameMask = Nothing
            maskParser = Nothing
            mask = Nothing
        End If
        If Me.ChkMoveTo.Checked Then
            newDir = New DirectoryInfoX(Me.TxtPath.Text)
            If (Not newDir.IsValid) Then
                Throw New Exception("Invalid destination folder")
            ElseIf (Not newDir.Exists) Then
                If MsgBox.AlertYesNo("The destination folder doesn't exist." & vbNewLine & "Create it?") = Windows.Forms.DialogResult.Yes Then
                    Try
                        newDir = New DirectoryInfoX(IO.Directory.CreateDirectory(newDir.FullName))
                    Catch ex As Exception
                        Throw New Exception("Can't create the directory: " & ex.Message)
                    End Try
                Else
                    Return False
                End If
            End If
        Else
            newDir = New EmptyDirectoryInfoX()
        End If
        _imagesQueue.Clear()
        _imagesQueue.Push(_allImages.GetImagesToCompress(newExt, renameMask, mask, maskParser, counter, newDir))
        Return True
    End Function

    Private Sub StartCompressingImages()
        _bgwErrored = False
        _bgwNoItemDone = True
        _lvVisibleItems = Me.ListView_GetVisibleCount(Me.LvFiles.Handle)
        Dim bgw As BgwCompressImages = Me.CreateBackgroundWorker()
        _bgwImgCompressors.Add(bgw)
        _dlgImgCompressor = New DlgProcessing()
        _dlgImgCompressor.Init(_imagesQueue.Count, _launcher.Name, "Are you sure to stop converting these images?", My.Resources.Icon)
        _bgwDoWorkParams = New BgwCompressImages.DoWorkObject(_imagesQueue, Me.SelectedImageFormat, Me.SelectedEncoderParameters, _resizeRatio, _
                                                              Me.SelectedInterpolationMode, Me.ChkDeleteOrignal.Checked, Me.ChkOverwrite.Checked, Me.ChkKeepDate.Checked, Me.ChkKeepExif.Checked)
        bgw.RunWorkerAsync(_bgwDoWorkParams)
        If _dlgImgCompressor.ShowDialog() = Windows.Forms.DialogResult.Abort Then
            Me.CancelBackgroundWorkers()
        End If
    End Sub

    Private Sub StartOtherBackgroundWorkers()
        Dim nbThreads As Integer = Me.SelectedParallelThreads
        For i As Integer = 2 To nbThreads
            Dim bgw As BgwCompressImages = Me.CreateBackgroundWorker()
            _bgwImgCompressors.Add(bgw)
            bgw.RunWorkerAsync(_bgwDoWorkParams)
        Next
    End Sub

#End Region


#Region "BackgroundWorkers"

#Region "BackgroundWorders: Callbacks"

    Private Sub Bgw_WorkCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        Dim bgw As BgwCompressImages = CType(sender, BgwCompressImages), ex As Exception = e.Error
        Dim err As Boolean = (ex IsNot Nothing)
        Dim showError As Boolean = False
        SyncLock _lock
            _bgwImgCompressors.Remove(bgw)
            If (Not _bgwErrored) And (err) Then
                Me.CancelBackgroundWorkers()
                showError = Not _bgwErrored
                _bgwErrored = True
                _dlgImgCompressor.Abort()
            End If
        End SyncLock
        If err Then
            If showError Then MsgBox.Alert(ex.Message)
            If ex.GetType() Is GetType(BgwCompressImages.ImageProcessingException) Then
                Dim lvItem As ListViewItem = GetLvItem(CType(ex, BgwCompressImages.ImageProcessingException).CurrentImage)
                lvItem.BackColor = Gadgets.Toolbox.BgColorError
                Me.ScrollToListViewItem(lvItem, lvItem.Index)
            End If
        End If
        AddHandler bgw.ProgressChanged, AddressOf Bgw_ProgressChanged
        RemoveHandler bgw.ProgressChanged, AddressOf Bgw_ProgressChanged
    End Sub

    Private Sub Bgw_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs)
        Dim usrState As BgwCompressImages.UserStateObject = CType(e.UserState, BgwCompressImages.UserStateObject)
        SyncLock _lock
            _dlgImgCompressor.NotifyItemProcessed()
            If _bgwNoItemDone Then
                _bgwNoItemDone = False
                If Me.IsChecked(Me.ChkParallelProcessing) Then
                    Me.StartOtherBackgroundWorkers()
                End If
            End If
        End SyncLock
        usrState.Image.MarkAsDone()
        Dim lvItem As ListViewItem = GetLvItem(usrState.Image)
        lvItem.BackColor = Color.FromArgb(200, 255, 200)
        Dim dstFi As FileInfoX = usrState.Image.DestinationFile
        Dim exSize As Long = usrState.Image.SourceFile.Length, newSize As Long = dstFi.Length
        lvItem.SubItems(1).Text = dstFi.LengthFormatted
        lvItem.SubItems(2).Text = Me.GetCompressionRatio(newSize, exSize)
        Me.ScrollToListViewItem(lvItem, lvItem.Index)
        SyncLock _lock
            _nbFilesProcessed += 1
            _exTotalSize += exSize
            _newTotalSize += newSize
            Me.LblAverageCompression.Text = Me.GetCompressionRatio(_newTotalSize, _exTotalSize)
            Me.LblAverageCompression.Visible = True
        End SyncLock
    End Sub

    Private Function GetCompressionRatio(newSize As Long, exSize As Long) As String
        Return String.Format("{0} %", CInt(Math.Ceiling((newSize * 100) / exSize)))
    End Function

    Private Function GetLvItem(img As ImageToProcess) As ListViewItem
        Dim index As Integer = _allImages.IndexOf(img)
        Return Me.LvFiles.Items(index)
    End Function

    Private Sub ScrollToListViewItem(lvItem As ListViewItem, idx As Integer)
        If _scrolledTo > idx OrElse Me.WindowState = Windows.Forms.FormWindowState.Minimized Then Return
        If idx < _lvVisibleItems Then
            idx = _lvVisibleItems
        Else
            lvItem = Me.LvFiles.Items(idx + 2 - _lvVisibleItems)
        End If
        Try
            Me.LvFiles.TopItem = lvItem
            _scrolledTo = idx
        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region "BackgroundWorders: functions"

    Private Function CreateBackgroundWorker() As BgwCompressImages
        Dim bgw As New BgwCompressImages()
        AddHandler bgw.RunWorkerCompleted, AddressOf Bgw_WorkCompleted
        AddHandler bgw.ProgressChanged, AddressOf Bgw_ProgressChanged
        Return bgw
    End Function

    Private Sub CancelBackgroundWorkers()
        For Each bw As BgwCompressImages In _bgwImgCompressors
            bw.CancelAsync()
        Next
    End Sub

#End Region

#End Region


#Region "API (ListView_GetVisibleCount)"

    Private Const LVM_FIRST = &H1000
    Private Const LVM_GETCOUNTPERPAGE As Long = (LVM_FIRST + 40)
    Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As IntPtr, ByVal wMsg As Long, ByVal wParam As Long, ByVal lParam As Long) As Long

    Private Function ListView_GetVisibleCount(ByVal hwndlv As IntPtr) As Integer
        Return CInt(SendMessage(hwndlv, LVM_GETCOUNTPERPAGE, 0&, 0&))
    End Function

#End Region


End Class
