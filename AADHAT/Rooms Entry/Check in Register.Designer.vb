<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Check_in_Register
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Check_in_Register))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnShow = New System.Windows.Forms.Button()
        Me.MsktoDate = New System.Windows.Forms.MaskedTextBox()
        Me.mskFromDate = New System.Windows.Forms.MaskedTextBox()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.dg1 = New System.Windows.Forms.DataGridView()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.ckCheckOutCustomers = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtVAStotal = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txtDueAmount = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtAdvanceRecieved = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.TxtTotal = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtDiscAmt = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.TxtRentAmount = New System.Windows.Forms.TextBox()
        Me.dtp1 = New System.Windows.Forms.DateTimePicker()
        Me.dtp2 = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtGuestName = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.CadetBlue
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label10.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label10.Location = New System.Drawing.Point(230, 83)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(81, 28)
        Me.Label10.TabIndex = 91187
        Me.Label10.Text = "To Date :"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.CadetBlue
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label9.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label9.Location = New System.Drawing.Point(12, 83)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(103, 28)
        Me.Label9.TabIndex = 91186
        Me.Label9.Text = "From Date :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnShow
        '
        Me.btnShow.BackColor = System.Drawing.Color.Salmon
        Me.btnShow.FlatAppearance.BorderSize = 0
        Me.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShow.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnShow.ForeColor = System.Drawing.Color.GhostWhite
        Me.btnShow.Image = CType(resources.GetObject("btnShow.Image"), System.Drawing.Image)
        Me.btnShow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnShow.Location = New System.Drawing.Point(427, 83)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(85, 28)
        Me.btnShow.TabIndex = 2
        Me.btnShow.Text = "&Show"
        Me.btnShow.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnShow.UseVisualStyleBackColor = False
        '
        'MsktoDate
        '
        Me.MsktoDate.BackColor = System.Drawing.Color.GhostWhite
        Me.MsktoDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MsktoDate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.MsktoDate.Location = New System.Drawing.Point(311, 83)
        Me.MsktoDate.Mask = "00-00-0000"
        Me.MsktoDate.Name = "MsktoDate"
        Me.MsktoDate.Size = New System.Drawing.Size(100, 27)
        Me.MsktoDate.TabIndex = 1
        '
        'mskFromDate
        '
        Me.mskFromDate.BackColor = System.Drawing.Color.GhostWhite
        Me.mskFromDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskFromDate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.mskFromDate.Location = New System.Drawing.Point(115, 83)
        Me.mskFromDate.Mask = "00-00-0000"
        Me.mskFromDate.Name = "mskFromDate"
        Me.mskFromDate.Size = New System.Drawing.Size(100, 27)
        Me.mskFromDate.TabIndex = 0
        '
        'BtnPrint
        '
        Me.BtnPrint.BackColor = System.Drawing.Color.IndianRed
        Me.BtnPrint.FlatAppearance.BorderSize = 0
        Me.BtnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPrint.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.BtnPrint.ForeColor = System.Drawing.Color.GhostWhite
        Me.BtnPrint.Location = New System.Drawing.Point(1200, 271)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(76, 30)
        Me.BtnPrint.TabIndex = 40224
        Me.BtnPrint.Text = "&Print"
        Me.BtnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnPrint.UseVisualStyleBackColor = False
        '
        'dg1
        '
        Me.dg1.AllowUserToAddRows = False
        Me.dg1.AllowUserToDeleteRows = False
        Me.dg1.AllowUserToResizeRows = False
        Me.dg1.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dg1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.RosyBrown
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dg1.ColumnHeadersHeight = 28
        Me.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Times New Roman", 7.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.CadetBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg1.DefaultCellStyle = DataGridViewCellStyle2
        Me.dg1.EnableHeadersVisualStyles = False
        Me.dg1.GridColor = System.Drawing.Color.Gray
        Me.dg1.Location = New System.Drawing.Point(12, 109)
        Me.dg1.MultiSelect = False
        Me.dg1.Name = "dg1"
        Me.dg1.ReadOnly = True
        Me.dg1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dg1.RowHeadersVisible = False
        Me.dg1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dg1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dg1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg1.Size = New System.Drawing.Size(1170, 492)
        Me.dg1.TabIndex = 40205
        Me.dg1.TabStop = False
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Bodoni Bk BT", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.Black
        Me.Label41.Location = New System.Drawing.Point(414, 1)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(387, 48)
        Me.Label41.TabIndex = 91111
        Me.Label41.Text = "CHECK IN REGISTER"
        '
        'ckCheckOutCustomers
        '
        Me.ckCheckOutCustomers.BackColor = System.Drawing.Color.Navy
        Me.ckCheckOutCustomers.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.ckCheckOutCustomers.ForeColor = System.Drawing.Color.GhostWhite
        Me.ckCheckOutCustomers.Location = New System.Drawing.Point(285, 625)
        Me.ckCheckOutCustomers.Name = "ckCheckOutCustomers"
        Me.ckCheckOutCustomers.Size = New System.Drawing.Size(178, 28)
        Me.ckCheckOutCustomers.TabIndex = 4
        Me.ckCheckOutCustomers.Text = "Check Out Guests List"
        Me.ckCheckOutCustomers.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckCheckOutCustomers.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.IndianRed
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.GhostWhite
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(512, 83)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(85, 28)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "&Print"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(1154, -1)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(40, 40)
        Me.btnClose.TabIndex = 91199
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(359, 1)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox4.TabIndex = 91208
        Me.PictureBox4.TabStop = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(771, 601)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(54, 21)
        Me.Label14.TabIndex = 91220
        Me.Label14.Text = "V.A.S "
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtVAStotal
        '
        Me.txtVAStotal.BackColor = System.Drawing.Color.GhostWhite
        Me.txtVAStotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVAStotal.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtVAStotal.ForeColor = System.Drawing.Color.Red
        Me.txtVAStotal.Location = New System.Drawing.Point(721, 625)
        Me.txtVAStotal.Name = "txtVAStotal"
        Me.txtVAStotal.ReadOnly = True
        Me.txtVAStotal.Size = New System.Drawing.Size(104, 27)
        Me.txtVAStotal.TabIndex = 91219
        Me.txtVAStotal.TabStop = False
        Me.txtVAStotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.Black
        Me.Label35.Location = New System.Drawing.Point(1072, 602)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(111, 21)
        Me.Label35.TabIndex = 91218
        Me.Label35.Text = "Due Amount"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDueAmount
        '
        Me.txtDueAmount.BackColor = System.Drawing.Color.GhostWhite
        Me.txtDueAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDueAmount.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtDueAmount.ForeColor = System.Drawing.Color.Red
        Me.txtDueAmount.Location = New System.Drawing.Point(1062, 625)
        Me.txtDueAmount.Name = "txtDueAmount"
        Me.txtDueAmount.Size = New System.Drawing.Size(120, 27)
        Me.txtDueAmount.TabIndex = 91213
        Me.txtDueAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.Black
        Me.Label34.Location = New System.Drawing.Point(975, 602)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(85, 21)
        Me.Label34.TabIndex = 91217
        Me.Label34.Text = "Advance"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAdvanceRecieved
        '
        Me.txtAdvanceRecieved.BackColor = System.Drawing.Color.GhostWhite
        Me.txtAdvanceRecieved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAdvanceRecieved.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtAdvanceRecieved.ForeColor = System.Drawing.Color.Red
        Me.txtAdvanceRecieved.Location = New System.Drawing.Point(943, 625)
        Me.txtAdvanceRecieved.Name = "txtAdvanceRecieved"
        Me.txtAdvanceRecieved.Size = New System.Drawing.Size(120, 27)
        Me.txtAdvanceRecieved.TabIndex = 91212
        Me.txtAdvanceRecieved.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Black
        Me.Label32.Location = New System.Drawing.Point(891, 602)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(53, 21)
        Me.Label32.TabIndex = 91216
        Me.Label32.Text = "Total "
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtTotal
        '
        Me.TxtTotal.BackColor = System.Drawing.Color.GhostWhite
        Me.TxtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTotal.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TxtTotal.ForeColor = System.Drawing.Color.Red
        Me.TxtTotal.Location = New System.Drawing.Point(824, 625)
        Me.TxtTotal.Name = "TxtTotal"
        Me.TxtTotal.Size = New System.Drawing.Size(120, 27)
        Me.TxtTotal.TabIndex = 91211
        Me.TxtTotal.TabStop = False
        Me.TxtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.Black
        Me.Label31.Location = New System.Drawing.Point(678, 602)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(41, 21)
        Me.Label31.TabIndex = 91215
        Me.Label31.Text = "Disc"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDiscAmt
        '
        Me.txtDiscAmt.BackColor = System.Drawing.Color.GhostWhite
        Me.txtDiscAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiscAmt.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtDiscAmt.ForeColor = System.Drawing.Color.Red
        Me.txtDiscAmt.Location = New System.Drawing.Point(610, 625)
        Me.txtDiscAmt.Name = "txtDiscAmt"
        Me.txtDiscAmt.Size = New System.Drawing.Size(112, 27)
        Me.txtDiscAmt.TabIndex = 91210
        Me.txtDiscAmt.TabStop = False
        Me.txtDiscAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(499, 602)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(116, 21)
        Me.Label29.TabIndex = 91214
        Me.Label29.Text = "Rent Amount"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtRentAmount
        '
        Me.TxtRentAmount.BackColor = System.Drawing.Color.GhostWhite
        Me.TxtRentAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtRentAmount.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TxtRentAmount.ForeColor = System.Drawing.Color.Red
        Me.TxtRentAmount.Location = New System.Drawing.Point(462, 625)
        Me.TxtRentAmount.Name = "TxtRentAmount"
        Me.TxtRentAmount.Size = New System.Drawing.Size(149, 27)
        Me.TxtRentAmount.TabIndex = 91209
        Me.TxtRentAmount.TabStop = False
        Me.TxtRentAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtp1
        '
        Me.dtp1.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.dtp1.Location = New System.Drawing.Point(114, 83)
        Me.dtp1.Name = "dtp1"
        Me.dtp1.Size = New System.Drawing.Size(116, 27)
        Me.dtp1.TabIndex = 91221
        '
        'dtp2
        '
        Me.dtp2.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.dtp2.Location = New System.Drawing.Point(311, 83)
        Me.dtp2.Name = "dtp2"
        Me.dtp2.Size = New System.Drawing.Size(116, 27)
        Me.dtp2.TabIndex = 91222
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label4.Location = New System.Drawing.Point(597, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(122, 27)
        Me.Label4.TabIndex = 91276
        Me.Label4.Text = "Guest Name :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtGuestName
        '
        Me.txtGuestName.BackColor = System.Drawing.Color.GhostWhite
        Me.txtGuestName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGuestName.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.txtGuestName.ForeColor = System.Drawing.Color.Black
        Me.txtGuestName.Location = New System.Drawing.Point(719, 83)
        Me.txtGuestName.Name = "txtGuestName"
        Me.txtGuestName.Size = New System.Drawing.Size(263, 27)
        Me.txtGuestName.TabIndex = 91275
        Me.txtGuestName.TabStop = False
        Me.txtGuestName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Label15.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label15.Location = New System.Drawing.Point(981, 83)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(93, 26)
        Me.Label15.TabIndex = 91282
        Me.Label15.Text = "Room No. :"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.GhostWhite
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TextBox1.ForeColor = System.Drawing.Color.Black
        Me.TextBox1.Location = New System.Drawing.Point(1073, 83)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(109, 27)
        Me.TextBox1.TabIndex = 91281
        Me.TextBox1.TabStop = False
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Check_in_Register
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1194, 653)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtGuestName)
        Me.Controls.Add(Me.dg1)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtVAStotal)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.txtDueAmount)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.txtAdvanceRecieved)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.TxtTotal)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.txtDiscAmt)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.TxtRentAmount)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.ckCheckOutCustomers)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.btnShow)
        Me.Controls.Add(Me.MsktoDate)
        Me.Controls.Add(Me.mskFromDate)
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.dtp1)
        Me.Controls.Add(Me.dtp2)
        Me.Name = "Check_in_Register"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Check_in_Register"
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnShow As System.Windows.Forms.Button
    Friend WithEvents MsktoDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mskFromDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents dg1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents ckCheckOutCustomers As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtVAStotal As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents txtDueAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txtAdvanceRecieved As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents TxtTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtDiscAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents TxtRentAmount As System.Windows.Forms.TextBox
    Friend WithEvents dtp1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtGuestName As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
End Class
