Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class AccountListPrint
    Sub printReport()
        'Dim Rpt As New ReportDocument
        'Rpt.Load(Application.StartupPath & "\AccountMaster.rpt")
        'Rpt.SetDatabaseLogon("sa", "123", "Tiya-pc", "LoanDb")
        'CrystalReportViewer1.ReportSource = Rpt
        Dim crystalReport As New ReportDocument()
        crystalReport.Load(Application.StartupPath & "\CompanyMaster.rpt")
        Dim dsCustomers As DataSet = GetData()
        crystalReport.SetDataSource(dsCustomers)
        CrystalReportViewer1.ReportSource = crystalReport
    End Sub

    Private Sub AccountListPrint_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub AccountListPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        printReport()
        Me.KeyPreview = True
    End Sub
    Private Function GetData() As DataSet
        Dim sSql As String = "Select * From Accounts"
        Dim ds As New DataSet
        ds = clsFun.ExecDataSet(sSql)
        GetData = ds
    End Function
End Class