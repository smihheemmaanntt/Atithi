Public Class Items
    Dim sql As String = String.Empty

    Private Sub Items_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub
    Private Sub Items_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0 : Me.Left = 0
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True : BtnDelete.Visible = False
        VNumber()
        clsFun.FillDropDownList(cbItemGroup, "Select ID,GroupName From ItemGroup order by ID,GroupName", "GroupName", "Id", "")
        clsFun.FillDropDownList(cbItemCompany, "Select ID,CompanyName From ItemCompany order by ID,CompanyName", "CompanyName", "Id", "")
        clsFun.FillDropDownList(cbTax, "Select ID,TaxName From Taxation order by ID,TaxName ", "TaxName", "Id", "")
        clsFun.FillDropDownList(cbMainUnit, "Select ID,MainUNit From ItemUnits Order by ID,MainUNit", "MainUNit", "Id", "")
        rowColums()
    End Sub
    Private Sub VNumber()
        Vno = clsFun.ExecScalarInt("SELECT Count(ID) AS NumberOfProducts FROM Items")
        txtItemCode.Text = Vno + 1
    End Sub

    Private Sub txtName_GotFocus(sender As Object, e As EventArgs) Handles txtName.GotFocus, txtName.Click
        txtName.SelectAll()
    End Sub

    Private Sub txtName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtName.KeyDown, txtHSnCode.KeyDown,
      txtItemCode.KeyDown, cbMainUnit.KeyDown, cbTax.KeyDown, txtDisPer.KeyDown, cbItemCompany.KeyDown, cbItemGroup.KeyDown, txtPosRate.KeyDown, txtPurchase.KeyDown,
     txtTableRate.KeyDown, txtTakeAwayRate.KeyDown, txtRoomRate.KeyDown, txtBarRate.KeyDown, txtOpStcok.KeyDown, txtLooseStock.KeyDown, txtBarcode.KeyDown, CkStock.KeyDown
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
    Private Sub cbItemGroup_KeyDown(sender As Object, e As KeyEventArgs) Handles cbItemGroup.KeyDown
        If e.KeyCode = Keys.F3 Then
            Group_items.MdiParent = MainScreenForm
            Group_items.Show()
                Group_items.BringToFront()
            End If
        If e.KeyCode = Keys.F1 Then
            Group_items.MdiParent = MainScreenForm
            Group_items.Show()
            Group_items.FillControls(cbItemGroup.SelectedValue)
            If Not Group_items Is Nothing Then
                Group_items.BringToFront()
            End If
        End If
    End Sub

    Private Sub cbItemCompany_KeyDown(sender As Object, e As KeyEventArgs) Handles cbItemCompany.KeyDown
        If e.KeyCode = Keys.F3 Then
            Item_Company.MdiParent = MainScreenForm
            Item_Company.Show()
            If Not Item_Company Is Nothing Then
                Item_Company.BringToFront()
            End If
        End If
        If e.KeyCode = Keys.F1 Then
            Item_Company.MdiParent = MainScreenForm
            Item_Company.Show()
            Item_Company.FillControls(cbItemCompany.SelectedValue)
            If Not Item_Company Is Nothing Then
                Item_Company.BringToFront()
            End If
        End If
    End Sub
    Private Sub cbTax_KeyDown(sender As Object, e As KeyEventArgs) Handles cbTax.KeyDown
        If e.KeyCode = Keys.F3 Then
            Taxation.MdiParent = MainScreenForm
            Taxation.Show()
            If Not Taxation Is Nothing Then
                Taxation.BringToFront()
            End If
        End If
        If e.KeyCode = Keys.F1 Then
            Taxation.MdiParent = MainScreenForm
            Taxation.Show()
            Taxation.FillControls(cbTax.SelectedValue)
            If Not Taxation Is Nothing Then
                Taxation.BringToFront()
            End If
        End If
    End Sub
    Private Sub cbMainUnit_KeyDown(sender As Object, e As KeyEventArgs) Handles cbMainUnit.KeyDown
        If e.KeyCode = Keys.F3 Then
            Unit_items.MdiParent = MainScreenForm
            Unit_items.Show()
            If Not Unit_items Is Nothing Then
                Unit_items.BringToFront()
            End If
        End If
        If e.KeyCode = Keys.F1 Then
            Unit_items.MdiParent = MainScreenForm
            Unit_items.Show()
            Unit_items.FillControls(cbMainUnit.SelectedValue)
            If Not Unit_items Is Nothing Then
                Unit_items.BringToFront()
            End If
        End If
    End Sub
    Private Sub save()
        Dim cmd As SQLite.SQLiteCommand
        sql = String.Empty
        Dim count As Integer = 0
        If txtName.Text.Trim = "" Then
            txtName.Focus()
            MsgBox("Item Name is Emply...Please Fill item Name... ", MsgBoxStyle.Exclamation, "Empty Item")
            Exit Sub
        End If
        sql = "insert into Items (ItemName,HSNCode,ItemCode,TaxID,CompanyID,GroupID," _
                            & "RateID,RatePer,MaintainStock,RawItem,PurchaseRate,TableRate,RoomRate,POSRate,BarRate,TakeAwayRate,OpStock,LooseStock,DisPer,Barcode) " _
                            & "values (@1, @2,@3,@4,@5,@6,@7,@8,@9, @10,@11,@12,@13,@14,@15,@16,@17,@18,@19,@20)"
        Try
            cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
            cmd.Parameters.AddWithValue("@1", txtName.Text.Trim.Trim)
            cmd.Parameters.AddWithValue("@2", txtHSnCode.Text.Trim)
            cmd.Parameters.AddWithValue("@3", txtItemCode.Text.Trim)
            cmd.Parameters.AddWithValue("@4", Val(cbTax.SelectedValue))
            cmd.Parameters.AddWithValue("@5", Val(cbItemCompany.SelectedValue))
            cmd.Parameters.AddWithValue("@6", Val(cbItemGroup.SelectedValue))
            cmd.Parameters.AddWithValue("@7", Val(cbMainUnit.SelectedValue))
            cmd.Parameters.AddWithValue("@8", cbMainUnit.Text.Trim)
            cmd.Parameters.AddWithValue("@9", IIf(CkStock.Checked = True, "Y", "N"))
            cmd.Parameters.AddWithValue("@10", IIf(ckRaw.Checked = True, "Y", "N"))
            cmd.Parameters.AddWithValue("@11", Val(txtPurchase.Text.Trim))
            cmd.Parameters.AddWithValue("@12", Val(txtTableRate.Text.Trim))
            cmd.Parameters.AddWithValue("@13", Val(txtRoomRate.Text.Trim))
            cmd.Parameters.AddWithValue("@14", Val(txtPosRate.Text.Trim))
            cmd.Parameters.AddWithValue("@15", txtBarRate.Text.Trim)
            cmd.Parameters.AddWithValue("@16", Val(txtTakeAwayRate.Text.Trim))
            cmd.Parameters.AddWithValue("@17", Val(txtOpStcok.Text.Trim))
            cmd.Parameters.AddWithValue("@18", Val(txtLooseStock.Text.Trim))
            cmd.Parameters.AddWithValue("@19", Val(txtDisPer.Text.Trim))
            cmd.Parameters.AddWithValue("@20", txtBarcode.Text.Trim)
            If cmd.ExecuteNonQuery() > 0 Then
                MsgBox("Record Insert SuccesFully", MsgBoxStyle.Information, "Saved")
                txtclearall()
            End If
            clsFun.CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message)
            clsFun.CloseConnection()
        End Try
    End Sub
    Private Sub txtclearall()
        txtName.Clear() : txtHSnCode.Clear()
        txtItemCode.Clear() : txtTableRate.Clear()
        txtTakeAwayRate.Clear() : txtRoomRate.Clear()
        txtBarRate.Clear() : txtDisPer.Clear()
        txtOpStcok.Clear() : txtLooseStock.Clear()
        txtBarcode.Clear() : BtnDelete.Visible = False
        BtnSave.Text = "&Save" : txtName.Focus()
        lblName.Text = "ITEM ENTRY"
        txtid.Clear() : VNumber()
        retrive() : dg1.ClearSelection()
        txtPosRate.Clear() : txtPurchase.Clear()
    End Sub
    Private Sub rowColums()
        dg1.ColumnCount = 11
        dg1.Columns(0).Name = "ID" : dg1.Columns(0).Visible = False
        dg1.Columns(1).Name = "Code" : dg1.Columns(1).Width = 50
        dg1.Columns(2).Name = "Item Name" : dg1.Columns(2).Width = 270
        dg1.Columns(3).Name = "Unit" : dg1.Columns(3).Width = 150
        dg1.Columns(4).Name = "Tax %" : dg1.Columns(4).Width = 80
        dg1.Columns(5).Name = "Table" : dg1.Columns(5).Width = 80
        dg1.Columns(6).Name = "Room" : dg1.Columns(6).Width = 80
        dg1.Columns(7).Name = "POS" : dg1.Columns(7).Width = 80
        dg1.Columns(8).Name = "Bar" : dg1.Columns(8).Width = 80
        dg1.Columns(9).Name = "Away" : dg1.Columns(9).Width = 80
        dg1.Columns(10).Name = "Stock" : dg1.Columns(10).Width = 150
        retrive()
    End Sub
    Private Sub retrive(Optional ByVal condtion As String = "")
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("Select * from Item_View " & condtion & " Order By ItemName")
        Try
            If dt.Rows.Count > 0 Then
                dg1.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("id").ToString()
                        .Cells(1).Value = dt.Rows(i)("ItemCode").ToString()
                        .Cells(2).Value = dt.Rows(i)("ItemName").ToString()
                        .Cells(3).Value = dt.Rows(i)("RatePer").ToString()
                        .Cells(4).Value = dt.Rows(i)("TaxName").ToString()
                        .Cells(5).Value = Format(Val(dt.Rows(i)("TableRate").ToString()), "0.00")
                        .Cells(6).Value = Format(Val(dt.Rows(i)("RoomRate").ToString()), "0.00")
                        .Cells(7).Value = Format(Val(dt.Rows(i)("PosRate").ToString()), "0.00")
                        .Cells(8).Value = Format(Val(dt.Rows(i)("BarRate").ToString()), "0.00")
                        .Cells(9).Value = Format(Val(dt.Rows(i)("TakeAwayRate").ToString()), "0.00")
                        .Cells(10).Value = dt.Rows(i)("OPStock").ToString() & " : " & dt.Rows(i)("LooseStock").ToString()
                    End With
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "AADHAT")
        End Try
        dg1.ClearSelection() : lblTotal.Visible = True : lblTotal.Text = "Items : " & Val(dg1.RowCount)
    End Sub

    Public Sub FillControls(ByVal id As Integer)
        Dim RawItem As String = String.Empty
        Dim ItemStock As String = String.Empty
        clsFun.FillDropDownList(cbItemGroup, "Select ID,GroupName From ItemGroup order by GroupName", "GroupName", "Id", "")
        clsFun.FillDropDownList(cbItemCompany, "Select ID,CompanyName From ItemCompany order by CompanyName", "CompanyName", "Id", "")
        clsFun.FillDropDownList(cbTax, "Select ID,TaxName From Taxation order by TaxName ", "TaxName", "Id", "")
        clsFun.FillDropDownList(cbMainUnit, "Select ID,MainUNit From ItemUnits Order by MainUNit", "MainUNit", "Id", "")
        Dim sSql As String = String.Empty
        lblName.Text = "MODIFY ITEM"
        BtnSave.Visible = True
        BtnDelete.Visible = True
        BtnSave.Text = "&Update"
        '  Panel1.BackColor = Color.PaleVioletRed
        If clsFun.GetConnection.State = ConnectionState.Open Then clsFun.CloseConnection()
        sSql = "Select * from Item_View where id=" & id
        clsFun.con.Open()
        Dim ad As New SQLite.SQLiteDataAdapter(sSql, clsFun.GetConnection)
        Dim ds As New DataSet
        ad.Fill(ds, "a")
        If ds.Tables("a").Rows.Count > 0 Then
            txtid.Text = ds.Tables("a").Rows(0)("ID").ToString()
            txtName.Text = ds.Tables("a").Rows(0)("ItemName").ToString()
            txtHSnCode.Text = ds.Tables("a").Rows(0)("HSNCode").ToString()
            txtItemCode.Text = ds.Tables("a").Rows(0)("ItemCode").ToString()
            cbTax.Text = ds.Tables("a").Rows(0)("TaxName").ToString()
            cbItemCompany.Text = ds.Tables("a").Rows(0)("CompanyName").ToString()
            cbItemGroup.Text = ds.Tables("a").Rows(0)("GroupName").ToString()
            cbMainUnit.Text = ds.Tables("a").Rows(0)("RatePer").ToString()
            txtRoomRate.Text = ds.Tables("a").Rows(0)("RoomRate").ToString()
            txtTableRate.Text = ds.Tables("a").Rows(0)("TableRate").ToString()
            txtBarRate.Text = ds.Tables("a").Rows(0)("BarRate").ToString()
            txtTakeAwayRate.Text = ds.Tables("a").Rows(0)("TakeAwayRate").ToString()
            txtDisPer.Text = ds.Tables("a").Rows(0)("DisPer").ToString()
            txtBarcode.Text = ds.Tables("a").Rows(0)("barcode").ToString()
            txtPurchase.Text = ds.Tables("a").Rows(0)("PurchaseRate").ToString()
            txtPosRate.Text = ds.Tables("a").Rows(0)("POSRate").ToString()
            ItemStock = ds.Tables("a").Rows(0)("MaintainStock").ToString()
            If ItemStock = "Y" Then CkStock.Checked = True Else CkStock.Checked = False
            RawItem = ds.Tables("a").Rows(0)("RawItem").ToString()
            If RawItem = "Y" Then ckRaw.Checked = True Else ckRaw.Checked = False
            ' cbMainUnit.Text = ds.Tables("a").Rows(0)("MainUnit").ToString()
        End If
    End Sub
    Private Sub Update()
        If txtName.Text.Trim = "" Then
            MsgBox("Please fill Item Name") : txtName.Focus() : Exit Sub
        End If

        If clsFun.ExecScalarStr("Select count(*)from Items where ItemName='" & txtName.Text.Trim & "'") > 1 Then MsgBox("Item Already Exists...", vbCritical + vbOKOnly, "Access Denied") : Exit Sub
        sql = "Update Items Set ItemName='" & txtName.Text.Trim & "',HSNCode='" & txtName.Text.Trim & "',ItemCode='" & txtItemCode.Text.Trim & "',TaxID='" & Val(cbTax.SelectedValue) & "'," _
               & " CompanyID='" & Val(cbItemCompany.SelectedValue) & "',GroupID='" & (cbItemGroup.SelectedValue) & "',RateID='" & Val(cbMainUnit.Text.Trim) & "', " _
               & "RatePer='" & cbMainUnit.Text.Trim & "',MaintainStock='" & IIf(CkStock.Checked = True, "Y", "N") & "',RawItem='" & IIf(ckRaw.Checked = True, "Y", "N") & "'," _
               & "PurchaseRate='" & Val(txtPurchase.Text.Trim) & "',TableRate='" & Val(txtTableRate.Text.Trim) & "',RoomRate='" & Val(txtRoomRate.Text.Trim) & "'," _
               & "POSRate='" & Val(txtPosRate.Text.Trim) & "',BarRate='" & Val(txtBarRate.Text.Trim) & "',TakeAwayRate='" & Val(txtTableRate.Text.Trim) & "'," _
               & "OpStock='" & Val(txtOpStcok.Text.Trim) & "',LooseStock='" & Val(txtLooseStock.Text.Trim) & "',DisPer='" & Val(txtDisPer.Text.Trim) & "',Barcode='" & Val(txtBarcode.Text.Trim) & "' Where ID='" & Val(txtid.Text.Trim) & "' "
        Try
            If clsFun.ExecNonQuery(sql) > 0 Then
                MsgBox("Record Updated Successfully.", vbInformation + vbOKOnly, "Updated")
                txtclearall()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Delete()
        If clsFun.ExecScalarInt("Select count(*) from Trans where ItemID='" & Val(txtid.Text) & "'") >= 1 Then
            MsgBox("Item Already Used in Transactions", vbCritical + vbOKOnly, "Access Denied")
            Exit Sub
        End If
        'Exit Sub
        Try
            '  If clsFun.ExecScalarInt("Select tag From AccountGroup  WHERE ID=" & txtid.Text & "") = 0 Then MsgBox("access denied", MsgBoxStyle.Critical) : Exit Sub
                If MessageBox.Show("Are you Sure Want to Delete Item : '" & txtName.Text & "' ??", "DELETE", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.OK Then
                    If clsFun.ExecNonQuery("DELETE from Items WHERE ID=" & txtid.Text & "") > 0 Then
                        MsgBox("Record Deleted Successfully", vbInformation + vbOKOnly, "Deleted")
                        Item_Register.btnRefresh.PerformClick()
                        txtclearall()
                        'GroupList.BtnRefresh.PerformClick()
                        BtnDelete.Visible = False
                        BtnSave.Visible = True
                        txtName.Focus()
                    End If
                End If
                    Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If BtnSave.Text = "&Save" Then
            save()
        Else
            Update()
        End If
        Item_Register.btnRefresh.PerformClick()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        Delete()
    End Sub


    Private Sub txtName_Leave(sender As Object, e As EventArgs) Handles txtName.Leave
        If BtnSave.Text = "&Save" Then
            If clsFun.ExecScalarStr("Select count(*)from Items where upper(ItemName)='" & txtName.Text.ToUpper & "'") = 1 Then
                MsgBox("Item Already Exists...", vbCritical + vbOKOnly, "Access Denied")
                txtName.Focus()
            End If
        Else
            Exit Sub
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Item_Register.MdiParent = MainScreenForm : Item_Register.Show()
        If Item_Register Is Nothing Then Item_Register.BringToFront()
    End Sub

    Private Sub cbItemGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbItemGroup.DropDown
        clsFun.FillDropDownList(cbItemGroup, "Select ID,GroupName From ItemGroup order by GroupName", "GroupName", "Id", "")
        clsFun.FillDropDownList(cbItemCompany, "Select ID,CompanyName From ItemCompany order by CompanyName", "CompanyName", "Id", "")
        clsFun.FillDropDownList(cbTax, "Select ID,TaxName From Taxation order by TaxName ", "TaxName", "Id", "")
        clsFun.FillDropDownList(cbMainUnit, "Select ID,MainUNit From ItemUnits Order by MainUNit", "MainUNit", "Id", "")
    End Sub

    Private Sub dg1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg1.CellDoubleClick
        If dg1.SelectedRows.Count = 0 Then Exit Sub
        Dim tmpID As Integer = Val(dg1.SelectedRows(0).Cells(0).Value)
        FillControls(tmpID) : txtName.Focus()
    End Sub

    Private Sub dg1_KeyDown(sender As Object, e As KeyEventArgs) Handles dg1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dg1.SelectedRows.Count = 0 Then Exit Sub
            Dim tmpID As Integer = Val(dg1.SelectedRows(0).Cells(0).Value)
            FillControls(tmpID) : txtName.Focus()
        End If
    End Sub

    Private Sub txtTableRate_Leave(sender As Object, e As EventArgs) Handles txtTableRate.Leave
        If txtRoomRate.Text.Trim = "" Then txtRoomRate.Text = txtTableRate.Text.Trim
        If txtPosRate.Text.Trim = "" Then txtPosRate.Text = txtTableRate.Text.Trim
        If txtTakeAwayRate.Text.Trim = "" Then txtTakeAwayRate.Text = txtTableRate.Text.Trim
        If txtBarRate.Text.Trim = "" Then txtBarRate.Text = txtTableRate.Text.Trim
    End Sub

    Private Sub cbItemGroup_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cbItemGroup.SelectedIndexChanged

    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged

    End Sub

    Private Sub dg1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg1.CellContentClick

    End Sub

    Private Sub txtName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtName.KeyPress
        If Not Char.IsLetterOrDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso e.KeyChar <> " " AndAlso Not Char.IsControl(e.KeyChar) AndAlso e.KeyChar <> "(" AndAlso Not Char.IsControl(e.KeyChar) AndAlso e.KeyChar <> ")" Then
            e.Handled = True
        End If
    End Sub
End Class