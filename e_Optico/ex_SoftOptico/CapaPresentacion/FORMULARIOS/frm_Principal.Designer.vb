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
        TextBoxLabel2ui1 = New TextBoxLabel2UI()
        TextBoxLabel2ui2 = New TextBoxLabel2UI()
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
        pnlEditarDatos.Controls.Add(TextBoxLabel2ui2)
        pnlEditarDatos.Controls.Add(TextBoxLabel2ui1)
        pnlEditarDatos.Dock = DockStyle.Fill
        pnlEditarDatos.Location = New Point(0, 0)
        pnlEditarDatos.Name = "pnlEditarDatos"
        pnlEditarDatos.Size = New Size(1132, 559)
        pnlEditarDatos.TabIndex = 5
        ' 
        ' TextBoxLabel2ui1
        ' 
        TextBoxLabel2ui1.BackColor = Color.Transparent
        TextBoxLabel2ui1.BorderFlat = True
        TextBoxLabel2ui1.BorderRadius = 10
        TextBoxLabel2ui1.CampoRequerido = True
        TextBoxLabel2ui1.ColorError = Color.Firebrick
        TextBoxLabel2ui1.FontField = New Font("Segoe UI", 10F)
        TextBoxLabel2ui1.ForeColor = Color.White
        TextBoxLabel2ui1.LabelText = "Texto:"
        TextBoxLabel2ui1.Location = New Point(32, 45)
        TextBoxLabel2ui1.MensajeError = "Este campo no puede quedar vacío."
        TextBoxLabel2ui1.Name = "TextBoxLabel2ui1"
        TextBoxLabel2ui1.PaddingAll = 15
        TextBoxLabel2ui1.PanelBackColor = Color.DimGray
        TextBoxLabel2ui1.PlaceholderColor = Color.White
        TextBoxLabel2ui1.PlaceholderFont = New Font("Segoe UI", 10F, FontStyle.Italic)
        TextBoxLabel2ui1.PlaceholderText = "Escribe algo..."
        TextBoxLabel2ui1.Size = New Size(306, 89)
        TextBoxLabel2ui1.TabIndex = 0
        TextBoxLabel2ui1.TextColor = Color.Blue
        ' 
        ' TextBoxLabel2ui2
        ' 
        TextBoxLabel2ui2.BackColor = Color.Transparent
        TextBoxLabel2ui2.BorderFlat = True
        TextBoxLabel2ui2.BorderRadius = 10
        TextBoxLabel2ui2.CampoRequerido = True
        TextBoxLabel2ui2.ColorError = Color.Firebrick
        TextBoxLabel2ui2.FontField = New Font("Segoe UI", 10F)
        TextBoxLabel2ui2.ForeColor = Color.White
        TextBoxLabel2ui2.LabelText = "Texto:"
        TextBoxLabel2ui2.Location = New Point(394, 45)
        TextBoxLabel2ui2.MensajeError = "Este campo no puede quedar vacío."
        TextBoxLabel2ui2.Name = "TextBoxLabel2ui2"
        TextBoxLabel2ui2.PaddingAll = 15
        TextBoxLabel2ui2.PanelBackColor = Color.DimGray
        TextBoxLabel2ui2.PlaceholderColor = Color.White
        TextBoxLabel2ui2.PlaceholderFont = New Font("Segoe UI", 10F, FontStyle.Italic)
        TextBoxLabel2ui2.PlaceholderText = "Escribe algo..."
        TextBoxLabel2ui2.Size = New Size(306, 89)
        TextBoxLabel2ui2.TabIndex = 0
        TextBoxLabel2ui2.TextColor = Color.Blue
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
    Friend WithEvents TextBoxLabel2ui1 As TextBoxLabel2UI
    Friend WithEvents TextBoxLabel2ui2 As TextBoxLabel2UI
End Class
