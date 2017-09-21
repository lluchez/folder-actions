Imports System.Windows.Forms



Public Class GlobalData


#Region "Namespace FileSystem"

    Public Class FileSystem

        Public Shared Function FolderRequester(Optional selectedPath As String = "", Optional newFolderBtn As Boolean = True) As DirectoryInfoX
            Dim dlg As New FolderBrowserDialog()
            dlg.SelectedPath = selectedPath
            dlg.ShowNewFolderButton = newFolderBtn
            If (dlg.ShowDialog() = DialogResult.OK) Then
                Return New DirectoryInfoX(dlg.SelectedPath)
            End If
            Return New EmptyDirectoryInfoX()
        End Function

        Public Shared Function SaveFileRequester(Optional initialPath As String = "", Optional overwritePrompt As Boolean = True) As FileInfoX
            Dim dlg As New SaveFileDialog()
            dlg.InitialDirectory = initialPath
            dlg.OverwritePrompt = overwritePrompt
            dlg.RestoreDirectory = True
            If (dlg.ShowDialog() = DialogResult.OK) Then
                Return New FileInfoX(dlg.FileName)
            End If
            Return New FileInfoX()
        End Function

        Public Shared Function IsValidFileName(filename As String) As Boolean
            For Each c In IO.Path.GetInvalidFileNameChars()
                If filename.Contains(c) Then
                    Return False
                End If
            Next
            Return True
        End Function

        Public Shared Function IsValidPathName(path As String) As Boolean
            For Each c In IO.Path.GetInvalidPathChars()
                If path.Contains(c) Then
                    Return False
                End If
            Next
            Return True
        End Function

    End Class

#End Region


#Region "Namespace ExtensionsSeparator"

    Public Class ExtensionsSeparator

        Public Const DefSeparator As Char = ";"c
        Public Shared Separators() As Char = New Char() {DefSeparator, ","c, "|"c}

        Public Shared Function Split(ByVal str As String) As List(Of String)
            Dim parts As New List(Of String)
            For Each part As String In str.Split(Separators)
                part = part.Trim()
                If (part.Length > 0) Then parts.Add(part)
            Next
            Return parts
        End Function

    End Class

#End Region


#Region "Namespace Sys (System)"

    Public Class Sys

        Public Shared Function GetApplicationVersion(Optional ByVal appVersion As System.Version = Nothing) As String
            If appVersion Is Nothing Then appVersion = My.Application.Info.Version
            Dim sVersion As String = String.Format("{0}.{1:00}", appVersion.Major, appVersion.Minor)
            If appVersion.Build <> 0 Then sVersion &= "." & IntegerManager.ToString(appVersion.Build)
            Return sVersion
        End Function

        Public Shared Function CountProcessors() As Integer
            Return Environment.ProcessorCount
        End Function

    End Class

#End Region


#Region "Namespace Icon"

    Class Icon

        <System.Runtime.InteropServices.DllImport("shell32.dll")> _
        Private Shared Function ExtractAssociatedIcon(ByVal hinst As IntPtr, ByVal lpiconpath As String, ByRef lpiicon As Integer) As IntPtr
        End Function

        'Public Shared Function ExtractIcon(frm As Form, path As String, Optional index As Integer = 0) As Drawing.Icon
        '    Dim hIcon As IntPtr = ExtractAssociatedIcon(frm.Handle, path, index)
        '    If hIcon = Nothing Then Return Nothing
        '    Return Drawing.Icon.FromHandle(hIcon)
        'End Function

    End Class


#End Region


End Class
