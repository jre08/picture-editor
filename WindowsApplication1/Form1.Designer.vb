Imports MetroFramework.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form
    'Inherits MetroForm
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
        Me.OpenFile = New System.Windows.Forms.OpenFileDialog()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.dirPath = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Printview = New System.Windows.Forms.PrintPreviewDialog()
        Me.ImportDirDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.PdfOpen = New System.Windows.Forms.OpenFileDialog()
        Me.NaviBar1 = New Guifreaks.Navisuite.NaviBar(Me.components)
        Me.NaviBand2 = New Guifreaks.Navisuite.NaviBand(Me.components)
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.NaviBand1 = New Guifreaks.Navisuite.NaviBand(Me.components)
        Me.NaviGroup1 = New Guifreaks.Navisuite.NaviGroup(Me.components)
        Me.RibbonTab1 = New System.Windows.Forms.RibbonTab()
        Me.RibbonPanel1 = New System.Windows.Forms.RibbonPanel()
        Me.RibbonButton1 = New System.Windows.Forms.RibbonButton()
        Me.RibbonButton2 = New System.Windows.Forms.RibbonButton()
        Me.RibbonButton3 = New System.Windows.Forms.RibbonButton()
        Me.RibbonButton5 = New System.Windows.Forms.RibbonButton()
        Me.RibbonPanel2 = New System.Windows.Forms.RibbonPanel()
        Me.RibbonButton4 = New System.Windows.Forms.RibbonButton()
        Me.RibbonPanel3 = New System.Windows.Forms.RibbonPanel()
        Me.rbn_btn_closeimg = New System.Windows.Forms.RibbonButton()
        Me.Rbn_ck_Editmode = New System.Windows.Forms.RibbonCheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Ribbon1 = New System.Windows.Forms.Ribbon()
        Me.RibbonOrbMenuItem3 = New System.Windows.Forms.RibbonOrbMenuItem()
        Me.RibbonOrbOptionButton2 = New System.Windows.Forms.RibbonOrbOptionButton()
        Me.RibbonButton6 = New System.Windows.Forms.RibbonButton()
        Me.RibbonOrbOptionButton1 = New System.Windows.Forms.RibbonOrbOptionButton()
        Me.RibbonOrbRecentItem1 = New System.Windows.Forms.RibbonOrbRecentItem()
        Me.RibbonOrbRecentItem2 = New System.Windows.Forms.RibbonOrbRecentItem()
        Me.RibbonOrbMenuItem1 = New System.Windows.Forms.RibbonOrbMenuItem()
        Me.RibbonOrbMenuItem2 = New System.Windows.Forms.RibbonOrbMenuItem()
        Me.StatusStrip1.SuspendLayout()
        Me.NaviBar1.SuspendLayout()
        Me.NaviBand2.ClientArea.SuspendLayout()
        Me.NaviBand2.SuspendLayout()
        Me.NaviBand1.ClientArea.SuspendLayout()
        Me.NaviBand1.SuspendLayout()
        CType(Me.NaviGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NaviGroup1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OpenFile
        '
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(128, 128)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'ListView1
        '
        Me.ListView1.LargeImageList = Me.ImageList1
        Me.ListView1.Location = New System.Drawing.Point(6, 25)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(219, 599)
        Me.ListView1.TabIndex = 2
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.dirPath})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 843)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(928, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'dirPath
        '
        Me.dirPath.Name = "dirPath"
        Me.dirPath.Size = New System.Drawing.Size(82, 17)
        Me.dirPath.Text = "Directory Path"
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
        'PdfOpen
        '
        Me.PdfOpen.FileName = "OpenFileDialog1"
        '
        'NaviBar1
        '
        Me.NaviBar1.ActiveBand = Me.NaviBand1
        Me.NaviBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.NaviBar1.Controls.Add(Me.NaviBand1)
        Me.NaviBar1.Controls.Add(Me.NaviBand2)
        Me.NaviBar1.LayoutStyle = Guifreaks.Navisuite.NaviLayoutStyle.Office2007Silver
        Me.NaviBar1.Location = New System.Drawing.Point(3, 139)
        Me.NaviBar1.Name = "NaviBar1"
        Me.NaviBar1.Size = New System.Drawing.Size(241, 701)
        Me.NaviBar1.TabIndex = 8
        Me.NaviBar1.Text = "Redact Editor"
        '
        'NaviBand2
        '
        '
        'NaviBand2.ClientArea
        '
        Me.NaviBand2.ClientArea.Controls.Add(Me.ListView2)
        Me.NaviBand2.ClientArea.LayoutStyle = Guifreaks.Navisuite.NaviLayoutStyle.StyleFromOwner
        Me.NaviBand2.ClientArea.Location = New System.Drawing.Point(2, 3)
        Me.NaviBand2.ClientArea.Name = "ClientArea"
        Me.NaviBand2.ClientArea.Size = New System.Drawing.Size(1, 1)
        Me.NaviBand2.ClientArea.TabIndex = 0
        Me.NaviBand2.LargeImageIndex = 0
        Me.NaviBand2.LayoutStyle = Guifreaks.Navisuite.NaviLayoutStyle.StyleFromOwner
        Me.NaviBand2.Location = New System.Drawing.Point(1, 27)
        Me.NaviBand2.Name = "NaviBand2"
        Me.NaviBand2.Size = New System.Drawing.Size(0, 0)
        Me.NaviBand2.SmallImageIndex = 0
        Me.NaviBand2.TabIndex = 5
        '
        'ListView2
        '
        Me.ListView2.LargeImageList = Me.ImageList2
        Me.ListView2.Location = New System.Drawing.Point(1, 0)
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(224, 511)
        Me.ListView2.SmallImageList = Me.ImageList2
        Me.ListView2.TabIndex = 0
        Me.ListView2.UseCompatibleStateImageBehavior = False
        Me.ListView2.View = System.Windows.Forms.View.SmallIcon
        '
        'ImageList2
        '
        Me.ImageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit
        Me.ImageList2.ImageSize = New System.Drawing.Size(256, 256)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        '
        'NaviBand1
        '
        '
        'NaviBand1.ClientArea
        '
        Me.NaviBand1.ClientArea.Controls.Add(Me.NaviGroup1)
        Me.NaviBand1.ClientArea.LayoutStyle = Guifreaks.Navisuite.NaviLayoutStyle.StyleFromOwner
        Me.NaviBand1.ClientArea.Location = New System.Drawing.Point(0, 3)
        Me.NaviBand1.ClientArea.Name = "ClientArea"
        Me.NaviBand1.ClientArea.Size = New System.Drawing.Size(239, 634)
        Me.NaviBand1.ClientArea.TabIndex = 0
        Me.NaviBand1.LargeImageIndex = 0
        Me.NaviBand1.LayoutStyle = Guifreaks.Navisuite.NaviLayoutStyle.StyleFromOwner
        Me.NaviBand1.Location = New System.Drawing.Point(1, 27)
        Me.NaviBand1.Name = "NaviBand1"
        Me.NaviBand1.Size = New System.Drawing.Size(239, 634)
        Me.NaviBand1.SmallImageIndex = 0
        Me.NaviBand1.TabIndex = 3
        '
        'NaviGroup1
        '
        Me.NaviGroup1.Caption = "Thumbnail Images"
        Me.NaviGroup1.Controls.Add(Me.ListView1)
        Me.NaviGroup1.ExpandedHeight = 628
        Me.NaviGroup1.HeaderContextMenuStrip = Nothing
        Me.NaviGroup1.LayoutStyle = Guifreaks.Navisuite.NaviLayoutStyle.Office2007Silver
        Me.NaviGroup1.Location = New System.Drawing.Point(2, 0)
        Me.NaviGroup1.Name = "NaviGroup1"
        Me.NaviGroup1.Padding = New System.Windows.Forms.Padding(1, 22, 1, 1)
        Me.NaviGroup1.Size = New System.Drawing.Size(234, 628)
        Me.NaviGroup1.TabIndex = 0
        Me.NaviGroup1.Text = "Thumbnails"
        '
        'RibbonTab1
        '
        Me.RibbonTab1.Panels.Add(Me.RibbonPanel1)
        Me.RibbonTab1.Panels.Add(Me.RibbonPanel2)
        Me.RibbonTab1.Panels.Add(Me.RibbonPanel3)
        Me.RibbonTab1.Text = "Home"
        '
        'RibbonPanel1
        '
        Me.RibbonPanel1.Items.Add(Me.RibbonButton1)
        Me.RibbonPanel1.Items.Add(Me.RibbonButton2)
        Me.RibbonPanel1.Items.Add(Me.RibbonButton3)
        Me.RibbonPanel1.Items.Add(Me.RibbonButton5)
        Me.RibbonPanel1.Text = "Open / Save File"
        '
        'RibbonButton1
        '
        Me.RibbonButton1.Image = Global.PictureBoxPractice.My.Resources.Resources.folder_images
        Me.RibbonButton1.SmallImage = Global.PictureBoxPractice.My.Resources.Resources.folder_images
        Me.RibbonButton1.Text = "Open Image"
        Me.RibbonButton1.ToolTip = "Open a specific image"
        '
        'RibbonButton2
        '
        Me.RibbonButton2.Image = Global.PictureBoxPractice.My.Resources.Resources.folder
        Me.RibbonButton2.SmallImage = CType(resources.GetObject("RibbonButton2.SmallImage"), System.Drawing.Image)
        Me.RibbonButton2.Text = "Import Folder"
        Me.RibbonButton2.ToolTip = "Import a folder of images"
        '
        'RibbonButton3
        '
        Me.RibbonButton3.Image = Global.PictureBoxPractice.My.Resources.Resources.action_print
        Me.RibbonButton3.SmallImage = CType(resources.GetObject("RibbonButton3.SmallImage"), System.Drawing.Image)
        Me.RibbonButton3.Text = "Print Preview"
        '
        'RibbonButton5
        '
        Me.RibbonButton5.Image = Global.PictureBoxPractice.My.Resources.Resources.action_save
        Me.RibbonButton5.SmallImage = CType(resources.GetObject("RibbonButton5.SmallImage"), System.Drawing.Image)
        Me.RibbonButton5.Text = "Save File"
        '
        'RibbonPanel2
        '
        Me.RibbonPanel2.Items.Add(Me.RibbonButton4)
        Me.RibbonPanel2.Text = "PDF TOOLS"
        '
        'RibbonButton4
        '
        Me.RibbonButton4.Image = Global.PictureBoxPractice.My.Resources.Resources.icon_component
        Me.RibbonButton4.SmallImage = CType(resources.GetObject("RibbonButton4.SmallImage"), System.Drawing.Image)
        Me.RibbonButton4.Text = "Import PDF"
        '
        'RibbonPanel3
        '
        Me.RibbonPanel3.Items.Add(Me.rbn_btn_closeimg)
        Me.RibbonPanel3.Items.Add(Me.Rbn_ck_Editmode)
        Me.RibbonPanel3.Text = "Edit Image"
        '
        'rbn_btn_closeimg
        '
        Me.rbn_btn_closeimg.Image = Global.PictureBoxPractice.My.Resources.Resources.action_stop
        Me.rbn_btn_closeimg.SmallImage = Global.PictureBoxPractice.My.Resources.Resources.action_stop
        Me.rbn_btn_closeimg.Text = "Close Image"
        '
        'Rbn_ck_Editmode
        '
        Me.Rbn_ck_Editmode.Text = "Edit Mode Enabled"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(250, 139)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(666, 701)
        Me.Panel1.TabIndex = 10
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(3, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(660, 695)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Ribbon1
        '
        Me.Ribbon1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Ribbon1.Location = New System.Drawing.Point(0, 0)
        Me.Ribbon1.Minimized = False
        Me.Ribbon1.Name = "Ribbon1"
        '
        '
        '
        Me.Ribbon1.OrbDropDown.BorderRoundness = 8
        Me.Ribbon1.OrbDropDown.Location = New System.Drawing.Point(0, 0)
        Me.Ribbon1.OrbDropDown.MenuItems.Add(Me.RibbonOrbMenuItem3)
        Me.Ribbon1.OrbDropDown.Name = ""
        Me.Ribbon1.OrbDropDown.OptionItems.Add(Me.RibbonOrbOptionButton2)
        Me.Ribbon1.OrbDropDown.Size = New System.Drawing.Size(527, 116)
        Me.Ribbon1.OrbDropDown.TabIndex = 0
        Me.Ribbon1.OrbImage = Global.PictureBoxPractice.My.Resources.Resources.icon_home
        '
        '
        '
        Me.Ribbon1.QuickAcessToolbar.Items.Add(Me.RibbonButton6)
        Me.Ribbon1.RibbonTabFont = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.Ribbon1.Size = New System.Drawing.Size(928, 133)
        Me.Ribbon1.TabIndex = 9
        Me.Ribbon1.Tabs.Add(Me.RibbonTab1)
        Me.Ribbon1.TabsMargin = New System.Windows.Forms.Padding(12, 26, 20, 0)
        Me.Ribbon1.Text = "Ribbon1"
        Me.Ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Black
        '
        'RibbonOrbMenuItem3
        '
        Me.RibbonOrbMenuItem3.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.RibbonOrbMenuItem3.Image = CType(resources.GetObject("RibbonOrbMenuItem3.Image"), System.Drawing.Image)
        Me.RibbonOrbMenuItem3.SmallImage = CType(resources.GetObject("RibbonOrbMenuItem3.SmallImage"), System.Drawing.Image)
        Me.RibbonOrbMenuItem3.Text = "RibbonOrbMenuItem3"
        '
        'RibbonOrbOptionButton2
        '
        Me.RibbonOrbOptionButton2.Image = CType(resources.GetObject("RibbonOrbOptionButton2.Image"), System.Drawing.Image)
        Me.RibbonOrbOptionButton2.SmallImage = CType(resources.GetObject("RibbonOrbOptionButton2.SmallImage"), System.Drawing.Image)
        Me.RibbonOrbOptionButton2.Text = "Close"
        '
        'RibbonButton6
        '
        Me.RibbonButton6.Image = Global.PictureBoxPractice.My.Resources.Resources.comment
        Me.RibbonButton6.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact
        Me.RibbonButton6.SmallImage = Global.PictureBoxPractice.My.Resources.Resources.comment
        Me.RibbonButton6.Text = "RibbonButton6"
        '
        'RibbonOrbOptionButton1
        '
        Me.RibbonOrbOptionButton1.Image = Global.PictureBoxPractice.My.Resources.Resources.action_stop
        Me.RibbonOrbOptionButton1.SmallImage = Global.PictureBoxPractice.My.Resources.Resources.action_stop
        Me.RibbonOrbOptionButton1.Text = "CLOSE"
        '
        'RibbonOrbRecentItem1
        '
        Me.RibbonOrbRecentItem1.Image = CType(resources.GetObject("RibbonOrbRecentItem1.Image"), System.Drawing.Image)
        Me.RibbonOrbRecentItem1.SmallImage = CType(resources.GetObject("RibbonOrbRecentItem1.SmallImage"), System.Drawing.Image)
        Me.RibbonOrbRecentItem1.Text = "RibbonOrbRecentItem1"
        '
        'RibbonOrbRecentItem2
        '
        Me.RibbonOrbRecentItem2.Image = CType(resources.GetObject("RibbonOrbRecentItem2.Image"), System.Drawing.Image)
        Me.RibbonOrbRecentItem2.SmallImage = CType(resources.GetObject("RibbonOrbRecentItem2.SmallImage"), System.Drawing.Image)
        Me.RibbonOrbRecentItem2.Text = "RibbonOrbRecentItem2"
        '
        'RibbonOrbMenuItem1
        '
        Me.RibbonOrbMenuItem1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.RibbonOrbMenuItem1.Image = CType(resources.GetObject("RibbonOrbMenuItem1.Image"), System.Drawing.Image)
        Me.RibbonOrbMenuItem1.SmallImage = CType(resources.GetObject("RibbonOrbMenuItem1.SmallImage"), System.Drawing.Image)
        Me.RibbonOrbMenuItem1.Text = "RibbonOrbMenuItem1"
        '
        'RibbonOrbMenuItem2
        '
        Me.RibbonOrbMenuItem2.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.RibbonOrbMenuItem2.Image = CType(resources.GetObject("RibbonOrbMenuItem2.Image"), System.Drawing.Image)
        Me.RibbonOrbMenuItem2.SmallImage = CType(resources.GetObject("RibbonOrbMenuItem2.SmallImage"), System.Drawing.Image)
        Me.RibbonOrbMenuItem2.Text = "RibbonOrbMenuItem2"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(928, 865)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Ribbon1)
        Me.Controls.Add(Me.NaviBar1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.NaviBar1.ResumeLayout(False)
        Me.NaviBand2.ClientArea.ResumeLayout(False)
        Me.NaviBand2.ResumeLayout(False)
        Me.NaviBand1.ClientArea.ResumeLayout(False)
        Me.NaviBand1.ResumeLayout(False)
        CType(Me.NaviGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NaviGroup1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFile As OpenFileDialog
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents ListView1 As ListView
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents Printview As PrintPreviewDialog
    Friend WithEvents ImportDirDialog As FolderBrowserDialog
    Friend WithEvents dirPath As ToolStripStatusLabel
    Friend WithEvents PdfOpen As OpenFileDialog
    Friend WithEvents NaviBar1 As Guifreaks.Navisuite.NaviBar
    Friend WithEvents NaviBand2 As Guifreaks.Navisuite.NaviBand
    Friend WithEvents NaviBand1 As Guifreaks.Navisuite.NaviBand
    Friend WithEvents NaviGroup1 As Guifreaks.Navisuite.NaviGroup
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Ribbon1 As Ribbon
    Friend WithEvents RibbonTab1 As RibbonTab
    Friend WithEvents RibbonPanel1 As RibbonPanel
    Friend WithEvents RibbonButton1 As RibbonButton
    Friend WithEvents RibbonButton2 As RibbonButton
    Friend WithEvents RibbonButton3 As RibbonButton
    Friend WithEvents RibbonPanel2 As RibbonPanel
    Friend WithEvents RibbonButton4 As RibbonButton
    Friend WithEvents RibbonButton5 As RibbonButton
    Friend WithEvents RibbonOrbOptionButton1 As RibbonOrbOptionButton
    Friend WithEvents RibbonOrbRecentItem1 As RibbonOrbRecentItem
    Friend WithEvents RibbonOrbRecentItem2 As RibbonOrbRecentItem
    Friend WithEvents RibbonOrbMenuItem1 As RibbonOrbMenuItem
    Friend WithEvents RibbonOrbMenuItem2 As RibbonOrbMenuItem
    Friend WithEvents RibbonOrbOptionButton2 As RibbonOrbOptionButton
    Friend WithEvents RibbonOrbMenuItem3 As RibbonOrbMenuItem
    Friend WithEvents RibbonPanel3 As RibbonPanel
    Friend WithEvents Rbn_ck_Editmode As RibbonCheckBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents RibbonButton6 As RibbonButton
    Friend WithEvents rbn_btn_closeimg As RibbonButton
    Friend WithEvents ListView2 As ListView
    Friend WithEvents ImageList2 As ImageList
End Class
