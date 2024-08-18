<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainScreenPicture
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainScreenPicture))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTotalBooking = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblTotalCheckIn = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.LblTotalCheckOut = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblTbleTotal = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblOrgName = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.lbltime = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.lblDay = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.lblFinYear = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.lblCity = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.lblTotalFood = New System.Windows.Forms.Label()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.pbtime = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.btnRefreshRoom = New System.Windows.Forms.Button()
        Me.btnRefreshTables = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel9.SuspendLayout()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbtime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.RosyBrown
        Me.Panel1.Controls.Add(Me.lblTotalBooking)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(56, 56)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 100)
        Me.Panel1.TabIndex = 0
        '
        'lblTotalBooking
        '
        Me.lblTotalBooking.Font = New System.Drawing.Font("Times New Roman", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalBooking.ForeColor = System.Drawing.Color.GhostWhite
        Me.lblTotalBooking.Location = New System.Drawing.Point(71, 54)
        Me.lblTotalBooking.Name = "lblTotalBooking"
        Me.lblTotalBooking.Size = New System.Drawing.Size(115, 34)
        Me.lblTotalBooking.TabIndex = 3
        Me.lblTotalBooking.Text = "0.00"
        Me.lblTotalBooking.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(15, 38)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label1.Location = New System.Drawing.Point(12, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Today's Booking"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SandyBrown
        Me.Panel2.Controls.Add(Me.lblTotalCheckIn)
        Me.Panel2.Controls.Add(Me.PictureBox2)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(271, 56)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(200, 100)
        Me.Panel2.TabIndex = 2
        '
        'lblTotalCheckIn
        '
        Me.lblTotalCheckIn.Font = New System.Drawing.Font("Times New Roman", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalCheckIn.ForeColor = System.Drawing.Color.GhostWhite
        Me.lblTotalCheckIn.Location = New System.Drawing.Point(71, 54)
        Me.lblTotalCheckIn.Name = "lblTotalCheckIn"
        Me.lblTotalCheckIn.Size = New System.Drawing.Size(115, 34)
        Me.lblTotalCheckIn.TabIndex = 2
        Me.lblTotalCheckIn.Text = "0.00"
        Me.lblTotalCheckIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(15, 38)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label2.Location = New System.Drawing.Point(12, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 15)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Today's Check In"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.BurlyWood
        Me.Panel3.Controls.Add(Me.LblTotalCheckOut)
        Me.Panel3.Controls.Add(Me.PictureBox3)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Location = New System.Drawing.Point(486, 56)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(200, 100)
        Me.Panel3.TabIndex = 3
        '
        'LblTotalCheckOut
        '
        Me.LblTotalCheckOut.Font = New System.Drawing.Font("Times New Roman", 16.0!, System.Drawing.FontStyle.Bold)
        Me.LblTotalCheckOut.ForeColor = System.Drawing.Color.GhostWhite
        Me.LblTotalCheckOut.Location = New System.Drawing.Point(71, 54)
        Me.LblTotalCheckOut.Name = "LblTotalCheckOut"
        Me.LblTotalCheckOut.Size = New System.Drawing.Size(115, 34)
        Me.LblTotalCheckOut.TabIndex = 3
        Me.LblTotalCheckOut.Text = "0.00"
        Me.LblTotalCheckOut.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(15, 38)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox3.TabIndex = 1
        Me.PictureBox3.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label3.Location = New System.Drawing.Point(12, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 15)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Today's Check Out"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.SaddleBrown
        Me.Panel4.Controls.Add(Me.lblTbleTotal)
        Me.Panel4.Controls.Add(Me.PictureBox4)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Location = New System.Drawing.Point(701, 56)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(200, 100)
        Me.Panel4.TabIndex = 4
        '
        'lblTbleTotal
        '
        Me.lblTbleTotal.Font = New System.Drawing.Font("Times New Roman", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblTbleTotal.ForeColor = System.Drawing.Color.GhostWhite
        Me.lblTbleTotal.Location = New System.Drawing.Point(71, 54)
        Me.lblTbleTotal.Name = "lblTbleTotal"
        Me.lblTbleTotal.Size = New System.Drawing.Size(115, 34)
        Me.lblTbleTotal.TabIndex = 3
        Me.lblTbleTotal.Text = "0.00"
        Me.lblTbleTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(15, 38)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox4.TabIndex = 1
        Me.PictureBox4.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label4.Location = New System.Drawing.Point(12, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(132, 15)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Today's  Table Booking"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(56, 260)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(415, 324)
        Me.FlowLayoutPanel1.TabIndex = 5
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.AutoScroll = True
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(486, 260)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(630, 324)
        Me.FlowLayoutPanel2.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(53, 240)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 15)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Room Status :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(488, 240)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(79, 15)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "Table Status :"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.SeaGreen
        Me.Panel5.Location = New System.Drawing.Point(245, 240)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(17, 17)
        Me.Panel5.TabIndex = 8
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(268, 240)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 15)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "Booked"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(173, 240)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(57, 15)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "Available"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.CadetBlue
        Me.Panel6.Location = New System.Drawing.Point(150, 240)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(17, 17)
        Me.Panel6.TabIndex = 10
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(603, 240)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(57, 15)
        Me.Label13.TabIndex = 15
        Me.Label13.Text = "Available"
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel7.Location = New System.Drawing.Point(580, 240)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(17, 17)
        Me.Panel7.TabIndex = 14
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(705, 240)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(48, 15)
        Me.Label14.TabIndex = 13
        Me.Label14.Text = "Booked"
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.SeaGreen
        Me.Panel8.Location = New System.Drawing.Point(674, 240)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(17, 17)
        Me.Panel8.TabIndex = 12
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Times New Roman", 15.0!)
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(853, 608)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(262, 22)
        Me.Label15.TabIndex = 16
        Me.Label15.Text = "SOFT MANAGEMENT INDIA"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(854, 587)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(97, 15)
        Me.Label16.TabIndex = 17
        Me.Label16.Text = "Handcrafted By :"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(53, 10)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(108, 15)
        Me.Label17.TabIndex = 18
        Me.Label17.Text = "Organization Name"
        '
        'lblOrgName
        '
        Me.lblOrgName.AutoSize = True
        Me.lblOrgName.Font = New System.Drawing.Font("Times New Roman", 15.0!)
        Me.lblOrgName.ForeColor = System.Drawing.Color.Black
        Me.lblOrgName.Location = New System.Drawing.Point(52, 30)
        Me.lblOrgName.Name = "lblOrgName"
        Me.lblOrgName.Size = New System.Drawing.Size(219, 22)
        Me.lblOrgName.TabIndex = 19
        Me.lblOrgName.Text = "HOTEL MIRAGE PLACE"
        Me.lblOrgName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(112, 175)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(32, 15)
        Me.Label19.TabIndex = 20
        Me.Label19.Text = "User"
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblUser.ForeColor = System.Drawing.Color.Black
        Me.lblUser.Location = New System.Drawing.Point(112, 202)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(67, 15)
        Me.lblUser.TabIndex = 21
        Me.lblUser.Text = "User Name"
        '
        'lbltime
        '
        Me.lbltime.Font = New System.Drawing.Font("Monotype Corsiva", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltime.ForeColor = System.Drawing.Color.Black
        Me.lbltime.Location = New System.Drawing.Point(1041, 219)
        Me.lbltime.Name = "lbltime"
        Me.lbltime.Size = New System.Drawing.Size(75, 27)
        Me.lbltime.TabIndex = 22
        Me.lbltime.Text = "00:00:00"
        Me.lbltime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDate
        '
        Me.lblDate.Font = New System.Drawing.Font("Monotype Corsiva", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.Color.Black
        Me.lblDate.Location = New System.Drawing.Point(1041, 192)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(75, 27)
        Me.lblDate.TabIndex = 23
        Me.lblDate.Text = "dd-MM-yyyy"
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDay
        '
        Me.lblDay.Font = New System.Drawing.Font("Monotype Corsiva", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDay.ForeColor = System.Drawing.Color.Black
        Me.lblDay.Location = New System.Drawing.Point(1018, 159)
        Me.lblDay.Name = "lblDay"
        Me.lblDay.Size = New System.Drawing.Size(98, 27)
        Me.lblDay.TabIndex = 24
        Me.lblDay.Text = "Day"
        Me.lblDay.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("BlackChancery", 30.0!)
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(58, 584)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(110, 47)
        Me.Label20.TabIndex = 28
        Me.Label20.Text = "Atithi"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(166, 604)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(80, 15)
        Me.Label21.TabIndex = 29
        Me.Label21.Text = "Devo Bhavah"
        '
        'lblFinYear
        '
        Me.lblFinYear.Font = New System.Drawing.Font("Times New Roman", 15.0!)
        Me.lblFinYear.ForeColor = System.Drawing.Color.Black
        Me.lblFinYear.Location = New System.Drawing.Point(347, 196)
        Me.lblFinYear.Name = "lblFinYear"
        Me.lblFinYear.Size = New System.Drawing.Size(124, 23)
        Me.lblFinYear.TabIndex = 31
        Me.lblFinYear.Text = "0000-0000"
        Me.lblFinYear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(374, 175)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(81, 15)
        Me.Label22.TabIndex = 30
        Me.Label22.Text = "Financial Year"
        '
        'lblCity
        '
        Me.lblCity.Font = New System.Drawing.Font("Times New Roman", 15.0!)
        Me.lblCity.ForeColor = System.Drawing.Color.Black
        Me.lblCity.Location = New System.Drawing.Point(482, 195)
        Me.lblCity.Name = "lblCity"
        Me.lblCity.Size = New System.Drawing.Size(419, 23)
        Me.lblCity.TabIndex = 33
        Me.lblCity.Text = "City"
        Me.lblCity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(488, 175)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(29, 15)
        Me.Label23.TabIndex = 32
        Me.Label23.Text = "City"
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.Coral
        Me.Panel9.Controls.Add(Me.lblTotalFood)
        Me.Panel9.Controls.Add(Me.PictureBox9)
        Me.Panel9.Controls.Add(Me.Label24)
        Me.Panel9.Location = New System.Drawing.Point(916, 56)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(200, 100)
        Me.Panel9.TabIndex = 5
        '
        'lblTotalFood
        '
        Me.lblTotalFood.Font = New System.Drawing.Font("Times New Roman", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalFood.ForeColor = System.Drawing.Color.GhostWhite
        Me.lblTotalFood.Location = New System.Drawing.Point(71, 54)
        Me.lblTotalFood.Name = "lblTotalFood"
        Me.lblTotalFood.Size = New System.Drawing.Size(115, 34)
        Me.lblTotalFood.TabIndex = 3
        Me.lblTotalFood.Text = "0.00"
        Me.lblTotalFood.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PictureBox9
        '
        Me.PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), System.Drawing.Image)
        Me.PictureBox9.Location = New System.Drawing.Point(15, 38)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox9.TabIndex = 1
        Me.PictureBox9.TabStop = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label24.Location = New System.Drawing.Point(12, 16)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(103, 15)
        Me.Label24.TabIndex = 0
        Me.Label24.Text = "Today's  Food Bill"
        '
        'PictureBox8
        '
        Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
        Me.PictureBox8.Location = New System.Drawing.Point(992, 162)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox8.TabIndex = 27
        Me.PictureBox8.TabStop = False
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(992, 192)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox7.TabIndex = 26
        Me.PictureBox7.TabStop = False
        '
        'pbtime
        '
        Me.pbtime.Image = Global.Atithi.My.Resources.Resources.icons8_sand_watch_20px
        Me.pbtime.Location = New System.Drawing.Point(992, 219)
        Me.pbtime.Name = "pbtime"
        Me.pbtime.Size = New System.Drawing.Size(20, 20)
        Me.pbtime.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbtime.TabIndex = 25
        Me.pbtime.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(56, 170)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox5.TabIndex = 4
        Me.PictureBox5.TabStop = False
        '
        'btnRefreshRoom
        '
        Me.btnRefreshRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefreshRoom.Font = New System.Drawing.Font("Microsoft Sans Serif", 5.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefreshRoom.ForeColor = System.Drawing.Color.Navy
        Me.btnRefreshRoom.Location = New System.Drawing.Point(351, 240)
        Me.btnRefreshRoom.Name = "btnRefreshRoom"
        Me.btnRefreshRoom.Size = New System.Drawing.Size(75, 17)
        Me.btnRefreshRoom.TabIndex = 34
        Me.btnRefreshRoom.Text = "Refresh"
        Me.btnRefreshRoom.UseVisualStyleBackColor = True
        '
        'btnRefreshTables
        '
        Me.btnRefreshTables.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefreshTables.Font = New System.Drawing.Font("Microsoft Sans Serif", 5.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefreshTables.ForeColor = System.Drawing.Color.Navy
        Me.btnRefreshTables.Location = New System.Drawing.Point(812, 240)
        Me.btnRefreshTables.Name = "btnRefreshTables"
        Me.btnRefreshTables.Size = New System.Drawing.Size(75, 17)
        Me.btnRefreshTables.TabIndex = 35
        Me.btnRefreshTables.Text = "Refresh"
        Me.btnRefreshTables.UseVisualStyleBackColor = True
        '
        'MainScreenPicture
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.GhostWhite
        Me.ClientSize = New System.Drawing.Size(1194, 662)
        Me.Controls.Add(Me.btnRefreshTables)
        Me.Controls.Add(Me.btnRefreshRoom)
        Me.Controls.Add(Me.Panel9)
        Me.Controls.Add(Me.lblCity)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.lblFinYear)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.PictureBox8)
        Me.Controls.Add(Me.PictureBox7)
        Me.Controls.Add(Me.pbtime)
        Me.Controls.Add(Me.lblDay)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.lbltime)
        Me.Controls.Add(Me.lblUser)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.lblOrgName)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Panel8)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.FlowLayoutPanel2)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "MainScreenPicture"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "MainScreenPicture"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbtime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblTotalBooking As System.Windows.Forms.Label
    Friend WithEvents lblTotalCheckIn As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents LblTotalCheckOut As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lblTbleTotal As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblOrgName As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents lbltime As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents lblDay As System.Windows.Forms.Label
    Friend WithEvents pbtime As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lblFinYear As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents lblCity As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents lblTotalFood As System.Windows.Forms.Label
    Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents btnRefreshRoom As System.Windows.Forms.Button
    Friend WithEvents btnRefreshTables As System.Windows.Forms.Button
End Class
