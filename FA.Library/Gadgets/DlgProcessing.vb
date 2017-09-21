Imports System.Windows.Forms

Public Class DlgProcessing


#Region "Properties"

    Private _aborted As Boolean = False
    Private _elapsedSeconds As Integer = 0, _elapsedMinutes As Integer = 0

    Private _titleMask As String = "Processing"
    Public WriteOnly Property TitleMask As String
        Set(value As String)
            Me.Text = value
            _titleMask = value & " - {0}/{1}"
        End Set
    End Property

    Private _abortConfirmMsg As String = "Are you sure to abort this process ?"
    Public WriteOnly Property AbortConfirmationMessage As String
        Set(value As String)
            _abortConfirmMsg = value
        End Set
    End Property

#End Region


#Region "Events"

    Private Sub BtnCancel_Click(sender As System.Object, e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub FrmLoadThumbnails_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            If (Not _aborted) And (Me.ProgressBar.Value <> Me.ProgressBar.Maximum) Then
                If FA.Library.MsgBox.AlertYesNo(_abortConfirmMsg) = DialogResult.No Then
                    e.Cancel = True
                    Exit Sub
                End If
                Me.DialogResult = Windows.Forms.DialogResult.Abort
            Else
                Me.DialogResult = Windows.Forms.DialogResult.OK
            End If
        End If
        Me.TmrElapsedTime.Stop()
    End Sub

    Private Sub DlgProcessing_ResizeEnd(sender As Object, e As System.EventArgs) Handles Me.Shown
        Me.TmrElapsedTime.Start()
    End Sub

    Private Sub TmrElapsedTime_Tick(sender As Object, e As System.EventArgs) Handles TmrElapsedTime.Tick
        _elapsedSeconds += 1
        If _elapsedSeconds = 60 Then
            _elapsedSeconds = 0
            _elapsedMinutes += 1
        End If
        Me.UpdateElapsedTimeLabel()
    End Sub

#End Region


#Region "Constructor and Init"

    Public Sub New()
        Me.InitializeComponent()
        Me.UpdateElapsedTimeLabel()
    End Sub

    Protected Sub Init(titleMask As String, Optional abordConfirmMessage As String = Nothing, Optional ico As System.Drawing.Icon = Nothing)
        Me.TitleMask = titleMask
        If (abordConfirmMessage IsNot Nothing) Then Me.AbortConfirmationMessage = abordConfirmMessage
        If (ico IsNot Nothing) Then Me.Icon = ico
        Me.UpdateTitle()
    End Sub

    Public Sub Init(max As Integer, titleMask As String, Optional abordConfirmMessage As String = Nothing, Optional ico As System.Drawing.Icon = Nothing)
        Me.Init(max)
        Me.Init(titleMask, abordConfirmMessage, ico)
    End Sub


    Public Sub Init(max As Integer)
        Me.ProgressBar.Value = 0
        Me.ProgressBar.Maximum = max
        Me.UpdateTitle()
    End Sub

#End Region


#Region "Other functions"

    Private Sub UpdateTitle()
        Me.Text = String.Format(_titleMask, Me.ProgressBar.Value, Me.ProgressBar.Maximum)
    End Sub

    Public Sub NotifyItemProcessed()
        Me.ProgressBar.Value += 1
        Me.UpdateTitle()
        If Me.ProgressBar.Value = Me.ProgressBar.Maximum Then
            Me.Close()
        End If
    End Sub

    Private Sub UpdateElapsedTimeLabel()
        Me.LblElapsedTime.Text = String.Format("{0}min{1:00}", _elapsedMinutes, _elapsedSeconds)
    End Sub

    Public Sub Abort()
        If _aborted Then Return
        _aborted = True
        Me.Close()
    End Sub

#End Region


End Class
