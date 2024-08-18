Public Class RestroTables

    Private Sub RestoTables_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub RestoTables_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.BackColor = Color.Moccasin
        Me.KeyPreview = True
        BtnDelete.Visible = False
        txtTableName.Focus()
        rowColums()
    End Sub
    Private Sub rowColums()
        dg1.ColumnCount = 4
        dg1.Columns(0).Name = "ID"
        dg1.Columns(0).Visible = False
        dg1.Columns(1).Name = "Table Name"
        dg1.Columns(1).Width = 450
        dg1.Columns(2).Name = "Capicity"
        dg1.Columns(2).Width = 150
        retrive()
    End Sub
    Private Sub retrive()
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("Select * from RestroTables")
        Try
            If dt.Rows.Count > 0 Then
                dg1.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("id").ToString()
                        .Cells(1).Value = dt.Rows(i)("TableName").ToString()
                        .Cells(2).Value = dt.Rows(i)("CapaCity").ToString()
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
        If txtTableName.Text = "" Then
            txtTableName.Focus()
            MsgBox("Table Can't be Empty...Please Fill Table Name... ", MsgBoxStyle.Exclamation, "Empty")
        Else
            Dim sql As String = "insert into RestroTables (TableName, Capacity,ISBooked) values (@1, @2,@3)"
            Try
                cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
                cmd.Parameters.AddWithValue("@1", txtTableName.Text)
                cmd.Parameters.AddWithValue("@2", TxtCapacity.Text)
                cmd.Parameters.AddWithValue("@3", "N")
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
            If MessageBox.Show("Are You Sure want to Delete ??", "DELETE", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.OK Then
                If clsFun.ExecNonQuery("DELETE from RestroTables WHERE ID=" & txtID.Text & "") > 0 Then
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
        lblgroup.Text = "Table Creation"
        retrive()
        BtnSave.Text = "&Save"
        TxtCapacity.Clear()
        txtTableName.Clear()
        txtID.Clear()
        BtnDelete.Visible = False
        txtTableName.Focus()
    End Sub

    Private Sub Update()
        Dim cmd As SQLite.SQLiteCommand
        If txtTableName.Text = "" Then
            txtTableName.Focus()
            MsgBox("Table Can't be Empty...Please Fill Table Name... ", MsgBoxStyle.Exclamation, "Empty")
            Exit Sub
        End If
        Dim sql As String = "Update RestroTables Set TableName='" & txtTableName.Text & "',Capacity='" & Val(TxtCapacity.Text) & "'" _
                            & "where ID=" & txtID.Text & ""
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
        lblgroup.Text = "Modify Tables"
        BtnDelete.Visible = True
        BtnSave.Text = "&Update"
        ssql = "Select * from RestroTables where id=" & id
        dt = clsFun.ExecDataTable(ssql) ' where id=" & id & "")
        If dt.Rows.Count > 0 Then
            txtTableName.Text = dt.Rows(0)("TableName").ToString()
            TxtCapacity.Text = dt.Rows(0)("Capacity").ToString()
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

    Private Sub txtName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTableName.KeyDown, TxtCapacity.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        Else
            Exit Sub
        End If
        e.SuppressKeyPress = True
        Select Case e.KeyCode
            Case Keys.End
                e.Handled = True
                BtnSave.Focus()
        End Select
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class