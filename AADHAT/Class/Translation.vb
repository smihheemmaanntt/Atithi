Public Class Translation
    Public Shared Function DoTransLitrate(ByVal str As String) As String
        Dim i As Integer = 0
        Dim ret As String = ""
        Dim pi As Integer = 0
        Dim vowelFlag As Boolean = False
        str = str.ToLower()

        While i < str.Length

            Try

                If (str(i) = "h"c AndAlso vowelFlag) OrElse (isConsonent(str(i), vowelFlag) AndAlso i > 0) OrElse (str(i) = " "c) OrElse isPunct(str(i)) OrElse isDigit(str(i)) OrElse ((i - pi) > 5) Then

                    If pi < i Then
                        ret += GetSound(str.Substring(pi, i - pi))
                    End If

                    If str(i) = " "c Then
                        ret += " "c
                    End If

                    If ((str(i) = " "c) OrElse isPunct(str(i))) Then
                        ret += str(i)
                        pi = i + 1
                    ElseIf isDigit(str(i)) Then
                        Dim digi As String = "" & ChrW(("०" & (Asc(str(i)) - "0")))
                        ret += digi
                        pi = i + 1
                    Else
                        pi = i
                    End If

                    vowelFlag = False
                ElseIf isVowel(str(i)) AndAlso str(i) <> "h"c Then
                    vowelFlag = True
                End If

                i += 1
            Catch exp As Exception
                ret += "error!!"
            End Try
        End While

        If pi < i Then

            Try
                ret += GetSound(str.Substring(pi, i - pi))
            Catch exp As Exception
                ret += "error!!"
            End Try
        End If

        Return DoTransLitrate(ret)
    End Function
    Private Shared Function isConsonent(ByVal a As Char, ByVal hflag As Boolean) As Boolean
        Dim str As String = "aieouh"

        For i As Integer = 0 To str.Length - 1

            If str(i) = a Then
                Return False
            End If
        Next

        Return True
    End Function
    Private Shared Function isTrueVowel(ByVal a As Char) As Boolean
        Dim str As String = "aieou"

        For i As Integer = 0 To str.Length - 1

            If str(i) = a Then
                Return True
            End If
        Next

        Return False
    End Function
    Private Shared Function isDigit(ByVal a As Char) As Boolean
        Dim str As String = "0123456789"

        For i As Integer = 0 To str.Length - 1

            If str(i) = a Then
                Return True
            End If
        Next

        Return False
    End Function
    Private Shared Function isPunct(ByVal a As Char) As Boolean
        Dim str As String = ",.><?/+=-_}{[]*&^%$#@!~`""\|:;"

        For i As Integer = 0 To str.Length - 1

            If str(i) = a Then
                Return True
            End If
        Next

        Return False
    End Function
    Private Shared Function isVowel(ByVal a As Char) As Boolean
        Dim str As String = "aieouh"

        For i As Integer = 0 To str.Length - 1

            If str(i) = a Then
                Return True
            End If
        Next

        Return False
    End Function
    Private Shared Function isSpecial(ByVal a As Char) As Boolean
        Dim str As String = "hy"

        For i As Integer = 0 To str.Length - 1

            If str(i) = a Then
                Return True
            End If
        Next

        Return False
    End Function
    Private Shared Function GetMatra(ByVal str As String) As String
        Dim i As Integer = 0

        If str.Length < 1 Then
            Return "्"
        End If

        While str(i) = "h"c
            i += 1

            If i >= str.Length Then
                Exit While
            End If
        End While

        If i < str.Length Then
            str = str.Substring(i)
        End If

        If str = "aa" Then
            Return "ा"
        End If

        If str = "ai" Then
            Return "ै"
        ElseIf str = "e" Then
            Return "े"
        ElseIf str = "ee" Then
            Return "ी"
        ElseIf str = "i" Then
            Return "ि"
        ElseIf str = "u" Then
            Return "ु"
        ElseIf str = "oo" Then
            Return "ू"
        ElseIf str = "o" Then
            Return "ो"
        ElseIf str = "h" Then
            Return ""
        ElseIf str = "hh" Then
            Return ""
        End If

        Return ""
    End Function
    Private Shared Function GethShift(ByVal str As String, ByRef totalCoreSoundCharacter As Integer) As String
        totalCoreSoundCharacter = 2

        If str.IndexOf("kh") = 0 Then
            Return "ख"
        ElseIf str.IndexOf("gh") = 0 Then
            Return "घ"
        ElseIf str.IndexOf("bh") = 0 Then
            Return "भ"
        ElseIf str.IndexOf("chh") = 0 Then
            totalCoreSoundCharacter = 3
            Return "छ"
        ElseIf str.IndexOf("ch") = 0 Then
            Return "च"
        ElseIf str.IndexOf("jh") = 0 Then
            Return "झ"
        ElseIf str.IndexOf("thh") = 0 Then
            totalCoreSoundCharacter = 3
            Return "ट"
        ElseIf str.IndexOf("th") = 0 Then
            Return "थ"
        ElseIf str.IndexOf("gh") = 0 Then
            Return "घ"
        ElseIf str.IndexOf("dhh") = 0 Then
            totalCoreSoundCharacter = 3
            Return "ड"
        ElseIf str.IndexOf("dh") = 0 Then
            Return "ध"
        ElseIf str.IndexOf("shh") = 0 Then
            totalCoreSoundCharacter = 3
            Return "ष"
        ElseIf str.IndexOf("sh") = 0 Then
            Return "श"
        ElseIf str.IndexOf("rh") = 0 Then
            Return "ण"
        ElseIf str.IndexOf("h") >= 1 Then
            Dim sound As String = ""
            totalCoreSoundCharacter = 0

            For Each c As Char In str

                If Not isTrueVowel(c) Then
                    sound = sound & ResolveCharacterSound(c)
                    totalCoreSoundCharacter += 1
                Else
                    Exit For
                End If
            Next

            Return sound
        End If

        totalCoreSoundCharacter = 1
        Return Nothing
    End Function
    Private Shared Function GetCoreSound(ByVal str As String, ByRef totalCoreSoundCharacter As Integer) As String
        Dim soundmap As String = "अबसदइफगहईजकलमनओपकरसतउववज़यज"
        Dim h_shift As String = GethShift(str, totalCoreSoundCharacter)

        If h_shift Is Nothing Then
            Dim position As Integer = ((Asc(str(0))) - "a")

            If position < soundmap.Length AndAlso position >= 0 Then
                Return "" & soundmap(position)
            End If

            totalCoreSoundCharacter = 1
            Return str
        Else
            Return h_shift
        End If
    End Function
    Private Shared Function GetSpecialSound(ByVal str As String) As String
        If str = "aa" Then
            Return "आ"
        ElseIf str = "au" Then
            Return "औ"
        ElseIf str = "e" Then
            Return "इ"
        ElseIf str = "ee" Then
            Return "ई"
        ElseIf str = "i" Then
            Return "इ"
        ElseIf str = "o" Then
            Return "ओ"
        ElseIf str = "x" Then
            Return "एक्स"
        End If

        Return Nothing
    End Function
    Private Shared Function ResolveCharacterSound(ByVal c As Char) As String
        Dim str As String = "" & c
        Dim totalCoreSoundCharacter As Integer = 0

        If isPunct(c) Then
            Return str
        ElseIf isDigit(c) Then
            Return "" & ChrW(("०" + (Asc(c) - "0")))
        ElseIf isConsonent(str(0), False) Then
            Return "" & GetCoreSound(str, totalCoreSoundCharacter) & "्"
        Else
            Return "" & GetCoreSound(str, totalCoreSoundCharacter)
        End If
    End Function
    Private Shared Function GetSound(ByVal str As String) As String
        Dim totalCoreSoundCharacter As Integer = 0
        str = str.ToLower().Trim()

        If str Is Nothing OrElse str = "" Then
            Return ""
        End If

        Dim SpecialSound As String = GetSpecialSound(str)

        If SpecialSound IsNot Nothing Then
            Return SpecialSound
        End If

        If str.Length = 1 Then
            Return ResolveCharacterSound(str(0))
        Else
            Dim core_sound As String = GetCoreSound(str, totalCoreSoundCharacter)
            Dim matra As String = ""

            Try
                matra = GetMatra(str.Substring(totalCoreSoundCharacter))
            Catch exp As Exception
                matra = ""
            End Try

            Return "" & core_sound & matra
        End If
    End Function
    Public Shared Function SuperTrim(ByVal str As String) As String
        While True
            Dim trimmed As String = str.Replace("  ", " ")

            If trimmed.Length = str.Length Then
                Exit While
            End If

            str = trimmed
        End While

        Return str
    End Function
End Class
