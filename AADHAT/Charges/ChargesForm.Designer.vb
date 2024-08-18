<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChargesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChargesForm))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TxtChargeName = New System.Windows.Forms.TextBox()
        Me.txtCalculate = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbAccountName = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblGst = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.LblCharges = New System.Windows.Forms.Label()
        Me.btnRetrive = New System.Windows.Forms.Button()
        Me.CkRoundOff = New System.Windows.Forms.CheckBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.cbApply = New System.Windows.Forms.ComboBox()
        Me.cbTaxPer = New System.Windows.Forms.ComboBox()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.dg1 = New System.Windows.Forms.DataGridView()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.txtChargesHSN = New System.Windows.Forms.TextBox()
        Me.lblHsn = New System.Windows.Forms.Label()
        Me.cbFixas = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbSupply = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbChargesType = New System.Windows.Forms.ComboBox()
        Me.cbApplyType = New System.Windows.Forms.ComboBox()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtChargeName
        '
        Me.TxtChargeName.BackColor = System.Drawing.Color.GhostWhite
        Me.TxtChargeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtChargeName.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TxtChargeName.Location = New System.Drawing.Point(12, 135)
        Me.TxtChargeName.Name = "TxtChargeName"
        Me.TxtChargeName.Size = New System.Drawing.Size(211, 27)
        Me.TxtChargeName.TabIndex = 0
        Me.TxtChargeName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCalculate
        '
        Me.txtCalculate.BackColor = System.Drawing.Color.GhostWhite
        Me.txtCalculate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCalculate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtCalculate.Location = New System.Drawing.Point(222, 135)
        Me.txtCalculate.Name = "txtCalculate"
        Me.txtCalculate.Size = New System.Drawing.Size(113, 27)
        Me.txtCalculate.TabIndex = 1
        Me.txtCalculate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(12, 108)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 21)
        Me.Label2.TabIndex = 109
        Me.Label2.Text = "Charge Name"
        '
        'cbAccountName
        '
        Me.cbAccountName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbAccountName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbAccountName.BackColor = System.Drawing.Color.GhostWhite
        Me.cbAccountName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAccountName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbAccountName.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.cbAccountName.ForeColor = System.Drawing.Color.Black
        Me.cbAccountName.FormattingEnabled = True
        Me.cbAccountName.Location = New System.Drawing.Point(335, 136)
        Me.cbAccountName.Name = "cbAccountName"
        Me.cbAccountName.Size = New System.Drawing.Size(391, 25)
        Me.cbAccountName.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(222, 108)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 21)
        Me.Label1.TabIndex = 110
        Me.Label1.Text = "Calculate"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(337, 108)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(166, 21)
        Me.Label3.TabIndex = 111
        Me.Label3.Text = "Account to be  Post"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(990, 107)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 21)
        Me.Label4.TabIndex = 115
        Me.Label4.Text = "Apply on"
        '
        'lblGst
        '
        Me.lblGst.AutoSize = True
        Me.lblGst.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblGst.ForeColor = System.Drawing.Color.Black
        Me.lblGst.Location = New System.Drawing.Point(104, 162)
        Me.lblGst.Name = "lblGst"
        Me.lblGst.Size = New System.Drawing.Size(40, 21)
        Me.lblGst.TabIndex = 117
        Me.lblGst.Text = "GST"
        Me.lblGst.Visible = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Red
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(1143, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(53, 47)
        Me.btnClose.TabIndex = 91118
        Me.btnClose.TabStop = False
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'LblCharges
        '
        Me.LblCharges.AutoSize = True
        Me.LblCharges.Font = New System.Drawing.Font("Bodoni Bk BT", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCharges.ForeColor = System.Drawing.Color.Black
        Me.LblCharges.Location = New System.Drawing.Point(440, 9)
        Me.LblCharges.Name = "LblCharges"
        Me.LblCharges.Size = New System.Drawing.Size(326, 48)
        Me.LblCharges.TabIndex = 101
        Me.LblCharges.Text = "CHARGES ENTRY"
        '
        'btnRetrive
        '
        Me.btnRetrive.BackColor = System.Drawing.Color.Black
        Me.btnRetrive.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRetrive.ForeColor = System.Drawing.Color.Red
        Me.btnRetrive.Location = New System.Drawing.Point(1143, 0)
        Me.btnRetrive.Name = "btnRetrive"
        Me.btnRetrive.Size = New System.Drawing.Size(51, 43)
        Me.btnRetrive.TabIndex = 91112
        Me.btnRetrive.TabStop = False
        Me.btnRetrive.Text = "R"
        Me.btnRetrive.UseVisualStyleBackColor = False
        '
        'CkRoundOff
        '
        Me.CkRoundOff.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CkRoundOff.ForeColor = System.Drawing.Color.Navy
        Me.CkRoundOff.Location = New System.Drawing.Point(958, 186)
        Me.CkRoundOff.Name = "CkRoundOff"
        Me.CkRoundOff.Size = New System.Drawing.Size(104, 33)
        Me.CkRoundOff.TabIndex = 10
        Me.CkRoundOff.Text = "&Round off"
        Me.CkRoundOff.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.DarkTurquoise
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.GhostWhite
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(1068, 172)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(116, 51)
        Me.btnSave.TabIndex = 11
        Me.btnSave.Text = "&Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'BtnDelete
        '
        Me.BtnDelete.BackColor = System.Drawing.Color.DarkRed
        Me.BtnDelete.FlatAppearance.BorderSize = 0
        Me.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDelete.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.BtnDelete.ForeColor = System.Drawing.Color.GhostWhite
        Me.BtnDelete.Image = CType(resources.GetObject("BtnDelete.Image"), System.Drawing.Image)
        Me.BtnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnDelete.Location = New System.Drawing.Point(1068, 608)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(116, 37)
        Me.BtnDelete.TabIndex = 9
        Me.BtnDelete.TabStop = False
        Me.BtnDelete.Text = "&Delete"
        Me.BtnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnDelete.UseVisualStyleBackColor = False
        '
        'cbApply
        '
        Me.cbApply.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbApply.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbApply.BackColor = System.Drawing.Color.GhostWhite
        Me.cbApply.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbApply.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.cbApply.ForeColor = System.Drawing.Color.Black
        Me.cbApply.FormattingEnabled = True
        Me.cbApply.Items.AddRange(New Object() {"Taxable Amount", "Item Total"})
        Me.cbApply.Location = New System.Drawing.Point(985, 136)
        Me.cbApply.Name = "cbApply"
        Me.cbApply.Size = New System.Drawing.Size(199, 25)
        Me.cbApply.TabIndex = 4
        '
        'cbTaxPer
        '
        Me.cbTaxPer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbTaxPer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbTaxPer.BackColor = System.Drawing.Color.GhostWhite
        Me.cbTaxPer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTaxPer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbTaxPer.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.cbTaxPer.ForeColor = System.Drawing.Color.Black
        Me.cbTaxPer.FormattingEnabled = True
        Me.cbTaxPer.Location = New System.Drawing.Point(12, 190)
        Me.cbTaxPer.Name = "cbTaxPer"
        Me.cbTaxPer.Size = New System.Drawing.Size(211, 25)
        Me.cbTaxPer.TabIndex = 5
        Me.cbTaxPer.Visible = False
        '
        'txtID
        '
        Me.txtID.BackColor = System.Drawing.Color.AliceBlue
        Me.txtID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtID.Location = New System.Drawing.Point(1085, 77)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(99, 26)
        Me.txtID.TabIndex = 12
        Me.txtID.TabStop = False
        Me.txtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtID.Visible = False
        '
        'dg1
        '
        Me.dg1.AllowUserToAddRows = False
        Me.dg1.AllowUserToDeleteRows = False
        Me.dg1.AllowUserToResizeRows = False
        Me.dg1.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dg1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Crimson
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dg1.ColumnHeadersHeight = 28
        Me.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DarkTurquoise
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg1.DefaultCellStyle = DataGridViewCellStyle5
        Me.dg1.EnableHeadersVisualStyles = False
        Me.dg1.GridColor = System.Drawing.Color.Crimson
        Me.dg1.Location = New System.Drawing.Point(12, 223)
        Me.dg1.Name = "dg1"
        Me.dg1.ReadOnly = True
        Me.dg1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dg1.RowHeadersVisible = False
        Me.dg1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        Me.dg1.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dg1.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.dg1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dg1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dg1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg1.Size = New System.Drawing.Size(1172, 374)
        Me.dg1.TabIndex = 13
        Me.dg1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(384, 7)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 91139
        Me.PictureBox2.TabStop = False
        '
        'txtChargesHSN
        '
        Me.txtChargesHSN.BackColor = System.Drawing.Color.GhostWhite
        Me.txtChargesHSN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChargesHSN.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtChargesHSN.Location = New System.Drawing.Point(222, 189)
        Me.txtChargesHSN.Name = "txtChargesHSN"
        Me.txtChargesHSN.Size = New System.Drawing.Size(113, 27)
        Me.txtChargesHSN.TabIndex = 6
        Me.txtChargesHSN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblHsn
        '
        Me.lblHsn.AutoSize = True
        Me.lblHsn.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblHsn.ForeColor = System.Drawing.Color.Black
        Me.lblHsn.Location = New System.Drawing.Point(229, 166)
        Me.lblHsn.Name = "lblHsn"
        Me.lblHsn.Size = New System.Drawing.Size(89, 21)
        Me.lblHsn.TabIndex = 91141
        Me.lblHsn.Text = "HSN Code"
        '
        'cbFixas
        '
        Me.cbFixas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbFixas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbFixas.BackColor = System.Drawing.Color.GhostWhite
        Me.cbFixas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFixas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbFixas.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.cbFixas.ForeColor = System.Drawing.Color.Black
        Me.cbFixas.FormattingEnabled = True
        Me.cbFixas.Items.AddRange(New Object() {"Not Applicable", "Include in GST (Goods)", "Include in With GST (Service)", "Exclude GST Applicable"})
        Me.cbFixas.Location = New System.Drawing.Point(727, 136)
        Me.cbFixas.Name = "cbFixas"
        Me.cbFixas.Size = New System.Drawing.Size(261, 25)
        Me.cbFixas.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(777, 111)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(145, 21)
        Me.Label8.TabIndex = 91143
        Me.Label8.Text = "Is GST Applicable"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 10.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(383, 167)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 17)
        Me.Label6.TabIndex = 91144
        Me.Label6.Text = "Apply Type"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 10.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(578, 167)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(95, 17)
        Me.Label7.TabIndex = 91145
        Me.Label7.Text = "Charge Type"
        '
        'cbSupply
        '
        Me.cbSupply.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbSupply.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbSupply.BackColor = System.Drawing.Color.GhostWhite
        Me.cbSupply.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSupply.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbSupply.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.cbSupply.ForeColor = System.Drawing.Color.Black
        Me.cbSupply.FormattingEnabled = True
        Me.cbSupply.Items.AddRange(New Object() {"Goods", "Services"})
        Me.cbSupply.Location = New System.Drawing.Point(727, 190)
        Me.cbSupply.Name = "cbSupply"
        Me.cbSupply.Size = New System.Drawing.Size(209, 25)
        Me.cbSupply.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(791, 166)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 21)
        Me.Label5.TabIndex = 91147
        Me.Label5.Text = "Supply Type"
        Me.Label5.Visible = False
        '
        'cbChargesType
        '
        Me.cbChargesType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbChargesType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbChargesType.BackColor = System.Drawing.Color.GhostWhite
        Me.cbChargesType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbChargesType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbChargesType.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.cbChargesType.ForeColor = System.Drawing.Color.Black
        Me.cbChargesType.FormattingEnabled = True
        Me.cbChargesType.Items.AddRange(New Object() {"Plus(+)", "Minus(-)"})
        Me.cbChargesType.Location = New System.Drawing.Point(527, 190)
        Me.cbChargesType.Name = "cbChargesType"
        Me.cbChargesType.Size = New System.Drawing.Size(199, 25)
        Me.cbChargesType.TabIndex = 8
        '
        'cbApplyType
        '
        Me.cbApplyType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbApplyType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbApplyType.BackColor = System.Drawing.Color.GhostWhite
        Me.cbApplyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbApplyType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbApplyType.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.cbApplyType.ForeColor = System.Drawing.Color.Black
        Me.cbApplyType.FormattingEnabled = True
        Me.cbApplyType.Items.AddRange(New Object() {"Aboslute", "Percentage", "Weight", "Qty", "AltQty"})
        Me.cbApplyType.Location = New System.Drawing.Point(335, 190)
        Me.cbApplyType.Name = "cbApplyType"
        Me.cbApplyType.Size = New System.Drawing.Size(193, 25)
        Me.cbApplyType.TabIndex = 7
        '
        'ChargesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1196, 653)
        Me.Controls.Add(Me.cbApplyType)
        Me.Controls.Add(Me.cbChargesType)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cbSupply)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cbFixas)
        Me.Controls.Add(Me.lblHsn)
        Me.Controls.Add(Me.txtChargesHSN)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.LblCharges)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.dg1)
        Me.Controls.Add(Me.btnRetrive)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.cbTaxPer)
        Me.Controls.Add(Me.cbApply)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.CkRoundOff)
        Me.Controls.Add(Me.lblGst)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbAccountName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCalculate)
        Me.Controls.Add(Me.TxtChargeName)
        Me.ForeColor = System.Drawing.Color.GhostWhite
        Me.KeyPreview = True
        Me.Name = "ChargesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ChargesForm"
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtChargeName As System.Windows.Forms.TextBox
    Friend WithEvents txtCalculate As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbAccountName As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblGst As System.Windows.Forms.Label
    Friend WithEvents LblCharges As System.Windows.Forms.Label
    Friend WithEvents btnRetrive As System.Windows.Forms.Button
    Friend WithEvents CkRoundOff As System.Windows.Forms.CheckBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents BtnDelete As System.Windows.Forms.Button
    Friend WithEvents cbApply As System.Windows.Forms.ComboBox
    Friend WithEvents cbTaxPer As System.Windows.Forms.ComboBox
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents dg1 As System.Windows.Forms.DataGridView
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents txtChargesHSN As System.Windows.Forms.TextBox
    Friend WithEvents lblHsn As System.Windows.Forms.Label
    Friend WithEvents cbFixas As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbSupply As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbChargesType As System.Windows.Forms.ComboBox
    Friend WithEvents cbApplyType As System.Windows.Forms.ComboBox
End Class
