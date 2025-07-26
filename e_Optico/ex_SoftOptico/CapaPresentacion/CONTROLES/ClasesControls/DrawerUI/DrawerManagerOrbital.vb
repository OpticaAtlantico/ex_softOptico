Imports System.Windows.Forms
Imports FontAwesome.Sharp

Public Class DrawerManagerOrbital

    Private ReadOnly drawerPanel As Panel
    Private ReadOnly triggerBtn As IconButton
    Private ReadOnly configs As Dictionary(Of DrawerGroup, List(Of DrawerItem))
    Private ReadOnly animator As DrawerAnimatorOrbital

    Public Property PendingGroup As DrawerGroup

    Public Sub New(
        panel As Panel,
        trigger As IconButton,
        groupConfigs As Dictionary(Of DrawerGroup, List(Of DrawerItem)),
        finalWidth As Integer
    )
        drawerPanel = panel
        triggerBtn = trigger
        configs = groupConfigs

        animator = New DrawerAnimatorOrbital(panel, finalWidth, duration:=300, steps:=20)
        AddHandler animator.DrawerOpened, AddressOf OnDrawerOpened
        AddHandler triggerBtn.Click, AddressOf OnTriggerClicked

        ' Panel inicia colapsado
        drawerPanel.Width = 0
    End Sub

    Private Sub OnTriggerClicked(sender As Object, e As EventArgs)
        animator.Toggle()
    End Sub

    Private Sub OnDrawerOpened(sender As Object, e As EventArgs)
        drawerPanel.Controls.Clear()

        Dim container As New FlowLayoutPanel() With {
            .Dock = DockStyle.None,
            .Width = 600,
            .AutoScroll = True,
            .FlowDirection = FlowDirection.TopDown,
            .WrapContents = False,
            .Padding = New Padding(8)
        }

        Dim lst = If(configs.ContainsKey(PendingGroup),
                     configs(PendingGroup),
                     New List(Of DrawerItem)())

        For Each itm In lst
            container.Controls.Add(MakeItem(itm))
        Next

        drawerPanel.Controls.Add(container)
    End Sub

    Private Function MakeItem(itm As DrawerItem) As IconButton
        Dim btn = New IconButton() With {
            .Text = "   " & itm.Text,
            .IconChar = itm.Icon,
            .IconColor = Color.White,
            .IconSize = 24,
            .TextAlign = ContentAlignment.MiddleLeft,
            .ImageAlign = ContentAlignment.MiddleLeft,
            .Height = 40,
            .Dock = DockStyle.Top,
            .FlatStyle = FlatStyle.Flat,
            .BackColor = Color.Transparent
        }
        btn.FlatAppearance.BorderSize = 0

        AddHandler btn.Click, Sub()
                                  itm.CallBack.Invoke()
                                  animator.Hide()
                              End Sub

        Return btn
    End Function

    Public Sub Show()
        animator.Show()
    End Sub

    Public Sub Hide()
        animator.Hide()
    End Sub

    Public Sub Toggle()
        animator.Toggle()
    End Sub
End Class














'Imports System.Windows.Forms
'Imports System.Drawing
'Imports FontAwesome.Sharp

'Public Class DrawerManagerOrbital

'    Private ReadOnly drawerPanel As Panel
'    Private ReadOnly triggerBtn As IconButton
'    Private ReadOnly animator As DrawerAnimatorOrbital
'    Private ReadOnly configs As Dictionary(Of DrawerGroup, List(Of DrawerItem))

'    Public Property PendingGroup As DrawerGroup

'    Public Sub New(
'        panel As Panel,
'        trigger As IconButton,
'        groupConfigs As Dictionary(Of DrawerGroup, List(Of DrawerItem)),
'        finalWidth As Integer
'    )
'        drawerPanel = panel
'        triggerBtn = trigger
'        configs = groupConfigs

'        animator = New DrawerAnimatorOrbital(panel, finalWidth, duration:=300, steps:=20)
'        AddHandler animator.DrawerOpened, AddressOf OnDrawerOpened
'        AddHandler triggerBtn.Click, AddressOf OnTriggerClicked

