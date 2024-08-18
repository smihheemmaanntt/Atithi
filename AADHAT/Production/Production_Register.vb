﻿Public Class Production_Register

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
        dg1.ColumnCount = 6
        dg1.Columns(0).Name = "ID" : dg1.Columns(0).Visible = False
        dg1.Columns(1).Name = "Date" : dg1.Columns(1).Width = 150
        dg1.Columns(2).Name = "V No" : dg1.Columns(2).Width = 150
        dg1.Columns(3).Name = "Receipe Name" : dg1.Columns(3).Width = 350
        dg1.Columns(4).Name = "Item Name" : dg1.Columns(4).Width = 350
        dg1.Columns(5).Name = "Qty" : dg1.Columns(5).Width = 150
    End Sub
    Private Sub retrive(Optional ByVal condtion As String = "")
        dg1.Rows.Clear() : Dim dt As New DataTable
        '    dt = clsFun.ExecDataTable("Select * from Trans_View Where EntryDate Between '" & CDate(mskFromDate.Text).ToString("yyyy-MM-dd") & "' And '" & CDate(MsktoDate.Text).ToString("yyyy-MM-dd") & "' and transtype='" & Me.Text & "' " & condtion & "  order by ID ")
        dt = clsFun.ExecDataTable("Select * From Vouchers Where EntryDate Between '" & CDate(mskFromDate.Text).ToString("yyyy-MM-dd") & "' And '" & CDate(MsktoDate.Text).ToString("yyyy-MM-dd") & "' and transtype='" & Me.Text & "' " & condtion & "  order by ID ")
        Dim vchid As Integer = 0
        Try
            If dt.Rows.Count > 0 Then
                dg1.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("ID").ToString()
                        .Cells(1).Value = CDate(dt.Rows(i)("EntryDate")).ToString("dd-MM-yyyy")
                        .Cells(2).Value = dt.Rows(i)("InvoiceNo").ToString()
                        .Cells(3).Value = dt.Rows(i)("ProcessName").ToString()
                        .Cells(4).Value = dt.Rows(i)("ItemName").ToString()
                        .Cells(5).Value = dt.Rows(i)("TotQty").ToString()
                    End With
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "AADHAT")
        End Try
        calc() : dg1.ClearSelection()
    End Sub
    Sub calc()
        txttotQty.Text = Format(0, "0.00")
        For i = 0 To dg1.Rows.Count - 1
            txttotQty.Text = Format(Val(txttotQty.Text) + Val(dg1.Rows(i).Cells(5).Value), "0.00")
        Next
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

    Private Sub dg1_KeyDown(sender As Object, e As KeyEventArgs) Handles dg1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dg1.SelectedRows.Count = 0 Then Exit Sub
            Dim tmpID As Integer = Val(dg1.SelectedRows(0).Cells(0).Value)
            Production.MdiParent = MainScreenForm
            Production.Show() : Production.FillControls(tmpID)
            Production.BringToFront()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub dg1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dg1.MouseDoubleClick
        If dg1.SelectedRows.Count = 0 Then Exit Sub
        Dim tmpID As Integer = Val(dg1.SelectedRows(0).Cells(0).Value)
        Production.MdiParent = MainScreenForm
        Production.Show() : Production.FillControls(tmpID)
        Production.BringToFront()
    End Sub
End Class