Imports System.Drawing
Imports System.Windows.Forms
Imports DocumentFormat.OpenXml.Office2016.Drawing.Charts
Imports FontAwesome.Sharp

' DrawerControlUI: lateral profesional con:
' - Acordeón (solo un submenú abierto)
' - Animación suave de submenús
' - Modo compacto <-> expandido (íconos centrados cuando está compacto)
' - Evento OpcionSeleccionada(opcion As String)
Public Class DrawerControlUI
    Inherits UserControl

    ' Evento público
    Public Event OpcionSeleccionada(opcion As String)

    ' Layout
    Private flpMenu As New FlowLayoutPanel()

    ' Animación submenú
    Private WithEvents submenuTimer As New Timer With {.Interval = 15}
    Private targetSubmenu As Panel = Nothing
    Private expandingSubmenu As Boolean
    Private stepSub As Integer = 12
    Private nextSubmenuToOpen As Panel = Nothing

    ' Toggle drawer (compact/expand)
    Private WithEvents drawerTimer As New Timer With {.Interval = 15}
    Private isExpanded As Boolean = True
    Private expandedWidth As Integer = 220
    Private collapsedWidth As Integer = 60
    Private drawerTargetWidth As Integer

    Public Sub New()
        Me.Dock = DockStyle.Left
        Me.Width = expandedWidth
        Me.BackColor = Color.FromArgb(28, 28, 30)

        ' FlowLayoutPanel que contiene elementos (orden top->down según Add)
        flpMenu.Dock = DockStyle.Fill
        flpMenu.FlowDirection = FlowDirection.TopDown
        flpMenu.WrapContents = False
        flpMenu.AutoScroll = True
        flpMenu.Padding = New Padding(0)
        Me.Controls.Add(flpMenu)

        ' Redimensionar ítems cuando cambie el ancho disponible
        AddHandler flpMenu.SizeChanged, AddressOf OnMenuSizeChanged
        AddHandler Me.Load, Sub() UpdateAllItemWidths()

        ' EJEMPLO: (puedes quitar/editar estas líneas en tu proyecto)
        AgregarOpcion("Empleados", IconChar.Users, New List(Of String) From {"Gestión de Empleados", "Horarios"})
        AgregarOpcion("Compras", IconChar.ShoppingCart, New List(Of String) From {"Nueva Compra", "Proveedores"})
        AgregarOpcion("Ventas", IconChar.CashRegister, New List(Of String) From {"Nueva Venta", "Historial", "Devoluciones"})
        AgregarOpcion("Reportes", IconChar.ChartLine, New List(Of String) From {"Ventas", "Inventario", "Caja"})
    End Sub

    ' ---------------------
    ' Public API
    ' ---------------------
    Public Sub ToggleDrawer()
        If isExpanded Then
            drawerTargetWidth = collapsedWidth
        Else
            drawerTargetWidth = expandedWidth
        End If
        drawerTimer.Start()
    End Sub

    ' Agrega una opción principal (texto+ícono) y su lista de subopciones
    Public Sub AgregarOpcion(texto As String, icono As IconChar, Optional subOpciones As List(Of String) = Nothing)
        ' Panel item: contendrá icono-izq, label-centro, chevron-dcha
        Dim pnlItem As New Panel With {
            .Height = 44,
            .Width = Math.Max(100, flpMenu.ClientSize.Width),
            .BackColor = Color.FromArgb(28, 28, 30),
            .Margin = New Padding(0)
        }

        ' Icono principal (izq)
        Dim iconMain As New IconPictureBox With {
            .IconChar = icono,
            .IconColor = Color.White,
            .Size = New Size(28, 28),
            .Location = New Point(10, (pnlItem.Height - 28) \ 2),
            .SizeMode = PictureBoxSizeMode.CenterImage
        }
        pnlItem.Controls.Add(iconMain)

        ' Label de texto
        Dim lbl As New Label With {
            .Text = "  " & texto,
            .ForeColor = Color.White,
            .AutoSize = False,
            .Height = pnlItem.Height,
            .Width = pnlItem.Width - 80,
            .Location = New Point(48, 0),
            .TextAlign = ContentAlignment.MiddleLeft
        }
        pnlItem.Controls.Add(lbl)

        ' Chevron (derecha)
        Dim chevron As New IconPictureBox With {
            .IconChar = IconChar.ChevronRight,
            .IconColor = Color.White,
            .Size = New Size(20, 20),
            .Location = New Point(pnlItem.Width - 30, (pnlItem.Height - 20) \ 2),
            .Anchor = AnchorStyles.Top Or AnchorStyles.Right
        }
        pnlItem.Controls.Add(chevron)

        ' Submenu panel (se añade inmediatamente debajo en el FlowLayoutPanel)
        Dim pnlSub As New Panel With {
            .Height = 0,
            .Width = Math.Max(100, flpMenu.ClientSize.Width),
            .BackColor = Color.FromArgb(60, 60, 64),
            .Visible = False,
            .Margin = New Padding(0)
        }

        ' Si hay subopciones, crearlas dentro del pnlSub (Dock.Top stack)
        If subOpciones IsNot Nothing AndAlso subOpciones.Count > 0 Then
            For Each s As String In subOpciones
                Dim b As New Button With {
                    .Text = "   • " & s,
                    .ForeColor = Color.Gainsboro,
                    .BackColor = pnlSub.BackColor,
                    .FlatStyle = FlatStyle.Flat,
                    .Height = 34,
                    .Dock = DockStyle.Top,
                    .TextAlign = ContentAlignment.MiddleLeft,
                    .Padding = New Padding(12, 0, 0, 0),
                    .Tag = s
                }
                b.FlatAppearance.BorderSize = 0
                AddHandler b.Click, Sub(sender, e)
                                        MarcarBotonActivo(s)
                                        RaiseEvent OpcionSeleccionada(s)
                                    End Sub
                pnlSub.Controls.Add(b)
                pnlSub.Controls.SetChildIndex(b, 0) ' para que se agreguen en orden correcto
            Next
        Else
            ' Si no hay subopciones, escondemos chevron (no será acordeón)
            chevron.Visible = False
        End If

        ' Asignar referencias cruzadas para fácil manipulación
        pnlSub.Tag = pnlItem ' link from sub -> parent item
        pnlItem.Tag = pnlSub ' link from item -> sub panel
        lbl.Tag = texto
        pnlItem.Name = "item_" & texto.Replace(" ", "_")

        ' Manejar clicks: clic en panel o en cualquiera de sus hijos actúa como clic principal
        Dim clickHandler As EventHandler = Sub(s, e)
                                               ToggleSubmenu(DirectCast(pnlSub, Panel), pnlItem)
                                           End Sub
        AddHandler pnlItem.Click, clickHandler
        AddHandler iconMain.Click, clickHandler
        AddHandler lbl.Click, clickHandler
        AddHandler chevron.Click, clickHandler

        ' Añadir en el FlowLayoutPanel: primero item, luego su subpanel (para que sub aparezca debajo)
        flpMenu.Controls.Add(pnlItem)
        flpMenu.Controls.Add(pnlSub)

        ' actualizar anchos y posiciones
        UpdateItemSizes(pnlItem, pnlSub)
    End Sub

    ' Marcar subopción activa (resaltar)
    Public Sub MarcarBotonActivo(opcion As String)
        For Each ctrl As Control In flpMenu.Controls
            If TypeOf ctrl Is Panel Then
                Dim pnl As Panel = DirectCast(ctrl, Panel)
                For Each c As Control In pnl.Controls
                    If TypeOf c Is Button Then
                        Dim b = DirectCast(c, Button)
                        b.BackColor = If(b.Tag IsNot Nothing AndAlso b.Tag.ToString() = opcion, Color.FromArgb(80, 80, 100), Color.FromArgb(60, 60, 64))
                    End If
                Next
            End If
        Next
    End Sub

    ' ---------------------
    ' Toggle submenus (acordeón)
    ' ---------------------
    Private Sub ToggleSubmenu(subPanel As Panel, parentItem As Panel)
        If subPanel Is Nothing Then
            ' si no tiene submenu, disparar evento con el texto del item
            Dim t = TryCast(parentItem.Controls.OfType(Of Label)().FirstOrDefault()?.Tag, String)
            If t IsNot Nothing Then RaiseEvent OpcionSeleccionada(t)
            Return
        End If

        ' Si otro submenú está abierto y es distinto, cerrarlo primero y luego abrir el nuevo al terminar
        If targetSubmenu IsNot Nothing AndAlso targetSubmenu IsNot subPanel Then
            ' guardar el siguiente a abrir
            nextSubmenuToOpen = subPanel
            ' iniciar cierre del abierto
            expandingSubmenu = False
            targetSubmenu = DirectCast(targetSubmenu, Panel)
            submenuTimer.Start()
            Return
        End If

        ' Si aquí no había otro abierto o era el mismo:
        If subPanel.Visible = False OrElse subPanel.Height = 0 Then
            ' abrir
            subPanel.Visible = True
            expandingSubmenu = True
            targetSubmenu = subPanel
            submenuTimer.Start()
            ' resaltar el parentItem visualmente
            parentItem.BackColor = Color.FromArgb(40, 40, 60)
            ' chevron -> down
            Dim ch = parentItem.Controls.OfType(Of IconPictureBox)().FirstOrDefault(Function(x) x.IconChar = IconChar.ChevronRight Or x.IconChar = IconChar.ChevronDown)
            If ch IsNot Nothing Then ch.IconChar = IconChar.ChevronDown
        Else
            ' cerrar
            expandingSubmenu = False
            targetSubmenu = subPanel
            submenuTimer.Start()
            parentItem.BackColor = Color.FromArgb(28, 28, 30)
            Dim ch = parentItem.Controls.OfType(Of IconPictureBox)().FirstOrDefault(Function(x) x.IconChar = IconChar.ChevronRight Or x.IconChar = IconChar.ChevronDown)
            If ch IsNot Nothing Then ch.IconChar = IconChar.ChevronRight
        End If
    End Sub

    ' Timer de animación de submenus
    Private Sub submenuTimer_Tick(sender As Object, e As EventArgs) Handles submenuTimer.Tick
        If targetSubmenu Is Nothing Then
            submenuTimer.Stop()
            Return
        End If

        Dim fullHeight = targetSubmenu.Controls.Count * 34 ' altura objetivo por botón de sub
        If expandingSubmenu Then
            targetSubmenu.Height += stepSub
            If targetSubmenu.Height >= fullHeight Then
                targetSubmenu.Height = fullHeight
                submenuTimer.Stop()
                ' Si se abrió y había otra pendiente (no debería) nada que hacer
            End If
        Else
            targetSubmenu.Height -= stepSub
            If targetSubmenu.Height <= 0 Then
                targetSubmenu.Height = 0
                targetSubmenu.Visible = False
                submenuTimer.Stop()
                ' Si hay otro submenu pendiente por abrir (acordeón secuencial), abrirlo ahora
                If nextSubmenuToOpen IsNot Nothing Then
                    Dim toOpen = nextSubmenuToOpen
                    nextSubmenuToOpen = Nothing
                    ' abrir siguiente
                    toOpen.Visible = True
                    expandingSubmenu = True
                    targetSubmenu = toOpen
                    submenuTimer.Start()
                Else
                    targetSubmenu = Nothing
                End If
            End If
        End If
    End Sub

    ' ---------------------
    ' Timer de animación del Drawer (ancho)
    ' ---------------------
    Private Sub drawerTimer_Tick(sender As Object, e As EventArgs) Handles drawerTimer.Tick
        If Me.Width < drawerTargetWidth Then
            Me.Width += 20
            If Me.Width >= drawerTargetWidth Then
                Me.Width = drawerTargetWidth
                drawerTimer.Stop()
                isExpanded = True
                UpdateAllItemWidths()
                UpdateCompactVisuals(False)
            End If
        ElseIf Me.Width > drawerTargetWidth Then
            Me.Width -= 20
            If Me.Width <= drawerTargetWidth Then
                Me.Width = drawerTargetWidth
                drawerTimer.Stop()
                isExpanded = False
                UpdateAllItemWidths()
                UpdateCompactVisuals(True)
            End If
        End If
    End Sub

    ' ---------------------
    ' Actualizar tamaños/posiciones de items
    ' ---------------------
    Private Sub UpdateItemSizes(item As Panel, subPanel As Panel)
        Dim targetWidth = Math.Max(80, flpMenu.ClientSize.Width - flpMenu.Margin.Horizontal)
        item.Width = targetWidth
        subPanel.Width = targetWidth
        ' ajustar positions internas (icon, label, chevron)
        For Each c As Control In item.Controls
            If TypeOf c Is IconPictureBox Then
                Dim ip = DirectCast(c, IconPictureBox)
                If ip.IconChar = IconChar.ChevronRight Or ip.IconChar = IconChar.ChevronDown Then
                    ip.Location = New Point(item.Width - 30, (item.Height - ip.Height) \ 2)
                Else
                    ip.Location = New Point(10, (item.Height - ip.Height) \ 2)
                End If
            ElseIf TypeOf c Is Label Then
                Dim lbl = DirectCast(c, Label)
                lbl.Width = Math.Max(40, item.Width - 80)
            End If
        Next
    End Sub

    Private Sub UpdateAllItemWidths()
        For i = 0 To flpMenu.Controls.Count - 1
            Dim ctrl = flpMenu.Controls(i)
            If TypeOf ctrl Is Panel Then
                Dim pnl = DirectCast(ctrl, Panel)
                ' Si el panel es subpanel (background distinto), su Tag apunta al parent; para item parent Tag apunta al subpanel.
                If pnl.Tag IsNot Nothing AndAlso TypeOf pnl.Tag Is Panel Then
                    ' it's a subpanel
                    pnl.Width = Math.Max(80, flpMenu.ClientSize.Width)
                Else
                    ' item panel
                    pnl.Width = Math.Max(80, flpMenu.ClientSize.Width)
                    UpdateItemSizes(pnl, DirectCast(pnl.Tag, Panel))
                End If
            End If
        Next
    End Sub

    Private Sub OnMenuSizeChanged(s As Object, e As EventArgs)
        UpdateAllItemWidths()
    End Sub

    ' Ajusta visuales (centrar icono y esconder texto) según modo compacto
    ' ========================================
    ' Actualiza el estilo visual del Drawer en
    ' modo compacto (solo íconos) o expandido.
    ' ========================================
    Private Sub UpdateCompactVisuals(compact As Boolean)
        For Each ctrl As Control In flpMenu.Controls
            If TypeOf ctrl Is Panel Then
                Dim pnlItem = DirectCast(ctrl, Panel)
                Dim subPanel As Panel = TryCast(pnlItem.Tag, Panel)

                ' Buscar controles dentro del item
                Dim iconMain As IconPictureBox =
                    pnlItem.Controls.OfType(Of IconPictureBox)().
                        FirstOrDefault(Function(x) x IsNot Nothing AndAlso
                                                  x.IconChar <> IconChar.ChevronRight AndAlso
                                                  x.IconChar <> IconChar.ChevronDown)

                Dim chevron As IconPictureBox =
                    pnlItem.Controls.OfType(Of IconPictureBox)().
                        FirstOrDefault(Function(x) x IsNot Nothing AndAlso
                                                  (x.IconChar = IconChar.ChevronRight OrElse x.IconChar = IconChar.ChevronDown))

                Dim lbl As Label = pnlItem.Controls.OfType(Of Label)().FirstOrDefault()

                If compact Then
                    ' --- MODO COMPACTO ---
                    If lbl IsNot Nothing Then lbl.Visible = False
                    If chevron IsNot Nothing Then chevron.Visible = False

                    ' Centrar ícono principal
                    If iconMain IsNot Nothing Then
                        iconMain.Location = New Point(
                            (pnlItem.Width - iconMain.Width) \ 2,
                            (pnlItem.Height - iconMain.Height) \ 2
                        )
                    End If

                    ' Ajustar ancho del subpanel
                    If subPanel IsNot Nothing Then
                        subPanel.Width = Math.Max(40, Me.Width)
                    End If
                Else
                    ' --- MODO EXPANDIDO ---
                    If lbl IsNot Nothing Then
                        lbl.Visible = True
                        lbl.Location = New Point(48, 0)
                    End If

                    If chevron IsNot Nothing Then
                        chevron.Visible = True
                    End If

                    ' Colocar ícono principal a la izquierda
                    If iconMain IsNot Nothing Then
                        iconMain.Location = New Point(10, (pnlItem.Height - iconMain.Height) \ 2)
                    End If

                    If subPanel IsNot Nothing Then
                        subPanel.Width = Math.Max(80, Me.Width)
                    End If
                End If
            End If
        Next
    End Sub

End Class
