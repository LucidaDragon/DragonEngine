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
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.MenuStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddItemDropDown, Me.ToolStripSeparator1, Me.EditItemButton})
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
        Me.ObjectView.TabIndex = 1
        Me.ObjectView.UseCompatibleStateImageBehavior = False
        '
        'IconList
        '
        Me.IconList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.IconList.ImageSize = New System.Drawing.Size(16, 16)
        Me.IconList.TransparentColor = System.Drawing.Color.Transparent
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
End Class
