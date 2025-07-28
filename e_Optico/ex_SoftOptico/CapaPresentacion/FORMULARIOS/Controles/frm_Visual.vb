
Imports FontAwesome.Sharp

Public Class frm_Visual

    Private drawerAbierto As Boolean = False
    Private drawerControl As New DrawerControl()

    Private DrawerExpandido As Boolean = False
    Private DrawerObjetivoWidth As Integer = 250
    Private DrawerVelocidad As Integer = 20

    Private Sub frm_Visual_Load(sender As Object, e As EventArgs) Handles Me.Load
        pnlDrawer.Controls.Add(drawerControl)
        pnlDrawer.Width = 250
        pnlDrawer.Visible = False

        ' Ejemplo: Agregar botones de menú
        AgregarBotonMenu("Archivo", IconChar.File, AddressOf BotonMenuArchivo_Click)
        AgregarBotonMenu("Editar", IconChar.Edit, AddressOf BotonMenuEditar_Click)
    End Sub

    Private Sub AgregarBotonMenu(nombre As String, icono As IconChar, evento As EventHandler)
        Dim btn As New IconButton With {
            .Text = nombre,
            .IconChar = icono,
            .IconColor = Color.WhiteSmoke,
            .Dock = DockStyle.Top,
            .Height = 45,
            .FlatStyle = FlatStyle.Flat,
            .TextImageRelation = TextImageRelation.ImageAboveText,
            .IconSize = 25,
            .ForeColor = Color.WhiteSmoke
        }
        btn.FlatAppearance.BorderSize = 0
        AddHandler btn.Click, evento
        pnlMenu.Controls.Add(btn)

    End Sub

    Private Sub btnHamburguesa_Click(sender As Object, e As EventArgs) Handles btnHamburguesa.Click
        DrawerTimer.Start()
    End Sub

    Private Sub DrawerTimer_Tick(sender As Object, e As EventArgs) Handles DrawerTimer.Tick
        If Not DrawerExpandido Then
            ' Expandiendo
            If pnlDrawer.Width < DrawerObjetivoWidth Then
                pnlDrawer.Visible = True
                pnlDrawer.Width += DrawerVelocidad
            Else
                DrawerTimer.Stop()
                DrawerExpandido = True
            End If
        Else
            ' Contrayendo
            If pnlDrawer.Width > 0 Then
                pnlDrawer.Width -= DrawerVelocidad
            Else
                DrawerTimer.Stop()
                pnlDrawer.Visible = False
                DrawerExpandido = False
            End If
        End If
    End Sub


    Private Sub MostrarContenido(control As UserControl)
        pnlContenedor.Controls.Clear()
        control.Dock = DockStyle.Fill
        pnlContenedor.Controls.Add(control)
    End Sub

    Private Sub BotonMenuArchivo_Click(sender As Object, e As EventArgs)
        ' Crear las opciones de manera clara, evitando CType de lambdas
        Dim opciones As New List(Of Tuple(Of String, IconChar, EventHandler))

        ' Opción: Nuevo
        Dim handlerNuevo As New EventHandler(AddressOf SubNuevo_Click)
        opciones.Add(Tuple.Create("Nuevo", IconChar.Plus, handlerNuevo))

        ' Opción: Abrir
        Dim handlerAbrir As New EventHandler(AddressOf SubAbrir_Click)
        opciones.Add(Tuple.Create("Abrir", IconChar.FolderOpen, handlerAbrir))

        ' Opción: Guardar
        Dim handlerGuardar As New EventHandler(AddressOf SubGuardar_Click)
        opciones.Add(Tuple.Create("Guardar", IconChar.Save, handlerGuardar))

        ' Cargar en Drawer
        drawerControl.CargarOpciones(opciones)
        pnlDrawer.Visible = True
        If pnlDrawer.Width <= 0 Then
            DrawerTimer.Start()
        End If
        drawerAbierto = True
    End Sub

    Private Sub BotonMenuEditar_Click(sender As Object, e As EventArgs)
        Dim opciones As New List(Of Tuple(Of String, IconChar, EventHandler))

        ' Opción: Copiar
        Dim handlerCopiar As New EventHandler(AddressOf SubCopiar_Click)
        opciones.Add(Tuple.Create("Copiar", IconChar.Copy, handlerCopiar))

        ' Opción: Pegar
        Dim handlerPegar As New EventHandler(AddressOf SubPegar_Click)
        opciones.Add(Tuple.Create("Pegar", IconChar.Paste, handlerPegar))

        drawerControl.CargarOpciones(opciones)
        pnlDrawer.Visible = True
        If pnlDrawer.Width <= 0 Then
            DrawerTimer.Start()
        End If
        drawerAbierto = True
    End Sub

    Private Sub SubNuevo_Click(sender As Object, e As EventArgs)
        MostrarContenido(New NuevoControl())
        DrawerTimer.Start()
    End Sub

    Private Sub SubAbrir_Click(sender As Object, e As EventArgs)
        MostrarContenido(New AbrirControl())
        DrawerTimer.Start()
    End Sub

    Private Sub SubGuardar_Click(sender As Object, e As EventArgs)
        MostrarContenido(New GuardarControl())
        DrawerTimer.Start()
    End Sub

    Private Sub SubCopiar_Click(sender As Object, e As EventArgs)
        MostrarContenido(New CopiarControl())
        DrawerTimer.Start()
    End Sub

    Private Sub SubPegar_Click(sender As Object, e As EventArgs)
        MostrarContenido(New PegarControl())
        DrawerTimer.Start()
    End Sub



