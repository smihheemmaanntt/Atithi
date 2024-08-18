<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Item_Wise_Stock
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Item_Wise_Stock))
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTotalBal = New System.Windows.Forms.TextBox()
        Me.txtTotalOut = New System.Windows.Forms.TextBox()
        Me.txtTotalIn = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.txtItem = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TxtItemID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.MsktoDate = New System.Windows.Forms.MaskedTextBox()
        Me.mskFromDate = New System.Windows.Forms.MaskedTextBox()
        Me.dtp2 = New System.Windows.Forms.DateTimePicker()
        Me.dtp1 = New System.Windows.Forms.DateTimePicker()
        Me.btnPrintList = New System.Windows.Forms.Button()
        Me.btnShow = New System.Windows.Forms.Button()
        Me.txtOpeningStock = New System.Windows.Forms.TextBox()
        Me.dgItemSearch = New System.Windows.Forms.DataGridView()
        Me.radioAlt = New System.Windows.Forms.RadioButton()
        Me.RadioMainAlt = New System.Windows.Forms.RadioButton()
        Me.RadioMain = New System.Windows.Forms.RadioButton()
        Me.dg1 = New System.Windows.Forms.DataGridView()
        Me.pnlWait = New System.Windows.Forms.Panel()
        Me.pb1 = New System.Windows.Forms.ProgressBar()
        Me.Label66 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgItemSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlWait.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Bodoni Bk BT", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(425, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(340, 48)
        Me.Label1.TabIndex = 91184
        Me.Label1.Text = "ITEM WISE STOCK"
        '
        'Label19
        '
        Me.Label19.AllowDrop = True
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("TIMES NEW ROMAN", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(956, 601)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(106, 19)
        Me.Label19.TabIndex = 91192
        Me.Label19.Text = "Total Out Qty"
        '
        'Label6
        '
        Me.Label6.AllowDrop = True
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("TIMES NEW ROMAN", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(851, 601)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 19)
        Me.Label6.TabIndex = 91191
        Me.Label6.Text = "Total In Qty"
        '
        'txtTotalBal
        '
        Me.txtTotalBal.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.txtTotalBal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalBal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalBal.Font = New System.Drawing.Font("TIMES NEW ROMAN", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtTotalBal.ForeColor = System.Drawing.Color.Navy
        Me.txtTotalBal.Location = New System.Drawing.Point(1064, 623)
        Me.txtTotalBal.Name = "txtTotalBal"
        Me.txtTotalBal.ReadOnly = True
        Me.txtTotalBal.Size = New System.Drawing.Size(120, 27)
        Me.txtTotalBal.TabIndex = 91190
        Me.txtTotalBal.TabStop = False
        Me.txtTotalBal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalOut
        '
        Me.txtTotalOut.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.txtTotalOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalOut.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalOut.Font = New System.Drawing.Font("TIMES NEW ROMAN", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtTotalOut.ForeColor = System.Drawing.Color.Navy
        Me.txtTotalOut.Location = New System.Drawing.Point(945, 623)
        Me.txtTotalOut.Name = "txtTotalOut"
        Me.txtTotalOut.ReadOnly = True
        Me.txtTotalOut.Size = New System.Drawing.Size(120, 27)
        Me.txtTotalOut.TabIndex = 91189
        Me.txtTotalOut.TabStop = False
        Me.txtTotalOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalIn
        '
        Me.txtTotalIn.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.txtTotalIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalIn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalIn.Font = New System.Drawing.Font("TIMES NEW ROMAN", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtTotalIn.ForeColor = System.Drawing.Color.Navy
        Me.txtTotalIn.Location = New System.Drawing.Point(826, 623)
        Me.txtTotalIn.Name = "txtTotalIn"
        Me.txtTotalIn.ReadOnly = True
        Me.txtTotalIn.Size = New System.Drawing.Size(120, 27)
        Me.txtTotalIn.TabIndex = 91187
        Me.txtTotalIn.TabStop = False
        Me.txtTotalIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AllowDrop = True
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("TIMES NEW ROMAN", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(1077, 601)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(104, 19)
        Me.Label20.TabIndex = 91193
        Me.Label20.Text = "Balance Qty"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(369, 11)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 91196
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
        Me.btnClose.TabIndex = 91188
        Me.btnClose.TabStop = False
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'txtItem
        '
        Me.txtItem.BackColor = System.Drawing.Color.White
        Me.txtItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItem.Font = New System.Drawing.Font("TIMES NEW ROMAN", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtItem.ForeColor = System.Drawing.Color.Black
        Me.txtItem.Location = New System.Drawing.Point(142, 110)
        Me.txtItem.Name = "txtItem"
        Me.txtItem.Size = New System.Drawing.Size(388, 27)
        Me.txtItem.TabIndex = 0
        Me.txtItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Label25.Font = New System.Drawing.Font("TIMES NEW ROMAN", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(12, 109)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(131, 27)
        Me.Label25.TabIndex = 91201
        Me.Label25.Text = "Item Name :"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtItemID
        '
        Me.TxtItemID.BackColor = System.Drawing.Color.White
        Me.TxtItemID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtItemID.Font = New System.Drawing.Font("TIMES NEW ROMAN", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TxtItemID.ForeColor = System.Drawing.Color.Black
        Me.TxtItemID.Location = New System.Drawing.Point(12, 20)
        Me.TxtItemID.Name = "TxtItemID"
        Me.TxtItemID.Size = New System.Drawing.Size(59, 27)
        Me.TxtItemID.TabIndex = 91202
        Me.TxtItemID.TabStop = False
        Me.TxtItemID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TxtItemID.Visible = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Label2.Font = New System.Drawing.Font("TIMES NEW ROMAN", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(696, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 27)
        Me.Label2.TabIndex = 91207
        Me.Label2.Text = "To"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Label3.Font = New System.Drawing.Font("TIMES NEW ROMAN", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(529, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 27)
        Me.Label3.TabIndex = 91206
        Me.Label3.Text = "From"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MsktoDate
        '
        Me.MsktoDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MsktoDate.Font = New System.Drawing.Font("TIMES NEW ROMAN", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.MsktoDate.Location = New System.Drawing.Point(732, 110)
        Me.MsktoDate.Mask = "00-00-0000"
        Me.MsktoDate.Name = "MsktoDate"
        Me.MsktoDate.Size = New System.Drawing.Size(100, 27)
        Me.MsktoDate.TabIndex = 2
        '
        'mskFromDate
        '
        Me.mskFromDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskFromDate.Font = New System.Drawing.Font("TIMES NEW ROMAN", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.mskFromDate.Location = New System.Drawing.Point(582, 110)
        Me.mskFromDate.Mask = "00-00-0000"
        Me.mskFromDate.Name = "mskFromDate"
        Me.mskFromDate.Size = New System.Drawing.Size(100, 27)
        Me.mskFromDate.TabIndex = 1
        '
        'dtp2
        '
        Me.dtp2.Font = New System.Drawing.Font("TIMES NEW ROMAN", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.dtp2.Location = New System.Drawing.Point(739, 110)
        Me.dtp2.Name = "dtp2"
        Me.dtp2.Size = New System.Drawing.Size(109, 27)
        Me.dtp2.TabIndex = 200
        '
        'dtp1
        '
        Me.dtp1.Font = New System.Drawing.Font("TIMES NEW ROMAN", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.dtp1.Location = New System.Drawing.Point(587, 110)
        Me.dtp1.Name = "dtp1"
        Me.dtp1.Size = New System.Drawing.Size(109, 27)
        Me.dtp1.TabIndex = 100
        '
        'btnPrintList
        '
        Me.btnPrintList.BackColor = System.Drawing.Color.MediumAquamarine
        Me.btnPrintList.FlatAppearance.BorderSize = 0
        Me.btnPrintList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintList.Font = New System.Drawing.Font("TIMES NEW ROMAN", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnPrintList.ForeColor = System.Drawing.Color.GhostWhite
        Me.btnPrintList.Image = CType(resources.GetObject("btnPrintList.Image"), System.Drawing.Image)
        Me.btnPrintList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrintList.Location = New System.Drawing.Point(941, 110)
        Me.btnPrintList.Name = "btnPrintList"
        Me.btnPrintList.Size = New System.Drawing.Size(93, 27)
        Me.btnPrintList.TabIndex = 4
        Me.btnPrintList.TabStop = False
        Me.btnPrintList.Text = "&Print"
        Me.btnPrintList.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPrintList.UseVisualStyleBackColor = False
        '
        'btnShow
        '
        Me.btnShow.BackColor = System.Drawing.Color.DarkTurquoise
        Me.btnShow.FlatAppearance.BorderSize = 0
        Me.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShow.Font = New System.Drawing.Font("TIMES NEW ROMAN", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnShow.ForeColor = System.Drawing.Color.GhostWhite
        Me.btnShow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnShow.Location = New System.Drawing.Point(847, 110)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(94, 27)
        Me.btnShow.TabIndex = 3
        Me.btnShow.Text = "&Show"
        Me.btnShow.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnShow.UseVisualStyleBackColor = False
        '
        'txtOpeningStock
        '
        Me.txtOpeningStock.BackColor = System.Drawing.Color.White
        Me.txtOpeningStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOpeningStock.Font = New System.Drawing.Font("TIMES NEW ROMAN", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtOpeningStock.ForeColor = System.Drawing.Color.Black
        Me.txtOpeningStock.Location = New System.Drawing.Point(1034, 110)
        Me.txtOpeningStock.Name = "txtOpeningStock"
        Me.txtOpeningStock.ReadOnly = True
        Me.txtOpeningStock.Size = New System.Drawing.Size(150, 27)
        Me.txtOpeningStock.TabIndex = 91211
        Me.txtOpeningStock.TabStop = False
        Me.txtOpeningStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dgItemSearch
        '
        Me.dgItemSearch.AllowUserToAddRows = False
        Me.dgItemSearch.AllowUserToDeleteRows = False
        Me.dgItemSearch.AllowUserToResizeRows = False
        Me.dgItemSearch.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.dgItemSearch.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("TIMES NEW ROMAN", 10.0!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgItemSearch.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgItemSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(241, Byte), Integer))
        DataGridViewCellStyle8.Font = New System.Drawing.Font("TIMES NEW ROMAN", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.CadetBlue
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgItemSearch.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgItemSearch.EnableHeadersVisualStyles = False
        Me.dgItemSearch.GridColor = System.Drawing.Color.Gray
        Me.dgItemSearch.Location = New System.Drawing.Point(143, 136)
        Me.dgItemSearch.MultiSelect = False
        Me.dgItemSearch.Name = "dgItemSearch"
        Me.dgItemSearch.ReadOnly = True
        Me.dgItemSearch.RowHeadersVisible = False
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        Me.dgItemSearch.RowsDefaultCellStyle = DataGridViewCellStyle9
        Me.dgItemSearch.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dgItemSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgItemSearch.Size = New System.Drawing.Size(553, 217)
        Me.dgItemSearch.TabIndex = 91341
        Me.dgItemSearch.TabStop = False
        Me.dgItemSearch.Visible = False
        '
        'radioAlt
        '
        Me.radioAlt.AutoSize = True
        Me.radioAlt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radioAlt.ForeColor = System.Drawing.Color.Black
        Me.radioAlt.Location = New System.Drawing.Point(963, 84)
        Me.radioAlt.Name = "radioAlt"
        Me.radioAlt.Size = New System.Drawing.Size(100, 20)
        Me.radioAlt.TabIndex = 11
        Me.radioAlt.Text = "Show Alt Qty"
        Me.radioAlt.UseVisualStyleBackColor = True
        '
        'RadioMainAlt
        '
        Me.RadioMainAlt.AutoSize = True
        Me.RadioMainAlt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioMainAlt.ForeColor = System.Drawing.Color.Black
        Me.RadioMainAlt.Location = New System.Drawing.Point(1069, 84)
        Me.RadioMainAlt.Name = "RadioMainAlt"
        Me.RadioMainAlt.Size = New System.Drawing.Size(115, 20)
        Me.RadioMainAlt.TabIndex = 12
        Me.RadioMainAlt.Text = "Show Main : Alt"
        Me.RadioMainAlt.UseVisualStyleBackColor = True
        '
        'RadioMain
        '
        Me.RadioMain.AutoSize = True
        Me.RadioMain.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioMain.ForeColor = System.Drawing.Color.Black
        Me.RadioMain.Location = New System.Drawing.Point(843, 84)
        Me.RadioMain.Name = "RadioMain"
        Me.RadioMain.Size = New System.Drawing.Size(114, 20)
        Me.RadioMain.TabIndex = 10
        Me.RadioMain.Text = "Show Main Qty"
        Me.RadioMain.UseVisualStyleBackColor = True
        '
        'dg1
        '
        Me.dg1.AllowUserToAddRows = False
        Me.dg1.AllowUserToDeleteRows = False
        Me.dg1.AllowUserToResizeRows = False
        Me.dg1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.dg1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(241, Byte), Integer))
        DataGridViewCellStyle10.Font = New System.Drawing.Font("TIMES NEW ROMAN", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Crimson
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dg1.ColumnHeadersHeight = 28
        Me.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(241, Byte), Integer))
        DataGridViewCellStyle11.Font = New System.Drawing.Font("TIMES NEW ROMAN", 11.0!)
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg1.DefaultCellStyle = DataGridViewCellStyle11
        Me.dg1.EnableHeadersVisualStyles = False
        Me.dg1.GridColor = System.Drawing.Color.Gray
        Me.dg1.Location = New System.Drawing.Point(12, 136)
        Me.dg1.MultiSelect = False
        Me.dg1.Name = "dg1"
        Me.dg1.ReadOnly = True
        Me.dg1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dg1.RowHeadersVisible = False
        Me.dg1.RowHeadersWidth = 42
        Me.dg1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
        Me.dg1.RowsDefaultCellStyle = DataGridViewCellStyle12
        Me.dg1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dg1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg1.Size = New System.Drawing.Size(1172, 447)
        Me.dg1.TabIndex = 91342
        Me.dg1.TabStop = False
        '
        'pnlWait
        '
        Me.pnlWait.BackColor = System.Drawing.Color.Maroon
        Me.pnlWait.Controls.Add(Me.pb1)
        Me.pnlWait.Controls.Add(Me.Label66)
        Me.pnlWait.Location = New System.Drawing.Point(404, 295)
        Me.pnlWait.Name = "pnlWait"
        Me.pnlWait.Size = New System.Drawing.Size(388, 131)
        Me.pnlWait.TabIndex = 91357
        Me.pnlWait.Visible = False
        '
        'pb1
        '
        Me.pb1.Location = New System.Drawing.Point(3, 101)
        Me.pb1.Name = "pb1"
        Me.pb1.Size = New System.Drawing.Size(382, 23)
        Me.pb1.TabIndex = 3
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Font = New System.Drawing.Font("Bodoni Bk BT", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label66.ForeColor = System.Drawing.Color.White
        Me.Label66.Location = New System.Drawing.Point(71, 23)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(237, 48)
        Me.Label66.TabIndex = 1
        Me.Label66.Text = "Please Wait..."
        '
        'Item_Wise_Stock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1196, 653)
        Me.Controls.Add(Me.pnlWait)
        Me.Controls.Add(Me.RadioMain)
        Me.Controls.Add(Me.RadioMainAlt)
        Me.Controls.Add(Me.radioAlt)
        Me.Controls.Add(Me.dgItemSearch)
        Me.Controls.Add(Me.txtOpeningStock)
        Me.Controls.Add(Me.btnPrintList)
        Me.Controls.Add(Me.btnShow)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.MsktoDate)
        Me.Controls.Add(Me.mskFromDate)
        Me.Controls.Add(Me.dtp2)
        Me.Controls.Add(Me.dtp1)
        Me.Controls.Add(Me.TxtItemID)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.txtItem)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtTotalBal)
        Me.Controls.Add(Me.txtTotalOut)
        Me.Controls.Add(Me.txtTotalIn)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.dg1)
        Me.Name = "Item_Wise_Stock"
        Me.Text = "Item_Wise_Stock"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgItemSearch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlWait.ResumeLayout(False)
        Me.pnlWait.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTotalBal As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalOut As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalIn As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtItem As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TxtItemID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents MsktoDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mskFromDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents dtp2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnPrintList As System.Windows.Forms.Button
    Friend WithEvents btnShow As System.Windows.Forms.Button
    Friend WithEvents txtOpeningStock As System.Windows.Forms.TextBox
    Friend WithEvents dgItemSearch As System.Windows.Forms.DataGridView
    Friend WithEvents radioAlt As System.Windows.Forms.RadioButton
    Friend WithEvents RadioMainAlt As System.Windows.Forms.RadioButton
    Friend WithEvents RadioMain As System.Windows.Forms.RadioButton
    Friend WithEvents dg1 As System.Windows.Forms.DataGridView
    Friend WithEvents pnlWait As System.Windows.Forms.Panel
    Friend WithEvents pb1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label66 As System.Windows.Forms.Label
End Class
