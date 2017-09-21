Imports FA.Library


Public Class FrmAppend


#Region "Members"

    Protected _outputFile As FileInfoX = Nothing
    Protected WithEvents _bgwAppendFiles As New BgwAppendFiles()
    Protected _dlgProgress As DlgProcessing

#End Region


#Region "MustOverride (CreateLauncher)"

    Protected Overrides Function CreateLauncher() As IPluginLauncher
        Return New LauncherAppend()
    End Function

#End Region


#Region "Overrides (FormReady and FormIsClosing)"

    Protected Overrides Sub FormReady()
        '** Init UI
        Me.FillListBox()
        Me.UpdateMoveButtons()

        '** Tooltip
        Me.TtButtonTip.SetToolTip(Me.BtnMoveTop, "Move the selected item to the top")
        Me.TtButtonTip.SetToolTip(Me.BtnMoveUp, "Move the selected item up")
        Me.TtButtonTip.SetToolTip(Me.BtnReverseOrder, "Reverse the items")
        Me.TtButtonTip.SetToolTip(Me.BtnMoveDown, "Move the selected item down")
        Me.TtButtonTip.SetToolTip(Me.BtnMoveBottom, "Move the selected item to the bottom")
    End Sub

    Protected Overrides Sub FormIsClosing()
    End Sub

#End Region


#Region "UI functions"

    Private Sub FillListBox()
        Me.LbFiles.Items.Clear()
        For Each fi As FileInfoX In _fis
            Me.LbFiles.Items.Add(fi.Name)
        Next
    End Sub

    Private Sub UpdateMoveButtons()
        Dim idx As Integer = Me.LbFiles.SelectedIndex, enabled As Boolean = (idx >= 0)
        Dim first As Boolean = (idx = 0), last As Boolean = (idx = _fis.Count - 1)
        Me.BtnMoveTop.Enabled = enabled And (Not first)
        Me.BtnMoveUp.Enabled = enabled And (Not first)
        Me.BtnMoveDown.Enabled = enabled And (Not last)
        Me.BtnMoveBottom.Enabled = enabled And (Not last)
        Me.BtnRemove.Enabled = enabled
    End Sub

#End Region


#Region "Events"

#Region "Events - Move Buttons"

    Private Sub BtnMoveTop_Click(sender As System.Object, e As System.EventArgs) Handles BtnMoveTop.Click
        Me.MoveSelectedItemTo(0)
    End Sub

    Private Sub BtnMoveUp_Click(sender As System.Object, e As System.EventArgs) Handles BtnMoveUp.Click
        Dim idx As Integer = Me.LbFiles.SelectedIndex
        Me.MoveItemTo(idx, idx - 1)
    End Sub

    Private Sub BtnReverseOrder_Click(sender As System.Object, e As System.EventArgs) Handles BtnReverseOrder.Click
        Dim idx As Integer = Me.LbFiles.SelectedIndex
        _fis.Reverse()
        Me.FillListBox()
        Me.LbFiles.SelectedIndex = (_fis.Count - 1 - idx)
    End Sub

    Private Sub BtnMoveDown_Click(sender As System.Object, e As System.EventArgs) Handles BtnMoveDown.Click
        Dim idx As Integer = Me.LbFiles.SelectedIndex
        Me.MoveItemTo(idx, idx + 1)
    End Sub

    Private Sub BtnMoveBottom_Click(sender As System.Object, e As System.EventArgs) Handles BtnMoveBottom.Click
        Me.MoveSelectedItemTo(_fis.Count - 1)
    End Sub

    Private Sub BtnRemove_Click(sender As System.Object, e As System.EventArgs) Handles BtnRemove.Click
        Dim idx As Integer = Me.LbFiles.SelectedIndex
        If MsgBox.AlertYesNo(String.Format("Are you sure to remove '{0}' ?", _fis(idx).Name)) = Windows.Forms.DialogResult.No Then Return
        Dim newIdx As Integer = CInt(IIf(idx = _fis.Count - 1, idx - 1, idx))
        _fis.RemoveAt(idx)
        Me.LbFiles.Items.RemoveAt(idx)
        Me.LbFiles.SelectedIndex = newIdx
    End Sub

#End Region

