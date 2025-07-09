<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Inicio
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
        components = New ComponentModel.Container()
        pnlMenuOpciones = New Panel()
        icoMenu = New FontAwesome.Sharp.IconButton()
        IconButton9 = New FontAwesome.Sharp.IconButton()
        IconButton3 = New FontAwesome.Sharp.IconButton()
        IconButton1 = New FontAwesome.Sharp.IconButton()
        btn_1 = New FontAwesome.Sharp.IconButton()
        IconButton8 = New FontAwesome.Sharp.IconButton()
        IconButton7 = New FontAwesome.Sharp.IconButton()
        IconButton6 = New FontAwesome.Sharp.IconButton()
        IconButton5 = New FontAwesome.Sharp.IconButton()
        IconButton4 = New FontAwesome.Sharp.IconButton()
        btnMantenedor = New FontAwesome.Sharp.IconButton()
        pnlMenu = New Panel()
        btn11 = New Button()
        btn10 = New Button()
        btn9 = New Button()
        btn8 = New Button()
        btn7 = New Button()
        btn6 = New Button()
        btn5 = New Button()
        btn4 = New Button()
        btn3 = New Button()
        btn2 = New Button()
        btn1 = New Button()
        btnEditarPerfil = New FontAwesome.Sharp.IconButton()
        lblCargo = New Label()
        lblUsuario = New Label()
        imgLogo = New FontAwesome.Sharp.IconPictureBox()
        pnl_Encabezado = New Panel()
        lbl_Titulo = New Label()
        btn_Maximizar = New FontAwesome.Sharp.IconButton()
        btn_Minimizar = New FontAwesome.Sharp.IconButton()
        btnCerrar = New FontAwesome.Sharp.IconButton()
        btnCloseChildForm = New Button()
        pnl_Contenedor = New Panel()
        tmr_OcultarMenu = New Timer(components)
        tmr_MostrarMenu = New Timer(components)
        tol_Mensajes = New ToolTip(components)
        pnlMenuOpciones.SuspendLayout()
        pnlMenu.SuspendLayout()
        CType(imgLogo, ComponentModel.ISupportInitialize).BeginInit()
        pnl_Encabezado.SuspendLayout()
        pnl_Contenedor.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlMenuOpciones
        ' 
        pnlMenuOpciones.BackColor = Color.FromArgb(CByte(51), CByte(51), CByte(76))
        pnlMenuOpciones.Controls.Add(icoMenu)
        pnlMenuOpciones.Controls.Add(IconButton9)
        pnlMenuOpciones.Controls.Add(IconButton3)
        pnlMenuOpciones.Controls.Add(IconButton1)
        pnlMenuOpciones.Controls.Add(btn_1)
        pnlMenuOpciones.Controls.Add(IconButton8)
        pnlMenuOpciones.Controls.Add(IconButton7)
        pnlMenuOpciones.Controls.Add(IconButton6)
        pnlMenuOpciones.Controls.Add(IconButton5)
        pnlMenuOpciones.Controls.Add(IconButton4)
        pnlMenuOpciones.Controls.Add(btnMantenedor)
        pnlMenuOpciones.Dock = DockStyle.Left
        pnlMenuOpciones.Location = New Point(0, 0)
        pnlMenuOpciones.Name = "pnlMenuOpciones"
        pnlMenuOpciones.Size = New Size(57, 683)
        pnlMenuOpciones.TabIndex = 0
        ' 
        ' icoMenu
        ' 
        icoMenu.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        icoMenu.Cursor = Cursors.Hand
        icoMenu.FlatAppearance.BorderSize = 0
        icoMenu.FlatStyle = FlatStyle.Flat
        icoMenu.Font = New Font("Century Gothic", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        icoMenu.ForeColor = Color.White
        icoMenu.IconChar = FontAwesome.Sharp.IconChar.Bars
        icoMenu.IconColor = Color.White
        icoMenu.IconFont = FontAwesome.Sharp.IconFont.Auto
        icoMenu.IconSize = 50
        icoMenu.Location = New Point(9, 15)
        icoMenu.Name = "icoMenu"
        icoMenu.Size = New Size(40, 40)
        icoMenu.TabIndex = 21
        icoMenu.UseVisualStyleBackColor = True
        ' 
        ' IconButton9
        ' 
        IconButton9.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        IconButton9.BackgroundImageLayout = ImageLayout.None
        IconButton9.Cursor = Cursors.Hand
        IconButton9.FlatAppearance.BorderSize = 0
        IconButton9.FlatStyle = FlatStyle.Flat
        IconButton9.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal
        IconButton9.Font = New Font("Century Gothic", 6.0F)
        IconButton9.ForeColor = Color.White
        IconButton9.IconChar = FontAwesome.Sharp.IconChar.Tools
        IconButton9.IconColor = Color.White
        IconButton9.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconButton9.IconSize = 30
        IconButton9.Location = New Point(3, 634)
        IconButton9.Name = "IconButton9"
        IconButton9.Size = New Size(55, 46)
        IconButton9.TabIndex = 20
        IconButton9.Text = "Productos"
        IconButton9.TextImageRelation = TextImageRelation.ImageAboveText
        IconButton9.UseVisualStyleBackColor = True
        ' 
        ' IconButton3
        ' 
        IconButton3.BackgroundImageLayout = ImageLayout.None
        IconButton3.Cursor = Cursors.Hand
        IconButton3.FlatAppearance.BorderSize = 0
        IconButton3.FlatStyle = FlatStyle.Flat
        IconButton3.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal
        IconButton3.Font = New Font("Century Gothic", 6.0F)
        IconButton3.ForeColor = Color.White
        IconButton3.IconChar = FontAwesome.Sharp.IconChar.Tools
        IconButton3.IconColor = Color.White
        IconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconButton3.IconSize = 30
        IconButton3.Location = New Point(0, 514)
        IconButton3.Name = "IconButton3"
        IconButton3.Size = New Size(55, 46)
        IconButton3.TabIndex = 19
        IconButton3.Text = "Productos"
        IconButton3.TextImageRelation = TextImageRelation.ImageAboveText
        IconButton3.UseVisualStyleBackColor = True
        ' 
        ' IconButton1
        ' 
        IconButton1.BackgroundImageLayout = ImageLayout.None
        IconButton1.Cursor = Cursors.Hand
        IconButton1.FlatAppearance.BorderSize = 0
        IconButton1.FlatStyle = FlatStyle.Flat
        IconButton1.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal
        IconButton1.Font = New Font("Century Gothic", 6.0F)
        IconButton1.ForeColor = Color.White
        IconButton1.IconChar = FontAwesome.Sharp.IconChar.Tools
        IconButton1.IconColor = Color.White
        IconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconButton1.IconSize = 30
        IconButton1.Location = New Point(0, 461)
        IconButton1.Name = "IconButton1"
        IconButton1.Size = New Size(55, 46)
        IconButton1.TabIndex = 18
        IconButton1.Text = "Productos"
        IconButton1.TextImageRelation = TextImageRelation.ImageAboveText
        IconButton1.UseVisualStyleBackColor = True
        ' 
        ' btn_1
        ' 
        btn_1.BackgroundImageLayout = ImageLayout.None
        btn_1.Cursor = Cursors.Hand
        btn_1.FlatAppearance.BorderSize = 0
        btn_1.FlatStyle = FlatStyle.Flat
        btn_1.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal
        btn_1.Font = New Font("Century Gothic", 6.0F)
        btn_1.ForeColor = Color.White
        btn_1.IconChar = FontAwesome.Sharp.IconChar.Tools
        btn_1.IconColor = Color.White
        btn_1.IconFont = FontAwesome.Sharp.IconFont.Auto
        btn_1.IconSize = 30
        btn_1.Location = New Point(0, 90)
        btn_1.Name = "btn_1"
        btn_1.Size = New Size(55, 46)
        btn_1.TabIndex = 17
        btn_1.Text = "Productos"
        btn_1.TextImageRelation = TextImageRelation.ImageAboveText
        btn_1.UseVisualStyleBackColor = True
        ' 
        ' IconButton8
        ' 
        IconButton8.Cursor = Cursors.Hand
        IconButton8.FlatAppearance.BorderSize = 0
        IconButton8.FlatStyle = FlatStyle.Flat
        IconButton8.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal
        IconButton8.Font = New Font("Century Gothic", 6.0F)
        IconButton8.ForeColor = Color.White
        IconButton8.IconChar = FontAwesome.Sharp.IconChar.BarChart
        IconButton8.IconColor = Color.White
        IconButton8.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconButton8.IconSize = 30
        IconButton8.Location = New Point(0, 408)
        IconButton8.Name = "IconButton8"
        IconButton8.Size = New Size(55, 46)
        IconButton8.TabIndex = 14
        IconButton8.Text = "    Reportes"
        IconButton8.TextImageRelation = TextImageRelation.ImageAboveText
        tol_Mensajes.SetToolTip(IconButton8, "Ver los reportes y facturas")
        IconButton8.UseVisualStyleBackColor = True
        ' 
        ' IconButton7
        ' 
        IconButton7.Cursor = Cursors.Hand
        IconButton7.FlatAppearance.BorderSize = 0
        IconButton7.FlatStyle = FlatStyle.Flat
        IconButton7.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal
        IconButton7.Font = New Font("Century Gothic", 6.0F)
        IconButton7.ForeColor = Color.White
        IconButton7.IconChar = FontAwesome.Sharp.IconChar.Vcard
        IconButton7.IconColor = Color.White
        IconButton7.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconButton7.IconSize = 30
        IconButton7.Location = New Point(0, 355)
        IconButton7.Name = "IconButton7"
        IconButton7.Size = New Size(55, 46)
        IconButton7.TabIndex = 13
        IconButton7.Text = "    Proveedor"
        IconButton7.TextImageRelation = TextImageRelation.ImageAboveText
        tol_Mensajes.SetToolTip(IconButton7, "Administrar datos del proveedor")
        IconButton7.UseVisualStyleBackColor = True
        ' 
        ' IconButton6
        ' 
        IconButton6.Cursor = Cursors.Hand
        IconButton6.FlatAppearance.BorderSize = 0
        IconButton6.FlatStyle = FlatStyle.Flat
        IconButton6.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal
        IconButton6.Font = New Font("Century Gothic", 6.0F)
        IconButton6.ForeColor = Color.White
        IconButton6.IconChar = FontAwesome.Sharp.IconChar.UserFriends
        IconButton6.IconColor = Color.White
        IconButton6.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconButton6.IconSize = 30
        IconButton6.Location = New Point(0, 302)
        IconButton6.Name = "IconButton6"
        IconButton6.Size = New Size(55, 46)
        IconButton6.TabIndex = 12
        IconButton6.Text = "    Clientes"
        IconButton6.TextImageRelation = TextImageRelation.ImageAboveText
        tol_Mensajes.SetToolTip(IconButton6, "Administrar datos del cliente")
        IconButton6.UseVisualStyleBackColor = True
        ' 
        ' IconButton5
        ' 
        IconButton5.Cursor = Cursors.Hand
        IconButton5.FlatAppearance.BorderSize = 0
        IconButton5.FlatStyle = FlatStyle.Flat
        IconButton5.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal
        IconButton5.Font = New Font("Century Gothic", 6.0F)
        IconButton5.ForeColor = Color.White
        IconButton5.IconChar = FontAwesome.Sharp.IconChar.CartFlatbed
        IconButton5.IconColor = Color.White
        IconButton5.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconButton5.IconSize = 30
        IconButton5.Location = New Point(0, 249)
        IconButton5.Name = "IconButton5"
        IconButton5.Size = New Size(55, 46)
        IconButton5.TabIndex = 11
        IconButton5.Text = "    Compra"
        IconButton5.TextImageRelation = TextImageRelation.ImageAboveText
        tol_Mensajes.SetToolTip(IconButton5, "Realizar nueva compra")
        IconButton5.UseVisualStyleBackColor = True
        ' 
        ' IconButton4
        ' 
        IconButton4.BackgroundImageLayout = ImageLayout.None
        IconButton4.Cursor = Cursors.Hand
        IconButton4.FlatAppearance.BorderSize = 0
        IconButton4.FlatStyle = FlatStyle.Flat
        IconButton4.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal
        IconButton4.Font = New Font("Century Gothic", 6.0F)
        IconButton4.ForeColor = Color.White
        IconButton4.IconChar = FontAwesome.Sharp.IconChar.Tags
        IconButton4.IconColor = Color.White
        IconButton4.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconButton4.IconSize = 30
        IconButton4.Location = New Point(0, 196)
        IconButton4.Name = "IconButton4"
        IconButton4.Size = New Size(55, 46)
        IconButton4.TabIndex = 10
        IconButton4.Text = "    Venta"
        IconButton4.TextImageRelation = TextImageRelation.ImageAboveText
        tol_Mensajes.SetToolTip(IconButton4, "Realizar nueva venta")
        IconButton4.UseVisualStyleBackColor = True
        ' 
        ' btnMantenedor
        ' 
        btnMantenedor.BackgroundImageLayout = ImageLayout.None
        btnMantenedor.Cursor = Cursors.Hand
        btnMantenedor.FlatAppearance.BorderSize = 0
        btnMantenedor.FlatStyle = FlatStyle.Flat
        btnMantenedor.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal
        btnMantenedor.Font = New Font("Century Gothic", 6.0F)
        btnMantenedor.ForeColor = Color.White
        btnMantenedor.IconChar = FontAwesome.Sharp.IconChar.Tools
        btnMantenedor.IconColor = Color.White
        btnMantenedor.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnMantenedor.IconSize = 30
        btnMantenedor.Location = New Point(0, 143)
        btnMantenedor.Name = "btnMantenedor"
        btnMantenedor.Size = New Size(55, 46)
        btnMantenedor.TabIndex = 9
        btnMantenedor.Text = "Productos"
        btnMantenedor.TextImageRelation = TextImageRelation.ImageAboveText
        btnMantenedor.UseVisualStyleBackColor = True
        ' 
        ' pnlMenu
        ' 
        pnlMenu.AutoScroll = True
        pnlMenu.BackColor = Color.White
        pnlMenu.BorderStyle = BorderStyle.FixedSingle
        pnlMenu.Controls.Add(btn11)
        pnlMenu.Controls.Add(btn10)
        pnlMenu.Controls.Add(btn9)
        pnlMenu.Controls.Add(btn8)
        pnlMenu.Controls.Add(btn7)
        pnlMenu.Controls.Add(btn6)
        pnlMenu.Controls.Add(btn5)
        pnlMenu.Controls.Add(btn4)
        pnlMenu.Controls.Add(btn3)
        pnlMenu.Controls.Add(btn2)
        pnlMenu.Controls.Add(btn1)
        pnlMenu.Dock = DockStyle.Left
        pnlMenu.Location = New Point(0, 0)
        pnlMenu.Name = "pnlMenu"
        pnlMenu.Size = New Size(225, 616)
        pnlMenu.TabIndex = 1
        ' 
        ' btn11
        ' 
        btn11.Dock = DockStyle.Top
        btn11.FlatAppearance.BorderSize = 0
        btn11.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(192), CByte(255), CByte(255))
        btn11.FlatStyle = FlatStyle.Flat
        btn11.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btn11.Location = New Point(0, 450)
        btn11.Name = "btn11"
        btn11.Padding = New Padding(20, 0, 0, 0)
        btn11.Size = New Size(223, 45)
        btn11.TabIndex = 10
        btn11.Tag = "11"
        btn11.Text = "Button10"
        btn11.TextAlign = ContentAlignment.MiddleLeft
        btn11.TextImageRelation = TextImageRelation.ImageBeforeText
        btn11.UseVisualStyleBackColor = True
        ' 
        ' btn10
        ' 
        btn10.Dock = DockStyle.Top
        btn10.FlatAppearance.BorderSize = 0
        btn10.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(192), CByte(255), CByte(255))
        btn10.FlatStyle = FlatStyle.Flat
        btn10.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btn10.Location = New Point(0, 405)
        btn10.Name = "btn10"
        btn10.Padding = New Padding(20, 0, 0, 0)
        btn10.Size = New Size(223, 45)
        btn10.TabIndex = 9
        btn10.Tag = "10"
        btn10.Text = "Button9"
        btn10.TextAlign = ContentAlignment.MiddleLeft
        btn10.TextImageRelation = TextImageRelation.ImageBeforeText
        btn10.UseVisualStyleBackColor = True
        ' 
        ' btn9
        ' 
        btn9.Dock = DockStyle.Top
        btn9.FlatAppearance.BorderSize = 0
        btn9.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(192), CByte(255), CByte(255))
        btn9.FlatStyle = FlatStyle.Flat
        btn9.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btn9.Location = New Point(0, 360)
        btn9.Name = "btn9"
        btn9.Padding = New Padding(20, 0, 0, 0)
        btn9.Size = New Size(223, 45)
        btn9.TabIndex = 8
        btn9.Tag = "9"
        btn9.Text = "Button8"
        btn9.TextAlign = ContentAlignment.MiddleLeft
        btn9.TextImageRelation = TextImageRelation.ImageBeforeText
        btn9.UseVisualStyleBackColor = True
        ' 
        ' btn8
        ' 
        btn8.Dock = DockStyle.Top
        btn8.FlatAppearance.BorderSize = 0
        btn8.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(192), CByte(255), CByte(255))
        btn8.FlatStyle = FlatStyle.Flat
        btn8.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btn8.Location = New Point(0, 315)
        btn8.Name = "btn8"
        btn8.Padding = New Padding(20, 0, 0, 0)
        btn8.Size = New Size(223, 45)
        btn8.TabIndex = 7
        btn8.Tag = "8"
        btn8.Text = "Button7"
        btn8.TextAlign = ContentAlignment.MiddleLeft
        btn8.TextImageRelation = TextImageRelation.ImageBeforeText
        btn8.UseVisualStyleBackColor = True
        ' 
        ' btn7
        ' 
        btn7.Dock = DockStyle.Top
        btn7.FlatAppearance.BorderSize = 0
        btn7.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(192), CByte(255), CByte(255))
        btn7.FlatStyle = FlatStyle.Flat
        btn7.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btn7.Location = New Point(0, 270)
        btn7.Name = "btn7"
        btn7.Padding = New Padding(20, 0, 0, 0)
        btn7.Size = New Size(223, 45)
        btn7.TabIndex = 6
        btn7.Tag = "7"
        btn7.Text = "Button6"
        btn7.TextAlign = ContentAlignment.MiddleLeft
        btn7.TextImageRelation = TextImageRelation.ImageBeforeText
        btn7.UseVisualStyleBackColor = True
        ' 
        ' btn6
        ' 
        btn6.Dock = DockStyle.Top
        btn6.FlatAppearance.BorderSize = 0
        btn6.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(192), CByte(255), CByte(255))
        btn6.FlatStyle = FlatStyle.Flat
        btn6.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btn6.Location = New Point(0, 225)
        btn6.Name = "btn6"
        btn6.Padding = New Padding(20, 0, 0, 0)
        btn6.Size = New Size(223, 45)
        btn6.TabIndex = 5
        btn6.Tag = "6"
        btn6.Text = "Button5"
        btn6.TextAlign = ContentAlignment.MiddleLeft
        btn6.TextImageRelation = TextImageRelation.ImageBeforeText
        btn6.UseVisualStyleBackColor = True
        ' 
        ' btn5
        ' 
        btn5.Dock = DockStyle.Top
        btn5.FlatAppearance.BorderSize = 0
        btn5.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(192), CByte(255), CByte(255))
        btn5.FlatStyle = FlatStyle.Flat
        btn5.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btn5.Location = New Point(0, 180)
        btn5.Name = "btn5"
        btn5.Padding = New Padding(20, 0, 0, 0)
        btn5.Size = New Size(223, 45)
        btn5.TabIndex = 4
        btn5.Tag = "5"
        btn5.Text = "Button4"
        btn5.TextAlign = ContentAlignment.MiddleLeft
        btn5.TextImageRelation = TextImageRelation.ImageBeforeText
        btn5.UseVisualStyleBackColor = True
        ' 
        ' btn4
        ' 
        btn4.Dock = DockStyle.Top
        btn4.FlatAppearance.BorderSize = 0
        btn4.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(192), CByte(255), CByte(255))
        btn4.FlatStyle = FlatStyle.Flat
        btn4.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btn4.Location = New Point(0, 135)
        btn4.Name = "btn4"
        btn4.Padding = New Padding(20, 0, 0, 0)
        btn4.Size = New Size(223, 45)
        btn4.TabIndex = 3
        btn4.Tag = "4"
        btn4.Text = "Button3"
        btn4.TextAlign = ContentAlignment.MiddleLeft
        btn4.TextImageRelation = TextImageRelation.ImageBeforeText
        btn4.UseVisualStyleBackColor = True
        ' 
        ' btn3
        ' 
        btn3.Dock = DockStyle.Top
        btn3.FlatAppearance.BorderSize = 0
        btn3.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(192), CByte(255), CByte(255))
        btn3.FlatStyle = FlatStyle.Flat
        btn3.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btn3.Location = New Point(0, 90)
        btn3.Name = "btn3"
        btn3.Padding = New Padding(20, 0, 0, 0)
        btn3.Size = New Size(223, 45)
        btn3.TabIndex = 2
        btn3.Tag = "3"
        btn3.Text = "Button2"
        btn3.TextAlign = ContentAlignment.MiddleLeft
        btn3.TextImageRelation = TextImageRelation.ImageBeforeText
        btn3.UseVisualStyleBackColor = True
        ' 
        ' btn2
        ' 
        btn2.Dock = DockStyle.Top
        btn2.FlatAppearance.BorderSize = 0
        btn2.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(192), CByte(255), CByte(255))
        btn2.FlatStyle = FlatStyle.Flat
        btn2.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btn2.Location = New Point(0, 45)
        btn2.Name = "btn2"
        btn2.Padding = New Padding(20, 0, 0, 0)
        btn2.Size = New Size(223, 45)
        btn2.TabIndex = 1
        btn2.Tag = "2"
        btn2.Text = "Button1"
        btn2.TextAlign = ContentAlignment.MiddleLeft
        btn2.TextImageRelation = TextImageRelation.ImageBeforeText
        btn2.UseVisualStyleBackColor = True
        ' 
        ' btn1
        ' 
        btn1.Dock = DockStyle.Top
        btn1.FlatAppearance.BorderSize = 0
        btn1.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(192), CByte(255), CByte(255))
        btn1.FlatStyle = FlatStyle.Flat
        btn1.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btn1.Location = New Point(0, 0)
        btn1.Name = "btn1"
        btn1.Padding = New Padding(20, 0, 0, 0)
        btn1.Size = New Size(223, 45)
        btn1.TabIndex = 0
        btn1.Tag = "1"
        btn1.Text = "btn1"
        btn1.TextAlign = ContentAlignment.MiddleLeft
        btn1.TextImageRelation = TextImageRelation.ImageBeforeText
        btn1.UseVisualStyleBackColor = True
        ' 
        ' btnEditarPerfil
        ' 
        btnEditarPerfil.Cursor = Cursors.Hand
        btnEditarPerfil.FlatAppearance.BorderSize = 0
        btnEditarPerfil.FlatStyle = FlatStyle.Flat
        btnEditarPerfil.Font = New Font("Century Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnEditarPerfil.ForeColor = Color.WhiteSmoke
        btnEditarPerfil.IconChar = FontAwesome.Sharp.IconChar.None
        btnEditarPerfil.IconColor = Color.Black
        btnEditarPerfil.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnEditarPerfil.Location = New Point(833, 41)
        btnEditarPerfil.Name = "btnEditarPerfil"
        btnEditarPerfil.Size = New Size(75, 23)
        btnEditarPerfil.TabIndex = 7
        btnEditarPerfil.Text = "Editar Perfil"
        btnEditarPerfil.UseVisualStyleBackColor = True
        ' 
        ' lblCargo
        ' 
        lblCargo.AutoSize = True
        lblCargo.Font = New Font("Century Gothic", 6.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCargo.ForeColor = Color.WhiteSmoke
        lblCargo.Location = New Point(696, 35)
        lblCargo.Name = "lblCargo"
        lblCargo.Size = New Size(69, 13)
        lblCargo.TabIndex = 6
        lblCargo.Text = "Administrador"
        ' 
        ' lblUsuario
        ' 
        lblUsuario.AutoSize = True
        lblUsuario.Font = New Font("Century Gothic", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblUsuario.ForeColor = Color.WhiteSmoke
        lblUsuario.Location = New Point(696, 15)
        lblUsuario.Name = "lblUsuario"
        lblUsuario.Size = New Size(87, 17)
        lblUsuario.TabIndex = 1
        lblUsuario.Text = "Wilmer Flores"
        ' 
        ' imgLogo
        ' 
        imgLogo.Anchor = AnchorStyles.Left
        imgLogo.BackColor = Color.FromArgb(CByte(0), CByte(150), CByte(136))
        imgLogo.IconChar = FontAwesome.Sharp.IconChar.UserSecret
        imgLogo.IconColor = Color.White
        imgLogo.IconFont = FontAwesome.Sharp.IconFont.Auto
        imgLogo.IconSize = 48
        imgLogo.Location = New Point(640, 9)
        imgLogo.Name = "imgLogo"
        imgLogo.Size = New Size(50, 48)
        imgLogo.TabIndex = 1
        imgLogo.TabStop = False
        ' 
        ' pnl_Encabezado
        ' 
        pnl_Encabezado.BackColor = Color.FromArgb(CByte(0), CByte(150), CByte(136))
        pnl_Encabezado.Controls.Add(lbl_Titulo)
        pnl_Encabezado.Controls.Add(btnEditarPerfil)
        pnl_Encabezado.Controls.Add(btn_Maximizar)
        pnl_Encabezado.Controls.Add(imgLogo)
        pnl_Encabezado.Controls.Add(lblCargo)
        pnl_Encabezado.Controls.Add(btn_Minimizar)
        pnl_Encabezado.Controls.Add(lblUsuario)
        pnl_Encabezado.Controls.Add(btnCerrar)
        pnl_Encabezado.Controls.Add(btnCloseChildForm)
        pnl_Encabezado.Dock = DockStyle.Top
        pnl_Encabezado.Location = New Point(57, 0)
        pnl_Encabezado.Name = "pnl_Encabezado"
        pnl_Encabezado.Size = New Size(1083, 67)
        pnl_Encabezado.TabIndex = 1
        ' 
        ' lbl_Titulo
        ' 
        lbl_Titulo.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lbl_Titulo.AutoSize = True
        lbl_Titulo.Font = New Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lbl_Titulo.ForeColor = Color.WhiteSmoke
        lbl_Titulo.Location = New Point(281, 23)
        lbl_Titulo.Name = "lbl_Titulo"
        lbl_Titulo.Size = New Size(144, 25)
        lbl_Titulo.TabIndex = 8
        lbl_Titulo.Text = "Wilmer Flores"
        ' 
        ' btn_Maximizar
        ' 
        btn_Maximizar.Anchor = AnchorStyles.Right
        btn_Maximizar.BackColor = Color.FromArgb(CByte(0), CByte(150), CByte(136))
        btn_Maximizar.Cursor = Cursors.Hand
        btn_Maximizar.FlatAppearance.BorderSize = 0
        btn_Maximizar.FlatStyle = FlatStyle.Flat
        btn_Maximizar.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize
        btn_Maximizar.IconColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        btn_Maximizar.IconFont = FontAwesome.Sharp.IconFont.Auto
        btn_Maximizar.IconSize = 25
        btn_Maximizar.Location = New Point(1019, 9)
        btn_Maximizar.Name = "btn_Maximizar"
        btn_Maximizar.Size = New Size(22, 23)
        btn_Maximizar.TabIndex = 6
        btn_Maximizar.UseVisualStyleBackColor = False
        ' 
        ' btn_Minimizar
        ' 
        btn_Minimizar.Anchor = AnchorStyles.Right
        btn_Minimizar.BackColor = Color.FromArgb(CByte(0), CByte(150), CByte(136))
        btn_Minimizar.Cursor = Cursors.Hand
        btn_Minimizar.FlatAppearance.BorderSize = 0
        btn_Minimizar.FlatStyle = FlatStyle.Flat
        btn_Minimizar.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize
        btn_Minimizar.IconColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        btn_Minimizar.IconFont = FontAwesome.Sharp.IconFont.Auto
        btn_Minimizar.IconSize = 25
        btn_Minimizar.Location = New Point(989, 9)
        btn_Minimizar.Name = "btn_Minimizar"
        btn_Minimizar.Size = New Size(22, 23)
        btn_Minimizar.TabIndex = 5
        btn_Minimizar.UseVisualStyleBackColor = False
        ' 
        ' btnCerrar
        ' 
        btnCerrar.Anchor = AnchorStyles.Right
        btnCerrar.BackColor = Color.FromArgb(CByte(0), CByte(150), CByte(136))
        btnCerrar.Cursor = Cursors.Hand
        btnCerrar.FlatAppearance.BorderSize = 0
        btnCerrar.FlatStyle = FlatStyle.Flat
        btnCerrar.IconChar = FontAwesome.Sharp.IconChar.X
        btnCerrar.IconColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        btnCerrar.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnCerrar.IconSize = 25
        btnCerrar.Location = New Point(1049, 9)
        btnCerrar.Name = "btnCerrar"
        btnCerrar.Size = New Size(22, 23)
        btnCerrar.TabIndex = 4
        btnCerrar.UseVisualStyleBackColor = False
        ' 
        ' btnCloseChildForm
        ' 
        btnCloseChildForm.Dock = DockStyle.Left
        btnCloseChildForm.FlatAppearance.BorderSize = 0
        btnCloseChildForm.FlatStyle = FlatStyle.Flat
        btnCloseChildForm.Location = New Point(0, 0)
        btnCloseChildForm.Name = "btnCloseChildForm"
        btnCloseChildForm.Size = New Size(75, 67)
        btnCloseChildForm.TabIndex = 1
        btnCloseChildForm.UseVisualStyleBackColor = True
        ' 
        ' pnl_Contenedor
        ' 
        pnl_Contenedor.Controls.Add(pnlMenu)
        pnl_Contenedor.Dock = DockStyle.Fill
        pnl_Contenedor.Location = New Point(57, 67)
        pnl_Contenedor.Name = "pnl_Contenedor"
        pnl_Contenedor.Size = New Size(1083, 616)
        pnl_Contenedor.TabIndex = 2
        ' 
        ' tmr_OcultarMenu
        ' 
        tmr_OcultarMenu.Interval = 50
        ' 
        ' tmr_MostrarMenu
        ' 
        tmr_MostrarMenu.Interval = 50
        ' 
        ' tol_Mensajes
        ' 
        tol_Mensajes.AutomaticDelay = 900
        tol_Mensajes.BackColor = Color.CadetBlue
        tol_Mensajes.ForeColor = Color.Silver
        tol_Mensajes.IsBalloon = True
        tol_Mensajes.OwnerDraw = True
        ' 
        ' frm_Inicio
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1140, 683)
        Controls.Add(pnl_Contenedor)
        Controls.Add(pnl_Encabezado)
        Controls.Add(pnlMenuOpciones)
        Name = "frm_Inicio"
        Text = "frm_Inicio"
        pnlMenuOpciones.ResumeLayout(False)
        pnlMenu.ResumeLayout(False)
        CType(imgLogo, ComponentModel.ISupportInitialize).EndInit()
        pnl_Encabezado.ResumeLayout(False)
        pnl_Encabezado.PerformLayout()
        pnl_Contenedor.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlMenuOpciones As Panel
    Friend WithEvents pnlMenu As Panel
    Friend WithEvents pnl_Encabezado As Panel
    Friend WithEvents pnl_Contenedor As Panel
    Friend WithEvents btnCloseChildForm As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents bntMinimize As Button
    Friend WithEvents btnMaximize As Button
    Friend WithEvents tmr_OcultarMenu As Timer
    Friend WithEvents tmr_MostrarMenu As Timer
    Friend WithEvents tol_Mensajes As ToolTip
    Friend WithEvents IconButton8 As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton7 As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton6 As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton5 As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton4 As FontAwesome.Sharp.IconButton
    Friend WithEvents btnMantenedor As FontAwesome.Sharp.IconButton
    Friend WithEvents imgLogo As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents lblUsuario As Label
    Friend WithEvents lblCargo As Label
    Friend WithEvents btnEditarPerfil As FontAwesome.Sharp.IconButton
    Friend WithEvents btn_Maximizar As FontAwesome.Sharp.IconButton
    Friend WithEvents btn_Minimizar As FontAwesome.Sharp.IconButton
    Friend WithEvents btnCerrar As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton3 As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton1 As FontAwesome.Sharp.IconButton
    Friend WithEvents btn_1 As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton9 As FontAwesome.Sharp.IconButton
    Friend WithEvents lbl_Titulo As Label
    Friend WithEvents icoMenu As FontAwesome.Sharp.IconButton
    Friend WithEvents btn1 As Button
    Friend WithEvents Button12 As Button
    Friend WithEvents Button11 As Button
    Friend WithEvents btn11 As Button
    Friend WithEvents btn10 As Button
    Friend WithEvents btn9 As Button
    Friend WithEvents btn8 As Button
    Friend WithEvents btn7 As Button
    Friend WithEvents btn6 As Button
    Friend WithEvents btn5 As Button
    Friend WithEvents btn4 As Button
    Friend WithEvents btn3 As Button
    Friend WithEvents btn2 As Button
End Class
