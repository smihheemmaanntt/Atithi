<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Taxation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Taxation))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtid = New System.Windows.Forms.TextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtGSTName = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.cbGstType = New System.Windows.Forms.ComboBox()
        Me.txtGSTPer = New System.Windows.Forms.TextBox()
        Me.txtCessper = New System.Windows.Forms.TextBox()
        Me.CbCessOn = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblCessPer = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dg1 = New System.Windows.Forms.DataGridView()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtQtyRate = New System.Windows.Forms.TextBox()
        Me.ckOnMrp = New System.Windows.Forms.CheckBox()
        Me.ckOnFree = New System.Windows.Forms.CheckBox()
        Me.lblRatePer = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtid
        '
        Me.txtid.BackColor = System.Drawing.Color.AliceBlue
        Me.txtid.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtid.ForeColor = System.Drawing.Color.Teal
        Me.txtid.Location = New System.Drawing.Point(43, 19)
        Me.txtid.Name = "txtid"
        Me.txtid.Size = New System.Drawing.Size(71, 26)
        Me.txtid.TabIndex = 21
        Me.txtid.Visible = False
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Bodoni Bk BT", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblName.ForeColor = System.Drawing.Color.Navy
        Me.lblName.Location = New System.Drawing.Point(228, 9)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(150, 32)
        Me.lblName.TabIndex = 20
        Me.lblName.Text = "TAXATION"
        '
        'txtGSTName
        '
        Me.txtGSTName.BackColor = System.Drawing.Color.GhostWhite
        Me.txtGSTName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGSTName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGSTName.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtGSTName.ForeColor = System.Drawing.Color.Black
        Me.txtGSTName.Location = New System.Drawing.Point(24, 72)
        Me.txtGSTName.Name = "txtGSTName"
        Me.txtGSTName.Size = New System.Drawing.Size(336, 27)
        Me.txtGSTName.TabIndex = 0
        Me.txtGSTName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(25, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 21)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Tax Name"
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.LightGray
        Me.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Navy
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.GhostWhite
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(554, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(50, 39)
        Me.btnClose.TabIndex = 19
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(192, 7)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(30, 30)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 91134
        Me.PictureBox1.TabStop = False
        '
        'BtnDelete
        '
        Me.BtnDelete.BackColor = System.Drawing.Color.DarkRed
        Me.BtnDelete.FlatAppearance.BorderColor = System.Drawing.Color.Navy
        Me.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDelete.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.BtnDelete.ForeColor = System.Drawing.Color.GhostWhite
        Me.BtnDelete.Image = CType(resources.GetObject("BtnDelete.Image"), System.Drawing.Image)
        Me.BtnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnDelete.Location = New System.Drawing.Point(24, 210)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(115, 31)
        Me.BtnDelete.TabIndex = 9
        Me.BtnDelete.Text = "&Delete"
        Me.BtnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnDelete.UseVisualStyleBackColor = False
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.Coral
        Me.BtnSave.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.BtnSave.ForeColor = System.Drawing.Color.GhostWhite
        'Me.BtnSave.Image = Global.Atithi.My.Resources.Resources.AddItem
        Me.BtnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSave.Location = New System.Drawing.Point(461, 210)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(115, 31)
        Me.BtnSave.TabIndex = 8
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'cbGstType
        '
        Me.cbGstType.BackColor = System.Drawing.Color.GhostWhite
        Me.cbGstType.DropDownHeight = 100
        Me.cbGstType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbGstType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbGstType.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.cbGstType.ForeColor = System.Drawing.Color.Black
        Me.cbGstType.FormattingEnabled = True
        Me.cbGstType.IntegralHeight = False
        Me.cbGstType.Items.AddRange(New Object() {"Goods", "Service"})
        Me.cbGstType.Location = New System.Drawing.Point(360, 73)
        Me.cbGstType.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cbGstType.Name = "cbGstType"
        Me.cbGstType.Size = New System.Drawing.Size(216, 25)
        Me.cbGstType.TabIndex = 1
        '
        'txtGSTPer
        '
        Me.txtGSTPer.BackColor = System.Drawing.Color.GhostWhite
        Me.txtGSTPer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGSTPer.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtGSTPer.ForeColor = System.Drawing.Color.Black
        Me.txtGSTPer.Location = New System.Drawing.Point(24, 124)
        Me.txtGSTPer.Name = "txtGSTPer"
        Me.txtGSTPer.Size = New System.Drawing.Size(90, 27)
        Me.txtGSTPer.TabIndex = 2
        Me.txtGSTPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCessper
        '
        Me.txtCessper.BackColor = System.Drawing.Color.GhostWhite
        Me.txtCessper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCessper.Enabled = False
        Me.txtCessper.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtCessper.ForeColor = System.Drawing.Color.Black
        Me.txtCessper.Location = New System.Drawing.Point(360, 124)
        Me.txtCessper.Name = "txtCessper"
        Me.txtCessper.Size = New System.Drawing.Size(102, 27)
        Me.txtCessper.TabIndex = 4
        Me.txtCessper.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CbCessOn
        '
        Me.CbCessOn.BackColor = System.Drawing.Color.GhostWhite
        Me.CbCessOn.DropDownHeight = 100
        Me.CbCessOn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbCessOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbCessOn.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.CbCessOn.ForeColor = System.Drawing.Color.Black
        Me.CbCessOn.FormattingEnabled = True
        Me.CbCessOn.IntegralHeight = False
        Me.CbCessOn.Items.AddRange(New Object() {"Not Applicable", "Taxable", "Qty", "Taxable+Qty"})
        Me.CbCessOn.Location = New System.Drawing.Point(115, 125)
        Me.CbCessOn.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CbCessOn.Name = "CbCessOn"
        Me.CbCessOn.Size = New System.Drawing.Size(245, 25)
        Me.CbCessOn.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(356, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 21)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Tax Type"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(25, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 21)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "GST %"
        '
        'lblCessPer
        '
        Me.lblCessPer.AutoSize = True
        Me.lblCessPer.Enabled = False
        Me.lblCessPer.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblCessPer.ForeColor = System.Drawing.Color.Black
        Me.lblCessPer.Location = New System.Drawing.Point(361, 101)
        Me.lblCessPer.Name = "lblCessPer"
        Me.lblCessPer.Size = New System.Drawing.Size(61, 21)
        Me.lblCessPer.TabIndex = 15
        Me.lblCessPer.Text = "Cess %"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(130, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(126, 21)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Cess based On"
        '
        'dg1
        '
        Me.dg1.AllowUserToAddRows = False
        Me.dg1.AllowUserToDeleteRows = False
        Me.dg1.AllowUserToResizeRows = False
        Me.dg1.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dg1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Crimson
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkTurquoise
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg1.DefaultCellStyle = DataGridViewCellStyle2
        Me.dg1.EnableHeadersVisualStyles = False
        Me.dg1.GridColor = System.Drawing.Color.Crimson
        Me.dg1.Location = New System.Drawing.Point(24, 247)
        Me.dg1.MultiSelect = False
        Me.dg1.Name = "dg1"
        Me.dg1.ReadOnly = True
        Me.dg1.RowHeadersVisible = False
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.dg1.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dg1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dg1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg1.Size = New System.Drawing.Size(552, 222)
        Me.dg1.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Bodoni Bk BT", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.Navy
        Me.Label8.Location = New System.Drawing.Point(224, 210)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(132, 32)
        Me.Label8.TabIndex = 91136
        Me.Label8.Text = "TAX LIST"
        '
        'txtQtyRate
        '
        Me.txtQtyRate.BackColor = System.Drawing.Color.GhostWhite
        Me.txtQtyRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQtyRate.Enabled = False
        Me.txtQtyRate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtQtyRate.ForeColor = System.Drawing.Color.Black
        Me.txtQtyRate.Location = New System.Drawing.Point(461, 124)
        Me.txtQtyRate.Name = "txtQtyRate"
        Me.txtQtyRate.Size = New System.Drawing.Size(115, 27)
        Me.txtQtyRate.TabIndex = 5
        Me.txtQtyRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ckOnMrp
        '
        Me.ckOnMrp.AutoSize = True
        Me.ckOnMrp.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ckOnMrp.ForeColor = System.Drawing.Color.Navy
        Me.ckOnMrp.Location = New System.Drawing.Point(29, 174)
        Me.ckOnMrp.Name = "ckOnMrp"
        Me.ckOnMrp.Size = New System.Drawing.Size(202, 23)
        Me.ckOnMrp.TabIndex = 6
        Me.ckOnMrp.Text = "Calculate Tax On MRP "
        Me.ckOnMrp.UseVisualStyleBackColor = True
        '
        'ckOnFree
        '
        Me.ckOnFree.AutoSize = True
        Me.ckOnFree.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ckOnFree.ForeColor = System.Drawing.Color.Navy
        Me.ckOnFree.Location = New System.Drawing.Point(403, 174)
        Me.ckOnFree.Name = "ckOnFree"
        Me.ckOnFree.Size = New System.Drawing.Size(173, 23)
        Me.ckOnFree.TabIndex = 7
        Me.ckOnFree.Text = "Tax On Free Goods"
        Me.ckOnFree.UseVisualStyleBackColor = True
        '
        'lblRatePer
        '
        Me.lblRatePer.AutoSize = True
        Me.lblRatePer.Enabled = False
        Me.lblRatePer.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblRatePer.ForeColor = System.Drawing.Color.Black
        Me.lblRatePer.Location = New System.Drawing.Point(465, 99)
        Me.lblRatePer.Name = "lblRatePer"
        Me.lblRatePer.Size = New System.Drawing.Size(111, 21)
        Me.lblRatePer.TabIndex = 91137
        Me.lblRatePer.Text = "Rate Per Unit"
        '
        'Taxation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(604, 481)
        Me.Controls.Add(Me.lblRatePer)
        Me.Controls.Add(Me.ckOnFree)
        Me.Controls.Add(Me.ckOnMrp)
        Me.Controls.Add(Me.txtQtyRate)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.dg1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblCessPer)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CbCessOn)
        Me.Controls.Add(Me.txtCessper)
        Me.Controls.Add(Me.txtGSTPer)
        Me.Controls.Add(Me.cbGstType)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.txtid)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.txtGSTName)
        Me.Controls.Add(Me.Label7)
        Me.Name = "Taxation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Taxation"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtid As System.Windows.Forms.TextBox
    Friend WithEvents BtnDelete As System.Windows.Forms.Button
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtGSTName As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents cbGstType As System.Windows.Forms.ComboBox
    Friend WithEvents txtGSTPer As System.Windows.Forms.TextBox
    Friend WithEvents txtCessper As System.Windows.Forms.TextBox
    Friend WithEvents CbCessOn As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblCessPer As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dg1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtQtyRate As System.Windows.Forms.TextBox
    Friend WithEvents ckOnMrp As System.Windows.Forms.CheckBox
    Friend WithEvents ckOnFree As System.Windows.Forms.CheckBox
    Friend WithEvents lblRatePer As System.Windows.Forms.Label
End Class