'        drawerPanel.Width = 0
'    End Sub

'    Private Sub OnTriggerClicked(sender As Object, e As EventArgs)
'        animator.Toggle()
'    End Sub

'    Private Sub OnDrawerOpened(sender As Object, e As EventArgs)
'        drawerPanel.Controls.Clear()
'        Dim container = CreateContainerPanel()
'        PopulateGroupItems(PendingGroup, container)
'        drawerPanel.Controls.Add(container)
'    End Sub

'    Private Function CreateContainerPanel() As FlowLayoutPanel
'        Return New FlowLayoutPanel With {
'            .Dock = DockStyle.Fill,
'            .AutoScroll = True,
'            .FlowDirection = FlowDirection.TopDown,
'            .WrapContents = False,
'            .Padding = New Padding(8),
'            .Margin = New Padding(0)
'        }
'    End Function

'    Private Sub PopulateGroupItems(group As DrawerGroup, container As FlowLayoutPanel)
'        If configs.ContainsKey(group) Then
'            For Each cfg In configs(group)
'                container.Controls.Add(MakeItem(cfg.Text, cfg.Icon, cfg.Handler))
'            Next
'        Else
'            container.Controls.Add(MakeItem("Sin ítems", IconChar.Ban, Nothing))
'        End If
'    End Sub

'    Private Function MakeItem(text As String, iconChar As IconChar, handler As EventHandler) As IconButton
'        Dim btn = New IconButton With {
'            .Text = text,
'            .IconChar = iconChar,
'            .IconColor = ThemeManager.Current.IconColor,
'            .TextAlign = ContentAlignment.MiddleLeft,
'            .ImageAlign = ContentAlignment.MiddleLeft,
'            .Padding = New Padding(36, 8, 8, 8),
'            .Height = 40,
'            .Width = drawerPanel.ClientSize.Width - 16,
'            .FlatStyle = FlatStyle.Flat,
'            .BackColor = ThemeManager.Current.ItemBackColor
'        }

'        With btn.FlatAppearance
'            .BorderSize = 0
'            .MouseOverBackColor = ThemeManager.Current.MouseOverBackColor
'            .MouseDownBackColor = ThemeManager.Current.MouseDownBackColor
'        End With

'        If handler IsNot Nothing Then
'            AddHandler btn.Click, handler
'        End If

'        Return btn
'    End Function
'End Class





















''Imports System
''Imports System.Diagnostics
''Imports System.Drawing
''Imports System.Windows.Forms
''Imports DocumentFormat.OpenXml.Drawing
''Imports FontAwesome.Sharp
''Imports MyApp.UI.Animators   ' Ajusta este namespace a tu proyecto

''Public Enum DrawerGroup
''    Ventas
''    Compras
''    Inventario
''End Enum

''Public Structure DrawerItemConfig
''    Public Property Text As String
''    Public Property Icon As FontAwesome.Sharp.IconChar
''    Public Property Handler As EventHandler
''End Structure

''Public Class DrawerManagerOrbital

