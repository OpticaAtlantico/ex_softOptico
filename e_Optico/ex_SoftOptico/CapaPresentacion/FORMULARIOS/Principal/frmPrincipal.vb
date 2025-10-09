Imports FontAwesome.Sharp

Public Class frmPrincipal
    Inherits Form

    Private pnlEncabezado As Panel
    Private pnlMenu As Panel
    Private pnlContenedor As Panel
    Private drawerFlotante As DrawerbasicUI
    Private btnHamburguesa As IconButton
    Private btnMin As IconButton
    Private btnMax As IconButton
    Private btnClose As IconButton

    Public Sub New()
        Me.Text = "Dashboard Principal"
        Me.Size = New Size(1200, 700)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.None
        Me.BackColor = Color.WhiteSmoke

        InicializarUI()
    End Sub

    Private Sub InicializarUI()
        ' ENCABEZADO SUPERIOR
        pnlEncabezado = New Panel() With {
            .Dock = DockStyle.Top,
            .Height = 45,
            .BackColor = Color.FromArgb(33, 37, 41)
        }
        Me.Controls.Add(pnlEncabezado)

        btnHamburguesa = CrearBotonEncabezado(IconChar.Bars, Color.White)
        btnHamburguesa.Location = New Point(10, 5)
        AddHandler btnHamburguesa.Click, AddressOf ToggleDrawer

        btnMin = CrearBotonEncabezado(IconChar.WindowMinimize, Color.White)
        btnMax = CrearBotonEncabezado(IconChar.WindowMaximize, Color.White)
        btnClose = CrearBotonEncabezado(IconChar.Times, Color.IndianRed)

        Dim botones = {btnMin, btnMax, btnClose}
        Dim posX As Integer = Me.Width - 120
        For Each b In botones
            b.Location = New Point(posX, 5)
            posX += 35
            pnlEncabezado.Controls.Add(b)
        Next

        pnlEncabezado.Controls.Add(btnHamburguesa)

        ' PANEL MENU PRINCIPAL
        pnlMenu = New Panel() With {
            .Dock = DockStyle.Left,
            .Width = 60,
            .BackColor = Color.FromArgb(52, 58, 64)
        }
        Me.Controls.Add(pnlMenu)

        ' PANEL CONTENEDOR
        pnlContenedor = New Panel() With {
            .Dock = DockStyle.Fill,
            .BackColor = Color.White
        }
        Me.Controls.Add(pnlContenedor)

        ' DRAWER flotante
        drawerFlotante = New DrawerbasicUI() With {
            .Visible = False
        }
        Me.Controls.Add(drawerFlotante)
        drawerFlotante.BringToFront()

        AddHandler drawerFlotante.OpcionSeleccionada, Sub(form)
                                                          AbrirFormulario(form)
                                                      End Sub

        ' BOTONES DEL MENU PRINCIPAL
        Dim menuBtns = {
            CrearBotonMenu(IconChar.Users, "Empleados"),
            CrearBotonMenu(IconChar.ShoppingCart, "Compras"),
            CrearBotonMenu(IconChar.CashRegister, "Ventas"),
            CrearBotonMenu(IconChar.ChartLine, "Reportes")
        }

        Dim y As Integer = 60
        For Each b In menuBtns
            b.Location = New Point(0, y)
            pnlMenu.Controls.Add(b)
            AddHandler b.Click, AddressOf MostrarDrawer
            y += 55
        Next
    End Sub

    Private Function CrearBotonEncabezado(icono As IconChar, color As Color) As IconButton
        Dim btn = New IconButton() With {
            .Size = New Size(30, 30),
            .FlatStyle = FlatStyle.Flat,
            .IconChar = icono,
            .IconColor = color,
            .IconSize = 20,
            .Cursor = Cursors.Hand
        }
        btn.FlatAppearance.BorderSize = 0
        Return btn
    End Function

    Private Function CrearBotonMenu(icono As IconChar, tagName As String) As IconButton
        Dim btn = New IconButton() With {
            .Size = New Size(60, 50),
            .FlatStyle = FlatStyle.Flat,
            .IconChar = icono,
            .IconColor = Color.White,
            .IconSize = 24,
            .Tag = tagName,
            .Cursor = Cursors.Hand
        }
        btn.FlatAppearance.BorderSize = 0
        Return btn
    End Function

    Private Sub ToggleDrawer(sender As Object, e As EventArgs)
        drawerFlotante.Visible = Not drawerFlotante.Visible
        drawerFlotante.Location = New Point(pnlMenu.Right, pnlEncabezado.Bottom)
        drawerFlotante.Height = Me.Height - pnlEncabezado.Height
    End Sub

    Private Sub MostrarDrawer(sender As Object, e As EventArgs)
        Dim btn = DirectCast(sender, IconButton)
        Dim opcionesPorCategoria As New Dictionary(Of String, List(Of (String, Form)))

        Select Case btn.Tag.ToString()
            Case "Empleados"
                opcionesPorCategoria("Gestión de Empleados") = New List(Of (String, Form)) From {
                    ("Registrar Empleado", New frmEmpleado()),
                    ("Consultar Empleados", New frmConsultaEmpleados())
                }

            Case "Compras"
                opcionesPorCategoria("Gestión de Compras") = New List(Of (String, Form)) From {
                    ("Nueva Compra", New frmCompras()),
                    ("Proveedores", New frmProveedor())
                }

            Case "Ventas"
                opcionesPorCategoria("Gestión de Ventas") = New List(Of (String, Form)) From {
                    ("Nueva Venta", New frmListarProductos()),
                    ("Historial", New frmDetallesCompra())
                }

            Case "Reportes"
                opcionesPorCategoria("Reportes") = New List(Of (String, Form)) From {
                    ("Reporte de Ventas", New frmPerfilUsuario()),
                    ("Inventario", New frmProveedor())
                }
        End Select

        drawerFlotante.CargarOpcionesAcordeon(opcionesPorCategoria)
        drawerFlotante.Location = New Point(pnlMenu.Right, pnlEncabezado.Bottom)
        drawerFlotante.Height = Me.Height - pnlEncabezado.Height
        drawerFlotante.Visible = True
        drawerFlotante.BringToFront()
    End Sub

    Private Sub AbrirFormulario(form As Form)
        pnlContenedor.Controls.Clear()
        form.TopLevel = False
        form.Dock = DockStyle.Fill
        pnlContenedor.Controls.Add(form)
        form.Show()
    End Sub
End Class
