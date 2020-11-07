'Calvin Coxen
'RCET 0265
'Fall 2020
'Etch-a-Sketch
'https://github.com/CalvinAC/Etch-A-Sketch

Option Strict On
Option Explicit On

Public Class Etchy_Sketchy

    Dim drawPen As New System.Drawing.Pen(Color.Black, 1)
    Dim erasePen As New System.Drawing.Pen(Color.FromName("control"), 50)
    Dim sinePen As New Pen(Color.Black, 10)
    Dim cosinePen As New Pen(Color.Black, 10) '- Probably only need one pen here - TJR
    Dim tangentPen As New Pen(Color.Black, 10)
    Dim g As Graphics ' = Me.CreateGraphics   -- Associating the graphics object with the Form here may cause problems - TJR
    Dim lastX As Integer
    Dim lastY As Integer

    ' Creates a pen that the user can use to freehand drawings
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

    'Creates a color dialog box for the user to select the color of the pen
    Sub ColorChooser()
        ColorShoes.ShowDialog()
        drawPen.Color = ColorShoes.Color
        sinePen.Color = ColorShoes.Color
        cosinePen.Color = ColorShoes.Color
        tangentPen.Color = ColorShoes.Color
    End Sub

    ' Creates an eraser for the user to erase with
    Sub Eraser(x As Integer, y As Integer)
        g = DrawBox.CreateGraphics()
        g.DrawLine(erasePen, x, y, x - 1, y - 1)
    End Sub

    ' Draws a sine, cosine, and tangent wave using the math to plot the points & a pen to draw them
    Sub WaveformDrawings()
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

    ' Allows the user to draw using the left mouse click, select color with the mouse wheel, and erase with the right mouse click
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

    Private Sub DrawWaveformToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DrawWaveformToolStripMenuItem.Click, DrawWaveFormsButton.Click
        WaveformDrawings()
    End Sub

    Private Sub ColorSelect_Click(sender As Object, e As EventArgs) Handles ColorSelect.Click, SelectColorToolStripMenuItem.Click '- handles any event to choose color
        ColorChooser()
    End Sub

    Private Sub Etchy_Sketchy_Load(sender As Object, e As EventArgs) Handles MyBase.Load, AboutToolStripMenuItem.MouseLeave
        AboutBox.Visible = False
    End Sub

    ' Displays tool tips to the user when hovered over
    Private Sub AboutToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.MouseHover
        AboutBox.Visible = True
        AboutBox.Items.Add(" The color button will dsiplay a color palette to choose what color the pen will draw with ")
        AboutBox.Items.Add(" The Draw Waveform button draws a Sine, Cosine, and Tangent wave across the screen")
        AboutBox.Items.Add(" Pressing the clear button will erase all the wonderful artwork that has been created WITHOUT SAVING")
        AboutBox.Items.Add(" Exit button leaves the program")
        AboutBox.Items.Add(" Click down on the left mouse and hold to draw line, release to end line")
        AboutBox.Items.Add(" Click the mouse wheel to open the color menu")
        AboutBox.Items.Add(" Click down on the right right mouse and hold to erase, release to end erasing")
    End Sub

    ' Shakes the picture box when the user clears the drawings
    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click, Clear.Click

        For i = 1 To 100
            DrawBox.Left = DrawBox.Left + 10
            DrawBox.Top = DrawBox.Top + 10
            DrawBox.Left = DrawBox.Left - 20
            DrawBox.Top = DrawBox.Top - 20
            DrawBox.Left = DrawBox.Left + 20
            DrawBox.Top = DrawBox.Top + 20
            DrawBox.Left = DrawBox.Left - 10
            DrawBox.Top = DrawBox.Top - 10
        Next

        DrawBox.Image = Nothing
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click, ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

End Class
