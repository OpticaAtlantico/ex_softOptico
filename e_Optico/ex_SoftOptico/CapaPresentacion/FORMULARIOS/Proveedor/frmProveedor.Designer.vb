Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ExplorerBar

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmProveedor
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
        pnlContenedor = New Panel()
        pnlFoter = New Panel()
        pnlContenido = New Panel()
        txtDireccion = New MultilineTextBoxLabelUI()
        TableLayoutPanel1 = New TableLayoutPanel()
        txtNombreEmpresa = New TextBoxLabelUI()
        txtRazonSocial = New TextBoxLabelUI()
        txtCorreo = New TextBoxLabelUI()
        txtTelefono = New MaskedTextBoxLabelUI()
        txtContacto = New MaskedTextBoxLabelUI()
        Panel1 = New Panel()
        txtRif = New MaskedTextBoxLabelUI()
        cmbSiglas = New ComboBoxLabelUI()
        pnlEncabezado = New Panel()
        btnAccion = New CommandButtonUI()
        lblEncabezado = New HeaderUI()
        pnlContenedor.SuspendLayout()
        pnlContenido.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        Panel1.SuspendLayout()
        pnlEncabezado.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlContenedor
        ' 
        pnlContenedor.Controls.Add(pnlFoter)
        pnlContenedor.Controls.Add(pnlContenido)
        pnlContenedor.Controls.Add(pnlEncabezado)
        pnlContenedor.Dock = DockStyle.Fill
        pnlContenedor.Location = New Point(0, 0)
        pnlContenedor.Name = "pnlContenedor"
        pnlContenedor.Size = New Size(1274, 626)
        pnlContenedor.TabIndex = 0
        ' 
        ' pnlFoter
        ' 
        pnlFoter.BackColor = Color.FromArgb(CByte(0), CByte(192), CByte(192))
        pnlFoter.Dock = DockStyle.Bottom
        pnlFoter.Location = New Point(0, 570)
        pnlFoter.Name = "pnlFoter"
        pnlFoter.Size = New Size(1274, 56)
        pnlFoter.TabIndex = 2
        ' 
        ' pnlContenido
        ' 
        pnlContenido.AutoScroll = True
        pnlContenido.Controls.Add(txtDireccion)
        pnlContenido.Controls.Add(TableLayoutPanel1)
        pnlContenido.Dock = DockStyle.Fill
        pnlContenido.Location = New Point(0, 60)
        pnlContenido.Margin = New Padding(3, 30, 3, 3)
        pnlContenido.Name = "pnlContenido"
        pnlContenido.Padding = New Padding(10, 30, 0, 0)
        pnlContenido.Size = New Size(1274, 566)
        pnlContenido.TabIndex = 1
        ' 
        ' txtDireccion
        ' 
        txtDireccion.AlturaMultilinea = 41
        txtDireccion.BackColor = Color.Transparent
        txtDireccion.BorderColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtDireccion.BorderRadius = 8
        txtDireccion.BorderSize = 1
        txtDireccion.CampoRequerido = True
        txtDireccion.CapitalizarTexto = True
        txtDireccion.CapitalizarTodasLasPalabras = True
        txtDireccion.ColorError = Color.Firebrick
        txtDireccion.FontField = New Font("Century Gothic", 12F)
        txtDireccion.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtDireccion.IconoDerechoChar = FontAwesome.Sharp.IconChar.Building
        txtDireccion.LabelColor = Color.DarkSlateGray
        txtDireccion.LabelText = "Domicilio Fiscal:"
        txtDireccion.Location = New Point(15, 200)
        txtDireccion.MensajeError = "Este campo es obligatorio."
        txtDireccion.Multilinea = False
        txtDireccion.Name = "txtDireccion"
        txtDireccion.PaddingAll = 10
        txtDireccion.PanelBackColor = Color.White
        txtDireccion.Size = New Size(1238, 86)
        txtDireccion.TabIndex = 7
        txtDireccion.TextColor = Color.Black
        txtDireccion.TextoUsuario = ""
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 3
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.33333F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333359F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333359F))
        TableLayoutPanel1.Controls.Add(txtNombreEmpresa, 0, 0)
        TableLayoutPanel1.Controls.Add(txtRazonSocial, 1, 0)
        TableLayoutPanel1.Controls.Add(txtCorreo, 2, 0)
        TableLayoutPanel1.Controls.Add(txtTelefono, 1, 1)
        TableLayoutPanel1.Controls.Add(txtContacto, 2, 1)
        TableLayoutPanel1.Controls.Add(Panel1, 0, 1)
        TableLayoutPanel1.Location = New Point(12, 11)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 2
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 90F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 90F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel1.Size = New Size(1250, 183)
        TableLayoutPanel1.TabIndex = 26
        ' 
        ' txtNombreEmpresa
        ' 
        txtNombreEmpresa.BackColor = Color.Transparent
        txtNombreEmpresa.BorderColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtNombreEmpresa.BorderRadius = 8
        txtNombreEmpresa.BorderSize = 1
        txtNombreEmpresa.CampoRequerido = True
        txtNombreEmpresa.CapitalizarTexto = True
        txtNombreEmpresa.CapitalizarTodasLasPalabras = True
        txtNombreEmpresa.CaracterContraseña = "*"c
        txtNombreEmpresa.ColorError = Color.Firebrick
        txtNombreEmpresa.FontField = New Font("Century Gothic", 12F)
        txtNombreEmpresa.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtNombreEmpresa.IconoDerechoChar = FontAwesome.Sharp.IconChar.Vcard
        txtNombreEmpresa.LabelColor = Color.DarkSlateGray
        txtNombreEmpresa.LabelText = "Nombre de Empresa:"
        txtNombreEmpresa.Location = New Point(3, 3)
        txtNombreEmpresa.MensajeError = "Este campo es obligatorio."
        txtNombreEmpresa.Name = "txtNombreEmpresa"
        txtNombreEmpresa.PaddingAll = 10
        txtNombreEmpresa.PanelBackColor = Color.White
        txtNombreEmpresa.Size = New Size(407, 80)
        txtNombreEmpresa.SombraBackColor = Color.LightGray
        txtNombreEmpresa.TabIndex = 0
        txtNombreEmpresa.TextColor = Color.Black
        txtNombreEmpresa.TextoUsuario = ""
        txtNombreEmpresa.UsarModoContraseña = False
        txtNombreEmpresa.ValidarComoCorreo = False
        ' 
        ' txtRazonSocial
        ' 
        txtRazonSocial.BackColor = Color.Transparent
        txtRazonSocial.BorderColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtRazonSocial.BorderRadius = 8
        txtRazonSocial.BorderSize = 1
        txtRazonSocial.CampoRequerido = True
        txtRazonSocial.CapitalizarTexto = True
        txtRazonSocial.CapitalizarTodasLasPalabras = True
        txtRazonSocial.CaracterContraseña = "*"c
        txtRazonSocial.ColorError = Color.Firebrick
        txtRazonSocial.FontField = New Font("Century Gothic", 12F)
        txtRazonSocial.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtRazonSocial.IconoDerechoChar = FontAwesome.Sharp.IconChar.Vcard
        txtRazonSocial.LabelColor = Color.DarkSlateGray
        txtRazonSocial.LabelText = "Razón Social:"
        txtRazonSocial.Location = New Point(419, 3)
        txtRazonSocial.MensajeError = "Este campo es obligatorio."
        txtRazonSocial.Name = "txtRazonSocial"
        txtRazonSocial.PaddingAll = 10
        txtRazonSocial.PanelBackColor = Color.White
        txtRazonSocial.Size = New Size(406, 80)
        txtRazonSocial.SombraBackColor = Color.LightGray
        txtRazonSocial.TabIndex = 1
        txtRazonSocial.TextColor = Color.Black
        txtRazonSocial.TextoUsuario = ""
        txtRazonSocial.UsarModoContraseña = False
        txtRazonSocial.ValidarComoCorreo = False
        ' 
        ' txtCorreo
        ' 
        txtCorreo.BackColor = Color.Transparent
        txtCorreo.BorderColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtCorreo.BorderRadius = 8
        txtCorreo.BorderSize = 1
        txtCorreo.CampoRequerido = False
        txtCorreo.CapitalizarTexto = False
        txtCorreo.CapitalizarTodasLasPalabras = True
        txtCorreo.CaracterContraseña = "*"c
        txtCorreo.ColorError = Color.Firebrick
        txtCorreo.FontField = New Font("Century Gothic", 12F)
        txtCorreo.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtCorreo.IconoDerechoChar = FontAwesome.Sharp.IconChar.EnvelopesBulk
        txtCorreo.LabelColor = Color.DarkSlateGray
        txtCorreo.LabelText = "Correo electrónico:"
        txtCorreo.Location = New Point(835, 3)
        txtCorreo.MensajeError = "Este campo es obligatorio."
        txtCorreo.Name = "txtCorreo"
        txtCorreo.PaddingAll = 10
        txtCorreo.PanelBackColor = Color.White
        txtCorreo.Size = New Size(405, 80)
        txtCorreo.SombraBackColor = Color.LightGray
        txtCorreo.TabIndex = 2
        txtCorreo.TextColor = Color.Black
        txtCorreo.TextoUsuario = ""
        txtCorreo.UsarModoContraseña = False
        txtCorreo.ValidarComoCorreo = True
        ' 
        ' txtTelefono
        ' 
        txtTelefono.BackColor = Color.Transparent
        txtTelefono.BorderColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtTelefono.BorderRadius = 8
        txtTelefono.BorderSize = 1
        txtTelefono.CampoRequerido = True
        txtTelefono.ColorError = Color.Firebrick
        txtTelefono.FontField = New Font("Century Gothic", 12F)
        txtTelefono.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtTelefono.IconoDerechoChar = FontAwesome.Sharp.IconChar.PhoneVolume
        txtTelefono.LabelColor = Color.DarkSlateGray
        txtTelefono.LabelText = "Número de Teléfono:"
        txtTelefono.Location = New Point(419, 93)
        txtTelefono.MascaraPersonalizada = ""
        txtTelefono.MaxCaracteres = 0
        txtTelefono.MensajeError = "Este campo es obligatorio."
        txtTelefono.Name = "txtTelefono"
        txtTelefono.PaddingAll = 10
        txtTelefono.PanelBackColor = Color.White
        txtTelefono.SelectionStart = 0
        txtTelefono.Size = New Size(406, 80)
        txtTelefono.SombraBackColor = Color.LightGray
        txtTelefono.TabIndex = 5
        txtTelefono.TextColor = Color.Black
        txtTelefono.TextoUsuario = ""
        txtTelefono.TipoNumerico = MaskedTextBoxLabelUI.TipoEntradaNumerica.Ninguno
        ' 
        ' txtContacto
        ' 
        txtContacto.BackColor = Color.Transparent
        txtContacto.BorderColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtContacto.BorderRadius = 8
        txtContacto.BorderSize = 1
        txtContacto.CampoRequerido = True
        txtContacto.ColorError = Color.Firebrick
        txtContacto.FontField = New Font("Century Gothic", 12F)
        txtContacto.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtContacto.IconoDerechoChar = FontAwesome.Sharp.IconChar.Close
        txtContacto.LabelColor = Color.DarkSlateGray
        txtContacto.LabelText = "Teléfono Contacto Cel:"
        txtContacto.Location = New Point(835, 93)
        txtContacto.MascaraPersonalizada = ""
        txtContacto.MaxCaracteres = 0
        txtContacto.MensajeError = "Este campo es obligatorio."
        txtContacto.Name = "txtContacto"
        txtContacto.PaddingAll = 10
        txtContacto.PanelBackColor = Color.White
        txtContacto.SelectionStart = 0
        txtContacto.Size = New Size(406, 80)
        txtContacto.SombraBackColor = Color.LightGray
        txtContacto.TabIndex = 6
        txtContacto.TextColor = Color.Black
        txtContacto.TextoUsuario = ""
        txtContacto.TipoNumerico = MaskedTextBoxLabelUI.TipoEntradaNumerica.Ninguno
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(txtRif)
        Panel1.Controls.Add(cmbSiglas)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(3, 93)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(410, 87)
        Panel1.TabIndex = 6
        ' 
        ' txtRif
        ' 
        txtRif.BackColor = Color.Transparent
        txtRif.BorderColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtRif.BorderRadius = 8
        txtRif.BorderSize = 1
        txtRif.CampoRequerido = True
        txtRif.ColorError = Color.Firebrick
        txtRif.FontField = New Font("Century Gothic", 12F)
        txtRif.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtRif.IconoDerechoChar = FontAwesome.Sharp.IconChar.ContactBook
        txtRif.LabelColor = Color.DarkSlateGray
        txtRif.LabelText = "Rif / C.I."
        txtRif.Location = New Point(66, 0)
        txtRif.MascaraPersonalizada = ""
        txtRif.MaxCaracteres = 0
        txtRif.MensajeError = "Este campo es obligatorio."
        txtRif.Name = "txtRif"
        txtRif.PaddingAll = 10
        txtRif.PanelBackColor = Color.White
        txtRif.SelectionStart = 0
        txtRif.Size = New Size(341, 80)
        txtRif.SombraBackColor = Color.LightGray
        txtRif.TabIndex = 4
        txtRif.TextColor = Color.Black
        txtRif.TextoUsuario = ""
        txtRif.TipoNumerico = MaskedTextBoxLabelUI.TipoEntradaNumerica.Ninguno
        ' 
        ' cmbSiglas
        ' 
        cmbSiglas.BackColor = Color.Transparent
        cmbSiglas.BackColorPnl = Color.WhiteSmoke
        cmbSiglas.BorderColor = Color.LightGray
        cmbSiglas.BorderSize = 1
        cmbSiglas.CampoRequerido = True
        cmbSiglas.ForeColor = Color.Black
        cmbSiglas.IndiceSeleccionado = -1
        cmbSiglas.LabelColor = Color.DarkSlateGray
        cmbSiglas.Location = New Point(3, -1)
        cmbSiglas.MensajeError = "Este campo es obligatorio."
        cmbSiglas.MostrarError = False
        cmbSiglas.Name = "cmbSiglas"
        cmbSiglas.RadioContornoPanel = 8
        cmbSiglas.Size = New Size(57, 80)
        cmbSiglas.SombraBackColor = Color.LightGray
        cmbSiglas.TabIndex = 3
        cmbSiglas.Titulo = "Siglas"
        cmbSiglas.ValorSeleccionado = Nothing
        ' 
        ' pnlEncabezado
        ' 
        pnlEncabezado.Controls.Add(btnAccion)
        pnlEncabezado.Controls.Add(lblEncabezado)
        pnlEncabezado.Dock = DockStyle.Top
        pnlEncabezado.Location = New Point(0, 0)
        pnlEncabezado.Name = "pnlEncabezado"
        pnlEncabezado.Size = New Size(1274, 60)
        pnlEncabezado.TabIndex = 0
        ' 
        ' btnAccion
        ' 
        btnAccion.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnAccion.AnimarHover = True
        btnAccion.BackColor = Color.FromArgb(CByte(0), CByte(192), CByte(192))
        btnAccion.ColorBase = Color.FromArgb(CByte(255), CByte(193), CByte(7))
        btnAccion.ColorHover = Color.FromArgb(CByte(255), CByte(179), CByte(0))
        btnAccion.ColorInternoFondo = Color.FromArgb(CByte(255), CByte(193), CByte(7))
        btnAccion.ColorPresionado = Color.FromArgb(CByte(255), CByte(160), CByte(0))
        btnAccion.ColorTexto = Color.Black
        btnAccion.EstiloBoton = CommandButtonUI.EstiloBootstrap.Warning
        btnAccion.Font = New Font("Century Gothic", 10F, FontStyle.Bold)
        btnAccion.Icono = FontAwesome.Sharp.IconChar.Warning
        btnAccion.Location = New Point(1084, 12)
        btnAccion.Name = "btnAccion"
        btnAccion.RadioBorde = 8
        btnAccion.Size = New Size(180, 40)
        btnAccion.TabIndex = 7
        btnAccion.Text = "CommandButtonui2"
        btnAccion.Texto = "Guardar Datos"
        ' 
        ' lblEncabezado
        ' 
        lblEncabezado.BackColor = Color.WhiteSmoke
        lblEncabezado.ColorFondo = Color.FromArgb(CByte(0), CByte(192), CByte(192))
        lblEncabezado.ColorTexto = Color.WhiteSmoke
        lblEncabezado.Dock = DockStyle.Top
        lblEncabezado.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblEncabezado.Icono = FontAwesome.Sharp.IconChar.UserPlus
        lblEncabezado.Location = New Point(0, 0)
        lblEncabezado.MostrarSeparador = True
        lblEncabezado.Name = "lblEncabezado"
        lblEncabezado.Size = New Size(1274, 60)
        lblEncabezado.Subtitulo = "Subtítulo opcional"
        lblEncabezado.TabIndex = 0
        lblEncabezado.Text = "Headerui1"
        lblEncabezado.Titulo = "Título Principal"
        ' 
        ' frmProveedor
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1274, 626)
        Controls.Add(pnlContenedor)
        Name = "frmProveedor"
        Text = "frmProveedor"
        WindowState = FormWindowState.Maximized
        pnlContenedor.ResumeLayout(False)
        pnlContenido.ResumeLayout(False)
        TableLayoutPanel1.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        pnlEncabezado.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents pnlContenedor As Panel
    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents lblEncabezado As HeaderUI
    Friend WithEvents btnAccion As CommandButtonUI
    Friend WithEvents pnlContenido As Panel
    Friend WithEvents txtDireccion As MultilineTextBoxLabelUI
    Friend WithEvents txtTelefono As MaskedTextBoxLabelUI
    Friend WithEvents txtCorreo As TextBoxLabelUI
    Friend WithEvents txtRazonSocial As TextBoxLabelUI
    Friend WithEvents txtNombreEmpresa As TextBoxLabelUI
    Friend WithEvents txtRif As MaskedTextBoxLabelUI
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents txtContacto As MaskedTextBoxLabelUI
    Friend WithEvents pnlFoter As Panel
    Friend WithEvents cmbSiglas As ComboBoxLabelUI
    Friend WithEvents Panel1 As Panel

End Class
