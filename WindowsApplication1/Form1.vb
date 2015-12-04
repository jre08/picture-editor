Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports Spire.Pdf

Public Class Form1
    Private startCorner As Point
    Private rubberBand As Rectangle
    Private rubberBandColor As Color = Color.Red
    Private rubberBanding As Boolean = False

    Dim finishX, finishY As Integer
    Dim startX, startY As Integer
    Dim up, down As Point
    Dim strFilePath As String
    Dim strPath As String
    Dim strFileName As String
    Dim g As Graphics
    Dim pn As Pen
    Dim totalPages As Integer
    Dim currentPage As Integer = 0
    Dim fs As FileStream
    Dim srcBmp As Bitmap
    Dim resized As Image



    Public Sub OpenFile_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFile.FileOk

        '##  Open image file(tiff,jpg,bmp)
        'Dim original As Image = Image.FromFile(OpenFile.FileName)
        'resized = ResizeImage(original, New Size(PictureBox1.Width, PictureBox1.Height))
        'Dim memStream As MemoryStream = New MemoryStream()
        'resized.Save(memStream, ImageFormat.Tiff)
        'PictureBox1.Image = resized



        fs = File.Open(OpenFile.FileName, FileMode.Open, FileAccess.Read)
        srcBmp = CType(Bitmap.FromStream(fs), Bitmap)
        totalPages = CInt(srcBmp.GetFrameCount(FrameDimension.Page) - 1)
        'srcBmp.SelectActiveFrame(FrameDimension.Page, currentPage)
        'MsgBox(srcBmp.GetFrameCount(FrameDimension.Page))

        For i = 0 To totalPages
            srcBmp.SelectActiveFrame(FrameDimension.Page, i)
            'srcBmp.totalWidth = Math.Max(totalWidth, (iFile.Width * 0.4))
            'imageStructure.totalHeight += (iFile.Height * 0.4)
            resized = New Bitmap(srcBmp, srcBmp.Width * 0.4, srcBmp.Height * 0.4)
            ListView1.Items.Add(Str(i), Str(i), i)
            ImageList1.Images.Add(i, resized)

        Next
        ListView1.LargeImageList = ImageList1
        PictureBox1.Image = ImageList1.Images.Item(0)

        'resized = ResizeImage(srcBmp, New Size(PictureBox1.Width, PictureBox1.Height))
        'PictureBox1.Image = resized


        '##Open pdf
        'LOADPDF(OpenFile.FileName)
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        thumbnail()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        PictureBox1.Image = ImageList1.Images.Item(1)

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

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        For Each item As ListViewItem In ListView1.SelectedItems()
            'MsgBox(item.Text)
            PictureBox1.Image = ImageList1.Images.Item(item.ImageIndex)
        Next
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
            g.Dispose()
            objNewBmp.Save("c:\temp\s" & ".tif", Imaging.ImageFormat.Tiff)
            PictureBox1.Image = objNewBmp
            'cboFrameEdit.Items.Add(curF)
            g.Dispose()
            'objNewBmp.Dispose()

            rubberBanding = False
        End If
    End Sub

    Private Sub PictureBox1_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles PictureBox1.Paint
        Using pn As New Pen(rubberBandColor) With {.DashStyle = Drawing2D.DashStyle.Dash}
            e.Graphics.DrawRectangle(pn, rubberBand)
        End Using
    End Sub



    Sub thumbnail()
        'Select Case isDelete
        'Case True
        'Dim objImage As System.Drawing.Image = objImage.FromFile(strFilePath)
        'Case False
        'Dim objImage As System.Drawing.Image = objImage.FromFile(strPath & curF & ".tif")
        'End Select
        'Dim objImage As Image
        Dim totFrame As Integer
        Dim objImage As Image
        ' MsgBox(PictureBox1.ImageLocation)
        objImage = PictureBox1.Image
        Dim objGuid As Guid = (objImage.FrameDimensionsList(0))
        Dim objDimension As System.Drawing.Imaging.FrameDimension = New System.Drawing.Imaging.FrameDimension(objGuid)
        'objImage.SelectActiveFrame(objDimension, curF)
        'picImage.Image = objImage
        'picImage.SizeMode = PictureBoxSizeMode.Zoom


        '#REGION#
        'Changed the cursor to waitCursor
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        'Sets the tiff file as an image object.


        'Gets the total number of frames in the .tiff file
        totFrame = objImage.GetFrameCount(objDimension)
        totalPages = CInt(objImage.GetFrameCount(FrameDimension.Page))
        MsgBox(totalPages)
        objImage.SelectActiveFrame(FrameDimension.Page, 1)

        PictureBox1.Refresh()



        'Adds number of frames to the combo box for displaying purposes.
        'Dim i As Integer
        'For i = 0 To totFrame - 1
        'cboFrameNo.Items.Add(i)
        'Next
        'cboFrameNo.Items.IndexOf(1)

        'Sets the temporary folder to "C:\temp\"
        'strPath = "c:\temp\"

        'Saves every frame as a seperate file.
        'Dim z As Integer
        'z = 0
        'curF = 0
        'For z = 0 To (totFrame - 1)
        'objImage.SelectActiveFrame(objDimension, curF)
        'objImage.Save(strPath & curF & ".tif", Imaging.ImageFormat.Tiff)
        'curF = curF + 1
        'Next

        'curF = 0

        'Displayes the frames
        'DisplayFrame()
        Me.Cursor = System.Windows.Forms.Cursors.Default

    End Sub
End Class