End Class






'Imports FontAwesome.Sharp
'Public Class frm_Visual
'    Inherits Form

'    Private groupConfigs As Dictionary(Of DrawerGroup, List(Of DrawerItem))
'    Private groupBuilder As DrawerPanelBuilder

'    Public Sub New()
'        InitializeComponent()

'        DrawerGroup.Compras.TriggerButton = btnCompras
'        DrawerGroup.Ventas.TriggerButton = btnVentas

'        InitializeGroupConfigs()
'        groupBuilder = New DrawerPanelBuilder(panelSide, groupConfigs)
'    End Sub

'    Private Sub InitializeGroupConfigs()
'        groupConfigs = New Dictionary(Of DrawerGroup, List(Of DrawerItem)) From {
'              {
'                DrawerGroup.Compras,
'                New List(Of DrawerItem) From {
'                  New DrawerItem() With {
'                    .Text = "Nuevo cliente",
'                    .Icon = IconChar.UserPlus,
'                    .ClickHandler = AddressOf OnAddClient
'                  },
'                  New DrawerItem() With {
'                    .Text = "Buscar cliente",
'                    .Icon = IconChar.Search,
'                    .CallBack = Sub() MessageBox.Show("Buscar cliente")
'                  }
'                }
'              },
'              {
'                DrawerGroup.Ventas,
'                New List(Of DrawerItem) From {
'                  New DrawerItem() With {
'                    .Text = "Facturación",
'                    .Icon = IconChar.FileInvoiceDollar,
'                    .ClickHandler = AddressOf OnFacturacion
'                  },
'                  New DrawerItem() With {
'                    .Text = "Reportes",
'                    .Icon = IconChar.ChartLine,
'                    .CallBack = Sub() MessageBox.Show("Reportes")
'                  }
'                }
'              }
'            }
'    End Sub

'    ' Handlers de ejemplo
'    Private Sub OnAddClient(sender As Object, e As EventArgs)
'        MessageBox.Show("Agregar cliente")
'    End Sub
'    Private Sub OnSearchClient(sender As Object, e As EventArgs)
'        MessageBox.Show("Buscar cliente")
'    End Sub
'    Private Sub OnFacturacion(sender As Object, e As EventArgs)
'        MessageBox.Show("Facturación")
'    End Sub
'    Private Sub OnReportes(sender As Object, e As EventArgs)
'        MessageBox.Show("Reportes")
'    End Sub

'End Class


























'Imports System.Windows.Forms
'Imports FontAwesome.Sharp

'Public Class frm_Visual
'    Inherits Form

'    Private manager As DrawerManagerOrbital
'    Private animator As DrawerAnimatorOrbital

'    Private ReadOnly groupConfigs As New Dictionary(Of DrawerGroup, List(Of DrawerItem)) From {
'        {
'            DrawerGroup.Ventas,
'            New List(Of DrawerItem) From {
'                New DrawerItem With {.Text = "Facturación", .Icon = IconChar.FileInvoiceDollar, .Handler = AddressOf OnFacturacion},
'                New DrawerItem With {.Text = "Reportes", .Icon = IconChar.ChartLine, .Handler = AddressOf OnReportes},
'                New DrawerItem With {.Text = "Clientes", .Icon = IconChar.Users, .Handler = AddressOf OnClientes}
'            }
'        },
'        {
'            DrawerGroup.Compras,
'            New List(Of DrawerItem) From {
'                New DrawerItem With {.Text = "Proveedores", .Icon = IconChar.Truck, .Handler = AddressOf OnProveedores},
'                New DrawerItem With {.Text = "Órdenes", .Icon = IconChar.ClipboardList, .Handler = AddressOf OnOrdenes}
'            }
'        }
'    }

