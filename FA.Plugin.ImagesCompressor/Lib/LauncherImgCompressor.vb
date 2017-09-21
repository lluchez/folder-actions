Imports FA.Library

Public Class LauncherImgCompressor
    Inherits PluginLauncherAbstract

    Public Overrides ReadOnly Property CreateForm As Library.FrmPluginAbstract
        Get
            Return New FrmImgCompressor()
        End Get
    End Property

    Public Overrides ReadOnly Property Icon As System.Drawing.Icon
        Get
            Return My.Resources.Icon
        End Get
    End Property

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Images Compressor"
        End Get
    End Property

    Public Overrides ReadOnly Property ID As String
        Get
            Return "ImgCompressor"
        End Get
    End Property

End Class
