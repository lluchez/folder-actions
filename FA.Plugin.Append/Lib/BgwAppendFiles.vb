Imports FA.Library


Public Class BgwAppendFiles
    Inherits System.ComponentModel.BackgroundWorker



#Region "Constructor"

    Public Sub New()
        Me.WorkerReportsProgress = True
        Me.WorkerSupportsCancellation = True
    End Sub

#End Region


#Region "DoWork"

    Private Sub BgwThumbsLoader_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Me.DoWork
        Dim param As DoWorkObject = CType(e.Argument, DoWorkObject)
        '** Appen all files
        Dim i As Integer = 0
        For Each fi As FileInfoX In param.Files
            If Me.CancellationPending Then
                e.Cancel = True
                Return
            End If
            Me.ProcessFile(fi, param.DestinationFile)
            Threading.Thread.Sleep(1000)
            i += 1
            Me.ReportProgress(i)
        Next
    End Sub

    Private Sub ProcessFile(srcFile As FileInfoX, dstFile As FileInfoX)
        Try
            Dim lines() As String = IO.File.ReadAllLines(srcFile.FullName)
            IO.File.AppendAllLines(dstFile.FullName, lines)
        Catch ex As Exception
            Select Case MsgBox.AlertYesNoCancel(String.Format("Unable to process '{1}': {2}!{0}Would you like to retry?", vbNewLine, srcFile.Name, ex.Message))
                Case Windows.Forms.DialogResult.Yes
                    Me.ProcessFile(srcFile, dstFile)
                Case Windows.Forms.DialogResult.Cancel
                    Me.CancelAsync()
            End Select
        End Try
    End Sub

#End Region


#Region "Inner Classes"

    Public Class DoWorkObject
        Public Files As List(Of FileInfoX)
        Public DestinationFile As FileInfoX

        Public Sub New(ByVal files As List(Of FileInfoX), ByVal dstFile As FileInfoX)
            Me.Files = files
            Me.DestinationFile = dstFile
        End Sub
    End Class

#End Region


End Class
