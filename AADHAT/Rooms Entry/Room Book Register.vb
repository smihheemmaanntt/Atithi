Public Class Room_Booking_Register

    Private Sub Room_Booking_Register_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub
    Private Sub Room_Booking_Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0 : Me.Left = 0
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Dim mindate, maxdate As String
        mindate = clsFun.ExecScalarStr("select Max(EntryDate) as entrydate from Vouchers Where TransType='Room Book'")
        maxdate = clsFun.ExecScalarStr("select Max(EntryDate) as entrydate from Vouchers Where TransType='Room Book'")
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
    Private Sub rowColums()
        dg1.ColumnCount = 10
        dg1.Columns(0).Name = "ID" : dg1.Columns(0).Visible = False
        dg1.Columns(1).Name = "Book Date" : dg1.Columns(1).Width = 100
        dg1.Columns(2).Name = "Rooms" : dg1.Columns(2).Width = 80
        dg1.Columns(3).Name = "CheckIn" : dg1.Columns(3).Width = 150
        dg1.Columns(4).Name = "Guest Name" : dg1.Columns(4).Width = 200
        dg1.Columns(5).Name = "Package" : dg1.Columns(5).Width = 100
        dg1.Columns(6).Name = "Company Name" : dg1.Columns(6).Width = 130
        dg1.Columns(7).Name = "Mobile" : dg1.Columns(7).Width = 80
        dg1.Columns(8).Name = "City" : dg1.Columns(8).Width = 150
        dg1.Columns(9).Name = "Nationality" : dg1.Columns(9).Width = 180
    End Sub
    Private Sub retrive(Optional ByVal condtion As String = "")
        dg1.Rows.Clear()
        Dim dt As New DataTable
        '  dt = clsFun.ExecDataTable("SELECT * FROM Vouchers AS V LEFT JOIN Package P ON V.PackageID = P.ID  Where TransType='Room Book' and EntryDate Between '" & CDate(mskFromDate.Text).ToString("yyyy-MM-dd") & "' And '" & CDate(MsktoDate.Text).ToString("yyyy-MM-dd") & "' " & condtion & "  order by ID ")
        If ckCheckOutCustomers.Checked = True Then
            dt = clsFun.ExecDataTable("SELECT * FROM Vouchers AS V LEFT JOIN Package P ON V.PackageID = P.ID  Where TransType='Room Book'and ISBooked IS not NUll  and EntryDate Between '" & CDate(mskFromDate.Text).ToString("yyyy-MM-dd") & "' And '" & CDate(MsktoDate.Text).ToString("yyyy-MM-dd") & "' " & condtion & "  order by ID ")
        Else
            dt = clsFun.ExecDataTable("SELECT * FROM Vouchers AS V LEFT JOIN Package P ON V.PackageID = P.ID  Where TransType='Room Book' and ISBooked IS NUll and EntryDate Between '" & CDate(mskFromDate.Text).ToString("yyyy-MM-dd") & "' And '" & CDate(MsktoDate.Text).ToString("yyyy-MM-dd") & "' " & condtion & "  order by ID ")
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
                        .Cells(3).Value = CDate(dt.Rows(i)("CheckinDate")).tostring("dd-MM-yyyy") & " - " & dt.Rows(i)("CheckInTime").ToString()
                        .Cells(4).Value = dt.Rows(i)("CustomerName").ToString()
                        .Cells(5).Value = dt.Rows(i)("PackageName").ToString()
                        .Cells(6).Value = dt.Rows(i)("CompanyName").ToString()
                        .Cells(7).Value = dt.Rows(i)("CustomerMobile").ToString()
                        .Cells(8).Value = dt.Rows(i)("CustomerCity").ToString()
                        .Cells(9).Value = dt.Rows(i)("Nationality").ToString()
                    End With

                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "Athiti")
        End Try
        dg1.ClearSelection()
        'lblTotal.Visible = True
        'lblTotal.Text = "POS Bills : " & Val(dg1.RowCount)
    End Sub
    Private Sub dg1_KeyDown(sender As Object, e As KeyEventArgs) Handles dg1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dg1.SelectedRows.Count = 0 Then Exit Sub
            Dim tmpID As Integer = Val(dg1.SelectedRows(0).Cells(0).Value)
            Room_Reservaration.MdiParent = MainScreenForm
            Room_Reservaration.Show()
            Room_Reservaration.FillControls(tmpID)
            If Not Room_Reservaration Is Nothing Then
                Room_Reservaration.BringToFront()
            End If
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub dg1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dg1.MouseDoubleClick
        If dg1.SelectedRows.Count = 0 Then Exit Sub
        Dim tmpID As Integer = Val(dg1.SelectedRows(0).Cells(0).Value)
        Room_Reservaration.MdiParent = MainScreenForm
        Room_Reservaration.Show()
        Room_Reservaration.FillControls(tmpID)
        If Not Room_Reservaration Is Nothing Then
            Room_Reservaration.BringToFront()
        End If
    End Sub
   

    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        retrive()
    End Sub
  
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
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

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click

    End Sub
End Class