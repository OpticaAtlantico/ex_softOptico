' =======================================================
' DrawerControlAdvanced.vb
' Drawer lateral profesional con animación de colapso/expansión
' Compatible con Dark/Light Mode, iconos FontAwesome
' Bordes redondeados y resaltado del botón activo
' =======================================================

Imports System.Drawing
Imports System.Windows.Forms
Imports FontAwesome.Sharp
Imports System.ComponentModel

Public Class DrawerControlUI
    Inherits UserControl

    ' Evento público para notificar selección
    Public Event OpcionSeleccionada(opcion As String)

    ' Variables internas
    Private botones As New List(Of Button)
    Private botonActivo As Button = Nothing
    Private DarkMode As Boolean = False
    Private ExpandedWidth As Integer = 200
    Private CollapsedWidth As Integer = 60
    Private isExpanded As Boolean = True
    Private animTimer As Timer

    ' Constructor
    Public Sub New()
        Me.Width = ExpandedWidth
        Me.BackColor = Color.White
        InicializarBotones()
        InicializarTimer()
    End Sub

    ' ----------------------------
    ' Inicializar botones
    ' ----------------------------
    Private Sub InicializarBotones()
        AgregarBoton("Empleados", IconChar.User)
        AgregarBoton("Compras", IconChar.ShoppingCart)
        AgregarBoton("Ventas", IconChar.MoneyBillWave)
        AgregarBoton("Reportes", IconChar.ChartBar)
        AgregarBoton("Configuración", IconChar.Cogs)

        ' Posición vertical
        Dim yPos As Integer = 20
        For Each btn In botones
            btn.Top = yPos
            btn.Left = 0
            btn.Width = Me.Width
            btn.Height = 50
            yPos += btn.Height + 5
            Me.Controls.Add(btn)
        Next

        ' Eventos para hover de expansión
        AddHandler Me.MouseEnter, AddressOf Drawer_MouseEnter
        AddHandler Me.MouseLeave, AddressOf Drawer_MouseLeave
    End Sub

    ' ----------------------------
    ' Agregar botón
    ' ----------------------------
    Private Sub AgregarBoton(texto As String, icono As IconChar)
        Dim btn As New Button With {
            .Text = "  " & texto,
            .TextAlign = ContentAlignment.MiddleLeft,
            .Font = New Font("Segoe UI", 10, FontStyle.Regular),
            .FlatStyle = FlatStyle.Flat,
            .BackColor = Me.BackColor,
            .ForeColor = If(DarkMode, Color.White, Color.Black),
            .Cursor = Cursors.Hand,
            .Dock = DockStyle.Top,
            .Height = 50,
            .Tag = texto
        }
        btn.FlatAppearance.BorderSize = 0
        btn.Padding = New Padding(5, 0, 0, 0)

        Dim ico As New IconPictureBox With {
            .IconChar = icono,
            .IconColor = If(DarkMode, Color.White, Color.Black),
            .Size = New Size(25, 25),
            .Location = New Point(10, (btn.Height - 25) \ 2),
            .BackColor = Color.Transparent
        }
        btn.Controls.Add(ico)

        AddHandler btn.Click, AddressOf Boton_Click
        botones.Add(btn)
    End Sub

    ' ----------------------------
    ' Evento botón
    ' ----------------------------
    Private Sub Boton_Click(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        MarcarBotonActivo(btn.Tag.ToString(), botonActivo)
        RaiseEvent OpcionSeleccionada(btn.Tag.ToString())
    End Sub

    ' ----------------------------
    ' Marcar botón activo
    ' ----------------------------
    Public Sub MarcarBotonActivo(opcion As String, ByRef botonAnterior As Button)
        If botonAnterior IsNot Nothing Then
            botonAnterior.BackColor = Me.BackColor
            botonAnterior.ForeColor = If(DarkMode, Color.White, Color.Black)
        End If

        botonActivo = botones.Find(Function(b) b.Tag.ToString() = opcion)
        If botonActivo IsNot Nothing Then
            botonActivo.BackColor = If(DarkMode, Color.FromArgb(0, 120, 215), Color.LightBlue)
            botonActivo.ForeColor = Color.White
            botonAnterior = botonActivo
        End If
    End Sub

    ' ----------------------------
    ' Dark Mode
    ' ----------------------------
    Public Sub ActualizarModo(isDark As Boolean)
        DarkMode = isDark
        Me.BackColor = If(DarkMode, Color.FromArgb(45, 45, 48), Color.White)
        For Each btn In botones
            btn.BackColor = Me.BackColor
            btn.ForeColor = If(DarkMode, Color.White, Color.Black)
            If btn.Controls.OfType(Of IconPictureBox).Any() Then
                Dim ico = btn.Controls.OfType(Of IconPictureBox).First()
                ico.IconColor = If(DarkMode, Color.White, Color.Black)
            End If
        Next
        If botonActivo IsNot Nothing Then
            botonActivo.BackColor = If(DarkMode, Color.FromArgb(0, 120, 215), Color.LightBlue)
            botonActivo.ForeColor = Color.White
        End If
    End Sub

    ' ----------------------------
    ' Timer de animación
    ' ----------------------------
    Private Sub InicializarTimer()
        animTimer = New Timer With {.Interval = 15}
        AddHandler animTimer.Tick, AddressOf AnimTimer_Tick
    End Sub

    Private Sub AnimTimer_Tick(sender As Object, e As EventArgs)
        If isExpanded Then
            ' Expandir
            If Me.Width < ExpandedWidth Then
                Me.Width += 15
                ActualizarBotonesTexto(True)
            Else
                animTimer.Stop()
            End If
        Else
            ' Colapsar
            If Me.Width > CollapsedWidth Then
                Me.Width -= 15
                ActualizarBotonesTexto(False)
            Else
                animTimer.Stop()
            End If
        End If
    End Sub

    ' ----------------------------
    ' Mostrar/Ocultar texto de botones según ancho
    ' ----------------------------
    Private Sub ActualizarBotonesTexto(expanded As Boolean)
        For Each btn In botones
            If expanded Then
                btn.Text = "  " & btn.Tag.ToString()
            Else
                btn.Text = ""
            End If
        Next
    End Sub

    ' ----------------------------
    ' Hover expand/collapse
    ' ----------------------------
    Private Sub Drawer_MouseEnter(sender As Object, e As EventArgs)
        isExpanded = True
        animTimer.Start()
    End Sub

    Private Sub Drawer_MouseLeave(sender As Object, e As EventArgs)
        isExpanded = False
        animTimer.Start()
    End Sub

End Class

' =======================================================
' ==================== INSTRUCCIONES ====================
' 1) Agrega DrawerControlAdvanced.vb a tu proyecto.
' 2) Instala FontAwesome.Sharp via NuGet.
' 3) En tu formulario principal:
'       Dim drawer As New DrawerControlAdvanced()
'       Me.Controls.Add(drawer)
' 4) Suscribe el evento:
'       AddHandler drawer.OpcionSeleccionada, AddressOf Drawer_OpcionSeleccionada
' 5) Función de manejo:
'       Private Sub Drawer_OpcionSeleccionada(opcion As String)
'           Select Case opcion
'               Case "Empleados"
'                   ' Abrir frmEmpleados
'               Case "Compras"
'                   ' Abrir frmCompras
'               ' etc.
'           End Select
'       End Sub
' 6) Para Dark Mode:
'       drawer.ActualizarModo(True) ' True=Dark, False=Light
' =======================================================
