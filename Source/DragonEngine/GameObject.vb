Public Class GameObject
    Public Property Name As String
        Get
            Return ObjectName
        End Get
        Set(value As String)
            ObjectName = value
            If MyNode IsNot Nothing And Not Sync Then
                Sync = True
                MyNode.Text = value
                Sync = False
            End If
        End Set
    End Property
    Private ObjectName As String
    Private Sync As Boolean = False

    Public Property SpecialData As New List(Of Data)

    Public MyNode As SpecialTreeNode

    Public Overridable Sub Tick(deltaSeconds As Double)
    End Sub

    Sub New(name As String)
        Me.Name = name
    End Sub

    Public Class Data
        Public Property Name As String
        Public Property Value As String
    End Class
End Class