'    Public Sub New()
'        InitializeComponent()

'        ' Instanciar Animator y Manager
'        animator = New DrawerAnimatorOrbital(
'            target:=drawerPanel,
'            width:=250,
'            duration:=15,
'            steps:=1
'        )

'        ' --- 2) Creamos el manager PASANDO LOS 4 ARGUMENTOS ---
'        manager = New DrawerManagerOrbital(
'            panel:=drawerPanel,
'            trigger:=btnHamburger,
'            groupConfigs:=groupConfigs,
'            finalWidth:=250
'        )
'        manager.PendingGroup = DrawerGroup.Ventas
'        animator.Toggle()
'    End Sub

'    ' Handlers para cada ítem
'    Private Sub OnFacturacion(sender As Object, e As EventArgs)
'        MessageBox.Show("Facturación seleccionada")
'    End Sub

'    Private Sub OnReportes(sender As Object, e As EventArgs)
'        MessageBox.Show("Reportes seleccionados")
'    End Sub

'    Private Sub OnClientes(sender As Object, e As EventArgs)
'        MessageBox.Show("Clientes seleccionados")
'    End Sub

'    Private Sub OnProveedores(sender As Object, e As EventArgs)
'        MessageBox.Show("Proveedores seleccionados")
'    End Sub

'    Private Sub OnOrdenes(sender As Object, e As EventArgs)
'        MessageBox.Show("Órdenes seleccionadas")
'    End Sub
'End Class






''Imports System
''Imports System.Drawing
''Imports System.Windows.Forms
''Imports DocumentFormat.OpenXml.Drawing
''Imports FontAwesome.Sharp

''Public Class frm_Visual
''    Inherits Form

''    Private drawerUI As DrawerPanelUI
''    Private drawerMgr As DrawerManagerOrbital

''    Private PanelPrincipal As TableLayoutPanel
''    Private panelMenu As Panel

''    Private WithEvents btnHamburger As IconButton
''    Private WithEvents btnVentas As IconButton
''    Private WithEvents btnCompras As IconButton
''    Private WithEvents btnInventario As IconButton
''    Private WithEvents btnThemeToggle As IconButton

''    Public Sub New()
''        ' --- Form básico ---
''        Me.Text = "Drawer Orbital Moderno"
''        Me.ClientSize = New Size(900, 600)
''        Me.StartPosition = FormStartPosition.CenterScreen

''        ' --- Drawer secundario y su manager (se añade primero para Z-order) ---
''        drawerUI = New DrawerPanelUI()
''        drawerMgr = New DrawerManagerOrbital(drawerUI)
''        Me.Controls.Add(drawerUI)

''        ' --- TableLayoutPanel: 1 columna, 2 filas ---
''        PanelPrincipal = New TableLayoutPanel() With {
''            .Dock = DockStyle.Left,
''            .Width = 70,
''            .BackColor = ThemeManagerUI.BackColor,
''            .ColumnCount = 1,
''            .RowCount = 2
''        }
''        ' Limpiar estilos viejos y definir nuevos
''        PanelPrincipal.ColumnStyles.Clear()
''        PanelPrincipal.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100))

''        PanelPrincipal.RowStyles.Clear()
''        PanelPrincipal.RowStyles.Add(New RowStyle(SizeType.Absolute, 50))   ' fila 0: 50px
''        PanelPrincipal.RowStyles.Add(New RowStyle(SizeType.Percent, 100))   ' fila 1: resto %

''        Me.Controls.Add(PanelPrincipal)

''        ' --- Botón hamburguesa en (0,0) ---
''        btnHamburger = New IconButton() With {
''            .IconChar = IconChar.Bars,
''            .IconColor = ThemeManagerUI.ForeColor,
''            .Dock = DockStyle.Fill,
''            .FlatStyle = FlatStyle.Flat,
''            .BackColor = Color.Transparent
''        }
''        btnHamburger.FlatAppearance.BorderSize = 0
''        PanelPrincipal.Controls.Add(btnHamburger, column:=0, row:=0)

