Imports System.Security.Cryptography
Imports System.Text.RegularExpressions
Imports SkyEditor.Core.IO
Imports SkyEditor.Core.Utilities

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

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>If this is overridden, do custom work, THEN use MyBase.Build</remarks>
    Public Async Function DoBuild(originalDirectory As String, modifiedDirectory As String, outputModFilename As String, provider As IOProvider) As Task
        IsBuildComplete = False

        Dim modTempFiles = IO.Path.Combine(ModTempDir, "Files")
        Dim modTempTools = IO.Path.Combine(ModTempDir, "Tools")

        Dim patchers As New List(Of FilePatcher)
        Dim actions As New ModJson

        Await Task.Run(Async Function() As Task
                           Me.BuildProgress = 0
                           Me.BuildStatusMessage = My.Resources.Language.LoadingAnalzingFiles
                           'Create the mod
                           '-Find all the files
                           Dim sourceFiles As New Dictionary(Of String, Byte())
                           For Each file In IO.Directory.GetFiles(originalDirectory, "*", IO.SearchOption.AllDirectories)
                               sourceFiles.Add(file.Replace(originalDirectory, "").ToLower, {})
                           Next


                           Dim destFiles As New Dictionary(Of String, Byte())
                           For Each file In IO.Directory.GetFiles(modifiedDirectory, "*", IO.SearchOption.AllDirectories)
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
                                                                     Using source = IO.File.OpenRead(IO.Path.Combine(originalDirectory, hashToCalcSource(c).TrimStart("\")))
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
                                                                     Using dest = IO.File.OpenRead(IO.Path.Combine(modifiedDirectory, hashToCalcDest(c).TrimStart("\")))
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


        actions.DependenciesBefore = modDependenciesBefore
        actions.DependenciesAfter = modDependenciesAfter
        actions.Name = modName
        actions.Author = modAuthor
        actions.Description = modDescription
        actions.UpdateUrl = homepage

        '-Copy and write files
        Await FileSystem.ReCreateDirectory(ModTempDir, provider)

        IO.File.WriteAllText(IO.Path.Combine(ModTempDir, "mod.json"), Json.Serialize(actions))

        Me.BuildProgress = 0
        Me.BuildStatusMessage = My.Resources.Language.LoadingGeneratingPatch

        '--Add files that were added
        For Each item In actions.ToAdd
            Dim fileName = IO.Path.Combine(modifiedDirectory, item.TrimStart("\"))
            'Todo: remove item from toAdd if no longer exists
            If IO.File.Exists(fileName) Then
                If Not IO.Directory.Exists(IO.Path.GetDirectoryName(IO.Path.Combine(modTempFiles, item.TrimStart("\")))) Then
                    IO.Directory.CreateDirectory(IO.Path.GetDirectoryName(IO.Path.Combine(modTempFiles, item.TrimStart("\"))))
                End If
                IO.File.Copy(fileName, IO.Path.Combine(modTempFiles, item.TrimStart("\")), True)
            End If
        Next

        Dim f As New AsyncFor
        Me.BuildStatusMessage = My.Resources.Language.LoadingGeneratingPatch
        Dim onProgressChanged = Sub(sender As Object, e As LoadingStatusChangedEventArgs)
                                    Me.BuildProgress = e.Progress
                                End Sub
        AddHandler f.LoadingStatusChanged, onProgressChanged

        Await f.RunForEach(Of String)(Async Function(Item As String) As Task
                                          Dim patchMade As Boolean = False
                                          'Detect and use appropriate patching program
                                          For Each patcher In CustomFilePatchers
                                              Dim reg As New Regex(patcher.FilePath, RegexOptions.IgnoreCase)
                                              If reg.IsMatch(Item) Then
                                                  If patcher IsNot Nothing AndAlso Not patchers.Contains(patcher) Then
                                                      patchers.Add(patcher)
                                                  End If
                                                  If Not IO.Directory.Exists(IO.Path.GetDirectoryName(IO.Path.Combine(modTempFiles, Item.Trim("\")))) Then
                                                      IO.Directory.CreateDirectory(IO.Path.GetDirectoryName(IO.Path.Combine(modTempFiles, Item.Trim("\"))))
                                                  End If

                                                  Dim oldF As String = IO.Path.Combine(originalDirectory, Item.Trim("\"))
                                                  Dim newF As String = IO.Path.Combine(modifiedDirectory, Item.Trim("\"))
                                                  Dim patchFile As String = IO.Path.Combine(modTempFiles, Item.Trim("\") & "." & patcher.PatchExtension.Trim("*").Trim("."))

                                                  Await ProcessHelper.RunProgram(patcher.CreatePatchProgram, String.Format(patcher.CreatePatchArguments, oldF, newF, patchFile)).ConfigureAwait(False)
                                                  patchMade = True
                                                  Exit For
                                              End If
                                          Next
                                          If Not patchMade Then
                                              'Use xdelta for all other file types
                                              If Not IO.Directory.Exists(IO.Path.GetDirectoryName(IO.Path.Combine(modTempFiles, Item.Trim("\")))) Then
                                                  IO.Directory.CreateDirectory(IO.Path.GetDirectoryName(IO.Path.Combine(modTempFiles, Item.Trim("\"))))
                                              End If
                                              Dim tmpVal As String = Guid.NewGuid.ToString
                                              Dim oldFile As String = IO.Path.Combine(originalDirectory, Item.Trim("\"))
                                              Dim oldFileTemp As String = IO.Path.Combine(EnvironmentPaths.GetResourceName("xdelta"), $"oldFile-{tmpVal}.bin")
                                              Dim newFile As String = IO.Path.Combine(modifiedDirectory, Item.Trim("\"))
                                              Dim newFileTemp As String = IO.Path.Combine(EnvironmentPaths.GetResourceName("xdelta"), $"newFile-{tmpVal}.bin")
                                              Dim deltaFile As String = IO.Path.Combine(modTempFiles, Item.Trim("\") & ".xdelta")
                                              Dim deltaFileTemp As String = IO.Path.Combine(EnvironmentPaths.GetResourceName("xdelta"), $"patch-{tmpVal}.xdelta")
                                              IO.File.Copy(oldFile, oldFileTemp, True)
                                              IO.File.Copy(newFile, newFileTemp, True)
                                              Dim path = IO.Path.Combine(EnvironmentPaths.GetResourceDirectory, "xdelta", "xdelta3.exe")
                                              Await ProcessHelper.RunProgram(IO.Path.Combine(EnvironmentPaths.GetResourceDirectory, "xdelta", "xdelta3.exe"), String.Format("-e -s ""{0}"" ""{1}"" ""{2}""", $"oldFile-{tmpVal}.bin", $"newFile-{tmpVal}.bin", $"patch-{tmpVal}.xdelta")).ConfigureAwait(False)
                                              IO.File.Copy(deltaFileTemp, deltaFile)
                                              IO.File.Delete(deltaFileTemp)
                                              IO.File.Delete(oldFileTemp)
                                              IO.File.Delete(newFileTemp)
                                          End If
                                      End Function, actions.ToUpdate)
        '-Copy Patcher programs for non-standard file formats
        'XDelta will be copied with the modpack
        If Not IO.Directory.Exists(modTempTools) Then
            IO.Directory.CreateDirectory(modTempTools)
        End If
        For Each item In patchers
            If item IsNot Nothing Then
                IO.File.Copy(item.ApplyPatchProgram, IO.Path.Combine(modTempTools, IO.Path.GetFileName(item.ApplyPatchProgram)), True)
            End If
        Next
        Json.SerializeToFile(IO.Path.Combine(modTempTools, "patchers.json"), patchers, provider)

        '-Zip Mod
        Zip.Zip(ModTempDir, outputModFilename)


        Me.BuildProgress = 1
        Me.BuildStatusMessage = My.Resources.Language.Complete

        IsBuildComplete = True
    End Function
End Class
