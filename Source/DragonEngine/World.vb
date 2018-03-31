Public Class World
    Implements IListIcon
    Implements ISerialize
    Implements ISpecialEditObject
    Implements IDrawing

    Public Property StaticMap As String
        Get
            If SelectedStaticMap Is Nothing Then
                Return ""
            Else
                Return SelectedStaticMap.Name
            End If
        End Get
        Set(value As String)
            Try
                SelectedStaticMap = ObjectLookupTable.GetItem(Of Image)(value)
            Catch ex As Exception
                LogWindow.Log(ex.Message)
            End Try
        End Set
    End Property
    <ComponentModel.Browsable(False)>
    Public Property SelectedStaticMap As Image

    Public Property AnimatedMap As String
        Get
            If SelectedAnimMap Is Nothing Then
                Return ""
            Else
                Return SelectedAnimMap.Name
            End If
        End Get
        Set(value As String)
            Try
                SelectedAnimMap = ObjectLookupTable.GetItem(Of Animation)(value)
            Catch ex As Exception
                LogWindow.Log(ex.Message)
            End Try
        End Set
    End Property
    <ComponentModel.Browsable(False)>
    Public Property SelectedAnimMap As Animation

    <ComponentModel.Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor,System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
    Public Property GameObjects As New List(Of String)

    <ComponentModel.Browsable(False), Web.Script.Serialization.ScriptIgnore>
    Public Property RealGameObjects As New GameObjectList(GameObjects)

    Public Property UseStaticMap As Boolean = True
    Public Property MapOffset As New Point(0, 0)

    Public Property Collision As New List(Of Rectangle)

    Public Property Name As String Implements INamedObject.Name

    Public Sub ToDisk(path As String) Implements ISerialize.ToDisk
        JsonData.WriteToFile(Of World)(Me, path)
    End Sub

    Public Function GetIconName() As String Implements IListIcon.GetIconName
        Return "exit.png"
    End Function

    Public Function GetSubItems() As List(Of IListIcon) Implements IListIcon.GetSubItems
        Return New List(Of IListIcon)
    End Function

    Public Function FromDisk(path As String) As ISerialize Implements ISerialize.FromDisk
        Return JsonData.ReadFromFile(Of World)(path)
    End Function

    Public Function GetControl() As Control Implements ISpecialEditObject.GetControl
        Return New WorldDisplay(Me)
    End Function

    Public Function GetDisplayType() As EditorWindow.DisplayType Implements ISpecialEditObject.GetDisplayType
        Return EditorWindow.DisplayType.PropertyAndControl
    End Function

    Public Function ShowModal() As Boolean Implements ISpecialEditObject.ShowModal
        Return False
    End Function

    Public Function GetCurrentImage() As Bitmap Implements IDrawing.GetCurrentImage
        If UseStaticMap Then
            If SelectedStaticMap Is Nothing Then
                Return Nothing
            Else
                Return SelectedStaticMap.SelectedImage
            End If
        Else
            If SelectedAnimMap Is Nothing Then
                Return Nothing
            Else
                Return SelectedAnimMap.GetCurrentImage()
            End If
        End If
    End Function

    Public Class Rectangle
        Public Property Location As New Point(0, 0)
        Public Property Size As New Size(1, 1)

        Sub New()
        End Sub

        Sub New(location As Point, size As Size)
            Me.Location = location
            Me.Size = size
        End Sub

        Public Shared Widening Operator CType(obj As Rectangle) As Drawing.Rectangle
            Return New Drawing.Rectangle(obj.Location, obj.Size)
        End Operator

        Public Shared Widening Operator CType(obj As Drawing.Rectangle) As Rectangle
            Return New Rectangle(obj.Location, obj.Size)
        End Operator
    End Class

    Public Class GameObjectList
        Implements IReadOnlyList(Of GameObject)

        Public Source As List(Of String)

        Sub New()
        End Sub

        Sub New(source As List(Of String))
            Me.Source = source
        End Sub

        Default Public ReadOnly Property Item(index As Integer) As GameObject Implements IReadOnlyList(Of GameObject).Item
            Get
                Return ObjectLookupTable.GetItem(Of GameObject)(Source.Item(index))
            End Get
        End Property

        Public ReadOnly Property Count As Integer Implements IReadOnlyCollection(Of GameObject).Count
            Get
                Return Source.Count
            End Get
        End Property

        Public Function GetEnumerator() As IEnumerator(Of GameObject) Implements IEnumerable(Of GameObject).GetEnumerator
            Dim result As New List(Of GameObject)
            For Each elem In Source
                result.Add(ObjectLookupTable.GetItem(Of GameObject)(elem))
            Next
            Return result.GetEnumerator()
        End Function

        Private Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return Source.GetEnumerator()
        End Function
    End Class
End Class
