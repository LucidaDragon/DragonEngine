Imports DragonEngine

Public Class Level
    Implements IListable
    Implements IRender
    Implements IDataExchange

    Public Property BackgroundImage As Bitmap
    Public Property StaticElements As New List(Of Element)
    Public Property LevelName As String = "Untitled Level"

    Public Sub FromStorage(storage() As Byte) Implements IDataExchange.FromStorage

    End Sub

    Public Function GetIcon() As String Implements IListable.GetIcon
        Return "exit.png"
    End Function

    Public Function GetText() As String Implements IListable.GetText
        Return LevelName
    End Function

    Public Function GetArea(cameraLocation As Point) As Rectangle Implements IRender.GetArea
        Return New Rectangle(New Point(0, 0), BackgroundImage.Size)
    End Function

    Public Function GetImage() As Bitmap Implements IRender.GetImage
        Return BackgroundImage
    End Function

    Public Function GetZAxis() As Integer Implements IRender.GetZAxis
        Return Integer.MinValue
    End Function

    Public Function ToStorage() As Byte() Implements IDataExchange.ToStorage
        Dim buffer As Byte()
        Dim memStream As New IO.MemoryStream
        BackgroundImage.Save(memStream, BackgroundImage.RawFormat)
        buffer = memStream.ToArray()

        Dim elems As String = String.Empty
        For Each elem In StaticElements
            elems += elem.GetPackageName() & Chr(1)
        Next
        elems = elems.Remove(elems.Length - 1, 1) & Chr(2)

        Return Text.Encoding.ASCII.GetBytes(LevelName & Chr(2) & elems & Text.Encoding.ASCII.GetChars(buffer))
    End Function

    Public Function GetPackageName() As String Implements IDataExchange.GetPackageName
        Return LevelName & Globals.LevelPackageSuffix
    End Function

    Public Class Element
        Implements IPhysics
        Implements IRender
        Implements IDataExchange

        Public Property Position As Point
        Public Property Image As Bitmap
        Public Property RenderZ As Integer
        Public Property CollisionLayers As New List(Of Integer)
        Public MyPackageSeed As String = Seeds.GetNew()

        Public Sub Tick(deltaSeconds As Double) Implements ITickable.Tick
        End Sub

        Public Sub FromStorage(storage() As Byte) Implements IDataExchange.FromStorage
            Dim data As String = Text.Encoding.ASCII.GetChars(storage)
            Seeds.ActiveSeeds.Remove(MyPackageSeed)

            Dim pos As Integer = 0
            Dim parts As String() = data.Split(Chr(2))
            MyPackageSeed = parts(0)
            RenderZ = Integer.Parse(parts(1))
            Position = New Point(Integer.Parse(parts(2)), Integer.Parse(parts(3)))
            pos += parts(0).Length + 1 + parts(1).Length + 1 + parts(2).Length + 1 + parts(3).Length + 1 + parts(4).Length

            For Each elem In parts(4).Split(Chr(1))
                CollisionLayers.Add(Integer.Parse(elem))
            Next

            'todo: trim based on pos
        End Sub

        Public Function GetCollisionLayers() As List(Of Integer) Implements IPhysics.GetCollisionLayers
            Return CollisionLayers
        End Function

        Public Function GetBounds() As Rectangle Implements IPhysics.GetBounds
            Return New Rectangle(Position, Image.Size)
        End Function

        Public Function GetArea(cameraLocation As Point) As Rectangle Implements IRender.GetArea
            Return New Rectangle(cameraLocation - Position, Image.Size)
        End Function

        Public Function GetImage() As Bitmap Implements IRender.GetImage
            Return Image
        End Function

        Public Function GetZAxis() As Integer Implements IRender.GetZAxis
            Return RenderZ
        End Function

        Public Function ToStorage() As Byte() Implements IDataExchange.ToStorage
            Dim data As String = MyPackageSeed & Chr(2) & RenderZ & Chr(2) & Position.X & Chr(2) & Position.Y & Chr(2)

            Dim buffer As Byte()
            Dim memStream As New IO.MemoryStream
            Image.Save(memStream, Image.RawFormat)
            buffer = memStream.ToArray()

            Dim elems As String = String.Empty
            For Each elem In CollisionLayers
                elems += elem & Chr(1)
            Next
            If elems.Length > 0 Then
                elems = elems.Remove(elems.Length - 1, 1) & Chr(2)
            Else
                elems = Chr(2)
            End If

            Return Text.Encoding.ASCII.GetBytes(data & elems & Text.Encoding.ASCII.GetChars(buffer))
        End Function

        Public Function GetPackageName() As String Implements IDataExchange.GetPackageName
            Return MyPackageSeed & ".LevelElement"
        End Function
    End Class
End Class
