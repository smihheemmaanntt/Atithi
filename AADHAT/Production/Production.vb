Public Class Production
    Dim Hash As Decimal = "0.00"
    Dim CalcType As String
    Private Sub Manufacturing_of_Materials_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If dgReceipe.Visible = True Then dgReceipe.Visible = False : Exit Sub
            If DgRawItem.Visible = True Then DgRawItem.Visible = False : Exit Sub
            If dgScrap.Visible = True Then dgScrap.Visible = False : Exit Sub
            If dgCharges.Visible = True Then dgCharges.Visible = False : Exit Sub
            If Val(dg1.Rows.Count) > 0 Then
                If MessageBox.Show("Are you Sure want to Exit Production ?", "Exit Production Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    e.SuppressKeyPress = True
                    Me.SuspendLayout() : Me.Dispose()
                End If
            Else
                Me.SuspendLayout() : Me.Dispose()
            End If
        End If

    End Sub

    Private Sub Manufacturing_of_Materials_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0 : Me.Left = 0
        mskEntryDate.Text = Date.Today.ToString("dd-MM-yyyy")
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True : VNumber() : Dg1RowColumns() : Dg2RowColumns() : Dg3RowColumns()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If Val(dg1.Rows.Count) > 0 Then
            If MessageBox.Show("Are you Sure want to Exit Production ?", "Exit Purchase Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.SuspendLayout() : Me.Dispose()
            End If
        Else
            Me.SuspendLayout() : Me.Dispose()
        End If
    End Sub

    Public Sub FillControls(ByVal id As Integer)
        Dim sSql As String = String.Empty
        Dim IsIGST As String = String.Empty
        BtnSave.Text = "&Update"
        btnDelete.Visible = True
        If clsFun.GetConnection.State = ConnectionState.Open Then clsFun.CloseConnection()
        sSql = "Select * from Vouchers where ID=" & id
        clsFun.con.Open()
        Dim ad As New SQLite.SQLiteDataAdapter(sSql, clsFun.GetConnection)
        Dim ds As New DataSet
        ad.Fill(ds, "a")
        If ds.Tables("a").Rows.Count > 0 Then
            txtID.Text = ds.Tables("a").Rows(0)("ID").ToString()
            mskEntryDate.Text = Format(ds.Tables("a").Rows(0)("EntryDate"), "dd-MM-yyyy")
            txtBillNo.Text = ds.Tables("a").Rows(0)("InvoiceNo").ToString()
            txtReceipeID.Text = ds.Tables("a").Rows(0)("ProcessID").ToString()
            lblUnit.Text = clsFun.ExecScalarStr("Select UnitName From Receipe Where ID=" & Val(ds.Tables("a").Rows(0)("ProcessID").ToString()) & "")
            txtReceipeName.Text = ds.Tables("a").Rows(0)("ProcessName").ToString()
            txtMainItemID.Text = ds.Tables("a").Rows(0)("ItemID").ToString()
            txtMainItem.Text = ds.Tables("a").Rows(0)("ItemName").ToString()
            txtMainQty.Text = ds.Tables("a").Rows(0)("TotQty").ToString()
            txtInvoiceID.Text = Val(ds.Tables("a").Rows(0)("InvoiceID").ToString())
        End If
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("SELECT * FROM Trans where TransType='Raw Item' and VoucherID=" & id)
        Dim dvData As DataView = New DataView(dt)
        Try
            If dt.Rows.Count > 0 Then
                dg1.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("ItemID").ToString()
                        .Cells(1).Value = dt.Rows(i)("ItemName").ToString()
                        .Cells(2).Value = dt.Rows(i)("Qty").ToString()
                        .Cells(3).Value = dt.Rows(i)("UnitName").ToString()
                        .Cells(4).Value = dt.Rows(i)("Rate").ToString()
                        .Cells(5).Value = Val(dt.Rows(i)("BasicAmt").ToString())
                    End With
                Next
            End If
        Catch ex As Exception
            MsgBox("Atithi")
        End Try

        Dim DT11 As New DataTable
        DT1 = clsFun.ExecDataTable("SELECT * FROM Trans where TransType='Scrap Item' and VoucherID=" & id)
        Dim dvData1 As DataView = New DataView(DT1)
        Try
            If DT1.Rows.Count > 0 Then
                dg2.Rows.Clear()
                For i = 0 To DT1.Rows.Count - 1
                    dg2.Rows.Add()
                    With dg2.Rows(i)
                        .Cells(0).Value = DT1.Rows(i)("ItemID").ToString()
                        .Cells(1).Value = DT1.Rows(i)("ItemName").ToString()
                        .Cells(2).Value = DT1.Rows(i)("Qty").ToString()
                        .Cells(3).Value = DT1.Rows(i)("UnitName").ToString()
                        .Cells(4).Value = DT1.Rows(i)("Rate").ToString()
                        .Cells(5).Value = Val(DT1.Rows(i)("BasicAmt").ToString())
                    End With
                Next
            End If
        Catch ex As Exception
            MsgBox("Atithi")
        End Try

        Dim Dt2 As New DataTable
        DT2 = clsFun.ExecDataTable("Select * from ChargesTrans where VoucherID=" & Val(txtID.Text) & "")
        Dim dvData2 As DataView = New DataView(DT1)
        Try
            If DT2.Rows.Count > 0 Then
                dg3.Rows.Clear()
                For i = 0 To DT2.Rows.Count - 1
                    dg3.Rows.Add()
                    With dg3.Rows(i)
                        .Cells(0).Value = DT2.Rows(i)("ChargesID").ToString()
                        .Cells(1).Value = DT2.Rows(i)("ChargeName").ToString()
                        .Cells(2).Value = IIf(Val(Dt2.Rows(i)("OnValue").ToString()) = 0, "", Val(Dt2.Rows(i)("OnValue").ToString()))
                        .Cells(3).Value = IIf(Val(Dt2.Rows(i)("Calculate").ToString()) = 0, "", Val(Dt2.Rows(i)("Calculate").ToString()))
                        .Cells(4).Value = DT2.Rows(i)("ChargeType").ToString()
                        .Cells(5).Value = Val(DT2.Rows(i)("Amount").ToString())
                        .Cells(6).Value = Format(Math.Abs(Val(Val(DT2.Rows(i)("TaxPer").ToString()))), Hash)
                        .Cells(7).Value = Format(Math.Abs(Val(DT2.Rows(i)("TaxAmt").ToString())), Hash)
                        .Cells(8).Value = Format(Math.Abs(Val(DT2.Rows(i)("CessPer").ToString())), Hash)
                        .Cells(9).Value = Format(Math.Abs(Val(DT2.Rows(i)("CessAmt").ToString())), Hash)
                        .Cells(10).Value = Format(Math.Abs(Val(DT2.Rows(i)("TaxableAmt").ToString())), Hash)
                    End With
                Next
            End If
        Catch ex As Exception
            MsgBox("Atithi")
        End Try

    

        Calc() : dg1.ClearSelection() : dg2.ClearSelection() : dg3.ClearSelection()
    End Sub

    Private Sub Calc()
        txtTotTaxable.Text = Format(0, "0.00") : txtTotQty.Text = 0
        txtScrapeTotAmt.Text = Format(0, "0.00") : txtScrapTotQty.Text = 0
        lblChargesTotAmt.Text = Format(0, "0.00") : lblTotEffectiveCost.Text = Format(0, "0.00")
        lblTotAllocationCost.Text = Format(0, "0.00") : lblUnitRate.Text = Format(0, "0.00")
        For i = 0 To dg1.Rows.Count - 1
            txtTotQty.Text = Val(txtTotQty.Text) + Val(dg1.Rows(i).Cells(2).Value)
            txtTotTaxable.Text = Format(Val(txtTotTaxable.Text) + Val(dg1.Rows(i).Cells(5).Value), "0.00")
        Next
        For i = 0 To dg2.Rows.Count - 1
            txtScrapTotQty.Text = Val(txtScrapTotQty.Text) + Val(dg2.Rows(i).Cells(2).Value)
            txtScrapeTotAmt.Text = Format(Val(txtScrapeTotAmt.Text) + Val(dg2.Rows(i).Cells(5).Value), "0.00")
        Next
        For i = 0 To dg3.Rows.Count - 1
            lblChargesTotAmt.Text = Format(Val(lblChargesTotAmt.Text) + Val(dg3.Rows(i).Cells(5).Value), "0.00")
        Next
        lblTotEffectiveCost.Text = Format(Val(txtTotTaxable.Text) + Val(lblChargesTotAmt.Text), "0.00")
        lblTotAllocationCost.Text = Format(Val(Val(txtTotTaxable.Text) - Val(txtScrapeTotAmt.Text)) + Val(lblChargesTotAmt.Text), "0.00")
        lblUnitRate.Text = Format(Val(lblTotAllocationCost.Text) / Val(txtMainQty.Text), "0.00") & " /-" & lblUnit.Text
    End Sub
    Private Sub Dg3RowColumns()
        dg3.ColumnCount = 12
        dg3.Columns(0).Name = "ChargeID" : dg3.Columns(0).Visible = False
        dg3.Columns(1).Name = "Charge Name" : dg3.Columns(1).Width = 198 : dg3.Columns(1).SortMode = DataGridViewColumnSortMode.Automatic : dg3.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft : dg3.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dg3.Columns(2).Name = "On Value" : dg3.Columns(2).Width = 99 : dg3.Columns(2).SortMode = DataGridViewColumnSortMode.Automatic : dg3.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter : dg3.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg3.Columns(3).Name = "Cal" : dg3.Columns(3).Width = 69 : dg3.Columns(3).SortMode = DataGridViewColumnSortMode.Automatic : dg3.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter : dg3.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg3.Columns(4).Name = "+/-" : dg3.Columns(4).Width = 49 : dg3.Columns(4).SortMode = DataGridViewColumnSortMode.Automatic : dg3.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg3.Columns(5).Name = "Amount" : dg3.Columns(5).Width = 95 : dg3.Columns(5).SortMode = DataGridViewColumnSortMode.Automatic : dg3.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight : dg3.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dg3.Columns(6).Name = "TaxPer" : dg3.Columns(6).Visible = False
        dg3.Columns(7).Name = "TaxAmt" : dg3.Columns(7).Visible = False
        dg3.Columns(8).Name = "CessPer" : dg3.Columns(8).Visible = False
        dg3.Columns(9).Name = "CessAmt" : dg3.Columns(9).Visible = False
        dg3.Columns(10).Name = "Taxable" : dg3.Columns(10).Visible = False
        dg3.Columns(11).Name = "AppValue" : dg3.Columns(11).Visible = False
    End Sub

    Private Sub ChargesRowColums()
        dgCharges.ColumnCount = 3
        dgCharges.Columns(0).Name = "ID" : dgCharges.Columns(0).Visible = False
        dgCharges.Columns(1).Name = "Item Name" : dgCharges.Columns(1).Width = 130
        dgCharges.Columns(2).Name = "ApplyType" : dgCharges.Columns(2).Width = 130
        RetriveCharges()
    End Sub

    Private Sub RetriveCharges(Optional ByVal condtion As String = "")
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("Select * from Charges " & condtion & " order by ChargeName")
        Try
            If dt.Rows.Count > 0 Then
                dgCharges.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dgCharges.Rows.Add()
                    With dgCharges.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("id").ToString()
                        .Cells(1).Value = dt.Rows(i)("ChargeName").ToString()
                        .Cells(2).Value = dt.Rows(i)("ApplyType").ToString()
                    End With
                Next

            End If
            dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "Aadhat")
        End Try
    End Sub


    Private Sub ChargesCalculation()
        Dim GSTApplicable As String = String.Empty
        ' If String.IsNullOrEmpty(txtOnValue.Text) OrElse String.IsNullOrEmpty(txtCalculatePer.Text) Then Exit Sub
        Dim IsGST As String = clsFun.ExecScalarStr(" Select FixAs FROM Charges WHERE ID='" & Val(txtChargeID.Text) & "'")
        Dim ApplyOn As String = clsFun.ExecScalarStr(" Select Applyon FROM Charges WHERE ID='" & Val(txtChargeID.Text) & "'")
        If clsFun.ExecScalarInt(" Select TaxID FROM Charges WHERE ID='" & Val(txtChargeID.Text) & "'") <> 0 Then GSTApplicable = "Yes"
        If GSTApplicable = "Yes" Then
            txtGstperCharge.Text = Format(Val(clsFun.ExecScalarInt("SELECT GSTPer FROM Charges AS D Inner JOIN Taxation AS T ON D.TaxID = T.ID Where D.ID=" & Val(txtChargeID.Text) & "")), Hash)
            txtCessPerCharge.Text = Format(Val(clsFun.ExecScalarInt("SELECT CessPer FROM Charges AS D Inner JOIN Taxation AS T ON D.TaxID = T.ID Where D.ID=" & Val(txtChargeID.Text) & "")), Hash)
            If CalcType = "Percentage" Then
                txtChargeTaxable.Text = Format(Val(Val(txtOnValue.Text) * Val(txtCalculatePer.Text) / 100), Hash)
                If lblRegion.Text = "Local" Then
                    lblChargeCGST.Text = Format(Val(Val(txtChargeTaxable.Text) * Val(Val(txtGstperCharge.Text) / 2) / 100), Hash)
                    lblChargesSGST.Text = Format(Val(Val(txtChargeTaxable.Text) * Val(Val(txtGstperCharge.Text) / 2) / 100), Hash)
                    lblChargesIGST.Text = Format(0, Hash)
                Else
                    lblChargeCGST.Text = Format(0, Hash)
                    lblChargesIGST.Text = Format(0, Hash)
                    lblChargesSGST.Text = Format(Val(Val(txtChargeTaxable.Text) * Val(txtGstperCharge.Text) / 100), Hash)
                End If
                txtGSTAmtCharge.Text = Format(Val(lblChargeCGST.Text) + Val(lblChargesSGST.Text) + Val(lblChargesIGST.Text), Hash)
                '             txtchargesAmount.Text = Format(Val(Val(txtChargeTaxable.Text) + Val(txtGSTAmtCharge.Text) + Val(txtCessAmtCharge.Text)), Hash)
            ElseIf CalcType = "Qty" Then
                txtChargeTaxable.Text = Format(Val(Val(txtOnValue.Text) * Val(txtCalculatePer.Text)), Hash)
                If lblRegion.Text = "Local" Then
                    lblChargeCGST.Text = Format(Val(Val(txtChargeTaxable.Text) * Val(Val(txtGstperCharge.Text) / 2) / 100), Hash)
                    lblChargesSGST.Text = Format(Val(Val(txtChargeTaxable.Text) * Val(Val(txtGstperCharge.Text) / 2) / 100), Hash)
                    lblChargesIGST.Text = Format(0, Hash)
                Else
                    lblChargeCGST.Text = Format(0, Hash)
                    lblChargesIGST.Text = Format(0, Hash)
                    lblChargesSGST.Text = Format(Val(Val(txtChargeTaxable.Text) * Val(txtGstperCharge.Text) / 100), Hash)
                End If
                txtGSTAmtCharge.Text = Format(Val(lblChargeCGST.Text) + Val(lblChargesSGST.Text) + Val(lblChargesIGST.Text), Hash)
                '        txtCessAmtCharge.Text = Format(Val(Val(txtChargeTaxable.Text) * Val(Val(txtCessPerCharge.Text)) / 100), Hash)
                '  txtGSTAmtCharge.Text = Format(Val(Val(txtChargeTaxable.Text) * Val(txtGstperCharge.Text) / 100), Hash)
                '              txtchargesAmount.Text = Format(Val(Val(txtChargeTaxable.Text) + Val(txtGSTAmtCharge.Text) + Val(txtCessAmtCharge.Text)), Hash)
            ElseIf CalcType = "Weight" Then
                txtChargeTaxable.Text = Format(Val(txtOnValue.Text) * Val(txtCalculatePer.Text), Hash)
                If lblRegion.Text = "Local" Then
                    lblChargeCGST.Text = Format(Val(Val(txtChargeTaxable.Text) * Val(Val(txtGstperCharge.Text) / 2) / 100), Hash)
                    lblChargesSGST.Text = Format(Val(Val(txtChargeTaxable.Text) * Val(Val(txtGstperCharge.Text) / 2) / 100), Hash)
                    lblChargesIGST.Text = Format(0, Hash)
                Else
                    lblChargeCGST.Text = Format(0, Hash)
                    lblChargesIGST.Text = Format(0, Hash)
                    lblChargesSGST.Text = Format(Val(Val(txtChargeTaxable.Text) * Val(txtGstperCharge.Text) / 100), Hash)
                End If
                txtGSTAmtCharge.Text = Format(Val(lblChargeCGST.Text) + Val(lblChargesSGST.Text) + Val(lblChargesIGST.Text), Hash)
                '      txtCessAmtCharge.Text = Format(Val(Val(txtChargeTaxable.Text) * Val(Val(txtCessPerCharge.Text)) / 100), Hash)
                ' txtGSTAmtCharge.Text = Format(Val(Val(txtChargeTaxable.Text) * Val(txtGstperCharge.Text) / 100), Hash)
                '               txtchargesAmount.Text = Format(Val(Val(txtChargeTaxable.Text) + Val(txtGSTAmtCharge.Text) + Val(txtCessAmtCharge.Text)), Hash)
            ElseIf CalcType = "Aboslute" Then
                ' If String.IsNullOrEmpty(txtOnValue.Text) OrElse String.IsNullOrEmpty(txtCalculatePer.Text) Then Exit Sub
                'txtChargeTaxable.Text = Format(Val(CDbl(txtOnValue.Text) * CDbl(txtCalculatePer.Text)), Hash)
                If lblRegion.Text = "Local" Then
                    lblChargeCGST.Text = Format(Val(Val(txtChargeTaxable.Text) * Val(Val(txtGstperCharge.Text) / 2) / 100), Hash)
                    lblChargesSGST.Text = Format(Val(Val(txtChargeTaxable.Text) * Val(Val(txtGstperCharge.Text) / 2) / 100), Hash)
                    lblChargesIGST.Text = Format(0, Hash)
                Else
                    lblChargeCGST.Text = Format(0, Hash)
                    lblChargesIGST.Text = Format(0, Hash)
                    lblChargesSGST.Text = Format(Val(Val(txtChargeTaxable.Text) * Val(txtGstperCharge.Text) / 100), Hash)
                End If
                txtGSTAmtCharge.Text = Format(Val(lblChargeCGST.Text) + Val(lblChargesSGST.Text) + Val(lblChargesIGST.Text), Hash)
                '                txtchargesAmount.Text = Format(Val(Val(txtChargeTaxable.Text) + Val(txtGSTAmtCharge.Text) + Val(txtCessAmtCharge.Text)), Hash)
            End If
        Else
            txtChargeTaxable.Text = Format(0, Hash) : lblChargeCGST.Text = Format(0, Hash)
            lblChargesIGST.Text = Format(0, Hash) : lblChargesIGST.Text = Format(0, Hash)
            txtGSTAmtCharge.Text = Format(Val(lblChargeCGST.Text) + Val(lblChargesSGST.Text) + Val(lblChargesIGST.Text), Hash)
            txtGstperCharge.Text = Format(0, Hash)
            If CalcType = "Percentage" Then
                txtchargesAmount.Text = Format(Val(txtOnValue.Text) * Val(txtCalculatePer.Text) / 100, Hash)
                txtGSTAmtCharge.Text = txtchargesAmount.Text
            ElseIf CalcType = "Qty" Then
                txtchargesAmount.Text = Format(Val(txtOnValue.Text) * Val(txtCalculatePer.Text), Hash)
            ElseIf CalcType = "Weight" Then
                txtchargesAmount.Text = Format(Val(txtOnValue.Text) * Val(txtCalculatePer.Text), Hash)
                txtGSTAmtCharge.Text = txtchargesAmount.Text
            End If
        End If
    End Sub


    Private Sub ItemRowColumns()
        dgReceipe.ColumnCount = 5
        dgReceipe.Columns(0).Name = "ID" : dgReceipe.Columns(0).Visible = False
        dgReceipe.Columns(1).Name = "Receipe Name" : dgReceipe.Columns(1).Width = 150
        dgReceipe.Columns(2).Name = "ItemID" : dgReceipe.Columns(2).Visible = False
        dgReceipe.Columns(3).Name = "Item Name" : dgReceipe.Columns(3).Width = 200
        dgReceipe.Columns(4).Name = "Unit" : dgReceipe.Columns(4).Width = 100
        retriveMainItems()
    End Sub

    Private Sub Dg1RowColumns()
        dg1.ColumnCount = 6
        dg1.Columns(0).Name = "ID" : dg1.Columns(0).Visible = False
        dg1.Columns(1).Name = "Item Name" : dg1.Columns(1).Width = 202 : dg1.Columns(1).SortMode = DataGridViewColumnSortMode.Automatic : dg1.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft : dg1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dg1.Columns(2).Name = "Qty" : dg1.Columns(2).Width = 100 : dg1.Columns(2).SortMode = DataGridViewColumnSortMode.Automatic : dg1.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight : dg1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dg1.Columns(3).Name = "Unit" : dg1.Columns(3).Width = 99 : dg1.Columns(3).SortMode = DataGridViewColumnSortMode.Automatic : dg1.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter : dg1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg1.Columns(4).Name = "Rate" : dg1.Columns(4).Width = 99 : dg1.Columns(4).SortMode = DataGridViewColumnSortMode.Automatic : dg1.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight : dg1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dg1.Columns(5).Name = "Amount" : dg1.Columns(5).Width = 150 : dg1.Columns(5).SortMode = DataGridViewColumnSortMode.Automatic : dg1.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight : dg1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub Dg2RowColumns()
        dg2.ColumnCount = 6
        dg2.Columns(0).Name = "ID" : dg2.Columns(0).Visible = False
        dg2.Columns(1).Name = "Item Name" : dg2.Columns(1).Width = 198 : dg2.Columns(1).SortMode = DataGridViewColumnSortMode.Automatic : dg2.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft : dg2.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dg2.Columns(2).Name = "Qty" : dg2.Columns(2).Width = 49 : dg2.Columns(2).SortMode = DataGridViewColumnSortMode.Automatic : dg2.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight : dg2.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dg2.Columns(3).Name = "Unit" : dg2.Columns(3).Width = 69 : dg2.Columns(3).SortMode = DataGridViewColumnSortMode.Automatic : dg2.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter : dg2.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg2.Columns(4).Name = "Rate" : dg2.Columns(4).Width = 82 : dg2.Columns(4).SortMode = DataGridViewColumnSortMode.Automatic : dg2.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight : dg2.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dg2.Columns(5).Name = "Amount" : dg2.Columns(5).Width = 109 : dg2.Columns(5).SortMode = DataGridViewColumnSortMode.Automatic : dg2.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight : dg2.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub VNumber()
        Dim vno As Integer = 0
        If vno = Val(clsFun.ExecScalarInt("SELECT Max(InvoiceID) AS ID FROM Vouchers Where TransType='Production' AND  ID= (Select mAX(ID) from Vouchers)")) <> 0 Then
            vno = clsFun.ExecScalarInt("SELECT Max(InvoiceID) AS ID FROM Vouchers Where TransType='Production' AND  ID= (Select mAX(ID) from Vouchers)")
            txtBillNo.Text = vno + 1
            txtInvoiceID.Text = vno + 1
        Else
            vno = clsFun.ExecScalarInt("SELECT Max(InvoiceID) AS ID FROM Vouchers Where TransType='Production' AND  ID= (Select mAX(ID) from Vouchers)")
            txtBillNo.Text = vno + 1
            txtInvoiceID.Text = vno + 1
        End If
    End Sub

    Private Sub retriveMainItems(Optional ByVal condtion As String = "")
        dgReceipe.Rows.Clear()
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("Select * from Receipe " & condtion & " Limit 20")
        Try
            If dt.Rows.Count > 0 Then
                dgReceipe.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dgReceipe.Rows.Add()
                    With dgReceipe.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("ID").ToString()
                        .Cells(1).Value = dt.Rows(i)("ReceipeName").ToString()
                        .Cells(2).Value = dt.Rows(i)("ItemID").ToString()
                        .Cells(3).Value = dt.Rows(i)("ItemName").ToString()
                        .Cells(4).Value = dt.Rows(i)("UnitName").ToString()
                    End With
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "Teller")
        End Try
    End Sub

    Private Sub RetriveRecepie(Optional ByVal condtion As String = "")
        txtReceipeName.Text = clsFun.ExecScalarStr("Select ReceipeName From  Receipe Where ItemID=" & Val(txtMainItemID.Text) & "")
        txtReceipeID.Text = clsFun.ExecScalarStr("Select ID From  Receipe Where ItemID=" & Val(txtMainItemID.Text) & "")
        dg1.Rows.Clear()
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("Select * from ReceipeItems Where ReceipeID=" & Val(txtReceipeID.Text) & "")
        Try
            If dt.Rows.Count > 0 Then
                dg1.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        .Cells(0).Value = Val(dt.Rows(i)("ItemID").ToString())
                        .Cells(1).Value = dt.Rows(i)("ItemName").ToString()
                        .Cells(2).Value = Val(dt.Rows(i)("Qty").ToString()) * Val(txtMainQty.Text)
                        .Cells(3).Value = dt.Rows(i)("UnitName").ToString()
                        .Cells(4).Value = Format(Val(clsFun.ExecScalarDec("Select PurchaseRate From Items Where ID=" & Val(dt.Rows(i)("ItemID").ToString()) & "")), "0.00")
                        .Cells(5).Value = Format(Val(.cells(2).value) * Val(.cells(4).value), "0.00")
                    End With
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "Teller")
        End Try
        Calc() : dg1.ClearSelection()
    End Sub

    Private Sub txtMainItem_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMainItem.KeyPress
        If Not Char.IsLetterOrDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso e.KeyChar <> "%" AndAlso Not Char.IsControl(e.KeyChar) AndAlso e.KeyChar <> " " Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtMainQty_GotFocus(sender As Object, e As EventArgs) Handles txtMainQty.GotFocus
        If dgReceipe.ColumnCount = 0 Then ItemRowColumns()
        If txtMainItem.Text.Trim() <> "" Then
            retriveMainItems(" Where upper(ItemName) Like upper('" & txtMainItem.Text.Trim() & "%')")
        Else
            If dgReceipe.Rows.Count = 0 Then retriveMainItems()
        End If
        If dgReceipe.SelectedRows.Count = 0 Then dgReceipe.Visible = True : dgReceipe.BringToFront() : txtMainItem.Focus() : Exit Sub
        txtReceipeID.Text = Val(dgReceipe.SelectedRows(0).Cells(0).Value)
        txtReceipeName.Text = dgReceipe.SelectedRows(0).Cells(1).Value
        txtMainItemID.Text = Val(dgReceipe.SelectedRows(0).Cells(2).Value)
        txtMainItem.Text = dgReceipe.SelectedRows(0).Cells(3).Value
        lblUnit.Text = dgReceipe.SelectedRows(0).Cells(4).Value
        dgReceipe.Visible = False
    End Sub

    Private Sub txtReceipeName_GotFocus(sender As Object, e As EventArgs) Handles txtReceipeName.GotFocus
        DgRawItem.Visible = False : RawItemClears() : dgScrap.Visible = False : ScrapItemClears()
        If dgReceipe.ColumnCount = 0 Then ItemRowColumns()
        If txtMainItem.Text.Trim() <> "" Then
            retriveMainItems(" Where upper(ItemName) Like upper('" & txtMainItem.Text.Trim() & "%')")
        Else
            If dgReceipe.Rows.Count = 0 Then retriveMainItems()
        End If
        If dgReceipe.SelectedRows.Count = 0 Then dgReceipe.Visible = True : dgReceipe.BringToFront() : txtReceipeName.Focus() : Exit Sub
    End Sub
    Private Sub txtBillNo_GotFocus(sender As Object, e As EventArgs) Handles txtBillNo.GotFocus, txtMainItem.GotFocus,
    txtReceipeName.GotFocus, txtMainQty.GotFocus, txtRawRate.GotFocus, TxtRawItem.GotFocus, txtRawQty.GotFocus, txtRawUnit.GotFocus, txtRawAmt.GotFocus,
        txtScrapItem.GotFocus, txtScrapQty.GotFocus, txtScrapRate.GotFocus, txtScrapUnit.GotFocus, txtScrapAmt.GotFocus, txtCharges.GotFocus, txtOnvalue.GotFocus,
        txtCalculatePer.GotFocus, txtPlusMinus.GotFocus, txtchargesAmount.GotFocus
        If txtScrapQty.Focused Then
            If dgScrap.ColumnCount = 0 Then ScrapItemRowColumns()
            If dgScrap.Rows.Count = 0 Then retriveScrapItems()
            If dgScrap.SelectedRows.Count = 0 Then dgScrap.Visible = True
            txtScrapID.Text = Val(dgScrap.SelectedRows(0).Cells(0).Value)
            txtScrapItem.Text = dgScrap.SelectedRows(0).Cells(2).Value
            txtScrapUnit.Text = dgScrap.SelectedRows(0).Cells(3).Value
            dgScrap.Visible = False : txtScrapQty.Focus()
        End If
        If txtOnvalue.Focused Then
            If dgCharges.ColumnCount = 0 Then ChargesRowColums()
            If dgCharges.RowCount = 0 Then RetriveCharges()
            If dgCharges.SelectedRows.Count = 0 Then dgCharges.Visible = True
            txtCharges.Text = dgCharges.SelectedRows(0).Cells(1).Value
            txtChargeID.Text = Val(dgCharges.SelectedRows(0).Cells(0).Value)
            dgCharges.Visible = False : FillCharges()
        End If
        If txtchargesAmount.Focused Then
            If txtOnvalue.TabStop = False Then
                If dgCharges.ColumnCount = 0 Then ChargesRowColums()
                If dgCharges.RowCount = 0 Then RetriveCharges()
                If dgCharges.SelectedRows.Count = 0 Then dgCharges.Visible = True
                txtCharges.Text = dgCharges.SelectedRows(0).Cells(1).Value
                txtChargeID.Text = Val(dgCharges.SelectedRows(0).Cells(0).Value)
                dgCharges.Visible = False : FillCharges()
                If pnlGSTCharges.Visible = True Then txtChargeTaxable.Text = Format(Val(txtchargesAmount.Text), Hash) Else txtChargeTaxable.Text = "0.00"
                txtOnvalue.BackColor = Color.GhostWhite
            End If
        End If
        Dim tb As TextBox = CType(sender, TextBox)
        tb.BackColor = Color.Orange
        'tb.BackColor = Color.GhostWhite
        tb.SelectAll()
    End Sub

    Private Sub txtBillNo_LostFocus(sender As Object, e As EventArgs) Handles txtBillNo.LostFocus, txtMainItem.LostFocus,
    txtReceipeName.LostFocus, txtMainQty.LostFocus, txtRawRate.LostFocus, TxtRawItem.LostFocus, txtRawQty.LostFocus, txtRawUnit.LostFocus, txtRawAmt.LostFocus,
    txtScrapItem.LostFocus, txtScrapQty.LostFocus, txtScrapRate.LostFocus, txtScrapUnit.LostFocus, txtScrapAmt.LostFocus, txtCharges.LostFocus, txtOnvalue.LostFocus,
    txtCalculatePer.LostFocus, txtPlusMinus.LostFocus, txtchargesAmount.LostFocus
        Dim tb As TextBox = CType(sender, TextBox)
        If tb Is txtMainItem Then tb.BackColor = SystemColors.ActiveBorder : Exit Sub
        'tb.BackColor = Color.PaleTurquoise
        tb.BackColor = Color.GhostWhite
        'tb.SelectAll()
    End Sub

    Private Sub mskEntryDate_GotFocus(sender As Object, e As EventArgs) Handles mskEntryDate.GotFocus
        mskEntryDate.BackColor = Color.Orange
        mskEntryDate.SelectAll()
    End Sub

    Private Sub RawItemClears()
        txtRawItemID.Clear() : TxtRawItem.Clear()
        txtRawQty.Clear() : txtRawUnit.Clear()
        txtRawRate.Clear() : txtRawAmt.Clear()
        Calc() : dg1.ClearSelection() : DgRawItem.Visible = False
    End Sub

    Private Sub ScrapItemClears()
        txtScrapID.Clear() : txtScrapItem.Clear()
        txtScrapQty.Clear() : txtScrapUnit.Clear()
        txtScrapRate.Clear() : txtScrapAmt.Clear()
        dg2.ClearSelection() : dgScrap.Visible = False
        Calc()
    End Sub
    Private Sub ChargesClear()
        txtChargeID.Clear() : txtCharges.Clear()
        txtOnvalue.Clear() : txtCalculatePer.Clear()
        txtPlusMinus.Clear() : txtchargesAmount.Clear()
        dg3.ClearSelection() : dgCharges.Visible = False
        Calc()
    End Sub


    Private Sub mskEntryDate_KeyDown(sender As Object, e As KeyEventArgs) Handles mskEntryDate.KeyDown, txtBillNo.KeyDown, txtMainItem.KeyDown,
        txtReceipeName.KeyDown, txtMainQty.KeyDown, txtRawRate.KeyDown, TxtRawItem.KeyDown, txtRawQty.KeyDown, txtRawUnit.KeyDown, txtRawAmt.KeyDown,
        txtScrapItem.KeyDown, txtScrapQty.KeyDown, txtScrapUnit.KeyDown, txtScrapRate.KeyDown, txtScrapAmt.KeyDown, txtCharges.KeyDown, txtOnvalue.KeyDown,
        txtCalculatePer.KeyDown, txtPlusMinus.KeyDown, txtchargesAmount.KeyDown
        If txtRawAmt.Focused Then
            If e.KeyCode = Keys.Enter Then
                If Val(txtRawQty.Text) = 0 Then RawItemClears() : txtScrapItem.Focus() : e.SuppressKeyPress = True : Exit Sub
                If dg1.SelectedRows.Count <> 0 Then
                    dg1.SelectedRows(0).Cells(0).Value = Val(txtRawItemID.Text)
                    dg1.SelectedRows(0).Cells(1).Value = TxtRawItem.Text
                    dg1.SelectedRows(0).Cells(2).Value = Val(txtRawQty.Text)
                    dg1.SelectedRows(0).Cells(3).Value = txtRawUnit.Text
                    dg1.SelectedRows(0).Cells(4).Value = Val(txtRawRate.Text)
                    dg1.SelectedRows(0).Cells(5).Value = Format(Val(txtRawAmt.Text), "0.00")
                    RawItemClears() : TxtRawItem.Focus() : e.SuppressKeyPress = True : Exit Sub
                Else
                    dg1.Rows.Add(Val(txtRawItemID.Text), TxtRawItem.Text, Val(txtRawQty.Text), txtRawUnit.Text, Val(txtRawRate.Text), Format(Val(txtRawAmt.Text), "0.00"))
                    RawItemClears() : TxtRawItem.Focus() : e.SuppressKeyPress = True : Exit Sub
                End If
            End If
        End If
        If TxtRawItem.Focused Or txtRawQty.Focused Or txtRawRate.Focused Or txtRawAmt.Focused Then
            If e.KeyCode = Keys.Down Then
                If DgRawItem.Visible = True Then DgRawItem.Focus() : Exit Sub
                If dg1.Rows.Count = 0 Then Exit Sub
                dg1.Rows(0).Selected = True : dg1.Focus()
            End If
        End If

        If txtScrapItem.Focused Or txtScrapQty.Focused Or txtScrapRate.Focused Or txtScrapAmt.Focused Then
            If e.KeyCode = Keys.Down Then
                If dgScrap.Visible = True Then dgScrap.Focus() : Exit Sub
                If dg2.Rows.Count = 0 Then Exit Sub
                dg2.Rows(0).Selected = True : dg2.Focus()
            End If
        End If

        If txtCharges.Focused Or txtOnvalue.Focused Or txtCalculatePer.Focused Or txtchargesAmount.Focused Then
            If e.KeyCode = Keys.Down Then
                If dgCharges.Visible = True Then dgCharges.Focus() : Exit Sub
                If dg3.Rows.Count = 0 Then Exit Sub
                dg3.Rows(0).Selected = True : dg3.Focus()
            End If
        End If

        If txtScrapAmt.Focused Then
            If e.KeyCode = Keys.Enter Then
                If Val(txtScrapQty.Text) = 0 Then ScrapItemClears() : txtCharges.Focus() : e.SuppressKeyPress = True : Exit Sub
                If dg2.SelectedRows.Count <> 0 Then
                    dg2.SelectedRows(0).Cells(0).Value = Val(txtScrapID.Text)
                    dg2.SelectedRows(0).Cells(1).Value = txtScrapItem.Text
                    dg2.SelectedRows(0).Cells(2).Value = Val(txtScrapQty.Text)
                    dg2.SelectedRows(0).Cells(3).Value = txtScrapUnit.Text
                    dg2.SelectedRows(0).Cells(4).Value = Val(txtScrapRate.Text)
                    dg2.SelectedRows(0).Cells(5).Value = Format(Val(txtScrapAmt.Text), "0.00")
                    ScrapItemClears() : txtScrapItem.Focus() : e.SuppressKeyPress = True : Exit Sub
                Else
                    dg2.Rows.Add(Val(txtScrapID.Text), txtScrapItem.Text, Val(txtScrapQty.Text), txtScrapUnit.Text, Val(txtScrapRate.Text), Format(Val(txtScrapAmt.Text), "0.00"))
                    ScrapItemClears() : txtScrapItem.Focus() : e.SuppressKeyPress = True : Exit Sub
                End If
            End If
        End If

        If txtchargesAmount.Focused Then
            If e.KeyCode = Keys.Enter Then
                If Val(txtchargesAmount.Text) = 0 Then ChargesClear() : BtnSave.Focus() : e.SuppressKeyPress = True : Exit Sub
                If dg3.SelectedRows.Count <> 0 Then
                    dg3.SelectedRows(0).Cells(0).Value = Val(txtChargeID.Text)
                    dg3.SelectedRows(0).Cells(1).Value = txtCharges.Text
                    dg3.SelectedRows(0).Cells(2).Value = Val(txtOnvalue.Text)
                    dg3.SelectedRows(0).Cells(3).Value = Val(txtCalculatePer.Text)
                    dg3.SelectedRows(0).Cells(4).Value = txtPlusMinus.Text
                    dg3.SelectedRows(0).Cells(5).Value = Format(Val(txtchargesAmount.Text), "0.00")
                    dg3.SelectedRows(0).Cells(6).Value = Format(Val(txtGstperCharge.Text), Hash)
                    dg3.SelectedRows(0).Cells(7).Value = Format(Val(txtGSTAmtCharge.Text), Hash)
                    dg3.SelectedRows(0).Cells(8).Value = Format(Val(txtCessPerCharge.Text), Hash)
                    dg3.SelectedRows(0).Cells(9).Value = Format(Val(txtCessAmtCharge.Text), Hash)
                    dg3.SelectedRows(0).Cells(10).Value = Format(Val(txtChargeTaxable.Text), Hash)
                    ChargesClear() : txtCharges.Focus() : e.SuppressKeyPress = True : Exit Sub
                Else
                    dg3.Rows.Add(Val(txtChargeID.Text), txtCharges.Text, Val(txtOnvalue.Text), Val(txtCalculatePer.Text), txtPlusMinus.Text,
                                 Format(Val(txtchargesAmount.Text), "0.00"), Format(Val(txtGstperCharge.Text), Hash), Format(Val(txtGSTAmtCharge.Text), Hash),
                             Format(Val(txtCessPerCharge.Text), Hash), Format(Val(txtCessAmtCharge.Text), Hash),
                             Format(Val(txtChargeTaxable.Text), Hash))
                    ChargesClear() : txtCharges.Focus() : e.SuppressKeyPress = True : Exit Sub
                End If
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
            e.SuppressKeyPress = True
        End If
        If txtReceipeName.Focused Then
            If e.KeyCode = Keys.F3 Then
                Receipe_Master.MdiParent = MainScreenForm
                Receipe_Master.Show()
                Receipe_Master.BringToFront()
            End If
            If e.KeyCode = Keys.F1 Then
                If Val(txtReceipeID.Text) = 0 Then Exit Sub
                Receipe_Master.MdiParent = MainScreenForm
                Receipe_Master.Show()
                Receipe_Master.FillControls(Val(txtReceipeID.Text))
                Receipe_Master.BringToFront()
            End If
            If e.KeyCode = Keys.Down Then
                dgReceipe.Focus()
            End If
        End If
        If TxtRawItem.Focused Then
            If e.KeyCode = Keys.F3 Then
                Items.MdiParent = MainScreenForm
                Items.Show()
                Items.BringToFront()
            End If
            If e.KeyCode = Keys.F1 Then
                Items.MdiParent = MainScreenForm
                Items.Show()
                Items.FillControls(Val(txtMainItemID.Text))
                Items.BringToFront()
            End If
            If e.KeyCode = Keys.Down Then
                DgRawItem.Focus()
            End If
        End If
        If txtScrapItem.Focused Then
            If e.KeyCode = Keys.F3 Then
                Items.MdiParent = MainScreenForm
                Items.Show()
                Items.BringToFront()
            End If
            If e.KeyCode = Keys.F1 Then
                Items.MdiParent = MainScreenForm
                Items.Show()
                Items.FillControls(Val(txtScrapID.Text))
                Items.BringToFront()
            End If
            If e.KeyCode = Keys.Down Then dgScrap.Focus()
        End If

        If txtCharges.Focused Then
            If e.KeyCode = Keys.F3 Then
                ChargesForm.MdiParent = MainScreenForm
                ChargesForm.Show()
                ChargesForm.BringToFront()
            End If
            If e.KeyCode = Keys.F1 Then
                If Val(txtReceipeID.Text) = 0 Then Exit Sub
                ChargesForm.MdiParent = MainScreenForm
                ChargesForm.Show()
                ChargesForm.FillContros(Val(txtReceipeID.Text))
                ChargesForm.BringToFront()
            End If
            If e.KeyCode = Keys.Down Then
                dgCharges.Focus()
            End If
        End If
    End Sub
    Private Sub DgRawItem_KeyDown(sender As Object, e As KeyEventArgs) Handles DgRawItem.KeyDown
        If e.KeyCode = Keys.Enter Then
            If DgRawItem.SelectedRows.Count = 0 Then Exit Sub
            TxtRawItem.Clear() : txtRawItemID.Clear()
            txtRawItemID.Text = Val(DgRawItem.SelectedRows(0).Cells(0).Value)
            ' lblCode.Text = DgRawItem.SelectedRows(0).Cells(1).Value
            TxtRawItem.Text = DgRawItem.SelectedRows(0).Cells(2).Value
            txtRawUnit.Text = DgRawItem.SelectedRows(0).Cells(3).Value
            DgRawItem.Visible = False : txtRawQty.Focus()
            e.SuppressKeyPress = True
        End If
        If e.KeyCode = Keys.Back Then TxtRawItem.Focus()
        If e.KeyCode = Keys.F3 Then
            Items.MdiParent = MainScreenForm
            Items.Show()
            Items.BringToFront()
        End If
        If e.KeyCode = Keys.F1 Then
            Items.MdiParent = MainScreenForm
            Items.Show()
            Items.FillControls(Val(DgRawItem.SelectedRows(0).Cells(0).Value))
            Items.BringToFront()
        End If
    End Sub

    Private Sub dgMainItem_KeyDown(sender As Object, e As KeyEventArgs) Handles dgReceipe.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgReceipe.SelectedRows.Count = 0 Then Exit Sub
            txtMainItem.Clear() : txtMainItemID.Clear()
            txtReceipeID.Text = Val(dgReceipe.SelectedRows(0).Cells(0).Value)
            txtReceipeName.Text = dgReceipe.SelectedRows(0).Cells(1).Value
            txtMainItemID.Text = Val(dgReceipe.SelectedRows(0).Cells(2).Value)
            txtMainItem.Text = dgReceipe.SelectedRows(0).Cells(3).Value
            lblUnit.Text = dgReceipe.SelectedRows(0).Cells(4).Value
            dgReceipe.Visible = False : txtMainQty.Focus()
            e.SuppressKeyPress = True
        End If
        If e.KeyCode = Keys.F3 Then
            Items.MdiParent = MainScreenForm
            Items.Show()
            Items.BringToFront()
        End If
        If e.KeyCode = Keys.F1 Then
            Items.MdiParent = MainScreenForm
            Items.Show()
            Items.FillControls(Val(dgReceipe.SelectedRows(0).Cells(0).Value))
            Items.BringToFront()
        End If
        If e.KeyCode = Keys.Back Then txtReceipeName.Focus()
    End Sub

    Private Sub dgMainItem_MouseClick(sender As Object, e As MouseEventArgs) Handles dgReceipe.MouseClick
        If dgReceipe.SelectedRows.Count = 0 Then Exit Sub
        txtReceipeID.Text = Val(dgReceipe.SelectedRows(0).Cells(0).Value)
        txtReceipeName.Text = dgReceipe.SelectedRows(0).Cells(1).Value
        txtMainItemID.Text = Val(dgReceipe.SelectedRows(0).Cells(2).Value)
        txtMainItem.Text = dgReceipe.SelectedRows(0).Cells(3).Value
        lblUnit.Text = dgReceipe.SelectedRows(0).Cells(4).Value
        dgReceipe.Visible = False : txtMainQty.Focus()
    End Sub

    Private Sub RawItemRowColumns()
        DgRawItem.ColumnCount = 4
        DgRawItem.Columns(0).Name = "ID" : DgRawItem.Columns(0).Visible = False
        DgRawItem.Columns(1).Name = "Item Code" : DgRawItem.Columns(1).Width = 50
        DgRawItem.Columns(2).Name = "Item Name" : DgRawItem.Columns(2).Width = 300
        DgRawItem.Columns(3).Name = "Unit" : DgRawItem.Columns(3).Width = 100
        retriveMainItems()
    End Sub


    Private Sub ScrapItemRowColumns()
        dgScrap.ColumnCount = 4
        dgScrap.Columns(0).Name = "ID" : dgScrap.Columns(0).Visible = False
        dgScrap.Columns(1).Name = "Item Code" : dgScrap.Columns(1).Width = 50
        dgScrap.Columns(2).Name = "Item Name" : dgScrap.Columns(2).Width = 300
        dgScrap.Columns(3).Name = "Unit" : dgScrap.Columns(3).Width = 100
        retriveScrapItems()
    End Sub

    Private Sub retriveScrapItems(Optional ByVal condtion As String = "")
        dgScrap.Rows.Clear()
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("Select * from items " & condtion & " Limit 20")
        Try
            If dt.Rows.Count > 0 Then
                dgScrap.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dgScrap.Rows.Add()
                    With dgScrap.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("ID").ToString()
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

    Private Sub txtRawItems_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtRawItem.KeyPress
        If Not Char.IsLetterOrDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso e.KeyChar <> "%" AndAlso Not Char.IsControl(e.KeyChar) AndAlso e.KeyChar <> " " Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtRawQty_GotFocus(sender As Object, e As EventArgs) Handles txtRawQty.GotFocus
        If DgRawItem.ColumnCount = 0 Then RawItemRowColumns()
        If DgRawItem.Rows.Count = 0 Then retriveRawItems()
        'If DgRawItem.ColumnCount = 0 Then RawItemRowColumns()
        'If TxtRawItem.Text.Trim() <> "" Then
        '    retriveRawItems(" Where upper(ItemName) Like upper('" & TxtRawItem.Text.Trim() & "%')")
        'Else
        '    retriveRawItems()
        'End If
        If DgRawItem.SelectedRows.Count = 0 Then DgRawItem.Visible = True
        TxtRawItem.Text = DgRawItem.SelectedRows(0).Cells(2).Value
        txtRawUnit.Text = DgRawItem.SelectedRows(0).Cells(3).Value
        DgRawItem.Visible = False : txtRawQty.Focus()
    End Sub

    Private Sub txtRawItems_KeyUp(sender As Object, e As KeyEventArgs) Handles TxtRawItem.KeyUp
        If DgRawItem.ColumnCount = 0 Then ItemRowColumns()
        If TxtRawItem.Text.Trim() <> "" Then
            DgRawItem.Visible = True : DgRawItem.BringToFront()
            retriveRawItems(" Where upper(ItemName) Like upper('%" & TxtRawItem.Text.Trim() & "%') or upper(ItemCode)  Like upper('" & TxtRawItem.Text.Trim() & "%') ")
        Else
            retriveRawItems()
        End If
        If e.KeyCode = Keys.Escape Then DgRawItem.Visible = False
    End Sub


    Private Sub retriveRawItems(Optional ByVal condtion As String = "")
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("Select ID,ItemCode,ItemName,TableRate,RatePer from Item_View " & condtion & " order by ItemCode,ItemName liMIT 20")
        Try
            If dt.Rows.Count > 0 Then
                DgRawItem.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    DgRawItem.Rows.Add()
                    With DgRawItem.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("ID").ToString()
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
    Private Sub txtRawItems_GotFocus(sender As Object, e As EventArgs) Handles TxtRawItem.GotFocus
        dgReceipe.Visible = False : dgScrap.Visible = False : ScrapItemClears()
        If DgRawItem.ColumnCount = 0 Then RawItemRowColumns()
        If TxtRawItem.Text.Trim() <> "" Then
            retriveRawItems(" Where upper(ItemName) Like upper('" & TxtRawItem.Text.Trim() & "%')")
        Else
            retriveRawItems()
        End If
    End Sub

    Private Sub txtMainQty_LostFocus(sender As Object, e As EventArgs) Handles txtMainQty.LostFocus
        If Val(txtMainQty.Text) <= 0 Then txtMainQty.Focus() : txtMainQty.BackColor = Color.Orange : Exit Sub
        RetriveRecepie()
    End Sub

    Private Sub txtReceipeName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtReceipeName.KeyPress
        dgReceipe.Visible = True : dgReceipe.BringToFront()
    End Sub

    Private Sub txtReceipeName_KeyUp(sender As Object, e As KeyEventArgs) Handles txtReceipeName.KeyUp
        If dgReceipe.ColumnCount = 0 Then ItemRowColumns()
        If txtMainItem.Text.Trim() <> "" Then
            dgReceipe.Visible = True : dgReceipe.BringToFront()
            retriveMainItems(" Where upper(ReceipeName) Like upper('%" & txtReceipeName.Text.Trim() & "%')")
        Else
            retriveMainItems()
        End If
        If e.KeyCode = Keys.Escape Then dgReceipe.Visible = False
    End Sub

    Private Sub mskEntryDate_LostFocus(sender As Object, e As EventArgs) Handles mskEntryDate.LostFocus
        mskEntryDate.BackColor = Color.GhostWhite
    End Sub


    Private Sub txtScrapItem_GotFocus(sender As Object, e As EventArgs) Handles txtScrapItem.GotFocus
        dgCharges.Visible = False : ChargesClear() : DgRawItem.Visible = False : RawItemClears() : dgReceipe.Visible = False
        If dgScrap.ColumnCount = 0 Then ScrapItemRowColumns()
        If txtScrapItem.Text.Trim() <> "" Then
            retriveScrapItems(" Where upper(ItemName) Like upper('" & txtScrapItem.Text.Trim() & "%')")
        Else
            retriveScrapItems()
        End If
    End Sub


    Private Sub txtScrapItem_KeyUp(sender As Object, e As KeyEventArgs) Handles txtScrapItem.KeyUp
        If dgScrap.ColumnCount = 0 Then ScrapItemRowColumns()
        If txtMainItem.Text.Trim() <> "" Then
            dgScrap.Visible = True : dgScrap.BringToFront()
            retriveScrapItems(" Where upper(ItemName) Like upper('%" & txtScrapItem.Text.Trim() & "%')")
        Else
            retriveScrapItems()
        End If
        If e.KeyCode = Keys.Escape Then dgScrap.Visible = False
    End Sub

    Private Sub txtScrapItem_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtScrapItem.KeyPress
        If Not Char.IsLetterOrDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso e.KeyChar <> "%" AndAlso Not Char.IsControl(e.KeyChar) AndAlso e.KeyChar <> " " Then
            e.Handled = True
        End If
    End Sub

    Private Sub dgScrap_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgScrap.CellClick
        If dgScrap.SelectedRows.Count = 0 Then Exit Sub
        txtScrapItem.Clear() : txtScrapID.Clear()
        txtScrapID.Text = Val(dgScrap.SelectedRows(0).Cells(0).Value)
        ' lblCode.Text = DgRawItem.SelectedRows(0).Cells(1).Value
        txtScrapItem.Text = dgScrap.SelectedRows(0).Cells(2).Value
        txtScrapUnit.Text = dgScrap.SelectedRows(0).Cells(3).Value
        DgRawItem.Visible = False : txtScrapQty.Focus()
    End Sub

    Private Sub dgScrap_KeyDown(sender As Object, e As KeyEventArgs) Handles dgScrap.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgScrap.SelectedRows.Count = 0 Then Exit Sub
            txtScrapItem.Clear() : txtScrapID.Clear()
            txtScrapID.Text = Val(dgScrap.SelectedRows(0).Cells(0).Value)
            ' lblCode.Text = DgRawItem.SelectedRows(0).Cells(1).Value
            txtScrapItem.Text = dgScrap.SelectedRows(0).Cells(2).Value
            txtScrapUnit.Text = dgScrap.SelectedRows(0).Cells(3).Value
            DgRawItem.Visible = False : txtScrapQty.Focus()
            e.SuppressKeyPress = True
        End If
        If e.KeyCode = Keys.Back Then txtScrapItem.Focus()
        If e.KeyCode = Keys.F3 Then
            Items.MdiParent = MainScreenForm
            Items.Show()
            Items.BringToFront()
        End If
        If e.KeyCode = Keys.F1 Then
            Items.MdiParent = MainScreenForm
            Items.Show()
            Items.FillControls(Val(dgScrap.SelectedRows(0).Cells(0).Value))
            Items.BringToFront()
        End If
    End Sub

    Private Sub txtRawQty_TextChanged(sender As Object, e As EventArgs) Handles txtRawQty.TextChanged, txtRawRate.TextChanged
        txtRawAmt.Text = Format(Val(txtRawQty.Text) * Val(txtRawRate.Text), "0.00")
    End Sub

    Private Sub txtScrapQty_TextChanged(sender As Object, e As EventArgs) Handles txtScrapQty.TextChanged, txtScrapRate.TextChanged
        txtScrapAmt.Text = Format(Val(txtScrapQty.Text) * Val(txtScrapRate.Text), "0.00")
    End Sub
    Private Sub dgCharges_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCharges.CellClick
        txtCharges.Clear() : txtChargeID.Clear()
        txtChargeID.Text = dgCharges.SelectedRows(0).Cells(0).Value
        txtCharges.Text = dgCharges.SelectedRows(0).Cells(1).Value
        dgCharges.Visible = False : txtOnvalue.Focus()
        FillCharges()
    End Sub
    Private Sub FillCharges()
        CalcType = clsFun.ExecScalarStr(" Select ApplyType FROM Charges WHERE ID='" & Val(txtChargeID.Text) & "'")
        txtPlusMinus.Text = clsFun.ExecScalarStr(" Select ChargesType FROM Charges WHERE ID='" & Val(txtChargeID.Text) & "'")
        txtCalculatePer.Text = clsFun.ExecScalarStr(" Select Calculate FROM Charges WHERE ID='" & Val(txtChargeID.Text) & "'")
        Dim ApplyOn As String = clsFun.ExecScalarStr(" Select ApplyOn FROM Charges WHERE ID='" & Val(txtChargeID.Text) & "'")
        If clsFun.ExecScalarInt(" Select TaxID FROM Charges WHERE ID='" & Val(txtChargeID.Text) & "'") > 0 Then pnlGSTCharges.BringToFront() : pnlGSTCharges.Visible = True Else pnlGSTCharges.Visible = False
        If CalcType = "Aboslute" Then
            txtOnvalue.TabStop = False
            txtCalculatePer.TabStop = False
            txtOnvalue.Text = ""
            txtchargesAmount.Focus()
        ElseIf CalcType = "Weight" Then
            txtOnvalue.Text = txtTotTaxable.Text
            txtOnvalue.TabStop = True
            txtCalculatePer.TabStop = True
        ElseIf CalcType = "Percentage" Then
            If ApplyOn = "Taxable Amount" Then
                txtOnvalue.Text = txtTotTaxable.Text
            ElseIf ApplyOn = "Tax Amount" Then
                txtOnvalue.Text = Val(txtTotTaxable.Text)
            ElseIf ApplyOn = "Item Total" Then
                txtOnvalue.Text = Val(txtTotQty.Text)
            ElseIf ApplyOn = "Total Amount" Then
                txtOnvalue.Text = Val(txtTotTaxable.Text)
            ElseIf ApplyOn = "Tax Amount" Then
                txtOnvalue.Text = txtTotTaxable.Text
            End If
            txtOnvalue.TabStop = True
            txtCalculatePer.TabStop = True
            txtOnvalue.Focus()
        ElseIf CalcType = "Qty" Then
            txtOnvalue.Text = Val(txtTotQty.Text)
            txtOnvalue.TabStop = True
            txtCalculatePer.TabStop = True
        End If
    End Sub

    Private Sub txtCharges_KeyUp(sender As Object, e As KeyEventArgs) Handles txtCharges.KeyUp
        ChargesRowColums()
        If txtCharges.Text.Trim() <> "" Then
            RetriveCharges(" Where upper(ChargeName) Like upper('" & txtCharges.Text.Trim() & "%')")
        End If
        If e.KeyCode = Keys.Escape Then dgCharges.Visible = False
    End Sub

    Private Sub txtCharges_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCharges.KeyPress
        e.Handled = (e.KeyChar = "'") Or (e.KeyChar = """")
        dgCharges.Visible = True
    End Sub

    Private Sub txtCharges_GotFocus(sender As Object, e As EventArgs) Handles txtCharges.GotFocus
        dgReceipe.Visible = False : DgRawItem.Visible = False : dgScrap.Visible = False
        If dgCharges.ColumnCount = 0 Then ChargesRowColums()
        If dgCharges.RowCount = 0 Then RetriveCharges()
        If txtCharges.Text.Trim() <> "" Then
            RetriveCharges(" Where upper(ChargeName) Like upper('" & txtCharges.Text.Trim() & "%')")
        Else
            RetriveCharges()
        End If
        If dgCharges.SelectedRows.Count = 0 Then dgCharges.Visible = True
    End Sub

    Private Sub dgCharges_KeyDown(sender As Object, e As KeyEventArgs) Handles dgCharges.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgCharges.SelectedRows.Count = 0 Then Exit Sub
            txtCharges.Clear() : txtChargeID.Clear()
            txtCharges.Text = dgCharges.SelectedRows(0).Cells(1).Value
            txtChargeID.Text = Val(dgCharges.SelectedRows(0).Cells(0).Value)
            dgCharges.Visible = False : FillCharges() : e.SuppressKeyPress = True
        End If
        If e.KeyCode = Keys.F3 Then
            ChargesForm.MdiParent = MainScreenForm
            ChargesForm.Show()
            ChargesForm.BringToFront()
        End If
        If e.KeyCode = Keys.F1 Then
            ChargesForm.MdiParent = MainScreenForm
            ChargesForm.Show()
            ChargesForm.FillContros(Val(dgReceipe.SelectedRows(0).Cells(0).Value))
            ChargesForm.BringToFront()
        End If
        If e.KeyCode = Keys.Back Then txtCharges.Focus()
    End Sub

    Private Sub dg1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg1.CellClick
        dg1.ClearSelection()
    End Sub

    Private Sub dg1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg1.CellDoubleClick
        If dg1.SelectedRows.Count = 0 Then Exit Sub
        txtRawItemID.Text = Val(dg1.SelectedRows(0).Cells(0).Value)
        TxtRawItem.Text = dg1.SelectedRows(0).Cells(1).Value
        txtRawQty.Text = dg1.SelectedRows(0).Cells(2).Value
        txtRawUnit.Text = dg1.SelectedRows(0).Cells(3).Value
        txtRawRate.Text = dg1.SelectedRows(0).Cells(4).Value
        txtRawAmt.Text = dg1.SelectedRows(0).Cells(5).Value
        TxtRawItem.Focus()
    End Sub

    Private Sub dg1_KeyDown(sender As Object, e As KeyEventArgs) Handles dg1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dg1.SelectedRows.Count = 0 Then Exit Sub
            txtRawItemID.Text = Val(dg1.SelectedRows(0).Cells(0).Value)
            TxtRawItem.Text = dg1.SelectedRows(0).Cells(1).Value
            txtRawQty.Text = dg1.SelectedRows(0).Cells(2).Value
            txtRawUnit.Text = dg1.SelectedRows(0).Cells(3).Value
            txtRawRate.Text = dg1.SelectedRows(0).Cells(4).Value
            txtRawAmt.Text = dg1.SelectedRows(0).Cells(5).Value
            TxtRawItem.Focus() : e.SuppressKeyPress = True
        End If
        If e.KeyCode = Keys.Up Then
            If dg1.SelectedRows.Count = 0 Then Exit Sub
            If Val(dg1.SelectedRows(0).Index) = 0 Then TxtRawItem.Focus()
            dg1.ClearSelection()
        End If
        If e.KeyCode = Keys.Down Then
            If dg1.SelectedRows.Count = 0 Then Exit Sub
            If Val(dg1.SelectedRows(0).Index) = Val(dg1.Rows.Count - 1) Then dg1.Rows(0).Selected = True
        End If
        If e.KeyCode = Keys.Delete Then
            If dg1.SelectedRows.Count = 0 Then Exit Sub
            If MessageBox.Show("Are you Sure to delete Raw Item", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                dg1.Rows.Remove(dg1.SelectedRows(0)) : Calc() : TxtRawItem.Focus() : dg1.ClearSelection()
            End If
        End If
    End Sub

    Private Sub txtchargesAmount_KeyUp(sender As Object, e As KeyEventArgs) Handles txtchargesAmount.KeyUp, txtOnvalue.KeyUp, txtCalculatePer.KeyUp
        ChargesCalculation()
    End Sub

    Private Sub dg2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg2.CellClick
        dg2.ClearSelection()
    End Sub

    Private Sub dg2_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg2.CellDoubleClick
        If dg2.SelectedRows.Count = 0 Then Exit Sub
        txtScrapID.Text = Val(dg2.SelectedRows(0).Cells(0).Value)
        txtScrapItem.Text = dg2.SelectedRows(0).Cells(1).Value
        txtScrapQty.Text = dg2.SelectedRows(0).Cells(2).Value
        txtScrapUnit.Text = dg2.SelectedRows(0).Cells(3).Value
        txtScrapRate.Text = dg2.SelectedRows(0).Cells(4).Value
        txtScrapAmt.Text = dg2.SelectedRows(0).Cells(5).Value
        txtScrapItem.Focus()
    End Sub

    Private Sub dg2_KeyDown(sender As Object, e As KeyEventArgs) Handles dg2.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dg2.SelectedRows.Count = 0 Then Exit Sub
            txtScrapID.Text = Val(dg2.SelectedRows(0).Cells(0).Value)
            txtScrapItem.Text = dg2.SelectedRows(0).Cells(1).Value
            txtScrapQty.Text = dg2.SelectedRows(0).Cells(2).Value
            txtScrapUnit.Text = dg2.SelectedRows(0).Cells(3).Value
            txtScrapRate.Text = dg2.SelectedRows(0).Cells(4).Value
            txtScrapAmt.Text = dg2.SelectedRows(0).Cells(5).Value
            txtScrapItem.Focus() : e.SuppressKeyPress = True
        End If
        If e.KeyCode = Keys.Up Then
            If dg2.SelectedRows.Count = 0 Then Exit Sub
            If Val(dg2.SelectedRows(0).Index) = 0 Then txtScrapItem.Focus()
            dg2.ClearSelection()
        End If
        If e.KeyCode = Keys.Down Then
            If dg2.SelectedRows.Count = 0 Then Exit Sub
            If Val(dg2.SelectedRows(0).Index) = Val(dg2.Rows.Count - 1) Then dg2.Rows(0).Selected = True
        End If
        If e.KeyCode = Keys.Delete Then
            If dg2.SelectedRows.Count = 0 Then Exit Sub
            If MessageBox.Show("Are you Sure to delete Scrap Item", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                dg2.Rows.Remove(dg2.SelectedRows(0)) : Calc() : txtScrapItem.Focus() : dg2.ClearSelection()
            End If
        End If
    End Sub

    Private Sub dg3_KeyDown(sender As Object, e As KeyEventArgs) Handles dg3.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dg3.SelectedRows.Count = 0 Then Exit Sub
            txtChargeID.Text = Val(dg3.SelectedRows(0).Cells(0).Value)
            txtCharges.Text = dg3.SelectedRows(0).Cells(1).Value
            txtOnvalue.Text = Val(dg3.SelectedRows(0).Cells(2).Value)
            txtCalculatePer.Text = Val(dg3.SelectedRows(0).Cells(3).Value)
            txtPlusMinus.Text = dg3.SelectedRows(0).Cells(4).Value
            txtchargesAmount.Text = Val(dg3.SelectedRows(0).Cells(5).Value)
            txtCharges.Focus() : e.SuppressKeyPress = True
        End If
        If e.KeyCode = Keys.Up Then
            If dg3.SelectedRows.Count = 0 Then Exit Sub
            If Val(dg3.SelectedRows(0).Index) = 0 Then txtScrapItem.Focus()
            dg3.ClearSelection()
        End If
        If e.KeyCode = Keys.Down Then
            If dg3.SelectedRows.Count = 0 Then Exit Sub
            If Val(dg3.SelectedRows(0).Index) = Val(dg3.Rows.Count - 1) Then dg3.Rows(0).Selected = True
        End If
        If e.KeyCode = Keys.Delete Then
            If dg3.SelectedRows.Count = 0 Then Exit Sub
            If MessageBox.Show("Are you Sure to delete Scrap Item", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                dg3.Rows.Remove(dg3.SelectedRows(0)) : Calc() : txtCharges.Focus() : dg3.ClearSelection()
            End If
        End If

    End Sub
    Private Sub ClearAll()
        RawItemClears() : ScrapItemClears()
        ChargesClear() : dg1.Rows.Clear()
        dg2.Rows.Clear() : dg3.Rows.Clear()
        VNumber() : BtnSave.Text = "&save"
        mskEntryDate.Focus()

    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If BtnSave.Text = "&Save" Then Save() Else Update()
        ClearAll()
    End Sub
    Private Sub Update()
        Dim UnitID As Integer = clsFun.ExecScalarInt("Select ID From ItemUnits Where Upper(MainUnit)=Upper('" & lblUnit.Text & "')")
        Dim sql As String = String.Empty
        sql = "Update Vouchers set TransType='" & Me.Text & "',EntryDate='" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "', " & _
              "InvoiceID='" & Val(txtInvoiceID.Text) & "',InvoiceNo='" & txtBillNo.Text & "',ProcessID='" & Val(txtReceipeID.Text) & "', " & _
              "ProcessName='" & txtReceipeName.Text & "',ItemID='" & Val(txtMainItemID.Text) & "',ItemName='" & txtMainItem.Text & "', " & _
              "UnitID='" & Val(UnitID) & "',UnitName='" & lblUnit.Text & "',SubType='" & Me.Text & "',TotQty='" & Val(txtMainQty.Text) & "' Where ID='" & Val(txtID.Text) & "'"
        If clsFun.ExecNonQuery(sql) > 0 Then
            clsFun.ExecNonQuery("Delete From Trans Where VoucherID='" & Val(txtID.Text) & "';Delete From ChargesTrans Where VoucherID='" & Val(txtID.Text) & "';")
            clsFun.ExecScalarStr("INSERT INTO Trans (VoucherID,TransType,EntryDate,ItemID,ItemName,Qty,AltQty,UnitID,UnitName,Rate,Per,BasicAmt) Select " & _
                                "'" & Val(txtID.Text) & "','Finished Goods','" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "','" & Val(txtMainItemID.Text) & "', " & _
                                "'" & txtMainItem.Text & "','" & Val(txtMainQty.Text) & "','" & Val(txtMainQty.Text) & "','" & Val(UnitID) & "', " & _
                                "'" & lblUnit.Text & "','" & Val(Val(lblTotAllocationCost.Text) / Val(txtMainQty.Text)) & "','" & lblUnit.Text & "','" & Val(lblTotAllocationCost.Text) & "'")
            Dg1Record() : Dg2Record() : dg3Record()
            MsgBox("Production Record Updated Successfully.", vbInformation.Information, "Updated")
        End If
    End Sub
    Private Sub Save()
        Dim UnitID As Integer = clsFun.ExecScalarInt("Select ID From ItemUnits Where Upper(MainUnit)=Upper('" & lblUnit.Text & "')")
        Dim sql As String = String.Empty
        sql = "Insert Into Vouchers(TransType,EntryDate,InvoiceID,InvoiceNo,ProcessID,ProcessName,ItemID,ItemName,UnitID,UnitName,SubType,TotQty) " _
            & " Select '" & Me.Text & "','" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "','" & Val(txtInvoiceID.Text) & "','" & txtBillNo.Text & "'," _
            & " '" & Val(txtReceipeID.Text) & "','" & txtReceipeName.Text & "','" & Val(txtMainItemID.Text) & "','" & txtMainItem.Text & "','" & Val(UnitID) & "'," _
            & " '" & lblUnit.Text & "','" & Me.Text & "','" & Val(txtMainQty.Text) & "'"
        If clsFun.ExecNonQuery(sql) > 0 Then
            txtID.Text = clsFun.ExecScalarInt("Select Max(ID) From Vouchers")
            clsFun.ExecScalarStr("INSERT INTO Trans (VoucherID,TransType,EntryDate,ItemID,ItemName,Qty,AltQty,UnitID,UnitName,Rate,Per,BasicAmt) Select " & _
                                 "'" & Val(txtID.Text) & "','Finished Goods','" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "','" & Val(txtMainItemID.Text) & "', " & _
                                 "'" & txtMainItem.Text & "','" & Val(txtMainQty.Text) & "','" & Val(txtMainQty.Text) & "','" & Val(UnitID) & "', " & _
                                 "'" & lblUnit.Text & "','" & Val(Val(lblTotAllocationCost.Text) / Val(txtMainQty.Text)) & "','" & lblUnit.Text & "','" & Val(lblTotAllocationCost.Text) & "'")
            Dg1Record() : Dg2Record() : dg3Record()
            MsgBox("Production Record Saved Successfully.", vbInformation.Information, "Saved")
        End If
    End Sub

    Private Sub Dg1Record()
        Dim sql As String = String.Empty
        Dim FastQuery As String = String.Empty
        For Each row As DataGridViewRow In dg1.Rows
            With row
                Dim UnitID As Integer = clsFun.ExecScalarInt("Select ID From ItemUnits Where upper(MainUnit)=upper('" & .Cells(3).Value & "')")
                If Val(.Cells("ID").Value) <> 0 Then
                    FastQuery = FastQuery & IIf(FastQuery <> "", " UNION ALL SELECT ", " SELECT ") & "'" & Val(txtID.Text) & "'," & _
                         "'Raw Item','" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "','" & Val(.Cells(0).Value) & "','" & .Cells(1).Value & "'," & _
                         "'" & Val(.Cells(2).Value) & "','" & Val(.Cells(2).Value) & "','" & UnitID & "','" & .Cells(3).Value & "','" & Val(.Cells(4).Value) & "', " & _
                         "'" & .Cells(3).Value & "','" & Val(.Cells(5).Value) & "'"
                End If
            End With
        Next
        If FastQuery = "" Then Exit Sub
        sql = "INSERT INTO Trans (VoucherID,TransType,EntryDate,ItemID,ItemName,Qty,AltQty,UnitID,UnitName,Rate,Per,BasicAmt) " & FastQuery & ""
        Try
            clsFun.ExecNonQuery(Sql)
        Catch ex As Exception
            MsgBox(ex.Message)
            clsFun.CloseConnection()
        End Try
        clsFun.CloseConnection()
    End Sub

    Private Sub Dg2Record()
        Dim sql As String = String.Empty
        Dim FastQuery As String = String.Empty
        For Each row As DataGridViewRow In dg2.Rows
            With row
                Dim UnitID As Integer = clsFun.ExecScalarInt("Select ID From ItemUnits Where Upper(MainUnit)=Upper('" & .Cells(3).Value & "')")
                If Val(.Cells("ID").Value) <> 0 Then
                    FastQuery = FastQuery & IIf(FastQuery <> "", " UNION ALL SELECT ", " SELECT ") & "'" & Val(txtID.Text) & "'," & _
                         "'Scrap Item','" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "','" & Val(.Cells(0).Value) & "','" & .Cells(1).Value & "'," & _
                         "'" & Val(.Cells(2).Value) & "','" & Val(.Cells(2).Value) & "','" & UnitID & "','" & .Cells(3).Value & "','" & Val(.Cells(4).Value) & "', " & _
                         "'" & .Cells(3).Value & "','" & Val(.Cells(5).Value) & "'"
                End If
            End With
        Next
        If FastQuery = "" Then Exit Sub
        sql = "INSERT INTO Trans (VoucherID,TransType,EntryDate,ItemID,ItemName,Qty,AltQty,UnitID,UnitName,Rate,Per,BasicAmt) " & FastQuery & ""
        Try
            clsFun.ExecNonQuery(sql)
        Catch ex As Exception
            MsgBox(ex.Message)
            clsFun.CloseConnection()
        End Try
        clsFun.CloseConnection()
    End Sub

    Private Sub deleteBill()
        If MessageBox.Show("Are you Sure want to Delete Invoice No : " & txtBillNo.Text & " ??", "DELETE", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            If clsFun.ExecNonQuery("Delete From Vouchers Where ID='" & Val(txtID.Text) & "'; " & _
                                   "Delete From Trans Where VoucherID='" & Val(txtID.Text) & "'; " & _
                                   "Delete From ChargesTrans Where VoucherID='" & Val(txtID.Text) & "';") Then
                MsgBox("Record Deleted Successfully...", vbInformation.Information, "Deleted")
                ClearAll()
            End If
        End If
    End Sub

    Private Sub dg3Record()
        Dim FastQuery As String = String.Empty
        Dim Sql As String = String.Empty
        For Each row As DataGridViewRow In dg3.Rows
            With row
                Dim TaxID As Integer = clsFun.ExecScalarInt("SELECT T.ID as TaxID  FROM Charges AS C INNER JOIN Taxation AS T ON C.TaxID = T.Id Where C.ID='" & Val(.Cells(5).Value) & "'")
                Dim TaxName As String = clsFun.ExecScalarStr("SELECT T.TaxName as TaxName  FROM Charges AS C INNER JOIN Taxation AS T ON C.TaxID = T.Id Where C.ID='" & Val(.Cells(5).Value) & "'")
                Dim FixAs As String = clsFun.ExecScalarStr(" Select FixAs FROM Charges WHERE ID='" & Val(dg3.Rows(i).Cells(0).Value) & "'")
                Dim taxableCharges As Decimal = Format(Val(.Cells(5).Value) + Val(.Cells(11).Value), Hash)
                If .Cells(4).Value = "+" Then
                    If .Cells("Charge Name").Value <> "" Then
                        FastQuery = FastQuery & IIf(FastQuery <> "", " UNION ALL SELECT ", " SELECT ") & Val(txtID.Text) & "," & _
                            "'" & Val(.Cells("ChargeID").Value) & "','" & .Cells("Charge Name").Value & "','" & .Cells("On Value").Value & "'," & _
                            "'" & .Cells("Cal").Value & "','" & .Cells("+/-").Value & "','" & .Cells("Amount").Value & "','" & TaxID & "','" & TaxName & "', " & _
                            "'" & Val(.Cells(6).Value) & "' ,'" & IIf(TaxID = 0, 0, (Val(.Cells(7).Value))) & "','" & If(TaxID = 0, 0, Val(.Cells(10).Value)) & "', " & _
                            "'" & IIf(TaxID = 0, 0, (IIf(lblRegion.Text = "Local", 0, Val(.Cells(6).Value)))) & "','" & IIf(TaxID = 0, 0, (IIf(lblRegion.Text = "Local", 0, Val(.Cells(7).Value)))) & "', " & _
                            "'" & IIf(TaxID = 0, 0, (IIf(lblRegion.Text = "Local", Val(.Cells(6).Value) / 2, 0))) & "','" & IIf(TaxID = 0, 0, (IIf(lblRegion.Text = "Local", Val(.Cells(7).Value) / 2, 0))) & "', " & _
                            "'" & IIf(TaxID = 0, 0, (IIf(lblRegion.Text = "Local", Val(.Cells(6).Value) / 2, 0))) & "', " & _
                            "'" & IIf(TaxID = 0, 0, (IIf(lblRegion.Text = "Local", Val(.Cells(7).Value) / 2, 0))) & "'," & 0 & "," & 0 & ",'" & FixAs & "','" & Val(.Cells(11).Value) & "'"
                    End If
                ElseIf .Cells(4).Value = "-" Then
                    If .Cells("Charge Name").Value <> "" Then
                        FastQuery = FastQuery & IIf(FastQuery <> "", " UNION ALL SELECT ", " SELECT ") & Val(txtID.Text) & "," & _
                            "'" & Val(.Cells("ChargeID").Value) & "','" & .Cells("Charge Name").Value & "','" & .Cells("On Value").Value & "'," & _
                            "'" & .Cells("Cal").Value & "','" & .Cells("+/-").Value & "','" & Val(.Cells("Amount").Value) & "','" & TaxID & "','" & TaxName & "', " & _
                            "'" & Val(.Cells(6).Value) & "' ,'" & IIf(TaxID = 0, 0, -(Val(.Cells(7).Value))) & "','" & If(TaxID = 0, 0, -Val(.Cells(10).Value)) & "', " & _
                            "'" & IIf(TaxID = 0, 0, (IIf(lblRegion.Text = "Local", 0, Val(.Cells(6).Value)))) & "','" & IIf(TaxID = 0, 0, (IIf(lblRegion.Text = "Local", 0, -Val(.Cells(7).Value)))) & "', " & _
                            "'" & IIf(TaxID = 0, 0, (IIf(lblRegion.Text = "Local", Val(.Cells(6).Value) / 2, 0))) & "','" & IIf(TaxID = 0, 0, (IIf(lblRegion.Text = "Local", -Val(.Cells(7).Value) / 2, 0))) & "', " & _
                            "'" & IIf(TaxID = 0, 0, (IIf(lblRegion.Text = "Local", Val(.Cells(6).Value) / 2, 0))) & "', " & _
                            "'" & IIf(TaxID = 0, 0, (IIf(lblRegion.Text = "Local", -Val(.Cells(7).Value) / 2, 0))) & "'," & 0 & "," & 0 & ",'" & FixAs & "','" & Val(.Cells(11).Value) & "'"
                    End If
                End If
            End With
        Next
        Try
            Sql = "insert into ChargesTrans(VoucherID, ChargesID, ChargeName, OnValue, Calculate, ChargeType,  " & _
                  "Amount,TaxID,TaxName,TaxPer,TaxAmt,TaxableAmt,IGSTPer,IGSTAmt,SGSTPer,SGSTAmt,CGSTPer,CGSTAmt, " & _
                  "CessPer,CessAmt,FixAs,AppValue)" & FastQuery & ""
            If FastQuery = String.Empty Then Exit Sub
            clsFun.ExecNonQuery(Sql)
        Catch ex As Exception
            MsgBox(ex.Message)
            clsFun.CloseConnection()
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        deleteBill()
    End Sub
End Class
