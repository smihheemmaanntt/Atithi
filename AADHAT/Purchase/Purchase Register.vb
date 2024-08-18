Public Class Purchase_Register
    Private headerCheckBox As CheckBox = New CheckBox()
    Dim Hash As String
    Private Sub Purchase_Register_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then If PnlDeleteBills.Visible = True Then PnlDeleteBills.Visible = False : txtDelete.Text = "" : Exit Sub
        If e.KeyCode = Keys.Escape Then If pnlSearch.Visible = True Then pnlSearch.Visible = False : Exit Sub
        If e.KeyCode = Keys.Escape Then Me.Close()
        ' If e.KeyCode = Keys.Down Then dg1.Focus()
    End Sub
    Private Sub Purchase_Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0 : Me.Left = 0
        Me.BackColor = Color.FromArgb(169, 223, 191)
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True : mskFromDate.Focus()
        Dim mindate, maxdate As String
        mindate = clsFun.ExecScalarStr("Select Max(EntryDate) as entrydate from Vouchers where transtype='" & Me.Text & "'")
        maxdate = clsFun.ExecScalarStr("Select max(entrydate) as entrydate from Vouchers where transtype='" & Me.Text & "'")
        If mindate = "" Then mskFromDate.Text = Date.Today.ToString("dd-MM-yyyy") Else mskFromDate.Text = CDate(mindate).ToString("dd-MM-yyyy")
        If maxdate = "" Then MsktoDate.Text = Date.Today.ToString("dd-MM-yyyy") Else MsktoDate.Text = CDate(maxdate).ToString("dd-MM-yyyy")
        mskFromDate.Text = clsFun.convdate(mskFromDate.Text) : MsktoDate.Text = clsFun.convdate(MsktoDate.Text)
        rowColums() : TempRowColumn() : ImportControls()
    End Sub
    Public Sub ImportControls()
        Hash = "0.00" 'clsFun.ExecScalarStr("Select DecimalFormat From Controls")
    End Sub
    Private Sub mskFromDate_GotFocus(sender As Object, e As EventArgs) Handles mskFromDate.GotFocus
        mskFromDate.SelectionStart = 0 : mskFromDate.SelectionLength = Len(mskFromDate.Text)
    End Sub
    Private Sub MsktoDate_GotFocus(sender As Object, e As EventArgs) Handles MsktoDate.GotFocus
        MsktoDate.SelectionStart = 0 : MsktoDate.SelectionLength = Len(MsktoDate.Text)
    End Sub
    Private Sub mskFromDate_KeyDown(sender As Object, e As KeyEventArgs) Handles mskFromDate.KeyDown, MsktoDate.KeyDown, btnShow.KeyDown
        If e.KeyCode = Keys.Enter Then SendKeys.Send("{TAB}")
        If e.KeyCode = Keys.Down And dg1.Rows.Count <> 0 Then dg1.Rows(0).Selected = True : dg1.Focus()
        'e.SuppressKeyPress = True
        'ProcessTabKey(True)
        'End If
    End Sub
    Private Sub mskFromDate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mskFromDate.Validating
        mskFromDate.Text = clsFun.convdate(mskFromDate.Text)
    End Sub

    Private Sub MsktoDate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MsktoDate.Validating
        MsktoDate.Text = clsFun.convdate(MsktoDate.Text)
    End Sub
    Private Sub HeaderCheckBox_Clicked(ByVal sender As Object, ByVal e As EventArgs)
        'Necessary to end the edit mode of the Cell.
        dg1.EndEdit()
        'Loop and check and uncheck all row CheckBoxes based on Header Cell CheckBox.
        For Each row As DataGridViewRow In dg1.Rows
            Dim checkBox As DataGridViewCheckBoxCell = (TryCast(row.Cells("checkBoxColumn"), DataGridViewCheckBoxCell))
            checkBox.Value = headerCheckBox.Checked
        Next
    End Sub
    Private Sub dg1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg1.CellClick
        'Check to ensure that the row CheckBox is clicked.
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = 0 Then
            'Loop to verify whether all row CheckBoxes are checked or not.
            Dim isChecked As Boolean = True
            For Each row As DataGridViewRow In dg1.Rows
                If Convert.ToBoolean(row.Cells("checkBoxColumn").EditedFormattedValue) = False Then
                    isChecked = False
                    Exit For
                End If
            Next
            headerCheckBox.Checked = isChecked
        End If
    End Sub
    Private Sub rowColums()
        dg1.ColumnCount = 12
        Dim headerCellLocation As Point = Me.dg1.GetCellDisplayRectangle(0, -1, True).Location
        'Place the Header CheckBox in the Location of the Header Cell.
        headerCheckBox.Location = New Point(headerCellLocation.X + 8, headerCellLocation.Y + 2)
        headerCheckBox.BackColor = Color.FromArgb(236, 248, 241)
        headerCheckBox.Size = New Size(18, 18)
        AddHandler headerCheckBox.Click, AddressOf HeaderCheckBox_Clicked
        dg1.Controls.Add(headerCheckBox)
        Dim checkBoxColumn As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        checkBoxColumn.HeaderText = ""
        checkBoxColumn.Width = 30
        checkBoxColumn.Name = "checkBoxColumn"
        dg1.Columns.Insert(0, checkBoxColumn)
        'Assign Click event to the DataGridView Cell.
        AddHandler dg1.CellContentClick, AddressOf dg1_CellClick
        dg1.Columns(1).Name = "ID" : dg1.Columns(1).Visible = False
        dg1.Columns(2).Name = "Date" : dg1.Columns(2).Width = 100
        dg1.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dg1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dg1.Columns(3).Name = "Invoice No." : dg1.Columns(3).Width = 100
        dg1.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dg1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dg1.Columns(4).Name = "Account Name" : dg1.Columns(4).Width = 200
        dg1.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dg1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dg1.Columns(5).Name = "Qty" : dg1.Columns(5).Width = 80 : dg1.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable : dg1.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dg1.Columns(6).Name = "Basic " : dg1.Columns(6).Width = 100 : dg1.Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable : dg1.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dg1.Columns(7).Name = "Disc" : dg1.Columns(7).Width = 80 : dg1.Columns(7).SortMode = DataGridViewColumnSortMode.NotSortable : dg1.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dg1.Columns(8).Name = "Taxable" : dg1.Columns(8).Width = 100 : dg1.Columns(8).SortMode = DataGridViewColumnSortMode.NotSortable : dg1.Columns(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dg1.Columns(9).Name = "Tax" : dg1.Columns(9).Width = 100 : dg1.Columns(9).SortMode = DataGridViewColumnSortMode.NotSortable : dg1.Columns(9).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dg1.Columns(10).Name = "Charges" : dg1.Columns(10).Width = 100 : dg1.Columns(10).SortMode = DataGridViewColumnSortMode.NotSortable : dg1.Columns(10).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dg1.Columns(11).Name = "Roff" : dg1.Columns(11).Width = 60 : dg1.Columns(11).SortMode = DataGridViewColumnSortMode.NotSortable : dg1.Columns(11).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dg1.Columns(12).Name = "Total" : dg1.Columns(12).Width = 125 : dg1.Columns(12).SortMode = DataGridViewColumnSortMode.NotSortable : dg1.Columns(12).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dg1.Columns(0).ReadOnly = False
        ' dg1.Rows(0).ReadOnly = False
    End Sub
    Private Sub retrive(Optional ByVal condtion As String = "")
        dg1.Rows.Clear()
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("Select * FROM Vouchers WHERE EntryDate Between '" & CDate(mskFromDate.Text).ToString("yyyy-MM-dd") & "' And '" & CDate(MsktoDate.Text).ToString("yyyy-MM-dd") & "' and transtype='" & Me.Text & "'  " & condtion & " order by EntryDate")
        Try
            If dt.Rows.Count > 0 Then
                If dt.Rows.Count >= 19 Then dg1.Columns(12).Width = 100 Else dg1.Columns(12).Width = 125
                dg1.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        .Cells(1).readonly = True : .Cells(2).readonly = True
                        .Cells(3).readonly = True : .Cells(4).readonly = True
                        .Cells(5).readonly = True : .Cells(6).readonly = True
                        .Cells(7).readonly = True : .Cells(8).readonly = True
                        .Cells(9).readonly = True : .Cells(10).readonly = True
                        .Cells(11).readonly = True : .Cells(12).readonly = True
                        .Cells(5).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Cells(6).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Cells(7).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Cells(8).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Cells(9).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Cells(10).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Cells(11).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Cells(1).Value = dt.Rows(i)("id").ToString()
                        .Cells(2).Value = Format(dt.Rows(i)("EntryDate"), "dd-MM-yyyy")
                        .Cells(3).Value = dt.Rows(i)("InvoiceNo").ToString()
                        .Cells(4).Value = dt.Rows(i)("AccountName").ToString()
                        .Cells(5).Value = Format(Val(dt.Rows(i)("TotQty").ToString()), "0.00")
                        .Cells(6).Value = Format(Val(dt.Rows(i)("TotalBasicAmt").ToString()), "0.00")
                        .Cells(7).Value = Format(Val(dt.Rows(i)("TotalDiscAmt").ToString()) + Val(dt.Rows(i)("CdAmount").ToString()), "0.00")
                        .Cells(8).Value = Format(Val(dt.Rows(i)("TotalTaxableAmt").ToString()), "0.00")
                        .Cells(9).Value = Format(Val(dt.Rows(i)("TotalTaxAmt").ToString()), "0.00")
                        .Cells(10).Value = Format(Val(dt.Rows(i)("AfterCharges").ToString()), "0.00")
                        .Cells(11).Value = Format(Val(dt.Rows(i)("RoundOff").ToString()), "0.00")
                        .Cells(12).Value = Format(Val(dt.Rows(i)("TotalGrandAmt").ToString()), "0.00")
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
        txtTotQty.Text = Format(0, "0.00") : txtTotNet.Text = Format(0, "0.00")
        txtTotDisc.Text = Format(0, "0.00") : txtTotTaxable.Text = Format(0, "0.00")
        txtTotTax.Text = Format(0, "0.00") : txtTotCharges.Text = Format(0, "0.00")
        txtTotRoundOff.Text = Format(0, "0.00") : TxtGrandTotal.Text = Format(0, "0.00")
        txtTotTaxable.Text = Format(0, "0.00")
        Dim i As Integer
        For i = 0 To dg1.Rows.Count - 1
            txtTotQty.Text = Format(Val(txtTotQty.Text) + Val(dg1.Rows(i).Cells(5).Value), "0.00")
            txtTotNet.Text = Format(Val(txtTotNet.Text) + Val(dg1.Rows(i).Cells(6).Value), "0.00")
            txtTotDisc.Text = Format(Val(txtTotDisc.Text) + Val(dg1.Rows(i).Cells(7).Value), "0.00")
            txtTotTaxable.Text = Format(Val(txtTotTaxable.Text) + Val(dg1.Rows(i).Cells(8).Value), "0.00")
            txtTotTax.Text = Format(Val(txtTotTax.Text) + Val(dg1.Rows(i).Cells(9).Value), "0.00")
            txtTotCharges.Text = Format(Val(txtTotCharges.Text) + Val(dg1.Rows(i).Cells(10).Value), "0.00")
            txtTotRoundOff.Text = Format(Val(txtTotRoundOff.Text) + Val(dg1.Rows(i).Cells(11).Value), "0.00")
            TxtGrandTotal.Text = Format(Val(TxtGrandTotal.Text) + Val(dg1.Rows(i).Cells(12).Value), "0.00")
        Next
    End Sub

    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        retrive()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub dg1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg1.CellContentClick

    End Sub

    Private Sub dg1_KeyDown(sender As Object, e As KeyEventArgs) Handles dg1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dg1.SelectedRows.Count = 0 Then Exit Sub
            Dim tmpID As Integer = Val(dg1.SelectedRows(0).Cells(1).Value)
            Purchase.MdiParent = MainScreenForm
            Purchase.Show()
            Purchase.ResumeLayout()
            Purchase.FillControl(tmpID)
            Purchase.BringToFront()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub dg1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dg1.MouseDoubleClick
        If dg1.SelectedRows.Count = 0 Then Exit Sub
        Dim tmpID As Integer = Val(dg1.SelectedRows(0).Cells(1).Value)
        Purchase.MdiParent = MainScreenForm
        Purchase.Show()
        Purchase.ResumeLayout()
        Purchase.FillControl(tmpID)
        Purchase.BringToFront()
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
                            " AS I ON T1.ItemID = I.ID  Where V.ID in (" & id & ")"
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
                    Dim ssql As String = "Select HSNCode,(sum(TaxableAmount)-(sum(CDAmt))) as Taxableamt,TaxPer,IGSTPer, " & _
                                         "sum(IGSTAmt) as IGSTAmt,SGSTPER,Sum(SGSTAmt) as SGSTAmt,CGSTPER, " & _
                                         "Sum(CGSTAmt) as CGSTAmt,sum(TaxAmount) as TaxAmt From Trans1 " & _
                                         " Where VoucherID=" & Val(dt.Rows(i)("ID").ToString()) & " Group by TaxPer,HSNCode Order by TaxPer"
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
    Private Sub IDGentate()
        Dim checkBox As DataGridViewCheckBoxCell
        Dim id As String = String.Empty
        For Each row As DataGridViewRow In dg1.Rows
            checkBox = (TryCast(row.Cells("checkBoxColumn"), DataGridViewCheckBoxCell))
            If checkBox.Value = True Then
                id = id & row.Cells(1).Value & ","
            End If

        Next
        If id = "" Then
            retrive2(id, " and upper(v.accountname) Like upper('" & txtAccountSearch.Text.Trim() & "%')")
        Else
            id = id.Remove(id.LastIndexOf(","))
            retrive2(id, " and upper(v.accountname) Like upper('" & txtAccountSearch.Text.Trim() & "%')")
        End If

    End Sub
    Private Sub PrintList()
        Dim cmd As New SQLite.SQLiteCommand
        Dim sql As String = ""
        ClsFunPrimary.ExecNonQuery("Delete from printing")
        ' clsFun.ExecNonQuery(sql)
        For Each row As DataGridViewRow In dg1.Rows
            With row
                sql = "insert into Printing(D1, D2, P1,P2,P3,P4,P5, P6, P7, P8, P9 , P10, P11, P12,P13,P14,P15,P16,P17,P18,P19,P20,P21) Values( " & _
                      "'" & mskFromDate.Text & "','" & MsktoDate.Text & "','" & .Cells(1).Value & "','" & .Cells(2).Value & "','" & .Cells(3).Value & "','" & .Cells(4).Value & "'," & _
                      "'" & .Cells(5).Value & "','" & .Cells(6).Value & "','" & .Cells(7).Value & "','" & .Cells(8).Value & "', " & _
                      "'" & .Cells(9).Value & "','" & .Cells(10).Value & "','" & .Cells(11).Value & "','" & .Cells(12).Value & "','" & txtTotQty.Text & "', " & _
                      "'" & Format(Val(txtTotNet.Text), "0.00") & "','" & Format(Val(txtTotDisc.Text), "0.00") & "', " & _
                      "'" & Format(Val(txtTotTaxable.Text), "0.00") & "','" & Format(Val(txtTotTax.Text), "0.00") & "', " & _
                      "'" & Format(Val(txtTotCharges.Text), "0.00") & "','" & Format(Val(txtTotRoundOff.Text), "0.00") & "', " & _
                      "'" & Format(Val(TxtGrandTotal.Text), "0.00") & "','" & "Purchase Register" & "')"
                Try
                    cmd = New SQLite.SQLiteCommand(sql, ClsFunPrimary.GetConnection())
                    ClsFunPrimary.ExecNonQuery(sql)
                Catch ex As Exception
                    MsgBox(ex.Message)
                    ClsFunPrimary.CloseConnection()
                End Try
            End With
        Next
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
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        IDGentate()
        If dg1.RowCount = 0 Then
            MsgBox("There is no record to Print...", vbCritical + vbOKOnly, "Empty")
            Exit Sub
        Else
            PrintRecord()
            If Application.OpenForms().OfType(Of Purchase_Register).Any = False Then Exit Sub
            Report_Viewer.printReport("\Purchase.rpt")
            Report_Viewer.MdiParent = MainScreenForm
            Report_Viewer.Show()
            If Not Report_Viewer Is Nothing Then
                Report_Viewer.BringToFront()
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        pnlSearch.Visible = False : PnlDeleteBills.Visible = True : txtDelete.Focus()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim checkBox As DataGridViewCheckBoxCell
        Dim id As String = String.Empty
        If txtDelete.Text <> "SURE" Then MsgBox("captcha Mis Match, Unable to Delete Billss", vbInformation.Critical, "Access Denied") : Exit Sub
        For Each row As DataGridViewRow In dg1.Rows
            checkBox = (TryCast(row.Cells("checkBoxColumn"), DataGridViewCheckBoxCell))
            If checkBox.Value = True Then
                id = id & row.Cells(1).Value & ","
            End If

        Next
        id = id.Remove(id.LastIndexOf(","))
        If id = "" Then MsgBox("Please Select atleast 1 bill to Delete", vbInformation.Critical, "Access Denied") : Exit Sub

        retrive2(id, " and upper(v.accountname) Like upper('" & txtAccountSearch.Text.Trim() & "%')")
        If MessageBox.Show("Are you Sure want to Delete Selected Invoices ??", "DELETE", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.OK Then
            If clsFun.ExecNonQuery("Delete From Vouchers Where ID in (" & id & "); " & _
                                    "Delete From Trans1 Where VoucherID in (" & id & "); " & _
                                    "Delete From ChargesTrans Where VoucherID in(" & id & "); " & _
                                    "Delete From Ledger Where VoucherID in(" & id & ");") Then
                MsgBox("Selected Bills Deleted Successfully...", vbInformation.Information, "Sucessful")
                retrive() : PnlDeleteBills.Visible = False : mskFromDate.Focus()
            End If
        End If
    End Sub

    Private Sub txtDelete_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDelete.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtDelete.Text <> "SURE" Then MsgBox("captcha Mis Match, Unable to Delete Billss", vbInformation.Critical, "Access Denied") : Exit Sub Else btnDelete.PerformClick()
        End If
    End Sub

    Private Sub txtDelete_TextChanged(sender As Object, e As EventArgs) Handles txtDelete.TextChanged

    End Sub

    Private Sub MsktoDate_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles MsktoDate.MaskInputRejected

    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles btnMore.Click
        pnlSearch.Visible = True : PnlDeleteBills.Visible = False
    End Sub

    Private Sub btnPrintList_Click(sender As Object, e As EventArgs) Handles btnPrintList.Click
        If dg1.RowCount = 0 Then MsgBox("No Record to Print...", vbExclamation.Exclamation, "Access Denied") : Exit Sub
        PrintList()
        If Application.OpenForms().OfType(Of Purchase_Register).Any = False Then Exit Sub
        Report_Viewer.printReport("\Reports\PurchaseRegister.rpt")
        Report_Viewer.MdiParent = MainScreenForm
        Report_Viewer.Show() : Report_Viewer.BringToFront()
    End Sub
    Private Sub txtAccountSearch_KeyUp(sender As Object, e As KeyEventArgs) Handles txtAccountSearch.KeyUp
        If txtAccountSearch.Text.Trim() <> "" Then
            retrive(" And upper(AccountName) Like upper('" & txtAccountSearch.Text.Trim() & "%')")
        Else
            retrive()
        End If
    End Sub

    Private Sub txtInvoiceSearch_KeyUp(sender As Object, e As KeyEventArgs) Handles txtInvoiceSearch.KeyUp
        If txtInvoiceSearch.Text.Trim() <> "" Then
            retrive(" And upper(BillNo) Like upper('%" & txtInvoiceSearch.Text.Trim() & "%')")
        Else
            retrive()
        End If
    End Sub

    Private Sub txtQtySearch_KeyUp(sender As Object, e As KeyEventArgs) Handles txtQtySearch.KeyUp
        If txtQtySearch.Text.Trim() <> "" Then
            retrive(" And upper(TotQty) Like upper('" & txtQtySearch.Text.Trim() & "%')")
        Else
            retrive()
        End If
    End Sub

    Private Sub txtbasicAmtSearch_KeyUp(sender As Object, e As KeyEventArgs) Handles txtbasicAmtSearch.KeyUp
        If txtbasicAmtSearch.Text.Trim() <> "" Then
            retrive(" And upper(BasicAmount) Like upper('" & txtbasicAmtSearch.Text.Trim() & "%')")
        Else
            retrive()
        End If
    End Sub

    Private Sub txtTaxableSearch_KeyUp(sender As Object, e As KeyEventArgs) Handles txtTaxableSearch.KeyUp
        If txtTaxableSearch.Text.Trim() <> "" Then
            retrive(" And upper(TaxableAmount) Like upper('" & txtTaxableSearch.Text.Trim() & "%')")
        Else
            retrive()
        End If
    End Sub

    Private Sub txtTotalSearch_KeyUp(sender As Object, e As KeyEventArgs) Handles txtTotalSearch.KeyUp
        If txtTotalSearch.Text.Trim() <> "" Then
            retrive(" And upper(TotalAmount) Like upper('" & txtTotalSearch.Text.Trim() & "%')")
        Else
            retrive()
        End If
    End Sub
End Class