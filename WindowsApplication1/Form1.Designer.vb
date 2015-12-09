<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.OpenFile = New System.Windows.Forms.OpenFileDialog()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.dirPath = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Printview = New System.Windows.Forms.PrintPreviewDialog()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ImportDirDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.PdfOpen = New System.Windows.Forms.OpenFileDialog()
        Me.btnPDFopen = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.NaviBar1 = New Guifreaks.Navisuite.NaviBar(Me.components)
        Me.NaviBand1 = New Guifreaks.Navisuite.NaviBand(Me.components)
        Me.NaviBand2 = New Guifreaks.Navisuite.NaviBand(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.NaviBar1.SuspendLayout()
        Me.NaviBand1.ClientArea.SuspendLayout()
        Me.NaviBand1.SuspendLayout()
        Me.NaviBand2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(250, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(569, 789)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'OpenFile
        '
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(64, 11)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(62, 39)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Save Pic Image"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(128, 128)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'ListView1
        '
        Me.ListView1.Location = New System.Drawing.Point(8, 3)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(219, 672)
        Me.ListView1.TabIndex = 2
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.dirPath})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 808)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(831, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'dirPath
        '
        Me.dirPath.Name = "dirPath"
        Me.dirPath.Size = New System.Drawing.Size(82, 17)
        Me.dirPath.Text = "Directory Path"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(0, 11)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(67, 38)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Open File"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Printview
        '
        Me.Printview.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.Printview.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.Printview.ClientSize = New System.Drawing.Size(400, 300)
        Me.Printview.Enabled = True
        Me.Printview.Icon = CType(resources.GetObject("Printview.Icon"), System.Drawing.Icon)
        Me.Printview.Name = "Printview"
        Me.Printview.Visible = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(123, 11)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(56, 38)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Preview"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'PdfOpen
        '
        Me.PdfOpen.FileName = "OpenFileDialog1"
        '
        'btnPDFopen
        '
        Me.btnPDFopen.Location = New System.Drawing.Point(175, 12)
        Me.btnPDFopen.Name = "btnPDFopen"
        Me.btnPDFopen.Size = New System.Drawing.Size(43, 36)
        Me.btnPDFopen.TabIndex = 6
        Me.btnPDFopen.Text = "PDF IMPORT"
        Me.btnPDFopen.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(224, 14)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(61, 36)
        Me.Button4.TabIndex = 7
        Me.Button4.Text = "Button4"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'NaviBar1
        '
        Me.NaviBar1.ActiveBand = Me.NaviBand2
        Me.NaviBar1.Controls.Add(Me.NaviBand1)
        Me.NaviBar1.Controls.Add(Me.NaviBand2)
        Me.NaviBar1.Location = New System.Drawing.Point(3, 56)
        Me.NaviBar1.Name = "NaviBar1"
        Me.NaviBar1.Size = New System.Drawing.Size(241, 745)
        Me.NaviBar1.TabIndex = 8
        Me.NaviBar1.Text = "NaviBar1"
        '
        'NaviBand1
        '
        '
        'NaviBand1.ClientArea
        '
        Me.NaviBand1.ClientArea.Controls.Add(Me.ListView1)
        Me.NaviBand1.ClientArea.LayoutStyle = Guifreaks.Navisuite.NaviLayoutStyle.StyleFromOwner
        Me.NaviBand1.ClientArea.Location = New System.Drawing.Point(0, 0)
        Me.NaviBand1.ClientArea.Name = "ClientArea"
        Me.NaviBand1.ClientArea.Size = New System.Drawing.Size(1, 1)
        Me.NaviBand1.ClientArea.TabIndex = 0
        Me.NaviBand1.LargeImageIndex = 0
        Me.NaviBand1.LayoutStyle = Guifreaks.Navisuite.NaviLayoutStyle.StyleFromOwner
        Me.NaviBand1.Location = New System.Drawing.Point(1, 27)
        Me.NaviBand1.Name = "NaviBand1"
        Me.NaviBand1.Size = New System.Drawing.Size(0, 0)
        Me.NaviBand1.SmallImageIndex = 0
        Me.NaviBand1.TabIndex = 3
        '
        'NaviBand2
        '
        '
        'NaviBand2.ClientArea
        '
        Me.NaviBand2.ClientArea.LayoutStyle = Guifreaks.Navisuite.NaviLayoutStyle.StyleFromOwner
        Me.NaviBand2.ClientArea.Location = New System.Drawing.Point(0, 0)
        Me.NaviBand2.ClientArea.Name = "ClientArea"
        Me.NaviBand2.ClientArea.Size = New System.Drawing.Size(239, 678)
        Me.NaviBand2.ClientArea.TabIndex = 0
        Me.NaviBand2.LargeImageIndex = 0
        Me.NaviBand2.LayoutStyle = Guifreaks.Navisuite.NaviLayoutStyle.StyleFromOwner
        Me.NaviBand2.Location = New System.Drawing.Point(1, 27)
        Me.NaviBand2.Name = "NaviBand2"
        Me.NaviBand2.Size = New System.Drawing.Size(239, 678)
        Me.NaviBand2.SmallImageIndex = 0
        Me.NaviBand2.TabIndex = 5
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(831, 830)
        Me.Controls.Add(Me.NaviBar1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.btnPDFopen)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.NaviBar1.ResumeLayout(False)
        Me.NaviBand1.ClientArea.ResumeLayout(False)
        Me.NaviBand1.ResumeLayout(False)
        Me.NaviBand2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents OpenFile As OpenFileDialog
    Friend WithEvents Button1 As Button
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents ListView1 As ListView
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents Button2 As Button
    Friend WithEvents Printview As PrintPreviewDialog
    Friend WithEvents Button3 As Button
    Friend WithEvents ImportDirDialog As FolderBrowserDialog
    Friend WithEvents dirPath As ToolStripStatusLabel
    Friend WithEvents PdfOpen As OpenFileDialog
    Friend WithEvents btnPDFopen As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents NaviBar1 As Guifreaks.Navisuite.NaviBar
    Friend WithEvents NaviBand2 As Guifreaks.Navisuite.NaviBand
    Friend WithEvents NaviBand1 As Guifreaks.Navisuite.NaviBand
End Class
