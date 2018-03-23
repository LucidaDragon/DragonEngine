Public Class GameEditor
    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count > 0 Then
            PropertyGrid1.SelectedObject = ListView1.Items(ListView1.SelectedIndices.Item(0)).Tag
        End If
    End Sub

    Public Sub SerializeGame(pakPath As String)
        Dim zip As New IO.Compression.ZipArchive(New IO.FileStream(pakPath, IO.FileMode.Create), IO.Compression.ZipArchiveMode.Create)
        For Each obj As ListViewItem In ListView1.Items
            If TryCast(obj.Tag, IDataExchange) IsNot Nothing Then
                Dim data As IDataExchange = TryCast(obj.Tag, IDataExchange)
                Dim raw As Byte() = data.ToStorage()
                zip.CreateEntry(data.GetPackageName())
                Dim stream As IO.Stream = zip.GetEntry(data.GetPackageName()).Open()
                stream.Write(raw, 0, raw.Length)
                stream.Close()
            End If
            GC.Collect()
        Next
    End Sub

    Public Sub AddItem(obj As IListable)
        Dim item As New ListViewItem(obj.GetText(), obj.GetIcon()) With {
            .Tag = obj
        }
        ListView1.Items.Add(item)
    End Sub

    Private Sub GameEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GameClient.Show()
        AddItem(Camera.Instance)
        AddItem(GameProperties.Settings)
    End Sub
End Class