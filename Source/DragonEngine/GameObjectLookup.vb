Public Class GameObjectLookup
    Private Shared GameObjects As New List(Of GameObject)

    Public Shared Function GetObjectByName(name As String) As GameObject
        For Each obj In GameObjects
            If obj.Name = name Then
                Return obj
            End If
        Next
        Return Nothing
    End Function

    Public Shared Sub SetObjectList(ByRef list As List(Of GameObject))
        GameObjects = list
    End Sub
End Class
