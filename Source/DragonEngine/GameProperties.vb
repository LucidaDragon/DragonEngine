Public Class GameProperties
    Inherits GameObject

    Sub New()
        MyBase.New("Game")
    End Sub

    Public Property GameDisplayName As String = "Untitled Game"
    Public Property GameVersion As String = "1.0.0"
    Public Property GameAuthor As String = Environment.UserName
End Class
