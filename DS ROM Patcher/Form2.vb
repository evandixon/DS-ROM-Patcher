Imports System.ComponentModel
Imports System.IO
Imports System.Reflection
Imports ICSharpCode.SharpZipLib.Zip
Imports SkyEditor.Core.Utilities

Public Class Form2

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Text = String.Format("{0} Patcher v{1}", "DS", Assembly.GetExecutingAssembly.GetName.Version.ToString)
        core = New NDSand3DSCore
    End Sub
    Private WithEvents core As PatcherCore
    Private Property Mods As List(Of ModJson)
    Private Property Modpack As ModpackInfo

    Private Property IsLoading As Boolean
        Get
            Return _isLoading
        End Get
        Set(value As Boolean)
            _isLoading = value

            btnBrowse.Enabled = Not value
            btnPatch.Enabled = Not value
        End Set
    End Property
    Dim _isLoading As Boolean

    Private Async Sub Form2_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim completed As Integer = 0

        'Filenames
        Dim currentDirectory = Environment.CurrentDirectory
        Dim modTempDirectory = Path.Combine(currentDirectory, "Tools", "modstemp")
        Dim modsDirectory = Path.Combine(currentDirectory, "Mods")
        Dim modpackInfoFilename As String = Path.Combine(modsDirectory, "Modpack.json")

        'Create directories
        If Not Directory.Exists(modsDirectory) Then
            Directory.CreateDirectory(modsDirectory)
        End If
        If Not Directory.Exists(modTempDirectory) Then
            Directory.CreateDirectory(modTempDirectory)
        End If

        'Load modpack info
        If File.Exists(modpackInfoFilename) Then
            Modpack = Json.Deserialize(Of ModpackInfo)(File.ReadAllText(modpackInfoFilename))
        Else
            Modpack = New ModpackInfo
        End If

        'Unpack Mods
        If Directory.Exists(modsDirectory) Then
            Dim modFiles = Directory.GetFiles(modsDirectory, "*.mod", SearchOption.TopDirectoryOnly)

            lblStatus.Text = "Unpacking Mods..."
            For Each item In modFiles
                pbProgress.Value = completed / modFiles.Count

                Dim z As New FastZip
                If Not IO.Directory.Exists(IO.Path.Combine(modTempDirectory, IO.Path.GetFileNameWithoutExtension(item))) Then
                    IO.Directory.CreateDirectory(IO.Path.Combine(modTempDirectory, IO.Path.GetFileNameWithoutExtension(item)))
                End If
                z.ExtractZip(item, IO.Path.Combine(modTempDirectory, IO.Path.GetFileNameWithoutExtension(item)), ".*")

                completed += 1
            Next
        End If

        'Load Mods
        Dim modDirs = Directory.GetDirectories(modTempDirectory, "*", IO.SearchOption.TopDirectoryOnly)
        Dim total As Integer = modDirs.Count
        Mods = New List(Of ModJson)

        lblStatus.Text = "Opening Mods..."
        completed = 0

        For Each item In modDirs
            pbProgress.Value = completed / total

            Dim jsonFile = IO.Path.Combine(item, "mod.json")
            If IO.File.Exists(jsonFile) Then
                Dim m = Json.Deserialize(Of ModJson)(IO.File.ReadAllText(jsonFile))
                m.Filename = jsonFile
                Mods.Add(m)
                completed += 1
            Else
                total -= 1
            End If
        Next

        lblStatus.Text = "Ready"

        'Auto-patch, if applicable
        Dim args = Environment.GetCommandLineArgs
        If args.Count > 2 Then
            btnBrowse.Enabled = False
            btnPatch.Enabled = False
            core.SelectedFilename = args(1)
            For Each item In Mods
                If Await core.SupportsMod(Modpack, item) Then
                    chbMods.Items.Add(item, True)
                End If
            Next

            Dim items As New List(Of ModJson)
            For Each item In chbMods.CheckedItems
                items.Add(item)
            Next
            Await core.RunPatch(Modpack, items, args(2))

            Me.Close()
        End If
    End Sub

#Region "Menu Event Handlers"
    Private Sub ImportPatcherPackToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportPatcherPackToolStripMenuItem.Click
        Dim o As New OpenFileDialog
        o.Filter = $"{My.Resources.Language.PatcherPack}|*.dsrppp;*.zip|{My.Resources.Language.AllFiles}|*.*"
        If o.ShowDialog = DialogResult.OK Then
            FilePatcher.ImportCurrentPatcherPack(o.FileName)
        End If
    End Sub

    Private Sub ExportPatcherPackToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportPatcherPackToolStripMenuItem.Click
        Dim s As New SaveFileDialog
        s.Filter = $"{My.Resources.Language.PatcherPack}|*.dsrppp;*.zip|{My.Resources.Language.AllFiles}|*.*"
        If s.ShowDialog = DialogResult.OK Then
            FilePatcher.ExportCurrentPatcherPack(s.FileName)
        End If
    End Sub
#End Region

    Private Async Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        core.PromptFilePath()
        txtInput.Text = core.SelectedFilename

        'Display supported mods
        chbMods.Items.Clear()
        For Each item In Mods
            If Await core.SupportsMod(Modpack, item) Then
                chbMods.Items.Add(item, True)
            End If
        Next
    End Sub

    Private Sub chbMods_SelectedIndexChanged(sender As Object, e As EventArgs) Handles chbMods.SelectedIndexChanged
        If chbMods.SelectedIndex > -1 Then
            txtDescription.Text = DirectCast(chbMods.SelectedItem, ModJson).GetDescription
        End If
    End Sub

    Private Async Sub btnPatch_Click(sender As Object, e As EventArgs) Handles btnPatch.Click
        IsLoading = True

        Dim items As New List(Of ModJson)
        For Each item In chbMods.CheckedItems
            items.Add(item)
        Next
        Await core.RunPatch(Modpack, items)

        IsLoading = False
    End Sub

    Private Sub Form2_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dim currentDirectory = Environment.CurrentDirectory
        Dim modTempDirectory = IO.Path.Combine(currentDirectory, "Tools/modstemp")
        If IO.Directory.Exists(modTempDirectory) Then
            For Each item In IO.Directory.GetDirectories(modTempDirectory, "*", IO.SearchOption.TopDirectoryOnly)
                IO.Directory.Delete(item, True)
            Next
        End If
    End Sub

    Private Sub core_ProgressChanged(sender As Object, e As PatcherCore.ProgressChangedEventArgs) Handles core.ProgressChanged
        If InvokeRequired Then
            Invoke(Sub()
                       lblStatus.Text = e.Message
                       pbProgress.Value = e.Progress
                   End Sub)
        Else
            lblStatus.Text = e.Message
            pbProgress.Value = e.Progress * 100
        End If
    End Sub

    Private Sub chbDesignMode_CheckedChanged(sender As Object, e As EventArgs) Handles chbDesignMode.CheckedChanged
        menuMain.Visible = chbDesignMode.Checked
    End Sub

End Class