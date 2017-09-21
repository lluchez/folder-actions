<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRename
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
        Me.PctRegexParsing = New System.Windows.Forms.PictureBox()
        Me.PctRegexReplacement = New System.Windows.Forms.PictureBox()
        Me.PctCounterMask = New System.Windows.Forms.PictureBox()
        Me.TxtRegexReplacement = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtRegexParsing = New System.Windows.Forms.TextBox()
        Me.RadioRegex = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NumCounterStep = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NumCounterStartAt = New System.Windows.Forms.NumericUpDown()
        Me.TxtCounterMask = New System.Windows.Forms.TextBox()
        Me.RadioUseCounter = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ChkOverwrite = New System.Windows.Forms.CheckBox()
        Me.ChkStartByEnd = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.LvFiles = New System.Windows.Forms.ListView()
        Me.ChCheck = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ChInName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ChNewName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BtnProcess = New System.Windows.Forms.Button()
        Me.BtnSimulate = New System.Windows.Forms.Button()
        Me.TtListViewError = New System.Windows.Forms.ToolTip(Me.components)
        Me.TtTextboxTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.PctRegexParsing, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PctRegexReplacement, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PctCounterMask, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumCounterStep, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumCounterStartAt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.PctRegexParsing)
        Me.GroupBox1.Controls.Add(Me.PctRegexReplacement)
        Me.GroupBox1.Controls.Add(Me.PctCounterMask)
        Me.GroupBox1.Controls.Add(Me.TxtRegexReplacement)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TxtRegexParsing)
        Me.GroupBox1.Controls.Add(Me.RadioRegex)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.NumCounterStep)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.NumCounterStartAt)
        Me.GroupBox1.Controls.Add(Me.TxtCounterMask)
        Me.GroupBox1.Controls.Add(Me.RadioUseCounter)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(568, 66)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Renaming options"
        '
        'PctRegexParsing
        '
        Me.PctRegexParsing.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PctRegexParsing.Image = Global.FA.Plugin.Rename.My.Resources.Resources.help
        Me.PctRegexParsing.Location = New System.Drawing.Point(268, 43)
        Me.PctRegexParsing.Name = "PctRegexParsing"
        Me.PctRegexParsing.Size = New System.Drawing.Size(16, 16)
        Me.PctRegexParsing.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PctRegexParsing.TabIndex = 12
        Me.PctRegexParsing.TabStop = False
        '
        'PctRegexReplacement
        '
        Me.PctRegexReplacement.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PctRegexReplacement.Image = Global.FA.Plugin.Rename.My.Resources.Resources.help
        Me.PctRegexReplacement.Location = New System.Drawing.Point(546, 43)
        Me.PctRegexReplacement.Name = "PctRegexReplacement"
        Me.PctRegexReplacement.Size = New System.Drawing.Size(16, 16)
        Me.PctRegexReplacement.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PctRegexReplacement.TabIndex = 11
        Me.PctRegexReplacement.TabStop = False
        '
        'PctCounterMask
        '
        Me.PctCounterMask.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PctCounterMask.Image = Global.FA.Plugin.Rename.My.Resources.Resources.help
        Me.PctCounterMask.Location = New System.Drawing.Point(342, 19)
        Me.PctCounterMask.Name = "PctCounterMask"
        Me.PctCounterMask.Size = New System.Drawing.Size(16, 16)
        Me.PctCounterMask.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PctCounterMask.TabIndex = 10
        Me.PctCounterMask.TabStop = False
        '
        'TxtRegexReplacement
        '
        Me.TxtRegexReplacement.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtRegexReplacement.Location = New System.Drawing.Point(367, 41)
        Me.TxtRegexReplacement.Name = "TxtRegexReplacement"
        Me.TxtRegexReplacement.Size = New System.Drawing.Size(179, 20)
        Me.TxtRegexReplacement.TabIndex = 9
        Me.TxtRegexReplacement.Text = "\0"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(288, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Replacement:"
        '
        'TxtRegexParsing
        '
        Me.TxtRegexParsing.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtRegexParsing.Location = New System.Drawing.Point(110, 41)
        Me.TxtRegexParsing.Name = "TxtRegexParsing"
        Me.TxtRegexParsing.Size = New System.Drawing.Size(158, 20)
        Me.TxtRegexParsing.TabIndex = 7
        Me.TxtRegexParsing.Text = "^.*$/i"
        '
        'RadioRegex
        '
        Me.RadioRegex.AutoSize = True
        Me.RadioRegex.Location = New System.Drawing.Point(9, 42)
        Me.RadioRegex.Name = "RadioRegex"
        Me.RadioRegex.Size = New System.Drawing.Size(85, 17)
        Me.RadioRegex.TabIndex = 6
        Me.RadioRegex.Text = "Use a regex:"
        Me.RadioRegex.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(474, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Step:"
        '
        'NumCounterStep
        '
        Me.NumCounterStep.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NumCounterStep.Location = New System.Drawing.Point(512, 18)
        Me.NumCounterStep.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumCounterStep.Name = "NumCounterStep"
        Me.NumCounterStep.Size = New System.Drawing.Size(50, 20)
        Me.NumCounterStep.TabIndex = 4
        Me.NumCounterStep.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(364, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Start at:"
        '
        'NumCounterStartAt
        '
        Me.NumCounterStartAt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NumCounterStartAt.Location = New System.Drawing.Point(418, 18)
        Me.NumCounterStartAt.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.NumCounterStartAt.Name = "NumCounterStartAt"
        Me.NumCounterStartAt.Size = New System.Drawing.Size(50, 20)
        Me.NumCounterStartAt.TabIndex = 2
        Me.NumCounterStartAt.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'TxtCounterMask
        '
        Me.TxtCounterMask.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCounterMask.Location = New System.Drawing.Point(110, 17)
        Me.TxtCounterMask.Name = "TxtCounterMask"
        Me.TxtCounterMask.Size = New System.Drawing.Size(232, 20)
        Me.TxtCounterMask.TabIndex = 1
        Me.TxtCounterMask.Text = "{name}_{num:000}.{ext}"
        '
        'RadioUseCounter
        '
        Me.RadioUseCounter.AutoSize = True
        Me.RadioUseCounter.Checked = True
        Me.RadioUseCounter.Location = New System.Drawing.Point(9, 19)
        Me.RadioUseCounter.Name = "RadioUseCounter"
        Me.RadioUseCounter.Size = New System.Drawing.Size(95, 17)
        Me.RadioUseCounter.TabIndex = 0
        Me.RadioUseCounter.TabStop = True
        Me.RadioUseCounter.Text = "Use a counter:"
        Me.RadioUseCounter.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.ChkOverwrite)
        Me.GroupBox2.Controls.Add(Me.ChkStartByEnd)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 76)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(568, 67)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Other options"
        '
        'ChkOverwrite
        '
        Me.ChkOverwrite.AutoSize = True
        Me.ChkOverwrite.Location = New System.Drawing.Point(9, 43)
        Me.ChkOverwrite.Name = "ChkOverwrite"
        Me.ChkOverwrite.Size = New System.Drawing.Size(239, 17)
        Me.ChkOverwrite.TabIndex = 1
        Me.ChkOverwrite.Text = "Overwrite (if the destination file already exists)"
        Me.ChkOverwrite.UseVisualStyleBackColor = True
        '
        'ChkStartByEnd
        '
        Me.ChkStartByEnd.AutoSize = True
        Me.ChkStartByEnd.Location = New System.Drawing.Point(9, 20)
        Me.ChkStartByEnd.Name = "ChkStartByEnd"
        Me.ChkStartByEnd.Size = New System.Drawing.Size(168, 17)
        Me.ChkStartByEnd.TabIndex = 0
        Me.ChkStartByEnd.Text = "Reversed (start by the last file)"
        Me.ChkStartByEnd.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.LvFiles)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 149)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(568, 174)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Files"
        '
        'LvFiles
        '
        Me.LvFiles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LvFiles.CheckBoxes = True
        Me.LvFiles.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ChCheck, Me.ChInName, Me.ChNewName})
        Me.LvFiles.FullRowSelect = True
        Me.LvFiles.GridLines = True
        Me.LvFiles.Location = New System.Drawing.Point(7, 19)
        Me.LvFiles.Name = "LvFiles"
        Me.LvFiles.Size = New System.Drawing.Size(554, 149)
        Me.LvFiles.TabIndex = 1
        Me.LvFiles.UseCompatibleStateImageBehavior = False
        Me.LvFiles.View = System.Windows.Forms.View.Details
        '
        'ChCheck
        '
        Me.ChCheck.Text = ""
        Me.ChCheck.Width = 20
        '
        'ChInName
        '
        Me.ChInName.Text = "Original file name"
        Me.ChInName.Width = 272
        '
        'ChNewName
        '
        Me.ChNewName.Text = "New file name"
        Me.ChNewName.Width = 257
        '
        'BtnProcess
        '
        Me.BtnProcess.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnProcess.Image = Global.FA.Plugin.Rename.My.Resources.Resources.start
        Me.BtnProcess.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnProcess.Location = New System.Drawing.Point(470, 329)
        Me.BtnProcess.Name = "BtnProcess"
        Me.BtnProcess.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.BtnProcess.Size = New System.Drawing.Size(95, 28)
        Me.BtnProcess.TabIndex = 3
        Me.BtnProcess.Text = "Rename files"
        Me.BtnProcess.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnProcess.UseVisualStyleBackColor = True
        '
        'BtnSimulate
        '
        Me.BtnSimulate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSimulate.Image = Global.FA.Plugin.Rename.My.Resources.Resources.Simulate
        Me.BtnSimulate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSimulate.Location = New System.Drawing.Point(390, 329)
        Me.BtnSimulate.Name = "BtnSimulate"
        Me.BtnSimulate.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.BtnSimulate.Size = New System.Drawing.Size(74, 28)
        Me.BtnSimulate.TabIndex = 4
        Me.BtnSimulate.Text = "Simulate"
        Me.BtnSimulate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSimulate.UseVisualStyleBackColor = True
        '
        'TtListViewError
        '
        Me.TtListViewError.AutoPopDelay = 5000
        Me.TtListViewError.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.TtListViewError.InitialDelay = 200
        Me.TtListViewError.IsBalloon = True
        Me.TtListViewError.ReshowDelay = 100
        Me.TtListViewError.ToolTipIcon = System.Windows.Forms.ToolTipIcon.[Error]
        Me.TtListViewError.ToolTipTitle = "Error"
        '
        'TtTextboxTip
        '
        Me.TtTextboxTip.AutomaticDelay = 200
        Me.TtTextboxTip.AutoPopDelay = 20000
        Me.TtTextboxTip.InitialDelay = 200
        Me.TtTextboxTip.IsBalloon = True
        Me.TtTextboxTip.ReshowDelay = 40
        Me.TtTextboxTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.TtTextboxTip.ToolTipTitle = "Tip"
        '
        'FrmRename
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(573, 361)
        Me.Controls.Add(Me.BtnSimulate)
        Me.Controls.Add(Me.BtnProcess)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrmRename"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PctRegexParsing, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PctRegexReplacement, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PctCounterMask, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumCounterStep, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumCounterStartAt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtCounterMask As System.Windows.Forms.TextBox
    Friend WithEvents RadioUseCounter As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NumCounterStep As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NumCounterStartAt As System.Windows.Forms.NumericUpDown
    Friend WithEvents RadioRegex As System.Windows.Forms.RadioButton
    Friend WithEvents TxtRegexReplacement As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtRegexParsing As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkStartByEnd As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents LvFiles As System.Windows.Forms.ListView
    Friend WithEvents ChCheck As System.Windows.Forms.ColumnHeader
    Friend WithEvents ChInName As System.Windows.Forms.ColumnHeader
    Friend WithEvents ChNewName As System.Windows.Forms.ColumnHeader
    Friend WithEvents BtnProcess As System.Windows.Forms.Button
    Friend WithEvents BtnSimulate As System.Windows.Forms.Button
    Friend WithEvents TtListViewError As System.Windows.Forms.ToolTip
    Friend WithEvents ChkOverwrite As System.Windows.Forms.CheckBox
    Friend WithEvents TtTextboxTip As System.Windows.Forms.ToolTip
    Friend WithEvents PctRegexReplacement As System.Windows.Forms.PictureBox
    Friend WithEvents PctCounterMask As System.Windows.Forms.PictureBox
    Friend WithEvents PctRegexParsing As System.Windows.Forms.PictureBox

End Class
