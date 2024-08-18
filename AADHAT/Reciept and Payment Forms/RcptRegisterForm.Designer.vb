<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RcptRegisterForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RcptRegisterForm))
        Me.lblName = New System.Windows.Forms.Label()
        Me.MsktoDate = New System.Windows.Forms.MaskedTextBox()
        Me.mskFromDate = New System.Windows.Forms.MaskedTextBox()
        Me.dg1 = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTotalSearch = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDiscSearch = New System.Windows.Forms.TextBox()
        Me.txtNetSearch = New System.Windows.Forms.TextBox()
        Me.txtCustomerSearch = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtp1 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.TxtGrandTotal = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTotDisCount = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTotBasic = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnShow = New System.Windows.Forms.Button()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Bodoni Bk BT", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.ForeColor = System.Drawing.Color.Black
        Me.lblName.Location = New System.Drawing.Point(417, 9)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(366, 48)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "RECIEPT REGISTER"
        '
        'MsktoDate
        '
        Me.MsktoDate.BackColor = System.Drawing.Color.GhostWhite
        Me.MsktoDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MsktoDate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.MsktoDate.Location = New System.Drawing.Point(305, 89)
        Me.MsktoDate.Mask = "00-00-0000"
        Me.MsktoDate.Name = "MsktoDate"
        Me.MsktoDate.Size = New System.Drawing.Size(90, 27)
        Me.MsktoDate.TabIndex = 115
        Me.MsktoDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'mskFromDate
        '
        Me.mskFromDate.BackColor = System.Drawing.Color.GhostWhite
        Me.mskFromDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskFromDate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.mskFromDate.Location = New System.Drawing.Point(112, 89)
        Me.mskFromDate.Mask = "00-00-0000"
        Me.mskFromDate.Name = "mskFromDate"
        Me.mskFromDate.Size = New System.Drawing.Size(92, 27)
        Me.mskFromDate.TabIndex = 114
        Me.mskFromDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dg1
        '
        Me.dg1.AllowUserToAddRows = False
        Me.dg1.AllowUserToDeleteRows = False
        Me.dg1.AllowUserToResizeRows = False
        Me.dg1.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dg1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Crimson
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dg1.ColumnHeadersHeight = 25
        Me.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkTurquoise
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg1.DefaultCellStyle = DataGridViewCellStyle2
        Me.dg1.EnableHeadersVisualStyles = False
        Me.dg1.GridColor = System.Drawing.Color.Gray
        Me.dg1.Location = New System.Drawing.Point(12, 115)
        Me.dg1.Name = "dg1"
        Me.dg1.ReadOnly = True
        Me.dg1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dg1.RowHeadersVisible = False
        Me.dg1.RowHeadersWidth = 42
        Me.dg1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.dg1.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dg1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dg1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg1.Size = New System.Drawing.Size(1172, 506)
        Me.dg1.TabIndex = 113
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(1061, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 21)
        Me.Label1.TabIndex = 40081
        Me.Label1.Text = "Total"
        '
        'txtTotalSearch
        '
        Me.txtTotalSearch.BackColor = System.Drawing.Color.GhostWhite
        Me.txtTotalSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalSearch.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtTotalSearch.ForeColor = System.Drawing.Color.Gray
        Me.txtTotalSearch.Location = New System.Drawing.Point(1058, 89)
        Me.txtTotalSearch.Name = "txtTotalSearch"
        Me.txtTotalSearch.Size = New System.Drawing.Size(126, 27)
        Me.txtTotalSearch.TabIndex = 40080
        Me.txtTotalSearch.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(935, 65)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 21)
        Me.Label8.TabIndex = 40079
        Me.Label8.Text = "Discount"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(809, 65)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 21)
        Me.Label7.TabIndex = 40078
        Me.Label7.Text = "Amount"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(614, 65)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(132, 21)
        Me.Label6.TabIndex = 40077
        Me.Label6.Text = "Account Name"
        '
        'txtDiscSearch
        '
        Me.txtDiscSearch.BackColor = System.Drawing.Color.GhostWhite
        Me.txtDiscSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiscSearch.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtDiscSearch.ForeColor = System.Drawing.Color.Gray
        Me.txtDiscSearch.Location = New System.Drawing.Point(931, 89)
        Me.txtDiscSearch.Name = "txtDiscSearch"
        Me.txtDiscSearch.Size = New System.Drawing.Size(128, 27)
        Me.txtDiscSearch.TabIndex = 40076
        Me.txtDiscSearch.TabStop = False
        '
        'txtNetSearch
        '
        Me.txtNetSearch.BackColor = System.Drawing.Color.GhostWhite
        Me.txtNetSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNetSearch.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtNetSearch.ForeColor = System.Drawing.Color.Gray
        Me.txtNetSearch.Location = New System.Drawing.Point(812, 89)
        Me.txtNetSearch.Name = "txtNetSearch"
        Me.txtNetSearch.Size = New System.Drawing.Size(120, 27)
        Me.txtNetSearch.TabIndex = 40075
        Me.txtNetSearch.TabStop = False
        '
        'txtCustomerSearch
        '
        Me.txtCustomerSearch.BackColor = System.Drawing.Color.GhostWhite
        Me.txtCustomerSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerSearch.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtCustomerSearch.ForeColor = System.Drawing.Color.Gray
        Me.txtCustomerSearch.Location = New System.Drawing.Point(606, 89)
        Me.txtCustomerSearch.Name = "txtCustomerSearch"
        Me.txtCustomerSearch.Size = New System.Drawing.Size(207, 27)
        Me.txtCustomerSearch.TabIndex = 40074
        Me.txtCustomerSearch.TabStop = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label2.Location = New System.Drawing.Point(12, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 27)
        Me.Label2.TabIndex = 40083
        Me.Label2.Text = "From Date :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label9.Location = New System.Drawing.Point(221, 89)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 27)
        Me.Label9.TabIndex = 40084
        Me.Label9.Text = "To Date :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtp1
        '
        Me.dtp1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.dtp1.Location = New System.Drawing.Point(119, 89)
        Me.dtp1.Name = "dtp1"
        Me.dtp1.Size = New System.Drawing.Size(102, 27)
        Me.dtp1.TabIndex = 91139
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.DateTimePicker1.Location = New System.Drawing.Point(310, 89)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(102, 27)
        Me.DateTimePicker1.TabIndex = 91140
        '
        'TxtGrandTotal
        '
        Me.TxtGrandTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.TxtGrandTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtGrandTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtGrandTotal.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TxtGrandTotal.ForeColor = System.Drawing.Color.Black
        Me.TxtGrandTotal.Location = New System.Drawing.Point(1046, 620)
        Me.TxtGrandTotal.Name = "TxtGrandTotal"
        Me.TxtGrandTotal.ReadOnly = True
        Me.TxtGrandTotal.Size = New System.Drawing.Size(137, 27)
        Me.TxtGrandTotal.TabIndex = 91146
        Me.TxtGrandTotal.TabStop = False
        Me.TxtGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.CadetBlue
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label5.Location = New System.Drawing.Point(983, 620)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 27)
        Me.Label5.TabIndex = 91145
        Me.Label5.Text = "Total :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTotDisCount
        '
        Me.txtTotDisCount.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.txtTotDisCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotDisCount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotDisCount.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtTotDisCount.ForeColor = System.Drawing.Color.Black
        Me.txtTotDisCount.Location = New System.Drawing.Point(863, 620)
        Me.txtTotDisCount.Name = "txtTotDisCount"
        Me.txtTotDisCount.ReadOnly = True
        Me.txtTotDisCount.Size = New System.Drawing.Size(120, 27)
        Me.txtTotDisCount.TabIndex = 91144
        Me.txtTotDisCount.TabStop = False
        Me.txtTotDisCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.CadetBlue
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label4.Location = New System.Drawing.Point(775, 620)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 27)
        Me.Label4.TabIndex = 91143
        Me.Label4.Text = "Discount :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTotBasic
        '
        Me.txtTotBasic.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.txtTotBasic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotBasic.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotBasic.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtTotBasic.ForeColor = System.Drawing.Color.Black
        Me.txtTotBasic.Location = New System.Drawing.Point(655, 620)
        Me.txtTotBasic.Name = "txtTotBasic"
        Me.txtTotBasic.ReadOnly = True
        Me.txtTotBasic.Size = New System.Drawing.Size(120, 27)
        Me.txtTotBasic.TabIndex = 91142
        Me.txtTotBasic.TabStop = False
        Me.txtTotBasic.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.CadetBlue
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label3.Location = New System.Drawing.Point(558, 620)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 27)
        Me.Label3.TabIndex = 91141
        Me.Label3.Text = "Amount :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(361, 7)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 91136
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
        Me.btnClose.TabIndex = 91116
        Me.btnClose.TabStop = False
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnPrint
        '
        Me.btnPrint.BackColor = System.Drawing.Color.ForestGreen
        Me.btnPrint.FlatAppearance.BorderSize = 0
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnPrint.ForeColor = System.Drawing.Color.GhostWhite
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrint.Location = New System.Drawing.Point(507, 89)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(100, 27)
        Me.btnPrint.TabIndex = 40066
        Me.btnPrint.TabStop = False
        Me.btnPrint.Text = "&Print"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'btnShow
        '
        Me.btnShow.BackColor = System.Drawing.Color.DarkTurquoise
        Me.btnShow.FlatAppearance.BorderSize = 0
        Me.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShow.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnShow.ForeColor = System.Drawing.Color.GhostWhite
        Me.btnShow.Image = CType(resources.GetObject("btnShow.Image"), System.Drawing.Image)
        Me.btnShow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnShow.Location = New System.Drawing.Point(413, 89)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(93, 27)
        Me.btnShow.TabIndex = 116
        Me.btnShow.TabStop = False
        Me.btnShow.Text = "&Show"
        Me.btnShow.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnShow.UseVisualStyleBackColor = False
        '
        'RcptRegisterForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1196, 653)
        Me.Controls.Add(Me.TxtGrandTotal)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtTotDisCount)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtTotBasic)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTotalSearch)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtDiscSearch)
        Me.Controls.Add(Me.txtNetSearch)
        Me.Controls.Add(Me.txtCustomerSearch)
        Me.Controls.Add(Me.MsktoDate)
        Me.Controls.Add(Me.mskFromDate)
        Me.Controls.Add(Me.dg1)
        Me.Controls.Add(Me.dtp1)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnShow)
        Me.KeyPreview = True
        Me.Name = "RcptRegisterForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Receipt"
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents btnShow As System.Windows.Forms.Button
    Friend WithEvents MsktoDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mskFromDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents dg1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTotalSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDiscSearch As System.Windows.Forms.TextBox
    Friend WithEvents txtNetSearch As System.Windows.Forms.TextBox
    Friend WithEvents txtCustomerSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents dtp1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxtGrandTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTotDisCount As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTotBasic As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
