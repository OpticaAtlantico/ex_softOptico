Imports System.Runtime.InteropServices
Imports CapaDatos
Imports CapaEntidad
Imports FontAwesome.Sharp

Public Class frm_Principal
    Private drawerAbierto As Boolean = False
    Private drawerControl As New DrawerControl()

    Private DrawerExpandido As Boolean = True
    Private DrawerObjetivoWidth As Integer = 160
    Private DrawerVelocidad As Integer = 30

    'Para procedimeintos de botones 
    Private currentButton As Button
    Private activeForms As Form = Nothing  ' Formulario activo
    Dim loginmodelo = listLogin

    Private fadeTimer As New Timer()
    Private fadeStep As Double = 0.05
    Public Property EmpleadoEncontrado As VEmpleados = Nothing
    Public Property ProveedorEncontrado As VProveedor = Nothing
    Public Property CompraEncontrado As VCompras = Nothing

    Public Event AbrirFormularioHijoSolicitado As Action(Of Form)
    Private formularioHijoActual As Form

#Region "CONSTRUCTOR"

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.

        InitializeComponent()
        FormStylerUI.Apply(Me)
        ' Maximizamos el formulario
        Me.WindowState = FormWindowState.Maximized
        Me.FormBorderStyle = FormBorderStyle.None

        ' Forzamos que ocupe toda la pantalla
        Me.Bounds = Screen.PrimaryScreen.Bounds
        CustomerComponent()
        pnlDrawer.BringToFront()
    End Sub

    Private Sub CustomerComponent()
        With Me
            .pnlMenu.BackColor = AppColors._cMenu1
            .pnlEncabezado.BackColor = AppColors._cFondo
            .pnlBotones.BackColor = AppColors._cFondo
            .pnlSalirfrm.BackColor = AppColors._cFondo
            'Boton regresar
            .btnSalirFrmHijo.IconColor = AppColors._cBlanco
            .btnSalirFrmHijo.BackColor = AppColors._cFondo
            'Boton para mostrar el menu
            .btnMostrarMenu.IconColor = AppColors._cHeaderTexto
            'Botones de formulario
            .btnSalir.FlatAppearance.MouseOverBackColor = AppColors._cBotonFrm
            .btnMinimizar.FlatAppearance.MouseOverBackColor = AppColors._cBotonFrm
            .btnMaximizar.FlatAppearance.MouseOverBackColor = AppColors._cBotonFrm
        End With
    End Sub

    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H2000000 ' WS_EX_COMPOSITED
            Return cp
        End Get
    End Property

#End Region

#Region "DRAG FORM"
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Integer, lParam As Integer)
    End Sub
#End Region

#Region "Formulario y botones"
    Private Sub btnSalirFrmHijo_Click(sender As Object, e As EventArgs) Handles btnSalirFrmHijo.Click
        If (Not (activeForms) Is Nothing) Then
            activeForms.Close()
            'DrawerTimer.Start()
        End If
        Reset()
    End Sub
    Private Sub pnlEncabezado_MouseDown(sender As Object, e As MouseEventArgs) Handles pnlEncabezado.MouseDown
        'Funcion para permitir mover el formulario por todas partes
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub frm_Principal_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.SuspendLayout()
        PrepararUI()

        AddHandler AbrirFormularioHijoSolicitado, AddressOf OpenChildForm
        Me.ResumeLayout()
        FadeManagerUI.StartFade(Me, 0.08)
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
            Me.WindowState = FormWindowState.Maximized
        Else
            Me.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub btnminimizar_Click(sender As Object, e As EventArgs) Handles btnMinimizar.Click
        If Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Minimized
        Else
            Me.WindowState = FormWindowState.Normal
        End If
    End Sub

#End Region

