Public Class RenderedObject
    Inherits GameObject

    Sub New(name As String)
        MyBase.New(name)
    End Sub

    Public Property Sprite As String
        Get
            If SelectedSprite IsNot Nothing Then
                Return SelectedSprite.Name
            Else
                Return ""
            End If
        End Get
        Set(value As String)
            SelectedSprite = GameObjectLookup.GetObjectByName(value)
        End Set
    End Property
    Public Property SelectedSprite As SpriteObject

    Public Property WorldPosition As Point
End Class
