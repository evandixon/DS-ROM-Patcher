Imports System.IO
Imports System.Security.Cryptography
Imports System.Text.RegularExpressions
Imports DS_ROM_Patcher.Utilities
Imports SkyEditor.Core.IO
Imports SkyEditor.Core.Utilities
Imports SkyEditor.Core.Windows.Utilities

Public Class ModBuilder
    Implements IReportProgress

    Public Sub New()
        Me.SupportsAdd = True
        Me.SupportsDelete = False

        CustomFilePatchers = New List(Of FilePatcher)
    End Sub

#Region "Progress"
    Public Event BuildStatusChanged(sender As Object, e As ProgressReportedEventArgs) Implements IReportProgress.ProgressChanged
    Public Event BuildCompleted(sender As Object, e As EventArgs) Implements IReportProgress.Completed

    ''' <summary>
    ''' Gets or sets the progress of the current project's build.
    ''' </summary>
    ''' <returns>A percentage indicating the progression of the build.</returns>
    Public Property BuildProgress As Single Implements IReportProgress.Progress
        Get
            Return _buildProgress
        End Get
        Set(value As Single)
            If _buildProgress <> value Then
                _buildProgress = value
                RaiseEvent BuildStatusChanged(Me, New ProgressReportedEventArgs With {.Progress = BuildProgress, .Message = BuildStatusMessage})
            End If
        End Set
    End Property
    Private _buildProgress As Single

    ''' <summary>
    ''' Gets or sets the current build message.
    ''' </summary>
    ''' <returns>A string indicating what is being done in the build.</returns>
    Public Property BuildStatusMessage As String Implements IReportProgress.Message
        Get
            Return _buildStatusMessage
        End Get
        Set(value As String)
            If _buildStatusMessage <> value Then
                _buildStatusMessage = value
                RaiseEvent BuildStatusChanged(Me, New ProgressReportedEventArgs With {.Progress = BuildProgress, .Message = BuildStatusMessage})
            End If
        End Set
    End Property
    Private _buildStatusMessage As String

    ''' <summary>
    ''' Gets or sets whether or not the build progress is indeterminate.
    ''' </summary>
    ''' <returns>A boolean indicating whether or not the build progress is indeterminate.</returns>
    Public Property IsBuildProgressIndeterminate As Boolean Implements IReportProgress.IsIndeterminate
        Get
            Return _isBuildProgressIndeterminate
        End Get
        Set(value As Boolean)
            If _isBuildProgressIndeterminate <> value Then
                _isBuildProgressIndeterminate = value
                RaiseEvent BuildStatusChanged(Me, New ProgressReportedEventArgs With {.Progress = BuildProgress, .Message = BuildStatusMessage})
            End If
        End Set
    End Property
    Dim _isBuildProgressIndeterminate As Boolean

    Public Property IsBuildComplete As Boolean Implements IReportProgress.IsCompleted
        Get
            Return _isBuildComplete
        End Get
        Set(value As Boolean)
            _isBuildComplete = value

            If _isBuildComplete Then
                RaiseEvent BuildCompleted(Me, New EventArgs)
            End If
        End Set
    End Property
    Dim _isBuildComplete As Boolean
