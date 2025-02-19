﻿Imports Microsoft.VisualBasic.Devices
Public Enum BlockRotation As Integer
    deg0
    deg90
    deg180
    deg270
End Enum
Public Enum BlockColor As Integer
    '0 is Nothing
    Red = 1
    Blue
    Yellow
    Purple
    orange
    green
    light_blue

End Enum

Public Enum BlockType As Integer
    IBlock
    OBlock
    LBlock
    JBlock
    TBlock
    SBlock
    ZBlock
    BruhBlock
    Cascoblock
End Enum
Public Class GameGrid
    Public matrix(21, 10) As Integer
    Public columns = 10
    Public rows = 21
    Public clearedRows As Integer
    Public score As Integer
    Public level As Integer = 1


    Function inBounds(myPoint As Point) As Boolean
        Return (0 <= myPoint.X And myPoint.X < rows) And (0 <= myPoint.Y And myPoint.Y < columns)
    End Function

    Function isEmpty(myPoint As Point) As Boolean
        Return matrix(myPoint.X, myPoint.Y).Equals(0)
    End Function

    Function isValidPos(myPoint As Point) As Boolean
        Return inBounds(myPoint) AndAlso isEmpty(myPoint)
    End Function

    Function isRowEmpty(row As Integer) As Boolean
        For i As Integer = 0 To (columns - 1)
            If Not matrix(row, i).Equals(0) Then
                Return False
            End If
        Next
        Return True
    End Function

    Function isRowFull(row As Integer) As Boolean
        For i As Integer = 0 To (columns - 1)
            If matrix(row, i).Equals(0) Then
                Return False
            End If

        Next
        Return True
    End Function

    Sub emptyRow(row As Integer)
        For i As Integer = 0 To (columns - 1)
            matrix(row, i) = 0
        Next
        Return
    End Sub

    Sub clearRows()
        Dim clearedRows = 0
        Dim curRow = rows - 1
        Dim temp = clearedRows
        While Not isRowEmpty(curRow)
            If isRowFull(curRow) Then
                emptyRow(curRow)
                clearedRows = clearedRows + 1
                score += 100
            Else
                For i As Integer = 0 To (columns - 1)
                    matrix(curRow + clearedRows, i) = matrix(curRow, i)
                Next
            End If
            curRow = curRow - 1
        End While
        For i As Integer = curRow + 1 To (curRow + clearedRows)
            emptyRow(i)
        Next
        Me.clearedRows += clearedRows
        If clearedRows <> temp Then
            checkLevel()
        End If
    End Sub

    Function checkLevel()
        If clearedRows Mod 10 = 0 Then
            level += 1
        End If
        If level > 25 Then
            level = 25
        End If
        Return level
    End Function

End Class

