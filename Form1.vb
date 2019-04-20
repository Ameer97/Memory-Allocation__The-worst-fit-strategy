Public Class Form1

    Dim loc = "300,600,350,200,750,128"
    Dim pro = "115,500,355,200,375"

    Dim locations() As String
    Dim Proccress() As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        locations = Split(loc, ",")
        Proccress = Split(pro, ",")
        MessageBox.Show("locations" & vbLf & Join(locations, vbLf) & vbLf & vbLf & "proccess" & vbLf & Join(Proccress, vbLf))

        'For i = 0 To theLength - 1
        '    locations(i) = InputBox("fill the location " & i + 1 & " from " & theLength)
        'Next


        'For i = 0 To theLengthProccess - 1
        '    Proccress(i) = InputBox("fill the proccess " & i + 1 & " from " & theLength)
        'Next

        first()
    End Sub

    Function first()

        Dim counter = 0
        Dim locationsInteger = WorstSort(toInteger(locations))
        Dim ProccressInteger = toInteger(Proccress)

        For i = 0 To Proccress.Length - 1
this:
            Try
                If locationsInteger(counter) >= ProccressInteger(i) Then
                    locationsInteger(counter) -= ProccressInteger(i)
                    Proccress(i) = 0
                    counter = 0

                    locationsInteger = WorstSort(locationsInteger)
                    locations = toTheString(locationsInteger)
                    MessageBox.Show("locations" & vbLf & Join(locations, vbLf) & vbLf & vbLf & "proccess" & vbLf & Join(Proccress, vbLf))

                Else
                    counter += 1
                    GoTo this
                End If
            Catch ex As Exception
                MessageBox.Show("This way is not correct for this input")
            End Try
        Next

        Return 0
    End Function

    Function WorstSort(randomNumbers() As Integer)
        Array.Sort(randomNumbers)
        Dim keys(randomNumbers.Length - 1) As Integer
        For i = 0 To randomNumbers.Length - 1
            keys(i) = randomNumbers.Length - 1 - i
        Next
        Array.Sort(keys, randomNumbers)
        Return randomNumbers
    End Function

    Function toInteger(StringArray() As String)
        Return Array.ConvertAll(StringArray, Function(str) Integer.Parse(str))
    End Function

    Function toTheString(IntegerArray() As Integer)
        Return Array.ConvertAll(IntegerArray, Function(x) x.ToString)
    End Function
End Class
