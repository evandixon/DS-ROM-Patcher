Imports System.IO
Imports System.Text.RegularExpressions
Imports SkyEditor.Core.Utilities
Imports SkyEditor.Utilities.AsyncFor

Public Class NDSand3DSCore
    Inherits PatcherCore

    Public Overrides Sub PromptFilePath()
        Dim o As New OpenFileDialog
        o.Filter = "Supported Files|*.nds;*.srl;*.3ds;*.3dz;*.cci;*.cxi;*.cia|NDS ROMs|*.nds;*.srl|3DS ROMs|*.3ds;*.3dz;*.cci;*.cxi;*.cia|All Files|*.*"
        If o.ShowDialog = DialogResult.OK Then
            SelectedFilename = o.FileName
        End If
    End Sub

    Public Overrides Async Function RunPatch(modpackDirectory As String, tempDirectory As String, patchers As List(Of FilePatcher), modpack As ModpackInfo, mods As IEnumerable(Of ModFile), Optional destinationPath As String = Nothing) As Task
        Dim args = Environment.GetCommandLineArgs
        Dim toolsDir = Path.Combine(modpackDirectory, "Tools")
        Dim patchersDir = Path.Combine(toolsDir, "Patchers")
        Dim ROMDirectory = Path.Combine(tempDirectory, "dstemp")
        Dim modTempDirectory = Path.Combine(tempDirectory, "modstemp")
        Dim isDirectoryMode As Boolean = False
        Dim outputFormat As DSFormat

        Using c As New DotNet3dsToolkit.Converter
            'Extract the ROM
            If File.Exists(SelectedFilename) Then
                RaiseProgressChanged(0, "Extracting the ROM...")
                If Not IO.Directory.Exists(ROMDirectory) Then
                    IO.Directory.CreateDirectory(ROMDirectory)
                End If

                Await c.ExtractAuto(SelectedFilename, ROMDirectory)
            Else
                'Or copy the raw files if the source is a directory (i.e. already extracted)
                isDirectoryMode = True

                RaiseProgressChanged(0, "Copying Files...")
                Dim tasks As New List(Of Task)
                For Each item In IO.Directory.GetFiles(SelectedFilename, "*", IO.SearchOption.AllDirectories)
                    Dim item2 = item
                    tasks.Add(Task.Run(Sub()
                                           Dim dest As String = item.Replace(SelectedFilename, ROMDirectory)
                                           If Not IO.Directory.Exists(IO.Path.GetDirectoryName(dest)) Then
                                               IO.Directory.CreateDirectory(IO.Path.GetDirectoryName(dest))
                                           End If
                                           IO.File.Copy(item, dest, True)
                                       End Sub))
                Next
                Await Task.WhenAll(tasks)
            End If

            'Apply the Mods
            Const RepackMessage As String = "Applying the mods..."
            RaiseProgressChanged(1 / 3, RepackMessage)
            Dim filesModified = Await ModFile.ApplyPatches(mods, patchers, modpackDirectory, tempDirectory, ROMDirectory)

            'Repack the ROM
            If isDirectoryMode Then
                If args.Contains("-output-nds") Then
                    outputFormat = DSFormat.NDS
                ElseIf args.Contains("-output-3ds") Then
                    If args.Contains("-key0") Then
                        outputFormat = DSFormat.Key0CCI
                    Else
                        outputFormat = DSFormat.DecCCI
                    End If
                ElseIf args.Contains("-output-cia") Then
                    outputFormat = DSFormat.DecCIA
                ElseIf args.Contains("-output-hans") Then
                    outputFormat = DSFormat.HANS
                ElseIf args.Contains("-output-luma") Then
                    outputFormat = DSFormat.Luma
                Else
                    Throw New ApplicationException(My.Resources.Language.ErrorUnknownInputType)
                End If
            Else
                Select Case Await DotNet3dsToolkit.MetadataReader.GetSystem(SelectedFilename)
                    Case DotNet3dsToolkit.SystemType.NDS
                        outputFormat = DSFormat.NDS
                    Case DotNet3dsToolkit.SystemType.ThreeDS
                        outputFormat = DSFormat.Auto3DS
                    Case Else
                        Throw New ApplicationException(My.Resources.Language.ErrorUnknownInputType)
                End Select
            End If

            RaiseProgressChanged(2 / 3, "Repacking the ROM...", True)
            If Not outputFormat = DSFormat.HANS AndAlso String.IsNullOrEmpty(destinationPath) AndAlso Not outputFormat = DSFormat.NDS Then
