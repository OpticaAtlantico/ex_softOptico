<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductos
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
        pnlEncabezado = New Panel()
        Panel2 = New Panel()
        pnlContenido = New Panel()
        pnlEncabezado.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlEncabezado
        ' 
        pnlEncabezado.BackColor = SystemColors.ActiveCaptionText
        pnlEncabezado.Controls.Add(Panel2)
        pnlEncabezado.Dock = DockStyle.Top
        pnlEncabezado.Location = New Point(0, 0)
        pnlEncabezado.Name = "pnlEncabezado"
        pnlEncabezado.Size = New Size(1084, 14)
        pnlEncabezado.TabIndex = 0
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.FromArgb(CByte(23), CByte(187), CByte(255))
        Panel2.Dock = DockStyle.Fill
        Panel2.Location = New Point(0, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1084, 14)
        Panel2.TabIndex = 1
        ' 
        ' pnlContenido
        ' 
        pnlContenido.Dock = DockStyle.Fill
        pnlContenido.Location = New Point(0, 14)
        pnlContenido.Name = "pnlContenido"
        pnlContenido.Size = New Size(1084, 531)
        pnlContenido.TabIndex = 2
        ' 
        ' frmProductos
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1084, 545)
        Controls.Add(pnlContenido)
        Controls.Add(pnlEncabezado)
        Name = "frmProductos"
        Text = "frmProductos"
        pnlEncabezado.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents pnlContenido As Panel
    Friend WithEvents Panel2 As Panel
End Class
