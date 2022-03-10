Imports Newtonsoft.Json
Module Base
    Public Class Formulaire
        Public Property Nom As String = Nothing
        Public Property Prenom As String = Nothing
        Public Property Age As Integer = 0

        Public Function GetJson() As String
            Try
                Return JsonConvert.SerializeObject(Me)
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Function LoadJson(ByVal JsonStr As String) As String
            Dim tempObj = Nothing
            Try
                tempObj = JsonConvert.DeserializeObject(Of Formulaire)(JsonStr)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Module
