<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_principal
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
        pnl_Titulo = New Panel()
        btn_Maximizar = New FontAwesome.Sharp.IconButton()
        btn_Minimizar = New FontAwesome.Sharp.IconButton()
        btn_Cerrar = New FontAwesome.Sharp.IconButton()
        Label1 = New Label()
        btn_Restore = New FontAwesome.Sharp.IconButton()
        lbl_Usuario = New Label()
        img_Usuario = New FontAwesome.Sharp.IconPictureBox()
        pnl_Menu = New Panel()
        Panel10 = New Panel()
        IconButton2 = New FontAwesome.Sharp.IconButton()
        Panel9 = New Panel()
        Panel8 = New Panel()
        Panel7 = New Panel()
        Panel6 = New Panel()
        Panel5 = New Panel()
        Panel4 = New Panel()
        Panel3 = New Panel()
        Panel2 = New Panel()
        Panel1 = New Panel()
        btn_Logout = New FontAwesome.Sharp.IconButton()
        IconButton9 = New FontAwesome.Sharp.IconButton()
        IconButton8 = New FontAwesome.Sharp.IconButton()
        IconButton7 = New FontAwesome.Sharp.IconButton()
        IconButton6 = New FontAwesome.Sharp.IconButton()
        IconButton5 = New FontAwesome.Sharp.IconButton()
        IconButton4 = New FontAwesome.Sharp.IconButton()
        IconButton3 = New FontAwesome.Sharp.IconButton()
        IconButton1 = New FontAwesome.Sharp.IconButton()
        tmr_OcultarMenu = New Timer(components)
        tmr_MostrarMenu = New Timer(components)
        pnl_Contenedor = New Panel()
        tol_Mensajes = New ToolTip(components)
        lbl_Posicion = New Label()
        lbl_Correo = New Label()
        pnl_Titulo.SuspendLayout()
        CType(img_Usuario, ComponentModel.ISupportInitialize).BeginInit()
        pnl_Menu.SuspendLayout()
        Panel10.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnl_Titulo
        ' 
        pnl_Titulo.BackColor = Color.DarkGoldenrod
        pnl_Titulo.Controls.Add(btn_Maximizar)
        pnl_Titulo.Controls.Add(btn_Minimizar)
        pnl_Titulo.Controls.Add(btn_Cerrar)
        pnl_Titulo.Controls.Add(Label1)
        pnl_Titulo.Controls.Add(btn_Restore)
        pnl_Titulo.Dock = DockStyle.Top
        pnl_Titulo.Location = New Point(0, 0)
        pnl_Titulo.Name = "pnl_Titulo"
        pnl_Titulo.Size = New Size(1300, 52)
        pnl_Titulo.TabIndex = 0
        ' 
        ' btn_Maximizar
        ' 
        btn_Maximizar.Anchor = AnchorStyles.Right
        btn_Maximizar.BackColor = Color.DarkGoldenrod
        btn_Maximizar.Cursor = Cursors.Hand
        btn_Maximizar.FlatAppearance.BorderSize = 0
        btn_Maximizar.FlatStyle = FlatStyle.Flat
        btn_Maximizar.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize
        btn_Maximizar.IconColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        btn_Maximizar.IconFont = FontAwesome.Sharp.IconFont.Auto
        btn_Maximizar.IconSize = 25
        btn_Maximizar.Location = New Point(1238, 16)
        btn_Maximizar.Name = "btn_Maximizar"
        btn_Maximizar.Size = New Size(22, 23)
        btn_Maximizar.TabIndex = 3
        btn_Maximizar.UseVisualStyleBackColor = False
        ' 
        ' btn_Minimizar
        ' 
        btn_Minimizar.Anchor = AnchorStyles.Right
        btn_Minimizar.BackColor = Color.DarkGoldenrod
        btn_Minimizar.Cursor = Cursors.Hand
        btn_Minimizar.FlatAppearance.BorderSize = 0
        btn_Minimizar.FlatStyle = FlatStyle.Flat
        btn_Minimizar.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize
        btn_Minimizar.IconColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        btn_Minimizar.IconFont = FontAwesome.Sharp.IconFont.Auto
        btn_Minimizar.IconSize = 25
        btn_Minimizar.Location = New Point(1208, 16)
        btn_Minimizar.Name = "btn_Minimizar"
        btn_Minimizar.Size = New Size(22, 23)
        btn_Minimizar.TabIndex = 2
        btn_Minimizar.UseVisualStyleBackColor = False
        ' 
        ' btn_Cerrar
        ' 
        btn_Cerrar.Anchor = AnchorStyles.Right
        btn_Cerrar.BackColor = Color.DarkGoldenrod
        btn_Cerrar.Cursor = Cursors.Hand
        btn_Cerrar.FlatAppearance.BorderSize = 0
        btn_Cerrar.FlatStyle = FlatStyle.Flat
        btn_Cerrar.IconChar = FontAwesome.Sharp.IconChar.X
        btn_Cerrar.IconColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        btn_Cerrar.IconFont = FontAwesome.Sharp.IconFont.Auto
        btn_Cerrar.IconSize = 25
        btn_Cerrar.Location = New Point(1268, 16)
        btn_Cerrar.Name = "btn_Cerrar"
        btn_Cerrar.Size = New Size(22, 23)
        btn_Cerrar.TabIndex = 1
        btn_Cerrar.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.FlatStyle = FlatStyle.System
        Label1.Font = New Font("Exotc350 Bd BT", 20.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.White
        Label1.Location = New Point(12, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(275, 31)
        Label1.TabIndex = 0
        Label1.Text = "SISTEMA DE VENTAS "
        ' 
        ' btn_Restore
        ' 
        btn_Restore.Anchor = AnchorStyles.Right
        btn_Restore.Cursor = Cursors.Hand
        btn_Restore.FlatAppearance.BorderSize = 0
        btn_Restore.FlatStyle = FlatStyle.Flat
        btn_Restore.IconChar = FontAwesome.Sharp.IconChar.WindowRestore
        btn_Restore.IconColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        btn_Restore.IconFont = FontAwesome.Sharp.IconFont.Auto
        btn_Restore.IconSize = 25
        btn_Restore.Location = New Point(1238, 16)
        btn_Restore.Name = "btn_Restore"
        btn_Restore.Size = New Size(22, 23)
        btn_Restore.TabIndex = 4
        btn_Restore.UseVisualStyleBackColor = True
        ' 
        ' lbl_Usuario
        ' 
        lbl_Usuario.AutoSize = True
        lbl_Usuario.FlatStyle = FlatStyle.System
        lbl_Usuario.Font = New Font("Century Gothic", 10F)
        lbl_Usuario.ForeColor = Color.White
        lbl_Usuario.Location = New Point(64, 53)
        lbl_Usuario.Name = "lbl_Usuario"
        lbl_Usuario.Size = New Size(58, 19)
        lbl_Usuario.TabIndex = 6
        lbl_Usuario.Text = "Usuario"
        ' 
        ' img_Usuario
        ' 
        img_Usuario.BackColor = Color.FromArgb(CByte(37), CByte(46), CByte(70))
        img_Usuario.ForeColor = Color.Silver
        img_Usuario.IconChar = FontAwesome.Sharp.IconChar.UserLarge
        img_Usuario.IconColor = Color.Silver
        img_Usuario.IconFont = FontAwesome.Sharp.IconFont.Auto
        img_Usuario.IconSize = 53
        img_Usuario.Location = New Point(3, 43)
        img_Usuario.Name = "img_Usuario"
        img_Usuario.Size = New Size(58, 53)
        img_Usuario.TabIndex = 5
        img_Usuario.TabStop = False
        ' 
        ' pnl_Menu
        ' 
        pnl_Menu.BackColor = Color.FromArgb(CByte(37), CByte(46), CByte(59))
        pnl_Menu.Controls.Add(Panel10)
        pnl_Menu.Controls.Add(Panel9)
        pnl_Menu.Controls.Add(Panel8)
        pnl_Menu.Controls.Add(Panel7)
        pnl_Menu.Controls.Add(Panel6)
        pnl_Menu.Controls.Add(Panel5)
        pnl_Menu.Controls.Add(Panel4)
        pnl_Menu.Controls.Add(Panel3)
        pnl_Menu.Controls.Add(Panel2)
        pnl_Menu.Controls.Add(Panel1)
        pnl_Menu.Controls.Add(btn_Logout)
        pnl_Menu.Controls.Add(IconButton9)
        pnl_Menu.Controls.Add(IconButton8)
        pnl_Menu.Controls.Add(IconButton7)
        pnl_Menu.Controls.Add(IconButton6)
        pnl_Menu.Controls.Add(IconButton5)
        pnl_Menu.Controls.Add(IconButton4)
        pnl_Menu.Controls.Add(IconButton3)
        pnl_Menu.Controls.Add(IconButton1)
        pnl_Menu.Dock = DockStyle.Left
        pnl_Menu.Location = New Point(0, 52)
        pnl_Menu.Name = "pnl_Menu"
        pnl_Menu.Size = New Size(220, 648)
        pnl_Menu.TabIndex = 1
        ' 
        ' Panel10
        ' 
        Panel10.BackColor = Color.FromArgb(CByte(37), CByte(46), CByte(70))
        Panel10.Controls.Add(lbl_Correo)
        Panel10.Controls.Add(lbl_Posicion)
        Panel10.Controls.Add(IconButton2)
        Panel10.Controls.Add(lbl_Usuario)
        Panel10.Controls.Add(img_Usuario)
        Panel10.Dock = DockStyle.Top
        Panel10.Location = New Point(0, 0)
        Panel10.Name = "Panel10"
        Panel10.Size = New Size(220, 100)
        Panel10.TabIndex = 7
        ' 
        ' IconButton2
        ' 
        IconButton2.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        IconButton2.Cursor = Cursors.Hand
        IconButton2.FlatAppearance.BorderSize = 0
        IconButton2.FlatStyle = FlatStyle.Flat
        IconButton2.Font = New Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        IconButton2.ForeColor = Color.White
        IconButton2.IconChar = FontAwesome.Sharp.IconChar.Bars
        IconButton2.IconColor = Color.White
        IconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconButton2.IconSize = 50
        IconButton2.Location = New Point(172, 2)
        IconButton2.Name = "IconButton2"
        IconButton2.Size = New Size(40, 40)
        IconButton2.TabIndex = 1
        IconButton2.UseVisualStyleBackColor = True
        ' 
        ' Panel9
        ' 
        Panel9.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        Panel9.BackColor = Color.DarkGoldenrod
        Panel9.Location = New Point(3, 590)
        Panel9.Name = "Panel9"
        Panel9.Size = New Size(5, 46)
        Panel9.TabIndex = 4
        ' 
        ' Panel8
        ' 
        Panel8.BackColor = Color.DarkGoldenrod
        Panel8.Location = New Point(2, 490)
        Panel8.Name = "Panel8"
        Panel8.Size = New Size(5, 46)
        Panel8.TabIndex = 3
        ' 
        ' Panel7
        ' 
        Panel7.BackColor = Color.DarkGoldenrod
        Panel7.Location = New Point(2, 438)
        Panel7.Name = "Panel7"
        Panel7.Size = New Size(5, 46)
        Panel7.TabIndex = 3
        ' 
        ' Panel6
        ' 
        Panel6.BackColor = Color.DarkGoldenrod
        Panel6.Location = New Point(2, 384)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(5, 46)
        Panel6.TabIndex = 3
        ' 
        ' Panel5
        ' 
        Panel5.BackColor = Color.DarkGoldenrod
        Panel5.Location = New Point(2, 330)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(5, 46)
        Panel5.TabIndex = 3
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = Color.DarkGoldenrod
        Panel4.Location = New Point(2, 276)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(5, 46)
        Panel4.TabIndex = 10
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.DarkGoldenrod
        Panel3.Location = New Point(2, 221)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(5, 46)
        Panel3.TabIndex = 9
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.DarkGoldenrod
        Panel2.Location = New Point(2, 166)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(5, 46)
        Panel2.TabIndex = 3
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.DarkGoldenrod
        Panel1.Location = New Point(2, 112)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(5, 46)
        Panel1.TabIndex = 2
        ' 
        ' btn_Logout
        ' 
        btn_Logout.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btn_Logout.Cursor = Cursors.Hand
        btn_Logout.FlatAppearance.BorderSize = 0
        btn_Logout.FlatAppearance.MouseDownBackColor = Color.DarkGoldenrod
        btn_Logout.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(44), CByte(55), CByte(70))
        btn_Logout.FlatStyle = FlatStyle.Flat
        btn_Logout.Font = New Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btn_Logout.ForeColor = Color.White
        btn_Logout.IconChar = FontAwesome.Sharp.IconChar.RightToBracket
        btn_Logout.IconColor = Color.White
        btn_Logout.IconFont = FontAwesome.Sharp.IconFont.Auto
        btn_Logout.IconSize = 45
        btn_Logout.ImageAlign = ContentAlignment.MiddleLeft
        btn_Logout.Location = New Point(3, 590)
        btn_Logout.Name = "btn_Logout"
        btn_Logout.Size = New Size(217, 46)
        btn_Logout.TabIndex = 8
        btn_Logout.Text = "    Cerrar Sesión"
        btn_Logout.TextAlign = ContentAlignment.MiddleLeft
        btn_Logout.TextImageRelation = TextImageRelation.ImageBeforeText
        tol_Mensajes.SetToolTip(btn_Logout, "Cerrar Sesión")
        btn_Logout.UseVisualStyleBackColor = True
        ' 
        ' IconButton9
        ' 
        IconButton9.Cursor = Cursors.Hand
        IconButton9.FlatAppearance.BorderSize = 0
        IconButton9.FlatAppearance.MouseDownBackColor = Color.DarkGoldenrod
        IconButton9.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(44), CByte(55), CByte(70))
        IconButton9.FlatStyle = FlatStyle.Flat
        IconButton9.Font = New Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        IconButton9.ForeColor = Color.White
        IconButton9.IconChar = FontAwesome.Sharp.IconChar.CircleInfo
        IconButton9.IconColor = Color.White
        IconButton9.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconButton9.IconSize = 45
        IconButton9.ImageAlign = ContentAlignment.MiddleLeft
        IconButton9.Location = New Point(3, 490)
        IconButton9.Name = "IconButton9"
        IconButton9.Size = New Size(217, 46)
        IconButton9.TabIndex = 8
        IconButton9.Text = "    Acerca de..."
        IconButton9.TextAlign = ContentAlignment.MiddleLeft
        IconButton9.TextImageRelation = TextImageRelation.ImageBeforeText
        tol_Mensajes.SetToolTip(IconButton9, "Conocer quienes somos")
        IconButton9.UseVisualStyleBackColor = True
        ' 
        ' IconButton8
        ' 
        IconButton8.Cursor = Cursors.Hand
        IconButton8.FlatAppearance.BorderSize = 0
        IconButton8.FlatAppearance.MouseDownBackColor = Color.DarkGoldenrod
        IconButton8.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(44), CByte(55), CByte(70))
        IconButton8.FlatStyle = FlatStyle.Flat
        IconButton8.Font = New Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        IconButton8.ForeColor = Color.White
        IconButton8.IconChar = FontAwesome.Sharp.IconChar.BarChart
        IconButton8.IconColor = Color.White
        IconButton8.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconButton8.IconSize = 45
        IconButton8.ImageAlign = ContentAlignment.MiddleLeft
        IconButton8.Location = New Point(3, 436)
        IconButton8.Name = "IconButton8"
        IconButton8.Size = New Size(217, 46)
        IconButton8.TabIndex = 7
        IconButton8.Text = "    Reportes"
        IconButton8.TextAlign = ContentAlignment.MiddleLeft
        IconButton8.TextImageRelation = TextImageRelation.ImageBeforeText
        tol_Mensajes.SetToolTip(IconButton8, "Ver los reportes y facturas")
        IconButton8.UseVisualStyleBackColor = True
        ' 
        ' IconButton7
        ' 
        IconButton7.Cursor = Cursors.Hand
        IconButton7.FlatAppearance.BorderSize = 0
        IconButton7.FlatAppearance.MouseDownBackColor = Color.DarkGoldenrod
        IconButton7.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(44), CByte(55), CByte(70))
        IconButton7.FlatStyle = FlatStyle.Flat
        IconButton7.Font = New Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        IconButton7.ForeColor = Color.White
        IconButton7.IconChar = FontAwesome.Sharp.IconChar.Vcard
        IconButton7.IconColor = Color.White
        IconButton7.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconButton7.IconSize = 45
        IconButton7.ImageAlign = ContentAlignment.MiddleLeft
        IconButton7.Location = New Point(3, 382)
        IconButton7.Name = "IconButton7"
        IconButton7.Size = New Size(217, 46)
        IconButton7.TabIndex = 6
        IconButton7.Text = "    Proveedor"
        IconButton7.TextAlign = ContentAlignment.MiddleLeft
        IconButton7.TextImageRelation = TextImageRelation.ImageBeforeText
        tol_Mensajes.SetToolTip(IconButton7, "Administrar datos del proveedor")
        IconButton7.UseVisualStyleBackColor = True
        ' 
        ' IconButton6
        ' 
        IconButton6.Cursor = Cursors.Hand
        IconButton6.FlatAppearance.BorderSize = 0
        IconButton6.FlatAppearance.MouseDownBackColor = Color.DarkGoldenrod
        IconButton6.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(44), CByte(55), CByte(70))
        IconButton6.FlatStyle = FlatStyle.Flat
        IconButton6.Font = New Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        IconButton6.ForeColor = Color.White
        IconButton6.IconChar = FontAwesome.Sharp.IconChar.UserFriends
        IconButton6.IconColor = Color.White
        IconButton6.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconButton6.IconSize = 45
        IconButton6.ImageAlign = ContentAlignment.MiddleLeft
        IconButton6.Location = New Point(3, 328)
        IconButton6.Name = "IconButton6"
        IconButton6.Size = New Size(217, 46)
        IconButton6.TabIndex = 5
        IconButton6.Text = "    Clientes"
        IconButton6.TextAlign = ContentAlignment.MiddleLeft
        IconButton6.TextImageRelation = TextImageRelation.ImageBeforeText
        tol_Mensajes.SetToolTip(IconButton6, "Administrar datos del cliente")
        IconButton6.UseVisualStyleBackColor = True
        ' 
        ' IconButton5
        ' 
        IconButton5.Cursor = Cursors.Hand
        IconButton5.FlatAppearance.BorderSize = 0
        IconButton5.FlatAppearance.MouseDownBackColor = Color.DarkGoldenrod
        IconButton5.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(44), CByte(55), CByte(70))
        IconButton5.FlatStyle = FlatStyle.Flat
        IconButton5.Font = New Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        IconButton5.ForeColor = Color.White
        IconButton5.IconChar = FontAwesome.Sharp.IconChar.CartFlatbed
        IconButton5.IconColor = Color.White
        IconButton5.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconButton5.IconSize = 45
        IconButton5.ImageAlign = ContentAlignment.MiddleLeft
        IconButton5.Location = New Point(3, 274)
        IconButton5.Name = "IconButton5"
        IconButton5.Size = New Size(217, 46)
        IconButton5.TabIndex = 4
        IconButton5.Text = "    Compra"
        IconButton5.TextAlign = ContentAlignment.MiddleLeft
        IconButton5.TextImageRelation = TextImageRelation.ImageBeforeText
        tol_Mensajes.SetToolTip(IconButton5, "Realizar nueva compra")
        IconButton5.UseVisualStyleBackColor = True
        ' 
        ' IconButton4
        ' 
        IconButton4.Cursor = Cursors.Hand
        IconButton4.FlatAppearance.BorderSize = 0
        IconButton4.FlatAppearance.MouseDownBackColor = Color.DarkGoldenrod
        IconButton4.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(44), CByte(55), CByte(70))
        IconButton4.FlatStyle = FlatStyle.Flat
        IconButton4.Font = New Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        IconButton4.ForeColor = Color.White
        IconButton4.IconChar = FontAwesome.Sharp.IconChar.Tags
        IconButton4.IconColor = Color.White
        IconButton4.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconButton4.IconSize = 45
        IconButton4.ImageAlign = ContentAlignment.MiddleLeft
        IconButton4.Location = New Point(3, 220)
        IconButton4.Name = "IconButton4"
        IconButton4.Size = New Size(217, 46)
        IconButton4.TabIndex = 3
        IconButton4.Text = "    Venta"
        IconButton4.TextAlign = ContentAlignment.MiddleLeft
        IconButton4.TextImageRelation = TextImageRelation.ImageBeforeText
        tol_Mensajes.SetToolTip(IconButton4, "Realizar nueva venta")
        IconButton4.UseVisualStyleBackColor = True
        ' 
        ' IconButton3
        ' 
        IconButton3.Cursor = Cursors.Hand
        IconButton3.FlatAppearance.BorderSize = 0
        IconButton3.FlatAppearance.MouseDownBackColor = Color.DarkGoldenrod
        IconButton3.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(44), CByte(55), CByte(70))
        IconButton3.FlatStyle = FlatStyle.Flat
        IconButton3.Font = New Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        IconButton3.ForeColor = Color.White
        IconButton3.IconChar = FontAwesome.Sharp.IconChar.Tools
        IconButton3.IconColor = Color.White
        IconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconButton3.IconSize = 45
        IconButton3.ImageAlign = ContentAlignment.MiddleLeft
        IconButton3.Location = New Point(3, 166)
        IconButton3.Name = "IconButton3"
        IconButton3.Size = New Size(217, 46)
        IconButton3.TabIndex = 2
        IconButton3.Text = "    Mantenedor"
        IconButton3.TextAlign = ContentAlignment.MiddleLeft
        IconButton3.TextImageRelation = TextImageRelation.ImageBeforeText
        tol_Mensajes.SetToolTip(IconButton3, "Mantenimiento del Sistema")
        IconButton3.UseVisualStyleBackColor = True
        ' 
        ' IconButton1
        ' 
        IconButton1.Cursor = Cursors.Hand
        IconButton1.FlatAppearance.BorderSize = 0
        IconButton1.FlatAppearance.MouseDownBackColor = Color.DarkGoldenrod
        IconButton1.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(44), CByte(55), CByte(70))
        IconButton1.FlatStyle = FlatStyle.Flat
        IconButton1.Font = New Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        IconButton1.ForeColor = Color.White
        IconButton1.IconChar = FontAwesome.Sharp.IconChar.UsersCog
        IconButton1.IconColor = Color.White
        IconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconButton1.IconSize = 45
        IconButton1.ImageAlign = ContentAlignment.MiddleLeft
        IconButton1.Location = New Point(3, 112)
        IconButton1.Name = "IconButton1"
        IconButton1.Size = New Size(217, 46)
        IconButton1.TabIndex = 0
        IconButton1.Text = "    Usuarios"
        IconButton1.TextAlign = ContentAlignment.MiddleLeft
        IconButton1.TextImageRelation = TextImageRelation.ImageBeforeText
        tol_Mensajes.SetToolTip(IconButton1, "Administrar Usuarios.")
        IconButton1.UseVisualStyleBackColor = True
        ' 
        ' tmr_OcultarMenu
        ' 
        tmr_OcultarMenu.Interval = 50
        ' 
        ' tmr_MostrarMenu
        ' 
        tmr_MostrarMenu.Interval = 50
        ' 
        ' pnl_Contenedor
        ' 
        pnl_Contenedor.BackColor = Color.White
        pnl_Contenedor.Dock = DockStyle.Fill
        pnl_Contenedor.Location = New Point(220, 52)
        pnl_Contenedor.Name = "pnl_Contenedor"
        pnl_Contenedor.Size = New Size(1080, 648)
        pnl_Contenedor.TabIndex = 2
        ' 
        ' tol_Mensajes
        ' 
        tol_Mensajes.AutomaticDelay = 900
        tol_Mensajes.BackColor = Color.CadetBlue
        tol_Mensajes.ForeColor = Color.Silver
        tol_Mensajes.IsBalloon = True
        tol_Mensajes.OwnerDraw = True
        ' 
        ' lbl_Posicion
        ' 
        lbl_Posicion.AutoSize = True
        lbl_Posicion.FlatStyle = FlatStyle.System
        lbl_Posicion.Font = New Font("Century Gothic", 10F)
        lbl_Posicion.ForeColor = Color.White
        lbl_Posicion.Location = New Point(64, 34)
        lbl_Posicion.Name = "lbl_Posicion"
        lbl_Posicion.Size = New Size(58, 19)
        lbl_Posicion.TabIndex = 7
        lbl_Posicion.Text = "Usuario"
        ' 
        ' lbl_Correo
        ' 
        lbl_Correo.AutoSize = True
        lbl_Correo.FlatStyle = FlatStyle.System
        lbl_Correo.Font = New Font("Century Gothic", 10F)
        lbl_Correo.ForeColor = Color.White
        lbl_Correo.Location = New Point(64, 72)
        lbl_Correo.Name = "lbl_Correo"
        lbl_Correo.Size = New Size(58, 19)
        lbl_Correo.TabIndex = 8
        lbl_Correo.Text = "Usuario"
        ' 
        ' frm_principal
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1300, 700)
        Controls.Add(pnl_Contenedor)
        Controls.Add(pnl_Menu)
        Controls.Add(pnl_Titulo)
        FormBorderStyle = FormBorderStyle.None
        Name = "frm_principal"
        StartPosition = FormStartPosition.CenterScreen
        pnl_Titulo.ResumeLayout(False)
        pnl_Titulo.PerformLayout()
        CType(img_Usuario, ComponentModel.ISupportInitialize).EndInit()
        pnl_Menu.ResumeLayout(False)
        Panel10.ResumeLayout(False)
        Panel10.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnl_Titulo As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents pnl_Menu As Panel
    Friend WithEvents btn_Cerrar As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton1 As FontAwesome.Sharp.IconButton
    Friend WithEvents btn_Maximizar As FontAwesome.Sharp.IconButton
    Friend WithEvents btn_Minimizar As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton2 As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton8 As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton7 As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton6 As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton5 As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton4 As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton3 As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton9 As FontAwesome.Sharp.IconButton
    Friend WithEvents btn_Restore As FontAwesome.Sharp.IconButton
    Friend WithEvents tmr_OcultarMenu As Timer
    Friend WithEvents tmr_MostrarMenu As Timer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents pnl_Contenedor As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents btn_Logout As FontAwesome.Sharp.IconButton
    Friend WithEvents tol_Mensajes As ToolTip
    Friend WithEvents img_Usuario As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents lbl_Usuario As Label
    Friend WithEvents Panel10 As Panel
    Friend WithEvents lbl_Posicion As Label
    Friend WithEvents lbl_Correo As Label
End Class
