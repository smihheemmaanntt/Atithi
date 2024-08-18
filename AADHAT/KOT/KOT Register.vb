﻿Public Class KOT_Register

    Private Sub Item_Register_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub
    Private Sub Item_Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0 : Me.Left = 0
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Dim mindate, maxdate As String
        mindate = clsFun.ExecScalarStr("select Max(EntryDate) as entrydate from KOT ")
        maxdate = clsFun.ExecScalarStr("select Max(EntryDate) as entrydate from KOT")
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
        dg1.ColumnCount = 12
        dg1.Columns(0).Name = "ID" : dg1.Columns(0).Visible = False
        dg1.Columns(1).Name = "Date" : dg1.Columns(1).Width = 100
        dg1.Columns(2).Name = "KOT No" : dg1.Columns(2).Width = 100
        dg1.Columns(3).Name = "Attender" : dg1.Columns(3).Width = 150
        dg1.Columns(4).Name = "Service Type" : dg1.Columns(4).Width = 129
        dg1.Columns(5).Name = "Table/Room No" : dg1.Columns(5).Width = 150
        dg1.Columns(6).Name = "SR" : dg1.Columns(6).Visible = False
        dg1.Columns(7).Name = "Item Name" : dg1.Columns(7).Width = 268
        dg1.Columns(8).Name = "Unit" : dg1.Columns(8).Visible = False
        dg1.Columns(9).Name = "Qty" : dg1.Columns(9).Width = 79
        dg1.Columns(10).Name = "Rate" : dg1.Columns(10).Width = 93
        dg1.Columns(11).Name = "Amount" : dg1.Columns(11).Width = 120
    End Sub
    Private Sub retrive(Optional ByVal condtion As String = "")
        dg1.Rows.Clear()
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("SELECT * FROM KOT AS K LEFT JOIN KOTTrans KT ON KT.KOTID = K.ID Where EntryDate Between '" & CDate(mskFromDate.Text).ToString("yyyy-MM-dd") & "' And '" & CDate(MsktoDate.Text).ToString("yyyy-MM-dd") & "' " & condtion & "  order by ID ")
        Dim vchid As Integer = 0
        Try
            If dt.Rows.Count > 0 Then
                dg1.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("ID").ToString()
                        If i = 0 Then
                            .Cells(1).Value = Format(dt.Rows(i)("EntryDate"), "dd-MM-yyyy")
                            .Cells(2).Value = dt.Rows(i)("KOTNo").ToString()
                            .Cells(3).Value = dt.Rows(i)("AttenderName").ToString()
                            .Cells(4).Value = dt.Rows(i)("ServiceName").ToString()
                            .Cells(5).Value = IIf(dt.Rows(i)("TableNos").ToString() = "", dt.Rows(i)("RoomNos").ToString(), dt.Rows(i)("TableNos").ToString())
                        ElseIf vchid = dt.Rows(i)("ID").ToString() Then
                            .Cells(1).Value = ""
                            .Cells(2).Value = ""
                            .Cells(3).Value = ""
                            .Cells(4).Value = ""
                            .Cells(5).Value = ""
                        Else
                            .Cells(1).Value = Format(dt.Rows(i)("EntryDate"), "dd-MM-yyyy")
                            .Cells(2).Value = dt.Rows(i)("KOTNo").ToString()
                            .Cells(3).Value = dt.Rows(i)("AttenderName").ToString()
                            .Cells(4).Value = dt.Rows(i)("ServiceName").ToString()
                            .Cells(5).Value = IIf(dt.Rows(i)("TableNos").ToString() = "", dt.Rows(i)("RoomNos").ToString(), dt.Rows(i)("TableNos").ToString())
                        End If

                        .Cells(6).Value = dt.Rows(i)("SRNo").ToString()
                        .Cells(7).Value = dt.Rows(i)("ItemName").ToString()
                        .Cells(8).Value = dt.Rows(i)("Unit").ToString()
                        .Cells(9).Value = Val(dt.Rows(i)("Qty").ToString())
                        .Cells(10).Value = Format(Val(dt.Rows(i)("Rate").ToString()), "0.00")
                        .Cells(11).Value = Format(Val(dt.Rows(i)("Amount").ToString()), "0.00")
                    End With
                    vchid = dt.Rows(i)("ID").ToString()
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "Athiti")
        End Try
        calc() : dg1.ClearSelection()
        'lblTotal.Visible = True
        'lblTotal.Text = "POS Bills : " & Val(dg1.RowCount)
    End Sub
    Private Sub dg1_KeyDown(sender As Object, e As KeyEventArgs) Handles dg1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dg1.SelectedRows.Count = 0 Then Exit Sub
            Dim tmpID As String = dg1.SelectedRows(0).Cells(0).Value
            KOT.MdiParent = MainScreenForm
            KOT.Show()
            KOT.FillControls(tmpID)
            If Not KOT Is Nothing Then
                KOT.BringToFront()
            End If
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub dg1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dg1.MouseDoubleClick
        If dg1.SelectedRows.Count = 0 Then Exit Sub
        KOT.MdiParent = MainScreenForm
        KOT.Show()
        Dim tmpid As Integer = Val(dg1.SelectedRows(0).Cells(0).Value)
        KOT.FillControls(tmpid)
        If Not KOT Is Nothing Then
            KOT.BringToFront()
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
    Private Sub txtUnit_KeyUp(sender As Object, e As KeyEventArgs) Handles txtAttenderName.KeyUp
        If txtAttenderName.Text.Trim() <> "" Then
            retrive(" and AttenderName Like '" & txtAttenderName.Text.Trim() & "%'")
        End If
        If txtAttenderName.Text.Trim() = "" Then
            retrive()
        End If
        If e.KeyCode = Keys.Down Then dg1.Focus()
    End Sub
    Private Sub txtTax_KeyUp(sender As Object, e As KeyEventArgs) Handles txtKotNo.KeyUp
        If txtKotNo.Text.Trim() <> "" Then
            retrive(" and KotNo Like '" & txtKotNo.Text.Trim() & "%'")
        End If
        If txtKotNo.Text.Trim() = "" Then
            retrive()
        End If
        If e.KeyCode = Keys.Down Then dg1.Focus()
    End Sub
    Private Sub txtPurchase_KeyUp(sender As Object, e As KeyEventArgs) Handles txtQty.KeyUp
        If txtQty.Text.Trim() <> "" Then
            retrive(" and Qty Like '" & txtQty.Text.Trim() & "%'")
        End If
        If txtQty.Text.Trim() = "" Then
            retrive()
        End If
        If e.KeyCode = Keys.Down Then dg1.Focus()
    End Sub

    Private Sub txtSale_KeyUp(sender As Object, e As KeyEventArgs) Handles txtRate.KeyUp
        If txtRate.Text.Trim() <> "" Then
            retrive(" and Rate Like '" & txtRate.Text.Trim() & "%'")
        End If
        If txtRate.Text.Trim() = "" Then
            retrive()
        End If
        If e.KeyCode = Keys.Down Then dg1.Focus()
    End Sub

    Private Sub txtMrp_KeyUp(sender As Object, e As KeyEventArgs) Handles txtTotal.KeyUp
        If txtTotal.Text.Trim() <> "" Then
            retrive(" and Amount Like '" & txtTotal.Text.Trim() & "%'")
        End If
        If txtTotal.Text.Trim() = "" Then
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
    Sub calc()
        txttotQty.Text = 0 : txtTotTotal.Text = Format(0, "0.00")
        For i = 0 To dg1.Rows.Count - 1
            txttotQty.Text = Val(txttotQty.Text) + Val(dg1.Rows(i).Cells(9).Value)
            txtTotTotal.Text = Format(Val(txtTotTotal.Text) + Val(dg1.Rows(i).Cells(11).Value), "0.00")
        Next
        '   calculation()
    End Sub
    Private Sub txtTable_KeyUp(sender As Object, e As KeyEventArgs) Handles txtTable.KeyUp
        If txtTable.Text.Trim() <> "" Then
            retrive(" and TableNos Like '" & txtTotal.Text.Trim() & "%'")
        End If
        If txtTable.Text.Trim() = "" Then
            retrive()
        End If
        If e.KeyCode = Keys.Down Then dg1.Focus()
    End Sub

    Private Sub mskFromDate_KeyDown(sender As Object, e As KeyEventArgs) Handles mskFromDate.KeyDown, MsktoDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub dg1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg1.CellContentClick

    End Sub
End Class