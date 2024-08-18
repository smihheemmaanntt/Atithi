Public Class BusinessSources

    Private Sub BusinessSources_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub BusinessSources_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True : BtnDelete.Visible = False
        txtBusinessSourceName.Focus() : rowColums()
    End Sub
    Private Sub rowColums()
        dg1.ColumnCount = 4
        dg1.Columns(0).Name = "ID" : dg1.Columns(0).Visible = False
        dg1.Columns(1).Name = "SourceName Name" : dg1.Columns(1).Width = 220
        dg1.Columns(2).Name = "City" : dg1.Columns(2).Width = 170
        dg1.Columns(3).Name = "Mobile No" : dg1.Columns(3).Width = 170
        retrive()
    End Sub
    Private Sub retrive()
        dg1.Rows.Clear()
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("SELECT * FROM BusinessSources")
        Try
            If dt.Rows.Count > 0 Then
                dg1.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    Application.DoEvents()
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("id").ToString()
                        .Cells(1).Value = dt.Rows(i)("SourceName").ToString()
                        .Cells(2).Value = dt.Rows(i)("City").ToString()
                        .Cells(3).Value = dt.Rows(i)("Mob1").ToString()
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
        If txtBusinessSourceName.Text = "" Then
            txtBusinessSourceName.Focus()
            MsgBox("Please Fill Room Name... ", MsgBoxStyle.Exclamation, "Empty")
            Exit Sub
        End If
        Dim sql As String = "insert into BusinessSources (SourceName, FullAddress,City,State,PhoneNo,Mob1,Mob2,FaxNo,EmailID,Website) values (@1, @2,@3,@4, @5,@6,@7, @8,@9,@10)"
        Try
            cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
            cmd.Parameters.AddWithValue("@1", txtBusinessSourceName.Text)
            cmd.Parameters.AddWithValue("@2", txtFullAddress.Text)
            cmd.Parameters.AddWithValue("@3", txtCity.Text)
            cmd.Parameters.AddWithValue("@4", txtState.Text)
            cmd.Parameters.AddWithValue("@5", txtPhone.Text)
            cmd.Parameters.AddWithValue("@6", txtMobile1.Text)
            cmd.Parameters.AddWithValue("@7", txtMobile2.Text)
            cmd.Parameters.AddWithValue("@8", txtFaxNo.Text)
            cmd.Parameters.AddWithValue("@9", txtEmail.Text)
            cmd.Parameters.AddWithValue("@10", txtWebsite.Text)
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
        ssql = "SELECT * FROM BusinessSources where id=" & id
        dt = clsFun.ExecDataTable(ssql) ' where id=" & id & "")
        If dt.Rows.Count > 0 Then
            txtID.Text = dt.Rows(0)("ID").ToString()
            txtBusinessSourceName.Text = dt.Rows(0)("SourceName").ToString()
            txtFullAddress.Text = dt.Rows(0)("FullAddress").ToString()
            txtCity.Text = dt.Rows(0)("City").ToString()
            txtState.Text = dt.Rows(0)("State").ToString()
            txtPhone.Text = dt.Rows(0)("PhoneNo").ToString()
            txtMobile1.Text = dt.Rows(0)("Mob1").ToString()
            txtMobile2.Text = dt.Rows(0)("Mob2").ToString()
            txtFaxNo.Text = dt.Rows(0)("FaxNo").ToString()
            txtEmail.Text = dt.Rows(0)("EmailID").ToString()
            txtWebsite.Text = dt.Rows(0)("Website").ToString()
        End If
    End Sub
    Private Sub clearTxtAll()
        lblgroup.Text = "Business Sources"
        retrive() : BtnSave.Text = "&Save"
        txtBusinessSourceName.Clear() : txtFullAddress.Clear()
        txtCity.Clear() : txtState.Clear()
        txtPhone.Clear() : txtMobile1.Clear()
        txtMobile2.Clear() : txtFaxNo.Clear()
        txtEmail.Clear() : txtWebsite.Clear()
        txtBusinessSourceName.Focus()
    End Sub
    Private Sub Update()
        Dim cmd As SQLite.SQLiteCommand
        If txtBusinessSourceName.Text = "" Then
            txtBusinessSourceName.Focus()
            MsgBox("Please Fill Business Source Name ... ", MsgBoxStyle.Exclamation, "Empty")
            Exit Sub
        End If
        Dim sql As String = "Update  BusinessSources  Set SourceName='" & txtBusinessSourceName.Text & "', FullAddress='" & txtFullAddress.Text & "',City='" & txtCity.Text & "', " _
                            & "State='" & txtState.Text & "',PhoneNo='" & txtPhone.Text & "',Mob1='" & txtMobile1.Text & "',Mob2='" & txtMobile2.Text & "',FaxNo='" & txtFaxNo.Text & "', " _
                            & " EmailID='" & txtEmail.Text & "',Website='" & txtWebsite.Text & "' Where ID=" & Val(txtID.Text) & ""
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
    Private Sub Delete()
        Try
            'If clsFun.ExecScalarInt("Select Room From RoomType  WHERE RoomTypeID=" & Val(txtID.Text) & "") <> 0 Then MsgBox("Room Type is Used For Rooms. Please Remove First Room Type From Rooms.", vbCritical + vbOKOnly, "Access Denied") : Exit Sub
            If MessageBox.Show("Are You Sure want to Delete ??", "DELETE", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.OK Then
                If clsFun.ExecNonQuery("DELETE from BusinessSourcrs WHERE ID=" & Val(txtID.Text) & "") > 0 Then
                    MessageBox.Show("Source Deleted SuccesFully", "deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
    Private Sub txtRoomName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBusinessSourceName.KeyDown,
        txtFullAddress.KeyDown, txtCity.KeyDown, txtState.KeyDown, txtPhone.KeyDown, txtMobile1.KeyDown, txtMobile2.KeyDown,
        txtFaxNo.KeyDown, txtEmail.KeyDown, txtWebsite.KeyDown
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
End Class