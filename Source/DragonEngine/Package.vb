Public Class Package
    ''' <summary>
    ''' The list of files in this package.
    ''' </summary>
    Public Files As New List(Of String)

    ''' <summary>
    ''' Writes this package to disk.
    ''' </summary>
    ''' <param name="path">The path to write to.</param>
    Public Sub WritePackage(path As String)
        IO.Compression.ZipFile.CreateFromDirectory(Engine.EditorWorkingFolder, path)
    End Sub

    ''' <summary>
    ''' Reads a package zip file and adds it to the working directory.
    ''' </summary>
    ''' <param name="path">The path to the package.</param>
    ''' <returns>A package object with the extracted files.</returns>
    Public Shared Function ReadPackage(path As String) As Package
        Dim pkg As New Package
        IO.Compression.ZipFile.ExtractToDirectory(path, Engine.EditorWorkingFolder)
        For Each file In IO.Directory.GetFiles(Engine.EditorWorkingFolder)
            If IO.Path.GetFileName(file).EndsWith(".json") And IO.Path.GetFileName(file).Split(".").Length >= 3 Then
                pkg.Files.Add(file)
            End If
        Next
        Return pkg
    End Function
End Class
