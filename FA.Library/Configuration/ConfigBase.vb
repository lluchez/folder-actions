Public Class ConfigBase
    Inherits ConfigGeneral



#Region "GetSection functions"

    Protected Function BuildSectionKey(ByVal prefix As String, ByVal section As String) As String
        Return String.Format("{0}.{1}", prefix, section)
    End Function

    Private _sectionsPrefix As String
    Protected Function GetSectionName(Optional ByVal section As String = "") As String
        If String.IsNullOrEmpty(section) Then Return _sectionsPrefix
        Return Me.BuildSectionKey(_sectionsPrefix, section)
    End Function

#End Region


#Region "Constructors"

    Public Sub New(prefix As String)
        MyBase.New()
        _sectionsPrefix = prefix
    End Sub

#End Region


End Class
