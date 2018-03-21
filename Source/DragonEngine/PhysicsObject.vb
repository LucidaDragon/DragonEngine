Public Class PhysicsObject
    Inherits GameObject

    Public Property Position As New Point
    Public Property Velocity As New Point

    Public Property Forces As New List(Of Force)

    Public Overrides Sub Tick(deltaSeconds As Double)
        If deltaSeconds > 0.5 Then
            Position = New Point((Position.X + Velocity.X) * deltaSeconds, (Position.Y + Velocity.Y) * deltaSeconds)
        Else
            Position = New Point(Position.X + Velocity.X, Position.Y + Velocity.Y)
        End If

        Dim accel As New Point(0, 0)
        For Each force In Forces
            accel += New Point(force.Direction.X * force.Magnitude, force.Direction.Y * force.Magnitude)
        Next
        Velocity = New Point(Velocity.X * accel.X, Velocity.Y * accel.Y)
    End Sub
End Class
