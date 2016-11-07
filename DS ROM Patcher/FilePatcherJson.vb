Public Class FilePatcherJson

    ''' <summary>
    ''' Regular expression matching all file paths of a ROM that this patcher supports.
    ''' </summary>
    Public Property FilePath As String

    ''' <summary>
    ''' Relative path of the program used to create patches
    ''' </summary>
    Public Property CreatePatchProgram As String

    ''' <summary>
    ''' Arguments for the CreatePatchProgram.
    ''' {0} is a placeholder for the original file, {1} is a placeholder for the updated file, and {2} is a placeholder for the output patch file.
    ''' </summary>
    Public Property CreatePatchArguments As String

    ''' <summary>
    ''' Relative path of the program used to apply patches.
    ''' </summary>
    Public Property ApplyPatchProgram As String

    ''' <summary>
    ''' Arguments for the ApplyPatchProgram.
    ''' {0} is a placeholder for the original file, {1} is a placeholder for the patch file, and {2} is a placeholder for the output file.
    ''' </summary>
    Public Property ApplyPatchArguments As String

    ''' <summary>
    ''' Whether or not multiple patches can be applied to the same file.
    ''' </summary>
    Public Property IsPatchMergeSafe As Boolean

    ''' <summary>
    ''' Extension of the patch file
    ''' </summary>
    Public Property PatchExtension As String

    ''' <summary>
    ''' Relative paths of dependency files required by either the <see cref="CreatePatchProgram"/> or the <see cref="ApplyPatchProgram"/>
    ''' </summary>
    Public Property Dependencies As List(Of String)

    Public Overrides Function Equals(obj As Object) As Boolean
        If TypeOf obj Is FilePatcherJson Then
            Dim other As FilePatcherJson = obj

            Return Me.FilePath = other.FilePath AndAlso
                Me.CreatePatchProgram = other.CreatePatchProgram AndAlso
                Me.CreatePatchArguments = other.CreatePatchArguments AndAlso
                Me.ApplyPatchProgram = other.ApplyPatchProgram AndAlso
                Me.ApplyPatchArguments = other.ApplyPatchArguments AndAlso
                Me.IsPatchMergeSafe = other.IsPatchMergeSafe AndAlso
                Me.PatchExtension = other.PatchExtension AndAlso
                Me.Dependencies.SequenceEqual(other.Dependencies)
        Else
            Return False
        End If
    End Function
End Class