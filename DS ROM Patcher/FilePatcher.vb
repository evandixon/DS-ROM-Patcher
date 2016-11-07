Imports System.IO
Imports Newtonsoft.Json
Imports SkyEditor.Core.Utilities

Public Class FilePatcher

    Public Shared Function DeserializePatcherList(patchersJsonFilename As String, toolsDirectory As String) As List(Of FilePatcher)
        Dim out As New List(Of FilePatcher)
        For Each item In Json.DeserializeFromFile(Of List(Of FilePatcherJson))(patchersJsonFilename, New WindowsIOProvider)
            out.Add(New FilePatcher(item, toolsDirectory))
        Next
        Return out
    End Function

    Public Shared Sub SerializePatherListToFile(patchers As List(Of FilePatcher), filename As String, provider As WindowsIOProvider)
        Dim jsons As List(Of FilePatcherJson) = patchers.Select(Function(x) x.SerializableInfo).ToList
        Json.SerializeToFile(filename, jsons, provider)
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
        For Each item In SerializableInfo.Dependencies.Concat({SerializableInfo.CreatePatchProgram, SerializableInfo.ApplyPatchProgram}).Distinct
            Dim source As String = Path.Combine(ToolsDirectory, item)
            Dim dest As String = Path.Combine(newToolsDir, item)

            File.Copy(source, dest, True)
        Next
    End Sub
End Class
