'Calvin Coxen
'RCET 0265
'Fall 2020
'Etch-a-Sketch
'https://github.com/CalvinAC/Etch-A-Sketch

Public Class Etchy_Sketchy

    Dim drawPen As New System.Drawing.Pen(Color.Black, 1)
    Dim erasePen As New System.Drawing.Pen(Color.FromName("control"), 50)
    Dim sinePen As New Pen(Color.Black, 6)
    Dim cosinePen As New Pen(Color.Black, 6)
    Dim tangentPen As New Pen(Color.Black, 6)
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
        ColorShoes.ShowDialog()
        drawPen.Color = ColorShoes.Color
        sinePen.Color = ColorShoes.Color
        cosinePen.Color = ColorShoes.Color
        tangentPen.Color = ColorShoes.Color

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

    Private Sub DrawBox_MouseMove(sender As Object, e As MouseEventArgs) Handles DrawBox.MouseUp
        lastX = 0
        lastY = 0
    End Sub


    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub DrawWaveform_Click(sender As Object, e As EventArgs)
        AboutBox.Visible = False
        Dim x As Double
        Dim y As Double

        g = DrawBox.CreateGraphics

        For n As Double = 0 To 1000
            y = Math.Sin(n / 280 * 2 * Math.PI) * 100 + 150
            x = n

            g.DrawLine(sinePen, CType(x, Single), CType(y, Single), CType(x, Single) + 1, CType(y, Single))

        Next

        For n As Double = 0 To 1000
            y = Math.Cos(n / 280 * 2 * Math.PI) * 100 + 150
            x = n

            g.DrawLine(cosinePen, CType(x, Single), CType(y, Single), CType(x, Single) + 1, CType(y, Single))

        Next

        For n As Double = 0 To 1000
            y = Math.Tan(n / 550 * 2 * Math.PI) * 20 + 150
            x = n

            g.DrawLine(tangentPen, CType(x, Single), CType(y, Single), CType(x, Single) + 1, CType(y, Single))

        Next
    End Sub

    Private Sub Clear_Click(sender As Object, e As EventArgs) Handles Clear.Click
        AboutBox.Visible = False
        DrawBox.Image = Nothing
    End Sub

    Private Sub ColorSelect_Click(sender As Object, e As EventArgs) Handles ColorSelect.Click
        AboutBox.Visible = False
        ColorChooser()
    End Sub


    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox.Visible = True
        AboutBox.Items.Add(" Press the button to do the thing")
    End Sub

    Private Sub Etchy_Sketchy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AboutBox.Visible = False
    End Sub
End Class
