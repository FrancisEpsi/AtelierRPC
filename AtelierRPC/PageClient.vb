Imports Newtonsoft.Json
Public Class PageClient
    Dim client As New ClientRPC

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub Submit()
        Dim leFormulaire = New Formulaire
        With leFormulaire
            'Remplacer les "" par les noms des contrôles textbox adéquat:
            .Nom = ""
            .Prenom = ""
            .Age = 0
        End With

        Dim JsonFormulaire As String = leFormulaire.GetJson
        If JsonFormulaire Is Nothing Then MsgBox("Il y a eu une erreur de sérialisaiton JSON !", vbCritical) : Exit Sub

    End Sub
End Class