''        ' --- Panel de menú con scroll en (0,1) ---
''        panelMenu = New Panel() With {
''            .Dock = DockStyle.Fill,
''            .BackColor = ThemeManagerUI.BackColor,
''            .AutoScroll = True
''        }
''        PanelPrincipal.Controls.Add(panelMenu, column:=0, row:=1)
''        panelMenu.BringToFront()    ' asegurar visibilidad

''        ' --- Crear y añadir botones (inverso para Dock Top) ---
''        btnInventario = CreateMenuButton(IconChar.Box, "Inventario")
''        btnCompras = CreateMenuButton(IconChar.CartArrowDown, "Compras")
''        btnVentas = CreateMenuButton(IconChar.Tags, "Ventas")
''        btnThemeToggle = CreateMenuButton(IconChar.Lightbulb, "ToggleTheme")

''        For Each btn In {btnThemeToggle, btnVentas, btnCompras, btnInventario}
''            panelMenu.Controls.Add(btn)
''        Next

''        ' --- Tema inicial ---
''        ApplyTheme()
''    End Sub

''    Private Function CreateMenuButton(icon As IconChar, tag As String) As IconButton
''        Dim btn = New IconButton() With {
''            .IconChar = icon,
''            .IconColor = ThemeManagerUI.ForeColor,
''            .Text = "",
''            .Tag = tag,
''            .Dock = DockStyle.Top,
''            .Height = 50,
''            .FlatStyle = FlatStyle.Flat,
''            .BackColor = Color.Transparent
''        }
''        btn.FlatAppearance.BorderSize = 0
''        Return btn
''    End Function

''    Private Sub ApplyTheme()
''        Me.BackColor = ThemeManagerUI.BackColor
''        PanelPrincipal.BackColor = ThemeManagerUI.BackColor
''        drawerUI.BackColor = ThemeManagerUI.BackColor
''        panelMenu.BackColor = ThemeManagerUI.BackColor

''        ' Actualiza colores de todos los IconButtons
''        Dim allBtns = PanelPrincipal.Controls.Cast(Of Control)() _
''                      .Concat(panelMenu.Controls.Cast(Of Control)())
''        For Each ctrl In allBtns
''            If TypeOf ctrl Is IconButton Then
''                Dim icb = DirectCast(ctrl, IconButton)
''                icb.IconColor = ThemeManagerUI.ForeColor
''                icb.ForeColor = ThemeManagerUI.ForeColor
''                icb.BackColor = If(ThemeManagerUI.CurrentTheme = AppTheme.Dark,
''                                   Color.FromArgb(45, 45, 45),
''                                   Color.LightGray)
''            End If
''        Next
''    End Sub

''    ' ─── Handlers ───────────────────────────────────────────────────────────
''    Private Sub btnHamburger_Click(sender As Object, e As EventArgs) Handles btnHamburger.Click
''        drawerMgr.Hide()
''    End Sub

''    Private Sub btnVentas_Click(sender As Object, e As EventArgs) Handles btnVentas.Click
''        drawerMgr.ShowGroup("Ventas")
''    End Sub

''    Private Sub btnCompras_Click(sender As Object, e As EventArgs) Handles btnCompras.Click
''        drawerMgr.ShowGroup("Compras")
''    End Sub

''    Private Sub btnInventario_Click(sender As Object, e As EventArgs) Handles btnInventario.Click
''        drawerMgr.ShowGroup("Inventario")
''    End Sub

''    Private Sub btnThemeToggle_Click(sender As Object, e As EventArgs) Handles btnThemeToggle.Click
''        ThemeManagerUI.CurrentTheme = If(ThemeManagerUI.CurrentTheme = AppTheme.Dark,
''                                        AppTheme.Light,
''                                        AppTheme.Dark)
''        ApplyTheme()
''    End Sub
''End Class



''Private Sub AnimarDrawer(panel As System.Windows.Forms.Panel, abrir As Boolean)
''    Dim targetX As Integer = If(abrir, 0, -panel.Width)
''    Dim velocidad As Integer = 20
''    Dim timerAnimacion As New Timer With {.Interval = 15}

''    AddHandler timerAnimacion.Tick, Sub()
''                                        Dim delta As Integer = velocidad
''                                        If abrir AndAlso panel.Left < targetX Then
''                                            panel.Left = Math.Min(panel.Left + delta, targetX)
''                                        ElseIf Not abrir AndAlso panel.Left > targetX Then
''                                            panel.Left = Math.Max(panel.Left - delta, targetX)
''                                        Else
''                                            timerAnimacion.Stop()
''                                            timerAnimacion.Dispose()
''                                        End If
''                                    End Sub

