Public Class Engine
    ''' <summary>
    ''' The working folder for the currently open project.
    ''' </summary>
    Public Shared ReadOnly EditorWorkingFolder As String = Application.StartupPath & "\ProjectCache"

    ''' <summary>
    ''' The currently loaded package.
    ''' </summary>
    Public Shared Package As Package

    ''' <summary>
    ''' Find a specified type via a string name.
    ''' </summary>
    ''' <param name="name">The type name to search for.</param>
    ''' <returns>The type or nothing if it was not found.</returns>
    Public Shared Function FindType(ByVal name As String) As Type
        Dim base As Type

        base = Reflection.Assembly.GetEntryAssembly.GetType(name, False, True)
        If base IsNot Nothing Then Return base

        base = Reflection.Assembly.GetExecutingAssembly.GetType(name, False, True)
        If base IsNot Nothing Then Return base

        For Each assembly As Reflection.Assembly In
          AppDomain.CurrentDomain.GetAssemblies
            base = assembly.GetType(name, False, True)
            If base IsNot Nothing Then Return base
        Next
        Return Nothing
    End Function

    ''' <summary>
    ''' Get the type of a specified file. Must be a file with a double dot extension where the middle keyword is a valid type. Throws InvalidCastException if this is not the case.
    ''' </summary>
    ''' <param name="path">The path to the file.</param>
    ''' <returns>The type or nothing if the type was not found.</returns>
    Public Shared Function GetTypeOfFile(path As String) As Type
        Dim file As String = IO.Path.GetFileName(path)
        If file.Split(".").Length = 3 Then
            Return FindType(file.Split(".").ElementAt(1))
        Else
            Throw New InvalidCastException(file)
        End If
    End Function

    ''' <summary>
    ''' Creates a new project in the working directory, overwriting the previous one.
    ''' </summary>
    ''' <param name="showDialog">Whether this action should show a dialog if it will overwrite files.</param>
    ''' <param name="createDeafultObjects">Whether to create deafult project objects.</param>
    ''' <returns>Whether this operation completed successfully.</returns>
    Public Shared Function NewProject(showDialog As Boolean, createDeafultObjects As Boolean) As Boolean
        If Not IO.Directory.Exists(EditorWorkingFolder) Then
            IO.Directory.CreateDirectory(EditorWorkingFolder)
        End If

        If IO.Directory.GetFiles(EditorWorkingFolder).Length > 0 Then
            If showDialog Then
                If MsgBox("The currently open project may not be saved. Are you sure you want to continue?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Return False
                End If
            End If

            For Each file In IO.Directory.GetFiles(EditorWorkingFolder)
                IO.File.Delete(file)
            Next
        End If

        Package = New Package

        If createDeafultObjects Then
            GameProperties.Init()
            ObjectBrowserWindow.AddObject(GameProperties.Instance, True)
            CameraControls.Init()
            ObjectBrowserWindow.AddObject(CameraControls.Instance, True)
        End If

        Return True
    End Function

    ''' <summary>
    ''' Load a project from a package.
    ''' </summary>
    ''' <param name="path">The package to load from.</param>
    Public Shared Sub OpenProject(path As String)
        NewProject(True, False)
        Package.ReadPackage(path)
    End Sub

    Public Class Graphics
        Public Shared DrawCalls As New List(Of DrawCall)

        Public Shared Sub SortZ()
            DrawCalls.Sort()
        End Sub

        Public Shared Sub Draw(g As Drawing.Graphics, bounds As Rectangle)
            For Each drawCall In DrawCalls
                g.DrawImage(drawCall.Sprite, CameraControls.Instance.Position.X - drawCall.Location.X, CameraControls.Instance.Position.Y - drawCall.Location.Y, drawCall.Size.Width, drawCall.Size.Height)
            Next
        End Sub

        Public Class DrawCall
            Public Property Location As New Point
            Public Property Size As New Size
            Public Property Sprite As Bitmap = My.Resources.cross
            Public Property DrawZ As Integer = 0

            Public Event Drawn(sender As Object, e As InvalidateEventArgs)

            Sub New()
            End Sub

            Sub New(location As Point, size As Size, sprite As Bitmap, drawZ As Integer)
                Me.Location = location
                Me.Size = size
                Me.Sprite = sprite
                Me.DrawZ = drawZ
            End Sub

            Public Sub WasDrawn()
                RaiseEvent Drawn(Me, New InvalidateEventArgs(New Rectangle(Location, Size)))
            End Sub

            Public Shared Operator =(a As DrawCall, b As DrawCall)
                Return a.DrawZ = b.DrawZ
            End Operator

            Public Shared Operator <>(a As DrawCall, b As DrawCall)
                Return Not a.DrawZ = b.DrawZ
            End Operator

            Public Shared Operator >(a As DrawCall, b As DrawCall)
                Return a.DrawZ > b.DrawZ
            End Operator

            Public Shared Operator <(a As DrawCall, b As DrawCall)
                Return a.DrawZ < b.DrawZ
            End Operator
        End Class
    End Class
End Class
