Imports CapaDatos
Imports Microsoft.EntityFrameworkCore
Imports System.ComponentModel.DataAnnotations

Public Class Login_Model
    Private _IdLogin As Integer
    Private _IdRol As Integer
    Private _IdEmpleado As Integer
    Private _IdPermisos As Integer
    Private _IdSucursal As Integer
    Private _Usuario As String
    Private _Clave As String
    Private _Estado As Byte
    Private _FechaRegistro As Date
    Private _State As Estado_Identidad
    Private Repositorio As IRepositorio_Login

    Private _Cedula As String
    Private _Nombre As String
    Private _Posicion As String
    Private _Usuarios As String
    Private _Claves As String
    Private _Estados As Byte
    Private _Fecha As Date


#Region "PROPIEDADES/VISTAMODELO/DATA VALIDACION"
    Public Property IdLogin As Integer
        Private Get
            Return _IdLogin
        End Get
        Set(value As Integer)
            _IdLogin = value
        End Set
    End Property

    <Required>
    Public Property IdRol As Integer
        Get
            Return _IdRol
        End Get
        Set(value As Integer)
            _IdRol = value
        End Set
    End Property

    Public Property IdEmpleado As Integer
        Get
            Return _IdEmpleado
        End Get
        Set(value As Integer)
            _IdEmpleado = value
        End Set
    End Property

    Public Property IdPermisos As Integer
        Get
            Return _IdPermisos
        End Get
        Set(value As Integer)
            _IdPermisos = value
        End Set
    End Property

    Public Property IdSucursal As Integer
        Get
            Return _IdSucursal
        End Get
        Set(value As Integer)
            _IdSucursal = value
        End Set
    End Property

    <Required>
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

    Public Property Estado As Byte
        Get
            Return _Estado
        End Get
        Set(value As Byte)
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

    Public Property State As Estado_Identidad
        Get
            Return _State
        End Get
        Private Set(value As Estado_Identidad)
            _State = value
        End Set
    End Property

    Public Property Cedula As String
        Get
            Return _Cedula
        End Get
        Set(value As String)
            _Cedula = value
        End Set
    End Property

    Public Property Nombre As String
        Get
            Return _Nombre
        End Get
        Set(value As String)
            _Nombre = value
        End Set
    End Property

    Public Property Posicion As String
        Get
            Return _Posicion
        End Get
        Set(value As String)
            _Posicion = value
        End Set
    End Property

    Public Property Usuarios As String
        Get
            Return _Usuarios
        End Get
        Set(value As String)
            _Usuarios = value
        End Set
    End Property

    Public Property Claves As String
        Get
            Return _Claves
        End Get
        Set(value As String)
            _Claves = value
        End Set
    End Property

    Public Property Estados As Byte
        Get
            Return _Estados
        End Get
        Set(value As Byte)
            _Estados = value
        End Set
    End Property

    Public Property Fecha As Date
        Get
            Return _Fecha
        End Get
        Set(value As Date)
            _Fecha = value
        End Set
    End Property

#End Region

    'CONSTRUCTOR

    Public Sub New()
        Repositorio = New Repositorio_Login()
    End Sub

    'METHODOS
    Public Function SaveChange() As String
        Dim message As String = Nothing

        Try
            Dim loginDataModel As New tab_LOGIN With {
                .IdLogin = IdLogin,
                .IdRol = IdRol,
                .IdEmpleado = IdEmpleado,
                .IdPermisos = IdPermisos,
                .IdSucursal = IdSucursal,
                .Usuario = Usuario,
                .Clave = Clave,
                .Estado = Estado,
                .FechaRegistro = FechaRegistro
            }

            Select Case State
                Case EntityState.Added
                    Repositorio.Add(loginDataModel)
                    message = "Record almacenado correctamemte"
                Case EntityState.Modified
                    Repositorio.Edit(loginDataModel)
                    message = "Record modificado correctamemte"
                Case EntityState.Deleted
                    Repositorio.Remove(IdLogin)
                    message = "Record eliminado correctamemte"

            End Select

        Catch ex As Exception
            Dim sqlEx As Microsoft.Data.SqlClient.SqlException = TryCast(ex, Microsoft.Data.SqlClient.SqlException)
            If sqlEx IsNot Nothing AndAlso sqlEx.Number = 2627 Then
                message = "Datos Duplicados"
            Else
                message = ex.ToString()
            End If

        End Try

        Return message
    End Function

    Public Function GetUserPass(Usuario As String, Clave As String) As List(Of Login_Model)
        Dim listaLoginViewModel = New List(Of Login_Model)
        Dim listaLoginDataModel = Repositorio.GetAllUserPass(Usuario, Clave)

        For Each item As tab_LOGIN In listaLoginDataModel
            listaLoginViewModel.Add(New Login_Model With {
                .Cedula = item.Cedula,
                .Nombre = item.Nombre,
                .Posicion = item.Posicion,
                .Usuarios = item.Users,
                .Claves = item.Pass,
                .Estado = item.Activo,
                .Fecha = item.Fecha
                })
        Next
        Return listaLoginViewModel
    End Function

    Public Function GetLogin() As List(Of Login_Model)
        Dim listaLoginViewModel = New List(Of Login_Model)
        Dim listaLoginDataModel = Repositorio.GetAll()

        For Each item As tab_LOGIN In listaLoginDataModel
            listaLoginViewModel.Add(New Login_Model With {
            .IdLogin = item.IdLogin,
            .IdRol = item.IdRol,
            .IdEmpleado = item.IdEmpleado,
            .IdPermisos = item.IdPermisos,
            .IdSucursal = item.IdSucursal,
            .Usuario = item.Usuario,
            .Clave = item.Clave,
            .Estado = item.Estado,
            .FechaRegistro = item.FechaRegistro
            })
        Next
        Return listaLoginViewModel
    End Function

    Public Function FindByUserPass(user As String, pass As String) As IEnumerable(Of Login_Model)
        Return GetUserPass(user, pass)
    End Function

    Public Function FindById(id As Integer) As IEnumerable(Of Login_Model)
        Return GetLogin().FindAll(Function(emp) Convert.ToString(emp.IdLogin).Contains(id))
    End Function

    Private Function CalcularEdad(Fecha As Date) As Integer
        Dim dateNow = Date.Now
        Return Date.Now.Year - dateNow.Year
    End Function

End Class
