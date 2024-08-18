<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class JournalEntry
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
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtTotalCredit = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtTotalDebit = New System.Windows.Forms.TextBox()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtRemark = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CbAccountName = New System.Windows.Forms.ComboBox()
        Me.CbDrCr = New System.Windows.Forms.ComboBox()
        Me.mskEntryDate = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtVoucherNo = New System.Windows.Forms.TextBox()
        Me.txtid = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dg1 = New System.Windows.Forms.DataGridView()
        Me.Panel1.SuspendLayout()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(733, 538)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 20)
        Me.Label8.TabIndex = 40083
        Me.Label8.Text = "Total Credit"
        '
        'TxtTotalCredit
        '
        Me.TxtTotalCredit.BackColor = System.Drawing.Color.AliceBlue
        Me.TxtTotalCredit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTotalCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalCredit.ForeColor = System.Drawing.Color.Red
        Me.TxtTotalCredit.Location = New System.Drawing.Point(852, 535)
        Me.TxtTotalCredit.Name = "TxtTotalCredit"
        Me.TxtTotalCredit.Size = New System.Drawing.Size(115, 26)
        Me.TxtTotalCredit.TabIndex = 40082
        Me.TxtTotalCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(499, 539)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 20)
        Me.Label7.TabIndex = 40081
        Me.Label7.Text = "Total Debit"
        '
        'TxtTotalDebit
        '
        Me.TxtTotalDebit.BackColor = System.Drawing.Color.AliceBlue
        Me.TxtTotalDebit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTotalDebit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalDebit.ForeColor = System.Drawing.Color.Red
        Me.TxtTotalDebit.Location = New System.Drawing.Point(599, 536)
        Me.TxtTotalDebit.Name = "TxtTotalDebit"
        Me.TxtTotalDebit.Size = New System.Drawing.Size(115, 26)
        Me.TxtTotalDebit.TabIndex = 40080
        Me.TxtTotalDebit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.Black
        Me.BtnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.ForeColor = System.Drawing.Color.GhostWhite
        Me.BtnSave.Location = New System.Drawing.Point(628, 70)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 50)
        Me.BtnSave.TabIndex = 7
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'btnPrint
        '
        Me.btnPrint.BackColor = System.Drawing.Color.Black
        Me.btnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.ForeColor = System.Drawing.Color.GhostWhite
        Me.btnPrint.Location = New System.Drawing.Point(787, 70)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 49)
        Me.btnPrint.TabIndex = 9
        Me.btnPrint.Text = "&Print"
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'BtnDelete
        '
        Me.BtnDelete.BackColor = System.Drawing.Color.Black
        Me.BtnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDelete.ForeColor = System.Drawing.Color.GhostWhite
        Me.BtnDelete.Location = New System.Drawing.Point(706, 70)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(75, 49)
        Me.BtnDelete.TabIndex = 8
        Me.BtnDelete.Text = "&Delete"
        Me.BtnDelete.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(758, 151)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 20)
        Me.Label5.TabIndex = 40075
        Me.Label5.Text = "Narration"
        '
        'txtRemark
        '
        Me.txtRemark.BackColor = System.Drawing.Color.AliceBlue
        Me.txtRemark.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemark.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemark.ForeColor = System.Drawing.Color.Black
        Me.txtRemark.Location = New System.Drawing.Point(628, 179)
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(340, 26)
        Me.txtRemark.TabIndex = 6
        Me.txtRemark.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(515, 149)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 20)
        Me.Label6.TabIndex = 40073
        Me.Label6.Text = "Amount"
        '
        'txtAmount
        '
        Me.txtAmount.BackColor = System.Drawing.Color.AliceBlue
        Me.txtAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmount.ForeColor = System.Drawing.Color.Black
        Me.txtAmount.Location = New System.Drawing.Point(488, 179)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(141, 26)
        Me.txtAmount.TabIndex = 5
        Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(220, 151)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(118, 20)
        Me.Label4.TabIndex = 40071
        Me.Label4.Text = " Account Name"
        '
        'CbAccountName
        '
        Me.CbAccountName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CbAccountName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CbAccountName.BackColor = System.Drawing.Color.AliceBlue
        Me.CbAccountName.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.CbAccountName.FormattingEnabled = True
        Me.CbAccountName.Location = New System.Drawing.Point(108, 179)
        Me.CbAccountName.Name = "CbAccountName"
        Me.CbAccountName.Size = New System.Drawing.Size(381, 26)
        Me.CbAccountName.TabIndex = 4
        '
        'CbDrCr
        '
        Me.CbDrCr.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CbDrCr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CbDrCr.BackColor = System.Drawing.Color.AliceBlue
        Me.CbDrCr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbDrCr.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbDrCr.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.CbDrCr.FormattingEnabled = True
        Me.CbDrCr.Items.AddRange(New Object() {"D", "C"})
        Me.CbDrCr.Location = New System.Drawing.Point(20, 179)
        Me.CbDrCr.Name = "CbDrCr"
        Me.CbDrCr.Size = New System.Drawing.Size(88, 26)
        Me.CbDrCr.TabIndex = 3
        '
        'mskEntryDate
        '
        Me.mskEntryDate.BackColor = System.Drawing.Color.AliceBlue
        Me.mskEntryDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskEntryDate.Location = New System.Drawing.Point(181, 94)
        Me.mskEntryDate.Mask = "00-00-0000"
        Me.mskEntryDate.Name = "mskEntryDate"
        Me.mskEntryDate.Size = New System.Drawing.Size(114, 26)
        Me.mskEntryDate.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(301, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 20)
        Me.Label2.TabIndex = 40067
        Me.Label2.Text = "Voucher No."
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(74, 97)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(85, 20)
        Me.Label25.TabIndex = 40066
        Me.Label25.Text = "Entry Date"
        '
        'txtVoucherNo
        '
        Me.txtVoucherNo.BackColor = System.Drawing.Color.AliceBlue
        Me.txtVoucherNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVoucherNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVoucherNo.ForeColor = System.Drawing.Color.Black
        Me.txtVoucherNo.Location = New System.Drawing.Point(401, 94)
        Me.txtVoucherNo.Name = "txtVoucherNo"
        Me.txtVoucherNo.Size = New System.Drawing.Size(115, 26)
        Me.txtVoucherNo.TabIndex = 2
        Me.txtVoucherNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtid
        '
        Me.txtid.BackColor = System.Drawing.Color.AliceBlue
        Me.txtid.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtid.ForeColor = System.Drawing.Color.Black
        Me.txtid.Location = New System.Drawing.Point(44, 12)
        Me.txtid.Name = "txtid"
        Me.txtid.Size = New System.Drawing.Size(71, 26)
        Me.txtid.TabIndex = 40054
        Me.txtid.TabStop = False
        Me.txtid.Visible = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.Black
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Red
        Me.btnClose.Location = New System.Drawing.Point(921, 2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(51, 43)
        Me.btnClose.TabIndex = 40053
        Me.btnClose.TabStop = False
        Me.btnClose.Text = "X"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!)
        Me.Label1.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label1.Location = New System.Drawing.Point(358, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(242, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "JOURNAL ENTRY"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(25, 156)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 20)
        Me.Label3.TabIndex = 40069
        Me.Label3.Text = "Dr. / Cr."
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Controls.Add(Me.txtid)
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.ForeColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(987, 47)
        Me.Panel1.TabIndex = 40063
        '
        'dg1
        '
        Me.dg1.AllowUserToAddRows = False
        Me.dg1.AllowUserToDeleteRows = False
        Me.dg1.AllowUserToResizeRows = False
        Me.dg1.BackgroundColor = System.Drawing.Color.AliceBlue
        Me.dg1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dg1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg1.DefaultCellStyle = DataGridViewCellStyle2
        Me.dg1.GridColor = System.Drawing.Color.Gray
        Me.dg1.Location = New System.Drawing.Point(20, 207)
        Me.dg1.Name = "dg1"
        Me.dg1.ReadOnly = True
        Me.dg1.RowHeadersVisible = False
        Me.dg1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dg1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg1.Size = New System.Drawing.Size(947, 323)
        Me.dg1.TabIndex = 40084
        '
        'JournalEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(987, 630)
        Me.Controls.Add(Me.dg1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TxtTotalCredit)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtTotalDebit)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtRemark)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CbAccountName)
        Me.Controls.Add(Me.CbDrCr)
        Me.Controls.Add(Me.mskEntryDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.txtVoucherNo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.Name = "JournalEntry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Journal"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtTotalCredit As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtTotalDebit As System.Windows.Forms.TextBox
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents BtnDelete As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtRemark As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CbAccountName As System.Windows.Forms.ComboBox
    Friend WithEvents CbDrCr As System.Windows.Forms.ComboBox
    Friend WithEvents mskEntryDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtVoucherNo As System.Windows.Forms.TextBox
    Friend WithEvents txtid As System.Windows.Forms.TextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dg1 As System.Windows.Forms.DataGridView
End Class
