Public Class TextInputBox
    Sub New()
        InitializeComponent()
    End Sub

    Sub New(text As String)
        InitializeComponent()
        Query = text
    End Sub

    Private Query As String = "Input Text"

    Private Sub TextInputBox_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Text = Query
    End Sub

    Private Sub OkSubmitButton_Click(sender As Object, e As EventArgs) Handles OkSubmitButton.Click
        Text = InputTextBox.Text
        DialogResult = DialogResult.OK
    End Sub

    Private Sub CancelSubmitButton_Click(sender As Object, e As EventArgs) Handles CancelSubmitButton.Click
        DialogResult = DialogResult.Cancel
    End Sub
End Class