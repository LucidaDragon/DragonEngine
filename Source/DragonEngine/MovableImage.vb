Public Class MovableImage
    Inherits PictureBox

    Private IsMouseDown As Boolean = False
    Private Shadows Parent As MapEditor
    Private LastLocation As Point

    Public Sub Image_MouseDown() Handles MyBase.MouseDown
        IsMouseDown = True
        Parent.UndoBuffer.Add(New MapEditor.TileHistory(Me, Location))
        If Parent.UndoBuffer.Count > 10000 Then
            Parent.UndoBuffer.RemoveAt(0)
        End If
        LastLocation = MousePosition
    End Sub

    Public Sub Image_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        Location += MousePosition - LastLocation
        LastLocation = MousePosition
    End Sub

    Public Sub Image_MouseUp() Handles MyBase.MouseUp
        IsMouseDown = False
    End Sub

    Public Sub Image_MouseEnter() Handles MyBase.MouseEnter
        Cursor = Cursors.SizeAll
    End Sub
End Class
