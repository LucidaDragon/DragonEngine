Public Class WorldDisplay
    Private MyWorld As World
    Private PanOffset As New Point(0, 0)
    Private DeltaTime As Double = 1000
    Private IsMouseDown As Boolean = False
    Private IsMouseOver As Boolean = False
    Private PrevMouseLocation As Point

    Sub New(world As World)
        InitializeComponent()
        MyWorld = world
    End Sub

    Private Sub WorldDisplay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dock = DockStyle.Fill
        Timer.Start()
    End Sub

    Private Sub WorldDisplay_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        Dim start As DateTime = DateTime.Now

        If MyWorld.GetCurrentImage() IsNot Nothing Then
            e.Graphics.DrawImage(MyWorld.SelectedStaticMap.SelectedImage, New Point(MyWorld.MapOffset.X + PanOffset.X, MyWorld.MapOffset.Y + PanOffset.Y))
        End If

        Dim timeSin As Double = Math.Abs(Math.Sin((DateTime.Now.Millisecond + (DateTime.Now.Second * 1000)) / 2000.0)) * 255
        Dim timeCos As Double = Math.Abs(Math.Cos((DateTime.Now.Millisecond + (DateTime.Now.Second * 1000)) / 2000.0)) * 255

        If IsMouseOver And MyWorld.GetCurrentImage() IsNot Nothing Then
            Dim whole As Bitmap = MyWorld.GetCurrentImage()
            For Each rect In MyWorld.Collision
                e.Graphics.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(0, timeSin, timeCos)), 1), New Rectangle(rect.Location.X + MyWorld.MapOffset.X + PanOffset.X, rect.Location.Y + MyWorld.MapOffset.Y + PanOffset.Y, rect.Size.Width, rect.Size.Height))
            Next
        End If

        e.Graphics.DrawLine(New Pen(New SolidBrush(Color.FromArgb(timeSin, timeCos, 0)), 1), New Point(PanOffset.X, PanOffset.Y), New Point(PanOffset.X, PanOffset.Y - 10))
        e.Graphics.DrawLine(New Pen(New SolidBrush(Color.FromArgb(timeSin, timeCos, 0)), 1), New Point(PanOffset.X, PanOffset.Y), New Point(PanOffset.X, PanOffset.Y + 10))
        e.Graphics.DrawLine(New Pen(New SolidBrush(Color.FromArgb(timeSin, timeCos, 0)), 1), New Point(PanOffset.X, PanOffset.Y), New Point(PanOffset.X - 10, PanOffset.Y))
        e.Graphics.DrawLine(New Pen(New SolidBrush(Color.FromArgb(timeSin, timeCos, 0)), 1), New Point(PanOffset.X, PanOffset.Y), New Point(PanOffset.X + 10, PanOffset.Y))

        DeltaTime = (DateTime.Now - start).TotalMilliseconds
        e.Graphics.DrawString(DeltaTime & "ms", Font, New SolidBrush(Color.White), New Point(3, 3))
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        If MyWorld.SelectedAnimMap Is Nothing Or MyWorld.UseStaticMap Then
            Timer.Interval = DeltaTime + 10
        Else
            If DeltaTime > MyWorld.SelectedAnimMap.Delay Then
                Timer.Interval = DeltaTime + 10
            Else
                Timer.Interval = MyWorld.SelectedAnimMap.Delay
            End If
        End If
        Invalidate()
    End Sub

    Private Sub WorldDisplay_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        If e.Button = MouseButtons.Left Then
            PrevMouseLocation = MousePosition
            IsMouseDown = True
        End If
    End Sub

    Private Sub WorldDisplay_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        If IsMouseDown Then
            PanOffset += New Point(MousePosition.X - PrevMouseLocation.X, MousePosition.Y - PrevMouseLocation.Y)
            PrevMouseLocation = MousePosition
        End If
    End Sub

    Private Sub WorldDisplay_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
        IsMouseDown = False
    End Sub

    Private Sub WorldDisplay_MouseEnter(sender As Object, e As EventArgs) Handles MyBase.MouseEnter
        IsMouseOver = True
    End Sub

    Private Sub WorldDisplay_MouseLeave(sender As Object, e As EventArgs) Handles MyBase.MouseLeave
        IsMouseOver = False
    End Sub
End Class
