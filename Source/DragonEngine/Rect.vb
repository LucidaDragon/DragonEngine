Public Class Rect
    Public Property X As Integer
    Public Property Y As Integer
    Public Property Width As Integer
    Public Property Height As Integer

    Public Shared Widening Operator CType(ByVal rect As Rect) As Rectangle
        Return New Rectangle(rect.X, rect.Y, rect.Width, rect.Height)
    End Operator
End Class
