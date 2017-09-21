Imports FA.Library

Public Class LauncherRename
    Inherits PluginLauncherAbstract

    Public Overrides ReadOnly Property CreateForm As Library.FrmPluginAbstract
        Get
            Return New FrmRename()
        End Get
    End Property

    Public Overrides ReadOnly Property Icon As System.Drawing.Icon
        Get
            Return My.Resources.Icon
        End Get
    End Property

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Files Renamer"
        End Get
    End Property

    Public Overrides ReadOnly Property ID As String
        Get
            Return "Renamer"
        End Get
    End Property

End Class
