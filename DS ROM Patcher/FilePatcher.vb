Imports System.IO
Imports System.IO.Compression
Imports SkyEditor.Core.IO
Imports SkyEditor.Core.Utilities

Public Class FilePatcher

    ''' <remarks>Returns an empty list if the file does not exist.</remarks>
    Public Shared Function DeserializePatcherList(patchersJsonFilename As String, toolsDirectory As String) As List(Of FilePatcher)
        Dim out As New List(Of FilePatcher)
        If File.Exists(patchersJsonFilename) Then
            For Each item In Json.DeserializeFromFile(Of List(Of FilePatcherJson))(patchersJsonFilename, New PhysicalIOProvider)
                out.Add(New FilePatcher(item, toolsDirectory))
            Next
        End If
        Return out
    End Function

    Public Shared Sub SerializePatherListToFile(patchers As List(Of FilePatcher), filename As String, provider As IIOProvider)
        Dim jsons As List(Of FilePatcherJson) = patchers.Select(Function(x) x.SerializableInfo).Distinct.ToList
        Json.SerializeToFile(filename, jsons, provider)
    End Sub

    Public Shared Sub ImportCurrentPatcherPack(patcherZipFilename As String, modpackDirectory As String)
        'Open existing patchers
        Dim patchersDir = Path.Combine(modpackDirectory, "Tools", "Patchers")
        Dim patchersFile = Path.Combine(patchersDir, "patchers.json")
        Dim currentPatchers = DeserializePatcherList(patchersFile, patchersDir)

        'Unzip importing patchers
        Dim tempDirectory As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Temp-" & Guid.NewGuid.ToString)
        ZipFile.ExtractToDirectory(patcherZipFilename, tempDirectory)

        'Copy patchers
        For Each item In DeserializePatcherList(Path.Combine(tempDirectory, "patchers.json"), tempDirectory)
            item.CopyToolsToDirectory(patchersDir)
            currentPatchers.Add(item)
        Next
        SerializePatherListToFile(currentPatchers, patchersFile, New PhysicalIOProvider)

        'Cleanup
        Directory.Delete(tempDirectory, True)
    End Sub

    Public Shared Sub ExportCurrentPatcherPack(patcherZipFilename As String, modpackDirectory As String)
        Dim patchersDir = Path.Combine(modpackDirectory, "Tools", "Patchers")
        ZipFile.CreateFromDirectory(patchersDir, patcherZipFilename)
    End Sub

    Public Sub New(serializableInfo As FilePatcherJson, toolsDirectory As String)
        Me.SerializableInfo = serializableInfo
        Me.ToolsDirectory = toolsDirectory
    End Sub

    Public Property SerializableInfo As FilePatcherJson

    Public Property ToolsDirectory As String

    Public Function GetCreatePatchProgramPath() As String
        Return Path.Combine(ToolsDirectory, SerializableInfo.CreatePatchProgram)
    End Function

    Public Function GetApplyPatchProgramPath() As String
        Return Path.Combine(ToolsDirectory, SerializableInfo.ApplyPatchProgram)
    End Function

    Public Sub CopyToolsToDirectory(newToolsDir As String)
        Dim tools As New List(Of String)
        If SerializableInfo.Dependencies IsNot Nothing
            tools.AddRange(SerializableInfo.Dependencies)
        End If
        tools.Add(SerializableInfo.CreatePatchProgram)
        tools.Add(SerializableInfo.ApplyPatchProgram)
        For Each item In tools.Distinct
            Dim source As String = Path.Combine(ToolsDirectory, item)
            Dim dest As String = Path.Combine(newToolsDir, item)

            If Not Directory.Exists(Path.GetDirectoryName(dest)) Then
                Directory.CreateDirectory(Path.GetDirectoryName(dest))
            End If

            File.Copy(source, dest, True)
        Next
    End Sub
End Class
