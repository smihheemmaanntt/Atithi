Public Class Room_Check_In

    Private headerCheckBox As CheckBox = New CheckBox()



    Private Sub Room_Check_In_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If pnlVAS.Visible = True Then
                pnlVAS.Visible = False
                txtVAStotal.Focus()
                Exit Sub
            End If
            If pnlBooking.Visible = True Then
                pnlBooking.Visible = False
                txtGuestName.Focus()
                Exit Sub
            End If
        End If
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub Room_Check_In_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0 : Me.Left = 0
        clsFun.FillDropDownList(cbPackage, "Select * From Package", "PackageName", "Id", "")
        clsFun.FillDropDownList(cbState, "Select ID,StateName || ' - ' || CASE WHEN StateGSTCodes < 10 THEN '0' ELSE '' END || StateGSTCodes as State  From StateList ", "State", "Id", "--N.A.--")
        clsFun.FillDropDownList(cbBusinessSources, "Select ID,SourceName From BusinessSources", "SourceName", "Id", "")
        cbDocumentType.SelectedIndex = 0
        mskBookingdate.Text = Date.Today.ToString("dd-MM-yyyy")
        dtpTime.Text = TimeOfDay.ToString("HH:mm tt")
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        CbGender.SelectedIndex = 0 : CbTitle.SelectedIndex = 0
        Me.KeyPreview = True : dg1Columns() : VNumber()
        txtCheckInNo.Focus()
    End Sub

    Private Sub dtp1_KeyUp(sender As Object, e As KeyEventArgs) Handles dtp1.KeyUp
        If e.KeyCode = Keys.Enter Then
            dtpTime.Focus()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub dtp1_ValueChanged(sender As Object, e As EventArgs) Handles dtp1.ValueChanged
        mskBookingdate.Text = dtp1.Value.ToString("dd-MM-yyyy")
        mskBookingdate.Text = clsFun.convdate(mskBookingdate.Text)
    End Sub
    Private Sub TempRowColumn()
        tempdt.ColumnCount = 44
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
        tempdt.Columns(12).Name = "StayDays" : tempdt.Columns(12).Width = 30
        tempdt.Columns(13).Name = "Male" : tempdt.Columns(13).Width = 30
        tempdt.Columns(14).Name = "Female" : tempdt.Columns(14).Width = 30
        tempdt.Columns(15).Name = "Kids" : tempdt.Columns(15).Width = 30
        tempdt.Columns(16).Name = "CompanyName" : tempdt.Columns(16).Width = 30
        tempdt.Columns(17).Name = "CompanyContact" : tempdt.Columns(17).Width = 30
        tempdt.Columns(18).Name = "CompanyAdd" : tempdt.Columns(18).Width = 30
        tempdt.Columns(19).Name = "Email" : tempdt.Columns(19).Width = 30
        tempdt.Columns(20).Name = "Website" : tempdt.Columns(20).Width = 30
        tempdt.Columns(21).Name = "BusinessSourceName" : tempdt.Columns(21).Width = 30
        tempdt.Columns(22).Name = "DocumentType" : tempdt.Columns(22).Width = 30
        tempdt.Columns(23).Name = "DocumentNo" : tempdt.Columns(23).Width = 30
        tempdt.Columns(24).Name = "Remark" : tempdt.Columns(24).Width = 30
        tempdt.Columns(25).Name = "TotalBasicAmt" : tempdt.Columns(25).Width = 30
        tempdt.Columns(26).Name = "TotalDiscAmt" : tempdt.Columns(26).Width = 30
        tempdt.Columns(27).Name = "TotalGrandAmt" : tempdt.Columns(27).Width = 30
        tempdt.Columns(28).Name = "TotalBalAmt" : tempdt.Columns(28).Width = 30
        tempdt.Columns(29).Name = "TotalCashAmt" : tempdt.Columns(29).Width = 30
        tempdt.Columns(30).Name = "RoomNos" : tempdt.Columns(30).Width = 30
        tempdt.Columns(31).Name = "StateName" : tempdt.Columns(31).Width = 30
        tempdt.Columns(32).Name = "CustomerGSTN" : tempdt.Columns(32).Width = 30
        tempdt.Columns(33).Name = "CommingFrom" : tempdt.Columns(33).Width = 30
        tempdt.Columns(34).Name = "GoingTo" : tempdt.Columns(34).Width = 30
        tempdt.Columns(35).Name = "VisitPurpose" : tempdt.Columns(35).Width = 30
        tempdt.Columns(36).Name = "CustomerAddress" : tempdt.Columns(36).Width = 30
        tempdt.Columns(37).Name = "CustomerCity" : tempdt.Columns(37).Width = 30
        tempdt.Columns(38).Name = "PinCode" : tempdt.Columns(38).Width = 30
        tempdt.Columns(39).Name = "VASAmt" : tempdt.Columns(39).Width = 30
        ''''''
        tempdt.Columns(40).Name = "" : tempdt.Columns(40).Width = 30
        tempdt.Columns(41).Name = "" : tempdt.Columns(41).Width = 30
        tempdt.Columns(42).Name = "" : tempdt.Columns(42).Width = 30
        tempdt.Columns(43).Name = "" : tempdt.Columns(43).Width = 30
    End Sub
    Sub FillData()
        TempRowColumn()
        tempdt.Rows.Clear()
        Dim i, j As Integer
        Dim dt As New DataTable
        Dim cnt As Integer = -1
        dt = clsFun.ExecDataTable("Select * From Trans as t left join Items I on I.id=t.ItemID left join Vouchers V on V.id=t.VoucherID LEFT JOIN Package P ON P.ID=V.PackageID " & _
                                  " LEFT JOIN BusinessSources B ON V.BusinessSourceID = B.ID LEFT JOIN StateList S ON V.StateID = S.ID Where VoucherID=" & Val(txtID.Text) & "")
        If dt.Rows.Count = 0 Then Exit Sub
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                tempdt.Rows.Add()
                With tempdt
                    '.Rows(i)(0) = dt.Rows(i)("ID").ToString()
                    tempdt.Rows(i).Cells(1).Value = dt.Rows(i)("TransType").ToString()
                    tempdt.Rows(i).Cells(2).Value = dt.Rows(i)("InvoiceNo").ToString()
                    tempdt.Rows(i).Cells(3).Value = CDate(dt.Rows(i)("EntryDate")).ToString("dd-MM-yyyy")
                    tempdt.Rows(i).Cells(4).Value = dt.Rows(i)("PackageName").ToString()
                    tempdt.Rows(i).Cells(5).Value = dt.Rows(i)("Title").ToString()
                    tempdt.Rows(i).Cells(6).Value = dt.Rows(i)("CustomerName").ToString() : tempdt.Rows(i).Cells(7).Value = dt.Rows(i)("CustomerMobile").ToString()
                    tempdt.Rows(i).Cells(8).Value = dt.Rows(i)("Gender").ToString() : tempdt.Rows(i).Cells(9).Value = dt.Rows(i)("Nationality").ToString()
                    tempdt.Rows(i).Cells(10).Value = dt.Rows(i)("CHeckINDate").ToString() : tempdt.Rows(i).Cells(11).Value = dt.Rows(i)("CheckinTime").ToString()
                    tempdt.Rows(i).Cells(12).Value = Val(dt.Rows(i)("StayDays").ToString())
                    tempdt.Rows(i).Cells(13).Value = dt.Rows(i)("Male").ToString() : tempdt.Rows(i).Cells(14).Value = dt.Rows(i)("Female").ToString()
                    tempdt.Rows(i).Cells(15).Value = dt.Rows(i)("Kids").ToString() : tempdt.Rows(i).Cells(16).Value = dt.Rows(i)("CompanyName").ToString()
                    tempdt.Rows(i).Cells(17).Value = dt.Rows(i)("CompanyContact").ToString() : tempdt.Rows(i).Cells(18).Value = dt.Rows(i)("CompanyAdd").ToString()
                    tempdt.Rows(i).Cells(19).Value = dt.Rows(i)("Email").ToString() : tempdt.Rows(i).Cells(20).Value = dt.Rows(i)("Website").ToString()
                    tempdt.Rows(i).Cells(21).Value = dt.Rows(i)("SourceName").ToString() : tempdt.Rows(i).Cells(22).Value = dt.Rows(i)("DocumentType").ToString()
                    tempdt.Rows(i).Cells(23).Value = dt.Rows(i)("DocumentNo").ToString() : tempdt.Rows(i).Cells(24).Value = dt.Rows(i)("Remark").ToString()
                    tempdt.Rows(i).Cells(25).Value = Format(Val(dt.Rows(i)("TotalBasicAmt").ToString()), "0.00") : tempdt.Rows(i).Cells(26).Value = Format(Val(dt.Rows(i)("TotalDiscAmt").ToString()), "0.00")
                    tempdt.Rows(i).Cells(27).Value = Format(Val(dt.Rows(i)("TotalGrandAmt").ToString()), "0.00") : tempdt.Rows(i).Cells(28).Value = Format(Val(dt.Rows(i)("TotalBalAmt").ToString()), "0.00")
                    tempdt.Rows(i).Cells(29).Value = Format(Val(dt.Rows(i)("TotalCashAmt").ToString()), "0.00")
                    tempdt.Rows(i).Cells(30).Value = dt.Rows(i)("RoomNos").ToString() : tempdt.Rows(i).Cells(31).Value = dt.Rows(i)("StateName").ToString()
                    tempdt.Rows(i).Cells(32).Value = dt.Rows(i)("CustomerGSTN").ToString() : tempdt.Rows(i).Cells(33).Value = dt.Rows(i)("CommingFrom").ToString() 'clsFun.ExecScalarStr("Select StateName From StateList Where ID='" & dt.Rows(i)("StateID").ToString() & "'")
                    tempdt.Rows(i).Cells(34).Value = dt.Rows(i)("GoingTo").ToString() : tempdt.Rows(i).Cells(35).Value = dt.Rows(i)("VisitPurpose").ToString()
                    tempdt.Rows(i).Cells(36).Value = dt.Rows(i)("CustomerAddress").ToString() : tempdt.Rows(i).Cells(37).Value = dt.Rows(i)("CustomerCity").ToString()
                    tempdt.Rows(i).Cells(38).Value = dt.Rows(i)("PinCode").ToString() : tempdt.Rows(i).Cells(39).Value = dt.Rows(i)("VASAmt").ToString()
                    tempdt.Rows(i).Cells(40).Value = "" : tempdt.Rows(i).Cells(41).Value = ""
                    tempdt.Rows(i).Cells(42).Value = "" : tempdt.Rows(i).Cells(43).Value = ""
                End With
            Next
        End If
        dt.Clear()
    End Sub
    Private Sub VNumber()
        'Vno = clsFun.ExecScalarInt("SELECT Max(InvoiceID) AS ID FROM Vouchers Where TransType='Check In' ")
        'txtCheckInNo.Text = Vno + 1
        'txtInvoiceID.Text = Vno + 1
        Dim vno As Integer = 0
        Dim prefix As String = clsFun.ExecScalarStr("Select BookingPrefix From Options").ToString.Trim
        If vno = Val(clsFun.ExecScalarInt("SELECT Max(InvoiceID) AS ID FROM Vouchers Where TransType='Check In' and  ID= (Select mAX(ID) from Vouchers Where TransType='Check In' )")) <> 0 Then
            vno = clsFun.ExecScalarInt("SELECT Max(InvoiceID) AS ID FROM Vouchers Where TransType='Check In' and ID= (Select mAX(ID) from Vouchers Where TransType='Check In')")
            txtCheckInNo.Text = prefix & vno + 1
            txtInvoiceID.Text = vno + 1
        Else
            vno = clsFun.ExecScalarInt("SELECT Max(InvoiceID) AS ID FROM Vouchers Where TransType='Check In' and ID= (Select Max(ID) from Vouchers Where TransType='Check In')")
            txtCheckInNo.Text = prefix & vno + 1
            txtInvoiceID.Text = vno + 1
        End If
    End Sub
    Private Sub txtCheckInNo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCheckInNo.KeyDown
        If e.KeyCode = Keys.F2 Then
            txtInvoiceID.Focus()
            txtInvoiceID.Visible = True
        End If
    End Sub
    Private Sub txtInvoiceID_Leave(sender As Object, e As EventArgs)
        txtInvoiceID.Visible = False
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
    Private Sub dg1Columns()
        dg1.ColumnCount = 8
        Dim headerCellLocation As Point = Me.dg1.GetCellDisplayRectangle(0, -1, True).Location
        'Place the Header CheckBox in the Location of the Header Cell.
        headerCheckBox.Location = New Point(headerCellLocation.X + 8, headerCellLocation.Y + 2)
        headerCheckBox.BackColor = Color.Tan
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
        dg1.Columns(1).Name = "RoomID" : dg1.Columns(1).Visible = False
        dg1.Columns(2).Name = "Room No." : dg1.Columns(2).Width = 200
        dg1.Columns(3).Name = "Type" : dg1.Columns(3).Width = 160
        dg1.Columns(4).Name = "Details" : dg1.Columns(4).Width = 230
        dg1.Columns(5).Name = "Rate" : dg1.Columns(5).Width = 80
        dg1.Columns(6).Name = "Disc %" : dg1.Columns(6).Width = 80
        dg1.Columns(7).Name = "Disc" : dg1.Columns(7).Width = 80
        dg1.Columns(8).Name = "Amount" : dg1.Columns(8).Width = 140
        ' retrive()
    End Sub
    Private Sub dg3Columns()
        dgBookingList.ColumnCount = 6
        dgBookingList.Columns(0).Name = "ID" : dgBookingList.Columns(0).Visible = False
        dgBookingList.Columns(1).Name = "No." : dgBookingList.Columns(1).Width = 50
        dgBookingList.Columns(2).Name = "Book Date" : dgBookingList.Columns(2).Width = 100
        dgBookingList.Columns(3).Name = "Guest Name" : dgBookingList.Columns(3).Width = 200
        dgBookingList.Columns(4).Name = "Room No" : dgBookingList.Columns(4).Width = 100
        dgBookingList.Columns(5).Name = "Check In" : dgBookingList.Columns(4).Width = 100
    End Sub
    Private Sub dg1_KeyDown(sender As Object, e As KeyEventArgs) Handles dg1.KeyDown
        If e.KeyCode = Keys.Space Then
            dg1.BeginEdit(False)
            If dg1.CurrentRow.Cells(0).Value = True Then
                dg1.CurrentRow.Cells(0).Value = False
                calc()
            Else
                dg1.CurrentRow.Cells(0).Value = True
                calc()
            End If
            e.SuppressKeyPress = True
        End If
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If dg1.Rows.Count = 0 Then txtAdvanceRecieved.Focus() : Exit Sub
            Dim iColumn As Integer = dg1.CurrentCell.ColumnIndex
            Dim iRow As Integer = dg1.CurrentCell.RowIndex
            'If iColumn < dg1.Columns.Count Then Exit Sub
            If iColumn = dg1.Columns.Count - 1 Then
                If notlastColumn = True Then
                    dg1.CurrentCell = dg1.Rows(i).Cells(5)
                End If
                If dg1.CurrentRow.Index = Val(dg1.Rows.Count - 1) Then
                    txtAdvanceRecieved.Focus() : dg1.ClearSelection()
                    Exit Sub
                End If
                dg1.CurrentCell = dg1(5, iRow + 1)
            Else
                If dg1.CurrentCell.ColumnIndex = 0 Then
                    dg1.CurrentCell = dg1(iColumn + 5, iRow)
                Else
                    dg1.CurrentCell = dg1(iColumn + 1, iRow)
                End If
            End If
        End If

    End Sub

    Private Sub dg1_Leave(sender As Object, e As EventArgs) Handles dg1.Leave
        If dg1.Rows.Count = 0 Then Exit Sub
        If dg1.CurrentCell.ColumnIndex <> 0 Then
            dg1.EndEdit(True)
        End If

    End Sub
    Private Sub dg1_LostFocus(sender As Object, e As EventArgs) Handles dg1.LostFocus
        dg1.ClearSelection()
    End Sub

    Private Sub retrive()
        dg1.Rows.Clear()
        'Where ISOccupied='N'
        dt = clsFun.ExecDataTable("SELECT * FROM Room AS R INNER JOIN RoomType AS RT ON R.RoomTypeID = RT.ID Where PackageID= '" & Val(cbPackage.SelectedValue) & "'   ")
        Try
            If dt.Rows.Count > 0 Then
                dg1.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add() : dg1.ClearSelection()
                    '  Application.DoEvents()
                    With dg1.Rows(i)
                        .Cells(1).Value = dt.Rows(i)("id").ToString()
                        .Cells(2).Value = dt.Rows(i)("RoomName").ToString()
                        .Cells(3).Value = dt.Rows(i)("RoomTypeName").ToString()
                        .Cells(4).Value = dt.Rows(i)("Discription").ToString()
                        dt2 = clsFun.ExecDataTable("SELECT * FROM RoomType Where PackageID= '" & Val(cbPackage.SelectedValue) & "' and  ID= '" & Val(dt.Rows(i)("RoomTypeID").ToString()) & "'")
                        .Cells(5).Value = Format(Val(dt2.Rows(0)("RoomRent").ToString()), "0.00")
                        .Cells(6).Value = Format(Val(dt2.Rows(0)("DiscPer").ToString()), "0.00")
                        .Cells(7).Value = Format(Val(Val(.Cells(5).Value) * Val(.Cells(6).Value) / 100), "0.00")
                        .Cells(8).Value = Format(Val(.Cells(5).Value - .Cells(7).Value), "0.00")
                        .Cells(5).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Cells(6).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Cells(7).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Cells(8).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        dg1.Rows(i).Cells(0).ReadOnly = False : dg1.Rows(i).Cells(1).ReadOnly = True
                        dg1.Rows(i).Cells(2).ReadOnly = True : dg1.Rows(i).Cells(3).ReadOnly = True
                        dg1.Rows(i).Cells(4).ReadOnly = True : dg1.Rows(i).Cells(5).ReadOnly = False
                        dg1.Rows(i).Cells(5).ReadOnly = False : dg1.Rows(i).Cells(7).ReadOnly = False
                        dg1.Rows(i).Cells(8).ReadOnly = True

                    End With
                    ' Dg1.Rows.Add()
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "Atithi")
        End Try
        dg1.ClearSelection() : Exit Sub
    End Sub
    Private Sub retriveBooking(Optional ByVal condtion As String = "")
        dgBookingList.Rows.Clear()
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("Select * from Vouchers Where ISBooked is null and TransType='Room Book' " & condtion & "")
        Dim vchid As Integer = 0
        Try
            If dt.Rows.Count > 0 Then
                dgBookingList.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dgBookingList.Rows.Add()
                    With dgBookingList.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("ID").ToString()
                        .Cells(1).Value = dt.Rows(i)("InvoiceNo").ToString()
                        .Cells(2).Value = CDate(dt.Rows(i)("EntryDate")).ToString("dd-MM-yyyy")
                        .Cells(3).Value = dt.Rows(i)("CustomerName").ToString()
                        .Cells(4).Value = dt.Rows(i)("RoomNos").ToString()
                        .Cells(5).Value = CDate(dt.Rows(i)("CheckinDate")).ToString("dd-MM-yyyy")
                    End With
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "AADHAT")
        End Try
        dgBookingList.ClearSelection()
    End Sub
    Private Sub cbDocumentType_Leave(sender As Object, e As EventArgs) Handles cbDocumentType.Leave
        If cbDocumentType.Text = "" Then cbDocumentType.SelectedIndex = 0
    End Sub
    Private Sub CbTitle_Leave(sender As Object, e As EventArgs) Handles CbTitle.Leave
        If CbTitle.Text = "" Then CbTitle.SelectedIndex = 0
    End Sub
    Private Sub cbPackage_Leave(sender As Object, e As EventArgs) Handles cbPackage.Leave
        If cbPackage.Text = "" Then cbPackage.SelectedIndex = 0
        If BtnSave.Text <> "&Save" Then Exit Sub
        If Val(txtBookingID.Text) > 0 Then Exit Sub
        retrive()
    End Sub
    Private Sub mskBookingdate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mskBookingdate.Validating
        mskBookingdate.Text = clsFun.convdate(mskBookingdate.Text)
    End Sub
    Private Sub mskBookingdate_KeyDown(sender As Object, e As KeyEventArgs) Handles mskBookingdate.KeyDown, txtCheckInNo.KeyDown,
    cbPackage.KeyDown, CbTitle.KeyDown, txtGuestName.KeyDown, txtGuestMobileNo.KeyDown, txtBdate.KeyDown, CbGender.KeyDown, txtNationalitiy.KeyDown,
    dtpTime.KeyDown, txtStayDays.KeyDown, txtMale.KeyDown, txtFemale.KeyDown, txtKids.KeyDown, txtAddress.KeyDown, ckBooking.KeyDown,
        txtDistrict.KeyDown, cbState.KeyDown, txtPinCode.KeyDown, txtCompanyName.KeyDown, txtContactNo.KeyDown, txtBusinessAdd.KeyDown,
        txtEmail.KeyDown, txtWebsite.KeyDown, cbBusinessSources.KeyDown, txtGSTN.KeyDown, cbDocumentType.KeyDown, txtDocumentNo.KeyDown,
        txtRemark.KeyDown, txtAdvanceRecieved.KeyDown, txtCommingFrom.KeyDown, txtGoingTo.KeyDown, txtVisitPurpose.KeyDown, txtDueAmount.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
            e.SuppressKeyPress = True
        End If
        If txtVisitPurpose.Focused Then
            If e.KeyCode = Keys.Enter Then
                If dg1.Rows.Count = 0 Then Exit Sub
                dg1.Rows(0).Selected = True
                e.SuppressKeyPress = True
            End If
        End If
    End Sub
    Private Sub calc()
        TxtRentAmount.Text = Format(0, "0.00") : txtDiscAmt.Text = Format(0, "0.00")
        TxtTotal.Text = Format(0, "0.00") : TxtTotal.Text = Format(0, "0.00")
        For i = 0 To dg1.Rows.Count - 1
            Dim c As Boolean = Convert.ToBoolean(dg1.Rows(i).Cells(0).EditedFormattedValue)
            If c = True Then
                TxtRentAmount.Text = Format(Val(TxtRentAmount.Text) + Val(dg1.Rows(i).Cells(5).Value), "0.00")
                txtDiscAmt.Text = Format(Val(txtDiscAmt.Text) + Val(dg1.Rows(i).Cells(7).Value), "0.00")
                'TxtTotal.Text = Format(Val(TxtTotal.Text) + Val(dg1.Rows(i).Cells(8).Value), "0.00")
            End If
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
        calc()
    End Sub
    Private Sub ckBooking_CheckedChanged(sender As Object, e As EventArgs) Handles ckBooking.CheckedChanged
        If ckBooking.Checked = True Then
            dg3Columns() : retriveBooking()
            pnlBooking.Visible = True
            pnlBooking.BringToFront()
            dgBookingList.Focus()
        Else
            pnlBooking.Visible = False
            txtGuestName.Focus()
        End If
    End Sub

    Private Sub txtBookingNumber_KeyUp(sender As Object, e As KeyEventArgs) Handles txtBookingSearch.KeyUp
        If txtBookingSearch.Text.Trim() <> "" Then
            retriveBooking(" And InvoiceNo Like '" & txtBookingSearch.Text.Trim() & "%'")
        End If
        If txtBookingSearch.Text.Trim() = "" Then
            retriveBooking()
        End If
        If e.KeyCode = Keys.Down Then dgBookingList.Focus()
    End Sub


    Private Sub txtGuestSearch_KeyUp(sender As Object, e As KeyEventArgs) Handles txtGuestSearch.KeyUp
        If txtGuestSearch.Text.Trim() <> "" Then
            retriveBooking(" And CustomerName Like '" & txtGuestSearch.Text.Trim() & "%'")
        End If
        If txtGuestSearch.Text.Trim() = "" Then
            retriveBooking()
        End If
        If e.KeyCode = Keys.Down Then dgBookingList.Focus()
    End Sub

    Private Sub txtRoomNoSearch_KeyUp(sender As Object, e As KeyEventArgs) Handles txtRoomNoSearch.KeyUp
        If txtRoomNoSearch.Text.Trim() <> "" Then
            retriveBooking(" And RoomNos Like '" & txtRoomNoSearch.Text.Trim() & "%'")
        End If
        If txtRoomNoSearch.Text.Trim() = "" Then
            retriveBooking()
        End If
        If e.KeyCode = Keys.Down Then dgBookingList.Focus()
    End Sub
    Public Sub FillEnquiry(ByVal id As Integer)
        If clsFun.GetConnection.State = ConnectionState.Open Then clsFun.CloseConnection()
        sSql = "SELECT * FROM Vouchers AS V LEFT JOIN Package P ON V.PackageID = P.ID LEFT JOIN BusinessSources B ON V.BusinessSourceID = B.ID LEFT JOIN StateList S ON V.StateID = S.ID  where V.id=" & id
        clsFun.con.Open()
        Dim ad As New SQLite.SQLiteDataAdapter(sSql, clsFun.GetConnection)
        Dim ds As New DataSet
        ad.Fill(ds, "a")

        If ds.Tables("a").Rows.Count > 0 Then
            txtBookingID.Text = ds.Tables("a").Rows(0)("ID").ToString()
            ' mskBookingdate.Text = Format(ds.Tables("a").Rows(0)("EntryDate"), "dd-MM-yyyy")
            ' txtBookingNo.Text = ds.Tables("a").Rows(0)("InvoiceNo").ToString()
            cbPackage.Text = ds.Tables("a").Rows(0)("PackageName").ToString()
            CbTitle.Text = ds.Tables("a").Rows(0)("Title").ToString()
            txtGuestName.Text = ds.Tables("a").Rows(0)("CustomerName").ToString()
            txtGuestMobileNo.Text = ds.Tables("a").Rows(0)("CustomerMobile").ToString()
            txtBdate.Text = ds.Tables("a").Rows(0)("DateofBirth").ToString()
            CbGender.Text = ds.Tables("a").Rows(0)("Gender").ToString()
            txtNationalitiy.Text = ds.Tables("a").Rows(0)("Nationality").ToString()
            mskBookingdate.Text = CDate(ds.Tables("a").Rows(0)("CheckinDate")).ToString("dd-MM-yyyy")
            ' dtpTime.Text = ds.Tables("a").Rows(0)("CheckinTime").ToString()
            txtStayDays.Text = ds.Tables("a").Rows(0)("StayDays").ToString()
            txtMale.Text = Val(ds.Tables("a").Rows(0)("Male").ToString())
            txtFemale.Text = ds.Tables("a").Rows(0)("Female").ToString()
            txtKids.Text = ds.Tables("a").Rows(0)("Kids").ToString()
            txtCompanyName.Text = ds.Tables("a").Rows(0)("CompanyName").ToString()
            txtContactNo.Text = ds.Tables("a").Rows(0)("CompanyContact").ToString()
            txtBusinessAdd.Text = ds.Tables("a").Rows(0)("CompanyAdd").ToString()
            txtEmail.Text = ds.Tables("a").Rows(0)("Email").ToString()
            txtWebsite.Text = ds.Tables("a").Rows(0)("Website").ToString()
            cbBusinessSources.Text = ds.Tables("a").Rows(0)("SourceName").ToString()
            txtGSTN.Text = ds.Tables("a").Rows(0)("CustomerGSTN").ToString()
            cbDocumentType.Text = ds.Tables("a").Rows(0)("DocumentType").ToString()
            txtDocumentNo.Text = ds.Tables("a").Rows(0)("DocumentNo").ToString()
            txtRemark.Text = ds.Tables("a").Rows(0)("Remark").ToString()
            TxtRentAmount.Text = ds.Tables("a").Rows(0)("TotalBasicAmt").ToString()
            txtDiscAmt.Text = ds.Tables("a").Rows(0)("TotalDiscAmt").ToString()
            TxtTotal.Text = ds.Tables("a").Rows(0)("TotalGrandAmt").ToString()
            txtAdvanceRecieved.Text = ds.Tables("a").Rows(0)("TotalCashAmt").ToString()
            txtDueAmount.Text = ds.Tables("a").Rows(0)("TotalBalAmt").ToString()
            cbState.SelectedValue = ds.Tables("a").Rows(0)("StateID").ToString()
            txtCommingFrom.Text = ds.Tables("a").Rows(0)("CommingFrom").ToString()
            txtGoingTo.Text = ds.Tables("a").Rows(0)("GoingTo").ToString()
            txtVisitPurpose.Text = ds.Tables("a").Rows(0)("VisitPurpose").ToString()
            txtAddress.Text = ds.Tables("a").Rows(0)("CustomerAddress").ToString()
            txtDistrict.Text = ds.Tables("a").Rows(0)("CustomerCity").ToString()
            txtPinCode.Text = ds.Tables("a").Rows(0)("PinCode").ToString()
        End If
        Dim dt2 As New DataTable
        dg1.Rows.Clear()
        'Where ISOccupied='N'
        dt = clsFun.ExecDataTable("SELECT * FROM Trans AS T Inner JOIN Room R ON T.RoomID = R.ID Inner JOIN RoomType RT ON R.RoomTypeID = RT.ID  Where VoucherID=" & id)
        Dim dvData As DataView = New DataView(dt)
        Try
            If dt.Rows.Count > 0 Then
                dg1.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        .Cells(0).Value = True
                        .Cells(1).Value = dt.Rows(i)("RoomID").ToString()
                        .Cells(2).Value = dt.Rows(i)("RoomName").ToString()
                        .Cells(3).Value = dt.Rows(i)("RoomTypeName").ToString()
                        .Cells(4).Value = dt.Rows(i)("Discription").ToString()
                        .Cells(5).Value = Format(Val(dt.Rows(i)("Rate").ToString()), "0.00")
                        .Cells(6).Value = Format(Val(dt.Rows(i)("DisPer").ToString()), "0.00")
                        .Cells(7).Value = Format(Val(dt.Rows(i)("DisAmt").ToString()), "0.00")
                        .Cells(8).Value = Format(Val(dt.Rows(i)("BasicAmt").ToString()), "0.00")
                    End With
                Next
            End If
        Catch ex As Exception
            MsgBox("a")
        End Try
        dg1.ClearSelection()
    End Sub

    Public Sub FillControls(ByVal id As Integer)
        BtnSave.Text = "&Update"
        If clsFun.GetConnection.State = ConnectionState.Open Then clsFun.CloseConnection()
        sSql = "SELECT * FROM Vouchers AS V LEFT JOIN Package P ON V.PackageID = P.ID LEFT JOIN BusinessSources B ON V.BusinessSourceID = B.ID LEFT JOIN StateList S ON V.StateID = S.ID  where V.id=" & id
        clsFun.con.Open()
        Dim ad As New SQLite.SQLiteDataAdapter(sSql, clsFun.GetConnection)
        Dim ds As New DataSet
        ad.Fill(ds, "a")
        If ds.Tables("a").Rows.Count > 0 Then
            txtID.Text = ds.Tables("a").Rows(0)("ID").ToString()
            mskBookingdate.Text = Format(ds.Tables("a").Rows(0)("EntryDate"), "dd-MM-yyyy")
            txtCheckInNo.Text = ds.Tables("a").Rows(0)("InvoiceNo").ToString()
            txtInvoiceID.Text = Val(ds.Tables("a").Rows(0)("InvoiceID").ToString())
            cbPackage.Text = ds.Tables("a").Rows(0)("PackageName").ToString()
            CbTitle.Text = ds.Tables("a").Rows(0)("Title").ToString()
            txtGuestName.Text = ds.Tables("a").Rows(0)("CustomerName").ToString()
            txtGuestMobileNo.Text = ds.Tables("a").Rows(0)("CustomerMobile").ToString()
            txtBdate.Text = ds.Tables("a").Rows(0)("DateofBirth").ToString()
            CbGender.Text = ds.Tables("a").Rows(0)("Gender").ToString()
            txtNationalitiy.Text = ds.Tables("a").Rows(0)("Nationality").ToString()
            'mskBookingdate.Text = CDate(ds.Tables("a").Rows(0)("CheckinDate")).ToString("dd-MM-yyyy")
            dtpTime.Text = ds.Tables("a").Rows(0)("CheckinTime").ToString()
            txtStayDays.Text = ds.Tables("a").Rows(0)("StayDays").ToString()
            txtMale.Text = Val(ds.Tables("a").Rows(0)("Male").ToString())
            txtFemale.Text = ds.Tables("a").Rows(0)("Female").ToString()
            txtKids.Text = ds.Tables("a").Rows(0)("Kids").ToString()
            txtCompanyName.Text = ds.Tables("a").Rows(0)("CompanyName").ToString()
            txtContactNo.Text = ds.Tables("a").Rows(0)("CompanyContact").ToString()
            txtBusinessAdd.Text = ds.Tables("a").Rows(0)("CompanyAdd").ToString()
            txtEmail.Text = ds.Tables("a").Rows(0)("Email").ToString()
            txtWebsite.Text = ds.Tables("a").Rows(0)("Website").ToString()
            cbBusinessSources.Text = ds.Tables("a").Rows(0)("SourceName").ToString()
            txtGSTN.Text = ds.Tables("a").Rows(0)("CustomerGSTN").ToString()
            cbDocumentType.Text = ds.Tables("a").Rows(0)("DocumentType").ToString()
            txtDocumentNo.Text = ds.Tables("a").Rows(0)("DocumentNo").ToString()
            txtRemark.Text = ds.Tables("a").Rows(0)("Remark").ToString()
            TxtRentAmount.Text = Format(Val(ds.Tables("a").Rows(0)("RoomRentAmount").ToString()), "0.00")
            txtDiscAmt.Text = Format(Val(ds.Tables("a").Rows(0)("TotalDiscAmt").ToString()), "0.00")
            TxtTotal.Text = Format(Val(ds.Tables("a").Rows(0)("TotalGrandAmt").ToString()), "0.00")
            txtAdvanceRecieved.Text = Format(Val(ds.Tables("a").Rows(0)("TotalCashAmt").ToString()), "0.00")
            txtDueAmount.Text = Format(Val(ds.Tables("a").Rows(0)("TotalBalAmt").ToString()), "0.00")
            cbState.SelectedValue = ds.Tables("a").Rows(0)("StateID").ToString()
            txtCommingFrom.Text = ds.Tables("a").Rows(0)("CommingFrom").ToString()
            txtGoingTo.Text = ds.Tables("a").Rows(0)("GoingTo").ToString()
            txtVisitPurpose.Text = ds.Tables("a").Rows(0)("VisitPurpose").ToString()
            txtAddress.Text = ds.Tables("a").Rows(0)("CustomerAddress").ToString()
            txtDistrict.Text = ds.Tables("a").Rows(0)("CustomerCity").ToString()
            txtPinCode.Text = ds.Tables("a").Rows(0)("PinCode").ToString()
            txtVAStotal.Text = ds.Tables("a").Rows(0)("VASAmt").ToString()
        End If
        dg1.Rows.Clear()
        dt = clsFun.ExecDataTable("SELECT * FROM Trans AS T Inner JOIN Room R ON T.RoomID = R.ID Inner JOIN RoomType RT ON R.RoomTypeID = RT.ID  Where VoucherID=" & id)
        Dim dvData As DataView = New DataView(dt)
        Try
            If dt.Rows.Count > 0 Then
                dg1.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        .Cells(0).Value = True
                        .Cells(1).Value = dt.Rows(i)("RoomID").ToString()
                        .Cells(2).Value = dt.Rows(i)("RoomName").ToString()
                        .Cells(3).Value = dt.Rows(i)("RoomTypeName").ToString()
                        .Cells(4).Value = dt.Rows(i)("Discription").ToString()
                        .Cells(5).Value = Format(Val(dt.Rows(i)("Rate").ToString()), "0.00")
                        .Cells(6).Value = Format(Val(dt.Rows(i)("DisPer").ToString()), "0.00")
                        .Cells(7).Value = Format(Val(dt.Rows(i)("DisAmt").ToString()), "0.00")
                        .Cells(8).Value = Format(Val(dt.Rows(i)("BasicAmt").ToString()), "0.00")
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
                    End With
                Next
            End If
        Catch ex As Exception
            MsgBox("a")
        End Try
        calcVas() : dg1.ClearSelection()
    End Sub

    Private Sub dgBookingList_KeyDown(sender As Object, e As KeyEventArgs) Handles dgBookingList.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If dgBookingList.SelectedRows.Count = 0 Then Exit Sub
            Dim tmpID As Integer = Val(dgBookingList.SelectedRows(0).Cells(0).Value)
            FillEnquiry(tmpID) : pnlBooking.Visible = False : txtGuestName.Focus()
        End If
    End Sub

    Private Sub dgBookingList_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dgBookingList.MouseDoubleClick
        If dgBookingList.SelectedRows.Count = 0 Then Exit Sub
        Dim tmpID As Integer = Val(dgBookingList.SelectedRows(0).Cells(0).Value)
        FillEnquiry(tmpID) : pnlBooking.Visible = False : txtGuestName.Focus()
    End Sub

    Private Sub save()
        Dim cmd As SQLite.SQLiteCommand
        Dim RoomID As String = String.Empty
        Dim RoomNo As String = String.Empty
        Dim checkBox As DataGridViewCheckBoxCell
        For Each row As DataGridViewRow In dg1.Rows
            checkBox = (TryCast(row.Cells("checkBoxColumn"), DataGridViewCheckBoxCell))
            If checkBox.Value = True Then
                RoomID = RoomID & row.Cells(1).Value & ","
                RoomNo = RoomNo & row.Cells(2).Value & ","
            End If
        Next
        If RoomID <> "" Then
            RoomID = RoomID.Remove(RoomID.LastIndexOf(","))
            RoomNo = RoomNo.Remove(RoomNo.LastIndexOf(","))
            clsFun.ExecScalarStr("Update Room Set ISOccupied='Y' Where ID in(" & RoomID & ")")
        Else
            MsgBox("Please Select At Leat 1 Room for Booking...", vbCritical, "Choose Room") : dg1.Focus() : Exit Sub
        End If
        If txtGuestName.Text = "" Then
            txtGuestName.Focus()
            MsgBox("Please Fill Gusest Name... ", MsgBoxStyle.Exclamation, "Empty")
            Exit Sub
        End If
        Dim sql As String = "insert into Vouchers (TransType, InvoiceNo, EntryDate,PackageID,Title,CustomerName,CustomerMobile,DateofBirth, " & _
                             "Gender,Nationality,CHeckINDate,CheckinTime,StayDays,Male,Female,Kids,CompanyName, " & _
                             "CompanyContact,CompanyAdd,Email,Website,BusinessSourceID,DocumentType,DocumentNo,Remark, " & _
                             "RoomRentAmount,TotalDiscAmt,TotalGrandAmt,TotalCashAmt,TotalBalAmt,RoomNos,StateID,CustomerGSTN, " & _
                             "CommingFrom,GoingTo,VisitPurpose,CustomerAddress,CustomerCity,PinCode,VASAmt,RoomIDs,InvoiceID) " & _
                             " values (@0,@1, @2,@3,@4, @5,@6,@7, @8,@9,@10,@11, @12,@13,@14, @15,@16,@17, @18,@19,@20, " & _
                             "@21, @22,@23,@24, @25,@26,@27,@28,@29,@30,@31,@32,@33,@34,@35 ,@36,@37,@38,@39,@40,@41)"
        Try
            cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
            cmd.Parameters.AddWithValue("@0", Me.Text)
            cmd.Parameters.AddWithValue("@1", txtCheckInNo.Text) : cmd.Parameters.AddWithValue("@2", CDate(mskBookingdate.Text).ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@3", Val(cbPackage.SelectedValue)) : cmd.Parameters.AddWithValue("@4", CbTitle.Text)
            cmd.Parameters.AddWithValue("@5", txtGuestName.Text) : cmd.Parameters.AddWithValue("@6", txtGuestMobileNo.Text)
            cmd.Parameters.AddWithValue("@7", txtBdate.Text) : cmd.Parameters.AddWithValue("@8", CbGender.Text)
            cmd.Parameters.AddWithValue("@9", txtNationalitiy.Text) : cmd.Parameters.AddWithValue("@10", CDate(mskBookingdate.Text).ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@11", dtpTime.Text) : cmd.Parameters.AddWithValue("@12", Val(txtStayDays.Text))
            cmd.Parameters.AddWithValue("@13", Val(txtMale.Text)) : cmd.Parameters.AddWithValue("@14", Val(txtFemale.Text))
            cmd.Parameters.AddWithValue("@15", Val(txtKids.Text)) : cmd.Parameters.AddWithValue("@16", txtCompanyName.Text) : cmd.Parameters.AddWithValue("@17", txtContactNo.Text)
            cmd.Parameters.AddWithValue("@18", txtBusinessAdd.Text) : cmd.Parameters.AddWithValue("@19", txtEmail.Text)
            cmd.Parameters.AddWithValue("@20", txtWebsite.Text) : cmd.Parameters.AddWithValue("@21", Val(cbBusinessSources.SelectedValue))
            cmd.Parameters.AddWithValue("@22", cbDocumentType.Text) : cmd.Parameters.AddWithValue("@23", txtDocumentNo.Text)
            cmd.Parameters.AddWithValue("@24", txtRemark.Text) : cmd.Parameters.AddWithValue("@25", Val(TxtRentAmount.Text))
            cmd.Parameters.AddWithValue("@26", Val(txtDiscAmt.Text)) : cmd.Parameters.AddWithValue("@27", Val(TxtTotal.Text))
            cmd.Parameters.AddWithValue("@28", Val(txtAdvanceRecieved.Text)) : cmd.Parameters.AddWithValue("@29", Val(txtDueAmount.Text))
            cmd.Parameters.AddWithValue("@30", RoomNo) : cmd.Parameters.AddWithValue("@31", Val(cbState.SelectedValue))
            cmd.Parameters.AddWithValue("@32", txtGSTN.Text) : cmd.Parameters.AddWithValue("@33", txtCommingFrom.Text)
            cmd.Parameters.AddWithValue("@34", txtGoingTo.Text) : cmd.Parameters.AddWithValue("@35", txtVisitPurpose.Text)
            cmd.Parameters.AddWithValue("@36", txtAddress.Text) : cmd.Parameters.AddWithValue("@37", txtDistrict.Text)
            cmd.Parameters.AddWithValue("@38", txtPinCode.Text) : cmd.Parameters.AddWithValue("@39", txtVAStotal.Text)
            cmd.Parameters.AddWithValue("@40", RoomID) : cmd.Parameters.AddWithValue("@41", Val(txtInvoiceID.Text))
            If cmd.ExecuteNonQuery() > 0 Then
                MsgBox("Record Insert Succesfully", MsgBoxStyle.Information, "Saved")
                txtID.Text = clsFun.ExecScalarInt("Select Max(ID) from Vouchers")
                clsFun.ExecScalarStr("Update Vouchers set ISBooked='" & Val(txtID.Text) & "' Where ID='" & Val(txtBookingID.Text) & "'")
                dg1Record() : VASRecord() : Ledger()
                textclearall()
                ' clearTxtAll()
            End If
            clsFun.CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message)
            clsFun.CloseConnection()
        End Try
    End Sub
    Private Sub Ledger()
        ' Change the format:
        SqliteEntryDate = CDate(mskBookingdate.Text).ToString("yyyy-MM-dd")
        If Val(txtAdvanceRecieved.Text) > 0 Then ''Sale Account Fixed
            clsFun.Ledger(0, Val(txtID.Text), SqliteEntryDate, Me.Text, 58, clsFun.ExecScalarStr("Select AccountName from Accounts where Id=58"), Val(txtAdvanceRecieved.Text), "C", txtCheckInNo.Text & " - " & txtGuestName.Text)
            clsFun.Ledger(0, Val(txtID.Text), SqliteEntryDate, Me.Text, Val(7), clsFun.ExecScalarStr("Select AccountName from Accounts where Id=7"), Val(txtAdvanceRecieved.Text), "D", txtCheckInNo.Text & " - " & txtGuestName.Text)
        End If
    End Sub
    Private Sub dg1Record()
        Dim sql As String = String.Empty
        vchID = txtID.Text
        For Each row As DataGridViewRow In dg1.Rows
            With row
                If .Cells(0).Value = True Then
                    sql = sql & ""
                    sql = sql & "INSERT INTO Trans (TransType,VoucherID,RoomID,RoomNo,Rate,DisPer,DisAmt,BasicAmt) values('" & Me.Text & "','" & Val(vchID) & "'," & _
                        "'" & .Cells(1).Value & "', '" & Val(.Cells(2).Value) & "','" & .Cells(5).Value & "','" & .Cells(6).Value & "', " & _
                         "'" & Val(.Cells(7).Value) & "','" & Val(.Cells(8).Value) & "');"
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

    Private Sub VASRecord()
        Dim sql As String = String.Empty
        vchID = txtID.Text
        For Each row As DataGridViewRow In dgVas.Rows
            With row
                If .Cells(0).Value <> Val(0) Then
                    sql = sql & ""
                    sql = sql & "INSERT INTO VASTrans (VoucherID,VASID,VASName,OnValue,Rate,Amount) values('" & Val(vchID) & "'," & _
                        "'" & .Cells(0).Value & "', '" & .Cells(1).Value & "','" & .Cells(2).Value & "','" & .Cells(3).Value & "', " & _
                         "'" & Val(.Cells(4).Value) & "');"
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
    Private Sub textclearall()
        VNumber()
        txtGuestName.Clear() : txtGuestMobileNo.Clear() : txtBdate.Clear() : txtNationalitiy.Clear()
        txtStayDays.Clear() : txtMale.Clear() : txtFemale.Clear() : txtKids.Clear() : txtAddress.Clear()
        txtDistrict.Clear() : txtPinCode.Clear() : txtCompanyName.Clear() : txtContactNo.Clear() : txtBusinessAdd.Clear()
        txtEmail.Clear() : txtWebsite.Clear() : txtGSTN.Clear() : txtDocumentNo.Clear()
        txtRemark.Clear() : txtAdvanceRecieved.Clear() : txtCommingFrom.Clear() : txtGoingTo.Clear() : txtVisitPurpose.Clear()
        txtCheckInNo.Focus() : TxtRentAmount.Clear() : txtDiscAmt.Clear() : txtAdvanceRecieved.Clear() : TxtTotal.Clear() : txtDueAmount.Clear()
        BtnSave.Text = "&Save" : ckBooking.Checked = False
        retrive()
        dg1.ClearSelection()
    End Sub
    Private Sub Update()
        If clsFun.ExecScalarStr("Select * From Vouchers Where ID='" & Val(txtID.Text) & "' and ISBooked is Not Null") <> "" Then
            MsgBox("Can't Modify After Check Out Bill is Done ", vbCritical, "Access Denid") : Exit Sub
        End If
        Dim cmd As SQLite.SQLiteCommand
        Dim RoomID As String = String.Empty
        Dim RoomNo As String = String.Empty
        Dim checkBox As DataGridViewCheckBoxCell
        For Each row As DataGridViewRow In dg1.Rows
            checkBox = (TryCast(row.Cells("checkBoxColumn"), DataGridViewCheckBoxCell))
            If checkBox.Value = True Then
                RoomID = RoomID & row.Cells(1).Value & ","
                RoomNo = RoomNo & row.Cells(2).Value & ","
            End If
        Next
        If RoomID <> "" Then
            RoomID = RoomID.Remove(RoomID.LastIndexOf(","))
            RoomNo = RoomNo.Remove(RoomNo.LastIndexOf(","))
            clsFun.ExecScalarStr("Update Room Set ISOccupied='Y' Where ID in(" & RoomID & ")")
        Else
            MsgBox("Please Select At Leat 1 Room for Booking...", vbCritical, "Choose Room") : Exit Sub
        End If
        If txtGuestName.Text = "" Then
            txtGuestName.Focus()
            MsgBox("Please Fill Guest Name ... ", MsgBoxStyle.Exclamation, "Empty")
            Exit Sub
        End If
        Dim sql As String = "Update Vouchers Set TransType='" & Me.Text & "', InvoiceNo='" & txtCheckInNo.Text & "', " & _
                            "EntryDate='" & CDate(mskBookingdate.Text).ToString("yyyy-MM-dd") & "',PackageID='" & Val(cbPackage.SelectedValue) & "', " & _
                            "Title='" & CbTitle.Text & "',CustomerName='" & txtGuestName.Text & "',CustomerMobile='" & txtGuestMobileNo.Text & "', " & _
                            "DateofBirth='" & txtBdate.Text & "', Gender='" & CbGender.Text & "',Nationality='" & txtNationalitiy.Text & "', " & _
                            "CheckinDate='" & CDate(mskBookingdate.Text).ToString("yyyy-MM-dd") & "',CheckinTime='" & dtpTime.Text & "'," & _
                            "StayDays='" & Val(txtStayDays.Text) & "',Male='" & Val(txtMale.Text) & "',Female='" & Val(txtFemale.Text) & "',Kids='" & Val(txtKids.Text) & "', " & _
                            "CompanyName='" & txtCompanyName.Text & "', CompanyContact='" & txtContactNo.Text & "',CompanyAdd='" & txtBusinessAdd.Text & "', " & _
                            "Email='" & txtEmail.Text & "',Website='" & txtWebsite.Text & "',BusinessSourceID='" & Val(cbBusinessSources.SelectedValue) & "', " & _
                            "DocumentType='" & cbDocumentType.Text & "',DocumentNo='" & txtDocumentNo.Text & "',Remark='" & txtRemark.Text & "', " & _
                            "RoomRentAmount='" & Val(TxtRentAmount.Text) & "',TotalDiscAmt='" & Val(txtDiscAmt.Text) & "',VasAmt='" & Val(txtVAStotal.Text) & "',TotalGrandAmt='" & TxtTotal.Text & "', " & _
                            "TotalCashAmt='" & txtAdvanceRecieved.Text & "',TotalBalAmt='" & txtDueAmount.Text & "',RoomNos='" & RoomNo & "',RoomIDs='" & RoomID & "', " & _
                            "CommingFrom='" & txtCommingFrom.Text & "',GoingTo='" & txtGoingTo.Text & "',VisitPurpose='" & txtVisitPurpose.Text & "', " & _
                            "CustomerAddress='" & txtAddress.Text & "',CustomerCity='" & txtDistrict.Text & "',PinCode='" & txtPinCode.Text & "', " & _
                            "StateID='" & Val(cbState.SelectedValue) & "',CustomerGSTN='" & txtGSTN.Text & "',InvoiceID='" & Val(txtInvoiceID.Text) & "' Where ID='" & Val(txtID.Text) & "'"
        cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
        Try
            If clsFun.ExecNonQuery(sql) > 0 Then
                clsFun.ExecScalarStr("Delete From Trans Where VoucherID=" & Val(txtID.Text) & "")
                clsFun.ExecScalarStr("Delete From VASTrans Where VoucherID=" & Val(txtID.Text) & "")
                clsFun.ExecScalarStr("Delete From Ledger Where VouchersID=" & Val(txtID.Text) & "")
                dg1Record() : VASRecord() : Ledger() : textclearall()
                MessageBox.Show("Record Updated SuccesFully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If BtnSave.Text = "&Save" Then
            save() : MainScreenPicture.RetriveGroups()
        Else
            Update() : MainScreenPicture.RetriveGroups()
        End If
        FillData() : PrintRecord()
        Report_Viewer.printReport("\Checkin.rpt")
        Report_Viewer.MdiParent = MainScreenForm
        Report_Viewer.Show()
        If Not Report_Viewer Is Nothing Then
            Report_Viewer.BringToFront()
        End If
    End Sub
    Private Sub PrintRecord()
        Dim count As Integer = 0
        Dim cmd As New SQLite.SQLiteCommand
        Dim sql As String = String.Empty
        ClsFunPrimary.ExecNonQuery("Delete from printing")
        ' clsFun.ExecNonQuery(sql)
        For Each row As DataGridViewRow In tempdt.Rows
            With row
                sql = sql & "insert into Printing(D1,M1,M2,M3,M4,P1,P2,P3,P4,P5,P6,P7,P8,P9,P10,P11,P12,P13,P14,P15,P16,P17,P18,P19,P20,P21,P22,P23,P24,P25, " & _
                    "P26,P27,P28,P29,P30,P31,P32,P33,P34,P35,P36,P37,P38,P39)" & _
           "  values('" & .Cells(0).Value & "','" & .Cells(1).Value & "','" & .Cells(2).Value & "','" & .Cells(3).Value & "','" & .Cells(4).Value & "', " & _
           "'" & .Cells(5).Value & "','" & .Cells(6).Value & "','" & .Cells(7).Value & "','" & .Cells(8).Value & "','" & .Cells(9).Value & "'," & _
           "'" & .Cells(10).Value & "','" & .Cells(11).Value & "','" & .Cells(12).Value & "','" & .Cells(13).Value & "','" & .Cells(14).Value & "'," & _
           "'" & .Cells(15).Value & "','" & .Cells(16).Value & "','" & .Cells(17).Value & "','" & .Cells(18).Value & "','" & .Cells(19).Value & "'," & _
           "'" & .Cells(20).Value & "','" & .Cells(21).Value & "','" & .Cells(22).Value & "','" & .Cells(23).Value & "','" & .Cells(24).Value & "'," & _
           "'" & .Cells(25).Value & "','" & .Cells(26).Value & "','" & .Cells(27).Value & "','" & .Cells(28).Value & "','" & .Cells(29).Value & "'," & _
           "'" & .Cells(30).Value & "','" & .Cells(31).Value & "','" & .Cells(32).Value & "','" & .Cells(33).Value & "','" & .Cells(34).Value & "'," & _
           "'" & .Cells(35).Value & "','" & .Cells(36).Value & "','" & .Cells(37).Value & "','" & .Cells(38).Value & "','" & .Cells(39).Value & "'," & _
           "'" & .Cells(40).Value & "','" & .Cells(41).Value & "','" & .Cells(42).Value & "','" & .Cells(43).Value & "');"
                'End If
            End With


        Next
        Try
            cmd = New SQLite.SQLiteCommand(sql, ClsFunPrimary.GetConnection())
            ClsFunPrimary.ExecNonQuery(sql)
            'If cmd.ExecuteNonQuery() > 0 Then

            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
            ClsFunPrimary.CloseConnection()
        End Try
        ' clsFun.ExecNonQuery(sql)
    End Sub
    Private Sub btnClearBooking_Click(sender As Object, e As EventArgs) Handles btnClearBooking.Click
        textclearall() : txtGuestName.Focus()
        pnlBooking.Visible = False

    End Sub
    Private Sub VASColumns()
        dgVas.ColumnCount = 5
        dgVas.Columns(0).Name = "VASID" : dgVas.Columns(0).Visible = False
        dgVas.Columns(1).Name = "VAS Name." : dgVas.Columns(1).Width = 220
        dgVas.Columns(2).Name = "On Value" : dgVas.Columns(2).Width = 95
        dgVas.Columns(3).Name = "@" : dgVas.Columns(3).Width = 95
        dgVas.Columns(4).Name = "Amount" : dgVas.Columns(4).Width = 142
        clsFun.FillDropDownList(cbVAS, "Select ID,VASName From VAS", "VASName", "Id", "")
    End Sub
    Private Sub btnAddVAS_Click(sender As Object, e As EventArgs) Handles btnAddVAS.Click
        If pnlVAS.Visible = False Then
            VASColumns() : cbVAS.Focus()
            pnlVAS.Visible = True
            pnlVAS.BringToFront()
        ElseIf pnlVAS.Visible = True Then
            pnlVAS.Visible = False
        End If
    End Sub

    Private Sub cbVAS_KeyDown(sender As Object, e As KeyEventArgs) Handles cbVAS.KeyDown, txtonValue.KeyDown, txtVASRate.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txtVASAmt_KeyDown(sender As Object, e As KeyEventArgs) Handles txtVASAmt.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If dgVas.SelectedRows.Count = 1 Then
                If cbVAS.Text = "" Then MsgBox("Please Select VAS Name...", vbCritical, "") : cbVAS.SelectedIndex = 0 : cbVAS.Focus() : Exit Sub
                dgVas.SelectedRows(0).Cells(0).Value = cbVAS.SelectedValue
                dgVas.SelectedRows(0).Cells(1).Value = cbVAS.Text
                dgVas.SelectedRows(0).Cells(2).Value = txtonValue.Text
                dgVas.SelectedRows(0).Cells(3).Value = txtVASRate.Text
                dgVas.SelectedRows(0).Cells(4).Value = txtVASAmt.Text
                VasTxtClear()
            Else
                If cbVAS.Text = "" Then MsgBox("Please Select VAS Name...", vbCritical, "") : cbVAS.SelectedIndex = 0 : cbVAS.Focus() : Exit Sub
                dgVas.Rows.Add(Val(cbVAS.SelectedValue), cbVAS.Text, Format(Val(txtonValue.Text), "0.00"), Format(Val(txtVASRate.Text), "0.00"), Format(Val(txtVASAmt.Text), "0.00"))
                VasTxtClear()
            End If
        End If
    End Sub
    Private Sub VasTxtClear()
        txtonValue.Clear() : txtVASRate.Clear()
        txtVASAmt.Clear() : dgVas.ClearSelection()
        cbVAS.Focus() : calcVas()
    End Sub
    Private Sub txtonValue_TextChanged(sender As Object, e As EventArgs) Handles txtonValue.TextChanged, txtVASRate.TextChanged
        txtVASAmt.Text = Format(Val(txtonValue.Text) * Val(txtVASRate.Text), "0.00")
    End Sub

    Private Sub dgVas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgVas.CellDoubleClick
        If dgVas.SelectedRows.Count = 0 Then Exit Sub
        cbVAS.Text = dgVas.SelectedRows(0).Cells(1).Value
        txtonValue.Text = dgVas.SelectedRows(0).Cells(2).Value
        txtVASRate.Text = dgVas.SelectedRows(0).Cells(3).Value
        txtVASAmt.Text = dgVas.SelectedRows(0).Cells(4).Value
    End Sub
    Private Sub calcVas()
        txtVAStotal.Text = Format(0, "0.00")
        For i = 0 To dgVas.Rows.Count - 1
            txtVAStotal.Text = Format(Val(txtVAStotal.Text) + Val(dgVas.Rows(i).Cells(4).Value), "0.00")
        Next
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

    Private Sub TxtRentAmount_TextChanged(sender As Object, e As EventArgs) Handles TxtRentAmount.TextChanged,
        txtVAStotal.TextChanged, txtDiscAmt.TextChanged
        TxtTotal.Text = Format(Val(Val(TxtRentAmount.Text) - Val(txtDiscAmt.Text)) + Val(txtVAStotal.Text), "0.00")
    End Sub

    Private Sub txtAdvanceRecieved_TextChanged(sender As Object, e As EventArgs) Handles txtAdvanceRecieved.TextChanged, TxtTotal.TextChanged
        txtDueAmount.Text = Format(Val(TxtTotal.Text) - Val(txtAdvanceRecieved.Text), "0.00")
    End Sub


    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        Delete()
    End Sub
    Private Sub Delete()
        If clsFun.ExecScalarStr("Select Count(*) From Vouchers  Where ISBooked is Not null And  ID='" & Val(txtID.Text) & "'") Then
            MsgBox("Can't Delete Booking Entry, Because Booking Already Converted In Check In Entry", MsgBoxStyle.Critical, "Check In Entry")
            Exit Sub
        End If
        Try
            If MessageBox.Show("Are you Sure Want to Delete Check In Entry ??", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                clsFun.ExecNonQuery("DELETE from Vouchers WHERE ID=" & Val(txtID.Text) & "")
                clsFun.ExecNonQuery("DELETE from Ledger WHERE vouchersID=" & Val(txtID.Text) & "")
                clsFun.ExecNonQuery("DELETE from Trans WHERE voucherID=" & Val(txtID.Text) & "")
                clsFun.ExecNonQuery("DELETE from VASTrans WHERE voucherID=" & Val(txtID.Text) & "")
                clsFun.ExecScalarStr("Update Vouchers set ISBooked = null Where ID='" & Val(txtID.Text) & "'")
                MsgBox("Check In Entry Deleted Successfully.", vbInformation + vbOKOnly, "Deleted")
                textclearall()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtGuestName_TextChanged(sender As Object, e As EventArgs) Handles txtGuestName.TextChanged

    End Sub

    Private Sub txtRemark_TextChanged(sender As Object, e As EventArgs) Handles txtRemark.TextChanged

    End Sub

    Private Sub txtCheckInNo_TextChanged(sender As Object, e As EventArgs) Handles txtCheckInNo.TextChanged

    End Sub
End Class