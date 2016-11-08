Imports System.Threading
Imports Microsoft.VisualBasic.ApplicationServices

Namespace My
    ' The following events are available for MyApplication:
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication


        Private Shared Sub UIThreadException(sender As Object, t As ThreadExceptionEventArgs)
            Dim result As DialogResult = DialogResult.Cancel
            Try
                ' Todo: make this translatable
                ErrorWindow.ShowErrorDialog("An unhandled exception has occurred." & vbLf & "You can continue running the program, but please report this error.", t.Exception, True)
            Catch
                Try
                    ' Todo: make this translatable
                    MessageBox.Show("A fatal error has occurred, and the details could not be displayed.  Please report this to the author.", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Stop])
                Finally
                    Environment.Exit(1)
                End Try
            End Try

            ' Exits the program when the user clicks Abort.
            If result = DialogResult.Abort Then
                Environment.Exit(1)
            End If
        End Sub

        ' Handle the UI exceptions by showing a dialog box, and asking the user whether
        ' or not they wish to abort execution.
        ' NOTE: This exception cannot be kept from terminating the application - it can only 
        ' log the event, and inform the user about it. 
        Private Shared Sub CurrentDomain_UnhandledException(sender As Object, e As System.UnhandledExceptionEventArgs)
            Try
                Dim ex = DirectCast(e.ExceptionObject, Exception)
                ' Todo: make this translatable
                ErrorWindow.ShowErrorDialog("An unhandled exception has occurred." & vbLf & "The program must now close.", ex, False)
            Catch
                Try
                    ' Todo: make this translatable
                    MessageBox.Show("A fatal non-UI error has occurred, and the details could not be displayed.  Please report this to the author.", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Stop])
                Finally
                    Environment.Exit(1)
                End Try
            End Try
        End Sub

        Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
            ' Add the event handler for handling UI thread exceptions to the event.
            AddHandler Windows.Forms.Application.ThreadException, AddressOf UIThreadException

            ' Set the unhandled exception mode to force all Windows Forms errors to go through our handler.
            Windows.Forms.Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException)

            ' Add the event handler for handling non-UI thread exceptions to the event. 
            AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf CurrentDomain_UnhandledException
        End Sub
    End Class

End Namespace
