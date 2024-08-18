Public Class JournalEntry
    Dim rs As New Resizer
    Dim vno As Integer

    Private Sub JournalEntry_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub
    Private Sub mskEntryDate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mskEntryDate.Validating
        mskEntryDate.Text = clsFun.convdate(mskEntryDate.Text)
    End Sub
    Private Sub JournalEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = "0.5"
        Me.Left = "179"
        'rs.FindAllControls(Me)
        Me.BackColor = Color.Moccasin
        mskEntryDate.Text = Date.Today.ToString("dd-MM-yyy")
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        clsFun.FillDropDownList(CbAccountName, "Select * From Accounts", "AccountName", "Id", "")
        CbDrCr.SelectedIndex = 0
        BtnDelete.Enabled = False
        rowColums()
        txtclear()
    End Sub
    Private Sub VNumber()
        Vno = clsFun.ExecScalarInt("SELECT Count(ID) AS NumberOfProducts FROM Vouchers Where TransType='" & Me.Text & "'")
        txtVoucherNo.Text = Vno + 1
    End Sub
    Private Sub rowColums()
        dg1.ColumnCount = 6
        dg1.Columns(0).Name = "DC"
        dg1.Columns(0).Width = 88
        dg1.Columns(1).Name = "Account Name"
        dg1.Columns(1).Width = 380
        dg1.Columns(2).Name = "Debit"
        dg1.Columns(2).Width = 70
        dg1.Columns(3).Name = "Credit"
        dg1.Columns(3).Width = 70
        dg1.Columns(4).Name = "Remark"
        dg1.Columns(4).Width = 340
        dg1.Columns(5).Name = "AcId"
        dg1.Columns(5).Width = 0
    End Sub
    Private Sub JournalEntry_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        'rs.ResizeAllControls(Me)
    End Sub

    Private Sub mskEntryDate_KeyDown(sender As Object, e As KeyEventArgs) Handles mskEntryDate.KeyDown, txtVoucherNo.KeyDown,
        CbDrCr.KeyDown, CbAccountName.KeyDown, txtAmount.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            ProcessTabKey(True)
        End If
        Select Case e.KeyCode
            Case Keys.End
                e.Handled = True
                BtnSave.Focus()
        End Select
    End Sub

    Private Sub CbAccountName_Leave(sender As Object, e As EventArgs) Handles CbAccountName.Leave
        If clsFun.ExecScalarInt("Select count(*)from Accounts") = 0 Then
            Exit Sub
        End If
        If clsFun.ExecScalarInt("Select count(*)from Accounts where AccountName='" & CbAccountName.Text & "'") = 0 Then
            MsgBox("Account Not Found in Database...", vbCritical + vbOKOnly, "Access Denied")
            CbAccountName.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub txtRemark_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRemark.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dg1.SelectedRows.Count = 1 Then
                If CbDrCr.Text = "D" Then
                    dg1.SelectedRows(0).Cells(0).Value = CbDrCr.Text
                    dg1.SelectedRows(0).Cells(1).Value = CbAccountName.Text
                    dg1.SelectedRows(0).Cells(2).Value = txtAmount.Text
                    dg1.SelectedRows(0).Cells(3).Value = 0
                    dg1.SelectedRows(0).Cells(4).Value = txtRemark.Text
                    CbDrCr.Focus()
                    dg1.ClearSelection()
                    calc()
                Else
                    dg1.SelectedRows(0).Cells(0).Value = CbDrCr.Text
                    dg1.SelectedRows(0).Cells(1).Value = CbAccountName.Text
                    dg1.SelectedRows(0).Cells(2).Value = 0
                    dg1.SelectedRows(0).Cells(3).Value = txtAmount.Text
                    dg1.SelectedRows(0).Cells(4).Value = txtRemark.Text
                    CbDrCr.Focus()
                    dg1.ClearSelection()
                    calc()
                End If
            Else 'mid
                If dg1.Rows.Count > 0 Then
                    For i = 0 To dg1.RowCount - 1
                        If dg1.Rows(i).Cells(1).Value = CbAccountName.Text Then
                            MsgBox("Same Account can't be Debited & Credited in a single Voucher")
                            CbAccountName.Focus()
                            Exit Sub
                        End If
                    Next
                End If
                If CbDrCr.Text = "D" Then
                    dg1.Rows.Add(CbDrCr.Text, CbAccountName.Text, txtAmount.Text, 0, txtRemark.Text, CbAccountName.SelectedValue)
                    calc()
                Else
                    dg1.Rows.Add(CbDrCr.Text, CbAccountName.Text, 0, txtAmount.Text, txtRemark.Text, CbAccountName.SelectedValue)
                    calc()
                End If
                calc()
                'cleartxtCharges()
                CbDrCr.Focus()
                dg1.ClearSelection()
            End If
        End If
    End Sub
    Sub calc()
        TxtTotalDebit.Text = Format(0, "00000.00")
        Dim i As Integer
        For i = 0 To dg1.Rows.Count - 1
            TxtTotalDebit.Text = TxtTotalDebit.Text + Val(dg1.Rows(i).Cells(2).Value)
        Next
        TxtTotalCredit.Text = Format(0, "00000.00")
        For i = 0 To dg1.Rows.Count - 1
            TxtTotalCredit.Text = TxtTotalCredit.Text + Val(dg1.Rows(i).Cells(3).Value)
        Next
    End Sub
    Private Sub dg1_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            If dg1.SelectedRows(0).Cells(0).Value = "D" Then
                CbDrCr.Text = dg1.SelectedRows(0).Cells(0).Value
                CbAccountName.Text = dg1.SelectedRows(0).Cells(1).Value
                txtAmount.Text = dg1.SelectedRows(0).Cells(2).Value
                txtRemark.Text = dg1.SelectedRows(0).Cells(4).Value
            Else
                CbDrCr.Text = dg1.SelectedRows(0).Cells(0).Value
                CbAccountName.Text = dg1.SelectedRows(0).Cells(1).Value
                txtAmount.Text = dg1.SelectedRows(0).Cells(3).Value
                txtRemark.Text = dg1.SelectedRows(0).Cells(4).Value
            End If
        End If
        e.SuppressKeyPress = True
        If e.KeyCode = Keys.Delete Then
            dg1.Rows.Remove(dg1.SelectedRows(0).Cells(0).Value)
        End If
    End Sub
    Private Sub dg1_MouseDoubleClick(sender As Object, e As MouseEventArgs)
        If dg1.SelectedRows(0).Cells(0).Value = "D" Then
            CbDrCr.Text = dg1.SelectedRows(0).Cells(0).Value
            CbAccountName.Text = dg1.SelectedRows(0).Cells(1).Value
            txtAmount.Text = dg1.SelectedRows(0).Cells(2).Value
            txtRemark.Text = dg1.SelectedRows(0).Cells(4).Value
        Else
            CbDrCr.Text = dg1.SelectedRows(0).Cells(0).Value
            CbAccountName.Text = dg1.SelectedRows(0).Cells(1).Value
            txtAmount.Text = dg1.SelectedRows(0).Cells(3).Value
            txtRemark.Text = dg1.SelectedRows(0).Cells(4).Value
        End If
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If BtnSave.Text = "&Save" Then
            save()
        Else
            Update()
        End If
    End Sub
    Private Sub save()
        If TxtTotalDebit.Text <> TxtTotalCredit.Text Then
            MsgBox("Debit and Credit Balance Not Same")
            txtAmount.Focus()
            Exit Sub
        End If
        Dim count As Integer = 0
        Dim cmd As New SQLite.SQLiteCommand
        Dim sql As String = "insert into Vouchers (EntryDate,TransType,BillNo) values (@1, @2, @3)"
        Try
            cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
            cmd.Parameters.AddWithValue("@1", mskEntryDate.Text)
            cmd.Parameters.AddWithValue("@2", Me.Text)
            cmd.Parameters.AddWithValue("@3", txtVoucherNo.Text)
            If cmd.ExecuteNonQuery() > 0 Then
                MessageBox.Show("Record Inserted SuccesFully", "SuccessFully", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' textclear()
                BtnDelete.Enabled = False
                mskEntryDate.Focus()
            End If
            clsFun.CloseConnection()
            'Dim itemid As Integer = txtid.Text
            For Each row As DataGridViewRow In dg1.Rows
                'For Each row As DataGridViewRow In .Rows
                With row
                    Dim VchId As Integer = clsFun.ExecScalarInt("Select Max(ID) from Vouchers")
                    If .Cells("DC").Value <> "" Then
                        '  If CbAccountName.SelectedValue > 0 Then ''Journal in Ledger
                        clsFun.Ledger(0, VchId, mskEntryDate.Text, Me.Text, .Cells(5).Value, .Cells(1).Value, IIf(Val(.Cells(2).Value) > 0, Val(.Cells(2).Value), .Cells(3).Value), .Cells("DC").Value, .Cells(4).Value)
                        'End If
                    End If
                End With
            Next
            txtclear()
        Catch ex As Exception
            MsgBox(ex.Message)
            clsFun.CloseConnection()
        End Try
    End Sub
    Private Sub Update()
        Dim count As Integer = 0
        Dim cmd As New SQLite.SQLiteCommand
        If TxtTotalDebit.Text <> TxtTotalCredit.Text Then
            MsgBox("Debit and Credit Balance Are not Same", MsgBoxStyle.Exclamation, "Invalid")
            txtAmount.Focus()
            Exit Sub
        End If
        Dim sql As String = "Update Vouchers SET EntryDate='" & mskEntryDate.Text & "',TransType='" & Me.Text & "',BillNo='" & txtVoucherNo.Text & "' where ID=" & txtid.Text & ""
        Try
            If clsFun.ExecNonQuery(sql) > 0 Then
                MessageBox.Show("Record Inserted SuccesFully", "SuccessFully", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' textclear()
                mskEntryDate.Focus()
            End If
            clsFun.CloseConnection()
            If clsFun.ExecNonQuery("DELETE from Ledger WHERE vourchersID=" & txtid.Text & "") > 0 Then
                Panel1.BackColor = Color.PaleVioletRed
                BtnSave.Text = "&Save"
                BtnDelete.Enabled = False
                For Each row As DataGridViewRow In dg1.Rows
                    'For Each row As DataGridViewRow In .Rows
                    With row
                        Dim VchId As Integer = txtid.Text
                        If .Cells("DC").Value <> "" Then
                            '  If CbAccountName.SelectedValue > 0 Then ''Journal in Ledger
                            clsFun.Ledger(0, VchId, mskEntryDate.Text, Me.Text, .Cells(5).Value, .Cells(1).Value, IIf(Val(.Cells(2).Value) > 0, Val(.Cells(2).Value), .Cells(3).Value), .Cells("DC").Value, .Cells(4).Value)
                            'End If
                        End If
                    End With
                Next
                txtclear()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            clsFun.CloseConnection()
        End Try
    End Sub
    Private Sub Delete()
        Try
            If MessageBox.Show("Sure ??", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                If clsFun.ExecNonQuery("DELETE from Vouchers WHERE ID=" & txtid.Text & "") > 0 Then
                End If
                If clsFun.ExecNonQuery("DELETE from Ledger WHERE vourchersID=" & txtid.Text & "") > 0 Then
                End If
                MsgBox("Record Deleted Successfully.", vbInformation + vbOKOnly, "Deleted")
                txtclear()
                BtnSave.Text = "&Save"
                Panel1.BackColor = Color.Black
            Else

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub txtclear()
        VNumber()
        txtRemark.Text = ""
        TxtTotalCredit.Text = ""
        TxtTotalDebit.Text = ""
        txtAmount.Text = ""
        dg1.Rows.Clear()
    End Sub

    Public Sub FillContros(ByVal id As Integer)
        Dim sSql As String = String.Empty
        Dim Crate As String = String.Empty
        BtnSave.Text = "&Update"
        Panel1.BackColor = Color.PaleVioletRed
        '  BtnUpdate.Visible = True
        BtnDelete.Enabled = True
        If clsFun.GetConnection.State = ConnectionState.Open Then clsFun.CloseConnection()
        sSql = "Select * from Vouchers where id=" & id
        'Dim sql As String = "SELECT EntryDate,TransType,AccountName,Amount as Dr,'' as Cr,Remark from Ledger where DC ='D' and VourchersID=" & id " & _
        '                    "UNION ALL SELECT VourchersID, EntryDate,TransType,AccountName,'' as Dr,Amount as Cr,Remark  from Ledger where Dc='C' ;"
        Dim sql As String = "Select * from Ledger where VourchersID=" & id
        clsFun.con.Open()
        Dim ad As New  SQLite.SQLiteDataAdapter(sSql, clsFun.GetConnection)
        Dim ad1 As New  SQLite.SQLiteDataAdapter(sql, clsFun.GetConnection)

        Dim ds As New DataSet
        ad.Fill(ds, "a")
        ad1.Fill(ds, "b")
        If ds.Tables("a").Rows.Count > 0 Then
            mskEntryDate.Text = Format(ds.Tables("a").Rows(0)("EntryDate"), "dd-MM-yyyy")
            txtVoucherNo.Text = ds.Tables("a").Rows(0)("BillNo").ToString()
            txtid.Text = ds.Tables("a").Rows(0)("ID").ToString()
        End If
        If ds.Tables("b").Rows.Count > 0 Then
            dg1.Rows.Clear()
            If dg1.Rows.Count = 0 Then dg1.Rows.Add()
            With dg1
                Dim i As Integer = 0
                For i = 0 To ds.Tables("b").Rows.Count - 1
                    .Rows.Add()
                    .Rows(i).Cells("DC").Value = ds.Tables("b").Rows(i)("Dc").ToString()
                    .Rows(i).Cells("Account Name").Value = ds.Tables("b").Rows(i)("AccountName").ToString()
                    If dg1.Rows(i).Cells(0).Value = "D" Then
                        .Rows(i).Cells("Debit").Value = ds.Tables("b").Rows(i)("Amount").ToString()
                    Else
                        .Rows(i).Cells("Credit").Value = ds.Tables("b").Rows(i)("Amount").ToString()
                    End If
                    .Rows(i).Cells("Remark").Value = ds.Tables("b").Rows(i)("Remark").ToString()
                Next
            End With
        End If
        calc()
        BtnDelete.Enabled = True
    End Sub

    Private Sub dg1_KeyDown1(sender As Object, e As KeyEventArgs) Handles dg1.KeyDown

        If e.KeyCode = Keys.Enter Then

            If dg1.SelectedRows(0).Cells(0).Value = "D" Then
                CbDrCr.Text = dg1.SelectedRows(0).Cells(0).Value
                CbAccountName.Text = dg1.SelectedRows(0).Cells(1).Value
                txtAmount.Text = dg1.SelectedRows(0).Cells(2).Value
                txtRemark.Text = dg1.SelectedRows(0).Cells(4).Value
            Else
                CbDrCr.Text = dg1.SelectedRows(0).Cells(0).Value
                CbAccountName.Text = dg1.SelectedRows(0).Cells(1).Value
                txtAmount.Text = dg1.SelectedRows(0).Cells(3).Value
                txtRemark.Text = dg1.SelectedRows(0).Cells(4).Value
            End If
        End If
        e.SuppressKeyPress = True
        If e.KeyCode = Keys.Delete Then
            If MessageBox.Show("Are you Sure to delete Item", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                dg1.Rows.Remove(dg1.SelectedRows(0))
                calc()
                'ClearDetails()
            End If
        End If
    End Sub

    Private Sub dg1_MouseDoubleClick1(sender As Object, e As MouseEventArgs) Handles dg1.MouseDoubleClick
        If dg1.SelectedRows(0).Cells(0).Value = "D" Then
            CbDrCr.Text = dg1.SelectedRows(0).Cells(0).Value
            CbAccountName.Text = dg1.SelectedRows(0).Cells(1).Value
            txtAmount.Text = dg1.SelectedRows(0).Cells(2).Value
            txtRemark.Text = dg1.SelectedRows(0).Cells(4).Value
        Else
            CbDrCr.Text = dg1.SelectedRows(0).Cells(0).Value
            CbAccountName.Text = dg1.SelectedRows(0).Cells(1).Value
            txtAmount.Text = dg1.SelectedRows(0).Cells(3).Value
            txtRemark.Text = dg1.SelectedRows(0).Cells(4).Value
        End If
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        Delete()
    End Sub
    Private Sub txtAmount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAmount.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8 Or ((e.KeyChar = ".") And (sender.Text.IndexOf(".") = -1)))
    End Sub

    Private Sub txtRemark_Leave(sender As Object, e As EventArgs) Handles txtRemark.Leave

    End Sub
End Class