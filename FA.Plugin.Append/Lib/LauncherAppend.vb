Imports FA.Library

Public Class LauncherAppend
    Inherits PluginLauncherAbstract

    Public Overrides ReadOnly Property CreateForm As Library.FrmPluginAbstract
        Get
            Return New FrmAppend()
        End Get
    End Property

    Public Overrides ReadOnly Property Icon As System.Drawing.Icon
        Get
            Return My.Resources.Icon
        End Get
    End Property

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Files Appender"
        End Get
    End Property

    Public Overrides ReadOnly Property ID As String
        Get
            Return "Append"
        End Get
    End Property

End Class
