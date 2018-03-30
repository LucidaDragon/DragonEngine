#Disable Warning IDE0037
Public Class EditorWindow
    Public Sub EditObject(obj As Object)
        SplitDesigner.Panel2.Controls.Clear()

        If TryCast(obj, ISpecialEditObject) Is Nothing Then
            PropertyGrid1.SelectedObject = Nothing
            SplitDesigner.Panel1.Enabled = False
            SplitDesigner.Panel2.Enabled = True

            Dim special As ISpecialEditObject = TryCast(obj, ISpecialEditObject)
            If special.GetControl() IsNot Nothing Then
                If special.ShowInNewWindow() Then
                    Dim frm As New Form With {
                        .Location = Location,
                        .Size = Size,
                        .WindowState = WindowState,
                        .Icon = Icon,
                        .FormBorderStyle = FormBorderStyle.SizableToolWindow,
                        .Text = "Edit"
                    }
                    frm.Controls.Add(special.GetControl())
                    If special.ShowModal Then
                        frm.ShowDialog()
                    Else
                        frm.Show()
                    End If
                Else
                    SplitDesigner.Panel2.Controls.Add(special.GetControl())
                End If
            End If
        Else
            SplitDesigner.Panel1.Enabled = True
            SplitDesigner.Panel2.Enabled = False

            PropertyGrid1.SelectedObject = obj
        End If

        SplitDesigner.Invalidate()
    End Sub
End Class
