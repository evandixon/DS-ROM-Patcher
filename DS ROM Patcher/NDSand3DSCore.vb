Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Web.Script.Serialization

Public Class NDSand3DSCore
    Inherits PatcherCore

    Public Overrides Sub PromptFilePath()
        Dim o As New OpenFileDialog
        o.Filter = "Supported Files|*.nds;*.srl;*.3ds;*.3dz;*.cci;*.cxi;*.cia|NDS ROMs|*.nds;*.srl|3DS ROMs|*.3ds;*.3dz;*.cci;*.cxi;*.cia|All Files|*.*"
        If o.ShowDialog = DialogResult.OK Then
            SelectedFilename = o.FileName
        End If
    End Sub

    Public Overrides Async Function RunPatch(modpack As ModpackInfo, mods As IEnumerable(Of ModJson), Optional destinationPath As String = Nothing) As Task
        Dim j As New JavaScriptSerializer
        Dim currentDirectory = Environment.CurrentDirectory
        Dim args = Environment.GetCommandLineArgs
        Dim ROMDirectory = Path.Combine(currentDirectory, "Tools/dstemp")
        Dim modTempDirectory = Path.Combine(currentDirectory, "Tools/modstemp")
        Dim isDirectoryMode As Boolean = False
        Dim isHansMode As Boolean = False
        Dim isKey0CCIMode As Boolean = False

        Using c As New DotNet3dsToolkit.Converter
            'Extract the ROM
            If IO.File.Exists(SelectedFilename) Then
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

            Dim patchers = j.Deserialize(Of List(Of FilePatcher))(IO.File.ReadAllText(IO.Path.Combine(currentDirectory, "Tools", "patchers.json")))
            Dim modFiles As New List(Of ModFile)
            For Each item In mods
                modFiles.Add(New ModFile(item.Filename))
            Next

            For Each item In modFiles
                Await ModFile.ApplyPatch(modFiles, item, currentDirectory, ROMDirectory, patchers)
            Next

            'Repack the ROM
            Dim sourceExt As String = ""

            If isDirectoryMode Then
                If args.Contains("-source-nds") Then
                    sourceExt = ".nds"
                ElseIf args.Contains("-source-3ds") Then
                    If args.Contains("-key0") Then
                        isKey0CCIMode = True
                    End If
                    sourceExt = ".3ds"
                ElseIf args.Contains("-source-cia") Then
                    sourceExt = ".cia"
                ElseIf args.Contains("-source-cxi") Then
                    isHansMode = True
                Else
                    Throw New ApplicationException("Unable to detect the source ROM type.  Please use one of the following command-line arguments when using a directory as the source: -source-nds, -source-3ds, -source-cia, or -source-cxi")
                End If
            Else
                sourceExt = Path.GetExtension(SelectedFilename).ToLower
            End If

            RaiseProgressChanged(2 / 3, "Repacking the ROM...", True)
            If Not isHansMode AndAlso String.IsNullOrEmpty(destinationPath) AndAlso Not sourceExt = ".nds" AndAlso Not sourceExt = ".srl" Then
                If MessageBox.Show("Would you like to output to HANS?  (Say no to output to .3DS or .CIA)", "DS ROM Patcher", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    isHansMode = True
                End If
            End If

            If isHansMode OrElse sourceExt = ".cxi" Then
                If String.IsNullOrEmpty(destinationPath) Then
                    Dim d As New FolderBrowserDialog
                    d.Description = "Please select the root of your SD card."
ShowFolderDialog3DS: If d.ShowDialog = DialogResult.OK Then
                        destinationPath = d.SelectedPath
                    Else
                        If MessageBox.Show("Are you sure you want to cancel the patching process?", "DS ROM Patcher", MessageBoxButtons.YesNo) = DialogResult.No Then
                            GoTo ShowFolderDialog3DS
                        End If
                    End If
                End If

                Await c.BuildHans(ROMDirectory, destinationPath, modpack.ShortName)
            Else
                If String.IsNullOrEmpty(destinationPath) Then
ShowSaveDialogNDS:  Dim s As New SaveFileDialog
                    Select Case sourceExt
                        Case ".nds", ".srl"
                            s.Filter = "NDS ROMs|*.nds;*.srl|All Files|*.*"
                        Case ".3ds", ".cia"
                            s.Filter = "3DS ROMs|*.3ds;*.3dz;*.cci|CIA Files|*.cia|All Files|*.*"
                            If sourceExt = ".cia" Then
                                s.FilterIndex = 1
                            End If
                        Case Else
                            s.Filter = "All Files|*.*"
                    End Select
                    If s.ShowDialog = DialogResult.OK Then
                        destinationPath = s.FileName
                    Else
                        If MessageBox.Show("Are you sure you want to cancel the patching process?", "DS ROM Patcher", MessageBoxButtons.YesNo) = DialogResult.No Then
                            GoTo ShowSaveDialogNDS
                        End If
                    End If
                End If

                'Todo: watch progress changed event
                Await c.BuildAuto(ROMDirectory, destinationPath)
            End If
            RaiseProgressChanged(1, "Ready")

            'Cleanup
            If IO.Directory.Exists(ROMDirectory) Then IO.Directory.Delete(ROMDirectory, True)
        End Using
    End Function

    Public Overrides Async Function SupportsMod(modpack As ModpackInfo, modToCheck As ModJson) As Task(Of Boolean)
        Dim currentCode = Await DotNet3dsToolkit.MetadataReader.GetGameID(SelectedFilename)
        Dim supportedCode = New Regex(modpack.GameCode)
        Return supportedCode.IsMatch(currentCode)
    End Function
End Class
