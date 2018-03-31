Public Class AnimationDisplay
    Public Property SelectedAnimation As Animation
    Public Property SelectedImage As Image

    Sub New()
        InitializeComponent()
        Dock = DockStyle.Fill
        Timer.Interval = 1000
        Timer.Start()
    End Sub

    Sub New(anim As Animation)
        InitializeComponent()
        SelectedAnimation = anim
        Dock = DockStyle.Fill
        Timer.Interval = 1000
        Timer.Start()
    End Sub

    Sub New(img As Image)
        InitializeComponent()
        SelectedImage = img
        Dock = DockStyle.Fill
        Timer.Interval = 1000
        Timer.Start()
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        Invalidate()
        Update()
    End Sub

    Private Sub AnimationDisplay_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        Dim rect As New Rectangle(0, 0, 0, 0)

        If Width < Height Then
            rect = New Rectangle(0, (Height / 2) - (Width / 2), Width, Width)
        Else
            rect = New Rectangle((Width / 2) - (Height / 2), 0, Height, Height)
        End If

        If SelectedAnimation IsNot Nothing Then
            If SelectedAnimation.GetCurrentImage() IsNot Nothing Then
                Try
                    e.Graphics.DrawImage(SelectedAnimation.GetCurrentImage(), rect)
                Catch ex As ArgumentNullException
                    e.Graphics.FillRectangle(New TextureBrush(My.Resources.cross), rect)
                End Try
                Timer.Interval = SelectedAnimation.Delay / 2
            End If
        End If

        If SelectedImage IsNot Nothing Then
            e.Graphics.DrawImage(SelectedImage.SelectedImage, rect)
        End If
    End Sub
End Class
