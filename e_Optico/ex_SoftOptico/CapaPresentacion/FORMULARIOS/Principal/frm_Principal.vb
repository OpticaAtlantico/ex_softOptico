Imports System.Drawing.Drawing2D
Imports System.Printing
Imports System.Runtime.InteropServices
Imports CapaDatos
Imports CapaEntidad
Imports FontAwesome.Sharp

Public Class frm_Principal

#Region "=== VARIABLES ==="
    ' Drawer
    Private drawerAbierto As Boolean = False
    Private drawerControl As New DrawerControl()
    Private DrawerExpandido As Boolean = False
    Private DrawerObjetivoWidth As Integer = 200
    Private DrawerVelocidad As Integer = 15

    ' Timers
    Private fadeTimer As New Timer() With {.Interval = 15}
    Private fadeStep As Double = 0.05

    ' Formularios
    Private activeForms As Form = Nothing
    Public Event AbrirFormularioHijoSolicitado As Action(Of Form)

    ' Botones
    Private currentButton As Button
    Private botonActivo As IconButton = Nothing

    ' Modelos (login)
    Private loginmodelo = listLogin

    'Botones 
    Private botones As New List(Of Button)

#End Region

#Region "=== PROPIEDADES ==="
    Public Property EmpleadoEncontrado As VEmpleados = Nothing
    Public Property ProveedorEncontrado As VProveedor = Nothing
    Public Property CompraEncontrado As VCompras = Nothing
#End Region

#Region "=== CONSTRUCTOR ==="
    Public Sub New()
        InitializeComponent()
        FormStylerUI.Apply(Me)
        InicializarUI()
        AddHandler fadeTimer.Tick, AddressOf DrawerTimer_Tick
        pnlDrawer.BringToFront()
    End Sub
    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H2000000 ' WS_EX_COMPOSITED
            Return cp
        End Get
    End Property

#End Region

#Region "=== INICIALIZACION UI ==="
    Private Sub InicializarUI()
        MaximizarFrm(Me)

        ' Colores principales
        pnlMenu.BackColor = AppColors._cMenu1
        pnlEncabezado.BackColor = AppColors._cFondo
        pnlBotones.BackColor = AppColors._cFondo
        pnlSalirfrm.BackColor = AppColors._cFondo

        ' Botones de encabezado
        btnSalirFrmHijo.IconColor = AppColors._cBlanco
        btnSalirFrmHijo.BackColor = AppColors._cFondo
        btnMostrarMenu.IconColor = AppColors._cHeaderTexto

        btnSalir.FlatAppearance.MouseOverBackColor = AppColors._cBotonFrm
        btnMinimizar.FlatAppearance.MouseOverBackColor = AppColors._cBotonFrm
        btnMaximizar.FlatAppearance.MouseOverBackColor = AppColors._cBotonFrm

        Dim btn As New IconButton
        For Each btn In pnlMenu.Controls
            If TypeOf btn Is IconButton Then
                botones.Add(btn)
                AddHandler btn.Click, AddressOf Boton_Click
            End If
        Next

    End Sub
    Private Sub PrepararUI()
        pnlDrawer.Controls.Add(drawerControl)
        pnlDrawer.BackColor = Color.Azure
        CerrarDrawer()
        With Me
            btnSalirFrmHijo.Visible = False
            .Text = String.Empty
            .ControlBox = False
            .MaximizedBounds = Screen.FromHandle(Me.Handle).WorkingArea
        End With

        With Me.lblTitulo
            .Icono = IconChar.Eye
            .Titulo = "SISTEMA INTEGRAL DE GESTIÓN OPTICA"
            .Subtitulo = "Administracion, Gestión y Control de Ópticas "
            .ColorFondo = AppColors._cFondo
            .ColorTexto = AppColors._cBlancoOscuro
        End With

        With Me.lblEmpleado
            .Icono = IconChar.UsersViewfinder
            .Titulo = Sesion.NombreUsuario
            .Subtitulo = Sesion.Cargo
            .ColorFondo = AppColors._cFondo
            .ColorTexto = AppColors._cBlancoOscuro
        End With

        With Me.lblLocalidad
            .Icono = IconChar.LocationDot
            .Titulo = Sesion.NombreUbicacion
            .Subtitulo = Sesion.Direccion
            .ColorFondo = AppColors._cFondo
            .ColorTexto = AppColors._cBlancoOscuro
        End With

        WindowState = FormWindowState.Maximized
    End Sub

