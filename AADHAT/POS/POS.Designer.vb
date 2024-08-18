<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class POS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(POS))
        Me.btnMenu = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.dg1 = New System.Windows.Forms.DataGridView()
        Me.txtItemSearch = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtChangeAmt = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtCashAmt = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtTotAmt = New System.Windows.Forms.TextBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CkIGST = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtServiceAmt = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtServicePer = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPackingAmt = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPackingPer = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDiscAmt = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDisPer = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTaxAmt = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtAmt = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnDeleteBill = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtGstNo = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtMobileNo = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtRemark = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCustomerName = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.mskEntryDate = New System.Windows.Forms.MaskedTextBox()
        Me.txtTotQty = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtBillNo = New System.Windows.Forms.TextBox()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.dtp1 = New System.Windows.Forms.DateTimePicker()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnMenu
        '
        Me.btnMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMenu.ForeColor = System.Drawing.Color.GhostWhite
        Me.btnMenu.Location = New System.Drawing.Point(1157, 24)
        Me.btnMenu.Name = "btnMenu"
        Me.btnMenu.Size = New System.Drawing.Size(142, 37)
        Me.btnMenu.TabIndex = 2
        Me.btnMenu.Text = "&Menu"
        Me.btnMenu.UseVisualStyleBackColor = False
        Me.btnMenu.Visible = False
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(503, 67)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(847, 525)
        Me.FlowLayoutPanel1.TabIndex = 3
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.Red
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.ForeColor = System.Drawing.Color.GhostWhite
        Me.btnClose.Location = New System.Drawing.Point(1305, 24)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(45, 37)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "X"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'dg1
        '
        Me.dg1.AllowUserToAddRows = False
        Me.dg1.AllowUserToDeleteRows = False
        Me.dg1.AllowUserToResizeColumns = False
        Me.dg1.AllowUserToResizeRows = False
        Me.dg1.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dg1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg1.DefaultCellStyle = DataGridViewCellStyle2
        Me.dg1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.dg1.GridColor = System.Drawing.Color.Gray
        Me.dg1.Location = New System.Drawing.Point(21, 115)
        Me.dg1.MultiSelect = False
        Me.dg1.Name = "dg1"
        Me.dg1.RowHeadersVisible = False
        Me.dg1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dg1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dg1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg1.Size = New System.Drawing.Size(476, 384)
        Me.dg1.TabIndex = 40321
        '
        'txtItemSearch
        '
        Me.txtItemSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemSearch.Location = New System.Drawing.Point(259, 83)
        Me.txtItemSearch.Name = "txtItemSearch"
        Me.txtItemSearch.Size = New System.Drawing.Size(238, 26)
        Me.txtItemSearch.TabIndex = 40322
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label1.Location = New System.Drawing.Point(187, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 16)
        Me.Label1.TabIndex = 40323
        Me.Label1.Text = "Barcode :"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.txtChangeAmt)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.txtCashAmt)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.txtTotAmt)
        Me.Panel1.Controls.Add(Me.CheckBox2)
        Me.Panel1.Controls.Add(Me.CkIGST)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.txtServiceAmt)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.txtServicePer)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.txtPackingAmt)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.txtPackingPer)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtDiscAmt)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtDisPer)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtTaxAmt)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtAmt)
        Me.Panel1.Location = New System.Drawing.Point(21, 548)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(476, 181)
        Me.Panel1.TabIndex = 40325
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(334, 112)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(125, 20)
        Me.Label16.TabIndex = 40301
        Me.Label16.Text = "Change Amount"
        '
        'txtChangeAmt
        '
        Me.txtChangeAmt.BackColor = System.Drawing.Color.AliceBlue
        Me.txtChangeAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChangeAmt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtChangeAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChangeAmt.ForeColor = System.Drawing.Color.Black
        Me.txtChangeAmt.Location = New System.Drawing.Point(331, 136)
        Me.txtChangeAmt.Name = "txtChangeAmt"
        Me.txtChangeAmt.Size = New System.Drawing.Size(129, 26)
        Me.txtChangeAmt.TabIndex = 40300
        Me.txtChangeAmt.TabStop = False
        Me.txtChangeAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(180, 111)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(106, 20)
        Me.Label15.TabIndex = 40299
        Me.Label15.Text = "Cash Amount"
        '
        'txtCashAmt
        '
        Me.txtCashAmt.BackColor = System.Drawing.Color.AliceBlue
        Me.txtCashAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCashAmt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCashAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCashAmt.ForeColor = System.Drawing.Color.Black
        Me.txtCashAmt.Location = New System.Drawing.Point(169, 135)
        Me.txtCashAmt.Name = "txtCashAmt"
        Me.txtCashAmt.Size = New System.Drawing.Size(129, 26)
        Me.txtCashAmt.TabIndex = 40298
        Me.txtCashAmt.TabStop = False
        Me.txtCashAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(40, 112)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(89, 20)
        Me.Label14.TabIndex = 40297
        Me.Label14.Text = "Bill Amount"
        '
        'txtTotAmt
        '
        Me.txtTotAmt.BackColor = System.Drawing.Color.AliceBlue
        Me.txtTotAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotAmt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotAmt.ForeColor = System.Drawing.Color.Black
        Me.txtTotAmt.Location = New System.Drawing.Point(15, 135)
        Me.txtTotAmt.Name = "txtTotAmt"
        Me.txtTotAmt.ReadOnly = True
        Me.txtTotAmt.Size = New System.Drawing.Size(129, 26)
        Me.txtTotAmt.TabIndex = 40296
        Me.txtTotAmt.TabStop = False
        Me.txtTotAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(382, 36)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(91, 17)
        Me.CheckBox2.TabIndex = 40295
        Me.CheckBox2.Text = "&Whatsapp Bill"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CkIGST
        '
        Me.CkIGST.AutoSize = True
        Me.CkIGST.Location = New System.Drawing.Point(331, 37)
        Me.CkIGST.Name = "CkIGST"
        Me.CkIGST.Size = New System.Drawing.Size(51, 17)
        Me.CkIGST.TabIndex = 40294
        Me.CkIGST.Text = "&IGST"
        Me.CkIGST.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(376, 59)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(61, 20)
        Me.Label12.TabIndex = 40293
        Me.Label12.Text = "Service"
        '
        'txtServiceAmt
        '
        Me.txtServiceAmt.BackColor = System.Drawing.Color.AliceBlue
        Me.txtServiceAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtServiceAmt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtServiceAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtServiceAmt.ForeColor = System.Drawing.Color.Black
        Me.txtServiceAmt.Location = New System.Drawing.Point(360, 82)
        Me.txtServiceAmt.Name = "txtServiceAmt"
        Me.txtServiceAmt.Size = New System.Drawing.Size(100, 26)
        Me.txtServiceAmt.TabIndex = 40292
        Me.txtServiceAmt.TabStop = False
        Me.txtServiceAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(334, 59)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(23, 20)
        Me.Label13.TabIndex = 40291
        Me.Label13.Text = "%"
        '
        'txtServicePer
        '
        Me.txtServicePer.BackColor = System.Drawing.Color.AliceBlue
        Me.txtServicePer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtServicePer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtServicePer.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtServicePer.ForeColor = System.Drawing.Color.Black
        Me.txtServicePer.Location = New System.Drawing.Point(331, 82)
        Me.txtServicePer.Name = "txtServicePer"
        Me.txtServicePer.Size = New System.Drawing.Size(28, 26)
        Me.txtServicePer.TabIndex = 40290
        Me.txtServicePer.TabStop = False
        Me.txtServicePer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(214, 59)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 20)
        Me.Label6.TabIndex = 40289
        Me.Label6.Text = "Packing"
        '
        'txtPackingAmt
        '
        Me.txtPackingAmt.BackColor = System.Drawing.Color.AliceBlue
        Me.txtPackingAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPackingAmt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPackingAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPackingAmt.ForeColor = System.Drawing.Color.Black
        Me.txtPackingAmt.Location = New System.Drawing.Point(198, 82)
        Me.txtPackingAmt.Name = "txtPackingAmt"
        Me.txtPackingAmt.Size = New System.Drawing.Size(100, 26)
        Me.txtPackingAmt.TabIndex = 40288
        Me.txtPackingAmt.TabStop = False
        Me.txtPackingAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(172, 59)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(23, 20)
        Me.Label7.TabIndex = 40287
        Me.Label7.Text = "%"
        '
        'txtPackingPer
        '
        Me.txtPackingPer.BackColor = System.Drawing.Color.AliceBlue
        Me.txtPackingPer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPackingPer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPackingPer.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPackingPer.ForeColor = System.Drawing.Color.Black
        Me.txtPackingPer.Location = New System.Drawing.Point(169, 82)
        Me.txtPackingPer.Name = "txtPackingPer"
        Me.txtPackingPer.Size = New System.Drawing.Size(28, 26)
        Me.txtPackingPer.TabIndex = 40286
        Me.txtPackingPer.TabStop = False
        Me.txtPackingPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(60, 59)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 20)
        Me.Label5.TabIndex = 40284
        Me.Label5.Text = "Discount"
        '
        'txtDiscAmt
        '
        Me.txtDiscAmt.BackColor = System.Drawing.Color.AliceBlue
        Me.txtDiscAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiscAmt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDiscAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiscAmt.ForeColor = System.Drawing.Color.Black
        Me.txtDiscAmt.Location = New System.Drawing.Point(44, 82)
        Me.txtDiscAmt.Name = "txtDiscAmt"
        Me.txtDiscAmt.Size = New System.Drawing.Size(100, 26)
        Me.txtDiscAmt.TabIndex = 40283
        Me.txtDiscAmt.TabStop = False
        Me.txtDiscAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(18, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 20)
        Me.Label3.TabIndex = 40282
        Me.Label3.Text = "%"
        '
        'txtDisPer
        '
        Me.txtDisPer.BackColor = System.Drawing.Color.AliceBlue
        Me.txtDisPer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDisPer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDisPer.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDisPer.ForeColor = System.Drawing.Color.Black
        Me.txtDisPer.Location = New System.Drawing.Point(15, 82)
        Me.txtDisPer.Name = "txtDisPer"
        Me.txtDisPer.Size = New System.Drawing.Size(28, 26)
        Me.txtDisPer.TabIndex = 40281
        Me.txtDisPer.TabStop = False
        Me.txtDisPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(185, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 20)
        Me.Label2.TabIndex = 40280
        Me.Label2.Text = "Tax Amount"
        '
        'txtTaxAmt
        '
        Me.txtTaxAmt.BackColor = System.Drawing.Color.AliceBlue
        Me.txtTaxAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTaxAmt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTaxAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTaxAmt.ForeColor = System.Drawing.Color.Black
        Me.txtTaxAmt.Location = New System.Drawing.Point(169, 30)
        Me.txtTaxAmt.Name = "txtTaxAmt"
        Me.txtTaxAmt.ReadOnly = True
        Me.txtTaxAmt.Size = New System.Drawing.Size(129, 26)
        Me.txtTaxAmt.TabIndex = 40279
        Me.txtTaxAmt.TabStop = False
        Me.txtTaxAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(49, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 20)
        Me.Label4.TabIndex = 40278
        Me.Label4.Text = "Amount"
        '
        'txtAmt
        '
        Me.txtAmt.BackColor = System.Drawing.Color.AliceBlue
        Me.txtAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAmt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmt.ForeColor = System.Drawing.Color.Black
        Me.txtAmt.Location = New System.Drawing.Point(15, 32)
        Me.txtAmt.Name = "txtAmt"
        Me.txtAmt.ReadOnly = True
        Me.txtAmt.Size = New System.Drawing.Size(129, 26)
        Me.txtAmt.TabIndex = 40277
        Me.txtAmt.TabStop = False
        Me.txtAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DodgerBlue
        Me.Panel2.Controls.Add(Me.btnDeleteBill)
        Me.Panel2.Controls.Add(Me.BtnSave)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.txtGstNo)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.txtMobileNo)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.txtRemark)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.txtCustomerName)
        Me.Panel2.Location = New System.Drawing.Point(503, 612)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(847, 117)
        Me.Panel2.TabIndex = 40326
        '
        'btnDeleteBill
        '
        Me.btnDeleteBill.BackColor = System.Drawing.Color.OrangeRed
        Me.btnDeleteBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeleteBill.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteBill.ForeColor = System.Drawing.Color.GhostWhite
        Me.btnDeleteBill.Location = New System.Drawing.Point(584, 55)
        Me.btnDeleteBill.Name = "btnDeleteBill"
        Me.btnDeleteBill.Size = New System.Drawing.Size(102, 47)
        Me.btnDeleteBill.TabIndex = 40333
        Me.btnDeleteBill.Text = "&Delete Bill"
        Me.btnDeleteBill.UseVisualStyleBackColor = False
        Me.btnDeleteBill.Visible = False
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.ForeColor = System.Drawing.Color.GhostWhite
        Me.BtnSave.Location = New System.Drawing.Point(692, 54)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(130, 48)
        Me.BtnSave.TabIndex = 40332
        Me.BtnSave.Text = "&Save N Print"
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label11.Location = New System.Drawing.Point(35, 50)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(79, 16)
        Me.Label11.TabIndex = 40331
        Me.Label11.Text = "Mobile No. :"
        '
        'txtGstNo
        '
        Me.txtGstNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGstNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGstNo.Location = New System.Drawing.Point(131, 76)
        Me.txtGstNo.Name = "txtGstNo"
        Me.txtGstNo.Size = New System.Drawing.Size(238, 26)
        Me.txtGstNo.TabIndex = 40330
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label10.Location = New System.Drawing.Point(21, 82)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(93, 16)
        Me.Label10.TabIndex = 40329
        Me.Label10.Text = "GST Number :"
        '
        'txtMobileNo
        '
        Me.txtMobileNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMobileNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMobileNo.Location = New System.Drawing.Point(131, 44)
        Me.txtMobileNo.Name = "txtMobileNo"
        Me.txtMobileNo.Size = New System.Drawing.Size(238, 26)
        Me.txtMobileNo.TabIndex = 40328
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label9.Location = New System.Drawing.Point(386, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 16)
        Me.Label9.TabIndex = 40327
        Me.Label9.Text = "Remark / Add. :"
        '
        'txtRemark
        '
        Me.txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemark.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemark.Location = New System.Drawing.Point(584, 12)
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(238, 26)
        Me.txtRemark.TabIndex = 40326
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label8.Location = New System.Drawing.Point(3, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(111, 16)
        Me.Label8.TabIndex = 40325
        Me.Label8.Text = "Customer Name :"
        '
        'txtCustomerName
        '
        Me.txtCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomerName.Location = New System.Drawing.Point(131, 12)
        Me.txtCustomerName.Name = "txtCustomerName"
        Me.txtCustomerName.Size = New System.Drawing.Size(238, 26)
        Me.txtCustomerName.TabIndex = 40324
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label18.Location = New System.Drawing.Point(25, 89)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(37, 16)
        Me.Label18.TabIndex = 40328
        Me.Label18.Text = "Date"
        '
        'mskEntryDate
        '
        Me.mskEntryDate.BackColor = System.Drawing.Color.GhostWhite
        Me.mskEntryDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskEntryDate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.mskEntryDate.Location = New System.Drawing.Point(66, 83)
        Me.mskEntryDate.Mask = "00-00-0000"
        Me.mskEntryDate.Name = "mskEntryDate"
        Me.mskEntryDate.Size = New System.Drawing.Size(100, 26)
        Me.mskEntryDate.TabIndex = 40327
        '
        'txtTotQty
        '
        Me.txtTotQty.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.txtTotQty.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotQty.ForeColor = System.Drawing.Color.GhostWhite
        Me.txtTotQty.Location = New System.Drawing.Point(111, 516)
        Me.txtTotQty.Name = "txtTotQty"
        Me.txtTotQty.Size = New System.Drawing.Size(129, 19)
        Me.txtTotQty.TabIndex = 40329
        Me.txtTotQty.TabStop = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label17.Location = New System.Drawing.Point(24, 515)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(88, 20)
        Me.Label17.TabIndex = 40302
        Me.Label17.Text = "Total Qty   :"
        '
        'txtBillNo
        '
        Me.txtBillNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBillNo.Location = New System.Drawing.Point(363, 51)
        Me.txtBillNo.Name = "txtBillNo"
        Me.txtBillNo.Size = New System.Drawing.Size(63, 26)
        Me.txtBillNo.TabIndex = 40330
        Me.txtBillNo.Visible = False
        '
        'txtID
        '
        Me.txtID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtID.Location = New System.Drawing.Point(432, 51)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(63, 26)
        Me.txtID.TabIndex = 40331
        Me.txtID.Visible = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.ForeColor = System.Drawing.Color.DarkTurquoise
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.Location = New System.Drawing.Point(447, 501)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(50, 45)
        Me.btnDelete.TabIndex = 40324
        Me.btnDelete.UseVisualStyleBackColor = False
        Me.btnDelete.Visible = False
        '
        'dtp1
        '
        Me.dtp1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.dtp1.Location = New System.Drawing.Point(66, 83)
        Me.dtp1.Name = "dtp1"
        Me.dtp1.Size = New System.Drawing.Size(116, 26)
        Me.dtp1.TabIndex = 91224
        Me.dtp1.TabStop = False
        '
        'POS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1354, 733)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.txtBillNo)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtTotQty)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.mskEntryDate)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtItemSearch)
        Me.Controls.Add(Me.dg1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.btnMenu)
        Me.Controls.Add(Me.dtp1)
        Me.Name = "POS"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "POS"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnMenu As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents dg1 As System.Windows.Forms.DataGridView
    Friend WithEvents txtItemSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPackingAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPackingPer As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDiscAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDisPer As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTaxAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents mskEntryDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtGstNo As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtMobileNo As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtRemark As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCustomerName As System.Windows.Forms.TextBox
    Friend WithEvents btnDeleteBill As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtServiceAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtServicePer As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtChangeAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtCashAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtTotAmt As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CkIGST As System.Windows.Forms.CheckBox
    Friend WithEvents txtTotQty As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtBillNo As System.Windows.Forms.TextBox
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents dtp1 As System.Windows.Forms.DateTimePicker
End Class
