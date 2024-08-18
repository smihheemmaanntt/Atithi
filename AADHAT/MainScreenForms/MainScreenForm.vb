Imports System.Management
Imports System.Text
Imports System.Configuration
Imports System.Xml
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Reflection

Public Class MainScreenForm

    Dim rs As New Resizer
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub

    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub
    Private Sub NewAccountToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewAccountToolStripMenuItem.Click
        CreateAccount.MdiParent = Me
        CreateAccount.Show()
        If Not CreateAccount Is Nothing Then
            CreateAccount.BringToFront()
        End If
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        clsFun.changeCompany()
        Me.Hide()
        ShowCompanies.Show()
        Me.Dispose()
    End Sub


    Private Sub AccountListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AccountListToolStripMenuItem.Click
        Account_List.MdiParent = Me
        Account_List.Show()
        If Not Account_List Is Nothing Then
            Account_List.BringToFront()
        End If
    End Sub

    Private Sub AddGroupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddGroupToolStripMenuItem.Click
        Account_Group.MdiParent = Me
        Account_Group.Show()
        If Not Account_Group Is Nothing Then
            Account_Group.BringToFront()
        End If
    End Sub

    Private Sub ListGroupToolStripMenuItem_Click(sender As Object, e As EventArgs)
        account_group_list.MdiParent = Me
        account_group_list.Show()
        If Not account_group_list Is Nothing Then
            account_group_list.BringToFront()
        End If
    End Sub

    Private Sub TeamViewerQSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TeamViewerQSToolStripMenuItem.Click
        Dim p As New System.Diagnostics.Process
        p.StartInfo.FileName = Application.StartupPath & "\TeamViewerQS.exe"
        p.Start()
    End Sub

    Private Sub AnyDeskToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnyDeskToolStripMenuItem.Click
        Dim p As New System.Diagnostics.Process
        p.StartInfo.FileName = Application.StartupPath & "\anydesk.exe"
        p.Start()
    End Sub
    Private Sub RecieptVoucherToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecieptVoucherToolStripMenuItem.Click
        RecieptForm.MdiParent = Me
        RecieptForm.Show()
        RecieptForm.BringToFront()

    End Sub


    Private Sub MainScreenForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        backup()
        clsFun.changeCompany()
        Application.Exit()
    End Sub
    Private Sub backup()
        If Directory.Exists(Application.StartupPath & "\Backup") = False Then
            Directory.CreateDirectory(Application.StartupPath & "\Backup")
        End If
        Dim compfolder As String = clsFun.ExecScalarStr("Select CompData from Company") ''clsFun.ExecScalarStr("Select CompData from Company")
        If compfolder = "" Then clsFun.changeCompany() : Application.Exit() : Exit Sub
        Dim compfolder1 As String = compfolder
        compfolder = compfolder.Substring(0, compfolder.LastIndexOf("\"))
        If Directory.Exists(Application.StartupPath & "\Backup\" & compfolder) = False Then
            Directory.CreateDirectory(Application.StartupPath & "\Backup\" & compfolder)
        End If
        Dim FileName As String = "Data-" & clsFun.GetServerDate().Replace("-", "") & ".db"
        File.Copy(Application.StartupPath & "\Data\" & compfolder1, Application.StartupPath & "\Backup\" & compfolder & "\" & FileName, True)
    End Sub
    Private Sub MainScreenForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String = clsFun.ExecScalarStr("Select CompanyName from Company")
        FinYearStart = clsFun.ExecScalarStr("Select YearStart from Company")
        FinYearEnd = clsFun.ExecScalarStr("Select Yearend from Company")
        Dim AccName As String = sql & " "
        Dim fecha As Date = IO.File.GetCreationTime(Assembly.GetExecutingAssembly().Location)
        Me.Text = "[Atithi #" & CDate(fecha).ToString("yyMMddhhmm") & "] [#" & AccName & "]" & " [" & CDate(FinYearStart).ToString("dd-MM-yy") & " To " & CDate(FinYearEnd).ToString("dd-MM-yy") & "]"
        MainScreenPicture.MdiParent = Me
        MainScreenPicture.Show()
    End Sub

    Private Sub BankEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BankEntryToolStripMenuItem.Click
        Bank_Entry.MdiParent = Me
        Bank_Entry.Show()
            Bank_Entry.BringToFront()
    End Sub

    Private Sub ChargesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChargesToolStripMenuItem.Click
        ChargesForm.MdiParent = Me
        ChargesForm.Show()
            ChargesForm.BringToFront()
    End Sub

    Private Sub CashBankBookToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CashBankBookToolStripMenuItem.Click
        Cash_Bank_Book.MdiParent = Me
        Cash_Bank_Book.Show()
            Cash_Bank_Book.BringToFront()
    End Sub
    Private Sub MainScreenForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        'rs.ResizeAllControls(Me)
    End Sub
    Private Sub RegisterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegisterToolStripMenuItem.Click
        ActivationForm.MdiParent = Me
        ActivationForm.Show()
            ActivationForm.BringToFront()
    End Sub
    Private Sub JournalEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JournalEntryToolStripMenuItem.Click
        JournalEntry.MdiParent = Me
        JournalEntry.Show()
            JournalEntry.BringToFront()
    End Sub
    Private Sub PaymentVoucherToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PaymentVoucherToolStripMenuItem.Click
        PayMentform.MdiParent = Me
        PayMentform.Show()
            PayMentform.BringToFront()
    End Sub
    Private Sub JournalEntryRegisterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JournalEntryRegisterToolStripMenuItem.Click
        Journal_Register.MdiParent = Me
        Journal_Register.Show()
        Journal_Register.BringToFront()
    End Sub
    Private Sub PaymentRegisterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PaymentRegisterToolStripMenuItem.Click
        Payment_Register.MdiParent = Me
        Payment_Register.Show()
        Payment_Register.BringToFront()
    End Sub
    Private Sub btnRecieptRegister_Click(sender As Object, e As EventArgs)
        PayMentform.MdiParent = Me
        PayMentform.Show()
        PayMentform.BringToFront()
    End Sub
    Private Sub RecieptRegisterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecieptRegisterToolStripMenuItem.Click
        RcptRegisterForm.MdiParent = Me
        RcptRegisterForm.Show()
        RcptRegisterForm.BringToFront()
    End Sub
    Private Sub BankEntryRegisterToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BankEntryRegisterToolStripMenuItem1.Click
        bank_Register.MdiParent = Me
        bank_Register.Show()
        bank_Register.BringToFront()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        MainScreenPicture.lbltime.Text = Format(TimeOfDay, "hh:mm tt")
        MainScreenPicture.lblDate.Text = Format(Date.Now, "dd-MM-yyyy")
        MainScreenPicture.lblDay.Text = DateTime.Now.DayOfWeek.ToString()
        Dim sec As Integer = CDate(Format(TimeOfDay, "hh:mm:ss")).Second
        If CLng(sec) Mod 2 > 0 Then
            MainScreenPicture.pbtime.Image = My.Resources.icons8_sand_watch_20px
        Else
            MainScreenPicture.pbtime.Image = My.Resources.icons8_sand_timer_20px
        End If

    End Sub
    Private Sub CalculatorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalculatorToolStripMenuItem.Click
        Dim p As New System.Diagnostics.Process
        p.StartInfo.FileName = "calc.exe"
        p.Start()
    End Sub
    Private Sub ClearDataToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If MessageBox.Show("Are you Sure want to Record Delete, It can't Be Reverse ??", "Be careFul", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.OK Then
            clsFun.ExecNonQuery("Delete from Items")
            clsFun.ExecNonQuery("Delete  From Accounts where Tag=1")
            clsFun.ExecNonQuery("Delete from Ledger")
            clsFun.ExecNonQuery("Delete from Trans")
            clsFun.ExecNonQuery("Delete from SmsAPI")
            clsFun.ExecNonQuery("Delete from Vouchers")
            clsFun.ExecNonQuery("Delete from ChargesTrans")
            MsgBox("Data is Null & Fully Refreshed Now", MsgBoxStyle.Information, "Data Refreshed")
        End If
    End Sub


    Private Sub ItemUnitMasterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ItemUnitMasterToolStripMenuItem.Click
        Unit_items.MdiParent = Me
        Unit_items.Show()
        Unit_items.BringToFront()
    End Sub

    Private Sub CreateGroupToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Group_items.MdiParent = Me
        Group_items.Show()
        Group_items.BringToFront()
    End Sub

    Private Sub CreateInvoiceTypeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateInvoiceTypeToolStripMenuItem.Click
        Purchase_Type.MdiParent = Me
        Purchase_Type.Show()
        Purchase_Type.BringToFront()
    End Sub

    Private Sub InvoiceTypeRegisterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InvoiceTypeRegisterToolStripMenuItem.Click
        Purchase_Type_Register.MdiParent = Me
        Purchase_Type_Register.Show()
        Purchase_Type_Register.BringToFront()
    End Sub

    Private Sub CreateItemsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateItemsToolStripMenuItem.Click
        Items.MdiParent = Me
        Items.Show()
        Items.BringToFront()
    End Sub

    Private Sub ItemRegisterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ItemRegisterToolStripMenuItem.Click
        Item_Register.MdiParent = Me
        Item_Register.Show()
            Item_Register.BringToFront()
    End Sub

    Private Sub PurchaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PurchaseToolStripMenuItem.Click
        Purchase.MdiParent = Me
        Purchase.Show()
        Purchase.BringToFront()
    End Sub

    Private Sub SMSTempletesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SMSTempletesToolStripMenuItem.Click
        SmsTemplete.MdiParent = Me
        SmsTemplete.Show()
            SmsTemplete.BringToFront()
    End Sub

    Private Sub CreateUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateUserToolStripMenuItem.Click
        UserForm.MdiParent = Me
        UserForm.Show()
        UserForm.BringToFront()
    End Sub

    Private Sub UserRegisterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserRegisterToolStripMenuItem.Click
        Users_Register.MdiParent = Me
        Users_Register.Show()
        Users_Register.BringToFront()
    End Sub

    Private Sub RoomTypesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RoomTypesToolStripMenuItem.Click
        Room_Type.MdiParent = Me
        Room_Type.Show()
        Room_Type.BringToFront()
    End Sub

    Private Sub TablesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TablesToolStripMenuItem.Click
        RestroTables.MdiParent = Me
        RestroTables.Show()
        RestroTables.BringToFront()
    End Sub

    Private Sub CreateSaleTypeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateSaleTypeToolStripMenuItem.Click
        Sale_Type.MdiParent = Me
        Sale_Type.Show()
        Sale_Type.BringToFront()
    End Sub

    Private Sub SaleTypeRegisterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaleTypeRegisterToolStripMenuItem.Click
        Sale_Type_Register.MdiParent = Me
        Sale_Type_Register.Show()
        Sale_Type_Register.BringToFront()
    End Sub

    Private Sub OptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OptionsToolStripMenuItem.Click
        OptionsAllForm.MdiParent = Me
        OptionsAllForm.Show()
        OptionsAllForm.BringToFront()
    End Sub

    Private Sub CreateAttenderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateAttenderToolStripMenuItem.Click
        Attender.MdiParent = Me
        Attender.Show()
        Attender.BringToFront()

    End Sub

    Private Sub CreateAttenderTableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateAttenderTableToolStripMenuItem.Click
        clsFun.ExecScalarStr("CREATE TABLE Attender ( " & _
                            " ID              INTEGER PRIMARY KEY AUTOINCREMENT, " & _
                            " AttenderName    TEXT,  AttenderCode     DATE, " & _
                            " DOB              DATE, DOJ              DATE, " & _
                            " Add1             TEXT, Add2             TEXT, " & _
                            " City             TEXT, State            TEXT, " & _
                            " Mobile1          TEXT,  Mobile2          TEXT, " & _
                            " AlternetAddress1 TEXT,  alternetAddress2 TEXT, " & _
                            " AlternetCity     TEXT,  AlternetState    TEXT, " & _
                            " GuarntorName     TEXT,  GuarantorAddress TEXT, " & _
                            " GaurantorCity    TEXT,  GaurantorState   TEXT, " & _
                            " GaurantorMob1    TEXT, GaurantorMob2 Text  ); " & _
                            " CREATE TABLE KOTTrans (  KOTID    INTEGER,   " & _
                            " ItemID   INTEGER,     ItemName TEXT,   " & _
                            " SrNo     INTEGER, Unit     TEXT,   " & _
                            " Qty      DECIMAL,Rate     DECIMAL,  " & _
                            " Amount   DECIMAL,    TableNo  TEXT);" & _
                            " CREATE TABLE KOT ( " & _
                            " ID           INTEGER PRIMARY KEY AUTOINCREMENT, " & _
                            " KOTNo        TEXT," & _
                            " AttenderID   INTEGER, " & _
                            " AttenderName TEXT," & _
                            "    ServiceName(Text, " & _
                            "TotalQty     DECIMAL," & _
                            "TotalAmount  DECIMAL," & _
                            "   TableNos Text);")
    End Sub

    Private Sub AttenderRegisterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AttenderRegisterToolStripMenuItem.Click
        Attender_Register.MdiParent = Me
        Attender_Register.Show()
        Attender_Register.BringToFront()
    End Sub

    Private Sub KOTEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KOTEntryToolStripMenuItem.Click
        KOT.MdiParent = Me
        KOT.Show()
        If Not KOT Is Nothing Then
            KOT.BringToFront()
        End If
    End Sub

    Private Sub BillEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BillEntryToolStripMenuItem.Click
        Food_Bill.MdiParent = Me
        Food_Bill.Show()
        Food_Bill.BringToFront()
    End Sub

    Private Sub LedgerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LedgerToolStripMenuItem.Click
        Ledger.MdiParent = Me
        Ledger.Show()
        Ledger.BringToFront()
    End Sub

    Private Sub DayBookToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DayBookToolStripMenuItem1.Click
        Day_book.MdiParent = Me
        Day_book.Show()
        Day_book.BringToFront()
    End Sub

    Private Sub PurchaseRegisterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PurchaseRegisterToolStripMenuItem.Click
        Purchase_Register.MdiParent = Me
        Purchase_Register.Show()
        Purchase_Register.BringToFront()
    End Sub

    Private Sub SaleRegisterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaleRegisterToolStripMenuItem.Click
        Food_Bill_Register.MdiParent = Me
        Food_Bill_Register.Show()
        Food_Bill_Register.BringToFront()
    End Sub

    Private Sub POSEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles POSEntryToolStripMenuItem.Click
        POS.Show()
        POS.BringToFront()

    End Sub

    Private Sub GSTR2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GSTR2ToolStripMenuItem.Click
        GSTR_2.MdiParent = Me
        GSTR_2.Show()
        GSTR_2.BringToFront()
    End Sub

    Private Sub PackageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PackageToolStripMenuItem.Click
        Package.MdiParent = Me
        Package.Show()
        Package.BringToFront()

    End Sub

    Private Sub RoomCreationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RoomCreationToolStripMenuItem.Click
        Rooms.MdiParent = Me
        Rooms.Show()
        Rooms.BringToFront()

    End Sub

    Private Sub StateNameCodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StateNameCodeToolStripMenuItem.Click
        State.MdiParent = Me
        State.Show()
        State.BringToFront()
    End Sub

    Private Sub BusinessSourcesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BusinessSourcesToolStripMenuItem.Click
        BusinessSources.MdiParent = Me
        BusinessSources.Show()
            BusinessSources.BringToFront()
    End Sub

    Private Sub VASToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VASToolStripMenuItem.Click
        VAS.MdiParent = Me
        VAS.Show()
        If Not VAS Is Nothing Then
            VAS.BringToFront()
        End If
    End Sub

    Private Sub CheckInRegisterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckInRegisterToolStripMenuItem.Click
        Check_in_Register.MdiParent = Me
        Check_in_Register.Show()
        Check_in_Register.BringToFront()
    End Sub

    Private Sub CheckOutRegisterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckOutRegisterToolStripMenuItem.Click
        CheckOut_Register.MdiParent = Me
        CheckOut_Register.Show()
        CheckOut_Register.BringToFront()

    End Sub


    Private Sub btnBooking_Click(sender As Object, e As EventArgs) Handles btnBooking.Click
        Room_Reservaration.MdiParent = Me
        Room_Reservaration.Show()
        Room_Reservaration.BringToFront()
    End Sub

    Private Sub btnBookingRegister_Click(sender As Object, e As EventArgs) Handles btnBookingRegister.Click
        Room_Booking_Register.MdiParent = Me
        Room_Booking_Register.Show()
        Room_Booking_Register.BringToFront()
    End Sub

    Private Sub btnCheckIN_Click(sender As Object, e As EventArgs) Handles btnCheckIN.Click
        Room_Check_In.MdiParent = Me
        Room_Check_In.Show()
        Room_Check_In.BringToFront()
    End Sub

    Private Sub btnCheckOutRegister_Click(sender As Object, e As EventArgs) Handles btnCheckOutRegister.Click
        Room_Checkout.MdiParent = Me
        Room_Checkout.Show()
        Room_Checkout.BringToFront()
    End Sub

    Private Sub btnCheckInRegister_Click(sender As Object, e As EventArgs) Handles btnCheckInRegister.Click
        Check_in_Register.MdiParent = Me
        Check_in_Register.Show()
        Check_in_Register.BringToFront()

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        CheckOut_Register.MdiParent = Me
        CheckOut_Register.Show()
        If Not CheckOut_Register Is Nothing Then
            CheckOut_Register.BringToFront()
        End If
    End Sub

    Private Sub btnItemEntry_Click(sender As Object, e As EventArgs) Handles btnItemEntry.Click
        Items.MdiParent = Me
        Items.Show()
        Items.BringToFront()
    End Sub

    Private Sub btnItemRegister_Click(sender As Object, e As EventArgs) Handles btnItemRegister.Click
        Item_Register.MdiParent = Me
        Item_Register.Show()
        Item_Register.BringToFront()

    End Sub

    Private Sub btnKotEntry_Click(sender As Object, e As EventArgs) Handles btnKotEntry.Click
        KOT.MdiParent = Me
        KOT.Show()
        KOT.BringToFront()

    End Sub

    Private Sub btnKOTRegiter_Click(sender As Object, e As EventArgs) Handles btnKOTRegiter.Click
        KOT_Register.MdiParent = Me
        KOT_Register.Show()
        KOT_Register.BringToFront()
    End Sub

    Private Sub btnFoodBill_Click(sender As Object, e As EventArgs) Handles btnFoodBill.Click
        Food_Bill.MdiParent = Me
        Food_Bill.Show()
        Food_Bill.BringToFront()
    End Sub

    Private Sub btnFoodBillRegister_Click(sender As Object, e As EventArgs) Handles btnFoodBillRegister.Click
        Food_Bill_Register.MdiParent = Me
        Food_Bill_Register.Show()
        Food_Bill_Register.BringToFront()
    End Sub

    Private Sub btnPOS_Click(sender As Object, e As EventArgs) Handles btnPOS.Click
        POS.Show()
        POS.BringToFront()
    End Sub

    Private Sub BtnPOSRegister_Click(sender As Object, e As EventArgs) Handles BtnPOSRegister.Click
        POS_Register.MdiParent = Me
        POS_Register.Show()
        POS_Register.BringToFront()
    End Sub

    Private Sub btnDayBook_Click_1(sender As Object, e As EventArgs) Handles btnDayBook.Click
        Day_book.MdiParent = Me
        Day_book.Show()
        Day_book.BringToFront()
    End Sub

    Private Sub btnLedger_Click(sender As Object, e As EventArgs) Handles btnLedger.Click
        Ledger.MdiParent = Me
        Ledger.Show()
        Ledger.BringToFront()
    End Sub

    Private Sub btnCashBook_Click(sender As Object, e As EventArgs) Handles btnCashBook.Click
        Cash_Bank_Book.MdiParent = Me
        Cash_Bank_Book.Show()
        Cash_Bank_Book.BringToFront()
    End Sub

    Private Sub btnOutStanding_Click(sender As Object, e As EventArgs) Handles btnOutStanding.Click
        OutStanding_Amount_Only.MdiParent = Me
        OutStanding_Amount_Only.Show()
        OutStanding_Amount_Only.BringToFront()
    End Sub

    Private Sub btnPurchase_Click_1(sender As Object, e As EventArgs) Handles btnPurchase.Click
        Purchase.MdiParent = Me
        Purchase.Show()
        Purchase.BringToFront()
     End Sub

    Private Sub btnPurchaseRegister_Click_1(sender As Object, e As EventArgs) Handles btnPurchaseRegister.Click
        Purchase_Register.MdiParent = Me
        Purchase_Register.Show()
        Purchase_Register.BringToFront()
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        RecieptForm.MdiParent = Me
        RecieptForm.Show()
        RecieptForm.BringToFront()
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        PayMentform.MdiParent = Me
        PayMentform.Show()
        PayMentform.BringToFront()
    End Sub

    Private Sub WebcamToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WebcamToolStripMenuItem.Click
        '  Webcam.Show()
    End Sub

    Private Sub RunQueryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RunQueryToolStripMenuItem.Click
        Query_Maker.MdiParent = Me
        Query_Maker.Show()
        Query_Maker.BringToFront()
    End Sub

    Private Sub RoomBookToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RoomBookToolStripMenuItem.Click
        Room_Reservaration.MdiParent = Me
        Room_Reservaration.Show()
        Room_Reservaration.BringToFront()
    End Sub

    Private Sub CheckInToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckInToolStripMenuItem.Click
        Room_Check_In.MdiParent = Me
        Room_Check_In.Show()
        Room_Check_In.BringToFront()
    End Sub

    Private Sub BankEntryToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BankEntryToolStripMenuItem1.Click
        Bank_Entry.MdiParent = Me
        Bank_Entry.Show()
        Bank_Entry.BringToFront()
    End Sub

    Private Sub AccountGroupRegisterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AccountGroupRegisterToolStripMenuItem.Click
        account_group_list.MdiParent = Me
        account_group_list.Show()
        account_group_list.BringToFront()
    End Sub

    Private Sub RoomBookToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RoomBookToolStripMenuItem1.Click
        Room_Reservaration.MdiParent = Me
        Room_Reservaration.Show()
        Room_Reservaration.BringToFront()
    End Sub

    Private Sub KOTRegisterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KOTRegisterToolStripMenuItem.Click
        KOT_Register.MdiParent = Me
        KOT_Register.Show()
        KOT_Register.BringToFront()
    End Sub

    Private Sub POSRegisterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles POSRegisterToolStripMenuItem.Click
        POS_Register.MdiParent = Me
        POS_Register.Show()
        POS_Register.BringToFront()
    End Sub

    Private Sub CashBookToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CashBookToolStripMenuItem.Click
        Cash_Bank_Book.MdiParent = Me
        Cash_Bank_Book.Show()
        Cash_Bank_Book.BringToFront()
    End Sub

 

    Private Sub ItemGroupToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ItemGroupToolStripMenuItem1.Click
        Group_items.MdiParent = Me
        Group_items.Show()
        Group_items.BringToFront()
    End Sub

    Private Sub ItemCompanyToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ItemCompanyToolStripMenuItem1.Click
        Item_Company.MdiParent = Me
        Item_Company.Show()
        Item_Company.BringToFront()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Tax_Setting.MdiParent = Me
        Tax_Setting.Show()
        Tax_Setting.BringToFront()
    End Sub

    Private Sub LoanTypeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoanTypeToolStripMenuItem.Click
        Taxation.MdiParent = Me
        Taxation.Show()
        Taxation.BringToFront()
    End Sub

    Private Sub ReArrangeFoodBillsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReArrangeFoodBillsToolStripMenuItem.Click
        Rearrange_Invoice_No.MdiParent = Me
        Rearrange_Invoice_No.Show()
        Rearrange_Invoice_No.BringToFront()
    End Sub


    Private Sub NewReciepeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewReciepeToolStripMenuItem.Click
        Receipe_Master.MdiParent = Me
        Receipe_Master.Show()
        Receipe_Master.BringToFront()
    End Sub

    Private Sub ReciepeRegisterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReciepeRegisterToolStripMenuItem.Click
        Receipe_Register.MdiParent = Me
        Receipe_Register.Show()
        Receipe_Register.BringToFront()
    End Sub

    Private Sub ProductionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductionToolStripMenuItem.Click
        Production.MdiParent = Me
        Production.Show()
        Production.BringToFront()
    End Sub

    Private Sub ProductionRegisterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductionRegisterToolStripMenuItem.Click
        Production_Register.MdiParent = Me
        Production_Register.Show()
        Production_Register.BringToFront()
    End Sub

    Private Sub StockStatusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockStatusToolStripMenuItem.Click
        Stock_Status.MdiParent = Me
        Stock_Status.Show()
        Stock_Status.BringToFront()
    End Sub

    Private Sub ItemWiseStockToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ItemWiseStockToolStripMenuItem.Click
        Item_Wise_Stock.MdiParent = Me
        Item_Wise_Stock.Show()
        Item_Wise_Stock.BringToFront()
    End Sub

End Class