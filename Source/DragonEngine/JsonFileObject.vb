Public Class JsonFileObject
    Inherits JsonObject

    Public Property Path As String

    Public Shared Shadows Function FromJsonString(path As String) As JsonFileObject
        If IO.File.Exists(path) Then
            Dim obj As JsonFileObject = TryCast(JsonObject.FromJsonString(IO.File.ReadAllText(path)), JsonFileObject)
            If obj Is Nothing Then
                Throw New NullReferenceException(path)
            Else
                obj.Path = path
                Return obj
            End If
        Else
            Throw New IO.FileNotFoundException(path)
        End If
    End Function

    Public Shadows Function ToJsonString() As String
        IO.File.WriteAllText(Path, New Web.Script.Serialization.JavaScriptSerializer().Serialize(Me))
        Return Path
    End Function
End Class
