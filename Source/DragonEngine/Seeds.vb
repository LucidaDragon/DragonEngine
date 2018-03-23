Public Class Seeds
    Implements IDataExchange

    Public Shared ActiveSeeds As New List(Of String)
    Public Shared Rand As New Random

    Public Sub FromStorage(storage() As Byte) Implements IDataExchange.FromStorage
        Dim data As String = Text.Encoding.ASCII.GetChars(storage)
        For Each elem In data.Split(Environment.NewLine)
            ActiveSeeds.Add(elem)
        Next
    End Sub

    Public Shared Function GetNew() As String
        Dim result As String = String.Empty
        For i As Integer = 0 To 63
            result += Rand.Next(0, 10)
        Next
        If ActiveSeeds.Contains(result) Then
            Return GetNew()
        Else
            Return result
        End If
    End Function

    Public Function ToStorage() As Byte() Implements IDataExchange.ToStorage
        Dim data As String = String.Empty
        For Each elem In ActiveSeeds
            data += elem & Environment.NewLine
        Next
        data = data.TrimEnd(Environment.NewLine)
        Return Text.Encoding.ASCII.GetBytes(data)
    End Function

    Public Function GetPackageName() As String Implements IDataExchange.GetPackageName
        Return Globals.SeedingPackageName
    End Function
End Class
