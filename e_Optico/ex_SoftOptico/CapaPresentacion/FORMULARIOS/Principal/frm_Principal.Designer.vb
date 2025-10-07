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
        pnlEncabezado = New Panel()
        btnSalirFrmHijo = New FontAwesome.Sharp.IconButton()
        pnlBotones = New Panel()
        btnSalir = New FontAwesome.Sharp.IconButton()
        btnMaximizar = New FontAwesome.Sharp.IconButton()
        btnMinimizar = New FontAwesome.Sharp.IconButton()
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
        pnlBotones.SuspendLayout()
        pnlMenu.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlEncabezado
        ' 
        pnlEncabezado.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        pnlEncabezado.Controls.Add(btnSalirFrmHijo)
        pnlEncabezado.Controls.Add(pnlBotones)
        pnlEncabezado.Controls.Add(btnMostrarMenu)
        pnlEncabezado.Dock = DockStyle.Top
        pnlEncabezado.Location = New Point(0, 0)
        pnlEncabezado.Name = "pnlEncabezado"
        pnlEncabezado.Size = New Size(1370, 50)
        pnlEncabezado.TabIndex = 0
        ' 
        ' btnSalirFrmHijo
        ' 
        btnSalirFrmHijo.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        btnSalirFrmHijo.Dock = DockStyle.Left
        btnSalirFrmHijo.FlatAppearance.BorderSize = 0
        btnSalirFrmHijo.FlatStyle = FlatStyle.Flat
        btnSalirFrmHijo.IconChar = FontAwesome.Sharp.IconChar.Reply
        btnSalirFrmHijo.IconColor = Color.White
        btnSalirFrmHijo.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnSalirFrmHijo.IconSize = 25
        btnSalirFrmHijo.Location = New Point(55, 0)
        btnSalirFrmHijo.Name = "btnSalirFrmHijo"
        btnSalirFrmHijo.Size = New Size(74, 50)
        btnSalirFrmHijo.TabIndex = 8
        btnSalirFrmHijo.Tag = "btnSalirHijo"
        btnSalirFrmHijo.UseVisualStyleBackColor = False
        ' 
        ' pnlBotones
        ' 
        pnlBotones.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        pnlBotones.Controls.Add(btnSalir)
        pnlBotones.Controls.Add(btnMaximizar)
        pnlBotones.Controls.Add(btnMinimizar)
        pnlBotones.Location = New Point(1238, 0)
        pnlBotones.Name = "pnlBotones"
        pnlBotones.Size = New Size(132, 58)
        pnlBotones.TabIndex = 6
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
        ' btnMostrarMenu
        ' 
        btnMostrarMenu.Dock = DockStyle.Left
        btnMostrarMenu.FlatAppearance.BorderSize = 0
        btnMostrarMenu.FlatStyle = FlatStyle.Flat
        btnMostrarMenu.IconChar = FontAwesome.Sharp.IconChar.Bars
        btnMostrarMenu.IconColor = Color.White
        btnMostrarMenu.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnMostrarMenu.IconSize = 25
        btnMostrarMenu.Location = New Point(0, 0)
        btnMostrarMenu.Name = "btnMostrarMenu"
        btnMostrarMenu.Size = New Size(55, 50)
        btnMostrarMenu.TabIndex = 7
        btnMostrarMenu.Tag = "BotonMenu"
        ' 
        ' pnlMenu
        ' 
        pnlMenu.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
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
        pnlMenu.Location = New Point(0, 50)
        pnlMenu.Name = "pnlMenu"
        pnlMenu.Size = New Size(55, 576)
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
        btnAjustes.Tag = "Ajuste"
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
        btnAnalisis.Tag = "Analisis"
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
        btnReporte.Tag = "Reporte"
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
        btnNomina.Tag = "Nomina"
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
        btnComision.Tag = "Comision"
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
        btnEmpleado.Tag = "Empleado"
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
        btnProveedor.Tag = "Proveedor"
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
        btnCompra.Tag = "Compra"
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
        btnVenta.Tag = "Venta"
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
        btnInventario.Tag = "Inventario"
        btnInventario.Text = "Inventario"
        btnInventario.TextImageRelation = TextImageRelation.ImageAboveText
        btnInventario.UseVisualStyleBackColor = True
        ' 
        ' pnlDrawer
        ' 
        pnlDrawer.BackColor = Color.White
        pnlDrawer.Dock = DockStyle.Left
        pnlDrawer.Location = New Point(55, 50)
        pnlDrawer.Name = "pnlDrawer"
        pnlDrawer.Size = New Size(0, 576)
        pnlDrawer.TabIndex = 2
        ' 
        ' pnlContenedor
        ' 
        pnlContenedor.BackColor = Color.White
        pnlContenedor.BackgroundImageLayout = ImageLayout.Stretch
        pnlContenedor.Dock = DockStyle.Fill
        pnlContenedor.Location = New Point(55, 50)
        pnlContenedor.Name = "pnlContenedor"
        pnlContenedor.Size = New Size(1315, 576)
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
        pnlBotones.ResumeLayout(False)
        pnlMenu.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents pnlBars As Panel
    Friend WithEvents btnMostrarMenu As FontAwesome.Sharp.IconButton
    Friend WithEvents pnlBotones As Panel
    Friend WithEvents btnSalir As FontAwesome.Sharp.IconButton
    Friend WithEvents btnMaximizar As FontAwesome.Sharp.IconButton
    Friend WithEvents btnMinimizar As FontAwesome.Sharp.IconButton
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
    Friend WithEvents btnAjustes As FontAwesome.Sharp.IconButton
    Friend WithEvents btnAnalisis As FontAwesome.Sharp.IconButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents pnlRol As Panel
    Friend WithEvents btnSalirFrmHijo As FontAwesome.Sharp.IconButton
End Class
