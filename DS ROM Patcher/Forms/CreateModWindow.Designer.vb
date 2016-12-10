<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreateModWindow
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
        Me.txtOriginal = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtModified = New System.Windows.Forms.TextBox()
        Me.btnOriginalBrowseFiles = New System.Windows.Forms.Button()
        Me.btnOriginalBrowseFolders = New System.Windows.Forms.Button()
        Me.btnModifiedBrowseFolders = New System.Windows.Forms.Button()
        Me.btnModifiedBrowseFiles = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnCreate = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtGameCode = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtModDescription = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtModDependenciesAfter = New System.Windows.Forms.TextBox()
        Me.txtModDependenciesBefore = New System.Windows.Forms.TextBox()
        Me.txtModVersion = New System.Windows.Forms.TextBox()
        Me.txtModAuthor = New System.Windows.Forms.TextBox()
        Me.txtModName = New System.Windows.Forms.TextBox()
        Me.txtModID = New System.Windows.Forms.TextBox()
        Me.pbProgress = New System.Windows.Forms.ProgressBar()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.chbEnableAdd = New System.Windows.Forms.CheckBox()
        Me.chbEnableDelete = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout
        Me.SuspendLayout
        '
        'txtOriginal
        '
        Me.txtOriginal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtOriginal.Location = New System.Drawing.Point(68, 12)
        Me.txtOriginal.Name = "txtOriginal"
        Me.txtOriginal.Size = New System.Drawing.Size(268, 20)
        Me.txtOriginal.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Original:"
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Location = New System.Drawing.Point(12, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Modified:"
        '
        'txtModified
        '
        Me.txtModified.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtModified.Location = New System.Drawing.Point(68, 39)
        Me.txtModified.Name = "txtModified"
        Me.txtModified.Size = New System.Drawing.Size(268, 20)
        Me.txtModified.TabIndex = 3
        '
        'btnOriginalBrowseFiles
        '
        Me.btnOriginalBrowseFiles.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnOriginalBrowseFiles.Location = New System.Drawing.Point(342, 10)
        Me.btnOriginalBrowseFiles.Name = "btnOriginalBrowseFiles"
        Me.btnOriginalBrowseFiles.Size = New System.Drawing.Size(125, 23)
        Me.btnOriginalBrowseFiles.TabIndex = 1
        Me.btnOriginalBrowseFiles.Text = "Browse Files..."
        Me.btnOriginalBrowseFiles.UseVisualStyleBackColor = true
        '
        'btnOriginalBrowseFolders
        '
        Me.btnOriginalBrowseFolders.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnOriginalBrowseFolders.Location = New System.Drawing.Point(473, 10)
        Me.btnOriginalBrowseFolders.Name = "btnOriginalBrowseFolders"
        Me.btnOriginalBrowseFolders.Size = New System.Drawing.Size(125, 23)
        Me.btnOriginalBrowseFolders.TabIndex = 2
        Me.btnOriginalBrowseFolders.Text = "Browse Folders..."
        Me.btnOriginalBrowseFolders.UseVisualStyleBackColor = true
        '
        'btnModifiedBrowseFolders
        '
        Me.btnModifiedBrowseFolders.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnModifiedBrowseFolders.Location = New System.Drawing.Point(473, 37)
        Me.btnModifiedBrowseFolders.Name = "btnModifiedBrowseFolders"
        Me.btnModifiedBrowseFolders.Size = New System.Drawing.Size(125, 23)
        Me.btnModifiedBrowseFolders.TabIndex = 5
        Me.btnModifiedBrowseFolders.Text = "Browse Folders..."
        Me.btnModifiedBrowseFolders.UseVisualStyleBackColor = true
        '
        'btnModifiedBrowseFiles
        '
        Me.btnModifiedBrowseFiles.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnModifiedBrowseFiles.Location = New System.Drawing.Point(342, 37)
        Me.btnModifiedBrowseFiles.Name = "btnModifiedBrowseFiles"
        Me.btnModifiedBrowseFiles.Size = New System.Drawing.Size(125, 23)
        Me.btnModifiedBrowseFiles.TabIndex = 4
        Me.btnModifiedBrowseFiles.Text = "Browse Files..."
        Me.btnModifiedBrowseFiles.UseVisualStyleBackColor = true
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(96, 416)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = true
        '
        'btnCreate
        '
        Me.btnCreate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.btnCreate.Location = New System.Drawing.Point(15, 416)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(75, 23)
        Me.btnCreate.TabIndex = 6
        Me.btnCreate.Text = "Create"
        Me.btnCreate.UseVisualStyleBackColor = true
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtGameCode)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtModDescription)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtModDependenciesAfter)
        Me.GroupBox1.Controls.Add(Me.txtModDependenciesBefore)
        Me.GroupBox1.Controls.Add(Me.txtModVersion)
        Me.GroupBox1.Controls.Add(Me.txtModAuthor)
        Me.GroupBox1.Controls.Add(Me.txtModName)
        Me.GroupBox1.Controls.Add(Me.txtModID)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 65)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(583, 239)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = false
        Me.GroupBox1.Text = "Metadata"
        '
        'Label10
        '
        Me.Label10.AutoSize = true
        Me.Label10.Location = New System.Drawing.Point(6, 205)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 13)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "Game Code"
        '
        'txtGameCode
        '
        Me.txtGameCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtGameCode.Location = New System.Drawing.Point(143, 202)
        Me.txtGameCode.Name = "txtGameCode"
        Me.txtGameCode.Size = New System.Drawing.Size(424, 20)
        Me.txtGameCode.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = true
        Me.Label9.Location = New System.Drawing.Point(8, 101)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 13)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Description"
        '
        'txtModDescription
        '
        Me.txtModDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtModDescription.Location = New System.Drawing.Point(143, 98)
        Me.txtModDescription.Name = "txtModDescription"
        Me.txtModDescription.Size = New System.Drawing.Size(424, 20)
        Me.txtModDescription.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = true
        Me.Label8.Location = New System.Drawing.Point(8, 179)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(107, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Dependencies (After)"
        '
        'Label7
        '
        Me.Label7.AutoSize = true
        Me.Label7.Location = New System.Drawing.Point(8, 153)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(116, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Dependencies (Before)"
        '
        'Label6
        '
        Me.Label6.AutoSize = true
        Me.Label6.Location = New System.Drawing.Point(8, 127)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Version"
        '
        'Label5
        '
        Me.Label5.AutoSize = true
        Me.Label5.Location = New System.Drawing.Point(8, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Author"
        '
        'Label4
        '
        Me.Label4.AutoSize = true
        Me.Label4.Location = New System.Drawing.Point(8, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Friendly Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.Location = New System.Drawing.Point(8, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(18, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "ID"
        '
        'txtModDependenciesAfter
        '
        Me.txtModDependenciesAfter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtModDependenciesAfter.Location = New System.Drawing.Point(143, 176)
        Me.txtModDependenciesAfter.Name = "txtModDependenciesAfter"
        Me.txtModDependenciesAfter.Size = New System.Drawing.Size(424, 20)
        Me.txtModDependenciesAfter.TabIndex = 6
        '
        'txtModDependenciesBefore
        '
        Me.txtModDependenciesBefore.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtModDependenciesBefore.Location = New System.Drawing.Point(143, 150)
        Me.txtModDependenciesBefore.Name = "txtModDependenciesBefore"
        Me.txtModDependenciesBefore.Size = New System.Drawing.Size(424, 20)
        Me.txtModDependenciesBefore.TabIndex = 5
        '
        'txtModVersion
        '
        Me.txtModVersion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtModVersion.Location = New System.Drawing.Point(143, 124)
        Me.txtModVersion.Name = "txtModVersion"
        Me.txtModVersion.Size = New System.Drawing.Size(424, 20)
        Me.txtModVersion.TabIndex = 4
        Me.txtModVersion.Text = "1.0.0"
        '
        'txtModAuthor
        '
        Me.txtModAuthor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtModAuthor.Location = New System.Drawing.Point(143, 72)
        Me.txtModAuthor.Name = "txtModAuthor"
        Me.txtModAuthor.Size = New System.Drawing.Size(424, 20)
        Me.txtModAuthor.TabIndex = 2
        '
        'txtModName
        '
        Me.txtModName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtModName.Location = New System.Drawing.Point(143, 46)
        Me.txtModName.Name = "txtModName"
        Me.txtModName.Size = New System.Drawing.Size(424, 20)
        Me.txtModName.TabIndex = 1
        '
        'txtModID
        '
        Me.txtModID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtModID.Location = New System.Drawing.Point(143, 19)
        Me.txtModID.Name = "txtModID"
        Me.txtModID.Size = New System.Drawing.Size(424, 20)
        Me.txtModID.TabIndex = 0
        '
        'pbProgress
        '
        Me.pbProgress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.pbProgress.Location = New System.Drawing.Point(15, 384)
        Me.pbProgress.Maximum = 10000
        Me.pbProgress.Name = "pbProgress"
        Me.pbProgress.Size = New System.Drawing.Size(583, 23)
        Me.pbProgress.TabIndex = 11
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.lblStatus.AutoSize = true
        Me.lblStatus.Location = New System.Drawing.Point(12, 368)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(38, 13)
        Me.lblStatus.TabIndex = 12
        Me.lblStatus.Text = "Ready"
        '
        'chbEnableAdd
        '
        Me.chbEnableAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.chbEnableAdd.AutoSize = true
        Me.chbEnableAdd.Checked = true
        Me.chbEnableAdd.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbEnableAdd.Location = New System.Drawing.Point(26, 310)
        Me.chbEnableAdd.Name = "chbEnableAdd"
        Me.chbEnableAdd.Size = New System.Drawing.Size(86, 17)
        Me.chbEnableAdd.TabIndex = 13
        Me.chbEnableAdd.Text = "Enable Adds"
        Me.chbEnableAdd.UseVisualStyleBackColor = true
        '
        'chbEnableDelete
        '
        Me.chbEnableDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.chbEnableDelete.AutoSize = true
        Me.chbEnableDelete.Location = New System.Drawing.Point(26, 333)
        Me.chbEnableDelete.Name = "chbEnableDelete"
        Me.chbEnableDelete.Size = New System.Drawing.Size(98, 17)
        Me.chbEnableDelete.TabIndex = 14
        Me.chbEnableDelete.Text = "Enable Deletes"
        Me.chbEnableDelete.UseVisualStyleBackColor = true
        '
        'CreateModWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(611, 451)
        Me.Controls.Add(Me.chbEnableDelete)
        Me.Controls.Add(Me.chbEnableAdd)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.pbProgress)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCreate)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnModifiedBrowseFolders)
        Me.Controls.Add(Me.btnModifiedBrowseFiles)
        Me.Controls.Add(Me.btnOriginalBrowseFolders)
        Me.Controls.Add(Me.btnOriginalBrowseFiles)
        Me.Controls.Add(Me.txtModified)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtOriginal)
        Me.Name = "CreateModWindow"
        Me.Text = "Create Mod"
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox1.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents txtOriginal As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtModified As TextBox
    Friend WithEvents btnOriginalBrowseFiles As Button
    Friend WithEvents btnOriginalBrowseFolders As Button
    Friend WithEvents btnModifiedBrowseFolders As Button
    Friend WithEvents btnModifiedBrowseFiles As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnCreate As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtModID As TextBox
    Friend WithEvents txtModName As TextBox
    Friend WithEvents txtModDependenciesAfter As TextBox
    Friend WithEvents txtModDependenciesBefore As TextBox
    Friend WithEvents txtModVersion As TextBox
    Friend WithEvents txtModAuthor As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents pbProgress As ProgressBar
    Friend WithEvents lblStatus As Label
    Friend WithEvents chbEnableAdd As CheckBox
    Friend WithEvents chbEnableDelete As CheckBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtModDescription As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtGameCode As TextBox
End Class
