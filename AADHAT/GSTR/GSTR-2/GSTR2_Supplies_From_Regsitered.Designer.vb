<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GSTR2_Supplies_From_Regsitered
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
        Me.btnShow = New System.Windows.Forms.Button()
        Me.mskFromDate = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtTotITC = New System.Windows.Forms.TextBox()
        Me.txtTaxable = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTotIGST = New System.Windows.Forms.TextBox()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTotCess = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.MsktoDate = New System.Windows.Forms.MaskedTextBox()
        Me.txtTotCGST = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtGrandTotal = New System.Windows.Forms.TextBox()
        Me.txtTotSGST = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dg1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel1.SuspendLayout()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnShow
        '
        Me.btnShow.BackColor = System.Drawing.Color.Tomato
        Me.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShow.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShow.ForeColor = System.Drawing.Color.GhostWhite
        Me.btnShow.Location = New System.Drawing.Point(327, 19)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(76, 26)
        Me.btnShow.TabIndex = 40203
        Me.btnShow.Text = "&Show"
        Me.btnShow.UseVisualStyleBackColor = False
        '
        'mskFromDate
        '
        Me.mskFromDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskFromDate.Location = New System.Drawing.Point(74, 19)
        Me.mskFromDate.Mask = "00-00-0000"
        Me.mskFromDate.Name = "mskFromDate"
        Me.mskFromDate.Size = New System.Drawing.Size(100, 26)
        Me.mskFromDate.TabIndex = 40201
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label2.Location = New System.Drawing.Point(474, 509)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 20)
        Me.Label2.TabIndex = 40074
        Me.Label2.Text = "IGST"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label26.Location = New System.Drawing.Point(363, 509)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(64, 20)
        Me.Label26.TabIndex = 40072
        Me.Label26.Text = "Taxable"
        '
        'txtTotITC
        '
        Me.txtTotITC.BackColor = System.Drawing.Color.DarkTurquoise
        Me.txtTotITC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotITC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotITC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotITC.ForeColor = System.Drawing.Color.GhostWhite
        Me.txtTotITC.Location = New System.Drawing.Point(860, 531)
        Me.txtTotITC.Name = "txtTotITC"
        Me.txtTotITC.ReadOnly = True
        Me.txtTotITC.Size = New System.Drawing.Size(97, 26)
        Me.txtTotITC.TabIndex = 40187
        Me.txtTotITC.TabStop = False
        Me.txtTotITC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTaxable
        '
        Me.txtTaxable.BackColor = System.Drawing.Color.DarkTurquoise
        Me.txtTaxable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTaxable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTaxable.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTaxable.ForeColor = System.Drawing.Color.GhostWhite
        Me.txtTaxable.Location = New System.Drawing.Point(347, 531)
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
        Me.Label7.Location = New System.Drawing.Point(858, 509)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 20)
        Me.Label7.TabIndex = 40186
        Me.Label7.Text = "ITC Available"
        '
        'txtTotIGST
        '
        Me.txtTotIGST.BackColor = System.Drawing.Color.DarkTurquoise
        Me.txtTotIGST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotIGST.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotIGST.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotIGST.ForeColor = System.Drawing.Color.GhostWhite
        Me.txtTotIGST.Location = New System.Drawing.Point(448, 531)
        Me.txtTotIGST.Name = "txtTotIGST"
        Me.txtTotIGST.ReadOnly = True
        Me.txtTotIGST.Size = New System.Drawing.Size(97, 26)
        Me.txtTotIGST.TabIndex = 40075
        Me.txtTotIGST.TabStop = False
        Me.txtTotIGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BtnPrint
        '
        Me.BtnPrint.BackColor = System.Drawing.Color.Blue
        Me.BtnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrint.ForeColor = System.Drawing.Color.GhostWhite
        Me.BtnPrint.Location = New System.Drawing.Point(409, 19)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(76, 25)
        Me.BtnPrint.TabIndex = 40204
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
        Me.Panel1.TabIndex = 40200
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.DarkTurquoise
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Red
        Me.btnClose.Location = New System.Drawing.Point(924, 3)
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
        Me.Label1.Location = New System.Drawing.Point(182, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(560, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "GSTR2 : Supplies From Regsitered Suppliers"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label3.Location = New System.Drawing.Point(577, 509)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 20)
        Me.Label3.TabIndex = 40076
        Me.Label3.Text = "CGST"
        '
        'txtTotCess
        '
        Me.txtTotCess.BackColor = System.Drawing.Color.DarkTurquoise
        Me.txtTotCess.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotCess.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotCess.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotCess.ForeColor = System.Drawing.Color.GhostWhite
        Me.txtTotCess.Location = New System.Drawing.Point(757, 531)
        Me.txtTotCess.Name = "txtTotCess"
        Me.txtTotCess.ReadOnly = True
        Me.txtTotCess.Size = New System.Drawing.Size(97, 26)
        Me.txtTotCess.TabIndex = 40083
        Me.txtTotCess.TabStop = False
        Me.txtTotCess.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label6.Location = New System.Drawing.Point(780, 510)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 20)
        Me.Label6.TabIndex = 40082
        Me.Label6.Text = "Cess"
        '
        'MsktoDate
        '
        Me.MsktoDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MsktoDate.Location = New System.Drawing.Point(221, 19)
        Me.MsktoDate.Mask = "00-00-0000"
        Me.MsktoDate.Name = "MsktoDate"
        Me.MsktoDate.Size = New System.Drawing.Size(100, 26)
        Me.MsktoDate.TabIndex = 40202
        '
        'txtTotCGST
        '
        Me.txtTotCGST.BackColor = System.Drawing.Color.DarkTurquoise
        Me.txtTotCGST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotCGST.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotCGST.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotCGST.ForeColor = System.Drawing.Color.GhostWhite
        Me.txtTotCGST.Location = New System.Drawing.Point(551, 531)
        Me.txtTotCGST.Name = "txtTotCGST"
        Me.txtTotCGST.ReadOnly = True
        Me.txtTotCGST.Size = New System.Drawing.Size(97, 26)
        Me.txtTotCGST.TabIndex = 40077
        Me.txtTotCGST.TabStop = False
        Me.txtTotCGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label9.Location = New System.Drawing.Point(180, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(35, 20)
        Me.Label9.TabIndex = 40207
        Me.Label9.Text = "To :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label4.Location = New System.Drawing.Point(675, 509)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 20)
        Me.Label4.TabIndex = 40078
        Me.Label4.Text = "SGST"
        '
        'TxtGrandTotal
        '
        Me.TxtGrandTotal.BackColor = System.Drawing.Color.DarkTurquoise
        Me.TxtGrandTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtGrandTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtGrandTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtGrandTotal.ForeColor = System.Drawing.Color.GhostWhite
        Me.TxtGrandTotal.Location = New System.Drawing.Point(244, 531)
        Me.TxtGrandTotal.Name = "TxtGrandTotal"
        Me.TxtGrandTotal.ReadOnly = True
        Me.TxtGrandTotal.Size = New System.Drawing.Size(97, 26)
        Me.TxtGrandTotal.TabIndex = 40081
        Me.TxtGrandTotal.TabStop = False
        Me.TxtGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotSGST
        '
        Me.txtTotSGST.BackColor = System.Drawing.Color.DarkTurquoise
        Me.txtTotSGST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotSGST.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotSGST.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotSGST.ForeColor = System.Drawing.Color.GhostWhite
        Me.txtTotSGST.Location = New System.Drawing.Point(654, 531)
        Me.txtTotSGST.Name = "txtTotSGST"
        Me.txtTotSGST.ReadOnly = True
        Me.txtTotSGST.Size = New System.Drawing.Size(97, 26)
        Me.txtTotSGST.TabIndex = 40079
        Me.txtTotSGST.TabStop = False
        Me.txtTotSGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label5.Location = New System.Drawing.Point(271, 508)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 20)
        Me.Label5.TabIndex = 40080
        Me.Label5.Text = "Total"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label8.Location = New System.Drawing.Point(6, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 20)
        Me.Label8.TabIndex = 40206
        Me.Label8.Text = "From :"
        '
        'dg1
        '
        Me.dg1.AllowUserToAddRows = False
        Me.dg1.AllowUserToDeleteRows = False
        Me.dg1.AllowUserToResizeRows = False
        Me.dg1.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dg1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.DarkTurquoise
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.RoyalBlue
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dg1.ColumnHeadersHeight = 28
        Me.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Navy
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg1.DefaultCellStyle = DataGridViewCellStyle8
        Me.dg1.GridColor = System.Drawing.Color.Gray
        Me.dg1.Location = New System.Drawing.Point(6, 50)
        Me.dg1.Name = "dg1"
        Me.dg1.ReadOnly = True
        Me.dg1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dg1.RowHeadersVisible = False
        Me.dg1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dg1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dg1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg1.Size = New System.Drawing.Size(951, 455)
        Me.dg1.TabIndex = 40205
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.DarkTurquoise
        Me.GroupBox1.Controls.Add(Me.mskFromDate)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.btnShow)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.MsktoDate)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.BtnPrint)
        Me.GroupBox1.Controls.Add(Me.txtTotITC)
        Me.GroupBox1.Controls.Add(Me.txtTaxable)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtTotIGST)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.dg1)
        Me.GroupBox1.Controls.Add(Me.txtTotCess)
        Me.GroupBox1.Controls.Add(Me.txtTotCGST)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TxtGrandTotal)
        Me.GroupBox1.Controls.Add(Me.txtTotSGST)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 52)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(963, 575)
        Me.GroupBox1.TabIndex = 40208
        Me.GroupBox1.TabStop = False
        '
        'GSTR2_Supplies_From_Regsitered
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(987, 630)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "GSTR2_Supplies_From_Regsitered"
        Me.Text = "GSTR2_Supplies_From_Regsitered"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnShow As System.Windows.Forms.Button
    Friend WithEvents mskFromDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtTotITC As System.Windows.Forms.TextBox
    Friend WithEvents txtTaxable As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTotIGST As System.Windows.Forms.TextBox
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTotCess As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents MsktoDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtTotCGST As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtGrandTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtTotSGST As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dg1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
