Public Class CustomMsgBox

    Private Sub CustomMsgBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
    End Sub
   Public Function ShowCustomMessageBox(ByVal message As String, ByVal caption As String, ByVal icon As MessageBoxIcon, ByVal buttons As MessageBoxButtons) As DialogResult
        lblMessage.Text = message
        Me.Text = caption
        Select Case icon
            Case MessageBoxIcon.Error
                picIcon.Image = SystemIcons.Error.ToBitmap()
            Case MessageBoxIcon.Information
                picIcon.Image = SystemIcons.Information.ToBitmap()
            Case MessageBoxIcon.Question
                picIcon.Image = SystemIcons.Question.ToBitmap()
            Case MessageBoxIcon.Warning
                picIcon.Image = SystemIcons.Warning.ToBitmap()
        End Select
        Select Case buttons
            Case MessageBoxButtons.OK
                btnOK.Visible = True
            Case MessageBoxButtons.OKCancel
                btnOK.Visible = True
                btnCancel.Visible = True
            Case MessageBoxButtons.YesNo
                BtnYes.Visible = True
                BtnYes.Focus()
                BtnNo.ForeColor = Color.FromArgb(255, 51, 153, 255)
                BtnNo.BackColor = Color.Transparent
                btnNo.Visible = True
            Case MessageBoxButtons.YesNoCancel
                btnYes.Visible = True
                btnNo.Visible = True
                btnCancel.Visible = True
        End Select
        Me.ShowDialog()
        SendKeys.Send("%")
        If btnOK.Visible AndAlso btnOK.DialogResult = Windows.Forms.DialogResult.OK Then
            Return Windows.Forms.DialogResult.OK
        ElseIf btnCancel.Visible AndAlso btnCancel.DialogResult = Windows.Forms.DialogResult.Cancel Then
            Return Windows.Forms.DialogResult.Cancel
        ElseIf btnYes.Visible AndAlso btnYes.DialogResult = Windows.Forms.DialogResult.Yes Then
            Return Windows.Forms.DialogResult.Yes
        ElseIf btnNo.Visible AndAlso btnNo.DialogResult = Windows.Forms.DialogResult.No Then
            Return Windows.Forms.DialogResult.No
        Else
            Return Windows.Forms.DialogResult.None
        End If
    End Function

    Private Sub BtnYes_Click(sender As Object, e As EventArgs) Handles BtnYes.Click
        Me.DialogResult = DialogResult.Yes
        Me.Close()
    End Sub

    Private Sub BtnNo_Click(sender As Object, e As EventArgs) Handles BtnNo.Click

    End Sub

    Private Sub BtnNo_GotFocus(sender As Object, e As EventArgs) Handles BtnNo.GotFocus
        BtnNo.ForeColor = Color.Transparent
        BtnNo.BackColor = Color.FromArgb(255, 51, 153, 255)
        BtnYes.ForeColor = Color.FromArgb(255, 51, 153, 255)
        BtnYes.BackColor = Color.Transparent
    End Sub

    Private Sub BtnYes_GotFocus(sender As Object, e As EventArgs) Handles BtnYes.GotFocus
        BtnYes.BackColor = Color.FromArgb(255, 51, 153, 255) 'Color.Transparent
        BtnYes.ForeColor = Color.Transparent
        BtnNo.ForeColor = Color.FromArgb(255, 51, 153, 255)
        BtnNo.BackColor = Color.Transparent 'Color.FromArgb(255, 51, 153, 255)

    End Sub
End Class