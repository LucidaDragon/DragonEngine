Public Class GameObject
    Public Property Name As String
    Public Property SpecialData As New List(Of Data)

    Public Overridable Sub Tick(deltaSeconds As Double)
    End Sub

    Public Class Data
        Public Property Name As String
        Public Property Value As String
    End Class
End Class