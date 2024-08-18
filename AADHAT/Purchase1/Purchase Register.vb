Public Class Purchase_Register

    Private Sub dg1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        If dg1.SelectedRows.Count = 0 Then Exit Sub
        Dim tmpID As String = Val(dg1.SelectedRows(0).Cells(0).Value)
        Purchase.MdiParent = MainScreenForm
        Purchase.Show()
        ' Purchase.FillControls(tmpID)
        If Not Purchase Is Nothing Then
            Purchase.BringToFront()
        End If
    End Sub
    Private Sub dg1_MouseClick(sender As Object, e As MouseEventArgs)
        dg1.ClearSelection()
    End Sub

    Private Sub Purchase_Register_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub
    Private Sub Purchase_Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0.5
        Me.Left = 179
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.BackColor = Color.DarkTurquoise
        Me.KeyPreview = True
        Dim mindate, maxdate As String
        mindate = clsFun.ExecScalarStr("select Max(EntryDate) as entrydate from Vouchers where  transtype='" & Me.Text & "'")
        maxdate = clsFun.ExecScalarStr("select Max(EntryDate) as entrydate from Vouchers where  transtype='" & Me.Text & "'")
        If mindate <> "" Then
            mskFromDate.Text = CDate(mindate).ToString("dd-MM-yyyy")
        Else
            mskFromDate.Text = Date.Today.ToString("dd-MM-yyyy")
        End If
        If maxdate <> "" Then
            MsktoDate.Text = CDate(maxdate).ToString("dd-MM-yyyy")
        Else
            MsktoDate.Text = Date.Today.ToString("dd-MM-yyyy")
        End If
        mskFromDate.Focus()
        rowColums()
    End Sub
    Private Sub mskFromDate_GotFocus(sender As Object, e As EventArgs) Handles mskFromDate.GotFocus
        clsFun.selectmskTextbox(mskFromDate)
    End Sub
    Private Sub mskFromDate_KeyDown(sender As Object, e As KeyEventArgs) Handles mskFromDate.KeyDown, MsktoDate.KeyDown, btnShow.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            ProcessTabKey(True)
        End If
    End Sub

    Private Sub mskFromDate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mskFromDate.Validating
        mskFromDate.Text = clsFun.convdate(mskFromDate.Text)
    End Sub

    Private Sub MsktoDate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MsktoDate.Validating
        MsktoDate.Text = clsFun.convdate(MsktoDate.Text)
    End Sub
    Private Sub rowColums()
        dg1.ColumnCount = 15
        dg1.Columns(0).Name = "ID" : dg1.Columns(0).Visible = False
        dg1.Columns(1).Name = "Date" : dg1.Columns(1).Width = 70
        dg1.Columns(2).Name = "Bill No" : dg1.Columns(2).Width = 50
        dg1.Columns(3).Name = "Account Name" : dg1.Columns(3).Width = 180
        dg1.Columns(4).Name = "S.N." : dg1.Columns(4).Width = 30
        dg1.Columns(5).Name = "Item Name" : dg1.Columns(5).Width = 130
        dg1.Columns(6).Name = "Qty" : dg1.Columns(6).Width = 40
        dg1.Columns(7).Name = "Rate" : dg1.Columns(7).Width = 50
        dg1.Columns(8).Name = "Basic" : dg1.Columns(8).Width = 60
        dg1.Columns(9).Name = "Disc" : dg1.Columns(9).Width = 40
        dg1.Columns(10).Name = "Taxable" : dg1.Columns(10).Width = 60
        dg1.Columns(11).Name = "Tax" : dg1.Columns(11).Width = 60
        dg1.Columns(12).Name = "Charges" : dg1.Columns(12).Width = 60
        dg1.Columns(13).Name = "R.Off" : dg1.Columns(13).Width = 50
        dg1.Columns(14).Name = "Total" : dg1.Columns(14).Width = 80

    End Sub
    Sub calc()
        Dim i As Integer
        txtTotBasic.Text = Format(0, "00000.00") : txtTotDisc.Text = Format(0, "00000.00")
        txtTotCharges.Text = Format(0, "00000.00") : txtTotTax.Text = Format(0, "00000.00")
        TxtGrandTotal.Text = Format(0, "00000.00") : txtTaxable.Text = Format(0, "00000.00")
        txtTotRoundOff.Text = Format(0, "00000.00")
        For i = 0 To dg1.Rows.Count - 1
            txtTotBasic.Text = Format(Val(txtTotBasic.Text) + Val(dg1.Rows(i).Cells(8).Value), "0.00")
            txtTotDisc.Text = Format(Val(txtTotDisc.Text) + Val(dg1.Rows(i).Cells(9).Value), "0.00")
            txtTaxable.Text = Format(Val(txtTaxable.Text) + Val(dg1.Rows(i).Cells(10).Value), "0.00")
            txtTotTax.Text = Format(Val(txtTotTax.Text) + Val(dg1.Rows(i).Cells(11).Value), "0.00")
            txtTotCharges.Text = Format(Val(txtTotCharges.Text) + Val(dg1.Rows(i).Cells(12).Value), "0.00")
            txtTotRoundOff.Text = Format(Val(txtTotRoundOff.Text) + Val(dg1.Rows(i).Cells(13).Value), "0.00")
            TxtGrandTotal.Text = Format(Val(TxtGrandTotal.Text) + Val(dg1.Rows(i).Cells(14).Value), "0.00")
        Next
    End Sub
    Private Sub retrive(Optional ByVal condtion As String = "")
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("Select * from Trans_View Where EntryDate Between '" & CDate(mskFromDate.Text).ToString("yyyy-MM-dd") & "' And '" & CDate(MsktoDate.Text).ToString("yyyy-MM-dd") & "' and transtype='" & Me.Text & "' " & condtion & "  order by ID ")
        Dim vchid As Integer = 0
        Try
            If dt.Rows.Count > 0 Then
                dg1.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("ID").ToString()
                        If i = 0 Then
                            .Cells(1).Value = Format(dt.Rows(i)("EntryDate"), "dd-MM-yyyy")
                            .Cells(2).Value = dt.Rows(i)("InvoiceNo").ToString()
                            .Cells(3).Value = dt.Rows(i)("AccountName").ToString()
                            .Cells(12).Value = Format(Val(dt.Rows(i)("TotalCharges").ToString()), "0.00")
                            .Cells(13).Value = Format(Val(dt.Rows(i)("RoundOff").ToString()), "0.00")
                            .Cells(14).Value = Format(Val(dt.Rows(i)("TotalGrandAmt").ToString()), "0.00")
                        ElseIf vchid = dt.Rows(i)("ID").ToString() Then
                            .Cells(1).Value = ""
                            .Cells(2).Value = ""
                            .Cells(3).Value = ""
                            .Cells(12).Value = ""
                            .Cells(13).Value = ""
                            .Cells(14).Value = ""
                        Else
                            .Cells(1).Value = Format(dt.Rows(i)("EntryDate"), "dd-MM-yyyy")
                            .Cells(2).Value = dt.Rows(i)("InvoiceNo").ToString()
                            .Cells(3).Value = dt.Rows(i)("AccountName").ToString()
                            .Cells(12).Value = Format(Val(dt.Rows(i)("TotalCharges").ToString()), "0.00")
                            .Cells(13).Value = Format(Val(dt.Rows(i)("RoundOff").ToString()), "0.00")
                            .Cells(14).Value = Format(Val(dt.Rows(i)("TotalGrandAmt").ToString()), "0.00")
                        End If
                        .Cells(4).Value = dt.Rows(i)("Sno").ToString()
                        .Cells(5).Value = dt.Rows(i)("ItemName").ToString()
                        .Cells(6).Value = Format(Val(dt.Rows(i)("Qty").ToString()), "0.00")
                        .Cells(7).Value = Format(Val(dt.Rows(i)("Rate").ToString()), "0.00")
                        .Cells(8).Value = Format(Val(dt.Rows(i)("BasicAmt").ToString()), "0.00")
                        .Cells(9).Value = Format(Val(dt.Rows(i)("DisAmt").ToString()), "0.00")
                        .Cells(10).Value = Format(Val(dt.Rows(i)("TaxableAmt").ToString()), "0.00")
                        .Cells(11).Value = Format(Val(dt.Rows(i)("TaxAmt").ToString()), "0.00")
                    End With
                    vchid = dt.Rows(i)("ID").ToString()
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "AADHAT")
        End Try
        dg1.ClearSelection() : calc()
        'lblTotal.Visible = True
        'lblTotal.Text = "POS Bills : " & Val(dg1.RowCount)
    End Sub
    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        retrive()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    
    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub dg1_KeyDown(sender As Object, e As KeyEventArgs) Handles dg1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dg1.RowCount = 0 Then Exit Sub
            Dim tmpID As String = dg1.SelectedRows(0).Cells(0).Value
            Purchase.MdiParent = MainScreenForm
            Purchase.Show()
            Purchase.FillControls(tmpID)
            If Not Purchase Is Nothing Then
                Purchase.BringToFront()
            End If
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub dg1_MouseClick1(sender As Object, e As MouseEventArgs) Handles dg1.MouseClick
        dg1.ClearSelection()
    End Sub

    Private Sub dg1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dg1.MouseDoubleClick
        Dim tmpID As String = dg1.SelectedRows(0).Cells(0).Value
        Purchase.MdiParent = MainScreenForm
        Purchase.Show()
        Purchase.FillControls(tmpID)
        If Not Purchase Is Nothing Then
            Purchase.BringToFront()
        End If
    End Sub
End Class