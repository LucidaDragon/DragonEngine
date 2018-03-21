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

    Public GameObjects As New List(Of GameObject)
    Public DrawCalls As New List(Of RenderedObject)

    Private DeltaMiliseconds As Integer = 0

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Invalidate()
        Timer1.Interval = DeltaMiliseconds + 1
    End Sub

    Private Sub GameClient_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        Dim startTick As DateTime = DateTime.Now

        For Each obj In GameObjects
            obj.Tick(DeltaMiliseconds / 1000)
        Next

        For Each drawCall In DrawCalls
            e.Graphics.DrawImage(drawCall.SelectedSprite.Image, drawCall.WorldPosition)
        Next

        DeltaMiliseconds = (DateTime.Now - startTick).TotalMilliseconds
    End Sub

    Private Sub GameClient_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Timer1.Start()
    End Sub

    Private Sub GameClient_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        KeyManager.SetKeyState(e.KeyCode, True)
    End Sub

    Private Sub GameClient_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        KeyManager.SetKeyState(e.KeyCode, False)
    End Sub
End Class