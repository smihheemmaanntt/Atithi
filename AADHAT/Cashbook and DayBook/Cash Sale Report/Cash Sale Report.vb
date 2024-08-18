Public Class Cash_Sale_Report

    Private Sub Cash_Sale_Report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0.5
        Me.Left = 179
        Me.BackColor = Color.Moccasin
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Dim mindate, maxdate As String
        mindate = clsFun.ExecScalarStr("select min(strftime('%d-%m-%y', entrydate)) as entrydate from crateVoucher where transtype='" & Me.Text & "'")
        maxdate = clsFun.ExecScalarStr("select max(strftime('%d-%m-%y', entrydate)) as entrydate from crateVoucher where transtype='" & Me.Text & "'")
        mskFromDate.Text = IIf(mindate <> "", mindate, Date.Today.ToString("dd-MM-yyy"))
        MsktoDate.Text = IIf(maxdate <> "", maxdate, Date.Today.ToString("dd-MM-yyy"))
        rowColums()
    End Sub
    Private Sub rowColums()
        dg1.ColumnCount = 3
        dg1.Columns(0).Name = "ID" : dg1.Columns(0).Visible = False
        dg1.Columns(1).Name = "Date" : dg1.Columns(1).Width = 600
        dg1.Columns(2).Name = "Total Cash Amount" : dg1.Columns(2).Width = 400

    End Sub
    Sub calc()
        TxtGrandTotal.Text = Format(0, "00000.00")
        Dim i As Integer
        For i = 0 To dg1.Rows.Count - 1
            TxtGrandTotal.Text = TxtGrandTotal.Text + Val(dg1.Rows(i).Cells(2).Value)
        Next
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        Retrive()
    End Sub
    Private Sub Retrive()
        dg1.Rows.Clear()
        Dim dt As New DataTable
        Dim i As Integer
        Dim count As Integer = 0
        ssql = "Select VourchersID,EntryDate,round(Sum(Amount),2) as CashAmount From Ledger Where AccountID=7  and DC='D' and TransType in('Stock Sale','Super Sale' ,'Standard Sale','Speed Sale') and EntryDate between '" & CDate(mskFromDate.Text).ToString("yyyy-MM-dd") & "' and '" & CDate(MsktoDate.Text).ToString("yyyy-MM-dd") & "'Group by EntryDate Order By EntryDate"

        'ssql = "Select t2.EntryDate as entrydate, Ac.AccountName as AccountName,ac.id as id ,Sum(t2.Amount) as Sales,Sum(t2.Charges) as Charges from Account_acgrp ac " & _
        '    "inner join Transaction2 t2 on ac.id=t2.accountid left join vouchers v on v.id =t2.voucherid where (ac.groupid =16 or ac.undergroupid=16)  " & _
        '    "and  t2.EntryDate between '" & CDate(mskFromDate.Text).ToString("yyyy-MM-dd") & "' and '" & CDate(MsktoDate.Text).ToString("yyyy-MM-dd") & "' group by Ac.AccountName order by ac.accountname "
        dt = clsFun.ExecDataTable(ssql)
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                dg1.Rows.Add()
                With dg1.Rows(i)
                    .Cells(0).Value = dt.Rows(i)("VourchersID").ToString()
                    .Cells(1).Value = CDate(dt.Rows(i)("EntryDate")).ToString("dd-MM-yyyy")
                    .Cells(2).Value = dt.Rows(i)("CashAmount").ToString()
                End With
            Next i
        End If
        calc()
    End Sub

End Class