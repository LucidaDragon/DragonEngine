Public Interface IListIcon
    Function GetIconName() As String
    Function GetSubItems() As List(Of IListIcon)
    Property Name As String
End Interface
