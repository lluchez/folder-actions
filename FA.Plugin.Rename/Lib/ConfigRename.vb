Imports FA.Library


Public Class ConfigRename
    Inherits FA.Library.ConfigPluginAbstract


#Region "Constants"

    Private Class GeneralSection
        Public Class Keys
            Public Const Overwrite As String = "Overwrite"
        End Class
    End Class

#End Region


#Region "Properties"

    Private _overwrite As Boolean
    Public Property Overwrite() As Boolean
        Get
            Return _overwrite
        End Get
        Set(ByVal value As Boolean)
            _overwrite = value
            Me.SetBoolean(Me.GetSectionName(), GeneralSection.Keys.Overwrite, value)
        End Set
    End Property

#End Region


#Region "Constructor"

    Public Sub New(ByVal plugin As FrmPluginAbstract)
        MyBase.New(plugin)

        Dim section As String = Me.GetSectionName()
        _overwrite = Me.GetBoolean(section, GeneralSection.Keys.Overwrite, False)
    End Sub

#End Region


End Class
