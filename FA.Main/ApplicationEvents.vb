Namespace My

    Partial Friend Class MyApplication


#Region "Properties"

        Public Const APP_NAME As String = "Folder Actions"
        Public ReadOnly Property ApplicationName() As String
            Get
                Return APP_NAME
            End Get
        End Property

#End Region


#Region "Events"

        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            FA.Library.MsgBox.AppName = APP_NAME
        End Sub

        Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            FA.Library.MsgBox.Error("An unexpected error happened!", e.Exception)
        End Sub

#End Region


    End Class

End Namespace

