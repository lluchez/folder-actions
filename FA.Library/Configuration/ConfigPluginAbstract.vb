Public MustInherit Class ConfigPluginAbstract
    Inherits ConfigBase


#Region "Constructor"

    Public Sub New(ByVal plugin As FrmPluginAbstract)
        MyBase.New(String.Format("Plugin.{0}", plugin.PluginID))
    End Sub

#End Region


End Class

