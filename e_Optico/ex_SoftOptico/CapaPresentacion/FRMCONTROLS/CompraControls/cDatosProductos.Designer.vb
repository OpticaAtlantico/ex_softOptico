<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cDatosProductos
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        tlpFooter = New TableLayoutPanel()
        Panel5 = New Panel()
        CommandButtonui3 = New CommandButtonUI()
        btnSiguiente = New CommandButtonUI()
        CommandButtonui2 = New CommandButtonUI()
        Panel4 = New Panel()
        btnAnterior = New CommandButtonUI()
        CommandButtonui1 = New CommandButtonUI()
        Panel1 = New Panel()
        PanelTituloui1 = New PanelTituloUI()
        PanelTituloui2 = New PanelTituloUI()
        Panel2 = New Panel()
        Label1 = New Label()
        Panel3 = New Panel()
        Panel9 = New Panel()
        IconButton4 = New FontAwesome.Sharp.IconButton()
        Panel8 = New Panel()
        IconButton3 = New FontAwesome.Sharp.IconButton()
        Panel7 = New Panel()
        IconButton2 = New FontAwesome.Sharp.IconButton()
        Panel6 = New Panel()
        IconButton1 = New FontAwesome.Sharp.IconButton()
        Label2 = New Label()
        tlpFooter.SuspendLayout()
        Panel5.SuspendLayout()
        Panel4.SuspendLayout()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        Panel9.SuspendLayout()
        Panel8.SuspendLayout()
        Panel7.SuspendLayout()
        Panel6.SuspendLayout()
        SuspendLayout()
        ' 
        ' tlpFooter
        ' 
        tlpFooter.BackColor = Color.LightSkyBlue
        tlpFooter.ColumnCount = 2
        tlpFooter.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpFooter.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpFooter.Controls.Add(Panel5, 1, 0)
        tlpFooter.Controls.Add(Panel4, 0, 0)
        tlpFooter.Dock = DockStyle.Bottom
        tlpFooter.Location = New Point(0, 498)
        tlpFooter.Name = "tlpFooter"
        tlpFooter.RowCount = 1
        tlpFooter.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        tlpFooter.Size = New Size(1180, 66)
        tlpFooter.TabIndex = 6
        ' 
        ' Panel5
        ' 
        Panel5.Controls.Add(CommandButtonui3)
        Panel5.Controls.Add(btnSiguiente)
        Panel5.Controls.Add(CommandButtonui2)
        Panel5.Dock = DockStyle.Fill
        Panel5.Location = New Point(593, 3)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(584, 60)
        Panel5.TabIndex = 15
        ' 
        ' CommandButtonui3
        ' 
        CommandButtonui3.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        CommandButtonui3.AnimarHover = True
        CommandButtonui3.BackColor = Color.Transparent
        CommandButtonui3.ColorBase = Color.FromArgb(CByte(33), CByte(150), CByte(243))
        CommandButtonui3.ColorHover = Color.FromArgb(CByte(30), CByte(136), CByte(229))
        CommandButtonui3.ColorInternoFondo = Color.FromArgb(CByte(33), CByte(150), CByte(243))
        CommandButtonui3.ColorPresionado = Color.FromArgb(CByte(25), CByte(118), CByte(210))
        CommandButtonui3.ColorTexto = Color.WhiteSmoke
        CommandButtonui3.EstiloBoton = CommandButtonUI.EstiloBootstrap.Primary
        CommandButtonui3.Font = New Font("Century Gothic", 10F, FontStyle.Bold)
        CommandButtonui3.Icono = FontAwesome.Sharp.IconChar.CircleRight
        CommandButtonui3.Location = New Point(751, 8)
        CommandButtonui3.Name = "CommandButtonui3"
        CommandButtonui3.RadioBorde = 8
        CommandButtonui3.Size = New Size(200, 44)
        CommandButtonui3.TabIndex = 3
        CommandButtonui3.Text = "CommandButtonui1"
        CommandButtonui3.Texto = "Siguiente..."
        ' 
        ' btnSiguiente
        ' 
        btnSiguiente.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnSiguiente.AnimarHover = True
        btnSiguiente.BackColor = Color.Transparent
        btnSiguiente.ColorBase = Color.FromArgb(CByte(33), CByte(150), CByte(243))
        btnSiguiente.ColorHover = Color.FromArgb(CByte(30), CByte(136), CByte(229))
        btnSiguiente.ColorInternoFondo = Color.FromArgb(CByte(33), CByte(150), CByte(243))
        btnSiguiente.ColorPresionado = Color.FromArgb(CByte(25), CByte(118), CByte(210))
        btnSiguiente.ColorTexto = Color.WhiteSmoke
        btnSiguiente.EstiloBoton = CommandButtonUI.EstiloBootstrap.Primary
        btnSiguiente.Font = New Font("Century Gothic", 10F, FontStyle.Bold)
        btnSiguiente.Icono = FontAwesome.Sharp.IconChar.CircleRight
        btnSiguiente.Location = New Point(1092, 8)
        btnSiguiente.Name = "btnSiguiente"
        btnSiguiente.RadioBorde = 8
        btnSiguiente.Size = New Size(200, 44)
        btnSiguiente.TabIndex = 2
        btnSiguiente.Text = "CommandButtonui1"
        btnSiguiente.Texto = "Siguiente..."
        ' 
        ' CommandButtonui2
        ' 
        CommandButtonui2.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        CommandButtonui2.AnimarHover = True
        CommandButtonui2.BackColor = Color.Transparent
        CommandButtonui2.ColorBase = Color.FromArgb(CByte(33), CByte(150), CByte(243))
        CommandButtonui2.ColorHover = Color.FromArgb(CByte(30), CByte(136), CByte(229))
        CommandButtonui2.ColorInternoFondo = Color.FromArgb(CByte(33), CByte(150), CByte(243))
        CommandButtonui2.ColorPresionado = Color.FromArgb(CByte(25), CByte(118), CByte(210))
        CommandButtonui2.ColorTexto = Color.WhiteSmoke
        CommandButtonui2.EstiloBoton = CommandButtonUI.EstiloBootstrap.Primary
        CommandButtonui2.Font = New Font("Century Gothic", 10F, FontStyle.Bold)
        CommandButtonui2.Icono = FontAwesome.Sharp.IconChar.CircleRight
        CommandButtonui2.Location = New Point(1438, 8)
        CommandButtonui2.Name = "CommandButtonui2"
        CommandButtonui2.RadioBorde = 8
        CommandButtonui2.Size = New Size(200, 44)
        CommandButtonui2.TabIndex = 1
        CommandButtonui2.Text = "CommandButtonui1"
        CommandButtonui2.Texto = "Siguiente..."
        ' 
        ' Panel4
        ' 
        Panel4.Controls.Add(btnAnterior)
        Panel4.Controls.Add(CommandButtonui1)
        Panel4.Dock = DockStyle.Fill
        Panel4.Location = New Point(3, 3)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(584, 60)
        Panel4.TabIndex = 14
        ' 
        ' btnAnterior
        ' 
        btnAnterior.AnimarHover = True
        btnAnterior.BackColor = Color.Transparent
        btnAnterior.ColorBase = Color.FromArgb(CByte(33), CByte(150), CByte(243))
        btnAnterior.ColorHover = Color.FromArgb(CByte(30), CByte(136), CByte(229))
        btnAnterior.ColorInternoFondo = Color.FromArgb(CByte(33), CByte(150), CByte(243))
        btnAnterior.ColorPresionado = Color.FromArgb(CByte(25), CByte(118), CByte(210))
        btnAnterior.ColorTexto = Color.WhiteSmoke
        btnAnterior.EstiloBoton = CommandButtonUI.EstiloBootstrap.Primary
        btnAnterior.Font = New Font("Century Gothic", 10F, FontStyle.Bold)
        btnAnterior.Icono = FontAwesome.Sharp.IconChar.ArrowAltCircleLeft
        btnAnterior.Location = New Point(8, 8)
        btnAnterior.Name = "btnAnterior"
        btnAnterior.RadioBorde = 8
        btnAnterior.Size = New Size(200, 44)
        btnAnterior.TabIndex = 3
        btnAnterior.Text = "CommandButtonui1"
        btnAnterior.Texto = "Anterior..."
        ' 
        ' CommandButtonui1
        ' 
        CommandButtonui1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        CommandButtonui1.AnimarHover = True
        CommandButtonui1.BackColor = Color.Transparent
        CommandButtonui1.ColorBase = Color.FromArgb(CByte(33), CByte(150), CByte(243))
        CommandButtonui1.ColorHover = Color.FromArgb(CByte(30), CByte(136), CByte(229))
        CommandButtonui1.ColorInternoFondo = Color.FromArgb(CByte(33), CByte(150), CByte(243))
        CommandButtonui1.ColorPresionado = Color.FromArgb(CByte(25), CByte(118), CByte(210))
        CommandButtonui1.ColorTexto = Color.WhiteSmoke
        CommandButtonui1.EstiloBoton = CommandButtonUI.EstiloBootstrap.Primary
        CommandButtonui1.Font = New Font("Century Gothic", 10F, FontStyle.Bold)
        CommandButtonui1.Icono = FontAwesome.Sharp.IconChar.CircleRight
        CommandButtonui1.Location = New Point(1437, 8)
        CommandButtonui1.Name = "CommandButtonui1"
        CommandButtonui1.RadioBorde = 8
        CommandButtonui1.Size = New Size(200, 44)
        CommandButtonui1.TabIndex = 1
        CommandButtonui1.Text = "CommandButtonui1"
        CommandButtonui1.Texto = "Siguiente..."
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.White
        Panel1.Location = New Point(9, 58)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(878, 422)
        Panel1.TabIndex = 7
        ' 
        ' PanelTituloui1
        ' 
        PanelTituloui1.BackColor = Color.Transparent
        PanelTituloui1.BackColorContenedor = Color.White
        PanelTituloui1.BackColorTitulo = Color.FromArgb(CByte(33), CByte(150), CByte(243))
        PanelTituloui1.BorderColor = Color.LightGray
        PanelTituloui1.BorderColorTitulo = Color.White
        PanelTituloui1.BorderRadius = 20
        PanelTituloui1.BorderSize = 1
        PanelTituloui1.CardBackColor = Color.White
        PanelTituloui1.Estilo = PanelTituloUI.EstiloCard.None
        PanelTituloui1.Location = New Point(906, 3)
        PanelTituloui1.Name = "PanelTituloui1"
        PanelTituloui1.ShadowColor = Color.LightGray
        PanelTituloui1.Size = New Size(266, 492)
        PanelTituloui1.TabIndex = 8
        PanelTituloui1.Texto = ""
        ' 
        ' PanelTituloui2
        ' 
        PanelTituloui2.BackColor = Color.Transparent
        PanelTituloui2.BackColorContenedor = Color.White
        PanelTituloui2.BackColorTitulo = Color.FromArgb(CByte(33), CByte(150), CByte(243))
        PanelTituloui2.BorderColor = Color.LightGray
        PanelTituloui2.BorderColorTitulo = Color.White
        PanelTituloui2.BorderRadius = 20
        PanelTituloui2.BorderSize = 1
        PanelTituloui2.CardBackColor = Color.White
        PanelTituloui2.Estilo = PanelTituloUI.EstiloCard.None
        PanelTituloui2.Location = New Point(3, 3)
        PanelTituloui2.Name = "PanelTituloui2"
        PanelTituloui2.ShadowColor = Color.LightGray
        PanelTituloui2.Size = New Size(897, 492)
        PanelTituloui2.TabIndex = 9
        PanelTituloui2.Texto = ""
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.FromArgb(CByte(0), CByte(40), CByte(74))
        Panel2.Controls.Add(Label1)
        Panel2.Location = New Point(913, 10)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(249, 36)
        Panel2.TabIndex = 10
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        Label1.Font = New Font("Segoe UI", 14F, FontStyle.Bold Or FontStyle.Italic)
        Label1.ForeColor = Color.White
        Label1.Location = New Point(14, 7)
        Label1.Name = "Label1"
        Label1.Size = New Size(222, 20)
        Label1.TabIndex = 0
        Label1.Text = "Totales."
        Label1.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.FromArgb(CByte(0), CByte(40), CByte(74))
        Panel3.Controls.Add(Panel9)
        Panel3.Controls.Add(Panel8)
        Panel3.Controls.Add(Panel7)
        Panel3.Controls.Add(Panel6)
        Panel3.Controls.Add(Label2)
        Panel3.Location = New Point(11, 10)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(876, 36)
        Panel3.TabIndex = 11
        ' 
        ' Panel9
        ' 
        Panel9.Controls.Add(IconButton4)
        Panel9.Location = New Point(122, 3)
        Panel9.Name = "Panel9"
        Panel9.Size = New Size(30, 30)
        Panel9.TabIndex = 1
        ' 
        ' IconButton4
        ' 
        IconButton4.Cursor = Cursors.Hand
        IconButton4.Dock = DockStyle.Fill
        IconButton4.FlatAppearance.BorderSize = 0
        IconButton4.FlatAppearance.MouseDownBackColor = Color.Silver
        IconButton4.FlatAppearance.MouseOverBackColor = Color.Lavender
        IconButton4.FlatStyle = FlatStyle.Flat
        IconButton4.IconChar = FontAwesome.Sharp.IconChar.NodeJs
        IconButton4.IconColor = Color.White
        IconButton4.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconButton4.IconSize = 28
        IconButton4.Location = New Point(0, 0)
        IconButton4.Name = "IconButton4"
        IconButton4.Size = New Size(30, 30)
        IconButton4.TabIndex = 1
        IconButton4.TextImageRelation = TextImageRelation.ImageAboveText
        IconButton4.UseVisualStyleBackColor = True
        ' 
        ' Panel8
        ' 
        Panel8.Controls.Add(IconButton3)
        Panel8.Location = New Point(86, 3)
        Panel8.Name = "Panel8"
        Panel8.Size = New Size(30, 30)
        Panel8.TabIndex = 1
        ' 
        ' IconButton3
        ' 
        IconButton3.Cursor = Cursors.Hand
        IconButton3.Dock = DockStyle.Fill
        IconButton3.FlatAppearance.BorderSize = 0
        IconButton3.FlatAppearance.MouseDownBackColor = Color.Silver
        IconButton3.FlatAppearance.MouseOverBackColor = Color.Lavender
        IconButton3.FlatStyle = FlatStyle.Flat
        IconButton3.IconChar = FontAwesome.Sharp.IconChar.NodeJs
        IconButton3.IconColor = Color.White
        IconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconButton3.IconSize = 28
        IconButton3.Location = New Point(0, 0)
        IconButton3.Name = "IconButton3"
        IconButton3.Size = New Size(30, 30)
        IconButton3.TabIndex = 1
        IconButton3.TextImageRelation = TextImageRelation.ImageAboveText
        IconButton3.UseVisualStyleBackColor = True
        ' 
        ' Panel7
        ' 
        Panel7.Controls.Add(IconButton2)
        Panel7.Location = New Point(50, 3)
        Panel7.Name = "Panel7"
        Panel7.Size = New Size(30, 30)
        Panel7.TabIndex = 1
        ' 
        ' IconButton2
        ' 
        IconButton2.Cursor = Cursors.Hand
        IconButton2.Dock = DockStyle.Fill
        IconButton2.FlatAppearance.BorderSize = 0
        IconButton2.FlatAppearance.MouseDownBackColor = Color.Silver
        IconButton2.FlatAppearance.MouseOverBackColor = Color.Lavender
        IconButton2.FlatStyle = FlatStyle.Flat
        IconButton2.IconChar = FontAwesome.Sharp.IconChar.NodeJs
        IconButton2.IconColor = Color.White
        IconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconButton2.IconSize = 28
        IconButton2.Location = New Point(0, 0)
        IconButton2.Name = "IconButton2"
        IconButton2.Size = New Size(30, 30)
        IconButton2.TabIndex = 1
        IconButton2.TextImageRelation = TextImageRelation.ImageAboveText
        IconButton2.UseVisualStyleBackColor = True
        ' 
        ' Panel6
        ' 
        Panel6.Controls.Add(IconButton1)
        Panel6.Location = New Point(14, 3)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(30, 30)
        Panel6.TabIndex = 1
        ' 
        ' IconButton1
        ' 
        IconButton1.Cursor = Cursors.Hand
        IconButton1.Dock = DockStyle.Fill
        IconButton1.FlatAppearance.BorderSize = 0
        IconButton1.FlatAppearance.MouseDownBackColor = Color.Silver
        IconButton1.FlatAppearance.MouseOverBackColor = Color.Lavender
        IconButton1.FlatStyle = FlatStyle.Flat
        IconButton1.IconChar = FontAwesome.Sharp.IconChar.NodeJs
        IconButton1.IconColor = Color.White
        IconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconButton1.IconSize = 28
        IconButton1.Location = New Point(0, 0)
        IconButton1.Name = "IconButton1"
        IconButton1.Size = New Size(30, 30)
        IconButton1.TabIndex = 0
        IconButton1.TextImageRelation = TextImageRelation.ImageAboveText
        IconButton1.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        Label2.Font = New Font("Segoe UI", 14F, FontStyle.Bold Or FontStyle.Italic)
        Label2.ForeColor = Color.White
        Label2.Location = New Point(14, 7)
        Label2.Name = "Label2"
        Label2.Size = New Size(222, 0)
        Label2.TabIndex = 0
        Label2.Text = "Totales."
        Label2.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' cDatosProductos
        ' 
        AutoScaleMode = AutoScaleMode.None
        BackColor = Color.WhiteSmoke
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Controls.Add(PanelTituloui2)
        Controls.Add(PanelTituloui1)
        Controls.Add(tlpFooter)
        Name = "cDatosProductos"
        Size = New Size(1180, 564)
        tlpFooter.ResumeLayout(False)
        Panel5.ResumeLayout(False)
        Panel4.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        Panel9.ResumeLayout(False)
        Panel8.ResumeLayout(False)
        Panel7.ResumeLayout(False)
        Panel6.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents tlpFooter As TableLayoutPanel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents CommandButtonui3 As CommandButtonUI
    Friend WithEvents btnSiguiente As CommandButtonUI
    Friend WithEvents CommandButtonui2 As CommandButtonUI
    Friend WithEvents Panel4 As Panel
    Friend WithEvents CommandButtonui1 As CommandButtonUI
    Friend WithEvents btnAnterior As CommandButtonUI
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PanelTituloui1 As PanelTituloUI
    Friend WithEvents PanelTituloui2 As PanelTituloUI
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents IconButton1 As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton4 As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton3 As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton2 As FontAwesome.Sharp.IconButton

End Class
