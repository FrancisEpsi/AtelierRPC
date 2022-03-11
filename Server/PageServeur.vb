Imports System.Net.Sockets
Imports System.Net

Public Class PageServeur
    Dim serveur As New ServerRPC(Me)
    Dim DataList As New List(Of Formulaire)

    ''' <summary>
    ''' Affiche de manière sécurisé (sur le thread principal via un delegate) les données d'un formulaire reçu (Nom, Prénom, Age) dans le tableau
    ''' </summary>
    ''' <param name="DonneeFormulaire"></param>
    Public Sub SafeSetData(ByVal DonneeFormulaire As Object)
        Dim dSetData As New OneObjectParamDelegate(AddressOf SetData)
        Me.Invoke(dSetData, DonneeFormulaire)
    End Sub

    Private Delegate Sub OneObjectParamDelegate(ByVal obj1 As Object)
    Private Sub SetData(ByVal DonneeFormulaire As Object)
        DataList.Add(DonneeFormulaire)
        RefreshFormulaireList()
    End Sub

    ''' <summary>
    ''' Rafraichit le tableau des formulaires reçu grâce à la variable DataList permettant de les stockés
    ''' </summary>
    Sub RefreshFormulaireList()
        DataGridView1.Rows.Clear()
        For Each formulaire As Formulaire In DataList
            DataGridView1.Rows.Add(formulaire.Nom, formulaire.Prenom, formulaire.Age)
        Next
    End Sub

    Private Sub BTN_StartServer_Click(sender As Object, e As EventArgs) Handles BTN_StartServer.Click
        serveur.StartServer()
        BTN_StartServer.Enabled = False
        BTN_StopServer.Enabled = True
    End Sub

    Private Sub BTN_StopServer_Click(sender As Object, e As EventArgs) Handles BTN_StopServer.Click
        serveur.StopServer()
        BTN_StopServer.Enabled = False
        BTN_StartServer.Enabled = True
    End Sub
End Class