#End Region

#Region "=== DRAG FORM ==="

    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub

    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Integer, lParam As Integer)
    End Sub
    Private Sub pnlEncabezado_MouseDown(sender As Object, e As MouseEventArgs) Handles pnlEncabezado.MouseDown
        'Funcion para permitir mover el formulario por todas partes
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub
#End Region

#Region "=== EVENTOS FORMULARIO ==="
    Private Sub frm_Principal_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.SuspendLayout()
        PrepararUI()
        AddHandler AbrirFormularioHijoSolicitado, AddressOf OpenChildForm
        Me.ResumeLayout()
        FadeManagerUI.StartFade(Me, 0.08)
    End Sub

#End Region

#Region "=== BOTONES ENCABEZADO ==="
    Private Sub btnSalirFrmHijo_Click(sender As Object, e As EventArgs) Handles btnSalirFrmHijo.Click
        If activeForms IsNot Nothing Then activeForms.Close()
        Reset()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.SuspendLayout()
        Dim confirmacion = MessageBoxUI.Mostrar("Cerrar...",
                                                 "Saliendo del Sistema de gestión de datos",
                                                 MessageBoxUI.TipoMensaje.Exito,
                                                 MessageBoxUI.TipoBotones.AceptarCancelar)

        If confirmacion = DialogResult.Cancel Then Exit Sub

        listLogin.Clear()
        Me.Close() ' Cierra el formulario después de eliminar
        Me.ResumeLayout()
    End Sub

    Private Sub btnMaximizar_Click(sender As Object, e As EventArgs) Handles btnMaximizar.Click
        If Me.WindowState = FormWindowState.Normal Then
            MaximizarFrm(Me)
        Else
            Me.WindowState = FormWindowState.Normal
            Me.Bounds = Screen.PrimaryScreen.WorkingArea
        End If
    End Sub

    Private Sub btnminimizar_Click(sender As Object, e As EventArgs) Handles btnMinimizar.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

#End Region

#Region "=== BOTONES MENU EMPLEADOS ==="

    Private Sub BotonMenuEmpleados()
        Dim opciones As New List(Of Tuple(Of String, IconChar, EventHandler)) From {
        Tuple.Create("Reportes", IconChar.ListCheck, New EventHandler(AddressOf SubReportesE_Click)),
        Tuple.Create("Consultar", IconChar.ListNumeric, New EventHandler(AddressOf SubConsultarE_Click)),
        Tuple.Create("Eliminar Datos", IconChar.TrashArrowUp, New EventHandler(AddressOf SubEliminarE_Click)),
        Tuple.Create("Editar Datos", IconChar.FilePen, New EventHandler(AddressOf SubEditarE_Click)),
        Tuple.Create("Nuevo Registro", IconChar.Save, New EventHandler(AddressOf SubNuevoE_Click))
    }

        drawerControl.CargarOpciones(opciones)
        If pnlDrawer.Width = 0 Then AbrirDrawer()
    End Sub

    Private Sub SubNuevoE_Click(sender As Object, e As EventArgs)
        Me.SuspendLayout()
        CerrarDrawer()

        If Not Application.OpenForms().OfType(Of frmEmpleado).Any() Then
            'EfectoBotonInactivo()
            Dim frm As New frmEmpleado With {.NombreBoton = "Guardar..."}
            AddHandler frm.CerrarEmpleado, Sub() btnSalirFrmHijo.Visible = False
            OpenChildForm(frm)
            btnSalirFrmHijo.Visible = True
        End If

        Me.ResumeLayout()
    End Sub

    Private Sub SubEditarE_Click(sender As Object, e As EventArgs)
        PedirDatoEmpleado("Ingrese número de cédula", Sub(valor) enviarDatosEmpleados(valor, 0))
    End Sub

    Private Sub SubEliminarE_Click(sender As Object, e As EventArgs)
        PedirDatoEmpleado("Ingrese número de cédula", Sub(valor) enviarDatosEmpleados(valor, 1))
    End Sub

    Private Sub SubConsultarE_Click(sender As Object, e As EventArgs)
        Me.SuspendLayout()
        CerrarDrawer()

        If Not Application.OpenForms().OfType(Of frmConsultaEmpleados).Any() Then
            'EfectoBotonInactivo()
            Dim frm As New frmConsultaEmpleados()
            AddHandler frm.AbrirFormularioHijo, AddressOf Me.SolicitarAbrirFormularioHijo
            OpenChildForm(frm)
        End If

        Me.ResumeLayout()
    End Sub

    Private Sub SubReportesE_Click(sender As Object, e As EventArgs)
        CerrarDrawer()
    End Sub
    Private Sub PedirDatoEmpleado(titulo As String, accionSiValido As Action(Of String))
        Me.SuspendLayout()
        CerrarDrawer()

        Dim overlay As New FondoOverlayUI()
        overlay.Show()
        Dim resultado = InputBoxUI.Mostrar(
        titulo:=titulo,
        placeholder:="12345678",
        tipoDato:=InputBoxUI.TipoValidacion.Numero,
        icono:=FontAwesome.Sharp.IconChar.UserAlt,
        obligatorio:=True)
        overlay.Close()

        'EfectoBotonInactivo()

        If resultado.Aceptado Then
            accionSiValido(resultado.Valor)
        Else
            MessageBoxUI.Mostrar("Cerrar...",
                             "Saliendo de control de entrada de datos",
                             MessageBoxUI.TipoMensaje.Advertencia,
                             MessageBoxUI.TipoBotones.Aceptar)
        End If

        Me.ResumeLayout()
    End Sub
