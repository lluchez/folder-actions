<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImgCompressor
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
        Me.GrpEncoding = New System.Windows.Forms.GroupBox()
        Me.PanelInterpolationMode = New System.Windows.Forms.Panel()
        Me.CmbResizeMethod = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PanelJpeqQuality = New System.Windows.Forms.Panel()
        Me.LblCompression = New System.Windows.Forms.Label()
        Me.TrbCompression = New System.Windows.Forms.TrackBar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CmbSize = New System.Windows.Forms.ComboBox()
        Me.CmbFormat = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ChkOverwrite = New System.Windows.Forms.CheckBox()
        Me.ChkDeleteOrignal = New System.Windows.Forms.CheckBox()
        Me.BtnBrowse = New System.Windows.Forms.Button()
        Me.TxtPath = New System.Windows.Forms.TextBox()
        Me.ChkMoveTo = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.NumCounterStartAt = New System.Windows.Forms.NumericUpDown()
        Me.PctRenameMask = New System.Windows.Forms.PictureBox()
        Me.TxtRenameMask = New System.Windows.Forms.TextBox()
        Me.ChkRename = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.PanelParallelProcessing = New System.Windows.Forms.Panel()
        Me.LlbCpuCores = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CmbNbThreads = New System.Windows.Forms.ComboBox()
        Me.ChkKeepExif = New System.Windows.Forms.CheckBox()
        Me.ChkParallelProcessing = New System.Windows.Forms.CheckBox()
        Me.ChkKeepDate = New System.Windows.Forms.CheckBox()
        Me.GrpFiles = New System.Windows.Forms.GroupBox()
        Me.LvFiles = New System.Windows.Forms.ListView()
        Me.ChName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ChSize = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ChCompression = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TtTextboxTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.BtnProcess = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LblTotalSize = New System.Windows.Forms.Label()
        Me.LblAverageCompression = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.TtSaveBtnTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.GrpEncoding.SuspendLayout()
        Me.PanelInterpolationMode.SuspendLayout()
        Me.PanelJpeqQuality.SuspendLayout()
        CType(Me.TrbCompression, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.NumCounterStartAt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PctRenameMask, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.PanelParallelProcessing.SuspendLayout()
        Me.GrpFiles.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpEncoding
        '
        Me.GrpEncoding.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpEncoding.Controls.Add(Me.PanelInterpolationMode)
        Me.GrpEncoding.Controls.Add(Me.PanelJpeqQuality)
        Me.GrpEncoding.Controls.Add(Me.CmbSize)
        Me.GrpEncoding.Controls.Add(Me.CmbFormat)
        Me.GrpEncoding.Controls.Add(Me.Label4)
        Me.GrpEncoding.Controls.Add(Me.Label1)
        Me.GrpEncoding.Location = New System.Drawing.Point(3, 2)
        Me.GrpEncoding.Name = "GrpEncoding"
        Me.GrpEncoding.Size = New System.Drawing.Size(487, 74)
        Me.GrpEncoding.TabIndex = 0
        Me.GrpEncoding.TabStop = False
        Me.GrpEncoding.Text = "Encoding and resizing"
        '
        'PanelInterpolationMode
        '
        Me.PanelInterpolationMode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelInterpolationMode.Controls.Add(Me.CmbResizeMethod)
        Me.PanelInterpolationMode.Controls.Add(Me.Label3)
        Me.PanelInterpolationMode.Enabled = False
        Me.PanelInterpolationMode.Location = New System.Drawing.Point(153, 40)
        Me.PanelInterpolationMode.Name = "PanelInterpolationMode"
        Me.PanelInterpolationMode.Size = New System.Drawing.Size(327, 32)
        Me.PanelInterpolationMode.TabIndex = 2
        '
        'CmbResizeMethod
        '
        Me.CmbResizeMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbResizeMethod.FormattingEnabled = True
        Me.CmbResizeMethod.Location = New System.Drawing.Point(112, 8)
        Me.CmbResizeMethod.Name = "CmbResizeMethod"
        Me.CmbResizeMethod.Size = New System.Drawing.Size(135, 21)
        Me.CmbResizeMethod.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Interpolation mode:"
        '
        'PanelJpeqQuality
        '
        Me.PanelJpeqQuality.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelJpeqQuality.Controls.Add(Me.LblCompression)
        Me.PanelJpeqQuality.Controls.Add(Me.TrbCompression)
        Me.PanelJpeqQuality.Controls.Add(Me.Label2)
        Me.PanelJpeqQuality.Location = New System.Drawing.Point(153, 10)
        Me.PanelJpeqQuality.Name = "PanelJpeqQuality"
        Me.PanelJpeqQuality.Size = New System.Drawing.Size(327, 32)
        Me.PanelJpeqQuality.TabIndex = 2
        '
        'LblCompression
        '
        Me.LblCompression.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblCompression.Location = New System.Drawing.Point(302, 11)
        Me.LblCompression.Name = "LblCompression"
        Me.LblCompression.Size = New System.Drawing.Size(25, 20)
        Me.LblCompression.TabIndex = 3
        Me.LblCompression.Text = "100"
        Me.LblCompression.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TrbCompression
        '
        Me.TrbCompression.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TrbCompression.AutoSize = False
        Me.TrbCompression.LargeChange = 10
        Me.TrbCompression.Location = New System.Drawing.Point(75, 3)
        Me.TrbCompression.Maximum = 100
        Me.TrbCompression.Name = "TrbCompression"
        Me.TrbCompression.Size = New System.Drawing.Size(226, 27)
        Me.TrbCompression.SmallChange = 5
        Me.TrbCompression.TabIndex = 2
        Me.TrbCompression.TickFrequency = 10
        Me.TrbCompression.Value = 100
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Jpeg quality:"
        '
        'CmbSize
        '
        Me.CmbSize.FormattingEnabled = True
        Me.CmbSize.Location = New System.Drawing.Point(45, 48)
        Me.CmbSize.Name = "CmbSize"
        Me.CmbSize.Size = New System.Drawing.Size(105, 21)
        Me.CmbSize.TabIndex = 1
        '
        'CmbFormat
        '
        Me.CmbFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbFormat.FormattingEnabled = True
        Me.CmbFormat.Location = New System.Drawing.Point(57, 17)
        Me.CmbFormat.Name = "CmbFormat"
        Me.CmbFormat.Size = New System.Drawing.Size(93, 21)
        Me.CmbFormat.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Size:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Format:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.ChkOverwrite)
        Me.GroupBox3.Controls.Add(Me.ChkDeleteOrignal)
        Me.GroupBox3.Controls.Add(Me.BtnBrowse)
        Me.GroupBox3.Controls.Add(Me.TxtPath)
        Me.GroupBox3.Controls.Add(Me.ChkMoveTo)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.NumCounterStartAt)
        Me.GroupBox3.Controls.Add(Me.PctRenameMask)
        Me.GroupBox3.Controls.Add(Me.TxtRenameMask)
        Me.GroupBox3.Controls.Add(Me.ChkRename)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 82)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(487, 110)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Renaming"
        '
        'ChkOverwrite
        '
        Me.ChkOverwrite.AutoSize = True
        Me.ChkOverwrite.Location = New System.Drawing.Point(12, 87)
        Me.ChkOverwrite.Name = "ChkOverwrite"
        Me.ChkOverwrite.Size = New System.Drawing.Size(282, 17)
        Me.ChkOverwrite.TabIndex = 20
        Me.ChkOverwrite.Text = "Overwrite existing files (will stop the process otherwise)"
        Me.ChkOverwrite.UseVisualStyleBackColor = True
        '
        'ChkDeleteOrignal
        '
        Me.ChkDeleteOrignal.AutoSize = True
        Me.ChkDeleteOrignal.Enabled = False
        Me.ChkDeleteOrignal.Location = New System.Drawing.Point(12, 66)
        Me.ChkDeleteOrignal.Name = "ChkDeleteOrignal"
        Me.ChkDeleteOrignal.Size = New System.Drawing.Size(470, 17)
        Me.ChkDeleteOrignal.TabIndex = 19
        Me.ChkDeleteOrignal.Text = "Delete the original image (if new file path/name/extension is different). Will be" & _
    " done at the end."
        Me.ChkDeleteOrignal.UseVisualStyleBackColor = True
        '
        'BtnBrowse
        '
        Me.BtnBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBrowse.Location = New System.Drawing.Point(450, 39)
        Me.BtnBrowse.Name = "BtnBrowse"
        Me.BtnBrowse.Size = New System.Drawing.Size(31, 23)
        Me.BtnBrowse.TabIndex = 18
        Me.BtnBrowse.Text = "..."
        Me.BtnBrowse.UseVisualStyleBackColor = True
        '
        'TxtPath
        '
        Me.TxtPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TxtPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem
        Me.TxtPath.Location = New System.Drawing.Point(101, 41)
        Me.TxtPath.Name = "TxtPath"
        Me.TxtPath.Size = New System.Drawing.Size(343, 20)
        Me.TxtPath.TabIndex = 17
        '
        'ChkMoveTo
        '
        Me.ChkMoveTo.AutoSize = True
        Me.ChkMoveTo.Location = New System.Drawing.Point(12, 43)
        Me.ChkMoveTo.Name = "ChkMoveTo"
        Me.ChkMoveTo.Size = New System.Drawing.Size(68, 17)
        Me.ChkMoveTo.TabIndex = 16
        Me.ChkMoveTo.Text = "Move to:"
        Me.ChkMoveTo.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(337, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Counter starts at:"
        '
        'NumCounterStartAt
        '
        Me.NumCounterStartAt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NumCounterStartAt.Location = New System.Drawing.Point(430, 19)
        Me.NumCounterStartAt.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.NumCounterStartAt.Name = "NumCounterStartAt"
        Me.NumCounterStartAt.Size = New System.Drawing.Size(50, 20)
        Me.NumCounterStartAt.TabIndex = 14
        Me.NumCounterStartAt.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'PctRenameMask
        '
        Me.PctRenameMask.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PctRenameMask.Image = Global.FA.Plugin.ImagesCompressor.My.Resources.Resources.help
        Me.PctRenameMask.Location = New System.Drawing.Point(314, 19)
        Me.PctRenameMask.Name = "PctRenameMask"
        Me.PctRenameMask.Size = New System.Drawing.Size(16, 16)
        Me.PctRenameMask.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PctRenameMask.TabIndex = 13
        Me.PctRenameMask.TabStop = False
        '
        'TxtRenameMask
        '
        Me.TxtRenameMask.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtRenameMask.Location = New System.Drawing.Point(101, 17)
        Me.TxtRenameMask.Name = "TxtRenameMask"
        Me.TxtRenameMask.Size = New System.Drawing.Size(212, 20)
        Me.TxtRenameMask.TabIndex = 1
        '
        'ChkRename
        '
        Me.ChkRename.AutoSize = True
        Me.ChkRename.Location = New System.Drawing.Point(12, 20)
        Me.ChkRename.Name = "ChkRename"
        Me.ChkRename.Size = New System.Drawing.Size(83, 17)
        Me.ChkRename.TabIndex = 0
        Me.ChkRename.Text = "Rename as:"
        Me.ChkRename.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.PanelParallelProcessing)
        Me.GroupBox4.Controls.Add(Me.ChkKeepExif)
        Me.GroupBox4.Controls.Add(Me.ChkParallelProcessing)
        Me.GroupBox4.Controls.Add(Me.ChkKeepDate)
        Me.GroupBox4.Location = New System.Drawing.Point(3, 198)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(487, 89)
        Me.GroupBox4.TabIndex = 5
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Other options"
        '
        'PanelParallelProcessing
        '
        Me.PanelParallelProcessing.Controls.Add(Me.LlbCpuCores)
        Me.PanelParallelProcessing.Controls.Add(Me.Label7)
        Me.PanelParallelProcessing.Controls.Add(Me.Label6)
        Me.PanelParallelProcessing.Controls.Add(Me.CmbNbThreads)
        Me.PanelParallelProcessing.Enabled = False
        Me.PanelParallelProcessing.Location = New System.Drawing.Point(198, 60)
        Me.PanelParallelProcessing.Name = "PanelParallelProcessing"
        Me.PanelParallelProcessing.Size = New System.Drawing.Size(280, 26)
        Me.PanelParallelProcessing.TabIndex = 28
        '
        'LlbCpuCores
        '
        Me.LlbCpuCores.AutoSize = True
        Me.LlbCpuCores.Location = New System.Drawing.Point(259, 6)
        Me.LlbCpuCores.Name = "LlbCpuCores"
        Me.LlbCpuCores.Size = New System.Drawing.Size(13, 13)
        Me.LlbCpuCores.TabIndex = 26
        Me.LlbCpuCores.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(194, 6)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "CPU Cores:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 13)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Parallel threads:"
        '
        'CmbNbThreads
        '
        Me.CmbNbThreads.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbNbThreads.FormattingEnabled = True
        Me.CmbNbThreads.Location = New System.Drawing.Point(103, 3)
        Me.CmbNbThreads.Name = "CmbNbThreads"
        Me.CmbNbThreads.Size = New System.Drawing.Size(56, 21)
        Me.CmbNbThreads.TabIndex = 24
        '
        'ChkKeepExif
        '
        Me.ChkKeepExif.AutoSize = True
        Me.ChkKeepExif.Checked = True
        Me.ChkKeepExif.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkKeepExif.Location = New System.Drawing.Point(9, 42)
        Me.ChkKeepExif.Name = "ChkKeepExif"
        Me.ChkKeepExif.Size = New System.Drawing.Size(388, 17)
        Me.ChkKeepExif.TabIndex = 21
        Me.ChkKeepExif.Text = "Preserve the EXIF data (copy image metadata, like camera name, focal, ISO)"
        Me.ChkKeepExif.UseVisualStyleBackColor = True
        '
        'ChkParallelProcessing
        '
        Me.ChkParallelProcessing.AutoSize = True
        Me.ChkParallelProcessing.Location = New System.Drawing.Point(9, 65)
        Me.ChkParallelProcessing.Name = "ChkParallelProcessing"
        Me.ChkParallelProcessing.Size = New System.Drawing.Size(182, 17)
        Me.ChkParallelProcessing.TabIndex = 22
        Me.ChkParallelProcessing.Text = "Parallel processing (multi threads)"
        Me.ChkParallelProcessing.UseVisualStyleBackColor = True
        '
        'ChkKeepDate
        '
        Me.ChkKeepDate.AutoSize = True
        Me.ChkKeepDate.Checked = True
        Me.ChkKeepDate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkKeepDate.Location = New System.Drawing.Point(9, 19)
        Me.ChkKeepDate.Name = "ChkKeepDate"
        Me.ChkKeepDate.Size = New System.Drawing.Size(349, 17)
        Me.ChkKeepDate.TabIndex = 20
        Me.ChkKeepDate.Text = "Preserve the timestamps (like creation and last modification datetime)"
        Me.ChkKeepDate.UseVisualStyleBackColor = True
        '
        'GrpFiles
        '
        Me.GrpFiles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpFiles.Controls.Add(Me.LvFiles)
        Me.GrpFiles.Location = New System.Drawing.Point(3, 293)
        Me.GrpFiles.Name = "GrpFiles"
        Me.GrpFiles.Size = New System.Drawing.Size(487, 156)
        Me.GrpFiles.TabIndex = 6
        Me.GrpFiles.TabStop = False
        Me.GrpFiles.Text = "Files"
        '
        'LvFiles
        '
        Me.LvFiles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LvFiles.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ChName, Me.ChSize, Me.ChCompression})
        Me.LvFiles.FullRowSelect = True
        Me.LvFiles.GridLines = True
        Me.LvFiles.Location = New System.Drawing.Point(7, 19)
        Me.LvFiles.Name = "LvFiles"
        Me.LvFiles.Size = New System.Drawing.Size(473, 131)
        Me.LvFiles.TabIndex = 1
        Me.LvFiles.UseCompatibleStateImageBehavior = False
        Me.LvFiles.View = System.Windows.Forms.View.Details
        '
        'ChName
        '
        Me.ChName.Text = "File name"
        Me.ChName.Width = 290
        '
        'ChSize
        '
        Me.ChSize.Text = "Size"
        Me.ChSize.Width = 80
        '
        'ChCompression
        '
        Me.ChCompression.Text = "Compression"
        Me.ChCompression.Width = 75
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
        'BtnProcess
        '
        Me.BtnProcess.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnProcess.Image = Global.FA.Plugin.ImagesCompressor.My.Resources.Resources.Start
        Me.BtnProcess.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnProcess.Location = New System.Drawing.Point(365, 454)
        Me.BtnProcess.Name = "BtnProcess"
        Me.BtnProcess.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.BtnProcess.Size = New System.Drawing.Size(118, 30)
        Me.BtnProcess.TabIndex = 7
        Me.BtnProcess.Text = "Compress images"
        Me.BtnProcess.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnProcess.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 463)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 13)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Total size:"
        '
        'LblTotalSize
        '
        Me.LblTotalSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblTotalSize.AutoSize = True
        Me.LblTotalSize.Location = New System.Drawing.Point(68, 463)
        Me.LblTotalSize.Name = "LblTotalSize"
        Me.LblTotalSize.Size = New System.Drawing.Size(33, 13)
        Me.LblTotalSize.TabIndex = 10
        Me.LblTotalSize.Text = "0 bite"
        '
        'LblAverageCompression
        '
        Me.LblAverageCompression.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblAverageCompression.AutoSize = True
        Me.LblAverageCompression.Location = New System.Drawing.Point(262, 463)
        Me.LblAverageCompression.Name = "LblAverageCompression"
        Me.LblAverageCompression.Size = New System.Drawing.Size(21, 13)
        Me.LblAverageCompression.TabIndex = 12
        Me.LblAverageCompression.Text = "0%"
        Me.LblAverageCompression.Visible = False
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(129, 463)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(133, 13)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Average compression rate:"
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.Image = Global.FA.Plugin.ImagesCompressor.My.Resources.Resources.Save
        Me.BtnSave.Location = New System.Drawing.Point(328, 454)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(32, 30)
        Me.BtnSave.TabIndex = 13
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'TtSaveBtnTip
        '
        Me.TtSaveBtnTip.AutomaticDelay = 200
        Me.TtSaveBtnTip.AutoPopDelay = 20000
        Me.TtSaveBtnTip.InitialDelay = 200
        Me.TtSaveBtnTip.IsBalloon = True
        Me.TtSaveBtnTip.ReshowDelay = 40
        Me.TtSaveBtnTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.TtSaveBtnTip.ToolTipTitle = "Save options"
        '
        'FrmImgCompressor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(493, 490)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.LblAverageCompression)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.LblTotalSize)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.BtnProcess)
        Me.Controls.Add(Me.GrpFiles)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GrpEncoding)
        Me.Name = "FrmImgCompressor"
        Me.GrpEncoding.ResumeLayout(False)
        Me.GrpEncoding.PerformLayout()
        Me.PanelInterpolationMode.ResumeLayout(False)
        Me.PanelInterpolationMode.PerformLayout()
        Me.PanelJpeqQuality.ResumeLayout(False)
        Me.PanelJpeqQuality.PerformLayout()
        CType(Me.TrbCompression, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.NumCounterStartAt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PctRenameMask, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.PanelParallelProcessing.ResumeLayout(False)
        Me.PanelParallelProcessing.PerformLayout()
        Me.GrpFiles.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GrpEncoding As System.Windows.Forms.GroupBox
    Friend WithEvents PanelJpeqQuality As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmbFormat As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PanelInterpolationMode As System.Windows.Forms.Panel
    Friend WithEvents CmbResizeMethod As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CmbSize As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtRenameMask As System.Windows.Forms.TextBox
    Friend WithEvents ChkRename As System.Windows.Forms.CheckBox
    Friend WithEvents PctRenameMask As System.Windows.Forms.PictureBox
    Friend WithEvents ChkMoveTo As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents NumCounterStartAt As System.Windows.Forms.NumericUpDown
    Friend WithEvents ChkDeleteOrignal As System.Windows.Forms.CheckBox
    Friend WithEvents BtnBrowse As System.Windows.Forms.Button
    Friend WithEvents TxtPath As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkKeepExif As System.Windows.Forms.CheckBox
    Friend WithEvents ChkKeepDate As System.Windows.Forms.CheckBox
    Friend WithEvents GrpFiles As System.Windows.Forms.GroupBox
    Friend WithEvents LvFiles As System.Windows.Forms.ListView
    Friend WithEvents ChName As System.Windows.Forms.ColumnHeader
    Friend WithEvents ChSize As System.Windows.Forms.ColumnHeader
    Friend WithEvents ChCompression As System.Windows.Forms.ColumnHeader
    Friend WithEvents LblCompression As System.Windows.Forms.Label
    Friend WithEvents TrbCompression As System.Windows.Forms.TrackBar
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TtTextboxTip As System.Windows.Forms.ToolTip
    Friend WithEvents BtnProcess As System.Windows.Forms.Button
    Friend WithEvents LlbCpuCores As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CmbNbThreads As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ChkParallelProcessing As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LblTotalSize As System.Windows.Forms.Label
    Friend WithEvents LblAverageCompression As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents PanelParallelProcessing As System.Windows.Forms.Panel
    Friend WithEvents ChkOverwrite As System.Windows.Forms.CheckBox
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents TtSaveBtnTip As System.Windows.Forms.ToolTip

End Class
