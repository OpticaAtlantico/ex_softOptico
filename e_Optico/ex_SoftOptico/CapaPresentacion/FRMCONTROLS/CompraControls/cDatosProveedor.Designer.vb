<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cDatosProveedor
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        tlpFooter = New TableLayoutPanel()
        Panel5 = New Panel()
        btnSiguiente = New CommandButtonUI()
        CommandButtonui2 = New CommandButtonUI()
        Panel4 = New Panel()
        CommandButtonui1 = New CommandButtonUI()
        tlpContenido = New TableLayoutPanel()
        Panelui1 = New PanelUI()
        cmbSucursal = New ComboBoxLayoutUI()
        txtnControl = New TextOnlyTextBoxLabelUI()
        txtnFactura = New TextOnlyTextBoxLabelUI()
        txtFechaEmision = New DatePickerProUI()
        txtRif = New TextOnlyTextBoxLabelUI()
        TextOnlyTextBoxLabelui4 = New TextOnlyTextBoxLabelUI()
        cmbFormaPago = New ComboBoxLayoutUI()
        txtDomicilio = New MultilineTextBoxLabelUI()
        Panel1 = New Panel()
        Panel2 = New Panel()
        Panel3 = New Panel()
        cmbProveedor = New ComboBoxLayoutUI()
        btnCrearProveedor = New FontAwesome.Sharp.IconButton()
        txtObservacion = New MultilineTextBoxLabelUI()
        tlpFooter.SuspendLayout()
        Panel5.SuspendLayout()
        Panel4.SuspendLayout()
        tlpContenido.SuspendLayout()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' tlpFooter
        ' 
        tlpFooter.BackColor = Color.LightSkyBlue
        tlpFooter.ColumnCount = 2
        tlpFooter.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpFooter.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpFooter.Controls.Add(Panel5, 1, 0)
        tlpFooter.Controls.Add(Panel4, 0, 0)
        tlpFooter.Dock = DockStyle.Bottom
        tlpFooter.Location = New Point(0, 501)
        tlpFooter.Name = "tlpFooter"
        tlpFooter.RowCount = 1
        tlpFooter.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        tlpFooter.Size = New Size(1175, 66)
        tlpFooter.TabIndex = 5
        ' 
        ' Panel5
        ' 
        Panel5.Controls.Add(btnSiguiente)
        Panel5.Controls.Add(CommandButtonui2)
        Panel5.Dock = DockStyle.Fill
        Panel5.Location = New Point(590, 3)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(582, 60)
        Panel5.TabIndex = 15
        ' 
        ' btnSiguiente
        ' 
        btnSiguiente.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnSiguiente.AnimarHover = True
        btnSiguiente.BackColor = Color.Transparent
        btnSiguiente.ColorBase = Color.FromArgb(CByte(33), CByte(150), CByte(243))
        btnSiguiente.ColorHover = Color.FromArgb(CByte(30), CByte(136), CByte(229))
        btnSiguiente.ColorInternoFondo = Color.FromArgb(CByte(33), CByte(150), CByte(243))
        btnSiguiente.ColorPresionado = Color.FromArgb(CByte(25), CByte(118), CByte(210))
        btnSiguiente.ColorTexto = Color.WhiteSmoke
        btnSiguiente.EstiloBoton = CommandButtonUI.EstiloBootstrap.Primary
        btnSiguiente.Font = New Font("Century Gothic", 10F, FontStyle.Bold)
        btnSiguiente.Icono = FontAwesome.Sharp.IconChar.CircleRight
        btnSiguiente.Location = New Point(708, 8)
        btnSiguiente.Name = "btnSiguiente"
        btnSiguiente.RadioBorde = 8
        btnSiguiente.Size = New Size(200, 44)
        btnSiguiente.TabIndex = 2
        btnSiguiente.Text = "CommandButtonui1"
        btnSiguiente.Texto = "Siguiente..."
        ' 
        ' CommandButtonui2
        ' 
        CommandButtonui2.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        CommandButtonui2.AnimarHover = True
        CommandButtonui2.BackColor = Color.Transparent
        CommandButtonui2.ColorBase = Color.FromArgb(CByte(33), CByte(150), CByte(243))
        CommandButtonui2.ColorHover = Color.FromArgb(CByte(30), CByte(136), CByte(229))
        CommandButtonui2.ColorInternoFondo = Color.FromArgb(CByte(33), CByte(150), CByte(243))
        CommandButtonui2.ColorPresionado = Color.FromArgb(CByte(25), CByte(118), CByte(210))
        CommandButtonui2.ColorTexto = Color.WhiteSmoke
        CommandButtonui2.EstiloBoton = CommandButtonUI.EstiloBootstrap.Primary
        CommandButtonui2.Font = New Font("Century Gothic", 10F, FontStyle.Bold)
        CommandButtonui2.Icono = FontAwesome.Sharp.IconChar.CircleRight
        CommandButtonui2.Location = New Point(1054, 8)
        CommandButtonui2.Name = "CommandButtonui2"
        CommandButtonui2.RadioBorde = 8
        CommandButtonui2.Size = New Size(200, 44)
        CommandButtonui2.TabIndex = 1
        CommandButtonui2.Text = "CommandButtonui1"
        CommandButtonui2.Texto = "Siguiente..."
        ' 
        ' Panel4
        ' 
        Panel4.Controls.Add(CommandButtonui1)
        Panel4.Dock = DockStyle.Fill
        Panel4.Location = New Point(3, 3)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(581, 60)
        Panel4.TabIndex = 14
        ' 
        ' CommandButtonui1
        ' 
        CommandButtonui1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        CommandButtonui1.AnimarHover = True
        CommandButtonui1.BackColor = Color.Transparent
        CommandButtonui1.ColorBase = Color.FromArgb(CByte(33), CByte(150), CByte(243))
        CommandButtonui1.ColorHover = Color.FromArgb(CByte(30), CByte(136), CByte(229))
        CommandButtonui1.ColorInternoFondo = Color.FromArgb(CByte(33), CByte(150), CByte(243))
        CommandButtonui1.ColorPresionado = Color.FromArgb(CByte(25), CByte(118), CByte(210))
        CommandButtonui1.ColorTexto = Color.WhiteSmoke
        CommandButtonui1.EstiloBoton = CommandButtonUI.EstiloBootstrap.Primary
        CommandButtonui1.Font = New Font("Century Gothic", 10F, FontStyle.Bold)
        CommandButtonui1.Icono = FontAwesome.Sharp.IconChar.CircleRight
        CommandButtonui1.Location = New Point(1053, 8)
        CommandButtonui1.Name = "CommandButtonui1"
        CommandButtonui1.RadioBorde = 8
        CommandButtonui1.Size = New Size(200, 44)
        CommandButtonui1.TabIndex = 1
        CommandButtonui1.Text = "CommandButtonui1"
        CommandButtonui1.Texto = "Siguiente..."
        ' 
        ' tlpContenido
        ' 
        tlpContenido.BackColor = Color.White
        tlpContenido.ColumnCount = 2
        tlpContenido.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpContenido.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpContenido.Controls.Add(txtObservacion, 1, 4)
        tlpContenido.Controls.Add(cmbSucursal, 0, 0)
        tlpContenido.Controls.Add(txtnControl, 1, 0)
        tlpContenido.Controls.Add(txtnFactura, 0, 1)
        tlpContenido.Controls.Add(txtFechaEmision, 1, 1)
        tlpContenido.Controls.Add(txtRif, 1, 2)
        tlpContenido.Controls.Add(TextOnlyTextBoxLabelui4, 0, 3)
        tlpContenido.Controls.Add(cmbFormaPago, 1, 3)
        tlpContenido.Controls.Add(txtDomicilio, 0, 4)
        tlpContenido.Controls.Add(Panel1, 0, 2)
        tlpContenido.Location = New Point(11, 13)
        tlpContenido.Name = "tlpContenido"
        tlpContenido.RowCount = 5
        tlpContenido.RowStyles.Add(New RowStyle(SizeType.Absolute, 80F))
        tlpContenido.RowStyles.Add(New RowStyle(SizeType.Absolute, 80F))
        tlpContenido.RowStyles.Add(New RowStyle(SizeType.Absolute, 80F))
        tlpContenido.RowStyles.Add(New RowStyle(SizeType.Absolute, 80F))
        tlpContenido.RowStyles.Add(New RowStyle(SizeType.Absolute, 50F))
        tlpContenido.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        tlpContenido.Size = New Size(1149, 432)
        tlpContenido.TabIndex = 4
        ' 
        ' Panelui1
        ' 
        Panelui1.BackColor = Color.Transparent
        Panelui1.BackColorContenedor = Color.Transparent
        Panelui1.BorderColor = Color.FromArgb(CByte(0), CByte(188), CByte(212))
        Panelui1.BorderRadius = 20
        Panelui1.BorderSize = 1
        Panelui1.CardBackColor = Color.White
        Panelui1.Estilo = PanelUI.EstiloCard.None
        Panelui1.Location = New Point(4, 7)
        Panelui1.Name = "Panelui1"
        Panelui1.ShadowColor = Color.LightGray
        Panelui1.Size = New Size(1168, 484)
        Panelui1.TabIndex = 6
        Panelui1.Texto = ""
        ' 
        ' cmbSucursal
        ' 
        cmbSucursal.BackColor = Color.Transparent
        cmbSucursal.CampoRequerido = True
        cmbSucursal.ColorTitulo = Color.DarkSlateGray
        cmbSucursal.Dock = DockStyle.Fill
        cmbSucursal.IndiceSeleccionado = -1
        cmbSucursal.Location = New Point(3, 3)
        cmbSucursal.MensajeError = "Campo requerido"
        cmbSucursal.Name = "cmbSucursal"
        cmbSucursal.Placeholder = "Selecciones la Sucursal"
        cmbSucursal.PlaceholderColor = Color.Gray
        cmbSucursal.Size = New Size(568, 74)
        cmbSucursal.TabIndex = 0
        cmbSucursal.Texto = ""
        cmbSucursal.TextoLabel = "Nombre de la Sucursal:"
        cmbSucursal.ValorSeleccionado = Nothing
        ' 
        ' txtnControl
        ' 
        txtnControl.BackColor = Color.Transparent
        txtnControl.CampoRequerido = True
        txtnControl.CapitalizarTexto = True
        txtnControl.CapitalizarTodasLasPalabras = True
        txtnControl.ColorTitulo = Color.DarkSlateGray
        txtnControl.Dock = DockStyle.Fill
        txtnControl.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtnControl.IconoDerechoChar = FontAwesome.Sharp.IconChar.Hashtag
        txtnControl.Location = New Point(577, 3)
        txtnControl.MaxCaracteres = 0
        txtnControl.MensajeError = "Campo requerido"
        txtnControl.MinCaracteres = 0
        txtnControl.Name = "txtnControl"
        txtnControl.PaddingIzquierda = 8
        txtnControl.PaddingIzquierdaIcono = 10
        txtnControl.Placeholder = "Ingrese el número de control"
        txtnControl.PlaceholderColor = Color.Gray
        txtnControl.Size = New Size(569, 74)
        txtnControl.TabIndex = 1
        txtnControl.TextoLabel = "Número de Control:"
        txtnControl.TextString = ""
        txtnControl.ValidarComoCorreo = False
        ' 
        ' txtnFactura
        ' 
        txtnFactura.BackColor = Color.Transparent
        txtnFactura.CampoRequerido = True
        txtnFactura.CapitalizarTexto = True
        txtnFactura.CapitalizarTodasLasPalabras = True
        txtnFactura.ColorTitulo = Color.DarkSlateGray
        txtnFactura.Dock = DockStyle.Fill
        txtnFactura.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtnFactura.IconoDerechoChar = FontAwesome.Sharp.IconChar.Hashtag
        txtnFactura.Location = New Point(3, 83)
        txtnFactura.MaxCaracteres = 0
        txtnFactura.MensajeError = "Campo requerido"
        txtnFactura.MinCaracteres = 0
        txtnFactura.Name = "txtnFactura"
        txtnFactura.PaddingIzquierda = 8
        txtnFactura.PaddingIzquierdaIcono = 10
        txtnFactura.Placeholder = "Ingrese numero de factura"
        txtnFactura.PlaceholderColor = Color.Gray
        txtnFactura.Size = New Size(568, 74)
        txtnFactura.TabIndex = 2
        txtnFactura.TextoLabel = "Número de Factura:"
        txtnFactura.TextString = ""
        txtnFactura.ValidarComoCorreo = False
        ' 
        ' txtFechaEmision
        ' 
        txtFechaEmision.BackColor = Color.Transparent
        txtFechaEmision.BorderColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtFechaEmision.BorderRadius = 8
        txtFechaEmision.BorderSize = 1
        txtFechaEmision.CampoRequerido = True
        txtFechaEmision.Dock = DockStyle.Fill
        txtFechaEmision.FechaSeleccionada = New Date(2025, 10, 27, 8, 17, 44, 418)
        txtFechaEmision.FontField = New Font("Century Gothic", 12F)
        txtFechaEmision.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtFechaEmision.IconoDerechoChar = FontAwesome.Sharp.IconChar.None
        txtFechaEmision.LabelColor = Color.DarkSlateGray
        txtFechaEmision.LabelText = "Fecha de emisión:"
        txtFechaEmision.Location = New Point(577, 83)
        txtFechaEmision.MensajeError = "Campo requerido"
        txtFechaEmision.Name = "txtFechaEmision"
        txtFechaEmision.PaddingAll = 10
        txtFechaEmision.PanelBackColor = Color.White
        txtFechaEmision.Size = New Size(569, 74)
        txtFechaEmision.TabIndex = 3
        txtFechaEmision.TextColor = Color.Black
        txtFechaEmision.ValorFecha = New Date(2025, 10, 27, 8, 17, 44, 418)
        ' 
        ' txtRif
        ' 
        txtRif.BackColor = Color.Transparent
        txtRif.CampoRequerido = False
        txtRif.CapitalizarTexto = False
        txtRif.CapitalizarTodasLasPalabras = False
        txtRif.ColorTitulo = Color.DarkSlateGray
        txtRif.Dock = DockStyle.Fill
        txtRif.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtRif.IconoDerechoChar = FontAwesome.Sharp.IconChar.CirclePlus
        txtRif.Location = New Point(577, 163)
        txtRif.MaxCaracteres = 0
        txtRif.MensajeError = "Este campo es requerido"
        txtRif.MinCaracteres = 0
        txtRif.Name = "txtRif"
        txtRif.PaddingIzquierda = 8
        txtRif.PaddingIzquierdaIcono = 10
        txtRif.Placeholder = "Ingrese datos"
        txtRif.PlaceholderColor = Color.Gray
        txtRif.Size = New Size(569, 74)
        txtRif.TabIndex = 5
        txtRif.TextoLabel = "Número de Rif / C.I."
        txtRif.TextString = ""
        txtRif.ValidarComoCorreo = False
        ' 
        ' TextOnlyTextBoxLabelui4
        ' 
        TextOnlyTextBoxLabelui4.BackColor = Color.Transparent
        TextOnlyTextBoxLabelui4.CampoRequerido = False
        TextOnlyTextBoxLabelui4.CapitalizarTexto = False
        TextOnlyTextBoxLabelui4.CapitalizarTodasLasPalabras = False
        TextOnlyTextBoxLabelui4.ColorTitulo = Color.DarkSlateGray
        TextOnlyTextBoxLabelui4.Dock = DockStyle.Fill
        TextOnlyTextBoxLabelui4.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        TextOnlyTextBoxLabelui4.IconoDerechoChar = FontAwesome.Sharp.IconChar.Phone
        TextOnlyTextBoxLabelui4.Location = New Point(3, 243)
        TextOnlyTextBoxLabelui4.MaxCaracteres = 0
        TextOnlyTextBoxLabelui4.MensajeError = "Este campo es requerido"
        TextOnlyTextBoxLabelui4.MinCaracteres = 0
        TextOnlyTextBoxLabelui4.Name = "TextOnlyTextBoxLabelui4"
        TextOnlyTextBoxLabelui4.PaddingIzquierda = 8
        TextOnlyTextBoxLabelui4.PaddingIzquierdaIcono = 10
        TextOnlyTextBoxLabelui4.Placeholder = "Ingrese datos"
        TextOnlyTextBoxLabelui4.PlaceholderColor = Color.Gray
        TextOnlyTextBoxLabelui4.Size = New Size(568, 74)
        TextOnlyTextBoxLabelui4.TabIndex = 6
        TextOnlyTextBoxLabelui4.TextoLabel = "Número de Teléfono:"
        TextOnlyTextBoxLabelui4.TextString = ""
        TextOnlyTextBoxLabelui4.ValidarComoCorreo = False
        ' 
        ' cmbFormaPago
        ' 
        cmbFormaPago.BackColor = Color.Transparent
        cmbFormaPago.CampoRequerido = False
        cmbFormaPago.ColorTitulo = Color.DarkSlateGray
        cmbFormaPago.Dock = DockStyle.Fill
        cmbFormaPago.IndiceSeleccionado = -1
        cmbFormaPago.Location = New Point(577, 243)
        cmbFormaPago.MensajeError = "Este campo es requerido"
        cmbFormaPago.Name = "cmbFormaPago"
        cmbFormaPago.Placeholder = "Selecciones una Opcion..."
        cmbFormaPago.PlaceholderColor = Color.Gray
        cmbFormaPago.Size = New Size(569, 74)
        cmbFormaPago.TabIndex = 7
        cmbFormaPago.Texto = ""
        cmbFormaPago.TextoLabel = "Forma de Pago:"
        cmbFormaPago.ValorSeleccionado = Nothing
        ' 
        ' txtDomicilio
        ' 
        txtDomicilio.AlturaMultilinea = 70
        txtDomicilio.BackColor = Color.Transparent
        txtDomicilio.BorderColor = Color.FromArgb(CByte(33), CByte(150), CByte(243))
        txtDomicilio.BorderRadius = 8
        txtDomicilio.BorderSize = 1
        txtDomicilio.CampoRequerido = True
        txtDomicilio.CapitalizarTexto = True
        txtDomicilio.CapitalizarTodasLasPalabras = False
        txtDomicilio.ColorError = Color.Firebrick
        txtDomicilio.Dock = DockStyle.Fill
        txtDomicilio.FontField = New Font("Century Gothic", 12F)
        txtDomicilio.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtDomicilio.IconoDerechoChar = FontAwesome.Sharp.IconChar.Building
        txtDomicilio.LabelColor = Color.DarkSlateGray
        txtDomicilio.LabelText = "Direción de Domicilio:"
        txtDomicilio.Location = New Point(3, 323)
        txtDomicilio.MensajeError = "Este campo es requerido"
        txtDomicilio.Multilinea = True
        txtDomicilio.Name = "txtDomicilio"
        txtDomicilio.PaddingAll = 10
        txtDomicilio.PanelBackColor = Color.White
        txtDomicilio.Placeholder = "Introduzca la dirección de la domicilio..."
        txtDomicilio.PlaceholderColor = Color.Gray
        txtDomicilio.Size = New Size(568, 106)
        txtDomicilio.TabIndex = 8
        txtDomicilio.TextColor = Color.Black
        txtDomicilio.TextoString = Nothing
        txtDomicilio.TextString = ""
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(Panel3)
        Panel1.Controls.Add(Panel2)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(3, 163)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(568, 74)
        Panel1.TabIndex = 10
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(cmbProveedor)
        Panel2.Dock = DockStyle.Left
        Panel2.Location = New Point(0, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(495, 74)
        Panel2.TabIndex = 0
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(btnCrearProveedor)
        Panel3.Dock = DockStyle.Fill
        Panel3.Location = New Point(495, 0)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(73, 74)
        Panel3.TabIndex = 1
        ' 
        ' cmbProveedor
        ' 
        cmbProveedor.BackColor = Color.Transparent
        cmbProveedor.CampoRequerido = True
        cmbProveedor.ColorTitulo = Color.DarkSlateGray
        cmbProveedor.Dock = DockStyle.Fill
        cmbProveedor.IndiceSeleccionado = -1
        cmbProveedor.Location = New Point(0, 0)
        cmbProveedor.MensajeError = "Campo requerido"
        cmbProveedor.Name = "cmbProveedor"
        cmbProveedor.Placeholder = "Selecciones una Opcion..."
        cmbProveedor.PlaceholderColor = Color.Gray
        cmbProveedor.Size = New Size(495, 74)
        cmbProveedor.TabIndex = 5
        cmbProveedor.Texto = ""
        cmbProveedor.TextoLabel = "Proveedor:"
        cmbProveedor.ValorSeleccionado = Nothing
        ' 
        ' btnCrearProveedor
        ' 
        btnCrearProveedor.BackColor = Color.Transparent
        btnCrearProveedor.Cursor = Cursors.Hand
        btnCrearProveedor.Dock = DockStyle.Fill
        btnCrearProveedor.FlatAppearance.BorderColor = Color.White
        btnCrearProveedor.FlatAppearance.BorderSize = 0
        btnCrearProveedor.FlatAppearance.MouseDownBackColor = Color.White
        btnCrearProveedor.FlatAppearance.MouseOverBackColor = Color.White
        btnCrearProveedor.FlatStyle = FlatStyle.Flat
        btnCrearProveedor.IconChar = FontAwesome.Sharp.IconChar.PlusSquare
        btnCrearProveedor.IconColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        btnCrearProveedor.IconFont = FontAwesome.Sharp.IconFont.Regular
        btnCrearProveedor.IconSize = 45
        btnCrearProveedor.Location = New Point(0, 0)
        btnCrearProveedor.Name = "btnCrearProveedor"
        btnCrearProveedor.Size = New Size(73, 74)
        btnCrearProveedor.TabIndex = 0
        btnCrearProveedor.TextImageRelation = TextImageRelation.ImageAboveText
        btnCrearProveedor.UseVisualStyleBackColor = False
        ' 
        ' txtObservacion
        ' 
        txtObservacion.AlturaMultilinea = 70
        txtObservacion.BackColor = Color.Transparent
        txtObservacion.BorderColor = Color.FromArgb(CByte(33), CByte(150), CByte(243))
        txtObservacion.BorderRadius = 8
        txtObservacion.BorderSize = 1
        txtObservacion.CampoRequerido = False
        txtObservacion.CapitalizarTexto = True
        txtObservacion.CapitalizarTodasLasPalabras = False
        txtObservacion.ColorError = Color.Firebrick
        txtObservacion.Dock = DockStyle.Fill
        txtObservacion.FontField = New Font("Century Gothic", 12F)
        txtObservacion.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtObservacion.IconoDerechoChar = FontAwesome.Sharp.IconChar.CircleInfo
        txtObservacion.LabelColor = Color.DarkSlateGray
        txtObservacion.LabelText = "Observación:"
        txtObservacion.Location = New Point(577, 323)
        txtObservacion.MensajeError = "Este campo es requerido"
        txtObservacion.Multilinea = True
        txtObservacion.Name = "txtObservacion"
        txtObservacion.PaddingAll = 10
        txtObservacion.PanelBackColor = Color.White
        txtObservacion.Placeholder = "Observación breve..."
        txtObservacion.PlaceholderColor = Color.Gray
        txtObservacion.Size = New Size(569, 106)
        txtObservacion.TabIndex = 11
        txtObservacion.TextColor = Color.Black
        txtObservacion.TextoString = Nothing
        txtObservacion.TextString = ""
        ' 
        ' cDatosProveedor
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.WhiteSmoke
        Controls.Add(tlpFooter)
        Controls.Add(tlpContenido)
        Controls.Add(Panelui1)
        Name = "cDatosProveedor"
        Size = New Size(1175, 567)
        tlpFooter.ResumeLayout(False)
        Panel5.ResumeLayout(False)
        Panel4.ResumeLayout(False)
        tlpContenido.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents tlpFooter As TableLayoutPanel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents btnSiguiente As CommandButtonUI
    Friend WithEvents CommandButtonui2 As CommandButtonUI
    Friend WithEvents Panel4 As Panel
    Friend WithEvents CommandButtonui1 As CommandButtonUI
    Friend WithEvents tlpContenido As TableLayoutPanel
    Friend WithEvents Panelui1 As PanelUI
    Friend WithEvents cmbSucursal As ComboBoxLayoutUI
    Friend WithEvents txtnControl As TextOnlyTextBoxLabelUI
    Friend WithEvents txtnFactura As TextOnlyTextBoxLabelUI
    Friend WithEvents txtFechaEmision As DatePickerProUI
    Friend WithEvents txtRif As TextOnlyTextBoxLabelUI
    Friend WithEvents TextOnlyTextBoxLabelui4 As TextOnlyTextBoxLabelUI
    Friend WithEvents cmbFormaPago As ComboBoxLayoutUI
    Friend WithEvents txtDomicilio As MultilineTextBoxLabelUI
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnCrearProveedor As FontAwesome.Sharp.IconButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents cmbProveedor As ComboBoxLayoutUI
    Friend WithEvents txtObservacion As MultilineTextBoxLabelUI

End Class
