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
        ' expandir/colapsar el pnlMenu junto con el drawer
        pnlMenu.Width = drawer.Width
    End Sub

    Private Sub Drawer_OpcionSeleccionada(opcion As String)
        MessageBox.Show("Seleccionaste: " & opcion)
        ' Aquí iría: OpenChildForm(New frmXxx(), opcion)
    End Sub

    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