''    Private ReadOnly drawerPanel As Panel
''    Private ReadOnly animator As DrawerAnimatorOrbital
''    Private pendingGroup As String
''    ''' <param name="drawerPanel">
''    ''' Panel (DrawerPanelUI) insertado desde el diseñador.
''    ''' </param>
''    ''' <param name="finalWidth">
''    ''' Ancho en pixeles cuando el drawer está completamente abierto.
''    ''' </param>
''    ''' <param name="animationIntervalMs">
''    ''' Intervalo en milisegundos para el Timer de animación.
''    ''' </param>
''    Public Sub New(
''            drawerPanel As Panel,
''            Optional finalWidth As Integer = 200,
''            Optional animationIntervalMs As Integer = 1)

''        Me.drawerPanel = drawerPanel
''        Me.animator = New DrawerAnimatorOrbital(drawerPanel, finalWidth, animationIntervalMs)

''        AddHandler animator.Opened, AddressOf OnDrawerOpened
''        'If drawerPanel Is Nothing Then
''        '    Throw New ArgumentNullException(NameOf(drawerPanel))
''        'End If

''        'Me.drawerPanel = drawerPanel
''        'Me.animator = New DrawerAnimatorOrbital(drawerPanel, finalWidth, animationIntervalMs)
''    End Sub

''    Private ReadOnly groupConfigs As New Dictionary(Of DrawerGroup, List(Of DrawerItemConfig)) From {
''    {
''        DrawerGroup.Ventas,
''        New List(Of DrawerItemConfig) From {
''            New DrawerItemConfig With {
''                .Text = "Facturación",
''                .Icon = FontAwesome.Sharp.IconChar.FileInvoiceDollar,
''                .Handler = AddressOf OnFacturacion
''            },
''            New DrawerItemConfig With {
''                .Text = "Reportes",
''                .Icon = FontAwesome.Sharp.IconChar.ChartLine,
''                .Handler = AddressOf OnReportes
''            },
''            New DrawerItemConfig With {
''                .Text = "Clientes",
''                .Icon = FontAwesome.Sharp.IconChar.Users,
''                .Handler = AddressOf OnClientes
''            }
''        }
''    },
''    {
''        DrawerGroup.Compras,
''        New List(Of DrawerItemConfig) From {
''            New DrawerItemConfig With {
''                .Text = "Proveedores",
''                .Icon = FontAwesome.Sharp.IconChar.Truck,
''                .Handler = AddressOf OnProveedores
''            },
''            New DrawerItemConfig With {
''                .Text = "Órdenes",
''                .Icon = FontAwesome.Sharp.IconChar.ClipboardList,
''                .Handler = AddressOf OnOrdenes
''            }
''        }
''    }}
''    ' Agrega más grupos según necesites...


''    Private Function CreateContainerPanel() As FlowLayoutPanel
''        Dim pnl As New FlowLayoutPanel With {
''        .Dock = DockStyle.Fill,
''        .AutoScroll = True,
''        .FlowDirection = FlowDirection.TopDown,
''        .WrapContents = False,
''        .Padding = New Padding(8),
''        .Margin = New Padding(0)
''    }
''        Return pnl
''    End Function

''    Private Function MakeItem(
''    text As String,
''    iconChar As FontAwesome.Sharp.IconChar,
''    handler As EventHandler
'') As FontAwesome.Sharp.IconButton

''        Dim btn As New FontAwesome.Sharp.IconButton With {
''        .Text = text,
''        .IconChar = iconChar,
''        .IconColor = ThemeManagerUI.Current.IconColor,
''        .TextAlign = ContentAlignment.MiddleLeft,
''        .ImageAlign = ContentAlignment.MiddleLeft,
''        .Padding = New Padding(36, 8, 8, 8),
''        .Height = 40,
''        .Width = drawerPanel.ClientSize.Width - 16,
''        .FlatStyle = FlatStyle.Flat,
''        .BackColor = ThemeManagerUI.Current.ItemBackColor
''    }

''        With btn.FlatAppearance
''            .BorderSize = 0
''            .MouseOverBackColor = ThemeManagerUI.Current.MouseOverBackColor
''            .MouseDownBackColor = ThemeManagerUI.Current.MouseDownBackColor
''        End With

''        If handler IsNot Nothing Then
''            AddHandler btn.Click, handler
''        End If

''        Return btn
''    End Function

''    Private Sub PopulateGroupItems(
''    group As DrawerGroup,
''    container As FlowLayoutPanel
'')
''        If groupConfigs.ContainsKey(group) Then
''            For Each cfg In groupConfigs(group)
''                container.Controls.Add(MakeItem(cfg.Text, cfg.Icon, cfg.Handler))
''            Next
''        Else
''            container.Controls.Add(MakeItem("Sin ítems", FontAwesome.Sharp.IconChar.Ban, Nothing))
''        End If
''    End Sub

''    Private Sub drawerPanel_SizeChanged(
''    sender As Object,
''    e As EventArgs
'') Handles drawerPanel.SizeChanged

''        For Each ctrl In drawerPanel.Controls
''            If TypeOf ctrl Is FontAwesome.Sharp.IconButton Then
''                Dim btn = DirectCast(ctrl, FontAwesome.Sharp.IconButton)
''                btn.Width = drawerPanel.ClientSize.Width - 16
''            End If
''        Next
''    End Sub

''    Private Sub OnDrawerOpened(sender As Object, e As EventArgs)
''        drawerPanel.Controls.Clear()

''        Dim container = CreateContainerPanel()
''        PopulateGroupItems(pendingGroup, container)

''        drawerPanel.Controls.Add(container)
''    End Sub

''End Class

'''''' <summary>
'''''' Limpia el contenido actual, inserta los botones del grupo
'''''' y abre el drawer con animación.
'''''' </summary>
'''''' 
'''Public Sub ShowGroup(groupName As String)
'''        ' Sólo agendamos qué grupo mostrar y abrimos
'''        pendingGroup = groupName
'''        animator.Open()
'''    End Sub

