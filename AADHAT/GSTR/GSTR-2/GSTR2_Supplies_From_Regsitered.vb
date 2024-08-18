Public Class GSTR2_Supplies_From_Regsitered

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
        dg1.ColumnCount = 19
        dg1.Columns(0).Name = "ID" : dg1.Columns(0).Visible = False
        dg1.Columns(1).Name = "GSTN" : dg1.Columns(1).Width = 120
        dg1.Columns(2).Name = "Invoice No" : dg1.Columns(2).Width = 80
        dg1.Columns(3).Name = "Date" : dg1.Columns(3).Width = 70
        dg1.Columns(4).Name = "Value" : dg1.Columns(4).Width = 80
        dg1.Columns(5).Name = "POS" : dg1.Columns(5).Width = 80
        dg1.Columns(6).Name = "Rev.Charges" : dg1.Columns(6).Width = 80
        dg1.Columns(7).Name = "Invoice Type" : dg1.Columns(7).Width = 80
        dg1.Columns(8).Name = "Rate" : dg1.Columns(8).Width = 50
        dg1.Columns(9).Name = "Taxable" : dg1.Columns(9).Width = 60
        dg1.Columns(10).Name = "IGST" : dg1.Columns(10).Width = 50
        dg1.Columns(11).Name = "CGST" : dg1.Columns(11).Width = 50
        dg1.Columns(12).Name = "SGST" : dg1.Columns(12).Width = 50
        dg1.Columns(13).Name = "Cess" : dg1.Columns(13).Width = 50
        dg1.Columns(14).Name = "Eligibilty" : dg1.Columns(14).Width = 50
        dg1.Columns(15).Name = "ITC IGST" : dg1.Columns(15).Width = 80
        dg1.Columns(16).Name = "ITC CGST" : dg1.Columns(16).Width = 80
        dg1.Columns(17).Name = "ITC SGST" : dg1.Columns(17).Width = 80
        dg1.Columns(18).Name = "ITC Cess" : dg1.Columns(18).Width = 80

    End Sub

    Private Sub retrive(Optional ByVal condtion As String = "")
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("SELECT ID,GSTN,EntryDate,InvoiceNo,AccountID,AccountName,AccountType,GstType,Taxper," _
                                  & "sum(TaxableAmt),sum(IGSTamt),sum(CGSTamt),sum(SGSTamt), " _
                                  & "CessPer,sum(CessAmt),TotalValue FROM GST_View WHERE EntryDate Between '" & CDate(Me.mskFromDate.Text).ToString("yyyy-MM-dd") & "' And '" & CDate(MsktoDate.Text).ToString("yyyy-MM-dd") & "' " & condtion & " and TaxableAmt>0 and Gsttype='R' Group by ID,TaxPer Order By EntryDate")
        dg1.Rows.Clear()
        Try
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    dg1.Rows.Add()
                    With dg1.Rows(i)
                        .Cells(0).Value = dt.Rows(i)("id").ToString()
                        .Cells(1).Value = dt.Rows(i)("GSTN").ToString()
                        .Cells(2).Value = dt.Rows(i)("InvoiceNo").ToString()
                        .Cells(3).Value = Format(dt.Rows(i)("EntryDate"), "dd-MMM-yyyy")
                        .Cells(4).Value = dt.Rows(i)("TotalValue").ToString()
                        .Cells(5).Value = clsFun.ExecScalarStr("Select StateCodes || '-' ||StateName From Account_AcGrp Where ID= " & dt.Rows(i)("AccountID").ToString() & "")
                        .Cells(6).Value = "N"
                        .Cells(7).Value = IIf(dt.Rows(i)("GSTType").ToString() = "R", "Regular", "UnRegisterd")
                        .Cells(8).Value = dt.Rows(i)("Taxper").ToString()
                        .Cells(9).Value = Math.Round(Val(dt.Rows(i)("sum(TaxableAmt)").ToString()), 2)
                        .Cells(10).Value = Math.Round(Val(dt.Rows(i)("sum(IGSTamt)").ToString()), 2)
                        .Cells(11).Value = Math.Round(Val(dt.Rows(i)("sum(CGSTamt)").ToString()), 2)
                        .Cells(12).Value = Math.Round(Val(dt.Rows(i)("sum(SGSTAmt)").ToString()), 2)
                        .Cells(13).Value = Math.Round(Val(dt.Rows(i)("sum(CessAmt)").ToString()), 2)
                        .Cells(14).Value = "Inputs"
                        .Cells(15).Value = Math.Round(Val(dt.Rows(i)("sum(IGSTamt)").ToString()), 2)
                        .Cells(16).Value = Math.Round(Val(dt.Rows(i)("sum(CGSTamt)").ToString()), 2)
                        .Cells(17).Value = Math.Round(Val(dt.Rows(i)("sum(SGSTAmt)").ToString()), 2)
                        .Cells(18).Value = Math.Round(Val(dt.Rows(i)("sum(CessAmt)").ToString()), 2)
                    End With
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly + vbInformation, "AADHAT")
        End Try

        calc() : dg1.ClearSelection()
    End Sub
    Sub calc()
        Dim i As Integer
        txtTotIGST.Text = Format(0, "00000.00") : txtTotCGST.Text = Format(0, "00000.00")
        txtTotCess.Text = Format(0, "00000.00") : txtTotSGST.Text = Format(0, "00000.00")
        TxtGrandTotal.Text = Format(0, "00000.00") : txtTaxable.Text = Format(0, "00000.00")
        txtTotITC.Text = Format(0, "00000.00")
        For i = 0 To dg1.Rows.Count - 1
            txtTaxable.Text = Format(Val(txtTaxable.Text) + Val(dg1.Rows(i).Cells(7).Value), "0.00")
            txtTotIGST.Text = Format(Val(txtTotIGST.Text) + Val(dg1.Rows(i).Cells(8).Value), "0.00")
            txtTotCGST.Text = Format(Val(txtTotCGST.Text) + Val(dg1.Rows(i).Cells(9).Value), "0.00")
            txtTotSGST.Text = Format(Val(txtTotSGST.Text) + Val(dg1.Rows(i).Cells(10).Value), "0.00")
            txtTotCess.Text = Format(Val(txtTotCess.Text) + Val(dg1.Rows(i).Cells(11).Value), "0.00")
            txtTotITC.Text = Format(Val(txtTotITC.Text) + Val(dg1.Rows(i).Cells(13).Value) + Val(dg1.Rows(i).Cells(14).Value) + Val(dg1.Rows(i).Cells(15).Value) + Val(dg1.Rows(i).Cells(16).Value), "0.00")
        Next
    End Sub
    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        retrive()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class