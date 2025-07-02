Imports System.Data.SqlClient
Imports System.Data
Imports Microsoft.Data.SqlClient

Public MustInherit Class ConexionSQL
    Private _connectionString As String
    Protected Sub New()
        _connectionString = "Data Source=.\SQLEXPRESS;" &
                            "Initial Catalog=DB_OPTICA;" &
                            "User ID=sa;" &
                            "Password=123456;" &
                            "Encrypt=False;" &
                            "Trust Server Certificate=True"
    End Sub
    Protected Function GetConnection() As SqlConnection
        Return New SqlConnection(_connectionString)
    End Function
End Class
