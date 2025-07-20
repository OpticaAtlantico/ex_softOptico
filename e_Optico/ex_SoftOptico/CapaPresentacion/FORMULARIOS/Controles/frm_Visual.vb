Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Forms
Imports FontAwesome.Sharp
Public Class frm_Visual
    Inherits Form

    Private Sub frm_Visual_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        '        Dim moduloGeneral As New ModuloGeneralUI()

        '        TabPanel.AddTab(New TabItemOrbitalAdv With {
        '    .Titulo = "General",
        '    .Icono = IconChar.Home,
        '    .Tooltip = "Parámetros generales",
        '    .Contenido = moduloGeneral,
        '    .Estilo = TabItemOrbitalAdv.EstiloBootstrap.Primary,
        '    .EstadoValidacion = TabItemOrbitalAdv.EstadoOrbital.Correcto
        '})


    End Sub

    Public Sub InicializarTabPanelAvanzado(ByVal contenedor As System.Windows.Forms.Control)
        Dim tabPanel As New TabPanelUI() With {
            .Dock = DockStyle.Fill,
            .TabHeight = 44,
            .BackColor = Color.Transparent
        }

        ' ✅ Pestaña de Inicio
        tabPanel.AddTab(New TabItemOrbitalAdv With {
            .Titulo = "Inicio",
            .Icono = IconChar.Home,
            .Tooltip = "Bienvenido al sistema",
            .BadgeTexto = "1",
            .EstadoValidacion = TabItemOrbitalAdv.EstadoOrbital.Correcto,
            .Estilo = TabItemOrbitalAdv.EstiloBootstrap.Primary,
            .Contenido = New System.Windows.Forms.Label() With {
                                                                    .Text = "Módulo cargado",
                                                                    .AutoSize = True,
                                                                    .Location = New Point(30, 30)
                                                                }
        })

        ' ⚙️ Pestaña de Configuración
        tabPanel.AddTab(New TabItemOrbitalAdv With {
            .Titulo = "Configuración",
            .Icono = IconChar.Cogs,
            .Tooltip = "Opciones del sistema",
            .EstadoValidacion = TabItemOrbitalAdv.EstadoOrbital.Pendiente,
            .Estilo = TabItemOrbitalAdv.EstiloBootstrap.Warning,
            .Contenido = New System.Windows.Forms.Label() With {
                                                                    .Text = "Módulo cargado",
                                                                    .AutoSize = True,
                                                                    .Location = New Point(30, 30)
                                                                }
        })

        ' 🔐 Pestaña de Seguridad
        tabPanel.AddTab(New TabItemOrbitalAdv With {
            .Titulo = "Seguridad",
            .Icono = IconChar.ShieldAlt,
            .Tooltip = "Roles y permisos",
            .EstadoValidacion = TabItemOrbitalAdv.EstadoOrbital.Errores,
            .Estilo = TabItemOrbitalAdv.EstiloBootstrap.Danger,
            .Contenido = New System.Windows.Forms.Label() With {
                                                                    .Text = "Módulo cargado",
                                                                    .AutoSize = True,
                                                                    .Location = New Point(30, 30)
                                                                }
        })

        ' Agregar el TabPanel orbital al contenedor visual
        contenedor.Controls.Add(tabPanel)
    End Sub
End Class

'.Contenido = New System.Windows.Forms.Panel() With {.BackColor = Color.Gainsboro, .Dock = DockStyle.Fill}