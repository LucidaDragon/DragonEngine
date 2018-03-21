Public Class Form1
    Public Property GameObjects As List(Of GameObject)
        Get
            If Not MemoryToTree Then
                MemoryToTree = True
                UpdateTreeView()
                MemoryToTree = False
            End If
            Return ObjectMemory
        End Get
        Set(value As List(Of GameObject))
            ObjectMemory = value
        End Set
    End Property
    Private ObjectMemory As New List(Of GameObject)
    Private MemoryToTree As Boolean = False

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GameObjectLookup.SetObjectList(ObjectMemory)
        TreeView1.TopNode.Tag = New GameProperties
        GameObjects.Add(New RenderedObject("Render_Obj"))
        GameObjects.Add(New ScriptObject("Script_Obj"))
        GameObjects.Add(New PhysicsObject("Phys_Obj"))
        GameObjects.Add(New SpriteObject("Sprite_Obj"))
        GameObjects.Add(New TileMapObject("TileMap_Obj"))
        UpdateTreeView()
    End Sub

    Private Sub PropertyGrid1_SelectedObjectsChanged(sender As Object, e As EventArgs) Handles PropertyGrid1.SelectedObjectsChanged
        Try
            ImageEditor1.Hide()
            TextBox1.Text = ""
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

    Private Sub UpdateTreeView()
        TreeView1.Nodes.Item(0).Nodes.Clear()
        For Each obj In GameObjects
            Dim node As New SpecialTreeNode(obj.Name)
            If TryCast(obj, ScriptObject) IsNot Nothing Then
                node.ImageKey = "gear.png"
            ElseIf TryCast(obj, PhysicsObject) IsNot Nothing Then
                node.ImageKey = "open.png"
            ElseIf TryCast(obj, RenderedObject) IsNot Nothing Then
                node.ImageKey = "gamepad.png"
            ElseIf TryCast(obj, SpriteObject) IsNot Nothing Then
                node.ImageKey = "movie.png"
            ElseIf TryCast(obj, TileMapObject) IsNot Nothing Then
                node.ImageKey = "exit.png"
            End If
            node.SelectedImageKey = node.ImageKey
            node.Tag = obj
            TreeView1.Nodes.Item(0).Nodes.Add(node)
        Next
    End Sub
End Class
