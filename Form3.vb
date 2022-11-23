Public Class Form3
    Public Property myList As New List(Of KeyValuePair(Of String, Integer))
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub



    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadscore()
    End Sub

    Public Sub recorrer(nombre As String, score As Integer)

        myList.Add(New KeyValuePair(Of String, Integer)(nombre, score))

        Dim asd = Function(x As KeyValuePair(Of String, Integer), y As KeyValuePair(Of String, Integer))
                      If x.Value = y.Value Then Return 0
                      If x.Value > y.Value Then Return -1
                      If x.Value < y.Value Then Return 1
                  End Function
        myList.Sort(asd)

    End Sub
    Function addscore()
        Dim line As String
        Dim filewriter As System.IO.StreamWriter
        filewriter = My.Computer.FileSystem.OpenTextFileWriter(System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Highscores.txt"), False)
        For Each keyvalue As KeyValuePair(Of String, Integer) In myList
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
            myList.Add(New KeyValuePair(Of String, Integer)(stringarray(0), num))
        End While
        Reader.Close()
    End Function

    Function loadscore()
        Label1.Text = myList.Item(0).ToString
        Label2.Text = myList.Item(1).ToString
        Label3.Text = myList.Item(2).ToString
        Label4.Text = myList.Item(3).ToString
        Label5.Text = myList.Item(4).ToString
    End Function
End Class