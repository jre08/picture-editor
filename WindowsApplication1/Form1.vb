Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Drawing.Printing
'Imports Spire.Pdf
'Imports Spire.Pdf.Graphics
Imports System.Web
Imports PdfSharp
Imports PdfSharp.Drawing
Imports PdfSharp.Pdf

Public Class Form1

#Region "Variables"

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
    Dim img As Image
    Dim tempdi As DirectoryInfo
    'Dim img As Drawing.Image
    Public filename As String
    Friend WithEvents prntDoc As New PrintDocument()

#End Region



#Region "Ribbon Menu Buttons"

    Private Sub Openfile_click(sender As Object, e As EventArgs) Handles RibbonButton1.Click
        OpenFile.ShowDialog()
    End Sub

    Public Sub OpenFile_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFile.FileOk

        'fs = File.Open(OpenFile.FileName, FileMode.Open, FileAccess.ReadWrite)
        'srcBmp = CType(Bitmap.FromStream(fs), Bitmap)
        'totalPages = CInt(srcBmp.GetFrameCount(FrameDimension.Page) - 1)

        'For i = 0 To totalPages
        '    srcBmp.SelectActiveFrame(FrameDimension.Page, i)
        '    resized = New Bitmap(srcBmp, srcBmp.Width, srcBmp.Height)
        '    ListView1.Items.Add(Str(i), "Page" & Str(i + 1), i)
        '    ImageList1.Images.Add(i, resized)

        'Next
        'ListView1.LargeImageList = ImageList1
        'ListView1.Items.Item(0).Selected = True
        'srcBmp.SelectActiveFrame(FrameDimension.Page, 0)
        'PictureBox1.Image = ResizeImage(srcBmp, New Size(PictureBox1.Width, PictureBox1.Height))


        addimage(OpenFile.FileName)


        'ListView1.Items.Item(0).Selected = True
        ' srcBmp.SelectActiveFrame(FrameDimension.Page, 0)
        ' PictureBox1.Image = ResizeImage(srcBmp, New Size(PictureBox1.Width, PictureBox1.Height))

    End Sub

    Private Sub importDIR_Click(sender As Object, e As EventArgs) Handles RibbonButton2.Click

        If (ImportDirDialog.ShowDialog() = DialogResult.OK) Then

            ImportDir()

        End If

    End Sub

    Private Sub Save_Click(sender As Object, e As EventArgs) Handles RibbonButton5.Click
        ''Saves the picturebox image in a temp folder

        'Dim objNewBmp As New Bitmap(PictureBox1.Image)
        'Dim g As Graphics

        'g = Graphics.FromImage(objNewBmp)
        ''Creats a duplicate image file as bitmap format 

        ''Creates an rectagnle on the picture box for visual.
        'g = PictureBox1.CreateGraphics

        'objNewBmp.Save("c:\temp\s" & ".tif", Imaging.ImageFormat.Tiff)
        tiff2PDF("temp.tiff")
    End Sub

    Private Sub btnPDFopen_Click(sender As Object, e As EventArgs) Handles RibbonButton4.Click

        If (PdfOpen.ShowDialog() = DialogResult.OK) Then
            tiff2PDF(PdfOpen.FileName)
        End If
        '    Dim doc As New PdfDocument()
        '    doc.LoadFromFile(PdfOpen.FileName)
        '    If doc.Pages.Count > 3 Then
        '        totalPages = 2
        '    Else
        '        totalPages = doc.Pages.Count - 1
        '    End If
        '    For i = 0 To totalPages

        '        'dirPath.Text = doc.Pages.Count
        '        Dim bmp As Image = doc.SaveAsImage(i)
        '        Dim emf As Image = doc.SaveAsImage(i, Spire.Pdf.Graphics.PdfImageType.Metafile)
        '        Dim zoomImg As Image = New Bitmap(CInt(emf.Size.Width * 2), CInt(emf.Size.Height * 2))
        '        Using g As Graphics = Graphics.FromImage(zoomImg)
        '            g.ScaleTransform(2.0F, 2.0F)
        '            g.DrawImage(emf, New Rectangle(New Point(0, 0), emf.Size), New Rectangle(New Point(0, 0), emf.Size), GraphicsUnit.Pixel)
        '        End Using
        '        'bmp.Save(i & "convertToBmp.bmp", ImageFormat.Bmp)
        '        'System.Diagnostics.Process.Start(i & "convertToBmp.bmp")
        '        'emf.Save(i & "convertToEmf.png", ImageFormat.Png)
        '        'System.Diagnostics.Process.Start("convertToEmf.png")
        '        zoomImg.Save(i & "convertToZoom.png", ImageFormat.Png)
        '        'System.Diagnostics.Process.Start(i & "convertToZoom.png")
        '        ListView1.Items.Add(Str(i), "Page " & i + 1, i)
        '        resized = New Bitmap(zoomImg, zoomImg.Width, zoomImg.Height)
        '        ImageList1.Images.Add(i, bmp)
        '        'PictureBox1.Image = ResizeImage(zoomImg, New Size(PictureBox1.Width, PictureBox1.Height))
        '        PictureBox1.Width = picsizew(zoomImg)
        '        PictureBox1.Height = picsizeh(zoomImg)

        '        PictureBox1.Image = resized
        '    Next
        'End If
        'importedpdf = True
        'ListView1.LargeImageList = ImageList1
    End Sub

    Private Sub RibbonOrbOptionButton2_Click(sender As Object, e As EventArgs) Handles RibbonOrbOptionButton2.Click
        Me.Close()
    End Sub

    Private Sub PrintPreview_Click(sender As Object, e As EventArgs) Handles RibbonButton3.Click

        Printview.Document = prntDoc
        Printview.ShowDialog()

    End Sub

    'Private Sub Editmode_change() Handles Rbn_ck_Editmode.CheckBoxCheckChanged
    '    If Rbn_ck_Editmode.Checked = True Then
    '        If importedpdf = False Then
    '            For Each item As ListViewItem In ListView1.SelectedItems()
    '                srcBmp.SelectActiveFrame(FrameDimension.Page, item.ImageIndex)
    '                'PictureBox1.Image = ResizeImage(srcBmp, New Size(PictureBox1.Width, PictureBox1.Height))
    '                PictureBox1.Width = srcBmp.Width
    '                PictureBox1.Height = srcBmp.Height
    '                PictureBox1.Image = srcBmp

    '            Next


    '            'Else




    '            '    For Each item As ListViewItem In ListView1.SelectedItems()
    '            '        Dim folder As String = dirPath.Text
    '            '        filename = System.IO.Path.Combine(folder, item.Text)
    '            '        fs = File.Open(filename, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite)
    '            '        srcBmp = CType(Bitmap.FromStream(fs), Bitmap)
    '            '        resized = New Bitmap(srcBmp, srcBmp.Width, srcBmp.Height)



    '            '    Next

    '        End If
    '    ElseIf Rbn_ck_Editmode.Checked = False Then
    '        PictureBox1.Width = 667
    '        PictureBox1.Height = 771


    '    End If
    'End Sub

    Private Sub CloseImage() Handles rbn_btn_closeimg.Click
        ImageList1.Images.Clear()
        ListView1.Items.Clear()
        PictureBox1.Image = New Bitmap(Image.FromFile("back.jpg"))
        srcBmp.Dispose()
        fs.Dispose()
        My.Computer.FileSystem.DeleteFile("temp.tiff")
    End Sub
