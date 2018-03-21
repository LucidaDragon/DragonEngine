Public Class SpecialTreeNode
    Inherits TreeNode

    Sub New(name As String)
        MyBase.New(name)
    End Sub

    Public Shadows Property Text As String
        Get
            Return MyBase.Text
        End Get
        Set(value As String)
            MyBase.Text = value
            If TryCast(Tag, GameObject) IsNot Nothing And Not Sync Then
                Sync = True
                TryCast(Tag, GameObject).Name = value
                Sync = False
            End If
        End Set
    End Property
    Private Sync As Boolean = False

    Public Shadows Property Tag As GameObject
        Get
            Return MyBase.Tag
        End Get
        Set(value As GameObject)
            MyBase.Tag = value
            value.MyNode = Me
        End Set
    End Property
End Class
