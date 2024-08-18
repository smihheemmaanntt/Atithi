<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VAS
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
        Me.CbPer = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtSno = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dg1 = New System.Windows.Forms.DataGridView()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbTax = New System.Windows.Forms.ComboBox()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.txtHSNCode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCal = New System.Windows.Forms.TextBox()
        Me.lblgroup = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtVASName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CbPer
        '
        Me.CbPer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CbPer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CbPer.BackColor = System.Drawing.Color.GhostWhite
        Me.CbPer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbPer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbPer.Font = New System.Drawing.Font("Times New Roman", 7.0!)
        Me.CbPer.ForeColor = System.Drawing.Color.Black
        Me.CbPer.FormattingEnabled = True
        Me.CbPer.Items.AddRange(New Object() {"Per Day", "Net Amount", "Per Person Per Day", "Per Person"})
        Me.CbPer.Location = New System.Drawing.Point(500, 142)
        Me.CbPer.Name = "CbPer"
        Me.CbPer.Size = New System.Drawing.Size(189, 21)
        Me.CbPer.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label3.Location = New System.Drawing.Point(506, 121)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 17)
        Me.Label3.TabIndex = 40210
        Me.Label3.Text = "Per"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Tan
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(5, 459)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(849, 5)
        Me.Panel5.TabIndex = 10
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Tan
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(854, 27)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(5, 437)
        Me.Panel2.TabIndex = 9
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Tan
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 27)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(5, 437)
        Me.Panel3.TabIndex = 11
        '
        'txtSno
        '
        Me.txtSno.BackColor = System.Drawing.Color.GhostWhite
        Me.txtSno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSno.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtSno.ForeColor = System.Drawing.Color.Black
        Me.txtSno.Location = New System.Drawing.Point(43, 141)
        Me.txtSno.Name = "txtSno"
        Me.txtSno.Size = New System.Drawing.Size(75, 23)
        Me.txtSno.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.Label2.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label2.Location = New System.Drawing.Point(302, 121)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 19)
        Me.Label2.TabIndex = 40206
        Me.Label2.Text = "HSN Code"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dg1
        '
        Me.dg1.AllowUserToAddRows = False
        Me.dg1.AllowUserToDeleteRows = False
        Me.dg1.AllowUserToResizeRows = False
        Me.dg1.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dg1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.IndianRed
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkTurquoise
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg1.DefaultCellStyle = DataGridViewCellStyle2
        Me.dg1.EnableHeadersVisualStyles = False
        Me.dg1.GridColor = System.Drawing.Color.GhostWhite
        Me.dg1.Location = New System.Drawing.Point(43, 163)
        Me.dg1.Name = "dg1"
        Me.dg1.ReadOnly = True
        Me.dg1.RowHeadersVisible = False
        Me.dg1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dg1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg1.Size = New System.Drawing.Size(764, 193)
        Me.dg1.TabIndex = 40205
        Me.dg1.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label7.Location = New System.Drawing.Point(765, 123)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 17)
        Me.Label7.TabIndex = 40204
        Me.Label7.Text = "Tax %"
        '
        'cbTax
        '
        Me.cbTax.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbTax.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbTax.BackColor = System.Drawing.Color.GhostWhite
        Me.cbTax.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTax.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbTax.Font = New System.Drawing.Font("Times New Roman", 7.0!)
        Me.cbTax.ForeColor = System.Drawing.Color.Black
        Me.cbTax.FormattingEnabled = True
        Me.cbTax.Location = New System.Drawing.Point(689, 142)
        Me.cbTax.Name = "cbTax"
        Me.cbTax.Size = New System.Drawing.Size(118, 21)
        Me.cbTax.TabIndex = 5
        '
        'txtID
        '
        Me.txtID.BackColor = System.Drawing.Color.AliceBlue
        Me.txtID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtID.ForeColor = System.Drawing.Color.Black
        Me.txtID.Location = New System.Drawing.Point(150, 368)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(78, 26)
        Me.txtID.TabIndex = 8
        Me.txtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtID.Visible = False
        '
        'BtnDelete
        '
        Me.BtnDelete.BackColor = System.Drawing.Color.IndianRed
        Me.BtnDelete.FlatAppearance.BorderSize = 0
        Me.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDelete.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.BtnDelete.ForeColor = System.Drawing.Color.GhostWhite
        Me.BtnDelete.Location = New System.Drawing.Point(592, 379)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(100, 40)
        Me.BtnDelete.TabIndex = 7
        Me.BtnDelete.TabStop = False
        Me.BtnDelete.Text = "&Delete"
        Me.BtnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnDelete.UseVisualStyleBackColor = False
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.Chocolate
        Me.BtnSave.FlatAppearance.BorderSize = 0
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.BtnSave.ForeColor = System.Drawing.Color.GhostWhite
        Me.BtnSave.Location = New System.Drawing.Point(698, 379)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(109, 40)
        Me.BtnSave.TabIndex = 6
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'txtHSNCode
        '
        Me.txtHSNCode.BackColor = System.Drawing.Color.GhostWhite
        Me.txtHSNCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHSNCode.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtHSNCode.ForeColor = System.Drawing.Color.Black
        Me.txtHSNCode.Location = New System.Drawing.Point(306, 141)
        Me.txtHSNCode.Name = "txtHSNCode"
        Me.txtHSNCode.Size = New System.Drawing.Size(112, 23)
        Me.txtHSNCode.TabIndex = 2
        Me.txtHSNCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label1.Location = New System.Drawing.Point(450, 123)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 17)
        Me.Label1.TabIndex = 40201
        Me.Label1.Text = "Calc@"
        '
        'txtCal
        '
        Me.txtCal.BackColor = System.Drawing.Color.GhostWhite
        Me.txtCal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCal.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtCal.ForeColor = System.Drawing.Color.Black
        Me.txtCal.Location = New System.Drawing.Point(417, 141)
        Me.txtCal.Name = "txtCal"
        Me.txtCal.Size = New System.Drawing.Size(83, 23)
        Me.txtCal.TabIndex = 3
        Me.txtCal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblgroup
        '
        Me.lblgroup.AutoSize = True
        Me.lblgroup.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblgroup.ForeColor = System.Drawing.Color.Black
        Me.lblgroup.Location = New System.Drawing.Point(4, 4)
        Me.lblgroup.Name = "lblgroup"
        Me.lblgroup.Size = New System.Drawing.Size(42, 21)
        Me.lblgroup.TabIndex = 0
        Me.lblgroup.Text = "VAS"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Tan
        Me.Panel1.Controls.Add(Me.lblgroup)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(859, 27)
        Me.Panel1.TabIndex = 40199
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label6.Location = New System.Drawing.Point(40, 121)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 17)
        Me.Label6.TabIndex = 40200
        Me.Label6.Text = "SNo."
        '
        'txtVASName
        '
        Me.txtVASName.BackColor = System.Drawing.Color.GhostWhite
        Me.txtVASName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVASName.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtVASName.ForeColor = System.Drawing.Color.Black
        Me.txtVASName.Location = New System.Drawing.Point(117, 141)
        Me.txtVASName.Name = "txtVASName"
        Me.txtVASName.Size = New System.Drawing.Size(190, 23)
        Me.txtVASName.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label4.Location = New System.Drawing.Point(114, 121)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(142, 17)
        Me.Label4.TabIndex = 40212
        Me.Label4.Text = "Value Added Service"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 20.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label5.Location = New System.Drawing.Point(274, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(297, 33)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Value Added Service"
        '
        'VAS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.CadetBlue
        Me.ClientSize = New System.Drawing.Size(859, 464)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtVASName)
        Me.Controls.Add(Me.CbPer)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.txtSno)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dg1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cbTax)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.txtHSNCode)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCal)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label6)
        Me.Name = "VAS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VAS"
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CbPer As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents txtSno As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dg1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbTax As System.Windows.Forms.ComboBox
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents BtnDelete As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents txtHSNCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCal As System.Windows.Forms.TextBox
    Friend WithEvents lblgroup As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtVASName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
