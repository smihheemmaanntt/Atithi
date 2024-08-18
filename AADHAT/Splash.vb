Imports System.IO

Public Class Splash

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Value += 1
        If ProgressBar1.Value <= 4 Then
            Label4.Text = "Loading System......."
        ElseIf ProgressBar1.Value <= 8 Then
            Label4.Text = "Checking Companies..."
        ElseIf ProgressBar1.Value <= 12 Then
            Label4.Text = "Checking Database...."
        ElseIf ProgressBar1.Value <= 16 Then
            Label4.Text = "Just Wait.Almost Done"
        ElseIf ProgressBar1.Value <= 20 Then
            Label4.Text = "Welcome to aadhat...."
            If ProgressBar1.Value = 20 Then
                '' CreateSqlLite()
                Me.Dispose()
                ShowCompanies.Show()
                Timer1.Dispose()
                'ShowCompanies.Show()

                ''Me.Hide()
            End If
        End If

    End Sub

    Private Sub Splash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ProgressBar1.Visible = False
        Label4.TextAlign = ContentAlignment.MiddleCenter
    End Sub
End Class
