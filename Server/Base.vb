Imports Newtonsoft.Json
Imports System.Net
Imports System.Net.Sockets
Module Base
    ''' <summary>
    ''' Classe permettant de faciliter le stockage, l'envoi, la réception, des formulaires grâce à la puissance de l'orienté objet.
    ''' </summary>
    Public Class Formulaire
        ''' <summary>
        ''' Le nom de famille
        ''' </summary>
        Public Property Nom As String = Nothing
        ''' <summary>
        ''' Le prénom
        ''' </summary>
        Public Property Prenom As String = Nothing
        ''' <summary>
        ''' L'Âge
        ''' </summary>
        Public Property Age As Integer = 0

        ''' <summary>
        ''' Fonction permettant de sérialisé cet objet (ses propriétées) dans un string au format JSON
        ''' </summary>
        ''' <returns>une chaine de caractère au format JSON sinon NOTHING sera retourné en cas d'echec de sérialisation</returns>
        Public Function GetJson() As String
            Try
                Return JsonConvert.SerializeObject(Me)
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        ''' <summary>
        ''' Fonction permettant de définir les valeurs de propriété de cet objet en désérialisation une string formatté en JSON contenant les données du formulaire
        ''' </summary>
        ''' <param name="JsonStr">Une string au format JSON valide</param>
        ''' <returns>TRUE si la désérialisation est passée, et que les propriétées de cet objets ont été définies, sinon retourne FALSE en cas d'échec de désérialisation</returns>
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

    ''' <summary>
    ''' Classe utilisé par le client pour la communication avec le serveur (NE SERT A RIEN DANS CE PROJET)
    ''' </summary>
    Public Class ClientRPC
        Public Property ServerIP As String = "127.0.0.1"
        Public Property ServerPort As Integer = 3426
        Dim sockClient As New Socket(SocketType.Stream, ProtocolType.Tcp)
        Dim serverEndPoint As New IPEndPoint(IPAddress.Parse(ServerIP), ServerPort)

        ''' <summary>
        ''' Permet la connexion au serveur prédéfini
        ''' </summary>
        ''' <returns>TRUE si le connexion à réussi, sinon retourne FALSE</returns>
        Private Function Connect() As Boolean
            sockClient = New Socket(SocketType.Stream, ProtocolType.Tcp)
            Try
                sockClient.Connect(serverEndPoint)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' Déconnecte le socket du client
        ''' </summary>
        ''' <returns>TRUE si la déconnexion à réussi, sinon retourne false</returns>
        Private Function Disconnect() As Boolean
            Try
                sockClient.Disconnect(False)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        '''  -> 1) Se connecte au serveur 
        '''  -> 2) Convertie le paramètre JsonStr (String au format JSON) en tableau d'octet avec l'encodage UTF8 
        '''  -> 3) Se déconnecte du serveur
        ''' </summary>
        ''' <param name="JsonStr">Un string au format JSON contenant les informations du formulaire (Généré avec la méthode Formulaire.GetJson) (Résultat de la sérialisation JSON)</param>
        ''' <returns>TRUE si le JSON à été envoyé au serveur, sinon retourne FALSE</returns>
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

    ''' <summary>
    ''' Classe utilisé par l'application serveur
    ''' </summary>
    Public Class ServerRPC

        Public SenderForm As PageServeur = Nothing

        Dim socketListenner As New Socket(SocketType.Stream, ProtocolType.Tcp)
        Dim interfaceEcoute As New IPEndPoint(IPAddress.Any, 3426)

        Dim threadListenning As Threading.Thread
        Dim Listenning As Boolean = False

        ''' <summary>
        ''' Constructeur de la classe
        ''' </summary>
        ''' <param name="sender">Paramètre indiquant la classe appelante (de type PageServeur) afin de pouvoir accéder à sa méthode SafeSetData() lors de la réception d'un formulaire</param>
        Sub New(ByVal sender As PageServeur)
            Me.SenderForm = sender
        End Sub

        ''' <summary>
        ''' Fonction permettant de démarrer le serveur
        ''' </summary>
        ''' <returns>TRUE si le serveur à correctement démarré, que le listenner à bindé une interface et qu'il est bien en mode écoute, sinon retourne false en cas de conflit d'interface, port, ou toutes autres restriction du système d'exploitation.</returns>
        Public Function StartServer() As Boolean
            Try
                socketListenner = New Socket(SocketType.Stream, ProtocolType.Tcp)
                socketListenner.Bind(interfaceEcoute)
                socketListenner.Listen(1)
                Listenning = True
                threadListenning = New Threading.Thread(AddressOf Listen)
                threadListenning.Start()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' Arrête le serveur en stoppant la boucle d'écoute et en fermant le socket d'écoute.
        ''' </summary>
        Public Sub StopServer()
            Try
                Listenning = False
                socketListenner.Close()
            Catch ex As Exception
            End Try
        End Sub

        ''' <summary>
        ''' Boucle d'écoute. Elle accepte les connexions clientes entrantes
        ''' </summary>
        Private Sub Listen()
            While Listenning
                Try
                    ReadRequest(socketListenner.Accept())
                Catch ex As Exception
                End Try
            End While
        End Sub

        ''' <summary>
        ''' Méthode déclenché dès l'acceptation d'un client, permet de lire les données reçu par le client, car dès sa connexion, il envoit les données contenant le JSON du formulaire. Ensuite, la méthode appel la méthode SafeSetData() dans la classe PageServeur afin d'afficher sur le thread principal dans la liste des formulaires reçus les données de ce formulaire reçu
        ''' </summary>
        ''' <param name="sockSession">Le socket de session qui vient d'être accepté par le listenner</param>
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
