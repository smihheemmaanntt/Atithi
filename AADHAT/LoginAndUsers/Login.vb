Imports System.IO

Public Class Login
    Dim ClsCommon As CommonClass = New CommonClass()
    Dim rs As New Resizer
    Private Sub Login_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        CompanyList.Enabled = True
    End Sub

    Private Sub Login_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rs.FindAllControls(Me)
        CompanyList.Enabled = False
        Me.Top = 130 : Me.Left = 84
        Me.BackColor = Color.DarkTurquoise
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        clsFun.FillDropDownList(CbUserName, "Select * From Users", "UserName", "Id", "")
        Me.KeyPreview = True
        CbUserName.BackColor = Color.DarkTurquoise
        txtPassword.UseSystemPasswordChar = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub


    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnLogin.Click
        UpdateDatabase()
        Dim dt As New DataTable
        dt = clsFun.ExecDataTable("Select COUNT(*) from Users  where  username='" & CbUserName.Text & "' and Password='" & txtPassword.Text & "'")
        Dim fileName As String = AppDomain.CurrentDomain.BaseDirectory & "accent.dll"
        If dt.Rows(0)(0) > 0 Then
            Application.DoEvents()
            If clsFun.CheckLicence = False Then
                lblMsg.Visible = True
                lblMsg.Text = "Login Successfuly..."
                MainScreenPicture.lblUser.Text = CbUserName.Text
                MainScreenForm.Show()
                Me.Dispose()
                ShowCompanies.Dispose()
                lblMsg.Visible = False
            Else
                If clsFun.CheckLicence = True Then
                    If Not File.Exists(fileName) Then
                        ApplyLicenseKey.MdiParent = ShowCompanies
                        ApplyLicenseKey.Show()
                        If Not ApplyLicenseKey Is Nothing Then
                            ApplyLicenseKey.BringToFront()
                        End If
                    Else
                        Dim LicCheck As Boolean = LicenseCheck(fileName)
                        If LicCheck Then
                            If ClsCommon.IsLicenseBlocked() Then
                                MsgBox("License is Blocked !!! Please Contact to Software Vendor ", vbCritical + vbOKOnly, "Blocked") : Exit Sub

                                ' clsFun.ChangePath(Data)
                                Exit Sub
                            Else
                                Data = CompanyList.dg1.SelectedRows(0).Cells(7).Value
                                ' MainScreenForm.tssLicenseStatus.Text = "Registed User"
                                'If Data <> "" Then
                                '    isCompanyOpen = True
                                '    clsFun.ChangePath("Data\" & Data)
                                'End If
                                lblMsg.Visible = True
                                lblMsg.Text = "Login Successfuly..."
                                MainScreenPicture.lblUser.Text = CbUserName.Text
                                MainScreenForm.Show()
                                Me.Dispose() : ShowCompanies.Dispose()
                                lblMsg.Visible = False
                            End If
                        End If
                    End If
                End If
            End If
        Else
            MsgBox("Incorrect Password !!! Try Again... ", vbCritical + vbOKOnly, "invalid Password")
            txtPassword.Focus()
        End If
        Try
            Dim p() As Process
            p = Process.GetProcessesByName("Easy Whatsapp")
            If p.Count = 0 Then
                Dim StartWhatsapp As New System.Diagnostics.Process
                StartWhatsapp.StartInfo.FileName = Application.StartupPath & "\Whatsapp\Easy Whatsapp.exe"
                StartWhatsapp.Start()
            End If
        Catch ex As Exception

        End Try
    
    End Sub
    Private Sub UpdateDatabase()
        'clsFun.ExecNonQuery("CREATE TABLE IF NOT EXISTS SMSAPI (Part1 TEXT,Part2 DATE)")
        'clsFun.ExecNonQuery("ALTER TABLE Transaction2  ADD PurchaseID INTEGER;")
    End Sub
    Private Sub CbUserName_KeyDown(sender As Object, e As KeyEventArgs) Handles CbUserName.KeyDown, txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        Else
            Exit Sub
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub CbUserName_Leave(sender As Object, e As EventArgs) Handles CbUserName.Leave
        If clsFun.ExecScalarInt("Select COUNT(*) from Users  where  username='" & CbUserName.Text & "'") = 0 Then
            MsgBox("User Not Found in Database...", vbCritical + vbOKOnly, "Access Denied")
            CbUserName.Focus()
            Exit Sub
        End If
    End Sub

   

    Private Sub btnViewPassword_Click(sender As Object, e As EventArgs) Handles btnViewPassword.Click
        If txtPassword.UseSystemPasswordChar = True Then
            txtPassword.UseSystemPasswordChar = False
        Else
            txtPassword.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub txtPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPassword.KeyPress
        btnViewPassword.Visible = True
    End Sub

    Private Sub txtPassword_Leave(sender As Object, e As EventArgs) Handles txtPassword.Leave

    End Sub

    Private Sub txtPassword_TextChanged_1(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        If txtPassword.Text = "" Then btnViewPassword.Visible = False
    End Sub
    Public Function LicenseCheck(ByVal fileName As String) As Boolean
        Dim decryptedString As String = String.Empty
        Dim DaysRemain As String = String.Empty
        Dim LicenseGenerate As String = String.Empty
        Dim Daysdiff As String = String.Empty
        Dim LictempMac As String = String.Empty
        Dim LicOSName As String = String.Empty
        Dim LichostName As String = String.Empty
        Dim LicmyIP As String = String.Empty
        Dim LicMotherBoardID As String = String.Empty
        Dim LicHardDiskID As String = String.Empty
        Dim ClsCommon As CommonClass = New CommonClass()
        Using sr As StreamReader = File.OpenText(fileName)
            Dim s As String = ""

            Do
                s = sr.ReadLine()

                If s Is Nothing Then Exit Do
                decryptedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(s))
                Dim LicenseValueList As String() = decryptedString.Split("$"c)
                DaysRemain = LicenseValueList(5).ToString().Split("|"c)(1)
                LicenseGenerate = LicenseValueList(6).ToString().Split("|"c)(1)
                LictempMac = LicenseValueList(1).ToString().Split("|"c)(1)
                LicOSName = LicenseValueList(4).ToString().Split("|"c)(1)
                LichostName = LicenseValueList(2).ToString().Split("|"c)(1)
                LicmyIP = LicenseValueList(3).ToString().Split("|"c)(1)
                LicMotherBoardID = LicenseValueList(7).ToString().Split("|"c)(1)
                LicHardDiskID = LicenseValueList(8).ToString().Split("|"c)(1)
                Daysdiff = (Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy")) - Convert.ToDateTime(LicenseGenerate.ToString())).TotalDays.ToString()
            Loop
        End Using
        If String.IsNullOrEmpty(DaysRemain) Or String.IsNullOrEmpty(LicenseGenerate) Then
            MsgBox("License is Invalid for this machine", MsgBoxStyle.Critical, "Invalid License")
            Return False

        End If

        If Convert.ToInt32(Daysdiff) > Convert.ToInt32(DaysRemain) Then
            MsgBox("Your License is expired", vbCritical, "Expired")
            ApplyLicenseKey.MdiParent = ShowCompanies
            ApplyLicenseKey.Show()
            If Not ApplyLicenseKey Is Nothing Then
                ApplyLicenseKey.BringToFront()
            End If
            Return False
        Else
            Dim tempMac As String = String.Empty
            Dim OSName As String = String.Empty
            Dim hostName As String = String.Empty
            Dim myIP As String = String.Empty
            Dim MotherBoardID As String = String.Empty
            Dim HardDiskID As String = String.Empty
            hostName = ClsCommon.GetHostName()
            myIP = ClsCommon.GetIPAddress()
            tempMac = ClsCommon.GetMacAddress()
            OSName = ClsCommon.GetOSName()
            MotherBoardID = ClsCommon.MotherboardSerialNumber()
            HardDiskID = ClsCommon.HardDiskSerialNumber()
            'If (hostName = LichostName And myIP = LicmyIP And tempMac = LictempMac And OSName = LicOSName) Then
            If (MotherBoardID = LicMotherBoardID And HardDiskID = LicHardDiskID) Then
                Return True
            Else
                MsgBox("License is Invalid for this machine", MsgBoxStyle.Critical, "Invalid License")
                Return False
            End If
        End If
    End Function

    Private Sub Login_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        rs.ResizeAllControls(Me)
    End Sub
End Class