#Disable Warning IDE0037
Public Class EditorWindow
    Private WithEvents SubForm As Form

    Public Sub EditObject(obj As Object)
        SplitDesigner.Panel2.Controls.Clear()

        If TryCast(obj, ISpecialEditObject) IsNot Nothing Then
            ObjectPropertyGrid.SelectedObject = Nothing
            SplitDesigner.Panel1.Enabled = False
            SplitDesigner.Panel2.Enabled = True

            Dim special As ISpecialEditObject = TryCast(obj, ISpecialEditObject)
            If special IsNot Nothing Then
                If special.GetDisplayType() = DisplayType.CustomControl Or special.GetDisplayType() = DisplayType.CustomControlNewWindow Then
                    If special.GetDisplayType() = DisplayType.CustomControlNewWindow Then
                        Hide()

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
                ElseIf special.GetDisplayType() = DisplayType.PropertyAndControl Then
                    SplitDesigner.Panel1.Enabled = True
                    SplitDesigner.Panel2.Enabled = True
                    SplitDesigner.Panel2.Controls.Add(special.GetControl())
                    ObjectPropertyGrid.SelectedObject = obj
                ElseIf special.GetDisplayType() = DisplayType.PropertyGrid Then
                    UsePropertyGrid(obj)
                End If
            Else
                UsePropertyGrid(obj)
            End If
        Else
            UsePropertyGrid(obj)
        End If

        SplitDesigner.Invalidate()
    End Sub

    Private Sub UsePropertyGrid(obj As Object)
        SplitDesigner.Panel1.Enabled = True
        SplitDesigner.Panel2.Enabled = False

        ObjectPropertyGrid.SelectedObject = obj
    End Sub

    Private Sub SpecialControlRemoved() Handles SplitDesigner.ControlRemoved
        If SplitDesigner.Panel2.Controls.Count = 0 Then
            Close()
        End If
    End Sub

    Private Sub ObjectPropertyGrid_PropertyValueChanged(s As Object, e As PropertyValueChangedEventArgs) Handles ObjectPropertyGrid.PropertyValueChanged
        ObjectBrowserWindow.AutoSave(False)
    End Sub

    Private Sub EditorWindow_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If SubForm IsNot Nothing Then
            Hide()
            SubForm.Show()
            SubForm.BringToFront()
        End If
    End Sub

    Private Sub EditorWindow_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If SubForm IsNot Nothing Then
            SubForm.Close()
        End If

        SubForm = Nothing
        SplitDesigner.Panel2.Controls.Clear()
        ObjectPropertyGrid.SelectedObject = Nothing
    End Sub

    Public Enum DisplayType
        PropertyGrid = 0
        CustomControl = 1
        PropertyAndControl = 2
        CustomControlNewWindow = 3
    End Enum
End Class
