Public Class LogWindow
    Public Sub Log(message As String)
        ListBox1.Items.Add(message)
    End Sub

    Private Sub CopyAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyAllToolStripMenuItem.Click
        Dim str As String = String.Empty
        For Each elem In ListBox1.Items
            str += elem & StrDup(2, Environment.NewLine)
        Next
        Clipboard.SetText(str, TextDataFormat.Text)
    End Sub

    Private Sub CopySelectedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopySelectedToolStripMenuItem.Click
        Dim str As String = String.Empty
        For Each elem In ListBox1.SelectedItems
            str += elem & StrDup(2, Environment.NewLine)
        Next
        Clipboard.SetText(str, TextDataFormat.Text)
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        If ListBox1.SelectedIndices.Count > 0 Then
            For Each elem As Integer In ListBox1.SelectedIndices
                ListBox1.Items.RemoveAt(elem)
            Next
        End If
    End Sub

    Private Sub LogWindow_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ShowInTaskbar = True
    End Sub

    Private Sub LogWindow_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            ShowInTaskbar = False
            Hide()
        End If
    End Sub
End Class