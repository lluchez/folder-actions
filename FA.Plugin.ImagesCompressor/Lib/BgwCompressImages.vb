Imports FA.Library


Public Class BgwCompressImages
    Inherits System.ComponentModel.BackgroundWorker


#Region "Constructor"

    Public Sub New()
        Me.WorkerReportsProgress = True
        Me.WorkerSupportsCancellation = True
    End Sub

#End Region


#Region "DoWork"

    Private _param As DoWorkObject
    Private Sub BgwThumbsLoader_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles Me.DoWork
        _param = CType(e.Argument, DoWorkObject)
        Dim item As ImageToProcess = Nothing
        Try
            While (Not Me.CancellationPending)
                item = _param.Files.Pop()
                If item Is Nothing Then Return
                If (Not _param.Overwrite) AndAlso item.DestinationFile.Exists() AndAlso (Not item.DestinationFile.IsSame(item.SourceFile)) Then
                    Throw New Exception(String.Format("There is already a file called '{0}' in '{1}'", item.DestinationFile.Name, item.DestinationFile.DirectoryName))
                End If
                Dim img As Image = Me.CompressImage(item)
                If Me.CancellationPending Then
                    img.Dispose()
                    Return
                End If
                img.Save(item.DestinationFile.FullName, _param.CodecInfo, _param.EncoderParameters)
                item.DestinationFile.Refresh()
                img.Dispose()
                If _param.KeepTimeStamps Then
                    item.DestinationFile.InnerObject.CreationTime = item.SourceFile.InnerObject.CreationTime
                    item.DestinationFile.InnerObject.LastWriteTime = item.SourceFile.InnerObject.LastWriteTime
                    item.DestinationFile.InnerObject.LastAccessTime = item.SourceFile.InnerObject.LastAccessTime
                End If
                Me.ReportProgress(0, New UserStateObject(item))
            End While
        Catch ex As Exception
            Throw New ImageProcessingException(item, ex)
        End Try
    End Sub

#End Region


#Region "Private function (Compression/Resize)"

    Private Function CompressImage(item As ImageToProcess) As Image
        Dim img As Image = Nothing, fi As FileInfoX = item.SourceFile
        Try
            img = Image.FromFile(fi.FullName)
        Catch ex As Exception
            Throw New Exception(String.Format("Unable to load the image '{0}': {1}", fi.Name, ex.Message))
        End Try
        Try
            Return Me.ResizeImage(img)
        Catch ex As Exception
            Throw New Exception(String.Format("Unable to resize the image '{0}': {1}", fi.Name, ex.Message))
        End Try
    End Function

    Private Function ResizeImage(srcImg As Image) As Image
        Dim w As Integer = srcImg.Width, h As Integer = srcImg.Height, ratio As Double = _param.ResizeRatio
        If ratio = 1 Then
            If Not _param.KeepExifData Then
                Dim newBitmap As New Bitmap(w, h)
                Using gr As Graphics = Graphics.FromImage(newBitmap)
                    gr.InterpolationMode = _param.InterpolationMode
                    gr.DrawImage(srcImg, New Rectangle(0, 0, w, h))
                End Using
                srcImg.Dispose()
                Return newBitmap
            End If
            Return srcImg
        Else
            Dim newWidth As Integer = CInt(w * ratio), newHeight As Integer = CInt(h * ratio)
            Dim newBitmap As New Bitmap(newWidth, newHeight, Imaging.PixelFormat.Format32bppArgb)
            Using g As Graphics = Graphics.FromImage(newBitmap)
                g.InterpolationMode = _param.InterpolationMode
                g.DrawImage(srcImg, New Rectangle(0, 0, newWidth, newHeight), New Rectangle(0, 0, w, h), GraphicsUnit.Pixel)
                If _param.KeepExifData Then
                    For Each pImg As Imaging.PropertyItem In srcImg.PropertyItems
                        newBitmap.SetPropertyItem(pImg)
                    Next
                End If
            End Using
            srcImg.Dispose()
            Return newBitmap
        End If
    End Function

#End Region


#Region "Inner Classes"

    Public Class DoWorkObject
        Public Files As SyncFIFO(Of ImageToProcess)
        Public CodecInfo As Imaging.ImageCodecInfo, EncoderParameters As Imaging.EncoderParameters
        Public ResizeRatio As Double, InterpolationMode As Drawing2D.InterpolationMode
        Public DeleteOriginal, Overwrite, KeepTimeStamps, KeepExifData As Boolean

        Public Sub New(files As SyncFIFO(Of ImageToProcess), imgFormat As Imaging.ImageFormat, encoderParams As Imaging.EncoderParameters, resize As Double, _
                    interpolationMode As Drawing2D.InterpolationMode, deleteOriginal As Boolean, overwrite As Boolean, keepTimestamps As Boolean, keepExif As Boolean)
            Me.Files = files
            Me.CodecInfo = Me.GetEncoderInfo(imgFormat)
            Me.EncoderParameters = encoderParams
            Me.ResizeRatio = resize
            Me.InterpolationMode = interpolationMode
            Me.DeleteOriginal = deleteOriginal
            Me.Overwrite = overwrite
            Me.KeepTimeStamps = keepTimestamps
            Me.KeepExifData = keepExif
        End Sub

        Private Function GetEncoderInfo(ByVal format As Imaging.ImageFormat) As Imaging.ImageCodecInfo
            For Each encoder As Imaging.ImageCodecInfo In Imaging.ImageCodecInfo.GetImageEncoders()
                If encoder.FormatID = format.Guid Then Return encoder
            Next
            Return Nothing
        End Function
    End Class


    Public Class UserStateObject
        Public Image As ImageToProcess

        Public Sub New(fi As ImageToProcess)
            Me.Image = fi
        End Sub
    End Class


    Public Class ImageProcessingException
        Inherits Exception

        Public CurrentImage As ImageToProcess

        Public Sub New(currImg As ImageToProcess, innerException As Exception)
            MyBase.New(innerException.Message, innerException)
            CurrentImage = currImg
        End Sub

    End Class

#End Region


End Class
