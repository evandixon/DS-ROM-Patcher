<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtInput = New System.Windows.Forms.TextBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.chbMods = New System.Windows.Forms.CheckedListBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.btnPatch = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.pbProgress = New System.Windows.Forms.ToolStripProgressBar()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.menuMain = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportPatcherPackToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportPatcherPackToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateModToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.chbDesignMode = New System.Windows.Forms.CheckBox()
        Me.EditMetadataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.menuMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Input: "
        '
        'txtInput
        '
        Me.txtInput.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInput.Location = New System.Drawing.Point(50, 29)
        Me.txtInput.Name = "txtInput"
        Me.txtInput.ReadOnly = True
        Me.txtInput.Size = New System.Drawing.Size(311, 20)
        Me.txtInput.TabIndex = 1
        '
        'btnBrowse
        '
        Me.btnBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowse.Location = New System.Drawing.Point(367, 27)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowse.TabIndex = 2
        Me.btnBrowse.Text = "Browse..."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.SplitContainer1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(433, 260)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Mods"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 16)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.chbMods)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtDescription)
        Me.SplitContainer1.Size = New System.Drawing.Size(427, 241)
        Me.SplitContainer1.SplitterDistance = 185
        Me.SplitContainer1.TabIndex = 2
        '
        'chbMods
        '
        Me.chbMods.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chbMods.FormattingEnabled = True
        Me.chbMods.Location = New System.Drawing.Point(0, 0)
        Me.chbMods.Name = "chbMods"
        Me.chbMods.Size = New System.Drawing.Size(185, 241)
        Me.chbMods.TabIndex = 0
        '
        'txtDescription
        '
        Me.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDescription.Location = New System.Drawing.Point(0, 0)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ReadOnly = True
        Me.txtDescription.Size = New System.Drawing.Size(238, 241)
        Me.txtDescription.TabIndex = 2
        '
        'btnPatch
        '
        Me.btnPatch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPatch.Location = New System.Drawing.Point(8, 322)
        Me.btnPatch.Name = "btnPatch"
        Me.btnPatch.Size = New System.Drawing.Size(75, 23)
        Me.btnPatch.TabIndex = 7
        Me.btnPatch.Text = "Patch"
        Me.btnPatch.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.pbProgress, Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 348)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(457, 22)
        Me.StatusStrip1.TabIndex = 8
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'pbProgress
        '
        Me.pbProgress.Name = "pbProgress"
        Me.pbProgress.Size = New System.Drawing.Size(100, 16)
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(39, 17)
        Me.lblStatus.Text = "Ready"
        '
        'menuMain
        '
        Me.menuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ModsToolStripMenuItem})
        Me.menuMain.Location = New System.Drawing.Point(0, 0)
        Me.menuMain.Name = "menuMain"
        Me.menuMain.Size = New System.Drawing.Size(457, 24)
        Me.menuMain.TabIndex = 9
        Me.menuMain.Text = "MenuStrip1"
        Me.menuMain.Visible = False
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportPatcherPackToolStripMenuItem, Me.ExportPatcherPackToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(64, 20)
        Me.FileToolStripMenuItem.Text = "&Patchers"
        '
        'ImportPatcherPackToolStripMenuItem
        '
        Me.ImportPatcherPackToolStripMenuItem.Name = "ImportPatcherPackToolStripMenuItem"
        Me.ImportPatcherPackToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.ImportPatcherPackToolStripMenuItem.Text = "&Import Patcher Pack"
        '
        'ExportPatcherPackToolStripMenuItem
        '
        Me.ExportPatcherPackToolStripMenuItem.Name = "ExportPatcherPackToolStripMenuItem"
        Me.ExportPatcherPackToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.ExportPatcherPackToolStripMenuItem.Text = "&Export Patcher Pack"
        '
        'ModsToolStripMenuItem
        '
        Me.ModsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CreateModToolStripMenuItem, Me.EditMetadataToolStripMenuItem})
        Me.ModsToolStripMenuItem.Name = "ModsToolStripMenuItem"
        Me.ModsToolStripMenuItem.Size = New System.Drawing.Size(69, 20)
        Me.ModsToolStripMenuItem.Text = "&Modpack"
        '
        'CreateModToolStripMenuItem
        '
        Me.CreateModToolStripMenuItem.Name = "CreateModToolStripMenuItem"
        Me.CreateModToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CreateModToolStripMenuItem.Text = "&Create Mod"
        '
        'chbDesignMode
        '
        Me.chbDesignMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chbDesignMode.AutoSize = True
        Me.chbDesignMode.Location = New System.Drawing.Point(353, 319)
        Me.chbDesignMode.Name = "chbDesignMode"
        Me.chbDesignMode.Size = New System.Drawing.Size(89, 17)
        Me.chbDesignMode.TabIndex = 10
        Me.chbDesignMode.Text = "Design Mode"
        Me.chbDesignMode.UseVisualStyleBackColor = True
        '
        'EditMetadataToolStripMenuItem
        '
        Me.EditMetadataToolStripMenuItem.Name = "EditMetadataToolStripMenuItem"
        Me.EditMetadataToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.EditMetadataToolStripMenuItem.Text = "&Edit Metadata"
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(457, 370)
        Me.Controls.Add(Me.chbDesignMode)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.menuMain)
        Me.Controls.Add(Me.btnPatch)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.txtInput)
        Me.Controls.Add(Me.Label1)
        Me.MainMenuStrip = Me.menuMain
        Me.Name = "Form2"
        Me.Text = "{0} Patcher v{1}"
        Me.GroupBox1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.menuMain.ResumeLayout(False)
        Me.menuMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtInput As TextBox
    Friend WithEvents btnBrowse As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents chbMods As CheckedListBox
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents btnPatch As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents pbProgress As ToolStripProgressBar
    Friend WithEvents lblStatus As ToolStripStatusLabel
    Friend WithEvents menuMain As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents chbDesignMode As CheckBox
    Friend WithEvents ImportPatcherPackToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExportPatcherPackToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ModsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CreateModToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditMetadataToolStripMenuItem As ToolStripMenuItem
End Class
