<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucStock
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
        TableLayoutPanel3 = New TableLayoutPanel()
        Panel2 = New Panel()
        optActivoNo = New OptionButtonLabelUI()
        optActivoSi = New OptionButtonLabelUI()
        Label2 = New Label()
        pnlBtnIzquierdo = New Panel()
        pnlBtnDerecho = New Panel()
        TableLayoutPanel2 = New TableLayoutPanel()
        Panel1 = New Panel()
        optRequiereInvNo = New OptionButtonLabelUI()
        optRequiereInvSi = New OptionButtonLabelUI()
        Label1 = New Label()
        tlpContenidoFoto = New TableLayoutPanel()
        imgFoto = New FontAwesome.Sharp.IconPictureBox()
        TableLayoutPanel1 = New TableLayoutPanel()
        tlpFooter = New TableLayoutPanel()
        Panel5 = New Panel()
        Panel4 = New Panel()
        btnAnterior = New CommandButtonUI()
        pnlIzquierdo = New Panel()
        txtCedula = New MaskedTextBoxLabelUI()
        MaskedTextBoxLabelui1 = New MaskedTextBoxLabelUI()
        MaskedTextBoxLabelui2 = New MaskedTextBoxLabelUI()
        MaskedTextBoxLabelui3 = New MaskedTextBoxLabelUI()
        tlpContenido.SuspendLayout()
        TableLayoutPanel3.SuspendLayout()
        Panel2.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        Panel1.SuspendLayout()
        tlpContenidoFoto.SuspendLayout()
        CType(imgFoto, ComponentModel.ISupportInitialize).BeginInit()
        tlpFooter.SuspendLayout()
        Panel4.SuspendLayout()
        pnlIzquierdo.SuspendLayout()
        SuspendLayout()
        ' 
        ' tlpContenido
        ' 
        tlpContenido.ColumnCount = 2
        tlpContenido.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpContenido.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpContenido.Controls.Add(MaskedTextBoxLabelui3, 1, 1)
        tlpContenido.Controls.Add(MaskedTextBoxLabelui2, 0, 1)
        tlpContenido.Controls.Add(MaskedTextBoxLabelui1, 1, 0)
        tlpContenido.Controls.Add(txtCedula, 0, 0)
        tlpContenido.Controls.Add(TableLayoutPanel3, 1, 3)
        tlpContenido.Controls.Add(pnlBtnIzquierdo, 0, 5)
        tlpContenido.Controls.Add(pnlBtnDerecho, 1, 5)
        tlpContenido.Controls.Add(TableLayoutPanel2, 0, 3)
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
        Panel2.Controls.Add(optActivoNo)
        Panel2.Controls.Add(optActivoSi)
        Panel2.Dock = DockStyle.Fill
        Panel2.Location = New Point(3, 25)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(377, 46)
        Panel2.TabIndex = 37
        ' 
        ' optActivoNo
        ' 
        optActivoNo.BackColor = Color.Transparent
        optActivoNo.BorderColor = Color.Gray
        optActivoNo.Checked = False
        optActivoNo.CheckedColor = Color.MediumSlateBlue
        optActivoNo.Location = New Point(130, 10)
        optActivoNo.Name = "optActivoNo"
        optActivoNo.Size = New Size(76, 26)
        optActivoNo.TabIndex = 1
        optActivoNo.Texto = "No"
        ' 
        ' optActivoSi
        ' 
        optActivoSi.BackColor = Color.Transparent
        optActivoSi.BorderColor = Color.Gray
        optActivoSi.Checked = True
        optActivoSi.CheckedColor = Color.MediumSlateBlue
        optActivoSi.Location = New Point(28, 8)
        optActivoSi.Name = "optActivoSi"
        optActivoSi.Size = New Size(76, 26)
        optActivoSi.TabIndex = 0
        optActivoSi.Texto = "Si"
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
        Panel1.Controls.Add(optRequiereInvNo)
        Panel1.Controls.Add(optRequiereInvSi)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(3, 25)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(377, 46)
        Panel1.TabIndex = 36
        ' 
        ' optRequiereInvNo
        ' 
        optRequiereInvNo.BackColor = Color.Transparent
        optRequiereInvNo.BorderColor = Color.Gray
        optRequiereInvNo.Checked = False
        optRequiereInvNo.CheckedColor = Color.MediumSlateBlue
        optRequiereInvNo.Location = New Point(130, 10)
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
        optRequiereInvSi.Location = New Point(28, 8)
        optRequiereInvSi.Name = "optRequiereInvSi"
        optRequiereInvSi.Size = New Size(76, 26)
        optRequiereInvSi.TabIndex = 0
        optRequiereInvSi.Texto = "Si"
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
        imgFoto.ForeColor = Color.DarkOrange
        imgFoto.IconChar = FontAwesome.Sharp.IconChar.BoxesStacked
        imgFoto.IconColor = Color.DarkOrange
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
        TableLayoutPanel1.Location = New Point(3, 283)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 300F))
        TableLayoutPanel1.Size = New Size(248, 69)
        TableLayoutPanel1.TabIndex = 1
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
        Panel5.Dock = DockStyle.Fill
        Panel5.Location = New Point(553, 3)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(544, 60)
        Panel5.TabIndex = 15
        ' 
        ' Panel4
        ' 
        Panel4.Controls.Add(btnAnterior)
        Panel4.Dock = DockStyle.Fill
        Panel4.Location = New Point(3, 3)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(544, 60)
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
        btnAnterior.ColorTexto = Color.White
        btnAnterior.EstiloBoton = CommandButtonUI.EstiloBootstrap.Primary
        btnAnterior.Font = New Font("Century Gothic", 10F, FontStyle.Bold)
        btnAnterior.Icono = FontAwesome.Sharp.IconChar.ArrowAltCircleLeft
        btnAnterior.Location = New Point(19, 8)
        btnAnterior.Name = "btnAnterior"
        btnAnterior.RadioBorde = 8
        btnAnterior.Size = New Size(200, 44)
        btnAnterior.TabIndex = 3
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
        txtCedula.LabelText = "Precio de Venta al Público:"
        txtCedula.Location = New Point(3, 3)
        txtCedula.MascaraPersonalizada = ""
        txtCedula.MaxCaracteres = 8
        txtCedula.MensajeError = "Este campo es obligatorio."
        txtCedula.Name = "txtCedula"
        txtCedula.PaddingAll = 10
        txtCedula.PanelBackColor = Color.White
        txtCedula.SelectionStart = 0
        txtCedula.Size = New Size(380, 74)
        txtCedula.SombraBackColor = Color.LightGray
        txtCedula.TabIndex = 37
        txtCedula.TextColor = Color.Black
        txtCedula.TextoUsuario = ""
        txtCedula.TipoNumerico = MaskedTextBoxLabelUI.TipoEntradaNumerica.Entero
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
        MaskedTextBoxLabelui1.LabelText = "Precio de Costo:"
        MaskedTextBoxLabelui1.Location = New Point(392, 3)
        MaskedTextBoxLabelui1.MascaraPersonalizada = ""
        MaskedTextBoxLabelui1.MaxCaracteres = 8
        MaskedTextBoxLabelui1.MensajeError = "Este campo es obligatorio."
        MaskedTextBoxLabelui1.Name = "MaskedTextBoxLabelui1"
        MaskedTextBoxLabelui1.PaddingAll = 10
        MaskedTextBoxLabelui1.PanelBackColor = Color.White
        MaskedTextBoxLabelui1.SelectionStart = 0
        MaskedTextBoxLabelui1.Size = New Size(380, 74)
        MaskedTextBoxLabelui1.SombraBackColor = Color.LightGray
        MaskedTextBoxLabelui1.TabIndex = 38
        MaskedTextBoxLabelui1.TextColor = Color.Black
        MaskedTextBoxLabelui1.TextoUsuario = ""
        MaskedTextBoxLabelui1.TipoNumerico = MaskedTextBoxLabelUI.TipoEntradaNumerica.Entero
        ' 
        ' MaskedTextBoxLabelui2
        ' 
        MaskedTextBoxLabelui2.BackColor = Color.Transparent
        MaskedTextBoxLabelui2.BorderColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        MaskedTextBoxLabelui2.BorderRadius = 8
        MaskedTextBoxLabelui2.BorderSize = 1
        MaskedTextBoxLabelui2.CampoRequerido = True
        MaskedTextBoxLabelui2.ColorError = Color.Firebrick
        MaskedTextBoxLabelui2.FontField = New Font("Century Gothic", 12F)
        MaskedTextBoxLabelui2.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        MaskedTextBoxLabelui2.IconoDerechoChar = FontAwesome.Sharp.IconChar.Vcard
        MaskedTextBoxLabelui2.LabelColor = Color.DarkSlateGray
        MaskedTextBoxLabelui2.LabelText = "Precio de Promosión:"
        MaskedTextBoxLabelui2.Location = New Point(3, 83)
        MaskedTextBoxLabelui2.MascaraPersonalizada = ""
        MaskedTextBoxLabelui2.MaxCaracteres = 8
        MaskedTextBoxLabelui2.MensajeError = "Este campo es obligatorio."
        MaskedTextBoxLabelui2.Name = "MaskedTextBoxLabelui2"
        MaskedTextBoxLabelui2.PaddingAll = 10
        MaskedTextBoxLabelui2.PanelBackColor = Color.White
        MaskedTextBoxLabelui2.SelectionStart = 0
        MaskedTextBoxLabelui2.Size = New Size(380, 74)
        MaskedTextBoxLabelui2.SombraBackColor = Color.LightGray
        MaskedTextBoxLabelui2.TabIndex = 39
        MaskedTextBoxLabelui2.TextColor = Color.Black
        MaskedTextBoxLabelui2.TextoUsuario = ""
        MaskedTextBoxLabelui2.TipoNumerico = MaskedTextBoxLabelUI.TipoEntradaNumerica.Entero
        ' 
        ' MaskedTextBoxLabelui3
        ' 
        MaskedTextBoxLabelui3.BackColor = Color.Transparent
        MaskedTextBoxLabelui3.BorderColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        MaskedTextBoxLabelui3.BorderRadius = 8
        MaskedTextBoxLabelui3.BorderSize = 1
        MaskedTextBoxLabelui3.CampoRequerido = True
        MaskedTextBoxLabelui3.ColorError = Color.Firebrick
        MaskedTextBoxLabelui3.FontField = New Font("Century Gothic", 12F)
        MaskedTextBoxLabelui3.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        MaskedTextBoxLabelui3.IconoDerechoChar = FontAwesome.Sharp.IconChar.Vcard
        MaskedTextBoxLabelui3.LabelColor = Color.DarkSlateGray
        MaskedTextBoxLabelui3.LabelText = "Precio de % Descuento:"
        MaskedTextBoxLabelui3.Location = New Point(392, 83)
        MaskedTextBoxLabelui3.MascaraPersonalizada = ""
        MaskedTextBoxLabelui3.MaxCaracteres = 8
        MaskedTextBoxLabelui3.MensajeError = "Este campo es obligatorio."
        MaskedTextBoxLabelui3.Name = "MaskedTextBoxLabelui3"
        MaskedTextBoxLabelui3.PaddingAll = 10
        MaskedTextBoxLabelui3.PanelBackColor = Color.White
        MaskedTextBoxLabelui3.SelectionStart = 0
        MaskedTextBoxLabelui3.Size = New Size(380, 74)
        MaskedTextBoxLabelui3.SombraBackColor = Color.LightGray
        MaskedTextBoxLabelui3.TabIndex = 40
        MaskedTextBoxLabelui3.TextColor = Color.Black
        MaskedTextBoxLabelui3.TextoUsuario = ""
        MaskedTextBoxLabelui3.TipoNumerico = MaskedTextBoxLabelUI.TipoEntradaNumerica.Entero
        ' 
        ' ucStock
        ' 
        AutoScaleMode = AutoScaleMode.None
        BackColor = Color.White
        Controls.Add(pnlIzquierdo)
        Controls.Add(tlpFooter)
        Controls.Add(tlpContenido)
        Name = "ucStock"
        Size = New Size(1100, 519)
        tlpContenido.ResumeLayout(False)
        TableLayoutPanel3.ResumeLayout(False)
        TableLayoutPanel3.PerformLayout()
        Panel2.ResumeLayout(False)
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel2.PerformLayout()
        Panel1.ResumeLayout(False)
        tlpContenidoFoto.ResumeLayout(False)
        CType(imgFoto, ComponentModel.ISupportInitialize).EndInit()
        tlpFooter.ResumeLayout(False)
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
    Friend WithEvents pnlBtnIzquierdo As Panel
    Friend WithEvents pnlBtnDerecho As Panel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents optRequiereInvNo As OptionButtonLabelUI
    Friend WithEvents optRequiereInvSi As OptionButtonLabelUI
    Friend WithEvents Panel2 As Panel
    Friend WithEvents optActivoNo As OptionButtonLabelUI
    Friend WithEvents optActivoSi As OptionButtonLabelUI
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btnAnterior As CommandButtonUI
    Friend WithEvents MaskedTextBoxLabelui3 As MaskedTextBoxLabelUI
    Friend WithEvents MaskedTextBoxLabelui2 As MaskedTextBoxLabelUI
    Friend WithEvents MaskedTextBoxLabelui1 As MaskedTextBoxLabelUI
    Friend WithEvents txtCedula As MaskedTextBoxLabelUI

End Class
