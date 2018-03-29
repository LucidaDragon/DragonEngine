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
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(966, 25)
        Me.MenuStrip.TabIndex = 0
        Me.MenuStrip.Text = "ToolStrip1"
        '
        'ObjectView
        '
        Me.ObjectView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ObjectView.Location = New System.Drawing.Point(0, 25)
        Me.ObjectView.Name = "ObjectView"
        Me.ObjectView.Size = New System.Drawing.Size(966, 463)
        Me.ObjectView.TabIndex = 1
        Me.ObjectView.UseCompatibleStateImageBehavior = False
        '
        'IconList
        '
        Me.IconList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.IconList.ImageSize = New System.Drawing.Size(16, 16)
        Me.IconList.TransparentColor = System.Drawing.Color.Transparent
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
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip As ToolStrip
    Friend WithEvents ObjectView As ListView
    Friend WithEvents IconList As ImageList
End Class
