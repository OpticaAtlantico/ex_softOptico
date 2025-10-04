Imports System.Windows.Forms
Imports FontAwesome.Sharp

Public Class frmPrincipal
    Inherits Form

    ' === Controles base ===
    Private pnlEncabezado As New Panel()
    Private pnlMenu As New Panel()
    Private pnlContenedor As New Panel()
    Private btnHamburguesa As New IconButton()
    Private drawer As DrawerControlUI

    ' === Formulario hijo activo ===
    Private currentChildForm As Form = Nothing

    ' === Constructor ===
    Public Sub New()
        Me.Text = "Sistema Óptica - Principal"
        Me.WindowState = FormWindowState.Maximized
        Me.BackColor = Color.White
        Me.MinimumSize = New Size(1000, 600)

        ' ---- Encabezado ----
        pnlEncabezado.Dock = DockStyle.Top
        pnlEncabezado.Height = 50
        pnlEncabezado.BackColor = Color.FromArgb(45, 45, 48)

        ' Botón hamburguesa
        btnHamburguesa.IconChar = IconChar.Bars
        btnHamburguesa.IconColor = Color.White
        btnHamburguesa.IconSize = 25
        btnHamburguesa.Dock = DockStyle.Left
        btnHamburguesa.FlatStyle = FlatStyle.Flat
        btnHamburguesa.FlatAppearance.BorderSize = 0
        btnHamburguesa.Width = 50

        ' ---- Panel menú (contendrá el drawer) ----
        pnlMenu.Dock = DockStyle.Left
        pnlMenu.Width = 220 ' colapsado inicial
        pnlMenu.BackColor = Color.FromArgb(28, 28, 30)

        ' ---- Panel contenedor ----
        pnlContenedor.Dock = DockStyle.Fill
        pnlContenedor.BackColor = Color.White

        ' ---- Drawer ----
        drawer = New DrawerControlUI()
        drawer.Dock = DockStyle.Left

        ' Iniciar drawer colapsado
        drawer.Width = 220
        drawer.ToggleDrawer() ' asegura que se inicie compacto

        Me.Controls.Add(pnlContenedor)
        pnlMenu.Controls.Add(drawer)
        Me.Controls.Add(pnlMenu)
        pnlEncabezado.Controls.Add(btnHamburguesa)
        Me.Controls.Add(pnlEncabezado)

        ' Eventos
        AddHandler btnHamburguesa.Click, AddressOf ToggleMenu
        AddHandler drawer.OpcionSeleccionada, AddressOf Drawer_OpcionSeleccionada
    End Sub

    ' =======================
    ' Eventos
    ' =======================
    Private Sub ToggleMenu(sender As Object, e As EventArgs)
        drawer.ToggleDrawer()
        pnlMenu.Width = drawer.Width ' sincronizar ancho
    End Sub

    Private Sub Drawer_OpcionSeleccionada(opcion As String)
        Select Case opcion
            Case "Gestión de Empleados"
                OpenChildForm(New frmEmpleado())
            Case "Nueva Compra"
                OpenChildForm(New frmCompras())
            Case "Nueva Venta"
                OpenChildForm(New frmConsultaEmpleados())
            Case Else
                MessageBox.Show("Seleccionaste: " & opcion)
        End Select
    End Sub

    ' =======================
    ' Método para abrir hijos
    ' =======================
    Private Sub OpenChildForm(childForm As Form)
        ' Cierra el form activo si existe
        If currentChildForm IsNot Nothing Then
            currentChildForm.Close()
        End If

        currentChildForm = childForm
        With childForm
            .TopLevel = False
            .FormBorderStyle = FormBorderStyle.None
            .Dock = DockStyle.Fill
        End With

        pnlContenedor.Controls.Clear()
        pnlContenedor.Controls.Add(childForm)
        pnlContenedor.Tag = childForm
        childForm.BringToFront()
        childForm.Show()
    End Sub
End Class
