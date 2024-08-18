Public Class Tax_Setting

    Private Sub Tax_Setting_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub Tax_Setting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        cbApplyOn.SelectedIndex = 0 : cbDefaultPrice.SelectedIndex = 0
        clsFun.FillDropDownList(cbPostAccount, "Select ID,AccountName From Accounts", "AccountName", "Id", "")
        rowColums() : cbTaxType.SelectedIndex = 0
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub rowColums()
        dg1.ColumnCount = 8
        dg1.Columns(0).Name = "ID" : dg1.Columns(0).Visible = False
        dg1.Columns(1).Name = "Heading" : dg1.Columns(1).Width = 100
        dg1.Columns(2).Name = "AccountID" : dg1.Columns(2).Visible = False
        dg1.Columns(3).Name = "Account" : dg1.Columns(3).Width = 250
        dg1.Columns(4).Name = "Tax Type" : dg1.Columns(4).Width = 150
        dg1.Columns(5).Name = "Apply On" : dg1.Columns(5).Width = 100
        dg1.Columns(6).Name = "Price On" : dg1.Columns(6).Width = 100
        dg1.Columns(7).Name = "Dis %" : dg1.Columns(7).Width = 100
        retrive()
    End Sub
    Private Sub retrive(Optional ByVal condtion As String = "")
        dg1.Rows.Clear()
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("Select * from TaxSetting " & condtion & " order by HeadingName ")
        Try
            If dt.Rows.Count > 0 Then
                dg1.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    Application.DoEvents()
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        'dg1.Rows.Clear()
                        .Cells(0).Value = dt.Rows(i)("id").ToString()
                        .Cells(1).Value = dt.Rows(i)("HeadingName").ToString()
                        .Cells(2).Value = dt.Rows(i)("AccountID").ToString()
                        .Cells(3).Value = dt.Rows(i)("AccountName").ToString()
                        .Cells(4).Value = dt.Rows(i)("TaxType").ToString()
                        .Cells(5).Value = dt.Rows(i)("ApplyOn").ToString()
                        .Cells(6).Value = dt.Rows(i)("DefaultPrice").ToString()
                        .Cells(7).Value = Format(Val(dt.Rows(i)("DisPer").ToString()), "0.00")
                    End With
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "AccoBook")
        End Try
        dg1.ClearSelection()
    End Sub
    Private Sub save()
        Dim TaxType As String
        If clsFun.ExecScalarInt("Select count(*)from TaxSetting where upper(HeadingName)=upper('" & txtHeading.Text & "') AND upper(ApplyOn)=upper('" & cbApplyOn.Text & "') ") = 1 Then
            MsgBox("Heading Name Already Exists...", vbCritical + vbOKOnly, "Access Denied") : txtHeading.Focus() : Exit Sub
        End If
        If txtHeading.Text = "" Then txtHeading.Focus() : MsgBox("Please Fill Heading Name... ", MsgBoxStyle.Exclamation, "Empty") : Exit Sub
        Dim cmd As New SQLite.SQLiteCommand
        If cbTaxType.Text = "Tax Exclusive" Then TaxType = "TE"
        If cbTaxType.Text = "Tax Inclusive" Then TaxType = "TI"
        If cbTaxType.Text = "Tax Mannual" Then TaxType = "TM"
        If cbTaxType.Text = "Tax in Charges" Then TaxType = "TC"
        If cbTaxType.Text = "Tax Paid" Then TaxType = "TP"
        If cbTaxType.Text = "Composition" Then TaxType = "NT"
        Dim sql As String = "insert into TaxSetting (HeadingName,AccountID,AccountName,TaxType,ApplyOn,DefaultPrice,DisPer,InvoicePrefix,InvoiceStart) " & _
                            "values (@1,@2,@3,@4,@5,@6,@7,@8,@9)"
        Try
            cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
            cmd.Parameters.AddWithValue("@1", txtHeading.Text)
            cmd.Parameters.AddWithValue("@2", Val(cbPostAccount.SelectedValue))
            cmd.Parameters.AddWithValue("@3", cbPostAccount.Text)
            cmd.Parameters.AddWithValue("@4", TaxType)
            cmd.Parameters.AddWithValue("@5", cbApplyOn.Text)
            cmd.Parameters.AddWithValue("@6", cbDefaultPrice.Text)
            cmd.Parameters.AddWithValue("@7", Val(txtDisPer.Text))
            cmd.Parameters.AddWithValue("@8", txtPrefix.Text)
            cmd.Parameters.AddWithValue("@9", txtInvoiceStart.Text)

            If cmd.ExecuteNonQuery() > 0 Then
                MsgBox("Tax Setting Saved Successfully...", vbInformation, "successful")
                TxtClear()
            End If
            clsFun.CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message)
            clsFun.CloseConnection()
        End Try
    End Sub
    Public Sub FillControls(ByVal id As Integer)
        Dim TaxType As String
        Dim sSql As String = String.Empty
        Dim Crate As String = String.Empty
        BtnDelete.Enabled = True
        BtnSave.BackColor = Color.Coral
        ' BtnSave.Image = My.Resources.EditItem
        BtnSave.Text = "&Update"
        If clsFun.GetConnection.State = ConnectionState.Open Then clsFun.CloseConnection()
        sSql = "Select * from TaxSetting where id=" & id
        clsFun.con.Open()
        Dim ad As New SQLite.SQLiteDataAdapter(sSql, clsFun.GetConnection)
        Dim ds As New DataSet
        ad.Fill(ds, "a")
        If ds.Tables("a").Rows.Count > 0 Then
            txtHeading.Text = ds.Tables("a").Rows(0)("HeadingName").ToString()
            cbPostAccount.SelectedValue = ds.Tables("a").Rows(0)("AccountID").ToString()
            cbPostAccount.Text = ds.Tables("a").Rows(0)("AccountName").ToString()
            TaxType = ds.Tables("a").Rows(0)("TaxType").ToString()
            If TaxType = "TE" Then cbTaxType.Text = "Tax Exclusive"
            If TaxType = "TI" Then cbTaxType.Text = "Tax Inclusive"
            If TaxType = "TM" Then cbTaxType.Text = "Tax Mannual"
            If TaxType = "TC" Then cbTaxType.Text = "Tax in Charges"
            If TaxType = "TP" Then cbTaxType.Text = "Tax Paid"
            If TaxType = "NT" Then cbTaxType.Text = "Composition"
            cbApplyOn.Text = ds.Tables("a").Rows(0)("ApplyOn").ToString()
            cbDefaultPrice.Text = ds.Tables("a").Rows(0)("DefaultPrice").ToString()
            txtDisPer.Text = Format(Val(ds.Tables("a").Rows(0)("DisPer").ToString()), "0.00")
            txtPrefix.Text = ds.Tables("a").Rows(0)("InvoicePrefix").ToString()
            txtInvoiceStart.Text = Val(ds.Tables("a").Rows(0)("InvoiceStart").ToString())
            txtid.Text = ds.Tables("a").Rows(0)("ID").ToString()
        End If
        dg1.ClearSelection() : txtHeading.Focus()
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
    Private Sub Update()
        Dim TaxType As String
        If clsFun.ExecScalarInt("Select count(*)from TaxSetting where upper(HeadingName)=upper('" & txtHeading.Text & "') AND upper(ApplyOn)=upper('" & cbApplyOn.Text & "') ") > 1 Then
            MsgBox("Heading Name Already Exists...", vbCritical + vbOKOnly, "Access Denied") : txtHeading.Focus() : Exit Sub
        End If
        If txtHeading.Text = "" Then txtHeading.Focus() : MsgBox("Please Fill Heading Name... ", MsgBoxStyle.Exclamation, "Empty") : Exit Sub
        Dim cmd As New SQLite.SQLiteCommand
        If cbTaxType.Text = "Tax Exclusive" Then TaxType = "TE"
        If cbTaxType.Text = "Tax Inclusive" Then TaxType = "TI"
        If cbTaxType.Text = "Tax Mannual" Then TaxType = "TM"
        If cbTaxType.Text = "Tax in Charges" Then TaxType = "TC"
        If cbTaxType.Text = "Tax Paid" Then TaxType = "TP"
        If cbTaxType.Text = "Composition" Then TaxType = "NT"
        '  Dim sql As String = "Update AccountGroup SET GroupName='" & txtGroupName.Text & "',DC='" & lbldc.Text & "',UndergrpID=" & CbUnderGroup.SelectedValue & ",IsPrimary='" & primary & "',ISCHNGDEL=0 WHERE ID=" & Val(txtid.Text) & ""
        Dim sql As String = "Update TaxSetting Set HeadingName='" & txtHeading.Text & "',AccountID='" & Val(cbPostAccount.SelectedValue) & "',AccountName='" & cbPostAccount.Text & "',TaxType='" & TaxType & "',ApplyOn='" & cbApplyOn.Text & "', " & _
                            "DefaultPrice='" & cbDefaultPrice.Text & "',DisPer='" & Val(txtDisPer.Text) & "',InvoicePrefix='" & txtPrefix.Text & "',InvoiceStart='" & Val(txtInvoiceStart.Text) & "' Where ID='" & Val(txtid.Text) & "' "
        cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
        Try
            If clsFun.ExecNonQuery(sql) > 0 Then
                MsgBox("Tax Setting Updated Successfully", MsgBoxStyle.Information, "Updated")
                TxtClear()
            End If
            'con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            'con.Close()
        End Try
    End Sub
    Private Sub TxtClear()
        retrive()
        txtHeading.Clear()
        txtDisPer.Clear()
        txtPrefix.Clear()
        txtInvoiceStart.Clear()
        txtHeading.Focus()
        BtnSave.Text = "&Save"
        BtnDelete.Enabled = False
    End Sub
    Private Sub txtHeading_KeyDown(sender As Object, e As KeyEventArgs) Handles txtHeading.KeyDown, cbPostAccount.KeyDown,
        cbTaxType.KeyDown, cbApplyOn.KeyDown, cbDefaultPrice.KeyDown, txtDisPer.KeyDown, txtPrefix.KeyDown, txtInvoiceStart.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            ProcessTabKey(True)
        End If
        Select Case e.KeyCode
            Case Keys.End
                e.Handled = True
                BtnSave.PerformClick()
                Me.Close()
        End Select
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If BtnSave.Text = "&Save" Then
            save()
        Else
            Update()
        End If
        '    clsFun.FillDropDownList(Purchase.cbSeries, "Select ID,HeadingName ||' : '||TaxType as HeadingName From TaxSetting Where ApplyOn= 'Purchase'", "HeadingName", "Id", "")
    End Sub

    Private Sub BtnSave_GotFocus(sender As Object, e As EventArgs) Handles BtnSave.GotFocus
        BtnSave.BackColor = Color.CadetBlue
    End Sub

    Private Sub BtnSave_Leave(sender As Object, e As EventArgs) Handles BtnSave.Leave
        BtnSave.BackColor = Color.Coral
    End Sub
End Class