Public Class Force
    Public Property Direction As New Point
    Public Property Magnitude As Double
        Get
            If ForceTrigger = ForceTriggerType.Constant Then
                Return Magnitude
            ElseIf ForceTrigger = ForceTriggerType.Keyboard Then
                For Each key In ForceKeys
                    If KeyManager.PressedKeys.Contains(key) Then
                        Return Magnitude
                    End If
                Next
            End If
            Return 0
        End Get
        Set(value As Double)
            scale = value
        End Set
    End Property
    Public Property ForceTrigger As ForceTriggerType = ForceTriggerType.Constant
    Public Property ForceKeys As New List(Of Keys)

    Private scale As Double = 1

    Public Enum ForceTriggerType
        Constant = 0
        Keyboard = 1
    End Enum
End Class
