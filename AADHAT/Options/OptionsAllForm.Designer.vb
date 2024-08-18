<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OptionsAllForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OptionsAllForm))
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.TCOptions = New System.Windows.Forms.TabControl()
        Me.tpGenral = New System.Windows.Forms.TabPage()
        Me.txtCheckOutPrefix = New System.Windows.Forms.TextBox()
        Me.txtCheckinPrefix = New System.Windows.Forms.TextBox()
        Me.txtBookingPrefix = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ck24hr = New System.Windows.Forms.CheckBox()
        Me.dtpCheckoutTime = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.ckOutCoppies = New System.Windows.Forms.CheckBox()
        Me.CkOutPreView = New System.Windows.Forms.CheckBox()
        Me.ckOutDont = New System.Windows.Forms.CheckBox()
        Me.ckOutAsk = New System.Windows.Forms.CheckBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.CkCheckINCoppies = New System.Windows.Forms.CheckBox()
        Me.CkCheckPreview = New System.Windows.Forms.CheckBox()
        Me.ckCheckinDont = New System.Windows.Forms.CheckBox()
        Me.CkCheckInAsk = New System.Windows.Forms.CheckBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.CkBooking2Coppies = New System.Windows.Forms.CheckBox()
        Me.ckBookingPrintPriView = New System.Windows.Forms.CheckBox()
        Me.CkBookingDontPrint = New System.Windows.Forms.CheckBox()
        Me.CkBookingAskPrint = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.ckBill2Copy = New System.Windows.Forms.CheckBox()
        Me.ckBillPrintPreview = New System.Windows.Forms.CheckBox()
        Me.ckBillDoNotPrint = New System.Windows.Forms.CheckBox()
        Me.ckBillAskForPrint = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ckKOT2Copy = New System.Windows.Forms.CheckBox()
        Me.ckKOTPrintPreView = New System.Windows.Forms.CheckBox()
        Me.ckKOTDoNotPrint = New System.Windows.Forms.CheckBox()
        Me.ckKOTAskForPrint = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ckPOS2Copy = New System.Windows.Forms.CheckBox()
        Me.ckPOSPrintPreview = New System.Windows.Forms.CheckBox()
        Me.ckPOSDoNotPrint = New System.Windows.Forms.CheckBox()
        Me.ckPosAskForPrint = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.cbDecimalValues = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TCOptions.SuspendLayout()
        Me.tpGenral.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtID
        '
        Me.txtID.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtID.Location = New System.Drawing.Point(12, 21)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(121, 26)
        Me.txtID.TabIndex = 91113
        Me.txtID.TabStop = False
        Me.txtID.Text = "1"
        Me.txtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtID.Visible = False
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label41.Location = New System.Drawing.Point(440, -22)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(137, 31)
        Me.Label41.TabIndex = 101
        Me.Label41.Text = "OPTIONS"
        '
        'TCOptions
        '
        Me.TCOptions.Controls.Add(Me.tpGenral)
        Me.TCOptions.Location = New System.Drawing.Point(12, 53)
        Me.TCOptions.Name = "TCOptions"
        Me.TCOptions.SelectedIndex = 0
        Me.TCOptions.Size = New System.Drawing.Size(1170, 503)
        Me.TCOptions.TabIndex = 40040
        '
        'tpGenral
        '
        Me.tpGenral.Controls.Add(Me.Label7)
        Me.tpGenral.Controls.Add(Me.cbDecimalValues)
        Me.tpGenral.Controls.Add(Me.txtCheckOutPrefix)
        Me.tpGenral.Controls.Add(Me.txtCheckinPrefix)
        Me.tpGenral.Controls.Add(Me.txtBookingPrefix)
        Me.tpGenral.Controls.Add(Me.Label6)
        Me.tpGenral.Controls.Add(Me.Label5)
        Me.tpGenral.Controls.Add(Me.Label4)
        Me.tpGenral.Controls.Add(Me.Label2)
        Me.tpGenral.Controls.Add(Me.ck24hr)
        Me.tpGenral.Controls.Add(Me.Label41)
        Me.tpGenral.Controls.Add(Me.dtpCheckoutTime)
        Me.tpGenral.Controls.Add(Me.Label1)
        Me.tpGenral.Controls.Add(Me.GroupBox1)
        Me.tpGenral.Location = New System.Drawing.Point(4, 22)
        Me.tpGenral.Name = "tpGenral"
        Me.tpGenral.Padding = New System.Windows.Forms.Padding(3)
        Me.tpGenral.Size = New System.Drawing.Size(1162, 477)
        Me.tpGenral.TabIndex = 0
        Me.tpGenral.Text = "General/Printing"
        Me.tpGenral.UseVisualStyleBackColor = True
        '
        'txtCheckOutPrefix
        '
        Me.txtCheckOutPrefix.BackColor = System.Drawing.Color.GhostWhite
        Me.txtCheckOutPrefix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCheckOutPrefix.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtCheckOutPrefix.ForeColor = System.Drawing.Color.Red
        Me.txtCheckOutPrefix.Location = New System.Drawing.Point(166, 123)
        Me.txtCheckOutPrefix.Name = "txtCheckOutPrefix"
        Me.txtCheckOutPrefix.Size = New System.Drawing.Size(179, 26)
        Me.txtCheckOutPrefix.TabIndex = 91116
        Me.txtCheckOutPrefix.TabStop = False
        '
        'txtCheckinPrefix
        '
        Me.txtCheckinPrefix.BackColor = System.Drawing.Color.GhostWhite
        Me.txtCheckinPrefix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCheckinPrefix.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtCheckinPrefix.ForeColor = System.Drawing.Color.Red
        Me.txtCheckinPrefix.Location = New System.Drawing.Point(166, 91)
        Me.txtCheckinPrefix.Name = "txtCheckinPrefix"
        Me.txtCheckinPrefix.Size = New System.Drawing.Size(179, 26)
        Me.txtCheckinPrefix.TabIndex = 91115
        Me.txtCheckinPrefix.TabStop = False
        '
        'txtBookingPrefix
        '
        Me.txtBookingPrefix.BackColor = System.Drawing.Color.GhostWhite
        Me.txtBookingPrefix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBookingPrefix.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtBookingPrefix.ForeColor = System.Drawing.Color.Red
        Me.txtBookingPrefix.Location = New System.Drawing.Point(166, 58)
        Me.txtBookingPrefix.Name = "txtBookingPrefix"
        Me.txtBookingPrefix.Size = New System.Drawing.Size(179, 26)
        Me.txtBookingPrefix.TabIndex = 91114
        Me.txtBookingPrefix.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.Label6.Location = New System.Drawing.Point(6, 128)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(158, 19)
        Me.Label6.TabIndex = 40227
        Me.Label6.Text = "Check Out No. Prefix :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.Label5.Location = New System.Drawing.Point(17, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(144, 19)
        Me.Label5.TabIndex = 40226
        Me.Label5.Text = "Check In No. Prefix :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.Label4.Location = New System.Drawing.Point(23, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(137, 19)
        Me.Label4.TabIndex = 40225
        Me.Label4.Text = "Booking No. Prefix :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.Label2.Location = New System.Drawing.Point(378, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(151, 19)
        Me.Label2.TabIndex = 40224
        Me.Label2.Text = "Check Out Method :"
        '
        'ck24hr
        '
        Me.ck24hr.AutoSize = True
        Me.ck24hr.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.ck24hr.Location = New System.Drawing.Point(535, 27)
        Me.ck24hr.Name = "ck24hr"
        Me.ck24hr.Size = New System.Drawing.Size(92, 23)
        Me.ck24hr.TabIndex = 40223
        Me.ck24hr.Text = "24Hr Stay"
        Me.ck24hr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ck24hr.UseVisualStyleBackColor = True
        '
        'dtpCheckoutTime
        '
        Me.dtpCheckoutTime.CalendarFont = New System.Drawing.Font("Times New Roman", 11.0!)
        Me.dtpCheckoutTime.CalendarMonthBackground = System.Drawing.Color.GhostWhite
        Me.dtpCheckoutTime.CustomFormat = "HH:mm tt"
        Me.dtpCheckoutTime.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.dtpCheckoutTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpCheckoutTime.Location = New System.Drawing.Point(166, 27)
        Me.dtpCheckoutTime.Name = "dtpCheckoutTime"
        Me.dtpCheckoutTime.ShowUpDown = True
        Me.dtpCheckoutTime.Size = New System.Drawing.Size(179, 24)
        Me.dtpCheckoutTime.TabIndex = 40222
        Me.dtpCheckoutTime.Value = New Date(2020, 8, 19, 15, 20, 0, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.Label1.Location = New System.Drawing.Point(34, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Check Out Time :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox7)
        Me.GroupBox1.Controls.Add(Me.GroupBox6)
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Red
        Me.GroupBox1.Location = New System.Drawing.Point(645, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(511, 361)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Print Preview"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.ckOutCoppies)
        Me.GroupBox7.Controls.Add(Me.CkOutPreView)
        Me.GroupBox7.Controls.Add(Me.ckOutDont)
        Me.GroupBox7.Controls.Add(Me.ckOutAsk)
        Me.GroupBox7.Location = New System.Drawing.Point(6, 304)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(495, 48)
        Me.GroupBox7.TabIndex = 9
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Check-Out Print / Preview"
        '
        'ckOutCoppies
        '
        Me.ckOutCoppies.AutoSize = True
        Me.ckOutCoppies.Location = New System.Drawing.Point(327, 19)
        Me.ckOutCoppies.Name = "ckOutCoppies"
        Me.ckOutCoppies.Size = New System.Drawing.Size(73, 17)
        Me.ckOutCoppies.TabIndex = 4
        Me.ckOutCoppies.Text = "&2 Coppies"
        Me.ckOutCoppies.UseVisualStyleBackColor = True
        '
        'CkOutPreView
        '
        Me.CkOutPreView.AutoSize = True
        Me.CkOutPreView.Location = New System.Drawing.Point(202, 19)
        Me.CkOutPreView.Name = "CkOutPreView"
        Me.CkOutPreView.Size = New System.Drawing.Size(88, 17)
        Me.CkOutPreView.TabIndex = 3
        Me.CkOutPreView.Text = "&Print Preview"
        Me.CkOutPreView.UseVisualStyleBackColor = True
        '
        'ckOutDont
        '
        Me.ckOutDont.AutoSize = True
        Me.ckOutDont.Location = New System.Drawing.Point(6, 19)
        Me.ckOutDont.Name = "ckOutDont"
        Me.ckOutDont.Size = New System.Drawing.Size(84, 17)
        Me.ckOutDont.TabIndex = 2
        Me.ckOutDont.Text = "&Do Not Print"
        Me.ckOutDont.UseVisualStyleBackColor = True
        '
        'ckOutAsk
        '
        Me.ckOutAsk.AutoSize = True
        Me.ckOutAsk.Location = New System.Drawing.Point(96, 19)
        Me.ckOutAsk.Name = "ckOutAsk"
        Me.ckOutAsk.Size = New System.Drawing.Size(89, 17)
        Me.ckOutAsk.TabIndex = 1
        Me.ckOutAsk.Text = "&Ask For  Print"
        Me.ckOutAsk.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.CkCheckINCoppies)
        Me.GroupBox6.Controls.Add(Me.CkCheckPreview)
        Me.GroupBox6.Controls.Add(Me.ckCheckinDont)
        Me.GroupBox6.Controls.Add(Me.CkCheckInAsk)
        Me.GroupBox6.Location = New System.Drawing.Point(6, 241)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(495, 48)
        Me.GroupBox6.TabIndex = 8
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Check-In Print / Preview"
        '
        'CkCheckINCoppies
        '
        Me.CkCheckINCoppies.AutoSize = True
        Me.CkCheckINCoppies.Location = New System.Drawing.Point(327, 19)
        Me.CkCheckINCoppies.Name = "CkCheckINCoppies"
        Me.CkCheckINCoppies.Size = New System.Drawing.Size(73, 17)
        Me.CkCheckINCoppies.TabIndex = 4
        Me.CkCheckINCoppies.Text = "&2 Coppies"
        Me.CkCheckINCoppies.UseVisualStyleBackColor = True
        '
        'CkCheckPreview
        '
        Me.CkCheckPreview.AutoSize = True
        Me.CkCheckPreview.Location = New System.Drawing.Point(202, 19)
        Me.CkCheckPreview.Name = "CkCheckPreview"
        Me.CkCheckPreview.Size = New System.Drawing.Size(88, 17)
        Me.CkCheckPreview.TabIndex = 3
        Me.CkCheckPreview.Text = "&Print Preview"
        Me.CkCheckPreview.UseVisualStyleBackColor = True
        '
        'ckCheckinDont
        '
        Me.ckCheckinDont.AutoSize = True
        Me.ckCheckinDont.Location = New System.Drawing.Point(6, 19)
        Me.ckCheckinDont.Name = "ckCheckinDont"
        Me.ckCheckinDont.Size = New System.Drawing.Size(84, 17)
        Me.ckCheckinDont.TabIndex = 2
        Me.ckCheckinDont.Text = "&Do Not Print"
        Me.ckCheckinDont.UseVisualStyleBackColor = True
        '
        'CkCheckInAsk
        '
        Me.CkCheckInAsk.AutoSize = True
        Me.CkCheckInAsk.Location = New System.Drawing.Point(96, 19)
        Me.CkCheckInAsk.Name = "CkCheckInAsk"
        Me.CkCheckInAsk.Size = New System.Drawing.Size(89, 17)
        Me.CkCheckInAsk.TabIndex = 1
        Me.CkCheckInAsk.Text = "&Ask For  Print"
        Me.CkCheckInAsk.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.CkBooking2Coppies)
        Me.GroupBox5.Controls.Add(Me.ckBookingPrintPriView)
        Me.GroupBox5.Controls.Add(Me.CkBookingDontPrint)
        Me.GroupBox5.Controls.Add(Me.CkBookingAskPrint)
        Me.GroupBox5.Location = New System.Drawing.Point(6, 187)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(495, 48)
        Me.GroupBox5.TabIndex = 7
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Booking Print / Preview"
        '
        'CkBooking2Coppies
        '
        Me.CkBooking2Coppies.AutoSize = True
        Me.CkBooking2Coppies.Location = New System.Drawing.Point(327, 19)
        Me.CkBooking2Coppies.Name = "CkBooking2Coppies"
        Me.CkBooking2Coppies.Size = New System.Drawing.Size(73, 17)
        Me.CkBooking2Coppies.TabIndex = 4
        Me.CkBooking2Coppies.Text = "&2 Coppies"
        Me.CkBooking2Coppies.UseVisualStyleBackColor = True
        '
        'ckBookingPrintPriView
        '
        Me.ckBookingPrintPriView.AutoSize = True
        Me.ckBookingPrintPriView.Location = New System.Drawing.Point(202, 19)
        Me.ckBookingPrintPriView.Name = "ckBookingPrintPriView"
        Me.ckBookingPrintPriView.Size = New System.Drawing.Size(88, 17)
        Me.ckBookingPrintPriView.TabIndex = 3
        Me.ckBookingPrintPriView.Text = "&Print Preview"
        Me.ckBookingPrintPriView.UseVisualStyleBackColor = True
        '
        'CkBookingDontPrint
        '
        Me.CkBookingDontPrint.AutoSize = True
        Me.CkBookingDontPrint.Location = New System.Drawing.Point(6, 19)
        Me.CkBookingDontPrint.Name = "CkBookingDontPrint"
        Me.CkBookingDontPrint.Size = New System.Drawing.Size(84, 17)
        Me.CkBookingDontPrint.TabIndex = 2
        Me.CkBookingDontPrint.Text = "&Do Not Print"
        Me.CkBookingDontPrint.UseVisualStyleBackColor = True
        '
        'CkBookingAskPrint
        '
        Me.CkBookingAskPrint.AutoSize = True
        Me.CkBookingAskPrint.Location = New System.Drawing.Point(96, 19)
        Me.CkBookingAskPrint.Name = "CkBookingAskPrint"
        Me.CkBookingAskPrint.Size = New System.Drawing.Size(89, 17)
        Me.CkBookingAskPrint.TabIndex = 1
        Me.CkBookingAskPrint.Text = "&Ask For  Print"
        Me.CkBookingAskPrint.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.ckBill2Copy)
        Me.GroupBox4.Controls.Add(Me.ckBillPrintPreview)
        Me.GroupBox4.Controls.Add(Me.ckBillDoNotPrint)
        Me.GroupBox4.Controls.Add(Me.ckBillAskForPrint)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 133)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(495, 48)
        Me.GroupBox4.TabIndex = 6
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Food Bill Print / Preview"
        '
        'ckBill2Copy
        '
        Me.ckBill2Copy.AutoSize = True
        Me.ckBill2Copy.Location = New System.Drawing.Point(327, 19)
        Me.ckBill2Copy.Name = "ckBill2Copy"
        Me.ckBill2Copy.Size = New System.Drawing.Size(73, 17)
        Me.ckBill2Copy.TabIndex = 4
        Me.ckBill2Copy.Text = "&2 Coppies"
        Me.ckBill2Copy.UseVisualStyleBackColor = True
        '
        'ckBillPrintPreview
        '
        Me.ckBillPrintPreview.AutoSize = True
        Me.ckBillPrintPreview.Location = New System.Drawing.Point(202, 19)
        Me.ckBillPrintPreview.Name = "ckBillPrintPreview"
        Me.ckBillPrintPreview.Size = New System.Drawing.Size(88, 17)
        Me.ckBillPrintPreview.TabIndex = 3
        Me.ckBillPrintPreview.Text = "&Print Preview"
        Me.ckBillPrintPreview.UseVisualStyleBackColor = True
        '
        'ckBillDoNotPrint
        '
        Me.ckBillDoNotPrint.AutoSize = True
        Me.ckBillDoNotPrint.Location = New System.Drawing.Point(6, 19)
        Me.ckBillDoNotPrint.Name = "ckBillDoNotPrint"
        Me.ckBillDoNotPrint.Size = New System.Drawing.Size(84, 17)
        Me.ckBillDoNotPrint.TabIndex = 2
        Me.ckBillDoNotPrint.Text = "&Do Not Print"
        Me.ckBillDoNotPrint.UseVisualStyleBackColor = True
        '
        'ckBillAskForPrint
        '
        Me.ckBillAskForPrint.AutoSize = True
        Me.ckBillAskForPrint.Location = New System.Drawing.Point(96, 19)
        Me.ckBillAskForPrint.Name = "ckBillAskForPrint"
        Me.ckBillAskForPrint.Size = New System.Drawing.Size(89, 17)
        Me.ckBillAskForPrint.TabIndex = 1
        Me.ckBillAskForPrint.Text = "&Ask For  Print"
        Me.ckBillAskForPrint.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ckKOT2Copy)
        Me.GroupBox3.Controls.Add(Me.ckKOTPrintPreView)
        Me.GroupBox3.Controls.Add(Me.ckKOTDoNotPrint)
        Me.GroupBox3.Controls.Add(Me.ckKOTAskForPrint)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 79)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(495, 48)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "KOT Print / Preview"
        '
        'ckKOT2Copy
        '
        Me.ckKOT2Copy.AutoSize = True
        Me.ckKOT2Copy.Location = New System.Drawing.Point(327, 19)
        Me.ckKOT2Copy.Name = "ckKOT2Copy"
        Me.ckKOT2Copy.Size = New System.Drawing.Size(73, 17)
        Me.ckKOT2Copy.TabIndex = 4
        Me.ckKOT2Copy.Text = "&2 Coppies"
        Me.ckKOT2Copy.UseVisualStyleBackColor = True
        '
        'ckKOTPrintPreView
        '
        Me.ckKOTPrintPreView.AutoSize = True
        Me.ckKOTPrintPreView.Location = New System.Drawing.Point(201, 19)
        Me.ckKOTPrintPreView.Name = "ckKOTPrintPreView"
        Me.ckKOTPrintPreView.Size = New System.Drawing.Size(88, 17)
        Me.ckKOTPrintPreView.TabIndex = 3
        Me.ckKOTPrintPreView.Text = "&Print Preview"
        Me.ckKOTPrintPreView.UseVisualStyleBackColor = True
        '
        'ckKOTDoNotPrint
        '
        Me.ckKOTDoNotPrint.AutoSize = True
        Me.ckKOTDoNotPrint.Location = New System.Drawing.Point(6, 19)
        Me.ckKOTDoNotPrint.Name = "ckKOTDoNotPrint"
        Me.ckKOTDoNotPrint.Size = New System.Drawing.Size(84, 17)
        Me.ckKOTDoNotPrint.TabIndex = 2
        Me.ckKOTDoNotPrint.Text = "&Do Not Print"
        Me.ckKOTDoNotPrint.UseVisualStyleBackColor = True
        '
        'ckKOTAskForPrint
        '
        Me.ckKOTAskForPrint.AutoSize = True
        Me.ckKOTAskForPrint.Location = New System.Drawing.Point(96, 19)
        Me.ckKOTAskForPrint.Name = "ckKOTAskForPrint"
        Me.ckKOTAskForPrint.Size = New System.Drawing.Size(89, 17)
        Me.ckKOTAskForPrint.TabIndex = 1
        Me.ckKOTAskForPrint.Text = "&Ask For  Print"
        Me.ckKOTAskForPrint.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ckPOS2Copy)
        Me.GroupBox2.Controls.Add(Me.ckPOSPrintPreview)
        Me.GroupBox2.Controls.Add(Me.ckPOSDoNotPrint)
        Me.GroupBox2.Controls.Add(Me.ckPosAskForPrint)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 25)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(495, 48)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "P.O.S Print / Preview"
        '
        'ckPOS2Copy
        '
        Me.ckPOS2Copy.AutoSize = True
        Me.ckPOS2Copy.Location = New System.Drawing.Point(327, 19)
        Me.ckPOS2Copy.Name = "ckPOS2Copy"
        Me.ckPOS2Copy.Size = New System.Drawing.Size(73, 17)
        Me.ckPOS2Copy.TabIndex = 4
        Me.ckPOS2Copy.Text = "&2 Coppies"
        Me.ckPOS2Copy.UseVisualStyleBackColor = True
        '
        'ckPOSPrintPreview
        '
        Me.ckPOSPrintPreview.AutoSize = True
        Me.ckPOSPrintPreview.Location = New System.Drawing.Point(201, 19)
        Me.ckPOSPrintPreview.Name = "ckPOSPrintPreview"
        Me.ckPOSPrintPreview.Size = New System.Drawing.Size(88, 17)
        Me.ckPOSPrintPreview.TabIndex = 3
        Me.ckPOSPrintPreview.Text = "&Print Preview"
        Me.ckPOSPrintPreview.UseVisualStyleBackColor = True
        '
        'ckPOSDoNotPrint
        '
        Me.ckPOSDoNotPrint.AutoSize = True
        Me.ckPOSDoNotPrint.Location = New System.Drawing.Point(6, 19)
        Me.ckPOSDoNotPrint.Name = "ckPOSDoNotPrint"
        Me.ckPOSDoNotPrint.Size = New System.Drawing.Size(84, 17)
        Me.ckPOSDoNotPrint.TabIndex = 2
        Me.ckPOSDoNotPrint.Text = "&Do Not Print"
        Me.ckPOSDoNotPrint.UseVisualStyleBackColor = True
        '
        'ckPosAskForPrint
        '
        Me.ckPosAskForPrint.AutoSize = True
        Me.ckPosAskForPrint.Location = New System.Drawing.Point(96, 19)
        Me.ckPosAskForPrint.Name = "ckPosAskForPrint"
        Me.ckPosAskForPrint.Size = New System.Drawing.Size(89, 17)
        Me.ckPosAskForPrint.TabIndex = 1
        Me.ckPosAskForPrint.Text = "&Ask For  Print"
        Me.ckPosAskForPrint.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.DodgerBlue
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.GhostWhite
        Me.Button1.Location = New System.Drawing.Point(963, 562)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(215, 45)
        Me.Button1.TabIndex = 40041
        Me.Button1.Text = "&Save Changes"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(1154, -2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(40, 40)
        Me.btnClose.TabIndex = 91196
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Bodoni Bk BT", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(543, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(175, 48)
        Me.Label3.TabIndex = 40225
        Me.Label3.Text = "OPTIONS"
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(487, 3)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox4.TabIndex = 91208
        Me.PictureBox4.TabStop = False
        '
        'cbDecimalValues
        '
        Me.cbDecimalValues.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDecimalValues.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbDecimalValues.FormattingEnabled = True
        Me.cbDecimalValues.Items.AddRange(New Object() {"0", "0.0", "0.00", "0.000", "0.0000", "0.00000"})
        Me.cbDecimalValues.Location = New System.Drawing.Point(484, 62)
        Me.cbDecimalValues.Name = "cbDecimalValues"
        Me.cbDecimalValues.Size = New System.Drawing.Size(143, 21)
        Me.cbDecimalValues.TabIndex = 91117
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.Label7.Location = New System.Drawing.Point(360, 61)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(118, 19)
        Me.Label7.TabIndex = 91118
        Me.Label7.Text = "Decimal Value :"
        '
        'OptionsAllForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.GhostWhite
        Me.ClientSize = New System.Drawing.Size(1194, 630)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TCOptions)
        Me.Name = "OptionsAllForm"
        Me.Text = "OptionsAllForm"
        Me.TCOptions.ResumeLayout(False)
        Me.tpGenral.ResumeLayout(False)
        Me.tpGenral.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents TCOptions As System.Windows.Forms.TabControl
    Friend WithEvents tpGenral As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents ckBill2Copy As System.Windows.Forms.CheckBox
    Friend WithEvents ckBillPrintPreview As System.Windows.Forms.CheckBox
    Friend WithEvents ckBillDoNotPrint As System.Windows.Forms.CheckBox
    Friend WithEvents ckBillAskForPrint As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ckKOT2Copy As System.Windows.Forms.CheckBox
    Friend WithEvents ckKOTPrintPreView As System.Windows.Forms.CheckBox
    Friend WithEvents ckKOTDoNotPrint As System.Windows.Forms.CheckBox
    Friend WithEvents ckKOTAskForPrint As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ckPOS2Copy As System.Windows.Forms.CheckBox
    Friend WithEvents ckPOSPrintPreview As System.Windows.Forms.CheckBox
    Friend WithEvents ckPOSDoNotPrint As System.Windows.Forms.CheckBox
    Friend WithEvents ckPosAskForPrint As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents ckOutCoppies As System.Windows.Forms.CheckBox
    Friend WithEvents CkOutPreView As System.Windows.Forms.CheckBox
    Friend WithEvents ckOutDont As System.Windows.Forms.CheckBox
    Friend WithEvents ckOutAsk As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents CkCheckINCoppies As System.Windows.Forms.CheckBox
    Friend WithEvents CkCheckPreview As System.Windows.Forms.CheckBox
    Friend WithEvents ckCheckinDont As System.Windows.Forms.CheckBox
    Friend WithEvents CkCheckInAsk As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents CkBooking2Coppies As System.Windows.Forms.CheckBox
    Friend WithEvents ckBookingPrintPriView As System.Windows.Forms.CheckBox
    Friend WithEvents CkBookingDontPrint As System.Windows.Forms.CheckBox
    Friend WithEvents CkBookingAskPrint As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ck24hr As System.Windows.Forms.CheckBox
    Friend WithEvents dtpCheckoutTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents txtCheckOutPrefix As System.Windows.Forms.TextBox
    Friend WithEvents txtCheckinPrefix As System.Windows.Forms.TextBox
    Friend WithEvents txtBookingPrefix As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbDecimalValues As System.Windows.Forms.ComboBox
End Class