#Region "Events - BackgroundWorker"

    Private Sub _bgwAppendFiles_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles _bgwAppendFiles.ProgressChanged
        _dlgProgress.NotifyItemProcessed()
    End Sub

    Private Sub _bgwAppendFiles_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles _bgwAppendFiles.RunWorkerCompleted
        _dlgProgress.Close()
        If e.Error IsNot Nothing Then
            MsgBox.Alert(e.Error.Message)
        ElseIf Not e.Cancelled Then
            MsgBox.Info(String.Format("The {0} selected files have been successfully merged into '{1}'.{2}The program will now terminate.", _fis.Count, _outputFile.Name, vbNewLine))
            Application.Exit()
        End If
    End Sub

#End Region

#Region "Events - Others"

    Private Sub LbFiles_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles LbFiles.SelectedIndexChanged
        Me.UpdateMoveButtons()
    End Sub

    Private Sub BtnBrowse_Click(sender As System.Object, e As System.EventArgs) Handles BtnBrowse.Click
        Dim iniDir As String = Me.TxtPath.Text
        If String.IsNullOrWhiteSpace(iniDir) And _di IsNot Nothing Then iniDir = _di.FullName
        Dim fi As FileInfoX = GlobalData.FileSystem.SaveFileRequester(iniDir, False)
        If fi IsNot Nothing Then Me.TxtPath.Text = fi.FullName
    End Sub

    Private Sub TxtPath_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtPath.TextChanged
        _outputFile = New FileInfoX(Me.TxtPath.Text)
        Dim enabled As Boolean = False
        If _outputFile.IsValid AndAlso _outputFile.Directory.Exists Then
            enabled = True
            If _outputFile.Exists Then
                Dim outFile As String = _outputFile.FullName.ToLower
                For Each fi As FileInfoX In _fis
                    If fi.FullName.ToLower = outFile Then
                        enabled = False
                        Exit For
                    End If
                Next
            End If
        End If
        Me.BtnMerge.Enabled = enabled
    End Sub

    Private Sub BtnMerge_Click(sender As System.Object, e As System.EventArgs) Handles BtnMerge.Click
        _outputFile.Refresh()
        If _outputFile.Exists Then
            Select Case MsgBox.AlertYesNoCancel(String.Format("The file '{1}' already exists!{0}Would you like to append the files to it (Yes) or overwite it (No) ?", vbNewLine, _outputFile.FullName))
                Case Windows.Forms.DialogResult.Cancel
                    Return
                Case Windows.Forms.DialogResult.No
                    '** Remove file if exists
                    Try
                        _outputFile.Delete()
                    Catch ex As Exception
                        MsgBox.Alert(String.Format("Unable to delete '{1}'!{0}Reason: {2}.", vbNewLine, _outputFile.FullName, ex.Message))
                        Return
                    End Try
            End Select
        End If
        Me.RunBackgroundWorker()
    End Sub

#End Region

#End Region


#Region "Private Functions"

    Private Sub MoveSelectedItemTo(newIdx As Integer)
        Me.MoveItemTo(Me.LbFiles.SelectedIndex, newIdx)
    End Sub

    Private Sub MoveItemTo(index As Integer, newIdx As Integer)
        If newIdx < 0 Or newIdx >= _fis.Count Or newIdx = index Then Return
        Dim insertIdx As Integer = newIdx, removeIdx As Integer = index
        If newIdx < index Then
            removeIdx += 1
        Else
            insertIdx += 1
        End If
        _fis.Insert(insertIdx, _fis(index))
        _fis.RemoveAt(removeIdx)

        Me.LbFiles.Items.Insert(insertIdx, Me.LbFiles.Items(index))
        Me.LbFiles.Items.RemoveAt(removeIdx)

        Me.LbFiles.SelectedIndex = newIdx
    End Sub

    Private Sub RunBackgroundWorker()
        _dlgProgress = New DlgProcessing()
        _dlgProgress.Init(_fis.Count, "Appending files")
        _bgwAppendFiles.RunWorkerAsync(New BgwAppendFiles.DoWorkObject(_fis, _outputFile))
        If _dlgProgress.ShowDialog() = Windows.Forms.DialogResult.Abort Then
            _bgwAppendFiles.CancelAsync()
        End If
    End Sub

#End Region


End Class