#End Region

    Private Sub prntDoc_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles prntDoc.PrintPage
        Dim emf As Image = Me.PictureBox1.Image
        Dim zoomImg As Image = New Bitmap(CInt(emf.Size.Width * 2), CInt(emf.Size.Height * 2))
        Using g As Graphics = Graphics.FromImage(zoomImg)
            g.ScaleTransform(1.7F, 1.7F)
            g.DrawImage(emf, New Rectangle(New Point(0, 0), emf.Size), New Rectangle(New Point(0, 0), emf.Size), GraphicsUnit.Pixel)
        End Using
        e.Graphics.DrawImage(zoomImg, 0, 0)
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If importedpdf = False Then
            For Each item As ListViewItem In ListView1.SelectedItems()
                'srcBmp.SelectActiveFrame(FrameDimension.Page, item.ImageIndex)
                ''PictureBox1.Image = ResizeImage(srcBmp, New Size(PictureBox1.Width, PictureBox1.Height))
                'PictureBox1.Width = srcBmp.Width
                'PictureBox1.Height = srcBmp.Height
                PictureBox1.Image = CType(Bitmap.FromFile(Application.StartupPath & "\temp\temp" & item.ImageIndex & ".tif"), Bitmap)

            Next


        Else




            For Each item As ListViewItem In ListView1.SelectedItems()
                srcBmp.SelectActiveFrame(FrameDimension.Page, item.ImageIndex)
                'PictureBox1.Image = ResizeImage(srcBmp, New Size(PictureBox1.Width, PictureBox1.Height))
                PictureBox1.Width = srcBmp.Width
                PictureBox1.Height = srcBmp.Height
                PictureBox1.Image = srcBmp
                'Dim folder As String = dirPath.Text
                'filename = System.IO.Path.Combine(folder, item.Text)
                'fs = File.Open(filename, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite)
                'srcBmp = CType(Bitmap.FromStream(fs), Bitmap)
                'resized = New Bitmap(srcBmp, srcBmp.Width, srcBmp.Height)



            Next

            'PictureBox1.Image = ResizeImage(srcBmp, New Size(PictureBox1.Width, PictureBox1.Height))
            If Rbn_ck_Editmode.Checked = True Then
                PictureBox1.Width = picsizew(srcBmp)
                PictureBox1.Height = picsizeh(srcBmp)
            End If

            'PictureBox1.Image = srcBmp

        End If
        Me.Refresh()


    End Sub



