Public Class Image
    Implements ISerialize
    Implements IDrawing
    Implements IListIcon

    <Web.Script.Serialization.ScriptIgnore>
    Public Property SelectedImage As Bitmap
        Get
            If Cache Is Nothing Then
                If BitmapData Is Nothing Then
                    Return Nothing
                Else
                    Dim memStream As New IO.MemoryStream
                    Dim arr As Byte() = Convert.FromBase64String(BitmapData)
                    memStream.Write(arr, 0, arr.Length)
                    Cache = New Bitmap(memStream)
                    Return Cache
                End If
            Else
                Return Cache
            End If
        End Get
        Set(value As Bitmap)
            Dim memStream As New IO.MemoryStream
            value.Save(memStream, value.RawFormat)
            BitmapData = Convert.ToBase64String(memStream.GetBuffer())
            Cache = value
        End Set
    End Property
    <ComponentModel.Browsable(False)>
    Public Property BitmapData As String

    Public Property Name As String Implements IListIcon.Name

    Private Cache As Bitmap

    Public Sub ToDisk(path As String) Implements ISerialize.ToDisk
        IO.File.WriteAllText(path, BitmapData)
    End Sub

    Public Function FromDisk(path As String) As ISerialize Implements ISerialize.FromDisk
        BitmapData = IO.File.ReadAllText(path)
        Return Me
    End Function

    Public Function GetCurrentImage() As Bitmap Implements IDrawing.GetCurrentImage
        Return SelectedImage
    End Function

    Public Function GetIconName() As String Implements IListIcon.GetIconName
        Return "movie.png"
    End Function

    Public Function GetSubItems() As List(Of IListIcon) Implements IListIcon.GetSubItems
        Return New List(Of IListIcon)
    End Function
End Class
