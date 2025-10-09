Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ExplorerBar

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmProveedor
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        pnlContenedor = New Panel()
        pnlFoter = New Panel()
        pnlContenido = New Panel()
        txtDireccion = New MultilineTextBoxLabelUI()
        TableLayoutPanel1 = New TableLayoutPanel()
        txtTelefono = New MaskedTextBoxLabelUI()
        txtContacto = New MaskedTextBoxLabelUI()
        Panel1 = New Panel()
        txtRif = New MaskedTextBoxLabelUI()
        cmbSiglas = New ComboBoxLabelUI()
        pnlEncabezado = New Panel()
        btnAccion = New CommandButtonUI()
        lblEncabezado = New HeaderUI()
        TableLayoutPanel2 = New TableLayoutPanel()
        Panelui1 = New PanelUI()
        txtNombreEmpresa = New TextOnlyTextBoxLabelUI()
        txtRazonSocial = New TextOnlyTextBoxLabelUI()
        txtCorreo = New EmailTextBoxLabelUI()
        Panel2 = New Panel()
        TextOnlyTextBoxLabelui3 = New TextOnlyTextBoxLabelUI()
        TextOnlyTextBoxLabelui4 = New TextOnlyTextBoxLabelUI()
        Panel3 = New Panel()
        Panel4 = New Panel()
        ComboBoxLayoutui1 = New ComboBoxLayoutUI()
        ComboBoxLayoutui2 = New ComboBoxLayoutUI()
        pnlContenedor.SuspendLayout()
        pnlContenido.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        Panel1.SuspendLayout()
        pnlEncabezado.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        Panel4.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlContenedor
        ' 
        pnlContenedor.Controls.Add(pnlFoter)
        pnlContenedor.Controls.Add(pnlContenido)
        pnlContenedor.Controls.Add(pnlEncabezado)
        pnlContenedor.Dock = DockStyle.Fill
        pnlContenedor.Location = New Point(0, 0)
        pnlContenedor.Name = "pnlContenedor"
        pnlContenedor.Size = New Size(1274, 626)
        pnlContenedor.TabIndex = 0
        ' 
        ' pnlFoter
        ' 
        pnlFoter.BackColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        pnlFoter.Dock = DockStyle.Bottom
        pnlFoter.Location = New Point(0, 570)
        pnlFoter.Name = "pnlFoter"
        pnlFoter.Size = New Size(1274, 56)
        pnlFoter.TabIndex = 2
        ' 
        ' pnlContenido
        ' 
        pnlContenido.AutoScroll = True
        pnlContenido.Controls.Add(TableLayoutPanel1)
        pnlContenido.Controls.Add(TableLayoutPanel2)
        pnlContenido.Controls.Add(Panelui1)
        pnlContenido.Controls.Add(txtDireccion)
        pnlContenido.Dock = DockStyle.Fill
        pnlContenido.Location = New Point(0, 60)
        pnlContenido.Margin = New Padding(3, 30, 3, 3)
        pnlContenido.Name = "pnlContenido"
        pnlContenido.Padding = New Padding(10, 30, 0, 0)
        pnlContenido.Size = New Size(1274, 566)
        pnlContenido.TabIndex = 1
        ' 
        ' txtDireccion
        ' 
        txtDireccion.AlturaMultilinea = 41
        txtDireccion.BackColor = Color.Transparent
        txtDireccion.BorderColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtDireccion.BorderRadius = 8
        txtDireccion.BorderSize = 1
        txtDireccion.CampoRequerido = True
        txtDireccion.CapitalizarTexto = True
        txtDireccion.CapitalizarTodasLasPalabras = True
        txtDireccion.ColorError = Color.Firebrick
        txtDireccion.FontField = New Font("Century Gothic", 12F)
        txtDireccion.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtDireccion.IconoDerechoChar = FontAwesome.Sharp.IconChar.Building
        txtDireccion.LabelColor = Color.DarkSlateGray
        txtDireccion.LabelText = "Domicilio Fiscal:"
        txtDireccion.Location = New Point(12, 418)
        txtDireccion.MensajeError = "Este campo es obligatorio."
        txtDireccion.Multilinea = False
        txtDireccion.Name = "txtDireccion"
        txtDireccion.PaddingAll = 10
        txtDireccion.PanelBackColor = Color.White
        txtDireccion.Placeholder = "Escriba aquí..."
        txtDireccion.PlaceholderColor = Color.Gray
        txtDireccion.Size = New Size(1238, 86)
        txtDireccion.TabIndex = 7
        txtDireccion.TextColor = Color.Black
        txtDireccion.TextoString = Nothing
        txtDireccion.TextString = ""
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 3
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.33333F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333359F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333359F))
        TableLayoutPanel1.Controls.Add(txtTelefono, 1, 1)
        TableLayoutPanel1.Controls.Add(txtContacto, 2, 1)
        TableLayoutPanel1.Controls.Add(Panel1, 0, 1)
        TableLayoutPanel1.Location = New Point(12, 229)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 2
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 90F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 90F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel1.Size = New Size(1250, 183)
        TableLayoutPanel1.TabIndex = 26
        ' 
        ' txtTelefono
        ' 
        txtTelefono.BackColor = Color.Transparent
        txtTelefono.BorderColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtTelefono.BorderRadius = 8
        txtTelefono.BorderSize = 1
        txtTelefono.CampoRequerido = True
        txtTelefono.ColorError = Color.Firebrick
        txtTelefono.FocusColor = Color.Orange
        txtTelefono.FontField = New Font("Century Gothic", 12F)
        txtTelefono.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtTelefono.IconoDerechoChar = FontAwesome.Sharp.IconChar.PhoneVolume
        txtTelefono.LabelColor = Color.DarkSlateGray
        txtTelefono.LabelText = "Número de Teléfono:"
        txtTelefono.Location = New Point(419, 93)
        txtTelefono.MascaraPersonalizada = ""
        txtTelefono.MaxCaracteres = 0
        txtTelefono.MensajeError = "Este campo es obligatorio."
        txtTelefono.Name = "txtTelefono"
        txtTelefono.PaddingAll = 10
        txtTelefono.PanelBackColor = Color.White
        txtTelefono.SelectionStart = 0
        txtTelefono.Size = New Size(406, 80)
        txtTelefono.SombraBackColor = Color.LightGray
        txtTelefono.TabIndex = 5
        txtTelefono.TextColor = Color.Black
        txtTelefono.TextoUsuario = ""
        txtTelefono.TipoNumerico = MaskedTextBoxLabelUI.TipoEntradaNumerica.Ninguno
        ' 
        ' txtContacto
        ' 
        txtContacto.BackColor = Color.Transparent
        txtContacto.BorderColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtContacto.BorderRadius = 8
        txtContacto.BorderSize = 1
        txtContacto.CampoRequerido = True
        txtContacto.ColorError = Color.Firebrick
        txtContacto.FocusColor = Color.Orange
        txtContacto.FontField = New Font("Century Gothic", 12F)
        txtContacto.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtContacto.IconoDerechoChar = FontAwesome.Sharp.IconChar.Close
        txtContacto.LabelColor = Color.DarkSlateGray
        txtContacto.LabelText = "Teléfono Contacto Cel:"
        txtContacto.Location = New Point(835, 93)
        txtContacto.MascaraPersonalizada = ""
        txtContacto.MaxCaracteres = 0
        txtContacto.MensajeError = "Este campo es obligatorio."
        txtContacto.Name = "txtContacto"
        txtContacto.PaddingAll = 10
        txtContacto.PanelBackColor = Color.White
        txtContacto.SelectionStart = 0
        txtContacto.Size = New Size(406, 80)
        txtContacto.SombraBackColor = Color.LightGray
        txtContacto.TabIndex = 6
        txtContacto.TextColor = Color.Black
        txtContacto.TextoUsuario = ""
        txtContacto.TipoNumerico = MaskedTextBoxLabelUI.TipoEntradaNumerica.Ninguno
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(txtRif)
        Panel1.Controls.Add(cmbSiglas)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(3, 93)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(410, 87)
        Panel1.TabIndex = 6
        ' 
        ' txtRif
        ' 
        txtRif.BackColor = Color.Transparent
        txtRif.BorderColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtRif.BorderRadius = 8
        txtRif.BorderSize = 1
        txtRif.CampoRequerido = True
        txtRif.ColorError = Color.Firebrick
        txtRif.FocusColor = Color.Orange
        txtRif.FontField = New Font("Century Gothic", 12F)
        txtRif.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtRif.IconoDerechoChar = FontAwesome.Sharp.IconChar.ContactBook
        txtRif.LabelColor = Color.DarkSlateGray
        txtRif.LabelText = "Rif / C.I."
        txtRif.Location = New Point(66, 0)
        txtRif.MascaraPersonalizada = ""
        txtRif.MaxCaracteres = 0
        txtRif.MensajeError = "Este campo es obligatorio."
        txtRif.Name = "txtRif"
        txtRif.PaddingAll = 10
        txtRif.PanelBackColor = Color.White
        txtRif.SelectionStart = 0
        txtRif.Size = New Size(341, 80)
        txtRif.SombraBackColor = Color.LightGray
        txtRif.TabIndex = 4
        txtRif.TextColor = Color.Black
        txtRif.TextoUsuario = ""
        txtRif.TipoNumerico = MaskedTextBoxLabelUI.TipoEntradaNumerica.Ninguno
        ' 
        ' cmbSiglas
        ' 
        cmbSiglas.BackColor = Color.Transparent
        cmbSiglas.BackColorPnl = Color.WhiteSmoke
        cmbSiglas.BorderColor = Color.LightGray
        cmbSiglas.BorderSize = 1
        cmbSiglas.CampoRequerido = True
        cmbSiglas.ForeColor = Color.Black
        cmbSiglas.IndiceSeleccionado = -1
        cmbSiglas.LabelColor = Color.DarkSlateGray
        cmbSiglas.Location = New Point(3, -1)
        cmbSiglas.MensajeError = "Este campo es obligatorio."
        cmbSiglas.MostrarError = False
        cmbSiglas.Name = "cmbSiglas"
        cmbSiglas.RadioContornoPanel = 8
        cmbSiglas.Size = New Size(57, 80)
        cmbSiglas.SombraBackColor = Color.LightGray
        cmbSiglas.TabIndex = 3
        cmbSiglas.Titulo = "Siglas"
        cmbSiglas.ValorSeleccionado = Nothing
        ' 
        ' pnlEncabezado
        ' 
        pnlEncabezado.Controls.Add(btnAccion)
        pnlEncabezado.Controls.Add(lblEncabezado)
        pnlEncabezado.Dock = DockStyle.Top
        pnlEncabezado.Location = New Point(0, 0)
        pnlEncabezado.Name = "pnlEncabezado"
        pnlEncabezado.Size = New Size(1274, 60)
        pnlEncabezado.TabIndex = 0
        ' 
        ' btnAccion
        ' 
        btnAccion.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnAccion.AnimarHover = True
        btnAccion.BackColor = Color.FromArgb(CByte(0), CByte(192), CByte(192))
        btnAccion.ColorBase = Color.FromArgb(CByte(255), CByte(193), CByte(7))
        btnAccion.ColorHover = Color.FromArgb(CByte(255), CByte(179), CByte(0))
        btnAccion.ColorInternoFondo = Color.FromArgb(CByte(255), CByte(193), CByte(7))
        btnAccion.ColorPresionado = Color.FromArgb(CByte(255), CByte(160), CByte(0))
        btnAccion.ColorTexto = Color.WhiteSmoke
        btnAccion.EstiloBoton = CommandButtonUI.EstiloBootstrap.Warning
        btnAccion.Font = New Font("Century Gothic", 10F, FontStyle.Bold)
        btnAccion.Icono = FontAwesome.Sharp.IconChar.Warning
        btnAccion.Location = New Point(1084, 12)
        btnAccion.Name = "btnAccion"
        btnAccion.RadioBorde = 8
        btnAccion.Size = New Size(180, 40)
        btnAccion.TabIndex = 7
        btnAccion.Text = "CommandButtonui2"
        btnAccion.Texto = "Guardar Datos"
        ' 
        ' lblEncabezado
        ' 
        lblEncabezado.BackColor = Color.WhiteSmoke
        lblEncabezado.ColorFondo = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        lblEncabezado.ColorTexto = Color.WhiteSmoke
        lblEncabezado.Dimension = 12
        lblEncabezado.Dock = DockStyle.Top
        lblEncabezado.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblEncabezado.Icono = FontAwesome.Sharp.IconChar.UserPlus
        lblEncabezado.Location = New Point(0, 0)
        lblEncabezado.MostrarSeparador = True
        lblEncabezado.Name = "lblEncabezado"
        lblEncabezado.Size = New Size(1274, 60)
        lblEncabezado.Subtitulo = "Subtítulo opcional"
        lblEncabezado.TabIndex = 0
        lblEncabezado.Text = "Headerui1"
        lblEncabezado.Titulo = "Título Principal"
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 3
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.33333F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333359F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333359F))
        TableLayoutPanel2.Controls.Add(txtNombreEmpresa, 0, 0)
        TableLayoutPanel2.Controls.Add(txtRazonSocial, 1, 0)
        TableLayoutPanel2.Controls.Add(txtCorreo, 2, 0)
        TableLayoutPanel2.Controls.Add(Panel2, 0, 1)
        TableLayoutPanel2.Controls.Add(TextOnlyTextBoxLabelui3, 1, 1)
        TableLayoutPanel2.Controls.Add(TextOnlyTextBoxLabelui4, 2, 1)
        TableLayoutPanel2.Location = New Point(11, 11)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 2
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 90F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 90F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel2.Size = New Size(1250, 183)
        TableLayoutPanel2.TabIndex = 27
        ' 
        ' Panelui1
        ' 
        Panelui1.BackColor = Color.Transparent
        Panelui1.BackColorContenedor = Color.Transparent
        Panelui1.BorderColor = Color.White
        Panelui1.BorderRadius = 20
        Panelui1.BorderSize = 1
        Panelui1.CardBackColor = Color.White
        Panelui1.Estilo = PanelUI.EstiloCard.None
        Panelui1.Location = New Point(8, 7)
        Panelui1.Name = "Panelui1"
        Panelui1.ShadowColor = Color.LightGray
        Panelui1.Size = New Size(1256, 305)
        Panelui1.TabIndex = 28
        Panelui1.Texto = ""
        ' 
        ' txtNombreEmpresa
        ' 
        txtNombreEmpresa.BackColor = Color.Transparent
        txtNombreEmpresa.CampoRequerido = False
        txtNombreEmpresa.CapitalizarTexto = False
        txtNombreEmpresa.CapitalizarTodasLasPalabras = False
        txtNombreEmpresa.ColorTitulo = Color.DarkSlateGray
        txtNombreEmpresa.Dock = DockStyle.Fill
        txtNombreEmpresa.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtNombreEmpresa.IconoDerechoChar = FontAwesome.Sharp.IconChar.ContactBook
        txtNombreEmpresa.Location = New Point(3, 3)
        txtNombreEmpresa.MaxCaracteres = 0
        txtNombreEmpresa.MensajeError = "Este campo es requerido"
        txtNombreEmpresa.MinCaracteres = 0
        txtNombreEmpresa.Name = "txtNombreEmpresa"
        txtNombreEmpresa.PaddingIzquierda = 8
        txtNombreEmpresa.PaddingIzquierdaIcono = 10
        txtNombreEmpresa.Placeholder = "Ingrese datos"
        txtNombreEmpresa.PlaceholderColor = Color.Gray
        txtNombreEmpresa.Size = New Size(410, 84)
        txtNombreEmpresa.TabIndex = 0
        txtNombreEmpresa.TextoLabel = "Nombre de la Empresa:"
        txtNombreEmpresa.TextString = ""
        txtNombreEmpresa.ValidarComoCorreo = False
        ' 
        ' txtRazonSocial
        ' 
        txtRazonSocial.BackColor = Color.Transparent
        txtRazonSocial.CampoRequerido = False
        txtRazonSocial.CapitalizarTexto = False
        txtRazonSocial.CapitalizarTodasLasPalabras = False
        txtRazonSocial.ColorTitulo = Color.DarkSlateGray
        txtRazonSocial.Dock = DockStyle.Fill
        txtRazonSocial.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtRazonSocial.IconoDerechoChar = FontAwesome.Sharp.IconChar.Tag
        txtRazonSocial.Location = New Point(419, 3)
        txtRazonSocial.MaxCaracteres = 0
        txtRazonSocial.MensajeError = "Este campo es requerido"
        txtRazonSocial.MinCaracteres = 0
        txtRazonSocial.Name = "txtRazonSocial"
        txtRazonSocial.PaddingIzquierda = 8
        txtRazonSocial.PaddingIzquierdaIcono = 10
        txtRazonSocial.Placeholder = "Ingrese datos"
        txtRazonSocial.PlaceholderColor = Color.Gray
        txtRazonSocial.Size = New Size(410, 84)
        txtRazonSocial.TabIndex = 1
        txtRazonSocial.TextoLabel = "Razon Social:"
        txtRazonSocial.TextString = ""
        txtRazonSocial.ValidarComoCorreo = False
        ' 
        ' txtCorreo
        ' 
        txtCorreo.BackColor = Color.Transparent
        txtCorreo.CampoRequerido = False
        txtCorreo.CapitalizarTexto = False
        txtCorreo.CapitalizarTodasLasPalabras = False
        txtCorreo.ColorTitulo = Color.DarkSlateGray
        txtCorreo.Dock = DockStyle.Fill
        txtCorreo.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtCorreo.IconoDerechoChar = FontAwesome.Sharp.IconChar.EnvelopesBulk
        txtCorreo.Location = New Point(835, 3)
        txtCorreo.MaxCaracteres = 0
        txtCorreo.MensajeError = "Este campo es requerido"
        txtCorreo.MinCaracteres = 0
        txtCorreo.Name = "txtCorreo"
        txtCorreo.PaddingIzquierda = 8
        txtCorreo.PaddingIzquierdaIcono = 10
        txtCorreo.Placeholder = "Escriba aquí..."
        txtCorreo.PlaceholderColor = Color.Gray
        txtCorreo.Size = New Size(412, 84)
        txtCorreo.TabIndex = 2
        txtCorreo.TextoLabel = "Correo electrónico:"
        txtCorreo.TextString = ""
        txtCorreo.ValidarComoCorreo = False
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(Panel4)
        Panel2.Controls.Add(Panel3)
        Panel2.Dock = DockStyle.Fill
        Panel2.Location = New Point(3, 93)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(410, 87)
        Panel2.TabIndex = 3
        ' 
        ' TextOnlyTextBoxLabelui3
        ' 
        TextOnlyTextBoxLabelui3.BackColor = Color.Transparent
        TextOnlyTextBoxLabelui3.CampoRequerido = False
        TextOnlyTextBoxLabelui3.CapitalizarTexto = False
        TextOnlyTextBoxLabelui3.CapitalizarTodasLasPalabras = False
        TextOnlyTextBoxLabelui3.ColorTitulo = Color.DarkSlateGray
        TextOnlyTextBoxLabelui3.Dock = DockStyle.Fill
        TextOnlyTextBoxLabelui3.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        TextOnlyTextBoxLabelui3.IconoDerechoChar = FontAwesome.Sharp.IconChar.Font
        TextOnlyTextBoxLabelui3.Location = New Point(419, 93)
        TextOnlyTextBoxLabelui3.MaxCaracteres = 0
        TextOnlyTextBoxLabelui3.MensajeError = "Este campo es requerido"
        TextOnlyTextBoxLabelui3.MinCaracteres = 0
        TextOnlyTextBoxLabelui3.Name = "TextOnlyTextBoxLabelui3"
        TextOnlyTextBoxLabelui3.PaddingIzquierda = 8
        TextOnlyTextBoxLabelui3.PaddingIzquierdaIcono = 10
        TextOnlyTextBoxLabelui3.Placeholder = "Ingrese datos"
        TextOnlyTextBoxLabelui3.PlaceholderColor = Color.Gray
        TextOnlyTextBoxLabelui3.Size = New Size(410, 87)
        TextOnlyTextBoxLabelui3.TabIndex = 4
        TextOnlyTextBoxLabelui3.TextoLabel = "Texto:"
        TextOnlyTextBoxLabelui3.TextString = ""
        TextOnlyTextBoxLabelui3.ValidarComoCorreo = False
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
        TextOnlyTextBoxLabelui4.IconoDerechoChar = FontAwesome.Sharp.IconChar.Font
        TextOnlyTextBoxLabelui4.Location = New Point(835, 93)
        TextOnlyTextBoxLabelui4.MaxCaracteres = 0
        TextOnlyTextBoxLabelui4.MensajeError = "Este campo es requerido"
        TextOnlyTextBoxLabelui4.MinCaracteres = 0
        TextOnlyTextBoxLabelui4.Name = "TextOnlyTextBoxLabelui4"
        TextOnlyTextBoxLabelui4.PaddingIzquierda = 8
        TextOnlyTextBoxLabelui4.PaddingIzquierdaIcono = 10
        TextOnlyTextBoxLabelui4.Placeholder = "Ingrese datos"
        TextOnlyTextBoxLabelui4.PlaceholderColor = Color.Gray
        TextOnlyTextBoxLabelui4.Size = New Size(412, 87)
        TextOnlyTextBoxLabelui4.TabIndex = 5
        TextOnlyTextBoxLabelui4.TextoLabel = "Texto:"
        TextOnlyTextBoxLabelui4.TextString = ""
        TextOnlyTextBoxLabelui4.ValidarComoCorreo = False
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(ComboBoxLayoutui1)
        Panel3.Dock = DockStyle.Left
        Panel3.Location = New Point(0, 0)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(89, 87)
        Panel3.TabIndex = 0
        ' 
        ' Panel4
        ' 
        Panel4.Controls.Add(ComboBoxLayoutui2)
        Panel4.Dock = DockStyle.Fill
        Panel4.Location = New Point(89, 0)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(321, 87)
        Panel4.TabIndex = 1
        ' 
        ' ComboBoxLayoutui1
        ' 
        ComboBoxLayoutui1.BackColor = Color.Transparent
        ComboBoxLayoutui1.CampoRequerido = False
        ComboBoxLayoutui1.ColorTitulo = Color.DarkSlateGray
        ComboBoxLayoutui1.Dock = DockStyle.Fill
        ComboBoxLayoutui1.IndiceSeleccionado = -1
        ComboBoxLayoutui1.Location = New Point(0, 0)
        ComboBoxLayoutui1.MensajeError = "Este campo es requerido"
        ComboBoxLayoutui1.Name = "ComboBoxLayoutui1"
        ComboBoxLayoutui1.Placeholder = "Selecciones una Opcion..."
        ComboBoxLayoutui1.PlaceholderColor = Color.Gray
        ComboBoxLayoutui1.Size = New Size(89, 87)
        ComboBoxLayoutui1.TabIndex = 0
        ComboBoxLayoutui1.Texto = ""
        ComboBoxLayoutui1.TextoLabel = "Texto:"
        ComboBoxLayoutui1.ValorSeleccionado = Nothing
        ' 
        ' ComboBoxLayoutui2
        ' 
        ComboBoxLayoutui2.BackColor = Color.Transparent
        ComboBoxLayoutui2.CampoRequerido = False
        ComboBoxLayoutui2.ColorTitulo = Color.DarkSlateGray
        ComboBoxLayoutui2.Dock = DockStyle.Fill
        ComboBoxLayoutui2.IndiceSeleccionado = -1
        ComboBoxLayoutui2.Location = New Point(0, 0)
        ComboBoxLayoutui2.MensajeError = "Este campo es requerido"
        ComboBoxLayoutui2.Name = "ComboBoxLayoutui2"
        ComboBoxLayoutui2.Placeholder = "Selecciones una Opcion..."
        ComboBoxLayoutui2.PlaceholderColor = Color.Gray
        ComboBoxLayoutui2.Size = New Size(321, 87)
        ComboBoxLayoutui2.TabIndex = 0
        ComboBoxLayoutui2.Texto = ""
        ComboBoxLayoutui2.TextoLabel = "Texto:"
        ComboBoxLayoutui2.ValorSeleccionado = Nothing
        ' 
        ' frmProveedor
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1274, 626)
        Controls.Add(pnlContenedor)
        Name = "frmProveedor"
        Text = "frmProveedor"
        WindowState = FormWindowState.Maximized
        pnlContenedor.ResumeLayout(False)
        pnlContenido.ResumeLayout(False)
        TableLayoutPanel1.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        pnlEncabezado.ResumeLayout(False)
        TableLayoutPanel2.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        Panel4.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents pnlContenedor As Panel
    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents lblEncabezado As HeaderUI
    Friend WithEvents btnAccion As CommandButtonUI
    Friend WithEvents pnlContenido As Panel
    Friend WithEvents txtDireccion As MultilineTextBoxLabelUI
    Friend WithEvents txtTelefono As MaskedTextBoxLabelUI
    Friend WithEvents txtCorreo As TextBoxLabelUI
    Friend WithEvents txtRazonSocial As TextBoxLabelUI
    Friend WithEvents txtNombreEmpresa As TextBoxLabelUI
    Friend WithEvents txtRif As MaskedTextBoxLabelUI
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents txtContacto As MaskedTextBoxLabelUI
    Friend WithEvents pnlFoter As Panel
    Friend WithEvents cmbSiglas As ComboBoxLabelUI
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Panelui1 As PanelUI
    Friend WithEvents txtNombreEmpresa As TextOnlyTextBoxLabelUI
    Friend WithEvents txtRazonSocial As TextOnlyTextBoxLabelUI
    Friend WithEvents txtCorreo As EmailTextBoxLabelUI
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TextOnlyTextBoxLabelui3 As TextOnlyTextBoxLabelUI
    Friend WithEvents TextOnlyTextBoxLabelui4 As TextOnlyTextBoxLabelUI
    Friend WithEvents Panel4 As Panel
    Friend WithEvents ComboBoxLayoutui2 As ComboBoxLayoutUI
    Friend WithEvents Panel3 As Panel
    Friend WithEvents ComboBoxLayoutui1 As ComboBoxLayoutUI

End Class
