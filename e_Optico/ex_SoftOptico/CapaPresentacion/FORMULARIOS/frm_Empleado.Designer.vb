
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
        Label5 = New Label()
        Label7 = New Label()
        Label8 = New Label()
        Label9 = New Label()
        Label10 = New Label()
        Label12 = New Label()
        Label13 = New Label()
        Label14 = New Label()
        Label15 = New Label()
        Label16 = New Label()
        Panel3 = New Panel()
        lblCorreo = New Label()
        Label6 = New Label()
        lblPosicion = New Label()
        lblUsuario = New Label()
        lblApellido = New Label()
        lblNombres = New Label()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        IconPictureBox1 = New FontAwesome.Sharp.IconPictureBox()
        Panel1 = New Panel()
        Panel2 = New Panel()
        pnlEditarDatos = New Panel()
        btn_Cancelar = New Button()
        btn_Aceptar = New Button()
        TextBox10 = New TextBox()
        txt_PassConfirmar = New TextBox()
        TextBox3 = New TextBox()
        TextBox8 = New TextBox()
        txt_PassNueva = New TextBox()
        TextBox2 = New TextBox()
        TextBox6 = New TextBox()
        txt_PassActual = New TextBox()
        TextBox1 = New TextBox()
        TextBox4 = New TextBox()
        txtCedula = New TextBox()
        Label25 = New Label()
        Label30 = New Label()
        Label18 = New Label()
        Label23 = New Label()
        Label28 = New Label()
        Label19 = New Label()
        Label22 = New Label()
        Label26 = New Label()
        Label20 = New Label()
        Label24 = New Label()
        Label21 = New Label()
        pnl_Titulo = New Panel()
        Label17 = New Label()
        pnlPrincipal.SuspendLayout()
        pnlDatos.SuspendLayout()
        Panel4.SuspendLayout()
        CType(IconPictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
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
        pnlDatos.Controls.Add(Label5)
        pnlDatos.Controls.Add(Label7)
        pnlDatos.Controls.Add(Label8)
        pnlDatos.Controls.Add(Label9)
        pnlDatos.Controls.Add(Label10)
        pnlDatos.Controls.Add(Label12)
        pnlDatos.Controls.Add(Label13)
        pnlDatos.Controls.Add(Label14)
        pnlDatos.Controls.Add(Label15)
        pnlDatos.Controls.Add(Label16)
        pnlDatos.Controls.Add(Panel3)
        pnlDatos.Controls.Add(lblCorreo)
        pnlDatos.Controls.Add(Label6)
        pnlDatos.Controls.Add(lblPosicion)
        pnlDatos.Controls.Add(lblUsuario)
        pnlDatos.Controls.Add(lblApellido)
        pnlDatos.Controls.Add(lblNombres)
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
        lnk_EditarUsuario.Location = New Point(82, 370)
        lnk_EditarUsuario.Name = "lnk_EditarUsuario"
        lnk_EditarUsuario.Size = New Size(116, 17)
        lnk_EditarUsuario.TabIndex = 40
        lnk_EditarUsuario.TabStop = True
        lnk_EditarUsuario.Text = "Editar Empleado"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.FlatStyle = FlatStyle.Flat
        Label5.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = Color.DimGray
        Label5.Location = New Point(278, 560)
        Label5.Name = "Label5"
        Label5.Size = New Size(138, 17)
        Label5.TabIndex = 39
        Label5.Text = "wiflores@gmail.com"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(278, 541)
        Label7.Name = "Label7"
        Label7.Size = New Size(65, 19)
        Label7.TabIndex = 38
        Label7.Text = "Correo:"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.FlatStyle = FlatStyle.Flat
        Label8.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label8.ForeColor = Color.DimGray
        Label8.Location = New Point(278, 617)
        Label8.Name = "Label8"
        Label8.Size = New Size(98, 17)
        Label8.TabIndex = 37
        Label8.Text = "Administrador"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.FlatStyle = FlatStyle.Flat
        Label9.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label9.ForeColor = Color.DimGray
        Label9.Location = New Point(278, 503)
        Label9.Name = "Label9"
        Label9.Size = New Size(56, 17)
        Label9.TabIndex = 36
        Label9.Text = "wiflores"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.FlatStyle = FlatStyle.Flat
        Label10.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label10.ForeColor = Color.DimGray
        Label10.Location = New Point(278, 446)
        Label10.Name = "Label10"
        Label10.Size = New Size(88, 17)
        Label10.TabIndex = 35
        Label10.Text = "Flores Parejo"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.FlatStyle = FlatStyle.Flat
        Label12.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label12.ForeColor = Color.DimGray
        Label12.Location = New Point(278, 389)
        Label12.Name = "Label12"
        Label12.Size = New Size(108, 17)
        Label12.TabIndex = 34
        Label12.Text = "Wilmer Delvalle"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label13.Location = New Point(278, 598)
        Label13.Name = "Label13"
        Label13.Size = New Size(76, 19)
        Label13.TabIndex = 33
        Label13.Text = "Posición:"
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label14.Location = New Point(278, 484)
        Label14.Name = "Label14"
        Label14.Size = New Size(69, 19)
        Label14.TabIndex = 32
        Label14.Text = "Usuario:"
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label15.Location = New Point(278, 427)
        Label15.Name = "Label15"
        Label15.Size = New Size(85, 19)
        Label15.TabIndex = 31
        Label15.Text = "Apellidos:"
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label16.Location = New Point(278, 370)
        Label16.Name = "Label16"
        Label16.Size = New Size(83, 19)
        Label16.TabIndex = 30
        Label16.Text = "Nombres:"
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.LightGray
        Panel3.Location = New Point(265, 68)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(3, 305)
        Panel3.TabIndex = 28
        ' 
        ' lblCorreo
        ' 
        lblCorreo.AutoSize = True
        lblCorreo.FlatStyle = FlatStyle.Flat
        lblCorreo.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCorreo.ForeColor = Color.DimGray
        lblCorreo.Location = New Point(278, 274)
        lblCorreo.Name = "lblCorreo"
        lblCorreo.Size = New Size(138, 17)
        lblCorreo.TabIndex = 27
        lblCorreo.Text = "wiflores@gmail.com"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(278, 255)
        Label6.Name = "Label6"
        Label6.Size = New Size(65, 19)
        Label6.TabIndex = 26
        Label6.Text = "Correo:"
        ' 
        ' lblPosicion
        ' 
        lblPosicion.AutoSize = True
        lblPosicion.FlatStyle = FlatStyle.Flat
        lblPosicion.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblPosicion.ForeColor = Color.DimGray
        lblPosicion.Location = New Point(278, 331)
        lblPosicion.Name = "lblPosicion"
        lblPosicion.Size = New Size(98, 17)
        lblPosicion.TabIndex = 25
        lblPosicion.Text = "Administrador"
        ' 
        ' lblUsuario
        ' 
        lblUsuario.AutoSize = True
        lblUsuario.FlatStyle = FlatStyle.Flat
        lblUsuario.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblUsuario.ForeColor = Color.DimGray
        lblUsuario.Location = New Point(278, 217)
        lblUsuario.Name = "lblUsuario"
        lblUsuario.Size = New Size(56, 17)
        lblUsuario.TabIndex = 24
        lblUsuario.Text = "wiflores"
        ' 
        ' lblApellido
        ' 
        lblApellido.AutoSize = True
        lblApellido.FlatStyle = FlatStyle.Flat
        lblApellido.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblApellido.ForeColor = Color.DimGray
        lblApellido.Location = New Point(278, 160)
        lblApellido.Name = "lblApellido"
        lblApellido.Size = New Size(88, 17)
        lblApellido.TabIndex = 23
        lblApellido.Text = "Flores Parejo"
        ' 
        ' lblNombres
        ' 
        lblNombres.AutoSize = True
        lblNombres.FlatStyle = FlatStyle.Flat
        lblNombres.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblNombres.ForeColor = Color.DimGray
        lblNombres.Location = New Point(278, 103)
        lblNombres.Name = "lblNombres"
        lblNombres.Size = New Size(108, 17)
        lblNombres.TabIndex = 22
        lblNombres.Text = "Wilmer Delvalle"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(278, 312)
        Label4.Name = "Label4"
        Label4.Size = New Size(76, 19)
        Label4.TabIndex = 21
        Label4.Text = "Posición:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(278, 198)
        Label3.Name = "Label3"
        Label3.Size = New Size(69, 19)
        Label3.TabIndex = 20
        Label3.Text = "Usuario:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(278, 141)
        Label2.Name = "Label2"
        Label2.Size = New Size(85, 19)
        Label2.TabIndex = 19
        Label2.Text = "Apellidos:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(278, 84)
        Label1.Name = "Label1"
        Label1.Size = New Size(83, 19)
        Label1.TabIndex = 18
        Label1.Text = "Nombres:"
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
        ' Panel1
        ' 
        Panel1.Controls.Add(Panel2)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(567, 0)
        Panel1.Name = "Panel1"
        Panel1.Padding = New Padding(20)
        Panel1.Size = New Size(736, 746)
        Panel1.TabIndex = 1
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
        pnlEditarDatos.Controls.Add(btn_Cancelar)
        pnlEditarDatos.Controls.Add(btn_Aceptar)
        pnlEditarDatos.Controls.Add(TextBox10)
        pnlEditarDatos.Controls.Add(txt_PassConfirmar)
        pnlEditarDatos.Controls.Add(TextBox3)
        pnlEditarDatos.Controls.Add(TextBox8)
        pnlEditarDatos.Controls.Add(txt_PassNueva)
        pnlEditarDatos.Controls.Add(TextBox2)
        pnlEditarDatos.Controls.Add(TextBox6)
        pnlEditarDatos.Controls.Add(txt_PassActual)
        pnlEditarDatos.Controls.Add(TextBox1)
        pnlEditarDatos.Controls.Add(TextBox4)
        pnlEditarDatos.Controls.Add(txtCedula)
        pnlEditarDatos.Controls.Add(Label25)
        pnlEditarDatos.Controls.Add(Label30)
        pnlEditarDatos.Controls.Add(Label18)
        pnlEditarDatos.Controls.Add(Label23)
        pnlEditarDatos.Controls.Add(Label28)
        pnlEditarDatos.Controls.Add(Label19)
        pnlEditarDatos.Controls.Add(Label22)
        pnlEditarDatos.Controls.Add(Label26)
        pnlEditarDatos.Controls.Add(Label20)
        pnlEditarDatos.Controls.Add(Label24)
        pnlEditarDatos.Controls.Add(Label21)
        pnlEditarDatos.Dock = DockStyle.Fill
        pnlEditarDatos.Location = New Point(0, 57)
        pnlEditarDatos.Name = "pnlEditarDatos"
        pnlEditarDatos.Size = New Size(696, 649)
        pnlEditarDatos.TabIndex = 4
        ' 
        ' btn_Cancelar
        ' 
        btn_Cancelar.BackColor = Color.IndianRed
        btn_Cancelar.Cursor = Cursors.Hand
        btn_Cancelar.FlatAppearance.BorderSize = 0
        btn_Cancelar.FlatStyle = FlatStyle.Flat
        btn_Cancelar.Font = New Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btn_Cancelar.ForeColor = Color.White
        btn_Cancelar.Location = New Point(54, 573)
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
        btn_Aceptar.Location = New Point(331, 573)
        btn_Aceptar.Name = "btn_Aceptar"
        btn_Aceptar.Size = New Size(162, 54)
        btn_Aceptar.TabIndex = 23
        btn_Aceptar.Text = "Aceptar"
        btn_Aceptar.UseVisualStyleBackColor = False
        ' 
        ' TextBox10
        ' 
        TextBox10.BackColor = Color.FromArgb(CByte(80), CByte(94), CByte(129))
        TextBox10.BorderStyle = BorderStyle.None
        TextBox10.Font = New Font("Century Gothic", 12F)
        TextBox10.ForeColor = Color.White
        TextBox10.Location = New Point(360, 271)
        TextBox10.Multiline = True
        TextBox10.Name = "TextBox10"
        TextBox10.Size = New Size(297, 116)
        TextBox10.TabIndex = 22
        ' 
        ' txt_PassConfirmar
        ' 
        txt_PassConfirmar.BackColor = Color.FromArgb(CByte(80), CByte(94), CByte(129))
        txt_PassConfirmar.BorderStyle = BorderStyle.None
        txt_PassConfirmar.Font = New Font("Century Gothic", 12F)
        txt_PassConfirmar.ForeColor = Color.White
        txt_PassConfirmar.Location = New Point(23, 271)
        txt_PassConfirmar.Name = "txt_PassConfirmar"
        txt_PassConfirmar.Size = New Size(297, 20)
        txt_PassConfirmar.TabIndex = 22
        ' 
        ' TextBox3
        ' 
        TextBox3.BackColor = Color.FromArgb(CByte(80), CByte(94), CByte(129))
        TextBox3.BorderStyle = BorderStyle.None
        TextBox3.Font = New Font("Century Gothic", 12F)
        TextBox3.ForeColor = Color.White
        TextBox3.Location = New Point(23, 493)
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(297, 20)
        TextBox3.TabIndex = 21
        ' 
        ' TextBox8
        ' 
        TextBox8.BackColor = Color.FromArgb(CByte(80), CByte(94), CByte(129))
        TextBox8.BorderStyle = BorderStyle.None
        TextBox8.Font = New Font("Century Gothic", 12F)
        TextBox8.ForeColor = Color.White
        TextBox8.Location = New Point(360, 198)
        TextBox8.Name = "TextBox8"
        TextBox8.Size = New Size(297, 20)
        TextBox8.TabIndex = 21
        ' 
        ' txt_PassNueva
        ' 
        txt_PassNueva.BackColor = Color.FromArgb(CByte(80), CByte(94), CByte(129))
        txt_PassNueva.BorderStyle = BorderStyle.None
        txt_PassNueva.Font = New Font("Century Gothic", 12F)
        txt_PassNueva.ForeColor = Color.White
        txt_PassNueva.Location = New Point(23, 198)
        txt_PassNueva.Name = "txt_PassNueva"
        txt_PassNueva.Size = New Size(297, 20)
        txt_PassNueva.TabIndex = 21
        ' 
        ' TextBox2
        ' 
        TextBox2.BackColor = Color.FromArgb(CByte(80), CByte(94), CByte(129))
        TextBox2.BorderStyle = BorderStyle.None
        TextBox2.Font = New Font("Century Gothic", 12F)
        TextBox2.ForeColor = Color.White
        TextBox2.Location = New Point(23, 420)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(297, 20)
        TextBox2.TabIndex = 20
        ' 
        ' TextBox6
        ' 
        TextBox6.BackColor = Color.FromArgb(CByte(80), CByte(94), CByte(129))
        TextBox6.BorderStyle = BorderStyle.None
        TextBox6.Font = New Font("Century Gothic", 12F)
        TextBox6.ForeColor = Color.White
        TextBox6.Location = New Point(360, 125)
        TextBox6.Name = "TextBox6"
        TextBox6.Size = New Size(297, 20)
        TextBox6.TabIndex = 20
        ' 
        ' txt_PassActual
        ' 
        txt_PassActual.BackColor = Color.FromArgb(CByte(80), CByte(94), CByte(129))
        txt_PassActual.BorderStyle = BorderStyle.None
        txt_PassActual.Font = New Font("Century Gothic", 12F)
        txt_PassActual.ForeColor = Color.White
        txt_PassActual.Location = New Point(23, 125)
        txt_PassActual.Name = "txt_PassActual"
        txt_PassActual.Size = New Size(297, 20)
        txt_PassActual.TabIndex = 20
        ' 
        ' TextBox1
        ' 
        TextBox1.BackColor = Color.FromArgb(CByte(80), CByte(94), CByte(129))
        TextBox1.BorderStyle = BorderStyle.None
        TextBox1.Font = New Font("Century Gothic", 12F)
        TextBox1.ForeColor = Color.White
        TextBox1.Location = New Point(23, 347)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(297, 20)
        TextBox1.TabIndex = 19
        ' 
        ' TextBox4
        ' 
        TextBox4.BackColor = Color.FromArgb(CByte(80), CByte(94), CByte(129))
        TextBox4.BorderStyle = BorderStyle.None
        TextBox4.Font = New Font("Century Gothic", 12F)
        TextBox4.ForeColor = Color.White
        TextBox4.Location = New Point(360, 52)
        TextBox4.Name = "TextBox4"
        TextBox4.Size = New Size(297, 20)
        TextBox4.TabIndex = 19
        ' 
        ' txtCedula
        ' 
        txtCedula.BackColor = Color.FromArgb(CByte(80), CByte(94), CByte(129))
        txtCedula.BorderStyle = BorderStyle.None
        txtCedula.Font = New Font("Century Gothic", 12F)
        txtCedula.ForeColor = Color.White
        txtCedula.Location = New Point(23, 52)
        txtCedula.Margin = New Padding(10, 5, 3, 3)
        txtCedula.Name = "txtCedula"
        txtCedula.PlaceholderText = "Número de Cedula..."
        txtCedula.Size = New Size(297, 20)
        txtCedula.TabIndex = 19
        ' 
        ' Label25
        ' 
        Label25.AutoSize = True
        Label25.Font = New Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label25.ForeColor = Color.WhiteSmoke
        Label25.Location = New Point(23, 393)
        Label25.Name = "Label25"
        Label25.Size = New Size(104, 21)
        Label25.TabIndex = 17
        Label25.Text = "Estado Civil:"
        ' 
        ' Label30
        ' 
        Label30.AutoSize = True
        Label30.Font = New Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label30.ForeColor = Color.WhiteSmoke
        Label30.Location = New Point(360, 98)
        Label30.Name = "Label30"
        Label30.Size = New Size(64, 21)
        Label30.TabIndex = 17
        Label30.Text = "Cargo:"
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.Font = New Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label18.ForeColor = Color.WhiteSmoke
        Label18.Location = New Point(23, 98)
        Label18.Name = "Label18"
        Label18.Size = New Size(83, 21)
        Label18.TabIndex = 17
        Label18.Text = "Nombres:"
        ' 
        ' Label23
        ' 
        Label23.AutoSize = True
        Label23.Font = New Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label23.ForeColor = Color.WhiteSmoke
        Label23.Location = New Point(23, 466)
        Label23.Name = "Label23"
        Label23.Size = New Size(50, 21)
        Label23.TabIndex = 15
        Label23.Text = "Sexo:"
        ' 
        ' Label28
        ' 
        Label28.AutoSize = True
        Label28.Font = New Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label28.ForeColor = Color.WhiteSmoke
        Label28.Location = New Point(360, 244)
        Label28.Name = "Label28"
        Label28.Size = New Size(87, 21)
        Label28.TabIndex = 16
        Label28.Text = "Dirección:"
        ' 
        ' Label19
        ' 
        Label19.AutoSize = True
        Label19.Font = New Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label19.ForeColor = Color.WhiteSmoke
        Label19.Location = New Point(23, 244)
        Label19.Name = "Label19"
        Label19.Size = New Size(52, 21)
        Label19.TabIndex = 16
        Label19.Text = "Edad"
        ' 
        ' Label22
        ' 
        Label22.AutoSize = True
        Label22.Font = New Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label22.ForeColor = Color.WhiteSmoke
        Label22.Location = New Point(23, 320)
        Label22.Name = "Label22"
        Label22.Size = New Size(120, 21)
        Label22.TabIndex = 14
        Label22.Text = "Nacionalidad:"
        ' 
        ' Label26
        ' 
        Label26.AutoSize = True
        Label26.Font = New Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label26.ForeColor = Color.WhiteSmoke
        Label26.Location = New Point(360, 171)
        Label26.Name = "Label26"
        Label26.Size = New Size(158, 21)
        Label26.TabIndex = 15
        Label26.Text = "Correo Electrónico:"
        ' 
        ' Label20
        ' 
        Label20.AutoSize = True
        Label20.Font = New Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label20.ForeColor = Color.WhiteSmoke
        Label20.Location = New Point(23, 171)
        Label20.Name = "Label20"
        Label20.Size = New Size(84, 21)
        Label20.TabIndex = 15
        Label20.Text = "Apellidos:"
        ' 
        ' Label24
        ' 
        Label24.AutoSize = True
        Label24.Font = New Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label24.ForeColor = Color.WhiteSmoke
        Label24.Location = New Point(360, 23)
        Label24.Name = "Label24"
        Label24.Size = New Size(183, 21)
        Label24.TabIndex = 14
        Label24.Text = "Fecha de Nacimiento:"
        ' 
        ' Label21
        ' 
        Label21.AutoSize = True
        Label21.Font = New Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label21.ForeColor = Color.WhiteSmoke
        Label21.Location = New Point(23, 23)
        Label21.Name = "Label21"
        Label21.Size = New Size(94, 21)
        Label21.TabIndex = 14
        Label21.Text = "Nº Cedula:"
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
        Controls.Add(Panel1)
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
        Panel1.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        pnlEditarDatos.ResumeLayout(False)
        pnlEditarDatos.PerformLayout()
        pnl_Titulo.ResumeLayout(False)
        pnl_Titulo.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlPrincipal As Panel
    Friend WithEvents pnlDatos As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lblCorreo As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblPosicion As Label
    Friend WithEvents lblUsuario As Label
    Friend WithEvents lblApellido As Label
    Friend WithEvents lblNombres As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents IconPictureBox1 As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lnk_EditarUsuario As LinkLabel
    Friend WithEvents pnl_Titulo As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents pnlEditarDatos As Panel
    Friend WithEvents btn_Cancelar As Button
    Friend WithEvents btn_Aceptar As Button
    Friend WithEvents txt_PassConfirmar As TextBox
    Friend WithEvents txt_PassNueva As TextBox
    Friend WithEvents txt_PassActual As TextBox
    Friend WithEvents txtCedula As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents TextBox10 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox8 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Label24 As Label
End Class
