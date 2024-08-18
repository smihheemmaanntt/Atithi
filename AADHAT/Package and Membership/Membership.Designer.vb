<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Membership
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblgroup = New System.Windows.Forms.Label()
        Me.txtAccount = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbpackageName = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtAmountpaid = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.mskExpiryDate = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.mskStartDate = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMemberID = New System.Windows.Forms.TextBox()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.btnList = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.txtAccountID = New System.Windows.Forms.TextBox()
        Me.DgAccountSearch = New System.Windows.Forms.DataGridView()
        Me.Panel1.SuspendLayout()
        CType(Me.DgAccountSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Controls.Add(Me.lblgroup)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(605, 27)
        Me.Panel1.TabIndex = 113
        '
        'lblgroup
        '
        Me.lblgroup.AutoSize = True
        Me.lblgroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblgroup.ForeColor = System.Drawing.Color.GhostWhite
        Me.lblgroup.Location = New System.Drawing.Point(4, 4)
        Me.lblgroup.Name = "lblgroup"
        Me.lblgroup.Size = New System.Drawing.Size(100, 20)
        Me.lblgroup.TabIndex = 1
        Me.lblgroup.Text = "Membership "
        '
        'txtAccount
        '
        Me.txtAccount.BackColor = System.Drawing.Color.AliceBlue
        Me.txtAccount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccount.ForeColor = System.Drawing.Color.Black
        Me.txtAccount.Location = New System.Drawing.Point(12, 67)
        Me.txtAccount.Name = "txtAccount"
        Me.txtAccount.Size = New System.Drawing.Size(349, 26)
        Me.txtAccount.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(118, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(113, 20)
        Me.Label6.TabIndex = 123
        Me.Label6.Text = "Member Name"
        '
        'cbpackageName
        '
        Me.cbpackageName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbpackageName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbpackageName.BackColor = System.Drawing.Color.AliceBlue
        Me.cbpackageName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbpackageName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbpackageName.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbpackageName.ForeColor = System.Drawing.Color.Black
        Me.cbpackageName.FormattingEnabled = True
        Me.cbpackageName.Location = New System.Drawing.Point(388, 67)
        Me.cbpackageName.Name = "cbpackageName"
        Me.cbpackageName.Size = New System.Drawing.Size(183, 26)
        Me.cbpackageName.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(420, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 20)
        Me.Label1.TabIndex = 125
        Me.Label1.Text = "Package Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(423, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 127
        Me.Label2.Text = "Amount Paid"
        '
        'txtAmountpaid
        '
        Me.txtAmountpaid.BackColor = System.Drawing.Color.AliceBlue
        Me.txtAmountpaid.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmountpaid.ForeColor = System.Drawing.Color.Red
        Me.txtAmountpaid.Location = New System.Drawing.Point(388, 127)
        Me.txtAmountpaid.Name = "txtAmountpaid"
        Me.txtAmountpaid.Size = New System.Drawing.Size(183, 26)
        Me.txtAmountpaid.TabIndex = 5
        Me.txtAmountpaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(225, 104)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(90, 20)
        Me.Label29.TabIndex = 40142
        Me.Label29.Text = "Expiry Date"
        '
        'mskExpiryDate
        '
        Me.mskExpiryDate.BackColor = System.Drawing.Color.AliceBlue
        Me.mskExpiryDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskExpiryDate.ForeColor = System.Drawing.Color.Red
        Me.mskExpiryDate.Location = New System.Drawing.Point(183, 127)
        Me.mskExpiryDate.Mask = "00-00-0000"
        Me.mskExpiryDate.Name = "mskExpiryDate"
        Me.mskExpiryDate.Size = New System.Drawing.Size(178, 26)
        Me.mskExpiryDate.TabIndex = 4
        Me.mskExpiryDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(38, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 20)
        Me.Label3.TabIndex = 40144
        Me.Label3.Text = "Start Date"
        '
        'mskStartDate
        '
        Me.mskStartDate.BackColor = System.Drawing.Color.AliceBlue
        Me.mskStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskStartDate.ForeColor = System.Drawing.Color.Red
        Me.mskStartDate.Location = New System.Drawing.Point(12, 127)
        Me.mskStartDate.Mask = "00-00-0000"
        Me.mskStartDate.Name = "mskStartDate"
        Me.mskStartDate.Size = New System.Drawing.Size(142, 26)
        Me.mskStartDate.TabIndex = 3
        Me.mskStartDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(128, 170)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 20)
        Me.Label4.TabIndex = 40146
        Me.Label4.Text = "Member ID"
        '
        'txtMemberID
        '
        Me.txtMemberID.BackColor = System.Drawing.Color.AliceBlue
        Me.txtMemberID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMemberID.ForeColor = System.Drawing.Color.Black
        Me.txtMemberID.Location = New System.Drawing.Point(12, 193)
        Me.txtMemberID.Name = "txtMemberID"
        Me.txtMemberID.Size = New System.Drawing.Size(349, 26)
        Me.txtMemberID.TabIndex = 6
        '
        'BtnDelete
        '
        Me.BtnDelete.BackColor = System.Drawing.Color.Black
        Me.BtnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDelete.ForeColor = System.Drawing.Color.GhostWhite
        Me.BtnDelete.Location = New System.Drawing.Point(496, 193)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(75, 27)
        Me.BtnDelete.TabIndex = 8
        Me.BtnDelete.Text = "&Delete"
        Me.BtnDelete.UseVisualStyleBackColor = False
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.Black
        Me.BtnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.ForeColor = System.Drawing.Color.GhostWhite
        Me.BtnSave.Location = New System.Drawing.Point(496, 159)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 27)
        Me.BtnSave.TabIndex = 7
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'btnList
        '
        Me.btnList.BackColor = System.Drawing.Color.Black
        Me.btnList.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnList.ForeColor = System.Drawing.Color.GhostWhite
        Me.btnList.Location = New System.Drawing.Point(415, 159)
        Me.btnList.Name = "btnList"
        Me.btnList.Size = New System.Drawing.Size(75, 27)
        Me.btnList.TabIndex = 9
        Me.btnList.Text = "&List"
        Me.btnList.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.Black
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.GhostWhite
        Me.btnClose.Location = New System.Drawing.Point(415, 193)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 27)
        Me.btnClose.TabIndex = 10
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'txtID
        '
        Me.txtID.BackColor = System.Drawing.Color.AliceBlue
        Me.txtID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtID.ForeColor = System.Drawing.Color.Black
        Me.txtID.Location = New System.Drawing.Point(283, 35)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(78, 26)
        Me.txtID.TabIndex = 40169
        Me.txtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtID.Visible = False
        '
        'txtAccountID
        '
        Me.txtAccountID.BackColor = System.Drawing.Color.AliceBlue
        Me.txtAccountID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccountID.ForeColor = System.Drawing.Color.Black
        Me.txtAccountID.Location = New System.Drawing.Point(12, 38)
        Me.txtAccountID.Name = "txtAccountID"
        Me.txtAccountID.Size = New System.Drawing.Size(78, 26)
        Me.txtAccountID.TabIndex = 40170
        Me.txtAccountID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtAccountID.Visible = False
        '
        'DgAccountSearch
        '
        Me.DgAccountSearch.AllowUserToAddRows = False
        Me.DgAccountSearch.AllowUserToDeleteRows = False
        Me.DgAccountSearch.AllowUserToResizeRows = False
        Me.DgAccountSearch.BackgroundColor = System.Drawing.Color.Ivory
        Me.DgAccountSearch.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgAccountSearch.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgAccountSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgAccountSearch.ColumnHeadersVisible = False
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgAccountSearch.DefaultCellStyle = DataGridViewCellStyle2
        Me.DgAccountSearch.GridColor = System.Drawing.Color.Gray
        Me.DgAccountSearch.Location = New System.Drawing.Point(12, 88)
        Me.DgAccountSearch.MultiSelect = False
        Me.DgAccountSearch.Name = "DgAccountSearch"
        Me.DgAccountSearch.ReadOnly = True
        Me.DgAccountSearch.RowHeadersVisible = False
        Me.DgAccountSearch.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgAccountSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgAccountSearch.Size = New System.Drawing.Size(349, 131)
        Me.DgAccountSearch.TabIndex = 40288
        Me.DgAccountSearch.TabStop = False
        Me.DgAccountSearch.Visible = False
        '
        'Membership
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(605, 246)
        Me.Controls.Add(Me.txtAccountID)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.btnList)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtMemberID)
        Me.Controls.Add(Me.mskStartDate)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.mskExpiryDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtAmountpaid)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbpackageName)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtAccount)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.DgAccountSearch)
        Me.Name = "Membership"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MemberShip"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DgAccountSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblgroup As System.Windows.Forms.Label
    Friend WithEvents txtAccount As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbpackageName As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtAmountpaid As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents mskExpiryDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents mskStartDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMemberID As System.Windows.Forms.TextBox
    Friend WithEvents BtnDelete As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents btnList As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents txtAccountID As System.Windows.Forms.TextBox
    Friend WithEvents DgAccountSearch As System.Windows.Forms.DataGridView
End Class
