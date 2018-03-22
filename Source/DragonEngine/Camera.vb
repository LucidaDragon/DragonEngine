Public Class Camera
    Implements ITickable

    Public Shared Property Location As Point
    Public Shared Property CameraUpKeys As Keys()
    Public Shared Property CameraDownKeys As Keys()
    Public Shared Property CameraLeftKeys As Keys()
    Public Shared Property CameraRightKeys As Keys()

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
End Class
