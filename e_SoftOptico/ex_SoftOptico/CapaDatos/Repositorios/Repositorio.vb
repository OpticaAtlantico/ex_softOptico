Imports System.Configuration
Imports System.Data.SqlClient

Public MustInherit Class Repositorio
    Private ReadOnly ConnectionString As String

    Public Sub New()
        ConnectionString = ConfigurationManager.ConnectionStrings("ConnMyCompany").ToString()
    End Sub

    Protected Function GetConnection() As SqlConnection
        Return New SqlConnection(ConnectionString)
    End Function
End Class
