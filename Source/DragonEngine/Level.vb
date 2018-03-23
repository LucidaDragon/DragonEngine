Public Class Level
    Implements IListable
    Implements IRender
    Implements IDataExchange

    Public Property BackgroundImage As Bitmap
    Public Property LevelName As String = "Untitled Level"

    Public Sub FromStorage(storage() As Byte) Implements IDataExchange.FromStorage
        Throw New NotImplementedException()
    End Sub

    Public Function GetIcon() As String Implements IListable.GetIcon
        Return "exit.png"
    End Function

    Public Function GetText() As String Implements IListable.GetText
        Return LevelName
    End Function

    Public Function GetArea(cameraLocation As Point) As Rectangle Implements IRender.GetArea
        Return New Rectangle(New Point(0, 0), BackgroundImage.Size)
    End Function

    Public Function GetImage() As Bitmap Implements IRender.GetImage
        Return BackgroundImage
    End Function

    Public Function GetZAxis() As Integer Implements IRender.GetZAxis
        Return Integer.MinValue
    End Function

    Public Function ToStorage() As Byte() Implements IDataExchange.ToStorage
        Throw New NotImplementedException()
    End Function

    Public Function GetPackageName() As String Implements IDataExchange.GetPackageName
        Return LevelName & Globals.LevelPackageSuffix
    End Function
End Class
