Public Interface IListIcon
    Inherits INamedObject
    Function GetIconName() As String
    Function GetSubItems() As List(Of IListIcon)
End Interface
