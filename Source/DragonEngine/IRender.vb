Public Interface IRender
    Function GetArea(cameraLocation As Point) As Rectangle
    Function GetImage() As Bitmap
    Function GetZAxis() As Integer
End Interface
