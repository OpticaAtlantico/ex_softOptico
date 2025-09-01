Imports Microsoft.Data.SqlClient
Imports CapaEntidad
Public Class Repositorio_VLogin
    Inherits Repositorio_Maestro

    Private SeleccionarUserPass As String

    Public Sub New()
        SeleccionarUserPass = "SELECT * FROM VLogin WHERE Usuario = @Usuario AND Clave = @Pass"
    End Sub

    Public Function GetUserPass(usuario As String, clave As String) As IEnumerable(Of VLogin)
        parameter = New List(Of SqlParameter) From {
            New SqlParameter("@Usuario", usuario),
            New SqlParameter("@Pass", clave)
        }
        Dim resultadoTable As DataTable = ExecuteReader(SeleccionarUserPass)
        Dim lista = New List(Of VLogin)
        For Each row As DataRow In resultadoTable.Rows
            Dim login As New VLogin With {
                .Usuario = Convert.ToString(row("Usuario")),
                .ID = Convert.ToInt32(row("ID")),
                .Cedula = Convert.ToString(row("Cedula")),
                .Clave = Convert.ToString(row("Clave")),
                .Nombre = Convert.ToString(row("Nombre")),
                .Apellido = Convert.ToString(row("Apellido")),
                .Cargo = Convert.ToString(row("Cargo")),
                .Correo = Convert.ToString(row("Correo")),
                .Central = Convert.ToString(row("Central")),
                .Clasificacion = Convert.ToString(row("Clasificacion")),
                .Permisos = Convert.ToString(row("Permisos")),
                .Estado = Convert.ToBoolean(row("Estado"))
            }
            lista.Add(login)
        Next
        Return lista
    End Function


End Class

