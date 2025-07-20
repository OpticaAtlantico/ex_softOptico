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
            Case EstiloBootstrap.Primary : Return Color.FromArgb(33, 150, 243)
            Case EstiloBootstrap.Success : Return Color.FromArgb(76, 175, 80)
            Case EstiloBootstrap.Danger : Return Color.FromArgb(244, 67, 54)
            Case EstiloBootstrap.Warning : Return Color.FromArgb(255, 193, 7)
            Case EstiloBootstrap.Info : Return Color.FromArgb(0, 188, 212)
            Case EstiloBootstrap.Dark : Return Color.FromArgb(66, 66, 66)
            Case Else : Return Color.Gray
        End Select
    End Function
End Class
