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
        dgvProveedor = New DataGridViewProveedorUI()
        TableLayoutPanel2 = New TableLayoutPanel()
        txtCedula = New MaskedTextBoxLabelUI()
        cmbProveedor = New ComboBoxLabelUI()
        TableLayoutPanel3 = New TableLayoutPanel()
        btnAgregar = New FontAwesome.Sharp.IconButton()
        Panel1 = New Panel()
        Label1 = New Label()
        optRequiereInvNo = New OptionButtonLabelUI()
        optRequiereInvSi = New OptionButtonLabelUI()
        txtFechaNac = New DateBoxLabelUI()
        MaskedTextBoxLabelui1 = New MaskedTextBoxLabelUI()
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
        TableLayoutPanel2.SuspendLayout()
        TableLayoutPanel3.SuspendLayout()
        Panel1.SuspendLayout()
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
        tlpContenido.AutoScroll = True
        tlpContenido.ColumnCount = 1
        tlpContenido.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        tlpContenido.Controls.Add(dgvProveedor, 0, 2)
        tlpContenido.Controls.Add(TableLayoutPanel2, 0, 0)
        tlpContenido.Controls.Add(TableLayoutPanel3, 0, 1)
        tlpContenido.Location = New Point(293, 15)
        tlpContenido.Name = "tlpContenido"
        tlpContenido.RowCount = 3
        tlpContenido.RowStyles.Add(New RowStyle(SizeType.Absolute, 90F))
        tlpContenido.RowStyles.Add(New RowStyle(SizeType.Absolute, 90F))
        tlpContenido.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        tlpContenido.Size = New Size(778, 432)
        tlpContenido.TabIndex = 0
        ' 
        ' dgvProveedor
        ' 
        dgvProveedor.Dock = DockStyle.Fill
        dgvProveedor.Location = New Point(3, 183)
        dgvProveedor.Name = "dgvProveedor"
        dgvProveedor.Size = New Size(772, 246)
        dgvProveedor.TabIndex = 9
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 2
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 70F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 30F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20F))
        TableLayoutPanel2.Controls.Add(txtCedula, 1, 0)
        TableLayoutPanel2.Controls.Add(cmbProveedor, 0, 0)
        TableLayoutPanel2.Dock = DockStyle.Fill
        TableLayoutPanel2.Location = New Point(3, 3)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 1
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.Size = New Size(772, 84)
        TableLayoutPanel2.TabIndex = 10
        ' 
        ' txtCedula
        ' 
        txtCedula.BackColor = Color.Transparent
        txtCedula.BorderColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtCedula.BorderRadius = 8
        txtCedula.BorderSize = 1
        txtCedula.CampoRequerido = True
        txtCedula.ColorError = Color.Firebrick
        txtCedula.FontField = New Font("Century Gothic", 12F)
        txtCedula.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtCedula.IconoDerechoChar = FontAwesome.Sharp.IconChar.Vcard
        txtCedula.LabelColor = Color.DarkSlateGray
        txtCedula.LabelText = "#Cédula:"
        txtCedula.Location = New Point(543, 3)
        txtCedula.MascaraPersonalizada = ""
        txtCedula.MaxCaracteres = 8
        txtCedula.MensajeError = "Este campo es obligatorio."
        txtCedula.Name = "txtCedula"
        txtCedula.PaddingAll = 10
        txtCedula.PanelBackColor = Color.White
        txtCedula.SelectionStart = 0
        txtCedula.Size = New Size(226, 78)
        txtCedula.SombraBackColor = Color.LightGray
        txtCedula.TabIndex = 9
        txtCedula.TextColor = Color.Black
        txtCedula.TextoUsuario = ""
        txtCedula.TipoNumerico = MaskedTextBoxLabelUI.TipoEntradaNumerica.Entero
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
        cmbProveedor.Size = New Size(534, 78)
        cmbProveedor.SombraBackColor = Color.LightGray
        cmbProveedor.TabIndex = 8
        cmbProveedor.Titulo = "Proveedor:"
        cmbProveedor.ValorSeleccionado = Nothing
        ' 
        ' TableLayoutPanel3
        ' 
        TableLayoutPanel3.ColumnCount = 4
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 32.48511F))
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 27.0709248F))
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 27.0709248F))
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 13.3730364F))
        TableLayoutPanel3.Controls.Add(btnAgregar, 3, 0)
        TableLayoutPanel3.Controls.Add(Panel1, 2, 0)
        TableLayoutPanel3.Controls.Add(txtFechaNac, 1, 0)
        TableLayoutPanel3.Controls.Add(MaskedTextBoxLabelui1, 0, 0)
        TableLayoutPanel3.Dock = DockStyle.Fill
        TableLayoutPanel3.Location = New Point(3, 93)
        TableLayoutPanel3.Name = "TableLayoutPanel3"
        TableLayoutPanel3.RowCount = 1
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel3.Size = New Size(772, 84)
        TableLayoutPanel3.TabIndex = 11
        ' 
        ' btnAgregar
        ' 
        btnAgregar.FlatAppearance.BorderSize = 0
        btnAgregar.FlatStyle = FlatStyle.Flat
        btnAgregar.Font = New Font("Century Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnAgregar.IconChar = FontAwesome.Sharp.IconChar.ArrowTurnDown
        btnAgregar.IconColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        btnAgregar.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnAgregar.IconSize = 40
        btnAgregar.Location = New Point(669, 3)
        btnAgregar.Name = "btnAgregar"
        btnAgregar.Size = New Size(100, 78)
        btnAgregar.TabIndex = 38
        btnAgregar.Text = "Incluir datos"
        btnAgregar.TextImageRelation = TextImageRelation.ImageAboveText
        btnAgregar.UseVisualStyleBackColor = True
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(optRequiereInvNo)
        Panel1.Controls.Add(optRequiereInvSi)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(461, 3)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(202, 78)
        Panel1.TabIndex = 37
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.DarkSlateGray
        Label1.Location = New Point(6, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(190, 17)
        Label1.TabIndex = 36
        Label1.Text = "El proveedor es el principal?"
        ' 
        ' optRequiereInvNo
        ' 
        optRequiereInvNo.BackColor = Color.Transparent
        optRequiereInvNo.BorderColor = Color.Gray
        optRequiereInvNo.Checked = False
        optRequiereInvNo.CheckedColor = Color.MediumSlateBlue
        optRequiereInvNo.Location = New Point(115, 39)
        optRequiereInvNo.Name = "optRequiereInvNo"
        optRequiereInvNo.Size = New Size(76, 26)
        optRequiereInvNo.TabIndex = 1
        optRequiereInvNo.Texto = "No"
        ' 
        ' optRequiereInvSi
        ' 
        optRequiereInvSi.BackColor = Color.Transparent
        optRequiereInvSi.BorderColor = Color.Gray
        optRequiereInvSi.Checked = True
        optRequiereInvSi.CheckedColor = Color.MediumSlateBlue
        optRequiereInvSi.Location = New Point(31, 39)
        optRequiereInvSi.Name = "optRequiereInvSi"
        optRequiereInvSi.Size = New Size(76, 26)
        optRequiereInvSi.TabIndex = 0
        optRequiereInvSi.Texto = "Si"
        ' 
        ' txtFechaNac
        ' 
        txtFechaNac.BackColor = Color.White
        txtFechaNac.BorderColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtFechaNac.BorderRadius = 8
        txtFechaNac.BorderSize = 1
        txtFechaNac.CampoRequerido = True
        txtFechaNac.FechaSeleccionada = New Date(2025, 7, 31, 0, 0, 0, 0)
        txtFechaNac.FontField = New Font("Century Gothic", 12F)
        txtFechaNac.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtFechaNac.IconoDerechoChar = FontAwesome.Sharp.IconChar.CalendarDays
        txtFechaNac.LabelColor = Color.DarkSlateGray
        txtFechaNac.LabelText = "Fecha:"
        txtFechaNac.Location = New Point(253, 3)
        txtFechaNac.MensajeError = "Fecha requerida o inválida."
        txtFechaNac.Name = "txtFechaNac"
        txtFechaNac.PaddingAll = 10
        txtFechaNac.PanelBackColor = Color.White
        txtFechaNac.Size = New Size(202, 78)
        txtFechaNac.TabIndex = 11
        txtFechaNac.TextColor = Color.Black
        ' 
        ' MaskedTextBoxLabelui1
        ' 
        MaskedTextBoxLabelui1.BackColor = Color.Transparent
        MaskedTextBoxLabelui1.BorderColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        MaskedTextBoxLabelui1.BorderRadius = 8
        MaskedTextBoxLabelui1.BorderSize = 1
        MaskedTextBoxLabelui1.CampoRequerido = True
        MaskedTextBoxLabelui1.ColorError = Color.Firebrick
        MaskedTextBoxLabelui1.FontField = New Font("Century Gothic", 12F)
        MaskedTextBoxLabelui1.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        MaskedTextBoxLabelui1.IconoDerechoChar = FontAwesome.Sharp.IconChar.Vcard
        MaskedTextBoxLabelui1.LabelColor = Color.DarkSlateGray
        MaskedTextBoxLabelui1.LabelText = "#Cédula:"
        MaskedTextBoxLabelui1.Location = New Point(3, 3)
        MaskedTextBoxLabelui1.MascaraPersonalizada = ""
        MaskedTextBoxLabelui1.MaxCaracteres = 8
        MaskedTextBoxLabelui1.MensajeError = "Este campo es obligatorio."
        MaskedTextBoxLabelui1.Name = "MaskedTextBoxLabelui1"
        MaskedTextBoxLabelui1.PaddingAll = 10
        MaskedTextBoxLabelui1.PanelBackColor = Color.White
        MaskedTextBoxLabelui1.SelectionStart = 0
        MaskedTextBoxLabelui1.Size = New Size(244, 78)
        MaskedTextBoxLabelui1.SombraBackColor = Color.LightGray
        MaskedTextBoxLabelui1.TabIndex = 10
        MaskedTextBoxLabelui1.TextColor = Color.Black
        MaskedTextBoxLabelui1.TextoUsuario = ""
        MaskedTextBoxLabelui1.TipoNumerico = MaskedTextBoxLabelUI.TipoEntradaNumerica.Entero
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
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel3.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
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
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents txtCedula As MaskedTextBoxLabelUI
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents MaskedTextBoxLabelui1 As MaskedTextBoxLabelUI
    Friend WithEvents txtFechaNac As DateBoxLabelUI
    Friend WithEvents Panel1 As Panel
    Friend WithEvents optRequiereInvNo As OptionButtonLabelUI
    Friend WithEvents optRequiereInvSi As OptionButtonLabelUI
    Friend WithEvents Label1 As Label
    Friend WithEvents btnAgregar As FontAwesome.Sharp.IconButton

End Class
