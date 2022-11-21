Imports System.Timers
Public Class Form2
    Private Property Game As New GameState
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim myvar = TableLayoutPanel1.GetControlFromPosition(0, 0)
    End Sub


    Private Sub Dibujo()
        Dim Fichas(7) As String
        Fichas(0) = ""
        Fichas(1) = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "assets\rsq.png")
        Fichas(2) = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "assets\bsq.png")
        Fichas(3) = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "assets\ysq.png")
        Fichas(4) = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "assets\psq.png")
        Fichas(5) = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "assets\osq.png")
        Fichas(6) = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "assets\gsq.png")
        Fichas(7) = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "assets\lbsq.png")

        Label4.Text = Game.level
        Label5.Text = Game.grid.clearedRows
        Label6.Text = Game.grid.score
        For i As Integer = 0 To (Game.grid.rows - 1)
            For j As Integer = 0 To (Game.grid.columns - 1)
                Dim color = Game.grid.matrix(i, j)
                If color = 0 Then
                    TryCast(TableLayoutPanel1.GetControlFromPosition(j, i), PictureBox).Image = Nothing
                    Continue For
                End If
                TryCast(TableLayoutPanel1.GetControlFromPosition(j, i), PictureBox).Image = Image.FromFile(Fichas(color))
            Next
        Next
        Dim blockTiles As List(Of Point) = Game.currentBlock.getTiles()
        Dim curBlockPath = System.IO.Path.Combine(My.Application.Info.DirectoryPath, Fichas(Game.currentBlock.color))
        For Each tile In blockTiles
            TryCast(TableLayoutPanel1.GetControlFromPosition(tile.Y, tile.X), PictureBox).Image = Image.FromFile(curBlockPath)
        Next

        'Lista de bloques
        Game.queue.queue(0).position.X = 0
        Game.queue.queue(0).position.Y = 0
        Game.queue.queue(1).position.X = 0
        Game.queue.queue(1).position.Y = 0
        Game.queue.queue(2).position.X = 0
        Game.queue.queue(2).position.Y = 0

        Dim ListaSig = Game.queue.queue(0).getTiles()
        For Each imagen As PictureBox In TableLayoutPanel2.Controls
            imagen.Image = Nothing
        Next
        For Each cordenada In ListaSig
            TryCast(TableLayoutPanel2.GetControlFromPosition(cordenada.Y, cordenada.X), PictureBox).Image = Image.FromFile(Fichas(Game.queue.queue(0).color))
        Next
        ListaSig = Game.queue.queue(1).getTiles()
        For Each imagen As PictureBox In TableLayoutPanel3.Controls
            imagen.Image = Nothing
        Next

        For Each cordenada In ListaSig
            TryCast(TableLayoutPanel3.GetControlFromPosition(cordenada.Y, cordenada.X), PictureBox).Image = Image.FromFile(Fichas(Game.queue.queue(1).color))
        Next
        ListaSig = Game.queue.queue(2).getTiles()
        For Each imagen As PictureBox In TableLayoutPanel5.Controls
            imagen.Image = Nothing
        Next
        For Each cordenada In ListaSig
            TryCast(TableLayoutPanel5.GetControlFromPosition(cordenada.Y, cordenada.X), PictureBox).Image = Image.FromFile(Fichas(Game.queue.queue(2).color))
        Next

        Dim Bloquefantasma = Game.ghostBlock.getTiles()
        Dim Fantasma(7) As String
        Fantasma(0) = ""
        Fantasma(1) = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "assets\rsqghost.png")
        Fantasma(2) = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "assets\bsqghost.png")
        Fantasma(3) = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "assets\ysqghost.png")
        Fantasma(4) = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "assets\psqghost.png")
        Fantasma(5) = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "assets\osqghost.png")
        Fantasma(6) = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "assets\gsqghost.png")
        Fantasma(7) = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "assets\lbsqghost.png")
        For Each imagen In Bloquefantasma

            TryCast(TableLayoutPanel1.GetControlFromPosition(imagen.Y, imagen.X), PictureBox).Image = Image.FromFile(Fantasma(Game.ghostBlock.color))
        Next
    End Sub
    Private Sub Dibujarguardado()
        Dim Fichas(7) As String
        Fichas(0) = ""
        Fichas(1) = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "assets\rsq.png")
        Fichas(2) = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "assets\bsq.png")
        Fichas(3) = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "assets\ysq.png")
        Fichas(4) = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "assets\psq.png")
        Fichas(5) = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "assets\osq.png")
        Fichas(6) = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "assets\gsq.png")
        Fichas(7) = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "assets\lbsq.png")



        For Each imagen As PictureBox In TableLayoutPanel7.Controls
            imagen.Image = Nothing
        Next
        Dim bloquecordenadas = Game.heldBlock.getTiles()
        For Each cordenada In bloquecordenadas
            TryCast(TableLayoutPanel7.GetControlFromPosition(cordenada.Y, cordenada.X), PictureBox).Image = Image.FromFile(Fichas(Game.heldBlock.color))
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
                Game.grid.score += 1
            Case Keys.Up
                Game.rotateClockwise()
            Case Keys.M
                Game.rotateClockwise()
            Case Keys.Space
                Game.jumpDown()
                Game.grid.score += 30
            Case Keys.C
                Game.actualizacion()
                Dibujarguardado()
        End Select
        Dibujo()
    End Sub

    Private Sub TableLayoutPanel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub TableLayoutPanel3_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TableLayoutPanel3.Paint

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Game.level > 25 Then
            Game.level = 25
        End If
        Timer1.Interval = (1000 - Game.level * 40 + 40)
        Timer1.Enabled = True
        Game.moveDown()
        Dibujo()
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub TableLayoutPanel7_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel7.Paint

    End Sub
End Class