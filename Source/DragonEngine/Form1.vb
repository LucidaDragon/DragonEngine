Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim room As New TileMapObject
        PropertyGrid1.SelectedObject = room
    End Sub

    Private Sub PropertyGrid1_SelectedObjectsChanged(sender As Object, e As EventArgs) Handles PropertyGrid1.SelectedObjectsChanged
        Try
            If TryCast(PropertyGrid1.SelectedObject, ScriptObject) IsNot Nothing Then
                TextBox1.Text = TryCast(PropertyGrid1.SelectedObject, ScriptObject).Script
            End If
        Catch
        End Try
    End Sub
End Class
