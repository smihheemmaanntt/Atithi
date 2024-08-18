Public Class Package

    Private Sub Package_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub Package_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        BtnDelete.Visible = False
        txtPackageName.Focus()
        rowColums()
    End Sub
    Private Sub rowColums()
        dg1.ColumnCount = 3
        dg1.Columns(0).Name = "ID"
        dg1.Columns(0).Visible = False
        dg1.Columns(1).Name = "Package Name"
        dg1.Columns(1).Width = 214
        dg1.Columns(2).Name = "Discription"
        dg1.Columns(2).Width = 343
        retrive()
    End Sub
    Private Sub retrive()
        dg1.Rows.Clear()
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("Select * from Package")
        Try
            If dt.Rows.Count > 0 Then
                dg1.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("id").ToString()
                        .Cells(1).Value = dt.Rows(i)("packageName").ToString()
                        .Cells(2).Value = dt.Rows(i)("Discription").ToString()
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
        Dim tmpID As String = dg1.SelectedRows(0).Cells(0).Value
        FillControls(tmpID)
    End Sub
    Private Sub save()
        Dim cmd As SQLite.SQLiteCommand
        If txtPackageName.Text = "" Then
            txtPackageName.Focus()
            MsgBox("Please Fill package Name... ", MsgBoxStyle.Exclamation, "Empty")
        Else
            Dim sql As String = "insert into Package (PackageName, Discription,Tag) values (@1, @2,@3)"
            Try
                cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
                cmd.Parameters.AddWithValue("@1", txtPackageName.Text)
                cmd.Parameters.AddWithValue("@2", txtDiscription.Text)
                cmd.Parameters.AddWithValue("@3", 1)
                If cmd.ExecuteNonQuery() > 0 Then
                    MsgBox("Record Insert SuccesFully", MsgBoxStyle.Information, "Saved")
                    clearTxtAll()
                End If
                clsFun.CloseConnection()
            Catch ex As Exception
                MsgBox(ex.Message)
                clsFun.CloseConnection()
            End Try
        End If
    End Sub
    Private Sub Delete()
        Try
            If clsFun.ExecScalarInt("Select Count(*) From Package  WHERE ID=" & Val(txtID.Text) & "") <> 0 Then MsgBox("Package is Used For Room Type. Please Remove First Package From Room Type.", vbCritical + vbOKOnly, "Access Denied") : Exit Sub
            If clsFun.ExecScalarInt("Select tag From Package  WHERE ID=" & txtID.Text & "") = 0 Then MsgBox("Pre-Define Package. You Can't Delete it.", vbCritical + vbOKOnly, "Access Denied") : Exit Sub
            If MessageBox.Show("Are You Sure want to Delete ??", "DELETE", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.OK Then
                If clsFun.ExecNonQuery("DELETE from Package WHERE ID=" & Val(txtID.Text) & "") > 0 Then
                    MessageBox.Show("Record Deleted SuccesFully", "deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    clearTxtAll()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub clearTxtAll()
        Panel1.BackColor = Color.Black
        lblgroup.Text = "Room Type"
        retrive()
        BtnSave.Text = "&Save"
        txtDiscription.Clear()
        txtPackageName.Clear()
        txtID.Clear()
        BtnDelete.Visible = False
        txtPackageName.Focus()
    End Sub

    Private Sub Update()
        Dim cmd As SQLite.SQLiteCommand
        If txtPackageName.Text = "" Then
            txtPackageName.Focus()
            MsgBox("Please Fill Company Name... ", MsgBoxStyle.Exclamation, "Empty")
            Exit Sub
        End If
        Dim sql As String = "Update Package Set packageName='" & txtPackageName.Text & "',Discription='" & txtDiscription.Text & "'" _
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
    Public Sub FillControls(ByVal id As Integer)
        Dim ssql As String = String.Empty
        Dim dt As New DataTable
        Panel1.BackColor = Color.PaleVioletRed
        lblgroup.Text = "Modify Package"
        BtnDelete.Visible = True
        BtnSave.Text = "&Update"
        ssql = "Select * from Package where id=" & id
        dt = clsFun.ExecDataTable(ssql) ' where id=" & id & "")
        If dt.Rows.Count > 0 Then
            txtPackageName.Text = dt.Rows(0)("PackageName").ToString()
            txtDiscription.Text = dt.Rows(0)("Discription").ToString()
            txtID.Text = dt.Rows(0)("ID").ToString()
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If BtnSave.Text = "&Save" Then
            save()
        Else
            Update()
        End If
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        Delete()
    End Sub

    Private Sub txtName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPackageName.KeyDown, txtDiscription.KeyDown
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

    Private Sub dg1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg1.CellContentClick

    End Sub
End Class