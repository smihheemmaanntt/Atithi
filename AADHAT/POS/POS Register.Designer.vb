<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class POS_Register
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(POS_Register))
        Me.Label41 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.txtCustomerSearch = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtitemCode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnShow = New System.Windows.Forms.Button()
        Me.MsktoDate = New System.Windows.Forms.MaskedTextBox()
        Me.mskFromDate = New System.Windows.Forms.MaskedTextBox()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTotRoundOff = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtTotChange = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtTotCash = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtTotTotal = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtTotTax = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtTotTaxable = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtTotDiscount = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txttotQty = New System.Windows.Forms.TextBox()
        Me.txtTotBasic = New System.Windows.Forms.TextBox()
        Me.dg1 = New System.Windows.Forms.DataGridView()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.dtp1 = New System.Windows.Forms.DateTimePicker()
        Me.dtp2 = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Bodoni Bk BT", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.Black
        Me.Label41.Location = New System.Drawing.Point(426, -1)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(279, 48)
        Me.Label41.TabIndex = 91111
        Me.Label41.Text = "POS REGISTER"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.Red
        Me.lblTotal.Location = New System.Drawing.Point(14, 624)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(83, 20)
        Me.lblTotal.TabIndex = 40185
        Me.lblTotal.Text = "ItemName"
        Me.lblTotal.Visible = False
        '
        'txtCustomerSearch
        '
        Me.txtCustomerSearch.BackColor = System.Drawing.Color.GhostWhite
        Me.txtCustomerSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerSearch.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomerSearch.ForeColor = System.Drawing.Color.Black
        Me.txtCustomerSearch.Location = New System.Drawing.Point(870, 91)
        Me.txtCustomerSearch.Name = "txtCustomerSearch"
        Me.txtCustomerSearch.Size = New System.Drawing.Size(312, 26)
        Me.txtCustomerSearch.TabIndex = 40186
        Me.txtCustomerSearch.TabStop = False
        Me.txtCustomerSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.CadetBlue
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label6.Location = New System.Drawing.Point(753, 91)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(118, 28)
        Me.Label6.TabIndex = 40187
        Me.Label6.Text = "Item Name :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtitemCode
        '
        Me.txtitemCode.BackColor = System.Drawing.Color.GhostWhite
        Me.txtitemCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtitemCode.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtitemCode.ForeColor = System.Drawing.Color.Black
        Me.txtitemCode.Location = New System.Drawing.Point(674, 91)
        Me.txtitemCode.Name = "txtitemCode"
        Me.txtitemCode.Size = New System.Drawing.Size(79, 26)
        Me.txtitemCode.TabIndex = 40190
        Me.txtitemCode.TabStop = False
        Me.txtitemCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.CadetBlue
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label2.Location = New System.Drawing.Point(598, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 27)
        Me.Label2.TabIndex = 40191
        Me.Label2.Text = "POS No.:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnShow
        '
        Me.btnShow.BackColor = System.Drawing.Color.Salmon
        Me.btnShow.FlatAppearance.BorderSize = 0
        Me.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShow.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnShow.ForeColor = System.Drawing.Color.GhostWhite
        Me.btnShow.Location = New System.Drawing.Point(410, 91)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(94, 27)
        Me.btnShow.TabIndex = 40202
        Me.btnShow.Text = "&Show"
        Me.btnShow.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnShow.UseVisualStyleBackColor = False
        '
        'MsktoDate
        '
        Me.MsktoDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MsktoDate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MsktoDate.Location = New System.Drawing.Point(294, 91)
        Me.MsktoDate.Mask = "00-00-0000"
        Me.MsktoDate.Name = "MsktoDate"
        Me.MsktoDate.Size = New System.Drawing.Size(100, 26)
        Me.MsktoDate.TabIndex = 40201
        '
        'mskFromDate
        '
        Me.mskFromDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskFromDate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskFromDate.Location = New System.Drawing.Point(98, 91)
        Me.mskFromDate.Mask = "00-00-0000"
        Me.mskFromDate.Name = "mskFromDate"
        Me.mskFromDate.Size = New System.Drawing.Size(100, 26)
        Me.mskFromDate.TabIndex = 40200
        '
        'BtnPrint
        '
        Me.BtnPrint.BackColor = System.Drawing.Color.IndianRed
        Me.BtnPrint.FlatAppearance.BorderSize = 0
        Me.BtnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPrint.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.BtnPrint.ForeColor = System.Drawing.Color.GhostWhite
        Me.BtnPrint.Location = New System.Drawing.Point(504, 91)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(94, 27)
        Me.BtnPrint.TabIndex = 40203
        Me.BtnPrint.Text = "&Print"
        Me.BtnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnPrint.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Navy
        Me.Label8.Location = New System.Drawing.Point(806, 592)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 19)
        Me.Label8.TabIndex = 91185
        Me.Label8.Text = "Round off"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTotRoundOff
        '
        Me.txtTotRoundOff.BackColor = System.Drawing.Color.GhostWhite
        Me.txtTotRoundOff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotRoundOff.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotRoundOff.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotRoundOff.ForeColor = System.Drawing.Color.Red
        Me.txtTotRoundOff.Location = New System.Drawing.Point(803, 615)
        Me.txtTotRoundOff.Name = "txtTotRoundOff"
        Me.txtTotRoundOff.ReadOnly = True
        Me.txtTotRoundOff.Size = New System.Drawing.Size(83, 26)
        Me.txtTotRoundOff.TabIndex = 91184
        Me.txtTotRoundOff.TabStop = False
        Me.txtTotRoundOff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Navy
        Me.Label23.Location = New System.Drawing.Point(1109, 593)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(60, 19)
        Me.Label23.TabIndex = 91183
        Me.Label23.Text = "Change"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTotChange
        '
        Me.txtTotChange.BackColor = System.Drawing.Color.GhostWhite
        Me.txtTotChange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotChange.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotChange.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotChange.ForeColor = System.Drawing.Color.Red
        Me.txtTotChange.Location = New System.Drawing.Point(1082, 615)
        Me.txtTotChange.Name = "txtTotChange"
        Me.txtTotChange.ReadOnly = True
        Me.txtTotChange.Size = New System.Drawing.Size(100, 26)
        Me.txtTotChange.TabIndex = 91182
        Me.txtTotChange.TabStop = False
        Me.txtTotChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Navy
        Me.Label22.Location = New System.Drawing.Point(996, 592)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(74, 19)
        Me.Label22.TabIndex = 91181
        Me.Label22.Text = "Cash Amt"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTotCash
        '
        Me.txtTotCash.BackColor = System.Drawing.Color.GhostWhite
        Me.txtTotCash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotCash.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotCash.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotCash.ForeColor = System.Drawing.Color.Red
        Me.txtTotCash.Location = New System.Drawing.Point(983, 615)
        Me.txtTotCash.Name = "txtTotCash"
        Me.txtTotCash.ReadOnly = True
        Me.txtTotCash.Size = New System.Drawing.Size(100, 26)
        Me.txtTotCash.TabIndex = 91180
        Me.txtTotCash.TabStop = False
        Me.txtTotCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Navy
        Me.Label21.Location = New System.Drawing.Point(939, 592)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(43, 19)
        Me.Label21.TabIndex = 91179
        Me.Label21.Text = "Total"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTotTotal
        '
        Me.txtTotTotal.BackColor = System.Drawing.Color.GhostWhite
        Me.txtTotTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotTotal.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotTotal.ForeColor = System.Drawing.Color.Red
        Me.txtTotTotal.Location = New System.Drawing.Point(884, 615)
        Me.txtTotTotal.Name = "txtTotTotal"
        Me.txtTotTotal.ReadOnly = True
        Me.txtTotTotal.Size = New System.Drawing.Size(100, 26)
        Me.txtTotTotal.TabIndex = 91178
        Me.txtTotTotal.TabStop = False
        Me.txtTotTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Navy
        Me.Label20.Location = New System.Drawing.Point(733, 592)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(65, 19)
        Me.Label20.TabIndex = 91177
        Me.Label20.Text = "Tax Amt"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTotTax
        '
        Me.txtTotTax.BackColor = System.Drawing.Color.GhostWhite
        Me.txtTotTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotTax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotTax.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotTax.ForeColor = System.Drawing.Color.Red
        Me.txtTotTax.Location = New System.Drawing.Point(724, 615)
        Me.txtTotTax.Name = "txtTotTax"
        Me.txtTotTax.ReadOnly = True
        Me.txtTotTax.Size = New System.Drawing.Size(80, 26)
        Me.txtTotTax.TabIndex = 91176
        Me.txtTotTax.TabStop = False
        Me.txtTotTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Navy
        Me.Label19.Location = New System.Drawing.Point(645, 592)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(62, 19)
        Me.Label19.TabIndex = 91175
        Me.Label19.Text = "Taxable"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTotTaxable
        '
        Me.txtTotTaxable.BackColor = System.Drawing.Color.GhostWhite
        Me.txtTotTaxable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotTaxable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotTaxable.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotTaxable.ForeColor = System.Drawing.Color.Red
        Me.txtTotTaxable.Location = New System.Drawing.Point(625, 615)
        Me.txtTotTaxable.Name = "txtTotTaxable"
        Me.txtTotTaxable.ReadOnly = True
        Me.txtTotTaxable.Size = New System.Drawing.Size(100, 26)
        Me.txtTotTaxable.TabIndex = 91174
        Me.txtTotTaxable.TabStop = False
        Me.txtTotTaxable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Navy
        Me.Label17.Location = New System.Drawing.Point(554, 592)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(68, 19)
        Me.Label17.TabIndex = 91173
        Me.Label17.Text = "Discount"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTotDiscount
        '
        Me.txtTotDiscount.BackColor = System.Drawing.Color.GhostWhite
        Me.txtTotDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotDiscount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotDiscount.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotDiscount.ForeColor = System.Drawing.Color.Red
        Me.txtTotDiscount.Location = New System.Drawing.Point(546, 615)
        Me.txtTotDiscount.Name = "txtTotDiscount"
        Me.txtTotDiscount.ReadOnly = True
        Me.txtTotDiscount.Size = New System.Drawing.Size(80, 26)
        Me.txtTotDiscount.TabIndex = 91172
        Me.txtTotDiscount.TabStop = False
        Me.txtTotDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Navy
        Me.Label9.Location = New System.Drawing.Point(459, 592)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 19)
        Me.Label9.TabIndex = 91171
        Me.Label9.Text = "Basic Amt"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Navy
        Me.Label10.Location = New System.Drawing.Point(400, 592)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(34, 19)
        Me.Label10.TabIndex = 91170
        Me.Label10.Text = "Qty"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txttotQty
        '
        Me.txttotQty.BackColor = System.Drawing.Color.GhostWhite
        Me.txttotQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txttotQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txttotQty.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotQty.ForeColor = System.Drawing.Color.Red
        Me.txttotQty.Location = New System.Drawing.Point(381, 615)
        Me.txttotQty.Name = "txttotQty"
        Me.txttotQty.ReadOnly = True
        Me.txttotQty.Size = New System.Drawing.Size(67, 26)
        Me.txttotQty.TabIndex = 91169
        Me.txttotQty.TabStop = False
        Me.txttotQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotBasic
        '
        Me.txtTotBasic.BackColor = System.Drawing.Color.GhostWhite
        Me.txtTotBasic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotBasic.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotBasic.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotBasic.ForeColor = System.Drawing.Color.Red
        Me.txtTotBasic.Location = New System.Drawing.Point(447, 615)
        Me.txtTotBasic.Name = "txtTotBasic"
        Me.txtTotBasic.ReadOnly = True
        Me.txtTotBasic.Size = New System.Drawing.Size(100, 26)
        Me.txtTotBasic.TabIndex = 91168
        Me.txtTotBasic.TabStop = False
        Me.txtTotBasic.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dg1.ColumnHeadersHeight = 28
        Me.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.CadetBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg1.DefaultCellStyle = DataGridViewCellStyle2
        Me.dg1.EnableHeadersVisualStyles = False
        Me.dg1.GridColor = System.Drawing.Color.Gray
        Me.dg1.Location = New System.Drawing.Point(12, 116)
        Me.dg1.MultiSelect = False
        Me.dg1.Name = "dg1"
        Me.dg1.ReadOnly = True
        Me.dg1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg1.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dg1.RowHeadersVisible = False
        Me.dg1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dg1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dg1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg1.Size = New System.Drawing.Size(1170, 472)
        Me.dg1.TabIndex = 91204
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(370, -1)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox4.TabIndex = 91209
        Me.PictureBox4.TabStop = False
        '
        'btnClose
        '
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(1153, -1)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(40, 40)
        Me.btnClose.TabIndex = 91210
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'dtp1
        '
        Me.dtp1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.dtp1.Location = New System.Drawing.Point(105, 91)
        Me.dtp1.Name = "dtp1"
        Me.dtp1.Size = New System.Drawing.Size(109, 26)
        Me.dtp1.TabIndex = 91228
        '
        'dtp2
        '
        Me.dtp2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.dtp2.Location = New System.Drawing.Point(301, 91)
        Me.dtp2.Name = "dtp2"
        Me.dtp2.Size = New System.Drawing.Size(109, 26)
        Me.dtp2.TabIndex = 91227
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.CadetBlue
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label12.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label12.Location = New System.Drawing.Point(214, 91)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(80, 27)
        Me.Label12.TabIndex = 91230
        Me.Label12.Text = "To Date :"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.CadetBlue
        Me.Label13.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label13.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label13.Location = New System.Drawing.Point(12, 91)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(85, 27)
        Me.Label13.TabIndex = 91229
        Me.Label13.Text = "From Date :"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'POS_Register
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.ClientSize = New System.Drawing.Size(1194, 653)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.mskFromDate)
        Me.Controls.Add(Me.dtp1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.dg1)
        Me.Controls.Add(Me.btnShow)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.MsktoDate)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.txtTotRoundOff)
        Me.Controls.Add(Me.txtTotChange)
        Me.Controls.Add(Me.txtTotBasic)
        Me.Controls.Add(Me.txttotQty)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtTotDiscount)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.txtitemCode)
        Me.Controls.Add(Me.txtTotTaxable)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtCustomerSearch)
        Me.Controls.Add(Me.txtTotCash)
        Me.Controls.Add(Me.txtTotTax)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.txtTotTotal)
        Me.Controls.Add(Me.dtp2)
        Me.Name = "POS_Register"
        Me.Text = "POS"
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

End Sub
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents txtCustomerSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtitemCode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnShow As System.Windows.Forms.Button
    Friend WithEvents MsktoDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mskFromDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTotRoundOff As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtTotChange As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtTotCash As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtTotTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtTotTax As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtTotTaxable As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtTotDiscount As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txttotQty As System.Windows.Forms.TextBox
    Friend WithEvents txtTotBasic As System.Windows.Forms.TextBox
    Friend WithEvents dg1 As System.Windows.Forms.DataGridView
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents dtp1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
