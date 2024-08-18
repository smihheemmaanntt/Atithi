Imports System.Windows.Forms
Imports System.Data
Public Class UserForm

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If BtnSave.Text = "&Save" Then
            Save()
        Else
            Update()
        End If
    End Sub

    Private Sub Save()
        If txtPassword.Text <> txtConfirm.Text Then
            MsgBox("Password Did Not Matched... Please Re Check Your Password...", MsgBoxStyle.Exclamation, "Unmatched")
            txtConfirm.Focus() : Exit Sub
        End If
        Dim cmd As SQLite.SQLiteCommand
        Dim sql As String = "insert into Users(UserName, Password,Tag)values (@1, @2,@3)"
        Try
            cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
            cmd.Parameters.AddWithValue("@1", TxtUsername.Text)
            cmd.Parameters.AddWithValue("@2", txtPassword.Text)
            cmd.Parameters.AddWithValue("@3", 1)
            If cmd.ExecuteNonQuery() > 0 Then
                MessageBox.Show("Record Insert SuccesFully", "SuccessFully", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CompanyList.BtnRetrive.PerformClick()
            End If
            ' MsgBox("SuccessFully Inserted")
            clsFun.CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message)
            clsFun.CloseConnection()
        End Try
    End Sub

    Private Sub UserForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None

    End Sub
    Private Sub Update()
        If txtPassword.Text <> txtConfirm.Text Then
            MsgBox("Password Did Not Matched... Please Re Check Your Password...", MsgBoxStyle.Exclamation, "Unmatched")
            txtConfirm.Focus() : Exit Sub
        End If
        Dim sql As String = "Update Users SET userName='" & TxtUsername.Text & "',Password='" & txtPassword.Text & "' WHERE ID=" & Val(txtid.Text) & ""
        cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
        Try
            If clsFun.ExecNonQuery(sql) > 0 Then
                MsgBox("Record Updated Successfully.", vbInformation + vbOKOnly, "Updated")
                account_group_list.btnRetrive.PerformClick()
                lblgroup.Text = "USER CREATION"
                Panel1.BackColor = Color.Black
                ' Textclear()
                BtnSave.Text = "&Save"
                btnDelete.Visible = False
                TxtUsername.Focus()
                Me.Close()
            End If
            'con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            'con.Close()
        End Try
    End Sub
    Private Sub TxtUsername_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtUsername.KeyDown, txtPassword.KeyDown, txtConfirm.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        Else
            Exit Sub
        End If
        e.SuppressKeyPress = True
    End Sub
    Public Sub FillControls(ByVal id As Integer)
        Dim ssql As String = String.Empty
        Dim dt As New DataTable
        Panel1.BackColor = Color.PaleVioletRed
        lblgroup.Text = "Modify User"
        BtnDelete.Visible = True
        BtnSave.Text = "&Update"
        ssql = "Select * from Users where id=" & id
        dt = clsFun.ExecDataTable(ssql) ' where id=" & id & "")
        If dt.Rows.Count > 0 Then
            txtid.Text = dt.Rows(0)("ID").ToString()
            TxtUsername.Text = dt.Rows(0)("UserName").ToString()
            txtPassword.Text = dt.Rows(0)("Password").ToString()
        End If
    End Sub

    Private Sub btnList_Click(sender As Object, e As EventArgs) Handles btnList.Click
        Users_Register.MdiParent = MainScreenForm
        Users_Register.Show()
        If Not Users_Register Is Nothing Then
            Users_Register.BringToFront()
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        delete()
    End Sub
    Private Sub delete()
        If MessageBox.Show("Sure ??", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If clsFun.ExecNonQuery("DELETE from Users WHERE ID=" & txtid.Text & "") > 0 Then
                MsgBox("User Deleted Successfully.", vbInformation + vbOKOnly, "Deleted")
            End If
        End If
    End Sub
End Class