#End Region

#Region "Botones menu Inventario"
    Private Sub BotonMenuInventario()
        Dim opciones As New List(Of Tuple(Of String, IconChar, EventHandler)) From {
        Tuple.Create("Reporte", IconChar.ListCheck, New EventHandler(AddressOf SubReportesInv_Click)),
        Tuple.Create("Conteo Físico", IconChar.Refresh, New EventHandler(AddressOf SubReportesInv_Click)),
        Tuple.Create("Ajustes", IconChar.Refresh, New EventHandler(AddressOf SubReportesInv_Click)),
        Tuple.Create("Admin. Géneros", IconChar.Refresh, New EventHandler(AddressOf SubReportesInv_Click)),
        Tuple.Create("Admin. Grupos", IconChar.Refresh, New EventHandler(AddressOf SubReportesInv_Click)),
        Tuple.Create("Consultas", IconChar.ListNumeric, New EventHandler(AddressOf SubConsultarInv_Click)),
        Tuple.Create("Lista de Misceláneos", IconChar.TrashArrowUp, New EventHandler(AddressOf SubEliminarInv_Click)),
        Tuple.Create("Catálogo de Cristales", IconChar.FilePen, New EventHandler(AddressOf SubEditarInv_Click)),
        Tuple.Create("Catálogo de Lentes", IconChar.Save, New EventHandler(AddressOf SubNuevoInv_Click))
    }

        drawerControl.CargarOpciones(opciones)
        AbrirDrawer()
    End Sub

    Private Sub SubReportesInv_Click(sender As Object, e As EventArgs)
        Throw New NotImplementedException()
    End Sub

    Private Sub SubConsultarInv_Click(sender As Object, e As EventArgs)
        OpenChildForm(New frmConsultarCompras)
    End Sub

    Private Sub SubEliminarInv_Click(sender As Object, e As EventArgs)
        ActualizarEliminarCompra(1)
    End Sub

    Private Sub SubEditarInv_Click(sender As Object, e As EventArgs)
        ActualizarEliminarCompra(0)
    End Sub

    Private Sub SubNuevoInv_Click(sender As Object, e As EventArgs)
        OpenChildForm(New frmProductos)
    End Sub
#End Region

#Region "Botones menu Ventas"

#End Region

