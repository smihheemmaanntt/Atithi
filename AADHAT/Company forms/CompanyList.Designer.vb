﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CompanyList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CompanyList))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnRefress = New System.Windows.Forms.PictureBox()
        Me.dg1 = New System.Windows.Forms.DataGridView()
        Me.BtnRetrive = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtMainPath = New System.Windows.Forms.TextBox()
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.btnPath = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.BtnRefress, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(-6, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1052, 49)
        Me.Panel1.TabIndex = 164
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label1.Location = New System.Drawing.Point(363, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(287, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "LIST OF COMPANIES"
        '
        'BtnRefress
        '
        Me.BtnRefress.Enabled = False
        Me.BtnRefress.Image = CType(resources.GetObject("BtnRefress.Image"), System.Drawing.Image)
        Me.BtnRefress.Location = New System.Drawing.Point(1045, -1)
        Me.BtnRefress.Name = "BtnRefress"
        Me.BtnRefress.Size = New System.Drawing.Size(315, 633)
        Me.BtnRefress.TabIndex = 166
        Me.BtnRefress.TabStop = False
        '
        'dg1
        '
        Me.dg1.AllowUserToAddRows = False
        Me.dg1.AllowUserToDeleteRows = False
        Me.dg1.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dg1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dg1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dg1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg1.ColumnHeadersVisible = False
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg1.DefaultCellStyle = DataGridViewCellStyle2
        Me.dg1.GridColor = System.Drawing.Color.Gray
        Me.dg1.Location = New System.Drawing.Point(84, 130)
        Me.dg1.Name = "dg1"
        Me.dg1.ReadOnly = True
        Me.dg1.RowHeadersVisible = False
        Me.dg1.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dg1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg1.Size = New System.Drawing.Size(863, 390)
        Me.dg1.TabIndex = 165
        '
        'BtnRetrive
        '
        Me.BtnRetrive.BackColor = System.Drawing.Color.Black
        Me.BtnRetrive.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRetrive.ForeColor = System.Drawing.Color.GhostWhite
        Me.BtnRetrive.Location = New System.Drawing.Point(1044, 2)
        Me.BtnRetrive.Name = "BtnRetrive"
        Me.BtnRetrive.Size = New System.Drawing.Size(75, 27)
        Me.BtnRetrive.TabIndex = 167
        Me.BtnRetrive.Text = "&Retrive"
        Me.BtnRetrive.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 45)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1046, 585)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 171
        Me.PictureBox1.TabStop = False
        '
        'txtMainPath
        '
        Me.txtMainPath.BackColor = System.Drawing.Color.GhostWhite
        Me.txtMainPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMainPath.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.txtMainPath.ForeColor = System.Drawing.Color.Black
        Me.txtMainPath.Location = New System.Drawing.Point(205, 558)
        Me.txtMainPath.Name = "txtMainPath"
        Me.txtMainPath.ReadOnly = True
        Me.txtMainPath.Size = New System.Drawing.Size(742, 23)
        Me.txtMainPath.TabIndex = 176
        Me.txtMainPath.Visible = False
        '
        'txtPath
        '
        Me.txtPath.BackColor = System.Drawing.Color.GhostWhite
        Me.txtPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPath.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.txtPath.ForeColor = System.Drawing.Color.Black
        Me.txtPath.Location = New System.Drawing.Point(84, 524)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.ReadOnly = True
        Me.txtPath.Size = New System.Drawing.Size(863, 23)
        Me.txtPath.TabIndex = 175
        '
        'btnPath
        '
        Me.btnPath.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.btnPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPath.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPath.ForeColor = System.Drawing.Color.GhostWhite
        Me.btnPath.Location = New System.Drawing.Point(84, 550)
        Me.btnPath.Name = "btnPath"
        Me.btnPath.Size = New System.Drawing.Size(115, 35)
        Me.btnPath.TabIndex = 174
        Me.btnPath.Text = "Select &Path"
        Me.btnPath.UseVisualStyleBackColor = False
        Me.btnPath.Visible = False
        '
        'CompanyList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Moccasin
        Me.ClientSize = New System.Drawing.Size(1361, 622)
        Me.Controls.Add(Me.txtMainPath)
        Me.Controls.Add(Me.txtPath)
        Me.Controls.Add(Me.btnPath)
        Me.Controls.Add(Me.BtnRefress)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dg1)
        Me.Controls.Add(Me.BtnRetrive)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "CompanyList"
        Me.Text = "CompanyList"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.BtnRefress, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnRefress As System.Windows.Forms.PictureBox
    Friend WithEvents dg1 As System.Windows.Forms.DataGridView
    Friend WithEvents BtnRetrive As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtMainPath As System.Windows.Forms.TextBox
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents btnPath As System.Windows.Forms.Button
End Class
