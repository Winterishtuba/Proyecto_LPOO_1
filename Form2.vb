Public Class Form2
    Private Property Game As New GameState

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Game.grid.grid(4, 2) = 1
        Dim myvar = TableLayoutPanel1.GetControlFromPosition(0, 0)
        If myvar Is Nothing Then
            MsgBox("hola")
        End If
        Dibujo()
    End Sub

    Private Sub TableLayoutPanel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub PictureBox79_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click

    End Sub

    Private Sub Dibujo()
        Dim Fichas(7) As String
        Fichas(0) = ""
        Fichas(1) = "assets\rsq.png"
        Fichas(2) = "assets\bsq.png"
        Fichas(3) = "assets\ysq.png"
        Fichas(4) = "assets\psq.png"
        Fichas(5) = "assets\lbsq.png"
        Fichas(6) = "assets\osq.png"
        Fichas(7) = "assets\gsq.png"


        For i As Integer = 0 To (Game.grid.rows - 1)
            For j As Integer = 0 To (Game.grid.columns - 1)
                Dim color = Game.grid.grid(i, j)
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
                Dibujo()
            Case Keys.Left
                Game.moveLeft()
                Dibujo()
            Case Keys.Down
                Game.moveDown()
                Dibujo()
        End Select
    End Sub

    Private Sub TableLayoutPanel3_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel3.Paint

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class