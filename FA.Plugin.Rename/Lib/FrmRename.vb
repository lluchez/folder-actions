Imports FA.Library
Imports System.Text.RegularExpressions


Public Class FrmRename


#Region "Constants"

    Const _MaskCounterName As String = "num"

    Const MaskBaseName As String = "{name}"
    Const MaskCounter As String = "{" & _MaskCounterName & "}" '** {num}
    Const MaskExtension As String = "{ext}"

    Const _DefMaskCounter As String = "{" & _MaskCounterName & ":000}"
    Const DefMaskCounter As String = "{" & _MaskCounterName & ":3}"

#End Region


#Region "Members"

    Protected _files As New FilesToProcess()
    Protected WithEvents _lvListener As Gadgets.ListViewListener
    Protected _changed As Boolean

    Protected ReadOnly _maskCounterParser As New MaskCounterParser(_MaskCounterName)
    Protected ReadOnly _eregRegexReplacement As New Regex("\\\d+")

    Protected _outFileNames As New Dictionary(Of String, FileToProcess)
    Protected _duplicateOutFileNames As Boolean = False

#End Region


#Region "Properties"

    Protected _config As ConfigRename = Nothing
    Protected ReadOnly Property Config() As ConfigRename
        Get
            If (_config Is Nothing) Then _config = New ConfigRename(Me)
            Return _config
        End Get
    End Property

    Private ReadOnly Property FilesChecked() As Integer
        Get
            Return _lvListener.CheckedItems()
        End Get
    End Property

#End Region


#Region "MustOverride (CreateLauncher)"

    Protected Overrides Function CreateLauncher() As IPluginLauncher
        Return New LauncherRename()
    End Function

#End Region


#Region "Overrides (FormReady and FormIsClosing)"

    Protected Overrides Sub FormReady()
        '** ListView for files
        _lvListener = New Gadgets.ListViewListener(Me.LvFiles)
        _lvListener.AssignHandle(Me.LvFiles.Handle)

        '** Init Gadgets
        Me.TxtCounterMask.Text = String.Format("{0}_{1}{2}", MaskBaseName, DefMaskCounter, MaskExtension)
        Me.ChkOverwrite.Checked = Me.Config().Overwrite

        '** Fill the list view
        Dim items As New List(Of ListViewItem)
        For Each fi As FileInfoX In _fis
            _files.Add(New FileToProcess(fi))
            Dim item As New ListViewItem("", 0)
            item.Checked = True
            item.SubItems.Add(fi.Name)
            item.SubItems.Add("")
            items.Add(item)
        Next
        _lvListener.AddItemsToListView(items)

        '** Tooltip
        Me.TtTextboxTip.SetToolTip(Me.PctCounterMask, String.Format("You can use the following masks:{0}- '{1}': will be replaced by the base file name{0}- '{2}': will be replaced by the extension{0}- '{3}': will be replaced by the value of the counter{0}{0}Note: '{4}' or '{5}' can also be used to format the counter with as many digits as wanted (in these examples)", _
                                                                    vbNewLine, MaskBaseName, MaskExtension, MaskCounter, DefMaskCounter, _DefMaskCounter))
        Me.TtTextboxTip.SetToolTip(Me.PctRegexParsing, String.Format("To make it case insensitive, add the following suffix: '/i' (or '#i')"))
        Me.TtTextboxTip.SetToolTip(Me.PctRegexReplacement, String.Format("Use '\X' to replacement with the capturing groups (where X is an integer)"))

        Me.UpdateProccessButtonsState()
        _changed = False
    End Sub

    Protected Overrides Sub FormIsClosing()
        _lvListener.ReleaseHandle()
    End Sub

#End Region


#Region "All Events"

#Region "Events TextChanged"

    Private Sub TxtCounterMask_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCounterMask.TextChanged
        Me.TxtCounterMask.BackColor = Me.GetBackgroundColor(Me.ValidateCounterMask())
        Me.RadioUseCounter.Checked = True
        Me.UpdateProccessButtonsState()
    End Sub

    Private Sub TxtRegexParsing_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtRegexParsing.TextChanged
        Me.TxtRegexParsing.BackColor = Me.GetBackgroundColor(Me.ValidateRegexParsing())
        Me.RadioRegex.Checked = True
        Me.UpdateProccessButtonsState()
    End Sub

    Private Sub TxtRegexReplacement_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtRegexReplacement.TextChanged
        Me.TxtRegexReplacement.BackColor = Me.GetBackgroundColor(Me.ValidateRegexReplacement())
        Me.RadioRegex.Checked = True
        Me.UpdateProccessButtonsState()
    End Sub

