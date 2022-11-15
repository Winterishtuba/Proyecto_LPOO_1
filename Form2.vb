Imports System.Timers
Public Class Form2
    Private Property Game As New GameState
    Private Sub TimerEvent(ByVal source As Object, ByVal e As ElapsedEventArgs)
        Game.moveDown()
        Dibujo()


    End Sub
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim myvar = TableLayoutPanel1.GetControlFromPosition(0, 0)
        Dim timer As Timer = New Timer()
        timer.Interval = 1000
        AddHandler timer.Elapsed, AddressOf TimerEvent
        timer.AutoReset = True
        timer.Enabled = True
        Dibujo()
    End Sub

    Private Sub TableLayoutPanel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub PictureBox79_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Dibujo()
        Dim Fichas(7) As String
        Fichas(0) = ""
        Fichas(1) = "assets\rsq.png"
        Fichas(2) = "assets\bsq.png"
        Fichas(3) = "assets\ysq.png"
        Fichas(4) = "assets\psq.png"
        Fichas(5) = "assets\osq.png"
        Fichas(6) = "assets\gsq.png"
        Fichas(7) = "assets\lbsq.png"


        For i As Integer = 0 To (Game.grid.rows - 1)
            For j As Integer = 0 To (Game.grid.columns - 1)
                Dim color = Game.grid.matrix(i, j)
                If color = 0 Then
                    TryCast(TableLayoutPanel1.GetControlFromPosition(j, i), PictureBox).Image = Nothing
                    Continue For
                End If
                Dim path As String = System.IO.Path.Combine(My.Application.Info.DirectoryPath, Fichas(color))
                TryCast(TableLayoutPanel1.GetControlFromPosition(j, i), PictureBox).Image = Image.FromFile(path)
            Next
        Next

        Dim blockTiles As List(Of Point) = Game.currentBlock.getTiles()
        Dim curBlockPath = System.IO.Path.Combine(My.Application.Info.DirectoryPath, Fichas(Game.currentBlock.color))
        For Each tile In blockTiles
            TryCast(TableLayoutPanel1.GetControlFromPosition(tile.Y, tile.X), PictureBox).Image = Image.FromFile(curBlockPath)
        Next

    End Sub
    Private Sub Form2_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyData
            Case Keys.Right
                Game.moveRight()
            Case Keys.Left
                Game.moveLeft()
            Case Keys.Down
                Game.moveDown()
            Case Keys.Up
                Game.rotateClockwise()
            Case Keys.M
                Game.rotateClockwise()
            Case Keys.Space
                Game.jumpDown()
        End Select
        Dibujo()
    End Sub

End Class