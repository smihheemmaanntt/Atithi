Imports System.Management
Imports System.Text
Imports System.Configuration
Imports System.Xml
Imports System.IO
Imports System.Data.SQLite

Public Class CompanyList

    Dim rs As New Resizer
    Dim root As String = Application.StartupPath
    ' Public Shared filepath As String = String.Empty
    Public newconnection As String = ""
    Private Sub CompanyList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rowColums() : getCompanies()
        rs.FindAllControls(Me)
    End Sub
    Public Sub rowColums()
        dg1.ColumnCount = 8
        dg1.Columns(0).Name = "ID" : dg1.Columns(0).Visible = False
        dg1.Columns(1).Name = "Company Name" : dg1.Columns(1).Width = 300
        dg1.Columns(2).Name = "Address" : dg1.Columns(2).Width = 280
        dg1.Columns(3).Name = "City" : dg1.Columns(3).Width = 100
        dg1.Columns(4).Name = "Finacial Year Start" : dg1.Columns(4).Width = 100
        dg1.Columns(5).Name = "Finacial Year End" : dg1.Columns(5).Width = 100
        dg1.Columns(6).Name = "FYID" : dg1.Columns(6).Visible = False
        dg1.Columns(7).Name = "DbPath" : dg1.Columns(7).Visible = False
        ' retrive()
    End Sub
    Public Sub getCompanies()
        dg1.Rows.Clear()
        Dim i As Integer = 1 ' NewCompanies
        For Each sDir In Directory.GetDirectories(root, "Data", SearchOption.AllDirectories)
            For Each FilePath In Directory.GetFiles(sDir, "*data*.db", SearchOption.AllDirectories)
                Application.DoEvents()
                Dim detailedfile As New IO.FileInfo(FilePath)
                Dim dt As New DataTable
                Dim cmdText As String = "Select * from Company"
                Dim Connectionstring As String = "Data Source=|DataDirectory|" & FilePath.ToString & ";Version=3;New=True;Compress=True;synchronous=ON;"
                Dim con As New SQLite.SQLiteConnection(Connectionstring)
                Dim ad As New SQLiteDataAdapter(cmdText, con)
                ad.Fill(dt)
                If dt.Rows.Count > 0 Then
                    dg1.Rows.Add()
                    With dg1.Rows(i - 1)
                        .Cells(0).Value = dt.Rows(0)("id").ToString()
                        .Cells(1).Value = dt.Rows(0)("CompanyName").ToString()
                        .Cells(2).Value = dt.Rows(0)("Address").ToString()
                        .Cells(3).Value = dt.Rows(0)("City").ToString()
                        .Cells(6).Value = dt.Rows(0)("id").ToString()
                        .Cells(4).Value = CDate(dt.Rows(0)("YearStart")).ToString("dd-MM-yyyy")
                        .Cells(5).Value = CDate(dt.Rows(0)("YearEnd")).ToString("dd-MM-yyyy")
                        .Cells(7).Value = FilePath.ToString
                    End With
                    i = i + 1
                End If
                '  dg1.Rows.Add("", detailedfile.Name, FilePath)
            Next
        Next
    End Sub

    Private Sub dg1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg1.CellDoubleClick
        If dg1.SelectedRows.Count = 0 Then Exit Sub
        '   If clsFun.CheckIfColumnExists("Company", "OrganizationID") = False Then updateCompanytbl()
        '  If clsFun.CheckIfColumnExists("Transaction2", "CrateAccountID") = False Then updateTransaction2()
        CompanyInfo()
        Login.MdiParent = ShowCompanies
        Login.Show()
        If Not Login Is Nothing Then
            Login.BringToFront()
        End If
    End Sub

    Private Sub dg1_KeyDown(sender As Object, e As KeyEventArgs) Handles dg1.KeyDown
        If e.KeyCode = Keys.Enter Then
            'If clsFun.CheckIfColumnExists("Company", "OrganizationID") = False Then
            '    updateCompanytbl()
            'End If
            'If clsFun.CheckIfColumnExists("Transaction2", "CrateAccountID") = False Then
            '    updateTransaction2()
            'End If
            CompanyInfo()
            Login.MdiParent = ShowCompanies
            Login.Show()
            If Not Login Is Nothing Then
                Login.BringToFront()
            End If
            e.SuppressKeyPress = True
            ' clsFun.GetConnection()
        End If
    End Sub
    Public Sub CompanyInfo()
        '    clsFun.GetConnection()
        sCompCode = dg1.SelectedRows(0).Cells(0).Value
        compname = dg1.SelectedRows(0).Cells(1).Value
        ' compnameHindi = dg1.SelectedRows(0).Cells(2).Value
        compnameHindi = clsFun.ExecScalarStr("Select PrintOtherName from Company where id=" & dg1.SelectedRows(0).Cells(0).Value & "")
        Mob1 = clsFun.ExecScalarStr("Select MobileNo1 from Company where id=" & dg1.SelectedRows(0).Cells(0).Value & "")
        Mob2 = clsFun.ExecScalarStr("Select MobileNo2 from Company where id=" & dg1.SelectedRows(0).Cells(0).Value & "")
        Address = clsFun.ExecScalarStr("Select Address from Company where id=" & dg1.SelectedRows(0).Cells(0).Value & "")
        AddressHindi = clsFun.ExecScalarStr("Select PrintOtheraddress from Company where id=" & dg1.SelectedRows(0).Cells(0).Value & "")
        City = clsFun.ExecScalarStr("Select City from Company where id=" & dg1.SelectedRows(0).Cells(0).Value & "")
        CityHindi = clsFun.ExecScalarStr("Select PrintOtherCity from Company where id=" & dg1.SelectedRows(0).Cells(0).Value & "")
        StateName = clsFun.ExecScalarStr("Select State from Company where id=" & Val(dg1.SelectedRows(0).Cells(0).Value) & "")
        StateHindi = clsFun.ExecScalarStr("Select PrintOtherState from Company where id=" & dg1.SelectedRows(0).Cells(0).Value & "")
        Fax = clsFun.ExecScalarStr("Select FaxNo from Company where id=" & dg1.SelectedRows(0).Cells(0).Value & "")
        Email = clsFun.ExecScalarStr("Select EmailID from Company where id=" & dg1.SelectedRows(0).Cells(0).Value & "")
        Phone = clsFun.ExecScalarStr("Select PhoneNo from Company where id=" & dg1.SelectedRows(0).Cells(0).Value & "")
        Website = clsFun.ExecScalarStr("Select Website from Company where id=" & dg1.SelectedRows(0).Cells(0).Value & "")
        Gstn = clsFun.ExecScalarStr("Select Gstn from Company where id=" & dg1.SelectedRows(0).Cells(0).Value & "")
        DealsIN = clsFun.ExecScalarStr("Select DealsIN from Company where id=" & dg1.SelectedRows(0).Cells(0).Value & "")
        Registration = clsFun.ExecScalarStr("Select RegistrationNo from Company where id=" & dg1.SelectedRows(0).Cells(0).Value & "")
        Pan = clsFun.ExecScalarStr("Select PanNo from Company where id=" & dg1.SelectedRows(0).Cells(0).Value & "")
        Marka = clsFun.ExecScalarStr("Select Marka from Company where id=" & dg1.SelectedRows(0).Cells(0).Value & "")
        other = clsFun.ExecScalarStr("Select Other from Company where id=" & dg1.SelectedRows(0).Cells(0).Value & "")
        'clsFun.CloseConnection()
    End Sub
    '    Private Sub updateCompanytbl()
    '        Dim sql As String = "PRAGMA foreign_keys = 0; CREATE TABLE sqlitestudio_temp_table  AS  SELECT  *  FROM Company; DROP TABLE Company;CREATE TABLE Company ( ID                NUMERIC,    CompanyName       TEXT,    PrintOtherName    TEXT,    Address           TEXT,    PrintOtheraddress TEXT,    City              TEXT,    PrintOtherCity    TEXT,    State             TEXT,    PrintOtherState   TEXT,    MobileNo1         TEXT,    MobileNo2         TEXT,    PhoneNo           TEXT,    FaxNo             TEXT,    EmailID           TEXT,    Website           TEXT,    GSTN              TEXT,    DealsIN           TEXT,    RegistrationNo    TEXT,    PanNo             TEXT,    Marka             TEXT,    Other             TEXT,    Logo              BLOB,    YearStart         DATE,    Yearend           DATE,    CompData          TEXT,    tag               TEXT,    OrganizationID    INTEGER,    Password          TEXT,    Autosync          TEXT);" & _
    '                             "INSERT INTO Company ( ID, CompanyName, PrintOtherName, Address, PrintOtheraddress,                      City, PrintOtherCity,  State,  PrintOtherState,   MobileNo1,  MobileNo2,  PhoneNo, FaxNo,                     EmailID,  Website,   GSTN, DealsIN, RegistrationNo, PanNo, Marka, Other,  Logo, YearStart,                        Yearend, CompData, tag )  SELECT ID,  CompanyName,  PrintOtherName,   Address,                     PrintOtheraddress,   City, PrintOtherCity,  State, PrintOtherState, MobileNo1, MobileNo2,                    PhoneNo, FaxNo,  EmailID, Website,  GSTN,  DealsIN,RegistrationNo,PanNo,  Marka,                           Other,  Logo, YearStart,  Yearend,  CompData, tag  FROM sqlitestudio_temp_table;DROP TABLE sqlitestudio_temp_table;PRAGMA foreign_keys = 1;"
    '        clsFun.ExecNonQuery(sql)
    '    End Sub
    '    Private Sub updateTransaction2()
    '        Dim sql As String = "PRAGMA foreign_keys = 0;CREATE TABLE sqlitestudio_temp_table AS SELECT *   FROM Transaction2;DROP TABLE Transaction2; " & _
    '"CREATE TABLE Transaction2 ( ID INTEGER PRIMARY KEY AUTOINCREMENT, EntryDate DATETIME DEFAULT ('strftime(''%d-%m-%Y'')'), VoucherID INTEGER, TransType TEXT, BillNo   TEXT, SallerID  INTEGER, SallerName  TEXT, AccountID INTEGER, AccountName  TEXT, OtherAccountName TEXT, ItemID   INTEGER, ItemName  TEXT, OtherItemName TEXT, Cut   DECIMAL, Lot   TEXT, Nug   DECIMAL, Weight   DECIMAL, Rate  DECIMAL, SRate  DECIMAL, Per   TEXT, Amount   DECIMAL, Charges  DECIMAL, TotalAmount  DECIMAL, SallerAmt DECIMAL, CommPer  DECIMAL, CommAmt  DECIMAL, MPer  DECIMAL, MAmt  DECIMAL, RdfPer   DECIMAL, RdfAmt   DECIMAL, Tare  DECIMAL, TareAmt  DECIMAL, labour   DECIMAL, LabourAmt DECIMAL, MaintainCrate TEXT, CrateID  DECIMAL, Cratemarka  TEXT, CrateQty  DECIMAL, PurchaseTypename TEXT, PurchaseID  INTEGER, RoundOff  DECIMAL, CrateAccountID  INTEGER, CrateAccountName TEXT);" & _
    '"INSERT INTO Transaction2 ( ID, EntryDate, VoucherID, TransType, BillNo, SallerID, SallerName, AccountID, AccountName, OtherAccountName, ItemID, ItemName, OtherItemName, Cut, Lot, Nug, Weight, Rate, SRate, Per, Amount, Charges, TotalAmount, SallerAmt, CommPer, CommAmt, MPer, MAmt, RdfPer, RdfAmt, Tare, TareAmt, labour, LabourAmt, MaintainCrate, CrateID, Cratemarka, CrateQty, PurchaseTypename, PurchaseID) SELECT ID, EntryDate, VoucherID, TransType, BillNo, SallerID, SallerName, AccountID, AccountName, OtherAccountName, ItemID, ItemName, OtherItemName, Cut, Lot, Nug, Weight, Rate, SRate, Per, Amount, Charges, TotalAmount, SallerAmt, CommPer, CommAmt, MPer, MAmt, RdfPer, RdfAmt, Tare, TareAmt, labour, LabourAmt, MaintainCrate, CrateID, Cratemarka, CrateQty, PurchaseTypename, PurchaseID  FROM sqlitestudio_temp_table;" & _
    '"DROP TABLE sqlitestudio_temp_table;DROP VIEW Stock_Sale_Report;" & _
    '"CREATE VIEW Stock_Sale_Report AS SELECT v.VehicleNo AS VehicleNo,   V.id AS VoucherID,   V.entryDate,   v.billNo AS BillNo,   v.SallerID AS SallerID,   v.sallerName AS SallerName,   t.ItemName AS ItemName,   t.Lot AS lot,   t.accountName AS AccountName,   t.nug AS nug,   t.Weight AS weight,   t.rate AS rate,   t.per AS per,   t.Amount AS amount,   t.Charges AS charges,   t.TotalAmount AS totalAmount,   v.TransType AS transtype  FROM Vouchers v   INNER JOIN   Transaction2 t ON v.id = t.VoucherID;PRAGMA foreign_keys = 1; "
    '        clsFun.ExecNonQuery(sql)
    '    End Sub
    Private Sub dg1_SelectionChanged(sender As Object, e As EventArgs) Handles dg1.SelectionChanged, dg1.GotFocus
        If dg1.RowCount = 0 Or dg1.SelectedRows.Count = 0 Then Exit Sub
        txtPath.Text = dg1.SelectedRows(0).Cells(7).Value
        GlobalData.ConnectionPath = txtPath.Text
    End Sub

    Private Sub BtnRetrive_Click(sender As Object, e As EventArgs) Handles BtnRetrive.Click
        getCompanies()
    End Sub

    Private Sub CompanyList_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        rs.ResizeAllControls(Me)
    End Sub
End Class