Public Class Animation
    Implements ISerialize
    Implements IDrawing
    Implements IListIcon
    Implements ISpecialEditObject

    ''' <summary>
    ''' List of images to animate with.
    ''' </summary>
    ''' <returns>The list of images to animate with.</returns>
    Public Property Images As New List(Of Image)

    ''' <summary>
    ''' Delay between images in milliseconds.
    ''' </summary>
    ''' <returns>Delay in milliseconds.</returns>
    Public Property Delay As Integer = 1000

    Private BeginAnim As DateTime = DateTime.Now

    Private Property CurrentFrame As Double
        Get
            Return FrameIndex
        End Get
        Set(value As Double)
            If value > Images.Count - 1 Then
                value = 0
            ElseIf value < 0 Then
                value = Images.Count - 1
            End If

            FrameIndex = value
        End Set
    End Property

    Public Property Name As String Implements IListIcon.Name

    Private FrameIndex As Double = 0

    Public Sub ToDisk(path As String) Implements ISerialize.ToDisk
        JsonData.WriteToFile(Of Animation)(Me, path)
    End Sub

    Public Function FromDisk(path As String) As ISerialize Implements ISerialize.FromDisk
        Return JsonData.ReadFromFile(Of Animation)(path)
    End Function

    Public Function GetCurrentImage() As Bitmap Implements IDrawing.GetCurrentImage
        If Images.Count > 0 Then
            CurrentFrame += (DateTime.Now - BeginAnim).TotalMilliseconds / Delay
            If Images.Item(CurrentFrame).SelectedImage IsNot Nothing Then
                Return Images.Item(CurrentFrame).SelectedImage
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
    End Function

    Public Function GetIconName() As String Implements IListIcon.GetIconName
        Return "video.png"
    End Function

    Public Function GetSubItems() As List(Of IListIcon) Implements IListIcon.GetSubItems
        Return Images.Cast(Of IListIcon)
    End Function

    Public Function GetControl() As Control Implements ISpecialEditObject.GetControl
        Return New AnimationDisplay(Me)
    End Function

    Public Function GetDisplayType() As EditorWindow.DisplayType Implements ISpecialEditObject.GetDisplayType
        Return EditorWindow.DisplayType.PropertyAndControl
    End Function

    Public Function ShowModal() As Boolean Implements ISpecialEditObject.ShowModal
        Return False
    End Function
End Class
