Imports Microsoft.Data.SqlClient
Imports CapaEntidad
Public Class Repositorio_VLogin
    Inherits Repositorio_Maestro
    Implements IRepositorio_VLogin

    Private SeleccionarUserPass As String

    Public Sub New()
        SeleccionarUserPass = "SELECT * FROM VLogin WHERE Usuario = @Usuario AND Clave = @Pass"
    End Sub


    Public Function ObtenerPorUsuarioYClave(usuario As String, clave As String) As IEnumerable(Of TVLogin) Implements IRepositorio_VLogin.GetUserPass
        parameter = New List(Of SqlParameter) From {
            New SqlParameter("@Usuario", usuario),
            New SqlParameter("@Pass", clave)
        }
        Dim resultadoTable As DataTable = ExecuteReader(SeleccionarUserPass)
        Dim lista = New List(Of TVLogin)
        For Each row As DataRow In resultadoTable.Rows
            Dim login As New TVLogin With {
                .Usuario = Convert.ToString(row("Usuario")),
                .ID = Convert.ToInt32(row("ID")),
                .Clave = Convert.ToString(row("Clave")),
                .Cedula = Convert.ToString(row("Cedula")),
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

    Public Function GetAllUserPass(usuario As String, password As String) As IEnumerable(Of TVLogin) Implements IRepositorio_Generico(Of TVLogin).GetAllUserPass
        Return ObtenerPorUsuarioYClave(usuario, password)
    End Function

    Public Function GetAll() As IEnumerable(Of TVLogin) Implements IRepositorio_Generico(Of TVLogin).GetAll
        Throw New NotImplementedException()
    End Function

    Public Function Add(entity As TVLogin) As Integer Implements IRepositorio_Generico(Of TVLogin).Add
        Throw New NotImplementedException()
    End Function

    Public Function Edit(entity As TVLogin) As Integer Implements IRepositorio_Generico(Of TVLogin).Edit
        Throw New NotImplementedException()
    End Function

    Public Function Remove(id As Integer) As Integer Implements IRepositorio_Generico(Of TVLogin).Remove
        Throw New NotImplementedException()
    End Function
End Class

