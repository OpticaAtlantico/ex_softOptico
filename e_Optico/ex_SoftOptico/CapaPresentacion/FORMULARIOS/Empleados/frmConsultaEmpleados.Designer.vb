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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaEmpleados))
        dgvDatosEmpleado = New DataGridViewUI()
        SuspendLayout()
        ' 
        ' dgvDatosEmpleado
        ' 
        dgvDatosEmpleado.BackColor = Color.WhiteSmoke
        dgvDatosEmpleado.DataCompleta = Nothing
        dgvDatosEmpleado.DataOriginal = Nothing
        dgvDatosEmpleado.Dock = DockStyle.Fill
        dgvDatosEmpleado.IconosPorAccion = CType(resources.GetObject("dgvDatosEmpleado.IconosPorAccion"), Dictionary(Of String, FontAwesome.Sharp.IconChar))
        dgvDatosEmpleado.Location = New Point(0, 0)
        dgvDatosEmpleado.MetodoCargaDatos = Nothing
        dgvDatosEmpleado.Name = "dgvDatosEmpleado"
        dgvDatosEmpleado.Size = New Size(1251, 507)
        dgvDatosEmpleado.TabIndex = 0
        ' 
        ' frmConsultaEmpleados
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1251, 507)
        Controls.Add(dgvDatosEmpleado)
        Name = "frmConsultaEmpleados"
        Text = "frm_ConsultaEmpleados"
        WindowState = FormWindowState.Maximized
        ResumeLayout(False)
    End Sub

    Friend WithEvents dgvDatosEmpleado As DataGridViewUI
End Class
