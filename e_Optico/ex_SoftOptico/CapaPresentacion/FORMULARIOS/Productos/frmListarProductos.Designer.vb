<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListarProductos
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
        pnlContenedor = New Panel()
        pnlEncabezado = New Panel()
        pnlContenido = New Panel()
        dgvProductos = New DataGridView()
        pnlContenedor.SuspendLayout()
        pnlContenido.SuspendLayout()
        CType(dgvProductos, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pnlContenedor
        ' 
        pnlContenedor.Controls.Add(pnlContenido)
        pnlContenedor.Controls.Add(pnlEncabezado)
        pnlContenedor.Dock = DockStyle.Fill
        pnlContenedor.Location = New Point(0, 0)
        pnlContenedor.Name = "pnlContenedor"
        pnlContenedor.Padding = New Padding(15)
        pnlContenedor.Size = New Size(705, 739)
        pnlContenedor.TabIndex = 0
        ' 
        ' pnlEncabezado
        ' 
        pnlEncabezado.Dock = DockStyle.Top
        pnlEncabezado.Location = New Point(15, 15)
        pnlEncabezado.Name = "pnlEncabezado"
        pnlEncabezado.Size = New Size(675, 67)
        pnlEncabezado.TabIndex = 0
        ' 
        ' pnlContenido
        ' 
        pnlContenido.Controls.Add(dgvProductos)
        pnlContenido.Dock = DockStyle.Fill
        pnlContenido.Location = New Point(15, 82)
        pnlContenido.Name = "pnlContenido"
        pnlContenido.Size = New Size(675, 642)
        pnlContenido.TabIndex = 1
        ' 
        ' dgvProductos
        ' 
        dgvProductos.BackgroundColor = Color.WhiteSmoke
        dgvProductos.BorderStyle = BorderStyle.None
        dgvProductos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvProductos.Dock = DockStyle.Fill
        dgvProductos.Location = New Point(0, 0)
        dgvProductos.Name = "dgvProductos"
        dgvProductos.Size = New Size(675, 642)
        dgvProductos.TabIndex = 0
        ' 
        ' frmListarProductos
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(705, 739)
        Controls.Add(pnlContenedor)
        Name = "frmListarProductos"
        Text = "frmListarProductos"
        pnlContenedor.ResumeLayout(False)
        pnlContenido.ResumeLayout(False)
        CType(dgvProductos, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlContenedor As Panel
    Friend WithEvents pnlContenido As Panel
    Friend WithEvents dgvProductos As DataGridView
    Friend WithEvents pnlEncabezado As Panel
End Class