'''    Private Sub OnDrawerOpened(sender As Object, e As EventArgs)
'''        ' Limpiar contenido previo
'''        drawerPanel.Controls.Clear()

'''        ' Crear contenedor scrollable
'''        Dim container As FlowLayoutPanel = CreateContainerPanel()

'''        ' Poblar según el grupo pendiente
'''        Select Case pendingGroup
'''            Case "Ventas"
'''                container.Controls.Add(MakeItem("Facturación", IconChar.FileInvoiceDollar, AddressOf OnFacturacion))
'''                container.Controls.Add(MakeItem("Reportes", IconChar.ChartLine, AddressOf OnReportes))
'''                container.Controls.Add(MakeItem("Clientes", IconChar.Users, AddressOf OnClientes))

'''            Case "Compras"
'''                container.Controls.Add(MakeItem("Proveedores", IconChar.Truck, AddressOf OnProveedores))
'''                container.Controls.Add(MakeItem("Órdenes", IconChar.ClipboardList, AddressOf OnOrdenes))

'''            Case Else
'''                container.Controls.Add(MakeItem("Sin ítems", IconChar.Ban, Nothing))
'''        End Select

'''        ' Añadir y ajustar layout
'''        drawerPanel.Controls.Add(container)
'''    End Sub


'''    'Private Sub OnDrawerOpened(sender As Object, e As EventArgs)
'''    '    ' Aquí el drawer ya tiene ancho final: podemos poblar con seguridad

'''    '    drawerPanel.Controls.Clear()

'''    '    Dim container = CreateContainerPanel()
'''    '    PopulateGroupItems(pendingGroup, container)

'''    '    drawerPanel.Controls.Add(container)
'''    'End Sub

'''    ''' <summary>
'''    ''' Inicia la animación de cierre del drawer.
'''    ''' </summary>
'''    Public Sub Close()
'''        Debug.WriteLine("[DrawerManagerOrbital] Close")
'''        animator.Close()
'''    End Sub

'''    ''' <summary>
'''    ''' Fabrica un FlowLayoutPanel para listar botones verticalmente.
'''    ''' </summary>
'''    ''' 
'''    Private Function CreateContainerPanel() As FlowLayoutPanel
'''        Dim pnl As New FlowLayoutPanel With {
'''            .Dock = DockStyle.Fill,
'''            .AutoScroll = True,
'''            .FlowDirection = FlowDirection.TopDown,
'''            .WrapContents = False,
'''            .Padding = New Padding(8),
'''            .Margin = New Padding(0)
'''        }
'''        Return pnl
'''    End Function

