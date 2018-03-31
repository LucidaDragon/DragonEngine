Public Class CameraControls
    Implements ISerialize
    Implements ITickable
    Implements IListIcon

    Public Property Position As Point
    Public Property Speed As Double
    Public Property UpTriggers As New List(Of Trigger)
    Public Property DownTriggers As New List(Of Trigger)
    Public Property LeftTriggers As New List(Of Trigger)
    Public Property RightTriggers As New List(Of Trigger)

    <ComponentModel.Browsable(False)>
    Public Property Name As String Implements INamedObject.Name
        Get
            Return "Camera"
        End Get
        Set(value As String)
        End Set
    End Property

    Public Shared Instance As CameraControls

    Public Shared Sub Init()
        Instance = New CameraControls
    End Sub

    Public Sub ToDisk(path As String) Implements ISerialize.ToDisk
        JsonData.WriteToFile(Of CameraControls)(Me, path)
    End Sub

    Public Function FromDisk(path As String) As ISerialize Implements ISerialize.FromDisk
        Instance = JsonData.ReadFromFile(Of CameraControls)(path)
        Return Instance
    End Function

    Public Sub Tick() Implements ITickable.Tick
        For Each elem In UpTriggers
            If elem.GetTrigger() Then
                Position.Offset(0, -Speed)
                Exit For
            End If
        Next

        For Each elem In DownTriggers
            If elem.GetTrigger() Then
                Position.Offset(0, Speed)
                Exit For
            End If
        Next

        For Each elem In LeftTriggers
            If elem.GetTrigger() Then
                Position.Offset(-Speed, 0)
                Exit For
            End If
        Next

        For Each elem In RightTriggers
            If elem.GetTrigger() Then
                Position.Offset(Speed, 0)
                Exit For
            End If
        Next
    End Sub

    Public Function GetIconName() As String Implements IListIcon.GetIconName
        Return "gamepad.png"
    End Function

    Public Function GetSubItems() As List(Of IListIcon) Implements IListIcon.GetSubItems
        Return New List(Of IListIcon)
    End Function
End Class
