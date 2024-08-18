Public Class Purchase
    Dim PrintCopies As String : Dim Hash As String = "0.00"
    Dim IGSTPER As Decimal : Dim IGSTAMT As Decimal
    Dim SGSTPER As Decimal : Dim SGSTAMT As Decimal
    Dim CGSTPER As Decimal : Dim CGSTAMT As Decimal
    Dim CessPer As Decimal : Dim CessAmt As Decimal
    Dim ItemTotalTax As Decimal : Dim TaxableTotal As Decimal

    Private Sub Purchase_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub Purchase_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0 : Me.Left = 0
        mskEntryDate.Text = Date.Today.ToString("dd-MM-yyyy")
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        clsFun.FillDropDownList(CbSeries, "Select ID,InvoiceTypeName From InvoiceType Where AccountID=36 and InvoiceTypeName ='Purchase' ", "InvoiceTypeName", "Id", "")
        dg1Columns() : ItemRowColumns() : dg2Columns() : VNumber()
    End Sub
    'Private Sub VNumber()
    '    Vno = clsFun.ExecScalarInt("SELECT Count(ID) AS BillNo FROM Vouchers Where TransType='" & Me.Text & "'")
    '    txtBillNo.Text = Vno + 1
    'End Sub
    Private Sub VNumber()
        Dim vno As Integer = 0
        If vno = Val(clsFun.ExecScalarInt("Select Max(InvoiceID) AS NumberOfProducts FROM Vouchers Where TransType='" & Me.Text & "'")) <> 0 Then
            vno = clsFun.ExecScalarInt("Select Count(ID) AS NumberOfProducts FROM Vouchers Where TransType='" & Me.Text & "'")
            txtBillNo.Text = vno + 1
            txtInvoiceID.Text = Val(vno + 1)
        Else
            vno = clsFun.ExecScalarInt("Select Max(InvoiceID)  AS NumberOfProducts FROM Vouchers WHERE id=(SELECT max(id) FROM Vouchers Where TransType='" & Me.Text & "')")
            txtBillNo.Text = vno + 1
            txtInvoiceID.Text = Val(vno + 1)
        End If
    End Sub
    Private Sub AcBal()
        Dim opbal As String = ""
        Dim ClBal As String = ""
        opbal = clsFun.ExecScalarStr(" SELECT (OpBal) FROM Accounts WHERE ID=  " & Val(txtAccountID.Text) & "")
        Dim tmpamtdr As String = clsFun.ExecScalarStr("SELECT sum(Amount) as tot from Ledger where Dc='D' and accountID=" & Val(txtAccountID.Text) & " and EntryDate <= '" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "'")
        Dim tmpamtcr As String = clsFun.ExecScalarStr("SELECT sum(Amount) as tot from Ledger where Dc='C' and accountID=" & Val(txtAccountID.Text) & " and EntryDate <= '" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "'")
        ' opbal = clsFun.ExecScalarStr(" SELECT (OpBal) FROM Accounts WHERE AccountName like '%" + cbAccountName.Text + "%'")
        Dim drcr As String = clsFun.ExecScalarStr(" SELECT Dc FROM Accounts WHERE ID= " & Val(txtAccountID.Text) & "")
        If drcr = "Dr" Then
            tmpamtdr = Val(opbal) + Val(tmpamtdr)
        Else
            tmpamtcr = Val(opbal) + Val(tmpamtcr)
        End If
        Dim tmpamt As String = IIf(Val(tmpamtdr) > Val(tmpamtcr), Val(tmpamtdr) - Val(tmpamtcr), Val(tmpamtcr) - Val(tmpamtdr)) '- Val(opbal)
        If drcr = "Cr" Then
            opbal = Math.Round(Math.Abs(Val(tmpamt)), 2) & " Cr"
        Else
            opbal = Math.Round(Math.Abs(Val(tmpamt)), 2) & " Dr"
        End If
        Dim cntbal As Integer = 0
        cntbal = clsFun.ExecScalarInt("select count(*) from ledger where  accountid=" & Val(txtAccountID.Text) & " and  EntryDate <= '" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "'")
        If cntbal = 0 Then
            opbal = Math.Round(Math.Abs(Val(tmpamt)), 2) & " " & clsFun.ExecScalarStr(" select dc from accounts where id= " & Val(txtAccountID.Text) & "")
        Else
            If Val(tmpamtcr) > Val(tmpamtdr) Then
                opbal = Format(Math.Abs(Val(tmpamt)), "0.00") & " Cr"
            Else
                opbal = Format(Math.Abs(Val(tmpamt)), "0.00") & " Dr"
            End If
        End If
        lblAcBal.Visible = True
        lblAcBal.Text = "Bal : " & opbal
    End Sub
    Private Sub StockBal()
        Dim ItemStock As Decimal = 0.0 : Dim PurchaseStock As Decimal = 0.0
        Dim SaleStock As Decimal = 0.0 : Dim BalStock As String = 0.0
        Dim RestBal As String = 0.0 : Dim tmpbal As String = ""
        ItemStock = clsFun.ExecScalarDec("Select sum(OpStock) From Items Where ID='" & Val(txtItemID.Text) & "'")
        PurchaseStock = Val(clsFun.ExecScalarStr("Select sum(Qty) From Trans Where TransType ='Purchase' and ItemID='" & Val(txtItemID.Text) & "'"))
        SaleStock = Val(clsFun.ExecScalarStr("Select sum(Qty) From Trans Where TransType ='Sale' and ItemID='" & Val(txtItemID.Text) & "'"))
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
                                tmpbal = Val(tmpbal) + Val(dg1.Rows(i).Cells(5).Value)
                            End If
                        Next i
                        tmpbal = (tmpbal)
                    End If
                    bal = Val(RestBal) + Val(tmpbal)
                Else
                    If dg1.RowCount = 0 Then ' if any Record Inserted in Database but Row not Added
                        bal = (RestBal)
                    Else
                        For i As Integer = 0 To dg1.RowCount - 1 'if any Record Inserted in Database and Row Added
                            If dg1.Rows(i).Cells(0).Value = txtItemID.Text Then
                                tmpbal = Val(tmpbal) + Val(dg1.Rows(i).Cells(5).Value)
                            End If
                        Next i
                        bal = Val(RestBal) + Val(tmpbal)
                    End If
                End If
            Else
                If Val(SaleStock) = 0 Then
                    For i As Integer = 0 To dg1.RowCount - 1
                        If dg1.Rows(i).Cells(0).Value = txtItemID.Text Then
                            tmpbal = Val(tmpbal) + Val(dg1.Rows(i).Cells(5).Value)
                        End If
                    Next i
                    tmpbal = Val(RestBal) + Val(tmpbal)
                    tmpbal = Val(tmpbal) + Val(dg1.SelectedRows(0).Cells(5).Value)
                    bal = Val(tmpbal)
                Else
                    For i As Integer = 0 To dg1.RowCount - 1
                        If dg1.Rows(i).Cells(0).Value = txtItemID.Text Then
                            tmpbal = Val(tmpbal) + Val(dg1.Rows(i).Cells(5).Value)
                        End If
                    Next i
                    tmpbal = Val(RestBal) + Val(tmpbal)
                    tmpbal = (tmpbal) + Val(dg1.SelectedRows(0).Cells(5).Value)
                    bal = Val(tmpbal)
                End If
            End If
        End If
        '  End If
        lblStock.Text = "Stock : " & bal
    End Sub
    Private Sub dg1Columns()
        dg1.ColumnCount = 22
        dg1.Columns(0).Name = "Itemid" : dg1.Columns(0).Visible = False
        dg1.Columns(1).Name = "SN" : dg1.Columns(1).Width = 20
        dg1.Columns(2).Name = "Code" : dg1.Columns(2).Visible = False
        dg1.Columns(3).Name = "Item Name" : dg1.Columns(3).Width = 300
        dg1.Columns(4).Name = "Unit" : dg1.Columns(4).Visible = False
        dg1.Columns(5).Name = "Qty" : dg1.Columns(5).Width = 79
        dg1.Columns(6).Name = "Rate" : dg1.Columns(6).Width = 99
        dg1.Columns(7).Name = "Basic" : dg1.Columns(7).Width = 112
        dg1.Columns(8).Name = "D%" : dg1.Columns(8).Width = 74
        dg1.Columns(9).Name = "Disc" : dg1.Columns(9).Width = 80
        dg1.Columns(10).Name = "Taxable" : dg1.Columns(10).Width = 112
        dg1.Columns(11).Name = "T%" : dg1.Columns(11).Width = 74
        dg1.Columns(12).Name = "Tax" : dg1.Columns(12).Width = 80
        dg1.Columns(13).Name = "Total" : dg1.Columns(13).Width = 144
        dg1.Columns(14).Name = "IGSTPer" : dg1.Columns(14).Width = 80
        dg1.Columns(15).Name = "IGSTAmt" : dg1.Columns(15).Width = 80
        dg1.Columns(16).Name = "CGSTPer" : dg1.Columns(16).Width = 80
        dg1.Columns(17).Name = "CGStAmt" : dg1.Columns(17).Width = 80
        dg1.Columns(18).Name = "SGStPer" : dg1.Columns(18).Width = 80
        dg1.Columns(19).Name = "SGSTAmt" : dg1.Columns(19).Width = 80
        dg1.Columns(20).Name = "CessPer" : dg1.Columns(20).Width = 48
        dg1.Columns(21).Name = "CessAmt" : dg1.Columns(21).Width = 79
        dg1.DefaultCellStyle.SelectionBackColor = Color.Orange
        dg1.DefaultCellStyle.SelectionForeColor = Color.White
        dg1.EnableHeadersVisualStyles = False
        dg1.ColumnHeadersDefaultCellStyle.ForeColor = Color.BlueViolet
        dg1.ColumnHeadersDefaultCellStyle.BackColor = Color.White
    End Sub
    Private Sub dg2Columns()
        Dg2.ColumnCount = 10
        Dg2.Columns(0).Name = "SN." : Dg2.Columns(0).Width = 30
        Dg2.Columns(1).Name = "ChargeID" : Dg2.Columns(1).Visible = False
        Dg2.Columns(2).Name = "Charge Name" : Dg2.Columns(2).Width = 128
        Dg2.Columns(3).Name = "Value" : Dg2.Columns(3).Width = 78
        Dg2.Columns(4).Name = "@" : Dg2.Columns(4).Width = 39
        Dg2.Columns(5).Name = "+/-" : Dg2.Columns(5).Width = 43
        Dg2.Columns(6).Name = "Basic" : Dg2.Columns(6).Width = 89
        Dg2.Columns(7).Name = "T%" : Dg2.Columns(7).Width = 49
        Dg2.Columns(8).Name = "Total" : Dg2.Columns(8).Width = 90
        Dg2.Columns(9).Name = "GSTAmt" : Dg2.Columns(9).Width = 89
    End Sub
    Private Sub FillCharges()
        txtchargesTaxPer.Text = Format(clsFun.ExecScalarInt("SELECT IGSTPer FROM Charges AS C LEFT JOIN Taxation T ON T.ID = C.GSTID Where C.ID=" & Val(txtChargesID.Text) & " "), "0.00")
        txtPlusMinus.Text = clsFun.ExecScalarStr("SELECT ChargesType FROM Charges AS C LEFT JOIN Taxation T ON T.ID = C.GSTID Where C.ID='" & Val(txtChargesID.Text) & "' ")
        txtCalculatePer.Text = Format(clsFun.ExecScalarInt("SELECT Calculate FROM Charges AS C LEFT JOIN Taxation T ON T.ID = C.GSTID Where C.ID=" & Val(txtChargesID.Text) & " "), "0.00")
        lblClcType.Text = clsFun.ExecScalarStr("SELECT ApplyType FROM Charges AS C LEFT JOIN Taxation T ON T.ID = C.GSTID Where C.ID='" & Val(txtChargesID.Text) & "' ")
    End Sub


    Private Sub ChargesColums()
        dgCharges.ColumnCount = 3
        dgCharges.Columns(0).Name = "ID"
        dgCharges.Columns(0).Visible = False
        dgCharges.Columns(1).Name = "Charges Name"
        dgCharges.Columns(1).Width = 200
        dgCharges.Columns(2).Name = "GST"
        dgCharges.Columns(2).Width = 58
        RetriveCharges()
    End Sub

    Private Sub txtOnValue_GotFocus(sender As Object, e As EventArgs) Handles txtOnValue.GotFocus
        If txtcharges.Text = "" Then txtcharges.Focus() : Exit Sub
        If dgCharges.SelectedRows.Count = 0 Then Exit Sub
        If txtcharges.Text.ToUpper = dgCharges.SelectedRows(0).Cells(1).Value.ToString.ToUpper Then
            txtChargesID.Text = dgCharges.SelectedRows(0).Cells(0).Value
            txtcharges.Text = dgCharges.SelectedRows(0).Cells(1).Value
            dgCharges.Visible = False : FillCharges()
        Else
            txtcharges.Focus()
        End If
    End Sub

    Private Sub txtcharges_KeyDown(sender As Object, e As KeyEventArgs) Handles txtcharges.KeyDown, txtOnValue.KeyDown,
        txtCalculatePer.KeyDown, txtPlusMinus.KeyDown, txtchargesBasic.KeyDown, txtchargesTaxPer.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
            e.SuppressKeyPress = True
        End If
        Select Case e.KeyCode
            Case Keys.End
                e.Handled = True
                BtnSave.Focus()
        End Select
        Select Case e.KeyCode
            Case Keys.PageUp
                e.Handled = True
                txtItem.Focus()
        End Select
        If txtcharges.Focused Then
            If e.KeyCode = Keys.F3 Then
                ChargesForm.MdiParent = MainScreenForm
                ChargesForm.Show()
                If Not ChargesForm Is Nothing Then
                    ChargesForm.BringToFront()
                End If
            End If
            If e.KeyCode = Keys.F1 Then
                If txtChargesID.Text = "" Then Exit Sub
                ChargesForm.MdiParent = MainScreenForm
                ChargesForm.FillContros(Val(txtChargesID.Text))
                ChargesForm.Show()
                If Not ChargesForm Is Nothing Then
                    ChargesForm.BringToFront()
                End If
            End If
            If e.KeyCode = Keys.Down Then dgCharges.Focus()
        End If
    End Sub

    Private Sub txtcharges_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcharges.KeyPress
        ChargesColums()
    End Sub

    Private Sub txtcharges_KeyUp(sender As Object, e As KeyEventArgs) Handles txtcharges.KeyUp
        If BtnSave.Text = "&Update" Then ChargesColums()
        If txtcharges.Text.Trim() <> "" Then
            RetriveCharges(" Where ChargeName Like '" & txtcharges.Text.Trim() & "%'")
        End If
    End Sub
    Private Sub RetriveCharges(Optional ByVal condtion As String = "")
        If dg1.Rows.Count = 0 Then MsgBox("First Add Some items in Record...", vbCritical, "Access Denied") : txtItem.Focus() : Exit Sub
        dgCharges.Visible = True
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("Select * from Charges" & condtion & " order by ChargeName")
        Try
            If dt.Rows.Count > 0 Then
                dgCharges.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dgCharges.Rows.Add()
                    With dgCharges.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("id").ToString()
                        .Cells(1).Value = dt.Rows(i)("ChargeName").ToString()
                        .Cells(2).Value = dt.Rows(i)("GSTYN").ToString()
                    End With
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "Teller")
        End Try
    End Sub
    Private Sub dgCharges_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCharges.CellClick
        txtcharges.Clear() : txtChargesID.Clear()
        txtChargesID.Text = dgCharges.SelectedRows(0).Cells(0).Value
        txtcharges.Text = dgCharges.SelectedRows(0).Cells(1).Value
        lblTaxonCharges.Text = dgCharges.SelectedRows(0).Cells(2).Value
        dgCharges.Visible = False
        txtOnValue.Focus() : FillCharges()
        'fillCharges(id) :
        'ChargesPicTax()
    End Sub
    Private Sub dgCharges_KeyDown(sender As Object, e As KeyEventArgs) Handles dgCharges.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtcharges.Clear() : txtChargesID.Clear()
            txtChargesID.Text = dgCharges.SelectedRows(0).Cells(0).Value
            txtcharges.Text = dgCharges.SelectedRows(0).Cells(1).Value
            lblTaxonCharges.Text = dgCharges.SelectedRows(0).Cells(2).Value
            dgCharges.Visible = False
            txtOnValue.Focus() : FillCharges()
        End If

    End Sub
    Private Sub txtQty_GotFocus(sender As Object, e As EventArgs) Handles txtQty.GotFocus
        If dgItemSearch.RowCount = 0 Then txtItem.Focus() : Exit Sub
        If txtItem.Text = "" Then txtItem.Focus() : Exit Sub
        If dgItemSearch.SelectedRows.Count = 0 Then Exit Sub
        If txtItem.Text.ToUpper = dgItemSearch.SelectedRows(0).Cells(2).Value.ToString.ToUpper Then
            txtItemID.Text = dgItemSearch.SelectedRows(0).Cells(0).Value
            lblCode.Text = dgItemSearch.SelectedRows(0).Cells(1).Value
            txtItem.Text = dgItemSearch.SelectedRows(0).Cells(2).Value
            lblUnit.Text = dgItemSearch.SelectedRows(0).Cells(3).Value
            dgItemSearch.Visible = False
        Else
            txtItem.Focus()
        End If
    End Sub

    Private Sub txtRate_GotFocus(sender As Object, e As EventArgs) Handles txtRate.GotFocus
        ' pnlaltinfo.Visible = False : pnlDisc.Visible = False : pnlSerial.Visible = False
        If lblTaxType.Text = "TI" Then pnlNetRate.Visible = True : txtNetRate.TabStop = False
    End Sub

    Private Sub mskEntryDate_KeyDown(sender As Object, e As KeyEventArgs) Handles mskEntryDate.KeyDown, CbSeries.KeyDown,
        txtBillNo.KeyDown, txtAccount.KeyDown, txtItem.KeyDown, txtQty.KeyDown, txtRate.KeyDown,
        txtBasic.KeyDown, txtDisPer.KeyDown, txtDisAmt.KeyDown, txtTaxable.KeyDown, txtTaxPer.KeyDown, txtTaxAmt.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
            e.SuppressKeyPress = True
        End If
        Select Case e.KeyCode
            Case Keys.End
                e.Handled = True
                BtnSave.Focus()
        End Select
        Select Case e.KeyCode
            Case Keys.PageDown
                e.Handled = True
                txtcharges.Focus()
        End Select
        If txtAccount.Focused Then
            If e.KeyCode = Keys.Down Then
                dgAccountSearch.Focus()
                e.SuppressKeyPress = True
            End If
        End If
        If txtItem.Focused Then
            If e.KeyCode = Keys.Down Then
                dgItemSearch.Focus()
                e.SuppressKeyPress = True
            End If
        End If
    End Sub
    Private Sub txtItem_GotFocus(sender As Object, e As EventArgs) Handles txtItem.GotFocus
        ' lblAccountType.Text = clsFun.ExecScalarStr(" Select AccountType From Accounts where ID=" & Val(txtAccountID.Text) & "")
        If BtnSave.Text <> "&Save" Then Exit Sub
        If dgAccountSearch.RowCount = 0 Then txtAccount.Focus() : Exit Sub
        If txtAccount.Text = "" Then txtAccount.Focus() : Exit Sub
        If dgAccountSearch.SelectedRows.Count = 0 Then Exit Sub
        If txtAccount.Text.ToUpper = dgAccountSearch.SelectedRows(0).Cells(1).Value.ToString.ToUpper Then
            txtAccountID.Text = dgAccountSearch.SelectedRows(0).Cells(0).Value
            txtAccount.Text = dgAccountSearch.SelectedRows(0).Cells(1).Value
            AcBal()
            dgAccountSearch.Visible = False
        Else
            txtAccount.Focus()
        End If
        autoGSTPick()
    End Sub
    Private Sub pickPrice()
        txtRate.Text = Format(Val(clsFun.ExecScalarInt(" SELECT PurchaseRate FROM Item_View WHERE ID ='" & Val(txtItemID.Text) & "'")), "0.00")
        txtTaxPer.Text = Format(Val(clsFun.ExecScalarInt(" SELECT GSTPer FROM Item_View WHERE ID ='" & Val(txtItemID.Text) & "'")), "0.00")
        lblCessPer.Text = Format(Val(clsFun.ExecScalarInt(" SELECT CessPer FROM Item_View WHERE ID ='" & Val(txtItemID.Text) & "'")), "0.00")
        lblAddCessPer.Text = Val(clsFun.ExecScalarInt("Select CessAmt From Item_View Where ID='" & Val(txtItemID.Text) & "'"))
        'lblAdditionalCess.Text = clsFun.ExecScalarStr("Select asper From Item_View Where ID='" & Val(txtItemID.Text) & "'")
        StockBal()
    End Sub
    Private Sub dgItemSearch_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgItemSearch.CellClick
        txtItem.Clear() : txtItemID.Clear()
        txtItemID.Text = dgItemSearch.SelectedRows(0).Cells(0).Value
        lblCode.Text = dgItemSearch.SelectedRows(0).Cells(1).Value
        txtItem.Text = dgItemSearch.SelectedRows(0).Cells(2).Value
        lblUnit.Text = dgItemSearch.SelectedRows(0).Cells(3).Value
        dgItemSearch.Visible = False : txtQty.Focus() : pickPrice()
    End Sub
    Private Sub dgItemSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles dgItemSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtItem.Clear() : txtItem.Clear()
            txtItemID.Text = dgItemSearch.SelectedRows(0).Cells(0).Value
            lblCode.Text = dgItemSearch.SelectedRows(0).Cells(1).Value
            txtItem.Text = dgItemSearch.SelectedRows(0).Cells(2).Value
            lblUnit.Text = dgItemSearch.SelectedRows(0).Cells(3).Value
            dgItemSearch.Visible = False : e.SuppressKeyPress = True
            txtQty.Focus() : pickPrice()
        End If
        If e.KeyCode = Keys.Back Then
            txtItem.Focus()
        End If
        If e.KeyCode = Keys.F1 Then
            If dgItemSearch.SelectedRows.Count = 0 Then Exit Sub
            Dim itemid As String = dgItemSearch.SelectedRows(0).Cells(0).Value
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

    Private Sub DgAccountSearch_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgAccountSearch.CellClick
        txtAccount.Clear() : txtAccountID.Clear()
        txtAccountID.Text = dgAccountSearch.SelectedRows(0).Cells(0).Value
        txtAccount.Text = dgAccountSearch.SelectedRows(0).Cells(1).Value
        dgAccountSearch.Visible = False : txtItem.Focus() : AcBal()
        lblAccountType.Text = clsFun.ExecScalarStr(" Select AccountType From Accounts where ID=" & Val(txtAccountID.Text) & "")
        If txtAccountID.Text = "" Then txtAccount.Focus() : Exit Sub
        If txtAccountID.Text = Val(11) Then
            pnlCustomerInfo.Visible = True : txtName.Focus()
        Else
            txtItem.Focus() : pnlCustomerInfo.Visible = False
        End If
    End Sub
    Private Sub DgAccountSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles dgAccountSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtAccount.Clear() : txtAccountID.Clear()
            txtAccountID.Text = dgAccountSearch.SelectedRows(0).Cells(0).Value
            txtAccount.Text = dgAccountSearch.SelectedRows(0).Cells(1).Value
            dgAccountSearch.Visible = False : e.SuppressKeyPress = True
            txtItem.Focus() : AcBal()
            'lblAccountType.Text = clsFun.ExecScalarStr(" Select AccountType From Accounts where ID=" & Val(txtAccountID.Text) & "")
            If txtAccountID.Text = "" Then txtAccount.Focus() : Exit Sub
            If Val(txtAccountID.Text) = Val(7) Then
                pnlCustomerInfo.Visible = True : txtName.Focus()
            Else
                txtItem.Focus() : pnlCustomerInfo.Visible = False
            End If
        End If

    End Sub
    Private Sub txtAccount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAccount.KeyPress
        dgAccountSearch.BringToFront()
        AccountRowColumns()
        dgAccountSearch.Visible = True
    End Sub

    Private Sub txtAccount_KeyUp(sender As Object, e As KeyEventArgs) Handles txtAccount.KeyUp
        If BtnSave.Text <> "&Save" Then AccountRowColumns()
        If txtAccount.Text.Trim() <> "" Then
            retriveAccounts(" And upper(accountname) Like upper('" & txtAccount.Text.Trim() & "%')")
        End If
    End Sub
    Private Sub AccountRowColumns()
        dgAccountSearch.ColumnCount = 3
        dgAccountSearch.Columns(0).Name = "ID" : dgAccountSearch.Columns(0).Visible = False
        dgAccountSearch.Columns(1).Name = "Account Name" : dgAccountSearch.Columns(1).Width = 260
        dgAccountSearch.Columns(2).Name = "City" : dgAccountSearch.Columns(2).Width = 100
        retriveAccounts()
    End Sub
    Private Sub retriveAccounts(Optional ByVal condtion As String = "")
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("Select * from Account_AcGrp where (Groupid in(11,12,17)  or UnderGroupID in (11,12,17))" & condtion & " order by AccountName")
        Try
            If dt.Rows.Count > 0 Then
                dgAccountSearch.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dgAccountSearch.Rows.Add()
                    With dgAccountSearch.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("id").ToString()
                        .Cells(1).Value = dt.Rows(i)("AccountName").ToString()
                        .Cells(2).Value = dt.Rows(i)("City").ToString()
                    End With
                    ' Dg1.Rows.Add()
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "Teller")
        End Try
    End Sub
    Private Sub AccountFill()
        Dim GSTType As String = String.Empty
        lblAccountType.Text = clsFun.ExecScalarStr(" Select lblaccounttype.text From Accounts where ID=" & txtAccountID.Text & "")
        If lblAccountType.Text = "L" Or lblAccountType.Text = "" Then
            lblAccountType.Visible = True
            lblAccountType.Text = "Local"
        Else
            lblAccountType.Visible = True
            lblAccountType.Text = "Central"
        End If
        GSTType = clsFun.ExecScalarStr(" Select GSTNo From Accounts where ID=" & txtAccountID.Text & "")
        If GSTType = "" Then
            lblGstType.Visible = True
            lblGstType.Text = "Unregistered"
        Else
            lblGstType.Visible = True
            lblGstType.Text = "Registered"
        End If
    End Sub
    Private Sub ItemRowColumns()
        dgItemSearch.ColumnCount = 4
        dgItemSearch.Columns(0).Name = "ID" : dgItemSearch.Columns(0).Visible = False
        dgItemSearch.Columns(1).Name = "Item Code" : dgItemSearch.Columns(1).Width = 30
        dgItemSearch.Columns(2).Name = "Item Name" : dgItemSearch.Columns(2).Width = 150
        dgItemSearch.Columns(3).Name = "Unit" : dgItemSearch.Columns(3).Width = 90
    End Sub
    Private Sub retriveItems(Optional ByVal condtion As String = "")
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("Select ID,ItemCode,ItemName,TableRate,RatePer from Item_View " & condtion & " order by ItemName")
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
            MsgBox(ex.Message, vbOKOnly + vbInformation, "Atithi")
        End Try
    End Sub

    Private Sub txtItem_KeyUp(sender As Object, e As KeyEventArgs) Handles txtItem.KeyUp
        If txtItem.Text.Trim() <> "" Then
            dgItemSearch.Visible = True
            retriveItems(" Where upper(ItemName) Like upper('" & txtItem.Text.Trim() & "%') or upper(ItemCode)  Like upper('%" & txtItem.Text.Trim() & "%') ")
        Else
            retriveItems()
        End If
        If e.KeyCode = Keys.Escape Then dgItemSearch.Visible = False
    End Sub
    Private Sub autoGSTPick()
        lblTaxType.Visible = True
        lblTaxType.Text = clsFun.ExecScalarStr("Select TaxType From TaxSetting Where ID='" & Val(cbSeries.SelectedValue) & "'")
        If Val(clsFun.ExecScalarStr("Select Count(*) From Vouchers Where TransType='" & Me.Text & "'")) = 0 Then
            If Val(clsFun.ExecScalarStr("Select InvoiceStart From TaxSetting Where ID='" & Val(cbSeries.SelectedValue) & "'")) > 0 Then
                txtBillNo.Text = clsFun.ExecScalarStr("Select InvoiceStart From TaxSetting Where ID='" & Val(CbSeries.SelectedValue) & "'")
                txtInvoiceID.Text = clsFun.ExecScalarStr("Select InvoiceStart From TaxSetting Where ID='" & Val(cbSeries.SelectedValue) & "'")
            End If
        End If

        If clsFun.ExecScalarStr("Select InvoicePrefix From TaxSetting Where ID='" & Val(cbSeries.SelectedValue) & "'") <> "" Then
            Dim Prefix As String = clsFun.ExecScalarStr("Select InvoicePrefix From TaxSetting Where ID='" & Val(cbSeries.SelectedValue) & "'")
            txtBillNo.Clear() : VNumber()
            txtBillNo.Text = Prefix & txtBillNo.Text
        End If

        Dim CompanyStateCode As String = Format(Val(clsFun.ExecScalarStr("Select StateCode From Company")), "00")
        Dim AccountStateCode As String = Format(Val(clsFun.ExecScalarStr("Select StateCode From Accounts Where ID='" & Val(txtAccountID.Text) & "'")), "00")
        Dim SCodeInGSTN As String = clsFun.ExecScalarStr("Select GSTNo From Accounts Where ID='" & Val(txtAccountID.Text) & "'")

        '   If Val(txtTotTaxAmt.Text) > 0 Then
        lblRegion.Visible = True
        If CompanyStateCode = AccountStateCode Then
            lblGstAmt.Visible = True : lblGstAmt.Text = "SGST : " & Format(Val(TotalSGST), Hash) & " + CGST : " & Format(Val(TotalCGST), Hash) & If(TotalCess > 0, " + Cess : " & Format(Val(TotalCess), Hash), "")
            lblRegion.Text = "Local"
        ElseIf Val(txtAccountID.Text) = 7 And (CompanyStateCode = txtStateCode.Text Or txtStateCode.Text = "00") Then
            lblGstAmt.Visible = True : lblGstAmt.Text = "SGST : " & Format(Val(TotalSGST), Hash) & " + CGST : " & Format(Val(TotalCGST), Hash) & If(TotalCess > 0, " + Cess : " & Format(Val(TotalCess), Hash), "")
            lblRegion.Text = "Local"
        ElseIf (CompanyStateCode <> AccountStateCode) Or (txtStateCode.Text <> CompanyStateCode) Then
            lblGstAmt.Visible = True : lblGstAmt.Text = "IGST : " & Format(Val(TotalIGST), Hash) & If(TotalCess > 0, " + Cess : " & Format(Val(TotalCess), Hash), "")
            lblRegion.Text = "Central"
        End If
        '        Else

        '  End If
        'If BtnSave.Text = "&Save" Then
        '    If Val(txtAccountID.Text) = 7 Then
        '        txtTotCashAmt.Text = txtTotTotal.Text
        '        txtTotDueamt.Text = Format(0, Hash)
        '    Else
        '        txtTotCashAmt.Text = Format(0, Hash)
        '        txtTotDueamt.Text = txtTotTotal.Text
        '    End If
        'End If



    End Sub
    Private Sub txtItem_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtItem.KeyPress
        dgItemSearch.Visible = True
    End Sub
    Private Sub calculation()
        If lblTaxType.Text = "TI" Then
            Dim incRate As Decimal = Val(txtRate.Text) - Val(SpeCess)
            incRate = Val(incRate) * (100 / Val(Val(Val(txtTaxPer.Text) + Val(CessPer)) + 100))
            txtNetRate.Text = Format(Val(incRate), Hash)
            txtBasic.Text = Format(Val(txtQty.Text) * Val(txtNetRate.Text), Hash)
            txtDisAmt.Text = Format(Val(Val(txtBasic.Text) * Val(txtDisPer.Text)) / 100, Hash)
            txtTaxable.Text = Format(Math.Round(Val(Val(txtBasic.Text) - Val(txtDisAmt.Text)), 2), Hash)
            If lblRegion.Text = "Local" Then
                SGSTPER = Val(Val(txtTaxPer.Text) / 2)
                CGSTPER = Val(Val(txtTaxPer.Text) / 2)
                IGSTPER = Val(Val(0))
                SGSTAMT = Val(Val(Val(txtTaxPer.Text) / 2) * Format(Val(Val(txtBasic.Text) - Val(txtDisAmt.Text)), Hash) / 100)
                CGSTAMT = Val(Val(Val(txtTaxPer.Text) / 2) * Format(Val(Val(txtBasic.Text) - Val(txtDisAmt.Text)), Hash) / 100)
                txtTaxAmt.Text = Format(Val(SGSTAMT) + Format(Val(CGSTAMT)), Hash)
            Else
                SGSTPER = Val(0) : CGSTPER = Val(0)
                IGSTPER = Val(Val(txtTaxPer.Text))
                IGSTAMT = Val(Val(Val(txtTaxPer.Text)) * Format(Val(Val(txtBasic.Text) - Val(txtDisAmt.Text)), Hash) / 100)
                txtTaxAmt.Text = Format(IGSTAMT, Hash)
            End If

            If CessAsOn = "Taxable" Then
                CessAmt = Format(Val(Val(txtBasic.Text) - Val(txtDisAmt.Text)) * Val(CessPer) / 100, Hash)
                txtTaxAmt.Text = Format(Val(txtTaxAmt.Text) + Val(CessAmt), Hash)
            ElseIf CessAsOn = "Qty" Then
                CessAmt = CessAmt + Val(Val(txtQty.Text) * Val(SpeCess))
                txtTaxAmt.Text = Format(Val(txtTaxAmt.Text) + Val(CessAmt), Hash)
            ElseIf CessAsOn = "Taxable+Qty" Then
                CessAmt = Format(Val(Val(txtBasic.Text) - Val(txtDisAmt.Text)) * Val(CessPer) / 100, Hash)
                CessAmt = CessAmt + Val(Val(txtQty.Text) * Val(SpeCess))
                txtTaxAmt.Text = Format(Val(txtTaxAmt.Text) + Val(CessAmt), Hash)
            End If
            txtTotAmt.Text = Format(Val(Format(IGSTAMT, Hash)) + Val(Format(SGSTAMT, Hash)) + Val(Format(CGSTAMT, Hash)) + Val(Format(CessAmt, Hash)) + Val(Val(Val(txtBasic.Text) - Val(txtDisAmt.Text)) - Val(lblDiscamt.Text)), Hash)
        ElseIf lblTaxType.Text = "TE" Then
            txtNetRate.Text = Val(txtRate.Text)
            If cbPricePer.SelectedIndex = 1 Then
                txtBasic.Text = Format(Val(txtAltQty.Text) * Val(txtNetRate.Text), Hash)
            Else
                txtBasic.Text = Format(Val(txtQty.Text) * Val(txtNetRate.Text), Hash)
            End If
            txtDisAmt.Text = Format(Val(Val(txtBasic.Text) * Val(txtDisPer.Text)) / 100, Hash)
            '  Dim disc2 As Decimal = Format(Val(Val(txtBasic.Text) * Val(txtDisPer.Text)) / 100, Hash)
            lblTaxableamt.Text = "Taxable Value : " & Format(Val(Val(txtBasic.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)), Hash)
            If lblRegion.Text = "Local" Then
                SGSTPER = Val(Val(txtTaxPer.Text) / 2)
                CGSTPER = Val(Val(txtTaxPer.Text) / 2)
                IGSTPER = Val(Val(0))
                SGSTAMT = Val(Val(Val(txtTaxPer.Text) / 2) * Format(Val(Val(txtBasic.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)), Hash) / 100)
                CGSTAMT = Val(Val(Val(txtTaxPer.Text) / 2) * Format(Val(Val(txtBasic.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)), Hash) / 100)
                txtTaxAmt.Text = Format(Val(SGSTAMT) + Format(Val(CGSTAMT)), Hash)
            Else
                SGSTPER = Val(0)
                CGSTPER = Val(0)
                IGSTPER = Val(Val(txtTaxPer.Text))
                IGSTAMT = Val(Val(Val(txtTaxPer.Text)) * Format(Val(Val(txtBasic.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)), Hash) / 100)
                txtTaxAmt.Text = Format(IGSTAMT, Hash)
            End If
            txtTotAmt.Text = Format(Val(Format(IGSTAMT, Hash)) + Val(Format(SGSTAMT, Hash)) + Val(Format(CGSTAMT, Hash)) + Val(Format(CessAmt, Hash)) + Val(Val(Val(txtBasic.Text) - Val(txtDisAmt.Text)) - Val(lblDiscamt.Text)), Hash)
            If CessAsOn = "Taxable" Then
                CessAmt = Format(Val(Val(txtBasic.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)) * Val(CessPer) / 100, Hash)
                txtTaxAmt.Text = Format(Val(txtTaxAmt.Text) + Val(CessAmt), Hash)
            ElseIf CessAsOn = "Qty" Then
                CessAmt = CessAmt + Val(Val(txtQty.Text) * Val(SpeCess))
                txtTaxAmt.Text = Format(Val(txtTaxAmt.Text) + Val(CessAmt), Hash)
            ElseIf CessAsOn = "Taxable+Qty" Then
                CessAmt = Format(Val(Val(txtBasic.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)) * Val(CessPer) / 100, Hash)
                CessAmt = CessAmt + Val(Val(txtQty.Text) * Val(SpeCess))
                txtTaxAmt.Text = Format(Val(txtTaxAmt.Text) + Val(CessAmt), Hash)
            End If
        Else
            txtNetRate.Text = Val(txtRate.Text)
            If cbPricePer.SelectedIndex = 1 Then
                txtBasic.Text = Format(Val(txtAltQty.Text) * Val(txtNetRate.Text), Hash)
            Else
                txtBasic.Text = Format(Val(txtQty.Text) * Val(txtNetRate.Text), Hash)
            End If
            txtDisAmt.Text = Format(Val(Val(txtBasic.Text) * Val(txtDisPer.Text)) / 100, Hash)
            lblTaxableamt.Text = "Taxable Value : " & Format(Val(Val(txtBasic.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)), Hash)
            '  txtTaxAmt.Text = Format(Val(Val(txtTaxPer.Text) * Val(Val(txtBasic.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)) / 100), Hash)
            txtTotAmt.Text = Format(Val(txtTaxAmt.Text) + Val(Val(txtBasic.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)), Hash)
        End If
    End Sub

    Private Sub txtTaxPer_Leave(sender As Object, e As EventArgs) Handles txtTaxPer.Leave
        txtQty.Text = Format(Val(txtQty.Text), "0.00") : txtRate.Text = Format(Val(txtRate.Text), "0.00")
        txtDisPer.Text = Format(Val(txtDisPer.Text), "0.00") : txtTaxPer.Text = Format(Val(txtTaxPer.Text), "0.00")
    End Sub
    Private Sub dg1_KeyDown(sender As Object, e As KeyEventArgs) Handles dg1.KeyDown
        If e.KeyCode = Keys.Delete Then
            If dg1.SelectedRows.Count = 0 Then Exit Sub
            If MessageBox.Show("Are You Sure Want to Delete Selected Item ?", "Delete Item", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                dg1.Rows.Remove(dg1.SelectedRows(0))
                Dg1AutoSerial() : dg1.ClearSelection() : calc()
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            If dg1.SelectedRows.Count = 0 Then Exit Sub
            txtItemID.Text = dg1.SelectedRows(0).Cells(0).Value
            txtItem.Text = dg1.SelectedRows(0).Cells(3).Value
            lblUnit.Text = dg1.SelectedRows(0).Cells(4).Value
            txtQty.Text = dg1.SelectedRows(0).Cells(5).Value
            txtRate.Text = dg1.SelectedRows(0).Cells(6).Value
            txtBasic.Text = dg1.SelectedRows(0).Cells(7).Value
            txtDisPer.Text = dg1.SelectedRows(0).Cells(8).Value
            txtDisAmt.Text = dg1.SelectedRows(0).Cells(9).Value
            txtTaxable.Text = dg1.SelectedRows(0).Cells(10).Value
            txtTaxPer.Text = dg1.SelectedRows(0).Cells(11).Value
            txtTaxAmt.Text = dg1.SelectedRows(0).Cells(12).Value
            txtTotalAmt.Text = dg1.SelectedRows(0).Cells(13).Value
            lblCessPer.Text = dg1.SelectedRows(0).Cells(14).Value
        End If
    End Sub
    Private Sub Dg1AutoSerial()
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
    Private Sub Dg2AutoSerial()
        Dim SlNumber As Integer = 0
        If Me.Dg2.Rows.Count = 0 Then
            SlNumber = 1
        ElseIf Me.Dg2.Rows.Count > 0 Then
            For i As Integer = 0 To Me.Dg2.Rows.Count - 1
                SlNumber = Me.Dg2.Rows.Count
                Me.Dg2.CurrentRow.Cells(0).Value = SlNumber
            Next
        End If
    End Sub
    Sub calc()
        txttotQty.Text = Format(0, "0.00") : txtTotBasic.Text = Format(0, "0.00")
        txtTotDiscount.Text = Format(0, "0.00") : txtTotTaxable.Text = Format(0, "0.00")
        txtTotTax.Text = Format(0, "0.00") : txtTotTotal.Text = Format(0, "0.00")
        txtTotTaxable.Text = Format(0, "0.00") : txtTotCharges.Text = Format(0, "0.00")
        txtTotRoundOff.Text = Format(0, "0.00") : txtTotCess.Text = Format(0, "0.00")
        txtTotAddCess.Text = Format(0, "0.00")
        For i = 0 To dg1.Rows.Count - 1
            txttotQty.Text = Format(Val(txttotQty.Text) + Val(dg1.Rows(i).Cells(5).Value), "0.00")
            txtTotBasic.Text = Format(Val(txtTotBasic.Text) + Val(dg1.Rows(i).Cells(7).Value), "0.00")
            txtTotDiscount.Text = Format(Val(txtTotDiscount.Text) + Val(dg1.Rows(i).Cells(9).Value), "0.00")
            txtTotTaxable.Text = Format(Val(txtTotTaxable.Text) + Val(dg1.Rows(i).Cells(10).Value), "0.00")
            txtTotTax.Text = Format(Val(txtTotTax.Text) + Val(dg1.Rows(i).Cells(12).Value), "0.00")
            txtTotTotal.Text = Format(Val(txtTotTotal.Text) + Val(dg1.Rows(i).Cells(13).Value), "0.00")
            txtTotCess.Text = Format(Val(txtTotCess.Text) + Val(dg1.Rows(i).Cells(15).Value), "0.00")
            txtTotAddCess.Text = Format(Val(txtTotAddCess.Text) + Val(dg1.Rows(i).Cells(16).Value), "0.00")
        Next

        For i = 0 To Dg2.Rows.Count - 1
            If Dg2.Rows(i).Cells(4).Value = "-" Then
                txtTotCharges.Text = Format(Val(txtTotCharges.Text) - Val(Dg2.Rows(i).Cells(8).Value), "0.00")
            Else
                txtTotCharges.Text = Format(Val(txtTotCharges.Text) + Val(Dg2.Rows(i).Cells(8).Value), "0.00")
            End If
        Next
        '   calculation()
        txtTotTotal.Text = Format(Val(txtTotTaxable.Text) + Val(txtTotCharges.Text) + Val(txtTotCess.Text) + Val(txtTotAddCess.Text) + Val(txtTotTax.Text), "0.00")
        Dim tmpamount As Double = CDbl(txtTotTotal.Text)
        txtTotTotal.Text = Format(Math.Round(Val(tmpamount), 0), "0.00")
        txtTotRoundOff.Text = Format(Math.Round(Val(txtTotTotal.Text) - Val(tmpamount), 2), "0.00")
        If txtAccountID.Text = Val(11) Then
            txtTotCash.Text = Format(Val(txtTotTotal.Text), "0.00")
        Else
            txtTotChange.Text = Format(Val(txtTotTotal.Text), "0.00")
        End If
        txtTotChange.Text = Format(Val(txtTotChange.Text), "0.00") : txtTotCash.Text = Format(Val(txtTotCash.Text), "0.00")
    End Sub

    Private Sub dg1_MouseClick(sender As Object, e As MouseEventArgs) Handles dg1.MouseClick
        dg1.ClearSelection()
    End Sub
    Private Sub save()
        Dim sql As String = String.Empty
        SqliteEntryDate = CDate(mskEntryDate.Text).ToString("yyyy-MM-dd")
        dg1.ClearSelection()
        Dim cmd As SQLite.SQLiteCommand
        sql = "insert into Vouchers(TransType,EntryDate,InvoiceNo,InvoiceTypeID,InvoiceTypeName, AccountID,AccountName,totQty,TotalBasicAmt, TotalDiscAmt, " _
                                    & " TotalTaxableAmt,TotalSGSTAmt,TotalCGSTAmt, " _
                                    & "TotalIGSTAmt,TotalTaxAmt,TotalCharges,RoundOff,TotalGrandAmt, TotalCashAmt,TotalBalAmt," _
                                    & " CustomerName,CustomerAddress,CustomerMobile,CustomerCity,CustomerState,CustomerStateCode,CustomerGSTN,TotalCessAmt,TotalAddCessAmt) " _
                                    & "values (@1, @2, @3, @4, @5, @6, @7, @8, @9, @10,@11,@12," _
                                    & "@13, @14, @15, @16, @17,@18,@19,@20,@21,@22,@23,@24,@25,@26,@27,@28,@29)"
        Try
            cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
            cmd.Parameters.AddWithValue("@1", Me.Text)
            cmd.Parameters.AddWithValue("@2", SqliteEntryDate)
            cmd.Parameters.AddWithValue("@3", txtBillNo.Text)
            cmd.Parameters.AddWithValue("@4", Val(CbSeries.SelectedValue))
            cmd.Parameters.AddWithValue("@5", CbSeries.Text)
            cmd.Parameters.AddWithValue("@6", Val(txtAccountID.Text))
            cmd.Parameters.AddWithValue("@7", txtAccount.Text)
            cmd.Parameters.AddWithValue("@8", Val(txttotQty.Text))
            cmd.Parameters.AddWithValue("@9", Val(txtTotBasic.Text))
            cmd.Parameters.AddWithValue("@10", Val(txtTotDiscount.Text))
            cmd.Parameters.AddWithValue("@11", Val(txtTotTaxable.Text))
            cmd.Parameters.AddWithValue("@12", IIf(lblAccountType.Text = "L", Val(txtTotTax.Text / 2), 0))
            cmd.Parameters.AddWithValue("@13", IIf(lblAccountType.Text = "L", Val(txtTotTax.Text / 2), 0))
            cmd.Parameters.AddWithValue("@14", IIf(lblAccountType.Text = "L", 0, Val(txtTotTax.Text)))
            cmd.Parameters.AddWithValue("@15", Val(txtTotTax.Text))
            cmd.Parameters.AddWithValue("@16", Val(txtTotCharges.Text))
            cmd.Parameters.AddWithValue("@17", Val(txtTotRoundOff.Text))
            cmd.Parameters.AddWithValue("@18", Val(txtTotTotal.Text))
            cmd.Parameters.AddWithValue("@19", Val(txtTotCash.Text))
            cmd.Parameters.AddWithValue("@20", Val(txtTotChange.Text))
            cmd.Parameters.AddWithValue("@21", "")
            cmd.Parameters.AddWithValue("@22", "")
            cmd.Parameters.AddWithValue("@23", "")
            cmd.Parameters.AddWithValue("@24", "")
            cmd.Parameters.AddWithValue("@25", "")
            cmd.Parameters.AddWithValue("@25", "")
            cmd.Parameters.AddWithValue("@26", "")
            cmd.Parameters.AddWithValue("@27", "")
            cmd.Parameters.AddWithValue("@28", Val(txtTotCess.Text))
            cmd.Parameters.AddWithValue("@29", Val(txtTotAddCess.Text))
            If cmd.ExecuteNonQuery() > 0 Then
                clsFun.CloseConnection()
                txtID.Text = clsFun.ExecScalarInt("Select Max(ID) from Vouchers")
                dg1Record()
                dg2Record()
            End If
            Ledger()
            'ChargeInsert()
            'SendSms()
            MsgBox("Record Saved Successfully.", vbInformation + vbOKOnly, "Saved") 'Insert SuccesFully", "SuccessFully", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtclearall()
        Catch ex As Exception
            MsgBox(ex.Message)
            clsFun.CloseConnection()
        End Try
    End Sub
    Private Sub dg1Record()
        Dim sql As String = String.Empty
        For Each row As DataGridViewRow In dg1.Rows
            With row
                If .Cells(0).Value <> 0 Then
                    sql = sql & "insert into Trans(TransType,VoucherID, ItemID,Sno,  ItemName, Qty, Rate, Per, BasicAmt,DisPer,DisAmt," & _
                          "TaxableAmt,TaxPer,TaxAmt,TotalAmt,SgstPer,SgstAmt,CGSTPer,cgstAmt,IGSTPer,IGSTAmt,CessPer,CessAmt,Cess2) values ('" & Me.Text & "'," & _
                        "'" & Val(txtID.Text) & "','" & Val(.Cells(0).Value) & "','" & .Cells(1).Value & "', '" & .Cells(3).Value & "','" & .Cells(5).Value & "'," & _
                        "'" & Val(.Cells(6).Value) & "','" & .Cells(4).Value & "','" & Val(.Cells(7).Value) & "'," & _
                        "'" & Val(.Cells(8).Value) & "','" & Val(.Cells(9).Value) & "','" & Val(.Cells(10).Value) & "','" & Val(.Cells(11).Value) & "'," & _
                        "'" & Val(.Cells(12).Value) & "','" & Val(.Cells(13).Value) & "', '" & IIf(lblAccountType.Text = "L", Val(.Cells(11).Value) / 2, 0) & "'," & _
                        "'" & IIf(lblAccountType.Text = "L", Val(.Cells(12).Value) / 2, 0) & "','" & IIf(lblAccountType.Text = "L", Val(.Cells(11).Value) / 2, 0) & "', " & _
                        "'" & IIf(lblAccountType.Text = "L", Val(.Cells(12).Value) / 2, 0) & "','" & IIf(lblAccountType.Text = "L", 0, .Cells(11).Value) & "', " & _
                        "'" & IIf(lblAccountType.Text = "L", 0, .Cells(12).Value) & "','" & Val(.Cells(14).Value) & "','" & Val(.Cells(15).Value) & "','" & Val(.Cells(16).Value) & "');"
                End If
            End With
        Next
        Try
            cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
            If cmd.ExecuteNonQuery() > 0 Then count = +1
        Catch ex As Exception
            MsgBox(ex.Message)
            clsFun.CloseConnection()
        End Try
        clsFun.CloseConnection()
    End Sub
    Private Sub dg2Record()
        Dim sql As String = String.Empty
        For Each row As DataGridViewRow In Dg2.Rows
            With row
                If .Cells("Charge Name").Value <> "" Then
                    sql = "insert into ChargesTrans(VoucherID,TransType,Sno, ChargesID, ChargeName, OnValue, Calculate, ChargeType, " & _
                         "Taxable,TaxPer, Amount,TaxAmt,SGSTper,SGSTAmt,CGSTPer,CGSTAmt,IGSTPer,IGSTAmt) values(" & (txtID.Text) & "," & _
                        "'" & Me.Text & "','" & .Cells(0).Value & "','" & .Cells(1).Value & "','" & .Cells(2).Value & "'," & _
                        "'" & .Cells(3).Value & "','" & .Cells(4).Value & "','" & .Cells(5).Value & "'," & _
                        "'" & .Cells(6).Value & "','" & .Cells(7).Value & "','" & .Cells(8).Value & "','" & .Cells(9).Value & "'," & _
                        " '" & IIf(lblAccountType.Text = "L", Val(.Cells(7).Value) / 2, 0) & "'," & _
                        "'" & IIf(lblAccountType.Text = "L", Val(.Cells(9).Value) / 2, 0) & "','" & IIf(lblAccountType.Text = "L", Val(.Cells(7).Value) / 2, 0) & "', " & _
                        "'" & IIf(lblAccountType.Text = "L", Val(.Cells(9).Value) / 2, 0) & "','" & IIf(lblAccountType.Text = "L", 0, .Cells(7).Value) & "','" & IIf(lblAccountType.Text = "L", 0, .Cells(9).Value) & "');"
                    Try
                        cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
                        If cmd.ExecuteNonQuery() > 0 Then count = +1
                    Catch ex As Exception
                        MsgBox(ex.Message)
                        clsFun.CloseConnection()
                    End Try
                End If
            End With
        Next
        clsFun.CloseConnection()
    End Sub
    Private Sub Ledger()
        Dim tmpsgstamt As Double = Val(txtTotTax.Text) / 2
        Dim tmpcgstamt As Double = Val(txtTotTax.Text) / 2
        Dim tmpigstamt As Double = Val(txtTotTax.Text)
        For Each row As DataGridViewRow In Dg2.Rows
            With row
                If .Cells("Charge Name").Value <> "" Then

                    '   If clsFun.ExecScalarStr("Select COSTON from Charges where ChargeName='" & .Cells("Charge Name").Value & "'") = "Party Cost" Then
                    If .Cells(5).Value = "+" Then
                        If lblAccountType.Text = "L" Then
                            tmpsgstamt = tmpsgstamt + Val(.Cells(9).Value)
                            tmpcgstamt = tmpcgstamt + Val(.Cells(9).Value)
                        Else
                            tmpcgstamt = tmpcgstamt + Val(.Cells(9).Value)
                        End If
                    Else
                        If lblAccountType.Text = "L" Then
                            tmpsgstamt = tmpsgstamt - Val(.Cells(9).Value)
                            tmpcgstamt = tmpcgstamt - Val(.Cells(9).Value)
                        Else
                            tmpcgstamt = tmpcgstamt - Val(.Cells(9).Value)
                        End If
                    End If
                End If
                '    End If
            End With
        Next
        SqliteEntryDate = CDate(Me.mskEntryDate.Text).ToString("yyyy-MM-dd")
        If Val(txtTotTaxable.Text) > 0 Then ''Sale Account Fixed
            clsFun.Ledger(0, txtID.Text, SqliteEntryDate, Me.Text, 36, clsFun.ExecScalarStr("Select AccountName from Accounts where Id=36"), Val(txtTotTaxable.Text), "D", "Invoice No.: " & txtBillNo.Text & ", Account Name : " & txtAccount.Text & ", Total Amount : " & Format(txtTotTotal.Text, "0.00"), txtAccount.Text)
        End If
        If lblAccountType.Text = "L" Then
            If Val(txtTotTax.Text) > 0 Then
                'SGST amount
                clsFun.Ledger(0, txtID.Text, SqliteEntryDate, Me.Text, 43, clsFun.ExecScalarStr("Select AccountName from Accounts where Id=43"), tmpsgstamt, "D", "Invoice No.: " & txtBillNo.Text & ", Account Name : " & txtAccount.Text & ", Total Amount : " & Format(txtTotTotal.Text, "0.00"), txtAccount.Text)
                'CGST amount
                clsFun.Ledger(0, txtID.Text, SqliteEntryDate, Me.Text, 13, clsFun.ExecScalarStr("Select AccountName from Accounts where Id=13"), tmpcgstamt, "D", "Invoice No.: " & txtBillNo.Text & ", Account Name : " & txtAccount.Text & ", Total Amount : " & Format(txtTotTotal.Text, "0.00"), txtAccount.Text)
            End If
        Else
            If Val(txtTotTax.Text) > 0 Then
                ' IGST amount 
                clsFun.Ledger(0, txtID.Text, SqliteEntryDate, Me.Text, 25, clsFun.ExecScalarStr("Select AccountName from Accounts where Id=25"), tmpigstamt, "D", "Invoice No.: " & txtBillNo.Text & ", Account Name : " & txtAccount.Text & ", Total Amount : " & Format(txtTotTotal.Text, "0.00"), txtAccount.Text)
            End If
        End If
        If Val(txtTotCash.Text) > 0 Then ''Cash amt
            clsFun.Ledger(0, txtID.Text, SqliteEntryDate, Me.Text, 11, clsFun.ExecScalarStr("Select AccountName from Accounts where Id=11"), Val(txtTotCash.Text), "C", "Invoice No.: " & txtBillNo.Text & ", Account Name : " & txtAccount.Text & ", Total Amount : " & Format(txtTotTotal.Text, "0.00"), txtAccount.Text)
        End If
        If Val(txtTotChange.Text) > 0 Then ''Change Amt
            clsFun.Ledger(0, txtID.Text, SqliteEntryDate, Me.Text, Val(txtAccountID.Text), txtAccount.Text, Val(txtTotChange.Text), "C")
        End If
        If Val(txtTotAddCess.Text) + Val(txtTotCess.Text) > 0 Then ''add Cess 
            clsFun.Ledger(0, txtID.Text, SqliteEntryDate, Me.Text, 1, clsFun.ExecScalarStr("Select AccountName from Accounts where Id=1"), Val(txtTotAddCess.Text) + Val(txtTotCess.Text), "D")
        End If
        If Val(txtTotRoundOff.Text) <> 0 Then ''Account 
            If Val(txtTotRoundOff.Text) < 0 Then
                clsFun.Ledger(0, txtID.Text, SqliteEntryDate, Me.Text, 39, clsFun.ExecScalarStr("Select AccountName from Accounts where Id=39"), Math.Abs(Val(txtTotRoundOff.Text)), "C", "Invoice No.: " & txtBillNo.Text & ", Account Name : " & txtAccount.Text & ", Total Amount : " & Format(txtTotTotal.Text, "0.00"), txtAccount.Text)
            Else
                clsFun.Ledger(0, txtID.Text, SqliteEntryDate, Me.Text, 39, clsFun.ExecScalarStr("Select AccountName from Accounts where Id=39"), Val(txtTotRoundOff.Text), "D", "Invoice No.: " & txtBillNo.Text & ", Account Name : " & txtAccount.Text & ", Total Amount : " & Format(txtTotTotal.Text, "0.00"), txtAccount.Text)
            End If
        End If
    End Sub
    Private Sub Update()
        Dim sql As String = String.Empty
        SqliteEntryDate = CDate(mskEntryDate.Text).ToString("yyyy-MM-dd")
        Dim count As Integer = 0
        dg1.ClearSelection()
        Dim cmd As SQLite.SQLiteCommand
        ' sql = "Update KOT Set KOTNo='" & txtBillNo.Text & "',EntryDate='" & SqliteEntryDate & "',AttenderID=" & Val(CbType.SelectedValue) & ",AttenderName='" & CbType.Text & "',ServiceName='" & cbServiceType.Text & "',TotalQty=" & Val(txttotQty.Text) & ",TotalAmount=" & Val(txtTotNet.Text) & " Where ID=" & Val(txtID.Text) & ""
        sql = "Update  Vouchers Set TransType='" & Me.Text & "',EntryDate='" & SqliteEntryDate & "', " _
              & " InvoiceNo='" & txtBillNo.Text & "',InvoiceTypeID='" & CbSeries.SelectedValue & "', " _
              & "InvoiceTypeName='" & CbSeries.Text & "', AccountID= '" & txtAccountID.Text & "', " _
              & "AccountName='" & txtAccount.Text & "',totQty='" & Val(txttotQty.Text) & "', " _
              & "TotalBasicAmt='" & Val(txtTotBasic.Text) & "', TotalDiscAmt='" & Val(txtTotDiscount.Text) & "', " _
              & " TotalTaxableAmt='" & txtTotTaxable.Text & "',TotalSGSTAmt='" & IIf(lblAccountType.Text = "L", Val(txtTotTax.Text / 2), 0) & "', " _
              & "TotalCGSTAmt='" & IIf(lblAccountType.Text = "L", Val(txtTotTax.Text / 2), 0) & "', " _
              & "TotalIGSTAmt='" & IIf(lblAccountType.Text = "L", 0, Val(txtTotTax.Text)) & "'," _
              & "TotalTaxAmt='" & Val(txtTotTax.Text) & "',TotalCharges='" & Val(txtTotCharges.Text) & "', " _
              & "RoundOff='" & Val(txtTotRoundOff.Text) & "',TotalGrandAmt='" & txtTotTotal.Text & "', " _
              & "TotalCashAmt='" & Val(txtTotCash.Text) & "',TotalBalAmt='" & Val(txtTotChange.Text) & "', " _
              & "TotalCessAmt='" & Val(txtTotCess.Text) & "',TotalAddCessAmt='" & Val(txtTotAddCess.Text) & "' Where ID=" & Val(txtID.Text) & ""


        '   & " CustomerName='',CustomerAddress,CustomerMobile,CustomerCity,CustomerState,CustomerStateCode,CustomerGSTN) " _

        Try
            If clsFun.ExecNonQuery(sql) > 0 Then
                clsFun.CloseConnection()
            End If
            If clsFun.ExecNonQuery("DELETE from Trans WHERE VoucherID=" & Val(txtID.Text) & ";DELETE from ChargesTrans WHERE VoucherID=" & Val(txtID.Text) & ";DELETE from Ledger WHERE VouchersID=" & Val(txtID.Text) & "") > 0 Then
            End If
            vchID = txtID.Text : dg1Record() : dg2Record() : Ledger() : ChargesLedger()
            BtnSave.Text = "&Save"
            btnPrintNDelete.Enabled = False
            MsgBox("Record Updated Successfully.", vbInformation + vbOKOnly, "Updated")
            clsFun.CloseConnection()
            txtclearall()
        Catch ex As Exception
            MsgBox(ex.Message)
            clsFun.CloseConnection()
        End Try
    End Sub
    Sub ChargesLedger()
        Dim dt As DateTime
        dt = CDate(Me.mskEntryDate.Text)
        ' Change the format:
        SqliteEntryDate = dt.ToString("yyyy-MM-dd")
        Dim CostON As String = clsFun.ExecScalarStr(" SELECT CostOn FROM Charges WHERE ID='" & txtChargesID.Text & "'")
        For Each row As DataGridViewRow In Dg2.Rows
            With row
                If .Cells("Charge Name").Value <> "" Then
                    Dim AcID As Integer = clsFun.ExecScalarInt("Select AccountID from Charges where ID=" & .Cells(1).Value & "")
                    Dim AccName As String = clsFun.ExecScalarStr("Select AccountName from Charges where ID='" & .Cells(1).Value & "'")
                    If clsFun.ExecScalarStr("Select COSTON from Charges where ChargeName='" & .Cells("Charge Name").Value & "'") = "Party Cost" Then
                        If .Cells(5).Value = "+" Then
                            clsFun.Ledger(0, txtID.Text, SqliteEntryDate, Me.Text, AcID, AccName, .Cells(6).Value, "C", "Invoice No.: " & txtBillNo.Text & ", Account Name : " & txtAccount.Text & ", Total Amount : " & Format(txtTotTotal.Text, "0.00"), txtAccount.Text)
                        Else
                            clsFun.Ledger(0, txtID.Text, SqliteEntryDate, Me.Text, AcID, AccName, .Cells(6).Value, "D", "Invoice No.: " & txtBillNo.Text & ", Account Name : " & txtAccount.Text & ", Total Amount : " & Format(txtTotTotal.Text, "0.00"), txtAccount.Text)
                        End If
                    Else ''our coast
                        If .Cells(5).Value = "+" Then
                            clsFun.Ledger(0, txtID.Text, SqliteEntryDate, Me.Text, AcID, AccName, .Cells(6).Value, "D", "Invoice No.: " & txtBillNo.Text & ", Account Name : " & txtAccount.Text & ", Total Amount : " & Format(txtTotTotal.Text, "0.00"), txtAccount.Text)
                        Else
                            clsFun.Ledger(0, txtID.Text, SqliteEntryDate, Me.Text, AcID, AccName, .Cells(6).Value, "C", "Invoice No.: " & txtBillNo.Text & ", Account Name : " & txtAccount.Text & ", Total Amount : " & Format(txtTotTotal.Text, "0.00"), txtAccount.Text)
                        End If
                    End If
                End If
            End With
        Next
        clsFun.CloseConnection()
    End Sub
    Public Sub FillControls(ByVal id As Integer)
        Dim sSql As String = String.Empty
        Dim Sql As String = String.Empty
        BtnSave.Text = "&Update" : btnPrintNDelete.Text = "&Delete"
        LblName.Text = "MODIFY PURCHASE"
        clsFun.FillDropDownList(CbSeries, "Select ID,InvoiceTypeName From InvoiceType Where AccountID=36 and InvoiceTypeName ='Purchase' ", "InvoiceTypeName", "Id", "")
        '  Panel1.BackColor = Color.PaleVioletRed
        If clsFun.GetConnection.State = ConnectionState.Open Then clsFun.CloseConnection()
        If clsFun.GetConnection.State = ConnectionState.Open Then clsFun.CloseConnection()
        sSql = "Select * from Trans_View where id=" & id
        Sql = "Select * from ChargesTrans where VoucherID=" & id
        clsFun.con.Open()
        Dim ad As New SQLite.SQLiteDataAdapter(sSql, clsFun.GetConnection)
        Dim ad1 As New SQLite.SQLiteDataAdapter(Sql, clsFun.GetConnection)
        Dim ds As New DataSet
        ad.Fill(ds, "a")
        ad1.Fill(ds, "b")
        If ds.Tables("a").Rows.Count > 0 Then
            txtID.Text = ds.Tables("a").Rows(0)("ID").ToString()
            mskEntryDate.Text = Format(ds.Tables("a").Rows(0)("EntryDate"), "dd-MM-yyyy")
            txtBillNo.Text = ds.Tables("a").Rows(0)("InvoiceNo").ToString()
            CbSeries.Text = ds.Tables("a").Rows(0)("InvoiceTypeName").ToString()
            txtAccountID.Text = ds.Tables("a").Rows(0)("AccountID").ToString()
            lblAccountType.Text = clsFun.ExecScalarStr("Select AccountType From Accounts Where ID=" & Val(ds.Tables("a").Rows(0)("AccountID").ToString()) & "")
            txtAccount.Text = ds.Tables("a").Rows(0)("AccountName").ToString()
            txttotQty.Text = Format(Val(ds.Tables("a").Rows(0)("totQty").ToString()), "0.00")
            txtTotBasic.Text = Format(Val(ds.Tables("a").Rows(0)("TotalBasicAmt").ToString()), "0.00")
            txtTotDiscount.Text = Format(Val(ds.Tables("a").Rows(0)("TotalDiscAmt").ToString()), "0.00")
            txtTotTaxable.Text = Format(Val(ds.Tables("a").Rows(0)("TotalTaxableAmt").ToString()), "0.00")
            txtTotTax.Text = Format(Val(ds.Tables("a").Rows(0)("TotalTaxAmt").ToString()), "0.00")
            txtTotCharges.Text = Format(Val(ds.Tables("a").Rows(0)("TotalCharges").ToString()), "0.00")
            txtTotRoundOff.Text = Format(Val(ds.Tables("a").Rows(0)("RoundOff").ToString()), "0.00")
            txtTotTotal.Text = Format(Val(ds.Tables("a").Rows(0)("TotalGrandAmt").ToString()), "0.00")
            txtTotCash.Text = Format(Val(ds.Tables("a").Rows(0)("TotalCashAmt").ToString()), "0.00")
            txtTotChange.Text = Format(Val(ds.Tables("a").Rows(0)("TotalBalAmt").ToString()), "0.00")
            txtTotCess.Text = Format(Val(ds.Tables("a").Rows(0)("TotalCessAmt").ToString()), "0.00")
            txtTotAddCess.Text = Format(Val(ds.Tables("a").Rows(0)("TotalAddCessAmt").ToString()), "0.00")
        End If

        '''''''''''''''''''Items Retrive''''''''''''''''''''
        If ds.Tables("a").Rows.Count > 0 Then dg1.Rows.Clear()
        With dg1
            Dim i As Integer = 0
            For i = 0 To ds.Tables("a").Rows.Count - 1
                .Rows.Add()
                .Rows(i).Cells(0).Value = ds.Tables("a").Rows(i)("ItemID").ToString()
                .Rows(i).Cells(1).Value = ds.Tables("a").Rows(i)("SNo").ToString()
                .Rows(i).Cells(3).Value = ds.Tables("a").Rows(i)("ItemName").ToString()
                .Rows(i).Cells(4).Value = ds.Tables("a").Rows(i)("Per").ToString()
                .Rows(i).Cells(5).Value = Format(Val(ds.Tables("a").Rows(i)("Qty").ToString()), "0.00")
                .Rows(i).Cells(6).Value = Format(Val(ds.Tables("a").Rows(i)("Rate").ToString()), "0.00")
                .Rows(i).Cells(7).Value = Format(Val(ds.Tables("a").Rows(i)("BasicAmt").ToString()), "0.00")
                .Rows(i).Cells(8).Value = Format(Val(ds.Tables("a").Rows(i)("DisPer").ToString()), "0.00")
                .Rows(i).Cells(9).Value = Format(Val(ds.Tables("a").Rows(i)("DisAmt").ToString()), "0.00")
                .Rows(i).Cells(10).Value = Format(Val(ds.Tables("a").Rows(i)("TaxableAmt").ToString()), "0.00")
                .Rows(i).Cells(11).Value = Format(Val(ds.Tables("a").Rows(i)("TaxPer").ToString()), "0.00")
                .Rows(i).Cells(12).Value = Format(Val(ds.Tables("a").Rows(i)("TaxAmt").ToString()), "0.00")
                .Rows(i).Cells(13).Value = Format(Val(ds.Tables("a").Rows(i)("TotalAmt").ToString()), "0.00")
                .Rows(i).Cells(14).Value = Format(Val(ds.Tables("a").Rows(i)("CessPer").ToString()), "0.00")
                .Rows(i).Cells(15).Value = Format(Val(ds.Tables("a").Rows(i)("CessAmt").ToString()), "0.00")
                .Rows(i).Cells(16).Value = Format(Val(ds.Tables("a").Rows(i)("Cess2").ToString()), "0.00")
            Next
        End With
        ''''''''''''''''''''''''Charges Retrive ''''''''''''''''''''''''''''''''''
        If ds.Tables("b").Rows.Count > 0 Then Dg2.Rows.Clear()
        Dg2.Rows.Clear()
        With Dg2
            Dim i As Integer = 0
            For i = 0 To ds.Tables("b").Rows.Count - 1
                .Rows.Add()
                .Rows(i).Cells(0).Value = ds.Tables("b").Rows(i)("SNo").ToString()
                .Rows(i).Cells(1).Value = ds.Tables("b").Rows(i)("ChargesID").ToString()
                .Rows(i).Cells(2).Value = ds.Tables("b").Rows(i)("ChargeName").ToString()
                .Rows(i).Cells(3).Value = Format(ds.Tables("b").Rows(i)("OnValue").ToString(), "0.00")
                .Rows(i).Cells(4).Value = ds.Tables("b").Rows(i)("Calculate").ToString()
                .Rows(i).Cells(5).Value = ds.Tables("b").Rows(i)("ChargeType").ToString()
                .Rows(i).Cells(6).Value = Format(Val(ds.Tables("b").Rows(i)("Taxable").ToString()), "0.00")
                .Rows(i).Cells(7).Value = Format(Val(ds.Tables("b").Rows(i)("TaxPer").ToString()), "0.00")
                .Rows(i).Cells(8).Value = Format(Val(ds.Tables("b").Rows(i)("Amount").ToString()), "0.00")
                .Rows(i).Cells(9).Value = Format(Val(ds.Tables("b").Rows(i)("TaxAmt").ToString()), "0.00")
            Next
        End With
        dg1.ClearSelection() : Dg2.ClearSelection()
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
        txtDisAmt.Text = dg1.SelectedRows(0).Cells(9).Value
        txtTaxable.Text = dg1.SelectedRows(0).Cells(10).Value
        txtTaxPer.Text = dg1.SelectedRows(0).Cells(11).Value
        txtTaxAmt.Text = dg1.SelectedRows(0).Cells(12).Value
        txtTotalAmt.Text = dg1.SelectedRows(0).Cells(13).Value
        lblCessPer.Text = dg1.SelectedRows(0).Cells(14).Value
    End Sub
    Private Sub txtTotalAmt_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTotalAmt.KeyDown
        If e.KeyCode = Keys.Enter Then
            'If txtItem.Text = "" Or txtItemID.Text = "" Then MsgBox("Please select Item... Blank Item Name Can't Be Insert in Record.", vbCritical, "Access Denied.") : txtItem.Focus() : Exit Sub
            'If txtQty.Text = Val(0) Then MsgBox("Zero Quantity Can't Insert In Record", vbCritical, "Access Denied.") : txtQty.Focus() : Exit Sub
            If dg1.SelectedRows.Count = 1 Then
                dg1.SelectedRows(0).Cells(0).Value = Val(txtItemID.Text)
                dg1.SelectedRows(0).Cells(3).Value = txtItem.Text
                dg1.SelectedRows(0).Cells(4).Value = lblUnit.Text
                dg1.SelectedRows(0).Cells(5).Value = txtQty.Text
                dg1.SelectedRows(0).Cells(6).Value = txtRate.Text
                dg1.SelectedRows(0).Cells(7).Value = txtBasic.Text
                dg1.SelectedRows(0).Cells(8).Value = txtDisPer.Text
                dg1.SelectedRows(0).Cells(9).Value = txtDisAmt.Text
                dg1.SelectedRows(0).Cells(10).Value = txtTaxable.Text
                dg1.SelectedRows(0).Cells(11).Value = txtTaxPer.Text
                dg1.SelectedRows(0).Cells(12).Value = txtTaxAmt.Text
                dg1.SelectedRows(0).Cells(13).Value = txtTotalAmt.Text
                dg1.SelectedRows(0).Cells(14).Value = lblCessPer.Text

            Else
                dg1.Rows.Add(Val(txtItemID.Text), dg1.Rows.Count + 1, lblCode.Text, txtItem.Text, lblUnit.Text, Val(txtQty.Text), Val(txtRate.Text),
                           Val(txtBasic.Text), Val(txtDisPer.Text), Val(txtDisAmt.Text), Val(txtTaxable.Text), Val(txtTaxPer.Text),
                           Val(txtTaxAmt.Text), Val(txtTotalAmt.Text), lblCessPer.Text)
            End If
            e.SuppressKeyPress = True
            dg1.ClearSelection() : calc() : txtClear()
        End If
    End Sub
    Private Sub txtClear()
        txtItemID.Clear() : txtItem.Clear()
        txtQty.Clear() : txtRate.Clear()
        txtBasic.Clear() : txtDisPer.Clear()
        txtDisAmt.Clear() : txtTaxable.Clear()
        txtTaxPer.Clear() : txtTaxAmt.Clear()
        txtTotalAmt.Clear() : txtItem.Focus()
    End Sub
    Private Sub txtclearall()
        txtClear() : VNumber()
        txtAccountID.Clear() : txtAccount.Clear()
        txttotQty.Clear() : txtTotBasic.Clear()
        txtTotDiscount.Clear() : txtTotTaxable.Clear()
        txtTotTax.Clear() : txtTotCharges.Clear()
        txtTotRoundOff.Clear() : txtTotTotal.Clear()
        txtTotCash.Clear() : txtTotChange.Clear()
        dg1.Rows.Clear() : Dg2.Rows.Clear()
        BtnSave.Text = "&Save" : btnPrintNDelete.Text = "&Print"
        LblName.Text = "PURCHASE ENTRY" : mskEntryDate.Focus()
    End Sub
    Private Sub txtQty_TextChanged(sender As Object, e As EventArgs) Handles txtQty.TextChanged, txtRate.TextChanged,
        txtBasic.TextChanged, txtDisPer.TextChanged, txtDisAmt.TextChanged, txtTaxable.TextChanged, txtTaxPer.TextChanged,
        txtTaxAmt.TextChanged, txtTotalAmt.TextChanged
        calculation()
    End Sub

    Private Sub txtChargesTotal_KeyDown(sender As Object, e As KeyEventArgs) Handles txtChargesTotal.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Dg2.SelectedRows.Count = 1 Then
                Dg2.SelectedRows(0).Cells(1).Value = txtChargesID.Text
                Dg2.SelectedRows(0).Cells(2).Value = txtcharges.Text
                Dg2.SelectedRows(0).Cells(3).Value = txtOnValue.Text
                Dg2.SelectedRows(0).Cells(4).Value = txtCalculatePer.Text
                Dg2.SelectedRows(0).Cells(5).Value = txtPlusMinus.Text
                Dg2.SelectedRows(0).Cells(6).Value = txtchargesBasic.Text
                Dg2.SelectedRows(0).Cells(7).Value = txtchargesTaxPer.Text
                Dg2.SelectedRows(0).Cells(8).Value = txtChargesTotal.Text

            Else
                Dg2.Rows.Add(Dg2.Rows.Count + 1, Val(txtChargesID.Text), txtcharges.Text, Format(Val(txtOnValue.Text), "0.00"),
                             Format(Val(txtCalculatePer.Text), "0.00"), txtPlusMinus.Text,
                             Format(Val(txtchargesBasic.Text), "0.00"), Format(Val(txtchargesTaxPer.Text), "0.00"),
                             Format(Val(txtChargesTotal.Text), "0.00"))
            End If

            Dg2.ClearSelection() : calc() : cleartxtCharges()
        End If

    End Sub
    Private Sub cleartxtCharges()
        txtOnValue.Text = "" : txtCalculatePer.Text = ""
        txtPlusMinus.Text = "" : txtChargesTotal.Text = ""
        txtchargesBasic.Text = ""
        txtchargesTaxPer.Text = "" : txtcharges.Focus()
    End Sub
    Private Sub txtOnValue_TextChanged(sender As Object, e As EventArgs) Handles txtOnValue.TextChanged, txtCalculatePer.TextChanged,
        txtBasic.TextChanged, txtTaxPer.TextChanged, txtTaxAmt.TextChanged, txtTotalAmt.TextChanged, txtChargesTotal.TextChanged

    End Sub
    Private Sub Dg2_KeyDown(sender As Object, e As KeyEventArgs) Handles Dg2.KeyDown
        If e.KeyCode = Keys.Delete Then
            If Dg2.SelectedRows.Count = 0 Then Exit Sub
            If MessageBox.Show("Are You Sure Want to Delete Selected Charge ?", "Delete Charge", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                Dg2.Rows.Remove(Dg2.SelectedRows(0))
                Dg2AutoSerial() : Dg2.ClearSelection() : calc()
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            If Dg2.SelectedRows.Count = 0 Then Exit Sub
            txtChargesID.Text = Dg2.SelectedRows(0).Cells(1).Value
            txtcharges.Text = Dg2.SelectedRows(0).Cells(2).Value
            txtOnValue.Text = Dg2.SelectedRows(0).Cells(3).Value
            txtCalculatePer.Text = Dg2.SelectedRows(0).Cells(4).Value
            txtPlusMinus.Text = Dg2.SelectedRows(0).Cells(5).Value
            txtchargesBasic.Text = Dg2.SelectedRows(0).Cells(6).Value
            txtchargesTaxPer.Text = Dg2.SelectedRows(0).Cells(7).Value
            txtChargesTotal.Text = Dg2.SelectedRows(0).Cells(8).Value
        End If
    End Sub

    Private Sub Dg2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Dg2.MouseDoubleClick
        If Dg2.SelectedRows.Count = 0 Then Exit Sub
        txtChargesID.Text = Dg2.SelectedRows(0).Cells(1).Value
        txtcharges.Text = Dg2.SelectedRows(0).Cells(2).Value
        txtOnValue.Text = Dg2.SelectedRows(0).Cells(3).Value
        txtCalculatePer.Text = Dg2.SelectedRows(0).Cells(4).Value
        txtPlusMinus.Text = Dg2.SelectedRows(0).Cells(5).Value
        txtchargesBasic.Text = Dg2.SelectedRows(0).Cells(6).Value
        txtchargesTaxPer.Text = Dg2.SelectedRows(0).Cells(7).Value
        txtChargesTotal.Text = Dg2.SelectedRows(0).Cells(8).Value
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If txtTotTotal.Text <> Val(txtTotCash.Text) + Val(txtTotChange.Text) Then
            MsgBox("ToTal Amount Should Be Equal Cash and Credit...", vbCritical, "Access Denied") : txtTotCash.Focus()
            txtTotCash.BackColor = Color.Red : txtTotCash.ForeColor = Color.White
            Exit Sub
        End If

        If BtnSave.Text = "&Save" Then
            save()
        Else
            Update()
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnPrintNDelete_Click(sender As Object, e As EventArgs) Handles btnPrintNDelete.Click
        If btnPrintNDelete.Text = "&Delete" Then
            Delete()
        End If
    End Sub
    Private Sub Delete()
        If MessageBox.Show("Are You Sure Want to Delete Purchase Bill ?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
            If clsFun.ExecNonQuery("DELETE from Vouchers WHERE ID=" & Val(txtID.Text) & ";DELETE from Trans where VoucherID=" & Val(txtID.Text) & ";DELETE from Ledger WHERE VouchersID=" & Val(txtID.Text) & ";DELETE from ChargesTrans WHERE VoucherID=" & Val(txtID.Text) & "") > 0 Then
                MsgBox("Record Deleted Successfully", vbInformation + vbOKOnly, "Deleted")
                txtclearall()
            End If
        End If
    End Sub
    Private Sub txtName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtName.KeyDown, txtAddress.KeyDown, txtCity.KeyDown,
        txtZip.KeyDown, txtState.KeyDown, txtStateCode.KeyDown, txtMobileNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txtGstNo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtGstNo.KeyDown
        If e.KeyCode = Keys.Enter Then txtItem.Focus() : pnlCustomerInfo.Visible = False
    End Sub

    Private Sub txtTotCash_Leave(sender As Object, e As EventArgs) Handles txtTotCash.Leave
        txtTotChange.Text = Format(Val(txtTotTotal.Text) - Val(txtTotCash.Text), "0.00") : txtTotCash.Text = Format(Val(txtTotCash.Text), "0.00")

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtID_TextChanged(sender As Object, e As EventArgs) Handles txtID.TextChanged

    End Sub

    Private Sub txtItem_TextChanged(sender As Object, e As EventArgs) Handles txtItem.TextChanged

    End Sub

    Private Sub txtAccount_TextChanged(sender As Object, e As EventArgs) Handles txtAccount.TextChanged

    End Sub
End Class