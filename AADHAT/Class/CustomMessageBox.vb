Public Class CustomMessageBox
    Public Shared Function ShowCustomMessageBox(ByVal senderForm As Form, ByVal messageText As String, ByVal messageTitle As String, ByVal messageIcon As MessageBoxIcon, ByVal buttons As MessageBoxButtons) As DialogResult
        Dim customMessageBox As New Form()
        customMessageBox.Text = messageTitle
        customMessageBox.FormBorderStyle = FormBorderStyle.FixedDialog
        customMessageBox.ControlBox = False
        customMessageBox.MaximizeBox = False
        customMessageBox.MinimizeBox = False
        customMessageBox.StartPosition = FormStartPosition.CenterScreen
        customMessageBox.BackColor = Color.White

        Dim label As New Label()
        label.Text = messageText
        label.AutoSize = True
        label.Location = New Point(70, 30)
        label.ForeColor = Color.Navy

        Dim yesButton As New Button()
        yesButton.Text = "&Print"
        yesButton.DialogResult = DialogResult.Yes
        yesButton.Location = New Point(20, 80)
        yesButton.ForeColor = Color.Navy
        yesButton.FlatStyle = FlatStyle.Flat


        Dim noButton As New Button()
        noButton.Text = "Pre&view"
        noButton.DialogResult = DialogResult.No
        noButton.Location = New Point(100, 70)
        noButton.ForeColor = Color.Navy
        noButton.FlatStyle = FlatStyle.Flat

        Dim cancelButton As New Button()
        cancelButton.Text = "&Whatsapp"
        cancelButton.DialogResult = DialogResult.Cancel
        cancelButton.Location = New Point(180, 70)
        cancelButton.ForeColor = Color.Navy
        cancelButton.FlatStyle = FlatStyle.Flat

        Dim AbortButton As New Button()
        AbortButton.Text = "&Cancel"
        AbortButton.DialogResult = DialogResult.Abort
        AbortButton.Location = New Point(260, 70)
        AbortButton.ForeColor = Color.Red
        AbortButton.FlatStyle = FlatStyle.Flat
        Dim iconPictureBox As New PictureBox()
        iconPictureBox.Location = New Point(20, 20)
        iconPictureBox.Size = New Size(48, 48)

        customMessageBox.ClientSize = New Size(350, 110)
        customMessageBox.Controls.Add(label)
        customMessageBox.Controls.Add(yesButton)
        customMessageBox.Controls.Add(noButton)
        customMessageBox.Controls.Add(cancelButton)
        customMessageBox.Controls.Add(AbortButton)
        customMessageBox.Controls.Add(iconPictureBox)

        ' Set the icon based on your requirement
        Select Case messageIcon
            Case MessageBoxIcon.Information
                iconPictureBox.Image = SystemIcons.Information.ToBitmap()
            Case MessageBoxIcon.Question
                iconPictureBox.Image = SystemIcons.Question.ToBitmap()
            Case MessageBoxIcon.Warning
                iconPictureBox.Image = SystemIcons.Warning.ToBitmap()
            Case MessageBoxIcon.Error
                iconPictureBox.Image = SystemIcons.Error.ToBitmap()
        End Select

        ' Set the buttons based on your requirement
        Select Case buttons
            Case MessageBoxButtons.YesNoCancel
                yesButton.Visible = True
                noButton.Visible = True
                cancelButton.Visible = True
                AbortButton.Visible = True
                yesButton.Location = New Point(20, 70)
                noButton.Location = New Point(100, 70)
                cancelButton.Location = New Point(180, 70)
                AbortButton.Location = New Point(260, 70)
            Case MessageBoxButtons.YesNo
                yesButton.Visible = True
                noButton.Visible = True
                cancelButton.Visible = False
                yesButton.Location = New Point(70, 70)
                noButton.Location = New Point(150, 70)
            Case MessageBoxButtons.OK
                yesButton.Visible = False
                noButton.Visible = False
                cancelButton.Visible = True
                cancelButton.Location = New Point(95, 70)
            Case Else
                yesButton.Visible = True
                noButton.Visible = True
                cancelButton.Visible = True
                yesButton.Location = New Point(20, 70)
                noButton.Location = New Point(100, 70)
                cancelButton.Location = New Point(180, 70)
        End Select

        Dim result As DialogResult = customMessageBox.ShowDialog(senderForm)

        Return result
    End Function
    Public Enum MessageBoxButtons
        OK
        OKCancel
        YesNo
        YesNoCancel
    End Enum

End Class
