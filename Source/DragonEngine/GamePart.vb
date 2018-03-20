Public Class GamePart
    Public Property Name As String
    Public Property Contents As Byte()

    Sub New(name As String, contents As Byte())
        Me.Name = name
        Me.Contents = contents
    End Sub
End Class
