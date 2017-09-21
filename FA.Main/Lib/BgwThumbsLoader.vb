Imports FA.Library


Public Class BgwThumbsLoader
    Inherits System.ComponentModel.BackgroundWorker


#Region "Constants"

    Const THUMB_WIDTH As Integer = FrmMain.THUMB_WIDTH
    Const THUMB_HEIGHT As Integer = FrmMain.THUMB_HEIGHT
    Const THUMB_RATIO As Double = THUMB_WIDTH / THUMB_HEIGHT

#End Region


#Region "Constructor"

    Public Sub New()
        Me.WorkerReportsProgress = True
        Me.WorkerSupportsCancellation = True
    End Sub

#End Region


#Region "DoWork"

    Private Sub BgwThumbsLoader_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Me.DoWork
        Dim param As DoWorkObject = CType(e.Argument, DoWorkObject), img As Image
        Dim i As Integer = 0
        For Each fi As FileInfoX In param.Files
            If Me.CancellationPending Then Return
            Try
                img = Me.ResizeThumbnail(Image.FromFile(fi.FullName))
            Catch ex As Exception
                img = Nothing
            End Try
            Me.ReportProgress(i + 1, New UserStateObject(img, i))
            i += 1
        Next
    End Sub

#End Region


#Region "ResizeThumbnail"

    Private Function ResizeThumbnail(ByVal srcImg As Image) As Image
        Dim sW As Integer = srcImg.Width, sH As Integer = srcImg.Height, ratio As Double = sW / sH
        If ratio = THUMB_RATIO Then Return srcImg
        Dim p As New Point(0, 0), s As New Size(sW, sH)
        If sW <= THUMB_WIDTH And sH <= THUMB_HEIGHT Then
            p = New Point(CInt((THUMB_WIDTH - s.Width) / 2), CInt((THUMB_HEIGHT - s.Height) / 2))
        ElseIf ratio < THUMB_RATIO Then
            Dim h As Integer = THUMB_HEIGHT, r As Double = sH / h
            Dim w As Integer = CInt(sW / r)
            s = New Size(w, h)
            p = New Point(CInt((THUMB_WIDTH - s.Width) / 2), 0)
        Else
            Dim w As Integer = THUMB_WIDTH, r As Double = sW / w
            Dim h As Integer = CInt(sH / r)
            s = New Size(w, h)
            p = New Point(0, CInt((THUMB_HEIGHT - s.Height) / 2))
        End If
        Dim img As New Bitmap(THUMB_WIDTH, THUMB_HEIGHT, Imaging.PixelFormat.Format24bppRgb)
        Dim g As Graphics = Graphics.FromImage(img)
        g.Clear(Color.White)
        g.InterpolationMode = Drawing2D.InterpolationMode.Default
        g.DrawImage(srcImg, New Rectangle(p, s), New Rectangle(0, 0, sW, sH), GraphicsUnit.Pixel)
        srcImg.Dispose()
        Return img
    End Function

#End Region


#Region "Inner Classes"

    Public Class DoWorkObject
        Public Files As List(Of FileInfoX)

        Public Sub New(files As List(Of FileInfoX))
            Me.Files = files
        End Sub
    End Class

    Public Class UserStateObject
        Public Image As Image
        Public Offset As Integer

        Public Sub New(image As Image, offset As Integer)
            Me.Image = image
            Me.Offset = offset
        End Sub
    End Class

#End Region


End Class
