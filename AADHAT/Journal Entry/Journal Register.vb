Public Class Journal_Register

    Private Sub Journal_Register_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub
    Private Sub Journal_Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0.5
        Me.Left = 179
        Me.BackColor = Color.Moccasin
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Dim mindate, maxdate As String
        mindate = clsFun.ExecScalarStr("SELECT format(Min(Entrydate),'dd-mm-yyyy')From Transaction2 where TransType='" & Me.Text & "'")
        maxdate = clsFun.ExecScalarStr("SELECT format(Max(Entrydate),'dd-mm-yyyy')From Transaction2 where TransType='" & Me.Text & "'")
        mskFromDate.Text = IIf(mindate <> "", mindate, Date.Today.ToString("dd-MM-yyy"))
        MsktoDate.Text = IIf(maxdate <> "", maxdate, Date.Today.ToString("dd-MM-yyy"))
        rowColums()
    End Sub
    Private Sub mskFromDate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mskFromDate.Validating
        mskFromDate.Text = clsFun.convdate(mskFromDate.Text)
    End Sub

    Private Sub MsktoDate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MsktoDate.Validating
        MsktoDate.Text = clsFun.convdate(MsktoDate.Text)
    End Sub
    Private Sub rowColums()
        dg1.ColumnCount = 7
        dg1.Columns(0).Name = "ID"
        dg1.Columns(0).Visible = False
        dg1.Columns(1).Name = "Date"
        dg1.Columns(1).Width = 95
        dg1.Columns(2).Name = "Type"
        dg1.Columns(2).Width = 100
        dg1.Columns(3).Name = "Account Name"
        dg1.Columns(3).Width = 275
        dg1.Columns(4).Name = "Debit"
        dg1.Columns(4).Width = 120
        dg1.Columns(5).Name = "Credit"
        dg1.Columns(5).Width = 120
        dg1.Columns(6).Name = "Remark"
        dg1.Columns(6).Width = 230
    End Sub
    Private Sub retrive()
        Dim ssql As String
        Dim dt As New DataTable
        ssql = "SELECT VourchersID, [EntryDate],TransType,AccountName,Amount as Dr,'0' as Cr,Remark from Ledger where DC ='D' and transtype='" & Me.Text & "' and  (((DateValue([EntryDate])) Between DateValue('" & mskFromDate.Text & "') And DateValue('" & MsktoDate.Text & "'))) " & _
         " UNION ALL SELECT VourchersID, [EntryDate],TransType,AccountName,'0' as Dr,Amount as Cr,Remark  from Ledger where Dc='C' and transtype='" & Me.Text & "' and (((DateValue([EntryDate])) Between DateValue('" & mskFromDate.Text & "') And DateValue('" & MsktoDate.Text & "')))"
        dt = clsFun.ExecDataTable(ssql)
        dg1.Rows.Clear()
        Try
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("VourchersID").ToString()
                        '  .Cells(0).Value = i + 1
                        .Cells(1).Value = Format(dt.Rows(i)("EntryDate"), "dd-MM-yyyy")
                        .Cells(2).Value = dt.Rows(i)("TransType").ToString()
                        .Cells(3).Value = dt.Rows(i)("AccountName").ToString()
                        .Cells(4).Value = dt.Rows(i)("Dr").ToString()
                        .Cells(5).Value = dt.Rows(i)("Cr").ToString()
                        .Cells(6).Value = dt.Rows(i)("Remark").ToString()
                    End With
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "AADHAT")
        End Try
    End Sub

    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        retrive()
    End Sub

    Private Sub dg1_KeyDown(sender As Object, e As KeyEventArgs) Handles dg1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dg1.RowCount = 0 Then
                Exit Sub
            End If
            Dim tmpID As String = dg1.SelectedRows(0).Cells(0).Value
            JournalEntry.MdiParent = MainScreenForm
            JournalEntry.Show()
            JournalEntry.FillContros(tmpID)
            If Not JournalEntry Is Nothing Then
                JournalEntry.BringToFront()
            End If
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub dg1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dg1.MouseDoubleClick
        If dg1.RowCount = 0 Then
            Exit Sub
        End If
        Dim tmpID As String = dg1.SelectedRows(0).Cells(0).Value
        JournalEntry.MdiParent = MainScreenForm
        JournalEntry.Show()
        JournalEntry.FillContros(tmpID)
        If Not JournalEntry Is Nothing Then
            JournalEntry.BringToFront()
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class