''    timerAnimacion.Start()
''End Sub

''Private Sub ToggleDrawerAnimado()
''    Dim abrir As Boolean = DrawerPanelUI.Left < 0
''    AnimarDrawer(DrawerPanelUI, abrir)
''End Sub


''Private Sub CargarDatosDesdeSql()
''    Dim tabla As New DataTable()

''    Using conexion As New SqlConnection("TuConexionSQL")
''        conexion.Open()
''        Dim cmd As New SqlCommand("SELECT ID, Nombre, Correo, FechaAlta, TotalPagado FROM Empleados", conexion)
''        Dim adapter As New SqlDataAdapter(cmd)
''        adapter.Fill(tabla)
''    End Using

''    Dim visibles = {"ID", "Nombre", "Correo", "FechaAlta", "TotalPagado", "Mensaje"}
''    Dim anchos = New Dictionary(Of String, Integer) From {
''    {"ID", 60}, {"Nombre", 200}, {"Correo", 180},
''    {"FechaAlta", 100}, {"TotalPagado", 100}
''}
''    Dim visuales = New Dictionary(Of String, String) From {
''    {"ID", "#"}, {"Nombre", "Nombre completo"},
''    {"Correo", "Correo electrónico"}, {"FechaAlta", "Fecha de alta"},
''    {"TotalPagado", "Total pagado Bs."}
''}



''    gridUI.ConfigurarColumnasVisualesPorTipo(tabla, visibles, anchos, visuales)
''    gridUI.CargarDatos(tabla) ' o RefrescarPaginacion(tabla)
''End Sub

''Private Sub CargarDatosDePrueba()
''    ' 1. Crear tabla simulada
''    Dim tabla As New DataTable()
''    tabla.Columns.Add("ID", GetType(Integer))
''    tabla.Columns.Add("Nombre", GetType(String))
''    tabla.Columns.Add("Correo", GetType(String))
''    tabla.Columns.Add("FechaAlta", GetType(DateTime))
''    tabla.Columns.Add("TotalPagado", GetType(Decimal))
''    tabla.Columns.Add("Mensaje", GetType(String))

''    For i = 1 To 25
''        tabla.Rows.Add(i, $"Empleado {i}", $"empleado{i}@empresa.com", Date.Today.AddDays(-i), i * 1500, "Hola")
''    Next

''    Dim colAgregar = New DataGridViewImageColumn() With {
''            .Image = IconChar.Plus.ToBitmapPaint(Color.SeaGreen, 18),
''            .HeaderText = "",
''            .Width = 20,
''            .MinimumWidth = 18,
''            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
''            .Resizable = DataGridViewTriState.False
''        }

''    Dim colEditar = New DataGridViewImageColumn() With {
''            .Image = IconChar.Pen.ToBitmapPaint(Color.SteelBlue, 18),
''            .HeaderText = "",
''            .Width = 20,
''            .MinimumWidth = 18,
''            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
''            .Resizable = DataGridViewTriState.False
''        }

''    Dim colEliminar = New DataGridViewImageColumn() With {
''            .Image = IconChar.TrashAlt.ToBitmapPaint(Color.Firebrick, 18),
''            .HeaderText = "",
''            .Width = 20,
''            .MinimumWidth = 18,
''            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
''            .Resizable = DataGridViewTriState.False
''        }

''    gridUI.GrvOrbital.Columns.AddRange({colAgregar, colEditar, colEliminar})

''    ' 3. Definir columnas visuales
''    Dim visibles = {"ID", "Nombre", "Correo", "FechaAlta", "TotalPagado", "Mensaje"}
''    Dim anchos = New Dictionary(Of String, Integer) From {
''    {"ID", 50}, {"Nombre", 300}, {"Correo", 250}, {"FechaAlta", 150}, {"TotalPagado", 120}, {"Mensaje", 150}
''}
''    Dim visuales = New Dictionary(Of String, String) From {
''    {"ID", "#"}, {"Nombre", "Nombre completo"},
''    {"Correo", "Correo electrónico"},
''    {"FechaAlta", "Fecha de alta"},
''    {"TotalPagado", "Total pagado Bs."},
''    {"Mensaje", "Mensaje pagado"}
''}

