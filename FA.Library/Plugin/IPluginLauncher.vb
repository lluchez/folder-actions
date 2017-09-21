
Public Interface IPluginLauncher
    ReadOnly Property ID() As String
    ReadOnly Property Name() As String
    ReadOnly Property Icon() As Drawing.Icon
    Sub ShowForm(ByVal files As List(Of FileInfoX))
End Interface