#Region "Paint Rectangle On Mouse move"

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

            Dim img As System.Drawing.Image
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
            'objNewBmp.Save("c:\temp\s" & ".tif", Imaging.ImageFormat.Tiff)
            PictureBox1.Image = objNewBmp
            'cboFrameEdit.Items.Add(curF)
            g.Dispose()
            'objNewBmp.Dispose()

            rubberBanding = False

            'savemouse()

        End If
        'pn.Dispose()
    End Sub

    Private Sub PictureBox1_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles PictureBox1.Paint
        Using pn As New Pen(rubberBandColor) With {.DashStyle = Drawing2D.DashStyle.Dash}
            e.Graphics.DrawRectangle(pn, rubberBand)
        End Using

    End Sub

    Dim pic As Image
    Sub savemouse()
        ''Saves the picturebox image in a temp folder

        'Dim objNewBmp As New Bitmap(PictureBox1.Image)
        'Dim g As Graphics

        'g = Graphics.FromImage(objNewBmp)
        ''Creats a duplicate image file as bitmap format 

        ''Creates an rectagnle on the picture box for visual.
        ' g = PictureBox1.CreateGraphics

        'objNewBmp.Save("c:\temp\s" & ".tif", Imaging.ImageFormat.Tiff)

        'resized = New Bitmap(objNewBmp, objNewBmp.Width, objNewBmp.Height)

        'ListView1.Items.Add(Str(i), "Page" & Str(i + 1), i)
        Dim num As Integer
        For Each item As ListViewItem In ListView1.SelectedItems()
            num = item.ImageIndex
            'ImageList2.Images.Add(Str(num), resized)
            'ListView2.Items.Add(Str(num), "num", Str(num))
            'PictureBox1.Image = ResizeImage(srcBmp, New Size(PictureBox1.Width, PictureBox1.Height))
            ' PictureBox1.Width = srcBmp.Width
            'PictureBox1.Height = srcBmp.Height
            'PictureBox1.Image = srcBmp
            Debug.Print(num)
            'Next
        Next
        Debug.Print(num)

        For i = 0 To ImageList1.Images.Count - 1
            pic = ImageList1.Images(i)
            If i = num Then
                Debug.Print("equal")
                pic = PictureBox1.Image
            End If
            Dim filenm = "temp" & i & ".tiff"
            SaveAddTiff(pic, filenm)
        Next
    End Sub
