Public Class GameWindow
    Private Sub GameWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If GameProperties.Instance.GameIcon IsNot Nothing Then
            Icon = Icon.FromHandle(ObjectLookupTable.GetItem(Of Image)(GameProperties.Instance.GameIcon).SelectedImage.GetHicon())
        End If

        Text = GameProperties.Instance.GameName

        InheritWindowState()
    End Sub

    Private Sub InheritWindowState()
        If GameProperties.Instance.ViewportStyle = GameProperties.ViewportType.Window Then
            FormBorderStyle = FormBorderStyle.Sizable
            WindowState = FormWindowState.Normal
        ElseIf GameProperties.Instance.ViewportStyle = GameProperties.ViewportType.Borderless Then
            FormBorderStyle = FormBorderStyle.None
            WindowState = FormWindowState.Normal
        ElseIf GameProperties.Instance.ViewportStyle = GameProperties.ViewportType.FullscreenWindow Then
            FormBorderStyle = FormBorderStyle.Sizable
            WindowState = FormWindowState.Maximized
        ElseIf GameProperties.Instance.ViewportStyle = GameProperties.ViewportType.FullscreenBorderless Then
            FormBorderStyle = FormBorderStyle.None
            WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub GameWindow_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        Engine.Graphics.Draw(e.Graphics, New Rectangle(New Point(Size.Width / -2, Size.Height / -2), Size))
    End Sub

    Private Sub GameWindow_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Timer.Start()
    End Sub

    Private Sub GameWindow_Closing(sender As Object, e As EventArgs) Handles MyBase.FormClosing
        Timer.Stop()
    End Sub

    Private Sub GameWindow_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If WindowState = FormWindowState.Maximized Or FormBorderStyle = FormBorderStyle.None Then
                WindowState = FormWindowState.Normal
                FormBorderStyle = FormBorderStyle.Sizable
            Else
                InheritWindowState()
            End If
        End If
    End Sub

    Private Sub GameWindow_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If WindowState = FormWindowState.Maximized Then
            If GameProperties.Instance.ViewportStyle = GameProperties.ViewportType.FullscreenBorderless Then
                FormBorderStyle = FormBorderStyle.None
                WindowState = FormWindowState.Normal
                WindowState = FormWindowState.Maximized
            End If
        End If
    End Sub
End Class