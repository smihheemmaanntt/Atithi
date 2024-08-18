Public Class Attender_Register

    Private Sub Attender_Register_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub Attender_Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0 : Me.Left = 0
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True : rowColums()
    End Sub
    Private Sub rowColums()
        dg1.ColumnCount = 8
        dg1.Columns(0).Name = "ID" : dg1.Columns(0).Visible = False
        dg1.Columns(1).Name = "Code" : dg1.Columns(1).Width = 100
        dg1.Columns(2).Name = "AttenderName Name" : dg1.Columns(2).Width = 400
        dg1.Columns(3).Name = "Join Date" : dg1.Columns(3).Width = 100
        dg1.Columns(4).Name = "City" : dg1.Columns(4).Width = 170
        dg1.Columns(5).Name = "State" : dg1.Columns(5).Width = 200
        dg1.Columns(6).Name = "Mobile 1" : dg1.Columns(6).Width = 100
        dg1.Columns(7).Name = "Mobile 2" : dg1.Columns(7).Width = 100
        retrive()
    End Sub
    Private Sub retrive(Optional ByVal condtion As String = "")
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("Select * from Attender " & condtion & "")
        Try
            If dt.Rows.Count > 0 Then
                dg1.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("id").ToString()
                        .Cells(1).Value = dt.Rows(i)("AttenderCode").ToString()
                        .Cells(2).Value = dt.Rows(i)("AttenderName").ToString()
                        .Cells(3).Value = Format(dt.Rows(i)("DOJ"), "dd-MM-yyyy")
                        .Cells(4).Value = dt.Rows(i)("City").ToString() ' & dt.Rows(i)("Dc").ToString()
                        .Cells(5).Value = dt.Rows(i)("State").ToString()
                        .Cells(6).Value = dt.Rows(i)("Mobile1").ToString()
                        .Cells(7).Value = dt.Rows(i)("Mobile2").ToString()
                    End With
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "AADHAT")
        End Try
        lblTotal.Visible = True : dg1.ClearSelection()
        lblTotal.Text = "Total Attenders / Waiters : " & Val(dg1.RowCount)
    End Sub
    Private Sub dg1_KeyDown(sender As Object, e As KeyEventArgs) Handles dg1.KeyDown
        If dg1.SelectedRows.Count = 0 Then Exit Sub
        Dim tmpID As String = dg1.SelectedRows(0).Cells(0).Value
        Attender.MdiParent = MainScreenForm
        Attender.Show()
        Attender.FillControls(tmpID)
        If Not Attender Is Nothing Then
            Attender.BringToFront()
        End If
        e.SuppressKeyPress = True
    End Sub
    Private Sub dg1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dg1.MouseDoubleClick
        If dg1.SelectedRows.Count = 0 Then Exit Sub
        Dim tmpID As String = dg1.SelectedRows(0).Cells(0).Value
        Attender.MdiParent = MainScreenForm
        Attender.Show()
        Attender.FillControls(tmpID)
        If Not Attender Is Nothing Then
            Attender.BringToFront()
        End If
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class