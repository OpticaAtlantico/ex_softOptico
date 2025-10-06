Imports System.Drawing
Imports System.Windows.Forms
Imports FontAwesome.Sharp

Public Class frmPrincipal
    Inherits Form

    ' ===========================================================
    ' VARIABLES Y CONTROLES BASE
    ' ===========================================================
    Private panelEncabezado As Panel
    Private panelMenuPrincipal As Panel
    Private panelContenedor As Panel
    Private drawerPanel As DrawerUI

    Private btnHamburguesa As IconButton
    Private btnMin As IconButton
    Private btnMax As IconButton
    Private btnCerrar As IconButton

    Private drawerVisible As Boolean = False
    Private botonesMenu As New List(Of IconButton)

    ' ===========================================================
    ' CONSTRUCTOR
    ' ===========================================================
    Public Sub New()
        Me.Text = "Sistema de Óptica - Principal"
        Me.WindowState = FormWindowState.Maximized
        Me.MinimumSize = New Size(1000, 600)
        Me.BackColor = Color.WhiteSmoke
        Me.DoubleBuffered = True

        ' Crear estructura
        CrearEncabezado()
        CrearPanelMenu()
        CrearPanelContenedor()
        CrearDrawer()

        ' Mostrar en orden
        Controls.Add(panelContenedor)
        Controls.Add(panelMenuPrincipal)
        Controls.Add(panelEncabezado)
        Controls.Add(drawerPanel)

        drawerPanel.BringToFront()
    End Sub

    ' ===========================================================
    ' PANEL DE ENCABEZADO
    ' ===========================================================
    Private Sub CrearEncabezado()
        panelEncabezado = New Panel With {
            .Dock = DockStyle.Top,
            .Height = 45,
            .BackColor = Color.FromArgb(45, 45, 48)
        }

        ' --- Botón Hamburguesa ---
        btnHamburguesa = New IconButton With {
            .IconChar = IconChar.Bars,
            .IconColor = Color.White,
            .IconSize = 22,
            .Size = New Size(45, 45),
            .FlatStyle = FlatStyle.Flat,
            .Cursor = Cursors.Hand
        }
        btnHamburguesa.FlatAppearance.BorderSize = 0
        AddHandler btnHamburguesa.Click, AddressOf ToggleDrawer
        panelEncabezado.Controls.Add(btnHamburguesa)

        ' --- Título ---
        Dim lblTitulo As New Label With {
            .Text = "Sistema de Óptica",
            .ForeColor = Color.White,
            .Font = New Font("Segoe UI", 12, FontStyle.Bold),
            .AutoSize = True,
            .Location = New Point(55, 10)
        }
        panelEncabezado.Controls.Add(lblTitulo)

        ' --- Botones de ventana ---
        btnCerrar = CrearBotonVentana(IconChar.Xmark, Color.White)
        btnMax = CrearBotonVentana(IconChar.Square, Color.White)
        btnMin = CrearBotonVentana(IconChar.Minus, Color.White)

        btnCerrar.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnMax.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnMin.Anchor = AnchorStyles.Top Or AnchorStyles.Right

        btnCerrar.Location = New Point(Me.Width - 45, 0)
        btnMax.Location = New Point(Me.Width - 90, 0)
        btnMin.Location = New Point(Me.Width - 135, 0)

        AddHandler btnCerrar.Click, Sub() Me.Close()
        AddHandler btnMax.Click, Sub()
                                     If Me.WindowState = FormWindowState.Maximized Then
                                         Me.WindowState = FormWindowState.Normal
                                     Else
                                         Me.WindowState = FormWindowState.Maximized
                                     End If
                                 End Sub
        AddHandler btnMin.Click, Sub() Me.WindowState = FormWindowState.Minimized

        panelEncabezado.Controls.AddRange({btnCerrar, btnMax, btnMin})

        ' Hover efecto tipo Windows 11
        AddHandler btnCerrar.MouseEnter, Sub() btnCerrar.BackColor = Color.FromArgb(232, 17, 35)
        AddHandler btnCerrar.MouseLeave, Sub() btnCerrar.BackColor = Color.Transparent

        AddHandler btnMax.MouseEnter, Sub() btnMax.BackColor = Color.FromArgb(63, 63, 70)
        AddHandler btnMax.MouseLeave, Sub() btnMax.BackColor = Color.Transparent

        AddHandler btnMin.MouseEnter, Sub() btnMin.BackColor = Color.FromArgb(63, 63, 70)
        AddHandler btnMin.MouseLeave, Sub() btnMin.BackColor = Color.Transparent
    End Sub

    Private Function CrearBotonVentana(icon As IconChar, iconColor As Color) As IconButton
        Dim b = New IconButton With {
            .IconChar = icon,
            .IconColor = iconColor,
            .IconSize = 18,
            .Dock = DockStyle.None,
            .FlatStyle = FlatStyle.Flat,
            .Width = 45,
            .Height = 45,
            .Cursor = Cursors.Hand,
            .BackColor = Color.Transparent
        }
        b.FlatAppearance.BorderSize = 0
        Return b
    End Function

    ' ===========================================================
    ' PANEL MENU PRINCIPAL
    ' ===========================================================
    Private Sub CrearPanelMenu()
        panelMenuPrincipal = New Panel With {
            .Dock = DockStyle.Left,
            .Width = 60,
            .BackColor = Color.FromArgb(37, 37, 38)
        }

        Dim menuItems = {
            ("Empleados", IconChar.Users),
            ("Compras", IconChar.ShoppingCart),
            ("Ventas", IconChar.CashRegister),
            ("Reportes", IconChar.ChartLine),
            ("Inventario", IconChar.BoxesStacked),
            ("Clientes", IconChar.UserTie),
            ("Configuración", IconChar.Gear)
        }

        For i = 0 To menuItems.Length - 1
            Dim btn = New IconButton With {
                .Text = menuItems(i).Item1,
                .IconChar = menuItems(i).Item2,
                .IconColor = Color.White,
                .IconSize = 22,
                .ForeColor = Color.White,
                .FlatStyle = FlatStyle.Flat,
                .Dock = DockStyle.Top,
                .Height = 55,
                .TextAlign = ContentAlignment.BottomCenter,
                .TextImageRelation = TextImageRelation.ImageAboveText,
                .Tag = menuItems(i).Item1,
                .Cursor = Cursors.Hand
            }
            btn.FlatAppearance.BorderSize = 0
            panelMenuPrincipal.Controls.Add(btn)
            botonesMenu.Add(btn)

            AddHandler btn.Click, AddressOf BotonMenuPrincipal_Click
        Next
    End Sub

    ' ===========================================================
    ' PANEL CONTENEDOR
    ' ===========================================================
    Private Sub CrearPanelContenedor()
        panelContenedor = New Panel With {
            .Dock = DockStyle.Fill,
            .BackColor = Color.White
        }
    End Sub

    ' ===========================================================
    ' DRAWER FLOTANTE
    ' ===========================================================
    Private Sub CrearDrawer()
        drawerPanel = New DrawerUI With {
            .Visible = False,
            .Size = New Size(220, 400),
            .BackColor = Color.White
        }
        drawerPanel.Location = New Point(panelMenuPrincipal.Right, panelEncabezado.Bottom)
        AddHandler drawerPanel.OpcionSeleccionada, AddressOf Drawer_OpcionSeleccionada
    End Sub

    ' ===========================================================
    ' EVENTOS
    ' ===========================================================
    Private Sub ToggleDrawer(sender As Object, e As EventArgs)
        drawerVisible = Not drawerVisible
        drawerPanel.Visible = drawerVisible
        drawerPanel.BringToFront()
        drawerPanel.Location = New Point(panelMenuPrincipal.Right, panelEncabezado.Bottom)
    End Sub

    Private Sub BotonMenuPrincipal_Click(sender As Object, e As EventArgs)
        Dim btn = DirectCast(sender, IconButton)

        ' Resetear colores
        For Each b In botonesMenu
            b.BackColor = Color.FromArgb(37, 37, 38)
            b.IconColor = Color.White
            b.ForeColor = Color.White
        Next

        ' Resaltar seleccionado
        btn.BackColor = Color.White
        btn.IconColor = Color.Black
        btn.ForeColor = Color.Black

        ' Cargar opciones en el drawer
        Dim opciones As List(Of String) = Nothing
        Select Case btn.Text
            Case "Empleados"
                opciones = New List(Of String) From {"Registrar Empleado", "Consultar Empleados"}
            Case "Compras"
                opciones = New List(Of String) From {"Nueva Compra", "Proveedores"}
            Case "Ventas"
                opciones = New List(Of String) From {"Nueva Venta", "Historial"}
            Case "Reportes"
                opciones = New List(Of String) From {"Reporte de Ventas", "Inventario"}
        End Select

        If opciones IsNot Nothing Then
            drawerPanel.CargarOpciones(opciones)
            drawerPanel.Visible = True
            drawerPanel.Location = New Point(panelMenuPrincipal.Right, panelEncabezado.Bottom)
            drawerPanel.BringToFront()
        End If
    End Sub

    Private Sub Drawer_OpcionSeleccionada(opcion As String)
        drawerPanel.Visible = False
        MessageBox.Show("Seleccionaste: " & opcion)
    End Sub
End Class
