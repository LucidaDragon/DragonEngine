Public Class Form1
    Public GameObjects As New List(Of GameObject)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GameObjects.Add(New ScriptObject)
        GameObjects.Add(New PhysicsObject)
        GameObjects.Add(New SpriteObject)
        GameObjects.Add(New RenderedObject)
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

    Private Sub TreeView1_Paint(sender As Object, e As PaintEventArgs) Handles TreeView1.Paint
        TreeView1.TopNode.Nodes.Clear()
        For Each obj In GameObjects
            Dim node As New TreeNode(obj.Name)
            If TryCast(obj, ScriptObject) IsNot Nothing Then
                node.ImageKey = "gear.png"
            ElseIf TryCast(obj, PhysicsObject) IsNot Nothing Then
                node.ImageKey = "open.png"
            ElseIf TryCast(obj, RenderedObject) IsNot Nothing Then
                node.ImageKey = "gamepad.png"
            ElseIf TryCast(obj, SpriteObject) IsNot Nothing Then
                node.ImageKey = "movie.png"
            End If
            TreeView1.TopNode.Nodes.Add(node)
        Next
    End Sub

    Private Sub TreeView1_MouseEnter(sender As Object, e As EventArgs) Handles TreeView1.MouseEnter
        TreeView1.Invalidate()
    End Sub
End Class
