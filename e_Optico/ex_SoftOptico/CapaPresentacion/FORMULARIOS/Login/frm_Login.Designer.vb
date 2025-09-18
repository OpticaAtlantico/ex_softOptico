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
        cmbLocal = New ComboBoxLayoutUI()
        txtPass = New PasswordTextBoxLabelUI()
        txtUsuario = New TextOnlyTextBoxLabelUI()
        btnOlvidePass = New ButtonLinkUI()
        btnAceptar = New CommandButtonUI()
        btnSalir = New FontAwesome.Sharp.IconButton()
        btnMinimizar = New FontAwesome.Sharp.IconButton()
        pnlContenido.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlContenido
        ' 
        pnlContenido.BackgroundImage = CType(resources.GetObject("pnlContenido.BackgroundImage"), Image)
        pnlContenido.Controls.Add(cmbLocal)
        pnlContenido.Controls.Add(txtPass)
        pnlContenido.Controls.Add(txtUsuario)
        pnlContenido.Controls.Add(btnOlvidePass)
        pnlContenido.Controls.Add(btnAceptar)
        pnlContenido.Controls.Add(btnSalir)
        pnlContenido.Controls.Add(btnMinimizar)
        pnlContenido.Dock = DockStyle.Fill
        pnlContenido.Location = New Point(0, 0)
        pnlContenido.Name = "pnlContenido"
        pnlContenido.Size = New Size(906, 555)
        pnlContenido.TabIndex = 0
        ' 
        ' cmbLocal
        ' 
        cmbLocal.BackColor = Color.Transparent
        cmbLocal.CampoRequerido = False
        cmbLocal.ColorTitulo = Color.DarkSlateGray
        cmbLocal.IndiceSeleccionado = -1
        cmbLocal.Location = New Point(559, 310)
        cmbLocal.MensajeError = "Este campo es requerido"
        cmbLocal.Name = "cmbLocal"
        cmbLocal.Placeholder = "Selecciones una Opción..."
        cmbLocal.PlaceholderColor = Color.Gray
        cmbLocal.Size = New Size(308, 80)
        cmbLocal.TabIndex = 2
        cmbLocal.TextoLabel = "Establecimiento:"
        cmbLocal.ValorSeleccionado = Nothing
        ' 
        ' txtPass
        ' 
        txtPass.BackColor = Color.Transparent
        txtPass.CampoRequerido = True
        txtPass.CapitalizarTexto = False
        txtPass.CapitalizarTodasLasPalabras = False
        txtPass.ColorTitulo = Color.DarkSlateGray
        txtPass.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtPass.IconoDerechoChar = FontAwesome.Sharp.IconChar.Fingerprint
        txtPass.Location = New Point(559, 226)
        txtPass.MaxCaracteres = 0
        txtPass.MensajeError = "Campo requerido"
        txtPass.MinCaracteres = 6
        txtPass.Name = "txtPass"
        txtPass.PaddingIzquierda = 8
        txtPass.PaddingIzquierdaIcono = 10
        txtPass.Placeholder = "Ingrese la contraseña..."
        txtPass.PlaceholderColor = Color.Gray
        txtPass.Size = New Size(308, 80)
        txtPass.TabIndex = 1
        txtPass.TextoLabel = "Contraseña:"
        txtPass.TextString = ""
        txtPass.ValidarComoCorreo = False
        ' 
        ' txtUsuario
        ' 
        txtUsuario.BackColor = Color.Transparent
        txtUsuario.CampoRequerido = True
        txtUsuario.CapitalizarTexto = False
        txtUsuario.CapitalizarTodasLasPalabras = False
        txtUsuario.ColorTitulo = Color.DarkSlateGray
        txtUsuario.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtUsuario.IconoDerechoChar = FontAwesome.Sharp.IconChar.UserCheck
        txtUsuario.Location = New Point(559, 142)
        txtUsuario.MaxCaracteres = 0
        txtUsuario.MensajeError = "Campo requerido"
        txtUsuario.MinCaracteres = 0
        txtUsuario.Name = "txtUsuario"
        txtUsuario.PaddingIzquierda = 8
        txtUsuario.PaddingIzquierdaIcono = 10
        txtUsuario.Placeholder = "Ingrese el usuario..."
        txtUsuario.PlaceholderColor = Color.Gray
        txtUsuario.Size = New Size(308, 80)
        txtUsuario.TabIndex = 0
        txtUsuario.TextoLabel = "Usuario:"
        txtUsuario.TextString = ""
        txtUsuario.ValidarComoCorreo = False
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
        btnAceptar.Font = New Font("Microsoft Sans Serif", 10F, FontStyle.Bold)
        btnAceptar.Icono = FontAwesome.Sharp.IconChar.CheckCircle
        btnAceptar.Location = New Point(583, 464)
        btnAceptar.Name = "btnAceptar"
        btnAceptar.RadioBorde = 12
        btnAceptar.Size = New Size(266, 42)
        btnAceptar.TabIndex = 3
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
    Friend WithEvents fadeTimer As Timer
    Friend WithEvents btnMinimizar As FontAwesome.Sharp.IconButton
    Friend WithEvents btnSalir As FontAwesome.Sharp.IconButton
    Friend WithEvents btnAceptar As CommandButtonUI
    Friend WithEvents btnOlvidePass As ButtonLinkUI
    Friend WithEvents txtPass As PasswordTextBoxLabelUI
    Friend WithEvents txtUsuario As TextOnlyTextBoxLabelUI
    Friend WithEvents cmbLocal As ComboBoxLayoutUI
End Class
