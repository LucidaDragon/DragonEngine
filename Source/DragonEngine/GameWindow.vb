Public Class GameWindow
    Private Sub GameWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = Icon.FromHandle(GameProperties.Instance.GameIcon.SelectedImage.GetHicon())
        Text = GameProperties.Instance.GameName
    End Sub

    Private Sub GameWindow_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        Engine.Graphics.Draw(e.Graphics, New Rectangle(New Point(Size.Width / -2, Size.Height / -2), Size))
    End Sub
End Class