Public Class TileMapObject
    Inherits GameObject

    Public TileMap As New List(Of Tuple(Of Point, Integer))
    Public TileMapData As New List(Of Tuple(Of Integer))
    Public Property Zones As New List(Of MapZone)
End Class
