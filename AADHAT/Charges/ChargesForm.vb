Public Class ChargesForm
    Private Sub ChargesForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub ChargesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0 : Me.Left = 0
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.BackColor = Color.FromArgb(156, 220, 170)
        clsFun.FillDropDownList(cbAccountName, "Select * From Accounts", "AccountName", "Id", "")
        cbApply.SelectedIndex = 0 : cbFixas.SelectedIndex = 0
        clsFun.FillDropDownList(cbTaxPer, "Select ID,TaxName From Taxation", "TaxName", "Id", "--N.A.--")
        ' BtnUpdate.Visible = False
        BtnDelete.Visible = False
        rowColums() : cbSupply.SelectedIndex = 0
        cbApplyType.SelectedIndex = 0 : cbChargesType.SelectedIndex = 0
    End Sub
    Private Sub retrive()
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("Select * from Charges")
        dg1.Rows.Clear()
        Try
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("id").ToString()
                        .Cells(1).Value = dt.Rows(i)("ChargeName").ToString()
                        .Cells(2).Value = dt.Rows(i)("Calculate").ToString()
                        .Cells(3).Value = dt.Rows(i)("AccountName").ToString()
                        .Cells(4).Value = dt.Rows(i)("ApplyType").ToString()
                        .Cells(5).Value = dt.Rows(i)("ChargesType").ToString()
                        .Cells(6).Value = dt.Rows(i)("ApplyOn").ToString()
                        .Cells(7).Value = dt.Rows(i)("FixAs").ToString()
                        .Cells(8).Value = dt.Rows(i)("TaxName").ToString()
                        .Cells(9).Value = dt.Rows(i)("HSNCode").ToString()
                        .Cells(10).Value = dt.Rows(i)("SupplyType").ToString()
                    End With
                    ' Dg1.Rows.Add()
                Next
            End If
            dt.Dispose()

        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "AccoBook")
        End Try
        dg1.ClearSelection()
    End Sub
    Private Sub Save()
        If TxtChargeName.Text = "" Then MsgBox("Charge Name Can't be Empty.", vbCritical + vbOKOnly, "Access Denied ") : TxtChargeName.Focus() : Exit Sub
        If txtCalculate.Text = "" Then txtCalculate.Text = "0"
        Dim cmd As New SQLite.SQLiteCommand
        Dim sql As String = "insert into Charges (ChargeName,Calculate,AccountID,AccountName,ApplyType, " & _
            "ChargesType,ApplyOn,TaxID,TaxName,HSNCode,RoundOff,FixAs,SupplyType) values (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13)"
        Try
            cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
            cmd.Parameters.AddWithValue("@1", TxtChargeName.Text)
            cmd.Parameters.AddWithValue("@2", txtCalculate.Text)
            cmd.Parameters.AddWithValue("@3", cbAccountName.SelectedValue)
            cmd.Parameters.AddWithValue("@4", cbAccountName.Text)
            cmd.Parameters.AddWithValue("@5", cbApplyType.Text)
            cmd.Parameters.AddWithValue("@6", If(cbChargesType.SelectedIndex = 0, "+", "-"))
            cmd.Parameters.AddWithValue("@7", cbApply.Text)
            cmd.Parameters.AddWithValue("@8", Val(cbTaxPer.SelectedValue))
            cmd.Parameters.AddWithValue("@9", If(cbTaxPer.Visible = False, "--N.A.--", cbTaxPer.Text))
            cmd.Parameters.AddWithValue("@10", txtChargesHSN.Text)
            cmd.Parameters.AddWithValue("@11", ISRoundOFf)
            cmd.Parameters.AddWithValue("@12", cbFixas.Text)
            cmd.Parameters.AddWithValue("@13", cbSupply.Text)
            If cmd.ExecuteNonQuery() > 0 Then
                MsgBox("Record Saved Successfully.", vbInformation + vbOKOnly, "Saved")
                txtclear()
            End If
            clsFun.CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message)
            clsFun.CloseConnection()
        End Try
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.Text = "&Save" Then
            If clsFun.ExecScalarStr("Select count(*)from Charges where ChargeName='" & TxtChargeName.Text & "'") = 1 Then
                MsgBox("Charge Name Already Exists...", vbCritical + vbOKOnly, "Access Denied")
                TxtChargeName.Focus() : Exit Sub
            End If
            Save()
        Else
            If clsFun.ExecScalarStr("Select count(*)from Charges where ChargeName='" & TxtChargeName.Text & "'") > 1 Then
                MsgBox("Charge Name Already Exists...", vbCritical + vbOKOnly, "Access Denied")
                TxtChargeName.Focus() : Exit Sub
            End If
            UpdateCharges()
        End If
    End Sub
    Public Sub FillContros(ByVal id As Integer)
        btnSave.Text = "&Update"
        BtnDelete.Visible = True
        Dim ChargesType As String = ""
        Dim ApplyType As String = ""
        Dim RoundOff As String = ""
        Dim sSql As String = String.Empty
        LblCharges.Text = "MODIFY CHARGES"
        ' btnSave.Image = My.Resources.Edit
        btnSave.BackColor = Color.Coral
        If clsFun.GetConnection.State = ConnectionState.Open Then clsFun.CloseConnection()
        sSql = "Select * from Charges where id=" & id
        clsFun.con.Open()
        Dim ad As New SQLite.SQLiteDataAdapter(sSql, clsFun.GetConnection)
        Dim ds As New DataSet
        ad.Fill(ds, "a")
        If ds.Tables("a").Rows.Count > 0 Then
            txtID.Text = ds.Tables("a").Rows(0)("ID").ToString()
            TxtChargeName.Text = ds.Tables("a").Rows(0)("ChargeName").ToString()
            txtCalculate.Text = ds.Tables("a").Rows(0)("Calculate").ToString()
            cbAccountName.Text = ds.Tables("a").Rows(0)("AccountName").ToString()
            cbApplyType.Text = ds.Tables("a").Rows(0)("ApplyType").ToString()
            cbApply.Text = ds.Tables("a").Rows(0)("ApplyON").ToString()
            cbFixas.Text = ds.Tables("a").Rows(0)("FixAs").ToString()
            cbSupply.Text = ds.Tables("a").Rows(0)("SupplyType").ToString()
            cbTaxPer.SelectedValue = Val(ds.Tables("a").Rows(0)("TaxID").ToString())
            cbTaxPer.Text = ds.Tables("a").Rows(0)("TaxName").ToString()
            txtChargesHSN.Text = ds.Tables("a").Rows(0)("HSNCode").ToString()
            RoundOff = ds.Tables("a").Rows(0)("RoundOff").ToString()
            If ds.Tables("a").Rows(0)("ChargesType").ToString() = "+" Then
                cbChargesType.SelectedIndex = 0
            Else
                cbChargesType.SelectedIndex = 1
            End If
            If RoundOff = "Y" Then CkRoundOff.Checked = True Else CkRoundOff.Checked = False
            If cbTaxPer.SelectedValue <> 0 Then lblGst.Visible = True : txtChargesHSN.Visible = True : cbTaxPer.Visible = True : lblHsn.Visible = True Else _
                lblGst.Visible = False : txtChargesHSN.Visible = False : cbTaxPer.Visible = False : lblHsn.Visible = False
        End If
        TxtChargeName.Focus()
    End Sub

    Private Sub CkRoundOff_GotFocus(sender As Object, e As EventArgs) Handles CkRoundOff.GotFocus
        CkRoundOff.ForeColor = Color.Navy
    End Sub
    Private Sub TxtChargeName_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtChargeName.KeyDown, txtCalculate.KeyDown, cbAccountName.KeyDown, cbApply.KeyDown,
        cbTaxPer.KeyDown, txtChargesHSN.KeyDown, CkRoundOff.KeyDown, cbFixas.KeyDown, cbSupply.KeyDown, cbApplyType.KeyDown, cbChargesType.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            ProcessTabKey(True)
        End If
        Select Case e.KeyCode
            Case Keys.End
                e.Handled = True
                btnSave.Focus()
        End Select
    End Sub
    Private Sub rowColums()
        dg1.ColumnCount = 11
        dg1.Columns(0).Name = "ID" : dg1.Columns(0).Visible = False
        dg1.Columns(1).Name = "Charge Name" : dg1.Columns(1).Width = 220
        dg1.Columns(2).Name = "Cal.@" : dg1.Columns(2).Width = 50
        dg1.Columns(3).Name = "Account Post" : dg1.Columns(3).Width = 200
        dg1.Columns(4).Name = "($/%)" : dg1.Columns(4).Width = 100
        dg1.Columns(5).Name = "(+/-)" : dg1.Columns(5).Width = 50
        dg1.Columns(6).Name = "Apply On" : dg1.Columns(6).Width = 100
        dg1.Columns(7).Name = "Applicable" : dg1.Columns(7).Width = 170
        dg1.Columns(8).Name = "Tax Name" : dg1.Columns(8).Width = 100
        dg1.Columns(9).Name = "HSN Code" : dg1.Columns(9).Width = 80
        dg1.Columns(10).Name = "Supply" : dg1.Columns(10).Width = 80
        retrive()
    End Sub
    Private Sub Delete()
        If clsFun.ExecScalarInt("Select count(*) from ChargesTrans where ChargesID='" & Val(txtID.Text) & "'") <> 0 Then
            MsgBox("Charges Already Used in Transactions", vbCritical + vbOKOnly, "Access Denied")
            Exit Sub
        Else
            Try
                '  If clsFun.ExecScalarInt("Select tag From AccountGroup  WHERE ID=" & txtid.Text & "") = 0 Then MsgBox("access denied", MsgBoxStyle.Critical) : Exit Sub
                '  If clsFun.ExecScalarInt("Select count(*) from Accounts where GroupId=" & Val(txtid.Text) & "") = 1 Then
                If MessageBox.Show("Are you Sure Want to Delete Charges??", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    If clsFun.ExecNonQuery("DELETE from Charges WHERE ID=" & txtID.Text & "") > 0 Then
                        MsgBox("Successfully deleted Charge", vbInformation.Information, "Deleted")
                        txtclear()
                    End If
                End If
                'Else
                'MsgBox("Account Group Cannot delete alreday use in Account", vbCritical + vbOKOnly, "Access Denied")
                'End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub dg1_KeyDown(sender As Object, e As KeyEventArgs) Handles dg1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dg1.SelectedRows.Count = 0 Then Exit Sub
            FillContros(dg1.SelectedRows(0).Cells(0).Value)
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub UpdateCharges()
        If TxtChargeName.Text = "" Then MsgBox("Charge Name Can't be Empty.", vbCritical + vbOKOnly, "Access Denied ") : TxtChargeName.Focus() : Exit Sub
        Dim cmd As New SQLite.SQLiteCommand
        Dim sql As String = "Update Charges SET ChargeName='" & TxtChargeName.Text & "', Calculate='" & txtCalculate.Text & "',  " & _
                                "AccountID=" & Val(cbAccountName.SelectedValue) & ",AccountName='" & cbAccountName.Text & "'," & _
                                "ApplyType='" & cbApplyType.Text & "',ChargesType='" & If(cbChargesType.SelectedIndex = 0, "+", "-") & "',ApplyOn='" & cbApply.Text & "', " & _
                                "TaxID='" & (cbTaxPer.SelectedValue) & "',TaxName='" & If(cbTaxPer.Visible = False, "--N.A.--", cbTaxPer.Text) & "',HSNCode='" & txtChargesHSN.Text & "', " & _
                                " Roundoff='" & RoundOFf & "',Fixas='" & cbFixas.Text & "',SupplyType='" & cbSupply.Text & "' WHERE ID=" & Val(txtID.Text) & ""
        cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
        Try
            If clsFun.ExecNonQuery(sql) > 0 Then
                MsgBox("Record Updated Successfully", MsgBoxStyle.Information, "Updated")
                txtclear()
            End If
            'con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            'con.Close()
        End Try
    End Sub
    Private Sub txtclear()
        txtCalculate.Clear() : TxtChargeName.Clear()
        CkRoundOff.Checked = False
        LblCharges.Text = "CHARGES ENTRY"
        retrive() : txtChargesHSN.Clear()
        ' btnSave.Image = My.Resources.Save
        btnSave.BackColor = Color.DarkTurquoise
        btnSave.Text = "&Save"
        BtnDelete.Visible = False
        TxtChargeName.Focus()
    End Sub

    Private Sub dg1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dg1.MouseDoubleClick
        If dg1.SelectedRows.Count = 0 Then Exit Sub
        FillContros(dg1.SelectedRows(0).Cells(0).Value)
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        Delete()
    End Sub

    Private Sub txtCalculate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCalculate.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8 Or ((e.KeyChar = ".") And (sender.Text.IndexOf(".") = -1)))
    End Sub

    Private Sub TxtChargeName_Leave(sender As Object, e As EventArgs) Handles TxtChargeName.Leave
        If btnSave.Text = "&save" Then
            If clsFun.ExecScalarInt("Select count(*) from ChargesTrans where ChargeName='" & TxtChargeName.Text & "'") = 1 Then
                MsgBox("Charges Already Exists...", vbCritical + vbOKOnly, "Access Denied")
                Exit Sub
                TxtChargeName.Focus()
            End If
        End If
    End Sub

    Private Sub btnClose_Click_1(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub cbTaxPer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTaxPer.SelectedIndexChanged
        If cbTaxPer.SelectedIndex = 0 Then lblHsn.Visible = False : txtChargesHSN.Visible = False Else lblHsn.Visible = True : txtChargesHSN.Visible = True
    End Sub

    Private Sub CkRoundOff_Leave(sender As Object, e As EventArgs) Handles CkRoundOff.Leave
        CkRoundOff.ForeColor = Color.Red
    End Sub

    Private Sub cbFixas_Leave(sender As Object, e As EventArgs) Handles cbFixas.Leave
        If cbFixas.SelectedIndex <> 3 Then cbTaxPer.SelectedValue = 0 : cbTaxPer.Visible = False : lblGst.Visible = False Else cbTaxPer.Visible = True : lblGst.Visible = True
    End Sub

End Class