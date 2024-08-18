Public Class GSTR2_Supplies_From_Unregsiter

    Private Sub GSTR2_Supplies_From_Unregsiter_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()

    End Sub

    Private Sub GSTR2_Supplies_From_Unregsiter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0.5
        Me.Left = 179
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.BackColor = Color.DarkTurquoise
        Me.KeyPreview = True
        Dim mindate, maxdate As String
        mindate = clsFun.ExecScalarStr("select Max(EntryDate) as entrydate from GST_View ")
        maxdate = clsFun.ExecScalarStr("select Max(EntryDate) as entrydate from GST_View ")
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
    Private Sub rowColums()
        dg1.ColumnCount = 16
        dg1.Columns(0).Name = "ID" : dg1.Columns(0).Visible = False
        dg1.Columns(1).Name = "Date" : dg1.Columns(1).Width = 70
        dg1.Columns(2).Name = "Invoice No" : dg1.Columns(2).Width = 80
        dg1.Columns(3).Name = "Account Name" : dg1.Columns(3).Width = 180
        dg1.Columns(4).Name = "Type" : dg1.Columns(4).Width = 80
        dg1.Columns(5).Name = "Rate" : dg1.Columns(5).Width = 50
        dg1.Columns(6).Name = "Taxable amt" : dg1.Columns(6).Width = 80
        dg1.Columns(7).Name = "IGST" : dg1.Columns(7).Width = 80
        dg1.Columns(8).Name = "CGST" : dg1.Columns(8).Width = 80
        dg1.Columns(9).Name = "SGST" : dg1.Columns(9).Width = 80
        dg1.Columns(10).Name = "Cess" : dg1.Columns(10).Width = 80
        dg1.Columns(11).Name = "Value" : dg1.Columns(11).Width = 100
        dg1.Columns(12).Name = "IGST" : dg1.Columns(12).Width = 80
        dg1.Columns(13).Name = "CGST" : dg1.Columns(13).Width = 80
        dg1.Columns(14).Name = "SGST" : dg1.Columns(14).Width = 80
        dg1.Columns(15).Name = "Cess" : dg1.Columns(15).Width = 80

    End Sub

    Private Sub retrive(Optional ByVal condtion As String = "")
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("SELECT ID,EntryDate,InvoiceNo,AccountName,AccountType,Taxper," _
                                  & "sum(TaxableAmt),sum(IGSTamt),sum(CGSTamt),sum(SGSTamt), " _
                                  & "CessPer,sum(CessAmt),TotalValue FROM GST_View WHERE EntryDate Between '" & CDate(Me.mskFromDate.Text).ToString("yyyy-MM-dd") & "' And '" & CDate(MsktoDate.Text).ToString("yyyy-MM-dd") & "' " & condtion & " and Gsttype='U' Group by ID,TaxPer Order By EntryDate")
        dg1.Rows.Clear()
        Try
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("id").ToString()
                        .Cells(1).Value = Format(dt.Rows(i)("EntryDate"), "dd-MM-yyyy")
                        .Cells(2).Value = dt.Rows(i)("InvoiceNo").ToString()
                        .Cells(3).Value = dt.Rows(i)("AccountName").ToString()
                        .Cells(4).Value = IIf(dt.Rows(i)("AccountType").ToString() = "L", "Intra-State", "Interstate")
                        .Cells(5).Value = dt.Rows(i)("Taxper").ToString()
                        .Cells(6).Value = Math.Round(Val(dt.Rows(i)("sum(TaxableAmt)").ToString()), 2)
                        .Cells(7).Value = Math.Round(Val(dt.Rows(i)("sum(IGSTamt)").ToString()), 2)
                        .Cells(8).Value = Math.Round(Val(dt.Rows(i)("sum(CGSTamt)").ToString()), 2)
                        .Cells(9).Value = Math.Round(Val(dt.Rows(i)("sum(SGSTAmt)").ToString()), 2)
                        .Cells(10).Value = Math.Round(Val(dt.Rows(i)("sum(CessAmt)").ToString()), 2)
                        .Cells(11).Value = dt.Rows(i)("TotalValue").ToString()
                        .Cells(12).Value = Math.Round(Val(dt.Rows(i)("sum(IGSTamt)").ToString()), 2)
                        .Cells(13).Value = Math.Round(Val(dt.Rows(i)("sum(CGSTamt)").ToString()), 2)
                        .Cells(14).Value = Math.Round(Val(dt.Rows(i)("sum(SGSTAmt)").ToString()), 2)
                        .Cells(15).Value = Math.Round(Val(dt.Rows(i)("sum(CessAmt)").ToString()), 2)
                    End With
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "AADHAT")
        End Try
        ' calc() : dg1.ClearSelection()
    End Sub

    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        retrive()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class