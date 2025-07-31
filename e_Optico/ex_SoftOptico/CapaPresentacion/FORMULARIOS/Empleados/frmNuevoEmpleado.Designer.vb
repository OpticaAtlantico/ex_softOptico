<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNuevoEmpleado
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
        pnlContenido = New Panel()
        cmbSexo = New ComboBoxLabelUI()
        btnEliminarFoto = New FontAwesome.Sharp.IconButton()
        btnGuardarFoto = New FontAwesome.Sharp.IconButton()
        pnlCargo = New Panel()
        swMarketing = New ToggleSwitchUI()
        swGerente = New ToggleSwitchUI()
        swOptometrista = New ToggleSwitchUI()
        swAsesor = New ToggleSwitchUI()
        txtDireccion = New MultilineTextBoxLabelUI()
        txtTelefono = New MaskedTextBoxLabelUI()
        txtCorreo = New TextBoxLabelUI()
        cmbZona = New ComboBoxLabelUI()
        cmbCargo = New ComboBoxLabelUI()
        txtFechaNac = New MaskedTextBoxLabelUI()
        cmbEstadoCivil = New ComboBoxLabelUI()
        cmbNacionalidad = New ComboBoxLabelUI()
        txtApellido = New TextBoxLabelUI()
        txtNombre = New TextBoxLabelUI()
        txtEdad = New MaskedTextBoxLabelUI()
        txtCedula = New MaskedTextBoxLabelUI()
        imgFoto = New FontAwesome.Sharp.IconPictureBox()
        pnlEncabezado = New Panel()
        bntGuardar = New CommandButtonUI()
        Headerui1 = New HeaderUI()
        pnlContenedor.SuspendLayout()
        pnlContenido.SuspendLayout()
        pnlCargo.SuspendLayout()
        CType(imgFoto, ComponentModel.ISupportInitialize).BeginInit()
        pnlEncabezado.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlContenedor
        ' 
        pnlContenedor.Controls.Add(pnlContenido)
        pnlContenedor.Controls.Add(pnlEncabezado)
        pnlContenedor.Dock = DockStyle.Fill
        pnlContenedor.Location = New Point(0, 0)
        pnlContenedor.Name = "pnlContenedor"
        pnlContenedor.Size = New Size(1274, 606)
        pnlContenedor.TabIndex = 0
        ' 
        ' pnlContenido
        ' 
        pnlContenido.AutoScroll = True
        pnlContenido.Controls.Add(cmbSexo)
        pnlContenido.Controls.Add(btnEliminarFoto)
        pnlContenido.Controls.Add(btnGuardarFoto)
        pnlContenido.Controls.Add(pnlCargo)
        pnlContenido.Controls.Add(txtDireccion)
        pnlContenido.Controls.Add(txtTelefono)
        pnlContenido.Controls.Add(txtCorreo)
        pnlContenido.Controls.Add(cmbZona)
        pnlContenido.Controls.Add(cmbCargo)
        pnlContenido.Controls.Add(txtFechaNac)
        pnlContenido.Controls.Add(cmbEstadoCivil)
        pnlContenido.Controls.Add(cmbNacionalidad)
        pnlContenido.Controls.Add(txtApellido)
        pnlContenido.Controls.Add(txtNombre)
        pnlContenido.Controls.Add(txtEdad)
        pnlContenido.Controls.Add(txtCedula)
        pnlContenido.Controls.Add(imgFoto)
        pnlContenido.Dock = DockStyle.Fill
        pnlContenido.Location = New Point(0, 60)
        pnlContenido.Margin = New Padding(3, 30, 3, 3)
        pnlContenido.Name = "pnlContenido"
        pnlContenido.Padding = New Padding(10, 30, 0, 0)
        pnlContenido.Size = New Size(1274, 546)
        pnlContenido.TabIndex = 1
        ' 
        ' cmbSexo
        ' 
        cmbSexo.BackColor = Color.Transparent
        cmbSexo.BackColorPnl = Color.WhiteSmoke
        cmbSexo.BorderColor = Color.LightGray
        cmbSexo.BorderSize = 1
        cmbSexo.CampoRequerido = True
        cmbSexo.ForeColor = Color.Black
        cmbSexo.LabelColor = Color.DarkSlateGray
        cmbSexo.Location = New Point(214, 177)
        cmbSexo.MensajeError = "Este campo es obligatorio."
        cmbSexo.MostrarError = False
        cmbSexo.Name = "cmbSexo"
        cmbSexo.RadioContornoPanel = 6
        cmbSexo.Size = New Size(343, 74)
        cmbSexo.TabIndex = 24
        cmbSexo.Titulo = "Selecciona una opción:"
        ' 
        ' btnEliminarFoto
        ' 
        btnEliminarFoto.FlatAppearance.BorderSize = 0
        btnEliminarFoto.FlatStyle = FlatStyle.Flat
        btnEliminarFoto.Font = New Font("Century Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnEliminarFoto.IconChar = FontAwesome.Sharp.IconChar.TrashRestore
        btnEliminarFoto.IconColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        btnEliminarFoto.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnEliminarFoto.IconSize = 40
        btnEliminarFoto.Location = New Point(111, 239)
        btnEliminarFoto.Name = "btnEliminarFoto"
        btnEliminarFoto.Size = New Size(68, 57)
        btnEliminarFoto.TabIndex = 23
        btnEliminarFoto.Text = "Remover"
        btnEliminarFoto.TextImageRelation = TextImageRelation.ImageAboveText
        btnEliminarFoto.UseVisualStyleBackColor = True
        ' 
        ' btnGuardarFoto
        ' 
        btnGuardarFoto.FlatAppearance.BorderSize = 0
        btnGuardarFoto.FlatStyle = FlatStyle.Flat
        btnGuardarFoto.Font = New Font("Century Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnGuardarFoto.IconChar = FontAwesome.Sharp.IconChar.FolderOpen
        btnGuardarFoto.IconColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        btnGuardarFoto.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnGuardarFoto.IconSize = 40
        btnGuardarFoto.Location = New Point(27, 239)
        btnGuardarFoto.Name = "btnGuardarFoto"
        btnGuardarFoto.Size = New Size(68, 57)
        btnGuardarFoto.TabIndex = 22
        btnGuardarFoto.Text = "Agregar"
        btnGuardarFoto.TextImageRelation = TextImageRelation.ImageAboveText
        btnGuardarFoto.UseVisualStyleBackColor = True
        ' 
        ' pnlCargo
        ' 
        pnlCargo.BackColor = Color.Azure
        pnlCargo.Controls.Add(swMarketing)
        pnlCargo.Controls.Add(swGerente)
        pnlCargo.Controls.Add(swOptometrista)
        pnlCargo.Controls.Add(swAsesor)
        pnlCargo.Location = New Point(660, 364)
        pnlCargo.Name = "pnlCargo"
        pnlCargo.Size = New Size(602, 99)
        pnlCargo.TabIndex = 21
        ' 
        ' swMarketing
        ' 
        swMarketing.BackgroundOff = Color.Gainsboro
        swMarketing.BackgroundOn = Color.SeaGreen
        swMarketing.BorderRadius = 20
        swMarketing.Checked = False
        swMarketing.EstadoTexto = "Marketing..."
        swMarketing.Font = New Font("Century Gothic", 11F)
        swMarketing.Location = New Point(345, 61)
        swMarketing.Name = "swMarketing"
        swMarketing.Size = New Size(160, 23)
        swMarketing.SwitchColor = Color.DarkSlateGray
        swMarketing.TabIndex = 0
        swMarketing.Text = "ToggleSwitchui1"
        swMarketing.TextColor = Color.DarkSlateGray
        ' 
        ' swGerente
        ' 
        swGerente.BackgroundOff = Color.Gainsboro
        swGerente.BackgroundOn = Color.SeaGreen
        swGerente.BorderRadius = 20
        swGerente.Checked = False
        swGerente.EstadoTexto = "Gerente..."
        swGerente.Font = New Font("Century Gothic", 11F)
        swGerente.Location = New Point(93, 61)
        swGerente.Name = "swGerente"
        swGerente.Size = New Size(147, 23)
        swGerente.SwitchColor = Color.DarkSlateGray
        swGerente.TabIndex = 0
        swGerente.Text = "ToggleSwitchui1"
        swGerente.TextColor = Color.DarkSlateGray
        ' 
        ' swOptometrista
        ' 
        swOptometrista.BackgroundOff = Color.Gainsboro
        swOptometrista.BackgroundOn = Color.SeaGreen
        swOptometrista.BorderRadius = 20
        swOptometrista.Checked = False
        swOptometrista.EstadoTexto = "Optometrista..."
        swOptometrista.Font = New Font("Century Gothic", 11F)
        swOptometrista.Location = New Point(345, 17)
        swOptometrista.Name = "swOptometrista"
        swOptometrista.Size = New Size(170, 23)
        swOptometrista.SwitchColor = Color.DarkSlateGray
        swOptometrista.TabIndex = 0
        swOptometrista.Text = "ToggleSwitchui1"
        swOptometrista.TextColor = Color.DarkSlateGray
        ' 
        ' swAsesor
        ' 
        swAsesor.BackgroundOff = Color.Gainsboro
        swAsesor.BackgroundOn = Color.SeaGreen
        swAsesor.BorderRadius = 20
        swAsesor.Checked = False
        swAsesor.EstadoTexto = "Asesor..."
        swAsesor.Font = New Font("Century Gothic", 11F)
        swAsesor.Location = New Point(93, 17)
        swAsesor.Name = "swAsesor"
        swAsesor.Size = New Size(131, 23)
        swAsesor.SwitchColor = Color.DarkSlateGray
        swAsesor.TabIndex = 0
        swAsesor.Text = "ToggleSwitchui1"
        swAsesor.TextColor = Color.DarkSlateGray
        ' 
        ' txtDireccion
        ' 
        txtDireccion.AlturaMultilinea = 160
        txtDireccion.BackColor = Color.Transparent
        txtDireccion.BorderColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtDireccion.BorderRadius = 8
        txtDireccion.BorderSize = 1
        txtDireccion.CampoRequerido = True
        txtDireccion.CapitalizarTexto = True
        txtDireccion.CapitalizarTodasLasPalabras = False
        txtDireccion.ColorError = Color.Firebrick
        txtDireccion.FontField = New Font("Century Gothic", 12F)
        txtDireccion.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtDireccion.IconoDerechoChar = FontAwesome.Sharp.IconChar.Building
        txtDireccion.LabelColor = Color.DarkSlateGray
        txtDireccion.LabelText = "Dirección de habitación:"
        txtDireccion.Location = New Point(12, 343)
        txtDireccion.MensajeError = "Este campo es obligatorio."
        txtDireccion.Multilinea = True
        txtDireccion.Name = "txtDireccion"
        txtDireccion.PaddingAll = 10
        txtDireccion.PanelBackColor = Color.White
        txtDireccion.Size = New Size(642, 141)
        txtDireccion.TabIndex = 20
        txtDireccion.TextColor = Color.Black
        ' 
        ' txtTelefono
        ' 
        txtTelefono.BackColor = Color.Transparent
        txtTelefono.BorderColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtTelefono.BorderRadius = 8
        txtTelefono.BorderSize = 1
        txtTelefono.CampoRequerido = True
        txtTelefono.ColorError = Color.Firebrick
        txtTelefono.FontField = New Font("Century Gothic", 12F)
        txtTelefono.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtTelefono.IconoDerechoChar = FontAwesome.Sharp.IconChar.PhoneVolume
        txtTelefono.LabelColor = Color.DarkSlateGray
        txtTelefono.LabelText = "# Teléfono contacto:"
        txtTelefono.Location = New Point(568, 260)
        txtTelefono.MascaraPersonalizada = ""
        txtTelefono.MensajeError = "Este campo es obligatorio."
        txtTelefono.Name = "txtTelefono"
        txtTelefono.PaddingAll = 10
        txtTelefono.PanelBackColor = Color.White
        txtTelefono.Size = New Size(348, 77)
        txtTelefono.TabIndex = 8
        txtTelefono.TextColor = Color.Black
        txtTelefono.TipoNumerico = MaskedTextBoxLabelUI.TipoEntradaNumerica.Ninguno
        ' 
        ' txtCorreo
        ' 
        txtCorreo.BackColor = Color.Transparent
        txtCorreo.BorderColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtCorreo.BorderRadius = 5
        txtCorreo.BorderSize = 1
        txtCorreo.CampoRequerido = True
        txtCorreo.CapitalizarTexto = False
        txtCorreo.CapitalizarTodasLasPalabras = True
        txtCorreo.CaracterContraseña = "*"c
        txtCorreo.ColorError = Color.Firebrick
        txtCorreo.FontField = New Font("Century Gothic", 12F)
        txtCorreo.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtCorreo.IconoDerechoChar = FontAwesome.Sharp.IconChar.EnvelopesBulk
        txtCorreo.LabelColor = Color.DarkSlateGray
        txtCorreo.LabelText = "Correo electrónico:"
        txtCorreo.Location = New Point(214, 260)
        txtCorreo.MensajeError = "Este campo es obligatorio."
        txtCorreo.Name = "txtCorreo"
        txtCorreo.PaddingAll = 10
        txtCorreo.PanelBackColor = Color.White
        txtCorreo.Size = New Size(348, 77)
        txtCorreo.TabIndex = 13
        txtCorreo.TextColor = Color.Black
        txtCorreo.UsarModoContraseña = False
        txtCorreo.ValidarComoCorreo = True
        ' 
        ' cmbZona
        ' 
        cmbZona.BackColor = Color.Transparent
        cmbZona.BackColorPnl = Color.WhiteSmoke
        cmbZona.BorderColor = Color.LightGray
        cmbZona.BorderSize = 1
        cmbZona.CampoRequerido = True
        cmbZona.LabelColor = Color.DarkSlateGray
        cmbZona.Location = New Point(922, 260)
        cmbZona.MensajeError = "Este campo es obligatorio."
        cmbZona.MostrarError = False
        cmbZona.Name = "cmbZona"
        cmbZona.RadioContornoPanel = 8
        cmbZona.Size = New Size(348, 77)
        cmbZona.TabIndex = 14
        cmbZona.Titulo = "Zona de habitación:"
        ' 
        ' cmbCargo
        ' 
        cmbCargo.BackColor = Color.Transparent
        cmbCargo.BackColorPnl = Color.WhiteSmoke
        cmbCargo.BorderColor = Color.LightGray
        cmbCargo.BorderSize = 1
        cmbCargo.CampoRequerido = True
        cmbCargo.LabelColor = Color.DarkSlateGray
        cmbCargo.Location = New Point(922, 177)
        cmbCargo.MensajeError = "Este campo es obligatorio."
        cmbCargo.MostrarError = False
        cmbCargo.Name = "cmbCargo"
        cmbCargo.RadioContornoPanel = 8
        cmbCargo.Size = New Size(348, 77)
        cmbCargo.TabIndex = 15
        cmbCargo.Titulo = "Cargo:"
        ' 
        ' txtFechaNac
        ' 
        txtFechaNac.BackColor = Color.Transparent
        txtFechaNac.BorderColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtFechaNac.BorderRadius = 8
        txtFechaNac.BorderSize = 1
        txtFechaNac.CampoRequerido = True
        txtFechaNac.ColorError = Color.Firebrick
        txtFechaNac.FontField = New Font("Century Gothic", 12F)
        txtFechaNac.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtFechaNac.IconoDerechoChar = FontAwesome.Sharp.IconChar.CalendarDays
        txtFechaNac.LabelColor = Color.DarkSlateGray
        txtFechaNac.LabelText = "Fecha de Nacimiento:"
        txtFechaNac.Location = New Point(568, 177)
        txtFechaNac.MascaraPersonalizada = "99/99/9999"
        txtFechaNac.MensajeError = "Este campo es obligatorio."
        txtFechaNac.Name = "txtFechaNac"
        txtFechaNac.PaddingAll = 10
        txtFechaNac.PanelBackColor = Color.White
        txtFechaNac.Size = New Size(348, 77)
        txtFechaNac.TabIndex = 7
        txtFechaNac.TextColor = Color.Black
        txtFechaNac.TipoNumerico = MaskedTextBoxLabelUI.TipoEntradaNumerica.Ninguno
        ' 
        ' cmbEstadoCivil
        ' 
        cmbEstadoCivil.BackColor = Color.Transparent
        cmbEstadoCivil.BackColorPnl = Color.WhiteSmoke
        cmbEstadoCivil.BorderColor = Color.LightGray
        cmbEstadoCivil.BorderSize = 1
        cmbEstadoCivil.CampoRequerido = True
        cmbEstadoCivil.LabelColor = Color.DarkSlateGray
        cmbEstadoCivil.Location = New Point(922, 94)
        cmbEstadoCivil.MensajeError = "Este campo es obligatorio."
        cmbEstadoCivil.MostrarError = False
        cmbEstadoCivil.Name = "cmbEstadoCivil"
        cmbEstadoCivil.RadioContornoPanel = 8
        cmbEstadoCivil.Size = New Size(348, 77)
        cmbEstadoCivil.TabIndex = 17
        cmbEstadoCivil.Titulo = "Estado Civil:"
        ' 
        ' cmbNacionalidad
        ' 
        cmbNacionalidad.BackColor = Color.Transparent
        cmbNacionalidad.BackColorPnl = Color.WhiteSmoke
        cmbNacionalidad.BorderColor = Color.LightGray
        cmbNacionalidad.BorderSize = 1
        cmbNacionalidad.CampoRequerido = True
        cmbNacionalidad.LabelColor = Color.DarkSlateGray
        cmbNacionalidad.Location = New Point(568, 94)
        cmbNacionalidad.MensajeError = "Este campo es obligatorio."
        cmbNacionalidad.MostrarError = False
        cmbNacionalidad.Name = "cmbNacionalidad"
        cmbNacionalidad.RadioContornoPanel = 8
        cmbNacionalidad.Size = New Size(348, 77)
        cmbNacionalidad.TabIndex = 18
        cmbNacionalidad.Titulo = "Nacionalidad:"
        ' 
        ' txtApellido
        ' 
        txtApellido.BackColor = Color.Transparent
        txtApellido.BorderColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtApellido.BorderRadius = 5
        txtApellido.BorderSize = 1
        txtApellido.CampoRequerido = True
        txtApellido.CapitalizarTexto = False
        txtApellido.CapitalizarTodasLasPalabras = True
        txtApellido.CaracterContraseña = "*"c
        txtApellido.ColorError = Color.Firebrick
        txtApellido.FontField = New Font("Century Gothic", 12F)
        txtApellido.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtApellido.IconoDerechoChar = FontAwesome.Sharp.IconChar.Vcard
        txtApellido.LabelColor = Color.DarkSlateGray
        txtApellido.LabelText = "Apellido:"
        txtApellido.Location = New Point(922, 11)
        txtApellido.MensajeError = "Este campo es obligatorio."
        txtApellido.Name = "txtApellido"
        txtApellido.PaddingAll = 10
        txtApellido.PanelBackColor = Color.White
        txtApellido.Size = New Size(348, 77)
        txtApellido.TabIndex = 11
        txtApellido.TextColor = Color.Black
        txtApellido.UsarModoContraseña = False
        txtApellido.ValidarComoCorreo = False
        ' 
        ' txtNombre
        ' 
        txtNombre.BackColor = Color.Transparent
        txtNombre.BorderColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtNombre.BorderRadius = 5
        txtNombre.BorderSize = 1
        txtNombre.CampoRequerido = True
        txtNombre.CapitalizarTexto = True
        txtNombre.CapitalizarTodasLasPalabras = True
        txtNombre.CaracterContraseña = "*"c
        txtNombre.ColorError = Color.Firebrick
        txtNombre.FontField = New Font("Century Gothic", 12F)
        txtNombre.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtNombre.IconoDerechoChar = FontAwesome.Sharp.IconChar.Vcard
        txtNombre.LabelColor = Color.DarkSlateGray
        txtNombre.LabelText = "Nombre:"
        txtNombre.Location = New Point(568, 11)
        txtNombre.MensajeError = "Este campo es obligatorio."
        txtNombre.Name = "txtNombre"
        txtNombre.PaddingAll = 10
        txtNombre.PanelBackColor = Color.White
        txtNombre.Size = New Size(348, 77)
        txtNombre.TabIndex = 10
        txtNombre.TextColor = Color.Black
        txtNombre.UsarModoContraseña = False
        txtNombre.ValidarComoCorreo = False
        ' 
        ' txtEdad
        ' 
        txtEdad.BackColor = Color.Transparent
        txtEdad.BorderColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtEdad.BorderRadius = 8
        txtEdad.BorderSize = 1
        txtEdad.CampoRequerido = True
        txtEdad.ColorError = Color.Firebrick
        txtEdad.FontField = New Font("Century Gothic", 12F)
        txtEdad.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtEdad.IconoDerechoChar = FontAwesome.Sharp.IconChar.ArrowUp19
        txtEdad.LabelColor = Color.DarkSlateGray
        txtEdad.LabelText = "Edad:"
        txtEdad.Location = New Point(214, 94)
        txtEdad.MascaraPersonalizada = ""
        txtEdad.MensajeError = "Este campo es obligatorio."
        txtEdad.Name = "txtEdad"
        txtEdad.PaddingAll = 10
        txtEdad.PanelBackColor = Color.White
        txtEdad.Size = New Size(348, 77)
        txtEdad.TabIndex = 9
        txtEdad.TextColor = Color.Black
        txtEdad.TipoNumerico = MaskedTextBoxLabelUI.TipoEntradaNumerica.Entero
        ' 
        ' txtCedula
        ' 
        txtCedula.BackColor = Color.Transparent
        txtCedula.BorderColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtCedula.BorderRadius = 8
        txtCedula.BorderSize = 1
        txtCedula.CampoRequerido = True
        txtCedula.ColorError = Color.Firebrick
        txtCedula.FontField = New Font("Century Gothic", 12F)
        txtCedula.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtCedula.IconoDerechoChar = FontAwesome.Sharp.IconChar.Vcard
        txtCedula.LabelColor = Color.DarkSlateGray
        txtCedula.LabelText = "#Cédula:"
        txtCedula.Location = New Point(214, 11)
        txtCedula.MascaraPersonalizada = ""
        txtCedula.MensajeError = "Este campo es obligatorio."
        txtCedula.Name = "txtCedula"
        txtCedula.PaddingAll = 10
        txtCedula.PanelBackColor = Color.White
        txtCedula.Size = New Size(348, 77)
        txtCedula.TabIndex = 9
        txtCedula.TextColor = Color.Black
        txtCedula.TipoNumerico = MaskedTextBoxLabelUI.TipoEntradaNumerica.Entero
        ' 
        ' imgFoto
        ' 
        imgFoto.BackColor = Color.White
        imgFoto.BorderStyle = BorderStyle.FixedSingle
        imgFoto.ForeColor = SystemColors.AppWorkspace
        imgFoto.IconChar = FontAwesome.Sharp.IconChar.UserGear
        imgFoto.IconColor = SystemColors.AppWorkspace
        imgFoto.IconFont = FontAwesome.Sharp.IconFont.Auto
        imgFoto.IconSize = 196
        imgFoto.Location = New Point(12, 11)
        imgFoto.Name = "imgFoto"
        imgFoto.Size = New Size(196, 225)
        imgFoto.TabIndex = 19
        imgFoto.TabStop = False
        ' 
        ' pnlEncabezado
        ' 
        pnlEncabezado.Controls.Add(bntGuardar)
        pnlEncabezado.Controls.Add(Headerui1)
        pnlEncabezado.Dock = DockStyle.Top
        pnlEncabezado.Location = New Point(0, 0)
        pnlEncabezado.Name = "pnlEncabezado"
        pnlEncabezado.Size = New Size(1274, 60)
        pnlEncabezado.TabIndex = 0
        ' 
        ' bntGuardar
        ' 
        bntGuardar.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        bntGuardar.AnimarHover = True
        bntGuardar.BackColor = Color.Transparent
        bntGuardar.ColorBase = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        bntGuardar.ColorHover = Color.FromArgb(CByte(67), CByte(160), CByte(71))
        bntGuardar.ColorInternoFondo = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        bntGuardar.ColorPresionado = Color.FromArgb(CByte(56), CByte(142), CByte(60))
        bntGuardar.ColorTexto = Color.White
        bntGuardar.EstiloBoton = CommandButtonUI.EstiloBootstrap.Success
        bntGuardar.Font = New Font("Century Gothic", 10F, FontStyle.Bold)
        bntGuardar.Icono = FontAwesome.Sharp.IconChar.Save
        bntGuardar.Location = New Point(1084, 12)
        bntGuardar.Name = "bntGuardar"
        bntGuardar.RadioBorde = 8
        bntGuardar.Size = New Size(180, 40)
        bntGuardar.TabIndex = 1
        bntGuardar.Text = "CommandButtonui2"
        bntGuardar.Texto = "Guardar Datos"
        ' 
        ' Headerui1
        ' 
        Headerui1.ColorFondo = Color.White
        Headerui1.ColorTexto = Color.FromArgb(CByte(45), CByte(45), CByte(45))
        Headerui1.Dock = DockStyle.Fill
        Headerui1.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Headerui1.Icono = FontAwesome.Sharp.IconChar.CircleInfo
        Headerui1.Location = New Point(0, 0)
        Headerui1.MostrarSeparador = True
        Headerui1.Name = "Headerui1"
        Headerui1.Size = New Size(1274, 60)
        Headerui1.Subtitulo = "Subtítulo opcional"
        Headerui1.TabIndex = 0
        Headerui1.Text = "Headerui1"
        Headerui1.Titulo = "Título Principal"
        ' 
        ' frmNuevoEmpleado
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1274, 606)
        Controls.Add(pnlContenedor)
        Name = "frmNuevoEmpleado"
        Text = "frmNuevoEmpleado"
        pnlContenedor.ResumeLayout(False)
        pnlContenido.ResumeLayout(False)
        pnlCargo.ResumeLayout(False)
        CType(imgFoto, ComponentModel.ISupportInitialize).EndInit()
        pnlEncabezado.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents pnlContenedor As Panel
    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents Headerui1 As HeaderUI
    Friend WithEvents bntGuardar As CommandButtonUI
    Friend WithEvents pnlContenido As Panel
    Friend WithEvents btnEliminarFoto As FontAwesome.Sharp.IconButton
    Friend WithEvents btnGuardarFoto As FontAwesome.Sharp.IconButton
    Friend WithEvents pnlCargo As Panel
    Friend WithEvents swMarketing As ToggleSwitchUI
    Friend WithEvents swGerente As ToggleSwitchUI
    Friend WithEvents swOptometrista As ToggleSwitchUI
    Friend WithEvents swAsesor As ToggleSwitchUI
    Friend WithEvents txtDireccion As MultilineTextBoxLabelUI
    Friend WithEvents txtTelefono As MaskedTextBoxLabelUI
    Friend WithEvents txtCorreo As TextBoxLabelUI
    Friend WithEvents cmbZona As ComboBoxLabelUI
    Friend WithEvents cmbCargo As ComboBoxLabelUI
    Friend WithEvents txtFechaNac As MaskedTextBoxLabelUI
    Friend WithEvents cmbEstadoCivil As ComboBoxLabelUI
    Friend WithEvents cmbNacionalidad As ComboBoxLabelUI
    Friend WithEvents txtApellido As TextBoxLabelUI
    Friend WithEvents txtNombre As TextBoxLabelUI
    Friend WithEvents txtCedula As MaskedTextBoxLabelUI
    Friend WithEvents imgFoto As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents txtEdad As MaskedTextBoxLabelUI
    Friend WithEvents cmbSexo As ComboBoxLabelUI
End Class
