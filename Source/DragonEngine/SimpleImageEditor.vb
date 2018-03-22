Public Class SimpleImageEditor
    Public Property PaintColor As Color
    Public Property Sprite As SpriteObject
        Get
            Return CurrentSprite
        End Get
        Set(value As SpriteObject)
            If CurrentSprite IsNot Nothing And CurrentImage IsNot Nothing Then
                CurrentSprite.Image = CurrentImage
            End If
            CurrentSprite = value
            If value IsNot Nothing Then
                Image = CurrentSprite.Image.Clone()
            Else
                Image = Nothing
            End If
        End Set
    End Property
    Public Property Image As Bitmap
        Get
            Return CurrentImage
        End Get
        Set(value As Bitmap)
            CurrentImage = value
            If Not UndoUpdating Then
                UndoBuffer.Clear()
            End If
            Invalidate()
        End Set
    End Property
    Public Shadows Property Scale As Double = 1

    Private CurrentSprite As SpriteObject
    Private CurrentImage As Bitmap
    Private IsMouseDown As Boolean = False
    Private UndoBuffer As New List(Of Bitmap)
    Private UndoUpdating As Boolean = False

    Private Sub ImageEditor_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        If Image IsNot Nothing And e.Button = MouseButtons.Left Then
            IsMouseDown = True
            UndoBuffer.Add(Image.Clone())
            If UndoBuffer.Count > 10000 Then
                UndoBuffer.RemoveAt(0)
            End If
        End If
    End Sub

    Private Sub ImageEditor_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
        IsMouseDown = False
    End Sub

    Private Sub ImageEditor_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        If IsMouseDown Then
            Dim paintLoc As Point = MousePosition - PointToScreen(New Point(0, 0))
            paintLoc = New Point(paintLoc.X / Scale, paintLoc.Y / Scale)
            Image.SetPixel(paintLoc.X, paintLoc.Y, PaintColor)
            Invalidate()
        End If
    End Sub

    Private Sub ImageEditor_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        If Image IsNot Nothing Then
            Width = Image.Width * Scale
            Height = Image.Height * Scale
            e.Graphics.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor
            e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.None
            e.Graphics.DrawImage(Image, New Rectangle(0, 0, Image.Width * Scale, Image.Height * Scale))
        End If
    End Sub

    Private Sub ImageEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Location = New Point(0, 0)
        Dock = DockStyle.None
        Parent.ContextMenuStrip = ContextMenuStrip1
    End Sub

    Private Sub ImageEditor_MouseEnter(sender As Object, e As EventArgs) Handles MyBase.MouseEnter
        Me.Select()
        Invalidate()
    End Sub

    Private Sub ImageEditor_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If Not (e.KeyCode = Keys.Control Or e.KeyCode = Keys.ControlKey) Then
            If e.Control And e.KeyCode = Keys.Z And UndoBuffer.Count > 0 Then
                UndoToolStripMenuItem_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub ColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColorToolStripMenuItem.Click
        Dim dia As New ColorDialog
        If dia.ShowDialog() = DialogResult.OK Then
            PaintColor = dia.Color
        End If
        dia.Dispose()
    End Sub

    Private Sub UndoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem.Click
        If UndoBuffer.Count > 0 Then
            UndoUpdating = True
            Image = UndoBuffer.Last
            UndoBuffer.RemoveAt(UndoBuffer.Count - 1)
            UndoUpdating = False
        End If
    End Sub

    Private Sub ZoomInToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZoomInToolStripMenuItem.Click
        Scale *= 2
        If Scale > 64 Then
            Scale = 64
        End If
    End Sub

    Private Sub ZoomOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZoomOutToolStripMenuItem.Click
        Scale /= 2
        If Scale < Double.MinValue * 4 Then
            Scale = Double.MinValue * 4
        End If
    End Sub

    Private Sub ResetZoomToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetZoomToolStripMenuItem.Click
        Scale = 1
    End Sub

    Private Sub ImageEditor_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        If Parent IsNot Nothing Then
            Location = New Point((Parent.Width / 2) - (Width / 2), (Parent.Height / 2) - (Height / 2))
        End If
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        ContextMenuStrip1.BringToFront()
    End Sub
End Class