#Region "Botones menu Empleados"

    Private Sub BotonMenuEmpleados()
        ' Crear las opciones de manera clara, evitando CType de lambdas
        Dim opciones As New List(Of Tuple(Of String, IconChar, EventHandler))

        Dim handlerReporte As New EventHandler(AddressOf SubReportesE_Click)
        opciones.Add(Tuple.Create("Reportes", IconChar.ListCheck, handlerReporte))

        Dim handlerConsultar As New EventHandler(AddressOf SubConsultarE_Click)
        opciones.Add(Tuple.Create("Consultar", IconChar.ListNumeric, handlerConsultar))

        Dim handlerEliminar As New EventHandler(AddressOf SubEliminarE_Click)
        opciones.Add(Tuple.Create("Eliminar Datos", IconChar.TrashArrowUp, handlerEliminar))

        Dim handlerEditar As New EventHandler(AddressOf SubEditarE_Click)
        opciones.Add(Tuple.Create("Editar Datos", IconChar.FilePen, handlerEditar))

        Dim handlerNuevo As New EventHandler(AddressOf SubNuevoE_Click)
        opciones.Add(Tuple.Create("Nuevo Registro", IconChar.Save, handlerNuevo))

        ' Cargar en Drawer
        drawerControl.CargarOpciones(opciones)
        'pnlDrawer.Visible = True
        If pnlDrawer.Visible = False Then DrawerTimer.Start()
        'End If
        'drawerAbierto = True
    End Sub

    Private Sub SubNuevoE_Click(sender As Object, e As EventArgs)
        Me.SuspendLayout()
        Dim abierto As Boolean = Application.OpenForms().OfType(Of frmEmpleado).Any()

        CerrarDrawer()

        If Not abierto Then
            EfectoBotonInActivo()
            Dim formularioHijo As New frmEmpleado()
            formularioHijo.NombreBoton = "Guardar..."

            ' 🔹 Aquí conectas el evento de cierre del hijo con la acción del principal
            AddHandler formularioHijo.CerrarEmpleado, Sub()
                                                          btnSalirFrmHijo.Visible = False
                                                      End Sub

            ' 🔹 Abres el hijo
            OpenChildForm(formularioHijo)

            ' 🔹 Al abrirlo, muestras el botón salir
            btnSalirFrmHijo.Visible = True

        End If

        DrawerTimer.Start()
        Me.ResumeLayout()
    End Sub

    Private Sub SubEditarE_Click(sender As Object, e As EventArgs)
        Me.SuspendLayout()
        CerrarDrawer()

        Dim overlay As New FondoOverlayUI()
        overlay.Show()
        Dim resultado = InputBoxUI.Mostrar(
            titulo:="Ingrese número de cédula",
            placeholder:="12345678",
            tipoDato:=InputBoxUI.TipoValidacion.Numero,
            icono:=FontAwesome.Sharp.IconChar.UserAlt,
            obligatorio:=True
        )
        overlay.Close()
        EfectoBotonInActivo()

        If resultado.Aceptado Then
            enviarDatosEmpleados(resultado.Valor, 0)
        Else
            MessageBoxUI.Mostrar(
                                 "Cerrar...",
                                 "Saliendo de control de entrada de datos",
                                 MessageBoxUI.TipoMensaje.Advertencia,
                                 MessageBoxUI.TipoBotones.Aceptar)

        End If
        DrawerTimer.Start()
        Me.ResumeLayout()
    End Sub

    Private Sub SubEliminarE_Click(sender As Object, e As EventArgs)
        Me.SuspendLayout()
        CerrarDrawer()

        Dim overlay As New FondoOverlayUI()
        overlay.Show()
        Dim resultado = InputBoxUI.Mostrar(
            titulo:="Ingrese número de cédula",
            placeholder:="12345678",
            tipoDato:=InputBoxUI.TipoValidacion.Numero,
            icono:=FontAwesome.Sharp.IconChar.UserAlt,
            obligatorio:=True
        )
        overlay.Close()
        EfectoBotonInActivo()

        If resultado.Aceptado Then
            enviarDatosEmpleados(resultado.Valor, 1)
        Else
            MessageBoxUI.Mostrar(
                                 "Cerrar...",
                                 "Saliendo de control de entrada de datos",
                                 MessageBoxUI.TipoMensaje.Advertencia,
                                 MessageBoxUI.TipoBotones.Aceptar)
        End If
        DrawerTimer.Start()
        Me.ResumeLayout()
    End Sub

    Private Sub SubConsultarE_Click(sender As Object, e As EventArgs)
        Me.SuspendLayout()
        Dim abierto As Boolean = Application.OpenForms().OfType(Of frmConsultaEmpleados).Any()

        CerrarDrawer()

        If Not abierto Then
            EfectoBotonInActivo()
            Dim consultaEmpleadosForm As New frmConsultaEmpleados()
            AddHandler consultaEmpleadosForm.AbrirFormularioHijo, AddressOf Me.SolicitarAbrirFormularioHijo
            OpenChildForm(consultaEmpleadosForm)

        End If
        Me.ResumeLayout()
    End Sub


    Private Sub SubReportesE_Click(sender As Object, e As EventArgs)
        'MostrarContenido(New PegarControl())
        DrawerTimer.Start()
    End Sub

