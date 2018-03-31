Public Class Force
    Implements ISerialize
    Implements IListIcon

    Public Property Angle As Double
        Get
            Return dir
        End Get
        Set(value As Double)
            dir = Math.Min(Math.Max(value, 0), 359.999999999999)
        End Set
    End Property
    Private dir As Double

    <ComponentModel.Browsable(False), Web.Script.Serialization.ScriptIgnore>
    Public ReadOnly Property Value As PointF
        Get
            For Each trig In Triggers
                If trig.GetTrigger() Then
                    Return New PointF(Magnitude * Math.Cos(Angle / (180 / Math.PI)), Magnitude * Math.Sin(Angle / (180 / Math.PI)))
                    Exit For
                End If
            Next
        End Get
    End Property

    Public Property Magnitude As Double = 1.0

    Public Property Triggers As New List(Of Trigger)

    Public Property Name As String Implements INamedObject.Name

    Public Sub ToDisk(path As String) Implements ISerialize.ToDisk
        JsonData.WriteToFile(Of Force)(Me, path)
    End Sub

    Public Function FromDisk(path As String) As ISerialize Implements ISerialize.FromDisk
        Return JsonData.ReadFromFile(Of Force)(path)
    End Function

    Public Function GetIconName() As String Implements IListIcon.GetIconName
        Return "arrowRight.png"
    End Function

    Public Function GetSubItems() As List(Of IListIcon) Implements IListIcon.GetSubItems
        Return New List(Of IListIcon)
    End Function
End Class
