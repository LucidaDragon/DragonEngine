Public Class PhysicsObject
    Inherits GameObject
    Implements ITickable

    Public Property Forces As New List(Of Force)
    Public Property Velocity As Point
    Public Property Position As Point

    Public Sub Tick() Implements ITickable.Tick
        Throw New NotImplementedException()
    End Sub

    Public Overrides Function GetIconName() As String
        Return "larger.png"
    End Function

    Public Overrides Sub ToDisk(path As String)
        JsonData.WriteToFile(Of PhysicsObject)(Me, path)
    End Sub

    Public Overrides Function FromDisk(path As String) As ISerialize
        Return JsonData.ReadFromFile(Of PhysicsObject)(path)
    End Function
End Class
