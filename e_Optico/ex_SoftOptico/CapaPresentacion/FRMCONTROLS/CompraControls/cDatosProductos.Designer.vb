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
        Panel4 = New Panel()
        btnAnterior = New CommandButtonUI()
        Panel1 = New Panel()
        PanelTituloui1 = New PanelTituloUI()
        PanelTituloui2 = New PanelTituloUI()
        Panel2 = New Panel()
        Label1 = New Label()
        Panel3 = New Panel()
        Panel9 = New Panel()
        btnOtros = New FontAwesome.Sharp.IconButton()
        Panel8 = New Panel()
        btnMiselaneos = New FontAwesome.Sharp.IconButton()
        Panel7 = New Panel()
        btnCristales = New FontAwesome.Sharp.IconButton()
        Panel6 = New Panel()
        btnMonturas = New FontAwesome.Sharp.IconButton()
        Panel10 = New Panel()
        TableLayoutPanel1 = New TableLayoutPanel()
        Label5 = New Label()
        lblTotalGeneral = New Label()
        Label3 = New Label()
        lblIva = New Label()
        Label4 = New Label()
        lblBaseImponible = New Label()
        lblTextoIva = New Label()
        lblExento = New Label()
        tlpFooter.SuspendLayout()
        Panel4.SuspendLayout()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        Panel9.SuspendLayout()
        Panel8.SuspendLayout()
        Panel7.SuspendLayout()
        Panel6.SuspendLayout()
        Panel10.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' tlpFooter
        ' 
        tlpFooter.BackColor = Color.LightSkyBlue
        tlpFooter.ColumnCount = 2
        tlpFooter.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0F))
        tlpFooter.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0F))
        tlpFooter.Controls.Add(Panel5, 1, 0)
        tlpFooter.Controls.Add(Panel4, 0, 0)
        tlpFooter.Dock = DockStyle.Bottom
        tlpFooter.Location = New Point(0, 491)
        tlpFooter.Name = "tlpFooter"
        tlpFooter.RowCount = 1
        tlpFooter.RowStyles.Add(New RowStyle(SizeType.Absolute, 20.0F))
        tlpFooter.Size = New Size(1190, 66)
        tlpFooter.TabIndex = 6
        ' 
        ' Panel5
        ' 
        Panel5.Dock = DockStyle.Fill
        Panel5.Location = New Point(598, 3)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(589, 60)
        Panel5.TabIndex = 15
        ' 
        ' Panel4
        ' 
        Panel4.Controls.Add(btnAnterior)
        Panel4.Dock = DockStyle.Fill
        Panel4.Location = New Point(3, 3)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(589, 60)
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
        btnAnterior.Font = New Font("Century Gothic", 10.0F, FontStyle.Bold)
        btnAnterior.Icono = FontAwesome.Sharp.IconChar.ArrowAltCircleLeft
        btnAnterior.Location = New Point(8, 8)
        btnAnterior.Name = "btnAnterior"
        btnAnterior.RadioBorde = 8
        btnAnterior.Size = New Size(200, 44)
        btnAnterior.TabIndex = 3
        btnAnterior.Text = "CommandButtonui1"
        btnAnterior.Texto = "Anterior..."
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.White
        Panel1.Location = New Point(9, 58)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(878, 414)
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
        PanelTituloui1.Size = New Size(266, 480)
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
        PanelTituloui2.Size = New Size(897, 480)
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
        Label1.Font = New Font("Segoe UI", 14.0F, FontStyle.Bold Or FontStyle.Italic)
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
        Panel3.Location = New Point(11, 10)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(876, 36)
        Panel3.TabIndex = 11
        ' 
        ' Panel9
        ' 
        Panel9.Controls.Add(btnOtros)
        Panel9.Location = New Point(122, 3)
        Panel9.Name = "Panel9"
        Panel9.Size = New Size(30, 30)
        Panel9.TabIndex = 1
        ' 
        ' btnOtros
        ' 
        btnOtros.Cursor = Cursors.Hand
        btnOtros.Dock = DockStyle.Fill
        btnOtros.FlatAppearance.BorderSize = 0
        btnOtros.FlatAppearance.MouseDownBackColor = Color.Silver
        btnOtros.FlatAppearance.MouseOverBackColor = Color.Lavender
        btnOtros.FlatStyle = FlatStyle.Flat
        btnOtros.IconChar = FontAwesome.Sharp.IconChar.NodeJs
        btnOtros.IconColor = Color.White
        btnOtros.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnOtros.IconSize = 28
        btnOtros.Location = New Point(0, 0)
        btnOtros.Name = "btnOtros"
        btnOtros.Size = New Size(30, 30)
        btnOtros.TabIndex = 1
        btnOtros.TextImageRelation = TextImageRelation.ImageAboveText
        btnOtros.UseVisualStyleBackColor = True
        ' 
        ' Panel8
        ' 
        Panel8.Controls.Add(btnMiselaneos)
        Panel8.Location = New Point(86, 3)
        Panel8.Name = "Panel8"
        Panel8.Size = New Size(30, 30)
        Panel8.TabIndex = 1
        ' 
        ' btnMiselaneos
        ' 
        btnMiselaneos.Cursor = Cursors.Hand
        btnMiselaneos.Dock = DockStyle.Fill
        btnMiselaneos.FlatAppearance.BorderSize = 0
        btnMiselaneos.FlatAppearance.MouseDownBackColor = Color.Silver
        btnMiselaneos.FlatAppearance.MouseOverBackColor = Color.Lavender
        btnMiselaneos.FlatStyle = FlatStyle.Flat
        btnMiselaneos.IconChar = FontAwesome.Sharp.IconChar.NodeJs
        btnMiselaneos.IconColor = Color.White
        btnMiselaneos.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnMiselaneos.IconSize = 28
        btnMiselaneos.Location = New Point(0, 0)
        btnMiselaneos.Name = "btnMiselaneos"
        btnMiselaneos.Size = New Size(30, 30)
        btnMiselaneos.TabIndex = 1
        btnMiselaneos.TextImageRelation = TextImageRelation.ImageAboveText
        btnMiselaneos.UseVisualStyleBackColor = True
        ' 
        ' Panel7
        ' 
        Panel7.Controls.Add(btnCristales)
        Panel7.Location = New Point(50, 3)
        Panel7.Name = "Panel7"
        Panel7.Size = New Size(30, 30)
        Panel7.TabIndex = 1
        ' 
        ' btnCristales
        ' 
        btnCristales.Cursor = Cursors.Hand
        btnCristales.Dock = DockStyle.Fill
        btnCristales.FlatAppearance.BorderSize = 0
        btnCristales.FlatAppearance.MouseDownBackColor = Color.Silver
        btnCristales.FlatAppearance.MouseOverBackColor = Color.Lavender
        btnCristales.FlatStyle = FlatStyle.Flat
        btnCristales.IconChar = FontAwesome.Sharp.IconChar.NodeJs
        btnCristales.IconColor = Color.White
        btnCristales.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnCristales.IconSize = 28
        btnCristales.Location = New Point(0, 0)
        btnCristales.Name = "btnCristales"
        btnCristales.Size = New Size(30, 30)
        btnCristales.TabIndex = 1
        btnCristales.TextImageRelation = TextImageRelation.ImageAboveText
        btnCristales.UseVisualStyleBackColor = True
        ' 
        ' Panel6
        ' 
        Panel6.Controls.Add(btnMonturas)
        Panel6.Location = New Point(14, 3)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(30, 30)
        Panel6.TabIndex = 1
        ' 
        ' btnMonturas
        ' 
        btnMonturas.Cursor = Cursors.Hand
        btnMonturas.Dock = DockStyle.Fill
        btnMonturas.FlatAppearance.BorderSize = 0
        btnMonturas.FlatAppearance.MouseDownBackColor = Color.Silver
        btnMonturas.FlatAppearance.MouseOverBackColor = Color.Lavender
        btnMonturas.FlatStyle = FlatStyle.Flat
        btnMonturas.IconChar = FontAwesome.Sharp.IconChar.NodeJs
        btnMonturas.IconColor = Color.White
        btnMonturas.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnMonturas.IconSize = 28
        btnMonturas.Location = New Point(0, 0)
        btnMonturas.Name = "btnMonturas"
        btnMonturas.Size = New Size(30, 30)
        btnMonturas.TabIndex = 0
        btnMonturas.TextImageRelation = TextImageRelation.ImageAboveText
        btnMonturas.UseVisualStyleBackColor = True
        ' 
        ' Panel10
        ' 
        Panel10.Controls.Add(TableLayoutPanel1)
        Panel10.Location = New Point(913, 58)
        Panel10.Name = "Panel10"
        Panel10.Size = New Size(249, 414)
        Panel10.TabIndex = 12
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 56.78479F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 43.2152138F))
        TableLayoutPanel1.Controls.Add(Label5, 0, 0)
        TableLayoutPanel1.Controls.Add(lblTotalGeneral, 1, 3)
        TableLayoutPanel1.Controls.Add(Label3, 0, 1)
        TableLayoutPanel1.Controls.Add(lblIva, 1, 2)
        TableLayoutPanel1.Controls.Add(Label4, 0, 3)
        TableLayoutPanel1.Controls.Add(lblBaseImponible, 1, 1)
        TableLayoutPanel1.Controls.Add(lblTextoIva, 0, 2)
        TableLayoutPanel1.Controls.Add(lblExento, 1, 0)
        TableLayoutPanel1.Location = New Point(8, 41)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 5
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 20.0F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 20.0F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 20.0F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 20.0F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 20.0F))
        TableLayoutPanel1.Size = New Size(234, 208)
        TableLayoutPanel1.TabIndex = 10
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(3, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(90, 17)
        Label5.TabIndex = 9
        Label5.Text = "Total Exento:"
        Label5.TextAlign = ContentAlignment.TopRight
        ' 
        ' lblTotalGeneral
        ' 
        lblTotalGeneral.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold)
        lblTotalGeneral.Location = New Point(135, 123)
        lblTotalGeneral.Name = "lblTotalGeneral"
        lblTotalGeneral.Size = New Size(82, 16)
        lblTotalGeneral.TabIndex = 2
        lblTotalGeneral.Text = "0.00"
        lblTotalGeneral.TextAlign = ContentAlignment.TopRight
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(3, 41)
        Label3.Name = "Label3"
        Label3.Size = New Size(110, 17)
        Label3.TabIndex = 7
        Label3.Text = "Base Imponible:"
        Label3.TextAlign = ContentAlignment.TopRight
        ' 
        ' lblIva
        ' 
        lblIva.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold)
        lblIva.Location = New Point(135, 82)
        lblIva.Name = "lblIva"
        lblIva.Size = New Size(82, 16)
        lblIva.TabIndex = 4
        lblIva.Text = "0.00"
        lblIva.TextAlign = ContentAlignment.TopRight
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(3, 123)
        Label4.Name = "Label4"
        Label4.Size = New Size(98, 17)
        Label4.TabIndex = 3
        Label4.Text = "Total General:"
        Label4.TextAlign = ContentAlignment.TopRight
        ' 
        ' lblBaseImponible
        ' 
        lblBaseImponible.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold)
        lblBaseImponible.Location = New Point(135, 41)
        lblBaseImponible.Name = "lblBaseImponible"
        lblBaseImponible.Size = New Size(82, 16)
        lblBaseImponible.TabIndex = 6
        lblBaseImponible.Text = "0.00"
        lblBaseImponible.TextAlign = ContentAlignment.TopRight
        ' 
        ' lblTextoIva
        ' 
        lblTextoIva.AutoSize = True
        lblTextoIva.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblTextoIva.Location = New Point(3, 82)
        lblTextoIva.Name = "lblTextoIva"
        lblTextoIva.RightToLeft = RightToLeft.No
        lblTextoIva.Size = New Size(70, 17)
        lblTextoIva.TabIndex = 5
        lblTextoIva.Text = "IVA (16%):"
        lblTextoIva.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' lblExento
        ' 
        lblExento.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold)
        lblExento.Location = New Point(135, 0)
        lblExento.Name = "lblExento"
        lblExento.Size = New Size(82, 16)
        lblExento.TabIndex = 8
        lblExento.Text = "0.00"
        lblExento.TextAlign = ContentAlignment.TopRight
        ' 
        ' cDatosProductos
        ' 
        AutoScaleMode = AutoScaleMode.None
        BackColor = Color.WhiteSmoke
        Controls.Add(Panel10)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Controls.Add(PanelTituloui2)
        Controls.Add(PanelTituloui1)
        Controls.Add(tlpFooter)
        Name = "cDatosProductos"
        Size = New Size(1190, 557)
        tlpFooter.ResumeLayout(False)
        Panel4.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        Panel9.ResumeLayout(False)
        Panel8.ResumeLayout(False)
        Panel7.ResumeLayout(False)
        Panel6.ResumeLayout(False)
        Panel10.ResumeLayout(False)
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents tlpFooter As TableLayoutPanel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btnAnterior As CommandButtonUI
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PanelTituloui1 As PanelTituloUI
    Friend WithEvents PanelTituloui2 As PanelTituloUI
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents btnMonturas As FontAwesome.Sharp.IconButton
    Friend WithEvents btnOtros As FontAwesome.Sharp.IconButton
    Friend WithEvents btnMiselaneos As FontAwesome.Sharp.IconButton
    Friend WithEvents btnCristales As FontAwesome.Sharp.IconButton
    Friend WithEvents Panel10 As Panel
    Friend WithEvents lblTotalGeneral As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblIva As Label
    Friend WithEvents lblTextoIva As Label
    Friend WithEvents lblBaseImponible As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblExento As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel

End Class