''    ' 4. Configurar columnas visuales y cargar datos
''    gridUI.ConfigurarColumnasVisualesPorTipo(tabla, visibles, anchos, visuales)
''    gridUI.CargarDatos(tabla)
''End Sub








'''

'''Me.Controls.Add(gridUI)

'''' Cargar registros simulados
'''Dim dt As New DataTable()
'''dt.Columns.Add("ID", GetType(Integer))
'''dt.Columns.Add("Nombre")
'''dt.Columns.Add("Correo")

'''dt.Rows.Add(1, "Wilmer Duarte", "wilmer@empresa.com")
'''dt.Rows.Add(2, "Sofía Ramos", "sofia@empresa.com")
'''dt.Rows.Add(3, "Julio López", "carlos@empresa.com")
'''dt.Rows.Add(1, "Wilmer Duarte", "wilmer@empresa.com")
'''dt.Rows.Add(2, "Petra Ramos", "sofia@empresa.com")
'''dt.Rows.Add(3, "Cars López", "carlos@empresa.com")
'''dt.Rows.Add(1, "Pedro Duarte", "wilmer@empresa.com")
'''dt.Rows.Add(2, "Sofía Ramos", "sofia@empresa.com")
'''dt.Rows.Add(3, "Marcos López", "carlos@empresa.com")
'''dt.Rows.Add(1, "Wilmer Duarte", "wilmer@empresa.com")
'''dt.Rows.Add(2, "Julia Ramos", "sofia@empresa.com")
'''dt.Rows.Add(3, "Manuel López", "carlos@empresa.com")
'''' Cargar al Grid principal
'''gridUI.CargarDatos(dt)

'''' Actualizar el encabezado visual
'''gridUI.lblTitulo.Titulo = "Wilmer Flores"
'''gridUI.lblTitulo.Subtitulo = "Gestión de usuarios"
'''gridUI.lblTitulo.Icono = IconChar.User


'''AddHandler gridUI.Filtros.TextChanged, Sub()
'''                                           Debug.Print("Filtro activado: " & gridUI.Filtros.TextoFiltrado)
'''                                       End Sub

'''tabPanel = New TabPanelUI() With {
'''    .Dock = DockStyle.Fill,
'''    .TabHeight = 44
'''}

'''Me.Controls.Add(tabPanel)

'''Dim contenido As New moduloProductos()
'''tabPanel.AddTab(New TabItemOrbitalAdv With {
'''        .Titulo = "Auditoría",
'''        .Icono = IconChar.A,
'''        .Estilo = TabItemOrbitalAdv.EstiloBootstrap.Success,
'''        .Tooltip = "Registros y seguimiento del sistema",
'''        .Contenido = contenido,
'''        .EstadoValidacion = TabItemOrbitalAdv.EstadoOrbital.Pendiente
'''})

'''tabPanel.AddTab(New TabItemOrbitalAdv With {
'''        .Titulo = "Control",
'''        .Icono = IconChar.ClinicMedical,
'''        .Estilo = TabItemOrbitalAdv.EstiloBootstrap.Info,
'''        .Tooltip = "Registros y seguimiento del sistema",
'''        .Contenido = contenido,
'''        .EstadoValidacion = TabItemOrbitalAdv.EstadoOrbital.Ninguno
'''})

'''tabPanel.AddTab(New TabItemOrbitalAdv With {
'''        .Titulo = "Productos",
'''        .Icono = IconChar.Procedures,
'''        .Estilo = TabItemOrbitalAdv.EstiloBootstrap.Dark,
'''        .Tooltip = "Registros y seguimiento del sistema",
'''        .Contenido = contenido,
'''        .EstadoValidacion = TabItemOrbitalAdv.EstadoOrbital.Correcto
'''})






'''Eventos públicos orbitando 🚀
''Private Sub gridUI_EditarRegistro(id As Integer) Handles gridUI.EditarRegistro
''    MessageBox.Show($"Editar: {id}")
''End Sub

''Private Sub gridUI_EliminarRegistro(id As Integer) Handles gridUI.EliminarRegistro
''    MessageBox.Show($"Eliminar: {id}")
''End Sub

''Private Sub gridUI_AgregarRegistro() Handles gridUI.AgregarRegistro
''    MessageBox.Show("Agregar nuevo registro")
''End Sub

''Private Sub gridUI_ExportarExcelSolicitado() Handles gridUI.ExportarExcelSolicitado
''    gridUI.ExportarConEstiloExcel("ReporteFinanciero")
''End Sub



