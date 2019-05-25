Imports System.IO
Imports DS_ROM_Patcher.Analysis
Imports DS_ROM_Patcher.Utilities
Imports SkyEditor.Core.IO
Imports SkyEditor.Core.Utilities
Imports SkyEditor.IO.FileSystem

Public Class ModFile
    Public Sub New(Filename As String)
        Dim provider As New PhysicalFileSystem
        Me.ModDetails = Json.DeserializeFromFile(Of ModJson)(Filename, provider)
        Me.ID = Me.ModDetails.ID
        Me.Name = Me.ModDetails.Name
        Me.Patched = False
        Me.Filename = Filename

        'Load patchers.json
        Dim toolsDir = Path.Combine(Path.GetDirectoryName(Filename), "Tools")
        Dim patchersPath = IO.Path.Combine(toolsDir, "patchers.json")
        If IO.File.Exists(patchersPath) Then
            ModLevelPatchers = FilePatcher.DeserializePatcherList(patchersPath, toolsDir)
        End If
    End Sub

    Public Property ModDetails As ModJson
    Public Property ID As String
    Public Property Name As String
    Public Property Patched As Boolean
    Public Property Filename As String
    Public Property ModLevelPatchers As List(Of FilePatcher)
    Private ReadOnly Property FilesPath As String
        Get
            Return Path.Combine(Path.GetDirectoryName(Filename), "Files")
        End Get
    End Property


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="modpackDirectory"></param>
    ''' <param name="romDirectory"></param>
    ''' <param name="patchers"></param>
    ''' <returns></returns>
    Public Function AnalyzeMod(modpackDirectory As String, romDirectory As String, patchers As List(Of FilePatcher)) As ModAnalysisResult
        Dim modResult As New ModAnalysisResult

        'Update analysis
        If ModDetails.ToUpdate IsNot Nothing Then
            For Each file In ModDetails.ToUpdate
                Dim fileTrimmed As String = file.TrimStart("\")
                If IO.File.Exists(Path.Combine(romDirectory, fileTrimmed)) Then
                    Dim fileResults As New FilePatchAnalysisResult
                    fileResults.SourceFile = fileTrimmed

                    Dim patches = Directory.GetFiles(Path.GetDirectoryName(Path.Combine(FilesPath, fileTrimmed)), Path.GetFileName(fileTrimmed) & "*")

                    For Each patchFile In patches
                        Dim relativePath As String = patchFile.Replace(FilesPath, "").TrimStart("\")
                        Dim possiblePatchers As New List(Of FilePatcher) ' = (From p In patchers Where p.PatchExtension = IO.Path.GetExtension(patchFile) Select p).ToList
                        Dim chosenPatcher As FilePatcher
                        Dim isPatcherChosen As Boolean
                        'Load pack level patchers
                        For Each p In patchers
                            If p.SerializableInfo.PatchExtension = Path.GetExtension(patchFile).Trim(".") Then
                                possiblePatchers.Add(p)
                            End If
                        Next

                        'Load mod level patchers
                        For Each p In ModLevelPatchers
                            If "." & p.SerializableInfo.PatchExtension = Path.GetExtension(patchFile) Then
                                possiblePatchers.Add(p)
                            End If
                        Next

                        If possiblePatchers.Count = 0 Then
                            If Path.GetExtension(patchFile) = ".xdelta" Then
                                chosenPatcher = Nothing
                                isPatcherChosen = True
                            Else
                                'Do nothing, we don't have the tools to deal with this patch
                                isPatcherChosen = False
                                chosenPatcher = Nothing
                            End If
                        ElseIf possiblePatchers.Count >= 1 Then
                            chosenPatcher = possiblePatchers.First
                            isPatcherChosen = True
                        Else
                            Throw New Exception("possiblePatchers has a count that's less than 0.")
                        End If

                        If isPatcherChosen Then
                            fileResults.Patches.Add(relativePath, chosenPatcher)
                        Else
                            fileResults.MissingPatchers.Add(relativePath)
                        End If

                    Next

                    modResult.Files.Add(fileResults)
                End If
            Next
        End If
        Return modResult
    End Function

    ''' <summary>
    ''' Applies a patch
    ''' </summary>
    ''' <param name="currentDirectory"></param>
    ''' <param name="tempDirectory"></param>
    ''' <param name="ROMDirectory"></param>
    ''' <param name="patchers"></param>
    ''' <returns>A list of file paths that are modified</returns>
    Public Async Function ApplyPatch(currentDirectory As String, tempDirectory As String, ROMDirectory As String, patchers As List(Of FilePatcher)) As Task(Of List(Of String))
        Dim filesModified As New List(Of String)
        Dim analysis = AnalyzeMod(currentDirectory, ROMDirectory, patchers)
        Using xdelta As New xdelta
            Dim renameTemp = IO.Path.Combine(currentDirectory, "Tools", "renametemp")
            If ModDetails.ToAdd IsNot Nothing Then
                For Each file In ModDetails.ToAdd
                    IO.File.Copy(IO.Path.Combine(IO.Path.GetDirectoryName(Filename), "Files", file.Trim("\")), Path.Combine(ROMDirectory, file.Trim("\")), True)
                Next
            End If

            If ModDetails.ToUpdate IsNot Nothing Then
                For Each fileAnalysis In analysis.Files
                    Dim sourceFile = fileAnalysis.SourceFile
                    filesModified.Add(sourceFile)
                    For Each patch In fileAnalysis.Patches
                        Dim patchFile = Path.Combine(FilesPath, patch.Key)
                        Dim patcher = patch.Value
                        Dim tempFilename As String = Path.Combine(tempDirectory, "tempFile")

                        'Run the patcher
                        If patcher Is Nothing Then
                            'Patch with XDelta
                            Await xdelta.ApplyPatch(Path.Combine(ROMDirectory, sourceFile), patchFile, tempFilename)
                        Else
                            'Patch with given patcher
                            Await ProcessHelper.RunProgram(patcher.GetApplyPatchProgramPath, String.Format(patcher.SerializableInfo.ApplyPatchArguments, IO.Path.Combine(ROMDirectory, sourceFile), patchFile, tempFilename))
                        End If

                        'Copy temp file to target location
                        If Not IO.File.Exists(tempFilename) Then
                            MessageBox.Show("Unable to patch file """ & sourceFile & """.  Please ensure you're using a supported ROM.  If you sure you are, report this to the mod author.")
                        Else
                            File.Copy(tempFilename, IO.Path.Combine(ROMDirectory, sourceFile), True)
                            File.Delete(tempFilename)
                        End If
                    Next
                Next
            End If

            If ModDetails.ToRename IsNot Nothing Then
                'Create temporary directory
                If Not IO.Directory.Exists(renameTemp) Then
                    IO.Directory.CreateDirectory(renameTemp)
                End If

                'Move to a temporary directory (so swapping files works)
                For Each file In ModDetails.ToRename
                    CopyFile(IO.Path.Combine(ROMDirectory, file.Key.Trim("\")), IO.Path.Combine(renameTemp, file.Key.Trim("\")), True)
                Next

                'Rename the things
                For Each file In ModDetails.ToRename
                    Dim dest = Path.Combine(ROMDirectory, file.Value.Trim("\"))
                    filesModified.Add(dest)
                    CopyFile(Path.Combine(renameTemp, file.Key.Trim("\")), dest, True)
                Next
            End If

            If ModDetails.ToDelete IsNot Nothing Then
                For Each file In ModDetails.ToDelete
                    If IO.File.Exists(IO.Path.Combine(ROMDirectory, file.Trim("\"))) Then
                        IO.File.Delete(IO.Path.Combine(ROMDirectory, file.Trim("\")))
                    End If
                Next
            End If

            If IO.Directory.Exists(renameTemp) Then IO.Directory.Delete(renameTemp, True)

            Patched = True
        End Using
        Return filesModified
    End Function

    ''' <summary>
    ''' Applies a patch
    ''' </summary>
    ''' <param name="Mods">All of the available mods to be applied</param>
    ''' <param name="ModFile">The mod to apply</param>
    ''' <param name="currentDirectory"></param>
    ''' <param name="tempDirectory"></param>
    ''' <param name="ROMDirectory"></param>
    ''' <param name="patchers"></param>
    ''' <returns>A list of file paths that were modified</returns>
    Public Shared Async Function ApplyPatch(Mods As List(Of ModFile), ModFile As ModFile, currentDirectory As String, tempDirectory As String, ROMDirectory As String, patchers As List(Of FilePatcher)) As Task(Of List(Of String))
        If Not ModFile.Patched Then
            Dim filesModified As New List(Of String)

            'Patch depencencies
            If ModFile.ModDetails.DependenciesBefore IsNot Nothing Then
                For Each item In ModFile.ModDetails.DependenciesBefore
                    Dim q = From m In Mods Where m.ID = item AndAlso Not String.IsNullOrEmpty(m.ID)

                    For Each d In q
                        filesModified.AddRange(Await ApplyPatch(Mods, d, currentDirectory, tempDirectory, ROMDirectory, patchers))
                    Next
                Next
            End If

            filesModified.AddRange(Await ModFile.ApplyPatch(currentDirectory, tempDirectory, ROMDirectory, patchers))

            'Patch dependencies
            If ModFile.ModDetails.DependenciesBefore IsNot Nothing Then
                For Each item In ModFile.ModDetails.DependenciesAfter
                    Dim q = From m In Mods Where m.ID = item AndAlso Not String.IsNullOrEmpty(m.ID)

                    For Each d In q
                        filesModified.AddRange(Await ApplyPatch(Mods, d, currentDirectory, tempDirectory, ROMDirectory, patchers))
                    Next
                Next
            End If
            Return filesModified
        Else
            Return New List(Of String)
        End If
    End Function

    ''' <summary>
    ''' Applies patches to a directory.
    ''' </summary>
    ''' <param name="mods">The mods to apply.</param>
    ''' <param name="patchers">The modpack-level patchers used to apply patches.</param>
    ''' <param name="modpackDirectory">The directory of the modpack.  This is <see cref="Environment.CurrentDirectory"/> if called from the DS-ROM-Patcher.</param>
    ''' <param name="romDirectory">The unpacked ROM.</param>
    ''' <returns>A list of relative file paths that were modified</returns>
    Public Shared Async Function ApplyPatches(mods As List(Of ModFile), patchers As List(Of FilePatcher), modpackDirectory As String, tempDirectory As String, romDirectory As String) As Task(Of List(Of String))
        Dim filesModified As New List(Of String)
        For Each item In mods
            filesModified.AddRange(Await ModFile.ApplyPatch(mods, item, modpackDirectory, tempDirectory, romDirectory, patchers))
        Next
        Return filesModified.Distinct().ToList()
    End Function

    Public Shared Sub CopyFile(OriginalFilename As String, NewFilename As String, Overwrite As Boolean)
        If Not Directory.Exists(IO.Path.GetDirectoryName(NewFilename)) Then
            Directory.CreateDirectory(IO.Path.GetDirectoryName(NewFilename))
        End If
        File.Copy(OriginalFilename, NewFilename, Overwrite)
    End Sub
End Class