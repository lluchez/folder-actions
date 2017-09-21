<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAppend
    Inherits FA.Library.FrmPluginAbstract

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnRemove = New System.Windows.Forms.Button()
        Me.BtnReverseOrder = New System.Windows.Forms.Button()
        Me.BtnMoveBottom = New System.Windows.Forms.Button()
        Me.BtnMoveDown = New System.Windows.Forms.Button()
        Me.BtnMoveUp = New System.Windows.Forms.Button()
        Me.BtnMoveTop = New System.Windows.Forms.Button()
        Me.LbFiles = New System.Windows.Forms.ListBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.BtnBrowse = New System.Windows.Forms.Button()
        Me.TxtPath = New System.Windows.Forms.TextBox()
        Me.BtnMerge = New System.Windows.Forms.Button()
        Me.TtButtonTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.BtnRemove)
        Me.GroupBox1.Controls.Add(Me.BtnReverseOrder)
        Me.GroupBox1.Controls.Add(Me.BtnMoveBottom)
        Me.GroupBox1.Controls.Add(Me.BtnMoveDown)
        Me.GroupBox1.Controls.Add(Me.BtnMoveUp)
        Me.GroupBox1.Controls.Add(Me.BtnMoveTop)
        Me.GroupBox1.Controls.Add(Me.LbFiles)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(351, 187)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Files"
        '
        'BtnRemove
        '
        Me.BtnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRemove.Image = Global.FA.Plugin.Append.My.Resources.Resources.Remove
        Me.BtnRemove.Location = New System.Drawing.Point(317, 140)
        Me.BtnRemove.Name = "BtnRemove"
        Me.BtnRemove.Size = New System.Drawing.Size(25, 25)
        Me.BtnRemove.TabIndex = 6
        Me.BtnRemove.UseVisualStyleBackColor = True
        '
        'BtnReverseOrder
        '
        Me.BtnReverseOrder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnReverseOrder.Image = Global.FA.Plugin.Append.My.Resources.Resources.Reverse
        Me.BtnReverseOrder.Location = New System.Drawing.Point(317, 68)
        Me.BtnReverseOrder.Name = "BtnReverseOrder"
        Me.BtnReverseOrder.Size = New System.Drawing.Size(25, 25)
        Me.BtnReverseOrder.TabIndex = 3
        Me.BtnReverseOrder.UseVisualStyleBackColor = True
        '
        'BtnMoveBottom
        '
        Me.BtnMoveBottom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnMoveBottom.Image = Global.FA.Plugin.Append.My.Resources.Resources.MoveBottom
        Me.BtnMoveBottom.Location = New System.Drawing.Point(317, 116)
        Me.BtnMoveBottom.Name = "BtnMoveBottom"
        Me.BtnMoveBottom.Size = New System.Drawing.Size(25, 25)
        Me.BtnMoveBottom.TabIndex = 5
        Me.BtnMoveBottom.UseVisualStyleBackColor = True
        '
        'BtnMoveDown
        '
        Me.BtnMoveDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnMoveDown.Image = Global.FA.Plugin.Append.My.Resources.Resources.MoveDown
        Me.BtnMoveDown.Location = New System.Drawing.Point(317, 92)
        Me.BtnMoveDown.Name = "BtnMoveDown"
        Me.BtnMoveDown.Size = New System.Drawing.Size(25, 25)
        Me.BtnMoveDown.TabIndex = 4
        Me.BtnMoveDown.UseVisualStyleBackColor = True
        '
        'BtnMoveUp
        '
        Me.BtnMoveUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnMoveUp.Image = Global.FA.Plugin.Append.My.Resources.Resources.MoveUp
        Me.BtnMoveUp.Location = New System.Drawing.Point(317, 44)
        Me.BtnMoveUp.Name = "BtnMoveUp"
        Me.BtnMoveUp.Size = New System.Drawing.Size(25, 25)
        Me.BtnMoveUp.TabIndex = 2
        Me.BtnMoveUp.UseVisualStyleBackColor = True
        '
        'BtnMoveTop
        '
        Me.BtnMoveTop.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnMoveTop.Image = Global.FA.Plugin.Append.My.Resources.Resources.MoveTop
        Me.BtnMoveTop.Location = New System.Drawing.Point(317, 20)
        Me.BtnMoveTop.Name = "BtnMoveTop"
        Me.BtnMoveTop.Size = New System.Drawing.Size(25, 25)
        Me.BtnMoveTop.TabIndex = 1
        Me.BtnMoveTop.UseVisualStyleBackColor = True
        '
        'LbFiles
        '
        Me.LbFiles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LbFiles.FormattingEnabled = True
        Me.LbFiles.Location = New System.Drawing.Point(9, 19)
        Me.LbFiles.Name = "LbFiles"
        Me.LbFiles.Size = New System.Drawing.Size(302, 147)
        Me.LbFiles.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.BtnBrowse)
        Me.GroupBox2.Controls.Add(Me.TxtPath)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 196)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(351, 49)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Output file"
        '
        'BtnBrowse
        '
        Me.BtnBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBrowse.Location = New System.Drawing.Point(302, 18)
        Me.BtnBrowse.Name = "BtnBrowse"
        Me.BtnBrowse.Size = New System.Drawing.Size(40, 23)
        Me.BtnBrowse.TabIndex = 7
        Me.BtnBrowse.Text = "..."
        Me.BtnBrowse.UseVisualStyleBackColor = True
        '
        'TxtPath
        '
        Me.TxtPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TxtPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem
        Me.TxtPath.Location = New System.Drawing.Point(9, 19)
        Me.TxtPath.Name = "TxtPath"
        Me.TxtPath.Size = New System.Drawing.Size(287, 20)
        Me.TxtPath.TabIndex = 6
        '
        'BtnMerge
        '
        Me.BtnMerge.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnMerge.Enabled = False
        Me.BtnMerge.Image = Global.FA.Plugin.Append.My.Resources.Resources.Merge
        Me.BtnMerge.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnMerge.Location = New System.Drawing.Point(267, 250)
        Me.BtnMerge.Name = "BtnMerge"
        Me.BtnMerge.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.BtnMerge.Size = New System.Drawing.Size(87, 28)
        Me.BtnMerge.TabIndex = 8
        Me.BtnMerge.Text = "Merge files"
        Me.BtnMerge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnMerge.UseVisualStyleBackColor = True
        '
        'TtButtonTip
        '
        Me.TtButtonTip.AutomaticDelay = 200
        Me.TtButtonTip.AutoPopDelay = 20000
        Me.TtButtonTip.InitialDelay = 1000
        Me.TtButtonTip.IsBalloon = True
        Me.TtButtonTip.ReshowDelay = 40
        Me.TtButtonTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.TtButtonTip.ToolTipTitle = "Tip"
        '
        'FrmAppend
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(358, 281)
        Me.Controls.Add(Me.BtnMerge)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrmAppend"
        Me.Text = "FrmAppend"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LbFiles As System.Windows.Forms.ListBox
    Friend WithEvents BtnMoveTop As System.Windows.Forms.Button
    Friend WithEvents BtnMoveBottom As System.Windows.Forms.Button
    Friend WithEvents BtnMoveDown As System.Windows.Forms.Button
    Friend WithEvents BtnMoveUp As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnBrowse As System.Windows.Forms.Button
    Friend WithEvents TxtPath As System.Windows.Forms.TextBox
    Friend WithEvents BtnMerge As System.Windows.Forms.Button
    Friend WithEvents BtnReverseOrder As System.Windows.Forms.Button
    Friend WithEvents TtButtonTip As System.Windows.Forms.ToolTip
    Friend WithEvents BtnRemove As System.Windows.Forms.Button

End Class
