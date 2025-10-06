Imports CapaEntidad
Imports FontAwesome.Sharp

Public Class DashBoard
    Private Sub DashBoard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With Me.lblTitulo
            .Icono = IconChar.Eye
            .Titulo = "SISTEMA INTEGRAL DE GESTIÓN OPTICA"
            .Subtitulo = "Administracion, Gestión y Control de Ópticas "
            .ColorFondo = AppColors._cBlanco
            .ColorTexto = AppColors._cTexto
        End With

        With Me.lblEmpleado
            .Icono = IconChar.UsersViewfinder
            .Titulo = Sesion.NombreUsuario
            .Subtitulo = Sesion.Cargo
            .ColorFondo = AppColors._cBlanco
            .ColorTexto = AppColors._cTexto
        End With

        With Me.lblLocalidad
            .Icono = IconChar.LocationDot
            .Titulo = Sesion.NombreUbicacion
            .Subtitulo = Sesion.Direccion
            .ColorFondo = AppColors._cBlanco
            .ColorTexto = AppColors._cTexto
        End With
    End Sub
End Class