#Region "Boton menu compra"
    Private Sub BotonMenuCompra()
        ' Crear las opciones de manera clara, evitando CType de lambdas
        Dim opciones As New List(Of Tuple(Of String, IconChar, EventHandler))

        Dim handlerReporte As New EventHandler(AddressOf SubReportesC_Click)
        opciones.Add(Tuple.Create("Reporte", IconChar.ListCheck, handlerReporte))

        Dim handlerDevolucion As New EventHandler(AddressOf SubReportesPv_Click)
        opciones.Add(Tuple.Create("Devolución a Prove...", IconChar.Refresh, handlerDevolucion))

        Dim handlerConsultar As New EventHandler(AddressOf SubConsultarC_Click)
        opciones.Add(Tuple.Create("Consultar", IconChar.ListNumeric, handlerConsultar))

        Dim handlerEliminar As New EventHandler(AddressOf SubEliminarC_Click)
        opciones.Add(Tuple.Create("Borrar Orden", IconChar.TrashArrowUp, handlerEliminar))

        Dim handlerEditar As New EventHandler(AddressOf SubEditarC_Click)
        opciones.Add(Tuple.Create("Editar Orden", IconChar.FilePen, handlerEditar))

        Dim handlerNuevo As New EventHandler(AddressOf SubNuevoC_Click)
        opciones.Add(Tuple.Create("Nueva Orden", IconChar.Save, handlerNuevo))

        ' Cargar en Drawer
        drawerControl.CargarOpciones(opciones)
        'pnlDrawer.Visible = True
        If pnlDrawer.Width = 0 Then
            AbrirDrawer()
        End If
    End Sub

    Private Sub SubReportesC_Click(sender As Object, e As EventArgs)
        Throw New NotImplementedException()
    End Sub

    Private Sub SubConsultarC_Click(sender As Object, e As EventArgs)
        Me.SuspendLayout()
        Dim abierto As Boolean = Application.OpenForms().OfType(Of frmConsultarCompras).Any()

        CerrarDrawer()

        If Not abierto Then
            'EfectoBotonInActivo()
            Dim consultaCompraForm As New frmConsultarCompras()
            AddHandler consultaCompraForm.AbrirFormularioHijo, AddressOf Me.SolicitarAbrirFormularioHijo
            OpenChildForm(consultaCompraForm)
        End If
        Me.ResumeLayout()
    End Sub

    Private Sub SubEliminarC_Click(sender As Object, e As EventArgs)
        ActualizarEliminarCompra(1)
    End Sub

    Private Sub SubEditarC_Click(sender As Object, e As EventArgs)
        ActualizarEliminarCompra(0)
    End Sub

    Private Sub SubNuevoC_Click(sender As Object, e As EventArgs)
        Dim abierto As Boolean = Application.OpenForms().OfType(Of frmCompras).Any()

        CerrarDrawer()

        If Not abierto Then
            OpenChildForm(New frmCompras)
            'EfectoBotonInActivo()
        End If
    End Sub

#End Region

