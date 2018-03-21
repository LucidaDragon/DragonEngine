Public Class MovableImage
    Inherits PictureBox

    Private IsMouseDown As Boolean = False

    Public Sub Image_MouseDown() Handles MyBase.MouseDown
        IsMouseDown = True
    End Sub

    Public Sub Image_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove

    End Sub

    Public Sub Image_MouseUp() Handles MyBase.MouseUp
        IsMouseDown = False
    End Sub
End Class