#End Region




    Sub ImportDir()

        Dim di As DirectoryInfo = New DirectoryInfo(ImportDirDialog.SelectedPath)


        For Each fi In di.GetFiles
            If fi.Extension = ".png" Then
                Dim filename As String = "temp.tiff"
                fs = File.Open(fi.FullName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite)
                srcBmp = CType(Bitmap.FromStream(fs), Bitmap)
                resized = New Bitmap(srcBmp, srcBmp.Width, srcBmp.Height)
                SaveAddTiff(resized, filename)
                'addimage(fi.FullName)
            End If

            If fi.Extension = ".tiff" Then
                Dim filename As String = "temp.tiff"
                fs = File.Open(fi.FullName, FileMode.Open, FileAccess.ReadWrite)
                srcBmp = CType(Bitmap.FromStream(fs), Bitmap)
                totalPages = CInt(srcBmp.GetFrameCount(FrameDimension.Page) - 1)

                For i = 0 To totalPages
                    srcBmp.SelectActiveFrame(FrameDimension.Page, i)
                    resized = New Bitmap(srcBmp, srcBmp.Width, srcBmp.Height)
                    SaveAddTiff(resized, filename)
                    '    ListView1.Items.Add(Str(i), "Page" & Str(i + 1), i)
                    '    ImageList1.Images.Add(i, resized)

                Next
            End If
        Next



        'Add tiff frames to image list for list view //  select frame from listview
        fs = File.Open("temp.tiff", FileMode.Open, FileAccess.ReadWrite)
        srcBmp = CType(Bitmap.FromStream(fs), Bitmap)
        totalPages = CInt(srcBmp.GetFrameCount(FrameDimension.Page) - 1)

        For i = 0 To totalPages
            srcBmp.SelectActiveFrame(FrameDimension.Page, i)
            resized = New Bitmap(srcBmp, srcBmp.Width, srcBmp.Height)
            ListView1.Items.Add(Str(i), "Page" & Str(i + 1), i)
            ImageList1.Images.Add(i, resized)

        Next

        ListView1.Items.Item(0).Selected = True
        srcBmp.SelectActiveFrame(FrameDimension.Page, 0)
        PictureBox1.Image = ResizeImage(srcBmp, New Size(PictureBox1.Width, PictureBox1.Height))

        dirPath.Text = ImportDirDialog.SelectedPath
        importeddir = True
    End Sub


