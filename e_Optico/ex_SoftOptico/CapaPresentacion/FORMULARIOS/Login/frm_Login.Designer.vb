<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Login
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Login))
        pnlContenido = New Panel()
        btnOlvidePass = New ButtonLinkUI()
        btnAceptar = New CommandButtonUI()
        btnSalir = New FontAwesome.Sharp.IconButton()
        btnMinimizar = New FontAwesome.Sharp.IconButton()
        txtPass = New TextBoxLabelUI()
        txtUsuario = New TextBoxLabelUI()
        TextOnlyTextBoxLabelui1 = New TextOnlyTextBoxLabelUI()
        PasswordTextBoxLabelui1 = New PasswordTextBoxLabelUI()
        Comboui1 = New ComboUI()
        pnlContenido.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlContenido
        ' 
        pnlContenido.BackgroundImage = CType(resources.GetObject("pnlContenido.BackgroundImage"), Image)
        pnlContenido.Controls.Add(Comboui1)
        pnlContenido.Controls.Add(PasswordTextBoxLabelui1)
        pnlContenido.Controls.Add(TextOnlyTextBoxLabelui1)
        pnlContenido.Controls.Add(btnOlvidePass)
        pnlContenido.Controls.Add(btnAceptar)
        pnlContenido.Controls.Add(btnSalir)
        pnlContenido.Controls.Add(btnMinimizar)
        pnlContenido.Controls.Add(txtPass)
        pnlContenido.Controls.Add(txtUsuario)
        pnlContenido.Dock = DockStyle.Fill
        pnlContenido.Location = New Point(0, 0)
        pnlContenido.Name = "pnlContenido"
        pnlContenido.Size = New Size(906, 555)
        pnlContenido.TabIndex = 0
        ' 
        ' btnOlvidePass
        ' 
        btnOlvidePass.ActiveColor = Color.RoyalBlue
        btnOlvidePass.BackColor = Color.Transparent
        btnOlvidePass.Font = New Font("Tahoma", 6F)
        btnOlvidePass.HoverColor = Color.DodgerBlue
        btnOlvidePass.LinkText = "Olvide mi contraseña"
        btnOlvidePass.Location = New Point(634, 421)
        btnOlvidePass.Margin = New Padding(2)
        btnOlvidePass.Name = "btnOlvidePass"
        btnOlvidePass.NormalColor = Color.Green
        btnOlvidePass.Size = New Size(166, 24)
        btnOlvidePass.SubrayarAlPasar = True
        btnOlvidePass.TabIndex = 4
        ' 
        ' btnAceptar
        ' 
        btnAceptar.AnimarHover = True
        btnAceptar.BackColor = Color.Transparent
        btnAceptar.ColorBase = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        btnAceptar.ColorHover = Color.FromArgb(CByte(67), CByte(160), CByte(71))
        btnAceptar.ColorInternoFondo = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        btnAceptar.ColorPresionado = Color.FromArgb(CByte(56), CByte(142), CByte(60))
        btnAceptar.ColorTexto = Color.WhiteSmoke
        btnAceptar.EstiloBoton = CommandButtonUI.EstiloBootstrap.Success
        btnAceptar.Font = New Font("Century Gothic", 10F, FontStyle.Bold)
        btnAceptar.Icono = FontAwesome.Sharp.IconChar.CheckCircle
        btnAceptar.Location = New Point(583, 464)
        btnAceptar.Name = "btnAceptar"
        btnAceptar.RadioBorde = 12
        btnAceptar.Size = New Size(266, 42)
        btnAceptar.TabIndex = 2
        btnAceptar.Text = "CommandButtonui1"
        btnAceptar.Texto = "Aceptar"
        ' 
        ' btnSalir
        ' 
        btnSalir.FlatAppearance.BorderSize = 0
        btnSalir.FlatStyle = FlatStyle.Flat
        btnSalir.IconChar = FontAwesome.Sharp.IconChar.X
        btnSalir.IconColor = Color.DimGray
        btnSalir.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnSalir.IconSize = 30
        btnSalir.Location = New Point(858, 10)
        btnSalir.Name = "btnSalir"
        btnSalir.Size = New Size(23, 25)
        btnSalir.TabIndex = 2
        btnSalir.UseVisualStyleBackColor = True
        ' 
        ' btnMinimizar
        ' 
        btnMinimizar.FlatAppearance.BorderSize = 0
        btnMinimizar.FlatStyle = FlatStyle.Flat
        btnMinimizar.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize
        btnMinimizar.IconColor = Color.DimGray
        btnMinimizar.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnMinimizar.IconSize = 30
        btnMinimizar.Location = New Point(829, 10)
        btnMinimizar.Name = "btnMinimizar"
        btnMinimizar.Size = New Size(23, 25)
        btnMinimizar.TabIndex = 2
        btnMinimizar.UseVisualStyleBackColor = True
        ' 
        ' txtPass
        ' 
        txtPass.BackColor = Color.Transparent
        txtPass.BorderColor = Color.LightGray
        txtPass.BorderRadius = 5
        txtPass.BorderSize = 1
        txtPass.CampoRequerido = True
        txtPass.CapitalizarTexto = False
        txtPass.CapitalizarTodasLasPalabras = True
        txtPass.CaracterContraseña = "*"c
        txtPass.ColorError = Color.Firebrick
        txtPass.FontField = New Font("Century Gothic", 12F)
        txtPass.IconoColor = Color.White
        txtPass.IconoDerechoChar = FontAwesome.Sharp.IconChar.Fingerprint
        txtPass.LabelColor = Color.WhiteSmoke
        txtPass.LabelText = "Contraseña"
        txtPass.Location = New Point(231, 189)
        txtPass.MensajeError = "La contraseña no puede quedar vacia..."
        txtPass.Name = "txtPass"
        txtPass.PaddingAll = 10
        txtPass.PanelBackColor = Color.FromArgb(CByte(80), CByte(94), CByte(129))
        txtPass.Size = New Size(302, 78)
        txtPass.SombraBackColor = Color.Transparent
        txtPass.TabIndex = 1
        txtPass.TextColor = Color.WhiteSmoke
        txtPass.TextoUsuario = ""
        txtPass.UsarModoContraseña = True
        txtPass.ValidarComoCorreo = False
        ' 
        ' txtUsuario
        ' 
        txtUsuario.BackColor = Color.Transparent
        txtUsuario.BorderColor = Color.LightGray
        txtUsuario.BorderRadius = 5
        txtUsuario.BorderSize = 1
        txtUsuario.CampoRequerido = True
        txtUsuario.CapitalizarTexto = False
        txtUsuario.CapitalizarTodasLasPalabras = True
        txtUsuario.CaracterContraseña = "*"c
        txtUsuario.ColorError = Color.Firebrick
        txtUsuario.FontField = New Font("Century Gothic", 12F)
        txtUsuario.ForeColor = SystemColors.ControlText
        txtUsuario.IconoColor = Color.White
        txtUsuario.IconoDerechoChar = FontAwesome.Sharp.IconChar.UserCheck
        txtUsuario.LabelColor = Color.WhiteSmoke
        txtUsuario.LabelText = "Usuario"
        txtUsuario.Location = New Point(231, 67)
        txtUsuario.MensajeError = "Usuario desconocido..."
        txtUsuario.Name = "txtUsuario"
        txtUsuario.PaddingAll = 10
        txtUsuario.PanelBackColor = Color.FromArgb(CByte(80), CByte(94), CByte(129))
        txtUsuario.Size = New Size(302, 76)
        txtUsuario.SombraBackColor = Color.Transparent
        txtUsuario.TabIndex = 0
        txtUsuario.TextColor = Color.WhiteSmoke
        txtUsuario.TextoUsuario = ""
        txtUsuario.UsarModoContraseña = False
        txtUsuario.ValidarComoCorreo = False
        ' 
        ' TextOnlyTextBoxLabelui1
        ' 
        TextOnlyTextBoxLabelui1.BackColor = Color.Transparent
        TextOnlyTextBoxLabelui1.CampoRequerido = False
        TextOnlyTextBoxLabelui1.CapitalizarTexto = False
        TextOnlyTextBoxLabelui1.CapitalizarTodasLasPalabras = False
        TextOnlyTextBoxLabelui1.ColorTitulo = Color.DarkSlateGray
        TextOnlyTextBoxLabelui1.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        TextOnlyTextBoxLabelui1.IconoDerechoChar = FontAwesome.Sharp.IconChar.UserCheck
        TextOnlyTextBoxLabelui1.Location = New Point(559, 142)
        TextOnlyTextBoxLabelui1.MaxCaracteres = 0
        TextOnlyTextBoxLabelui1.MensajeError = "Campo requerido"
        TextOnlyTextBoxLabelui1.Name = "TextOnlyTextBoxLabelui1"
        TextOnlyTextBoxLabelui1.PaddingIzquierda = 8
        TextOnlyTextBoxLabelui1.PaddingIzquierdaIcono = 10
        TextOnlyTextBoxLabelui1.Placeholder = "Ingrese datos"
        TextOnlyTextBoxLabelui1.PlaceholderColor = Color.Gray
        TextOnlyTextBoxLabelui1.Size = New Size(308, 74)
        TextOnlyTextBoxLabelui1.TabIndex = 5
        TextOnlyTextBoxLabelui1.TextoLabel = "Usuario:"
        ' 
        ' PasswordTextBoxLabelui1
        ' 
        PasswordTextBoxLabelui1.BackColor = Color.Transparent
        PasswordTextBoxLabelui1.CampoRequerido = False
        PasswordTextBoxLabelui1.CapitalizarTexto = False
        PasswordTextBoxLabelui1.CapitalizarTodasLasPalabras = False
        PasswordTextBoxLabelui1.ColorTitulo = Color.DarkSlateGray
        PasswordTextBoxLabelui1.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        PasswordTextBoxLabelui1.IconoDerechoChar = FontAwesome.Sharp.IconChar.Fingerprint
        PasswordTextBoxLabelui1.Location = New Point(558, 218)
        PasswordTextBoxLabelui1.MaxCaracteres = 0
        PasswordTextBoxLabelui1.MensajeError = "Campo requerido"
        PasswordTextBoxLabelui1.Name = "PasswordTextBoxLabelui1"
        PasswordTextBoxLabelui1.PaddingIzquierda = 8
        PasswordTextBoxLabelui1.PaddingIzquierdaIcono = 10
        PasswordTextBoxLabelui1.Placeholder = "Ingrese contraseña"
        PasswordTextBoxLabelui1.PlaceholderColor = Color.Gray
        PasswordTextBoxLabelui1.Size = New Size(309, 72)
        PasswordTextBoxLabelui1.TabIndex = 6
        PasswordTextBoxLabelui1.TextoLabel = "Contraseña:"
        ' 
        ' Comboui1
        ' 
        Comboui1.BackColor = Color.Transparent
        Comboui1.CampoRequerido = False
        Comboui1.ColorTitulo = Color.DarkSlateGray
        Comboui1.Location = New Point(559, 296)
        Comboui1.MensajeError = "Este campo es requerido"
        Comboui1.MostrarError = False
        Comboui1.Name = "Comboui1"
        Comboui1.Placeholder = "Selecciones una Opcion..."
        Comboui1.PlaceholderColor = Color.Gray
        Comboui1.Size = New Size(308, 76)
        Comboui1.TabIndex = 7
        Comboui1.TextoLabel = "Local:"
        ' 
        ' frm_Login
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(906, 555)
        Controls.Add(pnlContenido)
        FormBorderStyle = FormBorderStyle.None
        Name = "frm_Login"
        Opacity = 0.95R
        StartPosition = FormStartPosition.CenterScreen
        Text = "frm_Login"
        pnlContenido.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlContenido As Panel
    Friend WithEvents txtPass As TextBoxLabelUI
    Friend WithEvents txtUsuario As TextBoxLabelUI
    Friend WithEvents fadeTimer As Timer
    Friend WithEvents btnMinimizar As FontAwesome.Sharp.IconButton
    Friend WithEvents btnSalir As FontAwesome.Sharp.IconButton
    Friend WithEvents btnAceptar As CommandButtonUI
    Friend WithEvents btnOlvidePass As ButtonLinkUI
    Friend WithEvents PasswordTextBoxLabelui1 As PasswordTextBoxLabelUI
    Friend WithEvents TextOnlyTextBoxLabelui1 As TextOnlyTextBoxLabelUI
    Friend WithEvents Comboui1 As ComboUI
End Class
