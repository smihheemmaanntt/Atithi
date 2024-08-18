Public Class State

    Private Sub State_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub State_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'clsFun.FillDropDownList(cbRoomType, "Select ID,RoomTypeName From RoomType", "RoomTypeName", "Id", "")
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True : BtnDelete.Visible = False
        txtStateName.Focus() : rowColums()
    End Sub
    Private Sub rowColums()
        dg1.ColumnCount = 4
        dg1.Columns(0).Name = "ID" : dg1.Columns(0).Visible = False
        dg1.Columns(1).Name = "State Name" : dg1.Columns(1).Width = 390
        dg1.Columns(2).Name = "StateCode" : dg1.Columns(2).Width = 170
        retrive()
    End Sub
    Private Sub retrive()
        dg1.Rows.Clear()
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("SELECT * FROM StateList")
        Try
            If dt.Rows.Count > 0 Then
                dg1.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    Application.DoEvents()
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("id").ToString()
                        .Cells(1).Value = dt.Rows(i)("Statename").ToString()
                        .Cells(2).Value = dt.Rows(i)("StateGSTCodes").ToString()
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
    Private Sub save()
        Dim cmd As SQLite.SQLiteCommand
        If txtStateName.Text = "" Then
            txtStateName.Focus()
            MsgBox("Please Fill Room Name... ", MsgBoxStyle.Exclamation, "Empty")
            Exit Sub
        End If
        Dim sql As String = "insert into StateList (StateName, StateGSTCodes) values (@1, @2)"
        Try
            cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
            cmd.Parameters.AddWithValue("@1", txtStateName.Text)
            cmd.Parameters.AddWithValue("@2", txtStateCode.Text)
            If cmd.ExecuteNonQuery() > 0 Then
                MsgBox("Record Insert Succesfully", MsgBoxStyle.Information, "Saved")
                clearTxtAll()
            End If
            clsFun.CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message)
            clsFun.CloseConnection()
        End Try
    End Sub
    Public Sub FillControls(ByVal id As Integer)
        Dim ssql As String = String.Empty
        Dim dt As New DataTable
        lblgroup.Text = "Modify State"
        BtnDelete.Visible = True
        BtnSave.Text = "&Update"
        ssql = "SELECT * FROM StateList where id=" & id
        dt = clsFun.ExecDataTable(ssql) ' where id=" & id & "")
        If dt.Rows.Count > 0 Then
            txtID.Text = dt.Rows(0)("ID").ToString()
            txtStateName.Text = dt.Rows(0)("StateName").ToString()
            txtStateCode.Text = dt.Rows(0)("StateGSTCodes").ToString()
        End If
    End Sub
    Private Sub clearTxtAll()
        lblgroup.Text = "State Creation"
        retrive() : BtnSave.Text = "&Save"
        txtStateName.Clear() : txtSearch.Clear()
        txtStateName.Focus() : txtStateCode.Clear()
    End Sub
    Private Sub Update()
        Dim cmd As SQLite.SQLiteCommand
        If txtStateName.Text = "" Then
            txtStateName.Focus()
            MsgBox("Please Fill Room Name / Number ... ", MsgBoxStyle.Exclamation, "Empty")
            Exit Sub
        End If
        Dim sql As String = "Update StateList Set Statename='" & txtStateName.Text & "',StateGSTCodes='" & Val(txtStateCode.Text) & "'," _
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
    Private Sub Delete()
        Try
            'If clsFun.ExecScalarInt("Select Room From RoomType  WHERE RoomTypeID=" & Val(txtID.Text) & "") <> 0 Then MsgBox("Room Type is Used For Rooms. Please Remove First Room Type From Rooms.", vbCritical + vbOKOnly, "Access Denied") : Exit Sub
            If MessageBox.Show("Are You Sure want to Delete ??", "DELETE", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.OK Then
                If clsFun.ExecNonQuery("DELETE from StateList WHERE ID=" & Val(txtID.Text) & "") > 0 Then
                    MessageBox.Show("State Deleted SuccesFully", "deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    clearTxtAll()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        Delete()
    End Sub
    Private Sub txtRoomName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtStateName.KeyDown, txtStateCode.KeyDown, txtSearch.KeyDown
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
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If BtnSave.Text = "&Save" Then
            save()
        Else
            Update()
        End If
    End Sub
End Class