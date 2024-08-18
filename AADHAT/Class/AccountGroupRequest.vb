Public Class AddAccountGroupRequest
    Public Sub New()
        AccountGroups = New List(Of AccountGroupRequest)
    End Sub
    Public Property AccountGroups As List(Of AccountGroupRequest)
End Class
Public Class AccountGroupRequest
    Public Property GroupId As Integer = 0
    Public Property GroupName As String = ""
    Public Property UnderGroupID As Integer = 0
    Public Property UnderGroupName As String = ""
    Public Property DC As String = ""
    Public Property Primary2 As String = ""
    Public Property Tag As String = ""
    Public Property OrganizationId As Integer
End Class
Public Class AccountGroupResponse
    Inherits Response
End Class

