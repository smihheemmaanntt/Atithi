<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KOT
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(KOT))
        Me.btnCreateTable = New System.Windows.Forms.Button()
        Me.CbType = New System.Windows.Forms.ComboBox()
        Me.lblCode = New System.Windows.Forms.Label()
        Me.lblUnit = New System.Windows.Forms.Label()
        Me.txtItemID = New System.Windows.Forms.TextBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txttotQty = New System.Windows.Forms.TextBox()
        Me.txtTotNet = New System.Windows.Forms.TextBox()
        Me.dgItemSearch = New System.Windows.Forms.DataGridView()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNet = New System.Windows.Forms.TextBox()
        Me.txtRate = New System.Windows.Forms.TextBox()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.txtItem = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbServiceType = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBillNo = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.mskEntryDate = New System.Windows.Forms.MaskedTextBox()
        Me.dg1 = New System.Windows.Forms.DataGridView()
        Me.Dg2 = New System.Windows.Forms.DataGridView()
        Me.lblServiceName = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.LblName = New System.Windows.Forms.Label()
        Me.Dtp1 = New System.Windows.Forms.DateTimePicker()
        Me.pnlInvoiceID = New System.Windows.Forms.Panel()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.txtInvoiceID = New System.Windows.Forms.TextBox()
        Me.btnFirst = New System.Windows.Forms.Button()
        Me.btnLast = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnPrevious = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        CType(Me.dgItemSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dg2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlInvoiceID.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCreateTable
        '
        Me.btnCreateTable.BackColor = System.Drawing.Color.DarkViolet
        Me.btnCreateTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCreateTable.ForeColor = System.Drawing.Color.GhostWhite
        Me.btnCreateTable.Location = New System.Drawing.Point(1156, 63)
        Me.btnCreateTable.Name = "btnCreateTable"
        Me.btnCreateTable.Size = New System.Drawing.Size(26, 26)
        Me.btnCreateTable.TabIndex = 40324
        Me.btnCreateTable.Text = "+"
        Me.btnCreateTable.UseVisualStyleBackColor = False
        '
        'CbType
        '
        Me.CbType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CbType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CbType.BackColor = System.Drawing.Color.GhostWhite
        Me.CbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbType.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.CbType.ForeColor = System.Drawing.Color.Black
        Me.CbType.FormattingEnabled = True
        Me.CbType.Location = New System.Drawing.Point(269, 93)
        Me.CbType.Name = "CbType"
        Me.CbType.Size = New System.Drawing.Size(329, 23)
        Me.CbType.TabIndex = 2
        '
        'lblCode
        '
        Me.lblCode.AutoSize = True
        Me.lblCode.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblCode.ForeColor = System.Drawing.Color.Red
        Me.lblCode.Location = New System.Drawing.Point(375, 141)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Size = New System.Drawing.Size(43, 19)
        Me.lblCode.TabIndex = 91118
        Me.lblCode.Text = "Code"
        Me.lblCode.Visible = False
        '
        'lblUnit
        '
        Me.lblUnit.AutoSize = True
        Me.lblUnit.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblUnit.ForeColor = System.Drawing.Color.Red
        Me.lblUnit.Location = New System.Drawing.Point(444, 141)
        Me.lblUnit.Name = "lblUnit"
        Me.lblUnit.Size = New System.Drawing.Size(34, 19)
        Me.lblUnit.TabIndex = 91117
        Me.lblUnit.Text = "Unit"
        Me.lblUnit.Visible = False
        '
        'txtItemID
        '
        Me.txtItemID.BackColor = System.Drawing.Color.AliceBlue
        Me.txtItemID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemID.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtItemID.ForeColor = System.Drawing.Color.Black
        Me.txtItemID.Location = New System.Drawing.Point(301, 132)
        Me.txtItemID.Name = "txtItemID"
        Me.txtItemID.Size = New System.Drawing.Size(48, 26)
        Me.txtItemID.TabIndex = 40370
        Me.txtItemID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtItemID.Visible = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.Red
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnDelete.ForeColor = System.Drawing.Color.GhostWhite
        Me.btnDelete.Location = New System.Drawing.Point(1042, 569)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(140, 34)
        Me.btnDelete.TabIndex = 40369
        Me.btnDelete.TabStop = False
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.Peru
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.BtnSave.ForeColor = System.Drawing.Color.GhostWhite
        Me.BtnSave.Location = New System.Drawing.Point(1042, 608)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(140, 34)
        Me.BtnSave.TabIndex = 40368
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Navy
        Me.Label9.Location = New System.Drawing.Point(817, 584)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 19)
        Me.Label9.TabIndex = 40367
        Me.Label9.Text = "Total Amount"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Navy
        Me.Label10.Location = New System.Drawing.Point(704, 582)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 19)
        Me.Label10.TabIndex = 40366
        Me.Label10.Text = "Total Qty"
        '
        'txttotQty
        '
        Me.txttotQty.BackColor = System.Drawing.Color.GhostWhite
        Me.txttotQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txttotQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txttotQty.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txttotQty.ForeColor = System.Drawing.Color.Black
        Me.txttotQty.Location = New System.Drawing.Point(648, 608)
        Me.txttotQty.Name = "txttotQty"
        Me.txttotQty.ReadOnly = True
        Me.txttotQty.Size = New System.Drawing.Size(138, 32)
        Me.txttotQty.TabIndex = 40343
        Me.txttotQty.TabStop = False
        Me.txttotQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotNet
        '
        Me.txtTotNet.BackColor = System.Drawing.Color.GhostWhite
        Me.txtTotNet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotNet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotNet.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtTotNet.ForeColor = System.Drawing.Color.Black
        Me.txtTotNet.Location = New System.Drawing.Point(797, 608)
        Me.txtTotNet.Name = "txtTotNet"
        Me.txtTotNet.ReadOnly = True
        Me.txtTotNet.Size = New System.Drawing.Size(138, 32)
        Me.txtTotNet.TabIndex = 40342
        Me.txtTotNet.TabStop = False
        Me.txtTotNet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgItemSearch
        '
        Me.dgItemSearch.AllowUserToAddRows = False
        Me.dgItemSearch.AllowUserToDeleteRows = False
        Me.dgItemSearch.AllowUserToResizeRows = False
        Me.dgItemSearch.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgItemSearch.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgItemSearch.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgItemSearch.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgItemSearch.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgItemSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgItemSearch.ColumnHeadersVisible = False
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Orange
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgItemSearch.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgItemSearch.GridColor = System.Drawing.Color.Gray
        Me.dgItemSearch.Location = New System.Drawing.Point(13, 192)
        Me.dgItemSearch.MultiSelect = False
        Me.dgItemSearch.Name = "dgItemSearch"
        Me.dgItemSearch.ReadOnly = True
        Me.dgItemSearch.RowHeadersVisible = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.GhostWhite
        Me.dgItemSearch.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgItemSearch.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dgItemSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgItemSearch.Size = New System.Drawing.Size(473, 246)
        Me.dgItemSearch.TabIndex = 40333
        Me.dgItemSearch.TabStop = False
        Me.dgItemSearch.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(860, 138)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 19)
        Me.Label8.TabIndex = 40332
        Me.Label8.Text = "Amount"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(689, 138)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 19)
        Me.Label7.TabIndex = 40331
        Me.Label7.Text = "Rate"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(559, 138)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 19)
        Me.Label6.TabIndex = 40330
        Me.Label6.Text = "Qty"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(15, 135)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(154, 19)
        Me.Label5.TabIndex = 40329
        Me.Label5.Text = "Item Name / Item Code"
        '
        'txtNet
        '
        Me.txtNet.BackColor = System.Drawing.Color.GhostWhite
        Me.txtNet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNet.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtNet.ForeColor = System.Drawing.Color.Black
        Me.txtNet.Location = New System.Drawing.Point(735, 165)
        Me.txtNet.Name = "txtNet"
        Me.txtNet.ReadOnly = True
        Me.txtNet.Size = New System.Drawing.Size(200, 26)
        Me.txtNet.TabIndex = 8
        Me.txtNet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRate
        '
        Me.txtRate.BackColor = System.Drawing.Color.GhostWhite
        Me.txtRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtRate.ForeColor = System.Drawing.Color.Black
        Me.txtRate.Location = New System.Drawing.Point(597, 165)
        Me.txtRate.Name = "txtRate"
        Me.txtRate.Size = New System.Drawing.Size(140, 26)
        Me.txtRate.TabIndex = 7
        Me.txtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtQty
        '
        Me.txtQty.BackColor = System.Drawing.Color.GhostWhite
        Me.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQty.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtQty.ForeColor = System.Drawing.Color.Black
        Me.txtQty.Location = New System.Drawing.Point(484, 165)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(114, 26)
        Me.txtQty.TabIndex = 6
        Me.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtItem
        '
        Me.txtItem.BackColor = System.Drawing.Color.GhostWhite
        Me.txtItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItem.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtItem.ForeColor = System.Drawing.Color.Black
        Me.txtItem.Location = New System.Drawing.Point(12, 165)
        Me.txtItem.Name = "txtItem"
        Me.txtItem.Size = New System.Drawing.Size(473, 26)
        Me.txtItem.TabIndex = 5
        Me.txtItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(595, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 19)
        Me.Label3.TabIndex = 40317
        Me.Label3.Text = "Service Type"
        '
        'cbServiceType
        '
        Me.cbServiceType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbServiceType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbServiceType.BackColor = System.Drawing.Color.GhostWhite
        Me.cbServiceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbServiceType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbServiceType.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.cbServiceType.ForeColor = System.Drawing.Color.Black
        Me.cbServiceType.FormattingEnabled = True
        Me.cbServiceType.Items.AddRange(New Object() {"New KOT", "Next KOT", "Room Service", "Packing/Home Delivery", "Bar"})
        Me.cbServiceType.Location = New System.Drawing.Point(598, 93)
        Me.cbServiceType.Name = "cbServiceType"
        Me.cbServiceType.Size = New System.Drawing.Size(336, 23)
        Me.cbServiceType.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(265, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 19)
        Me.Label1.TabIndex = 40315
        Me.Label1.Text = "Attender Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(131, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 19)
        Me.Label2.TabIndex = 40313
        Me.Label2.Text = "K.O.T. No."
        '
        'txtBillNo
        '
        Me.txtBillNo.BackColor = System.Drawing.Color.GhostWhite
        Me.txtBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBillNo.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtBillNo.ForeColor = System.Drawing.Color.Black
        Me.txtBillNo.Location = New System.Drawing.Point(135, 92)
        Me.txtBillNo.Name = "txtBillNo"
        Me.txtBillNo.Size = New System.Drawing.Size(134, 26)
        Me.txtBillNo.TabIndex = 1
        Me.txtBillNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(12, 64)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(38, 19)
        Me.Label18.TabIndex = 40311
        Me.Label18.Text = "Date"
        '
        'mskEntryDate
        '
        Me.mskEntryDate.BackColor = System.Drawing.Color.GhostWhite
        Me.mskEntryDate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.mskEntryDate.ForeColor = System.Drawing.Color.Black
        Me.mskEntryDate.Location = New System.Drawing.Point(16, 92)
        Me.mskEntryDate.Mask = "00-00-0000"
        Me.mskEntryDate.Name = "mskEntryDate"
        Me.mskEntryDate.Size = New System.Drawing.Size(103, 26)
        Me.mskEntryDate.TabIndex = 0
        '
        'dg1
        '
        Me.dg1.AllowUserToAddRows = False
        Me.dg1.AllowUserToDeleteRows = False
        Me.dg1.AllowUserToResizeRows = False
        Me.dg1.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dg1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Crimson
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Crimson
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Orange
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg1.DefaultCellStyle = DataGridViewCellStyle5
        Me.dg1.EnableHeadersVisualStyles = False
        Me.dg1.GridColor = System.Drawing.Color.Crimson
        Me.dg1.Location = New System.Drawing.Point(12, 190)
        Me.dg1.Name = "dg1"
        Me.dg1.ReadOnly = True
        Me.dg1.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dg1.RowHeadersVisible = False
        Me.dg1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dg1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg1.Size = New System.Drawing.Size(923, 373)
        Me.dg1.TabIndex = 40324
        '
        'Dg2
        '
        Me.Dg2.AllowUserToAddRows = False
        Me.Dg2.AllowUserToDeleteRows = False
        Me.Dg2.AllowUserToResizeColumns = False
        Me.Dg2.AllowUserToResizeRows = False
        Me.Dg2.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.Dg2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Crimson
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Crimson
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dg2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.Dg2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Orange
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Dg2.DefaultCellStyle = DataGridViewCellStyle8
        Me.Dg2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.Dg2.EnableHeadersVisualStyles = False
        Me.Dg2.GridColor = System.Drawing.Color.Crimson
        Me.Dg2.Location = New System.Drawing.Point(955, 92)
        Me.Dg2.Name = "Dg2"
        Me.Dg2.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.Dg2.RowHeadersVisible = False
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.GhostWhite
        Me.Dg2.RowsDefaultCellStyle = DataGridViewCellStyle9
        Me.Dg2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Dg2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dg2.Size = New System.Drawing.Size(227, 472)
        Me.Dg2.TabIndex = 4
        '
        'lblServiceName
        '
        Me.lblServiceName.AutoSize = True
        Me.lblServiceName.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblServiceName.ForeColor = System.Drawing.Color.Black
        Me.lblServiceName.Location = New System.Drawing.Point(951, 64)
        Me.lblServiceName.Name = "lblServiceName"
        Me.lblServiceName.Size = New System.Drawing.Size(93, 19)
        Me.lblServiceName.TabIndex = 40323
        Me.lblServiceName.Text = "Choose Table"
        '
        'txtID
        '
        Me.txtID.BackColor = System.Drawing.Color.AliceBlue
        Me.txtID.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtID.ForeColor = System.Drawing.Color.Black
        Me.txtID.Location = New System.Drawing.Point(61, 12)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(46, 26)
        Me.txtID.TabIndex = 40244
        Me.txtID.Visible = False
        '
        'LblName
        '
        Me.LblName.AutoSize = True
        Me.LblName.Font = New System.Drawing.Font("Bodoni Bk BT", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblName.ForeColor = System.Drawing.Color.Black
        Me.LblName.Location = New System.Drawing.Point(448, 4)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(256, 48)
        Me.LblName.TabIndex = 101
        Me.LblName.Text = "K.O.T. ENTRY"
        '
        'Dtp1
        '
        Me.Dtp1.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Dtp1.Location = New System.Drawing.Point(28, 92)
        Me.Dtp1.Name = "Dtp1"
        Me.Dtp1.Size = New System.Drawing.Size(108, 26)
        Me.Dtp1.TabIndex = 91231
        '
        'pnlInvoiceID
        '
        Me.pnlInvoiceID.Controls.Add(Me.Label56)
        Me.pnlInvoiceID.Controls.Add(Me.txtInvoiceID)
        Me.pnlInvoiceID.Location = New System.Drawing.Point(135, 118)
        Me.pnlInvoiceID.Name = "pnlInvoiceID"
        Me.pnlInvoiceID.Size = New System.Drawing.Size(178, 74)
        Me.pnlInvoiceID.TabIndex = 91250
        Me.pnlInvoiceID.Visible = False
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label56.ForeColor = System.Drawing.Color.Black
        Me.Label56.Location = New System.Drawing.Point(3, 10)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(73, 19)
        Me.Label56.TabIndex = 40073
        Me.Label56.Text = "Invoice ID"
        '
        'txtInvoiceID
        '
        Me.txtInvoiceID.BackColor = System.Drawing.Color.GhostWhite
        Me.txtInvoiceID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvoiceID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInvoiceID.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtInvoiceID.ForeColor = System.Drawing.Color.Black
        Me.txtInvoiceID.Location = New System.Drawing.Point(2, 37)
        Me.txtInvoiceID.Name = "txtInvoiceID"
        Me.txtInvoiceID.Size = New System.Drawing.Size(164, 26)
        Me.txtInvoiceID.TabIndex = 2
        Me.txtInvoiceID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnFirst
        '
        Me.btnFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFirst.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnFirst.ForeColor = System.Drawing.Color.Navy
        Me.btnFirst.Location = New System.Drawing.Point(11, 570)
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.Size = New System.Drawing.Size(44, 23)
        Me.btnFirst.TabIndex = 91260
        Me.btnFirst.TabStop = False
        Me.btnFirst.Text = "|<"
        Me.btnFirst.UseVisualStyleBackColor = True
        '
        'btnLast
        '
        Me.btnLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLast.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnLast.ForeColor = System.Drawing.Color.Navy
        Me.btnLast.Location = New System.Drawing.Point(161, 570)
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(44, 23)
        Me.btnLast.TabIndex = 91259
        Me.btnLast.TabStop = False
        Me.btnLast.Text = ">|"
        Me.btnLast.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNext.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnNext.ForeColor = System.Drawing.Color.Navy
        Me.btnNext.Location = New System.Drawing.Point(111, 570)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(44, 23)
        Me.btnNext.TabIndex = 91258
        Me.btnNext.TabStop = False
        Me.btnNext.Text = ">>"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnPrevious
        '
        Me.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrevious.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnPrevious.ForeColor = System.Drawing.Color.Navy
        Me.btnPrevious.Location = New System.Drawing.Point(61, 570)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(44, 23)
        Me.btnPrevious.TabIndex = 91257
        Me.btnPrevious.TabStop = False
        Me.btnPrevious.Text = "<<"
        Me.btnPrevious.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Red
        Me.Button2.Location = New System.Drawing.Point(211, 570)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(85, 23)
        Me.Button2.TabIndex = 91261
        Me.Button2.TabStop = False
        Me.Button2.Text = "&Reset"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(1153, 1)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(40, 40)
        Me.btnClose.TabIndex = 91210
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(392, 2)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox4.TabIndex = 91209
        Me.PictureBox4.TabStop = False
        '
        'KOT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1194, 653)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnFirst)
        Me.Controls.Add(Me.btnLast)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnPrevious)
        Me.Controls.Add(Me.pnlInvoiceID)
        Me.Controls.Add(Me.mskEntryDate)
        Me.Controls.Add(Me.Dtp1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.lblServiceName)
        Me.Controls.Add(Me.Dg2)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.btnCreateTable)
        Me.Controls.Add(Me.LblName)
        Me.Controls.Add(Me.CbType)
        Me.Controls.Add(Me.lblCode)
        Me.Controls.Add(Me.lblUnit)
        Me.Controls.Add(Me.txtItemID)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.txtBillNo)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txttotQty)
        Me.Controls.Add(Me.cbServiceType)
        Me.Controls.Add(Me.txtTotNet)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dgItemSearch)
        Me.Controls.Add(Me.txtItem)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtQty)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtRate)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtNet)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dg1)
        Me.Name = "KOT"
        Me.Text = "KOT"
        CType(Me.dgItemSearch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dg2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlInvoiceID.ResumeLayout(False)
        Me.pnlInvoiceID.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents LblName As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents mskEntryDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBillNo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbServiceType As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CbType As System.Windows.Forms.ComboBox
    Friend WithEvents Dg2 As System.Windows.Forms.DataGridView
    Friend WithEvents lblServiceName As System.Windows.Forms.Label
    Friend WithEvents dg1 As System.Windows.Forms.DataGridView
    Friend WithEvents txtItem As System.Windows.Forms.TextBox
    Friend WithEvents txtQty As System.Windows.Forms.TextBox
    Friend WithEvents txtRate As System.Windows.Forms.TextBox
    Friend WithEvents txtNet As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dgItemSearch As System.Windows.Forms.DataGridView
    Friend WithEvents txttotQty As System.Windows.Forms.TextBox
    Friend WithEvents txtTotNet As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents txtItemID As System.Windows.Forms.TextBox
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents lblUnit As System.Windows.Forms.Label
    Friend WithEvents btnCreateTable As System.Windows.Forms.Button
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Dtp1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents pnlInvoiceID As System.Windows.Forms.Panel
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceID As System.Windows.Forms.TextBox
    Friend WithEvents btnFirst As System.Windows.Forms.Button
    Friend WithEvents btnLast As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnPrevious As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
