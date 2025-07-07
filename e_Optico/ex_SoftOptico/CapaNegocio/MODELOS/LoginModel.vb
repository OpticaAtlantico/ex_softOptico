Imports CapaDatos
Imports CapaEntidad
Imports Microsoft.EntityFrameworkCore
Imports System.ComponentModel.DataAnnotations

Public Class LoginModel
    Private _LoginID As Integer
    Private _EmpleadoID As String
    Private _UbicacionID As String
    Private _RolID As String
    Private _Usuario As String
    Private _Clave As String
    Private _Estado As Boolean
    Private _FechaRegistro As DateTime
    Private _state As EstadoIdentidad
    Private repositorio As IRepositorio_Login

#Region "Propiedades Privadas"
    Public Property LoginID As Integer
        Get
            Return _LoginID
        End Get
        Set(value As Integer)
            _LoginID = value
        End Set
    End Property

    Public Property EmpleadoID As String
        Get
            Return _EmpleadoID
        End Get
        Set(value As String)
            _EmpleadoID = value
        End Set
    End Property

    Public Property UbicacionID As String
        Get
            Return _UbicacionID
        End Get
        Set(value As String)
            _UbicacionID = value
        End Set
    End Property

    Public Property RolID As String
        Get
            Return _RolID
        End Get
        Set(value As String)
            _RolID = value
        End Set
    End Property

    Public Property Usuario As String
        Get
            Return _Usuario
        End Get
        Set(value As String)
            _Usuario = value
        End Set
    End Property

    Public Property Clave As String
        Get
            Return _Clave
        End Get
        Set(value As String)
            _Clave = value
        End Set
    End Property

    Public Property Estado As Boolean
        Get
            Return _Estado
        End Get
        Set(value As Boolean)
            _Estado = value
        End Set
    End Property

    Public Property FechaRegistro As Date
        Get
            Return _FechaRegistro
        End Get
        Set(value As Date)
            _FechaRegistro = value
        End Set
    End Property

    Public Property State As EstadoIdentidad
        Get
            Return _state
        End Get
        Set(value As EstadoIdentidad)
            _state = value
        End Set
    End Property
#End Region
    ' Constructor por defecto
    Public Sub New()
        repositorio = New Repositorio_Login()
    End Sub

    Public Function SaveChanges() As String
        Dim message As String = String.Empty
        Try
            Dim loginDataModel As New TLogin With {
                .LoginID = Me.LoginID,
                .EmpleadoID = Me.EmpleadoID,
                .UbicacionID = Me.UbicacionID,
                .RolID = Me.RolID,
                .Usuario = Me.Usuario,
                .Clave = Me.Clave,
                .Estado = Me.Estado,
                .FechaRegistro = Me.FechaRegistro
            }
            Select Case State
                Case EntityState.Added
                    repositorio.Add(loginDataModel)
                    message = "Registro agregado correctamente."
                Case EntityState.Modified
                    repositorio.Edit(loginDataModel)
                    message = "Registro actualizado correctamente."
                Case EntityState.Deleted
                    repositorio.Remove(_LoginID)
                    message = "Registro eliminado correctamente."
            End Select
        Catch ex As Exception
            Dim sqlEx As Microsoft.Data.SqlClient.SqlException = TryCast(ex, Microsoft.Data.SqlClient.SqlException)
            If sqlEx IsNot Nothing Then
                Select Case sqlEx.Number
                    Case 2627 ' Violación de clave única
                        message = "El registro ya existe."
                    Case 547 ' Violación de clave foránea
                        message = "No se puede eliminar el registro porque está siendo utilizado en otra parte."
                    Case Else
                        message = "Error al procesar la solicitud: " & ex.Message
                End Select
            Else
                message = "Error inesperado: " & ex.Message
            End If
        End Try
        Return message
    End Function

    Public Function GetUserPass(usuario As String, clave As String) As List(Of LoginModel)
        Dim loginListViewModel = New List(Of LoginModel)
        Dim listaLoginDataModel = repositorio.GetAllUserPass(usuario, clave)
        Try
            For Each item As TLogin In listaLoginDataModel
                Dim loginModel = New LoginModel With {
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

    Public Function GetLogin() As List(Of LoginModel)
        Dim loginListViewModel = New List(Of LoginModel)
        Dim listaLoginDataModel = repositorio.GetAll()
        Try
            For Each item As TLogin In listaLoginDataModel
                Dim loginModel = New LoginModel With {
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

    Public Function FindByUserPass(user As String, pass As String) As IEnumerable(Of LoginModel)
        Return GetUserPass(user, pass).Where(Function(x) x.Usuario = user AndAlso x.Clave = pass)
    End Function

    Public Function FindById(id As Integer) As IEnumerable(Of LoginModel)
        Return GetLogin().FindAll(Function(emp) Convert.ToString(emp.LoginID).Contains(id))
    End Function



End Class
