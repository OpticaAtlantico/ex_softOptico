Imports CapaDatos
Imports CapaEntidad

Public Class UserModel
    Dim userDao As New UserDao()

#Region "ATTRIBUTES"
    Private IdRol
    Private IdEmpleado
    Private Usuario
    Private Clave
    Private Estado

    Public Property IdRol1 As Object
        Get
            Return IdRol
        End Get
        Set(value As Object)
            IdRol = value
        End Set
    End Property

    Public Property IdEmpleado1 As Object
        Get
            Return IdEmpleado
        End Get
        Set(value As Object)
            IdEmpleado = value
        End Set
    End Property

    Public Property Usuario1 As Object
        Get
            Return Usuario
        End Get
        Set(value As Object)
            Usuario = value
        End Set
    End Property

    Public Property Clave1 As Object
        Get
            Return Clave
        End Get
        Set(value As Object)
            Clave = value
        End Set
    End Property

    Public Property Estado1 As Object
        Get
            Return Estado
        End Get
        Set(value As Object)
            Estado = value
        End Set
    End Property

#End Region

#Region "CONSTRUCOR"
    Public Sub New(idRol As Object, idEmpleado As Object, usuario As Object, clave As Object, estado As Object)
        Me.IdRol1 = idRol
        Me.IdEmpleado1 = idEmpleado
        Me.Usuario1 = usuario
        Me.Clave1 = clave
        Me.Estado1 = estado
    End Sub
    Public Sub New()

    End Sub
#End Region

#Region "METODOS"
    Public Function editUserProfile() As String
        Try
            userDao.EditLogin(IdRol1, IdEmpleado1, Usuario1, Clave1, Estado1)
            Login(Usuario1, Clave1)
            Return "Sus datos de perfil se actualizaron con exito"
        Catch ex As Exception
            Return "El usuario que intenta ingresar ya existe, intente nuevamente"
        End Try
    End Function
    Public Function Login(correo As String, pass As String) As Boolean
        Return userDao.Login(correo, pass)
    End Function

#End Region

End Class
