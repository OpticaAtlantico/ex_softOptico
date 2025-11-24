<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucProductos
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
        tlpContenido = New TableLayoutPanel()
        TableLayoutPanel3 = New TableLayoutPanel()
        Panel2 = New Panel()
        Label2 = New Label()
        pnlBtnIzquierdo = New Panel()
        pnlBtnDerecho = New Panel()
        TableLayoutPanel2 = New TableLayoutPanel()
        Panel1 = New Panel()
        Label1 = New Label()
        TableLayoutPanel4 = New TableLayoutPanel()
        tlpContenidoFoto = New TableLayoutPanel()
        imgFoto = New FontAwesome.Sharp.IconPictureBox()
        TableLayoutPanel1 = New TableLayoutPanel()
        btnEliminarFoto = New FontAwesome.Sharp.IconButton()
        btnGuardarFoto = New FontAwesome.Sharp.IconButton()
        tlpFooter = New TableLayoutPanel()
        Panel5 = New Panel()
        btnSiguiente = New CommandButtonUI()
        Panel4 = New Panel()
        CommandButtonui1 = New CommandButtonUI()
        pnlIzquierdo = New Panel()
        tlpContenido.SuspendLayout()
        TableLayoutPanel3.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        tlpContenidoFoto.SuspendLayout()
        CType(imgFoto, ComponentModel.ISupportInitialize).BeginInit()
        TableLayoutPanel1.SuspendLayout()
        tlpFooter.SuspendLayout()
        Panel5.SuspendLayout()
        Panel4.SuspendLayout()
        pnlIzquierdo.SuspendLayout()
        SuspendLayout()
        ' 
        ' tlpContenido
        ' 
        tlpContenido.ColumnCount = 2
        tlpContenido.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpContenido.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpContenido.Controls.Add(TableLayoutPanel3, 1, 3)
        tlpContenido.Controls.Add(pnlBtnIzquierdo, 0, 5)
        tlpContenido.Controls.Add(pnlBtnDerecho, 1, 5)
        tlpContenido.Controls.Add(TableLayoutPanel2, 0, 3)
        tlpContenido.Controls.Add(TableLayoutPanel4, 0, 0)
        tlpContenido.Location = New Point(293, 15)
        tlpContenido.Name = "tlpContenido"
        tlpContenido.RowCount = 6
        tlpContenido.RowStyles.Add(New RowStyle(SizeType.Absolute, 80F))
        tlpContenido.RowStyles.Add(New RowStyle(SizeType.Absolute, 80F))
        tlpContenido.RowStyles.Add(New RowStyle(SizeType.Absolute, 80F))
        tlpContenido.RowStyles.Add(New RowStyle(SizeType.Absolute, 80F))
        tlpContenido.RowStyles.Add(New RowStyle(SizeType.Absolute, 50F))
        tlpContenido.RowStyles.Add(New RowStyle(SizeType.Absolute, 50F))
        tlpContenido.Size = New Size(778, 432)
        tlpContenido.TabIndex = 0
        ' 
        ' TableLayoutPanel3
        ' 
        TableLayoutPanel3.ColumnCount = 1
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel3.Controls.Add(Panel2, 0, 1)
        TableLayoutPanel3.Controls.Add(Label2, 0, 0)
        TableLayoutPanel3.Dock = DockStyle.Fill
        TableLayoutPanel3.Location = New Point(392, 243)
        TableLayoutPanel3.Name = "TableLayoutPanel3"
        TableLayoutPanel3.RowCount = 2
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 30F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 70F))
        TableLayoutPanel3.Size = New Size(383, 74)
        TableLayoutPanel3.TabIndex = 36
        ' 
        ' Panel2
        ' 
        Panel2.Dock = DockStyle.Fill
        Panel2.Location = New Point(3, 25)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(377, 46)
        Panel2.TabIndex = 37
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.DarkSlateGray
        Label2.Location = New Point(3, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(58, 17)
        Label2.TabIndex = 36
        Label2.Text = "Activo?"
        ' 
        ' pnlBtnIzquierdo
        ' 
        pnlBtnIzquierdo.Dock = DockStyle.Fill
        pnlBtnIzquierdo.Location = New Point(3, 373)
        pnlBtnIzquierdo.Name = "pnlBtnIzquierdo"
        pnlBtnIzquierdo.Size = New Size(383, 56)
        pnlBtnIzquierdo.TabIndex = 11
        ' 
        ' pnlBtnDerecho
        ' 
        pnlBtnDerecho.Dock = DockStyle.Fill
        pnlBtnDerecho.Location = New Point(392, 373)
        pnlBtnDerecho.Name = "pnlBtnDerecho"
        pnlBtnDerecho.Size = New Size(383, 56)
        pnlBtnDerecho.TabIndex = 12
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 1
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.Controls.Add(Panel1, 0, 1)
        TableLayoutPanel2.Controls.Add(Label1, 0, 0)
        TableLayoutPanel2.Dock = DockStyle.Fill
        TableLayoutPanel2.Location = New Point(3, 243)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 2
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 30F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 70F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel2.Size = New Size(383, 74)
        TableLayoutPanel2.TabIndex = 35
        ' 
        ' Panel1
        ' 
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(3, 25)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(377, 46)
        Panel1.TabIndex = 36
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.DarkSlateGray
        Label1.Location = New Point(3, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(141, 17)
        Label1.TabIndex = 35
        Label1.Text = "Requiere Inventario?"
        ' 
        ' TableLayoutPanel4
        ' 
        TableLayoutPanel4.ColumnCount = 2
        TableLayoutPanel4.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 80F))
        TableLayoutPanel4.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20F))
        TableLayoutPanel4.Dock = DockStyle.Fill
        TableLayoutPanel4.Location = New Point(3, 3)
        TableLayoutPanel4.Name = "TableLayoutPanel4"
        TableLayoutPanel4.RowCount = 1
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel4.Size = New Size(383, 74)
        TableLayoutPanel4.TabIndex = 37
        ' 
        ' tlpContenidoFoto
        ' 
        tlpContenidoFoto.ColumnCount = 1
        tlpContenidoFoto.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        tlpContenidoFoto.Controls.Add(imgFoto, 0, 0)
        tlpContenidoFoto.Controls.Add(TableLayoutPanel1, 0, 1)
        tlpContenidoFoto.Location = New Point(14, 14)
        tlpContenidoFoto.Name = "tlpContenidoFoto"
        tlpContenidoFoto.RowCount = 2
        tlpContenidoFoto.RowStyles.Add(New RowStyle(SizeType.Absolute, 280F))
        tlpContenidoFoto.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        tlpContenidoFoto.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        tlpContenidoFoto.Size = New Size(254, 355)
        tlpContenidoFoto.TabIndex = 1
        ' 
        ' imgFoto
        ' 
        imgFoto.BackColor = Color.White
        imgFoto.BorderStyle = BorderStyle.FixedSingle
        imgFoto.ForeColor = SystemColors.MenuHighlight
        imgFoto.IconChar = FontAwesome.Sharp.IconChar.Glasses
        imgFoto.IconColor = SystemColors.MenuHighlight
        imgFoto.IconFont = FontAwesome.Sharp.IconFont.Auto
        imgFoto.IconSize = 248
        imgFoto.Location = New Point(3, 3)
        imgFoto.Name = "imgFoto"
        imgFoto.Size = New Size(248, 274)
        imgFoto.TabIndex = 0
        imgFoto.TabStop = False
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Controls.Add(btnEliminarFoto, 1, 0)
        TableLayoutPanel1.Controls.Add(btnGuardarFoto, 0, 0)
        TableLayoutPanel1.Location = New Point(3, 283)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 300F))
        TableLayoutPanel1.Size = New Size(248, 69)
        TableLayoutPanel1.TabIndex = 1
        ' 
        ' btnEliminarFoto
        ' 
        btnEliminarFoto.FlatAppearance.BorderSize = 0
        btnEliminarFoto.FlatStyle = FlatStyle.Flat
        btnEliminarFoto.Font = New Font("Century Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnEliminarFoto.IconChar = FontAwesome.Sharp.IconChar.TrashRestore
        btnEliminarFoto.IconColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        btnEliminarFoto.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnEliminarFoto.IconSize = 40
        btnEliminarFoto.Location = New Point(127, 3)
        btnEliminarFoto.Name = "btnEliminarFoto"
        btnEliminarFoto.Size = New Size(118, 66)
        btnEliminarFoto.TabIndex = 28
        btnEliminarFoto.Text = "Remover"
        btnEliminarFoto.TextImageRelation = TextImageRelation.ImageAboveText
        btnEliminarFoto.UseVisualStyleBackColor = True
        ' 
        ' btnGuardarFoto
        ' 
        btnGuardarFoto.FlatAppearance.BorderSize = 0
        btnGuardarFoto.FlatStyle = FlatStyle.Flat
        btnGuardarFoto.Font = New Font("Century Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnGuardarFoto.IconChar = FontAwesome.Sharp.IconChar.FolderOpen
        btnGuardarFoto.IconColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        btnGuardarFoto.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnGuardarFoto.IconSize = 40
        btnGuardarFoto.Location = New Point(3, 3)
        btnGuardarFoto.Name = "btnGuardarFoto"
        btnGuardarFoto.Size = New Size(118, 66)
        btnGuardarFoto.TabIndex = 27
        btnGuardarFoto.Text = "Agregar"
        btnGuardarFoto.TextImageRelation = TextImageRelation.ImageAboveText
        btnGuardarFoto.UseVisualStyleBackColor = True
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
        tlpFooter.Location = New Point(0, 453)
        tlpFooter.Name = "tlpFooter"
        tlpFooter.RowCount = 1
        tlpFooter.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        tlpFooter.Size = New Size(1100, 66)
        tlpFooter.TabIndex = 2
        ' 
        ' Panel5
        ' 
        Panel5.Controls.Add(btnSiguiente)
        Panel5.Dock = DockStyle.Fill
        Panel5.Location = New Point(553, 3)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(544, 60)
        Panel5.TabIndex = 15
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
        btnSiguiente.Location = New Point(326, 8)
        btnSiguiente.Name = "btnSiguiente"
        btnSiguiente.RadioBorde = 8
        btnSiguiente.Size = New Size(200, 44)
        btnSiguiente.TabIndex = 2
        btnSiguiente.Text = "CommandButtonui1"
        btnSiguiente.Texto = "Siguiente..."
        ' 
        ' Panel4
        ' 
        Panel4.Controls.Add(CommandButtonui1)
        Panel4.Dock = DockStyle.Fill
        Panel4.Location = New Point(3, 3)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(544, 60)
        Panel4.TabIndex = 14
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
        CommandButtonui1.Location = New Point(672, 8)
        CommandButtonui1.Name = "CommandButtonui1"
        CommandButtonui1.RadioBorde = 8
        CommandButtonui1.Size = New Size(200, 44)
        CommandButtonui1.TabIndex = 1
        CommandButtonui1.Text = "CommandButtonui1"
        CommandButtonui1.Texto = "Siguiente..."
        ' 
        ' pnlIzquierdo
        ' 
        pnlIzquierdo.BackColor = Color.White
        pnlIzquierdo.Controls.Add(tlpContenidoFoto)
        pnlIzquierdo.Dock = DockStyle.Left
        pnlIzquierdo.Location = New Point(0, 0)
        pnlIzquierdo.Name = "pnlIzquierdo"
        pnlIzquierdo.Size = New Size(285, 453)
        pnlIzquierdo.TabIndex = 3
        ' 
        ' ucProductos
        ' 
        AutoScaleMode = AutoScaleMode.None
        BackColor = Color.White
        Controls.Add(pnlIzquierdo)
        Controls.Add(tlpFooter)
        Controls.Add(tlpContenido)
        Name = "ucProductos"
        Size = New Size(1100, 519)
        tlpContenido.ResumeLayout(False)
        TableLayoutPanel3.ResumeLayout(False)
        TableLayoutPanel3.PerformLayout()
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel2.PerformLayout()
        tlpContenidoFoto.ResumeLayout(False)
        CType(imgFoto, ComponentModel.ISupportInitialize).EndInit()
        TableLayoutPanel1.ResumeLayout(False)
        tlpFooter.ResumeLayout(False)
        Panel5.ResumeLayout(False)
        Panel4.ResumeLayout(False)
        pnlIzquierdo.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents tlpContenido As TableLayoutPanel
    Friend WithEvents tlpContenidoFoto As TableLayoutPanel
    Friend WithEvents tlpFooter As TableLayoutPanel
    Friend WithEvents pnlIzquierdo As Panel
    Friend WithEvents imgFoto As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents btnEliminarFoto As FontAwesome.Sharp.IconButton
    Friend WithEvents btnGuardarFoto As FontAwesome.Sharp.IconButton
    Friend WithEvents pnlBtnIzquierdo As Panel
    Friend WithEvents pnlBtnDerecho As Panel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents btnSiguiente As CommandButtonUI
    Friend WithEvents Panel4 As Panel
    Friend WithEvents CommandButtonui1 As CommandButtonUI

End Class
