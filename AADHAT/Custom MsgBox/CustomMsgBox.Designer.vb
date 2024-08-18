<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomMsgBox
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
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.picIcon = New System.Windows.Forms.PictureBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.BtnYes = New System.Windows.Forms.Button()
        Me.BtnNo = New System.Windows.Forms.Button()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape2, Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(466, 174)
        Me.ShapeContainer1.TabIndex = 0
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape2
        '
        Me.LineShape2.Enabled = False
        Me.LineShape2.Name = "LineShape2"
        Me.LineShape2.X1 = 12
        Me.LineShape2.X2 = 454
        Me.LineShape2.Y1 = 119
        Me.LineShape2.Y2 = 119
        '
        'LineShape1
        '
        Me.LineShape1.BorderColor = System.Drawing.SystemColors.MenuHighlight
        Me.LineShape1.BorderWidth = 2
        Me.LineShape1.Enabled = False
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 8
        Me.LineShape1.X2 = 450
        Me.LineShape1.Y1 = 34
        Me.LineShape1.Y2 = 34
        '
        'picIcon
        '
        Me.picIcon.Enabled = False
        Me.picIcon.Image = Global.Atithi.My.Resources.Resources.warning
        Me.picIcon.Location = New System.Drawing.Point(12, 7)
        Me.picIcon.Name = "picIcon"
        Me.picIcon.Size = New System.Drawing.Size(26, 23)
        Me.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picIcon.TabIndex = 1
        Me.picIcon.TabStop = False
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnOK.FlatAppearance.BorderSize = 0
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOK.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.btnOK.ForeColor = System.Drawing.Color.White
        Me.btnOK.Location = New System.Drawing.Point(379, 131)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 32)
        Me.btnOK.TabIndex = 0
        Me.btnOK.TabStop = False
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = False
        Me.btnOK.Visible = False
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Enabled = False
        Me.lblMessage.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblMessage.Location = New System.Drawing.Point(45, 12)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(66, 17)
        Me.lblMessage.TabIndex = 0
        Me.lblMessage.Text = "Alret Msg"
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(298, 131)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 32)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.TabStop = False
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        Me.btnCancel.Visible = False
        '
        'BtnYes
        '
        Me.BtnYes.BackColor = System.Drawing.SystemColors.HotTrack
        Me.BtnYes.FlatAppearance.BorderSize = 0
        Me.BtnYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnYes.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.BtnYes.ForeColor = System.Drawing.Color.White
        Me.BtnYes.Location = New System.Drawing.Point(217, 130)
        Me.BtnYes.Name = "BtnYes"
        Me.BtnYes.Size = New System.Drawing.Size(75, 32)
        Me.BtnYes.TabIndex = 2
        Me.BtnYes.TabStop = False
        Me.BtnYes.Text = "&Yes"
        Me.BtnYes.UseVisualStyleBackColor = False
        Me.BtnYes.Visible = False
        '
        'BtnNo
        '
        Me.BtnNo.BackColor = System.Drawing.SystemColors.HotTrack
        Me.BtnNo.FlatAppearance.BorderSize = 0
        Me.BtnNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNo.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.BtnNo.ForeColor = System.Drawing.Color.White
        Me.BtnNo.Location = New System.Drawing.Point(136, 130)
        Me.BtnNo.Name = "BtnNo"
        Me.BtnNo.Size = New System.Drawing.Size(75, 32)
        Me.BtnNo.TabIndex = 3
        Me.BtnNo.TabStop = False
        Me.BtnNo.Text = "&No"
        Me.BtnNo.UseVisualStyleBackColor = False
        Me.BtnNo.Visible = False
        '
        'CustomMsgBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(466, 174)
        Me.Controls.Add(Me.BtnNo)
        Me.Controls.Add(Me.BtnYes)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.picIcon)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Name = "CustomMsgBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CustomMsgBox"
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape2 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents picIcon As System.Windows.Forms.PictureBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnYes As System.Windows.Forms.Button
    Friend WithEvents BtnNo As System.Windows.Forms.Button
End Class
