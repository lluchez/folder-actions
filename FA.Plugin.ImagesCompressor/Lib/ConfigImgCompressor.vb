Imports FA.Library


Public Class ConfigImgCompressor
    Inherits FA.Library.ConfigPluginAbstract


#Region "Constants"

    Private Class PluginSection
        Public Class Keys
            Public Const JpegCompression As String = "JpegCompression"
            Public Const ResizingRatio As String = "ResizingRatio"
            Public Const InterpolationMode As String = "InterpolationMode"
            Public Const ParallelThreads As String = "ParallelThreads"
            Public Const EnableParallelProcessing As String = "EnableParallelProcessing"
        End Class
    End Class

    Public Const DEFAULT_SIZE As String = "100% (no resize)"

#End Region


#Region "Properties"

    Private _jpegCompression As Integer
    Public Property JpegCompression() As Integer
        Get
            Return _jpegCompression
        End Get
        Set(ByVal value As Integer)
            _jpegCompression = value
            Me.SetInteger(Me.GetSectionName(), PluginSection.Keys.JpegCompression, value)
        End Set
    End Property

    Private _resizingRatio As String
    Public Property ResizingRatio() As String
        Get
            Return _resizingRatio
        End Get
        Set(ByVal value As String)
            _resizingRatio = value
            Me.SetString(Me.GetSectionName(), PluginSection.Keys.ResizingRatio, value)
        End Set
    End Property

    Private _interpolationMode As ResizingModes.Modes
    Public Property InterpolationMode() As ResizingModes.Modes
        Get
            Return _interpolationMode
        End Get
        Set(ByVal value As ResizingModes.Modes)
            _interpolationMode = value
            Me.SetString(Me.GetSectionName(), PluginSection.Keys.InterpolationMode, ResizingModes.GetModeName(value))
        End Set
    End Property

    Private _parallelThreads As Integer
    Public Property ParallelThreads() As Integer
        Get
            Return _parallelThreads
        End Get
        Set(ByVal value As Integer)
            _parallelThreads = value
            Me.SetInteger(Me.GetSectionName(), PluginSection.Keys.ParallelThreads, value)
        End Set
    End Property

    Private _enableParallelProcessing As Boolean
    Public Property EnableParallelProcessing() As Boolean
        Get
            Return _enableParallelProcessing
        End Get
        Set(ByVal value As Boolean)
            _enableParallelProcessing = value
            Me.SetBoolean(Me.GetSectionName(), PluginSection.Keys.EnableParallelProcessing, value)
        End Set
    End Property


#End Region


#Region "Constructor"

    Public Sub New(ByVal plugin As FrmPluginAbstract)
        MyBase.New(plugin)

        Dim section As String = Me.GetSectionName()
        _jpegCompression = Me.GetInteger(section, PluginSection.Keys.JpegCompression, 100)
        _resizingRatio = Me.GetString(section, PluginSection.Keys.ResizingRatio, DEFAULT_SIZE)
        _interpolationMode = ResizingModes.GetMode(Me.GetString(section, PluginSection.Keys.InterpolationMode, ResizingModes.DefaultMethodName))
        _parallelThreads = Me.GetInteger(section, PluginSection.Keys.ParallelThreads, Environment.ProcessorCount)
        _enableParallelProcessing = Me.GetBoolean(section, PluginSection.Keys.EnableParallelProcessing, True)
    End Sub

#End Region


End Class
