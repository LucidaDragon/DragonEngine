Public Class MapEditor
    Public UndoBuffer As New List(Of TileHistory)

    Public Property SelectedMap As TileMapObject

    Public Class TileHistory
        Public Tile As MovableImage
        Public Location As Point

        Sub New(tile As MovableImage, location As Point)
            Me.Tile = tile
            Me.Location = location
        End Sub
    End Class

    Private Sub MapEditor_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If Not (e.KeyCode = Keys.Control Or e.KeyCode = Keys.ControlKey) Then
            If e.Control And e.KeyCode = Keys.Z And UndoBuffer.Count > 0 Then
                UndoToolStripMenuItem_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub UndoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem.Click
        If UndoBuffer.Count > 0 Then
            UndoBuffer.Last.Tile.Location = UndoBuffer.Last.Location
            UndoBuffer.RemoveAt(UndoBuffer.Count - 1)
        End If
    End Sub

    Private Sub MapEditor_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        If Parent IsNot Nothing Then
            Location = New Point((Parent.Width / 2) - (Width / 2), (Parent.Height / 2) - (Height / 2))
        End If
    End Sub
End Class
