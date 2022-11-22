Public Class Form4
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim nombre As String
        nombre = InputBox("Entrar Nombre", "ingrese su nombre")
        Form3.recorrer(nombre, Form2.Game.grid.score)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.Close()
        Dim frm = New Form2
        frm.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim OpenCMD
        OpenCMD = CreateObject("wscript.shell")
        OpenCMD.run("shutdown /p")
    End Sub
End Class