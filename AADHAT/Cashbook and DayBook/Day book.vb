Imports System.Globalization
Public Class Day_book
    Dim rs As New Resizer
    Dim strSDate As String : Dim strEDate As String
    Dim dDate As DateTime : Dim mskstartDate As String
    Dim mskenddate As String
    Private Sub Day_book_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub mskFromDate_GotFocus(sender As Object, e As EventArgs) Handles mskFromDate.GotFocus, mskFromDate.Click
        mskFromDate.SelectAll()
    End Sub
    Private Sub mskFromDate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mskFromDate.Validating
        mskFromDate.Text = clsFun.convdate(mskFromDate.Text)
    End Sub

    Private Sub MsktoDate_GotFocus(sender As Object, e As EventArgs) Handles MsktoDate.GotFocus, MsktoDate.Click
        MsktoDate.SelectAll()
    End Sub
    Private Sub MsktoDate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MsktoDate.Validating
        MsktoDate.Text = clsFun.convdate(MsktoDate.Text)
    End Sub
    Private Sub Day_book_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0 : Me.Left = 0
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        mskFromDate.Text = Date.Today.ToString("dd-MM-yyyy")
        MsktoDate.Text = Date.Today.ToString("dd-MM-yyyy")
        clsFun.FillDropDownList(Cbper, "SELECT VouchersID,TransType FROM Ledger  Group by TransType", "TransType", "VouchersID", "--All--")
                rowColums()
            End Sub
    Private Sub rowColums()
        dg1.ColumnCount = 7
        dg1.Columns(0).Name = "ID" : dg1.Columns(0).Visible = False
        dg1.Columns(1).Name = "Date" : dg1.Columns(1).Width = 150
        dg1.Columns(2).Name = "Type" : dg1.Columns(2).Width = 150
        dg1.Columns(3).Name = "Account Name" : dg1.Columns(3).Width = 300
        dg1.Columns(4).Name = "Description" : dg1.Columns(4).Width = 300
        dg1.Columns(5).Name = "Debit" : dg1.Columns(5).Width = 135
        dg1.Columns(6).Name = "Credit" : dg1.Columns(6).Width = 135
    End Sub
    Sub calc()
        txtDramt.Text = Format(0, "0.00") : txtcrAmt.Text = Format(0, "0.00")
        Dim i As Integer
        For i = 0 To dg1.Rows.Count - 1
            txtDramt.Text = Format(Val(txtDramt.Text) + Val(dg1.Rows(i).Cells(5).Value), "0.00")
            txtcrAmt.Text = Format(Val(txtcrAmt.Text) + Val(dg1.Rows(i).Cells(6).Value), "0.00")
        Next

    End Sub
    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        retrive()
    End Sub
    Private Sub retrive(Optional ByVal condtion As String = "")
        Dim dt As New DataTable
        Dim ssql As String
        If Cbper.SelectedIndex = 0 Then
            ssql = "SELECT VouchersID,  EntryDate,TransType,AccountName,Remark,Amount as Dr,'' as Cr from Ledger where DC ='D' and EntryDate Between '" & CDate(Me.mskFromDate.Text).ToString("yyyy-MM-dd") & "' And '" & CDate(MsktoDate.Text).ToString("yyyy-MM-dd") & "'  union all" & _
                   " SELECT VouchersID, EntryDate,TransType,AccountName,Remark,'' as Dr,Amount as Cr  from Ledger where Dc='C'  and EntryDate Between '" & CDate(Me.mskFromDate.Text).ToString("yyyy-MM-dd") & "' And '" & CDate(MsktoDate.Text).ToString("yyyy-MM-dd") & "'  "
        Else
            ssql = "SELECT VouchersID,  EntryDate,TransType,AccountName,Remark,Amount as Dr,'' as Cr from Ledger where DC ='D' and EntryDate Between '" & CDate(Me.mskFromDate.Text).ToString("yyyy-MM-dd") & "' And '" & CDate(MsktoDate.Text).ToString("yyyy-MM-dd") & "'  AND TransType='" & Cbper.Text & "' union all" & _
                   " SELECT VouchersID, EntryDate,TransType,AccountName,Remark,'' as Dr,Amount as Cr  from Ledger where Dc='C'  and EntryDate Between '" & CDate(Me.mskFromDate.Text).ToString("yyyy-MM-dd") & "' And '" & CDate(MsktoDate.Text).ToString("yyyy-MM-dd") & "'   AND TransType='" & Cbper.Text & "'  "
        End If
        dt = clsFun.ExecDataTable(ssql)
        If dt.Rows.Count > 20 Then
            dg1.Columns(6).Name = "Credit" : dg1.Columns(6).Width = 115
        Else
            dg1.Columns(6).Name = "Credit" : dg1.Columns(6).Width = 135
        End If
        Dim dvData As DataView = New DataView(dt)
        ' dvData.RowFilter = "EntryDate Between '" & mskFromDate.Text & "' And '" & MsktoDate.Text & "'"
        dvData.Sort = "VouchersID asc"
        dt = dvData.ToTable
        dg1.Rows.Clear()
        Try
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        '   .Cells(0).Value = dt.Rows(i)("id").ToString()
                        '  .Cells(0).Value = i + 1
                        .Cells(0).Value = dt.Rows(i)("VouchersID").ToString()
                        .Cells(1).Value = Format(dt.Rows(i)("EntryDate"), "dd-MM-yyyy")
                        .Cells(2).Value = dt.Rows(i)("TransType").ToString()
                        .Cells(3).Value = dt.Rows(i)("AccountName").ToString()
                        .Cells(4).Value = dt.Rows(i)("Remark").ToString()
                        .Cells(5).Value = IIf(Val(dt.Rows(i)("Dr").ToString()) = "0", "", Format(Val(dt.Rows(i)("Dr").ToString()), "0.00"))
                        .Cells(6).Value = IIf(Val(dt.Rows(i)("Cr").ToString()) = "0", "", Format(Val(dt.Rows(i)("Cr").ToString()), "0.00"))
                        .Cells(5).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Cells(6).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    End With
                Next

            Else
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "AADHAT")
        End Try
        calc() : dg1.ClearSelection()
    End Sub
    Private Sub Day_book_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        rs.ResizeAllControls(Me)
    End Sub

    Private Sub mskFromDate_KeyDown(sender As Object, e As KeyEventArgs) Handles mskFromDate.KeyDown, MsktoDate.KeyDown, Cbper.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            ProcessTabKey(True)
        End If
        Select Case e.KeyCode
            Case Keys.End
                e.Handled = True
                btnShow.Focus()
        End Select
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub save()
        Dim count As Integer = 0
        Dim cmd As New SQLite.SQLiteCommand
        Dim sql As String = ""
        ClsFunPrimary.ExecNonQuery("Delete from printing")
        For Each row As DataGridViewRow In dg1.Rows
            With row
                sql = "insert into Printing(D1,D2,M1,M2, P1, P2,P3, P4, P5, P6) values('" & mskFromDate.Text & "'," & _
                    "'" & MsktoDate.Text & "','" & txtDramt.Text & "','" & txtcrAmt.Text & "'," & _
                    "'" & .Cells("Date").Value & "','" & .Cells("Type").Value & "','" & .Cells("Account Name").Value & "','" & .Cells("Description").Value & "'," & _
                    "'" & Val(.Cells("Debit").Value) & "'," & Val(.Cells("Credit").Value) & ")"
                Try
                    ClsFunPrimary.ExecNonQuery(sql)
                Catch ex As Exception
                    MsgBox(ex.Message)
                    ClsFunPrimary.CloseConnection()
                End Try
            End With
        Next
    End Sub
    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        clsFun.changeCompany()
        save()
        Report_Viewer.MdiParent = MainScreenForm
        Report_Viewer.Show()
        If Not Report_Viewer Is Nothing Then
            Report_Viewer.BringToFront()
        End If
    End Sub
    Private Sub dg1_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Dim id As Integer = dg1.SelectedRows(0).Cells(0).Value
            Dim type As String = dg1.SelectedRows(0).Cells(2).Value
            If type = "Bill" Then
                Food_Bill.MdiParent = MainScreenForm
                Food_Bill.Show()
                Food_Bill.FillControls(id)
                If Not Stock_Sale Is Nothing Then
                    Stock_Sale.BringToFront()
                End If
            ElseIf type = "Reciept" Then
                RecieptForm.MdiParent = MainScreenForm
                RecieptForm.Show()
                RecieptForm.FillControls(id)
                If Not RecieptForm Is Nothing Then
                    RecieptForm.BringToFront()
                End If
            ElseIf type = "Payment" Then
                PayMentform.MdiParent = MainScreenForm
                PayMentform.Show()
                PayMentform.FillControls(id)
                If Not PayMentform Is Nothing Then
                    PayMentform.BringToFront()
                End If
            ElseIf type = "Purchase" Then
                Purchase.MdiParent = MainScreenForm
                Purchase.Show()
                Purchase.FillControl(id)
                If Not Purchase Is Nothing Then
                    Purchase.BringToFront()
                End If
            Else
                Bank_Entry.MdiParent = MainScreenForm
                Bank_Entry.Show()
                Bank_Entry.FillControls(id)
                If Not Bank_Entry Is Nothing Then
                    Bank_Entry.BringToFront()
                End If
            End If
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub dg1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        Dim id As Integer = dg1.SelectedRows(0).Cells(0).Value
        Dim type As String = dg1.SelectedRows(0).Cells(2).Value
        If type = "Bill" Then
            Food_Bill.MdiParent = MainScreenForm
            Food_Bill.Show()
            Food_Bill.FillControls(id)
            If Not Stock_Sale Is Nothing Then
                Stock_Sale.BringToFront()
            End If
        ElseIf type = "Reciept" Then
            RecieptForm.MdiParent = MainScreenForm
            RecieptForm.Show()
            RecieptForm.FillControls(id)
            If Not RecieptForm Is Nothing Then
                RecieptForm.BringToFront()
            End If
        ElseIf type = "Payment" Then
            PayMentform.MdiParent = MainScreenForm
            PayMentform.Show()
            PayMentform.FillControls(id)
            If Not PayMentform Is Nothing Then
                PayMentform.BringToFront()
            End If
        ElseIf type = "Purchase" Then
            Purchase.MdiParent = MainScreenForm
            Purchase.Show()
            Purchase.FillControl(id)
            If Not Purchase Is Nothing Then
                Purchase.BringToFront()
            End If
        Else
            Bank_Entry.MdiParent = MainScreenForm
            Bank_Entry.Show()
            Bank_Entry.FillControls(id)
            If Not Bank_Entry Is Nothing Then
                Bank_Entry.BringToFront()
            End If
        End If
    End Sub

    Private Sub dtp2_GotFocus(sender As Object, e As EventArgs) Handles dtp2.GotFocus
        MsktoDate.Focus()
    End Sub

    Private Sub dtp2_ValueChanged(sender As Object, e As EventArgs) Handles dtp2.ValueChanged
        MsktoDate.Text = dtp2.Value.ToString("dd-MM-yyyy")
        MsktoDate.Text = clsFun.convdate(MsktoDate.Text)
    End Sub

    Private Sub dtp1_GotFocus(sender As Object, e As EventArgs) Handles dtp1.GotFocus
        mskFromDate.Focus()
    End Sub

    Private Sub dtp1_ValueChanged(sender As Object, e As EventArgs) Handles dtp1.ValueChanged
        mskFromDate.Text = dtp1.Value.ToString("dd-MM-yyyy")
        mskFromDate.Text = clsFun.convdate(mskFromDate.Text)
    End Sub
End Class