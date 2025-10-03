<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPrincipal
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
        pnlEncabezado = New Panel()
        tlySuperior = New TableLayoutPanel()
        pnlBotones = New Panel()
        btnSalir = New FontAwesome.Sharp.IconButton()
        btnMaximizar = New FontAwesome.Sharp.IconButton()
        btnMinimizar = New FontAwesome.Sharp.IconButton()
        lblLocalidad = New HeaderUI()
        lblEmpleado = New HeaderUI()
        pnlSalirfrm = New Panel()
        btnSalirFrmHijo = New FontAwesome.Sharp.IconButton()
        lblTitulo = New HeaderUI()
        pnlBars = New Panel()
        btnMostrarMenu = New FontAwesome.Sharp.IconButton()
        pnlMenu = New Panel()
        pnlDrawer = New Panel()
        pnlContenedor = New Panel()
        DrawerTimer = New Timer(components)
        pnlEncabezado.SuspendLayout()
        tlySuperior.SuspendLayout()
        pnlBotones.SuspendLayout()
        pnlSalirfrm.SuspendLayout()
        pnlBars.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlEncabezado
        ' 
        pnlEncabezado.BackColor = Color.FromArgb(CByte(54), CByte(116), CByte(164))
        pnlEncabezado.Controls.Add(tlySuperior)
        pnlEncabezado.Dock = DockStyle.Top
        pnlEncabezado.Location = New Point(0, 0)
        pnlEncabezado.Name = "pnlEncabezado"
        pnlEncabezado.Size = New Size(1370, 64)
        pnlEncabezado.TabIndex = 0
        ' 
        ' tlySuperior
        ' 
        tlySuperior.ColumnCount = 6
        tlySuperior.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 60F))
        tlySuperior.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 80F))
        tlySuperior.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 420F))
        tlySuperior.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 330F))
        tlySuperior.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 330F))
        tlySuperior.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 170F))
        tlySuperior.Controls.Add(pnlBotones, 5, 0)
        tlySuperior.Controls.Add(lblLocalidad, 4, 0)
        tlySuperior.Controls.Add(lblEmpleado, 3, 0)
        tlySuperior.Controls.Add(pnlSalirfrm, 1, 0)
        tlySuperior.Controls.Add(lblTitulo, 2, 0)
        tlySuperior.Controls.Add(pnlBars, 0, 0)
        tlySuperior.Dock = DockStyle.Fill
        tlySuperior.Location = New Point(0, 0)
        tlySuperior.Name = "tlySuperior"
        tlySuperior.RowCount = 1
        tlySuperior.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        tlySuperior.Size = New Size(1370, 64)
        tlySuperior.TabIndex = 1
        ' 
        ' pnlBotones
        ' 
        pnlBotones.Controls.Add(btnSalir)
        pnlBotones.Controls.Add(btnMaximizar)
        pnlBotones.Controls.Add(btnMinimizar)
        pnlBotones.Dock = DockStyle.Right
        pnlBotones.Location = New Point(1223, 3)
        pnlBotones.Name = "pnlBotones"
        pnlBotones.Size = New Size(164, 58)
        pnlBotones.TabIndex = 5
        ' 
        ' btnSalir
        ' 
        btnSalir.BackColor = Color.Transparent
        btnSalir.FlatAppearance.BorderSize = 0
        btnSalir.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnSalir.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnSalir.FlatStyle = FlatStyle.Flat
        btnSalir.IconChar = FontAwesome.Sharp.IconChar.X
        btnSalir.IconColor = Color.WhiteSmoke
        btnSalir.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnSalir.IconSize = 22
        btnSalir.Location = New Point(92, 15)
        btnSalir.Name = "btnSalir"
        btnSalir.Size = New Size(23, 23)
        btnSalir.TabIndex = 0
        btnSalir.UseVisualStyleBackColor = False
        ' 
        ' btnMaximizar
        ' 
        btnMaximizar.BackColor = Color.Transparent
        btnMaximizar.FlatAppearance.BorderSize = 0
        btnMaximizar.FlatStyle = FlatStyle.Flat
        btnMaximizar.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize
        btnMaximizar.IconColor = Color.WhiteSmoke
        btnMaximizar.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnMaximizar.IconSize = 22
        btnMaximizar.Location = New Point(54, 14)
        btnMaximizar.Name = "btnMaximizar"
        btnMaximizar.Size = New Size(23, 23)
        btnMaximizar.TabIndex = 0
        btnMaximizar.UseVisualStyleBackColor = False
        ' 
        ' btnMinimizar
        ' 
        btnMinimizar.BackColor = Color.Transparent
        btnMinimizar.FlatAppearance.BorderSize = 0
        btnMinimizar.FlatStyle = FlatStyle.Flat
        btnMinimizar.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize
        btnMinimizar.IconColor = Color.WhiteSmoke
        btnMinimizar.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnMinimizar.IconSize = 22
        btnMinimizar.Location = New Point(16, 14)
        btnMinimizar.Name = "btnMinimizar"
        btnMinimizar.Size = New Size(23, 23)
        btnMinimizar.TabIndex = 0
        btnMinimizar.UseVisualStyleBackColor = False
        ' 
        ' lblLocalidad
        ' 
        lblLocalidad.BackColor = Color.Transparent
        lblLocalidad.ColorFondo = Color.FromArgb(CByte(54), CByte(116), CByte(164))
        lblLocalidad.ColorTexto = Color.WhiteSmoke
        lblLocalidad.Dimension = 12
        lblLocalidad.Dock = DockStyle.Fill
        lblLocalidad.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblLocalidad.Icono = FontAwesome.Sharp.IconChar.Eye
        lblLocalidad.Location = New Point(893, 3)
        lblLocalidad.MostrarSeparador = False
        lblLocalidad.Name = "lblLocalidad"
        lblLocalidad.Size = New Size(324, 58)
        lblLocalidad.Subtitulo = "Óptica Atlantico "
        lblLocalidad.TabIndex = 3
        lblLocalidad.Titulo = "Sistema de Integral de Gestion"
        ' 
        ' lblEmpleado
        ' 
        lblEmpleado.BackColor = Color.Transparent
        lblEmpleado.ColorFondo = Color.FromArgb(CByte(54), CByte(116), CByte(164))
        lblEmpleado.ColorTexto = Color.WhiteSmoke
        lblEmpleado.Dimension = 12
        lblEmpleado.Dock = DockStyle.Fill
        lblEmpleado.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblEmpleado.Icono = FontAwesome.Sharp.IconChar.Eye
        lblEmpleado.Location = New Point(563, 3)
        lblEmpleado.MostrarSeparador = False
        lblEmpleado.Name = "lblEmpleado"
        lblEmpleado.Size = New Size(324, 58)
        lblEmpleado.Subtitulo = "Óptica Atlantico "
        lblEmpleado.TabIndex = 2
        lblEmpleado.Titulo = "Sistema de Integral de Gestion"
        ' 
        ' pnlSalirfrm
        ' 
        pnlSalirfrm.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(45))
        pnlSalirfrm.Controls.Add(btnSalirFrmHijo)
        pnlSalirfrm.Dock = DockStyle.Fill
        pnlSalirfrm.Location = New Point(63, 3)
        pnlSalirfrm.Name = "pnlSalirfrm"
        pnlSalirfrm.Size = New Size(74, 58)
        pnlSalirfrm.TabIndex = 1
        ' 
        ' btnSalirFrmHijo
        ' 
        btnSalirFrmHijo.BackColor = Color.FromArgb(CByte(53), CByte(113), CByte(165))
        btnSalirFrmHijo.Dock = DockStyle.Fill
        btnSalirFrmHijo.FlatAppearance.BorderSize = 0
        btnSalirFrmHijo.FlatStyle = FlatStyle.Flat
        btnSalirFrmHijo.IconChar = FontAwesome.Sharp.IconChar.Reply
        btnSalirFrmHijo.IconColor = Color.MistyRose
        btnSalirFrmHijo.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnSalirFrmHijo.IconSize = 40
        btnSalirFrmHijo.Location = New Point(0, 0)
        btnSalirFrmHijo.Name = "btnSalirFrmHijo"
        btnSalirFrmHijo.Size = New Size(74, 58)
        btnSalirFrmHijo.TabIndex = 0
        btnSalirFrmHijo.UseVisualStyleBackColor = False
        ' 
        ' lblTitulo
        ' 
        lblTitulo.BackColor = Color.Transparent
        lblTitulo.ColorFondo = Color.FromArgb(CByte(54), CByte(116), CByte(164))
        lblTitulo.ColorTexto = Color.WhiteSmoke
        lblTitulo.Dimension = 12
        lblTitulo.Dock = DockStyle.Fill
        lblTitulo.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitulo.Icono = FontAwesome.Sharp.IconChar.Eye
        lblTitulo.Location = New Point(143, 3)
        lblTitulo.MostrarSeparador = False
        lblTitulo.Name = "lblTitulo"
        lblTitulo.Size = New Size(414, 58)
        lblTitulo.Subtitulo = "Óptica Atlantico "
        lblTitulo.TabIndex = 0
        lblTitulo.Titulo = "Sistema de Integral de Gestion"
        ' 
        ' pnlBars
        ' 
        pnlBars.BackColor = Color.FromArgb(CByte(51), CByte(51), CByte(76))
        pnlBars.Controls.Add(btnMostrarMenu)
        pnlBars.Dock = DockStyle.Fill
        pnlBars.Location = New Point(0, 0)
        pnlBars.Margin = New Padding(0)
        pnlBars.Name = "pnlBars"
        pnlBars.Size = New Size(60, 64)
        pnlBars.TabIndex = 0
        ' 
        ' btnMostrarMenu
        ' 
        btnMostrarMenu.BackColor = Color.FromArgb(CByte(54), CByte(116), CByte(164))
        btnMostrarMenu.Dock = DockStyle.Fill
        btnMostrarMenu.FlatAppearance.BorderSize = 0
        btnMostrarMenu.FlatStyle = FlatStyle.Flat
        btnMostrarMenu.IconChar = FontAwesome.Sharp.IconChar.Bars
        btnMostrarMenu.IconColor = Color.Black
        btnMostrarMenu.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnMostrarMenu.Location = New Point(0, 0)
        btnMostrarMenu.Name = "btnMostrarMenu"
        btnMostrarMenu.Size = New Size(60, 64)
        btnMostrarMenu.TabIndex = 0
        btnMostrarMenu.Tag = "Menu"
        btnMostrarMenu.UseVisualStyleBackColor = False
        ' 
        ' pnlMenu
        ' 
        pnlMenu.BackColor = Color.White
        pnlMenu.Dock = DockStyle.Left
        pnlMenu.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        pnlMenu.Location = New Point(0, 64)
        pnlMenu.Name = "pnlMenu"
        pnlMenu.Size = New Size(220, 562)
        pnlMenu.TabIndex = 1
        ' 
        ' pnlDrawer
        ' 
        pnlDrawer.BackColor = Color.White
        pnlDrawer.Dock = DockStyle.Left
        pnlDrawer.Location = New Point(220, 64)
        pnlDrawer.Name = "pnlDrawer"
        pnlDrawer.Size = New Size(0, 562)
        pnlDrawer.TabIndex = 2
        ' 
        ' pnlContenedor
        ' 
        pnlContenedor.BackColor = Color.White
        pnlContenedor.BackgroundImageLayout = ImageLayout.Stretch
        pnlContenedor.Dock = DockStyle.Fill
        pnlContenedor.Location = New Point(220, 64)
        pnlContenedor.Name = "pnlContenedor"
        pnlContenedor.Size = New Size(1150, 562)
        pnlContenedor.TabIndex = 3
        ' 
        ' DrawerTimer
        ' 
        DrawerTimer.Interval = 10
        ' 
        ' frmPrincipal
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1370, 626)
        Controls.Add(pnlContenedor)
        Controls.Add(pnlDrawer)
        Controls.Add(pnlMenu)
        Controls.Add(pnlEncabezado)
        Name = "frmPrincipal"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Principal"
        WindowState = FormWindowState.Maximized
        pnlEncabezado.ResumeLayout(False)
        tlySuperior.ResumeLayout(False)
        pnlBotones.ResumeLayout(False)
        pnlSalirfrm.ResumeLayout(False)
        pnlBars.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents pnlBars As Panel
    Friend WithEvents pnlSalirfrm As Panel
    Friend WithEvents pnlBotones As Panel
    Friend WithEvents btnMostrarMenu As FontAwesome.Sharp.IconButton
    Friend WithEvents btnSalirFrmHijo As FontAwesome.Sharp.IconButton
    Friend WithEvents lblTitulo As HeaderUI
    Friend WithEvents btnMinimizar As FontAwesome.Sharp.IconButton
    Friend WithEvents btnMaximizar As FontAwesome.Sharp.IconButton
    Friend WithEvents pnlMenu As Panel
    Friend WithEvents pnlDrawer As Panel
    Friend WithEvents pnlContenedor As Panel
    Friend WithEvents DrawerTimer As New Timer
    Friend WithEvents btnSalir As FontAwesome.Sharp.IconButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents pnlRol As Panel
    Friend WithEvents tlySuperior As TableLayoutPanel
    Friend WithEvents lblLocalidad As HeaderUI
    Friend WithEvents lblEmpleado As HeaderUI
End Class
