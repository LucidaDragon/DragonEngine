Public Class Camera
    Implements ITickable
    Implements IListable
    Implements IDataExchange

    Public Shared Instance As Camera

    Sub New()
        Instance = Me
    End Sub

    Public Property Location As Point
    Public Property CameraUpKeys As New List(Of Keys)
    Public Property CameraDownKeys As New List(Of Keys)
    Public Property CameraLeftKeys As New List(Of Keys)
    Public Property CameraRightKeys As New List(Of Keys)

    Public Sub Tick(deltaSeconds As Double) Implements ITickable.Tick
        For Each key In CameraUpKeys
            If KeyManager.PressedKeys.Contains(key) Then
                Location = New Point(Location.X, Location.Y - 1)
                Exit For
            End If
        Next

        For Each key In CameraDownKeys
            If KeyManager.PressedKeys.Contains(key) Then
                Location = New Point(Location.X, Location.Y + 1)
                Exit For
            End If
        Next

        For Each key In CameraLeftKeys
            If KeyManager.PressedKeys.Contains(key) Then
                Location = New Point(Location.X - 1, Location.Y)
                Exit For
            End If
        Next

        For Each key In CameraRightKeys
            If KeyManager.PressedKeys.Contains(key) Then
                Location = New Point(Location.X + 1, Location.Y)
                Exit For
            End If
        Next
    End Sub

    Public Function GetIcon() As String Implements IListable.GetIcon
        Return "zoom.png"
    End Function

    Public Function GetText() As String Implements IListable.GetText
        Return "Camera"
    End Function

    Public Sub FromStorage(storage() As Byte) Implements IDataExchange.FromStorage
        Dim str As String = Text.Encoding.ASCII.GetChars(storage)
        Dim parts As String() = str.Split(Chr(2))
        Location = New Point(Integer.Parse(parts(0)), Integer.Parse(parts(1)))
        parts = parts(2).Split(Chr(1))

        For Each elem As String In parts(0).Split(",")
            CameraUpKeys.Add(Integer.Parse(elem))
        Next

        For Each elem As String In parts(1).Split(",")
            CameraDownKeys.Add(Integer.Parse(elem))
        Next

        For Each elem As String In parts(2).Split(",")
            CameraLeftKeys.Add(Integer.Parse(elem))
        Next

        For Each elem As String In parts(3).Split(",")
            CameraRightKeys.Add(Integer.Parse(elem))
        Next
    End Sub

    Public Function ToStorage() As Byte() Implements IDataExchange.ToStorage
        Dim keys As String = String.Empty
        keys += Chr(2)
        For Each elem As Integer In CameraUpKeys
            keys += elem & ","
        Next
        keys.TrimEnd(",")
        keys += Chr(1)
        For Each elem As Integer In CameraDownKeys
            keys += elem & ","
        Next
        keys.TrimEnd(",")
        keys += Chr(1)
        For Each elem As Integer In CameraLeftKeys
            keys += elem & ","
        Next
        keys.TrimEnd(",")
        keys += Chr(1)
        For Each elem As Integer In CameraRightKeys
            keys += elem & ","
        Next
        keys.TrimEnd(",")

        Return Text.Encoding.ASCII.GetBytes(Location.X & Chr(2) & Location.Y & keys)
    End Function

    Public Function GetPackageName() As String Implements IDataExchange.GetPackageName
        Return Globals.CameraPackageName
    End Function
End Class
