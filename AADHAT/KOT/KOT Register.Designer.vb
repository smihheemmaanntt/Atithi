<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KOT_Register
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(KOT_Register))
        Me.btnShow = New System.Windows.Forms.Button()
        Me.MsktoDate = New System.Windows.Forms.MaskedTextBox()
        Me.mskFromDate = New System.Windows.Forms.MaskedTextBox()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtRate = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtKotNo = New System.Windows.Forms.TextBox()
        Me.txtAttenderName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCustomerSearch = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txttotQty = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtTotTotal = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTable = New System.Windows.Forms.TextBox()
        Me.dg1 = New System.Windows.Forms.DataGridView()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.dtp2 = New System.Windows.Forms.DateTimePicker()
        Me.dtp1 = New System.Windows.Forms.DateTimePicker()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.btnClose = New System.Windows.Forms.Button()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnShow
        '
        Me.btnShow.BackColor = System.Drawing.Color.Salmon
        Me.btnShow.FlatAppearance.BorderSize = 0
        Me.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShow.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnShow.ForeColor = System.Drawing.Color.GhostWhite
        Me.btnShow.Location = New System.Drawing.Point(416, 77)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(76, 27)
        Me.btnShow.TabIndex = 2
        Me.btnShow.Text = "&Show"
        Me.btnShow.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnShow.UseVisualStyleBackColor = False
        '
        'MsktoDate
        '
        Me.MsktoDate.BackColor = System.Drawing.Color.GhostWhite
        Me.MsktoDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MsktoDate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MsktoDate.Location = New System.Drawing.Point(299, 77)
        Me.MsktoDate.Mask = "00-00-0000"
        Me.MsktoDate.Name = "MsktoDate"
        Me.MsktoDate.Size = New System.Drawing.Size(100, 27)
        Me.MsktoDate.TabIndex = 1
        '
        'mskFromDate
        '
        Me.mskFromDate.BackColor = System.Drawing.Color.GhostWhite
        Me.mskFromDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskFromDate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskFromDate.Location = New System.Drawing.Point(103, 77)
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
        Me.BtnPrint.Location = New System.Drawing.Point(492, 77)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(76, 27)
        Me.BtnPrint.TabIndex = 3
        Me.BtnPrint.Text = "&Print"
        Me.BtnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnPrint.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(1130, 105)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 21)
        Me.Label7.TabIndex = 40220
        Me.Label7.Text = "Total"
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.GhostWhite
        Me.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotal.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtTotal.ForeColor = System.Drawing.Color.Black
        Me.txtTotal.Location = New System.Drawing.Point(1079, 130)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(100, 27)
        Me.txtTotal.TabIndex = 11
        Me.txtTotal.TabStop = False
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(945, 108)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 21)
        Me.Label5.TabIndex = 40218
        Me.Label5.Text = "Qty"
        '
        'txtRate
        '
        Me.txtRate.BackColor = System.Drawing.Color.GhostWhite
        Me.txtRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtRate.ForeColor = System.Drawing.Color.Black
        Me.txtRate.Location = New System.Drawing.Point(986, 130)
        Me.txtRate.Name = "txtRate"
        Me.txtRate.Size = New System.Drawing.Size(94, 27)
        Me.txtRate.TabIndex = 10
        Me.txtRate.TabStop = False
        Me.txtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(1014, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 21)
        Me.Label4.TabIndex = 40216
        Me.Label4.Text = "Rate"
        '
        'txtQty
        '
        Me.txtQty.BackColor = System.Drawing.Color.GhostWhite
        Me.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQty.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtQty.ForeColor = System.Drawing.Color.Black
        Me.txtQty.Location = New System.Drawing.Point(907, 130)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(80, 27)
        Me.txtQty.TabIndex = 9
        Me.txtQty.TabStop = False
        Me.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(11, 108)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 21)
        Me.Label3.TabIndex = 40214
        Me.Label3.Text = "KOT No"
        '
        'txtKotNo
        '
        Me.txtKotNo.BackColor = System.Drawing.Color.GhostWhite
        Me.txtKotNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKotNo.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtKotNo.ForeColor = System.Drawing.Color.Black
        Me.txtKotNo.Location = New System.Drawing.Point(9, 130)
        Me.txtKotNo.Name = "txtKotNo"
        Me.txtKotNo.Size = New System.Drawing.Size(102, 27)
        Me.txtKotNo.TabIndex = 4
        Me.txtKotNo.TabStop = False
        Me.txtKotNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtAttenderName
        '
        Me.txtAttenderName.BackColor = System.Drawing.Color.GhostWhite
        Me.txtAttenderName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAttenderName.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtAttenderName.ForeColor = System.Drawing.Color.Black
        Me.txtAttenderName.Location = New System.Drawing.Point(110, 130)
        Me.txtAttenderName.Name = "txtAttenderName"
        Me.txtAttenderName.Size = New System.Drawing.Size(251, 27)
        Me.txtAttenderName.TabIndex = 5
        Me.txtAttenderName.TabStop = False
        Me.txtAttenderName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(634, 105)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 21)
        Me.Label6.TabIndex = 40208
        Me.Label6.Text = "Item Name"
        '
        'txtCustomerSearch
        '
        Me.txtCustomerSearch.BackColor = System.Drawing.Color.GhostWhite
        Me.txtCustomerSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerSearch.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtCustomerSearch.ForeColor = System.Drawing.Color.Black
        Me.txtCustomerSearch.Location = New System.Drawing.Point(638, 130)
        Me.txtCustomerSearch.Name = "txtCustomerSearch"
        Me.txtCustomerSearch.Size = New System.Drawing.Size(270, 27)
        Me.txtCustomerSearch.TabIndex = 8
        Me.txtCustomerSearch.TabStop = False
        Me.txtCustomerSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Bodoni Bk BT", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.Black
        Me.Label41.Location = New System.Drawing.Point(429, 2)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(315, 48)
        Me.Label41.TabIndex = 91111
        Me.Label41.Text = "K.O.T. REGISTER"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(104, 105)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(135, 21)
        Me.Label1.TabIndex = 40210
        Me.Label1.Text = "Attender Name"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(17, 627)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(77, 17)
        Me.Label24.TabIndex = 40185
        Me.Label24.Text = "ItemName"
        Me.Label24.Visible = False
        '
        'txttotQty
        '
        Me.txttotQty.BackColor = System.Drawing.Color.GhostWhite
        Me.txttotQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txttotQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txttotQty.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txttotQty.ForeColor = System.Drawing.Color.Black
        Me.txttotQty.Location = New System.Drawing.Point(1016, 621)
        Me.txttotQty.Name = "txttotQty"
        Me.txttotQty.ReadOnly = True
        Me.txttotQty.Size = New System.Drawing.Size(67, 27)
        Me.txttotQty.TabIndex = 91169
        Me.txttotQty.TabStop = False
        Me.txttotQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label16.ForeColor = System.Drawing.Color.Navy
        Me.Label16.Location = New System.Drawing.Point(1052, 598)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(35, 19)
        Me.Label16.TabIndex = 91170
        Me.Label16.Text = "Qty"
        '
        'txtTotTotal
        '
        Me.txtTotTotal.BackColor = System.Drawing.Color.GhostWhite
        Me.txtTotTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotTotal.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtTotTotal.ForeColor = System.Drawing.Color.Black
        Me.txtTotTotal.Location = New System.Drawing.Point(1082, 621)
        Me.txtTotTotal.Name = "txtTotTotal"
        Me.txtTotTotal.ReadOnly = True
        Me.txtTotTotal.Size = New System.Drawing.Size(100, 27)
        Me.txtTotTotal.TabIndex = 91182
        Me.txtTotTotal.TabStop = False
        Me.txtTotTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label23.ForeColor = System.Drawing.Color.Navy
        Me.Label23.Location = New System.Drawing.Point(1109, 599)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(71, 19)
        Me.Label23.TabIndex = 91183
        Me.Label23.Text = "Amount"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.CadetBlue
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label10.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label10.Location = New System.Drawing.Point(219, 77)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 27)
        Me.Label10.TabIndex = 91187
        Me.Label10.Text = "To Date"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.CadetBlue
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label9.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label9.Location = New System.Drawing.Point(11, 77)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(92, 27)
        Me.Label9.TabIndex = 91186
        Me.Label9.Text = "From Date"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(485, 105)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(139, 21)
        Me.Label8.TabIndex = 91185
        Me.Label8.Text = "Table / Room No"
        '
        'txtTable
        '
        Me.txtTable.BackColor = System.Drawing.Color.GhostWhite
        Me.txtTable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTable.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtTable.ForeColor = System.Drawing.Color.Black
        Me.txtTable.Location = New System.Drawing.Point(489, 130)
        Me.txtTable.Name = "txtTable"
        Me.txtTable.Size = New System.Drawing.Size(150, 27)
        Me.txtTable.TabIndex = 7
        Me.txtTable.TabStop = False
        Me.txtTable.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.CadetBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg1.DefaultCellStyle = DataGridViewCellStyle2
        Me.dg1.EnableHeadersVisualStyles = False
        Me.dg1.GridColor = System.Drawing.Color.Gray
        Me.dg1.Location = New System.Drawing.Point(9, 156)
        Me.dg1.MultiSelect = False
        Me.dg1.Name = "dg1"
        Me.dg1.ReadOnly = True
        Me.dg1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dg1.RowHeadersVisible = False
        Me.dg1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dg1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dg1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg1.Size = New System.Drawing.Size(1170, 435)
        Me.dg1.TabIndex = 91202
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(360, 105)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 21)
        Me.Label11.TabIndex = 91212
        Me.Label11.Text = "Service"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.GhostWhite
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.Black
        Me.TextBox1.Location = New System.Drawing.Point(360, 130)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(130, 27)
        Me.TextBox1.TabIndex = 6
        Me.TextBox1.TabStop = False
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dtp2
        '
        Me.dtp2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.dtp2.Location = New System.Drawing.Point(307, 77)
        Me.dtp2.Name = "dtp2"
        Me.dtp2.Size = New System.Drawing.Size(109, 27)
        Me.dtp2.TabIndex = 91213
        '
        'dtp1
        '
        Me.dtp1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.dtp1.Location = New System.Drawing.Point(110, 77)
        Me.dtp1.Name = "dtp1"
        Me.dtp1.Size = New System.Drawing.Size(109, 27)
        Me.dtp1.TabIndex = 91214
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(373, 2)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox4.TabIndex = 91210
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
        Me.btnClose.TabIndex = 91203
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'KOT_Register
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1194, 653)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.dg1)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtTable)
        Me.Controls.Add(Me.txtTotTotal)
        Me.Controls.Add(Me.btnShow)
        Me.Controls.Add(Me.txttotQty)
        Me.Controls.Add(Me.MsktoDate)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.mskFromDate)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtAttenderName)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtCustomerSearch)
        Me.Controls.Add(Me.txtRate)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtQty)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtKotNo)
        Me.Controls.Add(Me.dtp1)
        Me.Controls.Add(Me.dtp2)
        Me.Name = "KOT_Register"
        Me.Text = "KOT_Register"
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnShow As System.Windows.Forms.Button
    Friend WithEvents MsktoDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mskFromDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtRate As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtQty As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtKotNo As System.Windows.Forms.TextBox
    Friend WithEvents txtAttenderName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCustomerSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txttotQty As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtTotTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTable As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dg1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents dtp2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp1 As System.Windows.Forms.DateTimePicker
End Class
