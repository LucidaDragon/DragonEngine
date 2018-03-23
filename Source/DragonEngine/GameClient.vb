Public Class GameClient
    Public Property Levels As New List(Of Level)

    Sub New()
        InitializeComponent()
    End Sub

    Sub New(pakPath As String)
        InitializeComponent()
        Me.Size = Size
        Try
            Dim pak As New IO.Compression.ZipArchive(New IO.FileStream(pakPath, IO.FileMode.Open), IO.Compression.ZipArchiveMode.Read)
            For Each entry In pak.Entries
                GC.Collect()
                Dim buffer(entry.Length) As Byte
                Dim stream As IO.Stream = entry.Open()
                stream.Read(buffer, 0, entry.Length)
                stream.Close()
                If entry.Name = Globals.SettingsPackageName Then
                    Dim settings As New GameProperties
                    settings.FromStorage(buffer)
                ElseIf entry.Name = Globals.CameraPackageName Then
                    Dim camera As New Camera
                    camera.FromStorage(buffer)
                ElseIf entry.Name.EndsWith(Globals.LevelPackageSuffix) Then
                    Dim level As New Level
                    level.FromStorage(buffer)
                    Levels.Add(level)
                End If
            Next
        Catch ex As Exception
            MsgBox("An error occured while loading the game files:" & Environment.NewLine & ex.Message & Environment.NewLine & ex.ToString)
        End Try
    End Sub

    Public Sub LoadLevel(name As String)
        For Each level In Levels
            If level.LevelName = name Then

            End If
        Next
    End Sub

    Public GameObjects As New List(Of ITickable)
    Public DrawCalls As New List(Of IRender)

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

        DrawCalls.Sort(Function(x, y) x.GetZAxis().CompareTo(y.GetZAxis()))

        For Each drawCall In DrawCalls
            e.Graphics.DrawImage(drawCall.GetImage(), drawCall.GetArea(Camera.Instance.Location))
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

    Private Sub GameClient_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Size = GameProperties.Settings.GameResolution
        Text = GameProperties.Settings.GameDisplayName
        Icon = GameProperties.Settings.GameIcon
    End Sub
End Class