#End Region

    Public Property ModId As String

    Public Property ModName As String

    Public Property ModVersion As String

    Public Property ModAuthor As String

    Public Property ModDescription As String

    Public Property Homepage As String

    Public Property ModDependenciesBefore As List(Of String)

    Public Property ModDependenciesAfter As List(Of String)

    Public Property SupportsAdd As Boolean

    Public Property SupportsDelete As Boolean

    Public Property CustomFilePatchers As List(Of FilePatcher)

    Public Property GameCode As String

    Private ReadOnly Property ModTempDir As String
        Get
            If _modTempDir Is Nothing Then
                _modTempDir = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DS-ROM-Patcher-" & Guid.NewGuid.ToString)
            End If
            Return _modTempDir
        End Get
    End Property
    Dim _modTempDir As String

    Private Function DictionaryContainsValue(dictionary As Dictionary(Of String, Byte()), value As Byte()) As Boolean
        Dim out As Boolean = False
        For Each item In dictionary
            If item.Value.SequenceEqual(value) Then
                out = True
                Exit For
            End If
        Next
        Return out
    End Function

    ''' <remarks>If this is overridden, do custom work, THEN use MyBase.Build</remarks>
    Public Async Function BuildMod(originalDirectory As String, modifiedDirectory As String, outputModFilename As String, provider As IOProvider) As Task
        IsBuildComplete = False

        Dim modTempFiles = Path.Combine(ModTempDir, "Files")
        Dim modTempTools = Path.Combine(ModTempDir, "Tools")

        Dim patchers As New List(Of FilePatcher)
        Dim actions As New ModJson
        actions.DependenciesBefore = ModDependenciesBefore
        actions.DependenciesAfter = ModDependenciesAfter
        actions.ID = ModId
        actions.Name = ModName
        actions.Version = ModVersion
        actions.Author = ModAuthor
        actions.Description = ModDescription
        actions.UpdateUrl = Homepage
        actions.GameCode = GameCode

        Await Task.Run(Async Function() As Task
                           Me.BuildProgress = 0
                           Me.BuildStatusMessage = My.Resources.Language.LoadingAnalzingFiles
                           'Create the mod
                           '-Find all the files
                           Dim sourceFiles As New Dictionary(Of String, Byte())
                           For Each file In Directory.GetFiles(originalDirectory, "*", SearchOption.AllDirectories)
                               sourceFiles.Add(file.Replace(originalDirectory, "").ToLower, {})
                           Next


                           Dim destFiles As New Dictionary(Of String, Byte())
                           For Each file In Directory.GetFiles(modifiedDirectory, "*", SearchOption.AllDirectories)
                               Dim part = file.Replace(modifiedDirectory, "").ToLower
                               If Not file.ToLower.EndsWith(".skyproj") AndAlso Not part.StartsWith("\output") AndAlso Not part.StartsWith("\mod files") Then 'In case the raw files are stored in the project root
                                   destFiles.Add(part, {})
                               End If
                           Next

                           '-Analyze files
                           '(Only calculate hashes for files that exist on both sides, to save on time)
                           'Todo: figure out a faster way of doing this; it's absurdly slow for large numbers of files
                           Dim hashToCalcSource As New List(Of String)
                           Dim hashToCalcDest As New List(Of String)
                           For i = 0 To destFiles.Keys.Count - 1
                               Dim destFile = destFiles.Keys(i)
                               If sourceFiles.Keys.Contains(destFiles.Keys(i)) Then
                                   hashToCalcSource.Add(destFile)
                                   hashToCalcDest.Add(destFile)
                                   Me.BuildProgress = ((i) / (destFiles.Keys.Count))
                               End If
                           Next

                           Me.BuildProgress = 0
                           Me.BuildStatusMessage = My.Resources.Language.LoadingComputingHashes

                           Dim tasks As New List(Of Task)
                           Dim completed As Integer = 0
                           '-Compute the hashes
                           For count = 0 To hashToCalcSource.Count - 1
                               Dim c = count
                               tasks.Add(Task.Run(New Action(Sub()
                                                                 Using h = MD5.Create
                                                                     Me.BuildProgress = completed / (hashToCalcSource.Count + hashToCalcDest.Count)
                                                                     Using source = File.OpenRead(Path.Combine(originalDirectory, hashToCalcSource(c).TrimStart("\")))
                                                                         sourceFiles(hashToCalcSource(c)) = h.ComputeHash(source)
                                                                     End Using
                                                                     completed += 1
                                                                 End Using
                                                             End Sub)))
                           Next

                           For count = 0 To hashToCalcDest.Count - 1
                               Dim c = count
                               tasks.Add(Task.Run(New Action(Sub()
                                                                 Using h = MD5.Create
                                                                     Me.BuildProgress = completed / (hashToCalcSource.Count + hashToCalcDest.Count)
                                                                     Using dest = File.OpenRead(Path.Combine(modifiedDirectory, hashToCalcDest(c).TrimStart("\")))
                                                                         destFiles(hashToCalcDest(c)) = h.ComputeHash(dest)
                                                                     End Using
                                                                     completed += 1
                                                                 End Using
                                                             End Sub)))
                           Next

                           Await Task.WhenAll(tasks)

                           Me.BuildProgress = 0
                           Me.BuildStatusMessage = My.Resources.Language.LoadingComparingFiles
                           '-Analyze the differences
                           For Each item In destFiles.Keys
                               Dim originalFilename As String = ""
                               Dim existsSource As Boolean = sourceFiles.ContainsKey(item)
                               If existsSource Then
                                   'Possible actions: rename, update, none
                                   If sourceFiles(item).SequenceEqual(destFiles(item)) Then
                                       'Do Nothing
                                   Else
                                       'Possible actions: update, rename
                                       If DictionaryContainsValue(sourceFiles, destFiles(item)) Then
                                           actions.ToRename.Add(item, (From s In sourceFiles Where s.Value.SequenceEqual(destFiles(item)) Take 1 Select s.Key).ToList(0))
                                       Else
                                           actions.ToUpdate.Add(item)
                                       End If
                                   End If
                               Else
                                   'Possible actions: add, rename
                                   If DictionaryContainsValue(sourceFiles, destFiles(item)) Then
                                       actions.ToRename.Add(item, (From d In sourceFiles Where d.Value.SequenceEqual(destFiles(item)) Take 1 Select d.Key).ToList(0))
                                   Else
                                       If Me.SupportsAdd Then
                                           actions.ToAdd.Add(item)
                                       End If
                                   End If
                               End If
                           Next

                           If Me.SupportsDelete Then
                               For Each item In sourceFiles.Keys
                                   Dim existsDest As Boolean = destFiles.ContainsKey(item)
                                   If Not existsDest Then
                                       'Possible actions: delete (rename would have been detected in above iteration)
                                       actions.ToDelete.Add(item)
                                   End If
                               Next
                           End If
                       End Function)

        '-Copy and write files
        Await FileSystem.ReCreateDirectory(ModTempDir, provider)

        File.WriteAllText(IO.Path.Combine(ModTempDir, "mod.json"), SkyEditor.Core.Utilities.Json.Serialize(actions))

        Me.BuildProgress = 0
        Me.BuildStatusMessage = My.Resources.Language.LoadingGeneratingPatch

        '-- Add files that were added
        For Each item In actions.ToAdd
            Dim itemTrimmed = item.Trim("\")
            Dim fileName = IO.Path.Combine(modifiedDirectory, itemTrimmed)

            'Create the directory for the file if it doesn't exist
            Dim modTempFilesParentDirectory = Path.GetDirectoryName(Path.Combine(modTempFiles, itemTrimmed))
            If Not Directory.Exists(modTempFilesParentDirectory) Then
                Directory.CreateDirectory(modTempFilesParentDirectory)
            End If

            'Copy the file
            File.Copy(fileName, Path.Combine(modTempFiles, item.TrimStart("\")), True)
        Next

        Dim f As New AsyncFor
        Me.BuildStatusMessage = My.Resources.Language.LoadingGeneratingPatch
        Dim onProgressChanged = Sub(sender As Object, e As LoadingStatusChangedEventArgs)
                                    BuildProgress = e.Progress
                                End Sub
        AddHandler f.LoadingStatusChanged, onProgressChanged

        'TODO: remove
        f.RunSynchronously = True

        Await f.RunForEach(Async Function(Item As String) As Task
                               Dim itemTrimmed = Item.Trim("\")
                               Dim patchMade As Boolean = False

                               'Create the directory for the patch if it doesn't exist
                               Dim modTempFilesParentDirectory = Path.GetDirectoryName(Path.Combine(modTempFiles, itemTrimmed))
                               If Not Directory.Exists(modTempFilesParentDirectory) Then
                                   Directory.CreateDirectory(modTempFilesParentDirectory)
                               End If

                               'Detect and use appropriate patching program
                               For Each patcher In CustomFilePatchers
                                   Dim reg As New Regex(patcher.SerializableInfo.FilePath, RegexOptions.IgnoreCase)
                                   'Determine if there is a patcher that supports a file at the current path
                                   If reg.IsMatch(Item) Then
                                       'If so, add it to the list of patchers if it's not already there
                                       If patcher IsNot Nothing AndAlso Not patchers.Contains(patcher) Then
                                           patchers.Add(patcher)
                                       End If

                                       '- Run the patcher
                                       Dim oldF As String = Path.Combine(originalDirectory, itemTrimmed)
                                       Dim newF As String = Path.Combine(modifiedDirectory, itemTrimmed)
                                       Dim patchFile As String = Path.Combine(modTempFiles, itemTrimmed & "." & patcher.SerializableInfo.PatchExtension.Trim("*").Trim("."))

                                       Await ProcessHelper.RunProgram(patcher.GetCreatePatchProgramPath, String.Format(patcher.SerializableInfo.CreatePatchArguments, oldF, newF, patchFile)).ConfigureAwait(False)
                                       patchMade = True
                                       Exit For 'Stop looking for patchers, we've found one
                                   End If
                               Next

                               'Use xdelta for all other file types
                               If Not patchMade Then
                                   Using xdelta As New xdelta
                                       Dim oldFile As String = Path.Combine(originalDirectory, itemTrimmed)
                                       Dim newFile As String = Path.Combine(modifiedDirectory, itemTrimmed)
                                       Dim deltaFile As String = Path.Combine(modTempFiles, itemTrimmed & ".xdelta")
                                       Await xdelta.CreatePatch(oldFile, newFile, deltaFile)
                                   End Using
                               End If
                           End Function, actions.ToUpdate)

        '-Copy Patcher programs for non-standard file formats (xdelta will be copied with the modpack)
        '-- Create the tools directory if it doesn't exist
        If Not Directory.Exists(modTempTools) Then
            Directory.CreateDirectory(modTempTools)
        End If
        '- Copy the patchers
        For Each item In patchers
            If item IsNot Nothing Then
                item.CopyToolsToDirectory(modTempTools)
            End If
        Next
        '- Serialize the list of patchers
        FilePatcher.SerializePatherListToFile(patchers, Path.Combine(modTempTools, "patchers.json"), provider)

        '- Zip Mod
        Zip.Zip(ModTempDir, outputModFilename)

        '- Cleanup
        Directory.Delete(ModTempDir, True)
        _modTempDir = Nothing

        'Report completion
        BuildProgress = 1
        BuildStatusMessage = My.Resources.Language.Complete
        IsBuildComplete = True
    End Function

    ''' <summary>
    ''' Copies the patcher program (aka the code library/program that contains this function) to the given directory.
    ''' </summary>
    Public Shared Sub CopyPatcherProgram(modpackDirectory As String)
        Dim currentAssembly = GetType(ModBuilder).Assembly
        Dim referenced = WindowsReflectionHelpers.GetAssemblyDependencies(currentAssembly)
        For Each item In referenced.Concat({currentAssembly.Location})
            File.Copy(item, Path.Combine(modpackDirectory, Path.GetFileName(item)))
        Next
    End Sub

    Public Shared Sub CopyMod(modFilename As String, modpackDirectory As String, Optional overwrite As Boolean = True)
        Dim modsDir = Path.Combine(modpackDirectory, "Mods")
        If Not Directory.Exists(modsDir) Then
            Directory.CreateDirectory(modsDir)
        End If

        File.Copy(modFilename, Path.Combine(modsDir, Path.GetFileName(modFilename)), overwrite)
    End Sub

    Public Shared Sub ZipModpack(modpackDirectory As String, zipFilename As String)
        Zip.Zip(modpackDirectory, zipFilename)
    End Sub

    Public Shared Function GetModpackInfo(modpackDirectory As String) As ModpackInfo
        Dim modpackInfoFilename = Path.Combine(modpackDirectory, "Mods", "Modpack.json")
        If File.Exists(modpackInfoFilename) Then
            Return SkyEditor.Core.Windows.Utilities.Json.DeserializeFromFile(Of ModpackInfo)(modpackInfoFilename)
        Else
            Return New ModpackInfo
        End If
    End Function

    Public Shared Sub SaveModpackInfo(modpackDirectory As String, info As ModpackInfo)
        Dim modpackInfoFilename = Path.Combine(modpackDirectory, "Mods", "Modpack.json")
        SkyEditor.Core.Windows.Utilities.Json.SerializeToFile(modpackInfoFilename, info)
    End Sub
End Class
