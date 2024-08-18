Public Class POS_Register

    Private Sub Item_Register_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub
    Private Sub Item_Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Dim mindate, maxdate As String
        mindate = clsFun.ExecScalarStr("select Max(EntryDate) as entrydate from Vouchers where  transtype='" & Me.Text & "'")
        maxdate = clsFun.ExecScalarStr("select Max(EntryDate) as entrydate from Vouchers where  transtype='" & Me.Text & "'")
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
        mskFromDate.Focus()
        rowColums()
    End Sub
  
    Private Sub mskFromDate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mskFromDate.Validating
        mskFromDate.Text = clsFun.convdate(mskFromDate.Text)
    End Sub
    Private Sub MsktoDate_KeyDown(sender As Object, e As KeyEventArgs) Handles MsktoDate.KeyDown
        If e.KeyCode = Keys.Enter Then btnShow.Focus()
    End Sub
    Private Sub MsktoDate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MsktoDate.Validating
        MsktoDate.Text = clsFun.convdate(MsktoDate.Text)
    End Sub
    Private Sub rowColums()
        dg1.ColumnCount = 16
        dg1.Columns(0).Name = "ID" : dg1.Columns(0).Visible = False
        dg1.Columns(1).Name = "Date" : dg1.Columns(1).Width = 100
        dg1.Columns(2).Name = "Pos No" : dg1.Columns(2).Width = 70
        dg1.Columns(3).Name = "Service" : dg1.Columns(3).Visible = False
        dg1.Columns(4).Name = "S.No" : dg1.Columns(4).Width = 50
        dg1.Columns(5).Name = "Item Name" : dg1.Columns(5).Width = 200
        dg1.Columns(6).Name = "Qty" : dg1.Columns(6).Width = 70
        dg1.Columns(7).Name = "Rate" : dg1.Columns(7).Width = 70
        dg1.Columns(8).Name = "Basic" : dg1.Columns(8).Width = 70
        dg1.Columns(9).Name = "Disc" : dg1.Columns(9).Width = 60
        dg1.Columns(10).Name = "Taxable" : dg1.Columns(10).Width = 80
        dg1.Columns(11).Name = "Tax" : dg1.Columns(11).Width = 60
        dg1.Columns(12).Name = "R.off" : dg1.Columns(12).Width = 60
        dg1.Columns(13).Name = "Total" : dg1.Columns(13).Width = 100
        dg1.Columns(14).Name = "Cash" : dg1.Columns(14).Width = 100
        dg1.Columns(15).Name = "Change" : dg1.Columns(15).Width = 100
    End Sub
    Private Sub retrive(Optional ByVal condtion As String = "")
        dg1.Rows.Clear() : Dim dt As New DataTable
        '    dt = clsFun.ExecDataTable("Select * from Trans_View Where EntryDate Between '" & CDate(mskFromDate.Text).ToString("yyyy-MM-dd") & "' And '" & CDate(MsktoDate.Text).ToString("yyyy-MM-dd") & "' and transtype='" & Me.Text & "' " & condtion & "  order by ID ")
        dt = clsFun.ExecDataTable("Select * From Trans as t Inner  join Vouchers V on V.id=t.VoucherID Where  v.EntryDate Between '" & CDate(mskFromDate.Text).ToString("yyyy-MM-dd") & "' And '" & CDate(MsktoDate.Text).ToString("yyyy-MM-dd") & "' and V.transtype='POS' " & condtion & "  order by ID ")
        Dim vchid As Integer = 0
        Try
            If dt.Rows.Count > 0 Then
                dg1.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("ID").ToString()
                        If i = 0 Then
                            .Cells(1).Value = Format(dt.Rows(i)("EntryDate1"), "dd-MM-yyyy")
                            .Cells(2).Value = dt.Rows(i)("InvoiceNo").ToString()
                            .Cells(3).Value = dt.Rows(i)("ServiceType").ToString()
                            .Cells(12).Value = Format(Val(dt.Rows(i)("Roundoff").ToString()), "0.00")
                            .Cells(13).Value = Format(Val(dt.Rows(i)("TotalGrandAmt").ToString()), "0.00")
                            .Cells(14).Value = Format(Val(dt.Rows(i)("TotalCashAmt").ToString()), "0.00")
                            .Cells(15).Value = Format(Val(dt.Rows(i)("TotalBalAmt").ToString()), "0.00")
                        ElseIf vchid = dt.Rows(i)("ID").ToString() Then
                            .Cells(1).Value = ""
                            .Cells(2).Value = ""
                            .Cells(12).Value = ""
                            .Cells(13).Value = ""
                            .Cells(14).Value = ""
                            .Cells(15).Value = ""
                        Else
                            .Cells(1).Value = Format(dt.Rows(i)("EntryDate"), "dd-MM-yyyy")
                            .Cells(2).Value = dt.Rows(i)("InvoiceNo").ToString()
                            .Cells(3).Value = dt.Rows(i)("ServiceType").ToString()
                            '    .Cells(12).Value = Format(Val(dt.Rows(i)("Roundoff").ToString()), "0.00")
                            .Cells(13).Value = Format(Val(dt.Rows(i)("TotalGrandAmt").ToString()), "0.00")
                            .Cells(14).Value = Format(Val(dt.Rows(i)("TotalCashAmt").ToString()), "0.00")
                            .Cells(15).Value = Format(Val(dt.Rows(i)("TotalBalAmt").ToString()), "0.00")
                        End If
                        .Cells(4).Value = dt.Rows(i)("Sno").ToString()
                        .Cells(5).Value = dt.Rows(i)("ItemName").ToString()
                        .Cells(6).Value = Format(Val(dt.Rows(i)("Qty").ToString()), "0.00")
                        .Cells(7).Value = Format(Val(dt.Rows(i)("Rate").ToString()), "0.00")
                        .Cells(8).Value = Format(Val(dt.Rows(i)("BasicAmt").ToString()), "0.00")
                        .Cells(9).Value = Format(Val(dt.Rows(i)("DisAmt").ToString()), "0.00")
                        .Cells(10).Value = Format(Val(dt.Rows(i)("Taxableamt").ToString()), "0.00")
                        .Cells(11).Value = Format(Val(dt.Rows(i)("Taxamt").ToString()), "0.00")
                    End With
                    vchid = dt.Rows(i)("ID").ToString()
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "AADHAT")
        End Try
        calc() : dg1.ClearSelection()
    End Sub
    Sub calc()
        txttotQty.Text = Format(0, "0.00") : txtTotBasic.Text = Format(0, "0.00")
        txtTotDiscount.Text = Format(0, "0.00") : txtTotTaxable.Text = Format(0, "0.00")
        txtTotTax.Text = Format(0, "0.00") : txtTotTotal.Text = Format(0, "0.00")
        txtTotTaxable.Text = Format(0, "0.00") : txtTotCash.Text = Format(0, "0.00")
        txtTotChange.Text = Format(0, "0.00")
        For i = 0 To dg1.Rows.Count - 1
            txttotQty.Text = Format(Val(txttotQty.Text) + Val(dg1.Rows(i).Cells(6).Value), "0.00")
            txtTotBasic.Text = Format(Val(txtTotBasic.Text) + Val(dg1.Rows(i).Cells(8).Value), "0.00")
            txtTotDiscount.Text = Format(Val(txtTotDiscount.Text) + Val(dg1.Rows(i).Cells(9).Value), "0.00")
            txtTotTaxable.Text = Format(Val(txtTotTaxable.Text) + Val(dg1.Rows(i).Cells(10).Value), "0.00")
            txtTotTax.Text = Format(Val(txtTotTax.Text) + Val(dg1.Rows(i).Cells(11).Value), "0.00")
            txtTotRoundOff.Text = Format(Val(txtTotRoundOff.Text) + Val(dg1.Rows(i).Cells(12).Value), "0.00")
            txtTotTotal.Text = Format(Val(txtTotTotal.Text) + Val(dg1.Rows(i).Cells(13).Value), "0.00")
            txtTotCash.Text = Format(Val(txtTotCash.Text) + Val(dg1.Rows(i).Cells(14).Value), "0.00")
            txtTotChange.Text = Format(Val(txtTotChange.Text) + Val(dg1.Rows(i).Cells(15).Value), "0.00")
        Next
    End Sub
    Private Sub dg1_KeyDown(sender As Object, e As KeyEventArgs)
        If dg1.SelectedRows.Count = 0 Then Exit Sub
        Dim tmpID As String = dg1.SelectedRows(0).Cells(0).Value
        POS.Show()
        POS.FillControls(tmpID)
        If Not POS Is Nothing Then
            POS.BringToFront()
        End If
        e.SuppressKeyPress = True
    End Sub
    Private Sub dg1_MouseDoubleClick(sender As Object, e As MouseEventArgs)
        If dg1.SelectedRows.Count = 0 Then Exit Sub
        POS.Show()
        Dim tmpid As Integer = Val(dg1.SelectedRows(0).Cells(0).Value)
        POS.FillControls(tmpid)
        If Not POS Is Nothing Then
            POS.BringToFront()
        End If
    End Sub
    Private Sub txtCustomerSearch_KeyUp(sender As Object, e As KeyEventArgs) Handles txtCustomerSearch.KeyUp
        If txtCustomerSearch.Text.Trim() <> "" Then
            retrive(" And ItemName Like '" & txtCustomerSearch.Text.Trim() & "%'")
        End If
        If txtCustomerSearch.Text.Trim() = "" Then
            retrive()
        End If
        If e.KeyCode = Keys.Down Then dg1.Focus()
    End Sub

    Private Sub txtitemCode_KeyUp(sender As Object, e As KeyEventArgs) Handles txtitemCode.KeyUp
        If txtitemCode.Text.Trim() <> "" Then
            retrive(" and ItemCode Like '" & txtitemCode.Text.Trim() & "%'")
        End If
        If txtitemCode.Text.Trim() = "" Then
            retrive()
        End If
        If e.KeyCode = Keys.Down Then dg1.Focus()
    End Sub
   
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        retrive()
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
    Private Sub mskFromDate_GotFocus(sender As Object, e As EventArgs) Handles mskFromDate.GotFocus, mskFromDate.Click
        mskFromDate.SelectAll()
    End Sub
    Private Sub MsktoDate_GotFocus(sender As Object, e As EventArgs) Handles MsktoDate.GotFocus, MsktoDate.Click
        MsktoDate.SelectAll()
    End Sub

    Private Sub dg1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg1.CellContentClick

    End Sub

    Private Sub dg1_KeyDown1(sender As Object, e As KeyEventArgs) Handles dg1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dg1.SelectedRows.Count = 0 Then Exit Sub
            Dim tmpID As Integer = Val(dg1.SelectedRows(0).Cells(0).Value)
            POS.Show() : POS.FillControls(tmpID)
            POS.BringToFront()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub dg1_MouseDoubleClick1(sender As Object, e As MouseEventArgs) Handles dg1.MouseDoubleClick
        If dg1.SelectedRows.Count = 0 Then Exit Sub
        Dim tmpID As Integer = Val(dg1.SelectedRows(0).Cells(0).Value)
        POS.Show() : POS.FillControls(tmpID)
        POS.BringToFront()
    End Sub
End Class