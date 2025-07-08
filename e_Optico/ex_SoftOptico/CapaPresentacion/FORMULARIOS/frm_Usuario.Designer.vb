Imports MaterialSkin.Controls
Imports MaterialSkin

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Usuario
    'Inherits System.Windows.Forms.Form
    Inherits MaterialForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        pnlPrincipal = New Panel()
        pnlDatos = New Panel()
        pnlPrincipal.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlPrincipal
        ' 
        pnlPrincipal.Controls.Add(pnlDatos)
        pnlPrincipal.Dock = DockStyle.Left
        pnlPrincipal.Location = New Point(3, 64)
        pnlPrincipal.Name = "pnlPrincipal"
        pnlPrincipal.Padding = New Padding(10)
        pnlPrincipal.Size = New Size(564, 682)
        pnlPrincipal.TabIndex = 0
        ' 
        ' pnlDatos
        ' 
        pnlDatos.Dock = DockStyle.Fill
        pnlDatos.Location = New Point(10, 10)
        pnlDatos.Name = "pnlDatos"
        pnlDatos.Size = New Size(544, 662)
        pnlDatos.TabIndex = 0
        ' 
        ' frm_Usuario
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1370, 749)
        Controls.Add(pnlPrincipal)
        DrawerIsOpen = True
        MaximizeBox = False
        MinimizeBox = False
        Name = "frm_Usuario"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Administración Empleados..."
        TopMost = True
        pnlPrincipal.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlPrincipal As Panel
    Friend WithEvents pnlDatos As Panel
End Class
