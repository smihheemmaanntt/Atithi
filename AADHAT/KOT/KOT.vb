Public Class KOT
    Dim sql As String = String.Empty
    Dim vchID As Integer = 0
    Dim Tempdt As New DataTable
    Dim TotalPages As Integer = 0 : Dim PageNumber As Integer = 0
    Dim RowCount As Integer = 1 : Dim Offset As Integer = 0
    Private Sub KOT_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If dgItemSearch.Visible = True Then dgItemSearch.Visible = False : txtItem.Focus() : Exit Sub
            If dg1.RowCount = 0 Then Me.Close() : Exit Sub
            If MessageBox.Show("Are you Sure Want to Exit KOT ENTRY ???", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Close() : Exit Sub
            End If
        End If
    End Sub

    Private Sub KOT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0 : Me.Left = 0
        mskEntryDate.Text = Date.Today.ToString("dd-MM-yyyy")
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        dg1Columns() : dg2Columns()
        clsFun.FillDropDownList(CbType, "Select ID,AttenderName From Attender ", "AttenderName", "Id", "")
        cbServiceType.SelectedIndex = 0
        VNumber()
    End Sub

    Private Sub VNumber()
        Dim vno As Integer = 0
        If vno = Val(clsFun.ExecScalarInt("SELECT Max(InvoiceID) AS ID FROM KOT Where  ID= (Select mAX(ID) from KOT)")) <> 0 Then
            vno = clsFun.ExecScalarInt("SELECT Max(InvoiceID) AS ID FROM KOT Where ID= (Select mAX(ID) from KOT)")
            txtBillNo.Text = vno + 1
            txtInvoiceID.Text = vno + 1
        Else
            vno = clsFun.ExecScalarInt("SELECT Max(InvoiceID) AS ID FROM KOT Where ID= (Select mAX(ID) from KOT)")
            txtBillNo.Text = vno + 1
            txtInvoiceID.Text = vno + 1
        End If
    End Sub

    Private Sub TxtClear()
        txtItem.Clear() : txtQty.Clear()
        txtRate.Clear() : txtNet.Clear()
        txtItem.Focus()
    End Sub
    Private Sub txtClearAll()
        cbServiceType.Enabled = True
        VNumber() : TxtClear()
        dg1.Rows.Clear()
        Dg2.Rows.Clear()
        txttotQty.Clear() : txtTotNet.Clear()
        mskEntryDate.Focus()
        BtnSave.Text = "&Save"
    End Sub
    Private Sub dg2Columns()
        Dim checkBoxColumn As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        checkBoxColumn.HeaderText = "" : checkBoxColumn.Width = 30
        checkBoxColumn.Name = "Present" : Dg2.Columns.Insert(0, checkBoxColumn)
        Dg2.ColumnCount = 3
        Dg2.Columns(1).Name = "id" : Dg2.Columns(1).Visible = False
        Dg2.Columns(2).Name = "Table Name" : Dg2.Columns(2).Width = 194
        Dg2.Columns(0).ReadOnly = False
    End Sub
    Private Sub dg1Columns()
        dg1.ColumnCount = 8
        dg1.Columns(0).Name = "Itemid" : dg1.Columns(0).Visible = False
        dg1.Columns(1).Name = "SR No." : dg1.Columns(1).Width = 85
        dg1.Columns(2).Name = "Code" : dg1.Columns(2).Width = 80
        dg1.Columns(3).Name = "Item Name" : dg1.Columns(3).Width = 233
        dg1.Columns(4).Name = "Unit" : dg1.Columns(4).Width = 73
        dg1.Columns(5).Name = "Qty" : dg1.Columns(5).Width = 113
        dg1.Columns(6).Name = "Rate" : dg1.Columns(6).Width = 139
        dg1.Columns(7).Name = "Amount" : dg1.Columns(7).Width = 200
        dg1.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dg1.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dg1.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
    End Sub
    Private Sub save()
        Dim EntryDate As DateTime
        'EntryDate = mskEntryDate.ToString("yyyy-MM-dd")
      
        Dim IsIGST As String = String.Empty
        If dg1.Rows.Count = 0 Then
            Exit Sub
            MsgBox("There is no record to Save.", vbCritical + vbOKOnly, "Empty Record")
        End If
        dg1.ClearSelection()
        Dim cmd As SQLite.SQLiteCommand
        sql = "INSERT INTO KOT (KOTNo,EntryDate,AttenderID,AttenderName,ServiceName,TotalQty,TotalAmount,InvoiceID)Values(@1, @2, @3, @4, @5, @6, @7,@8)"
        Try
            cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
            cmd.Parameters.AddWithValue("@1", txtBillNo.Text)
            cmd.Parameters.AddWithValue("@2", CDate(mskEntryDate.Text).ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@3", Val(CbType.SelectedValue))
            cmd.Parameters.AddWithValue("@4", CbType.Text)
            cmd.Parameters.AddWithValue("@5", cbServiceType.Text)
            cmd.Parameters.AddWithValue("@6", Val(txttotQty.Text))
            cmd.Parameters.AddWithValue("@7", Val(txtTotNet.Text))
            cmd.Parameters.AddWithValue("@8", Val(txtInvoiceID.Text))
            If cmd.ExecuteNonQuery() > 0 Then
            End If
            clsFun.CloseConnection()
            txtID.Text = clsFun.ExecScalarInt("Select Max(ID) from KOT")
            dg1Record()
            ' Ledger()
            MsgBox("Record Saved Successfully.", vbInformation + vbOKOnly, "Saved") 'Insert SuccesFully", "SuccessFully", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtClearAll()
        Catch ex As Exception
            MsgBox(ex.Message)
            clsFun.CloseConnection()
        End Try
    End Sub
    Private Sub dg1Record()
        sql = String.Empty
        Dim TableNo As String = String.Empty
        Dim TableName As String = String.Empty
        Dim checkBox As DataGridViewCheckBoxCell
        For Each row As DataGridViewRow In Dg2.Rows
            checkBox = (TryCast(row.Cells("Present"), DataGridViewCheckBoxCell))
            If checkBox.Value = True Then
                TableNo = TableNo & row.Cells(1).Value & ","
                TableName = TableName & row.Cells(2).Value & ","
            End If
        Next
        If TableNo = "" Then
        Else
            TableNo = TableNo.Remove(TableNo.LastIndexOf(","))
            TableName = TableName.Remove(TableName.LastIndexOf(","))
            If cbServiceType.SelectedIndex <> 2 Then
                clsFun.ExecScalarStr("Update RestroTables Set IsBooked='Y' Where ID in(" & TableNo & ")")
            End If
        End If
        Dim FastQuery As String = String.Empty
        For Each row As DataGridViewRow In dg1.Rows
            With row
                If .Cells("ItemID").Value <> "" Then
                    FastQuery = FastQuery & IIf(FastQuery <> "", " UNION ALL SELECT ", " SELECT ") & "'" & Val(txtID.Text) & "'," & _
                         "'" & Val(.Cells(0).Value) & "','" & .Cells(1).Value & "'," & _
                         "'" & Val(.Cells(2).Value) & "','" & .Cells(3).Value & "','" & .Cells(4).Value & "', " & _
                         "'" & Val(.Cells(5).Value) & "','" & Val(.Cells(6).Value) & "','" & Val(.Cells(7).Value) & "','" & IIf(cbServiceType.SelectedIndex = 2, "", TableNo) & "', " & _
                         "'" & IIf(cbServiceType.SelectedIndex = 2, "", TableName) & "','" & IIf(cbServiceType.SelectedIndex = 2, "", "Y") & "', " & _
                         "'" & IIf(cbServiceType.SelectedIndex = 2, TableNo, "") & "','" & IIf(cbServiceType.SelectedIndex = 2, TableName, "") & "','" & IIf(cbServiceType.SelectedIndex = 2, "Y", "") & "'"
                End If
            End With
        Next
        If FastQuery = "" Then Exit Sub
        sql = "INSERT INTO KOTTrans (KOTID,ItemID,SrNo,ItemCode,ItemName,Unit,Qty,Rate,Amount,TableID,TableNos,IsOccupied,RoomVoucherID,RoomNos,RoomOccupied) " & FastQuery & ""
        Try
            clsFun.ExecNonQuery(sql)
        Catch ex As Exception
            MsgBox(ex.Message)
            clsFun.CloseConnection()
        End Try
        clsFun.CloseConnection()
    End Sub
    Private Sub Update()

        sql = String.Empty
        SqliteEntryDate = CDate(mskEntryDate.Text).ToString("yyyy-MM-dd")
        Dim count As Integer = 0
        dg1.ClearSelection()
        Dim cmd As SQLite.SQLiteCommand
        sql = "Update KOT Set KOTNo='" & txtBillNo.Text & "',EntryDate='" & SqliteEntryDate & "',AttenderID=" & Val(CbType.SelectedValue) & "," _
            & "AttenderName='" & CbType.Text & "',ServiceName='" & cbServiceType.Text & "',TotalQty=" & Val(txttotQty.Text) & "," _
            & "TotalAmount=" & Val(txtTotNet.Text) & ",InvoiceID=" & Val(txtInvoiceID.Text) & " Where ID=" & Val(txtID.Text) & ""
        Try
            If clsFun.ExecNonQuery(sql) > 0 Then
                clsFun.CloseConnection()
            End If
            If clsFun.ExecNonQuery("DELETE from KOtTrans WHERE KOTID=" & Val(txtID.Text) & "") > 0 Then
            End If
            dg1Record()
            BtnSave.Text = "&Save"
            BtnDelete.Enabled = False
            MsgBox("Record Updated Successfully.", vbInformation + vbOKOnly, "Update")
            clsFun.CloseConnection()
            txtClearAll()
        Catch ex As Exception
            MsgBox(ex.Message)
            clsFun.CloseConnection()
        End Try
    End Sub
    Public Sub FillControls(ByVal id As Integer)
        Dim sSql As String = String.Empty
        Dim IsIGST As String = String.Empty
        BtnSave.Text = "&Update"
        cbServiceType.Enabled = False
        '  Panel1.BackColor = Color.PaleVioletRed
        If clsFun.GetConnection.State = ConnectionState.Open Then clsFun.CloseConnection()
        sSql = "Select * from KOT where id=" & id
        clsFun.con.Open()
        Dim ad As New SQLite.SQLiteDataAdapter(sSql, clsFun.GetConnection)
        Dim ds As New DataSet
        ad.Fill(ds, "a")
        If ds.Tables("a").Rows.Count > 0 Then
            txtid.Text = ds.Tables("a").Rows(0)("ID").ToString()
            mskEntryDate.Text = Format(ds.Tables("a").Rows(0)("EntryDate"), "dd-MM-yyyy")
            txtBillNo.Text = ds.Tables("a").Rows(0)("KOTNo").ToString()
            CbType.Text = ds.Tables("a").Rows(0)("AttenderName").ToString()
            cbServiceType.Text = ds.Tables("a").Rows(0)("ServiceName").ToString()
            txttotQty.Text = ds.Tables("a").Rows(0)("TotalQty").ToString()
            txtTotNet.Text = ds.Tables("a").Rows(0)("TotalAmount").ToString()
            txtInvoiceID.Text = Val(ds.Tables("a").Rows(0)("InvoiceID").ToString())
        End If
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("SELECT * FROM KOT AS K LEFT JOIN KOTTrans KT ON KT.KOTID = K.ID where id=" & id)
        Dim dvData As DataView = New DataView(dt)
        Try
            If dt.Rows.Count > 0 Then
                dg1.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("ItemID").ToString()
                        .Cells(1).Value = dt.Rows(i)("SrNo").ToString()
                        .Cells(2).Value = dt.Rows(i)("ItemCode").ToString()
                        .Cells(3).Value = dt.Rows(i)("ItemName").ToString()
                        .Cells(4).Value = dt.Rows(i)("Unit").ToString()
                        .Cells(5).Value = Val(dt.Rows(i)("Qty").ToString())
                        .Cells(6).Value = Format(Val(dt.Rows(i)("Rate").ToString()), "0.00")
                        .Cells(7).Value = Format(Val(dt.Rows(i)("Amount").ToString()), "0.00")
                    End With
                Next

                Dim Tbls As String = String.Empty
                Tbls = IIf(cbServiceType.SelectedIndex = 2, dt.Rows(0)("RoomNos").ToString(), dt.Rows(0)("TableNos").ToString())
                Dim tblid As String = IIf(cbServiceType.SelectedIndex = 2, dt.Rows(0)("RoomVoucherID").ToString(), dt.Rows(0)("TableId").ToString())
                Dim tmpdt As New DataTable
                tmpdt.Columns.Add("tableid")
                tmpdt.Columns.Add("Tablename")
                For k As Integer = 0 To Tbls.Split(",").Length - 1
                    tmpdt.Rows.Add()
                    tmpdt.Rows(k)("tableid") = tblid.Split(",")(k)
                    tmpdt.Rows(k)("Tablename") = Tbls.Split(",")(k)
                Next
                ''  dg2Columns()
                '   retriveTables()
                If tmpdt.Rows.Count > 0 Then
                    Dg2.Rows.Clear()
                    For i = 0 To tmpdt.Rows.Count - 1
                        Dg2.Rows.Add()
                        With Dg2.Rows(i)
                            .Cells(1).Value = tmpdt.Rows(i)("tableid").ToString()
                            .cells(0).value = True
                            .Cells(2).Value = tmpdt.Rows(i)("tableName").ToString()
                        End With
                    Next
                End If
                tmpdt.Dispose()
            End If
        Catch ex As Exception
            MsgBox("a")
        End Try
        cbServiceType.Enabled = False
        calc() : dg1.ClearSelection() : Dg2.ClearSelection() : Dg2.Enabled = False
    End Sub


    Public Sub FillWithNevigation()
        Dim sSql As String = String.Empty
        Dim IsIGST As String = String.Empty
        BtnSave.Text = "&Update"
        cbServiceType.Enabled = False
        '  Panel1.BackColor = Color.PaleVioletRed
        If clsFun.GetConnection.State = ConnectionState.Open Then clsFun.CloseConnection()
        Dim recordsCount As Integer = clsFun.ExecScalarInt("Select Count(*) FROM KOT  Order By ID ")
        TotalPages = Math.Ceiling(recordsCount / RowCount)
        ' sSql = "Select * from KOT where id=" & id
        sSql = "Select * from  KOT  Order By ID LIMIT " + RowCount.ToString() + " OFFSET " + Offset.ToString() + ""
        clsFun.con.Open()
        Dim ad As New SQLite.SQLiteDataAdapter(sSql, clsFun.GetConnection)
        Dim ds As New DataSet
        ad.Fill(ds, "a")
        If ds.Tables("a").Rows.Count > 0 Then
            txtID.Text = ds.Tables("a").Rows(0)("ID").ToString()
            mskEntryDate.Text = Format(ds.Tables("a").Rows(0)("EntryDate"), "dd-MM-yyyy")
            txtBillNo.Text = ds.Tables("a").Rows(0)("KOTNo").ToString()
            CbType.Text = ds.Tables("a").Rows(0)("AttenderName").ToString()
            cbServiceType.Text = ds.Tables("a").Rows(0)("ServiceName").ToString()
            txttotQty.Text = ds.Tables("a").Rows(0)("TotalQty").ToString()
            txtTotNet.Text = ds.Tables("a").Rows(0)("TotalAmount").ToString()
            txtInvoiceID.Text = Val(ds.Tables("a").Rows(0)("InvoiceID").ToString())
            id = Val(txtID.Text)
        End If
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("SELECT * FROM KOT AS K LEFT JOIN KOTTrans KT ON KT.KOTID = K.ID where id=" & Val(id))
        Dim dvData As DataView = New DataView(dt)
        Try
            If dt.Rows.Count > 0 Then
                dg1.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("ItemID").ToString()
                        .Cells(1).Value = dt.Rows(i)("SrNo").ToString()
                        .Cells(2).Value = dt.Rows(i)("ItemCode").ToString()
                        .Cells(3).Value = dt.Rows(i)("ItemName").ToString()
                        .Cells(4).Value = dt.Rows(i)("Unit").ToString()
                        .Cells(5).Value = Val(dt.Rows(i)("Qty").ToString())
                        .Cells(6).Value = Format(Val(dt.Rows(i)("Rate").ToString()), "0.00")
                        .Cells(7).Value = Format(Val(dt.Rows(i)("Amount").ToString()), "0.00")
                    End With
                Next

                Dim Tbls As String = String.Empty
                Tbls = IIf(cbServiceType.SelectedIndex = 2, dt.Rows(0)("RoomNos").ToString(), dt.Rows(0)("TableNos").ToString())
                Dim tblid As String = IIf(cbServiceType.SelectedIndex = 2, dt.Rows(0)("RoomVoucherID").ToString(), dt.Rows(0)("TableId").ToString())
                Dim tmpdt As New DataTable
                tmpdt.Columns.Add("tableid")
                tmpdt.Columns.Add("Tablename")
                For k As Integer = 0 To Tbls.Split(",").Length - 1
                    tmpdt.Rows.Add()
                    tmpdt.Rows(k)("tableid") = tblid.Split(",")(k)
                    tmpdt.Rows(k)("Tablename") = Tbls.Split(",")(k)
                Next
                ''  dg2Columns()
                '   retriveTables()
                If tmpdt.Rows.Count > 0 Then
                    Dg2.Rows.Clear()
                    For i = 0 To tmpdt.Rows.Count - 1
                        Dg2.Rows.Add()
                        With Dg2.Rows(i)
                            .Cells(1).Value = tmpdt.Rows(i)("tableid").ToString()
                            .cells(0).value = True
                            .Cells(2).Value = tmpdt.Rows(i)("tableName").ToString()
                        End With
                    Next
                End If
                tmpdt.Dispose()
            End If
        Catch ex As Exception
            MsgBox("a")
        End Try
        cbServiceType.Enabled = False
        calc() : dg1.ClearSelection() : Dg2.ClearSelection() : Dg2.Enabled = False
    End Sub

    Private Sub txtItem_GotFocus(sender As Object, e As EventArgs) Handles txtItem.GotFocus
        ItemRowColumns()
        If txtItem.Text.Trim() <> "" Then
            retriveItems(" Where upper(ItemName) Like upper('" & txtItem.Text.Trim() & "%')")
        Else
            retriveItems()
        End If
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Delete()
    End Sub
    Private Sub Delete()
        If clsFun.ExecScalarStr("Select Count(*) From KOTTrans Where KOTID=" & Val(txtID.Text) & " and Paid isNull") = 0 Then MsgBox("Can't Delete KOT, Food Bill Done...", vbCritical + vbOKOnly, "Can't Delete") : Exit Sub

        If MessageBox.Show("Are You Sure Want to Delete K.O.T. Voucher ?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
            If clsFun.ExecNonQuery("DELETE from KOT WHERE ID=" & Val(txtID.Text) & "") > 0 Then
            End If
            If clsFun.ExecNonQuery("DELETE from KOTTrans WHERE KOTID=" & Val(txtID.Text) & "") > 0 Then
            End If
            Dim TableNo As String = String.Empty
            Dim TableName As String = String.Empty
            Dim checkBox As DataGridViewCheckBoxCell
            For Each row As DataGridViewRow In Dg2.Rows
                checkBox = (TryCast(row.Cells("Present"), DataGridViewCheckBoxCell))
                If checkBox.Value = True Then
                    TableNo = TableNo & row.Cells(1).Value & ","
                    TableName = TableName & row.Cells(2).Value & ","
                End If
            Next
            If TableNo = "" Then
            Else
                TableNo = TableNo.Remove(TableNo.LastIndexOf(","))
                TableName = TableName.Remove(TableName.LastIndexOf(","))
                If cbServiceType.SelectedIndex <> 2 Then
                    clsFun.ExecScalarStr("Update RestroTables Set IsBooked='N' Where ID in(" & TableNo & ")")
                Else
                    clsFun.ExecScalarStr("Update RestroTables Set IsBooked='N' Where ID in(" & TableNo & ")")
                End If

            End If
            MsgBox("Record Deleted Successfully", vbInformation + vbOKOnly, "Deleted")
            txtClearAll()
        End If
    End Sub
    Private Sub txtItem_KeyUp(sender As Object, e As KeyEventArgs) Handles txtItem.KeyUp
        ItemRowColumns()
        If txtItem.Text.Trim() <> "" Then
            dgItemSearch.Visible = True
            retriveItems(" Where upper(ItemName) Like upper('%" & txtItem.Text.Trim() & "%') or upper(ItemCode)  Like upper('" & txtItem.Text.Trim() & "%') ")
        End If
        If e.KeyCode = Keys.Escape Then dgItemSearch.Visible = False
    End Sub
    Private Sub ItemRowColumns()
        dgItemSearch.ColumnCount = 4
        dgItemSearch.Columns(0).Name = "ID" : dgItemSearch.Columns(0).Visible = False
        dgItemSearch.Columns(1).Name = "Item Code" : dgItemSearch.Columns(1).Width = 70
        dgItemSearch.Columns(2).Name = "Item Name" : dgItemSearch.Columns(2).Width = 250
        dgItemSearch.Columns(3).Name = "Unit" : dgItemSearch.Columns(3).Width = 150
        retriveItems()
    End Sub
    Private Sub retriveItems(Optional ByVal condtion As String = "")
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("Select ID,ItemCode,ItemName,TableRate,RatePer from Item_View " & condtion & " order by ItemCode,ItemName Limit 20")
        Try
            If dt.Rows.Count > 0 Then
                dgItemSearch.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dgItemSearch.Rows.Add()
                    With dgItemSearch.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("id").ToString()
                        .Cells(1).Value = dt.Rows(i)("ItemCode").ToString()
                        .Cells(2).Value = dt.Rows(i)("ItemName").ToString()
                        .Cells(3).Value = dt.Rows(i)("RatePer").ToString()
                    End With
                Next
            End If
            dt.Dispose()

        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "Teller")
        End Try
    End Sub
    Private Sub TempRowColumn()
        Tempdt.Columns.Clear()
        With Tempdt
            .Columns.AddRange(New DataColumn(14) {
                              New DataColumn("ID"),
                              New DataColumn("EntyDate"),
                           New DataColumn("KOTNo"),
                                New DataColumn("AttenderName"),
                              New DataColumn("ServiceName"),
                              New DataColumn("TotalQty"),
                           New DataColumn("TotalAmount"),
                        New DataColumn("ItemCode"),
                          New DataColumn("ItemName"),
                         New DataColumn("SrNo"),
                              New DataColumn("Unit"),
                              New DataColumn("Qty"),
                           New DataColumn("Rate"),
                        New DataColumn("Amount"),
                                New DataColumn("TableNos")})
        End With
    End Sub

    Sub FillData()
        Tempdt.Rows.Clear()
        Dim i, j As Integer
        Dim dt As New DataTable
        Dim cnt As Integer = -1
        dt = clsFun.ExecDataTable("SELECT * FROM KOT AS K LEFT JOIN KOTTrans KT ON KT.KOTID = K.ID where id=" & Val(txtID.Text))
        '   dt = clsFun.ExecDataTable("SELECT * FROM KOT AS K LEFT JOIN KOTTrans KT ON KT.KOTID = K.ID where id=" & val(id)")
        If dt.Rows.Count = 0 Then Exit Sub
        If dt.Rows.Count > 0 Then

            TempRowColumn()
            For i = 0 To dt.Rows.Count - 1
                Tempdt.Rows.Add()
                With Tempdt
                    '.Rows(i)(0) = dt.Rows(i)("ID").ToString()
                    .Rows(i)(0) = Format(dt.Rows(i)("EntryDate"), "dd-MM-yyyy")
                    .Rows(i)(1) = dt.Rows(i)("KOTNo").ToString() : .Rows(i)(2) = dt.Rows(i)("AttenderName").ToString()
                    .Rows(i)(3) = dt.Rows(i)("ServiceName").ToString() : .Rows(i)(4) = Format(Val(dt.Rows(i)("TotalQty").ToString()), "0.00")
                    .Rows(i)(5) = Format(Val(dt.Rows(i)("TotalAmount").ToString()), "0.00") : .Rows(i)(6) = dt.Rows(i)("ItemCode").ToString()
                    .Rows(i)(7) = dt.Rows(i)("ItemName").ToString() : .Rows(i)(8) = dt.Rows(i)("SrNo").ToString()
                    .Rows(i)(9) = dt.Rows(i)("Unit").ToString() : .Rows(i)(10) = Format(Val(dt.Rows(i)("Qty").ToString()), "0.00")
                    .Rows(i)(11) = Format(Val(dt.Rows(i)("Rate").ToString()), "0.00") : .Rows(i)(12) = Format(Val(dt.Rows(i)("Amount").ToString()), "0.00")
                    : .Rows(i)(13) = dt.Rows(i)("TableNos").ToString()
                End With
            Next
        End If
        dt.Clear()
    End Sub
    'Private Sub dg2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dg2.CellClick
    '    If e.RowIndex >= 0 AndAlso e.ColumnIndex = 0 Then ' Check if checkbox column is clicked and not the header row
    '        Dim checkboxCell As DataGridViewCheckBoxCell = dg2.Rows(e.RowIndex).Cells(0) ' Get the checkbox cell
    '        checkboxCell.Value = Not checkboxCell.Value ' Toggle the checkbox value
    '        dg2.EndEdit() ' Commit the edit
    '    End If
    'End Sub
    Private Sub calculation()
        txtNet.Text = Format(Val(Val(txtQty.Text) * Val(txtRate.Text)), "0.00")
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub cbServiceType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbServiceType.Leave
        If cbServiceType.SelectedIndex = 0 Then
            retriveTables() : Dg2.Focus()
        ElseIf cbServiceType.SelectedIndex = 1 Then
            retriveTables() : Dg2.Focus()
        ElseIf cbServiceType.SelectedIndex = 2 Then
            RetriveRooms() : Dg2.Focus()
        End If

    End Sub
    Private Sub retriveTables(Optional ByVal condtion As String = "")
        Dg2.Rows.Clear() : lblServiceName.Text = "Choose Table"
        Dg2.Columns(2).Name = "Table Name"
        Dim dt As New DataTable
        If cbServiceType.SelectedIndex = 0 Then
            dt = clsFun.ExecDataTable("Select * from RestroTables Where ISBooked ='N'")
        ElseIf cbServiceType.SelectedIndex = 1 Then
            dt = clsFun.ExecDataTable("Select * from RestroTables Where ISBooked = 'Y'")
        End If

        Try
            If dt.Rows.Count > 0 Then
                Dg2.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    Dg2.Rows.Add()
                    With Dg2.Rows(i)
                        .Cells(2).readonly = True
                        .Cells(1).Value = dt.Rows(i)("id").ToString()
                        .Cells(2).Value = dt.Rows(i)("tableName").ToString()
                    End With
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "AADHAT")
        End Try
    End Sub
    Private Sub RetriveRooms(Optional ByVal condtion As String = "")
        Dg2.Rows.Clear() : lblServiceName.Text = "Choose Room"
        Dg2.Columns(2).Name = "Room No"
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("Select ID,RoomNos,CustomerName from Vouchers Where TransType='Check In' And IsBooked is Null")
        Try
            If dt.Rows.Count > 0 Then
                Dg2.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    Dg2.Rows.Add()
                    With Dg2.Rows(i)
                        .Cells(2).readonly = True
                        .Cells(1).Value = dt.Rows(i)("id").ToString()
                        .Cells(2).Value = dt.Rows(i)("RoomNos").ToString() & " - " & dt.Rows(i)("CustomerName").ToString()
                    End With
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "Aadhat")
        End Try
    End Sub

    Private Sub txtQty_GotFocus(sender As Object, e As EventArgs) Handles txtQty.GotFocus
        If dgItemSearch.ColumnCount = 0 Then ItemRowColumns()
        If dgItemSearch.Rows.Count = 0 Then retriveItems()
        'If txtItem.Text.Trim() <> "" Then
        '    retriveItems(" Where upper(ItemName) Like upper('" & txtItem.Text.Trim() & "%')")
        'Else
        '    retriveItems()
        'End If
        If dgItemSearch.SelectedRows.Count = 0 Then dgItemSearch.Visible = True : txtItem.Focus() : Exit Sub
        txtItemID.Text = Val(dgItemSearch.SelectedRows(0).Cells(0).Value)
        lblCode.Text = dgItemSearch.SelectedRows(0).Cells(1).Value
        txtItem.Text = dgItemSearch.SelectedRows(0).Cells(2).Value
        dgItemSearch.Visible = False : pickPrice()
    End Sub

    Private Sub pickPrice()
        Dim price As String
        If cbServiceType.SelectedIndex = 0 Then
            txtRate.Text = Val(clsFun.ExecScalarInt(" SELECT TableRate FROM Item_View WHERE ID ='" & Val(txtItemID.Text) & "'"))
        ElseIf cbServiceType.SelectedIndex = 1 Then
            txtRate.Text = Val(clsFun.ExecScalarInt(" SELECT TableRate  FROM Item_View WHERE ID ='" & Val(txtItemID.Text) & "'"))
        ElseIf cbServiceType.SelectedIndex = 2 Then
            txtRate.Text = Val(clsFun.ExecScalarInt(" SELECT RoomRate FROM Item_View WHERE ID ='" & Val(txtItemID.Text) & "'"))
        ElseIf cbServiceType.SelectedIndex = 3 Then
            txtRate.Text = Val(clsFun.ExecScalarInt(" SELECT TakeAwayRate FROM Item_View WHERE ID ='" & Val(txtItemID.Text) & "'"))
        ElseIf cbServiceType.SelectedIndex = 5 Then
            txtRate.Text = Val(clsFun.ExecScalarInt(" SELECT Barrate FROM Item_View WHERE ID ='" & Val(txtItemID.Text) & "'"))
        End If
    End Sub
    Private Sub dgItemSearch_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgItemSearch.CellClick
        txtItem.Clear() : txtItemID.Clear()
        txtItemID.Text = dgItemSearch.SelectedRows(0).Cells(0).Value
        lblCode.Text = dgItemSearch.SelectedRows(0).Cells(1).Value
        txtItem.Text = dgItemSearch.SelectedRows(0).Cells(2).Value
        lblUnit.Text = dgItemSearch.SelectedRows(0).Cells(3).Value
        dgItemSearch.Visible = False : txtQty.Focus()
    End Sub
    Private Sub dgItemSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles dgItemSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtItem.Clear() : txtItem.Clear()
            txtItemID.Text = dgItemSearch.SelectedRows(0).Cells(0).Value
            lblCode.Text = dgItemSearch.SelectedRows(0).Cells(1).Value
            txtItem.Text = dgItemSearch.SelectedRows(0).Cells(2).Value
            lblUnit.Text = dgItemSearch.SelectedRows(0).Cells(3).Value
            dgItemSearch.Visible = False : e.SuppressKeyPress = True
            txtQty.Focus()
        End If
        If e.KeyCode = Keys.Back Then
            txtItem.Focus()
        End If
        If e.KeyCode = Keys.F1 Then
            If dgItemSearch.SelectedRows.Count = 0 Then Exit Sub
            Dim itemid As String = dgItemSearch.SelectedRows(0).Cells(0).Value
            Items.MdiParent = MainScreenForm
            Items.Show()
            Items.FillControls(itemid)
            If Not Items Is Nothing Then
                Items.BringToFront()
            End If
        End If
        If e.KeyCode = Keys.F3 Then
                Items.MdiParent = MainScreenForm
                Items.Show()
                If Not Items Is Nothing Then
                    Items.BringToFront()
                End If
        End If
    End Sub

    Private Sub txtNet_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNet.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(txtQty.Text) = 0 Then MsgBox("Please Fill Qty,", vbCritical.Critical, "Check Qty") : txtQty.Focus() : Exit Sub
            If dg1.SelectedRows.Count = 1 Then
                dg1.SelectedRows(0).Cells(0).Value = txtItemID.Text
                dg1.SelectedRows(0).Cells(2).Value = lblCode.Text
                dg1.SelectedRows(0).Cells(3).Value = txtItem.Text
                dg1.SelectedRows(0).Cells(4).Value = lblUnit.Text
                dg1.SelectedRows(0).Cells(5).Value = Format(Val(txtQty.Text), "0.00")
                dg1.SelectedRows(0).Cells(6).Value = Format(Val(txtRate.Text), "0.00")
                dg1.SelectedRows(0).Cells(7).Value = Format(Val(txtNet.Text), "0.00")
            Else
                dg1.Rows.Add(txtItemID.Text, dg1.RowCount + 1, lblCode.Text, txtItem.Text, lblUnit.Text, Format(Val(txtQty.Text), "0.00"), Format(Val(txtRate.Text), "0.00"), Format(Val(txtNet.Text), "0.00"))
            End If
            e.SuppressKeyPress = True
            dg1.ClearSelection() : calc() : TxtClear()
        End If

    End Sub
    Sub calc()
        txtTotNet.Text = Format(0, "0.00") : txttotQty.Text = 0
        For i = 0 To dg1.Rows.Count - 1
            txttotQty.Text = Val(txttotQty.Text) + Val(dg1.Rows(i).Cells(5).Value)
            txtTotNet.Text = Format(Val(txtTotNet.Text) + Val(dg1.Rows(i).Cells(7).Value), "0.00")
        Next
        '   calculation()
    End Sub

    Private Sub txtQty_TextChanged(sender As Object, e As EventArgs) Handles txtQty.TextChanged, txtRate.TextChanged, txtNet.TextChanged
        calculation()
    End Sub
    Private Sub txtNet_Leave(sender As Object, e As EventArgs) Handles txtNet.Leave, txtQty.Leave, txtRate.Leave
        txtQty.Text = Val(txtQty.Text) : txtRate.Text = Format(Val(txtRate.Text), "0.00") : txtNet.Text = Format(Val(txtNet.Text), "0.00")
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

    Private Sub dg1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg1.CellClick
        If dg1.SelectedRows.Count = 0 Then Exit Sub
        txtItemID.Text = Val(dg1.SelectedRows(0).Cells(0).Value)
        lblCode.Text = dg1.SelectedRows(0).Cells(2).Value
        txtItem.Text = dg1.SelectedRows(0).Cells(3).Value
        lblUnit.Text = dg1.SelectedRows(0).Cells(4).Value
        txtQty.Text = dg1.SelectedRows(0).Cells(5).Value
        txtRate.Text = dg1.SelectedRows(0).Cells(6).Value
        txtNet.Text = dg1.SelectedRows(0).Cells(7).Value
    End Sub

    Private Sub txtInvoiceID_Leave(sender As Object, e As EventArgs) Handles txtInvoiceID.Leave
        pnlInvoiceID.Visible = False : txtBillNo.Focus()
    End Sub

    Private Sub txtInvoiceID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtInvoiceID.KeyDown
        If e.KeyCode = Keys.Enter Then pnlInvoiceID.Visible = False : CbType.Focus()
    End Sub

    Private Sub txtBillNo_GotFocus(sender As Object, e As EventArgs) Handles txtBillNo.GotFocus, txtItem.GotFocus, txtQty.GotFocus, txtRate.GotFocus, txtNet.GotFocus
        If txtItem.Focused Then dgItemSearch.Visible = True
        Dim tb As TextBox = CType(sender, TextBox)
        tb.BackColor = Color.Orange
        tb.SelectAll()
    End Sub

    Private Sub txtBillNo_LostFocus(sender As Object, e As EventArgs) Handles txtBillNo.LostFocus, txtItem.LostFocus, txtQty.LostFocus, txtRate.LostFocus, txtNet.LostFocus
        Dim tb As TextBox = CType(sender, TextBox)
        tb.BackColor = Color.GhostWhite
    End Sub
    Private Sub mskEntryDate_GotFocus(sender As Object, e As EventArgs) Handles mskEntryDate.GotFocus, mskEntryDate.Click
        mskEntryDate.SelectAll()
    End Sub

    Private Sub mskEntryDate_KeyDown(sender As Object, e As KeyEventArgs) Handles mskEntryDate.KeyDown, txtBillNo.KeyDown,
     CbType.KeyDown, cbServiceType.KeyDown, txtItem.KeyDown, txtQty.KeyDown, txtRate.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
            e.SuppressKeyPress = True
        End If
        If txtBillNo.Focused Then
            If e.KeyCode = Keys.F2 Then
                pnlInvoiceID.Visible = True
                txtInvoiceID.Focus()
                e.SuppressKeyPress = True
            End If
        End If
        If txtItem.Focused Then
            If e.KeyCode = Keys.F3 Then
                Items.MdiParent = MainScreenForm
                Items.Show()
                Items.BringToFront()
            End If
        End If
     
        If txtItem.Focused Or txtQty.Focused Or txtRate.Focused Or txtNet.Focused Then
            If e.KeyCode = Keys.Down Then
                If dgItemSearch.Visible = True Then dgItemSearch.Focus() : Exit Sub
                dg1.Rows(0).Selected = True : dg1.Focus()
            End If
        End If
        If dg1.SelectedRows.Count <> 0 Then
            If e.KeyCode = Keys.Delete Then
                If dg1.SelectedRows.Count = 0 Then Exit Sub
                If MessageBox.Show("Are You Sure Want to Delete Selected Item ?", "Delete Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    dg1.Rows.Remove(dg1.SelectedRows(0))
                    DgvAutoSerialNumbering() : dg1.ClearSelection() : calc()
                End If
            End If
        End If
        Select Case e.KeyCode
            Case Keys.End
                e.Handled = True
                BtnSave.Focus()
        End Select
        Select Case e.KeyCode
            Case Keys.PageUp
                e.Handled = True
                txtItem.Focus()
        End Select
        If txtItem.Focused Then
            If e.KeyCode = Keys.Down Then
                dgItemSearch.Focus()
            End If
        End If

        If CbType.Focused Then
            If CbType.Text = "" Then
                clsFun.FillDropDownList(CbType, "Select ID,AttenderName From Attender ", "AttenderName", "Id", "")
            Else
                If e.KeyCode = Keys.Down Then
                    clsFun.FillDropDownList(CbType, "Select ID,AttenderName From Attender ", "AttenderName", "Id", "")
                End If
            End If
            If e.KeyCode = Keys.F3 Then
                Attender.MdiParent = MainScreenForm
                Attender.Show()
                If Not Attender Is Nothing Then
                    Attender.BringToFront()
                End If
            End If
            If e.KeyCode = Keys.F1 Then
                Dim tmpid As Integer = (CbType.SelectedValue)
                If tmpid = 0 Then Exit Sub
                Attender.MdiParent = MainScreenForm
                Attender.FillControls(tmpid)
                Attender.Show()
                If Not Attender Is Nothing Then
                    Attender.BringToFront()
                End If
            End If
        End If
    End Sub

    Private Sub Dg2_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dg2.CellDoubleClick
        Dg2.Rows(0).Cells(1).ReadOnly = True : Dg2.Rows(0).Cells(2).ReadOnly = True
    End Sub

    Private Sub Dg2_KeyDown(sender As Object, e As KeyEventArgs) Handles Dg2.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If cbServiceType.SelectedIndex <> 3 Then
                ' Dim checkBoxCell As DataGridViewCheckBoxCell = CType(Dg2.Rows(0).Cells("Present"), DataGridViewCheckBoxCell)
                Dim isChecked As Boolean = Dg2.Rows.Cast(Of DataGridViewRow)().Any(Function(row) Convert.ToBoolean(row.Cells("Present").Value))

                'Dim isChecked As Boolean = CBool(checkBoxCell.Value)
                If isChecked = False Then MsgBox("Please Select Table / Room No. to Make KOT", vbCritical.Critical, "Access Denied") : Dg2.Focus() : Exit Sub
            End If
            Dg2.ClearSelection() : txtItem.Focus()
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If dg1.Rows.Count = 0 Then MsgBox("There is No Items to Save", vbCritical.Critical, "Add Some Items") : txtItem.Focus() : Exit Sub
        If cbServiceType.SelectedIndex <> 3 Then
            Dim isChecked As Boolean = Dg2.Rows.Cast(Of DataGridViewRow)().Any(Function(row) Convert.ToBoolean(row.Cells("Present").Value))
            If isChecked = False Then MsgBox("Please Select Table / Room No. to Make KOT", vbCritical.Critical, "Access Denied") : cbServiceType.Focus() : Exit Sub
        End If
        If BtnSave.Text = "&Save" Then
            save()
        Else
            If clsFun.ExecScalarStr("Select Count(*) From KOTTrans Where KOTID=" & Val(txtID.Text) & " and Paid isNull") = 0 Then MsgBox("Can't Modify KOT, Food Bill Done...", vbCritical + vbOKOnly, "Can't Modify") : txtClearAll() : Exit Sub
            Update()
        End If
        MainScreenPicture.lblTbleTotal.Text = Val(clsFun.ExecScalarStr("Select Count(*) FROM KOT Where EntryDate='" & CDate(Date.Now).ToString("yyyy-MM-dd") & "'"))
        MainScreenPicture.RestroTables()
        If clsFun.ExecScalarStr("Select KOTDoNotPrint From Options") = "Y" Then Exit Sub
        If clsFun.ExecScalarStr("Select KOTAskForPrint From Options") = "Y" Then
            Dim res = MessageBox.Show("Do you want to Print KOT...", "Print KOT", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If res = Windows.Forms.DialogResult.Yes Then
                sendToPrint()
            Else
                Exit Sub
            End If
        Else
            sendToPrint()
        End If
    End Sub
    Private Sub sendToPrint()
        FillData()
        clsFun.CloseConnection()
        If clsFun.ExecScalarStr("Select KotPreview From Options") = "Y" Then
            PrintRecord()
            Report_Viewer.printReport("\KOT.rpt")
            Report_Viewer.MdiParent = MainScreenForm
            Report_Viewer.Show()
            If Not Report_Viewer Is Nothing Then
                Report_Viewer.BringToFront()
            End If
        Else
            PrintRecord()
            Report_Viewer.printReportDirect("\KOT.rpt")
        
        End If
    End Sub
    Private Sub PrintRecord()
        Dim sql As String = String.Empty
        Dim count As Integer = 0
        Dim cmd As New SQLite.SQLiteCommand
        ClsFunPrimary.ExecNonQuery("Delete from printing")
        ' clsFun.ExecNonQuery(sql)
        For Each row As DataRow In Tempdt.Rows
            ' If row(0).ToString <> "" Then
            sql = sql & "insert into Printing(D1,M1,M2,M3,M4,M6,P1,P2,P3,P4,P5,P6,P7,P8)" & _
                "  values('" & row(0).ToString() & "','" & row(1).ToString() & "','" & row(2).ToString() & "','" & row(3).ToString() & "','" & row(4).ToString() & "', " & _
                "'" & row(5).ToString() & "','" & row(6).ToString() & "','" & row(7).ToString() & "','" & row(8).ToString() & "','" & row(9).ToString() & "'," & _
                "'" & row(10).ToString() & "','" & row(11).ToString() & "','" & row(12).ToString() & "','" & row(13).ToString() & "');"
            'End If

        Next
        Try
            cmd = New SQLite.SQLiteCommand(sql, ClsFunPrimary.GetConnection())
            ClsFunPrimary.ExecNonQuery(sql)
            'If cmd.ExecuteNonQuery() > 0 Then

            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
            ClsFunPrimary.CloseConnection()
        End Try
        ' clsFun.ExecNonQuery(sql)
    End Sub
    Private Sub cbServiceType_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cbServiceType.SelectedIndexChanged

    End Sub

   
    Private Sub Dg2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Dg2.MouseDoubleClick
        Dg2.Rows(0).Cells(1).ReadOnly = True : Dg2.Rows(0).Cells(2).ReadOnly = True
    End Sub

    Private Sub CbType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbType.SelectedIndexChanged

    End Sub

    Private Sub btnCreateTable_Click(sender As Object, e As EventArgs) Handles btnCreateTable.Click
        If cbServiceType.SelectedIndex = 0 Then
            RestroTables.MdiParent = MainScreenForm
            RestroTables.Show()
            If Not RestroTables Is Nothing Then
                RestroTables.BringToFront()
            End If
            retriveTables()
        ElseIf cbServiceType.SelectedIndex = 2 Then
            Rooms.MdiParent = MainScreenForm
            Rooms.Show()
            If Not Rooms Is Nothing Then
                Rooms.BringToFront()
            End If
            RetriveRooms()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        retriveTables()
    End Sub

    Private Sub dg1_DoubleClick(sender As Object, e As EventArgs) Handles dg1.DoubleClick
        If dg1.SelectedRows.Count = 0 Then Exit Sub
        txtItemID.Text = dg1.SelectedRows(0).Cells(0).Value
        lblCode.Text = dg1.SelectedRows(0).Cells(2).Value
        txtItem.Text = dg1.SelectedRows(0).Cells(3).Value
        lblUnit.Text = dg1.SelectedRows(0).Cells(4).Value
        txtQty.Text = dg1.SelectedRows(0).Cells(5).Value
        txtRate.Text = dg1.SelectedRows(0).Cells(6).Value
        txtNet.Text = dg1.SelectedRows(0).Cells(7).Value
        txtItem.Focus()
    End Sub

    Private Sub dg1_KeyDown(sender As Object, e As KeyEventArgs) Handles dg1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dg1.SelectedRows.Count = 0 Then Exit Sub
            txtItemID.Text = dg1.SelectedRows(0).Cells(0).Value
            lblCode.Text = dg1.SelectedRows(0).Cells(2).Value
            txtItem.Text = dg1.SelectedRows(0).Cells(3).Value
            lblUnit.Text = dg1.SelectedRows(0).Cells(4).Value
            txtQty.Text = dg1.SelectedRows(0).Cells(5).Value
            txtRate.Text = dg1.SelectedRows(0).Cells(6).Value
            txtNet.Text = dg1.SelectedRows(0).Cells(7).Value
            txtItem.Focus() : e.SuppressKeyPress = True
        End If
        If e.KeyCode = Keys.Up Then
            If dg1.SelectedRows.Count = 0 Then Exit Sub
            If Val(dg1.SelectedRows(0).Index) = 0 Then txtItem.Focus()
            dg1.ClearSelection()
        End If
        If e.KeyCode = Keys.Down Then
            If dg1.SelectedRows.Count = 0 Then Exit Sub
            If Val(dg1.SelectedRows(0).Index) = Val(dg1.Rows.Count - 1) Then dg1.Rows(0).Selected = True
        End If

    End Sub

    Private Sub dtp1_ValueChanged(sender As Object, e As EventArgs) Handles Dtp1.ValueChanged
        mskEntryDate.Text = Dtp1.Value.ToString("dd-MM-yyyy")
        mskEntryDate.Text = clsFun.convdate(mskEntryDate.Text)
    End Sub

    Private Sub txtQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQty.KeyPress, txtRate.KeyPress, txtNet.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8 Or ((e.KeyChar = ".") And (sender.Text.IndexOf(".") = -1)))
    End Sub

    Private Sub txtItem_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtItem.KeyPress
        If Not Char.IsLetterOrDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso e.KeyChar <> "%" AndAlso Not Char.IsControl(e.KeyChar) AndAlso e.KeyChar <> " " Then
            e.Handled = True
        End If
    End Sub

    Private Sub mskEntryDate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mskEntryDate.Validating
        mskEntryDate.Text = clsFun.convdate(mskEntryDate.Text)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        txtClearAll()
    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        Offset = 0
        FillWithNevigation()
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        If Offset = 0 Then
            Offset = clsFun.ExecScalarInt("Select Count(*) FROM Vouchers WHERE transtype = 'Food Bill'  Order By ID ")
        End If
        Offset -= RowCount
        If Offset <= 0 Then
            Offset = 0
        End If
        FillWithNevigation()
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Dim currentPage As Integer = (Offset / RowCount) + 1
        If currentPage <> TotalPages Then
            Offset += RowCount
        Else
            Offset = 0
        End If

        FillWithNevigation()
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        Dim recordsCount As Integer = clsFun.ExecScalarInt("Select Count(*) FROM KOT  Order By ID ")
        TotalPages = Math.Ceiling(recordsCount / RowCount)
        Offset = (TotalPages - 1) * RowCount
        FillWithNevigation()
    End Sub

    Private Sub txtID_TextChanged(sender As Object, e As EventArgs) Handles txtID.TextChanged

    End Sub

    Private Sub txtItem_TextChanged(sender As Object, e As EventArgs) Handles txtItem.TextChanged

    End Sub

    Private Sub Dg2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dg2.CellContentClick
        Dg2.Rows(0).Cells(1).ReadOnly = True : Dg2.Rows(0).Cells(2).ReadOnly = True
        If Dg2.SelectedRows.Count = 0 Then Exit Sub
        If Dg2.SelectedRows(0).Cells(0).Value = False Then
            Dg2.SelectedRows(0).Cells(0).Value = True
        Else
            Dg2.SelectedRows(0).Cells(0).Value = False
        End If
    End Sub

    Private Sub Dg2_GotFocus(sender As Object, e As EventArgs) Handles Dg2.GotFocus
        If Dg2.SelectedRows.Count = 0 Then Exit Sub
        Dg2.CurrentCell = Dg2.SelectedRows(0).Cells(0)
    End Sub

    Private Sub Dg2_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Dg2.CellFormatting
        If e.RowIndex >= 0 AndAlso Dg2.Rows(e.RowIndex).Cells(0).Value = True Then
            e.CellStyle.BackColor = Color.Orange 'set the background color of the cell to LightGreen
        End If
    End Sub
End Class