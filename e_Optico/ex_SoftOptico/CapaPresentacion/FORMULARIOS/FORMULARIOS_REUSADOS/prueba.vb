' =======================================================
' frm_Principal.vb
' Formulario principal del sistema
' Contiene:
'   - PanelContenedor para abrir formularios hijos
'   - DrawerControlUI como menú lateral
'   - Encabezado con botones de control
'   - Método OpenChildForm para manejar child forms
' =======================================================

Imports System.Windows.Forms
Imports FontAwesome.Sharp

Public Class prueba
    Inherits Form

    ' === Campos privados ===
    Private activeForm As Form = Nothing
    Private drawer As DrawerControlUI

    ' === Controles principales ===
    Private PanelContenedor As New Panel()
    Private PanelEncabezado As New Panel()
    Private BtnMinimizar As New Button()
    Private BtnMaximizar As New Button()
    Private BtnCerrar As New Button()

    ' === Constructor ===
    Public Sub New()
        InitializeComponent()
        ConfigurarFormulario()
        ConfigurarEncabezado()
        ConfigurarContenedor()
        ConfigurarDrawer()
    End Sub

    ' ======================================================
    ' CONFIGURACIÓN GENERAL DEL FORM
    ' ======================================================
    Private Sub ConfigurarFormulario()
        Me.Text = "OpticaERP - Principal"
        Me.WindowState = FormWindowState.Maximized
        Me.FormBorderStyle = FormBorderStyle.None
        Me.BackColor = Color.White
        Me.DoubleBuffered = True
    End Sub

    Private Sub ConfigurarEncabezado()
        PanelEncabezado.Dock = DockStyle.Top
        PanelEncabezado.Height = 40
        PanelEncabezado.BackColor = Color.FromArgb(52, 58, 64)
        Me.Controls.Add(PanelEncabezado)

        ' === Botón Minimizar ===
        BtnMinimizar.Text = "_"
        BtnMinimizar.Width = 40
        BtnMinimizar.Dock = DockStyle.Right
        BtnMinimizar.FlatStyle = FlatStyle.Flat
        BtnMinimizar.ForeColor = Color.White
        BtnMinimizar.FlatAppearance.BorderSize = 0
        AddHandler BtnMinimizar.Click, Sub() Me.WindowState = FormWindowState.Minimized
        PanelEncabezado.Controls.Add(BtnMinimizar)

        ' === Botón Maximizar ===
        BtnMaximizar.Text = "□"
        BtnMaximizar.Width = 40
        BtnMaximizar.Dock = DockStyle.Right
        BtnMaximizar.FlatStyle = FlatStyle.Flat
        BtnMaximizar.ForeColor = Color.White
        BtnMaximizar.FlatAppearance.BorderSize = 0
        AddHandler BtnMaximizar.Click, AddressOf BtnMaximizar_Click
        PanelEncabezado.Controls.Add(BtnMaximizar)

        ' === Botón Cerrar ===
        BtnCerrar.Text = "X"
        BtnCerrar.Width = 40
        BtnCerrar.Dock = DockStyle.Right
        BtnCerrar.FlatStyle = FlatStyle.Flat
        BtnCerrar.ForeColor = Color.White
        BtnCerrar.FlatAppearance.BorderSize = 0
        BtnCerrar.BackColor = Color.Red
        AddHandler BtnCerrar.Click, Sub() Application.Exit()
        PanelEncabezado.Controls.Add(BtnCerrar)
    End Sub

    Private Sub ConfigurarContenedor()
        PanelContenedor.Dock = DockStyle.Fill
        PanelContenedor.BackColor = Color.WhiteSmoke
        Me.Controls.Add(PanelContenedor)
        PanelContenedor.BringToFront()
    End Sub

    Private Sub ConfigurarDrawer()
        drawer = New DrawerControlUI()
        drawer.Dock = DockStyle.Left
        drawer.Width = 220
        Me.Controls.Add(drawer)
        drawer.BringToFront()

        ' === Evento: opción seleccionada en el drawer ===
        'AddHandler drawer.OpcionSeleccionada, AddressOf AbrirFormularioDesdeMenu
    End Sub

    ' ======================================================
    ' MANEJO DE FORMULARIOS HIJOS
    ' ======================================================
    Public Sub OpenChildForm(childForm As Form, Optional btnSender As Object = Nothing)
        If activeForm IsNot Nothing Then
            activeForm.Close()
        End If
        activeForm = childForm
        childForm.TopLevel = False
        childForm.FormBorderStyle = FormBorderStyle.None
        childForm.Dock = DockStyle.Fill
        PanelContenedor.Controls.Add(childForm)
        PanelContenedor.Tag = childForm
        childForm.BringToFront()
        childForm.Show()
    End Sub

    ' ======================================================
    ' EVENTOS
    ' ======================================================
    Private Sub AbrirFormularioDesdeMenu(opcion As String)
        Select Case opcion
            Case "Empleados"
                OpenChildForm(New frmConsultaEmpleados())
            Case "NuevoEmpleado"
                OpenChildForm(New frmEmpleado())
            Case "Compras"
                OpenChildForm(New frmCompras())
            Case "Proveedores"
                OpenChildForm(New frmProveedor())
            Case Else
                MessageBox.Show("Opción no implementada: " & opcion)
        End Select
    End Sub

    Private Sub BtnMaximizar_Click(sender As Object, e As EventArgs)
        If Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal
        Else
            Me.WindowState = FormWindowState.Maximized
        End If
    End Sub

End Class
