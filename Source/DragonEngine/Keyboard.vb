Public Class Keyboard
    Public Shared Property SourceForm As Form
        Get
            Return Form
        End Get
        Set(value As Form)
            If value IsNot Nothing Then
                RemoveHandler Form.KeyDown, AddressOf GameWindow_KeyDown
                RemoveHandler Form.KeyUp, AddressOf GameWindow_KeyUp
                Form = value
                AddHandler Form.KeyDown, AddressOf GameWindow_KeyDown
                AddHandler Form.KeyUp, AddressOf GameWindow_KeyUp
            End If
        End Set
    End Property
    Private Shared WithEvents Form As Form = GameWindow

    Public Shared ActiveKeys As New List(Of Keys)

    Private Shared Sub GameWindow_KeyDown(sender As Object, e As KeyEventArgs) Handles Form.KeyDown
        ActiveKeys.Add(e.KeyCode)
    End Sub

    Private Shared Sub GameWindow_KeyUp(sender As Object, e As KeyEventArgs) Handles Form.KeyUp
        While ActiveKeys.Remove(e.KeyCode)
        End While
    End Sub
End Class
