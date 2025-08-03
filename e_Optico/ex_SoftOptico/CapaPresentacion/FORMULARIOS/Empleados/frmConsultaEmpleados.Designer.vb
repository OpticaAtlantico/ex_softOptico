<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaEmpleados
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
        DataGridViewui1 = New DataGridViewUI()
        SuspendLayout()
        ' 
        ' DataGridViewui1
        ' 
        DataGridViewui1.BackColor = Color.WhiteSmoke
        DataGridViewui1.DataCompleta = Nothing
        DataGridViewui1.DataOriginal = Nothing
        DataGridViewui1.Dock = DockStyle.Fill
        DataGridViewui1.Location = New Point(0, 0)
        DataGridViewui1.Name = "DataGridViewui1"
        DataGridViewui1.Size = New Size(1204, 447)
        DataGridViewui1.TabIndex = 0
        ' 
        ' frmConsultaEmpleados
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1204, 447)
        Controls.Add(DataGridViewui1)
        Name = "frmConsultaEmpleados"
        Text = "frm_ConsultaEmpleados"
        ResumeLayout(False)
    End Sub

    Friend WithEvents DataGridViewui1 As DataGridViewUI
End Class
