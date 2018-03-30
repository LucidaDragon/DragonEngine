Public Class Image
    Implements ISerialize

    <Web.Script.Serialization.ScriptIgnore>
    Public Property SelectedImage As Bitmap
        Get
            If Bitmap Is Nothing Then
                Return Nothing
            Else
                Dim memStream As New IO.MemoryStream
                Dim arr As Byte() = Convert.FromBase64String(Bitmap)
                memStream.Write(arr, 0, arr.Length)
                Return New Bitmap(memStream)
            End If
        End Get
        Set(value As Bitmap)
            Dim memStream As New IO.MemoryStream
            value.Save(memStream, value.RawFormat)
            Bitmap = Convert.ToBase64String(memStream.GetBuffer())
        End Set
    End Property
    <ComponentModel.Browsable(False)>
    Public Property Bitmap As String

    Public Sub ToDisk(path As String) Implements ISerialize.ToDisk
        IO.File.WriteAllText(path, Bitmap)
    End Sub

    Public Function FromDisk(path As String) As ISerialize Implements ISerialize.FromDisk
        Bitmap = IO.File.ReadAllText(path)
        Return Me
    End Function
End Class
