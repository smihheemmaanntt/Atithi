Public Class Query_Maker

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim sql As String = String.Empty
        If RtxtQuery.Text = "" Then MsgBox("please Insert Valid Sqlite Query ") : Exit Sub
        sql = RtxtQuery.Text
        If clsFun.ExecNonQuery(sql) > 0 Then
            MsgBox("Query Successful Updated...", MsgBoxStyle.Information, "Sucessful")
        End If
    End Sub
End Class