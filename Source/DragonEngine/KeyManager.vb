Public Class KeyManager
    Public Shared ReadOnly Property PressedKeys As List(Of Keys)
        Get
            Return ActiveKeys
        End Get
    End Property

    Private Shared ActiveKeys As New List(Of Keys)
    Private Shared KeyHooks As New List(Of KeyHook)

    Public Shared Sub SetKeyState(key As Keys, state As Boolean)
        If state Then
            If Not ActiveKeys.Contains(key) Then
                ActiveKeys.Add(key)
            End If
        Else
            While ActiveKeys.Remove(key)
            End While
        End If
    End Sub

    Public Shared Sub AddKeyDownHook(key As Keys, task As Action)
        KeyHooks.Add(New KeyHook(key, True, task))
    End Sub

    Public Shared Sub AddKeyUpHook(key As Keys, task As Action)
        KeyHooks.Add(New KeyHook(key, False, task))
    End Sub

    Private Class KeyHook
        Public Property Key As Keys
        Public Property OnDown As Boolean
        Public Property Task As Action

        Sub New(key As Keys, onDown As Boolean, task As Action)
            Me.Key = key
            Me.OnDown = onDown
            Me.Task = task
        End Sub

        Public Shared Operator =(ByVal a As KeyHook, ByVal b As Keys) As Boolean
            Return a.Key = b
        End Operator

        Public Shared Operator <>(ByVal a As KeyHook, ByVal b As Keys) As Boolean
            Return a.Key <> b
        End Operator
    End Class
End Class
