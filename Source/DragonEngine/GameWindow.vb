Public Class GameWindow
    Private Sub GameWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = Icon.FromHandle(GameProperties.Instance.GameIcon.SelectedImage.GetHicon())
        Text = GameProperties.Instance.GameName
    End Sub
End Class