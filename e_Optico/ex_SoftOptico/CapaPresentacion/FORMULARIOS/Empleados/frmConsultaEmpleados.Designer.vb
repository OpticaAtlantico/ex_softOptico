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
        dgvDatosProveedor = New DataGridViewUI()
        SuspendLayout()
        ' 
        ' dgvDatosProveedor
        ' 
        dgvDatosProveedor.BackColor = Color.WhiteSmoke
        dgvDatosProveedor.DataCompleta = Nothing
        dgvDatosProveedor.DataOriginal = Nothing
        dgvDatosProveedor.Dock = DockStyle.Fill
        dgvDatosProveedor.Location = New Point(0, 0)
        dgvDatosProveedor.MetodoCargaDatos = Nothing
        dgvDatosProveedor.Name = "dgvDatosProveedor"
        dgvDatosProveedor.Size = New Size(1251, 507)
        dgvDatosProveedor.TabIndex = 0
        ' 
        ' frmConsultaEmpleados
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1251, 507)
        Controls.Add(dgvDatosProveedor)
        Name = "frmConsultaEmpleados"
        Text = "frm_ConsultaEmpleados"
        WindowState = FormWindowState.Maximized
        ResumeLayout(False)
    End Sub

    Friend WithEvents dgvDatosProveedor As DataGridViewUI
End Class
