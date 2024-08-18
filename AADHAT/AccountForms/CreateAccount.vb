Imports System.IO
Imports System.Drawing.Imaging
Public Class CreateAccount
    Dim CustImagePath As String = String.Empty
    Dim GurImagePath As String = String.Empty
    Dim tmpid As Integer = 0
    Dim rs As New Resizer
    Private Sub CreateAccount_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then btnClose.PerformClick()
    End Sub

    Private Sub CreateAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '  rs.FindAllControls(Me)
        Me.Top = 0 : Me.Left = 0
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.BackColor = Color.FromArgb(169, 223, 191)
        clsFun.FillDropDownList(cbGroup, "Select ID,GroupName FROM AccountGroup", "GroupName", "ID", "")
        clsFun.FillDropDownList(cbState, "Select * From StateList", "StateName", "Id", "")
        If BtnSave.Text = "&Save" Then cbState.Text = clsFun.ExecScalarStr("Select State From Company Limit 1")
        txtStateGSTCode.Text = Format(Val(clsFun.ExecScalarStr("Select StateGSTCodes From StateList Where ID='" & Val(cbState.SelectedValue) & "'")), "00")
        clsFun.FillDropDownList(cbCountry, "Select * From Countries", "CountryName", "Id", "")
        cbDrCr.SelectedIndex = 0 : cbGSTtype.SelectedIndex = 0 : cbDefaultPrice.SelectedIndex = 0 : cbGSTApplicable.SelectedIndex = 0
        BtnDelete.Text = "&Reset"
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Public Sub saveImage()
        Dim sJpegPicFileName As String = String.Empty
        FileName = String.Empty
        If Directory.Exists(Application.StartupPath & "\Images") = False Then
            Directory.CreateDirectory(Application.StartupPath & "\Images")
        End If
        If File.Exists(Application.StartupPath & "\Images\" & txtName.Text & ".jpg") = True Then

        End If
        If picCustomer.Image IsNot Nothing Then
            picCustomer.Image.Save(Application.StartupPath & "\Images\" & txtName.Text & ".jpg")
        End If
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If txtGSTN.Text <> "" Then
            If BtnSave.Text = "&Save" Then
                If clsFun.ExecScalarStr("Select count(*) from Accounts where AccountName='" & txtName.Text.Trim & "'") = 1 Then
                    MsgBox("Account Already Exists...", MsgBoxStyle.Critical, "Access Denied")
                    txtName.Focus() : Exit Sub
                End If
                If clsFun.ExecScalarStr("Select count(*) from Accounts where upper(GSTNo)=upper('" & txtGSTN.Text & "')") = 1 Then
                    lbl_Result.ForeColor = Color.Red : txtGSTN.ForeColor = Color.Red
                    lbl_Result.Text = "GST No Already Exists..." : txtGSTN.Focus() : Exit Sub
                End If

            Else
                If clsFun.ExecScalarStr("Select count(*) from Accounts where AccountName='" & txtName.Text.Trim & "'") > 1 Then
                    MsgBox("Account Already Exists...", MsgBoxStyle.Critical, "Access Denied")
                    txtName.Focus() : Exit Sub
                End If
                If clsFun.ExecScalarStr("Select count(*)from Accounts where upper(GSTNo)=upper('" & txtGSTN.Text & "')") > 1 Then
                    lbl_Result.ForeColor = Color.Red : txtGSTN.ForeColor = Color.Red
                    lbl_Result.Text = "GST No Already Exists..." : txtGSTN.Focus() : Exit Sub
                End If
            End If
        End If
        If (cbGSTtype.SelectedIndex = 1 Or cbGSTtype.SelectedIndex = 3) And txtGSTN.Text = "" Then
            lbl_Result.ForeColor = Color.Red : txtGSTN.ForeColor = Color.Red
            lbl_Result.Text = "GSTIN is Empty " : txtGSTN.Focus() : Exit Sub
        End If
        If BtnSave.Text = "&Save" Then
            Save()
        Else
            updateAccount()
        End If
    End Sub
    Private Sub Save()
        If clsFun.ExecScalarStr("Select count(*)from Accounts where upper(AccountName)=upper('" & txtName.Text & "')") = 1 Then
            MsgBox("Account Already Exists...", vbCritical + vbOKOnly, "Access Denied")
            txtName.Focus() : Exit Sub
        End If
        Dim MaintainBillByBill As String = String.Empty
        If ckByB.Checked = True Then MaintainBillByBill = "Y" Else MaintainBillByBill = "N"
        Dim TCS As String = String.Empty
        If ckTCS.Checked = True Then TCS = "Y" Else TCS = "N"
        Dim cmd As SQLite.SQLiteCommand
        Dim CustImageName As String = String.Empty
        Dim GurimageName As String = String.Empty
        If txtName.Text = "" Then
            txtName.Focus()
            MsgBox("Account Name is Blank. Please Fill Account Name... ", MsgBoxStyle.Critical, "Empty")
        ElseIf cbGroup.Text = "" Then
            cbGroup.Focus()
            MsgBox("Account Group is Blank. Please Fill Select Group... ", MsgBoxStyle.Critical, "Empty")
        Else
            Dim sql As String = "insert into Accounts(AccountName, Groupid,  DC, OpBal, OtherName, address, LFNo, Area, City," _
                                & " State, StateCode, PinCode, Mobile1, Mobile2, MailID, BankName, AccNo," _
                                & " IFSC, VatNo, PanNo, CSTNo, DLNo1, DlNo2, AuditUpto,MaintainBillByBill,GSTNo,GSTType,UIDNo,tag, " _
                                & "TCSApplicable,Defaultprice,FixDiscPer,AccountLimit,Contact,PhoneNo,FaxNo,CountryName,CountryID,RCM,GSTApplicable,HSNCode,TaxID,TaxName)" _
                                & "values (@1, @2, @3, @4, @5, @6, @7, @8, @9,@10, @11, @12, @13, @14, @15, @16, @17, @18, @19," _
                                & "@20, @21, @22, @23, @24,@25, @26, @27,@28,@29, @30,@31,@32,@33,@34,@35,@36,@37,@38,@39,@40,@41,@42,@43)"
            Try
                cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
                cmd.Parameters.AddWithValue("@1", txtName.Text.Trim)
                cmd.Parameters.AddWithValue("@2", Val(cbGroup.SelectedValue))
                cmd.Parameters.AddWithValue("@3", cbDrCr.Text)
                cmd.Parameters.AddWithValue("@4", txtOPBal.Text)
                cmd.Parameters.AddWithValue("@5", txtOtherName.Text.Trim)
                cmd.Parameters.AddWithValue("@6", txtAddress.Text)
                cmd.Parameters.AddWithValue("@7", txtLf.Text)
                cmd.Parameters.AddWithValue("@8", txtArea.Text)
                cmd.Parameters.AddWithValue("@9", txtCity.Text)
                cmd.Parameters.AddWithValue("@10", cbState.Text)
                cmd.Parameters.AddWithValue("@11", Val(txtStateGSTCode.Text))
                cmd.Parameters.AddWithValue("@12", txtPinCode.Text)
                cmd.Parameters.AddWithValue("@13", txtMob1.Text)
                cmd.Parameters.AddWithValue("@14", txtMob2.Text)
                cmd.Parameters.AddWithValue("@15", txtMail.Text)
                cmd.Parameters.AddWithValue("@16", txtBank.Text)
                cmd.Parameters.AddWithValue("@17", txtACNo.Text)
                cmd.Parameters.AddWithValue("@18", txtIfsc.Text)
                cmd.Parameters.AddWithValue("@19", txtVATNo.Text)
                cmd.Parameters.AddWithValue("@20", txtPanNo.Text)
                cmd.Parameters.AddWithValue("@21", txtCSTNo.Text)
                cmd.Parameters.AddWithValue("@22", txtDLNo1.Text)
                cmd.Parameters.AddWithValue("@23", txtDLNo2.Text)
                cmd.Parameters.AddWithValue("@24", txtAuditUpto.Text)
                cmd.Parameters.AddWithValue("@25", MaintainBillByBill)
                cmd.Parameters.AddWithValue("@26", txtGSTN.Text)
                cmd.Parameters.AddWithValue("@27", cbGSTtype.Text)
                cmd.Parameters.AddWithValue("@28", txtUIDNo.Text)
                cmd.Parameters.AddWithValue("@29", 1)
                cmd.Parameters.AddWithValue("@30", TCS)
                cmd.Parameters.AddWithValue("@31", cbDefaultPrice.Text)
                cmd.Parameters.AddWithValue("@32", txtFixDis.Text)
                cmd.Parameters.AddWithValue("@33", txtLimit.Text)
                cmd.Parameters.AddWithValue("@34", txtContactName.Text)
                cmd.Parameters.AddWithValue("@35", txtphoneNo.Text)
                cmd.Parameters.AddWithValue("@36", txtFaxNo.Text)
                cmd.Parameters.AddWithValue("@37", cbCountry.Text)
                cmd.Parameters.AddWithValue("@38", Val(cbCountry.SelectedValue))
                cmd.Parameters.AddWithValue("@39", CbRCM.Text)
                cmd.Parameters.AddWithValue("@40", cbGSTApplicable.Text)
                cmd.Parameters.AddWithValue("@41", If(cbGSTApplicable.SelectedIndex = 0, "", txtHSNCode.Text))
                cmd.Parameters.AddWithValue("@42", If(cbGSTApplicable.SelectedIndex = 0, 0, CbTax.SelectedValue))
                cmd.Parameters.AddWithValue("@43", If(cbGSTApplicable.SelectedIndex = 0, "", CbTax.Text))
                If cmd.ExecuteNonQuery() > 0 Then
                    saveImage()
                    '  MsgBox("Record Saved Successfully.", vbInformation + vbOKOnly, "Saved") 'Insert Successfully", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ClearText()
                    MsgBox("Record Saved Successfully.", vbInformation + vbOKOnly, "Saved") 'Insert Successfully", "Successfully", 
                    '   Me.Alert("Success Alert", msgAlert.enmType.Info)
                    'Call clsFun.FillDropDownList(cbGroup, "Select * From AccountGroup", "GroupName", "Id", "")
                End If
                clsFun.CloseConnection()
            Catch ex As Exception
                MsgBox(ex.Message)
                clsFun.CloseConnection()
            End Try
        End If
    End Sub
    'Public Sub Alert(ByVal msg As String, ByVal type As msgAlert.enmType)
    '    Dim frm As msgAlert = New msgAlert()
    '    frm.showAlert(msg, type)
    'End Sub

    Private Sub txtMob2_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            txtMail.Focus()
        End If
    End Sub
    Private Sub ClearText()
        txtName.Text = "" : txtLimit.Text = ""
        cbDrCr.Text = "" : txtOPBal.Text = ""
        txtOtherName.Text = "" : txtLf.Text = ""
        txtAddress.Text = "" : txtArea.Text = ""
        txtCity.Text = "" : cbState.Text = ""
        txtStateGSTCode.Text = "" : txtPinCode.Text = ""
        txtMob1.Text = "" : txtMob2.Text = ""
        txtMail.Text = "" : txtBank.Text = ""
        txtACNo.Text = "" : txtIfsc.Text = ""
        txtVATNo.Text = "" : txtDLNo1.Text = ""
        txtDLNo2.Text = "" : txtAuditUpto.Text = ""
        ckByB.Checked = False
        txtUIDNo.Text = "" : txtGSTN.Text = ""
        '  txtStateGSTCode.Text = "" : cbState.SelectedIndex = 0
        cbGSTtype.SelectedIndex = 0
        txtPanNo.Text = "" : txtCSTNo.Text = ""
        cbState.Text = "" : txtCity.Text = ""
        BtnDelete.Text = "&Reset" : BtnSave.Text = "&Save"
        txtName.Focus() : Account_List.btnRetrive.PerformClick()
        lblName.Text = "CREATE ACCOUNT"
    End Sub
    Public Sub FillContros(ByVal id As Integer)
        Dim sSql As String = String.Empty
        lblName.Text = "MODIFY ACCOUNT"
        Dim MaintainBillByBill As String = String.Empty
        BtnSave.Visible = True
        BtnDelete.Text = "&Delete"
        BtnSave.Text = "&Update"
        If BtnSave.Text = "&Save" Then cbState.Text = clsFun.ExecScalarStr("Select State From Company Limit 1")
        '  Panel1.BackColor = Color.PaleVioletRed
        If clsFun.GetConnection.State = ConnectionState.Open Then clsFun.CloseConnection()
        sSql = "Select * from Accounts ac inner join AccountGroup grp on ac.GroupID=grp.ID where ac.id=" & id
        clsFun.con.Open()
        Dim ad As New SQLite.SQLiteDataAdapter(sSql, clsFun.GetConnection)
        Dim ds As New DataSet
        ad.Fill(ds, "a")
        If ds.Tables("a").Rows.Count > 0 Then
            tmpid = id
            txtName.Text = ds.Tables("a").Rows(0)("AccountName").ToString()
            cbGroup.Text = ds.Tables("a").Rows(0)("GroupName").ToString()
            cbDrCr.Text = ds.Tables("a").Rows(0)("DC").ToString()
            txtOPBal.Text = Format(Val(ds.Tables("a").Rows(0)("OpBal").ToString()), "0.00")
            txtOtherName.Text = ds.Tables("a").Rows(0)("OtherName").ToString()
            txtAddress.Text = ds.Tables("a").Rows(0)("address").ToString()
            txtLf.Text = ds.Tables("a").Rows(0)("LFNo").ToString()
            txtArea.Text = ds.Tables("a").Rows(0)("Area").ToString()
            txtCity.Text = ds.Tables("a").Rows(0)("City").ToString()
            cbState.Text = ds.Tables("a").Rows(0)("State").ToString()
            txtStateGSTCode.Text = Format(Val(ds.Tables("a").Rows(0)("StateCode").ToString()), "00")
            txtPinCode.Text = ds.Tables("a").Rows(0)("PinCode").ToString()
            txtMob1.Text = ds.Tables("a").Rows(0)("Mobile1").ToString()
            txtMob2.Text = ds.Tables("a").Rows(0)("Mobile2").ToString()
            txtContactName.Text = ds.Tables("a").Rows(0)("Contact").ToString()
            txtphoneNo.Text = ds.Tables("a").Rows(0)("PhoneNo").ToString()
            txtFaxNo.Text = ds.Tables("a").Rows(0)("FaxNo").ToString()
            txtMail.Text = ds.Tables("a").Rows(0)("MailID").ToString()
            txtBank.Text = ds.Tables("a").Rows(0)("BankName").ToString()
            txtACNo.Text = ds.Tables("a").Rows(0)("AccNo").ToString()
            txtIfsc.Text = ds.Tables("a").Rows(0)("IFSC").ToString()
            txtVATNo.Text = ds.Tables("a").Rows(0)("VatNo").ToString()
            txtPanNo.Text = ds.Tables("a").Rows(0)("PanNo").ToString()
            txtCSTNo.Text = ds.Tables("a").Rows(0)("CSTNo").ToString()
            txtDLNo1.Text = ds.Tables("a").Rows(0)("DLNo1").ToString()
            txtDLNo2.Text = ds.Tables("a").Rows(0)("DlNo2").ToString()
            txtUIDNo.Text = ds.Tables("a").Rows(0)("UIDNo").ToString()
            txtAuditUpto.Text = ds.Tables("a").Rows(0)("AuditUpto").ToString()
            txtLimit.Text = ds.Tables("a").Rows(0)("AccountLimit").ToString()
            MaintainBillByBill = ds.Tables("a").Rows(0)("MaintainBillByBill").ToString()
            If MaintainBillByBill = "Y" Then ckByB.Checked = True
            If MaintainBillByBill = "N" Then ckByB.Checked = False
            txtGSTN.Text = ds.Tables("a").Rows(0)("GSTNo").ToString()
            cbGSTtype.Text = ds.Tables("a").Rows(0)("GSTType").ToString()
            cbGSTApplicable.Text = ds.Tables("a").Rows(0)("GSTApplicable").ToString()
            If ds.Tables("a").Rows(0)("GSTApplicable").ToString() = "Yes" Then
                PnlTaxInfo.Visible = True
                txtHSNCode.Text = ds.Tables("a").Rows(0)("HSNCode").ToString()
                CbTax.SelectedValue = ds.Tables("a").Rows(0)("TaxID").ToString()
                CbTax.Text = ds.Tables("a").Rows(0)("TaxName").ToString()
                CbRCM.Text = ds.Tables("a").Rows(0)("RCM").ToString()
            End If
            If clsFun.ExecScalarInt("Select count(*) from AccountGroup where  ParentID in(24,25,26,27) and ID='" & Val(cbGroup.SelectedValue) & "'") <> 0 Then
                CbRCM.SelectedIndex = 0 : If clsFun.ExecScalarStr("Select RCM From Company") = "Yes" Then CbRCM.Enabled = True Else CbRCM.Enabled = False : CbRCM.SelectedIndex = 0
                cbGSTtype.SelectedIndex = 0 : cbGSTtype.Enabled = False : txtGSTN.Enabled = False
                PnlTaxInfo.Visible = True
            Else
                cbGSTtype.Enabled = True : txtGSTN.Enabled = True
                PnlTaxInfo.Visible = False : cbGSTApplicable.SelectedIndex = 0
                CbRCM.SelectedIndex = 0
            End If
            txtID.Text = tmpid
            If Directory.Exists(Application.StartupPath & "\Images") = False Then
                Directory.CreateDirectory(Application.StartupPath & "\Images")
            End If
            If File.Exists(Application.StartupPath & "\Images\" & txtName.Text & ".jpg") = True Then
                picCustomer.Load(Application.StartupPath & "\Images\" & txtName.Text & ".jpg")
                picCustomer.Update()
            End If
        End If
    End Sub

    Private Sub updateAccount()
        If clsFun.ExecScalarStr("Select count(*)from Accounts where upper(AccountName)=upper('" & txtName.Text & "')") > 1 Then
            MsgBox("Account Already Exists...", vbCritical + vbOKOnly, "Access Denied")
            txtName.Focus() : Exit Sub
        End If
        Dim MaintainBillByBill As String = String.Empty
        If ckByB.Checked = True Then MaintainBillByBill = "Y" Else MaintainBillByBill = "N"
        If txtName.Text = "" Then
            MsgBox("Account Name is Blank. Please Fill Account Name... ", MsgBoxStyle.Critical, "Empty")
            txtName.Focus()
        Else
            Dim sql As String = "Update Accounts SET AccountName='" & txtName.Text.Trim & "',GroupId=" & Val(cbGroup.SelectedValue) & ",DC='" & cbDrCr.Text & "'," _
                                 & " Opbal='" & txtOPBal.Text & "',address='" & txtAddress.Text & "',LFNo='" & txtLf.Text & "',OtherName='" & txtOtherName.Text.Trim & "'," _
                                 & " Area='" & txtArea.Text & "',city='" & txtCity.Text & "',State='" & cbState.Text & "',StateCode='" & txtStateGSTCode.Text & "'," _
                                 & " Mobile1='" & txtMob1.Text & "',Mobile2='" & txtMob2.Text & "',MailID='" & txtMail.Text & "',BankName='" & txtBank.Text & "'," _
                                 & " AccNo='" & txtACNo.Text & "',IFSC='" & txtIfsc.Text & "',VatNo='" & txtVATNo.Text & "',PinCode='" & txtPinCode.Text & "'," _
                                 & " PanNo='" & txtPanNo.Text & "',CSTNo='" & txtCSTNo.Text & "',DLNo1='" & txtDLNo1.Text & "',DlNo2='" & txtDLNo2.Text & "'," _
                                 & " AuditUpto='" & txtAuditUpto.Text & "',MaintainBillByBill='" & MaintainBillByBill & "',GSTNo='" & txtGSTN.Text & "'," _
                                 & " GSTType='" & cbGSTtype.Text & "',UIDNo='" & txtUIDNo.Text & "' ,Contact='" & txtContactName.Text & "',PhoneNo='" & txtphoneNo.Text & "', " _
                                 & " FaxNo='" & txtFaxNo.Text & "',AccountLimit='" & txtLimit.Text & "',CountryName='" & cbCountry.Text & "'," _
                                 & " CountryID='" & Val(cbCountry.SelectedValue) & "',RCM='" & CbRCM.Text & "',GSTApplicable='" & cbGSTApplicable.Text & "', " _
                                 & " HsnCode='" & If(cbGSTApplicable.SelectedIndex = 0, "", txtHSNCode.Text) & "',TaxID='" & If(cbGSTApplicable.SelectedIndex = 0, 0, CbTax.SelectedValue) & "', " _
                                 & " TaxName='" & If(cbGSTApplicable.SelectedIndex = 0, "", CbTax.Text) & "' WHERE ID=" & Val(txtID.Text) & ""
            Try
                If clsFun.ExecNonQuery(sql) > 0 Then
                    clsFun.ExecScalarStr("Update TaxDetails Set AccountName='" & txtName.Text & "',StateName='" & cbState.Text & "',StateCode='" & txtStateGSTCode.Text & "', " & _
                                         "GSTType='" & cbGSTtype.Text & "',GSTIN='" & txtGSTN.Text & "' Where AccountID=" & Val(txtID.Text) & "")
                    MsgBox("Record Updated Successfully.", vbInformation + vbOKOnly, "Updated")

                    Account_List.btnRetrive.PerformClick()
                    saveImage()
                    ClearText()
                    '       Me.Alert("Update Alert", msgAlert.enmType.Update)
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub cbGroup_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then txtOPBal.Focus()
    End Sub


    Private Sub cbGroup_SelectedIndexChanged(sender As Object, e As EventArgs)
        cbDrCr.Text = clsFun.ExecScalarStr(" Select DC FROM AccountGroup WHERE GroupName like '%" + cbGroup.Text + "%'")
    End Sub
    Private Sub txtGState_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then BtnSave.Focus()
    End Sub
    Private Sub Delete()
        If clsFun.ExecScalarInt("Select tag From Accounts  WHERE ID=" & txtID.Text & "") = 0 Then MsgBox("Pre-Define Master. You Can't Delete it.", vbCritical + vbOKOnly, "Access Denied") : Exit Sub
        If clsFun.ExecScalarInt("Select count(*) from Ledger where AccountID=" & Val(txtID.Text) & "") <> 0 Then
            MsgBox("Account Already Used in Transactions", vbCritical + vbOKOnly, "Access Denied")
            Exit Sub
        ElseIf clsFun.ExecScalarInt("Select count(*) from Vouchers where AccountID=" & Val(txtID.Text) & "") <> 0 Then
            MsgBox("Account Already Used in Purchase...", vbCritical + vbOKOnly, "Access Denied")
            Exit Sub
        Else
            Try
                If MessageBox.Show("Are you Sure want to Delete Account : " & txtName.Text & " ??", "DELETE", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.OK Then
                    If clsFun.ExecNonQuery("DELETE from AccountS WHERE ID=" & txtID.Text & "") > 0 Then
                        ClearText()
                        ' Me.Alert("Deleted Successful...", msgAlert.enmType.Delete)
                        MsgBox("Record Deleted Successfully.", vbInformation + vbOKOnly, "Deleted")

                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If BtnDelete.Text = "&Reset" Then
            ClearText()
        ElseIf BtnDelete.Text = "&Delete" Then
            Delete()
        End If

    End Sub
    Private Sub cbGroup_Leave(sender As Object, e As EventArgs)
        If clsFun.ExecScalarInt("Select count(*)from AccountGroup where GroupName='" & cbGroup.Text & "'") = 0 Then
            MsgBox("Group Not Found in Database...", vbCritical + vbOKOnly, "Access Denied")
            cbGroup.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txtOtherName_GotFocus(sender As Object, e As EventArgs) Handles txtOtherName.GotFocus
        'Try
        '    SendKeys.Send("+%")
        'Catch ex As InvalidOperationException
        '    ' Do nothing
        'End Try
        '  lblNotification.Visible = True
        ' pbHindi.Visible = True
        'PnlTranslate.Visible = True
        'txtTranslate.Focus()
    End Sub


    Private Sub txtName_KeyDown1(sender As Object, e As KeyEventArgs) Handles txtName.KeyDown, txtLimit.KeyDown,
  cbGroup.KeyDown, txtOPBal.KeyDown, cbDrCr.KeyDown, txtOtherName.KeyDown, txtLf.KeyDown, txtAddress.KeyDown,
        txtArea.KeyDown, txtCity.KeyDown, txtPinCode.KeyDown, txtMob1.KeyDown, cbState.KeyDown, txtStateGSTCode.KeyDown,
        txtMob2.KeyDown, txtMail.KeyDown, txtBank.KeyDown, txtACNo.KeyDown, txtIfsc.KeyDown, txtVATNo.KeyDown, txtUIDNo.KeyDown,
        txtPanNo.KeyDown, txtCSTNo.KeyDown, txtDLNo1.KeyDown, txtDLNo2.KeyDown, txtAuditUpto.KeyDown, ckByB.KeyDown,
        txtGSTN.KeyDown, cbGSTtype.KeyDown, txtContactName.KeyDown, txtphoneNo.KeyDown, txtFaxNo.KeyDown, ckTCS.KeyDown,
        cbDefaultPrice.KeyDown, txtFixDis.KeyDown, cbGSTApplicable.KeyDown, CbRCM.KeyDown, txtHSNCode.KeyDown, CbTax.KeyDown
        If cbGSTtype.Focused Then
            If e.KeyCode = Keys.Enter Then
                If cbGSTtype.SelectedIndex = 1 Or cbGSTtype.SelectedIndex = 3 Then
                    txtGSTN.Enabled = True
                    SendKeys.Send("{TAB}")
                    e.SuppressKeyPress = True
                    Exit Sub
                Else
                    txtGSTN.Enabled = False
                    SendKeys.Send("{TAB}")
                    txtGSTN.Text = ""
                    Exit Sub
                End If
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
            e.SuppressKeyPress = True
        End If
        Select Case e.KeyCode
            Case Keys.End
                e.Handled = True
                BtnSave.PerformClick()
                Me.Close()
        End Select
    End Sub

    Private Sub cbGroup_KeyUp(sender As Object, e As KeyEventArgs) Handles cbGroup.KeyUp
        If clsFun.ExecScalarInt("Select count(*) from AccountGroup where  ParentID in(24,25,26,27) and ID='" & Val(cbGroup.SelectedValue) & "'") <> 0 Then
            CbRCM.SelectedIndex = 0 : If clsFun.ExecScalarStr("Select RCM From Company") = "Yes" Then CbRCM.Enabled = True Else CbRCM.Enabled = False : CbRCM.SelectedIndex = 0
            cbGSTtype.SelectedIndex = 0 : cbGSTtype.Enabled = False : txtGSTN.Enabled = False
            PnlTaxInfo.Visible = True
        Else
            cbGSTtype.Enabled = True : txtGSTN.Enabled = True
            PnlTaxInfo.Visible = False : cbGSTApplicable.SelectedIndex = 0
            CbRCM.SelectedIndex = 0
        End If
    End Sub

    Private Sub cbGroup_Leave1(sender As Object, e As EventArgs) Handles cbGroup.Leave
        If clsFun.ExecScalarInt("Select count(*) from AccountGroup where GroupName='" & cbGroup.Text & "'") = 0 Then
            MsgBox("Group Not Found in Database...", vbCritical + vbOKOnly, "Access Denied") : cbGroup.Focus() : Exit Sub
        End If

    End Sub

    Private Sub cbGroup_SelectedIndexChanged1(sender As Object, e As EventArgs) Handles cbGroup.SelectedIndexChanged
        cbDrCr.Text = clsFun.ExecScalarStr(" Select DC FROM AccountGroup WHERE GroupName like '%" + cbGroup.Text + "%'")

    End Sub

    Private Sub CreateAccount_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        rs.ResizeAllControls(Me)
    End Sub

    Private Sub btnCustSelect_Click(sender As Object, e As EventArgs)
        OpenFileDialog1.FileName = String.Empty
        OpenFileDialog1.Filter = "Image Files (*.png *.jpg *.bmp) |*.png; *.jpg; *.bmp|All Files(*.*) |*.*"
        Me.OpenFileDialog1.ShowDialog()
        picCustomer.BackgroundImageLayout = ImageLayout.Center
        Dim fs As FileStream
        If OpenFileDialog1.FileName <> "" Then
            fs = File.OpenRead(OpenFileDialog1.FileName)
            picCustomer.Image = Image.FromFile(OpenFileDialog1.FileName)
            GurImagePath = OpenFileDialog1.FileName
        End If
    End Sub


    Private Sub txtName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtName.KeyPress
        e.Handled = (e.KeyChar = "'") Or (e.KeyChar = """")
    End Sub

    Private Sub txtName_Leave(sender As Object, e As EventArgs) Handles txtName.Leave
        If txtName.Text <> txtName.Text.ToUpper Then
            txtName.Text = StrConv(txtName.Text, VbStrConv.ProperCase)
        End If
        If BtnSave.Text = "&Save" Then
            If clsFun.ExecScalarStr("Select count(*)from Accounts where upper(AccountName)=upper('" & txtName.Text & "')") = 1 Then
                MsgBox("Account Already Exists...", vbCritical + vbOKOnly, "Access Denied") : txtName.Focus() : Exit Sub
            End If
        Else
            If clsFun.ExecScalarStr("Select count(*)from Accounts where upper(AccountName)=upper('" & txtName.Text & "')") > 1 Then
                MsgBox("Account Already Exists...", vbCritical + vbOKOnly, "Access Denied") : txtName.Focus() : Exit Sub
            End If
        End If
    End Sub

    Private Sub cbDrCr_Leave(sender As Object, e As EventArgs) Handles cbDrCr.Leave
        'PnlTranslate.Visible = True
        'txtTranslate.Focus()
    End Sub

    Private Sub cbDrCr_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDrCr.SelectedIndexChanged

    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        If BtnSave.Text = "&Save" Then
            txtOtherName.Text = txtName.Text
        End If
        ' txtTranslate.Text = txtName.Text
    End Sub
    Private Sub txtOtherName_Leave(sender As Object, e As EventArgs) Handles txtOtherName.Leave
        If txtName.Text = "" Then txtName.Focus() : Exit Sub
        'Try
        '    SendKeys.Send("+%")
        'Catch ex As InvalidOperationException
        '    ' Do nothing
        'End Try
        '  pbHindi.Visible = False
        ' lblNotification.Visible = False
    End Sub

    Private Sub txtOtherName_TextChanged(sender As Object, e As EventArgs) Handles txtOtherName.TextChanged

    End Sub

    Private Sub btnAccountList_Click(sender As Object, e As EventArgs) Handles btnAccountList.Click
        Account_List.MdiParent = MainScreenForm
        Account_List.Show()
        If Not Account_List Is Nothing Then
            Account_List.BringToFront()
        End If
    End Sub

    Private Sub txtAddress_Leave(sender As Object, e As EventArgs) Handles txtAddress.Leave
        If txtAddress.Text <> txtAddress.Text.ToUpper Then
            txtAddress.Text = StrConv(txtAddress.Text, VbStrConv.ProperCase)
        End If

    End Sub

    Private Sub txtAddress_TextChanged(sender As Object, e As EventArgs) Handles txtAddress.TextChanged

    End Sub

    Private Sub txtCity_Leave(sender As Object, e As EventArgs) Handles txtCity.Leave
        If txtCity.Text <> txtCity.Text.ToUpper Then
            txtCity.Text = StrConv(txtCity.Text, VbStrConv.ProperCase)
        End If

    End Sub

    Private Sub txtCity_TextChanged(sender As Object, e As EventArgs) Handles txtCity.TextChanged

    End Sub

    Private Sub txtState_Leave(sender As Object, e As EventArgs)
        If cbState.Text <> cbState.Text.ToUpper Then
            cbState.Text = StrConv(cbState.Text, VbStrConv.ProperCase)
        End If

    End Sub

    Private Sub txtGName_Leave(sender As Object, e As EventArgs) Handles txtVATNo.Leave
        If txtVATNo.Text <> txtVATNo.Text.ToUpper Then
            txtVATNo.Text = StrConv(txtVATNo.Text, VbStrConv.ProperCase)
        End If
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs)
        picCustomer.Image = Nothing
    End Sub
    Private Sub cbState_Leave(sender As Object, e As EventArgs) Handles cbState.Leave
        txtStateGSTCode.Text = Format(Val(ClsFunPrimary.ExecScalarStr("Select StateGSTCodes From StateList Where ID='" & Val(cbState.SelectedValue) & "'")), "00")
    End Sub

    Private Sub txtGSTN_Leave(sender As Object, e As EventArgs) Handles txtGSTN.Leave
        If txtGSTN.Text <> "" Then
            If BtnSave.Text = "&Save" Then
                If clsFun.ExecScalarStr("Select count(*) from Accounts where upper(GSTNo)=upper('" & txtGSTN.Text & "')") = 1 Then
                    lbl_Result.ForeColor = Color.Red : txtGSTN.ForeColor = Color.Red
                    lbl_Result.Text = "GST No Already Exists..." : txtGSTN.Focus() : Exit Sub
                End If
            Else
                If clsFun.ExecScalarStr("Select count(*)from Accounts where upper(GSTNo)=upper('" & txtGSTN.Text & "')") > 1 Then
                    lbl_Result.ForeColor = Color.Red : txtGSTN.ForeColor = Color.Red
                    lbl_Result.Text = "GST No Already Exists..." : txtGSTN.Focus() : Exit Sub
                End If
            End If
        End If
        If txtGSTN.Text.Length = 15 Then
            txtPanNo.Text = txtGSTN.Text.Substring(2, 10)
        End If
    End Sub

    Private Sub txtGSTN_TextChanged(sender As Object, e As EventArgs) Handles txtGSTN.TextChanged
        Try
            If GSTINValidator.IsValid(txtGSTN.Text) Then
                lbl_Result.ForeColor = Color.Green
                lbl_Result.Text = "Valid GSTIN."
                txtGSTN.ForeColor = Color.Green
            Else
                lbl_Result.ForeColor = Color.Red
                lbl_Result.Text = "Invalid GSTIN!"
                txtGSTN.ForeColor = Color.Red
            End If
        Catch ex As Exception
            lbl_Result.ForeColor = Color.Red
            txtGSTN.ForeColor = Color.Red
            lbl_Result.Text = ex.Message
        End Try
    End Sub

    Private Sub cbGSTtype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbGSTtype.SelectedIndexChanged

    End Sub

    Private Sub cbGSTApplicable_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbGSTApplicable.SelectedIndexChanged
        If cbGSTApplicable.SelectedIndex <> 0 Then
            txtHSNCode.Visible = True : CbTax.Visible = True : CbRCM.Visible = True
            If CbTax.SelectedIndex = -1 Then
                clsFun.FillDropDownList(CbTax, "Select ID,TaxName From Taxation Order by ID", "TaxName", "Id", "")
            End If

        Else
            CbTax.SelectedIndex = -1 : CbRCM.SelectedIndex = 0
            txtHSNCode.Visible = False : CbTax.Visible = False : CbRCM.Visible = False
        End If
    End Sub

   
End Class