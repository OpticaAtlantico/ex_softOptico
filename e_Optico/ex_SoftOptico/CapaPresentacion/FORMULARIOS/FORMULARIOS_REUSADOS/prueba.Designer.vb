<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class prueba
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
        TextOnlyTextBoxLabelui1 = New TextOnlyTextBoxLabelUI()
        EmailTextBoxLabelui1 = New EmailTextBoxLabelUI()
        NumericTextBoxLabelui1 = New NumericTextBoxLabelUI()
        PasswordTextBoxLabelui1 = New PasswordTextBoxLabelUI()
        DecimalTextBoxLabelui1 = New DecimalTextBoxLabelUI()
        DateTextBoxLabelui1 = New DateTextBoxLabelUI()
        MultilineTextBoxui1 = New MultilineTextBoxUI()
        SuspendLayout()
        ' 
        ' TextOnlyTextBoxLabelui1
        ' 
        TextOnlyTextBoxLabelui1.BackColor = Color.Transparent
        TextOnlyTextBoxLabelui1.CampoRequerido = True
        TextOnlyTextBoxLabelui1.CapitalizarTexto = True
        TextOnlyTextBoxLabelui1.CapitalizarTodasLasPalabras = True
        TextOnlyTextBoxLabelui1.Location = New Point(90, 107)
        TextOnlyTextBoxLabelui1.MaxCaracteres = 0
        TextOnlyTextBoxLabelui1.MensajeError = "Campo requerido."
        TextOnlyTextBoxLabelui1.Name = "TextOnlyTextBoxLabelui1"
        TextOnlyTextBoxLabelui1.Placeholder = "Ingrese datos"
        TextOnlyTextBoxLabelui1.PlaceholderColor = Color.Gray
        TextOnlyTextBoxLabelui1.Size = New Size(356, 85)
        TextOnlyTextBoxLabelui1.TabIndex = 1
        TextOnlyTextBoxLabelui1.TextoLabel = "Texto:"
        ' 
        ' EmailTextBoxLabelui1
        ' 
        EmailTextBoxLabelui1.BackColor = Color.Transparent
        EmailTextBoxLabelui1.CampoRequerido = False
        EmailTextBoxLabelui1.CapitalizarTexto = False
        EmailTextBoxLabelui1.CapitalizarTodasLasPalabras = False
        EmailTextBoxLabelui1.Location = New Point(53, 186)
        EmailTextBoxLabelui1.MaxCaracteres = 0
        EmailTextBoxLabelui1.MensajeError = "Campo requerido."
        EmailTextBoxLabelui1.Name = "EmailTextBoxLabelui1"
        EmailTextBoxLabelui1.Placeholder = "Escriba aquí..."
        EmailTextBoxLabelui1.PlaceholderColor = Color.Gray
        EmailTextBoxLabelui1.Size = New Size(368, 89)
        EmailTextBoxLabelui1.TabIndex = 2
        EmailTextBoxLabelui1.TextoLabel = "Correo electrónico:"
        ' 
        ' NumericTextBoxLabelui1
        ' 
        NumericTextBoxLabelui1.BackColor = Color.Transparent
        NumericTextBoxLabelui1.CampoRequerido = True
        NumericTextBoxLabelui1.CapitalizarTexto = False
        NumericTextBoxLabelui1.CapitalizarTodasLasPalabras = False
        NumericTextBoxLabelui1.Location = New Point(61, 265)
        NumericTextBoxLabelui1.MaxCaracteres = 8
        NumericTextBoxLabelui1.MensajeError = "Campo requerido."
        NumericTextBoxLabelui1.Name = "NumericTextBoxLabelui1"
        NumericTextBoxLabelui1.Placeholder = "Ingrese Número"
        NumericTextBoxLabelui1.PlaceholderColor = Color.Gray
        NumericTextBoxLabelui1.Size = New Size(360, 77)
        NumericTextBoxLabelui1.TabIndex = 3
        NumericTextBoxLabelui1.TextoLabel = "Número:"
        ' 
        ' PasswordTextBoxLabelui1
        ' 
        PasswordTextBoxLabelui1.BackColor = Color.Transparent
        PasswordTextBoxLabelui1.CampoRequerido = False
        PasswordTextBoxLabelui1.CapitalizarTexto = False
        PasswordTextBoxLabelui1.CapitalizarTodasLasPalabras = False
        PasswordTextBoxLabelui1.Location = New Point(63, 348)
        PasswordTextBoxLabelui1.MaxCaracteres = 0
        PasswordTextBoxLabelui1.MensajeError = "Campo requerido."
        PasswordTextBoxLabelui1.Name = "PasswordTextBoxLabelui1"
        PasswordTextBoxLabelui1.Placeholder = "Ingrese contraseña"
        PasswordTextBoxLabelui1.PlaceholderColor = Color.Gray
        PasswordTextBoxLabelui1.Size = New Size(358, 78)
        PasswordTextBoxLabelui1.TabIndex = 4
        PasswordTextBoxLabelui1.TextoLabel = "Contraseña:"
        ' 
        ' DecimalTextBoxLabelui1
        ' 
        DecimalTextBoxLabelui1.BackColor = Color.Transparent
        DecimalTextBoxLabelui1.CampoRequerido = False
        DecimalTextBoxLabelui1.CapitalizarTexto = False
        DecimalTextBoxLabelui1.CapitalizarTodasLasPalabras = False
        DecimalTextBoxLabelui1.Location = New Point(53, 22)
        DecimalTextBoxLabelui1.MaxCaracteres = 0
        DecimalTextBoxLabelui1.MensajeError = "Campo requerido."
        DecimalTextBoxLabelui1.Name = "DecimalTextBoxLabelui1"
        DecimalTextBoxLabelui1.Placeholder = "Ingrese Número"
        DecimalTextBoxLabelui1.PlaceholderColor = Color.Gray
        DecimalTextBoxLabelui1.Size = New Size(393, 79)
        DecimalTextBoxLabelui1.TabIndex = 5
        DecimalTextBoxLabelui1.TextoLabel = "Número:"
        ' 
        ' DateTextBoxLabelui1
        ' 
        DateTextBoxLabelui1.BackColor = Color.Transparent
        DateTextBoxLabelui1.CampoRequerido = False
        DateTextBoxLabelui1.CapitalizarTexto = False
        DateTextBoxLabelui1.CapitalizarTodasLasPalabras = False
        DateTextBoxLabelui1.Location = New Point(505, 42)
        DateTextBoxLabelui1.MaxCaracteres = 0
        DateTextBoxLabelui1.MensajeError = "Campo requerido."
        DateTextBoxLabelui1.Name = "DateTextBoxLabelui1"
        DateTextBoxLabelui1.Placeholder = ""
        DateTextBoxLabelui1.PlaceholderColor = Color.Gray
        DateTextBoxLabelui1.Size = New Size(400, 109)
        DateTextBoxLabelui1.TabIndex = 6
        DateTextBoxLabelui1.TextoLabel = "Fecha:"
        DateTextBoxLabelui1.Value = New Date(2025, 9, 10, 16, 40, 22, 569)
        ' 
        ' MultilineTextBoxui1
        ' 
        MultilineTextBoxui1.BackColor = Color.Transparent
        MultilineTextBoxui1.CampoRequerido = False
        MultilineTextBoxui1.CapitalizarTexto = False
        MultilineTextBoxui1.CapitalizarTodasLasPalabras = False
        MultilineTextBoxui1.Location = New Point(492, 219)
        MultilineTextBoxui1.MaxCaracteres = 0
        MultilineTextBoxui1.MensajeError = "Campo requerido."
        MultilineTextBoxui1.MinimumSize = New Size(150, 100)
        MultilineTextBoxui1.Name = "MultilineTextBoxui1"
        MultilineTextBoxui1.Placeholder = "Escriba un párrafo..."
        MultilineTextBoxui1.PlaceholderColor = Color.Gray
        MultilineTextBoxui1.Size = New Size(413, 147)
        MultilineTextBoxui1.TabIndex = 7
        MultilineTextBoxui1.TextoLabel = "Texto:"
        ' 
        ' prueba
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(975, 450)
        Controls.Add(MultilineTextBoxui1)
        Controls.Add(DateTextBoxLabelui1)
        Controls.Add(DecimalTextBoxLabelui1)
        Controls.Add(PasswordTextBoxLabelui1)
        Controls.Add(NumericTextBoxLabelui1)
        Controls.Add(EmailTextBoxLabelui1)
        Controls.Add(TextOnlyTextBoxLabelui1)
        Name = "prueba"
        Text = "prueba"
        ResumeLayout(False)
    End Sub
    Friend WithEvents TextOnlyTextBoxLabelui1 As TextOnlyTextBoxLabelUI
    Friend WithEvents EmailTextBoxLabelui1 As EmailTextBoxLabelUI
    Friend WithEvents NumericTextBoxLabelui1 As NumericTextBoxLabelUI
    Friend WithEvents PasswordTextBoxLabelui1 As PasswordTextBoxLabelUI
    Friend WithEvents DecimalTextBoxLabelui1 As DecimalTextBoxLabelUI
    Friend WithEvents DateTextBoxLabelui1 As DateTextBoxLabelUI
    Friend WithEvents MultilineTextBoxui1 As MultilineTextBoxUI
End Class
