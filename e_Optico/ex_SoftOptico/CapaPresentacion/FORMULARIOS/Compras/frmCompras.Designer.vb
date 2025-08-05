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
        pnlDatos = New Panel()
        pnlContenidoDatos = New FlowLayoutPanel()
        txtNumeroControl = New MaskedTextBoxLabelUI()
        txtNumeroFactura = New MaskedTextBoxLabelUI()
        txtFechaEmision = New DateBoxLabelUI()
        cmbProveedor = New ComboBoxLabelUI()
        txtDomicilio = New MultilineTextBoxLabelUI()
        txtRifCI = New TextBoxLabelUI()
        txtTelefonos = New MaskedTextBoxLabelUI()
        cmbTipoPago = New ComboBoxLabelUI()
        Panel2 = New Panel()
        pnlBotones = New Panel()
        CommandButtonui5 = New CommandButtonUI()
        CommandButtonui4 = New CommandButtonUI()
        CommandButtonui3 = New CommandButtonUI()
        CommandButtonui2 = New CommandButtonUI()
        btnAceptar = New CommandButtonUI()
        pnlTitulo = New Panel()
        lblEncabezado = New HeaderUI()
        DataGridComprasui1 = New DataGridComprasUI()
        pnlContenedor.SuspendLayout()
        pnlContenedorGrid.SuspendLayout()
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
        pnlContenedor.Size = New Size(1274, 611)
        pnlContenedor.TabIndex = 0
        ' 
        ' pnlContenedorGrid
        ' 
        pnlContenedorGrid.BackColor = Color.WhiteSmoke
        pnlContenedorGrid.Controls.Add(DataGridComprasui1)
        pnlContenedorGrid.Dock = DockStyle.Fill
        pnlContenedorGrid.Location = New Point(375, 65)
        pnlContenedorGrid.Name = "pnlContenedorGrid"
        pnlContenedorGrid.Size = New Size(899, 546)
        pnlContenedorGrid.TabIndex = 2
        ' 
        ' pnlDatos
        ' 
        pnlDatos.Controls.Add(pnlContenidoDatos)
        pnlDatos.Dock = DockStyle.Left
        pnlDatos.Location = New Point(0, 65)
        pnlDatos.Name = "pnlDatos"
        pnlDatos.Padding = New Padding(10)
        pnlDatos.Size = New Size(375, 546)
        pnlDatos.TabIndex = 1
        ' 
        ' pnlContenidoDatos
        ' 
        pnlContenidoDatos.AutoScroll = True
        pnlContenidoDatos.BackColor = Color.White
        pnlContenidoDatos.Controls.Add(txtNumeroControl)
        pnlContenidoDatos.Controls.Add(txtNumeroFactura)
        pnlContenidoDatos.Controls.Add(txtFechaEmision)
        pnlContenidoDatos.Controls.Add(cmbProveedor)
        pnlContenidoDatos.Controls.Add(txtDomicilio)
        pnlContenidoDatos.Controls.Add(txtRifCI)
        pnlContenidoDatos.Controls.Add(txtTelefonos)
        pnlContenidoDatos.Controls.Add(cmbTipoPago)
        pnlContenidoDatos.Dock = DockStyle.Fill
        pnlContenidoDatos.Location = New Point(10, 10)
        pnlContenidoDatos.Name = "pnlContenidoDatos"
        pnlContenidoDatos.Size = New Size(355, 526)
        pnlContenidoDatos.TabIndex = 0
        ' 
        ' txtNumeroControl
        ' 
        txtNumeroControl.BackColor = Color.Transparent
        txtNumeroControl.BorderColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtNumeroControl.BorderRadius = 8
        txtNumeroControl.BorderSize = 1
        txtNumeroControl.CampoRequerido = True
        txtNumeroControl.ColorError = Color.Firebrick
        txtNumeroControl.FontField = New Font("Century Gothic", 12F)
        txtNumeroControl.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtNumeroControl.IconoDerechoChar = FontAwesome.Sharp.IconChar.Vcard
        txtNumeroControl.LabelColor = Color.DarkSlateGray
        txtNumeroControl.LabelText = "Número de Control:"
        txtNumeroControl.Location = New Point(3, 3)
        txtNumeroControl.MascaraPersonalizada = ""
        txtNumeroControl.MaxCaracteres = 8
        txtNumeroControl.MensajeError = "Este campo es obligatorio."
        txtNumeroControl.Name = "txtNumeroControl"
        txtNumeroControl.PaddingAll = 10
        txtNumeroControl.PanelBackColor = Color.White
        txtNumeroControl.SelectionStart = 0
        txtNumeroControl.Size = New Size(323, 82)
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
        txtNumeroFactura.Location = New Point(3, 91)
        txtNumeroFactura.MascaraPersonalizada = ""
        txtNumeroFactura.MaxCaracteres = 8
        txtNumeroFactura.MensajeError = "Este campo es obligatorio."
        txtNumeroFactura.Name = "txtNumeroFactura"
        txtNumeroFactura.PaddingAll = 10
        txtNumeroFactura.PanelBackColor = Color.White
        txtNumeroFactura.SelectionStart = 0
        txtNumeroFactura.Size = New Size(323, 82)
        txtNumeroFactura.TabIndex = 2
        txtNumeroFactura.TextColor = Color.Black
        txtNumeroFactura.TextoUsuario = ""
        txtNumeroFactura.TipoNumerico = MaskedTextBoxLabelUI.TipoEntradaNumerica.Entero
        ' 
        ' txtFechaEmision
        ' 
        txtFechaEmision.BackColor = Color.White
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
        txtFechaEmision.Location = New Point(3, 179)
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
        cmbProveedor.Location = New Point(3, 265)
        cmbProveedor.MensajeError = "Este campo es obligatorio."
        cmbProveedor.MostrarError = False
        cmbProveedor.Name = "cmbProveedor"
        cmbProveedor.RadioContornoPanel = 8
        cmbProveedor.Size = New Size(323, 80)
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
        txtDomicilio.Location = New Point(3, 351)
        txtDomicilio.MensajeError = "Este campo es obligatorio."
        txtDomicilio.Multilinea = True
        txtDomicilio.Name = "txtDomicilio"
        txtDomicilio.PaddingAll = 10
        txtDomicilio.PanelBackColor = Color.White
        txtDomicilio.Size = New Size(323, 138)
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
        txtRifCI.Location = New Point(3, 495)
        txtRifCI.MensajeError = "Este campo es obligatorio."
        txtRifCI.Name = "txtRifCI"
        txtRifCI.PaddingAll = 10
        txtRifCI.PanelBackColor = Color.White
        txtRifCI.Size = New Size(323, 80)
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
        txtTelefonos.Location = New Point(3, 581)
        txtTelefonos.MascaraPersonalizada = ""
        txtTelefonos.MaxCaracteres = 8
        txtTelefonos.MensajeError = "Este campo es obligatorio."
        txtTelefonos.Name = "txtTelefonos"
        txtTelefonos.PaddingAll = 10
        txtTelefonos.PanelBackColor = Color.White
        txtTelefonos.SelectionStart = 0
        txtTelefonos.Size = New Size(323, 82)
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
        cmbTipoPago.Location = New Point(3, 669)
        cmbTipoPago.MensajeError = "Este campo es obligatorio."
        cmbTipoPago.MostrarError = False
        cmbTipoPago.Name = "cmbTipoPago"
        cmbTipoPago.RadioContornoPanel = 8
        cmbTipoPago.Size = New Size(323, 80)
        cmbTipoPago.TabIndex = 17
        cmbTipoPago.Titulo = "Codición de Pago:"
        cmbTipoPago.ValorSeleccionado = Nothing
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
        pnlBotones.Controls.Add(CommandButtonui5)
        pnlBotones.Controls.Add(CommandButtonui4)
        pnlBotones.Controls.Add(CommandButtonui3)
        pnlBotones.Controls.Add(CommandButtonui2)
        pnlBotones.Controls.Add(btnAceptar)
        pnlBotones.Dock = DockStyle.Fill
        pnlBotones.Location = New Point(480, 0)
        pnlBotones.Name = "pnlBotones"
        pnlBotones.Size = New Size(794, 65)
        pnlBotones.TabIndex = 1
        ' 
        ' CommandButtonui5
        ' 
        CommandButtonui5.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        CommandButtonui5.AnimarHover = True
        CommandButtonui5.BackColor = Color.Transparent
        CommandButtonui5.ColorBase = Color.FromArgb(CByte(66), CByte(66), CByte(66))
        CommandButtonui5.ColorHover = Color.FromArgb(CByte(55), CByte(55), CByte(55))
        CommandButtonui5.ColorInternoFondo = Color.FromArgb(CByte(66), CByte(66), CByte(66))
        CommandButtonui5.ColorPresionado = Color.FromArgb(CByte(40), CByte(40), CByte(40))
        CommandButtonui5.ColorTexto = Color.White
        CommandButtonui5.EstiloBoton = CommandButtonUI.EstiloBootstrap.Dark
        CommandButtonui5.Font = New Font("Century Gothic", 10F, FontStyle.Bold)
        CommandButtonui5.Icono = FontAwesome.Sharp.IconChar.Moon
        CommandButtonui5.Location = New Point(138, 12)
        CommandButtonui5.Name = "CommandButtonui5"
        CommandButtonui5.RadioBorde = 8
        CommandButtonui5.Size = New Size(124, 38)
        CommandButtonui5.TabIndex = 0
        CommandButtonui5.Text = "CommandButtonui1"
        CommandButtonui5.Texto = "Aceptar"
        ' 
        ' CommandButtonui4
        ' 
        CommandButtonui4.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        CommandButtonui4.AnimarHover = True
        CommandButtonui4.BackColor = Color.Transparent
        CommandButtonui4.ColorBase = Color.FromArgb(CByte(0), CByte(188), CByte(212))
        CommandButtonui4.ColorHover = Color.FromArgb(CByte(0), CByte(172), CByte(193))
        CommandButtonui4.ColorInternoFondo = Color.FromArgb(CByte(0), CByte(188), CByte(212))
        CommandButtonui4.ColorPresionado = Color.FromArgb(CByte(0), CByte(151), CByte(167))
        CommandButtonui4.ColorTexto = Color.White
        CommandButtonui4.EstiloBoton = CommandButtonUI.EstiloBootstrap.Info
        CommandButtonui4.Font = New Font("Century Gothic", 10F, FontStyle.Bold)
        CommandButtonui4.Icono = FontAwesome.Sharp.IconChar.CircleInfo
        CommandButtonui4.Location = New Point(268, 12)
        CommandButtonui4.Name = "CommandButtonui4"
        CommandButtonui4.RadioBorde = 8
        CommandButtonui4.Size = New Size(124, 38)
        CommandButtonui4.TabIndex = 0
        CommandButtonui4.Text = "CommandButtonui1"
        CommandButtonui4.Texto = "Aceptar"
        ' 
        ' CommandButtonui3
        ' 
        CommandButtonui3.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        CommandButtonui3.AnimarHover = True
        CommandButtonui3.BackColor = Color.Transparent
        CommandButtonui3.ColorBase = Color.FromArgb(CByte(255), CByte(193), CByte(7))
        CommandButtonui3.ColorHover = Color.FromArgb(CByte(255), CByte(179), CByte(0))
        CommandButtonui3.ColorInternoFondo = Color.FromArgb(CByte(255), CByte(193), CByte(7))
        CommandButtonui3.ColorPresionado = Color.FromArgb(CByte(255), CByte(160), CByte(0))
        CommandButtonui3.ColorTexto = Color.Black
        CommandButtonui3.EstiloBoton = CommandButtonUI.EstiloBootstrap.Warning
        CommandButtonui3.Font = New Font("Century Gothic", 10F, FontStyle.Bold)
        CommandButtonui3.Icono = FontAwesome.Sharp.IconChar.Warning
        CommandButtonui3.Location = New Point(398, 12)
        CommandButtonui3.Name = "CommandButtonui3"
        CommandButtonui3.RadioBorde = 8
        CommandButtonui3.Size = New Size(124, 38)
        CommandButtonui3.TabIndex = 0
        CommandButtonui3.Text = "CommandButtonui1"
        CommandButtonui3.Texto = "Aceptar"
        ' 
        ' CommandButtonui2
        ' 
        CommandButtonui2.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        CommandButtonui2.AnimarHover = True
        CommandButtonui2.BackColor = Color.Transparent
        CommandButtonui2.ColorBase = Color.FromArgb(CByte(244), CByte(67), CByte(54))
        CommandButtonui2.ColorHover = Color.FromArgb(CByte(229), CByte(57), CByte(53))
        CommandButtonui2.ColorInternoFondo = Color.FromArgb(CByte(244), CByte(67), CByte(54))
        CommandButtonui2.ColorPresionado = Color.FromArgb(CByte(211), CByte(47), CByte(47))
        CommandButtonui2.ColorTexto = Color.White
        CommandButtonui2.EstiloBoton = CommandButtonUI.EstiloBootstrap.Danger
        CommandButtonui2.Font = New Font("Century Gothic", 10F, FontStyle.Bold)
        CommandButtonui2.Icono = FontAwesome.Sharp.IconChar.TrashAlt
        CommandButtonui2.Location = New Point(528, 12)
        CommandButtonui2.Name = "CommandButtonui2"
        CommandButtonui2.RadioBorde = 8
        CommandButtonui2.Size = New Size(124, 38)
        CommandButtonui2.TabIndex = 0
        CommandButtonui2.Text = "CommandButtonui1"
        CommandButtonui2.Texto = "Aceptar"
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
        btnAceptar.Icono = FontAwesome.Sharp.IconChar.CheckCircle
        btnAceptar.Location = New Point(658, 12)
        btnAceptar.Name = "btnAceptar"
        btnAceptar.RadioBorde = 8
        btnAceptar.Size = New Size(124, 38)
        btnAceptar.TabIndex = 0
        btnAceptar.Text = "CommandButtonui1"
        btnAceptar.Texto = "Aceptar"
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
        ' DataGridComprasui1
        ' 
        DataGridComprasui1.Location = New Point(6, 101)
        DataGridComprasui1.Name = "DataGridComprasui1"
        DataGridComprasui1.Size = New Size(631, 286)
        DataGridComprasui1.TabIndex = 0
        ' 
        ' frmCompras
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1274, 611)
        Controls.Add(pnlContenedor)
        Name = "frmCompras"
        Text = "frmCompras"
        pnlContenedor.ResumeLayout(False)
        pnlContenedorGrid.ResumeLayout(False)
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
    Friend WithEvents CommandButtonui5 As CommandButtonUI
    Friend WithEvents CommandButtonui4 As CommandButtonUI
    Friend WithEvents CommandButtonui3 As CommandButtonUI
    Friend WithEvents CommandButtonui2 As CommandButtonUI
    Friend WithEvents btnAceptar As CommandButtonUI
    Friend WithEvents lblEncabezado As HeaderUI
    Friend WithEvents DataGridComprasui1 As DataGridComprasUI

End Class
