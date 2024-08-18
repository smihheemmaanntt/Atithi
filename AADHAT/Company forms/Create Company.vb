Imports System.IO
'Imports ADOX
Imports System.Windows.Forms
Imports System.Data
Imports System.Data.SQLite
Imports System.Text
Imports System.Configuration
Imports System.Xml

Public Class Create_Company
    Dim rs As New Resizer
    'Private Shared CompData As String = String.Empty
    'Dim sql As String = clsFun.ExecScalarStr("Select CompData from Company")
    Dim ClsCommon As CommonClass = New CommonClass()
    Dim CopyDestPath As String = String.Empty
    Dim tmpDataPath As String = String.Empty

    Private Sub Create_Company_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub Create_Company_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub


    Private Sub Create_Company_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String = String.Empty
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        rs.FindAllControls(Me) : Me.BackColor = Color.GhostWhite
        Me.Top = 0 : Me.Left = 0 : Me.KeyPreview = True
        CbBusinessType.SelectedIndex = 0
        ClsFunPrimary.FillDropDownList(cbState, "Select * From StateList", "StateName", "Id", "")
        ClsFunPrimary.FillDropDownList(CbCountry, "Select * From Countries", "CountryName", "Id", "")
        If BtnSave.Text <> "&Update" Then cbState.SelectedValue = 31 : CbCountry.SelectedIndex = 0
        cbGSTtype.SelectedIndex = 0 : CbFillingType.SelectedIndex = 0 : CbRCM.SelectedIndex = 0
    End Sub
    Private Sub SaveDirectory()
        Dim i As Integer = 0
        CopyDestPath = "Data\1000"
        tmpDataPath = "1000"
        For i = 1 To 50
            If Directory.Exists(Application.StartupPath & "\" & CopyDestPath & i) = False Then
                CompData = CopyDestPath & i & "\"
                tmpDataPath = tmpDataPath & i
                tmpDataPath = tmpDataPath & "\Data.db"
                Directory.CreateDirectory(Application.StartupPath & "\" & CopyDestPath & i)
                CopyDestPath = (Application.StartupPath & "\" & CopyDestPath & i).ToString()
                Exit For
            End If
        Next
        CopyDirectory(Application.StartupPath & "\Demo\Data.db", CopyDestPath)
        GlobalData.ConnectionPath = CopyDestPath & "\Data.db"
    End Sub

    Public Sub FillContros(ByVal id As Integer)
        Dim sSql As String = String.Empty
        Dim Crate As String = String.Empty
        lblBusinessType.Visible = False
        CbBusinessType.Visible = False
        'clsFun.changeCompany()
        BtnSave.Text = "&Update"
        ' BtnSave.Image = My.Resources.Edit
        BtnSave.BackColor = Color.Coral
        lblPath.Visible = True : txtPath.Visible = True
        '   l.Visible = True : txt.Visible = True
        If clsFun.GetConnection.State = ConnectionState.Open Then clsFun.CloseConnection()
        sSql = "Select * from Company where id=" & Val(id)
        clsFun.con.Open()
        Dim ad As New SQLite.SQLiteDataAdapter(sSql, clsFun.GetConnection)
        Dim ds As New DataSet
        ad.Fill(ds, "a")
        If ds.Tables("a").Rows.Count > 0 Then
            txtID.Text = ds.Tables("a").Rows(0)("ID").ToString()
            '  mskFYStart.Text = Format(ds.Tables("a").Rows(0)("EntryDate"), "dd-MM-yyyy")
            txtCompanyName.Text = ds.Tables("a").Rows(0)("CompanyName").ToString()
            txtPrintCompanyName.Text = ds.Tables("a").Rows(0)("PrintOtherName").ToString()
            txtAddress.Text = ds.Tables("a").Rows(0)("Address").ToString()
            txtPrintAddress.Text = ds.Tables("a").Rows(0)("PrintOtherAddress").ToString()
            txtCity.Text = ds.Tables("a").Rows(0)("City").ToString()
            txtprintCity.Text = ds.Tables("a").Rows(0)("PrintOtherCity").ToString()
            cbState.Text = ds.Tables("a").Rows(0)("State").ToString()
            txtStateGSTCode.Text = Format(Val(ds.Tables("a").Rows(0)("StateCode").ToString()), "00")
            txtPrintState.Text = ds.Tables("a").Rows(0)("PrintOtherState").ToString()
            txtMobile1.Text = ds.Tables("a").Rows(0)("MobileNo1").ToString()
            txtMobile2.Text = ds.Tables("a").Rows(0)("MobileNo2").ToString()
            txtPhone.Text = ds.Tables("a").Rows(0)("PhoneNo").ToString()
            txtFax.Text = ds.Tables("a").Rows(0)("FaxNo").ToString()
            txtEmal.Text = ds.Tables("a").Rows(0)("EMailID").ToString()
            txtWebsite.Text = ds.Tables("a").Rows(0)("Website").ToString()
            cbGSTtype.Text = ds.Tables("a").Rows(0)("GSTType").ToString()
            CbFillingType.Text = ds.Tables("a").Rows(0)("FillingType").ToString()
            CbRCM.Text = ds.Tables("a").Rows(0)("RCM").ToString()
            txtGSTN.Text = ds.Tables("a").Rows(0)("GSTN").ToString()
            txtDlNo1.Text = ds.Tables("a").Rows(0)("DLNo1").ToString()
            txtDlNo2.Text = ds.Tables("a").Rows(0)("DlNo2").ToString()
            txtPrevPath.Text = ds.Tables("a").Rows(0)("PrevPath").ToString()
            txtDelasIn.Text = ds.Tables("a").Rows(0)("DealsIn").ToString()
            txtReg.Text = ds.Tables("a").Rows(0)("RegistrationNo").ToString()
            txtPan.Text = ds.Tables("a").Rows(0)("PanNo").ToString()
            txtother.Text = ds.Tables("a").Rows(0)("Other").ToString()
            txtPinCode.Text = ds.Tables("a").Rows(0)("PinCode").ToString()
            mskFYStart.Text = CDate(ds.Tables("a").Rows(0)("YearStart")).ToString("dd-MM-yyyy")
            MskFYEnd.Text = CDate(ds.Tables("a").Rows(0)("YearEnd")).ToString("dd-MM-yyyy")
            txtPath.Text = ds.Tables("a").Rows(0)("CompData").ToString()
        End If
    End Sub

    Private Sub cbState_ContextMenuChanged(sender As Object, e As EventArgs) Handles cbState.ContextMenuChanged

    End Sub

    Private Sub txtCompanyName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCompanyName.KeyDown, txtAddress.KeyDown, txtCity.KeyDown,
        cbState.KeyDown, txtMobile1.KeyDown, txtMobile2.KeyDown, txtPhone.KeyDown, txtFax.KeyDown, txtEmal.KeyDown, txtWebsite.KeyDown, txtGSTN.KeyDown,
         txtReg.KeyDown, txtPan.KeyDown, txtother.KeyDown, mskFYStart.KeyDown, MskFYEnd.KeyDown, txtPrintAddress.KeyDown, txtStateGSTCode.KeyDown,
        txtPrintCompanyName.KeyDown, txtPrintState.KeyDown, txtprintCity.KeyDown, txtPinCode.KeyDown, txtDlNo1.KeyDown, txtDlNo2.KeyDown, CbCountry.KeyDown,
        CbBusinessType.KeyDown, cbGSTtype.KeyDown, txtDelasIn.KeyDown, CbFillingType.KeyDown, CbRCM.KeyDown
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
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If txtCompanyName.Text = "" Then MsgBox("Company Name Blank Not Allowed", vbInformation.Information, "Access Denied") : txtCompanyName.Focus() : Exit Sub
        If txtStateGSTCode.Text = "" Then MsgBox("State Code Blank Not Allowed", vbInformation.Information, "Access Denied") : cbState.Focus() : Exit Sub
        Dim fileName As String = AppDomain.CurrentDomain.BaseDirectory & "accent.dll"
        If Not File.Exists(fileName) Then
            If BtnSave.Text = "&Save" Then
                If CompanyList.dg1.RowCount >= 1 Then
                    MessageBox.Show("Sorry... Activation Required For Multiple Companies.", "Activation Required...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub
                End If
            Else
                If CompanyList.dg1.RowCount > 1 Then
                    MessageBox.Show("Sorry... Activation Required For Multiple Companies.", "Activation Required...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub
                End If
            End If
        End If
        If BtnSave.Text = "&Save" Then
            ' Dim fileName As String = AppDomain.CurrentDomain.BaseDirectory & "accent.dll"
            If Not File.Exists(fileName) Then
                SaveCompanyInfo()
            Else
                If ClsCommon.IsInternetConnect Then
                    SaveCompanyInfo()
                    ClsCommon.UpdateCutomerInfo("ADD")
                Else
                    MessageBox.Show("Sorry... Your System is not Connected to Internet. Please check internet connection...", "Internet Required...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub
                End If
            End If

        Else
            If Not File.Exists(fileName) Then
                update()
            Else
                If ClsCommon.IsInternetConnect Then
                    update()
                    ClsCommon.UpdateCutomerInfo("EDIT")
                Else
                    MessageBox.Show("Sorry... Your System is not Connected to Internet. Please check internet connection...", "Internet Required...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub
                End If
            End If
        End If
    End Sub
    Private Sub update()
        Dim dt As DateTime
        Dim dt1 As DateTime
        dt = CDate(Me.mskFYStart.Text)
        dt1 = CDate(Me.MskFYEnd.Text)
        StartDate = dt.ToString("yyyy-MM-dd")
        EndDate = dt1.ToString("yyyy-MM-dd")
        StartDate = dt.ToString("yyyy-MM-dd")
        EndDate = dt1.ToString("yyyy-MM-dd")
        Dim sql As String = "Update Company SET CompanyName='" & txtCompanyName.Text & "',PrintOtherName='" & txtPrintCompanyName.Text & "',State='" & cbState.Text & "',StateCode='" & Val(txtStateGSTCode.Text) & "'," _
                             & " Address='" & txtAddress.Text & "',PrintOtherAddress='" & txtPrintAddress.Text & "',City='" & txtCity.Text & "',PrintOtherCity='" & txtprintCity.Text & "'," _
                             & " PrintOtherState='" & txtPrintState.Text & "',MobileNo1='" & txtMobile1.Text & "',MobileNo2='" & txtMobile2.Text & "',PhoneNo='" & txtPhone.Text & "'," _
                             & " FaxNo='" & txtFax.Text & "',EmailID='" & txtEmal.Text & "',Website='" & txtWebsite.Text & "',GSTN='" & txtGSTN.Text & "'," _
                             & " DealsIn='" & txtDelasIn.Text & "',RegistrationNo='" & txtReg.Text & "',PanNo='" & txtPan.Text & "',FillingType='" & CbFillingType.Text & "',RCM='" & CbRCM.Text & "'," _
                             & " Other='" & txtother.Text & "',YearStart='" & StartDate & "',YearEnd='" & EndDate & "',PinCode='" & txtPinCode.Text & "'," _
                             & " Compdata='" & txtPath.Text & "',DlNo1='" & txtDlNo1.Text & "',DlNo2='" & txtDlNo2.Text & "',PrevPath='" & txtPrevPath.Text & "'," _
                             & " Country='" & CbCountry.Text & "',GSTType='" & cbGSTtype.Text & "',CountryID='" & Val(CbCountry.SelectedValue) & "' WHERE ID=" & Val(txtID.Text) & ""
        Try
            If clsFun.ExecNonQuery(sql) > 0 Then
                sCompCode = txtID.Text
                MsgBox("Record Updated Successfully.", vbInformation + vbOKOnly, "Updated")
                BtnSave.Text = "&Save"
                CompanyList.getCompanies()
                Panel1.BackColor = Color.Black
                ' clsFun.ChangePath(sql)
                Me.Close()
                'Me.Alert("Update Alert", msgAlert.enmType.Info)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Shared Sub CopyDirectory(ByVal sourcePath As String, ByVal destPath As String)
        'If Not Directory.Exists(destPath) Then
        '    Directory.CreateDirectory(destPath)
        'End If
        For Each file__1 As String In Directory.GetFiles(Path.GetDirectoryName(sourcePath))
            Dim dest As String = Path.Combine(destPath, Path.GetFileName(file__1))
            File.Copy(file__1, dest)
            CompData = CompData & file__1
        Next

        For Each folder As String In Directory.GetDirectories(Path.GetDirectoryName(sourcePath))
            Dim dest As String = Path.Combine(destPath, Path.GetFileName(folder))
            CopyDirectory(folder, dest)
        Next
    End Sub
    Private Sub SaveCompanyInfo()
        Dim dt As DateTime
        Dim dt1 As DateTime
        dt = CDate(Me.mskFYStart.Text)
        dt1 = CDate(Me.MskFYEnd.Text)
        StartDate = dt.ToString("yyyy-MM-dd")
        EndDate = dt1.ToString("yyyy-MM-dd")
        If txtCompanyName.Text = "" Then MsgBox("Company Name Blank Not Allowed", vbInformation.Information, "Access Denied") : txtCompanyName.Focus() : Exit Sub
        SaveDirectory()
        '   CompanyList.updateCompanytbl() : CompanyList.UpdateAccounts()
        Dim cmd As SQLite.SQLiteCommand
        Dim sql As String = "insert into Company(CompanyName, Address, City, State, MobileNo1, MobileNo2, PhoneNo, FaxNo," _
                             & " EmailID, Website, GSTN, DealsIN, RegistrationNo, PanNo, other,YearStart,YearEnd,CompData," _
                             & " PrintOtherName,PrintOtheraddress,PrintOtherCity,PrintOtherState,StateCode,DLNo1,DLNo2, " _
                             & "BusinessType,PinCode,Country,CountryID,GSTType,FillingType,RCM)" _
                             & "values (@1, @2, @3, @4, @5, @6, @7, @8, @9, @10,@11, @12, @13, @14, @15, @16, @17, @18, @19,@20,@21, " _
                             & "@22,@23,@24,@25,@26,@27,@28,@29,@30,@31,@32)"
        Try
            cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
            cmd.Parameters.AddWithValue("@1", txtCompanyName.Text)
            cmd.Parameters.AddWithValue("@2", txtAddress.Text)
            cmd.Parameters.AddWithValue("@3", txtCity.Text)
            cmd.Parameters.AddWithValue("@4", cbState.Text)
            cmd.Parameters.AddWithValue("@5", txtMobile1.Text)
            cmd.Parameters.AddWithValue("@6", txtMobile2.Text)
            cmd.Parameters.AddWithValue("@7", txtPhone.Text)
            cmd.Parameters.AddWithValue("@8", txtFax.Text)
            cmd.Parameters.AddWithValue("@9", txtEmal.Text)
            cmd.Parameters.AddWithValue("@10", txtWebsite.Text)
            cmd.Parameters.AddWithValue("@11", txtGSTN.Text)
            cmd.Parameters.AddWithValue("@12", txtDelasIn.Text)
            cmd.Parameters.AddWithValue("@13", txtReg.Text)
            cmd.Parameters.AddWithValue("@14", txtPan.Text)
            cmd.Parameters.AddWithValue("@15", txtother.Text)
            cmd.Parameters.AddWithValue("@16", StartDate)
            cmd.Parameters.AddWithValue("@17", EndDate)
            cmd.Parameters.AddWithValue("@18", tmpDataPath)
            cmd.Parameters.AddWithValue("@19", txtPrintCompanyName.Text)
            cmd.Parameters.AddWithValue("@20", txtPrintAddress.Text)
            cmd.Parameters.AddWithValue("@21", txtprintCity.Text)
            cmd.Parameters.AddWithValue("@22", txtPrintState.Text)
            cmd.Parameters.AddWithValue("@23", Val(txtStateGSTCode.Text))
            cmd.Parameters.AddWithValue("@24", txtDlNo1.Text)
            cmd.Parameters.AddWithValue("@25", txtDlNo2.Text)
            cmd.Parameters.AddWithValue("@26", CbBusinessType.Text)
            cmd.Parameters.AddWithValue("@27", txtPinCode.Text)
            cmd.Parameters.AddWithValue("@28", Val(CbCountry.SelectedValue))
            cmd.Parameters.AddWithValue("@29", CbCountry.Text)
            cmd.Parameters.AddWithValue("@30", cbGSTtype.Text)
            cmd.Parameters.AddWithValue("@31", CbFillingType.Text)
            cmd.Parameters.AddWithValue("@32", CbRCM.Text)
            If cmd.ExecuteNonQuery() > 0 Then
                MessageBox.Show("Record Insert Successfully", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information)
                sCompCode = clsFun.ExecScalarStr("Select max(ID) From Company")
                CompanyList.getCompanies()
                Me.Close()
                'Me.Alert("Success Alert", msgAlert.enmType.Info)
            End If
            clsFun.CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message)
            clsFun.CloseConnection()
        End Try
    End Sub
    'Public Sub Alert(ByVal msg As String, ByVal type As msgAlert.enmType)
    '    Dim frm As msgAlert = New msgAlert()
    '    frm.showAlert(msg, type)
    'End Sub
    Sub changeCompany(ByVal Data As String)
        Try
            'Constructing connection string from the inputs
            Dim Con As New StringBuilder("")
            Con.Append("Data Source=|DataDirectory|\")
            Con.Append(Data & ";Version=3;New=True;Compress=True;synchronous=ON;")
            Dim strCon As String = Con.ToString()
            updateConfigFile(strCon)
            'Create new sql connection
            Dim Db As New SQLite.SQLiteConnection()
            'to refresh connection string each time else it will use             previous connection string
            ConfigurationManager.RefreshSection("connectionStrings")
            Db.ConnectionString = ConfigurationManager.ConnectionStrings("Con").ConnectionString
            clsFun.ConStr = Db.ConnectionString

        Catch E As Exception
            MessageBox.Show(ConfigurationManager.ConnectionStrings("con").ToString() + ".This is invalid connection", "Incorrect server/Database")
        End Try

    End Sub
    Public Sub updateConfigFile(con As String)
        'updating config file
        Dim XmlDoc As New XmlDocument()
        'Loading the Config file
        XmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile)
        For Each xElement As XmlElement In XmlDoc.DocumentElement
            If xElement.Name = "connectionStrings" Then
                'setting the coonection string
                xElement.FirstChild.Attributes(1).Value = con
            End If
        Next
        'writing the connection string in config file
        XmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile)
    End Sub
    Private Sub SaveFinacialYear()
        Dim cmd As SQLite.SQLiteCommand
        Dim sql As String = "insert into FinancialYear(YearStart, YearEnd)values (@1, @2)"
        ' & "@21)"
        Try
            cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
            cmd.Parameters.AddWithValue("@1", mskFYStart.Text)
            cmd.Parameters.AddWithValue("@2", MskFYEnd.Text)
            If cmd.ExecuteNonQuery() > 0 Then
                MessageBox.Show("Record Insert Successfully", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CompanyList.BtnRetrive.PerformClick()
            End If
            ' MsgBox("Successfully Inserted")
            clsFun.CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message)
            clsFun.CloseConnection()
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub


    Private Sub txtCompanyName_Leave(sender As Object, e As EventArgs) Handles txtCompanyName.Leave
        If txtCompanyName.Text <> txtCompanyName.Text.ToUpper Then
            txtCompanyName.Text = StrConv(txtCompanyName.Text, VbStrConv.ProperCase)
        End If
    End Sub


    Private Sub txtAddress_Leave(sender As Object, e As EventArgs) Handles txtAddress.Leave
        If txtAddress.Text <> txtAddress.Text.ToUpper Then
            txtAddress.Text = StrConv(txtAddress.Text, VbStrConv.ProperCase)
        End If
    End Sub

    Private Sub txtCity_Leave(sender As Object, e As EventArgs) Handles txtCity.Leave
        If txtCity.Text <> txtCity.Text.ToUpper Then
            txtCity.Text = StrConv(txtCity.Text, VbStrConv.ProperCase)
        End If
    End Sub

    Private Sub Create_Company_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        rs.ResizeAllControls(Me)
    End Sub

    Private Sub btnClose_Click_1(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub txtPrintCompanyName_TextChanged(sender As Object, e As EventArgs) Handles txtPrintCompanyName.TextChanged

    End Sub

    Private Sub txtCity_TextChanged(sender As Object, e As EventArgs) Handles txtCity.TextChanged

    End Sub

    Private Sub txtPrintCompanyName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrintCompanyName.KeyPress

    End Sub

    Private Sub txtCompanyName_TextChanged(sender As Object, e As EventArgs) Handles txtCompanyName.TextChanged

    End Sub

    Private Sub cbState_Leave(sender As Object, e As EventArgs) Handles cbState.Leave
        txtStateGSTCode.Text = Format(Val(ClsFunPrimary.ExecScalarStr("Select StateGSTCodes From StateList Where ID='" & Val(cbState.SelectedValue) & "'")), "00")
        CbCountry.SelectedValue = Val(ClsFunPrimary.ExecScalarInt("Select CountryID From StateList"))
    End Sub


    Private Sub cbState_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbState.SelectedIndexChanged
        CbCountry.SelectedValue = Val(ClsFunPrimary.ExecScalarInt("Select CountryID From StateList"))
    End Sub

    Private Sub cbGSTtype_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label37_Click(sender As Object, e As EventArgs)

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
End Class