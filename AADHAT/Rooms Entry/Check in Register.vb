Public Class Check_in_Register

    Private Sub Room_Booking_Register_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub
    Private Sub Room_Booking_Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0 : Me.Left = 0
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Dim mindate, maxdate As String
        mindate = clsFun.ExecScalarStr("select Max(EntryDate) as entrydate from Vouchers Where TransType='Check In'  ")
        maxdate = clsFun.ExecScalarStr("select Max(EntryDate) as entrydate from Vouchers Where TransType='Check In'")
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
        mskFromDate.Focus()
        rowColums()
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
        mskFromDate.SelectAll()
    End Sub
    Private Sub MsktoDate_GotFocus(sender As Object, e As EventArgs) Handles MsktoDate.GotFocus, MsktoDate.Click
        MsktoDate.SelectAll()
    End Sub
    Private Sub mskFromDate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mskFromDate.Validating
        mskFromDate.Text = clsFun.convdate(mskFromDate.Text)
    End Sub
  
    Private Sub MsktoDate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MsktoDate.Validating
        MsktoDate.Text = clsFun.convdate(MsktoDate.Text)
    End Sub

    Private Sub rowColums()
        dg1.ColumnCount = 16
        dg1.Columns(0).Name = "ID" : dg1.Columns(0).Visible = False
        dg1.Columns(1).Name = "CheckIn Date" : dg1.Columns(1).Width = 100
        dg1.Columns(2).Name = "Rooms" : dg1.Columns(2).Width = 100
        dg1.Columns(3).Name = "Time" : dg1.Columns(3).Width = 100
        dg1.Columns(4).Name = "Guest Name" : dg1.Columns(4).Width = 250
        dg1.Columns(5).Name = "Package" : dg1.Columns(5).Visible = False
        dg1.Columns(6).Name = "Company Name" : dg1.Columns(6).Visible = False
        dg1.Columns(7).Name = "Mobile" : dg1.Columns(7).Width = 140
        dg1.Columns(8).Name = "City" : dg1.Columns(8).Visible = False
        dg1.Columns(9).Name = "Nationality" : dg1.Columns(9).Visible = False
        dg1.Columns(10).Name = "Rent" : dg1.Columns(10).Width = 80
        dg1.Columns(11).Name = "Disc" : dg1.Columns(11).Width = 80
        dg1.Columns(12).Name = "VAS" : dg1.Columns(12).Width = 80
        dg1.Columns(13).Name = "Total" : dg1.Columns(13).Width = 80
        dg1.Columns(14).Name = "Advance" : dg1.Columns(14).Width = 80
        dg1.Columns(15).Name = "Due" : dg1.Columns(15).Width = 80
    End Sub
    Private Sub retrive(Optional ByVal condtion As String = "")
        dg1.Rows.Clear()
        Dim dt As New DataTable
        If ckCheckOutCustomers.Checked = True Then
            dt = clsFun.ExecDataTable("SELECT * FROM Vouchers AS V LEFT JOIN Package P ON V.PackageID = P.ID  Where TransType='Check In' and ISBooked IS NUll and EntryDate Between '" & CDate(mskFromDate.Text).ToString("yyyy-MM-dd") & "' And '" & CDate(MsktoDate.Text).ToString("yyyy-MM-dd") & "' " & condtion & "  order by ID ")
        Else
            dt = clsFun.ExecDataTable("SELECT * FROM Vouchers AS V LEFT JOIN Package P ON V.PackageID = P.ID  Where TransType='Check In'and ISBooked IS not NUll  and EntryDate Between '" & CDate(mskFromDate.Text).ToString("yyyy-MM-dd") & "' And '" & CDate(MsktoDate.Text).ToString("yyyy-MM-dd") & "' " & condtion & "  order by ID ")
        End If

        Dim vchid As Integer = 0
        Try
            If dt.Rows.Count > 0 Then
                dg1.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("ID").ToString()
                        .Cells(1).Value = CDate(dt.Rows(i)("EntryDate")).tostring("dd-MM-yyyy")
                        .Cells(2).Value = dt.Rows(i)("RoomNos").ToString()
                        .Cells(3).Value = dt.Rows(i)("CheckInTime").ToString()
                        .Cells(4).Value = dt.Rows(i)("CustomerName").ToString()
                        .Cells(5).Value = dt.Rows(i)("PackageName").ToString()
                        .Cells(6).Value = dt.Rows(i)("CompanyName").ToString()
                        .Cells(7).Value = dt.Rows(i)("CustomerMobile").ToString()
                        .Cells(8).Value = dt.Rows(i)("CustomerCity").ToString()
                        .Cells(9).Value = dt.Rows(i)("Nationality").ToString()
                        .Cells(10).Value = Format(Val(dt.Rows(i)("RoomRentAmount").ToString()), "0.00")
                        .Cells(11).Value = Format(Val(dt.Rows(i)("TotalDiscAmt").ToString()), "0.00")
                        .Cells(12).Value = Format(Val(dt.Rows(i)("VasAmt").ToString()), "0.00")
                        .Cells(13).Value = Format(Val(dt.Rows(i)("TotalGrandAmt").ToString()), "0.00")
                        .Cells(14).Value = Format(Val(dt.Rows(i)("TotalCashAmt").ToString()), "0.00")
                        .Cells(15).Value = Format(Val(dt.Rows(i)("TotalbalAmt").ToString()), "0.00")
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

    Private Sub dg1_KeyDown(sender As Object, e As KeyEventArgs) Handles dg1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dg1.SelectedRows.Count = 0 Then Exit Sub
            Dim tmpID As Integer = Val(dg1.SelectedRows(0).Cells(0).Value)
            Room_Check_In.MdiParent = MainScreenForm
            Room_Check_In.Show()
            Room_Check_In.FillControls(tmpID)
            If Not Room_Check_In Is Nothing Then
                Room_Check_In.BringToFront()
            End If
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub dg1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dg1.MouseDoubleClick
        If dg1.SelectedRows.Count = 0 Then Exit Sub
        Dim tmpID As Integer = Val(dg1.SelectedRows(0).Cells(0).Value)
        Room_Check_In.MdiParent = MainScreenForm
        Room_Check_In.Show()
        Room_Check_In.FillControls(tmpID)
        If Not Room_Check_In Is Nothing Then
            Room_Check_In.BringToFront()
        End If
    End Sub
    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        retrive()
    End Sub
    Sub calc()
        TxtRentAmount.Text = Format(0, "0.00") : txtDiscAmt.Text = Format(0, "0.00")
        txtVAStotal.Text = Format(0, "0.00") : TxtTotal.Text = Format(0, "0.00")
        txtAdvanceRecieved.Text = Format(0, "0.00") : txtDueAmount.Text = Format(0, "0.00")

        For i = 0 To dg1.Rows.Count - 1
            TxtRentAmount.Text = Format(Val(TxtRentAmount.Text) + Val(dg1.Rows(i).Cells(10).Value), "0.00")
            txtDiscAmt.Text = Format(Val(txtDiscAmt.Text) + Val(dg1.Rows(i).Cells(11).Value), "0.00")
            txtVAStotal.Text = Format(Val(txtVAStotal.Text) + Val(dg1.Rows(i).Cells(12).Value), "0.00")
            TxtTotal.Text = Format(Val(TxtTotal.Text) + Val(dg1.Rows(i).Cells(13).Value), "0.00")
            txtAdvanceRecieved.Text = Format(Val(txtAdvanceRecieved.Text) + Val(dg1.Rows(i).Cells(14).Value), "0.00")
            txtDueAmount.Text = Format(Val(txtDueAmount.Text) + Val(dg1.Rows(i).Cells(15).Value), "0.00")
        Next
        '   calculation()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub mskFromDate_KeyDown(sender As Object, e As KeyEventArgs) Handles mskFromDate.KeyDown, MsktoDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
            e.SuppressKeyPress = True
        End If
        If e.KeyCode = Keys.Space Then
            If ckCheckOutCustomers.Checked = True Then
                ckCheckOutCustomers.Checked = False
            Else
                ckCheckOutCustomers.Checked = False
            End If
        End If
    End Sub
End Class