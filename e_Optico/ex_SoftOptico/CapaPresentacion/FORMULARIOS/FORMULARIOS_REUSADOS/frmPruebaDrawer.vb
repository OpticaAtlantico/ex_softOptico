' =======================================================
' frm_Principal.vb
' Ejemplo completo de formulario principal
' con DrawerControlAdvanced y apertura de formularios hijos
' =======================================================

Imports System.Windows.Forms

Public Class frmPruebaDrawer
    Inherits Form

    ' Panel contenedor para formularios hijos
    Private PanelContenedor As New Panel
    Private drawer As DrawerControlUI
    Private formularioActivo As Form = Nothing

    Public Sub New()
        ' Inicialización
        Me.Text = "Sistema Principal"
        Me.Size = New Size(1000, 600)
        Me.StartPosition = FormStartPosition.CenterScreen

        ' Panel contenedor central
        PanelContenedor.Dock = DockStyle.Fill
        Me.Controls.Add(PanelContenedor)

        ' Drawer lateral
        drawer = New DrawerControlUI With {
            .Dock = DockStyle.Left
        }
        Me.Controls.Add(drawer)
        drawer.BringToFront()

        ' Suscribir evento de selección del drawer
        AddHandler drawer.OpcionSeleccionada, AddressOf Drawer_OpcionSeleccionada
    End Sub

    ' ===============================
    ' Abrir formulario hijo
    ' ===============================
    Private Sub AbrirFormularioHijo(childForm As Form)
        ' Cierra formulario activo si existe
        If formularioActivo IsNot Nothing Then
            formularioActivo.Close()
        End If

        ' Configura el nuevo formulario
        formularioActivo = childForm
        childForm.TopLevel = False
        childForm.FormBorderStyle = FormBorderStyle.None
        childForm.Dock = DockStyle.Fill

        ' Agrega al panel contenedor
        PanelContenedor.Controls.Add(childForm)
        PanelContenedor.Tag = childForm
        childForm.BringToFront()
        childForm.Show()
    End Sub

    ' ===============================
    ' Manejo de opciones del Drawer
    ' ===============================
    Private Sub Drawer_OpcionSeleccionada(opcion As String)
        Select Case opcion
            Case "Empleados"
                Dim frmEmp As New frmEmpleado() ' Tu formulario de empleados
                AbrirFormularioHijo(frmEmp)

            Case "Compras"
                Dim frmComp As New frmCompras() ' Tu formulario de compras
                AbrirFormularioHijo(frmComp)

                'Case "Ventas"
                '    Dim frmVent As New frmVenta() ' Tu formulario de ventas
                '    AbrirFormularioHijo(frmVent)

                'Case "Reportes"
                '    Dim frmRep As New frmReporte() ' Tu formulario de reportes
                '    AbrirFormularioHijo(frmRep)

                'Case "Configuración"
                '    Dim frmConf As New frmConfiguracion() ' Tu formulario de configuración
                '    AbrirFormularioHijo(frmConf)

        End Select

        ' Resalta botón activo en Drawer
        drawer.MarcarBotonActivo(opcion, Nothing)
    End Sub

    ' ===============================
    ' Ejemplo Dark/Light Mode
    ' ===============================
    Public Sub ActivarDarkMode(isDark As Boolean)
        drawer.ActualizarModo(isDark)
        Me.BackColor = If(isDark, Color.FromArgb(45, 45, 48), Color.White)
        PanelContenedor.BackColor = Me.BackColor
    End Sub

End Class

' =======================================================
' NOTAS DE USO:
' 1) Agrega este frm_Principal.vb a tu proyecto.
' 2) Asegúrate de haber agregado DrawerControlAdvanced.vb.
' 3) Crea los formularios hijos: frmEmpleados, frmCompras, frmVentas, frmReportes, frmConfiguracion.
' 4) En Program.vb o Sub Main, instancia y muestra frm_Principal:
'       Application.Run(New frm_Principal())
' 5) El Drawer animará automáticamente al pasar el mouse.
' 6) El panel central mostrará solo un formulario hijo activo a la vez.
' =======================================================






















