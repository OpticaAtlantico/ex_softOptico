<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ComboBoxModerno
    Inherits System.Windows.Forms.ComboBox

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
    Public Property AutoScaleDimensions As SizeF

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent(AutoScaleMode As AutoScaleMode)
        SuspendLayout()
        ' 
        ' ComboBoxModerno
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        Name = "ComboBoxModerno"
        ResumeLayout(False)
    End Sub

End Class
