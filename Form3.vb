Public Class Form3
    Public Property List As New List(Of KeyValuePair(Of String, Integer))
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub



    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub recorrer(nombre As String, score As Integer)

        List.Add(New KeyValuePair(Of String, Integer)(nombre, score))

        Dim asd = Function(x As KeyValuePair(Of String, Integer), y As KeyValuePair(Of String, Integer))
                      If x.Value = y.Value Then Return 0
                      If x.Value > y.Value Then Return -1
                      If x.Value < y.Value Then Return 1
                  End Function
        List.Sort(asd)

    End Sub
    Function addscore()
        Dim line As String
        Dim filewriter As System.IO.StreamWriter
        filewriter = My.Computer.FileSystem.OpenTextFileWriter(System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Highscores.txt"), False)
        For Each keyvalue As KeyValuePair(Of String, Integer) In List
            line = keyvalue.Key & ":"
            line = line & keyvalue.Value
            filewriter.WriteLine(line)
        Next
        filewriter.Close()
    End Function

    Function getscore()

        Dim stringarray(2) As String
        Dim num As Integer
        Dim Reader As System.IO.StreamReader
        Dim stringreader As String
        Reader = My.Computer.FileSystem.OpenTextFileReader(System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Highscores.txt"))
        While Not Reader.EndOfStream
            stringreader = Reader.ReadLine()
            stringarray = stringreader.Split(":")
            num = CInt(stringarray(1))
            List.Add(New KeyValuePair(Of String, Integer)(stringarray(0), num))
        End While
        Reader.Close()
    End Function
End Class