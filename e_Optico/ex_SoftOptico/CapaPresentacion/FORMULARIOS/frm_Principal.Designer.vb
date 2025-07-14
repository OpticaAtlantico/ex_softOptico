<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Principal
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
        components = New ComponentModel.Container()
        menuIconList = New ImageList(components)
        pnlEditarDatos = New Panel()
        ComboBoxLabelui1 = New ComboBoxLabelUI()
        TextBoxLabelui1 = New TextBoxLabelUI()
        pnlEditarDatos.SuspendLayout()
        SuspendLayout()
        ' 
        ' menuIconList
        ' 
        menuIconList.ColorDepth = ColorDepth.Depth32Bit
        menuIconList.ImageSize = New Size(16, 16)
        menuIconList.TransparentColor = Color.Transparent
        ' 
        ' pnlEditarDatos
        ' 
        pnlEditarDatos.BackColor = Color.FromArgb(CByte(51), CByte(51), CByte(80))
        pnlEditarDatos.Controls.Add(ComboBoxLabelui1)
        pnlEditarDatos.Controls.Add(TextBoxLabelui1)
        pnlEditarDatos.Dock = DockStyle.Fill
        pnlEditarDatos.Location = New Point(0, 0)
        pnlEditarDatos.Name = "pnlEditarDatos"
        pnlEditarDatos.Size = New Size(1132, 559)
        pnlEditarDatos.TabIndex = 5
        ' 
        ' ComboBoxLabelui1
        ' 
        ComboBoxLabelui1.BackColor = Color.Transparent
        ComboBoxLabelui1.BorderRadius = 5
        ComboBoxLabelui1.CampoRequerido = True
        ComboBoxLabelui1.ColorError = Color.Firebrick
        ComboBoxLabelui1.FontField = New Font("Century Gothic", 12F)
        ComboBoxLabelui1.LabelText = "Selecciona una opción:"
        ComboBoxLabelui1.Location = New Point(34, 24)
        ComboBoxLabelui1.MensajeError = "Este campo es obligatorio."
        ComboBoxLabelui1.Name = "ComboBoxLabelui1"
        ComboBoxLabelui1.Size = New Size(291, 76)
        ComboBoxLabelui1.TabIndex = 4
        ' 
        ' TextBoxLabelui1
        ' 
        TextBoxLabelui1.BackColor = Color.Transparent
        TextBoxLabelui1.BorderFlat = True
        TextBoxLabelui1.BorderRadius = 5
        TextBoxLabelui1.CampoRequerido = True
        TextBoxLabelui1.ColorError = Color.Firebrick
        TextBoxLabelui1.FontField = New Font("Century Gothic", 12F)
        TextBoxLabelui1.LabelText = "Texto:"
        TextBoxLabelui1.Location = New Point(331, 24)
        TextBoxLabelui1.MensajeError = "Este campo no puede quedar vacío."
        TextBoxLabelui1.Name = "TextBoxLabelui1"
        TextBoxLabelui1.PaddingAll = 15
        TextBoxLabelui1.PanelBackColor = Color.FromArgb(CByte(80), CByte(94), CByte(129))
        TextBoxLabelui1.PlaceholderColor = Color.Gray
        TextBoxLabelui1.PlaceholderFont = New Font("Century Gothic", 12F, FontStyle.Italic)
        TextBoxLabelui1.PlaceholderText = "Escribe algo..."
        TextBoxLabelui1.Size = New Size(414, 82)
        TextBoxLabelui1.TabIndex = 0
        TextBoxLabelui1.TextColor = Color.WhiteSmoke
        ' 
        ' frm_Principal
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1132, 559)
        Controls.Add(pnlEditarDatos)
        Name = "frm_Principal"
        Text = "frm_Principal"
        pnlEditarDatos.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents menuIconList As ImageList
    Friend WithEvents pnlEditarDatos As Panel
    Friend WithEvents TextBoxLabelui1 As TextBoxLabelUI
    Friend WithEvents ComboBoxLabelui1 As ComboBoxLabelUI
    Friend WithEvents btnAceptar As MaterialSkin.Controls.MaterialButton
End Class