#End Region

#Region "Events Button Clicked"

    Private Sub BtnSimulate_Click(sender As System.Object, e As System.EventArgs) Handles BtnSimulate.Click
        Me.FillDestinationNameColumn()
    End Sub

    Private Sub BtnProcess_Click(sender As System.Object, e As System.EventArgs) Handles BtnProcess.Click
        Me.Process()
    End Sub

#End Region

#Region "Events ListView"

    Private Sub LvFiles_ItemChecked(sender As System.Object, e As ItemCheckedEventArgs) Handles _lvListener.ItemChecked
        Dim item As ListViewItem = e.Item
        If item.Checked AndAlso _files(item.Index).Processeed Then
            item.Checked = False
        End If
        Me.UpdateListViewItemBackColor(item)
        Me.UpdateProccessButtonsState()
    End Sub

    Private Sub LvFiles_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles LvFiles.MouseMove
        Dim lv As ListView = CType(sender, ListView)
        Dim item As ListViewItem = lv.GetItemAt(e.X, e.Y)
        Dim info As ListViewHitTestInfo = lv.HitTest(e.X, e.Y)
        If (item IsNot Nothing) AndAlso (info.SubItem IsNot Nothing) Then
            Dim msg As String = _files(item.Index).ErrorMessage
            If msg = Me.TtListViewError.GetToolTip(lv) Then Return
            Me.TtListViewError.SetToolTip(lv, msg)
        Else
            Me.TtListViewError.SetToolTip(lv, "")
        End If
    End Sub

#End Region

#Region "Events Checkbox/Radio"

    Private Sub ChkOverwrite_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkOverwrite.CheckedChanged
        Me.Config().Overwrite = Me.ChkOverwrite.Checked
    End Sub

#End Region

#End Region


#Region "Validate"

    Private Function ValidateCounterMask() As Boolean
        Dim filemask As String = Me.TxtCounterMask.Text
        If filemask.Length = 0 Then Return False
        filemask = filemask.Replace(MaskBaseName, "f")
        filemask = _maskCounterParser.Replace(filemask, "1")
        filemask = filemask.Replace(MaskExtension, ".x")
        Return GlobalData.FileSystem.IsValidFileName(filemask)
    End Function

    Private Function ValidateRegexParsing() As Boolean
        Return StringManager.Ereg.IsValidRegex(Me.TxtRegexParsing.Text)
    End Function

    Private Function ValidateRegexReplacement() As Boolean
        Dim replacement As String = Me.TxtRegexReplacement.Text
        If replacement.Length = 0 Then Return False
        replacement = _eregRegexReplacement.Replace(replacement, "a")
        Return GlobalData.FileSystem.IsValidFileName(replacement)
    End Function

#End Region


#Region "Update Button (Enabled/Disabled)"

    Private Sub UpdateProccessButtonsState()
        If _state = State.Initializing Then Return
        Dim enabled As Boolean = Me.GetProccessButtonsState()
        Me.BtnProcess.Enabled = enabled
        Me.BtnSimulate.Enabled = enabled
        _changed = True
    End Sub

    Private Function GetProccessButtonsState() As Boolean
        If _lvListener.CheckedItems = 0 Then Return False
        If Me.RadioUseCounter.Checked Then
            Return Me.IsOk(Me.TxtCounterMask.BackColor)
        Else
            Return Me.IsOk(Me.TxtRegexParsing.BackColor)
        End If
    End Function

#End Region


