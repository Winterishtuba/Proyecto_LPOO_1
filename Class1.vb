Public Class GameGrid
    Private grid(10, 23) As Integer
    Private columns = 10
    Private rows = 20

    Function inBounds(myPoint As Point) As Boolean
        Return (myPoint.X <= columns) And (myPoint.Y <= rows)
    End Function

    Function isEmpty(myPoint As Point) As Boolean
        Return grid(myPoint.X, myPoint.Y).Equals(0)
    End Function

    Function isValidPos(myPoint As Point) As Boolean
        Return inBounds(myPoint) And isEmpty(myPoint)
    End Function

End Class
