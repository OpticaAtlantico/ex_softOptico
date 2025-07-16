
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Empleado
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        pnlPrincipal = New Panel()
        pnlDatos = New Panel()
        Panel4 = New Panel()
        Label11 = New Label()
        lnk_EditarUsuario = New LinkLabel()
        lbl_Nombre = New Label()
        lbl_Correo = New Label()
        Label5 = New Label()
        Label33 = New Label()
        Label29 = New Label()
        Label7 = New Label()
        Label32 = New Label()
        lbl_Marketing = New Label()
        Label31 = New Label()
        lbl_Gerente = New Label()
        lbl_Asesor = New Label()
        lblDireccion = New Label()
        lbl_Apellidos = New Label()
        Label13 = New Label()
        Label27 = New Label()
        Label14 = New Label()
        Label15 = New Label()
        Label16 = New Label()
        Panel3 = New Panel()
        lbl_FechaNacimiento = New Label()
        Label6 = New Label()
        lbl_Cargo = New Label()
        lbl_Nacionalidad = New Label()
        lbl_Sexo = New Label()
        lbl_EstadoCivil = New Label()
        lbl_Edad = New Label()
        Label35 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        IconPictureBox1 = New FontAwesome.Sharp.IconPictureBox()
        pnlEntrada = New Panel()
        Panel2 = New Panel()
        pnlEditarDatos = New Panel()
        MultilineTextBoxLabelui1 = New MultilineTextBoxLabelUI()
        MaskedTextBoxLabelui1 = New MaskedTextBoxLabelUI()
        cmbSexo = New cl_ComboBoxLabelUI()
        cmbNacionalidad = New cl_ComboBoxLabelUI()
        cmbEdoCivil = New cl_ComboBoxLabelUI()
        cmbCargo = New cl_ComboBoxLabelUI()
        txtEdad = New TextBoxLabelUI()
        txtApellido = New TextBoxLabelUI()
        txtNombre = New TextBoxLabelUI()
        txtFechaNac = New TextBoxLabelUI()
        txtTelefonos = New TextBoxLabelUI()
        txtCorreo = New TextBoxLabelUI()
        txtCedula = New TextBoxLabelUI()
        btn_Cancelar = New Button()
        btn_Aceptar = New Button()
        pnl_Titulo = New Panel()
        Label17 = New Label()
        pnlPrincipal.SuspendLayout()
        pnlDatos.SuspendLayout()
        Panel4.SuspendLayout()
        CType(IconPictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        pnlEntrada.SuspendLayout()
        Panel2.SuspendLayout()
        pnlEditarDatos.SuspendLayout()
        pnl_Titulo.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlPrincipal
        ' 
        pnlPrincipal.Controls.Add(pnlDatos)
        pnlPrincipal.Dock = DockStyle.Left
        pnlPrincipal.Location = New Point(3, 0)
        pnlPrincipal.Name = "pnlPrincipal"
        pnlPrincipal.Padding = New Padding(20)
        pnlPrincipal.Size = New Size(564, 746)
        pnlPrincipal.TabIndex = 0
        ' 
        ' pnlDatos
        ' 
        pnlDatos.Controls.Add(Panel4)
        pnlDatos.Controls.Add(lnk_EditarUsuario)
        pnlDatos.Controls.Add(lbl_Nombre)
        pnlDatos.Controls.Add(lbl_Correo)
        pnlDatos.Controls.Add(Label5)
        pnlDatos.Controls.Add(Label33)
        pnlDatos.Controls.Add(Label29)
        pnlDatos.Controls.Add(Label7)
        pnlDatos.Controls.Add(Label32)
        pnlDatos.Controls.Add(lbl_Marketing)
        pnlDatos.Controls.Add(Label31)
        pnlDatos.Controls.Add(lbl_Gerente)
        pnlDatos.Controls.Add(lbl_Asesor)
        pnlDatos.Controls.Add(lblDireccion)
        pnlDatos.Controls.Add(lbl_Apellidos)
        pnlDatos.Controls.Add(Label13)
        pnlDatos.Controls.Add(Label27)
        pnlDatos.Controls.Add(Label14)
        pnlDatos.Controls.Add(Label15)
        pnlDatos.Controls.Add(Label16)
        pnlDatos.Controls.Add(Panel3)
        pnlDatos.Controls.Add(lbl_FechaNacimiento)
        pnlDatos.Controls.Add(Label6)
        pnlDatos.Controls.Add(lbl_Cargo)
        pnlDatos.Controls.Add(lbl_Nacionalidad)
        pnlDatos.Controls.Add(lbl_Sexo)
        pnlDatos.Controls.Add(lbl_EstadoCivil)
        pnlDatos.Controls.Add(lbl_Edad)
        pnlDatos.Controls.Add(Label35)
        pnlDatos.Controls.Add(Label4)
        pnlDatos.Controls.Add(Label3)
        pnlDatos.Controls.Add(Label2)
        pnlDatos.Controls.Add(Label1)
        pnlDatos.Controls.Add(IconPictureBox1)
        pnlDatos.Dock = DockStyle.Fill
        pnlDatos.Location = New Point(20, 20)
        pnlDatos.Name = "pnlDatos"
        pnlDatos.Size = New Size(524, 706)
        pnlDatos.TabIndex = 0
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = Color.FromArgb(CByte(0), CByte(120), CByte(215))
        Panel4.Controls.Add(Label11)
        Panel4.Dock = DockStyle.Top
        Panel4.Location = New Point(0, 0)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(524, 57)
        Panel4.TabIndex = 41
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Copperplate Gothic Light", 20F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label11.ForeColor = Color.White
        Label11.Location = New Point(3, 12)
        Label11.Name = "Label11"
        Label11.Size = New Size(184, 30)
        Label11.TabIndex = 30
        Label11.Text = "Mis Datos..."
        ' 
        ' lnk_EditarUsuario
        ' 
        lnk_EditarUsuario.ActiveLinkColor = Color.MidnightBlue
        lnk_EditarUsuario.AutoSize = True
        lnk_EditarUsuario.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lnk_EditarUsuario.ForeColor = Color.Silver
        lnk_EditarUsuario.LinkColor = Color.DarkCyan
        lnk_EditarUsuario.Location = New Point(83, 344)
        lnk_EditarUsuario.Name = "lnk_EditarUsuario"
        lnk_EditarUsuario.Size = New Size(116, 17)
        lnk_EditarUsuario.TabIndex = 40
        lnk_EditarUsuario.TabStop = True
        lnk_EditarUsuario.Text = "Editar Empleado"
        ' 
        ' lbl_Nombre
        ' 
        lbl_Nombre.AutoSize = True
        lbl_Nombre.FlatStyle = FlatStyle.Flat
        lbl_Nombre.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lbl_Nombre.ForeColor = Color.DimGray
        lbl_Nombre.Location = New Point(18, 462)
        lbl_Nombre.Name = "lbl_Nombre"
        lbl_Nombre.Size = New Size(108, 17)
        lbl_Nombre.TabIndex = 39
        lbl_Nombre.Text = "Wilmer Delvalle"
        ' 
        ' lbl_Correo
        ' 
        lbl_Correo.AutoSize = True
        lbl_Correo.FlatStyle = FlatStyle.Flat
        lbl_Correo.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lbl_Correo.ForeColor = Color.DimGray
        lbl_Correo.Location = New Point(18, 574)
        lbl_Correo.Name = "lbl_Correo"
        lbl_Correo.Size = New Size(138, 17)
        lbl_Correo.TabIndex = 39
        lbl_Correo.Text = "wiflores@gmail.com"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.FlatStyle = FlatStyle.Flat
        Label5.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = Color.DimGray
        Label5.Location = New Point(278, 611)
        Label5.Name = "Label5"
        Label5.Size = New Size(131, 17)
        Label5.TabIndex = 39
        Label5.Text = "No Seleccionado..."
        ' 
        ' Label33
        ' 
        Label33.AutoSize = True
        Label33.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label33.Location = New Point(18, 443)
        Label33.Name = "Label33"
        Label33.Size = New Size(83, 19)
        Label33.TabIndex = 38
        Label33.Text = "Nombres:"
        ' 
        ' Label29
        ' 
        Label29.AutoSize = True
        Label29.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label29.Location = New Point(18, 555)
        Label29.Name = "Label29"
        Label29.Size = New Size(65, 19)
        Label29.TabIndex = 38
        Label29.Text = "Correo:"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(278, 592)
        Label7.Name = "Label7"
        Label7.Size = New Size(111, 19)
        Label7.TabIndex = 38
        Label7.Text = "Optometrista:"
        ' 
        ' Label32
        ' 
        Label32.AutoSize = True
        Label32.FlatStyle = FlatStyle.Flat
        Label32.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label32.ForeColor = Color.DimGray
        Label32.Location = New Point(18, 519)
        Label32.Name = "Label32"
        Label32.Size = New Size(98, 17)
        Label32.TabIndex = 37
        Label32.Text = "Administrador"
        ' 
        ' lbl_Marketing
        ' 
        lbl_Marketing.AutoSize = True
        lbl_Marketing.FlatStyle = FlatStyle.Flat
        lbl_Marketing.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lbl_Marketing.ForeColor = Color.DimGray
        lbl_Marketing.Location = New Point(278, 668)
        lbl_Marketing.Name = "lbl_Marketing"
        lbl_Marketing.Size = New Size(131, 17)
        lbl_Marketing.TabIndex = 37
        lbl_Marketing.Text = "No Seleccionado..."
        ' 
        ' Label31
        ' 
        Label31.AutoSize = True
        Label31.FlatStyle = FlatStyle.Flat
        Label31.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label31.ForeColor = Color.DimGray
        Label31.Location = New Point(18, 405)
        Label31.Name = "Label31"
        Label31.Size = New Size(72, 17)
        Label31.TabIndex = 36
        Label31.Text = "12.133.391"
        ' 
        ' lbl_Gerente
        ' 
        lbl_Gerente.AutoSize = True
        lbl_Gerente.FlatStyle = FlatStyle.Flat
        lbl_Gerente.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lbl_Gerente.ForeColor = Color.DimGray
        lbl_Gerente.Location = New Point(278, 554)
        lbl_Gerente.Name = "lbl_Gerente"
        lbl_Gerente.Size = New Size(108, 17)
        lbl_Gerente.TabIndex = 36
        lbl_Gerente.Text = "Seleccionado..."
        ' 
        ' lbl_Asesor
        ' 
        lbl_Asesor.AutoSize = True
        lbl_Asesor.FlatStyle = FlatStyle.Flat
        lbl_Asesor.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lbl_Asesor.ForeColor = Color.DimGray
        lbl_Asesor.Location = New Point(278, 497)
        lbl_Asesor.Name = "lbl_Asesor"
        lbl_Asesor.Size = New Size(108, 17)
        lbl_Asesor.TabIndex = 35
        lbl_Asesor.Text = "Seleccionado..."
        ' 
        ' lblDireccion
        ' 
        lblDireccion.FlatStyle = FlatStyle.Flat
        lblDireccion.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblDireccion.ForeColor = Color.DimGray
        lblDireccion.Location = New Point(278, 389)
        lblDireccion.Name = "lblDireccion"
        lblDireccion.Size = New Size(226, 82)
        lblDireccion.TabIndex = 34
        lblDireccion.Text = "Puerto Ordaz Carrera Cuyuni Av. Principal de San Feliz con Cruce de Las Teodoquildas"
        ' 
        ' lbl_Apellidos
        ' 
        lbl_Apellidos.AutoSize = True
        lbl_Apellidos.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lbl_Apellidos.Location = New Point(18, 500)
        lbl_Apellidos.Name = "lbl_Apellidos"
        lbl_Apellidos.Size = New Size(85, 19)
        lbl_Apellidos.TabIndex = 33
        lbl_Apellidos.Text = "Apellidos:"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label13.Location = New Point(278, 649)
        Label13.Name = "Label13"
        Label13.Size = New Size(91, 19)
        Label13.TabIndex = 33
        Label13.Text = "Marketing:"
        ' 
        ' Label27
        ' 
        Label27.AutoSize = True
        Label27.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label27.Location = New Point(18, 386)
        Label27.Name = "Label27"
        Label27.Size = New Size(71, 19)
        Label27.TabIndex = 32
        Label27.Text = "Cedula:"
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label14.Location = New Point(278, 535)
        Label14.Name = "Label14"
        Label14.Size = New Size(75, 19)
        Label14.TabIndex = 32
        Label14.Text = "Gerente:"
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label15.Location = New Point(278, 478)
        Label15.Name = "Label15"
        Label15.Size = New Size(62, 19)
        Label15.TabIndex = 31
        Label15.Text = "Asesor:"
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label16.Location = New Point(278, 370)
        Label16.Name = "Label16"
        Label16.Size = New Size(87, 19)
        Label16.TabIndex = 30
        Label16.Text = "Dirección:"
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.LightGray
        Panel3.Location = New Point(265, 68)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(3, 305)
        Panel3.TabIndex = 28
        ' 
        ' lbl_FechaNacimiento
        ' 
        lbl_FechaNacimiento.AutoSize = True
        lbl_FechaNacimiento.FlatStyle = FlatStyle.Flat
        lbl_FechaNacimiento.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lbl_FechaNacimiento.ForeColor = Color.DimGray
        lbl_FechaNacimiento.Location = New Point(278, 103)
        lbl_FechaNacimiento.Name = "lbl_FechaNacimiento"
        lbl_FechaNacimiento.Size = New Size(151, 17)
        lbl_FechaNacimiento.TabIndex = 27
        lbl_FechaNacimiento.Text = "10 de Noviembre 1974"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(278, 84)
        Label6.Name = "Label6"
        Label6.Size = New Size(182, 19)
        Label6.TabIndex = 26
        Label6.Text = "Fecha de Nacimiento:"
        ' 
        ' lbl_Cargo
        ' 
        lbl_Cargo.AutoSize = True
        lbl_Cargo.FlatStyle = FlatStyle.Flat
        lbl_Cargo.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lbl_Cargo.ForeColor = Color.DimGray
        lbl_Cargo.Location = New Point(18, 633)
        lbl_Cargo.Name = "lbl_Cargo"
        lbl_Cargo.Size = New Size(98, 17)
        lbl_Cargo.TabIndex = 25
        lbl_Cargo.Text = "Administrador"
        ' 
        ' lbl_Nacionalidad
        ' 
        lbl_Nacionalidad.AutoSize = True
        lbl_Nacionalidad.FlatStyle = FlatStyle.Flat
        lbl_Nacionalidad.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lbl_Nacionalidad.ForeColor = Color.DimGray
        lbl_Nacionalidad.Location = New Point(278, 331)
        lbl_Nacionalidad.Name = "lbl_Nacionalidad"
        lbl_Nacionalidad.Size = New Size(85, 17)
        lbl_Nacionalidad.TabIndex = 25
        lbl_Nacionalidad.Text = "Venezolano"
        ' 
        ' lbl_Sexo
        ' 
        lbl_Sexo.AutoSize = True
        lbl_Sexo.FlatStyle = FlatStyle.Flat
        lbl_Sexo.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lbl_Sexo.ForeColor = Color.DimGray
        lbl_Sexo.Location = New Point(278, 277)
        lbl_Sexo.Name = "lbl_Sexo"
        lbl_Sexo.Size = New Size(72, 17)
        lbl_Sexo.TabIndex = 24
        lbl_Sexo.Text = "Masculino"
        ' 
        ' lbl_EstadoCivil
        ' 
        lbl_EstadoCivil.AutoSize = True
        lbl_EstadoCivil.FlatStyle = FlatStyle.Flat
        lbl_EstadoCivil.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lbl_EstadoCivil.ForeColor = Color.DimGray
        lbl_EstadoCivil.Location = New Point(278, 220)
        lbl_EstadoCivil.Name = "lbl_EstadoCivil"
        lbl_EstadoCivil.Size = New Size(60, 17)
        lbl_EstadoCivil.TabIndex = 23
        lbl_EstadoCivil.Text = "Casado"
        ' 
        ' lbl_Edad
        ' 
        lbl_Edad.AutoSize = True
        lbl_Edad.FlatStyle = FlatStyle.Flat
        lbl_Edad.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lbl_Edad.ForeColor = Color.DimGray
        lbl_Edad.Location = New Point(278, 163)
        lbl_Edad.Name = "lbl_Edad"
        lbl_Edad.Size = New Size(57, 17)
        lbl_Edad.TabIndex = 22
        lbl_Edad.Text = "50 Años"
        ' 
        ' Label35
        ' 
        Label35.AutoSize = True
        Label35.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label35.Location = New Point(18, 614)
        Label35.Name = "Label35"
        Label35.Size = New Size(76, 19)
        Label35.TabIndex = 21
        Label35.Text = "Posición:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(278, 312)
        Label4.Name = "Label4"
        Label4.Size = New Size(122, 19)
        Label4.TabIndex = 21
        Label4.Text = "Nacionalidad:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(278, 258)
        Label3.Name = "Label3"
        Label3.Size = New Size(50, 19)
        Label3.TabIndex = 20
        Label3.Text = "Sexo:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(278, 201)
        Label2.Name = "Label2"
        Label2.Size = New Size(100, 19)
        Label2.TabIndex = 19
        Label2.Text = "Estado Civil:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(278, 144)
        Label1.Name = "Label1"
        Label1.Size = New Size(54, 19)
        Label1.TabIndex = 18
        Label1.Text = "Edad:"
        ' 
        ' IconPictureBox1
        ' 
        IconPictureBox1.BackColor = Color.WhiteSmoke
        IconPictureBox1.ForeColor = SystemColors.Highlight
        IconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.UserGear
        IconPictureBox1.IconColor = SystemColors.Highlight
        IconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconPictureBox1.IconSize = 241
        IconPictureBox1.Location = New Point(18, 84)
        IconPictureBox1.Name = "IconPictureBox1"
        IconPictureBox1.Size = New Size(241, 247)
        IconPictureBox1.TabIndex = 17
        IconPictureBox1.TabStop = False
        ' 
        ' pnlEntrada
        ' 
        pnlEntrada.Controls.Add(Panel2)
        pnlEntrada.Dock = DockStyle.Fill
        pnlEntrada.Location = New Point(567, 0)
        pnlEntrada.Name = "pnlEntrada"
        pnlEntrada.Padding = New Padding(20)
        pnlEntrada.Size = New Size(736, 746)
        pnlEntrada.TabIndex = 1
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(pnlEditarDatos)
        Panel2.Controls.Add(pnl_Titulo)
        Panel2.Dock = DockStyle.Fill
        Panel2.Location = New Point(20, 20)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(696, 706)
        Panel2.TabIndex = 0
        ' 
        ' pnlEditarDatos
        ' 
        pnlEditarDatos.BackColor = Color.FromArgb(CByte(51), CByte(51), CByte(80))
        pnlEditarDatos.Controls.Add(MultilineTextBoxLabelui1)
        pnlEditarDatos.Controls.Add(MaskedTextBoxLabelui1)
        pnlEditarDatos.Controls.Add(cmbSexo)
        pnlEditarDatos.Controls.Add(cmbNacionalidad)
        pnlEditarDatos.Controls.Add(cmbEdoCivil)
        pnlEditarDatos.Controls.Add(cmbCargo)
        pnlEditarDatos.Controls.Add(txtEdad)
        pnlEditarDatos.Controls.Add(txtApellido)
        pnlEditarDatos.Controls.Add(txtNombre)
        pnlEditarDatos.Controls.Add(txtFechaNac)
        pnlEditarDatos.Controls.Add(txtTelefonos)
        pnlEditarDatos.Controls.Add(txtCorreo)
        pnlEditarDatos.Controls.Add(txtCedula)
        pnlEditarDatos.Controls.Add(btn_Cancelar)
        pnlEditarDatos.Controls.Add(btn_Aceptar)
        pnlEditarDatos.Dock = DockStyle.Fill
        pnlEditarDatos.Location = New Point(0, 57)
        pnlEditarDatos.Name = "pnlEditarDatos"
        pnlEditarDatos.Size = New Size(696, 649)
        pnlEditarDatos.TabIndex = 4
        ' 
        ' MultilineTextBoxLabelui1
        ' 
        MultilineTextBoxLabelui1.AlturaMultilinea = 120
        MultilineTextBoxLabelui1.BackColor = Color.Transparent
        MultilineTextBoxLabelui1.BorderRadius = 5
        MultilineTextBoxLabelui1.CampoRequerido = True
        MultilineTextBoxLabelui1.ColorError = Color.Firebrick
        MultilineTextBoxLabelui1.FontField = New Font("Century Gothic", 12F)
        MultilineTextBoxLabelui1.IconoColor = Color.White
        MultilineTextBoxLabelui1.IconoDerechoChar = FontAwesome.Sharp.IconChar.CircleInfo
        MultilineTextBoxLabelui1.LabelText = "Texto:"
        MultilineTextBoxLabelui1.Location = New Point(359, 336)
        MultilineTextBoxLabelui1.MensajeError = "Este campo es obligatorio."
        MultilineTextBoxLabelui1.Multilinea = False
        MultilineTextBoxLabelui1.Name = "MultilineTextBoxLabelui1"
        MultilineTextBoxLabelui1.PaddingAll = 10
        MultilineTextBoxLabelui1.PanelBackColor = Color.FromArgb(CByte(80), CByte(94), CByte(129))
        MultilineTextBoxLabelui1.Size = New Size(283, 151)
        MultilineTextBoxLabelui1.TabIndex = 29
        MultilineTextBoxLabelui1.TextColor = Color.WhiteSmoke
        ' 
        ' MaskedTextBoxLabelui1
        ' 
        MaskedTextBoxLabelui1.BackColor = Color.Transparent
        MaskedTextBoxLabelui1.BorderRadius = 5
        MaskedTextBoxLabelui1.CampoRequerido = True
        MaskedTextBoxLabelui1.ColorError = Color.Firebrick
        MaskedTextBoxLabelui1.FontField = New Font("Century Gothic", 12F)
        MaskedTextBoxLabelui1.IconoColor = Color.White
        MaskedTextBoxLabelui1.IconoDerechoChar = FontAwesome.Sharp.IconChar.Usd
        MaskedTextBoxLabelui1.LabelText = "Campo numérico:"
        MaskedTextBoxLabelui1.Location = New Point(358, 487)
        MaskedTextBoxLabelui1.MascaraPersonalizada = ""
        MaskedTextBoxLabelui1.MensajeError = "Este campo es obligatorio."
        MaskedTextBoxLabelui1.Name = "MaskedTextBoxLabelui1"
        MaskedTextBoxLabelui1.PaddingAll = 10
        MaskedTextBoxLabelui1.PanelBackColor = Color.FromArgb(CByte(80), CByte(94), CByte(129))
        MaskedTextBoxLabelui1.Size = New Size(300, 80)
        MaskedTextBoxLabelui1.TabIndex = 28
        MaskedTextBoxLabelui1.TextColor = Color.WhiteSmoke
        MaskedTextBoxLabelui1.TipoNumerico = MaskedTextBoxLabelUI.TipoEntradaNumerica.Decimals
        ' 
        ' cmbSexo
        ' 
        cmbSexo.BackColor = Color.Transparent
        cmbSexo.CampoRequerido = True
        cmbSexo.ForeColor = Color.White
        cmbSexo.Location = New Point(23, 409)
        cmbSexo.MensajeError = "Este campo es obligatorio."
        cmbSexo.MostrarError = False
        cmbSexo.Name = "cmbSexo"
        cmbSexo.RadioContornoPanel = 6
        cmbSexo.Size = New Size(300, 78)
        cmbSexo.TabIndex = 27
        cmbSexo.Titulo = "Sexo:"
        ' 
        ' cmbNacionalidad
        ' 
        cmbNacionalidad.BackColor = Color.Transparent
        cmbNacionalidad.CampoRequerido = True
        cmbNacionalidad.ForeColor = Color.White
        cmbNacionalidad.Location = New Point(23, 327)
        cmbNacionalidad.MensajeError = "Este campo es obligatorio."
        cmbNacionalidad.MostrarError = False
        cmbNacionalidad.Name = "cmbNacionalidad"
        cmbNacionalidad.RadioContornoPanel = 6
        cmbNacionalidad.Size = New Size(300, 78)
        cmbNacionalidad.TabIndex = 27
        cmbNacionalidad.Titulo = "Nacionalidad:"
        ' 
        ' cmbEdoCivil
        ' 
        cmbEdoCivil.BackColor = Color.Transparent
        cmbEdoCivil.CampoRequerido = True
        cmbEdoCivil.ForeColor = Color.White
        cmbEdoCivil.Location = New Point(358, 21)
        cmbEdoCivil.MensajeError = "Este campo es obligatorio."
        cmbEdoCivil.MostrarError = False
        cmbEdoCivil.Name = "cmbEdoCivil"
        cmbEdoCivil.RadioContornoPanel = 6
        cmbEdoCivil.Size = New Size(300, 72)
        cmbEdoCivil.TabIndex = 27
        cmbEdoCivil.Titulo = "Estado Civil:"
        ' 
        ' cmbCargo
        ' 
        cmbCargo.BackColor = Color.Transparent
        cmbCargo.CampoRequerido = True
        cmbCargo.ForeColor = Color.White
        cmbCargo.Location = New Point(358, 177)
        cmbCargo.MensajeError = "Este campo es obligatorio."
        cmbCargo.MostrarError = False
        cmbCargo.Name = "cmbCargo"
        cmbCargo.RadioContornoPanel = 6
        cmbCargo.Size = New Size(300, 72)
        cmbCargo.TabIndex = 27
        cmbCargo.Titulo = "Cargo:"
        ' 
        ' txtEdad
        ' 
        txtEdad.BackColor = Color.Transparent
        txtEdad.BorderRadius = 5
        txtEdad.CampoRequerido = True
        txtEdad.ColorError = Color.Firebrick
        txtEdad.FontField = New Font("Century Gothic", 12F)
        txtEdad.IconoColor = Color.White
        txtEdad.IconoDerechoChar = FontAwesome.Sharp.IconChar.None
        txtEdad.LabelText = "Edad:"
        txtEdad.Location = New Point(23, 251)
        txtEdad.MensajeError = "Este campo es obligatorio."
        txtEdad.Name = "txtEdad"
        txtEdad.PaddingAll = 10
        txtEdad.PanelBackColor = Color.FromArgb(CByte(80), CByte(94), CByte(129))
        txtEdad.Size = New Size(300, 72)
        txtEdad.TabIndex = 25
        txtEdad.TextColor = Color.WhiteSmoke
        ' 
        ' txtApellido
        ' 
        txtApellido.BackColor = Color.Transparent
        txtApellido.BorderRadius = 5
        txtApellido.CampoRequerido = True
        txtApellido.ColorError = Color.Firebrick
        txtApellido.FontField = New Font("Century Gothic", 12F)
        txtApellido.IconoColor = Color.White
        txtApellido.IconoDerechoChar = FontAwesome.Sharp.IconChar.None
        txtApellido.LabelText = "Apellidos:"
        txtApellido.Location = New Point(23, 175)
        txtApellido.MensajeError = "Este campo es obligatorio."
        txtApellido.Name = "txtApellido"
        txtApellido.PaddingAll = 10
        txtApellido.PanelBackColor = Color.FromArgb(CByte(80), CByte(94), CByte(129))
        txtApellido.Size = New Size(300, 72)
        txtApellido.TabIndex = 25
        txtApellido.TextColor = Color.WhiteSmoke
        ' 
        ' txtNombre
        ' 
        txtNombre.BackColor = Color.Transparent
        txtNombre.BorderRadius = 5
        txtNombre.CampoRequerido = True
        txtNombre.ColorError = Color.Firebrick
        txtNombre.FontField = New Font("Century Gothic", 12F)
        txtNombre.IconoColor = Color.White
        txtNombre.IconoDerechoChar = FontAwesome.Sharp.IconChar.None
        txtNombre.LabelText = "Nombres:"
        txtNombre.Location = New Point(23, 99)
        txtNombre.MensajeError = "Este campo es obligatorio."
        txtNombre.Name = "txtNombre"
        txtNombre.PaddingAll = 10
        txtNombre.PanelBackColor = Color.FromArgb(CByte(80), CByte(94), CByte(129))
        txtNombre.Size = New Size(300, 72)
        txtNombre.TabIndex = 25
        txtNombre.TextColor = Color.WhiteSmoke
        ' 
        ' txtFechaNac
        ' 
        txtFechaNac.BackColor = Color.Transparent
        txtFechaNac.BorderRadius = 5
        txtFechaNac.CampoRequerido = True
        txtFechaNac.ColorError = Color.Firebrick
        txtFechaNac.FontField = New Font("Century Gothic", 12F)
        txtFechaNac.IconoColor = Color.White
        txtFechaNac.IconoDerechoChar = FontAwesome.Sharp.IconChar.None
        txtFechaNac.LabelText = "Fecha Nacimiento:"
        txtFechaNac.Location = New Point(358, 99)
        txtFechaNac.MensajeError = "Este campo es obligatorio."
        txtFechaNac.Name = "txtFechaNac"
        txtFechaNac.PaddingAll = 10
        txtFechaNac.PanelBackColor = Color.FromArgb(CByte(80), CByte(94), CByte(129))
        txtFechaNac.Size = New Size(300, 72)
        txtFechaNac.TabIndex = 25
        txtFechaNac.TextColor = Color.WhiteSmoke
        ' 
        ' txtTelefonos
        ' 
        txtTelefonos.BackColor = Color.Transparent
        txtTelefonos.BorderRadius = 5
        txtTelefonos.CampoRequerido = True
        txtTelefonos.ColorError = Color.Firebrick
        txtTelefonos.FontField = New Font("Century Gothic", 12F)
        txtTelefonos.IconoColor = Color.White
        txtTelefonos.IconoDerechoChar = FontAwesome.Sharp.IconChar.None
        txtTelefonos.LabelText = "Teléfonos:"
        txtTelefonos.Location = New Point(23, 487)
        txtTelefonos.MensajeError = "Este campo es obligatorio."
        txtTelefonos.Name = "txtTelefonos"
        txtTelefonos.PaddingAll = 10
        txtTelefonos.PanelBackColor = Color.FromArgb(CByte(80), CByte(94), CByte(129))
        txtTelefonos.Size = New Size(300, 72)
        txtTelefonos.TabIndex = 25
        txtTelefonos.TextColor = Color.WhiteSmoke
        ' 
        ' txtCorreo
        ' 
        txtCorreo.BackColor = Color.Transparent
        txtCorreo.BorderRadius = 5
        txtCorreo.CampoRequerido = True
        txtCorreo.ColorError = Color.Firebrick
        txtCorreo.FontField = New Font("Century Gothic", 12F)
        txtCorreo.IconoColor = Color.White
        txtCorreo.IconoDerechoChar = FontAwesome.Sharp.IconChar.None
        txtCorreo.LabelText = "Correo:"
        txtCorreo.Location = New Point(358, 255)
        txtCorreo.MensajeError = "Este campo es obligatorio."
        txtCorreo.Name = "txtCorreo"
        txtCorreo.PaddingAll = 10
        txtCorreo.PanelBackColor = Color.FromArgb(CByte(80), CByte(94), CByte(129))
        txtCorreo.Size = New Size(300, 72)
        txtCorreo.TabIndex = 25
        txtCorreo.TextColor = Color.WhiteSmoke
        ' 
        ' txtCedula
        ' 
        txtCedula.BackColor = Color.Transparent
        txtCedula.BorderRadius = 5
        txtCedula.CampoRequerido = True
        txtCedula.ColorError = Color.Firebrick
        txtCedula.FontField = New Font("Century Gothic", 12F)
        txtCedula.IconoColor = Color.White
        txtCedula.IconoDerechoChar = FontAwesome.Sharp.IconChar.Clover
        txtCedula.LabelText = "#Cédula:"
        txtCedula.Location = New Point(23, 23)
        txtCedula.MensajeError = "Este campo es obligatorio."
        txtCedula.Name = "txtCedula"
        txtCedula.PaddingAll = 10
        txtCedula.PanelBackColor = Color.FromArgb(CByte(80), CByte(94), CByte(129))
        txtCedula.Size = New Size(300, 72)
        txtCedula.TabIndex = 25
        txtCedula.TextColor = Color.WhiteSmoke
        ' 
        ' btn_Cancelar
        ' 
        btn_Cancelar.BackColor = Color.IndianRed
        btn_Cancelar.Cursor = Cursors.Hand
        btn_Cancelar.FlatAppearance.BorderSize = 0
        btn_Cancelar.FlatStyle = FlatStyle.Flat
        btn_Cancelar.Font = New Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btn_Cancelar.ForeColor = Color.White
        btn_Cancelar.Location = New Point(23, 574)
        btn_Cancelar.Name = "btn_Cancelar"
        btn_Cancelar.Size = New Size(162, 54)
        btn_Cancelar.TabIndex = 24
        btn_Cancelar.Text = "Cancelar"
        btn_Cancelar.UseVisualStyleBackColor = False
        ' 
        ' btn_Aceptar
        ' 
        btn_Aceptar.BackColor = Color.FromArgb(CByte(17), CByte(97), CByte(238))
        btn_Aceptar.Cursor = Cursors.Hand
        btn_Aceptar.FlatAppearance.BorderSize = 0
        btn_Aceptar.FlatStyle = FlatStyle.Flat
        btn_Aceptar.Font = New Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btn_Aceptar.ForeColor = Color.White
        btn_Aceptar.Location = New Point(475, 592)
        btn_Aceptar.Name = "btn_Aceptar"
        btn_Aceptar.Size = New Size(162, 54)
        btn_Aceptar.TabIndex = 23
        btn_Aceptar.Text = "Aceptar"
        btn_Aceptar.UseVisualStyleBackColor = False
        ' 
        ' pnl_Titulo
        ' 
        pnl_Titulo.BackColor = Color.FromArgb(CByte(0), CByte(120), CByte(215))
        pnl_Titulo.Controls.Add(Label17)
        pnl_Titulo.Dock = DockStyle.Top
        pnl_Titulo.Location = New Point(0, 0)
        pnl_Titulo.Name = "pnl_Titulo"
        pnl_Titulo.Size = New Size(696, 57)
        pnl_Titulo.TabIndex = 0
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.Font = New Font("Copperplate Gothic Light", 20F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label17.ForeColor = Color.White
        Label17.Location = New Point(3, 12)
        Label17.Name = "Label17"
        Label17.Size = New Size(130, 30)
        Label17.TabIndex = 30
        Label17.Text = "Editar..."
        ' 
        ' frm_Empleado
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1306, 749)
        Controls.Add(pnlEntrada)
        Controls.Add(pnlPrincipal)
        MaximizeBox = False
        MinimizeBox = False
        Name = "frm_Empleado"
        Padding = New Padding(3, 0, 3, 3)
        StartPosition = FormStartPosition.CenterScreen
        TopMost = True
        pnlPrincipal.ResumeLayout(False)
        pnlDatos.ResumeLayout(False)
        pnlDatos.PerformLayout()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        CType(IconPictureBox1, ComponentModel.ISupportInitialize).EndInit()
        pnlEntrada.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        pnlEditarDatos.ResumeLayout(False)
        pnl_Titulo.ResumeLayout(False)
        pnl_Titulo.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlPrincipal As Panel
    Friend WithEvents pnlDatos As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lbl_Marketing As Label
    Friend WithEvents lbl_Gerente As Label
    Friend WithEvents lbl_Asesor As Label
    Friend WithEvents lblDireccion As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lbl_FechaNacimiento As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lbl_Nacionalidad As Label
    Friend WithEvents lbl_Sexo As Label
    Friend WithEvents lbl_EstadoCivil As Label
    Friend WithEvents lbl_Edad As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents IconPictureBox1 As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents pnlEntrada As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lnk_EditarUsuario As LinkLabel
    Friend WithEvents pnl_Titulo As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents pnlEditarDatos As Panel
    Friend WithEvents btn_Cancelar As Button
    Friend WithEvents btn_Aceptar As Button
    Friend WithEvents lbl_Nombre As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents lbl_Apellidos As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents lbl_Correo As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents lbl_Cargo As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents txtEdad As TextBoxLabelUI
    Friend WithEvents txtApellido As TextBoxLabelUI
    Friend WithEvents txtNombre As TextBoxLabelUI
    Friend WithEvents txtTelefonos As TextBoxLabelUI
    Friend WithEvents txtCorreo As TextBoxLabelUI
    Friend WithEvents txtCedula As TextBoxLabelUI
    Friend WithEvents txtFechaNac As TextBoxLabelUI
    Friend WithEvents cmbCargo As cl_ComboBoxLabelUI
    Friend WithEvents cmbSexo As cl_ComboBoxLabelUI
    Friend WithEvents cmbNacionalidad As cl_ComboBoxLabelUI
    Friend WithEvents cmbEdoCivil As cl_ComboBoxLabelUI
    Friend WithEvents MaskedTextBoxLabelui1 As MaskedTextBoxLabelUI
    Friend WithEvents MultilineTextBoxLabelui1 As MultilineTextBoxLabelUI
End Class
