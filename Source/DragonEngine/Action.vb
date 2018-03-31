Public Class Action
    Implements IListIcon
    Implements ISerialize
    Implements ITickable

    Public Property Triggers As New List(Of Trigger)
    Public Property Action As ActionType = ActionType.DoNothing
    Public Property IfLevel As String
    Public Property IfMessage As String

    Public Sub FireAction()
        If Not Action = ActionType.DoNothing Then
            If Action = ActionType.LoadLevel Then
                GameWindow.LoadLevel(IfLevel)
            ElseIf Action = ActionType.PostObjMsg Then
                Messaging.Post(IfMessage)
            End If
        End If
    End Sub

    Public Property Name As String Implements INamedObject.Name

    Public Sub Tick() Implements ITickable.Tick
        For Each trigger In Triggers
            If trigger.GetTrigger() Then
                FireAction()
                Exit For
            End If
        Next
    End Sub

    Public Sub ToDisk(path As String) Implements ISerialize.ToDisk
        JsonData.WriteToFile(Of Action)(Me, path)
    End Sub

    Public Function GetIconName() As String Implements IListIcon.GetIconName
        Return "mouse.png"
    End Function

    Public Function GetSubItems() As List(Of IListIcon) Implements IListIcon.GetSubItems
        Return New List(Of IListIcon)
    End Function

    Public Function FromDisk(path As String) As ISerialize Implements ISerialize.FromDisk
        Return JsonData.ReadFromFile(Of Action)(path)
    End Function

    Public Enum ActionType
        DoNothing = 0
        LoadLevel = 1
        PostObjMsg = 2
    End Enum
End Class
