Public Class ThreeDSFormatSelector



    Public ReadOnly Property SelectedFormat As DSFormat
        Get
            If rbBuildAuto.Checked Then
                Return DSFormat.Auto3DS
            ElseIf rbBuildCCIDec.Checked Then
                Return DSFormat.DecCCI
            ElseIf rbBuildCCI0Key.Checked Then
                Return DSFormat.Key0CCI
            ElseIf rbBuildCIA.Checked Then
                Return DSFormat.DecCIA
            ElseIf rbBuildHANS.Checked Then
                Return DSFormat.HANS
            Else
                'Invalid radio button selection
                'Should be unreachable
                Return DSFormat.Auto
            End If
        End Get
    End Property

    Public ReadOnly Property SelectedPath As String
        Get
            Return txtBuildDestination.Text
        End Get
    End Property

    Private Sub btnBuildOutputBrowse_Click(sender As Object, e As EventArgs) Handles btnBuildOutputBrowse.Click
        If rbBuildHANS.Checked Then
            Dim f As New FolderBrowserDialog
            If f.ShowDialog = DialogResult.OK Then
                txtBuildDestination.Text = f.SelectedPath
            End If
        Else
            Dim s As New SaveFileDialog
            s.Filter = "Decrypted 3DS ROMs|*.3ds;*.cci|CIA files|*.cia|0-Key Encryted 3DS ROMs|*.3dz;*.3ds|Nintendo DS ROMs|*.nds;*.srl|All Files|*.*"
            If s.ShowDialog = DialogResult.OK Then
                txtBuildDestination.Text = s.FileName
            End If
        End If
    End Sub

    Private Sub btnBuild_Click(sender As Object, e As EventArgs) Handles btnBuild.Click
        Close()
        DialogResult = DialogResult.OK
    End Sub
End Class