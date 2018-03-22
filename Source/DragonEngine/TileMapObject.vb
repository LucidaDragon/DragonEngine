Public Class TileMapObject
    Inherits GameObject

    Sub New(name As String)
        MyBase.New(name)
    End Sub

    Public TileMap As New List(Of Tuple(Of Point, Integer))
    Public Property TileMapData As New List(Of TileData)
    Public Property Zones As New List(Of MapZone)

    Public Class Tile
        Public Property Location As Point
        Public Property TileSprite As Integer
    End Class

    Public Class TileData
        Public Property ID As Integer
        Public Property Sprite As String
            Get
                Return SelectedSprite.Name
            End Get
            Set(value As String)
                Try
                    SelectedSprite = GameObjectLookup.GetObjectByName(value)
                Catch
                    MsgBox("Sprite '" & value & "' not found.")
                End Try
            End Set
        End Property
        Public Property SelectedSprite As SpriteObject
    End Class
End Class
