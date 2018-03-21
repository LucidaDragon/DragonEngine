Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim physObj As New ScriptObject
        PropertyGrid1.SelectedObject = physObj
    End Sub

    Private Sub PropertyGrid1_SelectedObjectsChanged(sender As Object, e As EventArgs) Handles PropertyGrid1.SelectedObjectsChanged
        Try
            ImageEditor1.Hide()
            If TryCast(PropertyGrid1.SelectedObject, ScriptObject) IsNot Nothing Then
                TextBox1.Text = TryCast(PropertyGrid1.SelectedObject, ScriptObject).Script
            ElseIf TryCast(PropertyGrid1.SelectedObject, SpriteObject) IsNot Nothing Then
                ImageEditor1.Image = TryCast(PropertyGrid1.SelectedObject, SpriteObject).Image
                ImageEditor1.Show()
            ElseIf TryCast(PropertyGrid1.SelectedObject, TileMapObject) IsNot Nothing Then

            End If
        Catch
        End Try
    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        PropertyGrid1.SelectedObject = e.Node.Tag
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TryCast(PropertyGrid1.SelectedObject, ScriptObject) IsNot Nothing Then
            TryCast(PropertyGrid1.SelectedObject, ScriptObject).Script = TextBox1.Text
        End If
    End Sub
End Class
