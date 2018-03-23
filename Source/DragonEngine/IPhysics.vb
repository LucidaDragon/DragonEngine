Public Interface IPhysics
    Inherits ITickable
    Function GetCollisionLayers() As List(Of Integer)
    Function GetBounds() As Rectangle
End Interface