#Region "Update functions"

    Private Sub UpdateListViewItemBackColor(item As ListViewItem)
        Dim state As FileToProcess.States = _files(item.Index).State
        If (state = FileToProcess.States.Success) Then
            item.BackColor = Color.FromArgb(200, 255, 200)
        ElseIf (Not item.Checked) Then
            item.BackColor = Color.LightGray
        ElseIf (state = FileToProcess.States.Failed) Then
            item.BackColor = Gadgets.Toolbox.BgColorError
        Else
            item.BackColor = Color.White
        End If
    End Sub

    Private Sub UpdateDestinationFile(item As ListViewItem, fi As FileToProcess, Optional basefilename As String = "", Optional err As String = "")
        If Not String.IsNullOrEmpty(basefilename) Then
            item.SubItems(2).Text = basefilename
            fi.DestinationFileBase = basefilename
            Me.AddFilePathToListOfOutputFiles(fi)
        ElseIf Not String.IsNullOrEmpty(err) Then
            item.SubItems(2).Text = ""
            fi.MarkAsFailed("Doesn't match the regular expression")
        Else
            item.SubItems(2).Text = ""
            fi.MarkAsNotDone()
        End If
        Me.UpdateListViewItemBackColor(item)
    End Sub
    Private Sub UpdateDestinationFile(index As Integer, basefilename As String, Optional err As String = "")
        Me.UpdateDestinationFile(Me.LvFiles.Items(index), _files(index), basefilename, err)
    End Sub

#End Region


#Region "FillDestinationNameColumn"

    Private Function FillDestinationNameColumn() As Boolean
        Dim ok As Boolean = True
        Dim nbFiles As Integer = _files.Count
        _outFileNames.Clear()
        _duplicateOutFileNames = False

        If Me.RadioUseCounter.Checked Then '** Counter related

            Dim vCounter As Integer = CInt(Me.NumCounterStartAt.Value)
            Dim vStep As Integer = CInt(Me.NumCounterStep.Value)
            Dim mask As String = Me.TxtCounterMask.Text
            Dim cptMask As String = _maskCounterParser.GetMask(mask, nbFiles, vCounter, vStep)

            For i As Integer = 0 To nbFiles - 1
                Dim fi As FileToProcess = _files(i), item As ListViewItem = Me.LvFiles.Items(i)
                If item.Checked Then
                    If Not fi.Processeed Then
                        Dim file As String = mask
                        file = file.Replace(MaskBaseName, fi.SourceFile.BaseName)
                        file = _maskCounterParser.Replace(file, cptMask, vCounter)
                        file = file.Replace(MaskExtension, fi.SourceFile.Extension)
                        Me.UpdateDestinationFile(item, fi, file)
                    End If
                ElseIf (fi.State = FileToProcess.States.NotDone) Then
                    Me.UpdateDestinationFile(item, fi, "")
                End If
                vCounter += vStep
            Next

        Else '** Regex related

            Dim ereg As Regex = Nothing, eregEx As Exception = Nothing
            If Not StringManager.Ereg.IsValidRegex(Me.TxtRegexParsing.Text, ereg, eregEx) Then Return False
            Dim replacement As String = Me.TxtRegexReplacement.Text

            For i As Integer = 0 To nbFiles - 1
                Dim fi As FileToProcess = _files(i), item As ListViewItem = Me.LvFiles.Items(i)
                If item.Checked Then
                    If Not fi.Processeed Then
                        Dim m As Match = ereg.Match(fi.SourceFile.Name)
                        If m.Success Then
                            Dim file As String = replacement
                            For j As Integer = m.Groups.Count - 1 To 0 Step -1
                                file = file.Replace(String.Format("\{0}", j), m.Groups(j).Value)
                            Next
                            Me.UpdateDestinationFile(item, fi, file)
                        Else
                            Me.UpdateDestinationFile(item, fi, "", "Doesn't match the regular expression")
                            ok = False
                        End If
                    End If
                ElseIf (fi.State = FileToProcess.States.NotDone) Then
                    Me.UpdateDestinationFile(item, fi, "")
                End If
            Next

        End If

        If (Not ok) Then
            MsgBox.Alert("An error has occured!" & vbNewLine & "Please review the destination files name.")
            Return False
        ElseIf _duplicateOutFileNames Then
            MsgBox.Alert("Some destination files name are identical!" & vbNewLine & "Please change the renaming options.")
            Return False
        ElseIf (Not Me.Config().Overwrite) AndAlso (Not Me.CheckForNoFilesCollision()) Then
            Return False
        Else
            Return True
        End If
    End Function

#End Region


