Imports System.Net.Sockets
Imports System.Net

Public Class PageServeur

    Public Class Serveur
        Dim socketListenner As New Socket(SocketType.Stream, ProtocolType.Tcp)
        Dim interfaceEcoute As New IPEndPoint(IPAddress.Any, 32245)
        Dim ServerEcoute As Boolean = True

        Sub StartServer()
            socketListenner.Bind(interfaceEcoute) 'On dit au socket d'écoute (listenner) de se lier à une interface réseau (accepte toutes les connexions sur toutes les adresses IP sur le port 32245)
            socketListenner.Listen(1) 'Met le listenner en mode écoute de nouvelles connexions clientes.
            While ServerEcoute = True 'Tant que le serveur est allumé
                Try
                    Dim session = New ClientSession(socketListenner.Accept()) '/!\ Bloquant tant que pas de connexion. Dès qu'il y a connexion entrante, on l'accepte et on créer une instance de la classe "ClientSession"
                Catch ex As Exception
                End Try
            End While
        End Sub

        Sub StopServer()
            ServerEcoute = False
        End Sub


    End Class



    Public Class ClientSession
        Sub New(ByVal socket As Socket)

        End Sub
    End Class


End Class
