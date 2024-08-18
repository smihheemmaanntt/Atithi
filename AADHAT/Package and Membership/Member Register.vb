Public Class Member_Register

    Private Sub Member_Register_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub Member_Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.BackColor = Color.Moccasin
        Me.KeyPreview = True
        rowColums()
    End Sub
    Private Sub rowColums()
        dg1.ColumnCount = 7
        dg1.Columns(0).Name = "ID"
        dg1.Columns(0).Visible = False
        dg1.Columns(1).Name = "Member Name"
        dg1.Columns(1).Width = 200
        dg1.Columns(2).Name = "member ID"
        dg1.Columns(2).Width = 120
        dg1.Columns(3).Name = "Package"
        dg1.Columns(3).Width = 100
        dg1.Columns(4).Name = "Start Date"
        dg1.Columns(4).Width = 120
        dg1.Columns(5).Name = "Expiry Date"
        dg1.Columns(5).Width = 120
        dg1.Columns(6).Name = "Amount Paid"
        dg1.Columns(6).Width = 130
        retrive()
    End Sub
    Private Sub retrive()
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("Select * from MemberShip")
        Try
            If dt.Rows.Count > 0 Then
                dg1.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("id").ToString()
                        .Cells(1).Value = dt.Rows(i)("AccountName").ToString()
                        .Cells(2).Value = dt.Rows(i)("MemberShipID").ToString()
                        .Cells(3).Value = dt.Rows(i)("PackageName").ToString()
                        .Cells(4).Value = CDate(dt.Rows(i)("StartDate")).ToString("dd-MM-yyyy")
                        .Cells(5).Value = CDate(dt.Rows(i)("ExpiryDate")).ToString("dd-MM-yyyy")
                        .Cells(6).Value = dt.Rows(i)("AmountPaid").ToString()
                    End With
                    ' Dg1.Rows.Add()
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "AADHAT")
        End Try
        dg1.ClearSelection()
    End Sub

    Private Sub dg1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg1.CellClick
        Membership.MdiParent = MainScreenForm
        Membership.Show()
        If dg1.SelectedRows.Count = 0 Then Exit Sub
        Dim tmpID As Integer = Val(dg1.SelectedRows(0).Cells(0).Value)
        Membership.FillControls(tmpID)
        If Not Membership Is Nothing Then
            Membership.BringToFront()
        End If
    End Sub

    Private Sub dg1_KeyDown(sender As Object, e As KeyEventArgs) Handles dg1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Membership.MdiParent = MainScreenForm
            Membership.Show()
            If dg1.SelectedRows.Count = 0 Then Exit Sub
            Dim tmpID As Integer = Val(dg1.SelectedRows(0).Cells(0).Value)
            Membership.FillControls(tmpID)
            If Not Membership Is Nothing Then
                Membership.BringToFront()
            End If
            e.SuppressKeyPress = True
        End If
    End Sub
End Class