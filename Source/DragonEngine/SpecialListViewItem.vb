Public Class SpecialListViewItem
    Inherits ListViewItem

    Private LastKnownText As String = String.Empty

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
            If (Not LastKnownText = Text) And (Not LastKnownText = String.Empty) Then
                obj.Name = Text
            Else
                Text = obj.Name
            End If
            LastKnownText = Text
        End If

        ToolTipText = Tag.GetType().Name
    End Sub
End Class
