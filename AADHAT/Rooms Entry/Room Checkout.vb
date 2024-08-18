Public Class Room_Checkout
    Private headerCheckBox As CheckBox = New CheckBox()
    Private Sub Room_Checkout_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If pnlVAS.Visible = True Then
                pnlVAS.Visible = False
                lblVAStotal.Focus()
                Exit Sub
            End If
            If pnlRoomDetails.Visible = True Then
                pnlRoomDetails.Visible = False
                txtTotalRoomRent.Focus()
                Exit Sub
            End If
            If pnlCreditBalance.Visible = True Then
                pnlCreditBalance.Visible = False
                txtTotalCash.Focus()
                Exit Sub
            End If
        End If
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub Room_Checkout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Application.DoEvents()
        Me.Top = 0 : Me.Left = 0
        cbSeries.SelectedIndex = 0
        cbGSTType.SelectedIndex = 0
        clsFun.FillDropDownList(cbCheckinDetails, "Select ID, InvoiceNo ||' : '|| CustomerName ||' : '|| RoomNos as CustomerDetails From Vouchers Where isBooked IS Null and TransType='Check In' ", "CustomerDetails", "Id", "")
        mskEntryDate.Text = Date.Today.ToString("dd-MM-yyyy") : mskCheckinDate.Text = Date.Today.ToString("dd-MM-yyyy")
        mskCheckOutDate.Text = Date.Today.ToString("dd-MM-yyyy") : dtpCheckinTime.Text = TimeOfDay.ToString("HH:mm tt")
        dtpCheckoutTime.Text = TimeOfDay.ToString("HH:mm tt") : Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True : dg1Columns() : VNumber()
    End Sub
    Private Sub txtClear()
        VNumber() : txtGuestName.Clear() : txtRemark.Clear()
        txtMobileNo.Clear() : txtGSTN.Clear()
        txtRoomNos.Clear() : txtStayDays.Clear()
        txtTotalRoomRate.Clear() : txtTotalRoomRent.Clear()
        txttotalFoodCharges.Clear() : txtTotalVasCharges.Clear()
        txtOtherCharges.Clear() : txtTotalTaxAmt.Clear()
        txtTotalBasicAmt.Clear() : txtTotalAdvance.Clear()
        txtTotalRoundOff.Clear() : TxtTotalAmount.Clear()
        txtTotalCash.Clear() : txtTotalChangeAmt.Clear()
        txtCardPayment.Clear() : txtRefNo.Clear()
        cbBank.SelectedIndex = -1 : txtRemark2.Clear()
        lblFoodTax.Text = "0.00" : lblFoodTaxable.Text = "0.00"
        lblVAStotal.Text = "0.00" : lblVASTaxtotal.Text = "0.00"
        lblRoomRentDisc.Text = "0.00" : lblRoomRentTax.Text = "0.00"
        lblRoomRentTaxable.Text = "0.00"
        dg1.Rows.Clear() : dgVas.Rows.Clear()
        dgRoom.Rows.Clear() : BtnSave.Text = "&Save"
    End Sub
    Private Sub TempRowColumn()
        tempdt.ColumnCount = 77
        tempdt.Columns(0).Name = "ID" : tempdt.Columns(0).Width = 30
        tempdt.Columns(1).Name = "TransType" : tempdt.Columns(1).Width = 30
        tempdt.Columns(2).Name = "InvoiceNo" : tempdt.Columns(2).Width = 30
        tempdt.Columns(3).Name = "EntryDate" : tempdt.Columns(3).Width = 30
        tempdt.Columns(4).Name = "PackageName" : tempdt.Columns(4).Width = 30
        tempdt.Columns(5).Name = "Title" : tempdt.Columns(5).Width = 30
        tempdt.Columns(6).Name = "CustomerName" : tempdt.Columns(6).Width = 30
        tempdt.Columns(7).Name = "CustomerMobile" : tempdt.Columns(7).Width = 30
        tempdt.Columns(8).Name = "Gender" : tempdt.Columns(8).Width = 30
        tempdt.Columns(9).Name = "Nationality" : tempdt.Columns(9).Width = 30
        tempdt.Columns(10).Name = "CHeckINDate" : tempdt.Columns(10).Width = 30
        tempdt.Columns(11).Name = "CheckinTime" : tempdt.Columns(11).Width = 30
        tempdt.Columns(12).Name = "CHeckOutDate" : tempdt.Columns(12).Width = 30
        tempdt.Columns(13).Name = "CheckOutTime" : tempdt.Columns(13).Width = 30
        tempdt.Columns(14).Name = "StayDays" : tempdt.Columns(14).Width = 30
        tempdt.Columns(15).Name = "Male" : tempdt.Columns(15).Width = 30
        tempdt.Columns(16).Name = "Female" : tempdt.Columns(16).Width = 30
        tempdt.Columns(17).Name = "Kids" : tempdt.Columns(17).Width = 30
        tempdt.Columns(18).Name = "CompanyName" : tempdt.Columns(18).Width = 30
        tempdt.Columns(19).Name = "CompanyContact" : tempdt.Columns(19).Width = 30
        tempdt.Columns(20).Name = "CompanyAdd" : tempdt.Columns(20).Width = 30
        tempdt.Columns(21).Name = "Email" : tempdt.Columns(21).Width = 30
        tempdt.Columns(22).Name = "Website" : tempdt.Columns(22).Width = 30
        tempdt.Columns(23).Name = "BusinessSourceName" : tempdt.Columns(23).Width = 30
        tempdt.Columns(24).Name = "DocumentType" : tempdt.Columns(24).Width = 30
        tempdt.Columns(25).Name = "DocumentNo" : tempdt.Columns(25).Width = 30
        tempdt.Columns(26).Name = "Remark" : tempdt.Columns(26).Width = 30
        tempdt.Columns(27).Name = "RoomNos" : tempdt.Columns(27).Width = 30
        tempdt.Columns(28).Name = "StateName" : tempdt.Columns(28).Width = 30
        tempdt.Columns(29).Name = "CustomerGSTN" : tempdt.Columns(29).Width = 30
        tempdt.Columns(30).Name = "CommingFrom" : tempdt.Columns(30).Width = 30
        tempdt.Columns(31).Name = "GoingTo" : tempdt.Columns(31).Width = 30
        tempdt.Columns(32).Name = "VisitPurpose" : tempdt.Columns(32).Width = 30
        tempdt.Columns(33).Name = "CustomerAddress" : tempdt.Columns(33).Width = 30
        tempdt.Columns(34).Name = "CustomerCity" : tempdt.Columns(34).Width = 30
        tempdt.Columns(35).Name = "PinCode" : tempdt.Columns(35).Width = 30
        tempdt.Columns(36).Name = "ItemName" : tempdt.Columns(36).Width = 30
        tempdt.Columns(37).Name = "No" : tempdt.Columns(37).Width = 30
        tempdt.Columns(38).Name = "Code" : tempdt.Columns(38).Width = 30
        tempdt.Columns(39).Name = "Item Name" : tempdt.Columns(39).Width = 170
        tempdt.Columns(40).Name = "Unit" : tempdt.Columns(40).Width = 30
        tempdt.Columns(41).Name = "Qty" : tempdt.Columns(41).Width = 49
        tempdt.Columns(42).Name = "Rate" : tempdt.Columns(42).Width = 79
        tempdt.Columns(43).Name = "Basic" : tempdt.Columns(43).Width = 89
        tempdt.Columns(44).Name = "D%" : tempdt.Columns(44).Width = 30
        tempdt.Columns(45).Name = "Disc" : tempdt.Columns(45).Width = 30
        tempdt.Columns(46).Name = "T%" : tempdt.Columns(46).Width = 51
        tempdt.Columns(47).Name = "Tax" : tempdt.Columns(47).Width = 51
        tempdt.Columns(48).Name = "Total" : tempdt.Columns(48).Width = 108
        tempdt.Columns(49).Name = "Taxable" : tempdt.Columns(49).Width = 108
        tempdt.Columns(50).Name = "KOtDate" : tempdt.Columns(50).Width = 108
        tempdt.Columns(51).Name = "VAS Name." : tempdt.Columns(51).Width = 220
        tempdt.Columns(52).Name = "On Value" : tempdt.Columns(52).Width = 95
        tempdt.Columns(53).Name = "@" : tempdt.Columns(53).Width = 95
        tempdt.Columns(54).Name = "Amount" : tempdt.Columns(54).Width = 142
        tempdt.Columns(55).Name = "TaxID" : tempdt.Columns(55).Width = 142
        tempdt.Columns(56).Name = "TaxPer" : tempdt.Columns(56).Width = 100
        tempdt.Columns(57).Name = "TaxAmt" : tempdt.Columns(57).Width = 142
        tempdt.Columns(58).Name = "TotalRoomRent" : tempdt.Columns(58).Width = 30
        tempdt.Columns(59).Name = "TotalRoomAmount" : tempdt.Columns(59).Width = 30
        tempdt.Columns(60).Name = "TotalFoodAmountt" : tempdt.Columns(60).Width = 30
        tempdt.Columns(61).Name = "TotalVASCharges" : tempdt.Columns(61).Width = 30
        tempdt.Columns(62).Name = "TotalOtherCharges" : tempdt.Columns(62).Width = 30
        tempdt.Columns(63).Name = "TotalTaxAmt" : tempdt.Columns(63).Width = 30
        tempdt.Columns(64).Name = "TotalSGSTAmt" : tempdt.Columns(64).Width = 30
        tempdt.Columns(65).Name = "TotalCGSTAmt" : tempdt.Columns(65).Width = 30
        tempdt.Columns(66).Name = "TotalIGSTAmt" : tempdt.Columns(66).Width = 30
        tempdt.Columns(67).Name = "TotalBasicAmt" : tempdt.Columns(67).Width = 30
        tempdt.Columns(68).Name = "TotalAdVanceAmt" : tempdt.Columns(68).Width = 30
        tempdt.Columns(69).Name = "TotalGrandAmt" : tempdt.Columns(69).Width = 30
        tempdt.Columns(70).Name = "TotalRoundOff" : tempdt.Columns(70).Width = 30
        tempdt.Columns(71).Name = "TotalCashAmt" : tempdt.Columns(71).Width = 30
        tempdt.Columns(72).Name = "TotalChangeAmt" : tempdt.Columns(72).Width = 30
        tempdt.Columns(73).Name = "RoomRentTax" : tempdt.Columns(73).Width = 30
        tempdt.Columns(74).Name = "TotalFoodTax" : tempdt.Columns(73).Width = 30
        tempdt.Columns(75).Name = "TotalVasTax" : tempdt.Columns(75).Width = 30
        tempdt.Columns(76).Name = "VisitorNo" : tempdt.Columns(76).Width = 30
    End Sub
    Sub FillData()
        TempRowColumn()
        tempdt.Rows.Clear()
        Dim i, j As Integer
        Dim dt As New DataTable
        Dim cnt As Integer = -1
        '   dt = clsFun.ExecDataTable("SELECT * FROM Vouchers AS O lEFT JOIN Vouchers I ON I.ISBooked = O.ID lEFT JOIN Trans T ON T.VoucherID = O.ID lEFT JOIN VASTrans V ON V.VoucherID = O.ID Where O.TransType = 'Check Out' and O.ID=" & Val(txtID.Text) & "")
        dt = clsFun.ExecDataTable("Select * From Trans as t left join Items I on I.id=t.ItemID left join Vouchers V on V.id=t.VoucherID LEFT JOIN Package P ON P.ID=V.PackageID " & _
                                  " LEFT JOIN BusinessSources B ON V.BusinessSourceID = B.ID LEFT JOIN StateList S ON V.StateID = S.ID Where VoucherID=" & Val(txtID.Text) & "")
        If dt.Rows.Count = 0 Then Exit Sub
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                tempdt.Rows.Add()
                With tempdt.Rows(i)
                    '.Rows(i)(0) = dt.Rows(i)("ID").ToString()
                    .Cells(1).Value = dt.Rows(i)("TransType").ToString()
                    .Cells(2).Value = dt.Rows(i)("InvoiceNo").ToString()
                    .Cells(3).Value = CDate(dt.Rows(i)("EntryDate")).ToString("dd-MM-yyyy")
                    .Cells(4).Value = dt.Rows(i)("PackageName").ToString()
                    .Cells(5).Value = dt.Rows(i)("Title").ToString()
                    .Cells(6).Value = dt.Rows(i)("CustomerName").ToString() : .Cells(7).Value = dt.Rows(i)("CustomerMobile").ToString()
                    .Cells(8).Value = dt.Rows(i)("Gender").ToString() : .Cells(9).Value = dt.Rows(i)("Nationality").ToString()
                    .Cells(10).Value = CDate(dt.Rows(i)("CHeckINDate").ToString()).ToString("dd-MM-yyyy") : .Cells(11).Value = dt.Rows(i)("CheckinTime").ToString()
                    .Cells(12).Value = CDate(dt.Rows(i)("CHeckOutDate").ToString()).ToString("dd-MM-yyyy") : .Cells(13).Value = dt.Rows(i)("CheckOutTime").ToString()
                    .Cells(14).Value = Val(txtStayDays.Text) : .Cells(15).Value = Val(dt.Rows(i)("Male").ToString()) + Val(dt.Rows(i)("Female").ToString())
                    .Cells(16).Value = dt.Rows(i)("Kids").ToString() : .Cells(17).Value = .Cells(15).Value
                    .Cells(18).Value = dt.Rows(i)("CompanyName").ToString() : .Cells(19).Value = dt.Rows(i)("CompanyContact").ToString()
                    .Cells(20).Value = dt.Rows(i)("CompanyAdd").ToString()
                    .Cells(21).Value = dt.Rows(i)("Email").ToString() : .Cells(22).Value = dt.Rows(i)("Website").ToString()
                    .Cells(23).Value = dt.Rows(i)("SourceName").ToString() : .Cells(24).Value = dt.Rows(i)("DocumentType").ToString()
                    .Cells(25).Value = dt.Rows(i)("DocumentNo").ToString() : .Cells(26).Value = dt.Rows(i)("Remark").ToString()
                    .Cells(27).Value = dt.Rows(i)("RoomNos").ToString() : .Cells(28).Value = dt.Rows(i)("StateName").ToString() & " - " & dt.Rows(i)("StateCode").ToString()
                    .Cells(29).Value = dt.Rows(i)("CustomerGSTN").ToString() : .Cells(30).Value = dt.Rows(i)("CommingFrom").ToString() 'clsFun.ExecScalarStr("Select StateName From StateList Where ID='" & dt.Rows(i)("StateID").ToString() & "'")
                    .Cells(31).Value = dt.Rows(i)("GoingTo").ToString() : .Cells(32).Value = dt.Rows(i)("VisitPurpose").ToString()
                    .Cells(33).Value = dt.Rows(i)("CustomerAddress").ToString() : .Cells(34).Value = dt.Rows(i)("CustomerCity").ToString()
                    .Cells(35).Value = dt.Rows(i)("PinCode").ToString()
                    '''' Food Item Details
                    dt1 = clsFun.ExecDataTable("Select * From Trans Where ItemID > 0 and VoucherID=" & Val(txtID.Text) & "")
                    For j = 0 To dt1.Rows.Count - 1
                        If Val(dt.Rows(i)("ItemID").ToString()) > 0 Then
                            .Cells(36).Value = .Cells(36).Value & dt1.Rows(j)("ItemName").ToString() & vbCrLf
                            .Cells(37).Value = .Cells(37).Value & dt1.Rows(j)("Sno").ToString() & vbCrLf
                            '.Cells(38).Value = .Cells(38).Value & dt1.Rows(j)("ItemCode").ToString() & vbCrLf
                            .Cells(39).Value = .Cells(39).Value & Format(Val(dt1.Rows(j)("Qty").ToString()), "0.00") & vbCrLf
                            .Cells(40).Value = .Cells(40).Value & Format(Val(dt1.Rows(j)("Rate").ToString()), "0.00") & vbCrLf
                            .Cells(41).Value = .Cells(41).Value & dt1.Rows(j)("Per").ToString() & vbCrLf
                            .Cells(42).Value = .Cells(42).Value & Format(Val(dt1.Rows(j)("BasicAmt").ToString()), "0.00") & vbCrLf
                            .Cells(43).Value = .Cells(43).Value & Format(Val(dt1.Rows(j)("DisPer").ToString()), "0.00") & vbCrLf
                            .Cells(44).Value = .Cells(44).Value & Format(Val(dt1.Rows(j)("taxPer").ToString()), "0.00") & vbCrLf
                            .Cells(45).Value = .Cells(45).Value & Format(Val(dt1.Rows(j)("TaxAmt").ToString()), "0.00") & vbCrLf
                            .Cells(46).Value = .Cells(46).Value & Format(Val(dt1.Rows(j)("TotalAmt").ToString()), "0.00") & vbCrLf
                            .Cells(47).Value = .Cells(47).Value & Format(Val(dt1.Rows(j)("TaxableAmt").ToString()), "0.00") & vbCrLf
                            .Cells(48).Value = .Cells(48).Value & dt1.Rows(j)("KotDate").ToString() & vbCrLf
                            .Cells(49).Value = .Cells(49).Value & Format(Val(dt1.Rows(j)("SGSTAMT").ToString()), "0.00") & vbCrLf
                            .Cells(50).Value = .Cells(50).Value & Format(Val(dt1.Rows(j)("CGSTAMT").ToString()), "0.00") & vbCrLf
                            .Cells(51).Value = .Cells(51).Value & Format(Val(dt1.Rows(j)("IGStAmt").ToString()), "0.00") & vbCrLf
                        End If
                    Next
                    dt2 = clsFun.ExecDataTable("Select * From VASTrans Where VoucherID=" & Val(txtID.Text) & "")
                    For j = 0 To dt2.Rows.Count - 1
                        .Cells(52).Value = .Cells(52).Value & dt2.Rows(j)("VASName").ToString() & vbCrLf
                        .Cells(53).Value = .Cells(53).Value & Format(Val(dt2.Rows(j)("OnValue").ToString()), "0.00") & vbCrLf
                        .Cells(54).Value = .Cells(54).Value & Format(Val(dt2.Rows(j)("Rate").ToString()), "0.00") & vbCrLf
                        .Cells(55).Value = .Cells(55).Value & Format(Val(dt2.Rows(j)("Amount").ToString()), "0.00") & vbCrLf
                        .Cells(56).Value = .Cells(56).Value & Format(Val(dt2.Rows(j)("taxPer").ToString()), "0.00") & vbCrLf
                        .Cells(57).Value = .Cells(57).Value & Format(Val(dt2.Rows(j)("TaxAmount").ToString()), "0.00") & vbCrLf
                    Next
                    .Cells(58).Value = Format(Val(dt.Rows(i)("RoomRentRate").ToString()), "0.00") : .Cells(59).Value = Format(Val(dt.Rows(i)("RoomRentAmount").ToString()), "0.00")
                    .Cells(60).Value = Format(Val(dt.Rows(i)("TotalFoodAmt").ToString()), "0.00") : .Cells(61).Value = Format(Val(dt.Rows(i)("VasAmt").ToString()), "0.00")
                    .Cells(62).Value = Format(Val(dt.Rows(i)("TotalCharges").ToString()), "0.00") : .Cells(63).Value = Format(Val(dt.Rows(i)("TotalTaxAmt").ToString()), "0.00")
                    .Cells(64).Value = Format(Val(dt.Rows(i)("TotalSGSTamt").ToString()), "0.00") : .Cells(65).Value = Format(Val(dt.Rows(i)("TotalCGSTAmt").ToString()), "0.00")
                    .Cells(66).Value = Format(Val(dt.Rows(i)("TotalIGSTAmt").ToString()), "0.00") : .Cells(67).Value = Format(Val(dt.Rows(i)("TotalBasicAmt").ToString()), "0.00")
                    .Cells(68).Value = Format(Val(dt.Rows(i)("TotalAdvanceAmt").ToString()), "0.00") : .Cells(69).Value = Format(Val(dt.Rows(i)("TotalGrandAmt").ToString()), "0.00")
                    .Cells(70).Value = Format(Val(dt.Rows(i)("RoundOff").ToString()), "0.00") : .Cells(71).Value = Format(Val(dt.Rows(i)("TotalCashAmt").ToString()), "0.00")
                    .Cells(72).Value = Format(Val(dt.Rows(i)("TotalBalAmt").ToString()), "0.00") : .Cells(73).Value = Format(Val(dt.Rows(i)("RoomRentTax").ToString()), "0.00")
                    .Cells(74).Value = Format(Val(dt.Rows(i)("FoodTaxAmt").ToString()), "0.00") : .Cells(75).Value = Format(Val(dt.Rows(i)("VASTaxAmt").ToString()), "0.00")
                    .Cells(76).Value = dt.Rows(i)("InvoiceNo").ToString()
                End With
            Next
        End If
        dt.Clear()
    End Sub


    Public Sub FillControls(ByVal id As Integer)
        clsFun.FillDropDownList(cbCheckinDetails, "Select ID, InvoiceNo ||' : '|| CustomerName ||' : '|| RoomNos as CustomerDetails From Vouchers Where  TransType='Check In' ", "CustomerDetails", "Id", "")
        BtnSave.Text = "&Update"
        If clsFun.GetConnection.State = ConnectionState.Open Then clsFun.CloseConnection()
        sSql = "SELECT * FROM Vouchers AS V LEFT JOIN Package P ON V.PackageID = P.ID LEFT JOIN BusinessSources B ON V.BusinessSourceID = B.ID LEFT JOIN StateList S ON V.StateID = S.ID  where V.id=" & id
        clsFun.con.Open()
        Dim ad As New SQLite.SQLiteDataAdapter(sSql, clsFun.GetConnection)
        Dim ds As New DataSet
        ad.Fill(ds, "a")
        If ds.Tables("a").Rows.Count > 0 Then
            txtID.Text = ds.Tables("a").Rows(0)("ID").ToString()
            mskEntryDate.Text = Format(ds.Tables("a").Rows(0)("EntryDate"), "dd-MM-yyyy")
            cbSeries.Text = ds.Tables("a").Rows(0)("Series").ToString()
            txtinvoiceNo.Text = ds.Tables("a").Rows(0)("InvoiceNo").ToString()
            txtInvoiceID.Text = Val(ds.Tables("a").Rows(0)("InvoiceID").ToString())
            cbGSTType.Text = ds.Tables("a").Rows(0)("GSTType").ToString()
            cbCheckinDetails.Text = ds.Tables("a").Rows(0)("CheckInDetails").ToString()
            txtGuestName.Text = ds.Tables("a").Rows(0)("CustomerName").ToString()
            txtMobileNo.Text = ds.Tables("a").Rows(0)("CustomerMobile").ToString()
            txtGSTN.Text = ds.Tables("a").Rows(0)("CustomerGSTN").ToString()
            txtRemark.Text = ds.Tables("a").Rows(0)("Remark").ToString()
            mskCheckinDate.Text = CDate(ds.Tables("a").Rows(0)("CheckinDate")).ToString("dd-MM-yyyy")
            dtpCheckinTime.Text = ds.Tables("a").Rows(0)("CheckinTime").ToString()
            mskCheckOutDate.Text = CDate(ds.Tables("a").Rows(0)("CheckOutDate")).ToString("dd-MM-yyyy")
            dtpCheckoutTime.Text = ds.Tables("a").Rows(0)("CheckOutTime").ToString()
            txtRoomNos.Text = ds.Tables("a").Rows(0)("RoomNos").ToString()
            txtStayDays.Text = ds.Tables("a").Rows(0)("StayDays").ToString()
            txtTotalRoomRate.Text = Format(Val(ds.Tables("a").Rows(0)("RoomRentRate").ToString()), "0.00")
            txtTotalRoomRent.Text = Format(Val(ds.Tables("a").Rows(0)("RoomRentAmount").ToString()), "0.00")
            txttotalFoodCharges.Text = Format(Val(ds.Tables("a").Rows(0)("TotalFoodAmt").ToString()), "0.00")
            txtVASAmt.Text = Format(Val(ds.Tables("a").Rows(0)("VASAmt").ToString()), "0.00")
            txtOtherCharges.Text = Format(Val(ds.Tables("a").Rows(0)("TotalCharges").ToString()), "0.00")
            txtTotalTaxAmt.Text = Format(Val(ds.Tables("a").Rows(0)("TotalTaxAmt").ToString()), "0.00")
            txtTotalBasicAmt.Text = Format(Val(ds.Tables("a").Rows(0)("TotalBasicAmt").ToString()), "0.00")
            txtTotalAdvance.Text = Format(Val(ds.Tables("a").Rows(0)("TotalAdvanceAmt").ToString()), "0.00")
            txtTotalRoundOff.Text = Format(Val(ds.Tables("a").Rows(0)("RoundOff").ToString()), "0.00")
            TxtTotalAmount.Text = Format(Val(ds.Tables("a").Rows(0)("TotalGrandAmt").ToString()), "0.00")
            txtTotalCash.Text = Format(Val(ds.Tables("a").Rows(0)("TotalCashAmt").ToString()), "0.00")
            txtTotalChangeAmt.Text = Format(Val(ds.Tables("a").Rows(0)("TotalBalAmt").ToString()), "0.00")
            '''Card Details
            txtCardPayment.Text = Format(Val(ds.Tables("a").Rows(0)("CardAmt").ToString()), "0.00")
            txtRefNo.Text = ds.Tables("a").Rows(0)("RefNo").ToString()
            cbBank.SelectedValue = Val(ds.Tables("a").Rows(0)("AccountID").ToString())
            cbBank.Text = ds.Tables("a").Rows(0)("AccountName").ToString()
            txtRemark2.Text = ds.Tables("a").Rows(0)("Remark2").ToString()
            txtTotalVasCharges.Text = Format(Val(ds.Tables("a").Rows(0)("VasAmt").ToString()), "0.00")
            lblFoodTax.Text = Format(Val(ds.Tables("a").Rows(0)("FoodTaxamt").ToString()), "0.00")
            lblFoodTaxable.Text = Format(Val(ds.Tables("a").Rows(0)("TotalFoodAmt").ToString()), "0.00")
            lblVASTaxtotal.Text = Format(Val(ds.Tables("a").Rows(0)("VASTaxAmt").ToString()), "0.00")
            lblVAStotal.Text = Format(Val(ds.Tables("a").Rows(0)("VasAmt").ToString()), "0.00")
            lblRoomRentTax.Text = Format(Val(ds.Tables("a").Rows(0)("RoomRentTax").ToString()), "0.00")
            lblRoomRentTaxable.Text = Format(Val(ds.Tables("a").Rows(0)("RoomRentAmount").ToString()), "0.00")
        End If
        RoomColumns() : dgRoom.Rows.Clear()
        dt = clsFun.ExecDataTable("SELECT * FROM Trans AS T Inner JOIN Room R ON T.RoomID = R.ID Inner JOIN RoomType RT ON R.RoomTypeID = RT.ID  Where VoucherID=" & id)
        Dim dvData As DataView = New DataView(dt)
        Try
            If dt.Rows.Count > 0 Then
                dgRoom.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dgRoom.Rows.Add()
                    With dgRoom.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("RoomID").ToString()
                        .Cells(1).Value = dt.Rows(i)("RoomName").ToString()
                        .Cells(2).Value = dt.Rows(i)("RoomTypeName").ToString()
                        .Cells(3).Value = dt.Rows(i)("StayDays").ToString()
                        .Cells(4).Value = Format(Val(dt.Rows(i)("Rate").ToString()), "0.00")
                        .Cells(5).Value = Format(Val(dt.Rows(i)("DisPer").ToString()), "0.00")
                        .Cells(6).Value = Format(Val(dt.Rows(i)("DisAmt").ToString()), "0.00")
                        .Cells(7).Value = Format(Val(dt.Rows(i)("BasicAmt").ToString()), "0.00")
                        .Cells(8).Value = Format(Val(dt.Rows(i)("TaxPerID").ToString()), "0.00")
                        .Cells(9).Value = Format(Val(dt.Rows(i)("TaxPer").ToString()), "0.00")
                        .Cells(10).Value = Format(Val(dt.Rows(i)("TaxAmt").ToString()), "0.00")
                    End With
                Next
            End If
        Catch ex As Exception
            MsgBox("a")
        End Try
        dg1.ClearSelection()

        VASColumns()
        dgVas.Rows.Clear()
        dt = clsFun.ExecDataTable("SELECT * FROM VASTrans Where VoucherID=" & id)
        Dim dvData1 As DataView = New DataView(dt)
        Try
            If dt.Rows.Count > 0 Then
                dgVas.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dgVas.Rows.Add()
                    With dgVas.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("VASID").ToString()
                        .Cells(1).Value = dt.Rows(i)("VASName").ToString()
                        .Cells(2).Value = Format(Val(dt.Rows(i)("OnValue").ToString()), "0.00")
                        .Cells(3).Value = Format(Val(dt.Rows(i)("Rate").ToString()), "0.00")
                        .Cells(4).Value = Format(Val(dt.Rows(i)("Amount").ToString()), "0.00")
                        .Cells(5).Value = Val(dt.Rows(i)("TaxID").ToString())
                        .Cells(6).Value = Format(Val(dt.Rows(i)("TaxPer").ToString()), "0.00")
                        .Cells(7).Value = Format(Val(dt.Rows(i)("TaxAmount").ToString()), "0.00")
                    End With
                Next
            End If
        Catch ex As Exception
            MsgBox("a")
        End Try
        dg1Columns()
        dg1.Rows.Clear()
        dt = clsFun.ExecDataTable("SELECT * FROM Trans Where ItemID > 0 and VoucherID=" & id)
        Dim dvData2 As DataView = New DataView(dt)
        Try
            If dt.Rows.Count > 0 Then
                dg1.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("ItemID").ToString()
                        .Cells(1).Value = Val(dt.Rows(i)("SNo").ToString())
                        .Cells(3).Value = dt.Rows(i)("ItemName").ToString()
                        .Cells(4).Value = dt.Rows(i)("Per").ToString()
                        .Cells(5).Value = dt.Rows(i)("Qty").ToString()
                        .Cells(6).Value = Format(Val(dt.Rows(i)("Rate").ToString()), "0.00")
                        .Cells(7).Value = Format(Val(dt.Rows(i)("BasicAmt").ToString()), "0.00")
                        .Cells(8).Value = Format(Val(dt.Rows(i)("DisPer").ToString()), "0.00")
                        .Cells(9).Value = Format(Val(dt.Rows(i)("DisAmt").ToString()), "0.00")
                        .Cells(10).Value = Format(Val(dt.Rows(i)("TaxPer").ToString()), "0.00")
                        .Cells(11).Value = Format(Val(dt.Rows(i)("TaxAmt").ToString()), "0.00")
                        .Cells(12).Value = Format(Val(dt.Rows(i)("TotalAmt").ToString()), "0.00")
                        .Cells(13).Value = Format(Val(dt.Rows(i)("TaxAbleAmt").ToString()), "0.00")
                        .Cells(14).Value = CDate(dt.Rows(i)("KotDate")).ToString("dd-MM-yyyy")
                    End With
                Next
            End If
        Catch ex As Exception
            MsgBox("a")
        End Try
        dgRoom.ClearSelection() : dgVas.ClearSelection()
    End Sub


    Private Sub VNumber()
        Dim prefix As String = clsFun.ExecScalarStr("Select CheckoutPrefix From Options")
        Vno = clsFun.ExecScalarInt("SELECT Max(InvoiceID) AS ID FROM Vouchers Where TransType='Check Out' ")
        txtinvoiceNo.Text = prefix & " " & Vno + 1
        txtInvoiceID.Text = Vno + 1
    End Sub
    Private Sub dg1Columns()
        dg1.ColumnCount = 15
        dg1.Columns(0).Name = "Itemid" : dg1.Columns(0).Visible = False
        dg1.Columns(1).Name = "No" : dg1.Columns(1).Width = 50
        dg1.Columns(2).Name = "Code" : dg1.Columns(2).Visible = False
        dg1.Columns(3).Name = "Item Name" : dg1.Columns(3).Width = 170
        dg1.Columns(4).Name = "Unit" : dg1.Columns(4).Visible = False
        dg1.Columns(5).Name = "Qty" : dg1.Columns(5).Width = 49
        dg1.Columns(6).Name = "Rate" : dg1.Columns(6).Width = 79
        dg1.Columns(7).Name = "Basic" : dg1.Columns(7).Width = 89
        dg1.Columns(8).Name = "D%" : dg1.Columns(8).Visible = False
        dg1.Columns(9).Name = "Disc" : dg1.Columns(9).Visible = False
        dg1.Columns(10).Name = "T%" : dg1.Columns(10).Width = 51
        dg1.Columns(11).Name = "Tax" : dg1.Columns(11).Width = 51
        dg1.Columns(12).Name = "Total" : dg1.Columns(12).Width = 108
        dg1.Columns(13).Name = "Taxable" : dg1.Columns(13).Visible = False
        dg1.Columns(14).Name = "KOtDate" : dg1.Columns(14).Visible = False
        dg1.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dg1.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dg1.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dg1.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dg1.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dg1.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dg1.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dg1.Columns(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dg1.Columns(9).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dg1.Columns(10).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dg1.Columns(11).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dg1.Columns(12).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dg1.Columns(13).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dg1.Columns(14).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub
    Private Sub RoomColumns()
        dgRoom.ColumnCount = 11
        dgRoom.Columns(0).Name = "RoomID" : dgRoom.Columns(0).Visible = False
        dgRoom.Columns(1).Name = "Room" : dgRoom.Columns(1).Width = 100
        dgRoom.Columns(2).Name = "Type" : dgRoom.Columns(2).Width = 100
        dgRoom.Columns(3).Name = "Days" : dgRoom.Columns(3).Width = 50
        dgRoom.Columns(4).Name = "Rate" : dgRoom.Columns(4).Width = 80
        dgRoom.Columns(5).Name = "Disc%" : dgRoom.Columns(5).Width = 70
        dgRoom.Columns(6).Name = "Disc" : dgRoom.Columns(6).Width = 70
        dgRoom.Columns(7).Name = "Taxable" : dgRoom.Columns(7).Width = 100
        dgRoom.Columns(8).Name = "TaxID" : dgRoom.Columns(8).Visible = False
        dgRoom.Columns(9).Name = "Tax%" : dgRoom.Columns(9).Width = 70
        dgRoom.Columns(10).Name = "Amt" : dgRoom.Columns(10).Width = 70
        dgRoom.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgRoom.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgRoom.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgRoom.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgRoom.Columns(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgRoom.Columns(9).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgRoom.Columns(10).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub mskEntryDate_GotFocus(sender As Object, e As EventArgs) Handles mskEntryDate.GotFocus, mskEntryDate.Click
        mskEntryDate.SelectAll()
    End Sub

    Private Sub mskEntryDate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mskEntryDate.Validating
        mskEntryDate.Text = clsFun.convdate(mskEntryDate.Text)
        If BtnSave.Text = "&Save" Then mskCheckOutDate.Text = mskEntryDate.Text
    End Sub

    Private Sub mskEntryDate_KeyDown(sender As Object, e As KeyEventArgs) Handles mskEntryDate.KeyDown, cbSeries.KeyDown,
        txtinvoiceNo.KeyDown, cbCheckinDetails.KeyDown, txtRemark.KeyDown, txtTotalCash.KeyDown, cbGSTType.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        Else
            Exit Sub
        End If
        If txtinvoiceNo.Focused Then
            If e.KeyCode = Keys.F2 Then
                pnlInvoiceID.Visible = True
                pnlInvoiceID.BringToFront()
                txtInvoiceID.Focus()
            End If
        End If
        e.SuppressKeyPress = True
        Select Case e.KeyCode
            Case Keys.End
                e.Handled = True
                BtnSave.Focus()
        End Select
    End Sub
    Private Sub mskCheckinDate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mskCheckinDate.Validating
        Try
            mskCheckinDate.Text = clsFun.convdate(mskCheckinDate.Text)
        Catch ex As Exception
            MsgBox("Date is Not Vallid")
        End Try

    End Sub
    Private Sub mskCheckOutDate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mskCheckOutDate.Validating
        mskCheckOutDate.Text = clsFun.convdate(mskCheckOutDate.Text)
    End Sub
    Private Sub VASColumns()
        dgVas.ColumnCount = 8
        dgVas.Columns(0).Name = "ID" : dgVas.Columns(0).Visible = False
        dgVas.Columns(1).Name = "VAS Name." : dgVas.Columns(1).Width = 296
        dgVas.Columns(2).Name = "On Value" : dgVas.Columns(2).Width = 95
        dgVas.Columns(3).Name = "@" : dgVas.Columns(3).Width = 95
        dgVas.Columns(4).Name = "Amount" : dgVas.Columns(4).Width = 142
        dgVas.Columns(5).Name = "TaxID" : dgVas.Columns(5).Width = 142
        dgVas.Columns(6).Name = "TaxPer" : dgVas.Columns(6).Width = 100
        dgVas.Columns(7).Name = "TaxAmt" : dgVas.Columns(7).Width = 142
        dgVas.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgVas.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgVas.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgVas.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgVas.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgVas.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        clsFun.FillDropDownList(cbVAS, "Select ID,VASName From VAS", "VASName", "Id", "")
    End Sub
    Private Sub Retrive()
        RoomColumns()
        Dim sql As String = String.Empty
        dgRoom.Rows.Clear()
        Dim dt As New DataTable
        sql = "Select * From Vouchers as v inner join  Trans as t  on v.ID=t.VoucherID left join Room R on R.id=t.RoomID" & _
            " left join RoomType Rt on Rt.id=R.RoomTypeID left join Taxation tt on tt.id=Rt.TaxperID Where v.ID in ('" & Val(cbCheckinDetails.SelectedValue) & "')"
        dt = clsFun.ExecDataTable(sql)
        If dt.Rows.Count > 0 Then
            txtGuestName.Text = dt.Rows(i)("CustomerName").ToString()
            txtMobileNo.Text = dt.Rows(i)("CustomerMobile").ToString()
            txtGSTN.Text = dt.Rows(i)("CustomerGSTN").ToString()
            txtRemark.Text = dt.Rows(i)("Remark").ToString()
            mskCheckinDate.Text = CDate(dt.Rows(i)("EntryDate")).ToString("dd-MM-yyyy")
            dtpCheckinTime.Text = dt.Rows(i)("CheckinTime").ToString()
            txtRoomNos.Text = dt.Rows(i)("RoomNos").ToString()
            txtRoomNos.Text = dt.Rows(i)("RoomNos").ToString()
            txtTotalAdvance.Text = Format(Val(dt.Rows(i)("TotalCashAmt").ToString()), "0.00")
            Dim CheckinDate As DateTime = Date.Parse(clsFun.convdate(mskCheckinDate.Text) & " " & dtpCheckinTime.Text)
            Dim CheckOutDate As DateTime = Date.Parse(clsFun.convdate(mskCheckOutDate.Text) & " " & dtpCheckoutTime.Text)
            Dim StayDays As Long = DateDiff(DateInterval.Day, CheckinDate, CheckOutDate)
            'StayDays = StayDays / 12
            '  Dim StayDays As Integer = CheckOutDate.Subtract(CheckinDate).Days
            txtStayDays.Text = IIf(StayDays <= 0, 1, StayDays + 1)
            For i = 0 To dt.Rows.Count - 1
                dgRoom.Rows.Add()
                With dgRoom.Rows(i)
                    .Cells(0).Value = dt.Rows(i)("RoomID").ToString()
                    .Cells(1).Value = dt.Rows(i)("RoomName").ToString()
                    .Cells(2).Value = dt.Rows(i)("RoomTypeName").ToString()
                    .Cells(3).Value = Val(txtStayDays.Text)
                    .Cells(4).Value = Format(Val(dt.Rows(i)("Rate").ToString()), "0.00")
                    .Cells(5).Value = Format(Val(dt.Rows(i)("DisPer").ToString()), "0.00")
                    .Cells(6).Value = Format(Val(Val(.Cells(3).Value) * Val(.Cells(4).Value) * Val(.Cells(5).Value)) / 100, "0.00")
                    .Cells(7).Value = Format(Val(Val(.Cells(3).Value) * Val(.Cells(4).Value)) - Val(.Cells(6).Value), "0.00")
                    .Cells(8).Value = dt.Rows(i)("TaxperID").ToString()
                    .Cells(9).Value = dt.Rows(i)("GSTPer").ToString()
                    .Cells(10).Value = Format(Val(Val(.Cells(7).Value) * Val(.Cells(9).Value) / 100), "0.00")
                    '.Cells(11).Value = IIf(cbGSTType.SelectedIndex = 0, Format(Val(.Cells(9).Value) / 2, "0.00"), "0.00")
                    '.Cells(12).Value = IIf(cbGSTType.SelectedIndex = 0, Format(Val(.Cells(10).Value) / 2, "0.00"), "0.00")
                    '.Cells(13).Value = IIf(cbGSTType.SelectedIndex = 0, Format(Val(.Cells(9).Value) / 2, "0.00"), "0.00")
                    '.Cells(14).Value = IIf(cbGSTType.SelectedIndex = 0, Format(Val(.Cells(10).Value) / 2, "0.00"), "0.00")
                    '.Cells(15).Value = IIf(cbGSTType.SelectedIndex = 0, "0.00", Format(Val(.Cells(9).Value), "0.00"))
                    '.Cells(16).Value = IIf(cbGSTType.SelectedIndex = 0, "0.00", Format(Val(.Cells(10).Value), "0.00"))
                    .Cells(3).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Cells(4).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Cells(5).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Cells(6).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Cells(7).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Cells(9).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Cells(10).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    '.Cells(11).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    '.Cells(12).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    '.Cells(13).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    '.Cells(14).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    '.Cells(15).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
            Next
        End If
        VASColumns()
        dgVas.Rows.Clear()
        dt = clsFun.ExecDataTable("SELECT * FROM VASTrans AS VT LEFT JOIN VAS V ON V.ID = VT.VASID LEFT JOIN Taxation t ON V.TaxPerID = t.ID Where VoucherID=" & Val(cbCheckinDetails.SelectedValue))
        Dim dvData1 As DataView = New DataView(dt)
        Try
            If dt.Rows.Count > 0 Then
                dgVas.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dgVas.Rows.Add()
                    With dgVas.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("VASID").ToString()
                        .Cells(1).Value = dt.Rows(i)("VASName").ToString()
                        .Cells(2).Value = Val(txtStayDays.Text)
                        .Cells(3).Value = Format(Val(dt.Rows(i)("Rate").ToString()), "0.00")
                        .Cells(4).Value = Format(Val(txtStayDays.Text) * Val(dt.Rows(i)("Rate").ToString()), "0.00")
                        .Cells(5).Value = dt.Rows(i)("TaxPerID").ToString()
                        .Cells(6).Value = Format(Val(dt.Rows(i)("GSTper").ToString()), "0.00")
                        .Cells(7).Value = Format(Val(Val(.Cells(4).Value) * Val(.Cells(6).Value)) / 100, "0.00")
                        '.Cells(8).Value = IIf(cbGSTType.SelectedIndex = 0, Format(Val(.Cells(6).Value) / 2, "0.00"), "0.00")
                        '.Cells(9).Value = IIf(cbGSTType.SelectedIndex = 0, Format(Val(.Cells(7).Value) / 2, "0.00"), "0.00")
                        '.Cells(10).Value = IIf(cbGSTType.SelectedIndex = 0, Format(Val(.Cells(6).Value) / 2, "0.00"), "0.00")
                        '.Cells(11).Value = IIf(cbGSTType.SelectedIndex = 0, Format(Val(.Cells(7).Value) / 2, "0.00"), "0.00")
                        '.Cells(12).Value = IIf(cbGSTType.SelectedIndex = 0, "0.00", Format(Val(.Cells(6).Value), "0.00"))
                        '.Cells(13).Value = IIf(cbGSTType.SelectedIndex = 0, "0.00", Format(Val(.Cells(7).Value), "0.00"))
                        .Cells(3).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Cells(4).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Cells(6).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Cells(7).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        '.Cells(8).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        '.Cells(9).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        '.Cells(10).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        '.Cells(11).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        '.Cells(12).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        '.Cells(13).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    End With
                Next
            End If
        Catch ex As Exception
            MsgBox("a")
        End Try
        VasTxtClear()
        'txtTaxPer.Text = Val(clsFun.ExecScalarStr("SELECT IGSTPer FROM Room AS R INNER JOIN RoomType AS RT ON R.RoomTypeID = RT.ID left join Taxation as T on T.ID=RT.TaxperID where R.id in ('" & Val(txtRoomIDs.Text) & "')"))


        '''Food Details
        dt.Clear()
        dt = clsFun.ExecDataTable("SELECT * FROM KOT AS K INNER JOIN KOTTrans AS KT ON K.ID = KT.KOTID Where RoomOccupied='Y' and Paid isnull and RoomVoucherID in ('" & Val(cbCheckinDetails.SelectedValue) & "')")
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
                        .Cells(5).Value = Format(Val(dt.Rows(i)("Qty").ToString()), "0.00")
                        .Cells(6).Value = Format(Val(dt.Rows(i)("Rate").ToString()), "0.00")
                        .Cells(7).Value = Format(Val(dt.Rows(i)("Amount").ToString()), "0.00")
                        .Cells(8).Value = Format(Val(0), "0.00")
                        .Cells(9).Value = Format(Val(0), "0.00")
                        .Cells(10).Value = Format(Val(clsFun.ExecScalarStr("Select GSTPer From Item_View Where ID= " & dt.Rows(i)("ItemID").ToString() & "")), "0.00")
                        .cells(13).value = Format((Val(.Cells(7).Value) - Val(.Cells(9).Value)), "0.00")
                        .Cells(11).Value = Format(Val(Val(.Cells(10).Value) * Val(.cells(13).value) / 100), "0.00")
                        .Cells(12).Value = Format(Val(Val(.cells(13).value) - Val(.Cells(9).Value) + Val(.Cells(11).Value)), "0.00")
                        .Cells(14).Value = CDate(dt.Rows(i)("EntryDate")).ToString("yyyy-MM-dd")
                        .Cells(5).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Cells(6).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Cells(7).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Cells(8).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Cells(9).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Cells(10).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Cells(13).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Cells(11).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Cells(12).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Cells(14).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    End With
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "Atithi")
        End Try
    End Sub

    Private Sub cbCheckinDetails_Leave(sender As Object, e As EventArgs) Handles cbCheckinDetails.Leave
        Retrive()
        calc() : dg1.ClearSelection() : dgRoom.ClearSelection()
    End Sub

    Private Sub dtpCheckoutTime_Leave(sender As Object, e As EventArgs) Handles dtpCheckoutTime.Leave, mskCheckOutDate.Leave, mskCheckinDate.Leave, dtpCheckinTime.Leave
        If CDate(clsFun.convdate(mskEntryDate.Text)) < CDate(clsFun.convdate(mskCheckOutDate.Text)) Then
            MsgBox("Check Out Date Must Be Less of Invoice Date...")
            mskCheckOutDate.Focus()
            : Exit Sub
        End If
        Retrive()
        calc() : dg1.ClearSelection() : dgRoom.ClearSelection()
    End Sub

    Private Sub txtStayDays_TextChanged(sender As Object, e As EventArgs) Handles txtStayDays.TextChanged, txtTotalRoomRate.TextChanged
        txtTotalRoomRent.Text = Format(Val(Val(txtStayDays.Text) * Val(txtTotalRoomRate.Text)), "0.00")
    End Sub
    Private Sub calc()
        txttotalFoodCharges.Text = Format(0, "0.00") : lblRoomRentDisc.Text = Format(0, "0.00")
        lblRoomRentTaxable.Text = Format(0, "0.00") : lblRoomRentTax.Text = Format(0, "0.00")
        txtTotalVasCharges.Text = Format(0, "0.00") : lblFoodTaxable.Text = Format(0, "0.00")
        lblFoodTax.Text = Format(0, "0.00") : lblVAStotal.Text = Format(0, "0.00") : txtOtherCharges.Text = Format(0, "0.00")
        lblVASTaxtotal.Text = Format(0, "0.00")
        For i = 0 To dgRoom.Rows.Count - 1
            lblRoomRentDisc.Text = Format(Val(lblRoomRentDisc.Text) + Val(dgRoom.Rows(i).Cells(6).Value), "0.00")
            lblRoomRentTaxable.Text = Format(Val(lblRoomRentTaxable.Text) + Val(dgRoom.Rows(i).Cells(7).Value), "0.00")
            lblRoomRentTax.Text = Format(Val(lblRoomRentTax.Text) + Val(dgRoom.Rows(i).Cells(10).Value), "0.00")
        Next
        For i = 0 To dg1.Rows.Count - 1
            lblFoodTaxable.Text = Format(Val(lblFoodTaxable.Text) + Val(dg1.Rows(i).Cells(7).Value), "0.00")
            lblFoodTax.Text = Format(Val(lblFoodTax.Text) + Val(dg1.Rows(i).Cells(11).Value), "0.00")
        Next
        For i = 0 To dgVas.Rows.Count - 1
            lblVAStotal.Text = Format(Val(lblVAStotal.Text) + Val(dgVas.Rows(i).Cells(4).Value), "0.00")
            lblVASTaxtotal.Text = Format(Val(lblVASTaxtotal.Text) + Val(dgVas.Rows(i).Cells(7).Value), "0.00")
        Next
        txtTotalRoomRent.Text = Format(Val(lblRoomRentTaxable.Text), "0.00")
        txtTotalRoomRate.Text = Format(Val(txtTotalRoomRent.Text) / Val(txtStayDays.Text), "0.00")
        txttotalFoodCharges.Text = Format(Val(lblFoodTaxable.Text), "0.00")
        txtTotalVasCharges.Text = Format(Val(lblVAStotal.Text), "0.00")
        txtTotalTaxAmt.Text = Format(Val(lblRoomRentTax.Text) + Val(lblFoodTax.Text) + Val(lblVASTaxtotal.Text), "0.00")
        txtTotalBasicAmt.Text = Format(Val(txtTotalRoomRent.Text) + Val(txttotalFoodCharges.Text) + Val(txtTotalVasCharges.Text) + +Val(txtTotalTaxAmt.Text), "0.00")
        Dim totalamt As Decimal = Val(txtTotalBasicAmt.Text) - Val(txtTotalAdvance.Text)
        TxtTotalAmount.Text = Format(Math.Round(Val(txtTotalBasicAmt.Text) - Val(txtTotalAdvance.Text)), "0.00")
        txtTotalRoundOff.Text = Format(Val(totalamt) - Val(TxtTotalAmount.Text), "0.00")
        txtTotalCash.Text = Format(Val(TxtTotalAmount.Text), "0.00")
    End Sub

    Private Sub btnAddVAS_Click(sender As Object, e As EventArgs) Handles btnAddVAS.Click
        If pnlRoomDetails.Visible = True Then pnlVAS.BringToFront()
        VASColumns() : cbVAS.Focus()
        pnlVAS.Visible = True
    End Sub

    Private Sub cbVAS_Leave(sender As Object, e As EventArgs) Handles cbVAS.Leave
        lblTaxID.Text = Val(clsFun.ExecScalarStr("SELECT T.ID FROM VAS AS V INNER JOIN Taxation AS T ON V.TaxPerID = T.ID Where V.ID='" & Val(cbVAS.SelectedValue) & "'"))
        lblTaxName.Text = clsFun.ExecScalarStr("SELECT TaxName FROM VAS AS V INNER JOIN Taxation AS T ON V.TaxPerID = T.ID Where V.ID='" & Val(cbVAS.SelectedValue) & "'")
        lblTaxPer.Text = Val(clsFun.ExecScalarStr("SELECT GSTPer FROM VAS AS V INNER JOIN Taxation AS T ON V.TaxPerID = T.ID Where V.ID='" & Val(cbVAS.SelectedValue) & "'"))
        txtonValue.Text = Format(Val(txtStayDays.Text), "0.00")
        txtVASRate.Text = Val(clsFun.ExecScalarStr("SELECT Per FROM VAS AS V INNER JOIN Taxation AS T ON V.TaxPerID = T.ID Where V.ID='" & Val(cbVAS.SelectedValue) & "'"))
    End Sub

    Private Sub txtVASAmt_TextChanged(sender As Object, e As EventArgs) Handles txtVASAmt.TextChanged, lblTaxPer.TextChanged, txtonValue.TextChanged, txtVASRate.TextChanged
        txtVASAmt.Text = Format(Val(txtonValue.Text) * Val(txtVASRate.Text), "0.00")
        lblTaxAmt.Text = Format(Val(lblTaxPer.Text) * Val(txtVASAmt.Text) / 100, "0.00")
    End Sub
    Private Sub txtVASAmt_KeyDown(sender As Object, e As KeyEventArgs) Handles txtVASAmt.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If dgVas.SelectedRows.Count = 1 Then
                If cbVAS.Text = "" Then MsgBox("Please Select VAS Name...", vbCritical, "") : cbVAS.SelectedIndex = 0 : cbVAS.Focus() : Exit Sub
                dgVas.SelectedRows(0).Cells(0).Value = Val(cbVAS.SelectedValue)
                dgVas.SelectedRows(0).Cells(1).Value = cbVAS.Text
                dgVas.SelectedRows(0).Cells(2).Value = Format(Val(txtonValue.Text), "0.00")
                dgVas.SelectedRows(0).Cells(3).Value = Format(Val(txtVASRate.Text), "0.00")
                dgVas.SelectedRows(0).Cells(4).Value = Format(Val(txtVASAmt.Text), "0.00")
                dgVas.SelectedRows(0).Cells(5).Value = Val(lblTaxID.Text)
                dgVas.SelectedRows(0).Cells(6).Value = Format(Val(lblTaxPer.Text), "0.00")
                dgVas.SelectedRows(0).Cells(7).Value = Format(Val(lblTaxAmt.Text), "0.00")
            Else
                If cbVAS.Text = "" Then MsgBox("Please Select VAS Name...", vbCritical, "") : cbVAS.SelectedIndex = 0 : cbVAS.Focus() : Exit Sub
                dgVas.Rows.Add(Val(cbVAS.SelectedValue), cbVAS.Text, Format(Val(txtonValue.Text), "0.00"), Format(Val(txtVASRate.Text), "0.00"),
                               Format(Val(txtVASAmt.Text), "0.00"), Val(lblTaxID.Text), Format(Val(lblTaxPer.Text), "0.00"))
            End If
            VasTxtClear()
        End If
    End Sub
    Private Sub VasTxtClear()
        txtonValue.Clear() : txtVASRate.Clear()
        txtVASAmt.Clear() : dgVas.ClearSelection()
        cbVAS.Focus() : calc()
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If pnlVAS.Visible = True Then pnlRoomDetails.BringToFront()
        dgRoom.Focus() : pnlRoomDetails.Visible = True
    End Sub

    Private Sub dg1_Leave(sender As Object, e As EventArgs) Handles dg1.Leave
        dg1.ClearSelection()
    End Sub

    Private Sub dgVas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgVas.CellDoubleClick
        If dgVas.SelectedRows.Count = 0 Then Exit Sub
        cbVAS.Text = dgVas.SelectedRows(0).Cells(1).Value
        txtonValue.Text = dgVas.SelectedRows(0).Cells(2).Value
        txtVASRate.Text = dgVas.SelectedRows(0).Cells(3).Value
        txtVASAmt.Text = dgVas.SelectedRows(0).Cells(4).Value
    End Sub
    Private Sub dgVas_KeyDown(sender As Object, e As KeyEventArgs) Handles dgVas.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgVas.SelectedRows.Count = 0 Then Exit Sub
            cbVAS.Text = dgVas.SelectedRows(0).Cells(1).Value
            txtonValue.Text = dgVas.SelectedRows(0).Cells(2).Value
            txtVASRate.Text = dgVas.SelectedRows(0).Cells(3).Value
            txtVASAmt.Text = dgVas.SelectedRows(0).Cells(4).Value
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click

        If Math.Abs(Val(txtTotalChangeAmt.Text)) > 0 Then
            clsFun.FillDropDownList(cbBank, "Select ID,AccountName From Account_AcGrp where (Groupid in(12,16)  or UnderGroupID in (12,16))", "AccountName", "Id", "")
            txtCardPayment.Text = Format(Val(txtTotalChangeAmt.Text), "0.00")
            txtCardPayment.Focus()
            pnlCreditBalance.Visible = True : Exit Sub
        End If
        If Val(txtCardPayment.Text) <= 0 And Val(cbBank.SelectedValue) <= 0 Then
            pnlCreditBalance.Visible = True
            cbBank.Focus() : Exit Sub
        End If
        If BtnSave.Text = "&Save" Then
            save() : MainScreenPicture.RetriveGroups() : MainScreenPicture.RestroTables()
        Else
            Update() : MainScreenPicture.RetriveGroups() : MainScreenPicture.RestroTables()
        End If
        FillData() : PrintRecord()
        If clsFun.ExecScalarStr("Select CheckOutAskForPrint From Options") = "Y" Then
            Dim res = MessageBox.Show("Do you want to Print Bill", "Print Bil", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If res = Windows.Forms.DialogResult.Yes Then
                If clsFun.ExecScalarStr("Select ChecKOutPreView From Options") = "Y" Then
                    Report_Viewer.printReport("\CheckOut.rpt")
                    Report_Viewer.MdiParent = MainScreenForm
                    Report_Viewer.Show() : Report_Viewer.BringToFront()
                    txtClear()

                Else
                    Report_Viewer.printReportDirect("\CheckOut.rpt")
                    txtClear()
                End If
            Else
                txtClear()
            End If
        Else
            txtClear()
        End If

    End Sub
    Private Sub PrintRecord()
        Dim fastQuery As String = String.Empty
        Dim count As Integer = 0
        Dim cmd As New SQLite.SQLiteCommand
        Dim sql As String = String.Empty
        ClsFunPrimary.ExecNonQuery("Delete from printing")
        ' clsFun.ExecNonQuery(sql)
        For Each row As DataGridViewRow In tempdt.Rows
            With row
                fastQuery = fastQuery & IIf(fastQuery <> "", " UNION ALL SELECT ", " SELECT ") & "'" & .Cells(0).Value & "','" & .Cells(1).Value & "','" & .Cells(2).Value & "','" & .Cells(3).Value & "','" & .Cells(4).Value & "', " & _
           "'" & .Cells(5).Value & "','" & .Cells(6).Value & "','" & .Cells(7).Value & "','" & .Cells(8).Value & "','" & .Cells(9).Value & "'," & _
           "'" & .Cells(10).Value & "','" & .Cells(11).Value & "','" & .Cells(12).Value & "','" & .Cells(13).Value & "','" & .Cells(14).Value & "'," & _
           "'" & .Cells(15).Value & "','" & .Cells(16).Value & "','" & .Cells(17).Value & "','" & .Cells(18).Value & "','" & .Cells(19).Value & "'," & _
           "'" & .Cells(20).Value & "','" & .Cells(21).Value & "','" & .Cells(22).Value & "','" & .Cells(23).Value & "','" & .Cells(24).Value & "'," & _
           "'" & .Cells(25).Value & "','" & .Cells(26).Value & "','" & .Cells(27).Value & "','" & .Cells(28).Value & "','" & .Cells(29).Value & "'," & _
           "'" & .Cells(30).Value & "','" & .Cells(31).Value & "','" & .Cells(32).Value & "','" & .Cells(33).Value & "','" & .Cells(34).Value & "'," & _
           "'" & .Cells(35).Value & "','" & .Cells(36).Value & "','" & .Cells(37).Value & "','" & .Cells(38).Value & "','" & .Cells(39).Value & "'," & _
           "'" & .Cells(40).Value & "','" & .Cells(41).Value & "','" & .Cells(42).Value & "','" & .Cells(43).Value & "','" & .Cells(44).Value & "'," & _
           "'" & .Cells(45).Value & "','" & .Cells(46).Value & "','" & .Cells(47).Value & "','" & .Cells(48).Value & "','" & .Cells(49).Value & "'," & _
           "'" & .Cells(50).Value & "','" & .Cells(51).Value & "','" & .Cells(52).Value & "','" & .Cells(53).Value & "','" & .Cells(54).Value & "'," & _
           "'" & .Cells(55).Value & "','" & .Cells(56).Value & "','" & .Cells(57).Value & "','" & .Cells(58).Value & "','" & .Cells(59).Value & "'," & _
           "'" & .Cells(60).Value & "','" & .Cells(61).Value & "','" & .Cells(62).Value & "','" & .Cells(63).Value & "','" & .Cells(64).Value & "'," & _
           "'" & .Cells(65).Value & "','" & .Cells(66).Value & "','" & .Cells(67).Value & "','" & .Cells(68).Value & "','" & .Cells(69).Value & "'," & _
           "'" & .Cells(70).Value & "','" & .Cells(71).Value & "','" & .Cells(72).Value & "','" & .Cells(73).Value & "','" & .Cells(74).Value & "'," & _
           "'" & .Cells(75).Value & "','" & .Cells(76).Value & "'"
                'End If
            End With


        Next
        Try
            If fastQuery = String.Empty Then Exit Sub
            sql = "insert into Printing(D1,M1,M2,M3,M4,P1,P2,P3,P4,P5,P6,P7,P8,P9,P10,P11,P12,P13,P14,P15,P16,P17,P18,P19,P20,P21,P22,P23,P24,P25, " & _
                    "P26,P27,P28,P29,P30,P31,P32,P33,P34,P35,P36,P37,P38,P39,P40,P41,P42,P43,P44,P45,P46,P47,P48,P49,P50,P51,P52,P53,P54,P55,P56,P57,P58,P59, " & _
                    "P60,P61,P62,P63,P64,P65,P66,P67,P68,P69,P70,P71,P72)" & fastQuery
            ClsFunPrimary.ExecNonQuery(sql)

        Catch ex As Exception
            MsgBox(ex.Message)
            ClsFunPrimary.CloseConnection()
        End Try
        ' clsFun.ExecNonQuery(sql)
    End Sub
    Private Sub HeaderCheckBox_Clicked(ByVal sender As Object, ByVal e As EventArgs)
        'Necessary to end the edit mode of the Cell.
        dg1.EndEdit()
        'Loop and check and uncheck all row CheckBoxes based on Header Cell CheckBox.
        For Each row As DataGridViewRow In dg1.Rows
            Dim checkBox As DataGridViewCheckBoxCell = (TryCast(row.Cells("checkBoxColumn"), DataGridViewCheckBoxCell))
            checkBox.Value = headerCheckBox.Checked
        Next
        ' calc()
    End Sub
    Private Sub save()
        Dim cmd As SQLite.SQLiteCommand
        Dim RoomID As String = String.Empty
        Dim RoomNo As String = String.Empty
        Dim checkBox As DataGridViewCheckBoxCell
        For Each row As DataGridViewRow In dgRoom.Rows
            RoomID = RoomID & row.Cells(0).Value & ","
            RoomNo = RoomNo & row.Cells(1).Value & ","
        Next
        If RoomID <> "" Then
            RoomID = RoomID.Remove(RoomID.LastIndexOf(","))
            RoomNo = RoomNo.Remove(RoomNo.LastIndexOf(","))
            clsFun.ExecScalarStr("Update Room Set ISOccupied='N' Where ID in(" & RoomID & ")")
        Else
            MsgBox("Please Select At Leat 1 Room for Booking...", vbCritical, "Choose Room") : dg1.Focus() : Exit Sub
        End If
        If txtGuestName.Text = "" Then
            txtGuestName.Focus()
            MsgBox("Please Fill Gusest Name... ", MsgBoxStyle.Exclamation, "Empty")
            Exit Sub
        End If
        Dim sql As String = "insert into Vouchers (TransType,EntryDate,Series, InvoiceNo,GSTType,CheckInDetails,CustomerName,CustomerMobile,CustomerGSTN, " & _
                             "Remark,CHeckINDate,CheckinTime,CheckOutDate,CheckOutTime,RoomIDs,RoomNos,StayDays,RoomRentRate,RoomRentAmount, " & _
                             "TotalFoodAmt,VASAmt,TotalCharges,TotalTaxAmt,TotalBasicAmt,TotalAdvanceAmt,RoundOff,TotalGrandAmt,TotalCashAmt,TotalBalAmt,InvoiceID, " & _
                             "TotalSGSTAmt,TotalCGSTAmt,TotalIGSTAmt,FoodTaxAmt,VASTaxAmt,RoomRentTax,CardAmt,RefNo,AccountID,AccountName,Remark2,SallerID,SallerName) " & _
                              " values (@1, @2,@3,@4, @5,@6,@7, @8,@9, " & _
                             "@10,@11, @12,@13,@14, @15,@16,@17, @18,@19, " & _
                             "@20,@21, @22,@23,@24, @25,@26,@27,@28,@29,@30, @31,@32,@33,@34,@35,@36,@37,@38,@39,@40,@41,@42,@43)"
        Try
            cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
            cmd.Parameters.AddWithValue("@1", Me.Text) : cmd.Parameters.AddWithValue("@2", CDate(mskEntryDate.Text).ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@3", cbSeries.Text) : cmd.Parameters.AddWithValue("@4", txtinvoiceNo.Text)
            cmd.Parameters.AddWithValue("@5", cbGSTType.Text) : cmd.Parameters.AddWithValue("@6", cbCheckinDetails.Text)
            cmd.Parameters.AddWithValue("@7", txtGuestName.Text) : cmd.Parameters.AddWithValue("@8", txtMobileNo.Text)
            cmd.Parameters.AddWithValue("@9", txtGSTN.Text) : cmd.Parameters.AddWithValue("@10", txtRemark.Text)
            cmd.Parameters.AddWithValue("@11", CDate(mskCheckinDate.Text).ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@12", dtpCheckinTime.Text) : cmd.Parameters.AddWithValue("@13", CDate(mskCheckOutDate.Text).ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@14", dtpCheckoutTime.Text) : cmd.Parameters.AddWithValue("@15", RoomID)
            cmd.Parameters.AddWithValue("@16", RoomNo) : cmd.Parameters.AddWithValue("@17", txtStayDays.Text)
            cmd.Parameters.AddWithValue("@18", Val(txtTotalRoomRate.Text)) : cmd.Parameters.AddWithValue("@19", Val(txtTotalRoomRent.Text))
            cmd.Parameters.AddWithValue("@20", Val(txttotalFoodCharges.Text)) : cmd.Parameters.AddWithValue("@21", Val(txtTotalVasCharges.Text))
            cmd.Parameters.AddWithValue("@22", Val(txtOtherCharges.Text)) : cmd.Parameters.AddWithValue("@23", Val(txtTotalTaxAmt.Text))
            cmd.Parameters.AddWithValue("@24", Val(txtTotalBasicAmt.Text)) : cmd.Parameters.AddWithValue("@25", Val(txtTotalAdvance.Text))
            cmd.Parameters.AddWithValue("@26", Val(txtTotalRoundOff.Text)) : cmd.Parameters.AddWithValue("@27", Val(TxtTotalAmount.Text))
            cmd.Parameters.AddWithValue("@28", Val(txtTotalCash.Text)) : cmd.Parameters.AddWithValue("@29", Val(txtTotalChangeAmt.Text))
            cmd.Parameters.AddWithValue("@30", Val(txtInvoiceID.Text))
            cmd.Parameters.AddWithValue("@31", IIf(cbGSTType.SelectedIndex = 0, Val(txtTotalTaxAmt.Text) / 2, 0))
            cmd.Parameters.AddWithValue("@32", IIf(cbGSTType.SelectedIndex = 0, Val(txtTotalTaxAmt.Text) / 2, 0))
            cmd.Parameters.AddWithValue("@33", IIf(cbGSTType.SelectedIndex = 1, 0, Val(txtTotalTaxAmt.Text)))
            cmd.Parameters.AddWithValue("@34", Val(lblFoodTax.Text)) : cmd.Parameters.AddWithValue("@35", Val(lblVASTaxtotal.Text))
            cmd.Parameters.AddWithValue("@36", Val(lblRoomRentTax.Text)) : cmd.Parameters.AddWithValue("@37", Val(txtCardPayment.Text))
            cmd.Parameters.AddWithValue("@38", txtRefNo.Text) : cmd.Parameters.AddWithValue("@39", Val(cbBank.SelectedValue))
            cmd.Parameters.AddWithValue("@40", cbBank.Text) : cmd.Parameters.AddWithValue("@41", txtRemark2.Text)
            cmd.Parameters.AddWithValue("@42", Val(7)) : cmd.Parameters.AddWithValue("@43", clsFun.ExecScalarStr("Select AccountName From Accounts Where ID=7"))
            If cmd.ExecuteNonQuery() > 0 Then
                txtID.Text = clsFun.ExecScalarInt("Select Max(ID) from Vouchers")
                clsFun.ExecScalarStr("Update Vouchers set ISBooked='" & Val(txtID.Text) & "' Where ID='" & Val(cbCheckinDetails.SelectedValue) & "'")
                dg1Record() : VASRecord() : Ledger() : RoomRecord()
                MsgBox("Record Insert Succesfully", MsgBoxStyle.Information, "Saved")
                ' textclearall()
                ' clearTxtAll()
            End If
            clsFun.CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message)
            clsFun.CloseConnection()
        End Try
    End Sub
    Private Sub Ledger()

        SqliteEntryDate = CDate(mskEntryDate.Text).ToString("yyyy-MM-dd")
        If Val(txtTotalRoomRent.Text) > 0 Then ''Room Rent Account Fixed
            clsFun.Ledger(0, (txtID.Text), SqliteEntryDate, Me.Text, 58, clsFun.ExecScalarStr("Select AccountName from Accounts where Id=58"), Val(txtTotalRoomRent.Text) - Val(txtTotalAdvance.Text), "C", cbCheckinDetails.Text)
        End If
        If Val(txttotalFoodCharges.Text) > 0 Then ''Sale Account Fixed
            clsFun.Ledger(0, (txtID.Text), SqliteEntryDate, Me.Text, 29, clsFun.ExecScalarStr("Select AccountName from Accounts where Id=29"), Val(txttotalFoodCharges.Text), "C", cbCheckinDetails.Text)
        End If
        If Val(txtTotalVasCharges.Text) > 0 Then ''VAS Account Fixed
            clsFun.Ledger(0, (txtID.Text), SqliteEntryDate, Me.Text, 59, clsFun.ExecScalarStr("Select AccountName from Accounts where Id=59"), Val(txtTotalVasCharges.Text), "C", cbCheckinDetails.Text)
        End If
        If cbGSTType.SelectedIndex = 0 Then
            If Val(txtTotalTaxAmt.Text) > 0 Then
                'SGST amount
                clsFun.Ledger(0, (txtID.Text), SqliteEntryDate, Me.Text, 998, clsFun.ExecScalarStr("Select AccountName from Accounts where Id=998"), Val(txtTotalTaxAmt.Text) / 2, "C", cbCheckinDetails.Text)
                'CGST amount
                clsFun.Ledger(0, (txtID.Text), SqliteEntryDate, Me.Text, 999, clsFun.ExecScalarStr("Select AccountName from Accounts where Id=999"), Val(txtTotalTaxAmt.Text) / 2, "C", cbCheckinDetails.Text)
            End If
        Else
            If Val(txtTotalTaxAmt.Text) > 0 Then
                ' IGST amount 
                clsFun.Ledger(0, (txtID.Text), SqliteEntryDate, Me.Text, 1000, clsFun.ExecScalarStr("Select AccountName from Accounts where Id=1000"), Val(txtTotalTaxAmt.Text), "C", cbCheckinDetails.Text)
            End If
        End If
        If Val(txtTotalRoundOff.Text) <> 0 Then ''Account 
            If Val(txtTotalRoundOff.Text) < 0 Then
                clsFun.Ledger(0, (txtID.Text), SqliteEntryDate, Me.Text, 39, clsFun.ExecScalarStr("Select AccountName from Accounts where Id=39"), Math.Abs(Val(txtTotalRoundOff.Text)), "C", cbCheckinDetails.Text)
            Else
                clsFun.Ledger(0, (txtID.Text), SqliteEntryDate, Me.Text, 39, clsFun.ExecScalarStr("Select AccountName from Accounts where Id=39"), Val(txtTotalRoundOff.Text), "D", cbCheckinDetails.Text)
            End If
        End If
        If Val(txtTotalCash.Text) > 0 Then ''Cash Amount 
            clsFun.Ledger(0, (txtID.Text), SqliteEntryDate, Me.Text, 7, clsFun.ExecScalarStr("Select AccountName from Accounts where Id=7"), Val(txtTotalCash.Text), "D", cbCheckinDetails.Text)
        End If
        If Val(txtCardPayment.Text) > 0 Then ''Card Due Amount 
            clsFun.Ledger(0, (txtID.Text), SqliteEntryDate, Me.Text, cbBank.SelectedValue, cbBank.Text, Val(txtCardPayment.Text), "D", cbCheckinDetails.Text)
        End If
    End Sub
    Private Sub Delete()
        Try
            If MessageBox.Show("Are you Sure Want to Delete Check Out Entry ??", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                clsFun.ExecNonQuery("DELETE from Vouchers WHERE ID=" & Val(txtID.Text) & "")
                clsFun.ExecNonQuery("DELETE from Ledger WHERE vouchersID=" & Val(txtID.Text) & "")
                clsFun.ExecNonQuery("DELETE from Trans WHERE voucherID=" & Val(txtID.Text) & "")
                clsFun.ExecNonQuery("DELETE from VASTrans WHERE voucherID=" & Val(txtID.Text) & "")
                clsFun.ExecScalarStr("Update Vouchers set ISBooked = null Where ID='" & Val(cbCheckinDetails.SelectedValue) & "'")
                VNumber()
                MsgBox("Check Out Invoice Deleted Successfully.", vbInformation + vbOKOnly, "Deleted")
                ' retrive()
                ' txtclear()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Update()
        Dim cmd As SQLite.SQLiteCommand
        Dim RoomID As String = String.Empty
        Dim RoomNo As String = String.Empty
        Dim checkBox As DataGridViewCheckBoxCell
        For Each row As DataGridViewRow In dgRoom.Rows
            RoomID = RoomID & row.Cells(0).Value & ","
            RoomNo = RoomNo & row.Cells(1).Value & ","
        Next
        If RoomID <> "" Then
            RoomID = RoomID.Remove(RoomID.LastIndexOf(","))
            RoomNo = RoomNo.Remove(RoomNo.LastIndexOf(","))
            clsFun.ExecScalarStr("Update Room Set ISOccupied='N' Where ID in(" & RoomID & ")")
        Else
            MsgBox("Please Select At Leat 1 Room for Booking...", vbCritical, "Choose Room") : dg1.Focus() : Exit Sub
        End If
        If txtGuestName.Text = "" Then MsgBox("Please Fill Gusest Name... ", MsgBoxStyle.Exclamation, "Empty") : txtGuestName.Focus() : Exit Sub
        Dim sql As String = "Update Vouchers set TransType='" & Me.Text & "',EntryDate='" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "'," & _
                            "Series='" & cbSeries.Text & "', InvoiceNo='" & txtinvoiceNo.Text & "',GSTType='" & cbGSTType.Text & "',CheckInDetails='" & cbCheckinDetails.Text & "', " & _
                            "CustomerName='" & txtGuestName.Text & "',CustomerMobile='" & txtMobileNo.Text & "',CustomerGSTN='" & txtGSTN.Text & "',InvoiceID='" & (txtInvoiceID.Text) & "', " & _
                             "Remark='" & txtRemark.Text & "',CHeckINDate='" & CDate(mskCheckinDate.Text).ToString("yyyy-MM-dd") & "',CheckinTime='" & dtpCheckinTime.Text & "', " & _
                             "CheckOutDate='" & CDate(mskCheckOutDate.Text).ToString("yyyy-MM-dd") & "',CheckOutTime='" & dtpCheckoutTime.Text & "',RoomIDs='" & RoomID & "', " & _
                             "RoomNos='" & RoomNo & "',StayDays='" & txtStayDays.Text & "',RoomRentRate='" & Val(txtTotalRoomRate.Text) & "',RoomRentAmount='" & Val(txtTotalRoomRent.Text) & "', " & _
                             "TotalFoodAmt='" & Val(txttotalFoodCharges.Text) & "',VASAmt='" & Val(txtTotalVasCharges.Text) & "',TotalCharges='" & Val(txtOtherCharges.Text) & "', " & _
                             "TotalTaxAmt='" & Val(txtTotalTaxAmt.Text) & "',TotalBasicAmt='" & Val(txtTotalBasicAmt.Text) & "',TotalAdvanceAmt='" & Val(txtTotalAdvance.Text) & "', " & _
                             "RoundOff='" & Val(txtTotalRoundOff.Text) & "',TotalGrandAmt='" & Val(TxtTotalAmount.Text) & "',TotalCashAmt='" & Val(txtTotalCash.Text) & "'," & _
                             "TotalBalAmt='" & Val(txtTotalChangeAmt.Text) & "',InvoiceID='" & Val(txtInvoiceID.Text) & "',TotalSGSTamt ='" & IIf(cbGSTType.SelectedIndex = 0, Val(txtTotalTaxAmt.Text) / 2, 0) & "', " & _
                             "TotalCGSTamt ='" & IIf(cbGSTType.SelectedIndex = 0, Val(txtTotalTaxAmt.Text) / 2, 0) & "',TotalIGSTamt ='" & IIf(cbGSTType.SelectedIndex = 1, 0, Val(txtTotalTaxAmt.Text)) & "', " & _
                            "FoodTaxAmt ='" & Val(lblFoodTax.Text) & "',VASTaxAmt ='" & Val(lblVASTaxtotal.Text) & "',RoomRentTax ='" & Val(lblRoomRentTax.Text) & "', " & _
                            "CardAmt='" & Val(txtCardPayment.Text) & "',RefNo='" & txtRefNo.Text & "',AccountID='" & Val(cbBank.SelectedValue) & "',AccountName='" & cbBank.Text & "', " & _
                            "Remark2='" & txtRemark2.Text & "',SallerID='" & Val(7) & "',SallerName='" & clsFun.ExecScalarStr("Select AccountName From Accounts Where ID=7") & "' Where ID='" & Val(txtID.Text) & "'"
        Try
            If clsFun.ExecNonQuery(sql) > 0 Then
                txtID.Text = Val(clsFun.ExecScalarInt("Select Max(ID) from Vouchers"))
                clsFun.ExecScalarStr("Update Vouchers set ISBooked='" & Val(txtID.Text) & "' Where ID='" & Val(cbCheckinDetails.SelectedValue) & "'")
                clsFun.ExecScalarStr("Delete From Trans Where VoucherID=" & Val(txtID.Text) & "")
                clsFun.ExecScalarStr("Delete From VASTrans Where VoucherID=" & Val(txtID.Text) & "")
                clsFun.ExecScalarStr("Delete From Ledger Where VouchersID=" & Val(txtID.Text) & "")
                dg1Record() : VASRecord() : Ledger() : RoomRecord()
                MsgBox("Record Updated Succesfully", MsgBoxStyle.Information, "Updated")

                ' textclearall()
                ' clearTxtAll()
            End If
            clsFun.CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message)
            clsFun.CloseConnection()
        End Try
    End Sub

    Private Sub RoomRecord()
        Dim sql As String = String.Empty
        vchID = txtID.Text
        Dim RoomID As String = String.Empty
        Dim RoomNo As String = String.Empty
        Dim checkBox As DataGridViewCheckBoxCell
        For Each row As DataGridViewRow In dgRoom.Rows
            RoomID = RoomID & row.Cells(0).Value & ","
            RoomNo = RoomNo & row.Cells(1).Value & ","
        Next
        If RoomID <> "" Then
            RoomID = RoomID.Remove(RoomID.LastIndexOf(","))
            RoomNo = RoomNo.Remove(RoomNo.LastIndexOf(","))
        End If
        For Each row As DataGridViewRow In dgRoom.Rows
            With row
                If .Cells(0).Value = True Then
                    ' Dim Taxableamt As Decimal = Val(.Cells(7).Value) - Val(.Cells(6).Value)
                    sql = sql & ""
                    sql = sql & "INSERT INTO Trans (TransType,VoucherID,RoomID,RoomNo,StayDays,Rate,DisPer,DisAmt,BasicAmt,TaxableAmt,TaxPer,TaxAmt, " & _
                        "SgstPer,SgstAmt,CGSTPer,cgstAmt,IGSTPer,IGSTAmt,RoomVoucherID,RoomNos) values('" & Me.Text & "','" & Val(vchID) & "'," & _
                        "'" & .Cells(0).Value & "', '" & Val(.Cells(1).Value) & "','" & .Cells(3).Value & "','" & .Cells(4).Value & "', " & _
                         "'" & Val(.Cells(5).Value) & "','" & Val(.Cells(6).Value) & "','" & Val(.Cells(7).Value) & "','" & Val(Taxableamt) & "', " & _
                         "'" & Val(.Cells(9).Value) & "','" & Val(.Cells(10).Value) & "','" & IIf(cbGSTType.SelectedIndex = 0, Val(.Cells(9).Value) / 2, "0.00") & "', " & _
                         "'" & IIf(cbGSTType.SelectedIndex = 0, Val(.Cells(10).Value) / 2, "0.00") & "','" & IIf(cbGSTType.SelectedIndex = 0, Val(.Cells(9).Value) / 2, "0.00") & "', " & _
                         "'" & IIf(cbGSTType.SelectedIndex = 0, Val(.Cells(10).Value) / 2, "0.00") & "','" & IIf(cbGSTType.SelectedIndex = 0, "0.00", Format(Val(.Cells(9).Value), "0.00")) & "', " & _
                         "'" & IIf(cbGSTType.SelectedIndex = 0, "0.00", Format(Val(.Cells(10).Value), "0.00")) & "','" & RoomID & "','" & RoomNo & "');"
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
    Private Sub dg1Record()
        Dim sql As String = String.Empty
        Dim RoomID As String = String.Empty
        Dim RoomNo As String = String.Empty
        Dim checkBox As DataGridViewCheckBoxCell
        If dgRoom.RowCount <> 0 Then
            For Each row As DataGridViewRow In dgRoom.Rows
                RoomID = RoomID & row.Cells(0).Value & ","
                RoomNo = RoomNo & row.Cells(1).Value & ","
            Next
            RoomID = RoomID.Remove(RoomID.LastIndexOf(","))
            RoomNo = RoomNo.Remove(RoomNo.LastIndexOf(","))

            clsFun.ExecScalarStr("Update RestroTables Set IsBooked='N' Where ID in(" & TableNo & ")")
            clsFun.ExecScalarStr("Update KOTTrans Set IsOccupied='N' Where TableID in(" & TableNo & ")")
            clsFun.ExecScalarStr("Update KOTTrans Set Paid='Y' Where RoomVoucherID in(" & TableNo & ")")
        End If
        For Each row As DataGridViewRow In dg1.Rows
            With row
                If .Cells("ItemID").Value <> "" Then
                    sql = sql & ""
                    sql = sql & "INSERT INTO Trans (TransType,VoucherID,ItemID,ItemName,SNo,Per,Qty,Rate,BasicAmt,DisPer,DisAmt," & _
                        " TaxableAmt,TaxPer,TaxAmt,TotalAmt,SgstPer,SgstAmt,CGSTPer,cgstAmt,IGSTPer,IGSTAmt,TableID,TableNos,KotDate,RoomVoucherID,RoomNos)" & _
                        "values ('" & Me.Text & "','" & Val(txtID.Text) & "','" & Val(.Cells(0).Value) & "','" & .Cells(3).Value & "','" & .Cells(1).Value & "','" & .Cells(4).Value & "'," & _
                        "'" & Val(.Cells(5).Value) & "','" & .Cells(6).Value & "','" & .Cells(7).Value & "','" & Val(.Cells(8).Value) & "'," & _
                        "'" & Val(.Cells(9).Value) & "','" & Val(.Cells(13).Value) & "','" & Val(.Cells(10).Value) & "','" & Val(.Cells(11).Value) & "'," & _
                           "'" & Val(.Cells(12).Value) & "','" & IIf(cbGSTType.SelectedIndex = 0, Val(.Cells(10).Value) / 2, 0) & "'," & _
                        "'" & IIf(cbGSTType.SelectedIndex = 0, Val(.Cells(11).Value) / 2, 0) & "','" & IIf(cbGSTType.SelectedIndex = 0, Val(.Cells(10).Value) / 2, 0) & "', " & _
                        "'" & IIf(cbGSTType.SelectedIndex = 0, Val(.Cells(11).Value) / 2, 0) & "','" & IIf(cbGSTType.SelectedIndex = 0, 0, Val(.Cells(10).Value)) & "'," & _
                        "'" & IIf(cbGSTType.SelectedIndex = 0, 0, Val(.Cells(11).Value)) & "','" & "" & "','" & "" & "','" & .Cells(14).Value & "', " & _
                        "'" & Val(cbCheckinDetails.SelectedValue) & "','" & RoomNo & "');"
                End If
            End With
        Next
        Try
            cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
            If cmd.ExecuteNonQuery() > 0 Then count = +1
            'Dim KOTid As String = clsFun.ExecScalarStr("Select KOTid FROM KOTTrans where Tableid in('" & TableNo & "')")
            'If clsFun.ExecNonQuery("DELETE from KOT WHERE ID=" & Val(KOTid) & ";DELETE from KOTTrans WHERE KOTID=" & Val(KOTid) & "") > 0 Then
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
            clsFun.CloseConnection()
        End Try
        clsFun.CloseConnection()
    End Sub
    Private Sub VASRecord()
        Dim sql As String = String.Empty
        vchID = txtID.Text
        For Each row As DataGridViewRow In dgVas.Rows
            With row
                If .Cells(0).Value <> Val(0) Then
                    sql = sql & ""
                    sql = sql & "INSERT INTO VASTrans (VoucherID,VASID,VASName,OnValue,Rate,Amount,TaxID,TaxPer,TaxAmount,SGSTPer,SGSTAmt,CGSTPer,CGSTAmt,IGSTPer,IGSTAmt) values('" & Val(vchID) & "'," & _
                        "'" & .Cells(0).Value & "', '" & .Cells(1).Value & "','" & .Cells(2).Value & "','" & .Cells(3).Value & "', " & _
                         "'" & Val(.Cells(4).Value) & "','" & Val(.Cells(5).Value) & "', '" & Val(.Cells(6).Value) & "','" & Val(.Cells(7).Value) & "','" & IIf(cbGSTType.SelectedIndex = 0, Val(.Cells(6).Value) / 2, "0.00") & "', " & _
                         "'" & IIf(cbGSTType.SelectedIndex = 0, Val(.Cells(7).Value) / 2, "0.00") & "','" & IIf(cbGSTType.SelectedIndex = 0, Val(.Cells(6).Value) / 2, "0.00") & "', " & _
                         "'" & IIf(cbGSTType.SelectedIndex = 0, Val(.Cells(7).Value) / 2, "0.00") & "','" & IIf(cbGSTType.SelectedIndex = 0, "0.00", Format(Val(.Cells(6).Value), "0.00")) & "', " & _
                         "'" & IIf(cbGSTType.SelectedIndex = 0, "0.00", Format(Val(.Cells(7).Value), "0.00")) & "');"
                End If
            End With
        Next
        Try
            cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
            If cmd.ExecuteNonQuery() > 0 Then

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            clsFun.CloseConnection()
        End Try
        clsFun.CloseConnection()
    End Sub
    Private Sub txtTotalCash_TextChanged(sender As Object, e As EventArgs) Handles txtTotalCash.TextChanged
        txtTotalChangeAmt.Text = Format(Val(TxtTotalAmount.Text) - Val(txtTotalCash.Text), "0.00")
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub
    Private Sub mskCheckinDate_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles mskCheckinDate.MaskInputRejected

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub txtinvoiceNo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtinvoiceNo.KeyDown
        If e.KeyCode = Keys.F4 Then
            txtInvoiceID.Focus()
            txtInvoiceID.Visible = True
        End If
    End Sub
    Private Sub txtInvoiceID_Leave(sender As Object, e As EventArgs)
        txtInvoiceID.Visible = False
    End Sub

    Private Sub txtCardPayment_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCardPayment.KeyDown, txtRefNo.KeyDown,
    cbBank.KeyDown, txtRemark2.KeyDown
        If cbBank.Focused Then
            If e.KeyCode = Keys.F3 Then
                CreateAccount.MdiParent = MainScreenForm
                CreateAccount.Show()
                CreateAccount.BringToFront()
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btnCrardPayment.Click
        pnlCreditBalance.Visible = True
        pnlCreditBalance.BringToFront()
        txtCardPayment.Focus()
    End Sub
    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        pnlCreditBalance.Visible = False : BtnSave.PerformClick()
    End Sub
    Private Sub txtCardPayment_TextChanged(sender As Object, e As EventArgs) Handles txtCardPayment.TextChanged
        If Val(txtCardPayment.Text) <> 0 Then
            txtTotalChangeAmt.Text = Format(Val(TxtTotalAmount.Text) - (Val(txtCardPayment.Text) + Val(txtTotalCash.Text)), "0.00")
            ' cbBank.SelectedIndex = 0
            cbBank.Enabled = True
        Else
            cbBank.SelectedIndex = -1
            cbBank.SelectedValue = 0
            cbBank.Text = ""
            cbBank.Enabled = False
        End If
    End Sub

    Private Sub pnlCreditBalance_VisibleChanged(sender As Object, e As EventArgs) Handles pnlCreditBalance.VisibleChanged
        If pnlCreditBalance.Visible = True Then
            clsFun.FillDropDownList(cbBank, "Select ID,AccountName From Account_AcGrp where (Groupid in(12,16)  or UnderGroupID in (12,16))", "AccountName", "Id", "")
        End If
    End Sub


    Private Sub cbBank_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbBank.SelectedIndexChanged

    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If BtnSave.Text = "&Save" Then Exit Sub
        Delete()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        pnlCreditBalance.Visible = False
    End Sub

    Private Sub dtpEntryDate_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpEntryDate.KeyDown

    End Sub

    Private Sub dtpEntryDate_KeyUp(sender As Object, e As KeyEventArgs) Handles dtpEntryDate.KeyUp
        If e.KeyCode.Enter Then
            mskEntryDate.Focus()
            mskEntryDate.SelectionLength = Len(mskCheckinDate.Text)
        End If
    End Sub

    Private Sub dtpEntryDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpEntryDate.ValueChanged
        mskEntryDate.Text = dtpEntryDate.Value.ToString("dd-MM-yyyy")
        mskEntryDate.Text = clsFun.convdate(mskEntryDate.Text)
    End Sub

    Private Sub dtpCheckDateEntry_KeyUp(sender As Object, e As KeyEventArgs) Handles dtpCheckDateEntry.KeyUp
        If e.KeyCode.Enter Then
            mskCheckinDate.Focus()
            mskCheckinDate.SelectionLength = Len(mskCheckinDate.Text)
        End If
    End Sub

    Private Sub dtpCheckDateEntry_ValueChanged(sender As Object, e As EventArgs) Handles dtpCheckDateEntry.ValueChanged
        mskCheckinDate.Text = dtpCheckDateEntry.Value.ToString("dd-MM-yyyy")
        mskCheckinDate.Text = clsFun.convdate(mskCheckinDate.Text)
    End Sub

    Private Sub dtpCheckOutEntry_KeyUp(sender As Object, e As KeyEventArgs) Handles dtpCheckOutEntry.KeyUp
        If e.KeyCode.Enter Then
            mskCheckOutDate.Focus()
            mskCheckOutDate.SelectionLength = Len(mskCheckOutDate.Text)
        End If
    End Sub

    Private Sub dtpCheckOutEntry_ValueChanged(sender As Object, e As EventArgs) Handles dtpCheckOutEntry.ValueChanged
        mskCheckOutDate.Text = dtpCheckOutEntry.Value.ToString("dd-MM-yyyy")
        mskCheckOutDate.Text = clsFun.convdate(mskCheckOutDate.Text)
    End Sub

    Private Sub txtinvoiceNo_TextChanged(sender As Object, e As EventArgs) Handles txtinvoiceNo.TextChanged

    End Sub
End Class