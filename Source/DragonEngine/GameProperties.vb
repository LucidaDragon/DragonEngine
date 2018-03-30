Public Class GameProperties
    Implements ISerialize
    Implements IListIcon

    ''' <summary>
    ''' The single instance of the GameProperties class, so that PropertyGrid and JsonSerializer can reference an object.
    ''' </summary>
    Public Shared Instance As GameProperties

    Public Property GameIcon As Icon
    Public Property GameName As String
    Public Property GameVersion As String = "1.0.0"
    Public Property GameAuthor As String = Environment.UserName

    ''' <summary>
    ''' Constructs a new GameProperties instance and overwrites the previous one.
    ''' </summary>
    Sub New()
        If Instance Is Nothing Then
            Instance = Me
        End If
    End Sub

    <ComponentModel.Browsable(False)>
    Public Property Name As String Implements IListIcon.Name
        Get
            Return "Settings"
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
        Return "gear.png"
    End Function
End Class
