Imports Newtonsoft.Json
Imports System.Net
Imports System.Net.Sockets
Module Base
    Public Class Formulaire
        Public Property Nom As String = Nothing
        Public Property Prenom As String = Nothing
        Public Property Age As Integer = 0

        'Lien du dépot du projet:
        'https://github.com/FrancisEpsi/AtelierRPC

        Public Function GetJson() As String
            Try
                Return JsonConvert.SerializeObject(Me)
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Function LoadJson(ByVal JsonStr As String) As Boolean
            Dim tempObj As Formulaire = Nothing
            Try
                tempObj = JsonConvert.DeserializeObject(Of Formulaire)(JsonStr)
                With tempObj
                    Me.Nom = tempObj.Nom
                    Me.Prenom = tempObj.Prenom
                    Me.Age = tempObj.Age
                End With
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
    End Class

    Public Class ClientRPC
        Public Property ServerIP As String = "127.0.0.1"
        Public Property ServerPort As Integer = 3426
        Dim sockClient As New Socket(SocketType.Stream, ProtocolType.Tcp)
        Dim serverEndPoint As New IPEndPoint(IPAddress.Parse(ServerIP), ServerPort)

        Public Function Connect() As Boolean
            sockClient = New Socket(SocketType.Stream, ProtocolType.Tcp)
            Try
                sockClient.Connect(serverEndPoint)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function Disconnect() As Boolean
            Try
                sockClient.Disconnect(False)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function SendMesage(ByVal JsonStr As String) As Boolean
            If Me.Connect() = True Then
                Try
                    Dim buffer As Byte() = System.Text.Encoding.UTF8.GetBytes(JsonStr)
                    sockClient.Send(buffer)
                    Me.Disconnect()
                    Return True
                Catch ex As Exception
                    Me.Disconnect()
                    Return False
                End Try
            Else
                Return False
            End If
        End Function
    End Class

    Public Class ServerRPC
        Dim socketListenner As New Socket(SocketType.Stream, ProtocolType.Tcp)
        Dim interfaceEcoute As New IPEndPoint(IPAddress.Any, 3426)

        Dim threadListenning As Threading.Thread
        Dim Listenning As Boolean = False

        Public Sub StartServer()
            Listenning = True
            threadListenning = New Threading.Thread(AddressOf Listen)
            threadListenning.Start()

        End Sub

        Public Sub StopServer()

        End Sub

        Private Sub Listen()
            While Listenning
                Dim sockSession = ""
            End While
        End Sub
    End Class
End Module
