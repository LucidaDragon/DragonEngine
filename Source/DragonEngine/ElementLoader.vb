Public Class ElementLoader
    Public Shared Elements As New List(Of Level.Element)

    Public Shared Function GetElementFromName(name As String) As Level.Element
        For Each elem In Elements
            If elem.GetPackageName() = name Then
                Return elem
            End If
        Next
        Return Nothing
    End Function
End Class
