Imports CapaDatos
Imports Microsoft.EntityFrameworkCore
Imports System.ComponentModel.DataAnnotations

Public Class LoginModel
    Private _LgoginID As Integer
    Private _EmpleadoID As String
    Private _UbicacionID As String
    Private _RolID As String
    Private _Usuario As String
    Private _Clave As String
    Private _Estado As Boolean
    Private _FechaRegistro As DateTime
    Private _state As EstadoIdentidad
    Private repositorio As IRepositorio_Login

    Public Property LgoginID As Integer
        Get
            Return _LgoginID
        End Get
        Set(value As Integer)
            _LgoginID = value
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



End Class
