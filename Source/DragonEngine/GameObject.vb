Public Class GameObject
    Public Property Name As String
    Public Property Data As New List(Of Data)
End Class

Public Class Data
    Public Property Name As String
    Public Property Value As String
End Class

Public Enum ObjectType
    Unknown = 0
    Script = 1
    Sprite = 2
    TileMap = 3
End Enum