Public Class Item_Wise_Stock

    Private Sub Item_Wise_Stock_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub Item_Wise_Stock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0 : Me.Left = 0
        Me.BackColor = Color.FromArgb(169, 223, 191)
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True : Dim mindate, maxdate As String
        mindate = clsFun.ExecScalarStr("Select min(EntryDate) as entrydate from Trans")
        maxdate = clsFun.ExecScalarStr("Select max(entrydate) as entrydate from Trans")
        If mindate = "" Then mskFromDate.Text = Date.Today.ToString("dd-MM-yyyy") Else mskFromDate.Text = CDate(mindate).ToString("dd-MM-yyyy")
        If maxdate = "" Then MsktoDate.Text = Date.Today.ToString("dd-MM-yyyy") Else MsktoDate.Text = CDate(maxdate).ToString("dd-MM-yyyy")
        mskFromDate.Text = clsFun.convdate(mskFromDate.Text) : MsktoDate.Text = clsFun.convdate(MsktoDate.Text)
        RowCloumns() : RadioMainAlt.Checked = True
    End Sub
    Private Sub RowCloumns()
        dg1.ColumnCount = 9
        dg1.Columns(0).Name = "ID" : dg1.Columns(0).Visible = False
        dg1.Columns(1).Name = "Date" : dg1.Columns(1).Width = 100
        dg1.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dg1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dg1.Columns(2).Name = "Type" : dg1.Columns(2).Width = 100
        dg1.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dg1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dg1.Columns(3).Name = "Invoice No" : dg1.Columns(3).Width = 120
        dg1.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dg1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dg1.Columns(4).Name = "Account Name" : dg1.Columns(4).Width = 370
        dg1.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dg1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dg1.Columns(5).Name = "Price " : dg1.Columns(5).Width = 120 : dg1.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable : dg1.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dg1.Columns(6).Name = "Qty In" : dg1.Columns(6).Width = 120 : dg1.Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable : dg1.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dg1.Columns(7).Name = "Qty Out" : dg1.Columns(7).Width = 120 : dg1.Columns(7).SortMode = DataGridViewColumnSortMode.NotSortable : dg1.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dg1.Columns(8).Name = "Balance" : dg1.Columns(8).Width = 120 : dg1.Columns(8).SortMode = DataGridViewColumnSortMode.NotSortable : dg1.Columns(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub
    Private Sub Retrive()
        '  dg1.Rows.Clear()
        ' Dim opbal As String = String.Empty
        Dim sql As String = String.Empty
        Dim altOpqty As String = String.Empty
        Dim OpStock As String = String.Empty
        Dim QtyIn As String = "" : Dim QtyOut As String = ""
        Dim QtyInMain As String = "" : Dim QtyInAlt As String = ""
        Dim QtyOutMain As String = "" : Dim QtyOutAlt As String = ""
        Dim TotMain As String = "" : Dim TotAlt As String = ""
        Dim tot As Decimal = 0 : Dim dt As New DataTable
        Dim tmpOpMain As Double : Dim tmpOpAlt As Double
        Dim Conversion As String = Val(clsFun.ExecScalarStr("Select Conversion From items Where ID=" & Val(TxtItemID.Text) & ""))
        Dim CheckUnit As String = clsFun.ExecScalarStr("Select RatePer From items Where ID=" & Val(TxtItemID.Text) & "")
        opbal = clsFun.ExecScalarStr(" Select ifnull(OpStock,0) FROM items WHERE ID= " & Val(TxtItemID.Text) & "")

        'If RadioMainAlt.Checked = True Then
        altOpqty = Format(Val(clsFun.ExecScalarStr(" Select ifnull(LooseStock,0) FROM Items WHERE ID= " & Val(TxtItemID.Text) & "")) / Val(Conversion), "0.00")
        opbal = Val(opbal) + Val(altOpqty)
        'End If
        sql = "Select VoucherID,Entrydate,UnitName,Rate,(Select InvoiceNo From Vouchers Where ID=Trans.VoucherID) As InvoiceNo,(Select AccountName From Vouchers Where ID=Trans.VoucherID) As AccountName, TransType,AltQty,FreeQty,Qty as QtyIn,'0' as QtyOut from Trans " & _
            "where TransType in('Purchase','Scrap Item','Credit Note','Finished Goods') and ItemID=" & Val(TxtItemID.Text) & " and EntryDate Between '" & CDate(mskFromDate.Text).ToString("yyyy-MM-dd") & "' And '" & CDate(MsktoDate.Text).ToString("yyyy-MM-dd") & "' " & _
            "union all Select VoucherID,Entrydate,UnitName,Rate,(Select InvoiceNo From Vouchers Where ID=Trans.VoucherID) As InvoiceNo,(Select AccountName From Vouchers Where ID=Trans.VoucherID) As AccountName,TransType,AltQty,FreeQty,'0' as QtyIn ,Qty as QtyOut" & _
            " from Trans where TransType in('Sale','Debit Note','Raw Item') and ItemID=" & Val(TxtItemID.Text) & " and EntryDate Between '" & CDate(mskFromDate.Text).ToString("yyyy-MM-dd") & "' And '" & CDate(MsktoDate.Text).ToString("yyyy-MM-dd") & "' "
        dt = clsFun.ExecDataTable(sql)
        Dim dvData As DataView = New DataView(dt)
        'dvData.RowFilter = "EntryDate Between '" & mskFromDate.Text & "' And '" & MsktoDate.Text & "'"
        dvData.Sort = " [EntryDate],VoucherID asc"
        dt = dvData.ToTable
        dg1.Rows.Clear()
        If RadioMain.Checked = True Then
            Dim PrevPurchase As String = clsFun.ExecScalarStr(" Select Sum(Qty) FROM Trans WHERE ItemID= " & Val(TxtItemID.Text) & " and TransType in('Purchase','Scrap Item','Credit Note','Finished Goods') and  EntryDate < '" & CDate(mskFromDate.Text).ToString("yyyy-MM-dd") & "'")
            Dim PrevSale As String = clsFun.ExecScalarStr(" Select Sum(Qty) FROM Trans WHERE ItemID= " & Val(TxtItemID.Text) & " and TransType in('Sale','Debit Note','Raw Item') and  EntryDate < '" & CDate(mskFromDate.Text).ToString("yyyy-MM-dd") & "'")
            opbal = Val(Val(opbal) + Val(PrevPurchase)) - Val(PrevSale)
            txtOpeningStock.Text = opbal
        End If
        If radioAlt.Checked = True Then
            opbal = Val(opbal) * Conversion
            Dim PrevPurchase As String = Val(clsFun.ExecScalarStr(" Select Sum(Qty) FROM Trans WHERE ItemID= " & Val(TxtItemID.Text) & " and TransType in('Purchase','Scrap Item','Credit Note','Finished Goods') and  EntryDate < '" & CDate(mskFromDate.Text).ToString("yyyy-MM-dd") & "'")) * Conversion
            Dim PrevSale As String = Val(clsFun.ExecScalarStr(" Select Sum(Qty) FROM Trans WHERE ItemID= " & Val(TxtItemID.Text) & " and TransType in('Sale','Debit Note','Raw Item') and  EntryDate < '" & CDate(mskFromDate.Text).ToString("yyyy-MM-dd") & "'")) * Conversion
            opbal = Val(Val(opbal) + Val(PrevPurchase)) - Val(PrevSale)
            txtOpeningStock.Text = opbal
        End If
        If RadioMainAlt.Checked = True Then
            Dim PrevPurchase As String = clsFun.ExecScalarStr(" Select Sum(Qty) FROM Trans WHERE ItemID= " & Val(TxtItemID.Text) & " and TransType in('Purchase','Scrap Item','Credit Note','Finished Goods') and  EntryDate < '" & CDate(mskFromDate.Text).ToString("yyyy-MM-dd") & "'")
            Dim PrevSale As String = clsFun.ExecScalarStr(" Select Sum(Qty) FROM Trans WHERE ItemID= " & Val(TxtItemID.Text) & " and TransType in('Sale','Debit Note','Raw Item') and  EntryDate < '" & CDate(mskFromDate.Text).ToString("yyyy-MM-dd") & "'")
            opbal = Val(Val(opbal) + Val(PrevPurchase)) - Val(PrevSale)
            tmpOpMain = Math.Floor(opbal)
            tmpOpAlt = Math.Round(Math.Abs(tmpOpMain - opbal) * Conversion, 0)
            ' tmpOpMain = Math.Floor(opbal)
            txtOpeningStock.Text = tmpOpMain & " : " & Val(tmpOpAlt)
        End If
        Try
            If dt.Rows.Count > 0 Then
                If dt.Rows.Count >= 19 Then dg1.Columns(8).Width = 100 Else dg1.Columns(8).Width = 120
                Application.DoEvents()
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("VoucherID").ToString()
                        .Cells(1).Value = Format(dt.Rows(i)("EntryDate"), "dd-MM-yyyy")
                        .Cells(2).Value = dt.Rows(i)("TransType").ToString()
                        .Cells(3).Value = dt.Rows(i)("InvoiceNo").ToString()
                        .Cells(4).Value = dt.Rows(i)("AccountName").ToString()
                        .Cells(5).Value = Format(Val(dt.Rows(i)("Rate").ToString()), "0.00")
                        If RadioMain.Checked = True Then
                            QtyIn = 0 : QtyOut = 0
                            If dt.Rows(i)("UnitName").ToString() = CheckUnit Then
                                If dt.Rows(i)("TransType").ToString() = "Purchase" Or dt.Rows(i)("TransType").ToString() = "Credit Note" Or dt.Rows(i)("TransType").ToString() = "Scrap Item" Or dt.Rows(i)("TransType").ToString() = "Finished Goods" Then
                                    QtyIn = IIf(Val(dt.Rows(i)("QtyIn").ToString()) + Val(dt.Rows(i)("FreeQty").ToString()) = 0, "", Val(dt.Rows(i)("QtyIn").ToString()) + Val(dt.Rows(i)("FreeQty").ToString()))
                                    .Cells(6).Value = QtyIn
                                Else
                                    QtyOut = IIf(Val(dt.Rows(i)("QtyOut").ToString()) + Val(dt.Rows(i)("FreeQty").ToString()) = 0, "", Val(dt.Rows(i)("QtyOut").ToString()) + Val(dt.Rows(i)("FreeQty").ToString()))
                                    .Cells(7).Value = QtyOut
                                End If

                            Else
                                If Conversion > 0 Then
                                    If dt.Rows(i)("TransType").ToString() = "Purchase" Or dt.Rows(i)("TransType").ToString() = "Credit Note" Or dt.Rows(i)("TransType").ToString() = "Scrap Item" Or dt.Rows(i)("TransType").ToString() = "Finished Goods" Then
                                        QtyIn = IIf(Val(dt.Rows(i)("QtyIn").ToString()) + Val(dt.Rows(i)("FreeQty").ToString()) = 0, "", Val(dt.Rows(i)("QtyIn").ToString()) + Val(dt.Rows(i)("FreeQty").ToString()) / Conversion)
                                        .Cells(6).Value = QtyIn
                                    Else
                                        QtyOut = IIf(Val(dt.Rows(i)("QtyOut").ToString()) + Val(dt.Rows(i)("FreeQty").ToString()) = 0, "", Val(dt.Rows(i)("QtyOut").ToString()) + Val(dt.Rows(i)("FreeQty").ToString()) / Conversion)
                                        .Cells(7).Value = QtyOut
                                    End If

                                End If
                            End If
                        End If
                        If radioAlt.Checked = True Then
                            If dt.Rows(i)("UnitName").ToString() = CheckUnit Then
                                QtyIn = 0 : QtyOut = 0
                                If dt.Rows(i)("TransType").ToString() = "Purchase" Or dt.Rows(i)("TransType").ToString() = "Credit Note" Or dt.Rows(i)("TransType").ToString() = "Scrap Item" Or dt.Rows(i)("TransType").ToString() = "Finished Goods" Then
                                    QtyIn = IIf(Val(dt.Rows(i)("QtyIn").ToString()) + Val(dt.Rows(i)("FreeQty").ToString()) = 0, "", Val(Val(dt.Rows(i)("QtyIn").ToString()) + Val(dt.Rows(i)("FreeQty").ToString())) * Conversion)
                                    .Cells(6).Value = QtyIn
                                Else
                                    QtyOut = IIf(Val(dt.Rows(i)("QtyOut").ToString()) + Val(dt.Rows(i)("FreeQty").ToString()) = 0, "", Val(Val(dt.Rows(i)("QtyOut").ToString()) + Val(dt.Rows(i)("FreeQty").ToString())) * Conversion)
                                    .Cells(7).Value = QtyOut
                                End If
                            Else
                                If Conversion > 0 Then
                                    If dt.Rows(i)("TransType").ToString() = "Purchase" Or dt.Rows(i)("TransType").ToString() = "Credit Note" Or dt.Rows(i)("TransType").ToString() = "Scrap Item" Or dt.Rows(i)("TransType").ToString() = "Finished Goods" Then
                                        QtyOut = ""
                                        QtyIn = IIf(Val(dt.Rows(i)("AltQty").ToString()) + Val(dt.Rows(i)("FreeQty").ToString()) = 0, "", Val(dt.Rows(i)("AltQty").ToString()) + Val(dt.Rows(i)("FreeQty").ToString()) * Conversion)
                                    Else
                                        QtyIn = ""
                                        QtyOut = IIf(Val(dt.Rows(i)("AltQty").ToString()) + Val(dt.Rows(i)("FreeQty").ToString()) = 0, "", Val(dt.Rows(i)("AltQty").ToString()) + Val(dt.Rows(i)("FreeQty").ToString()) * Conversion)
                                    End If
                                    .Cells(6).Value = QtyIn : .Cells(7).Value = QtyOut
                                End If
                            End If
                        End If
                        If RadioMainAlt.Checked = True Then
                            '  If dt.Rows(i)("UnitName").ToString() = CheckUnit Then
                            If dt.Rows(i)("TransType").ToString() = "Purchase" Or dt.Rows(i)("TransType").ToString() = "Credit Note" Or dt.Rows(i)("TransType").ToString() = "Scrap Item" Or dt.Rows(i)("TransType").ToString() = "Finished Goods" Then
                                QtyOut = 0
                                QtyIn = IIf(Val(dt.Rows(i)("QtyIn").ToString()) + Val(dt.Rows(i)("FreeQty").ToString()) = 0, "", Val(dt.Rows(i)("QtyIn").ToString()) + Val(dt.Rows(i)("FreeQty").ToString()))
                                QtyInMain = Math.Floor(Val(QtyIn))
                                QtyInAlt = Math.Round(Math.Abs(QtyIn - QtyInMain) * Conversion, 0)
                                .Cells(6).Value = Val(QtyInMain) & " : " & Val(QtyInAlt)

                            Else
                                QtyIn = 0
                                QtyOut = IIf(Val(dt.Rows(i)("QtyOut").ToString()) + Val(dt.Rows(i)("FreeQty").ToString()) = 0, "", Val(dt.Rows(i)("QtyOut").ToString()) + Val(dt.Rows(i)("FreeQty").ToString()))
                                QtyOutMain = Math.Floor(Val(QtyOut))
                                QtyOutAlt = Math.Round(Math.Abs(QtyOut - QtyOutMain) * Conversion, 0)
                                .Cells(7).Value = Val(QtyOutMain) & " : " & QtyOutAlt '.Cells(7).Value = QtyOut
                            End If
                            'End If
                        End If
                        If RadioMainAlt.Checked <> True Then
                            If i = 0 Then tot = Val(txtOpeningStock.Text + Val(QtyIn)) - Val(QtyOut) Else tot = Val(tot + Val(QtyIn)) - Val(QtyOut)
                            .Cells(8).Value = tot
                        Else
                            If i = 0 Then tot = Val(opbal + tot + Val(QtyIn)) - Val(QtyOut) Else tot = Val(tot + Val(QtyIn)) - Val(QtyOut)
                            '  tot = Val(opbal + tot + Val(QtyIn)) - Val(QtyOut)
                            TotMain = Math.Truncate(Val(tot))
                            'If opbal = 0 Then
                            '    TotMain = Math.Floor(Val(tot))
                            'ElseIf opbal > 0 Then
                            '    TotMain = Math.Floor(Val(tot))
                            'Else
                            '    TotMain = Math.Floor(Val(tot))
                            'End If


                            TotAlt = Math.Round(Val(tot - TotMain) * Conversion, 0)
                            If Math.Abs(Val(TotAlt)) > Conversion Then
                                TotMain = 0
                                TotMain = TotAlt / Conversion
                                TotMain = Math.Floor(Val(tot)) + TotMain
                                tot = Math.Truncate(Val(TotMain))
                                TotAlt = Math.Round(Val(Math.Floor(Val(tot)) - TotMain) * Conversion, 0)
                            End If
                            .Cells(8).Value = Val(TotMain) & " : " & Val(TotAlt)
                        End If

                    End With
                Next
            End If
        Catch ex As Exception

        End Try
        dg1.ClearSelection() : calc()
    End Sub
    Sub calc()
        txtTotalIn.Text = Format(0, "0.00") : txtTotalOut.Text = Format(0, "0.00")
        txtTotalBal.Text = Format(0, "0.00") ': txtBalanceQty.Text = Format(0, "0.00")
        Dim i As Integer
        For i = 0 To dg1.Rows.Count - 1
            If i = 0 Then txtTotalIn.Text = Format(Val(txtOpeningStock.Text) + Val(txtTotalIn.Text) + Val(dg1.Rows(i).Cells(6).Value), "0.00") Else txtTotalIn.Text = Format(Val(txtTotalIn.Text) + Val(dg1.Rows(i).Cells(6).Value), "0.00")
            txtTotalOut.Text = Format(Val(txtTotalOut.Text) + Val(dg1.Rows(i).Cells(7).Value), "0.00")
            txtTotalBal.Text = Format(Val(txtTotalIn.Text) - Val(txtTotalOut.Text), "0.00")
            If RadioMainAlt.Checked = True Then
                Dim TmpID As Integer = Val(dg1.Rows.Count - 1)
                txtTotalBal.Text = dg1.Rows(TmpID).Cells(8).Value
            End If

        Next
    End Sub
    Private Sub ItemRowColumns()
        dgItemSearch.ColumnCount = 6
        dgItemSearch.Columns(0).Name = "ID" : dgItemSearch.Columns(0).Visible = False
        dgItemSearch.Columns(1).Name = "Item Name" : dgItemSearch.Columns(1).Width = 548
        retriveItems()
    End Sub
    Private Sub retriveItems(Optional ByVal condtion As String = "")
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("Select Id,ItemName From Items  " & condtion & " order by ItemName  Limit 20")
        Try
            If dt.Rows.Count > 0 Then
                dgItemSearch.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dgItemSearch.Rows.Add()
                    With dgItemSearch.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("id").ToString()
                        .Cells(1).Value = dt.Rows(i)("ItemName").ToString()
                    End With
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "AccoBook")
        End Try
    End Sub
    Private Sub txtItem_GotFocus(sender As Object, e As EventArgs) Handles txtItem.GotFocus
        If dgItemSearch.ColumnCount = 0 Then ItemRowColumns()
        If dgItemSearch.RowCount = 0 Then retriveItems()
        If txtItem.Text.Trim() <> "" Then
            retriveItems(" Where upper(ItemName) Like upper('" & txtItem.Text.Trim() & "%')")
        Else
            retriveItems()
        End If
        If dgItemSearch.SelectedRows.Count = 0 Then dgItemSearch.Visible = True : txtItem.Focus()
        txtItem.SelectionStart = 0 : txtItem.SelectionLength = Len(txtItem.Text)
    End Sub
    Private Sub dgItemSearch_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgItemSearch.CellClick
        If dgItemSearch.RowCount = 0 Then Exit Sub
        txtItem.Clear() : TxtItemID.Clear()
        TxtItemID.Text = Val(dgItemSearch.SelectedRows(0).Cells(0).Value)
        txtItem.Text = dgItemSearch.SelectedRows(0).Cells(1).Value
        mskFromDate.Focus() : dgItemSearch.Visible = False
    End Sub
    Private Sub txtItem_KeyUp(sender As Object, e As KeyEventArgs) Handles txtItem.KeyUp
        If txtItem.Text.Trim() <> "" Then
            retriveItems(" Where upper(ItemName) Like upper('%" & txtItem.Text.Trim() & "%')")
        Else
            retriveItems()
        End If
        If e.KeyCode = Keys.Escape Then dgItemSearch.Visible = False
    End Sub

    Private Sub txtItem_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtItem.KeyPress
        e.Handled = (e.KeyChar = "'") Or (e.KeyChar = """")
        dgItemSearch.Visible = True
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub mskFromDate_GotFocus(sender As Object, e As EventArgs) Handles mskFromDate.GotFocus
        mskFromDate.SelectionStart = 0 : mskFromDate.SelectionLength = Len(mskFromDate.Text)
        If dgItemSearch.ColumnCount = 0 Then ItemRowColumns()
        If dgItemSearch.Rows.Count = 0 Then retriveItems()
        If dgItemSearch.SelectedRows.Count = 0 Then dgItemSearch.Visible = True : txtItem.Focus() : Exit Sub
        TxtItemID.Text = Val(dgItemSearch.SelectedRows(0).Cells(0).Value)
        txtItem.Text = dgItemSearch.SelectedRows(0).Cells(1).Value
        dgItemSearch.Visible = False
    End Sub
    Private Sub MsktoDate_GotFocus(sender As Object, e As EventArgs) Handles MsktoDate.GotFocus
        MsktoDate.SelectionStart = 0 : MsktoDate.SelectionLength = Len(MsktoDate.Text)
    End Sub
    Private Sub mskFromDate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mskFromDate.Validating
        mskFromDate.Text = clsFun.convdate(mskFromDate.Text)
    End Sub

    Private Sub MsktoDate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MsktoDate.Validating
        MsktoDate.Text = clsFun.convdate(MsktoDate.Text)
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

    Private Sub mskFromDate_KeyDown(sender As Object, e As KeyEventArgs) Handles mskFromDate.KeyDown, MsktoDate.KeyDown, RadioMainAlt.KeyDown,
        radioAlt.KeyDown, RadioMain.KeyDown, txtItem.KeyDown
        If e.KeyCode = Keys.Enter Then SendKeys.Send("{TAB}")
        If txtItem.Focused Then If e.KeyCode = Keys.Down Then dgItemSearch.Focus()
        If txtItem.Focused Then
            If e.KeyCode = Keys.F1 Then
                Items.MdiParent = MainScreenForm
                Items.Show()
                Items.FillControls(Val(TxtItemID.Text))
            End If

        End If



    End Sub

    Private Sub dgItemSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles dgItemSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgItemSearch.RowCount = 0 Then Exit Sub
            txtItem.Clear() : TxtItemID.Clear()
            TxtItemID.Text = Val(dgItemSearch.SelectedRows(0).Cells(0).Value)
            txtItem.Text = dgItemSearch.SelectedRows(0).Cells(1).Value
            mskFromDate.Focus() : dgItemSearch.Visible = False
        End If
    End Sub

    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        Retrive()
        'If RadioMain.Checked = True Then Retrive() : Exit Sub
        'If radioAlt.Checked = True Then Retrive() : Exit Sub
        'If RadioMain.Checked = True Then RetriveAllQty() : Exit Sub
    End Sub

    Private Sub dg1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg1.CellClick

    End Sub

    Private Sub dg1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg1.CellDoubleClick
        If dg1.SelectedRows.Count = 0 Then Exit Sub
        Dim id As Integer = dg1.SelectedRows(0).Cells(0).Value
        Dim type As String = dg1.SelectedRows(0).Cells(2).Value
        If type = "Purchase" Then
            Purchase.MdiParent = MainScreenForm
            Purchase.Show()
            Purchase.FillControl(id)
            Purchase.BringToFront()
        End If
    End Sub

    Private Sub dg1_KeyDown(sender As Object, e As KeyEventArgs) Handles dg1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dg1.SelectedRows.Count = 0 Then Exit Sub
            Dim id As Integer = dg1.SelectedRows(0).Cells(0).Value
            Dim type As String = dg1.SelectedRows(0).Cells(2).Value
            If type = "Purchase" Then
                Purchase.MdiParent = MainScreenForm
                Purchase.Show()
                Purchase.FillControl(id)
                Purchase.BringToFront()
            End If
            'If type = "Debit Note" Then
            '    Purchase_Return.MdiParent = MainScreenForm
            '    Purchase_Return.Show()
            '    Purchase_Return.FillControl(id)
            '    Purchase_Return.BringToFront()
            'End If
            'If type = "Credit Note" Then
            '    Sale_Return.MdiParent = MainScreenForm
            '    Sale_Return.Show()
            '    Sale_Return.FillControl(id)
            '    Sale_Return.BringToFront()
            'End If
        End If
    End Sub

    Private Sub RadioMain_CheckedChanged(sender As Object, e As EventArgs) Handles RadioMain.CheckedChanged
        Retrive()
    End Sub

    Private Sub radioAlt_CheckedChanged(sender As Object, e As EventArgs) Handles radioAlt.CheckedChanged
        Retrive()
    End Sub

    Private Sub RadioMainAlt_CheckedChanged(sender As Object, e As EventArgs) Handles RadioMainAlt.CheckedChanged
        Retrive()
    End Sub

    Private Sub dg1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dg1.MouseDoubleClick
        If dg1.SelectedRows.Count = 0 Then Exit Sub
        Dim id As Integer = dg1.SelectedRows(0).Cells(0).Value
        Dim type As String = dg1.SelectedRows(0).Cells(2).Value
        If type = "Purchase" Then
            Purchase.MdiParent = MainScreenForm
            Purchase.Show()
            Purchase.FillControl(id)
            Purchase.BringToFront()
        End If
        'If type = "Debit Note" Then
        '    Purchase_Return.MdiParent = MainScreenForm
        '    Purchase_Return.Show()
        '    Purchase_Return.FillControl(id)
        '    Purchase_Return.BringToFront()
        'End If
        'If type = "Credit Note" Then
        '    Sale_Return.MdiParent = MainScreenForm
        '    Sale_Return.Show()
        '    Sale_Return.FillControl(id)
        '    Sale_Return.BringToFront()
        'End If
    End Sub

    Private Sub btnPrintList_Click(sender As Object, e As EventArgs) Handles btnPrintList.Click
        If dg1.RowCount = 0 Then MsgBox("No Record to Print...", vbExclamation.Exclamation, "Access Denied") : Exit Sub
        PrintRecord()
        If Application.OpenForms().OfType(Of Item_Wise_Stock).Any = False Then Exit Sub
        Report_Viewer.printReport("\Reports\ItemWiseStock.rpt")
        Report_Viewer.MdiParent = MainScreenForm
        Report_Viewer.Show() : Report_Viewer.BringToFront()
    End Sub
    Private Sub PrintRecord()
        Dim cmd As New SQLite.SQLiteCommand
        Dim sql As String = ""
        ClsFunPrimary.ExecNonQuery("Delete from printing")
        ' clsFun.ExecNonQuery(sql)
        pnlWait.Visible = True
        pb1.Minimum = 0
        Dim i As Integer = 0
        For Each row As DataGridViewRow In dg1.Rows
            Application.DoEvents()
            With row
                pb1.Maximum = dg1.Rows.Count - 1
                pb1.Value = Val(row.Index)
                sql = "insert into Printing(D1,D2,M1,M2,P1,P2,P3,P4,P5,P6,P7,P8,M3,M4,M5) Values( " & _
                      "'" & mskFromDate.Text & "','" & MsktoDate.Text & "','" & txtItem.Text & "','" & txtOpeningStock.Text & "','" & .Cells(1).Value & "','" & .Cells(2).Value & "','" & .Cells(3).Value & "','" & .Cells(4).Value & "'," & _
                      "'" & .Cells(5).Value & "','" & .Cells(6).Value & "','" & .Cells(7).Value & "','" & .Cells(8).Value & "','" & txtTotalIn.Text & "','" & txtTotalOut.Text & "','" & txtTotalBal.Text & "')"
                Try
                    cmd = New SQLite.SQLiteCommand(sql, ClsFunPrimary.GetConnection())
                    ClsFunPrimary.ExecNonQuery(sql)
                Catch ex As Exception
                    MsgBox(ex.Message)
                    ClsFunPrimary.CloseConnection()
                    pnlWait.Visible = False
                End Try
            End With
        Next
        pnlWait.Visible = False
    End Sub
End Class