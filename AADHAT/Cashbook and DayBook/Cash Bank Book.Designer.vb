﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cash_Bank_Book
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cash_Bank_Book))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MsktoDate = New System.Windows.Forms.MaskedTextBox()
        Me.mskFromDate = New System.Windows.Forms.MaskedTextBox()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.btnShow = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.cbAccountName = New System.Windows.Forms.ComboBox()
        Me.dg1 = New System.Windows.Forms.DataGridView()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.dtp1 = New System.Windows.Forms.DateTimePicker()
        Me.Dtp2 = New System.Windows.Forms.DateTimePicker()
        Me.pnlWait = New System.Windows.Forms.Panel()
        Me.pb1 = New System.Windows.Forms.ProgressBar()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlWait.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Bodoni Bk BT", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(428, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(372, 48)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CASH / BANK  BOOK"
        '
        'MsktoDate
        '
        Me.MsktoDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MsktoDate.Font = New System.Drawing.Font("Times New Roman", 13.0!)
        Me.MsktoDate.Location = New System.Drawing.Point(777, 106)
        Me.MsktoDate.Mask = "00-00-0000"
        Me.MsktoDate.Name = "MsktoDate"
        Me.MsktoDate.Size = New System.Drawing.Size(110, 29)
        Me.MsktoDate.TabIndex = 3
        '
        'mskFromDate
        '
        Me.mskFromDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskFromDate.Font = New System.Drawing.Font("Times New Roman", 13.0!)
        Me.mskFromDate.Location = New System.Drawing.Point(565, 106)
        Me.mskFromDate.Mask = "00-00-0000"
        Me.mskFromDate.Name = "mskFromDate"
        Me.mskFromDate.Size = New System.Drawing.Size(112, 29)
        Me.mskFromDate.TabIndex = 2
        '
        'BtnPrint
        '
        Me.BtnPrint.BackColor = System.Drawing.Color.DarkSlateGray
        Me.BtnPrint.FlatAppearance.BorderSize = 0
        Me.BtnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPrint.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.BtnPrint.ForeColor = System.Drawing.Color.GhostWhite
        Me.BtnPrint.Location = New System.Drawing.Point(1042, 106)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(140, 29)
        Me.BtnPrint.TabIndex = 5
        Me.BtnPrint.TabStop = False
        Me.BtnPrint.Text = "&Print"
        Me.BtnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnPrint.UseVisualStyleBackColor = False
        '
        'btnShow
        '
        Me.btnShow.BackColor = System.Drawing.Color.LightSeaGreen
        Me.btnShow.FlatAppearance.BorderSize = 0
        Me.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShow.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnShow.ForeColor = System.Drawing.Color.GhostWhite
        Me.btnShow.Location = New System.Drawing.Point(903, 106)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(139, 29)
        Me.btnShow.TabIndex = 4
        Me.btnShow.TabStop = False
        Me.btnShow.Text = "&Show"
        Me.btnShow.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnShow.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.CadetBlue
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label2.Location = New System.Drawing.Point(692, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 29)
        Me.Label2.TabIndex = 40040
        Me.Label2.Text = "To Date:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.CadetBlue
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label3.Location = New System.Drawing.Point(465, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 29)
        Me.Label3.TabIndex = 40039
        Me.Label3.Text = "From Date :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.Color.CadetBlue
        Me.Label42.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label42.Location = New System.Drawing.Point(12, 106)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(136, 29)
        Me.Label42.TabIndex = 40038
        Me.Label42.Text = "Account Name"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbAccountName
        '
        Me.cbAccountName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbAccountName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbAccountName.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cbAccountName.FormattingEnabled = True
        Me.cbAccountName.Location = New System.Drawing.Point(148, 106)
        Me.cbAccountName.Name = "cbAccountName"
        Me.cbAccountName.Size = New System.Drawing.Size(319, 29)
        Me.cbAccountName.TabIndex = 1
        '
        'dg1
        '
        Me.dg1.AllowUserToAddRows = False
        Me.dg1.AllowUserToDeleteRows = False
        Me.dg1.AllowUserToResizeRows = False
        Me.dg1.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dg1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Crimson
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dg1.ColumnHeadersHeight = 28
        Me.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.CadetBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg1.DefaultCellStyle = DataGridViewCellStyle2
        Me.dg1.EnableHeadersVisualStyles = False
        Me.dg1.GridColor = System.Drawing.Color.Gray
        Me.dg1.Location = New System.Drawing.Point(12, 134)
        Me.dg1.MultiSelect = False
        Me.dg1.Name = "dg1"
        Me.dg1.ReadOnly = True
        Me.dg1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
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
        Me.dg1.Size = New System.Drawing.Size(1170, 507)
        Me.dg1.TabIndex = 91214
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(372, 9)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox4.TabIndex = 91217
        Me.PictureBox4.TabStop = False
        '
        'dtp1
        '
        Me.dtp1.Font = New System.Drawing.Font("Times New Roman", 13.0!)
        Me.dtp1.Location = New System.Drawing.Point(565, 106)
        Me.dtp1.Name = "dtp1"
        Me.dtp1.Size = New System.Drawing.Size(127, 29)
        Me.dtp1.TabIndex = 91219
        '
        'Dtp2
        '
        Me.Dtp2.Font = New System.Drawing.Font("Times New Roman", 13.0!)
        Me.Dtp2.Location = New System.Drawing.Point(777, 106)
        Me.Dtp2.Name = "Dtp2"
        Me.Dtp2.Size = New System.Drawing.Size(126, 29)
        Me.Dtp2.TabIndex = 91220
        '
        'pnlWait
        '
        Me.pnlWait.BackColor = System.Drawing.Color.Maroon
        Me.pnlWait.Controls.Add(Me.pb1)
        Me.pnlWait.Controls.Add(Me.Label4)
        Me.pnlWait.Location = New System.Drawing.Point(397, 301)
        Me.pnlWait.Name = "pnlWait"
        Me.pnlWait.Size = New System.Drawing.Size(388, 131)
        Me.pnlWait.TabIndex = 91269
        Me.pnlWait.Visible = False
        '
        'pb1
        '
        Me.pb1.Location = New System.Drawing.Point(3, 103)
        Me.pb1.Name = "pb1"
        Me.pb1.Size = New System.Drawing.Size(382, 23)
        Me.pb1.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Bodoni Bk BT", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label4.Location = New System.Drawing.Point(71, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(237, 48)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Please Wait..."
        '
        'btnClose
        '
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(1154, -1)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(40, 40)
        Me.btnClose.TabIndex = 91270
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Cash_Bank_Book
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1196, 653)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.pnlWait)
        Me.Controls.Add(Me.MsktoDate)
        Me.Controls.Add(Me.Dtp2)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dg1)
        Me.Controls.Add(Me.cbAccountName)
        Me.Controls.Add(Me.mskFromDate)
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.btnShow)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label42)
        Me.Controls.Add(Me.dtp1)
        Me.KeyPreview = True
        Me.Name = "Cash_Bank_Book"
        Me.Text = "Cash_Bank_Book"
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlWait.ResumeLayout(False)
        Me.pnlWait.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MsktoDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mskFromDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents btnShow As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents cbAccountName As System.Windows.Forms.ComboBox
    Friend WithEvents dg1 As System.Windows.Forms.DataGridView
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents dtp1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Dtp2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents pnlWait As System.Windows.Forms.Panel
    Friend WithEvents pb1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class
