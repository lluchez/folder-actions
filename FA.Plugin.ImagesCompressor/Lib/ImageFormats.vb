Public Class ImageFormats

#Region "Enums, Members and Constants"

    Public Enum Formats
        Jpeg
        Png
        Bmp
        Gif
        Icon
        Tiff
        Emf
        Exif
        Wmf
    End Enum

    Public Const DefaultImageFormat As Formats = Formats.Jpeg
    Public Const DefaultImageFormatIndex As Integer = CInt(Formats.Jpeg)

    Public Shared Names As New List(Of String)(New String() {"Jpeg", "Png", "Bmp", "Gif", "Icon", "Tiff", "Emf", "Exif", "Wmf"})
    Public Shared Extensions() As String = New String() {".jpg", ".png", ".bmp", ".gif", ".ico", ".tiff", ".emf", ".exif", ".wmf"}
    Protected Shared ImageFormats() As Imaging.ImageFormat = New Imaging.ImageFormat() {Imaging.ImageFormat.Jpeg, Imaging.ImageFormat.Png, Imaging.ImageFormat.Bmp, _
                                                                                   Imaging.ImageFormat.Gif, Imaging.ImageFormat.Icon, Imaging.ImageFormat.Tiff, _
                                                                                   Imaging.ImageFormat.Emf, Imaging.ImageFormat.Exif, Imaging.ImageFormat.Wmf}

#End Region


#Region "Public Shared functions"

    Public Shared Function NameToIndex(name As String) As Integer
        Return Names.IndexOf(name)
    End Function

    Public Shared Function GetFormat(idx As Integer) As Formats
        Return CType(idx, Formats)
    End Function

    Public Shared Function GetImageFormat(name As String) As Imaging.ImageFormat
        Return GetImageFormat(NameToIndex(name))
    End Function

    Public Shared Function GetImageFormat(idx As Integer) As Imaging.ImageFormat
        If idx < 0 Or idx >= ImageFormats.Count Then idx = DefaultImageFormatIndex
        Return ImageFormats(idx)
    End Function

    Public Shared Function GetExtension(idx As Integer) As String
        If idx < 0 Or idx >= Extensions.Count Then idx = DefaultImageFormatIndex
        Return Extensions(idx)
    End Function

#End Region


End Class
