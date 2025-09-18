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
        Panel2 = New Panel()
        chkOptometrista = New CheckBoxLabelUI()
        chkMarketing = New CheckBoxLabelUI()
        chkAsesor = New CheckBoxLabelUI()
        chkGerente = New CheckBoxLabelUI()
        Panelui4 = New PanelUI()
        txtDireccion = New MultilineTextBoxLabelUI()
        Panelui3 = New PanelUI()
        TableLayoutPanel1 = New TableLayoutPanel()
        txtCedula = New NumericTextBoxLabelUI()
        txtNombre = New TextOnlyTextBoxLabelUI()
        txtApellido = New TextOnlyTextBoxLabelUI()
        txtEdad = New NumericTextBoxLabelUI()
        cmbNacionalidad = New ComboBoxLayoutUI()
        cmbEstadoCivil = New ComboBoxLayoutUI()
        cmbSexo = New ComboBoxLayoutUI()
        txtFechaNac = New DatePickerProUI()
        cmbCargo = New ComboBoxLayoutUI()
        txtCorreo = New EmailTextBoxLabelUI()
        txtTelefono = New TextOnlyTextBoxLabelUI()
        cmbZona = New ComboBoxLayoutUI()
        Panelui2 = New PanelUI()
        TableLayoutPanel2 = New TableLayoutPanel()
        imgFoto = New FontAwesome.Sharp.IconPictureBox()
        TableLayoutPanel3 = New TableLayoutPanel()
        btnGuardarFoto = New FontAwesome.Sharp.IconButton()
        btnEliminarFoto = New FontAwesome.Sharp.IconButton()
        Panelui1 = New PanelUI()
        pnlEncabezado = New Panel()
        btnAccion = New CommandButtonUI()
        Headerui1 = New HeaderUI()
        pnlContenedor.SuspendLayout()
        pnlContenido.SuspendLayout()
        Panel2.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        CType(imgFoto, ComponentModel.ISupportInitialize).BeginInit()
        TableLayoutPanel3.SuspendLayout()
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
        pnlContenedor.Size = New Size(1304, 661)
        pnlContenedor.TabIndex = 0
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(0), CByte(192), CByte(192))
        Panel1.Dock = DockStyle.Bottom
        Panel1.Location = New Point(0, 605)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1304, 56)
        Panel1.TabIndex = 2
        ' 
        ' pnlContenido
        ' 
        pnlContenido.AutoScroll = True
        pnlContenido.Controls.Add(Panel2)
        pnlContenido.Controls.Add(Panelui4)
        pnlContenido.Controls.Add(txtDireccion)
        pnlContenido.Controls.Add(Panelui3)
        pnlContenido.Controls.Add(TableLayoutPanel1)
        pnlContenido.Controls.Add(Panelui2)
        pnlContenido.Controls.Add(TableLayoutPanel2)
        pnlContenido.Controls.Add(Panelui1)
        pnlContenido.Dock = DockStyle.Fill
        pnlContenido.Location = New Point(0, 60)
        pnlContenido.Margin = New Padding(3, 30, 3, 3)
        pnlContenido.Name = "pnlContenido"
        pnlContenido.Padding = New Padding(10, 30, 0, 0)
        pnlContenido.Size = New Size(1304, 601)
        pnlContenido.TabIndex = 1
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(chkOptometrista)
        Panel2.Controls.Add(chkMarketing)
        Panel2.Controls.Add(chkAsesor)
        Panel2.Controls.Add(chkGerente)
        Panel2.Location = New Point(789, 402)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(489, 126)
        Panel2.TabIndex = 42
        ' 
        ' chkOptometrista
        ' 
        chkOptometrista.BackColor = Color.Transparent
        chkOptometrista.BorderColor = Color.FromArgb(CByte(0), CByte(188), CByte(212))
        chkOptometrista.Checked = False
        chkOptometrista.CheckedColor = Color.LightBlue
        chkOptometrista.Checkeds = False
        chkOptometrista.Location = New Point(55, 70)
        chkOptometrista.Name = "chkOptometrista"
        chkOptometrista.Size = New Size(176, 28)
        chkOptometrista.TabIndex = 15
        chkOptometrista.Texto = "Optometrista"
        chkOptometrista.UncheckedColor = Color.WhiteSmoke
        ' 
        ' chkMarketing
        ' 
        chkMarketing.BackColor = Color.Transparent
        chkMarketing.BorderColor = Color.FromArgb(CByte(0), CByte(188), CByte(212))
        chkMarketing.Checked = False
        chkMarketing.CheckedColor = Color.LightBlue
        chkMarketing.Checkeds = False
        chkMarketing.Location = New Point(276, 70)
        chkMarketing.Name = "chkMarketing"
        chkMarketing.Size = New Size(176, 28)
        chkMarketing.TabIndex = 16
        chkMarketing.Texto = "Marketing"
        chkMarketing.UncheckedColor = Color.WhiteSmoke
        ' 
        ' chkAsesor
        ' 
        chkAsesor.BackColor = Color.Transparent
        chkAsesor.BorderColor = Color.FromArgb(CByte(0), CByte(188), CByte(212))
        chkAsesor.Checked = False
        chkAsesor.CheckedColor = Color.LightBlue
        chkAsesor.Checkeds = False
        chkAsesor.Location = New Point(276, 19)
        chkAsesor.Name = "chkAsesor"
        chkAsesor.Size = New Size(176, 28)
        chkAsesor.TabIndex = 14
        chkAsesor.Texto = "Asesor"
        chkAsesor.UncheckedColor = Color.WhiteSmoke
        ' 
        ' chkGerente
        ' 
        chkGerente.BackColor = Color.Transparent
        chkGerente.BorderColor = Color.FromArgb(CByte(0), CByte(188), CByte(212))
        chkGerente.Checked = False
        chkGerente.CheckedColor = Color.LightBlue
        chkGerente.Checkeds = False
        chkGerente.Location = New Point(55, 19)
        chkGerente.Name = "chkGerente"
        chkGerente.Size = New Size(176, 28)
        chkGerente.TabIndex = 13
        chkGerente.Texto = "Gerente"
        chkGerente.UncheckedColor = Color.WhiteSmoke
        ' 
        ' Panelui4
        ' 
        Panelui4.BackColor = Color.Transparent
        Panelui4.BackColorContenedor = Color.Transparent
        Panelui4.BorderColor = Color.Silver
        Panelui4.BorderRadius = 20
        Panelui4.BorderSize = 1
        Panelui4.CardBackColor = Color.White
        Panelui4.Estilo = PanelUI.EstiloCard.None
        Panelui4.Location = New Point(780, 395)
        Panelui4.Name = "Panelui4"
        Panelui4.ShadowColor = Color.FromArgb(CByte(0), CByte(188), CByte(212))
        Panelui4.Size = New Size(512, 144)
        Panelui4.TabIndex = 41
        Panelui4.Texto = ""
        ' 
        ' txtDireccion
        ' 
        txtDireccion.AlturaMultilinea = 80
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
        txtDireccion.Location = New Point(21, 402)
        txtDireccion.MensajeError = "Este campo es obligatorio."
        txtDireccion.Multilinea = True
        txtDireccion.Name = "txtDireccion"
        txtDireccion.PaddingAll = 10
        txtDireccion.PanelBackColor = Color.White
        txtDireccion.Placeholder = "Escribaaa aquí..."
        txtDireccion.PlaceholderColor = Color.Gray
        txtDireccion.Size = New Size(742, 126)
        txtDireccion.TabIndex = 12
        txtDireccion.TextColor = Color.Black
        txtDireccion.TextoString = Nothing
        txtDireccion.TextString = ""
        ' 
        ' Panelui3
        ' 
        Panelui3.BackColor = Color.Transparent
        Panelui3.BackColorContenedor = Color.Transparent
        Panelui3.BorderColor = Color.Silver
        Panelui3.BorderRadius = 20
        Panelui3.BorderSize = 1
        Panelui3.CardBackColor = Color.White
        Panelui3.Estilo = PanelUI.EstiloCard.None
        Panelui3.Location = New Point(15, 395)
        Panelui3.Name = "Panelui3"
        Panelui3.ShadowColor = Color.FromArgb(CByte(0), CByte(192), CByte(190))
        Panelui3.Size = New Size(759, 144)
        Panelui3.TabIndex = 40
        Panelui3.Texto = ""
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 3
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.33333F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333359F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333359F))
        TableLayoutPanel1.Controls.Add(txtCedula, 0, 0)
        TableLayoutPanel1.Controls.Add(txtNombre, 1, 0)
        TableLayoutPanel1.Controls.Add(txtApellido, 2, 0)
        TableLayoutPanel1.Controls.Add(txtEdad, 0, 1)
        TableLayoutPanel1.Controls.Add(cmbNacionalidad, 1, 1)
        TableLayoutPanel1.Controls.Add(cmbEstadoCivil, 2, 1)
        TableLayoutPanel1.Controls.Add(cmbSexo, 0, 2)
        TableLayoutPanel1.Controls.Add(txtFechaNac, 1, 2)
        TableLayoutPanel1.Controls.Add(cmbCargo, 2, 2)
        TableLayoutPanel1.Controls.Add(txtCorreo, 0, 3)
        TableLayoutPanel1.Controls.Add(txtTelefono, 1, 3)
        TableLayoutPanel1.Controls.Add(cmbZona, 2, 3)
        TableLayoutPanel1.Location = New Point(266, 13)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 4
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 90F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 90F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 90F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 90F))
        TableLayoutPanel1.Size = New Size(1015, 356)
        TableLayoutPanel1.TabIndex = 26
        ' 
        ' txtCedula
        ' 
        txtCedula.BackColor = Color.Transparent
        txtCedula.CampoRequerido = True
        txtCedula.CapitalizarTexto = False
        txtCedula.CapitalizarTodasLasPalabras = False
        txtCedula.ColorTitulo = Color.DarkSlateGray
        txtCedula.Dock = DockStyle.Fill
        txtCedula.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtCedula.IconoDerechoChar = FontAwesome.Sharp.IconChar.Hashtag
        txtCedula.Location = New Point(3, 3)
        txtCedula.MaxCaracteres = 0
        txtCedula.MensajeError = "Este campo es requerido"
        txtCedula.MinCaracteres = 0
        txtCedula.Name = "txtCedula"
        txtCedula.PaddingIzquierda = 8
        txtCedula.PaddingIzquierdaIcono = 10
        txtCedula.Placeholder = "Ingrese número de cédula..."
        txtCedula.PlaceholderColor = Color.Gray
        txtCedula.Size = New Size(332, 84)
        txtCedula.TabIndex = 0
        txtCedula.TextoLabel = "Cédula:"
        txtCedula.TextString = ""
        txtCedula.ValidarComoCorreo = False
        ' 
        ' txtNombre
        ' 
        txtNombre.BackColor = Color.Transparent
        txtNombre.CampoRequerido = True
        txtNombre.CapitalizarTexto = True
        txtNombre.CapitalizarTodasLasPalabras = True
        txtNombre.ColorTitulo = Color.DarkSlateGray
        txtNombre.Dock = DockStyle.Fill
        txtNombre.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtNombre.IconoDerechoChar = FontAwesome.Sharp.IconChar.Vcard
        txtNombre.Location = New Point(341, 3)
        txtNombre.MaxCaracteres = 0
        txtNombre.MensajeError = "Campo requerido"
        txtNombre.MinCaracteres = 0
        txtNombre.Name = "txtNombre"
        txtNombre.PaddingIzquierda = 8
        txtNombre.PaddingIzquierdaIcono = 10
        txtNombre.Placeholder = "Ingrese los nombres..."
        txtNombre.PlaceholderColor = Color.Gray
        txtNombre.Size = New Size(332, 84)
        txtNombre.TabIndex = 1
        txtNombre.TextoLabel = "Nombres:"
        txtNombre.TextString = ""
        txtNombre.ValidarComoCorreo = False
        ' 
        ' txtApellido
        ' 
        txtApellido.BackColor = Color.Transparent
        txtApellido.CampoRequerido = True
        txtApellido.CapitalizarTexto = True
        txtApellido.CapitalizarTodasLasPalabras = True
        txtApellido.ColorTitulo = Color.DarkSlateGray
        txtApellido.Dock = DockStyle.Fill
        txtApellido.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtApellido.IconoDerechoChar = FontAwesome.Sharp.IconChar.Vcard
        txtApellido.Location = New Point(679, 3)
        txtApellido.MaxCaracteres = 0
        txtApellido.MensajeError = "Campo requerido"
        txtApellido.MinCaracteres = 0
        txtApellido.Name = "txtApellido"
        txtApellido.PaddingIzquierda = 8
        txtApellido.PaddingIzquierdaIcono = 10
        txtApellido.Placeholder = "Ingrese los apellidos..."
        txtApellido.PlaceholderColor = Color.Gray
        txtApellido.Size = New Size(333, 84)
        txtApellido.TabIndex = 2
        txtApellido.TextoLabel = "Apellidos:"
        txtApellido.TextString = ""
        txtApellido.ValidarComoCorreo = False
        ' 
        ' txtEdad
        ' 
        txtEdad.BackColor = Color.Transparent
        txtEdad.CampoRequerido = True
        txtEdad.CapitalizarTexto = False
        txtEdad.CapitalizarTodasLasPalabras = False
        txtEdad.ColorTitulo = Color.DarkSlateGray
        txtEdad.Dock = DockStyle.Fill
        txtEdad.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtEdad.IconoDerechoChar = FontAwesome.Sharp.IconChar.Hashtag
        txtEdad.Location = New Point(3, 93)
        txtEdad.MaxCaracteres = 0
        txtEdad.MensajeError = "Campo requerido"
        txtEdad.MinCaracteres = 0
        txtEdad.Name = "txtEdad"
        txtEdad.PaddingIzquierda = 8
        txtEdad.PaddingIzquierdaIcono = 10
        txtEdad.Placeholder = "Ingrese la edad..."
        txtEdad.PlaceholderColor = Color.Gray
        txtEdad.Size = New Size(332, 84)
        txtEdad.TabIndex = 3
        txtEdad.TextoLabel = "Edad:"
        txtEdad.TextString = ""
        txtEdad.ValidarComoCorreo = False
        ' 
        ' cmbNacionalidad
        ' 
        cmbNacionalidad.BackColor = Color.Transparent
        cmbNacionalidad.CampoRequerido = False
        cmbNacionalidad.ColorTitulo = Color.DarkSlateGray
        cmbNacionalidad.Dock = DockStyle.Fill
        cmbNacionalidad.IndiceSeleccionado = -1
        cmbNacionalidad.Location = New Point(341, 93)
        cmbNacionalidad.MensajeError = "Campo requerido"
        cmbNacionalidad.Name = "cmbNacionalidad"
        cmbNacionalidad.Placeholder = "Selecciones una Opcion..."
        cmbNacionalidad.PlaceholderColor = Color.Gray
        cmbNacionalidad.Size = New Size(332, 84)
        cmbNacionalidad.TabIndex = 4
        cmbNacionalidad.TextoLabel = "Nacionaliad:"
        cmbNacionalidad.ValorSeleccionado = Nothing
        ' 
        ' cmbEstadoCivil
        ' 
        cmbEstadoCivil.BackColor = Color.Transparent
        cmbEstadoCivil.CampoRequerido = False
        cmbEstadoCivil.ColorTitulo = Color.DarkSlateGray
        cmbEstadoCivil.Dock = DockStyle.Fill
        cmbEstadoCivil.IndiceSeleccionado = -1
        cmbEstadoCivil.Location = New Point(679, 93)
        cmbEstadoCivil.MensajeError = "Campo requerido"
        cmbEstadoCivil.Name = "cmbEstadoCivil"
        cmbEstadoCivil.Placeholder = "Selecciones una Opcion..."
        cmbEstadoCivil.PlaceholderColor = Color.Gray
        cmbEstadoCivil.Size = New Size(333, 84)
        cmbEstadoCivil.TabIndex = 5
        cmbEstadoCivil.TextoLabel = "Estado Civil:"
        cmbEstadoCivil.ValorSeleccionado = Nothing
        ' 
        ' cmbSexo
        ' 
        cmbSexo.BackColor = Color.Transparent
        cmbSexo.CampoRequerido = False
        cmbSexo.ColorTitulo = Color.DarkSlateGray
        cmbSexo.Dock = DockStyle.Fill
        cmbSexo.IndiceSeleccionado = -1
        cmbSexo.Location = New Point(3, 183)
        cmbSexo.MensajeError = "Campo requerido"
        cmbSexo.Name = "cmbSexo"
        cmbSexo.Placeholder = "Selecciones una Opcion..."
        cmbSexo.PlaceholderColor = Color.Gray
        cmbSexo.Size = New Size(332, 84)
        cmbSexo.TabIndex = 6
        cmbSexo.TextoLabel = "Sexo:"
        cmbSexo.ValorSeleccionado = Nothing
        ' 
        ' txtFechaNac
        ' 
        txtFechaNac.BackColor = Color.Transparent
        txtFechaNac.BorderColor = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        txtFechaNac.BorderRadius = 8
        txtFechaNac.BorderSize = 1
        txtFechaNac.CampoRequerido = True
        txtFechaNac.Dock = DockStyle.Fill
        txtFechaNac.FechaSeleccionada = New Date(2025, 9, 17, 0, 0, 0, 0)
        txtFechaNac.FontField = New Font("Century Gothic", 12F)
        txtFechaNac.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtFechaNac.IconoDerechoChar = FontAwesome.Sharp.IconChar.None
        txtFechaNac.LabelColor = Color.DarkSlateGray
        txtFechaNac.LabelText = "Fecha:"
        txtFechaNac.Location = New Point(341, 183)
        txtFechaNac.MensajeError = "Este campo es requerido"
        txtFechaNac.Name = "txtFechaNac"
        txtFechaNac.PaddingAll = 10
        txtFechaNac.PanelBackColor = Color.White
        txtFechaNac.Size = New Size(332, 84)
        txtFechaNac.TabIndex = 7
        txtFechaNac.TextColor = Color.Black
        txtFechaNac.ValorFecha = New Date(2025, 9, 17, 0, 0, 0, 0)
        ' 
        ' cmbCargo
        ' 
        cmbCargo.BackColor = Color.Transparent
        cmbCargo.CampoRequerido = True
        cmbCargo.ColorTitulo = Color.DarkSlateGray
        cmbCargo.Dock = DockStyle.Fill
        cmbCargo.IndiceSeleccionado = -1
        cmbCargo.Location = New Point(679, 183)
        cmbCargo.MensajeError = "Campo requerido"
        cmbCargo.Name = "cmbCargo"
        cmbCargo.Placeholder = "Selecciones una Opcion..."
        cmbCargo.PlaceholderColor = Color.Gray
        cmbCargo.Size = New Size(333, 84)
        cmbCargo.TabIndex = 8
        cmbCargo.TextoLabel = "Cargo:"
        cmbCargo.ValorSeleccionado = Nothing
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
        txtCorreo.Location = New Point(3, 273)
        txtCorreo.MaxCaracteres = 0
        txtCorreo.MensajeError = "Campo requerido"
        txtCorreo.MinCaracteres = 0
        txtCorreo.Name = "txtCorreo"
        txtCorreo.PaddingIzquierda = 8
        txtCorreo.PaddingIzquierdaIcono = 10
        txtCorreo.Placeholder = "Ingrese el correo..."
        txtCorreo.PlaceholderColor = Color.Gray
        txtCorreo.Size = New Size(332, 84)
        txtCorreo.TabIndex = 9
        txtCorreo.TextoLabel = "Correo electrónico:"
        txtCorreo.TextString = ""
        txtCorreo.ValidarComoCorreo = True
        ' 
        ' txtTelefono
        ' 
        txtTelefono.BackColor = Color.Transparent
        txtTelefono.CampoRequerido = True
        txtTelefono.CapitalizarTexto = False
        txtTelefono.CapitalizarTodasLasPalabras = False
        txtTelefono.ColorTitulo = Color.DarkSlateGray
        txtTelefono.Dock = DockStyle.Fill
        txtTelefono.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtTelefono.IconoDerechoChar = FontAwesome.Sharp.IconChar.Font
        txtTelefono.Location = New Point(341, 273)
        txtTelefono.MaxCaracteres = 0
        txtTelefono.MensajeError = "Este campo es requerido"
        txtTelefono.MinCaracteres = 0
        txtTelefono.Name = "txtTelefono"
        txtTelefono.PaddingIzquierda = 8
        txtTelefono.PaddingIzquierdaIcono = 10
        txtTelefono.Placeholder = "Ingrese número de telf..."
        txtTelefono.PlaceholderColor = Color.Gray
        txtTelefono.Size = New Size(332, 84)
        txtTelefono.TabIndex = 10
        txtTelefono.TextoLabel = "Número de Teléfono:"
        txtTelefono.TextString = ""
        txtTelefono.ValidarComoCorreo = False
        ' 
        ' cmbZona
        ' 
        cmbZona.BackColor = Color.Transparent
        cmbZona.CampoRequerido = True
        cmbZona.ColorTitulo = Color.DarkSlateGray
        cmbZona.Dock = DockStyle.Fill
        cmbZona.IndiceSeleccionado = -1
        cmbZona.Location = New Point(679, 273)
        cmbZona.MensajeError = "Campo requerido"
        cmbZona.Name = "cmbZona"
        cmbZona.Placeholder = "Selecciones una Opcion..."
        cmbZona.PlaceholderColor = Color.Gray
        cmbZona.Size = New Size(333, 84)
        cmbZona.TabIndex = 11
        cmbZona.TextoLabel = "Zona:"
        cmbZona.ValorSeleccionado = Nothing
        ' 
        ' Panelui2
        ' 
        Panelui2.BackColor = Color.Transparent
        Panelui2.BackColorContenedor = Color.Transparent
        Panelui2.BorderColor = Color.Silver
        Panelui2.BorderRadius = 20
        Panelui2.BorderSize = 1
        Panelui2.CardBackColor = Color.White
        Panelui2.Estilo = PanelUI.EstiloCard.None
        Panelui2.Location = New Point(259, 6)
        Panelui2.Name = "Panelui2"
        Panelui2.ShadowColor = Color.FromArgb(CByte(0), CByte(192), CByte(190))
        Panelui2.Size = New Size(1033, 380)
        Panelui2.TabIndex = 39
        Panelui2.Texto = ""
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 1
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.Controls.Add(imgFoto, 0, 0)
        TableLayoutPanel2.Controls.Add(TableLayoutPanel3, 0, 1)
        TableLayoutPanel2.Location = New Point(12, 13)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 2
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 280F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 120F))
        TableLayoutPanel2.Size = New Size(231, 364)
        TableLayoutPanel2.TabIndex = 38
        ' 
        ' imgFoto
        ' 
        imgFoto.BackColor = Color.White
        imgFoto.BorderStyle = BorderStyle.FixedSingle
        imgFoto.Dock = DockStyle.Fill
        imgFoto.ForeColor = SystemColors.AppWorkspace
        imgFoto.IconChar = FontAwesome.Sharp.IconChar.UserGear
        imgFoto.IconColor = SystemColors.AppWorkspace
        imgFoto.IconFont = FontAwesome.Sharp.IconFont.Auto
        imgFoto.IconSize = 225
        imgFoto.Location = New Point(3, 3)
        imgFoto.Name = "imgFoto"
        imgFoto.Size = New Size(225, 274)
        imgFoto.TabIndex = 19
        imgFoto.TabStop = False
        ' 
        ' TableLayoutPanel3
        ' 
        TableLayoutPanel3.ColumnCount = 2
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel3.Controls.Add(btnGuardarFoto, 0, 0)
        TableLayoutPanel3.Controls.Add(btnEliminarFoto, 1, 0)
        TableLayoutPanel3.Dock = DockStyle.Top
        TableLayoutPanel3.Location = New Point(3, 283)
        TableLayoutPanel3.Name = "TableLayoutPanel3"
        TableLayoutPanel3.RowCount = 1
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel3.Size = New Size(225, 76)
        TableLayoutPanel3.TabIndex = 20
        ' 
        ' btnGuardarFoto
        ' 
        btnGuardarFoto.Dock = DockStyle.Fill
        btnGuardarFoto.FlatAppearance.BorderSize = 0
        btnGuardarFoto.FlatStyle = FlatStyle.Flat
        btnGuardarFoto.Font = New Font("Century Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnGuardarFoto.IconChar = FontAwesome.Sharp.IconChar.FolderOpen
        btnGuardarFoto.IconColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        btnGuardarFoto.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnGuardarFoto.IconSize = 40
        btnGuardarFoto.Location = New Point(3, 3)
        btnGuardarFoto.Name = "btnGuardarFoto"
        btnGuardarFoto.Size = New Size(106, 70)
        btnGuardarFoto.TabIndex = 22
        btnGuardarFoto.Text = "Agregar"
        btnGuardarFoto.TextImageRelation = TextImageRelation.ImageAboveText
        btnGuardarFoto.UseVisualStyleBackColor = True
        ' 
        ' btnEliminarFoto
        ' 
        btnEliminarFoto.Dock = DockStyle.Fill
        btnEliminarFoto.FlatAppearance.BorderSize = 0
        btnEliminarFoto.FlatStyle = FlatStyle.Flat
        btnEliminarFoto.Font = New Font("Century Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnEliminarFoto.IconChar = FontAwesome.Sharp.IconChar.TrashRestore
        btnEliminarFoto.IconColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        btnEliminarFoto.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnEliminarFoto.IconSize = 40
        btnEliminarFoto.Location = New Point(115, 3)
        btnEliminarFoto.Name = "btnEliminarFoto"
        btnEliminarFoto.Size = New Size(107, 70)
        btnEliminarFoto.TabIndex = 23
        btnEliminarFoto.Text = "Remover"
        btnEliminarFoto.TextImageRelation = TextImageRelation.ImageAboveText
        btnEliminarFoto.UseVisualStyleBackColor = True
        ' 
        ' Panelui1
        ' 
        Panelui1.BackColor = Color.Transparent
        Panelui1.BackColorContenedor = Color.Transparent
        Panelui1.BorderColor = Color.Silver
        Panelui1.BorderRadius = 20
        Panelui1.BorderSize = 1
        Panelui1.CardBackColor = Color.White
        Panelui1.Estilo = PanelUI.EstiloCard.None
        Panelui1.Location = New Point(7, 6)
        Panelui1.Name = "Panelui1"
        Panelui1.ShadowColor = Color.FromArgb(CByte(0), CByte(192), CByte(190))
        Panelui1.Size = New Size(245, 380)
        Panelui1.TabIndex = 37
        Panelui1.Texto = ""
        ' 
        ' pnlEncabezado
        ' 
        pnlEncabezado.Controls.Add(btnAccion)
        pnlEncabezado.Controls.Add(Headerui1)
        pnlEncabezado.Dock = DockStyle.Top
        pnlEncabezado.Location = New Point(0, 0)
        pnlEncabezado.Name = "pnlEncabezado"
        pnlEncabezado.Size = New Size(1304, 60)
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
        btnAccion.ColorTexto = Color.WhiteSmoke
        btnAccion.Cursor = Cursors.Hand
        btnAccion.EstiloBoton = CommandButtonUI.EstiloBootstrap.Warning
        btnAccion.Font = New Font("Century Gothic", 10F, FontStyle.Bold)
        btnAccion.Icono = FontAwesome.Sharp.IconChar.Warning
        btnAccion.Location = New Point(1114, 12)
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
        Headerui1.Size = New Size(1304, 60)
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
        ClientSize = New Size(1304, 661)
        Controls.Add(pnlContenedor)
        Name = "frmEmpleado"
        Text = "frmEmpleado"
        WindowState = FormWindowState.Maximized
        pnlContenedor.ResumeLayout(False)
        pnlContenido.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel2.ResumeLayout(False)
        CType(imgFoto, ComponentModel.ISupportInitialize).EndInit()
        TableLayoutPanel3.ResumeLayout(False)
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
    Friend WithEvents imgFoto As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtCedula As NumericTextBoxLabelUI
    Friend WithEvents txtNombre As TextOnlyTextBoxLabelUI
    Friend WithEvents txtApellido As TextOnlyTextBoxLabelUI
    Friend WithEvents txtEdad As NumericTextBoxLabelUI
    Friend WithEvents cmbNacionalidad As ComboBoxLayoutUI
    Friend WithEvents cmbEstadoCivil As ComboBoxLayoutUI
    Friend WithEvents cmbSexo As ComboBoxLayoutUI
    Friend WithEvents txtFechaNac As DatePickerProUI
    Friend WithEvents cmbCargo As ComboBoxLayoutUI
    Friend WithEvents txtCorreo As EmailTextBoxLabelUI
    Friend WithEvents txtTelefono As TextOnlyTextBoxLabelUI
    Friend WithEvents cmbZona As ComboBoxLayoutUI
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Panelui1 As PanelUI
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Panelui2 As PanelUI
    Friend WithEvents txtDireccion As MultilineTextBoxLabelUI
    Friend WithEvents Panelui3 As PanelUI
    Friend WithEvents Panelui4 As PanelUI
    Friend WithEvents Panel2 As Panel
    Friend WithEvents chkGerente As CheckBoxLabelUI
    Friend WithEvents chkOptometrista As CheckBoxLabelUI
    Friend WithEvents chkMarketing As CheckBoxLabelUI
    Friend WithEvents chkAsesor As CheckBoxLabelUI
End Class