'''    'Private Function CreateContainerPanel() As FlowLayoutPanel
'''    '    Return New FlowLayoutPanel() With {
'''    '        .Dock = DockStyle.Fill,
'''    '        .FlowDirection = FlowDirection.TopDown,
'''    '        .AutoScroll = True,
'''    '        .Padding = New Padding(4),
'''    '        .BackColor = Color.WhiteSmoke
'''    '    }
'''    'End Function

'''    ''' <summary>
'''    ''' Agrega botones al contenedor según el nombre del grupo.
'''    ''' </summary>
'''    'Private Sub PopulateGroupItems(groupName As String, container As FlowLayoutPanel)
'''    '    Select Case groupName
'''    '        Case "Ventas"
'''    '            container.Controls.Add("Ventas", IconChar.FileInvoiceDollar, AddressOf OnFacturacion)
'''    '            container.Controls.Add(MakeItem("Reportes", AddressOf OnReportes))
'''    '            container.Controls.Add(MakeItem("Clientes", AddressOf OnClientes))

'''    '        Case "Compras"
'''    '            container.Controls.Add(MakeItem("Proveedores", AddressOf OnProveedores))
'''    '            container.Controls.Add(MakeItem("Órdenes", AddressOf OnOrdenes))

'''    '        Case Else
'''    '            container.Controls.Add(MakeItem("Sin ítems", Nothing))
'''    '    End Select
'''    'End Sub

'''    Private Sub PopulateGroupItems()
'''        ' Limpia contenidos previos
'''        drawerPanel.Controls.Clear()

'''        ' Crea un contenedor con TableLayoutPanel
'''        Dim tlp As New TableLayoutPanel() With {
'''        .Dock = DockStyle.Top,
'''        .AutoSize = True,
'''        .AutoSizeMode = AutoSizeMode.GrowAndShrink,
'''        .ColumnCount = 1
'''    }

'''        ' Define estilos de fila automáticos
'''        tlp.RowStyles.Clear()

