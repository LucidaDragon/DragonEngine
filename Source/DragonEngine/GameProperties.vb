Public Class GameProperties
    Implements ISerialize
    Implements IListIcon

    ''' <summary>
    ''' The single instance of the GameProperties class, so that PropertyGrid and JsonSerializer can reference an object.
    ''' </summary>
    Public Shared Instance As GameProperties

    ''' <summary>
    ''' Constructs a new GameProperties instance and overwrites the previous one.
    ''' </summary>
    Sub New()
        If Instance Is Nothing Then
            Instance = Me
        End If
    End Sub

    Public Property Name As String Implements IListIcon.Name
        Get
            Return "Game Properties"
        End Get
        Set(value As String)
        End Set
    End Property

    ''' <summary>
    ''' Initialize a new GameProperty instance.
    ''' </summary>
    Public Shared Sub Init()
        Instance = New GameProperties()
    End Sub

    Public Sub ToDisk(path As String) Implements ISerialize.ToDisk
        JsonData.WriteToFile(Of GameProperties)(Me, path)
    End Sub

    Public Function FromDisk(path As String) As ISerialize Implements ISerialize.FromDisk
        Instance = JsonData.ReadFromFile(Of GameProperties)(path)
        Return Instance
    End Function

    Public Function GetIconName() As String Implements IListIcon.GetIconName
        Return "property"
    End Function
End Class
