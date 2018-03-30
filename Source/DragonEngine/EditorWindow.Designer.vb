<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditorWindow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditorWindow))
        Me.SplitDesigner = New System.Windows.Forms.SplitContainer()
        Me.ObjectPropertyGrid = New System.Windows.Forms.PropertyGrid()
        CType(Me.SplitDesigner, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitDesigner.Panel1.SuspendLayout()
        Me.SplitDesigner.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitDesigner
        '
        Me.SplitDesigner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitDesigner.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitDesigner.Location = New System.Drawing.Point(0, 0)
        Me.SplitDesigner.Name = "SplitDesigner"
        '
        'SplitDesigner.Panel1
        '
        Me.SplitDesigner.Panel1.Controls.Add(Me.ObjectPropertyGrid)
        Me.SplitDesigner.Size = New System.Drawing.Size(900, 479)
        Me.SplitDesigner.SplitterDistance = 330
        Me.SplitDesigner.TabIndex = 0
        '
        'ObjectPropertyGrid
        '
        Me.ObjectPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ObjectPropertyGrid.Location = New System.Drawing.Point(0, 0)
        Me.ObjectPropertyGrid.Name = "ObjectPropertyGrid"
        Me.ObjectPropertyGrid.Size = New System.Drawing.Size(328, 477)
        Me.ObjectPropertyGrid.TabIndex = 0
        '
        'EditorWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(900, 479)
        Me.Controls.Add(Me.SplitDesigner)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "EditorWindow"
        Me.Text = "Dragon Engine Editor"
        Me.SplitDesigner.Panel1.ResumeLayout(False)
        CType(Me.SplitDesigner, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitDesigner.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitDesigner As SplitContainer
    Friend WithEvents ObjectPropertyGrid As PropertyGrid
End Class
