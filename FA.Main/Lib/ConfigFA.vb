Imports FA.Library
Imports Microsoft.Win32


Public Class ConfigFA
    Inherits ConfigBase


#Region "Constants"

    Private Class GeneralSection
        Public Const Name As String = "Selector"

        Public Class Keys
            Public Const ViewAllFiles As String = "ViewAllFiles"
        End Class
    End Class

    Private Class SectionTypes
        Public Const Name As String = "Types"
    End Class

    Private Class RegKeys
        Public Const FolderPath As String = "Folder"
        Public Const FolderActionsPath As String = FolderPath & "\shell\FolderActions"
        Public Const CommandKey As String = "Command"
    End Class

#End Region


#Region "Properties"

    Private _types As New Dictionary(Of String, List(Of String))
    Public ReadOnly Property Types() As Dictionary(Of String, List(Of String))
        Get
            Return _types
        End Get
    End Property

    Private _viewAllFilesOption As Boolean
    Public Property ViewAllFilesOption() As Boolean
        Get
            Return _viewAllFilesOption
        End Get
        Set(ByVal value As Boolean)
            _viewAllFilesOption = value
            Me.SetBoolean(Me.GetSectionName(), GeneralSection.Keys.ViewAllFiles, value)
        End Set
    End Property

#End Region


#Region "Properties/Functions: Registry related"

    Private _canAccessRegistry As Boolean
    Public ReadOnly Property CanAccessRegistry() As Boolean
        Get
            Return _canAccessRegistry
        End Get
    End Property

    Private _shellContextMenuText As String
    Public Property ShellContextMenuText() As String
        Get
            Return _shellContextMenuText
        End Get
        Set(ByVal value As String)
            Dim regKey As RegistryKey = Me.GetRegKey()
            If regKey Is Nothing Then regKey = Registry.ClassesRoot.CreateSubKey(RegKeys.FolderActionsPath)
            Dim subKey As RegistryKey = regKey.OpenSubKey(RegKeys.CommandKey, True)
            If subKey Is Nothing Then subKey = regKey.CreateSubKey(RegKeys.CommandKey)
            subKey.SetValue("", Me.CommandLineForRegistry())
            subKey.Close()
            regKey.SetValue("Icon", String.Format("""{0}"",0", Me.ExecutablePath))
            regKey.SetValue("", value)
            _shellContextMenuText = value
            regKey.Close()
        End Set
    End Property

    Public ReadOnly Property IsShellRegistred() As Boolean
        Get
            Return Not String.IsNullOrEmpty(_shellContextMenuText)
        End Get
    End Property

    Public Sub ShellRemove()
        Registry.ClassesRoot.DeleteSubKeyTree(RegKeys.FolderActionsPath)
        _shellContextMenuText = ""
    End Sub

#End Region


#Region "Constructor and Init(ReadFileTypesSection)"

    Public Sub New()
        MyBase.New(GeneralSection.Name)

        Dim section As String = Me.GetSectionName()
        _viewAllFilesOption = Me.GetBoolean(section, GeneralSection.Keys.ViewAllFiles, True)
        _shellContextMenuText = Me.GetShellContextMenuText()
        Me.ReadFileTypesSection()
    End Sub


    Private Sub ReadFileTypesSection()
        Dim section As String = Me.GetSectionName(SectionTypes.Name)
        If Not Me.SectionExists(section) Then
            Dim sep As Char = GlobalData.ExtensionsSeparator.DefSeparator
            Me.SetString(section, "Image", String.Format("jpeg{0}jpg{0}png{0}gif{0}bmp", sep))
            Me.SetString(section, "Music", String.Format("3gp{0}aac{0}amr{0}atrac{0}flac{0}m4a{0}m4p{0}mp3{0}ogg{0}wav{0}wma", sep))
            Me.SetString(section, "Video", String.Format("3gp{0}asf{0}avi{0}cam{0}flv{0}m1v{0}m2v{0}m4v{0}mkv{0}mov{0}mp4{0}mpeg{0}mpg{0}swf{0}wmv", sep))
        End If

        _types.Clear()
        For Each key As String In Me.Keys(section)
            If Not _types.ContainsKey(key) Then
                Dim val As String = Me.GetString(section, key, "", False).ToLower.Trim
                If (val.Length > 0) Then _types(key) = FA.Library.GlobalData.ExtensionsSeparator.Split(val)
            End If
        Next
    End Sub

#End Region


#Region "Private functions"

    Private Function ExecutablePath() As String
        Return Application.ExecutablePath
    End Function

    Private Function CommandLineForRegistry() As String
        Return String.Format("""{0}"" ""%1""", Me.ExecutablePath)
    End Function

    Private Function GetRegKey() As RegistryKey
        Return Registry.ClassesRoot.OpenSubKey(RegKeys.FolderActionsPath, True)
    End Function

    Private Function GetShellContextMenuText() As String
        Try
            Dim testKey As RegistryKey = Registry.ClassesRoot.OpenSubKey(RegKeys.FolderPath, True)
            testKey.Close()
            _canAccessRegistry = True
        Catch ex As Exception
            _canAccessRegistry = False
            Return ""
        End Try

        Dim ctxMenuTxt As String = ""
        Try
            Dim keyFolderActions As RegistryKey = Me.GetRegKey()
            If keyFolderActions IsNot Nothing Then
                ctxMenuTxt = CStr(keyFolderActions.GetValue(""))
                keyFolderActions.Close()
            End If
        Catch ex As Exception
        End Try
        Return ctxMenuTxt
    End Function

#End Region


End Class
