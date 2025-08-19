<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDetallesCompra
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
        pnlMove = New Panel()
        pnlContenedor = New Panel()
        SuspendLayout()
        ' 
        ' pnlMove
        ' 
        pnlMove.BackColor = Color.FromArgb(CByte(0), CByte(192), CByte(190))
        pnlMove.Dock = DockStyle.Top
        pnlMove.Location = New Point(0, 0)
        pnlMove.Name = "pnlMove"
        pnlMove.Size = New Size(955, 27)
        pnlMove.TabIndex = 0
        ' 
        ' pnlContenedor
        ' 
        pnlContenedor.Dock = DockStyle.Fill
        pnlContenedor.Location = New Point(0, 27)
        pnlContenedor.Name = "pnlContenedor"
        pnlContenedor.Size = New Size(955, 458)
        pnlContenedor.TabIndex = 1
        ' 
        ' frmDetallesCompra
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(955, 485)
        Controls.Add(pnlContenedor)
        Controls.Add(pnlMove)
        FormBorderStyle = FormBorderStyle.None
        Name = "frmDetallesCompra"
        StartPosition = FormStartPosition.CenterScreen
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlMove As Panel
    Friend WithEvents pnlContenedor As Panel
End Class