'Public Class frmPruebaDrawer
'    Inherits Form

'    Private PanelEncabezado As New Panel()
'    Private PanelMenu As New Panel()
'    Private PanelContenido As New Panel()
'    Private DrawerPanel As New Panel()
'    Private BotonDrawer As New Button()
'    Private WithEvents DrawerTimer As New Timer()

'    ' Control de animación
'    Private DrawerVisible As Boolean = False
'    Private DrawerTargetX As Integer = 60
'    Private DrawerSpeed As Integer = 20

'    Public Sub New()
'        Me.Text = "Ejemplo de Drawer UI con Slide"
'        Me.Size = New Size(900, 600)
'        Me.StartPosition = FormStartPosition.CenterScreen
'        Me.BackColor = Color.White

'        DrawerTimer.Interval = 15
'        InicializarLayout()
'    End Sub

'    Private Sub InicializarLayout()
'        ' === Panel Encabezado ===
'        PanelEncabezado.BackColor = Color.DarkSlateGray
'        PanelEncabezado.Dock = DockStyle.Top
'        PanelEncabezado.Height = 50
'        Me.Controls.Add(PanelEncabezado)

'        ' === Panel Menú ===
'        PanelMenu.BackColor = Color.LightGray
'        PanelMenu.Dock = DockStyle.Left
'        PanelMenu.Width = 60
'        Me.Controls.Add(PanelMenu)

'        ' === Panel Contenido ===
'        PanelContenido.BackColor = Color.WhiteSmoke
'        PanelContenido.Dock = DockStyle.Fill
'        Me.Controls.Add(PanelContenido)

'        ' === Botón para activar el Drawer ===
'        BotonDrawer.Text = "≡"
'        BotonDrawer.Size = New Size(40, 40)
'        BotonDrawer.Location = New Point(10, 5)
'        PanelEncabezado.Controls.Add(BotonDrawer)
'        AddHandler BotonDrawer.Click, AddressOf ToggleDrawer

'        ' === Drawer Panel ===
'        DrawerPanel.BackColor = Color.FromArgb(245, 245, 245)
'        DrawerPanel.BorderStyle = BorderStyle.FixedSingle
'        DrawerPanel.Size = New Size(200, Me.Height - PanelEncabezado.Height)
'        DrawerPanel.Location = New Point(-DrawerPanel.Width, PanelEncabezado.Height)
'        DrawerPanel.Visible = True ' Visible siempre, pero fuera de vista
'        DrawerPanel.Anchor = AnchorStyles.Top Or AnchorStyles.Left

'        ' Contenido de ejemplo
'        Dim lblDrawer As New Label With {
'            .Text = "Opciones del Drawer",
'            .AutoSize = True,
'            .Location = New Point(10, 10),
'            .Font = New Font("Segoe UI", 10, FontStyle.Bold)
'        }
'        DrawerPanel.Controls.Add(lblDrawer)

'        Me.Controls.Add(DrawerPanel)
'        DrawerPanel.BringToFront()
'    End Sub

'    Private Sub ToggleDrawer(sender As Object, e As EventArgs)
'        ' Determinar destino de animación
'        DrawerVisible = Not DrawerVisible
'        DrawerTargetX = If(DrawerVisible, 60, -DrawerPanel.Width)
'        DrawerTimer.Start()
'    End Sub

'    Private Sub DrawerTimer_Tick(sender As Object, e As EventArgs) Handles DrawerTimer.Tick
'        Dim posActual = DrawerPanel.Left
'        Dim destino = DrawerTargetX

'        If posActual < destino Then
'            posActual += DrawerSpeed
'            If posActual > destino Then posActual = destino
'        ElseIf posActual > destino Then
'            posActual -= DrawerSpeed
'            If posActual < destino Then posActual = destino
'        End If

'        DrawerPanel.Left = posActual

'        If posActual = destino Then
'            DrawerTimer.Stop()
'        End If
'    End Sub

'End Class
