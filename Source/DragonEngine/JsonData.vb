Public Class JsonData
    ''' <summary>
    ''' Saves an object in memory to disk for later use.
    ''' </summary>
    ''' <typeparam name="T">The object's type.</typeparam>
    ''' <param name="obj">The object to save to disk.</param>
    ''' <param name="path">The file to save the data to.</param>
    Public Shared Sub WriteToFile(Of T)(obj As Object, path As String)
        IO.File.WriteAllText(path, New Web.Script.Serialization.JavaScriptSerializer().Serialize(CType(obj, T)))
    End Sub

    ''' <summary>
    ''' Reads an object from disk into memory.
    ''' </summary>
    ''' <typeparam name="T">The object's type.</typeparam>
    ''' <param name="path">The file to read data from.</param>
    ''' <returns>The object read from the disk.</returns>
    Public Shared Function ReadFromFile(Of T)(path As String) As T
        Return New Web.Script.Serialization.JavaScriptSerializer().Deserialize(Of T)(IO.File.ReadAllText(path))
    End Function
End Class
