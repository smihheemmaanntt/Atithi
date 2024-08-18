<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Mobile_App
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Mobile_App))
        Me.txtCompanyID = New System.Windows.Forms.TextBox()
        Me.BtnIDGenrate = New System.Windows.Forms.Button()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.btnSync = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CkShowPassword = New System.Windows.Forms.CheckBox()
        Me.ckSynconClose = New System.Windows.Forms.CheckBox()
        Me.dataProgress = New System.Windows.Forms.ProgressBar()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtCompanyID
        '
        Me.txtCompanyID.BackColor = System.Drawing.Color.GhostWhite
        Me.txtCompanyID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCompanyID.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtCompanyID.ForeColor = System.Drawing.Color.Black
        Me.txtCompanyID.Location = New System.Drawing.Point(232, 156)
        Me.txtCompanyID.Name = "txtCompanyID"
        Me.txtCompanyID.ReadOnly = True
        Me.txtCompanyID.Size = New System.Drawing.Size(200, 27)
        Me.txtCompanyID.TabIndex = 1
        '
        'BtnIDGenrate
        '
        Me.BtnIDGenrate.BackColor = System.Drawing.Color.DarkTurquoise
        Me.BtnIDGenrate.FlatAppearance.BorderSize = 0
        Me.BtnIDGenrate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnIDGenrate.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.BtnIDGenrate.ForeColor = System.Drawing.Color.GhostWhite
        Me.BtnIDGenrate.Location = New System.Drawing.Point(227, 25)
        Me.BtnIDGenrate.Name = "BtnIDGenrate"
        Me.BtnIDGenrate.Size = New System.Drawing.Size(208, 44)
        Me.BtnIDGenrate.TabIndex = 0
        Me.BtnIDGenrate.Text = "&Genrate Organization ID"
        Me.BtnIDGenrate.UseVisualStyleBackColor = False
        '
        'txtPassword
        '
        Me.txtPassword.BackColor = System.Drawing.Color.GhostWhite
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPassword.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtPassword.ForeColor = System.Drawing.Color.Black
        Me.txtPassword.Location = New System.Drawing.Point(233, 210)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(199, 27)
        Me.txtPassword.TabIndex = 2
        Me.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnSync
        '
        Me.btnSync.BackColor = System.Drawing.Color.DarkTurquoise
        Me.btnSync.FlatAppearance.BorderSize = 0
        Me.btnSync.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSync.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnSync.ForeColor = System.Drawing.Color.GhostWhite
        Me.btnSync.Location = New System.Drawing.Point(227, 384)
        Me.btnSync.Name = "btnSync"
        Me.btnSync.Size = New System.Drawing.Size(208, 35)
        Me.btnSync.TabIndex = 5
        Me.btnSync.Text = "&Synchronization On Server "
        Me.btnSync.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.GhostWhite
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(263, 133)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(123, 17)
        Me.Label6.TabIndex = 124
        Me.Label6.Text = "Your Organisation"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.GhostWhite
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(273, 190)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 17)
        Me.Label1.TabIndex = 125
        Me.Label1.Text = "Your Password"
        '
        'CkShowPassword
        '
        Me.CkShowPassword.AutoSize = True
        Me.CkShowPassword.BackColor = System.Drawing.Color.GhostWhite
        Me.CkShowPassword.Font = New System.Drawing.Font("Times New Roman", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CkShowPassword.ForeColor = System.Drawing.Color.Red
        Me.CkShowPassword.Location = New System.Drawing.Point(346, 243)
        Me.CkShowPassword.Name = "CkShowPassword"
        Me.CkShowPassword.Size = New System.Drawing.Size(86, 16)
        Me.CkShowPassword.TabIndex = 3
        Me.CkShowPassword.Text = "&Show Password"
        Me.CkShowPassword.UseVisualStyleBackColor = False
        '
        'ckSynconClose
        '
        Me.ckSynconClose.AutoSize = True
        Me.ckSynconClose.BackColor = System.Drawing.Color.GhostWhite
        Me.ckSynconClose.Font = New System.Drawing.Font("Times New Roman", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ckSynconClose.ForeColor = System.Drawing.Color.Red
        Me.ckSynconClose.Location = New System.Drawing.Point(232, 267)
        Me.ckSynconClose.Name = "ckSynconClose"
        Me.ckSynconClose.Size = New System.Drawing.Size(186, 16)
        Me.ckSynconClose.TabIndex = 4
        Me.ckSynconClose.Text = "&Autometic Sync When Close Application"
        Me.ckSynconClose.UseVisualStyleBackColor = False
        '
        'dataProgress
        '
        Me.dataProgress.BackColor = System.Drawing.Color.Red
        Me.dataProgress.Location = New System.Drawing.Point(232, 355)
        Me.dataProgress.Name = "dataProgress"
        Me.dataProgress.Size = New System.Drawing.Size(200, 23)
        Me.dataProgress.TabIndex = 129
        Me.dataProgress.Visible = False
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(364, 289)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(54, 20)
        Me.txtID.TabIndex = 128
        Me.txtID.TabStop = False
        Me.txtID.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.GhostWhite
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(470, 500)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 130
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.GhostWhite
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(13, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(190, 32)
        Me.Label2.TabIndex = 131
        Me.Label2.Text = "Step 1 : If you are 1st Time Click on" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " "" Genrate Organization ID ""."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.GhostWhite
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(12, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(176, 16)
        Me.Label3.TabIndex = 132
        Me.Label3.Text = "Step 2 : Choose Your Password."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.GhostWhite
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(12, 110)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(173, 48)
        Me.Label4.TabIndex = 133
        Me.Label4.Text = "Step 3 : Click  "" Synchronization" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " On Server "". Be patience." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "It Will Take Some " & _
    "Time."
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Mobile_App
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(470, 500)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dataProgress)
        Me.Controls.Add(Me.btnSync)
        Me.Controls.Add(Me.ckSynconClose)
        Me.Controls.Add(Me.CkShowPassword)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.BtnIDGenrate)
        Me.Controls.Add(Me.txtCompanyID)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "Mobile_App"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mobile_App"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCompanyID As System.Windows.Forms.TextBox
    Friend WithEvents BtnIDGenrate As System.Windows.Forms.Button
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents btnSync As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CkShowPassword As System.Windows.Forms.CheckBox
    Friend WithEvents ckSynconClose As System.Windows.Forms.CheckBox
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents dataProgress As System.Windows.Forms.ProgressBar
End Class
