Public Class Room_Type



    Private Sub Room_Type_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub Room_Type_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clsFun.FillDropDownList(CbPackage, "Select * From Package", "PackageName", "Id", "")
        clsFun.FillDropDownList(cbTax, "Select * From Taxation", "TaxName", "Id", "")
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True : BtnDelete.Visible = False
        txtRoomType.Focus() : rowColums()
    End Sub
    Private Sub rowColums()
        dg1.ColumnCount = 6
        dg1.Columns(0).Name = "ID" : dg1.Columns(0).Visible = False
        dg1.Columns(1).Name = "Room Type" : dg1.Columns(1).Width = 120
        dg1.Columns(2).Name = "Package Name" : dg1.Columns(2).Width = 140
        dg1.Columns(3).Name = "Room Charge" : dg1.Columns(3).Width = 130
        dg1.Columns(4).Name = "Dis %" : dg1.Columns(4).Width = 70
        dg1.Columns(5).Name = "Tax %" : dg1.Columns(5).Width = 100
        retrive()
    End Sub
  

    Private Sub txtPackageName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRoomType.KeyDown, CbPackage.KeyDown,
        txtChargesAmt.KeyDown, txtDisPer.KeyDown, cbTax.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
            e.SuppressKeyPress = True
        End If
        Select Case e.KeyCode
            Case Keys.End
                e.Handled = True
                BtnSave.Focus()
        End Select
    End Sub

    Private Sub txtPackageName_TextChanged(sender As Object, e As EventArgs) Handles txtRoomType.TextChanged

    End Sub

    Private Sub txtChargesAmt_TextChanged(sender As Object, e As EventArgs) Handles txtChargesAmt.TextChanged

    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If BtnSave.Text = "&Save" Then
            save()
        Else
            Update()
        End If
    End Sub
    Private Sub save()
        Dim cmd As SQLite.SQLiteCommand
        If txtRoomType.Text = "" Then
            txtRoomType.Focus()
            MsgBox("Please Fill Room Type... ", MsgBoxStyle.Exclamation, "Empty")
            Exit Sub
        End If
        Dim sql As String = "insert into RoomType (RoomTypeName, PackageID,RoomRent,DiscPer,TaxperID) values (@1, @2,@3,@4,@5)"
        Try
            cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
            cmd.Parameters.AddWithValue("@1", txtRoomType.Text)
            cmd.Parameters.AddWithValue("@2", CbPackage.SelectedValue)
            cmd.Parameters.AddWithValue("@3", txtChargesAmt.Text)
            cmd.Parameters.AddWithValue("@4", txtDisPer.Text)
            cmd.Parameters.AddWithValue("@5", cbTax.SelectedValue)
            If cmd.ExecuteNonQuery() > 0 Then
                MsgBox("Record Insert SuccesFully", MsgBoxStyle.Information, "Saved")
                clearTxtAll()
            End If
            clsFun.CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message)
            clsFun.CloseConnection()
        End Try
            End Sub
    Private Sub retrive()
        dg1.Rows.Clear()
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("SELECT * FROM RoomType AS RT INNER JOIN Package AS P ON RT.PackageID = P.ID LEFT JOIN Taxation T ON T.id = RT.TaxperID")
        Try
            If dt.Rows.Count > 0 Then
                dg1.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("id").ToString()
                        .Cells(1).Value = dt.Rows(i)("RoomTypeName").ToString()
                        .Cells(2).Value = dt.Rows(i)("PackageName").ToString()
                        .Cells(3).Value = Format(Val(dt.Rows(i)("RoomRent").ToString()), "0.00")
                        .Cells(4).Value = Format(Val(dt.Rows(i)("DiscPer").ToString()), "0.00")
                        .Cells(5).Value = dt.Rows(i)("TaxName").ToString()
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
    Public Sub FillControls(ByVal id As Integer)
        Dim ssql As String = String.Empty
        Dim dt As New DataTable
        lblgroup.Text = "Modify Room Type"
        BtnDelete.Visible = True
        BtnSave.Text = "&Update"
        ssql = "SELECT * FROM RoomType AS RT INNER JOIN Package AS P ON RT.PackageID = P.ID LEFT JOIN Taxation T ON T.id = RT.TaxperID where RT.id=" & id
        dt = clsFun.ExecDataTable(ssql) ' where id=" & id & "")
        If dt.Rows.Count > 0 Then
            txtID.Text = dt.Rows(0)("ID").ToString()
            txtRoomType.Text = dt.Rows(0)("RoomTypeName").ToString()
            CbPackage.Text = dt.Rows(0)("PackageName").ToString()
            txtChargesAmt.Text = Format(Val(dt.Rows(0)("RoomRent").ToString()), "0.00")
            txtDisPer.Text = Format(Val(dt.Rows(0)("DiscPer").ToString()), "0.00")
            cbTax.Text = dt.Rows(0)("TaxName").ToString()
        End If
    End Sub
    Private Sub Delete()
        Try
            If clsFun.ExecScalarInt("Select Count(*) From Room  WHERE RoomTypeID=" & Val(txtID.Text) & "") <> 0 Then MsgBox("Room Type is Used For Rooms. Please Remove First Room Type From Rooms.", vbCritical + vbOKOnly, "Access Denied") : Exit Sub
            If MessageBox.Show("Are You Sure want to Delete ??", "DELETE", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.OK Then
                If clsFun.ExecNonQuery("DELETE from RoomType WHERE ID=" & Val(txtID.Text) & "") > 0 Then
                    MessageBox.Show("Room Type Deleted SuccesFully", "deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    clearTxtAll()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Update()
        Dim cmd As SQLite.SQLiteCommand
        If txtRoomType.Text = "" Then
            txtRoomType.Focus()
            MsgBox("Please Fill Room Type Name... ", MsgBoxStyle.Exclamation, "Empty")
            Exit Sub
        End If
        Dim sql As String = "Update RoomType Set RoomTypeName='" & txtRoomType.Text & "',PackageID='" & Val(CbPackage.SelectedValue) & "'," _
                            & "RoomRent='" & Val(txtChargesAmt.Text) & "',DiscPer='" & Val(txtDisPer.Text) & "',TaxperID='" & Val(cbTax.SelectedValue) & "' " _
                            & "where ID=" & Val(txtID.Text) & ""
        cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
        Try
            If clsFun.ExecNonQuery(sql) > 0 Then
                MessageBox.Show("Record Updated SuccesFully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
                clearTxtAll()

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub clearTxtAll()
        lblgroup.Text = "Package Creation"
        retrive() : BtnSave.Text = "&Save"
        txtRoomType.Clear() : txtChargesAmt.Clear()
        txtDisPer.Clear() : txtID.Clear()
        BtnDelete.Visible = False : txtRoomType.Focus()
    End Sub

    Private Sub dg1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg1.CellClick
        dg1.ClearSelection()
    End Sub
    Private Sub dg1_KeyDown(sender As Object, e As KeyEventArgs) Handles dg1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dg1.SelectedRows.Count = 0 Then Exit Sub
            Dim tmpID As String = dg1.SelectedRows(0).Cells(0).Value
            FillControls(tmpID)
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub dg1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dg1.MouseDoubleClick
        If dg1.SelectedRows.Count = 0 Then Exit Sub
        If dg1.SelectedRows.Count = 0 Then Exit Sub
        Dim tmpID As String = dg1.SelectedRows(0).Cells(0).Value
        FillControls(tmpID)
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        Delete()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class
