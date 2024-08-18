<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Purchase_Type
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.RadioCompostion = New System.Windows.Forms.RadioButton()
        Me.RadioMannual = New System.Windows.Forms.RadioButton()
        Me.RadioInclusive = New System.Windows.Forms.RadioButton()
        Me.RadioExclusive = New System.Windows.Forms.RadioButton()
        Me.cbPrice = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbAccount = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnRetrive = New System.Windows.Forms.Button()
        Me.txtid = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtInvocieTypeName = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(12, 227)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 20)
        Me.Label2.TabIndex = 40160
        Me.Label2.Text = "Price to Apply"
        '
        'BtnDelete
        '
        Me.BtnDelete.BackColor = System.Drawing.Color.Black
        Me.BtnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDelete.ForeColor = System.Drawing.Color.GhostWhite
        Me.BtnDelete.Location = New System.Drawing.Point(375, 225)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(75, 27)
        Me.BtnDelete.TabIndex = 40158
        Me.BtnDelete.Text = "&Delete"
        Me.BtnDelete.UseVisualStyleBackColor = False
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.Black
        Me.BtnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.ForeColor = System.Drawing.Color.GhostWhite
        Me.BtnSave.Location = New System.Drawing.Point(475, 225)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 27)
        Me.BtnSave.TabIndex = 40157
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'RadioCompostion
        '
        Me.RadioCompostion.AutoSize = True
        Me.RadioCompostion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.RadioCompostion.Location = New System.Drawing.Point(384, 12)
        Me.RadioCompostion.Name = "RadioCompostion"
        Me.RadioCompostion.Size = New System.Drawing.Size(141, 24)
        Me.RadioCompostion.TabIndex = 3
        Me.RadioCompostion.TabStop = True
        Me.RadioCompostion.Text = "Tax &Compostion"
        Me.RadioCompostion.UseVisualStyleBackColor = True
        '
        'RadioMannual
        '
        Me.RadioMannual.AutoSize = True
        Me.RadioMannual.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.RadioMannual.Location = New System.Drawing.Point(261, 12)
        Me.RadioMannual.Name = "RadioMannual"
        Me.RadioMannual.Size = New System.Drawing.Size(117, 24)
        Me.RadioMannual.TabIndex = 2
        Me.RadioMannual.TabStop = True
        Me.RadioMannual.Text = "Tax &Mannual"
        Me.RadioMannual.UseVisualStyleBackColor = True
        '
        'RadioInclusive
        '
        Me.RadioInclusive.AutoSize = True
        Me.RadioInclusive.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.RadioInclusive.Location = New System.Drawing.Point(138, 12)
        Me.RadioInclusive.Name = "RadioInclusive"
        Me.RadioInclusive.Size = New System.Drawing.Size(117, 24)
        Me.RadioInclusive.TabIndex = 1
        Me.RadioInclusive.TabStop = True
        Me.RadioInclusive.Text = "Tax &Inclusive"
        Me.RadioInclusive.UseVisualStyleBackColor = True
        '
        'RadioExclusive
        '
        Me.RadioExclusive.AutoSize = True
        Me.RadioExclusive.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.RadioExclusive.Location = New System.Drawing.Point(11, 12)
        Me.RadioExclusive.Name = "RadioExclusive"
        Me.RadioExclusive.Size = New System.Drawing.Size(121, 24)
        Me.RadioExclusive.TabIndex = 0
        Me.RadioExclusive.TabStop = True
        Me.RadioExclusive.Text = "Tax &Exclusive"
        Me.RadioExclusive.UseVisualStyleBackColor = True
        '
        'cbPrice
        '
        Me.cbPrice.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbPrice.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbPrice.BackColor = System.Drawing.Color.AliceBlue
        Me.cbPrice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPrice.FormattingEnabled = True
        Me.cbPrice.Items.AddRange(New Object() {"Purchase", "Room Service", "Table Service", "POS", "Bar", "Take Away"})
        Me.cbPrice.Location = New System.Drawing.Point(174, 226)
        Me.cbPrice.Name = "cbPrice"
        Me.cbPrice.Size = New System.Drawing.Size(180, 26)
        Me.cbPrice.TabIndex = 40159
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.RadioCompostion)
        Me.Panel1.Controls.Add(Me.RadioMannual)
        Me.Panel1.Controls.Add(Me.RadioInclusive)
        Me.Panel1.Controls.Add(Me.RadioExclusive)
        Me.Panel1.Location = New System.Drawing.Point(16, 160)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(537, 47)
        Me.Panel1.TabIndex = 40156
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 130)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(146, 20)
        Me.Label1.TabIndex = 40155
        Me.Label1.Text = "Account to Be Post"
        '
        'cbAccount
        '
        Me.cbAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbAccount.BackColor = System.Drawing.Color.AliceBlue
        Me.cbAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbAccount.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAccount.FormattingEnabled = True
        Me.cbAccount.Location = New System.Drawing.Point(174, 128)
        Me.cbAccount.Name = "cbAccount"
        Me.cbAccount.Size = New System.Drawing.Size(379, 26)
        Me.cbAccount.TabIndex = 40154
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Black
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Red
        Me.Button1.Location = New System.Drawing.Point(502, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(51, 43)
        Me.Button1.TabIndex = 91113
        Me.Button1.TabStop = False
        Me.Button1.Text = "X"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btnRetrive
        '
        Me.btnRetrive.BackColor = System.Drawing.Color.Black
        Me.btnRetrive.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRetrive.ForeColor = System.Drawing.Color.Red
        Me.btnRetrive.Location = New System.Drawing.Point(502, 3)
        Me.btnRetrive.Name = "btnRetrive"
        Me.btnRetrive.Size = New System.Drawing.Size(51, 43)
        Me.btnRetrive.TabIndex = 91114
        Me.btnRetrive.TabStop = False
        Me.btnRetrive.Text = "R"
        Me.btnRetrive.UseVisualStyleBackColor = False
        '
        'txtid
        '
        Me.txtid.BackColor = System.Drawing.Color.AliceBlue
        Me.txtid.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtid.ForeColor = System.Drawing.Color.Black
        Me.txtid.Location = New System.Drawing.Point(53, 9)
        Me.txtid.Name = "txtid"
        Me.txtid.Size = New System.Drawing.Size(71, 26)
        Me.txtid.TabIndex = 40042
        Me.txtid.TabStop = False
        Me.txtid.Visible = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.Black
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Red
        Me.btnClose.Location = New System.Drawing.Point(884, 2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(51, 43)
        Me.btnClose.TabIndex = 10000
        Me.btnClose.TabStop = False
        Me.btnClose.Text = "X"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label41.Location = New System.Drawing.Point(160, 9)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(244, 31)
        Me.Label41.TabIndex = 91111
        Me.Label41.Text = "PURCHASE TYPE"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.btnRetrive)
        Me.Panel2.Controls.Add(Me.txtid)
        Me.Panel2.Controls.Add(Me.btnClose)
        Me.Panel2.Controls.Add(Me.Label41)
        Me.Panel2.Controls.Add(Me.Label40)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(572, 47)
        Me.Panel2.TabIndex = 40153
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label40.Location = New System.Drawing.Point(365, 9)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(0, 37)
        Me.Label40.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(23, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 20)
        Me.Label3.TabIndex = 40152
        Me.Label3.Text = "Purchase Type"
        '
        'txtInvocieTypeName
        '
        Me.txtInvocieTypeName.BackColor = System.Drawing.Color.AliceBlue
        Me.txtInvocieTypeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvocieTypeName.ForeColor = System.Drawing.Color.Black
        Me.txtInvocieTypeName.Location = New System.Drawing.Point(174, 96)
        Me.txtInvocieTypeName.Name = "txtInvocieTypeName"
        Me.txtInvocieTypeName.Size = New System.Drawing.Size(379, 26)
        Me.txtInvocieTypeName.TabIndex = 40151
        '
        'Purchase_Type
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(572, 258)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.cbPrice)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbAccount)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtInvocieTypeName)
        Me.Name = "Purchase_Type"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Purchase_Type"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnDelete As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents RadioCompostion As System.Windows.Forms.RadioButton
    Friend WithEvents RadioMannual As System.Windows.Forms.RadioButton
    Friend WithEvents RadioInclusive As System.Windows.Forms.RadioButton
    Friend WithEvents RadioExclusive As System.Windows.Forms.RadioButton
    Friend WithEvents cbPrice As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbAccount As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnRetrive As System.Windows.Forms.Button
    Friend WithEvents txtid As System.Windows.Forms.TextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtInvocieTypeName As System.Windows.Forms.TextBox
End Class
