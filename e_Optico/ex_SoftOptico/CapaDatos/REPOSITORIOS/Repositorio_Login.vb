Imports Microsoft.Data.SqlClient
Imports CapaEntidad
Public Class Repositorio_Login
    Inherits Repositorio_Maestro
    Implements IRepositorio_Login

    Private SeleccionarTodos As String
    Private SeleccionarUserPass As String
    Private Insertar As String
    Private Actualizar As String
    Private Eliminar As String

    Public Sub New()
        SeleccionarTodos = "SELECT * FROM TLogin"
        SeleccionarUserPass = "SELECT * FROM TLogin WHERE Usuario = @Usuario AND Clave = @Pass"
        Insertar = "INSERT INTO TLogin (Usuario, Pass) VALUES (@Usuario, @Pass)"
        Actualizar = "UPDATE TLogin SET Usuario = @Usuario, Pass = @Pass WHERE Id = @Id"
        Eliminar = "DELETE FROM TLogin WHERE Id = @Id"
    End Sub

    Public Function ObtenerTodos() As IEnumerable(Of TLogin) Implements IRepositorio_Generico(Of TLogin).GetAll
        Dim resultadoTable As DataTable = ExcecuteReader(SeleccionarTodos)
        Dim lista = New List(Of TLogin)
        For Each row As DataRow In resultadoTable.Rows
            Dim login As New TLogin With {
                .LoginID = Convert.ToInt32(row("LoginID")),
                .EmpleadoID = Convert.ToString(row("EmpleadoID")),
                .UbicacionID = Convert.ToString(row("UbicacionID")),
                .RolID = Convert.ToString(row("RolID")),
                .Usuario = Convert.ToString(row("Usuario")),
                .Clave = Convert.ToString(row("Clave")),
                .Estado = Convert.ToBoolean(row("Estado")),
                .FechaRegistro = Convert.ToDateTime(row("FechaRegistro"))
            }
            lista.Add(login)
        Next
        Return lista
    End Function

    Public Function ObtenerTodosLosUsuarios() As IEnumerable(Of TLogin) Implements IRepositorio_Login.GetAllUser
        Throw New NotImplementedException()
    End Function

    Public Function BuscarTodosUsuarioPassord(usuario As String, password As String) As TLogin Implements IRepositorio_Generico(Of TLogin).GetAllUserPass
        Throw New NotImplementedException()
    End Function

    Private Function IRepositorio_Generico_Insertar(entity As TLogin) As Integer Implements IRepositorio_Generico(Of TLogin).Add
        parameter = New List(Of SqlParameter) From {
            New SqlParameter("@EmpleadoID", entity.EmpleadoID),
            New SqlParameter("@UbicacionID", entity.UbicacionID),
            New SqlParameter("@RolID", entity.RolID),
            New SqlParameter("@Usuario", entity.Usuario),
            New SqlParameter("@Pass", entity.Clave),
            New SqlParameter("@Estado", entity.Estado),
            New SqlParameter("@FechaRegistro", entity.FechaRegistro)
        }
        Return ExecuteNonQuery(Insertar)
    End Function

    Private Function IRepositorio_Generico_Actualizar(entity As TLogin) As Integer Implements IRepositorio_Generico(Of TLogin).Edit
        parameter = New List(Of SqlParameter) From {
            New SqlParameter("@EmpleadoID", entity.EmpleadoID),
            New SqlParameter("@UbicacionID", entity.UbicacionID),
            New SqlParameter("@RolID", entity.RolID),
            New SqlParameter("@Usuario", entity.Usuario),
            New SqlParameter("@Pass", entity.Clave),
            New SqlParameter("@Estado", entity.Estado),
            New SqlParameter("@FechaRegistro", entity.FechaRegistro)
        }
        Return ExecuteNonQuery(Actualizar)
    End Function

    Private Function IRepositorio_Generico_Eliminar(id As Integer) As Integer Implements IRepositorio_Generico(Of TLogin).Remove
        parameter = New List(Of SqlParameter) From {
            New SqlParameter("@Id", id)
        }
        Return ExecuteNonQuery(Eliminar)
    End Function
End Class
