Public Class FilePatchAnalysisResult

    Public Sub New()
        Patches = New Dictionary(Of String, FilePatcher)
    End Sub

    ''' <summary>
    ''' Relative path of the file to be patched
    ''' </summary>
    Public Property SourceFile As String

    ''' <summary>
    ''' Dictionary matching relative paths of patch files to the patcher used to apply them.
    ''' </summary>
    ''' <returns>A dictionary whose key is the relative path of a patch and whose value is the file patcher used to apply the patch or null if no patcher was found (in which case, xDelta will be used).</returns>
    Public Property Patches As Dictionary(Of String, FilePatcher)

    ''' <summary>
    ''' List of relative paths of patches without an available patcher.
    ''' </summary>
    ''' <returns></returns>
    Public Property MissingPatchers As List(Of String)
End Class
