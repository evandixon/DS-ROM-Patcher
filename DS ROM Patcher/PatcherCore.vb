Public MustInherit Class PatcherCore

#Region "Progress Changed"
    Public Class ProgressChangedEventArgs
        Inherits EventArgs
        Public Property Progress As Single
        Public Property Message As String
        Public Property IsIndeterminate As Boolean
    End Class
    Public Event ProgressChanged(sender As Object, e As ProgressChangedEventArgs)
    Protected Sub RaiseProgressChanged(sender As Object, e As ProgressChangedEventArgs)
        RaiseEvent ProgressChanged(sender, e)
    End Sub
    Protected Sub RaiseProgressChanged(Progress As Single, Message As String, Optional isIndeterminate As Boolean = False)
        Dim e As New ProgressChangedEventArgs
        e.Progress = Progress
        e.Message = Message
        e.IsIndeterminate = isIndeterminate
        RaiseProgressChanged(Me, e)
    End Sub
#End Region

    Public Property SelectedFilename As String

    ''' <summary>
    ''' Prompts the user for a file, then stores the filename in PatcherCore.SelectedFilename
    ''' </summary>
    Public MustOverride Sub PromptFilePath()

    ''' <summary>
    ''' Determines whether or not the ROM located at the path <see cref="SelectedFilename"/> is supported a mod and its modpack.
    ''' </summary>
    Public MustOverride Function SupportsMod(modpack As ModpackInfo, modToCheck As ModJson) As Task(Of Boolean)

    Public MustOverride Function RunPatch(modpack As ModpackInfo, mods As IEnumerable(Of ModJson), Optional destinationPath As String = Nothing) As Task
End Class
