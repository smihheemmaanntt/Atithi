<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CheckOut_Register
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CheckOut_Register))
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnShow = New System.Windows.Forms.Button()
        Me.MsktoDate = New System.Windows.Forms.MaskedTextBox()
        Me.mskFromDate = New System.Windows.Forms.MaskedTextBox()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.dg1 = New System.Windows.Forms.DataGridView()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtTotalRoomRent = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFoodAmt = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtVasAmt = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtOtheramt = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTaxAmt = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtBasicAmt = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtAdvanceAmt = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtRoff = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTotalAmt = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtCashAmt = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtCardAmt = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtChangeAmt = New System.Windows.Forms.TextBox()
        Me.dtp1 = New System.Windows.Forms.DateTimePicker()
        Me.dtp2 = New System.Windows.Forms.DateTimePicker()
        Me.Label14 = New System.Windows.Forms.Label()
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
        Me.Label10.Location = New System.Drawing.Point(238, 90)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(86, 27)
        Me.Label10.TabIndex = 91187
        Me.Label10.Text = "To Date :"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.CadetBlue
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label9.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label9.Location = New System.Drawing.Point(12, 90)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(110, 27)
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
        Me.btnShow.Location = New System.Drawing.Point(440, 90)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(93, 27)
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
        Me.MsktoDate.Location = New System.Drawing.Point(324, 90)
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
        Me.mskFromDate.Location = New System.Drawing.Point(122, 90)
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
        Me.BtnPrint.Location = New System.Drawing.Point(533, 90)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(92, 27)
        Me.BtnPrint.TabIndex = 3
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
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dg1.ColumnHeadersHeight = 28
        Me.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Navy
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg1.DefaultCellStyle = DataGridViewCellStyle2
        Me.dg1.EnableHeadersVisualStyles = False
        Me.dg1.GridColor = System.Drawing.Color.Gray
        Me.dg1.Location = New System.Drawing.Point(12, 116)
        Me.dg1.Name = "dg1"
        Me.dg1.ReadOnly = True
        Me.dg1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dg1.RowHeadersVisible = False
        Me.dg1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dg1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dg1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg1.Size = New System.Drawing.Size(1172, 475)
        Me.dg1.TabIndex = 40205
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Bodoni Bk BT", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.Black
        Me.Label41.Location = New System.Drawing.Point(395, 0)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(422, 48)
        Me.Label41.TabIndex = 91111
        Me.Label41.Text = "CHECK OUT REGISTER"
        '
        'btnClose
        '
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(1153, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(40, 40)
        Me.btnClose.TabIndex = 91200
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(343, 0)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox4.TabIndex = 91209
        Me.PictureBox4.TabStop = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(64, 594)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(47, 21)
        Me.Label16.TabIndex = 91211
        Me.Label16.Text = "Rent"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalRoomRent
        '
        Me.txtTotalRoomRent.BackColor = System.Drawing.Color.GhostWhite
        Me.txtTotalRoomRent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalRoomRent.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtTotalRoomRent.ForeColor = System.Drawing.Color.Navy
        Me.txtTotalRoomRent.Location = New System.Drawing.Point(11, 618)
        Me.txtTotalRoomRent.Name = "txtTotalRoomRent"
        Me.txtTotalRoomRent.ReadOnly = True
        Me.txtTotalRoomRent.Size = New System.Drawing.Size(100, 27)
        Me.txtTotalRoomRent.TabIndex = 91210
        Me.txtTotalRoomRent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(161, 594)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 21)
        Me.Label1.TabIndex = 91213
        Me.Label1.Text = "Food"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFoodAmt
        '
        Me.txtFoodAmt.BackColor = System.Drawing.Color.GhostWhite
        Me.txtFoodAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFoodAmt.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtFoodAmt.ForeColor = System.Drawing.Color.Navy
        Me.txtFoodAmt.Location = New System.Drawing.Point(110, 618)
        Me.txtFoodAmt.Name = "txtFoodAmt"
        Me.txtFoodAmt.ReadOnly = True
        Me.txtFoodAmt.Size = New System.Drawing.Size(100, 27)
        Me.txtFoodAmt.TabIndex = 91212
        Me.txtFoodAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(267, 594)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 21)
        Me.Label2.TabIndex = 91215
        Me.Label2.Text = "VAS"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtVasAmt
        '
        Me.txtVasAmt.BackColor = System.Drawing.Color.GhostWhite
        Me.txtVasAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVasAmt.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtVasAmt.ForeColor = System.Drawing.Color.Navy
        Me.txtVasAmt.Location = New System.Drawing.Point(209, 618)
        Me.txtVasAmt.Name = "txtVasAmt"
        Me.txtVasAmt.ReadOnly = True
        Me.txtVasAmt.Size = New System.Drawing.Size(100, 27)
        Me.txtVasAmt.TabIndex = 91214
        Me.txtVasAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(357, 594)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 21)
        Me.Label3.TabIndex = 91217
        Me.Label3.Text = "Other"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOtheramt
        '
        Me.txtOtheramt.BackColor = System.Drawing.Color.GhostWhite
        Me.txtOtheramt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOtheramt.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtOtheramt.ForeColor = System.Drawing.Color.Navy
        Me.txtOtheramt.Location = New System.Drawing.Point(308, 618)
        Me.txtOtheramt.Name = "txtOtheramt"
        Me.txtOtheramt.ReadOnly = True
        Me.txtOtheramt.Size = New System.Drawing.Size(100, 27)
        Me.txtOtheramt.TabIndex = 91216
        Me.txtOtheramt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(470, 594)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 21)
        Me.Label4.TabIndex = 91219
        Me.Label4.Text = "Tax"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTaxAmt
        '
        Me.txtTaxAmt.BackColor = System.Drawing.Color.GhostWhite
        Me.txtTaxAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTaxAmt.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtTaxAmt.ForeColor = System.Drawing.Color.Navy
        Me.txtTaxAmt.Location = New System.Drawing.Point(407, 618)
        Me.txtTaxAmt.Name = "txtTaxAmt"
        Me.txtTaxAmt.ReadOnly = True
        Me.txtTaxAmt.Size = New System.Drawing.Size(100, 27)
        Me.txtTaxAmt.TabIndex = 91218
        Me.txtTaxAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(557, 594)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 21)
        Me.Label5.TabIndex = 91221
        Me.Label5.Text = "Basic"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBasicAmt
        '
        Me.txtBasicAmt.BackColor = System.Drawing.Color.GhostWhite
        Me.txtBasicAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBasicAmt.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtBasicAmt.ForeColor = System.Drawing.Color.Navy
        Me.txtBasicAmt.Location = New System.Drawing.Point(506, 618)
        Me.txtBasicAmt.Name = "txtBasicAmt"
        Me.txtBasicAmt.ReadOnly = True
        Me.txtBasicAmt.Size = New System.Drawing.Size(100, 27)
        Me.txtBasicAmt.TabIndex = 91220
        Me.txtBasicAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(620, 594)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 21)
        Me.Label6.TabIndex = 91223
        Me.Label6.Text = "Advance"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAdvanceAmt
        '
        Me.txtAdvanceAmt.BackColor = System.Drawing.Color.GhostWhite
        Me.txtAdvanceAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAdvanceAmt.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtAdvanceAmt.ForeColor = System.Drawing.Color.Navy
        Me.txtAdvanceAmt.Location = New System.Drawing.Point(605, 618)
        Me.txtAdvanceAmt.Name = "txtAdvanceAmt"
        Me.txtAdvanceAmt.ReadOnly = True
        Me.txtAdvanceAmt.Size = New System.Drawing.Size(100, 27)
        Me.txtAdvanceAmt.TabIndex = 91222
        Me.txtAdvanceAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(732, 594)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 21)
        Me.Label7.TabIndex = 91225
        Me.Label7.Text = "Round"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRoff
        '
        Me.txtRoff.BackColor = System.Drawing.Color.GhostWhite
        Me.txtRoff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRoff.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtRoff.ForeColor = System.Drawing.Color.Navy
        Me.txtRoff.Location = New System.Drawing.Point(704, 618)
        Me.txtRoff.Name = "txtRoff"
        Me.txtRoff.ReadOnly = True
        Me.txtRoff.Size = New System.Drawing.Size(84, 27)
        Me.txtRoff.TabIndex = 91224
        Me.txtRoff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(838, 594)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 21)
        Me.Label8.TabIndex = 91227
        Me.Label8.Text = "Total"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalAmt
        '
        Me.txtTotalAmt.BackColor = System.Drawing.Color.GhostWhite
        Me.txtTotalAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalAmt.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtTotalAmt.ForeColor = System.Drawing.Color.Navy
        Me.txtTotalAmt.Location = New System.Drawing.Point(787, 618)
        Me.txtTotalAmt.Name = "txtTotalAmt"
        Me.txtTotalAmt.ReadOnly = True
        Me.txtTotalAmt.Size = New System.Drawing.Size(100, 27)
        Me.txtTotalAmt.TabIndex = 91226
        Me.txtTotalAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(936, 594)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(50, 21)
        Me.Label11.TabIndex = 91229
        Me.Label11.Text = "Cash"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCashAmt
        '
        Me.txtCashAmt.BackColor = System.Drawing.Color.GhostWhite
        Me.txtCashAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCashAmt.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtCashAmt.ForeColor = System.Drawing.Color.Navy
        Me.txtCashAmt.Location = New System.Drawing.Point(886, 618)
        Me.txtCashAmt.Name = "txtCashAmt"
        Me.txtCashAmt.ReadOnly = True
        Me.txtCashAmt.Size = New System.Drawing.Size(100, 27)
        Me.txtCashAmt.TabIndex = 91228
        Me.txtCashAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(1035, 594)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(50, 21)
        Me.Label12.TabIndex = 91231
        Me.Label12.Text = "Card"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCardAmt
        '
        Me.txtCardAmt.BackColor = System.Drawing.Color.GhostWhite
        Me.txtCardAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCardAmt.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtCardAmt.ForeColor = System.Drawing.Color.Navy
        Me.txtCardAmt.Location = New System.Drawing.Point(985, 618)
        Me.txtCardAmt.Name = "txtCardAmt"
        Me.txtCardAmt.ReadOnly = True
        Me.txtCardAmt.Size = New System.Drawing.Size(100, 27)
        Me.txtCardAmt.TabIndex = 91230
        Me.txtCardAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(1109, 594)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(75, 21)
        Me.Label13.TabIndex = 91233
        Me.Label13.Text = "Change"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtChangeAmt
        '
        Me.txtChangeAmt.BackColor = System.Drawing.Color.GhostWhite
        Me.txtChangeAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChangeAmt.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtChangeAmt.ForeColor = System.Drawing.Color.Navy
        Me.txtChangeAmt.Location = New System.Drawing.Point(1084, 618)
        Me.txtChangeAmt.Name = "txtChangeAmt"
        Me.txtChangeAmt.ReadOnly = True
        Me.txtChangeAmt.Size = New System.Drawing.Size(100, 27)
        Me.txtChangeAmt.TabIndex = 91232
        Me.txtChangeAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtp1
        '
        Me.dtp1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.dtp1.Location = New System.Drawing.Point(122, 90)
        Me.dtp1.Name = "dtp1"
        Me.dtp1.Size = New System.Drawing.Size(116, 27)
        Me.dtp1.TabIndex = 91234
        '
        'dtp2
        '
        Me.dtp2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.dtp2.Location = New System.Drawing.Point(324, 90)
        Me.dtp2.Name = "dtp2"
        Me.dtp2.Size = New System.Drawing.Size(116, 27)
        Me.dtp2.TabIndex = 91235
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Label14.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label14.Location = New System.Drawing.Point(625, 90)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(118, 27)
        Me.Label14.TabIndex = 91278
        Me.Label14.Text = "Guest Name :"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtGuestName
        '
        Me.txtGuestName.BackColor = System.Drawing.Color.GhostWhite
        Me.txtGuestName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGuestName.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.txtGuestName.ForeColor = System.Drawing.Color.Black
        Me.txtGuestName.Location = New System.Drawing.Point(743, 90)
        Me.txtGuestName.Name = "txtGuestName"
        Me.txtGuestName.Size = New System.Drawing.Size(191, 27)
        Me.txtGuestName.TabIndex = 91277
        Me.txtGuestName.TabStop = False
        Me.txtGuestName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Label15.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label15.Location = New System.Drawing.Point(927, 90)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(93, 26)
        Me.Label15.TabIndex = 91280
        Me.Label15.Text = "Room No. :"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.GhostWhite
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TextBox1.ForeColor = System.Drawing.Color.Black
        Me.TextBox1.Location = New System.Drawing.Point(1019, 90)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(165, 27)
        Me.TextBox1.TabIndex = 91279
        Me.TextBox1.TabStop = False
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CheckOut_Register
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1194, 653)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtGuestName)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtChangeAmt)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtCardAmt)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtCashAmt)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtTotalAmt)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtRoff)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtAdvanceAmt)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtBasicAmt)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtTaxAmt)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtOtheramt)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtVasAmt)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtFoodAmt)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtTotalRoomRent)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.dg1)
        Me.Controls.Add(Me.btnShow)
        Me.Controls.Add(Me.MsktoDate)
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.mskFromDate)
        Me.Controls.Add(Me.dtp1)
        Me.Controls.Add(Me.dtp2)
        Me.Name = "CheckOut_Register"
        Me.Text = "CheckOut_Register"
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
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtTotalRoomRent As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFoodAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtVasAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtOtheramt As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTaxAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtBasicAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtAdvanceAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtRoff As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTotalAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtCashAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtCardAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtChangeAmt As System.Windows.Forms.TextBox
    Friend WithEvents dtp1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtGuestName As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
End Class
