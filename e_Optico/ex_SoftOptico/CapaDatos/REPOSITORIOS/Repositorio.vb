Imports System.Configuration
Imports Microsoft.data.sqlclient

Public MustInherit Class Repositorio
    Private ReadOnly ConnectionString As String
    Public Sub New()
        ' Constructor base para inicializar cualquier recurso común
        ConnectionString = ConfigurationManager.ConnectionStrings("ConnMyCompany").ConnectionString
    End Sub

    Protected Function ObtenerConexion() As SqlConnection
        ' Método para obtener una conexión a la base de datos
        Return New SqlConnection(ConnectionString)
    End Function


End Class
