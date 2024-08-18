<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Purchase_Register
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Purchase_Register))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dg1 = New System.Windows.Forms.DataGridView()
        Me.txtTotRoundOff = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAccountSearch = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtGrandTotal = New System.Windows.Forms.TextBox()
        Me.txtTotCharges = New System.Windows.Forms.TextBox()
        Me.txtTotDisc = New System.Windows.Forms.TextBox()
        Me.txtTotQty = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.btnShow = New System.Windows.Forms.Button()
        Me.MsktoDate = New System.Windows.Forms.MaskedTextBox()
        Me.mskFromDate = New System.Windows.Forms.MaskedTextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.dtp2 = New System.Windows.Forms.DateTimePicker()
        Me.dtp1 = New System.Windows.Forms.DateTimePicker()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnPrintList = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtTotNet = New System.Windows.Forms.TextBox()
        Me.txtTotTax = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTotTaxable = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tmpgrid = New System.Windows.Forms.DataGridView()
        Me.PnlDeleteBills = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.txtDelete = New System.Windows.Forms.TextBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnMore = New System.Windows.Forms.Button()
        Me.pnlSearch = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtTotalSearch = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtTaxableSearch = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtbasicAmtSearch = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtQtySearch = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtInvoiceSearch = New System.Windows.Forms.TextBox()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tmpgrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlDeleteBills.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSearch.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Bodoni Bk BT", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(394, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(407, 48)
        Me.Label1.TabIndex = 91140
        Me.Label1.Text = "PURCHASE REGISTER"
        '
        'Label5
        '
        Me.Label5.AllowDrop = True
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(972, 599)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 21)
        Me.Label5.TabIndex = 91167
        Me.Label5.Text = "Round Off"
        '
        'dg1
        '
        Me.dg1.AllowUserToAddRows = False
        Me.dg1.AllowUserToDeleteRows = False
        Me.dg1.AllowUserToResizeRows = False
        Me.dg1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.dg1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(241, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Crimson
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dg1.ColumnHeadersHeight = 28
        Me.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(241, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Times New Roman", 11.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg1.DefaultCellStyle = DataGridViewCellStyle2
        Me.dg1.EnableHeadersVisualStyles = False
        Me.dg1.GridColor = System.Drawing.Color.Gray
        Me.dg1.Location = New System.Drawing.Point(12, 137)
        Me.dg1.MultiSelect = False
        Me.dg1.Name = "dg1"
        Me.dg1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dg1.RowHeadersVisible = False
        Me.dg1.RowHeadersWidth = 42
        Me.dg1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.dg1.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dg1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dg1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg1.Size = New System.Drawing.Size(1172, 447)
        Me.dg1.TabIndex = 91173
        Me.dg1.TabStop = False
        '
        'txtTotRoundOff
        '
        Me.txtTotRoundOff.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.txtTotRoundOff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotRoundOff.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotRoundOff.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotRoundOff.ForeColor = System.Drawing.Color.Navy
        Me.txtTotRoundOff.Location = New System.Drawing.Point(957, 621)
        Me.txtTotRoundOff.Name = "txtTotRoundOff"
        Me.txtTotRoundOff.ReadOnly = True
        Me.txtTotRoundOff.Size = New System.Drawing.Size(100, 27)
        Me.txtTotRoundOff.TabIndex = 91165
        Me.txtTotRoundOff.TabStop = False
        Me.txtTotRoundOff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(790, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(132, 21)
        Me.Label3.TabIndex = 91170
        Me.Label3.Text = "Account Name"
        '
        'txtAccountSearch
        '
        Me.txtAccountSearch.BackColor = System.Drawing.Color.GhostWhite
        Me.txtAccountSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAccountSearch.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtAccountSearch.ForeColor = System.Drawing.Color.Black
        Me.txtAccountSearch.Location = New System.Drawing.Point(787, 111)
        Me.txtAccountSearch.Name = "txtAccountSearch"
        Me.txtAccountSearch.Size = New System.Drawing.Size(270, 27)
        Me.txtAccountSearch.TabIndex = 91166
        Me.txtAccountSearch.TabStop = False
        Me.txtAccountSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label21
        '
        Me.Label21.AllowDrop = True
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(887, 599)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(76, 21)
        Me.Label21.TabIndex = 91158
        Me.Label21.Text = "Charges"
        '
        'Label6
        '
        Me.Label6.AllowDrop = True
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(397, 599)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 21)
        Me.Label6.TabIndex = 91155
        Me.Label6.Text = "Qty"
        '
        'TxtGrandTotal
        '
        Me.TxtGrandTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.TxtGrandTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtGrandTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtGrandTotal.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtGrandTotal.ForeColor = System.Drawing.Color.Navy
        Me.TxtGrandTotal.Location = New System.Drawing.Point(1056, 621)
        Me.TxtGrandTotal.Name = "TxtGrandTotal"
        Me.TxtGrandTotal.ReadOnly = True
        Me.TxtGrandTotal.Size = New System.Drawing.Size(130, 27)
        Me.TxtGrandTotal.TabIndex = 91154
        Me.TxtGrandTotal.TabStop = False
        Me.TxtGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotCharges
        '
        Me.txtTotCharges.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.txtTotCharges.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotCharges.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotCharges.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotCharges.ForeColor = System.Drawing.Color.Navy
        Me.txtTotCharges.Location = New System.Drawing.Point(858, 621)
        Me.txtTotCharges.Name = "txtTotCharges"
        Me.txtTotCharges.ReadOnly = True
        Me.txtTotCharges.Size = New System.Drawing.Size(100, 27)
        Me.txtTotCharges.TabIndex = 91153
        Me.txtTotCharges.TabStop = False
        Me.txtTotCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotDisc
        '
        Me.txtTotDisc.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.txtTotDisc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotDisc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotDisc.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotDisc.ForeColor = System.Drawing.Color.Navy
        Me.txtTotDisc.Location = New System.Drawing.Point(531, 621)
        Me.txtTotDisc.Name = "txtTotDisc"
        Me.txtTotDisc.ReadOnly = True
        Me.txtTotDisc.Size = New System.Drawing.Size(100, 27)
        Me.txtTotDisc.TabIndex = 91152
        Me.txtTotDisc.TabStop = False
        Me.txtTotDisc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotQty
        '
        Me.txtTotQty.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.txtTotQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotQty.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotQty.ForeColor = System.Drawing.Color.Navy
        Me.txtTotQty.Location = New System.Drawing.Point(353, 621)
        Me.txtTotQty.Name = "txtTotQty"
        Me.txtTotQty.ReadOnly = True
        Me.txtTotQty.Size = New System.Drawing.Size(80, 27)
        Me.txtTotQty.TabIndex = 91149
        Me.txtTotQty.TabStop = False
        Me.txtTotQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label2.Location = New System.Drawing.Point(179, 111)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 27)
        Me.Label2.TabIndex = 91147
        Me.Label2.Text = "To"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Label25.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label25.Location = New System.Drawing.Point(12, 111)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(53, 27)
        Me.Label25.TabIndex = 91146
        Me.Label25.Text = "From"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnShow
        '
        Me.btnShow.BackColor = System.Drawing.Color.DarkTurquoise
        Me.btnShow.FlatAppearance.BorderSize = 0
        Me.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShow.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnShow.ForeColor = System.Drawing.Color.GhostWhite
        Me.btnShow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnShow.Location = New System.Drawing.Point(331, 111)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(94, 27)
        Me.btnShow.TabIndex = 2
        Me.btnShow.Text = "&Show"
        Me.btnShow.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnShow.UseVisualStyleBackColor = False
        '
        'MsktoDate
        '
        Me.MsktoDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MsktoDate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.MsktoDate.Location = New System.Drawing.Point(215, 111)
        Me.MsktoDate.Mask = "00-00-0000"
        Me.MsktoDate.Name = "MsktoDate"
        Me.MsktoDate.Size = New System.Drawing.Size(100, 27)
        Me.MsktoDate.TabIndex = 1
        '
        'mskFromDate
        '
        Me.mskFromDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskFromDate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.mskFromDate.Location = New System.Drawing.Point(65, 111)
        Me.mskFromDate.Mask = "00-00-0000"
        Me.mskFromDate.Name = "mskFromDate"
        Me.mskFromDate.Size = New System.Drawing.Size(100, 27)
        Me.mskFromDate.TabIndex = 0
        '
        'Label20
        '
        Me.Label20.AllowDrop = True
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(593, 601)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(41, 21)
        Me.Label20.TabIndex = 91157
        Me.Label20.Text = "Disc"
        '
        'Label22
        '
        Me.Label22.AllowDrop = True
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(1140, 599)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(49, 21)
        Me.Label22.TabIndex = 91159
        Me.Label22.Text = "Total"
        '
        'dtp2
        '
        Me.dtp2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.dtp2.Location = New System.Drawing.Point(222, 111)
        Me.dtp2.Name = "dtp2"
        Me.dtp2.Size = New System.Drawing.Size(109, 27)
        Me.dtp2.TabIndex = 1111
        '
        'dtp1
        '
        Me.dtp1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.dtp1.Location = New System.Drawing.Point(70, 111)
        Me.dtp1.Name = "dtp1"
        Me.dtp1.Size = New System.Drawing.Size(109, 27)
        Me.dtp1.TabIndex = 91176
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(338, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 91174
        Me.PictureBox1.TabStop = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Red
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(1143, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(53, 47)
        Me.btnClose.TabIndex = 91150
        Me.btnClose.TabStop = False
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Brown
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.GhostWhite
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(660, 111)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(128, 27)
        Me.Button3.TabIndex = 5
        Me.Button3.TabStop = False
        Me.Button3.Text = "&Delete Bills"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Coral
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.GhostWhite
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(551, 111)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(109, 27)
        Me.Button2.TabIndex = 4
        Me.Button2.TabStop = False
        Me.Button2.Text = "Print &Bills"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = False
        '
        'btnPrintList
        '
        Me.btnPrintList.BackColor = System.Drawing.Color.MediumAquamarine
        Me.btnPrintList.FlatAppearance.BorderSize = 0
        Me.btnPrintList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintList.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnPrintList.ForeColor = System.Drawing.Color.GhostWhite
        Me.btnPrintList.Image = CType(resources.GetObject("btnPrintList.Image"), System.Drawing.Image)
        Me.btnPrintList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrintList.Location = New System.Drawing.Point(425, 111)
        Me.btnPrintList.Name = "btnPrintList"
        Me.btnPrintList.Size = New System.Drawing.Size(127, 27)
        Me.btnPrintList.TabIndex = 3
        Me.btnPrintList.TabStop = False
        Me.btnPrintList.Text = "&Print List"
        Me.btnPrintList.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPrintList.UseVisualStyleBackColor = False
        '
        'Label19
        '
        Me.Label19.AllowDrop = True
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(483, 599)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(49, 21)
        Me.Label19.TabIndex = 91156
        Me.Label19.Text = "Basic"
        '
        'txtTotNet
        '
        Me.txtTotNet.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.txtTotNet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotNet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotNet.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotNet.ForeColor = System.Drawing.Color.Navy
        Me.txtTotNet.Location = New System.Drawing.Point(432, 621)
        Me.txtTotNet.Name = "txtTotNet"
        Me.txtTotNet.ReadOnly = True
        Me.txtTotNet.Size = New System.Drawing.Size(100, 27)
        Me.txtTotNet.TabIndex = 91151
        Me.txtTotNet.TabStop = False
        Me.txtTotNet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotTax
        '
        Me.txtTotTax.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.txtTotTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotTax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotTax.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotTax.ForeColor = System.Drawing.Color.Navy
        Me.txtTotTax.Location = New System.Drawing.Point(759, 621)
        Me.txtTotTax.Name = "txtTotTax"
        Me.txtTotTax.ReadOnly = True
        Me.txtTotTax.Size = New System.Drawing.Size(100, 27)
        Me.txtTotTax.TabIndex = 91177
        Me.txtTotTax.TabStop = False
        Me.txtTotTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AllowDrop = True
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(827, 599)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 21)
        Me.Label7.TabIndex = 91178
        Me.Label7.Text = "Tax"
        '
        'txtTotTaxable
        '
        Me.txtTotTaxable.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.txtTotTaxable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotTaxable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotTaxable.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotTaxable.ForeColor = System.Drawing.Color.Navy
        Me.txtTotTaxable.Location = New System.Drawing.Point(630, 621)
        Me.txtTotTaxable.Name = "txtTotTaxable"
        Me.txtTotTaxable.ReadOnly = True
        Me.txtTotTaxable.Size = New System.Drawing.Size(130, 27)
        Me.txtTotTaxable.TabIndex = 91179
        Me.txtTotTaxable.TabStop = False
        Me.txtTotTaxable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AllowDrop = True
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(692, 600)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 21)
        Me.Label8.TabIndex = 91180
        Me.Label8.Text = "Taxable"
        '
        'tmpgrid
        '
        Me.tmpgrid.AllowUserToAddRows = False
        Me.tmpgrid.AllowUserToDeleteRows = False
        Me.tmpgrid.AllowUserToResizeRows = False
        Me.tmpgrid.BackgroundColor = System.Drawing.Color.Gray
        Me.tmpgrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Crimson
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.tmpgrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.tmpgrid.ColumnHeadersHeight = 28
        Me.tmpgrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.tmpgrid.DefaultCellStyle = DataGridViewCellStyle5
        Me.tmpgrid.EnableHeadersVisualStyles = False
        Me.tmpgrid.GridColor = System.Drawing.Color.Crimson
        Me.tmpgrid.Location = New System.Drawing.Point(12, 404)
        Me.tmpgrid.MultiSelect = False
        Me.tmpgrid.Name = "tmpgrid"
        Me.tmpgrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.tmpgrid.RowHeadersVisible = False
        Me.tmpgrid.RowHeadersWidth = 42
        Me.tmpgrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        Me.tmpgrid.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.tmpgrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tmpgrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tmpgrid.Size = New System.Drawing.Size(1172, 180)
        Me.tmpgrid.TabIndex = 91181
        Me.tmpgrid.TabStop = False
        Me.tmpgrid.Visible = False
        '
        'PnlDeleteBills
        '
        Me.PnlDeleteBills.BackColor = System.Drawing.Color.Silver
        Me.PnlDeleteBills.Controls.Add(Me.Label9)
        Me.PnlDeleteBills.Controls.Add(Me.PictureBox4)
        Me.PnlDeleteBills.Controls.Add(Me.txtDelete)
        Me.PnlDeleteBills.Controls.Add(Me.btnDelete)
        Me.PnlDeleteBills.Location = New System.Drawing.Point(331, 138)
        Me.PnlDeleteBills.Name = "PnlDeleteBills"
        Me.PnlDeleteBills.Size = New System.Drawing.Size(457, 210)
        Me.PnlDeleteBills.TabIndex = 6
        Me.PnlDeleteBills.Visible = False
        '
        'Label9
        '
        Me.Label9.AllowDrop = True
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(54, 38)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(332, 19)
        Me.Label9.TabIndex = 91374
        Me.Label9.Text = "Type [SURE] For Delete Bills Comfirmation...."
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(5, 90)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(141, 86)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 91373
        Me.PictureBox4.TabStop = False
        '
        'txtDelete
        '
        Me.txtDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtDelete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDelete.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDelete.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtDelete.ForeColor = System.Drawing.Color.Black
        Me.txtDelete.Location = New System.Drawing.Point(150, 92)
        Me.txtDelete.Name = "txtDelete"
        Me.txtDelete.Size = New System.Drawing.Size(278, 27)
        Me.txtDelete.TabIndex = 91372
        Me.txtDelete.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnDelete.FlatAppearance.BorderSize = 0
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnDelete.ForeColor = System.Drawing.Color.GhostWhite
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(150, 125)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(278, 51)
        Me.btnDelete.TabIndex = 91269
        Me.btnDelete.TabStop = False
        Me.btnDelete.Text = "&Delete Selected Bills "
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnMore
        '
        Me.btnMore.BackColor = System.Drawing.Color.Brown
        Me.btnMore.FlatAppearance.BorderSize = 0
        Me.btnMore.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMore.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnMore.ForeColor = System.Drawing.Color.GhostWhite
        Me.btnMore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMore.Location = New System.Drawing.Point(1056, 110)
        Me.btnMore.Name = "btnMore"
        Me.btnMore.Size = New System.Drawing.Size(128, 27)
        Me.btnMore.TabIndex = 91182
        Me.btnMore.TabStop = False
        Me.btnMore.Text = "Search &More..."
        Me.btnMore.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnMore.UseVisualStyleBackColor = False
        '
        'pnlSearch
        '
        Me.pnlSearch.BackColor = System.Drawing.Color.Silver
        Me.pnlSearch.Controls.Add(Me.Label13)
        Me.pnlSearch.Controls.Add(Me.txtTotalSearch)
        Me.pnlSearch.Controls.Add(Me.Label12)
        Me.pnlSearch.Controls.Add(Me.txtTaxableSearch)
        Me.pnlSearch.Controls.Add(Me.Label11)
        Me.pnlSearch.Controls.Add(Me.txtbasicAmtSearch)
        Me.pnlSearch.Controls.Add(Me.Label10)
        Me.pnlSearch.Controls.Add(Me.txtQtySearch)
        Me.pnlSearch.Controls.Add(Me.Label4)
        Me.pnlSearch.Controls.Add(Me.txtInvoiceSearch)
        Me.pnlSearch.Location = New System.Drawing.Point(727, 138)
        Me.pnlSearch.Name = "pnlSearch"
        Me.pnlSearch.Size = New System.Drawing.Size(457, 210)
        Me.pnlSearch.TabIndex = 91375
        Me.pnlSearch.Visible = False
        '
        'Label13
        '
        Me.Label13.AllowDrop = True
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(42, 164)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(119, 19)
        Me.Label13.TabIndex = 91382
        Me.Label13.Text = "Total Amount :"
        '
        'txtTotalSearch
        '
        Me.txtTotalSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtTotalSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalSearch.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtTotalSearch.ForeColor = System.Drawing.Color.Black
        Me.txtTotalSearch.Location = New System.Drawing.Point(179, 162)
        Me.txtTotalSearch.Name = "txtTotalSearch"
        Me.txtTotalSearch.Size = New System.Drawing.Size(259, 27)
        Me.txtTotalSearch.TabIndex = 91381
        Me.txtTotalSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.AllowDrop = True
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(15, 131)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(146, 19)
        Me.Label12.TabIndex = 91380
        Me.Label12.Text = "Taxable Amount :"
        '
        'txtTaxableSearch
        '
        Me.txtTaxableSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtTaxableSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTaxableSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTaxableSearch.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtTaxableSearch.ForeColor = System.Drawing.Color.Black
        Me.txtTaxableSearch.Location = New System.Drawing.Point(179, 129)
        Me.txtTaxableSearch.Name = "txtTaxableSearch"
        Me.txtTaxableSearch.Size = New System.Drawing.Size(259, 27)
        Me.txtTaxableSearch.TabIndex = 91379
        Me.txtTaxableSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AllowDrop = True
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(38, 98)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(123, 19)
        Me.Label11.TabIndex = 91378
        Me.Label11.Text = "Basic Amount :"
        '
        'txtbasicAmtSearch
        '
        Me.txtbasicAmtSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtbasicAmtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbasicAmtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtbasicAmtSearch.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtbasicAmtSearch.ForeColor = System.Drawing.Color.Black
        Me.txtbasicAmtSearch.Location = New System.Drawing.Point(179, 96)
        Me.txtbasicAmtSearch.Name = "txtbasicAmtSearch"
        Me.txtbasicAmtSearch.Size = New System.Drawing.Size(259, 27)
        Me.txtbasicAmtSearch.TabIndex = 91377
        Me.txtbasicAmtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AllowDrop = True
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(118, 65)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 19)
        Me.Label10.TabIndex = 91376
        Me.Label10.Text = "Qty :"
        '
        'txtQtySearch
        '
        Me.txtQtySearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtQtySearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQtySearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQtySearch.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtQtySearch.ForeColor = System.Drawing.Color.Black
        Me.txtQtySearch.Location = New System.Drawing.Point(179, 63)
        Me.txtQtySearch.Name = "txtQtySearch"
        Me.txtQtySearch.Size = New System.Drawing.Size(259, 27)
        Me.txtQtySearch.TabIndex = 91375
        Me.txtQtySearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AllowDrop = True
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(57, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 19)
        Me.Label4.TabIndex = 91374
        Me.Label4.Text = "Invoice No. :"
        '
        'txtInvoiceSearch
        '
        Me.txtInvoiceSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtInvoiceSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvoiceSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInvoiceSearch.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtInvoiceSearch.ForeColor = System.Drawing.Color.Black
        Me.txtInvoiceSearch.Location = New System.Drawing.Point(179, 30)
        Me.txtInvoiceSearch.Name = "txtInvoiceSearch"
        Me.txtInvoiceSearch.Size = New System.Drawing.Size(259, 27)
        Me.txtInvoiceSearch.TabIndex = 91372
        Me.txtInvoiceSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Purchase_Register
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1196, 653)
        Me.Controls.Add(Me.pnlSearch)
        Me.Controls.Add(Me.PnlDeleteBills)
        Me.Controls.Add(Me.btnMore)
        Me.Controls.Add(Me.tmpgrid)
        Me.Controls.Add(Me.txtTotTaxable)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtTotTax)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dg1)
        Me.Controls.Add(Me.txtTotRoundOff)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtAccountSearch)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtGrandTotal)
        Me.Controls.Add(Me.txtTotCharges)
        Me.Controls.Add(Me.txtTotDisc)
        Me.Controls.Add(Me.txtTotNet)
        Me.Controls.Add(Me.txtTotQty)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnPrintList)
        Me.Controls.Add(Me.btnShow)
        Me.Controls.Add(Me.MsktoDate)
        Me.Controls.Add(Me.mskFromDate)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.dtp2)
        Me.Controls.Add(Me.dtp1)
        Me.Name = "Purchase_Register"
        Me.Text = "Purchase"
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tmpgrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlDeleteBills.ResumeLayout(False)
        Me.PnlDeleteBills.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSearch.ResumeLayout(False)
        Me.pnlSearch.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dg1 As System.Windows.Forms.DataGridView
    Friend WithEvents txtTotRoundOff As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAccountSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtGrandTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtTotCharges As System.Windows.Forms.TextBox
    Friend WithEvents txtTotDisc As System.Windows.Forms.TextBox
    Friend WithEvents txtTotQty As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btnPrintList As System.Windows.Forms.Button
    Friend WithEvents btnShow As System.Windows.Forms.Button
    Friend WithEvents MsktoDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mskFromDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents dtp2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtTotNet As System.Windows.Forms.TextBox
    Friend WithEvents txtTotTax As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTotTaxable As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tmpgrid As System.Windows.Forms.DataGridView
    Friend WithEvents PnlDeleteBills As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents txtDelete As System.Windows.Forms.TextBox
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnMore As System.Windows.Forms.Button
    Friend WithEvents pnlSearch As System.Windows.Forms.Panel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtTotalSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtTaxableSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtbasicAmtSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtQtySearch As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceSearch As System.Windows.Forms.TextBox
End Class
