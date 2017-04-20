<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HelsepersonellMinSide
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
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(12, 32)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(436, 134)
        Me.ListBox1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "folk som venter på legetime"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(454, 62)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(181, 67)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Godkjenn legetime"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(454, 243)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(181, 67)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Registrer blodtapping"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(650, 62)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(181, 67)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Bestill Blodprodukter"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 182)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(135, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "folk som venter på tapping."
        '
        'ListBox2
        '
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.Location = New System.Drawing.Point(12, 198)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(436, 147)
        Me.ListBox2.TabIndex = 7
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(454, 409)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(181, 72)
        Me.Button4.TabIndex = 9
        Me.Button4.Text = "Kall inn folk for blodtapping"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(650, 409)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(181, 72)
        Me.Button5.TabIndex = 10
        Me.Button5.Text = "Kriseblod"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'HelsepersonellMinSide
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(843, 557)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.ListBox2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListBox1)
        Me.Name = "HelsepersonellMinSide"
        Me.Text = "HelsepersonellMinSide"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents ListBox2 As ListBox
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
End Class
