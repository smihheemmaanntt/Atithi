﻿Imports System.Net
Imports Newtonsoft.Json

Public Class HttpService
    Public Sub New()
    End Sub
    Public Function SendAccountData(ByVal rqst As AddAccountRequest) As SaveAccountResponse
        Dim resp As SaveAccountResponse = New SaveAccountResponse()
        Try
            Using webClient As WebClient = New WebClient()
                webClient.BaseAddress = "http://api.smicloud.in/api/"
                Dim url = "Master/SaveAccounts"
                'webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)")
                webClient.Headers(HttpRequestHeader.ContentType) = "application/json"
                Dim data As String = JsonConvert.SerializeObject(rqst)
                Dim response = webClient.UploadString(url, data)
                resp = JsonConvert.DeserializeObject(Of SaveAccountResponse)(response)
                Return resp
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SendLedgerData(ByVal rqst As LedgerRequest) As SaveLedgerResponse
        Dim resp As SaveLedgerResponse = New SaveLedgerResponse()
        Try
            Using webClient As WebClient = New WebClient()
                webClient.BaseAddress = "http://api.smicloud.in/api/"
                Dim url = "Master/SaveLedgers"
                'webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)")
                webClient.Headers(HttpRequestHeader.ContentType) = "application/json"
                Dim data As String = JsonConvert.SerializeObject(rqst)
                Dim response = webClient.UploadString(url, data)
                resp = JsonConvert.DeserializeObject(Of SaveLedgerResponse)(response)
                Return resp
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SendCompany(ByVal rqst As CompanyRequest) As CompanyResponse
        Dim resp As CompanyResponse = New CompanyResponse()
        Try
            Using webClient As WebClient = New WebClient()
                webClient.BaseAddress = "http://api.smicloud.in/api/"
                Dim url = "Master/SaveCompany"
                'webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)")
                webClient.Headers(HttpRequestHeader.ContentType) = "application/json"
                Dim data As String = JsonConvert.SerializeObject(rqst)
                Dim response = webClient.UploadString(url, data)
                resp = JsonConvert.DeserializeObject(Of CompanyResponse)(response)
                Return resp
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function SendAccountGroup(ByVal rqst As AddAccountGroupRequest) As AccountGroupResponse
        Dim resp As AccountGroupResponse = New AccountGroupResponse()
        Try
            Using webClient As WebClient = New WebClient()
                webClient.BaseAddress = "http://api.smicloud.in/api/"
                Dim url = "Master/SaveAccountGroups"
                'webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)")
                webClient.Headers(HttpRequestHeader.ContentType) = "application/json"
                Dim data As String = JsonConvert.SerializeObject(rqst)
                Dim response = webClient.UploadString(url, data)
                resp = JsonConvert.DeserializeObject(Of AccountGroupResponse)(response)
                Return resp
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class

