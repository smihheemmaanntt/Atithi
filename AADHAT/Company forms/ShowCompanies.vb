Option Strict Off
Option Explicit On
Imports System.IO
Imports System.Reflection

Friend Class ShowCompanies
    Inherits System.Windows.Forms.Form
    Dim rs As New Resizer
    Private Sub ShowCompanies_ForeColorChanged(sender As Object, e As EventArgs) Handles Me.ForeColorChanged

    End Sub

    Private Sub ShowCompanies_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        clsFun.changeCompany()
        Application.Exit()
    End Sub

    Private Sub ShowCompanies_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F3 Then
            Create_Company.MdiParent = Me
            Create_Company.Show()
            If Not Create_Company Is Nothing Then
                Create_Company.BringToFront()
            End If
        End If
    End Sub

    Private Sub ShowCompanies_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim fecha As Date = IO.File.GetCreationTime(Assembly.GetExecutingAssembly().Location)
        Me.Text = "[Atithi #" & CDate(fecha).ToString("yyMMddhhmm")
        CompanyList.MdiParent = Me
        CompanyList.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ShowCompanies_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        '    rs.ResizeAllControls(Me)
    End Sub

    Private Sub UpdateDatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ModifyCompanyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModifyCompanyToolStripMenuItem.Click
        Create_Company.MdiParent = Me
        Create_Company.Show()
        If CompanyList.dg1.SelectedRows.Count = 0 Then Exit Sub
        Dim tmpid As Integer = Val(CompanyList.dg1.SelectedRows(0).Cells(0).Value)
        Create_Company.FillContros(tmpid)
        If Not Create_Company Is Nothing Then
            Create_Company.BringToFront()
        End If
    End Sub

    Private Sub CreateCompanyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateCompanyToolStripMenuItem.Click
        Create_Company.MdiParent = Me
        Create_Company.Show()
        If Not Create_Company Is Nothing Then
            Create_Company.BringToFront()
        End If
    End Sub

    Private Sub RunQueryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RunQueryToolStripMenuItem.Click
        Query_Maker.MdiParent = Me
        Query_Maker.Show()
        Query_Maker.BringToFront()
    End Sub

    Private Sub ChangeFinanacialYearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeFinanacialYearToolStripMenuItem.Click
        Change_Financial_Year.MdiParent = Me
        Change_Financial_Year.Show()
        If Not Change_Financial_Year Is Nothing Then
            Change_Financial_Year.BringToFront()
        End If
    End Sub
End Class
