﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Absent_Account_List
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Absent_Account_List))
        Me.RadioAll = New System.Windows.Forms.RadioButton()
        Me.RadioSundryDebtors = New System.Windows.Forms.RadioButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.RadioSundryCreditors = New System.Windows.Forms.RadioButton()
        Me.pnlWait = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.txtCreditBal = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.txtDebitBal = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtAreaSearch = New System.Windows.Forms.TextBox()
        Me.btnPrintHindi = New System.Windows.Forms.Button()
        Me.TxtGrandTotal = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblRecordCount = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCustomerSearch = New System.Windows.Forms.TextBox()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.btnShow = New System.Windows.Forms.Button()
        Me.mskEntryDate = New System.Windows.Forms.MaskedTextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.dg1 = New System.Windows.Forms.DataGridView()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.pnlWait.SuspendLayout()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RadioAll
        '
        Me.RadioAll.AutoSize = True
        Me.RadioAll.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.RadioAll.ForeColor = System.Drawing.Color.Blue
        Me.RadioAll.Location = New System.Drawing.Point(1075, 76)
        Me.RadioAll.Name = "RadioAll"
        Me.RadioAll.Size = New System.Drawing.Size(105, 21)
        Me.RadioAll.TabIndex = 91221
        Me.RadioAll.TabStop = True
        Me.RadioAll.Text = "All Accounts"
        Me.RadioAll.UseVisualStyleBackColor = True
        '
        'RadioSundryDebtors
        '
        Me.RadioSundryDebtors.AutoSize = True
        Me.RadioSundryDebtors.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.RadioSundryDebtors.ForeColor = System.Drawing.Color.Blue
        Me.RadioSundryDebtors.Location = New System.Drawing.Point(915, 76)
        Me.RadioSundryDebtors.Name = "RadioSundryDebtors"
        Me.RadioSundryDebtors.Size = New System.Drawing.Size(76, 21)
        Me.RadioSundryDebtors.TabIndex = 91219
        Me.RadioSundryDebtors.TabStop = True
        Me.RadioSundryDebtors.Text = "Debtors"
        Me.RadioSundryDebtors.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Bodoni Bk BT", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(71, 37)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(237, 48)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Please Wait..."
        '
        'RadioSundryCreditors
        '
        Me.RadioSundryCreditors.AutoSize = True
        Me.RadioSundryCreditors.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.RadioSundryCreditors.ForeColor = System.Drawing.Color.Blue
        Me.RadioSundryCreditors.Location = New System.Drawing.Point(991, 76)
        Me.RadioSundryCreditors.Name = "RadioSundryCreditors"
        Me.RadioSundryCreditors.Size = New System.Drawing.Size(84, 21)
        Me.RadioSundryCreditors.TabIndex = 91220
        Me.RadioSundryCreditors.TabStop = True
        Me.RadioSundryCreditors.Text = "Creditors"
        Me.RadioSundryCreditors.UseVisualStyleBackColor = True
        '
        'pnlWait
        '
        Me.pnlWait.BackColor = System.Drawing.Color.Maroon
        Me.pnlWait.Controls.Add(Me.Label7)
        Me.pnlWait.Location = New System.Drawing.Point(423, 339)
        Me.pnlWait.Name = "pnlWait"
        Me.pnlWait.Size = New System.Drawing.Size(388, 131)
        Me.pnlWait.TabIndex = 91241
        Me.pnlWait.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Bodoni Bk BT", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(399, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(431, 48)
        Me.Label1.TabIndex = 91238
        Me.Label1.Text = "ABSENT ACCOUNT LIST"
        '
        'Panel13
        '
        Me.Panel13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel13.Location = New System.Drawing.Point(599, 645)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(214, 1)
        Me.Panel13.TabIndex = 91235
        '
        'txtCreditBal
        '
        Me.txtCreditBal.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(111, Byte), Integer))
        Me.txtCreditBal.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCreditBal.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtCreditBal.ForeColor = System.Drawing.Color.Red
        Me.txtCreditBal.Location = New System.Drawing.Point(673, 622)
        Me.txtCreditBal.Name = "txtCreditBal"
        Me.txtCreditBal.ReadOnly = True
        Me.txtCreditBal.Size = New System.Drawing.Size(138, 20)
        Me.txtCreditBal.TabIndex = 91236
        Me.txtCreditBal.TabStop = False
        Me.txtCreditBal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(593, 622)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 21)
        Me.Label4.TabIndex = 91234
        Me.Label4.Text = "Credit : "
        '
        'Panel12
        '
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Location = New System.Drawing.Point(359, 645)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(214, 1)
        Me.Panel12.TabIndex = 91233
        '
        'txtDebitBal
        '
        Me.txtDebitBal.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(111, Byte), Integer))
        Me.txtDebitBal.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDebitBal.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtDebitBal.ForeColor = System.Drawing.Color.Red
        Me.txtDebitBal.Location = New System.Drawing.Point(435, 622)
        Me.txtDebitBal.Name = "txtDebitBal"
        Me.txtDebitBal.ReadOnly = True
        Me.txtDebitBal.Size = New System.Drawing.Size(138, 20)
        Me.txtDebitBal.TabIndex = 91232
        Me.txtDebitBal.TabStop = False
        Me.txtDebitBal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(355, 621)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 21)
        Me.Label3.TabIndex = 91231
        Me.Label3.Text = "Debit : "
        '
        'Panel10
        '
        Me.Panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel10.Location = New System.Drawing.Point(841, 645)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(341, 1)
        Me.Panel10.TabIndex = 91230
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(332, 108)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 21)
        Me.Label2.TabIndex = 91229
        Me.Label2.Text = "Area:"
        '
        'txtAreaSearch
        '
        Me.txtAreaSearch.BackColor = System.Drawing.Color.White
        Me.txtAreaSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAreaSearch.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtAreaSearch.ForeColor = System.Drawing.Color.Gray
        Me.txtAreaSearch.Location = New System.Drawing.Point(407, 106)
        Me.txtAreaSearch.Name = "txtAreaSearch"
        Me.txtAreaSearch.Size = New System.Drawing.Size(202, 27)
        Me.txtAreaSearch.TabIndex = 91223
        Me.txtAreaSearch.TabStop = False
        '
        'btnPrintHindi
        '
        Me.btnPrintHindi.BackColor = System.Drawing.Color.Teal
        Me.btnPrintHindi.FlatAppearance.BorderSize = 0
        Me.btnPrintHindi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintHindi.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnPrintHindi.ForeColor = System.Drawing.Color.GhostWhite
        Me.btnPrintHindi.Location = New System.Drawing.Point(1075, 103)
        Me.btnPrintHindi.Name = "btnPrintHindi"
        Me.btnPrintHindi.Size = New System.Drawing.Size(105, 30)
        Me.btnPrintHindi.TabIndex = 91218
        Me.btnPrintHindi.TabStop = False
        Me.btnPrintHindi.Text = "Print &Hindi"
        Me.btnPrintHindi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPrintHindi.UseVisualStyleBackColor = False
        '
        'TxtGrandTotal
        '
        Me.TxtGrandTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(111, Byte), Integer))
        Me.TxtGrandTotal.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtGrandTotal.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TxtGrandTotal.ForeColor = System.Drawing.Color.Red
        Me.TxtGrandTotal.Location = New System.Drawing.Point(1006, 622)
        Me.TxtGrandTotal.Name = "TxtGrandTotal"
        Me.TxtGrandTotal.ReadOnly = True
        Me.TxtGrandTotal.Size = New System.Drawing.Size(174, 20)
        Me.TxtGrandTotal.TabIndex = 91228
        Me.TxtGrandTotal.TabStop = False
        Me.TxtGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(837, 622)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(165, 21)
        Me.Label5.TabIndex = 91227
        Me.Label5.Text = "Total Outstanding : "
        '
        'lblRecordCount
        '
        Me.lblRecordCount.AutoSize = True
        Me.lblRecordCount.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblRecordCount.ForeColor = System.Drawing.Color.Black
        Me.lblRecordCount.Location = New System.Drawing.Point(13, 623)
        Me.lblRecordCount.Name = "lblRecordCount"
        Me.lblRecordCount.Size = New System.Drawing.Size(90, 16)
        Me.lblRecordCount.TabIndex = 91226
        Me.lblRecordCount.Text = "Account Name"
        Me.lblRecordCount.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(19, 112)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 21)
        Me.Label6.TabIndex = 91225
        Me.Label6.Text = "Account:"
        '
        'txtCustomerSearch
        '
        Me.txtCustomerSearch.BackColor = System.Drawing.Color.White
        Me.txtCustomerSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerSearch.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtCustomerSearch.ForeColor = System.Drawing.Color.Gray
        Me.txtCustomerSearch.Location = New System.Drawing.Point(109, 106)
        Me.txtCustomerSearch.Name = "txtCustomerSearch"
        Me.txtCustomerSearch.Size = New System.Drawing.Size(217, 27)
        Me.txtCustomerSearch.TabIndex = 91222
        Me.txtCustomerSearch.TabStop = False
        '
        'BtnPrint
        '
        Me.BtnPrint.BackColor = System.Drawing.Color.Teal
        Me.BtnPrint.FlatAppearance.BorderSize = 0
        Me.BtnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPrint.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.BtnPrint.ForeColor = System.Drawing.Color.GhostWhite
        Me.BtnPrint.Location = New System.Drawing.Point(993, 103)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(76, 30)
        Me.BtnPrint.TabIndex = 91217
        Me.BtnPrint.TabStop = False
        Me.BtnPrint.Text = "&Print"
        Me.BtnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnPrint.UseVisualStyleBackColor = False
        '
        'btnShow
        '
        Me.btnShow.BackColor = System.Drawing.Color.Teal
        Me.btnShow.FlatAppearance.BorderSize = 0
        Me.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShow.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnShow.ForeColor = System.Drawing.Color.GhostWhite
        Me.btnShow.Location = New System.Drawing.Point(911, 103)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(76, 30)
        Me.btnShow.TabIndex = 91216
        Me.btnShow.TabStop = False
        Me.btnShow.Text = "&Show"
        Me.btnShow.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnShow.UseVisualStyleBackColor = False
        '
        'mskEntryDate
        '
        Me.mskEntryDate.BackColor = System.Drawing.Color.GhostWhite
        Me.mskEntryDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskEntryDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskEntryDate.Location = New System.Drawing.Point(791, 106)
        Me.mskEntryDate.Mask = "00-00-0000"
        Me.mskEntryDate.Name = "mskEntryDate"
        Me.mskEntryDate.Size = New System.Drawing.Size(114, 26)
        Me.mskEntryDate.TabIndex = 91215
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(699, 108)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(86, 21)
        Me.Label25.TabIndex = 91224
        Me.Label25.Text = "On Date :"
        '
        'dg1
        '
        Me.dg1.AllowUserToAddRows = False
        Me.dg1.AllowUserToDeleteRows = False
        Me.dg1.AllowUserToResizeRows = False
        Me.dg1.BackgroundColor = System.Drawing.Color.White
        Me.dg1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Crimson
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dg1.ColumnHeadersHeight = 28
        Me.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.CadetBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg1.DefaultCellStyle = DataGridViewCellStyle2
        Me.dg1.EnableHeadersVisualStyles = False
        Me.dg1.GridColor = System.Drawing.Color.Crimson
        Me.dg1.Location = New System.Drawing.Point(10, 139)
        Me.dg1.MultiSelect = False
        Me.dg1.Name = "dg1"
        Me.dg1.ReadOnly = True
        Me.dg1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg1.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dg1.RowHeadersVisible = False
        Me.dg1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        Me.dg1.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dg1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dg1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg1.Size = New System.Drawing.Size(1170, 479)
        Me.dg1.TabIndex = 91237
        '
        'btnClose
        '
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(1141, 1)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(53, 47)
        Me.btnClose.TabIndex = 91240
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(343, 7)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox4.TabIndex = 91239
        Me.PictureBox4.TabStop = False
        '
        'Absent_Account_List
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(111, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1196, 653)
        Me.Controls.Add(Me.RadioAll)
        Me.Controls.Add(Me.RadioSundryDebtors)
        Me.Controls.Add(Me.RadioSundryCreditors)
        Me.Controls.Add(Me.pnlWait)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel13)
        Me.Controls.Add(Me.txtCreditBal)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Panel12)
        Me.Controls.Add(Me.txtDebitBal)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel10)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtAreaSearch)
        Me.Controls.Add(Me.btnPrintHindi)
        Me.Controls.Add(Me.TxtGrandTotal)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblRecordCount)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtCustomerSearch)
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.btnShow)
        Me.Controls.Add(Me.mskEntryDate)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.dg1)
        Me.Name = "Absent_Account_List"
        Me.Text = "Absent_Account_List"
        Me.pnlWait.ResumeLayout(False)
        Me.pnlWait.PerformLayout()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RadioAll As System.Windows.Forms.RadioButton
    Friend WithEvents RadioSundryDebtors As System.Windows.Forms.RadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents RadioSundryCreditors As System.Windows.Forms.RadioButton
    Friend WithEvents pnlWait As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel13 As System.Windows.Forms.Panel
    Friend WithEvents txtCreditBal As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents txtDebitBal As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtAreaSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnPrintHindi As System.Windows.Forms.Button
    Friend WithEvents TxtGrandTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblRecordCount As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCustomerSearch As System.Windows.Forms.TextBox
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents btnShow As System.Windows.Forms.Button
    Friend WithEvents mskEntryDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents dg1 As System.Windows.Forms.DataGridView
End Class
