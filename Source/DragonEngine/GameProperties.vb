Public Class GameProperties
    Implements IDataExchange
    Implements IListable

    Public Shared Settings As GameProperties

    Sub New()
        Settings = Me
    End Sub

    Public Property GameDisplayName As String = "Untitled Game"
    Public Property GameVersion As String = "1.0.0"
    Public Property GameAuthor As String = Environment.UserName
    Public Property GameResolution As Size = New Size(800, 600)
    Public Property GameIcon As Icon

    Public Sub FromStorage(storage As Byte()) Implements IDataExchange.FromStorage
        Dim index As Integer = 0
        Dim str As String = Text.Encoding.ASCII.GetChars(storage)
        Dim trim As String = String.Empty
        For Each elem In str.Split(Chr(2))
            If index = 0 Then
                GameDisplayName = elem
            ElseIf index = 1 Then
                GameVersion = elem
            ElseIf index = 2 Then
                GameAuthor = elem
            ElseIf index = 3 Then
                GameResolution = New Size(Integer.Parse(elem), GameResolution.Height)
            ElseIf index = 4 Then
                GameResolution = New Size(GameResolution.Width, Integer.Parse(elem))
            End If
            trim += elem & Chr(2)
            index += 1
        Next
        Dim icoStream As New IO.MemoryStream(Text.Encoding.ASCII.GetBytes(str.TrimStart(trim)))
        GameIcon = New Icon(icoStream)
    End Sub

    Public Function ToStorage() As Byte() Implements IDataExchange.ToStorage
        Dim start As String = GameDisplayName & Chr(2) & GameVersion & Chr(2) & GameAuthor & Chr(2) & GameResolution.Width & Chr(2) & GameResolution.Height & Chr(2)
        Dim buffer As Byte()
        Dim memStream As New IO.MemoryStream
        GameIcon.ToBitmap().Save(memStream, GameIcon.ToBitmap().RawFormat)
        buffer = memStream.ToArray()
        Return Text.Encoding.ASCII.GetBytes(start & Text.Encoding.ASCII.GetChars(buffer))
    End Function

    Public Function GetIcon() As String Implements IListable.GetIcon
        Return "gear.png"
    End Function

    Public Function GetText() As String Implements IListable.GetText
        Return "Game Properties"
    End Function

    Public Function GetPackageName() As String Implements IDataExchange.GetPackageName
        Return Globals.SettingsPackageName
    End Function
End Class
