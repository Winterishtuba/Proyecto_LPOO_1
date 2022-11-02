Public Class GameGrid
    Private grid(24, 10) As Integer
    Private columns = 10
    Private rows = 20

    Function inBounds(myPoint As Point) As Boolean
        Return (0 <= myPoint.X And myPoint.X <= columns) And (0 <= myPoint.Y And myPoint.Y <= rows)
    End Function

    Function isEmpty(myPoint As Point) As Boolean
        Return grid(myPoint.X, myPoint.Y).Equals(0)
    End Function

    Function isValidPos(myPoint As Point) As Boolean
        Return inBounds(myPoint) And isEmpty(myPoint)
    End Function

    Function isRowEmpty(row As Integer) As Boolean
        'Account for spawning area
        row = row + 4
        For i As Integer = 0 To (columns - 1)
            If Not grid(row, i).Equals(0) Then
                Return False
            End If
        Next
        Return True
    End Function

    Function isRowFull(row As Integer) As Boolean
        row = row + 4
        For i As Integer = 0 To (columns - 1)
            If grid(row, i).Equals(0) Then
                Return False
            End If
        Next
        Return True
    End Function

    Sub emptyRow(row As Integer)
        row = row + 4
        For i As Integer = 0 To (columns - 1)
            grid(row, i) = 0
        Next
        Return
    End Sub

    Sub clearRows()
        Dim clearedRows = 0
        Dim curRow = 0
        While Not isRowEmpty(curRow)
            If isRowFull(curRow) Then
                emptyRow(curRow)
                clearedRows = clearedRows + 1
            Else
                For i As Integer = 0 To (columns - 1)
                    grid(curRow - clearedRows, i) = grid(curRow, i)
                Next
            End If
            curRow = curRow + 1
        End While
    End Sub

    Sub saveBlock()
        'to do
    End Sub


End Class

Public Class Block
    Enum BlockRotation As Integer
        deg0
        deg90
        deg180
        deg270
    End Enum

    Enum BlockColor As Integer
        Red
        Blue
        Yellow
        Purple
    End Enum

    Enum BlockType As Integer
        IBlock
    End Enum

    Protected spawnPos As New Point(0, 4)
    Protected spawnOffset As Point
    Protected position As Point
    Protected rotation As BlockRotation
    Protected color As BlockColor
    Protected tileCount As Integer
    Protected tiles(,) As Point
    Protected type As BlockType

    Sub New(type As BlockType)
        rotation = 0
        'randomize
        color = BlockColor.Red
        Me.type = type
        Select Case type
            Case BlockType.IBlock
                tiles = {
                            {New Point(1, 0), New Point(1, 1), New Point(1, 2), New Point(1, 3)},
                            {New Point(0, 2), New Point(1, 2), New Point(2, 2), New Point(3, 2)},
                            {New Point(2, 0), New Point(2, 1), New Point(2, 2), New Point(2, 3)},
                            {New Point(0, 1), New Point(1, 1), New Point(2, 1), New Point(3, 1)}
                           }
                tileCount = 4
                spawnOffset = New Point(0, -1)
        End Select
        position.X = spawnPos.X + spawnOffset.X
        position.Y = spawnPos.Y + spawnOffset.Y
    End Sub

    Function getTiles() As List(Of Point)
        Dim list As New List(Of Point)
        For i As Integer = 0 To (tileCount - 1)
            list.Add(New Point(position.X + tiles(rotation, i).X, position.Y + tiles(rotation, i).Y))
        Next
        Return list
    End Function

    Sub rotateClockwise()
        rotation = (rotation + 1) Mod 4
    End Sub

    Sub rotateCounterClockwise()
        If rotation = 0 Then
            rotation = 3
            Return
        End If
        rotation = rotation - 1
    End Sub

    Sub move(myPoint As Point)
        position.X = position.X + myPoint.X
        position.Y = position.Y + myPoint.Y
    End Sub

End Class
