Public Class SpecialListViewItem
    Inherits ListViewItem

    Sub New()
        MyBase.New()
    End Sub

    Sub New(text As String)
        MyBase.New(text)
    End Sub

    Public Sub Refresh()
        Dim obj As IListIcon = TryCast(Tag, IListIcon)

        If Not ObjectLookupTable.GetNamedItem(obj.Name).Equals(obj) Then
            ListView.Items.Remove(Me)
        End If

        If obj IsNot Nothing Then
            Text = obj.Name
        End If
    End Sub
End Class