#End Region

#Region "Botones menu Inventario"
    Private Sub BotonMenuInventario()
        ' Crear las opciones de manera clara, evitando CType de lambdas
        Dim opciones As New List(Of Tuple(Of String, IconChar, EventHandler))

        Dim handlerReporte As New EventHandler(AddressOf SubReportesInv_Click)
        opciones.Add(Tuple.Create("Reporte", IconChar.ListCheck, handlerReporte))

        Dim handlerDevolucion As New EventHandler(AddressOf SubReportesInv_Click)
        opciones.Add(Tuple.Create("Conteo Fisico", IconChar.Refresh, handlerDevolucion))

        Dim handlerDevolucin As New EventHandler(AddressOf SubReportesInv_Click)
        opciones.Add(Tuple.Create("Ajustes", IconChar.Refresh, handlerDevolucion))

        Dim handlerDevolucio As New EventHandler(AddressOf SubReportesInv_Click)
        opciones.Add(Tuple.Create("Admin. Generos", IconChar.Refresh, handlerDevolucion))

        Dim handlerDevoluci As New EventHandler(AddressOf SubReportesInv_Click)
        opciones.Add(Tuple.Create("Admin. Grupos", IconChar.Refresh, handlerDevolucion))

        Dim handlerConsultar As New EventHandler(AddressOf SubConsultarInv_Click)
        opciones.Add(Tuple.Create("Consultas", IconChar.ListNumeric, handlerConsultar))

        Dim handlerEliminar As New EventHandler(AddressOf SubEliminarInv_Click)
        opciones.Add(Tuple.Create("Lista de Miselaneos", IconChar.TrashArrowUp, handlerEliminar))

        Dim handlerEditar As New EventHandler(AddressOf SubEditarInv_Click)
        opciones.Add(Tuple.Create("Catalogo de Cristales", IconChar.FilePen, handlerEditar))

        Dim handlerNuevo As New EventHandler(AddressOf SubNuevoInv_Click)
        opciones.Add(Tuple.Create("Catalogo de Lentes", IconChar.Save, handlerNuevo))

        ' Cargar en Drawer
        drawerControl.CargarOpciones(opciones)
        'pnlDrawer.Visible = True
        If pnlDrawer.Visible = False Then DrawerTimer.Start()
        'End If
        'drawerAbierto = True
    End Sub

    Private Sub SubReportesInv_Click(sender As Object, e As EventArgs)
        Throw New NotImplementedException()
    End Sub

    Private Sub SubConsultarInv_Click(sender As Object, e As EventArgs)
        Me.SuspendLayout()
        Dim abierto As Boolean = Application.OpenForms().OfType(Of frmConsultarCompras).Any()

        CerrarDrawer()

        If Not abierto Then
            EfectoBotonInActivo()
            Dim consultaCompraForm As New frmConsultarCompras()
            AddHandler consultaCompraForm.AbrirFormularioHijo, AddressOf Me.SolicitarAbrirFormularioHijo
            OpenChildForm(consultaCompraForm)
        End If
        Me.ResumeLayout()
    End Sub

    Private Sub SubEliminarInv_Click(sender As Object, e As EventArgs)
        ActualizarEliminarCompra(1)
    End Sub

    Private Sub SubEditarInv_Click(sender As Object, e As EventArgs)
        ActualizarEliminarCompra(0)
    End Sub

    Private Sub SubNuevoInv_Click(sender As Object, e As EventArgs)
        Dim abierto As Boolean = Application.OpenForms().OfType(Of frmCompras).Any()

        CerrarDrawer()

        If Not abierto Then
            OpenChildForm(New frmProductos)
            EfectoBotonInActivo()
        End If
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
        If pnlDrawer.Visible = False Then DrawerTimer.Start()
        'End If
        'drawerAbierto = True
    End Sub

    Private Sub SubReportesC_Click(sender As Object, e As EventArgs)
        Throw New NotImplementedException()
    End Sub

    Private Sub SubConsultarC_Click(sender As Object, e As EventArgs)
        Me.SuspendLayout()
        Dim abierto As Boolean = Application.OpenForms().OfType(Of frmConsultarCompras).Any()

        CerrarDrawer()

        If Not abierto Then
            EfectoBotonInActivo()
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
            EfectoBotonInActivo()
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
        If pnlDrawer.Visible = False Then DrawerTimer.Start()
        'End If
        'drawerAbierto = True
    End Sub

    Private Sub SubNuevoPv_Click(sender As Object, e As EventArgs)
        Dim abierto As Boolean = Application.OpenForms().OfType(Of frmProveedor).Any()

        CerrarDrawer()

        If Not abierto Then
            OpenChildForm(New frmProveedor)
            EfectoBotonInActivo()
        End If

    End Sub

    Private Sub SubEditarPv_Click(sender As Object, e As EventArgs)

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
        EfectoBotonInActivo()

        If resultado.Aceptado Then
            enviarDatosProveedor(resultado.Valor, 0)
        Else
            MessageBoxUI.Mostrar("Cerrar...", "Saliendo de control de entrada de datos",
                                 MessageBoxUI.TipoMensaje.Advertencia,
                                 MessageBoxUI.TipoBotones.Aceptar)
        End If
        DrawerTimer.Start()
    End Sub

    Private Sub SubEliminarPv_Click(sender As Object, e As EventArgs)
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
        EfectoBotonInActivo()

        If resultado.Aceptado Then
            enviarDatosProveedor(resultado.Valor, 1)
        Else
            MessageBoxUI.Mostrar("Cerrar...",
                                 "Saliendo de control de entrada de datos",
                                 MessageBoxUI.TipoMensaje.Advertencia,
                                 MessageBoxUI.TipoBotones.Aceptar)
        End If
        DrawerTimer.Start()
    End Sub

    Private Sub SubConsultarPv_Click(sender As Object, e As EventArgs)
        Dim abierto As Boolean = Application.OpenForms().OfType(Of frmConsultaProveedor).Any()

        CerrarDrawer()

        If Not abierto Then
            EfectoBotonInActivo()
            Dim consultaProveedorForm As New frmConsultaProveedor()
            AddHandler consultaProveedorForm.AbrirFormularioHijo, AddressOf Me.SolicitarAbrirFormularioHijo
            OpenChildForm(consultaProveedorForm)

        End If
    End Sub


    Private Sub SubReportesPv_Click(sender As Object, e As EventArgs)
        'MostrarContenido(New PegarControl())
        DrawerTimer.Start()
    End Sub

