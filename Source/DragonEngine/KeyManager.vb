Public Class KeyManager
    Public Shared PressedKeys As New List(Of Keys)

    Public Shared Sub SetKeyState(key As Keys, state As Boolean)
        If state And (Not PressedKeys.Contains(key)) Then
            PressedKeys.Add(key)
        ElseIf (Not state) And PressedKeys.Contains(key) Then
            PressedKeys.Remove(key)
        End If
    End Sub
End Class