#Region "Botones menu Proveedor"

    Private Sub BotonMenuProveedor()
        ' Crear las opciones de manera clara, evitando CType de lambdas
        Dim opciones As New List(Of Tuple(Of String, IconChar, EventHandler))

        Dim handlerReporte As New EventHandler(AddressOf SubReportesPv_Click)
        opciones.Add(Tuple.Create("Reportes", IconChar.ListCheck, handlerReporte))

        Dim handlerConsultar As New EventHandler(AddressOf SubConsultarPv_Click)
        opciones.Add(Tuple.Create("Consultar", IconChar.ListNumeric, handlerConsultar))

        Dim handlerEliminar As New EventHandler(AddressOf SubEliminarPv_Click)
        opciones.Add(Tuple.Create("Eliminar Registro", IconChar.TrashArrowUp, handlerEliminar))

        Dim handlerEditar As New EventHandler(AddressOf SubEditarPv_Click)
        opciones.Add(Tuple.Create("Editar Datos", IconChar.FolderOpen, handlerEditar))

        Dim handlerNuevo As New EventHandler(AddressOf SubNuevoPv_Click)
        opciones.Add(Tuple.Create("Nuevo Registro", IconChar.Save, handlerNuevo))

        ' Cargar en Drawer
        drawerControl.CargarOpciones(opciones)
        'pnlDrawer.Visible = True
        If pnlDrawer.Width = 0 Then
            AbrirDrawer()
        End If
    End Sub

    Private Sub SubNuevoPv_Click(sender As Object, e As EventArgs)
        Me.SuspendLayout()
        Dim abierto As Boolean = Application.OpenForms().OfType(Of frmProveedor).Any()

        CerrarDrawer()

        If Not abierto Then
            OpenChildForm(New frmProveedor)
            'EfectoBotonInActivo()
        End If
        Me.ResumeLayout()
    End Sub

    Private Sub SubEditarPv_Click(sender As Object, e As EventArgs)
        Me.SuspendLayout()
        CerrarDrawer()

        Dim overlay As New FondoOverlayUI()
        overlay.Show()
        Dim resultado = InputBoxUI.Mostrar(
            titulo:="Ingrese el Nombre de la Empresa",
            placeholder:="Ferreteria",
            tipoDato:=InputBoxUI.TipoValidacion.Texto,
            icono:=FontAwesome.Sharp.IconChar.UserAlt,
            obligatorio:=True
        )
        overlay.Close()
        'EfectoBotonInActivo()

        If resultado.Aceptado Then
            enviarDatosProveedor(resultado.Valor, 0)
        Else
            MessageBoxUI.Mostrar("Cerrar...", "Saliendo de control de entrada de datos",
                                 MessageBoxUI.TipoMensaje.Advertencia,
                                 MessageBoxUI.TipoBotones.Aceptar)
        End If
        Me.ResumeLayout()
    End Sub

    Private Sub SubEliminarPv_Click(sender As Object, e As EventArgs)
        Me.SuspendLayout()
        CerrarDrawer()

        Dim overlay As New FondoOverlayUI()
        overlay.Show()
        Dim resultado = InputBoxUI.Mostrar(
            titulo:="Ingrese el nombre del proveedor",
            placeholder:="ferret",
            tipoDato:=InputBoxUI.TipoValidacion.Texto,
            icono:=FontAwesome.Sharp.IconChar.UserAlt,
            obligatorio:=True
        )
        overlay.Close()
        'EfectoBotonInActivo()

        If resultado.Aceptado Then
            enviarDatosProveedor(resultado.Valor, 1)
        Else
            MessageBoxUI.Mostrar("Cerrar...",
                                 "Saliendo de control de entrada de datos",
                                 MessageBoxUI.TipoMensaje.Advertencia,
                                 MessageBoxUI.TipoBotones.Aceptar)
        End If
        Me.ResumeLayout()
    End Sub

    Private Sub SubConsultarPv_Click(sender As Object, e As EventArgs)
        Me.SuspendLayout()
        Dim abierto As Boolean = Application.OpenForms().OfType(Of frmConsultaProveedor).Any()

        CerrarDrawer()

        If Not abierto Then
            'EfectoBotonInActivo()
            Dim consultaProveedorForm As New frmConsultaProveedor()
            AddHandler consultaProveedorForm.AbrirFormularioHijo, AddressOf Me.SolicitarAbrirFormularioHijo
            OpenChildForm(consultaProveedorForm)

        End If
        Me.ResumeLayout()
    End Sub


    Private Sub SubReportesPv_Click(sender As Object, e As EventArgs)
        'MostrarContenido(New PegarControl())
        CerrarDrawer()
    End Sub

#End Region

