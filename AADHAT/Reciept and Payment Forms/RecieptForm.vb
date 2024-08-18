Imports System.Globalization

Public Class RecieptForm
    Dim Vno As Integer


    Private Sub RecieptForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If DgAccountSearch.Visible = True Then
                DgAccountSearch.Visible = False
                txtAccount.Focus()
                Exit Sub
            ElseIf dgMode.Visible = True Then
                dgMode.Visible = False
                txtMode.Focus()
                Exit Sub
            ElseIf pnlbbb.Visible = True Then
                pnlbbb.Visible = False
                mskEntryDate.Focus()
                Exit Sub
            Else
                Dim msgRslt As MsgBoxResult = MsgBox("Are you Sure Want to Close Entry?", MsgBoxStyle.YesNo, "AccoBook")
                If msgRslt = MsgBoxResult.Yes Then
                    Me.Close()
                ElseIf msgRslt = MsgBoxResult.No Then
                End If
            End If
        End If
    End Sub

    Private Sub dg1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg1.CellClick
        dg1.ClearSelection()
    End Sub
    Private Sub RecieptForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0 : Me.Left = 0
        dgMode.BorderStyle = BorderStyle.None
        DgAccountSearch.BorderStyle = BorderStyle.None
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        mskEntryDate.Text = Date.Today.ToString("dd-MM-yyyy")
        rowColums() : VNumber() : rowColums1()
    End Sub
    Private Sub rowColums1()
        dg2.ColumnCount = 7
        dg2.Columns(0).Name = "ID" : dg2.Columns(0).Visible = False
        dg2.Columns(1).Name = "Date" : dg2.Columns(1).Width = 100
        dg2.Columns(2).Name = "Bill No." : dg2.Columns(2).Width = 100
        dg2.Columns(3).Name = "Type" : dg2.Columns(3).Width = 100
        dg2.Columns(4).Name = "Ref.Amount" : dg2.Columns(4).Width = 100
        dg2.Columns(5).Name = "Adj. Amt" : dg2.Columns(5).Width = 100
        dg2.Columns(6).Name = "Bal.Amt" : dg2.Columns(6).Width = 100
    End Sub

    Private Sub RetriveRef()
        Dim lasval As Integer = 0
        Dim Balamt As Decimal = Val(txtReciveAmount.Text)
        dg2.Rows.Clear()
        If lblBBB.Text <> "Y" Then pnlbbb.Visible = False : Exit Sub
        Dim dt As New DataTable
        If btnSave.Text = "&Save" Then
            dt = clsFun.ExecDataTable("Select * FROM Ref WHERE AccountID = '" & Val(txtAccountID.Text) & "' and (RefID=0 or RefID isNull) and TransType='Sale' Order by EntryDate,InvoiceNo")
            Try
                If dt.Rows.Count > 0 Then
                    For i = 0 To dt.Rows.Count - 1
                        Dim oldBalance As Decimal = Val(clsFun.ExecScalarStr("Select Sum(RefAmount) From Ref Where DC='C' and RefID=" & Val(dt.Rows(i)("VoucherID").ToString()) & ""))
                        If oldBalance <> Val(dt.Rows(i)("RefAmount").ToString()) Then
                            dg2.Rows.Add()
                            With dg2.Rows(lasval)
                                .Cells(0).ReadOnly = True : .Cells(1).ReadOnly = True
                                .Cells(2).ReadOnly = True : .Cells(3).ReadOnly = True
                                .Cells(4).ReadOnly = True : .Cells(6).ReadOnly = True
                                .Cells(0).Value = dt.Rows(i)("VoucherID").ToString()
                                .Cells(1).Value = Format(dt.Rows(i)("Entrydate"), "dd-MM-yyyy")
                                .Cells(2).Value = dt.Rows(i)("InvoiceNo").ToString()
                                .Cells(3).Value = dt.Rows(i)("TransType").ToString()
                                .Cells(4).Value = Format(Val(dt.Rows(i)("RefAmount").ToString()) - Val(oldBalance), "0.00")
                                If lasval = 0 Then
                                    If Val(Balamt) < Val(dt.Rows(i)("RefAmount").ToString()) Then
                                        .Cells(5).Value = Format(Val(Balamt), "0.00")
                                        .Cells(6).Value = Format(Val(.Cells(4).Value) - Val(.Cells(5).Value), "0.00")
                                        Balamt = Format(Val(Balamt) - Val(.Cells(5).Value), "0.00")
                                    ElseIf Val(Balamt) >= Val(dt.Rows(i)("RefAmount").ToString()) Then
                                        '.Cells(6).Value = Format(Val(Balamt) - Val(dt.Rows(i)("RefAmount").ToString()), "0.00")
                                        .Cells(5).Value = Format(Val(Val(dt.Rows(i)("RefAmount").ToString())), "0.00")
                                        .Cells(6).Value = Format(Val(Val(.Cells(5).Value) - .Cells(4).Value), "0.00")
                                        Balamt = Format(Val(Balamt) - Val(.Cells(5).Value), "0.00")
                                    End If
                                Else
                                    If Val(Balamt) < Val(.Cells(4).Value) Then
                                        .Cells(5).Value = Format(Val(Balamt), "0.00")
                                        .Cells(6).Value = Format(Val(.Cells(4).Value) - Val(.Cells(5).Value), "0.00")
                                        Balamt = Format(Val(Balamt) - Val(.Cells(5).Value), "0.00")
                                    ElseIf Val(Balamt) > Val(dt.Rows(i)("RefAmount").ToString()) Then
                                        .Cells(6).Value = Format(Val(Balamt) - Val(.Cells(4).Value), "0.00")
                                        .Cells(5).Value = Format(Val(Val(.Cells(4).Value)), "0.00")
                                        Balamt = Val(.Cells(6).Value)
                                    End If
                                End If

                                '.Cells(5).Value = Format(Val(dt.Rows(i)("AdjAmount").ToString()), "0.00")
                                '.Cells(6).Value = Format(Val(dt.Rows(i)("DueAmount").ToString()), "0.00")
                                .Cells(4).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                                .Cells(5).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                                .Cells(6).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                                lasval = lasval + 1
                            End With
                        End If
                    Next
                    If dg2.Rows.Count = 0 Then pnlbbb.Visible = False : txtDiscountAmount.Focus() : Exit Sub
                    If lblBBB.Text = "Y" Then pnlbbb.Visible = True : pnlbbb.BringToFront() : dg2.Focus() : dg2.Rows(0).Cells(5).Selected = True Else pnlbbb.Visible = False
                End If
                dt.Dispose()
            Catch ex As Exception
                MsgBox(ex.Message, vbOKOnly + vbInformation, "AccoBook")
            End Try


        Else
            dt = clsFun.ExecDataTable("Select * FROM Ref WHERE AccountID = '" & Val(txtAccountID.Text) & "'  and  VoucherID=" & Val(txtID.Text) & "  Order by EntryDate,InvoiceNo")

            Try
                If dt.Rows.Count > 0 Then
                    For i = 0 To dt.Rows.Count - 1
                        dg2.Rows.Add()
                        With dg2.Rows(i)
                            .Cells(0).Readonly = True : .Cells(1).Readonly = True
                            .Cells(2).Readonly = True : .Cells(3).Readonly = True
                            .Cells(4).Readonly = True : .Cells(6).Readonly = True
                            .Cells(0).Value = dt.Rows(i)("VoucherID").ToString()
                            .Cells(1).Value = Format(dt.Rows(i)("Entrydate"), "dd-MM-yyyy")
                            .Cells(2).Value = dt.Rows(i)("InvoiceNo").ToString()
                            .Cells(3).Value = dt.Rows(i)("TransType").ToString()
                            .Cells(4).Value = Format(Val(dt.Rows(i)("TotalAmount").ToString()), "0.00")
                            .Cells(5).Value = Format(Val(dt.Rows(i)("AdjAmount").ToString()), "0.00")
                            .Cells(6).Value = Format(Val(dt.Rows(i)("DueAmount").ToString()), "0.00")
                            'If i = 0 Then
                            '    If Val(Balamt) < Val(dt.Rows(i)("RefAmount").ToString()) Then
                            '        .Cells(5).Value = Format(Val(Balamt), "0.00")
                            '        .Cells(6).Value = Format(Val(dt.Rows(i)("RefAmount").ToString()) - Val(.cells(5).value), "0.00")
                            '        Balamt = Format(Val(Balamt) - Val(.cells(5).value), "0.00")
                            '    ElseIf Val(Balamt) >= Val(dt.Rows(i)("RefAmount").ToString()) Then
                            '        '.Cells(6).Value = Format(Val(Balamt) - Val(dt.Rows(i)("RefAmount").ToString()), "0.00")
                            '        .Cells(5).Value = Format(Val(Val(dt.Rows(i)("RefAmount").ToString())), "0.00")
                            '        .Cells(6).Value = Format(Val(.cells(5).value) - Val(dt.Rows(i)("RefAmount").ToString()), "0.00")
                            '        Balamt = Format(Val(Balamt) - Val(.cells(5).value), "0.00")
                            '    End If
                            'Else
                            '    If Val(Balamt) < Val(dt.Rows(i)("RefAmount").ToString()) Then
                            '        .Cells(5).Value = Format(Val(Balamt), "0.00")
                            '        .Cells(6).Value = Format(Val(dt.Rows(i)("RefAmount").ToString()) - Val(.cells(5).value), "0.00")
                            '        Balamt = Format(Val(Balamt) - Val(.cells(5).value), "0.00")
                            '    ElseIf Val(Balamt) > Val(dt.Rows(i)("RefAmount").ToString()) Then
                            '        .Cells(6).Value = Format(Val(Balamt) - Val(dt.Rows(i)("RefAmount").ToString()), "0.00")
                            '        .Cells(5).Value = Format(Val(Val(dt.Rows(i)("RefAmount").ToString())), "0.00")
                            '        Balamt = Val(.Cells(6).Value)
                            '    End If
                            'End If

                            '.Cells(5).Value = Format(Val(dt.Rows(i)("AdjAmount").ToString()), "0.00")
                            '.Cells(6).Value = Format(Val(dt.Rows(i)("DueAmount").ToString()), "0.00")
                            .Cells(4).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Cells(5).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Cells(6).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        End With
                    Next
                    If dg2.Rows.Count = 0 Then pnlbbb.Visible = False : txtDiscountAmount.Focus() : Exit Sub
                    If lblBBB.Text = "Y" Then pnlbbb.Visible = True : pnlbbb.BringToFront() : dg2.Focus() : dg2.Rows(0).Cells(5).Selected = True Else pnlbbb.Visible = False
                End If
                dt.Dispose()
            Catch ex As Exception
                MsgBox(ex.Message, vbOKOnly + vbInformation, "AccoBook")
            End Try

        End If

        'dt = clsFun.ExecDataTable("Select * from Vouchers where TransType= '" & Me.Text & "'and EntryDate='" & mskEntryDate.Text & "'")

        calcRef() : Application.DoEvents()
    End Sub
    Private Sub AcBal()
        'Dim i, j As Integer
        Dim dt As New DataTable
        Dim dt1 As New DataTable
        Dim dt2 As New DataTable
        Dim opbal As String = ""
        Dim ClBal As String = ""
        opbal = clsFun.ExecScalarStr(" Select (OpBal) FROM Accounts WHERE ID=  " & Val(txtAccountID.Text) & "")
        Dim tmpamtdr As String = clsFun.ExecScalarStr("Select sum(Amount) as tot from Ledger where Dc='D' and accountID=" & Val(txtAccountID.Text) & " and EntryDate <= '" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "'")
        Dim tmpamtcr As String = clsFun.ExecScalarStr("Select sum(Amount) as tot from Ledger where Dc='C' and accountID=" & Val(txtAccountID.Text) & " and EntryDate <= '" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "'")
        ' opbal = clsFun.ExecScalarStr(" Select (OpBal) FROM Accounts WHERE AccountName like '%" + cbAccountName.Text + "%'")
        Dim drcr As String = clsFun.ExecScalarStr(" Select Dc FROM Accounts WHERE ID= " & Val(txtAccountID.Text) & "")
        If drcr = "Dr" Then
            tmpamtdr = Val(opbal) + Val(tmpamtdr)
        Else
            tmpamtcr = Val(opbal) + Val(tmpamtcr)
        End If
        Dim tmpamt As String = IIf(Val(tmpamtdr) > Val(tmpamtcr), Val(tmpamtdr) - Val(tmpamtcr), Val(tmpamtcr) - Val(tmpamtdr)) '- Val(opbal)
        If drcr = "Cr" Then
            opbal = Math.Abs(Val(opbal)) & " Cr"
        Else
            opbal = Math.Abs(Val(opbal)) & " Dr"
        End If
        Dim cntbal As Integer = 0
        cntbal = clsFun.ExecScalarInt("Select count(*) from ledger where  accountid=" & Val(txtAccountID.Text) & " and  EntryDate <= '" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "'")
        If cntbal = 0 Then
            opbal = Math.Abs(Val(opbal)) & " " & clsFun.ExecScalarStr(" Select dc from accounts where id= " & Val(txtAccountID.Text) & "")
        Else
            If Val(tmpamtcr) > Val(tmpamtdr) Then
                opbal = Format(Math.Abs(Val(tmpamt)), "0.00") & " Cr"
            Else
                opbal = Format(Math.Abs(Val(tmpamt)), "0.00") & " Dr"
            End If
        End If
        lblAcBal.Visible = True
        lblAcBal.Text = "Bal : " & opbal
    End Sub
    Private Sub CapAcBal()
        Dim i, j As Integer
        Dim dt As New DataTable
        Dim dt1 As New DataTable
        Dim dt2 As New DataTable
        Dim opbal As String = ""
        Dim ClBal As String = ""
        opbal = clsFun.ExecScalarStr(" Select (OpBal) FROM Accounts WHERE ID=  " & Val(txtModeID.Text) & "")
        Dim tmpamtdr As String = clsFun.ExecScalarStr("Select sum(Amount) as tot from Ledger where Dc='D' and accountID=" & Val(txtModeID.Text) & " and EntryDate <= '" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "'")
        Dim tmpamtcr As String = clsFun.ExecScalarStr("Select sum(Amount) as tot from Ledger where Dc='C' and accountID=" & Val(txtModeID.Text) & " and EntryDate <= '" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "'")
        ' opbal = clsFun.ExecScalarStr(" Select (OpBal) FROM Accounts WHERE AccountName like '%" + cbAccountName.Text + "%'")
        Dim drcr As String = clsFun.ExecScalarStr(" Select Dc FROM Accounts WHERE ID= " & Val(txtModeID.Text) & "")
        If drcr = "Dr" Then
            tmpamtdr = Val(opbal) + Val(tmpamtdr)
        Else
            tmpamtcr = Val(opbal) + Val(tmpamtcr)
        End If
        Dim tmpamt As String = IIf(Val(tmpamtdr) > Val(tmpamtcr), Val(tmpamtdr) - Val(tmpamtcr), Val(tmpamtcr) - Val(tmpamtdr)) '- Val(opbal)
        If drcr = "Cr" Then
            opbal = Math.Abs(Val(opbal)) & " Cr"
        Else
            opbal = Math.Abs(Val(opbal)) & " Dr"
        End If
        Dim cntbal As Integer = 0
        cntbal = clsFun.ExecScalarInt("Select count(*) from ledger where  accountid=" & Val(txtModeID.Text) & " and  EntryDate <= '" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "'")
        If cntbal = 0 Then
            opbal = Math.Abs(Val(opbal)) & " " & clsFun.ExecScalarStr(" Select dc from accounts where id=" & Val(txtModeID.Text) & "")
        Else
            If Val(tmpamtcr) > Val(tmpamtdr) Then
                opbal = Format(Math.Abs(Val(tmpamt)), "0.00") & " Cr"
            Else
                opbal = Format(Math.Abs(Val(tmpamt)), "0.00") & " Dr"
            End If
        End If
        lblCapAcBal.Visible = True
        lblCapAcBal.Text = "Bal : " & opbal
    End Sub
    Private Sub ModeColums()
        dgMode.ColumnCount = 2
        dgMode.Columns(0).Name = "ID" : dgMode.Columns(0).Visible = False
        dgMode.Columns(1).Name = "Mode Name" : dgMode.Columns(1).Width = 262
        RetriveMode()
    End Sub
    Private Sub RetriveMode(Optional ByVal condtion As String = "")
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("Select * from Accounts where groupid in(11,12) " & condtion & " order by AccountName")
        Try
            If dt.Rows.Count > 0 Then
                dgMode.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dgMode.Rows.Add()
                    With dgMode.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("id").ToString()
                        .Cells(1).Value = dt.Rows(i)("AccountName").ToString()
                    End With
                Next

            End If
            dt.Dispose()

        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "Teller")
        End Try
    End Sub
    Private Sub AccountRowColumns()
        DgAccountSearch.ColumnCount = 4
        DgAccountSearch.Columns(0).Name = "ID" : DgAccountSearch.Columns(0).Visible = False
        DgAccountSearch.Columns(1).Name = "Account Name" : DgAccountSearch.Columns(1).Width = 200
        DgAccountSearch.Columns(2).Name = "City" : DgAccountSearch.Columns(2).Width = 110
        DgAccountSearch.Columns(3).Name = "BBB" : DgAccountSearch.Columns(3).Visible = False
    End Sub
    Private Sub retriveAccounts(Optional ByVal condtion As String = "")
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("Select * From Accounts where not groupid in(11,12) " & condtion & " order by AccountName")
        Try
            If dt.Rows.Count > 0 Then
                DgAccountSearch.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    DgAccountSearch.Rows.Add()
                    With DgAccountSearch.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("id").ToString()
                        .Cells(1).Value = dt.Rows(i)("AccountName").ToString()
                        .Cells(2).Value = dt.Rows(i)("City").ToString()
                        .Cells(3).Value = dt.Rows(i)("MaintainBillByBill").ToString()
                    End With
                    ' Dg1.Rows.Add()
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "Teller")
        End Try
    End Sub
    Private Sub dgMode_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgMode.CellClick
        txtMode.Clear()
        txtModeID.Clear()
        txtModeID.Text = dgMode.SelectedRows(0).Cells(0).Value
        txtMode.Text = dgMode.SelectedRows(0).Cells(1).Value
        dgMode.Visible = False
        txtAccount.Focus()
    End Sub

    Private Sub dgMode_KeyDown(sender As Object, e As KeyEventArgs) Handles dgMode.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtMode.Clear()
            txtModeID.Clear()
            txtModeID.Text = dgMode.SelectedRows(0).Cells(0).Value
            txtMode.Text = dgMode.SelectedRows(0).Cells(1).Value
            dgMode.Visible = False
            txtAccount.Focus()
        End If
        If e.KeyCode = Keys.Back Then
            txtMode.Focus()
        End If
        If e.KeyCode = Keys.F3 Then
            CreateAccount.MdiParent = MainScreenForm
            CreateAccount.Show()
            clsFun.FillDropDownList(CreateAccount.cbGroup, "Select ID,GroupName FROM AccountGroup Where ID=12", "GroupName", "ID", "")
            If Not CreateAccount Is Nothing Then
                CreateAccount.BringToFront()
            End If
        End If
        If e.KeyCode = Keys.F1 Then
            If dgMode.SelectedRows.Count = 0 Then Exit Sub
            Dim tmpAcID As Integer = dgMode.SelectedRows(0).Cells(0).Value
            CreateAccount.MdiParent = MainScreenForm
            CreateAccount.Show()
            CreateAccount.FillContros(tmpAcID)
            If Not CreateAccount Is Nothing Then
                CreateAccount.BringToFront()
            End If
        End If
        If e.KeyCode = Keys.Back Then txtMode.Focus()
    End Sub
    Private Sub txtAccount_GotFocus(sender As Object, e As EventArgs) Handles txtAccount.GotFocus
        If dgMode.ColumnCount = 0 Then ModeColums()
        If dgMode.RowCount = 0 Then RetriveMode()
        If dgMode.SelectedRows.Count = 0 Then dgMode.Visible = True
        If txtMode.Text.Trim() <> "" Then
            RetriveMode(" And upper(AccountName) Like upper('" & txtMode.Text.Trim() & "%')")
        Else
            RetriveMode()
        End If
        txtModeID.Text = dgMode.SelectedRows(0).Cells(0).Value
        txtMode.Text = dgMode.SelectedRows(0).Cells(1).Value
        dgMode.Visible = False : CapAcBal()
        If DgAccountSearch.ColumnCount = 0 Then AccountRowColumns()
        If DgAccountSearch.RowCount = 0 Then retriveAccounts()
        If txtAccount.Text.Trim() <> "" Then
            retriveAccounts(" And upper(AccountName) Like upper('" & txtAccount.Text.Trim() & "%')")
        Else
            retriveAccounts()
        End If
        If DgAccountSearch.SelectedRows.Count = 0 Then DgAccountSearch.Visible = True
    End Sub
    Private Sub txtAccount_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAccount.KeyDown
        If e.KeyCode = Keys.Down Then DgAccountSearch.Focus()
        If e.KeyCode = Keys.F3 Then
            CreateAccount.MdiParent = MainScreenForm
            CreateAccount.Show()
            clsFun.FillDropDownList(CreateAccount.cbGroup, "Select ID,GroupName FROM AccountGroup", "GroupName", "ID", "")
            If Not CreateAccount Is Nothing Then
                CreateAccount.BringToFront()
            End If
        End If
        If e.KeyCode = Keys.F1 Then
            If DgAccountSearch.SelectedRows.Count = 0 Then Exit Sub
            Dim tmpAcID As Integer = DgAccountSearch.SelectedRows(0).Cells(0).Value
            CreateAccount.MdiParent = MainScreenForm
            CreateAccount.Show()
            CreateAccount.FillContros(tmpAcID)
            If Not CreateAccount Is Nothing Then
                CreateAccount.BringToFront()
            End If
        End If
    End Sub
    Private Sub DgAccountSearch_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgAccountSearch.CellClick
        txtAccount.Clear()
        txtAccountID.Clear()
        txtAccountID.Text = DgAccountSearch.SelectedRows(0).Cells(0).Value
        txtAccount.Text = DgAccountSearch.SelectedRows(0).Cells(1).Value
        lblBBB.Text = DgAccountSearch.SelectedRows(0).Cells(3).Value
        DgAccountSearch.Visible = False
        If txtReciptNo.TabStop = True Then txtReciptNo.Focus() Else txtReciveAmount.Focus()
    End Sub
    Private Sub DgAccountSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles DgAccountSearch.KeyDown
        If e.KeyCode = Keys.Down Then DgAccountSearch.Focus()
        If e.KeyCode = Keys.F3 Then
            CreateAccount.MdiParent = MainScreenForm
            CreateAccount.Show()
            clsFun.FillDropDownList(CreateAccount.cbGroup, "Select ID,GroupName FROM AccountGroup", "GroupName", "ID", "")
            If Not CreateAccount Is Nothing Then
                CreateAccount.BringToFront()
            End If
        End If
        If e.KeyCode = Keys.F1 Then
            If DgAccountSearch.SelectedRows.Count = 0 Then Exit Sub
            Dim tmpAcID As Integer = DgAccountSearch.SelectedRows(0).Cells(0).Value
            CreateAccount.MdiParent = MainScreenForm
            CreateAccount.Show()
            CreateAccount.FillContros(tmpAcID)
            If Not CreateAccount Is Nothing Then
                CreateAccount.BringToFront()
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            txtAccount.Clear()
            txtAccountID.Clear()
            txtAccountID.Text = DgAccountSearch.SelectedRows(0).Cells(0).Value
            txtAccount.Text = DgAccountSearch.SelectedRows(0).Cells(1).Value
            lblBBB.Text = DgAccountSearch.SelectedRows(0).Cells(3).Value
            DgAccountSearch.Visible = False
            If txtReciptNo.TabStop = True Then txtReciptNo.Focus() Else txtReciveAmount.Focus()
            e.SuppressKeyPress = True
        End If
        If e.KeyCode = Keys.Back Then txtAccount.Focus()
    End Sub
    Private Sub VNumber()
        'If Vno = Val(clsFun.ExecScalarInt("Select Max(InvoiceID) AS NumberOfProducts FROM Vouchers Where TransType='" & Me.Text & "'")) <> 0 Then
        '    Vno = clsFun.ExecScalarInt("Select Count(ID) AS NumberOfProducts FROM Vouchers Where TransType='" & Me.Text & "'")
        '    txtReciptNo.Text = Vno + 1
        '    txtInvoiceID.Text = Vno + 1
        'Else
        '    Vno = clsFun.ExecScalarInt("Select Count(ID)  AS NumberOfProducts FROM Vouchers Where TransType='" & Me.Text & "'")
        '    txtReciptNo.Text = Vno + 1
        '    txtInvoiceID.Text = Vno + 1
        'End If
        Dim vno As Integer = 0
        If vno = Val(clsFun.ExecScalarInt("Select Max(InvoiceID) AS NumberOfProducts FROM Vouchers Where TransType='" & Me.Text & "'")) <> 0 Then
            vno = clsFun.ExecScalarInt("Select Max(InvoiceID) AS NumberOfProducts FROM Vouchers Where TransType='" & Me.Text & "'")
            txtReciptNo.Text = vno + 1
            txtInvoiceID.Text = vno + 1
        Else
            vno = clsFun.ExecScalarInt("SELECT InvoiceID AS NumberOfProducts FROM Vouchers WHERE id=(SELECT max(id) FROM Vouchers Where TransType='" & Me.Text & "')")
            '  vno = clsFun.ExecScalarInt("Select Max(InvoiceID) AS NumberOfProducts FROM Vouchers Where TransType='" & Me.Text & "'")
            txtReciptNo.Text = vno + 1
            txtInvoiceID.Text = vno + 1
        End If
    End Sub
    Private Sub txtclear()
        BtnDelete.Visible = False
        VNumber()
        txtReciveAmount.Text = ""
        txtDiscountAmount.Text = ""
        txtTotalAmount.Text = ""
        btnSave.Text = "&Save"
        TxtRemark.Text = ""
        If mskEntryDate.TabStop = True Then mskEntryDate.Focus() Else txtMode.Focus()
        retrive()
        btnSave.BackColor = Color.DarkSlateGray
        'btnSave.Image = My.Resources.icons8_save_48px
    End Sub

    Private Sub rowColums()
        dg1.ColumnCount = 9
        dg1.Columns(0).Name = "ID"
        dg1.Columns(0).Visible = False
        dg1.Columns(1).Name = "Date" : dg1.Columns(1).Width = 98
        dg1.Columns(2).Name = "Mode" : dg1.Columns(2).Width = 171
        dg1.Columns(3).Name = "Account Name" : dg1.Columns(3).Width = 210
        dg1.Columns(4).Name = "Rcpt No." : dg1.Columns(4).Width = 99
        dg1.Columns(5).Name = "Amount" : dg1.Columns(5).Width = 100
        dg1.Columns(6).Name = "Discount" : dg1.Columns(6).Width = 108
        dg1.Columns(7).Name = "Total" : dg1.Columns(7).Width = 120
        dg1.Columns(8).Name = "Remark" : dg1.Columns(8).Width = 260
    End Sub
    Private Sub calcRef()
        lblTotAmount.Text = Format(0, "0.00") : lblAdjustAmoount.Text = Format(0, "0.00") : lblBalanceAmt.Text = Format(0, "0.00")
        For i = 0 To dg2.Rows.Count - 1
            lblTotAmount.Text = Format(Val(lblTotAmount.Text) + Val(dg2.Rows(i).Cells(4).Value), "0.00")
            lblAdjustAmoount.Text = Format(Val(lblAdjustAmoount.Text) + Val(dg2.Rows(i).Cells(5).Value), "0.00")
            lblBalanceAmt.Text = Format(Val(lblBalanceAmt.Text) + Val(dg2.Rows(i).Cells(6).Value), "0.00")
        Next
    End Sub

    Private Sub calc()
        txttotNet.Text = Format(0, "0.00") : txtTotDisc.Text = Format(0, "0.00") : txtTotal.Text = Format(0, "0.00")
        For i = 0 To dg1.Rows.Count - 1
            txttotNet.Text = Format(Val(txttotNet.Text) + Val(dg1.Rows(i).Cells(5).Value), "0.00")
            txtTotDisc.Text = Format(Val(txtTotDisc.Text) + Val(dg1.Rows(i).Cells(6).Value), "0.00")
            txtTotal.Text = Format(Val(txtTotal.Text) + Val(dg1.Rows(i).Cells(7).Value), "0.00")
        Next
    End Sub
    Private Sub retrive()
        dg1.Rows.Clear()
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("Select * FROM Vouchers WHERE EntryDate = '" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "' and transtype='" & Me.Text & "' Order by ID Desc")
        'dt = clsFun.ExecDataTable("Select * from Vouchers where TransType= '" & Me.Text & "'and EntryDate='" & mskEntryDate.Text & "'")
        dg1.Rows.Clear()
        Try
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("id").ToString()
                        .Cells(1).Value = Format(dt.Rows(i)("Entrydate"), "dd-MM-yyyy")
                        .Cells(2).Value = dt.Rows(i)("sellerName").ToString()
                        .Cells(4).Value = dt.Rows(i)("BillNo").ToString()
                        .Cells(3).Value = dt.Rows(i)("AccountName").ToString()
                        .Cells(5).Value = Format(Val(dt.Rows(i)("BasicAmount").ToString()), "0.00")
                        .Cells(6).Value = Format(Val(dt.Rows(i)("DiscountAmount").ToString()), "0.00")
                        .Cells(7).Value = Format(Val(dt.Rows(i)("TotalAmount").ToString()), "0.00")
                        .Cells(5).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Cells(6).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Cells(7).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Cells(8).Value = dt.Rows(i)("Remark").ToString()
                    End With
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "AccoBook")
        End Try
        calc() : dg1.ClearSelection()
    End Sub
    Private Sub retriveByDate()
        dg1.Rows.Clear()

        Dim recordsCount As Integer = clsFun.ExecScalarInt("Select Count(*) FROM Vouchers WHERE transtype = 'Super Sale'  Order By ID ")
        TotalPages = Math.Ceiling(recordsCount / RowCount)
        Dim dt As New DataTable
        Dim sql As String = "Select * FROM Vouchers WHERE EntryDate = '" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "' and transtype='" & Me.Text & "' Order by ID Desc"
        dt = clsFun.ExecDataTable(sql)
        'dt = clsFun.ExecDataTable("Select * from Vouchers where TransType= '" & Me.Text & "'and EntryDate='" & mskEntryDate.Text & "'")
        Try
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("id").ToString()
                        .Cells(1).Value = Format(dt.Rows(i)("Entrydate"), "dd-MM-yyyy")
                        .Cells(2).Value = dt.Rows(i)("sellerName").ToString()
                        .Cells(4).Value = dt.Rows(i)("BillNo").ToString()
                        .Cells(3).Value = dt.Rows(i)("AccountName").ToString()
                        .Cells(5).Value = Format(Val(dt.Rows(i)("BasicAmount").ToString()), "0.00")
                        .Cells(6).Value = Format(Val(dt.Rows(i)("DiscountAmount").ToString()), "0.00")
                        .Cells(7).Value = Format(Val(dt.Rows(i)("TotalAmount").ToString()), "0.00")
                        .Cells(5).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Cells(6).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Cells(7).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Cells(8).Value = dt.Rows(i)("Remark").ToString()
                    End With
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "AccoBook")
        End Try
        calc() : dg1.ClearSelection()
    End Sub
    Public Sub FillControls(ByVal id As Integer)
        Dim ssql As String = String.Empty
        Dim primary As String = String.Empty
        Dim dt As New DataTable
        BtnDelete.Visible = True
        btnSave.BackColor = Color.Coral
        '  btnSave.Image = My.Resources.icons8_edit_48px
        btnSave.Text = "&Update"
        ssql = "Select * from Vouchers where id=" & id
        dt = clsFun.ExecDataTable(ssql) ' where id=" & id & "")
        If dt.Rows.Count > 0 Then
            mskEntryDate.Text = Format(dt.Rows(0)("EntryDate"), "dd-MM-yyyy")
            txtModeID.Text = dt.Rows(0)("sellerID").ToString()
            txtMode.Text = dt.Rows(0)("sellerName").ToString()
            txtAccountID.Text = dt.Rows(0)("AccountID").ToString()
            txtAccount.Text = dt.Rows(0)("AccountName").ToString()
            txtReciveAmount.Text = Format(Val(dt.Rows(0)("BasicAmount").ToString()), "0.00")
            txtDiscountAmount.Text = Format(Val(dt.Rows(0)("DiscountAmount").ToString()), "0.00")
            txtTotalAmount.Text = Format(Val(dt.Rows(0)("TotalAmount").ToString()), "0.00")
            TxtRemark.Text = dt.Rows(0)("Remark").ToString()
            txtReciptNo.Text = dt.Rows(0)("BillNo").ToString()
            txtID.Text = dt.Rows(0)("ID").ToString()
            txtInvoiceID.Text = Val(dt.Rows(0)("InvoiceID").ToString())
        End If
    End Sub
    Public Sub Alert(ByVal msg As String, ByVal type As msgAlert.enmType)
        Dim frm As msgAlert = New msgAlert()
        frm.showAlert(msg, type)
    End Sub
    Private Sub save()
        Dim dt As DateTime
        dt = CDate(Me.mskEntryDate.Text)
        SqliteEntryDate = dt.ToString("yyyy-MM-dd")
        Dim cmd As New SQLite.SQLiteCommand
        If txtMode.Text = "" Then txtMode.Focus() : MsgBox("Please Fill Mode Name... ", MsgBoxStyle.Exclamation, "Empty") : Exit Sub
        If Val(txtReciveAmount.Text) = 0 Then MsgBox("Please Fill Reciveable Amount... ", MsgBoxStyle.Exclamation, "Empty") : txtReciveAmount.Focus() : Exit Sub
        If Val(txtTotalAmount.Text) = 0 Then MsgBox("Please Fill Total Amount... ", MsgBoxStyle.Exclamation, "Empty") : txtTotalAmount.Focus() : Exit Sub

        Dim sql As String = "insert into Vouchers (EntryDate,TransType,sellerID,sellerName,AccountID,AccountName,BasicAmount,DiscountAmount,TotalAmount,Remark,billNo,InvoiceID) values (@1, @2, @3,@4,@5,@6,@7,@8,@9,@10,@11,@12)"
        Try
            cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
            cmd.Parameters.AddWithValue("@1", SqliteEntryDate)
            cmd.Parameters.AddWithValue("@2", Me.Text)
            cmd.Parameters.AddWithValue("@3", Val(txtModeID.Text))
            cmd.Parameters.AddWithValue("@4", txtMode.Text)
            cmd.Parameters.AddWithValue("@5", txtAccountID.Text)
            cmd.Parameters.AddWithValue("@6", txtAccount.Text)
            cmd.Parameters.AddWithValue("@7", Val(txtReciveAmount.Text))
            cmd.Parameters.AddWithValue("@8", Val(txtDiscountAmount.Text))
            cmd.Parameters.AddWithValue("@9", Val(txtTotalAmount.Text))
            cmd.Parameters.AddWithValue("@10", TxtRemark.Text)
            cmd.Parameters.AddWithValue("@11", txtReciptNo.Text)
            cmd.Parameters.AddWithValue("@12", Val(txtInvoiceID.Text))
            If cmd.ExecuteNonQuery() > 0 Then
                txtID.Text = Val(clsFun.ExecScalarInt("Select Max(ID) from Vouchers"))
                Ledger() : Dg2Record() : txtclear() : Me.Alert("Success Alert", msgAlert.enmType.Success)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            clsFun.CloseConnection()
        End Try

    End Sub
    Private Sub Dg2Record()
        Dim FastQuery As String = String.Empty
        Dim Sql As String = String.Empty
        If clsFun.ExecScalarStr("Select MaintainBillByBill From Accounts Where ID='" & Val(txtAccountID.Text) & "'") = "Y" Then
            clsFun.ExecNonQuery("Delete From Ref Where VoucherID='" & Val(txtID.Text) & "'")
            For Each row As DataGridViewRow In dg2.Rows
                With row
                    If Val(.Cells(5).Value) <> 0 Then
                        FastQuery = FastQuery & IIf(FastQuery <> "", " UNION ALL SELECT ", " SELECT ") & Val(.Cells(0).Value) & ", " & Val(txtID.Text) & ",'" & txtReciptNo.Text & "','" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "', " & _
                            "'" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "','" & Me.Text & "','Adjustment','" & Val(txtAccountID.Text) & "', " & _
                            "'" & txtAccount.Text & "','" & Val(txtTotalAmount.Text) & "','C','" & Val(.Cells(4).Value) & "','" & Val(.Cells(5).Value) & "','" & Val(.Cells(6).Value) & "'"
                    End If
                End With
            Next
            Sql = "Insert Into Ref(RefID,VoucherID,InvoiceNo,EntryDate,DueDate,TransType,Mathod,AccountID,AccountName,RefAmount,DC,TotalAmount,AdjAmount,DueAmount)" & FastQuery &
            clsFun.ExecNonQuery(Sql)
        End If
    End Sub
    Private Sub UpdateReciept()
        Dim dt As DateTime
        dt = CDate(Me.mskEntryDate.Text)
        SqliteEntryDate = dt.ToString("yyyy-MM-dd")
        Dim cmd As New SQLite.SQLiteCommand
        If txtMode.Text = "" Then
            txtMode.Focus()
            MsgBox("Please Fill Mode Name... ", MsgBoxStyle.Exclamation, "Empty")
        Else
            Dim sql As String = "Update Vouchers SET EntryDate='" & SqliteEntryDate & "',TransType='" & Me.Text & "',sellerID=" & Val(txtModeID.Text) & ",sellerName='" & txtMode.Text & "',AccountID=" & Val(txtAccountID.Text) & ",AccountName='" & txtAccount.Text & "',BasicAmount=" & Val(txtReciveAmount.Text) & ",DiscountAmount=" & Val(txtDiscountAmount.Text) & ",TotalAmount=" & Val(txtTotalAmount.Text) & ",Remark='" & TxtRemark.Text & "',billNo='" & txtReciptNo.Text & "',InvoiceID='" & Val(txtInvoiceID.Text) & "' where ID=" & Val(txtID.Text) & ""
            Try
                If clsFun.ExecNonQuery(sql) > 0 Then
                    clsFun.CloseConnection()
                    If clsFun.ExecNonQuery("DELETE from Ledger WHERE VoucherID=" & txtID.Text & "") > 0 Then
                        Dim VchId As Integer = Val(txtID.Text)
                        Dim Remark2 As String = clsFun.ExecScalarStr("Select 'Receipt No. : '|| billNo  ||', Received Amt : ' ||BasicAmount ||', Dis Amt : ' ||DiscountAmount ||', Total Amt : ' ||TotalAmount  From Vouchers Where ID=" & Val(VchId) & "")
                        Dim RemarkHindi As String = clsFun.ExecScalarStr("Select 'रसीद नं. : '|| billNo  ||', प्राप्त राशि : ' ||BasicAmount ||', छूट राशि : ' ||DiscountAmount ||', कुल  राशि : ' ||TotalAmount  From Vouchers Where ID=" & Val(VchId) & "")
                        If txtAccountID.Text > 0 Then ''Party Account
                            clsFun.Ledger(0, VchId, SqliteEntryDate, Me.Text, txtAccountID.Text, txtAccount.Text, Val(txtReciveAmount.Text), "C", Remark2 & IIf(TxtRemark.Text = "", "", ", Remark :" & TxtRemark.Text), txtAccount.Text)
                        End If
                        If Val(txtDiscountAmount.Text) > 0 Then ''Discount Amount
                            clsFun.Ledger(0, VchId, SqliteEntryDate, Me.Text, 17, clsFun.ExecScalarStr("Select AccountName from Accounts where Id=17"), Val(txtDiscountAmount.Text), "D", Remark2 & IIf(TxtRemark.Text = "", "", ", Remark :" & TxtRemark.Text), txtAccount.Text)
                        End If
                        If Val(txtTotalAmount.Text) > 0 Then ''Total Amout
                            If txtModeID.Text > 0 Then ''Party Account
                                clsFun.Ledger(0, VchId, SqliteEntryDate, Me.Text, txtModeID.Text, txtMode.Text, Val(txtTotalAmount.Text), "D", Remark2 & IIf(TxtRemark.Text = "", "", ", Remark :" & TxtRemark.Text), txtAccount.Text)
                            End If
                        End If
                    End If
                End If
                Dg2Record() : txtclear() : Me.Alert("Update Alert", msgAlert.enmType.Update)
            Catch ex As Exception
                MsgBox(ex.Message)
                clsFun.CloseConnection()
            End Try
        End If
    End Sub
    Public Sub UpdateRecieptMulti()
        Dim dt As DateTime
        dt = CDate(Me.mskEntryDate.Text)
        SqliteEntryDate = dt.ToString("yyyy-MM-dd")
        Dim cmd As New SQLite.SQLiteCommand
        If txtMode.Text = "" Then
            txtMode.Focus()
            MsgBox("Please Fill Mode Name... ", MsgBoxStyle.Exclamation, "Empty")
        Else
            Dim sql As String = "Update Vouchers SET EntryDate='" & SqliteEntryDate & "',TransType='" & Me.Text & "',sellerID=" & Val(txtModeID.Text) & ",sellerName='" & txtMode.Text & "',AccountID=" & Val(txtAccountID.Text) & ",AccountName='" & txtAccount.Text & "',BasicAmount=" & Val(txtReciveAmount.Text) & ",DiscountAmount=" & Val(txtDiscountAmount.Text) & ",TotalAmount=" & Val(txtTotalAmount.Text) & ",Remark='" & TxtRemark.Text & "',billNo='" & txtReciptNo.Text & "',InvoiceID='" & Val(txtInvoiceID.Text) & "' where ID=" & txtID.Text & ""
            Try
                If clsFun.ExecNonQuery(sql) > 0 Then
                    Ledger() : Dg2Record() : txtclear() ': Me.Alert("Update Alert", msgAlert.enmType.Update)
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
                clsFun.CloseConnection()
            End Try
        End If
    End Sub
    Private Sub Ledger()
        clsFun.ExecNonQuery("DELETE from Ledger WHERE VoucherID=" & txtID.Text & "")
        Dim FastQuery As String = String.Empty
        SqliteEntryDate = CDate(Me.mskEntryDate.Text).ToString("yyyy-MM-dd")
        Dim Remark1 As String = "(" & txtAccount.Text & ") : " & clsFun.ExecScalarStr(" Select 'Receipt No. : '|| billNo  ||', Received Amt : ' ||BasicAmount ||', Dis Amt : ' ||DiscountAmount ||', Total Amt : ' ||TotalAmount  From Vouchers Where ID=" & Val(Val(txtID.Text)) & "")
        Dim Remark2 As String = "(" & txtMode.Text & ") : " & clsFun.ExecScalarStr(" Select 'Receipt No. : '|| billNo  ||', Received Amt : ' ||BasicAmount ||', Dis Amt : ' ||DiscountAmount ||', Total Amt : ' ||TotalAmount  From Vouchers Where ID=" & Val(Val(txtID.Text)) & "")
        Dim RemarkHindi As String = clsFun.ExecScalarStr(" Select 'रसीद नं. : '|| billNo  ||', प्राप्त राशि : ' ||BasicAmount ||', छूट राशि : ' ||DiscountAmount ||', कुल  राशि : ' ||TotalAmount  From Vouchers Where ID=" & Val(Val(txtID.Text)) & "")
        If Val(txtAccountID.Text) > 0 Then ''Party Account
            ' clsFun.Ledger(0, Val(txtID.Text), SqliteEntryDate, Me.Text, txtAccountID.Text, txtAccount.Text, Val(txtReciveAmount.Text), "C", Remark2 & IIf(TxtRemark.Text = "", "", ", Remark :" & TxtRemark.Text), txtAccount.Text, RemarkHindi & IIf(TxtRemark.Text = "", "", ", Remark :" & TxtRemark.Text))
            FastQuery = FastQuery & IIf(FastQuery <> "", " UNION ALL SELECT ", " SELECT ") & Val(txtID.Text) & ",'" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "','" & Me.Text & "'," & Val(txtAccountID.Text) & ",'" & txtAccount.Text & "'," & Val(txtReciveAmount.Text) & ",'C' ,'" & Remark2 & IIf(TxtRemark.Text = "", "", ", Remark :" & TxtRemark.Text) & "','" & txtAccount.Text & "','" & RemarkHindi & IIf(TxtRemark.Text = "", "", ", Remark :" & TxtRemark.Text) & "'"
        End If
        If Val(txtDiscountAmount.Text) > 0 Then ''Discount Amount
            '    clsFun.Ledger(0, Val(TxtID.text), SqliteEntryDate, Me.Text, 17, clsFun.ExecScalarStr("Select AccountName from Accounts where Id=17"), Val(txtDiscountAmount.Text), "D", Remark2 & IIf(TxtRemark.Text = "", "", ", Remark :" & TxtRemark.Text), txtAccount.Text, RemarkHindi & IIf(TxtRemark.Text = "", "", ", Remark :" & TxtRemark.Text))
            FastQuery = FastQuery & IIf(FastQuery <> "", " UNION ALL SELECT ", " SELECT ") & Val(txtID.Text) & ",'" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "','" & Me.Text & "'," & Val(17) & ",'" & clsFun.ExecScalarStr("Select AccountName from Accounts where Id=17") & "'," & Val(txtDiscountAmount.Text) & ",'D' ,'" & Remark2 & IIf(TxtRemark.Text = "", "", ", Remark :" & TxtRemark.Text) & "','" & txtAccount.Text & "','" & RemarkHindi & IIf(TxtRemark.Text = "", "", ", Remark :" & TxtRemark.Text) & "'"
        End If
        If Val(txtTotalAmount.Text) > 0 Then ''Total Amout
            If txtModeID.Text > 0 Then ''Party Account
                '  clsFun.Ledger(0, Val(TxtID.text), SqliteEntryDate, Me.Text, txtModeID.Text, txtMode.Text, Val(txtTotalAmount.Text), "D", Remark1 & IIf(TxtRemark.Text = "", "", ", Remark :" & TxtRemark.Text), txtAccount.Text, RemarkHindi & IIf(TxtRemark.Text = "", "", ", Remark :" & TxtRemark.Text))
                FastQuery = FastQuery & IIf(FastQuery <> "", " UNION ALL SELECT ", " SELECT ") & Val(txtID.Text) & ",'" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "','" & Me.Text & "'," & Val(txtModeID.Text) & ",'" & txtMode.Text & "'," & Val(txtTotalAmount.Text) & ",'D' ,'" & Remark2 & IIf(TxtRemark.Text = "", "", ", Remark :" & TxtRemark.Text) & "','" & txtAccount.Text & "','" & RemarkHindi & IIf(TxtRemark.Text = "", "", ", Remark :" & TxtRemark.Text) & "'"
            End If
        End If
        If FastQuery = String.Empty Then Exit Sub
        clsFun.FastReceipt(FastQuery)
    End Sub
    Private Sub print()
        PrintRecord()
        If clsFun.ExecScalarStr("Select RecPrint from Option5 ") = "D" Then
            Report_Viewer.printReport("\Trans.rpt")
            Report_Viewer.MdiParent = MainScreenForm
            Report_Viewer.Show()
            If Not Report_Viewer Is Nothing Then
                Report_Viewer.BringToFront()
            End If
        Else
            Report_Viewer.printReport("\Trans.rpt")
            Report_Viewer.MdiParent = MainScreenForm
            Report_Viewer.Show()
            If Not Report_Viewer Is Nothing Then
                Report_Viewer.BringToFront()
            End If
        End If

    End Sub
    Private Sub PrintRecord()
        Dim count As Integer = 0
        Dim cmd As New SQLite.SQLiteCommand
        Dim sql As String = ""
        ClsFunPrimary.ExecNonQuery("Delete from printing")
        sql = "insert into printing (D1,M1,M2,M3,P1,P2,P3,P4,P5,P6) values (@1, @2, @3,@4,@5,@6,@7,@8,@9,@10)"
        Try
            cmd = New SQLite.SQLiteCommand(sql, ClsFunPrimary.GetConnection())
            cmd.Parameters.AddWithValue("@1", mskEntryDate.Text)
            cmd.Parameters.AddWithValue("@2", Me.Text)
            cmd.Parameters.AddWithValue("@3", txtMode.Text)
            cmd.Parameters.AddWithValue("@4", txtAccount.Text)
            cmd.Parameters.AddWithValue("@5", txtReciveAmount.Text)
            cmd.Parameters.AddWithValue("@6", txtDiscountAmount.Text)
            cmd.Parameters.AddWithValue("@7", txtTotalAmount.Text)
            cmd.Parameters.AddWithValue("@8", TxtRemark.Text)
            cmd.Parameters.AddWithValue("@9", txtReciptNo.Text)
            cmd.Parameters.AddWithValue("@10", lblInword.Text)
            If cmd.ExecuteNonQuery() > 0 Then

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            ClsFunPrimary.CloseConnection()
        End Try
    End Sub

    Private Sub Delete()
        If Val(txtID.Text) = 0 Then Exit Sub
        Try
            If MessageBox.Show("Are You Sure want to Delete Receipt No.: " & txtReciptNo.Text & ", account Name : " & txtAccount.Text & ",Total Amount : " & txtTotalAmount.Text & " ??", "Delete Confirmation...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If clsFun.ExecNonQuery("DELETE from Ledger WHERE VoucherID=" & Val(txtID.Text) & "; " & _
                                       "DELETE from Vouchers WHERE ID=" & Val(txtID.Text) & "; " & _
                                       "DELETE from Ref WHERE VoucherID=" & Val(txtID.Text) & ";") > 0 Then
                End If
                'MsgBox("Record Deleted Successfully.", vbInformation + vbOKOnly, "Deleted")
                'btnSave.Visible = True
                txtclear() : Me.Alert("Delete Alert", msgAlert.enmType.Delete)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtReciptNo_GotFocus(sender As Object, e As EventArgs) Handles txtReciptNo.GotFocus

        If DgAccountSearch.ColumnCount = 0 Then AccountRowColumns()
        If DgAccountSearch.RowCount = 0 Then retriveAccounts()
        If DgAccountSearch.SelectedRows.Count = 0 Then DgAccountSearch.Visible = True
        'If txtAccount.Text.Trim() <> "" Then
        '    retriveAccounts(" And upper(AccountName) Like upper('" & txtAccount.Text.Trim() & "%')")
        'Else
        '    retriveAccounts()
        'End If
        txtAccountID.Text = Val(DgAccountSearch.SelectedRows(0).Cells(0).Value)
        txtAccount.Text = DgAccountSearch.SelectedRows(0).Cells(1).Value
        lblBBB.Text = DgAccountSearch.SelectedRows(0).Cells(3).Value
        DgAccountSearch.Visible = False : AcBal()
    End Sub

    'If DgAccountSearch.ColumnCount = 0 Then Acco'untRowColumns()
    'If DgAccountSearch.RowCount = 0 Then retriveAccounts()
    'If DgAccountSearch.SelectedRows.Count = 0 Then DgAccountSearch.Visible = True
    'txtAccountID.Text = DgAccountSearch.SelectedRows(0).Cells(0).Value
    'txtAccount.Text = DgAccountSearch.SelectedRows(0).Cells(1).Value
    'lblBBB.Text = DgAccountSearch.SelectedRows(0).Cells(3).Value
    'DgAccountSearch.Visible = False : AcBal()

    Private Sub txtMode_GotFocus(sender As Object, e As EventArgs) Handles txtMode.GotFocus

        If dgMode.ColumnCount = 0 Then ModeColums()
        If dgMode.RowCount = 0 Then RetriveMode()
        If txtMode.Text.Trim() <> "" Then
            RetriveMode(" And upper(AccountName) Like upper('" & txtMode.Text.Trim() & "%')")
        Else
            RetriveMode()
        End If
        If dgMode.SelectedRows.Count = 0 Then dgMode.Visible = True
    End Sub
    Private Sub txtInvoiceID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtInvoiceID.KeyDown
        If e.KeyCode = Keys.Enter Then
            pnlInvoiceID.Visible = False
            txtReciptNo.Focus()
        End If
    End Sub

    Private Sub txtReciveAmount_GotFocus(sender As Object, e As EventArgs) Handles txtReciveAmount.GotFocus
        If txtReciptNo.TabStop = True Then Exit Sub
        ' If txtReciptNo.TabStop = False Then VNumber()
        If DgAccountSearch.ColumnCount = 0 Then AccountRowColumns()
        If DgAccountSearch.RowCount = 0 Then retriveAccounts()
        If DgAccountSearch.SelectedRows.Count = 0 Then DgAccountSearch.Visible = True
        txtAccountID.Text = DgAccountSearch.SelectedRows(0).Cells(0).Value
        txtAccount.Text = DgAccountSearch.SelectedRows(0).Cells(1).Value
        lblBBB.Text = DgAccountSearch.SelectedRows(0).Cells(3).Value
        DgAccountSearch.Visible = False : AcBal()
    End Sub

    Private Sub mskEntryDate_GotFocus(sender As Object, e As EventArgs) Handles mskEntryDate.GotFocus, mskEntryDate.Click
        mskEntryDate.SelectionStart = 0 : mskEntryDate.SelectionLength = Len(mskEntryDate.Text)
    End Sub
    Private Sub mskEntryDate_KeyDown(sender As Object, e As KeyEventArgs) Handles mskEntryDate.KeyDown, txtMode.KeyDown, txtAccount.KeyDown,
        txtReciptNo.KeyDown, txtReciveAmount.KeyDown, txtDiscountAmount.KeyDown, txtTotalAmount.KeyDown
        If txtReciptNo.Focused Then
            If e.KeyCode = Keys.F2 Then
                pnlInvoiceID.Visible = True
                txtInvoiceID.Focus()
            End If
        End If
        If txtMode.Focused Then
            If e.KeyCode = Keys.F3 Then
                CreateAccount.MdiParent = MainScreenForm
                CreateAccount.Show()
                clsFun.FillDropDownList(CreateAccount.cbGroup, "Select ID,GroupName FROM AccountGroup Where ID=12 ", "GroupName", "ID", "")
                If Not CreateAccount Is Nothing Then
                    CreateAccount.BringToFront()
                End If
            End If

            If e.KeyCode = Keys.F1 Then
                If dgMode.SelectedRows.Count = 0 Then Exit Sub
                Dim tmpID As String = dgMode.SelectedRows(0).Cells(0).Value
                CreateAccount.MdiParent = MainScreenForm
                CreateAccount.Show()
                CreateAccount.FillContros(tmpID)
                If Not CreateAccount Is Nothing Then
                    CreateAccount.BringToFront()
                End If
            End If
        End If
        If txtAccount.Focused Then
            If e.KeyCode = Keys.F3 Then
                CreateAccount.MdiParent = MainScreenForm
                CreateAccount.Show()
                clsFun.FillDropDownList(CreateAccount.cbGroup, "Select ID,GroupName FROM AccountGroup", "GroupName", "ID", "")
                If Not CreateAccount Is Nothing Then
                    CreateAccount.BringToFront()
                End If
            End If
            If e.KeyCode = Keys.F1 Then
                Dim tmpID As String = txtAccountID.Text
                CreateAccount.MdiParent = MainScreenForm
                CreateAccount.Show()
                CreateAccount.FillContros(tmpID)
                If Not CreateAccount Is Nothing Then
                    CreateAccount.BringToFront()
                End If
            End If
        End If
        If txtReciveAmount.Focused Then
            If e.KeyCode = Keys.Enter Then
                If lblBBB.Text = "Y" Then
                    RetriveRef()
                    If pnlbbb.Visible = True Then dg2.Focus() : dg2.Rows(0).Cells(5).Selected = True : Exit Sub Else txtDiscountAmount.Focus() : Exit Sub
                Else
                    e.SuppressKeyPress = True
                    ProcessTabKey(True)
                End If
                'Exit Sub
            End If
        End If

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
            e.SuppressKeyPress = True
        End If
        Select Case e.KeyCode
            Case Keys.End
                e.Handled = True
                btnSave.Focus()
        End Select
        If e.KeyCode = Keys.Delete Then
            Delete()
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
    Private Sub ButtonControl()
        For Each b As Button In Me.Controls.OfType(Of Button)()
            If b.Enabled = True Then
                '        b.Text = "&Saving..."
                b.Enabled = False
            Else
                b.Enabled = True
            End If
        Next
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Val(txtModeID.Text) = 0 Then txtMode.Focus() : Exit Sub
        If Val(txtAccountID.Text) = 0 Then txtAccount.Focus() : Exit Sub
        If btnSave.Text = "&Save" Then
            If Val(clsFun.ExecScalarStr("Select count(*) from Vouchers where upper(BillNo)=upper('" & txtReciptNo.Text & "') and TransType='" & Me.Text & "'")) >= 1 And Val(txtReciptNo.Text) <> 0 Then
                MsgBox("Invoice No. Already Exists...", vbCritical.Critical, "Access Denied")
                Vno = clsFun.ExecScalarInt("SELECT InvoiceID AS NumberOfProducts FROM Vouchers WHERE id=(SELECT max(id) FROM Vouchers Where TransType='" & Me.Text & "')")
                txtReciptNo.Text = Vno + 1 : txtInvoiceID.Text = Vno + 1
                txtReciptNo.Focus() : Exit Sub
            End If
        Else
            If Val(clsFun.ExecScalarStr("Select count(*) from Vouchers where upper(BillNo)=upper('" & txtReciptNo.Text & "') and TransType='" & Me.Text & "'")) > 1 And Val(txtReciptNo.Text) <> 0 Then
                MsgBox("Invoice No. Already Exists...", vbCritical.Critical, "Access Denied")
                Vno = clsFun.ExecScalarInt("SELECT InvoiceID AS NumberOfProducts FROM Vouchers WHERE id=(SELECT max(id) FROM Vouchers Where TransType='" & Me.Text & "')")
                txtReciptNo.Text = Vno + 1 : txtInvoiceID.Text = Vno + 1
                txtReciptNo.Focus() : Exit Sub
            End If
        End If
        If btnSave.Text = "&Save" Then
            If clsFun.ExecScalarStr("Select count(*) from Vouchers where BillNo='" & txtReciptNo.Text & "' and TransType='" & Me.Text & "'") = 1 Then
                MsgBox("Invoice  Already Exists...", vbCritical + vbOKOnly, "Access Denied")
                txtReciptNo.Focus() : Exit Sub
            End If
            ButtonControl() : save() : ButtonControl()
        Else
            ButtonControl() : UpdateReciept() : ButtonControl()
        End If
        '  MainScreenPicture.lblTotRecieptamt.Text = Format(Val(clsFun.ExecScalarStr("Select Sum(TotalAmount) from Vouchers Where TransType='Receipt' And EntryDate='" & CDate(Date.Now).ToString("yyyy-MM-dd") & "'")), "0.00")
        ' MainScreenPicture.lblTotReciept.Text = Val(clsFun.ExecScalarStr("Select Count(*) from Vouchers Where TransType='Receipt' And EntryDate='" & CDate(Date.Now).ToString("yyyy-MM-dd") & "'"))
    End Sub
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")> <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2123:OverrideLinkDemandsShouldBeIdenticalToBase")> Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If dg2.Visible = False Then Exit Function
        Dim icolumn As Integer = dg2.CurrentCell.ColumnIndex
        Dim irow As Integer = dg2.CurrentCell.RowIndex
        Dim i As Integer = irow
        If keyData = Keys.Enter Then
            If irow = dg2.Rows.Count - 1 Then
                If notlastColumn = True Then
                    dg2.CurrentCell = dg2.Rows(i).Cells(3)
                End If
                If dg2.CurrentRow.Index = Val(dg2.Rows.Count - 1) Then
                    dg2.EndEdit()
                    If Val(dg2.CurrentRow.Cells(4).Value) < Val(dg2.CurrentRow.Cells(5).Value) Then MsgBox("Amount Can't be Upto : " & dg2.CurrentRow.Cells(4).Value & "", vbCritical.Critical, "Check Amount") : dg2.CurrentRow.Cells(5).Selected = True : Exit Function
                    dg2.CurrentRow.Cells(6).Value = Format(Val(dg2.CurrentRow.Cells(4).Value) - Val(dg2.CurrentRow.Cells(5).Value), "0.00")
                    calcRef() : If Val(lblAdjustAmoount.Text) <> Val(txtTotalAmount.Text) Then MsgBox("please Check Adjusted Amount", vbCritical.Critical, "Check Amount") : Exit Function
                    pnlbbb.Visible = False : txtDiscountAmount.Focus()
                    ' dg2.Rows.Add("0.00", "0.00")
                    Exit Function
                End If
                dg2.CurrentCell = dg2(3, irow + 1)
            Else
                dg2.EndEdit()
                If Val(dg2.CurrentRow.Cells(4).Value) < Val(dg2.CurrentRow.Cells(5).Value) Then MsgBox("Amount Can't be Upto : " & dg2.CurrentRow.Cells(4).Value & "", vbCritical.Critical, "Check Amount") : dg2.CurrentRow.Cells(5).Selected = True : Exit Function
                dg2.CurrentRow.Cells(6).Value = Format(Val(dg2.CurrentRow.Cells(4).Value) - Val(dg2.CurrentRow.Cells(5).Value), "0.00")
                calcRef() : dg2.CurrentCell = dg2(5, irow + 1)
            End If
            Return True
        Else
            Return MyBase.ProcessCmdKey(msg, keyData)
        End If
    End Function
    Private Sub dg1_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dg2.CurrentCellDirtyStateChanged
        If dg2.CurrentCell.ColumnIndex = 1 AndAlso dg2.IsCurrentCellDirty Then
            dg2.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub dg2_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs)
        If Not dg2.Rows(e.RowIndex).Cells(5).Value Is Nothing Then
            If Not IsNumeric(dg2.Rows(e.RowIndex).Cells(5).Value) Then
                MessageBox.Show("Enter Numeric value only", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub dg2_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dg2.CellEndEdit

        calcRef()
    End Sub


    Private Sub dg2_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dg2.CurrentCellDirtyStateChanged
        'If dg2.CurrentCell.ColumnIndex = 1 AndAlso dg2.IsCurrentCellDirty Then
        '    dg2.CommitEdit(DataGridViewDataErrorContexts.Commit)
        'End If
    End Sub


    Private Sub txtReciveAmount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtReciveAmount.KeyPress, txtDiscountAmount.KeyPress, txtTotalAmount.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8 Or ((e.KeyChar = ".") And (sender.Text.IndexOf(".") = -1)))
    End Sub
    Private Sub calculation()
        If String.IsNullOrEmpty(txtReciveAmount.Text) OrElse String.IsNullOrEmpty(txtDiscountAmount.Text) Then Exit Sub
        txtTotalAmount.Text = Format(Val(txtReciveAmount.Text), "0.00") - Format(Val(txtDiscountAmount.Text), "0.00")
    End Sub

    Private Sub txtDiscountAmount_Leave(sender As Object, e As EventArgs) Handles txtDiscountAmount.Leave
        If txtDiscountAmount.Text = "" Then txtDiscountAmount.Text = "0"
    End Sub


    Private Sub txtReciveAmount_Leave(sender As Object, e As EventArgs) Handles txtReciveAmount.Leave
        'RetriveRef()
        If txtReciveAmount.Text = "" Then txtReciveAmount.Text = Format(Val(txtReciveAmount.Text), "0.00")
        If txtDiscountAmount.Text = "" Then txtDiscountAmount.Text = Format(Val(txtDiscountAmount.Text), "0.00")
    End Sub
    Private Sub txtReciveAmount_TextChanged(sender As Object, e As EventArgs) Handles txtReciveAmount.TextChanged, txtDiscountAmount.TextChanged, txtTotalAmount.TextChanged
        calculation()
        Try
            lblInword.Text = AmtInWord(txtTotalAmount.Text)
        Catch ex As Exception
            lblInword.Text = ex.ToString
        End Try
    End Sub
    Private Sub dg1_KeyDown(sender As Object, e As KeyEventArgs) Handles dg1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dg1.RowCount = 0 Then
                Exit Sub
            End If
            FillControls(dg1.SelectedRows(0).Cells(0).Value)
            mskEntryDate.Focus()
            e.SuppressKeyPress = True
        End If

    End Sub

    Private Sub dg1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dg1.MouseDoubleClick
        If dg1.SelectedRows.Count = 0 Then Exit Sub
        FillControls(Val(dg1.SelectedRows(0).Cells(0).Value))
        mskEntryDate.Focus()
    End Sub
    Private Sub TxtRemark_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtRemark.KeyDown
        If e.KeyCode = Keys.Enter Then btnSave.Focus()
    End Sub

    Private Sub mskEntryDate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mskEntryDate.Validating
        mskEntryDate.Text = clsFun.convdate(mskEntryDate.Text)
        If dg1.RowCount = 0 Then
            retrive()
        End If
    End Sub

    Private Sub txtMode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMode.KeyDown
        If e.KeyCode = Keys.Down Then dgMode.Focus()
        If e.KeyCode = Keys.F3 Then
            CreateAccount.MdiParent = MainScreenForm
            CreateAccount.Show()
            clsFun.FillDropDownList(CreateAccount.cbGroup, "Select ID,GroupName FROM AccountGroup Where  ID=12", "GroupName", "ID", "")
            If Not CreateAccount Is Nothing Then
                CreateAccount.BringToFront()
            End If
        End If
        If e.KeyCode = Keys.F1 Then
            If dgMode.SelectedRows.Count = 0 Then Exit Sub
            Dim tmpAcID As Integer = dgMode.SelectedRows(0).Cells(0).Value
            CreateAccount.MdiParent = MainScreenForm
            CreateAccount.Show()
            CreateAccount.FillContros(tmpAcID)
            If Not CreateAccount Is Nothing Then
                CreateAccount.BringToFront()
            End If
        End If
    End Sub

    Private Sub txtMode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMode.KeyPress
        dgMode.Visible = True
    End Sub

    Private Sub txtMode_KeyUp(sender As Object, e As KeyEventArgs) Handles txtMode.KeyUp
        If txtMode.Text.Trim() <> "" Then
            dgMode.Visible = True
            RetriveMode(" And upper(AccountName) Like upper('" & txtMode.Text.Trim() & "%')")
        Else
            RetriveMode()
        End If
        If e.KeyCode = Keys.Escape Then dgMode.Visible = False
    End Sub


    Private Sub txtAccount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAccount.KeyPress
        DgAccountSearch.Visible = True
    End Sub

    Private Sub txtAccount_KeyUp(sender As Object, e As KeyEventArgs) Handles txtAccount.KeyUp
        If txtAccount.Text.Trim() <> "" Then
            retriveAccounts(" And upper(accountname) Like upper('" & txtAccount.Text.Trim() & "%')")
        Else
            retriveAccounts()
        End If
        If e.KeyCode = Keys.Escape Then DgAccountSearch.Visible = False
    End Sub

    Private Sub txtReciptNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtReciptNo.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8 Or ((e.KeyChar = ".") And (sender.Text.IndexOf(".") = -1)))
    End Sub


    Private Sub txtReciptNo_Leave(sender As Object, e As EventArgs) Handles txtReciptNo.Leave
        'If btnSave.Text = "&Save" Then
        '    If clsFun.ExecScalarStr("Select count(*)from Vouchers where TransType='Receipt' and  BillNo='" & Val(txtReciptNo.Text) & "'") >= 1 Then
        '        MsgBox("Receipt Already Exists...", vbCritical + vbOKOnly, "Access Denied")
        '        txtReciptNo.Focus() : txtReciptNo.Text = Val(txtReciptNo.Text) + 1
        '    End If
        'End If
    End Sub



    Private Sub txtAccount_TextChanged(sender As Object, e As EventArgs) Handles txtAccount.TextChanged

    End Sub

    Private Sub DgAccountSearch_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgAccountSearch.CellContentClick

    End Sub

    Private Sub dgMode_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgMode.CellContentClick

    End Sub

    Private Sub TxtRemark_TextChanged(sender As Object, e As EventArgs) Handles TxtRemark.TextChanged

    End Sub

    Private Sub mskEntryDate_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles mskEntryDate.MaskInputRejected

    End Sub

    Private Sub btnClose_Click_1(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub retriveNext()
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("Select * FROM Vouchers WHERE EntryDate = (Select Date('" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "','+1 day')) and transtype='" & Me.Text & "' Order by ID Desc")
        'dt = clsFun.ExecDataTable("Select * from Vouchers where TransType= '" & Me.Text & "'and EntryDate='" & mskEntryDate.Text & "'")
        dg1.Rows.Clear()
        If dt.Rows.Count = 0 Then
            Dim NextDate As String = clsFun.ExecScalarStr("Select EntryDate FROM Vouchers WHERE EntryDate >'" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "' and transtype='" & Me.Text & "' limit 1")
            If NextDate = "" Then MsgBox("No More Record Found", vbCritical.Critical, "Record Ended") : Exit Sub
            dt = clsFun.ExecDataTable("Select * FROM Vouchers WHERE EntryDate ='" & CDate(NextDate).ToString("yyyy-MM-dd") & "' and transtype='" & Me.Text & "' Order by ID Desc")
        End If
        Try
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("id").ToString()
                        .Cells(1).Value = Format(dt.Rows(i)("Entrydate"), "dd-MM-yyyy")
                        .Cells(2).Value = dt.Rows(i)("Sellername").ToString()
                        .Cells(4).Value = dt.Rows(i)("BillNo").ToString()
                        .Cells(3).Value = dt.Rows(i)("AccountName").ToString()
                        .Cells(5).Value = Format(Val(dt.Rows(i)("BasicAmount").ToString()), "0.00")
                        .Cells(6).Value = Format(Val(dt.Rows(i)("DiscountAmount").ToString()), "0.00")
                        .Cells(7).Value = Format(Val(dt.Rows(i)("TotalAmount").ToString()), "0.00")
                        .Cells(5).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Cells(6).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Cells(7).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Cells(8).Value = dt.Rows(i)("Remark").ToString()
                        mskEntryDate.Text = Format(dt.Rows(i)("Entrydate"), "dd-MM-yyyy")
                    End With
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "AADHAT")
        End Try

        calc() : dg1.ClearSelection()
    End Sub

    Private Sub retrivePrev()
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("Select * FROM Vouchers WHERE EntryDate = (Select Date('" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "','-1 day')) and transtype='" & Me.Text & "' Order by ID Desc")
        'dt = clsFun.ExecDataTable("Select * from Vouchers where TransType= '" & Me.Text & "'and EntryDate='" & mskEntryDate.Text & "'")
        dg1.Rows.Clear()
        If dt.Rows.Count = 0 Then
            Dim NextDate As String = clsFun.ExecScalarStr("Select EntryDate FROM Vouchers WHERE EntryDate <'" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "' and transtype='" & Me.Text & "' limit 1")
            If NextDate = "" Then MsgBox("No More Record Found", vbCritical.Critical, "Record Ended") : Exit Sub
            dt = clsFun.ExecDataTable("Select * FROM Vouchers WHERE EntryDate ='" & CDate(NextDate).ToString("yyyy-MM-dd") & "' and transtype='" & Me.Text & "' Order by ID Desc")
        End If
        Try
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("id").ToString()
                        .Cells(1).Value = Format(dt.Rows(i)("Entrydate"), "dd-MM-yyyy")
                        .Cells(2).Value = dt.Rows(i)("Sellername").ToString()
                        .Cells(4).Value = dt.Rows(i)("BillNo").ToString()
                        .Cells(3).Value = dt.Rows(i)("AccountName").ToString()
                        .Cells(5).Value = Format(Val(dt.Rows(i)("BasicAmount").ToString()), "0.00")
                        .Cells(6).Value = Format(Val(dt.Rows(i)("DiscountAmount").ToString()), "0.00")
                        .Cells(7).Value = Format(Val(dt.Rows(i)("TotalAmount").ToString()), "0.00")
                        .Cells(5).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Cells(6).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Cells(7).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Cells(8).Value = dt.Rows(i)("Remark").ToString()
                        mskEntryDate.Text = Format(dt.Rows(i)("Entrydate"), "dd-MM-yyyy")
                    End With
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "AADHAT")
        End Try

        calc() : dg1.ClearSelection()
    End Sub

    Private Sub retriveFirst()
        Dim dt As New DataTable
        Dim NextDate As String = clsFun.ExecScalarStr("Select EntryDate FROM Vouchers WHERE transtype='" & Me.Text & "' Order by EntryDate limit 1")
        '  dt = clsFun.ExecDataTable("Select * FROM Vouchers WHERE EntryDate = (Select Date('" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "','-1 day')) and transtype='" & Me.Text & "' Order by ID Desc")
        dt = clsFun.ExecDataTable("Select * from Vouchers where TransType= '" & Me.Text & "'and EntryDate='" & CDate(NextDate).ToString("yyyy-MM-dd") & "' Order By ID")
        dg1.Rows.Clear()
        'If dt.Rows.Count = 0 Then
        '    Dim NextDate As String = clsFun.ExecScalarStr("Select EntryDate FROM Vouchers WHERE EntryDate >'" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "' and transtype='" & Me.Text & "' limit 1")
        '    If NextDate = "" Then MsgBox("No More Record Found", vbCritical.Critical, "Record Ended") : Exit Sub
        '    dt = clsFun.ExecDataTable("Select * FROM Vouchers WHERE EntryDate ='" & CDate(NextDate).ToString("yyyy-MM-dd") & "' and transtype='" & Me.Text & "' Order by ID Desc")
        'End If
        Try
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("id").ToString()
                        .Cells(1).Value = Format(dt.Rows(i)("Entrydate"), "dd-MM-yyyy")
                        .Cells(2).Value = dt.Rows(i)("Sellername").ToString()
                        .Cells(4).Value = dt.Rows(i)("BillNo").ToString()
                        .Cells(3).Value = dt.Rows(i)("AccountName").ToString()
                        .Cells(5).Value = Format(Val(dt.Rows(i)("BasicAmount").ToString()), "0.00")
                        .Cells(6).Value = Format(Val(dt.Rows(i)("DiscountAmount").ToString()), "0.00")
                        .Cells(7).Value = Format(Val(dt.Rows(i)("TotalAmount").ToString()), "0.00")
                        .Cells(5).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Cells(6).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Cells(7).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Cells(8).Value = dt.Rows(i)("Remark").ToString()
                        mskEntryDate.Text = Format(dt.Rows(i)("Entrydate"), "dd-MM-yyyy")
                    End With
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "AADHAT")
        End Try

        calc() : dg1.ClearSelection()
    End Sub

    Private Sub retriveLast()
        Dim dt As New DataTable
        Dim NextDate As String = clsFun.ExecScalarStr("Select EntryDate FROM Vouchers WHERE transtype='" & Me.Text & "' Order by EntryDate Desc limit 1")
        '  dt = clsFun.ExecDataTable("Select * FROM Vouchers WHERE EntryDate = (Select Date('" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "','-1 day')) and transtype='" & Me.Text & "' Order by ID Desc")
        dt = clsFun.ExecDataTable("Select * from Vouchers where TransType= '" & Me.Text & "'and EntryDate='" & CDate(NextDate).ToString("yyyy-MM-dd") & "' Order by ID Desc")
        dg1.Rows.Clear()
        'If dt.Rows.Count = 0 Then
        '    Dim NextDate As String = clsFun.ExecScalarStr("Select EntryDate FROM Vouchers WHERE EntryDate >'" & CDate(mskEntryDate.Text).ToString("yyyy-MM-dd") & "' and transtype='" & Me.Text & "' limit 1")
        '    If NextDate = "" Then MsgBox("No More Record Found", vbCritical.Critical, "Record Ended") : Exit Sub
        '    dt = clsFun.ExecDataTable("Select * FROM Vouchers WHERE EntryDate ='" & CDate(NextDate).ToString("yyyy-MM-dd") & "' and transtype='" & Me.Text & "' Order by ID Desc")
        'End If
        Try
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("id").ToString()
                        .Cells(1).Value = Format(dt.Rows(i)("Entrydate"), "dd-MM-yyyy")
                        .Cells(2).Value = dt.Rows(i)("Sellername").ToString()
                        .Cells(4).Value = dt.Rows(i)("BillNo").ToString()
                        .Cells(3).Value = dt.Rows(i)("AccountName").ToString()
                        .Cells(5).Value = Format(Val(dt.Rows(i)("BasicAmount").ToString()), "0.00")
                        .Cells(6).Value = Format(Val(dt.Rows(i)("DiscountAmount").ToString()), "0.00")
                        .Cells(7).Value = Format(Val(dt.Rows(i)("TotalAmount").ToString()), "0.00")
                        .Cells(5).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Cells(6).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Cells(7).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Cells(8).Value = dt.Rows(i)("Remark").ToString()
                        mskEntryDate.Text = Format(dt.Rows(i)("Entrydate"), "dd-MM-yyyy")
                    End With
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "AADHAT")
        End Try
        calc() : dg1.ClearSelection()
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        retriveNext()
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        retriveLast()
    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        retriveFirst()
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        retrivePrev()
    End Sub


    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        Delete()
    End Sub

    Private Sub dtp1_GotFocus(sender As Object, e As EventArgs) Handles dtp1.GotFocus
        mskEntryDate.Focus()
    End Sub

    Private Sub dtp1_ValueChanged(sender As Object, e As EventArgs) Handles dtp1.ValueChanged
        mskEntryDate.Text = dtp1.Value.ToString("dd-MM-yyyy")
        mskEntryDate.Text = clsFun.convdate(mskEntryDate.Text)
    End Sub

    Private Sub txtReciptNo_TextChanged(sender As Object, e As EventArgs) Handles txtReciptNo.TextChanged

    End Sub
End Class