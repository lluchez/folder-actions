Imports FA.Library

Public Class DlgThumbsLoader
    Inherits DlgProcessing

    Public Sub New()
        MyBase.New()
        Me.Init("Loading Thumbnails", "Are you sure to aboard this process ?", My.Resources.Thumbnails)
    End Sub

End Class
