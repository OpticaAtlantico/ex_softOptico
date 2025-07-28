Imports CapaDatos
Imports CapaEntidad
Imports Microsoft.EntityFrameworkCore
Imports System.ComponentModel.DataAnnotations

Public Class LoginModel

    Private repositorio As IRepositorio_Login

    ' Constructor por defecto
    Public Sub New()
        repositorio = New Repositorio_Login()
    End Sub

    'Public Function SaveChanges() As String
    '    Dim message As String = String.Empty
    '    Try
    '        Dim loginDataModel As New TLogin With {
    '            .LoginID = Me.LoginID,
    '            .EmpleadoID = Me.EmpleadoID,
    '            .UbicacionID = Me.UbicacionID,
    '            .RolID = Me.RolID,
    '            .Usuario = Me.Usuario,
    '            .Clave = Me.Clave,
    '            .Estado = Me.Estado,
    '            .FechaRegistro = Me.FechaRegistro
    '        }
    '        Select Case State
    '            Case EntityState.Added
    '                repositorio.Add(loginDataModel)
    '                message = "Registro agregado correctamente."
    '            Case EntityState.Modified
    '                repositorio.Edit(loginDataModel)
    '                message = "Registro actualizado correctamente."
    '            Case EntityState.Deleted
    '                repositorio.Remove(_LoginID)
    '                message = "Registro eliminado correctamente."
    '        End Select
    '    Catch ex As Exception
    '        Dim sqlEx As Microsoft.Data.SqlClient.SqlException = TryCast(ex, Microsoft.Data.SqlClient.SqlException)
    '        If sqlEx IsNot Nothing Then
    '            Select Case sqlEx.Number
    '                Case 2627 ' Violación de clave única
    '                    message = "El registro ya existe."
    '                Case 547 ' Violación de clave foránea
    '                    message = "No se puede eliminar el registro porque está siendo utilizado en otra parte."
    '                Case Else
    '                    message = "Error al procesar la solicitud: " & ex.Message
    '            End Select
    '        Else
    '            message = "Error inesperado: " & ex.Message
    '        End If
    '    End Try
    '    Return message
    'End Function


    Public Function FindByUserPass(user As String, pass As String) As IEnumerable(Of TLogin)
        Return GetUserPass(user, pass).Where(Function(x) x.Usuario = user AndAlso x.Clave = pass)
    End Function

    Public Function FindById(id As Integer) As IEnumerable(Of TLogin)
        Return GetLogin().FindAll(Function(emp) Convert.ToString(emp.LoginID).Contains(id))
    End Function

    Public Function GetLogin() As List(Of TLogin)
        Dim loginListViewModel = New List(Of TLogin)
        Dim listaLoginDataModel = repositorio.GetAll()
        Try
            For Each item As TLogin In listaLoginDataModel
                Dim loginModel = New TLogin With {
                    .LoginID = item.LoginID,
                    .EmpleadoID = item.EmpleadoID,
                    .UbicacionID = item.UbicacionID,
                    .RolID = item.RolID,
                    .Usuario = item.Usuario,
                    .Clave = item.Clave,
                    .Estado = item.Estado,
                    .FechaRegistro = item.FechaRegistro
                }
                loginListViewModel.Add(loginModel)
            Next
        Catch ex As Exception
            Throw New Exception("Error al obtener los registros de login: " & ex.Message)
        End Try
        Return loginListViewModel
    End Function

    Public Function GetUserPass(usuario As String, clave As String) As List(Of TLogin)
        Dim loginListViewModel = New List(Of TLogin)
        Dim listaLoginDataModel = repositorio.GetAllUserPass(usuario, clave)
        Try
            For Each item As TLogin In listaLoginDataModel
                Dim loginModel = New TLogin With {
                    .LoginID = item.LoginID,
                    .EmpleadoID = item.EmpleadoID,
                    .UbicacionID = item.UbicacionID,
                    .RolID = item.RolID,
                    .Usuario = item.Usuario,
                    .Clave = item.Clave,
                    .Estado = item.Estado,
                    .FechaRegistro = item.FechaRegistro
                }
                loginListViewModel.Add(loginModel)
            Next
        Catch ex As Exception
            Throw New Exception("Error al obtener el usuario y contraseña: " & ex.Message)
        End Try
        Return loginListViewModel
    End Function

End Class
