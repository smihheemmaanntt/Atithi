<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tax_Setting
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tax_Setting))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtHeading = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbPostAccount = New System.Windows.Forms.ComboBox()
        Me.cbTaxType = New System.Windows.Forms.ComboBox()
        Me.txtDisPer = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPrefix = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbDefaultPrice = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtInvoiceStart = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.cbApplyOn = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dg1 = New System.Windows.Forms.DataGridView()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.txtid = New System.Windows.Forms.TextBox()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtHeading
        '
        Me.txtHeading.BackColor = System.Drawing.Color.GhostWhite
        Me.txtHeading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHeading.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtHeading.ForeColor = System.Drawing.Color.Black
        Me.txtHeading.Location = New System.Drawing.Point(12, 87)
        Me.txtHeading.Name = "txtHeading"
        Me.txtHeading.Size = New System.Drawing.Size(295, 27)
        Me.txtHeading.TabIndex = 0
        Me.txtHeading.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(14, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 21)
        Me.Label5.TabIndex = 91263
        Me.Label5.Text = "Tax Heading"
        '
        'cbPostAccount
        '
        Me.cbPostAccount.BackColor = System.Drawing.Color.GhostWhite
        Me.cbPostAccount.DropDownHeight = 100
        Me.cbPostAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPostAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbPostAccount.Font = New System.Drawing.Font("Times New Roman", 11.0!)
        Me.cbPostAccount.ForeColor = System.Drawing.Color.Navy
        Me.cbPostAccount.FormattingEnabled = True
        Me.cbPostAccount.IntegralHeight = False
        Me.cbPostAccount.Location = New System.Drawing.Point(308, 87)
        Me.cbPostAccount.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cbPostAccount.Name = "cbPostAccount"
        Me.cbPostAccount.Size = New System.Drawing.Size(307, 28)
        Me.cbPostAccount.TabIndex = 1
        '
        'cbTaxType
        '
        Me.cbTaxType.BackColor = System.Drawing.Color.GhostWhite
        Me.cbTaxType.DropDownHeight = 100
        Me.cbTaxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTaxType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbTaxType.Font = New System.Drawing.Font("Times New Roman", 11.0!)
        Me.cbTaxType.ForeColor = System.Drawing.Color.Navy
        Me.cbTaxType.FormattingEnabled = True
        Me.cbTaxType.IntegralHeight = False
        Me.cbTaxType.Items.AddRange(New Object() {"Tax Exclusive", "Tax Inclusive", "Tax Mannual", "Tax in Charges", "Tax Paid", "Composition"})
        Me.cbTaxType.Location = New System.Drawing.Point(615, 87)
        Me.cbTaxType.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cbTaxType.Name = "cbTaxType"
        Me.cbTaxType.Size = New System.Drawing.Size(203, 28)
        Me.cbTaxType.TabIndex = 2
        '
        'txtDisPer
        '
        Me.txtDisPer.BackColor = System.Drawing.Color.GhostWhite
        Me.txtDisPer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDisPer.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtDisPer.ForeColor = System.Drawing.Color.Black
        Me.txtDisPer.Location = New System.Drawing.Point(311, 150)
        Me.txtDisPer.Name = "txtDisPer"
        Me.txtDisPer.Size = New System.Drawing.Size(55, 27)
        Me.txtDisPer.TabIndex = 5
        Me.txtDisPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(310, 126)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 21)
        Me.Label1.TabIndex = 91294
        Me.Label1.Text = "Disc%"
        '
        'txtPrefix
        '
        Me.txtPrefix.BackColor = System.Drawing.Color.GhostWhite
        Me.txtPrefix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrefix.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtPrefix.ForeColor = System.Drawing.Color.Black
        Me.txtPrefix.Location = New System.Drawing.Point(365, 150)
        Me.txtPrefix.Name = "txtPrefix"
        Me.txtPrefix.Size = New System.Drawing.Size(110, 27)
        Me.txtPrefix.TabIndex = 6
        Me.txtPrefix.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(364, 126)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 21)
        Me.Label2.TabIndex = 91296
        Me.Label2.Text = "Invoice Prefix"
        '
        'cbDefaultPrice
        '
        Me.cbDefaultPrice.BackColor = System.Drawing.Color.GhostWhite
        Me.cbDefaultPrice.DropDownHeight = 100
        Me.cbDefaultPrice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDefaultPrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbDefaultPrice.Font = New System.Drawing.Font("Times New Roman", 11.0!)
        Me.cbDefaultPrice.ForeColor = System.Drawing.Color.Navy
        Me.cbDefaultPrice.FormattingEnabled = True
        Me.cbDefaultPrice.IntegralHeight = False
        Me.cbDefaultPrice.Items.AddRange(New Object() {"MRP", "Purchase", "Sale"})
        Me.cbDefaultPrice.Location = New System.Drawing.Point(159, 150)
        Me.cbDefaultPrice.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cbDefaultPrice.Name = "cbDefaultPrice"
        Me.cbDefaultPrice.Size = New System.Drawing.Size(152, 28)
        Me.cbDefaultPrice.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(168, 126)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 21)
        Me.Label3.TabIndex = 91298
        Me.Label3.Text = "Default Price"
        '
        'txtInvoiceStart
        '
        Me.txtInvoiceStart.BackColor = System.Drawing.Color.GhostWhite
        Me.txtInvoiceStart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvoiceStart.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtInvoiceStart.ForeColor = System.Drawing.Color.Black
        Me.txtInvoiceStart.Location = New System.Drawing.Point(474, 150)
        Me.txtInvoiceStart.Name = "txtInvoiceStart"
        Me.txtInvoiceStart.Size = New System.Drawing.Size(141, 27)
        Me.txtInvoiceStart.TabIndex = 7
        Me.txtInvoiceStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(475, 126)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(140, 21)
        Me.Label4.TabIndex = 91300
        Me.Label4.Text = "Start Invoice No."
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.Coral
        Me.BtnSave.FlatAppearance.BorderSize = 0
        Me.BtnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.BtnSave.ForeColor = System.Drawing.Color.GhostWhite
        Me.BtnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSave.Location = New System.Drawing.Point(712, 149)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(106, 28)
        Me.BtnSave.TabIndex = 8
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'BtnDelete
        '
        Me.BtnDelete.BackColor = System.Drawing.Color.Firebrick
        Me.BtnDelete.Enabled = False
        Me.BtnDelete.FlatAppearance.BorderSize = 0
        Me.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDelete.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.BtnDelete.ForeColor = System.Drawing.Color.GhostWhite
        Me.BtnDelete.Image = CType(resources.GetObject("BtnDelete.Image"), System.Drawing.Image)
        Me.BtnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnDelete.Location = New System.Drawing.Point(615, 149)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(98, 28)
        Me.BtnDelete.TabIndex = 10
        Me.BtnDelete.Text = "&Delete"
        Me.BtnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnDelete.UseVisualStyleBackColor = False
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Bodoni Bk BT", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Label41.ForeColor = System.Drawing.Color.Black
        Me.Label41.Location = New System.Drawing.Point(302, 9)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(187, 32)
        Me.Label41.TabIndex = 91332
        Me.Label41.Text = "TAX SETTING"
        '
        'cbApplyOn
        '
        Me.cbApplyOn.BackColor = System.Drawing.Color.GhostWhite
        Me.cbApplyOn.DropDownHeight = 100
        Me.cbApplyOn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbApplyOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbApplyOn.Font = New System.Drawing.Font("Times New Roman", 11.0!)
        Me.cbApplyOn.ForeColor = System.Drawing.Color.Navy
        Me.cbApplyOn.FormattingEnabled = True
        Me.cbApplyOn.IntegralHeight = False
        Me.cbApplyOn.Items.AddRange(New Object() {"Purchase", "Sale", "Debit Note", "Credit Note"})
        Me.cbApplyOn.Location = New System.Drawing.Point(12, 149)
        Me.cbApplyOn.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cbApplyOn.Name = "cbApplyOn"
        Me.cbApplyOn.Size = New System.Drawing.Size(149, 28)
        Me.cbApplyOn.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(10, 126)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 21)
        Me.Label6.TabIndex = 91334
        Me.Label6.Text = "Apply On"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(308, 63)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(163, 21)
        Me.Label7.TabIndex = 91335
        Me.Label7.Text = "To be Post Account"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(611, 63)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 21)
        Me.Label8.TabIndex = 91336
        Me.Label8.Text = "Tax Type"
        '
        'dg1
        '
        Me.dg1.AllowUserToAddRows = False
        Me.dg1.AllowUserToDeleteRows = False
        Me.dg1.AllowUserToResizeRows = False
        Me.dg1.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dg1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Crimson
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DarkTurquoise
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg1.DefaultCellStyle = DataGridViewCellStyle5
        Me.dg1.EnableHeadersVisualStyles = False
        Me.dg1.GridColor = System.Drawing.Color.Crimson
        Me.dg1.Location = New System.Drawing.Point(11, 176)
        Me.dg1.MultiSelect = False
        Me.dg1.Name = "dg1"
        Me.dg1.ReadOnly = True
        Me.dg1.RowHeadersVisible = False
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        Me.dg1.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dg1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dg1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg1.Size = New System.Drawing.Size(807, 271)
        Me.dg1.TabIndex = 9
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(159, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Navy
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.GhostWhite
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(784, -1)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(50, 39)
        Me.btnClose.TabIndex = 91338
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'txtid
        '
        Me.txtid.BackColor = System.Drawing.Color.AliceBlue
        Me.txtid.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtid.ForeColor = System.Drawing.Color.Teal
        Me.txtid.Location = New System.Drawing.Point(11, 12)
        Me.txtid.Name = "txtid"
        Me.txtid.Size = New System.Drawing.Size(71, 26)
        Me.txtid.TabIndex = 91339
        Me.txtid.Visible = False
        '
        'Tax_Setting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(159, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(834, 461)
        Me.Controls.Add(Me.txtid)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.dg1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cbApplyOn)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.txtInvoiceStart)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbDefaultPrice)
        Me.Controls.Add(Me.txtPrefix)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtDisPer)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbTaxType)
        Me.Controls.Add(Me.cbPostAccount)
        Me.Controls.Add(Me.txtHeading)
        Me.Controls.Add(Me.Label5)
        Me.Name = "Tax_Setting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tax Setting"
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtHeading As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbPostAccount As System.Windows.Forms.ComboBox
    Friend WithEvents cbTaxType As System.Windows.Forms.ComboBox
    Friend WithEvents txtDisPer As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPrefix As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbDefaultPrice As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceStart As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnDelete As System.Windows.Forms.Button
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents cbApplyOn As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dg1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents txtid As System.Windows.Forms.TextBox
End Class
