Namespace Utilities
    Public Class ProcessHelper
        ''' <summary>
        ''' Runs the specified program, capturing console output.
        ''' Returns true when the program exits.
        ''' </summary>
        ''' <param name="Filename"></param>
        ''' <param name="Arguments"></param>
        ''' <remarks></remarks>
        Public Shared Async Function RunProgram(Filename As String, Arguments As String, Optional IsVisible As Boolean = False) As Task
            Using p As New Process()
                p.StartInfo.FileName = Filename
                p.StartInfo.Arguments = Arguments
                p.StartInfo.RedirectStandardOutput = True
                p.StartInfo.UseShellExecute = False
                If IsVisible Then
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                Else
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                End If
                p.StartInfo.CreateNoWindow = True
                p.StartInfo.WorkingDirectory = IO.Path.GetDirectoryName(Filename)

                Try
                    p.Start()
                Catch ex As Exception
                    Throw New ProcessFailedToStartException(p.StartInfo, ex)
                End Try

                p.BeginOutputReadLine()
                Await Task.Run(Sub() p.WaitForExit())
            End Using
        End Function

        Public Class ProcessFailedToStartException
            Inherits Exception

            Public Sub New(startInfo As ProcessStartInfo, innerException As Exception)
                MyBase.New($"Process '{startInfo.FileName}{If(Not String.IsNullOrEmpty(startInfo.Arguments), " " & startInfo.Arguments, "")}' failed to start: {innerException.Message}")

                Me.StartInfo = startInfo
            End Sub

            Public ReadOnly Property StartInfo As ProcessStartInfo
        End Class
    End Class
End Namespace