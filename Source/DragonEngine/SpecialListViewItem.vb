Public Class SpecialListViewItem
    Inherits ListViewItem

    Public Shadows WithEvents ListView As ListView

    Sub New()
        MyBase.New()
    End Sub

    Sub New(text As String)
        MyBase.New(text)
    End Sub

    Private Sub Refresh() Handles ListView.Invalidated, ListView.BeforeLabelEdit, ListView.ItemSelectionChanged
        Dim obj As IListIcon = TryCast(Tag, IListIcon)
        If obj IsNot Nothing Then
            Text = obj.Name
        End If
    End Sub

    Private Sub TextEdited(sender As Object, e As LabelEditEventArgs) Handles ListView.AfterLabelEdit
        If ListView.Items.Item(e.Item).Equals(Me) Then
            Dim obj As IListIcon = TryCast(Tag, IListIcon)
            If obj IsNot Nothing Then
                obj.Name = Text
            End If
        End If
    End Sub
End Class
