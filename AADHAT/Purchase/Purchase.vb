'Imports Microsoft.Office.Interop.Excel
Public Class Purchase
    Dim CalcType As String = String.Empty
    Dim PrintCopies As String : Dim Hash As String
    Dim IGSTPER As Decimal : Dim IGSTAMT As Decimal
    Dim SGSTPER As Decimal : Dim SGSTAMT As Decimal
    Dim CGSTPER As Decimal : Dim CGSTAMT As Decimal
    Dim CessPer As Decimal : Dim CessAmt As Decimal
    Dim ItemTotalTax As Decimal : Dim TaxableTotal As Decimal
    Dim taxableamt As Decimal = 0.0 : Dim taxamtIGST As Decimal = 0.0
    Dim taxamtSGST As Decimal = 0.0 : Dim taxamtCGST As Decimal = 0.0
    Dim TotalTax As Decimal = 0.0 : Dim TotalIGST As Decimal = 0.0
    Dim TotalSGST As Decimal = 0.0 : Dim TotalCGST As Decimal = 0.0
    Dim TotalCess As Decimal = 0.0 : Dim SpeCess As Decimal = 0.0
    Dim taxamt As Decimal = 0.0 : Dim freeqty As Decimal = 0.0
    Private headerCheckBox As CheckBox = New CheckBox()
    Dim StockMaintain As String : Dim tmpOpMain As Decimal
    Dim tmpOpAlt As Decimal : Dim chargeTaxableTotal As Decimal
    Dim CessAsOn As String : Dim SpeCessOn As String
    Dim ItemWarning As String : Dim ItemRO As String
    Dim TotalRO As String : Dim altunitMainUnit As Decimal
    Dim UNRegSupplies As String
    Dim TotalPages As Integer = 0 : Dim PageNumber As Integer = 0
    Dim RowCount As Integer = 1 : Dim Offset As Integer = 0
    Private Sub Purchase_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F9 Then pnlEway.Visible = True : txtEwayBillNo.Focus() : Exit Sub
        If e.KeyCode = Keys.Escape Then
            If DgAccountSearch.Visible = True Then DgAccountSearch.Visible = False : Exit Sub
            If pnlCustomerInfo.Visible = True Then pnlCustomerInfo.Visible = False : txtItem.Focus() : Exit Sub
            If dgItemSearch.Visible = True Then dgItemSearch.Visible = False : txtItem.Focus() : Exit Sub
            If dgCharges.Visible = True Then dgCharges.Visible = False : Exit Sub
            If PnlPrint.Visible = True Then PnlPrint.Visible = False : mskEntryDate.Focus() : Exit Sub
            If pnlEway.Visible = True Then pnlEway.Visible = False : BtnSave.Focus() : Exit Sub
            If pnlSerial.Visible = True Then pnlSerial.Visible = False : txtQty.Focus() : Exit Sub
            If Val(dg1.Rows.Count) > 0 Then
                If MessageBox.Show("Are you Sure want to Exit Purchase ?", "Exit Purchase Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    e.SuppressKeyPress = True
                    Me.SuspendLayout() : Me.Dispose()
                End If
            Else
                Me.SuspendLayout() : Me.Dispose()
            End If
        End If
      
        'If e.KeyCode = Keys.Escape Then
        '    If DgAccountSearch.Visible = True Then DgAccountSearch.Visible = False : Exit Sub
        '    If dgItemSearch.Visible = True Then dgItemSearch.Visible = False : Exit Sub
        '    If dgCharges.Visible = True Then dgCharges.Visible = False : Exit Sub
        '    If pnlCustomerInfo.Visible = True Then pnlCustomerInfo.Visible = False : cbSeries.Focus() : Exit Sub
        '    If PnlPrint.Visible = True Then PnlPrint.Visible = False : mskEntryDate.Focus() : Exit Sub
        '    If pnlSerial.Visible = True Then pnlSerial.Visible = False : txtQty.Focus() : Exit Sub
        '    If dg1.Rows.Count > 0 Then
        '        If MessageBox.Show("Are you Sure want to Exit Purchase ?", "Exit Purchase Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        '            Me.SuspendLayout() : Me.Dispose()
        '        End If
        '    Else
        '        Me.SuspendLayout() : Me.Dispose()
        '    End If
        'End If
    End Sub
    Private Sub dtp1_GotFocus(sender As Object, e As EventArgs) Handles dtp1.GotFocus
        mskEntryDate.Focus()
    End Sub

    Private Sub dtp1_ValueChanged(sender As Object, e As EventArgs) Handles dtp1.ValueChanged
        mskEntryDate.Text = dtp1.Value.ToString("dd-MM-yyyy")
        mskEntryDate.Text = clsFun.convdate(mskEntryDate.Text)
    End Sub
    Private Sub Purchase_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0 : Me.Left = 0
        Me.BackColor = Color.FromArgb(169, 223, 191)
        mskEntryDate.Text = Date.Today.ToString("dd-MM-yyyy")
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        mskEntryDate.Focus() : VNumber() : rowColums() : serialRowColums()
        Me.KeyPreview = True : ImportControls()
        Hash = "0.00" 'clsFun.ExecScalarStr("Select DecimalFormat From Controls")
        clsFun.FillDropDownList(cbSeries, "Select ID,HeadingName ||' : '||TaxType as HeadingName From TaxSetting Where ApplyOn= 'Purchase'", "HeadingName", "Id", "")
        clsFun.FillDropDownList(cbPricePer, "Select RateID,RatePer from Items  Where ID=" & Val(txtItemID.Text) & " Group by RateID", "RatePer", "RateID", "")
        cbState.Text = clsFun.ExecScalarStr("Select State From Company") : txtStateCode.Text = Format(Val(clsFun.ExecScalarStr("Select StateCode From Company")), "00")
        cbGSTtype.SelectedIndex = 0
    End Sub

    Public Sub ImportControls()
        Hash = "0.00" 'clsFun.ExecScalarStr("Select DecimalFormat From Controls")
        'StockMaintain = clsFun.ExecScalarStr("Select DecimalFormat From Controls")
        'StockMaintain = clsFun.ExecScalarStr("Select DecimalFormat From Controls")
    End Sub
    Private Sub serialRowColums()
        dgSerial.ColumnCount = 7
        dgSerial.Columns(0).Name = "ItemID" : dgSerial.Columns(0).Visible = False
        dgSerial.Columns(1).Name = "SerialID" : dgSerial.Columns(1).Visible = False
        dgSerial.Columns(2).Name = "SNo1" : dgSerial.Columns(2).Width = 139
        dgSerial.Columns(3).Name = "SNo2" : dgSerial.Columns(3).Width = 139
        dgSerial.Columns(4).Name = "SNo3" : dgSerial.Columns(4).Width = 139
        dgSerial.Columns(5).Name = "SNo4" : dgSerial.Columns(5).Width = 139
        dgSerial.Columns(6).Name = "SNo5" : dgSerial.Columns(6).Width = 139
    End Sub

    Private Sub TempRowColumn()
        With tmpgrid
            .ColumnCount = 151
            .Columns(0).Name = "ID" : .Columns(0).Visible = False
            .Columns(1).Name = "EntryDate" : .Columns(1).Width = 95
            .Columns(2).Name = "InvoiceNo" : .Columns(2).Width = 159
            .Columns(3).Name = "AccountName" : .Columns(3).Width = 59
            .Columns(4).Name = "ItemName" : .Columns(4).Width = 59
            .Columns(5).Name = "HSNCode" : .Columns(5).Width = 59
            .Columns(6).Name = "Unit" : .Columns(6).Width = 59
            .Columns(7).Name = "BrandName" : .Columns(7).Width = 59
            .Columns(8).Name = "Section" : .Columns(8).Width = 59
            .Columns(9).Name = "Batch" : .Columns(9).Width = 159
            .Columns(10).Name = "SizeName" : .Columns(10).Width = 69
            .Columns(11).Name = "ColorName" : .Columns(11).Width = 76
            .Columns(12).Name = "Qty" : .Columns(12).Width = 90
            .Columns(13).Name = "Rate" : .Columns(13).Width = 86
            .Columns(14).Name = "Net" : .Columns(14).Width = 90
            .Columns(15).Name = "DisPer" : .Columns(15).Width = 50
            .Columns(16).Name = "DisAmt" : .Columns(16).Width = 95
            .Columns(17).Name = "TaxPer" : .Columns(17).Width = 159
            .Columns(18).Name = "TaxAmt" : .Columns(18).Width = 159
            .Columns(19).Name = "TotalAmt" : .Columns(19).Width = 59
            .Columns(20).Name = "RoundOff" : .Columns(20).Width = 59
            .Columns(21).Name = "NetRate" : .Columns(21).Width = 69
            .Columns(22).Name = "Taxable" : .Columns(22).Width = 76
            .Columns(23).Name = "IGSTamt" : .Columns(23).Width = 90
            .Columns(24).Name = "IGSTPer" : .Columns(24).Width = 86
            .Columns(25).Name = "IGSTAmt" : .Columns(25).Width = 90
            .Columns(26).Name = "SGSTPer" : .Columns(26).Width = 90
            .Columns(27).Name = "SGSTAmt" : .Columns(27).Width = 95
            .Columns(28).Name = "CGSTPer" : .Columns(28).Width = 159
            .Columns(29).Name = "CGSTAmt" : .Columns(29).Width = 159
            .Columns(30).Name = "CessPer" : .Columns(30).Width = 90
            .Columns(31).Name = "CessAmt" : .Columns(31).Width = 86
            .Columns(32).Name = "TaxName" : .Columns(32).Width = 86
            .Columns(33).Name = "TotalQty" : .Columns(33).Width = 90
            .Columns(34).Name = "TotalNetAmt" : .Columns(34).Width = 90
            .Columns(35).Name = "TotalDisPer" : .Columns(35).Width = 95
            .Columns(36).Name = "TotalDisAmt" : .Columns(36).Width = 159
            .Columns(37).Name = "TotalTaxPer" : .Columns(37).Width = 159
            .Columns(38).Name = "TotalTaxAmt" : .Columns(38).Width = 90
            .Columns(39).Name = "TotalCharges" : .Columns(39).Width = 90
            .Columns(40).Name = "TotalRoundOff" : .Columns(40).Width = 95
            .Columns(41).Name = "TotalGrand" : .Columns(41).Width = 159
            .Columns(42).Name = "TotalCashAmt" : .Columns(42).Width = 159
            .Columns(43).Name = "TotalDueAmt" : .Columns(43).Width = 159

            .Columns(44).Name = "HeadName1" : .Columns(44).Width = 159
            .Columns(45).Name = "Onvalue1" : .Columns(45).Width = 159
            .Columns(46).Name = "Cal1" : .Columns(46).Width = 159
            .Columns(47).Name = "Amount1" : .Columns(47).Width = 159

            .Columns(48).Name = "HeadName2" : .Columns(48).Width = 159
            .Columns(59).Name = "Onvalue2" : .Columns(49).Width = 159
            .Columns(50).Name = "Cal2" : .Columns(50).Width = 159
            .Columns(51).Name = "Amount2" : .Columns(51).Width = 159

            .Columns(52).Name = "HeadName3" : .Columns(52).Width = 159
            .Columns(53).Name = "Onvalue3" : .Columns(53).Width = 159
            .Columns(54).Name = "Cal3" : .Columns(54).Width = 159
            .Columns(55).Name = "Amount3" : .Columns(55).Width = 159

            .Columns(56).Name = "HeadName4" : .Columns(56).Width = 159
            .Columns(57).Name = "Onvalue4" : .Columns(57).Width = 159
            .Columns(58).Name = "Cal4" : .Columns(58).Width = 159
            .Columns(59).Name = "Amount4" : .Columns(59).Width = 159

            .Columns(60).Name = "DisPer" : .Columns(60).Width = 159
            .Columns(61).Name = "DisAmt" : .Columns(61).Width = 159

            .Columns(62).Name = "Serial1" : .Columns(62).Width = 159
            .Columns(63).Name = "Serial2" : .Columns(63).Width = 159
            .Columns(64).Name = "Serial3" : .Columns(64).Width = 159
            .Columns(65).Name = "Serial4" : .Columns(65).Width = 159
            .Columns(66).Name = "Serial5" : .Columns(66).Width = 159

            .Columns(67).Name = "CustomerName" : .Columns(61).Width = 159
            .Columns(68).Name = "CustomerAdd" : .Columns(62).Width = 159
            .Columns(69).Name = "CustomerMob" : .Columns(63).Width = 159
            .Columns(70).Name = "CustomerState" : .Columns(64).Width = 159
            .Columns(71).Name = "CustomerStateCode" : .Columns(65).Width = 159
            .Columns(72).Name = "CustomerGSTN" : .Columns(66).Width = 159
            .Columns(73).Name = "TotIGSTamt" : .Columns(67).Width = 159
            .Columns(74).Name = "TotSGSTamt" : .Columns(68).Width = 159
            .Columns(75).Name = "TotCGSTamt" : .Columns(69).Width = 159



            ''''Optional Fileds
            .Columns(76).Name = "" : .Columns(76).Width = 159
            .Columns(77).Name = "" : .Columns(77).Width = 159
            .Columns(78).Name = "" : .Columns(78).Width = 159
            .Columns(79).Name = "" : .Columns(79).Width = 159
            .Columns(80).Name = "" : .Columns(80).Width = 159
            .Columns(81).Name = "" : .Columns(81).Width = 159
            .Columns(82).Name = "" : .Columns(82).Width = 159
            .Columns(83).Name = "" : .Columns(83).Width = 159

            '''''

            .Columns(84).Name = "ChargeName" : .Columns(84).Width = 159
            .Columns(85).Name = "OnValue" : .Columns(85).Width = 159
            .Columns(86).Name = "@" : .Columns(86).Width = 159
            .Columns(87).Name = "+/-" : .Columns(87).Width = 159
            .Columns(88).Name = "ChargeAmt" : .Columns(88).Width = 159
            .Columns(89).Name = "TaxName" : .Columns(89).Width = 159
            .Columns(90).Name = "Taxper" : .Columns(90).Width = 159
            .Columns(91).Name = "TaxAmt" : .Columns(91).Width = 159
            .Columns(92).Name = "Taxable" : .Columns(92).Width = 159
            .Columns(93).Name = "IGSTPer" : .Columns(93).Width = 159
            .Columns(94).Name = "IGSTAmt" : .Columns(94).Width = 159
            .Columns(95).Name = "SGSTPer" : .Columns(95).Width = 159
            .Columns(96).Name = "SGSTAmt" : .Columns(96).Width = 159
            .Columns(97).Name = "CGSTPer" : .Columns(97).Width = 159
            .Columns(98).Name = "CGSTAmt" : .Columns(98).Width = 159
            .Columns(99).Name = "CessPer" : .Columns(99).Width = 159
            .Columns(100).Name = "CessAmt" : .Columns(100).Width = 159

            .Columns(101).Name = "TaxAmt" : .Columns(101).Width = 159
            .Columns(102).Name = "Taxable" : .Columns(102).Width = 159
            .Columns(103).Name = "IGSTPer" : .Columns(103).Width = 159
            .Columns(104).Name = "IGSTAmt" : .Columns(104).Width = 159
            .Columns(105).Name = "SGSTPer" : .Columns(105).Width = 159
            .Columns(106).Name = "SGSTAmt" : .Columns(106).Width = 159
            .Columns(107).Name = "CGSTPer" : .Columns(107).Width = 159
            .Columns(108).Name = "CGSTAmt" : .Columns(108).Width = 159
            .Columns(109).Name = "CessPer" : .Columns(109).Width = 159
            .Columns(110).Name = "CessAmt" : .Columns(110).Width = 159

            .Columns(111).Name = "Field1" : .Columns(111).Width = 159
            .Columns(112).Name = "Field2" : .Columns(112).Width = 159
            .Columns(113).Name = "Field3" : .Columns(113).Width = 159
            .Columns(114).Name = "Field4" : .Columns(114).Width = 159
            .Columns(115).Name = "Field5" : .Columns(115).Width = 159
            .Columns(116).Name = "Field6" : .Columns(116).Width = 159
            .Columns(117).Name = "Field7" : .Columns(117).Width = 159
            .Columns(118).Name = "Field8" : .Columns(118).Width = 159
            .Columns(119).Name = "Field9" : .Columns(119).Width = 159
            .Columns(120).Name = "Field10" : .Columns(120).Width = 159
            .Columns(121).Name = "Field11" : .Columns(121).Width = 159
            .Columns(122).Name = "Field12" : .Columns(122).Width = 159
            .Columns(123).Name = "Field13" : .Columns(123).Width = 159
            .Columns(124).Name = "Field14" : .Columns(124).Width = 159
            .Columns(125).Name = "Field15" : .Columns(125).Width = 159
            .Columns(126).Name = "Field16" : .Columns(126).Width = 159
            .Columns(127).Name = "Field17" : .Columns(127).Width = 159
            .Columns(128).Name = "Field18" : .Columns(128).Width = 159
            .Columns(129).Name = "Field19" : .Columns(129).Width = 159
            .Columns(130).Name = "Field20" : .Columns(130).Width = 159
            '''Eway Bill Details
            .Columns(131).Name = "EwayBillNo" : .Columns(131).Width = 159
            .Columns(132).Name = "EwayBillDate" : .Columns(132).Width = 159
            .Columns(133).Name = "SubType" : .Columns(133).Width = 159
            .Columns(134).Name = "DocumentType" : .Columns(134).Width = 159
            .Columns(135).Name = "MOT" : .Columns(135).Width = 159
            .Columns(136).Name = "FromPinCode" : .Columns(136).Width = 159
            .Columns(137).Name = "ToPinCode" : .Columns(137).Width = 159
            .Columns(138).Name = "Distance" : .Columns(138).Width = 159
            .Columns(139).Name = "VehicleNo" : .Columns(139).Width = 159
            .Columns(140).Name = "TPName" : .Columns(140).Width = 159
            .Columns(141).Name = "LRNo" : .Columns(141).Width = 159
            .Columns(142).Name = "Dated" : .Columns(142).Width = 159
            .Columns(143).Name = "TPID" : .Columns(143).Width = 159
            '''Item FIleds
            .Columns(144).Name = "Item1" : .Columns(144).Width = 159
            .Columns(145).Name = "Item2" : .Columns(145).Width = 159
            .Columns(146).Name = "Item3" : .Columns(146).Width = 159
            .Columns(147).Name = "Item4" : .Columns(147).Width = 159
            .Columns(148).Name = "Item5" : .Columns(148).Width = 159
            .Columns(149).Name = "Item6" : .Columns(149).Width = 159
            .Columns(150).Name = "Item7" : .Columns(150).Width = 159
        End With
    End Sub
    Sub retrive2(ByVal id As String, Optional ByVal condtion As String = "")
        Dim i, j As Integer
        Dim dt As New DataTable
        Dim dt1 As New DataTable
        Dim dt2 As New DataTable
        Dim cnt As Integer = -1
        tmpgrid.Rows.Clear()
        Dim sql As String = "SELECT * FROM Vouchers AS V INNER JOIN Trans1 AS T1 ON V.ID = T1.VoucherID " & _
                            "INNER JOIN Accounts As A ON V.AccountID = A.ID INNER JOIN Items " & _
                            " AS I ON T1.ItemID = I.ID  Where V.ID = " & Val(id) & ""
        dt = clsFun.ExecDataTable(sql)
        If dt.Rows.Count = 0 Then Exit Sub
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                Application.DoEvents()
                tmpgrid.Rows.Add()
                cnt = cnt + 1
                With tmpgrid.Rows(cnt)
                    .Cells(1).Value = Format(dt.Rows(i)("EntryDate"), "dd-MM-yyyy")
                    .Cells(2).Value = .Cells(2).Value & dt.Rows(i)("BillNo").ToString()
                    ' .Cells(3).Value = dt.Rows(i)("AccountName").ToString()
                    .Cells(3).Value = .Cells(5).Value & dt.Rows(i)("ItemName").ToString()
                    .Cells(4).Value = .Cells(5).Value & dt.Rows(i)("HSNCode").ToString()
                    .Cells(5).Value = dt.Rows(i)("ItemCode").ToString()
                    .Cells(6).Value = .Cells(6).Value & dt.Rows(i)("UnitName").ToString()
                    .Cells(7).Value = .Cells(7).Value & dt.Rows(i)("BrandName").ToString()
                    .Cells(8).Value = .Cells(8).Value & dt.Rows(i)("SectionName").ToString()
                    .Cells(9).Value = .Cells(9).Value & dt.Rows(i)("BatchNo").ToString()
                    .Cells(10).Value = .Cells(10).Value & dt.Rows(i)("SizeName").ToString()
                    .Cells(11).Value = .Cells(11).Value & dt.Rows(i)("ColorName").ToString()
                    .Cells(12).Value = .Cells(12).Value & IIf(Val(dt.Rows(i)("FreeQty").ToString()) > 0, Val(dt.Rows(i)("Qty").ToString()) & "+" & Val(dt.Rows(i)("FreeQty").ToString()), Val(dt.Rows(i)("Qty").ToString()))
                    .Cells(13).Value = .Cells(13).Value & Format(Val(dt.Rows(i)("Rate").ToString()), Hash)
                    .Cells(14).Value = .Cells(14).Value & Format(Val(dt.Rows(i)("NetRate").ToString()), Hash)
                    .Cells(15).Value = .Cells(15).Value & Format(Val(dt.Rows(i)("DiscPer").ToString()), Hash)
                    .Cells(16).Value = .Cells(16).Value & Format(Val(dt.Rows(i)("DiscAmount").ToString()), Hash)
                    .Cells(17).Value = .Cells(17).Value & Format(Val(dt.Rows(i)("TaxPer").ToString()), Hash)
                    .Cells(18).Value = .Cells(18).Value & Format(Val(dt.Rows(i)("TaxAmount").ToString()), Hash)
                    .Cells(19).Value = .Cells(19).Value & Format(Val(dt.Rows(i)("TotalAmount1").ToString()), Hash)
                    .Cells(20).Value = .Cells(20).Value & Format(Val(dt.Rows(i)("RoundOff").ToString()), Hash)
                    .Cells(21).Value = .Cells(21).Value & Format(Val(dt.Rows(i)("NetRate").ToString()), Hash)
                    .Cells(22).Value = .Cells(22).Value & Format(Val(dt.Rows(i)("TaxableAmount").ToString()), Hash)
                    .Cells(23).Value = .Cells(23).Value & Format(Val(dt.Rows(i)("IGSTPer").ToString()), Hash)
                    .Cells(24).Value = .Cells(24).Value & Format(Val(dt.Rows(i)("IGSTAmt").ToString()), Hash)
                    .Cells(26).Value = .Cells(26).Value & Format(Val(dt.Rows(i)("SGSTPer").ToString()), Hash)
                    .Cells(27).Value = .Cells(27).Value & Format(Val(dt.Rows(i)("SGSTAmt").ToString()), Hash)
                    .Cells(28).Value = .Cells(28).Value & Format(Val(dt.Rows(i)("CGSTPer").ToString()), Hash)
                    .Cells(29).Value = .Cells(29).Value & Format(Val(dt.Rows(i)("CGSTAmt").ToString()), Hash)
                    .Cells(30).Value = .Cells(30).Value & Format(Val(dt.Rows(i)("CessPer").ToString()), Hash)
                    .Cells(31).Value = .Cells(31).Value & Format(Val(dt.Rows(i)("CessAmt").ToString()), Hash)
                    .Cells(32).Value = .Cells(32).Value & Format(Val(dt.Rows(i)("TaxName").ToString()), Hash)
                    .Cells(33).Value = Val(dt.Rows(i)("TotQty").ToString())
                    .Cells(34).Value = Format(Val(dt.Rows(i)("basicAmount").ToString()), Hash)
                    .Cells(35).Value = Format(Val(dt.Rows(i)("DiscountAmount").ToString()), Hash)
                    .Cells(36).Value = Format(Val(dt.Rows(i)("CdPer").ToString()), Hash)
                    .Cells(37).Value = Format(Val(dt.Rows(i)("CdAmount").ToString()), Hash)
                    .Cells(38).Value = Format(Val(dt.Rows(i)("GstAmt").ToString()), Hash)
                    .Cells(39).Value = Format(Val(dt.Rows(i)("AfterCharges").ToString()), Hash)
                    .Cells(40).Value = Format(Val(dt.Rows(i)("RoundOff").ToString()), Hash)
                    .Cells(41).Value = Format(Val(dt.Rows(i)("TotalAmount").ToString()), Hash)
                    .Cells(42).Value = Format(Val(dt.Rows(i)("TotalCashAmount").ToString()), Hash)
                    .Cells(43).Value = Format(Val(dt.Rows(i)("TotalDueAmount").ToString()), Hash)

                    .Cells(44).Value = dt.Rows(i)("DisName1").ToString()
                    .Cells(45).Value = If(Val(dt.Rows(i)("DisOnValue1").ToString()) > 0, Format(Val(dt.Rows(i)("DisOnValue1").ToString()), Hash), "")
                    .Cells(46).Value = If(Val(dt.Rows(i)("DisCal1").ToString()) > 0, Format(Val(dt.Rows(i)("DisCal1").ToString()), Hash), "")
                    .Cells(47).Value = If(Val(dt.Rows(i)("DisAmt1").ToString()) > 0, Format(Val(dt.Rows(i)("DisAmt1").ToString()), Hash), "")

                    .Cells(48).Value = dt.Rows(i)("DisName2").ToString()
                    .Cells(49).Value = If(Val(dt.Rows(i)("DisOnValue2").ToString()) > 0, Format(Val(dt.Rows(i)("DisOnValue2").ToString()), Hash), "")
                    .Cells(50).Value = If(Val(dt.Rows(i)("DisCal2").ToString()) > 0, Format(Val(dt.Rows(i)("DisCal2").ToString()), Hash), "")
                    .Cells(51).Value = If(Val(dt.Rows(i)("DisAmt2").ToString()) > 0, Format(Val(dt.Rows(i)("DisAmt2").ToString()), Hash), "")

                    .Cells(52).Value = dt.Rows(i)("DisName3").ToString()
                    .Cells(53).Value = If(Val(dt.Rows(i)("DisOnValue3").ToString()) > 0, Format(Val(dt.Rows(i)("DisOnValue3").ToString()), Hash), "")
                    .Cells(54).Value = If(Val(dt.Rows(i)("DisCal3").ToString()) > 0, Format(Val(dt.Rows(i)("DisCal3").ToString()), Hash), "")
                    .Cells(55).Value = If(Val(dt.Rows(i)("DisAmt3").ToString()) > 0, Format(Val(dt.Rows(i)("DisAmt3").ToString()), Hash), "")

                    .Cells(56).Value = dt.Rows(i)("DisName4").ToString()
                    .Cells(57).Value = If(Val(dt.Rows(i)("DisOnValue4").ToString()) > 0, Format(Val(dt.Rows(i)("DisOnValue4").ToString()), Hash), "")
                    .Cells(58).Value = If(Val(dt.Rows(i)("DisCal4").ToString()) > 0, Format(Val(dt.Rows(i)("DisCal4").ToString()), Hash), "")
                    .Cells(59).Value = If(Val(dt.Rows(i)("DisAmt4").ToString()) > 0, Format(Val(dt.Rows(i)("DisAmt4").ToString()), Hash), "")

                    .Cells(60).Value = If(Val(dt.Rows(i)("CDPer").ToString()) > 0, Val(dt.Rows(i)("CDPer").ToString()) & "%", "")
                    .Cells(61).Value = If(Val(dt.Rows(i)("CdAmt").ToString()) > 0, Format(Val(dt.Rows(i)("CdAmt").ToString()), Hash), "")

                    dt2 = clsFun.ExecDataTable("Select * FROM Serials WHERE VoucherID=" & Val(dt.Rows(i)("ID").ToString()) & " and ItemID=" & Val(dt.Rows(i)("ItemID").ToString()) & " and SerialID= " & Val(dt.Rows(i)("AltQty").ToString()) & "")
                    '  tmpgrid.Rows.Clear()
                    'Serial Record
                    Dim Serial1 As String = String.Empty : Dim Serial2 As String = String.Empty
                    Dim Serial3 As String = String.Empty : Dim Serial4 As String = String.Empty
                    Dim Serial5 As String = String.Empty
                    If dt2.Rows.Count > 0 Then
                        For k = 0 To dt2.Rows.Count - 1
                            Serial1 = Serial1 & dt2.Rows(k)("SerialNo1").ToString() & ","
                            Serial2 = Serial2 & dt2.Rows(k)("SerialNo2").ToString() & ","
                            Serial3 = Serial3 & dt2.Rows(k)("SerialNo3").ToString() & ","
                            Serial4 = Serial4 & dt2.Rows(k)("SerialNo4").ToString() & ","
                            Serial5 = Serial5 & dt2.Rows(k)("SerialNo5").ToString() & ","
                        Next
                    End If
                    'IIf(Serial1 = "", "", Serial1.Remove(Serial1.LastIndexOf(",")))
                    If Serial1 = String.Empty Then Serial1 = "" Else Serial1 = Serial1.Remove(Serial1.LastIndexOf(","))
                    If Serial2 = String.Empty Then Serial2 = "" Else Serial2 = Serial2.Remove(Serial2.LastIndexOf(","))
                    If Serial3 = String.Empty Then Serial3 = "" Else Serial3 = Serial3.Remove(Serial3.LastIndexOf(","))
                    If Serial4 = String.Empty Then Serial4 = "" Else Serial4 = Serial4.Remove(Serial4.LastIndexOf(","))
                    If Serial5 = String.Empty Then Serial5 = "" Else Serial5 = Serial5.Remove(Serial5.LastIndexOf(","))
                    .Cells(62).Value = Serial1
                    .Cells(63).Value = Serial2
                    .Cells(64).Value = Serial3
                    .Cells(65).Value = Serial4
                    .Cells(66).Value = Serial5

                    If Val(dt.Rows(i)("AccountID").ToString()) = 7 Then
                        .Cells(67).Value = dt.Rows(i)("T1").ToString()
                        .Cells(68).Value = dt.Rows(i)("T2").ToString()
                        .Cells(69).Value = dt.Rows(i)("T3").ToString()
                        .Cells(70).Value = dt.Rows(i)("T4").ToString()
                        .Cells(71).Value = Format(Val(dt.Rows(i)("T5").ToString()), "00")
                        .Cells(72).Value = dt.Rows(i)("T6").ToString()
                        .Cells(76).Value = "Cash"
                    Else
                        .Cells(67).Value = dt.Rows(i)("AccountName").ToString()
                        .Cells(68).Value = dt.Rows(i)("Address").ToString() & dt.Rows(i)("City").ToString()
                        .Cells(69).Value = dt.Rows(i)("Mobile1").ToString() & IIf(dt.Rows(i)("Mobile2").ToString() = "", dt.Rows(i)("Mobile2").ToString(), ", " & dt.Rows(i)("Mobile2").ToString())
                        .Cells(70).Value = dt.Rows(i)("State").ToString()
                        .Cells(71).Value = Format(Val(dt.Rows(i)("StateCode").ToString()), "00")
                        .Cells(72).Value = dt.Rows(i)("GSTNo").ToString()
                        .Cells(76).Value = "Credit"
                    End If
                    .Cells(73).Value = Format(Val(dt.Rows(i)("TotIGSTamt").ToString()), Hash)
                    .Cells(74).Value = Format(Val(dt.Rows(i)("TotSGSTamt").ToString()), Hash)
                    .Cells(75).Value = Format(Val(dt.Rows(i)("TotCGSTamt").ToString()), Hash)

                    .Cells(77).Value = If(Val(dt.Rows(i)("CDAmount").ToString()) > 0, Format(Val(dt.Rows(i)("CDAmount").ToString()), Hash), "")
                    .Cells(78).Value = ""
                    .Cells(79).Value = ""
                    .Cells(80).Value = ""
                    .Cells(81).Value = ""
                    .Cells(82).Value = ""
                    .Cells(83).Value = ""

                    '''Additional Fields
                    .Cells(111).Value = dt.Rows(i)("Field1").ToString()
                    .Cells(112).Value = dt.Rows(i)("Field2").ToString()
                    .Cells(113).Value = dt.Rows(i)("Field3").ToString()
                    .Cells(114).Value = dt.Rows(i)("Field4").ToString()
                    .Cells(115).Value = dt.Rows(i)("Field5").ToString()
                    .Cells(116).Value = dt.Rows(i)("Field6").ToString()
                    .Cells(117).Value = dt.Rows(i)("Field7").ToString()
                    .Cells(118).Value = dt.Rows(i)("Field8").ToString()
                    .Cells(119).Value = dt.Rows(i)("Field9").ToString()
                    .Cells(120).Value = dt.Rows(i)("Field10").ToString()

                    dt1 = clsFun.ExecDataTable("Select * FROM ChargesTrans WHERE VoucherID=" & dt.Rows(i)("ID").ToString() & "")
                    '  tmpgrid.Rows.Clear()
                    If dt1.Rows.Count > 0 Then
                        For j = 0 To dt1.Rows.Count - 1
                            .Cells(84).Value = .Cells(84).Value & dt1.Rows(j)("ChargeName").ToString() & vbCrLf
                            .Cells(85).Value = .Cells(85).Value & dt1.Rows(j)("OnValue").ToString() & vbCrLf
                            .Cells(86).Value = .Cells(86).Value & dt1.Rows(j)("Calculate").ToString() & vbCrLf
                            .Cells(87).Value = .Cells(87).Value & dt1.Rows(j)("ChargeType").ToString() & vbCrLf
                            .Cells(88).Value = .Cells(88).Value & dt1.Rows(j)("Amount").ToString() & vbCrLf
                            .Cells(89).Value = .Cells(89).Value & dt1.Rows(j)("TaxName").ToString() & vbCrLf
                            .Cells(90).Value = .Cells(90).Value & dt1.Rows(j)("TaxPer").ToString() & vbCrLf
                            .Cells(91).Value = .Cells(91).Value & dt1.Rows(j)("TaxAmt").ToString() & vbCrLf
                            .Cells(92).Value = .Cells(92).Value & dt1.Rows(j)("TaxName").ToString() & vbCrLf
                            .Cells(93).Value = .Cells(93).Value & dt1.Rows(j)("IGSTPer").ToString() & vbCrLf
                            .Cells(94).Value = .Cells(94).Value & dt1.Rows(j)("IGSTAmt").ToString() & vbCrLf
                            .Cells(95).Value = .Cells(95).Value & dt1.Rows(j)("SGSTPer").ToString() & vbCrLf
                            .Cells(96).Value = .Cells(96).Value & dt1.Rows(j)("SGSTAmt").ToString() & vbCrLf
                            .Cells(97).Value = .Cells(97).Value & dt1.Rows(j)("CGSTPer").ToString() & vbCrLf
                            .Cells(98).Value = .Cells(98).Value & dt1.Rows(j)("CGSTAmt").ToString() & vbCrLf
                            .Cells(99).Value = .Cells(99).Value & dt1.Rows(j)("CessPer").ToString() & vbCrLf
                            .Cells(100).Value = .Cells(100).Value & dt1.Rows(j)("CessAmt").ToString() & vbCrLf
                        Next
                    End If
               Dim ssql As String = "Select HSNCode,round(sum(TaxableAmount)-(sum(CDAmt)),2) as Taxableamt,TaxPer,IGSTPer, round(sum(IGSTAmt),2) as IGSTAmt,SGSTPER,round(Sum(SGSTAmt),2) as SGSTAmt,CGSTPER, " & _
                                              "round(Sum(CGSTAmt),2) as CGSTAmt,round(sum(TaxAmount),2) as TaxAmt From Trans1  Where VoucherID=" & Val(dt.Rows(i)("ID").ToString()) & "  Group by TaxPer Order by TaxPer;"
                    dt2 = clsFun.ExecDataTable(ssql)
                    '  tmpgrid.Rows.Clear()
                    If dt2.Rows.Count > 0 Then
                        For k = 0 To dt2.Rows.Count - 1
                            .Cells(101).Value = .Cells(101).Value & dt2.Rows(k)("HSNCode").ToString() & vbCrLf
                            .Cells(102).Value = .Cells(102).Value & Format(Val(dt2.Rows(k)("Taxableamt").ToString()), Hash) & vbCrLf
                            .Cells(103).Value = .Cells(103).Value & Format(Val(dt2.Rows(k)("TaxPer").ToString()), Hash) & vbCrLf
                            .Cells(104).Value = .Cells(104).Value & Format(Val(dt2.Rows(k)("IGSTPer").ToString()), Hash) & vbCrLf
                            .Cells(105).Value = .Cells(105).Value & Format(Val(dt2.Rows(k)("IGSTAmt").ToString()), Hash) & vbCrLf
                            .Cells(106).Value = .Cells(106).Value & Format(Val(dt2.Rows(k)("SGSTPER").ToString()), Hash) & vbCrLf
                            .Cells(107).Value = .Cells(107).Value & Format(Val(dt2.Rows(k)("SGSTAmt").ToString()), Hash) & vbCrLf
                            .Cells(108).Value = .Cells(108).Value & Format(Val(dt2.Rows(k)("CGSTPER").ToString()), Hash) & vbCrLf
                            .Cells(109).Value = .Cells(109).Value & Format(Val(dt2.Rows(k)("CGSTAmt").ToString()), Hash) & vbCrLf
                            .Cells(110).Value = .Cells(110).Value & Format(Val(dt2.Rows(k)("TaxAmt").ToString()), Hash) & vbCrLf
                        Next
                    End If
                End With
            Next
        End If
        dt.Clear()
        dt1.Clear()
    End Sub


    Private Sub VNumber()
        If vno = Val(clsFun.ExecScalarInt("Select Max(InvoiceID) AS NumberOfProducts FROM Vouchers Where TransType='" & Me.Text & "'")) <> 0 Then
            vno = clsFun.ExecScalarInt("Select Count(ID) AS NumberOfProducts FROM Vouchers Where TransType='" & Me.Text & "'")
            txtVoucherNo.Text = vno + 1
            txtInvoiceID.Text = vno + 1
        Else
            vno = clsFun.ExecScalarInt("Select Max(InvoiceID)  AS NumberOfProducts FROM Vouchers Where TransType='" & Me.Text & "'")
            txtVoucherNo.Text = vno + 1
            txtInvoiceID.Text = vno + 1
        End If
        'If vno = Val(clsFun.ExecScalarInt("Select Max(InvoiceID) AS NumberOfProducts FROM Vouchers Where TransType='" & Me.Text & "'")) <> 0 Then
        '    vno = clsFun.ExecScalarInt("Select Count(ID) AS NumberOfProducts FROM Vouchers Where TransType='" & Me.Text & "'")
        '    txtVoucherNo.Text = vno + 1
        '    txtInvoiceID.Text = vno + 1
        'Else
        '    vno = clsFun.ExecScalarInt("Select Max(InvoiceID)  AS NumberOfProducts FROM Vouchers Where TransType='" & Me.Text & "'")
        '    txtVoucherNo.Text = vno + 1
        '    txtInvoiceID.Text = vno + 1
        'End If
    End Sub
    Private Sub ItemRowColumns()
        dgItemSearch.ColumnCount = 5
        dgItemSearch.Columns(0).Name = "ID" : dgItemSearch.Columns(0).Visible = False
        dgItemSearch.Columns(1).Name = "Item Name" : dgItemSearch.Columns(1).Width = 200
        dgItemSearch.Columns(2).Name = "HSNCode" : dgItemSearch.Columns(2).Width = 100
        dgItemSearch.Columns(3).Name = "Unit" : dgItemSearch.Columns(3).Width = 100
        dgItemSearch.Columns(4).Name = "Tax%" : dgItemSearch.Columns(4).Width = 100
        retriveItems()
    End Sub
    Private Sub retriveItems(Optional ByVal condtion As String = "")
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("Select ID,ItemName,HSNCode,RatePer,TaxName FROM Item_View  " & condtion & " Group by ID order by ItemName  Limit 20")
        Try
            If dt.Rows.Count > 0 Then
                dgItemSearch.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dgItemSearch.Rows.Add()
                    With dgItemSearch.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("id").ToString()
                        .Cells(1).Value = dt.Rows(i)("ItemName").ToString()
                        .Cells(2).Value = dt.Rows(i)("HSNCode").ToString()
                        .Cells(3).Value = dt.Rows(i)("RatePer").ToString()
                        .Cells(4).Value = dt.Rows(i)("TaxName").ToString()

                    End With
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "Teller")
        End Try
    End Sub

    Private Sub ItemFill()
        lblHsnCode.Text = clsFun.ExecScalarStr("Select HSnCode From Items Where ID='" & Val(txtItemID.Text) & "'")
        lblItemCode.Text = clsFun.ExecScalarStr("Select ItemCode From Items Where ID='" & Val(txtItemID.Text) & "'")
        lblPurchaseRate.Text = clsFun.ExecScalarStr("Select Purchaserate From Item_View Where id='" & Val(txtItemID.Text) & "'")
        lblSaleRate.Text = clsFun.ExecScalarStr("Select TableRate From Item_View Where ID='" & Val(txtItemID.Text) & "'")
        lblMRPRate.Text = clsFun.ExecScalarStr("Select RoomRate From Item_View Where ID='" & Val(txtItemID.Text) & "'")
        lblCostRate.Text = clsFun.ExecScalarStr("Select POSRate From Item_View Where ID='" & Val(txtItemID.Text) & "'")
        lblRateA.Text = clsFun.ExecScalarStr("Select BarRate From Item_View Where ID='" & Val(txtItemID.Text) & "'")
        lblRateB.Text = clsFun.ExecScalarStr("Select TakeAwayRate from Item_View Where ID='" & Val(txtItemID.Text) & "'")
        lblDisPer.Text = clsFun.ExecScalarStr("Select DisPer From Item_View Where ID='" & Val(txtItemID.Text) & "'")
        lblDisAmt.Text = clsFun.ExecScalarStr("Select Barcode From Item_View Where ID='" & Val(txtItemID.Text) & "'")
        'clsFun.FillDropDownList(cbPricePer, "Select UnitID,UnitName from Items  Where ID=" & Val(txtItemID.Text) & " Group by UnitID Union all Select AltUnitID as UnitID, AltUnitName as UnitName from Items  Where ID=" & Val(txtItemID.Text) & " Group by AltUnitID", "UnitName", "UnitID", "")
        clsFun.FillDropDownList(cbPricePer, "Select RateID,RatePer from Items  Where ID=" & Val(txtItemID.Text) & " Group by RateID", "RatePer", "RateID", "")
        cbPricePer.SelectedValue = Val(clsFun.ExecScalarStr("Select RateID From Items Where ID='" & Val(txtItemID.Text) & "'"))
        cbPricePer.Text = clsFun.ExecScalarStr("Select RatePer From Items Where ID='" & Val(txtItemID.Text) & "'")
        cbPricePer.SelectedIndex = 0
        If lblTaxType.Text = "TE" Or lblTaxType.Text = "TI" Then
            txtTaxPer.ReadOnly = True : txtTaxPer.TabStop = False
            txtTaxPer.Text = Format(Val(clsFun.ExecScalarDec("SELECT GSTPer FROM Items AS I Inner JOIN Taxation AS T ON I.TaxID = T.ID Where I.ID=" & Val(txtItemID.Text) & "")), Hash)
            CessPer = Format(Val(clsFun.ExecScalarDec("SELECT CessPer FROM Items AS I Inner JOIN Taxation AS T ON I.TaxID = T.ID Where I.ID=" & Val(txtItemID.Text) & "")), Hash)
            CessAsOn = clsFun.ExecScalarStr("SELECT GSTOn FROM Items AS I Inner JOIN Taxation AS T ON I.TaxID = T.ID Where I.ID=" & Val(txtItemID.Text) & "")
            SpeCess = Format(Val(clsFun.ExecScalarDec("SELECT CessAmt FROM Items AS I Inner JOIN Taxation AS T ON I.TaxID = T.ID Where I.ID=" & Val(txtItemID.Text) & "")), Hash)
        ElseIf lblTaxType.Text = "TM" Then
            txtTaxPer.ReadOnly = False : txtTaxPer.TabStop = True
            txtTaxPer.Text = Format(Val(clsFun.ExecScalarDec("SELECT GSTPer FROM Items AS I Inner JOIN Taxation AS T ON I.TaxID = T.ID Where I.ID=" & Val(txtItemID.Text) & "")), Hash)
            CessPer = Format(Val(clsFun.ExecScalarDec("SELECT CessPer FROM Items AS I Inner JOIN Taxation AS T ON I.TaxID = T.ID Where I.ID=" & Val(txtItemID.Text) & "")), Hash)
            CessAsOn = clsFun.ExecScalarStr("SELECT GSTOn FROM Items AS I Inner JOIN Taxation AS T ON I.TaxID = T.ID Where I.ID=" & Val(txtItemID.Text) & "")
            SpeCess = Format(Val(clsFun.ExecScalarDec("SELECT CessAmt FROM Items AS I Inner JOIN Taxation AS T ON I.TaxID = T.ID Where I.ID=" & Val(txtItemID.Text) & "")), Hash)
        Else
            txtTaxPer.ReadOnly = True : txtTaxPer.TabStop = False
            txtTaxPer.Text = Format(Val(clsFun.ExecScalarDec("SELECT GSTPer FROM Items AS I Inner JOIN Taxation AS T ON I.TaxID = T.ID Where I.ID=" & Val(txtItemID.Text) & "")), Hash)
            txtTaxAmt.Text = Format(0, Hash)
        End If
        ' lblbatchYN.Text = clsFun.ExecScalarStr("Select Maintainbatch From Items Where ID='" & Val(txtItemID.Text) & "'")
        'lblAltYN.Text = clsFun.ExecScalarStr("Select MaintainAltUnit From Items Where ID='" & Val(txtItemID.Text) & "'")
        'If lblbatchYN.Text = "Y" Then
        '    pnlItemInfo.Visible = True : pnlItemInfo.BringToFront() : lblbatchName.Visible = True : cbbatch.Visible = True : cbbatch.SelectedIndex = 0
        'Else
        '    pnlItemInfo.Visible = True : pnlItemInfo.BringToFront() : lblbatchName.Visible = False : cbbatch.Visible = False
        'End If
        If dg1.SelectedRows.Count <> 0 Then Exit Sub
        txtRate.Text = Format(Val(clsFun.ExecScalarStr("Select Purchaserate From Item_View Where id='" & Val(txtItemID.Text) & "'")), Hash)
        txtNetRate.Text = txtRate.Text
        '        txtDisPer.Text = Format(Val(clsFun.ExecScalarInt("Select DisPer From Batch Where ItemID=" & Val(txtItemID.Text) & " and ArticleName='" & CbArticle.Text & "'")), Hash)
    End Sub

    Private Sub txtItem_GotFocus(sender As Object, e As EventArgs) Handles txtItem.GotFocus
        pnlaltinfo.Visible = False : pnlNetRate.Visible = False : pnlPricePer.Visible = False : pnlDisc.Visible = False
        If dgItemSearch.ColumnCount = 0 Then ItemRowColumns()
        If dgItemSearch.RowCount = 0 Then retriveItems()
        If txtItem.Text.Trim() <> "" Then
            retriveItems(" Where upper(ItemName) Like upper('" & txtItem.Text.Trim() & "%')")
        Else
            retriveItems()
        End If
        autoGSTPick()
        If dgItemSearch.SelectedRows.Count = 0 Then dgItemSearch.Visible = True : txtItem.Focus()
        txtItem.SelectionStart = 0 : txtItem.SelectionLength = Len(txtItem.Text)
    End Sub
    Private Sub ItemFieldsSetting()


        If Val(clsFun.ExecScalarStr("Select Count(*) From AdditionFileds where  EntryType='Items'")) > 0 Then pnlAdditional.BringToFront() : pnlAdditional.Visible = True : txtField1.Focus() Else pnlAdditional.Visible = False : txtQty.Focus() : Exit Sub
        txtFieldNos.Text = Val(clsFun.ExecScalarStr("Select FieldNos  From AdditionFileds where  EntryType='Items'"))
        If Val(clsFun.ExecScalarStr("Select FieldNos  From AdditionFileds where  EntryType='Items'")) = 1 Then
            lblTitleAdd1.Visible = True : txtField1.Visible = True
            lblTitleAdd2.Visible = False : txtField2.Visible = False
            lblTitleAdd3.Visible = False : txtField3.Visible = False
            lblTitleAdd4.Visible = False : txtField4.Visible = False
            lblTitleAdd5.Visible = False : txtField5.Visible = False
            lblTitleAdd6.Visible = False : txtField6.Visible = False
            lblTitleAdd7.Visible = False : txtField7.Visible = False
            lblTitleAdd8.Visible = False : txtField8.Visible = False
            lblTitleAdd9.Visible = False : txtField9.Visible = False
            lblTitleAdd10.Visible = False : txtField10.Visible = False
            lblTitleAdd1.Text = clsFun.ExecScalarStr("Select FieldName1 From AdditionFileds  where  EntryType='Items'")
            pnlAdditional.Size = New Size(488, 40)
        ElseIf Val(clsFun.ExecScalarStr("Select FieldNos  From AdditionFileds where  EntryType='Items' ")) = 2 Then
            lblTitleAdd1.Visible = True : txtField1.Visible = True
            lblTitleAdd2.Visible = True : txtField2.Visible = True
            lblTitleAdd3.Visible = False : txtField3.Visible = False
            lblTitleAdd4.Visible = False : txtField4.Visible = False
            lblTitleAdd5.Visible = False : txtField5.Visible = False
            lblTitleAdd6.Visible = False : txtField6.Visible = False
            lblTitleAdd7.Visible = False : txtField7.Visible = False
            lblTitleAdd8.Visible = False : txtField8.Visible = False
            lblTitleAdd9.Visible = False : txtField9.Visible = False
            lblTitleAdd10.Visible = False : txtField10.Visible = False
            lblTitleAdd1.Text = clsFun.ExecScalarStr("Select FieldName1 From AdditionFileds  where  EntryType='Items'")
            lblTitleAdd2.Text = clsFun.ExecScalarStr("Select FieldName2 From AdditionFileds  where  EntryType='Items'")
            pnlAdditional.Size = New Size(488, 60)
        ElseIf Val(clsFun.ExecScalarStr("Select FieldNos  From AdditionFileds where  EntryType='Items' ")) = 3 Then
            lblTitleAdd1.Visible = True : txtField1.Visible = True
            lblTitleAdd2.Visible = True : txtField2.Visible = True
            lblTitleAdd3.Visible = True : txtField3.Visible = True
            lblTitleAdd4.Visible = False : txtField4.Visible = False
            lblTitleAdd5.Visible = False : txtField5.Visible = False
            lblTitleAdd6.Visible = False : txtField6.Visible = False
            lblTitleAdd7.Visible = False : txtField7.Visible = False
            lblTitleAdd8.Visible = False : txtField8.Visible = False
            lblTitleAdd9.Visible = False : txtField9.Visible = False
            lblTitleAdd10.Visible = False : txtField10.Visible = False
            lblTitleAdd1.Text = clsFun.ExecScalarStr("Select FieldName1 From AdditionFileds  where  EntryType='Items'")
            lblTitleAdd2.Text = clsFun.ExecScalarStr("Select FieldName2 From AdditionFileds  where  EntryType='Items'")
            lblTitleAdd3.Text = clsFun.ExecScalarStr("Select FieldName3 From AdditionFileds  where  EntryType='Items'")
            pnlAdditional.Size = New Size(488, 85)
        ElseIf Val(clsFun.ExecScalarStr("Select FieldNos  From AdditionFileds where  EntryType='Items' ")) = 4 Then
            lblTitleAdd1.Visible = True : txtField1.Visible = True
            lblTitleAdd2.Visible = True : txtField2.Visible = True
            lblTitleAdd3.Visible = True : txtField3.Visible = True
            lblTitleAdd4.Visible = True : txtField4.Visible = True
            lblTitleAdd5.Visible = False : txtField5.Visible = False
            lblTitleAdd6.Visible = False : txtField6.Visible = False
            lblTitleAdd7.Visible = False : txtField7.Visible = False
            lblTitleAdd8.Visible = False : txtField8.Visible = False
            lblTitleAdd9.Visible = False : txtField9.Visible = False
            lblTitleAdd10.Visible = False : txtField10.Visible = False
            lblTitleAdd1.Text = clsFun.ExecScalarStr("Select FieldName1 From AdditionFileds  where  EntryType='Items'")
            lblTitleAdd2.Text = clsFun.ExecScalarStr("Select FieldName2 From AdditionFileds  where  EntryType='Items'")
            lblTitleAdd3.Text = clsFun.ExecScalarStr("Select FieldName3 From AdditionFileds  where  EntryType='Items'")
            lblTitleAdd4.Text = clsFun.ExecScalarStr("Select FieldName4 From AdditionFileds  where  EntryType='Items'")
            pnlAdditional.Size = New Size(488, 110)
        ElseIf Val(clsFun.ExecScalarStr("Select FieldNos  From AdditionFileds where  EntryType='Items'")) = 5 Then
            lblTitleAdd1.Visible = True : txtField1.Visible = True
            lblTitleAdd2.Visible = True : txtField2.Visible = True
            lblTitleAdd3.Visible = True : txtField3.Visible = True
            lblTitleAdd4.Visible = True : txtField4.Visible = True
            lblTitleAdd5.Visible = True : txtField5.Visible = True
            lblTitleAdd6.Visible = False : txtField6.Visible = False
            lblTitleAdd7.Visible = False : txtField7.Visible = False
            lblTitleAdd8.Visible = False : txtField8.Visible = False
            lblTitleAdd9.Visible = False : txtField9.Visible = False
            lblTitleAdd10.Visible = False : txtField10.Visible = False
            lblTitleAdd1.Text = clsFun.ExecScalarStr("Select FieldName1 From AdditionFileds  where  EntryType='Items'")
            lblTitleAdd2.Text = clsFun.ExecScalarStr("Select FieldName2 From AdditionFileds  where  EntryType='Items'")
            lblTitleAdd3.Text = clsFun.ExecScalarStr("Select FieldName3 From AdditionFileds  where  EntryType='Items'")
            lblTitleAdd4.Text = clsFun.ExecScalarStr("Select FieldName4 From AdditionFileds  where  EntryType='Items'")
            lblTitleAdd5.Text = clsFun.ExecScalarStr("Select FieldName5 From AdditionFileds  where  EntryType='Items'")
            pnlAdditional.Size = New Size(488, 140)
        ElseIf Val(clsFun.ExecScalarStr("Select FieldNos  From AdditionFileds where  EntryType='Items'")) = 6 Then
            lblTitleAdd1.Visible = True : txtField1.Visible = True
            lblTitleAdd2.Visible = True : txtField2.Visible = True
            lblTitleAdd3.Visible = True : txtField3.Visible = True
            lblTitleAdd4.Visible = True : txtField4.Visible = True
            lblTitleAdd5.Visible = True : txtField5.Visible = True
            lblTitleAdd6.Visible = True : txtField6.Visible = True
            lblTitleAdd7.Visible = False : txtField7.Visible = False
            lblTitleAdd8.Visible = False : txtField8.Visible = False
            lblTitleAdd9.Visible = False : txtField9.Visible = False
            lblTitleAdd10.Visible = False : txtField10.Visible = False
            lblTitleAdd1.Text = clsFun.ExecScalarStr("Select FieldName1 From AdditionFileds  where  EntryType='Items'")
            lblTitleAdd2.Text = clsFun.ExecScalarStr("Select FieldName2 From AdditionFileds  where  EntryType='Items'")
            lblTitleAdd3.Text = clsFun.ExecScalarStr("Select FieldName3 From AdditionFileds  where  EntryType='Items'")
            lblTitleAdd4.Text = clsFun.ExecScalarStr("Select FieldName4 From AdditionFileds  where  EntryType='Items'")
            lblTitleAdd5.Text = clsFun.ExecScalarStr("Select FieldName5 From AdditionFileds  where  EntryType='Items'")
            lblTitleAdd6.Text = clsFun.ExecScalarStr("Select FieldName6 From AdditionFileds  where  EntryType='Items'")
            pnlAdditional.Size = New Size(488, 160)
        ElseIf Val(clsFun.ExecScalarStr("Select FieldNos  From AdditionFileds where  EntryType='Items'")) = 7 Then
            lblTitleAdd1.Visible = True : txtField1.Visible = True
            lblTitleAdd2.Visible = True : txtField2.Visible = True
            lblTitleAdd3.Visible = True : txtField3.Visible = True
            lblTitleAdd4.Visible = True : txtField4.Visible = True
            lblTitleAdd5.Visible = True : txtField5.Visible = True
            lblTitleAdd6.Visible = True : txtField6.Visible = True
            lblTitleAdd7.Visible = True : txtField7.Visible = True
            lblTitleAdd8.Visible = False : txtField8.Visible = False
            lblTitleAdd9.Visible = False : txtField9.Visible = False
            lblTitleAdd10.Visible = False : txtField10.Visible = False
            lblTitleAdd1.Text = clsFun.ExecScalarStr("Select FieldName1 From AdditionFileds  where  EntryType='Items'")
            lblTitleAdd2.Text = clsFun.ExecScalarStr("Select FieldName2 From AdditionFileds  where  EntryType='Items'")
            lblTitleAdd3.Text = clsFun.ExecScalarStr("Select FieldName3 From AdditionFileds  where  EntryType='Items'")
            lblTitleAdd4.Text = clsFun.ExecScalarStr("Select FieldName4 From AdditionFileds  where  EntryType='Items'")
            lblTitleAdd5.Text = clsFun.ExecScalarStr("Select FieldName5 From AdditionFileds  where  EntryType='Items'")
            lblTitleAdd6.Text = clsFun.ExecScalarStr("Select FieldName6 From AdditionFileds  where  EntryType='Items'")
            lblTitleAdd7.Text = clsFun.ExecScalarStr("Select FieldName7 From AdditionFileds  where  EntryType='Items'")
            pnlAdditional.Size = New Size(488, 185)

        ElseIf Val(clsFun.ExecScalarStr("Select FieldNos  From AdditionFileds where  EntryType='Items'")) = 8 Then
            lblTitleAdd1.Visible = True : txtField1.Visible = True
            lblTitleAdd2.Visible = True : txtField2.Visible = True
            lblTitleAdd3.Visible = True : txtField3.Visible = True
            lblTitleAdd4.Visible = True : txtField4.Visible = True
            lblTitleAdd5.Visible = True : txtField5.Visible = True
            lblTitleAdd6.Visible = True : txtField6.Visible = True
            lblTitleAdd7.Visible = True : txtField7.Visible = True
            lblTitleAdd8.Visible = True : txtField8.Visible = True
            lblTitleAdd9.Visible = False : txtField9.Visible = False
            lblTitleAdd10.Visible = False : txtField10.Visible = False
            lblTitleAdd1.Text = clsFun.ExecScalarStr("Select FieldName1 From AdditionFileds  where  EntryType='Items'")
            lblTitleAdd2.Text = clsFun.ExecScalarStr("Select FieldName2 From AdditionFileds  where  EntryType='Items'")
            lblTitleAdd3.Text = clsFun.ExecScalarStr("Select FieldName3 From AdditionFileds  where  EntryType='Items'")
            lblTitleAdd4.Text = clsFun.ExecScalarStr("Select FieldName4 From AdditionFileds  where  EntryType='Items'")
            lblTitleAdd5.Text = clsFun.ExecScalarStr("Select FieldName5 From AdditionFileds  where  EntryType='Items'")
            lblTitleAdd6.Text = clsFun.ExecScalarStr("Select FieldName6 From AdditionFileds  where  EntryType='Items'")
            lblTitleAdd7.Text = clsFun.ExecScalarStr("Select FieldName7 From AdditionFileds  where  EntryType='Items'")
            lblTitleAdd8.Text = clsFun.ExecScalarStr("Select FieldName8 From AdditionFileds  where  EntryType='Items'")
            pnlAdditional.Size = New Size(488, 210)

        ElseIf Val(clsFun.ExecScalarStr("Select FieldNos  From AdditionFileds where  EntryType='Items'")) = 9 Then
            lblTitleAdd1.Visible = True : txtField1.Visible = True
            lblTitleAdd2.Visible = True : txtField2.Visible = True
            lblTitleAdd3.Visible = True : txtField3.Visible = True
            lblTitleAdd4.Visible = True : txtField4.Visible = True
            lblTitleAdd5.Visible = True : txtField5.Visible = True
            lblTitleAdd6.Visible = True : txtField6.Visible = True
            lblTitleAdd7.Visible = True : txtField7.Visible = True
            lblTitleAdd8.Visible = True : txtField8.Visible = True
            lblTitleAdd9.Visible = True : txtField9.Visible = True
            lblTitleAdd10.Visible = False : txtField10.Visible = False
            lblTitleAdd1.Text = clsFun.ExecScalarStr("Select FieldName1 From AdditionFileds  where  EntryType='Items'")
            lblTitleAdd2.Text = clsFun.ExecScalarStr("Select FieldName2 From AdditionFileds  where  EntryType='Items'")
            lblTitleAdd3.Text = clsFun.ExecScalarStr("Select FieldName3 From AdditionFileds  where  EntryType='Items'")
            lblTitleAdd4.Text = clsFun.ExecScalarStr("Select FieldName4 From AdditionFileds  where  EntryType='Items'")
            lblTitleAdd5.Text = clsFun.ExecScalarStr("Select FieldName5 From AdditionFileds  where  EntryType='Items'")
            lblTitleAdd6.Text = clsFun.ExecScalarStr("Select FieldName6 From AdditionFileds  where  EntryType='Items'")
            lblTitleAdd7.Text = clsFun.ExecScalarStr("Select FieldName7 From AdditionFileds  where  EntryType='Items'")
            lblTitleAdd8.Text = clsFun.ExecScalarStr("Select FieldName8 From AdditionFileds  where  EntryType='Items'")
            lblTitleAdd9.Text = clsFun.ExecScalarStr("Select FieldName9 From AdditionFileds  where  EntryType='Items'")
            pnlAdditional.Size = New Size(488, 240)

        ElseIf Val(clsFun.ExecScalarStr("Select FieldNos  From AdditionFileds where  EntryType='Items'")) = 10 Then
            lblTitleAdd1.Visible = True : txtField1.Visible = True
            lblTitleAdd2.Visible = True : txtField2.Visible = True
            lblTitleAdd3.Visible = True : txtField3.Visible = True
            lblTitleAdd4.Visible = True : txtField4.Visible = True
            lblTitleAdd5.Visible = True : txtField5.Visible = True
            lblTitleAdd6.Visible = True : txtField6.Visible = True
            lblTitleAdd7.Visible = True : txtField7.Visible = True
            lblTitleAdd8.Visible = True : txtField8.Visible = True
            lblTitleAdd9.Visible = True : txtField9.Visible = True
            lblTitleAdd10.Visible = True : txtField10.Visible = True
            lblTitleAdd1.Text = clsFun.ExecScalarStr("Select FieldName1 From AdditionFileds  where  EntryType='Items'")
            lblTitleAdd2.Text = clsFun.ExecScalarStr("Select FieldName2 From AdditionFileds  where  EntryType='Items'")
            lblTitleAdd3.Text = clsFun.ExecScalarStr("Select FieldName3 From AdditionFileds  where  EntryType='Items'")
            lblTitleAdd4.Text = clsFun.ExecScalarStr("Select FieldName4 From AdditionFileds  where  EntryType='Items'")
            lblTitleAdd5.Text = clsFun.ExecScalarStr("Select FieldName5 From AdditionFileds  where  EntryType='Items'")
            lblTitleAdd6.Text = clsFun.ExecScalarStr("Select FieldName6 From AdditionFileds  where  EntryType='Items'")
            lblTitleAdd7.Text = clsFun.ExecScalarStr("Select FieldName7 From AdditionFileds  where  EntryType='Items'")
            lblTitleAdd8.Text = clsFun.ExecScalarStr("Select FieldName8 From AdditionFileds  where  EntryType='Items'")
            lblTitleAdd9.Text = clsFun.ExecScalarStr("Select FieldName9 From AdditionFileds  where  EntryType='Items'")
            lblTitleAdd10.Text = clsFun.ExecScalarStr("Select FieldName10 From AdditionFileds  where  EntryType='Items'")
            pnlAdditional.Size = New Size(488, 266)
        End If
    End Sub

    Private Sub dgItemSearch_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgItemSearch.CellClick
        txtItem.Clear()
        txtItemID.Clear()
        txtItemID.Text = Val(dgItemSearch.SelectedRows(0).Cells(0).Value)
        txtItem.Text = dgItemSearch.SelectedRows(0).Cells(1).Value
        lblUOM.Text = dgItemSearch.SelectedRows(0).Cells(3).Value
        ItemFill() : dgItemSearch.Visible = False
        If Val(clsFun.ExecScalarStr("Select Count(*) From AdditionFileds where  EntryType='Items'")) > 0 Then ItemFieldsSetting() : pnlAdditional.BringToFront() : pnlAdditional.Visible = True : txtField1.Focus() : Exit Sub Else pnlAdditional.Visible = False : txtQty.Focus() : Exit Sub
        If lblbatchYN.Text = "Y" Then cbbatch.Focus() Else txtQty.Focus()
    End Sub

    Private Sub dgItemSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles dgItemSearch.KeyDown
        If e.KeyCode = Keys.PageUp Then If dgItemSearch.CurrentRow.Index = 0 Then txtItem.Focus()
        If e.KeyCode = Keys.F3 Then
            Items.MdiParent = MainScreenForm
            Items.Show()
            If Not Item_form Is Nothing Then
                Item_form.BringToFront()
            End If
        End If
        If e.KeyCode = Keys.F1 Then
            Dim ItemID As String = dgItemSearch.SelectedRows(0).Cells(0).Value
            Item_form.MdiParent = MainScreenForm
            Item_form.Show()
            Item_form.FillControl(ItemID)
            If Not Item_form Is Nothing Then
                Item_form.BringToFront()
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            txtItem.Clear()
            txtItemID.Text = Val(dgItemSearch.SelectedRows(0).Cells(0).Value)
            txtItem.Text = dgItemSearch.SelectedRows(0).Cells(1).Value
            lblUOM.Text = dgItemSearch.SelectedRows(0).Cells(3).Value
            ItemFill() : dgItemSearch.Visible = False
            'If Val(clsFun.ExecScalarStr("Select Count(*) From AdditionFileds where  EntryType='Items'")) > 0 Then ItemFieldsSetting() : pnlAdditional.BringToFront() : pnlAdditional.Visible = True : txtField1.Focus() : e.SuppressKeyPress = True : Exit Sub Else pnlAdditional.Visible = False : txtQty.Focus() : e.SuppressKeyPress = True : Exit Sub
            'If lblbatchYN.Text = "Y" Then cbbatch.Focus() Else txtQty.Focus()
            txtQty.Focus()
            e.SuppressKeyPress = True
        End If
        If e.KeyCode = Keys.Back Then
            txtItem.Focus()
        End If
        If e.KeyCode = Keys.Up Then
            If dgItemSearch.CurrentRow.Index = 0 Then
                txtItem.Focus()
            End If
        End If
    End Sub

    Private Sub txtItem_KeyUp(sender As Object, e As KeyEventArgs) Handles txtItem.KeyUp
        If txtItem.Text.Trim() <> "" Then
            retriveItems(" Where upper(ItemName) Like upper('%" & txtItem.Text.Trim() & "%') or Barcode='" & txtItem.Text.Trim() & "'")
        Else
            retriveItems()
        End If
        If e.KeyCode = Keys.Escape Then dgItemSearch.Visible = False
    End Sub

    Private Sub txtItem_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtItem.KeyPress
        e.Handled = (e.KeyChar = "'") Or (e.KeyChar = """")
        dgItemSearch.Visible = True
    End Sub
    Private Sub rowColums()
        dg1.ColumnCount = 71
        dg1.Columns(0).Name = "ItemID" : dg1.Columns(0).Visible = False
        dg1.Columns(0).SortMode = DataGridViewColumnSortMode.Automatic
        dg1.Columns(1).Name = "Item Name" : dg1.Columns(1).Width = 249
        dg1.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dg1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dg1.Columns(2).Name = "HSN" : dg1.Columns(2).Width = 50
        dg1.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dg1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dg1.Columns(3).Name = "Code" : dg1.Columns(3).Visible = False
        dg1.Columns(4).Name = "Pack" : dg1.Columns(4).Visible = False
        dg1.Columns(5).Name = "BatchID" : dg1.Columns(5).Visible = False
        dg1.Columns(6).Name = "Batch" : dg1.Columns(6).Visible = False
        dg1.Columns(7).Name = "UOMID" : dg1.Columns(7).Visible = False
        dg1.Columns(8).Name = "UOM" : dg1.Columns(8).Width = 50
        dg1.Columns(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dg1.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dg1.Columns(9).Name = "Qty" : dg1.Columns(9).Width = 78
        dg1.Columns(9).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg1.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg1.Columns(10).Name = "Main" : dg1.Columns(10).Visible = False
        dg1.Columns(11).Name = "Alt" : dg1.Columns(11).Visible = False
        dg1.Columns(12).Name = "Sceme" : dg1.Columns(12).Visible = False
        dg1.Columns(13).Name = "Rate" : dg1.Columns(13).Width = 119
        dg1.Columns(14).Name = "Basic" : dg1.Columns(14).Width = 119
        dg1.Columns(15).Name = "Disc%" : dg1.Columns(15).Width = 79
        dg1.Columns(16).Name = "Disc" : dg1.Columns(16).Width = 99
        dg1.Columns(17).Name = "Tax%" : dg1.Columns(17).Width = 79
        dg1.Columns(18).Name = "Tax" : dg1.Columns(18).Width = 99
        dg1.Columns(19).Name = "Total" : dg1.Columns(19).Width = 151
        dg1.Columns(20).Name = "NetRate" : dg1.Columns(20).Visible = False : dg1.Columns(21).Name = "DisName1" : dg1.Columns(21).Visible = False
        dg1.Columns(22).Name = "DisOnValue1" : dg1.Columns(22).Visible = False : dg1.Columns(23).Name = "DisAmt1" : dg1.Columns(23).Visible = False
        dg1.Columns(24).Name = "DisName2" : dg1.Columns(24).Visible = False : dg1.Columns(25).Name = "DisOnValue2" : dg1.Columns(25).Visible = False
        dg1.Columns(26).Name = "DisAmt2" : dg1.Columns(26).Visible = False : dg1.Columns(27).Name = "DisName3" : dg1.Columns(27).Visible = False
        dg1.Columns(28).Name = "DisOnValue3" : dg1.Columns(28).Visible = False : dg1.Columns(29).Name = "DisAmt3" : dg1.Columns(29).Visible = False
        dg1.Columns(30).Name = "DisName4" : dg1.Columns(30).Visible = False : dg1.Columns(31).Name = "DisOnValue4" : dg1.Columns(31).Visible = False
        dg1.Columns(32).Name = "DisAmt4" : dg1.Columns(32).Visible = False : dg1.Columns(33).Name = "TotDis" : dg1.Columns(33).Visible = False
        dg1.Columns(34).Name = "SerialID" : dg1.Columns(34).Visible = False : dg1.Columns(35).Name = "CdAmt" : dg1.Columns(34).Visible = False
        dg1.Columns(36).Name = "DisPer1" : dg1.Columns(36).Visible = False : dg1.Columns(37).Name = "DisPer2" : dg1.Columns(37).Visible = False
        dg1.Columns(38).Name = "DisPer3" : dg1.Columns(39).Visible = False : dg1.Columns(39).Name = "DisPer4" : dg1.Columns(39).Visible = False
        '''''
        dg1.Columns(40).Name = "IGSTPer" : dg1.Columns(40).Visible = False : dg1.Columns(41).Name = "IGSTAmt" : dg1.Columns(41).Visible = False
        dg1.Columns(42).Name = "CGSTPer" : dg1.Columns(42).Visible = False : dg1.Columns(43).Name = "CGSTAmt" : dg1.Columns(43).Visible = False
        dg1.Columns(44).Name = "SGSTPer" : dg1.Columns(44).Visible = False : dg1.Columns(45).Name = "SGSTAmt" : dg1.Columns(45).Visible = False
        dg1.Columns(46).Name = "CessPer" : dg1.Columns(46).Visible = False : dg1.Columns(47).Name = "CessAsOn" : dg1.Columns(47).Visible = False
        dg1.Columns(48).Name = "SpeCess" : dg1.Columns(48).Visible = False : dg1.Columns(49).Name = "CessAmt" : dg1.Columns(49).Visible = False
        dg1.Columns(50).Name = "ApprValue" : dg1.Columns(50).Visible = False
        '' additional Items
        dg1.Columns(51).Name = "Field1" : dg1.Columns(51).Visible = False : dg1.Columns(52).Name = "Field2" : dg1.Columns(52).Visible = False
        dg1.Columns(53).Name = "Field3" : dg1.Columns(53).Visible = False : dg1.Columns(54).Name = "Field4" : dg1.Columns(54).Visible = False
        dg1.Columns(55).Name = "Field5" : dg1.Columns(55).Visible = False : dg1.Columns(56).Name = "Field6" : dg1.Columns(56).Visible = False
        dg1.Columns(57).Name = "Field7" : dg1.Columns(57).Visible = False : dg1.Columns(58).Name = "Field8" : dg1.Columns(58).Visible = False
        dg1.Columns(59).Name = "Field9" : dg1.Columns(59).Visible = False : dg1.Columns(60).Name = "Field10" : dg1.Columns(60).Visible = False
        ''additional accounts
        dg1.Columns(61).Name = "FieldAcc1" : dg1.Columns(61).Visible = False : dg1.Columns(62).Name = "FieldAcc2" : dg1.Columns(62).Visible = False
        dg1.Columns(63).Name = "FieldAcc3" : dg1.Columns(63).Visible = False : dg1.Columns(64).Name = "FieldAcc4" : dg1.Columns(64).Visible = False
        dg1.Columns(65).Name = "FieldAcc5" : dg1.Columns(65).Visible = False : dg1.Columns(66).Name = "FieldAcc6" : dg1.Columns(66).Visible = False
        dg1.Columns(67).Name = "FieldAcc7" : dg1.Columns(67).Visible = False : dg1.Columns(68).Name = "FieldAcc8" : dg1.Columns(68).Visible = False
        dg1.Columns(69).Name = "FieldAcc9" : dg1.Columns(69).Visible = False : dg1.Columns(70).Name = "FieldAcc10" : dg1.Columns(70).Visible = False

        Dg2.ColumnCount = 12
        Dg2.Columns(0).Name = "Charge Name" : Dg2.Columns(0).Width = 259 : Dg2.Columns(0).SortMode = DataGridViewColumnSortMode.Automatic : Dg2.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter : Dg2.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Dg2.Columns(1).Name = "On Value" : Dg2.Columns(1).Width = 113 : Dg2.Columns(1).SortMode = DataGridViewColumnSortMode.Automatic : Dg2.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter : Dg2.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Dg2.Columns(2).Name = "Cal" : Dg2.Columns(2).Width = 114 : Dg2.Columns(2).SortMode = DataGridViewColumnSortMode.Automatic : Dg2.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter : Dg2.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Dg2.Columns(3).Name = "+/-" : Dg2.Columns(3).Width = 114 : Dg2.Columns(3).SortMode = DataGridViewColumnSortMode.Automatic : Dg2.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Dg2.Columns(4).Name = "Amount" : Dg2.Columns(4).Width = 114 : Dg2.Columns(4).SortMode = DataGridViewColumnSortMode.Automatic : Dg2.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight : Dg2.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Dg2.Columns(5).Name = "ChargeID" : Dg2.Columns(5).Visible = False
        Dg2.Columns(6).Name = "TaxPer" : Dg2.Columns(6).Visible = False
        Dg2.Columns(7).Name = "TaxAmt" : Dg2.Columns(7).Visible = False
        Dg2.Columns(8).Name = "CessPer" : Dg2.Columns(8).Visible = False
        Dg2.Columns(9).Name = "CessAmt" : Dg2.Columns(9).Visible = False
        Dg2.Columns(10).Name = "Taxable" : Dg2.Columns(10).Visible = False
        Dg2.Columns(11).Name = "AppValue" : Dg2.Columns(11).Visible = False
    End Sub
    Private Sub AccountRowColumns()
        DgAccountSearch.ColumnCount = 3
        DgAccountSearch.Columns(0).Name = "ID" : DgAccountSearch.Columns(0).Visible = False
        DgAccountSearch.Columns(1).Name = "Account Name" : DgAccountSearch.Columns(1).Width = 200
        DgAccountSearch.Columns(2).Name = "City" : DgAccountSearch.Columns(2).Width = 110
        DgAccountSearch.BringToFront() : DgAccountSearch.Visible = True
        retriveAccounts()
    End Sub

    Private Sub retriveAccounts(Optional ByVal condtion As String = "")
        Dim dt As New DataTable
        If ckShowCustomer.Checked = True Then
            dt = clsFun.ExecDataTable("Select * from Account_AcGrp where (Groupid in(11,17,16)  or UnderGroupID in (11,17,16))" & condtion & " order by AccountName Limit 10")
        Else
            dt = clsFun.ExecDataTable("Select * from Account_AcGrp where (Groupid in(11,17)  or UnderGroupID in (11,17))" & condtion & " order by AccountName limit 10")
        End If
        Try
            If dt.Rows.Count > 0 Then
                DgAccountSearch.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    DgAccountSearch.Rows.Add()
                    With DgAccountSearch.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("id").ToString()
                        .Cells(1).Value = dt.Rows(i)("AccountName").ToString()
                        .Cells(2).Value = dt.Rows(i)("City").ToString()
                    End With
                    ' Dg1.Rows.Add()
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "AccoBook")
        End Try
    End Sub

    Private Sub txtAccount_GotFocus(sender As Object, e As EventArgs) Handles txtAccount.GotFocus
        If DgAccountSearch.ColumnCount = 0 Then AccountRowColumns()
        If DgAccountSearch.RowCount = 0 Then retriveAccounts()
        If txtAccount.Text.Trim() <> "" Then
            retriveAccounts(" And upper(accountname) Like upper('" & txtAccount.Text.Trim() & "%')")
        Else
            retriveAccounts()
        End If
    End Sub

    Private Sub cbSeries_GotFocus(sender As Object, e As EventArgs) Handles cbSeries.GotFocus
        If DgAccountSearch.ColumnCount = 0 Then AccountRowColumns()
        If DgAccountSearch.RowCount = 0 Then retriveAccounts()
        If txtAccount.Text.Trim() <> "" Then
            retriveAccounts(" And upper(accountname) Like upper('" & txtAccount.Text.Trim() & "')")
        Else
            retriveAccounts()
        End If
        If DgAccountSearch.ColumnCount = 0 Then AccountRowColumns()
        If DgAccountSearch.RowCount = 0 Then retriveAccounts()
        If DgAccountSearch.SelectedRows.Count = 0 Then DgAccountSearch.Visible = True : txtAccount.Focus() : Exit Sub
        txtAccountID.Clear() : txtAccount.Clear()
        txtAccountID.Text = Val(DgAccountSearch.SelectedRows(0).Cells(0).Value)
        txtAccount.Text = DgAccountSearch.SelectedRows(0).Cells(1).Value
        DgAccountSearch.Visible = False
    End Sub

    Private Sub CbArticle_GotFocus(sender As Object, e As EventArgs)
        If dgItemSearch.ColumnCount = 0 Then ItemRowColumns()
        If dgItemSearch.Rows.Count = 0 Then retriveItems()
        If dgItemSearch.SelectedRows.Count = 0 Then dgItemSearch.Visible = True : txtItem.Focus() : Exit Sub
        txtItemID.Text = Val(dgItemSearch.SelectedRows(0).Cells(0).Value)
        txtItem.Text = dgItemSearch.SelectedRows(0).Cells(1).Value
        lblUOM.Text = dgItemSearch.SelectedRows(0).Cells(2).Value
        dgItemSearch.Visible = False : ItemBalance()
        clsFun.FillDropDownList(CbArticle, "Select ItemID,Batch From Batch Where ItemID=" & Val(txtItemID.Text) & " Group by Batch,ItemID", "Batch", "ItemID", "")
    End Sub
    Private Sub txtchargesAmount_KeyDown(sender As Object, e As KeyEventArgs) Handles txtchargesAmount.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Dg2.SelectedRows.Count = 1 Then
                Dg2.SelectedRows(0).Cells(0).Value = txtCharges.Text
                Dg2.SelectedRows(0).Cells(1).Value = Format(Val(txtOnValue.Text), Hash)
                Dg2.SelectedRows(0).Cells(2).Value = Format(Val(txtCalculatePer.Text), Hash)
                Dg2.SelectedRows(0).Cells(3).Value = txtPlusMinus.Text
                Dg2.SelectedRows(0).Cells(4).Value = Format(Val(txtchargesAmount.Text), Hash)
                Dg2.SelectedRows(0).Cells(5).Value = Val(txtChargeID.Text)
                Dg2.SelectedRows(0).Cells(6).Value = Format(Val(txtGstperCharge.Text), Hash)
                Dg2.SelectedRows(0).Cells(7).Value = Format(Val(txtGSTAmtCharge.Text), Hash)
                Dg2.SelectedRows(0).Cells(8).Value = Format(Val(txtCessPerCharge.Text), Hash)
                Dg2.SelectedRows(0).Cells(9).Value = Format(Val(txtCessAmtCharge.Text), Hash)
                Dg2.SelectedRows(0).Cells(10).Value = Format(Val(txtChargeTaxable.Text), Hash)

                calc()
                txtCharges.Focus()
                Dg2.ClearSelection()
                cleartxtCharges()
            Else
                Dg2.Rows.Add(txtCharges.Text, Format(Val(txtOnValue.Text), Hash), Format(Val(txtCalculatePer.Text), Hash),
                             txtPlusMinus.Text, Format(Val(txtchargesAmount.Text), Hash), txtChargeID.Text,
                             Format(Val(txtGstperCharge.Text), Hash), Format(Val(txtGSTAmtCharge.Text), Hash),
                             Format(Val(txtCessPerCharge.Text), Hash), Format(Val(txtCessAmtCharge.Text), Hash),
                             Format(Val(txtChargeTaxable.Text), Hash))
                calc()
                cleartxtCharges()
                txtCharges.Focus()
                Dg2.ClearSelection()
            End If
        End If
    End Sub

    Private Sub cleartxtCharges()
        If Dg2.Rows.Count > 4 Then Dg2.Columns(4).Width = 95 Else Dg2.Columns(4).Width = 114
        txtOnValue.Text = "" : txtCalculatePer.Text = ""
        txtPlusMinus.Text = "" : txtchargesAmount.Text = ""
        txtChargeTaxable.Text = "" : txtGstperCharge.Text = ""
        txtGSTAmtCharge.Text = "" : txtCessPerCharge.Text = ""
        txtCessAmtCharge.Text = "" : pnlGSTCharges.Visible = False
        calc() : Dg2.ClearSelection()
    End Sub
    Private Sub FillCharges()
        CalcType = clsFun.ExecScalarStr(" Select ApplyType FROM Charges WHERE ID='" & Val(txtChargeID.Text) & "'")
        txtPlusMinus.Text = clsFun.ExecScalarStr(" Select ChargesType FROM Charges WHERE ID='" & Val(txtChargeID.Text) & "'")
        txtCalculatePer.Text = clsFun.ExecScalarStr(" Select Calculate FROM Charges WHERE ID='" & Val(txtChargeID.Text) & "'")
        Dim ApplyOn As String = clsFun.ExecScalarStr(" Select ApplyOn FROM Charges WHERE ID='" & Val(txtChargeID.Text) & "'")
        If clsFun.ExecScalarInt(" Select TaxID FROM Charges WHERE ID='" & Val(txtChargeID.Text) & "'") > 0 Then pnlGSTCharges.BringToFront() : pnlGSTCharges.Visible = True Else pnlGSTCharges.Visible = False
        If CalcType = "Aboslute" Then
            txtOnValue.TabStop = False
            txtCalculatePer.TabStop = False
            txtOnValue.Text = ""
            txtchargesAmount.Focus()
        ElseIf CalcType = "Weight" Then
            txtOnValue.Text = txtTotNetAmt.Text
            txtOnValue.TabStop = True
            txtCalculatePer.TabStop = True
        ElseIf CalcType = "Percentage" Then
            If ApplyOn = "Taxable Amount" Then
                txtOnValue.Text = txtTotTaxable.Text
            ElseIf ApplyOn = "Tax Amount" Then
                txtOnValue.Text = Val(txtTotTaxAmt.Text)
            ElseIf ApplyOn = "Item Total" Then
                txtOnValue.Text = Val(lblTotQty.Text)
            ElseIf ApplyOn = "Total Amount" Then
                txtOnValue.Text = Val(txtTotTotal.Text) + Val(txttotRoundoff.Text)
            ElseIf ApplyOn = "Tax Amount" Then
                txtOnValue.Text = txtTotTaxAmt.Text
            End If
            txtOnValue.TabStop = True
            txtCalculatePer.TabStop = True
        ElseIf CalcType = "Qty" Then
            txtOnValue.Text = Val(lblTotQty.Text)
            txtOnValue.TabStop = True
            txtCalculatePer.TabStop = True
        End If

    End Sub

    Private Sub Update()

        'Dim chargestaxble As Decimal = 0.0
        'For i = 0 To Dg2.Rows.Count - 1
        '    If Dg2.Rows(i).Cells(3).Value = "+" Then
        '        chargestaxble = Format(Val(chargestaxble) + Val(Dg2.Rows(i).Cells(10).Value), Hash)
        '    Else
        '        chargestaxble = Format(Val(chargestaxble) - Math.Abs(Val(Dg2.Rows(i).Cells(10).Value)), Hash)
        '    End If
        'Next
        Dim sql As String = "Update Vouchers SET TransType='" & Me.Text & "',InvoiceNo='" & txtVoucherNo.Text & "',InvoiceID=" & Val(txtInvoiceID.Text) & "," & _
                            " Entrydate='" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "',TotQty=" & Val(lblTotQty.Text) & ",SeriesID=" & Val(cbSeries.SelectedValue) & ", " & _
                            " SeriesName='" & cbSeries.Text & "',AccountID=" & Val(txtAccountID.Text) & ",AccountName='" & txtAccount.Text & "',TotalBasicAmt=" & Val(txtTotNetAmt.Text) & ", " & _
                            " TotalDiscAmt=" & Val(txtTotDisAmt.Text) & ",TotalTaxAmt=" & Val(txtTotTaxAmt.Text) & ",AfterCharges=" & Val(txtAfterCharges.Text) & ",RoundOff=" & Val(txttotRoundoff.Text) & ", " & _
                            " TotalGrandAmt=" & Val(txtTotTotal.Text) & ",TotalCashAmt=" & Val(txtTotCashAmt.Text) & ",TotalBalAmt=" & Val(txtTotDueamt.Text) & ",CustomerName='" & txtCustomerName.Text & "'," & _
                            " CustomerAddress='" & txtFullAddress.Text & "',CustomerMobile='" & txtMobileNo.Text & "',CustomerGSTN='" & txtGSTN.Text & "',StateName='" & cbState.Text & "'," & _
                            " StateCode='" & txtStateCode.Text & "',TotalIGSTAmt=" & IIf(lblRegion.Text = "Local", 0, Val(TotalIGST)) & ",TotalCGSTAmt=" & IIf(lblRegion.Text = "Local", Val(Val(TotalCGST)), 0) & ", " & _
                            " TotalSGSTAmt=" & IIf(lblRegion.Text = "Local", Val(Val(TotalCGST)), 0) & ",TotalCessAmt=" & Val(TotalCess) & ",CdPer=" & Val(txtCdPer.Text) & ", " & _
                            " CdAmount=" & Val(txtBeforeCharges.Text) & ",TotalTaxableAmt=" & Val(TaxableTotal) & ",GSTType='" & cbGSTtype.Text & "' Where ID=" & Val(txtID.Text) & ""
        Try
            If clsFun.ExecNonQuery(sql) > 0 Then
                clsFun.ExecNonQuery("Delete From Trans Where VoucherID='" & Val(txtID.Text) & "';Delete From ChargesTrans Where VoucherID='" & Val(txtID.Text) & "';Delete From Ledger Where VoucherID='" & Val(txtID.Text) & "'")
                UpdateEwayBill() : dg1Record() : dg2Record() : taxDetails() : insertLedger() : InsertCharges() ' : SerialRecord() : MaintainBBB()
                MsgBox("Purchase Record Updated Successfully...", vbInformation.Information, "Updated")
                ClearAll()
            End If
            'con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            'con.Close()
        End Try
    End Sub
    Public Sub MultiUpdatePurchase()

        'Dim chargestaxble As Decimal = 0.0
        'For i = 0 To Dg2.Rows.Count - 1
        '    If Dg2.Rows(i).Cells(3).Value = "+" Then
        '        chargestaxble = Format(Val(chargestaxble) + Val(Dg2.Rows(i).Cells(10).Value), Hash)
        '    Else
        '        chargestaxble = Format(Val(chargestaxble) - Math.Abs(Val(Dg2.Rows(i).Cells(10).Value)), Hash)
        '    End If
        'Next
        Dim sql As String = "Update Vouchers Set TransType='" & Me.Text & "',BillNo='" & txtVoucherNo.Text & "' ," & _
            "InvoiceID='" & Val(txtInvoiceID.Text) & "',Entrydate='" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "'," & _
            "TotQty='" & Val(lblTotQty.Text) & "',SeriesID='" & Val(cbSeries.SelectedValue) & "', " & _
           "SeriesName='" & cbSeries.Text & "',AccountID='" & Val(txtAccountID.Text) & "',AccountName='" & txtAccount.Text & "', " & _
           "BasicAmount='" & Val(txtTotNetAmt.Text) & "',DiscountAmount='" & Val(txtTotDisAmt.Text) & "', " & _
           "GSTAmt='" & Val(txtTotTaxAmt.Text) & "',AfterCharges='" & Val(txtAfterCharges.Text) & "',RoundOff='" & Val(txttotRoundoff.Text) & "', " & _
           "TotalAmount='" & Val(txtTotTotal.Text) & "',TotalCashAmount='" & Val(txtTotCashAmt.Text) & "',TotalDueAmount='" & Val(txtTotDueamt.Text) & "', " & _
           "T1='" & txtCustomerName.Text & "',T2='" & txtFullAddress.Text & "',T3='" & txtMobileNo.Text & "',T4='" & txtGSTN.Text & "', " & _
           "T5='" & cbState.Text & "',T6='" & txtStateCode.Text & "',TotIGSTAmt='" & IIf(lblRegion.Text = "Local", 0, Val(Val(TotalIGST))) & "', " & _
           "TotSGSTAmt='" & IIf(lblRegion.Text = "Local", Val(Val(TotalSGST)), 0) & "',TotCGSTAmt='" & IIf(lblRegion.Text = "Local", Val(Val(TotalCGST)), 0) & "', " & _
           "CessAmt='" & TotalCess & "',CdPer='" & Val(txtCdPer.Text) & "',CDAmount='" & Val(txtBeforeCharges.Text) & "', " & _
           "TaxableAmount='" & Val(TaxableTotal) & "',T7='" & cbGSTtype.Text & "' Where ID='" & Val(txtID.Text) & "'"
        cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
        Try
            If clsFun.ExecNonQuery(sql) > 0 Then
                clsFun.ExecNonQuery("Delete From Trans1 Where VoucherID='" & Val(txtID.Text) & "';Delete From ChargesTrans Where VoucherID='" & Val(txtID.Text) & "';Delete From Ledger Where VoucherID='" & Val(txtID.Text) & "'")
                UpdateEwayBill() : dg1Record() : dg2Record() : taxDetails() : insertLedger() : InsertCharges() : SerialRecord() : MaintainBBB()
                '   MsgBox("Sale Record Updated Successfully...", vbInformation.Information, "Updated")
                ClearAll()
            End If
            'con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            'con.Close()
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

    Private Sub txtOnValue_GotFocus(sender As Object, e As EventArgs) Handles txtOnValue.GotFocus
        If dgCharges.ColumnCount = 0 Then ChargesRowColums()
        If dgCharges.RowCount = 0 Then RetriveCharges()
        If dgCharges.SelectedRows.Count = 0 Then dgCharges.Visible = True
        txtCharges.Text = dgCharges.SelectedRows(0).Cells(1).Value
        txtChargeID.Text = Val(dgCharges.SelectedRows(0).Cells(0).Value)
        dgCharges.Visible = False : FillCharges()
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

    Private Sub txtCharges_GotFocus(sender As Object, e As EventArgs) Handles txtCharges.GotFocus, txtCharges.Click
        pnlItemInfo.Visible = False : dgItemSearch.Visible = False : DgAccountSearch.Visible = False
        If dgCharges.ColumnCount = 0 Then ChargesRowColums()
        If dgCharges.RowCount = 0 Then RetriveCharges()
        If txtCharges.Text.Trim() <> "" Then
            RetriveCharges(" Where upper(ChargeName) Like upper('" & txtCharges.Text.Trim() & "%')")
        Else
            RetriveCharges()
        End If
        If dgCharges.SelectedRows.Count = 0 Then dgCharges.Visible = True
        txtCharges.SelectAll()
    End Sub

    Private Sub txtCharges_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCharges.KeyDown, txtOnValue.KeyDown, txtCalculatePer.KeyDown,
        txtPlusMinus.KeyDown
        If e.KeyCode = Keys.PageUp Then
            txtItem.Focus()
        End If

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
            'e.SuppressKeyPress = True
            'ProcessTabKey(True)
        End If
        Select Case e.KeyCode
            Case Keys.End
                e.Handled = True
                BtnSave.Focus()
        End Select
        If e.KeyCode = Keys.Delete Then
            dgCharges.Visible = False
            If Dg2.SelectedRows.Count = 0 Then Exit Sub
            If MessageBox.Show("Are you Sure to Remove Charge Name : " & Dg2.SelectedRows(0).Cells(0).Value & "", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) = Windows.Forms.DialogResult.Yes Then
                Dg2.Rows.Remove(Dg2.SelectedRows(0))
                cleartxtCharges()
                'ClearDetails()
            End If
        End If
        If txtCharges.Focused Then
            If e.KeyCode = Keys.F3 Then
                ChargesForm.MdiParent = MainScreenForm
                ChargesForm.Show()
                If Not ChargesForm Is Nothing Then
                    ChargesForm.BringToFront()
                End If
            End If
            If e.KeyCode = Keys.F1 Then
                Dim tmpMarkaID As String = dgCharges.SelectedRows(0).Cells(0).Value
                ChargesForm.MdiParent = MainScreenForm
                ChargesForm.Show()
                ChargesForm.FillContros(tmpMarkaID)
                If Not ChargesForm Is Nothing Then
                    ChargesForm.BringToFront()
                End If
            End If
            If e.KeyCode = Keys.Down Then dgCharges.Focus()
        End If

    End Sub
    'Sub calc()
    '    txtTotNetAmt.Text = Format(0, Hash) : txtTotDisAmt.Text = Format(0, Hash)
    '    txtTotTaxAmt.Text = Format(0, Hash) : txtAfterCharges.Text = Format(0, Hash)
    '    txttotRoundoff.Text = Format(0, Hash) : txtTotTotal.Text = Format(0, Hash)
    '    txtTotCashAmt.Text = Format(0, Hash) : txtTotDueamt.Text = Format(0, Hash)
    '    lblTotQty.Text = Hash : txtBeforeCharges.Text = Format(0, Hash)
    '    taxableamt = 0.0 : taxamtIGST = 0.0
    '    taxamtSGST = 0.0 : taxamtCGST = 0.0
    '    TotalTax = 0.0 : TotalIGST = 0.0
    '    TotalSGST = 0.0 : TotalCGST = 0.0
    '    Dim i As Integer
    '    For i = 0 To dg1.Rows.Count - 1
    '        txtTotNetAmt.Text = Format(Val(txtTotNetAmt.Text) + Val(dg1.Rows(i).Cells(14).Value), Hash)
    '        '    txtTotNetAmt.Text = Decimal.Truncate(txtTotNetAmt.Text)
    '        txtTotDisAmt.Text = Format(Val(txtTotDisAmt.Text) + Val(Val(dg1.Rows(i).Cells(16).Value) + Val(dg1.Rows(i).Cells(33).Value)), Hash)
    '        dg1.Rows(i).Cells(35).Value = (Val(txtCdPer.Text) * Val(Val(dg1.Rows(i).Cells(14).Value) - Val(Val(dg1.Rows(i).Cells(16).Value)) - Val(dg1.Rows(i).Cells(33).Value))) / 100
    '        txtBeforeCharges.Text = Format(Val(txtBeforeCharges.Text) + Val(dg1.Rows(i).Cells(35).Value), Hash)
    '        taxableamt = Format(Val(Val(dg1.Rows(i).Cells(14).Value) - Val(Val(dg1.Rows(i).Cells(16).Value) + Val(dg1.Rows(i).Cells(33).Value) + Val(dg1.Rows(i).Cells(35).Value))), Hash)
    '        If lblTaxType.Text = "TI" Or lblTaxType.Text = "TE" Then
    '            If lblRegion.Text = "Local" Then
    '                taxamtSGST = Val(dg1.Rows(i).Cells(17).Value) / 2 * Val(Val(taxableamt) / 100)
    '                taxamtCGST = Val(dg1.Rows(i).Cells(17).Value) / 2 * Val(Val(taxableamt) / 100)
    '                taxamtIGST = 0
    '                taxamt = taxamtCGST + taxamtSGST
    '                TotalTax = TotalTax + taxamt
    '                TotalSGST = TotalSGST + Format(Val(taxamtSGST), Hash)
    '                TotalCGST = TotalCGST + Format(Val(taxamtCGST), Hash)
    '                TotalIGST = 0
    '            Else
    '                taxamtSGST = 0
    '                taxamtCGST = 0
    '                taxamtIGST = Val(dg1.Rows(i).Cells(17).Value) * Val(Val(taxableamt) / 100)
    '                taxamt = taxamtCGST + taxamtIGST
    '                TotalTax = TotalTax + taxamt
    '                TotalSGST = 0
    '                TotalCGST = 0
    '                TotalIGST = TotalIGST + taxamtIGST
    '            End If
    '            dg1.Rows(i).Cells(18).Value = Val(dg1.Rows(i).Cells(17).Value) * Val(Val(taxableamt) / 100)
    '            taxamt = Val(dg1.Rows(i).Cells(17).Value) * Val(Val(taxableamt) / 100)
    '            dg1.Rows(i).Cells(18).Value = Format(taxamt, Hash)
    '        Else
    '            dg1.Rows(i).Cells(18).Value = Format(0, "")
    '        End If
    '        dg1.Rows(i).Cells(41).Value = Format(Val(taxamtIGST), Hash)
    '        dg1.Rows(i).Cells(43).Value = Format(Val(taxamtSGST), Hash)
    '        dg1.Rows(i).Cells(45).Value = Format(Val(taxamtCGST), Hash)
    '        txtTotTaxAmt.Text = Val(txtTotTaxAmt.Text) + Val(Val(dg1.Rows(i).Cells(41).Value) + Val(dg1.Rows(i).Cells(43).Value) + Val(dg1.Rows(i).Cells(45).Value))
    '        Dim total As Decimal = Val(taxableamt) + Val(dg1.Rows(i).Cells(18).Value)
    '        dg1.Rows(i).Cells(19).Value = Format(total, Hash)
    '        freeqty = Val(freeqty) + Val(dg1.Rows(i).Cells(12).Value)
    '        lblTotQty.Text = Val(lblTotQty.Text) + Val(dg1.Rows(i).Cells(10).Value)
    '        If Val(freeqty) > 0 Then
    '            lblTotQty.Text = lblTotQty.Text & "+" & freeqty
    '        End If
    '    Next
    '    For i = 0 To Dg2.Rows.Count - 1
    '        Dim FixAs As String = clsFun.ExecScalarStr(" Select FixAs FROM Charges WHERE ID='" & Val(Dg2.Rows(i).Cells(5).Value) & "'")
    '        If Dg2.Rows(i).Cells(3).Value = "-" Then
    '            txtAfterCharges.Text = Format(Val(txtAfterCharges.Text) - Val(Dg2.Rows(i).Cells(4).Value), Hash)
    '        Else
    '            txtAfterCharges.Text = Format(Val(txtAfterCharges.Text) + Val(Dg2.Rows(i).Cells(4).Value), Hash)
    '        End If
    '    Next
    '    ItemTotalTax = txtTotTaxAmt.Text
    '    If dg1.RowCount > 8 Then dg1.Columns(19).Width = 132 Else dg1.Columns(19).Width = 145
    '    If lblRegion.Text = "Local" Then TotalSGST = Format(Val(TotalSGST), Hash) : TotalCGST = Format(Val(TotalCGST), Hash) Else TotalIGST = Format(Val(TotalIGST), Hash)
    '    txtTotTaxable.Text = Format((Val(Val(txtTotNetAmt.Text) - Val(txtTotDisAmt.Text)) - Val(txtBeforeCharges.Text)), Hash)
    '    txtTotTotal.Text = Format(Val(Val(txtTotTaxable.Text) + TotalIGST + TotalSGST + TotalCGST + Val(txtAfterCharges.Text)), Hash)
    '    txtTotTaxAmt.Text = Format(Val(TotalIGST + TotalSGST + TotalCGST), Hash)
    '    Dim tmpamount As Double = CDbl(Val(txtTotTotal.Text))
    '    txtTotTotal.Text = Math.Round(Val(tmpamount), 0)
    '    txttotRoundoff.Text = Format(Val(txtTotTotal.Text) - Val(tmpamount), Hash)
    '    txtTotTotal.Text = Format(Val(txtTotTotal.Text), Hash)
    '    lblRecordCount.Text = Val(dg1.Rows.Count)
    '    If Val(txtAccountID.Text) = 7 Then
    '        txtTotCashAmt.Text = txtTotTotal.Text
    '        txtTotDueamt.Text = Format(0, Hash)
    '    Else
    '        txtTotCashAmt.Text = Format(0, Hash)
    '        txtTotDueamt.Text = txtTotTotal.Text
    '    End If
    '    autoGSTPick()
    'End Sub
    '''''Old Calculation Mathod

    'Sub calc()
    '    txtTotNetAmt.Text = Format(0, Hash) : txtTotDisAmt.Text = Format(0, Hash)
    '    txtTotTaxAmt.Text = Format(0, Hash) : txtAfterCharges.Text = Format(0, Hash)
    '    txttotRoundoff.Text = Format(0, Hash) : txtTotTotal.Text = Format(0, Hash)
    '    txtTotCashAmt.Text = Format(0, Hash) : txtTotDueamt.Text = Format(0, Hash)
    '    lblTotQty.Text = Hash : txtBeforeCharges.Text = Format(0, Hash)

    '    Dim i As Integer
    '    For i = 0 To dg1.Rows.Count - 1
    '        txtTotNetAmt.Text = Format(Val(txtTotNetAmt.Text) + Val(dg1.Rows(i).Cells(14).Value), Hash)
    '        '    txtTotNetAmt.Text = Decimal.Truncate(txtTotNetAmt.Text)
    '        txtTotDisAmt.Text = Format(Val(txtTotDisAmt.Text) + Val(Val(dg1.Rows(i).Cells(16).Value) + Val(dg1.Rows(i).Cells(33).Value)), Hash)
    '        dg1.Rows(i).Cells(35).Value = (Val(txtCdPer.Text) * Val(Val(dg1.Rows(i).Cells(14).Value) - Val(Val(dg1.Rows(i).Cells(16).Value)) - Val(dg1.Rows(i).Cells(33).Value))) / 100
    '        txtBeforeCharges.Text = Format(Val(txtBeforeCharges.Text) + Val(dg1.Rows(i).Cells(35).Value), Hash)
    '        taxableamt = Format(Val(Val(dg1.Rows(i).Cells(14).Value) - Val(Val(dg1.Rows(i).Cells(16).Value) + Val(dg1.Rows(i).Cells(33).Value) + Val(dg1.Rows(i).Cells(35).Value))), Hash)
    '        If lblTaxType.Text = "TI" Or lblTaxType.Text = "TE" Then
    '            If lblRegion.Text = "Local" Then
    '                taxamtSGST = Val(dg1.Rows(i).Cells(17).Value) / 2 * Val(Val(taxableamt) / 100)
    '                taxamtCGST = Val(dg1.Rows(i).Cells(17).Value) / 2 * Val(Val(taxableamt) / 100)
    '                taxamtIGST = 0
    '                taxamt = taxamtCGST + taxamtSGST
    '                TotalTax = TotalTax + taxamt
    '                TotalSGST = TotalSGST + taxamtSGST
    '                TotalCGST = TotalCGST + taxamtCGST
    '                TotalIGST = 0
    '                dg1.Rows(i).Cells(40).Value = Val(0)
    '                dg1.Rows(i).Cells(42).Value = Val(dg1.Rows(i).Cells(17).Value) / 2
    '                dg1.Rows(i).Cells(44).Value = Val(dg1.Rows(i).Cells(17).Value) / 2
    '            Else
    '                taxamtSGST = 0
    '                taxamtCGST = 0
    '                taxamtIGST = Val(dg1.Rows(i).Cells(17).Value) * Val(Val(taxableamt) / 100)
    '                taxamt = taxamtCGST + taxamtIGST
    '                TotalTax = TotalTax + taxamt
    '                TotalSGST = 0
    '                TotalCGST = 0
    '                TotalIGST = TotalIGST + taxamtIGST
    '                dg1.Rows(i).Cells(40).Value = Val(dg1.Rows(i).Cells(17).Value)
    '                dg1.Rows(i).Cells(42).Value = Val(0)
    '                dg1.Rows(i).Cells(44).Value = Val(0)
    '            End If
    '            dg1.Rows(i).Cells(18).Value = Val(dg1.Rows(i).Cells(17).Value) * Val(Val(taxableamt) / 100)
    '            taxamt = Val(dg1.Rows(i).Cells(17).Value) * Val(Val(taxableamt) / 100)
    '            dg1.Rows(i).Cells(18).Value = Format(taxamt, Hash)
    '        Else
    '            dg1.Rows(i).Cells(41).Value = 0
    '            dg1.Rows(i).Cells(43).Value = 0
    '            dg1.Rows(i).Cells(45).Value = 0
    '            dg1.Rows(i).Cells(18).Value = Format(0, "")
    '        End If
    '        dg1.Rows(i).Cells(41).Value = taxamtIGST
    '        dg1.Rows(i).Cells(43).Value = taxamtSGST
    '        dg1.Rows(i).Cells(45).Value = taxamtCGST
    '        txtTotTaxAmt.Text = Val(txtTotTaxAmt.Text) + Val(Val(dg1.Rows(i).Cells(41).Value) + Val(dg1.Rows(i).Cells(43).Value) + Val(dg1.Rows(i).Cells(45).Value))
    '        Dim total As Decimal = Val(taxableamt) + Val(dg1.Rows(i).Cells(18).Value)
    '        dg1.Rows(i).Cells(19).Value = Format(total, Hash)
    '        freeqty = Val(freeqty) + Val(dg1.Rows(i).Cells(12).Value)
    '        lblTotQty.Text = Val(lblTotQty.Text) + Val(dg1.Rows(i).Cells(10).Value)
    '        If Val(freeqty) > 0 Then
    '            lblTotQty.Text = lblTotQty.Text & "+" & freeqty
    '        End If
    '    Next
    '    For i = 0 To Dg2.Rows.Count - 1
    '        Dim FixAs As String = clsFun.ExecScalarStr(" Select FixAs FROM Charges WHERE ID='" & Val(Dg2.Rows(i).Cells(5).Value) & "'")
    '        If Dg2.Rows(i).Cells(3).Value = "-" Then
    '            txtAfterCharges.Text = Format(Val(txtAfterCharges.Text) - Val(Dg2.Rows(i).Cells(4).Value), Hash)
    '        Else
    '            txtAfterCharges.Text = Format(Val(txtAfterCharges.Text) + Val(Dg2.Rows(i).Cells(4).Value), Hash)
    '        End If
    '    Next
    '    ItemTotalTax = txtTotTaxAmt.Text
    '    If dg1.RowCount > 8 Then dg1.Columns(19).Width = 132 Else dg1.Columns(19).Width = 145
    '    If lblRegion.Text = "Local" Then TotalSGST = Format(Val(txtTotTaxAmt.Text / 2), Hash) : TotalCGST = Format(Val(txtTotTaxAmt.Text / 2), Hash) Else TotalIGST = txtTotTaxAmt.Text
    '    txtTotTaxable.Text = Format((Val(Val(txtTotNetAmt.Text) - Val(txtTotDisAmt.Text)) - Val(txtBeforeCharges.Text)), Hash)
    '    txtTotTotal.Text = Format(Val(Val(txtTotTaxable.Text) + TotalIGST + TotalSGST + TotalCGST + Val(txtAfterCharges.Text)), Hash)
    '    txtTotTaxAmt.Text = Format(Val(txtTotTaxAmt.Text), Hash)
    '    Dim tmpamount As Double = CDbl(Val(txtTotTotal.Text))
    '    txtTotTotal.Text = Math.Round(Val(tmpamount), 0)
    '    txttotRoundoff.Text = Format(Val(txtTotTotal.Text) - Val(tmpamount), Hash)
    '    txtTotTotal.Text = Format(Val(txtTotTotal.Text), Hash)
    '    lblRecordCount.Text = Val(dg1.Rows.Count)
    '    If Val(txtAccountID.Text) = 7 Then
    '        txtTotCashAmt.Text = txtTotTotal.Text
    '        txtTotDueamt.Text = Format(0, Hash)
    '    Else
    '        txtTotCashAmt.Text = Format(0, Hash)
    '        txtTotDueamt.Text = txtTotTotal.Text
    '    End If
    '    autoGSTPick()
    'End Sub

    Sub calc()
        txtTotTaxable.Text = Hash
        txtTotNetAmt.Text = Format(0, Hash) : txtTotDisAmt.Text = Format(0, Hash)
        txtTotTaxAmt.Text = Format(0, Hash) : txtAfterCharges.Text = Format(0, Hash)
        txttotRoundoff.Text = Format(0, Hash) : txtTotTotal.Text = Format(0, Hash)
        txtTotCashAmt.Text = Format(0, Hash) : txtTotDueamt.Text = Format(0, Hash)
        lblTotQty.Text = Hash : txtBeforeCharges.Text = Format(0, Hash)
        taxableamt = 0.0 : taxamtIGST = 0.0 : TaxableTotal = Hash
        taxamtSGST = 0.0 : taxamtCGST = 0.0 : TotalTax = 0.0 : TotalIGST = 0.0
        TotalSGST = 0.0 : TotalCGST = 0.0 : Dim i As Integer
        CessAmt = 0.0 : TotalCess = 0.0 : Dim GSTApplicable As String = String.Empty
        Dim chargesIGST As Decimal = 0 : Dim chargesCGST As Decimal = 0
        Dim chargesSGST As Decimal = 0 : Dim AppValue As Decimal
        Dim TotAppValue As Decimal = 0 : Dim Chargestaxable As Decimal = 0
        Dim GoodschargesApprValue As Decimal = 0 : Dim ServicechargesApprValue As Decimal = 0
        Dim GoodsCharges As Decimal = 0 : Dim ServicesCharges As Decimal = 0
        For i = 0 To Dg2.Rows.Count - 1
            Dim IsGST As String = clsFun.ExecScalarStr(" Select FixAs FROM Charges WHERE ID='" & Val(Dg2.Rows(i).Cells(5).Value) & "'")
            Dim ApplyOn As String = clsFun.ExecScalarStr(" Select Applyon FROM Charges WHERE ID='" & Val(Dg2.Rows(i).Cells(5).Value) & "'")
            Dim SupplyType As String = clsFun.ExecScalarStr(" Select SupplyType FROM Charges WHERE ID='" & Val(Dg2.Rows(i).Cells(5).Value) & "'")
            If clsFun.ExecScalarInt(" Select TaxID FROM Charges WHERE ID='" & Val(Dg2.Rows(i).Cells(5).Value) & "'") <> 0 Then GSTApplicable = "Yes"
            If IsGST = "Include in GST (Goods)" And ApplyOn = "Taxable Amount" Then
                If SupplyType = "Goods" Then
                    If Dg2.Rows(i).Cells(3).Value = "+" Then
                        GoodschargesApprValue = Val(GoodschargesApprValue) + Val(Dg2.Rows(i).Cells(4).Value)
                    Else
                        GoodschargesApprValue = Val(GoodschargesApprValue) - Val(Dg2.Rows(i).Cells(4).Value)
                    End If

                ElseIf SupplyType = "Services" Then
                    If Dg2.Rows(i).Cells(3).Value = "+" Then
                        ServicechargesApprValue = Val(ServicechargesApprValue) + Val(Dg2.Rows(i).Cells(4).Value)
                    Else
                        ServicechargesApprValue = Val(ServicechargesApprValue) - Val(Dg2.Rows(i).Cells(4).Value)
                    End If

                End If

            ElseIf IsGST = "Exclude GST Applicable" And GSTApplicable = "Yes" Then
                If SupplyType = "Goods" Then
                    If Dg2.Rows(i).Cells(3).Value = "+" Then
                        GoodsCharges = Val(GoodsCharges) + Val(Dg2.Rows(i).Cells(4).Value)
                    Else
                        GoodsCharges = Val(GoodsCharges) - Val(Dg2.Rows(i).Cells(4).Value)
                    End If
                    Dg2.Rows(i).Cells(11).Value = Hash
                ElseIf SupplyType = "Services" Then
                    If Dg2.Rows(i).Cells(3).Value = "+" Then
                        ServicesCharges = Val(ServicesCharges) + Val(Dg2.Rows(i).Cells(4).Value)
                    Else
                        ServicesCharges = Val(ServicesCharges) - Val(Dg2.Rows(i).Cells(4).Value)
                    End If

                    Dg2.Rows(i).Cells(11).Value = Hash
                End If
            End If

        Next

        For i = 0 To dg1.Rows.Count - 1
            dg1.Rows(i).Cells(49).Value = Hash
            dg1.Rows(i).Cells(50).Value = Hash

            txtTotNetAmt.Text = Format(Val(txtTotNetAmt.Text) + Val(dg1.Rows(i).Cells(14).Value), Hash)
            '    txtTotNetAmt.Text = Decimal.Truncate(txtTotNetAmt.Text)
            txtTotDisAmt.Text = Format(Val(txtTotDisAmt.Text) + Val(Val(dg1.Rows(i).Cells(16).Value) + Val(dg1.Rows(i).Cells(33).Value)), Hash)
            dg1.Rows(i).Cells(35).Value = Val(Val(txtCdPer.Text) * Val(Val(dg1.Rows(i).Cells(14).Value) - Val(Val(dg1.Rows(i).Cells(16).Value)) - Val(dg1.Rows(i).Cells(33).Value))) / 100
            txtBeforeCharges.Text = Val(txtBeforeCharges.Text) + Format(Val(dg1.Rows(i).Cells(35).Value), Hash)
            taxableamt = Val(Val(dg1.Rows(i).Cells(14).Value) - Val(Val(dg1.Rows(i).Cells(16).Value) + Val(dg1.Rows(i).Cells(33).Value) + Val(dg1.Rows(i).Cells(35).Value)))

            If lblTaxType.Text = "TI" Or lblTaxType.Text = "TE" Then
                If lblRegion.Text = "Local" Then
                    taxamtSGST = Val(dg1.Rows(i).Cells(17).Value) / 2 * Val(Val(taxableamt) / 100)
                    taxamtCGST = Val(dg1.Rows(i).Cells(17).Value) / 2 * Val(Val(taxableamt) / 100)
                    If dg1.Rows(i).Cells(47).Value = "Taxable" Then
                        CessAmt = Val(Val(taxableamt) * Val(dg1.Rows(i).Cells(46).Value) / 100)
                        dg1.Rows(i).Cells(49).Value = Format(Val(CessAmt), Hash)
                        TotalCess = Val(TotalCess) + Val(CessAmt)
                    ElseIf dg1.Rows(i).Cells(47).Value = "Qty" Then
                        CessAmt = Val(CessAmt) + Val(Val(Val(dg1.Rows(i).Cells(10).Value)) * Val(dg1.Rows(i).Cells(48).Value))
                        dg1.Rows(i).Cells(49).Value = Format(Val(CessAmt), Hash)
                        TotalCess = Val(TotalCess) + Val(CessAmt)
                    ElseIf dg1.Rows(i).Cells(47).Value = "Taxable+Qty" Then
                        CessAmt = Val(Val(taxableamt) * Val(dg1.Rows(i).Cells(46).Value) / 100)
                        CessAmt = Val(CessAmt) + Val(Val(Val(dg1.Rows(i).Cells(10).Value)) * Val(dg1.Rows(i).Cells(48).Value))
                        dg1.Rows(i).Cells(49).Value = Format(Val(CessAmt), Hash)
                        TotalCess = Val(TotalCess) + Val(CessAmt)
                    End If
                    taxamtIGST = 0
                    taxamt = taxamtCGST + taxamtSGST
                    TotalTax = TotalTax + (taxamt + CessAmt)
                    TotalSGST = TotalSGST + Format(Val(taxamtSGST), Hash)
                    TotalCGST = TotalCGST + Format(Val(taxamtCGST), Hash)
                    TotalIGST = 0 'TotalCess = TotalCess + CessAmt
                    dg1.Rows(i).Cells(40).Value = Val(0)
                    dg1.Rows(i).Cells(42).Value = Val(dg1.Rows(i).Cells(17).Value) / 2
                    dg1.Rows(i).Cells(44).Value = Val(dg1.Rows(i).Cells(17).Value) / 2
                Else
                    taxamtSGST = 0
                    taxamtCGST = 0
                    taxamtIGST = Val(dg1.Rows(i).Cells(17).Value) * Val(Val(taxableamt) / 100)
                    If dg1.Rows(i).Cells(47).Value = "Taxable" Then
                        CessAmt = Val(Val(taxableamt) * Val(dg1.Rows(i).Cells(46).Value) / 100)
                        dg1.Rows(i).Cells(49).Value = Format(Val(CessAmt), Hash)
                    ElseIf dg1.Rows(i).Cells(47).Value = "Qty" Then
                        CessAmt = Val(CessAmt) + Val(Val(Val(dg1.Rows(i).Cells(10).Value)) * Val(dg1.Rows(i).Cells(48).Value))
                        dg1.Rows(i).Cells(49).Value = Format(Val(CessAmt), Hash)
                    ElseIf dg1.Rows(i).Cells(47).Value = "Taxable+Qty" Then
                        CessAmt = Val(Val(taxableamt) * Val(dg1.Rows(i).Cells(46).Value) / 100)
                        CessAmt = Val(CessAmt) + Val(Val(Val(dg1.Rows(i).Cells(10).Value)) * Val(dg1.Rows(i).Cells(48).Value))
                        dg1.Rows(i).Cells(49).Value = Format(Val(CessAmt), Hash)
                    End If
                    TotalTax = TotalTax + taxamtIGST
                    TotalTax = TotalTax + (taxamt + CessAmt)
                    TotalSGST = 0 : TotalCGST = 0
                    TotalIGST = TotalIGST + taxamtIGST
                    TotalCess = TotalCess + CessAmt
                    dg1.Rows(i).Cells(40).Value = Val(dg1.Rows(i).Cells(17).Value)
                    dg1.Rows(i).Cells(42).Value = Val(0)
                    dg1.Rows(i).Cells(44).Value = Val(0)
                End If
                dg1.Rows(i).Cells(41).Value = Format(Val(taxamtIGST), Hash)
                dg1.Rows(i).Cells(43).Value = Format(Val(taxamtSGST), Hash)
                dg1.Rows(i).Cells(45).Value = Format(Val(taxamtCGST), Hash)
                dg1.Rows(i).Cells(50).Value = 0
                '  dg1.Rows(i).Cells(18).Value = Val(dg1.Rows(i).Cells(17).Value) * Val(Val(taxableamt) / 100)
                'taxamt = (Format(Val(taxamtIGST), Hash) + Format(Val(taxamtCGST), Hash) + Format(Val(taxamtSGST), Hash))
                dg1.Rows(i).Cells(18).Value = Format(Val(Val(dg1.Rows(i).Cells(41).Value) + Val(dg1.Rows(i).Cells(43).Value) + Val(dg1.Rows(i).Cells(45).Value) + Val(dg1.Rows(i).Cells(49).Value)), Hash)
            Else
                dg1.Rows(i).Cells(18).Value = Format(0, Hash)
            End If

            TaxableTotal = Format(Val(TaxableTotal) + Val(taxableamt), Hash)
            txtTotTaxAmt.Text = Val(txtTotTaxAmt.Text) + Val(Val(dg1.Rows(i).Cells(41).Value) + Val(dg1.Rows(i).Cells(43).Value) + Val(dg1.Rows(i).Cells(45).Value) + Val(dg1.Rows(i).Cells(49).Value))
            Dim total As Decimal = Val(taxableamt) + Val(dg1.Rows(i).Cells(18).Value)
            dg1.Rows(i).Cells(19).Value = Format(total, Hash)
            freeqty = Val(freeqty) + Val(dg1.Rows(i).Cells(12).Value)
            lblTotQty.Text = Val(lblTotQty.Text) + Val(dg1.Rows(i).Cells(10).Value)
            If Val(freeqty) > 0 Then
                lblTotQty.Text = lblTotQty.Text & "+" & freeqty
            End If
        Next
        Dim tempTotTaxableGoods As Decimal = Val(TaxableTotal) + Val(GoodsCharges)
        Dim tempTotTaxableServices As Decimal = Val(TaxableTotal) + Val(ServicesCharges)

        '''''''''''''''''''''''''Charges Calculation Mathod''''''''''''''''''''''''''''''''''''''




        For i = 0 To Dg2.Rows.Count - 1
            Dim IsGST As String = clsFun.ExecScalarStr(" Select FixAs FROM Charges WHERE ID='" & Val(Dg2.Rows(i).Cells(5).Value) & "'")
            Dim ApplyOn As String = clsFun.ExecScalarStr(" Select Applyon FROM Charges WHERE ID='" & Val(Dg2.Rows(i).Cells(5).Value) & "'")
            Dim SupplyType As String = clsFun.ExecScalarStr(" Select SupplyType FROM Charges WHERE ID='" & Val(Dg2.Rows(i).Cells(5).Value) & "'")
            If clsFun.ExecScalarInt(" Select TaxID FROM Charges WHERE ID='" & Val(Dg2.Rows(i).Cells(5).Value) & "'") <> 0 Then GSTApplicable = "Yes" Else GSTApplicable = "No"
            If IsGST = "Not Applicable" And (ApplyOn = "Taxable Amount" Or ApplyOn = "Item Total") Then
                If Dg2.Rows(i).Cells(3).Value = "+" Then
                    txtAfterCharges.Text = Format(Val(txtAfterCharges.Text) + Val(Dg2.Rows(i).Cells(4).Value), Hash)
                ElseIf Dg2.Rows(i).Cells(3).Value = "-" Then
                    txtAfterCharges.Text = Format(Val(txtAfterCharges.Text) - Val(Dg2.Rows(i).Cells(4).Value), Hash)
                End If
            ElseIf IsGST = "Include in GST (Goods)" Then
                TotalIGST = 0.0 : TotalSGST = 0.0 : TotalCGST = 0.0 : TaxableTotal = Hash : txtBeforeCharges.Text = Hash : TotalCess = Hash
                For j = 0 To dg1.Rows.Count - 1
                    CessAmt = Hash
                    '  txtTotNetAmt.Text = Format(Val(txtTotNetAmt.Text) + Val(dg1.Rows(j).Cells(14).Value), Hash)
                    '    txtTotNetAmt.Text = Decimal.Truncate(txtTotNetAmt.Text)
                    ' txtTotDisAmt.Text = Format(Val(txtTotDisAmt.Text) + Val(Val(dg1.Rows(j).Cells(16).Value) + Val(dg1.Rows(j).Cells(33).Value)), Hash)
                    dg1.Rows(j).Cells(35).Value = (Val(txtCdPer.Text) * Val(Val(dg1.Rows(j).Cells(14).Value) - Val(Val(dg1.Rows(j).Cells(16).Value)) - Val(dg1.Rows(j).Cells(33).Value))) / 100
                    txtBeforeCharges.Text = Format(Val(txtBeforeCharges.Text) + Val(dg1.Rows(j).Cells(35).Value), Hash)
                    taxableamt = Format(Val(Val(dg1.Rows(j).Cells(14).Value) - Val(Val(dg1.Rows(j).Cells(16).Value) + Val(dg1.Rows(j).Cells(33).Value) + Val(dg1.Rows(j).Cells(35).Value))), Hash)
                    If lblTaxType.Text = "TI" Or lblTaxType.Text = "TE" Then
                        If ApplyOn = "Taxable Amount" And SupplyType = "Goods" Then
                            If Dg2.Rows(i).Cells(3).Value = "+" Then
                                dg1.Rows(j).Cells(50).Value = Val(dg1.Rows(j).Cells(50).Value) + (Format(Val(Val(Dg2.Rows(i).Cells(4).Value) / Val(tempTotTaxableGoods)) * Val(taxableamt), Hash))
                            ElseIf Dg2.Rows(i).Cells(3).Value = "-" Then
                                dg1.Rows(j).Cells(50).Value = Val(dg1.Rows(j).Cells(50).Value) + (Format(Val(-Val(Dg2.Rows(i).Cells(4).Value) / Val(tempTotTaxableGoods)) * Val(taxableamt), Hash))
                                'txtAfterCharges.Text = Format(Val(txtAfterCharges.Text) - Val(Dg2.Rows(i).Cells(10).Value), Hash)
                            End If
                        ElseIf ApplyOn = "Taxable Amount" And SupplyType = "Services" Then
                            If Dg2.Rows(i).Cells(3).Value = "+" Then
                                dg1.Rows(j).Cells(50).Value = Val(dg1.Rows(j).Cells(50).Value) + Format(Val(Val(Dg2.Rows(i).Cells(4).Value) / Val(tempTotTaxableServices)) * Val(taxableamt), Hash)
                                'txtAfterCharges.Text = Format(Val(txtAfterCharges.Text) + Val(Dg2.Rows(i).Cells(10).Value), Hash)
                            ElseIf Dg2.Rows(i).Cells(3).Value = "-" Then
                                dg1.Rows(j).Cells(50).Value = Val(dg1.Rows(j).Cells(50).Value) + (Format(Val(-Val(Dg2.Rows(i).Cells(4).Value) / Val(tempTotTaxableServices)) * Val(taxableamt), Hash))
                                'txtAfterCharges.Text = Format(Val(txtAfterCharges.Text) - Val(Dg2.Rows(i).Cells(10).Value), Hash)
                            End If
                        ElseIf ApplyOn = "Item Total" And SupplyType = "Goods" Then
                            If Dg2.Rows(i).Cells(3).Value = "+" Then
                                dg1.Rows(j).Cells(50).Value = Val(dg1.Rows(j).Cells(50).Value) + (Format(Val(Val(Dg2.Rows(i).Cells(4).Value) / Val(lblTotQty.Text)) * Val(dg1.Rows(j).Cells(9).Value), Hash))
                                'txtAfterCharges.Text = Format(Val(txtAfterCharges.Text) + Val(Dg2.Rows(i).Cells(10).Value), Hash)
                            ElseIf Dg2.Rows(i).Cells(3).Value = "-" Then
                                dg1.Rows(j).Cells(50).Value = Val(dg1.Rows(j).Cells(50).Value) + (Format(Val(-Val(Dg2.Rows(i).Cells(4).Value) / Val(lblTotQty.Text)) * Val(dg1.Rows(j).Cells(9).Value), Hash))
                                'txtAfterCharges.Text = Format(Val(txtAfterCharges.Text) - Val(Dg2.Rows(i).Cells(10).Value), Hash)
                            End If
                        ElseIf ApplyOn = "Item Total" And SupplyType = "Services" Then
                            If Dg2.Rows(i).Cells(3).Value = "+" Then
                                dg1.Rows(j).Cells(50).Value = Val(dg1.Rows(j).Cells(50).Value) + (Format(Val(Val(Dg2.Rows(i).Cells(4).Value) / Val(lblTotQty.Text)) * Val(dg1.Rows(j).Cells(9).Value), Hash))
                                'txtAfterCharges.Text = Format(Val(txtAfterCharges.Text) + Val(Dg2.Rows(i).Cells(10).Value), Hash)
                            ElseIf Dg2.Rows(i).Cells(3).Value = "-" Then
                                dg1.Rows(j).Cells(50).Value = Val(dg1.Rows(j).Cells(50).Value) + (Format(Val(-Val(Dg2.Rows(i).Cells(4).Value) / Val(lblTotQty.Text)) * Val(dg1.Rows(j).Cells(9).Value), Hash))
                                'txtAfterCharges.Text = Format(Val(txtAfterCharges.Text) - Val(Dg2.Rows(i).Cells(10).Value), Hash)
                            End If
                        End If
                        taxableamt = Format(Val(taxableamt) + Val(dg1.Rows(j).Cells(50).Value), Hash)
                        If dg1.Rows(j).Cells(47).Value = "Taxable" Then
                            CessAmt = Val(Val(taxableamt) * Val(dg1.Rows(j).Cells(46).Value) / 100)
                            TotalCess = Val(TotalCess) + Val(CessAmt)
                        ElseIf dg1.Rows(j).Cells(47).Value = "Qty" Then
                            CessAmt = Val(CessAmt) + Val(Val(Val(dg1.Rows(j).Cells(10).Value)) * Val(dg1.Rows(j).Cells(48).Value))
                            TotalCess = Val(TotalCess) + Val(CessAmt)
                        ElseIf dg1.Rows(j).Cells(47).Value = "Taxable+Qty" Then
                            CessAmt = Format(Val(Val(taxableamt) * Val(dg1.Rows(j).Cells(46).Value) / 100), Hash)
                            CessAmt = Format(Val(CessAmt) + Val(Val(Val(dg1.Rows(j).Cells(10).Value)) * Val(dg1.Rows(j).Cells(48).Value)), Hash)
                            TotalCess = Val(TotalCess) + Val(CessAmt)
                        End If

                        If lblRegion.Text = "Local" Then
                            'dg1.Rows(j).Cells(47).Value = taxableamt
                            taxamtSGST = Val(dg1.Rows(j).Cells(17).Value) / 2 * Val(Val(taxableamt) / 100)
                            taxamtCGST = Val(dg1.Rows(j).Cells(17).Value) / 2 * Val(Val(taxableamt) / 100)
                            taxamtIGST = 0
                            taxamt = taxamtCGST + taxamtSGST
                            TotalTax = TotalTax + taxamt
                            TotalSGST = TotalSGST + Format(Val(taxamtSGST), Hash)
                            TotalCGST = TotalCGST + Format(Val(taxamtCGST), Hash)
                            TotalIGST = 0
                            dg1.Rows(j).Cells(40).Value = Val(0)
                            dg1.Rows(j).Cells(42).Value = Val(dg1.Rows(j).Cells(17).Value) / 2
                            dg1.Rows(j).Cells(44).Value = Val(dg1.Rows(j).Cells(17).Value) / 2
                        Else
                            ' dg1.Rows(j).Cells(50).Value = Format(Val(Val(Dg2.Rows(i).Cells(4).Value) / Val(tempTotTaxable)) * Val(taxableamt), Hash)
                            'taxableamt = taxableamt + Val(dg1.Rows(j).Cells(50).Value)
                            '  dg1.Rows(j).Cells(47).Value = taxableamt
                            taxamtSGST = 0
                            taxamtCGST = 0
                            taxamtIGST = Val(dg1.Rows(j).Cells(17).Value) * Val(Val(taxableamt) / 100)
                            taxamt = taxamtCGST + taxamtIGST
                            TotalTax = TotalTax + taxamt
                            TotalSGST = 0
                            TotalCGST = 0
                            TotalIGST = TotalIGST + taxamtIGST
                            dg1.Rows(j).Cells(40).Value = Val(dg1.Rows(j).Cells(17).Value)
                            dg1.Rows(j).Cells(42).Value = Val(0)
                            dg1.Rows(j).Cells(44).Value = Val(0)
                        End If
                        dg1.Rows(j).Cells(49).Value = Hash
                        dg1.Rows(j).Cells(41).Value = Format(Val(taxamtIGST), Hash)
                        dg1.Rows(j).Cells(43).Value = Format(Val(taxamtSGST), Hash)
                        dg1.Rows(j).Cells(45).Value = Format(Val(taxamtCGST), Hash)
                        dg1.Rows(j).Cells(49).Value = Format(Val(CessAmt), Hash)
                        '   dg1.Rows(j).Cells(50).Value = Val(AppValue)
                        '  dg1.Rows(j).Cells(18).Value = Val(dg1.Rows(j).Cells(17).Value) * Val(Val(taxableamt) / 100)
                        'taxamt = (Format(Val(taxamtIGST), Hash) + Format(Val(taxamtCGST), Hash) + Format(Val(taxamtSGST), Hash))
                        dg1.Rows(j).Cells(18).Value = Format(Val(Val(dg1.Rows(j).Cells(41).Value) + Val(dg1.Rows(j).Cells(43).Value) + Val(dg1.Rows(j).Cells(45).Value) + Val(dg1.Rows(j).Cells(49).Value)), Hash)
                    Else
                        dg1.Rows(j).Cells(18).Value = Format(0, Hash)
                    End If

                    TaxableTotal = Format(Val(TaxableTotal) + Val(taxableamt), Hash)
                    txtTotTaxAmt.Text = Val(txtTotTaxAmt.Text) + Val(Val(dg1.Rows(j).Cells(41).Value) + Val(dg1.Rows(j).Cells(43).Value) + Val(dg1.Rows(j).Cells(45).Value) + Val(dg1.Rows(j).Cells(49).Value))
                    Dim total As Decimal = Val(taxableamt) + Val(dg1.Rows(j).Cells(18).Value)
                    dg1.Rows(j).Cells(19).Value = Format(total, Hash)

                Next
            ElseIf IsGST = "Not Applicable" And GSTApplicable = "No" Then
                If Dg2.Rows(i).Cells(3).Value = "+" Then
                    txtAfterCharges.Text = Format(Val(txtAfterCharges.Text) + Val(Dg2.Rows(i).Cells(4).Value), Hash)
                ElseIf Dg2.Rows(i).Cells(3).Value = "-" Then
                    txtAfterCharges.Text = Format(Val(txtAfterCharges.Text) - Val(Dg2.Rows(i).Cells(4).Value), Hash)
                End If
            ElseIf IsGST = "Exclude GST Applicable" And GSTApplicable <> "Yes" Then
                If Dg2.Rows(i).Cells(3).Value = "+" Then
                    txtAfterCharges.Text = Format(Val(txtAfterCharges.Text) + Val(Dg2.Rows(i).Cells(4).Value), Hash)
                ElseIf Dg2.Rows(i).Cells(3).Value = "-" Then
                    txtAfterCharges.Text = Format(Val(txtAfterCharges.Text) - Val(Dg2.Rows(i).Cells(4).Value), Hash)
                End If
            ElseIf IsGST = "Exclude GST Applicable" And GSTApplicable = "Yes" And SupplyType = "Goods" Then
                If Dg2.Rows(i).Cells(3).Value = "+" Then
                    Dg2.Rows(i).Cells(11).Value = Format(Val(Val(GoodschargesApprValue) / Val(tempTotTaxableGoods)) * Val(Dg2.Rows(i).Cells(4).Value), Hash)
                    Chargestaxable = Format(Val(Chargestaxable) + Val(Dg2.Rows(i).Cells(4).Value) + Val(Dg2.Rows(i).Cells(11).Value), Hash)
                ElseIf Dg2.Rows(i).Cells(3).Value = "-" Then
                    Dg2.Rows(i).Cells(11).Value = Format(-Val(Val(GoodschargesApprValue) / Val(tempTotTaxableGoods)) * Val(Dg2.Rows(i).Cells(4).Value), Hash)
                    Chargestaxable = Format(Val(Chargestaxable) - Val(Dg2.Rows(i).Cells(4).Value) + Val(Dg2.Rows(i).Cells(11).Value), Hash)
                End If
            ElseIf IsGST = "Exclude GST Applicable" And GSTApplicable = "Yes" And SupplyType = "Services" Then
                If Dg2.Rows(i).Cells(3).Value = "+" Then
                    'Dg2.Rows(i).Cells(11).Value = Val(Dg2.Rows(i).Cells(11).Value) + Format(Val(Val(Dg2.Rows(i).Cells(4).Value) / Val(tempTotTaxableServices)) * Val(Dg2.Rows(i).Cells(10).Value), Hash)
                    Chargestaxable = Format(Val(Chargestaxable) + Val(Val(Dg2.Rows(i).Cells(4).Value) + Val(Dg2.Rows(i).Cells(11).Value)), Hash)
                ElseIf Dg2.Rows(i).Cells(3).Value = "-" Then
                    'Dg2.Rows(i).Cells(11).Value = Val(Dg2.Rows(i).Cells(11).Value) + Format(Val(-Val(Dg2.Rows(i).Cells(4).Value) / Val(tempTotTaxableServices)) * Val(Dg2.Rows(i).Cells(10).Value), Hash)
                    Chargestaxable = Format(Val(Chargestaxable) - Val(Val(Dg2.Rows(i).Cells(4).Value) + Val(Dg2.Rows(i).Cells(11).Value)), Hash)
                End If
            End If
            If lblRegion.Text = "Local" Then
                If Dg2.Rows(i).Cells(3).Value = "+" Then
                    chargesCGST = chargesCGST + Val(Val(Dg2.Rows(i).Cells(4).Value) * (Val(Dg2.Rows(i).Cells(6).Value) / 2) / 100)
                    chargesSGST = chargesSGST + Val(Val(Dg2.Rows(i).Cells(4).Value) * (Val(Dg2.Rows(i).Cells(6).Value) / 2) / 100)
                    chagesIGST = 0
                Else
                    chargesCGST = chargesCGST - Val(Val(Dg2.Rows(i).Cells(4).Value) * (Val(Dg2.Rows(i).Cells(6).Value) / 2) / 100)
                    chargesSGST = chargesSGST - Val(Val(Dg2.Rows(i).Cells(4).Value) * (Val(Dg2.Rows(i).Cells(6).Value) / 2) / 100)
                End If
                Dg2.Rows(i).Cells(10).Value = Format(Val(Dg2.Rows(i).Cells(4).Value) + Val(Dg2.Rows(i).Cells(11).Value), Hash)
                Dg2.Rows(i).Cells(7).Value = Format(Val(Val(Val(Dg2.Rows(i).Cells(4).Value) + Val(Dg2.Rows(i).Cells(11).Value)) * (Val(Dg2.Rows(i).Cells(6).Value)) / 100), Hash)
            Else
                If Dg2.Rows(i).Cells(3).Value = "+" Then
                    chargesSGST = 0 : chargesCGST = 0
                    chargesIGST = Val(chargesIGST) + Val(Val(Val(Dg2.Rows(i).Cells(4).Value) + Val(Dg2.Rows(i).Cells(11).Value)) * (Val(Dg2.Rows(i).Cells(6).Value)) / 100)
                Else
                    chargesSGST = 0 : chargesCGST = 0
                    chargesIGST = Val(chargesIGST) - Val(Val(Val(Dg2.Rows(i).Cells(4).Value) + Val(Dg2.Rows(i).Cells(11).Value)) * (Val(Dg2.Rows(i).Cells(6).Value)) / 100)
                End If
                Dg2.Rows(i).Cells(10).Value = Format(Val(Dg2.Rows(i).Cells(4).Value) + Val(Dg2.Rows(i).Cells(11).Value), Hash)
                Dg2.Rows(i).Cells(7).Value = Format(Val(Val(Val(Dg2.Rows(i).Cells(4).Value) + Val(Dg2.Rows(i).Cells(11).Value)) * (Val(Dg2.Rows(i).Cells(6).Value)) / 100), Hash)
            End If
        Next



        '  calc2()

        'For i = 0 To Dg2.Rows.Count - 1
        '    Dim FixAs As String = clsFun.ExecScalarStr(" Select FixAs FROM Charges WHERE ID='" & Val(Dg2.Rows(i).Cells(5).Value) & "'")
        '    If Dg2.Rows(i).Cells(3).Value = "-" Then
        '        txtAfterCharges.Text = Format(Val(txtAfterCharges.Text) - Val(Dg2.Rows(i).Cells(10).Value), Hash)
        '        txtChargesTax.Text = Format(Val(txtChargesTax.Text) - Val(Dg2.Rows(i).Cells(7).Value), Hash)
        '    Else
        '        txtAfterCharges.Text = Format(Val(txtAfterCharges.Text) + Val(Dg2.Rows(i).Cells(10).Value), Hash)
        '        txtChargesTax.Text = Format(Val(txtChargesTax.Text) + Val(Dg2.Rows(i).Cells(7).Value), Hash)
        '    End If
        'Next
        TotalIGST = TotalIGST + chargesIGST
        TotalCGST = TotalCGST + chargesCGST
        TotalSGST = TotalSGST + chargesSGST
        ItemTotalTax = Val(txtTotTaxAmt.Text)
        txtBeforeCharges.Text = Format(Val(txtBeforeCharges.Text), Hash)
        If dg1.RowCount > 8 Then dg1.Columns(19).Width = 132 Else dg1.Columns(19).Width = 149
        If lblRegion.Text = "Local" Then TotalSGST = Format(Val(TotalSGST), Hash) : TotalCGST = Format(Val(TotalCGST), Hash) Else TotalIGST = Format(Val(TotalIGST), Hash)
        txtTotTaxable.Text = Format(Val(TaxableTotal) + Val(Chargestaxable), Hash)
        txtTotTotal.Text = Format(Val(Val(txtTotTaxable.Text) + Val(txtAfterCharges.Text) + TotalIGST + TotalSGST + TotalCGST + TotalCess), Hash)
        txtTotTaxAmt.Text = Format(Val(TotalIGST + TotalSGST + TotalCGST + TotalCess), Hash)
        Dim tmpamount As Double = CDbl(Val(txtTotTotal.Text))
        txtTotTotal.Text = Math.Round(Val(tmpamount), 0)
        txttotRoundoff.Text = Format(Val(txtTotTotal.Text) - Val(tmpamount), Hash)
        txtTotTotal.Text = Format(Val(txtTotTotal.Text), Hash)
        lblRecordCount.Text = Val(dg1.Rows.Count)
        If Val(txtAccountID.Text) = 7 Then
            txtTotCashAmt.Text = txtTotTotal.Text
            txtTotDueamt.Text = Format(0, Hash)
        Else
            txtTotCashAmt.Text = Format(0, Hash)
            txtTotDueamt.Text = txtTotTotal.Text
        End If
        autoGSTPick()
    End Sub
    Sub calc2()
        txtTotTaxable.Text = Hash
        txtTotNetAmt.Text = Format(0, Hash) : txtTotDisAmt.Text = Format(0, Hash)
        txtTotTaxAmt.Text = Format(0, Hash) : txtAfterCharges.Text = Format(0, Hash)
        txttotRoundoff.Text = Format(0, Hash) : txtTotTotal.Text = Format(0, Hash)
        txtTotCashAmt.Text = Format(0, Hash) : txtTotDueamt.Text = Format(0, Hash)
        lblTotQty.Text = Hash : txtBeforeCharges.Text = Format(0, Hash)
        taxableamt = 0.0 : taxamtIGST = 0.0 : TaxableTotal = Hash
        taxamtSGST = 0.0 : taxamtCGST = 0.0 : TotalTax = 0.0 : TotalIGST = 0.0
        TotalSGST = 0.0 : TotalCGST = 0.0 : Dim i As Integer
        CessAmt = 0.0 : TotalCess = 0.0 : Dim GSTApplicable As String = String.Empty
        Dim chargesIGST As Decimal = 0 : Dim chargesCGST As Decimal = 0
        Dim chargesSGST As Decimal = 0 : Dim AppValue As Decimal
        Dim TotAppValue As Decimal = 0 : Dim Chargestaxable As Decimal = 0
        Dim GoodschargesApprValue As Decimal = 0 : Dim ServicechargesApprValue As Decimal = 0
        Dim GoodsCharges As Decimal = 0 : Dim ServicesCharges As Decimal = 0
        For i = 0 To Dg2.Rows.Count - 1
            Dim IsGST As String = clsFun.ExecScalarStr(" Select FixAs FROM Charges WHERE ID='" & Val(Dg2.Rows(i).Cells(5).Value) & "'")
            Dim ApplyOn As String = clsFun.ExecScalarStr(" Select Applyon FROM Charges WHERE ID='" & Val(Dg2.Rows(i).Cells(5).Value) & "'")
            Dim SupplyType As String = clsFun.ExecScalarStr(" Select SupplyType FROM Charges WHERE ID='" & Val(Dg2.Rows(i).Cells(5).Value) & "'")
            If clsFun.ExecScalarInt(" Select TaxID FROM Charges WHERE ID='" & Val(Dg2.Rows(i).Cells(5).Value) & "'") <> 0 Then GSTApplicable = "Yes"
            If IsGST = "Include in GST (Goods)" And ApplyOn = "Taxable Amount" Then
                If SupplyType = "Goods" Then
                    If Dg2.Rows(i).Cells(3).Value = "+" Then
                        GoodschargesApprValue = Val(GoodschargesApprValue) + Val(Dg2.Rows(i).Cells(4).Value)
                    Else
                        GoodschargesApprValue = Val(GoodschargesApprValue) - Val(Dg2.Rows(i).Cells(4).Value)
                    End If

                ElseIf SupplyType = "Services" Then
                    If Dg2.Rows(i).Cells(3).Value = "+" Then
                        ServicechargesApprValue = Val(ServicechargesApprValue) + Val(Dg2.Rows(i).Cells(4).Value)
                    Else
                        ServicechargesApprValue = Val(ServicechargesApprValue) - Val(Dg2.Rows(i).Cells(4).Value)
                    End If

                End If

            ElseIf IsGST = "Exclude GST Applicable" And GSTApplicable = "Yes" Then
                If SupplyType = "Goods" Then
                    If Dg2.Rows(i).Cells(3).Value = "+" Then
                        GoodsCharges = Val(GoodsCharges) + Val(Dg2.Rows(i).Cells(4).Value)
                    Else
                        GoodsCharges = Val(GoodsCharges) - Val(Dg2.Rows(i).Cells(4).Value)
                    End If
                    Dg2.Rows(i).Cells(11).Value = Hash
                ElseIf SupplyType = "Services" Then
                    If Dg2.Rows(i).Cells(3).Value = "+" Then
                        ServicesCharges = Val(ServicesCharges) + Val(Dg2.Rows(i).Cells(4).Value)
                    Else
                        ServicesCharges = Val(ServicesCharges) - Val(Dg2.Rows(i).Cells(4).Value)
                    End If

                    Dg2.Rows(i).Cells(11).Value = Hash
                End If
            End If

        Next

        For i = 0 To dg1.Rows.Count - 1
            dg1.Rows(i).Cells(49).Value = Hash
            dg1.Rows(i).Cells(50).Value = Hash

            txtTotNetAmt.Text = Format(Val(txtTotNetAmt.Text) + Val(dg1.Rows(i).Cells(14).Value), Hash)
            '    txtTotNetAmt.Text = Decimal.Truncate(txtTotNetAmt.Text)
            txtTotDisAmt.Text = Format(Val(txtTotDisAmt.Text) + Val(Val(dg1.Rows(i).Cells(16).Value) + Val(dg1.Rows(i).Cells(33).Value)), Hash)
            dg1.Rows(i).Cells(35).Value = (Val(txtCdPer.Text) * Val(Val(dg1.Rows(i).Cells(14).Value) - Val(Val(dg1.Rows(i).Cells(16).Value)) - Val(dg1.Rows(i).Cells(33).Value))) / 100
            txtBeforeCharges.Text = Format(Val(txtBeforeCharges.Text) + Val(dg1.Rows(i).Cells(35).Value), Hash)
            taxableamt = Format(Val(Val(dg1.Rows(i).Cells(14).Value) - Val(Val(dg1.Rows(i).Cells(16).Value) + Val(dg1.Rows(i).Cells(33).Value) + Val(dg1.Rows(i).Cells(35).Value))), Hash)
            If lblTaxType.Text = "TI" Or lblTaxType.Text = "TE" Then
                If lblRegion.Text = "Local" Then
                    taxamtSGST = Val(dg1.Rows(i).Cells(17).Value) / 2 * Val(Val(taxableamt) / 100)
                    taxamtCGST = Val(dg1.Rows(i).Cells(17).Value) / 2 * Val(Val(taxableamt) / 100)
                    If dg1.Rows(i).Cells(47).Value = "Taxable" Then
                        CessAmt = Val(Val(taxableamt) * Val(dg1.Rows(i).Cells(46).Value) / 100)
                        dg1.Rows(i).Cells(49).Value = Format(Val(CessAmt), Hash)
                        TotalCess = Val(TotalCess) + Val(CessAmt)
                    ElseIf dg1.Rows(i).Cells(47).Value = "Qty" Then
                        CessAmt = Val(CessAmt) + Val(Val(Val(dg1.Rows(i).Cells(10).Value)) * Val(dg1.Rows(i).Cells(48).Value))
                        dg1.Rows(i).Cells(49).Value = Format(Val(CessAmt), Hash)
                        TotalCess = Val(TotalCess) + Val(CessAmt)
                    ElseIf dg1.Rows(i).Cells(47).Value = "Taxable+Qty" Then
                        CessAmt = Val(Val(taxableamt) * Val(dg1.Rows(i).Cells(46).Value) / 100)
                        CessAmt = Val(CessAmt) + Val(Val(Val(dg1.Rows(i).Cells(10).Value)) * Val(dg1.Rows(i).Cells(48).Value))
                        dg1.Rows(i).Cells(49).Value = Format(Val(CessAmt), Hash)
                        TotalCess = Val(TotalCess) + Val(CessAmt)
                    End If
                    taxamtIGST = 0
                    taxamt = taxamtCGST + taxamtSGST
                    TotalTax = TotalTax + (taxamt + CessAmt)
                    TotalSGST = TotalSGST + Format(Val(taxamtSGST), Hash)
                    TotalCGST = TotalCGST + Format(Val(taxamtCGST), Hash)
                    TotalIGST = 0 'TotalCess = TotalCess + CessAmt
                    dg1.Rows(i).Cells(40).Value = Val(0)
                    dg1.Rows(i).Cells(42).Value = Val(dg1.Rows(i).Cells(17).Value) / 2
                    dg1.Rows(i).Cells(44).Value = Val(dg1.Rows(i).Cells(17).Value) / 2
                Else
                    taxamtSGST = 0
                    taxamtCGST = 0
                    taxamtIGST = Val(dg1.Rows(i).Cells(17).Value) * Val(Val(taxableamt) / 100)
                    If dg1.Rows(i).Cells(47).Value = "Taxable" Then
                        CessAmt = Val(Val(taxableamt) * Val(dg1.Rows(i).Cells(46).Value) / 100)
                        dg1.Rows(i).Cells(49).Value = Format(Val(CessAmt), Hash)
                    ElseIf dg1.Rows(i).Cells(47).Value = "Qty" Then
                        CessAmt = Val(CessAmt) + Val(Val(Val(dg1.Rows(i).Cells(10).Value)) * Val(dg1.Rows(i).Cells(48).Value))
                        dg1.Rows(i).Cells(49).Value = Format(Val(CessAmt), Hash)
                    ElseIf dg1.Rows(i).Cells(47).Value = "Taxable+Qty" Then
                        CessAmt = Val(Val(taxableamt) * Val(dg1.Rows(i).Cells(46).Value) / 100)
                        CessAmt = Val(CessAmt) + Val(Val(Val(dg1.Rows(i).Cells(10).Value)) * Val(dg1.Rows(i).Cells(48).Value))
                        dg1.Rows(i).Cells(49).Value = Format(Val(CessAmt), Hash)
                    End If
                    TotalTax = TotalTax + taxamtIGST
                    TotalTax = TotalTax + (taxamt + CessAmt)
                    TotalSGST = 0 : TotalCGST = 0
                    TotalIGST = TotalIGST + taxamtIGST
                    TotalCess = TotalCess + CessAmt
                    dg1.Rows(i).Cells(40).Value = Val(dg1.Rows(i).Cells(17).Value)
                    dg1.Rows(i).Cells(42).Value = Val(0)
                    dg1.Rows(i).Cells(44).Value = Val(0)
                End If
                dg1.Rows(i).Cells(41).Value = Format(Val(taxamtIGST), Hash)
                dg1.Rows(i).Cells(43).Value = Format(Val(taxamtSGST), Hash)
                dg1.Rows(i).Cells(45).Value = Format(Val(taxamtCGST), Hash)
                dg1.Rows(i).Cells(50).Value = 0
                '  dg1.Rows(i).Cells(18).Value = Val(dg1.Rows(i).Cells(17).Value) * Val(Val(taxableamt) / 100)
                'taxamt = (Format(Val(taxamtIGST), Hash) + Format(Val(taxamtCGST), Hash) + Format(Val(taxamtSGST), Hash))
                dg1.Rows(i).Cells(18).Value = Format(0, Hash)
            Else
                dg1.Rows(i).Cells(18).Value = Format(0, Hash)
            End If

            TaxableTotal = Val(TaxableTotal) + Val(taxableamt)
            txtTotTaxAmt.Text = Format(0, Hash)
            Dim total As Decimal = Val(taxableamt) + Val(dg1.Rows(i).Cells(18).Value)
            dg1.Rows(i).Cells(19).Value = Format(total, Hash)
            freeqty = Val(freeqty) + Val(dg1.Rows(i).Cells(12).Value)
            lblTotQty.Text = Val(lblTotQty.Text) + Val(dg1.Rows(i).Cells(10).Value)
            If Val(freeqty) > 0 Then
                lblTotQty.Text = lblTotQty.Text & "+" & freeqty
            End If
        Next
        Dim tempTotTaxableGoods As Decimal = Val(TaxableTotal) + Val(GoodsCharges)
        Dim tempTotTaxableServices As Decimal = Val(TaxableTotal) + Val(ServicesCharges)

        '''''''''''''''''''''''''Charges Calculation Mathod''''''''''''''''''''''''''''''''''''''




        For i = 0 To Dg2.Rows.Count - 1
            Dim IsGST As String = clsFun.ExecScalarStr(" Select FixAs FROM Charges WHERE ID='" & Val(Dg2.Rows(i).Cells(5).Value) & "'")
            Dim ApplyOn As String = clsFun.ExecScalarStr(" Select Applyon FROM Charges WHERE ID='" & Val(Dg2.Rows(i).Cells(5).Value) & "'")
            Dim SupplyType As String = clsFun.ExecScalarStr(" Select SupplyType FROM Charges WHERE ID='" & Val(Dg2.Rows(i).Cells(5).Value) & "'")
            If clsFun.ExecScalarInt(" Select TaxID FROM Charges WHERE ID='" & Val(Dg2.Rows(i).Cells(5).Value) & "'") <> 0 Then GSTApplicable = "Yes" Else GSTApplicable = "No"
            If IsGST = "Not Applicable" And (ApplyOn = "Taxable Amount" Or ApplyOn = "Item Total") Then
                If Dg2.Rows(i).Cells(3).Value = "+" Then
                    txtAfterCharges.Text = Format(Val(txtAfterCharges.Text) + Val(Dg2.Rows(i).Cells(4).Value), Hash)
                ElseIf Dg2.Rows(i).Cells(3).Value = "-" Then
                    txtAfterCharges.Text = Format(Val(txtAfterCharges.Text) - Val(Dg2.Rows(i).Cells(4).Value), Hash)
                End If
            ElseIf IsGST = "Include in GST (Goods)" Then
                TotalIGST = 0.0 : TotalSGST = 0.0 : TotalCGST = 0.0 : TaxableTotal = Hash : txtBeforeCharges.Text = Hash : TotalCess = Hash
                For j = 0 To dg1.Rows.Count - 1
                    CessAmt = Hash
                    '  txtTotNetAmt.Text = Format(Val(txtTotNetAmt.Text) + Val(dg1.Rows(j).Cells(14).Value), Hash)
                    '    txtTotNetAmt.Text = Decimal.Truncate(txtTotNetAmt.Text)
                    ' txtTotDisAmt.Text = Format(Val(txtTotDisAmt.Text) + Val(Val(dg1.Rows(j).Cells(16).Value) + Val(dg1.Rows(j).Cells(33).Value)), Hash)
                    dg1.Rows(j).Cells(35).Value = (Val(txtCdPer.Text) * Val(Val(dg1.Rows(j).Cells(14).Value) - Val(Val(dg1.Rows(j).Cells(16).Value)) - Val(dg1.Rows(j).Cells(33).Value))) / 100
                    txtBeforeCharges.Text = Format(Val(txtBeforeCharges.Text) + Val(dg1.Rows(j).Cells(35).Value), Hash)
                    taxableamt = Format(Val(Val(dg1.Rows(j).Cells(14).Value) - Val(Val(dg1.Rows(j).Cells(16).Value) + Val(dg1.Rows(j).Cells(33).Value) + Val(dg1.Rows(j).Cells(35).Value))), Hash)
                    If lblTaxType.Text = "TI" Or lblTaxType.Text = "TE" Then
                        If ApplyOn = "Taxable Amount" And SupplyType = "Goods" Then
                            If Dg2.Rows(i).Cells(3).Value = "+" Then
                                dg1.Rows(j).Cells(50).Value = Val(dg1.Rows(j).Cells(50).Value) + (Format(Val(Val(Dg2.Rows(i).Cells(4).Value) / Val(tempTotTaxableGoods)) * Val(taxableamt), Hash))
                            ElseIf Dg2.Rows(i).Cells(3).Value = "-" Then
                                dg1.Rows(j).Cells(50).Value = Val(dg1.Rows(j).Cells(50).Value) + (Format(Val(-Val(Dg2.Rows(i).Cells(4).Value) / Val(tempTotTaxableGoods)) * Val(taxableamt), Hash))
                                'txtAfterCharges.Text = Format(Val(txtAfterCharges.Text) - Val(Dg2.Rows(i).Cells(10).Value), Hash)
                            End If
                        ElseIf ApplyOn = "Taxable Amount" And SupplyType = "Services" Then
                            If Dg2.Rows(i).Cells(3).Value = "+" Then
                                dg1.Rows(j).Cells(50).Value = Val(dg1.Rows(j).Cells(50).Value) + Format(Val(Val(Dg2.Rows(i).Cells(4).Value) / Val(tempTotTaxableServices)) * Val(taxableamt), Hash)
                                'txtAfterCharges.Text = Format(Val(txtAfterCharges.Text) + Val(Dg2.Rows(i).Cells(10).Value), Hash)
                            ElseIf Dg2.Rows(i).Cells(3).Value = "-" Then
                                dg1.Rows(j).Cells(50).Value = Val(dg1.Rows(j).Cells(50).Value) + (Format(Val(-Val(Dg2.Rows(i).Cells(4).Value) / Val(tempTotTaxableServices)) * Val(taxableamt), Hash))
                                'txtAfterCharges.Text = Format(Val(txtAfterCharges.Text) - Val(Dg2.Rows(i).Cells(10).Value), Hash)
                            End If
                        ElseIf ApplyOn = "Item Total" And SupplyType = "Goods" Then
                            If Dg2.Rows(i).Cells(3).Value = "+" Then
                                dg1.Rows(j).Cells(50).Value = Val(dg1.Rows(j).Cells(50).Value) + (Format(Val(Val(Dg2.Rows(i).Cells(4).Value) / Val(lblTotQty.Text)) * Val(dg1.Rows(j).Cells(9).Value), Hash))
                                'txtAfterCharges.Text = Format(Val(txtAfterCharges.Text) + Val(Dg2.Rows(i).Cells(10).Value), Hash)
                            ElseIf Dg2.Rows(i).Cells(3).Value = "-" Then
                                dg1.Rows(j).Cells(50).Value = Val(dg1.Rows(j).Cells(50).Value) + (Format(Val(-Val(Dg2.Rows(i).Cells(4).Value) / Val(lblTotQty.Text)) * Val(dg1.Rows(j).Cells(9).Value), Hash))
                                'txtAfterCharges.Text = Format(Val(txtAfterCharges.Text) - Val(Dg2.Rows(i).Cells(10).Value), Hash)
                            End If
                        ElseIf ApplyOn = "Item Total" And SupplyType = "Services" Then
                            If Dg2.Rows(i).Cells(3).Value = "+" Then
                                dg1.Rows(j).Cells(50).Value = Val(dg1.Rows(j).Cells(50).Value) + (Format(Val(Val(Dg2.Rows(i).Cells(4).Value) / Val(lblTotQty.Text)) * Val(dg1.Rows(j).Cells(9).Value), Hash))
                                'txtAfterCharges.Text = Format(Val(txtAfterCharges.Text) + Val(Dg2.Rows(i).Cells(10).Value), Hash)
                            ElseIf Dg2.Rows(i).Cells(3).Value = "-" Then
                                dg1.Rows(j).Cells(50).Value = Val(dg1.Rows(j).Cells(50).Value) + (Format(Val(-Val(Dg2.Rows(i).Cells(4).Value) / Val(lblTotQty.Text)) * Val(dg1.Rows(j).Cells(9).Value), Hash))
                                'txtAfterCharges.Text = Format(Val(txtAfterCharges.Text) - Val(Dg2.Rows(i).Cells(10).Value), Hash)
                            End If
                        End If
                        taxableamt = Format(Val(taxableamt) + Val(dg1.Rows(j).Cells(50).Value), Hash)
                        If dg1.Rows(j).Cells(47).Value = "Taxable" Then
                            CessAmt = Val(Val(taxableamt) * Val(dg1.Rows(j).Cells(46).Value) / 100)
                            TotalCess = Val(TotalCess) + Val(CessAmt)
                        ElseIf dg1.Rows(j).Cells(47).Value = "Qty" Then
                            CessAmt = Val(CessAmt) + Val(Val(Val(dg1.Rows(j).Cells(10).Value)) * Val(dg1.Rows(j).Cells(48).Value))
                            TotalCess = Val(TotalCess) + Val(CessAmt)
                        ElseIf dg1.Rows(j).Cells(47).Value = "Taxable+Qty" Then
                            CessAmt = Format(Val(Val(taxableamt) * Val(dg1.Rows(j).Cells(46).Value) / 100), Hash)
                            CessAmt = Format(Val(CessAmt) + Val(Val(Val(dg1.Rows(j).Cells(10).Value)) * Val(dg1.Rows(j).Cells(48).Value)), Hash)
                            TotalCess = Val(TotalCess) + Val(CessAmt)
                        End If

                        If lblRegion.Text = "Local" Then
                            'dg1.Rows(j).Cells(47).Value = taxableamt
                            taxamtSGST = Val(dg1.Rows(j).Cells(17).Value) / 2 * Val(Val(taxableamt) / 100)
                            taxamtCGST = Val(dg1.Rows(j).Cells(17).Value) / 2 * Val(Val(taxableamt) / 100)
                            taxamtIGST = 0
                            taxamt = taxamtCGST + taxamtSGST
                            TotalTax = TotalTax + taxamt
                            TotalSGST = TotalSGST + Format(Val(taxamtSGST), Hash)
                            TotalCGST = TotalCGST + Format(Val(taxamtCGST), Hash)
                            TotalIGST = 0
                            dg1.Rows(j).Cells(40).Value = Val(0)
                            dg1.Rows(j).Cells(42).Value = Val(dg1.Rows(j).Cells(17).Value) / 2
                            dg1.Rows(j).Cells(44).Value = Val(dg1.Rows(j).Cells(17).Value) / 2
                        Else
                            ' dg1.Rows(j).Cells(50).Value = Format(Val(Val(Dg2.Rows(i).Cells(4).Value) / Val(tempTotTaxable)) * Val(taxableamt), Hash)
                            'taxableamt = taxableamt + Val(dg1.Rows(j).Cells(50).Value)
                            '  dg1.Rows(j).Cells(47).Value = taxableamt
                            taxamtSGST = 0
                            taxamtCGST = 0
                            taxamtIGST = Val(dg1.Rows(j).Cells(17).Value) * Val(Val(taxableamt) / 100)
                            taxamt = taxamtCGST + taxamtIGST
                            TotalTax = TotalTax + taxamt
                            TotalSGST = 0
                            TotalCGST = 0
                            TotalIGST = TotalIGST + taxamtIGST
                            dg1.Rows(j).Cells(40).Value = Val(dg1.Rows(j).Cells(17).Value)
                            dg1.Rows(j).Cells(42).Value = Val(0)
                            dg1.Rows(j).Cells(44).Value = Val(0)
                        End If
                        dg1.Rows(j).Cells(49).Value = Hash
                        dg1.Rows(j).Cells(41).Value = Format(Val(taxamtIGST), Hash)
                        dg1.Rows(j).Cells(43).Value = Format(Val(taxamtSGST), Hash)
                        dg1.Rows(j).Cells(45).Value = Format(Val(taxamtCGST), Hash)
                        dg1.Rows(j).Cells(49).Value = Format(Val(CessAmt), Hash)
                        '   dg1.Rows(j).Cells(50).Value = Val(AppValue)
                        '  dg1.Rows(j).Cells(18).Value = Val(dg1.Rows(j).Cells(17).Value) * Val(Val(taxableamt) / 100)
                        'taxamt = (Format(Val(taxamtIGST), Hash) + Format(Val(taxamtCGST), Hash) + Format(Val(taxamtSGST), Hash))
                        dg1.Rows(j).Cells(18).Value = Format(0, Hash)
                    Else
                        dg1.Rows(j).Cells(18).Value = Format(0, Hash)
                    End If

                    TaxableTotal = Format(Val(TaxableTotal) + Val(taxableamt), Hash)
                    txtTotTaxAmt.Text = Format(0, Hash)
                    Dim total As Decimal = Val(taxableamt) + Val(dg1.Rows(j).Cells(18).Value)
                    dg1.Rows(j).Cells(19).Value = Format(total, Hash)

                Next
            ElseIf IsGST = "Not Applicable" And GSTApplicable = "No" Then
                If Dg2.Rows(i).Cells(3).Value = "+" Then
                    txtAfterCharges.Text = Format(Val(txtAfterCharges.Text) + Val(Dg2.Rows(i).Cells(4).Value), Hash)
                ElseIf Dg2.Rows(i).Cells(3).Value = "-" Then
                    txtAfterCharges.Text = Format(Val(txtAfterCharges.Text) - Val(Dg2.Rows(i).Cells(4).Value), Hash)
                End If
            ElseIf IsGST = "Exclude GST Applicable" And GSTApplicable <> "Yes" Then
                If Dg2.Rows(i).Cells(3).Value = "+" Then
                    txtAfterCharges.Text = Format(Val(txtAfterCharges.Text) + Val(Dg2.Rows(i).Cells(4).Value), Hash)
                ElseIf Dg2.Rows(i).Cells(3).Value = "-" Then
                    txtAfterCharges.Text = Format(Val(txtAfterCharges.Text) - Val(Dg2.Rows(i).Cells(4).Value), Hash)
                End If
            ElseIf IsGST = "Exclude GST Applicable" And GSTApplicable = "Yes" And SupplyType = "Goods" Then
                If Dg2.Rows(i).Cells(3).Value = "+" Then
                    Dg2.Rows(i).Cells(11).Value = Format(Val(Val(GoodschargesApprValue) / Val(tempTotTaxableGoods)) * Val(Dg2.Rows(i).Cells(4).Value), Hash)
                    Chargestaxable = Format(Val(Chargestaxable) + Val(Dg2.Rows(i).Cells(4).Value) + Val(Dg2.Rows(i).Cells(11).Value), Hash)
                ElseIf Dg2.Rows(i).Cells(3).Value = "-" Then
                    Dg2.Rows(i).Cells(11).Value = Format(-Val(Val(GoodschargesApprValue) / Val(tempTotTaxableGoods)) * Val(Dg2.Rows(i).Cells(4).Value), Hash)
                    Chargestaxable = Format(Val(Chargestaxable) - Val(Dg2.Rows(i).Cells(4).Value) + Val(Dg2.Rows(i).Cells(11).Value), Hash)
                End If
            ElseIf IsGST = "Exclude GST Applicable" And GSTApplicable = "Yes" And SupplyType = "Services" Then
                If Dg2.Rows(i).Cells(3).Value = "+" Then
                    'Dg2.Rows(i).Cells(11).Value = Val(Dg2.Rows(i).Cells(11).Value) + Format(Val(Val(Dg2.Rows(i).Cells(4).Value) / Val(tempTotTaxableServices)) * Val(Dg2.Rows(i).Cells(10).Value), Hash)
                    Chargestaxable = Format(Val(Chargestaxable) + Val(Val(Dg2.Rows(i).Cells(4).Value) + Val(Dg2.Rows(i).Cells(11).Value)), Hash)
                ElseIf Dg2.Rows(i).Cells(3).Value = "-" Then
                    'Dg2.Rows(i).Cells(11).Value = Val(Dg2.Rows(i).Cells(11).Value) + Format(Val(-Val(Dg2.Rows(i).Cells(4).Value) / Val(tempTotTaxableServices)) * Val(Dg2.Rows(i).Cells(10).Value), Hash)
                    Chargestaxable = Format(Val(Chargestaxable) - Val(Val(Dg2.Rows(i).Cells(4).Value) + Val(Dg2.Rows(i).Cells(11).Value)), Hash)
                End If
            End If
            If lblRegion.Text = "Local" Then
                If Dg2.Rows(i).Cells(3).Value = "+" Then
                    chargesCGST = chargesCGST + Val(Val(Dg2.Rows(i).Cells(4).Value) * (Val(Dg2.Rows(i).Cells(6).Value) / 2) / 100)
                    chargesSGST = chargesSGST + Val(Val(Dg2.Rows(i).Cells(4).Value) * (Val(Dg2.Rows(i).Cells(6).Value) / 2) / 100)
                    chagesIGST = 0
                Else
                    chargesCGST = chargesCGST - Val(Val(Dg2.Rows(i).Cells(4).Value) * (Val(Dg2.Rows(i).Cells(6).Value) / 2) / 100)
                    chargesSGST = chargesSGST - Val(Val(Dg2.Rows(i).Cells(4).Value) * (Val(Dg2.Rows(i).Cells(6).Value) / 2) / 100)
                End If
                Dg2.Rows(i).Cells(10).Value = Format(Val(Dg2.Rows(i).Cells(4).Value) + Val(Dg2.Rows(i).Cells(11).Value), Hash)
                Dg2.Rows(i).Cells(7).Value = Format(Val(Val(Val(Dg2.Rows(i).Cells(4).Value) + Val(Dg2.Rows(i).Cells(11).Value)) * (Val(Dg2.Rows(i).Cells(6).Value)) / 100), Hash)
            Else
                If Dg2.Rows(i).Cells(3).Value = "+" Then
                    chargesSGST = 0 : chargesCGST = 0
                    chargesIGST = Val(chargesIGST) + Val(Val(Val(Dg2.Rows(i).Cells(4).Value) + Val(Dg2.Rows(i).Cells(11).Value)) * (Val(Dg2.Rows(i).Cells(6).Value)) / 100)
                Else
                    chargesSGST = 0 : chargesCGST = 0
                    chargesIGST = Val(chargesIGST) - Val(Val(Val(Dg2.Rows(i).Cells(4).Value) + Val(Dg2.Rows(i).Cells(11).Value)) * (Val(Dg2.Rows(i).Cells(6).Value)) / 100)
                End If
                Dg2.Rows(i).Cells(10).Value = Format(Val(Dg2.Rows(i).Cells(4).Value) + Val(Dg2.Rows(i).Cells(11).Value), Hash)
                Dg2.Rows(i).Cells(7).Value = Format(Val(Val(Val(Dg2.Rows(i).Cells(4).Value) + Val(Dg2.Rows(i).Cells(11).Value)) * (Val(Dg2.Rows(i).Cells(6).Value)) / 100), Hash)
            End If
        Next



        '  calc2()

        'For i = 0 To Dg2.Rows.Count - 1
        '    Dim FixAs As String = clsFun.ExecScalarStr(" Select FixAs FROM Charges WHERE ID='" & Val(Dg2.Rows(i).Cells(5).Value) & "'")
        '    If Dg2.Rows(i).Cells(3).Value = "-" Then
        '        txtAfterCharges.Text = Format(Val(txtAfterCharges.Text) - Val(Dg2.Rows(i).Cells(10).Value), Hash)
        '        txtChargesTax.Text = Format(Val(txtChargesTax.Text) - Val(Dg2.Rows(i).Cells(7).Value), Hash)
        '    Else
        '        txtAfterCharges.Text = Format(Val(txtAfterCharges.Text) + Val(Dg2.Rows(i).Cells(10).Value), Hash)
        '        txtChargesTax.Text = Format(Val(txtChargesTax.Text) + Val(Dg2.Rows(i).Cells(7).Value), Hash)
        '    End If
        'Next
        TotalIGST = TotalIGST + chargesIGST
        TotalCGST = TotalCGST + chargesCGST
        TotalSGST = TotalSGST + chargesSGST
        ItemTotalTax = Val(txtTotTaxAmt.Text)
        If dg1.RowCount > 8 Then dg1.Columns(19).Width = 132 Else dg1.Columns(19).Width = 149
        If lblRegion.Text = "Local" Then TotalSGST = Format(Val(TotalSGST), Hash) : TotalCGST = Format(Val(TotalCGST), Hash) Else TotalIGST = Format(Val(TotalIGST), Hash)
        txtTotTaxable.Text = Format(Val(TaxableTotal) + Val(Chargestaxable), Hash)
        txtTotTotal.Text = Format(Val(Val(txtTotTaxable.Text) + Val(txtAfterCharges.Text)), Hash)
        txtTotTaxAmt.Text = Format(0, Hash)
        Dim tmpamount As Double = CDbl(Val(txtTotTotal.Text))
        txtTotTotal.Text = Math.Round(Val(tmpamount), 0)
        txttotRoundoff.Text = Format(Val(txtTotTotal.Text) - Val(tmpamount), Hash)
        txtTotTotal.Text = Format(Val(txtTotTotal.Text), Hash)
        lblRecordCount.Text = Val(dg1.Rows.Count)
        If Val(txtAccountID.Text) = 7 Then
            txtTotCashAmt.Text = txtTotTotal.Text
            txtTotDueamt.Text = Format(0, Hash)
        Else
            txtTotCashAmt.Text = Format(0, Hash)
            txtTotDueamt.Text = txtTotTotal.Text
        End If
        autoGSTPick()
    End Sub
    Private Sub dgCharges_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCharges.CellClick
        txtCharges.Clear() : txtChargeID.Clear()
        txtChargeID.Text = dgCharges.SelectedRows(0).Cells(0).Value
        txtCharges.Text = dgCharges.SelectedRows(0).Cells(1).Value
        dgCharges.Visible = False : txtOnValue.Focus()
        FillCharges()

    End Sub

    Private Sub dgCharges_KeyDown(sender As Object, e As KeyEventArgs) Handles dgCharges.KeyDown
        If e.KeyCode = Keys.PageUp Then If dgCharges.CurrentRow.Index = 0 Then txtCharges.Focus()
        If e.KeyCode = Keys.Enter Then
            txtCharges.Clear() : txtChargeID.Clear()
            txtChargeID.Text = Val(dgCharges.SelectedRows(0).Cells(0).Value)
            txtCharges.Text = dgCharges.SelectedRows(0).Cells(1).Value
            dgCharges.Visible = False : txtOnValue.Focus()
            FillCharges() : e.SuppressKeyPress = True
        End If
        If e.KeyCode = Keys.Back Then txtCharges.Focus()
    End Sub

    Private Sub Dg2_KeyDown(sender As Object, e As KeyEventArgs) Handles Dg2.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Dg2.SelectedRows.Count = 0 Then Exit Sub
            txtCharges.Text = Dg2.SelectedRows(0).Cells(0).Value
            txtOnValue.Text = Format(Val(Dg2.SelectedRows(0).Cells(1).Value), Hash)
            txtCalculatePer.Text = Format(Val(Dg2.SelectedRows(0).Cells(2).Value), Hash)
            txtPlusMinus.Text = Dg2.SelectedRows(0).Cells(3).Value
            txtchargesAmount.Text = Format(Val(Dg2.SelectedRows(0).Cells(4).Value), Hash)
            txtChargeID.Text = Val(Dg2.SelectedRows(0).Cells(5).Value)
            txtGstperCharge.Text = Format(Val(Dg2.SelectedRows(0).Cells(6).Value), Hash)
            txtGSTAmtCharge.Text = Format(Val(Dg2.SelectedRows(0).Cells(7).Value), Hash)
            txtCessPerCharge.Text = Format(Val(Dg2.SelectedRows(0).Cells(8).Value), Hash)
            txtCessAmtCharge.Text = Format(Val(Dg2.SelectedRows(0).Cells(9).Value), Hash)
            txtChargeTaxable.Text = Format(Val(Dg2.SelectedRows(0).Cells(10).Value), Hash)
            txtCharges.Focus() : e.SuppressKeyPress = True
        End If

        If e.KeyCode = Keys.Back Then txtCharges.Focus()
    End Sub

    Private Sub txtchargesAmount_GotFocus(sender As Object, e As EventArgs) Handles txtchargesAmount.GotFocus
        '   If pnlGSTCharges.Visible <> True Then
        If txtOnValue.TabStop = False Then
            If dgCharges.ColumnCount = 0 Then ChargesRowColums()
            If dgCharges.RowCount = 0 Then RetriveCharges()
            If dgCharges.SelectedRows.Count = 0 Then dgCharges.Visible = True
            txtCharges.Text = dgCharges.SelectedRows(0).Cells(1).Value
            txtChargeID.Text = Val(dgCharges.SelectedRows(0).Cells(0).Value)
            dgCharges.Visible = False : FillCharges()
            If pnlGSTCharges.Visible = True Then txtChargeTaxable.Text = Format(Val(txtchargesAmount.Text), Hash) Else txtChargeTaxable.Text = Hash
            '    If pnlGSTCharges.Visible = True Then txtChargeTaxable.Focus()
            'End If
        End If


    End Sub
    Private Sub txtchargesAmount_TextChanged(sender As Object, e As EventArgs) Handles txtchargesAmount.TextChanged
        If pnlGSTCharges.Visible = True Then txtChargeTaxable.Text = Format(Val(txtchargesAmount.Text), Hash) Else txtChargeTaxable.Text = Hash
    End Sub

    Private Sub Dg2_MouseClick(sender As Object, e As MouseEventArgs) Handles Dg2.MouseClick
        Dg2.ClearSelection()
    End Sub

    Private Sub Dg2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Dg2.MouseDoubleClick
        If Dg2.SelectedRows.Count = 0 Then Exit Sub
        txtCharges.Text = Dg2.SelectedRows(0).Cells(0).Value
        txtOnValue.Text = Format(Val(Dg2.SelectedRows(0).Cells(1).Value), Hash)
        txtCalculatePer.Text = Format(Val(Dg2.SelectedRows(0).Cells(2).Value), Hash)
        txtPlusMinus.Text = Dg2.SelectedRows(0).Cells(3).Value
        txtchargesAmount.Text = Format(Val(Dg2.SelectedRows(0).Cells(4).Value), Hash)
        txtChargeID.Text = Val(Dg2.SelectedRows(0).Cells(5).Value)
        txtGstperCharge.Text = Format(Val(Dg2.SelectedRows(0).Cells(6).Value), Hash)
        txtGSTAmtCharge.Text = Format(Val(Dg2.SelectedRows(0).Cells(7).Value), Hash)
        txtCessPerCharge.Text = Format(Val(Dg2.SelectedRows(0).Cells(8).Value), Hash)
        txtCessAmtCharge.Text = Format(Val(Dg2.SelectedRows(0).Cells(9).Value), Hash)
        txtChargeTaxable.Text = Format(Val(Dg2.SelectedRows(0).Cells(10).Value), Hash)
        txtCharges.Focus()
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

    Private Sub txtQty_GotFocus(sender As Object, e As EventArgs) Handles txtQty.GotFocus
        pnlItemInfo.Visible = True : pnlItemInfo.BringToFront()
        If dgItemSearch.ColumnCount = 0 Then ItemRowColumns()
        If dgItemSearch.Rows.Count = 0 Then retriveItems()
        If dgItemSearch.SelectedRows.Count = 0 Then dgItemSearch.Visible = True : txtItem.Focus() : Exit Sub
        txtItemID.Text = Val(dgItemSearch.SelectedRows(0).Cells(0).Value)
        txtItem.Text = dgItemSearch.SelectedRows(0).Cells(1).Value
        lblUOM.Text = dgItemSearch.SelectedRows(0).Cells(3).Value
        'ItemBalance() 
        ItemFill() : dgItemSearch.Visible = False
        '  If lblbatch.Text = "Y" Then cbbatch.Focus() Else txtQty.Focus()
    End Sub

    Private Sub txtRate_GotFocus(sender As Object, e As EventArgs) Handles txtRate.GotFocus
        pnlaltinfo.Visible = False : pnlDisc.Visible = False : pnlSerial.Visible = False
        If lblTaxType.Text = "TI" Then pnlNetRate.Visible = True : txtNetRate.TabStop = False
    End Sub

    Private Sub mskEntryDate_GotFocus(sender As Object, e As EventArgs) Handles mskEntryDate.GotFocus, mskEntryDate.Click
        mskEntryDate.SelectionStart = 0 : mskEntryDate.SelectionLength = Len(mskEntryDate.Text)
    End Sub
    Private Sub mskEntryDate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mskEntryDate.Validating
        mskEntryDate.Text = clsFun.convdate(mskEntryDate.Text)
    End Sub
    Private Sub txtVoucherNo_GotFocus(sender As Object, e As EventArgs) Handles txtVoucherNo.GotFocus, txtVoucherNo.Click
        txtVoucherNo.SelectionStart = 0 : txtVoucherNo.SelectionLength = Len(txtVoucherNo.Text)
    End Sub

    Private Sub cbbatch_GotFocus(sender As Object, e As EventArgs) Handles cbbatch.GotFocus
        If dgItemSearch.ColumnCount = 0 Then ItemRowColumns()
        If dgItemSearch.Rows.Count = 0 Then retriveItems()
        If dgItemSearch.SelectedRows.Count = 0 Then dgItemSearch.Visible = True : txtItem.Focus() : Exit Sub
        txtItemID.Text = Val(dgItemSearch.SelectedRows(0).Cells(0).Value)
        txtItem.Text = dgItemSearch.SelectedRows(0).Cells(1).Value
        lblUOM.Text = dgItemSearch.SelectedRows(0).Cells(2).Value
        dgItemSearch.Visible = False : ItemBalance() : ItemFill()
    End Sub

    Private Sub txtDisPer_GotFocus(sender As Object, e As EventArgs) Handles txtDisPer.GotFocus
        'pnlItemInfo.Visible = False : pnlaltinfo.Visible = False : pnlNetRate.Visible = False : pnlPricePer.Visible = False
        'DiscountSetting()
    End Sub
    Private Sub DiscountSetting()
        'If clsFun.ExecScalarInt("Select Count(*) From DiscountSetting Where ApplicableOn='Purchase'") <= 0 Then pnlDisc.Visible = False : lblDisHead1.Text = "" : lblDisHead2.Text = "" : lblDisHead3.Text = "" : lblDisHead4.Text = "" : Exit Sub
        'pnlDisc.BorderStyle = BorderStyle.FixedSingle
        'If clsFun.ExecScalarStr("Select Enable1 From DiscountSetting") = "Y" Then
        '    txtOnValue1.Visible = True : txtCalPer1.Visible = True : txtDisAmt1.Visible = True
        '    lblDisHead1.Text = clsFun.ExecScalarStr("Select DiscountHead1 From DiscountSetting")
        '    If dg1.SelectedRows.Count = 0 Then txtCalPer1.Text = clsFun.ExecScalarStr("Select Calculate1 From DiscountSetting")
        '    lblPlusMins1.Text = clsFun.ExecScalarStr("Select Addless1 From DiscountSetting")
        '    If clsFun.ExecScalarStr("Select ApplyOn1 From DiscountSetting") = "Balance Value" Then
        '        txtOnValue1.Text = Format(Val(txtNet.Text) - Val(txtDisAmt.Text), Hash)
        '    ElseIf clsFun.ExecScalarStr("Select ApplyOn1 From DiscountSetting") = "Basic Value" Then
        '        txtOnValue1.Text = Format(Val(txtNet.Text), "0.000")
        '    End If
        '    pnlDisc.Size = New Size(688, 67)
        '    pnlDisc.Visible = True : pnlDisc.BringToFront()
        'Else
        '    lblDisHead1.Text = "" : txtOnValue1.Text = "" : txtCalPer1.Text = "" : txtDisAmt1.Text = ""
        '    lblDisHead1.Visible = False : txtOnValue1.Visible = False : txtCalPer1.Visible = False : txtDisAmt1.Visible = False
        'End If
        'If clsFun.ExecScalarStr("Select Enable2 From DiscountSetting") = "Y" Then
        '    txtOnValue2.Visible = True : txtCalPer2.Visible = True : txtDisAmt2.Visible = True
        '    lblDisHead2.Text = clsFun.ExecScalarStr("Select DiscountHead2 From DiscountSetting")
        '    If dg1.SelectedRows.Count <> 0 Then txtCalPer2.Text = clsFun.ExecScalarStr("Select Calculate2 From DiscountSetting")
        '    lblPlusMins2.Text = clsFun.ExecScalarStr("Select Addless2 From DiscountSetting")
        '    If clsFun.ExecScalarStr("Select ApplyOn2 From DiscountSetting") = "Balance Value" Then
        '        txtOnValue2.Text = Format(Val(txtNet.Text) - Val(Val(Val(txtDisAmt.Text) + Val(txtDisAmt1.Text))), Hash)
        '    ElseIf clsFun.ExecScalarStr("Select ApplyOn2 From DiscountSetting") = "Basic Value" Then
        '        txtOnValue2.Text = Format(Val(txtNet.Text), Hash)
        '    End If
        '    pnlDisc.Size = New Size(688, 107)
        '    pnlDisc.Visible = True : pnlDisc.BringToFront()
        'Else
        '    lblDisHead2.Text = "" : txtOnValue2.Text = "" : txtCalPer2.Text = "" : txtDisAmt2.Text = ""
        '    lblDisHead2.Visible = False : txtOnValue2.Visible = False : txtCalPer2.Visible = False : txtDisAmt2.Visible = False
        'End If
        'If clsFun.ExecScalarStr("Select Enable3 From DiscountSetting") = "Y" Then
        '    txtOnValue3.Visible = True : txtCalPer3.Visible = True : txtDisAmt3.Visible = True
        '    lblDisHead3.Text = clsFun.ExecScalarStr("Select DiscountHead3 From DiscountSetting")
        '    If dg1.SelectedRows.Count = 0 Then txtCalPer3.Text = clsFun.ExecScalarStr("Select Calculate3 From DiscountSetting")
        '    lblPlusMins3.Text = clsFun.ExecScalarStr("Select Addless3 From DiscountSetting")
        '    If clsFun.ExecScalarStr("Select ApplyOn3 From DiscountSetting") = "Balance Value" Then
        '        txtOnValue3.Text = Format(Val(txtNet.Text) - Val(txtDisAmt.Text), Hash)
        '    ElseIf clsFun.ExecScalarStr("Select ApplyOn3 From DiscountSetting") = "Basic Value" Then
        '        txtOnValue3.Text = Format(Val(txtNet.Text), Hash)
        '    End If
        '    pnlDisc.Size = New Size(688, 134)
        '    pnlDisc.Visible = True : pnlDisc.BringToFront()
        'Else
        '    lblDisHead3.Text = "" : txtOnValue3.Text = "" : txtCalPer3.Text = "" : txtDisAmt3.Text = ""
        '    lblDisHead3.Visible = False : txtOnValue3.Visible = False : txtCalPer3.Visible = False : txtDisAmt3.Visible = False
        'End If
        'If clsFun.ExecScalarStr("Select Enable4 From DiscountSetting") = "Y" Then
        '    txtOnValue4.Visible = True : txtCalPer4.Visible = True : txtDisAmt4.Visible = True
        '    lblDisHead4.Text = clsFun.ExecScalarStr("Select DiscountHead4 From DiscountSetting")
        '    If dg1.SelectedRows.Count = 0 Then txtCalPer4.Text = clsFun.ExecScalarStr("Select Calculate4 From DiscountSetting")
        '    lblPlusMins4.Text = clsFun.ExecScalarStr("Select Addless4 From DiscountSetting")
        '    If clsFun.ExecScalarStr("Select ApplyOn4 From DiscountSetting") = "Balance Value" Then
        '        txtOnValue4.Text = Format(Val(txtNet.Text) - Val(txtDisAmt.Text), Hash)
        '    ElseIf clsFun.ExecScalarStr("Select ApplyOn4 From DiscountSetting") = "Basic Value" Then
        '        txtOnValue4.Text = Format(Val(txtNet.Text), Hash)
        '    End If
        '    pnlDisc.Size = New Size(688, 195)
        '    pnlDisc.Visible = True : pnlDisc.BringToFront()
        'Else
        '    lblDisHead4.Text = "" : txtOnValue4.Text = "" : txtCalPer4.Text = "" : txtDisAmt4.Text = ""
        '    lblDisHead4.Visible = False : txtOnValue4.Visible = False : txtCalPer4.Visible = False : txtDisAmt4.Visible = False
        'End If
    End Sub

    Private Sub DiscountCalculation()
        txtDisAmt1.Text = Format(Val(txtOnValue1.Text) * Val(txtCalPer1.Text) / 100, Hash)
        If clsFun.ExecScalarStr("Select ApplyOn2 From DiscountSetting") = "Balance Value" Then
            txtOnValue2.Text = Format(Val(txtNet.Text) - Val(Val(Val(txtDisAmt.Text) + Val(txtDisAmt1.Text))), Hash)
        End If
        txtDisAmt2.Text = Format(Math.Round(Val(txtOnValue2.Text) * Val(txtCalPer2.Text) / 100, 2), Hash)
        txtDisAmt3.Text = Format(Math.Round(Val(txtOnValue3.Text) * Val(txtCalPer3.Text) / 100, 2), Hash)
        txtDisAmt4.Text = Format(Math.Round(Val(txtOnValue4.Text) * Val(txtCalPer4.Text) / 100, 2), Hash)
        lblDiscamt.Text = Format(Val(txtDisAmt1.Text) + Val(txtDisAmt2.Text) + Val(txtDisAmt3.Text) + Val(txtDisAmt4.Text), Hash)

        'Dim theNumber As Double : theNumber = txtTaxAmt.Text
        'Dim taxamt = Math.Floor(Math.Abs(theNumber) * 100) / 100.0
        'txtTaxAmt.Text = Format(taxamt, Hash)
        If lblTaxType.Text = "TI" Or lblTaxType.Text = "TE" Then
            If lblRegion.Text = "Local" Then
                SGSTAMT = Format(Val(Val(txtTaxPer.Text / 2) * Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)) / 100), Hash)
                CGSTAMT = Format(Val(Val(txtTaxPer.Text / 2) * Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)) / 100), Hash)
                IGSTAMT = 0
                txtTaxAmt.Text = Format(Val(Format(IGSTAMT, Hash)) + Val(Format(SGSTAMT, Hash)) + Val(Format(CGSTAMT, Hash)), Hash)
                If CessAsOn = "Taxable" Then
                    CessAmt = Format(Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)) * Val(CessPer) / 100, Hash)
                    txtTaxAmt.Text = Format(Val(txtTaxAmt.Text) + Val(CessAmt), Hash)
                ElseIf CessAsOn = "Qty" Then
                    CessAmt = CessAmt + Val(Val(txtQty.Text) * Val(SpeCess))
                    txtTaxAmt.Text = Format(Val(txtTaxAmt.Text) + Val(CessAmt), Hash)
                ElseIf CessAsOn = "Taxable+Qty" Then
                    CessAmt = Format(Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)) * Val(CessPer) / 100, Hash)
                    CessAmt = CessAmt + Val(Val(txtQty.Text) * Val(SpeCess))
                    txtTaxAmt.Text = Format(Val(txtTaxAmt.Text) + Val(CessAmt), Hash)
                End If
            Else
                SGSTAMT = 0
                CGSTAMT = 0
                IGSTAMT = Format(Val(Val(txtTaxPer.Text) * Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)) / 100), Hash)
                txtTaxAmt.Text = Format(Val(Format(IGSTAMT, Hash)) + Val(Format(SGSTAMT, Hash)) + Val(Format(CGSTAMT, Hash)), Hash)
                If CessAsOn = "Taxable" Then
                    CessAmt = Format(Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)) * Val(CessPer) / 100, Hash)
                    txtTaxAmt.Text = Format(Val(txtTaxAmt.Text) + Val(CessAmt), Hash)
                ElseIf CessAsOn = "Qty" Then
                    CessAmt = CessAmt + Val(Val(txtQty.Text) * Val(SpeCess))
                    txtTaxAmt.Text = Format(Val(txtTaxAmt.Text) + Val(CessAmt), Hash)
                ElseIf CessAsOn = "Taxable+Qty" Then
                    CessAmt = Format(Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)) * Val(CessPer) / 100, Hash)
                    CessAmt = CessAmt + Val(Val(txtQty.Text) * Val(SpeCess))
                    txtTaxAmt.Text = Format(Val(txtTaxAmt.Text) + Val(CessAmt), Hash)
                End If
            End If

        End If
        '  txtTotAmt.Text = Format(Math.Round(Val(Val(txtTaxAmt.Text) + Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text))), 2), Hash)
        txtTotAmt.Text = Format(Val(Format(IGSTAMT, Hash)) + Val(Format(SGSTAMT, Hash)) + Val(Format(CGSTAMT, Hash)) + Val(Format(CessAmt, Hash)) + Val(Val(Val(txtNet.Text) - Val(txtDisAmt.Text)) - Val(lblDiscamt.Text)), Hash)
        'Dim TotalAmount As Double : TotalAmount = txtTotAmt.Text
        'Dim Total = Math.Floor(Math.Abs(TotalAmount) * 100) / 100.0
        'txtTotAmt.Text = Format(Total, Hash)
        lblTaxableamt.Text = "Taxable Value : " & Format(Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)), Hash)
    End Sub

    Private Sub txtTaxPer_GotFocus(sender As Object, e As EventArgs) Handles txtTaxPer.GotFocus
        pnlDisc.Visible = False
    End Sub
    Private Sub TxtTPID_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtTPID.KeyDown
        If e.KeyCode = Keys.Enter Then BtnSave.Focus()
    End Sub

    Private Sub txtAccount_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAccount.KeyDown, mskEntryDate.KeyDown,
        txtVoucherNo.KeyDown, cbSeries.KeyDown, txtItem.KeyDown, cbbatch.KeyDown, txtAltQty.KeyDown, txtFreeQty.KeyDown,
        txtQty.KeyDown, txtRate.KeyDown, txtNet.KeyDown, txtDisPer.KeyDown, txtDisAmt.KeyDown, txtTaxPer.KeyDown, txtTaxAmt.KeyDown,
         txtCustomerName.KeyDown, txtFullAddress.KeyDown, txtMobileNo.KeyDown, cbState.KeyDown, txtGSTN.KeyDown, cbPricePer.KeyDown,
        txtOnValue1.KeyDown, txtCalPer1.KeyDown, txtDisAmt1.KeyDown, txtOnValue2.KeyDown, txtCalPer2.KeyDown, txtDisAmt2.KeyDown,
        txtOnValue3.KeyDown, txtCalPer3.KeyDown, txtDisAmt3.KeyDown, txtOnValue4.KeyDown, txtCalPer4.KeyDown, txtDisAmt4.KeyDown,
        txtEwayBillNo.KeyDown, mskEwayDate.KeyDown, cbSubType.KeyDown, cbDocumentType.KeyDown, cbTranport.KeyDown, txtFromPin.KeyDown,
        txtToPin.KeyDown, txtDistance.KeyDown, txtVehicleNo.KeyDown, txtTransPorterName.KeyDown, txtLrNo.KeyDown, cbGSTtype.KeyDown,
        txtEwayBillDated.KeyDown
        'If e.KeyCode = Keys.F10 Then
        '    If Val(txtAccountID.Text) = Val(7) Then
        '        pnlCustomerInfo.Visible = True
        '        pnlCustomerInfo.BringToFront()
        '        If cbState.Text = "-N.A." Or cbState.Text = "" Then
        '            ClsFunPrimary.FillDropDownList(cbState, "Select ID,StateName From StateList", "StateName", "Id", "")
        '            cbState.Text = ClsFunPrimary.ExecScalarStr("Select State From Company")
        '            txtStateCode.Text = Format(ClsFunPrimary.ExecScalarStr("Select StateCode From Company"), "00")
        '            txtCustomerName.Focus()
        '        Else
        '            txtCustomerName.Focus()
        '        End If
        '    End If
        'End If
        If txtVoucherNo.Focused Then
            If e.KeyCode = Keys.F2 Then
                pnlInvoiceID.BringToFront()
                pnlInvoiceID.Visible = True
                txtInvoiceID.Focus()
            End If
        End If
        If cbSeries.Focused Then
            If Val(txtAccountID.Text) = Val(7) Then
                If e.KeyCode = Keys.Enter Then
                    pnlCustomerInfo.Visible = True
                    pnlCustomerInfo.BringToFront()
                    If cbState.Text = "-N.A." Or cbState.Text = "" Then
                        clsFun.FillDropDownList(cbState, "Select ID,StateName From StateList", "StateName", "Id", "")
                        cbState.Text = clsFun.ExecScalarStr("Select State From Company")
                        txtStateCode.Text = Format(Val(clsFun.ExecScalarStr("Select StateCode From Company")), "00")
                        txtCustomerName.Focus()
                        ' cbGSTtype.SelectedIndex = 0
                        Exit Sub
                    Else
                        cbState.Text = clsFun.ExecScalarStr("Select State From Company")
                        txtStateCode.Text = Format(Val(clsFun.ExecScalarStr("Select StateCode From Company")), "00")
                        txtCustomerName.Focus() : Exit Sub

                    End If
                End If
            End If
        End If

        If cbGSTtype.Focused Then
            If e.KeyCode = Keys.Enter Then
                If cbGSTtype.SelectedIndex = 0 Or cbGSTtype.SelectedIndex = 1 Or cbGSTtype.SelectedIndex = 3 Then
                    txtGSTN.Enabled = True
                    SendKeys.Send("{TAB}")
                    e.SuppressKeyPress = True
                    Exit Sub
                Else
                    txtGSTN.Text = ""
                    txtGSTN.Enabled = False
                    pnlCustomerInfo.Visible = False
                    txtItem.Focus()
                    Exit Sub
                End If
            End If
        End If

        If txtQty.Focused Then
            If e.KeyCode = Keys.F2 Then
                pnlaltinfo.Visible = True
                pnlaltinfo.BringToFront()
                txtAltQty.Focus()
            End If
            If e.KeyCode = Keys.F3 Then
                pnlaltinfo.Visible = True
                txtFreeQty.Focus()
            End If
            If e.KeyCode = Keys.Enter Then
                If lblAltYN.Text = "Y" Then
                    pnlaltinfo.Visible = True
                    pnlaltinfo.BringToFront()
                    txtAltQty.Focus() : Exit Sub
                End If
            End If
        End If
        If cbSeries.Focused Then
            If e.KeyCode = Keys.F3 Then
                If clsFun.ExecScalarStr("Select BusinessType From Company") = "Pharma (Whole Sale & Retailer)" Then
                    Tax_Setting.MdiParent = PharmaMainScreenForm
                    Tax_Setting.Show()
                Else
                    Tax_Setting.MdiParent = MainScreenForm
                    Tax_Setting.Show()
                End If

            End If
            If e.KeyCode = Keys.F1 Then
                Tax_Setting.MdiParent = MainScreenForm
                Tax_Setting.Show()
                Tax_Setting.FillControls(Val(cbSeries.SelectedValue))
            End If
        End If

        If e.KeyCode = Keys.Delete Then
            dgItemSearch.Visible = False
            If dg1.SelectedRows.Count = 0 Then Exit Sub
            If MessageBox.Show("Are you Sure to Remove Item : " & dg1.SelectedRows(0).Cells(1).Value & " " & vbNewLine & " Qty. : " & dg1.SelectedRows(0).Cells(9).Value & "", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) = Windows.Forms.DialogResult.Yes Then
                dg1.Rows.Remove(dg1.SelectedRows(0))
                txtClear()
                'ClearDetails()
            End If
        End If
        If txtGSTN.Focused Then
            If e.KeyCode = Keys.Enter Then
                cbSeries.Focus()
                pnlCustomerInfo.Visible = False
            End If
        End If

        If e.KeyCode = Keys.PageDown Then
            txtCharges.Focus()
        End If
        If txtAccount.Focused Then
            If e.KeyCode = Keys.F3 Then
                If clsFun.ExecScalarStr("Select BusinessType From Company") = "Pharma (Whole Sale & Retailer)" Then
                    CreateAccount.MdiParent = PharmaMainScreenForm
                    clsFun.FillDropDownList(CreateAccount.cbGroup, "Select ID,GroupName FROM AccountGroup Where ID=32 ", "GroupName", "ID", "")
                    CreateAccount.Show()
                Else
                    CreateAccount.MdiParent = MainScreenForm
                    clsFun.FillDropDownList(CreateAccount.cbGroup, "Select ID,GroupName FROM AccountGroup Where ID=32 ", "GroupName", "ID", "")
                    CreateAccount.Show()
                End If

            End If
            If e.KeyCode = Keys.F1 Then
                If DgAccountSearch.SelectedRows.Count = 0 Then Exit Sub
                If clsFun.ExecScalarStr("Select BusinessType From Company") = "Pharma (Whole Sale & Retailer)" Then
                    CreateAccount.MdiParent = PharmaMainScreenForm
                    CreateAccount.Show()
                    CreateAccount.FillContros(Val(DgAccountSearch.SelectedRows(0).Cells(0).Value))
                Else
                    CreateAccount.MdiParent = MainScreenForm
                    CreateAccount.Show()
                    CreateAccount.FillContros(Val(DgAccountSearch.SelectedRows(0).Cells(0).Value))
                End If

            End If
            If e.KeyCode = Keys.Down Then DgAccountSearch.Focus()
        End If

        If txtItem.Focused Then
            If e.KeyCode = Keys.F3 Then
                Items.MdiParent = MainScreenForm
                Items.Show()
            End If
            If e.KeyCode = Keys.F1 Then
                If dgItemSearch.SelectedRows.Count = 0 Then Exit Sub
                Items.MdiParent = MainScreenForm
                Items.Show()
                Items.FillControls(Val(dgItemSearch.SelectedRows(0).Cells(0).Value))
            End If
            If e.KeyCode = Keys.Down Then dgItemSearch.Focus()
        End If
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
        Select Case e.KeyCode
            Case Keys.End
                e.Handled = True
                txtCdPer.Focus()
        End Select
    End Sub

    Private Sub txtAccount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAccount.KeyPress
        DgAccountSearch.BringToFront() : DgAccountSearch.Visible = True
    End Sub
    Private Sub txtAccount_KeyUp(sender As Object, e As KeyEventArgs) Handles txtAccount.KeyUp

        If txtAccount.Text.Trim() <> "" Then
            retriveAccounts(" And upper(accountname) Like upper('" & txtAccount.Text.Trim() & "%')")
        Else
            retriveAccounts()
        End If
    End Sub
    Private Sub DgAccountSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles DgAccountSearch.KeyDown
        If e.KeyCode = Keys.PageUp Then
            If DgAccountSearch.CurrentRow.Index = 0 Then txtAccount.Focus()
        End If
        If e.KeyCode = Keys.F3 Then
            CreateAccount.MdiParent = MainScreenForm
            CreateAccount.Show()
            clsFun.FillDropDownList(CreateAccount.cbGroup, "Select ID,GroupName FROM AccountGroup Where ID=32 ", "GroupName", "ID", "")
            If Not CreateAccount Is Nothing Then
                CreateAccount.BringToFront()
            End If
        End If
        If e.KeyCode = Keys.F1 Then
            Dim AccountID As String = DgAccountSearch.SelectedRows(0).Cells(0).Value
            CreateAccount.MdiParent = MainScreenForm
            CreateAccount.Show()
            CreateAccount.FillContros(AccountID)
            If Not CreateAccount Is Nothing Then
                CreateAccount.BringToFront()
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            txtAccount.Clear() : txtAccountID.Clear()
            txtAccountID.Text = Val(DgAccountSearch.SelectedRows(0).Cells(0).Value)
            txtAccount.Text = DgAccountSearch.SelectedRows(0).Cells(1).Value
            cbSeries.Focus()
            e.SuppressKeyPress = True
        End If
        If e.KeyCode = Keys.Back Then txtAccount.Focus()
        If e.KeyCode = Keys.Up Then
            If DgAccountSearch.CurrentRow.Index = 0 Then txtAccount.Focus()
        End If
    End Sub

    Private Sub DgAccountSearch_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgAccountSearch.CellClick
        txtAccount.Clear() : txtAccountID.Clear()
        txtAccountID.Text = Val(DgAccountSearch.SelectedRows(0).Cells(0).Value)
        txtAccount.Text = DgAccountSearch.SelectedRows(0).Cells(1).Value
        cbSeries.Focus()
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub Calculation()
        CessAmt = Hash
        lblTaxableamt.Visible = True
        If Val(txtItemID.Text) = 0 Then Exit Sub
        ' Dim conversion As Decimal = clsFun.ExecScalarStr("Select Conversion From Items Where ID='" & Val(txtItemID.Text) & "'")
        'If Val(conversion) > 0 Then
        '    txtAltQty.Text = Val(txtQty.Text) * Val(conversion)
        'Else
        '    txtAltQty.Text = Val(txtQty.Text)
        'End If
        txtAltQty.Text = Val(txtQty.Text)
        If lblTaxType.Text = "TI" Then
            Dim incRate As Decimal = Val(txtRate.Text) - Val(SpeCess)
            incRate = Val(incRate) * (100 / Val(Val(Val(txtTaxPer.Text) + Val(CessPer)) + 100))
            txtNetRate.Text = Format(Val(incRate), Hash)
            If cbPricePer.SelectedIndex = 1 Then
                txtNet.Text = Format(Val(txtAltQty.Text) * Val(txtNetRate.Text), Hash)
            Else
                txtNet.Text = Format(Val(txtQty.Text) * Val(txtNetRate.Text), Hash)
            End If
            txtDisAmt.Text = Format(Val(Val(txtNet.Text) * Val(txtDisPer.Text)) / 100, Hash)
            lblTaxableamt.Text = "Taxable Value : " & Format(Math.Round(Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)), 2), Hash)
            If lblRegion.Text = "Local" Then
                SGSTPER = Val(Val(txtTaxPer.Text) / 2)
                CGSTPER = Val(Val(txtTaxPer.Text) / 2)
                IGSTPER = Val(Val(0))
                SGSTAMT = Val(Val(Val(txtTaxPer.Text) / 2) * Format(Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)), Hash) / 100)
                CGSTAMT = Val(Val(Val(txtTaxPer.Text) / 2) * Format(Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)), Hash) / 100)
                txtTaxAmt.Text = Format(Val(SGSTAMT) + Format(Val(CGSTAMT)), Hash)
            Else
                SGSTPER = Val(0) : CGSTPER = Val(0)
                IGSTPER = Val(Val(txtTaxPer.Text))
                IGSTAMT = Val(Val(Val(txtTaxPer.Text)) * Format(Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)), Hash) / 100)
                txtTaxAmt.Text = Format(IGSTAMT, Hash)
            End If

            If CessAsOn = "Taxable" Then
                CessAmt = Format(Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)) * Val(CessPer) / 100, Hash)
                txtTaxAmt.Text = Format(Val(txtTaxAmt.Text) + Val(CessAmt), Hash)
            ElseIf CessAsOn = "Qty" Then
                CessAmt = CessAmt + Val(Val(txtQty.Text) * Val(SpeCess))
                txtTaxAmt.Text = Format(Val(txtTaxAmt.Text) + Val(CessAmt), Hash)
            ElseIf CessAsOn = "Taxable+Qty" Then
                CessAmt = Format(Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)) * Val(CessPer) / 100, Hash)
                CessAmt = CessAmt + Val(Val(txtQty.Text) * Val(SpeCess))
                txtTaxAmt.Text = Format(Val(txtTaxAmt.Text) + Val(CessAmt), Hash)
            End If
            txtTotAmt.Text = Format(Val(Format(IGSTAMT, Hash)) + Val(Format(SGSTAMT, Hash)) + Val(Format(CGSTAMT, Hash)) + Val(Format(CessAmt, Hash)) + Val(Val(Val(txtNet.Text) - Val(txtDisAmt.Text)) - Val(lblDiscamt.Text)), Hash)
        ElseIf lblTaxType.Text = "TE" Then
            txtNetRate.Text = Val(txtRate.Text)
            If cbPricePer.SelectedIndex = 1 Then
                txtNet.Text = Format(Val(txtAltQty.Text) * Val(txtNetRate.Text), Hash)
            Else
                txtNet.Text = Format(Val(txtQty.Text) * Val(txtNetRate.Text), Hash)
            End If
            txtDisAmt.Text = Format(Val(Val(txtNet.Text) * Val(txtDisPer.Text)) / 100, Hash)
            '  Dim disc2 As Decimal = Format(Val(Val(txtNet.Text) * Val(txtDisPer.Text)) / 100, Hash)
            lblTaxableamt.Text = "Taxable Value : " & Format(Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)), Hash)
            If lblRegion.Text = "Local" Then
                SGSTPER = Val(Val(txtTaxPer.Text) / 2)
                CGSTPER = Val(Val(txtTaxPer.Text) / 2)
                IGSTPER = Val(Val(0))
                SGSTAMT = Val(Val(Val(txtTaxPer.Text) / 2) * Format(Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)), Hash) / 100)
                CGSTAMT = Val(Val(Val(txtTaxPer.Text) / 2) * Format(Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)), Hash) / 100)
                txtTaxAmt.Text = Format(Val(SGSTAMT) + Format(Val(CGSTAMT)), Hash)
            Else
                SGSTPER = Val(0)
                CGSTPER = Val(0)
                IGSTPER = Val(Val(txtTaxPer.Text))
                IGSTAMT = Val(Val(Val(txtTaxPer.Text)) * Format(Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)), Hash) / 100)
                txtTaxAmt.Text = Format(IGSTAMT, Hash)
            End If
            txtTotAmt.Text = Format(Val(Format(IGSTAMT, Hash)) + Val(Format(SGSTAMT, Hash)) + Val(Format(CGSTAMT, Hash)) + Val(Format(CessAmt, Hash)) + Val(Val(Val(txtNet.Text) - Val(txtDisAmt.Text)) - Val(lblDiscamt.Text)), Hash)
            If CessAsOn = "Taxable" Then
                CessAmt = Format(Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)) * Val(CessPer) / 100, Hash)
                txtTaxAmt.Text = Format(Val(txtTaxAmt.Text) + Val(CessAmt), Hash)
            ElseIf CessAsOn = "Qty" Then
                CessAmt = CessAmt + Val(Val(txtQty.Text) * Val(SpeCess))
                txtTaxAmt.Text = Format(Val(txtTaxAmt.Text) + Val(CessAmt), Hash)
            ElseIf CessAsOn = "Taxable+Qty" Then
                CessAmt = Format(Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)) * Val(CessPer) / 100, Hash)
                CessAmt = CessAmt + Val(Val(txtQty.Text) * Val(SpeCess))
                txtTaxAmt.Text = Format(Val(txtTaxAmt.Text) + Val(CessAmt), Hash)
            End If
        Else
            txtNetRate.Text = Val(txtRate.Text)
            If cbPricePer.SelectedIndex = 1 Then
                txtNet.Text = Format(Val(txtAltQty.Text) * Val(txtNetRate.Text), Hash)
            Else
                txtNet.Text = Format(Val(txtQty.Text) * Val(txtNetRate.Text), Hash)
            End If
            txtDisAmt.Text = Format(Val(Val(txtNet.Text) * Val(txtDisPer.Text)) / 100, Hash)
            lblTaxableamt.Text = "Taxable Value : " & Format(Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)), Hash)
            '  txtTaxAmt.Text = Format(Val(Val(txtTaxPer.Text) * Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)) / 100), Hash)
            txtTotAmt.Text = Format(Val(txtTaxAmt.Text) + Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)), Hash)
        End If
    End Sub
    Private Sub Calculation2()
        CessAmt = Hash
        lblTaxableamt.Visible = True
        If Val(txtItemID.Text) = 0 Then Exit Sub
        'Dim conversion As Decimal = clsFun.ExecScalarStr("Select Conversion From Items Where ID='" & Val(txtItemID.Text) & "'")
        'If Val(conversion) > 0 Then
        '    txtAltQty.Text = Val(txtQty.Text) * Val(conversion)
        'Else
        '    txtAltQty.Text = Val(txtQty.Text)
        'End If
        txtAltQty.Text = Val(txtQty.Text)
        If lblTaxType.Text = "TI" Then
            Dim incRate As Decimal = Val(txtRate.Text) - Val(SpeCess)
            incRate = Val(incRate) * (100 / Val(Val(Val(txtTaxPer.Text) + Val(CessPer)) + 100))
            txtNetRate.Text = Format(Val(incRate), Hash)
            If cbPricePer.SelectedIndex = 1 Then
                txtNet.Text = Format(Val(txtAltQty.Text) * Val(txtNetRate.Text), Hash)
            Else
                txtNet.Text = Format(Val(txtQty.Text) * Val(txtNetRate.Text), Hash)
            End If
            txtDisAmt.Text = Format(Val(Val(txtNet.Text) * Val(txtDisPer.Text)) / 100, Hash)
            lblTaxableamt.Text = "Taxable Value : " & Format(Math.Round(Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)), 2), Hash)
            If lblRegion.Text = "Local" Then
                SGSTPER = Val(Val(txtTaxPer.Text) / 2)
                CGSTPER = Val(Val(txtTaxPer.Text) / 2)
                IGSTPER = Val(Val(0))
                SGSTAMT = Val(Val(Val(txtTaxPer.Text) / 2) * Format(Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)), Hash) / 100)
                CGSTAMT = Val(Val(Val(txtTaxPer.Text) / 2) * Format(Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)), Hash) / 100)
                txtTaxAmt.Text = Format(Val(0), Hash)
            Else
                SGSTPER = Val(0) : CGSTPER = Val(0)
                IGSTPER = Val(Val(txtTaxPer.Text))
                IGSTAMT = Val(Val(Val(txtTaxPer.Text)) * Format(Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)), Hash) / 100)
                txtTaxAmt.Text = Format(0, Hash)
            End If

            If CessAsOn = "Taxable" Then
                CessAmt = Format(Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)) * Val(CessPer) / 100, Hash)
                txtTaxAmt.Text = Format(Val(txtTaxAmt.Text) + Val(CessAmt), Hash)
            ElseIf CessAsOn = "Qty" Then
                CessAmt = CessAmt + Val(Val(txtQty.Text) * Val(SpeCess))
                txtTaxAmt.Text = Format(Val(0), Hash)
            ElseIf CessAsOn = "Taxable+Qty" Then
                CessAmt = Format(Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)) * Val(CessPer) / 100, Hash)
                CessAmt = CessAmt + Val(Val(txtQty.Text) * Val(SpeCess))
                txtTaxAmt.Text = Format(Val(0), Hash)
            End If
            txtTotAmt.Text = Format(Val(txtTaxAmt.Text) + Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)), Hash)
        ElseIf lblTaxType.Text = "TE" Then
            txtNetRate.Text = Val(txtRate.Text)
            If cbPricePer.SelectedIndex = 1 Then
                txtNet.Text = Format(Val(txtAltQty.Text) * Val(txtNetRate.Text), Hash)
            Else
                txtNet.Text = Format(Val(txtQty.Text) * Val(txtNetRate.Text), Hash)
            End If
            txtDisAmt.Text = Format(Val(Val(txtNet.Text) * Val(txtDisPer.Text)) / 100, Hash)
            '  Dim disc2 As Decimal = Format(Val(Val(txtNet.Text) * Val(txtDisPer.Text)) / 100, Hash)
            lblTaxableamt.Text = "Taxable Value : " & Format(Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)), Hash)
            If lblRegion.Text = "Local" Then
                SGSTPER = Val(Val(txtTaxPer.Text) / 2)
                CGSTPER = Val(Val(txtTaxPer.Text) / 2)
                IGSTPER = Val(Val(0))
                SGSTAMT = Val(Val(Val(txtTaxPer.Text) / 2) * Format(Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)), Hash) / 100)
                CGSTAMT = Val(Val(Val(txtTaxPer.Text) / 2) * Format(Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)), Hash) / 100)
                txtTaxAmt.Text = Format(Val(0), Hash)
            Else
                SGSTPER = Val(0)
                CGSTPER = Val(0)
                IGSTPER = Val(Val(txtTaxPer.Text))
                IGSTAMT = Val(Val(Val(txtTaxPer.Text)) * Format(Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)), Hash) / 100)
                txtTaxAmt.Text = Format(Val(0), Hash)
            End If
            txtTaxAmt.Text = Format(Val(0), Hash)
            If CessAsOn = "Taxable" Then
                CessAmt = Format(Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)) * Val(CessPer) / 100, Hash)
                txtTaxAmt.Text = Format(Val(0), Hash)
            ElseIf CessAsOn = "Qty" Then
                CessAmt = CessAmt + Val(Val(txtQty.Text) * Val(SpeCess))
                txtTaxAmt.Text = Format(Val(0), Hash)
            ElseIf CessAsOn = "Taxable+Qty" Then
                CessAmt = Format(Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)) * Val(CessPer) / 100, Hash)
                CessAmt = CessAmt + Val(Val(txtQty.Text) * Val(SpeCess))
                txtTaxAmt.Text = Format(Val(0), Hash)
            End If
            txtTotAmt.Text = Format(Val(txtTaxAmt.Text) + Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)), Hash)
        Else
            txtNetRate.Text = Val(txtRate.Text)
            If cbPricePer.SelectedIndex = 1 Then
                txtNet.Text = Format(Val(txtAltQty.Text) * Val(txtNetRate.Text), Hash)
            Else
                txtNet.Text = Format(Val(txtQty.Text) * Val(txtNetRate.Text), Hash)
            End If
            txtDisAmt.Text = Format(Val(Val(txtNet.Text) * Val(txtDisPer.Text)) / 100, Hash)
            lblTaxableamt.Text = "Taxable Value : " & Format(Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)), Hash)
            '  txtTaxAmt.Text = Format(Val(Val(txtTaxPer.Text) * Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)) / 100), Hash)
            txtTotAmt.Text = Format(Val(txtTaxAmt.Text) + Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)), Hash)
        End If
    End Sub
    'Private Sub Calculation()
    '    lblTaxableamt.Visible = True
    '    If Val(txtItemID.Text) = 0 Then Exit Sub
    '    Dim conversion As Decimal = clsFun.ExecScalarStr("Select Conversion From Items Where ID='" & Val(txtItemID.Text) & "'")
    '    If Val(conversion) > 0 Then
    '        txtAltQty.Text = Val(txtQty.Text) * Val(conversion)
    '    Else
    '        txtAltQty.Text = Val(txtQty.Text)
    '    End If
    '    If lblTaxType.Text = "TI" Then
    '        Dim incRate As Decimal = Val(txtRate.Text) * (100 / Val(Val(txtTaxPer.Text) + 100))
    '        txtNetRate.Text = Format(Val(incRate), "0.000")
    '        If cbPricePer.SelectedIndex = 1 Then
    '            txtNet.Text = Format(Val(txtAltQty.Text) * Val(txtNetRate.Text), Hash)
    '        Else
    '            txtNet.Text = Format(Val(txtQty.Text) * Val(txtNetRate.Text), Hash)
    '        End If
    '        txtDisAmt.Text = Format(Val(Val(txtNet.Text) * Val(txtDisPer.Text)) / 100, "0.000")
    '        lblTaxableamt.Text = "Taxable Value : " & Format(Math.Round(Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)), 2), Hash)
    '        txtTaxAmt.Text = Format(Math.Round(Val(Val(txtTaxPer.Text) * Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)) / 100), 2), Hash)
    '        If Val(txtTaxAmt.Text) Mod 2 <> 0 Then
    '            txtTotTaxAmt.Text = Format(Val(txtTaxAmt.Text) - 0.01, Hash)
    '        End If
    '        txtTotAmt.Text = Format(Math.Round(Val(Val(txtTaxAmt.Text) + Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text))), 2), Hash)
    '        'Dim TotalAmount As Double : TotalAmount = txtTotAmt.Text
    '        'Dim Total = Math.Floor(Math.Abs(TotalAmount) * 100) / 100.0
    '        'txtTotAmt.Text = Format(Total, Hash)
    '    ElseIf lblTaxType.Text = "TE" Then
    '        txtNetRate.Text = Val(txtRate.Text)
    '        If cbPricePer.SelectedIndex = 1 Then
    '            txtNet.Text = Format(Val(txtAltQty.Text) * Val(txtNetRate.Text), Hash)
    '        Else
    '            txtNet.Text = Format(Val(txtQty.Text) * Val(txtNetRate.Text), Hash)
    '        End If
    '        txtDisAmt.Text = Format(Val(Val(txtNet.Text) * Val(txtDisPer.Text)) / 100, Hash)
    '        lblTaxableamt.Text = "Taxable Value : " & Format(Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)), Hash)
    '        txtTaxAmt.Text = Format(Val(Val(txtTaxPer.Text) * Format(Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)), Hash) / 100), Hash)
    '        If Val(txtTaxAmt.Text) Mod 2 <> 0 Then
    '            txtTotTaxAmt.Text = Format(Val(txtTaxAmt.Text) - 0.01, Hash)
    '        End If
    '        txtTotAmt.Text = Format(Val(txtTaxAmt.Text) + Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)), Hash)
    '    Else
    '        txtNetRate.Text = Val(txtRate.Text)
    '        If cbPricePer.SelectedIndex = 1 Then
    '            txtNet.Text = Format(Val(txtAltQty.Text) * Val(txtNetRate.Text), Hash)
    '        Else
    '            txtNet.Text = Format(Val(txtQty.Text) * Val(txtNetRate.Text), Hash)
    '        End If
    '        txtDisAmt.Text = Format(Val(Val(txtNet.Text) * Val(txtDisPer.Text)) / 100, Hash)
    '        lblTaxableamt.Text = "Taxable Value : " & Format(Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)), Hash)
    '        '  txtTaxAmt.Text = Format(Val(Val(txtTaxPer.Text) * Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)) / 100), Hash)
    '        txtTotAmt.Text = Format(Val(txtTaxAmt.Text) + Val(Val(txtNet.Text) - Val(txtDisAmt.Text) - Val(lblDiscamt.Text)), Hash)
    '    End If
    'End Sub

    Private Sub txtQty_Leave(sender As Object, e As EventArgs) Handles txtQty.Leave
        'lblAltYN.Text = "Y" Then pnlaltinfo.Visible = True : pnlaltinfo.BringToFront() : txtAltQty.Focus() Else pnlaltinfo.Visible = False : If lblSerial.Text = "Y" Then pnladditional.BringToFront() : pnlaltinfo.BringToFront()
        'lblSerial.Text = clsFun.ExecScalarStr("Select MaintainSR From Items Where ID='" & Val(txtItemID.Text) & "'")
        'If lblSerial.Text = "Y" And lblAltYN.Text = "Y" Then pnlaltinfo.Visible = True : pnlaltinfo.BringToFront() : txtAltQty.Focus()
        'If lblSerial.Text = "Y" And lblAltYN.Text = "N" Then serialSetting() : txtSr1.Focus() : pnlSerial.BringToFront()
    End Sub

    Private Sub serialSetting()
        lblSerial.Text = clsFun.ExecScalarStr("Select MaintainSR From Items Where ID='" & Val(txtItemID.Text) & "'")
        If lblSerial.Text = "Y" Then
            If clsFun.ExecScalarStr("Select Count(*) From SerialSetting ") = 0 Then pnlSerial.Visible = False : Exit Sub
            If clsFun.ExecScalarInt("Select Nos From SerialSetting") = 0 Then pnlSerial.Visible = False : Exit Sub
            pnlSerial.Visible = True : pnlSerial.BringToFront()
            Dim serialID As Integer = Val(dg1.Rows.Count + 1)
            txtSerialID.Text = Val(txtAltQty.Text)
            If Val(clsFun.ExecScalarStr("Select Nos From SerialSetting ")) = 1 Then
                lblTitle1.Visible = True : txtSr1.Visible = True
                lbltitle2.Visible = False : txtSr2.Visible = False
                lbltitle3.Visible = False : txtSr3.Visible = False
                lbltitle4.Visible = False : txtsr4.Visible = False
                lbltitle5.Visible = False : txtsr5.Visible = False
                lblTitle1.Text = clsFun.ExecScalarStr("Select SNo1 From SerialSetting ")
                pnlSerial.Size = New Size(160, 199)
                dgSerial.Size = New Size(140, 117)
            ElseIf Val(clsFun.ExecScalarStr("Select Nos From SerialSetting ")) = 2 Then
                lblTitle1.Visible = True : txtSr1.Visible = True
                lbltitle2.Visible = True : txtSr2.Visible = True
                lbltitle3.Visible = False : txtSr3.Visible = False
                lbltitle4.Visible = False : txtsr4.Visible = False
                lbltitle5.Visible = False : txtsr5.Visible = False
                lblTitle1.Text = clsFun.ExecScalarStr("Select SNo1 From SerialSetting ")
                lbltitle2.Text = clsFun.ExecScalarStr("Select SNo2 From SerialSetting ")
                pnlSerial.Size = New Size(300, 199)
                dgSerial.Size = New Size(279, 117)
            ElseIf Val(clsFun.ExecScalarStr("Select Nos From SerialSetting ")) = 3 Then
                lblTitle1.Visible = True : txtSr1.Visible = True
                lbltitle2.Visible = True : txtSr2.Visible = True
                lbltitle3.Visible = True : txtSr3.Visible = True
                lbltitle4.Visible = False : txtsr4.Visible = False
                lbltitle5.Visible = False : txtsr5.Visible = False
                lblTitle1.Text = clsFun.ExecScalarStr("Select SNo1 From SerialSetting ")
                lbltitle2.Text = clsFun.ExecScalarStr("Select SNo2 From SerialSetting ")
                lbltitle3.Text = clsFun.ExecScalarStr("Select SNo3 From SerialSetting ")
                pnlSerial.Size = New Size(440, 199) : dgSerial.Size = New Size(418, 117)
            ElseIf Val(clsFun.ExecScalarStr("Select Nos From SerialSetting ")) = 4 Then
                lblTitle1.Visible = True : txtSr1.Visible = True
                lbltitle2.Visible = True : txtSr2.Visible = True
                lbltitle3.Visible = True : txtSr3.Visible = True
                lbltitle4.Visible = True : txtsr4.Visible = True
                lbltitle5.Visible = False : txtsr5.Visible = False
                lblTitle1.Text = clsFun.ExecScalarStr("Select SNo1 From SerialSetting ")
                lbltitle2.Text = clsFun.ExecScalarStr("Select SNo2 From SerialSetting ")
                lbltitle3.Text = clsFun.ExecScalarStr("Select SNo3 From SerialSetting ")
                lbltitle4.Text = clsFun.ExecScalarStr("Select SNo4 From SerialSetting ")
                pnlSerial.Size = New Size(575, 199) : dgSerial.Size = New Size(557, 117)
            ElseIf Val(clsFun.ExecScalarStr("Select Nos From SerialSetting ")) = 5 Then
                lblTitle1.Visible = True : txtSr1.Visible = True
                lbltitle2.Visible = True : txtSr2.Visible = True
                lbltitle3.Visible = True : txtSr3.Visible = True
                lbltitle4.Visible = True : txtsr4.Visible = True
                lbltitle5.Visible = True : txtsr5.Visible = True
                lblTitle1.Text = clsFun.ExecScalarStr("Select SNo1 From SerialSetting ")
                lbltitle2.Text = clsFun.ExecScalarStr("Select SNo2 From SerialSetting ")
                lbltitle3.Text = clsFun.ExecScalarStr("Select SNo3 From SerialSetting ")
                lbltitle4.Text = clsFun.ExecScalarStr("Select SNo4 From SerialSetting ")
                lbltitle5.Text = clsFun.ExecScalarStr("Select SNo5 From SerialSetting ")
                pnlSerial.Size = New Size(714, 199) : dgSerial.Size = New Size(696, 117)
            End If
        Else
            pnlSerial.Visible = False
        End If
        dgSerial.ClearSelection()
    End Sub

    Private Sub txtRate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRate.KeyPress, txtDisPer.KeyPress, txtTaxPer.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8 Or ((e.KeyChar = ".") And (sender.Text.IndexOf(".") = -1)))
    End Sub
    Private Sub txtRate_Leave(sender As Object, e As EventArgs) Handles txtRate.Leave
        'If lblTaxType.Text <> "TI" Then
        If lblAltYN.Text = "Y" Then pnlPricePer.Visible = True : pnlPricePer.BringToFront() : cbPricePer.Focus() Else pnlaltinfo.Visible = False
        'End If
    End Sub

    Private Sub txtNetRate_Leave(sender As Object, e As EventArgs) Handles txtNetRate.Leave
        ' If lblAltYN.Text = "Y" Then pnlPricePer.Visible = True : pnlPricePer.BringToFront() : cbPricePer.Focus() Else pnlaltinfo.Visible = False
    End Sub

    Private Sub txtDisPer_Leave(sender As Object, e As EventArgs) Handles txtDisPer.Leave
        DiscountSetting()
    End Sub

    Private Sub txtCalculatePer_Leave(sender As Object, e As EventArgs) Handles txtCalculatePer.Leave
        If pnlGSTCharges.Visible = True Then txtChargeTaxable.Focus()
    End Sub

    Private Sub txtChargeTaxable_KeyDown(sender As Object, e As KeyEventArgs) Handles txtChargeTaxable.KeyDown, txtChargeTaxable.KeyDown, txtGstperCharge.KeyDown, txtGSTAmtCharge.KeyDown, txtCessAmtCharge.KeyDown,
        txtCessPerCharge.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtchargesAmount.Focus()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txtQty_KeuUp(sender As Object, e As KeyEventArgs) Handles txtQty.KeyUp, txtRate.KeyUp,
        txtTaxPer.KeyUp, txtNet.KeyUp, txtDisPer.KeyUp, txtDisAmt.KeyUp, txtNetRate.KeyUp,
        txtCalculatePer.KeyUp, txtOnValue.KeyUp, txtchargesAmount.KeyUp, txtChargeTaxable.KeyUp
        clsFun.ExecScalarInt("Select GroupID from Accounts where ID='" & Val(txtAccountID.Text) & "'")
        UNRegSupplies = clsFun.ExecScalarStr("Select GSTType From Accounts Where ID='" & Val(txtAccountID.Text) & "'")
        If (UNRegSupplies = "GST Registered" Or UNRegSupplies = "Composition") Or (cbGSTtype.Text = "GST Registered" Or cbGSTtype.Text = "Composition") Then
            Calculation() : ChargesCalculation()
        Else
            Calculation2() : ChargesCalculation()
        End If
    End Sub

    Private Sub txtTotAmt_GotFocus(sender As Object, e As EventArgs) Handles txtTotAmt.GotFocus
        pnlaltinfo.Visible = False : pnlCustomerInfo.Visible = False
        pnlNetRate.Visible = False : pnlDisc.Visible = False
        pnlPricePer.Visible = False
    End Sub

    Private Sub txtTotAmt_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTotAmt.KeyDown
        Dim hsncode As String = String.Empty
        Dim ItemCode As String = String.Empty
        Dim Pack As String = String.Empty
        hsncode = clsFun.ExecScalarStr("Select HSNCode From Items Where ID='" & Val(txtItemID.Text) & "'")
        ItemCode = clsFun.ExecScalarStr("Select ItemCode From Items Where ID='" & Val(txtItemID.Text) & "'")
        'Pack = clsFun.ExecScalarStr("Select Packing From Items Where ID='" & Val(txtItemID.Text) & "'")
        If e.KeyCode = Keys.Enter Then
            If Val(txtQty.Text) = 0 And Val(txtFreeQty.Text) = 0 Then MsgBox("Quantity is Empty... Please Fill Quantiy...", vbCritical.Critical, "No Quantity") : txtQty.Focus() : Exit Sub
            If dg1.SelectedRows.Count = 1 Then
                dg1.SelectedRows(0).Cells(0).Value = Val(txtItemID.Text)
                dg1.SelectedRows(0).Cells(1).Value = txtItem.Text
                dg1.SelectedRows(0).Cells(2).Value = hsncode
                dg1.SelectedRows(0).Cells(3).Value = ItemCode
                dg1.SelectedRows(0).Cells(4).Value = Pack
                dg1.SelectedRows(0).Cells(5).Value = Val(cbbatch.SelectedValue)
                dg1.SelectedRows(0).Cells(6).Value = cbbatch.Text
                dg1.SelectedRows(0).Cells(7).Value = cbPricePer.SelectedValue
                dg1.SelectedRows(0).Cells(8).Value = cbPricePer.Text
                dg1.SelectedRows(0).Cells(9).Value = Val(txtQty.Text)
                dg1.SelectedRows(0).Cells(10).Value = Val(txtQty.Text)
                dg1.SelectedRows(0).Cells(11).Value = Val(txtAltQty.Text)
                dg1.SelectedRows(0).Cells(12).Value = Val(txtFreeQty.Text)
                dg1.SelectedRows(0).Cells(13).Value = Format(Val(txtRate.Text), Hash)
                dg1.SelectedRows(0).Cells(14).Value = Format(Val(txtNet.Text), Hash)
                dg1.SelectedRows(0).Cells(15).Value = Format(Val(txtDisPer.Text), Hash)
                dg1.SelectedRows(0).Cells(16).Value = Format(Val(txtDisAmt.Text), Hash)
                dg1.SelectedRows(0).Cells(17).Value = Format(Val(txtTaxPer.Text), Hash)
                dg1.SelectedRows(0).Cells(18).Value = Format(Val(txtTaxAmt.Text), Hash)
                dg1.SelectedRows(0).Cells(19).Value = Format(Val(txtTotAmt.Text), Hash)
                dg1.SelectedRows(0).Cells(20).Value = Format(Val(txtNetRate.Text), Hash)
                dg1.SelectedRows(0).Cells(21).Value = lblDisHead1.Text
                dg1.SelectedRows(0).Cells(22).Value = Format(Val(txtOnValue1.Text), Hash)
                dg1.SelectedRows(0).Cells(23).Value = Format(Val(txtDisAmt1.Text), Hash)
                dg1.SelectedRows(0).Cells(24).Value = lblDisHead2.Text
                dg1.SelectedRows(0).Cells(25).Value = Format(Val(txtOnValue2.Text), Hash)
                dg1.SelectedRows(0).Cells(26).Value = Format(Val(txtDisAmt2.Text), Hash)
                dg1.SelectedRows(0).Cells(27).Value = lblDisHead3.Text
                dg1.SelectedRows(0).Cells(28).Value = Format(Val(txtOnValue3.Text), Hash)
                dg1.SelectedRows(0).Cells(29).Value = Format(Val(txtDisAmt3.Text), Hash)
                dg1.SelectedRows(0).Cells(30).Value = lblDisHead4.Text
                dg1.SelectedRows(0).Cells(31).Value = Format(Val(txtOnValue4.Text), Hash)
                dg1.SelectedRows(0).Cells(32).Value = Format(Val(txtDisAmt4.Text), Hash)
                dg1.SelectedRows(0).Cells(33).Value = Val(lblDiscamt.Text)
                dg1.SelectedRows(0).Cells(34).Value = Val(txtSerialID.Text)
                dg1.SelectedRows(0).Cells(36).Value = Format(Val(txtCalPer1.Text), Hash)
                dg1.SelectedRows(0).Cells(37).Value = Format(Val(txtCalPer2.Text), Hash)
                dg1.SelectedRows(0).Cells(38).Value = Format(Val(txtCalPer3.Text), Hash)
                dg1.SelectedRows(0).Cells(39).Value = Format(Val(txtCalPer4.Text), Hash)
                dg1.SelectedRows(0).Cells(40).Value = Format(Val(IGSTPER), Hash)
                dg1.SelectedRows(0).Cells(41).Value = Format(Val(IGSTAMT), Hash)
                dg1.SelectedRows(0).Cells(42).Value = Format(Val(SGSTPER), Hash)
                dg1.SelectedRows(0).Cells(43).Value = Format(Val(SGSTAMT), Hash)
                dg1.SelectedRows(0).Cells(44).Value = Format(Val(CGSTPER), Hash)
                dg1.SelectedRows(0).Cells(45).Value = Format(Val(CGSTAMT), Hash)
                dg1.SelectedRows(0).Cells(46).Value = Format(Val(CessPer), Hash)
                dg1.SelectedRows(0).Cells(47).Value = CessAsOn
                dg1.SelectedRows(0).Cells(48).Value = Format(Val(SpeCess), Hash)
                dg1.SelectedRows(0).Cells(49).Value = Format(Val(CessAmt), Hash)
                dg1.SelectedRows(0).Cells(51).Value = txtField1.Text
                dg1.SelectedRows(0).Cells(52).Value = txtField2.Text
                dg1.SelectedRows(0).Cells(53).Value = txtField3.Text
                dg1.SelectedRows(0).Cells(54).Value = txtField4.Text
                dg1.SelectedRows(0).Cells(55).Value = txtField5.Text
                dg1.SelectedRows(0).Cells(56).Value = txtField6.Text
                dg1.SelectedRows(0).Cells(57).Value = txtField7.Text
                dg1.SelectedRows(0).Cells(58).Value = txtField8.Text
                dg1.SelectedRows(0).Cells(59).Value = txtField9.Text
                dg1.SelectedRows(0).Cells(60).Value = txtField10.Text
                txtClear()
            Else
                dg1.Rows.Add(Val(txtItemID.Text), txtItem.Text, hsncode, ItemCode, Pack, Val(cbbatch.SelectedValue), cbbatch.Text, Val(cbPricePer.SelectedValue), cbPricePer.Text,
                  Val(txtQty.Text), Val(txtQty.Text), Val(txtAltQty.Text), Val(txtFreeQty.Text), Format(Val(txtRate.Text), Hash), Format(Val(txtNet.Text), Hash),
                 Format(Val(txtDisPer.Text), Hash), Format(Val(txtDisAmt.Text), Hash), Format(Val(txtTaxPer.Text), Hash), Format(Val(txtTaxAmt.Text), Hash),
                 Format(Val(txtTotAmt.Text), Hash), Format(Val(txtNetRate.Text), Hash), lblDisHead1.Text, Format(Val(txtOnValue1.Text), Hash), Format(Val(txtDisAmt1.Text), Hash),
                 lblDisHead2.Text, Format(Val(txtOnValue2.Text), Hash), Format(Val(txtDisAmt2.Text), Hash), lblDisHead3.Text, Format(Val(txtOnValue3.Text), Hash), Format(Val(txtDisAmt3.Text), Hash),
                 lblDisHead4.Text, Format(Val(txtOnValue4.Text), Hash), Format(Val(txtDisAmt4.Text), Hash), Val(lblDiscamt.Text), Val(txtSerialID.Text), 0, txtCalPer1.Text, txtCalPer2.Text,
                 txtCalPer3.Text, txtCalPer4.Text, IGSTPER, IGSTAMT, SGSTPER, SGSTAMT, CGSTPER, CGSTAMT, CessPer, CessAsOn, SpeCess, CessAmt, txtField1.Text, txtField2.Text, txtField3.Text, txtField4.Text, txtField5.Text, txtField6.Text,
                 txtField7.Text, txtField8.Text, txtField9.Text, txtField10.Text)
                txtClear()
            End If

        End If

    End Sub

    Private Sub txtClear()
        IGSTPER = 0 : IGSTAMT = 0
        SGSTPER = 0 : SGSTAMT = 0
        CGSTPER = 0 : CGSTAMT = 0
        If dg1.RowCount > 8 Then dg1.Columns(19).Width = 132 Else dg1.Columns(19).Width = 145
        dg1.ClearSelection() : lblUOM.Text = "" : txtQty.Clear() : txtAltQty.Clear()
        txtFreeQty.Clear() : txtRate.Clear() : txtNet.Clear() : txtDisPer.Clear()
        txtDisAmt.Clear() : txtTaxPer.Clear() : txtTaxAmt.Clear()
        txtNetRate.Clear() : txtTotAmt.Clear() : txtSerialID.Clear()
        txtOnValue1.Clear() : txtCalPer1.Clear() : txtDisAmt1.Clear()
        txtOnValue2.Clear() : txtCalPer2.Clear() : txtDisAmt2.Clear()
        txtOnValue3.Clear() : txtCalPer3.Clear() : txtDisAmt3.Clear()
        txtOnValue4.Clear() : txtCalPer4.Clear() : txtDisAmt4.Clear()
        txtField1.Clear() : txtField2.Clear() : txtField3.Clear()
        txtField4.Clear() : txtField5.Clear() : txtField6.Clear()
        txtField7.Clear() : txtField8.Clear() : txtField9.Clear()
        txtField10.Clear() : lblDiscamt.Text = Hash
        cbbatch.SelectedValue = 0 : cbbatch.Text = ""
        txtItem.Focus() : pnlNetRate.Visible = False
        lblTaxableamt.Visible = False
        UNRegSupplies = clsFun.ExecScalarStr("Select GSTType From Accounts Where ID='" & Val(txtAccountID.Text) & "'")
        If (UNRegSupplies = "GST Registered" Or UNRegSupplies = "Composition") Or (cbGSTtype.Text = "GST Registered" Or cbGSTtype.Text = "Composition") Then
            calc()
        Else
            calc2()
        End If
    End Sub

    Private Sub ClearAll()
        pnlCustomerInfo.Visible = False
        BtnSave.BackColor = Color.DarkTurquoise
        BtnSave.Text = "&Save" : BtnDelete.Enabled = False
        dg1.Rows.Clear() : Dg2.Rows.Clear()
        txtClear() : cleartxtCharges()
        txtCdPer.Clear() : txtID.Clear()
        txtAccount.Text = "" : txtAccountID.Text = ""
        lblTotQty.Visible = False : lblGstAmt.Visible = False
        txtTotNetAmt.Text = Hash : txtDisAmt.Text = Hash
        txtTotTaxAmt.Text = Hash : txtAfterCharges.Text = Hash
        txttotRoundoff.Text = Hash : txtTotTotal.Text = Hash
        txtTotCashAmt.Text = Hash : pnlEway.Visible = False
        pnlAdditional.Visible = False : pnlSerial.Visible = False
        If Application.OpenForms().OfType(Of Purchase_Register).Any = True Then Purchase_Register.btnShow.PerformClick()
        VNumber() : dgItemSearch.Visible = False : mskEntryDate.Focus()
    End Sub

    Private Sub ClearSelectionRow()
        calc() ': autoGSTPick()
        If dg1.RowCount > 8 Then dg1.Columns(19).Width = 131 Else dg1.Columns(19).Width = 145
        dg1.ClearSelection() : lblUOM.Text = "" : txtQty.Clear() : txtAltQty.Clear()
        txtFreeQty.Clear() : txtRate.Clear() : txtNet.Clear() : txtDisPer.Clear()
        txtDisAmt.Clear() : txtTaxPer.Clear() : txtTaxAmt.Clear()
        txtNetRate.Clear() : txtTotAmt.Clear() : txtSerialID.Clear()
        txtOnValue1.Clear() : txtCalPer1.Clear() : txtDisAmt1.Clear()
        txtOnValue2.Clear() : txtCalPer2.Clear() : txtDisAmt2.Clear()
        txtOnValue3.Clear() : txtCalPer3.Clear() : txtDisAmt3.Clear()
        txtOnValue4.Clear() : txtCalPer4.Clear() : txtDisAmt4.Clear()
        lblDiscamt.Text = Hash
        cbbatch.SelectedValue = 0 : cbbatch.Text = ""
        pnlNetRate.Visible = False : lblTaxableamt.Visible = False
    End Sub
    Private Sub dg1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg1.CellClick
        dg1.ClearSelection() : ClearSelectionRow()
    End Sub

    Private Sub dg1_KeyDown(sender As Object, e As KeyEventArgs) Handles dg1.KeyDown
        '  If e.KeyCode = Keys.Down Then If Dg2.CurrentRow.Index = Val(dg1.Rows.Count) Then txtItem.Focus()
        'If e.KeyCode = Keys.Up Then If Dg2.CurrentRow.Index = 0 Then txtItem.Focus()
        If e.KeyCode = Keys.Enter Then
            If dg1.SelectedRows.Count = 0 Then Exit Sub
            txtItemID.Text = Val(dg1.SelectedRows(0).Cells(0).Value)
            txtItem.Text = dg1.SelectedRows(0).Cells(1).Value
            hsncode = dg1.SelectedRows(0).Cells(2).Value
            ItemCode = dg1.SelectedRows(0).Cells(3).Value
            Pack = dg1.SelectedRows(0).Cells(4).Value
            cbbatch.SelectedValue = Val(dg1.SelectedRows(0).Cells(5).Value)
            cbbatch.Text = dg1.SelectedRows(0).Cells(6).Value
            cbPricePer.SelectedValue = Val(dg1.SelectedRows(0).Cells(7).Value)
            cbPricePer.Text = dg1.SelectedRows(0).Cells(8).Value
            txtQty.Text = Val(dg1.SelectedRows(0).Cells(9).Value)
            txtQty.Text = Val(dg1.SelectedRows(0).Cells(10).Value)
            txtAltQty.Text = Val(dg1.SelectedRows(0).Cells(11).Value)
            txtFreeQty.Text = Val(dg1.SelectedRows(0).Cells(12).Value)
            txtRate.Text = Format(Val(dg1.SelectedRows(0).Cells(13).Value), Hash)
            txtNet.Text = Format(Val(dg1.SelectedRows(0).Cells(14).Value), Hash)
            txtDisPer.Text = Format(Val(dg1.SelectedRows(0).Cells(15).Value), Hash)
            '    txtDisAmt.Text = Format(Val(dg1.SelectedRows(0).Cells(16).Value), Hash)
            txtTaxPer.Text = Format(Val(dg1.SelectedRows(0).Cells(17).Value), Hash)
            '     txtTaxAmt.Text = Format(Val(dg1.SelectedRows(0).Cells(18).Value), Hash)
            txtTotAmt.Text = Format(Val(dg1.SelectedRows(0).Cells(19).Value), Hash)
            txtNetRate.Text = Format(Val(dg1.SelectedRows(0).Cells(20).Value), Hash)
            txtCalPer1.Text = Format(Val(dg1.SelectedRows(0).Cells(36).Value), Hash)
            txtCalPer2.Text = Format(Val(dg1.SelectedRows(0).Cells(37).Value), Hash)
            txtCalPer3.Text = Format(Val(dg1.SelectedRows(0).Cells(38).Value), Hash)
            txtCalPer4.Text = Format(Val(dg1.SelectedRows(0).Cells(39).Value), Hash)

            txtField1.Text = dg1.SelectedRows(0).Cells(49).Value
            txtField2.Text = dg1.SelectedRows(0).Cells(50).Value
            txtField3.Text = dg1.SelectedRows(0).Cells(51).Value
            txtField4.Text = dg1.SelectedRows(0).Cells(52).Value
            txtField5.Text = dg1.SelectedRows(0).Cells(53).Value
            txtField6.Text = dg1.SelectedRows(0).Cells(54).Value
            txtField7.Text = dg1.SelectedRows(0).Cells(55).Value
            txtField8.Text = dg1.SelectedRows(0).Cells(56).Value
            txtField9.Text = dg1.SelectedRows(0).Cells(57).Value
            txtField10.Text = dg1.SelectedRows(0).Cells(58).Value
            txtItem.Focus()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub dg1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dg1.MouseDoubleClick
        If dg1.SelectedRows.Count = 0 Then Exit Sub
        If dg1.SelectedRows.Count = 0 Then Exit Sub
        txtItemID.Text = Val(dg1.SelectedRows(0).Cells(0).Value)
        txtItem.Text = dg1.SelectedRows(0).Cells(1).Value
        hsncode = dg1.SelectedRows(0).Cells(2).Value
        ItemCode = dg1.SelectedRows(0).Cells(3).Value
        Pack = dg1.SelectedRows(0).Cells(4).Value
        cbbatch.SelectedValue = Val(dg1.SelectedRows(0).Cells(5).Value)
        cbbatch.Text = dg1.SelectedRows(0).Cells(6).Value
        cbPricePer.SelectedValue = Val(dg1.SelectedRows(0).Cells(7).Value)
        cbPricePer.Text = dg1.SelectedRows(0).Cells(8).Value
        txtQty.Text = Val(dg1.SelectedRows(0).Cells(9).Value)
        txtQty.Text = Val(dg1.SelectedRows(0).Cells(10).Value)
        txtAltQty.Text = Val(dg1.SelectedRows(0).Cells(11).Value)
        txtFreeQty.Text = Val(dg1.SelectedRows(0).Cells(12).Value)
        txtRate.Text = Format(Val(dg1.SelectedRows(0).Cells(13).Value), Hash)
        txtNet.Text = Format(Val(dg1.SelectedRows(0).Cells(14).Value), Hash)
        txtDisPer.Text = Format(Val(dg1.SelectedRows(0).Cells(15).Value), Hash)
        '    txtDisAmt.Text = Format(Val(dg1.SelectedRows(0).Cells(16).Value), Hash)
        txtTaxPer.Text = Format(Val(dg1.SelectedRows(0).Cells(17).Value), Hash)
        '     txtTaxAmt.Text = Format(Val(dg1.SelectedRows(0).Cells(18).Value), Hash)
        txtTotAmt.Text = Format(Val(dg1.SelectedRows(0).Cells(19).Value), Hash)
        txtNetRate.Text = Format(Val(dg1.SelectedRows(0).Cells(20).Value), Hash)
        txtCalPer1.Text = Format(Val(dg1.SelectedRows(0).Cells(36).Value), Hash)
        txtCalPer2.Text = Format(Val(dg1.SelectedRows(0).Cells(37).Value), Hash)
        txtCalPer3.Text = Format(Val(dg1.SelectedRows(0).Cells(38).Value), Hash)
        txtCalPer4.Text = Format(Val(dg1.SelectedRows(0).Cells(39).Value), Hash)

        txtField1.Text = dg1.SelectedRows(0).Cells(49).Value
        txtField2.Text = dg1.SelectedRows(0).Cells(50).Value
        txtField3.Text = dg1.SelectedRows(0).Cells(51).Value
        txtField4.Text = dg1.SelectedRows(0).Cells(52).Value
        txtField5.Text = dg1.SelectedRows(0).Cells(53).Value
        txtField6.Text = dg1.SelectedRows(0).Cells(54).Value
        txtField7.Text = dg1.SelectedRows(0).Cells(55).Value
        txtField8.Text = dg1.SelectedRows(0).Cells(56).Value
        txtField9.Text = dg1.SelectedRows(0).Cells(57).Value
        txtField10.Text = dg1.SelectedRows(0).Cells(58).Value
        txtItem.Focus()
    End Sub
    Private Sub txtNetRate_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNetRate.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtDisPer.Focus()
            e.SuppressKeyPress = True
            pnlNetRate.Visible = False
        End If
    End Sub
    Private Sub cbState_Leave(sender As Object, e As EventArgs)
        txtStateCode.Text = Format(Val(clsFun.ExecScalarStr("Select StateGSTCodes From StateList Where ID='" & Val(cbState.SelectedValue) & "'")), "00")
    End Sub

     Private Sub autoGSTPick()
        lblTaxType.Visible = True
        lblTaxType.Text = clsFun.ExecScalarStr("Select TaxType From TaxSetting Where ID='" & Val(cbSeries.SelectedValue) & "'")
        If Val(clsFun.ExecScalarStr("Select Count(*) From Vouchers Where TransType='" & Me.Text & "'")) = 0 Then
            If Val(clsFun.ExecScalarStr("Select InvoiceStart From TaxSetting Where ID='" & Val(cbSeries.SelectedValue) & "'")) > 0 Then
                txtVoucherNo.Text = clsFun.ExecScalarStr("Select InvoiceStart From TaxSetting Where ID='" & Val(cbSeries.SelectedValue) & "'")
                txtInvoiceID.Text = clsFun.ExecScalarStr("Select InvoiceStart From TaxSetting Where ID='" & Val(cbSeries.SelectedValue) & "'")
            End If
        End If

        If clsFun.ExecScalarStr("Select InvoicePrefix From TaxSetting Where ID='" & Val(cbSeries.SelectedValue) & "'") <> "" Then
            Dim Prefix As String = clsFun.ExecScalarStr("Select InvoicePrefix From TaxSetting Where ID='" & Val(cbSeries.SelectedValue) & "'")
            txtVoucherNo.Text = Prefix & txtVoucherNo.Text
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
        If BtnSave.Text = "&Save" Then
            If Val(txtAccountID.Text) = 7 Then
                txtTotCashAmt.Text = txtTotTotal.Text
                txtTotDueamt.Text = Format(0, Hash)
            Else
                txtTotCashAmt.Text = Format(0, Hash)
                txtTotDueamt.Text = txtTotTotal.Text
            End If
        End If



    End Sub


    Private Sub txtAccountID_TextChanged(sender As Object, e As EventArgs) Handles txtAccountID.TextChanged
        'autoGSTPick()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If dg1.RowCount = 0 Then MsgBox("Please Fill Some Record to Save this Invoice...", vbCritical.Critical, "No Reocrd to Save/Update") : txtItem.Focus() : Exit Sub
        If txtAccount.Text = "" Then MsgBox("Please Fill Account Name", vbCritical.Critical, "No Acount Name Found") : txtAccount.Focus() : Exit Sub
        If BtnSave.Text = "&Save" Then
            If Val(clsFun.ExecScalarStr("Select count(*) from Vouchers where upper(InvoiceNo)=upper('" & txtVoucherNo.Text & "') and TransType='" & Me.Text & "'")) >= 1 And Val(txtVoucherNo.Text) <> 0 Then
                MsgBox("Invoice No. Already Exists...", vbCritical.Critical, "Access Denied")
                vno = clsFun.ExecScalarInt("SELECT InvoiceID AS NumberOfProducts FROM Vouchers WHERE id=(SELECT max(id) FROM Vouchers Where TransType='" & Me.Text & "')")
                txtVoucherNo.Text = vno + 1 : txtInvoiceID.Text = vno + 1
                txtVoucherNo.Focus() : Exit Sub
            End If
        Else

            If Val(clsFun.ExecScalarStr("Select count(*) from Vouchers where upper(InvoiceNo)=upper('" & txtVoucherNo.Text & "') and TransType='" & Me.Text & "'")) > 1 And Val(txtVoucherNo.Text) <> 0 Then
                MsgBox("Invoice No. Already Exists...", vbCritical.Critical, "Access Denied")
                vno = clsFun.ExecScalarInt("SELECT InvoiceID AS NumberOfProducts FROM Vouchers WHERE id=(SELECT max(id) FROM Vouchers Where TransType='" & Me.Text & "')")
                txtVoucherNo.Text = vno + 1 : txtInvoiceID.Text = vno + 1
                txtVoucherNo.Focus() : Exit Sub
            End If
        End If
        If BtnSave.Text = "&Save" Then
            Save()
        Else
            Update()
        End If
        txtID.Clear()
    End Sub

    Private Sub InsertCharges()
        Dim FastQuery As String = String.Empty
        For Each row As DataGridViewRow In Dg2.Rows
            With row
                If .Cells("Charge Name").Value <> "" Then
                    Dim AcID As Integer = clsFun.ExecScalarInt("Select AccountID from Charges where ID=" & Val(.Cells(5).Value) & "")
                    ssql = clsFun.ExecScalarStr("Select AccountName from Charges where ID=" & Val(.Cells(5).Value) & "")
                    Dim AccName As String = ssql
                    Dim FixAs As String = clsFun.ExecScalarStr(" Select FixAs FROM Charges WHERE ID='" & Val(.Cells(5).Value) & "'")
                    If .Cells(3).Value = "+" Then
                        FastQuery = FastQuery & IIf(FastQuery <> "", " UNION ALL SELECT ", " SELECT ") & Val(txtID.Text) & ",'" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "','" & Me.Text & "'," & Val(AcID) & ",'" & AccName & "'," & Val(.Cells(4).Value) & ", 'D','" & "Invoice No.:" & txtVoucherNo.Text & "," & txtAccount.Text & "', '" & txtAccount.Text & "','" & remarkHindi & "'"
                    Else
                        FastQuery = FastQuery & IIf(FastQuery <> "", " UNION ALL SELECT ", " SELECT ") & Val(txtID.Text) & ",'" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "','" & Me.Text & "'," & Val(AcID) & ",'" & AccName & "'," & Val(.Cells(4).Value) & ", 'C','" & "Invoice No.:" & txtVoucherNo.Text & "," & txtAccount.Text & "', '" & txtAccount.Text & "','" & remarkHindi & "'"
                    End If
                End If
            End With
        Next
        If FastQuery = "" Then Exit Sub
        clsFun.FastLedger(FastQuery)
        clsFun.CloseConnection()
    End Sub
    
    Private Sub insertLedger()
        Dim FastQuery As String = String.Empty
        If txtAccountID.Text > 0 Then ''Party Account
            If Val(txtTotCashAmt.Text) > 0 Then
                FastQuery = FastQuery & IIf(FastQuery <> "", " UNION ALL SELECT ", " SELECT ") & Val(txtID.Text) & ",'" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "','" & Me.Text & "'," & Val(7) & ",'" & clsFun.ExecScalarStr("Select AccountName from Accounts where Id=7") & "'," & Val(txtTotCashAmt.Text) & ", 'C','" & "Invoice No.:" & txtVoucherNo.Text & "," & txtAccount.Text & "', '" & txtAccount.Text & "'"
            ElseIf Val(txtTotCashAmt.Text) < 0 Then
                FastQuery = FastQuery & IIf(FastQuery <> "", " UNION ALL SELECT ", " SELECT ") & Val(txtID.Text) & ",'" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "','" & Me.Text & "'," & Val(7) & ",'" & clsFun.ExecScalarStr("Select AccountName from Accounts where Id=7") & "'," & Math.Abs(Val(txtTotCashAmt.Text)) & ", 'D','" & "Invoice No.:" & txtVoucherNo.Text & "," & txtAccount.Text & "', '" & txtAccount.Text & "'"
            End If
            If Val(txtTotDueamt.Text) > 0 Then
                FastQuery = FastQuery & IIf(FastQuery <> "", " UNION ALL SELECT ", " SELECT ") & Val(txtID.Text) & ",'" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "','" & Me.Text & "'," & Val(txtAccountID.Text) & ",'" & txtAccount.Text & "'," & Math.Abs(Val(txtTotDueamt.Text)) & ", 'C','" & "Invoice No.:" & txtVoucherNo.Text & "," & txtAccount.Text & "', '" & txtAccount.Text & "'"
            ElseIf Val(txtTotDueamt.Text) < 0 Then
                FastQuery = FastQuery & IIf(FastQuery <> "", " UNION ALL SELECT ", " SELECT ") & Val(txtID.Text) & ",'" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "','" & Me.Text & "'," & Val(txtAccountID.Text) & ",'" & txtAccount.Text & "'," & Math.Abs(Val(txtTotDueamt.Text)) & ", 'D','" & "Invoice No.:" & txtVoucherNo.Text & "," & txtAccount.Text & "', '" & txtAccount.Text & "'"
            End If
            If Val(txtTotTaxable.Text) > 0 Then ''Maal Khata Account
                FastQuery = FastQuery & IIf(FastQuery <> "", " UNION ALL SELECT ", " SELECT ") & Val(txtID.Text) & ",'" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "','" & Me.Text & "'," & Val(28) & ",'" & clsFun.ExecScalarStr("Select AccountName from Accounts where Id=28") & "'," & Val(txtTotTaxable.Text) & ", 'D','" & "Invoice No.:" & txtVoucherNo.Text & "," & txtAccount.Text & "', '" & txtAccount.Text & "'"
            End If

            If lblRegion.Text = "Local" Then
                If Val(txtTotTaxAmt.Text + chargestax) > 0 Then 'SGST+CGST
                    FastQuery = FastQuery & IIf(FastQuery <> "", " UNION ALL SELECT ", " SELECT ") & Val(txtID.Text) & ",'" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "','" & Me.Text & "'," & Val(998) & ",'" & clsFun.ExecScalarStr("Select AccountName from Accounts where Id=998") & "'," & Val(TotalSGST) & ", 'D','" & "Invoice No.:" & txtVoucherNo.Text & "," & txtAccount.Text & "', '" & txtAccount.Text & "'"
                    FastQuery = FastQuery & IIf(FastQuery <> "", " UNION ALL SELECT ", " SELECT ") & Val(txtID.Text) & ",'" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "','" & Me.Text & "'," & Val(999) & ",'" & clsFun.ExecScalarStr("Select AccountName from Accounts where Id=999") & "'," & Val(TotalCGST) & ", 'D','" & "Invoice No.:" & txtVoucherNo.Text & "," & txtAccount.Text & "', '" & txtAccount.Text & "'"
                End If
            Else
                If Val(txtTotTaxAmt.Text + chargestax) > 0 Then ''IGST
                    FastQuery = FastQuery & IIf(FastQuery <> "", " UNION ALL SELECT ", " SELECT ") & Val(txtID.Text) & ",'" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "','" & Me.Text & "'," & Val(1000) & ",'" & clsFun.ExecScalarStr("Select AccountName from Accounts where Id=100") & "'," & Val(TotalIGST) & ", 'D','" & "Invoice No.:" & txtVoucherNo.Text & "," & txtAccount.Text & "', '" & txtAccount.Text & "'"
                End If
            End If
        End If
        If (TotalCess) <> 0 Then
            FastQuery = FastQuery & IIf(FastQuery <> "", " UNION ALL SELECT ", " SELECT ") & Val(txtID.Text) & ",'" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "','" & Me.Text & "'," & Val(1000) & ",'" & clsFun.ExecScalarStr("Select AccountName from Accounts where Id=100") & "'," & Val(TotalCess) & ", 'D','" & "Invoice No.:" & txtVoucherNo.Text & "," & txtAccount.Text & "', '" & txtAccount.Text & "'"
        End If
        If Val(txttotRoundoff.Text) <> 0 Then ''Account
            If Val(txttotRoundoff.Text) < 0 Then
                FastQuery = FastQuery & IIf(FastQuery <> "", " UNION ALL SELECT ", " SELECT ") & Val(txtID.Text) & ",'" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "','" & Me.Text & "'," & Val(42) & ",'" & clsFun.ExecScalarStr("Select AccountName from Accounts where Id=42") & "'," & Math.Abs(Val(txttotRoundoff.Text)) & ", 'C','" & "Invoice No.:" & txtVoucherNo.Text & "," & txtAccount.Text & "', '" & txtAccount.Text & "'"
            Else
                FastQuery = FastQuery & IIf(FastQuery <> "", " UNION ALL SELECT ", " SELECT ") & Val(txtID.Text) & ",'" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "','" & Me.Text & "'," & Val(42) & ",'" & clsFun.ExecScalarStr("Select AccountName from Accounts where Id=42") & "'," & Math.Abs(Val(txttotRoundoff.Text)) & ", 'D','" & "Invoice No.:" & txtVoucherNo.Text & "," & txtAccount.Text & "', '" & txtAccount.Text & "'"
            End If
        End If
        If FastQuery = "" Then Exit Sub
        clsFun.FastLedger(FastQuery)
    End Sub
    Private Sub UpdateEwayBill()
        If Val(txtTotTotal.Text) >= Val(50000) Then
            Dim sql As String = "Update Vouchers Set E1='" & txtEwayBillNo.Text & "',E2='" & mskEwayDate.Text & "',E3='" & cbSubType.Text & "', " & _
         "E4='" & cbDocumentType.Text & "',E5='" & cbTranport.Text & "',E6='" & txtFromPin.Text & "',E7='" & txtToPin.Text & "',E8='" & txtDistance.Text & "', " & _
         "E9='" & txtVehicleNo.Text & "',E10='" & txtTransPorterName.Text & "',E11='" & txtLrNo.Text & "',E12='" & txtEwayBillDated.Text & "', " & _
         "E13='" & TxtTPID.Text & "' Where ID=" & Val(txtID.Text) & ""
            cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
            Try
                clsFun.ExecNonQuery(sql)
            Catch ex As Exception

            End Try
        End If

    End Sub
    Private Sub Save()
      
        Dim cmd As New SQLite.SQLiteCommand

        Dim sql As String = "insert into Vouchers (TransType,InvoiceNo,InvoiceID,Entrydate,TotQty,SeriesID, " & _
            " SeriesName,AccountID,AccountName,TotalBasicAmt,TotalDiscAmt,TotalTaxAmt,AfterCharges,RoundOff, " & _
            " TotalGrandAmt,TotalCashAmt,TotalBalAmt,CustomerName,CustomerAddress,CustomerMobile,CustomerGSTN,StateName,StateCode,TotalIGSTAmt,TotalCGSTAmt,TotalSGSTAmt, " & _
            " TotalCessAmt,CdPer,CdAmount,TotalTaxableAmt,GSTType) SELECT '" & Me.Text & "','" & txtVoucherNo.Text & "'," & Val(txtInvoiceID.Text) & ", " & _
            "'" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "'," & Val(lblTotQty.Text) & "," & Val(cbSeries.SelectedValue) & ",'" & cbSeries.Text & "'," & Val(txtAccountID.Text) & ", " & _
            "'" & txtAccount.Text & "'," & Val(txtTotNetAmt.Text) & "," & Val(txtTotDisAmt.Text) & "," & Val(txtTotTaxAmt.Text) & "," & Val(txtAfterCharges.Text) & "," & Val(txttotRoundoff.Text) & ", " & _
            "" & Val(txtTotTotal.Text) & "," & Val(txtTotCashAmt.Text) & "," & Val(txtTotDueamt.Text) & ",'" & txtCustomerName.Text & "','" & txtFullAddress.Text & "', " & _
            "'" & txtMobileNo.Text & "','" & txtGSTN.Text & "','" & cbState.Text & "','" & txtStateCode.Text & "'," & IIf(lblRegion.Text = "Local", 0, Val(TotalIGST)) & ", " & _
            "" & IIf(lblRegion.Text = "Local", Val(Val(TotalSGST)), 0) & "," & IIf(lblRegion.Text = "Local", Val(Val(TotalCGST)), 0) & "," & Val(TotalCess) & ", " & _
            "" & Val(txtCdPer.Text) & "," & Val(txtBeforeCharges.Text) & "," & Val(TaxableTotal) & ",'" & cbGSTtype.Text & "'"

        'Dim sql As String = "insert into Vouchers (TransType,InvoiceNo,InvoiceID,Entrydate,TotQty,SeriesID, " & _
        '    " SeriesName,AccountID,AccountName,TotalBasicAmt,TotalDiscAmt,TotalTaxAmt,AfterCharges,RoundOff, " & _
        '    " TotalGrandAmt,TotalCashAmt,TotalBalAmt,CustomerName,CustomerAddress,CustomerMobile,CustomerGSTN,StateName,StateCode,TotalIGSTAmt,TotalCGSTAmt,TotalSGSTAmt, " & _
        '    " TotalCashAmt,CdPer,CdAmount,TotalTaxableAmt,GSTType) values (@1,@2,@3,@4,@5,@6,@7,@8,@9, " & _
        '    "@10,@11,@12,@13,@14,@15,@16,@17,@18,@19,@20,@21,@22,@23,@24,@25,@26,@27,@28,@29,@30,@31)"
        'Try
        '    cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
        '    cmd.Parameters.AddWithValue("@1", Me.Text)
        '    cmd.Parameters.AddWithValue("@2", txtVoucherNo.Text)
        '    cmd.Parameters.AddWithValue("@3", txtInvoiceID.Text)
        '    cmd.Parameters.AddWithValue("@4", CDate(mskEntryDate.Text).ToString("yyyy-MM-dd"))
        '    cmd.Parameters.AddWithValue("@5", Val(lblTotQty.Text))
        '    cmd.Parameters.AddWithValue("@6", Val(cbSeries.SelectedValue))
        '    cmd.Parameters.AddWithValue("@7", cbSeries.Text)
        '    cmd.Parameters.AddWithValue("@8", Val(txtAccountID.Text))
        '    cmd.Parameters.AddWithValue("@9", txtAccount.Text)
        '    cmd.Parameters.AddWithValue("@10", Val(txtTotNetAmt.Text))
        '    cmd.Parameters.AddWithValue("@11", Val(txtTotDisAmt.Text))
        '    cmd.Parameters.AddWithValue("@12", Val(txtTotTaxAmt.Text))
        '    cmd.Parameters.AddWithValue("@13", Val(txtAfterCharges.Text))
        '    cmd.Parameters.AddWithValue("@14", Val(txttotRoundoff.Text))
        '    cmd.Parameters.AddWithValue("@15", Val(txtTotTotal.Text))
        '    cmd.Parameters.AddWithValue("@16", Val(txtTotCashAmt.Text))
        '    cmd.Parameters.AddWithValue("@17", Val(txtTotDueamt.Text))
        '    cmd.Parameters.AddWithValue("@18", txtCustomerName.Text)
        '    cmd.Parameters.AddWithValue("@19", txtFullAddress.Text)
        '    cmd.Parameters.AddWithValue("@20", txtMobileNo.Text)
        '    cmd.Parameters.AddWithValue("@21", txtGSTN.Text)
        '    cmd.Parameters.AddWithValue("@22", cbState.Text)
        '    cmd.Parameters.AddWithValue("@23", txtStateCode.Text)
        '    cmd.Parameters.AddWithValue("@24", IIf(lblRegion.Text = "Local", 0, Val(TotalIGST)))
        '    cmd.Parameters.AddWithValue("@25", IIf(lblRegion.Text = "Local", Val(Val(TotalSGST)), 0))
        '    cmd.Parameters.AddWithValue("@26", IIf(lblRegion.Text = "Local", Val(Val(TotalCGST)), 0))
        '    cmd.Parameters.AddWithValue("@27", Val(TotalCess))
        '    cmd.Parameters.AddWithValue("@28", Val(txtCdPer.Text))
        '    cmd.Parameters.AddWithValue("@29", Val(txtBeforeCharges.Text))
        '    cmd.Parameters.AddWithValue("@30", Val(TaxableTotal))
        '    cmd.Parameters.AddWithValue("@31", cbGSTtype.Text)
        ' If cmd.ExecuteNonQuery() > 0 Then
        Try
            If clsFun.ExecNonQuery(sql) > 0 Then
                txtID.Text = clsFun.ExecScalarInt("Select Max(ID) from Vouchers")
                UpdateEwayBill() : dg1Record() : dg2Record() : taxDetails() : insertLedger() : InsertCharges() ': SerialRecord() : MaintainBBB()
                MsgBox("Purchase Invoice : " & txtVoucherNo.Text & " Saved Successfully...", vbInformation, "successful")
                ClearAll()
            End If
            clsFun.CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message)
            clsFun.CloseConnection()
        End Try
    End Sub
    Private Sub MaintainBBB()
        Dim sql As String
        If BtnSave.Text = "&Update" And Val(clsFun.ExecScalarInt("Select Count(*) From Ref Where VoucherID='" & Val(txtID.Text) & "'")) = 0 Then Exit Sub
        If clsFun.ExecScalarStr("Select MaintainBillByBill From Accounts Where ID='" & Val(txtAccountID.Text) & "'") = "Y" Then
            clsFun.ExecNonQuery("Delete From Ref Where VoucherID='" & Val(txtID.Text) & "'")
            sql = "Insert Into Ref(VoucherID,InvoiceNo,EntryDate,DueDate,TransType,Mathod,AccountID,AccountName,RefAmount,DC)" & _
                "values('" & Val(txtID.Text) & "','" & txtVoucherNo.Text & "','" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "'," & _
                "'" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "','" & Me.Text & "','New Ref', " & _
                "'" & Val(txtAccountID.Text) & "','" & txtAccount.Text & "','" & Val(txtTotTotal.Text) & "','D')"
            clsFun.ExecNonQuery(sql)
        End If
    End Sub
    Sub SerialRecord()
        Dim FastQuery As String = String.Empty
        Dim sql As String = String.Empty
        clsFun.ExecNonQuery("Delete From Serials Where VoucherID='" & Val(txtID.Text) & "';")
        For i As Integer = 0 To dgSerial.Rows.Count - 1
            With dgSerial.Rows(i)
                Dim ItemName As String = clsFun.ExecScalarStr("SELECT ItemName From Items Where ID='" & Val(.Cells(0).Value) & "'")
                FastQuery = FastQuery & IIf(FastQuery <> "", " UNION ALL SELECT ", " SELECT ") & Val(txtID.Text) & ",'" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "','" & Me.Text & "', " & _
                "'" & Val(.Cells(1).Value) & "','" & Val(.Cells(1).Value) & "','" & Val(.Cells(0).Value) & "','" & ItemName & "'," & _
                "'" & Val(txtAccountID.Text) & "','" & txtAccount.Text & "','" & .Cells(2).Value & "','" & .Cells(3).Value & "'," & _
                "'" & .Cells(4).Value & "','" & .Cells(5).Value & "','" & .Cells(6).Value & "'"
            End With
        Next
        Try
            If FastQuery = "" Then Exit Sub
            sql = "insert into Serials(VoucherID,EntryDate,TransType, SerialID,SerialNos,ItemID,ItemName,AccountID,AccountName,SerialNo1,SerialNo2,SerialNo3,SerialNo4,SerialNo5)" & FastQuery & ""
            clsFun.ExecNonQuery(sql)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub dg1Record()
        Dim FastQuery As String = String.Empty
        Dim Sql As String = String.Empty
        For i As Integer = 0 To dg1.Rows.Count - 1
            With dg1.Rows(i)
                '''Real Data  
                Dim itemTaxableAmt As Decimal = Val(.Cells(14).Value) - Val(Val(.Cells(16).Value) + Val(.Cells(33).Value) + Val(.Cells(35).Value)) + Val(.Cells(50).Value)
                Dim ItemName As String = clsFun.ExecScalarStr("SELECT ItemName From Items Where ID='" & Val(.Cells(0).Value) & "'")
                Dim HSnCode As String = clsFun.ExecScalarStr("SELECT HSnCode From Items Where ID='" & Val(.Cells(0).Value) & "'")
                Dim TaxID As Integer = clsFun.ExecScalarInt("SELECT T.ID as TaxID  FROM Items AS I INNER JOIN Taxation AS T ON I.TaxID = T.Id Where I.ID='" & Val(.Cells(0).Value) & "'")
                Dim TaxName As String = clsFun.ExecScalarStr("SELECT T.TaxName as TaxName  FROM Items AS I INNER JOIN Taxation AS T ON I.TaxID = T.Id Where I.ID='" & Val(.Cells(0).Value) & "'")
                ''Dg1 Data
                FastQuery = FastQuery & IIf(FastQuery <> "", " UNION ALL SELECT ", " SELECT ") & Val(txtID.Text) & ",'" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "','" & Me.Text & "', " & _
                               "'" & Val(.Cells(0).Value) & "','" & ItemName & "', " & _
                               "'" & HSnCode & "','" & .Cells(3).Value & "','" & .Cells(4).Value & "','" & .Cells(5).Value & "'," & _
                              "'" & .Cells(6).Value & "','" & .Cells(7).Value & "','" & .Cells(8).Value & "', " & _
                              "'" & TaxID & "','" & TaxName & "','" & .Cells(9).Value & "'," & .Cells(10).Value & ", " & _
                              "'" & .Cells(11).Value & "','" & .Cells(12).Value & "','" & .Cells(13).Value & "','" & .Cells(14).Value & "', " & _
                              "'" & .Cells(15).Value & "','" & .Cells(16).Value & "','" & .Cells(17).Value & "','" & .Cells(18).Value & "', " & _
                              "'" & .Cells(19).Value & "','" & .Cells(20).Value & "','" & itemTaxableAmt & "', " & _
                              "'" & .Cells(50).Value & "','" & .Cells(40).Value & "','" & .Cells(41).Value & "', " & _
                              "'" & .Cells(42).Value & "','" & .Cells(43).Value & "','" & .Cells(44).Value & "', " & _
                              "'" & .Cells(45).Value & "','" & Val(.Cells(46).Value) & "','" & .Cells(47).Value & "','" & Val(.Cells(48).Value) & "','" & Val(.Cells(49).Value) & "', " & _
                              "'" & .Cells(21).Value & "','" & .Cells(22).Value & "','" & .Cells(23).Value & "','" & .Cells(24).Value & "', " & _
                              "'" & .Cells(25).Value & "','" & .Cells(26).Value & "','" & .Cells(27).Value & "','" & .Cells(28).Value & "', " & _
                              "'" & .Cells(29).Value & "','" & Val(.Cells(30).Value) & "','" & Val(.Cells(31).Value) & "','" & .Cells(32).Value & "', " & _
                              "'" & .Cells(33).Value & "','" & Val(.Cells(34).Value) & "','" & Val(.Cells(35).Value) & "','" & .Cells(36).Value & "', " & _
                              "'" & .Cells(37).Value & "','" & Val(.Cells(38).Value) & "','" & Val(.Cells(39).Value) & "','" & .Cells(46).Value & "', " & _
                              "'" & .Cells(47).Value & "','" & .Cells(48).Value & "','" & .Cells(49).Value & "','" & .Cells(50).Value & "', " & _
                              "'" & .Cells(51).Value & "','" & .Cells(52).Value & "','" & .Cells(53).Value & "','" & .Cells(54).Value & "','" & .Cells(55).Value & "'"
                cmd = New SQLite.SQLiteCommand(ssql, clsFun.GetConnection())
            End With
        Next
        Try
            Sql = "Insert into Trans(VoucherID,EntryDate,TransType, ItemID,ItemName,HSNCode,ItemCode,Pack,BatchID,Batch,UnitID,UnitName," & _
                  "TaxID,TaxName,MainQty,Qty,AltQty,FreeQty,Rate,BasicAmt,DisPer,DisAmt,TaxPer,TaxAmt,TotalAmt, " & _
                  "NetRate,TaxableAmt,ApprValue,IGSTPer,IGSTAmt,SGSTper,SGSTAmt,CGSTPer,CGSTAmt,CessPer,CessbasedOn,SpecialCess,CessAmt,DisName1,DisOnValue1,DisAmt1, " & _
                  "DisName2,DisOnValue2,DisAmt2,DisName3,DisOnValue3,DisAmt3,DisName4,DisOnValue4,DisAmt4,TotDiscAmt,SerialID,CdAmt,DisCal1, " & _
                  "DisCal2,DisCal3,DisCal4,Field1,Field2,Field3,Field4,Field5,Field6,Field7,Field8,Field9,Field10) " & FastQuery & ""
            If FastQuery = String.Empty Then Exit Sub
            clsFun.ExecNonQuery(Sql)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        clsFun.CloseConnection()
    End Sub
    Private Sub taxDetails()
        Dim i As Integer = 0
        Dim AccountName As String
        Dim GSTType As String : Dim GSTIN As String
        Dim State As String : Dim StateCode As String
        Dim ssql As String = String.Empty
        Dim FastQuery As String = String.Empty
        Dim Sql As String = String.Empty
        clsFun.ExecScalarStr("Delete From TaxDetails Where VoucherID='" & (txtID.Text) & "'")
        AccountName = clsFun.ExecScalarStr("Select AccountName from Account_AcGrp Where ID=" & Val(txtAccountID.Text) & "")
        If Val(clsFun.ExecScalarStr("Select GroupID from Account_AcGrp Where ID=" & Val(txtAccountID.Text) & "")) <> 11 Then
            GSTType = clsFun.ExecScalarStr("Select GSTType from Account_AcGrp Where ID=" & Val(txtAccountID.Text) & "")
            GSTIN = clsFun.ExecScalarStr("Select GSTNo from Account_AcGrp Where ID=" & Val(txtAccountID.Text) & "")
            State = clsFun.ExecScalarStr("Select State from Account_AcGrp Where ID=" & Val(txtAccountID.Text) & "")
            State = clsFun.ExecScalarStr("Select State from Account_AcGrp Where ID=" & Val(txtAccountID.Text) & "")
            StateCode = Format(Val(clsFun.ExecScalarStr("Select StateCode from Account_AcGrp Where ID=" & Val(txtAccountID.Text) & "")), "00")
        Else
            AccountName = IIf(txtCustomerName.Text = "", AccountName, txtCustomerName.Text)
            GSTType = cbGSTtype.Text : GSTIN = txtGSTN.Text
            State = cbState.Text : StateCode = Format(Val(txtStateCode.Text), "00")
        End If
        For Each row As DataGridViewRow In dg1.Rows
            With row
                Dim Qty As Decimal = Val(.Cells(10).Value) + Val(.Cells(12).Value)
                Dim GSTUNit As String = clsFun.ExecScalarStr("Select MainUnit From ItemUnits Where ID='" & Val(.Cells(7).Value) & "'")
                Dim itemTaxableAmt As Decimal = Val(.Cells(14).Value) - Val(Val(.Cells(16).Value) + Val(.Cells(33).Value) + Val(.Cells(35).Value)) + Val(.Cells(50).Value)
                Dim ItemName As String = clsFun.ExecScalarStr("SELECT ItemName From Items Where ID='" & Val(.Cells(0).Value) & "'")
                Dim HSnCode As String = clsFun.ExecScalarStr("SELECT HSnCode From Items Where ID='" & Val(.Cells(0).Value) & "'")
                ' Dim SupplyType As String = clsFun.ExecScalarStr("SELECT SupplyType From Items Where ID='" & Val(.Cells(0).Value) & "'")
                Dim SupplyType As String = "Goods"
                Dim TaxID As Integer = clsFun.ExecScalarInt("SELECT T.ID as TaxID  FROM Items AS I INNER JOIN Taxation AS T ON I.TaxID = T.Id Where I.ID='" & Val(.Cells(0).Value) & "'")
                Dim TaxName As String = clsFun.ExecScalarStr("SELECT T.TaxName as TaxName  FROM Items AS I INNER JOIN Taxation AS T ON I.TaxID = T.Id Where I.ID='" & Val(.Cells(0).Value) & "'")
                Dim RCM As String = "N" ' clsFun.ExecScalarStr("SELECT RCM From Items Where ID='" & Val(.Cells(0).Value) & "'")
                If RCM = "Yes" Then RCM = "Y" Else RCM = "N"
                FastQuery = FastQuery & IIf(FastQuery <> "", " UNION ALL SELECT ", " SELECT ") & Val(txtID.Text) & ",'" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "','" & Me.Text & "', '" & txtVoucherNo.Text & "','" & Val(txtAccountID.Text) & "','" & AccountName & "'," & _
                     "'" & IIf(i = 0, Val(txtTotTotal.Text), 0) & "','" & IIf(i = 0, Val(txtTotTaxable.Text), 0) & "','" & If(i = 0, Val(txtTotTaxAmt.Text), 0) & "','" & If(i = 0, Val(TotalIGST), 0) & "','" & If(i = 0, Val(TotalCGST), 0) & "','" & If(i = 0, Val(TotalSGST), 0) & "','" & If(i = 0, Val(TotalCess), 0) & "'," & _
                     "'" & Val(.Cells(0).Value) & "','" & ItemName & "','" & Val(Qty) & "','" & HSnCode & "','" & If(SupplyType = "Goods", GSTUNit, "NA") & "','" & Val(.Cells(19).Value) & "','" & Val(itemTaxableAmt) & "', '" & Val(TaxID) & "','" & TaxName & "'," & _
                     "'" & Val(.Cells(17).Value) & "','" & Val(.Cells(18).Value) & "','" & .Cells(40).Value & "','" & .Cells(41).Value & "','" & .Cells(42).Value & "','" & .Cells(43).Value & "', " & _
                     "'" & .Cells(44).Value & "','" & .Cells(45).Value & "','" & Val(0) & "','" & Val(.Cells(49).Value) & "','" & SupplyType & "','" & GSTType & "','" & GSTIN & "','" & State & "','" & StateCode & "','" & Val(txtTotTaxAmt.Text) & "','" & Val(txtTotTaxable.Text) & "','" & Val(txtTotTotal.Text) & "','" & RCM & "'"
                i = i + 1
            End With
        Next
        Try
            Sql = "insert into TaxDetails(VoucherID,EntryDate,TransType,BillNo,AccountID,AccountName,TotalAmount,TotalTaxable,TotalTax,TotalIGSTAmt,TotalCGSTAmt,TotalSGSTAmt,TotalCessAmt," & _
                  "ItemID,ItemName,Qty,HSNCode,UQC,TotalAmt,TaxableAmt,TaxID,TaxName,TaxPer,TaxAmt,IGSTPer,IGSTAmt,CGSTPer,CGSTAmt,SGSTPer,SGSTAmt,CessPer,CessAmt,EntryType,GSTType,GSTIN,StateName,StateCode,GSTAmt,Taxable,Total,RCM)" & FastQuery & ""
            If FastQuery = String.Empty Then Exit Sub
            clsFun.ExecNonQuery(Sql)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        FastQuery = String.Empty
        Sql = String.Empty

        For Each row As DataGridViewRow In Dg2.Rows
            With row
                Dim ChargeName As String = clsFun.ExecScalarStr(" Select ChargeName FROM Charges WHERE ID='" & Val(.Cells(5).Value) & "'")
                Dim HSnCode As String = clsFun.ExecScalarStr("SELECT HSnCode From Charges Where ID='" & Val(.Cells(5).Value) & "'")
                Dim SupplyType As String = clsFun.ExecScalarStr("SELECT SupplyType From Charges Where ID='" & Val(.Cells(5).Value) & "'")
                Dim GSTUNit As String = "OTH-OTHERS" : Dim Qty As Decimal = 0
                Dim totamt As Decimal = Val(.Cells(4).Value) + Val(.Cells(10).Value) + Val(.Cells(7).Value)
                Dim TaxID As Integer = clsFun.ExecScalarInt("SELECT T.ID as TaxID  FROM Charges AS C INNER JOIN Taxation AS T ON C.TaxID = T.Id Where C.ID='" & Val(.Cells(5).Value) & "'")
                Dim TaxName As String = clsFun.ExecScalarStr("SELECT T.TaxName as TaxName  FROM Charges AS C INNER JOIN Taxation AS T ON C.TaxID = T.Id Where C.ID='" & Val(.Cells(5).Value) & "'")
                Dim FixAs As String = clsFun.ExecScalarStr(" Select FixAs FROM Charges WHERE ID='" & Val(.Cells(5).Value) & "'")
                '  Dim RCM As String = clsFun.ExecScalarStr("SELECT RCM From Items Where ID='" & Val(.Cells(0).Value) & "'")
                If TaxID <> 0 Then
                    If .Cells(3).Value = "+" Then
                        FastQuery = FastQuery & IIf(FastQuery <> "", " UNION ALL SELECT ", " SELECT ") & Val(txtID.Text) & ",'" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "','" & Me.Text & "', '" & txtVoucherNo.Text & "','" & Val(txtAccountID.Text) & "','" & AccountName & "'," & _
                     "'" & Val(0) & "','" & Val(0) & "','" & Val(0) & "','" & Val(0) & "','" & Val(0) & "','" & Val(0) & "','" & Val(0) & "'," & _
                     "'" & Val(.Cells(5).Value) & "','" & ChargeName & "','" & Val(Qty) & "','" & HSnCode & "','" & If(SupplyType = "Goods", GSTUNit, "NA") & "','" & Val(Val(.Cells(10).Value) + Val(.Cells(7).Value)) & "','" & Val(.Cells(10).Value) & "', '" & Val(TaxID) & "','" & TaxName & "'," & _
                     "'" & Val(.Cells(6).Value) & "' ,'" & IIf(TaxID = 0, 0, (Val(.Cells(7).Value))) & "'," & _
                     "'" & IIf(TaxID = 0, 0, (IIf(lblRegion.Text = "Local", 0, Val(.Cells(6).Value)))) & "','" & IIf(TaxID = 0, 0, (IIf(lblRegion.Text = "Local", 0, Val(.Cells(7).Value)))) & "', " & _
                     "'" & IIf(TaxID = 0, 0, (IIf(lblRegion.Text = "Local", Val(.Cells(6).Value) / 2, 0))) & "','" & IIf(TaxID = 0, 0, (IIf(lblRegion.Text = "Local", Val(.Cells(7).Value) / 2, 0))) & "', " & _
                     "'" & IIf(TaxID = 0, 0, (IIf(lblRegion.Text = "Local", Val(.Cells(6).Value) / 2, 0))) & "','" & IIf(TaxID = 0, 0, (IIf(lblRegion.Text = "Local", Val(.Cells(7).Value) / 2, 0))) & "', " & _
                     "'" & Val(0) & "','" & Val(0) & "','" & SupplyType & "','" & GSTType & "','" & GSTIN & "','" & State & "','" & StateCode & "','" & Val(txtTotTaxAmt.Text) & "','" & Val(txtTotTaxable.Text) & "','" & Val(txtTotTotal.Text) & "'"
                    Else
                        FastQuery = FastQuery & IIf(FastQuery <> "", " UNION ALL SELECT ", " SELECT ") & Val(txtID.Text) & ",'" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "','" & Me.Text & "', '" & txtVoucherNo.Text & "','" & Val(txtAccountID.Text) & "','" & AccountName & "'," & _
                        "'" & Val(0) & "','" & Val(0) & "','" & Val(0) & "','" & Val(0) & "','" & Val(0) & "','" & Val(0) & "','" & Val(0) & "'," & _
                   "'" & Val(.Cells(5).Value) & "','" & ChargeName & "','" & Val(Qty) & "','" & HSnCode & "','" & If(SupplyType = "Goods", GSTUNit, "NA") & "','" & -Val(Val(.Cells(10).Value) + Val(.Cells(7).Value)) & "','" & -Val(.Cells(10).Value) & "', '" & Val(TaxID) & "','" & TaxName & "'," & _
                   "'" & Val(.Cells(6).Value) & "' ,'" & IIf(TaxID = 0, 0, -(Val(.Cells(7).Value))) & "'," & _
                   "'" & IIf(TaxID = 0, 0, (IIf(lblRegion.Text = "Local", 0, Val(.Cells(6).Value)))) & "','" & IIf(TaxID = 0, 0, (IIf(lblRegion.Text = "Local", 0, -Val(.Cells(7).Value)))) & "', " & _
                   "'" & IIf(TaxID = 0, 0, (IIf(lblRegion.Text = "Local", Val(.Cells(6).Value) / 2, 0))) & "','" & IIf(TaxID = 0, 0, (IIf(lblRegion.Text = "Local", -Val(.Cells(7).Value) / 2, 0))) & "', " & _
                   "'" & IIf(TaxID = 0, 0, (IIf(lblRegion.Text = "Local", Val(.Cells(6).Value) / 2, 0))) & "','" & IIf(TaxID = 0, 0, (IIf(lblRegion.Text = "Local", -Val(.Cells(7).Value) / 2, 0))) & "', " & _
                   "'" & Val(0) & "','" & Val(0) & "','" & SupplyType & "','" & GSTType & "','" & GSTIN & "','" & State & "','" & StateCode & "','" & Val(txtTotTaxAmt.Text) & "','" & Val(txtTotTaxable.Text) & "','" & Val(txtTotTotal.Text) & "'"
                    End If
                End If
            End With
        Next
        Try
            Sql = "insert into TaxDetails(VoucherID,EntryDate,TransType,BillNo,AccountID,AccountName,TotalAmount,TotalTaxable,TotalTax,TotalIGSTAmt,TotalCGSTAmt,TotalSGSTAmt,TotalCessAmt," & _
                  "ItemID,ItemName,Qty,HSNCode,UQC,TotalAmt,TaxableAmt,TaxID,TaxName,TaxPer,TaxAmt,IGSTPer,IGSTAmt,CGSTPer,CGSTAmt,SGSTPer,SGSTAmt,CessPer,CessAmt,EntryType,GSTType,GSTIN,StateName,StateCode,GstAmt,Taxable,Total)" & FastQuery & ""
            If FastQuery = String.Empty Then Exit Sub
            clsFun.ExecNonQuery(Sql)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub dg2Record()
        Dim FastQuery As String = String.Empty
        Dim Sql As String = String.Empty
        For Each row As DataGridViewRow In Dg2.Rows
            With row
                Dim TaxID As Integer = clsFun.ExecScalarInt("SELECT T.ID as TaxID  FROM Charges AS C INNER JOIN Taxation AS T ON C.TaxID = T.Id Where C.ID='" & Val(.Cells(5).Value) & "'")
                Dim TaxName As String = clsFun.ExecScalarStr("SELECT T.TaxName as TaxName  FROM Charges AS C INNER JOIN Taxation AS T ON C.TaxID = T.Id Where C.ID='" & Val(.Cells(5).Value) & "'")
                Dim FixAs As String = clsFun.ExecScalarStr(" Select FixAs FROM Charges WHERE ID='" & Val(Dg2.Rows(i).Cells(5).Value) & "'")
                Dim taxableCharges As Decimal = Format(Val(.Cells(4).Value) + Val(.Cells(11).Value), Hash)
                If .Cells(3).Value = "+" Then
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
                ElseIf .Cells(3).Value = "-" Then
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
    Public Sub FillControl(ByVal id As Integer)
        pnlWait.Visible = True
        Application.DoEvents()
        Dim sSql As String = String.Empty
        Dim sql As String = String.Empty
        BtnDelete.Enabled = True
        BtnSave.BackColor = Color.DeepSkyBlue
        '   BtnSave.Image = My.Resources.EditItem
        BtnSave.Text = "&Update"
        clsFun.FillDropDownList(cbState, "Select ID,StateName From StateList", "StateName", "Id", "")
        sSql = "Select * from Vouchers where id=" & id
        Dim ad As New SQLite.SQLiteDataAdapter(sSql, clsFun.GetConnection)
        Dim ds As New DataSet
        ad.Fill(ds, "a")
        If ds.Tables("a").Rows.Count > 0 Then
            txtCdPer.Text = IIf(Val(ds.Tables("a").Rows(0)("CdPer").ToString()) = 0, "", Val(ds.Tables("a").Rows(0)("CdPer").ToString()))
            txtVoucherNo.Text = ds.Tables("a").Rows(0)("InvoiceNo").ToString()
            txtInvoiceID.Text = Val(ds.Tables("a").Rows(0)("InvoiceID").ToString())
            mskEntryDate.Text = Format(ds.Tables("a").Rows(0)("EntryDate"), "dd-MM-yyyy")
            lblTotQty.Text = Val(ds.Tables("a").Rows(0)("TotQty").ToString())
            cbSeries.SelectedValue = Val(ds.Tables("a").Rows(0)("SeriesID").ToString())
            cbSeries.Text = ds.Tables("a").Rows(0)("SeriesName").ToString()
            txtAccountID.Text = Val(ds.Tables("a").Rows(0)("AccountID").ToString())
            txtAccount.Text = ds.Tables("a").Rows(0)("AccountName").ToString()
            txtTotNetAmt.Text = Format(Val(ds.Tables("a").Rows(0)("TotalBasicAmt").ToString()), Hash)
            txtTotDisAmt.Text = Format(Val(ds.Tables("a").Rows(0)("TotalDiscAmt").ToString()), Hash)
            txtTotTaxAmt.Text = Format(Val(ds.Tables("a").Rows(0)("TotalTaxAmt").ToString()), Hash)
            txtBeforeCharges.Text = Format(Val(ds.Tables("a").Rows(0)("CdAmount").ToString()), Hash)
            txtTotTaxable.Text = Format(Val(ds.Tables("a").Rows(0)("TotalTaxableAmt").ToString()), Hash)
            txtAfterCharges.Text = Format(Val(ds.Tables("a").Rows(0)("AfterCharges").ToString()), Hash)
            txttotRoundoff.Text = Format(Val(ds.Tables("a").Rows(0)("RoundOff").ToString()), Hash)
            txtTotTotal.Text = Format(Val(ds.Tables("a").Rows(0)("TotalGrandAmt").ToString()), Hash)
            txtTotCashAmt.Text = Format(Val(ds.Tables("a").Rows(0)("TotalCashAmt").ToString()), Hash)
            txtTotDueamt.Text = Format(Val(ds.Tables("a").Rows(0)("TotalBalAmt").ToString()), Hash)
            txtCustomerName.Text = ds.Tables("a").Rows(0)("CustomerName").ToString()
            txtFullAddress.Text = ds.Tables("a").Rows(0)("CustomerAddress").ToString()
            txtMobileNo.Text = ds.Tables("a").Rows(0)("CustomerMobile").ToString()
            txtGSTN.Text = ds.Tables("a").Rows(0)("CustomerGSTN").ToString()
            cbState.Text = ds.Tables("a").Rows(0)("StateName").ToString()
            txtStateCode.Text = ds.Tables("a").Rows(0)("StateCode").ToString()
            cbGSTtype.Text = ds.Tables("a").Rows(0)("GSTType").ToString()
            txtID.Text = (ds.Tables("a").Rows(0)("ID").ToString())
        End If
        autoGSTPick()
        sSql = "Select * from Trans where VoucherID=" & Val(txtID.Text)
        Dim ad1 As New SQLite.SQLiteDataAdapter(sSql, clsFun.GetConnection)
        Dim ds1 As New DataSet
        ad1.Fill(ds1, "b")
        If ds1.Tables("b").Rows.Count > 0 Then
            If ds1.Tables("b").Rows.Count > 8 Then dg1.Columns(19).Width = 132 Else dg1.Columns(19).Width = 145
            dg1.Rows.Clear()
            With dg1
                pb1.Minimum = 0
                Dim i As Integer = 0
                For i = 0 To ds1.Tables("b").Rows.Count - 1
                    '   Application.DoEvents()
                    pb1.Maximum = ds1.Tables("b").Rows.Count - 1
                    pb1.Value = i
                    .Rows.Add()
                    .Rows(i).Cells(0).Value = ds1.Tables("b").Rows(i)("ItemID").ToString()
                    .Rows(i).Cells(1).Value = ds1.Tables("b").Rows(i)("ItemName").ToString()
                    .Rows(i).Cells(2).Value = ds1.Tables("b").Rows(i)("HSNCode").ToString()
                    .Rows(i).Cells(3).Value = ds1.Tables("b").Rows(i)("Pack").ToString()
                    .Rows(i).Cells(4).Value = ds1.Tables("b").Rows(i)("ItemCode").ToString()
                    .Rows(i).Cells(5).Value = ds1.Tables("b").Rows(i)("BatchID").ToString()
                    .Rows(i).Cells(6).Value = ds1.Tables("b").Rows(i)("Batch").ToString()
                    .Rows(i).Cells(7).Value = ds1.Tables("b").Rows(i)("UnitID").ToString()
                    .Rows(i).Cells(8).Value = ds1.Tables("b").Rows(i)("UnitName").ToString()
                    .Rows(i).Cells(9).Value = ds1.Tables("b").Rows(i)("MainQty").ToString()
                    .Rows(i).Cells(10).Value = Format(Val(ds1.Tables("b").Rows(i)("Qty").ToString()), Hash)
                    .Rows(i).Cells(11).Value = Format(Val(ds1.Tables("b").Rows(i)("AltQty").ToString()), Hash)
                    .Rows(i).Cells(12).Value = Format(Val(ds1.Tables("b").Rows(i)("FreeQty").ToString()), Hash)
                    .Rows(i).Cells(13).Value = Format(Val(ds1.Tables("b").Rows(i)("Rate").ToString()), Hash)
                    .Rows(i).Cells(14).Value = Format(Val(ds1.Tables("b").Rows(i)("basicAmt").ToString()), Hash)
                    .Rows(i).Cells(15).Value = Format(Val(ds1.Tables("b").Rows(i)("DisPer").ToString()), Hash)
                    .Rows(i).Cells(16).Value = Format(Val(ds1.Tables("b").Rows(i)("DisAmt").ToString()), Hash)
                    .Rows(i).Cells(17).Value = Format(Val(ds1.Tables("b").Rows(i)("TaxPer").ToString()), Hash)
                    .Rows(i).Cells(18).Value = Format(Val(ds1.Tables("b").Rows(i)("TaxAmt").ToString()), Hash)
                    .Rows(i).Cells(19).Value = Format(Val(ds1.Tables("b").Rows(i)("TotalAmt").ToString()), Hash)
                    .Rows(i).Cells(66).Value = Format(Val(ds1.Tables("b").Rows(i)("ApprValue").ToString()), Hash)
                    .Rows(i).Cells(20).Value = Format(Val(ds1.Tables("b").Rows(i)("NetRate").ToString()), Hash)
                    .Rows(i).Cells(21).Value = ds1.Tables("b").Rows(i)("DisName1").ToString()
                    .Rows(i).Cells(22).Value = Format(Val(ds1.Tables("b").Rows(i)("DisOnValue1").ToString()), Hash)
                    .Rows(i).Cells(23).Value = Format(Val(ds1.Tables("b").Rows(i)("DisAmt1").ToString()), Hash)
                    .Rows(i).Cells(24).Value = ds1.Tables("b").Rows(i)("DisName2").ToString()
                    .Rows(i).Cells(25).Value = Format(Val(ds1.Tables("b").Rows(i)("DisOnValue2").ToString()), Hash)
                    .Rows(i).Cells(26).Value = Format(Val(ds1.Tables("b").Rows(i)("DisAmt2").ToString()), Hash)
                    .Rows(i).Cells(27).Value = ds1.Tables("b").Rows(i)("DisName3").ToString()
                    .Rows(i).Cells(28).Value = Format(Val(ds1.Tables("b").Rows(i)("DisOnValue3").ToString()), Hash)
                    .Rows(i).Cells(29).Value = Format(Val(ds1.Tables("b").Rows(i)("DisAmt3").ToString()), Hash)
                    .Rows(i).Cells(30).Value = ds1.Tables("b").Rows(i)("DisName4").ToString()
                    .Rows(i).Cells(31).Value = Format(Val(ds1.Tables("b").Rows(i)("DisOnValue4").ToString()), Hash)
                    .Rows(i).Cells(32).Value = Format(Val(ds1.Tables("b").Rows(i)("DisAmt4").ToString()), Hash)
                    .Rows(i).Cells(33).Value = Format(Val(ds1.Tables("b").Rows(i)("TotDiscAmt").ToString()), Hash)
                    .Rows(i).Cells(30).Value = ds1.Tables("b").Rows(i)("DisName4").ToString()
                    .Rows(i).Cells(34).Value = Val(ds1.Tables("b").Rows(i)("SerialID").ToString())
                    .Rows(i).Cells(35).Value = Val(ds1.Tables("b").Rows(i)("CDAmt").ToString())
                    .Rows(i).Cells(36).Value = Val(ds1.Tables("b").Rows(i)("DisCal1").ToString())
                    .Rows(i).Cells(37).Value = Val(ds1.Tables("b").Rows(i)("DisCal2").ToString())
                    .Rows(i).Cells(38).Value = Val(ds1.Tables("b").Rows(i)("DisCal3").ToString())
                    .Rows(i).Cells(39).Value = Val(ds1.Tables("b").Rows(i)("DisCal4").ToString())
                    .Rows(i).Cells(40).Value = Val(ds1.Tables("b").Rows(i)("IGSTPer").ToString())
                    .Rows(i).Cells(41).Value = Val(ds1.Tables("b").Rows(i)("IGSTAmt").ToString())
                    .Rows(i).Cells(42).Value = Val(ds1.Tables("b").Rows(i)("SGSTPer").ToString())
                    .Rows(i).Cells(43).Value = Val(ds1.Tables("b").Rows(i)("SGSTAmt").ToString())
                    .Rows(i).Cells(44).Value = Val(ds1.Tables("b").Rows(i)("CGSTPer").ToString())
                    .Rows(i).Cells(45).Value = Val(ds1.Tables("b").Rows(i)("CGSTAmt").ToString())

                    .Rows(i).Cells(46).Value = ds1.Tables("b").Rows(i)("Field1").ToString()
                    .Rows(i).Cells(47).Value = ds1.Tables("b").Rows(i)("Field2").ToString()
                    .Rows(i).Cells(48).Value = ds1.Tables("b").Rows(i)("Field3").ToString()
                    .Rows(i).Cells(49).Value = ds1.Tables("b").Rows(i)("Field4").ToString()
                    .Rows(i).Cells(50).Value = ds1.Tables("b").Rows(i)("Field5").ToString()
                    .Rows(i).Cells(51).Value = ds1.Tables("b").Rows(i)("Field6").ToString()
                    .Rows(i).Cells(52).Value = ds1.Tables("b").Rows(i)("Field7").ToString()
                    .Rows(i).Cells(53).Value = ds1.Tables("b").Rows(i)("Field8").ToString()
                    .Rows(i).Cells(54).Value = ds1.Tables("b").Rows(i)("Field9").ToString()
                    .Rows(i).Cells(55).Value = ds1.Tables("b").Rows(i)("Field10").ToString()
                Next
            End With
        End If
        lblRecordCount.Text = dg1.Rows.Count
        pnlWait.Visible = False
        sql = "Select * from ChargesTrans where VoucherID=" & Val(txtID.Text)
        Dim ad2 As New SQLite.SQLiteDataAdapter(sql, clsFun.GetConnection)
        Dim ds2 As New DataSet
        ad2.Fill(ds2, "D")
        If ds2.Tables("D").Rows.Count > 0 Then
            Dg2.Rows.Clear()
            If ds2.Tables("D").Rows.Count > 4 Then Dg2.Columns(4).Width = 95 Else Dg2.Columns(4).Width = 114
            Dg2.Rows.Clear()
            With Dg2
                Dim i As Integer = 0
                For i = 0 To ds2.Tables("D").Rows.Count - 1
                    .Rows.Add()
                    .Rows(i).Cells("Charge Name").Value = ds2.Tables("D").Rows(i)("ChargeName").ToString()
                    If Val(ds2.Tables("D").Rows(i)("OnValue").ToString()) > 0 Then
                        .Rows(i).Cells("On Value").Value = Format(Val(ds2.Tables("D").Rows(i)("OnValue").ToString()), Hash)
                    End If
                    .Rows(i).Cells("Cal").Value = Format(Val(ds2.Tables("D").Rows(i)("Calculate").ToString()), Hash)
                    .Rows(i).Cells("+/-").Value = ds2.Tables("D").Rows(i)("ChargeType").ToString()
                    .Rows(i).Cells("Amount").Value = Format(Val(ds2.Tables("D").Rows(i)("Amount").ToString()), Hash)
                    .Rows(i).Cells("ChargeID").Value = ds2.Tables("D").Rows(i)("ChargesID").ToString()
                    .Rows(i).Cells(6).Value = Format(Math.Abs(Val(ds2.Tables("D").Rows(i)("TaxPer").ToString())), Hash)
                    .Rows(i).Cells(7).Value = Format(Math.Abs(Val(ds2.Tables("D").Rows(i)("TaxAmt").ToString())), Hash)
                    .Rows(i).Cells(8).Value = Format(Math.Abs(Val(ds2.Tables("D").Rows(i)("CessPer").ToString())), Hash)
                    .Rows(i).Cells(9).Value = Format(Math.Abs(Val(ds2.Tables("D").Rows(i)("CessAmt").ToString())), Hash)
                    .Rows(i).Cells(10).Value = Format(Math.Abs(Val(ds2.Tables("D").Rows(i)("TaxableAmt").ToString())), Hash)

                Next
            End With
            'txtItemID.Text = IID
        End If

        'sql = "Select * from Serials where VoucherID=" & Val(txtID.Text)
        'Dim ad3 As New SQLite.SQLiteDataAdapter(sql, clsFun.GetConnection)
        'Dim ds3 As New DataSet
        'ad3.Fill(ds3, "D")
        'If ds3.Tables("D").Rows.Count > 0 Then
        '    dgSerial.Rows.Clear()
        '    ' If ds3.Tables("D").Rows.Count > 4 Then dgSerial.Columns(4).Width = 95 Else dgSerial.Columns(4).Width = 114
        '    dgSerial.Rows.Clear()
        '    With dgSerial
        '        Dim i As Integer = 0
        '        For i = 0 To ds3.Tables("D").Rows.Count - 1
        '            .Rows.Add()
        '            .Rows(i).Cells(0).Value = ds3.Tables("D").Rows(i)("ItemID").ToString()
        '            .Rows(i).Cells(1).Value = ds3.Tables("D").Rows(i)("SerialID").ToString()
        '            .Rows(i).Cells(2).Value = ds3.Tables("D").Rows(i)("SerialNo1").ToString()
        '            .Rows(i).Cells(3).Value = ds3.Tables("D").Rows(i)("SerialNo2").ToString()
        '            .Rows(i).Cells(4).Value = ds3.Tables("D").Rows(i)("SerialNo3").ToString()
        '            .Rows(i).Cells(5).Value = ds3.Tables("D").Rows(i)("SerialNo4").ToString()
        '            .Rows(i).Cells(6).Value = ds3.Tables("D").Rows(i)("SerialNo5").ToString()

        '        Next
        '    End With
        '    'txtItemID.Text = IID
        'End If
        UNRegSupplies = clsFun.ExecScalarStr("Select GSTType From Accounts Where ID='" & Val(txtAccountID.Text) & "'")
        If (UNRegSupplies = "GST Registered" Or UNRegSupplies = "Composition") Or (cbGSTtype.Text = "GST Registered" Or cbGSTtype.Text = "Composition") Then
            calc()
        Else
            calc2()
        End If
        dg1.ClearSelection() : Dg2.ClearSelection() : dgSerial.ClearSelection()
    End Sub



    Public Sub FillWithNevigation()
        pnlWait.Visible = True
        Application.DoEvents()
        Dim sSql As String = String.Empty
        Dim sql As String = String.Empty
        BtnDelete.Enabled = True
        BtnSave.BackColor = Color.DeepSkyBlue
        '  BtnSave.Image = My.Resources.EditItem
        BtnSave.Text = "&Update"
        Dim recordsCount As Integer = clsFun.ExecScalarInt("Select Count(*) FROM Vouchers Where transtype = 'Purchase'  Order By ID ")
        TotalPages = Math.Ceiling(recordsCount / RowCount)
        'Offset = (TotalPages - 1) * RowCount

        clsFun.FillDropDownList(cbState, "Select ID,StateName From StateList", "StateName", "Id", "")
        sSql = "Select * from Vouchers Where transtype = 'Purchase'  Order By ID  LIMIT " + RowCount.ToString() + " OFFSET " + Offset.ToString() + ""
        Dim ad As New SQLite.SQLiteDataAdapter(sSql, clsFun.GetConnection)
        Dim ds As New DataSet
        ad.Fill(ds, "a")
        If ds.Tables("a").Rows.Count > 0 Then
            txtCdPer.Text = IIf(Val(ds.Tables("a").Rows(0)("CdPer").ToString()) = 0, "", Val(ds.Tables("a").Rows(0)("CdPer").ToString()))
            txtVoucherNo.Text = ds.Tables("a").Rows(0)("BillNo").ToString()
            txtInvoiceID.Text = Val(ds.Tables("a").Rows(0)("InvoiceID").ToString())
            mskEntryDate.Text = Format(ds.Tables("a").Rows(0)("EntryDate"), "dd-MM-yyyy")
            lblTotQty.Text = Val(ds.Tables("a").Rows(0)("TotQty").ToString())
            cbSeries.SelectedValue = Val(ds.Tables("a").Rows(0)("SeriesID").ToString())
            cbSeries.Text = ds.Tables("a").Rows(0)("SeriesName").ToString()
            txtAccountID.Text = Val(ds.Tables("a").Rows(0)("AccountID").ToString())
            txtAccount.Text = ds.Tables("a").Rows(0)("AccountName").ToString()
            txtTotNetAmt.Text = Format(Val(ds.Tables("a").Rows(0)("BasicAmount").ToString()), Hash)
            txtTotDisAmt.Text = Format(Val(ds.Tables("a").Rows(0)("DiscountAmount").ToString()), Hash)
            txtTotTaxAmt.Text = Format(Val(ds.Tables("a").Rows(0)("GSTAmt").ToString()), Hash)
            txtBeforeCharges.Text = Format(Val(ds.Tables("a").Rows(0)("CDAmount").ToString()), Hash)
            txtTotTaxable.Text = Format(Val(ds.Tables("a").Rows(0)("TaxableAmount").ToString()), Hash)
            txtAfterCharges.Text = Format(Val(ds.Tables("a").Rows(0)("AfterCharges").ToString()), Hash)
            txttotRoundoff.Text = Format(Val(ds.Tables("a").Rows(0)("RoundOff").ToString()), Hash)
            txtTotTotal.Text = Format(Val(ds.Tables("a").Rows(0)("TotalAmount").ToString()), Hash)
            txtTotCashAmt.Text = Format(Val(ds.Tables("a").Rows(0)("TotalCashAmount").ToString()), Hash)
            txtTotDueamt.Text = Format(Val(ds.Tables("a").Rows(0)("TotalDueAmount").ToString()), Hash)
            txtCustomerName.Text = ds.Tables("a").Rows(0)("T1").ToString()
            txtFullAddress.Text = ds.Tables("a").Rows(0)("T2").ToString()
            txtMobileNo.Text = ds.Tables("a").Rows(0)("T3").ToString()
            txtGSTN.Text = ds.Tables("a").Rows(0)("T4").ToString()
            cbState.Text = ds.Tables("a").Rows(0)("T5").ToString()
            txtStateCode.Text = ds.Tables("a").Rows(0)("T6").ToString()
            cbGSTtype.Text = ds.Tables("a").Rows(0)("T7").ToString()
            txtID.Text = (ds.Tables("a").Rows(0)("ID").ToString())
        End If
        autoGSTPick()
        sSql = "Select * from Trans1 where VoucherID=" & Val(txtID.Text)
        Dim ad1 As New SQLite.SQLiteDataAdapter(sSql, clsFun.GetConnection)
        Dim ds1 As New DataSet
        ad1.Fill(ds1, "b")
        If ds1.Tables("b").Rows.Count > 0 Then
            If ds1.Tables("b").Rows.Count > 8 Then dg1.Columns(19).Width = 132 Else dg1.Columns(19).Width = 145
            dg1.Rows.Clear()
            With dg1
                pb1.Minimum = 0
                Dim i As Integer = 0
                For i = 0 To ds1.Tables("b").Rows.Count - 1
                    '   Application.DoEvents()
                    pb1.Maximum = ds1.Tables("b").Rows.Count - 1
                    pb1.Value = i
                    .Rows.Add()
                    .Rows(i).Cells(0).Value = ds1.Tables("b").Rows(i)("ItemID").ToString()
                    .Rows(i).Cells(1).Value = ds1.Tables("b").Rows(i)("ItemName").ToString()
                    .Rows(i).Cells(2).Value = ds1.Tables("b").Rows(i)("HSNCode").ToString()
                    .Rows(i).Cells(3).Value = ds1.Tables("b").Rows(i)("Pack").ToString()
                    .Rows(i).Cells(4).Value = ds1.Tables("b").Rows(i)("ItemCode").ToString()
                    .Rows(i).Cells(5).Value = ds1.Tables("b").Rows(i)("BatchID").ToString()
                    .Rows(i).Cells(6).Value = ds1.Tables("b").Rows(i)("BatchNo").ToString()
                    .Rows(i).Cells(7).Value = ds1.Tables("b").Rows(i)("UnitID").ToString()
                    .Rows(i).Cells(8).Value = ds1.Tables("b").Rows(i)("UnitName").ToString()
                    .Rows(i).Cells(9).Value = ds1.Tables("b").Rows(i)("MainQty").ToString()
                    .Rows(i).Cells(10).Value = Format(Val(ds1.Tables("b").Rows(i)("Qty").ToString()), Hash)
                    .Rows(i).Cells(11).Value = Format(Val(ds1.Tables("b").Rows(i)("AltQty").ToString()), Hash)
                    .Rows(i).Cells(12).Value = Format(Val(ds1.Tables("b").Rows(i)("FreeQty").ToString()), Hash)
                    .Rows(i).Cells(13).Value = Format(Val(ds1.Tables("b").Rows(i)("Rate").ToString()), Hash)
                    .Rows(i).Cells(14).Value = Format(Val(ds1.Tables("b").Rows(i)("basicAmount").ToString()), Hash)
                    .Rows(i).Cells(15).Value = Format(Val(ds1.Tables("b").Rows(i)("DisCPer").ToString()), Hash)
                    .Rows(i).Cells(16).Value = Format(Val(ds1.Tables("b").Rows(i)("DiscAmount").ToString()), Hash)
                    .Rows(i).Cells(17).Value = Format(Val(ds1.Tables("b").Rows(i)("TaxPer").ToString()), Hash)
                    .Rows(i).Cells(18).Value = Format(Val(ds1.Tables("b").Rows(i)("TaxAmount").ToString()), Hash)
                    .Rows(i).Cells(19).Value = Format(Val(ds1.Tables("b").Rows(i)("TotalAmount").ToString()), Hash)
                    .Rows(i).Cells(66).Value = Format(Val(ds1.Tables("b").Rows(i)("ApprValue").ToString()), Hash)
                    .Rows(i).Cells(20).Value = Format(Val(ds1.Tables("b").Rows(i)("NetRate").ToString()), Hash)
                    .Rows(i).Cells(21).Value = ds1.Tables("b").Rows(i)("DisName1").ToString()
                    .Rows(i).Cells(22).Value = Format(Val(ds1.Tables("b").Rows(i)("DisOnValue1").ToString()), Hash)
                    .Rows(i).Cells(23).Value = Format(Val(ds1.Tables("b").Rows(i)("DisAmt1").ToString()), Hash)
                    .Rows(i).Cells(24).Value = ds1.Tables("b").Rows(i)("DisName2").ToString()
                    .Rows(i).Cells(25).Value = Format(Val(ds1.Tables("b").Rows(i)("DisOnValue2").ToString()), Hash)
                    .Rows(i).Cells(26).Value = Format(Val(ds1.Tables("b").Rows(i)("DisAmt2").ToString()), Hash)
                    .Rows(i).Cells(27).Value = ds1.Tables("b").Rows(i)("DisName3").ToString()
                    .Rows(i).Cells(28).Value = Format(Val(ds1.Tables("b").Rows(i)("DisOnValue3").ToString()), Hash)
                    .Rows(i).Cells(29).Value = Format(Val(ds1.Tables("b").Rows(i)("DisAmt3").ToString()), Hash)
                    .Rows(i).Cells(30).Value = ds1.Tables("b").Rows(i)("DisName4").ToString()
                    .Rows(i).Cells(31).Value = Format(Val(ds1.Tables("b").Rows(i)("DisOnValue4").ToString()), Hash)
                    .Rows(i).Cells(32).Value = Format(Val(ds1.Tables("b").Rows(i)("DisAmt4").ToString()), Hash)
                    .Rows(i).Cells(33).Value = Format(Val(ds1.Tables("b").Rows(i)("TotDiscAmt").ToString()), Hash)
                    .Rows(i).Cells(30).Value = ds1.Tables("b").Rows(i)("DisName4").ToString()
                    .Rows(i).Cells(34).Value = Val(ds1.Tables("b").Rows(i)("SerialID").ToString())
                    .Rows(i).Cells(35).Value = Val(ds1.Tables("b").Rows(i)("CDAmt").ToString())
                    .Rows(i).Cells(36).Value = Val(ds1.Tables("b").Rows(i)("DisCal1").ToString())
                    .Rows(i).Cells(37).Value = Val(ds1.Tables("b").Rows(i)("DisCal2").ToString())
                    .Rows(i).Cells(38).Value = Val(ds1.Tables("b").Rows(i)("DisCal3").ToString())
                    .Rows(i).Cells(39).Value = Val(ds1.Tables("b").Rows(i)("DisCal4").ToString())
                    .Rows(i).Cells(40).Value = Val(ds1.Tables("b").Rows(i)("IGSTPer").ToString())
                    .Rows(i).Cells(41).Value = Val(ds1.Tables("b").Rows(i)("IGSTAmt").ToString())
                    .Rows(i).Cells(42).Value = Val(ds1.Tables("b").Rows(i)("SGSTPer").ToString())
                    .Rows(i).Cells(43).Value = Val(ds1.Tables("b").Rows(i)("SGSTAmt").ToString())
                    .Rows(i).Cells(44).Value = Val(ds1.Tables("b").Rows(i)("CGSTPer").ToString())
                    .Rows(i).Cells(45).Value = Val(ds1.Tables("b").Rows(i)("CGSTAmt").ToString())

                    .Rows(i).Cells(46).Value = ds1.Tables("b").Rows(i)("Field1").ToString()
                    .Rows(i).Cells(47).Value = ds1.Tables("b").Rows(i)("Field2").ToString()
                    .Rows(i).Cells(48).Value = ds1.Tables("b").Rows(i)("Field3").ToString()
                    .Rows(i).Cells(49).Value = ds1.Tables("b").Rows(i)("Field4").ToString()
                    .Rows(i).Cells(50).Value = ds1.Tables("b").Rows(i)("Field5").ToString()
                    .Rows(i).Cells(51).Value = ds1.Tables("b").Rows(i)("Field6").ToString()
                    .Rows(i).Cells(52).Value = ds1.Tables("b").Rows(i)("Field7").ToString()
                    .Rows(i).Cells(53).Value = ds1.Tables("b").Rows(i)("Field8").ToString()
                    .Rows(i).Cells(54).Value = ds1.Tables("b").Rows(i)("Field9").ToString()
                    .Rows(i).Cells(55).Value = ds1.Tables("b").Rows(i)("Field10").ToString()
                Next
            End With
        End If
        lblRecordCount.Text = dg1.Rows.Count
        pnlWait.Visible = False
        sql = "Select * from ChargesTrans where VoucherID=" & Val(txtID.Text)
        Dim ad2 As New SQLite.SQLiteDataAdapter(sql, clsFun.GetConnection)
        Dim ds2 As New DataSet
        ad2.Fill(ds2, "D")
        If ds2.Tables("D").Rows.Count > 0 Then
            Dg2.Rows.Clear()
            If ds2.Tables("D").Rows.Count > 4 Then Dg2.Columns(4).Width = 95 Else Dg2.Columns(4).Width = 114
            Dg2.Rows.Clear()
            With Dg2
                Dim i As Integer = 0
                For i = 0 To ds2.Tables("D").Rows.Count - 1
                    .Rows.Add()
                    .Rows(i).Cells("Charge Name").Value = ds2.Tables("D").Rows(i)("ChargeName").ToString()
                    If Val(ds2.Tables("D").Rows(i)("OnValue").ToString()) > 0 Then
                        .Rows(i).Cells("On Value").Value = Format(Val(ds2.Tables("D").Rows(i)("OnValue").ToString()), Hash)
                    End If
                    .Rows(i).Cells("Cal").Value = Format(Val(ds2.Tables("D").Rows(i)("Calculate").ToString()), Hash)
                    .Rows(i).Cells("+/-").Value = ds2.Tables("D").Rows(i)("ChargeType").ToString()
                    .Rows(i).Cells("Amount").Value = Format(Val(ds2.Tables("D").Rows(i)("Amount").ToString()), Hash)
                    .Rows(i).Cells("ChargeID").Value = ds2.Tables("D").Rows(i)("ChargesID").ToString()
                    .Rows(i).Cells(6).Value = Format(Math.Abs(Val(ds2.Tables("D").Rows(i)("TaxPer").ToString())), Hash)
                    .Rows(i).Cells(7).Value = Format(Math.Abs(Val(ds2.Tables("D").Rows(i)("TaxAmt").ToString())), Hash)
                    .Rows(i).Cells(8).Value = Format(Math.Abs(Val(ds2.Tables("D").Rows(i)("CessPer").ToString())), Hash)
                    .Rows(i).Cells(9).Value = Format(Math.Abs(Val(ds2.Tables("D").Rows(i)("CessAmt").ToString())), Hash)
                    .Rows(i).Cells(10).Value = Format(Math.Abs(Val(ds2.Tables("D").Rows(i)("TaxableAmt").ToString())), Hash)

                Next
            End With
            'txtItemID.Text = IID
        End If

        sql = "Select * from Serials where VoucherID=" & Val(txtID.Text)
        Dim ad3 As New SQLite.SQLiteDataAdapter(sql, clsFun.GetConnection)
        Dim ds3 As New DataSet
        ad3.Fill(ds3, "D")
        If ds3.Tables("D").Rows.Count > 0 Then
            dgSerial.Rows.Clear()
            ' If ds3.Tables("D").Rows.Count > 4 Then dgSerial.Columns(4).Width = 95 Else dgSerial.Columns(4).Width = 114
            dgSerial.Rows.Clear()
            With dgSerial
                Dim i As Integer = 0
                For i = 0 To ds3.Tables("D").Rows.Count - 1
                    .Rows.Add()
                    .Rows(i).Cells(0).Value = ds3.Tables("D").Rows(i)("ItemID").ToString()
                    .Rows(i).Cells(1).Value = ds3.Tables("D").Rows(i)("SerialID").ToString()
                    .Rows(i).Cells(2).Value = ds3.Tables("D").Rows(i)("SerialNo1").ToString()
                    .Rows(i).Cells(3).Value = ds3.Tables("D").Rows(i)("SerialNo2").ToString()
                    .Rows(i).Cells(4).Value = ds3.Tables("D").Rows(i)("SerialNo3").ToString()
                    .Rows(i).Cells(5).Value = ds3.Tables("D").Rows(i)("SerialNo4").ToString()
                    .Rows(i).Cells(6).Value = ds3.Tables("D").Rows(i)("SerialNo5").ToString()

                Next
            End With
            'txtItemID.Text = IID
        End If
        UNRegSupplies = clsFun.ExecScalarStr("Select GSTType From Accounts Where ID='" & Val(txtAccountID.Text) & "'")
        If (UNRegSupplies = "GST Registered" Or UNRegSupplies = "Composition") Or (cbGSTtype.Text = "GST Registered" Or cbGSTtype.Text = "Composition") Then
            calc()
        Else
            calc2()
        End If
        dg1.ClearSelection() : Dg2.ClearSelection() : dgSerial.ClearSelection()
    End Sub
    Private Sub ItemBalance()
        Dim PurchaseBal As String = "" : Dim StockBal As String = ""
        Dim RestBal As String = "" : Dim tmpbal As String = ""
        Dim dt As New DataTable
        Dim sql As String = "SELECT (ifnull(Sum(OpStockMain),0)+(Select ifnull(Sum(Qty),0) from Trans1 Where ItemID=I.ID and TransType in('Purchase','Credit Note') and EntryDate<='" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "'))" & _
             "-(Select ifnull(Sum(Qty),0) from Trans1 Where ItemID=I.ID and TransType in('Sale','Debit Note') and EntryDate<='" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "') as RestQty FROM Items AS I Inner JOIN Batch AS B ON B.ItemID=I.ID Where I.ID=" & Val(txtItemID.Text) & ""
        RestBal = clsFun.ExecScalarStr(sql)
        If BtnSave.Text = "&Save" Then
            If dg1.SelectedRows.Count = 0 Then
                If Val(StockBal) = 0 Then ' if no record inserted
                    If dg1.RowCount = 0 Then ' if no rows addred
                        bal = (RestBal)
                    Else 'if rows count
                        For i As Integer = 0 To dg1.RowCount - 1
                            If dg1.Rows(i).Cells(0).Value = txtItemID.Text Then
                                tmpbal = Val(tmpbal) + Val(dg1.Rows(i).Cells(9).Value)
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
                                tmpbal = Val(tmpbal) + Val(dg1.Rows(i).Cells(9).Value)
                            End If
                        Next i
                        bal = Val(RestBal) - Val(tmpbal)
                    End If
                End If
            Else
                If Val(RestBal) = 0 Then
                    For i As Integer = 0 To dg1.RowCount - 1
                        If dg1.Rows(i).Cells(0).Value = txtItemID.Text Then
                            tmpbal = Val(tmpbal) + Val(dg1.Rows(i).Cells(9).Value)
                        End If
                    Next i
                    tmpbal = Val(RestBal) + Val(tmpbal)
                    tmpbal = Val(tmpbal) + Val(dg1.SelectedRows(0).Cells(9).Value)
                    bal = Val(tmpbal)
                Else
                    For i As Integer = 0 To dg1.RowCount - 1
                        If dg1.Rows(i).Cells(0).Value = txtItemID.Text Then
                            tmpbal = Val(tmpbal) + Val(dg1.Rows(i).Cells(9).Value)
                        End If
                    Next i
                    tmpbal = Val(RestBal) + Val(tmpbal)
                    tmpbal = (tmpbal) - Val(dg1.SelectedRows(0).Cells(9).Value)
                    bal = Val(tmpbal)
                End If
            End If
        Else '''''''''''''''''''''''''''''for Update Stock--------------------------------------
            If dg1.RowCount = 0 Then ' if no rows addred
                bal = (RestBal)
            Else 'if rows count
                UpdateTmp = clsFun.ExecScalarInt("Select ifnull(Sum(Qty),0) from Trans1 Where  ItemID = " & Val(txtItemID.Text) & " AND VoucherID  in ('" & Val(txtID.Text) & "')")
                If dg1.SelectedRows.Count = 0 Then
                    For i As Integer = 0 To dg1.RowCount - 1
                        If dg1.Rows(i).Cells(0).Value = txtItemID.Text Then
                            tmpbal = Val(tmpbal) + Val(dg1.Rows(i).Cells(9).Value)
                        End If
                    Next i
                    tmpbal = Val(UpdateTmp) - Val(tmpbal)
                    bal = Val(RestBal) - Val(tmpbal)
                Else
                    For i As Integer = 0 To dg1.RowCount - 1
                        If dg1.Rows(i).Cells(0).Value = txtItemID.Text Then
                            tmpbal = Val(tmpbal) + Val(dg1.Rows(i).Cells(9).Value)
                        End If
                    Next i
                    ' If (StockBal) = 0 Then
                    tmpbal = Val(RestBal) - Val(tmpbal) '- Val(dg1.SelectedRows(0).Cells(9).Value)
                    tmpbal = Val(tmpbal) - Val(dg1.SelectedRows(0).Cells(9).Value)
                    bal = Val(RestBal) - Val(tmpbal)
                End If
            End If
        End If
        If dg1.SelectedRows.Count = 0 Then
            lblMainQty.Text = Format(Val(bal), Hash)
        Else
            lblMainQty.Text = Format(Val(bal), Hash)
        End If
    End Sub



    Private Sub PrintRecord()
        Dim count As Integer = 0
        Dim cmd As New SQLite.SQLiteCommand
        Dim sql As String = ""
        ClsFunPrimary.ExecNonQuery("Delete from printing")
        ' clsFun.ExecNonQuery(sql)
        For Each row As DataGridViewRow In tmpgrid.Rows
            'For Each row As DataGridViewRow In .Rows
            With row
                If .Cells(6).Value <> "" Then
                    Dim amtInWords As String = String.Empty
                    Try
                        amtInWords = AmtInWord(.Cells(41).Value)
                    Catch ex As Exception
                        amtInWords = ex.ToString
                    End Try
                    sql = "insert into Printing(T1,T2,M1,M2,M3,M4,M5,M6,M7,D1, D2, P1,P2, P3, P4, P5, P6,P7,P8,P9, " & _
                                          " P10,P11,P12,P13,P14,P15,P16,P17,P18,P19,P20, " & _
                                          " P21,P22,P23,P24,P25,P26,P27,P28,P29,P30,P31,P32," & _
                                          "P33,P34,P35,P36,P37,P38,P39,P40,P41,P42,P43,P44, " & _
                                          "P45,P46,P47,P48,P49,P50,P51,P52,P53,P54,P55,P56,P57, " & _
                                           "P58,P59,P60,P61,P62,P63,P64,P65,P66,P67,P68,P69,P70, " & _
                                           "P71,P72,P73,P74,P75,P76,P77,P78,P79,P80,P81,P82,P83, " & _
                                          "P84,P85,P86,P87,P88,P89,P90,P91,G1,G2,G3,G4,G5,G6,G7,G8,G9,G10, " & _
                                            "P101,P102,P103,P104,P105,P106,P107,P108,P109,P110)" & _
                                          "  values('" & PrintCopies & "', '" & amtInWords & "','" & .Cells(67).Value & "','" & .Cells(68).Value & "','" & .Cells(69).Value & "', " & _
                                                  "'" & .Cells(70).Value & "','" & .Cells(71).Value & "','" & .Cells(72).Value & "', " & _
                                                  "'" & .Cells(76).Value & "','" & .Cells(1).Value & "','" & .Cells(2).Value & "','" & .Cells(3).Value & "','" & .Cells(4).Value & "'," & _
                                                  "'" & .Cells(5).Value & "','" & .Cells(6).Value & "','" & .Cells(7).Value & "','" & .Cells(8).Value & "', " & _
                                                  "'" & .Cells(9).Value & "','" & .Cells(10).Value & "','" & .Cells(11).Value & "','" & .Cells(12).Value & "', " & _
                                                  "'" & .Cells(13).Value & "','" & .Cells(14).Value & "','" & .Cells(15).Value & "','" & .Cells(16).Value & "', " & _
                                                  "'" & .Cells(17).Value & "','" & .Cells(18).Value & "','" & .Cells(19).Value & "','" & .Cells(20).Value & "', " & _
                                                  "'" & .Cells(21).Value & "','" & .Cells(22).Value & "','" & .Cells(23).Value & "','" & .Cells(24).Value & "'," & _
                                                  "'" & .Cells(25).Value & "','" & .Cells(26).Value & "','" & .Cells(27).Value & "','" & .Cells(28).Value & "'," & _
                                                  "'" & .Cells(29).Value & "','" & .Cells(30).Value & "','" & .Cells(31).Value & "','" & .Cells(32).Value & "'," & _
                                                  "'" & .Cells(33).Value & "','" & .Cells(34).Value & "','" & .Cells(35).Value & "','" & .Cells(36).Value & "'," & _
                                                  "'" & .Cells(37).Value & "','" & .Cells(38).Value & "'," & _
                                                  "'" & .Cells(39).Value & "','" & .Cells(40).Value & "','" & .Cells(41).Value & "','" & .Cells(42).Value & "','" & .Cells(43).Value & "'," & _
                                                  "'" & .Cells(44).Value & "','" & .Cells(45).Value & "','" & .Cells(46).Value & "','" & .Cells(47).Value & "', " & _
                                                  "'" & .Cells(48).Value & "','" & .Cells(49).Value & "','" & .Cells(50).Value & "', " & _
                                                  "'" & .Cells(51).Value & "','" & .Cells(52).Value & "','" & .Cells(53).Value & "','" & .Cells(54).Value & "', " & _
                                                  "'" & .Cells(55).Value & "','" & .Cells(56).Value & "','" & .Cells(57).Value & "','" & .Cells(58).Value & "', " & _
                                                  "'" & .Cells(59).Value & "','" & .Cells(60).Value & "','" & .Cells(61).Value & "','" & .Cells(62).Value & "', " & _
                                                  "'" & .Cells(63).Value & "','" & .Cells(64).Value & "','" & .Cells(65).Value & "','" & .Cells(66).Value & "', " & _
                                                 "'" & .Cells(73).Value & "','" & .Cells(74).Value & "','" & .Cells(75).Value & "','" & .Cells(77).Value & "', " & _
                                                  "'" & .Cells(78).Value & "','" & .Cells(79).Value & "','" & .Cells(80).Value & "','" & .Cells(81).Value & "', " & _
                                                  "'" & .Cells(82).Value & "','" & .Cells(83).Value & "','" & .Cells(84).Value & "','" & .Cells(85).Value & "', " & _
                                                  "'" & .Cells(86).Value & "','" & .Cells(87).Value & "','" & .Cells(88).Value & "','" & .Cells(89).Value & "', " & _
                                                  "'" & .Cells(90).Value & "','" & .Cells(91).Value & "','" & .Cells(92).Value & "','" & .Cells(93).Value & "', " & _
                                                  "'" & .Cells(94).Value & "','" & .Cells(95).Value & "','" & .Cells(96).Value & "','" & .Cells(97).Value & "', " & _
                                                  "'" & .Cells(98).Value & "','" & .Cells(99).Value & "','" & .Cells(100).Value & "','" & .Cells(101).Value & "' , " & _
                                                  "'" & .Cells(102).Value & "','" & .Cells(103).Value & "','" & .Cells(104).Value & "','" & .Cells(105).Value & "'," & _
                                                  "'" & .Cells(106).Value & "','" & .Cells(107).Value & "','" & .Cells(108).Value & "', '" & .Cells(109).Value & "', " & _
                                                   "'" & .Cells(110).Value & "','" & .Cells(111).Value & "','" & .Cells(112).Value & "', '" & .Cells(113).Value & "', " & _
                                                  "'" & .Cells(114).Value & "','" & .Cells(115).Value & "','" & .Cells(116).Value & "','" & .Cells(117).Value & "', " & _
                                                  "'" & .Cells(118).Value & "','" & .Cells(119).Value & "','" & .Cells(120).Value & "')"
                    Try
                        cmd = New SQLite.SQLiteCommand(sql, ClsFunPrimary.GetConnection())
                        ClsFunPrimary.ExecNonQuery(sql)
                    Catch ex As Exception
                        MsgBox(ex.Message)
                        ClsFunPrimary.CloseConnection()
                    End Try
                End If
            End With
        Next
        ' clsFun.ExecNonQuery(sql)
    End Sub
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        PnlPrint.Visible = True : PnlPrint.BringToFront()
        TempRowColumn() : retrive2(Val(txtID.Text))

    End Sub

    Private Sub txtTotCashAmt_Leave(sender As Object, e As EventArgs) Handles txtTotCashAmt.Leave
        txtTotCashAmt.Text = Format(Val(txtTotCashAmt.Text), Hash)
    End Sub

    Private Sub txtTotCashAmt_TextChanged(sender As Object, e As EventArgs) Handles txtTotCashAmt.TextChanged
        txtTotDueamt.Text = Format(Val(txtTotTotal.Text) - Val(txtTotCashAmt.Text), Hash)
    End Sub

    Private Sub txtOnValue1_KeyUp(sender As Object, e As KeyEventArgs) Handles txtOnValue1.KeyUp, txtCalPer1.KeyUp,
        txtDisAmt1.KeyUp, txtOnValue2.KeyUp, txtCalPer2.KeyUp, txtDisAmt2.KeyUp, txtOnValue3.KeyUp, txtCalPer3.KeyUp,
        txtDisAmt3.KeyUp, txtOnValue4.KeyUp, txtCalPer4.KeyUp, txtDisAmt4.KeyUp
        DiscountCalculation()
    End Sub

    Private Sub txtFreeQty_Leave(sender As Object, e As EventArgs) Handles txtFreeQty.Leave
        If lblSerial.Text = "Y" Then serialSetting() : pnlSerial.BringToFront() : txtSr1.Focus()
    End Sub

    Private Sub txtFreeQty_LostFocus(sender As Object, e As EventArgs) Handles txtFreeQty.LostFocus
        'serialSetting()
    End Sub

    Private Sub txtSr1_Click(sender As Object, e As EventArgs) Handles txtSr1.Click
        serialSetting()
    End Sub

    Private Sub CheckSerial()
        For Each row As DataGridViewRow In dgSerial.Rows
            'If you want the results to be case sensitive then remove the 2 ".ToLower" references on the line below   
            If row.Cells(1).Value.ToString.ToLower.StartsWith(txtSerialID.Text.ToLower) Then
                row.Visible = True
            Else
                row.Visible = False
            End If
        Next
    End Sub

    Private Sub txtSRClear()
        txtSr1.Clear() : txtSr2.Clear()
        txtSr3.Clear() : txtsr4.Clear()
        txtsr5.Clear()
    End Sub

    Private Sub txtSr1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSr1.KeyDown, txtSr2.KeyDown, txtSr3.KeyDown, txtsr4.KeyDown, txtsr5.KeyDown
        ''If e.KeyCode = Keys.F3 Then
        ''    pnlSerialList.BringToFront() : pnlSerialList.Visible = True : RetriveSerials()
        ''End If
        'If e.KeyCode = Keys.Escape Then
        '    pnlSerialList.Visible = False : pnladditional.Visible = False : txtQty.Focus()
        'End If
        If e.KeyCode = Keys.Enter Then
            Dim serialID As Integer = Val(txtAltQty.Text)
            txtSerialID.Text = serialID
            Dim j As Integer = dgSerial.Rows.GetRowCount(DataGridViewElementStates.Visible)
            If j <> 0 Then
                If j >= Val(txtAltQty.Text) Then txtRate.Focus() : pnlSerial.Visible = False : Exit Sub
                'Else
                '    If j >= Val(txtAltQty.Text) Then txtRate.Focus() : pnladditional.Visible = False : Exit Sub

            End If



            If txtSr1.Focused = True Then
                If Val(clsFun.ExecScalarStr("Select Nos From SerialSetting")) = 1 Then
                    If txtSr1.Text = String.Empty Then MsgBox("Serial No. Can't be Emplty....", vbExclamation.Critical, "Access Denied") : txtSr1.Focus() : Exit Sub
                    Dim k As Integer = 0
                    For k = 0 To dgSerial.Rows.Count - 1
                        With dgSerial.Rows(k)
                            If dgSerial.Rows(k).Cells(2).Value = txtSr1.Text Then
                                If MessageBox.Show("" & lblTitle1.Text & " Already Exits... Do you Want to Continue with Duplicate " & lblTitle1.Text & " ??", "Duplicate", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                                Else
                                    Exit Sub
                                End If
                            End If
                        End With
                    Next
                    Dim i As Integer = dgSerial.Rows.GetRowCount(DataGridViewElementStates.Visible)
                    dgSerial.Rows.Add(txtItemID.Text, serialID, txtSr1.Text) : txtSRClear() : dgSerial.ClearSelection()
                    i = dgSerial.Rows.GetRowCount(DataGridViewElementStates.Visible)
                    If i <> Val(txtAltQty.Text) Then txtSr1.Focus() Else txtRate.Focus() : pnlSerial.Visible = False
                Else
                    SendKeys.Send("{TAB}")
                End If
            End If
            If txtSr2.Focused = True Then
                If Val(clsFun.ExecScalarStr("Select Nos From SerialSetting ")) = 2 Then
                    If txtSr1.Text = String.Empty Then MsgBox("Serial No. Can't be Emplty....", vbExclamation.Critical, "Access Denied") : txtSr1.Focus() : Exit Sub
                    Dim k As Integer = 0
                    For k = 0 To dgSerial.Rows.Count - 1
                        With dgSerial.Rows(k)
                            If dgSerial.Rows(k).Cells(2).Value = txtSr1.Text Then
                                If MessageBox.Show("" & lblTitle1.Text & " Already Exits... Do you Want to Continue with Duplicate " & lblTitle1.Text & " ??", "Duplicate", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                                Else
                                    Exit Sub
                                End If
                            End If
                        End With
                    Next
                    Dim i As Integer = dgSerial.Rows.GetRowCount(DataGridViewElementStates.Visible)
                    If i <> Val(txtAltQty.Text) Then dgSerial.Rows.Add(txtItemID.Text, serialID, txtSr1.Text, txtSr2.Text) : txtSRClear() : dgSerial.ClearSelection()
                    i = dgSerial.Rows.GetRowCount(DataGridViewElementStates.Visible)
                    If i <> Val(txtAltQty.Text) Then txtSr1.Focus() Else txtRate.Focus() : pnlSerial.Visible = False
                Else
                    SendKeys.Send("{TAB}")
                End If
            End If
            If txtSr3.Focused = True Then
                If Val(clsFun.ExecScalarStr("Select Nos From SerialSetting ")) = 3 Then
                    If txtSr1.Text = String.Empty Then MsgBox("Serial No. Can't be Emplty....", vbExclamation.Critical, "Access Denied") : txtSr1.Focus() : Exit Sub
                    Dim k As Integer = 0
                    For k = 0 To dgSerial.Rows.Count - 1
                        With dgSerial.Rows(k)
                            If dgSerial.Rows(k).Cells(2).Value = txtSr1.Text Then
                                If MessageBox.Show("" & lblTitle1.Text & " Already Exits... Do you Want to Continue with Duplicate " & lblTitle1.Text & " ??", "Duplicate", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                                Else
                                    Exit Sub
                                End If
                            End If
                        End With
                    Next
                    Dim i As Integer = dgSerial.Rows.GetRowCount(DataGridViewElementStates.Visible)
                    If i <> Val(txtAltQty.Text) Then dgSerial.Rows.Add(txtItemID.Text, serialID, txtSr1.Text, txtSr2.Text, txtSr3.Text) : txtSRClear() : dgSerial.ClearSelection()
                    i = dgSerial.Rows.GetRowCount(DataGridViewElementStates.Visible)
                    If i <> Val(txtAltQty.Text) Then txtSr1.Focus() Else txtRate.Focus() : pnlSerial.Visible = False
                Else
                    SendKeys.Send("{TAB}")
                End If
            End If
            If txtsr4.Focused = True Then
                If Val(clsFun.ExecScalarStr("Select Nos From SerialSetting ")) = 4 Then
                    If txtSr1.Text = String.Empty Then MsgBox("Serial No. Can't be Emplty....", vbExclamation.Critical, "Access Denied") : txtSr1.Focus() : Exit Sub
                    Dim k As Integer = 0
                    For k = 0 To dgSerial.Rows.Count - 1
                        With dgSerial.Rows(k)
                            If dgSerial.Rows(k).Cells(2).Value = txtSr1.Text Then
                                If MessageBox.Show("" & lblTitle1.Text & " Already Exits... Do you Want to Continue with Duplicate " & lblTitle1.Text & " ??", "Duplicate", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                                Else
                                    Exit Sub
                                End If
                            End If
                        End With
                    Next
                    Dim i As Integer = dgSerial.Rows.GetRowCount(DataGridViewElementStates.Visible)
                    If i <> Val(txtAltQty.Text) Then dgSerial.Rows.Add(txtItemID.Text, serialID, txtSr1.Text, txtSr2.Text, txtSr3.Text, txtsr4.Text) : txtSRClear() : dgSerial.ClearSelection()
                    i = dgSerial.Rows.GetRowCount(DataGridViewElementStates.Visible)
                    If i <> Val(txtAltQty.Text) And dgSerial.Rows(0).Cells(1).Value = Val(txtSerialID.Text) Then txtSr1.Focus() Else txtRate.Focus() : pnlSerial.Visible = False
                Else
                    SendKeys.Send("{TAB}")
                End If
            End If
            If txtsr5.Focused = True Then
                If Val(clsFun.ExecScalarStr("Select Nos From SerialSetting ")) = 5 Then
                    If txtSr1.Text = String.Empty Then MsgBox("Serial No. Can't be Emplty....", vbExclamation.Critical, "Access Denied") : txtSr1.Focus() : Exit Sub
                    Dim k As Integer = 0
                    For k = 0 To dgSerial.Rows.Count - 1
                        With dgSerial.Rows(k)
                            If dgSerial.Rows(k).Cells(2).Value = txtSr1.Text Then
                                If MessageBox.Show("" & lblTitle1.Text & " Already Exits... Do you Want to Continue with Duplicate " & lblTitle1.Text & " ??", "Duplicate", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                                Else
                                    Exit Sub
                                End If
                            End If
                        End With
                    Next
                    Dim i As Integer = dgSerial.Rows.GetRowCount(DataGridViewElementStates.Visible)
                    If i <> Val(txtAltQty.Text) Then dgSerial.Rows.Add(txtItemID.Text, serialID, txtSr1.Text, txtSr2.Text, txtSr3.Text, txtsr4.Text, txtsr5.Text) : txtSRClear() : dgSerial.ClearSelection()
                    i = dgSerial.Rows.GetRowCount(DataGridViewElementStates.Visible)
                    If i <> Val(txtAltQty.Text) Then txtSr1.Focus() Else txtRate.Focus() : pnlSerial.Visible = False
                Else
                    SendKeys.Send("{TAB}")
                End If
            End If
        End If
        ' e.SuppressKeyPress = True
    End Sub

    Private Sub txtSerialID_TextChanged(sender As Object, e As EventArgs) Handles txtSerialID.TextChanged
        For Each row As DataGridViewRow In dgSerial.Rows
            'If you want the results to be case sensitive then remove the 2 ".ToLower" references on the line below   
            If row.Cells(1).Value.ToString.ToLower.StartsWith(txtSerialID.Text.ToLower) And row.Cells(0).Value = Val(txtItemID.Text) Then
                row.Visible = True
            Else
                row.Visible = False
            End If
        Next
    End Sub

    Private Sub deleteBill()
        If MessageBox.Show("Are you Sure want to Delete Invoice No : " & txtVoucherNo.Text & " ??", "DELETE", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            If clsFun.ExecNonQuery("Delete From Vouchers Where ID='" & Val(txtID.Text) & "'; " & _
                                   "Delete From Trans1 Where VoucherID='" & Val(txtID.Text) & "'; " & _
                                   "Delete From ChargesTrans Where VoucherID='" & Val(txtID.Text) & "'; " & _
                                   "Delete From Ledger Where VoucherID='" & Val(txtID.Text) & "'; " & _
                                    "Delete From TaxDetails Where VoucherID='" & Val(txtID.Text) & "'; " & _
                                   "Delete From Ref Where VoucherID='" & Val(txtID.Text) & "'") Then
                MsgBox("Record Deleted Successfully...", vbInformation.Information, "Deleted")
                ClearAll()
            End If
        End If
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        deleteBill()
    End Sub

    Private Sub txtItem_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtCalPer1_Leave(sender As Object, e As EventArgs) Handles txtCalPer1.Leave
        ' DiscountSetting()
    End Sub

    Private Sub txtCdPer_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCdPer.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnSave.PerformClick()
        End If
    End Sub

    Private Sub txtCdPer_KeyUp(sender As Object, e As KeyEventArgs) Handles txtCdPer.KeyUp
        calc()
    End Sub

    Private Sub BtnDirectPrint_Click(sender As Object, e As EventArgs) Handles BtnDirectPrint.Click
        retrive2(Val(txtID.Text)) : PrintCopy()
    End Sub
    Private Sub PrintCopy()
        If ckOriginalPrint.Checked = True And ckDuplicatePrint.Checked = False And ckTransPortPrint.Checked = False Then
            PrintCopies = "(Original For Buyer)" : retrive2(txtID.Text) : PrintRecord()
            If Application.OpenForms().OfType(Of Purchase).Any = False Then Exit Sub
            '  Report_Viewer.PrintDirect("\Purchase.rpt")
        ElseIf ckOriginalPrint.Checked = True And ckDuplicatePrint.Checked = True And ckTransPortPrint.Checked = False Then
            For i As Integer = 1 To 2
                If i = 1 Then PrintCopies = "(Original For Buyer)" Else PrintCopies = "(Duplicate Copy)"
                PrintRecord()
                If Application.OpenForms().OfType(Of Purchase).Any = False Then Exit Sub
                '     Report_Viewer.PrintDirect("\Purchase.rpt")
            Next
        ElseIf ckOriginalPrint.Checked = True And ckDuplicatePrint.Checked = True And ckTransPortPrint.Checked = True Then
            For i As Integer = 1 To 3
                If i = 1 Then PrintCopies = "(Original For Buyer)"
                If i = 2 Then PrintCopies = "(Duplicate Copy)"
                If i = 3 Then PrintCopies = "(Trasport Copy)"
                PrintRecord()
                If Application.OpenForms().OfType(Of Purchase).Any = False Then Exit Sub
                '    Report_Viewer.PrintDirect("\Purchase.rpt")
            Next
        ElseIf ckOriginalPrint.Checked = False And ckDuplicatePrint.Checked = True And ckTransPortPrint.Checked = False Then
            PrintCopies = "(Duplicate Copy)" : PrintRecord()
            If Application.OpenForms().OfType(Of Purchase).Any = False Then Exit Sub
            'Report_Viewer.PrintDirect("\Purchase.rpt")
        ElseIf ckOriginalPrint.Checked = False And ckDuplicatePrint.Checked = False And ckTransPortPrint.Checked = True Then
            PrintCopies = "(Duplicate Copy)" : PrintRecord()
            If Application.OpenForms().OfType(Of Purchase).Any = False Then Exit Sub
            'Report_Viewer.PrintDirect("\Purchase.rpt")
        ElseIf ckOriginalPrint.Checked = False And ckDuplicatePrint.Checked = True And ckTransPortPrint.Checked = True Then
            For i As Integer = 1 To 2
                If i = 1 Then PrintCopies = "(Duplicate Copy)"
                If i = 2 Then PrintCopies = "(Trasport Copy)"
                PrintRecord()
                If Application.OpenForms().OfType(Of Purchase).Any = False Then Exit Sub
                '   Report_Viewer.PrintDirect("\Purchase.rpt")
            Next
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        PrintCopies = "(Original For Buyer)" : PrintRecord()
        'PrintCopy() : PrintRecord()
        If Application.OpenForms().OfType(Of Purchase).Any = False Then Exit Sub
        Report_Viewer.printReport("\Purchase.rpt")
        Report_Viewer.MdiParent = MainScreenForm
        Report_Viewer.Show()
        If Not Report_Viewer Is Nothing Then
            Report_Viewer.BringToFront()
        End If
    End Sub

    Private Sub cbPricePer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPricePer.SelectedIndexChanged
        Calculation()
    End Sub

    Private Sub txtAltQty_KeyUp(sender As Object, e As EventArgs) Handles txtAltQty.KeyUp
        Dim conversion As Decimal = clsFun.ExecScalarStr("Select Conversion From Items Where ID='" & Val(txtItemID.Text) & "'")
        txtQty.Text = Format(Val(txtAltQty.Text) / Val(conversion), Hash)
    End Sub

    Private Sub dgSerial_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgSerial.CellDoubleClick
        If dgSerial.SelectedRows.Count = 0 Then Exit Sub
        txtSr1.Text = dgSerial.SelectedRows(0).Cells(2).Value
        txtSr2.Text = dgSerial.SelectedRows(0).Cells(3).Value
        txtSr3.Text = dgSerial.SelectedRows(0).Cells(4).Value
        txtsr4.Text = dgSerial.SelectedRows(0).Cells(5).Value
        txtsr5.Text = dgSerial.SelectedRows(0).Cells(6).Value
        dgSerial.Rows.Remove(dgSerial.SelectedRows(0)) : dgSerial.ClearSelection() : txtSr1.Focus()

    End Sub

    Private Sub dgSerial_KeyDown(sender As Object, e As KeyEventArgs) Handles dgSerial.KeyDown
        If e.KeyCode = Keys.End Then
            If dgSerial.SelectedRows.Count = 0 Then Exit Sub
            txtSr1.Text = dgSerial.SelectedRows(0).Cells(2).Value
            txtSr2.Text = dgSerial.SelectedRows(0).Cells(3).Value
            txtSr3.Text = dgSerial.SelectedRows(0).Cells(4).Value
            txtsr4.Text = dgSerial.SelectedRows(0).Cells(5).Value
            txtsr5.Text = dgSerial.SelectedRows(0).Cells(6).Value
            dgSerial.Rows.Remove(dgSerial.SelectedRows(0)) : dgSerial.ClearSelection() : txtSr1.Focus()
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        WhatsAppMsg()
    End Sub
    Sub WhatsAppMsg()

        'Dim LastRow As Long
        'Dim i As Integer
        'Dim strip As String
        'Dim strPhoneNumber As String
        'Dim strMessage As String
        'Dim strPostData As String
        'Dim IE As Object
        'strPhoneNumber = txtWhatsapp.Text
        'strMessage = "I Love You Jaan"

        ''IE.navigate "whatsapp://send?phone=phone_number&text=your_message"

        'strPostData = "whatsapp://send?phone=" & strPhoneNumber & "&text=" & strMessage
        'IE = CreateObject("InternetExplorer.Application")
        'IE.Navigate(strPostData)
        ''Application.SendKeys("~")
        '' SendKeys.Send("{ENTER}", True)
        ' '' Application.
        ' '' IE.navigate strPostData
        ' ''Application.Wait Now() + TimeSerial(0, 0, 5)
        'My.Computer.Keyboard.SendKeys("{ENTER}", True)
        ''My.Computer.Keyboard.SendKeys("~", True)
        '' My.Computer.Keyboard.SendKeys.Send("~", True)
    End Sub

    Private Sub cbbatch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbbatch.SelectedIndexChanged

    End Sub

    Private Sub txtField1_GotFocus(sender As Object, e As EventArgs) Handles txtField1.GotFocus
        If dgItemSearch.ColumnCount = 0 Then ItemRowColumns()
        If dgItemSearch.Rows.Count = 0 Then retriveItems()
        If dgItemSearch.SelectedRows.Count = 0 Then dgItemSearch.Visible = True : txtItem.Focus() : Exit Sub
        txtItemID.Text = Val(dgItemSearch.SelectedRows(0).Cells(0).Value)
        txtItem.Text = dgItemSearch.SelectedRows(0).Cells(1).Value
        lblUOM.Text = dgItemSearch.SelectedRows(0).Cells(3).Value
        dgItemSearch.Visible = False : ItemBalance() : ItemFill()
    End Sub

    Private Sub txtField1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtField1.KeyDown, txtField2.KeyDown, txtField3.KeyDown,
        txtField4.KeyDown, txtField5.KeyDown, txtField6.KeyDown, txtField7.KeyDown, txtField8.KeyDown, txtField9.KeyDown, txtField10.KeyDown
        If e.KeyCode = Keys.Enter Then
            'ItemFieldsSetting()
            If txtField1.Focused = True Then
                If Val(clsFun.ExecScalarStr("Select FieldNos  From AdditionFileds where  EntryType='Items'")) = 1 Then
                    pnlAdditional.Visible = False : txtQty.Focus() : Exit Sub

                Else
                    txtField2.Focus() : Exit Sub
                End If
            End If
            If txtField2.Focused = True Then
                If Val(clsFun.ExecScalarStr("Select FieldNos  From AdditionFileds where  EntryType='Items'")) = 2 Then
                    pnlAdditional.Visible = False : txtQty.Focus() : Exit Sub
                Else
                    txtField3.Focus() : Exit Sub
                End If
            End If
            If txtField3.Focused = True Then
                If Val(clsFun.ExecScalarStr("Select FieldNos  From AdditionFileds where  EntryType='Items'")) = 3 Then
                    pnlAdditional.Visible = False : txtQty.Focus() : Exit Sub

                Else
                    txtField4.Focus() : Exit Sub
                End If
            End If
            If txtField4.Focused = True Then
                If Val(clsFun.ExecScalarStr("Select FieldNos  From AdditionFileds where  EntryType='Items'")) = 4 Then
                    pnlAdditional.Visible = False : txtQty.Focus() : Exit Sub

                Else
                    txtField5.Focus() : Exit Sub
                End If
            End If
            If txtField5.Focused = True Then
                If Val(clsFun.ExecScalarStr("Select FieldNos  From AdditionFileds where  EntryType='Items'")) = 5 Then
                    pnlAdditional.Visible = False : txtQty.Focus() : Exit Sub

                Else
                    txtField6.Focus() : Exit Sub
                End If
            End If
            If txtField6.Focused = True Then
                If Val(clsFun.ExecScalarStr("Select FieldNos  From AdditionFileds where  EntryType='Items'")) = 6 Then
                    pnlAdditional.Visible = False : txtQty.Focus() : Exit Sub

                Else
                    txtField7.Focus() : Exit Sub
                End If
            End If
            If txtField7.Focused = True Then
                If Val(clsFun.ExecScalarStr("Select FieldNos  From AdditionFileds where  EntryType='Items'")) = 7 Then
                    pnlAdditional.Visible = False : txtQty.Focus() : Exit Sub

                Else
                    txtField8.Focus() : Exit Sub
                End If
            End If
            If txtField8.Focused = True Then
                If Val(clsFun.ExecScalarStr("Select FieldNos  From AdditionFileds where  EntryType='Items'")) = 8 Then
                    pnlAdditional.Visible = False : txtQty.Focus() : Exit Sub

                Else
                    txtField9.Focus() : Exit Sub
                End If
            End If
            If txtField9.Focused = True Then
                If Val(clsFun.ExecScalarStr("Select FieldNos  From AdditionFileds where  EntryType='Items'")) = 9 Then
                    pnlAdditional.Visible = False : txtQty.Focus() : Exit Sub
                Else
                    txtField10.Focus() : Exit Sub
                End If
            End If
            If txtField10.Focused = True Then
                If Val(clsFun.ExecScalarStr("Select FieldNos  From AdditionFileds where  EntryType='Items'")) = 10 Then
                    pnlAdditional.Visible = False : txtQty.Focus() : Exit Sub
                Else
                    pnlAdditional.Visible = False : txtQty.Focus() : Exit Sub
                End If
            End If
        End If
    End Sub

    
    Private Sub txtGSTN_TextChanged(sender As Object, e As EventArgs) Handles txtGSTN.TextChanged
        Try
            If GSTINValidator.IsValid(txtGSTN.Text) Then
                lbl_Result.ForeColor = Color.Green
                lbl_Result.Text = "Valid GSTIN."
            Else
                lbl_Result.ForeColor = Color.Red
                lbl_Result.Text = "Invalid GSTIN!"
            End If
        Catch ex As Exception
            lbl_Result.ForeColor = Color.Red
            lbl_Result.Text = ex.Message
        End Try
    End Sub
    Private Sub txtInvoiceID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtInvoiceID.KeyDown
        If e.KeyCode = Keys.Enter Then txtAccount.Focus() : pnlInvoiceID.Visible = False
    End Sub

    Private Sub txtInvoiceID_Leave(sender As Object, e As EventArgs) Handles txtInvoiceID.Leave
        pnlInvoiceID.Visible = False
    End Sub

    Private Sub cbSeries_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSeries.SelectedIndexChanged

    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        Dim recordsCount As Integer = clsFun.ExecScalarInt("Select Count(*) FROM Vouchers Where transtype = 'Purchase'  Order By ID ")
        TotalPages = Math.Ceiling(recordsCount / RowCount)
        Offset = (TotalPages - 1) * RowCount
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

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        If Offset = 0 Then
            Offset = clsFun.ExecScalarInt("Select Count(*) FROM Vouchers WHERE transtype = 'Purchase'  Order By ID ")
        End If
        Offset -= RowCount
        If Offset <= 0 Then
            Offset = 0
        End If
        FillWithNevigation()
    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        Offset = 0
        FillWithNevigation()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        ClearAll()
    End Sub

End Class