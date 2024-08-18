Public Class CheckOut_Register
    Private headerCheckBox As CheckBox = New CheckBox()
    Private Sub Room_Booking_Register_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub
    Private Sub Room_Booking_Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0 : Me.Left = 0
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Dim mindate, maxdate As String
        mindate = clsFun.ExecScalarStr("select Max(EntryDate) as entrydate from Vouchers Where TransType='Check Out'")
        maxdate = clsFun.ExecScalarStr("select Max(EntryDate) as entrydate from Vouchers Where TransType='Check Out'")
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
        mskFromDate.Focus() : rowColums()
        Me.KeyPreview = True
    End Sub

    Private Sub dtp1_ValueChanged(sender As Object, e As EventArgs) Handles dtp1.ValueChanged
        mskFromDate.Text = dtp1.Value.ToString("dd-MM-yyyy")
        mskFromDate.Text = clsFun.convdate(mskFromDate.Text)
    End Sub
    Private Sub dtp2_ValueChanged(sender As Object, e As EventArgs) Handles dtp2.ValueChanged
        MsktoDate.Text = dtp2.Value.ToString("dd-MM-yyyy")
        MsktoDate.Text = clsFun.convdate(MsktoDate.Text)
    End Sub
    Private Sub mskFromDate_GotFocus(sender As Object, e As EventArgs) Handles mskFromDate.GotFocus, mskFromDate.Click
        mskFromDate.SelectionStart = 0 : mskFromDate.SelectionLength = Len(mskFromDate.Text)
    End Sub
    Private Sub MsktoDate_GotFocus(sender As Object, e As EventArgs) Handles MsktoDate.GotFocus, MsktoDate.Click
        MsktoDate.SelectionStart = 0 : MsktoDate.SelectionLength = Len(MsktoDate.Text)
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
        Try
            dg1.Rows(e.RowIndex).Cells(0).ReadOnly = False
            '            Check to ensure that the row CheckBox is clicked.
            If e.RowIndex >= 0 AndAlso e.ColumnIndex = 0 Then
                'Loop to verify whether all row CheckBoxes are checked or not.
                Dim isChecked As Boolean = True
                For Each row As DataGridViewRow In dg1.Rows
                    If Convert.ToBoolean(row.Cells("checkBoxColumn").FormattedValue) = False Then
                        isChecked = False
                        Exit For
                    Else
                    End If
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rowColums()
        dg1.ColumnCount = 22
        Dim headerCellLocation As Point = Me.dg1.GetCellDisplayRectangle(0, -1, True).Location
        'Place the Header CheckBox in the Location of the Header Cell.
        headerCheckBox.Location = New Point(headerCellLocation.X + 8, headerCellLocation.Y + 2)
        headerCheckBox.BackColor = Color.RosyBrown
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
        dg1.Columns(2).Name = "No." : dg1.Columns(2).Width = 50
        dg1.Columns(3).Name = "Date" : dg1.Columns(3).Width = 60
        dg1.Columns(4).Name = "Rooms" : dg1.Columns(4).Width = 60
        dg1.Columns(5).Name = "Time" : dg1.Columns(5).Width = 50
        dg1.Columns(6).Name = "Guest" : dg1.Columns(6).Width = 120
        dg1.Columns(7).Name = "Mobile" : dg1.Columns(7).Width = 80
        dg1.Columns(8).Name = "GSTN" : dg1.Columns(8).Width = 80
        dg1.Columns(9).Name = "Days" : dg1.Columns(9).Width = 50
        dg1.Columns(10).Name = "Rent/-" : dg1.Columns(10).Width = 50
        dg1.Columns(11).Name = "Rent" : dg1.Columns(11).Width = 50
        dg1.Columns(12).Name = "Food" : dg1.Columns(12).Width = 50
        dg1.Columns(13).Name = "VAS" : dg1.Columns(13).Width = 50
        dg1.Columns(14).Name = "Other" : dg1.Columns(14).Width = 50
        dg1.Columns(15).Name = "Basic" : dg1.Columns(15).Width = 50
        dg1.Columns(16).Name = "Tax" : dg1.Columns(16).Width = 50
        dg1.Columns(17).Name = "Advance" : dg1.Columns(17).Width = 60
        dg1.Columns(18).Name = "Total" : dg1.Columns(18).Width = 60
        dg1.Columns(19).Name = "Cash" : dg1.Columns(19).Width = 60
        dg1.Columns(20).Name = "Card" : dg1.Columns(20).Width = 60
        dg1.Columns(21).Name = "Change" : dg1.Columns(21).Visible = False
    End Sub
    Private Sub retrive(Optional ByVal condtion As String = "")
        dg1.Rows.Clear()
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("SELECT * FROM Vouchers AS V LEFT JOIN Package P ON V.PackageID = P.ID  Where TransType='Check Out' and EntryDate Between '" & CDate(mskFromDate.Text).ToString("yyyy-MM-dd") & "' And '" & CDate(MsktoDate.Text).ToString("yyyy-MM-dd") & "' " & condtion & "  order by ID ")
        Dim vchid As Integer = 0
        Try
            If dt.Rows.Count > 0 Then
                dg1.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        .Cells(1).Value = dt.Rows(i)("ID").ToString()
                        .Cells(2).Value = dt.Rows(i)("InvoiceNo").ToString()
                        .Cells(3).Value = CDate(dt.Rows(i)("EntryDate")).tostring("dd-MM-yyyy")
                        .Cells(4).Value = dt.Rows(i)("RoomNos").ToString()
                        .Cells(5).Value = dt.Rows(i)("CheckOutTime").ToString()
                        .Cells(6).Value = dt.Rows(i)("CustomerName").ToString()
                        .Cells(7).Value = dt.Rows(i)("CustomerMobile").ToString()
                        .Cells(8).Value = dt.Rows(i)("CustomerGSTN").ToString()
                        .Cells(9).Value = dt.Rows(i)("StayDays").ToString()
                        .Cells(10).Value = Format(Val(dt.Rows(i)("RoomRentRate").ToString()), "0.00")
                        .Cells(11).Value = Format(Val(dt.Rows(i)("RoomRentAmount").ToString()), "0.00")
                        .Cells(12).Value = Format(Val(dt.Rows(i)("TotalFoodAmt").ToString()), "0.00")
                        .Cells(13).Value = Format(Val(dt.Rows(i)("VASAmt").ToString()), "0.00")
                        .Cells(14).Value = Format(Val(dt.Rows(i)("TotalCharges").ToString()), "0.00")
                        .Cells(15).Value = Format(Val(dt.Rows(i)("TotalBasicAmt").ToString()), "0.00")
                        .Cells(16).Value = Format(Val(dt.Rows(i)("TotalTaxAmt").ToString()), "0.00")
                        .Cells(17).Value = Format(Val(dt.Rows(i)("TotalAdvanceAmt").ToString()), "0.00")
                        .Cells(18).Value = Format(Val(dt.Rows(i)("TotaLGrandAmt").ToString()), "0.00")
                        .Cells(19).Value = Format(Val(dt.Rows(i)("TotalCashAmt").ToString()), "0.00")
                        .Cells(20).Value = Format(Val(dt.Rows(i)("CardAmt").ToString()), "0.00")
                        .Cells(21).Value = Format(Val(dt.Rows(i)("TotalBalAmt").ToString()), "0.00")

                    End With

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
    Sub calc()
        txtTotalRoomRent.Text = Format(0, "0.00") : txtFoodAmt.Text = Format(0, "0.00")
        txtVasAmt.Text = Format(0, "0.00") : txtOtheramt.Text = Format(0, "0.00")
        txtTaxAmt.Text = Format(0, "0.00") : txtBasicAmt.Text = Format(0, "0.00")
        txtAdvanceAmt.Text = Format(0, "0.00") : txtRoff.Text = Format(0, "0.00")
        txtTotalAmt.Text = Format(0, "0.00") : txtCashAmt.Text = Format(0, "0.00")
        txtCardAmt.Text = Format(0, "0.00") : txtChangeAmt.Text = Format(0, "0.00")

        For i = 0 To dg1.Rows.Count - 1
            txtTotalRoomRent.Text = Format(Val(txtTotalRoomRent.Text) + Val(dg1.Rows(i).Cells(10).Value), "0.00")
            txtFoodAmt.Text = Format(Val(txtFoodAmt.Text) + Val(dg1.Rows(i).Cells(11).Value), "0.00")
            txtVasAmt.Text = Format(Val(txtVasAmt.Text) + Val(dg1.Rows(i).Cells(12).Value), "0.00")
            txtFoodAmt.Text = Format(Val(txtFoodAmt.Text) + Val(dg1.Rows(i).Cells(13).Value), "0.00")
            txtOtheramt.Text = Format(Val(txtOtheramt.Text) + Val(dg1.Rows(i).Cells(14).Value), "0.00")
            txtTaxAmt.Text = Format(Val(txtTaxAmt.Text) + Val(dg1.Rows(i).Cells(15).Value), "0.00")
            txtBasicAmt.Text = Format(Val(txtBasicAmt.Text) + Val(dg1.Rows(i).Cells(16).Value), "0.00")
            txtAdvanceAmt.Text = Format(Val(txtAdvanceAmt.Text) + Val(dg1.Rows(i).Cells(17).Value), "0.00")
            txtRoff.Text = Format(Val(txtRoff.Text) + Val(dg1.Rows(i).Cells(18).Value), "0.00")
            txtCashAmt.Text = Format(Val(txtCashAmt.Text) + Val(dg1.Rows(i).Cells(19).Value), "0.00")
            txtCardAmt.Text = Format(Val(txtCardAmt.Text) + Val(dg1.Rows(i).Cells(20).Value), "0.00")
            txtChangeAmt.Text = Format(Val(txtChangeAmt.Text) + Val(dg1.Rows(i).Cells(21).Value), "0.00")
        Next
        '   calculation()
    End Sub
    Private Sub dg1_KeyDown(sender As Object, e As KeyEventArgs) Handles dg1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dg1.SelectedRows.Count = 0 Then Exit Sub
            Dim tmpID As Integer = Val(dg1.SelectedRows(0).Cells(1).Value)
            Room_Checkout.MdiParent = MainScreenForm
            Room_Checkout.Show()
            Room_Checkout.FillControls(tmpID)
            If Not Room_Checkout Is Nothing Then
                Room_Checkout.BringToFront()
            End If
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub dg1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dg1.MouseDoubleClick
        If dg1.SelectedRows.Count = 0 Then Exit Sub
        Dim tmpID As Integer = Val(dg1.SelectedRows(0).Cells(1).Value)
        Room_Checkout.MdiParent = MainScreenForm
        Room_Checkout.Show()
        Room_Checkout.FillControls(tmpID)
        If Not Room_Checkout Is Nothing Then
            Room_Checkout.BringToFront()
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        retrive()
    End Sub
    Private Sub mskFromDate_KeyDown(sender As Object, e As KeyEventArgs) Handles mskFromDate.KeyDown, MsktoDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub MsktoDate_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles MsktoDate.MaskInputRejected

    End Sub
End Class