Public Class VAS

    Private Sub VAS_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub VAS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clsFun.FillDropDownList(cbTax, "Select * From Taxation", "TaxName", "Id", "")
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True : BtnDelete.Visible = False
        rowColums() : CbPer.SelectedIndex = 0 : VNumber()
    End Sub
    Private Sub VNumber()
        Vno = clsFun.ExecScalarInt("SELECT Count(ID) AS ID FROM VAS ")
        txtSno.Text = Vno + 1
    End Sub
    Private Sub rowColums()
        dg1.ColumnCount = 7
        dg1.Columns(0).Name = "ID" : dg1.Columns(0).Visible = False
        dg1.Columns(1).Name = "SNo." : dg1.Columns(1).Width = 74
        dg1.Columns(2).Name = "VAS Name" : dg1.Columns(2).Width = 188
        dg1.Columns(3).Name = "HSN Code" : dg1.Columns(3).Width = 111
        dg1.Columns(4).Name = "Calc" : dg1.Columns(4).Width = 83
        dg1.Columns(5).Name = "Per" : dg1.Columns(5).Width = 189
        dg1.Columns(6).Name = "Tax" : dg1.Columns(6).Width = 118
        retrive()
    End Sub

    Private Sub txtSno_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSno.KeyDown, txtVASName.KeyDown, CbPer.KeyDown, txtHSNCode.KeyDown, txtCal.KeyDown,
        CbPer.KeyDown, cbTax.KeyDown
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

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If BtnSave.Text = "&Save" Then
            save()
        Else
            Update()
        End If
    End Sub
    Private Sub save()
        Dim cmd As SQLite.SQLiteCommand
        If txtSno.Text = "" Then txtSno.Focus() : MsgBox("Please Fill Serial No. Name... ", MsgBoxStyle.Exclamation, "Empty") : Exit Sub

        If txtVASName.Text = "" Then txtVASName.Focus() : MsgBox("Please Fill VAS Name... ", MsgBoxStyle.Exclamation, "Empty") : Exit Sub


        Dim sql As String = "insert into VAS (Sno, VASName,HSNCode,CalPer,Per,TaxPerID) values (@1, @2,@3,@4,@5,@6)"
        Try
            cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
            cmd.Parameters.AddWithValue("@1", txtSno.Text)
            cmd.Parameters.AddWithValue("@2", txtVASName.Text)
            cmd.Parameters.AddWithValue("@3", txtHSNCode.Text)
            cmd.Parameters.AddWithValue("@4", Val(txtCal.Text))
            cmd.Parameters.AddWithValue("@5", CbPer.Text)
            cmd.Parameters.AddWithValue("@6", cbTax.SelectedValue)
            If cmd.ExecuteNonQuery() > 0 Then
                MsgBox("Record Insert SuccesFully", MsgBoxStyle.Information, "Saved")
                cleartxtall()
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
        dt = clsFun.ExecDataTable("SELECT * FROM VAS AS V INNER JOIN Taxation AS T ON V.TaxPerID = T.ID")
        Try
            If dt.Rows.Count > 0 Then
                dg1.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        '  Sno, VASName, HSNCode, CalPer, Per, TaxPerID
                        .Cells(0).Value = dt.Rows(i)("id").ToString()
                        .Cells(1).Value = dt.Rows(i)("Sno").ToString()
                        .Cells(2).Value = dt.Rows(i)("VASName").ToString()
                        .Cells(3).Value = dt.Rows(i)("HSNCode").ToString()
                        .Cells(4).Value = Format(Val(dt.Rows(i)("CalPer").ToString()), "0.00")
                        .Cells(5).Value = dt.Rows(i)("Per").ToString()
                        .Cells(6).Value = dt.Rows(i)("TaxName").ToString()
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
        lblgroup.Text = "Modify VAS"
        BtnDelete.Visible = True
        BtnSave.Text = "&Update"
        ssql = "SELECT * FROM VAS AS V INNER JOIN Taxation AS T ON V.TaxPerID = T.ID where V.id=" & id
        dt = clsFun.ExecDataTable(ssql) ' where id=" & id & "")
        If dt.Rows.Count > 0 Then
            txtID.Text = dt.Rows(0)("ID").ToString()
            txtSno.Text = dt.Rows(0)("SNo").ToString()
            txtVASName.Text = dt.Rows(0)("VASName").ToString()
            txtHSNCode.Text = dt.Rows(0)("HSNCode").ToString()
            txtCal.Text = Format(Val(dt.Rows(0)("CalPer").ToString()), "0.00")
            CbPer.Text = dt.Rows(0)("Per").ToString()
            cbTax.Text = dt.Rows(0)("TaxName").ToString()
        End If
    End Sub
    Private Sub Update()
        Dim cmd As SQLite.SQLiteCommand
        If txtVASName.Text = "" Then
            txtVASName.Focus()
            MsgBox("Please Fill VAS Name... ", MsgBoxStyle.Exclamation, "Empty")
            Exit Sub
        End If
        'Dim sql As String = "Update VAS Set Sno, VASName,HSNCode,CalPer,Per,TaxPerID) values (@1, @2,@3,@4,@5,@6)"
        Dim sql As String = "Update VAS Set Sno='" & txtSno.Text & "',VASName='" & txtVASName.Text & "'," _
                            & "HSNCode='" & txtHSNCode.Text & "',CalPer='" & txtCal.Text & "',Per='" & CbPer.Text & "',TaxperID='" & Val(cbTax.SelectedValue) & "' " _
                            & "where ID=" & Val(txtID.Text) & ""
        cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
        Try
            If clsFun.ExecNonQuery(sql) > 0 Then
                MessageBox.Show("Record Updated SuccesFully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cleartxtall()

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
    Private Sub cleartxtall()
        txtSno.Clear() : txtVASName.Clear() : txtHSNCode.Clear() : txtCal.Clear()
        txtSno.Focus() : BtnSave.Text = "&Save" : BtnDelete.Visible = False
        retrive() : lblgroup.Text = "VAS" : VNumber()
    End Sub
End Class