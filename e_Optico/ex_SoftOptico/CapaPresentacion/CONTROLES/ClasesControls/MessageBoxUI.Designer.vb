<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MessageBoxUI
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        lblTitulo = New Label()
        lblMensaje = New Label()
        pnlBotones = New FlowLayoutPanel()
        icon = New FontAwesome.Sharp.IconPictureBox()
        CType(icon, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblTitulo
        ' 
        lblTitulo.AutoSize = True
        lblTitulo.Location = New Point(51, 160)
        lblTitulo.Name = "lblTitulo"
        lblTitulo.Size = New Size(41, 15)
        lblTitulo.TabIndex = 0
        lblTitulo.Text = "Label1"
        ' 
        ' lblMensaje
        ' 
        lblMensaje.AutoSize = True
        lblMensaje.Location = New Point(111, 187)
        lblMensaje.Name = "lblMensaje"
        lblMensaje.Size = New Size(41, 15)
        lblMensaje.TabIndex = 1
        lblMensaje.Text = "Label2"
        ' 
        ' pnlBotones
        ' 
        pnlBotones.Location = New Point(51, 19)
        pnlBotones.Name = "pnlBotones"
        pnlBotones.Size = New Size(200, 100)
        pnlBotones.TabIndex = 2
        ' 
        ' icon
        ' 
        icon.BackColor = SystemColors.Control
        icon.ForeColor = SystemColors.ControlText
        icon.IconChar = FontAwesome.Sharp.IconChar.None
        icon.IconColor = SystemColors.ControlText
        icon.IconFont = FontAwesome.Sharp.IconFont.Auto
        icon.Location = New Point(317, 47)
        icon.Name = "icon"
        icon.Size = New Size(32, 32)
        icon.TabIndex = 3
        icon.TabStop = False
        ' 
        ' MessageBoxUI
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(icon)
        Controls.Add(pnlBotones)
        Controls.Add(lblMensaje)
        Controls.Add(lblTitulo)
        Name = "MessageBoxUI"
        Size = New Size(390, 252)
        CType(icon, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTitulo As Label
    Friend WithEvents lblMensaje As Label
    Friend WithEvents pnlBotones As FlowLayoutPanel
    Friend WithEvents icon As FontAwesome.Sharp.IconPictureBox

End Class
