Imports TestCallVB

Public Class Mobile_App
    Dim ClsCommon As CommonClass = New CommonClass()
    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles BtnIDGenrate.Click
        If My.Computer.Network.IsAvailable = False Then MsgBox("Please Check Your Internet Connection", vbCritical, "No Internet Access") : Exit Sub
        BtnIDGenrate.BackColor = Color.DarkTurquoise
        ClsCommon.GenrateID()
    End Sub
    Private Sub saveUpdateInfo()
        Application.DoEvents()
        If ClsCommon.IsInternetConnect Then
            Update() ' ClsCommon.UpdateCompanyInfo("ADD")
            Dim httpservice As HttpService = New HttpService()
            Dim OrgID As Integer = 0
            Dim ComPSql As String = "SELECT * FROM Company"
            Dim compdt As DataTable = New DataTable()
            compdt = clsFun.ExecDataTable(ComPSql)
            Dim companyRequest As CompanyRequest = New CompanyRequest()
            For Each item As DataRow In compdt.Rows
                companyRequest.Address = item.Field(Of String)("Address")
                companyRequest.City = item.Field(Of String)("City")
                companyRequest.CompanyID = 0
                companyRequest.CompanyName = item.Field(Of String)("CompanyName")
                companyRequest.CompData = item.Field(Of String)("CompData")
                companyRequest.DealsIN = item.Field(Of String)("DealsIN")
                companyRequest.EmailID = item.Field(Of String)("EmailID")
                companyRequest.FaxNo = item.Field(Of String)("FaxNo")
                companyRequest.GSTN = item.Field(Of String)("GSTN")
                companyRequest.IsActive = True
                companyRequest.Marka = item.Field(Of String)("Marka")
                companyRequest.MobileNo1 = item.Field(Of String)("MobileNo1")
                companyRequest.MobileNo2 = item.Field(Of String)("MobileNo2")
                companyRequest.OrganizationID = item.Field(Of Int64)("OrganizationID")
                companyRequest.Other = item.Field(Of String)("Other")
                companyRequest.PanNo = item.Field(Of String)("PanNO")
                companyRequest.Password = item.Field(Of String)("Password")
                companyRequest.PhoneNo = item.Field(Of String)("PhoneNo")
                companyRequest.PrintOtheraddress = item.Field(Of String)("PrintOtheraddress")
                companyRequest.PrintOtherCity = item.Field(Of String)("PrintOtherCity")
                companyRequest.PrintOtherName = item.Field(Of String)("PrintOtherName")
                companyRequest.PrintOtherState = item.Field(Of String)("PrintOtherState")
                companyRequest.RegistrationNo = item.Field(Of String)("RegistrationNo")
                companyRequest.State = item.Field(Of String)("State")
                companyRequest.tag = item.Field(Of String)("tag")
                companyRequest.Website = item.Field(Of String)("Website")
                companyRequest.Yearend = item.Field(Of Date)("YearStart")
                companyRequest.YearStart = item.Field(Of Date)("Yearend")
                OrgID = item.Field(Of Int64)("OrganizationID")

            Next
            Dim companyResp As CompanyResponse = httpservice.SendCompany(companyRequest)


            ''' AccountGroup Insert
            ''' 
            Dim AccGrpSql As String = "SELECT * FROM AccountGroup"
            Dim AccgrpDt As DataTable = New DataTable()
            AccgrpDt = clsFun.ExecDataTable(AccGrpSql)

            Dim AccgrpRqst As AddAccountGroupRequest = New AddAccountGroupRequest()
            For Each item As DataRow In AccgrpDt.Rows

                Dim accgrp As AccountGroupRequest = New AccountGroupRequest()
                accgrp.GroupId = item.Field(Of Int64)("ID")
                accgrp.GroupName = item.Field(Of String)("GroupName")
                accgrp.UnderGroupID = item.Field(Of Int64)("UnderGroupID")
                accgrp.UnderGroupName = item.Field(Of String)("UnderGroupName")
                accgrp.DC = item.Field(Of String)("DC")
                accgrp.Primary2 = item.Field(Of String)("Primary2")
                accgrp.Tag = item.Field(Of String)("Tag")
                accgrp.OrganizationId = OrgID 'item.Field(Of Int64)("OrganizationId")
                AccgrpRqst.AccountGroups.Add(accgrp)
            Next
            Dim AccGrpResp As AccountGroupResponse = New HttpService().SendAccountGroup(AccgrpRqst)

            '''' Ledger Talbe Insert

            'Dim totLegCount As Integer = 0


            Dim sql As String = "SELECT COUNT(*) FROM Ledger"
            Dim ledgerCount As Integer = clsFun.ExecScalarInt(sql)

            Dim progesssCount As Integer = 0

            Dim maxRowCount As Decimal = 0
            maxRowCount = Math.Ceiling(ledgerCount / 1000)

            dataProgress.Minimum = progesssCount
            dataProgress.Maximum = maxRowCount
            dataProgress.Visible = True
            Dim legCount As Integer = 0

            For i As Integer = 0 To maxRowCount - 1

                Dim ledSql As String = "SELECT VourchersID,EntryDate,TransType,AccountID,AccountName,Amount,DC,Remark,Narration" +
                                    " FROM Ledger LIMIT 1000 OFFSET " + legCount.ToString()
                Dim ledDt As DataTable = New DataTable()
                ledDt = clsFun.ExecDataTable(ledSql)

                progesssCount = progesssCount + 1
                If ledDt.Rows.Count() > 0 Then
                    legCount = legCount + ledDt.Rows.Count()
                    Dim ledgerRqst As LedgerRequest = New LedgerRequest()
                    If i = 0 Then
                        ledgerRqst.IsFirstRow = True
                    Else
                        ledgerRqst.IsFirstRow = False
                    End If
                    'dataProgress.Maximum = maxRowCount 'Set Max Lenght
                    dataProgress.Step = 1 'Set Step
                    dataProgress.Value = progesssCount
                    For Each item As DataRow In ledDt.Rows
                        dataProgress.Value = i
                        Dim ledger As LedgerData = New LedgerData()
                        ledger.AccountID = item.Field(Of Int64)("AccountID")
                        ledger.VourchersID = item.Field(Of Int64)("VourchersID")
                        ledger.EntryDate = item.Field(Of Date)("EntryDate")
                        ledger.TransType = item.Field(Of String)("TransType")
                        ledger.AccountName = item.Field(Of String)("AccountName")
                        ledger.Amount = item.Field(Of Decimal)("Amount")
                        ledger.DC = item.Field(Of String)("DC")
                        ledger.Remark = item.Field(Of String)("Remark")
                        ledger.Narration = item.Field(Of String)("Narration")
                        ledger.OrganizationId = OrgID 'item.Field(Of Int64)("OrganizationId")
                        ledgerRqst.Ledgers.Add(ledger)
                    Next
                    Dim ledgerResp As SaveLedgerResponse = New HttpService().SendLedgerData(ledgerRqst)

                End If
                dataProgress.Value = 0
            Next




            '''' Account Table Insert

            Dim accSql As String = "SELECT * FROM Accounts"
            Dim accDt As DataTable = New DataTable()
            accDt = clsFun.ExecDataTable(accSql)
            Dim accRqst As AddAccountRequest = New AddAccountRequest()
            For Each item As DataRow In accDt.Rows
                Dim acc As AccountRequest = New AccountRequest()
                acc.AccountId = item.Field(Of Int64)("ID")
                acc.AccountName = item.Field(Of String)("AccountName")
                acc.GroupID = item.Field(Of Int64)("GroupID")
                acc.DC = item.Field(Of String)("DC")
                acc.Tag = item.Field(Of String)("Tag")
                acc.OpBal = item.Field(Of Decimal)("OpBal")
                acc.OtherName = item.Field(Of String)("OtherName")
                acc.Address = item.Field(Of String)("Address")
                acc.LFNo = item.Field(Of String)("LFNo")
                acc.Area = item.Field(Of String)("Area")
                acc.City = item.Field(Of String)("City")
                acc.AccNo = item.Field(Of String)("State")
                acc.Phone = item.Field(Of String)("Phone")
                acc.Contact = item.Field(Of String)("Contact")
                acc.Mobile1 = item.Field(Of String)("Mobile1")
                acc.Mobile2 = item.Field(Of String)("Mobile2")
                acc.MailID = item.Field(Of String)("MailID")
                acc.BankName = item.Field(Of String)("BankName")
                acc.AccNo = item.Field(Of String)("AccNo")
                acc.IFSC = item.Field(Of String)("IFSC")
                acc.GName = item.Field(Of String)("GName")
                acc.Gmobile1 = item.Field(Of String)("Gmobile1")
                acc.Gmobile2 = item.Field(Of String)("Gmobile2")
                acc.Gaddress = item.Field(Of String)("Gaddress")
                acc.GCity = item.Field(Of String)("GCity")
                acc.Gstate = item.Field(Of String)("Gstate")
                acc.Limit = item.Field(Of String)("Limit")
                acc.AccountPhoto = ""
                acc.Gphoto = ""
                acc.OrganizationId = OrgID

                accRqst.Accounts.Add(acc)
            Next
            Dim httppservice As HttpService = New HttpService()
            Dim accResp As SaveAccountResponse = httpservice.SendAccountData(accRqst)
            dataProgress.Visible = False
            MsgBox("Record Updated on Server Successfully", vbInformation, "Sucessful")
        Else
            MessageBox.Show("Sorry... Your System is not Connected to Internet. Please check internet connection...", "Internet Required...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub
        End If
        'Else
        'If ClsCommon.IsInternetConnect Then
        '    Update() : ClsCommon.UpdateCutomerInfo("EDIT")
        'Else
        '    MessageBox.Show("Sorry... Your System is not Connected to Internet. Please check internet connection...", "Internet Required...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub
        'End If
        'End If
    End Sub

    Private Sub Save()
        Dim cmd As SQLite.SQLiteCommand
        Dim sync As String = String.Empty
        If ckSynconClose.CheckState = CheckState.Checked Then
            sync = "Y"
        Else
            sync = "N"
        End If
        Dim sql As String = "insert into Company(OrganizationID, Password,AutoSync)values (@1, @2,@3)"
        Try
            cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
            cmd.Parameters.AddWithValue("@1", txtCompanyID.Text)
            cmd.Parameters.AddWithValue("@2", txtPassword.Text)
            cmd.Parameters.AddWithValue("@3", sync)
            If cmd.ExecuteNonQuery() > 0 Then
                MessageBox.Show("Record Insert SuccesFully", "SuccessFully", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            clsFun.CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message)
            clsFun.CloseConnection()
        End Try
    End Sub

    Private Sub Update()
        Dim sync As String = String.Empty
        If ckSynconClose.CheckState = CheckState.Checked Then
            sync = "Y"
        Else
            sync = "N"
        End If
        Dim sql As String = "Update Company SET OrganizationID='" & txtCompanyID.Text & "',Password='" & txtPassword.Text & "',AutoSync='" & sync & "' WHERE ID=" & Val(txtID.Text) & ""
        cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
        Try
            If clsFun.ExecNonQuery(sql) > 0 Then
                '  MsgBox("Record Updated Successfully.", vbInformation + vbOKOnly, "Updated")
            End If
            'con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            'con.Close()
        End Try
    End Sub

    Private Sub Mobile_App_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub Mobile_App_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        txtCompanyID.TextAlign = HorizontalAlignment.Center
        FillControls()
        txtPassword.UseSystemPasswordChar = True
    End Sub

    Private Sub btnSync_Click(sender As Object, e As EventArgs) Handles btnSync.Click
        If txtCompanyID.Text = "" Or Val(txtCompanyID.Text) = 0 Then MsgBox("Please Check Your Organization ID...", MsgBoxStyle.Exclamation, "Organization ID") : BtnIDGenrate.BackColor = Color.Red : BtnIDGenrate.Focus() : Exit Sub
        If txtPassword.Text = "" Then MsgBox("Please Re Check Your Password...", MsgBoxStyle.Exclamation, "Password") : txtPassword.Focus() : Exit Sub
        saveUpdateInfo()
        'If clsFun.ExecScalarStr("") Then
        '    Save()
    End Sub
    Public Sub FillControls()
        Dim ssql As String = String.Empty
        ' Dim primary As String = String.Empty
        ' BtnIDGenrate.Visible = False
        Dim dt As New DataTable
        ssql = "Select * from Company "
        dt = clsFun.ExecDataTable(ssql) ' where id=" & id & "")
        If dt.Rows.Count > 0 Then
            txtID.Text = Val(dt.Rows(0)("ID").ToString())
            txtCompanyID.Text = Val(dt.Rows(0)("OrganizationID").ToString())
            txtPassword.Text = dt.Rows(0)("Password").ToString()
        End If
        If txtCompanyID.Text > 0 Then
            BtnIDGenrate.Visible = False
        Else
            txtCompanyID.Text = ""
        End If

    End Sub

    Private Sub txtCompanyID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCompanyID.KeyDown, BtnIDGenrate.KeyDown, txtPassword.KeyDown, CkShowPassword.KeyDown, ckSynconClose.KeyDown, btnSync.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtCompanyID_TextChanged(sender As Object, e As EventArgs) Handles txtCompanyID.TextChanged

    End Sub

    Private Sub CkShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles CkShowPassword.CheckedChanged
        If CkShowPassword.Checked = True Then
            txtPassword.UseSystemPasswordChar = False
        Else
            txtPassword.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged

    End Sub
End Class