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
        TableLayoutPanel2 = New TableLayoutPanel()
        txtNombreEmpresa = New TextOnlyTextBoxLabelUI()
        txtRazonSocial = New TextOnlyTextBoxLabelUI()
        txtCorreo = New EmailTextBoxLabelUI()
        Panel2 = New Panel()
        Panel4 = New Panel()
        txtRif = New TextOnlyTextBoxLabelUI()
        Panel3 = New Panel()
        cmbSiglas = New ComboBoxLayoutUI()
        txtTelefono = New TextOnlyTextBoxLabelUI()
        txtContacto = New TextOnlyTextBoxLabelUI()
        Panelui1 = New PanelUI()
        pnlEncabezado = New Panel()
        btnAccion = New CommandButtonUI()
        lblEncabezado = New HeaderUI()
        pnlContenedor.SuspendLayout()
        pnlContenido.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        Panel2.SuspendLayout()
        Panel4.SuspendLayout()
        Panel3.SuspendLayout()
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
        pnlFoter.BackColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
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
        pnlContenido.Controls.Add(TableLayoutPanel2)
        pnlContenido.Controls.Add(Panelui1)
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
        txtDireccion.AlturaMultilinea = 80
        txtDireccion.BackColor = Color.Transparent
        txtDireccion.BorderColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtDireccion.BorderRadius = 8
        txtDireccion.BorderSize = 1
        txtDireccion.CampoRequerido = True
        txtDireccion.CapitalizarTexto = True
        txtDireccion.CapitalizarTodasLasPalabras = True
        txtDireccion.ColorError = Color.Firebrick
        txtDireccion.FontField = New Font("Microsoft Sans Serif", 12F)
        txtDireccion.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtDireccion.IconoDerechoChar = FontAwesome.Sharp.IconChar.Building
        txtDireccion.LabelColor = Color.DarkSlateGray
        txtDireccion.LabelText = "Domicilio Fiscal:"
        txtDireccion.Location = New Point(13, 200)
        txtDireccion.MensajeError = "Este campo es obligatorio."
        txtDireccion.Multilinea = True
        txtDireccion.Name = "txtDireccion"
        txtDireccion.PaddingAll = 10
        txtDireccion.PanelBackColor = Color.White
        txtDireccion.Placeholder = "Escriba aquí..."
        txtDireccion.PlaceholderColor = Color.Gray
        txtDireccion.Size = New Size(1238, 128)
        txtDireccion.TabIndex = 7
        txtDireccion.TextColor = Color.Black
        txtDireccion.TextoString = Nothing
        txtDireccion.TextString = ""
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 3
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.33333F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333359F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333359F))
        TableLayoutPanel2.Controls.Add(txtNombreEmpresa, 0, 0)
        TableLayoutPanel2.Controls.Add(txtRazonSocial, 1, 0)
        TableLayoutPanel2.Controls.Add(txtCorreo, 2, 0)
        TableLayoutPanel2.Controls.Add(Panel2, 0, 1)
        TableLayoutPanel2.Controls.Add(txtTelefono, 1, 1)
        TableLayoutPanel2.Controls.Add(txtContacto, 2, 1)
        TableLayoutPanel2.Location = New Point(11, 11)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 2
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 90F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 90F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel2.Size = New Size(1238, 183)
        TableLayoutPanel2.TabIndex = 27
        ' 
        ' txtNombreEmpresa
        ' 
        txtNombreEmpresa.BackColor = Color.Transparent
        txtNombreEmpresa.CampoRequerido = True
        txtNombreEmpresa.CapitalizarTexto = False
        txtNombreEmpresa.CapitalizarTodasLasPalabras = False
        txtNombreEmpresa.ColorTitulo = Color.DarkSlateGray
        txtNombreEmpresa.Dock = DockStyle.Fill
        txtNombreEmpresa.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtNombreEmpresa.IconoDerechoChar = FontAwesome.Sharp.IconChar.ContactBook
        txtNombreEmpresa.Location = New Point(3, 3)
        txtNombreEmpresa.MaxCaracteres = 0
        txtNombreEmpresa.MensajeError = "Este campo es requerido"
        txtNombreEmpresa.MinCaracteres = 0
        txtNombreEmpresa.Name = "txtNombreEmpresa"
        txtNombreEmpresa.PaddingIzquierda = 8
        txtNombreEmpresa.PaddingIzquierdaIcono = 10
        txtNombreEmpresa.Placeholder = "Ingrese datos"
        txtNombreEmpresa.PlaceholderColor = Color.Gray
        txtNombreEmpresa.Size = New Size(406, 84)
        txtNombreEmpresa.TabIndex = 0
        txtNombreEmpresa.TextoLabel = "Nombre de la Empresa:"
        txtNombreEmpresa.TextString = ""
        txtNombreEmpresa.ValidarComoCorreo = False
        ' 
        ' txtRazonSocial
        ' 
        txtRazonSocial.BackColor = Color.Transparent
        txtRazonSocial.CampoRequerido = False
        txtRazonSocial.CapitalizarTexto = False
        txtRazonSocial.CapitalizarTodasLasPalabras = False
        txtRazonSocial.ColorTitulo = Color.DarkSlateGray
        txtRazonSocial.Dock = DockStyle.Fill
        txtRazonSocial.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtRazonSocial.IconoDerechoChar = FontAwesome.Sharp.IconChar.Tag
        txtRazonSocial.Location = New Point(415, 3)
        txtRazonSocial.MaxCaracteres = 0
        txtRazonSocial.MensajeError = "Este campo es requerido"
        txtRazonSocial.MinCaracteres = 0
        txtRazonSocial.Name = "txtRazonSocial"
        txtRazonSocial.PaddingIzquierda = 8
        txtRazonSocial.PaddingIzquierdaIcono = 10
        txtRazonSocial.Placeholder = "Ingrese datos"
        txtRazonSocial.PlaceholderColor = Color.Gray
        txtRazonSocial.Size = New Size(406, 84)
        txtRazonSocial.TabIndex = 1
        txtRazonSocial.TextoLabel = "Razon Social:"
        txtRazonSocial.TextString = ""
        txtRazonSocial.ValidarComoCorreo = False
        ' 
        ' txtCorreo
        ' 
        txtCorreo.BackColor = Color.Transparent
        txtCorreo.CampoRequerido = False
        txtCorreo.CapitalizarTexto = False
        txtCorreo.CapitalizarTodasLasPalabras = False
        txtCorreo.ColorTitulo = Color.DarkSlateGray
        txtCorreo.Dock = DockStyle.Fill
        txtCorreo.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtCorreo.IconoDerechoChar = FontAwesome.Sharp.IconChar.EnvelopesBulk
        txtCorreo.Location = New Point(827, 3)
        txtCorreo.MaxCaracteres = 0
        txtCorreo.MensajeError = "Este campo es requerido"
        txtCorreo.MinCaracteres = 0
        txtCorreo.Name = "txtCorreo"
        txtCorreo.PaddingIzquierda = 8
        txtCorreo.PaddingIzquierdaIcono = 10
        txtCorreo.Placeholder = "Escriba aquí..."
        txtCorreo.PlaceholderColor = Color.Gray
        txtCorreo.Size = New Size(408, 84)
        txtCorreo.TabIndex = 2
        txtCorreo.TextoLabel = "Correo electrónico:"
        txtCorreo.TextString = ""
        txtCorreo.ValidarComoCorreo = False
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(Panel4)
        Panel2.Controls.Add(Panel3)
        Panel2.Dock = DockStyle.Fill
        Panel2.Location = New Point(3, 93)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(406, 87)
        Panel2.TabIndex = 3
        ' 
        ' Panel4
        ' 
        Panel4.Controls.Add(txtRif)
        Panel4.Dock = DockStyle.Fill
        Panel4.Location = New Point(83, 0)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(323, 87)
        Panel4.TabIndex = 1
        ' 
        ' txtRif
        ' 
        txtRif.BackColor = Color.Transparent
        txtRif.CampoRequerido = False
        txtRif.CapitalizarTexto = False
        txtRif.CapitalizarTodasLasPalabras = False
        txtRif.ColorTitulo = Color.DarkSlateGray
        txtRif.Dock = DockStyle.Fill
        txtRif.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtRif.IconoDerechoChar = FontAwesome.Sharp.IconChar.SortNumericDownAlt
        txtRif.Location = New Point(0, 0)
        txtRif.MaxCaracteres = 0
        txtRif.MensajeError = "Este campo es requerido"
        txtRif.MinCaracteres = 0
        txtRif.Name = "txtRif"
        txtRif.PaddingIzquierda = 8
        txtRif.PaddingIzquierdaIcono = 10
        txtRif.Placeholder = "Ingrese datos"
        txtRif.PlaceholderColor = Color.Gray
        txtRif.Size = New Size(323, 87)
        txtRif.TabIndex = 1
        txtRif.TextoLabel = "Rif / C.I."
        txtRif.TextString = ""
        txtRif.ValidarComoCorreo = False
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(cmbSiglas)
        Panel3.Dock = DockStyle.Left
        Panel3.Location = New Point(0, 0)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(83, 87)
        Panel3.TabIndex = 0
        ' 
        ' cmbSiglas
        ' 
        cmbSiglas.BackColor = Color.Transparent
        cmbSiglas.CampoRequerido = False
        cmbSiglas.ColorTitulo = Color.DarkSlateGray
        cmbSiglas.Dock = DockStyle.Left
        cmbSiglas.IndiceSeleccionado = -1
        cmbSiglas.Location = New Point(0, 0)
        cmbSiglas.MensajeError = "Este campo es requerido"
        cmbSiglas.Name = "cmbSiglas"
        cmbSiglas.Placeholder = "Selecciones una Opcion..."
        cmbSiglas.PlaceholderColor = Color.Gray
        cmbSiglas.Size = New Size(80, 87)
        cmbSiglas.TabIndex = 0
        cmbSiglas.Texto = ""
        cmbSiglas.TextoLabel = "Siglas:"
        cmbSiglas.ValorSeleccionado = Nothing
        ' 
        ' txtTelefono
        ' 
        txtTelefono.BackColor = Color.Transparent
        txtTelefono.CampoRequerido = False
        txtTelefono.CapitalizarTexto = False
        txtTelefono.CapitalizarTodasLasPalabras = False
        txtTelefono.ColorTitulo = Color.DarkSlateGray
        txtTelefono.Dock = DockStyle.Fill
        txtTelefono.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtTelefono.IconoDerechoChar = FontAwesome.Sharp.IconChar.PhoneVolume
        txtTelefono.Location = New Point(415, 93)
        txtTelefono.MaxCaracteres = 0
        txtTelefono.MensajeError = "Este campo es requerido"
        txtTelefono.MinCaracteres = 0
        txtTelefono.Name = "txtTelefono"
        txtTelefono.PaddingIzquierda = 8
        txtTelefono.PaddingIzquierdaIcono = 10
        txtTelefono.Placeholder = "Ingrese datos"
        txtTelefono.PlaceholderColor = Color.Gray
        txtTelefono.Size = New Size(406, 87)
        txtTelefono.TabIndex = 4
        txtTelefono.TextoLabel = "Número de teléfono:"
        txtTelefono.TextString = ""
        txtTelefono.ValidarComoCorreo = False
        ' 
        ' txtContacto
        ' 
        txtContacto.BackColor = Color.Transparent
        txtContacto.CampoRequerido = False
        txtContacto.CapitalizarTexto = False
        txtContacto.CapitalizarTodasLasPalabras = False
        txtContacto.ColorTitulo = Color.DarkSlateGray
        txtContacto.Dock = DockStyle.Fill
        txtContacto.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtContacto.IconoDerechoChar = FontAwesome.Sharp.IconChar.MobileAlt
        txtContacto.Location = New Point(827, 93)
        txtContacto.MaxCaracteres = 0
        txtContacto.MensajeError = "Este campo es requerido"
        txtContacto.MinCaracteres = 0
        txtContacto.Name = "txtContacto"
        txtContacto.PaddingIzquierda = 8
        txtContacto.PaddingIzquierdaIcono = 10
        txtContacto.Placeholder = "Ingrese datos"
        txtContacto.PlaceholderColor = Color.Gray
        txtContacto.Size = New Size(408, 87)
        txtContacto.TabIndex = 5
        txtContacto.TextoLabel = "Teléfono contacto Cel:"
        txtContacto.TextString = ""
        txtContacto.ValidarComoCorreo = False
        ' 
        ' Panelui1
        ' 
        Panelui1.BackColor = Color.Transparent
        Panelui1.BackColorContenedor = Color.Transparent
        Panelui1.BorderColor = Color.Silver
        Panelui1.BorderRadius = 20
        Panelui1.BorderSize = 1
        Panelui1.CardBackColor = Color.White
        Panelui1.Estilo = PanelUI.EstiloCard.None
        Panelui1.Location = New Point(8, 7)
        Panelui1.Name = "Panelui1"
        Panelui1.ShadowColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        Panelui1.Size = New Size(1256, 497)
        Panelui1.TabIndex = 28
        Panelui1.Texto = ""
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
        btnAccion.ColorTexto = Color.WhiteSmoke
        btnAccion.EstiloBoton = CommandButtonUI.EstiloBootstrap.Warning
        btnAccion.Font = New Font("Microsoft Sans Serif", 10F, FontStyle.Bold)
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
        lblEncabezado.ColorFondo = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        lblEncabezado.ColorTexto = Color.WhiteSmoke
        lblEncabezado.Dimension = 12
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
        TableLayoutPanel2.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel4.ResumeLayout(False)
        Panel3.ResumeLayout(False)
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
    Friend WithEvents pnlFoter As Panel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Panelui1 As PanelUI
    Friend WithEvents txtNombreEmpresa As TextOnlyTextBoxLabelUI
    Friend WithEvents txtRazonSocial As TextOnlyTextBoxLabelUI
    Friend WithEvents txtCorreo As EmailTextBoxLabelUI
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtTelefono As TextOnlyTextBoxLabelUI
    Friend WithEvents txtContacto As TextOnlyTextBoxLabelUI
    Friend WithEvents Panel4 As Panel
    Friend WithEvents ComboBoxLayoutui2 As ComboBoxLayoutUI
    Friend WithEvents Panel3 As Panel
    Friend WithEvents cmbSiglas As ComboBoxLayoutUI
    Friend WithEvents txtRif As TextOnlyTextBoxLabelUI

End Class
