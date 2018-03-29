Public Class GameProperties
    Inherits JsonFileObject

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
End Class
