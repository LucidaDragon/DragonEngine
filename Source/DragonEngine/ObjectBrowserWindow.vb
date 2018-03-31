Public Class ObjectBrowserWindow
    Public SelectedObject As Object
    Public LastSaveLocation As String = Nothing

    Private OpenObjs As New List(Of ObjWindow)
    Private DeleteBlacklist As New List(Of Object)
    Private WithEvents Domain As AppDomain = AppDomain.CurrentDomain

    Private Class ObjWindow
        Public WithEvents Form As Form
        Public Property ID As Integer
        Sub New(obj As Object, parent As ObjectBrowserWindow, frm As Form)
            Form = frm
            ID = obj.GetHashCode()
        End Sub
        Sub Destroy() Handles Form.Closed
            Form = Nothing
        End Sub
    End Class

    ''' <summary>
    ''' Clean up any open objects that are null.
    ''' </summary>
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

    ''' <summary>
    ''' Check if an object is being edited.
    ''' </summary>
    ''' <param name="obj">The object to check for.</param>
    ''' <returns>Returns true if the object is being edited. Returns false if not.</returns>
    Public Function IsObjectOpen(obj As Object) As Boolean
        For Each elem In OpenObjs
            If elem.ID = obj.GetHashCode() Then
                Return True
            End If
        Next
        Return False
    End Function

    ''' <summary>
    ''' Get the form that is currently editing an object.
    ''' </summary>
    ''' <param name="obj">The object to check for.</param>
    ''' <returns>Returns a form or nothing if the object is not being edited.</returns>
    Public Function GetObjectWindow(obj As Object) As Form
        For Each elem In OpenObjs
            If elem.ID = obj.GetHashCode() Then
                Return elem.Form
            End If
        Next
        Return Nothing
    End Function

    ''' <summary>
    ''' Shows an object in the editor.
    ''' </summary>
    ''' <param name="obj">The object to show.</param>
    Public Sub ShowObject(obj As Object)
        If Not IsObjectOpen(obj) Then
            Dim frm As New EditorWindow()
            Dim openObj As New ObjWindow(obj, Me, frm)

            OpenObjs.Add(openObj)

            AddHandler frm.FormClosed, AddressOf CleanUpObjects
            frm.EditObject(obj)
            frm.Show()
        Else
            GetObjectWindow(obj).BringToFront()
        End If
    End Sub

    ''' <summary>
    ''' Adds an object to the ObjectView.
    ''' </summary>
    ''' <param name="obj">The object to add.</param>
    Public Sub AddObject(obj As Object, Optional permanent As Boolean = False)
        If obj Is Nothing Then
            Exit Sub
        End If

        If TryCast(obj, INamedObject) IsNot Nothing Then
            Dim named As INamedObject = TryCast(obj, INamedObject)
            If ObjectLookupTable.GetNamedItem(named.Name) Is Nothing Then
                ObjectLookupTable.Add(named)
                ObjectLookupTable.Refresh()
            Else
                ObjectLookupTable.Remove(named.Name)
                ObjectLookupTable.Add(named)
                ObjectLookupTable.Refresh()
            End If
        End If

        If permanent Then
            DeleteBlacklist.Add(obj)
        End If

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

            Dim item As New SpecialListViewItem(text) With {
                .ImageKey = "target.png",
                .Tag = obj
            }
            ObjectView.Items.Add(item)
        Else
            Dim listIcon As IListIcon = TryCast(obj, IListIcon)
            If Not New Text.RegularExpressions.Regex("\w\d+").Match(listIcon.Name).Success Then
                Dim count As Integer = 1

                For Each elem As ListViewItem In ObjectView.Items
                    If elem.Text.StartsWith(listIcon.Name) Then
                        count += 1
                    End If
                Next

                If count > 1 Then
                    listIcon.Name += count.ToString()
                End If
            End If

            Dim item As New SpecialListViewItem(listIcon.Name) With {
                .ImageKey = listIcon.GetIconName(),
                .Tag = obj
            }
            ObjectView.Items.Add(item)
        End If
    End Sub

    ''' <summary>
    ''' Deserialize a json file and add it as an object.
    ''' </summary>
    ''' <param name="path">The json file path.</param>
    Public Sub AddJsonFile(path As String)
        AddObject(JsonData.ObjectFromDisk(path), IO.Path.GetFileName(path).StartsWith("Engine."))
    End Sub

    ''' <summary>
    ''' Writes all objects to disk.
    ''' </summary>
    ''' <param name="sendToPackage">Optionally save to last package location.</param>
    ''' <returns>Whether the package was saved.</returns>
    Public Function AutoSave(sendToPackage As Boolean) As Boolean
        For Each file In IO.Directory.GetFiles(Engine.EditorWorkingFolder)
            IO.File.Delete(file)
        Next
        For Each elem As ListViewItem In ObjectView.Items
            Dim obj As ISerialize = TryCast(elem.Tag, ISerialize)
            If obj IsNot Nothing Then
                obj.ToDisk(Engine.EditorWorkingFolder & "\" & GetItemFileName(elem))
            End If
        Next

        GC.Collect()

        For Each item As SpecialListViewItem In ObjectView.Items
            item.Refresh()
        Next

        If IO.File.Exists(LastSaveLocation) And sendToPackage Then
            Engine.Package.WritePackage(LastSaveLocation)
            GC.Collect()
            Return True
        End If
        Return False
    End Function

    ''' <summary>
    ''' Get the package file name of a ListViewItem.
    ''' </summary>
    ''' <param name="item">The item to get the file name for.</param>
    ''' <returns>The file name.</returns>
    Public Function GetItemFileName(item As ListViewItem) As String
        Dim obj As ISerialize = TryCast(item.Tag, ISerialize)

        Dim perma As Boolean = False
        For Each elem In DeleteBlacklist
            If elem.Equals(item.Tag) Then
                perma = True
                Exit For
            End If
        Next

        If obj Is Nothing Then
            Return item.Text & "." & item.Tag.GetType().Name & ".json"
        Else
            If perma Then
                Return "Engine." & item.Text & "." & obj.GetType().Name & ".json"
            Else
                Return item.Text & "." & obj.GetType().Name & ".json"
            End If
        End If
    End Function

    ''' <summary>
    ''' Add an object and display a dialog to set it's name.
    ''' </summary>
    ''' <param name="obj">The object to rename.</param>
    Public Sub AddObjectWithDialog(obj As INamedObject)
        Dim dia As New TextInputBox("Enter Item Name")
        If dia.ShowDialog() = DialogResult.OK Then
            obj.Name = dia.Text
            AddObject(obj)
        End If
    End Sub

    Private Sub ObjectBrowserWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ObjectView.View = My.Settings.ViewType
        Engine.NewProject(False, True)
        Timer.Start()
    End Sub

    Private Sub ObjectView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ObjectView.SelectedIndexChanged
        If ObjectView.SelectedIndices.Count > 0 Then
            SelectedObject = ObjectView.Items.Item(ObjectView.SelectedIndices.Item(0)).Tag
            EditItemButton.Enabled = True
            If Not DeleteBlacklist.Contains(SelectedObject) Then
                DeleteButton.Enabled = True
            End If
        Else
            SelectedObject = Nothing
            EditItemButton.Enabled = False
            DeleteButton.Enabled = False
        End If
    End Sub

    Private Sub EditItemButton_Click(sender As Object, e As EventArgs) Handles EditItemButton.Click
        ShowObject(SelectedObject)
    End Sub

    Private Sub SaveProjectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveProjectToolStripMenuItem.Click
        Timer.Stop()
        If Not AutoSave(True) Then
            Dim dia As New SaveFileDialog With {
                .Title = "Save As",
                .DefaultExt = "dpak",
                .OverwritePrompt = True,
                .Filter = "*.dpak|Dragon Engine Package"
            }

            If dia.ShowDialog() = DialogResult.OK Then
                Engine.Package.WritePackage(dia.FileName)
                LastSaveLocation = dia.FileName
            End If
        End If
        Timer.Start()
    End Sub

    Private Sub ObjectBrowserWindow_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        CleanUpObjects()
        If OpenObjs.Count > 0 Then
            e.Cancel = True
        End If

        If Not Engine.NewProject(True, False) Then
            e.Cancel = True
        End If
        My.Settings.ViewType = ObjectView.View
        My.Settings.Save()
    End Sub

    Private Sub ChangeViewButton_Click(sender As Object, e As EventArgs) Handles ChangeViewButton.Click
        If ObjectView.View = View.LargeIcon Then
            ObjectView.View = View.SmallIcon
        ElseIf ObjectView.View = View.SmallIcon Then
            ObjectView.View = View.List
        ElseIf ObjectView.View = View.List Then
            ObjectView.View = View.LargeIcon
        End If
    End Sub

    Private Sub OpenProjectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenProjectToolStripMenuItem.Click
        Timer.Stop()
        Dim dia As New OpenFileDialog With {
            .Title = "Save As",
            .DefaultExt = "dpak",
            .Filter = "Dragon Engine Package|*.dpak"
        }

        If dia.ShowDialog() = DialogResult.OK Then
            DeleteBlacklist.Clear()
            Engine.OpenProject(dia.FileName)
            LastSaveLocation = dia.FileName
        End If
        AutoSave(False)
        Timer.Start()
    End Sub

    Private Sub AnimationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnimationToolStripMenuItem.Click
        AddObjectWithDialog(New Animation)
    End Sub

    Private Sub DeleteButton_Click(sender As Object, e As EventArgs) Handles DeleteButton.Click
        Dim item As ListViewItem = ObjectView.Items(ObjectView.SelectedIndices(0))
        If IO.File.Exists(Engine.EditorWorkingFolder & "\" & GetItemFileName(item)) Then
            IO.File.Delete(Engine.EditorWorkingFolder & "\" & GetItemFileName(item))
        End If
        If TryCast(item.Tag, INamedObject) IsNot Nothing Then
            ObjectLookupTable.Remove(TryCast(item.Tag, INamedObject).Name)
            ObjectLookupTable.Refresh()
        End If
        ObjectView.Items.Remove(item)
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        Dim beginEval As DateTime = DateTime.Now

        ObjectView.Invalidate()
        AutoSave(False)

        Timer.Interval = ((DateTime.Now - beginEval).TotalMilliseconds * 4) + 3000
    End Sub

    Private Sub ImageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImageToolStripMenuItem.Click
        Dim dia As New OpenFileDialog With {
            .DefaultExt = "png",
            .Filter = "Image Files|*.jpg;*.gif;*.png;*.bmp"
        }

        If dia.ShowDialog() = DialogResult.OK Then
            Dim img As New Image With {
                .Name = IO.Path.GetFileNameWithoutExtension(dia.FileName),
                .SelectedImage = New Bitmap(dia.FileName)
            }
            AddObject(img)
        End If
    End Sub

    Private Sub PlayButton_Click(sender As Object, e As EventArgs) Handles PlayButton.Click
        Enabled = False
        AddHandler Domain.UnhandledException, AddressOf Engine_UnhandledException
        GameWindow.Show()
        AddHandler GameWindow.FormClosed, AddressOf GameWindow_Closed
    End Sub

    Private Sub Engine_UnhandledException(sender As Object, e As UnhandledExceptionEventArgs)
        MsgBox("An error occured while the game was running:" & Environment.NewLine & TryCast(e.ExceptionObject, Exception).Message)
        GameWindow.Close()
    End Sub

    Private Sub GameWindow_Closed(sender As Object, e As FormClosedEventArgs)
        Enabled = True
        RemoveHandler GameWindow.FormClosed, AddressOf GameWindow_Closed
        RemoveHandler Domain.UnhandledException, AddressOf Engine_UnhandledException
    End Sub

    Private Sub ForceToolStripMenuItem_Click(sender As Object, e As EventArgs)
        AddObjectWithDialog(New Force)
    End Sub

    Private Sub GameObjectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GameObjectToolStripMenuItem.Click
        AddObjectWithDialog(New GameObject)
    End Sub

    Private Sub PhysicsObjectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PhysicsObjectToolStripMenuItem.Click
        AddObjectWithDialog(New PhysicsObject)
    End Sub

    Private Sub WorldToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WorldToolStripMenuItem.Click
        AddObjectWithDialog(New World)
    End Sub
End Class