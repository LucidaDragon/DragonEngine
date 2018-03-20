Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim room As New TileMapObject
        PropertyGrid1.SelectedObject = room
    End Sub

    Private Sub PropertyGrid1_SelectedObjectsChanged(sender As Object, e As EventArgs) Handles PropertyGrid1.SelectedObjectsChanged
        Try
            Dim gObj As GameObject = PropertyGrid1.SelectedObject
        Catch
        End Try
    End Sub
End Class
