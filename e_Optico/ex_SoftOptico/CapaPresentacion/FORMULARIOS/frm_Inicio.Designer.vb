<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Inicio
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
        components = New ComponentModel.Container()
        pnl_Menu = New Panel()
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
        pnl_Logo = New Panel()
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
        PictureBox1 = New PictureBox()
        tmr_OcultarMenu = New Timer(components)
        tmr_MostrarMenu = New Timer(components)
        tol_Mensajes = New ToolTip(components)
        pnl_Menu.SuspendLayout()
        CType(imgLogo, ComponentModel.ISupportInitialize).BeginInit()
        pnl_Encabezado.SuspendLayout()
        pnl_Contenedor.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pnl_Menu
        ' 
        pnl_Menu.BackColor = Color.FromArgb(CByte(51), CByte(51), CByte(76))
        pnl_Menu.Controls.Add(icoMenu)
        pnl_Menu.Controls.Add(IconButton9)
        pnl_Menu.Controls.Add(IconButton3)
        pnl_Menu.Controls.Add(IconButton1)
        pnl_Menu.Controls.Add(btn_1)
        pnl_Menu.Controls.Add(IconButton8)
        pnl_Menu.Controls.Add(IconButton7)
        pnl_Menu.Controls.Add(IconButton6)
        pnl_Menu.Controls.Add(IconButton5)
        pnl_Menu.Controls.Add(IconButton4)
        pnl_Menu.Controls.Add(btnMantenedor)
        pnl_Menu.Dock = DockStyle.Left
        pnl_Menu.Location = New Point(0, 0)
        pnl_Menu.Name = "pnl_Menu"
        pnl_Menu.Size = New Size(57, 683)
        pnl_Menu.TabIndex = 0
        ' 
        ' icoMenu
        ' 
        icoMenu.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        icoMenu.Cursor = Cursors.Hand
        icoMenu.FlatAppearance.BorderSize = 0
        icoMenu.FlatStyle = FlatStyle.Flat
        icoMenu.Font = New Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
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
        IconButton9.Font = New Font("Century Gothic", 6F)
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
        IconButton3.Font = New Font("Century Gothic", 6F)
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
        IconButton1.Font = New Font("Century Gothic", 6F)
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
        btn_1.Font = New Font("Century Gothic", 6F)
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
        IconButton8.Font = New Font("Century Gothic", 6F)
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
        IconButton7.Font = New Font("Century Gothic", 6F)
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
        IconButton6.Font = New Font("Century Gothic", 6F)
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
        IconButton5.Font = New Font("Century Gothic", 6F)
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
        IconButton4.Font = New Font("Century Gothic", 6F)
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
        btnMantenedor.Font = New Font("Century Gothic", 6F)
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
        ' pnl_Logo
        ' 
        pnl_Logo.AutoScroll = True
        pnl_Logo.BackColor = Color.WhiteSmoke
        pnl_Logo.Location = New Point(0, 0)
        pnl_Logo.Name = "pnl_Logo"
        pnl_Logo.Size = New Size(225, 561)
        pnl_Logo.TabIndex = 1
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
        lblUsuario.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
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
        btnCloseChildForm.Image = My.Resources.Resources.cross_out_2_
        btnCloseChildForm.Location = New Point(0, 0)
        btnCloseChildForm.Name = "btnCloseChildForm"
        btnCloseChildForm.Size = New Size(75, 67)
        btnCloseChildForm.TabIndex = 1
        btnCloseChildForm.UseVisualStyleBackColor = True
        ' 
        ' pnl_Contenedor
        ' 
        pnl_Contenedor.Controls.Add(PictureBox1)
        pnl_Contenedor.Controls.Add(pnl_Logo)
        pnl_Contenedor.Dock = DockStyle.Fill
        pnl_Contenedor.Location = New Point(57, 67)
        pnl_Contenedor.Name = "pnl_Contenedor"
        pnl_Contenedor.Size = New Size(1083, 616)
        pnl_Contenedor.TabIndex = 2
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Anchor = AnchorStyles.None
        PictureBox1.Image = My.Resources.Resources._1
        PictureBox1.Location = New Point(287, 100)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(553, 357)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
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
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1140, 683)
        Controls.Add(pnl_Contenedor)
        Controls.Add(pnl_Encabezado)
        Controls.Add(pnl_Menu)
        Name = "frm_Inicio"
        Text = "frm_Inicio"
        pnl_Menu.ResumeLayout(False)
        CType(imgLogo, ComponentModel.ISupportInitialize).EndInit()
        pnl_Encabezado.ResumeLayout(False)
        pnl_Encabezado.PerformLayout()
        pnl_Contenedor.ResumeLayout(False)
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnl_Menu As Panel
    Friend WithEvents pnl_Logo As Panel
    Friend WithEvents pnl_Encabezado As Panel
    Friend WithEvents pnl_Contenedor As Panel
    Friend WithEvents btnCloseChildForm As Button
    Friend WithEvents PictureBox1 As PictureBox
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
End Class
