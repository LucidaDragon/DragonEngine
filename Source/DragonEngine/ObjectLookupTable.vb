Public Class ObjectLookupTable
    Public Shared Objects As New List(Of ObjectLookup)

    Public Shared Sub Refresh()
        Dim toRemove As New List(Of ObjectLookup)
        For Each lookup In Objects
            If lookup.Obj Is Nothing Then
                toRemove.Add(lookup)
            Else
                If Not lookup.Obj.Name = lookup.Name Then
                    lookup.Name = lookup.Obj.Name
                End If
            End If
        Next
        For Each elem In toRemove
            Objects.Remove(elem)
        Next
    End Sub

    Public Shared Sub Add(obj As INamedObject)
        Objects.Add(New ObjectLookup(obj))
    End Sub

    Public Shared Sub Remove(name As String)
        For i As Integer = 0 To Objects.Count - 1
            If Objects(i).Name = name Then
                Objects.RemoveAt(i)
                Exit For
            End If
        Next
    End Sub

    Public Shared Function GetNamedItem(name As String) As INamedObject
        For Each elem In Objects
            If elem.Name = name Then
                Return elem.Obj
            End If
        Next
        Return Nothing
    End Function

    Public Shared Function GetItem(Of T)(name As String) As T
        For Each elem In Objects
            If elem.Name = name Then
                Try
                    Return elem.Obj
                Catch
                End Try
            End If
        Next
        Throw New IO.FileNotFoundException(GetType(T).Name & " with name """ & name & """ was not found.")
    End Function

    Public Class ObjectLookup
        Public Name As String
        Public Obj As INamedObject
        Sub New(obj As INamedObject)
            Me.Obj = obj
            Name = obj.Name
        End Sub
    End Class
End Class
