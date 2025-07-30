<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNuevoEmpleado
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
        pnlContenido = New Panel()
        btnEliminarFoto = New FontAwesome.Sharp.IconButton()
        btnSaveFoto = New FontAwesome.Sharp.IconButton()
        pnlCargo = New Panel()
        ToggleSwitchui2 = New ToggleSwitchUI()
        ToggleSwitchui5 = New ToggleSwitchUI()
        ToggleSwitchui3 = New ToggleSwitchUI()
        ToggleSwitchui1 = New ToggleSwitchUI()
        MultilineTextBoxLabelui1 = New MultilineTextBoxLabelUI()
        MaskedTextBoxLabelui3 = New MaskedTextBoxLabelUI()
        TextBoxLabelui4 = New TextBoxLabelUI()
        ComboBoxLabelui5 = New ComboBoxLabelUI()
        ComboBoxLabelui4 = New ComboBoxLabelUI()
        MaskedTextBoxLabelui2 = New MaskedTextBoxLabelUI()
        ComboBoxLabelui3 = New ComboBoxLabelUI()
        ComboBoxLabelui2 = New ComboBoxLabelUI()
        ComboBoxLabelui1 = New ComboBoxLabelUI()
        TextBoxLabelui3 = New TextBoxLabelUI()
        TextBoxLabelui2 = New TextBoxLabelUI()
        txtNombre = New TextBoxLabelUI()
        MaskedTextBoxLabelui1 = New MaskedTextBoxLabelUI()
        IconPictureBox1 = New FontAwesome.Sharp.IconPictureBox()
        pnlEncabezado = New Panel()
        bntGuardar = New CommandButtonUI()
        Headerui1 = New HeaderUI()
        pnlContenedor.SuspendLayout()
        pnlContenido.SuspendLayout()
        pnlCargo.SuspendLayout()
        CType(IconPictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        pnlEncabezado.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlContenedor
        ' 
        pnlContenedor.Controls.Add(pnlContenido)
        pnlContenedor.Controls.Add(pnlEncabezado)
        pnlContenedor.Dock = DockStyle.Fill
        pnlContenedor.Location = New Point(0, 0)
        pnlContenedor.Name = "pnlContenedor"
        pnlContenedor.Size = New Size(1274, 606)
        pnlContenedor.TabIndex = 0
        ' 
        ' pnlContenido
        ' 
        pnlContenido.AutoScroll = True
        pnlContenido.Controls.Add(btnEliminarFoto)
        pnlContenido.Controls.Add(btnSaveFoto)
        pnlContenido.Controls.Add(pnlCargo)
        pnlContenido.Controls.Add(MultilineTextBoxLabelui1)
        pnlContenido.Controls.Add(MaskedTextBoxLabelui3)
        pnlContenido.Controls.Add(TextBoxLabelui4)
        pnlContenido.Controls.Add(ComboBoxLabelui5)
        pnlContenido.Controls.Add(ComboBoxLabelui4)
        pnlContenido.Controls.Add(MaskedTextBoxLabelui2)
        pnlContenido.Controls.Add(ComboBoxLabelui3)
        pnlContenido.Controls.Add(ComboBoxLabelui2)
        pnlContenido.Controls.Add(ComboBoxLabelui1)
        pnlContenido.Controls.Add(TextBoxLabelui3)
        pnlContenido.Controls.Add(TextBoxLabelui2)
        pnlContenido.Controls.Add(txtNombre)
        pnlContenido.Controls.Add(MaskedTextBoxLabelui1)
        pnlContenido.Controls.Add(IconPictureBox1)
        pnlContenido.Dock = DockStyle.Fill
        pnlContenido.Location = New Point(0, 60)
        pnlContenido.Margin = New Padding(3, 30, 3, 3)
        pnlContenido.Name = "pnlContenido"
        pnlContenido.Padding = New Padding(10, 30, 0, 0)
        pnlContenido.Size = New Size(1274, 546)
        pnlContenido.TabIndex = 1
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
        btnEliminarFoto.Location = New Point(111, 239)
        btnEliminarFoto.Name = "btnEliminarFoto"
        btnEliminarFoto.Size = New Size(68, 57)
        btnEliminarFoto.TabIndex = 23
        btnEliminarFoto.Text = "Remover"
        btnEliminarFoto.TextImageRelation = TextImageRelation.ImageAboveText
        btnEliminarFoto.UseVisualStyleBackColor = True
        ' 
        ' btnSaveFoto
        ' 
        btnSaveFoto.FlatAppearance.BorderSize = 0
        btnSaveFoto.FlatStyle = FlatStyle.Flat
        btnSaveFoto.Font = New Font("Century Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnSaveFoto.IconChar = FontAwesome.Sharp.IconChar.FolderOpen
        btnSaveFoto.IconColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        btnSaveFoto.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnSaveFoto.IconSize = 40
        btnSaveFoto.Location = New Point(27, 239)
        btnSaveFoto.Name = "btnSaveFoto"
        btnSaveFoto.Size = New Size(68, 57)
        btnSaveFoto.TabIndex = 22
        btnSaveFoto.Text = "Agregar"
        btnSaveFoto.TextImageRelation = TextImageRelation.ImageAboveText
        btnSaveFoto.UseVisualStyleBackColor = True
        ' 
        ' pnlCargo
        ' 
        pnlCargo.BackColor = Color.Azure
        pnlCargo.Controls.Add(ToggleSwitchui2)
        pnlCargo.Controls.Add(ToggleSwitchui5)
        pnlCargo.Controls.Add(ToggleSwitchui3)
        pnlCargo.Controls.Add(ToggleSwitchui1)
        pnlCargo.Location = New Point(660, 364)
        pnlCargo.Name = "pnlCargo"
        pnlCargo.Size = New Size(602, 99)
        pnlCargo.TabIndex = 21
        ' 
        ' ToggleSwitchui2
        ' 
        ToggleSwitchui2.BackgroundOff = Color.Gainsboro
        ToggleSwitchui2.BackgroundOn = Color.SeaGreen
        ToggleSwitchui2.BorderRadius = 20
        ToggleSwitchui2.Checked = False
        ToggleSwitchui2.EstadoTexto = "Marketing..."
        ToggleSwitchui2.Font = New Font("Century Gothic", 11F)
        ToggleSwitchui2.Location = New Point(345, 61)
        ToggleSwitchui2.Name = "ToggleSwitchui2"
        ToggleSwitchui2.Size = New Size(160, 23)
        ToggleSwitchui2.SwitchColor = Color.DarkSlateGray
        ToggleSwitchui2.TabIndex = 0
        ToggleSwitchui2.Text = "ToggleSwitchui1"
        ToggleSwitchui2.TextColor = Color.DarkSlateGray
        ' 
        ' ToggleSwitchui5
        ' 
        ToggleSwitchui5.BackgroundOff = Color.Gainsboro
        ToggleSwitchui5.BackgroundOn = Color.SeaGreen
        ToggleSwitchui5.BorderRadius = 20
        ToggleSwitchui5.Checked = False
        ToggleSwitchui5.EstadoTexto = "Gerente..."
        ToggleSwitchui5.Font = New Font("Century Gothic", 11F)
        ToggleSwitchui5.Location = New Point(93, 61)
        ToggleSwitchui5.Name = "ToggleSwitchui5"
        ToggleSwitchui5.Size = New Size(147, 23)
        ToggleSwitchui5.SwitchColor = Color.DarkSlateGray
        ToggleSwitchui5.TabIndex = 0
        ToggleSwitchui5.Text = "ToggleSwitchui1"
        ToggleSwitchui5.TextColor = Color.DarkSlateGray
        ' 
        ' ToggleSwitchui3
        ' 
        ToggleSwitchui3.BackgroundOff = Color.Gainsboro
        ToggleSwitchui3.BackgroundOn = Color.SeaGreen
        ToggleSwitchui3.BorderRadius = 20
        ToggleSwitchui3.Checked = False
        ToggleSwitchui3.EstadoTexto = "Optometrista..."
        ToggleSwitchui3.Font = New Font("Century Gothic", 11F)
        ToggleSwitchui3.Location = New Point(345, 17)
        ToggleSwitchui3.Name = "ToggleSwitchui3"
        ToggleSwitchui3.Size = New Size(170, 23)
        ToggleSwitchui3.SwitchColor = Color.DarkSlateGray
        ToggleSwitchui3.TabIndex = 0
        ToggleSwitchui3.Text = "ToggleSwitchui1"
        ToggleSwitchui3.TextColor = Color.DarkSlateGray
        ' 
        ' ToggleSwitchui1
        ' 
        ToggleSwitchui1.BackgroundOff = Color.Gainsboro
        ToggleSwitchui1.BackgroundOn = Color.SeaGreen
        ToggleSwitchui1.BorderRadius = 20
        ToggleSwitchui1.Checked = False
        ToggleSwitchui1.EstadoTexto = "Asesor..."
        ToggleSwitchui1.Font = New Font("Century Gothic", 11F)
        ToggleSwitchui1.Location = New Point(93, 17)
        ToggleSwitchui1.Name = "ToggleSwitchui1"
        ToggleSwitchui1.Size = New Size(131, 23)
        ToggleSwitchui1.SwitchColor = Color.DarkSlateGray
        ToggleSwitchui1.TabIndex = 0
        ToggleSwitchui1.Text = "ToggleSwitchui1"
        ToggleSwitchui1.TextColor = Color.DarkSlateGray
        ' 
        ' MultilineTextBoxLabelui1
        ' 
        MultilineTextBoxLabelui1.AlturaMultilinea = 160
        MultilineTextBoxLabelui1.BackColor = Color.Transparent
        MultilineTextBoxLabelui1.BorderColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        MultilineTextBoxLabelui1.BorderRadius = 8
        MultilineTextBoxLabelui1.BorderSize = 1
        MultilineTextBoxLabelui1.CampoRequerido = True
        MultilineTextBoxLabelui1.CapitalizarTexto = False
        MultilineTextBoxLabelui1.CapitalizarTodasLasPalabras = True
        MultilineTextBoxLabelui1.ColorError = Color.Firebrick
        MultilineTextBoxLabelui1.FontField = New Font("Century Gothic", 12F)
        MultilineTextBoxLabelui1.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        MultilineTextBoxLabelui1.IconoDerechoChar = FontAwesome.Sharp.IconChar.CircleInfo
        MultilineTextBoxLabelui1.LabelColor = Color.DarkSlateGray
        MultilineTextBoxLabelui1.LabelText = "Dirección de habitación:"
        MultilineTextBoxLabelui1.Location = New Point(12, 343)
        MultilineTextBoxLabelui1.MensajeError = "Este campo es obligatorio."
        MultilineTextBoxLabelui1.Multilinea = True
        MultilineTextBoxLabelui1.Name = "MultilineTextBoxLabelui1"
        MultilineTextBoxLabelui1.PaddingAll = 10
        MultilineTextBoxLabelui1.PanelBackColor = Color.White
        MultilineTextBoxLabelui1.Size = New Size(642, 141)
        MultilineTextBoxLabelui1.TabIndex = 20
        MultilineTextBoxLabelui1.TextColor = Color.Black
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
        MaskedTextBoxLabelui3.IconoDerechoChar = FontAwesome.Sharp.IconChar.Neuter
        MaskedTextBoxLabelui3.LabelColor = Color.DarkSlateGray
        MaskedTextBoxLabelui3.LabelText = "# Telefono contacto:"
        MaskedTextBoxLabelui3.Location = New Point(568, 260)
        MaskedTextBoxLabelui3.MascaraPersonalizada = ""
        MaskedTextBoxLabelui3.MensajeError = "Este campo es obligatorio."
        MaskedTextBoxLabelui3.Name = "MaskedTextBoxLabelui3"
        MaskedTextBoxLabelui3.PaddingAll = 10
        MaskedTextBoxLabelui3.PanelBackColor = Color.White
        MaskedTextBoxLabelui3.Size = New Size(348, 77)
        MaskedTextBoxLabelui3.TabIndex = 8
        MaskedTextBoxLabelui3.TextColor = Color.Black
        MaskedTextBoxLabelui3.TipoNumerico = MaskedTextBoxLabelUI.TipoEntradaNumerica.Entero
        ' 
        ' TextBoxLabelui4
        ' 
        TextBoxLabelui4.BackColor = Color.Transparent
        TextBoxLabelui4.BorderColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        TextBoxLabelui4.BorderRadius = 5
        TextBoxLabelui4.BorderSize = 1
        TextBoxLabelui4.CampoRequerido = True
        TextBoxLabelui4.CapitalizarTexto = False
        TextBoxLabelui4.CapitalizarTodasLasPalabras = True
        TextBoxLabelui4.CaracterContraseña = "*"c
        TextBoxLabelui4.ColorError = Color.Firebrick
        TextBoxLabelui4.FontField = New Font("Century Gothic", 12F)
        TextBoxLabelui4.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        TextBoxLabelui4.IconoDerechoChar = FontAwesome.Sharp.IconChar.CircleInfo
        TextBoxLabelui4.LabelColor = Color.DarkSlateGray
        TextBoxLabelui4.LabelText = "Correo electrónico:"
        TextBoxLabelui4.Location = New Point(214, 260)
        TextBoxLabelui4.MensajeError = "Este campo es obligatorio."
        TextBoxLabelui4.Name = "TextBoxLabelui4"
        TextBoxLabelui4.PaddingAll = 10
        TextBoxLabelui4.PanelBackColor = Color.White
        TextBoxLabelui4.Size = New Size(348, 77)
        TextBoxLabelui4.TabIndex = 13
        TextBoxLabelui4.TextColor = Color.Black
        TextBoxLabelui4.UsarModoContraseña = False
        ' 
        ' ComboBoxLabelui5
        ' 
        ComboBoxLabelui5.BackColor = Color.Transparent
        ComboBoxLabelui5.BackColorPnl = Color.WhiteSmoke
        ComboBoxLabelui5.BorderColor = Color.LightGray
        ComboBoxLabelui5.BorderSize = 1
        ComboBoxLabelui5.CampoRequerido = True
        ComboBoxLabelui5.LabelColor = Color.DarkSlateGray
        ComboBoxLabelui5.Location = New Point(922, 260)
        ComboBoxLabelui5.MensajeError = "Este campo es obligatorio."
        ComboBoxLabelui5.MostrarError = False
        ComboBoxLabelui5.Name = "ComboBoxLabelui5"
        ComboBoxLabelui5.RadioContornoPanel = 8
        ComboBoxLabelui5.Size = New Size(348, 77)
        ComboBoxLabelui5.TabIndex = 14
        ComboBoxLabelui5.Titulo = "Zona de habitación:"
        ' 
        ' ComboBoxLabelui4
        ' 
        ComboBoxLabelui4.BackColor = Color.Transparent
        ComboBoxLabelui4.BackColorPnl = Color.WhiteSmoke
        ComboBoxLabelui4.BorderColor = Color.LightGray
        ComboBoxLabelui4.BorderSize = 1
        ComboBoxLabelui4.CampoRequerido = True
        ComboBoxLabelui4.LabelColor = Color.DarkSlateGray
        ComboBoxLabelui4.Location = New Point(922, 177)
        ComboBoxLabelui4.MensajeError = "Este campo es obligatorio."
        ComboBoxLabelui4.MostrarError = False
        ComboBoxLabelui4.Name = "ComboBoxLabelui4"
        ComboBoxLabelui4.RadioContornoPanel = 8
        ComboBoxLabelui4.Size = New Size(348, 77)
        ComboBoxLabelui4.TabIndex = 15
        ComboBoxLabelui4.Titulo = "Cargo:"
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
        MaskedTextBoxLabelui2.IconoDerechoChar = FontAwesome.Sharp.IconChar.Neuter
        MaskedTextBoxLabelui2.LabelColor = Color.DarkSlateGray
        MaskedTextBoxLabelui2.LabelText = "Fecha de Nacimiento:"
        MaskedTextBoxLabelui2.Location = New Point(568, 177)
        MaskedTextBoxLabelui2.MascaraPersonalizada = "99/99/9999"
        MaskedTextBoxLabelui2.MensajeError = "Este campo es obligatorio."
        MaskedTextBoxLabelui2.Name = "MaskedTextBoxLabelui2"
        MaskedTextBoxLabelui2.PaddingAll = 10
        MaskedTextBoxLabelui2.PanelBackColor = Color.White
        MaskedTextBoxLabelui2.Size = New Size(348, 77)
        MaskedTextBoxLabelui2.TabIndex = 7
        MaskedTextBoxLabelui2.TextColor = Color.Black
        MaskedTextBoxLabelui2.TipoNumerico = MaskedTextBoxLabelUI.TipoEntradaNumerica.Entero
        ' 
        ' ComboBoxLabelui3
        ' 
        ComboBoxLabelui3.BackColor = Color.Transparent
        ComboBoxLabelui3.BackColorPnl = Color.WhiteSmoke
        ComboBoxLabelui3.BorderColor = Color.LightGray
        ComboBoxLabelui3.BorderSize = 1
        ComboBoxLabelui3.CampoRequerido = True
        ComboBoxLabelui3.LabelColor = Color.DarkSlateGray
        ComboBoxLabelui3.Location = New Point(214, 177)
        ComboBoxLabelui3.MensajeError = "Este campo es obligatorio."
        ComboBoxLabelui3.MostrarError = False
        ComboBoxLabelui3.Name = "ComboBoxLabelui3"
        ComboBoxLabelui3.RadioContornoPanel = 8
        ComboBoxLabelui3.Size = New Size(348, 77)
        ComboBoxLabelui3.TabIndex = 16
        ComboBoxLabelui3.Titulo = "Sexo:"
        ' 
        ' ComboBoxLabelui2
        ' 
        ComboBoxLabelui2.BackColor = Color.Transparent
        ComboBoxLabelui2.BackColorPnl = Color.WhiteSmoke
        ComboBoxLabelui2.BorderColor = Color.LightGray
        ComboBoxLabelui2.BorderSize = 1
        ComboBoxLabelui2.CampoRequerido = True
        ComboBoxLabelui2.LabelColor = Color.DarkSlateGray
        ComboBoxLabelui2.Location = New Point(922, 94)
        ComboBoxLabelui2.MensajeError = "Este campo es obligatorio."
        ComboBoxLabelui2.MostrarError = False
        ComboBoxLabelui2.Name = "ComboBoxLabelui2"
        ComboBoxLabelui2.RadioContornoPanel = 8
        ComboBoxLabelui2.Size = New Size(348, 77)
        ComboBoxLabelui2.TabIndex = 17
        ComboBoxLabelui2.Titulo = "Estado Civil:"
        ' 
        ' ComboBoxLabelui1
        ' 
        ComboBoxLabelui1.BackColor = Color.Transparent
        ComboBoxLabelui1.BackColorPnl = Color.WhiteSmoke
        ComboBoxLabelui1.BorderColor = Color.LightGray
        ComboBoxLabelui1.BorderSize = 1
        ComboBoxLabelui1.CampoRequerido = True
        ComboBoxLabelui1.LabelColor = Color.DarkSlateGray
        ComboBoxLabelui1.Location = New Point(568, 94)
        ComboBoxLabelui1.MensajeError = "Este campo es obligatorio."
        ComboBoxLabelui1.MostrarError = False
        ComboBoxLabelui1.Name = "ComboBoxLabelui1"
        ComboBoxLabelui1.RadioContornoPanel = 8
        ComboBoxLabelui1.Size = New Size(348, 77)
        ComboBoxLabelui1.TabIndex = 18
        ComboBoxLabelui1.Titulo = "Nacionalidad:"
        ' 
        ' TextBoxLabelui3
        ' 
        TextBoxLabelui3.BackColor = Color.Transparent
        TextBoxLabelui3.BorderColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        TextBoxLabelui3.BorderRadius = 5
        TextBoxLabelui3.BorderSize = 1
        TextBoxLabelui3.CampoRequerido = True
        TextBoxLabelui3.CapitalizarTexto = False
        TextBoxLabelui3.CapitalizarTodasLasPalabras = True
        TextBoxLabelui3.CaracterContraseña = "*"c
        TextBoxLabelui3.ColorError = Color.Firebrick
        TextBoxLabelui3.FontField = New Font("Century Gothic", 12F)
        TextBoxLabelui3.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        TextBoxLabelui3.IconoDerechoChar = FontAwesome.Sharp.IconChar.CircleInfo
        TextBoxLabelui3.LabelColor = Color.DarkSlateGray
        TextBoxLabelui3.LabelText = "Edad:"
        TextBoxLabelui3.Location = New Point(214, 94)
        TextBoxLabelui3.MensajeError = "Este campo es obligatorio."
        TextBoxLabelui3.Name = "TextBoxLabelui3"
        TextBoxLabelui3.PaddingAll = 10
        TextBoxLabelui3.PanelBackColor = Color.White
        TextBoxLabelui3.Size = New Size(348, 77)
        TextBoxLabelui3.TabIndex = 12
        TextBoxLabelui3.TextColor = Color.Black
        TextBoxLabelui3.UsarModoContraseña = False
        ' 
        ' TextBoxLabelui2
        ' 
        TextBoxLabelui2.BackColor = Color.Transparent
        TextBoxLabelui2.BorderColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        TextBoxLabelui2.BorderRadius = 5
        TextBoxLabelui2.BorderSize = 1
        TextBoxLabelui2.CampoRequerido = True
        TextBoxLabelui2.CapitalizarTexto = False
        TextBoxLabelui2.CapitalizarTodasLasPalabras = True
        TextBoxLabelui2.CaracterContraseña = "*"c
        TextBoxLabelui2.ColorError = Color.Firebrick
        TextBoxLabelui2.FontField = New Font("Century Gothic", 12F)
        TextBoxLabelui2.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        TextBoxLabelui2.IconoDerechoChar = FontAwesome.Sharp.IconChar.CircleInfo
        TextBoxLabelui2.LabelColor = Color.DarkSlateGray
        TextBoxLabelui2.LabelText = "Apellido:"
        TextBoxLabelui2.Location = New Point(922, 11)
        TextBoxLabelui2.MensajeError = "Este campo es obligatorio."
        TextBoxLabelui2.Name = "TextBoxLabelui2"
        TextBoxLabelui2.PaddingAll = 10
        TextBoxLabelui2.PanelBackColor = Color.White
        TextBoxLabelui2.Size = New Size(348, 77)
        TextBoxLabelui2.TabIndex = 11
        TextBoxLabelui2.TextColor = Color.Black
        TextBoxLabelui2.UsarModoContraseña = False
        ' 
        ' txtNombre
        ' 
        txtNombre.BackColor = Color.Transparent
        txtNombre.BorderColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtNombre.BorderRadius = 5
        txtNombre.BorderSize = 1
        txtNombre.CampoRequerido = True
        txtNombre.CapitalizarTexto = True
        txtNombre.CapitalizarTodasLasPalabras = True
        txtNombre.CaracterContraseña = "*"c
        txtNombre.ColorError = Color.Firebrick
        txtNombre.FontField = New Font("Century Gothic", 12F)
        txtNombre.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        txtNombre.IconoDerechoChar = FontAwesome.Sharp.IconChar.CircleInfo
        txtNombre.LabelColor = Color.DarkSlateGray
        txtNombre.LabelText = "Nombre:"
        txtNombre.Location = New Point(568, 11)
        txtNombre.MensajeError = "Este campo es obligatorio."
        txtNombre.Name = "txtNombre"
        txtNombre.PaddingAll = 10
        txtNombre.PanelBackColor = Color.White
        txtNombre.Size = New Size(348, 77)
        txtNombre.TabIndex = 10
        txtNombre.TextColor = Color.Black
        txtNombre.UsarModoContraseña = False
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
        MaskedTextBoxLabelui1.IconoDerechoChar = FontAwesome.Sharp.IconChar.Neuter
        MaskedTextBoxLabelui1.LabelColor = Color.DarkSlateGray
        MaskedTextBoxLabelui1.LabelText = "#Cedula:"
        MaskedTextBoxLabelui1.Location = New Point(214, 11)
        MaskedTextBoxLabelui1.MascaraPersonalizada = ""
        MaskedTextBoxLabelui1.MensajeError = "Este campo es obligatorio."
        MaskedTextBoxLabelui1.Name = "MaskedTextBoxLabelui1"
        MaskedTextBoxLabelui1.PaddingAll = 10
        MaskedTextBoxLabelui1.PanelBackColor = Color.White
        MaskedTextBoxLabelui1.Size = New Size(348, 77)
        MaskedTextBoxLabelui1.TabIndex = 9
        MaskedTextBoxLabelui1.TextColor = Color.Black
        MaskedTextBoxLabelui1.TipoNumerico = MaskedTextBoxLabelUI.TipoEntradaNumerica.Entero
        ' 
        ' IconPictureBox1
        ' 
        IconPictureBox1.BackColor = Color.White
        IconPictureBox1.BorderStyle = BorderStyle.FixedSingle
        IconPictureBox1.ForeColor = SystemColors.AppWorkspace
        IconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.UserGear
        IconPictureBox1.IconColor = SystemColors.AppWorkspace
        IconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconPictureBox1.IconSize = 196
        IconPictureBox1.Location = New Point(12, 11)
        IconPictureBox1.Name = "IconPictureBox1"
        IconPictureBox1.Size = New Size(196, 225)
        IconPictureBox1.TabIndex = 19
        IconPictureBox1.TabStop = False
        ' 
        ' pnlEncabezado
        ' 
        pnlEncabezado.Controls.Add(bntGuardar)
        pnlEncabezado.Controls.Add(Headerui1)
        pnlEncabezado.Dock = DockStyle.Top
        pnlEncabezado.Location = New Point(0, 0)
        pnlEncabezado.Name = "pnlEncabezado"
        pnlEncabezado.Size = New Size(1274, 60)
        pnlEncabezado.TabIndex = 0
        ' 
        ' bntGuardar
        ' 
        bntGuardar.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        bntGuardar.AnimarHover = True
        bntGuardar.BackColor = Color.Transparent
        bntGuardar.ColorBase = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        bntGuardar.ColorHover = Color.FromArgb(CByte(67), CByte(160), CByte(71))
        bntGuardar.ColorInternoFondo = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        bntGuardar.ColorPresionado = Color.FromArgb(CByte(56), CByte(142), CByte(60))
        bntGuardar.ColorTexto = Color.White
        bntGuardar.EstiloBoton = CommandButtonUI.EstiloBootstrap.Success
        bntGuardar.Font = New Font("Century Gothic", 10F, FontStyle.Bold)
        bntGuardar.Icono = FontAwesome.Sharp.IconChar.Save
        bntGuardar.Location = New Point(1084, 12)
        bntGuardar.Name = "bntGuardar"
        bntGuardar.RadioBorde = 8
        bntGuardar.Size = New Size(180, 40)
        bntGuardar.TabIndex = 1
        bntGuardar.Text = "CommandButtonui2"
        bntGuardar.Texto = "Guardar Datos"
        ' 
        ' Headerui1
        ' 
        Headerui1.ColorFondo = Color.White
        Headerui1.ColorTexto = Color.FromArgb(CByte(45), CByte(45), CByte(45))
        Headerui1.Dock = DockStyle.Fill
        Headerui1.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Headerui1.Icono = FontAwesome.Sharp.IconChar.CircleInfo
        Headerui1.Location = New Point(0, 0)
        Headerui1.MostrarSeparador = True
        Headerui1.Name = "Headerui1"
        Headerui1.Size = New Size(1274, 60)
        Headerui1.Subtitulo = "Subtítulo opcional"
        Headerui1.TabIndex = 0
        Headerui1.Text = "Headerui1"
        Headerui1.Titulo = "Título Principal"
        ' 
        ' frmNuevoEmpleado
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1274, 606)
        Controls.Add(pnlContenedor)
        Name = "frmNuevoEmpleado"
        Text = "frmNuevoEmpleado"
        pnlContenedor.ResumeLayout(False)
        pnlContenido.ResumeLayout(False)
        pnlCargo.ResumeLayout(False)
        CType(IconPictureBox1, ComponentModel.ISupportInitialize).EndInit()
        pnlEncabezado.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents pnlContenedor As Panel
    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents Headerui1 As HeaderUI
    Friend WithEvents bntGuardar As CommandButtonUI
    Friend WithEvents pnlContenido As Panel
    Friend WithEvents btnEliminarFoto As FontAwesome.Sharp.IconButton
    Friend WithEvents btnSaveFoto As FontAwesome.Sharp.IconButton
    Friend WithEvents pnlCargo As Panel
    Friend WithEvents ToggleSwitchui2 As ToggleSwitchUI
    Friend WithEvents ToggleSwitchui5 As ToggleSwitchUI
    Friend WithEvents ToggleSwitchui3 As ToggleSwitchUI
    Friend WithEvents ToggleSwitchui1 As ToggleSwitchUI
    Friend WithEvents MultilineTextBoxLabelui1 As MultilineTextBoxLabelUI
    Friend WithEvents MaskedTextBoxLabelui3 As MaskedTextBoxLabelUI
    Friend WithEvents TextBoxLabelui4 As TextBoxLabelUI
    Friend WithEvents ComboBoxLabelui5 As ComboBoxLabelUI
    Friend WithEvents ComboBoxLabelui4 As ComboBoxLabelUI
    Friend WithEvents MaskedTextBoxLabelui2 As MaskedTextBoxLabelUI
    Friend WithEvents ComboBoxLabelui3 As ComboBoxLabelUI
    Friend WithEvents ComboBoxLabelui2 As ComboBoxLabelUI
    Friend WithEvents ComboBoxLabelui1 As ComboBoxLabelUI
    Friend WithEvents TextBoxLabelui3 As TextBoxLabelUI
    Friend WithEvents TextBoxLabelui2 As TextBoxLabelUI
    Friend WithEvents txtNombre As TextBoxLabelUI
    Friend WithEvents MaskedTextBoxLabelui1 As MaskedTextBoxLabelUI
    Friend WithEvents IconPictureBox1 As FontAwesome.Sharp.IconPictureBox
End Class
