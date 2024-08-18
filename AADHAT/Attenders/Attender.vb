Public Class Attender

    Private Sub Attender_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub Attender_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0 : Me.Left = 0
        Me.BackColor = Color.FromArgb(169, 223, 191)
        Me.KeyPreview = True
        mskDOB.Text = Date.Today.ToString("dd-MM-yyyy")
        mskJoining.Text = Date.Today.ToString("dd-MM-yyyy")
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        AppLogin()
    End Sub
    Private Sub AppLogin()
        If txtAttenderCode.Text.Trim = "" Then
            txtAttenderCode.Text = 1000 & +Val(clsFun.ExecScalarInt("SELECT Max(ID) AS ID FROM Attender Where  ID= (Select mAX(ID) from Attender)"))
        End If
    End Sub
    Private Sub Update()
        Dim sql As String = String.Empty
        Dim Dob As String : Dim JoiningDate As String
        Dob = CDate(mskDOB.Text).ToString("yyyy-MM-dd")
        JoiningDate = CDate(mskJoining.Text).ToString("yyyy-MM-dd")
        If txtAttenderName.Text = "" Then
            txtAttenderName.Focus()
            MsgBox("Attender / Waiter Name is Emply...Please Fill Attender / Waiter Name... ", MsgBoxStyle.Critical, "Empty Item")
            Exit Sub
        End If
        Dim count As Integer = 0
        Dim cmd As SQLite.SQLiteCommand
        sql = "Update Attender Set AttenderName='" & txtAttenderName.Text & "',DOB='" & Dob & "',DOJ='" & JoiningDate & "',Add1= '" & txtAddress1.Text & "', Add2='" & txtAddress2.Text & "', " _
      & " City='" & txtCity.Text & "', State='" & txtState.Text & "',Mobile1='" & txtMobile1.Text & "',Mobile2='" & txtMobile2.Text & "',AlternetAddress1='" & txtAlterNetAdd1.Text & "', " _
      & "alternetAddress2='" & txtAlterNetadd2.Text & "', AlternetCity='" & txtAlterNetCity.Text & "',AlternetState='" & txtAlterNetState.Text & "',GuarntorName='" & txtGuarantorName.Text & "', " _
      & "GuarantorAddress='" & txtGuarntorAddress.Text & "',GaurantorCity='" & txtGurantorCity.Text & "',GaurantorState='" & txtGuarantorState.Text & "',GaurantorMob1='" & txtGaurantorMobile1.Text & "', " _
      & "GaurantorMob2='" & txtGaurantorMobile2.Text & "',AttenderCOde='" & txtAttenderCode.Text & "',Password='" & txtApppasword.Text & "' Where ID=" & Val(txtID.Text) & ""
        Try
            If clsFun.ExecNonQuery(sql) > 0 Then
                MsgBox("Record Updated Successfully.", vbInformation + vbOKOnly, "Updated")
                txtclear()
            End If
        Catch ex As Exception
            clsFun.CloseConnection()
        End Try
    End Sub
    Private Sub txtclear()
        txtAttenderName.Clear() : txtAddress1.Clear()
        txtAddress2.Clear() : txtCity.Clear()
        txtState.Clear() : txtMobile1.Clear()
        txtMobile2.Clear() : txtAlterNetAdd1.Clear()
        txtAlterNetadd2.Clear() : txtAlterNetCity.Clear()
        txtAlterNetState.Clear() : txtGuarantorName.Clear()
        txtGuarntorAddress.Clear() : txtGurantorCity.Clear()
        txtGuarantorState.Clear() : txtGaurantorMobile1.Clear()
        txtGaurantorMobile2.Clear() : txtAttenderName.Focus()
        mskDOB.Text = Date.Today.ToString("dd-MM-yyyy")
        mskJoining.Text = Date.Today.ToString("dd-MM-yyyy")
        BtnSave.Text = "&Save"
    End Sub
    Private Sub Save()
        ' Change the format Dob:
        Dim Dob As String = String.Empty : Dim JoiningDate As String = String.Empty
        Dob = CDate(mskDOB.Text).ToString("yyyy-MM-dd")
        JoiningDate = CDate(mskJoining.Text).ToString("yyyy-MM-dd")
        If txtAttenderName.Text = "" Then
            txtAttenderName.Focus()
            MsgBox("Attender / Waiter Name is Emply...Please Fill Attender / Waiter Name... ", MsgBoxStyle.Exclamation, "Empty Item")
            Exit Sub
        End If

        Dim sql As String = String.Empty
        Dim cmd As SQLite.SQLiteCommand
        sql = "insert into Attender(AttenderName,DOB,DOJ,Add1, Add2, " _
            & " City, State,Mobile1,Mobile2,AlternetAddress1,alternetAddress2, " _
            & " AlternetCity,AlternetState,GuarntorName,GuarantorAddress,GaurantorCity,GaurantorState,GaurantorMob1,GaurantorMob2,AttenderCode,Password) " _
            & " values (@1, @2, @3, @4, @5, @6, @7, @8,@9, @10, @11, @12, @13, @14, @15, @16, @17, @18, @19,@20,@21)"
        Try
            cmd = New SQLite.SQLiteCommand(sql, clsFun.GetConnection())
            cmd.Parameters.AddWithValue("@1", txtAttenderName.Text)
            cmd.Parameters.AddWithValue("@2", Dob)
            cmd.Parameters.AddWithValue("@3", JoiningDate)
            cmd.Parameters.AddWithValue("@4", txtAddress1.Text)
            cmd.Parameters.AddWithValue("@5", txtAddress2.Text)
            cmd.Parameters.AddWithValue("@6", txtCity.Text)
            cmd.Parameters.AddWithValue("@7", txtState.Text)
            cmd.Parameters.AddWithValue("@8", txtMobile1.Text)
            cmd.Parameters.AddWithValue("@9", txtMobile2.Text)
            cmd.Parameters.AddWithValue("@10", txtAlterNetAdd1.Text)
            cmd.Parameters.AddWithValue("@11", txtAlterNetadd2.Text)
            cmd.Parameters.AddWithValue("@12", txtAlterNetCity.Text)
            cmd.Parameters.AddWithValue("@13", txtAlterNetState.Text)
            cmd.Parameters.AddWithValue("@14", txtGuarantorName.Text)
            cmd.Parameters.AddWithValue("@15", txtGuarntorAddress.Text)
            cmd.Parameters.AddWithValue("@16", txtGurantorCity.Text)
            cmd.Parameters.AddWithValue("@17", txtGuarantorState.Text)
            cmd.Parameters.AddWithValue("@18", txtGaurantorMobile1.Text)
            cmd.Parameters.AddWithValue("@19", txtGaurantorMobile2.Text)
            cmd.Parameters.AddWithValue("@20", txtAttenderCode.Text)
            cmd.Parameters.AddWithValue("@21", txtApppasword.Text)
            If cmd.ExecuteNonQuery() > 0 Then
                MsgBox("Record Saved Successfully.", vbInformation + vbOKOnly, "Saved")
                txtclear()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            clsFun.CloseConnection()
        End Try
    End Sub
    Public Sub FillControls(ByVal id As Integer)
        LblName.Text = "MODIFY ATTENDER"
        btnDelete.Visible = True
        BtnSave.Text = "&Update"
        '  Panel1.BackColor = Color.PaleVioletRed
        If clsFun.GetConnection.State = ConnectionState.Open Then clsFun.CloseConnection()
        sSql = "Select * from Attender where id=" & id
        clsFun.con.Open()
        Dim ad As New SQLite.SQLiteDataAdapter(sSql, clsFun.GetConnection)
        Dim ds As New DataSet
        ad.Fill(ds, "a")
        If ds.Tables("a").Rows.Count > 0 Then
            txtID.Text = ds.Tables("a").Rows(0)("ID").ToString()
            txtAttenderName.Text = ds.Tables("a").Rows(0)("AttenderName").ToString()
            mskDOB.Text = Format(ds.Tables("a").Rows(0)("Dob"), "dd-MM-yyyy")
            mskJoining.Text = Format(ds.Tables("a").Rows(0)("doj"), "dd-MM-yyyy")
            txtAddress1.Text = ds.Tables("a").Rows(0)("Add1").ToString()
            txtAddress2.Text = ds.Tables("a").Rows(0)("Add2").ToString()
            txtCity.Text = ds.Tables("a").Rows(0)("City").ToString()
            txtState.Text = ds.Tables("a").Rows(0)("State").ToString()
            txtMobile1.Text = ds.Tables("a").Rows(0)("Mobile1").ToString()
            txtMobile2.Text = ds.Tables("a").Rows(0)("Mobile2").ToString()
            txtAlterNetAdd1.Text = ds.Tables("a").Rows(0)("AlternetAddress1").ToString()
            txtAlterNetadd2.Text = ds.Tables("a").Rows(0)("alternetAddress2").ToString()
            txtAlterNetCity.Text = ds.Tables("a").Rows(0)("AlternetCity").ToString()
            txtAlterNetState.Text = ds.Tables("a").Rows(0)("AlternetState").ToString()
            txtGuarantorName.Text = ds.Tables("a").Rows(0)("GuarntorName").ToString()
            txtGuarntorAddress.Text = ds.Tables("a").Rows(0)("GuarantorAddress").ToString()
            txtGurantorCity.Text = ds.Tables("a").Rows(0)("GaurantorCity").ToString()
            txtGuarantorState.Text = ds.Tables("a").Rows(0)("GaurantorState").ToString()
            txtGaurantorMobile1.Text = ds.Tables("a").Rows(0)("GaurantorMob1").ToString()
            txtGaurantorMobile2.Text = ds.Tables("a").Rows(0)("GaurantorMob2").ToString()
            txtAttenderCode.Text = ds.Tables("a").Rows(0)("AttenderCode").ToString()
            txtApppasword.Text = ds.Tables("a").Rows(0)("Password").ToString()

        End If
    End Sub

    Private Sub mskDOB_GotFocus(sender As Object, e As EventArgs) Handles mskDOB.GotFocus, mskDOB.Click
        mskDOB.SelectAll()
    End Sub

    Private Sub mskJoining_GotFocus(sender As Object, e As EventArgs) Handles mskJoining.GotFocus, mskJoining.Click
        mskJoining.SelectAll()
    End Sub
    Private Sub txtAttenderName_GotFocus(sender As Object, e As EventArgs) Handles txtAttenderName.GotFocus,
        txtAddress1.GotFocus, txtAddress2.GotFocus, txtMobile1.GotFocus, txtMobile2.GotFocus, txtCity.GotFocus, txtState.GotFocus,
        txtAlterNetAdd1.GotFocus, txtAlterNetadd2.GotFocus, txtAlterNetCity.GotFocus, txtAlterNetState.GotFocus, txtGuarantorName.GotFocus,
        txtGuarntorAddress.GotFocus, txtGurantorCity.GotFocus, txtGuarantorState.GotFocus, txtGaurantorMobile1.GotFocus, txtGaurantorMobile2.GotFocus
        Dim tb As TextBox = CType(sender, TextBox)
        tb.SelectAll()
    End Sub
    Private Sub mskEntryDate_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAttenderName.KeyDown, mskDOB.KeyDown,
  mskJoining.KeyDown, txtAddress1.KeyDown, txtAddress2.KeyDown, txtMobile1.KeyDown, txtMobile2.KeyDown, txtCity.KeyDown, txtState.KeyDown,
   txtAlterNetAdd1.KeyDown, txtAlterNetadd2.KeyDown, txtAlterNetCity.KeyDown, txtAlterNetState.KeyDown, txtGuarantorName.KeyDown,
   txtGuarntorAddress.KeyDown, txtGurantorCity.KeyDown, txtGuarantorState.KeyDown, txtGaurantorMobile1.KeyDown, txtGaurantorMobile2.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txtAttenderName_Leave(sender As Object, e As EventArgs) Handles txtAttenderName.Leave
        If BtnSave.Text = "&Save" Then
            If clsFun.ExecScalarStr("Select count(*)from Attender where upper(AttenderName)='" & txtAttenderName.Text.ToUpper & "'") = 1 Then
                MsgBox("Attender Name Already Exists...", vbCritical + vbOKOnly, "Access Denied")
                txtAttenderName.Focus()
            End If
        Else
            Exit Sub
        End If
    End Sub

    Private Sub txtAttenderName_TextChanged(sender As Object, e As EventArgs) Handles txtAttenderName.TextChanged

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If BtnSave.Text = "&Save" Then
            Save()
        Else
            Update()
        End If

    End Sub


    Private Sub dtp1_ValueChanged(sender As Object, e As EventArgs) Handles dtp1.ValueChanged
        mskDOB.Text = dtp1.Value.ToString("dd-MM-yyyy")
        mskDOB.Text = clsFun.convdate(mskDOB.Text)
    End Sub
    Private Sub dtp2_ValueChanged(sender As Object, e As EventArgs) Handles dtp2.ValueChanged
        mskJoining.Text = dtp2.Value.ToString("dd-MM-yyyy")
        mskJoining.Text = clsFun.convdate(mskJoining.Text)
    End Sub

    Private Sub mskDOB_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles mskDOB.MaskInputRejected

    End Sub

    Private Sub txtGuarantorName_TextChanged(sender As Object, e As EventArgs) Handles txtGuarantorName.TextChanged

    End Sub

    Private Sub txtAlterNetState_TextChanged(sender As Object, e As EventArgs) Handles txtAlterNetState.TextChanged

    End Sub

    Private Sub btnShowPassword_Click(sender As Object, e As EventArgs) Handles btnShowPassword.Click
        If txtApppasword.UseSystemPasswordChar = False Then
            txtApppasword.UseSystemPasswordChar = True 'Show password
        Else
            txtApppasword.UseSystemPasswordChar = False 'Hide password
        End If
    End Sub
End Class