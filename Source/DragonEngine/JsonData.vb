Public Class JsonData
    Private Shared Json As New Web.Script.Serialization.JavaScriptSerializer With {
        .MaxJsonLength = Integer.MaxValue,
        .RecursionLimit = Integer.MaxValue
    }

    ''' <summary>
    ''' Get a serialized ISerialize object from a file.
    ''' </summary>
    ''' <param name="path">The file to read from.</param>
    ''' <returns>The ISerialize object.</returns>
    Public Shared Function ObjectFromDisk(path As String) As ISerialize
        Try
            Dim dummyObj As ISerialize = FetchInstance(Engine.GetTypeOfFile(path))
            Return dummyObj.FromDisk(path)
        Catch ex As IO.FileNotFoundException
            LogWindow.Log("An error occured while loading """ & path & """: " & ex.Message)
            Return Nothing
        Catch ex As InvalidCastException
            LogWindow.Log("An error occured while loading """ & path & """: " & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function FetchInstance(objectType As Type) As ISerialize
        Dim obj As Object = Activator.CreateInstance(objectType)
        If TryCast(obj, ISerialize) Is Nothing Then
            Throw New InvalidCastException("""" & objectType.Name & """ does not support the ISerialize interface and cannot be loaded.")
        Else
            Return TryCast(obj, ISerialize)
        End If
    End Function

    ''' <summary>
    ''' Saves an object in memory to disk for later use.
    ''' </summary>
    ''' <typeparam name="T">The object's type.</typeparam>
    ''' <param name="obj">The object to save to disk.</param>
    ''' <param name="path">The file to save the data to.</param>
    Public Shared Sub WriteToFile(Of T)(obj As Object, path As String)
        IO.File.WriteAllText(path, Json.Serialize(CType(obj, T)))
    End Sub

    ''' <summary>
    ''' Reads an object from disk into memory.
    ''' </summary>
    ''' <typeparam name="T">The object's type.</typeparam>
    ''' <param name="path">The file to read data from.</param>
    ''' <returns>The object read from the disk.</returns>
    Public Shared Function ReadFromFile(Of T)(path As String) As T
        Return Json.Deserialize(Of T)(IO.File.ReadAllText(path))
    End Function
End Class
