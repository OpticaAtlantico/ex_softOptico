<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Principal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Principal))
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
        btnAjustes = New FontAwesome.Sharp.IconButton()
        btnAnalisis = New FontAwesome.Sharp.IconButton()
        btnReporte = New FontAwesome.Sharp.IconButton()
        btnNomina = New FontAwesome.Sharp.IconButton()
        btnComision = New FontAwesome.Sharp.IconButton()
        btnEmpleado = New FontAwesome.Sharp.IconButton()
        btnProveedor = New FontAwesome.Sharp.IconButton()
        btnCompra = New FontAwesome.Sharp.IconButton()
        btnVenta = New FontAwesome.Sharp.IconButton()
        btnInventario = New FontAwesome.Sharp.IconButton()
        pnlDrawer = New Panel()
        pnlContenedor = New Panel()
        DrawerTimer = New Timer(components)
        pnlEncabezado.SuspendLayout()
        tlySuperior.SuspendLayout()
        pnlBotones.SuspendLayout()
        pnlSalirfrm.SuspendLayout()
        pnlBars.SuspendLayout()
        pnlMenu.SuspendLayout()
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
        tlySuperior.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 420.0F))
        tlySuperior.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 330.0F))
        tlySuperior.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 330.0F))
        tlySuperior.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 170.0F))
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
        tlySuperior.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        tlySuperior.Size = New Size(1370, 64)
        tlySuperior.TabIndex = 1
        ' 
        ' pnlBotones
        ' 
        pnlBotones.Controls.Add(btnSalir)
        pnlBotones.Controls.Add(btnMaximizar)
        pnlBotones.Controls.Add(btnMinimizar)
        pnlBotones.Dock = DockStyle.Fill
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
        lblLocalidad.Dock = DockStyle.Fill
        lblLocalidad.Font = New Font("Microsoft Sans Serif", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
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
        lblEmpleado.Dock = DockStyle.Fill
        lblEmpleado.Font = New Font("Microsoft Sans Serif", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
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
        lblTitulo.Dock = DockStyle.Fill
        lblTitulo.Font = New Font("Microsoft Sans Serif", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
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
        btnMostrarMenu.UseVisualStyleBackColor = False
        ' 
        ' pnlMenu
        ' 
        pnlMenu.BackColor = Color.FromArgb(CByte(51), CByte(51), CByte(76))
        pnlMenu.Controls.Add(btnAjustes)
        pnlMenu.Controls.Add(btnAnalisis)
        pnlMenu.Controls.Add(btnReporte)
        pnlMenu.Controls.Add(btnNomina)
        pnlMenu.Controls.Add(btnComision)
        pnlMenu.Controls.Add(btnEmpleado)
        pnlMenu.Controls.Add(btnProveedor)
        pnlMenu.Controls.Add(btnCompra)
        pnlMenu.Controls.Add(btnVenta)
        pnlMenu.Controls.Add(btnInventario)
        pnlMenu.Dock = DockStyle.Left
        pnlMenu.Font = New Font("Microsoft Sans Serif", 6F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        pnlMenu.Location = New Point(0, 64)
        pnlMenu.Name = "pnlMenu"
        pnlMenu.Size = New Size(55, 562)
        pnlMenu.TabIndex = 1
        ' 
        ' btnAjustes
        ' 
        btnAjustes.Dock = DockStyle.Top
        btnAjustes.FlatAppearance.BorderSize = 0
        btnAjustes.FlatStyle = FlatStyle.Flat
        btnAjustes.Font = New Font("Microsoft Sans Serif", 6F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnAjustes.ForeColor = Color.WhiteSmoke
        btnAjustes.IconChar = FontAwesome.Sharp.IconChar.Cog
        btnAjustes.IconColor = Color.WhiteSmoke
        btnAjustes.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnAjustes.IconSize = 33
        btnAjustes.Location = New Point(0, 495)
        btnAjustes.Name = "btnAjustes"
        btnAjustes.Size = New Size(55, 55)
        btnAjustes.TabIndex = 9
        btnAjustes.Text = "Ajustes"
        btnAjustes.TextImageRelation = TextImageRelation.ImageAboveText
        btnAjustes.UseVisualStyleBackColor = True
        ' 
        ' btnAnalisis
        ' 
        btnAnalisis.Dock = DockStyle.Top
        btnAnalisis.FlatAppearance.BorderSize = 0
        btnAnalisis.FlatStyle = FlatStyle.Flat
        btnAnalisis.Font = New Font("Microsoft Sans Serif", 6F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnAnalisis.ForeColor = Color.WhiteSmoke
        btnAnalisis.IconChar = FontAwesome.Sharp.IconChar.ListAlt
        btnAnalisis.IconColor = Color.WhiteSmoke
        btnAnalisis.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnAnalisis.IconSize = 33
        btnAnalisis.Location = New Point(0, 440)
        btnAnalisis.Name = "btnAnalisis"
        btnAnalisis.Size = New Size(55, 55)
        btnAnalisis.TabIndex = 8
        btnAnalisis.Text = "Analisis"
        btnAnalisis.TextImageRelation = TextImageRelation.ImageAboveText
        btnAnalisis.UseVisualStyleBackColor = True
        ' 
        ' btnReporte
        ' 
        btnReporte.Dock = DockStyle.Top
        btnReporte.FlatAppearance.BorderSize = 0
        btnReporte.FlatStyle = FlatStyle.Flat
        btnReporte.Font = New Font("Microsoft Sans Serif", 6F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnReporte.ForeColor = Color.WhiteSmoke
        btnReporte.IconChar = FontAwesome.Sharp.IconChar.Newspaper
        btnReporte.IconColor = Color.WhiteSmoke
        btnReporte.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnReporte.IconSize = 33
        btnReporte.Location = New Point(0, 385)
        btnReporte.Name = "btnReporte"
        btnReporte.Size = New Size(55, 55)
        btnReporte.TabIndex = 7
        btnReporte.Text = "Reporte"
        btnReporte.TextImageRelation = TextImageRelation.ImageAboveText
        btnReporte.UseVisualStyleBackColor = True
        ' 
        ' btnNomina
        ' 
        btnNomina.Dock = DockStyle.Top
        btnNomina.FlatAppearance.BorderSize = 0
        btnNomina.FlatStyle = FlatStyle.Flat
        btnNomina.Font = New Font("Microsoft Sans Serif", 6F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnNomina.ForeColor = Color.WhiteSmoke
        btnNomina.IconChar = FontAwesome.Sharp.IconChar.ContactBook
        btnNomina.IconColor = Color.WhiteSmoke
        btnNomina.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnNomina.IconSize = 33
        btnNomina.Location = New Point(0, 330)
        btnNomina.Name = "btnNomina"
        btnNomina.Size = New Size(55, 55)
        btnNomina.TabIndex = 6
        btnNomina.Text = "Nomina"
        btnNomina.TextImageRelation = TextImageRelation.ImageAboveText
        btnNomina.UseVisualStyleBackColor = True
        ' 
        ' btnComision
        ' 
        btnComision.Dock = DockStyle.Top
        btnComision.FlatAppearance.BorderSize = 0
        btnComision.FlatStyle = FlatStyle.Flat
        btnComision.Font = New Font("Microsoft Sans Serif", 6F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnComision.ForeColor = Color.WhiteSmoke
        btnComision.IconChar = FontAwesome.Sharp.IconChar.MoneyCheck
        btnComision.IconColor = Color.WhiteSmoke
        btnComision.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnComision.IconSize = 33
        btnComision.Location = New Point(0, 275)
        btnComision.Name = "btnComision"
        btnComision.Size = New Size(55, 55)
        btnComision.TabIndex = 5
        btnComision.Text = "Comisión"
        btnComision.TextImageRelation = TextImageRelation.ImageAboveText
        btnComision.UseVisualStyleBackColor = True
        ' 
        ' btnEmpleado
        ' 
        btnEmpleado.Dock = DockStyle.Top
        btnEmpleado.FlatAppearance.BorderSize = 0
        btnEmpleado.FlatStyle = FlatStyle.Flat
        btnEmpleado.Font = New Font("Microsoft Sans Serif", 6F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnEmpleado.ForeColor = Color.WhiteSmoke
        btnEmpleado.IconChar = FontAwesome.Sharp.IconChar.Users
        btnEmpleado.IconColor = Color.WhiteSmoke
        btnEmpleado.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnEmpleado.IconSize = 33
        btnEmpleado.Location = New Point(0, 220)
        btnEmpleado.Name = "btnEmpleado"
        btnEmpleado.Size = New Size(55, 55)
        btnEmpleado.TabIndex = 4
        btnEmpleado.Text = "Empleado"
        btnEmpleado.TextImageRelation = TextImageRelation.ImageAboveText
        btnEmpleado.UseVisualStyleBackColor = True
        ' 
        ' btnProveedor
        ' 
        btnProveedor.Dock = DockStyle.Top
        btnProveedor.FlatAppearance.BorderSize = 0
        btnProveedor.FlatStyle = FlatStyle.Flat
        btnProveedor.Font = New Font("Microsoft Sans Serif", 6F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnProveedor.ForeColor = Color.WhiteSmoke
        btnProveedor.IconChar = FontAwesome.Sharp.IconChar.Handshake
        btnProveedor.IconColor = Color.WhiteSmoke
        btnProveedor.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnProveedor.IconSize = 33
        btnProveedor.Location = New Point(0, 165)
        btnProveedor.Name = "btnProveedor"
        btnProveedor.Size = New Size(55, 55)
        btnProveedor.TabIndex = 3
        btnProveedor.Text = "Proveedor"
        btnProveedor.TextImageRelation = TextImageRelation.ImageAboveText
        btnProveedor.UseVisualStyleBackColor = True
        ' 
        ' btnCompra
        ' 
        btnCompra.Dock = DockStyle.Top
        btnCompra.FlatAppearance.BorderSize = 0
        btnCompra.FlatStyle = FlatStyle.Flat
        btnCompra.Font = New Font("Microsoft Sans Serif", 6F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnCompra.ForeColor = Color.WhiteSmoke
        btnCompra.IconChar = FontAwesome.Sharp.IconChar.ShoppingBag
        btnCompra.IconColor = Color.WhiteSmoke
        btnCompra.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnCompra.IconSize = 33
        btnCompra.Location = New Point(0, 110)
        btnCompra.Name = "btnCompra"
        btnCompra.Size = New Size(55, 55)
        btnCompra.TabIndex = 2
        btnCompra.Text = "Compra"
        btnCompra.TextImageRelation = TextImageRelation.ImageAboveText
        btnCompra.UseVisualStyleBackColor = True
        ' 
        ' btnVenta
        ' 
        btnVenta.Dock = DockStyle.Top
        btnVenta.FlatAppearance.BorderSize = 0
        btnVenta.FlatStyle = FlatStyle.Flat
        btnVenta.Font = New Font("Microsoft Sans Serif", 6F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnVenta.ForeColor = Color.WhiteSmoke
        btnVenta.IconChar = FontAwesome.Sharp.IconChar.CartShopping
        btnVenta.IconColor = Color.WhiteSmoke
        btnVenta.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnVenta.IconSize = 33
        btnVenta.Location = New Point(0, 55)
        btnVenta.Name = "btnVenta"
        btnVenta.Size = New Size(55, 55)
        btnVenta.TabIndex = 1
        btnVenta.Text = "Venta"
        btnVenta.TextImageRelation = TextImageRelation.ImageAboveText
        btnVenta.UseVisualStyleBackColor = True
        ' 
        ' btnInventario
        ' 
        btnInventario.Dock = DockStyle.Top
        btnInventario.FlatAppearance.BorderSize = 0
        btnInventario.FlatStyle = FlatStyle.Flat
        btnInventario.Font = New Font("Microsoft Sans Serif", 6F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnInventario.ForeColor = Color.WhiteSmoke
        btnInventario.IconChar = FontAwesome.Sharp.IconChar.Truck
        btnInventario.IconColor = Color.WhiteSmoke
        btnInventario.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnInventario.IconSize = 33
        btnInventario.Location = New Point(0, 0)
        btnInventario.Name = "btnInventario"
        btnInventario.Size = New Size(55, 55)
        btnInventario.TabIndex = 0
        btnInventario.Text = "Inventario"
        btnInventario.TextImageRelation = TextImageRelation.ImageAboveText
        btnInventario.UseVisualStyleBackColor = True
        ' 
        ' pnlDrawer
        ' 
        pnlDrawer.BackColor = Color.White
        pnlDrawer.Dock = DockStyle.Left
        pnlDrawer.Location = New Point(55, 64)
        pnlDrawer.Name = "pnlDrawer"
        pnlDrawer.Size = New Size(0, 562)
        pnlDrawer.TabIndex = 2
        ' 
        ' pnlContenedor
        ' 
        pnlContenedor.BackColor = Color.White
        pnlContenedor.BackgroundImage = CType(resources.GetObject("pnlContenedor.BackgroundImage"), Image)
        pnlContenedor.BackgroundImageLayout = ImageLayout.Stretch
        pnlContenedor.Dock = DockStyle.Fill
        pnlContenedor.Location = New Point(55, 64)
        pnlContenedor.Name = "pnlContenedor"
        pnlContenedor.Size = New Size(1315, 562)
        pnlContenedor.TabIndex = 3
        ' 
        ' DrawerTimer
        ' 
        DrawerTimer.Interval = 10
        ' 
        ' frm_Principal
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1370, 626)
        Controls.Add(pnlContenedor)
        Controls.Add(pnlDrawer)
        Controls.Add(pnlMenu)
        Controls.Add(pnlEncabezado)
        Name = "frm_Principal"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Principal"
        WindowState = FormWindowState.Maximized
        pnlEncabezado.ResumeLayout(False)
        tlySuperior.ResumeLayout(False)
        pnlBotones.ResumeLayout(False)
        pnlSalirfrm.ResumeLayout(False)
        pnlBars.ResumeLayout(False)
        pnlMenu.ResumeLayout(False)
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
    Friend WithEvents btnInventario As FontAwesome.Sharp.IconButton
    Friend WithEvents btnReporte As FontAwesome.Sharp.IconButton
    Friend WithEvents btnNomina As FontAwesome.Sharp.IconButton
    Friend WithEvents btnComision As FontAwesome.Sharp.IconButton
    Friend WithEvents btnEmpleado As FontAwesome.Sharp.IconButton
    Friend WithEvents btnProveedor As FontAwesome.Sharp.IconButton
    Friend WithEvents btnCompra As FontAwesome.Sharp.IconButton
    Friend WithEvents btnVenta As FontAwesome.Sharp.IconButton
    Friend WithEvents btnSalir As FontAwesome.Sharp.IconButton
    Friend WithEvents btnAjustes As FontAwesome.Sharp.IconButton
    Friend WithEvents btnAnalisis As FontAwesome.Sharp.IconButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents pnlRol As Panel
    Friend WithEvents tlySuperior As TableLayoutPanel
    Friend WithEvents lblLocalidad As HeaderUI
    Friend WithEvents lblEmpleado As HeaderUI
End Class
