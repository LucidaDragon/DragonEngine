Public Class GameEditor
    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        PropertyGrid1.SelectedObject = ListView1.Items(ListView1.SelectedIndices.Item(0))
    End Sub
End Class