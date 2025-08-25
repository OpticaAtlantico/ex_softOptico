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
        pnlContenedor = New Panel()
        pnlContenido = New Panel()
        MaskedTextBoxLabelui2 = New MaskedTextBoxLabelUI()
        MaskedTextBoxLabelui1 = New MaskedTextBoxLabelUI()
        txtCedula = New MaskedTextBoxLabelUI()
        pnlIzquierda = New Panel()
        btnEliminarFoto = New FontAwesome.Sharp.IconButton()
        btnGuardarFoto = New FontAwesome.Sharp.IconButton()
        icoFoto = New FontAwesome.Sharp.IconPictureBox()
        pnlFooter = New Panel()
        btnSiguiente = New CommandButtonUI()
        pnlContenedor.SuspendLayout()
        pnlContenido.SuspendLayout()
        pnlIzquierda.SuspendLayout()
        CType(icoFoto, ComponentModel.ISupportInitialize).BeginInit()
        pnlFooter.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlContenedor
        ' 
        pnlContenedor.Controls.Add(pnlContenido)
        pnlContenedor.Controls.Add(pnlIzquierda)
        pnlContenedor.Controls.Add(pnlFooter)
        pnlContenedor.Dock = DockStyle.Fill
        pnlContenedor.Location = New Point(0, 0)
        pnlContenedor.Name = "pnlContenedor"
        pnlContenedor.Size = New Size(1000, 500)
        pnlContenedor.TabIndex = 2
        ' 
        ' pnlContenido
        ' 
        pnlContenido.BackColor = Color.White
        pnlContenido.Controls.Add(MaskedTextBoxLabelui2)
        pnlContenido.Controls.Add(MaskedTextBoxLabelui1)
        pnlContenido.Controls.Add(txtCedula)
        pnlContenido.Dock = DockStyle.Fill
        pnlContenido.Location = New Point(324, 0)
        pnlContenido.Name = "pnlContenido"
        pnlContenido.Padding = New Padding(15)
        pnlContenido.Size = New Size(676, 439)
        pnlContenido.TabIndex = 3
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
        MaskedTextBoxLabelui2.LabelText = "#Cédula:"
        MaskedTextBoxLabelui2.Location = New Point(18, 190)
        MaskedTextBoxLabelui2.MascaraPersonalizada = ""
        MaskedTextBoxLabelui2.MaxCaracteres = 8
        MaskedTextBoxLabelui2.MensajeError = "Este campo es obligatorio."
        MaskedTextBoxLabelui2.Name = "MaskedTextBoxLabelui2"
        MaskedTextBoxLabelui2.PaddingAll = 10
        MaskedTextBoxLabelui2.PanelBackColor = Color.White
        MaskedTextBoxLabelui2.SelectionStart = 0
        MaskedTextBoxLabelui2.Size = New Size(343, 80)
        MaskedTextBoxLabelui2.SombraBackColor = Color.LightGray
        MaskedTextBoxLabelui2.TabIndex = 4
        MaskedTextBoxLabelui2.TextColor = Color.Black
        MaskedTextBoxLabelui2.TextoUsuario = ""
        MaskedTextBoxLabelui2.TipoNumerico = MaskedTextBoxLabelUI.TipoEntradaNumerica.Entero
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
        MaskedTextBoxLabelui1.Location = New Point(18, 104)
        MaskedTextBoxLabelui1.MascaraPersonalizada = ""
        MaskedTextBoxLabelui1.MaxCaracteres = 8
        MaskedTextBoxLabelui1.MensajeError = "Este campo es obligatorio."
        MaskedTextBoxLabelui1.Name = "MaskedTextBoxLabelui1"
        MaskedTextBoxLabelui1.PaddingAll = 10
        MaskedTextBoxLabelui1.PanelBackColor = Color.White
        MaskedTextBoxLabelui1.SelectionStart = 0
        MaskedTextBoxLabelui1.Size = New Size(343, 80)
        MaskedTextBoxLabelui1.SombraBackColor = Color.LightGray
        MaskedTextBoxLabelui1.TabIndex = 3
        MaskedTextBoxLabelui1.TextColor = Color.Black
        MaskedTextBoxLabelui1.TextoUsuario = ""
        MaskedTextBoxLabelui1.TipoNumerico = MaskedTextBoxLabelUI.TipoEntradaNumerica.Entero
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
        txtCedula.Location = New Point(18, 18)
        txtCedula.MascaraPersonalizada = ""
        txtCedula.MaxCaracteres = 8
        txtCedula.MensajeError = "Este campo es obligatorio."
        txtCedula.Name = "txtCedula"
        txtCedula.PaddingAll = 10
        txtCedula.PanelBackColor = Color.White
        txtCedula.SelectionStart = 0
        txtCedula.Size = New Size(343, 80)
        txtCedula.SombraBackColor = Color.LightGray
        txtCedula.TabIndex = 2
        txtCedula.TextColor = Color.Black
        txtCedula.TextoUsuario = ""
        txtCedula.TipoNumerico = MaskedTextBoxLabelUI.TipoEntradaNumerica.Entero
        ' 
        ' pnlIzquierda
        ' 
        pnlIzquierda.BackColor = Color.White
        pnlIzquierda.Controls.Add(btnEliminarFoto)
        pnlIzquierda.Controls.Add(btnGuardarFoto)
        pnlIzquierda.Controls.Add(icoFoto)
        pnlIzquierda.Dock = DockStyle.Left
        pnlIzquierda.Location = New Point(0, 0)
        pnlIzquierda.Name = "pnlIzquierda"
        pnlIzquierda.Padding = New Padding(15)
        pnlIzquierda.Size = New Size(324, 439)
        pnlIzquierda.TabIndex = 2
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
        btnEliminarFoto.Location = New Point(166, 329)
        btnEliminarFoto.Name = "btnEliminarFoto"
        btnEliminarFoto.Size = New Size(68, 57)
        btnEliminarFoto.TabIndex = 25
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
        btnGuardarFoto.Location = New Point(82, 329)
        btnGuardarFoto.Name = "btnGuardarFoto"
        btnGuardarFoto.Size = New Size(68, 57)
        btnGuardarFoto.TabIndex = 24
        btnGuardarFoto.Text = "Agregar"
        btnGuardarFoto.TextImageRelation = TextImageRelation.ImageAboveText
        btnGuardarFoto.UseVisualStyleBackColor = True
        ' 
        ' icoFoto
        ' 
        icoFoto.BackColor = Color.White
        icoFoto.BorderStyle = BorderStyle.FixedSingle
        icoFoto.ForeColor = SystemColors.ControlDark
        icoFoto.IconChar = FontAwesome.Sharp.IconChar.Neuter
        icoFoto.IconColor = SystemColors.ControlDark
        icoFoto.IconFont = FontAwesome.Sharp.IconFont.Auto
        icoFoto.IconSize = 288
        icoFoto.Location = New Point(18, 18)
        icoFoto.Name = "icoFoto"
        icoFoto.Size = New Size(288, 296)
        icoFoto.TabIndex = 0
        icoFoto.TabStop = False
        ' 
        ' pnlFooter
        ' 
        pnlFooter.Controls.Add(btnSiguiente)
        pnlFooter.Dock = DockStyle.Bottom
        pnlFooter.Location = New Point(0, 439)
        pnlFooter.Name = "pnlFooter"
        pnlFooter.Size = New Size(1000, 61)
        pnlFooter.TabIndex = 1
        ' 
        ' btnSiguiente
        ' 
        btnSiguiente.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnSiguiente.AnimarHover = True
        btnSiguiente.BackColor = Color.Transparent
        btnSiguiente.ColorBase = Color.FromArgb(CByte(33), CByte(150), CByte(243))
        btnSiguiente.ColorHover = Color.FromArgb(CByte(30), CByte(136), CByte(229))
        btnSiguiente.ColorInternoFondo = Color.FromArgb(CByte(33), CByte(150), CByte(243))
        btnSiguiente.ColorPresionado = Color.FromArgb(CByte(25), CByte(118), CByte(210))
        btnSiguiente.ColorTexto = Color.White
        btnSiguiente.EstiloBoton = CommandButtonUI.EstiloBootstrap.Primary
        btnSiguiente.Font = New Font("Century Gothic", 10F, FontStyle.Bold)
        btnSiguiente.Icono = FontAwesome.Sharp.IconChar.Bolt
        btnSiguiente.Location = New Point(748, 8)
        btnSiguiente.Name = "btnSiguiente"
        btnSiguiente.RadioBorde = 8
        btnSiguiente.Size = New Size(238, 42)
        btnSiguiente.TabIndex = 0
        btnSiguiente.Text = "CommandButtonui1"
        btnSiguiente.Texto = "Aceptar"
        ' 
        ' ucProductos
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(pnlContenedor)
        Name = "ucProductos"
        Size = New Size(1000, 500)
        pnlContenedor.ResumeLayout(False)
        pnlContenido.ResumeLayout(False)
        pnlIzquierda.ResumeLayout(False)
        CType(icoFoto, ComponentModel.ISupportInitialize).EndInit()
        pnlFooter.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents pnlContenedor As Panel
    Friend WithEvents pnlIzquierda As Panel
    Friend WithEvents pnlFooter As Panel
    Friend WithEvents btnSiguiente As CommandButtonUI
    Friend WithEvents pnlContenido As Panel
    Friend WithEvents icoFoto As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents btnEliminarFoto As FontAwesome.Sharp.IconButton
    Friend WithEvents btnGuardarFoto As FontAwesome.Sharp.IconButton
    Friend WithEvents MaskedTextBoxLabelui2 As MaskedTextBoxLabelUI
    Friend WithEvents MaskedTextBoxLabelui1 As MaskedTextBoxLabelUI
    Friend WithEvents txtCedula As MaskedTextBoxLabelUI

End Class
