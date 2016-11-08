Imports System.IO
Imports SkyEditor.Core.Utilities

Public Class CreateModWindow
    Public Sub New(patchers As List(Of FilePatcher))

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _CurrentPatchers = patchers
        _FolderDialog = New FolderBrowserDialog
        _OpenFileDialog = New OpenFileDialog
        _OpenFileDialog.Filter = $"{My.Resources.Language.SupportedROMs}|*.nds;*.srl;*.3ds;*.cci;*.cxi;*.cia;|{My.Resources.Language.AllFiles}|*.*"
    End Sub

    Private _CurrentPatchers As List(Of FilePatcher)

    Private _OpenFileDialog As OpenFileDialog

    Private _FolderDialog As FolderBrowserDialog

    Private Property IsBuilding As Boolean
        Get
            Return _isBuilding
        End Get
        Set(value As Boolean)
            _isBuilding = value
        End Set
    End Property
    Dim _isBuilding As Boolean

    Public Property CreatedModFilename As String

#Region "Browse Buttons"
    Private Sub btnOriginalBrowseFiles_Click(sender As Object, e As EventArgs) Handles btnOriginalBrowseFiles.Click
        If _OpenFileDialog.ShowDialog = DialogResult.OK Then
            txtOriginal.Text = _OpenFileDialog.FileName
        End If
    End Sub

    Private Sub btnOriginalBrowseFolders_Click(sender As Object, e As EventArgs) Handles btnOriginalBrowseFolders.Click
        If _FolderDialog.ShowDialog = DialogResult.OK Then
            txtOriginal.Text = _FolderDialog.SelectedPath
        End If
    End Sub

    Private Sub btnModifiedBrowseFiles_Click(sender As Object, e As EventArgs) Handles btnModifiedBrowseFiles.Click
        If _OpenFileDialog.ShowDialog = DialogResult.OK Then
            txtModified.Text = _OpenFileDialog.FileName
        End If
    End Sub

    Private Sub btnModifiedBrowseFolders_Click(sender As Object, e As EventArgs) Handles btnModifiedBrowseFolders.Click
        If _FolderDialog.ShowDialog = DialogResult.OK Then
            txtModified.Text = _FolderDialog.SelectedPath
        End If
    End Sub

#End Region

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
        DialogResult = DialogResult.Cancel
    End Sub

    Private Async Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        Await Build()
        Close()
        DialogResult = DialogResult.OK
    End Sub

    Private Async Function Build() As Task
        IsBuilding = True

        Dim builder As New ModBuilder
        builder.ModID = txtModID.Text
        builder.ModName = txtModName.Text
        builder.ModAuthor = txtModAuthor.Text
        builder.ModDescription = txtModDescription.Text
        builder.ModVersion = txtModVersion.Text
        builder.ModDependenciesBefore = txtModDependenciesBefore.Text.Split(";").ToList
        builder.ModDependenciesAfter = txtModDependenciesAfter.Text.Split(";").ToList
        builder.SupportsAdd = chbEnableAdd.Checked
        builder.SupportsDelete = chbEnableDelete.Checked
        builder.CustomFilePatchers = _CurrentPatchers

        Dim destination As String = Path.Combine(Environment.CurrentDirectory, "Mods", txtModName.Text & " v" & txtModVersion.Text & ".mod")

        AddHandler builder.BuildStatusChanged, AddressOf OnProgressChanged
        Await builder.DoBuild(txtOriginal.Text, txtModified.Text, destination, New WindowsIOProvider)
        RemoveHandler builder.BuildStatusChanged, AddressOf OnProgressChanged

        CreatedModFilename = destination

        IsBuilding = False
    End Function

    Private Sub OnProgressChanged(sender As Object, e As ProgressReportedEventArgs)
        If InvokeRequired Then
            Invoke(Sub() OnProgressChangedInternal(sender, e))
        Else
            OnProgressChangedInternal(sender, e)
        End If
    End Sub

    Private Sub OnProgressChangedInternal(sender As Object, e As ProgressReportedEventArgs)
        pbProgress.Value = e.Progress * pbProgress.Maximum
        lblStatus.Text = e.Message

        If e.IsIndeterminate Then
            pbProgress.Style = ProgressBarStyle.Marquee
        Else
            pbProgress.Style = ProgressBarStyle.Continuous
        End If
    End Sub

End Class