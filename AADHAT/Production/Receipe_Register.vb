Public Class Receipe_Register

    Private Sub Receipe_Register_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub Receipe_Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0 : Me.Left = 0
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True : ItemRowColumns()
    End Sub
    Private Sub ItemRowColumns()
        dg1.ColumnCount = 5
        dg1.Columns(0).Name = "ID" : dg1.Columns(0).Visible = False
        dg1.Columns(1).Name = "Receipe Name" : dg1.Columns(1).Width = 500
        dg1.Columns(2).Name = "Item Name" : dg1.Columns(2).Width = 300
        dg1.Columns(3).Name = "Qty" : dg1.Columns(3).Width = 100
        dg1.Columns(4).Name = "Unit" : dg1.Columns(4).Width = 100
        retriveMainItems()
    End Sub

    Private Sub retriveMainItems(Optional ByVal condtion As String = "")
        dg1.Rows.Clear()
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("Select * From Receipe " & condtion & " order by ReceipeName")
        Try
            If dt.Rows.Count > 0 Then
                dg1.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("ID").ToString()
                        .Cells(1).Value = dt.Rows(i)("ReceipeName").ToString()
                        .Cells(2).Value = dt.Rows(i)("ItemName").ToString()
                        .Cells(3).Value = dt.Rows(i)("Qty").ToString()
                        .Cells(4).Value = dt.Rows(i)("UnitName").ToString()
                    End With
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "Teller")
        End Try
        dg1.ClearSelection()
    End Sub

    Private Sub txtReceipeName_KeyUp(sender As Object, e As KeyEventArgs) Handles txtReceipeName.KeyUp
        If txtReceipeName.Text.Trim() <> "" Then
            retriveMainItems(" Where upper(ReceipeName) Like upper('" & txtReceipeName.Text.Trim() & "%')")
        Else
            retriveMainItems()
        End If
    End Sub

    Private Sub txtReceipeName_TextChanged(sender As Object, e As EventArgs) Handles txtReceipeName.TextChanged

    End Sub

    Private Sub txtItemName_KeyUp(sender As Object, e As KeyEventArgs) Handles txtItemName.KeyUp
        If txtItemName.Text.Trim() <> "" Then
            retriveMainItems(" Where upper(ItemName) Like upper('" & txtItemName.Text.Trim() & "%')")
        Else
            retriveMainItems()
        End If
    End Sub


    Private Sub btnAddReceipe_Click(sender As Object, e As EventArgs) Handles btnAddReceipe.Click
        Receipe_Master.MdiParent = MainScreenForm
        Receipe_Master.Show()
        Receipe_Master.BringToFront()
    End Sub

    Private Sub dg1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg1.CellClick
        dg1.ClearSelection()
    End Sub


    Private Sub dg1_KeyDown(sender As Object, e As KeyEventArgs) Handles dg1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dg1.SelectedRows.Count = 0 Then Exit Sub
            Receipe_Master.MdiParent = MainScreenForm
            Dim TempID As Integer = (dg1.SelectedRows(0).Cells(0).Value)
            Receipe_Master.Show()
            Receipe_Master.FillControls(TempID)
            Receipe_Master.BringToFront()
        End If

    End Sub

    Private Sub dg1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dg1.MouseDoubleClick
        If dg1.SelectedRows.Count = 0 Then Exit Sub
        Receipe_Master.MdiParent = MainScreenForm
        Dim TempID As Integer = (dg1.SelectedRows(0).Cells(0).Value)
        Receipe_Master.Show()
        Receipe_Master.FillControls(TempID)
        Receipe_Master.BringToFront()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class