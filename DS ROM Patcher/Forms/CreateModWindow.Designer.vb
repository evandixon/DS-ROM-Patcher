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
        Me.txtOriginal.Location = New System.Drawing.Point(136, 23)
        Me.txtOriginal.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtOriginal.Name = "txtOriginal"
        Me.txtOriginal.Size = New System.Drawing.Size(532, 31)
        Me.txtOriginal.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 29)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Original:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 81)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 25)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Modified:"
        '
        'txtModified
        '
        Me.txtModified.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtModified.Location = New System.Drawing.Point(136, 75)
        Me.txtModified.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtModified.Name = "txtModified"
        Me.txtModified.Size = New System.Drawing.Size(532, 31)
        Me.txtModified.TabIndex = 3
        '
        'btnOriginalBrowseFiles
        '
        Me.btnOriginalBrowseFiles.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOriginalBrowseFiles.Enabled = False
        Me.btnOriginalBrowseFiles.Location = New System.Drawing.Point(684, 19)
        Me.btnOriginalBrowseFiles.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btnOriginalBrowseFiles.Name = "btnOriginalBrowseFiles"
        Me.btnOriginalBrowseFiles.Size = New System.Drawing.Size(250, 44)
        Me.btnOriginalBrowseFiles.TabIndex = 1
        Me.btnOriginalBrowseFiles.Text = "Browse Files..."
        Me.btnOriginalBrowseFiles.UseVisualStyleBackColor = True
        '
        'btnOriginalBrowseFolders
        '
        Me.btnOriginalBrowseFolders.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOriginalBrowseFolders.Location = New System.Drawing.Point(946, 19)
        Me.btnOriginalBrowseFolders.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btnOriginalBrowseFolders.Name = "btnOriginalBrowseFolders"
        Me.btnOriginalBrowseFolders.Size = New System.Drawing.Size(250, 44)
        Me.btnOriginalBrowseFolders.TabIndex = 2
        Me.btnOriginalBrowseFolders.Text = "Browse Folders..."
        Me.btnOriginalBrowseFolders.UseVisualStyleBackColor = True
        '
        'btnModifiedBrowseFolders
        '
        Me.btnModifiedBrowseFolders.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnModifiedBrowseFolders.Location = New System.Drawing.Point(946, 71)
        Me.btnModifiedBrowseFolders.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btnModifiedBrowseFolders.Name = "btnModifiedBrowseFolders"
        Me.btnModifiedBrowseFolders.Size = New System.Drawing.Size(250, 44)
        Me.btnModifiedBrowseFolders.TabIndex = 5
        Me.btnModifiedBrowseFolders.Text = "Browse Folders..."
        Me.btnModifiedBrowseFolders.UseVisualStyleBackColor = True
        '
        'btnModifiedBrowseFiles
        '
        Me.btnModifiedBrowseFiles.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnModifiedBrowseFiles.Enabled = False
        Me.btnModifiedBrowseFiles.Location = New System.Drawing.Point(684, 71)
        Me.btnModifiedBrowseFiles.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btnModifiedBrowseFiles.Name = "btnModifiedBrowseFiles"
        Me.btnModifiedBrowseFiles.Size = New System.Drawing.Size(250, 44)
        Me.btnModifiedBrowseFiles.TabIndex = 4
        Me.btnModifiedBrowseFiles.Text = "Browse Files..."
        Me.btnModifiedBrowseFiles.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(192, 800)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(150, 44)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnCreate
        '
        Me.btnCreate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCreate.Location = New System.Drawing.Point(30, 800)
        Me.btnCreate.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(150, 44)
        Me.btnCreate.TabIndex = 6
        Me.btnCreate.Text = "Create"
        Me.btnCreate.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.GroupBox1.Location = New System.Drawing.Point(30, 125)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.GroupBox1.Size = New System.Drawing.Size(1166, 460)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Metadata"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 394)
        Me.Label10.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(126, 25)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "Game Code"
        '
        'txtGameCode
        '
        Me.txtGameCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtGameCode.Location = New System.Drawing.Point(286, 388)
        Me.txtGameCode.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtGameCode.Name = "txtGameCode"
        Me.txtGameCode.Size = New System.Drawing.Size(844, 31)
        Me.txtGameCode.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 194)
        Me.Label9.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(120, 25)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Description"
        '
        'txtModDescription
        '
        Me.txtModDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtModDescription.Location = New System.Drawing.Point(286, 188)
        Me.txtModDescription.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtModDescription.Name = "txtModDescription"
        Me.txtModDescription.Size = New System.Drawing.Size(844, 31)
        Me.txtModDescription.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 344)
        Me.Label8.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(215, 25)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Dependencies (After)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 294)
        Me.Label7.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(233, 25)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Dependencies (Before)"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 244)
        Me.Label6.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 25)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Version"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 144)
        Me.Label5.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 25)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Author"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 94)
        Me.Label4.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(151, 25)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Friendly Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 42)
        Me.Label3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 25)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "ID"
        '
        'txtModDependenciesAfter
        '
        Me.txtModDependenciesAfter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtModDependenciesAfter.Location = New System.Drawing.Point(286, 338)
        Me.txtModDependenciesAfter.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtModDependenciesAfter.Name = "txtModDependenciesAfter"
        Me.txtModDependenciesAfter.Size = New System.Drawing.Size(844, 31)
        Me.txtModDependenciesAfter.TabIndex = 6
        '
        'txtModDependenciesBefore
        '
        Me.txtModDependenciesBefore.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtModDependenciesBefore.Location = New System.Drawing.Point(286, 288)
        Me.txtModDependenciesBefore.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtModDependenciesBefore.Name = "txtModDependenciesBefore"
        Me.txtModDependenciesBefore.Size = New System.Drawing.Size(844, 31)
        Me.txtModDependenciesBefore.TabIndex = 5
        '
        'txtModVersion
        '
        Me.txtModVersion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtModVersion.Location = New System.Drawing.Point(286, 238)
        Me.txtModVersion.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtModVersion.Name = "txtModVersion"
        Me.txtModVersion.Size = New System.Drawing.Size(844, 31)
        Me.txtModVersion.TabIndex = 4
        Me.txtModVersion.Text = "1.0.0"
        '
        'txtModAuthor
        '
        Me.txtModAuthor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtModAuthor.Location = New System.Drawing.Point(286, 138)
        Me.txtModAuthor.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtModAuthor.Name = "txtModAuthor"
        Me.txtModAuthor.Size = New System.Drawing.Size(844, 31)
        Me.txtModAuthor.TabIndex = 2
        '
        'txtModName
        '
        Me.txtModName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtModName.Location = New System.Drawing.Point(286, 88)
        Me.txtModName.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtModName.Name = "txtModName"
        Me.txtModName.Size = New System.Drawing.Size(844, 31)
        Me.txtModName.TabIndex = 1
        '
        'txtModID
        '
        Me.txtModID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtModID.Location = New System.Drawing.Point(286, 37)
        Me.txtModID.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtModID.Name = "txtModID"
        Me.txtModID.Size = New System.Drawing.Size(844, 31)
        Me.txtModID.TabIndex = 0
        '
        'pbProgress
        '
        Me.pbProgress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbProgress.Location = New System.Drawing.Point(30, 738)
        Me.pbProgress.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.pbProgress.Maximum = 10000
        Me.pbProgress.Name = "pbProgress"
        Me.pbProgress.Size = New System.Drawing.Size(1166, 44)
        Me.pbProgress.TabIndex = 11
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(24, 708)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(74, 25)
        Me.lblStatus.TabIndex = 12
        Me.lblStatus.Text = "Ready"
        '
        'chbEnableAdd
        '
        Me.chbEnableAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chbEnableAdd.AutoSize = True
        Me.chbEnableAdd.Checked = True
        Me.chbEnableAdd.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbEnableAdd.Location = New System.Drawing.Point(52, 600)
        Me.chbEnableAdd.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.chbEnableAdd.Name = "chbEnableAdd"
        Me.chbEnableAdd.Size = New System.Drawing.Size(166, 29)
        Me.chbEnableAdd.TabIndex = 13
        Me.chbEnableAdd.Text = "Enable Adds"
        Me.chbEnableAdd.UseVisualStyleBackColor = True
        '
        'chbEnableDelete
        '
        Me.chbEnableDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chbEnableDelete.AutoSize = True
        Me.chbEnableDelete.Location = New System.Drawing.Point(52, 644)
        Me.chbEnableDelete.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.chbEnableDelete.Name = "chbEnableDelete"
        Me.chbEnableDelete.Size = New System.Drawing.Size(190, 29)
        Me.chbEnableDelete.TabIndex = 14
        Me.chbEnableDelete.Text = "Enable Deletes"
        Me.chbEnableDelete.UseVisualStyleBackColor = True
        '
        'CreateModWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1222, 867)
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
        Me.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
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
