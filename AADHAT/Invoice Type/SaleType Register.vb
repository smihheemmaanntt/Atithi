Public Class Sale_Type_Register

    Private Sub Invoice_Type_Register_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub Invoice_Type_Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.BackColor = Color.Moccasin
        Me.KeyPreview = True
        rowColums()
    End Sub
    Private Sub rowColums()
        dg1.ColumnCount = 4
        dg1.Columns(0).Name = "ID"
        dg1.Columns(0).Visible = False
        dg1.Columns(1).Name = "Invoice Type Name"
        dg1.Columns(1).Width = 300
        dg1.Columns(2).Name = "Account Post"
        dg1.Columns(2).Width = 150
        dg1.Columns(3).Name = "Tax Type"
        dg1.Columns(3).Width = 130
        retrive()
    End Sub
    Private Sub retrive()
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("SELECT * FROM SaleType AS IT INNER JOIN Accounts AS Ac ON IT.AccountID = Ac.ID")
        dg1.Rows.Clear()
        Try
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("id").ToString()
                        .Cells(1).Value = dt.Rows(i)("InvoiceTypeName").ToString()
                        .Cells(2).Value = dt.Rows(i)("AccountName").ToString()
                        .Cells(3).Value = dt.Rows(i)("Taxtype").ToString()
                    End With
                Next
            End If
            dt.Dispose()

        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "Teller")
        End Try
    End Sub

    Private Sub btnRetrive_Click(sender As Object, e As EventArgs) Handles btnRetrive.Click
        retrive()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub dg1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg1.CellContentClick

    End Sub

    Private Sub dg1_KeyDown(sender As Object, e As KeyEventArgs) Handles dg1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dg1.RowCount = 0 Then
                ' btnShow.PerformClick()
                Exit Sub
            End If
            Dim tmpID As String = dg1.SelectedRows(0).Cells(0).Value
            Sale_Type.MdiParent = MainScreenForm
            Sale_Type.Show()
            Sale_Type.FillControls(tmpID)
            If Not Invoice_Type Is Nothing Then
                Sale_Type.BringToFront()
            End If
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub dg1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dg1.MouseDoubleClick
        Dim tmpID As String = dg1.SelectedRows(0).Cells(0).Value
        Sale_Type.MdiParent = MainScreenForm
        Sale_Type.Show()
        Sale_Type.FillControls(tmpID)
        If Not Invoice_Type Is Nothing Then
            Sale_Type.BringToFront()
        End If
    End Sub
End Class