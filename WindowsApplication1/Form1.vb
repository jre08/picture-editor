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
    Dim imgBmp As Bitmap
    Dim resized As Image
    Dim img As Image
    Dim pic As Image
    Dim tempdi As DirectoryInfo
    Public filename As String
    Dim tempfile As String = "temp.tif"
    Dim srcBmpfrm As Bitmap
    Dim ListNum As Integer = 0
    Private WithEvents prntDoc As New PrintDocument()

#End Region



#Region "Ribbon Menu Buttons"

    Private Sub Openfile_click(sender As Object, e As EventArgs) Handles RibbonButton1.Click
        OpenFile.ShowDialog()
    End Sub

    Public Sub OpenFile_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFile.FileOk
        addimage2(OpenFile.FileName)
        ImgList()

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
    End Sub

    Private Sub RibbonOrbOptionButton2_Click(sender As Object, e As EventArgs) Handles RibbonOrbOptionButton2.Click
        Me.Close()
    End Sub

    Private Sub PrintPreview_Click(sender As Object, e As EventArgs) Handles RibbonButton3.Click

        Printview.Document = prntDoc
        Printview.ShowDialog()

    End Sub

    Private Sub Editmode_change() Handles Rbn_ck_Editmode.CheckBoxCheckChanged
        'If Rbn_ck_Editmode.Checked = True Then
        '    If importedpdf = False Then
        '        For Each item As ListViewItem In ListView1.SelectedItems()
        '            'srcBmpfr.SelectActiveFrame(FrameDimension.Page, item.ImageIndex)
        '            'PictureBox1.Image = ResizeImage(srcBmp, New Size(PictureBox1.Width, PictureBox1.Height))
        '            'PictureBox1.Width = srcBmpfrm.Width
        '            'PictureBox1.Height = srcBmpfrm.Height
        '            'PictureBox1.Image = srcBmpfrm

        '        Next
        '        'Else
        '        '    For Each item As ListViewItem In ListView1.SelectedItems()
        '        '        Dim folder As String = dirPath.Text
        '        '        filename = System.IO.Path.Combine(folder, item.Text)
        '        '        fs = File.Open(filename, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite)
        '        '        srcBmp = CType(Bitmap.FromStream(fs), Bitmap)
        '        '        resized = New Bitmap(srcBmp, srcBmp.Width, srcBmp.Height)
        '        '    Next

        '    End If
        'ElseIf Rbn_ck_Editmode.Checked = False Then
        '    PictureBox1.Width = 667
        '    PictureBox1.Height = 771


        'End If
    End Sub

    Private Sub CloseImage() Handles rbn_btn_closeimg.Click
        ImageList1.Images.Clear()
        ListView1.Items.Clear()
        srcBmp = Nothing
        fs.Dispose()
        PictureBox1.Image = New Bitmap(Image.FromFile("back.jpg"))
        tempdi = New DirectoryInfo(Application.StartupPath & "\temp\")
        For Each fi In tempdi.GetFiles
            fi.Delete()
        Next
    End Sub

    Private Sub SaveEdit() Handles rbn_btn_svedit.Click
        savemouse()
    End Sub
#End Region

    Private Sub prntDoc_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles prntDoc.PrintPage
        Dim ImgX As Integer
        Dim ImgY As Integer
        Dim PSizeX As Integer
        Dim PSizeY As Integer
        Dim ScaleX As Double
        Dim ScaleY As Double
        Dim RecX As Integer
        Dim RecY As Integer
        Dim ScaleM As Double


        ImgX = Me.PictureBox1.Image.Height
        ImgY = Me.PictureBox1.Image.Width
        If Me.prntDoc.DefaultPageSettings.Landscape = False Then
            PSizeX = Me.prntDoc.DefaultPageSettings.PaperSize.Height
            PSizeY = Me.prntDoc.DefaultPageSettings.PaperSize.Width
        Else
            PSizeX = Me.prntDoc.DefaultPageSettings.PaperSize.Width
            PSizeY = Me.prntDoc.DefaultPageSettings.PaperSize.Height
        End If
        ScaleX = PSizeX / ImgX
        ScaleY = PSizeY / ImgY
        If ScaleX < ScaleY Then
            ScaleM = ScaleX
        Else : ScaleM = ScaleY
        End If
        RecY = ImgY * ScaleM
        RecX = ImgX * ScaleM
        e.Graphics.DrawImage(PictureBox1.Image, 0, 0, RecY, RecX)








        'Dim emf As Image = Me.PictureBox1.Image
        'Dim zoomImg As Image = New Bitmap(CInt(emf.Size.Width * 2), CInt(emf.Size.Height * 2))
        'Using g As Graphics = Graphics.FromImage(zoomImg)
        '    g.ScaleTransform(1.0F, 1.0F)
        '    g.DrawImage(emf, New Rectangle(New Point(0, 0), emf.Size), New Rectangle(New Point(0, 0), emf.Size), GraphicsUnit.Pixel)
        'End Using
        'e.Graphics.DrawImage(emf, 0, 0)
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If importedpdf = False Then
            For Each item As ListViewItem In ListView1.SelectedItems()
                ListNum = item.Index
                srcBmp = Nothing
                fs.Dispose()
                fs = File.Open(Application.StartupPath & "\temp\temp" & ListNum & ".tif", FileMode.Open, FileAccess.ReadWrite)
                srcBmp = CType(Bitmap.FromStream(fs), Bitmap)
                'srcBmpfrm = Bitmap.FromFile(Application.StartupPath & "\temp\temp" & item.Index & ".tif")
                'srcBmp.SelectActiveFrame(FrameDimension.Page, item.ImageIndex)
                'PictureBox1.Image = ResizeImage(srcBmp, New Size(PictureBox1.Width, PictureBox1.Height))
                'PictureBox1.Width = srcBmp.Width
                'PictureBox1.Height = srcBmp.Height
                PictureBox1.Image = srcBmp


            Next


        Else

            '    'PictureBox1.Image = ResizeImage(srcBmp, New Size(PictureBox1.Width, PictureBox1.Height))
            'filename = System.IO.Path.Combine(folder, item.Text)

            If Rbn_ck_Editmode.Checked = True Then
                PictureBox1.Width = picsizew(srcBmp)
                PictureBox1.Height = picsizeh(srcBmp)
            End If

        End If


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
            objBmp.Dispose()
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




#End Region



#Region "Functions"

    Private allowedExtensions() As String = {
".gif",
".jpg",
".bmp",
".png",
".tiff",
".tif"
    }
    Sub ImportDir()

        Dim di As DirectoryInfo = New DirectoryInfo(ImportDirDialog.SelectedPath)
        For Each fi In di.GetFiles
            For Each extension As String In allowedExtensions
                If extension = System.IO.Path.GetExtension(fi.FullName) Then
                    Debug.Print(fi.Name)
                    addimage2(fi.FullName)
                    'ImageList1.Images.Add(Image.FromFile(dirFile))

                End If
            Next
            'If fi.Extension = ".jpg" Then

            'End If
        Next

        dirPath.Text = ImportDirDialog.SelectedPath
        importeddir = True
        ImgList()
    End Sub

    Sub addimage2(filename As String)
        tempdi = New DirectoryInfo(Application.StartupPath & "\temp\")
        fs = File.Open(filename, FileMode.Open, FileAccess.ReadWrite)
        srcBmp = CType(Bitmap.FromStream(fs), Bitmap)
        totalPages = CInt(srcBmp.GetFrameCount(FrameDimension.Page) - 1)
        For i = 0 To totalPages
            srcBmp.SelectActiveFrame(FrameDimension.Page, i)

            resized = New Bitmap(srcBmp, srcBmp.Width, srcBmp.Height)
            If srcBmp.Width > "1200" Then
                resized = ResizeImage(resized, New Size(srcBmp.Width / 2.1, srcBmp.Height / 2.1), True)
            End If
            Dim num As Integer = tempdi.GetFiles.Count
            resized.Save(Application.StartupPath & "\temp\temp" & num & ".tif", Imaging.ImageFormat.Tiff)
            resized.Dispose()
        Next
        fs.Dispose()
        'PictureBox1.Image = ResizeImage(srcBmp, New Size(PictureBox1.Width, PictureBox1.Height))
        'ListView1.Items.Item(0).Selected = True
    End Sub

    'Retrieves the temp files in the application root temp folder in order to be add to the Image List 1
    Sub ImgList2(objNewbmp As Image, listnum As String)
        Debug.Print(listnum)
        ImageList1.Images.RemoveByKey(listnum)
        ImageList1.Images.Add(listnum, objNewbmp)
        'ImageList1.Images.Clear()
        'imgBmp = Nothing
        'tempdi = New DirectoryInfo(Application.StartupPath & "\temp\")
        'Dim num = 0
        'For i = 0 To tempdi.GetFiles.Count - 1
        '    num = i
        '    fs = File.Open(Application.StartupPath & "\temp\temp" & num & ".tif", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite)
        '    imgBmp = CType(Bitmap.FromStream(fs), Bitmap)
        '    ImageList1.Images.Add(num + 1, imgBmp)
        '    ListView1.Items.Add(Str(num), "Page" & Str(num + 1), num)
        '    fs.Dispose()
        '    num += 1
        'Next
    End Sub
    Sub ImgList()
        Me.Cursor = Cursors.WaitCursor
        ListView1.Items.Clear()

        ImageList1.Images.Clear()
        imgBmp = Nothing
        tempdi = New DirectoryInfo(Application.StartupPath & "\temp\")
        Dim num = 0
        For i = 0 To tempdi.GetFiles.Count - 1
            num = i
            fs = File.Open(Application.StartupPath & "\temp\temp" & num & ".tif", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite)
            imgBmp = CType(Bitmap.FromStream(fs), Bitmap)
            ImageList1.Images.Add(num, imgBmp)
            ListView1.Items.Add(Str(num), "Page" & Str(num + 1), num)
            fs.Dispose()
            num += 1
        Next
        Me.Cursor = Cursors.Default
    End Sub

    'Envoked when save button is clicked;  saves a new copy of edited temp file
    Sub savemouse()
        ''Saves the picturebox image in a temp folder
        Dim objNewBmp As New Bitmap(PictureBox1.Image)
        Dim g As Graphics

        For Each item As ListViewItem In ListView1.SelectedItems()
            ListNum = item.Index
        Next

        'ImageList1.Images.Clear()
        'ListView1.Items.Clear()
        srcBmp = Nothing
        fs.Dispose()
        'PictureBox1.Image.Dispose()
        'delete the current temp file to be overwritten by the new edited temp file
        My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\temp\temp" & ListNum & ".tif")
        g = Graphics.FromImage(objNewBmp)
        ''Creats a duplicate image file as bitmap format 

        ''Creates an rectagnle on the picture box for visual.
        g = PictureBox1.CreateGraphics
        objNewBmp.Save(Application.StartupPath & "\temp\temp" & ListNum & ".tif", Imaging.ImageFormat.Tiff)

        'ListView1.Refresh()
        ImgList()
        'ListView1.Items.Item(ListNum).Selected = True
    End Sub

    'Resize an image without distortion
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


#Region "TIFF To PDF  **WORKS  Using PDFSHARP .NET**"
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

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ImgList()
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

#Region "BACKUP / TEST CODE"


    '  ### Free Spire.net PDF SDK(pdf to tiff)  ** NEED Free/or/Full SPIRE.NET PDF framework
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

#End Region

End Class
