<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class prueba
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
        TextOnlyTextBoxLabelui1 = New TextOnlyTextBoxLabelUI()
        Panel1 = New Panel()
        MultilineTextBoxLabelui1 = New MultilineTextBoxLabelUI()
        EmailTextBoxLabelui1 = New EmailTextBoxLabelUI()
        DecimalTextBoxLabelui1 = New DecimalTextBoxLabelUI()
        DatePickerProui1 = New DatePickerProUI()
        Panel2 = New Panel()
        Panelui2 = New PanelUI()
        CommandButtonui1 = New CommandButtonUI()
        ComboBoxLabelui1 = New ComboBoxLabelUI()
        Comboui1 = New ComboUI()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' TextOnlyTextBoxLabelui1
        ' 
        TextOnlyTextBoxLabelui1.BackColor = Color.Transparent
        TextOnlyTextBoxLabelui1.CampoRequerido = True
        TextOnlyTextBoxLabelui1.CapitalizarTexto = False
        TextOnlyTextBoxLabelui1.CapitalizarTodasLasPalabras = False
        TextOnlyTextBoxLabelui1.ColorTitulo = Color.Navy
        TextOnlyTextBoxLabelui1.Dock = DockStyle.Top
        TextOnlyTextBoxLabelui1.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        TextOnlyTextBoxLabelui1.IconoDerechoChar = FontAwesome.Sharp.IconChar.Font
        TextOnlyTextBoxLabelui1.Location = New Point(0, 0)
        TextOnlyTextBoxLabelui1.MaxCaracteres = 0
        TextOnlyTextBoxLabelui1.MensajeError = "Campo requerido."
        TextOnlyTextBoxLabelui1.Name = "TextOnlyTextBoxLabelui1"
        TextOnlyTextBoxLabelui1.Placeholder = "Ingrese datos"
        TextOnlyTextBoxLabelui1.PlaceholderColor = Color.Gray
        TextOnlyTextBoxLabelui1.Size = New Size(395, 73)
        TextOnlyTextBoxLabelui1.TabIndex = 0
        TextOnlyTextBoxLabelui1.TextoLabel = "Texto:"
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.White
        Panel1.Controls.Add(MultilineTextBoxLabelui1)
        Panel1.Controls.Add(EmailTextBoxLabelui1)
        Panel1.Controls.Add(DecimalTextBoxLabelui1)
        Panel1.Controls.Add(DatePickerProui1)
        Panel1.Controls.Add(TextOnlyTextBoxLabelui1)
        Panel1.Location = New Point(12, 12)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(395, 431)
        Panel1.TabIndex = 4
        ' 
        ' MultilineTextBoxLabelui1
        ' 
        MultilineTextBoxLabelui1.AlturaMultilinea = 80
        MultilineTextBoxLabelui1.BackColor = Color.Transparent
        MultilineTextBoxLabelui1.BorderColor = Color.FromArgb(CByte(33), CByte(150), CByte(243))
        MultilineTextBoxLabelui1.BorderRadius = 8
        MultilineTextBoxLabelui1.BorderSize = 1
        MultilineTextBoxLabelui1.CampoRequerido = True
        MultilineTextBoxLabelui1.CapitalizarTexto = False
        MultilineTextBoxLabelui1.CapitalizarTodasLasPalabras = True
        MultilineTextBoxLabelui1.ColorError = Color.Firebrick
        MultilineTextBoxLabelui1.FontField = New Font("Microsoft Sans Serif", 12F)
        MultilineTextBoxLabelui1.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        MultilineTextBoxLabelui1.IconoDerechoChar = FontAwesome.Sharp.IconChar.CircleInfo
        MultilineTextBoxLabelui1.LabelColor = Color.DarkSlateGray
        MultilineTextBoxLabelui1.LabelText = "Texto:"
        MultilineTextBoxLabelui1.Location = New Point(3, 319)
        MultilineTextBoxLabelui1.MensajeError = "Este campo es requerido"
        MultilineTextBoxLabelui1.Multilinea = True
        MultilineTextBoxLabelui1.Name = "MultilineTextBoxLabelui1"
        MultilineTextBoxLabelui1.PaddingAll = 10
        MultilineTextBoxLabelui1.PanelBackColor = Color.White
        MultilineTextBoxLabelui1.Placeholder = "Escribaaa aquí..."
        MultilineTextBoxLabelui1.PlaceholderColor = Color.Gray
        MultilineTextBoxLabelui1.Size = New Size(372, 109)
        MultilineTextBoxLabelui1.TabIndex = 4
        MultilineTextBoxLabelui1.TextColor = Color.Black
        MultilineTextBoxLabelui1.TextoUsuario = ""
        ' 
        ' EmailTextBoxLabelui1
        ' 
        EmailTextBoxLabelui1.BackColor = Color.Transparent
        EmailTextBoxLabelui1.CampoRequerido = False
        EmailTextBoxLabelui1.CapitalizarTexto = False
        EmailTextBoxLabelui1.CapitalizarTodasLasPalabras = False
        EmailTextBoxLabelui1.ColorTitulo = Color.DarkSlateGray
        EmailTextBoxLabelui1.Dock = DockStyle.Top
        EmailTextBoxLabelui1.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        EmailTextBoxLabelui1.IconoDerechoChar = FontAwesome.Sharp.IconChar.Envelope
        EmailTextBoxLabelui1.Location = New Point(0, 233)
        EmailTextBoxLabelui1.MaxCaracteres = 0
        EmailTextBoxLabelui1.MensajeError = "Este campo es requerido"
        EmailTextBoxLabelui1.Name = "EmailTextBoxLabelui1"
        EmailTextBoxLabelui1.Placeholder = "Escriba aquí..."
        EmailTextBoxLabelui1.PlaceholderColor = Color.Gray
        EmailTextBoxLabelui1.Size = New Size(395, 80)
        EmailTextBoxLabelui1.TabIndex = 3
        EmailTextBoxLabelui1.TextoLabel = "Correo electrónico:"
        ' 
        ' DecimalTextBoxLabelui1
        ' 
        DecimalTextBoxLabelui1.BackColor = Color.Transparent
        DecimalTextBoxLabelui1.CampoRequerido = False
        DecimalTextBoxLabelui1.CapitalizarTexto = False
        DecimalTextBoxLabelui1.CapitalizarTodasLasPalabras = False
        DecimalTextBoxLabelui1.ColorTitulo = Color.DarkSlateGray
        DecimalTextBoxLabelui1.DecimalesPermitidos = 2
        DecimalTextBoxLabelui1.Dock = DockStyle.Top
        DecimalTextBoxLabelui1.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        DecimalTextBoxLabelui1.IconoDerechoChar = FontAwesome.Sharp.IconChar.CircleInfo
        DecimalTextBoxLabelui1.Location = New Point(0, 159)
        DecimalTextBoxLabelui1.MaxCaracteres = 0
        DecimalTextBoxLabelui1.MensajeError = "Este campo es requerido"
        DecimalTextBoxLabelui1.MensajeErrorNumeroInvalido = "Ingrese un número válido."
        DecimalTextBoxLabelui1.MensajeErrorRango = "El valor está fuera del rango permitido."
        DecimalTextBoxLabelui1.Name = "DecimalTextBoxLabelui1"
        DecimalTextBoxLabelui1.NumeroMaximo = New Decimal(New Integer() {-1, -1, -1, 0})
        DecimalTextBoxLabelui1.NumeroMinimo = New Decimal(New Integer() {-1, -1, -1, Integer.MinValue})
        DecimalTextBoxLabelui1.Placeholder = "Ingrese un número decimal..."
        DecimalTextBoxLabelui1.PlaceholderColor = Color.Gray
        DecimalTextBoxLabelui1.Size = New Size(395, 74)
        DecimalTextBoxLabelui1.TabIndex = 2
        DecimalTextBoxLabelui1.TextoLabel = "Texto:"
        DecimalTextBoxLabelui1.UsarSeparadorMiles = True
        ' 
        ' DatePickerProui1
        ' 
        DatePickerProui1.BackColor = Color.Transparent
        DatePickerProui1.BorderColor = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        DatePickerProui1.BorderRadius = 8
        DatePickerProui1.BorderSize = 1
        DatePickerProui1.CampoRequerido = True
        DatePickerProui1.Dock = DockStyle.Top
        DatePickerProui1.FechaSeleccionada = New Date(2025, 9, 13, 0, 0, 0, 0)
        DatePickerProui1.FontField = New Font("Microsoft Sans Serif", 12F)
        DatePickerProui1.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        DatePickerProui1.IconoDerechoChar = FontAwesome.Sharp.IconChar.None
        DatePickerProui1.LabelColor = Color.DarkSlateGray
        DatePickerProui1.LabelText = "Fecha"
        DatePickerProui1.Location = New Point(0, 73)
        DatePickerProui1.MensajeError = "Este campo es requerido"
        DatePickerProui1.Name = "DatePickerProui1"
        DatePickerProui1.PaddingAll = 10
        DatePickerProui1.PanelBackColor = Color.White
        DatePickerProui1.Size = New Size(395, 86)
        DatePickerProui1.TabIndex = 1
        DatePickerProui1.TextColor = Color.Black
        DatePickerProui1.ValorFecha = New Date(2025, 9, 13, 0, 0, 0, 0)
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.Transparent
        Panel2.Controls.Add(Panel1)
        Panel2.Controls.Add(Panelui2)
        Panel2.Location = New Point(12, 12)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(424, 461)
        Panel2.TabIndex = 5
        ' 
        ' Panelui2
        ' 
        Panelui2.BackColor = Color.Transparent
        Panelui2.BackColorContenedor = Color.Transparent
        Panelui2.BorderColor = Color.White
        Panelui2.BorderRadius = 20
        Panelui2.BorderSize = 1
        Panelui2.CardBackColor = Color.White
        Panelui2.Dock = DockStyle.Fill
        Panelui2.Estilo = PanelUI.EstiloCard.None
        Panelui2.Location = New Point(0, 0)
        Panelui2.Name = "Panelui2"
        Panelui2.ShadowColor = Color.PaleTurquoise
        Panelui2.Size = New Size(424, 461)
        Panelui2.TabIndex = 0
        Panelui2.Texto = ""
        ' 
        ' CommandButtonui1
        ' 
        CommandButtonui1.AnimarHover = True
        CommandButtonui1.BackColor = Color.Transparent
        CommandButtonui1.ColorBase = Color.FromArgb(CByte(33), CByte(150), CByte(243))
        CommandButtonui1.ColorHover = Color.FromArgb(CByte(30), CByte(136), CByte(229))
        CommandButtonui1.ColorInternoFondo = Color.FromArgb(CByte(33), CByte(150), CByte(243))
        CommandButtonui1.ColorPresionado = Color.FromArgb(CByte(25), CByte(118), CByte(210))
        CommandButtonui1.ColorTexto = Color.WhiteSmoke
        CommandButtonui1.EstiloBoton = CommandButtonUI.EstiloBootstrap.Primary
        CommandButtonui1.Font = New Font("Microsoft Sans Serif", 10F, FontStyle.Bold)
        CommandButtonui1.Icono = FontAwesome.Sharp.IconChar.Bolt
        CommandButtonui1.Location = New Point(559, 334)
        CommandButtonui1.Name = "CommandButtonui1"
        CommandButtonui1.RadioBorde = 8
        CommandButtonui1.Size = New Size(203, 57)
        CommandButtonui1.TabIndex = 6
        CommandButtonui1.Text = "CommandButtonui1"
        CommandButtonui1.Texto = "Aceptar"
        ' 
        ' ComboBoxLabelui1
        ' 
        ComboBoxLabelui1.BackColor = Color.Transparent
        ComboBoxLabelui1.BackColorPnl = Color.White
        ComboBoxLabelui1.BorderColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        ComboBoxLabelui1.BorderSize = 1
        ComboBoxLabelui1.CampoRequerido = True
        ComboBoxLabelui1.IndiceSeleccionado = -1
        ComboBoxLabelui1.LabelColor = Color.DarkSlateGray
        ComboBoxLabelui1.Location = New Point(493, 24)
        ComboBoxLabelui1.MensajeError = "Este campo es requerido"
        ComboBoxLabelui1.MostrarError = False
        ComboBoxLabelui1.Name = "ComboBoxLabelui1"
        ComboBoxLabelui1.RadioContornoPanel = 8
        ComboBoxLabelui1.Size = New Size(323, 83)
        ComboBoxLabelui1.SombraBackColor = Color.LightGray
        ComboBoxLabelui1.TabIndex = 7
        ComboBoxLabelui1.Titulo = "Selecciona una opción:"
        ComboBoxLabelui1.ValorSeleccionado = Nothing
        ' 
        ' Comboui1
        ' 
        Comboui1.BackColor = Color.Transparent
        Comboui1.CampoRequerido = False
        Comboui1.ColorTitulo = Color.DarkSlateGray
        Comboui1.Location = New Point(442, 183)
        Comboui1.MensajeError = "Este campo es requerido"
        Comboui1.Name = "Comboui1"
        Comboui1.Placeholder = "Selecciones una Opcion..."
        Comboui1.PlaceholderColor = Color.Gray
        Comboui1.Size = New Size(344, 88)
        Comboui1.TabIndex = 8
        Comboui1.TextoLabel = "Texto:"
        ' 
        ' prueba
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.WhiteSmoke
        ClientSize = New Size(937, 512)
        Controls.Add(Comboui1)
        Controls.Add(ComboBoxLabelui1)
        Controls.Add(CommandButtonui1)
        Controls.Add(Panel2)
        Name = "prueba"
        Text = "prueba"
        Panel1.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents TextOnlyTextBoxLabelui1 As TextOnlyTextBoxLabelUI
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panelui2 As PanelUI
    Friend WithEvents CommandButtonui1 As CommandButtonUI
    Friend WithEvents DatePickerProui1 As DatePickerProUI
    Friend WithEvents DecimalTextBoxLabelui1 As DecimalTextBoxLabelUI
    Friend WithEvents EmailTextBoxLabelui1 As EmailTextBoxLabelUI
    Friend WithEvents MultilineTextBoxLabelui1 As MultilineTextBoxLabelUI
    Friend WithEvents ComboBoxLabelui1 As ComboBoxLabelUI
    Friend WithEvents Comboui1 As ComboUI

End Class
