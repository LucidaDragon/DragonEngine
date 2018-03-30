#Disable Warning IDE0037
Public Class EditorWindow
    Private WithEvents SubForm As Form

    Public Sub EditObject(obj As Object)
        SplitDesigner.Panel2.Controls.Clear()

        If TryCast(obj, ISpecialEditObject) Is Nothing Then
            PropertyGrid1.SelectedObject = Nothing
            SplitDesigner.Panel1.Enabled = False
            SplitDesigner.Panel2.Enabled = True

            Dim special As ISpecialEditObject = TryCast(obj, ISpecialEditObject)
            If special IsNot Nothing Then
                If special.GetControl() IsNot Nothing Then
                    If special.ShowInNewWindow() Then
                        SubForm = New Form With {
                            .Location = Location,
                            .Size = Size,
                            .WindowState = WindowState,
                            .Icon = Icon,
                            .FormBorderStyle = FormBorderStyle.SizableToolWindow,
                            .Text = "Edit"
                        }
                        AddHandler SubForm.FormClosed, AddressOf Close
                        SubForm.Controls.Add(special.GetControl())

                        If special.ShowModal Then
                            SubForm.ShowDialog()
                        Else
                            SubForm.Show()
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
        Else
            SplitDesigner.Panel1.Enabled = True
            SplitDesigner.Panel2.Enabled = False

            PropertyGrid1.SelectedObject = obj
        End If

        SplitDesigner.Invalidate()
    End Sub

    Private Sub SpecialControlRemoved() Handles SplitDesigner.ControlRemoved
        If SplitDesigner.Panel2.Controls.Count = 0 Then
            Close()
        End If
    End Sub
End Class
