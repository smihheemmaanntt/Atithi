Public Class ActivationForm

    Private Sub ActivationForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackColor = Color.Moccasin
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Dim serial As Long
        Dim sm As New SecurityManager
        serial = sm.GetSerial
        txtSerial.Text = serial
        If txtSerial.Text = "0" Then
            lblWarning.ForeColor = Color.Red
            lblWarning.Text = "Internet Required..."
        Else
            lblWarning.ForeColor = Color.Green
            lblWarning.Text = "Internet Active..."
        End If
        txtKey.Focus()
    End Sub

    Private Sub btnActivate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnActivate.Click
        Dim key As Long
        If txtSerial.Text = "0" Then
            MsgBox("Internet Not Active Please active internet on this sytem and Try again...", MsgBoxStyle.Exclamation, "Access Denied")
        Else
            If Not Long.TryParse(txtKey.Text, key) Then
                MsgBox("Invallied Key...", MsgBoxStyle.Exclamation, "Access Denied")
                txtKey.Text = ""
                txtKey.Focus()
                Exit Sub
            End If
            Dim sm As New SecurityManager
            If sm.CheckKey(key) Then
                save()
            Else
                MsgBox("Invallied Key...", MsgBoxStyle.Critical, "Access Denied")
                txtKey.Text = ""
                txtKey.Focus()
            End If
        End If
    End Sub
    Private Sub save()
        Dim cmd As New SQLite.SQLiteCommand
        ' Dim sql As String = "insert into AccountGroup(GroupName, UnderGrpID, DC, Isprimary,ISCHNGDEL)values (@1, @2, @3, @4,@5)"
        Dim sql As String = "insert into CompanyDetails (x,y) values (@1,@2)"
        Try
            cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
            cmd.Parameters.AddWithValue("@1", txtSerial.Text)
            cmd.Parameters.AddWithValue("@2", txtKey.Text)

            If cmd.ExecuteNonQuery() > 0 Then
                MsgBox("Software Registered Successfully.", MsgBoxStyle.Information, "Successfull")
            End If
            clsFun.CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message)
            clsFun.CloseConnection()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        txtKey.Text = ""
        txtKey.Focus()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Me.Refresh()
        Dim serial As Long
        Dim sm As New SecurityManager
        serial = sm.GetSerial
        txtSerial.Text = serial
        If txtSerial.Text = "0" Then
            lblWarning.ForeColor = Color.Red
            lblWarning.Text = "Internet Required..."
        Else
            lblWarning.ForeColor = Color.Green
            lblWarning.Text = "Internet Active..."
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class
