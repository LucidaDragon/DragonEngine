Public Class ObjectBrowserWindow
    Public LargeIconList As New ImageList
    Private OpenObjs As New List(Of ObjWindow)

    Private Class ObjWindow
        Public WithEvents Form As Form
        Public Property ID As Integer
        Sub New(obj As Object, frm As Form)
            Form = frm
            ID = obj.GetHashCode()
        End Sub
        Sub Destroy() Handles Form.Closed
            Form = Nothing
        End Sub
    End Class

    Public Sub CleanUpObjects()
        Dim toRemove As New List(Of ObjWindow)
        For Each obj In OpenObjs
            If obj.Form Is Nothing Then
                toRemove.Add(obj)
            End If
        Next
        For Each obj In toRemove
            OpenObjs.Remove(obj)
        Next
    End Sub

    Public Function IsObjectOpen(obj As Object) As Boolean
        For Each elem In OpenObjs
            If elem.ID = obj.GetHashCode() Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Sub ShowObject(obj As Object)
        If Not IsObjectOpen(obj) Then
            Dim frm As New EditorWindow()
            frm.EditObject(obj)
            frm.Show()
        End If
    End Sub

    Public Sub AddObject(obj As Object)
        If TryCast(obj, IListIcon) Is Nothing Then
            Dim count As Integer = 1
            For Each elem As ListViewItem In ObjectView.Items
                If elem.Text.StartsWith(obj.GetType().Name) Then
                    count += 1
                End If
            Next

            Dim text As String = obj.GetType().Name
            If count > 1 Then
                text += count.ToString()
            End If

            Dim item As New ListViewItem(text) With {
                .ImageKey = "object",
                .Tag = obj
            }
            ObjectView.Items.Add(item)
        Else
            Dim listIcon As IListIcon = TryCast(obj, IListIcon)
            If Not New Text.RegularExpressions.Regex("\w\d+").Match(listIcon.Text).Success Then
                Dim count As Integer = 1

                For Each elem As ListViewItem In ObjectView.Items
                    If elem.Text.StartsWith(listIcon.Text) Then
                        count += 1
                    End If
                Next

                If count > 1 Then
                    listIcon.Text += count.ToString()
                End If
            End If

            Dim item As New ListViewItem(listIcon.Text) With {
                .ImageKey = listIcon.GetIconName(),
                .Tag = obj
            }
        End If
    End Sub

    Public Sub AddJsonFile(path As String)
        Dim obj As JsonFileObject = JsonFileObject.FromJsonString(path)
        AddObject(obj)
    End Sub

    Private Sub ObjectBrowserWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LargeIconList.Images.AddRange(IconList.Images.OfType(Of Image).ToArray())
    End Sub

    Private Sub ObjectView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ObjectView.SelectedIndexChanged
        If ObjectView.SelectedIndices.Count > 0 Then

        End If
    End Sub
End Class