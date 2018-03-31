Public Class Keyboard
    Public Shared WithEvents SourceForm As Form = GameWindow
    Public Shared ActiveKeys As New List(Of Keys)

    Private Shared Sub GameWindow_KeyDown(sender As Object, e As KeyEventArgs) Handles SourceForm.KeyDown
        ActiveKeys.Add(e.KeyCode)
    End Sub

    Private Shared Sub GameWindow_KeyUp(sender As Object, e As KeyEventArgs) Handles SourceForm.KeyUp
        ActiveKeys.Remove(e.KeyCode)
    End Sub
End Class
