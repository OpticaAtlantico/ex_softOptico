<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNuevoEmpleado
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
        pnlContenedor = New FlowLayoutPanel()
        TextBoxLabelui1 = New TextBoxLabelUI()
        txtUsuario = New TextBoxLabelUI()
        TextBoxLabelui2 = New TextBoxLabelUI()
        SuspendLayout()
        ' 
        ' pnlContenedor
        ' 
        pnlContenedor.AutoScroll = True
        pnlContenedor.BackColor = Color.Black
        pnlContenedor.Location = New Point(397, 143)
        pnlContenedor.Name = "pnlContenedor"
        pnlContenedor.Size = New Size(334, 167)
        pnlContenedor.TabIndex = 0
        ' 
        ' TextBoxLabelui1
        ' 
        TextBoxLabelui1.BackColor = Color.Transparent
        TextBoxLabelui1.BorderColor = Color.LightGray
        TextBoxLabelui1.BorderRadius = 5
        TextBoxLabelui1.BorderSize = 1
        TextBoxLabelui1.CampoRequerido = True
        TextBoxLabelui1.CaracterContraseña = "*"c
        TextBoxLabelui1.ColorError = Color.Firebrick
        TextBoxLabelui1.FontField = New Font("Century Gothic", 12F)
        TextBoxLabelui1.IconoColor = Color.White
        TextBoxLabelui1.IconoDerechoChar = FontAwesome.Sharp.IconChar.CircleInfo
        TextBoxLabelui1.LabelText = "Texto:"
        TextBoxLabelui1.Location = New Point(51, 333)
        TextBoxLabelui1.MensajeError = "Este campo es obligatorio."
        TextBoxLabelui1.Name = "TextBoxLabelui1"
        TextBoxLabelui1.PaddingAll = 10
        TextBoxLabelui1.PanelBackColor = Color.FromArgb(CByte(80), CByte(94), CByte(129))
        TextBoxLabelui1.Size = New Size(319, 74)
        TextBoxLabelui1.TabIndex = 1
        TextBoxLabelui1.TextColor = Color.WhiteSmoke
        TextBoxLabelui1.UsarModoContraseña = False
        ' 
        ' txtUsuario
        ' 
        txtUsuario.BackColor = Color.Transparent
        txtUsuario.BorderColor = Color.LightGray
        txtUsuario.BorderRadius = 5
        txtUsuario.BorderSize = 1
        txtUsuario.CampoRequerido = True
        txtUsuario.CaracterContraseña = "*"c
        txtUsuario.ColorError = Color.Firebrick
        txtUsuario.FontField = New Font("Century Gothic", 12F)
        txtUsuario.ForeColor = SystemColors.ControlText
        txtUsuario.IconoColor = Color.White
        txtUsuario.IconoDerechoChar = FontAwesome.Sharp.IconChar.UserCheck
        txtUsuario.LabelText = "Usuario"
        txtUsuario.Location = New Point(494, 333)
        txtUsuario.MensajeError = "Usuario desconocido..."
        txtUsuario.Name = "txtUsuario"
        txtUsuario.PaddingAll = 10
        txtUsuario.PanelBackColor = Color.FromArgb(CByte(80), CByte(94), CByte(129))
        txtUsuario.Size = New Size(372, 106)
        txtUsuario.TabIndex = 2
        txtUsuario.TextColor = Color.WhiteSmoke
        txtUsuario.UsarModoContraseña = False
        ' 
        ' TextBoxLabelui2
        ' 
        TextBoxLabelui2.BackColor = Color.Transparent
        TextBoxLabelui2.BorderColor = Color.DarkCyan
        TextBoxLabelui2.BorderRadius = 8
        TextBoxLabelui2.BorderSize = 1
        TextBoxLabelui2.CampoRequerido = True
        TextBoxLabelui2.CaracterContraseña = "*"c
        TextBoxLabelui2.ColorError = Color.Firebrick
        TextBoxLabelui2.FontField = New Font("Century Gothic", 12F)
        TextBoxLabelui2.IconoColor = Color.White
        TextBoxLabelui2.IconoDerechoChar = FontAwesome.Sharp.IconChar.CircleInfo
        TextBoxLabelui2.LabelText = "Texto:"
        TextBoxLabelui2.Location = New Point(466, 41)
        TextBoxLabelui2.MensajeError = "Este campo es obligatorio."
        TextBoxLabelui2.Name = "TextBoxLabelui2"
        TextBoxLabelui2.PaddingAll = 10
        TextBoxLabelui2.PanelBackColor = Color.WhiteSmoke
        TextBoxLabelui2.Size = New Size(346, 85)
        TextBoxLabelui2.TabIndex = 3
        TextBoxLabelui2.TextColor = Color.WhiteSmoke
        TextBoxLabelui2.UsarModoContraseña = False
        ' 
        ' frmNuevoEmpleado
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1190, 512)
        Controls.Add(TextBoxLabelui2)
        Controls.Add(txtUsuario)
        Controls.Add(TextBoxLabelui1)
        Controls.Add(pnlContenedor)
        Name = "frmNuevoEmpleado"
        Text = "frmNuevoEmpleado"
        ResumeLayout(False)
    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents pnlContenedor As FlowLayoutPanel
    Friend WithEvents TextBoxLabelui1 As TextBoxLabelUI
    Friend WithEvents txtUsuario As TextBoxLabelUI
    Friend WithEvents TextBoxLabelui2 As TextBoxLabelUI
End Class
