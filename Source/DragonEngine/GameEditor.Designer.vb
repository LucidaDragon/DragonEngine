<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GameEditor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GameEditor))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.PropertyGrid1 = New System.Windows.Forms.PropertyGrid()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2, Me.ToolStripSeparator1, Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(837, 27)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 27)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(38, 24)
        Me.ToolStripButton1.Text = "Run"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 27)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ListView1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.PropertyGrid1)
        Me.SplitContainer1.Size = New System.Drawing.Size(837, 425)
        Me.SplitContainer1.SplitterDistance = 393
        Me.SplitContainer1.TabIndex = 1
        '
        'ListView1
        '
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.LargeImageList = Me.ImageList2
        Me.ListView1.Location = New System.Drawing.Point(0, 0)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(393, 425)
        Me.ListView1.SmallImageList = Me.ImageList1
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "arrowDown.png")
        Me.ImageList2.Images.SetKeyName(1, "arrowLeft.png")
        Me.ImageList2.Images.SetKeyName(2, "arrowRight.png")
        Me.ImageList2.Images.SetKeyName(3, "arrowUp.png")
        Me.ImageList2.Images.SetKeyName(4, "audioOff.png")
        Me.ImageList2.Images.SetKeyName(5, "audioOn.png")
        Me.ImageList2.Images.SetKeyName(6, "barsHorizontal.png")
        Me.ImageList2.Images.SetKeyName(7, "barsVertical.png")
        Me.ImageList2.Images.SetKeyName(8, "button1.png")
        Me.ImageList2.Images.SetKeyName(9, "button2.png")
        Me.ImageList2.Images.SetKeyName(10, "button3.png")
        Me.ImageList2.Images.SetKeyName(11, "buttonA.png")
        Me.ImageList2.Images.SetKeyName(12, "buttonB.png")
        Me.ImageList2.Images.SetKeyName(13, "buttonL.png")
        Me.ImageList2.Images.SetKeyName(14, "buttonL1.png")
        Me.ImageList2.Images.SetKeyName(15, "buttonL2.png")
        Me.ImageList2.Images.SetKeyName(16, "buttonR.png")
        Me.ImageList2.Images.SetKeyName(17, "buttonR1.png")
        Me.ImageList2.Images.SetKeyName(18, "buttonR2.png")
        Me.ImageList2.Images.SetKeyName(19, "buttonSelect.png")
        Me.ImageList2.Images.SetKeyName(20, "buttonStart.png")
        Me.ImageList2.Images.SetKeyName(21, "buttonX.png")
        Me.ImageList2.Images.SetKeyName(22, "buttonY.png")
        Me.ImageList2.Images.SetKeyName(23, "checkmark.png")
        Me.ImageList2.Images.SetKeyName(24, "contrast.png")
        Me.ImageList2.Images.SetKeyName(25, "cross.png")
        Me.ImageList2.Images.SetKeyName(26, "down.png")
        Me.ImageList2.Images.SetKeyName(27, "downLeft.png")
        Me.ImageList2.Images.SetKeyName(28, "downRight.png")
        Me.ImageList2.Images.SetKeyName(29, "DragonIcon.ico")
        Me.ImageList2.Images.SetKeyName(30, "DragonIcon.png")
        Me.ImageList2.Images.SetKeyName(31, "exclamation.png")
        Me.ImageList2.Images.SetKeyName(32, "exit.png")
        Me.ImageList2.Images.SetKeyName(33, "exitLeft.png")
        Me.ImageList2.Images.SetKeyName(34, "exitRight.png")
        Me.ImageList2.Images.SetKeyName(35, "export.png")
        Me.ImageList2.Images.SetKeyName(36, "fastForward.png")
        Me.ImageList2.Images.SetKeyName(37, "gamepad.png")
        Me.ImageList2.Images.SetKeyName(38, "gamepad1.png")
        Me.ImageList2.Images.SetKeyName(39, "gamepad2.png")
        Me.ImageList2.Images.SetKeyName(40, "gamepad3.png")
        Me.ImageList2.Images.SetKeyName(41, "gamepad4.png")
        Me.ImageList2.Images.SetKeyName(42, "gear.png")
        Me.ImageList2.Images.SetKeyName(43, "home.png")
        Me.ImageList2.Images.SetKeyName(44, "import.png")
        Me.ImageList2.Images.SetKeyName(45, "information.png")
        Me.ImageList2.Images.SetKeyName(46, "joystick.png")
        Me.ImageList2.Images.SetKeyName(47, "joystickLeft.png")
        Me.ImageList2.Images.SetKeyName(48, "joystickRight.png")
        Me.ImageList2.Images.SetKeyName(49, "joystickUp.png")
        Me.ImageList2.Images.SetKeyName(50, "larger.png")
        Me.ImageList2.Images.SetKeyName(51, "leaderboardsComplex.png")
        Me.ImageList2.Images.SetKeyName(52, "leaderboardsSimple.png")
        Me.ImageList2.Images.SetKeyName(53, "left.png")
        Me.ImageList2.Images.SetKeyName(54, "locked.png")
        Me.ImageList2.Images.SetKeyName(55, "massiveMultiplayer.png")
        Me.ImageList2.Images.SetKeyName(56, "medal1.png")
        Me.ImageList2.Images.SetKeyName(57, "medal2.png")
        Me.ImageList2.Images.SetKeyName(58, "menuGrid.png")
        Me.ImageList2.Images.SetKeyName(59, "menuList.png")
        Me.ImageList2.Images.SetKeyName(60, "minus.png")
        Me.ImageList2.Images.SetKeyName(61, "mouse.png")
        Me.ImageList2.Images.SetKeyName(62, "movie.png")
        Me.ImageList2.Images.SetKeyName(63, "multiplayer.png")
        Me.ImageList2.Images.SetKeyName(64, "musicOff.png")
        Me.ImageList2.Images.SetKeyName(65, "musicOn.png")
        Me.ImageList2.Images.SetKeyName(66, "next.png")
        Me.ImageList2.Images.SetKeyName(67, "open.png")
        Me.ImageList2.Images.SetKeyName(68, "pause.png")
        Me.ImageList2.Images.SetKeyName(69, "phone.png")
        Me.ImageList2.Images.SetKeyName(70, "plus.png")
        Me.ImageList2.Images.SetKeyName(71, "power.png")
        Me.ImageList2.Images.SetKeyName(72, "previous.png")
        Me.ImageList2.Images.SetKeyName(73, "question.png")
        Me.ImageList2.Images.SetKeyName(74, "return.png")
        Me.ImageList2.Images.SetKeyName(75, "rewind.png")
        Me.ImageList2.Images.SetKeyName(76, "right.png")
        Me.ImageList2.Images.SetKeyName(77, "save.png")
        Me.ImageList2.Images.SetKeyName(78, "scrollHorizontal.png")
        Me.ImageList2.Images.SetKeyName(79, "scrollVertical.png")
        Me.ImageList2.Images.SetKeyName(80, "share1.png")
        Me.ImageList2.Images.SetKeyName(81, "share2.png")
        Me.ImageList2.Images.SetKeyName(82, "shoppingBasket.png")
        Me.ImageList2.Images.SetKeyName(83, "shoppingCart.png")
        Me.ImageList2.Images.SetKeyName(84, "siganl1.png")
        Me.ImageList2.Images.SetKeyName(85, "signal2.png")
        Me.ImageList2.Images.SetKeyName(86, "signal3.png")
        Me.ImageList2.Images.SetKeyName(87, "singleplayer.png")
        Me.ImageList2.Images.SetKeyName(88, "smaller.png")
        Me.ImageList2.Images.SetKeyName(89, "star.png")
        Me.ImageList2.Images.SetKeyName(90, "stop.png")
        Me.ImageList2.Images.SetKeyName(91, "tablet.png")
        Me.ImageList2.Images.SetKeyName(92, "target.png")
        Me.ImageList2.Images.SetKeyName(93, "trashcan.png")
        Me.ImageList2.Images.SetKeyName(94, "trashcanOpen.png")
        Me.ImageList2.Images.SetKeyName(95, "trophy.png")
        Me.ImageList2.Images.SetKeyName(96, "unlocked.png")
        Me.ImageList2.Images.SetKeyName(97, "up.png")
        Me.ImageList2.Images.SetKeyName(98, "upLeft.png")
        Me.ImageList2.Images.SetKeyName(99, "upRight.png")
        Me.ImageList2.Images.SetKeyName(100, "video.png")
        Me.ImageList2.Images.SetKeyName(101, "warning.png")
        Me.ImageList2.Images.SetKeyName(102, "wrench.png")
        Me.ImageList2.Images.SetKeyName(103, "zoom.png")
        Me.ImageList2.Images.SetKeyName(104, "zoomDefault.png")
        Me.ImageList2.Images.SetKeyName(105, "zoomIn.png")
        Me.ImageList2.Images.SetKeyName(106, "zoomOut.png")
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "arrowDown.png")
        Me.ImageList1.Images.SetKeyName(1, "arrowLeft.png")
        Me.ImageList1.Images.SetKeyName(2, "arrowRight.png")
        Me.ImageList1.Images.SetKeyName(3, "arrowUp.png")
        Me.ImageList1.Images.SetKeyName(4, "audioOff.png")
        Me.ImageList1.Images.SetKeyName(5, "audioOn.png")
        Me.ImageList1.Images.SetKeyName(6, "barsHorizontal.png")
        Me.ImageList1.Images.SetKeyName(7, "barsVertical.png")
        Me.ImageList1.Images.SetKeyName(8, "button1.png")
        Me.ImageList1.Images.SetKeyName(9, "button2.png")
        Me.ImageList1.Images.SetKeyName(10, "button3.png")
        Me.ImageList1.Images.SetKeyName(11, "buttonA.png")
        Me.ImageList1.Images.SetKeyName(12, "buttonB.png")
        Me.ImageList1.Images.SetKeyName(13, "buttonL.png")
        Me.ImageList1.Images.SetKeyName(14, "buttonL1.png")
        Me.ImageList1.Images.SetKeyName(15, "buttonL2.png")
        Me.ImageList1.Images.SetKeyName(16, "buttonR.png")
        Me.ImageList1.Images.SetKeyName(17, "buttonR1.png")
        Me.ImageList1.Images.SetKeyName(18, "buttonR2.png")
        Me.ImageList1.Images.SetKeyName(19, "buttonSelect.png")
        Me.ImageList1.Images.SetKeyName(20, "buttonStart.png")
        Me.ImageList1.Images.SetKeyName(21, "buttonX.png")
        Me.ImageList1.Images.SetKeyName(22, "buttonY.png")
        Me.ImageList1.Images.SetKeyName(23, "checkmark.png")
        Me.ImageList1.Images.SetKeyName(24, "contrast.png")
        Me.ImageList1.Images.SetKeyName(25, "cross.png")
        Me.ImageList1.Images.SetKeyName(26, "down.png")
        Me.ImageList1.Images.SetKeyName(27, "downLeft.png")
        Me.ImageList1.Images.SetKeyName(28, "downRight.png")
        Me.ImageList1.Images.SetKeyName(29, "DragonIcon.ico")
        Me.ImageList1.Images.SetKeyName(30, "DragonIcon.png")
        Me.ImageList1.Images.SetKeyName(31, "exclamation.png")
        Me.ImageList1.Images.SetKeyName(32, "exit.png")
        Me.ImageList1.Images.SetKeyName(33, "exitLeft.png")
        Me.ImageList1.Images.SetKeyName(34, "exitRight.png")
        Me.ImageList1.Images.SetKeyName(35, "export.png")
        Me.ImageList1.Images.SetKeyName(36, "fastForward.png")
        Me.ImageList1.Images.SetKeyName(37, "gamepad.png")
        Me.ImageList1.Images.SetKeyName(38, "gamepad1.png")
        Me.ImageList1.Images.SetKeyName(39, "gamepad2.png")
        Me.ImageList1.Images.SetKeyName(40, "gamepad3.png")
        Me.ImageList1.Images.SetKeyName(41, "gamepad4.png")
        Me.ImageList1.Images.SetKeyName(42, "gear.png")
        Me.ImageList1.Images.SetKeyName(43, "home.png")
        Me.ImageList1.Images.SetKeyName(44, "import.png")
        Me.ImageList1.Images.SetKeyName(45, "information.png")
        Me.ImageList1.Images.SetKeyName(46, "joystick.png")
        Me.ImageList1.Images.SetKeyName(47, "joystickLeft.png")
        Me.ImageList1.Images.SetKeyName(48, "joystickRight.png")
        Me.ImageList1.Images.SetKeyName(49, "joystickUp.png")
        Me.ImageList1.Images.SetKeyName(50, "larger.png")
        Me.ImageList1.Images.SetKeyName(51, "leaderboardsComplex.png")
        Me.ImageList1.Images.SetKeyName(52, "leaderboardsSimple.png")
        Me.ImageList1.Images.SetKeyName(53, "left.png")
        Me.ImageList1.Images.SetKeyName(54, "locked.png")
        Me.ImageList1.Images.SetKeyName(55, "massiveMultiplayer.png")
        Me.ImageList1.Images.SetKeyName(56, "medal1.png")
        Me.ImageList1.Images.SetKeyName(57, "medal2.png")
        Me.ImageList1.Images.SetKeyName(58, "menuGrid.png")
        Me.ImageList1.Images.SetKeyName(59, "menuList.png")
        Me.ImageList1.Images.SetKeyName(60, "minus.png")
        Me.ImageList1.Images.SetKeyName(61, "mouse.png")
        Me.ImageList1.Images.SetKeyName(62, "movie.png")
        Me.ImageList1.Images.SetKeyName(63, "multiplayer.png")
        Me.ImageList1.Images.SetKeyName(64, "musicOff.png")
        Me.ImageList1.Images.SetKeyName(65, "musicOn.png")
        Me.ImageList1.Images.SetKeyName(66, "next.png")
        Me.ImageList1.Images.SetKeyName(67, "open.png")
        Me.ImageList1.Images.SetKeyName(68, "pause.png")
        Me.ImageList1.Images.SetKeyName(69, "phone.png")
        Me.ImageList1.Images.SetKeyName(70, "plus.png")
        Me.ImageList1.Images.SetKeyName(71, "power.png")
        Me.ImageList1.Images.SetKeyName(72, "previous.png")
        Me.ImageList1.Images.SetKeyName(73, "question.png")
        Me.ImageList1.Images.SetKeyName(74, "return.png")
        Me.ImageList1.Images.SetKeyName(75, "rewind.png")
        Me.ImageList1.Images.SetKeyName(76, "right.png")
        Me.ImageList1.Images.SetKeyName(77, "save.png")
        Me.ImageList1.Images.SetKeyName(78, "scrollHorizontal.png")
        Me.ImageList1.Images.SetKeyName(79, "scrollVertical.png")
        Me.ImageList1.Images.SetKeyName(80, "share1.png")
        Me.ImageList1.Images.SetKeyName(81, "share2.png")
        Me.ImageList1.Images.SetKeyName(82, "shoppingBasket.png")
        Me.ImageList1.Images.SetKeyName(83, "shoppingCart.png")
        Me.ImageList1.Images.SetKeyName(84, "siganl1.png")
        Me.ImageList1.Images.SetKeyName(85, "signal2.png")
        Me.ImageList1.Images.SetKeyName(86, "signal3.png")
        Me.ImageList1.Images.SetKeyName(87, "singleplayer.png")
        Me.ImageList1.Images.SetKeyName(88, "smaller.png")
        Me.ImageList1.Images.SetKeyName(89, "star.png")
        Me.ImageList1.Images.SetKeyName(90, "stop.png")
        Me.ImageList1.Images.SetKeyName(91, "tablet.png")
        Me.ImageList1.Images.SetKeyName(92, "target.png")
        Me.ImageList1.Images.SetKeyName(93, "trashcan.png")
        Me.ImageList1.Images.SetKeyName(94, "trashcanOpen.png")
        Me.ImageList1.Images.SetKeyName(95, "trophy.png")
        Me.ImageList1.Images.SetKeyName(96, "unlocked.png")
        Me.ImageList1.Images.SetKeyName(97, "up.png")
        Me.ImageList1.Images.SetKeyName(98, "upLeft.png")
        Me.ImageList1.Images.SetKeyName(99, "upRight.png")
        Me.ImageList1.Images.SetKeyName(100, "video.png")
        Me.ImageList1.Images.SetKeyName(101, "warning.png")
        Me.ImageList1.Images.SetKeyName(102, "wrench.png")
        Me.ImageList1.Images.SetKeyName(103, "zoom.png")
        Me.ImageList1.Images.SetKeyName(104, "zoomDefault.png")
        Me.ImageList1.Images.SetKeyName(105, "zoomIn.png")
        Me.ImageList1.Images.SetKeyName(106, "zoomOut.png")
        '
        'PropertyGrid1
        '
        Me.PropertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PropertyGrid1.Location = New System.Drawing.Point(0, 0)
        Me.PropertyGrid1.Name = "PropertyGrid1"
        Me.PropertyGrid1.Size = New System.Drawing.Size(440, 425)
        Me.PropertyGrid1.TabIndex = 0
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(51, 24)
        Me.ToolStripButton2.Text = "Add"
        '
        'GameEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(837, 452)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "GameEditor"
        Me.Text = "Dragon Engine - Editor"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ImageList2 As ImageList
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents PropertyGrid1 As PropertyGrid
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripButton2 As ToolStripDropDownButton
End Class
