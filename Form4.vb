Public Class Form4
    Public Property List As New List(Of KeyValuePair(Of String, Integer))
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getscore()
        insertscoretofile()
    End Sub

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
            list.Add(New KeyValuePair(Of String, Integer)(stringarray(0), num))
        End While
    End Function

    Function insertscoretofile()
        Dim line As String
        Dim filewriter As System.IO.StreamWriter
        filewriter = My.Computer.FileSystem.OpenTextFileWriter(System.IO.Path.Combine(My.Application.Info.DirectoryPath, "test.txt"), False)
        For Each keyvalue As KeyValuePair(Of String, Integer) In List
            line = keyvalue.Key & ":"
            line = line & keyvalue.Value
            filewriter.WriteLine(line)
        Next
        filewriter.Close()
    End Function
End Class
