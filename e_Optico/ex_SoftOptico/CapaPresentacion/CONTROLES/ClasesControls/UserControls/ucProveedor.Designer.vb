<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucProveedor
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        tlpContenido = New TableLayoutPanel()
        cmbProveedor = New ComboBoxLabelUI()
        dgvProveedor = New DataGridViewProveedorUI()
        tlpContenidoFoto = New TableLayoutPanel()
        imgFoto = New FontAwesome.Sharp.IconPictureBox()
        TableLayoutPanel1 = New TableLayoutPanel()
        btnGuardarFoto = New FontAwesome.Sharp.IconButton()
        tlpFooter = New TableLayoutPanel()
        pnlBtnDerecho = New Panel()
        btnSiguiente = New CommandButtonUI()
        pnlBtnIzquierdo = New Panel()
        btnAnterior = New CommandButtonUI()
        pnlIzquierdo = New Panel()
        tlpContenido.SuspendLayout()
        tlpContenidoFoto.SuspendLayout()
        CType(imgFoto, ComponentModel.ISupportInitialize).BeginInit()
        TableLayoutPanel1.SuspendLayout()
        tlpFooter.SuspendLayout()
        pnlBtnDerecho.SuspendLayout()
        pnlBtnIzquierdo.SuspendLayout()
        pnlIzquierdo.SuspendLayout()
        SuspendLayout()
        ' 
        ' tlpContenido
        ' 
        tlpContenido.ColumnCount = 1
        tlpContenido.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpContenido.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpContenido.Controls.Add(cmbProveedor, 0, 0)
        tlpContenido.Controls.Add(dgvProveedor, 0, 1)
        tlpContenido.Location = New Point(293, 15)
        tlpContenido.Name = "tlpContenido"
        tlpContenido.RowCount = 2
        tlpContenido.RowStyles.Add(New RowStyle(SizeType.Absolute, 80F))
        tlpContenido.RowStyles.Add(New RowStyle(SizeType.Absolute, 80F))
        tlpContenido.RowStyles.Add(New RowStyle(SizeType.Absolute, 80F))
        tlpContenido.RowStyles.Add(New RowStyle(SizeType.Absolute, 80F))
        tlpContenido.RowStyles.Add(New RowStyle(SizeType.Absolute, 50F))
        tlpContenido.RowStyles.Add(New RowStyle(SizeType.Absolute, 50F))
        tlpContenido.Size = New Size(778, 432)
        tlpContenido.TabIndex = 0
        ' 
        ' cmbProveedor
        ' 
        cmbProveedor.BackColor = Color.Transparent
        cmbProveedor.BackColorPnl = Color.WhiteSmoke
        cmbProveedor.BorderColor = Color.LightGray
        cmbProveedor.BorderSize = 1
        cmbProveedor.CampoRequerido = True
        cmbProveedor.ForeColor = Color.Black
        cmbProveedor.IndiceSeleccionado = -1
        cmbProveedor.LabelColor = Color.DarkSlateGray
        cmbProveedor.Location = New Point(3, 3)
        cmbProveedor.MensajeError = "Este campo es obligatorio."
        cmbProveedor.MostrarError = False
        cmbProveedor.Name = "cmbProveedor"
        cmbProveedor.RadioContornoPanel = 8
        cmbProveedor.Size = New Size(772, 74)
        cmbProveedor.SombraBackColor = Color.LightGray
        cmbProveedor.TabIndex = 8
        cmbProveedor.Titulo = "Proveedor:"
        cmbProveedor.ValorSeleccionado = Nothing
        ' 
        ' dgvProveedor
        ' 
        dgvProveedor.Dock = DockStyle.Fill
        dgvProveedor.Location = New Point(3, 83)
        dgvProveedor.Name = "dgvProveedor"
        dgvProveedor.Size = New Size(772, 346)
        dgvProveedor.TabIndex = 9
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
        imgFoto.IconChar = FontAwesome.Sharp.IconChar.TruckArrowRight
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
        TableLayoutPanel1.ColumnCount = 1
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Controls.Add(btnGuardarFoto, 0, 0)
        TableLayoutPanel1.Location = New Point(3, 283)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 300F))
        TableLayoutPanel1.Size = New Size(248, 69)
        TableLayoutPanel1.TabIndex = 1
        ' 
        ' btnGuardarFoto
        ' 
        btnGuardarFoto.FlatAppearance.BorderSize = 0
        btnGuardarFoto.FlatStyle = FlatStyle.Flat
        btnGuardarFoto.Font = New Font("Century Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnGuardarFoto.IconChar = FontAwesome.Sharp.IconChar.CartPlus
        btnGuardarFoto.IconColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        btnGuardarFoto.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnGuardarFoto.IconSize = 40
        btnGuardarFoto.Location = New Point(3, 3)
        btnGuardarFoto.Name = "btnGuardarFoto"
        btnGuardarFoto.Size = New Size(242, 66)
        btnGuardarFoto.TabIndex = 27
        btnGuardarFoto.Text = "Editar datos..."
        btnGuardarFoto.TextImageRelation = TextImageRelation.ImageAboveText
        btnGuardarFoto.UseVisualStyleBackColor = True
        ' 
        ' tlpFooter
        ' 
        tlpFooter.BackColor = Color.LightSkyBlue
        tlpFooter.ColumnCount = 2
        tlpFooter.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpFooter.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpFooter.Controls.Add(pnlBtnDerecho, 1, 0)
        tlpFooter.Controls.Add(pnlBtnIzquierdo, 0, 0)
        tlpFooter.Dock = DockStyle.Bottom
        tlpFooter.Location = New Point(0, 453)
        tlpFooter.Name = "tlpFooter"
        tlpFooter.RowCount = 1
        tlpFooter.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        tlpFooter.Size = New Size(1100, 66)
        tlpFooter.TabIndex = 2
        ' 
        ' pnlBtnDerecho
        ' 
        pnlBtnDerecho.Controls.Add(btnSiguiente)
        pnlBtnDerecho.Dock = DockStyle.Fill
        pnlBtnDerecho.Location = New Point(553, 3)
        pnlBtnDerecho.Name = "pnlBtnDerecho"
        pnlBtnDerecho.Size = New Size(544, 60)
        pnlBtnDerecho.TabIndex = 13
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
        btnSiguiente.ColorTexto = Color.White
        btnSiguiente.EstiloBoton = CommandButtonUI.EstiloBootstrap.Primary
        btnSiguiente.Font = New Font("Century Gothic", 10F, FontStyle.Bold)
        btnSiguiente.Icono = FontAwesome.Sharp.IconChar.CircleRight
        btnSiguiente.Location = New Point(328, 8)
        btnSiguiente.Name = "btnSiguiente"
        btnSiguiente.RadioBorde = 8
        btnSiguiente.Size = New Size(200, 44)
        btnSiguiente.TabIndex = 1
        btnSiguiente.Text = "CommandButtonui1"
        btnSiguiente.Texto = "Siguiente..."
        ' 
        ' pnlBtnIzquierdo
        ' 
        pnlBtnIzquierdo.Controls.Add(btnAnterior)
        pnlBtnIzquierdo.Dock = DockStyle.Fill
        pnlBtnIzquierdo.Location = New Point(3, 3)
        pnlBtnIzquierdo.Name = "pnlBtnIzquierdo"
        pnlBtnIzquierdo.Size = New Size(544, 60)
        pnlBtnIzquierdo.TabIndex = 12
        ' 
        ' btnAnterior
        ' 
        btnAnterior.AnimarHover = True
        btnAnterior.BackColor = Color.Transparent
        btnAnterior.ColorBase = Color.FromArgb(CByte(33), CByte(150), CByte(243))
        btnAnterior.ColorHover = Color.FromArgb(CByte(30), CByte(136), CByte(229))
        btnAnterior.ColorInternoFondo = Color.FromArgb(CByte(33), CByte(150), CByte(243))
        btnAnterior.ColorPresionado = Color.FromArgb(CByte(25), CByte(118), CByte(210))
        btnAnterior.ColorTexto = Color.White
        btnAnterior.EstiloBoton = CommandButtonUI.EstiloBootstrap.Primary
        btnAnterior.Font = New Font("Century Gothic", 10F, FontStyle.Bold)
        btnAnterior.Icono = FontAwesome.Sharp.IconChar.ArrowAltCircleLeft
        btnAnterior.Location = New Point(11, 8)
        btnAnterior.Name = "btnAnterior"
        btnAnterior.RadioBorde = 8
        btnAnterior.Size = New Size(200, 44)
        btnAnterior.TabIndex = 2
        btnAnterior.Text = "CommandButtonui1"
        btnAnterior.Texto = "Anterior..."
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
        ' ucProveedor
        ' 
        AutoScaleMode = AutoScaleMode.None
        BackColor = Color.White
        Controls.Add(pnlIzquierdo)
        Controls.Add(tlpFooter)
        Controls.Add(tlpContenido)
        Name = "ucProveedor"
        Size = New Size(1100, 519)
        tlpContenido.ResumeLayout(False)
        tlpContenidoFoto.ResumeLayout(False)
        CType(imgFoto, ComponentModel.ISupportInitialize).EndInit()
        TableLayoutPanel1.ResumeLayout(False)
        tlpFooter.ResumeLayout(False)
        pnlBtnDerecho.ResumeLayout(False)
        pnlBtnIzquierdo.ResumeLayout(False)
        pnlIzquierdo.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents tlpContenido As TableLayoutPanel
    Friend WithEvents tlpContenidoFoto As TableLayoutPanel
    Friend WithEvents tlpFooter As TableLayoutPanel
    Friend WithEvents pnlIzquierdo As Panel
    Friend WithEvents imgFoto As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents btnGuardarFoto As FontAwesome.Sharp.IconButton
    Friend WithEvents pnlBtnDerecho As Panel
    Friend WithEvents btnSiguiente As CommandButtonUI
    Friend WithEvents pnlBtnIzquierdo As Panel
    Friend WithEvents btnAnterior As CommandButtonUI
    Friend WithEvents cmbProveedor As ComboBoxLabelUI
    Friend WithEvents dgvProveedor As DataGridViewProveedorUI

End Class