#Region "=== BOTONES DEL MENU ==="

    Private Sub Boton_Click(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        MarcarBotonActivo(btn.Tag.ToString(), botonActivo)
        OpcionSeleccionada(btn.Tag.ToString())
    End Sub

    Private Sub OpcionSeleccionada(opcion As String)
        Select Case opcion
            Case ""


        End Select
    End Sub

    'Private Sub btnInventario_Click(sender As Object, e As EventArgs) Handles btnInventario.Click
    '    EfectoBotonActivo(sender)
    '    BotonMenuInventario()
    'End Sub

    'Private Sub btnVenta_Click(sender As Object, e As EventArgs) Handles btnVenta.Click
    '    'BotonMenuInventario()
    '    EfectoBotonActivo(sender)
    'End Sub

    'Private Sub btnCompra_Click(sender As Object, e As EventArgs) Handles btnCompra.Click
    '    EfectoBotonActivo(sender)
    '    BotonMenuCompra()
    'End Sub

    'Private Sub btnProveedor_Click(sender As Object, e As EventArgs) Handles btnProveedor.Click
    'Boton_Click(sender, e)
    'EfectoBotonActivo(sender)
    'BotonMenuProveedor()
    'End Sub

    'Private Sub btnEmpleado_Click(sender As Object, e As EventArgs) Handles btnEmpleado.Click
    'Boton_Click(sender, e)
    'EfectoBotonActivo(sender)
    'BotonMenuEmpleados()
    'End Sub

    'Private Sub btnComision_Click(sender As Object, e As EventArgs) Handles btnComision.Click
    '    'BotonMenuInventario()
    '    EfectoBotonActivo(sender)
    'End Sub

    'Private Sub btnNomina_Click(sender As Object, e As EventArgs) Handles btnNomina.Click
    '    'BotonMenuInventario()
    '    EfectoBotonActivo(sender)
    'End Sub

    'Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
    '    'BotonMenuInventario()
    '    EfectoBotonActivo(sender)
    'End Sub

    'Private Sub btnAnalisis_Click(sender As Object, e As EventArgs) Handles btnAnalisis.Click
    '    'BotonMenuInventario()
    '    EfectoBotonActivo(sender)
    'End Sub

    'Private Sub btnAjustes_Click(sender As Object, e As EventArgs) Handles btnAjustes.Click
    '    'BotonMenuInventario()
    '    EfectoBotonActivo(sender)
    'End Sub


#End Region

#Region "=== DRAWER ==="
    Private Sub btnMostrarMenu_Click(sender As Object, e As EventArgs) Handles btnMostrarMenu.Click
        Boton_Click(sender, e)
        DrawerTimer.Start()
    End Sub

    Private Sub DrawerTimer_Tick(sender As Object, e As EventArgs) Handles DrawerTimer.Tick
        Me.SuspendLayout()

        If Not DrawerExpandido Then
            ' Expandir
            If pnlDrawer.Width < DrawerObjetivoWidth Then
                pnlDrawer.Width += DrawerVelocidad
                ActualizarBotonesTexto(True)
            Else
                DrawerTimer.Stop()
                DrawerExpandido = True
            End If
        Else
            ' Contraer
            If pnlDrawer.Width > 0 Then
                pnlDrawer.Width -= DrawerVelocidad + 50
                ActualizarBotonesTexto(False)
            Else
                DrawerTimer.Stop()
                DrawerExpandido = False
            End If
        End If

        Me.ResumeLayout()
    End Sub

    Private Sub CerrarDrawer()
        If pnlDrawer.Width > 0 Then
            DrawerExpandido = True
            DrawerTimer.Start()
        End If
    End Sub

    Private Sub AbrirDrawer()
        If pnlDrawer.Width = 0 Then
            DrawerExpandido = False
            DrawerTimer.Start()
        End If
    End Sub
    Private Sub ActualizarBotonesTexto(expanded As Boolean)
        For Each btn In drawerControl.Controls
            If expanded Then
                btn.Text = "  "
            Else
                btn.Text = ""
            End If
        Next
    End Sub
#End Region

#Region "=== FORMULARIOS HIJO ==="
    Public Sub OpenChildForm(childForm As Form)
        ' Si ya hay un formulario activo del mismo tipo, tráelo al frente y no crees otro
        If activeForms IsNot Nothing AndAlso activeForms.GetType() = childForm.GetType() Then
            activeForms.BringToFront()
            Return
        End If

        ' Cerrar el anterior si es distinto
        If activeForms IsNot Nothing Then
            Try
                activeForms.Close()
            Catch
            End Try
        End If

        ' Añadir nuevo formulario al panel contenedor
        activeForms = childForm
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

    Public Sub SolicitarAbrirFormularioHijo(childForm As Form)
        RaiseEvent AbrirFormularioHijoSolicitado(childForm)
    End Sub
#End Region

#Region "=== ESTILO BOTONES ==="

    Public Sub MarcarBotonActivo(nombre As String, ByRef botonAnterior As IconButton)
        If botonAnterior IsNot Nothing Then
            botonAnterior.BackColor = AppColors._cMenu1
            botonAnterior.ForeColor = AppColors._cBlancoOscuro
            botonAnterior.IconColor = AppColors._cBlancoOscuro
        End If

        botonActivo = botones.Find(Function(b) b.Tag.ToString() = nombre)
        If botonActivo IsNot Nothing Then
            botonActivo.BackColor = AppColors._cBlancoOscuro
            botonActivo.ForeColor = AppColors._cTexto
            botonActivo.IconColor = AppColors._cTexto
            botonAnterior = botonActivo
        End If
    End Sub

    'Private Sub EfectoBotonActivo(sender As Object)
    '    EfectoBotonInActivo()
    '    If sender IsNot Nothing Then
    '        sender.BackColor = Color.White
    '        sender.ForeColor = Color.Black
    '        sender.IconColor = Color.Black
    '    End If
    'End Sub
    'Private Sub EfectoBotonInactivo()
    '    For Each btn In pnlMenu.Controls
    '        If TypeOf btn Is IconButton Then
    '            CType(btn, IconButton).IconColor = Color.WhiteSmoke
    '            CType(btn, IconButton).ForeColor = Color.WhiteSmoke
    '            CType(btn, IconButton).BackColor = Color.FromArgb(51, 51, 76)
    '        End If
    '    Next
    'End Sub
    Private Sub ActivateButton()
        btnSalirFrmHijo.Visible = True
    End Sub
    Private Sub DisableButton()
        btnSalirFrmHijo.Visible = False
    End Sub
    Public Sub Reset()
        currentButton = New Button()
        DisableButton()
    End Sub

#End Region

#Region "Procedimientos sql"
    Private Sub enviarDatosEmpleados(cedula As Integer, opcion As Integer)

        Dim repositorio As New Repositorio_Empleados()
        Dim cedulaE As String = cedula
        Dim texto As String = String.Empty

        Try
            Me.EmpleadoEncontrado = repositorio.GetByCedula(cedulaE).FirstOrDefault()

            If Me.EmpleadoEncontrado IsNot Nothing Then
                Dim formularioHijo As New frmEmpleado()
                formularioHijo.DatosEmpleados = Me.EmpleadoEncontrado

                Select Case opcion
                    Case 0
                        texto = "Actualizar..."
                    Case 1
                        texto = "Eliminar..."
                End Select

                formularioHijo.NombreBoton = texto

                ' 🔹 Aquí conectas el evento de cierre del hijo con la acción del principal
                AddHandler formularioHijo.CerrarEmpleado, Sub()
                                                              btnSalirFrmHijo.Visible = False
                                                          End Sub

                ' 🔹 Abres el hijo
                OpenChildForm(formularioHijo)

                ' 🔹 Al abrirlo, muestras el botón salir
                btnSalirFrmHijo.Visible = True

            Else
                MessageBoxUI.Mostrar("Datos no existe...",
                                     "No hay ningún empleado con ese número de cédula, por favor verifique bien los datos",
                                     MessageBoxUI.TipoMensaje.Advertencia,
                                     MessageBoxUI.TipoBotones.Aceptar)
            End If

        Catch ex As Exception
            MessageBoxUI.Mostrar("Error",
                                 "Ocurrió un error al buscar el empleado. Por favor, intente nuevamente. " & ex.Message,
                                 MessageBoxUI.TipoMensaje.Errorr,
                                 MessageBoxUI.TipoBotones.Aceptar)
        End Try

    End Sub


    Private Sub enviarDatosProveedor(nombre As String, opcion As Integer)

        '--- CÓDIGO CORRECTO ---
        Dim repositorio As New Repositorio_Proveedor()
        Dim nombreProveedor As String = nombre ' Asumiendo que 'cedula' es un TextBox
        Dim texto As String = String.Empty

        ' 1. Llama a la función y guarda el resultado en una lista.
        Dim listaResultados As IEnumerable(Of VProveedor) = repositorio.GetAllByNombre(nombreProveedor)

        ' 2. Selecciona el PRIMER resultado de la lista y guárdalo en tu propiedad.
        '    FirstOrDefault() es seguro: si no encuentra nada, asigna 'Nothing'.
        Try
            Me.ProveedorEncontrado = listaResultados.FirstOrDefault()

            ' 3. Comprueba si se encontró un empleado antes de continuar.
            If Me.ProveedorEncontrado IsNot Nothing Then
                ' 4. Ahora puedes pasar el objeto al formulario hijo.
                Dim formularioHijo As New frmProveedor()
                formularioHijo.DatosProveedor = Me.ProveedorEncontrado
                Select Case opcion
                    Case 0
                        texto = "Actualizar..."
                    Case 1
                        texto = "Eliminar..."
                End Select
                formularioHijo.NombreBoton = texto

                ' 🔹 Aquí conectas el evento de cierre del hijo con la acción del principal
                AddHandler formularioHijo.CerrarProveedor, Sub()
                                                               btnSalirFrmHijo.Visible = False
                                                           End Sub

                ' 🔹 Abres el hijo
                OpenChildForm(formularioHijo)

                ' 🔹 Al abrirlo, muestras el botón salir
                btnSalirFrmHijo.Visible = True
            Else
                MessageBoxUI.Mostrar("Datos no existe...",
                                     "No hay ningún proveedor con ese nombre, por favor verifique bien los datos",
                                     MessageBoxUI.TipoMensaje.Advertencia,
                                     MessageBoxUI.TipoBotones.Aceptar)
            End If
        Catch ex As Exception
            MessageBoxUI.Mostrar("Error",
                                 "Ocurrió un error al buscar el proveedor. Por favor, intente nuevamente. " & ex.Message,
                                 MessageBoxUI.TipoMensaje.Errorr,
                                 MessageBoxUI.TipoBotones.Aceptar)
        End Try


    End Sub

    Private Sub enviarDatosCompra(id As Integer, opcion As Integer)

        Dim repositorio As New Repositorio_Compra()
        Dim Ident As Integer = id
        Dim texto As String = String.Empty

        ' GetById devuelve UN SOLO TCompra, no una lista
        Try
            Me.CompraEncontrado = repositorio.GetById(Ident)

            If Me.CompraEncontrado IsNot Nothing Then
                Dim formularioHijo As New frmCompras()
                formularioHijo.DatosCompra = Me.CompraEncontrado

                Select Case opcion
                    Case 0
                        texto = "Actualizar..."
                    Case 1
                        texto = "Eliminar..."
                End Select

                formularioHijo.NombreBoton = texto
                OpenChildForm(formularioHijo)
            Else
                MessageBoxUI.Mostrar("Datos inexistentes...",
                                     "No hay ninguna compra con ese número de identificador, por favor verifique bien los datos",
                                     MessageBoxUI.TipoMensaje.Advertencia,
                                     MessageBoxUI.TipoBotones.Aceptar)
            End If
        Catch ex As Exception
            MessageBoxUI.Mostrar("Error",
                                "Ocurrió un error al buscar la compra. Por favor, intente nuevamente. " & ex.Message,
                                MessageBoxUI.TipoMensaje.Errorr,
                                MessageBoxUI.TipoBotones.Aceptar)
        End Try

    End Sub

    Private Sub ActualizarEliminarCompra(opcion As Integer)
        CerrarDrawer()

        Dim overlay As New FondoOverlayUI()
        overlay.Show()
        Dim resultado = InputBoxUI.Mostrar(
            titulo:="Ingrese el Id de la Compra",
            placeholder:="1009",
            tipoDato:=InputBoxUI.TipoValidacion.Numero,
            icono:=FontAwesome.Sharp.IconChar.CartShopping,
            obligatorio:=True
        )
        overlay.Close()
        'EfectoBotonInActivo()
        Try
            If resultado.Aceptado Then

                Dim idCompra As Integer
                If Not Integer.TryParse(resultado.Valor, idCompra) Then
                    MessageBoxUI.Mostrar("Entrada inválida",
                                         "Por favor, ingrese un número válido para el Id de la Compra.",
                                         MessageBoxUI.TipoMensaje.Advertencia,
                                         MessageBoxUI.TipoBotones.Aceptar)
                    Exit Sub
                End If

                enviarDatosCompra(idCompra, opcion)
            Else
                MessageBoxUI.Mostrar("Cerrar...",
                                     "Saliendo de control de entrada de datos",
                                     MessageBoxUI.TipoMensaje.Advertencia,
                                     MessageBoxUI.TipoBotones.Aceptar)
            End If
        Catch ex As Exception
            MessageBoxUI.Mostrar("Error",
                                 "Ocurrió un error al procesar la entrada. Por favor, intente nuevamente. " & ex.Message,
                                 MessageBoxUI.TipoMensaje.Errorr,
                                 MessageBoxUI.TipoBotones.Aceptar)
        End Try

        DrawerTimer.Start()
    End Sub

#End Region

End Class