Imports System.Management
Imports System.Text
Imports System.Configuration
Imports System.Xml
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class Print_Outstanding
    Dim data As String = String.Empty
    Private Function GetData() As DataSet
        Dim sSql As String = "Select * from Printing"
        Dim ds As New DataSet
        ds = clsFun.ExecDataSet(sSql, "Printing")
        GetData = ds
    End Function
    Sub printReport()
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Try
            Dim Rpt As New ReportDocument
            Rpt.Load(Application.StartupPath & "\Outstanding.rpt")
            CrTables = Rpt.Database.Tables
            For Each CrTable In CrTables
                crtableLogoninfo = CrTable.LogOnInfo
                crtableLogoninfo.ConnectionInfo = crConnectionInfo
                CrTable.ApplyLogOnInfo(crtableLogoninfo)
            Next
            Dim dsCustomers As DataSet = GetData()
            Rpt.SetDataSource(dsCustomers.Tables("Printing"))
            Rpt.SetParameterValue("CompName", compname)
            CrystalReportViewer1.ReportSource = Rpt
            CrystalReportViewer1.Refresh()
            CrTables.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Print_Outstanding_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    
    End Sub

    Private Sub Print_Outstanding_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub
    Private Sub Print_Outstanding_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        me.Top = 0
        Me.Left = 0
        Me.BackColor = Color.GhostWhite
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        printReport()
        CrystalReportViewer1.Zoom(100)
        If data <> "" Then
            isCompanyOpen = True
            clsFun.ChangePath("Data\" & data)
        End If
    End Sub
End Class