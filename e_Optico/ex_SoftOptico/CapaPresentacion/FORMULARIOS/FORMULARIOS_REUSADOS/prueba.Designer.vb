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
        DecimalTextBoxLabelui1 = New DecimalTextBoxLabelUI()
        NumericTextBoxLabelui1 = New NumericTextBoxLabelUI()
        SuspendLayout()
        ' 
        ' TextOnlyTextBoxLabelui1
        ' 
        TextOnlyTextBoxLabelui1.BackColor = Color.Transparent
        TextOnlyTextBoxLabelui1.CampoRequerido = True
        TextOnlyTextBoxLabelui1.CapitalizarTexto = False
        TextOnlyTextBoxLabelui1.CapitalizarTodasLasPalabras = False
        TextOnlyTextBoxLabelui1.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        TextOnlyTextBoxLabelui1.IconoDerechoChar = FontAwesome.Sharp.IconChar.Font
        TextOnlyTextBoxLabelui1.Location = New Point(70, 46)
        TextOnlyTextBoxLabelui1.MaxCaracteres = 0
        TextOnlyTextBoxLabelui1.MensajeError = "Campo requerido."
        TextOnlyTextBoxLabelui1.Name = "TextOnlyTextBoxLabelui1"
        TextOnlyTextBoxLabelui1.Placeholder = "Ingrese datos"
        TextOnlyTextBoxLabelui1.PlaceholderColor = Color.Gray
        TextOnlyTextBoxLabelui1.Size = New Size(406, 73)
        TextOnlyTextBoxLabelui1.TabIndex = 0
        TextOnlyTextBoxLabelui1.TextoLabel = "Texto:"
        ' 
        ' DecimalTextBoxLabelui1
        ' 
        DecimalTextBoxLabelui1.BackColor = Color.Transparent
        DecimalTextBoxLabelui1.CampoRequerido = False
        DecimalTextBoxLabelui1.CapitalizarTexto = False
        DecimalTextBoxLabelui1.CapitalizarTodasLasPalabras = False
        DecimalTextBoxLabelui1.DecimalesPermitidos = 2
        DecimalTextBoxLabelui1.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        DecimalTextBoxLabelui1.IconoDerechoChar = FontAwesome.Sharp.IconChar.CircleInfo
        DecimalTextBoxLabelui1.Location = New Point(70, 125)
        DecimalTextBoxLabelui1.MaxCaracteres = 0
        DecimalTextBoxLabelui1.MensajeError = "Campo requerido."
        DecimalTextBoxLabelui1.MensajeErrorNumeroInvalido = "Ingrese un número válido."
        DecimalTextBoxLabelui1.MensajeErrorRango = "El valor está fuera del rango permitido."
        DecimalTextBoxLabelui1.Name = "DecimalTextBoxLabelui1"
        DecimalTextBoxLabelui1.NumeroMaximo = New Decimal(New Integer() {-1, -1, -1, 0})
        DecimalTextBoxLabelui1.NumeroMinimo = New Decimal(New Integer() {-1, -1, -1, Integer.MinValue})
        DecimalTextBoxLabelui1.Placeholder = "Ingrese un número decimal..."
        DecimalTextBoxLabelui1.PlaceholderColor = Color.Gray
        DecimalTextBoxLabelui1.Size = New Size(406, 75)
        DecimalTextBoxLabelui1.TabIndex = 1
        DecimalTextBoxLabelui1.TextoLabel = "Texto:"
        DecimalTextBoxLabelui1.UsarSeparadorMiles = True
        ' 
        ' NumericTextBoxLabelui1
        ' 
        NumericTextBoxLabelui1.BackColor = Color.Transparent
        NumericTextBoxLabelui1.CampoRequerido = False
        NumericTextBoxLabelui1.CapitalizarTexto = False
        NumericTextBoxLabelui1.CapitalizarTodasLasPalabras = False
        NumericTextBoxLabelui1.IconoColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        NumericTextBoxLabelui1.IconoDerechoChar = FontAwesome.Sharp.IconChar.Hashtag
        NumericTextBoxLabelui1.Location = New Point(70, 206)
        NumericTextBoxLabelui1.MaxCaracteres = 0
        NumericTextBoxLabelui1.MensajeError = "Campo requerido."
        NumericTextBoxLabelui1.Name = "NumericTextBoxLabelui1"
        NumericTextBoxLabelui1.Placeholder = "Ingrese Número"
        NumericTextBoxLabelui1.PlaceholderColor = Color.Gray
        NumericTextBoxLabelui1.Size = New Size(406, 76)
        NumericTextBoxLabelui1.TabIndex = 2
        NumericTextBoxLabelui1.TextoLabel = "Número:"
        ' 
        ' prueba
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(937, 512)
        Controls.Add(NumericTextBoxLabelui1)
        Controls.Add(DecimalTextBoxLabelui1)
        Controls.Add(TextOnlyTextBoxLabelui1)
        Name = "prueba"
        Text = "prueba"
        ResumeLayout(False)
    End Sub

    Friend WithEvents TextOnlyTextBoxLabelui1 As TextOnlyTextBoxLabelUI
    Friend WithEvents DecimalTextBoxLabelui1 As DecimalTextBoxLabelUI
    Friend WithEvents NumericTextBoxLabelui1 As NumericTextBoxLabelUI

End Class
