Public Class GameObject
    Implements IListIcon
    Implements ISerialize

    Public Property DrawData As New List(Of Engine.Graphics.DrawCall)

    Public Property Name As String Implements INamedObject.Name
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As String)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Overridable Sub ToDisk(path As String) Implements ISerialize.ToDisk
        JsonData.WriteToFile(Of GameObject)(Me, path)
    End Sub

    Public Overridable Function GetIconName() As String Implements IListIcon.GetIconName
        Return "contrast.png"
    End Function

    Public Function GetSubItems() As List(Of IListIcon) Implements IListIcon.GetSubItems
        Return New List(Of IListIcon)
    End Function

    Public Overridable Function FromDisk(path As String) As ISerialize Implements ISerialize.FromDisk
        Return JsonData.ReadFromFile(Of GameObject)(path)
    End Function
End Class
