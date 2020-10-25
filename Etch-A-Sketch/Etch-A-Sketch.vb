Public Class Etchy_Sketchy

    Dim pen As New System.Drawing.Pen(Color.Black, 1)
    Dim erasePen As New System.Drawing.Pen(Color.FromName("control"), 10)
    Dim g As Graphics = Me.CreateGraphics
    Dim h As System.Drawing.Graphics
    Dim lastX As Integer
    Dim lastY As Integer


    Sub Draw(x As Integer, y As Integer)
        h = DrawBox.CreateGraphics()
        h.DrawLine(pen, x, y, x - 1, y - 1)


    End Sub

    Sub ColorChooser()
        ColorChoose.ShowDialog()

    End Sub
    Private Sub EdiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EdiToolStripMenuItem.Click

    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub
End Class