#End Region

#Region "Botones del Menu"

    Private Sub btnInventario_Click(sender As Object, e As EventArgs) Handles btnInventario.Click
        EfectoBotonActivo(sender)
        BotonMenuInventario()
    End Sub

    Private Sub btnVenta_Click(sender As Object, e As EventArgs) Handles btnVenta.Click
        'BotonMenuInventario()
        EfectoBotonActivo(sender)
    End Sub

    Private Sub btnCompra_Click(sender As Object, e As EventArgs) Handles btnCompra.Click
        EfectoBotonActivo(sender)
        BotonMenuCompra()
    End Sub

    Private Sub btnProveedor_Click(sender As Object, e As EventArgs) Handles btnProveedor.Click
        EfectoBotonActivo(sender)
        BotonMenuProveedor()
    End Sub

    Private Sub btnEmpleado_Click(sender As Object, e As EventArgs) Handles btnEmpleado.Click
        EfectoBotonActivo(sender)
        BotonMenuEmpleados()
    End Sub

    Private Sub btnComision_Click(sender As Object, e As EventArgs) Handles btnComision.Click
        'BotonMenuInventario()
        EfectoBotonActivo(sender)
    End Sub

    Private Sub btnNomina_Click(sender As Object, e As EventArgs) Handles btnNomina.Click
        'BotonMenuInventario()
        EfectoBotonActivo(sender)
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        'BotonMenuInventario()
        EfectoBotonActivo(sender)
    End Sub

    Private Sub btnAnalisis_Click(sender As Object, e As EventArgs) Handles btnAnalisis.Click
        'BotonMenuInventario()
        EfectoBotonActivo(sender)
    End Sub

    Private Sub btnAjustes_Click(sender As Object, e As EventArgs) Handles btnAjustes.Click
        'BotonMenuInventario()
        EfectoBotonActivo(sender)
    End Sub


