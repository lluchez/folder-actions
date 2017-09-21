Imports System.Text.RegularExpressions
Imports System.Text
Imports System.Runtime.InteropServices



Public Class IniReader


#Region "Imports API functions (from kernel32.dll)"

    Private Declare Ansi Function GetPrivateProfileString Lib "kernel32.dll" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As StringBuilder, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    Private Declare Ansi Function GetPrivateProfileString Lib "kernel32.dll" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    Private Declare Ansi Function GetPrivateProfileSection Lib "kernel32.dll" Alias "GetPrivateProfileSectionA" (ByVal lpApplicationName As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    Private Declare Ansi Function WritePrivateProfileString Lib "kernel32.dll" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer
    Private Declare Ansi Function FlushPrivateProfileString Lib "kernel32.dll" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As Integer, ByVal lpKeyName As Integer, ByVal lpString As Integer, ByVal lpFileName As String) As Integer
    Private Declare Ansi Function FlushPrivateProfileString Lib "kernel32.dll" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As Integer, ByVal lpFileName As String) As Integer

#End Region


#Region "Properties and Constants"

    Private _alreadyExists As Boolean
    Private ReadOnly _lock As New Object()
    Protected _filename As String
    Protected ReadOnly Property FileName() As String
        Get
            Return _filename
        End Get
    End Property

#End Region


#Region "Constructors"

    Public Sub New(ByVal filename As String)
        If Not IO.Path.IsPathRooted(filename) Then
            filename = IO.Path.Combine(My.Application.Info.DirectoryPath, filename)
        End If
        Dim fi As IO.FileInfo = Nothing
        Try
            fi = New IO.FileInfo(filename)
        Catch ex As Exception
            Throw New Exception(String.Format("Invalid config file path: '{0}'", filename), ex)
        End Try
        Me.Init(fi)
    End Sub

    Public Sub New(ByVal fi As IO.FileInfo)
        Me.Init(fi)
    End Sub

    Protected Sub Init(ByVal fi As IO.FileInfo)
        Try
            _filename = fi.FullName
            _alreadyExists = fi.Exists
            If Not fi.Exists Then
                Using s As IO.FileStream = fi.Create()
                End Using
            End If
        Catch ex As Exception
            Throw New Exception(String.Format("Unable to access to the config file: '{0}'", fi.FullName), ex)
        End Try
    End Sub

#End Region


#Region "GetValue functions"

    Protected Function GetString(ByVal pSection As String, ByVal pKey As String, Optional ByVal defValue As String = "", Optional ByVal write As Boolean = True) As String
        SyncLock _lock
            Dim value As String = Nothing
            If Me.KeyExists(pSection, pKey, value) Then
                Return value
            End If
            If write Then Me.SetString(pSection, pKey, defValue)
            Return defValue
        End SyncLock
    End Function

    Protected Function GetBoolean(ByVal section As String, ByVal key As String, Optional ByVal defValue As Boolean = False, Optional ByVal write As Boolean = True) As Boolean
        SyncLock _lock
            Dim value As String = Nothing, _
                    sValue As String = BooleanManager.ToString(defValue), _
                    bValue As Boolean = False
            If Me.KeyExists(section, key, value) AndAlso BooleanManager.TryParse(value, bValue) Then Return bValue
            If write Then Me.SetString(section, key, sValue)
            Return defValue
        End SyncLock
    End Function

    Protected Function GetInteger(ByVal section As String, ByVal key As String, Optional ByVal defValue As Integer = 0, Optional ByVal write As Boolean = True) As Integer
        SyncLock _lock
            Dim value As String = Nothing, _
                    sValue As String = IntegerManager.ToString(defValue), _
                    iValue As Integer = 0
            If Me.KeyExists(section, key, value) AndAlso IntegerManager.TryParse(value, iValue) Then Return iValue
            If write Then Me.SetString(section, key, sValue)
            Return defValue
        End SyncLock
    End Function

#End Region


#Region "SetValue functions"

    Protected Sub SetString(ByVal section As String, ByVal key As String, ByVal value As String)
        SyncLock _lock
            If value Is Nothing Then value = String.Empty
            WritePrivateProfileString(section, key, value, _filename)
            Me.Flush()
        End SyncLock
    End Sub

    Protected Sub SetInteger(ByVal section As String, ByVal key As String, ByVal value As Integer)
        SyncLock _lock
            Me.SetString(section, key, IntegerManager.ToString(value))
        End SyncLock
    End Sub

    Protected Sub SetBoolean(ByVal section As String, ByVal key As String, ByVal value As Boolean)
        SyncLock _lock
            Me.SetString(section, key, BooleanManager.ToString(value))
        End SyncLock
    End Sub

#End Region


#Region "KeyExists and SectionExists"

    Protected Function KeyExists(ByVal section As String, ByVal pKey As String, Optional ByRef outValue As String = Nothing) As Boolean
        SyncLock _lock
            Dim testValue As String = "###--TEST_KEY_EXISTS--###"
            Dim buffer As New StringBuilder(256)
            Dim nbCharCount As Integer = GetPrivateProfileString(section, pKey, testValue, buffer, buffer.Capacity, _filename)
            outValue = buffer.ToString.Substring(0, nbCharCount)
            Return (outValue <> testValue)
        End SyncLock
    End Function

    Protected Function SectionExists(ByVal section As String) As Boolean
        SyncLock _lock
            Dim value = Me.GetPrivateProfileString(section, Nothing, Nothing)
            Return (value <> "")
            Return False
        End SyncLock
    End Function

#End Region


#Region "Properties Sections and Keys"

    Protected ReadOnly Property Sections() As List(Of String)
        Get
            Return Me.GetListOfObjects(Nothing)
        End Get
    End Property

    Protected ReadOnly Property Keys(ByVal section As String) As List(Of String)
        Get
            Return Me.GetListOfObjects(section)
        End Get
    End Property

#End Region


#Region "Functions: DelectSection/DeleteKeys"

    Protected Sub DeleteSection(ByVal section As String)
        FlushPrivateProfileString(section, Nothing, 0, _filename)
    End Sub

    Protected Sub DeleteKey(ByVal section As String, ByVal key As String)
        FlushPrivateProfileString(section, key, 0, _filename)
    End Sub

#End Region


#Region "Private functions"

    Private Sub Flush()
        FlushPrivateProfileString(0, 0, 0, _filename) '** Stores all the cached changes to your INI file
    End Sub

    Private Function CreateBuffer() As String
        Return New String(" "c, CInt(New IO.FileInfo(Me.FileName).Length + 100))
    End Function

    Private Function GetListOfObjects(ByVal section As String) As List(Of String)
        Dim results As New List(Of String)(Me.GetPrivateProfileString(section, Nothing, Nothing).Split(Chr(0)))
        Return results
    End Function

    Private Function GetPrivateProfileString(ByVal section As String, ByVal key As String, ByVal value As String) As String
        Dim buffer As String = Me.CreateBuffer()
        Dim nbCharCount As Integer = GetPrivateProfileString(section, key, value, buffer, buffer.Length, _filename)
        If nbCharCount = 0 Then Return ""
        Return buffer.Substring(0, nbCharCount - 1)
    End Function

#End Region


End Class
