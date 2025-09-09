Imports FontAwesome.Sharp
Imports System.Drawing

Public Class TabItemOrbitalAdv
    Public Property Titulo As String = "Pestaña"
    Public Property Contenido As Control
    Public Property Icono As IconChar = IconChar.None
    Public Property Estilo As EstiloBootstrap = EstiloBootstrap.Primary
    Public Property Tooltip As String = ""
    Public Property BadgeTexto As String = ""
    Public Property EstadoValidacion As EstadoOrbital = EstadoOrbital.Ninguno

    Public Enum EstiloBootstrap
        Primary
        Success
        Danger
        Warning
        Info
        Dark
    End Enum

    Public Enum EstadoOrbital
        Ninguno
        Correcto
        Pendiente
        Errores
    End Enum

    Public Function ColorBootstrap() As Color
        Select Case Estilo
            Case EstiloBootstrap.Primary : Return AppColors._cBasePrimary
            Case EstiloBootstrap.Success : Return AppColors._cBaseSuccess
            Case EstiloBootstrap.Danger : Return AppColors._cBaseDanger
            Case EstiloBootstrap.Warning : Return AppColors._cBaseWarning
            Case EstiloBootstrap.Info : Return AppColors._cBaseInfo
            Case EstiloBootstrap.Dark : Return AppColors._cBaseDark
            Case Else : Return Color.Gray
        End Select
    End Function
End Class
