<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEmpleado
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
        Panel1 = New Panel()
        pnlContenido = New Panel()
        swMarketing = New ToggleSwitchUI()
        swGerente = New ToggleSwitchUI()
        swOptometrista = New ToggleSwitchUI()
        swAsesor = New ToggleSwitchUI()
        Labelui1 = New LabelUI()
        txtDireccion = New MultilineTextBoxLabelUI()
        TableLayoutPanel1 = New TableLayoutPanel()
        txtCedula = New MaskedTextBoxLabelUI()
        txtFechaNac = New DateBoxLabelUI()
        txtNombre = New TextBoxLabelUI()
        cmbSexo = New ComboBoxLabelUI()
        txtApellido = New TextBoxLabelUI()
        cmbZona = New ComboBoxLabelUI()
        txtTelefono = New MaskedTextBoxLabelUI()
        txtEdad = New MaskedTextBoxLabelUI()
        txtCorreo = New TextBoxLabelUI()
        cmbNacionalidad = New ComboBoxLabelUI()
        cmbEstadoCivil = New ComboBoxLabelUI()
        cmbCargo = New ComboBoxLabelUI()
        btnEliminarFoto = New FontAwesome.Sharp.IconButton()
        btnGuardarFoto = New FontAwesome.Sharp.IconButton()
        imgFoto = New FontAwesome.Sharp.IconPictureBox()
        pnlEncabezado = New Panel()
        btnAccion = New CommandButtonUI()
        Headerui1 = New HeaderUI()
        pnlContenedor.SuspendLayout()
        pnlContenido.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        CType(imgFoto, ComponentModel.ISupportInitialize).BeginInit()
        pnlEncabezado.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlContenedor
        ' 
        pnlContenedor.Controls.Add(Panel1)
        pnlContenedor.Controls.Add(pnlContenido)
        pnlContenedor.Controls.Add(pnlEncabezado)
        pnlContenedor.Dock = DockStyle.Fill
        pnlContenedor.Location = New Point(0, 0)
        pnlContenedor.Name = "pnlContenedor"
        pnlContenedor.Size = New Size(1274, 626)
        pnlContenedor.TabIndex = 0
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(0), CByte(192), CByte(192))
        Panel1.Dock = DockStyle.Bottom
        Panel1.Location = New Point(0, 570)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1274, 56)
        Panel1.TabIndex = 2
        ' 
        ' pnlContenido
        ' 
        pnlContenido.AutoScroll = True
        pnlContenido.Controls.Add(swMarketing)
        pnlContenido.Controls.Add(swGerente)
        pnlContenido.Controls.Add(swOptometrista)
        pnlContenido.Controls.Add(swAsesor)
        pnlContenido.Controls.Add(Labelui1)
        pnlContenido.Controls.Add(txtDireccion)
        pnlContenido.Controls.Add(TableLayoutPanel1)
        pnlContenido.Controls.Add(btnEliminarFoto)
        pnlContenido.Controls.Add(btnGuardarFoto)
        pnlContenido.Controls.Add(imgFoto)
        pnlContenido.Dock = DockStyle.Fill
        pnlContenido.Location = New Point(0, 60)
        pnlContenido.Margin = New Padding(3, 30, 3, 3)
        pnlContenido.Name = "pnlContenido"
        pnlContenido.Padding = New Padding(10, 30, 0, 0)
        pnlContenido.Size = New Size(1274, 566)
        pnlContenido.TabIndex = 1
        ' 
        ' swMarketing
        ' 
        swMarketing.BackColor = Color.FromArgb(CByte(208), CByte(233), CByte(242))
        swMarketing.BackgroundOff = Color.WhiteSmoke
        swMarketing.BackgroundOn = Color.SeaGreen
        swMarketing.BorderRadius = 20
        swMarketing.Checked = False
        swMarketing.EstadoTexto = "Marketing..."
        swMarketing.Font = New Font("Century Gothic", 11F)
        swMarketing.Location = New Point(1046, 445)
        swMarketing.Name = "swMarketing"
        swMarketing.Size = New Size(160, 23)
        swMarketing.SwitchColor = Color.Aquamarine
        swMarketing.TabIndex = 36
        swMarketing.Text = "ToggleSwitchui1"
        swMarketing.TextColor = Color.DarkSlateGray
        ' 
        ' swGerente
        ' 
        swGerente.BackColor = Color.FromArgb(CByte(208), CByte(233), CByte(242))
        swGerente.BackgroundOff = Color.WhiteSmoke
        swGerente.BackgroundOn = Color.SeaGreen
        swGerente.BorderRadius = 20
        swGerente.Checked = False
        swGerente.EstadoTexto = "Gerente..."
        swGerente.Font = New Font("Century Gothic", 11F)
        swGerente.Location = New Point(794, 445)
        swGerente.Name = "swGerente"
        swGerente.Size = New Size(147, 23)
        swGerente.SwitchColor = Color.Aquamarine
        swGerente.TabIndex = 35
        swGerente.Text = "ToggleSwitchui1"
        swGerente.TextColor = Color.DarkSlateGray
        ' 
        ' swOptometrista
        ' 
        swOptometrista.BackColor = Color.FromArgb(CByte(208), CByte(233), CByte(242))
        swOptometrista.BackgroundOff = Color.WhiteSmoke
        swOptometrista.BackgroundOn = Color.SeaGreen
        swOptometrista.BorderRadius = 20
        swOptometrista.Checked = False
        swOptometrista.EstadoTexto = "Optometrista..."
        swOptometrista.Font = New Font("Century Gothic", 11F)
        swOptometrista.Location = New Point(1046, 401)
        swOptometrista.Name = "swOptometrista"
        swOptometrista.Size = New Size(170, 23)
        swOptometrista.SwitchColor = Color.Aquamarine
        swOptometrista.TabIndex = 34
        swOptometrista.Text = "ToggleSwitchui1"
        swOptometrista.TextColor = Color.DarkSlateGray
        ' 
        ' swAsesor
        ' 
        swAsesor.BackColor = Color.FromArgb(CByte(208), CByte(233), CByte(242))
        swAsesor.BackgroundOff = Color.WhiteSmoke
        swAsesor.BackgroundOn = Color.SeaGreen
        swAsesor.BorderRadius = 20
        swAsesor.Checked = False
        swAsesor.EstadoTexto = "Asesor..."
        swAsesor.Font = New Font("Century Gothic", 11F)
        swAsesor.Location = New Point(794, 401)
        swAsesor.Name = "swAsesor"
        swAsesor.Size = New Size(131, 23)
        swAsesor.SwitchColor = Color.Aquamarine
        swAsesor.TabIndex = 33
        swAsesor.Text = "ToggleSwitchui1"
        swAsesor.TextColor = Color.DarkSlateGray
        ' 
        ' Labelui1
        ' 
        Labelui1.BackColor = Color.Transparent
        Labelui1.BloquearColorFondo = True
        Labelui1.CausesValidation = False
        Labelui1.ColorInternoFondo = Color.FromArgb(CByte(208), CByte(233), CByte(242))
        Labelui1.EstiloLabel = LabelUI.EstiloBootstrap.Info
        Labelui1.Font = New Font("Century Gothic", 10F)
        Labelui1.ForeColor = Color.FromArgb(CByte(0), CByte(188), CByte(212))
        Labelui1.Icono = FontAwesome.Sharp.IconChar.None
        Labelui1.Location = New Point(721, 390)
        Labelui1.Name = "Labelui1"
        Labelui1.Padding = New Padding(10, 6, 10, 6)
        Labelui1.RadioBorde = 8
        Labelui1.Size = New Size(538, 98)
        Labelui1.TabIndex = 32
        Labelui1.Text = "Labelui1"
        Labelui1.Texto = ""
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
        txtDireccion.Location = New Point(12, 369)
        txtDireccion.MensajeError = "Este campo es obligatorio."
        txtDireccion.Multilinea = True
        txtDireccion.Name = "txtDireccion"
        txtDireccion.PaddingAll = 10
        txtDireccion.PanelBackColor = Color.White
        txtDireccion.Size = New Size(703, 138)
        txtDireccion.SombraBackColor = Color.LightGray
        txtDireccion.TabIndex = 13
        txtDireccion.TextColor = Color.Black
        txtDireccion.TextoUsuario = ""
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 3
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.33333F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333359F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333359F))
        TableLayoutPanel1.Controls.Add(txtCedula, 0, 0)
        TableLayoutPanel1.Controls.Add(txtFechaNac, 1, 2)
        TableLayoutPanel1.Controls.Add(txtNombre, 1, 0)
        TableLayoutPanel1.Controls.Add(cmbSexo, 0, 2)
        TableLayoutPanel1.Controls.Add(txtApellido, 2, 0)
        TableLayoutPanel1.Controls.Add(cmbZona, 2, 3)
        TableLayoutPanel1.Controls.Add(txtTelefono, 1, 3)
        TableLayoutPanel1.Controls.Add(txtEdad, 0, 1)
        TableLayoutPanel1.Controls.Add(txtCorreo, 0, 3)
        TableLayoutPanel1.Controls.Add(cmbNacionalidad, 1, 1)
        TableLayoutPanel1.Controls.Add(cmbEstadoCivil, 2, 1)
        TableLayoutPanel1.Controls.Add(cmbCargo, 2, 2)
        TableLayoutPanel1.Location = New Point(214, 11)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 4
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 90F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 90F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 90F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 90F))
        TableLayoutPanel1.Size = New Size(1048, 356)
        TableLayoutPanel1.TabIndex = 26
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
        txtCedula.Location = New Point(3, 3)
        txtCedula.MascaraPersonalizada = ""
        txtCedula.MaxCaracteres = 8
        txtCedula.MensajeError = "Este campo es obligatorio."
        txtCedula.Name = "txtCedula"
        txtCedula.PaddingAll = 10
        txtCedula.PanelBackColor = Color.White
        txtCedula.SelectionStart = 0
        txtCedula.Size = New Size(343, 80)
        txtCedula.SombraBackColor = Color.LightGray
        txtCedula.TabIndex = 1
        txtCedula.TextColor = Color.Black
        txtCedula.TextoUsuario = ""
        txtCedula.TipoNumerico = MaskedTextBoxLabelUI.TipoEntradaNumerica.Entero
        ' 
        ' txtFechaNac
        ' 
        txtFechaNac.BackColor = Color.White
        txtFechaNac.BorderColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtFechaNac.BorderRadius = 8
        txtFechaNac.BorderSize = 1
        txtFechaNac.CampoRequerido = True
        txtFechaNac.FechaSeleccionada = New Date(2025, 7, 31, 0, 0, 0, 0)
        txtFechaNac.FontField = New Font("Century Gothic", 12F)
        txtFechaNac.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtFechaNac.IconoDerechoChar = FontAwesome.Sharp.IconChar.CalendarDays
        txtFechaNac.LabelColor = Color.DarkSlateGray
        txtFechaNac.LabelText = "Fecha:"
        txtFechaNac.Location = New Point(352, 183)
        txtFechaNac.MensajeError = "Fecha requerida o inválida."
        txtFechaNac.Name = "txtFechaNac"
        txtFechaNac.PaddingAll = 10
        txtFechaNac.PanelBackColor = Color.White
        txtFechaNac.Size = New Size(343, 80)
        txtFechaNac.TabIndex = 8
        txtFechaNac.TextColor = Color.Black
        ' 
        ' txtNombre
        ' 
        txtNombre.BackColor = Color.Transparent
        txtNombre.BorderColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtNombre.BorderRadius = 8
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
        txtNombre.Location = New Point(352, 3)
        txtNombre.MensajeError = "Este campo es obligatorio."
        txtNombre.Name = "txtNombre"
        txtNombre.PaddingAll = 10
        txtNombre.PanelBackColor = Color.White
        txtNombre.Size = New Size(343, 80)
        txtNombre.SombraBackColor = Color.LightGray
        txtNombre.TabIndex = 2
        txtNombre.TextColor = Color.Black
        txtNombre.TextoUsuario = ""
        txtNombre.UsarModoContraseña = False
        txtNombre.ValidarComoCorreo = False
        ' 
        ' cmbSexo
        ' 
        cmbSexo.BackColor = Color.Transparent
        cmbSexo.BackColorPnl = Color.WhiteSmoke
        cmbSexo.BorderColor = Color.LightGray
        cmbSexo.BorderSize = 1
        cmbSexo.CampoRequerido = True
        cmbSexo.ForeColor = Color.Black
        cmbSexo.IndiceSeleccionado = -1
        cmbSexo.LabelColor = Color.DarkSlateGray
        cmbSexo.Location = New Point(3, 183)
        cmbSexo.MensajeError = "Este campo es obligatorio."
        cmbSexo.MostrarError = False
        cmbSexo.Name = "cmbSexo"
        cmbSexo.RadioContornoPanel = 8
        cmbSexo.Size = New Size(343, 80)
        cmbSexo.SombraBackColor = Color.LightGray
        cmbSexo.TabIndex = 7
        cmbSexo.Titulo = "Sexo:"
        cmbSexo.ValorSeleccionado = Nothing
        ' 
        ' txtApellido
        ' 
        txtApellido.BackColor = Color.Transparent
        txtApellido.BorderColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtApellido.BorderRadius = 8
        txtApellido.BorderSize = 1
        txtApellido.CampoRequerido = True
        txtApellido.CapitalizarTexto = True
        txtApellido.CapitalizarTodasLasPalabras = True
        txtApellido.CaracterContraseña = "*"c
        txtApellido.ColorError = Color.Firebrick
        txtApellido.FontField = New Font("Century Gothic", 12F)
        txtApellido.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtApellido.IconoDerechoChar = FontAwesome.Sharp.IconChar.Vcard
        txtApellido.LabelColor = Color.DarkSlateGray
        txtApellido.LabelText = "Apellido:"
        txtApellido.Location = New Point(701, 3)
        txtApellido.MensajeError = "Este campo es obligatorio."
        txtApellido.Name = "txtApellido"
        txtApellido.PaddingAll = 10
        txtApellido.PanelBackColor = Color.White
        txtApellido.Size = New Size(344, 80)
        txtApellido.SombraBackColor = Color.LightGray
        txtApellido.TabIndex = 3
        txtApellido.TextColor = Color.Black
        txtApellido.TextoUsuario = ""
        txtApellido.UsarModoContraseña = False
        txtApellido.ValidarComoCorreo = False
        ' 
        ' cmbZona
        ' 
        cmbZona.BackColor = Color.Transparent
        cmbZona.BackColorPnl = Color.WhiteSmoke
        cmbZona.BorderColor = Color.LightGray
        cmbZona.BorderSize = 1
        cmbZona.CampoRequerido = True
        cmbZona.IndiceSeleccionado = -1
        cmbZona.LabelColor = Color.DarkSlateGray
        cmbZona.Location = New Point(701, 273)
        cmbZona.MensajeError = "Este campo es obligatorio."
        cmbZona.MostrarError = False
        cmbZona.Name = "cmbZona"
        cmbZona.RadioContornoPanel = 8
        cmbZona.Size = New Size(344, 80)
        cmbZona.SombraBackColor = Color.LightGray
        cmbZona.TabIndex = 12
        cmbZona.Titulo = "Zona de habitación:"
        cmbZona.ValorSeleccionado = Nothing
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
        txtTelefono.Location = New Point(352, 273)
        txtTelefono.MascaraPersonalizada = ""
        txtTelefono.MaxCaracteres = 0
        txtTelefono.MensajeError = "Este campo es obligatorio."
        txtTelefono.Name = "txtTelefono"
        txtTelefono.PaddingAll = 10
        txtTelefono.PanelBackColor = Color.White
        txtTelefono.SelectionStart = 0
        txtTelefono.Size = New Size(343, 80)
        txtTelefono.SombraBackColor = Color.LightGray
        txtTelefono.TabIndex = 11
        txtTelefono.TextColor = Color.Black
        txtTelefono.TextoUsuario = ""
        txtTelefono.TipoNumerico = MaskedTextBoxLabelUI.TipoEntradaNumerica.Ninguno
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
        txtEdad.Location = New Point(3, 93)
        txtEdad.MascaraPersonalizada = ""
        txtEdad.MaxCaracteres = 0
        txtEdad.MensajeError = "Este campo es obligatorio."
        txtEdad.Name = "txtEdad"
        txtEdad.PaddingAll = 10
        txtEdad.PanelBackColor = Color.White
        txtEdad.SelectionStart = 0
        txtEdad.Size = New Size(343, 80)
        txtEdad.SombraBackColor = Color.LightGray
        txtEdad.TabIndex = 4
        txtEdad.TextColor = Color.Black
        txtEdad.TextoUsuario = ""
        txtEdad.TipoNumerico = MaskedTextBoxLabelUI.TipoEntradaNumerica.Entero
        ' 
        ' txtCorreo
        ' 
        txtCorreo.BackColor = Color.Transparent
        txtCorreo.BorderColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtCorreo.BorderRadius = 8
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
        txtCorreo.Location = New Point(3, 273)
        txtCorreo.MensajeError = "Este campo es obligatorio."
        txtCorreo.Name = "txtCorreo"
        txtCorreo.PaddingAll = 10
        txtCorreo.PanelBackColor = Color.White
        txtCorreo.Size = New Size(343, 80)
        txtCorreo.SombraBackColor = Color.LightGray
        txtCorreo.TabIndex = 10
        txtCorreo.TextColor = Color.Black
        txtCorreo.TextoUsuario = ""
        txtCorreo.UsarModoContraseña = False
        txtCorreo.ValidarComoCorreo = True
        ' 
        ' cmbNacionalidad
        ' 
        cmbNacionalidad.BackColor = Color.Transparent
        cmbNacionalidad.BackColorPnl = Color.WhiteSmoke
        cmbNacionalidad.BorderColor = Color.LightGray
        cmbNacionalidad.BorderSize = 1
        cmbNacionalidad.CampoRequerido = True
        cmbNacionalidad.IndiceSeleccionado = -1
        cmbNacionalidad.LabelColor = Color.DarkSlateGray
        cmbNacionalidad.Location = New Point(352, 93)
        cmbNacionalidad.MensajeError = "Este campo es obligatorio."
        cmbNacionalidad.MostrarError = False
        cmbNacionalidad.Name = "cmbNacionalidad"
        cmbNacionalidad.RadioContornoPanel = 8
        cmbNacionalidad.Size = New Size(343, 80)
        cmbNacionalidad.SombraBackColor = Color.LightGray
        cmbNacionalidad.TabIndex = 5
        cmbNacionalidad.Titulo = "Nacionalidad:"
        cmbNacionalidad.ValorSeleccionado = Nothing
        ' 
        ' cmbEstadoCivil
        ' 
        cmbEstadoCivil.BackColor = Color.Transparent
        cmbEstadoCivil.BackColorPnl = Color.WhiteSmoke
        cmbEstadoCivil.BorderColor = Color.LightGray
        cmbEstadoCivil.BorderSize = 1
        cmbEstadoCivil.CampoRequerido = True
        cmbEstadoCivil.IndiceSeleccionado = -1
        cmbEstadoCivil.LabelColor = Color.DarkSlateGray
        cmbEstadoCivil.Location = New Point(701, 93)
        cmbEstadoCivil.MensajeError = "Este campo es obligatorio."
        cmbEstadoCivil.MostrarError = False
        cmbEstadoCivil.Name = "cmbEstadoCivil"
        cmbEstadoCivil.RadioContornoPanel = 8
        cmbEstadoCivil.Size = New Size(344, 80)
        cmbEstadoCivil.SombraBackColor = Color.LightGray
        cmbEstadoCivil.TabIndex = 6
        cmbEstadoCivil.Titulo = "Estado Civil:"
        cmbEstadoCivil.ValorSeleccionado = Nothing
        ' 
        ' cmbCargo
        ' 
        cmbCargo.BackColor = Color.Transparent
        cmbCargo.BackColorPnl = Color.WhiteSmoke
        cmbCargo.BorderColor = Color.LightGray
        cmbCargo.BorderSize = 1
        cmbCargo.CampoRequerido = True
        cmbCargo.IndiceSeleccionado = -1
        cmbCargo.LabelColor = Color.DarkSlateGray
        cmbCargo.Location = New Point(701, 183)
        cmbCargo.MensajeError = "Este campo es obligatorio."
        cmbCargo.MostrarError = False
        cmbCargo.Name = "cmbCargo"
        cmbCargo.RadioContornoPanel = 8
        cmbCargo.Size = New Size(344, 80)
        cmbCargo.SombraBackColor = Color.LightGray
        cmbCargo.TabIndex = 9
        cmbCargo.Titulo = "Cargo:"
        cmbCargo.ValorSeleccionado = Nothing
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
        pnlEncabezado.Controls.Add(btnAccion)
        pnlEncabezado.Controls.Add(Headerui1)
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
        btnAccion.BackColor = Color.FromArgb(CByte(0), CByte(191), CByte(192))
        btnAccion.ColorBase = Color.FromArgb(CByte(255), CByte(193), CByte(7))
        btnAccion.ColorHover = Color.FromArgb(CByte(255), CByte(179), CByte(0))
        btnAccion.ColorInternoFondo = Color.FromArgb(CByte(255), CByte(193), CByte(7))
        btnAccion.ColorPresionado = Color.FromArgb(CByte(255), CByte(160), CByte(0))
        btnAccion.ColorTexto = Color.Black
        btnAccion.Cursor = Cursors.Hand
        btnAccion.EstiloBoton = CommandButtonUI.EstiloBootstrap.Warning
        btnAccion.Font = New Font("Century Gothic", 10F, FontStyle.Bold)
        btnAccion.Icono = FontAwesome.Sharp.IconChar.Warning
        btnAccion.Location = New Point(1084, 12)
        btnAccion.Name = "btnAccion"
        btnAccion.RadioBorde = 8
        btnAccion.Size = New Size(180, 40)
        btnAccion.TabIndex = 19
        btnAccion.Texto = "Guardar Datos"
        ' 
        ' Headerui1
        ' 
        Headerui1.BackColor = Color.FromArgb(CByte(0), CByte(192), CByte(190))
        Headerui1.ColorFondo = Color.FromArgb(CByte(0), CByte(192), CByte(192))
        Headerui1.ColorTexto = Color.WhiteSmoke
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
        ' frmEmpleado
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1274, 626)
        Controls.Add(pnlContenedor)
        Name = "frmEmpleado"
        Text = "frmEmpleado"
        WindowState = FormWindowState.Maximized
        pnlContenedor.ResumeLayout(False)
        pnlContenido.ResumeLayout(False)
        TableLayoutPanel1.ResumeLayout(False)
        CType(imgFoto, ComponentModel.ISupportInitialize).EndInit()
        pnlEncabezado.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents pnlContenedor As Panel
    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents Headerui1 As HeaderUI
    Friend WithEvents btnAccion As CommandButtonUI
    Friend WithEvents pnlContenido As Panel
    Friend WithEvents btnEliminarFoto As FontAwesome.Sharp.IconButton
    Friend WithEvents btnGuardarFoto As FontAwesome.Sharp.IconButton
    Friend WithEvents txtDireccion As MultilineTextBoxLabelUI
    Friend WithEvents txtTelefono As MaskedTextBoxLabelUI
    Friend WithEvents txtCorreo As TextBoxLabelUI
    Friend WithEvents cmbZona As ComboBoxLabelUI
    Friend WithEvents cmbCargo As ComboBoxLabelUI
    Friend WithEvents cmbEstadoCivil As ComboBoxLabelUI
    Friend WithEvents cmbNacionalidad As ComboBoxLabelUI
    Friend WithEvents txtApellido As TextBoxLabelUI
    Friend WithEvents txtNombre As TextBoxLabelUI
    Friend WithEvents txtCedula As MaskedTextBoxLabelUI
    Friend WithEvents imgFoto As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents txtEdad As MaskedTextBoxLabelUI
    Friend WithEvents cmbSexo As ComboBoxLabelUI
    Friend WithEvents txtFechaNac As DateBoxLabelUI
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents swMarketing As ToggleSwitchUI
    Friend WithEvents swGerente As ToggleSwitchUI
    Friend WithEvents swOptometrista As ToggleSwitchUI
    Friend WithEvents swAsesor As ToggleSwitchUI
    Friend WithEvents Labelui1 As LabelUI
End Class
