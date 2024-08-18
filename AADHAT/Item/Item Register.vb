Public Class Item_Register
    Private Sub Item_Register_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub
    Private Sub Item_Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0 : Me.Left = 0
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        rowColums()
    End Sub
    Private Sub rowColums()
        dg1.ColumnCount = 11
        dg1.Columns(0).Name = "ID" : dg1.Columns(0).Visible = False
        dg1.Columns(1).Name = "Code" : dg1.Columns(1).Width = 50
        dg1.Columns(2).Name = "Item Name" : dg1.Columns(2).Width = 270
        dg1.Columns(3).Name = "Unit" : dg1.Columns(3).Width = 150
        dg1.Columns(4).Name = "Tax %" : dg1.Columns(4).Width = 100
        dg1.Columns(5).Name = "Table" : dg1.Columns(5).Width = 100
        dg1.Columns(6).Name = "Room" : dg1.Columns(6).Width = 100
        dg1.Columns(7).Name = "POS" : dg1.Columns(7).Width = 100
        dg1.Columns(8).Name = "Bar" : dg1.Columns(8).Width = 100
        dg1.Columns(9).Name = "Away" : dg1.Columns(9).Width = 100
        dg1.Columns(10).Name = "Stock" : dg1.Columns(10).Width = 120

        retrive()
    End Sub
    Private Sub retrive(Optional ByVal condtion As String = "")
        dg1.Rows.Clear()
      
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("Select * from Item_View " & condtion & " Order By ItemName")
        If dt.Rows.Count > 22 Then
            dg1.Columns(10).Name = "Stock" : dg1.Columns(10).Width = 80
        End If
        Try
            If dt.Rows.Count > 0 Then
                dg1.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("id").ToString()
                        .Cells(1).Value = dt.Rows(i)("ItemCode").ToString()
                        .Cells(2).Value = dt.Rows(i)("ItemName").ToString()
                        .Cells(3).Value = dt.Rows(i)("RatePer").ToString()
                        .Cells(4).Value = dt.Rows(i)("TaxName").ToString()
                        .Cells(5).Value = Format(Val(dt.Rows(i)("TableRate").ToString()), "0.00")
                        .Cells(6).Value = Format(Val(dt.Rows(i)("RoomRate").ToString()), "0.00")
                        .Cells(7).Value = Format(Val(dt.Rows(i)("PosRate").ToString()), "0.00")
                        .Cells(8).Value = Format(Val(dt.Rows(i)("BarRate").ToString()), "0.00")
                        .Cells(9).Value = Format(Val(dt.Rows(i)("TakeAwayRate").ToString()), "0.00")
                        .Cells(10).Value = dt.Rows(i)("OPStock").ToString() & " : " & dt.Rows(i)("LooseStock").ToString()
                    End With
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "AADHAT")
        End Try
        dg1.ClearSelection() : lblTotal.Visible = True : lblTotal.Text = "Items : " & Val(dg1.RowCount)
    End Sub
    Private Sub dg1_KeyDown(sender As Object, e As KeyEventArgs) Handles dg1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dg1.RowCount = 0 Then
                ' btnShow.PerformClick()
                Exit Sub
            End If
            If dg1.SelectedRows.Count = 0 Then Exit Sub
            Dim tmpID As Integer = Val(dg1.SelectedRows(0).Cells(0).Value)
            Items.MdiParent = MainScreenForm
            Items.Show()
            Items.FillControls(tmpID)
            If Not ItemsForm Is Nothing Then
                Items.BringToFront()
            End If
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub dg1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dg1.MouseDoubleClick
        If dg1.SelectedRows.Count = 0 Then Exit Sub
        Items.MdiParent = MainScreenForm
        Items.Show()
        Dim tmpID As Integer = Val(dg1.SelectedRows(0).Cells(0).Value)
        Items.FillControls(tmpID)
        If Not Items Is Nothing Then
            Items.BringToFront()
        End If
    End Sub
    Private Sub txtCustomerSearch_KeyUp(sender As Object, e As KeyEventArgs) Handles txtCustomerSearch.KeyUp
        If txtCustomerSearch.Text.Trim() <> "" Then
            retrive(" Where ItemName Like '" & txtCustomerSearch.Text.Trim() & "%'")
        End If
        If txtCustomerSearch.Text.Trim() = "" Then
            retrive()
        End If
        If e.KeyCode = Keys.Down Then dg1.Focus()
    End Sub

    Private Sub txtitemCode_KeyUp(sender As Object, e As KeyEventArgs) Handles txtitemCode.KeyUp
        If txtitemCode.Text.Trim() <> "" Then
            retrive(" where ItemCode Like '" & txtitemCode.Text.Trim() & "%'")
        End If
        If txtitemCode.Text.Trim() = "" Then
            retrive()
        End If
        If e.KeyCode = Keys.Down Then dg1.Focus()
    End Sub
    Private Sub txtUnit_KeyUp(sender As Object, e As KeyEventArgs) Handles txtUnit.KeyUp
        If txtUnit.Text.Trim() <> "" Then
            retrive(" where RatePer Like '" & txtUnit.Text.Trim() & "%'")
        End If
        If txtUnit.Text.Trim() = "" Then
            retrive()
        End If
        If e.KeyCode = Keys.Down Then dg1.Focus()
    End Sub

    Private Sub txtTax_KeyUp(sender As Object, e As KeyEventArgs) Handles txtTax.KeyUp
        If txtTax.Text.Trim() <> "" Then
            retrive(" where TaxName Like '" & txtTax.Text.Trim() & "%'")
        End If
        If txtTax.Text.Trim() = "" Then
            retrive()
        End If
        If e.KeyCode = Keys.Down Then dg1.Focus()
    End Sub

    Private Sub txtTax_TextChanged(sender As Object, e As EventArgs) Handles txtTax.TextChanged

    End Sub

    Private Sub txtPurchase_KeyUp(sender As Object, e As KeyEventArgs) Handles txtPurchase.KeyUp
        If txtPurchase.Text.Trim() <> "" Then
            retrive(" where Purchase Like '" & txtPurchase.Text.Trim() & "%'")
        End If
        If txtPurchase.Text.Trim() = "" Then
            retrive()
        End If
        If e.KeyCode = Keys.Down Then dg1.Focus()
    End Sub

    Private Sub txtSale_KeyUp(sender As Object, e As KeyEventArgs) Handles txtTable.KeyUp
        If txtTable.Text.Trim() <> "" Then
            retrive(" where TableRate Like '" & txtTable.Text.Trim() & "%'")
        End If
        If txtTable.Text.Trim() = "" Then
            retrive()
        End If
        If e.KeyCode = Keys.Down Then dg1.Focus()
    End Sub

    Private Sub txtMrp_KeyUp(sender As Object, e As KeyEventArgs) Handles txtPos.KeyUp
        If txtPos.Text.Trim() <> "" Then
            retrive(" where POSRate Like '" & txtPos.Text.Trim() & "%'")
        End If
        If txtPos.Text.Trim() = "" Then
            retrive()
        End If
        If e.KeyCode = Keys.Down Then dg1.Focus()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnClose_Click_1(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs)
        retrive()
    End Sub
End Class