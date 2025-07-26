Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports FontAwesome.Sharp

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Visual
    Inherits Form

    Private panelTop As Panel
    Private btnHamburger As FontAwesome.Sharp.IconButton

    ' Panel lateral de 80px y sus botones de grupo
    Private panelSide As Panel
    Private btnVentas As FontAwesome.Sharp.IconButton
    Private btnCompras As FontAwesome.Sharp.IconButton

    ' Drawer colapsado a la izquierda
    Private panelDrawer As Panel

    ' Panel de contenido principal
    Private panelContent As Panel

    Private Sub InitializeComponent()
        panelTop = New Panel()
        btnHamburger = New IconButton()
        panelSide = New Panel()
        btnCompras = New IconButton()
        btnVentas = New IconButton()
        panelDrawer = New Panel()
        panelContent = New Panel()
        panelTop.SuspendLayout()
        panelSide.SuspendLayout()
        SuspendLayout()
        ' 
        ' panelTop
        ' 
        panelTop.BackColor = Color.FromArgb(CByte(30), CByte(30), CByte(30))
        panelTop.Controls.Add(btnHamburger)
        panelTop.Dock = DockStyle.Top
        panelTop.Location = New Point(0, 0)
        panelTop.Name = "panelTop"
        panelTop.Size = New Size(800, 50)
        panelTop.TabIndex = 3
        ' 
        ' btnHamburger
        ' 
        btnHamburger.Dock = DockStyle.Left
        btnHamburger.FlatAppearance.BorderSize = 0
        btnHamburger.FlatStyle = FlatStyle.Flat
        btnHamburger.IconChar = IconChar.Bars
        btnHamburger.IconColor = Color.White
        btnHamburger.IconFont = IconFont.Auto
        btnHamburger.IconSize = 28
        btnHamburger.Location = New Point(0, 0)
        btnHamburger.Name = "btnHamburger"
        btnHamburger.Size = New Size(50, 50)
        btnHamburger.TabIndex = 0
        ' 
        ' panelSide
        ' 
        panelSide.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(45))
        panelSide.Controls.Add(btnCompras)
        panelSide.Controls.Add(btnVentas)
        panelSide.Dock = DockStyle.Left
        panelSide.Location = New Point(0, 50)
        panelSide.Name = "panelSide"
        panelSide.Size = New Size(50, 400)
        panelSide.TabIndex = 2
        ' 
        ' btnCompras
        ' 
        btnCompras.Dock = DockStyle.Top
        btnCompras.FlatAppearance.BorderSize = 0
        btnCompras.FlatStyle = FlatStyle.Flat
        btnCompras.IconChar = IconChar.Truck
        btnCompras.IconColor = Color.White
        btnCompras.IconFont = IconFont.Auto
        btnCompras.IconSize = 32
        btnCompras.Location = New Point(0, 49)
        btnCompras.Name = "btnCompras"
        btnCompras.Size = New Size(50, 49)
        btnCompras.TabIndex = 0
        ' 
        ' btnVentas
        ' 
        btnVentas.Dock = DockStyle.Top
        btnVentas.FlatAppearance.BorderSize = 0
        btnVentas.FlatStyle = FlatStyle.Flat
        btnVentas.IconChar = IconChar.FileInvoiceDollar
        btnVentas.IconColor = Color.White
        btnVentas.IconFont = IconFont.Auto
        btnVentas.IconSize = 32
        btnVentas.Location = New Point(0, 0)
        btnVentas.Name = "btnVentas"
        btnVentas.Size = New Size(50, 49)
        btnVentas.TabIndex = 1
        ' 
        ' panelDrawer
        ' 
        panelDrawer.AutoSize = True
        panelDrawer.BackColor = Color.FromArgb(CByte(60), CByte(60), CByte(60))
        panelDrawer.Dock = DockStyle.Left
        panelDrawer.Location = New Point(50, 50)
        panelDrawer.Name = "panelDrawer"
        panelDrawer.Size = New Size(0, 400)
        panelDrawer.TabIndex = 1
        ' 
        ' panelContent
        ' 
        panelContent.BackColor = Color.FromArgb(CByte(240), CByte(240), CByte(240))
        panelContent.Dock = DockStyle.Fill
        panelContent.Location = New Point(50, 50)
        panelContent.Name = "panelContent"
        panelContent.Size = New Size(750, 400)
        panelContent.TabIndex = 0
        ' 
        ' frm_Visual
        ' 
        ClientSize = New Size(800, 450)
        Controls.Add(panelContent)
        Controls.Add(panelDrawer)
        Controls.Add(panelSide)
        Controls.Add(panelTop)
        Name = "frm_Visual"
        Text = "Mi App con Drawer"
        panelTop.ResumeLayout(False)
        panelSide.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub
End Class

