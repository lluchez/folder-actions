
Public Class ResizingModes


#Region "Enums and Members"

    Enum Modes
        [Default]
        Low
        High
        Bilinear
        Bicubic
        NearestNeighbor
        HighQualityBilinear
        HighQualityBicubic
    End Enum

    Public Shared Names() As String = New String() {"Default", "Low", "High", "Bilinear", "Bicubic", "Nearest Neighbor", "High Quality Bilinear", "High Quality Bicubic"}

    Public Const DefaultMethod As Modes = Modes.Default

#End Region


#Region "Public Shared Functions/Properties"

    Public Shared ReadOnly Property DefaultMethodName() As String
        Get
            Return Names(DefaultMethod)
        End Get
    End Property

    Public Shared Function GetModeName(ByVal mode As Modes) As String
        Return GetModeName(CInt(mode))
    End Function

    Public Shared Function GetModeName(ByVal modeIndex As Integer) As String
        Return Names(modeIndex)
    End Function

    Public Shared Function GetInterpolationMode(ByVal mode As Modes) As Drawing2D.InterpolationMode
        Select Case mode
            Case Modes.Low : Return Drawing2D.InterpolationMode.Low
            Case Modes.High : Return Drawing2D.InterpolationMode.High
            Case Modes.Bilinear : Return Drawing2D.InterpolationMode.Bilinear
            Case Modes.Bicubic : Return Drawing2D.InterpolationMode.Bicubic
            Case Modes.NearestNeighbor : Return Drawing2D.InterpolationMode.NearestNeighbor
            Case Modes.HighQualityBilinear : Return Drawing2D.InterpolationMode.HighQualityBilinear
            Case Modes.HighQualityBicubic : Return Drawing2D.InterpolationMode.HighQualityBicubic
            Case Else : Return Drawing2D.InterpolationMode.Default
        End Select
    End Function

    Public Shared Function GetInterpolationMode(ByVal modeIndex As Integer) As Drawing2D.InterpolationMode
        Return GetInterpolationMode(CType(modeIndex, Modes))
    End Function

    Public Shared Function GetInterpolationMode(ByVal mode As String) As Drawing2D.InterpolationMode
        Return GetInterpolationMode(GetMode(mode))
    End Function

    Public Shared Function GetMode(ByVal mode As String) As Modes
        Dim index As Integer = Names.ToList().IndexOf(mode)
        Return GetMode(index)
    End Function

    Public Shared Function GetMode(ByVal modeIndex As Integer) As Modes
        If modeIndex < 0 Then Return DefaultMethod
        Return CType(modeIndex, Modes)
    End Function

#End Region


End Class
