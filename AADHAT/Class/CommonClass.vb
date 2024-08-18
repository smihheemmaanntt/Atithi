Imports System.Net
Imports System.Management
Imports System.Data.SqlClient
Imports System.IO

Public Class CommonClass
    Public Function GetMacAddress() As String
        Dim qstring As String = "SELECT * FROM Win32_NetworkAdapterConfiguration where IPEnabled = true"
        For Each mo As System.Management.ManagementObject In New System.Management.ManagementObjectSearcher(qstring).Get()
            Dim macaddress As String = mo("MacAddress")
            If Not macaddress Is Nothing Then
                Return macaddress
            End If
        Next
        Return ""
    End Function

    Public Function GetHostName() As String
        Dim hostName As String = Dns.GetHostName()
        Return hostName
    End Function

    Public Function GetIPAddress() As String
        Dim hostName As String = Dns.GetHostName()
        Dim myIP As String = Dns.GetHostByName(hostName).AddressList(0).ToString()
        Return myIP
    End Function

    Public Function GetOSName() As String
        Dim Full_Os_Name As String = My.Computer.Info.OSFullName
        Return Full_Os_Name
    End Function

    Public Function IsInternetConnect() As Boolean
        Try
            If My.Computer.Network.IsAvailable = True Then
                Return True
            End If
        Catch
            Return False
        End Try
    End Function

    Public Function EnryptString(ByVal strEncrypted As String) As String
        Dim b As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted)
        Dim encrypted As String = Convert.ToBase64String(b)
        Return encrypted
    End Function

    Public Function MotherboardSerialNumber() As String
        Dim value As String = ""
        Dim baseBoard As ManagementClass = New ManagementClass("Win32_BaseBoard")
        Dim board As ManagementObjectCollection = baseBoard.GetInstances()
        If board.Count > 0 Then
            value = board(0)("SerialNumber")
            If value.Length > 0 Then value = value.Substring(2)
        End If
        Return value

    End Function

    Public Function HardDiskSerialNumber() As String
        Dim HDD_Serial As String
        Dim hdd As New ManagementObjectSearcher("select * from Win32_DiskDrive")
        For Each hd In hdd.Get
            HDD_Serial = hd("SerialNumber")
        Next
        Return HDD_Serial

    End Function

    Public Function UpdateCutomerInfo(ByVal Operation As String) As String
        Dim dts As New DataTable
        Dim decryptedString As String = String.Empty
        Dim CustID As Integer
        Dim LicenseKey As String = String.Empty
        Dim conn As SqlConnection
        Dim fileName As String = AppDomain.CurrentDomain.BaseDirectory & "accent.dll"
        ' clsFun.changeCompany()
        dts = clsFun.ExecDataTable("Select * From Company Where ID = " & Val(sCompCode) & "")
        Try
            If dts.Rows.Count > 0 Then
                CustID = Val(dts.Rows(0)("ID").ToString())
                LicenseKey = GetLicenseKey()
                conn = GetConnectionstring()
                conn.Open()
                Dim cmd As New SqlCommand("InsertingUpdating_customer", conn)
                Try
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.Add("@LicenseKey", SqlDbType.VarChar)
                    cmd.Parameters("@LicenseKey").Value = LicenseKey
                    cmd.Parameters.Add("@Operation", SqlDbType.VarChar)
                    cmd.Parameters("@Operation").Value = Operation
                    cmd.Parameters.Add("@CompanyID", SqlDbType.VarChar)
                    cmd.Parameters("@CompanyID").Value = CustID
                    cmd.Parameters.Add("@CompanyName", SqlDbType.VarChar)
                    cmd.Parameters("@CompanyName").Value = dts.Rows(0)("CompanyName").ToString()
                    cmd.Parameters.Add("@Address", SqlDbType.VarChar)
                    cmd.Parameters("@Address").Value = dts.Rows(0)("Address").ToString()
                    cmd.Parameters.Add("@City", SqlDbType.VarChar)
                    cmd.Parameters("@City").Value = dts.Rows(0)("City").ToString()
                    cmd.Parameters.Add("@State", SqlDbType.VarChar)
                    cmd.Parameters("@State").Value = dts.Rows(0)("State").ToString()
                    cmd.Parameters.Add("@StateCode", SqlDbType.VarChar)
                    cmd.Parameters("@StateCode").Value = 0
                    cmd.Parameters.Add("@MobileNo1", SqlDbType.VarChar)
                    cmd.Parameters("@MobileNo1").Value = dts.Rows(0)("MobileNo1").ToString()
                    cmd.Parameters.Add("@MobileNo2", SqlDbType.VarChar)
                    cmd.Parameters("@MobileNo2").Value = dts.Rows(0)("MobileNo2").ToString()
                    cmd.Parameters.Add("@PhoneNo", SqlDbType.VarChar)
                    cmd.Parameters("@PhoneNo").Value = dts.Rows(0)("PhoneNo").ToString()
                    cmd.Parameters.Add("@FaxNo", SqlDbType.VarChar)
                    cmd.Parameters("@FaxNo").Value = dts.Rows(0)("FaxNo").ToString()
                    cmd.Parameters.Add("@EmailID", SqlDbType.VarChar)
                    cmd.Parameters("@EmailID").Value = dts.Rows(0)("EmailID").ToString()
                    cmd.Parameters.Add("@Website", SqlDbType.VarChar)
                    cmd.Parameters("@Website").Value = dts.Rows(0)("Website").ToString()
                    cmd.Parameters.Add("@GSTN", SqlDbType.VarChar)
                    cmd.Parameters("@GSTN").Value = dts.Rows(0)("GSTN").ToString()
                    cmd.Parameters.Add("@RegistrationNo", SqlDbType.VarChar)
                    cmd.Parameters("@RegistrationNo").Value = dts.Rows(0)("RegistrationNo").ToString()
                    cmd.Parameters.Add("@PanNo", SqlDbType.VarChar)
                    cmd.Parameters("@PanNo").Value = dts.Rows(0)("PanNo").ToString()
                    cmd.Parameters.Add("@YearStart", SqlDbType.VarChar)
                    cmd.Parameters("@YearStart").Value = dts.Rows(0)("YearStart").ToString()
                    cmd.Parameters.Add("@Yearend", SqlDbType.VarChar)
                    cmd.Parameters("@Yearend").Value = dts.Rows(0)("Yearend").ToString()
                    cmd.Parameters.Add("@tag", SqlDbType.VarChar)
                    cmd.Parameters("@tag").Value = dts.Rows(0)("tag").ToString()
                    cmd.Parameters.Add("@ZipNo", SqlDbType.VarChar)
                    cmd.Parameters("@ZipNo").Value = 0
                    cmd.ExecuteNonQuery()
                Finally
                    If cmd IsNot Nothing Then cmd.Dispose()
                    If conn IsNot Nothing AndAlso conn.State <> ConnectionState.Closed Then conn.Close()
                End Try
            End If
            dts.Dispose()

        Catch ex As Exception
            MsgBox("Something went wrong", vbCritical, "Access Denied")
        End Try

        Return ""
    End Function

    Public Function IsLicenseBlocked() As Boolean
        Try
            If My.Computer.Network.IsAvailable = False Then
                Dim dt As New DataTable : ClsFunPrimary.changeCompany()
                dt = clsFun.ExecDataTable("select IsAssign from accent")
                Try
                    If dt.Rows.Count > 0 Then
                        If Convert.ToBoolean(dt.Rows(0)("IsAssign").ToString()) Then
                            Return True
                        Else
                            Return False
                        End If
                    End If
                Catch
                End Try
                Exit Function
            End If

            Try
                Dim strSql As String = "select IsBlocked from LicenseKeyDetails where LicenseKey='" + GetLicenseKey() + "'"
                Dim dtb As New DataTable
                Using cnn As New SqlConnection(Convert.ToString(GetConnectionstr()))
                    cnn.Open()
                    Using dad As New SqlDataAdapter(strSql, cnn)
                        dad.Fill(dtb)
                    End Using
                    cnn.Close()
                End Using

                If dtb.Rows.Count > 0 Then
                    'clsFun.changeCompany()
                    For Each dr As DataRow In dtb.Rows
                        If dr.Item("IsBlocked").ToString.Contains("True") Then

                            Dim sql As String = "Update accent SET IsAssign=1"
                            cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
                            ClsFunPrimary.ExecNonQuery(sql)
                            Return True
                        Else
                            Dim sql As String = "Update accent SET IsAssign=0"
                            cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
                            ClsFunPrimary.ExecNonQuery(sql)
                            Return False
                        End If
                    Next
                End If
            Catch
            End Try
        Catch
            Dim dt As New DataTable
            dt = ClsFunPrimary.ExecDataTable("select IsAssign from accent")
            Try
                If dt.Rows.Count > 0 Then
                    If Convert.ToBoolean(dt.Rows(0)("IsAssign").ToString()) Then
                        Return True
                    Else
                        Return False
                    End If

                End If
            Catch
            End Try
        End Try
    End Function

    Public Function GetLicenseKey() As String
        Dim LicenseKey As String = String.Empty
        Dim decryptedString As String = String.Empty
        Dim fileName As String = AppDomain.CurrentDomain.BaseDirectory & "accent.dll"
        Using sr As StreamReader = File.OpenText(fileName)
            Dim s As String = ""
            Do
                s = sr.ReadLine()
                If s Is Nothing Then Exit Do
                decryptedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(s))
                Dim LicenseValueList As String() = decryptedString.Split("$"c)
                LicenseKey = LicenseValueList(0).ToString().Split("|"c)(1)
            Loop
        End Using
        Return LicenseKey
    End Function

    Public Function GetConnectionstr() As String
        Dim conn As String
        conn = "Data Source=103.199.214.72;Initial Catalog=smicloud_smilic;Persist Security Info=True;User ID=smiadmin;Password=admin@123"
        Return conn
    End Function

    Public Function GetConnectionstring() As SqlConnection
        Dim conn As SqlConnection
        conn = New SqlConnection("Data Source=103.199.214.72;Initial Catalog=smicloud_smilic;Persist Security Info=True;User ID=smiadmin;Password=admin@123")
        Return conn
    End Function

    Public Function GetNewConnection() As SqlConnection
        Dim conn As SqlConnection
        conn = New SqlConnection("Data Source=103.199.214.72;Initial Catalog=smicloud_Aadhat;Persist Security Info=True;User ID=smiadmin;Password=admin@123")
        Return conn
    End Function

    Public Function GenrateID()
        Dim conn As SqlConnection
        conn = GetConnectionstring()
        Dim rnd As New Random()
        Mobile_App.txtCompanyID.Text = (rnd.Next(100000, 999999))
        If clsFun.ExecScalarInt("Select OrganizationID From Company  WHERE OrganizationID='" & Mobile_App.txtCompanyID.Text & "'") > 1 Then
            Mobile_App.txtCompanyID.Text = (rnd.Next(100000, 999999))
        End If
    End Function

    Public Function UpdateCompanyInfo(ByVal Operation As String) As String
        Dim dts As New DataTable
        Dim decryptedString As String = String.Empty
        Dim CustID As Integer
        Dim LicenseKey As String = String.Empty
        Dim conn As SqlConnection
        Dim fileName As String = AppDomain.CurrentDomain.BaseDirectory & "accent.dll"
        '  clsFun.ChangePath(Data)
        dts = clsFun.ExecDataTable("Select * From Company Where OrganizationID = " & Val(Mobile_App.txtCompanyID.Text) & "")
        Try
            If dts.Rows.Count > 0 Then
                CustID = Val(dts.Rows(0)("ID").ToString())
                LicenseKey = GetLicenseKey()
                conn = GetNewConnection()
                conn.Open()
                Dim cmd As New SqlCommand("InsertingUpdating_customer", conn)
                Try
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.Add("@LicenseKey", SqlDbType.VarChar)
                    cmd.Parameters("@LicenseKey").Value = LicenseKey
                    cmd.Parameters.Add("@Operation", SqlDbType.VarChar)
                    cmd.Parameters("@Operation").Value = Operation
                    cmd.Parameters.Add("@CompanyID", SqlDbType.VarChar)
                    cmd.Parameters("@CompanyID").Value = CustID
                    cmd.Parameters.Add("@CompanyName", SqlDbType.VarChar)
                    cmd.Parameters("@CompanyName").Value = dts.Rows(0)("CompanyName").ToString()
                    cmd.Parameters.Add("@Address", SqlDbType.VarChar)
                    cmd.Parameters("@Address").Value = dts.Rows(0)("Address").ToString()
                    cmd.Parameters.Add("@City", SqlDbType.VarChar)
                    cmd.Parameters("@City").Value = dts.Rows(0)("City").ToString()
                    cmd.Parameters.Add("@State", SqlDbType.VarChar)
                    cmd.Parameters("@State").Value = dts.Rows(0)("State").ToString()
                    cmd.Parameters.Add("@StateCode", SqlDbType.VarChar)
                    cmd.Parameters("@StateCode").Value = 0
                    cmd.Parameters.Add("@MobileNo1", SqlDbType.VarChar)
                    cmd.Parameters("@MobileNo1").Value = dts.Rows(0)("MobileNo1").ToString()
                    cmd.Parameters.Add("@MobileNo2", SqlDbType.VarChar)
                    cmd.Parameters("@MobileNo2").Value = dts.Rows(0)("MobileNo2").ToString()
                    cmd.Parameters.Add("@PhoneNo", SqlDbType.VarChar)
                    cmd.Parameters("@PhoneNo").Value = dts.Rows(0)("PhoneNo").ToString()
                    cmd.Parameters.Add("@FaxNo", SqlDbType.VarChar)
                    cmd.Parameters("@FaxNo").Value = dts.Rows(0)("FaxNo").ToString()
                    cmd.Parameters.Add("@EmailID", SqlDbType.VarChar)
                    cmd.Parameters("@EmailID").Value = dts.Rows(0)("EmailID").ToString()
                    cmd.Parameters.Add("@Website", SqlDbType.VarChar)
                    cmd.Parameters("@Website").Value = dts.Rows(0)("Website").ToString()
                    cmd.Parameters.Add("@GSTN", SqlDbType.VarChar)
                    cmd.Parameters("@GSTN").Value = dts.Rows(0)("GSTN").ToString()
                    cmd.Parameters.Add("@RegistrationNo", SqlDbType.VarChar)
                    cmd.Parameters("@RegistrationNo").Value = dts.Rows(0)("RegistrationNo").ToString()
                    cmd.Parameters.Add("@PanNo", SqlDbType.VarChar)
                    cmd.Parameters("@PanNo").Value = dts.Rows(0)("PanNo").ToString()
                    cmd.Parameters.Add("@YearStart", SqlDbType.VarChar)
                    cmd.Parameters("@YearStart").Value = dts.Rows(0)("YearStart").ToString()
                    cmd.Parameters.Add("@Yearend", SqlDbType.VarChar)
                    cmd.Parameters("@Yearend").Value = dts.Rows(0)("Yearend").ToString()
                    cmd.Parameters.Add("@tag", SqlDbType.VarChar)
                    cmd.Parameters("@tag").Value = dts.Rows(0)("tag").ToString()
                    cmd.Parameters.Add("@ZipNo", SqlDbType.VarChar)
                    cmd.Parameters("@ZipNo").Value = 0
                    cmd.Parameters.Add("@OrganisationID", SqlDbType.Int)
                    cmd.Parameters("@OrganisationID").Value = dts.Rows(0)("OrganisationID").ToString()
                    cmd.ExecuteNonQuery()
                Finally
                    If cmd IsNot Nothing Then cmd.Dispose()
                    If conn IsNot Nothing AndAlso conn.State <> ConnectionState.Closed Then conn.Close()
                End Try
            End If
            dts.Dispose()

        Catch ex As Exception
            MsgBox("Something went wrong", vbCritical, "Access Denied")
        End Try

        Return ""
    End Function
End Class
