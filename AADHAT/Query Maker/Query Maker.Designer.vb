<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Query_Maker
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
        Me.RtxtQuery = New System.Windows.Forms.RichTextBox()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'RtxtQuery
        '
        Me.RtxtQuery.Location = New System.Drawing.Point(36, 27)
        Me.RtxtQuery.Name = "RtxtQuery"
        Me.RtxtQuery.Size = New System.Drawing.Size(509, 299)
        Me.RtxtQuery.TabIndex = 0
        Me.RtxtQuery.Text = ""
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.Black
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.ForeColor = System.Drawing.Color.GhostWhite
        Me.BtnSave.Location = New System.Drawing.Point(390, 332)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(155, 37)
        Me.BtnSave.TabIndex = 40139
        Me.BtnSave.Text = "&Run Query"
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'Query_Maker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(631, 408)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.RtxtQuery)
        Me.Name = "Query_Maker"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Query Maker"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RtxtQuery As System.Windows.Forms.RichTextBox
    Friend WithEvents BtnSave As System.Windows.Forms.Button
End Class
