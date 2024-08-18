Imports System.Management
Imports System.Text
Imports System.Configuration
Imports System.Xml
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class Report_Viewer
    Dim data As String = String.Empty
    Private Function GetData() As DataSet
        Dim sSql As String = "Select * from Printing"
        Dim ds As New DataSet
        ds = ClsFunPrimary.ExecDataSet(sSql, "Printing")
        GetData = ds
    End Function
    Sub printReport(ByRef reportname As String)
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Try
            Dim Rpt As New ReportDocument
            Rpt.Load(Application.StartupPath & reportname)
            CrTables = Rpt.Database.Tables
            For Each CrTable In CrTables
                crtableLogoninfo = CrTable.LogOnInfo
                crtableLogoninfo.ConnectionInfo = crConnectionInfo
                CrTable.ApplyLogOnInfo(crtableLogoninfo)
            Next
            Dim dsCustomers As DataSet = GetData()
            Rpt.SetDataSource(dsCustomers.Tables("Printing"))
            Rpt.SetParameterValue("CompName", compname)
            Rpt.SetParameterValue("Mob1", Mob1)
            Rpt.SetParameterValue("Mob2", Mob2)
            Rpt.SetParameterValue("Address", Address)
            Rpt.SetParameterValue("City", City)
            Rpt.SetParameterValue("State", StateName)
            'Rpt.SetParameterValue("AddressHindi", AddressHindi)
            'Rpt.SetParameterValue("CityHindi", CityHindi)
            'Rpt.SetParameterValue("StateHindi", StateHindi)
            'Rpt.SetParameterValue("HindiCompanyName", compnameHindi)
            CrystalReportViewer1.ReportSource = Rpt
            CrystalReportViewer1.Refresh()
            '  Rpt.PrintToPrinter(1, False, 0, 0)
            CrTables.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub printReportDirect(ByRef reportname As String)
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Try
            Dim Rpt As New ReportDocument
            Rpt.Load(Application.StartupPath & reportname)
            CrTables = Rpt.Database.Tables
            For Each CrTable In CrTables
                crtableLogoninfo = CrTable.LogOnInfo
                crtableLogoninfo.ConnectionInfo = crConnectionInfo
                CrTable.ApplyLogOnInfo(crtableLogoninfo)
            Next
            Dim dsCustomers As DataSet = GetData()
            Rpt.SetDataSource(dsCustomers.Tables("Printing"))
            Rpt.SetParameterValue("CompName", compname)
            Rpt.SetParameterValue("Mob1", Mob1)
            Rpt.SetParameterValue("Mob2", Mob2)
            Rpt.SetParameterValue("Address", Address)
            Rpt.SetParameterValue("City", City)
            Rpt.SetParameterValue("State", StateName)
            'Rpt.SetParameterValue("AddressHindi", AddressHindi)
            'Rpt.SetParameterValue("CityHindi", CityHindi)
            'Rpt.SetParameterValue("StateHindi", StateHindi)
            'Rpt.SetParameterValue("HindiCompanyName", compnameHindi)
            CrystalReportViewer1.ReportSource = Rpt
            CrystalReportViewer1.Refresh()
            Rpt.PrintToPrinter(1, False, 0, 0)
            CrTables.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Report_Viewer_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub
    Private Sub Report_Viewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0 : Me.Left = 0
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        ' printReport(reportname)
        CrystalReportViewer1.Zoom(100)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class