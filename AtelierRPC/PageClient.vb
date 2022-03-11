Imports Newtonsoft.Json
Public Class PageClient
    Dim client As New ClientRPC

    Sub Submit()
        Dim leFormulaire = New Formulaire
        With leFormulaire
            .Nom = TB_LastName.Text
            .Prenom = TB_FirstName.Text
            .Age = NUM_Age.Value
        End With

        Dim JsonFormulaire As String = leFormulaire.GetJson
        If JsonFormulaire Is Nothing Then MsgBox("Il y a eu une erreur de sérialisaiton JSON !", vbCritical) : Exit Sub

        If client.SendMesage(JsonFormulaire) = True Then
            MsgBox("Formulaire envoyé !", vbInformation)
        Else
            MsgBox("Formulaire non envoyé, échec de l'envoi...", vbCritical)
        End If
    End Sub

    Private Sub BTN_Submit_Click(sender As Object, e As EventArgs) Handles BTN_Submit.Click
        Submit()
    End Sub
End Class
