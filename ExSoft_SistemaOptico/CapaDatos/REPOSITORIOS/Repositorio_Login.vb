Imports System.Data
Imports Microsoft.Data.SqlClient

Public Class Repositorio_Login
    Inherits Repositorio_Maestro
    Implements IRepositorio_Login

    'Public listLogin = New List(Of tab_LOGIN)

    Private selecAll As String
    Private selectPassUser As String
    Private insert As String
    Private update As String
    Private delete As String

    Public Sub New()
        selecAll = "SELECT * FROM tab_LOGIN"

        selectPassUser = "SELECT * FROM V_LOGIN WHERE Usuario=@usuario And Clave=@pass"

        insert = "INSERT INTO tab_LOGIN VALUES(@idRol,@idEmpleado,@usuario,@idPermisos
                                               @idSucursal,@clave,@estado,@fechaRegistro)"

        update = "UPDATE tab_LOGIN SET IdRol=@idRol, 
                                        IdEmpleado=@idEmpleado, 
                                        IdPermisos=@idPermisos, 
                                        IdSucursal=@idSucursal, 
                                        Usuario=@usuario, 
                                        Clave=@clave, 
                                        Estado=@estado, 
                                        FechaRegistro=@fechaRegistro 
                                        WHERE IdLogin=@idLogin"

        delete = "DELETE FROM tab_LOGIN WHERE idLogin=@idLogin"
    End Sub

    Public Function GetAll() As IEnumerable(Of tab_LOGIN) Implements IRepositorio_Generico(Of tab_LOGIN).GetAll
        Dim resultadoTable = ExcecuteReader(selecAll)
        Dim listLogin = New List(Of tab_LOGIN)

        For Each item As DataRow In resultadoTable.Rows
            listLogin.Add(New tab_LOGIN With {
            .IdLogin = item(0),
            .IdRol = item(1),
            .IdEmpleado = item(2),
            .IdPermisos = item(3),
            .IdSucursal = item(4),
            .Usuario = item(5),
            .Clave = item(6),
            .Estado = item(7),
            .FechaRegistro = item(8)
            })
        Next
        Return listLogin
    End Function

    Public Function Add(entity As tab_LOGIN) As Integer Implements IRepositorio_Generico(Of tab_LOGIN).Add
        parameter = New List(Of SqlParameter) From {
            New SqlParameter("@idRol", entity.IdRol),
            New SqlParameter("@idEmpleado", entity.IdEmpleado),
            New SqlParameter("@idPermisos", entity.IdPermisos),
            New SqlParameter("@idSucursal", entity.IdSucursal),
            New SqlParameter("@usuario", entity.Usuario),
            New SqlParameter("@clave", entity.Clave),
            New SqlParameter("@estado", entity.Estado),
            New SqlParameter("@fechaRegistro", entity.FechaRegistro)
        }
        Return ExecuteNomQuery(insert)
    End Function

    Public Function Edit(entity As tab_LOGIN) As Integer Implements IRepositorio_Generico(Of tab_LOGIN).Edit
        parameter = New List(Of SqlParameter) From {
            New SqlParameter("@idLogin", entity.IdLogin),
            New SqlParameter("@idRol", entity.IdRol),
            New SqlParameter("@idEmpleado", entity.IdEmpleado),
            New SqlParameter("@idPermisos", entity.IdPermisos),
            New SqlParameter("@idSucursal", entity.IdSucursal),
            New SqlParameter("@usuario", entity.Usuario),
            New SqlParameter("@clave", entity.Clave),
            New SqlParameter("@estado", entity.Estado),
            New SqlParameter("@fechaRegistro", entity.FechaRegistro)
        }
        Return ExecuteNomQuery(update)
    End Function

    Public Function Remove(id As Integer) As Integer Implements IRepositorio_Generico(Of tab_LOGIN).Remove
        parameter = New List(Of SqlParameter) From {
            New SqlParameter("@idLogin", id)
        }
        Return ExecuteNomQuery(delete)
    End Function

    Public Function GetAllUsuarios() As IEnumerable(Of tab_LOGIN) Implements IRepositorio_Login.GetAllUsuarios
        Throw New NotImplementedException()
    End Function

    Public Function GetAllUserPass(user As String, pass As String) As IEnumerable(Of tab_LOGIN) Implements IRepositorio_Generico(Of tab_LOGIN).GetAllUserPass
        parameter = New List(Of SqlParameter) From {
            New SqlParameter("@usuario", user),
            New SqlParameter("@pass", pass)
        }
        Dim resultadoTable = ExcecuteReaderUsePass(selectPassUser, user, pass)
        If resultadoTable.Rows.Count = 1 Then
            For Each item As DataRow In resultadoTable.Rows
                listLogin.Add(New tab_LOGIN With {
                .Cedula = item(0),
                .Nombre = item(1),
                .Posicion = item(2),
                .Users = item(3),
                .Pass = item(4),
                .Activo = item(5),
               .Fecha = item(6)
            })
                _cedula1 = item(0)
                _nombre1 = item(1)
                _posicion1 = item(2)
                _users1 = item(3)
                _pass1 = item(4)
                _activo1 = item(5)
                _fecha1 = item(6)
            Next
        End If
        Return listLogin
    End Function
End Class
