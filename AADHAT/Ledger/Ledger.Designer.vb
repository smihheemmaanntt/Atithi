<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ledger
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Ledger))
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnShow = New System.Windows.Forms.Button()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtOpBal = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtBalAmt = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtcrAmt = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDramt = New System.Windows.Forms.TextBox()
        Me.MsktoDate = New System.Windows.Forms.MaskedTextBox()
        Me.mskFromDate = New System.Windows.Forms.MaskedTextBox()
        Me.cbAccountName = New System.Windows.Forms.ComboBox()
        Me.dg1 = New System.Windows.Forms.DataGridView()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.dtp1 = New System.Windows.Forms.DateTimePicker()
        Me.dtp2 = New System.Windows.Forms.DateTimePicker()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Bodoni Bk BT", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.Black
        Me.Label41.Location = New System.Drawing.Point(523, 21)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(168, 48)
        Me.Label41.TabIndex = 20
        Me.Label41.Text = "LEDGER"
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.Color.CadetBlue
        Me.Label42.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label42.Location = New System.Drawing.Point(12, 140)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(164, 28)
        Me.Label42.TabIndex = 6
        Me.Label42.Text = "Account Name :"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.CadetBlue
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label1.Location = New System.Drawing.Point(535, 140)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 28)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "From Date :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.CadetBlue
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label2.Location = New System.Drawing.Point(756, 140)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 28)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "To Date :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnShow
        '
        Me.btnShow.BackColor = System.Drawing.Color.Chocolate
        Me.btnShow.FlatAppearance.BorderSize = 0
        Me.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShow.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnShow.ForeColor = System.Drawing.Color.GhostWhite
        Me.btnShow.Location = New System.Drawing.Point(964, 140)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(136, 28)
        Me.btnShow.TabIndex = 4
        Me.btnShow.Text = "&Show"
        Me.btnShow.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnShow.UseVisualStyleBackColor = False
        '
        'BtnPrint
        '
        Me.BtnPrint.BackColor = System.Drawing.Color.Navy
        Me.BtnPrint.FlatAppearance.BorderSize = 0
        Me.BtnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPrint.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.BtnPrint.ForeColor = System.Drawing.Color.GhostWhite
        Me.BtnPrint.Location = New System.Drawing.Point(1100, 140)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(82, 28)
        Me.BtnPrint.TabIndex = 5
        Me.BtnPrint.TabStop = False
        Me.BtnPrint.Text = "&Print"
        Me.BtnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnPrint.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.CadetBlue
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label6.Location = New System.Drawing.Point(755, 113)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(208, 27)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Opening Balance :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtOpBal
        '
        Me.txtOpBal.BackColor = System.Drawing.Color.GhostWhite
        Me.txtOpBal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOpBal.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtOpBal.ForeColor = System.Drawing.Color.Red
        Me.txtOpBal.Location = New System.Drawing.Point(962, 113)
        Me.txtOpBal.Name = "txtOpBal"
        Me.txtOpBal.ReadOnly = True
        Me.txtOpBal.Size = New System.Drawing.Size(220, 27)
        Me.txtOpBal.TabIndex = 9
        Me.txtOpBal.TabStop = False
        Me.txtOpBal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.CadetBlue
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label9.Location = New System.Drawing.Point(957, 615)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(102, 27)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Balance :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBalAmt
        '
        Me.txtBalAmt.BackColor = System.Drawing.Color.GhostWhite
        Me.txtBalAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBalAmt.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtBalAmt.ForeColor = System.Drawing.Color.Red
        Me.txtBalAmt.Location = New System.Drawing.Point(1059, 615)
        Me.txtBalAmt.Name = "txtBalAmt"
        Me.txtBalAmt.ReadOnly = True
        Me.txtBalAmt.Size = New System.Drawing.Size(123, 27)
        Me.txtBalAmt.TabIndex = 14
        Me.txtBalAmt.TabStop = False
        Me.txtBalAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.CadetBlue
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label8.Location = New System.Drawing.Point(752, 615)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 27)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Credit :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtcrAmt
        '
        Me.txtcrAmt.BackColor = System.Drawing.Color.GhostWhite
        Me.txtcrAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtcrAmt.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtcrAmt.ForeColor = System.Drawing.Color.Red
        Me.txtcrAmt.Location = New System.Drawing.Point(834, 615)
        Me.txtcrAmt.Name = "txtcrAmt"
        Me.txtcrAmt.ReadOnly = True
        Me.txtcrAmt.Size = New System.Drawing.Size(123, 27)
        Me.txtcrAmt.TabIndex = 13
        Me.txtcrAmt.TabStop = False
        Me.txtcrAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.CadetBlue
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label7.Location = New System.Drawing.Point(547, 615)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 27)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Debit :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDramt
        '
        Me.txtDramt.BackColor = System.Drawing.Color.GhostWhite
        Me.txtDramt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDramt.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtDramt.ForeColor = System.Drawing.Color.Red
        Me.txtDramt.Location = New System.Drawing.Point(629, 615)
        Me.txtDramt.Name = "txtDramt"
        Me.txtDramt.ReadOnly = True
        Me.txtDramt.Size = New System.Drawing.Size(123, 27)
        Me.txtDramt.TabIndex = 12
        Me.txtDramt.TabStop = False
        Me.txtDramt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'MsktoDate
        '
        Me.MsktoDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MsktoDate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.MsktoDate.Location = New System.Drawing.Point(849, 140)
        Me.MsktoDate.Mask = "00-00-0000"
        Me.MsktoDate.Name = "MsktoDate"
        Me.MsktoDate.Size = New System.Drawing.Size(100, 27)
        Me.MsktoDate.TabIndex = 3
        '
        'mskFromDate
        '
        Me.mskFromDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskFromDate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.mskFromDate.Location = New System.Drawing.Point(641, 140)
        Me.mskFromDate.Mask = "00-00-0000"
        Me.mskFromDate.Name = "mskFromDate"
        Me.mskFromDate.Size = New System.Drawing.Size(100, 27)
        Me.mskFromDate.TabIndex = 2
        '
        'cbAccountName
        '
        Me.cbAccountName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbAccountName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbAccountName.Font = New System.Drawing.Font("Times New Roman", 11.0!)
        Me.cbAccountName.FormattingEnabled = True
        Me.cbAccountName.Location = New System.Drawing.Point(172, 140)
        Me.cbAccountName.Name = "cbAccountName"
        Me.cbAccountName.Size = New System.Drawing.Size(363, 28)
        Me.cbAccountName.TabIndex = 1
        '
        'dg1
        '
        Me.dg1.AllowUserToAddRows = False
        Me.dg1.AllowUserToDeleteRows = False
        Me.dg1.AllowUserToResizeRows = False
        Me.dg1.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dg1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.RosyBrown
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dg1.ColumnHeadersHeight = 28
        Me.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.CadetBlue
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg1.DefaultCellStyle = DataGridViewCellStyle8
        Me.dg1.EnableHeadersVisualStyles = False
        Me.dg1.GridColor = System.Drawing.Color.Gray
        Me.dg1.Location = New System.Drawing.Point(12, 166)
        Me.dg1.MultiSelect = False
        Me.dg1.Name = "dg1"
        Me.dg1.ReadOnly = True
        Me.dg1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg1.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dg1.RowHeadersVisible = False
        Me.dg1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dg1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dg1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg1.Size = New System.Drawing.Size(1170, 450)
        Me.dg1.TabIndex = 91213
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(467, 24)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox4.TabIndex = 91214
        Me.PictureBox4.TabStop = False
        '
        'btnClose
        '
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(1154, -1)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(40, 40)
        Me.btnClose.TabIndex = 91215
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'dtp1
        '
        Me.dtp1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.dtp1.Location = New System.Drawing.Point(647, 140)
        Me.dtp1.Name = "dtp1"
        Me.dtp1.Size = New System.Drawing.Size(109, 27)
        Me.dtp1.TabIndex = 91217
        '
        'dtp2
        '
        Me.dtp2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.dtp2.Location = New System.Drawing.Point(855, 140)
        Me.dtp2.Name = "dtp2"
        Me.dtp2.Size = New System.Drawing.Size(109, 27)
        Me.dtp2.TabIndex = 91216
        '
        'Ledger
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1194, 653)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.dg1)
        Me.Controls.Add(Me.cbAccountName)
        Me.Controls.Add(Me.MsktoDate)
        Me.Controls.Add(Me.mskFromDate)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtBalAmt)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtcrAmt)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtDramt)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtOpBal)
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.btnShow)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label42)
        Me.Controls.Add(Me.dtp1)
        Me.Controls.Add(Me.dtp2)
        Me.Name = "Ledger"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Ledger"
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnShow As System.Windows.Forms.Button
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtOpBal As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtBalAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtcrAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDramt As System.Windows.Forms.TextBox
    Friend WithEvents MsktoDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mskFromDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cbAccountName As System.Windows.Forms.ComboBox
    Friend WithEvents dg1 As System.Windows.Forms.DataGridView
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents dtp1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp2 As System.Windows.Forms.DateTimePicker
End Class
