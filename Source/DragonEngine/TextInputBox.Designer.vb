<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TextInputBox
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TextInputBox))
        Me.InputTextBox = New System.Windows.Forms.TextBox()
        Me.CancelSubmitButton = New System.Windows.Forms.Button()
        Me.OkSubmitButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'InputTextBox
        '
        Me.InputTextBox.Location = New System.Drawing.Point(12, 12)
        Me.InputTextBox.Name = "InputTextBox"
        Me.InputTextBox.Size = New System.Drawing.Size(517, 22)
        Me.InputTextBox.TabIndex = 0
        '
        'CancelSubmitButton
        '
        Me.CancelSubmitButton.Location = New System.Drawing.Point(440, 40)
        Me.CancelSubmitButton.Name = "CancelSubmitButton"
        Me.CancelSubmitButton.Size = New System.Drawing.Size(89, 27)
        Me.CancelSubmitButton.TabIndex = 1
        Me.CancelSubmitButton.Text = "Cancel"
        Me.CancelSubmitButton.UseVisualStyleBackColor = True
        '
        'OkSubmitButton
        '
        Me.OkSubmitButton.Location = New System.Drawing.Point(345, 40)
        Me.OkSubmitButton.Name = "OkSubmitButton"
        Me.OkSubmitButton.Size = New System.Drawing.Size(89, 27)
        Me.OkSubmitButton.TabIndex = 2
        Me.OkSubmitButton.Text = "OK"
        Me.OkSubmitButton.UseVisualStyleBackColor = True
        '
        'TextInputBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(541, 79)
        Me.Controls.Add(Me.OkSubmitButton)
        Me.Controls.Add(Me.CancelSubmitButton)
        Me.Controls.Add(Me.InputTextBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "TextInputBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Input Text"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents InputTextBox As TextBox
    Friend WithEvents CancelSubmitButton As Button
    Friend WithEvents OkSubmitButton As Button
End Class
