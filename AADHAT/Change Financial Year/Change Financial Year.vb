Imports System.IO
Imports System.Text
Imports System.Configuration
Imports System.Xml
Public Class Change_Financial_Year
    Dim data As String = String.Empty
    Private Sub Change_Financial_Year_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub Change_Financial_Year_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        Me.Top = 130 : Me.Left = 84
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.BackColor = Color.GhostWhite
        txtAccountID.Text = Val(CompanyList.dg1.SelectedRows(0).Cells(0).Value)
        txtAccount.Text = CompanyList.dg1.SelectedRows(0).Cells(1).Value
        mskCurrFromDate.Text = CompanyList.dg1.SelectedRows(0).Cells(4).Value
        MskCurrToDate.Text = CompanyList.dg1.SelectedRows(0).Cells(5).Value
        txtCurrentPath.Text = CompanyList.dg1.SelectedRows(0).Cells(7).Value
        mskNewFromDate.Text = CDate(mskCurrFromDate.Text).AddYears(1).ToString("dd-MM-yyyy")
        mskNewtoDate.Text = CDate(MskCurrToDate.Text).AddYears(1).ToString("dd-MM-yyyy")
        mskNewFromDate.Focus() : Me.KeyPreview = True
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Public Sub CreateDb(ByVal dbname As String, ByVal compid As Integer)
        Dim CopyDestPath As String = String.Empty
        Dim tmpDataPath As String = String.Empty
        Dim i As Integer = 0
        directoryName = IO.Path.GetDirectoryName(GlobalData.ConnectionPath).Split(Path.DirectorySeparatorChar).Last()
        ' If directoryName = "Data" Then directoryName = ""
        CopyDestPath = "Data\1000"
        tmpDataPath = "1000"
        For i = 1 To 50
            If Directory.Exists(Application.StartupPath & "\" & CopyDestPath & i) = False Then
                CompData = CopyDestPath & i & "\"
                tmpDataPath = tmpDataPath & i
                tmpDataPath = tmpDataPath & "\Data.db"
                Directory.CreateDirectory(Application.StartupPath & "\" & CopyDestPath & i)
                CopyDestPath = (Application.StartupPath & "\" & CopyDestPath & i).ToString()
                Exit For
            End If
        Next

        Dim ssql As String = ""
        'ssql = "INSERT INTO Company (CompanyName,PrintOtherName,Address,PrintOtheraddress,City,PrintOtherCity,State,PrintOtherState,MobileNo1,MobileNo2,PhoneNo,FaxNo,EmailID,Website,GSTN,DealsIN,RegistrationNo,PanNo," & _
        '    " Marka,Other,Logo,YearStart,Yearend,CompData,tag) " & _
        '    " Select CompanyName,PrintOtherName,Address,PrintOtheraddress,City,PrintOtherCity,State,PrintOtherState,MobileNo1,MobileNo2,PhoneNo,FaxNo,EmailID,Website,GSTN,DealsIN,RegistrationNo,PanNo, " & _
        '    " Marka,Other,Logo,'" & CDate(mskNewFromDate.Text).ToString("yyyy-MM-dd") & "','" & CDate(mskNewtoDate.Text).ToString("yyyy-MM-dd") & "' ,'" & tmpDataPath & "',tag FROM Company WHERE ID = " & compid & ""
        '' GlobalData.ConnectionPath = CopyDestPath
        'clsFun.ExecNonQuery(ssql)
        CopyDirectory(Application.StartupPath & "\Data\" & directoryName & "\data.db", CopyDestPath)
        GlobalData.ConnectionPath = CopyDestPath & "\data.db"
        AcBal() : btnChangeYear.Text = "Successful"
    End Sub
    Private Shared Sub CopyDirectory(ByVal sourcePath As String, ByVal destPath As String)
        'If Not Directory.Exists(destPath) Then
        '    Directory.CreateDirectory(destPath)
        'End If
        For Each file__1 As String In Directory.GetFiles(Path.GetDirectoryName(sourcePath))
            Dim dest As String = Path.Combine(destPath, Path.GetFileName(file__1))
            File.Copy(file__1, dest)
            CompData = CompData & file__1
        Next

        For Each folder As String In Directory.GetDirectories(Path.GetDirectoryName(sourcePath))
            Dim dest As String = Path.Combine(destPath, Path.GetFileName(folder))
            CopyDirectory(folder, dest)
        Next

        ''Conection change
    End Sub

    Private Sub AcBal()
        'lblStatus.Text = "Importing Balancing From Accounts..."
        Dim i As Integer
        Dim dt As New DataTable
        Dim dt1 As New DataTable
        Dim dt2 As New DataTable
        Dim opbal As String = ""
        Dim ClBal As String = ""
        ''  clsFun.ExecNonQuery("Update Accounts set OpBal=0")
        Dim ssql As String = "" : ProgressBar1.Visible = True
        '' clsFun.GetConnection()

        ' GlobalData.ConnectionPath = CopyDestPath & "\data.db"
        dt = clsFun.ExecDataTable("Select OpBal,id,dc FROM Accounts")
        For i = 0 To dt.Rows.Count - 1
            Application.DoEvents()
            ProgressBar1.Maximum = dt.Rows.Count
            lblStatus.Text = Format(Val(i + 1) * 100 / dt.Rows.Count, "0.00") & " %"
            ProgressBar1.Value = i
            opbal = dt.Rows(i)("opbal").ToString()
            Dim tmpamtdr As String = clsFun.ExecScalarStr("Select sum(Amount) as tot from Ledger where Dc='D' and accountID=" & Val(dt.Rows(i)("Id").ToString()) & "")
            Dim tmpamtcr As String = clsFun.ExecScalarStr("Select sum(Amount) as tot from Ledger where Dc='C' and accountID=" & Val(dt.Rows(i)("Id").ToString()) & "")
            Dim drcr As String = clsFun.ExecScalarStr(" Select Dc FROM Accounts WHERE ID= " & Val(dt.Rows(i)("Id").ToString()) & "")
            If drcr = "Dr" Then
                tmpamtdr = Val(opbal) + Val(tmpamtdr)
            Else
                tmpamtcr = Val(opbal) + Val(tmpamtcr)
            End If
            Dim tmpamt As String = IIf(Val(tmpamtdr) > Val(tmpamtcr), Val(tmpamtdr) - Val(tmpamtcr), Val(tmpamtcr) - Val(tmpamtdr)) '- Val(opbal)
            If drcr = "Cr" Then
                opbal = Math.Abs(Val(opbal)) & " Cr"
            Else
                opbal = Math.Abs(Val(opbal)) & " Dr"
            End If
            Dim cntbal As Integer = 0
            cntbal = clsFun.ExecScalarInt("Select count(*) from ledger where  accountid=" & Val(dt.Rows(i)("Id").ToString()) & "")
            If cntbal = 0 Then
                opbal = Math.Abs(Val(opbal)) & "," & dt.Rows(0)("Dc").ToString()
                ssql = ssql & "Update Accounts set opbal=" & opbal.Split(",")(0) & " where id=" & dt.Rows(i)("id").ToString() & ";"
            Else
                If Val(tmpamtcr) > Val(tmpamtdr) Then
                    opbal = Math.Abs(Val(tmpamt)) & ",Cr"

                Else
                    opbal = Math.Abs(Val(tmpamt)) & ",Dr"
                End If
                ssql = ssql & "Update Accounts set opbal=" & opbal.Split(",")(0) & " ,DC='" & opbal.Split(",")(1) & "' where id=" & dt.Rows(i)("id").ToString() & ";"
            End If
        Next
        Dim a As Integer = clsFun.ExecNonQuery(ssql, True)

        If a > 0 Then
            ssql = ""
            Dim Sql As String = "CREATE TABLE TempKOT AS SELECT * FROM KOT;Delete from KOT; Delete from sqlite_sequence where name='KOT'"
            dt = clsFun.ExecDataTable(Sql)
            Sql = "Select * From KOTTrans Where Paid is Null"
        End If

        'If a > 0 Then
        '    ssql = ""
        '    Dim sql As String = "SELECT I.ID as ItemID,I.ItemName as ItemName,ifnull(Sum(OpStockMain),0) +ifnull(Sum(OpStockalt)/cast(Conversion as real),0) as OpQty,(Select ifnull(Sum(Qty),0)+ifnull(Sum(FreeQty),0) from Trans1 Where ItemID=I.ID and TransType In ('Purchase','Credit Note') and EntryDate<='" & CDate(MskCurrToDate.Text).ToString("yyyy-MM-dd") & "') as PurchaseQty," & _
        '            "(Select ifnull(Sum(Qty),0)+ifnull(Sum(FreeQty),0) from Trans1 Where ItemID=I.ID and TransType In ('Sale','Debit Note') and EntryDate<='" & CDate(MskCurrToDate.Text).ToString("yyyy-MM-dd") & "') as SoldQty," & _
        '            " (ifnull(Sum(OpStockMain),0)+ifnull(Sum(OpStockalt)/cast(Conversion as real),0)+(Select ifnull(Sum(Qty),0)+ifnull(Sum(FreeQty),0) from Trans1 Where ItemID=I.ID and TransType In ('Purchase','Credit Note')and EntryDate<='" & CDate(MskCurrToDate.Text).ToString("yyyy-MM-dd") & "'))" & _
        '            "-(Select ifnull(Sum(Qty),0)+ifnull(Sum(FreeQty),0) from Trans1 Where ItemID=I.ID and TransType In ('Sale','Debit Note') and EntryDate<='" & CDate(MskCurrToDate.Text).ToString("yyyy-MM-dd") & "') " & _
        '            " as RestQty FROM Items AS I Inner JOIN Batch AS B ON B.ItemID=I.ID " & condtion & " Group By ItemID "
        '    dt = clsFun.ExecDataTable(sql)
        '    For i = 0 To dt.Rows.Count - 1
        '        Dim Conversion As String = clsFun.ExecScalarStr("Select Conversion From items Where ID=" & dt.Rows(i)("ItemID").ToString() & "")
        '        If Val(Conversion) > 0 Then
        '            Dim totqty As Decimal = Format(Val(dt.Rows(i)("RestQty").ToString()), "0.00")
        '            Dim mainQty As Decimal = Math.Truncate(totqty)
        '            Dim altqty As Decimal = Math.Round(Math.Abs(totqty - mainQty) * Val(Conversion), 0)
        '            ssql = ssql & "Update Batch set OpStockMain='" & mainQty & "' ,OpStockAlt='" & altqty & "'  where ItemID=" & Val(dt.Rows(i)("ItemID").ToString()) & ";"
        '        Else
        '            ssql = ssql & "Update Batch set OpStockMain='" & dt.Rows(i)("RestQty").ToString() & "' where ItemID=" & Val(dt.Rows(i)("ItemID").ToString()) & ";"
        '        End If
        '    Next
        'End If
        'Dim a2 As Integer = clsFun.ExecNonQuery(ssql, True)

        If a > 0 Then
            ssql = ""
            ssql = "delete from Vouchers; delete from sqlite_sequence where name='Vouchers';delete from Ledger; delete from sqlite_sequence where name='Ledger';delete from Trans1; delete from sqlite_sequence where name='Trans1';" &
                   "delete from ChargesTrans;delete from sqlite_sequence where name='ChargesTrans'; delete from Licence;delete from TaxDetails; delete from sqlite_sequence where name='TaxDetails';" &
                   " Update Company set OrganizationID='',Password='',Autosync='N',YearStart='" & CDate(mskNewFromDate.Text).ToString("yyyy-MM-dd") & "',YearEnd='" & CDate(mskNewtoDate.Text).ToString("yyyy-MM-dd") & "',CompData='" & tmpDataPath & "';"
            Dim a1 As Integer = clsFun.ExecNonQuery(ssql, True)
            clsFun.ExecNonQuery("Vacuum;")
            If a1 > 0 Then MsgBox("Financial Year Changed Successfully...") : CompanyList.BtnRetrive.PerformClick() : Me.Close()
        End If
    End Sub

    Private Shared Sub updateConfigFile(con As String)
        Dim XmlDoc As New XmlDocument()
        XmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile)
        For Each xElement As XmlElement In XmlDoc.DocumentElement
            If xElement.Name = "connectionStrings" Then
                xElement.FirstChild.Attributes(1).Value = con
            End If
        Next
        XmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile)
    End Sub
    Private Shared Sub changeCompany(ByVal Data As String)
        Try
            Dim Con As New StringBuilder("")
            Con.Append("Data Source=|DataDirectory|\")
            Con.Append(Data & ";Version=3;New=True;Compress=True;synchronous=ON;")
            'Con.Append(Data & ";Version=3;Password=smi3933;")
            Dim strCon As String = Con.ToString()
            updateConfigFile(strCon)
            Dim Db As New SQLite.SQLiteConnection()
            ConfigurationManager.RefreshSection("connectionStrings")
            Db.ConnectionString = ConfigurationManager.ConnectionStrings("Con").ConnectionString
            clsFun.ConStr = Db.ConnectionString
        Catch E As Exception
            MessageBox.Show(ConfigurationManager.ConnectionStrings("con").ToString() + ".This is invalid connection", "Incorrect server/Database")
        End Try
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnChangeYear.Click
        If mskNewFromDate.Text = mskNewtoDate.Text Then MsgBox("Finacial Year End Date Must Be Diffrence Finacial Year Start Date", MsgBoxStyle.Critical, "Check Dates...")
        Dim tmpid As Integer = txtAccountID.Text
        Dim data As String = txtCurrentPath.Text
        If MessageBox.Show("Are you Sure want to Change Fiancial Year?", "Change Finacial Year", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            lblStatus.Visible = True ' lblStatus.Text = "New Database Created Successfully..."
            btnChangeYear.Text = "Please Wait" : CreateDb(data, tmpid)
            ProgressBar1.Visible = False : lblStatus.Visible = False
        Else
            Exit Sub
        End If
        'BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub mskNewFromDate_GotFocus(sender As Object, e As EventArgs) Handles mskNewFromDate.GotFocus
        mskNewFromDate.SelectionStart = 0 : mskNewFromDate.SelectionLength = Len(mskNewFromDate.Text)
    End Sub

    Private Sub mskNewFromDate_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles mskNewFromDate.MaskInputRejected

    End Sub

    Private Sub mskNewFromDate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mskNewFromDate.Validating
        mskNewFromDate.Text = clsFun.DateValidate(mskNewFromDate.Text)
    End Sub

    Private Sub mskNewtoDate_GotFocus(sender As Object, e As EventArgs) Handles mskNewtoDate.GotFocus
        mskNewtoDate.SelectionStart = 0 : mskNewtoDate.SelectionLength = Len(mskNewtoDate.Text)
    End Sub

    Private Sub mskNewtoDate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mskNewtoDate.Validating
        mskNewtoDate.Text = clsFun.DateValidate(mskNewtoDate.Text)
    End Sub

    Private Sub mskNewFromDate_KeyDown(sender As Object, e As KeyEventArgs) Handles mskNewFromDate.KeyDown, mskNewtoDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        Else
            Exit Sub
        End If
        e.SuppressKeyPress = True
        Select Case e.KeyCode
            Case Keys.End
                e.Handled = True
                btnChangeYear.Focus()
        End Select
    End Sub
End Class