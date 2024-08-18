Public Class Membership

    Private Sub Membership_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub mskStartDate_Leave(sender As Object, e As EventArgs) Handles mskStartDate.Leave

    End Sub
    Private Sub mskStartDate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mskStartDate.Validating
        mskStartDate.Text = clsFun.convdate(mskStartDate.Text)
        FindExpDate()
    End Sub
    Private Sub Membership_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clsFun.FillDropDownList(cbpackageName, "Select * From Package", "packageName", "Id", "")
        mskExpiryDate.Text = Date.Today.ToString("dd-MM-yyyy")
        mskStartDate.Text = Date.Today.ToString("dd-MM-yyyy")
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.BackColor = Color.Moccasin
        Me.KeyPreview = True
        BtnDelete.Visible = False
        txtAccount.Focus()
        FindExpDate()
        FindMemberShipNo()
    End Sub
    Private Sub Update()
        Dim dt As DateTime
        Dim dt1 As DateTime
        dt = CDate(mskStartDate.Text)
        dt1 = CDate(mskExpiryDate.Text)
        ' Change the format:
        SqliteStartDate = dt.ToString("yyyy-MM-dd")
        SqliteEndDate = dt1.ToString("yyyy-MM-dd")
        Dim cmd As SQLite.SQLiteCommand
        If txtAccount.Text = "" Then
            txtAccount.Focus()
            MsgBox("Please Fill Member Name... ", MsgBoxStyle.Exclamation, "Empty")
            Exit Sub
        End If
        Dim sql As String = "Update MemberShip Set AccountID='" & Val(txtAccountID.Text) & "',AccountName='" & txtAccount.Text & "'," _
                            & "ExpiryDate='" & SqliteEndDate & "',StartDate='" & SqliteStartDate & "',AmountPaid= '" & txtAmountpaid.Text & "', " _
                             & "PackageID='" & Val(cbpackageName.SelectedValue) & "',PackageName='" & cbpackageName.Text & "' where ID=" & txtID.Text & ""
        cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
        Try
            If clsFun.ExecNonQuery(sql) > 0 Then
                MessageBox.Show("Record Updated SuccesFully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'clearTxtAll()

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub FillControls(ByVal id As Integer)
        Dim ssql As String = String.Empty
        Dim dt As New DataTable
        Panel1.BackColor = Color.PaleVioletRed
        lblgroup.Text = "Modify MemberShip"
        BtnDelete.Visible = True
        BtnSave.Text = "&Update"
        ssql = "Select * from MemberShip where id=" & id
        dt = clsFun.ExecDataTable(ssql) ' where id=" & id & "")
        If dt.Rows.Count > 0 Then
            txtAccountID.Text = dt.Rows(0)("AccountID").ToString()
            txtAccount.Text = dt.Rows(0)("AccountName").ToString()
            txtAmountpaid.Text = dt.Rows(0)("AmountPaid").ToString()
            mskExpiryDate.Text = CDate(dt.Rows(0)("ExpiryDate")).ToString("dd-MM-yyyy")
            mskStartDate.Text = CDate(dt.Rows(0)("StartDate")).ToString("dd-MM-yyyy")
            cbpackageName.Text = dt.Rows(0)("PackageName").ToString()
            txtMemberID.Text = dt.Rows(0)("MemberShipID").ToString()
            txtID.Text = dt.Rows(0)("ID").ToString()
        End If
    End Sub
    Private Sub save()
        Dim dt As DateTime
        Dim dt1 As DateTime
        dt = CDate(mskStartDate.Text)
        dt1 = CDate(mskExpiryDate.Text)
        ' Change the format:
        SqliteStartDate = dt.ToString("yyyy-MM-dd")
        SqliteEndDate = dt1.ToString("yyyy-MM-dd")
        Dim cmd As SQLite.SQLiteCommand
        If txtAccount.Text = "" Then
            txtAccount.Focus()
            MsgBox("Please Fill Member Name... ", MsgBoxStyle.Exclamation, "Empty")
        Else
            Dim sql As String = "insert into MemberShip (AccountID,AccountName,ExpiryDate,StartDate,AmountPaid,Packageid,PackageName,MembershipID) values (@1, @2,@3,@4, @5,@6,@7,@8)"
            Try
                cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
                cmd.Parameters.AddWithValue("@1", txtAccountID.Text)
                cmd.Parameters.AddWithValue("@2", txtAccount.Text)
                cmd.Parameters.AddWithValue("@3", SqliteStartDate)
                cmd.Parameters.AddWithValue("@4", SqliteEndDate)
                cmd.Parameters.AddWithValue("@5", txtAmountpaid.Text)
                cmd.Parameters.AddWithValue("@6", cbpackageName.SelectedValue)
                cmd.Parameters.AddWithValue("@7", cbpackageName.Text)
                cmd.Parameters.AddWithValue("@8", txtMemberID.Text)
                If cmd.ExecuteNonQuery() > 0 Then
                    MsgBox("Record Insert SuccesFully", MsgBoxStyle.Information, "Saved")
                    ' clearTxtAll()
                End If
                clsFun.CloseConnection()
            Catch ex As Exception
                MsgBox(ex.Message)
                clsFun.CloseConnection()
            End Try
        End If
        FindMemberShipNo()
    End Sub
    Private Sub AccountRowColumns()
        DgAccountSearch.ColumnCount = 3
        DgAccountSearch.Columns(0).Name = "ID" : DgAccountSearch.Columns(0).Visible = False
        DgAccountSearch.Columns(1).Name = "Account Name" : DgAccountSearch.Columns(1).Width = 180
        DgAccountSearch.Columns(2).Name = "City" : DgAccountSearch.Columns(2).Width = 150
        retriveAccounts()
    End Sub
    Private Sub retriveAccounts(Optional ByVal condtion As String = "")
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("Select * from Account_AcGrp where (Groupid in(16)  or UnderGroupID in (16))" & condtion & " order by AccountName")
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
            MsgBox(ex.Message, vbOKOnly + vbInformation, "Teller")
        End Try
    End Sub

    Private Sub txtAccount_GotFocus(sender As Object, e As EventArgs) Handles txtAccount.GotFocus
        AccountRowColumns()
    End Sub
    Private Sub txtAccount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAccount.KeyPress
        DgAccountSearch.BringToFront()
        AccountRowColumns()
        DgAccountSearch.Visible = True
    End Sub

    Private Sub txtAccount_KeyUp(sender As Object, e As KeyEventArgs) Handles txtAccount.KeyUp
        AccountRowColumns()
        If txtAccount.Text.Trim() <> "" Then
            retriveAccounts(" And upper(accountname) Like upper('%" & txtAccount.Text.Trim() & "%')")
        End If
    End Sub
    Private Sub DgAccountSearch_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgAccountSearch.CellClick
        txtAccount.Clear()
        txtAccountID.Clear()
        txtAccountID.Text = DgAccountSearch.SelectedRows(0).Cells(0).Value
        txtAccount.Text = DgAccountSearch.SelectedRows(0).Cells(1).Value
        DgAccountSearch.Visible = False
        cbpackageName.Focus()
    End Sub
    Private Sub DgAccountSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles DgAccountSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtAccount.Clear()
            txtAccountID.Clear()
            txtAccountID.Text = DgAccountSearch.SelectedRows(0).Cells(0).Value
            txtAccount.Text = DgAccountSearch.SelectedRows(0).Cells(1).Value
            DgAccountSearch.Visible = False
            e.SuppressKeyPress = True
            cbpackageName.Focus()
        End If
        If e.KeyCode = Keys.Back Then txtAccount.Focus()
    End Sub

    Private Sub cbpackageName_GotFocus(sender As Object, e As EventArgs) Handles cbpackageName.GotFocus
        If DgAccountSearch.RowCount = 0 Then txtAccount.Focus() : Exit Sub
        If txtAccount.Text = "" Then txtAccount.Focus() : Exit Sub
        If DgAccountSearch.SelectedRows.Count = 0 Then Exit Sub
        If txtAccount.Text.ToUpper = DgAccountSearch.SelectedRows(0).Cells(1).Value.ToString.ToUpper Then
            txtAccountID.Text = DgAccountSearch.SelectedRows(0).Cells(0).Value
            txtAccount.Text = DgAccountSearch.SelectedRows(0).Cells(1).Value
            DgAccountSearch.Visible = False
        Else
            txtAccount.Focus()
        End If
    End Sub
    Private Sub txtName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAccount.KeyDown, cbpackageName.KeyDown, mskStartDate.KeyDown,
        mskExpiryDate.KeyDown, txtAmountpaid.KeyDown, txtMemberID.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        Else
            Exit Sub
        End If
        e.SuppressKeyPress = True
        Select Case e.KeyCode
            Case Keys.End
                e.Handled = True
                BtnSave.Focus()
        End Select
    End Sub
    Private Sub txtAccount_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAccount.KeyDown
        If e.KeyCode = Keys.Down Then DgAccountSearch.Focus()
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If BtnSave.Text = "&Save" Then
            save()
        Else
            Update()
        End If
    End Sub

    Private Sub cbpackageName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbpackageName.SelectedIndexChanged
        If DgAccountSearch.RowCount = 0 Then txtAccount.Focus() : Exit Sub
        If txtAccount.Text = "" Then txtAccount.Focus() : Exit Sub
        If DgAccountSearch.SelectedRows.Count = 0 Then Exit Sub
        If txtAccount.Text.ToUpper = DgAccountSearch.SelectedRows(0).Cells(1).Value.ToString.ToUpper Then
            txtAccountID.Text = DgAccountSearch.SelectedRows(0).Cells(0).Value
            txtAccount.Text = DgAccountSearch.SelectedRows(0).Cells(1).Value
            DgAccountSearch.Visible = False
        Else
            txtAccount.Focus()
        End If
        FindExpDate()
    End Sub

    Private Sub mskExpiryDate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mskExpiryDate.Validating
        mskExpiryDate.Text = clsFun.convdate(mskExpiryDate.Text)
    End Sub
    Sub FindExpDate()
        Dim expdate As Date
        Dim startdt As Date = mskStartDate.Text
        expdate = startdt.AddDays(clsFun.ExecScalarInt("Select ValidDays from Package where ID=" & Val(cbpackageName.SelectedValue) & ""))
        mskExpiryDate.Text = CDate(expdate).ToString("dd-MM-yyyy")
    End Sub
    Sub FindMemberShipNo()
        If clsFun.ExecScalarInt("Select count(*) from Membership") = 0 Then
            txtMemberID.Text = "JMR-1001"
        Else
            txtMemberID.Text = "JMR-" & clsFun.ExecScalarStr("Select MAX(substr(MembershipID,5,length(MembershipID)-4))+1 as maxno from Membership")
        End If
        txtMemberID.Enabled = False
    End Sub
End Class