'''        ' Lista de ítems: Texto, IconChar y handler de evento
'''        Dim items = New List(Of (Text As String, Icon As IconChar, Handler As EventHandler)) From {
'''        ("Facturación", IconChar.FileInvoiceDollar, AddressOf OnFacturacion),
'''        ("Pagos", IconChar.CreditCard, AddressOf OnPagos),
'''        ("Reportes", IconChar.ChartLine, AddressOf OnReportes),
'''        ("Ajustes", IconChar.Cogs, AddressOf OnAjustes)
'''    }

'''        ' Agrega cada ítem al TableLayoutPanel
'''        For i = 0 To items.Count - 1
'''            tlp.RowCount += 1
'''            tlp.RowStyles.Add(New RowStyle(SizeType.AutoSize))
'''            Dim btn = MakeItem(items(i).Text, items(i).Icon, items(i).Handler)
'''            tlp.Controls.Add(btn, column:=0, row:=i)
'''        Next

'''        ' Envuelve en Panel con scroll si es necesario
'''        Dim scrollContainer As New Panel() With {
'''        .Dock = DockStyle.Fill,
'''        .AutoScroll = True
'''    }
'''        scrollContainer.Controls.Add(tlp)

'''        ' Añade al drawer principal
'''        drawerPanel.Controls.Add(scrollContainer)
'''    End Sub

'''    ''' <summary>
'''    ''' Crea un botón con estilo uniforme para el drawer.
'''    ''' </summary>

'''    Private Function MakeItem(
'''        texto As String,
'''        icon As IconChar,
'''        handler As EventHandler) As IconButton

'''        Dim btn = New IconButton() With {
'''        .Text = texto,
'''        .IconChar = icon,
'''        .IconColor = Color.Teal,
'''        .IconFont = IconFont.Auto,
'''        .IconSize = 24,
'''        .TextImageRelation = TextImageRelation.ImageBeforeText,
'''        .ImageAlign = ContentAlignment.MiddleLeft,
'''        .Padding = New Padding(8, 0, 0, 0),
'''        .Width = drawerPanel.Width - 16,
'''        .Height = 40,
'''        .FlatStyle = FlatStyle.Flat,
'''        .BackColor = Color.WhiteSmoke,
'''        .ForeColor = Color.Black,
'''        .Margin = New Padding(4)
'''    }

'''        btn.FlatAppearance.BorderSize = 0
'''        btn.FlatAppearance.MouseDownBackColor = btn.BackColor
'''        btn.FlatAppearance.MouseOverBackColor = btn.BackColor

'''        If handler IsNot Nothing Then
'''            AddHandler btn.Click, handler
'''        End If

'''        Return btn
'''    End Function

'''    Private Sub drawerPanel_SizeChanged(
'''    sender As Object,
'''    e As EventArgs
''') Handles drawerPanel.SizeChanged

'''        For Each btn As IconButton In drawerPanel
'''            btn.Width = drawerPanel.ClientSize.Width - 16
'''        Next
'''    End Sub

'''    'Private Function MakeItem(texto As String, handler As EventHandler) As Button

'''    '    Dim btn As New Button() With {
'''    '        .Text = texto,
'''    '        .Width = drawerPanel.Width,
'''    '        .Height = 36,
'''    '        .FlatStyle = FlatStyle.Flat,
'''    '        .BackColor = Color.WhiteSmoke,
'''    '        .Font = New Font("Century Gothic", 9),
'''    '        .Margin = New Padding(4)
'''    '    }

'''    '    If handler IsNot Nothing Then
'''    '        AddHandler btn.Click, handler
'''    '    End If

'''    '    Return btn
'''    'End Function

'''    ' ------------------------------
'''    ' Ejemplos de manejadores de clic
'''    ' ------------------------------

'''    Private Sub OnFacturacion(s As Object, e As EventArgs)
'''        MessageBox.Show("Abrir módulo de Facturación")
'''    End Sub

'''    Private Sub OnReportes(s As Object, e As EventArgs)
'''        MessageBox.Show("Abrir Reportes de Ventas")
'''    End Sub

'''    Private Sub OnClientes(s As Object, e As EventArgs)
'''        MessageBox.Show("Abrir Gestión de Clientes")
'''    End Sub

'''    Private Sub OnProveedores(s As Object, e As EventArgs)
'''        MessageBox.Show("Abrir Proveedores")
'''    End Sub

'''    Private Sub OnOrdenes(s As Object, e As EventArgs)
'''        MessageBox.Show("Abrir Órdenes de Compra")
'''    End Sub

'''    Private Sub OnPagos(s As Object, e As EventArgs)
'''        MessageBox.Show("Abrir Pagos de Compra")
'''    End Sub

'''    Private Sub OnAjustes(s As Object, e As EventArgs)
'''        MessageBox.Show("Abrir Órdenes de Compra")
'''    End Sub

'''End Class




'''Imports System.Drawing
'''Imports System.Windows.Forms

'''Public Class DrawerManagerOrbital
'''    Private ReadOnly drawer As Panel
'''    Private ReadOnly animator As DrawerControllerOrbital

'''    Public Sub New(drawerPanel As Panel)
'''        drawer = drawerPanel
'''        ' Usa el animador que ya creaste para abrir/cerrar
'''        animator = New DrawerControllerOrbital(drawer)
'''    End Sub

'''    ''' <summary>
'''    ''' Borra el contenido actual y muestra los ítems del grupo indicado.
'''    ''' Luego abre el drawer (con animación).
'''    ''' </summary>
'''    Public Sub ShowGroup(groupName As String)
'''        ' 1) Limpia contenido previo
'''        drawer.Controls.Clear()

'''        ' 2) Crea un FlowLayoutPanel para listar opciones
'''        Dim container As New FlowLayoutPanel() With {
'''            .Dock = DockStyle.Fill,
'''            .FlowDirection = FlowDirection.TopDown,
'''            .AutoScroll = True,
'''            .Padding = New Padding(8)
'''        }

'''        ' 3) Pobla según groupName
'''        Select Case groupName
'''            Case "Ventas"
'''                container.Controls.Add(MakeItem("Facturación", AddressOf OnFacturacion))
'''                container.Controls.Add(MakeItem("Reportes", AddressOf OnReportes))
'''                container.Controls.Add(MakeItem("Clientes", AddressOf OnClientes))
'''            Case "Compras"
'''                container.Controls.Add(MakeItem("Proveedores", AddressOf OnProveedores))
'''                container.Controls.Add(MakeItem("Órdenes", AddressOf OnOrdenes))
'''            Case Else
'''                container.Controls.Add(MakeItem("No hay ítems", Nothing))
'''        End Select

'''        ' 4) Añade el contenedor al drawer y anímalo
'''        drawer.Controls.Add(container)
'''        'animator.Open()
'''    End Sub

'''    ''' <summary>
'''    ''' Cierra el drawer (sin cambiar contenido).
'''    ''' </summary>
'''    Public Sub Close()
'''        'animator.Close()
'''    End Sub

'''    ''' <summary>
'''    ''' Fabrica un botón estándar para el drawer.
'''    ''' </summary>
'''    Private Function MakeItem(texto As String, handler As EventHandler) As Button
'''        Dim btn = New Button() With {
'''            .Text = texto,
'''            .Width = drawer.Width - 16,
'''            .Height = 36,
'''            .FlatStyle = FlatStyle.Flat,
'''            .BackColor = Color.WhiteSmoke,
'''            .Font = New Font("Segoe UI", 9),
'''            .Margin = New Padding(4)
'''        }
'''        If handler IsNot Nothing Then
'''            AddHandler btn.Click, handler
'''        End If
'''        Return btn
'''    End Function

'''    ' Ejemplos de manejadores de clic
'''    Private Sub OnFacturacion(s As Object, e As EventArgs)
'''        MessageBox.Show("Abrir módulo de Facturación")
'''    End Sub
'''    Private Sub OnReportes(s As Object, e As EventArgs)
'''        MessageBox.Show("Abrir Reportes de Ventas")
'''    End Sub
'''    Private Sub OnClientes(s As Object, e As EventArgs)
'''        MessageBox.Show("Abrir Gestión de Clientes")
'''    End Sub
'''    Private Sub OnProveedores(s As Object, e As EventArgs)
'''        MessageBox.Show("Abrir Proveedores")
'''    End Sub
'''    Private Sub OnOrdenes(s As Object, e As EventArgs)
'''        MessageBox.Show("Abrir Órdenes de Compra")
'''    End Sub
'''End Class







''''Imports System.Collections.Generic
''''Imports FontAwesome.Sharp

''''' Orquesta grupos de DrawerItem y delega a DrawerPanelUI
''''Public Class DrawerManagerOrbital
''''    Private ReadOnly ui As DrawerPanelUI

''''    Public Sub New(drawerUI As DrawerPanelUI)
''''        Me.ui = drawerUI
''''    End Sub

''''    Public Sub ShowGroup(groupName As String)
''''        Dim list = GetItemsFor(groupName)
''''        ui.RenderItems(list)
''''        ui.OpenAnimated()
''''    End Sub

''''    Public Sub Hide()
''''        ui.CloseAnimated()
''''    End Sub

''''    Private Function GetItemsFor(name As String) As List(Of DrawerItem)
''''        Dim map As New Dictionary(Of String, List(Of DrawerItem)) From {
''''            {
''''                "Ventas",
''''                New List(Of DrawerItem) From {
''''                    New DrawerItem("Nueva Venta", IconChar.CartPlus, Sub() MessageBox.Show("Iniciar Nueva Venta")),
''''                    New DrawerItem("Historial", IconChar.History, Sub() MessageBox.Show("Mostrar Historial Ventas"))
''''                }
''''            },
''''            {
''''                "Compras",
''''                New List(Of DrawerItem) From {
''''                    New DrawerItem("Nueva Compra", IconChar.ShoppingCart, Sub() MessageBox.Show("Iniciar Nueva Compra")),
''''                    New DrawerItem("Historial", IconChar.ClipboardList, Sub() MessageBox.Show("Mostrar Historial Compras"))
''''                }
''''            },
''''            {
''''                "Inventario",
''''                New List(Of DrawerItem) From {
''''                    New DrawerItem("Nuevo Producto", IconChar.BoxOpen, Sub() MessageBox.Show("Agregar Producto")),
''''                    New DrawerItem("Stock", IconChar.Tags, Sub() MessageBox.Show("Ver Stock"))
''''                }
''''            }
''''        }

''''        Return If(map.ContainsKey(name), map(name), New List(Of DrawerItem)())
''''    End Function
''''End Class