#End Region

#Region "ACCIONES TIMER"

    Private Sub DrawerTimer_Tick(sender As Object, e As EventArgs) Handles DrawerTimer.Tick
        Me.SuspendLayout()
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
                pnlDrawer.Width = 0 'DrawerVelocidad
            Else
                DrawerTimer.Stop()
                pnlDrawer.Visible = False
                DrawerExpandido = False
            End If
        End If
        Me.ResumeLayout()
    End Sub

    Private Sub btnMostrarMenu_Click(sender As Object, e As EventArgs) Handles btnMostrarMenu.Click
        DrawerTimer.Start()
    End Sub


#End Region

#Region "PROCEDIMIENTO"

    Private Sub EfectoBotonActivo(sender As Object)
        EfectoBotonInActivo()
        If sender IsNot Nothing Then
            sender.BackColor = Color.White
            sender.ForeColor = Color.Black
            sender.IconColor = Color.Black
        End If
    End Sub

    Private Sub EfectoBotonInActivo()
        For Each btn In pnlMenu.Controls
            If TypeOf btn Is IconButton Then
                If btn IsNot currentButton Then
                    If CType(btn, IconButton).IconColor <> Color.WhiteSmoke Then
                        CType(btn, IconButton).IconColor = Color.WhiteSmoke
                        CType(btn, IconButton).ForeColor = Color.WhiteSmoke
                        CType(btn, IconButton).BackColor = Color.FromArgb(51, 51, 76)
                    End If
                End If
            End If
        Next
    End Sub
    Private Sub ActivateButton()
        btnSalirFrmHijo.Visible = True
    End Sub
    Private Sub DisableButton()
        btnSalirFrmHijo.Visible = False
    End Sub

    Private Sub CerrarDrawer()
        If pnlDrawer.Visible Then
            pnlDrawer.Width = 0
            drawerAbierto = False
        End If
    End Sub

    Public Sub SolicitarAbrirFormularioHijo(childForm As Form)
        RaiseEvent AbrirFormularioHijoSolicitado(childForm)
    End Sub

    Public Sub OpenChildForm(childForm As Form)
        ' Cierra el formulario hijo activo con tus efectos
        If activeForms IsNot Nothing Then
            activeForms.Close()
            ' Aquí puedes agregar efectos de fade out, blur, etc. si tienes
        End If
        ActivateButton()
        activeForms = childForm
        childForm.TopLevel = False
        childForm.FormBorderStyle = FormBorderStyle.None
        childForm.Dock = DockStyle.Fill
        pnlContenedor.Controls.Add(childForm)
        pnlContenedor.Tag = childForm
        childForm.BringToFront()

        ' Tus efectos de drawer o blur que tengas
        CerrarDrawer()

        childForm.Show()
    End Sub

    Public Sub Reset()
        currentButton = New Button()
        DisableButton()
    End Sub

    ' Aquí configuras tus controles, layout, etc.
    Private Sub PrepararUI()
        pnlDrawer.Controls.Add(drawerControl)
        pnlDrawer.BackColor = Color.Azure
        DrawerTimer.Start()
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
        EfectoBotonInActivo()
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