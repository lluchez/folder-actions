<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GrpFilters = New System.Windows.Forms.GroupBox()
        Me.ChkCaseSensitive = New System.Windows.Forms.CheckBox()
        Me.TxtContains = New System.Windows.Forms.TextBox()
        Me.RadioContains = New System.Windows.Forms.RadioButton()
        Me.BtnApplyFilters = New System.Windows.Forms.Button()
        Me.ComboTypes = New System.Windows.Forms.ComboBox()
        Me.TxtRegex = New System.Windows.Forms.TextBox()
        Me.TxtFilter = New System.Windows.Forms.TextBox()
        Me.TxtExtensions = New System.Windows.Forms.TextBox()
        Me.RadioType = New System.Windows.Forms.RadioButton()
        Me.RadioRegex = New System.Windows.Forms.RadioButton()
        Me.RadioFilter = New System.Windows.Forms.RadioButton()
        Me.RadioExtension = New System.Windows.Forms.RadioButton()
        Me.RadioAllFiles = New System.Windows.Forms.RadioButton()
        Me.GrpFiles = New System.Windows.Forms.GroupBox()
        Me.LvFiles = New System.Windows.Forms.ListView()
        Me.ChCheck = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ChName = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ChSize = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ChDate = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.GrpFolder = New System.Windows.Forms.GroupBox()
        Me.PathSelector = New FA.Library.PathSelector()
        Me.BtnSaveOptions = New System.Windows.Forms.Button()
        Me.ChkViewHiddenFiles = New System.Windows.Forms.CheckBox()
        Me.ChkRecursiveScan = New System.Windows.Forms.CheckBox()
        Me.BtnRefresh = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.TsiViewThumbnails = New System.Windows.Forms.ToolStripMenuItem()
        Me.TsiViewDetails = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TsiViewAllFiles = New System.Windows.Forms.ToolStripMenuItem()
        Me.TsiFilterOut = New System.Windows.Forms.ToolStripMenuItem()
        Me.TssRegistry = New System.Windows.Forms.ToolStripSeparator()
        Me.TsiRegAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.TsiRegDel = New System.Windows.Forms.ToolStripMenuItem()
        Me.TslSelectedFiles = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TsbActionSelector = New System.Windows.Forms.ToolStripDropDownButton()
        Me.GrpFilters.SuspendLayout()
        Me.GrpFiles.SuspendLayout()
        Me.GrpFolder.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpFilters
        '
        Me.GrpFilters.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpFilters.Controls.Add(Me.ChkCaseSensitive)
        Me.GrpFilters.Controls.Add(Me.TxtContains)
        Me.GrpFilters.Controls.Add(Me.RadioContains)
        Me.GrpFilters.Controls.Add(Me.BtnApplyFilters)
        Me.GrpFilters.Controls.Add(Me.ComboTypes)
        Me.GrpFilters.Controls.Add(Me.TxtRegex)
        Me.GrpFilters.Controls.Add(Me.TxtFilter)
        Me.GrpFilters.Controls.Add(Me.TxtExtensions)
        Me.GrpFilters.Controls.Add(Me.RadioType)
        Me.GrpFilters.Controls.Add(Me.RadioRegex)
        Me.GrpFilters.Controls.Add(Me.RadioFilter)
        Me.GrpFilters.Controls.Add(Me.RadioExtension)
        Me.GrpFilters.Controls.Add(Me.RadioAllFiles)
        Me.GrpFilters.Location = New System.Drawing.Point(3, 104)
        Me.GrpFilters.Name = "GrpFilters"
        Me.GrpFilters.Size = New System.Drawing.Size(513, 163)
        Me.GrpFilters.TabIndex = 0
        Me.GrpFilters.TabStop = False
        Me.GrpFilters.Text = "Filters"
        '
        'ChkCaseSensitive
        '
        Me.ChkCaseSensitive.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkCaseSensitive.AutoSize = True
        Me.ChkCaseSensitive.Location = New System.Drawing.Point(87, 67)
        Me.ChkCaseSensitive.Name = "ChkCaseSensitive"
        Me.ChkCaseSensitive.Size = New System.Drawing.Size(94, 17)
        Me.ChkCaseSensitive.TabIndex = 7
        Me.ChkCaseSensitive.Text = "Case sensitive"
        Me.ChkCaseSensitive.UseVisualStyleBackColor = True
        '
        'TxtContains
        '
        Me.TxtContains.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtContains.Location = New System.Drawing.Point(188, 65)
        Me.TxtContains.Name = "TxtContains"
        Me.TxtContains.Size = New System.Drawing.Size(319, 20)
        Me.TxtContains.TabIndex = 11
        '
        'RadioContains
        '
        Me.RadioContains.AutoSize = True
        Me.RadioContains.Location = New System.Drawing.Point(6, 66)
        Me.RadioContains.Name = "RadioContains"
        Me.RadioContains.Size = New System.Drawing.Size(69, 17)
        Me.RadioContains.TabIndex = 10
        Me.RadioContains.Text = "Contains:"
        Me.RadioContains.UseVisualStyleBackColor = True
        '
        'BtnApplyFilters
        '
        Me.BtnApplyFilters.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnApplyFilters.Image = Global.FA.My.Resources.Resources.Filter
        Me.BtnApplyFilters.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnApplyFilters.Location = New System.Drawing.Point(420, 134)
        Me.BtnApplyFilters.Name = "BtnApplyFilters"
        Me.BtnApplyFilters.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.BtnApplyFilters.Size = New System.Drawing.Size(87, 23)
        Me.BtnApplyFilters.TabIndex = 9
        Me.BtnApplyFilters.Text = "Apply filters"
        Me.BtnApplyFilters.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnApplyFilters.UseVisualStyleBackColor = True
        '
        'ComboTypes
        '
        Me.ComboTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboTypes.FormattingEnabled = True
        Me.ComboTypes.Location = New System.Drawing.Point(188, 134)
        Me.ComboTypes.MaximumSize = New System.Drawing.Size(279, 0)
        Me.ComboTypes.Name = "ComboTypes"
        Me.ComboTypes.Size = New System.Drawing.Size(105, 21)
        Me.ComboTypes.TabIndex = 8
        '
        'TxtRegex
        '
        Me.TxtRegex.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtRegex.Location = New System.Drawing.Point(188, 111)
        Me.TxtRegex.Name = "TxtRegex"
        Me.TxtRegex.Size = New System.Drawing.Size(319, 20)
        Me.TxtRegex.TabIndex = 7
        '
        'TxtFilter
        '
        Me.TxtFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtFilter.Location = New System.Drawing.Point(188, 88)
        Me.TxtFilter.Name = "TxtFilter"
        Me.TxtFilter.Size = New System.Drawing.Size(319, 20)
        Me.TxtFilter.TabIndex = 6
        '
        'TxtExtensions
        '
        Me.TxtExtensions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtExtensions.Location = New System.Drawing.Point(188, 42)
        Me.TxtExtensions.Name = "TxtExtensions"
        Me.TxtExtensions.Size = New System.Drawing.Size(319, 20)
        Me.TxtExtensions.TabIndex = 5
        '
        'RadioType
        '
        Me.RadioType.AutoSize = True
        Me.RadioType.Location = New System.Drawing.Point(6, 135)
        Me.RadioType.Name = "RadioType"
        Me.RadioType.Size = New System.Drawing.Size(144, 17)
        Me.RadioType.TabIndex = 4
        Me.RadioType.Text = "Is from the following type:"
        Me.RadioType.UseVisualStyleBackColor = True
        '
        'RadioRegex
        '
        Me.RadioRegex.AutoSize = True
        Me.RadioRegex.Location = New System.Drawing.Point(7, 112)
        Me.RadioRegex.Name = "RadioRegex"
        Me.RadioRegex.Size = New System.Drawing.Size(178, 17)
        Me.RadioRegex.TabIndex = 3
        Me.RadioRegex.Text = "Matching the regular expression:"
        Me.RadioRegex.UseVisualStyleBackColor = True
        '
        'RadioFilter
        '
        Me.RadioFilter.AutoSize = True
        Me.RadioFilter.Location = New System.Drawing.Point(7, 89)
        Me.RadioFilter.Name = "RadioFilter"
        Me.RadioFilter.Size = New System.Drawing.Size(112, 17)
        Me.RadioFilter.TabIndex = 2
        Me.RadioFilter.Text = "Matching the filter:"
        Me.RadioFilter.UseVisualStyleBackColor = True
        '
        'RadioExtension
        '
        Me.RadioExtension.AutoSize = True
        Me.RadioExtension.Location = New System.Drawing.Point(7, 43)
        Me.RadioExtension.Name = "RadioExtension"
        Me.RadioExtension.Size = New System.Drawing.Size(98, 17)
        Me.RadioExtension.TabIndex = 1
        Me.RadioExtension.Text = "With extension:"
        Me.RadioExtension.UseVisualStyleBackColor = True
        '
        'RadioAllFiles
        '
        Me.RadioAllFiles.AutoSize = True
        Me.RadioAllFiles.Checked = True
        Me.RadioAllFiles.Location = New System.Drawing.Point(7, 20)
        Me.RadioAllFiles.Name = "RadioAllFiles"
        Me.RadioAllFiles.Size = New System.Drawing.Size(188, 17)
        Me.RadioAllFiles.TabIndex = 0
        Me.RadioAllFiles.TabStop = True
        Me.RadioAllFiles.Text = "All files (No filters, will keep all files)"
        Me.RadioAllFiles.UseVisualStyleBackColor = True
        '
        'GrpFiles
        '
        Me.GrpFiles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpFiles.Controls.Add(Me.LvFiles)
        Me.GrpFiles.Location = New System.Drawing.Point(3, 273)
        Me.GrpFiles.Name = "GrpFiles"
        Me.GrpFiles.Size = New System.Drawing.Size(513, 189)
        Me.GrpFiles.TabIndex = 3
        Me.GrpFiles.TabStop = False
        Me.GrpFiles.Text = "Files to process"
        '
        'LvFiles
        '
        Me.LvFiles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LvFiles.CheckBoxes = True
        Me.LvFiles.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ChCheck, Me.ChName, Me.ChSize, Me.ChDate})
        Me.LvFiles.FullRowSelect = True
        Me.LvFiles.GridLines = True
        Me.LvFiles.Location = New System.Drawing.Point(7, 19)
        Me.LvFiles.Name = "LvFiles"
        Me.LvFiles.Size = New System.Drawing.Size(501, 164)
        Me.LvFiles.TabIndex = 0
        Me.LvFiles.UseCompatibleStateImageBehavior = False
        Me.LvFiles.View = System.Windows.Forms.View.Details
        '
        'ChCheck
        '
        Me.ChCheck.Text = ""
        Me.ChCheck.Width = 20
        '
        'ChName
        '
        Me.ChName.Text = "File name"
        Me.ChName.Width = 282
        '
        'ChSize
        '
        Me.ChSize.Text = "Size"
        Me.ChSize.Width = 80
        '
        'ChDate
        '
        Me.ChDate.Text = "Date"
        Me.ChDate.Width = 114
        '
        'GrpFolder
        '
        Me.GrpFolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpFolder.Controls.Add(Me.PathSelector)
        Me.GrpFolder.Controls.Add(Me.BtnSaveOptions)
        Me.GrpFolder.Controls.Add(Me.ChkViewHiddenFiles)
        Me.GrpFolder.Controls.Add(Me.ChkRecursiveScan)
        Me.GrpFolder.Controls.Add(Me.BtnRefresh)
        Me.GrpFolder.Location = New System.Drawing.Point(3, 3)
        Me.GrpFolder.Name = "GrpFolder"
        Me.GrpFolder.Size = New System.Drawing.Size(513, 95)
        Me.GrpFolder.TabIndex = 4
        Me.GrpFolder.TabStop = False
        Me.GrpFolder.Text = "Folder"
        '
        'PathSelector
        '
        Me.PathSelector.Location = New System.Drawing.Point(10, 17)
        Me.PathSelector.Name = "PathSelector"
        Me.PathSelector.Path = ""
        Me.PathSelector.Size = New System.Drawing.Size(458, 23)
        Me.PathSelector.TabIndex = 6
        '
        'BtnSaveOptions
        '
        Me.BtnSaveOptions.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSaveOptions.Image = Global.FA.My.Resources.Resources.Save
        Me.BtnSaveOptions.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSaveOptions.Location = New System.Drawing.Point(413, 63)
        Me.BtnSaveOptions.Name = "BtnSaveOptions"
        Me.BtnSaveOptions.Size = New System.Drawing.Size(92, 23)
        Me.BtnSaveOptions.TabIndex = 5
        Me.BtnSaveOptions.Text = "Save options"
        Me.BtnSaveOptions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSaveOptions.UseVisualStyleBackColor = True
        '
        'ChkViewHiddenFiles
        '
        Me.ChkViewHiddenFiles.AutoSize = True
        Me.ChkViewHiddenFiles.Location = New System.Drawing.Point(10, 67)
        Me.ChkViewHiddenFiles.Name = "ChkViewHiddenFiles"
        Me.ChkViewHiddenFiles.Size = New System.Drawing.Size(105, 17)
        Me.ChkViewHiddenFiles.TabIndex = 4
        Me.ChkViewHiddenFiles.Text = "View hidden files"
        Me.ChkViewHiddenFiles.UseVisualStyleBackColor = True
        '
        'ChkRecursiveScan
        '
        Me.ChkRecursiveScan.AutoSize = True
        Me.ChkRecursiveScan.Location = New System.Drawing.Point(10, 46)
        Me.ChkRecursiveScan.Name = "ChkRecursiveScan"
        Me.ChkRecursiveScan.Size = New System.Drawing.Size(210, 17)
        Me.ChkRecursiveScan.TabIndex = 3
        Me.ChkRecursiveScan.Text = "Look in sub-directories (recursive scan)"
        Me.ChkRecursiveScan.UseVisualStyleBackColor = True
        '
        'BtnRefresh
        '
        Me.BtnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRefresh.Image = Global.FA.My.Resources.Resources.Refresh
        Me.BtnRefresh.Location = New System.Drawing.Point(474, 17)
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Size = New System.Drawing.Size(31, 23)
        Me.BtnRefresh.TabIndex = 2
        Me.BtnRefresh.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton1, Me.TslSelectedFiles, Me.TsbActionSelector})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 465)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(520, 22)
        Me.StatusStrip1.TabIndex = 10
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsiViewThumbnails, Me.TsiViewDetails, Me.ToolStripSeparator1, Me.TsiViewAllFiles, Me.TsiFilterOut, Me.TssRegistry, Me.TsiRegAdd, Me.TsiRegDel})
        Me.ToolStripDropDownButton1.Image = Global.FA.My.Resources.Resources.action_32
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(29, 20)
        Me.ToolStripDropDownButton1.Text = "Coucou"
        '
        'TsiViewThumbnails
        '
        Me.TsiViewThumbnails.Image = Global.FA.My.Resources.Resources.View_Thumbnails
        Me.TsiViewThumbnails.Name = "TsiViewThumbnails"
        Me.TsiViewThumbnails.Size = New System.Drawing.Size(260, 22)
        Me.TsiViewThumbnails.Text = "Images View (with thumbnails)"
        '
        'TsiViewDetails
        '
        Me.TsiViewDetails.Enabled = False
        Me.TsiViewDetails.Image = Global.FA.My.Resources.Resources.View_Details
        Me.TsiViewDetails.Name = "TsiViewDetails"
        Me.TsiViewDetails.Size = New System.Drawing.Size(260, 22)
        Me.TsiViewDetails.Text = "Details View"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(257, 6)
        '
        'TsiViewAllFiles
        '
        Me.TsiViewAllFiles.Image = Global.FA.My.Resources.Resources.ViewAllFiles
        Me.TsiViewAllFiles.Name = "TsiViewAllFiles"
        Me.TsiViewAllFiles.Size = New System.Drawing.Size(260, 22)
        Me.TsiViewAllFiles.Text = "View all files (of the selected folder)"
        '
        'TsiFilterOut
        '
        Me.TsiFilterOut.Image = Global.FA.My.Resources.Resources.FilterOut
        Me.TsiFilterOut.Name = "TsiFilterOut"
        Me.TsiFilterOut.Size = New System.Drawing.Size(260, 22)
        Me.TsiFilterOut.Text = "Filter out files first"
        '
        'TssRegistry
        '
        Me.TssRegistry.Name = "TssRegistry"
        Me.TssRegistry.Size = New System.Drawing.Size(257, 6)
        '
        'TsiRegAdd
        '
        Me.TsiRegAdd.Image = Global.FA.My.Resources.Resources.Regedit
        Me.TsiRegAdd.Name = "TsiRegAdd"
        Me.TsiRegAdd.Size = New System.Drawing.Size(260, 22)
        Me.TsiRegAdd.Text = "Assign (Right Click on Folders)"
        '
        'TsiRegDel
        '
        Me.TsiRegDel.Image = Global.FA.My.Resources.Resources.DelRegedit
        Me.TsiRegDel.Name = "TsiRegDel"
        Me.TsiRegDel.Size = New System.Drawing.Size(260, 22)
        Me.TsiRegDel.Text = "Unassign (from the Right Click)"
        '
        'TslSelectedFiles
        '
        Me.TslSelectedFiles.Name = "TslSelectedFiles"
        Me.TslSelectedFiles.Size = New System.Drawing.Size(447, 17)
        Me.TslSelectedFiles.Spring = True
        Me.TslSelectedFiles.Text = "Items selected"
        '
        'TsbActionSelector
        '
        Me.TsbActionSelector.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TsbActionSelector.Image = Global.FA.My.Resources.Resources.Start
        Me.TsbActionSelector.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsbActionSelector.Name = "TsbActionSelector"
        Me.TsbActionSelector.Size = New System.Drawing.Size(29, 20)
        Me.TsbActionSelector.Text = "ToolStripDropDownButton2"
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(520, 487)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GrpFolder)
        Me.Controls.Add(Me.GrpFilters)
        Me.Controls.Add(Me.GrpFiles)
        Me.Name = "FrmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GrpFilters.ResumeLayout(false)
        Me.GrpFilters.PerformLayout
        Me.GrpFiles.ResumeLayout(false)
        Me.GrpFolder.ResumeLayout(false)
        Me.GrpFolder.PerformLayout
        Me.StatusStrip1.ResumeLayout(false)
        Me.StatusStrip1.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents GrpFilters As System.Windows.Forms.GroupBox
    Friend WithEvents BtnApplyFilters As System.Windows.Forms.Button
    Friend WithEvents ComboTypes As System.Windows.Forms.ComboBox
    Friend WithEvents TxtRegex As System.Windows.Forms.TextBox
    Friend WithEvents TxtFilter As System.Windows.Forms.TextBox
    Friend WithEvents TxtExtensions As System.Windows.Forms.TextBox
    Friend WithEvents RadioType As System.Windows.Forms.RadioButton
    Friend WithEvents RadioRegex As System.Windows.Forms.RadioButton
    Friend WithEvents RadioFilter As System.Windows.Forms.RadioButton
    Friend WithEvents RadioExtension As System.Windows.Forms.RadioButton
    Friend WithEvents RadioAllFiles As System.Windows.Forms.RadioButton
    Friend WithEvents GrpFiles As System.Windows.Forms.GroupBox
    Friend WithEvents LvFiles As System.Windows.Forms.ListView
    Friend WithEvents ChCheck As System.Windows.Forms.ColumnHeader
    Friend WithEvents ChName As System.Windows.Forms.ColumnHeader
    Friend WithEvents GrpFolder As System.Windows.Forms.GroupBox
    Friend WithEvents ChSize As System.Windows.Forms.ColumnHeader
    Friend WithEvents ChDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents BtnRefresh As System.Windows.Forms.Button
    Friend WithEvents TxtContains As System.Windows.Forms.TextBox
    Friend WithEvents RadioContains As System.Windows.Forms.RadioButton
    Friend WithEvents ChkCaseSensitive As System.Windows.Forms.CheckBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents TsiRegAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TsiViewDetails As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TsiViewThumbnails As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TslSelectedFiles As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TsbActionSelector As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents TsiRegDel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TsiViewAllFiles As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TssRegistry As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TsiFilterOut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChkViewHiddenFiles As System.Windows.Forms.CheckBox
    Friend WithEvents ChkRecursiveScan As System.Windows.Forms.CheckBox
    Friend WithEvents BtnSaveOptions As System.Windows.Forms.Button
    Friend WithEvents PathSelector As FA.Library.PathSelector

End Class
