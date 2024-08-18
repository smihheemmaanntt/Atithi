﻿Public Class Item_Company

    Private Sub Item_Company_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub Item_Company_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.BackColor = Color.Moccasin
        Me.KeyPreview = True
        BtnDelete.Visible = False
        rowColums() : txtName.Focus()
    End Sub
    Private Sub rowColums()
        dg1.ColumnCount = 2
        dg1.Columns(0).Name = "ID"
        dg1.Columns(0).Visible = False
        dg1.Columns(1).Name = "Item Company Name"
        dg1.Columns(1).Width = 560
        retrive()
    End Sub

    Private Sub retrive()
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("Select * from ItemCompany")
        Try
            If dt.Rows.Count > 0 Then
                dg1.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("id").ToString()
                        .Cells(1).Value = dt.Rows(i)("CompanyName").ToString()
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
    Private Sub ClearTxtAll()
        retrive() : BtnDelete.Visible = False
        txtName.Clear() : txtName.Focus()
        BtnSave.Text = "&Save"
        lblgroup.Text = "Item Company Creation"
        retrive()
    End Sub
    Private Sub save()
        Dim cmd As New SQLite.SQLiteCommand
        If txtName.Text = "" Then
            txtName.Focus()
            MsgBox("Please Fill Company Name... ", MsgBoxStyle.Exclamation, "Empty")
        Else
            Dim sql As String = "insert into ItemCompany (CompanyName) values (@1)"
            Try
                cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
                cmd.Parameters.AddWithValue("@1", txtName.Text.Trim)
                If cmd.ExecuteNonQuery() > 0 Then
                    MsgBox("Record Insert SuccesFully", MsgBoxStyle.Information, "Saved")
                    ClearTxtAll()
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
                If clsFun.ExecNonQuery("DELETE from ItemCompany WHERE ID=" & txtID.Text & "") > 0 Then
                    MsgBox("Successfully deleted")
                    ClearTxtAll()
                End If
            End If
            'Else
            'MsgBox("Crate Marka Cannot delete... alreday use in Database", vbCritical + vbOKOnly, "Access Denied")
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Update()
        Dim cmd As New SQLite.SQLiteCommand
        If txtName.Text = "" Then
            txtName.Focus()
            MsgBox("Please Fill Company Name... ", MsgBoxStyle.Exclamation, "Empty")
            Exit Sub
        End If

        Dim sql As String = "Update ItemCompany Set CompanyName='" & txtName.Text.Trim & "' where ID=" & Val(txtID.Text) & ""
        cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
        Try
            If clsFun.ExecNonQuery(sql) > 0 Then
                MessageBox.Show("Record Updated SuccesFully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '   Create_marka_list.btnRetrive.PerformClick()
                ClearTxtAll()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub FillControls(ByVal id As Integer)
        Dim ssql As String = String.Empty
        Dim dt As New DataTable
        lblgroup.Text = "Modify Company"
        BtnDelete.Visible = True
        BtnSave.Text = "&Update"
        ssql = "Select * from ItemCompany where id=" & id
        dt = clsFun.ExecDataTable(ssql) ' where id=" & id & "")
        If dt.Rows.Count > 0 Then
            txtName.Text = dt.Rows(0)("CompanyName").ToString()
            txtID.Text = Val(dt.Rows(0)("ID").ToString())
        End If
        txtName.Focus()
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

   
    Private Sub txtName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtName.KeyDown
         If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
            e.SuppressKeyPress = True
        End If
        Select Case e.KeyCode
            Case Keys.End
                e.Handled = True
                BtnSave.Focus()
        End Select
        If e.KeyCode = Keys.Down Then
            dg1.Rows(0).Selected = True : dg1.Focus()
        End If
    End Sub

    Private Sub txtName_Leave(sender As Object, e As EventArgs) Handles txtName.Leave
        If BtnSave.Text = "&Save" Then
            If clsFun.ExecScalarStr("Select count(*) from ItemCompany where CompanyName='" & txtName.Text & "'") = 1 Then
                MsgBox("Company Name Already Exists...", vbCritical + vbOKOnly, "Access Denied")
                txtName.Focus()
            End If
        Else
            Exit Sub
        End If
    End Sub

    Private Sub dg1_KeyDown(sender As Object, e As KeyEventArgs) Handles dg1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim tmpID As Integer = Val(dg1.SelectedRows(0).Cells(0).Value)
            FillControls(tmpID) : txtName.Focus()
            e.SuppressKeyPress = True
        End If
        If e.KeyCode = Keys.Up Then
            If dg1.SelectedRows.Count = 0 Then Exit Sub
            If Val(dg1.SelectedRows(0).Index) = 0 Then txtName.Focus()
            dg1.ClearSelection()
        End If
        If e.KeyCode = Keys.Down Then
            If dg1.SelectedRows.Count = 0 Then Exit Sub
            If Val(dg1.SelectedRows(0).Index) = Val(dg1.Rows.Count - 1) Then dg1.Rows(0).Selected = True
        End If
    End Sub

    Private Sub dg1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dg1.MouseDoubleClick
        Dim tmpID As Integer = Val(dg1.SelectedRows(0).Cells(0).Value)
        FillControls(tmpID) : txtName.Focus()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class