Public Class Block
    'X is for rows, Y is for columns 
    Public Shared Property gen As Random = New Random
    Public spawnPos As New Point(0, 4)
    Public spawnOffset As Point
    Public position As New Point(0, 0)
    Public rotation As BlockRotation
    Public color As BlockColor
    Public tileCount As Integer
    Public tiles(,) As Point
    Public type As BlockType

    Sub New()
        rotation = 0
        'randomizar
        Dim typeArray = {BlockType.IBlock, BlockType.OBlock, BlockType.LBlock, BlockType.JBlock, BlockType.TBlock, BlockType.SBlock, BlockType.ZBlock, BlockType.BruhBlock, BlockType.Cascoblock}
        Me.type = typeArray(gen.Next(0, 9))
        Select Case type
            Case BlockType.IBlock
                tiles = {
                            {New Point(1, 0), New Point(1, 1), New Point(1, 2), New Point(1, 3)},
                            {New Point(0, 2), New Point(1, 2), New Point(2, 2), New Point(3, 2)},
                            {New Point(2, 0), New Point(2, 1), New Point(2, 2), New Point(2, 3)},
                            {New Point(0, 1), New Point(1, 1), New Point(2, 1), New Point(3, 1)}
                           }
                Me.color = 7
                tileCount = 4
                spawnOffset = New Point(0, 1)
            Case BlockType.OBlock
                tiles = {
                            {New Point(0, 0), New Point(0, 1), New Point(1, 0), New Point(1, 1)},
                            {New Point(0, 0), New Point(0, 1), New Point(1, 0), New Point(1, 1)},
                            {New Point(0, 0), New Point(0, 1), New Point(1, 0), New Point(1, 1)},
                            {New Point(0, 0), New Point(0, 1), New Point(1, 0), New Point(1, 1)}
                        }
                Me.color = 3
                tileCount = 4
                spawnOffset = New Point(0, 0)
            Case BlockType.JBlock
                tiles = {
                            {New Point(0, 0), New Point(1, 0), New Point(1, 1), New Point(1, 2)},
                            {New Point(0, 1), New Point(0, 2), New Point(1, 1), New Point(2, 1)},
                            {New Point(1, 0), New Point(1, 1), New Point(1, 2), New Point(2, 2)},
                            {New Point(0, 1), New Point(1, 1), New Point(2, 0), New Point(2, 1)}
                        }
                tileCount = 4
                Me.color = 2
                spawnOffset = New Point(0, 0)
            Case BlockType.LBlock
                tiles = {
                            {New Point(0, 2), New Point(1, 0), New Point(1, 1), New Point(1, 2)},
                            {New Point(0, 1), New Point(1, 1), New Point(2, 1), New Point(2, 2)},
                            {New Point(1, 0), New Point(1, 1), New Point(1, 2), New Point(2, 0)},
                            {New Point(0, 0), New Point(0, 1), New Point(1, 1), New Point(2, 1)}
                        }
                tileCount = 4
                spawnOffset = New Point(0, 0)
                Me.color = 5
            Case BlockType.SBlock
                tiles = {
                            {New Point(0, 1), New Point(0, 2), New Point(1, 0), New Point(1, 1)},
                            {New Point(0, 1), New Point(1, 1), New Point(1, 2), New Point(2, 2)},
                            {New Point(1, 1), New Point(1, 2), New Point(2, 0), New Point(2, 1)},
                            {New Point(0, 0), New Point(1, 0), New Point(1, 1), New Point(2, 1)}
                        }
                tileCount = 4
                Me.color = 6
                spawnOffset = New Point(0, 0)
            Case BlockType.TBlock
                tiles = {
                            {New Point(0, 1), New Point(1, 0), New Point(1, 1), New Point(1, 2)},
                            {New Point(0, 1), New Point(1, 1), New Point(1, 2), New Point(2, 1)},
                            {New Point(1, 0), New Point(1, 1), New Point(1, 2), New Point(2, 1)},
                            {New Point(0, 1), New Point(1, 0), New Point(1, 1), New Point(2, 1)}
                        }
                tileCount = 4
                spawnOffset = New Point(0, 0)
                Me.color = 4
            Case BlockType.ZBlock
                tiles = {
                            {New Point(0, 0), New Point(0, 1), New Point(1, 1), New Point(1, 2)},
                            {New Point(0, 2), New Point(1, 1), New Point(1, 2), New Point(2, 1)},
                            {New Point(1, 0), New Point(1, 1), New Point(2, 1), New Point(2, 2)},
                            {New Point(0, 1), New Point(1, 0), New Point(1, 1), New Point(2, 0)}
                        }
                tileCount = 4
                spawnOffset = New Point(0, 0)
                Me.color = 1
            Case BlockType.BruhBlock
                tiles = {
                            {New Point(0, 0), New Point(1, 0), New Point(2, 1), New Point(2, 2)},
                            {New Point(0, 1), New Point(0, 2), New Point(1, 0), New Point(2, 0)},
                            {New Point(0, 0), New Point(0, 1), New Point(1, 2), New Point(2, 2)},
                            {New Point(0, 2), New Point(1, 2), New Point(2, 0), New Point(2, 1)}
                        }
                tileCount = 4
                Me.color = 6
                spawnOffset = New Point(0, 0)
            Case BlockType.CascoBlock
                tiles = {
                            {New Point(0, 0), New Point(1, 0), New Point(0, 1), New Point(0, 2), New Point(1, 2)},
                            {New Point(0, 0), New Point(0, 1), New Point(1, 1), New Point(2, 1), New Point(2, 0)},
                            {New Point(0, 0), New Point(1, 0), New Point(1, 1), New Point(1, 2), New Point(0, 2)},
                            {New Point(0, 0), New Point(0, 1), New Point(1, 0), New Point(2, 0), New Point(2, 1)}
                        }
                tileCount = 5
                Me.color = 4
                spawnOffset = New Point(0, 0)
        End Select
    End Sub

    Sub New(ByRef source As Block)
        Me.color = source.color
        Me.position = New Point(source.position)
        Me.rotation = source.rotation
        Me.spawnOffset = New Point(source.spawnOffset)
        Me.tileCount = source.tileCount
        Me.spawnPos = New Point(source.spawnPos)
        Me.type = source.type
        'copying reference to read-only data
        Me.tiles = source.tiles
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

    Sub move(ByVal myPoint As Point)
        position.X = position.X + myPoint.X
        position.Y = position.Y + myPoint.Y
    End Sub

