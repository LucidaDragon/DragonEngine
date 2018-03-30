<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ObjectBrowserWindow
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ObjectBrowserWindow))
        Me.MenuStrip = New System.Windows.Forms.ToolStrip()
        Me.ObjectView = New System.Windows.Forms.ListView()
        Me.IconList = New System.Windows.Forms.ImageList(Me.components)
        Me.AddItemDropDown = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.EditItemButton = New System.Windows.Forms.ToolStripButton()
        Me.FileDropDown = New System.Windows.Forms.ToolStripDropDownButton()
        Me.NewProjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenProjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveProjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.MenuStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileDropDown, Me.AddItemDropDown, Me.ToolStripSeparator1, Me.EditItemButton})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(966, 27)
        Me.MenuStrip.TabIndex = 0
        Me.MenuStrip.Text = "ToolStrip1"
        '
        'ObjectView
        '
        Me.ObjectView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ObjectView.Location = New System.Drawing.Point(0, 27)
        Me.ObjectView.MultiSelect = False
        Me.ObjectView.Name = "ObjectView"
        Me.ObjectView.Size = New System.Drawing.Size(966, 461)
        Me.ObjectView.SmallImageList = Me.IconList
        Me.ObjectView.TabIndex = 1
        Me.ObjectView.UseCompatibleStateImageBehavior = False
        Me.ObjectView.View = System.Windows.Forms.View.SmallIcon
        '
        'IconList
        '
        Me.IconList.ImageStream = CType(resources.GetObject("IconList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.IconList.TransparentColor = System.Drawing.Color.Transparent
        Me.IconList.Images.SetKeyName(0, "arrowDown.png")
        Me.IconList.Images.SetKeyName(1, "arrowLeft.png")
        Me.IconList.Images.SetKeyName(2, "arrowRight.png")
        Me.IconList.Images.SetKeyName(3, "arrowUp.png")
        Me.IconList.Images.SetKeyName(4, "audioOff.png")
        Me.IconList.Images.SetKeyName(5, "audioOn.png")
        Me.IconList.Images.SetKeyName(6, "barsHorizontal.png")
        Me.IconList.Images.SetKeyName(7, "barsVertical.png")
        Me.IconList.Images.SetKeyName(8, "button1.png")
        Me.IconList.Images.SetKeyName(9, "button2.png")
        Me.IconList.Images.SetKeyName(10, "button3.png")
        Me.IconList.Images.SetKeyName(11, "buttonA.png")
        Me.IconList.Images.SetKeyName(12, "buttonB.png")
        Me.IconList.Images.SetKeyName(13, "buttonL.png")
        Me.IconList.Images.SetKeyName(14, "buttonL1.png")
        Me.IconList.Images.SetKeyName(15, "buttonL2.png")
        Me.IconList.Images.SetKeyName(16, "buttonR.png")
        Me.IconList.Images.SetKeyName(17, "buttonR1.png")
        Me.IconList.Images.SetKeyName(18, "buttonR2.png")
        Me.IconList.Images.SetKeyName(19, "buttonSelect.png")
        Me.IconList.Images.SetKeyName(20, "buttonStart.png")
        Me.IconList.Images.SetKeyName(21, "buttonX.png")
        Me.IconList.Images.SetKeyName(22, "buttonY.png")
        Me.IconList.Images.SetKeyName(23, "checkmark.png")
        Me.IconList.Images.SetKeyName(24, "contrast.png")
        Me.IconList.Images.SetKeyName(25, "cross.png")
        Me.IconList.Images.SetKeyName(26, "down.png")
        Me.IconList.Images.SetKeyName(27, "downLeft.png")
        Me.IconList.Images.SetKeyName(28, "downRight.png")
        Me.IconList.Images.SetKeyName(29, "DragonIcon.ico")
        Me.IconList.Images.SetKeyName(30, "DragonIcon.png")
        Me.IconList.Images.SetKeyName(31, "exclamation.png")
        Me.IconList.Images.SetKeyName(32, "exit.png")
        Me.IconList.Images.SetKeyName(33, "exitLeft.png")
        Me.IconList.Images.SetKeyName(34, "exitRight.png")
        Me.IconList.Images.SetKeyName(35, "export.png")
        Me.IconList.Images.SetKeyName(36, "fastForward.png")
        Me.IconList.Images.SetKeyName(37, "gamepad.png")
        Me.IconList.Images.SetKeyName(38, "gamepad1.png")
        Me.IconList.Images.SetKeyName(39, "gamepad2.png")
        Me.IconList.Images.SetKeyName(40, "gamepad3.png")
        Me.IconList.Images.SetKeyName(41, "gamepad4.png")
        Me.IconList.Images.SetKeyName(42, "gear.png")
        Me.IconList.Images.SetKeyName(43, "home.png")
        Me.IconList.Images.SetKeyName(44, "import.png")
        Me.IconList.Images.SetKeyName(45, "information.png")
        Me.IconList.Images.SetKeyName(46, "joystick.png")
        Me.IconList.Images.SetKeyName(47, "joystickLeft.png")
        Me.IconList.Images.SetKeyName(48, "joystickRight.png")
        Me.IconList.Images.SetKeyName(49, "joystickUp.png")
        Me.IconList.Images.SetKeyName(50, "larger.png")
        Me.IconList.Images.SetKeyName(51, "leaderboardsComplex.png")
        Me.IconList.Images.SetKeyName(52, "leaderboardsSimple.png")
        Me.IconList.Images.SetKeyName(53, "left.png")
        Me.IconList.Images.SetKeyName(54, "locked.png")
        Me.IconList.Images.SetKeyName(55, "massiveMultiplayer.png")
        Me.IconList.Images.SetKeyName(56, "medal1.png")
        Me.IconList.Images.SetKeyName(57, "medal2.png")
        Me.IconList.Images.SetKeyName(58, "menuGrid.png")
        Me.IconList.Images.SetKeyName(59, "menuList.png")
        Me.IconList.Images.SetKeyName(60, "minus.png")
        Me.IconList.Images.SetKeyName(61, "mouse.png")
        Me.IconList.Images.SetKeyName(62, "movie.png")
        Me.IconList.Images.SetKeyName(63, "multiplayer.png")
        Me.IconList.Images.SetKeyName(64, "musicOff.png")
        Me.IconList.Images.SetKeyName(65, "musicOn.png")
        Me.IconList.Images.SetKeyName(66, "next.png")
        Me.IconList.Images.SetKeyName(67, "open.png")
        Me.IconList.Images.SetKeyName(68, "pause.png")
        Me.IconList.Images.SetKeyName(69, "phone.png")
        Me.IconList.Images.SetKeyName(70, "plus.png")
        Me.IconList.Images.SetKeyName(71, "power.png")
        Me.IconList.Images.SetKeyName(72, "previous.png")
        Me.IconList.Images.SetKeyName(73, "question.png")
        Me.IconList.Images.SetKeyName(74, "return.png")
        Me.IconList.Images.SetKeyName(75, "rewind.png")
        Me.IconList.Images.SetKeyName(76, "right.png")
        Me.IconList.Images.SetKeyName(77, "save.png")
        Me.IconList.Images.SetKeyName(78, "scrollHorizontal.png")
        Me.IconList.Images.SetKeyName(79, "scrollVertical.png")
        Me.IconList.Images.SetKeyName(80, "share1.png")
        Me.IconList.Images.SetKeyName(81, "share2.png")
        Me.IconList.Images.SetKeyName(82, "shoppingBasket.png")
        Me.IconList.Images.SetKeyName(83, "shoppingCart.png")
        Me.IconList.Images.SetKeyName(84, "siganl1.png")
        Me.IconList.Images.SetKeyName(85, "signal2.png")
        Me.IconList.Images.SetKeyName(86, "signal3.png")
        Me.IconList.Images.SetKeyName(87, "singleplayer.png")
        Me.IconList.Images.SetKeyName(88, "smaller.png")
        Me.IconList.Images.SetKeyName(89, "star.png")
        Me.IconList.Images.SetKeyName(90, "stop.png")
        Me.IconList.Images.SetKeyName(91, "tablet.png")
        Me.IconList.Images.SetKeyName(92, "target.png")
        Me.IconList.Images.SetKeyName(93, "trashcan.png")
        Me.IconList.Images.SetKeyName(94, "trashcanOpen.png")
        Me.IconList.Images.SetKeyName(95, "trophy.png")
        Me.IconList.Images.SetKeyName(96, "unlocked.png")
        Me.IconList.Images.SetKeyName(97, "up.png")
        Me.IconList.Images.SetKeyName(98, "upLeft.png")
        Me.IconList.Images.SetKeyName(99, "upRight.png")
        Me.IconList.Images.SetKeyName(100, "video.png")
        Me.IconList.Images.SetKeyName(101, "warning.png")
        Me.IconList.Images.SetKeyName(102, "wrench.png")
        Me.IconList.Images.SetKeyName(103, "zoom.png")
        Me.IconList.Images.SetKeyName(104, "zoomDefault.png")
        Me.IconList.Images.SetKeyName(105, "zoomIn.png")
        Me.IconList.Images.SetKeyName(106, "zoomOut.png")
        '
        'AddItemDropDown
        '
        Me.AddItemDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.AddItemDropDown.Image = CType(resources.GetObject("AddItemDropDown.Image"), System.Drawing.Image)
        Me.AddItemDropDown.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AddItemDropDown.Name = "AddItemDropDown"
        Me.AddItemDropDown.Size = New System.Drawing.Size(51, 24)
        Me.AddItemDropDown.Text = "Add"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 27)
        '
        'EditItemButton
        '
        Me.EditItemButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.EditItemButton.Enabled = False
        Me.EditItemButton.Image = CType(resources.GetObject("EditItemButton.Image"), System.Drawing.Image)
        Me.EditItemButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EditItemButton.Name = "EditItemButton"
        Me.EditItemButton.Size = New System.Drawing.Size(39, 24)
        Me.EditItemButton.Text = "Edit"
        '
        'FileDropDown
        '
        Me.FileDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.FileDropDown.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewProjectToolStripMenuItem, Me.OpenProjectToolStripMenuItem, Me.SaveProjectToolStripMenuItem})
        Me.FileDropDown.Image = CType(resources.GetObject("FileDropDown.Image"), System.Drawing.Image)
        Me.FileDropDown.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.FileDropDown.Name = "FileDropDown"
        Me.FileDropDown.Size = New System.Drawing.Size(46, 24)
        Me.FileDropDown.Text = "File"
        '
        'NewProjectToolStripMenuItem
        '
        Me.NewProjectToolStripMenuItem.Name = "NewProjectToolStripMenuItem"
        Me.NewProjectToolStripMenuItem.Size = New System.Drawing.Size(181, 26)
        Me.NewProjectToolStripMenuItem.Text = "New Project"
        '
        'OpenProjectToolStripMenuItem
        '
        Me.OpenProjectToolStripMenuItem.Name = "OpenProjectToolStripMenuItem"
        Me.OpenProjectToolStripMenuItem.Size = New System.Drawing.Size(181, 26)
        Me.OpenProjectToolStripMenuItem.Text = "Open Project"
        '
        'SaveProjectToolStripMenuItem
        '
        Me.SaveProjectToolStripMenuItem.Name = "SaveProjectToolStripMenuItem"
        Me.SaveProjectToolStripMenuItem.Size = New System.Drawing.Size(181, 26)
        Me.SaveProjectToolStripMenuItem.Text = "Save Project"
        '
        'ObjectBrowserWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(966, 488)
        Me.Controls.Add(Me.ObjectView)
        Me.Controls.Add(Me.MenuStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ObjectBrowserWindow"
        Me.Text = "Dragon Engine Object Browser"
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip As ToolStrip
    Friend WithEvents ObjectView As ListView
    Friend WithEvents IconList As ImageList
    Friend WithEvents AddItemDropDown As ToolStripDropDownButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents EditItemButton As ToolStripButton
    Friend WithEvents FileDropDown As ToolStripDropDownButton
    Friend WithEvents NewProjectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenProjectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveProjectToolStripMenuItem As ToolStripMenuItem
End Class
