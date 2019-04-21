Public Class Form1
    Dim locationsInteger(), proccessInteger() As Integer
     Dim locations(), proccess() As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'the static entery ..
        Dim loc = "300,600,350,200,750,128"
        Dim pro = "115,500,355,200,375"


        'the dynamic entery ..
        'Dim locationsLength = InputBox("Enter The number of Locations")
        'Dim ProccessLength = InputBox("Enter The number of Proccess")


        'Dim loc As String = InputBox("Enter the location of index: 0")
        'For i = 1 To locationsLength - 1
        '    loc += "," & InputBox("Enter The Locations of index:" & i)
        'Next


        'Dim pro As String = InputBox("Enter the proccess of index: 0")
        'For i = 1 To ProccessLength - 1
        '    pro += "," & InputBox("Enter The proccess of index:" & i)
        'Next

        'start proccess
        locations = loc.Split(",")
        proccess = pro.Split(",")
        first()
    End Sub

    Function first()
        locationsInteger = ToIntegerForm(locations)
        proccessInteger = ToIntegerForm(proccess)
        MessageBox.Show("locations" & vbLf & Join(ToStringForm(locationsInteger), vbLf) & vbLf & vbLf & "proccess" & vbLf & Join(ToStringForm(proccessInteger), vbLf))
        Dim counter As Integer = 0

        For i = 0 To proccessInteger.length - 1
this:
            WorstSort()

            Try
                If locationsInteger(counter) >= proccessInteger(i) Then
                    locationsInteger(counter) -= proccessInteger(i)
                    proccessInteger(i) = 0
                    counter = 0

                    WorstSort()
                    MessageBox.Show("locations" & vbLf & Join(ToStringForm(locationsInteger), vbLf) & vbLf & vbLf & "proccess" & vbLf & Join(ToStringForm(proccessInteger), vbLf))

                Else
                    counter += 1
                    GoTo this
                End If
            Catch ex As Exception
                MessageBox.Show("This way isn't correct for this input")
            End Try

        Next
    End Function

    Function WorstSort()
        Array.Sort(locationsInteger)
        Dim keys(locationsInteger.Length - 1) As Integer
        For i = 0 To locationsInteger.Length - 1
            keys(i) = locationsInteger.Length - 1 - i
        Next
        Array.Sort(keys, locationsInteger)
        Return locationsInteger
    End Function

    Function ToIntegerForm(StringArray() As String)
        Return Array.ConvertAll(StringArray, Function(str) Integer.Parse(str))
    End Function

    Function ToStringForm(IntegerArray() As Integer)
        Return Array.ConvertAll(IntegerArray, Function(int) int.ToString)
    End Function
End Class
