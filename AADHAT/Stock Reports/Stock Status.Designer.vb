<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Stock_Status
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Stock_Status))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dg1 = New System.Windows.Forms.DataGridView()
        Me.txtItemSearch = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtSoldQty = New System.Windows.Forms.TextBox()
        Me.txtOpQty = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.btnShow = New System.Windows.Forms.Button()
        Me.mskFromDate = New System.Windows.Forms.MaskedTextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.dtp1 = New System.Windows.Forms.DateTimePicker()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtPurchaseQty = New System.Windows.Forms.TextBox()
        Me.txtBalanceQty = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlWait = New System.Windows.Forms.Panel()
        Me.pb1 = New System.Windows.Forms.ProgressBar()
        Me.Label66 = New System.Windows.Forms.Label()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlWait.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Bodoni Bk BT", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(453, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(283, 48)
        Me.Label1.TabIndex = 91140
        Me.Label1.Text = "STOCK STATUS"
        '
        'dg1
        '
        Me.dg1.AllowUserToAddRows = False
        Me.dg1.AllowUserToDeleteRows = False
        Me.dg1.AllowUserToResizeRows = False
        Me.dg1.BackgroundColor = System.Drawing.Color.White
        Me.dg1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Crimson
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Crimson
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dg1.ColumnHeadersHeight = 28
        Me.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Orange
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg1.DefaultCellStyle = DataGridViewCellStyle2
        Me.dg1.EnableHeadersVisualStyles = False
        Me.dg1.GridColor = System.Drawing.Color.Crimson
        Me.dg1.Location = New System.Drawing.Point(12, 136)
        Me.dg1.MultiSelect = False
        Me.dg1.Name = "dg1"
        Me.dg1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dg1.RowHeadersVisible = False
        Me.dg1.RowHeadersWidth = 42
        Me.dg1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.dg1.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dg1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dg1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg1.Size = New System.Drawing.Size(1172, 446)
        Me.dg1.TabIndex = 91173
        Me.dg1.TabStop = False
        '
        'txtItemSearch
        '
        Me.txtItemSearch.BackColor = System.Drawing.Color.White
        Me.txtItemSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemSearch.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtItemSearch.ForeColor = System.Drawing.Color.Black
        Me.txtItemSearch.Location = New System.Drawing.Point(589, 111)
        Me.txtItemSearch.Name = "txtItemSearch"
        Me.txtItemSearch.Size = New System.Drawing.Size(595, 26)
        Me.txtItemSearch.TabIndex = 91166
        Me.txtItemSearch.TabStop = False
        Me.txtItemSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AllowDrop = True
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(631, 598)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 19)
        Me.Label6.TabIndex = 91155
        Me.Label6.Text = "Opening Qty"
        '
        'txtSoldQty
        '
        Me.txtSoldQty.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.txtSoldQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSoldQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSoldQty.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtSoldQty.ForeColor = System.Drawing.Color.Navy
        Me.txtSoldQty.Location = New System.Drawing.Point(885, 620)
        Me.txtSoldQty.Name = "txtSoldQty"
        Me.txtSoldQty.ReadOnly = True
        Me.txtSoldQty.Size = New System.Drawing.Size(150, 26)
        Me.txtSoldQty.TabIndex = 91152
        Me.txtSoldQty.TabStop = False
        Me.txtSoldQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtOpQty
        '
        Me.txtOpQty.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.txtOpQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOpQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOpQty.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtOpQty.ForeColor = System.Drawing.Color.Navy
        Me.txtOpQty.Location = New System.Drawing.Point(587, 620)
        Me.txtOpQty.Name = "txtOpQty"
        Me.txtOpQty.ReadOnly = True
        Me.txtOpQty.Size = New System.Drawing.Size(150, 26)
        Me.txtOpQty.TabIndex = 91149
        Me.txtOpQty.TabStop = False
        Me.txtOpQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Label25.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(12, 111)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(112, 27)
        Me.Label25.TabIndex = 91146
        Me.Label25.Text = "On Date :"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnShow
        '
        Me.btnShow.BackColor = System.Drawing.Color.DarkTurquoise
        Me.btnShow.FlatAppearance.BorderSize = 0
        Me.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShow.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.btnShow.ForeColor = System.Drawing.Color.GhostWhite
        Me.btnShow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnShow.Location = New System.Drawing.Point(238, 111)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(94, 27)
        Me.btnShow.TabIndex = 2
        Me.btnShow.Text = "&Show"
        Me.btnShow.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnShow.UseVisualStyleBackColor = False
        '
        'mskFromDate
        '
        Me.mskFromDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskFromDate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.mskFromDate.Location = New System.Drawing.Point(124, 111)
        Me.mskFromDate.Mask = "00-00-0000"
        Me.mskFromDate.Name = "mskFromDate"
        Me.mskFromDate.Size = New System.Drawing.Size(100, 26)
        Me.mskFromDate.TabIndex = 0
        '
        'Label20
        '
        Me.Label20.AllowDrop = True
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(962, 598)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(67, 19)
        Me.Label20.TabIndex = 91157
        Me.Label20.Text = "Sold Qty"
        '
        'dtp1
        '
        Me.dtp1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.dtp1.Location = New System.Drawing.Point(129, 111)
        Me.dtp1.Name = "dtp1"
        Me.dtp1.Size = New System.Drawing.Size(109, 26)
        Me.dtp1.TabIndex = 91176
        '
        'Label19
        '
        Me.Label19.AllowDrop = True
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(776, 598)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(99, 19)
        Me.Label19.TabIndex = 91156
        Me.Label19.Text = "Purchase Qty"
        '
        'txtPurchaseQty
        '
        Me.txtPurchaseQty.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.txtPurchaseQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPurchaseQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPurchaseQty.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtPurchaseQty.ForeColor = System.Drawing.Color.Navy
        Me.txtPurchaseQty.Location = New System.Drawing.Point(736, 620)
        Me.txtPurchaseQty.Name = "txtPurchaseQty"
        Me.txtPurchaseQty.ReadOnly = True
        Me.txtPurchaseQty.Size = New System.Drawing.Size(150, 26)
        Me.txtPurchaseQty.TabIndex = 91151
        Me.txtPurchaseQty.TabStop = False
        Me.txtPurchaseQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBalanceQty
        '
        Me.txtBalanceQty.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.txtBalanceQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBalanceQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBalanceQty.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtBalanceQty.ForeColor = System.Drawing.Color.Navy
        Me.txtBalanceQty.Location = New System.Drawing.Point(1034, 620)
        Me.txtBalanceQty.Name = "txtBalanceQty"
        Me.txtBalanceQty.ReadOnly = True
        Me.txtBalanceQty.Size = New System.Drawing.Size(150, 26)
        Me.txtBalanceQty.TabIndex = 91177
        Me.txtBalanceQty.TabStop = False
        Me.txtBalanceQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AllowDrop = True
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(1080, 598)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 19)
        Me.Label7.TabIndex = 91178
        Me.Label7.Text = "Balance Qty"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(397, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 91174
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
        Me.btnClose.TabIndex = 91150
        Me.btnClose.TabStop = False
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.MediumAquamarine
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.Button1.ForeColor = System.Drawing.Color.GhostWhite
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(332, 111)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 27)
        Me.Button1.TabIndex = 91144
        Me.Button1.TabStop = False
        Me.Button1.Text = "&Print"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(419, 111)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(171, 26)
        Me.Label2.TabIndex = 91181
        Me.Label2.Text = "Search Item Name :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlWait
        '
        Me.pnlWait.BackColor = System.Drawing.Color.Maroon
        Me.pnlWait.Controls.Add(Me.pb1)
        Me.pnlWait.Controls.Add(Me.Label66)
        Me.pnlWait.Location = New System.Drawing.Point(404, 261)
        Me.pnlWait.Name = "pnlWait"
        Me.pnlWait.Size = New System.Drawing.Size(388, 131)
        Me.pnlWait.TabIndex = 91356
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
        'Stock_Status
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1196, 653)
        Me.Controls.Add(Me.pnlWait)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtBalanceQty)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dg1)
        Me.Controls.Add(Me.txtItemSearch)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtSoldQty)
        Me.Controls.Add(Me.txtPurchaseQty)
        Me.Controls.Add(Me.txtOpQty)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnShow)
        Me.Controls.Add(Me.mskFromDate)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.dtp1)
        Me.Name = "Stock_Status"
        Me.Text = "Stock Report"
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlWait.ResumeLayout(False)
        Me.pnlWait.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dg1 As System.Windows.Forms.DataGridView
    Friend WithEvents txtItemSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtSoldQty As System.Windows.Forms.TextBox
    Friend WithEvents txtOpQty As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnShow As System.Windows.Forms.Button
    Friend WithEvents mskFromDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents dtp1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtPurchaseQty As System.Windows.Forms.TextBox
    Friend WithEvents txtBalanceQty As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pnlWait As System.Windows.Forms.Panel
    Friend WithEvents pb1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label66 As System.Windows.Forms.Label
End Class
