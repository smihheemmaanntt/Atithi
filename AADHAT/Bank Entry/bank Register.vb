Public Class bank_Register
    Private Sub bank_Register_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub
    Private Sub mskFromDate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mskFromDate.Validating
        mskFromDate.Text = clsFun.convdate(mskFromDate.Text)
    End Sub
    Private Sub mskFromDate_KeyDown(sender As Object, e As KeyEventArgs) Handles mskFromDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        Else
            Exit Sub
        End If
        e.SuppressKeyPress = True
        Select Case e.KeyCode
            Case Keys.End
                e.Handled = True
                btnShow.Focus()
        End Select
    End Sub

    Private Sub MsktoDate_KeyDown(sender As Object, e As KeyEventArgs) Handles MsktoDate.KeyDown
        If e.KeyCode = Keys.Enter Then btnShow.Focus()
    End Sub

    Private Sub MsktoDate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MsktoDate.Validating
        MsktoDate.Text = clsFun.convdate(MsktoDate.Text)
    End Sub
    Private Sub mskFromDate_GotFocus(sender As Object, e As EventArgs) Handles mskFromDate.GotFocus
        mskFromDate.SelectionStart = 0 : mskFromDate.SelectionLength = Len(mskFromDate.Text)
    End Sub
    Private Sub MsktoDate_GotFocus(sender As Object, e As EventArgs) Handles MsktoDate.GotFocus
        MsktoDate.SelectionStart = 0 : MsktoDate.SelectionLength = Len(MsktoDate.Text)
    End Sub
    Private Sub bank_Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0.5
        Me.Left = 179
        Me.BackColor = Color.Moccasin
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Dim mindate, maxdate As String
        mindate = clsFun.ExecScalarStr("select max(EntryDate) as entrydate from Vouchers where BankEntry='" & Me.Text & "'")
        maxdate = clsFun.ExecScalarStr("select max(entrydate) as entrydate from Vouchers where BankEntry='" & Me.Text & "'")
        If mindate <> "" Then
            mskFromDate.Text = CDate(mindate).ToString("dd-MM-yyyy")
        Else
            mskFromDate.Text = Date.Today.ToString("dd-MM-yyyy")
        End If
        If maxdate <> "" Then
            MsktoDate.Text = CDate(maxdate).ToString("dd-MM-yyyy")
        Else
            MsktoDate.Text = Date.Today.ToString("dd-MM-yyyy")
        End If
        rowColums()
    End Sub
    Private Sub rowColums()
        dg1.ColumnCount = 11
        dg1.Columns(0).Name = "ID"
        dg1.Columns(0).Visible = False
        dg1.Columns(1).Name = "Date"
        dg1.Columns(1).Width = 100
        dg1.Columns(2).Name = "Bank Name"
        dg1.Columns(2).Width = 200
        dg1.Columns(3).Name = "Entry Type"
        dg1.Columns(3).Width = 150
        dg1.Columns(4).Name = "Account Name"
        dg1.Columns(4).Width = 220
        dg1.Columns(5).Name = "Amount"
        dg1.Columns(5).Width = 70
        dg1.Columns(6).Name = "Exp."
        dg1.Columns(6).Width = 50
        dg1.Columns(7).Name = "Total"
        dg1.Columns(7).Width = 70
        dg1.Columns(8).Name = "Remark"
        dg1.Columns(8).Width = 100
        dg1.Columns(9).Name = "Cheque No."
        dg1.Columns(9).Visible = False
        dg1.Columns(10).Name = "Cheque Date"
        dg1.Columns(10).Visible = False
    End Sub

    Private Sub retrive()
        Dim ssql As String
        Dim dt As New DataTable
        ' dt = clsFun.ExecDataTable("SELECT * FROM Vouchers WHERE (((DateValue([EntryDate])) Between DateValue('" & mskFromDate.Text & "') And DateValue('" & MsktoDate.Text & "'))) and transtype='" & Me.Text & "' order by EntryDate")
        ssql = ("SELECT * FROM Vouchers WHERE EntryDate Between '" & CDate(mskFromDate.Text).ToString("yyyy-MM-dd") & "' And '" & CDate(MsktoDate.Text).ToString("yyyy-MM-dd") & "' and BankEntry='" & Me.Text & "' order by EntryDate")
        dt = clsFun.ExecDataTable(ssql)
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
                        .Cells(10).Value = dt.Rows(i)("ChequeDate").ToString()
                    End With
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "AADHAT")
        End Try
        dg1.ClearSelection()
    End Sub

    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        retrive()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub dg1_KeyDown(sender As Object, e As KeyEventArgs) Handles dg1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dg1.SelectedRows.Count = 0 Then Exit Sub
            Dim tmpID As String = dg1.SelectedRows(0).Cells(0).Value
            Bank_Entry.MdiParent = MainScreenForm
            Bank_Entry.Show()
            Bank_Entry.FillControls(tmpID)
            If Not scripForm Is Nothing Then
                Bank_Entry.BringToFront()
            End If
            e.SuppressKeyPress = True
        End If

    End Sub

    Private Sub dg1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dg1.MouseDoubleClick
        If dg1.SelectedRows.Count = 0 Then Exit Sub
        Dim tmpID As String = dg1.SelectedRows(0).Cells(0).Value
        Bank_Entry.MdiParent = MainScreenForm
        Bank_Entry.Show()
        Bank_Entry.FillControls(tmpID)
        If Not scripForm Is Nothing Then
            Bank_Entry.BringToFront()
        End If
    End Sub
End Class