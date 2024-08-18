Public Class POS
    Dim Tempdt As New DataTable

    Dim sql As String = String.Empty
    Dim VchID As Integer = 0

    Private Sub POS_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If dg1.RowCount = 0 Then
                Me.Close()
            Else
                If MessageBox.Show("Are You Sure Want to Exit POS... ?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                    Me.Close()
                End If
            End If
        End If

    End Sub
    Private Sub Test_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.Top = 0.5 : Me.Left = 179
        mskEntryDate.Text = Date.Today.ToString("dd-MM-yyyy")
        RetriveGroups() : Dg1Colums() : VNumber()
        Me.KeyPreview = True
    End Sub
    Private Sub Dg1Colums()
        dg1.ColumnCount = 8
        dg1.Columns(0).Name = "ID" : dg1.Columns(0).Visible = False
        dg1.Columns(1).Name = "S.No" : dg1.Columns(1).Width = 50
        dg1.Columns(2).Name = "Item Name" : dg1.Columns(2).Width = 200
        dg1.Columns(3).Name = "Qty" : dg1.Columns(3).Width = 50
        dg1.Columns(4).Name = "Rate" : dg1.Columns(4).Width = 80
        dg1.Columns(5).Name = "Amount" : dg1.Columns(5).Width = 100
        dg1.Columns(6).Name = "TaxPer" : dg1.Columns(6).Width = 50
        dg1.Columns(7).Name = "TaxAmt" : dg1.Columns(7).Width = 50
    End Sub
    Private Sub txtclear()
        dg1.Rows.Clear()
        txtAmt.Clear() : txtTaxAmt.Clear()
        txtTotAmt.Clear() : txtDiscAmt.Clear()
        txtDisPer.Clear() : txtServicePer.Clear()
        txtServiceAmt.Clear() : txtPackingPer.Clear()
        txtPackingAmt.Clear() : txtTotAmt.Clear()
        txtCashAmt.Clear() : txtChangeAmt.Clear()
        txtMobileNo.Clear() : txtCustomerName.Clear()
        txtGstNo.Clear() : txtRemark.Clear()
        CkIGST.Checked = False : CheckBox2.Checked = False
        VNumber() : BtnSave.Text = "&Save && Print"
    End Sub
    Public Sub FillControls(ByVal id As Integer)
        Dim sSql As String = String.Empty
        Dim IsIGST As String = String.Empty
        'lblName.Text = "MODIFY ITEM"
        Panel2.BackColor = Color.PaleVioletRed
        BtnSave.Visible = True
        btnDeleteBill.Visible = True
        BtnSave.Text = "&Update N Print"
        '  Panel1.BackColor = Color.PaleVioletRed
        If clsFun.GetConnection.State = ConnectionState.Open Then clsFun.CloseConnection()
        sSql = "Select * from Trans_View where id=" & Val(id)
        clsFun.con.Open()
        Dim ad As New SQLite.SQLiteDataAdapter(sSql, clsFun.GetConnection)
        Dim ds As New DataSet
        ad.Fill(ds, "a")
        If ds.Tables("a").Rows.Count > 0 Then
            txtID.Text = ds.Tables("a").Rows(0)("ID").ToString()
            mskEntryDate.Text = Format(ds.Tables("a").Rows(0)("EntryDate"), "dd-MM-yyyy")
            txtBillNo.Text = ds.Tables("a").Rows(0)("InvoiceNo").ToString()
            txtCustomerName.Text = ds.Tables("a").Rows(0)("CustomerName").ToString()
            txtRemark.Text = ds.Tables("a").Rows(0)("CustomerAddress").ToString()
            txtMobileNo.Text = ds.Tables("a").Rows(0)("CustomerMobile").ToString()
            txtGstNo.Text = ds.Tables("a").Rows(0)("CustomerGSTN").ToString()
            txtAmt.Text = Format(Val(ds.Tables("a").Rows(0)("TotalBasicAmt").ToString()), "0.00")
            txtTaxAmt.Text = Format(Val(ds.Tables("a").Rows(0)("TotalTaxAmt").ToString()), "0.00")
            txtDisPer.Text = Val(ds.Tables("a").Rows(0)("TotalDiscPer").ToString())
            txtDiscAmt.Text = Format(Val(ds.Tables("a").Rows(0)("TotalDiscAmt").ToString()), "0.00")
            txtServicePer.Text = Val(ds.Tables("a").Rows(0)("TotServicePer").ToString())
            txtServiceAmt.Text = Format(Val(ds.Tables("a").Rows(0)("TotServiceAmt").ToString()), "0.00")
            txtPackingPer.Text = Val(ds.Tables("a").Rows(0)("totPackingPer").ToString())
            txtPackingAmt.Text = Format(Val(ds.Tables("a").Rows(0)("totPackingAmt").ToString()), "0.00")
            txtTotAmt.Text = Format(Val(ds.Tables("a").Rows(0)("TotalGrandAmt").ToString()), "0.00")
            txtCashAmt.Text = Format(Val(ds.Tables("a").Rows(0)("TotalCashAmt").ToString()), "0.00")
            txtChangeAmt.Text = Format(Val(ds.Tables("a").Rows(0)("TotalBalAmt").ToString()), "0.00")
            IsIGST = ds.Tables("a").Rows(0)("IsIGST").ToString()
            If IsIGST = "Y" Then
                CkIGST.Checked = True
            Else
                CkIGST.Checked = False
            End If

        End If
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("Select * from Trans_View where id=" & id)
        Dim dvData As DataView = New DataView(dt)
        Try
            If dt.Rows.Count > 0 Then
                dg1.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("ItemID").ToString()
                        .Cells(1).Value = dt.Rows(i)("Sno").ToString()
                        .Cells(2).Value = dt.Rows(i)("ItemName").ToString()
                        .Cells(3).Value = Format(Val(dt.Rows(i)("Qty").ToString()), "0.00")
                        .Cells(4).Value = Format(Val(dt.Rows(i)("Rate").ToString()), "0.00")
                        .Cells(5).Value = Format(Val(dt.Rows(i)("BasicAmt").ToString()), "0.00")
                        .Cells(6).Value = Format(Val(dt.Rows(i)("TaxPer").ToString()), "0.00")
                        .Cells(7).Value = Format(Val(dt.Rows(i)("TaxAmt").ToString()), "0.00")
                    End With
                Next

            End If

        Catch ex As Exception

        End Try
        '  calc()
        dg1.ClearSelection()
    End Sub
    Private Sub RetriveGroups()
        dt = clsFun.ExecDataTable("SELECT * FROM ItemGroup ")
        Dim i As Integer
        For i = 0 To dt.Rows.Count - 1
            Application.DoEvents()
            Dim btn As New Button
            btn.Width = 100
            btn.Height = 100
            btn.Text = dt.Rows(i)("GroupName").ToString()
            btn.BackColor = Color.Orange : btn.ForeColor = Color.GhostWhite
            btn.TextAlign = ContentAlignment.MiddleCenter
            btn.Visible = True
            FlowLayoutPanel1.Controls.Add(btn)
            AddHandler btn.Click, AddressOf clickme
        Next
    End Sub
    Private Sub clickme(sender As Object, ByVal e As EventArgs)
        Dim btn As New Button
        btn = CType(sender, Button)
        Dim str As String = btn.Text
        FlowLayoutPanel1.Controls.Clear()
        dt = clsFun.ExecDataTable("SELECT * FROM Item_View Where GroupName='" & str & "' ")
        Dim i As Integer
        For i = 0 To dt.Rows.Count - 1
            Application.DoEvents()
            btn = New Button
            btn.Width = 100
            btn.Height = 100
            btn.Text = dt.Rows(i)("ItemName").ToString()
            btn.BackColor = Color.Yellow : btn.ForeColor = Color.BlueViolet
            btn.TextAlign = ContentAlignment.MiddleCenter
            btn.Visible = True
            FlowLayoutPanel1.Controls.Add(btn)
            AddHandler btn.Click, AddressOf clickmeItems
        Next
        btnMenu.Visible = True
    End Sub

    Private Sub clickmeItems(sender As Object, ByVal e As EventArgs)
        Dim btn As New Button
        btn = CType(sender, Button)
        Dim str As String = btn.Text
        dt = clsFun.ExecDataTable("Select * FROM Item_View Where ItemName='" & str & "'")
        Dim dvData As DataView = New DataView(dt)
        Try
            If dt.Rows.Count > 0 Then
                dg1.Rows.Add(dt.Rows(i)("id").ToString(), dg1.RowCount + 1, dt.Rows(i)("ItemName").ToString(), Format(Val(1), "0.00"),
                                            Format(Val(dt.Rows(i)("PosRate").ToString()), "0.00"), Format(Val(1) * Val(dt.Rows(i)("PosRate").ToString()), "0.00"),
                                             Format(Val(dt.Rows(i)("GSTPer").ToString()), "0.00"), Format(Val(dt.Rows(i)("GSTPer").ToString()) * Val(dt.Rows(i)("PosRate").ToString()) / 100, "0.00"))
                dg1.ClearSelection()
                calc()
            End If
            dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "Atithi")
        End Try
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnMenu.Click
        FlowLayoutPanel1.Controls.Clear()
        RetriveGroups() : btnMenu.Visible = False
    End Sub
    Private Sub VNumber()
        Vno = clsFun.ExecScalarInt("SELECT Count(ID) AS NumberOfProducts FROM Vouchers Where TransType='" & Me.Text & "'")
        txtBillNo.Text = Vno + 1
    End Sub
    Private Sub save()
        Dim dt As DateTime
        Dim IsIGST As String = String.Empty
        If CkIGST.Checked = True Then
            IsIGST = "Y"
        Else
            IsIGST = "N"
        End If
        dt = CDate(Me.mskEntryDate.Text)
        ' Change the format:
        SqliteEntryDate = dt.ToString("yyyy-MM-dd")
        If dg1.Rows.Count = 0 Then
            Exit Sub
            MsgBox("There is no record to Save.", vbCritical + vbOKOnly, "Empty Record")
        End If
        dg1.ClearSelection()
        Dim cmd As SQLite.SQLiteCommand
        sql = "insert into Vouchers(TransType,EntryDate,InvoiceNo,CustomerName, CustomerAddress, " _
            & " CustomerMobile, CustomerGSTN,TotalBasicAmt,TotalDiscPer,TotalDiscAmt,TotServicePer, " _
            & " TotServiceAmt,totPackingPer,totPackingAmt,TotalGrandAmt,TotalCashAmt,TotalBalAmt,  " _
            & " TotalTaxAmt,TotalIGSTAmt,TotalSGSTAmt,TotalCGSTAmt,IsIGST) " _
            & " values (@1, @2, @3, @4, @5, @6, @7, @8,@9, @10, @11, @12, @13, @14, @15, @16, @17, @18, @19, @20,@21,@22)"
        Try
            cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
            cmd.Parameters.AddWithValue("@1", Me.Text)
            cmd.Parameters.AddWithValue("@2", SqliteEntryDate)
            cmd.Parameters.AddWithValue("@3", txtBillNo.Text)
            cmd.Parameters.AddWithValue("@4", txtCustomerName.Text)
            cmd.Parameters.AddWithValue("@5", txtRemark.Text)
            cmd.Parameters.AddWithValue("@6", txtMobileNo.Text)
            cmd.Parameters.AddWithValue("@7", txtGstNo.Text)
            cmd.Parameters.AddWithValue("@8", Val(txtAmt.Text))
            cmd.Parameters.AddWithValue("@9", Val(txtDisPer.Text))
            cmd.Parameters.AddWithValue("@10", Val(txtDiscAmt.Text))
            cmd.Parameters.AddWithValue("@11", Val(txtServicePer.Text))
            cmd.Parameters.AddWithValue("@12", Val(txtServiceAmt.Text))
            cmd.Parameters.AddWithValue("@13", Val(txtPackingPer.Text))
            cmd.Parameters.AddWithValue("@14", txtPackingAmt.Text)
            cmd.Parameters.AddWithValue("@15", txtTotAmt.Text)
            cmd.Parameters.AddWithValue("@16", txtCashAmt.Text)
            cmd.Parameters.AddWithValue("@17", txtChangeAmt.Text)
            cmd.Parameters.AddWithValue("@18", txtTaxAmt.Text)
            cmd.Parameters.AddWithValue("@19", IIf(CkIGST.Checked = True, Val(txtTaxAmt.Text), 0))
            cmd.Parameters.AddWithValue("@20", IIf(CkIGST.Checked = True, 0, Val(txtTaxAmt.Text) / 2))
            cmd.Parameters.AddWithValue("@21", IIf(CkIGST.Checked = True, 0, Val(txtTaxAmt.Text) / 2))
            cmd.Parameters.AddWithValue("@22", IsIGST)
            If cmd.ExecuteNonQuery() > 0 Then
            End If
            clsFun.CloseConnection()
            txtID.Text = Val(clsFun.ExecScalarInt("Select Max(ID) from Vouchers"))
            dg1Record()
            Ledger()
            MsgBox("Record Saved Successfully.", vbInformation + vbOKOnly, "Saved") 'Insert SuccesFully", "SuccessFully", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtclear()
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
            clsFun.CloseConnection()
        End Try
    End Sub
    Private Sub dg1Record()
        Dim FastQuery As String = String.Empty
        sql = String.Empty
        For Each row As DataGridViewRow In dg1.Rows
            With row
                If .Cells("ID").Value <> "" Then
                    FastQuery = FastQuery & IIf(FastQuery <> "", " UNION ALL SELECT ", " SELECT ") & "'" & Me.Text & "', '" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "'," & _
                        "'" & Val(txtID.Text) & "','" & Val(.Cells(0).Value) & "','" & .Cells(2).Value & "','" & .Cells(1).Value & "'," & _
                        "'" & Val(.Cells(3).Value) & "','" & .Cells(4).Value & "','" & Val(.Cells(5).Value) & "', " & _
                         "'" & Val(.Cells(6).Value) & "','" & Val(.Cells(7).Value) & "','" & IIf(CkIGST.Checked = True, Val(.Cells(6).Value), 0) & "'," & _
                          "'" & IIf(CkIGST.Checked = True, Val(.Cells(7).Value), 0) & "','" & IIf(CkIGST.Checked = True, 0, Val(.Cells(6).Value) / 2) & "', " & _
                          "'" & IIf(CkIGST.Checked = True, 0, Val(.Cells(7).Value) / 2) & "','" & IIf(CkIGST.Checked = True, 0, Val(.Cells(6).Value) / 2) & "', " & _
                          "'" & IIf(CkIGST.Checked = True, 0, Val(.Cells(6).Value) / 2) & "'"
                End If
            End With
        Next
        If FastQuery = "" Then Exit Sub
        sql = "insert into Trans(TransType,EntryDate,VoucherID, ItemID,ItemName, SNo, Qty, Rate, BasicAmt,TaxPer,TaxAmt,IGSTPer,IGSTAmt, " & _
                        " SgstPer,SgstAmt,CgstPer,CgstAmt)" & FastQuery
        Try

            cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
            If cmd.ExecuteNonQuery() > 0 Then count = +1
        Catch ex As Exception
            MsgBox(ex.Message)
            clsFun.CloseConnection()
        End Try
        clsFun.CloseConnection()
    End Sub

    Private Sub dg1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg1.CellClick
        dg1.SelectedRows(0).Cells(0).ReadOnly = True : dg1.SelectedRows(0).Cells(1).ReadOnly = True
        dg1.SelectedRows(0).Cells(2).ReadOnly = True : dg1.SelectedRows(0).Cells(4).ReadOnly = True
        dg1.SelectedRows(0).Cells(5).ReadOnly = True
        dg1.SelectedRows(0).Cells(3).ReadOnly = False
        dg1.BeginEdit(True)
    End Sub

    Private Sub dg1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg1.CellDoubleClick
        If dg1.SelectedRows.Count = 0 Then Exit Sub
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dg1.SelectedRows.Count = 0 Then Exit Sub
        dg1.Rows.Remove(dg1.SelectedRows(0))
        DgvAutoSerialNumbering() : btnDelete.Visible = False
        dg1.ClearSelection() : calc()
        'ClearItems()
        ' End If
    End Sub

    Private Sub dg1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dg1.CellValueChanged
        Me.dg1.CurrentRow.Cells(5).Value = Format(Val(Val(Me.dg1.CurrentRow.Cells(3).Value) * Val(Me.dg1.CurrentRow.Cells(4).Value)), "0.00")
        Me.dg1.CurrentRow.Cells(3).Value = Format(Val(Me.dg1.CurrentRow.Cells(3).Value), "0.00")
        calc()
    End Sub

    Private Sub dg1_KeyDown(sender As Object, e As KeyEventArgs) Handles dg1.KeyDown

    End Sub

    

    Private Sub dg1_MouseClick(sender As Object, e As MouseEventArgs) Handles dg1.MouseClick
        If dg1.SelectedRows.Count = 0 Then Exit Sub
        btnDelete.Visible = True
    End Sub
    Private Sub DgvAutoSerialNumbering()
        Dim SlNumber As Integer = 0
        If Me.dg1.Rows.Count = 0 Then
            SlNumber = 1
        ElseIf Me.dg1.Rows.Count > 0 Then
            For i As Integer = 0 To Me.dg1.Rows.Count - 1
                SlNumber = Me.dg1.Rows.Count
                Me.dg1.CurrentRow.Cells(1).Value = SlNumber
            Next
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles txtTaxAmt.TextChanged

    End Sub
    Sub calc()
        txtAmt.Text = Format(0, "0.00") : txtTaxAmt.Text = Format(0, "0.00")
        txtDiscAmt.Text = Format(0, "0.00") : txtTotQty.Text = Format(0, "0.00")
        txtPackingAmt.Text = Format(0, "0.00") : txtServiceAmt.Text = Format(0, "0.00")
        txtTotAmt.Text = Format(0, "0.00") : txtCashAmt.Text = Format(0, "0.00")
        txtChangeAmt.Text = Format(0, "0.00")
        For i = 0 To dg1.Rows.Count - 1
            txtAmt.Text = Format(Val(txtAmt.Text) + Val(dg1.Rows(i).Cells(5).Value), "0.00")
            txtTotQty.Text = Format(Val(txtTotQty.Text) + Val(dg1.Rows(i).Cells(3).Value), "0.00")
            txtTaxAmt.Text = Format(Val(txtTaxAmt.Text) + Val(dg1.Rows(i).Cells(7).Value), "0.00")
        Next
        calculation()
    End Sub

    Private Sub calculation()
        Dim tmpamt As Decimal = 0.0
        tmpamt = Val(txtAmt.Text) + Val(txtTaxAmt.Text)
        txtDiscAmt.Text = Format(Val(tmpamt) * Val(txtDisPer.Text) / 100, "0.00")
        txtServiceAmt.Text = Format(Val(tmpamt) * Val(txtServicePer.Text) / 100, "0.00")
        txtPackingAmt.Text = Format(Val(tmpamt) * Val(txtPackingPer.Text) / 100, "0.00")
        txtTotAmt.Text = Format(Val(Val(tmpamt) - Val(txtDiscAmt.Text)) + Val(txtServiceAmt.Text) + Val(txtPackingAmt.Text), "0.00")
        txtCashAmt.Text = Format(Val(txtTotAmt.Text), "0.00")
    End Sub
    Private Sub txtAmt_TextChanged(sender As Object, e As EventArgs) Handles txtAmt.TextChanged,
        txtDiscAmt.TextChanged, txtDisPer.TextChanged, txtServicePer.TextChanged, txtPackingPer.TextChanged,
        txtServiceAmt.TextChanged, txtPackingAmt.TextChanged, txtTotAmt.TextChanged
        calculation()
    End Sub

    Private Sub txtCashAmt_Leave(sender As Object, e As EventArgs) Handles txtCashAmt.Leave
        txtChangeAmt.Text = Format(CDbl(Val(txtTotAmt.Text)) - CDbl(Val(txtCashAmt.Text)), "0.00")
    End Sub
    Private Sub Update()
        Dim IsIGST As String = String.Empty
        sql = String.Empty
        Dim dt As DateTime
        dt = CDate(Me.mskEntryDate.Text)
        ' Change the format:
        SqliteEntryDate = dt.ToString("yyyy-MM-dd")
        Dim count As Integer = 0
        dg1.ClearSelection()
        If CkIGST.Checked Then
            IsIGST = "Y"
        Else
            IsIGST = "N"
        End If
        Dim cmd As SQLite.SQLiteCommand
        sql = "Update Vouchers SET TransType = '" & Me.Text & "',EntryDate= '" & SqliteEntryDate & "',InvoiceNo= '" & txtBillNo.Text & "',CustomerName ='" & txtCustomerName.Text & "', CustomerAddress = '" & txtRemark.Text & "', " _
          & " CustomerMobile = '" & txtMobileNo.Text & "', CustomerGSTN = '" & txtGstNo.Text & "',TotalBasicAmt= " & Val(txtAmt.Text) & ",TotalDiscPer= " & Val(txtDisPer.Text) & ",TotalDiscAmt = " & Val(txtTotAmt.Text) & ",TotServicePer= " & Val(txtServicePer.Text) & ", " _
          & " TotServiceAmt = " & Val(txtServiceAmt.Text) & ",totPackingPer=" & Val(txtPackingPer.Text) & ",totPackingAmt=" & Val(txtPackingAmt.Text) & ",TotalGrandAmt=" & Val(txtTotAmt.Text) & ",TotalCashAmt= " & Val(txtCashAmt.Text) & ",TotalBalAmt= " & Val(txtChangeAmt.Text) & " ," _
          & "TotalTaxAmt=" & Val(txtTaxAmt.Text) & ",TotalIGSTAmt=" & IIf(CkIGST.Checked = True, txtTaxAmt.Text, 0) & ",TotalSGSTAmt=" & IIf(CkIGST.Checked = True, 0, txtTaxAmt.Text / 2) & ",TotalCGSTAmt=" & IIf(CkIGST.Checked = True, 0, txtTaxAmt.Text / 2) & "," _
          & "IsIGST='" & IsIGST & "' Where ID=" & txtID.Text & ""
        Try
            If clsFun.ExecNonQuery(sql) > 0 Then
                clsFun.CloseConnection()
            End If
            If clsFun.ExecNonQuery("DELETE from Ledger WHERE VouchersID=" & txtID.Text & "") > 0 Then
            End If
            If clsFun.ExecNonQuery("DELETE from Trans WHERE VoucherID=" & txtID.Text & "") > 0 Then
            End If
            VchID = txtID.Text
            dg1Record()
            'dg2Record()
            Ledger()
            '   ChargeInsert()
            btnDelete.Enabled = False
            ' Panel1.BackColor = Color.Black
            MsgBox("Record Updated Successfully.", vbInformation + vbOKOnly, "Update") 'Insert SuccesFully", "SuccessFully", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtclear()
            clsFun.CloseConnection()
            ' clearTxtAll()
        Catch ex As Exception
            MsgBox(ex.Message)
            clsFun.CloseConnection()
        End Try
    End Sub
    Private Sub Delete()
        If MessageBox.Show("Are You Sure Want to Delete ?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
            If clsFun.ExecNonQuery("DELETE from Vouchers WHERE ID=" & Val(txtID.Text) & "") > 0 Then
            End If
            If clsFun.ExecNonQuery("DELETE from Ledger WHERE VouchersID=" & Val(txtID.Text) & "") > 0 Then
            End If
            If clsFun.ExecNonQuery("DELETE from Trans WHERE VoucherID=" & Val(txtID.Text) & "") > 0 Then
            End If
            MsgBox("Record Deleted Successfully", vbInformation + vbOKOnly, "Deleted")
            txtclear()
        End If
    End Sub
    Private Sub Ledger()
        Dim dt As DateTime
        dt = CDate(Me.mskEntryDate.Text)
        ' Change the format:
        SqliteEntryDate = dt.ToString("yyyy-MM-dd")
        If Val(txtAmt.Text) > 0 Then ''Sale Account Fixed
            clsFun.Ledger(0, Val(txtID.Text), SqliteEntryDate, Me.Text, 37, clsFun.ExecScalarStr("Select AccountName from Accounts where Id=37"), Val(txtAmt.Text), "C")
        End If
        If Val(txtPackingAmt.Text) > 0 Then ''Packing Charges 
            clsFun.Ledger(0, Val(txtID.Text), SqliteEntryDate, Me.Text, 56, clsFun.ExecScalarStr("Select AccountName from Accounts where Id=56"), Val(txtPackingAmt.Text), "C")
        End If
        If Val(txtServiceAmt.Text) > 0 Then ''Service Charges 
            clsFun.Ledger(0, Val(txtID.Text), SqliteEntryDate, Me.Text, 57, clsFun.ExecScalarStr("Select AccountName from Accounts where Id=57"), Val(txtServiceAmt.Text), "C")
        End If
        If Val(txtDiscAmt.Text) > 0 Then ''Packing Charges 
            clsFun.Ledger(0, Val(txtID.Text), SqliteEntryDate, Me.Text, 17, clsFun.ExecScalarStr("Select AccountName from Accounts where Id=17"), Val(txtDiscAmt.Text), "D")
        End If
        If Val(txtCashAmt.Text) > 0 Then ''Service Charges 
            clsFun.Ledger(0, Val(txtID.Text), SqliteEntryDate, Me.Text, 11, clsFun.ExecScalarStr("Select AccountName from Accounts where Id=11"), Val(txtCashAmt.Text), "D")
        End If
        If CkIGST.Checked = False Then
            If Val(txtTaxAmt.Text) > 0 Then
                'SGST amount
                clsFun.Ledger(0, Val(txtID.Text), SqliteEntryDate, Me.Text, 1000, clsFun.ExecScalarStr("Select AccountName from Accounts where Id=998"), Val(txtTaxAmt.Text) / 2, "C")
                'CGST amount
                clsFun.Ledger(0, Val(txtID.Text), SqliteEntryDate, Me.Text, 998, clsFun.ExecScalarStr("Select AccountName from Accounts where Id=999"), Val(txtTaxAmt.Text) / 2, "C")
            End If
        Else
            If Val(txtTaxAmt.Text) > 0 Then
                ' IGST amount 
                clsFun.Ledger(0, Val(txtID.Text), SqliteEntryDate, Me.Text, 1000, clsFun.ExecScalarStr("Select AccountName from Accounts where Id=1000"), Val(txtTaxAmt.Text), "C")
            End If
            End If
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If BtnSave.Text = "&Save N Print" Then
            save()
        Else
            Update()
        End If
        Dim res = MessageBox.Show("Do you want to Print Bill", "Print POS", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If res = Windows.Forms.DialogResult.Yes Then
            FillData()
            clsFun.CloseConnection()
            If clsFun.ExecScalarStr("Select KOTPreview From Options") = "Y" Then
                clsFun.changeCompany()
                PrintRecord()
                Report_Viewer.printReport("\POS.rpt")
                Report_Viewer.MdiParent = MainScreenForm
                Report_Viewer.Show()
                If Not Report_Viewer Is Nothing Then
                    Report_Viewer.BringToFront()
                End If
            Else
                clsFun.changeCompany()
                PrintRecord()
                Report_Viewer.printReportDirect("\POS.rpt")
            End If

        Else
        End If
    End Sub

    Private Sub btnDeleteBill_Click(sender As Object, e As EventArgs) Handles btnDeleteBill.Click
        Delete()
    End Sub
    Private Sub TempRowColumn()
        Tempdt.Columns.Clear()
        With Tempdt
            .Columns.AddRange(New DataColumn(42) {
                              New DataColumn("Id"),
                              New DataColumn("EntyDate"),
                              New DataColumn("TransType"),
                           New DataColumn("InvoiceNo"),
                        New DataColumn("AccountName"),
                                New DataColumn("ItemName"),
                              New DataColumn("SNo"),
                              New DataColumn("Qty"),
                           New DataColumn("Rate"),
                        New DataColumn("Per"),
                          New DataColumn("BasicAmt"),
                         New DataColumn("DisPer"),
                              New DataColumn("DisAmt"),
                              New DataColumn("TaxPer"),
                           New DataColumn("TaxAmt"),
                        New DataColumn("TotalAmt"),
                          New DataColumn("SgstPer"),
                              New DataColumn("SGSTamt"),
                              New DataColumn("CGSTPer"),
                           New DataColumn("CGSTAmt"),
                               New DataColumn("IGSTPer"),
                        New DataColumn("IGSTAmt"),
                               New DataColumn("TotalBasicAmt"),
                          New DataColumn("TotalTaxAmt"),
                                       New DataColumn("TotalSGSTAmt"),
                               New DataColumn("TotalCGSTAmt"),
                        New DataColumn("TotalIGSTAmt"),
                               New DataColumn("TotDisPer"),
                          New DataColumn("TotDisAmt"),
                                          New DataColumn("TotPackingPer"),
                              New DataColumn("TotPackingAmt"),
                                New DataColumn("TotServicePer"),
                                New DataColumn("TotServiceAmt"),
                               New DataColumn("TotalGrandAmt"),
                        New DataColumn("TotalCashAmt"),
                            New DataColumn("TotalChangeAmt"),
                                       New DataColumn("HSNCode"),
                              New DataColumn("ItemCode"),
                              New DataColumn("RatePer"),
                           New DataColumn("CustomerName"),
                        New DataColumn("MObileNo"),
                                New DataColumn("GSTN"),
                              New DataColumn("Remark")})
        End With
    End Sub
    Sub FillData()
        Tempdt.Rows.Clear()
        Dim i, j As Integer
        Dim dt As New DataTable
        Dim cnt As Integer = -1
        dt = clsFun.ExecDataTable("Select * From Trans as t left join Items I on I.id=t.ItemID left join Vouchers V on V.id=t.VoucherID  Where VoucherID=" & Val(txtID.Text) & "")
        If dt.Rows.Count = 0 Then Exit Sub
        If dt.Rows.Count > 0 Then

            TempRowColumn()
            For i = 0 To dt.Rows.Count - 1
                Tempdt.Rows.Add()
                With Tempdt
                    '.Rows(i)(0) = dt.Rows(i)("ID").ToString()
                    .Rows(i)(0) = Format(dt.Rows(i)("EntryDate"), "dd-MM-yyyy")
                    .Rows(i)(1) = dt.Rows(i)("TransType").ToString() : .Rows(i)(2) = dt.Rows(i)("InvoiceNo").ToString()
                    .Rows(i)(3) = dt.Rows(i)("AccountName").ToString() : .Rows(i)(4) = dt.Rows(i)("ItemName").ToString()
                    .Rows(i)(5) = dt.Rows(i)("Sno").ToString() : .Rows(i)(6) = dt.Rows(i)("Qty").ToString()
                    .Rows(i)(7) = Format(Val(dt.Rows(i)("Rate").ToString()), "0.00") : .Rows(i)(8) = dt.Rows(i)("RatePer").ToString()
                    .Rows(i)(9) = Format(Val(dt.Rows(i)("BasicAmt").ToString()), "0.00") : .Rows(i)(10) = Format(Val(dt.Rows(i)("DisPer").ToString()), "0.00")
                    .Rows(i)(11) = Format(Val(dt.Rows(i)("DisAmt").ToString()), "0.00") : .Rows(i)(12) = Format(Val(dt.Rows(i)("TaxPer").ToString()), "0.00")
                    .Rows(i)(13) = Format(Val(dt.Rows(i)("TaxAmt").ToString()), "0.00") : .Rows(i)(14) = Format(Val(dt.Rows(i)("SGSTPer").ToString()), "0.00")
                    .Rows(i)(15) = Format(Val(dt.Rows(i)("SGSTAmt").ToString()), "0.00") : .Rows(i)(16) = Format(Val(dt.Rows(i)("CgstPer").ToString()), "0.00")
                    .Rows(i)(17) = Format(Val(dt.Rows(i)("CgstAmt").ToString()), "0.00") : .Rows(i)(18) = Format(Val(dt.Rows(i)("IGSTPer").ToString()), "0.00")
                    .Rows(i)(19) = Format(Val(dt.Rows(i)("igstAmt").ToString()), "0.00") : .Rows(i)(20) = Format(Val(dt.Rows(i)("igstAmt").ToString()), "0.00")
                    .Rows(i)(21) = Format(Val(dt.Rows(i)("TotalBasicAmt").ToString()), "0.00") : .Rows(i)(22) = Format(Val(dt.Rows(i)("TotalTaxAmt").ToString()), "0.00")
                    If dt.Rows(i)("ISIGST").ToString() = "N" Then
                        .Rows(i)(23) = Format(Val(dt.Rows(i)("TotalSGSTAmt").ToString()), "0.00") : .Rows(i)(24) = Format(Val(dt.Rows(i)("TotalCGSTAmt").ToString()), "0.00")
                        .Rows(i)(25) = "" 'Format(Val(dt.Rows(i)("TotalIGSTAmt").ToString()), "0.00")
                    Else
                        .Rows(i)(23) = "" : .Rows(i)(24) = ""
                        .Rows(i)(25) = Format(Val(dt.Rows(i)("TotalIGSTAmt").ToString()), "0.00")
                    End If
                    .Rows(i)(26) = Format(Val(dt.Rows(i)("TotalDiscPer").ToString()), "0.00")
                    .Rows(i)(27) = Format(Val(dt.Rows(i)("TotalDiscAmt").ToString()), "0.00") : .Rows(i)(28) = Format(Val(dt.Rows(i)("totPackingPer").ToString()), "0.00")
                    .Rows(i)(29) = Format(Val(dt.Rows(i)("totPackingAmt").ToString()), "0.00") : .Rows(i)(30) = Format(Val(dt.Rows(i)("TotServicePer").ToString()), "0.00")
                    .Rows(i)(31) = Format(Val(dt.Rows(i)("TotServiceAmt").ToString()), "0.00")
                    .Rows(i)(32) = Format(Val(dt.Rows(i)("TotalGrandAmt").ToString()), "0.00")
                    .Rows(i)(33) = IIf(Val(dt.Rows(i)("TotalCashAmt").ToString()) = 0, "", Format(Val(dt.Rows(i)("TotalCashAmt").ToString()), "0.00"))
                    .Rows(i)(34) = IIf(Val(dt.Rows(i)("TotalBalAmt").ToString()) = 0, "", Format(Val(dt.Rows(i)("TotalBalAmt").ToString()), "0.00"))
                    .Rows(i)(35) = dt.Rows(i)("HSNCode").ToString()
                    .Rows(i)(36) = dt.Rows(i)("ItemCode").ToString() : .Rows(i)(37) = dt.Rows(i)("RatePer").ToString()
                    .Rows(i)(38) = dt.Rows(i)("CustomerName").ToString() : .Rows(i)(39) = dt.Rows(i)("CustomerMobile").ToString()
                    .Rows(i)(40) = dt.Rows(i)("CustomerGSTN").ToString() : .Rows(i)(41) = dt.Rows(i)("Remark").ToString()
                End With

            Next
        End If
        dt.Clear()
        ' PrintRecord()
    End Sub
    Private Sub PrintRecord()
        Dim count As Integer = 0
        Dim cmd As New SQLite.SQLiteCommand
        Dim sql As String = ""
        ClsFunPrimary.ExecNonQuery("Delete from printing")
        ' clsFun.ExecNonQuery(sql)
        For Each row As DataRow In Tempdt.Rows
            ' If row(0).ToString <> "" Then
            sql = sql & "insert into Printing(D1,M1,M2,M3,M4,P1,P2,P3,P4,P5,P6,P7,P8,P9,P10,P11,P12,P13,P14,P15,P16,P17,P18,P19,P20,P21,P22,P23,P24,P25,P26,P27,P28,P29,P30,P31,P32,P33,P34,P35,P36,P37)" & _
                "  values('" & row(0).ToString() & "','" & row(1).ToString() & "','" & row(2).ToString() & "','" & row(3).ToString() & "','" & row(4).ToString() & "', " & _
                "'" & row(5).ToString() & "','" & row(6).ToString() & "','" & row(7).ToString() & "','" & row(8).ToString() & "','" & row(9).ToString() & "'," & _
                "'" & row(10).ToString() & "','" & row(11).ToString() & "','" & row(12).ToString() & "','" & row(13).ToString() & "','" & row(14).ToString() & "'," & _
                "'" & row(15).ToString() & "','" & row(16).ToString() & "','" & row(17).ToString() & "','" & row(18).ToString() & "','" & row(19).ToString() & "'," & _
                "'" & row(20).ToString() & "','" & row(21).ToString() & "','" & row(22).ToString() & "','" & row(23).ToString() & "','" & row(24).ToString() & "'," & _
                "'" & row(25).ToString() & "','" & row(26).ToString() & "','" & row(27).ToString() & "','" & row(28).ToString() & "','" & row(29).ToString() & "'," & _
                "'" & row(30).ToString() & "','" & row(31).ToString() & "','" & row(32).ToString() & "','" & row(33).ToString() & "','" & row(34).ToString() & "'," & _
                "'" & row(35).ToString() & "','" & row(36).ToString() & "'," & _
                "'" & row(37).ToString() & "','" & row(38).ToString() & "','" & row(39).ToString() & "','" & row(40).ToString() & "','" & row(41).ToString() & "');"
            'End If

        Next
        Try
            cmd = New SQLite.SQLiteCommand(sql, ClsFunPrimary.GetConnection())
            ClsFunPrimary.ExecNonQuery(sql)
            'If cmd.ExecuteNonQuery() > 0 Then

            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
            clsFun.CloseConnection()
        End Try
        ' clsFun.ExecNonQuery(sql)
    End Sub
    Private Sub txtItemSearch_KeyUp(sender As Object, e As KeyEventArgs) Handles txtItemSearch.KeyUp
        If clsFun.ExecScalarStr("Select ItemCode from Item_View Where upper(Barcode)  Like upper('" & txtItemSearch.Text.Trim() & "%') or upper(ItemCode)  Like upper('" & txtItemSearch.Text.Trim() & "%')") = txtItemSearch.Text Then
            Dim str As String = txtItemSearch.Text
            dt = clsFun.ExecDataTable("Select * FROM Item_View Where Barcode='" & str & "' or ItemCode='" & str & "'")
            Try
                If dt.Rows.Count > 0 Then
                    If CkIGST.Checked = True Then
                        dg1.Rows.Add(dt.Rows(i)("id").ToString(), dg1.RowCount + 1, dt.Rows(i)("ItemName").ToString(), Format(Val(1), "0.00"),
                                    Format(Val(dt.Rows(i)("PosRate").ToString()), "0.00"), Format(Val(1) * Val(dt.Rows(i)("PosRate").ToString()), "0.00"),
                                     Format(Val(dt.Rows(i)("IGSTPer").ToString()), "0.00"), Format(Val(dt.Rows(i)("IGSTPer").ToString()) * Val(dt.Rows(i)("PosRate").ToString()) / 100, "0.00"),
                                     "0.00", "0.00", "0.00", "0.00")
                    Else
                        dg1.Rows.Add(dt.Rows(i)("id").ToString(), dg1.RowCount + 1, dt.Rows(i)("ItemName").ToString(), Format(Val(1), "0.00"),
                                    Format(Val(dt.Rows(i)("PosRate").ToString()), "0.00"), Format(Val(1) * Val(dt.Rows(i)("PosRate").ToString()), "0.00"),
                                    "", "",
                                     Format(Val(dt.Rows(i)("SGSTPer").ToString()), "0.00"), Format(Val(dt.Rows(i)("SGSTPer").ToString()) * Val(dt.Rows(i)("PosRate").ToString()) / 100, "0.00"),
                                     Format(Val(dt.Rows(i)("CGSTPer").ToString()), "0.00"), Format(Val(dt.Rows(i)("CGSTPer").ToString()) * Val(dt.Rows(i)("PosRate").ToString()) / 100, "0.00"))
                    End If
                    dg1.ClearSelection() : calc() : txtItemSearch.Clear()
                End If
                dt.Dispose()
            Catch ex As Exception
                MsgBox(ex.Message, vbOKOnly + vbInformation, "Atithi")
            End Try

        End If
    End Sub

    Private Sub dtp1_GotFocus(sender As Object, e As EventArgs) Handles dtp1.GotFocus
        mskEntryDate.Focus()
    End Sub

    Private Sub dtp1_ValueChanged(sender As Object, e As EventArgs) Handles dtp1.ValueChanged
        mskEntryDate.Text = dtp1.Value.ToString("dd-MM-yyyy")
        mskEntryDate.Text = clsFun.convdate(mskEntryDate.Text)
    End Sub
End Class