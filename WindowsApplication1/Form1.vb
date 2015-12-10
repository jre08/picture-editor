Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Drawing.Printing
Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Public Class Form1
    Private startCorner As Point
    Private rubberBand As Rectangle
    Private rubberBandColor As Color = Color.Red
    Private rubberBanding As Boolean = False
    Public importeddir As Boolean = False
    Public importedpdf As Boolean = False
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
    Dim img As Drawing.Image
    Public filename As String



    Public Sub OpenFile_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFile.FileOk

        '##  Open image file(tiff,jpg,bmp)
        'Dim original As Image = Image.FromFile(OpenFile.FileName)
        'resized = ResizeImage(original, New Size(PictureBox1.Width, PictureBox1.Height))
        'Dim memStream As MemoryStream = New MemoryStream()
        'resized.Save(memStream, ImageFormat.Tiff)
        'PictureBox1.Image = resized
        fs = File.Open(OpenFile.FileName, FileMode.Open, FileAccess.ReadWrite)
        srcBmp = CType(Bitmap.FromStream(fs), Bitmap)
        totalPages = CInt(srcBmp.GetFrameCount(FrameDimension.Page) - 1)

        For i = 0 To totalPages
            srcBmp.SelectActiveFrame(FrameDimension.Page, i)
            resized = New Bitmap(srcBmp, srcBmp.Width, srcBmp.Height)
            ListView1.Items.Add(Str(i), "Page" & Str(i + 1), i)
            ImageList1.Images.Add(i, resized)

        Next
        ListView1.LargeImageList = ImageList1
        srcBmp.SelectActiveFrame(FrameDimension.Page, 0)
        PictureBox1.Image = ResizeImage(srcBmp, New Size(PictureBox1.Width, PictureBox1.Height))

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

    Private Sub Save_Click(sender As Object, e As EventArgs) Handles RibbonButton5.Click
        'Saves the picturebox image in a temp folder

        Dim objNewBmp As New Bitmap(PictureBox1.Image)
        Dim g As Graphics

        g = Graphics.FromImage(objNewBmp)
        'Creats a duplicate image file as bitmap format 

        'Creates an rectagnle on the picture box for visual.
        g = PictureBox1.CreateGraphics

        objNewBmp.Save("c:\temp\s" & ".tif", Imaging.ImageFormat.Tiff)
    End Sub

    Private Sub Openfile_click(sender As Object, e As EventArgs) Handles RibbonButton1.Click
        OpenFile.ShowDialog()
    End Sub

    Private Sub importDIR_Click(sender As Object, e As EventArgs) Handles RibbonButton2.Click

        If (ImportDirDialog.ShowDialog() = DialogResult.OK) Then

            ImportDir()

        End If

    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If importeddir = False And importedpdf = False Then
            For Each item As ListViewItem In ListView1.SelectedItems()
                srcBmp.SelectActiveFrame(FrameDimension.Page, item.ImageIndex)
                'PictureBox1.Image = ResizeImage(srcBmp, New Size(PictureBox1.Width, PictureBox1.Height))
                PictureBox1.Width = picsizew(srcBmp)
                PictureBox1.Height = picsizeh(srcBmp)
                PictureBox1.Image = srcBmp

            Next

        ElseIf importedpdf = True Then



        Else




            For Each item As ListViewItem In ListView1.SelectedItems()
                Dim folder As String = dirPath.Text
                filename = System.IO.Path.Combine(folder, item.Text)
                fs = File.Open(filename, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite)
                srcBmp = CType(Bitmap.FromStream(fs), Bitmap)
                resized = New Bitmap(srcBmp, srcBmp.Width, srcBmp.Height)



            Next

            'PictureBox1.Image = ResizeImage(srcBmp, New Size(PictureBox1.Width, PictureBox1.Height))
            If Rbn_ck_Editmode.Checked = True Then
                PictureBox1.Width = picsizew(srcBmp)
                PictureBox1.Height = picsizeh(srcBmp)
            End If

            PictureBox1.Image = srcBmp

        End If
        Me.Refresh()


    End Sub

    Private Sub PictureBox1_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        If e.Button = MouseButtons.Left And Rbn_ck_Editmode.Checked = True Then
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
        If e.Button = MouseButtons.Left And Rbn_ck_Editmode.Checked = True Then

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
    Dim pages As Integer

    Private Sub btnPDFopen_Click(sender As Object, e As EventArgs) Handles RibbonButton4.Click

        If (PdfOpen.ShowDialog() = DialogResult.OK) Then
            Dim doc As New PdfDocument()
            doc.LoadFromFile(PdfOpen.FileName)
            If doc.Pages.Count > 3 Then
                pages = 2
            Else
                pages = doc.Pages.Count - 1
            End If
            For i = 0 To pages

                'dirPath.Text = doc.Pages.Count
                Dim bmp As Image = doc.SaveAsImage(i)
                Dim emf As Image = doc.SaveAsImage(i, Spire.Pdf.Graphics.PdfImageType.Metafile)
                Dim zoomImg As Image = New Bitmap(CInt(emf.Size.Width * 2), CInt(emf.Size.Height * 2))
                Using g As Graphics = Graphics.FromImage(zoomImg)
                    g.ScaleTransform(2.0F, 2.0F)
                    g.DrawImage(emf, New Rectangle(New Point(0, 0), emf.Size), New Rectangle(New Point(0, 0), emf.Size), GraphicsUnit.Pixel)
                End Using
                'bmp.Save(i & "convertToBmp.bmp", ImageFormat.Bmp)
                'System.Diagnostics.Process.Start(i & "convertToBmp.bmp")
                'emf.Save(i & "convertToEmf.png", ImageFormat.Png)
                'System.Diagnostics.Process.Start("convertToEmf.png")
                zoomImg.Save(i & "convertToZoom.png", ImageFormat.Png)
                'System.Diagnostics.Process.Start(i & "convertToZoom.png")
                ListView1.Items.Add(Str(i), "Page " & i + 1, i)
                resized = New Bitmap(zoomImg, zoomImg.Width, zoomImg.Height)
                ImageList1.Images.Add(i, bmp)
                'PictureBox1.Image = ResizeImage(zoomImg, New Size(PictureBox1.Width, PictureBox1.Height))
                PictureBox1.Width = picsizew(zoomImg)
                PictureBox1.Height = picsizeh(zoomImg)

                PictureBox1.Image = resized
            Next
        End If
        importedpdf = True
        ListView1.LargeImageList = ImageList1
    End Sub

    Sub saveimagetopdf()
        ' Create a pdf document with a section and page added.
        Dim doc As New PdfDocument()
        Dim section As PdfSection = doc.Sections.Add()
        Dim page As PdfPageBase = doc.Pages.Add()

        'Load a tif image from system
        Dim image As PdfImage = PdfImage.FromFile("D:\images\bear.tif")
        'Set image display location and size in PDF
        Dim widthFitRate As Single = image.PhysicalDimension.Width / page.Canvas.ClientSize.Width
        Dim heightFitRate As Single = image.PhysicalDimension.Height / page.Canvas.ClientSize.Height
        Dim fitRate As Single = Math.Max(widthFitRate, heightFitRate)
        Dim fitWidth As Single = image.PhysicalDimension.Width / fitRate
        Dim fitHeight As Single = image.PhysicalDimension.Height / fitRate
        page.Canvas.DrawImage(image, 30, 30, fitWidth, fitHeight)
        'save and launch the file
        doc.SaveToFile("image to pdf.pdf")
        doc.Close()
        System.Diagnostics.Process.Start("image to pdf.pdf")

    End Sub

    Sub ImportDir()
        Dim di As DirectoryInfo = New DirectoryInfo(ImportDirDialog.SelectedPath)
        Dim i As Integer = 0
        ListView1.LargeImageList = ImageList1
        For Each fi In di.EnumerateFiles("*.jpg")

            fs = File.Open(fi.FullName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite)
            srcBmp = CType(Bitmap.FromStream(fs), Bitmap)
            resized = New Bitmap(srcBmp, srcBmp.Width, srcBmp.Height)
            ListView1.Items.Add(Str(i), fi.Name, i)
            ImageList1.Images.Add(i, resized)
            i += 1
        Next
        dirPath.Text = ImportDirDialog.SelectedPath
        importeddir = True
    End Sub


    Function picsizew(pic As Image)
        Dim picw As String
        picw = pic.Width
        Return picw
    End Function

    Function picsizeh(pic As Image)
        Dim pich As String
        pich = pic.Height
        Return pich
    End Function

    Private Sub RibbonOrbOptionButton2_Click(sender As Object, e As EventArgs) Handles RibbonOrbOptionButton2.Click
        Me.Close()
    End Sub

    Private Sub PrintPreview_Click(sender As Object, e As EventArgs) Handles RibbonButton3.Click

        Printview.Document = prntDoc
        Printview.ShowDialog()

    End Sub

    Friend WithEvents prntDoc As New PrintDocument()

    Private Sub prntDoc_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles prntDoc.PrintPage
        Dim emf As Image = Me.PictureBox1.Image
        Dim zoomImg As Image = New Bitmap(CInt(emf.Size.Width * 2), CInt(emf.Size.Height * 2))
        Using g As Graphics = Graphics.FromImage(zoomImg)
            g.ScaleTransform(2.0F, 2.0F)
            g.DrawImage(emf, New Rectangle(New Point(0, 0), emf.Size), New Rectangle(New Point(0, 0), emf.Size), GraphicsUnit.Pixel)
        End Using
        e.Graphics.DrawImage(zoomImg, 0, 0)
    End Sub





End Class
