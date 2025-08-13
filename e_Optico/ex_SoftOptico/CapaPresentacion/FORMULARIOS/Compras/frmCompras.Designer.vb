<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCompras
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        pnlContenedor = New Panel()
        pnlContenedorGrid = New Panel()
        pnlDataGrid = New Panel()
        pnlTotales = New Panel()
        lblTotalGeneral = New Label()
        Label4 = New Label()
        lblIva = New Label()
        lblTextoIva = New Label()
        lblBaseImponible = New Label()
        Label2 = New Label()
        lblExento = New Label()
        Label1 = New Label()
        btnAgregarProducto = New CommandButtonUI()
        pnlDatos = New Panel()
        pnlContenidoDatos = New FlowLayoutPanel()
        cmbSucursal = New ComboBoxLabelUI()
        txtNumeroControl = New MaskedTextBoxLabelUI()
        txtNumeroFactura = New MaskedTextBoxLabelUI()
        txtFechaEmision = New DateBoxLabelUI()
        cmbProveedor = New ComboBoxLabelUI()
        txtDomicilio = New MultilineTextBoxLabelUI()
        txtRifCI = New TextBoxLabelUI()
        txtTelefonos = New MaskedTextBoxLabelUI()
        cmbTipoPago = New ComboBoxLabelUI()
        txtObservacion = New MultilineTextBoxLabelUI()
        Panel2 = New Panel()
        pnlBotones = New Panel()
        btnLimpiarCeldas = New CommandButtonUI()
        btnLimpiarGrid = New CommandButtonUI()
        btnExportarPdf = New CommandButtonUI()
        btnExportarExcel = New CommandButtonUI()
        btnAceptar = New CommandButtonUI()
        pnlTitulo = New Panel()
        lblEncabezado = New HeaderUI()
        btnSiguiente = New CommandButtonUI()
        pnlContenedor.SuspendLayout()
        pnlContenedorGrid.SuspendLayout()
        pnlTotales.SuspendLayout()
        pnlDatos.SuspendLayout()
        pnlContenidoDatos.SuspendLayout()
        Panel2.SuspendLayout()
        pnlBotones.SuspendLayout()
        pnlTitulo.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlContenedor
        ' 
        pnlContenedor.BackColor = Color.White
        pnlContenedor.Controls.Add(pnlContenedorGrid)
        pnlContenedor.Controls.Add(pnlDatos)
        pnlContenedor.Controls.Add(Panel2)
        pnlContenedor.Dock = DockStyle.Fill
        pnlContenedor.Location = New Point(0, 0)
        pnlContenedor.Name = "pnlContenedor"
        pnlContenedor.Size = New Size(1274, 626)
        pnlContenedor.TabIndex = 0
        ' 
        ' pnlContenedorGrid
        ' 
        pnlContenedorGrid.BackColor = Color.WhiteSmoke
        pnlContenedorGrid.Controls.Add(pnlDataGrid)
        pnlContenedorGrid.Controls.Add(pnlTotales)
        pnlContenedorGrid.Dock = DockStyle.Fill
        pnlContenedorGrid.Location = New Point(375, 65)
        pnlContenedorGrid.Name = "pnlContenedorGrid"
        pnlContenedorGrid.Size = New Size(899, 561)
        pnlContenedorGrid.TabIndex = 2
        ' 
        ' pnlDataGrid
        ' 
        pnlDataGrid.BackColor = Color.White
        pnlDataGrid.Dock = DockStyle.Fill
        pnlDataGrid.Location = New Point(0, 113)
        pnlDataGrid.Name = "pnlDataGrid"
        pnlDataGrid.Padding = New Padding(20, 0, 20, 20)
        pnlDataGrid.Size = New Size(899, 448)
        pnlDataGrid.TabIndex = 1
        ' 
        ' pnlTotales
        ' 
        pnlTotales.BackColor = Color.White
        pnlTotales.Controls.Add(btnLimpiarGrid)
        pnlTotales.Controls.Add(lblTotalGeneral)
        pnlTotales.Controls.Add(Label4)
        pnlTotales.Controls.Add(lblIva)
        pnlTotales.Controls.Add(lblTextoIva)
        pnlTotales.Controls.Add(lblBaseImponible)
        pnlTotales.Controls.Add(Label2)
        pnlTotales.Controls.Add(lblExento)
        pnlTotales.Controls.Add(Label1)
        pnlTotales.Controls.Add(btnAgregarProducto)
        pnlTotales.Dock = DockStyle.Top
        pnlTotales.Location = New Point(0, 0)
        pnlTotales.Name = "pnlTotales"
        pnlTotales.Padding = New Padding(20, 0, 20, 0)
        pnlTotales.Size = New Size(899, 113)
        pnlTotales.TabIndex = 0
        ' 
        ' lblTotalGeneral
        ' 
        lblTotalGeneral.AutoSize = True
        lblTotalGeneral.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold)
        lblTotalGeneral.Location = New Point(707, 84)
        lblTotalGeneral.Name = "lblTotalGeneral"
        lblTotalGeneral.Size = New Size(32, 16)
        lblTotalGeneral.TabIndex = 1
        lblTotalGeneral.Text = "0.00"
        lblTotalGeneral.TextAlign = ContentAlignment.TopRight
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(600, 84)
        Label4.Name = "Label4"
        Label4.Size = New Size(98, 17)
        Label4.TabIndex = 1
        Label4.Text = "Total General:"
        Label4.TextAlign = ContentAlignment.TopRight
        ' 
        ' lblIva
        ' 
        lblIva.AutoSize = True
        lblIva.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold)
        lblIva.Location = New Point(707, 59)
        lblIva.Name = "lblIva"
        lblIva.Size = New Size(32, 16)
        lblIva.TabIndex = 1
        lblIva.Text = "0.00"
        lblIva.TextAlign = ContentAlignment.TopRight
        ' 
        ' lblTextoIva
        ' 
        lblTextoIva.AutoSize = True
        lblTextoIva.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblTextoIva.Location = New Point(628, 59)
        lblTextoIva.Name = "lblTextoIva"
        lblTextoIva.RightToLeft = RightToLeft.No
        lblTextoIva.Size = New Size(70, 17)
        lblTextoIva.TabIndex = 1
        lblTextoIva.Text = "IVA (16%):"
        lblTextoIva.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' lblBaseImponible
        ' 
        lblBaseImponible.AutoSize = True
        lblBaseImponible.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold)
        lblBaseImponible.Location = New Point(707, 34)
        lblBaseImponible.Name = "lblBaseImponible"
        lblBaseImponible.Size = New Size(32, 16)
        lblBaseImponible.TabIndex = 1
        lblBaseImponible.Text = "0.00"
        lblBaseImponible.TextAlign = ContentAlignment.TopRight
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(588, 34)
        Label2.Name = "Label2"
        Label2.Size = New Size(110, 17)
        Label2.TabIndex = 1
        Label2.Text = "Base Imponible:"
        Label2.TextAlign = ContentAlignment.TopRight
        ' 
        ' lblExento
        ' 
        lblExento.AutoSize = True
        lblExento.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold)
        lblExento.Location = New Point(707, 9)
        lblExento.Name = "lblExento"
        lblExento.Size = New Size(32, 16)
        lblExento.TabIndex = 1
        lblExento.Text = "0.00"
        lblExento.TextAlign = ContentAlignment.TopRight
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(608, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(90, 17)
        Label1.TabIndex = 1
        Label1.Text = "Total Exento:"
        Label1.TextAlign = ContentAlignment.TopRight
        ' 
        ' btnAgregarProducto
        ' 
        btnAgregarProducto.AnimarHover = True
        btnAgregarProducto.BackColor = Color.Transparent
        btnAgregarProducto.ColorBase = Color.FromArgb(CByte(33), CByte(150), CByte(243))
        btnAgregarProducto.ColorHover = Color.FromArgb(CByte(30), CByte(136), CByte(229))
        btnAgregarProducto.ColorInternoFondo = Color.FromArgb(CByte(33), CByte(150), CByte(243))
        btnAgregarProducto.ColorPresionado = Color.FromArgb(CByte(25), CByte(118), CByte(210))
        btnAgregarProducto.ColorTexto = Color.White
        btnAgregarProducto.EstiloBoton = CommandButtonUI.EstiloBootstrap.Primary
        btnAgregarProducto.Font = New Font("Century Gothic", 10F, FontStyle.Bold)
        btnAgregarProducto.Icono = FontAwesome.Sharp.IconChar.PlusSquare
        btnAgregarProducto.Location = New Point(23, 67)
        btnAgregarProducto.Name = "btnAgregarProducto"
        btnAgregarProducto.RadioBorde = 8
        btnAgregarProducto.Size = New Size(176, 40)
        btnAgregarProducto.TabIndex = 0
        btnAgregarProducto.Text = "CommandButtonui1"
        btnAgregarProducto.Texto = "Agregar producto"
        ' 
        ' pnlDatos
        ' 
        pnlDatos.BackColor = Color.WhiteSmoke
        pnlDatos.BorderStyle = BorderStyle.FixedSingle
        pnlDatos.Controls.Add(pnlContenidoDatos)
        pnlDatos.Dock = DockStyle.Left
        pnlDatos.Location = New Point(0, 65)
        pnlDatos.Name = "pnlDatos"
        pnlDatos.Padding = New Padding(10)
        pnlDatos.Size = New Size(375, 561)
        pnlDatos.TabIndex = 1
        ' 
        ' pnlContenidoDatos
        ' 
        pnlContenidoDatos.AutoScroll = True
        pnlContenidoDatos.BackColor = Color.Transparent
        pnlContenidoDatos.Controls.Add(cmbSucursal)
        pnlContenidoDatos.Controls.Add(txtNumeroControl)
        pnlContenidoDatos.Controls.Add(txtNumeroFactura)
        pnlContenidoDatos.Controls.Add(txtFechaEmision)
        pnlContenidoDatos.Controls.Add(cmbProveedor)
        pnlContenidoDatos.Controls.Add(txtDomicilio)
        pnlContenidoDatos.Controls.Add(txtRifCI)
        pnlContenidoDatos.Controls.Add(txtTelefonos)
        pnlContenidoDatos.Controls.Add(cmbTipoPago)
        pnlContenidoDatos.Controls.Add(txtObservacion)
        pnlContenidoDatos.Controls.Add(btnLimpiarCeldas)
        pnlContenidoDatos.Controls.Add(btnSiguiente)
        pnlContenidoDatos.Dock = DockStyle.Fill
        pnlContenidoDatos.Location = New Point(10, 10)
        pnlContenidoDatos.Name = "pnlContenidoDatos"
        pnlContenidoDatos.Size = New Size(353, 539)
        pnlContenidoDatos.TabIndex = 0
        ' 
        ' cmbSucursal
        ' 
        cmbSucursal.BackColor = Color.Transparent
        cmbSucursal.BackColorPnl = Color.WhiteSmoke
        cmbSucursal.BorderColor = Color.LightGray
        cmbSucursal.BorderSize = 1
        cmbSucursal.CampoRequerido = True
        cmbSucursal.ForeColor = Color.Black
        cmbSucursal.IndiceSeleccionado = -1
        cmbSucursal.LabelColor = Color.DarkSlateGray
        cmbSucursal.Location = New Point(3, 3)
        cmbSucursal.MensajeError = "Este campo es obligatorio."
        cmbSucursal.MostrarError = False
        cmbSucursal.Name = "cmbSucursal"
        cmbSucursal.RadioContornoPanel = 8
        cmbSucursal.Size = New Size(323, 80)
        cmbSucursal.SombraBackColor = Color.LightGray
        cmbSucursal.TabIndex = 10
        cmbSucursal.Titulo = "Selecciona la Óptica:"
        cmbSucursal.ValorSeleccionado = Nothing
        ' 
        ' txtNumeroControl
        ' 
        txtNumeroControl.BackColor = Color.Transparent
        txtNumeroControl.BorderColor = Color.FromArgb(CByte(53), CByte(103), CByte(208))
        txtNumeroControl.BorderRadius = 8
        txtNumeroControl.BorderSize = 1
        txtNumeroControl.CampoRequerido = True
        txtNumeroControl.ColorError = Color.Firebrick
        txtNumeroControl.FontField = New Font("Century Gothic", 12F)
        txtNumeroControl.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtNumeroControl.IconoDerechoChar = FontAwesome.Sharp.IconChar.Vcard
        txtNumeroControl.LabelColor = Color.DarkSlateGray
        txtNumeroControl.LabelText = "Número de Control:"
        txtNumeroControl.Location = New Point(3, 89)
        txtNumeroControl.MascaraPersonalizada = ""
        txtNumeroControl.MaxCaracteres = 8
        txtNumeroControl.MensajeError = "Este campo es obligatorio."
        txtNumeroControl.Name = "txtNumeroControl"
        txtNumeroControl.PaddingAll = 10
        txtNumeroControl.PanelBackColor = Color.White
        txtNumeroControl.SelectionStart = 0
        txtNumeroControl.Size = New Size(323, 82)
        txtNumeroControl.SombraBackColor = Color.LightGray
        txtNumeroControl.TabIndex = 2
        txtNumeroControl.TextColor = Color.Black
        txtNumeroControl.TextoUsuario = ""
        txtNumeroControl.TipoNumerico = MaskedTextBoxLabelUI.TipoEntradaNumerica.Entero
        ' 
        ' txtNumeroFactura
        ' 
        txtNumeroFactura.BackColor = Color.Transparent
        txtNumeroFactura.BorderColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtNumeroFactura.BorderRadius = 8
        txtNumeroFactura.BorderSize = 1
        txtNumeroFactura.CampoRequerido = True
        txtNumeroFactura.ColorError = Color.Firebrick
        txtNumeroFactura.FontField = New Font("Century Gothic", 12F)
        txtNumeroFactura.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtNumeroFactura.IconoDerechoChar = FontAwesome.Sharp.IconChar.Vcard
        txtNumeroFactura.LabelColor = Color.DarkSlateGray
        txtNumeroFactura.LabelText = "Número de Factura:"
        txtNumeroFactura.Location = New Point(3, 177)
        txtNumeroFactura.MascaraPersonalizada = ""
        txtNumeroFactura.MaxCaracteres = 8
        txtNumeroFactura.MensajeError = "Este campo es obligatorio."
        txtNumeroFactura.Name = "txtNumeroFactura"
        txtNumeroFactura.PaddingAll = 10
        txtNumeroFactura.PanelBackColor = Color.White
        txtNumeroFactura.SelectionStart = 0
        txtNumeroFactura.Size = New Size(323, 82)
        txtNumeroFactura.SombraBackColor = Color.LightGray
        txtNumeroFactura.TabIndex = 2
        txtNumeroFactura.TextColor = Color.Black
        txtNumeroFactura.TextoUsuario = ""
        txtNumeroFactura.TipoNumerico = MaskedTextBoxLabelUI.TipoEntradaNumerica.Entero
        ' 
        ' txtFechaEmision
        ' 
        txtFechaEmision.BackColor = Color.Transparent
        txtFechaEmision.BorderColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtFechaEmision.BorderRadius = 8
        txtFechaEmision.BorderSize = 1
        txtFechaEmision.CampoRequerido = True
        txtFechaEmision.FechaSeleccionada = New Date(2025, 7, 31, 0, 0, 0, 0)
        txtFechaEmision.FontField = New Font("Century Gothic", 12F)
        txtFechaEmision.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtFechaEmision.IconoDerechoChar = FontAwesome.Sharp.IconChar.CalendarDays
        txtFechaEmision.LabelColor = Color.DarkSlateGray
        txtFechaEmision.LabelText = "Fecha de emisión:"
        txtFechaEmision.Location = New Point(3, 265)
        txtFechaEmision.MensajeError = "Fecha requerida o inválida."
        txtFechaEmision.Name = "txtFechaEmision"
        txtFechaEmision.PaddingAll = 10
        txtFechaEmision.PanelBackColor = Color.White
        txtFechaEmision.Size = New Size(323, 80)
        txtFechaEmision.TabIndex = 9
        txtFechaEmision.TextColor = Color.Black
        ' 
        ' cmbProveedor
        ' 
        cmbProveedor.BackColor = Color.Transparent
        cmbProveedor.BackColorPnl = Color.WhiteSmoke
        cmbProveedor.BorderColor = Color.LightGray
        cmbProveedor.BorderSize = 1
        cmbProveedor.CampoRequerido = True
        cmbProveedor.ForeColor = Color.Black
        cmbProveedor.IndiceSeleccionado = -1
        cmbProveedor.LabelColor = Color.DarkSlateGray
        cmbProveedor.Location = New Point(3, 351)
        cmbProveedor.MensajeError = "Este campo es obligatorio."
        cmbProveedor.MostrarError = False
        cmbProveedor.Name = "cmbProveedor"
        cmbProveedor.RadioContornoPanel = 8
        cmbProveedor.Size = New Size(323, 80)
        cmbProveedor.SombraBackColor = Color.LightGray
        cmbProveedor.TabIndex = 10
        cmbProveedor.Titulo = "Proveedor:"
        cmbProveedor.ValorSeleccionado = Nothing
        ' 
        ' txtDomicilio
        ' 
        txtDomicilio.AlturaMultilinea = 160
        txtDomicilio.BackColor = Color.Transparent
        txtDomicilio.BorderColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtDomicilio.BorderRadius = 8
        txtDomicilio.BorderSize = 1
        txtDomicilio.CampoRequerido = True
        txtDomicilio.CapitalizarTexto = True
        txtDomicilio.CapitalizarTodasLasPalabras = False
        txtDomicilio.ColorError = Color.Firebrick
        txtDomicilio.FontField = New Font("Century Gothic", 12F)
        txtDomicilio.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtDomicilio.IconoDerechoChar = FontAwesome.Sharp.IconChar.Building
        txtDomicilio.LabelColor = Color.DarkSlateGray
        txtDomicilio.LabelText = "Domicilio Fiscal:"
        txtDomicilio.Location = New Point(3, 437)
        txtDomicilio.MensajeError = "Este campo es obligatorio."
        txtDomicilio.Multilinea = True
        txtDomicilio.Name = "txtDomicilio"
        txtDomicilio.PaddingAll = 10
        txtDomicilio.PanelBackColor = Color.White
        txtDomicilio.Size = New Size(323, 138)
        txtDomicilio.SombraBackColor = Color.LightGray
        txtDomicilio.TabIndex = 14
        txtDomicilio.TextColor = Color.Black
        txtDomicilio.TextoUsuario = ""
        ' 
        ' txtRifCI
        ' 
        txtRifCI.BackColor = Color.Transparent
        txtRifCI.BorderColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtRifCI.BorderRadius = 8
        txtRifCI.BorderSize = 1
        txtRifCI.CampoRequerido = True
        txtRifCI.CapitalizarTexto = True
        txtRifCI.CapitalizarTodasLasPalabras = True
        txtRifCI.CaracterContraseña = "*"c
        txtRifCI.ColorError = Color.Firebrick
        txtRifCI.FontField = New Font("Century Gothic", 12F)
        txtRifCI.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtRifCI.IconoDerechoChar = FontAwesome.Sharp.IconChar.Vcard
        txtRifCI.LabelColor = Color.DarkSlateGray
        txtRifCI.LabelText = "Rif / C.I.:"
        txtRifCI.Location = New Point(3, 581)
        txtRifCI.MensajeError = "Este campo es obligatorio."
        txtRifCI.Name = "txtRifCI"
        txtRifCI.PaddingAll = 10
        txtRifCI.PanelBackColor = Color.White
        txtRifCI.Size = New Size(323, 80)
        txtRifCI.SombraBackColor = Color.LightGray
        txtRifCI.TabIndex = 15
        txtRifCI.TextColor = Color.Black
        txtRifCI.TextoUsuario = ""
        txtRifCI.UsarModoContraseña = False
        txtRifCI.ValidarComoCorreo = False
        ' 
        ' txtTelefonos
        ' 
        txtTelefonos.BackColor = Color.Transparent
        txtTelefonos.BorderColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtTelefonos.BorderRadius = 8
        txtTelefonos.BorderSize = 1
        txtTelefonos.CampoRequerido = True
        txtTelefonos.ColorError = Color.Firebrick
        txtTelefonos.FontField = New Font("Century Gothic", 12F)
        txtTelefonos.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtTelefonos.IconoDerechoChar = FontAwesome.Sharp.IconChar.Vcard
        txtTelefonos.LabelColor = Color.DarkSlateGray
        txtTelefonos.LabelText = "Telefonos contacto:"
        txtTelefonos.Location = New Point(3, 667)
        txtTelefonos.MascaraPersonalizada = ""
        txtTelefonos.MaxCaracteres = 8
        txtTelefonos.MensajeError = "Este campo es obligatorio."
        txtTelefonos.Name = "txtTelefonos"
        txtTelefonos.PaddingAll = 10
        txtTelefonos.PanelBackColor = Color.White
        txtTelefonos.SelectionStart = 0
        txtTelefonos.Size = New Size(323, 82)
        txtTelefonos.SombraBackColor = Color.LightGray
        txtTelefonos.TabIndex = 16
        txtTelefonos.TextColor = Color.Black
        txtTelefonos.TextoUsuario = ""
        txtTelefonos.TipoNumerico = MaskedTextBoxLabelUI.TipoEntradaNumerica.Entero
        ' 
        ' cmbTipoPago
        ' 
        cmbTipoPago.BackColor = Color.Transparent
        cmbTipoPago.BackColorPnl = Color.WhiteSmoke
        cmbTipoPago.BorderColor = Color.LightGray
        cmbTipoPago.BorderSize = 1
        cmbTipoPago.CampoRequerido = True
        cmbTipoPago.ForeColor = Color.Black
        cmbTipoPago.IndiceSeleccionado = -1
        cmbTipoPago.LabelColor = Color.DarkSlateGray
        cmbTipoPago.Location = New Point(3, 755)
        cmbTipoPago.MensajeError = "Este campo es obligatorio."
        cmbTipoPago.MostrarError = False
        cmbTipoPago.Name = "cmbTipoPago"
        cmbTipoPago.RadioContornoPanel = 8
        cmbTipoPago.Size = New Size(323, 80)
        cmbTipoPago.SombraBackColor = Color.LightGray
        cmbTipoPago.TabIndex = 17
        cmbTipoPago.Titulo = "Codición de Pago:"
        cmbTipoPago.ValorSeleccionado = Nothing
        ' 
        ' txtObservacion
        ' 
        txtObservacion.AlturaMultilinea = 160
        txtObservacion.BackColor = Color.Transparent
        txtObservacion.BorderColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtObservacion.BorderRadius = 8
        txtObservacion.BorderSize = 1
        txtObservacion.CampoRequerido = False
        txtObservacion.CapitalizarTexto = True
        txtObservacion.CapitalizarTodasLasPalabras = False
        txtObservacion.ColorError = Color.Firebrick
        txtObservacion.FontField = New Font("Century Gothic", 12F)
        txtObservacion.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtObservacion.IconoDerechoChar = FontAwesome.Sharp.IconChar.Building
        txtObservacion.LabelColor = Color.DarkSlateGray
        txtObservacion.LabelText = "Observacion:"
        txtObservacion.Location = New Point(3, 841)
        txtObservacion.MensajeError = "Este campo es obligatorio."
        txtObservacion.Multilinea = True
        txtObservacion.Name = "txtObservacion"
        txtObservacion.PaddingAll = 10
        txtObservacion.PanelBackColor = Color.White
        txtObservacion.Size = New Size(323, 138)
        txtObservacion.SombraBackColor = Color.LightGray
        txtObservacion.TabIndex = 14
        txtObservacion.TextColor = Color.Black
        txtObservacion.TextoUsuario = ""
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(pnlBotones)
        Panel2.Controls.Add(pnlTitulo)
        Panel2.Dock = DockStyle.Top
        Panel2.Location = New Point(0, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1274, 65)
        Panel2.TabIndex = 0
        ' 
        ' pnlBotones
        ' 
        pnlBotones.BackColor = Color.LightSkyBlue
        pnlBotones.Controls.Add(btnExportarPdf)
        pnlBotones.Controls.Add(btnExportarExcel)
        pnlBotones.Controls.Add(btnAceptar)
        pnlBotones.Dock = DockStyle.Fill
        pnlBotones.Location = New Point(480, 0)
        pnlBotones.Name = "pnlBotones"
        pnlBotones.Size = New Size(794, 65)
        pnlBotones.TabIndex = 1
        ' 
        ' btnLimpiarCeldas
        ' 
        btnLimpiarCeldas.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnLimpiarCeldas.AnimarHover = True
        btnLimpiarCeldas.BackColor = Color.Transparent
        btnLimpiarCeldas.ColorBase = Color.FromArgb(CByte(244), CByte(67), CByte(54))
        btnLimpiarCeldas.ColorHover = Color.FromArgb(CByte(229), CByte(57), CByte(53))
        btnLimpiarCeldas.ColorInternoFondo = Color.FromArgb(CByte(244), CByte(67), CByte(54))
        btnLimpiarCeldas.ColorPresionado = Color.FromArgb(CByte(211), CByte(47), CByte(47))
        btnLimpiarCeldas.ColorTexto = Color.White
        btnLimpiarCeldas.EstiloBoton = CommandButtonUI.EstiloBootstrap.Danger
        btnLimpiarCeldas.Font = New Font("Century Gothic", 10F, FontStyle.Bold)
        btnLimpiarCeldas.Icono = FontAwesome.Sharp.IconChar.Trash
        btnLimpiarCeldas.Location = New Point(3, 985)
        btnLimpiarCeldas.Name = "btnLimpiarCeldas"
        btnLimpiarCeldas.RadioBorde = 8
        btnLimpiarCeldas.Size = New Size(153, 38)
        btnLimpiarCeldas.TabIndex = 1
        btnLimpiarCeldas.Text = "CommandButtonui1"
        btnLimpiarCeldas.Texto = "Limpiar Celdas"
        ' 
        ' btnLimpiarGrid
        ' 
        btnLimpiarGrid.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnLimpiarGrid.AnimarHover = True
        btnLimpiarGrid.BackColor = Color.Transparent
        btnLimpiarGrid.ColorBase = Color.FromArgb(CByte(244), CByte(67), CByte(54))
        btnLimpiarGrid.ColorHover = Color.FromArgb(CByte(229), CByte(57), CByte(53))
        btnLimpiarGrid.ColorInternoFondo = Color.FromArgb(CByte(244), CByte(67), CByte(54))
        btnLimpiarGrid.ColorPresionado = Color.FromArgb(CByte(211), CByte(47), CByte(47))
        btnLimpiarGrid.ColorTexto = Color.White
        btnLimpiarGrid.EstiloBoton = CommandButtonUI.EstiloBootstrap.Danger
        btnLimpiarGrid.Font = New Font("Century Gothic", 10F, FontStyle.Bold)
        btnLimpiarGrid.Icono = FontAwesome.Sharp.IconChar.TrashAlt
        btnLimpiarGrid.Location = New Point(205, 67)
        btnLimpiarGrid.Name = "btnLimpiarGrid"
        btnLimpiarGrid.RadioBorde = 8
        btnLimpiarGrid.Size = New Size(153, 40)
        btnLimpiarGrid.TabIndex = 0
        btnLimpiarGrid.Text = "CommandButtonui1"
        btnLimpiarGrid.Texto = "Limpiar Grid"
        ' 
        ' btnExportarPdf
        ' 
        btnExportarPdf.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnExportarPdf.AnimarHover = True
        btnExportarPdf.BackColor = Color.Transparent
        btnExportarPdf.ColorBase = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        btnExportarPdf.ColorHover = Color.FromArgb(CByte(67), CByte(160), CByte(71))
        btnExportarPdf.ColorInternoFondo = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        btnExportarPdf.ColorPresionado = Color.FromArgb(CByte(56), CByte(142), CByte(60))
        btnExportarPdf.ColorTexto = Color.White
        btnExportarPdf.EstiloBoton = CommandButtonUI.EstiloBootstrap.Success
        btnExportarPdf.Font = New Font("Century Gothic", 10F, FontStyle.Bold)
        btnExportarPdf.Icono = FontAwesome.Sharp.IconChar.FilePdf
        btnExportarPdf.Location = New Point(334, 12)
        btnExportarPdf.Name = "btnExportarPdf"
        btnExportarPdf.RadioBorde = 8
        btnExportarPdf.Size = New Size(144, 38)
        btnExportarPdf.TabIndex = 0
        btnExportarPdf.Text = "CommandButtonui1"
        btnExportarPdf.Texto = "Ex. PDFs"
        ' 
        ' btnExportarExcel
        ' 
        btnExportarExcel.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnExportarExcel.AnimarHover = True
        btnExportarExcel.BackColor = Color.Transparent
        btnExportarExcel.ColorBase = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        btnExportarExcel.ColorHover = Color.FromArgb(CByte(67), CByte(160), CByte(71))
        btnExportarExcel.ColorInternoFondo = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        btnExportarExcel.ColorPresionado = Color.FromArgb(CByte(56), CByte(142), CByte(60))
        btnExportarExcel.ColorTexto = Color.White
        btnExportarExcel.EstiloBoton = CommandButtonUI.EstiloBootstrap.Success
        btnExportarExcel.Font = New Font("Century Gothic", 10F, FontStyle.Bold)
        btnExportarExcel.Icono = FontAwesome.Sharp.IconChar.FileExcel
        btnExportarExcel.Location = New Point(486, 12)
        btnExportarExcel.Name = "btnExportarExcel"
        btnExportarExcel.RadioBorde = 8
        btnExportarExcel.Size = New Size(144, 38)
        btnExportarExcel.TabIndex = 0
        btnExportarExcel.Text = "CommandButtonui1"
        btnExportarExcel.Texto = " Ex. Excel"
        ' 
        ' btnAceptar
        ' 
        btnAceptar.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnAceptar.AnimarHover = True
        btnAceptar.BackColor = Color.Transparent
        btnAceptar.ColorBase = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        btnAceptar.ColorHover = Color.FromArgb(CByte(67), CByte(160), CByte(71))
        btnAceptar.ColorInternoFondo = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        btnAceptar.ColorPresionado = Color.FromArgb(CByte(56), CByte(142), CByte(60))
        btnAceptar.ColorTexto = Color.White
        btnAceptar.EstiloBoton = CommandButtonUI.EstiloBootstrap.Success
        btnAceptar.Font = New Font("Century Gothic", 10F, FontStyle.Bold)
        btnAceptar.Icono = FontAwesome.Sharp.IconChar.Save
        btnAceptar.Location = New Point(638, 12)
        btnAceptar.Name = "btnAceptar"
        btnAceptar.RadioBorde = 8
        btnAceptar.Size = New Size(144, 38)
        btnAceptar.TabIndex = 0
        btnAceptar.Text = "CommandButtonui1"
        btnAceptar.Texto = "Guardar"
        ' 
        ' pnlTitulo
        ' 
        pnlTitulo.Controls.Add(lblEncabezado)
        pnlTitulo.Dock = DockStyle.Left
        pnlTitulo.Location = New Point(0, 0)
        pnlTitulo.Name = "pnlTitulo"
        pnlTitulo.Size = New Size(480, 65)
        pnlTitulo.TabIndex = 0
        ' 
        ' lblEncabezado
        ' 
        lblEncabezado.ColorFondo = Color.LightSkyBlue
        lblEncabezado.ColorTexto = Color.FromArgb(CByte(45), CByte(45), CByte(45))
        lblEncabezado.Dock = DockStyle.Fill
        lblEncabezado.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblEncabezado.Icono = FontAwesome.Sharp.IconChar.CartShopping
        lblEncabezado.Location = New Point(0, 0)
        lblEncabezado.MostrarSeparador = False
        lblEncabezado.Name = "lblEncabezado"
        lblEncabezado.Size = New Size(480, 65)
        lblEncabezado.Subtitulo = "Subtítulo opcional"
        lblEncabezado.TabIndex = 0
        lblEncabezado.Text = "Headerui1"
        lblEncabezado.Titulo = "Título Principal"
        ' 
        ' btnSiguiente
        ' 
        btnSiguiente.AnimarHover = True
        btnSiguiente.BackColor = Color.Transparent
        btnSiguiente.ColorBase = Color.FromArgb(CByte(33), CByte(150), CByte(243))
        btnSiguiente.ColorHover = Color.FromArgb(CByte(30), CByte(136), CByte(229))
        btnSiguiente.ColorInternoFondo = Color.FromArgb(CByte(33), CByte(150), CByte(243))
        btnSiguiente.ColorPresionado = Color.FromArgb(CByte(25), CByte(118), CByte(210))
        btnSiguiente.ColorTexto = Color.White
        btnSiguiente.EstiloBoton = CommandButtonUI.EstiloBootstrap.Primary
        btnSiguiente.Font = New Font("Century Gothic", 10F, FontStyle.Bold)
        btnSiguiente.Icono = FontAwesome.Sharp.IconChar.ArrowTrendDown
        btnSiguiente.Location = New Point(162, 985)
        btnSiguiente.Name = "btnSiguiente"
        btnSiguiente.RadioBorde = 8
        btnSiguiente.Size = New Size(164, 40)
        btnSiguiente.TabIndex = 20
        btnSiguiente.Text = "CommandButtonui1"
        btnSiguiente.Texto = "Siguiente"
        ' 
        ' frmCompras
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1274, 626)
        Controls.Add(pnlContenedor)
        MaximumSize = New Size(1290, 665)
        MinimumSize = New Size(1290, 665)
        Name = "frmCompras"
        Text = "frmCompras"
        pnlContenedor.ResumeLayout(False)
        pnlContenedorGrid.ResumeLayout(False)
        pnlTotales.ResumeLayout(False)
        pnlTotales.PerformLayout()
        pnlDatos.ResumeLayout(False)
        pnlContenidoDatos.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        pnlBotones.ResumeLayout(False)
        pnlTitulo.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlContenedor As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents pnlBotones As Panel
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents pnlDatos As Panel
    Friend WithEvents pnlContenedorGrid As Panel
    Friend WithEvents pnlContenidoDatos As FlowLayoutPanel
    Friend WithEvents txtNumeroControl As MaskedTextBoxLabelUI
    Friend WithEvents txtNumeroFactura As MaskedTextBoxLabelUI
    Friend WithEvents txtFechaEmision As DateBoxLabelUI
    Friend WithEvents cmbProveedor As ComboBoxLabelUI
    Friend WithEvents txtDomicilio As MultilineTextBoxLabelUI
    Friend WithEvents txtRifCI As TextBoxLabelUI
    Friend WithEvents txtTelefonos As MaskedTextBoxLabelUI
    Friend WithEvents cmbTipoPago As ComboBoxLabelUI
    Friend WithEvents btnLimpiarGrid As CommandButtonUI
    Friend WithEvents btnAceptar As CommandButtonUI
    Friend WithEvents lblEncabezado As HeaderUI
    Friend WithEvents pnlDataGrid As Panel
    Friend WithEvents pnlTotales As Panel
    Friend WithEvents btnAgregarProducto As CommandButtonUI
    Friend WithEvents Label4 As Label
    Friend WithEvents lblTextoIva As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblTotalGeneral As Label
    Friend WithEvents lblIva As Label
    Friend WithEvents lblBaseImponible As Label
    Friend WithEvents lblExento As Label
    Friend WithEvents btnLimpiarCeldas As CommandButtonUI
    Friend WithEvents btnExportarPdf As CommandButtonUI
    Friend WithEvents btnExportarExcel As CommandButtonUI
    Friend WithEvents txtObservacion As MultilineTextBoxLabelUI
    Friend WithEvents cmbSucursal As ComboBoxLabelUI
    Friend WithEvents btnSiguiente As CommandButtonUI

End Class
