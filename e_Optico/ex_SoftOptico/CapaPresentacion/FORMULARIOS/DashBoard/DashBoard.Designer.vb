<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DashBoard
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
        tlySuperior = New TableLayoutPanel()
        lblLocalidad = New HeaderUI()
        lblEmpleado = New HeaderUI()
        lblTitulo = New HeaderUI()
        tlySuperior.SuspendLayout()
        SuspendLayout()
        ' 
        ' tlySuperior
        ' 
        tlySuperior.ColumnCount = 3
        tlySuperior.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333321F))
        tlySuperior.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333321F))
        tlySuperior.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333321F))
        tlySuperior.Controls.Add(lblLocalidad, 2, 0)
        tlySuperior.Controls.Add(lblEmpleado, 1, 0)
        tlySuperior.Controls.Add(lblTitulo, 0, 0)
        tlySuperior.Dock = DockStyle.Top
        tlySuperior.Location = New Point(0, 0)
        tlySuperior.Name = "tlySuperior"
        tlySuperior.RowCount = 1
        tlySuperior.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        tlySuperior.Size = New Size(1477, 64)
        tlySuperior.TabIndex = 2
        ' 
        ' lblLocalidad
        ' 
        lblLocalidad.BackColor = Color.Transparent
        lblLocalidad.ColorFondo = Color.White
        lblLocalidad.ColorTexto = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        lblLocalidad.Dimension = 12
        lblLocalidad.Dock = DockStyle.Fill
        lblLocalidad.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblLocalidad.Icono = FontAwesome.Sharp.IconChar.Eye
        lblLocalidad.Location = New Point(987, 3)
        lblLocalidad.MostrarSeparador = False
        lblLocalidad.Name = "lblLocalidad"
        lblLocalidad.Size = New Size(487, 58)
        lblLocalidad.Subtitulo = "Óptica Atlantico "
        lblLocalidad.TabIndex = 3
        lblLocalidad.Titulo = "Sistema de Integral de Gestion"
        ' 
        ' lblEmpleado
        ' 
        lblEmpleado.BackColor = Color.Transparent
        lblEmpleado.ColorFondo = Color.White
        lblEmpleado.ColorTexto = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        lblEmpleado.Dimension = 12
        lblEmpleado.Dock = DockStyle.Fill
        lblEmpleado.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblEmpleado.Icono = FontAwesome.Sharp.IconChar.Eye
        lblEmpleado.Location = New Point(495, 3)
        lblEmpleado.MostrarSeparador = False
        lblEmpleado.Name = "lblEmpleado"
        lblEmpleado.Size = New Size(486, 58)
        lblEmpleado.Subtitulo = "Óptica Atlantico "
        lblEmpleado.TabIndex = 2
        lblEmpleado.Titulo = "Sistema de Integral de Gestion"
        ' 
        ' lblTitulo
        ' 
        lblTitulo.BackColor = Color.Transparent
        lblTitulo.ColorFondo = Color.White
        lblTitulo.ColorTexto = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        lblTitulo.Dimension = 12
        lblTitulo.Dock = DockStyle.Fill
        lblTitulo.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitulo.Icono = FontAwesome.Sharp.IconChar.Eye
        lblTitulo.Location = New Point(3, 3)
        lblTitulo.MostrarSeparador = False
        lblTitulo.Name = "lblTitulo"
        lblTitulo.Size = New Size(486, 58)
        lblTitulo.Subtitulo = "Óptica Atlantico "
        lblTitulo.TabIndex = 0
        lblTitulo.Titulo = "Sistema de Integral de Gestion"
        ' 
        ' DashBoard
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1477, 798)
        Controls.Add(tlySuperior)
        Name = "DashBoard"
        Text = "DashBoard"
        tlySuperior.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents tlySuperior As TableLayoutPanel
    Friend WithEvents lblLocalidad As HeaderUI
    Friend WithEvents lblEmpleado As HeaderUI
    Friend WithEvents lblTitulo As HeaderUI
End Class
