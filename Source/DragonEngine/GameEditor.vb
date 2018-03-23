Public Class GameEditor
    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count > 0 Then
            PropertyGrid1.SelectedObject = ListView1.Items(ListView1.SelectedIndices.Item(0)).Tag
        End If
    End Sub

    Public Sub SerializeGame(pakPath As String)
        Dim zip As New IO.Compression.ZipArchive(New IO.FileStream(pakPath, IO.FileMode.Create), IO.Compression.ZipArchiveMode.Update)
        For Each obj As ListViewItem In ListView1.Items
            If TryCast(obj.Tag, IDataExchange) IsNot Nothing Then
                Dim data As IDataExchange = TryCast(obj.Tag, IDataExchange)
                Dim raw As Byte() = data.ToStorage()
                zip.CreateEntry(data.GetPackageName())
                Dim stream As IO.Stream = zip.GetEntry(data.GetPackageName()).Open()
                stream.Write(raw, 0, raw.Length)
                stream.Close()
                stream.Dispose()
            End If
            GC.Collect()
        Next
        zip.Dispose()
    End Sub

    Public Sub RefreshItems()
        For Each item As ListViewItem In ListView1.Items
            If TryCast(item.Tag, IListable) IsNot Nothing Then
                item.Text = TryCast(item.Tag, IListable).GetText()
                item.ImageKey = TryCast(item.Tag, IListable).GetIcon()
            End If
        Next
    End Sub

    Public Sub AddItem(obj As IListable)
        If obj IsNot Nothing Then
            Dim item As New ListViewItem(obj.GetText(), obj.GetIcon()) With {
                .Tag = obj
            }
            ListView1.Items.Add(item)
        End If
    End Sub

    Private Sub GameEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GameClient.Show()
        GameClient.Close()

        If GameProperties.Settings Is Nothing Then
            Dim deafultSettings As New GameProperties
        End If
        If Camera.Instance Is Nothing Then
            Dim deafultCamera As New Camera
        End If
        AddItem(Camera.Instance)
        AddItem(GameProperties.Settings)
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        SerializeGame(Globals.CurrentPackagePath)

        Dim client As New GameClient()
        client.Show()
    End Sub

    Private Sub NewLevelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewLevelToolStripMenuItem.Click
        AddItem(New Level)
    End Sub

    Private Sub PropertyGrid1_PropertyValueChanged(s As Object, e As PropertyValueChangedEventArgs) Handles PropertyGrid1.PropertyValueChanged
        RefreshItems()
    End Sub
End Class