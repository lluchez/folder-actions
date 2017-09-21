Public MustInherit Class PluginLauncherAbstract
    Implements IPluginLauncher


#Region "MustOverride Properties"

    Public MustOverride ReadOnly Property ID As String Implements IPluginLauncher.ID
    Public MustOverride ReadOnly Property Name As String Implements IPluginLauncher.Name
    Public MustOverride ReadOnly Property Icon As System.Drawing.Icon Implements IPluginLauncher.Icon
    Public MustOverride ReadOnly Property CreateForm As FrmPluginAbstract

#End Region


#Region "Function ShowForm"

    Public Sub ShowForm(files As List(Of FileInfoX)) Implements IPluginLauncher.ShowForm
        Dim frm As FrmPluginAbstract = Me.CreateForm()
        If frm Is Nothing Then Return
        frm.Init(Me, files, False)
        frm.ShowDialog()
    End Sub

#End Region


End Class
