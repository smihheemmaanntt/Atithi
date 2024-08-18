Imports System.IO
Public Class Food_Bill
    Dim sql As String = String.Empty
    Dim vchID As Integer = 0
    Dim TotalPages As Integer = 0 : Dim PageNumber As Integer = 0
    Dim RowCount As Integer = 1 : Dim Offset As Integer = 0
    ' Dim CustomMsgBox As CustomMessageBox = New CustomMessageBox()
    Private Sub KOT_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If dgItemSearch.Visible = True Then dgItemSearch.Visible = False : txtItem.Focus() : Exit Sub
            If dg1.RowCount = 0 Then Me.Close() : Exit Sub
            If MessageBox.Show("Are you Sure Want to Exit FOOD BILL ENTRY ???", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Close() : Exit Sub
            End If
            If pnlCreditBalance.Visible = True Then
                pnlCeditClear()
            Else
                Me.Close()
            End If
        End If
        If e.KeyCode = Keys.F12 Then
            pnlCreditBalance.Visible = True
            txtTotChange.Text = Format(txtTotCash.Text, "0.00")
            txtCardPayment.Text = Format(Val(txtTotChange.Text), "0.00")
            If BtnSave.Text <> "&Save" Then Exit Sub
            txtTotCash.Text = Format(0, "0.00")
            'txtCardPayment.Visible = True
        End If
    End Sub
    Private Sub KOT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0 : Me.Left = 0
        clsFun.FillDropDownList(cbState, "Select ID,StateName || ' - ' || CASE WHEN StateGSTCodes < 10 THEN '0' ELSE '' END || StateGSTCodes as State  From StateList ", "State", "Id", "--N.A.--")
        mskEntryDate.Text = Date.Today.ToString("dd-MM-yyyy")
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True : dg1Columns()
        cbServiceType.SelectedIndex = 0 : VNumber()
        ckWhatsapp.Checked = True
    End Sub

    Private Sub VNumber()
        Dim vno As Integer = 0
        If vno = Val(clsFun.ExecScalarInt("SELECT Max(InvoiceID) AS ID FROM Vouchers Where TransType='Food Bill' AND  ID= (Select mAX(ID) from Vouchers)")) <> 0 Then
            vno = clsFun.ExecScalarInt("SELECT Max(InvoiceID) AS ID FROM Vouchers Where TransType='Food Bill' AND  ID= (Select mAX(ID) from Vouchers)")
            txtBillNo.Text = vno + 1
            txtInvoiceID.Text = vno + 1
        Else
            vno = clsFun.ExecScalarInt("SELECT Max(InvoiceID) AS ID FROM Vouchers Where TransType='Food Bill' AND  ID= (Select mAX(ID) from Vouchers)")
            txtBillNo.Text = vno + 1
            txtInvoiceID.Text = vno + 1
        End If
    End Sub
    Private Sub TxtClear()
        txtItem.Clear() : txtQty.Clear()
        txtRate.Clear() : txtTotalAmt.Clear()
        txtItem.Focus() : txtTaxable.Clear()
    End Sub
    Private Sub txtClearAll()
        cbServiceType.Enabled = True
        VNumber() : TxtClear()
        dg1.Rows.Clear() : Dg2.Rows.Clear()
        txttotQty.Clear() : txtTotBasic.Clear()
        dgItemSearch.Visible = False
        mskEntryDate.Focus()
        BtnSave.Text = "&Save"
    End Sub
    Private Sub StockBal()
        Dim ItemStock As Decimal = 0.0
        Dim PurchaseStock As Decimal = 0.0
        Dim SaleStock As Decimal = 0.0
        Dim BalStock As String = 0.0
        Dim RestBal As String = 0.0
        Dim tmpbal As String = ""
        ItemStock = clsFun.ExecScalarDec("Select sum(OpStock) From Items Where ID='" & txtItemID.Text & "'")
        PurchaseStock = Val(clsFun.ExecScalarStr("Select sum(Qty) From Trans Where TransType ='Purchase' and ItemID='" & Val(txtItemID.Text) & "'"))
        SaleStock = Val(clsFun.ExecScalarStr("Select sum(Qty) From Trans Where TransType in('Bill','POS') and ItemID='" & Val(txtItemID.Text) & "'"))
        lblStock.Visible = True
        BalStock = Val(Val(ItemStock) + Val(PurchaseStock))
        RestBal = Val(BalStock) - Val(SaleStock)
        If BtnSave.Text = "&Save" Then
            If dg1.SelectedRows.Count = 0 Then
                If Val(SaleStock) = 0 Then ' if no record inserted
                    If dg1.RowCount = 0 Then ' if no rows addred
                        bal = (RestBal)
                    Else 'if rows count
                        For i As Integer = 0 To dg1.RowCount - 1
                            If dg1.Rows(i).Cells(0).Value = txtItemID.Text Then
                                tmpbal = Val(tmpbal) - Val(dg1.Rows(i).Cells(5).Value)
                            End If
                        Next i
                        tmpbal = Val(tmpbal)
                    End If
                    bal = Val(RestBal) - Val(tmpbal)
                Else
                    If dg1.RowCount = 0 Then ' if any Record Inserted in Database but Row not Added
                        bal = (RestBal)
                    Else
                        For i As Integer = 0 To dg1.RowCount - 1 'if any Record Inserted in Database and Row Added
                            If dg1.Rows(i).Cells(0).Value = txtItemID.Text Then
                                tmpbal = Val(tmpbal) - Val(dg1.Rows(i).Cells(5).Value)
                            End If
                        Next i
                        bal = Val(RestBal) + Val(tmpbal)
                    End If
                End If
            Else
                If Val(SaleStock) = 0 Then
                    For i As Integer = 0 To dg1.RowCount - 1
                        If dg1.Rows(i).Cells(0).Value = txtItemID.Text Then
                            tmpbal = Val(tmpbal) - Val(dg1.Rows(i).Cells(5).Value)
                        End If
                    Next i
                    tmpbal = Val(RestBal) - Val(tmpbal)
                    tmpbal = Val(tmpbal) - Val(dg1.SelectedRows(0).Cells(5).Value)
                    bal = Val(tmpbal)
                Else
                    For i As Integer = 0 To dg1.RowCount - 1
                        If dg1.Rows(i).Cells(0).Value = txtItemID.Text Then
                            tmpbal = Val(tmpbal) - Val(dg1.Rows(i).Cells(5).Value)
                        End If
                    Next i
                    tmpbal = Val(RestBal) + Val(tmpbal)
                    tmpbal = (tmpbal) - Val(dg1.SelectedRows(0).Cells(5).Value)
                    bal = Val(tmpbal)
                End If
            End If
        End If
        '  End If
        lblStock.Text = "Stock : " & bal
    End Sub
    Private Sub dg2Columns()
        If cbServiceType.SelectedIndex = 0 Then
            lblServiceType.Text = "Choose Table" : Dg2.Visible = True
            Dg2.Columns.Clear() : Dg2.Rows.Clear()
            Dim checkBoxColumn As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
            checkBoxColumn.HeaderText = "" : checkBoxColumn.Width = 40
            checkBoxColumn.Name = "Present" : Dg2.Columns.Insert(0, checkBoxColumn)
            Dg2.ColumnCount = 3
            Dg2.Columns(1).Name = "id" : Dg2.Columns(1).Visible = False
            Dg2.Columns(2).Name = "Table Name" : Dg2.Columns(2).Width = 210
            retriveTables()
        ElseIf cbServiceType.SelectedIndex = 1 Then
            lblServiceType.Text = "Choose Room" : Dg2.Visible = True
            Dg2.Columns.Clear() : Dg2.Rows.Clear()
            Dim checkBoxColumn As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
            checkBoxColumn.HeaderText = "" : checkBoxColumn.Width = 40
            checkBoxColumn.Name = "Present" : Dg2.Columns.Insert(0, checkBoxColumn)
            Dg2.ColumnCount = 3
            Dg2.Columns(1).Name = "id" : Dg2.Columns(1).Visible = False
            Dg2.Columns(2).Name = "Room No." : Dg2.Columns(2).Width = 210
        ElseIf cbServiceType.SelectedIndex = 2 Then
            Dg2.Columns.Clear() : Dg2.Rows.Clear()
            Dg2.Visible = False : lblServiceType.Visible = False
        ElseIf cbServiceType.SelectedIndex = 3 Then
            lblServiceType.Text = "Choose Table" : Dg2.Visible = True
            Dg2.Columns.Clear() : Dg2.Rows.Clear()
            Dim checkBoxColumn As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
            checkBoxColumn.HeaderText = "" : checkBoxColumn.Width = 40
            checkBoxColumn.Name = "Present" : Dg2.Columns.Insert(0, checkBoxColumn)
            Dg2.ColumnCount = 3
            Dg2.Columns(1).Name = "id" : Dg2.Columns(1).Visible = False
            Dg2.Columns(2).Name = "Table Name" : Dg2.Columns(2).Width = 210
            Dg2.Columns(0).ReadOnly = False
            retriveTables()
        End If
    End Sub
    Private Sub dg1Columns()
        dg1.ColumnCount = 21
        dg1.Columns(0).Name = "Itemid" : dg1.Columns(0).Visible = False
        dg1.Columns(1).Name = "No" : dg1.Columns(1).Width = 30
        dg1.Columns(2).Name = "Code" : dg1.Columns(2).Visible = False
        dg1.Columns(3).Name = "Item Name" : dg1.Columns(3).Width = 170
        dg1.Columns(4).Name = "Unit" : dg1.Columns(4).Visible = False
        dg1.Columns(5).Name = "Qty" : dg1.Columns(5).Width = 70
        dg1.Columns(6).Name = "Rate" : dg1.Columns(6).Width = 83
        dg1.Columns(7).Name = "Basic" : dg1.Columns(7).Width = 84
        dg1.Columns(8).Name = "D%" : dg1.Columns(8).Width = 74
        dg1.Columns(9).Name = "Disc" : dg1.Columns(9).Width = 89
        dg1.Columns(10).Name = "T%" : dg1.Columns(10).Width = 74
        dg1.Columns(11).Name = "Tax" : dg1.Columns(11).Width = 89
        dg1.Columns(12).Name = "Total" : dg1.Columns(12).Width = 119
        dg1.Columns(13).Name = "Taxable" : dg1.Columns(13).Width = 108
        dg1.Columns(14).Name = "KOtDate" : dg1.Columns(14).Width = 108
        dg1.Columns(15).Name = "IGSTPer" : dg1.Columns(15).Visible = False
        dg1.Columns(16).Name = "IGSTAmt" : dg1.Columns(16).Visible = False
        dg1.Columns(17).Name = "CGSTPer" : dg1.Columns(17).Visible = False
        dg1.Columns(18).Name = "CGSTAmt" : dg1.Columns(18).Visible = False
        dg1.Columns(19).Name = "SGSTPer" : dg1.Columns(19).Visible = False
        dg1.Columns(20).Name = "SGSTAmt" : dg1.Columns(20).Visible = False
    End Sub
    'Private Sub taxDetails()
    '    Dim i As Integer = 0
    '    Dim AccountName As String
    '    Dim GSTType As String : Dim GSTIN As String
    '    Dim State As String : Dim StateCode As String
    '    Dim ssql As String = String.Empty
    '    Dim FastQuery As String = String.Empty
    '    Dim Sql As String = String.Empty
    '    clsFun.ExecScalarStr("Delete From TaxDetails Where VoucherID='" & (txtID.Text) & "'")
    '    AccountName = clsFun.ExecScalarStr("Select AccountName From Accounts Where ID=7")
    '    If Val(clsFun.ExecScalarStr("Select GroupID from Account_AcGrp Where ID=" & Val(txtAccountID.Text) & "")) <> 11 Then
    '        GSTType = clsFun.ExecScalarStr("Select GSTType from Account_AcGrp Where ID=" & Val(txtAccountID.Text) & "")
    '        GSTIN = clsFun.ExecScalarStr("Select GSTNo from Account_AcGrp Where ID=" & Val(txtAccountID.Text) & "")
    '        State = clsFun.ExecScalarStr("Select State from Account_AcGrp Where ID=" & Val(txtAccountID.Text) & "")
    '        State = clsFun.ExecScalarStr("Select State from Account_AcGrp Where ID=" & Val(txtAccountID.Text) & "")
    '        StateCode = Format(Val(clsFun.ExecScalarStr("Select StateCode from Account_AcGrp Where ID=" & Val(txtAccountID.Text) & "")), "00")
    '    Else
    '        AccountName = IIf(txtCustomerName.Text = "", AccountName, txtCustomerName.Text)
    '        GSTType = cbGSTtype.Text : GSTIN = txtGSTN.Text
    '        State = cbState.Text : StateCode = Format(Val(txtStateCode.Text), "00")
    '    End If
    '    For Each row As DataGridViewRow In dg1.Rows
    '        With row
    '            Dim Qty As Decimal = Val(.Cells(10).Value) + Val(.Cells(12).Value)
    '            Dim GSTUNit As String = clsFun.ExecScalarStr("Select GSTUnit From Unit Where ID='" & Val(.Cells(7).Value) & "'")
    '            Dim itemTaxableAmt As Decimal = Val(.Cells(14).Value) - Val(Val(.Cells(16).Value) + Val(.Cells(33).Value) + Val(.Cells(35).Value)) + Val(.Cells(50).Value)
    '            Dim ItemName As String = clsFun.ExecScalarStr("SELECT ItemName From Items Where ID='" & Val(.Cells(0).Value) & "'")
    '            Dim HSnCode As String = clsFun.ExecScalarStr("SELECT HSnCode From Items Where ID='" & Val(.Cells(0).Value) & "'")
    '            Dim SupplyType As String = clsFun.ExecScalarStr("SELECT SupplyType From Items Where ID='" & Val(.Cells(0).Value) & "'")
    '            Dim TaxID As Integer = clsFun.ExecScalarInt("SELECT T.ID as TaxID  FROM Items AS I INNER JOIN Taxation AS T ON I.TaxID = T.Id Where I.ID='" & Val(.Cells(0).Value) & "'")
    '            Dim TaxName As String = clsFun.ExecScalarStr("SELECT T.TaxName as TaxName  FROM Items AS I INNER JOIN Taxation AS T ON I.TaxID = T.Id Where I.ID='" & Val(.Cells(0).Value) & "'")
    '            Dim RCM As String = clsFun.ExecScalarStr("SELECT RCM From Items Where ID='" & Val(.Cells(0).Value) & "'")
    '            If RCM = "Yes" Then RCM = "Y" Else RCM = "N"
    '            FastQuery = FastQuery & IIf(FastQuery <> "", " UNION ALL SELECT ", " SELECT ") & Val(txtID.Text) & ",'" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "','" & Me.Text & "', '" & txtVoucherNo.Text & "','" & Val(txtAccountID.Text) & "','" & AccountName & "'," & _
    '                 "'" & IIf(i = 0, Val(txtTotTotal.Text), 0) & "','" & IIf(i = 0, Val(txtTotTaxable.Text), 0) & "','" & If(i = 0, Val(txtTotTaxAmt.Text), 0) & "','" & If(i = 0, Val(TotalIGST), 0) & "','" & If(i = 0, Val(TotalCGST), 0) & "','" & If(i = 0, Val(TotalSGST), 0) & "','" & If(i = 0, Val(TotalCess), 0) & "'," & _
    '                 "'" & Val(.Cells(0).Value) & "','" & ItemName & "','" & Val(Qty) & "','" & HSnCode & "','" & If(SupplyType = "Goods", GSTUNit, "NA") & "','" & Val(.Cells(19).Value) & "','" & Val(itemTaxableAmt) & "', '" & Val(TaxID) & "','" & TaxName & "'," & _
    '                 "'" & Val(.Cells(17).Value) & "','" & Val(.Cells(18).Value) & "','" & .Cells(40).Value & "','" & .Cells(41).Value & "','" & .Cells(42).Value & "','" & .Cells(43).Value & "', " & _
    '                 "'" & .Cells(44).Value & "','" & .Cells(45).Value & "','" & Val(0) & "','" & Val(.Cells(49).Value) & "','" & SupplyType & "','" & GSTType & "','" & GSTIN & "','" & State & "','" & StateCode & "','" & Val(txtTotTaxAmt.Text) & "','" & Val(txtTotTaxable.Text) & "','" & Val(txtTotTotal.Text) & "','" & RCM & "'"
    '            i = i + 1
    '        End With
    '    Next
    '    Try
    '        Sql = "insert into TaxDetails(VoucherID,EntryDate,TransType,BillNo,AccountID,AccountName,TotalAmount,TotalTaxable,TotalTax,TotalIGSTAmt,TotalCGSTAmt,TotalSGSTAmt,TotalCessAmt," & _
    '              "ItemID,ItemName,Qty,HSNCode,UQC,TotalAmt,TaxableAmt,TaxID,TaxName,TaxPer,TaxAmt,IGSTPer,IGSTAmt,CGSTPer,CGSTAmt,SGSTPer,SGSTAmt,CessPer,CessAmt,EntryType,GSTType,GSTIN,StateName,StateCode,GSTAmt,Taxable,Total,RCM)" & FastQuery & ""
    '        If FastQuery = String.Empty Then Exit Sub
    '        clsFun.ExecNonQuery(Sql)
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    '    FastQuery = String.Empty
    '    Sql = String.Empty

    '    For Each row As DataGridViewRow In Dg2.Rows
    '        With row
    '            Dim ChargeName As String = clsFun.ExecScalarStr(" Select ChargeName FROM Charges WHERE ID='" & Val(.Cells(5).Value) & "'")
    '            Dim HSnCode As String = clsFun.ExecScalarStr("SELECT HSnCode From Charges Where ID='" & Val(.Cells(5).Value) & "'")
    '            Dim SupplyType As String = clsFun.ExecScalarStr("SELECT SupplyType From Charges Where ID='" & Val(.Cells(5).Value) & "'")
    '            Dim GSTUNit As String = "OTH-OTHERS" : Dim Qty As Decimal = 0
    '            Dim totamt As Decimal = Val(.Cells(4).Value) + Val(.Cells(10).Value) + Val(.Cells(7).Value)
    '            Dim TaxID As Integer = clsFun.ExecScalarInt("SELECT T.ID as TaxID  FROM Charges AS C INNER JOIN Taxation AS T ON C.TaxID = T.Id Where C.ID='" & Val(.Cells(5).Value) & "'")
    '            Dim TaxName As String = clsFun.ExecScalarStr("SELECT T.TaxName as TaxName  FROM Charges AS C INNER JOIN Taxation AS T ON C.TaxID = T.Id Where C.ID='" & Val(.Cells(5).Value) & "'")
    '            Dim FixAs As String = clsFun.ExecScalarStr(" Select FixAs FROM Charges WHERE ID='" & Val(.Cells(5).Value) & "'")
    '            '  Dim RCM As String = clsFun.ExecScalarStr("SELECT RCM From Items Where ID='" & Val(.Cells(0).Value) & "'")
    '            If TaxID <> 0 Then
    '                If .Cells(3).Value = "+" Then
    '                    FastQuery = FastQuery & IIf(FastQuery <> "", " UNION ALL SELECT ", " SELECT ") & Val(txtID.Text) & ",'" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "','" & Me.Text & "', '" & txtVoucherNo.Text & "','" & Val(txtAccountID.Text) & "','" & AccountName & "'," & _
    '                 "'" & Val(0) & "','" & Val(0) & "','" & Val(0) & "','" & Val(0) & "','" & Val(0) & "','" & Val(0) & "','" & Val(0) & "'," & _
    '                 "'" & Val(.Cells(5).Value) & "','" & ChargeName & "','" & Val(Qty) & "','" & HSnCode & "','" & If(SupplyType = "Goods", GSTUNit, "NA") & "','" & Val(Val(.Cells(10).Value) + Val(.Cells(7).Value)) & "','" & Val(.Cells(10).Value) & "', '" & Val(TaxID) & "','" & TaxName & "'," & _
    '                 "'" & Val(.Cells(6).Value) & "' ,'" & IIf(TaxID = 0, 0, (Val(.Cells(7).Value))) & "'," & _
    '                 "'" & IIf(TaxID = 0, 0, (IIf(lblRegion.Text = "Local", 0, Val(.Cells(6).Value)))) & "','" & IIf(TaxID = 0, 0, (IIf(lblRegion.Text = "Local", 0, Val(.Cells(7).Value)))) & "', " & _
    '                 "'" & IIf(TaxID = 0, 0, (IIf(lblRegion.Text = "Local", Val(.Cells(6).Value) / 2, 0))) & "','" & IIf(TaxID = 0, 0, (IIf(lblRegion.Text = "Local", Val(.Cells(7).Value) / 2, 0))) & "', " & _
    '                 "'" & IIf(TaxID = 0, 0, (IIf(lblRegion.Text = "Local", Val(.Cells(6).Value) / 2, 0))) & "','" & IIf(TaxID = 0, 0, (IIf(lblRegion.Text = "Local", Val(.Cells(7).Value) / 2, 0))) & "', " & _
    '                 "'" & Val(0) & "','" & Val(0) & "','" & SupplyType & "','" & GSTType & "','" & GSTIN & "','" & State & "','" & StateCode & "','" & Val(txtTotTaxAmt.Text) & "','" & Val(txtTotTaxable.Text) & "','" & Val(txtTotTotal.Text) & "'"
    '                Else
    '                    FastQuery = FastQuery & IIf(FastQuery <> "", " UNION ALL SELECT ", " SELECT ") & Val(txtID.Text) & ",'" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "','" & Me.Text & "', '" & txtVoucherNo.Text & "','" & Val(txtAccountID.Text) & "','" & AccountName & "'," & _
    '                    "'" & Val(0) & "','" & Val(0) & "','" & Val(0) & "','" & Val(0) & "','" & Val(0) & "','" & Val(0) & "','" & Val(0) & "'," & _
    '               "'" & Val(.Cells(5).Value) & "','" & ChargeName & "','" & Val(Qty) & "','" & HSnCode & "','" & If(SupplyType = "Goods", GSTUNit, "NA") & "','" & -Val(Val(.Cells(10).Value) + Val(.Cells(7).Value)) & "','" & -Val(.Cells(10).Value) & "', '" & Val(TaxID) & "','" & TaxName & "'," & _
    '               "'" & Val(.Cells(6).Value) & "' ,'" & IIf(TaxID = 0, 0, -(Val(.Cells(7).Value))) & "'," & _
    '               "'" & IIf(TaxID = 0, 0, (IIf(lblRegion.Text = "Local", 0, Val(.Cells(6).Value)))) & "','" & IIf(TaxID = 0, 0, (IIf(lblRegion.Text = "Local", 0, -Val(.Cells(7).Value)))) & "', " & _
    '               "'" & IIf(TaxID = 0, 0, (IIf(lblRegion.Text = "Local", Val(.Cells(6).Value) / 2, 0))) & "','" & IIf(TaxID = 0, 0, (IIf(lblRegion.Text = "Local", -Val(.Cells(7).Value) / 2, 0))) & "', " & _
    '               "'" & IIf(TaxID = 0, 0, (IIf(lblRegion.Text = "Local", Val(.Cells(6).Value) / 2, 0))) & "','" & IIf(TaxID = 0, 0, (IIf(lblRegion.Text = "Local", -Val(.Cells(7).Value) / 2, 0))) & "', " & _
    '               "'" & Val(0) & "','" & Val(0) & "','" & SupplyType & "','" & GSTType & "','" & GSTIN & "','" & State & "','" & StateCode & "','" & Val(txtTotTaxAmt.Text) & "','" & Val(txtTotTaxable.Text) & "','" & Val(txtTotTotal.Text) & "'"
    '                End If
    '            End If
    '        End With
    '    Next
    '    Try
    '        Sql = "insert into TaxDetails(VoucherID,EntryDate,TransType,BillNo,AccountID,AccountName,TotalAmount,TotalTaxable,TotalTax,TotalIGSTAmt,TotalCGSTAmt,TotalSGSTAmt,TotalCessAmt," & _
    '              "ItemID,ItemName,Qty,HSNCode,UQC,TotalAmt,TaxableAmt,TaxID,TaxName,TaxPer,TaxAmt,IGSTPer,IGSTAmt,CGSTPer,CGSTAmt,SGSTPer,SGSTAmt,CessPer,CessAmt,EntryType,GSTType,GSTIN,StateName,StateCode,GstAmt,Taxable,Total)" & FastQuery & ""
    '        If FastQuery = String.Empty Then Exit Sub
    '        clsFun.ExecNonQuery(Sql)
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub
    Private Sub save()
        If cbServiceType.SelectedIndex <> 2 Then
            Dim isChecked As Boolean = Dg2.Rows.Cast(Of DataGridViewRow)().Any(Function(row) Convert.ToBoolean(row.Cells("Present").Value))
            If isChecked = False Then MsgBox("Please Select Table / Room No. to Make KOT", vbCritical.Critical, "Access Denies") : cbServiceType.Focus() : Exit Sub
        End If
        Dim IsIGST As String = String.Empty
        Dim sql As String = String.Empty
        If ckIGST.Checked = True Then
            IsIGST = "Y"
        Else
            IsIGST = "N"
        End If
        Dim sqliteDate As String = CDate(mskEntryDate.Text).ToString("yyyy-MM-dd")
        dg1.ClearSelection()
        Dim cmd As SQLite.SQLiteCommand
        sql = " INSERT INTO Vouchers (TransType,EntryDate,InvoiceNo,ServiceType, " _
            & " TotalBasicAmt,TotalSGSTAmt,TotalCGSTAmt,TotalIGSTAmt,TotalTaxAmt," _
            & " TotalGrandAmt,TotalCashAmt,TotalBalAmt,IsIGST,TotalTaxableAmt,RoundOff,  " _
            & "SallerID,SallerName,CardAmt,RefNo,Remark,CustomerName,CustomerAddress, " _
            & "CustomerMobile,CustomerCity,StateID,PinCode,CustomerGSTN,AccountID,AccountName,TotQty,InvoiceID) " _
            & " Values (@1, @2, @3, @4, @5, @6, @7, @8, @9, @10,@11, @12," _
            & "@13,@14,@15,@16,@17,@18,@19,@20,@21,@22,@23,@24,@25,@26,@27,@28,@29,@30,@31)"
        Try
            cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
            cmd.Parameters.AddWithValue("@1", Me.Text)
            cmd.Parameters.AddWithValue("@2", sqliteDate)
            cmd.Parameters.AddWithValue("@3", txtBillNo.Text)
            cmd.Parameters.AddWithValue("@4", cbServiceType.Text)
            cmd.Parameters.AddWithValue("@5", Val(txtTotBasic.Text))
            cmd.Parameters.AddWithValue("@6", IIf(ckIGST.Checked = False, Val(txtTotTax.Text) / 2, 0))
            cmd.Parameters.AddWithValue("@7", IIf(ckIGST.Checked = False, Val(txtTotTax.Text) / 2, 0))
            cmd.Parameters.AddWithValue("@8", IIf(ckIGST.Checked = False, 0, Val(txtTotTax.Text)))
            cmd.Parameters.AddWithValue("@9", Val(txtTotTax.Text))
            cmd.Parameters.AddWithValue("@10", Val(txtTotTotal.Text))
            cmd.Parameters.AddWithValue("@11", Val(txtTotCash.Text))
            cmd.Parameters.AddWithValue("@12", Val(txtTotChange.Text))
            cmd.Parameters.AddWithValue("@13", IsIGST)
            cmd.Parameters.AddWithValue("@14", Val(txtTotTaxable.Text))
            cmd.Parameters.AddWithValue("@15", Val(txtTotRoundOff.Text))
            cmd.Parameters.AddWithValue("@16", Val(cbBank.SelectedValue))
            cmd.Parameters.AddWithValue("@17", cbBank.Text)
            cmd.Parameters.AddWithValue("@18", Val(txtCardPayment.Text))
            cmd.Parameters.AddWithValue("@19", txtRefNo.Text)
            cmd.Parameters.AddWithValue("@20", txtRemark.Text)
            cmd.Parameters.AddWithValue("@21", txtCustomerName.Text)
            cmd.Parameters.AddWithValue("@22", txtAddress.Text)
            cmd.Parameters.AddWithValue("@23", txtMobileNo.Text)
            cmd.Parameters.AddWithValue("@24", txtDistrict.Text)
            cmd.Parameters.AddWithValue("@25", Val(cbState.SelectedValue))
            cmd.Parameters.AddWithValue("@26", txtpincode.Text)
            cmd.Parameters.AddWithValue("@27", txtGSTNo.Text)
            cmd.Parameters.AddWithValue("@28", IIf(txtTotCash.Text <> 0, 7, 0))
            cmd.Parameters.AddWithValue("@29", IIf(txtTotCash.Text <> 0, "Cash", ""))
            cmd.Parameters.AddWithValue("@30", txttotQty.Text)
            cmd.Parameters.AddWithValue("@31", Val(txtInvoiceID.Text))
            If cmd.ExecuteNonQuery() > 0 Then
            End If
            clsFun.CloseConnection()
            txtID.Text = Val(clsFun.ExecScalarInt("Select Max(ID) from Vouchers"))
            vchID = Val(txtID.Text)
            dg1Record() : Ledger()
            MsgBox("Record Saved Successfully.", vbInformation + vbOKOnly, "Saved") 'Insert SuccesFully", "SuccessFully", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtClearAll()
        Catch ex As Exception
            MsgBox(ex.Message) : Exit Sub
            clsFun.CloseConnection()
        End Try
    End Sub
    Private Sub dg1Record()
        sql = String.Empty
        Dim TableNo As String = String.Empty
        Dim TableName As String = String.Empty
        Dim checkBox As DataGridViewCheckBoxCell
        If Dg2.RowCount <> 0 Then
            For Each row As DataGridViewRow In Dg2.Rows
                checkBox = (TryCast(row.Cells("Present"), DataGridViewCheckBoxCell))
                If checkBox.Value = True Then
                    TableNo = TableNo & row.Cells(1).Value & ","
                    TableName = TableName & row.Cells(2).Value & ","
                End If
            Next
            TableNo = TableNo.Remove(TableNo.LastIndexOf(","))
            TableName = TableName.Remove(TableName.LastIndexOf(","))

            If cbServiceType.SelectedIndex <> 0 Then
                clsFun.ExecScalarStr("Update KOTTrans Set RoomOccupied='N' Where RoomVoucherID in(" & TableNo & ")")
            Else
                clsFun.ExecScalarStr("Update RestroTables Set IsBooked='N' Where ID in(" & TableNo & ")")
                clsFun.ExecScalarStr("Update KOTTrans Set IsOccupied='N' Where TableID in('" & TableNo & "')")
                clsFun.ExecScalarStr("Update KOTTrans Set Paid='Y' Where TableID in('" & TableNo & "')")
            End If
        End If
        Dim FastQuery As String = String.Empty
        For Each row As DataGridViewRow In dg1.Rows
            With row
                If .Cells("ItemID").Value <> "" Then
                    FastQuery = FastQuery & IIf(FastQuery <> "", " UNION ALL SELECT ", " SELECT ") & "'" & Me.Text & "','" & Val(txtID.Text) & "','" & Val(.Cells(0).Value) & "','" & .Cells(3).Value & "','" & .Cells(1).Value & "','" & .Cells(4).Value & "'," & _
                        "'" & Val(.Cells(5).Value) & "','" & .Cells(6).Value & "','" & .Cells(7).Value & "','" & Val(.Cells(8).Value) & "'," & _
                        "'" & Val(.Cells(9).Value) & "','" & Val(.Cells(13).Value) & "','" & Val(.Cells(10).Value) & "','" & Val(.Cells(11).Value) & "'," & _
                           "'" & Val(.Cells(12).Value) & "','" & IIf(ckIGST.Checked = False, Val(.Cells(10).Value) / 2, 0) & "'," & _
                        "'" & IIf(ckIGST.Checked = False, Val(.Cells(11).Value) / 2, 0) & "','" & IIf(ckIGST.Checked = False, Val(.Cells(10).Value) / 2, 0) & "', " & _
                        "'" & IIf(ckIGST.Checked = False, Val(.Cells(11).Value) / 2, 0) & "','" & IIf(ckIGST.Checked = False, 0, Val(.Cells(10).Value)) & "'," & _
                        "'" & IIf(ckIGST.Checked = False, 0, Val(.Cells(11).Value)) & "','" & IIf(cbServiceType.SelectedIndex = 1, "", TableNo) & "','" & IIf(cbServiceType.SelectedIndex = 1, "", TableName) & "','" & .Cells(14).Value & "', " & _
                        "'" & IIf(cbServiceType.SelectedIndex = 1, TableNo, "") & "','" & IIf(cbServiceType.SelectedIndex = 1, TableName, "") & "'"
                End If
            End With
        Next
        If FastQuery = "" Then Exit Sub
        sql = "INSERT INTO Trans (TransType,VoucherID,ItemID,ItemName,SNo,Per,Qty,Rate,BasicAmt,DisPer,DisAmt," & _
             " TaxableAmt,TaxPer,TaxAmt,TotalAmt,SgstPer,SgstAmt,CGSTPer,cgstAmt,IGSTPer,IGSTAmt,TableID,TableNos,KotDate,RoomVoucherID,RoomNos)" & FastQuery & ""
        Try
            clsFun.ExecNonQuery(sql)
        Catch ex As Exception
            MsgBox(ex.Message)
            clsFun.CloseConnection()
        End Try
        clsFun.CloseConnection()
    End Sub
    Private Sub Update()
        sql = String.Empty
        SqliteEntryDate = CDate(mskEntryDate.Text).ToString("yyyy-MM-dd")
        Dim count As Integer = 0
        dg1.ClearSelection()
        Dim cmd As SQLite.SQLiteCommand
        sql = " UPdate Vouchers Set TransType='" & Me.Text & "',EntryDate='" & SqliteEntryDate & "',InvoiceNo='" & txtBillNo.Text & "',ServiceType='" & cbServiceType.Text & "', " _
    & "TotQty='" & txttotQty.Text & "',TotalBasicAmt='" & Val(txtTotBasic.Text) & "',TotalDiscAmt='" & Val(txtTotDiscount.Text) & "',TotalGrandAmt='" & Val(txtTotTotal.Text) & "',TotalCashAmt='" & Val(txtTotCash.Text) & "', " _
    & "TotalBalAmt='" & Val(txtTotChange.Text) & "',TotalTaxableAmt='" & Val(txtTotTaxable.Text) & "',RoundOff='" & Val(txtTotRoundOff.Text) & "', " _
    & "TotalTaxamt=" & Val(txtTotTax.Text) & ",TotalCGSTAmt='" & IIf(ckIGST.Checked = False, Val(txtTotTax.Text) / 2, 0) & "',TotalsGSTAmt='" & IIf(ckIGST.Checked = False, Val(txtTotTax.Text) / 2, 0) & "', " _
    & "totalIGSTamt='" & IIf(ckIGST.Checked = False, 0, Val(txtTotTax.Text)) & "', isIGST='" & IsIGST & "', " _
    & "SallerID='" & Val(cbBank.SelectedValue) & "',SallerName='" & cbBank.Text & "',CardAmt='" & Val(txtCardPayment.Text) & "',RefNO='" & txtRefNo.Text & "', " _
    & "Remark='" & txtRemark.Text & "',CustomerName='" & txtCustomerName.Text & "',CustomerMobile='" & txtMobileNo.Text & "',CustomerAddress='" & txtAddress.Text & "', " _
    & "CustomerCity='" & txtDistrict.Text & "',StateID='" & cbState.SelectedValue & "',PinCode='" & txtpincode.Text & "', CustomerGSTN='" & txtGSTNo.Text & "', " _
    & "AccountID='" & IIf(txtTotCash.Text <> 0, 7, 0) & "',AccountName='" & IIf(txtTotCash.Text <> 0, "Cash", 0) & "' ,InvoiceID='" & Val(txtInvoiceID.Text) & "' where ID ='" & Val(txtID.Text) & "'"
        Try
            If clsFun.ExecNonQuery(sql) > 0 Then
                clsFun.CloseConnection()
            End If
            If clsFun.ExecNonQuery("DELETE from Trans WHERE VoucherID=" & Val(txtID.Text) & "") > 0 Then : End If
            If clsFun.ExecNonQuery("DELETE from Ledger WHERE VouchersID=" & Val(txtID.Text) & "") > 0 Then : End If
            vchID = txtID.Text : dg1Record() : Ledger()
            BtnSave.Text = "&Save"
            btnDelete.Enabled = False
            MsgBox("Record Updated Successfully.", vbInformation + vbOKOnly, "Update")
            clsFun.CloseConnection()
            txtClearAll()
        Catch ex As Exception
            MsgBox(ex.Message)
            clsFun.CloseConnection()
        End Try
    End Sub
    Public Sub FillControls(ByVal id As Integer)
        clsFun.FillDropDownList(cbBank, "Select ID,AccountName From Account_AcGrp where (Groupid in(12,16)  or UnderGroupID in (12,16))", "AccountName", "Id", "")
        clsFun.FillDropDownList(cbState, "Select ID,StateName || ' - ' || CASE WHEN StateGSTCodes < 10 THEN '0' ELSE '' END || StateGSTCodes as State  From StateList ", "State", "Id", "--N.A.--")
        Dim sSql As String = String.Empty
        Dim IsIGST As String = String.Empty
        BtnSave.Text = "&Update"
        cbServiceType.Enabled = False
        '  Panel1.BackColor = Color.PaleVioletRed
        If clsFun.GetConnection.State = ConnectionState.Open Then clsFun.CloseConnection()
        sSql = "Select * from Vouchers where id=" & id
        clsFun.con.Open()
        Dim ad As New SQLite.SQLiteDataAdapter(sSql, clsFun.GetConnection)
        Dim ds As New DataSet
        ad.Fill(ds, "a")
        If ds.Tables("a").Rows.Count > 0 Then
            txtID.Text = ds.Tables("a").Rows(0)("ID").ToString()
            mskEntryDate.Text = Format(ds.Tables("a").Rows(0)("EntryDate"), "dd-MM-yyyy")
            txtBillNo.Text = ds.Tables("a").Rows(0)("InvoiceNo").ToString()
            cbServiceType.Text = ds.Tables("a").Rows(0)("ServiceType").ToString()
            txttotQty.Text = Format(Val(ds.Tables("a").Rows(0)("TotQty").ToString()), "0")
            txtTotBasic.Text = Format(Val(ds.Tables("a").Rows(0)("TotalBasicAmt").ToString()), "0.00")
            txtTotDiscount.Text = Format(Val(ds.Tables("a").Rows(0)("TotalDiscAmt").ToString()), "0.00")
            txtTotTaxable.Text = Format(Val(ds.Tables("a").Rows(0)("TotalTaxableAmt").ToString()), "0.00")
            txtTotTax.Text = Format(Val(ds.Tables("a").Rows(0)("TotalTaxAmt").ToString()), "0.00")
            txtTotRoundOff.Text = Format(Val(ds.Tables("a").Rows(0)("Roundoff").ToString()), "0.00")
            txtTotTotal.Text = Format(Val(ds.Tables("a").Rows(0)("TotalGrandAmt").ToString()), "0.00")
            txtTotCash.Text = Format(Val(ds.Tables("a").Rows(0)("TotalCashAmt").ToString()), "0.00")
            txtTotChange.Text = Format(Val(ds.Tables("a").Rows(0)("TotalBalAmt").ToString()), "0.00")
            cbBank.SelectedValue = Val(ds.Tables("a").Rows(0)("SallerID").ToString())
            cbBank.Text = ds.Tables("a").Rows(0)("SallerName").ToString()
            txtCardPayment.Text = Format(Val(ds.Tables("a").Rows(0)("CardAmt").ToString()), "0.00")
            txtRefNo.Text = ds.Tables("a").Rows(0)("RefNo").ToString()
            txtRemark.Text = ds.Tables("a").Rows(0)("Remark").ToString()
            txtCustomerName.Text = ds.Tables("a").Rows(0)("CustomerName").ToString()
            txtAddress.Text = ds.Tables("a").Rows(0)("CustomerAddress").ToString()
            txtMobileNo.Text = ds.Tables("a").Rows(0)("CustomerMobile").ToString()
            txtDistrict.Text = ds.Tables("a").Rows(0)("CustomerCity").ToString()
            cbState.SelectedValue = ds.Tables("a").Rows(0)("StateID").ToString()
            txtpincode.Text = ds.Tables("a").Rows(0)("PinCode").ToString()
            txtGSTNo.Text = ds.Tables("a").Rows(0)("CustomerGSTN").ToString()
            txtInvoiceID.Text = ds.Tables("a").Rows(0)("InvoiceID").ToString()
            IsIGST = ds.Tables("a").Rows(0)("ISIGST").ToString()
            If IsIGST = "Y" Then
                ckIGST.Checked = True
            Else
                ckIGST.Checked = False
            End If

        End If
        Dim dt As New DataTable
        'sql = sql & "INSERT INTO Trans (TransType,VoucherID,ItemID,SNo,Per,Qty,Rate,BasicAmt,DisPer,DisAmt," & _
        '          " TaxableAmt,TaxPer,TaxAmt,TotalAmt,SgstPer,SgstAmt,CGSTPer,cgstAmt,IGSTPer,IGSTAmt,TableID,TableNos)" & _
        dt = clsFun.ExecDataTable("Select * From Trans as t left join Items I on I.id=t.ItemID  Where VoucherID=" & id)
        Dim dvData As DataView = New DataView(dt)
        Try
            If dt.Rows.Count > 0 Then
                dg1.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("ItemID").ToString()
                        .Cells(1).Value = dt.Rows(i)("SNo").ToString()
                        .Cells(2).Value = dt.Rows(i)("ItemCode").ToString()
                        .Cells(3).Value = dt.Rows(i)("ItemName").ToString()
                        .Cells(4).Value = dt.Rows(i)("RatePer").ToString()
                        .Cells(5).Value = Format(Val(dt.Rows(i)("Qty").ToString()), "0")
                        .Cells(6).Value = Format(Val(dt.Rows(i)("Rate").ToString()), "0.00")
                        .Cells(7).Value = Format(Val(dt.Rows(i)("BasicAmt").ToString()), "0.00")
                        .Cells(8).Value = Format(Val(dt.Rows(i)("DisPer").ToString()), "0.00")
                        .Cells(9).Value = Format(Val(dt.Rows(i)("DisAmt").ToString()), "0.00")
                        .Cells(13).Value = Format(Val(dt.Rows(i)("TaxableAmt").ToString()), "0.00")
                        .Cells(10).Value = Format(Val(dt.Rows(i)("TaxPer").ToString()), "0.00")
                        .Cells(11).Value = Format(Val(dt.Rows(i)("TaxAmt").ToString()), "0.00")
                        .Cells(12).Value = Format(Val(dt.Rows(i)("TotalAmt").ToString()), "0.00")
                        .Cells(14).Value = dt.Rows(i)("KotDate").ToString()

                    End With
                Next
                If cbServiceType.SelectedIndex <> 2 Then
                    Dim tmpdt As New DataTable
                    tmpdt = clsFun.ExecDataTable("Select RoomVoucherID,RoomNos,TableID,TableNos From Trans Where TransType='Food Bill' and VoucherID='" & Val(txtID.Text) & "' Group by TableID")

                    If tmpdt.Rows.Count > 0 Then
                        Dg2.Rows.Clear()
                        For i = 0 To tmpdt.Rows.Count - 1
                            Dg2.Rows.Add()
                            With Dg2.Rows(i)
                                .cells(0).value = True
                                .Cells(1).Value = IIf(cbServiceType.SelectedIndex = 1, tmpdt.Rows(i)("RoomVoucherID").ToString(), tmpdt.Rows(i)("tableid").ToString())
                                .Cells(2).Value = IIf(cbServiceType.SelectedIndex = 1, tmpdt.Rows(i)("RoomNos").ToString(), tmpdt.Rows(i)("TableNos").ToString())
                                If .cells(1).value = "" Then
                                    Dg2.Rows.Clear()
                                End If
                            End With
                        Next

                    End If
                    tmpdt.Dispose()
                End If
            End If
        Catch ex As Exception
            MsgBox("a")
        End Try

        dg1.ClearSelection() : Dg2.ClearSelection() : Dg2.Enabled = False
    End Sub

    Public Sub FillWithNevigation()
        clsFun.FillDropDownList(cbBank, "Select ID,AccountName From Account_AcGrp where (Groupid in(12,16)  or UnderGroupID in (12,16))", "AccountName", "Id", "")
        clsFun.FillDropDownList(cbState, "Select ID,StateName || ' - ' || CASE WHEN StateGSTCodes < 10 THEN '0' ELSE '' END || StateGSTCodes as State  From StateList ", "State", "Id", "--N.A.--")
        Dim recordsCount As Integer = clsFun.ExecScalarInt("Select Count(*) FROM Vouchers WHERE transtype = 'Food Bill'  Order By ID ")
        TotalPages = Math.Ceiling(recordsCount / RowCount)
        Dim sSql As String = String.Empty
        Dim IsIGST As String = String.Empty
        BtnSave.Text = "&Update"
        cbServiceType.Enabled = False
        '  Panel1.BackColor = Color.PaleVioletRed
        If clsFun.GetConnection.State = ConnectionState.Open Then clsFun.CloseConnection()
        'sSql = "Select * from Vouchers where id=" & id
        sSql = "Select * from  Vouchers WHERE transtype = 'Food Bill'  Order By ID LIMIT " + RowCount.ToString() + " OFFSET " + Offset.ToString() + ""
        clsFun.con.Open()
        Dim ad As New SQLite.SQLiteDataAdapter(sSql, clsFun.GetConnection)
        Dim ds As New DataSet
        ad.Fill(ds, "a")
        If ds.Tables("a").Rows.Count > 0 Then
            txtID.Text = ds.Tables("a").Rows(0)("ID").ToString()
            mskEntryDate.Text = Format(ds.Tables("a").Rows(0)("EntryDate"), "dd-MM-yyyy")
            txtBillNo.Text = ds.Tables("a").Rows(0)("InvoiceNo").ToString()
            cbServiceType.Text = ds.Tables("a").Rows(0)("ServiceType").ToString()
            txttotQty.Text = Format(Val(ds.Tables("a").Rows(0)("TotQty").ToString()), "0")
            txtTotBasic.Text = Format(Val(ds.Tables("a").Rows(0)("TotalBasicAmt").ToString()), "0.00")
            txtTotDiscount.Text = Format(Val(ds.Tables("a").Rows(0)("TotalDiscAmt").ToString()), "0.00")
            txtTotTaxable.Text = Format(Val(ds.Tables("a").Rows(0)("TotalTaxableAmt").ToString()), "0.00")
            txtTotTax.Text = Format(Val(ds.Tables("a").Rows(0)("TotalTaxAmt").ToString()), "0.00")
            txtTotRoundOff.Text = Format(Val(ds.Tables("a").Rows(0)("Roundoff").ToString()), "0.00")
            txtTotTotal.Text = Format(Val(ds.Tables("a").Rows(0)("TotalGrandAmt").ToString()), "0.00")
            txtTotCash.Text = Format(Val(ds.Tables("a").Rows(0)("TotalCashAmt").ToString()), "0.00")
            txtTotChange.Text = Format(Val(ds.Tables("a").Rows(0)("TotalBalAmt").ToString()), "0.00")
            cbBank.SelectedValue = Val(ds.Tables("a").Rows(0)("SallerID").ToString())
            cbBank.Text = ds.Tables("a").Rows(0)("SallerName").ToString()
            txtCardPayment.Text = Format(Val(ds.Tables("a").Rows(0)("CardAmt").ToString()), "0.00")
            txtRefNo.Text = ds.Tables("a").Rows(0)("RefNo").ToString()
            txtRemark.Text = ds.Tables("a").Rows(0)("Remark").ToString()
            txtCustomerName.Text = ds.Tables("a").Rows(0)("CustomerName").ToString()
            txtAddress.Text = ds.Tables("a").Rows(0)("CustomerAddress").ToString()
            txtMobileNo.Text = ds.Tables("a").Rows(0)("CustomerMobile").ToString()
            txtDistrict.Text = ds.Tables("a").Rows(0)("CustomerCity").ToString()
            cbState.SelectedValue = ds.Tables("a").Rows(0)("StateID").ToString()
            txtpincode.Text = ds.Tables("a").Rows(0)("PinCode").ToString()
            txtGSTNo.Text = ds.Tables("a").Rows(0)("CustomerGSTN").ToString()
            txtInvoiceID.Text = ds.Tables("a").Rows(0)("InvoiceID").ToString()
            IsIGST = ds.Tables("a").Rows(0)("ISIGST").ToString()
            If IsIGST = "Y" Then
                ckIGST.Checked = True
            Else
                ckIGST.Checked = False
            End If
            id = Val(txtID.Text)

        End If
        Dim dt As New DataTable
        'sql = sql & "INSERT INTO Trans (TransType,VoucherID,ItemID,SNo,Per,Qty,Rate,BasicAmt,DisPer,DisAmt," & _
        '          " TaxableAmt,TaxPer,TaxAmt,TotalAmt,SgstPer,SgstAmt,CGSTPer,cgstAmt,IGSTPer,IGSTAmt,TableID,TableNos)" & _
        dt = clsFun.ExecDataTable("Select * From Trans as t left join Items I on I.id=t.ItemID  Where VoucherID=" & Val(id))
        Dim dvData As DataView = New DataView(dt)
        Try
            If dt.Rows.Count > 0 Then
                dg1.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("ItemID").ToString()
                        .Cells(1).Value = dt.Rows(i)("SNo").ToString()
                        .Cells(2).Value = dt.Rows(i)("ItemCode").ToString()
                        .Cells(3).Value = dt.Rows(i)("ItemName").ToString()
                        .Cells(4).Value = dt.Rows(i)("RatePer").ToString()
                        .Cells(5).Value = Format(Val(dt.Rows(i)("Qty").ToString()), "0")
                        .Cells(6).Value = Format(Val(dt.Rows(i)("Rate").ToString()), "0.00")
                        .Cells(7).Value = Format(Val(dt.Rows(i)("BasicAmt").ToString()), "0.00")
                        .Cells(8).Value = Format(Val(dt.Rows(i)("DisPer").ToString()), "0.00")
                        .Cells(9).Value = Format(Val(dt.Rows(i)("DisAmt").ToString()), "0.00")
                        .Cells(13).Value = Format(Val(dt.Rows(i)("TaxableAmt").ToString()), "0.00")
                        .Cells(10).Value = Format(Val(dt.Rows(i)("TaxPer").ToString()), "0.00")
                        .Cells(11).Value = Format(Val(dt.Rows(i)("TaxAmt").ToString()), "0.00")
                        .Cells(12).Value = Format(Val(dt.Rows(i)("TotalAmt").ToString()), "0.00")
                        .Cells(14).Value = dt.Rows(i)("KotDate").ToString()

                    End With
                Next
                If cbServiceType.SelectedIndex <> 2 Then
                    Dim tmpdt As New DataTable
                    tmpdt = clsFun.ExecDataTable("Select RoomVoucherID,RoomNos,TableID,TableNos From Trans Where TransType='Food Bill' and VoucherID='" & Val(txtID.Text) & "' Group by TableID")

                    If tmpdt.Rows.Count > 0 Then
                        Dg2.Rows.Clear()
                        For i = 0 To tmpdt.Rows.Count - 1
                            Dg2.Rows.Add()
                            With Dg2.Rows(i)
                                .cells(0).value = True
                                .Cells(1).Value = IIf(cbServiceType.SelectedIndex = 1, tmpdt.Rows(i)("RoomVoucherID").ToString(), tmpdt.Rows(i)("tableid").ToString())
                                .Cells(2).Value = IIf(cbServiceType.SelectedIndex = 1, tmpdt.Rows(i)("RoomNos").ToString(), tmpdt.Rows(i)("TableNos").ToString())
                                If .cells(1).value = "" Then
                                    Dg2.Rows.Clear()
                                End If
                            End With
                        Next

                    End If
                    tmpdt.Dispose()
                End If
            End If
        Catch ex As Exception
            MsgBox("a")
        End Try
        dg1.ClearSelection() : Dg2.ClearSelection() : Dg2.Enabled = False
    End Sub
    Private Sub TempRowColumn()
        tempdt.ColumnCount = 44
        tempdt.Columns(0).Name = "ID" : tempdt.Columns(0).Width = 30
        tempdt.Columns(1).Name = "EntryDate" : tempdt.Columns(1).Width = 30
        tempdt.Columns(2).Name = "TransType" : tempdt.Columns(2).Width = 30
        tempdt.Columns(3).Name = "InvoiceNo" : tempdt.Columns(3).Width = 30
        tempdt.Columns(4).Name = "AccountName" : tempdt.Columns(4).Width = 30
        tempdt.Columns(5).Name = "ItemName" : tempdt.Columns(5).Width = 30
        tempdt.Columns(6).Name = "Sno" : tempdt.Columns(6).Width = 30
        tempdt.Columns(7).Name = "Qty" : tempdt.Columns(7).Width = 30
        tempdt.Columns(8).Name = "Rate" : tempdt.Columns(8).Width = 30
        tempdt.Columns(9).Name = "Per" : tempdt.Columns(9).Width = 30
        tempdt.Columns(10).Name = "BasicAmt" : tempdt.Columns(10).Width = 30
        tempdt.Columns(11).Name = "DisPer" : tempdt.Columns(11).Width = 30
        tempdt.Columns(12).Name = "DisAmt" : tempdt.Columns(12).Width = 30
        tempdt.Columns(13).Name = "SgstPer" : tempdt.Columns(13).Width = 30
        tempdt.Columns(14).Name = "Sgstamt" : tempdt.Columns(14).Width = 30
        tempdt.Columns(15).Name = "CgstPer" : tempdt.Columns(15).Width = 30
        tempdt.Columns(16).Name = "Cgstamt" : tempdt.Columns(16).Width = 30
        tempdt.Columns(17).Name = "TaxPer" : tempdt.Columns(17).Width = 30
        tempdt.Columns(18).Name = "igstAmt" : tempdt.Columns(18).Width = 30
        tempdt.Columns(19).Name = "TotalBasicAmt" : tempdt.Columns(19).Width = 30
        tempdt.Columns(20).Name = "TotalAmt" : tempdt.Columns(20).Width = 30
        tempdt.Columns(21).Name = "TotalDiscAmt" : tempdt.Columns(21).Width = 30
        tempdt.Columns(22).Name = "TotalSGSTAmt" : tempdt.Columns(22).Width = 30
        tempdt.Columns(23).Name = "TotalCGSTAmt" : tempdt.Columns(23).Width = 30
        tempdt.Columns(24).Name = "TotalTaxAmt" : tempdt.Columns(24).Width = 30
        tempdt.Columns(25).Name = "RoundOFF" : tempdt.Columns(25).Width = 30
        tempdt.Columns(26).Name = "TotalCharges" : tempdt.Columns(26).Width = 30
        tempdt.Columns(27).Name = "TotalGrandAmt" : tempdt.Columns(27).Width = 30
        tempdt.Columns(28).Name = "TotalBalAmt" : tempdt.Columns(28).Width = 30
        tempdt.Columns(29).Name = "TotalCashAmt" : tempdt.Columns(29).Width = 30
        tempdt.Columns(30).Name = "CustomerName" : tempdt.Columns(30).Width = 30
        tempdt.Columns(31).Name = "CustomerAddress" : tempdt.Columns(31).Width = 30
        tempdt.Columns(32).Name = "CustomerMobile" : tempdt.Columns(32).Width = 30
        tempdt.Columns(33).Name = "CustomerCity" : tempdt.Columns(33).Width = 30
        tempdt.Columns(34).Name = "CustomerState" : tempdt.Columns(34).Width = 30
        tempdt.Columns(35).Name = "CustomerStateCode" : tempdt.Columns(35).Width = 30
        tempdt.Columns(36).Name = "GSTN" : tempdt.Columns(35).Width = 30
        tempdt.Columns(37).Name = "WalletAmt" : tempdt.Columns(35).Width = 30
        tempdt.Columns(38).Name = "RefNo" : tempdt.Columns(36).Width = 30
        tempdt.Columns(39).Name = "WalletName" : tempdt.Columns(37).Width = 30
        tempdt.Columns(40).Name = "Remark" : tempdt.Columns(38).Width = 30
        tempdt.Columns(41).Name = "HSNCode" : tempdt.Columns(41).Width = 30
        tempdt.Columns(42).Name = "KOTDate" : tempdt.Columns(42).Width = 30
        tempdt.Columns(43).Name = "TableNos" : tempdt.Columns(43).Width = 30
    End Sub

    Sub FillData()
        TempRowColumn()
        tempdt.Rows.Clear()
        Dim i, j As Integer
        Dim dt As New DataTable
        Dim cnt As Integer = -1
        dt = clsFun.ExecDataTable("Select * From Trans as t left join Items I on I.id=t.ItemID left join Vouchers V on V.id=t.VoucherID  Where VoucherID=" & Val(txtID.Text) & "")
        If dt.Rows.Count = 0 Then Exit Sub
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                tempdt.Rows.Add()
                With tempdt
                    '.Rows(i)(0) = dt.Rows(i)("ID").ToString()
                    tempdt.Rows(i).Cells(1).Value = CDate(dt.Rows(i)("EntryDate")).ToString("dd-MM-yyyy")
                    tempdt.Rows(i).Cells(2).Value = dt.Rows(i)("TransType").ToString() : tempdt.Rows(i).Cells(3).Value = dt.Rows(i)("InvoiceNo").ToString()
                    tempdt.Rows(i).Cells(4).Value = dt.Rows(i)("AccountName").ToString() : tempdt.Rows(i).Cells(5).Value = dt.Rows(i)("ItemName").ToString()
                    tempdt.Rows(i).Cells(6).Value = dt.Rows(i)("Sno").ToString() : tempdt.Rows(i).Cells(7).Value = Format(Val(dt.Rows(i)("Qty").ToString()), "0.00")
                    tempdt.Rows(i).Cells(8).Value = Format(Val(dt.Rows(i)("Rate").ToString()), "0.00") : tempdt.Rows(i).Cells(9).Value = dt.Rows(i)("Per").ToString()
                    tempdt.Rows(i).Cells(10).Value = Format(Val(dt.Rows(i)("BasicAmt").ToString()), "0.00") : tempdt.Rows(i).Cells(11).Value = Format(Val(dt.Rows(i)("DisPer").ToString()), "0.00")
                    tempdt.Rows(i).Cells(12).Value = Format(Val(dt.Rows(i)("DisAmt").ToString()), "0.00")
                    tempdt.Rows(i).Cells(13).Value = Format(Val(dt.Rows(i)("SgstPer").ToString()), "0.00") : tempdt.Rows(i).Cells(14).Value = Format(Val(dt.Rows(i)("Sgstamt").ToString()), "0.00")
                    tempdt.Rows(i).Cells(15).Value = Format(Val(dt.Rows(i)("CgstPer").ToString()), "0.00") : tempdt.Rows(i).Cells(16).Value = Format(Val(dt.Rows(i)("CgstAmt").ToString()), "0.00")
                    tempdt.Rows(i).Cells(17).Value = Format(Val(dt.Rows(i)("IGSTPer").ToString()), "0.00") : tempdt.Rows(i).Cells(18).Value = Format(Val(dt.Rows(i)("igstAmt").ToString()), "0.00")
                    tempdt.Rows(i).Cells(19).Value = Format(Val(dt.Rows(i)("TotalBasicAmt").ToString()), "0.00") : tempdt.Rows(i).Cells(20).Value = Format(Val(dt.Rows(i)("TotalAmt").ToString()), "0.00")
                    tempdt.Rows(i).Cells(21).Value = Format(Val(dt.Rows(i)("TotalDiscAmt").ToString()), "0.00") : tempdt.Rows(i).Cells(22).Value = Format(Val(dt.Rows(i)("TotalSGSTAmt").ToString()), "0.00")
                    tempdt.Rows(i).Cells(23).Value = Format(Val(dt.Rows(i)("TotalCGSTAmt").ToString()), "0.00") : tempdt.Rows(i).Cells(24).Value = Format(Val(dt.Rows(i)("IGSTAmt").ToString()), "0.00")
                    tempdt.Rows(i).Cells(25).Value = Format(Val(dt.Rows(i)("RoundOFF").ToString()), "0.00") : tempdt.Rows(i).Cells(26).Value = Format(Val(dt.Rows(i)("TotalCharges").ToString()), "0.00")
                    tempdt.Rows(i).Cells(27).Value = Format(Val(dt.Rows(i)("TotalGrandAmt").ToString()), "0.00") : tempdt.Rows(i).Cells(28).Value = Format(Val(dt.Rows(i)("TotalBalAmt").ToString()), "0.00")
                    tempdt.Rows(i).Cells(29).Value = Format(Val(dt.Rows(i)("TotalCashAmt").ToString()), "0.00")
                    tempdt.Rows(i).Cells(30).Value = dt.Rows(i)("CustomerName").ToString() : tempdt.Rows(i).Cells(31).Value = dt.Rows(i)("CustomerAddress").ToString()
                    tempdt.Rows(i).Cells(32).Value = dt.Rows(i)("CustomerCity").ToString() : tempdt.Rows(i).Cells(33).Value = clsFun.ExecScalarStr("Select StateName From StateList Where ID='" & dt.Rows(i)("StateID").ToString() & "'")
                    tempdt.Rows(i).Cells(34).Value = dt.Rows(i)("PinCode").ToString() : tempdt.Rows(i).Cells(35).Value = dt.Rows(i)("CustomerMobile").ToString()
                    tempdt.Rows(i).Cells(36).Value = dt.Rows(i)("CustomerGSTN").ToString() : tempdt.Rows(i).Cells(37).Value = Format(Val(dt.Rows(i)("CardAmt").ToString()), "0.00")
                    tempdt.Rows(i).Cells(38).Value = dt.Rows(i)("SallerName").ToString() : tempdt.Rows(i).Cells(39).Value = dt.Rows(i)("RefNo").ToString()
                    tempdt.Rows(i).Cells(40).Value = dt.Rows(i)("Remark").ToString() : tempdt.Rows(i).Cells(41).Value = dt.Rows(i)("HSNCode").ToString()
                    tempdt.Rows(i).Cells(42).Value = CDate(dt.Rows(i)("KOTdate")).ToString("dd-MM-yyyy") : tempdt.Rows(i).Cells(43).Value = IIf(dt.Rows(i)("TableNos").ToString() = "", clsFun.ExecScalarStr("Select RoomNos From Vouchers Where ID='" & Val(dt.Rows(i)("RoomVoucherID").ToString()) & "' "), dt.Rows(i)("TableNos").ToString())
                End With
            Next
        End If
        dt.Clear()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Delete()
    End Sub
    Private Sub Delete()
        If MessageBox.Show("Are You Sure Want to Delete Invoice : " & txtBillNo.Text & " ?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If clsFun.ExecNonQuery("DELETE from KOT WHERE ID=" & Val(txtID.Text) & ";DELETE from KOTTrans WHERE KOTID=" & Val(txtID.Text) & "; " & _
                                   "DELETE from Vouchers WHERE ID=" & Val(txtID.Text) & ";DELETE from Trans WHERE VoucherID=" & Val(txtID.Text) & "; " & _
                                   "DELETE from Ledger WHERE VouchersID=" & Val(txtID.Text) & "") > 0 Then
            End If
            'If clsFun.ExecNonQuery("DELETE from KOTTrans WHERE KOTID=" & Val(txtID.Text) & "") > 0 Then

            'End If
            'If clsFun.ExecNonQuery("DELETE from Vouchers WHERE ID=" & Val(txtID.Text) & "") > 0 Then
            'End If
            'If clsFun.ExecNonQuery("DELETE from Trans WHERE VoucherID=" & Val(txtID.Text) & "") > 0 Then
            'End If
            'If clsFun.ExecNonQuery("DELETE from Ledger WHERE VouchersID=" & Val(txtID.Text) & "") > 0 Then
            'End If
            sql = String.Empty
            Dim TableNo As String = String.Empty
            Dim TableName As String = String.Empty
            Dim checkBox As DataGridViewCheckBoxCell
            If Dg2.RowCount <> 0 Then
                For Each row As DataGridViewRow In Dg2.Rows
                    checkBox = (TryCast(row.Cells("Present"), DataGridViewCheckBoxCell))
                    If checkBox.Value = True Then
                        TableNo = TableNo & row.Cells(1).Value & ","
                        TableName = TableName & row.Cells(2).Value & ","
                    End If
                Next
                TableNo = TableNo.Remove(TableNo.LastIndexOf(","))
                TableName = TableName.Remove(TableName.LastIndexOf(","))
                clsFun.ExecScalarStr("Update RestroTables Set IsBooked='Y' Where ID in(" & TableNo & ") ")
                clsFun.ExecScalarStr("Update KOTTrans Set IsOccupied='Y',Paid =null Where TableID in(" & TableNo & ")")
            End If
            MsgBox("Record Deleted Successfully", vbInformation + vbOKOnly, "Deleted")
            txtClearAll()
        End If
    End Sub

    Private Sub txtItem_KeyUp(sender As Object, e As KeyEventArgs) Handles txtItem.KeyUp
        ItemRowColumns()
        If txtItem.Text.Trim() <> "" Then
            dgItemSearch.Visible = True
            retriveItems(" Where upper(ItemName) Like upper('%" & txtItem.Text.Trim() & "%') or upper(ItemCode)  Like upper('" & txtItem.Text.Trim() & "%') ")
        End If
        If e.KeyCode = Keys.Escape Then dgItemSearch.Visible = False
    End Sub
    Private Sub ItemRowColumns()
        dgItemSearch.ColumnCount = 4
        dgItemSearch.Columns(0).Name = "ID" : dgItemSearch.Columns(0).Visible = False
        dgItemSearch.Columns(1).Name = "Item Code" : dgItemSearch.Columns(1).Width = 50
        dgItemSearch.Columns(2).Name = "Item Name" : dgItemSearch.Columns(2).Width = 300
        dgItemSearch.Columns(3).Name = "Unit" : dgItemSearch.Columns(3).Width = 100
        retriveItems()
    End Sub
    Private Sub retriveItems(Optional ByVal condtion As String = "")
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("Select ID,ItemCode,ItemName,TableRate,RatePer from Item_View " & condtion & " order by ItemCode,ItemName liMIT 20")
        Try
            If dt.Rows.Count > 0 Then
                dgItemSearch.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dgItemSearch.Rows.Add()
                    With dgItemSearch.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("id").ToString()
                        .Cells(1).Value = dt.Rows(i)("ItemCode").ToString()
                        .Cells(2).Value = dt.Rows(i)("ItemName").ToString()
                        .Cells(3).Value = dt.Rows(i)("RatePer").ToString()
                    End With
                Next
            End If
            dt.Dispose()

        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "Teller")
        End Try
    End Sub
    Private Sub dg2_CellClick1(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub calculation()
        txtBasic.Text = Format(Val(Val(txtQty.Text) * Val(txtRate.Text)), "0.00")
        txtDiscAmt.Text = Format(Val(Val(txtDisPer.Text) * Val(txtBasic.Text) / 100), "0.00")
        txtTaxable.Text = Format(Val(Val(txtBasic.Text) - Val(txtDiscAmt.Text)), "0.00")
        txtTaxAmt.Text = Format(Val(Val(txtTaxPer.Text) * Val(txtTaxable.Text) / 100), "0.00")
        txtTotalAmt.Text = Format(Val(Val(txtBasic.Text) - Val(txtDiscAmt.Text)) + Val(Val(txtTaxAmt.Text)), "0.00")
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub cbServiceType_Leave(sender As Object, e As EventArgs) Handles cbServiceType.Leave
        If cbServiceType.SelectedIndex = 1 Then
            RetriveRooms()
        ElseIf cbServiceType.SelectedIndex = 0 Or cbServiceType.SelectedIndex = 3 Then
            retriveTables()
        End If
    End Sub

    Private Sub retriveTables(Optional ByVal condtion As String = "")
        Dg2.Rows.Clear()
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("Select * From KOtTrans Where IsOccupied='Y' Group by TableID")
        Try
            If dt.Rows.Count > 0 Then
                Dg2.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    Dg2.Rows.Add()
                    With Dg2.Rows(i)
                        .Cells(2).readonly = True
                        .Cells(1).Value = dt.Rows(i)("Tableid").ToString()
                        .Cells(2).Value = dt.Rows(i)("TableNos").ToString()
                    End With
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "Atithi")
        End Try
        Dg2.ClearSelection()
    End Sub
    Private Sub RetriveRooms(Optional ByVal condtion As String = "")
        Dg2.Rows.Clear()
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("Select * From KOtTrans Where RoomOccupied='Y' Group by RoomVoucherID")
        Try
            If dt.Rows.Count > 0 Then
                Dg2.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    Dg2.Rows.Add()
                    With Dg2.Rows(i)
                        .Cells(2).readonly = True
                        .Cells(1).Value = dt.Rows(i)("RoomVoucherID").ToString()
                        .Cells(2).Value = dt.Rows(i)("RoomNos").ToString()
                    End With
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "Atithi")
        End Try
        Dg2.ClearSelection()
    End Sub
    Private Sub pickPrice()
        Dim price As String
        If cbServiceType.SelectedIndex = 0 Then
            txtRate.Text = Val(clsFun.ExecScalarInt(" SELECT TableRate FROM Item_View WHERE ID ='" & Val(txtItemID.Text) & "'"))
        ElseIf cbServiceType.SelectedIndex = 1 Then
            txtRate.Text = Val(clsFun.ExecScalarInt(" SELECT RoomRate FROM Item_View WHERE ID ='" & Val(txtItemID.Text) & "'"))
        ElseIf cbServiceType.SelectedIndex = 2 Then
            txtRate.Text = Val(clsFun.ExecScalarInt(" SELECT TakeAwayRate FROM Item_View WHERE ID ='" & Val(txtItemID.Text) & "'"))
        ElseIf cbServiceType.SelectedIndex = 3 Then
            txtRate.Text = Val(clsFun.ExecScalarInt(" SELECT Barrate FROM Item_View WHERE ID ='" & Val(txtItemID.Text) & "'"))
        End If
        txtTaxPer.Text = Val(clsFun.ExecScalarInt(" SELECT GSTPer FROM Item_View WHERE ID ='" & Val(txtItemID.Text) & "'"))
    End Sub
    Private Sub dgItemSearch_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgItemSearch.CellClick
        If dgItemSearch.SelectedRows.Count = 0 Then Exit Sub
        txtItem.Clear() : txtItemID.Clear()
        txtItemID.Text = Val(dgItemSearch.SelectedRows(0).Cells(0).Value)
        lblCode.Text = dgItemSearch.SelectedRows(0).Cells(1).Value
        txtItem.Text = dgItemSearch.SelectedRows(0).Cells(2).Value
        lblUnit.Text = dgItemSearch.SelectedRows(0).Cells(3).Value
        dgItemSearch.Visible = False : txtQty.Focus()
    End Sub
    Private Sub dgItemSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles dgItemSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgItemSearch.SelectedRows.Count = 0 Then Exit Sub
            txtItem.Clear() : txtItem.Clear()
            txtItemID.Text = Val(dgItemSearch.SelectedRows(0).Cells(0).Value)
            lblCode.Text = dgItemSearch.SelectedRows(0).Cells(1).Value
            txtItem.Text = dgItemSearch.SelectedRows(0).Cells(2).Value
            lblUnit.Text = dgItemSearch.SelectedRows(0).Cells(3).Value
            dgItemSearch.Visible = False : e.SuppressKeyPress = True
            txtQty.Focus()
        End If
        If e.KeyCode = Keys.Back Then txtItem.Focus()
        If e.KeyCode = Keys.F1 Then
            If dgItemSearch.SelectedRows.Count = 0 Then Exit Sub
            Dim itemid As String = Val(dgItemSearch.SelectedRows(0).Cells(0).Value)
            Items.MdiParent = MainScreenForm
            Items.Show()
            Items.FillControls(itemid)
            If Not Items Is Nothing Then
                Items.BringToFront()
            End If
        End If
        If e.KeyCode = Keys.F3 Then
            Items.MdiParent = MainScreenForm
            Items.Show()
            If Not Items Is Nothing Then
                Items.BringToFront()
            End If
        End If
    End Sub

    Private Sub txtTotalAmt_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTotalAmt.KeyDown
        If Val(txtQty.Text) = 0 Then MsgBox("PLease Fill then Qty", vbCritical.Critical, "Check Qty") : txtQty.Focus() : Exit Sub
        If e.KeyCode = Keys.Enter Then
            'If txtItem.Text = "" Or txtItemID.Text = "" Then MsgBox("Please select Item... Blank Item Name Can't Be Insert in Record.", vbCritical, "Access Denied.") : txtItem.Focus() : Exit Sub
            'If txtQty.Text = 0 Then MsgBox("Zero Quantity Can't Insert In Record", vbCritical, "Access Denied.") : txtQty.Focus() : Exit Sub
            If dg1.SelectedRows.Count = 1 Then
                dg1.SelectedRows(0).Cells(0).Value = txtItemID.Text
                dg1.SelectedRows(0).Cells(3).Value = txtItem.Text
                dg1.SelectedRows(0).Cells(4).Value = lblUnit.Text
                dg1.SelectedRows(0).Cells(5).Value = txtQty.Text
                dg1.SelectedRows(0).Cells(6).Value = txtRate.Text
                dg1.SelectedRows(0).Cells(7).Value = txtBasic.Text
                dg1.SelectedRows(0).Cells(8).Value = txtDisPer.Text
                dg1.SelectedRows(0).Cells(9).Value = txtDiscAmt.Text
                dg1.SelectedRows(0).Cells(10).Value = txtTaxPer.Text
                dg1.SelectedRows(0).Cells(11).Value = txtTaxAmt.Text
                dg1.SelectedRows(0).Cells(12).Value = txtTotalAmt.Text
                dg1.SelectedRows(0).Cells(13).Value = txtTaxable.Text
                dg1.SelectedRows(0).Cells(14).Value = CDate(mskEntryDate.Text).ToString("yyyy-MM-dd")
                'If ckIGST.Checked = False Then
                '    dg1.SelectedRows(0).Cells(13).Value = Val(txtTaxPer.Text / 2)
                '    dg1.SelectedRows(0).Cells(14).Value = Val(txtTaxAmt.Text / 2)
                '    dg1.SelectedRows(0).Cells(15).Value = Val(txtTaxPer.Text / 2)
                '    dg1.SelectedRows(0).Cells(16).Value = Val(txtTaxAmt.Text / 2)
                '    dg1.SelectedRows(0).Cells(15).Value = Val(0)
                '    dg1.SelectedRows(0).Cells(16).Value = Val(0)
                'Else
                '    dg1.SelectedRows(0).Cells(13).Value = Val(0)
                '    dg1.SelectedRows(0).Cells(14).Value = Val(0)
                '    dg1.SelectedRows(0).Cells(15).Value = Val(0)
                '    dg1.SelectedRows(0).Cells(16).Value = Val(0)
                '    dg1.SelectedRows(0).Cells(17).Value = Val(txtTaxPer.Text)
                '    dg1.SelectedRows(0).Cells(18).Value = Val(txtTaxAmt.Text)
                'End If
            Else
                dg1.Rows.Add(txtItemID.Text, dg1.RowCount + 1, lblCode.Text, txtItem.Text, lblUnit.Text,
                         txtQty.Text, txtRate.Text, txtBasic.Text, txtDisPer.Text, txtDiscAmt.Text, txtTaxPer.Text,
                         txtTaxAmt.Text, txtTotalAmt.Text, txtTaxable.Text, CDate(mskEntryDate.Text).ToString("yyyy-MM-dd"))

                'dg1.Rows.Add(txtItemID.Text, dg1.RowCount + 1, lblCode.Text, txtItem.Text, lblUnit.Text,
                '         txtQty.Text, txtRate.Text, txtBasic.Text, txtDisPer.Text, txtDiscAmt.Text, txtTaxPer.Text,
                '         txtTaxAmt.Text, txtTotalAmt.Text, IIf(ckIGST.Checked = False, txtTaxAmt.Text / 2, 0),
                '         IIf(ckIGST.Checked = False, txtTaxPer.Text / 2, 0), IIf(ckIGST.Checked = False, txtTaxAmt.Text / 2, 0),
                '         IIf(ckIGST.Checked = False, 0, txtTaxPer.Text), IIf(ckIGST.Checked = False, 0, txtTaxAmt.Text), txtTaxable.Text)
            End If
            e.SuppressKeyPress = True
            dg1.ClearSelection() : TxtClear() : calc()
        End If
    End Sub
    Private Sub Ledger()
        Dim FastQuery As String = String.Empty
        If Val(txtTotTaxable.Text) > 0 Then ''Sale Account Fixed
            '      clsFun.Ledger(0, Val(txtID.Text), SqliteEntryDate, Me.Text, 37, clsFun.ExecScalarStr("Select AccountName from Accounts where Id=29"), Val(txtTotTaxable.Text), "C", txtBillNo.Text)
            FastQuery = FastQuery & IIf(FastQuery <> "", " UNION ALL SELECT ", " SELECT ") & Val(txtID.Text) & ",'" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "','" & Me.Text & "', 37,'" & clsFun.ExecScalarStr("Select AccountName from Accounts where Id=29") & "'," & Val(txtTotTaxable.Text) & ", 'C', '" & txtBillNo.Text & "',''"
        End If
        If Val(txtTotCash.Text) > 0 Then ''Cash Amount 
            '            clsFun.Ledger(0, Val(txtID.Text), SqliteEntryDate, Me.Text, 7, clsFun.ExecScalarStr("Select AccountName from Accounts where Id=7"), Val(txtTotCash.Text), "D", txtBillNo.Text)
            FastQuery = FastQuery & IIf(FastQuery <> "", " UNION ALL SELECT ", " SELECT ") & Val(txtID.Text) & ",'" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "','" & Me.Text & "', 7,'" & clsFun.ExecScalarStr("Select AccountName from Accounts where Id=7") & "'," & Val(txtTotCash.Text) & ", 'D', '" & txtBillNo.Text & "',''"
        End If
        If Val(txtTotChange.Text) > 0 Then ''Card Due Amount 
            '            clsFun.Ledger(0, Val(txtID.Text), SqliteEntryDate, Me.Text, cbBank.SelectedValue, cbBank.Text, Val(txtTotChange.Text), "D", txtBillNo.Text)
            FastQuery = FastQuery & IIf(FastQuery <> "", " UNION ALL SELECT ", " SELECT ") & Val(txtID.Text) & ",'" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "','" & Me.Text & "', " & Val(cbBank.SelectedValue) & ",'" & cbBank.Text & "'," & Val(txtTotChange.Text) & ", 'D', '" & txtBillNo.Text & "',''"
        End If
        If Val(txtTotRoundOff.Text) <> 0 Then ''Account 
            If Val(txtTotRoundOff.Text) < 0 Then
                'clsFun.Ledger(0, Val(txtID.Text), SqliteEntryDate, Me.Text, 42, clsFun.ExecScalarStr("Select AccountName from Accounts where Id=42"), Math.Abs(Val(txtTotRoundOff.Text)), "D", "Invoice No.: " & txtBillNo.Text & ",  Total Amount : " & Format(txtTotTotal.Text, "0.00"))
                FastQuery = FastQuery & IIf(FastQuery <> "", " UNION ALL SELECT ", " SELECT ") & Val(txtID.Text) & ",'" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "','" & Me.Text & "', " & Val(42) & ",'" & clsFun.ExecScalarStr("Select AccountName from Accounts where Id=42") & "'," & Math.Abs(Val(txtTotRoundOff.Text)) & ", 'D', '" & txtBillNo.Text & "',''"

            Else
                'clsFun.Ledger(0, Val(txtID.Text), SqliteEntryDate, Me.Text, 42, clsFun.ExecScalarStr("Select AccountName from Accounts where Id=42"), Val(txtTotRoundOff.Text), "C", "Invoice No.: " & txtBillNo.Text & ", Total Amount : " & Format(txtTotTotal.Text, "0.00"))
                FastQuery = FastQuery & IIf(FastQuery <> "", " UNION ALL SELECT ", " SELECT ") & Val(txtID.Text) & ",'" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "','" & Me.Text & "', " & Val(42) & ",'" & clsFun.ExecScalarStr("Select AccountName from Accounts where Id=42") & "'," & Math.Abs(Val(txtTotRoundOff.Text)) & ", 'C', '" & txtBillNo.Text & "',''"

            End If
        End If
        If ckIGST.Checked = False Then
            If Val(txtTotTax.Text) > 0 Then
                'SGST amount
                '      clsFun.Ledger(0, Val(txtID.Text), SqliteEntryDate, Me.Text, 998, clsFun.ExecScalarStr("Select AccountName from Accounts where Id=998"), Val(txtTotTax.Text) / 2, "C")
                FastQuery = FastQuery & IIf(FastQuery <> "", " UNION ALL SELECT ", " SELECT ") & Val(txtID.Text) & ",'" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "','" & Me.Text & "', " & Val(998) & ",'" & clsFun.ExecScalarStr("Select AccountName from Accounts where Id=998") & "'," & Val(txtTotTax.Text) / 2 & ", 'C', '" & txtBillNo.Text & "',''"

                'CGST amount
                '                clsFun.Ledger(0, Val(txtID.Text), SqliteEntryDate, Me.Text, 999, clsFun.ExecScalarStr("Select AccountName from Accounts where Id=999"), Val(txtTotTax.Text) / 2, "C")
                FastQuery = FastQuery & IIf(FastQuery <> "", " UNION ALL SELECT ", " SELECT ") & Val(txtID.Text) & ",'" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "','" & Me.Text & "', " & Val(999) & ",'" & clsFun.ExecScalarStr("Select AccountName from Accounts where Id=999") & "'," & Val(txtTotTax.Text) / 2 & ", 'C', '" & txtBillNo.Text & "',''"
            End If
        Else
            If Val(txtTotTax.Text) > 0 Then
                ' IGST amount 
                '   clsFun.Ledger(0, Val(txtID.Text), SqliteEntryDate, Me.Text, 1000, clsFun.ExecScalarStr("Select AccountName from Accounts where Id=1000"), Val(txtTotTax.Text), "C")
                FastQuery = FastQuery & IIf(FastQuery <> "", " UNION ALL SELECT ", " SELECT ") & Val(txtID.Text) & ",'" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "'," & Me.Text & ", " & Val(1000) & ",'" & clsFun.ExecScalarStr("Select AccountName from Accounts where Id=1000") & "'," & Val(txtTotTax.Text) & ", 'D', '" & txtBillNo.Text & "',''"
            End If
        End If
        If FastQuery = String.Empty Then Exit Sub
        clsFun.FastLedger(FastQuery)
    End Sub
    Sub calc()
        txttotQty.Text = Format(0, "0") : txtTotBasic.Text = Format(0, "0.00")
        txtTotDiscount.Text = Format(0, "0.00") : txtTotTaxable.Text = Format(0, "0.00")
        txtTotTax.Text = Format(0, "0.00") : txtTotTotal.Text = Format(0, "0.00")
        txtTotTaxable.Text = Format(0, "0.00")
        For i = 0 To dg1.Rows.Count - 1
            txttotQty.Text = Format(Val(txttotQty.Text) + Val(dg1.Rows(i).Cells(5).Value), "0")
            txtTotBasic.Text = Format(Val(txtTotBasic.Text) + Val(dg1.Rows(i).Cells(7).Value), "0.00")
            txtTotDiscount.Text = Format(Val(txtTotDiscount.Text) + Val(dg1.Rows(i).Cells(9).Value), "0.00")
            'TextBox9.Text = Format(Val(TextBox9.Text) + Val(Val(dg1.Rows(i).Cells(7).Value) - Val(dg1.Rows(i).Cells(9).Value)), "0.00")
            txtTotTax.Text = Format(Val(txtTotTax.Text) + Val(dg1.Rows(i).Cells(11).Value), "0.00")
            txtTotTotal.Text = Format(Val(txtTotTotal.Text) + Val(dg1.Rows(i).Cells(12).Value), "0.00")
            txtTotTaxable.Text = Format(Val(txtTotTaxable.Text) + Val(dg1.Rows(i).Cells(13).Value), "0.00")
        Next
        txtTotTotal.Text = Format(Val(txtTotTaxable.Text) + Val(txtTotTax.Text), "0.00")
        Dim tmpamount As Double = CDbl(txtTotTotal.Text)
        txtTotTotal.Text = Format(Math.Round(Val(tmpamount), 0), "0.00")
        txtTotRoundOff.Text = Format(Math.Round(Val(txtTotTotal.Text) - Val(tmpamount), 2), "0.00")
        txtTotCash.Text = Format(Val(txtTotTotal.Text), "0.00")
        txtTotChange.Text = Format(Val(txtTotChange.Text), "0.00")
        txtTotCash.Text = Format(Val(txtTotTotal.Text), "0.00")
        txtTotChange.Text = Format(Val(txtTotChange.Text), "0.00")
    End Sub
    Private Sub txtQty_TextChanged(sender As Object, e As EventArgs) Handles txtQty.TextChanged, txtRate.TextChanged,
        txtBasic.TextChanged, txtDisPer.TextChanged, txtDiscAmt.TextChanged, txtTaxPer.TextChanged, txtTaxAmt.TextChanged
        '  txtTotalAmt.TextChanged()
        calculation()
    End Sub
    Private Sub txtNet_Leave(sender As Object, e As EventArgs) Handles txtTotalAmt.Leave, txtQty.Leave, txtRate.Leave, txtDisPer.Leave, txtTaxPer.Leave
        txtQty.Text = Format(Val(txtQty.Text), "0.00") : txtRate.Text = Format(Val(txtRate.Text), "0.00")
        txtTaxPer.Text = Format(Val(txtTaxPer.Text), "0.00") : txtDisPer.Text = Format(Val(txtDisPer.Text), "0.00")
    End Sub
    Private Sub DgvAutoSerialNumbering()
        Dim SlNumber As Integer = 0
        If Me.dg1.Rows.Count = 0 Then
            SlNumber = 1
        ElseIf Me.dg1.Rows.Count > 0 Then
            For i As Integer = 0 To Me.dg1.Rows.Count - 1
                SlNumber = Me.dg1.Rows.Count
                Me.dg1.CurrentRow.Cells(1).Value = SlNumber
            Next
        End If
    End Sub

    Private Sub txtBillNo_GotFocus(sender As Object, e As EventArgs) Handles txtBillNo.GotFocus, txtItem.GotFocus, txtQty.GotFocus,
                txtRate.GotFocus, txtCustomerName.GotFocus, txtMobileNo.GotFocus, txtBasic.GotFocus, txtDisPer.GotFocus, txtDiscAmt.GotFocus,
                txtTaxPer.GotFocus, txtGSTNo.GotFocus, txtTaxAmt.GotFocus, txtAddress.GotFocus, txtDistrict.GotFocus ', txtpincode.GotFocus
        If txtItem.Focused Then dgItemSearch.Visible = True
        Dim tb As TextBox = CType(sender, TextBox)
        tb.BackColor = Color.Orange
        tb.SelectAll()
    End Sub

    Private Sub txtBillNo_LostFocus(sender As Object, e As EventArgs) Handles txtBillNo.LostFocus, txtItem.LostFocus, txtQty.LostFocus,
                txtRate.LostFocus, txtCustomerName.LostFocus, txtMobileNo.LostFocus, txtBasic.LostFocus, txtDisPer.LostFocus, txtDiscAmt.LostFocus,
                txtTaxPer.LostFocus, txtGSTNo.LostFocus, txtTaxAmt.LostFocus, txtAddress.LostFocus, txtDistrict.LostFocus
        Dim tb As TextBox = CType(sender, TextBox)
        tb.BackColor = Color.GhostWhite
    End Sub

    Private Sub txtItem_GotFocus(sender As Object, e As EventArgs) Handles txtItem.GotFocus
        ItemRowColumns()
        If txtItem.Text.Trim() <> "" Then
            retriveItems(" Where upper(ItemName) Like upper('" & txtItem.Text.Trim() & "%')")
        Else
            retriveItems()
        End If
    End Sub

    Private Sub txtQty_GotFocus(sender As Object, e As EventArgs) Handles txtQty.GotFocus
        If dgItemSearch.ColumnCount = 0 Then ItemRowColumns()
        If dgItemSearch.Rows.Count = 0 Then retriveItems()
        If dgItemSearch.SelectedRows.Count = 0 Then dgItemSearch.Visible = True : txtItem.Focus() : Exit Sub
        txtItemID.Text = Val(dgItemSearch.SelectedRows(0).Cells(0).Value)
        lblCode.Text = dgItemSearch.SelectedRows(0).Cells(1).Value
        txtItem.Text = dgItemSearch.SelectedRows(0).Cells(2).Value
        dgItemSearch.Visible = False : pickPrice()
    End Sub
    Private Sub mskEntryDate_GotFocus(sender As Object, e As EventArgs) Handles mskEntryDate.GotFocus, mskEntryDate.Click
        mskEntryDate.SelectAll()
    End Sub

    Private Sub mskEntryDate_KeyDown(sender As Object, e As KeyEventArgs) Handles mskEntryDate.KeyDown, txtBillNo.KeyDown,
      cbServiceType.KeyDown, txtItem.KeyDown, txtQty.KeyDown, txtRate.KeyDown, txtCustomerName.KeyDown, txtMobileNo.KeyDown,
       txtBasic.KeyDown, txtDisPer.KeyDown, txtDiscAmt.KeyDown, txtTaxPer.KeyDown, txtGSTNo.KeyDown, txtTaxAmt.KeyDown,
       ckIGST.KeyDown, txtAddress.KeyDown, txtDistrict.KeyDown, cbState.KeyDown, txtpincode.KeyDown
        If txtpincode.Focused Then
            If e.KeyCode = Keys.Enter Then
                If Dg2.Rows.Count = 0 Then
                    txtItem.Focus() : Exit Sub
                Else
                    If Dg2.Rows.Count = 0 Then txtItem.Focus() : Exit Sub
                    Dg2.Rows(0).Cells(0).Selected = True
                    Dg2.CurrentCell = Dg2.SelectedRows(0).Cells(0)
                End If
            End If
            Select Case e.KeyCode
                Case Keys.End
                    e.Handled = True
                    BtnSave.Focus()
            End Select
        End If

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
            e.SuppressKeyPress = True
        End If
        Select Case e.KeyCode
            Case Keys.End
                e.Handled = True
                txtTotCash.Focus()
        End Select
        If e.KeyCode = Keys.F3 Then
            Items.MdiParent = Me
            Items.Show()
            Items.BringToFront()
        End If
        If txtItem.Focused Or txtQty.Focused Or txtRate.Focused Or txtBasic.Focused Or txtTaxPer.Focused Or txtTotalAmt.Focused Or txtDisPer.Focused Then
            If e.KeyCode = Keys.Down Then
                If dgItemSearch.Visible = True Then dgItemSearch.Focus() : Exit Sub
                dg1.Rows(0).Selected = True : dg1.Focus()
            End If
        End If
        Select Case e.KeyCode
            Case Keys.PageUp
                e.Handled = True
                txtItem.Focus()
        End Select
        If txtBillNo.Focused Then
            If e.KeyCode = Keys.F2 Then
                pnlInvoiceID.Visible = True
                txtInvoiceID.Focus()
                e.SuppressKeyPress = True
            End If
        End If
        If txtItem.Focused Then
            If e.KeyCode = Keys.Down Then
                If dgItemSearch.Visible = True Then dgItemSearch.Focus() : Exit Sub
                If dg1.SelectedRows.Count = 0 Then Exit Sub
                dg1.Rows(0).Selected = True : dg1.Focus()
            End If
            If e.KeyCode = Keys.F3 Then
                Items.MdiParent = MainScreenForm
                Items.Show()
                Items.BringToFront()
            End If
            If e.KeyCode = Keys.F1 Then
                Items.MdiParent = MainScreenForm
                Items.FillControls(Val(dgItemSearch.SelectedRows(0).Cells(0).Value))
                Items.Show()
                Items.BringToFront()
            End If
        End If

        If txtQty.Focused Or txtRate.Focused Or txtBasic.Focused Or txtTotalAmt.Focused Then
            If e.KeyCode = Keys.Down Then
                dg1.Rows(0).Selected = True : dg1.Focus()
            End If
        End If

        If txtBillNo.Focused Then
            If e.KeyCode = Keys.F4 Then
                txtInvoiceID.Focus()
                txtInvoiceID.Visible = True
            End If
        End If
    End Sub

    Private Sub Dg2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dg2.CellContentClick
        ChooseService()
    End Sub

    Private Sub ChooseService()
        If Dg2.SelectedRows.Count = 0 Then Exit Sub
        Dg2.Rows(0).Cells(1).ReadOnly = True : Dg2.Rows(0).Cells(2).ReadOnly = True
        If Dg2.SelectedRows(0).Cells(0).Value = False Then
            Dg2.SelectedRows(0).Cells(0).Value = True
        Else
            Dg2.SelectedRows(0).Cells(0).Value = False
        End If
        Dim checkBox As DataGridViewCheckBoxCell
        For Each row As DataGridViewRow In Dg2.Rows
            checkBox = (TryCast(row.Cells("Present"), DataGridViewCheckBoxCell))
            If Convert.ToBoolean(checkBox.Value) = True Then
                TableNo = TableNo & row.Cells(1).Value & ","
                TableName = TableName & row.Cells(2).Value & ","
            End If
        Next
        If TableNo = "" Then dg1.Rows.Clear() : calc() : Exit Sub
        TableNo = TableNo.Remove(TableNo.LastIndexOf(","))
        Dim dt As New DataTable
        If BtnSave.Text = "&Save" Then
            If cbServiceType.SelectedIndex = 1 Then
                dt = clsFun.ExecDataTable("SELECT * FROM KOT AS K INNER JOIN KOTTrans AS KT ON K.ID = KT.KOTID Where Paid isnull and  RoomVoucherID in (" & TableNo & ")")
            Else
                dt = clsFun.ExecDataTable("SELECT * FROM KOT AS K INNER JOIN KOTTrans AS KT ON K.ID = KT.KOTID Where Paid isnull and  TableID in ('" & TableNo & "')")
            End If

        End If
        Try
            If dt.Rows.Count > 0 Then
                dg1.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("Itemid").ToString()
                        .Cells(1).Value = dg1.Rows.Count
                        .Cells(2).Value = clsFun.ExecScalarStr("Select ItemCode From Item_View Where ID= " & dt.Rows(i)("ItemID").ToString() & "")
                        .Cells(3).Value = dt.Rows(i)("ItemName").ToString()
                        .Cells(4).Value = clsFun.ExecScalarStr("Select RatePer From Item_View Where ID= " & dt.Rows(i)("ItemID").ToString() & "")
                        .Cells(5).Value = Format(Val(dt.Rows(i)("Qty").ToString()), "0")
                        .Cells(6).Value = Format(Val(dt.Rows(i)("Rate").ToString()), "0.00")
                        .Cells(7).Value = Format(Val(dt.Rows(i)("Amount").ToString()), "0.00")
                        .Cells(8).Value = Format(Val(0), "0.00")
                        .Cells(9).Value = Format(Val(0), "0.00")
                        .Cells(10).Value = Format(Val(clsFun.ExecScalarStr("Select GSTPer From Item_View Where ID= " & dt.Rows(i)("ItemID").ToString() & "")), "0.00")
                        .cells(13).value = Format((Val(.Cells(7).Value) - Val(.Cells(9).Value)), "0.00")
                        .Cells(11).Value = Format(Val(Val(.Cells(10).Value) * Val(.cells(13).value) / 100), "0.00")
                        .Cells(12).Value = Format(Val(Val(.cells(13).value) - Val(.Cells(9).Value) + Val(.Cells(11).Value)), "0.00")
                        .Cells(14).Value = CDate(dt.Rows(i)("EntryDate")).ToString("yyyy-MM-dd")
                    End With
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "Atithi")
        End Try
        dg1.ClearSelection() : calc()
    End Sub

    Private Sub Dg2_KeyDown(sender As Object, e As KeyEventArgs) Handles Dg2.KeyDown
        'If e.KeyCode = Keys.Enter Then
        '    txtItem.Focus() : Dg2.ClearSelection()
        '    e.SuppressKeyPress = True
        'End If
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If cbServiceType.SelectedIndex <> 2 Then
                Dim isChecked As Boolean = Dg2.Rows.Cast(Of DataGridViewRow)().Any(Function(row) Convert.ToBoolean(row.Cells("Present").Value))
                'Dim isChecked As Boolean = CBool(checkBoxCell.Value)
                If isChecked = False Then MsgBox("Please Select Table / Room No. to Make Food BIll", vbCritical.Critical, "Access Denies") : Dg2.Focus() : Exit Sub
            End If
            Dg2.ClearSelection() : txtItem.Focus()
        End If
    End Sub
    Private Sub PrintRecord()
        Dim AllRecord As Integer = Val(tempdt.Rows.Count)
        Dim maxRowCount As Decimal = Math.Ceiling(AllRecord / 100)
        Dim LastCount As Integer = 0
        Dim TotalRecord As Integer = 0
        Dim LastRecord As Integer = 0
        Dim count As Integer = 0 : Dim cmd As New SQLite.SQLiteCommand
        Dim FastQuery As String = String.Empty
        Dim Sql As String = String.Empty
        Dim marka As String = clsFun.ExecScalarStr("Select Marka From Company")
        ClsFunPrimary.ExecNonQuery("Delete from printing")
        For i As Integer = 0 To maxRowCount - 1
            FastQuery = String.Empty : TotalRecord = (AllRecord - LastRecord)
            For LastCount = 0 To IIf(i = (maxRowCount - 1), Val(TotalRecord - 1), 99)
                With tempdt.Rows(LastRecord)
                    FastQuery = FastQuery & IIf(FastQuery <> "", " UNION ALL SELECT ", " SELECT ") & "'" & .Cells(0).Value & "','" & .Cells(1).Value & "','" & .Cells(2).Value & "','" & .Cells(3).Value & "','" & .Cells(4).Value & "', " & _
                           "'" & .Cells(5).Value & "','" & .Cells(6).Value & "','" & .Cells(7).Value & "','" & .Cells(8).Value & "','" & .Cells(9).Value & "'," & _
                           "'" & .Cells(10).Value & "','" & .Cells(11).Value & "','" & .Cells(12).Value & "','" & .Cells(13).Value & "','" & .Cells(14).Value & "'," & _
                           "'" & .Cells(15).Value & "','" & .Cells(16).Value & "','" & .Cells(17).Value & "','" & .Cells(18).Value & "','" & .Cells(19).Value & "'," & _
                           "'" & .Cells(20).Value & "','" & .Cells(21).Value & "','" & .Cells(22).Value & "','" & .Cells(23).Value & "','" & .Cells(24).Value & "'," & _
                           "'" & .Cells(25).Value & "','" & .Cells(26).Value & "','" & .Cells(27).Value & "','" & .Cells(28).Value & "','" & .Cells(29).Value & "'," & _
                           "'" & .Cells(30).Value & "','" & .Cells(31).Value & "','" & .Cells(32).Value & "','" & .Cells(33).Value & "','" & .Cells(34).Value & "'," & _
                           "'" & .Cells(35).Value & "','" & .Cells(36).Value & "','" & .Cells(37).Value & "','" & .Cells(38).Value & "','" & .Cells(39).Value & "'," & _
                           "'" & .Cells(40).Value & "','" & .Cells(41).Value & "','" & .Cells(42).Value & "','" & .Cells(43).Value & "'"
                End With
                LastRecord = Val(LastRecord + 1)
            Next
            Try
                If FastQuery = String.Empty Then Exit Sub
                Sql = "insert into Printing(D1,M1,M2,M3,M4,P1,P2,P3,P4,P5,P6,P7,P8,P9,P10,P11,P12,P13,P14,P15,P16,P17,P18,P19,P20,P21,P22,P23,P24,P25, " & _
              "P26,P27,P28,P29,P30,P31,P32,P33,P34,P35,P36,P37,P38,P39)" & FastQuery & ""
                ClsFunPrimary.ExecNonQuery(Sql)
            Catch ex As Exception
                MsgBox(ex.Message)
                ClsFunPrimary.CloseConnection()
            End Try
        Next
    End Sub
    'Private Sub PrintRecord()
    '    Dim count As Integer = 0
    '    Dim cmd As New SQLite.SQLiteCommand
    '    Dim sql As String = String.Empty
    '    ClsFunPrimary.ExecNonQuery("Delete from printing")
    '    ' clsFun.ExecNonQuery(sql)
    '    For Each row As DataGridViewRow In tempdt.Rows
    '        With row
    '            sql = sql & "insert into Printing(D1,M1,M2,M3,M4,P1,P2,P3,P4,P5,P6,P7,P8,P9,P10,P11,P12,P13,P14,P15,P16,P17,P18,P19,P20,P21,P22,P23,P24,P25, " & _
    '                "P26,P27,P28,P29,P30,P31,P32,P33,P34,P35,P36,P37,P38,P39)" & _
    '       "  values('" & .Cells(0).Value & "','" & .Cells(1).Value & "','" & .Cells(2).Value & "','" & .Cells(3).Value & "','" & .Cells(4).Value & "', " & _
    '       "'" & .Cells(5).Value & "','" & .Cells(6).Value & "','" & .Cells(7).Value & "','" & .Cells(8).Value & "','" & .Cells(9).Value & "'," & _
    '       "'" & .Cells(10).Value & "','" & .Cells(11).Value & "','" & .Cells(12).Value & "','" & .Cells(13).Value & "','" & .Cells(14).Value & "'," & _
    '       "'" & .Cells(15).Value & "','" & .Cells(16).Value & "','" & .Cells(17).Value & "','" & .Cells(18).Value & "','" & .Cells(19).Value & "'," & _
    '       "'" & .Cells(20).Value & "','" & .Cells(21).Value & "','" & .Cells(22).Value & "','" & .Cells(23).Value & "','" & .Cells(24).Value & "'," & _
    '       "'" & .Cells(25).Value & "','" & .Cells(26).Value & "','" & .Cells(27).Value & "','" & .Cells(28).Value & "','" & .Cells(29).Value & "'," & _
    '       "'" & .Cells(30).Value & "','" & .Cells(31).Value & "','" & .Cells(32).Value & "','" & .Cells(33).Value & "','" & .Cells(34).Value & "'," & _
    '       "'" & .Cells(35).Value & "','" & .Cells(36).Value & "','" & .Cells(37).Value & "','" & .Cells(38).Value & "','" & .Cells(39).Value & "'," & _
    '       "'" & .Cells(40).Value & "','" & .Cells(41).Value & "','" & .Cells(42).Value & "','" & .Cells(43).Value & "');"
    '            'End If
    '        End With
    '    Next
    '    Try
    '        cmd = New SQLite.SQLiteCommand(sql, ClsFunPrimary.GetConnection())
    '        ClsFunPrimary.ExecNonQuery(sql)
    '        'If cmd.ExecuteNonQuery() > 0 Then

    '        'End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        ClsFunPrimary.CloseConnection()
    '    End Try
    '    ' clsFun.ExecNonQuery(sql)
    'End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If dg1.Rows.Count = 0 Then MsgBox("There is No Items to Save", vbCritical.Critical, "Add Some Items") : txtItem.Focus() : Exit Sub
        If cbServiceType.SelectedIndex <> 2 Then
            Dim isChecked As Boolean = Dg2.Rows.Cast(Of DataGridViewRow)().Any(Function(row) Convert.ToBoolean(row.Cells("Present").Value))
            'Dim isChecked As Boolean = CBool(checkBoxCell.Value)
            If isChecked = False Then MsgBox("Please Select Table / Room No. to Make Food BIll", vbCritical.Critical, "Access Denies") : Dg2.Focus() : Exit Sub
        End If

        If dg1.RowCount = 0 Then txtItem.Focus() : Exit Sub
        If txtTotChange.Text <> txtCardPayment.Text Then
            pnlCreditBalance.Visible = True
            txtCardPayment.Text = txtTotChange.Text
            txtCardPayment.Focus() : Exit Sub
        End If
        If txtCardPayment.Text > 0 Then
            If cbBank.Text = "" Then
                pnlCreditBalance.Visible = True
                cbBank.Focus() : Exit Sub
            End If
        End If
        If BtnSave.Text = "&Save" Then
            save()
        Else
            Update()
        End If
        MainScreenPicture.lblTbleTotal.Text = Val(clsFun.ExecScalarStr("Select Count(*) FROM KOT Where EntryDate='" & CDate(Date.Now).ToString("yyyy-MM-dd") & "'"))
        MainScreenPicture.lblTotalFood.Text = Val(clsFun.ExecScalarStr("Select Count(*) from Vouchers Where TransType='Bill' And EntryDate='" & CDate(Date.Now).ToString("yyyy-MM-dd") & "'"))
        MainScreenPicture.RestroTables()
        ' If ckWhatsapp.Checked = True Then SendOnWHatsapp()
        Dim res = MessageBox.Show("Do you want to Print Bill", "Print Bil", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If res = Windows.Forms.DialogResult.Yes Then
            FillData()
            clsFun.CloseConnection()
            If clsFun.ExecScalarStr("Select BillPreView From Options") = "Y" Then
                PrintRecord()
                Report_Viewer.printReport("\FoodBill.rpt")
                Report_Viewer.MdiParent = MainScreenForm
                Report_Viewer.Show()
                If Not Report_Viewer Is Nothing Then
                    Report_Viewer.BringToFront()
                End If
            Else
                clsFun.changeCompany()
                PrintRecord()
                Report_Viewer.printReportDirect("\FoodBill.rpt")
            End If
        Else

        End If
        '  '  Dim Result As DialogResult = CustomMsgBox.ShowCustomMessageBox("What do You want to Do?", "Print Food Bill", MessageBoxIcon.Question, MessageBoxButtons.YesNo)
        '  Dim result As Windows.Forms.DialogResult = CustomMsgBox.ShowCustomMessageBox("Do you want to print the food bill?", "Print Food Bill", MessageBoxIcon.Question, MessageBoxButtons.YesNo)
        'If result = Windows.Forms.DialogResult.Yes Then
        '      ' User clicked Yes button
        '      MsgBox("A")
        '  ElseIf Result = Windows.Forms.DialogResult.No Then
        '      ' User clicked No button
        '      MsgBox("B")
        '  End If


    End Sub
    Private Sub SendOnWHatsapp()
        If txtMobileNo.Text <> "" Then
            Dim p() As Process
            p = Process.GetProcessesByName("Easy Whatsapp")
            If p.Count = 0 Then
                Dim StartWhatsapp As New System.Diagnostics.Process
                StartWhatsapp.StartInfo.FileName = Application.StartupPath & "\Whatsapp\Easy Whatsapp.exe"
                StartWhatsapp.Start()
            End If
            SendWhatsappData()

        End If
    End Sub
    Private Sub SendWhatsappData()
        Dim directoryName As String = Application.StartupPath & "\Whatsapp\Pdfs"
        For Each deleteFile In Directory.GetFiles(directoryName, "*.PDf*", SearchOption.TopDirectoryOnly)
            File.Delete(deleteFile)
        Next
        Dim count As Integer = 0
        Dim cmd As New SQLite.SQLiteCommand
        Dim sql As String = ""
        Dim con As SQLite.SQLiteConnection = clsFun.GetConnection
        ClsFunWhatsapp.ExecNonQuery("Delete from SendingData")

        'pnlWahtsappNo.Visible = True
        'txtWhatsappNo.Focus()
        GlobalData.PdfName = txtCustomerName.Text & "-" & mskEntryDate.Text & ".pdf"
        PrintRecord()
        Pdf_Genrate.ExportReport("\Formats\FoodBill.rpt")
        sql = "insert into SendingData(AccountID,AccountName,MobileNos,AttachedFilepath) values  " & _
         "('" & Val(0) & "','" & txtCustomerName.Text & "','" & txtMobileNo.Text & "','" & GlobalData.PdfPath & "')"
        If ClsFunWhatsapp.ExecNonQuery(sql) > 0 Then
            sql = "Update Settings Set MinState='N'"
            ClsFunWhatsapp.ExecScalarStr(sql)
            'MsgBox("Data Send to Easy Whatsapp Successfully...", vbInformation, "Sended On Easy Whatsapp")
        End If
    End Sub

    'Private Sub ShowCustomMessageBox()
    '    Dim customMessageBox As New Form()
    '    customMessageBox.Text = "Print Bill"
    '    customMessageBox.FormBorderStyle = FormBorderStyle.FixedDialog
    '    customMessageBox.ControlBox = False
    '    customMessageBox.MaximizeBox = False
    '    customMessageBox.MinimizeBox = False
    '    customMessageBox.StartPosition = FormStartPosition.CenterScreen
    '    customMessageBox.BackColor = Color.GhostWhite
    '    Dim label As New Label()
    '    label.Text = "What do you want to do?"
    '    label.AutoSize = True
    '    label.Location = New Point(50, 30)
    '    label.ForeColor = Color.Navy
    '    Dim whatsappButton As New Button()
    '    whatsappButton.Text = "Whatsapp"
    '    whatsappButton.DialogResult = DialogResult.Yes
    '    whatsappButton.Location = New Point(20, 70)

    '    Dim previewButton As New Button()
    '    previewButton.Text = "Preview"
    '    previewButton.DialogResult = DialogResult.No
    '    previewButton.Location = New Point(100, 70)

    '    Dim printButton As New Button()
    '    printButton.Text = "Print"
    '    printButton.DialogResult = DialogResult.Cancel
    '    printButton.Location = New Point(180, 70)

    '    Dim noButton As New Button()
    '    noButton.Text = "No"
    '    noButton.DialogResult = DialogResult.Abort
    '    noButton.Location = New Point(260, 70)

    '    Dim iconPictureBox As New PictureBox()
    '    iconPictureBox.Location = New Point(10, 20)
    '    iconPictureBox.Size = New Size(32, 32)

    '    customMessageBox.ClientSize = New Size(350, 100)
    '    customMessageBox.Controls.Add(label)
    '    customMessageBox.Controls.Add(whatsappButton)
    '    customMessageBox.Controls.Add(previewButton)
    '    customMessageBox.Controls.Add(printButton)
    '    customMessageBox.Controls.Add(noButton)
    '    customMessageBox.Controls.Add(iconPictureBox)

    '    Dim icon As MessageBoxIcon = MessageBoxIcon.Question ' Default icon

    '    ' Set the icon based on your requirement
    '    Select Case icon
    '        Case MessageBoxIcon.Information
    '            iconPictureBox.Image = SystemIcons.Information.ToBitmap()
    '        Case MessageBoxIcon.Question
    '            iconPictureBox.Image = SystemIcons.Question.ToBitmap()
    '        Case MessageBoxIcon.Warning
    '            iconPictureBox.Image = SystemIcons.Warning.ToBitmap()
    '        Case MessageBoxIcon.Error
    '            iconPictureBox.Image = SystemIcons.Error.ToBitmap()
    '    End Select

    '    Dim result As DialogResult = customMessageBox.ShowDialog()

    '    If result = DialogResult.Yes Then
    '        ' code for "Whatsapp" button
    '        MsgBox("A")
    '    ElseIf result = DialogResult.No Then
    '        ' code for "Preview" button
    '        MsgBox("B")
    '    ElseIf result = DialogResult.Cancel Then
    '        ' code for "Print" button
    '        MsgBox("C")
    '    ElseIf result = DialogResult.Abort Then
    '        ' code for "No" button
    '        MsgBox("D")
    '    End If
    'End Sub


    Private Sub cbServiceType_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cbServiceType.SelectedIndexChanged
        dg2Columns()
    End Sub

    Private Sub dg1_KeyDown(sender As Object, e As KeyEventArgs) Handles dg1.KeyDown
        If e.KeyCode = Keys.Delete Then
            If dg1.SelectedRows.Count = 0 Then Exit Sub
            If MessageBox.Show("Are You Sure Want to Delete Selected Item ?", "Delete Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                dg1.Rows.Remove(dg1.SelectedRows(0))
                DgvAutoSerialNumbering() : dg1.ClearSelection() : calc()
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            If dg1.SelectedRows.Count = 0 Then Exit Sub
            txtItemID.Text = Val(dg1.SelectedRows(0).Cells(0).Value)
            txtItem.Text = dg1.SelectedRows(0).Cells(3).Value
            lblUnit.Text = dg1.SelectedRows(0).Cells(4).Value
            txtQty.Text = dg1.SelectedRows(0).Cells(5).Value
            txtRate.Text = dg1.SelectedRows(0).Cells(6).Value
            txtBasic.Text = dg1.SelectedRows(0).Cells(7).Value
            txtDisPer.Text = dg1.SelectedRows(0).Cells(8).Value
            txtDiscAmt.Text = dg1.SelectedRows(0).Cells(9).Value
            txtTaxPer.Text = dg1.SelectedRows(0).Cells(10).Value
            txtTaxAmt.Text = dg1.SelectedRows(0).Cells(11).Value
            txtTotalAmt.Text = dg1.SelectedRows(0).Cells(12).Value
            txtTaxable.Text = dg1.SelectedRows(0).Cells(13).Value
            txtItem.Focus() : e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub dg1_MouseClick(sender As Object, e As MouseEventArgs) Handles dg1.MouseClick
        If dg1.SelectedRows.Count = 0 Then Exit Sub
        dg1.ClearSelection()
    End Sub

    Private Sub dg1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dg1.MouseDoubleClick
        If dg1.SelectedRows.Count = 0 Then Exit Sub
        txtItemID.Text = dg1.SelectedRows(0).Cells(0).Value
        txtItem.Text = dg1.SelectedRows(0).Cells(3).Value
        lblUnit.Text = dg1.SelectedRows(0).Cells(4).Value
        txtQty.Text = dg1.SelectedRows(0).Cells(5).Value
        txtRate.Text = dg1.SelectedRows(0).Cells(6).Value
        txtBasic.Text = dg1.SelectedRows(0).Cells(7).Value
        txtDisPer.Text = dg1.SelectedRows(0).Cells(8).Value
        txtDiscAmt.Text = dg1.SelectedRows(0).Cells(9).Value
        txtTaxPer.Text = dg1.SelectedRows(0).Cells(10).Value
        txtTaxAmt.Text = dg1.SelectedRows(0).Cells(11).Value
        txtTotalAmt.Text = dg1.SelectedRows(0).Cells(12).Value
        txtTaxable.Text = dg1.SelectedRows(0).Cells(13).Value
        txtItem.Focus()
    End Sub

    Private Sub txtTotCash_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTotCash.KeyDown
        If e.KeyCode = Keys.Enter Then
            pnlCreditBalance.Visible = True : txtCardPayment.Focus()
        End If
    End Sub

    Private Sub txtTotCash_Leave(sender As Object, e As EventArgs) Handles txtTotCash.Leave
        txtTotCash.Text = Format(Val(txtTotCash.Text), "0.00")
        txtCardPayment.Text = txtTotChange.Text
    End Sub

    Private Sub txtTotCash_TextChanged(sender As Object, e As EventArgs) Handles txtTotCash.TextChanged, txtTotChange.TextChanged
        txtTotChange.Text = Format(Val(txtTotTotal.Text) - Val(txtTotCash.Text), "0.00")
        '   txtCardPayment.Text = txtTotChange.Text
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        pnlCeditClear()
    End Sub
    Private Sub pnlCeditClear()
        pnlCreditBalance.Visible = False : BtnSave.Focus()
        If BtnSave.Text <> "&Save" Then Exit Sub
        txtCardPayment.Clear() : txtRefNo.Clear()
        cbBank.Text = "" : cbBank.SelectedValue = 0
        txtRemark.Clear()
    End Sub
    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        pnlCreditBalance.Visible = False : BtnSave.PerformClick()
    End Sub

    Private Sub txtCardPayment_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCardPayment.KeyDown, txtRefNo.KeyDown,
        cbBank.KeyDown, txtRemark.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txtCardPayment_TextChanged(sender As Object, e As EventArgs) Handles txtCardPayment.TextChanged
        If Val(txtCardPayment.Text) <> 0 Then
            ' cbBank.SelectedIndex = 0
            cbBank.Enabled = True
        Else
            cbBank.SelectedIndex = -1
            cbBank.SelectedValue = 0
            cbBank.Text = ""
            cbBank.Enabled = False
        End If
        '   txtTotChange.Text = Format(Val(txtTotCash.Text) - Val(txtCardPayment.Text), "0.00")

    End Sub

    Private Sub pnlCreditBalance_VisibleChanged(sender As Object, e As EventArgs) Handles pnlCreditBalance.VisibleChanged
        If pnlCreditBalance.Visible = True Then
            clsFun.FillDropDownList(cbBank, "Select ID,AccountName From Account_AcGrp where (Groupid in(12,16)  or UnderGroupID in (12,16))", "AccountName", "Id", "")
        End If

    End Sub


    Private Sub cbState_Leave(sender As Object, e As EventArgs) Handles cbState.Leave
        lblStateCode.Text = Format(Val(clsFun.ExecScalarStr("Select  StateGSTCodes as State  From StateList Where ID='" & Val(cbState.SelectedValue) & "'")), "00")
    End Sub

    Private Sub dtp1_ValueChanged(sender As Object, e As EventArgs) Handles Dtp1.ValueChanged
        mskEntryDate.Text = Dtp1.Value.ToString("dd-MM-yyyy")
        mskEntryDate.Text = clsFun.convdate(mskEntryDate.Text)
    End Sub

    Private Sub txtInvoiceID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtInvoiceID.KeyDown
        If e.KeyCode = Keys.Enter Then pnlInvoiceID.Visible = False : mskEntryDate.Focus()
    End Sub

    Private Sub txtInvoiceID_Leave(sender As Object, e As EventArgs) Handles txtInvoiceID.Leave
        pnlInvoiceID.Visible = False : txtBillNo.Focus()
    End Sub


    Private Sub mskEntryDate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mskEntryDate.Validating
        mskEntryDate.Text = clsFun.convdate(mskEntryDate.Text)
    End Sub

    Private Sub txtGSTNo_TextChanged(sender As Object, e As EventArgs) Handles txtGSTNo.TextChanged
        Try
            If GSTINValidator.IsValid(txtGSTNo.Text) Then
                lbl_Result.ForeColor = Color.Green
                lbl_Result.Text = "Valid"
                lbl_Result.Visible = True
                txtGSTNo.ForeColor = Color.Navy
            Else
                lbl_Result.ForeColor = Color.Red
                lbl_Result.Text = "Invalid!"
                lbl_Result.Visible = True
                txtGSTNo.ForeColor = Color.Red
            End If
        Catch ex As Exception
            lbl_Result.ForeColor = Color.Red
            txtGSTNo.ForeColor = Color.Red
            lbl_Result.Text = ex.Message
        End Try
    End Sub


    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        Offset = 0
        FillWithNevigation()
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        If Offset = 0 Then
            Offset = clsFun.ExecScalarInt("Select Count(*) FROM Vouchers WHERE transtype = 'Food Bill'  Order By ID ")
        End If
        Offset -= RowCount
        If Offset <= 0 Then
            Offset = 0
        End If
        FillWithNevigation()
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Dim currentPage As Integer = (Offset / RowCount) + 1
        If currentPage <> TotalPages Then
            Offset += RowCount
        Else
            Offset = 0
        End If

        FillWithNevigation()
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        'Dim recordsCount As Integer = clsFun.ExecScalarInt("Select Count(*) FROM Vouchers WHERE transtype = 'Standard Sale'  Order By ID ")
        Dim recordsCount As Integer = clsFun.ExecScalarInt("Select Count(*) FROM Vouchers WHERE transtype = 'Food Bill'  Order By ID ")
        TotalPages = Math.Ceiling(recordsCount / RowCount)
        Offset = (TotalPages - 1) * RowCount
        FillWithNevigation()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        txtClearAll()
    End Sub

    Private Sub txtItem_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtItem.KeyPress
        If Not Char.IsLetterOrDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso e.KeyChar <> "%" AndAlso Not Char.IsControl(e.KeyChar) AndAlso e.KeyChar <> " " Then
            e.Handled = True
        End If
    End Sub

    Private Sub Dg2_GotFocus(sender As Object, e As EventArgs) Handles Dg2.GotFocus
        If Dg2.SelectedRows.Count = 0 Then Exit Sub
        Dg2.Focus() : Dg2.CurrentCell = Dg2.SelectedRows(0).Cells(0)
    End Sub

    'Private Sub Dg2_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Dg2.GotFocus
    '    If e.RowIndex >= 0 AndAlso Dg2.Rows(e.RowIndex).Cells(0).Value = True Then
    '        e.CellStyle.BackColor = Color.Orange 'set the background color of the cell to LightGreen
    '    End If
    'End Sub

    Private Sub Dg2_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Dg2.CellFormatting
        If e.RowIndex >= 0 AndAlso Dg2.Rows(e.RowIndex).Cells(0).Value = True Then
            e.CellStyle.BackColor = Color.Orange 'set the background color of the cell to LightGreen
        End If
    End Sub


End Class