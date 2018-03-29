Public Class JsonObject
    Public Shared Function FromJsonString(obj As String) As JsonObject
        Return New Web.Script.Serialization.JavaScriptSerializer().Deserialize(Of JsonObject)(obj)
    End Function

    Public Function ToJsonString() As String
        Return New Web.Script.Serialization.JavaScriptSerializer().Serialize(Me)
    End Function
End Class
