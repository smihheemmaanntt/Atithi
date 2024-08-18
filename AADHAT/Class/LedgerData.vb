﻿Public Class LedgerRequest
    Public Sub New()
        Ledgers = New List(Of LedgerData)()
    End Sub

    Public Property Ledgers As List(Of LedgerData)
    Public Property IsFirstRow As Boolean
End Class

Public Class LedgerData
    Public Property VourchersID As Integer = 0
    Public Property EntryDate As Date
    Public Property TransType As String = ""
    Public Property AccountID As Integer = 0
    Public Property AccountName As String = ""
    Public Property Amount As Decimal
    Public Property DC As String = ""
    Public Property Remark As String = ""
    Public Property Narration As String = ""
    Public Property OrganizationId As Integer
End Class

Public Class SaveLedgerResponse
    Inherits Response
End Class


