<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ThreeDSFormatSelector
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
        Me.btnBuild = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbBuildHANS = New System.Windows.Forms.RadioButton()
        Me.rbBuildCCI0Key = New System.Windows.Forms.RadioButton()
        Me.rbBuildCIA = New System.Windows.Forms.RadioButton()
        Me.rbBuildCCIDec = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.rbBuildAuto = New System.Windows.Forms.RadioButton()
        Me.btnBuildOutputBrowse = New System.Windows.Forms.Button()
        Me.txtBuildDestination = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout
        Me.SuspendLayout
        '
        'btnBuild
        '
        Me.btnBuild.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.btnBuild.Location = New System.Drawing.Point(12, 173)
        Me.btnBuild.Name = "btnBuild"
        Me.btnBuild.Size = New System.Drawing.Size(75, 23)
        Me.btnBuild.TabIndex = 20
        Me.btnBuild.Text = "OK"
        Me.btnBuild.UseVisualStyleBackColor = true
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.rbBuildHANS)
        Me.GroupBox2.Controls.Add(Me.rbBuildCCI0Key)
        Me.GroupBox2.Controls.Add(Me.rbBuildCIA)
        Me.GroupBox2.Controls.Add(Me.rbBuildCCIDec)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.rbBuildAuto)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 32)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(444, 135)
        Me.GroupBox2.TabIndex = 19
        Me.GroupBox2.TabStop = false
        Me.GroupBox2.Text = "Options"
        '
        'rbBuildHANS
        '
        Me.rbBuildHANS.AutoSize = true
        Me.rbBuildHANS.Location = New System.Drawing.Point(119, 109)
        Me.rbBuildHANS.Name = "rbBuildHANS"
        Me.rbBuildHANS.Size = New System.Drawing.Size(55, 17)
        Me.rbBuildHANS.TabIndex = 6
        Me.rbBuildHANS.TabStop = true
        Me.rbBuildHANS.Text = "HANS"
        Me.rbBuildHANS.UseVisualStyleBackColor = true
        '
        'rbBuildCCI0Key
        '
        Me.rbBuildCCI0Key.AutoSize = true
        Me.rbBuildCCI0Key.Location = New System.Drawing.Point(119, 63)
        Me.rbBuildCCI0Key.Name = "rbBuildCCI0Key"
        Me.rbBuildCCI0Key.Size = New System.Drawing.Size(189, 17)
        Me.rbBuildCCI0Key.TabIndex = 4
        Me.rbBuildCCI0Key.Text = "0-Key Encrypted CCI (for Gateway)"
        Me.rbBuildCCI0Key.UseVisualStyleBackColor = true
        '
        'rbBuildCIA
        '
        Me.rbBuildCIA.AutoSize = true
        Me.rbBuildCIA.Location = New System.Drawing.Point(119, 86)
        Me.rbBuildCIA.Name = "rbBuildCIA"
        Me.rbBuildCIA.Size = New System.Drawing.Size(94, 17)
        Me.rbBuildCIA.TabIndex = 3
        Me.rbBuildCIA.Text = "Decrypted CIA"
        Me.rbBuildCIA.UseVisualStyleBackColor = true
        '
        'rbBuildCCIDec
        '
        Me.rbBuildCCIDec.AutoSize = true
        Me.rbBuildCCIDec.Location = New System.Drawing.Point(119, 40)
        Me.rbBuildCCIDec.Name = "rbBuildCCIDec"
        Me.rbBuildCCIDec.Size = New System.Drawing.Size(322, 17)
        Me.rbBuildCCIDec.TabIndex = 2
        Me.rbBuildCCIDec.Text = "Decrypted CCI (for Citra or Sky 3DS/Gateway+CFW+Decrypt9)"
        Me.rbBuildCCIDec.UseVisualStyleBackColor = true
        '
        'Label4
        '
        Me.Label4.AutoSize = true
        Me.Label4.Location = New System.Drawing.Point(6, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Output ROM Format:"
        '
        'rbBuildAuto
        '
        Me.rbBuildAuto.AutoSize = true
        Me.rbBuildAuto.Checked = true
        Me.rbBuildAuto.Location = New System.Drawing.Point(119, 17)
        Me.rbBuildAuto.Name = "rbBuildAuto"
        Me.rbBuildAuto.Size = New System.Drawing.Size(81, 17)
        Me.rbBuildAuto.TabIndex = 0
        Me.rbBuildAuto.TabStop = true
        Me.rbBuildAuto.Text = "Auto (ROM)"
        Me.rbBuildAuto.UseVisualStyleBackColor = true
        '
        'btnBuildOutputBrowse
        '
        Me.btnBuildOutputBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnBuildOutputBrowse.Location = New System.Drawing.Point(384, 4)
        Me.btnBuildOutputBrowse.Name = "btnBuildOutputBrowse"
        Me.btnBuildOutputBrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnBuildOutputBrowse.TabIndex = 18
        Me.btnBuildOutputBrowse.Text = "Browse..."
        Me.btnBuildOutputBrowse.UseVisualStyleBackColor = true
        '
        'txtBuildDestination
        '
        Me.txtBuildDestination.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtBuildDestination.Location = New System.Drawing.Point(85, 6)
        Me.txtBuildDestination.Name = "txtBuildDestination"
        Me.txtBuildDestination.Size = New System.Drawing.Size(293, 20)
        Me.txtBuildDestination.TabIndex = 17
        '
        'Label5
        '
        Me.Label5.AutoSize = true
        Me.Label5.Location = New System.Drawing.Point(12, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Output Path:"
        '
        'ThreeDSFormatSelector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(471, 208)
        Me.Controls.Add(Me.btnBuild)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnBuildOutputBrowse)
        Me.Controls.Add(Me.txtBuildDestination)
        Me.Controls.Add(Me.Label5)
        Me.Name = "ThreeDSFormatSelector"
        Me.Text = "3DS Format Selector"
        Me.GroupBox2.ResumeLayout(false)
        Me.GroupBox2.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents btnBuild As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents rbBuildHANS As RadioButton
    Friend WithEvents rbBuildCCI0Key As RadioButton
    Friend WithEvents rbBuildCIA As RadioButton
    Friend WithEvents rbBuildCCIDec As RadioButton
    Friend WithEvents Label4 As Label
    Friend WithEvents rbBuildAuto As RadioButton
    Friend WithEvents btnBuildOutputBrowse As Button
    Friend WithEvents txtBuildDestination As TextBox
    Friend WithEvents Label5 As Label
End Class
