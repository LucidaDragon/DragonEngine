Public Interface ISerialize
    ''' <summary>
    ''' Saves the object to disk.
    ''' </summary>
    ''' <param name="path">The file to save to.</param>
    Sub ToDisk(path As String)

    ''' <summary>
    ''' Loads the object from the specified file.
    ''' </summary>
    ''' <param name="path">The file to load from.</param>
    ''' <returns>The loaded ISerialize object.</returns>
    Function FromDisk(path As String) As ISerialize
End Interface
