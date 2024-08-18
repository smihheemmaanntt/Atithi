<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GSTR2_Supplies_From_Unregsiter
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtTotRoundOff = New System.Windows.Forms.TextBox()
        Me.txtTaxable = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTotBasic = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTotCharges = New System.Windows.Forms.TextBox()
        Me.txtTotDisc = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtGrandTotal = New System.Windows.Forms.TextBox()
        Me.txtTotTax = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dg1 = New System.Windows.Forms.DataGridView()
        Me.btnShow = New System.Windows.Forms.Button()
        Me.MsktoDate = New System.Windows.Forms.MaskedTextBox()
        Me.mskFromDate = New System.Windows.Forms.MaskedTextBox()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label8.Location = New System.Drawing.Point(18, 102)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 20)
        Me.Label8.TabIndex = 40197
        Me.Label8.Text = "From :"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.DarkTurquoise
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.txtTotRoundOff)
        Me.GroupBox1.Controls.Add(Me.txtTaxable)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtTotBasic)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtTotCharges)
        Me.GroupBox1.Controls.Add(Me.txtTotDisc)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TxtGrandTotal)
        Me.GroupBox1.Controls.Add(Me.txtTotTax)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 58)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(963, 566)
        Me.GroupBox1.TabIndex = 40199
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label2.Location = New System.Drawing.Point(268, 510)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 20)
        Me.Label2.TabIndex = 40074
        Me.Label2.Text = "Basic"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label26.Location = New System.Drawing.Point(464, 510)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(64, 20)
        Me.Label26.TabIndex = 40072
        Me.Label26.Text = "Taxable"
        '
        'txtTotRoundOff
        '
        Me.txtTotRoundOff.BackColor = System.Drawing.Color.DarkTurquoise
        Me.txtTotRoundOff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotRoundOff.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotRoundOff.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotRoundOff.ForeColor = System.Drawing.Color.GhostWhite
        Me.txtTotRoundOff.Location = New System.Drawing.Point(757, 532)
        Me.txtTotRoundOff.Name = "txtTotRoundOff"
        Me.txtTotRoundOff.ReadOnly = True
        Me.txtTotRoundOff.Size = New System.Drawing.Size(97, 26)
        Me.txtTotRoundOff.TabIndex = 40187
        Me.txtTotRoundOff.TabStop = False
        Me.txtTotRoundOff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTaxable
        '
        Me.txtTaxable.BackColor = System.Drawing.Color.DarkTurquoise
        Me.txtTaxable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTaxable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTaxable.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTaxable.ForeColor = System.Drawing.Color.GhostWhite
        Me.txtTaxable.Location = New System.Drawing.Point(448, 532)
        Me.txtTaxable.Name = "txtTaxable"
        Me.txtTaxable.ReadOnly = True
        Me.txtTaxable.Size = New System.Drawing.Size(97, 26)
        Me.txtTaxable.TabIndex = 40073
        Me.txtTaxable.TabStop = False
        Me.txtTaxable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label7.Location = New System.Drawing.Point(761, 509)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 20)
        Me.Label7.TabIndex = 40186
        Me.Label7.Text = "Round Off"
        '
        'txtTotBasic
        '
        Me.txtTotBasic.BackColor = System.Drawing.Color.DarkTurquoise
        Me.txtTotBasic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotBasic.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotBasic.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotBasic.ForeColor = System.Drawing.Color.GhostWhite
        Me.txtTotBasic.Location = New System.Drawing.Point(242, 532)
        Me.txtTotBasic.Name = "txtTotBasic"
        Me.txtTotBasic.ReadOnly = True
        Me.txtTotBasic.Size = New System.Drawing.Size(97, 26)
        Me.txtTotBasic.TabIndex = 40075
        Me.txtTotBasic.TabStop = False
        Me.txtTotBasic.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label3.Location = New System.Drawing.Point(372, 510)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 20)
        Me.Label3.TabIndex = 40076
        Me.Label3.Text = "Disc. "
        '
        'txtTotCharges
        '
        Me.txtTotCharges.BackColor = System.Drawing.Color.DarkTurquoise
        Me.txtTotCharges.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotCharges.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotCharges.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotCharges.ForeColor = System.Drawing.Color.GhostWhite
        Me.txtTotCharges.Location = New System.Drawing.Point(654, 532)
        Me.txtTotCharges.Name = "txtTotCharges"
        Me.txtTotCharges.ReadOnly = True
        Me.txtTotCharges.Size = New System.Drawing.Size(97, 26)
        Me.txtTotCharges.TabIndex = 40083
        Me.txtTotCharges.TabStop = False
        Me.txtTotCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotDisc
        '
        Me.txtTotDisc.BackColor = System.Drawing.Color.DarkTurquoise
        Me.txtTotDisc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotDisc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotDisc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotDisc.ForeColor = System.Drawing.Color.GhostWhite
        Me.txtTotDisc.Location = New System.Drawing.Point(345, 532)
        Me.txtTotDisc.Name = "txtTotDisc"
        Me.txtTotDisc.ReadOnly = True
        Me.txtTotDisc.Size = New System.Drawing.Size(97, 26)
        Me.txtTotDisc.TabIndex = 40077
        Me.txtTotDisc.TabStop = False
        Me.txtTotDisc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label6.Location = New System.Drawing.Point(668, 510)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 20)
        Me.Label6.TabIndex = 40082
        Me.Label6.Text = "Charges"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label4.Location = New System.Drawing.Point(584, 510)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 20)
        Me.Label4.TabIndex = 40078
        Me.Label4.Text = "Tax"
        '
        'TxtGrandTotal
        '
        Me.TxtGrandTotal.BackColor = System.Drawing.Color.DarkTurquoise
        Me.TxtGrandTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtGrandTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtGrandTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtGrandTotal.ForeColor = System.Drawing.Color.GhostWhite
        Me.TxtGrandTotal.Location = New System.Drawing.Point(860, 532)
        Me.TxtGrandTotal.Name = "TxtGrandTotal"
        Me.TxtGrandTotal.ReadOnly = True
        Me.TxtGrandTotal.Size = New System.Drawing.Size(97, 26)
        Me.TxtGrandTotal.TabIndex = 40081
        Me.TxtGrandTotal.TabStop = False
        Me.TxtGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotTax
        '
        Me.txtTotTax.BackColor = System.Drawing.Color.DarkTurquoise
        Me.txtTotTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotTax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotTax.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotTax.ForeColor = System.Drawing.Color.GhostWhite
        Me.txtTotTax.Location = New System.Drawing.Point(551, 532)
        Me.txtTotTax.Name = "txtTotTax"
        Me.txtTotTax.ReadOnly = True
        Me.txtTotTax.Size = New System.Drawing.Size(97, 26)
        Me.txtTotTax.TabIndex = 40079
        Me.txtTotTax.TabStop = False
        Me.txtTotTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label5.Location = New System.Drawing.Point(887, 509)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 20)
        Me.Label5.TabIndex = 40080
        Me.Label5.Text = "Total"
        '
        'dg1
        '
        Me.dg1.AllowUserToAddRows = False
        Me.dg1.AllowUserToDeleteRows = False
        Me.dg1.AllowUserToResizeRows = False
        Me.dg1.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dg1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkTurquoise
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.RoyalBlue
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dg1.ColumnHeadersHeight = 28
        Me.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Navy
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg1.DefaultCellStyle = DataGridViewCellStyle2
        Me.dg1.GridColor = System.Drawing.Color.Gray
        Me.dg1.Location = New System.Drawing.Point(18, 131)
        Me.dg1.Name = "dg1"
        Me.dg1.ReadOnly = True
        Me.dg1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dg1.RowHeadersVisible = False
        Me.dg1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dg1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dg1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg1.Size = New System.Drawing.Size(951, 435)
        Me.dg1.TabIndex = 40196
        '
        'btnShow
        '
        Me.btnShow.BackColor = System.Drawing.Color.Tomato
        Me.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShow.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShow.ForeColor = System.Drawing.Color.GhostWhite
        Me.btnShow.Location = New System.Drawing.Point(339, 97)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(76, 26)
        Me.btnShow.TabIndex = 40194
        Me.btnShow.Text = "&Show"
        Me.btnShow.UseVisualStyleBackColor = False
        '
        'MsktoDate
        '
        Me.MsktoDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MsktoDate.Location = New System.Drawing.Point(233, 97)
        Me.MsktoDate.Mask = "00-00-0000"
        Me.MsktoDate.Name = "MsktoDate"
        Me.MsktoDate.Size = New System.Drawing.Size(100, 26)
        Me.MsktoDate.TabIndex = 40193
        '
        'mskFromDate
        '
        Me.mskFromDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskFromDate.Location = New System.Drawing.Point(78, 97)
        Me.mskFromDate.Mask = "00-00-0000"
        Me.mskFromDate.Name = "mskFromDate"
        Me.mskFromDate.Size = New System.Drawing.Size(100, 26)
        Me.mskFromDate.TabIndex = 40192
        '
        'BtnPrint
        '
        Me.BtnPrint.BackColor = System.Drawing.Color.Blue
        Me.BtnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrint.ForeColor = System.Drawing.Color.GhostWhite
        Me.BtnPrint.Location = New System.Drawing.Point(421, 97)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(76, 25)
        Me.BtnPrint.TabIndex = 40195
        Me.BtnPrint.Text = "&Print"
        Me.BtnPrint.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkTurquoise
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.ForeColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(987, 47)
        Me.Panel1.TabIndex = 40191
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.DarkTurquoise
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Red
        Me.btnClose.Location = New System.Drawing.Point(914, 3)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(51, 43)
        Me.btnClose.TabIndex = 40055
        Me.btnClose.TabStop = False
        Me.btnClose.Text = "X"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!)
        Me.Label1.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label1.Location = New System.Drawing.Point(209, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(554, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "GSTR2 : Supplies From Unregsiter Suppliers"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label9.Location = New System.Drawing.Point(184, 100)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(35, 20)
        Me.Label9.TabIndex = 40198
        Me.Label9.Text = "To :"
        '
        'GSTR2_Supplies_From_Unregsiter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(987, 630)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.dg1)
        Me.Controls.Add(Me.btnShow)
        Me.Controls.Add(Me.MsktoDate)
        Me.Controls.Add(Me.mskFromDate)
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "GSTR2_Supplies_From_Unregsiter"
        Me.Text = "GSTR2_Supplies_From_Unregsiter"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtTotRoundOff As System.Windows.Forms.TextBox
    Friend WithEvents txtTaxable As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTotBasic As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTotCharges As System.Windows.Forms.TextBox
    Friend WithEvents txtTotDisc As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtGrandTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtTotTax As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dg1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnShow As System.Windows.Forms.Button
    Friend WithEvents MsktoDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mskFromDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