ShowFormatDialog: Dim formatDialog As New ThreeDSFormatSelector
                If Not formatDialog.ShowDialog = DialogResult.OK Then
                    If MessageBox.Show("Are you sure you want to cancel the patching process?", "DS ROM Patcher", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                        GoTo StopPatching
                    Else
                        GoTo ShowFormatDialog
                    End If
                Else
                    outputFormat = formatDialog.SelectedFormat
                    destinationPath = formatDialog.SelectedPath
                End If
            End If

            '- Watch progress changed event
            Dim handler = Sub(sender As Object, e As ProgressReportedEventArgs)
                              RaiseProgressChanged(2 / 3 + (1 / 3 * e.Progress), "Repacking the ROM...", e.IsIndeterminate)
                          End Sub

            AddHandler c.UnpackProgressed, handler

            '- Build
            Select Case outputFormat
                Case DSFormat.Luma
                    If Directory.Exists(destinationPath) Then
                        Directory.Delete(destinationPath, True)
                    End If
                    Directory.CreateDirectory(destinationPath)

                    Dim titleId = Await DotNet3dsToolkit.MetadataReader.GetGameID(SelectedFilename)
                    Dim baseTargetPath = Path.Combine(destinationPath, "luma", "titles", titleId)
                    For Each file In filesModified
                        Dim sourceFile = Path.Combine(ROMDirectory, file)
                        Dim destFile = Path.Combine(destinationPath, baseTargetPath, file)

                        'Create directory if it doesn't exist
                        Dim destDir = Path.GetDirectoryName(destFile)

                        If Not Directory.Exists(destDir) Then
                            Directory.CreateDirectory(destDir)
                        End If

                        IO.File.Copy(sourceFile, destFile)
                    Next

                    'Move code.bin
                    Dim codeBinExefs = Path.Combine(destinationPath, baseTargetPath, "exefs", "code.bin")
                    If File.Exists(codeBinExefs) Then
                        File.Move(codeBinExefs, Path.Combine(destinationPath, baseTargetPath, "code.bin"))
                    End If
                Case DSFormat.HANS
                    Await c.BuildHans(ROMDirectory, destinationPath, modpack.ShortName)
                Case DSFormat.Auto, DSFormat.Auto3DS
                    Await c.BuildAuto(ROMDirectory, destinationPath)
                Case DSFormat.DecCCI
                    Await c.Build3DSDecrypted(ROMDirectory, destinationPath)
                Case DSFormat.DecCIA
                    Await c.BuildCia(ROMDirectory, destinationPath)
                Case DSFormat.Key0CCI
                    Await c.Build3DS0Key(ROMDirectory, destinationPath)
                Case DSFormat.NDS
                    Await c.BuildNDS(ROMDirectory, destinationPath)
            End Select

            RemoveHandler c.UnpackProgressed, handler

StopPatching: RaiseProgressChanged(1, "Ready")

            'Cleanup
            If Directory.Exists(ROMDirectory) Then Directory.Delete(ROMDirectory, True)
        End Using
    End Function

    Public Overrides Async Function SupportsMod(modpack As ModpackInfo, modToCheck As ModJson) As Task(Of Boolean)
        Dim currentCode = Await DotNet3dsToolkit.MetadataReader.GetGameID(SelectedFilename)
        Dim supportedCode = New Regex(modToCheck.GameCode)
        Return supportedCode.IsMatch(currentCode)
    End Function
End Class
