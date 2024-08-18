Imports System.IO
Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Public Class OptionsAllForm
    Dim Commission As String = ""
    Dim UserCharges As String = ""
    Dim Rdf As String = ""
    Dim Bardana As String = ""
    Dim Labour As String = ""
    Private Sub ckCommission_CheckedChanged(sender As Object, e As EventArgs)

    End Sub
    Private Sub saveChanges()
        Dim sql As String = "Update Options SET KOTPreview='" & IIf(ckKOTPrintPreView.Checked = True, "Y", "N") & "' ," & _
         " KOTDoNotPrint ='" & IIf(ckKOTDoNotPrint.Checked = True, "Y", "N") & "',KOTAskForPrint='" & IIf(ckKOTAskForPrint.Checked = True, "Y", "N") & "'," & _
        "  KOT2Copy='" & IIf(ckKOT2Copy.Checked = True, "Y", "N") & "',POSPreview='" & IIf(ckPOSPrintPreview.Checked = True, "Y", "N") & "', " & _
        "POSDoNotPrint ='" & IIf(ckPOSDoNotPrint.Checked = True, "Y", "N") & "' ,POSAskForPrint='" & IIf(ckPosAskForPrint.Checked = True, "Y", "N") & "'," & _
        "POS2Copy='" & IIf(ckPOS2Copy.Checked = True, "Y", "N") & "',BillPreview='" & IIf(ckBillPrintPreview.Checked = True, "Y", "N") & "', " & _
        "BillDoNotPrint='" & IIf(ckBillDoNotPrint.Checked = True, "Y", "N") & "',BillAskForPrint='" & IIf(ckBillAskForPrint.Checked = True, "Y", "N") & "'," & _
        " Bill2Copy='" & IIf(ckBill2Copy.Checked = True, "Y", "N") & "',BookingDoNotPrint='" & IIf(CkBookingDontPrint.Checked = True, "Y", "N") & "'," & _
         " BookingAskForPrint ='" & IIf(CkBookingAskPrint.Checked = True, "Y", "N") & "',BookingPreview='" & IIf(ckBookingPrintPriView.Checked = True, "Y", "N") & "'," & _
        "  BookingBill2Copy='" & IIf(CkBooking2Coppies.Checked = True, "Y", "N") & "',CheckinDoNotPrint='" & IIf(ckCheckinDont.Checked = True, "Y", "N") & "', " & _
        "CheckInAskForPrint ='" & IIf(CkCheckInAsk.Checked = True, "Y", "N") & "' ,CheckInPreview='" & IIf(CkCheckPreview.Checked = True, "Y", "N") & "'," & _
        "CheckIn2Copy='" & IIf(CkCheckINCoppies.Checked = True, "Y", "N") & "',CheckOutDoNotPrint='" & IIf(ckOutDont.Checked = True, "Y", "N") & "', " & _
        "CheckOutAskForPrint='" & IIf(ckOutAsk.Checked = True, "Y", "N") & "',CheckOutPreview='" & IIf(CkOutPreView.Checked = True, "Y", "N") & "'," & _
        " CheckOut2Copy='" & IIf(ckOutCoppies.Checked = True, "Y", "N") & "', FullDayCheckOut='" & IIf(ck24hr.Checked = True, "Y", "N") & "', " & _
        " CheckOutTIme='" & dtpCheckoutTime.Text & "',BookingPrefix='" & txtBookingPrefix.Text & "',CheckInPrefix='" & txtCheckinPrefix.Text & "', " & _
        " CheckoutPrefix='" & txtCheckOutPrefix.Text & "' WHERE ID = " & Val(txtID.Text) & ""
        cmd = New SQLite.SQLiteCommand(Sql, clsFun.GetConnection())
        Try
            If clsFun.ExecNonQuery(Sql) > 0 Then
                MsgBox("Setting Updated Successfully.", vbInformation + vbOKOnly, "Options Updated")

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub FillControls(ByVal id As Integer)
        ssql = "Select * from Options where id=" & id
        Dim KOTAskForPrint As String = String.Empty
        Dim KOTDoNotPrint As String = String.Empty
        Dim KOTPrintPrivew As String = String.Empty
        Dim KOT2copy As String = String.Empty
        Dim POSAskForPrint As String = String.Empty
        Dim POSDoNotPrint As String = String.Empty
        Dim POSPrintPrivew As String = String.Empty
        Dim POS2copy As String = String.Empty
        Dim BillAskForPrint As String = String.Empty
        Dim BillDoNotPrint As String = String.Empty
        Dim BillPrintPrivew As String = String.Empty
        Dim Bill2copy As String = String.Empty
        Dim FullDay As String = String.Empty


        ''''''''
        Dim BookingDont As String = String.Empty
        Dim BookingAsk As String = String.Empty
        Dim BookingPrivew As String = String.Empty
        Dim Booking2copy As String = String.Empty
        Dim CheckInAskPrint As String = String.Empty
        Dim CheckInDoNotPrint As String = String.Empty
        Dim CheckInPrintPrivew As String = String.Empty
        Dim CheckIn2copy As String = String.Empty
        Dim CheckOutAskForPrint As String = String.Empty
        Dim CheckOutDoNotPrint As String = String.Empty
        Dim CheckOutPrintPrivew As String = String.Empty
        Dim CheckOut2copy As String = String.Empty
        dt = clsFun.ExecDataTable(ssql) ' where id=" & id & "")
        If dt.Rows.Count > 0 Then
            txtID.Text = dt.Rows(0)("ID").ToString()
            KOTPrintPrivew = dt.Rows(0)("KOtPreview").ToString().Trim()
            KOTDoNotPrint = dt.Rows(0)("KOTDoNotPrint").ToString().Trim()
            KOTAskForPrint = dt.Rows(0)("KOTAskForPrint").ToString().Trim()
            KOT2copy = dt.Rows(0)("KOT2Copy").ToString().Trim()
            POSPrintPrivew = dt.Rows(0)("POsPreview").ToString().Trim()
            POSDoNotPrint = dt.Rows(0)("POSDoNotPrint").ToString().Trim()
            POSAskForPrint = dt.Rows(0)("POSAskForPrint").ToString().Trim()
            POS2copy = dt.Rows(0)("Pos2Copy").ToString().Trim()
            BillPrintPrivew = dt.Rows(0)("BillPreview").ToString().Trim()
            BillDoNotPrint = dt.Rows(0)("BillDoNotPrint").ToString().Trim()
            BillAskForPrint = dt.Rows(0)("BillAskForPrint").ToString().Trim()
            Bill2copy = dt.Rows(0)("Bill2Copy").ToString().Trim()
            '  If POSPrintPrivew = "Y" Then ckKOTPrintPreView.Checked = True Else ckKOTPrintPreView.Checked = False
            If KOTPrintPrivew = "Y" Then ckKOTPrintPreView.Checked = True Else ckKOTPrintPreView.Checked = False
            If KOTDoNotPrint = "Y" Then ckKOTDoNotPrint.Checked = True Else ckKOTDoNotPrint.Checked = False
            If KOTAskForPrint = "Y" Then ckKOTAskForPrint.Checked = True Else ckKOTAskForPrint.Checked = False
            If KOT2copy = "Y" Then ckKOT2Copy.Checked = True Else ckKOT2Copy.Checked = False
            If POSPrintPrivew = "Y" Then ckPOSPrintPreview.Checked = True Else ckPOSPrintPreview.Checked = False
            If POSDoNotPrint = "Y" Then ckPOSDoNotPrint.Checked = True Else ckPOSDoNotPrint.Checked = False
            If POSAskForPrint = "Y" Then ckPosAskForPrint.Checked = True Else ckPosAskForPrint.Checked = False
            If POS2copy = "Y" Then ckPOS2Copy.Checked = True Else ckPOS2Copy.Checked = False
            If BillPrintPrivew = "Y" Then ckBillPrintPreview.Checked = True Else ckBillPrintPreview.Checked = False
            If BillDoNotPrint = "Y" Then ckBillDoNotPrint.Checked = True Else ckBillDoNotPrint.Checked = False
            If BillAskForPrint = "Y" Then ckBillAskForPrint.Checked = True Else ckBillAskForPrint.Checked = False
            If Bill2copy = "Y" Then ckBill2Copy.Checked = True Else ckBill2Copy.Checked = False
            ''''''
            BookingDont = dt.Rows(0)("BookingDoNotPrint").ToString().Trim()
            BookingAsk = dt.Rows(0)("BookingAskForPrint").ToString().Trim()
            BookingPrivew = dt.Rows(0)("BookingPreview").ToString().Trim()
            Booking2copy = dt.Rows(0)("BookingBill2Copy").ToString().Trim()
            CheckInAskPrint = dt.Rows(0)("CheckInAskForPrint").ToString().Trim()
            CheckInDoNotPrint = dt.Rows(0)("CheckinDoNotPrint").ToString().Trim()
            CheckInPrintPrivew = dt.Rows(0)("CheckInPreview").ToString().Trim()
            CheckIn2copy = dt.Rows(0)("CheckIn2Copy").ToString().Trim()
            CheckOutDoNotPrint = dt.Rows(0)("CheckOutDoNotPrint").ToString().Trim()
            CheckOutAskForPrint = dt.Rows(0)("CheckOutAskForPrint").ToString().Trim()
            CheckOutPrintPrivew = dt.Rows(0)("CheckOutPreview").ToString().Trim()
            CheckOut2copy = dt.Rows(0)("CheckOut2Copy").ToString().Trim()

            If BookingDont = "Y" Then CkBookingDontPrint.Checked = True Else CkBookingDontPrint.Checked = False
            If BookingAsk = "Y" Then CkBookingAskPrint.Checked = True Else CkBookingAskPrint.Checked = False
            If BookingPrivew = "Y" Then ckBookingPrintPriView.Checked = True Else ckBookingPrintPriView.Checked = False
            If Booking2copy = "Y" Then CkBooking2Coppies.Checked = True Else CkBooking2Coppies.Checked = False
            If CheckInAskPrint = "Y" Then CkCheckInAsk.Checked = True Else CkCheckInAsk.Checked = False
            If CheckInDoNotPrint = "Y" Then ckCheckinDont.Checked = True Else ckCheckinDont.Checked = False
            If CheckInPrintPrivew = "Y" Then CkCheckPreview.Checked = True Else CkCheckPreview.Checked = False
            If CheckIn2copy = "Y" Then CkCheckINCoppies.Checked = True Else CkCheckINCoppies.Checked = False
            If CheckOutAskForPrint = "Y" Then ckOutAsk.Checked = True Else ckOutAsk.Checked = False
            If CheckOutDoNotPrint = "Y" Then ckOutDont.Checked = True Else ckOutDont.Checked = False
            If CheckOutPrintPrivew = "Y" Then CkOutPreView.Checked = True Else CkOutPreView.Checked = False
            If CheckOut2copy = "Y" Then ckOutCoppies.Checked = True Else ckOutCoppies.Checked = False
            '24hr checkout & Checkout Time
            FullDay = dt.Rows(0)("FullDayCheckOut").ToString().Trim()
            If FullDay = "Y" Then ck24hr.Checked = True Else ck24hr.Checked = False
            dtpCheckoutTime.Text = dt.Rows(0)("CheckOutTIme").ToString().Trim()
            '''Prefixs
            txtBookingPrefix.Text = dt.Rows(0)("BookingPrefix").ToString().Trim()
            txtCheckinPrefix.Text = dt.Rows(0)("CheckInPrefix").ToString().Trim()
            txtCheckOutPrefix.Text = dt.Rows(0)("CheckoutPrefix").ToString().Trim()
        End If
    End Sub
    Private Sub OptionsAllForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub OptionsAllForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0 : Me.Left = 0
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.BackColor = Color.Moccasin
        Me.KeyPreview = True : cbDecimalValues.SelectedIndex = 0
        FillControls(txtID.Text)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        saveChanges()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class