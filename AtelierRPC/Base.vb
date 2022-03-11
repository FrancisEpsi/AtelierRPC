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

        Public SenderForm As PageServeur = Nothing

        Dim socketListenner As New Socket(SocketType.Stream, ProtocolType.Tcp)
        Dim interfaceEcoute As New IPEndPoint(IPAddress.Any, 3426)

        Dim threadListenning As Threading.Thread
        Dim Listenning As Boolean = False

        Sub New(ByVal sender As PageServeur)
            Me.SenderForm = sender
        End Sub

        Public Sub StartServer()
            socketListenner = New Socket(SocketType.Stream, ProtocolType.Tcp)
            socketListenner.Bind(interfaceEcoute)
            socketListenner.Listen(1)
            Listenning = True
            threadListenning = New Threading.Thread(AddressOf Listen)
            threadListenning.Start()
        End Sub

        Public Sub StopServer()
            Try
                Listenning = False
                socketListenner.Close()
            Catch ex As Exception
            End Try
        End Sub

        Private Sub Listen()
            While Listenning
                Try
                    ReadRequest(socketListenner.Accept())
                Catch ex As Exception
                End Try
            End While
        End Sub

        Private Sub ReadRequest(ByVal sockSession As Socket)
            If sockSession Is Nothing Then Exit Sub
            Try
                Dim buffer(4096) As Byte
                Dim BytesReceived As Integer = sockSession.Receive(buffer)
                Dim JsonStr As String = System.Text.Encoding.UTF8.GetString(buffer)

                Dim trimJsonStr As String = Nothing
                Dim charcounter As Integer = 1
                For Each c As Char In JsonStr
                    If charcounter <= BytesReceived Then
                        trimJsonStr = trimJsonStr & c
                        charcounter = charcounter + 1
                    End If
                Next
                Debug.WriteLine("Formulaire JSON reçu : '" & trimJsonStr & "'")
                'Debug.WriteLine(BytesReceived & " octets reçu")

                Dim DonneeFormulaire As New Formulaire
                If DonneeFormulaire.LoadJson(trimJsonStr) = True Then
                    Debug.WriteLine("Nom:" & vbTab & DonneeFormulaire.Nom)
                    Debug.WriteLine("Prénom:" & vbTab & DonneeFormulaire.Prenom)
                    Debug.WriteLine("Âge:" & vbTab & DonneeFormulaire.Age)
                    SenderForm.SafeSetData(DonneeFormulaire)
                Else
                    Debug.WriteLine("Impossible de désérialiser le JSON reçu !")
                End If
            Catch ex As Exception
                Debug.WriteLine("[X] ReadRequest() : " & ex.Message)
            End Try
        End Sub
    End Class
End Module
