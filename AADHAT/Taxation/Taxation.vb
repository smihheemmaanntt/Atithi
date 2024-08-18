Public Class Taxation

    Private Sub Taxation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub Taxation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True : BtnDelete.Visible = False
        CbCessOn.SelectedIndex = 0 : cbGstType.SelectedIndex = 0
        rowColums()
    End Sub
    Private Sub rowColums()
        dg1.ColumnCount = 6
        dg1.Columns(0).Name = "ID" : dg1.Columns(0).Visible = False
        dg1.Columns(1).Name = "Tax Name" : dg1.Columns(1).Width = 200
        dg1.Columns(2).Name = "Tax %" : dg1.Columns(2).Width = 80
        dg1.Columns(3).Name = "Tax Type" : dg1.Columns(3).Width = 100
        dg1.Columns(4).Name = "Cess %" : dg1.Columns(4).Width = 80
        dg1.Columns(5).Name = "On Cess" : dg1.Columns(5).Width = 100
        retrive()
    End Sub

    Private Sub retrive(Optional ByVal condtion As String = "")
        dg1.Rows.Clear()
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("Select * from Taxation " & condtion & " order by TaxName ")
        Try
            If dt.Rows.Count > 0 Then
                dg1.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    Application.DoEvents()
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        'dg1.Rows.Clear()
                        .Cells(0).Value = dt.Rows(i)("id").ToString()
                        .Cells(1).Value = dt.Rows(i)("TaxName").ToString()
                        .Cells(2).Value = Format(Val(dt.Rows(i)("GstPer").ToString()), "0.00")
                        .Cells(3).Value = dt.Rows(i)("GSTtype").ToString()
                        .Cells(4).Value = Format(Val(dt.Rows(i)("CessPer").ToString()), "0.00")
                        .Cells(5).Value = dt.Rows(i)("GSTOn").ToString()
                    End With
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "AccoBook")
        End Try
        dg1.ClearSelection()
    End Sub
    Private Sub dg1_KeyDown(sender As Object, e As KeyEventArgs) Handles dg1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dg1.SelectedRows.Count = 0 Then Exit Sub
            FillControls(dg1.SelectedRows(0).Cells(0).Value)
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub dg1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dg1.MouseDoubleClick
        If dg1.SelectedRows.Count = 0 Then Exit Sub
        FillControls(dg1.SelectedRows(0).Cells(0).Value)
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub txtGSTName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtGSTName.KeyDown, cbGstType.KeyDown,
        txtGSTPer.KeyDown, txtCessper.KeyDown, CbCessOn.KeyDown, txtQtyRate.KeyDown, ckOnFree.KeyDown, ckOnMrp.KeyDown
        If e.KeyCode = Keys.Enter Then
            'e.SuppressKeyPress = True
            'ProcessTabKey(True)
            SendKeys.Send("{TAB}")
        End If
        Select Case e.KeyCode
            Case Keys.End
                e.Handled = True
                BtnSave.PerformClick()
                Me.Close()
        End Select
    End Sub
    Private Sub save()
        If clsFun.ExecScalarInt("Select count(*)from Taxation where upper(TaxName)=upper('" & txtGSTName.Text & "')") = 1 Then
            MsgBox("Tax Name Already Exists...", vbCritical + vbOKOnly, "Access Denied") : txtGSTName.Focus() : Exit Sub
        End If
        If txtGSTName.Text = "" Then txtGSTName.Focus() : MsgBox("Please Fill Tax Name... ", MsgBoxStyle.Critical, "Empty") : Exit Sub
        Dim OnFree As String = String.Empty : Dim OnMRP As String = String.Empty
        If ckOnMrp.Checked = True Then OnMRP = "Y" Else OnMRP = "N"
        If ckOnFree.Checked = True Then OnFree = "Y" Else OnFree = "N"

        Dim cmd As New SQLite.SQLiteCommand
        Dim sql As String = "insert into Taxation (TaxName,GSTtype,GSTPer,SGSTPer,CGSTper,CessPer,GSTOn,CessAmt,TaxOnMRP,TaxOnFree) " & _
                            " values (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10)"
        Try
            cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
            cmd.Parameters.AddWithValue("@1", txtGSTName.Text)
            cmd.Parameters.AddWithValue("@2", cbGstType.Text)
            cmd.Parameters.AddWithValue("@3", txtGSTPer.Text)
            cmd.Parameters.AddWithValue("@4", Val(txtGSTPer.Text / 2))
            cmd.Parameters.AddWithValue("@5", Val(txtGSTPer.Text / 2))
            cmd.Parameters.AddWithValue("@6", Val(txtCessper.Text))
            cmd.Parameters.AddWithValue("@7", CbCessOn.Text)
            cmd.Parameters.AddWithValue("@8", Val(txtQtyRate.Text))
            cmd.Parameters.AddWithValue("@9", ckOnMrp)
            cmd.Parameters.AddWithValue("@10", OnFree)
            If cmd.ExecuteNonQuery() > 0 Then
                MsgBox("Taxation Saved Successfully...", vbInformation, "successful")
                cleartext()
            End If
            clsFun.CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message)
            clsFun.CloseConnection()
        End Try
    End Sub
    Public Sub FillControls(ByVal id As Integer)
        Dim sSql As String = String.Empty
        Dim Crate As String = String.Empty
        Dim OnFree As String = String.Empty : Dim OnMRP As String = String.Empty
        BtnDelete.Visible = True
        BtnSave.BackColor = Color.Coral
        '  BtnSave.Image = My.Resources.EditItem
        BtnSave.Text = "&Update" : lblName.Text = "MODIFY ITEM"
        If clsFun.GetConnection.State = ConnectionState.Open Then clsFun.CloseConnection()
        sSql = "Select * from Taxation where id=" & id
        clsFun.con.Open()
        Dim ad As New SQLite.SQLiteDataAdapter(sSql, clsFun.GetConnection)
        Dim ds As New DataSet
        ad.Fill(ds, "a")
        If ds.Tables("a").Rows.Count > 0 Then
            txtGSTName.Text = ds.Tables("a").Rows(0)("TaxName").ToString()
            cbGstType.Text = ds.Tables("a").Rows(0)("GSTtype").ToString()
            txtGSTPer.Text = Format(Val(ds.Tables("a").Rows(0)("GSTPer").ToString()), "0.00")
            txtCessper.Text = Format(Val(ds.Tables("a").Rows(0)("CessPer").ToString()), "0.00")
            CbCessOn.Text = ds.Tables("a").Rows(0)("GSTOn").ToString()
            txtQtyRate.Text = Format(Val(ds.Tables("a").Rows(0)("CessAmt").ToString()), "0.00")
            OnMRP = ds.Tables("a").Rows(0)("TaxOnMRP").ToString()
            If OnMRP = "Y" Then ckOnMrp.Checked = True Else ckOnMrp.Checked = False
            OnFree = ds.Tables("a").Rows(0)("TaxOnFree").ToString()
            If OnFree = "Y" Then ckOnFree.Checked = True Else ckOnFree.Checked = False
            txtid.Text = ds.Tables("a").Rows(0)("ID").ToString()
        End If
        dg1.ClearSelection() : txtGSTName.Focus()
    End Sub
    Private Sub Update()
        If clsFun.ExecScalarInt("Select count(*)from Taxation where upper(TaxName)=upper('" & txtGSTName.Text & "')") > 1 Then
            MsgBox("Tax Name Already Exists...", vbCritical + vbOKOnly, "Access Denied") : txtGSTName.Focus() : Exit Sub
        End If
        Dim OnFree As String = String.Empty : Dim OnMRP As String = String.Empty
        If txtGSTName.Text = "" Then txtGSTName.Focus() : MsgBox("Please Fill Tax Name... ", MsgBoxStyle.Critical, "Empty") : Exit Sub
        If ckOnMrp.Checked = True Then OnMRP = "Y" Else OnMRP = "N"
        If ckOnFree.Checked = True Then OnFree = "Y" Else OnFree = "N"
        Dim cmd As New SQLite.SQLiteCommand
        Dim sql As String = "Update Taxation SET TaxName='" & txtGSTName.Text & "',GSTtype='" & cbGstType.Text & "' ,GSTPer='" & Val(txtGSTPer.Text) & "', " & _
                            "SGSTPer='" & Val(txtGSTPer.Text / 2) & "' ,CGSTper='" & Val(txtGSTPer.Text / 2) & "',CessPer='" & Val(txtCessper.Text) & "', " & _
                            "GSTOn='" & CbCessOn.Text & "' ,CessAmt='" & Val(txtQtyRate.Text) & "',TaxOnMRP='" & OnMRP & "', " & _
                            "TaxOnMRP='" & OnFree & "' WHERE ID=" & Val(txtid.Text) & ""
        cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
        Try
            If clsFun.ExecNonQuery(sql) > 0 Then
                MsgBox("Record Updated Successfully", MsgBoxStyle.Information, "Updated")
                cleartext()
                '  txtBrandName.Clear() : txtBrandDis.Clear() : txtBrandName.Focus() : retrive() : BtnSave.Text = "&Save"
            End If
            'con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            'con.Close()
        End Try
    End Sub
    Private Sub cleartext()
        txtGSTName.Clear() : txtGSTPer.Clear()
        txtCessper.Clear() : txtGSTName.Focus()
        txtQtyRate.Clear()
        ckOnMrp.Checked = False : ckOnFree.Checked = False
        txtGSTName.Focus() : BtnDelete.Visible = False
        retrive()
        BtnSave.Text = "&Save"
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If BtnSave.Text = "&Save" Then
            save()
        Else
            Update()
        End If
    End Sub

    Private Sub CbCessOn_KeyUp(sender As Object, e As KeyEventArgs) Handles CbCessOn.KeyUp

    End Sub

    Private Sub CbCessOn_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbCessOn.SelectedIndexChanged
        If CbCessOn.SelectedIndex = 1 Then
            lblCessPer.Enabled = True : txtCessper.Enabled = True
            lblRatePer.Enabled = False : txtQtyRate.Enabled = False : txtQtyRate.Text = ""
        ElseIf CbCessOn.SelectedIndex = 2 Then
            lblRatePer.Enabled = True : txtQtyRate.Enabled = True
            lblCessPer.Enabled = False : txtCessper.Enabled = False : txtCessper.Text = ""
        ElseIf CbCessOn.SelectedIndex = 3 Then
            lblRatePer.Enabled = True : txtQtyRate.Enabled = True
            lblCessPer.Enabled = True : txtCessper.Enabled = True
        Else
            lblRatePer.Enabled = False : txtQtyRate.Enabled = False : txtQtyRate.Text = ""
            lblCessPer.Enabled = False : txtCessper.Enabled = False : txtCessper.Text = ""
        End If
    End Sub
End Class