Public Class ModpackMetadataWindow

    Public Sub New(info As ModpackInfo)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ModpackInfo = info

        With ModpackInfo
            txtName.Text = .Name
            txtShortName.Text = .ShortName
            txtAuthor.Text = .Author
            txtVersion.Text = .Version
            txtSystem.Text = .System
            txtGameCode.Text = .GameCode
        End With
    End Sub

    Public Property ModpackInfo As ModpackInfo

    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim o As New OpenFileDialog
        o.Filter = $"{My.Resources.Language.SupportedROMs}|*.nds;*.srl;*.3ds;*.cci;*.cxi;*.cia;|{My.Resources.Language.AllFiles}|*.*"
        If o.ShowDialog = DialogResult.OK Then
            txtGameCode.Text = Await DotNet3dsToolkit.MetadataReader.GetROMGameID(o.FileName)
        End If
    End Sub

    Private Async Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim f As New FolderBrowserDialog
        If f.ShowDialog = DialogResult.OK Then
            txtGameCode.Text = Await DotNet3dsToolkit.MetadataReader.GetROMGameID(f.SelectedPath)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Close()
        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        With ModpackInfo
            .Name = txtName.Text
            .ShortName = txtShortName.Text
            .Author = txtAuthor.Text
            .Version = txtVersion.Text
            .System = txtSystem.Text
            .GameCode = txtGameCode.Text
        End With

        Close()
        DialogResult = DialogResult.OK
    End Sub
End Class