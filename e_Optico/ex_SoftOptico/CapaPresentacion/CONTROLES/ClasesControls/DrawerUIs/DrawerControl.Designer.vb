<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DrawerControl
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
        pnlOpciones = New Panel()
        SuspendLayout()
        ' 
        ' pnlOpciones
        ' 
        pnlOpciones.BackColor = Color.White
        pnlOpciones.Dock = DockStyle.Fill
        pnlOpciones.Location = New Point(0, 0)
        pnlOpciones.Name = "pnlOpciones"
        pnlOpciones.Size = New Size(126, 543)
        pnlOpciones.TabIndex = 0
        ' 
        ' DrawerControl
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(pnlOpciones)
        Name = "DrawerControl"
        Size = New Size(126, 543)
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlOpciones As Panel

End Class
