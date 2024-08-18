Public Class Purchase_Type


    Private Sub Invoice_Type_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub
    Private Sub Invoice_Type_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.BackColor = Color.Moccasin
        Me.KeyPreview = True
        RadioExclusive.Checked = True
        clsFun.FillDropDownList(cbAccount, "Select ID,AccountName From Accounts where (ID in(36,37) or GroupID in(36,37))", "AccountName", "Id", "")
        BtnDelete.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    Private Sub save()
        Dim cmd As SQLite.SQLiteCommand
        Dim Radio As String = String.Empty
        If RadioExclusive.Checked Then
            Radio = "TE"
        ElseIf RadioInclusive.Checked Then
            Radio = "TI"
        ElseIf RadioMannual.Checked Then
            Radio = "TM"
        ElseIf RadioCompostion.Checked Then
            Radio = "TC"
        End If
        If txtInvocieTypeName.Text = "" Then
            txtInvocieTypeName.Focus()
            MsgBox("Please Fill Invoice Type Name... ", MsgBoxStyle.Exclamation, "Empty")
        Else
            Dim sql As String = "insert into PurchaseType(InvoiceTypeName,AccountID,Taxtype,Price,tag)" _
                                & "values (@1, @2, @3, @4,@5)"
            Try
                cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
                cmd.Parameters.AddWithValue("@1", txtInvocieTypeName.Text)
                cmd.Parameters.AddWithValue("@2", Val(cbAccount.SelectedValue))
                cmd.Parameters.AddWithValue("@3", Radio)
                cmd.Parameters.AddWithValue("@4", cbPrice.Text)
                cmd.Parameters.AddWithValue("@5", 1)
                If cmd.ExecuteNonQuery() > 0 Then
                    MsgBox("Record Saved Successftully.", vbInformation + vbOKOnly, "Saved") 'Insert SuccesFully", "SuccessFully", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtInvocieTypeName.Clear()
                    RadioExclusive.Checked = True
                    txtInvocieTypeName.Focus()
                    '  Account_List.btnRetrive.PerformClick()
                End If
                clsFun.CloseConnection()
            Catch ex As Exception
                MsgBox(ex.Message)
                clsFun.CloseConnection()
            End Try
        End If
    End Sub
    Public Sub FillControls(ByVal id As Integer)
        Dim sSql As String = String.Empty
        Dim Radio As String = String.Empty
        Panel2.Text = "MODIFY INVOICE TYPE"
        Panel2.BackColor = Color.PaleVioletRed
        BtnSave.Visible = True
        BtnDelete.Visible = True
        BtnSave.Text = "&Update"
        '  Panel1.BackColor = Color.PaleVioletRed
        If clsFun.GetConnection.State = ConnectionState.Open Then clsFun.CloseConnection()
        sSql = "SELECT * FROM PurchaseType AS IT INNER JOIN Accounts AS Ac ON IT.AccountID = Ac.ID where IT.ID=" & id
        clsFun.con.Open()
        Dim ad As New SQLite.SQLiteDataAdapter(sSql, clsFun.GetConnection)
        Dim ds As New DataSet
        ad.Fill(ds, "a")
        If ds.Tables("a").Rows.Count > 0 Then
            txtID.Text = ds.Tables("a").Rows(0)("ID").ToString()
            txtInvocieTypeName.Text = ds.Tables("a").Rows(0)("InvoicetypeName").ToString()
            cbAccount.Text = ds.Tables("a").Rows(0)("AccountName").ToString()
            Radio = ds.Tables("a").Rows(0)("Taxtype").ToString()
            If Radio = "TE" Then
                RadioExclusive.Checked = True
            ElseIf Radio = "TI" Then
                RadioInclusive.Checked = True
            ElseIf Radio = "TM" Then
                RadioMannual.Checked = True
            ElseIf Radio = "TC" Then
                RadioCompostion.Checked = True
            End If
        End If
    End Sub
    Private Sub Update()
        Dim cmd As New SQLite.SQLiteCommand
        If txtInvocieTypeName.Text = "" Then
            txtInvocieTypeName.Focus()
            MsgBox("Please fill Invoice Type Name... ", MsgBoxStyle.Exclamation, "Access Denied")
        Else
            Dim Radio As String = String.Empty
            If RadioExclusive.Checked Then
                Radio = "TE"
            ElseIf RadioInclusive.Checked Then
                Radio = "TI"
            ElseIf RadioMannual.Checked Then
                Radio = "TM"
            ElseIf RadioCompostion.Checked Then
                Radio = "TC"
            End If
            Dim sql As String = "Update PurchaseType SET InvoiceTypeName='" & txtInvocieTypeName.Text & "', AccountID=" & Val(cbAccount.SelectedValue) & ",Taxtype='" & Radio & "',Price='" & cbPrice.Text & "' WHERE ID=" & Val(txtid.Text) & ""
            cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
            Try
                If clsFun.ExecNonQuery(sql) > 0 Then
                    MsgBox("Record Updated SuccesFully", MsgBoxStyle.Information, "Updated")
                    Panel2.BackColor = Color.Black
                    txtInvocieTypeName.Clear()
                    RadioExclusive.Checked = True
                    txtInvocieTypeName.Focus()
                    Sale_Type_Register.btnRetrive.PerformClick()
                    ' Textclear()
                    BtnSave.Text = "&Save"
                    BtnDelete.Visible = False
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If BtnSave.Text = "&Save" Then
            save()
        Else
            Update()
        End If
    End Sub

    Private Sub cbAccount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAccount.SelectedIndexChanged
        If cbAccount.Text = "Purchase" Then cbPrice.SelectedIndex = 1
        If cbAccount.Text = "Sale" Then cbPrice.SelectedIndex = 0
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        Delete()
    End Sub
    Private Sub Delete()
        Try
            If clsFun.ExecScalarInt("Select tag From PurchaseType  WHERE ID=" & txtid.Text & "") = 0 Then MsgBox("Pre-Define Master. You Can't Delete it.", vbCritical + vbOKOnly, "Access Denied") : Exit Sub
            If MessageBox.Show("Are you Sure to Delete Purchase Type ??", "DELETE", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.OK Then
                If clsFun.ExecNonQuery("DELETE from PurchaseType WHERE ID=" & txtid.Text & "") > 0 Then
                    MsgBox("Record Deleted Successfully.", vbInformation + vbOKOnly, "Deleted")
                    Account_List.btnRetrive.PerformClick()
                    ' lblName.Text = "CREATE ACCOUNT"
                    Panel2.BackColor = Color.Black
                    BtnDelete.Visible = False
                    BtnSave.Text = "&Save"
                    txtInvocieTypeName.Focus()
                End If
            End If
           
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class