#Region "Process"

    Public Sub Process()
        _state = State.Processing
        If Me.FillDestinationNameColumn() Then
            Dim begOffset, endOffset, stepDir As Integer, count As Integer = _files.Count
            If Me.ChkStartByEnd.Checked Then
                begOffset = count - 1
                endOffset = 0
                stepDir = -1
            Else
                begOffset = 0
                endOffset = count - 1
                stepDir = 1
            End If

            Dim overwrite As Boolean = Me.Config().Overwrite
            For i As Integer = begOffset To endOffset Step stepDir
                Dim fi As FileToProcess = _files(i), item As ListViewItem = Me.LvFiles.Items(i)
                If item.Checked Then
                    Try
                        fi.Refresh()
                        If Not fi.SourceFile.Exists Then
                            Throw New Exception("File doesn't exist anymore")
                        End If
                        Me.CheckDestinationFilePath(fi.DestinationFile, overwrite)
                        IO.File.Move(fi.SourceFile.FullName, fi.DestinationFile.FullName)
                        fi.MarkAsDone()
                        item.Checked = False
                    Catch ex As Exception
                        fi.MarkAsFailed(ex.Message)
                        Me.UpdateListViewItemBackColor(item)
                        MsgBox.Error(String.Format("Unable to rename the file '{1}'!{0}Reason: {2}!", vbNewLine, fi.SourceFile.Name, ex.Message))
                        _state = State.Initialized
                        Return
                    End Try
                End If
            Next

            If _files.IsProcessCompleted Then
                _state = State.Done
                MsgBox.Info("All files have been successfully renamed!" & vbNewLine & "The program will now terminate.")
                Application.Exit()
            End If
        End If
        _state = State.Initialized
    End Sub

    Private Sub CheckDestinationFilePath(ByVal fi As FileInfoX, overwrite As Boolean)
        If fi.Exists Then
            If Not overwrite Then
                Dim mask As String = "The file '{1}' already exists!{0}Do you want to rename the existing file?{0}{0}Possible actions:{0}- 'Yes' to rename '{1}'{0}- 'No' to overwrite '{1}'{0}- 'Cancel' to stop."
                Select Case MsgBox.AlertYesNoCancel(String.Format(mask, vbNewLine, fi.Name))
                    Case Windows.Forms.DialogResult.Yes
                        Dim newFi As FileInfoX = GlobalData.FileSystem.SaveFileRequester(fi.Directory.FullName)
                        If newFi.IsValid Then
                            If newFi.Exists Then newFi.Delete()
                            Try
                                IO.File.Move(fi.FullName, newFi.FullName)
                                fi.Refresh()
                                Return
                            Catch ex As Exception
                                Throw New Exception(String.Format("Unable to move the existing file '{0}': {1}", fi.Name, ex.Message), ex)
                            End Try
                        End If
                    Case Windows.Forms.DialogResult.No
                        fi.Delete()
                        Return
                End Select
                Throw New Exception(String.Format("The file '{0}' already exists", fi.Name))
            Else
                fi.Delete()
            End If
        End If
    End Sub

#End Region


#Region "Other functions"

    Private Sub AddFilePathToListOfOutputFiles(ByVal fi As FileToProcess)
        Dim key As String = fi.DestinationFile.FullName.ToLower
        If _outFileNames.ContainsKey(key) Then
            _duplicateOutFileNames = True
        Else
            _outFileNames(key) = fi
        End If
    End Sub

    Private Function CheckForNoFilesCollision() As Boolean
        Dim simulation As Boolean = _state <> State.Processing
        Dim conflicts As Boolean = False
        For Each pair As KeyValuePair(Of String, FileToProcess) In _outFileNames
            Dim fi As FileToProcess = pair.Value, outName As String = pair.Key
            If fi.DestinationFile.Exists AndAlso (fi.SourceFile.FullName.ToLower <> outName) Then
                conflicts = True
                Dim found As Boolean = False
                For Each pair2 As KeyValuePair(Of String, FileToProcess) In _outFileNames
                    If pair2.Value.SourceFile.FullName.ToLower = outName Then
                        found = True
                        Exit For
                    End If
                Next
                If Not found Then
                    MsgBox.Alert(String.Format("The file '{1}' already exists!{0}Check 'Overwrite' if the renaming should erase the former file.", vbNewLine, fi.DestinationFile.Name))
                    Return False
                End If
            End If
        Next
        If conflicts Then
            Dim msg As String = "There are possible file conflicts with existing files!"
            If simulation Then
                MsgBox.Alert("Be carefull..." & vbNewLine & msg)
            ElseIf MsgBox.AlertYesNo(msg & vbNewLine & "Do you want to continue?") = Windows.Forms.DialogResult.No Then
                Return False
            End If
        End If
        Return True
    End Function

#End Region


End Class
