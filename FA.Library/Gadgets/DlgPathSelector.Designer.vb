<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgPathSelector
    Inherits System.Windows.Forms.Form

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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.BtnOk = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.GroupBoxPath = New System.Windows.Forms.GroupBox()
        Me.PathSelector = New FA.Library.PathSelector()
        Me.GroupBoxOptions = New System.Windows.Forms.GroupBox()
        Me.ChkUseMask = New System.Windows.Forms.CheckBox()
        Me.TxtMask = New System.Windows.Forms.TextBox()
        Me.ChkViewHiddenFiles = New System.Windows.Forms.CheckBox()
        Me.ChkRecursiveScan = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBoxPath.SuspendLayout()
        Me.GroupBoxOptions.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.BtnOk, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.BtnCancel, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(265, 160)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'BtnOk
        '
        Me.BtnOk.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BtnOk.Enabled = False
        Me.BtnOk.Location = New System.Drawing.Point(3, 3)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(67, 23)
        Me.BtnOk.TabIndex = 0
        Me.BtnOk.Text = "Select"
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(76, 3)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(67, 23)
        Me.BtnCancel.TabIndex = 1
        Me.BtnCancel.Text = "Cancel"
        '
        'GroupBoxPath
        '
        Me.GroupBoxPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxPath.Controls.Add(Me.PathSelector)
        Me.GroupBoxPath.Location = New System.Drawing.Point(12, 12)
        Me.GroupBoxPath.Name = "GroupBoxPath"
        Me.GroupBoxPath.Size = New System.Drawing.Size(399, 50)
        Me.GroupBoxPath.TabIndex = 1
        Me.GroupBoxPath.TabStop = False
        Me.GroupBoxPath.Text = "Select the path"
        '
        'PathSelector
        '
        Me.PathSelector.Location = New System.Drawing.Point(6, 19)
        Me.PathSelector.Name = "PathSelector"
        Me.PathSelector.Path = ""
        Me.PathSelector.Size = New System.Drawing.Size(387, 23)
        Me.PathSelector.TabIndex = 0
        '
        'GroupBoxOptions
        '
        Me.GroupBoxOptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxOptions.Controls.Add(Me.ChkUseMask)
        Me.GroupBoxOptions.Controls.Add(Me.TxtMask)
        Me.GroupBoxOptions.Controls.Add(Me.ChkViewHiddenFiles)
        Me.GroupBoxOptions.Controls.Add(Me.ChkRecursiveScan)
        Me.GroupBoxOptions.Location = New System.Drawing.Point(12, 68)
        Me.GroupBoxOptions.Name = "GroupBoxOptions"
        Me.GroupBoxOptions.Size = New System.Drawing.Size(399, 86)
        Me.GroupBoxOptions.TabIndex = 2
        Me.GroupBoxOptions.TabStop = False
        Me.GroupBoxOptions.Text = "Additional options"
        '
        'ChkUseMask
        '
        Me.ChkUseMask.AutoSize = True
        Me.ChkUseMask.Location = New System.Drawing.Point(6, 61)
        Me.ChkUseMask.Name = "ChkUseMask"
        Me.ChkUseMask.Size = New System.Drawing.Size(138, 17)
        Me.ChkUseMask.TabIndex = 9
        Me.ChkUseMask.Text = "Use the following mask:"
        Me.ChkUseMask.UseVisualStyleBackColor = True
        '
        'TxtMask
        '
        Me.TxtMask.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtMask.Enabled = False
        Me.TxtMask.Location = New System.Drawing.Point(150, 59)
        Me.TxtMask.Name = "TxtMask"
        Me.TxtMask.Size = New System.Drawing.Size(243, 20)
        Me.TxtMask.TabIndex = 8
        Me.TxtMask.Text = "*.*"
        '
        'ChkViewHiddenFiles
        '
        Me.ChkViewHiddenFiles.AutoSize = True
        Me.ChkViewHiddenFiles.Location = New System.Drawing.Point(6, 40)
        Me.ChkViewHiddenFiles.Name = "ChkViewHiddenFiles"
        Me.ChkViewHiddenFiles.Size = New System.Drawing.Size(287, 17)
        Me.ChkViewHiddenFiles.TabIndex = 6
        Me.ChkViewHiddenFiles.Text = "Include hidden files (files that may not be visible usually)"
        Me.ChkViewHiddenFiles.UseVisualStyleBackColor = True
        '
        'ChkRecursiveScan
        '
        Me.ChkRecursiveScan.AutoSize = True
        Me.ChkRecursiveScan.Location = New System.Drawing.Point(6, 19)
        Me.ChkRecursiveScan.Name = "ChkRecursiveScan"
        Me.ChkRecursiveScan.Size = New System.Drawing.Size(247, 17)
        Me.ChkRecursiveScan.TabIndex = 5
        Me.ChkRecursiveScan.Text = "Recursive scan (look for files in sub-directories)"
        Me.ChkRecursiveScan.UseVisualStyleBackColor = True
        '
        'DlgPathSelector
        '
        Me.AcceptButton = Me.BtnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(423, 201)
        Me.Controls.Add(Me.GroupBoxOptions)
        Me.Controls.Add(Me.GroupBoxPath)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DlgPathSelector"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Files Selector"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBoxPath.ResumeLayout(False)
        Me.GroupBoxOptions.ResumeLayout(False)
        Me.GroupBoxOptions.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents BtnOk As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBoxPath As System.Windows.Forms.GroupBox
    Friend WithEvents PathSelector As FA.Library.PathSelector
    Friend WithEvents GroupBoxOptions As System.Windows.Forms.GroupBox
    Friend WithEvents ChkViewHiddenFiles As System.Windows.Forms.CheckBox
    Friend WithEvents ChkRecursiveScan As System.Windows.Forms.CheckBox
    Friend WithEvents ChkUseMask As System.Windows.Forms.CheckBox
    Friend WithEvents TxtMask As System.Windows.Forms.TextBox

End Class
