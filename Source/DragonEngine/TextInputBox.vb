Public Class TextInputBox
    Sub New()
        InitializeComponent()
    End Sub

    Sub New(text As String)
        InitializeComponent()
        Query = text
    End Sub

    Private Query As String = "Input Text"

    Private Sub InputTextBox_Validated(sender As Object, e As EventArgs) Handles InputTextBox.Validated
        Text = InputTextBox.Text
        Close()
    End Sub

    Private Sub TextInputBox_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Text = Query
    End Sub

    Private Sub TextInputBox_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If Text = Query Then
            DialogResult = DialogResult.Cancel
        Else
            DialogResult = DialogResult.OK
        End If
    End Sub

    Private Sub OkSubmitButton_Click(sender As Object, e As EventArgs) Handles OkSubmitButton.Click
        Text = InputTextBox.Text
        Close()
    End Sub

    Private Sub CancelSubmitButton_Click(sender As Object, e As EventArgs) Handles CancelSubmitButton.Click
        Close()
    End Sub
End Class