Public Class Bank_Entry
    Dim VchId As Integer
    Dim bankcharges As String
    Private Sub Bank_Entry_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub
    Private Sub Bank_Entry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterParent
        Me.Top = 0.5
        Me.Left = 179
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.BackColor = Color.Moccasin
        ' clsFun.FillDropDownList(CBBankAccount, "Select * From Accounts where groupid in(12)", "AccountName", "Id", "")
        ' clsFun.FillDropDownList(CBAccount, "Select * From Accounts", "AccountName", "Id", "")
        MskEntryDate.Text = Date.Today.ToString("dd-MM-yyyy")
        mskChequeDate.Text = Date.Today.ToString("dd-MM-yyyy")
        mskChequeDate.Text = MskEntryDate.Text
        CbEntryType.SelectedIndex = 0
        rowColums() : VNumber()
    End Sub
    Private Sub VNumber()
        Vno = clsFun.ExecScalarInt("SELECT Count(ID) AS NumberOfProducts FROM Vouchers Where BankEntry='Bank Entry'")
        txtBillNo.Text = Vno + 1
    End Sub
    Private Sub ModeColums()
        dgMode.ColumnCount = 2
        dgMode.Columns(0).Name = "ID" : dgMode.Columns(0).Visible = False
        dgMode.Columns(1).Name = "Mode Name" : dgMode.Columns(1).Width = 370
        RetriveMode()
    End Sub
    Private Sub RetriveMode(Optional ByVal condtion As String = "")
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("Select * from Accounts where groupid in(12) " & condtion & " order by AccountName")
        Try
            If dt.Rows.Count > 0 Then
                dgMode.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dgMode.Rows.Add()
                    With dgMode.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("id").ToString()
                        .Cells(1).Value = dt.Rows(i)("AccountName").ToString()
                    End With
                Next

            End If
            dt.Dispose()

        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "Teller")
        End Try
    End Sub
    Private Sub AccountRowColumns()
        DgAccountSearch.ColumnCount = 3
        DgAccountSearch.Columns(0).Name = "ID" : DgAccountSearch.Columns(0).Visible = False
        DgAccountSearch.Columns(1).Name = "Account Name" : DgAccountSearch.Columns(1).Width = 300
        DgAccountSearch.Columns(2).Name = "City" : DgAccountSearch.Columns(2).Width = 100
        retriveAccounts()
    End Sub
    Private Sub retriveAccounts(Optional ByVal condtion As String = "")
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("Select * From Accounts " & condtion & " order by AccountName")
        Try
            If dt.Rows.Count > 0 Then
                DgAccountSearch.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    DgAccountSearch.Rows.Add()
                    With DgAccountSearch.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("id").ToString()
                        .Cells(1).Value = dt.Rows(i)("AccountName").ToString()
                        .Cells(2).Value = dt.Rows(i)("City").ToString()
                    End With
                    ' Dg1.Rows.Add()
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "Aadhat")
        End Try
    End Sub
    Private Sub dgMode_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgMode.CellClick
        txtMode.Clear()
        txtModeID.Clear()
        txtModeID.Text = dgMode.SelectedRows(0).Cells(0).Value
        txtMode.Text = dgMode.SelectedRows(0).Cells(1).Value
        dgMode.Visible = False
        txtRemark.Focus()
    End Sub

    Private Sub dgMode_KeyDown(sender As Object, e As KeyEventArgs) Handles dgMode.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtMode.Clear()
            txtModeID.Clear()
            If dgMode.RowCount = 0 Then Exit Sub
            If dgMode.SelectedRows.Count = 0 Then Exit Sub
            txtModeID.Text = dgMode.SelectedRows(0).Cells(0).Value
            txtMode.Text = dgMode.SelectedRows(0).Cells(1).Value
            dgMode.Visible = False
            txtRemark.Focus()
        End If
        If e.KeyCode = Keys.F3 Then
            CreateAccount.MdiParent = MainScreenForm
            CreateAccount.Show()
            '  clsFun.FillDropDownList(CreateAccount.cbGroup, "SELECT ID,GroupName FROM AccountGroup Where ID=12", "GroupName", "ID", "")
            If Not CreateAccount Is Nothing Then
                CreateAccount.BringToFront()
            End If
        End If
        If e.KeyCode = Keys.F1 Then
            If dgMode.SelectedRows.Count = 0 Then Exit Sub
            Dim tmpAcID As Integer = dgMode.SelectedRows(0).Cells(0).Value
            CreateAccount.MdiParent = MainScreenForm
            CreateAccount.Show()
            CreateAccount.FillContros(tmpAcID)
            If Not CreateAccount Is Nothing Then
                CreateAccount.BringToFront()
            End If
        End If
        If e.KeyCode = Keys.Back Then txtMode.Focus()
    End Sub
    Private Sub txtAccount_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAccount.KeyDown
        If e.KeyCode = Keys.Down Then DgAccountSearch.Focus()
        If e.KeyCode = Keys.F3 Then
            CreateAccount.MdiParent = MainScreenForm
            CreateAccount.Show()
            'clsFun.FillDropDownList(CreateAccount.cbGroup, "SELECT ID,GroupName FROM AccountGroup", "GroupName", "ID", "")
            If Not CreateAccount Is Nothing Then
                CreateAccount.BringToFront()
            End If
        End If
        If e.KeyCode = Keys.F1 Then
            If DgAccountSearch.SelectedRows.Count = 0 Then Exit Sub
            Dim tmpAcID As Integer = DgAccountSearch.SelectedRows(0).Cells(0).Value
            CreateAccount.MdiParent = MainScreenForm
            CreateAccount.Show()
            CreateAccount.FillContros(tmpAcID)
            If Not CreateAccount Is Nothing Then
                CreateAccount.BringToFront()
            End If
        End If
    End Sub
    Private Sub DgAccountSearch_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgAccountSearch.CellClick
        txtAccount.Clear()
        txtAccountID.Clear()
        txtAccountID.Text = DgAccountSearch.SelectedRows(0).Cells(0).Value
        txtAccount.Text = DgAccountSearch.SelectedRows(0).Cells(1).Value
        DgAccountSearch.Visible = False
        txtAmount.Focus()
    End Sub
    Private Sub DgAccountSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles DgAccountSearch.KeyDown
        If e.KeyCode = Keys.Down Then DgAccountSearch.Focus()
        If e.KeyCode = Keys.F3 Then
            CreateAccount.MdiParent = MainScreenForm
            CreateAccount.Show()
            ' clsFun.FillDropDownList(CreateAccount.cbGroup, "SELECT ID,GroupName FROM AccountGroup", "GroupName", "ID", "")
            If Not CreateAccount Is Nothing Then
                CreateAccount.BringToFront()
            End If
        End If
        If e.KeyCode = Keys.F1 Then
            If DgAccountSearch.SelectedRows.Count = 0 Then Exit Sub
            Dim tmpAcID As Integer = DgAccountSearch.SelectedRows(0).Cells(0).Value
            CreateAccount.MdiParent = MainScreenForm
            CreateAccount.Show()
            CreateAccount.FillContros(tmpAcID)
            If Not CreateAccount Is Nothing Then
                CreateAccount.BringToFront()
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            txtAccount.Clear()
            txtAccountID.Clear()
            txtAccountID.Text = DgAccountSearch.SelectedRows(0).Cells(0).Value
            txtAccount.Text = DgAccountSearch.SelectedRows(0).Cells(1).Value
            DgAccountSearch.Visible = False
            txtAmount.Focus()
            e.SuppressKeyPress = True
        End If
        If e.KeyCode = Keys.Back Then txtAccount.Focus()
    End Sub
    Private Sub txtItem_KeyUp(sender As Object, e As KeyEventArgs) Handles txtMode.KeyUp
        ModeColums()
        If txtMode.Text.Trim() <> "" Then
            dgMode.Visible = True
            RetriveMode(" and upper(AccountName) Like upper('%" & txtMode.Text.Trim() & "%')")
        End If
        If e.KeyCode = Keys.Escape Then dgMode.Visible = False
    End Sub

    Private Sub txtItem_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMode.KeyPress
        ModeColums()
        dgMode.BringToFront()
        dgMode.Visible = True
    End Sub
    Private Sub rowColums()
        dg1.ColumnCount = 11
        dg1.Columns(0).Name = "ID"
        dg1.Columns(0).Visible = False
        dg1.Columns(1).Name = "Date"
        dg1.Columns(1).Width = 100
        dg1.Columns(2).Name = "Bank Name"
        dg1.Columns(2).Visible = False
        dg1.Columns(3).Name = "Entry Type"
        dg1.Columns(3).Width = 100
        dg1.Columns(4).Name = "Account Name"
        dg1.Columns(4).Width = 250
        dg1.Columns(5).Name = "Amount"
        dg1.Columns(5).Width = 100
        dg1.Columns(6).Name = "Exp."
        dg1.Columns(6).Width = 100
        dg1.Columns(7).Name = "Total"
        dg1.Columns(7).Width = 100
        dg1.Columns(8).Name = "Remark"
        dg1.Columns(8).Width = 100
        dg1.Columns(9).Name = "Cheque No."
        dg1.Columns(9).Width = 100
        dg1.Columns(10).Name = "Cheque Date"
        dg1.Columns(10).Visible = False
    End Sub
    Public Sub FillControls(ByVal id As Integer)
        Dim sSql As String = String.Empty
        Dim Crate As String = String.Empty
        btnSave.Text = "&Update"
        dg1.ClearSelection()
        Panel1.BackColor = Color.PaleVioletRed
        '  Dim bankcharges As String = ""
        If clsFun.GetConnection.State = ConnectionState.Open Then clsFun.CloseConnection()
        sSql = "Select * from Vouchers where id=" & id
        clsFun.con.Open()
        Dim ad As New SQLite.SQLiteDataAdapter(sSql, clsFun.GetConnection)
        Dim ds As New DataSet
        ad.Fill(ds, "a")
        If ds.Tables("a").Rows.Count > 0 Then
            txtID.Text = ds.Tables("a").Rows(0)("ID").ToString()
            txtBillNo.Text = ds.Tables("a").Rows(0)("BillNo").ToString()
            MskEntryDate.Text = Format(ds.Tables("a").Rows(0)("EntryDate"), "dd-MM-yyyy")
            txtAccountID.Text = ds.Tables("a").Rows(0)("AccountID").ToString()
            txtAccount.Text = ds.Tables("a").Rows(0)("AccountName").ToString()
            txtModeID.Text = ds.Tables("a").Rows(0)("SallerID").ToString()
            txtmode.text = ds.Tables("a").Rows(0)("SallerName").ToString()
            bankcharges = ds.Tables("a").Rows(0)("TransType").ToString()
            txtAmount.Text = ds.Tables("a").Rows(0)("BasicAmount").ToString()
            txtExpenses.Text = ds.Tables("a").Rows(0)("TotalCharges").ToString()
            txtTotal.Text = ds.Tables("a").Rows(0)("TotalAmount").ToString()
            txtRemark.Text = ds.Tables("a").Rows(0)("Remark").ToString()
            TxtChequeNo.Text = ds.Tables("a").Rows(0)("ChequeNo").ToString()
            If ds.Tables("a").Rows(0)("ChequeDate") = "  -  -" Then
                mskChequeDate.Text = ""
            Else
                mskChequeDate.Text = Format(CDate(ds.Tables("a").Rows(0)("ChequeDate")), "dd-MM-yyyy")
            End If
            '   mskChequeDate.Text = IIf(ds.Tables("a").Rows(0)("ChequeDate").ToString() = "  -  -", "", Format(CDate(ds.Tables("a").Rows(0)("ChequeDate")), "dd-MM-yyyy"))
            If bankcharges = "Bank Charges" Then
                CbEntryType.SelectedIndex = 0
            ElseIf bankcharges = "Cheque Recd" Then
                CbEntryType.SelectedIndex = 1
            ElseIf bankcharges = "Cheque Issued" Then
                CbEntryType.SelectedIndex = 2
            ElseIf bankcharges = "Cash Deposit" Then
                CbEntryType.SelectedIndex = 3
            ElseIf bankcharges = "Transfer" Then
                CbEntryType.SelectedIndex = 4
            ElseIf bankcharges = "Withdraw" Then
                CbEntryType.SelectedIndex = 5
            End If
        End If
    End Sub
    Private Sub save()
        If txtAmount.Text = "" Then MsgBox("Amount Empty") : txtAmount.Focus() : Exit Sub
        If txtTotal.Text = "" Then MsgBox("Total Amount Empty") : txtTotal.Focus() : Exit Sub
        SqliteEntryDate = CDate(Me.MskEntryDate.Text).ToString("yyyy-MM-dd")
        SqliteChequeDate = CDate(Me.mskChequeDate.Text).ToString("yyyy-MM-dd")
        ' Dim BankCharges As String
        Dim cmd As SQLite.SQLiteCommand
        Dim sql As String = "insert into Vouchers(TransType, Entrydate, SallerID, SallerName,AccountID, AccountName, BasicAmount, TotalAmount, TotalCharges, chequeDate, ChequeNo, Remark, BankEntry,BillNo)values (@1, @2, @3, @4, @5, @6, @7, @8, @9, @10, @11, @12, @13, @14)"
        Try
            cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
            If CbEntryType.SelectedIndex = 0 Then
                bankcharges = "Bank Charges"
                CbEntryType.Text = bankcharges
                cmd.Parameters.AddWithValue("@1", bankcharges)
            ElseIf CbEntryType.SelectedIndex = 1 Then
                bankcharges = "Cheque Recd"
                CbEntryType.Text = bankcharges
                cmd.Parameters.AddWithValue("@1", bankcharges)
            ElseIf CbEntryType.SelectedIndex = 2 Then
                bankcharges = "Cheque Issued"
                CbEntryType.Text = bankcharges
                cmd.Parameters.AddWithValue("@1", bankcharges)
            ElseIf CbEntryType.SelectedIndex = 3 Then
                bankcharges = "Cash Deposit"
                CbEntryType.Text = bankcharges
                cmd.Parameters.AddWithValue("@1", bankcharges)
            ElseIf CbEntryType.SelectedIndex = 4 Then
                bankcharges = "Transfer"
                CbEntryType.Text = bankcharges
                cmd.Parameters.AddWithValue("@1", bankcharges)
            ElseIf CbEntryType.SelectedIndex = 5 Then
                bankcharges = "Withdraw"
                CbEntryType.Text = bankcharges
                cmd.Parameters.AddWithValue("@1", bankcharges)
            End If
            cmd.Parameters.AddWithValue("@2", SqliteEntryDate)
            cmd.Parameters.AddWithValue("@3", Val(txtmodeID.text))
            cmd.Parameters.AddWithValue("@4", txtmode.text)
            cmd.Parameters.AddWithValue("@5", Val(txtAccountID.Text))
            cmd.Parameters.AddWithValue("@6", txtAccount.Text)
            cmd.Parameters.AddWithValue("@7", Val(txtAmount.Text))
            cmd.Parameters.AddWithValue("@8", Val(txtTotal.Text))
            cmd.Parameters.AddWithValue("@9", Val(txtExpenses.Text))
            cmd.Parameters.AddWithValue("@10", SqliteChequeDate)
            cmd.Parameters.AddWithValue("@11", TxtChequeNo.Text)
            cmd.Parameters.AddWithValue("@12", txtRemark.Text)
            cmd.Parameters.AddWithValue("@13", Me.Text)
            cmd.Parameters.AddWithValue("@14", txtBillNo.Text)
            If cmd.ExecuteNonQuery() > 0 Then
                clsFun.CloseConnection()
                MsgBox("Record Saved Successfully.", vbInformation + vbOKOnly, "Saved") 'Insert SuccesFully", "SuccessFully", MessageBoxButtons.OK, MessageBoxIcon.Information)
                VchId = clsFun.ExecScalarInt("Select Max(ID) from Vouchers") : UpdateLedger()
            End If
            retrive()
            txtClear()
            clsFun.CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message)
            clsFun.CloseConnection()
        End Try
    End Sub

    Private Sub txtRemark_GotFocus(sender As Object, e As EventArgs) Handles txtRemark.GotFocus
        If dgMode.SelectedRows.Count = 0 Then txtMode.Focus() : Exit Sub
        If txtMode.Text = "" Then txtMode.Focus() : Exit Sub
        If txtMode.Text.ToUpper <> dgMode.SelectedRows(0).Cells(1).Value.ToString.ToUpper Then txtMode.Focus() : Exit Sub
        If txtMode.Text = "" Then txtMode.Focus() : Exit Sub
        If dgMode.SelectedRows.Count = 0 Then Exit Sub
        If txtMode.Text.ToUpper = dgMode.SelectedRows(0).Cells(1).Value.ToString.ToUpper Then
            txtModeID.Text = dgMode.SelectedRows(0).Cells(0).Value
            dgMode.Visible = False
        Else
            txtMode.Focus()
        End If
    End Sub

    Private Sub txtAmount_GotFocus(sender As Object, e As EventArgs) Handles txtAmount.GotFocus
        If DgAccountSearch.SelectedRows.Count = 0 Then txtAccount.Focus() : Exit Sub
        If txtAccount.Text = "" Then txtAccount.Focus() : Exit Sub
        If txtAccount.Text.ToUpper <> DgAccountSearch.SelectedRows(0).Cells(1).Value.ToString.ToUpper Then txtAccount.Focus() : Exit Sub
        If txtAccount.Text = "" Then txtAccount.Focus() : Exit Sub
        If DgAccountSearch.SelectedRows.Count = 0 Then Exit Sub
        If txtAccount.Text.ToUpper = DgAccountSearch.SelectedRows(0).Cells(1).Value.ToString.ToUpper Then
            txtAccountID.Text = DgAccountSearch.SelectedRows(0).Cells(0).Value
            DgAccountSearch.Visible = False
            txtAmount.Focus()
        Else
            txtAccount.Focus()
        End If
    End Sub
    Private Sub txtAccount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAccount.KeyPress
        DgAccountSearch.BringToFront()
        AccountRowColumns()
        DgAccountSearch.Visible = True
    End Sub
    Private Sub txtAccount_KeyUp(sender As Object, e As KeyEventArgs) Handles txtAccount.KeyUp
        ' AccountRowColumns()
        If DgAccountSearch.RowCount = 0 Then Exit Sub
        If txtAccount.Text.Trim() <> "" Then
            retriveAccounts("Where upper(accountname) Like upper('%" & txtAccount.Text.Trim() & "%')")
        End If
        DgAccountSearch.Visible = True
    End Sub
    Private Sub txtMode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMode.KeyDown, txtAccount.KeyDown,
        txtAmount.KeyDown, txtExpenses.KeyDown, txtTotal.KeyDown, TxtChequeNo.KeyDown, txtBillNo.KeyDown,
        mskChequeDate.KeyDown, txtRemark.KeyDown, MskEntryDate.KeyDown
        If txtMode.Focused Then
            If e.KeyCode = Keys.Down Then dgMode.Focus()
            If e.KeyCode = Keys.F3 Then
                CreateAccount.MdiParent = MainScreenForm
                CreateAccount.Show()
                '    clsFun.FillDropDownList(CreateAccount.cbGroup, "SELECT ID,GroupName FROM AccountGroup Where ID=12 ", "GroupName", "ID", "")
                If Not CreateAccount Is Nothing Then
                    CreateAccount.BringToFront()
                End If
            End If
            If e.KeyCode = Keys.F1 Then
                If dgMode.SelectedRows.Count = 0 Then Exit Sub
                Dim tmpACid As Integer = dgMode.SelectedRows(0).Cells(0).Value
                CreateAccount.MdiParent = MainScreenForm
                CreateAccount.Show()
                CreateAccount.FillContros(tmpACid)
                If Not CreateAccount Is Nothing Then
                    CreateAccount.BringToFront()
                End If
            End If
        End If
        If txtAccount.Focused Then
            If e.KeyCode = Keys.Down Then DgAccountSearch.Focus()
            If e.KeyCode = Keys.F3 Then
                CreateAccount.MdiParent = MainScreenForm
                CreateAccount.Show()
                '   clsFun.FillDropDownList(CreateAccount.cbGroup, "SELECT ID,GroupName FROM AccountGroup", "GroupName", "ID", "")
                If Not CreateAccount Is Nothing Then
                    CreateAccount.BringToFront()
                End If
            End If
            If e.KeyCode = Keys.F1 Then
                If DgAccountSearch.SelectedRows.Count = 0 Then Exit Sub
                Dim tmpACid As Integer = DgAccountSearch.SelectedRows(0).Cells(0).Value
                CreateAccount.MdiParent = MainScreenForm
                CreateAccount.Show()
                CreateAccount.FillContros(tmpACid)
                If Not CreateAccount Is Nothing Then
                    CreateAccount.BringToFront()
                End If
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        Else
            Exit Sub
        End If
        Select Case e.KeyCode
            Case Keys.End
                e.Handled = True
                btnSave.Focus()
        End Select
    End Sub
    Private Sub txtClear()
        Panel1.BackColor = Color.Black
        MskEntryDate.Focus() : txtRemark.Text = ""
        txtAmount.Text = "" : txtExpenses.Text = ""
        TxtChequeNo.Text = "" : mskChequeDate.Text = ""
        txtTotal.Text = ""
    End Sub
    Private Sub CBBankAccount_Leave(sender As Object, e As EventArgs)
        If clsFun.ExecScalarInt("Select count(*)from Accounts") = 0 Then
            Exit Sub
        End If
        If clsFun.ExecScalarInt("Select count(*)from Accounts where AccountName='" & txtMode.Text & "'") = 0 Then
            MsgBox("Bank Not Found in Database...", vbCritical + vbOKOnly, "Access Denied")
            txtMode.Focus()
            Exit Sub
        End If
    End Sub
    Private Sub Calculation()
        If String.IsNullOrEmpty(txtAmount.Text) OrElse String.IsNullOrEmpty(txtExpenses.Text) Then Exit Sub
        txtTotal.Text = Format(CDbl(txtAmount.Text) - CDbl(txtExpenses.Text), "#######.00")
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub txtAmount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAmount.KeyPress, txtExpenses.KeyPress, txtTotal.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8 Or ((e.KeyChar = ".") And (sender.Text.IndexOf(".") = -1)))
    End Sub
    Private Sub txtAmount_Leave(sender As Object, e As EventArgs) Handles txtAmount.Leave
        If txtExpenses.Text = "" Then
            txtExpenses.Text = "0"
        End If
    End Sub
    Private Sub txtExpenses_Leave(sender As Object, e As EventArgs) Handles txtExpenses.Leave
        If txtExpenses.Text = "" Then
            txtExpenses.Text = "0"
        End If
    End Sub

    Private Sub txtAmount_TextChanged(sender As Object, e As EventArgs) Handles txtAmount.TextChanged, txtExpenses.TextChanged, txtTotal.TextChanged
        Calculation()
    End Sub

    Private Sub CbEntryType_KeyDown(sender As Object, e As KeyEventArgs) Handles CbEntryType.KeyDown
        If e.KeyCode = Keys.Enter Then txtAccount.Focus()
    End Sub
    Private Sub CbEntryType_Leave(sender As Object, e As EventArgs) Handles CbEntryType.Leave

    End Sub
    Private Sub CbEntryType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbEntryType.SelectedIndexChanged
        If CbEntryType.SelectedIndex = 0 Then
            TxtChequeNo.Visible = False
            mskChequeDate.Visible = False
            lblChequeDate.Visible = False
            lblChequeNo.Visible = False
        ElseIf CbEntryType.SelectedIndex = 3 Then
            TxtChequeNo.Visible = False
            mskChequeDate.Visible = False
            lblChequeDate.Visible = False
            lblChequeNo.Visible = False
        ElseIf CbEntryType.SelectedIndex = 5 Then
            TxtChequeNo.Visible = False
            mskChequeDate.Visible = False
            lblChequeDate.Visible = False
            lblChequeNo.Visible = False
        Else
            TxtChequeNo.Visible = True
            mskChequeDate.Visible = True
            lblChequeDate.Visible = True
            lblChequeNo.Visible = True
        End If
        'retrive()
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.Text = "&Save" Then
            save()
        Else
            Update()
        End If
    End Sub
    Private Sub Update()
        If txtAmount.Text = "" Then MsgBox("Amount Empty") : txtAmount.Focus() : Exit Sub
        If txtTotal.Text = "" Then MsgBox("Total Amount Empty") : txtTotal.Focus() : Exit Sub

        Dim dt As DateTime
        dt = CDate(Me.MskEntryDate.Text)
        SqliteEntryDate = CDate(Me.MskEntryDate.Text).ToString("yyyy-MM-dd")
        SqliteChequeDate = CDate(Me.mskChequeDate.Text).ToString("yyyy-MM-dd")
        Dim cmd As SQLite.SQLiteCommand
        Dim BankCharges As String
        If CbEntryType.SelectedIndex = 0 Then
            BankCharges = "Bank Charges"
            CbEntryType.Text = BankCharges
        ElseIf CbEntryType.SelectedIndex = 1 Then
            BankCharges = "Cheque Recd"
            CbEntryType.Text = BankCharges
        ElseIf CbEntryType.SelectedIndex = 2 Then
            BankCharges = "Cheque Issued"
            CbEntryType.Text = BankCharges
        ElseIf CbEntryType.SelectedIndex = 3 Then
            BankCharges = "Cash Deposit"
            CbEntryType.Text = BankCharges
            CbEntryType.Text = BankCharges
        ElseIf CbEntryType.SelectedIndex = 4 Then
            BankCharges = "Transfer"
            CbEntryType.Text = BankCharges
        ElseIf CbEntryType.SelectedIndex = 5 Then
            BankCharges = "Withdraw"
            CbEntryType.Text = BankCharges
        End If
        Dim sql As String = "Update  Vouchers SET BillNo='" & txtBillNo.Text & "',TransType='" & BankCharges & "', Entrydate='" & SqliteEntryDate & "', SallerID=" & Val(txtModeID.Text) & ", SallerName='" & txtMode.Text & "', " _
                                    & "AccountID=" & Val(txtAccountID.Text) & ", AccountName='" & txtAccount.Text & "',BasicAmount=" & Val(txtAmount.Text) & ", TotalAmount=" & Val(txtTotal.Text) & ", " _
                                    & " TotalCharges=" & Val(txtExpenses.Text) & ",chequeDate='" & SqliteChequeDate & "',ChequeNo='" & TxtChequeNo.Text & "',Remark='" & txtRemark.Text & "',BankEntry='" & Me.Text & "' where ID=" & txtID.Text & ""
        Try
            If clsFun.ExecNonQuery(sql) > 0 Then
                dg1.ClearSelection()
                Panel1.BackColor = Color.Black
                btnSave.Text = "&save"
                MsgBox("Record Updated Successfully.", vbInformation + vbOKOnly, "Update") 'Insert SuccesFully", "SuccessFully", MessageBoxButtons.OK, MessageBoxIcon.Information)
                clsFun.CloseConnection()
                If clsFun.ExecNonQuery("DELETE from Ledger WHERE VourchersID=" & txtID.Text & "") > 0 Then
                End If
                retrive()
                VchId = txtID.Text
                UpdateLedger()
            End If
            txtClear()
            clsFun.CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message)
            clsFun.CloseConnection()
        End Try
    End Sub

    Private Sub UpdateLedger()
        Dim dt As DateTime
        dt = CDate(Me.MskEntryDate.Text)
        ' Change the format:
        SqliteEntryDate = dt.ToString("yyyy-MM-dd")
        If CbEntryType.SelectedIndex = 1 Then
            If txtAccountID.Text > 0 Then ''Party Account
                If Val(txtTotal.Text) > 0 Then ''Account 
                    clsFun.Ledger(0, VchId, SqliteEntryDate, bankcharges, txtAccountID.Text, txtAccount.Text, Val(txtTotal.Text), "C", txtAccount.Text & ", Amount : " & Val(txtTotal.Text) & ", Cheque No : '" & TxtChequeNo.Text & "',Cheque Date :'" & mskChequeDate.Text & "'" & txtRemark.Text, txtAccount.Text)
                End If
            End If
            If txtModeID.Text > 0 Then ''bank account
                If Val(txtAmount.Text) > 0 Then ''Account 
                    clsFun.Ledger(0, VchId, SqliteEntryDate, bankcharges, txtModeID.Text, txtMode.Text, Val(txtAmount.Text), "D", txtAccount.Text & ", Amount : " & Val(txtTotal.Text) & ", Cheque No : '" & TxtChequeNo.Text & "', Cheque Date :'" & mskChequeDate.Text & "'" & txtRemark.Text, txtAccount.Text)
                End If
            End If
            If Val(txtExpenses.Text) > 0 Then ''Bank Charges
                clsFun.Ledger(0, VchId, SqliteEntryDate, bankcharges, 3, clsFun.ExecScalarStr("Select AccountName from Accounts where Id=3"), Val(txtExpenses.Text), "C", txtAccount.Text & ", Amount : " & Val(txtTotal.Text) & ", Cheque No : '" & TxtChequeNo.Text & "',Cheque Date :'" & mskChequeDate.Text & "'" & txtRemark.Text, txtAccount.Text)
            End If

        ElseIf CbEntryType.SelectedIndex = 3 Then
            If txtAccountID.Text > 0 Then ''Party Account
                If Val(txtTotal.Text) > 0 Then ''Account 
                    clsFun.Ledger(0, VchId, SqliteEntryDate, bankcharges, txtAccountID.Text, txtAccount.Text, Val(txtTotal.Text), "C", txtAccount.Text & ", Amount : " & Val(txtTotal.Text) & ", Cheque No : " & TxtChequeNo.Text & ", Cheque Date : " & mskChequeDate.Text & "," & txtRemark.Text, txtMode.Text)
                End If
            End If
            If txtModeID.Text > 0 Then ''bank account
                If Val(txtAmount.Text) > 0 Then ''Account 
                    clsFun.Ledger(0, VchId, SqliteEntryDate, bankcharges, txtModeID.Text, txtMode.Text, Val(txtAmount.Text), "D", txtAccount.Text & ", Amount : " & Val(txtTotal.Text) & ", Cheque No : " & TxtChequeNo.Text & ", Cheque Date : " & mskChequeDate.Text & "," & txtRemark.Text, txtMode.Text)
                End If
            End If
            If Val(txtExpenses.Text) > 0 Then ''Bank Charges
                clsFun.Ledger(0, VchId, SqliteEntryDate, bankcharges, 3, clsFun.ExecScalarStr("Select AccountName from Accounts where Id=3"), Val(txtExpenses.Text), "C", txtAccount.Text & ", Amount : " & Val(txtTotal.Text) & ", Cheque No : " & TxtChequeNo.Text & ", Cheque Date : " & mskChequeDate.Text & "," & txtRemark.Text, txtMode.Text)
            End If

        Else
            If txtAccountID.Text > 0 Then ''Party Account
                If Val(txtTotal.Text) > 0 Then ''Account 
                    clsFun.Ledger(0, VchId, SqliteEntryDate, bankcharges, txtAccountID.Text, txtAccount.Text, Val(txtTotal.Text), "D", txtAccount.Text & ", Amount : " & Val(txtTotal.Text) & ", Cheque No : " & TxtChequeNo.Text & ", Cheque Date : " & mskChequeDate.Text & "," & txtRemark.Text, txtAccount.Text)
                End If
            End If
            If txtModeID.Text > 0 Then ''bank account
                If Val(txtAmount.Text) > 0 Then ''Account 
                    clsFun.Ledger(0, VchId, SqliteEntryDate, bankcharges, txtModeID.Text, txtMode.Text, Val(txtAmount.Text), "C", txtAccount.Text & ", Amount : " & Val(txtTotal.Text) & ", Cheque No : " & TxtChequeNo.Text & ", Cheque Date : " & mskChequeDate.Text & "," & txtRemark.Text, txtAccount.Text)
                End If
            End If
            If Val(txtExpenses.Text) > 0 Then ''Bank Charges
                clsFun.Ledger(0, VchId, SqliteEntryDate, bankcharges, 3, clsFun.ExecScalarStr("Select AccountName from Accounts where Id=3"), Val(txtExpenses.Text), "D", txtAccount.Text & ", Amount : " & Val(txtTotal.Text) & ", Cheque No : " & TxtChequeNo.Text & ", Cheque Date : " & mskChequeDate.Text & "," & txtRemark.Text, txtAccount.Text)
            End If
        End If
    End Sub
    Private Sub Delete()
        Try
            If MessageBox.Show("Sure ??", "DELETE", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.OK Then
                If clsFun.ExecNonQuery("DELETE from Vouchers WHERE ID=" & dg1.SelectedRows(0).Cells(0).Value & "") > 0 Then
                End If
                If clsFun.ExecNonQuery("DELETE from Ledger WHERE VourchersID=" & dg1.SelectedRows(0).Cells(0).Value & "") > 0 Then

                End If
                MsgBox("Record Deleted Successfully.", vbExclamation + vbOKOnly, "Deleted")
                Panel1.BackColor = Color.Black
                btnSave.Text = "&Save"
                retrive()
                txtClear()
            End If
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub MskEntryDate_Leave(sender As Object, e As EventArgs) Handles MskEntryDate.Leave

    End Sub
    Private Sub mskEntryDate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MskEntryDate.Validating
        MskEntryDate.Text = clsFun.convdate(MskEntryDate.Text)
        If dg1.RowCount = 0 Then
            retrive()
        End If
    End Sub
    Private Sub retrive()
        Dim ssql As String
        Dim dt As New DataTable
        ' ssql = ("SELECT * FROM Vouchers WHERE EntryDate = '" & CDate(MskEntryDate.Text).ToString("yyyy-MM-dd") & "' and BankEntry='" & Me.Text & "'")
        'dt = clsFun.ExecDataTable(ssql)
        dt = clsFun.ExecDataTable("SELECT * FROM Vouchers WHERE EntryDate = '" & CDate(MskEntryDate.Text).ToString("yyyy-MM-dd") & "' and BankEntry='" & Me.Text & "'")
        dg1.Rows.Clear()
        Try
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("ID").ToString()
                        .Cells(1).Value = Format(dt.Rows(i)("EntryDate"), "dd-MM-yyyy")
                        .Cells(2).Value = dt.Rows(i)("SallerName").ToString()
                        .Cells(3).Value = dt.Rows(i)("TransType").ToString()
                        .Cells(4).Value = dt.Rows(i)("AccountName").ToString()
                        .Cells(5).Value = dt.Rows(i)("BasicAmount").ToString()
                        .Cells(6).Value = dt.Rows(i)("TotalCharges").ToString()
                        .Cells(7).Value = dt.Rows(i)("TotalAmount").ToString()
                        .Cells(8).Value = dt.Rows(i)("Remark").ToString()
                        .Cells(9).Value = dt.Rows(i)("ChequeNo").ToString()
                        If dt.Rows(i)("ChequeDate").ToString() = "  -  -" Then
                            .Cells(10).Value = ""
                        Else
                            .Cells(10).Value = Format(dt.Rows(i)("ChequeDate"), "dd-MM-yyyy")
                        End If
                    End With
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "Aadhat")
        End Try
        dg1.ClearSelection()
    End Sub


    Private Sub dg1_KeyDown(sender As Object, e As KeyEventArgs) Handles dg1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dg1.SelectedRows.Count = 0 Then Exit Sub
            FillControls(dg1.SelectedRows(0).Cells(0).Value)
            e.SuppressKeyPress = True
        End If
        If dg1.SelectedRows.Count = 0 Then Exit Sub
        If e.KeyCode = Keys.Delete Then
            Delete()
        End If
    End Sub
    Private Sub dg1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dg1.MouseDoubleClick
        If dg1.SelectedRows.Count = 0 Then Exit Sub
        FillControls(dg1.SelectedRows(0).Cells(0).Value)
    End Sub
    Private Sub mskChequeDate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mskChequeDate.Validating
        mskChequeDate.Text = clsFun.convdate(mskChequeDate.Text)
    End Sub
End Class