#Region "Functions"


    Sub addimage(imagename As String)
        'Dim filename As String = "temp.tiff"
        'fs = File.Open(imagename, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite)
        srcBmp = CType(Bitmap.FromFile(imagename), Bitmap)
        img = srcBmp
        tempdi = New DirectoryInfo(Application.StartupPath & "\temp\")
        Dim num As Integer = tempdi.GetFiles.Count
        'Debug.Print(Application.StartupPath)
        'ListView1.Items.Add(Str(num), "Page" & Str(num + 1), num)
        img.Save(Application.StartupPath & "\temp\temp" & num & ".tif", Imaging.ImageFormat.Tiff)
        srcBmp.Dispose()

        num = 0
        For Each fi In tempdi.GetFiles
            ListView1.Items.Add(Str(num + 1), "Page" & Str(num + 1), num + 1)
            ImageList1.Images.Add(num + 1, CType(Bitmap.FromFile(Application.StartupPath & "\temp\temp" & num & ".tif"), Bitmap))
            num += 1
        Next

        'resized = New Bitmap(srcBmp, srcBmp.Width, srcBmp.Height)

        'SaveAddTiff(resized, filename)

        'Add tiff frames to image list for list view //  select frame from listview
        'fs = File.Open("temp.tiff", FileMode.Open, FileAccess.ReadWrite)
        'srcBmp = CType(Bitmap.FromStream(fs), Bitmap)
        'totalPages = CInt(srcBmp.GetFrameCount(FrameDimension.Page) - 1)

        'For i = 0 To totalPages
        ' srcBmp.SelectActiveFrame(FrameDimension.Page, i)
        'resized = New Bitmap(srcBmp, srcBmp.Width, srcBmp.Height)
        'ListView1.Items.Add(Str(i), "Page" & Str(i + 1), i)
        'ImageList1.Images.Add(i, resized)

        'Next
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

#End Region






#Region "BACKUP / TEST CODE"

    'Sub saveimagetopdf()
    '    ' Create a pdf document with a section and page added.
    '    Dim doc As New PdfDocument()
    '    Dim section As PdfSection = doc.Sections.Add()
    '    Dim page As PdfPageBase = doc.Pages.Add()

    '    'Load a tif image from system
    '    Dim image As PdfImage = PdfImage.FromFile("D:\images\bear.tif")
    '    'Set image display location and size in PDF
    '    Dim widthFitRate As Single = image.PhysicalDimension.Width / page.Canvas.ClientSize.Width
    '    Dim heightFitRate As Single = image.PhysicalDimension.Height / page.Canvas.ClientSize.Height
    '    Dim fitRate As Single = Math.Max(widthFitRate, heightFitRate)
    '    Dim fitWidth As Single = image.PhysicalDimension.Width / fitRate
    '    Dim fitHeight As Single = image.PhysicalDimension.Height / fitRate
    '    page.Canvas.DrawImage(image, 30, 30, fitWidth, fitHeight)
    '    'save and launch the file
    '    doc.SaveToFile("image to pdf.pdf")
    '    doc.Close()
    '    System.Diagnostics.Process.Start("image to pdf.pdf")

    'End Sub

    Sub form2show() Handles RibbonButton6.Click
        Form2.Show()
    End Sub

    'Public Sub PdfGen(URL As String, pageWidth As String, pageHeight As String, savingPath As String, fileName As String)
    '    Dim address As String = URL
    '    '"http://" + txtWebsiteAddress.Text;
    '    Dim width As Integer = Int32.Parse(pageWidth)
    '    Dim height As Integer = Int32.Parse(pageHeight)
    '    'Bitmap bmp = WebsiteThumbnailImageGenerator.GetWebSiteThumbnail(address, 800, 600, width, height);
    '    Dim bmp As Bitmap = WebsiteThumbnailImageGenerator.GetWebSiteThumbnail(address, width, height, width, height)

    '    Dim jpegSource As String = (Convert.ToString(savingPath & Convert.ToString("/ ")) & fileName) + ".jpg"
    '    Dim pdfSource As String = (Convert.ToString(savingPath & Convert.ToString("/ ")) & fileName) + ".pdf"
    '    bmp.Save(jpegSource)
    '    'bmp.Save(Server.MapPath("~") + "/thumbnail.tif");
    '    Dim doc As New PdfDocument()
    '    doc.Pages.Add(New PdfPage())
    '    Dim xgr As XGraphics = XGraphics.FromPdfPage(doc.Pages(0))
    '    Dim img As XImage = XImage.FromFile(jpegSource)

    '    xgr.DrawImage(img, 0, 0, width, height)
    '    doc.Save(pdfSource)
    '    doc.Close()

    '    Dim delimg As New FileInfo(jpegSource)
    '    delimg.Delete()
    'End Sub

#Region "TIFF TO PDF  **WORKS**"
    Dim tiff As New TiffImageSplitter()

    Public Sub tiff2PDF(fileName As String)
        fs.Dispose()
        Dim doc As New PdfDocument()

        Dim pageCount As Integer = tiff.getPageCount(fileName)

        For i As Integer = 0 To pageCount - 1
            Dim page As New PdfPage()

            Dim tiffImg As Image = tiff.getTiffImage(fileName, i)

            Dim img As XImage = XImage.FromGdiPlusImage(tiffImg)

            page.Width = img.PointWidth
            page.Height = img.PointHeight
            doc.Pages.Add(page)

            Dim xgr As XGraphics = XGraphics.FromPdfPage(doc.Pages(i))

            xgr.DrawImage(img, 0, 0)
        Next

        doc.Save("temp.pdf")

        doc.Close()

    End Sub



    Private Class TiffImageSplitter
        ' Retrive PageCount of a multi-page tiff image
        Public Function getPageCount(fileName As [String]) As Integer
            Dim pageCount As Integer = -1
            Try
                Dim img As Image = Bitmap.FromFile(fileName)
                pageCount = img.GetFrameCount(FrameDimension.Page)

                img.Dispose()
            Catch ex As Exception
                pageCount = 0
            End Try
            Return pageCount
        End Function

        Public Function getPageCount(img As Image) As Integer
            Dim pageCount As Integer = -1
            Try
                pageCount = img.GetFrameCount(FrameDimension.Page)
            Catch ex As Exception
                pageCount = 0
            End Try
            Return pageCount
        End Function

        ' Retrive a specific Page from a multi-page tiff image
        Public Function getTiffImage(sourceFile As [String], pageNumber As Integer) As Image
            Dim returnImage As Image = Nothing

            Try
                Dim sourceIamge As Image = Bitmap.FromFile(sourceFile)
                returnImage = getTiffImage(sourceIamge, pageNumber)
                sourceIamge.Dispose()
            Catch ex As Exception
                returnImage = Nothing
            End Try

            '       String splittedImageSavePath = "X:\\CJT\\CJT-Docs\\CJT-Images\\result001.tif";
            '       returnImage.Save(splittedImageSavePath);

            Return returnImage
        End Function

        Public Function getTiffImage(sourceImage As Image, pageNumber As Integer) As Image
            Dim ms As MemoryStream = Nothing
            Dim returnImage As Image = Nothing

            Try
                ms = New MemoryStream()
                Dim objGuid As Guid = sourceImage.FrameDimensionsList(0)
                Dim objDimension As New FrameDimension(objGuid)
                sourceImage.SelectActiveFrame(objDimension, pageNumber)
                sourceImage.Save(ms, ImageFormat.Tiff)
                returnImage = Image.FromStream(ms)
            Catch ex As Exception
                returnImage = Nothing
            End Try
            Return returnImage
        End Function
    End Class
#End Region

    'Public Function tifftopdf2(sfilename)   **NOT TESTED**
    '    Dim objDoc As PdfDocument
    '    Dim objPdfPage As PdfPage
    '    Dim objTiffImg As Image
    '    Dim objXImg As XImage
    '    Dim iPageCount As Integer
    '    Dim objXgr As XGraphics
    '    Dim sPdfFile As String = Nothing
    '    Dim objDir As DirectoryInfo
    '    Dim objFile As FileInfo()
    '    Dim objFileInfo As FileInfo

    '    Try
    '        Dim objTiffImageSpliter = New TiffImageSplitter()
    '        objDoc = New PdfDocument
    '        iPageCount = objTiffImageSpliter.getPageCount(sfilename)

    '        For iCount As Integer = 0 To iPageCount - 1
    '            objPdfPage = New PdfPage
    '            objTiffImg = objTiffImageSpliter.getTiffImage(sfilename, iCount)
    '            objXImg = XImage.FromGdiPlusImage(objTiffImg)
    '            'objPdfPage.Height = objXImg.PointWidth
    '            'objPdfPage.Width = objXImg.PointHeight
    '            objDoc.Pages.Add(objPdfPage)
    '            objXgr = XGraphics.FromPdfPage(objDoc.Pages(iCount))
    '            objXgr.DrawImage(objXImg, 10, 10)
    '        Next
    '        sPdfFile = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\MY_FaxFile\"

    '        If System.IO.Directory.Exists(sPdfFile) Then
    '            objDir = New DirectoryInfo(sPdfFile)
    '            objFile = objDir.GetFiles()

    '            For Each objFileInfo In objFile
    '                objFileInfo.Delete()
    '            Next

    '            sPdfFile &= "MyFax.pdf"
    '        Else
    '            System.IO.Directory.CreateDirectory(sPdfFile)
    '            sPdfFile &= "MyFax.pdf"
    '        End If

    '        objDoc.Save(sPdfFile)   ' This Line shows the Error.
    '        objDoc.Close()
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '        sPdfFile = Nothing
    '    End Try

    '    Return sPdfFile
    'End Function


#Region " Save images to single multi-tiff image  **WORKS**  "
    Sub SaveAddTiff(ByVal img As Image, ByVal filename As String)
        If Not System.IO.File.Exists(filename) Then
            img.Save(filename, Imaging.ImageFormat.Tiff)
        Else
            Dim frames As List(Of Image) = getFrames(filename)
            frames.Add(img)
            SaveMultiTiff(frames.ToArray, filename)
        End If
        img.Dispose()
    End Sub

    Sub SaveMultiTiff(ByVal frames() As Image, ByVal filename As String)
        Dim codec As ImageCodecInfo = getTiffCodec()
        Dim enc As Encoder = Encoder.SaveFlag
        Dim ep As New EncoderParameters(2)
        ep.Param(0) = New EncoderParameter(enc, CLng(EncoderValue.MultiFrame))
        ep.Param(1) = New EncoderParameter(Encoder.Compression, CLng(EncoderValue.CompressionNone))
        Dim tiff As Image = frames(0)
        tiff.Save(filename, codec, ep)
        ep.Param(0) = New EncoderParameter(enc, CLng(EncoderValue.FrameDimensionPage))
        For i As Integer = 1 To frames.Length - 1
            tiff.SaveAdd(frames(i), ep)
            frames(i).Dispose()
        Next
        ep.Param(0) = New EncoderParameter(enc, CLng(EncoderValue.Flush))
        tiff.SaveAdd(ep)
        tiff.Dispose()
    End Sub

    Function getTiffCodec() As ImageCodecInfo
        For Each ice As ImageCodecInfo In ImageCodecInfo.GetImageEncoders()
            If ice.MimeType = "image/tiff" Then
                Return ice
            End If
        Next
        Return Nothing
    End Function

    Function getFrames(ByVal filename) As List(Of Image)
        Dim frames As New List(Of Image)
        Dim img As Image = Image.FromFile(filename)
        For i As Integer = 0 To img.GetFrameCount(Imaging.FrameDimension.Page) - 1
            img.SelectActiveFrame(Imaging.FrameDimension.Page, i)
            Dim tmp As New Bitmap(img.Width, img.Height)
            Dim g As Graphics = Graphics.FromImage(tmp)
            g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
            g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit
            g.DrawImageUnscaled(img, 0, 0)
            frames.Add(tmp)
            g.Dispose()
        Next
        img.Dispose()
        Return frames
    End Function
#End Region

#End Region

End Class
