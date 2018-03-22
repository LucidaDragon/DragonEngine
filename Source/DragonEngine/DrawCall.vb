Public Class DrawCall
    Public Property Image As Bitmap
    Public Property Location As Point
    Public Property Size As Size
    Public ReadOnly Property Rectangle As Rectangle
        Get
            Return New Rectangle(Location, Size)
        End Get
    End Property
End Class
