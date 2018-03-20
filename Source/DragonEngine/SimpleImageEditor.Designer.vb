<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SimpleImageEditor
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UndoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZoomInToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZoomOutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetZoomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ColorToolStripMenuItem, Me.UndoToolStripMenuItem, Me.ZoomInToolStripMenuItem, Me.ZoomOutToolStripMenuItem, Me.ResetZoomToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(176, 152)
        '
        'ColorToolStripMenuItem
        '
        Me.ColorToolStripMenuItem.Name = "ColorToolStripMenuItem"
        Me.ColorToolStripMenuItem.Size = New System.Drawing.Size(175, 24)
        Me.ColorToolStripMenuItem.Text = "Color"
        '
        'UndoToolStripMenuItem
        '
        Me.UndoToolStripMenuItem.Name = "UndoToolStripMenuItem"
        Me.UndoToolStripMenuItem.Size = New System.Drawing.Size(175, 24)
        Me.UndoToolStripMenuItem.Text = "Undo"
        '
        'ZoomInToolStripMenuItem
        '
        Me.ZoomInToolStripMenuItem.Name = "ZoomInToolStripMenuItem"
        Me.ZoomInToolStripMenuItem.Size = New System.Drawing.Size(175, 24)
        Me.ZoomInToolStripMenuItem.Text = "Zoom In"
        '
        'ZoomOutToolStripMenuItem
        '
        Me.ZoomOutToolStripMenuItem.Name = "ZoomOutToolStripMenuItem"
        Me.ZoomOutToolStripMenuItem.Size = New System.Drawing.Size(175, 24)
        Me.ZoomOutToolStripMenuItem.Text = "Zoom Out"
        '
        'ResetZoomToolStripMenuItem
        '
        Me.ResetZoomToolStripMenuItem.Name = "ResetZoomToolStripMenuItem"
        Me.ResetZoomToolStripMenuItem.Size = New System.Drawing.Size(175, 24)
        Me.ResetZoomToolStripMenuItem.Text = "Reset Zoom"
        '
        'ImageEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.DoubleBuffered = True
        Me.Name = "ImageEditor"
        Me.Size = New System.Drawing.Size(402, 364)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ColorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UndoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ZoomInToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ZoomOutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResetZoomToolStripMenuItem As ToolStripMenuItem
End Class
