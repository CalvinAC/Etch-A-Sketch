Public Class Etchy_Sketchy

    Dim drawPen As New System.Drawing.Pen(Color.Black, 1)
    Dim erasePen As New System.Drawing.Pen(Color.FromName("control"), 50)
    Dim g As Graphics = Me.CreateGraphics
    Dim lastX As Integer
    Dim lastY As Integer


    Sub Draw(x As Integer, y As Integer)
        g = DrawBox.CreateGraphics
        If lastX = Nothing Then
            g.DrawLine(drawPen, x, y, x, y)

        Else
            g.DrawLine(drawPen, x, y, lastX, lastY)

        End If
        lastX = x
        lastY = y

    End Sub

    Sub ColorChooser()
        ' ColorChoose.ShowDialog()
        'pen.Color=ColorChoose.Color
    End Sub

    Sub Eraser(x As Integer, y As Integer)
        g = DrawBox.CreateGraphics()
        g.DrawLine(erasePen, x, y, x - 1, y - 1)
    End Sub
    Private Sub DrawBox_MouseHoldMove(sender As Object, e As MouseEventArgs) Handles DrawBox.MouseDown, DrawBox.MouseMove

        If e.Button.ToString = "Left" Then
            Draw(e.X, e.Y)
        ElseIf e.Button.ToString = "Right" Then
            Eraser(e.X, e.Y)
        ElseIf e.Button.ToString = "Middle" Then
            ColorChooser()
        End If
    End Sub


    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub DrawWaveform_Click(sender As Object, e As EventArgs)
        Dim x As Double
        Dim y As Double
        Dim graphPen As New Pen(Color.Black, 6)

        g = DrawBox.CreateGraphics

        For r As Double = 0 To 900
            y = Math.Sin(r / 280 * 2 * Math.PI) * 100 + 100
            x = r

            g.DrawLine(graphPen, CType(x, Single), CType(y, Single), CType(x, Single) + 1, CType(y, Single))

        Next
    End Sub

    Private Sub Clear_Click(sender As Object, e As EventArgs) Handles Clear.Click
        DrawBox.Image = Nothing
    End Sub
End Class
