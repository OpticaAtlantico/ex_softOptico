<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class moduloProductos
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
        Panel1 = New Panel()
        Headerui1 = New HeaderUI()
        Panel2 = New Panel()
        Panel3 = New Panel()
        CommandButtonui2 = New CommandButtonUI()
        CommandButtonui1 = New CommandButtonUI()
        Panel1.SuspendLayout()
        Panel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(Headerui1)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(828, 59)
        Panel1.TabIndex = 0
        ' 
        ' Headerui1
        ' 
        Headerui1.ColorFondo = Color.FromArgb(CByte(240), CByte(240), CByte(240))
        Headerui1.ColorTexto = Color.FromArgb(CByte(45), CByte(45), CByte(45))
        Headerui1.Dock = DockStyle.Fill
        Headerui1.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Headerui1.Icono = FontAwesome.Sharp.IconChar.CircleInfo
        Headerui1.Location = New Point(0, 0)
        Headerui1.MostrarSeparador = True
        Headerui1.Name = "Headerui1"
        Headerui1.Size = New Size(828, 59)
        Headerui1.Subtitulo = "Subtítulo opcional"
        Headerui1.TabIndex = 0
        Headerui1.Text = "Headerui1"
        Headerui1.Titulo = "Título Principal"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.FromArgb(CByte(0), CByte(192), CByte(192))
        Panel2.Dock = DockStyle.Fill
        Panel2.Location = New Point(0, 59)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(828, 389)
        Panel2.TabIndex = 0
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(CommandButtonui2)
        Panel3.Controls.Add(CommandButtonui1)
        Panel3.Dock = DockStyle.Bottom
        Panel3.Location = New Point(0, 371)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(828, 77)
        Panel3.TabIndex = 0
        ' 
        ' CommandButtonui2
        ' 
        CommandButtonui2.AnimarHover = True
        CommandButtonui2.BackColor = Color.Transparent
        CommandButtonui2.ColorBase = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        CommandButtonui2.ColorHover = Color.FromArgb(CByte(67), CByte(160), CByte(71))
        CommandButtonui2.ColorInternoFondo = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        CommandButtonui2.ColorPresionado = Color.FromArgb(CByte(56), CByte(142), CByte(60))
        CommandButtonui2.ColorTexto = Color.White
        CommandButtonui2.EstiloBoton = CommandButtonUI.EstiloBootstrap.Success
        CommandButtonui2.Font = New Font("Century Gothic", 10F, FontStyle.Bold)
        CommandButtonui2.Icono = FontAwesome.Sharp.IconChar.CheckCircle
        CommandButtonui2.Location = New Point(380, 17)
        CommandButtonui2.Name = "CommandButtonui2"
        CommandButtonui2.RadioBorde = 8
        CommandButtonui2.Size = New Size(153, 46)
        CommandButtonui2.TabIndex = 0
        CommandButtonui2.Text = "CommandButtonui1"
        CommandButtonui2.Texto = "Aceptar"
        ' 
        ' CommandButtonui1
        ' 
        CommandButtonui1.AnimarHover = True
        CommandButtonui1.BackColor = Color.Transparent
        CommandButtonui1.ColorBase = Color.FromArgb(CByte(33), CByte(150), CByte(243))
        CommandButtonui1.ColorHover = Color.FromArgb(CByte(30), CByte(136), CByte(229))
        CommandButtonui1.ColorInternoFondo = Color.FromArgb(CByte(33), CByte(150), CByte(243))
        CommandButtonui1.ColorPresionado = Color.FromArgb(CByte(25), CByte(118), CByte(210))
        CommandButtonui1.ColorTexto = Color.White
        CommandButtonui1.EstiloBoton = CommandButtonUI.EstiloBootstrap.Primary
        CommandButtonui1.Font = New Font("Century Gothic", 10F, FontStyle.Bold)
        CommandButtonui1.Icono = FontAwesome.Sharp.IconChar.Bolt
        CommandButtonui1.Location = New Point(550, 17)
        CommandButtonui1.Name = "CommandButtonui1"
        CommandButtonui1.RadioBorde = 8
        CommandButtonui1.Size = New Size(153, 46)
        CommandButtonui1.TabIndex = 0
        CommandButtonui1.Text = "CommandButtonui1"
        CommandButtonui1.Texto = "Aceptar"
        ' 
        ' moduloProductos
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Name = "moduloProductos"
        Size = New Size(828, 448)
        Panel1.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Headerui1 As HeaderUI
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents CommandButtonui2 As CommandButtonUI
    Friend WithEvents CommandButtonui1 As CommandButtonUI

End Class
