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
        DateTextBoxLabelui2 = New DateTextBoxLabelUI()
        MultilineTextBoxLabelui1 = New MultilineTextBoxLabelUI()
        SuspendLayout()
        ' 
        ' DateTextBoxLabelui2
        ' 
        DateTextBoxLabelui2.BackColor = Color.Transparent
        DateTextBoxLabelui2.CampoRequerido = False
        DateTextBoxLabelui2.CapitalizarTexto = False
        DateTextBoxLabelui2.CapitalizarTodasLasPalabras = False
        DateTextBoxLabelui2.Location = New Point(335, 326)
        DateTextBoxLabelui2.MaxCaracteres = 0
        DateTextBoxLabelui2.MensajeError = "Campo requerido."
        DateTextBoxLabelui2.Name = "DateTextBoxLabelui2"
        DateTextBoxLabelui2.Placeholder = ""
        DateTextBoxLabelui2.PlaceholderColor = Color.Gray
        DateTextBoxLabelui2.Size = New Size(221, 76)
        DateTextBoxLabelui2.TabIndex = 1
        DateTextBoxLabelui2.TextoLabel = "Fecha:"
        DateTextBoxLabelui2.Value = New Date(2025, 9, 11, 3, 17, 39, 13)
        ' 
        ' MultilineTextBoxLabelui1
        ' 
        MultilineTextBoxLabelui1.AlturaMultilinea = 100
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
        MultilineTextBoxLabelui1.Location = New Point(102, 115)
        MultilineTextBoxLabelui1.MensajeError = "Este campo es requerido"
        MultilineTextBoxLabelui1.Multilinea = True
        MultilineTextBoxLabelui1.Name = "MultilineTextBoxLabelui1"
        MultilineTextBoxLabelui1.PaddingAll = 10
        MultilineTextBoxLabelui1.PanelBackColor = Color.White
        MultilineTextBoxLabelui1.Placeholder = "Escriba aquí..."
        MultilineTextBoxLabelui1.PlaceholderColor = Color.Gray
        MultilineTextBoxLabelui1.Size = New Size(479, 133)
        MultilineTextBoxLabelui1.SombraBackColor = Color.LightGray
        MultilineTextBoxLabelui1.TabIndex = 2
        MultilineTextBoxLabelui1.TextColor = Color.Black
        MultilineTextBoxLabelui1.TextoUsuario = ""
        ' 
        ' prueba
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(937, 512)
        Controls.Add(MultilineTextBoxLabelui1)
        Controls.Add(DateTextBoxLabelui2)
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
    Friend WithEvents DateTextBoxLabelui2 As DateTextBoxLabelUI
    Friend WithEvents MultilineTextBoxLabelui1 As MultilineTextBoxLabelUI
End Class
