Public Class Stock_Status

    Private Sub Purchase_Register_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub
    Private Sub Purchase_Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0 : Me.Left = 0
        Me.BackColor = Color.FromArgb(169, 223, 191)
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True : mskFromDate.Focus()
        Dim mindate, maxdate As String
        mindate = clsFun.ExecScalarStr("Select Max(EntryDate) as entrydate from Vouchers where transtype in('Purchase','Sale','Production')")
        If mindate = "" Then mskFromDate.Text = Date.Today.ToString("dd-MM-yyyy") Else mskFromDate.Text = CDate(mindate).ToString("dd-MM-yyyy")
        mskFromDate.Text = clsFun.convdate(mskFromDate.Text)
        rowColums()
    End Sub
    Private Sub mskFromDate_GotFocus(sender As Object, e As EventArgs) Handles mskFromDate.GotFocus
        mskFromDate.SelectionStart = 0 : mskFromDate.SelectionLength = Len(mskFromDate.Text)
    End Sub

    Private Sub mskFromDate_KeyDown(sender As Object, e As KeyEventArgs) Handles mskFromDate.KeyDown, btnShow.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            ProcessTabKey(True)
        End If
    End Sub
    Private Sub mskFromDate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mskFromDate.Validating
        mskFromDate.Text = clsFun.convdate(mskFromDate.Text)
    End Sub
    Private Sub rowColums()
        dg1.ColumnCount = 6
        dg1.Columns(0).Name = "ID" : dg1.Columns(0).Visible = False
        dg1.Columns(1).Name = "Item Name" : dg1.Columns(1).Width = 370 : dg1.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable : dg1.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dg1.Columns(2).Name = "Op Qty" : dg1.Columns(2).Width = 200 : dg1.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable : dg1.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dg1.Columns(3).Name = "Purchase/Scrap Qty" : dg1.Columns(3).Width = 200 : dg1.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable : dg1.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dg1.Columns(4).Name = "Sold/Raw Qty" : dg1.Columns(4).Width = 200 : dg1.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable : dg1.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dg1.Columns(5).Name = "Balance Qty " : dg1.Columns(5).Width = 200 : dg1.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable : dg1.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        ' dg1.Rows(0).ReadOnly = False
    End Sub
    Private Sub retrive(Optional ByVal condtion As String = "")
        dg1.Rows.Clear() : Dim dt As New DataTable
        'Dim sql As String = "SELECT I.ID as ItemID,I.ItemName as ItemName,ifnull(Sum(OpStockMain),0) +ifnull(Sum(OpStockalt)/cast(Conversion as real),0) as OpQty,(Select ifnull(Sum(Qty),0)+ifnull(Sum(FreeQty),0) from Trans1 Where ItemID=I.ID and TransType In ('Purchase','Credit Note') and EntryDate<='" & CDate(mskFromDate.Text).ToString("yyyy-MM-dd") & "') as PurchaseQty," & _
        '    "(Select ifnull(Sum(Qty),0)+ifnull(Sum(FreeQty),0) from Trans1 Where ItemID=I.ID and TransType In ('Sale','Debit Note') and EntryDate<='" & CDate(mskFromDate.Text).ToString("yyyy-MM-dd") & "') as SoldQty," & _
        '    " (ifnull(Sum(OpStockMain),0)+ifnull(Sum(OpStockalt)/cast(Conversion as real),0)+(Select ifnull(Sum(Qty),0)+ifnull(Sum(FreeQty),0) from Trans1 Where ItemID=I.ID and TransType In ('Purchase','Credit Note')and EntryDate<='" & CDate(mskFromDate.Text).ToString("yyyy-MM-dd") & "'))" & _
        '                "-(Select ifnull(Sum(Qty),0)+ifnull(Sum(FreeQty),0) from Trans1 Where ItemID=I.ID and TransType In ('Sale','Debit Note') and EntryDate<='" & CDate(mskFromDate.Text).ToString("yyyy-MM-dd") & "') " & _
        '                " as RestQty FROM Items AS I Inner JOIN Batch AS B ON B.ItemID=I.ID " & condtion & " Group By ItemID Having RestQty<>0 order by Upper(ItemName) "
        Dim sql As String = "SELECT ID as ItemID,ItemName ,ifnull(Sum(OpStock),0) +ifnull(Sum(LooseStock)/cast(Conversion as real),0) as OpQty," & _
        " (Select ifnull(Sum(Qty),0)+ifnull(Sum(FreeQty),0) from Trans Where ItemID=ID and TransType In ('Purchase','Scrap Item','Credit Note','Finished Goods') and EntryDate<='" & CDate(mskFromDate.Text).ToString("yyyy-MM-dd") & "') as PurchaseQty," & _
        " (Select ifnull(Sum(Qty),0)+ifnull(Sum(FreeQty),0) from Trans Where ItemID=ID and TransType In ('Sale','Debit Note','Raw Item') and EntryDate<='" & CDate(mskFromDate.Text).ToString("yyyy-MM-dd") & "') as SoldQty, " & _
        " (ifnull(Sum(OpStock),0)+ifnull(Sum(LooseStock)/cast(Conversion as real),0)+(Select ifnull(Sum(Qty),0)+ifnull(Sum(FreeQty),0) from Trans Where ItemID=ID  " & _
        " and TransType In ('Purchase','Scrap Item','Credit Note','Finished Goods')and EntryDate<='" & CDate(mskFromDate.Text).ToString("yyyy-MM-dd") & "'))-(Select ifnull(Sum(Qty),0)+ifnull(Sum(FreeQty),0) from Trans Where ItemID=ID " & _
        " and TransType In ('Sale','Debit Note','Raw Item') and EntryDate<='" & CDate(mskFromDate.Text).ToString("yyyy-MM-dd") & "') as RestQty FROM Items Group By ItemID Having RestQty<>0 order by Upper(ItemName) "
        dt = clsFun.ExecDataTable(Sql)
        If dt.Rows.Count > 10 Then dg1.Columns(5).Width = 180 Else dg1.Columns(5).Width = 200
        Try
            If dt.Rows.Count > 0 Then
                dg1.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        .Cells(1).readonly = True : .Cells(2).readonly = True
                        .Cells(3).readonly = True : .Cells(4).readonly = True
                        .Cells(5).readonly = True
                        .Cells(2).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Cells(3).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Cells(4).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Cells(5).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Cells(0).Value = dt.Rows(i)("ItemID").ToString()
                        .Cells(1).Value = dt.Rows(i)("ItemName").ToString()
                        .Cells(2).Value = Format(Val(dt.Rows(i)("OpQty").ToString()), "0.00")
                        .Cells(3).Value = Format(Val(dt.Rows(i)("PurchaseQty").ToString()), "0.00")
                        .Cells(4).Value = Format(Val(dt.Rows(i)("SoldQty").ToString()), "0.00")
                        .Cells(5).Value = Format(Val(dt.Rows(i)("RestQty").ToString()), "0.00")
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
        txtOpQty.Text = Format(0, "0.00") : txtPurchaseQty.Text = Format(0, "0.00")
        txtSoldQty.Text = Format(0, "0.00") : txtBalanceQty.Text = Format(0, "0.00")
        Dim i As Integer
        For i = 0 To dg1.Rows.Count - 1
            txtOpQty.Text = Format(Val(txtOpQty.Text) + Val(dg1.Rows(i).Cells(2).Value), "0.00")
            txtPurchaseQty.Text = Format(Val(txtPurchaseQty.Text) + Val(dg1.Rows(i).Cells(3).Value), "0.00")
            txtSoldQty.Text = Format(Val(txtSoldQty.Text) + Val(dg1.Rows(i).Cells(4).Value), "0.00")
            txtBalanceQty.Text = Format(Val(txtBalanceQty.Text) + Val(dg1.Rows(i).Cells(5).Value), "0.00")
        Next
    End Sub

    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        retrive()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub dtp1_GotFocus(sender As Object, e As EventArgs) Handles dtp1.GotFocus
        mskFromDate.Focus()
    End Sub

    Private Sub dtp1_ValueChanged(sender As Object, e As EventArgs) Handles dtp1.ValueChanged
        mskFromDate.Text = dtp1.Value.ToString("dd-MM-yyyy")
        mskFromDate.Text = clsFun.convdate(mskFromDate.Text)
    End Sub

    Private Sub dg1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg1.CellClick
        dg1.ClearSelection()
    End Sub

    Private Sub txtItemSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtItemSearch.KeyDown

    End Sub

    Private Sub txtItemSearch_KeyUp(sender As Object, e As KeyEventArgs) Handles txtItemSearch.KeyUp
        If dg1.ColumnCount = 0 Then rowColums()
        If dg1.RowCount = 0 Then retrive()
        If txtItemSearch.Text.Trim() <> "" Then
            retrive(" Where upper(I.ItemName) Like upper('" & txtItemSearch.Text.Trim() & "%')")
        Else
            retrive()
        End If
    End Sub

    Private Sub dg1_KeyDown(sender As Object, e As KeyEventArgs) Handles dg1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dg1.SelectedRows.Count = 0 Then Exit Sub
            Item_Wise_Stock.MdiParent = MainScreenForm
            Item_Wise_Stock.TxtItemID.Text = (dg1.SelectedRows(0).Cells(0).Value)
            Item_Wise_Stock.txtItem.Text = clsFun.ExecScalarStr("Select ItemName From Items Where ID=" & Val(dg1.SelectedRows(0).Cells(0).Value) & "")
            Item_Wise_Stock.Show() : Item_Wise_Stock.dgItemSearch.Visible = False
            Item_Wise_Stock.btnShow.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub dg1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dg1.MouseDoubleClick
        If dg1.SelectedRows.Count = 0 Then Exit Sub
        Item_Wise_Stock.MdiParent = MainScreenForm
        Item_Wise_Stock.TxtItemID.Text = (dg1.SelectedRows(0).Cells(0).Value)
        Item_Wise_Stock.txtItem.Text = clsFun.ExecScalarStr("Select ItemName From Items Where ID=" & Val(dg1.SelectedRows(0).Cells(0).Value) & "")
        Item_Wise_Stock.Show() : Item_Wise_Stock.dgItemSearch.Visible = False
        Item_Wise_Stock.btnShow.PerformClick()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If dg1.RowCount = 0 Then MsgBox("No Record to Print...", vbExclamation.Exclamation, "Access Denied") : Exit Sub
        PrintRecord()
        If Application.OpenForms().OfType(Of Stock_Status).Any = False Then Exit Sub
        Report_Viewer.printReport("\Reports\StockStatus.rpt")
        Report_Viewer.MdiParent = MainScreenForm
        Report_Viewer.Show() : Report_Viewer.BringToFront()
    End Sub
    'Private Sub PrintRecord()
    '    Dim cmd As New SQLite.SQLiteCommand
    '    Dim sql As String = ""
    '    ClsFunPrimary.ExecNonQuery("Delete from printing")
    '    ' clsFun.ExecNonQuery(sql)
    '    pnlWait.Visible = True
    '    pb1.Minimum = 0
    '    Dim i As Integer = 0
    '    For Each row As DataGridViewRow In dg1.Rows
    '        Application.DoEvents()
    '        With row
    '            pb1.Maximum = dg1.Rows.Count - 1
    '            pb1.Value = Val(row.Index)
    '            sql = "insert into Printing(D1, P1,P2,P3,P4,P5, P6, P7, P8,P9) Values( " & _
    '                  "'" & mskFromDate.Text & "','" & .Cells(1).Value & "','" & .Cells(2).Value & "','" & .Cells(3).Value & "','" & .Cells(4).Value & "'," & _
    '                  "'" & .Cells(5).Value & "','" & Format(Val(txtOpQty.Text), Hash) & "', " & _
    '                  "'" & Format(Val(txtPurchaseQty.Text), Hash) & "','" & Format(Val(txtSoldQty.Text), Hash) & "', " & _
    '                  "'" & Format(Val(txtBalanceQty.Text), Hash) & "')"
    '            Try
    '                cmd = New SQLite.SQLiteCommand(sql, ClsFunPrimary.GetConnection())
    '                ClsFunPrimary.ExecNonQuery(sql)
    '            Catch ex As Exception
    '                MsgBox(ex.Message)
    '                ClsFunPrimary.CloseConnection()
    '                pnlWait.Visible = False
    '            End Try
    '        End With
    '    Next
    '    pnlWait.Visible = False
    'End Sub

    Private Sub PrintRecord()
        Dim AllRecord As Integer = Val(dg1.Rows.Count)
        Dim maxRowCount As Decimal = Math.Ceiling(AllRecord / 100)
        Dim FastQuery As String = String.Empty
        Dim sQL As String = String.Empty
        Dim LastCount As Integer = 0
        pnlWait.Visible = True
        Dim TotalRecord As Integer = 0
        Dim LastRecord As Integer = 0
        ClsFunPrimary.ExecNonQuery("Delete from printing")
        For i As Integer = 0 To maxRowCount - 1
            Application.DoEvents()
            FastQuery = String.Empty : TotalRecord = (AllRecord - LastRecord)
            For LastCount = 0 To IIf(i = (maxRowCount - 1), Val(TotalRecord - 1), 99)
                With dg1.Rows(LastRecord)
                    FastQuery = FastQuery & IIf(FastQuery <> "", " UNION ALL SELECT ", " SELECT ") & "" & _
                      "'" & mskFromDate.Text & "','" & .Cells(1).Value & "','" & .Cells(2).Value & "','" & .Cells(3).Value & "','" & .Cells(4).Value & "'," & _
                      "'" & .Cells(5).Value & "','" & Format(Val(txtOpQty.Text), Hash) & "', " & _
                      "'" & Format(Val(txtPurchaseQty.Text), Hash) & "','" & Format(Val(txtSoldQty.Text), Hash) & "', " & _
                      "'" & Format(Val(txtBalanceQty.Text), Hash) & "'"
                End With
                LastRecord = Val(LastRecord + 1)
            Next
            ' LastRecord = LastCount
            Try
                If FastQuery = String.Empty Then Exit Sub
                sQL = "insert into Printing(D1,P1, P2,P3, P4,P5,P6,P7,P8,P9) " & FastQuery & ""
                ClsFunPrimary.ExecNonQuery(sQL)
            Catch ex As Exception
                MsgBox(ex.Message)
                ClsFunPrimary.CloseConnection()
            End Try

        Next


        pnlWait.Visible = False
    End Sub

    Private Sub dg1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg1.CellContentClick

    End Sub
End Class