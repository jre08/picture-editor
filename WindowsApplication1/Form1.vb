Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO

Public Class Form1
    Private startCorner As Point
    Private rubberBand As Rectangle
    Private rubberBandColor As Color = Color.Yellow
    Private rubberBanding As Boolean = False

    Dim finishX, finishY As Integer
    Dim startX, startY As Integer
    Dim up, down As Point
    Dim strFilePath As String
    Dim strPath As String
    Dim strFileName As String
    Dim g As Graphics
    Dim pn As Pen

    Private Sub OpenFile_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFile.FileOk
        ' Dim pic As Image = New Bitmap(OpenFile.FileName)
        'Dim original As Image = Image.FromFile("C:\temp\0.tif")
        Dim original As Image = Image.FromFile(OpenFile.FileName)

        Dim resized As Image = ResizeImage(original, New Size(PictureBox1.Width, PictureBox1.Height))
        Dim memStream As MemoryStream = New MemoryStream()
        resized.Save(memStream, ImageFormat.Tiff)



        PictureBox1.Image = resized
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As MouseEventArgs) Handles PictureBox1.DoubleClick
        If e.Button = MouseButtons.Right Then
            OpenFile.ShowDialog()
        End If
    End Sub

    Public Shared Function ResizeImage(ByVal image As Image,
  ByVal size As Size, Optional ByVal preserveAspectRatio As Boolean = True) As Image
        Dim newWidth As Integer
        Dim newHeight As Integer
        If preserveAspectRatio Then
            Dim originalWidth As Integer = image.Width
            Dim originalHeight As Integer = image.Height
            Dim percentWidth As Single = CSng(size.Width) / CSng(originalWidth)
            Dim percentHeight As Single = CSng(size.Height) / CSng(originalHeight)
            Dim percent As Single = If(percentHeight < percentWidth,
                    percentHeight, percentWidth)
            newWidth = CInt(originalWidth * percent)
            newHeight = CInt(originalHeight * percent)
        Else
            newWidth = size.Width
            newHeight = size.Height
        End If
        Dim newImage As Image = New Bitmap(newWidth, newHeight)
        Using graphicsHandle As Graphics = Graphics.FromImage(newImage)
            graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic
            graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight)
        End Using
        Return newImage
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim objNewBmp As New Bitmap(PictureBox1.Image)

        Dim g As Graphics
        g = Graphics.FromImage(objNewBmp)
        'Creats a duplicate image file as bitmap format 


        'Creates an rectagnle on the picture box for visual.
        g = PictureBox1.CreateGraphics

        objNewBmp.Save("c:\temp\s" & ".tif", Imaging.ImageFormat.Tiff)


    End Sub


    Private Sub PictureBox1_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        If e.Button = MouseButtons.Left Then
            rubberBanding = True
            startCorner = e.Location
            rubberBand = Rectangle.Empty
            down = New Point(startCorner.X, startCorner.Y)
            PictureBox1.Invalidate()
        End If
    End Sub

    Private Sub PictureBox1_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        If rubberBanding Then
            rubberBand.Width = Math.Abs(e.X - startCorner.X)
            rubberBand.Height = Math.Abs(e.Y - startCorner.Y)
            rubberBand.X = Math.Min(e.X, startCorner.X)
            rubberBand.Y = Math.Min(e.Y, startCorner.Y)
            PictureBox1.Invalidate()
        End If
    End Sub

    Private Sub PictureBox1_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        If e.Button = MouseButtons.Left Then

            Dim img As Drawing.Image
            'sets the current page as image.
            img = New Bitmap(PictureBox1.Image)

            Dim objBmp As New Bitmap(img, img.Width, img.Height)
            Dim objNewBmp As New Bitmap(objBmp.Width, objBmp.Height, Imaging.PixelFormat.Format16bppRgb555)

            Dim g As Graphics
            g = Graphics.FromImage(objNewBmp)
            'Creats a duplicate image file as bitmap format 
            Dim rect As Rectangle
            With rect
                .Width = img.Width
                .Height = img.Height
                .X = 0
                .Y = 0
            End With

            g.DrawImage(img, rect)

            Dim DrawRect As Rectangle
            'Sets the position of the mouse
            finishX = e.X
            finishY = e.Y

            up = New Point(finishX, finishY)
            'Sets the value of rectangle, x, y, width, height position
            DrawRect = New Rectangle(Math.Min(up.X, down.X), Math.Min(up.Y, down.Y), Math.Abs(up.X - down.X), Math.Abs(up.Y - down.Y))

            Dim b As SolidBrush = New SolidBrush(Color.White)
            g.FillRectangle(b, DrawRect)

            'Creates an rectagnle on the picture box for visual.
            g = PictureBox1.CreateGraphics
            g.FillRectangle(b, DrawRect)
            objNewBmp.Save("c:\temp\s" & ".tif", Imaging.ImageFormat.Tiff)
            PictureBox1.Image = objNewBmp
            'cboFrameEdit.Items.Add(curF)
            'g.Dispose()
            'objNewBmp.Dispose()
            rubberBanding = False
        End If
    End Sub

    Private Sub PictureBox1_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles PictureBox1.Paint
        Using pn As New Pen(rubberBandColor) With {.DashStyle = Drawing2D.DashStyle.Dash}
            e.Graphics.DrawRectangle(pn, rubberBand)
        End Using
    End Sub
End Class