End Class


Public Class BlockQueue
    Public queue As New List(Of Block)
    Sub New()
     
            queue.Add(New Block())
            queue.Add(New Block())
            queue.Add(New Block())


    End Sub
    Function nextBlock() As Block
        Dim temp As New Block(queue(0))
        Dim block As New Block()
        queue.RemoveAt(0)
        queue.Add(block)
        temp.position.X = temp.spawnPos.X + temp.spawnOffset.X
        temp.position.Y = temp.spawnPos.Y + temp.spawnOffset.Y
        Return temp
    End Function

End Class

Public Class GameState
    Public random As Random
    Public currentBlock As Block
    Public ghostBlock As Block
    Public grid As GameGrid
    Public queue As BlockQueue
    Public gameOver As Boolean = False
    Public heldBlock As Block
    Public Cambio As Boolean = True

    Sub New()
        queue = New BlockQueue()
        currentBlock = queue.nextBlock()
        grid = New GameGrid()
        updateGhost()
    End Sub

    Function blockFits(block As Block) As Boolean
        Dim listOfTiles = block.getTiles()
        For Each point As Point In listOfTiles
            If Not grid.isValidPos(point) Then
                Return False
            End If
        Next
        Return True
    End Function

    Sub rotateClockwise()
        currentBlock.rotateClockwise()
        If Not blockFits(currentBlock) Then
            currentBlock.rotateCounterClockwise()
        End If
        updateGhost()
    End Sub

    Sub rotateCounterClockwise()
        currentBlock.rotateCounterClockwise()
        If Not blockFits(currentBlock) Then
            currentBlock.rotateClockwise()
        End If
        updateGhost()
    End Sub

    Sub moveLeft()
        currentBlock.move(New Point(0, -1))
        If Not blockFits(currentBlock) Then
            currentBlock.move(New Point(0, 1))
        End If
        updateGhost()
    End Sub

    Sub moveRight()
        currentBlock.move(New Point(0, 1))
        If Not blockFits(currentBlock) Then
            currentBlock.move(New Point(0, -1))
        End If
        updateGhost()
    End Sub

    Sub isGameOver()
        If Not (grid.isRowEmpty(0) And grid.isRowEmpty(1) And grid.isRowEmpty(2)) Then
            gameOver = True
        End If
    End Sub

    Sub placeBlock()
        Dim listOfPos = currentBlock.getTiles()
        For Each point As Point In listOfPos
            grid.matrix(point.X, point.Y) = currentBlock.color
        Next
        isGameOver()
        grid.clearRows()
        currentBlock = queue.nextBlock()
        Cambio = True
        updateGhost()
    End Sub

    Sub moveDown()
        currentBlock.move(New Point(1, 0))
        If Not blockFits(currentBlock) Then
            currentBlock.move(New Point(-1, 0))
            placeBlock()
        End If
    End Sub

    Sub jumpDown()
        For i As Integer = 0 To (grid.rows - 1)
            currentBlock.move(New Point(1, 0))
            If Not blockFits(currentBlock) Then
                currentBlock.move(New Point(-1, 0))
                placeBlock()
                Exit For
            End If
        Next
    End Sub


    Sub updateGhost()
        ghostBlock = New Block(currentBlock)
        For i As Integer = 0 To (grid.rows - 1)
            ghostBlock.move(New Point(1, 0))
            If Not blockFits(ghostBlock) Then
                ghostBlock.move(New Point(-1, 0))
                Exit For
            End If
        Next
    End Sub

    Sub actualizacion()
        If Cambio Then
            Cambio = False


            Static Dim prim = True
            If prim = True Then
                heldBlock = New Block(currentBlock)
                heldBlock.position.X = 0
                heldBlock.position.Y = 0
                currentBlock = queue.nextBlock()

            Else
                Dim guardado
                guardado = New Block(currentBlock)
                currentBlock = heldBlock
                currentBlock.position.X = currentBlock.spawnPos.X + currentBlock.spawnOffset.X
                currentBlock.position.Y = currentBlock.spawnPos.Y + currentBlock.spawnOffset.Y
                heldBlock = guardado
                heldBlock.position.X = 0
                heldBlock.position.Y = 0
            End If
            prim = False
        End If
    End Sub
End Class