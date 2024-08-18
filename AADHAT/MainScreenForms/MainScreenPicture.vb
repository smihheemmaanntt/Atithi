Imports System.Collections 'For arraylist
Public Class MainScreenPicture
    Dim rs As New Resizer
    Private CtlArray As New ArrayList
    Dim intX, intY As Integer
    Dim Xratio, Yratio As Single
    Private Sub MainScreenPicture_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' rs.FindAllControls(Me)
        Me.Top = 0 : Me.Left = 0
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        lblOrgName.Text = clsFun.ExecScalarStr("Select CompanyName from Company").ToUpper
        Dim Yearend As String = clsFun.ExecScalarStr("Select YearEnd from Company").ToUpper
        Dim YearStart As String = clsFun.ExecScalarStr("Select YearStart from Company").ToUpper
        lblFinYear.Text = CDate(YearStart).Year & " - " & CDate(Yearend).Year
        lblCity.Text = clsFun.ExecScalarStr("Select City from Company").ToUpper
        Dashboard() : RetriveGroups() : RestroTables() ': RoomColorChange()
    End Sub
    Public Sub Dashboard()
        '  Application.DoEvents()
        lblTotalBooking.Text = Val(clsFun.ExecScalarStr("Select Count(*) from Vouchers Where TransType='Booking' And EntryDate='" & CDate(Date.Now).ToString("yyyy-MM-dd") & "'"))
        lblTotalCheckIn.Text = Val(clsFun.ExecScalarStr("Select Count(*) from Vouchers Where TransType='Check In' And EntryDate='" & CDate(Date.Now).ToString("yyyy-MM-dd") & "'"))
        LblTotalCheckOut.Text = Val(clsFun.ExecScalarStr("Select Count(*) from Vouchers Where TransType='Check Out' And EntryDate='" & CDate(Date.Now).ToString("yyyy-MM-dd") & "'"))
        lblTbleTotal.Text = Val(clsFun.ExecScalarStr("Select Count(*) FROM KOT Where EntryDate='" & CDate(Date.Now).ToString("yyyy-MM-dd") & "'"))
        lblTotalFood.Text = Val(clsFun.ExecScalarStr("Select Count(*) from Vouchers Where TransType='Food Bill' And EntryDate='" & CDate(Date.Now).ToString("yyyy-MM-dd") & "'"))

    End Sub
    Public Sub RetriveGroups()
        FlowLayoutPanel1.Controls.Clear()
        Dim btn As New Button
        dt = clsFun.ExecDataTable("SELECT ID,RoomName,ISOccupied FROM Room")
        Dim i As Integer
        For i = 0 To dt.Rows.Count - 1
            Application.DoEvents()
            If dt.Rows(i)("ISOccupied").ToString() = "Y" Then
                btn = New Button
                btn.Width = 120
                btn.Height = 60
                btn.Text = dt.Rows(i)("RoomName").ToString()
                btn.Name = "Btn" & dt.Rows(i)("ID").ToString()
                btn.BackColor = Color.SeaGreen : btn.ForeColor = Color.GhostWhite
                btn.TextAlign = ContentAlignment.MiddleCenter
                btn.FlatStyle = FlatStyle.Flat
                btn.Visible = True
                FlowLayoutPanel1.Controls.Add(btn)
            Else
                btn = New Button
                btn.Width = 120
                btn.Height = 60
                btn.Text = dt.Rows(i)("RoomName").ToString()
                btn.Name = "Btn" & dt.Rows(i)("ID").ToString()
                btn.BackColor = Color.SteelBlue : btn.ForeColor = Color.GhostWhite
                btn.TextAlign = ContentAlignment.MiddleCenter
                btn.FlatStyle = FlatStyle.Flat
                btn.Visible = True
                FlowLayoutPanel1.Controls.Add(btn)
                'AddHandler btn.Click, AddressOf clickme
            End If

        Next
        'Dim Booked As String = clsFun.ExecScalarStr("Select RoomID FROM Vouchers as V left join Trans T on t.VoucherID=v.ID  " & _
        '                     "Where RoomID='" & Val(dt.Rows(i)("ID").ToString()) & "' and " & _
        '                     "V.TransType ='Booking' and EntryDate='" & CDate(Date.Now).ToString("yyyy-MM-dd") & "'")
        'Dim CheckIn As String = clsFun.ExecScalarStr("Select RoomID FROM Vouchers as V left join Trans T on t.VoucherID=v.ID  " & _
        '                     "Where RoomID='" & Val(dt.Rows(i)("ID").ToString()) & "' and " & _
        '                     "V.TransType ='Check In' and EntryDate='" & CDate(Date.Now).ToString("yyyy-MM-dd") & "'")

        'If Booked = dt.Rows(i)("ID").ToString() Then
        '    btn.BackColor = Color.Turquoise : btn.ForeColor = Color.GhostWhite
        'Else
        '    btn.BackColor = Color.CadetBlue : btn.ForeColor = Color.GhostWhite
        'End If
        'If CheckIn = dt.Rows(i)("ID").ToString() Then
        '    btn.BackColor = Color.Red : btn.ForeColor = Color.GhostWhite
        'Else
        '    btn.BackColor = Color.CadetBlue : btn.ForeColor = Color.GhostWhite
        'End If
        '' btn.BackColor = Color.CadetBlue : btn.ForeColor = Color.GhostWhite
        'btn.TextAlign = ContentAlignment.MiddleCenter
        'btn.FlatStyle = FlatStyle.Flat
        'btn.Visible = True
        'FlowLayoutPanel1.Controls.Add(btn)
        'AddHandler btn.Click, AddressOf clickme
        ' Next
    End Sub

    Public Sub RoomColorChange()
        Dim btn As Button
        dt = clsFun.ExecDataTable("Select RoomID,V.TransType FROM Vouchers as V left join Trans T on t.VoucherID=v.ID  Where EntryDate='" & CDate(Date.Now).ToString("yyyy-MM-dd") & "'")
        Dim i As Integer
        For i = 0 To dt.Rows.Count - 1
            Dim RoomID As String = dt.Rows(i)("RoomID").ToString()
            Application.DoEvents()
            For Each ctrl As Control In FlowLayoutPanel1.Controls
                If TypeOf ctrl Is Button Then
                    If btn.Text.StartsWith("Btn" & RoomID) Then

                    End If
                    'ctrl.Color = Color.Red
                End If
            Next
        Next
    End Sub


    Public Sub RestroTables()
        FlowLayoutPanel2.Controls.Clear()
        Dim btn As New Button
        dt = clsFun.ExecDataTable("SELECT * FROM RestroTables ")
        Dim i As Integer
        For i = 0 To dt.Rows.Count - 1
            Application.DoEvents()
            If dt.Rows(i)("IsBooked").ToString() = "Y" Then
                btn = New Button
                btn.Width = 56
                btn.Height = 28
                btn.Text = dt.Rows(i)("TableName").ToString()
                btn.BackColor = Color.SeaGreen : btn.ForeColor = Color.GhostWhite
                btn.TextAlign = ContentAlignment.MiddleCenter
                btn.FlatStyle = FlatStyle.Flat
                btn.Visible = True
                FlowLayoutPanel2.Controls.Add(btn)
            Else
                btn = New Button
                btn.Width = 56
                btn.Height = 28
                btn.Text = dt.Rows(i)("TableName").ToString()
                btn.BackColor = Color.SteelBlue : btn.ForeColor = Color.GhostWhite
                btn.TextAlign = ContentAlignment.MiddleCenter
                btn.FlatStyle = FlatStyle.Flat
                btn.Visible = True
                FlowLayoutPanel2.Controls.Add(btn)
                'AddHandler btn.Click, AddressOf clickme
            End If

        Next
    End Sub
 
    Private Sub MainScreenPicture_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        '  rs.ResizeAllControls(Me)
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub FlowLayoutPanel2_Paint(sender As Object, e As PaintEventArgs) Handles FlowLayoutPanel2.Paint

    End Sub

    Private Sub FlowLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles FlowLayoutPanel1.Paint

    End Sub

    Private Sub btnRefreshRoom_Click(sender As Object, e As EventArgs) Handles btnRefreshRoom.Click
        RetriveGroups()
    End Sub

    Private Sub btnRefreshTables_Click(sender As Object, e As EventArgs) Handles btnRefreshTables.Click
        RestroTables()
    End Sub
End Class