Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports FontAwesome.Sharp

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Visual
    Inherits Form
    Private Sub InitializeComponent()
        components = New Container()
        pnlEncabezado = New Panel()
        btnHamburguesa = New IconButton()
        pnlMenu = New Panel()
        pnlContenedor = New Panel()
        DrawerTimer = New Timer(components)
        pnlDrawer = New Panel()
        pnlEncabezado.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlEncabezado
        ' 
        pnlEncabezado.Controls.Add(btnHamburguesa)
        pnlEncabezado.Dock = DockStyle.Top
        pnlEncabezado.Location = New Point(0, 0)
        pnlEncabezado.Name = "pnlEncabezado"
        pnlEncabezado.Size = New Size(1213, 57)
        pnlEncabezado.TabIndex = 0
        ' 
        ' btnHamburguesa
        ' 
        btnHamburguesa.BackColor = Color.Transparent
        btnHamburguesa.FlatAppearance.BorderSize = 0
        btnHamburguesa.FlatStyle = FlatStyle.Flat
        btnHamburguesa.IconChar = IconChar.Bars
        btnHamburguesa.IconColor = Color.Black
        btnHamburguesa.IconFont = IconFont.Auto
        btnHamburguesa.IconSize = 40
        btnHamburguesa.Location = New Point(13, 12)
        btnHamburguesa.Name = "btnHamburguesa"
        btnHamburguesa.Size = New Size(35, 35)
        btnHamburguesa.TabIndex = 0
        btnHamburguesa.UseVisualStyleBackColor = False
        ' 
        ' pnlMenu
        ' 
        pnlMenu.BackColor = SystemColors.ControlDarkDark
        pnlMenu.Dock = DockStyle.Left
        pnlMenu.Location = New Point(0, 57)
        pnlMenu.Name = "pnlMenu"
        pnlMenu.Size = New Size(58, 440)
        pnlMenu.TabIndex = 0
        ' 
        ' pnlDrawer
        ' 
        pnlDrawer.BackColor = SystemColors.ActiveCaption
        pnlDrawer.Dock = DockStyle.Left
        pnlDrawer.Location = New Point(58, 57)
        pnlDrawer.Name = "pnlDrawer"
        pnlDrawer.Size = New Size(200, 440)
        pnlDrawer.TabIndex = 2
        pnlDrawer.Visible = False
        ' 
        ' pnlContenedor
        ' 
        pnlContenedor.BackColor = Color.WhiteSmoke
        pnlContenedor.Dock = DockStyle.Fill
        pnlContenedor.Location = New Point(58, 57)
        pnlContenedor.Name = "pnlContenedor"
        pnlContenedor.Size = New Size(1155, 440)
        pnlContenedor.TabIndex = 0
        ' 
        ' DrawerTimer
        ' 
        DrawerTimer.Interval = 15
        ' 
        ' frm_Visual
        ' 
        ClientSize = New Size(1213, 497)
        Controls.Add(pnlContenedor)
        Controls.Add(pnlDrawer)
        Controls.Add(pnlMenu)
        Controls.Add(pnlEncabezado)
        Name = "frm_Visual"
        pnlEncabezado.ResumeLayout(False)
        ResumeLayout(False)


    End Sub

    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents pnlMenu As Panel
    Friend WithEvents pnlContenedor As Panel
    Friend WithEvents btnHamburguesa As IconButton
    Friend WithEvents DrawerTimer As Timer
    Private components As IContainer
    Friend WithEvents pnlDrawer As Panel

    'Private panelTop As Panel
    'Private btnHamburger As FontAwesome.Sharp.IconButton

    '' Panel lateral de 80px y sus botones de grupo
    'Private panelSide As Panel
    'Private btnVentas As FontAwesome.Sharp.IconButton
    'Private btnCompras As FontAwesome.Sharp.IconButton

    '' Drawer colapsado a la izquierda
    'Private panelDrawer As Panel

    '' Panel de contenido principal
    'Private panelContent As Panel
    'Private Sub InitializeComponent()
    '    panelTop = New Panel()
    '    btnHamburger = New IconButton()
    '    panelSide = New Panel()
    '    btnCompras = New IconButton()
    '    btnVentas = New IconButton()
    '    panelDrawer = New Panel()
    '    panelTop.SuspendLayout()
    '    panelSide.SuspendLayout()
    '    SuspendLayout()
    '    ' 
    '    ' panelTop
    '    ' 
    '    panelTop.BackColor = Color.FromArgb(CByte(30), CByte(30), CByte(30))
    '    panelTop.Controls.Add(btnHamburger)
    '    panelTop.Dock = DockStyle.Top
    '    panelTop.Location = New Point(0, 0)
    '    panelTop.Name = "panelTop"
    '    panelTop.Size = New Size(800, 50)
    '    panelTop.TabIndex = 3
    '    ' 
    '    ' btnHamburger
    '    ' 
    '    btnHamburger.Dock = DockStyle.Left
    '    btnHamburger.FlatAppearance.BorderSize = 0
    '    btnHamburger.FlatStyle = FlatStyle.Flat
    '    btnHamburger.IconChar = IconChar.Bars
    '    btnHamburger.IconColor = Color.White
    '    btnHamburger.IconFont = IconFont.Auto
    '    btnHamburger.IconSize = 28
    '    btnHamburger.Location = New Point(0, 0)
    '    btnHamburger.Name = "btnHamburger"
    '    btnHamburger.Size = New Size(50, 50)
    '    btnHamburger.TabIndex = 0
    '    ' 
    '    ' panelSide
    '    ' 
    '    panelSide.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(45))
    '    panelSide.Controls.Add(btnCompras)
    '    panelSide.Controls.Add(btnVentas)
    '    panelSide.Location = New Point(0, 50)
    '    panelSide.Name = "panelSide"
    '    panelSide.Size = New Size(50, 400)
    '    panelSide.TabIndex = 2
    '    ' 
    '    ' btnCompras
    '    ' 
    '    btnCompras.Dock = DockStyle.Top
    '    btnCompras.FlatAppearance.BorderSize = 0
    '    btnCompras.FlatStyle = FlatStyle.Flat
    '    btnCompras.IconChar = IconChar.Truck
    '    btnCompras.IconColor = Color.White
    '    btnCompras.IconFont = IconFont.Auto
    '    btnCompras.IconSize = 32
    '    btnCompras.Location = New Point(0, 80)
    '    btnCompras.Name = "btnCompras"
    '    btnCompras.Size = New Size(50, 80)
    '    btnCompras.TabIndex = 0
    '    ' 
    '    ' btnVentas
    '    ' 
    '    btnVentas.Dock = DockStyle.Top
    '    btnVentas.FlatAppearance.BorderSize = 0
    '    btnVentas.FlatStyle = FlatStyle.Flat
    '    btnVentas.IconChar = IconChar.FileInvoiceDollar
    '    btnVentas.IconColor = Color.White
    '    btnVentas.IconFont = IconFont.Auto
    '    btnVentas.IconSize = 32
    '    btnVentas.Location = New Point(0, 0)
    '    btnVentas.Name = "btnVentas"
    '    btnVentas.Size = New Size(50, 80)
    '    btnVentas.TabIndex = 1
    '    ' 
    '    ' panelDrawer
    '    ' 
    '    panelDrawer.AutoScroll = True
    '    panelDrawer.BackColor = Color.Red
    '    panelDrawer.Dock = DockStyle.Right
    '    panelDrawer.Location = New Point(800, 50)
    '    panelDrawer.Name = "panelDrawer"
    '    panelDrawer.Size = New Size(0, 400)
    '    panelDrawer.TabIndex = 1
    '    ' 
    '    ' frm_Visual
    '    ' 
    '    ClientSize = New Size(800, 450)
    '    Controls.Add(panelDrawer)
    '    Controls.Add(panelTop)
    '    Controls.Add(panelSide)
    '    Name = "frm_Visual"
    '    Text = "Mi App con Drawer"
    '    panelTop.ResumeLayout(False)
    '    panelSide.ResumeLayout(False)
    '    ResumeLayout(False)
    'End Sub
End Class
