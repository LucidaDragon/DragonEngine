Public Class ObjectLoader
    Public Shared Function ObjectFromDisk(path As String) As ISerialize
        Dim dummyObj As ISerialize = TryCast(Activator.CreateInstance(Engine.GetTypeOfFile(path)), ISerialize)
        Return dummyObj.FromDisk(path)
    End Function
End Class
