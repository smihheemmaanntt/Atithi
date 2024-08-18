<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Receipe_Master
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Receipe_Master))
        Me.LblName = New System.Windows.Forms.Label()
        Me.txtReceipeName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMainItem = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtMainQty = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dg1 = New System.Windows.Forms.DataGridView()
        Me.txtRawItem = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtRawQty = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.dgMainItem = New System.Windows.Forms.DataGridView()
        Me.DgRawItem = New System.Windows.Forms.DataGridView()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtRawUnit = New System.Windows.Forms.TextBox()
        Me.txtMainItemID = New System.Windows.Forms.TextBox()
        Me.txtRawItemID = New System.Windows.Forms.TextBox()
        Me.lblUnit = New System.Windows.Forms.Label()
        Me.txtTotRowQty = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblTotalRaws = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.btnReceipeRegister = New System.Windows.Forms.Button()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.btnClose = New System.Windows.Forms.Button()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgMainItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgRawItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblName
        '
        Me.LblName.AutoSize = True
        Me.LblName.Font = New System.Drawing.Font("Bodoni Bk BT", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblName.ForeColor = System.Drawing.Color.Black
        Me.LblName.Location = New System.Drawing.Point(429, 29)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(373, 48)
        Me.LblName.TabIndex = 91209
        Me.LblName.Text = "RECEIPE CREATION"
        '
        'txtReceipeName
        '
        Me.txtReceipeName.BackColor = System.Drawing.Color.GhostWhite
        Me.txtReceipeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReceipeName.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtReceipeName.ForeColor = System.Drawing.Color.Navy
        Me.txtReceipeName.Location = New System.Drawing.Point(194, 155)
        Me.txtReceipeName.Name = "txtReceipeName"
        Me.txtReceipeName.Size = New System.Drawing.Size(355, 27)
        Me.txtReceipeName.TabIndex = 0
        Me.txtReceipeName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(193, 132)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 21)
        Me.Label1.TabIndex = 91212
        Me.Label1.Text = "Receipe Name"
        '
        'txtMainItem
        '
        Me.txtMainItem.BackColor = System.Drawing.Color.GhostWhite
        Me.txtMainItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMainItem.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtMainItem.ForeColor = System.Drawing.Color.Black
        Me.txtMainItem.Location = New System.Drawing.Point(548, 155)
        Me.txtMainItem.Name = "txtMainItem"
        Me.txtMainItem.Size = New System.Drawing.Size(339, 27)
        Me.txtMainItem.TabIndex = 1
        Me.txtMainItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(546, 132)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(176, 19)
        Me.Label5.TabIndex = 91214
        Me.Label5.Text = "Main Item To Produce"
        '
        'txtMainQty
        '
        Me.txtMainQty.BackColor = System.Drawing.Color.GhostWhite
        Me.txtMainQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMainQty.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtMainQty.ForeColor = System.Drawing.Color.Black
        Me.txtMainQty.Location = New System.Drawing.Point(886, 155)
        Me.txtMainQty.Name = "txtMainQty"
        Me.txtMainQty.Size = New System.Drawing.Size(105, 27)
        Me.txtMainQty.TabIndex = 2
        Me.txtMainQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(884, 132)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 21)
        Me.Label2.TabIndex = 91216
        Me.Label2.Text = "Qty"
        '
        'dg1
        '
        Me.dg1.AllowUserToAddRows = False
        Me.dg1.AllowUserToDeleteRows = False
        Me.dg1.AllowUserToResizeRows = False
        Me.dg1.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dg1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
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
        Me.dg1.Location = New System.Drawing.Point(194, 304)
        Me.dg1.Name = "dg1"
        Me.dg1.ReadOnly = True
        Me.dg1.RowHeadersVisible = False
        Me.dg1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dg1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg1.Size = New System.Drawing.Size(797, 200)
        Me.dg1.TabIndex = 91217
        '
        'txtRawItem
        '
        Me.txtRawItem.BackColor = System.Drawing.Color.GhostWhite
        Me.txtRawItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRawItem.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtRawItem.ForeColor = System.Drawing.Color.Navy
        Me.txtRawItem.Location = New System.Drawing.Point(194, 278)
        Me.txtRawItem.Name = "txtRawItem"
        Me.txtRawItem.Size = New System.Drawing.Size(443, 27)
        Me.txtRawItem.TabIndex = 3
        Me.txtRawItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(193, 255)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(385, 21)
        Me.Label3.TabIndex = 91219
        Me.Label3.Text = "Raw Material that Used to Make Receipe (Item)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(353, 232)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(511, 21)
        Me.Label4.TabIndex = 91220
        Me.Label4.Text = "Raw Materials (Ingredaints) Required to Make this Receipe (Item)"
        '
        'txtRawQty
        '
        Me.txtRawQty.BackColor = System.Drawing.Color.GhostWhite
        Me.txtRawQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRawQty.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtRawQty.ForeColor = System.Drawing.Color.Navy
        Me.txtRawQty.Location = New System.Drawing.Point(839, 278)
        Me.txtRawQty.Name = "txtRawQty"
        Me.txtRawQty.Size = New System.Drawing.Size(152, 27)
        Me.txtRawQty.TabIndex = 5
        Me.txtRawQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(835, 254)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 21)
        Me.Label6.TabIndex = 91222
        Me.Label6.Text = "Qty"
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.LightCoral
        Me.btnDelete.FlatAppearance.BorderSize = 0
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnDelete.ForeColor = System.Drawing.Color.GhostWhite
        Me.btnDelete.Location = New System.Drawing.Point(555, 547)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(140, 34)
        Me.btnDelete.TabIndex = 10
        Me.btnDelete.TabStop = False
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDelete.UseVisualStyleBackColor = False
        Me.btnDelete.Visible = False
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.Peru
        Me.BtnSave.FlatAppearance.BorderSize = 0
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.BtnSave.ForeColor = System.Drawing.Color.GhostWhite
        Me.BtnSave.Location = New System.Drawing.Point(851, 547)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(140, 34)
        Me.BtnSave.TabIndex = 9
        Me.BtnSave.TabStop = False
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'dgMainItem
        '
        Me.dgMainItem.AllowUserToAddRows = False
        Me.dgMainItem.AllowUserToDeleteRows = False
        Me.dgMainItem.AllowUserToResizeRows = False
        Me.dgMainItem.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
        Me.dgMainItem.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgMainItem.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgMainItem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgMainItem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgMainItem.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgMainItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgMainItem.ColumnHeadersVisible = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgMainItem.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgMainItem.GridColor = System.Drawing.Color.Gray
        Me.dgMainItem.Location = New System.Drawing.Point(549, 182)
        Me.dgMainItem.MultiSelect = False
        Me.dgMainItem.Name = "dgMainItem"
        Me.dgMainItem.ReadOnly = True
        Me.dgMainItem.RowHeadersVisible = False
        Me.dgMainItem.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dgMainItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgMainItem.Size = New System.Drawing.Size(442, 246)
        Me.dgMainItem.TabIndex = 91231
        Me.dgMainItem.TabStop = False
        Me.dgMainItem.Visible = False
        '
        'DgRawItem
        '
        Me.DgRawItem.AllowUserToAddRows = False
        Me.DgRawItem.AllowUserToDeleteRows = False
        Me.DgRawItem.AllowUserToResizeRows = False
        Me.DgRawItem.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
        Me.DgRawItem.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.DgRawItem.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgRawItem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DgRawItem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgRawItem.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DgRawItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgRawItem.ColumnHeadersVisible = False
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgRawItem.DefaultCellStyle = DataGridViewCellStyle6
        Me.DgRawItem.GridColor = System.Drawing.Color.Gray
        Me.DgRawItem.Location = New System.Drawing.Point(195, 304)
        Me.DgRawItem.MultiSelect = False
        Me.DgRawItem.Name = "DgRawItem"
        Me.DgRawItem.ReadOnly = True
        Me.DgRawItem.RowHeadersVisible = False
        Me.DgRawItem.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.DgRawItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgRawItem.Size = New System.Drawing.Size(442, 200)
        Me.DgRawItem.TabIndex = 91232
        Me.DgRawItem.TabStop = False
        Me.DgRawItem.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(632, 254)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(99, 21)
        Me.Label10.TabIndex = 91234
        Me.Label10.Text = "UNIT NAME"
        '
        'txtRawUnit
        '
        Me.txtRawUnit.BackColor = System.Drawing.Color.GhostWhite
        Me.txtRawUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRawUnit.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtRawUnit.ForeColor = System.Drawing.Color.Navy
        Me.txtRawUnit.Location = New System.Drawing.Point(636, 278)
        Me.txtRawUnit.Name = "txtRawUnit"
        Me.txtRawUnit.ReadOnly = True
        Me.txtRawUnit.Size = New System.Drawing.Size(204, 27)
        Me.txtRawUnit.TabIndex = 4
        Me.txtRawUnit.TabStop = False
        Me.txtRawUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMainItemID
        '
        Me.txtMainItemID.BackColor = System.Drawing.Color.AliceBlue
        Me.txtMainItemID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMainItemID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMainItemID.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtMainItemID.ForeColor = System.Drawing.Color.Black
        Me.txtMainItemID.Location = New System.Drawing.Point(735, 129)
        Me.txtMainItemID.Name = "txtMainItemID"
        Me.txtMainItemID.Size = New System.Drawing.Size(48, 27)
        Me.txtMainItemID.TabIndex = 91238
        Me.txtMainItemID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtMainItemID.Visible = False
        '
        'txtRawItemID
        '
        Me.txtRawItemID.BackColor = System.Drawing.Color.AliceBlue
        Me.txtRawItemID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRawItemID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRawItemID.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtRawItemID.ForeColor = System.Drawing.Color.Black
        Me.txtRawItemID.Location = New System.Drawing.Point(197, 226)
        Me.txtRawItemID.Name = "txtRawItemID"
        Me.txtRawItemID.Size = New System.Drawing.Size(48, 27)
        Me.txtRawItemID.TabIndex = 91239
        Me.txtRawItemID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtRawItemID.Visible = False
        '
        'lblUnit
        '
        Me.lblUnit.AutoSize = True
        Me.lblUnit.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblUnit.ForeColor = System.Drawing.Color.Navy
        Me.lblUnit.Location = New System.Drawing.Point(789, 131)
        Me.lblUnit.Name = "lblUnit"
        Me.lblUnit.Size = New System.Drawing.Size(0, 19)
        Me.lblUnit.TabIndex = 91241
        '
        'txtTotRowQty
        '
        Me.txtTotRowQty.BackColor = System.Drawing.Color.GhostWhite
        Me.txtTotRowQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotRowQty.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtTotRowQty.ForeColor = System.Drawing.Color.Black
        Me.txtTotRowQty.Location = New System.Drawing.Point(839, 503)
        Me.txtTotRowQty.Name = "txtTotRowQty"
        Me.txtTotRowQty.ReadOnly = True
        Me.txtTotRowQty.Size = New System.Drawing.Size(152, 27)
        Me.txtTotRowQty.TabIndex = 91242
        Me.txtTotRowQty.TabStop = False
        Me.txtTotRowQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(751, 506)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 21)
        Me.Label7.TabIndex = 91243
        Me.Label7.Text = "Raw Qty :"
        '
        'lblTotalRaws
        '
        Me.lblTotalRaws.AutoSize = True
        Me.lblTotalRaws.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblTotalRaws.ForeColor = System.Drawing.Color.Navy
        Me.lblTotalRaws.Location = New System.Drawing.Point(193, 507)
        Me.lblTotalRaws.Name = "lblTotalRaws"
        Me.lblTotalRaws.Size = New System.Drawing.Size(138, 19)
        Me.lblTotalRaws.TabIndex = 91245
        Me.lblTotalRaws.Text = "Total  Raw Items :"
        '
        'txtID
        '
        Me.txtID.BackColor = System.Drawing.Color.AliceBlue
        Me.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtID.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtID.ForeColor = System.Drawing.Color.Black
        Me.txtID.Location = New System.Drawing.Point(50, 38)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(48, 27)
        Me.txtID.TabIndex = 91246
        Me.txtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtID.Visible = False
        '
        'btnReceipeRegister
        '
        Me.btnReceipeRegister.BackColor = System.Drawing.Color.Olive
        Me.btnReceipeRegister.FlatAppearance.BorderSize = 0
        Me.btnReceipeRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReceipeRegister.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnReceipeRegister.ForeColor = System.Drawing.Color.GhostWhite
        Me.btnReceipeRegister.Location = New System.Drawing.Point(694, 547)
        Me.btnReceipeRegister.Name = "btnReceipeRegister"
        Me.btnReceipeRegister.Size = New System.Drawing.Size(157, 34)
        Me.btnReceipeRegister.TabIndex = 91247
        Me.btnReceipeRegister.TabStop = False
        Me.btnReceipeRegister.Text = "&Receipe Register"
        Me.btnReceipeRegister.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReceipeRegister.UseVisualStyleBackColor = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(373, 29)
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
        Me.btnClose.Location = New System.Drawing.Point(1154, -2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(40, 40)
        Me.btnClose.TabIndex = 91248
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Receipe_Master
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1194, 653)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnReceipeRegister)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.DgRawItem)
        Me.Controls.Add(Me.lblTotalRaws)
        Me.Controls.Add(Me.txtTotRowQty)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblUnit)
        Me.Controls.Add(Me.txtRawItemID)
        Me.Controls.Add(Me.txtMainItemID)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtRawUnit)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtRawQty)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtRawItem)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dg1)
        Me.Controls.Add(Me.txtMainQty)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtMainItem)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtReceipeName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.LblName)
        Me.Controls.Add(Me.dgMainItem)
        Me.Name = "Receipe_Master"
        Me.Text = "Receipe_Master"
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgMainItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgRawItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents LblName As System.Windows.Forms.Label
    Friend WithEvents txtReceipeName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMainItem As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtMainQty As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dg1 As System.Windows.Forms.DataGridView
    Friend WithEvents txtRawItem As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtRawQty As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents dgMainItem As System.Windows.Forms.DataGridView
    Friend WithEvents DgRawItem As System.Windows.Forms.DataGridView
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtRawUnit As System.Windows.Forms.TextBox
    Friend WithEvents txtMainItemID As System.Windows.Forms.TextBox
    Friend WithEvents txtRawItemID As System.Windows.Forms.TextBox
    Friend WithEvents lblUnit As System.Windows.Forms.Label
    Friend WithEvents txtTotRowQty As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblTotalRaws As System.Windows.Forms.Label
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents btnReceipeRegister As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class
