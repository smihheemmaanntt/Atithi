Public Class Receipe_Master

    Private Sub Receipe_Master_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If dgMainItem.Visible = True Then dgMainItem.Visible = False : txtMainItem.Focus() : Exit Sub
            If DgRawItem.Visible = True Then DgRawItem.Visible = False : txtRawItem.Focus() : Exit Sub
            Me.Close()
        End If

    End Sub

    Private Sub Receipe_Master_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0 : Me.Left = 0
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True : Dg1Columns()
    End Sub
    Private Sub Dg1Columns()
        dg1.ColumnCount = 4
        dg1.Columns(0).Name = "RawItemID" : dg1.Columns(0).Visible = False
        dg1.Columns(1).Name = "Item Name" : dg1.Columns(1).Width = 442
        dg1.Columns(2).Name = "Unit Name" : dg1.Columns(2).Width = 203
        dg1.Columns(3).Name = "Qty" : dg1.Columns(3).Width = 151

    End Sub
    Private Sub ItemRowColumns()
        dgMainItem.ColumnCount = 4
        dgMainItem.Columns(0).Name = "ID" : dgMainItem.Columns(0).Visible = False
        dgMainItem.Columns(1).Name = "Item Code" : dgMainItem.Columns(1).Width = 50
        dgMainItem.Columns(2).Name = "Item Name" : dgMainItem.Columns(2).Width = 300
        dgMainItem.Columns(3).Name = "Unit" : dgMainItem.Columns(3).Width = 100
        retriveMainItems()
    End Sub

    Private Sub retriveMainItems(Optional ByVal condtion As String = "")
        dgMainItem.Rows.Clear()
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("Select ID,ItemCode,ItemName,TableRate,RatePer from Item_View " & condtion & " order by ItemCode,ItemName liMIT 20")
        Try
            If dt.Rows.Count > 0 Then
                dgMainItem.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dgMainItem.Rows.Add()
                    With dgMainItem.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("ID").ToString()
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

    Private Sub txtMainItem_GotFocus(sender As Object, e As EventArgs) Handles txtMainItem.GotFocus
        If dgMainItem.ColumnCount = 0 Then ItemRowColumns()
        If txtMainItem.Text.Trim() <> "" Then
            retriveMainItems(" Where upper(ItemName) Like upper('" & txtMainItem.Text.Trim() & "%')")
        Else
            retriveMainItems()
        End If
    End Sub

    Private Sub txtMainQty_GotFocus(sender As Object, e As EventArgs) Handles txtMainQty.GotFocus
        If dgMainItem.ColumnCount = 0 Then ItemRowColumns()
        If txtMainItem.Text.Trim() <> "" Then
            retriveMainItems(" Where upper(ItemName) Like upper('" & txtMainItem.Text.Trim() & "%')")
        Else
            If dgMainItem.Rows.Count = 0 Then retriveMainItems()
        End If
        If dgMainItem.SelectedRows.Count = 0 Then dgMainItem.Visible = True : txtMainItem.Focus() : Exit Sub
        txtMainItemID.Text = Val(dgMainItem.SelectedRows(0).Cells(0).Value)
        txtMainItem.Text = dgMainItem.SelectedRows(0).Cells(2).Value
        lblUnit.Text = dgMainItem.SelectedRows(0).Cells(3).Value
        dgMainItem.Visible = False
    End Sub

    Private Sub txtRawItems_GotFocus(sender As Object, e As EventArgs) Handles txtRawItem.GotFocus
        If DgRawItem.ColumnCount = 0 Then RawItemRowColumns()
        If txtRawItem.Text.Trim() <> "" Then
            retriveRawItems(" Where upper(ItemName) Like upper('" & txtRawItem.Text.Trim() & "%')")
        Else
            retriveRawItems()
        End If
    End Sub

    Private Sub txtRawQty_GotFocus(sender As Object, e As EventArgs) Handles txtRawQty.GotFocus
        If DgRawItem.ColumnCount = 0 Then RawItemRowColumns()
        If DgRawItem.Rows.Count = 0 Then retriveRawItems()
        If DgRawItem.SelectedRows.Count = 0 Then DgRawItem.Visible = True : txtRawQty.Focus() : Exit Sub
        txtRawItemID.Text = Val(DgRawItem.SelectedRows(0).Cells(0).Value)
        txtRawItem.Text = DgRawItem.SelectedRows(0).Cells(2).Value
        txtRawUnit.Text = DgRawItem.SelectedRows(0).Cells(3).Value
        DgRawItem.Visible = False
    End Sub
    Private Sub txtReceipeName_GotFocus(sender As Object, e As EventArgs) Handles txtReceipeName.GotFocus, txtMainItem.GotFocus,
    txtMainQty.GotFocus, txtRawItem.GotFocus, txtRawUnit.GotFocus, txtRawQty.GotFocus
        If dgMainItem.Focused Then dgMainItem.Visible = True
        If DgRawItem.Focused Then DgRawItem.Visible = True
        Dim tb As TextBox = CType(sender, TextBox)
        tb.SelectAll()
    End Sub

    Private Sub txtReceipeName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReceipeName.KeyDown, txtMainItem.KeyDown,
        txtMainQty.KeyDown, txtRawItem.KeyDown, txtRawUnit.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
            e.SuppressKeyPress = True
        End If
        If txtRawItem.Focused Or txtRawUnit.Focused Or txtRawQty.Focused Then
            If e.KeyCode = Keys.Down Then
                If DgRawItem.Visible = True Then DgRawItem.Focus() : Exit Sub
                If dg1.Rows.Count = 0 Then Exit Sub
                dg1.Rows(0).Selected = True : dg1.Focus()
            End If
        End If
        If txtMainItem.Focused Then
            If e.KeyCode = Keys.F3 Then
                Items.MdiParent = MainScreenForm
                Items.Show()
                Items.BringToFront()
            End If
            If e.KeyCode = Keys.F1 Then
                Items.MdiParent = MainScreenForm
                Items.Show()
                Items.FillControls(Val(txtMainItemID.Text))
                Items.BringToFront()
            End If
            If e.KeyCode = Keys.Down Then
                dgMainItem.Focus()
            End If
        End If
        If txtRawItem.Focused Then
            If e.KeyCode = Keys.F3 Then
                Items.MdiParent = MainScreenForm
                Items.Show()
                Items.BringToFront()
            End If
            If e.KeyCode = Keys.F1 Then
                Items.MdiParent = MainScreenForm
                Items.Show()
                Items.FillControls(Val(txtRawItemID.Text))
                Items.BringToFront()
            End If
            If e.KeyCode = Keys.Down Then
                DgRawItem.Focus()
            End If
        End If
        If e.KeyCode = Keys.Delete Then
            If dg1.SelectedRows.Count = 0 Then Exit Sub
            If MessageBox.Show("Are You Sure Want to Delete Selected Item ?", "Delete Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                dg1.Rows.Remove(dg1.SelectedRows(0))
                txtRawItem.Focus() : dg1.ClearSelection() : Calc()
            End If
        End If
    End Sub
    Private Sub txtMainItem_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMainItem.KeyPress
        If Not Char.IsLetterOrDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso e.KeyChar <> "%" AndAlso Not Char.IsControl(e.KeyChar) AndAlso e.KeyChar <> " " Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtMainItem_KeyUp(sender As Object, e As KeyEventArgs) Handles txtMainItem.KeyUp
        If dgMainItem.ColumnCount = 0 Then ItemRowColumns()
        If txtMainItem.Text.Trim() <> "" Then
            dgMainItem.Visible = True : dgMainItem.BringToFront()
            retriveMainItems(" Where upper(ItemName) Like upper('%" & txtMainItem.Text.Trim() & "%') or upper(ItemCode)  Like upper('" & txtMainItem.Text.Trim() & "%') ")
        Else
            retriveMainItems()
        End If
        If e.KeyCode = Keys.Escape Then dgMainItem.Visible = False
    End Sub

    Private Sub dgMainItem_KeyDown(sender As Object, e As KeyEventArgs) Handles dgMainItem.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgMainItem.SelectedRows.Count = 0 Then Exit Sub
            txtMainItem.Clear() : txtMainItemID.Clear()
            txtMainItemID.Text = Val(dgMainItem.SelectedRows(0).Cells(0).Value)
            ' lblCode.Text = dgMainItem.SelectedRows(0).Cells(1).Value
            txtMainItem.Text = dgMainItem.SelectedRows(0).Cells(2).Value
            lblUnit.Text = dgMainItem.SelectedRows(0).Cells(3).Value
            dgMainItem.Visible = False : txtMainQty.Focus()
            e.SuppressKeyPress = True
        End If
        If e.KeyCode = Keys.F3 Then
            Items.MdiParent = MainScreenForm
            Items.Show()
            Items.BringToFront()
        End If
        If e.KeyCode = Keys.F1 Then
            Items.MdiParent = MainScreenForm
            Items.Show()
            Items.FillControls(Val(dgMainItem.SelectedRows(0).Cells(0).Value))
            Items.BringToFront()
        End If
    End Sub

    Private Sub dgMainItem_MouseClick(sender As Object, e As MouseEventArgs) Handles dgMainItem.MouseClick
        If dgMainItem.SelectedRows.Count = 0 Then Exit Sub
        txtMainItem.Clear() : txtMainItemID.Clear()
        txtMainItemID.Text = Val(dgMainItem.SelectedRows(0).Cells(0).Value)
        ' lblCode.Text = dgMainItem.SelectedRows(0).Cells(1).Value
        txtMainItem.Text = dgMainItem.SelectedRows(0).Cells(2).Value
        lblUnit.Text = dgMainItem.SelectedRows(0).Cells(3).Value
        dgMainItem.Visible = False : txtMainQty.Focus()
    End Sub


    Private Sub RawItemRowColumns()
        DgRawItem.ColumnCount = 4
        DgRawItem.Columns(0).Name = "ID" : DgRawItem.Columns(0).Visible = False
        DgRawItem.Columns(1).Name = "Item Code" : DgRawItem.Columns(1).Width = 50
        DgRawItem.Columns(2).Name = "Item Name" : DgRawItem.Columns(2).Width = 300
        DgRawItem.Columns(3).Name = "Unit" : DgRawItem.Columns(3).Width = 100
        retriveMainItems()
    End Sub

    Private Sub retriveRawItems(Optional ByVal condtion As String = "")
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("Select ID,ItemCode,ItemName,TableRate,RatePer from Item_View " & condtion & " order by ItemCode,ItemName liMIT 20")
        Try
            If dt.Rows.Count > 0 Then
                DgRawItem.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    DgRawItem.Rows.Add()
                    With DgRawItem.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("ID").ToString()
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

    Private Sub txtRawItems_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRawItem.KeyPress
        If Not Char.IsLetterOrDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso e.KeyChar <> "%" AndAlso Not Char.IsControl(e.KeyChar) AndAlso e.KeyChar <> " " Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtRawItems_KeyUp(sender As Object, e As KeyEventArgs) Handles txtRawItem.KeyUp
        If DgRawItem.ColumnCount = 0 Then ItemRowColumns()
        If txtRawItem.Text.Trim() <> "" Then
            DgRawItem.Visible = True : DgRawItem.BringToFront()
            retriveRawItems(" Where upper(ItemName) Like upper('%" & txtRawItem.Text.Trim() & "%') or upper(ItemCode)  Like upper('" & txtRawItem.Text.Trim() & "%') ")
        Else
            retriveRawItems()
        End If
        If e.KeyCode = Keys.Escape Then DgRawItem.Visible = False
    End Sub

    Private Sub DgRawItem_KeyDown(sender As Object, e As KeyEventArgs) Handles DgRawItem.KeyDown
        If e.KeyCode = Keys.Enter Then
            If DgRawItem.SelectedRows.Count = 0 Then Exit Sub
            txtRawItem.Clear() : txtRawItemID.Clear()
            txtRawItemID.Text = Val(DgRawItem.SelectedRows(0).Cells(0).Value)
            ' lblCode.Text = DgRawItem.SelectedRows(0).Cells(1).Value
            txtRawItem.Text = DgRawItem.SelectedRows(0).Cells(2).Value
            txtRawUnit.Text = DgRawItem.SelectedRows(0).Cells(3).Value
            DgRawItem.Visible = False : txtRawQty.Focus()
            e.SuppressKeyPress = True
        End If
        If e.KeyCode = Keys.F3 Then
            Items.MdiParent = MainScreenForm
            Items.Show()
            Items.BringToFront()
        End If
        If e.KeyCode = Keys.F1 Then
            Items.MdiParent = MainScreenForm
            Items.Show()
            Items.FillControls(Val(DgRawItem.SelectedRows(0).Cells(0).Value))
            Items.BringToFront()
        End If
    End Sub

    Private Sub DgRawItem_MouseClick(sender As Object, e As MouseEventArgs) Handles DgRawItem.MouseClick
        If DgRawItem.SelectedRows.Count = 0 Then Exit Sub
        txtRawItem.Clear() : txtRawItemID.Clear()
        txtRawItemID.Text = Val(DgRawItem.SelectedRows(0).Cells(0).Value)
        ' lblCode.Text = DgRawItem.SelectedRows(0).Cells(1).Value
        txtRawItem.Text = DgRawItem.SelectedRows(0).Cells(2).Value
        txtRawUnit.Text = DgRawItem.SelectedRows(0).Cells(3).Value
        DgRawItem.Visible = False : txtRawQty.Focus()
    End Sub

    Private Sub Delete()
        If MessageBox.Show("Are You Sure Want to Delete Receipe ?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If clsFun.ExecNonQuery("DELETE from Receipe WHERE ID=" & Val(txtID.Text) & ";DELETE from ReceipeItems WHERE ReceipeID=" & Val(txtID.Text) & "") > 0 Then
                MsgBox("Receipe Deleted Successfully", vbInformation + vbOKOnly, "Receipe Deleted")
                TxtclearAll()
            End If
        End If
    End Sub

    Private Sub txtRawQty_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRawQty.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(txtRawQty.Text.Trim) = 0 Then MsgBox("Please Check Raw Qty.", vbCritical + vbOKOnly, "Check Raw Qty") : txtRawQty.Focus() : Exit Sub
            If txtRawItem.Text.Trim = "" Then MsgBox("Please Fill Raw Item.", vbCritical + vbOKOnly, "Check Raw Item") : txtRawItem.Focus() : Exit Sub
            If dg1.SelectedRows.Count = 0 Then
                dg1.Rows.Add((txtRawItemID.Text), txtRawItem.Text, txtRawUnit.Text, Format(Val(txtRawQty.Text), "0.00"))
                txtRawItem.Focus() : dg1.ClearSelection() : Calc()
            Else
                dg1.SelectedRows(0).Cells(0).Value = Val(txtRawItemID.Text)
                dg1.SelectedRows(0).Cells(1).Value = txtRawItem.Text
                dg1.SelectedRows(0).Cells(2).Value = txtRawUnit.Text
                dg1.SelectedRows(0).Cells(3).Value = Format(Val(txtRawQty.Text), "0.00")
                txtRawItem.Focus() : dg1.ClearSelection() : Calc()
            End If
        End If
        If e.KeyCode = Keys.Delete Then
            If dg1.SelectedRows.Count = 0 Then Exit Sub
            If MessageBox.Show("Are You Sure Want to Delete Selected Item ?", "Delete Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                dg1.Rows.Remove(dg1.SelectedRows(0))
                txtRawItem.Focus() : dg1.ClearSelection() : Calc()
            End If
        End If
        If txtRawQty.Focused Then
            If e.KeyCode = Keys.Down Then
                If DgRawItem.Visible = True Then DgRawItem.Focus() : Exit Sub
                If dg1.Rows.Count = 0 Then Exit Sub
                dg1.Rows(0).Selected = True : dg1.Focus() : Calc()
            End If
        End If
    End Sub

    Private Sub dg1_KeyDown(sender As Object, e As KeyEventArgs) Handles dg1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dg1.SelectedRows.Count = 0 Then Exit Sub
            txtRawItemID.Text = Val(dg1.SelectedRows(0).Cells(0).Value)
            txtRawItem.Text = dg1.SelectedRows(0).Cells(1).Value
            txtRawUnit.Text = dg1.SelectedRows(0).Cells(2).Value
            txtRawQty.Text = dg1.SelectedRows(0).Cells(3).Value
            txtRawItem.Focus()
            e.SuppressKeyPress = True
        End If

    End Sub

    Private Sub dg1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dg1.MouseDoubleClick
        If dg1.SelectedRows.Count = 0 Then Exit Sub
        txtRawItemID.Text = Val(dg1.SelectedRows(0).Cells(0).Value)
        txtRawItem.Text = dg1.SelectedRows(0).Cells(1).Value
        txtRawUnit.Text = dg1.SelectedRows(0).Cells(2).Value
        txtRawQty.Text = dg1.SelectedRows(0).Cells(3).Value
        txtRawItem.Focus()
    End Sub

    Private Sub txtMainQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMainQty.KeyPress, txtRawQty.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8 Or ((e.KeyChar = ".") And (sender.Text.IndexOf(".") = -1)))
    End Sub

    Private Sub Calc()
        txtTotRowQty.Text = Format(0, "0.00") : lblTotalRaws.Text = Format(0, "0.00")
        For i = 0 To dg1.Rows.Count - 1
            txtTotRowQty.Text = Format(Val(txtTotRowQty.Text) + Val(dg1.Rows(i).Cells(3).Value), "0.00")
        Next
        lblTotalRaws.Text = "Total Row Items : " & Val(dg1.Rows.Count)
    End Sub
    Private Sub Save()
        Dim Sql As String = String.Empty
        Sql = "Insert Into Receipe (ReceipeName,ItemID,ItemName,Qty,UnitName,ServiceName)values " & _
              "('" & txtReceipeName.Text & "'," & Val(txtMainItemID.Text) & ",'" & txtMainItem.Text & "','" & Val(txtMainQty.Text) & "','" & lblUnit.Text & "','Item To Produce') "
        If clsFun.ExecNonQuery(Sql) > 0 Then
            txtID.Text = Val(clsFun.ExecScalarInt("Select Max(ID) from Receipe"))
            Dg1Record()
            MsgBox("Record Saved Successfully.", vbInformation + vbOKOnly, "Saved")
            TxtclearAll()
        End If
    End Sub

    Private Sub Update()
        If Val(txtID.Text) = 0 Then TxtclearAll() : Exit Sub
        Dim Sql As String = String.Empty
        Sql = "Update Receipe SET ReceipeName='" & txtReceipeName.Text & "',ItemID=" & Val(txtMainItemID.Text) & ", " & _
            "ItemName='" & txtMainItem.Text & "',Qty='" & Val(txtMainQty.Text) & "',UnitName='" & lblUnit.Text & "',ServiceName='Item To Produce' Where ID=" & Val(txtID.Text) & ""
        If clsFun.ExecNonQuery(Sql) > 0 Then
            clsFun.ExecNonQuery("Delete from  ReceipeItems Where ReceipeID=" & Val(txtID.Text) & "")
            Dg1Record()
            MsgBox("Record Updated Successfully.", vbInformation + vbOKOnly, "Updated")
            TxtclearAll()
        End If
    End Sub
    Private Sub TxtclearAll()
        txtReceipeName.Clear() : txtMainItem.Clear()
        txtMainItemID.Clear() : lblUnit.Text = ""
        txtRawItem.Clear() : txtRawQty.Clear()
        txtRawUnit.Clear() : txtRawItemID.Clear()
        dg1.Rows.Clear() : BtnSave.Text = "&Save"
        btnDelete.Visible = False
        lblTotalRaws.Text = "" : txtTotRowQty.Clear()
        txtID.Clear() : txtReceipeName.Focus()
    End Sub
    Private Sub Dg1Record()
        Dim Sql As String = String.Empty
        Dim FastQuery As String = String.Empty
        For Each row As DataGridViewRow In dg1.Rows
            With row
                If .Cells(0).Value <> 0 Then
                    FastQuery = FastQuery & IIf(FastQuery <> "", " UNION ALL SELECT ", " SELECT ") & "'" & Val(txtID.Text) & "','" & txtReceipeName.Text & "','" & Val(.Cells(0).Value) & "'," & _
                        "'" & .Cells(1).Value & "','" & .Cells(3).Value & "','" & .Cells(2).Value & "'"
                End If
            End With
        Next
        If FastQuery = "" Then Exit Sub
        Sql = "INSERT INTO ReceipeItems(ReceipeID,ReceipeName,ItemID,ItemName,Qty,UnitName)" & FastQuery & ""
        Try
            clsFun.ExecNonQuery(Sql)
        Catch ex As Exception
            MsgBox(ex.Message)
            clsFun.CloseConnection()
        End Try
        clsFun.CloseConnection()
    End Sub


    Private Sub txtReceipeRegister_Click(sender As Object, e As EventArgs) Handles btnReceipeRegister.Click
        Receipe_Register.MdiParent = MainScreenForm
        Receipe_Register.Show()
        Receipe_Register.BringToFront()
    End Sub


    Public Sub FillControls(ByVal id As Integer)
        btnDelete.Visible = True
        BtnSave.Text = "&Update"
        sSql = "Select * from Receipe where id=" & Val(id)
        Dim ad As New SQLite.SQLiteDataAdapter(sSql, clsFun.GetConnection)
        Dim ds As New DataSet
        ad.Fill(ds, "a")
        If ds.Tables("a").Rows.Count > 0 Then
            txtID.Text = ds.Tables("a").Rows(0)("ID").ToString()
            txtReceipeName.Text = ds.Tables("a").Rows(0)("ReceipeName").ToString()
            txtMainItemID.Text = Val(ds.Tables("a").Rows(0)("ItemID").ToString())
            txtMainItem.Text = ds.Tables("a").Rows(0)("ItemName").ToString()
            txtMainQty.Text = Val(ds.Tables("a").Rows(0)("Qty").ToString())
            lblUnit.Text = ds.Tables("a").Rows(0)("UnitName").ToString()
        End If
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("SELECT * FROM ReceipeItems where ReceipeID=" & Val(id))
        Dim dvData As DataView = New DataView(dt)
        If dt.Rows.Count > 0 Then
            dg1.Rows.Clear()
            For i = 0 To dt.Rows.Count - 1
                dg1.Rows.Add()
                With dg1.Rows(i)
                    .Cells(0).Value = dt.Rows(i)("ItemID").ToString()
                    .Cells(1).Value = dt.Rows(i)("ItemName").ToString()
                    .Cells(2).Value = dt.Rows(i)("UnitName").ToString()
                    .Cells(3).Value = Format(Val(dt.Rows(i)("Qty").ToString()), "0.00")
                End With
            Next
        End If
        Calc() : dg1.ClearSelection()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If BtnSave.Text = "&Save" Then
            If clsFun.ExecScalarStr("Select count(*)from Receipe where upper(ReceipeName)=upper('" & txtReceipeName.Text & "')") = 1 Then
                MsgBox("Receipe Already Exists...", vbCritical + vbOKOnly, "Access Denied") : txtReceipeName.Focus() : Exit Sub
            End If
            If clsFun.ExecScalarInt("Select count(*)from Receipe where ItemID=" & (txtMainItemID.Text) & "") = 1 Then
                MsgBox("Receipe For this Items Already Exists...", vbCritical + vbOKOnly, "Access Denied") : txtMainItem.Focus() : Exit Sub
            End If
        Else
            If clsFun.ExecScalarStr("Select count(*)from Receipe where upper(ReceipeName)=upper('" & txtReceipeName.Text & "')") > 1 Then
                MsgBox("Receipe Already Exists...", vbCritical + vbOKOnly, "Access Denied") : txtReceipeName.Focus() : Exit Sub
            End If
            If clsFun.ExecScalarInt("Select count(*)from Receipe where ItemID=" & (txtMainItemID.Text) & "") > 1 Then
                MsgBox("Receipe For this Items Already Exists...", vbCritical + vbOKOnly, "Access Denied") : txtMainItem.Focus() : Exit Sub
            End If
        End If
        If txtReceipeName.Text.Trim = "" Then MsgBox("Please Fill Receipe Name.", vbCritical + vbOKOnly, "Receipe Name") : txtReceipeName.Focus() : Exit Sub
        If Val(txtMainQty.Text.Trim) = 0 Then MsgBox("Please Check Main Qty.", vbCritical + vbOKOnly, "Check Main Qty") : txtMainQty.Focus() : Exit Sub
        If txtMainItem.Text.Trim = "" Then MsgBox("Please Fill Main Item.", vbCritical + vbOKOnly, "Check Main Item") : txtMainItem.Focus() : Exit Sub
        If dg1.Rows.Count = 0 Then MsgBox("There is No Record to Save/Update", vbCritical + vbOKOnly, "Add Some Items") : txtRawItem.Focus() : Exit Sub
        If BtnSave.Text = "&Save" Then
            Save()
        Else
            Update()
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub txtReceipeName_Leave(sender As Object, e As EventArgs) Handles txtReceipeName.Leave
        If BtnSave.Text = "&Save" Then
            If clsFun.ExecScalarStr("Select count(*)from Receipe where upper(ReceipeName)=upper('" & txtReceipeName.Text & "')") = 1 Then
                MsgBox("Receipe Already Exists...", vbCritical + vbOKOnly, "Access Denied") : txtReceipeName.Focus() : Exit Sub
            End If
        Else
            If clsFun.ExecScalarStr("Select count(*)from Receipe where upper(ReceipeName)=upper('" & txtReceipeName.Text & "')") > 1 Then
                MsgBox("Receipe Already Exists...", vbCritical + vbOKOnly, "Access Denied") : txtReceipeName.Focus() : Exit Sub
            End If
        End If
    End Sub

    Private Sub txtMainQty_TextChanged(sender As Object, e As EventArgs) Handles txtMainQty.TextChanged

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Delete()
    End Sub

    Private Sub txtRawItem_TextChanged(sender As Object, e As EventArgs) Handles txtRawItem.TextChanged

    End Sub
End Class