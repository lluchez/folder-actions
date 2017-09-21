Imports System.Windows.Forms



Public Class MsgBox

    Public Shared AppName As String = "Undefined"


#Region "Info functions"

    Public Shared Function Info(ByVal message As String, Optional ByVal buttons As MessageBoxButtons = MessageBoxButtons.OK, Optional ByVal icon As MessageBoxIcon = MessageBoxIcon.Information, Optional ByVal defBtn As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1) As DialogResult
        Return MessageBox.Show(message, AppName, buttons, icon, defBtn)
    End Function

#End Region


#Region "Alert functions"

    Public Shared Function Alert(ByVal message As String, Optional ByVal buttons As MessageBoxButtons = MessageBoxButtons.OK, Optional ByVal icon As MessageBoxIcon = MessageBoxIcon.Exclamation, Optional ByVal defBtn As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1) As DialogResult
        Return MessageBox.Show(message, AppName, buttons, icon, defBtn)
    End Function

    Public Shared Function AlertYesNo(ByVal message As String, Optional ByVal defBtn As MessageBoxDefaultButton = MessageBoxDefaultButton.Button2) As DialogResult
        Return Alert(message, MessageBoxButtons.YesNo, , defBtn)
    End Function

    Public Shared Function AlertYesNoCancel(ByVal message As String, Optional ByVal defBtn As MessageBoxDefaultButton = MessageBoxDefaultButton.Button3) As DialogResult
        Return Alert(message, MessageBoxButtons.YesNoCancel, , defBtn)
    End Function

    Public Shared Function AlertOkCancel(ByVal message As String, Optional ByVal defBtn As MessageBoxDefaultButton = MessageBoxDefaultButton.Button2) As DialogResult
        Return Alert(message, MessageBoxButtons.OKCancel, , defBtn)
    End Function

#End Region


#Region "Error functions"

    Public Shared Function [Error](ByVal message As String, Optional ByVal buttons As MessageBoxButtons = MessageBoxButtons.OK, Optional ByVal icon As MessageBoxIcon = MessageBoxIcon.Error, Optional ByVal defBtn As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1) As DialogResult
        Return MessageBox.Show(message, AppName, buttons, icon, defBtn)
    End Function

    Public Shared Function [Error](ByVal message As String, ByVal ex As Exception, Optional ByVal buttons As MessageBoxButtons = MessageBoxButtons.OK, Optional ByVal icon As MessageBoxIcon = MessageBoxIcon.Error, Optional ByVal defBtn As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1) As DialogResult
        message = GetMessage(message, ex)
        Return [Error](message, buttons, icon, defBtn)
    End Function

    Public Shared Function [Error](ByVal ex As Exception, Optional ByVal buttons As MessageBoxButtons = MessageBoxButtons.OK, Optional ByVal icon As MessageBoxIcon = MessageBoxIcon.Error, Optional ByVal defBtn As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1) As DialogResult
        Return [Error](GetMessage(ex.Message, ex.InnerException), buttons, icon, defBtn)
    End Function

#End Region


#Region "Helper functions"

    Public Shared Function GetMessage(ByVal message As String, ByVal ex As Exception) As String
        If ex Is Nothing Then Return message
        Return String.Format("{0}{1}{2} ({3})", message, vbNewLine, ex.Message, ex.GetType)
    End Function

#End Region


End Class
