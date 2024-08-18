Public Class Unit_items

    Private Sub Unit_items_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub
    Private Sub Unit_items_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.BackColor = Color.Moccasin
        Me.KeyPreview = True
        BtnDelete.Visible = False
        txtName.Focus()
        rowColums()
    End Sub
    Private Sub rowColums()
        dg1.ColumnCount = 3
        dg1.Columns(0).Name = "ID"
        dg1.Columns(0).Visible = False
        dg1.Columns(1).Name = "Main Unit"
        dg1.Columns(1).Width = 255
        dg1.Columns(2).Name = "Conversion"
        dg1.Columns(2).Width = 300
        retrive()
    End Sub
    Private Sub retrive()
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("Select * from ItemUnits")
        Try
            If dt.Rows.Count > 0 Then
                dg1.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("id").ToString()
                        .Cells(1).Value = dt.Rows(i)("MainUnit").ToString()
                        .Cells(2).Value = dt.Rows(i)("Conversion").ToString()
                    End With
                    ' Dg1.Rows.Add()
                Next
            End If
            dt.Dispose()

        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "AADHAT")
        End Try
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub dg1_KeyDown(sender As Object, e As KeyEventArgs) Handles dg1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim tmpID As String = dg1.SelectedRows(0).Cells(0).Value
            FillControls(tmpID)
           
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub dg1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dg1.MouseDoubleClick
        Dim tmpID As String = dg1.SelectedRows(0).Cells(0).Value
       
        FillControls(tmpID)
        
    End Sub
   
    Private Sub save()
        Dim cmd As SQLite.SQLiteCommand
        If txtName.Text = "" Then
            txtName.Focus()
            MsgBox("Please Fill Company Name... ", MsgBoxStyle.Exclamation, "Empty")
        Else
            Dim sql As String = "insert into ItemUnits (mainUnit, Conversion) values (@1, @2)"
            Try
                cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
                cmd.Parameters.AddWithValue("@1", txtName.Text)
                cmd.Parameters.AddWithValue("@2", txtConversion.Text)
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
            '  If clsFun.ExecScalarInt("Select tag From AccountGroup  WHERE ID=" & txtid.Text & "") = 0 Then MsgBox("access denied", MsgBoxStyle.Critical) : Exit Sub
            ' If clsFun.ExecScalarInt("Select count(*) from Ledger where TaxationID='" & Val(txtID.Text) & "'") = 0 Then
            If MessageBox.Show("Sure ??", "DELETE", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.OK Then
                If clsFun.ExecNonQuery("DELETE from ItemUnits WHERE ID=" & txtID.Text & "") > 0 Then
                    MessageBox.Show("Record Deleted SuccesFully", "deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    clearTxtAll()
                End If
            End If
            'Else
            'MsgBox("Crate Marka Cannot delete... alreday use in Database", vbCritical + vbOKOnly, "Access Denied")
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub clearTxtAll()
        Panel1.BackColor = Color.Black
        lblgroup.Text = "Unit Creation"
        retrive()
        BtnSave.Text = "&Save"
        txtConversion.Clear()
        txtName.Clear()
        txtID.Clear()
        BtnDelete.Visible = False
        txtName.Focus()
    End Sub

    Private Sub UpdateCompany()
        Dim cmd As SQLite.SQLiteCommand
        If txtName.Text = "" Then
            txtName.Focus()
            MsgBox("Please Fill Company Name... ", MsgBoxStyle.Exclamation, "Empty")
        Else
           
            Dim sql As String = "Update ItemUnits Set MainUnit='" & txtName.Text & "',Conversion='" & txtConversion.Text & "'" _
                                & " where ID=" & txtID.Text & ""
            cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
            Try
                If clsFun.ExecNonQuery(sql) > 0 Then
                    MessageBox.Show("Record Updated SuccesFully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    clearTxtAll()

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Public Sub FillControls(ByVal id As Integer)
        Dim ssql As String = String.Empty
        Dim dt As New DataTable
        Panel1.BackColor = Color.PaleVioletRed
        lblgroup.Text = "Modify Unit"
        BtnDelete.Visible = True
        BtnSave.Text = "&Update"
        ssql = "Select * from ItemUnits where id=" & id
        dt = clsFun.ExecDataTable(ssql) ' where id=" & id & "")
        If dt.Rows.Count > 0 Then
            txtName.Text = dt.Rows(0)("MainUnit").ToString()
            txtConversion.Text = dt.Rows(0)("Conversion").ToString()
            txtID.Text = dt.Rows(0)("ID").ToString()
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If BtnSave.Text = "&Save" Then
            save()
        Else
            UpdateCompany()
        End If
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        Delete()
    End Sub

    Private Sub txtName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtName.KeyDown, txtConversion.KeyDown
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

    Private Sub txtName_Leave(sender As Object, e As EventArgs) Handles txtName.Leave
        If BtnSave.Text = "&Save" Then
            If clsFun.ExecScalarStr("Select count(*)from ItemUnits where MainUnit='" & txtName.Text & "'") = 1 Then
                MsgBox("Unit Name Already Exists...", vbCritical + vbOKOnly, "Access Denied")
                txtName.Focus()
            End If
        Else
            Exit Sub
        End If
    End Sub
End Class