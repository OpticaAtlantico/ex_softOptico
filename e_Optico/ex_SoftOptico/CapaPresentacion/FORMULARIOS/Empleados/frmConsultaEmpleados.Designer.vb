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
        dgvDatosEmpleados = New DataGridViewUI()
        SuspendLayout()
        ' 
        ' dgvDatosEmpleados
        ' 
        dgvDatosEmpleados.BackColor = Color.WhiteSmoke
        dgvDatosEmpleados.DataCompleta = Nothing
        dgvDatosEmpleados.DataOriginal = Nothing
        dgvDatosEmpleados.Dock = DockStyle.Fill
        dgvDatosEmpleados.Location = New Point(0, 0)
        dgvDatosEmpleados.Name = "dgvDatosEmpleados"
        dgvDatosEmpleados.Size = New Size(1251, 507)
        dgvDatosEmpleados.TabIndex = 0
        ' 
        ' frmConsultaEmpleados
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1251, 507)
        Controls.Add(dgvDatosEmpleados)
        Name = "frmConsultaEmpleados"
        Text = "frm_ConsultaEmpleados"
        ResumeLayout(False)
    End Sub

    Friend WithEvents dgvDatosEmpleados As DataGridViewUI
End Class
