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
                p.Start()
                p.BeginOutputReadLine()
                Await Task.Run(Sub() p.WaitForExit())
            End Using
        End Function
    End Class
End Namespace