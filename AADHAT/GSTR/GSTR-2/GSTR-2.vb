Public Class GSTR_2

    Private Sub GSTR_2_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub GSTR_1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Me.Top = "0.5" : Me.Left = "179"
        Me.BackColor = Color.DarkTurquoise
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GSTR2_Supplies_From_Unregsiter.MdiParent = MainScreenForm
        GSTR2_Supplies_From_Unregsiter.Show()
        If Not GSTR2_Supplies_From_Unregsiter Is Nothing Then
            GSTR2_Supplies_From_Unregsiter.BringToFront()
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        GSTR2_Supplies_From_Regsitered.MdiParent = MainScreenForm
        GSTR2_Supplies_From_Regsitered.Show()
        If Not GSTR2_Supplies_From_Regsitered Is Nothing Then
            GSTR2_Supplies_From_Regsitered.BringToFront()
        End If
    End Sub
End Class