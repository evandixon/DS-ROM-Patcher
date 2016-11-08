Public Class ModAnalysisResult
    Public Sub New()
        Files = New List(Of FilePatchAnalysisResult)
    End Sub

    Public Property Files As List(Of FilePatchAnalysisResult)
End Class
