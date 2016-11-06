Imports System.IO

Public Class xdelta
    Implements IDisposable

    Private ReadOnly Property XDeltaDirectory As String
        Get
            If _XDeltaDirectory Is Nothing Then
                _XDeltaDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "XDelta3-" & Guid.NewGuid.ToString)
            End If
            Return _XDeltaDirectory
        End Get
    End Property
    Dim _XDeltaDirectory As String

    Public ReadOnly Property XDeltaPath As String
        Get
            If _xDeltaPath Is Nothing Then
                _xDeltaPath = Path.Combine(XDeltaDirectory, "xdelta3.exe")
                File.WriteAllBytes(_xDeltaPath, My.Resources.xdelta3)
            End If
            Return _xDeltaPath
        End Get
    End Property
    Dim _xDeltaPath As String

    Public Async Function CreatePatch(oldFilename As String, newFilename As String, patchFile As String) As Task
        Dim oldFileTemp As String = Path.Combine(XDeltaDirectory, $"oldFile.bin")
        Dim newFileTemp As String = Path.Combine(XDeltaDirectory, $"newFile.bin")
        Dim deltaFileTemp As String = Path.Combine(XDeltaDirectory, $"patch.xdelta")
        File.Copy(oldFilename, oldFileTemp, True)
        File.Copy(newFilename, newFileTemp, True)
        Await ProcessHelper.RunProgram(Path.Combine(XDeltaDirectory, "xdelta3.exe"), String.Format("-e -s ""{0}"" ""{1}"" ""{2}""", $"oldFile.bin", $"newFile.bin", $"patch.xdelta")).ConfigureAwait(False)
    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
                If Not String.IsNullOrEmpty(_XDeltaDirectory) AndAlso Directory.Exists(_XDeltaDirectory) Then
                    Directory.Delete(_XDeltaDirectory, True)
                End If
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        ' TODO: uncomment the following line if Finalize() is overridden above.
        ' GC.SuppressFinalize(Me)
    End Sub
#End Region
End Class
