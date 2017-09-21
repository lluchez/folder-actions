Public Class ConfigGeneral
    Inherits IniReader


#Region "Constants"

    Private Class GeneralSection
        Public Const SectionName As String = "General"

        Public Class Keys
            Public Const ViewHiddenFiles As String = "ViewHiddenFiles"
            Public Const Recursive As String = "Recursive"
        End Class
    End Class

#End Region


#Region "Properties"

    Private _viewHiddenFiles As Boolean
    Public Property ViewHiddenFiles() As Boolean
        Get
            Return _viewHiddenFiles
        End Get
        Set(ByVal value As Boolean)
            _viewHiddenFiles = value
            Me.SetBoolean(Me.GetGeneralSectionName(), GeneralSection.Keys.ViewHiddenFiles, value)
        End Set
    End Property

    Private _recursive As Boolean
    Public Property Recursive() As Boolean
        Get
            Return _recursive
        End Get
        Set(ByVal value As Boolean)
            _recursive = value
            Me.SetBoolean(Me.GetGeneralSectionName(), GeneralSection.Keys.Recursive, value)
        End Set
    End Property

#End Region


#Region "GetGeneralSectionName function"

    Public Function GetGeneralSectionName() As String
        Return GeneralSection.SectionName
    End Function

#End Region


#Region "Constructors"

    Public Sub New()
        MyBase.New("Settings.ini")

        Dim section As String = Me.GetGeneralSectionName()
        _viewHiddenFiles = Me.GetBoolean(section, GeneralSection.Keys.ViewHiddenFiles, False)
        _recursive = Me.GetBoolean(section, GeneralSection.Keys.Recursive, False)
    End Sub

#End Region


End Class
