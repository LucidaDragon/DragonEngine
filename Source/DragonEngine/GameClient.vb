Public Class GameClient
    Sub New()
        InitializeComponent()
    End Sub

    Sub New(size As Size, pakPath As String)
        InitializeComponent()
        Me.Size = size
        Dim gameData As New List(Of GamePart)
        Try
            Dim pak As New IO.Compression.ZipArchive(New IO.FileStream(pakPath, IO.FileMode.Open), IO.Compression.ZipArchiveMode.Read)
            For Each entry In pak.Entries
                Dim buffer(entry.Length) As Byte
                entry.Open().Read(buffer, 0, entry.Length)
                gameData.Add(New GamePart(entry.Name, buffer))
            Next
        Catch ex As Exception
            MsgBox("An error occured while loading the game files:" & Environment.NewLine & ex.Message & Environment.NewLine & ex.ToString)
        End Try
    End Sub

    Private Sub GameClient_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class