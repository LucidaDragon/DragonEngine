Public Class Messaging
    Private Shared Messages As New List(Of Message)
    Private Shared Hooks As New List(Of Hook)

    Public Shared Function AddHook(message As String, method As System.Action, consumeMessage As Boolean) As Integer
        Dim hook As New Hook(message, method, consumeMessage)
        Hooks.Add(hook)
        Return hook.GetHashCode()
    End Function

    Public Shared Function RemoveHook(ID As Integer) As Boolean
        For i As Integer = 0 To Hooks.Count - 1
            If ID = Hooks.Item(i).GetHashCode() Then
                Hooks.RemoveAt(i)
                Return True
            End If
        Next
        Return False
    End Function

    Public Shared Sub Post(message As String)
        Messages.Add(New Message(message))
        Flush()
    End Sub

    Public Shared Sub Flush()
        For Each hook In Hooks
            For i As Integer = 0 To Messages.Count - 1
                If hook.Message = Messages.Item(i).Data And Not Messages.Item(i).Fetchers.Contains(hook) Then
                    If hook.Consume Then
                        Messages.RemoveAt(i)
                        hook.Action.Invoke()
                        Exit For
                    Else
                        Messages.Item(i).Fetchers.Add(hook)
                        hook.Action.Invoke()
                        Exit For
                    End If
                End If
            Next
        Next
    End Sub

    Private Class Message
        Public Property Data As String
        Public Property Fetchers As New List(Of Hook)

        Sub New(msg As String)
            Data = msg
        End Sub
    End Class

    Private Class Hook
        Public Property Message As String
        Public Property Action As System.Action
        Public Property Consume As Boolean

        Sub New(msg As String, actn As System.Action, chomp As Boolean)
            Message = msg
            Action = actn
            Consume = chomp
        End Sub
    End Class
End Class
