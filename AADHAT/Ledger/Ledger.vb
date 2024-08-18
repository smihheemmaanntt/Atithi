Imports System.Globalization
Imports System.Management
Imports System.Text
Imports System.Configuration
Imports System.Xml
Public Class Ledger
    Dim rs As New Resizer
    Dim strSDate As String
    Dim strEDate As String
    Dim dDate As DateTime
    Dim mskstartDate As String
    Dim mskenddate As String
    '  Private opbal As Decimal = 0.0
    Private Sub mskFromDate_KeyDown(sender As Object, e As KeyEventArgs) Handles mskFromDate.KeyDown, MsktoDate.KeyDown, cbAccountName.KeyDown
        If cbAccountName.Focused Then
            If e.KeyCode = Keys.F3 Then
                CreateAccount.MdiParent = MainScreenForm
                CreateAccount.Show()
                '  clsFun.FillDropDownList(CreateAccount.txtGroup.Text, "SELECT ID,GroupName FROM AccountGroup Where ID=32 ", "GroupName", "ID", "")
                If Not CreateAccount Is Nothing Then
                    CreateAccount.BringToFront()
                End If
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            ProcessTabKey(True)
        End If
        Select Case e.KeyCode
            Case Keys.End
                e.Handled = True
                btnShow.Focus()
        End Select

    End Sub
    Private Sub MsktoDate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MsktoDate.Validating
        MsktoDate.Text = clsFun.convdate(MsktoDate.Text)
    End Sub
    Private Sub Ledger_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub
    Private Sub Ledger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0 : Me.Left = 0
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        clsFun.FillDropDownList(cbAccountName, "Select * From Accounts", "AccountName", "Id", "")
        Dim mindate, maxdate As String
        mindate = clsFun.ExecScalarStr("SELECT min(strftime('%d-%m-%Y', EntryDate))From Ledger")
        maxdate = clsFun.ExecScalarStr("SELECT max(strftime('%d-%m-%Y', EntryDate))From Ledger")
        mskFromDate.Text = IIf(mindate <> "", mindate, Date.Today.ToString("dd-MM-yyyy"))
        MsktoDate.Text = IIf(maxdate <> "", maxdate, Date.Today.ToString("dd-MM-yyyy"))
        rowColums()
    End Sub
    Private Sub rowColums()
        dg1.ColumnCount = 8
        dg1.Columns(0).Name = "ID" : dg1.Columns(0).Visible = False
        dg1.Columns(1).Name = "Date" : dg1.Columns(1).Width = 150
        dg1.Columns(2).Name = "Type" : dg1.Columns(2).Width = 150
        dg1.Columns(3).Name = "Account Name" : dg1.Columns(3).Visible = False
        dg1.Columns(4).Name = "Description" : dg1.Columns(4).Width = 400
        dg1.Columns(5).Name = "Debit" : dg1.Columns(5).Width = 150
        dg1.Columns(6).Name = "Credit" : dg1.Columns(6).Width = 150
        dg1.Columns(7).Name = "Balance" : dg1.Columns(7).Width = 165
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub cbLedgerName_SelectedIndexChanged(sender As Object, e As EventArgs)


    End Sub

    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        dg1.Rows.Clear()
        'Try
        txtOpBal.Text = ""
        Dim ssql As String = String.Empty
        Dim dt As New DataTable
        Dim dr As Decimal = 0
        Dim cr As Decimal = 0
        Dim tot As Decimal = 0
        Dim opbal As String = ""

        opbal = clsFun.ExecScalarStr(" SELECT (OpBal) FROM Accounts WHERE ID= " & cbAccountName.SelectedValue & "")
        ssql = "SELECT VouchersID,[Entrydate], TransType,AccountName,Remark,Amount as Dr,'0' as Cr from Ledger where DC ='D' " & IIf(cbAccountName.SelectedValue > 0, "and AccountID=" & Val(cbAccountName.SelectedValue) & "", "") & " and EntryDate Between '" & CDate(mskFromDate.Text).ToString("yyyy-MM-dd") & "' And '" & CDate(MsktoDate.Text).ToString("yyyy-MM-dd") & "'    union all" & _
            " SELECT VouchersID, [Entrydate],  TransType,AccountName,Remark,'0' as Dr,Amount as Cr  from Ledger where Dc='C' " & IIf(cbAccountName.SelectedValue > 0, "and AccountID=" & Val(cbAccountName.SelectedValue) & "", "") & " and EntryDate Between '" & CDate(mskFromDate.Text).ToString("yyyy-MM-dd") & "' And '" & CDate(MsktoDate.Text).ToString("yyyy-MM-dd") & "'    "
        Dim tmpamtdr As String = clsFun.ExecScalarStr("SELECT sum(Amount) as tot from Ledger where Dc='D' and accountID=" & Val(cbAccountName.SelectedValue) & " and EntryDate  < '" & CDate(mskFromDate.Text).ToString("yyyy-MM-dd") & "'")
        Dim tmpamtcr As String = clsFun.ExecScalarStr("SELECT sum(Amount) as tot from Ledger where Dc='C' and accountID=" & Val(cbAccountName.SelectedValue) & " and EntryDate < '" & CDate(mskFromDate.Text).ToString("yyyy-MM-dd") & "'")
        ' opbal = clsFun.ExecScalarStr(" SELECT (OpBal) FROM Accounts WHERE AccountName like '%" + cbAccountName.Text + "%'")
        Dim drcr As String = clsFun.ExecScalarStr(" SELECT Dc FROM Accounts WHERE ID= " & cbAccountName.SelectedValue & "")
        If drcr = "Dr" Then
            tmpamtdr = Val(opbal) + Val(tmpamtdr)
        Else
            tmpamtcr = Val(opbal) + Val(tmpamtcr)
        End If

        Dim tmpamt As String = IIf(Val(tmpamtdr) > Val(tmpamtcr), Val(tmpamtdr) - Val(tmpamtcr), Val(tmpamtcr) - Val(tmpamtdr)) '- Val(opbal)

        If drcr = "Cr" Then
            opbal = -Val(opbal)
        End If
        'If Val(opbal) < Val(tmpamt) Then
        '    tmpamt = Math.Abs(Val(tmpamt)) + Math.Abs(Val(opbal))
        'Else
        '    tmpamt = Val(opbal) - Math.Abs(Val(tmpamt))
        'End If
        dt = clsFun.ExecDataTable(ssql)
        Dim dvData As DataView = New DataView(dt)
        'dvData.RowFilter = "EntryDate Between '" & mskFromDate.Text & "' And '" & MsktoDate.Text & "'"
        dvData.Sort = " [EntryDate] asc , VouchersID asc "
        dt = dvData.ToTable
        dg1.Rows.Clear()

        opbal = tmpamt
        'If Val(tmpamt) > 0 Then
        '    opbal = Val(tmpamt)
        'Else
        '    opbal = Val(opbal) + Val(tmpamt)
        'End If

        Dim cnt As Integer = clsFun.ExecScalarInt("Select count(*) from LEdger where  accountID=" & Val(cbAccountName.SelectedValue) & " and  EntryDate < '" & CDate(mskFromDate.Text).ToString("yyyy-MM-dd") & "'")
        If cnt = 0 Then
            'If Val(opbal) > 0 Then

            '    txtOpBal.Text = opbal & " " & clsFun.ExecScalarStr(" SELECT Dc FROM Accounts WHERE AccountName like '%" + cbAccountName.Text + "%'")

            'End If
            txtOpBal.Text = Format(Math.Abs(Val(opbal)), "0.00") & " " & clsFun.ExecScalarStr(" SELECT Dc FROM Accounts WHERE ID= " & Val(cbAccountName.SelectedValue) & "")
        Else

            If Val(tmpamtcr) > Val(tmpamtdr) Then
                txtOpBal.Text = Format(Math.Abs(Val(opbal)), "0.00") & " Cr"
            Else
                txtOpBal.Text = Format(Math.Abs(Val(opbal)), "0.00") & " Dr"
            End If
            '  txtOpBal.Text = IIf(Val(opbal) > 0, Val(opbal) & " Dr", Math.Abs(Val(opbal)) & " Cr")
        End If
        ''opbal = Val(opbal) + Val(tmpamt)
        '  
        If Val(txtOpBal.Text) > 0 Then
            drcr = txtOpBal.Text.Substring(txtOpBal.Text.Length - 2)
        End If
        ' opbal = Math.Abs(val(opbal))
        Try
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        .Cells(1).Value = Format(dt.Rows(i)("EntryDate"), "dd-MM-yyyy")
                        .Cells(2).Value = dt.Rows(i)("TransType").ToString()
                        .Cells(3).Value = dt.Rows(i)("AccountName").ToString()
                        .Cells(4).Value = dt.Rows(i)("Remark").ToString()
                        .Cells(5).Value = IIf(Val(dt.Rows(i)("Dr").ToString()) = 0, "", Format(Val(dt.Rows(i)("Dr").ToString()), "0.00"))
                        .Cells(6).Value = IIf(Val(dt.Rows(i)("Cr").ToString()) = 0, "", Format(Val(dt.Rows(i)("Cr").ToString()), "0.00"))
                           If i = 0 Then
                            If Val(.Cells(5).Value) > 0 Then
                                If drcr = "Dr" Then
                                    tot = Format(Val(Val(opbal) + Val(.Cells(5).Value)), "0.00")
                                Else
                                    tot = Format(Val(Val(.Cells(5).Value) - Val(opbal)), "0.00")
                                    'If Val(.cells(5).value) > Val(opbal) Then
                                    '    tot = Format(Val(Val(.Cells(5).Value) - Val(opbal)), "0.00")
                                    'Else
                                    '    tot = Format(Val(Val(.Cells(5).Value) - Val(opbal)), "0.00")
                                    'End If
                                End If
                            Else
                                If drcr = "Cr" Then
                                    tot = Format(Val(Val(opbal) + Val(.Cells(6).Value)), "0.00")
                                Else
                                    If Val(.cells(6).value) > Val(opbal) Then
                                        tot = Format(Val(Val(.Cells(6).Value) - Val(opbal)), "0.00")
                                    Else
                                        tot = Format(Val(Val(opbal) - Val(.Cells(6).Value)), "0.00")
                                    End If
                                End If
                                If drcr = "Dr" And Val(opbal) > Val(.Cells(6).Value) Then
                                    tot = Math.Round(Val(tot), 2)
                                Else
                                    tot = -Val(tot)
                                End If
                            End If
                        Else
                            tot = tot + IIf(Val(.Cells(5).Value) > 0, Val(.Cells(5).Value), -Val(.Cells(6).Value))
                        End If
                        .Cells(7).Value = IIf(tot > 0, Format(Val(tot), "0.00") & " Dr", Format(Math.Abs(tot), "0.00") & " Cr")
                        dr = dr + Val(.Cells(5).Value)
                        cr = cr + Val(.Cells(6).Value)
                    End With
                Next
            Else
                tot = Format(Val(opbal), "0.00")

            End If
            If drcr = "Dr" Then
                dr = Format(Val(dr) + Math.Abs(Val(opbal)), "0.00")
            Else
                cr = Format(Val(cr) + Math.Abs(Val(opbal)), "0.00")
            End If
            txtDramt.Text = dr.ToString() : txtcrAmt.Text = cr.ToString()
            If dt.Rows.Count = 0 Then
                txtBalAmt.Text = txtOpBal.Text
            Else
                txtBalAmt.Text = IIf(Format(Val(tot), "0.00") >= 0, Format(Val(tot), "0.00") & " Dr", Format(Math.Abs(Val(tot)), "0.00") & " Cr")
            End If
            dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "AADHAT")
        End Try
        dg1.ClearSelection()
    End Sub
     Private Sub cbAccountName_Leave(sender As Object, e As EventArgs) Handles cbAccountName.Leave
        If clsFun.ExecScalarInt("Select count(*)from Accounts where AccountName='" & cbAccountName.Text & "'") = 0 Then
            MsgBox("Account Name Not Found in Database...", vbCritical + vbOKOnly, "Access Denied")
            cbAccountName.Focus()
            Exit Sub
        End If
        mindate = clsFun.ExecScalarStr("SELECT min(strftime('%d-%m-%Y', EntryDate))From Ledger Where AccountID=" & cbAccountName.SelectedValue & "")
        mskFromDate.Text = IIf(mindate <> "", mindate, Date.Today.ToString("dd-MM-yyyy"))
        maxdate = clsFun.ExecScalarStr("SELECT Max(strftime('%d-%m-%Y', EntryDate))From Ledger Where AccountID=" & cbAccountName.SelectedValue & "")
        MsktoDate.Text = IIf(maxdate <> "", maxdate, Date.Today.ToString("dd-MM-yyyy"))
    End Sub
    Private Sub mskFromDate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mskFromDate.Validating
        mskFromDate.Text = clsFun.convdate(mskFromDate.Text)
    End Sub
    Private Sub PrintRecord()
        Dim count As Integer = 0
        Dim cmd As New SQLite.SQLiteCommand
        Dim sql As String = ""
        clsFun.ExecNonQuery("Delete from printing")
        For Each row As DataGridViewRow In dg1.Rows
            With row
                sql = "insert into Printing(D1,D2,M1,M2, M3, M4, M5, P1, P2,P3, P4, P5, P6,P7) values('" & mskFromDate.Text & "'," & _
                    "'" & MsktoDate.Text & "','" & cbAccountName.Text & "','" & txtOpBal.Text & "','" & txtDramt.Text & "','" & txtcrAmt.Text & "'," & _
                    "'" & txtBalAmt.Text & "','" & .Cells("Date").Value & "','" & .Cells("Type").Value & "','" & .Cells("Account Name").Value & "','" & .Cells("Description").Value & "'," & _
                    "'" & Val(.Cells("Debit").Value) & "'," & Val(.Cells("Credit").Value) & ",'" & .Cells("Balance").Value & "')"
                Try
                    clsFun.ExecNonQuery(sql)
                Catch ex As Exception
                    MsgBox(ex.Message)
                    clsFun.CloseConnection()
                End Try
            End With
        Next
    End Sub
    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        clsFun.changeCompany()
        PrintRecord()
        Print_Ledger.MdiParent = MainScreenForm
        Print_Ledger.Show()
        If Not Print_Ledger Is Nothing Then
            Print_Ledger.BringToFront()
        End If
    End Sub

    Private Sub dtp2_GotFocus(sender As Object, e As EventArgs) Handles dtp2.GotFocus
        MsktoDate.Focus()
    End Sub

    Private Sub dtp2_ValueChanged(sender As Object, e As EventArgs) Handles dtp2.ValueChanged
        MsktoDate.Text = dtp2.Value.ToString("dd-MM-yyyy")
        MsktoDate.Text = clsFun.convdate(MsktoDate.Text)
    End Sub

    Private Sub dtp1_GotFocus(sender As Object, e As EventArgs) Handles dtp1.GotFocus
        mskFromDate.Focus()
    End Sub

    Private Sub dtp1_ValueChanged(sender As Object, e As EventArgs) Handles dtp1.ValueChanged
        mskFromDate.Text = dtp1.Value.ToString("dd-MM-yyyy")
        mskFromDate.Text = clsFun.convdate(mskFromDate.Text)
    End Sub
End Class