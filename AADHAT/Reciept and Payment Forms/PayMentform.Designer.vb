﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PayMentform
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
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PayMentform))
        Me.DgAccountSearch = New System.Windows.Forms.DataGridView()
        Me.txtAccount = New System.Windows.Forms.TextBox()
        Me.txtMode = New System.Windows.Forms.TextBox()
        Me.dgMode = New System.Windows.Forms.DataGridView()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.txtTotDisc = New System.Windows.Forms.TextBox()
        Me.txttotNet = New System.Windows.Forms.TextBox()
        Me.lblInword = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.TxtRemark = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTotalAmount = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDiscountAmount = New System.Windows.Forms.TextBox()
        Me.txtReciveAmount = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtReciptNo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.mskEntryDate = New System.Windows.Forms.MaskedTextBox()
        Me.txtAccountID = New System.Windows.Forms.TextBox()
        Me.txtModeID = New System.Windows.Forms.TextBox()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblCapAcBal = New System.Windows.Forms.Label()
        Me.lblAcBal = New System.Windows.Forms.Label()
        Me.dg1 = New System.Windows.Forms.DataGridView()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.pnlInvoiceID = New System.Windows.Forms.Panel()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.txtInvoiceID = New System.Windows.Forms.TextBox()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.btnFirst = New System.Windows.Forms.Button()
        Me.btnLast = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnPrevious = New System.Windows.Forms.Button()
        Me.dtp1 = New System.Windows.Forms.DateTimePicker()
        CType(Me.DgAccountSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgMode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlInvoiceID.SuspendLayout()
        Me.SuspendLayout()
        '
        'DgAccountSearch
        '
        Me.DgAccountSearch.AllowUserToAddRows = False
        Me.DgAccountSearch.AllowUserToDeleteRows = False
        Me.DgAccountSearch.AllowUserToResizeRows = False
        Me.DgAccountSearch.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.DgAccountSearch.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgAccountSearch.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgAccountSearch.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.DgAccountSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgAccountSearch.ColumnHeadersVisible = False
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgAccountSearch.DefaultCellStyle = DataGridViewCellStyle11
        Me.DgAccountSearch.GridColor = System.Drawing.Color.GhostWhite
        Me.DgAccountSearch.Location = New System.Drawing.Point(282, 165)
        Me.DgAccountSearch.MultiSelect = False
        Me.DgAccountSearch.Name = "DgAccountSearch"
        Me.DgAccountSearch.ReadOnly = True
        Me.DgAccountSearch.RowHeadersVisible = False
        Me.DgAccountSearch.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.DgAccountSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgAccountSearch.Size = New System.Drawing.Size(310, 202)
        Me.DgAccountSearch.TabIndex = 40150
        Me.DgAccountSearch.TabStop = False
        Me.DgAccountSearch.Visible = False
        '
        'txtAccount
        '
        Me.txtAccount.BackColor = System.Drawing.Color.GhostWhite
        Me.txtAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAccount.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtAccount.ForeColor = System.Drawing.Color.Black
        Me.txtAccount.Location = New System.Drawing.Point(282, 139)
        Me.txtAccount.Name = "txtAccount"
        Me.txtAccount.Size = New System.Drawing.Size(211, 27)
        Me.txtAccount.TabIndex = 2
        Me.txtAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMode
        '
        Me.txtMode.BackColor = System.Drawing.Color.GhostWhite
        Me.txtMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMode.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtMode.ForeColor = System.Drawing.Color.Black
        Me.txtMode.Location = New System.Drawing.Point(111, 139)
        Me.txtMode.Name = "txtMode"
        Me.txtMode.Size = New System.Drawing.Size(172, 27)
        Me.txtMode.TabIndex = 1
        Me.txtMode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dgMode
        '
        Me.dgMode.AllowUserToAddRows = False
        Me.dgMode.AllowUserToDeleteRows = False
        Me.dgMode.AllowUserToResizeRows = False
        Me.dgMode.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgMode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgMode.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Teal
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgMode.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgMode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgMode.ColumnHeadersVisible = False
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgMode.DefaultCellStyle = DataGridViewCellStyle13
        Me.dgMode.GridColor = System.Drawing.Color.GhostWhite
        Me.dgMode.Location = New System.Drawing.Point(111, 165)
        Me.dgMode.MultiSelect = False
        Me.dgMode.Name = "dgMode"
        Me.dgMode.ReadOnly = True
        Me.dgMode.RowHeadersVisible = False
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black
        Me.dgMode.RowsDefaultCellStyle = DataGridViewCellStyle14
        Me.dgMode.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dgMode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgMode.Size = New System.Drawing.Size(262, 202)
        Me.dgMode.TabIndex = 40149
        Me.dgMode.TabStop = False
        Me.dgMode.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(1137, 592)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 21)
        Me.Label11.TabIndex = 40148
        Me.Label11.Text = "Total"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(960, 592)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(78, 21)
        Me.Label10.TabIndex = 40147
        Me.Label10.Text = "Discount"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(836, 592)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 21)
        Me.Label9.TabIndex = 40146
        Me.Label9.Text = "Basic"
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.GhostWhite
        Me.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotal.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtTotal.ForeColor = System.Drawing.Color.Navy
        Me.txtTotal.Location = New System.Drawing.Point(1031, 615)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(150, 27)
        Me.txtTotal.TabIndex = 40145
        Me.txtTotal.TabStop = False
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotDisc
        '
        Me.txtTotDisc.BackColor = System.Drawing.Color.GhostWhite
        Me.txtTotDisc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotDisc.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtTotDisc.ForeColor = System.Drawing.Color.Navy
        Me.txtTotDisc.Location = New System.Drawing.Point(882, 615)
        Me.txtTotDisc.Name = "txtTotDisc"
        Me.txtTotDisc.Size = New System.Drawing.Size(150, 27)
        Me.txtTotDisc.TabIndex = 40144
        Me.txtTotDisc.TabStop = False
        Me.txtTotDisc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txttotNet
        '
        Me.txttotNet.BackColor = System.Drawing.Color.GhostWhite
        Me.txttotNet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txttotNet.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txttotNet.ForeColor = System.Drawing.Color.Navy
        Me.txttotNet.Location = New System.Drawing.Point(733, 615)
        Me.txttotNet.Name = "txttotNet"
        Me.txttotNet.Size = New System.Drawing.Size(150, 27)
        Me.txttotNet.TabIndex = 40143
        Me.txttotNet.TabStop = False
        Me.txttotNet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblInword
        '
        Me.lblInword.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInword.ForeColor = System.Drawing.Color.Blue
        Me.lblInword.Location = New System.Drawing.Point(87, 624)
        Me.lblInword.Name = "lblInword"
        Me.lblInword.Size = New System.Drawing.Size(260, 20)
        Me.lblInword.TabIndex = 40142
        Me.lblInword.Text = "Amount in Words"
        Me.lblInword.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(870, 117)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 21)
        Me.Label8.TabIndex = 40141
        Me.Label8.Text = "Total"
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.DarkSlateGray
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.GhostWhite
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(1050, 86)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(131, 47)
        Me.btnSave.TabIndex = 8
        Me.btnSave.Text = "&Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'TxtRemark
        '
        Me.TxtRemark.BackColor = System.Drawing.Color.GhostWhite
        Me.TxtRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtRemark.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TxtRemark.ForeColor = System.Drawing.Color.Black
        Me.TxtRemark.Location = New System.Drawing.Point(919, 139)
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(263, 27)
        Me.TxtRemark.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(925, 116)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 21)
        Me.Label7.TabIndex = 40139
        Me.Label7.Text = "Remark"
        '
        'txtTotalAmount
        '
        Me.txtTotalAmount.BackColor = System.Drawing.Color.GhostWhite
        Me.txtTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalAmount.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtTotalAmount.ForeColor = System.Drawing.Color.Black
        Me.txtTotalAmount.Location = New System.Drawing.Point(799, 139)
        Me.txtTotalAmount.Name = "txtTotalAmount"
        Me.txtTotalAmount.Size = New System.Drawing.Size(121, 27)
        Me.txtTotalAmount.TabIndex = 6
        Me.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(722, 116)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 21)
        Me.Label6.TabIndex = 40138
        Me.Label6.Text = "Discount"
        '
        'txtDiscountAmount
        '
        Me.txtDiscountAmount.BackColor = System.Drawing.Color.GhostWhite
        Me.txtDiscountAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiscountAmount.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtDiscountAmount.ForeColor = System.Drawing.Color.Black
        Me.txtDiscountAmount.Location = New System.Drawing.Point(690, 139)
        Me.txtDiscountAmount.Name = "txtDiscountAmount"
        Me.txtDiscountAmount.Size = New System.Drawing.Size(110, 27)
        Me.txtDiscountAmount.TabIndex = 5
        Me.txtDiscountAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtReciveAmount
        '
        Me.txtReciveAmount.BackColor = System.Drawing.Color.GhostWhite
        Me.txtReciveAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReciveAmount.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtReciveAmount.ForeColor = System.Drawing.Color.Black
        Me.txtReciveAmount.Location = New System.Drawing.Point(591, 139)
        Me.txtReciveAmount.Name = "txtReciveAmount"
        Me.txtReciveAmount.Size = New System.Drawing.Size(100, 27)
        Me.txtReciveAmount.TabIndex = 4
        Me.txtReciveAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(497, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 21)
        Me.Label4.TabIndex = 40136
        Me.Label4.Text = "Receipt No."
        '
        'txtReciptNo
        '
        Me.txtReciptNo.BackColor = System.Drawing.Color.GhostWhite
        Me.txtReciptNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReciptNo.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtReciptNo.ForeColor = System.Drawing.Color.Black
        Me.txtReciptNo.Location = New System.Drawing.Point(492, 139)
        Me.txtReciptNo.Name = "txtReciptNo"
        Me.txtReciptNo.Size = New System.Drawing.Size(100, 27)
        Me.txtReciptNo.TabIndex = 3
        Me.txtReciptNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(280, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(132, 21)
        Me.Label3.TabIndex = 40135
        Me.Label3.Text = "Account Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(107, 116)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 21)
        Me.Label2.TabIndex = 40134
        Me.Label2.Text = "Mode"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(34, 117)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 21)
        Me.Label1.TabIndex = 40133
        Me.Label1.Text = "Date"
        '
        'mskEntryDate
        '
        Me.mskEntryDate.BackColor = System.Drawing.Color.GhostWhite
        Me.mskEntryDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskEntryDate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.mskEntryDate.ForeColor = System.Drawing.Color.Black
        Me.mskEntryDate.Location = New System.Drawing.Point(12, 139)
        Me.mskEntryDate.Mask = "00-00-0000"
        Me.mskEntryDate.Name = "mskEntryDate"
        Me.mskEntryDate.Size = New System.Drawing.Size(85, 27)
        Me.mskEntryDate.TabIndex = 0
        '
        'txtAccountID
        '
        Me.txtAccountID.BackColor = System.Drawing.Color.AliceBlue
        Me.txtAccountID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAccountID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccountID.ForeColor = System.Drawing.Color.Teal
        Me.txtAccountID.Location = New System.Drawing.Point(144, 26)
        Me.txtAccountID.Name = "txtAccountID"
        Me.txtAccountID.Size = New System.Drawing.Size(48, 26)
        Me.txtAccountID.TabIndex = 91114
        Me.txtAccountID.TabStop = False
        Me.txtAccountID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtAccountID.Visible = False
        '
        'txtModeID
        '
        Me.txtModeID.BackColor = System.Drawing.Color.AliceBlue
        Me.txtModeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtModeID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtModeID.ForeColor = System.Drawing.Color.Teal
        Me.txtModeID.Location = New System.Drawing.Point(90, 26)
        Me.txtModeID.Name = "txtModeID"
        Me.txtModeID.Size = New System.Drawing.Size(48, 26)
        Me.txtModeID.TabIndex = 91113
        Me.txtModeID.TabStop = False
        Me.txtModeID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtModeID.Visible = False
        '
        'txtID
        '
        Me.txtID.BackColor = System.Drawing.Color.AliceBlue
        Me.txtID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtID.Location = New System.Drawing.Point(17, 26)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(67, 26)
        Me.txtID.TabIndex = 40029
        Me.txtID.TabStop = False
        Me.txtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtID.Visible = False
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Bodoni Bk BT", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.Black
        Me.Label41.Location = New System.Drawing.Point(492, 9)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(194, 48)
        Me.Label41.TabIndex = 101
        Me.Label41.Text = "PAYMENT"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(616, 115)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 21)
        Me.Label5.TabIndex = 40137
        Me.Label5.Text = "Amount"
        '
        'lblCapAcBal
        '
        Me.lblCapAcBal.AutoSize = True
        Me.lblCapAcBal.Font = New System.Drawing.Font("Times New Roman", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblCapAcBal.ForeColor = System.Drawing.Color.Navy
        Me.lblCapAcBal.Location = New System.Drawing.Point(108, 93)
        Me.lblCapAcBal.Name = "lblCapAcBal"
        Me.lblCapAcBal.Size = New System.Drawing.Size(28, 16)
        Me.lblCapAcBal.TabIndex = 40152
        Me.lblCapAcBal.Text = "Bal"
        Me.lblCapAcBal.Visible = False
        '
        'lblAcBal
        '
        Me.lblAcBal.AutoSize = True
        Me.lblAcBal.Font = New System.Drawing.Font("Times New Roman", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblAcBal.ForeColor = System.Drawing.Color.Navy
        Me.lblAcBal.Location = New System.Drawing.Point(281, 93)
        Me.lblAcBal.Name = "lblAcBal"
        Me.lblAcBal.Size = New System.Drawing.Size(28, 16)
        Me.lblAcBal.TabIndex = 40151
        Me.lblAcBal.Text = "Bal"
        Me.lblAcBal.Visible = False
        '
        'dg1
        '
        Me.dg1.AllowUserToAddRows = False
        Me.dg1.AllowUserToDeleteRows = False
        Me.dg1.AllowUserToResizeRows = False
        Me.dg1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.dg1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(241, Byte), Integer))
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Crimson
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.dg1.ColumnHeadersHeight = 28
        Me.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        DataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.CadetBlue
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg1.DefaultCellStyle = DataGridViewCellStyle16
        Me.dg1.EnableHeadersVisualStyles = False
        Me.dg1.GridColor = System.Drawing.Color.Crimson
        Me.dg1.Location = New System.Drawing.Point(12, 165)
        Me.dg1.MultiSelect = False
        Me.dg1.Name = "dg1"
        Me.dg1.ReadOnly = True
        Me.dg1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg1.RowHeadersDefaultCellStyle = DataGridViewCellStyle17
        Me.dg1.RowHeadersVisible = False
        Me.dg1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black
        Me.dg1.RowsDefaultCellStyle = DataGridViewCellStyle18
        Me.dg1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dg1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg1.Size = New System.Drawing.Size(1170, 424)
        Me.dg1.TabIndex = 91204
        Me.dg1.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(436, 9)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox4.TabIndex = 91212
        Me.PictureBox4.TabStop = False
        '
        'btnClose
        '
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(1143, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(53, 47)
        Me.btnClose.TabIndex = 91248
        Me.btnClose.TabStop = False
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'pnlInvoiceID
        '
        Me.pnlInvoiceID.Controls.Add(Me.Label56)
        Me.pnlInvoiceID.Controls.Add(Me.txtInvoiceID)
        Me.pnlInvoiceID.Location = New System.Drawing.Point(492, 165)
        Me.pnlInvoiceID.Name = "pnlInvoiceID"
        Me.pnlInvoiceID.Size = New System.Drawing.Size(176, 74)
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
        Me.Label56.Size = New System.Drawing.Size(89, 21)
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
        Me.txtInvoiceID.Size = New System.Drawing.Size(171, 27)
        Me.txtInvoiceID.TabIndex = 2
        Me.txtInvoiceID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BtnDelete
        '
        Me.BtnDelete.BackColor = System.Drawing.Color.DarkRed
        Me.BtnDelete.FlatAppearance.BorderSize = 0
        Me.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDelete.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.BtnDelete.ForeColor = System.Drawing.Color.Green
        Me.BtnDelete.Image = CType(resources.GetObject("BtnDelete.Image"), System.Drawing.Image)
        Me.BtnDelete.Location = New System.Drawing.Point(12, 596)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(56, 56)
        Me.BtnDelete.TabIndex = 91252
        Me.BtnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnDelete.UseVisualStyleBackColor = False
        Me.BtnDelete.Visible = False
        '
        'btnFirst
        '
        Me.btnFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFirst.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnFirst.ForeColor = System.Drawing.Color.Navy
        Me.btnFirst.Location = New System.Drawing.Point(530, 618)
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.Size = New System.Drawing.Size(44, 23)
        Me.btnFirst.TabIndex = 91259
        Me.btnFirst.TabStop = False
        Me.btnFirst.Text = "|<"
        Me.btnFirst.UseVisualStyleBackColor = True
        '
        'btnLast
        '
        Me.btnLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLast.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnLast.ForeColor = System.Drawing.Color.Navy
        Me.btnLast.Location = New System.Drawing.Point(680, 618)
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(44, 23)
        Me.btnLast.TabIndex = 91258
        Me.btnLast.TabStop = False
        Me.btnLast.Text = ">|"
        Me.btnLast.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNext.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnNext.ForeColor = System.Drawing.Color.Navy
        Me.btnNext.Location = New System.Drawing.Point(630, 618)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(44, 23)
        Me.btnNext.TabIndex = 91257
        Me.btnNext.TabStop = False
        Me.btnNext.Text = ">>"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnPrevious
        '
        Me.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrevious.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnPrevious.ForeColor = System.Drawing.Color.Navy
        Me.btnPrevious.Location = New System.Drawing.Point(580, 618)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(44, 23)
        Me.btnPrevious.TabIndex = 91256
        Me.btnPrevious.TabStop = False
        Me.btnPrevious.Text = "<<"
        Me.btnPrevious.UseVisualStyleBackColor = True
        '
        'dtp1
        '
        Me.dtp1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.dtp1.Location = New System.Drawing.Point(12, 139)
        Me.dtp1.Name = "dtp1"
        Me.dtp1.Size = New System.Drawing.Size(100, 27)
        Me.dtp1.TabIndex = 91260
        Me.dtp1.TabStop = False
        '
        'PayMentform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1196, 653)
        Me.Controls.Add(Me.btnFirst)
        Me.Controls.Add(Me.btnLast)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnPrevious)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.pnlInvoiceID)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.txtAccountID)
        Me.Controls.Add(Me.dgMode)
        Me.Controls.Add(Me.txtModeID)
        Me.Controls.Add(Me.DgAccountSearch)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.dg1)
        Me.Controls.Add(Me.lblCapAcBal)
        Me.Controls.Add(Me.lblAcBal)
        Me.Controls.Add(Me.txtAccount)
        Me.Controls.Add(Me.txtMode)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.txtTotDisc)
        Me.Controls.Add(Me.txttotNet)
        Me.Controls.Add(Me.lblInword)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.TxtRemark)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtTotalAmount)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtDiscountAmount)
        Me.Controls.Add(Me.txtReciveAmount)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtReciptNo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.mskEntryDate)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dtp1)
        Me.Name = "PayMentform"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Payment"
        CType(Me.DgAccountSearch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgMode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlInvoiceID.ResumeLayout(False)
        Me.pnlInvoiceID.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DgAccountSearch As System.Windows.Forms.DataGridView
    Friend WithEvents txtAccount As System.Windows.Forms.TextBox
    Friend WithEvents txtMode As System.Windows.Forms.TextBox
    Friend WithEvents dgMode As System.Windows.Forms.DataGridView
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtTotDisc As System.Windows.Forms.TextBox
    Friend WithEvents txttotNet As System.Windows.Forms.TextBox
    Friend WithEvents lblInword As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents TxtRemark As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTotalAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDiscountAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtReciveAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtReciptNo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents mskEntryDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtAccountID As System.Windows.Forms.TextBox
    Friend WithEvents txtModeID As System.Windows.Forms.TextBox
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblCapAcBal As System.Windows.Forms.Label
    Friend WithEvents lblAcBal As System.Windows.Forms.Label
    Friend WithEvents dg1 As System.Windows.Forms.DataGridView
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents pnlInvoiceID As System.Windows.Forms.Panel
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceID As System.Windows.Forms.TextBox
    Friend WithEvents BtnDelete As System.Windows.Forms.Button
    Friend WithEvents btnFirst As System.Windows.Forms.Button
    Friend WithEvents btnLast As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnPrevious As System.Windows.Forms.Button
    Friend WithEvents dtp1 As System.Windows.Forms.DateTimePicker
End Class
