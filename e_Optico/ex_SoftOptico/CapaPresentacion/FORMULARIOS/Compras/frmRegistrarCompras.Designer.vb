<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegistrarCompras
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
        pnlContenido = New Panel()
        pnlEncabezado = New Panel()
        lblTitulo = New HeaderUI()
        btnExportarPdf = New CommandButtonUI()
        btnExportarExcel = New CommandButtonUI()
        btnAceptar = New CommandButtonUI()
        pnlEncabezado.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlContenido
        ' 
        pnlContenido.BackColor = Color.WhiteSmoke
        pnlContenido.Dock = DockStyle.Fill
        pnlContenido.Location = New Point(0, 57)
        pnlContenido.Name = "pnlContenido"
        pnlContenido.Size = New Size(1218, 539)
        pnlContenido.TabIndex = 4
        ' 
        ' pnlEncabezado
        ' 
        pnlEncabezado.BackColor = SystemColors.ActiveCaptionText
        pnlEncabezado.Controls.Add(btnExportarPdf)
        pnlEncabezado.Controls.Add(btnExportarExcel)
        pnlEncabezado.Controls.Add(btnAceptar)
        pnlEncabezado.Controls.Add(lblTitulo)
        pnlEncabezado.Dock = DockStyle.Top
        pnlEncabezado.Location = New Point(0, 0)
        pnlEncabezado.Name = "pnlEncabezado"
        pnlEncabezado.Size = New Size(1218, 57)
        pnlEncabezado.TabIndex = 3
        ' 
        ' lblTitulo
        ' 
        lblTitulo.ColorFondo = Color.FromArgb(CByte(240), CByte(240), CByte(240))
        lblTitulo.ColorTexto = Color.FromArgb(CByte(45), CByte(45), CByte(45))
        lblTitulo.Dimension = 12
        lblTitulo.Dock = DockStyle.Fill
        lblTitulo.Font = New Font("Century Gothic", 10F, FontStyle.Bold)
        lblTitulo.Icono = FontAwesome.Sharp.IconChar.CircleInfo
        lblTitulo.Location = New Point(0, 0)
        lblTitulo.MostrarSeparador = True
        lblTitulo.Name = "lblTitulo"
        lblTitulo.Size = New Size(1218, 57)
        lblTitulo.Subtitulo = "Subtítulo opcional"
        lblTitulo.TabIndex = 0
        lblTitulo.Text = "Headerui1"
        lblTitulo.Titulo = "Título Principal"
        ' 
        ' btnExportarPdf
        ' 
        btnExportarPdf.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnExportarPdf.AnimarHover = True
        btnExportarPdf.BackColor = Color.WhiteSmoke
        btnExportarPdf.ColorBase = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        btnExportarPdf.ColorHover = Color.FromArgb(CByte(67), CByte(160), CByte(71))
        btnExportarPdf.ColorInternoFondo = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        btnExportarPdf.ColorPresionado = Color.FromArgb(CByte(56), CByte(142), CByte(60))
        btnExportarPdf.ColorTexto = Color.WhiteSmoke
        btnExportarPdf.EstiloBoton = CommandButtonUI.EstiloBootstrap.Success
        btnExportarPdf.Font = New Font("Century Gothic", 10F, FontStyle.Bold)
        btnExportarPdf.Icono = FontAwesome.Sharp.IconChar.FilePdf
        btnExportarPdf.Location = New Point(758, 8)
        btnExportarPdf.Name = "btnExportarPdf"
        btnExportarPdf.RadioBorde = 8
        btnExportarPdf.Size = New Size(144, 38)
        btnExportarPdf.TabIndex = 1
        btnExportarPdf.Text = "CommandButtonui1"
        btnExportarPdf.Texto = "Ex. PDFs"
        ' 
        ' btnExportarExcel
        ' 
        btnExportarExcel.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnExportarExcel.AnimarHover = True
        btnExportarExcel.BackColor = Color.WhiteSmoke
        btnExportarExcel.ColorBase = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        btnExportarExcel.ColorHover = Color.FromArgb(CByte(67), CByte(160), CByte(71))
        btnExportarExcel.ColorInternoFondo = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        btnExportarExcel.ColorPresionado = Color.FromArgb(CByte(56), CByte(142), CByte(60))
        btnExportarExcel.ColorTexto = Color.WhiteSmoke
        btnExportarExcel.EstiloBoton = CommandButtonUI.EstiloBootstrap.Success
        btnExportarExcel.Font = New Font("Century Gothic", 10F, FontStyle.Bold)
        btnExportarExcel.Icono = FontAwesome.Sharp.IconChar.FileExcel
        btnExportarExcel.Location = New Point(910, 8)
        btnExportarExcel.Name = "btnExportarExcel"
        btnExportarExcel.RadioBorde = 8
        btnExportarExcel.Size = New Size(144, 38)
        btnExportarExcel.TabIndex = 2
        btnExportarExcel.Text = "CommandButtonui1"
        btnExportarExcel.Texto = " Ex. Excel"
        ' 
        ' btnAceptar
        ' 
        btnAceptar.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnAceptar.AnimarHover = True
        btnAceptar.BackColor = Color.WhiteSmoke
        btnAceptar.ColorBase = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        btnAceptar.ColorHover = Color.FromArgb(CByte(67), CByte(160), CByte(71))
        btnAceptar.ColorInternoFondo = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        btnAceptar.ColorPresionado = Color.FromArgb(CByte(56), CByte(142), CByte(60))
        btnAceptar.ColorTexto = Color.WhiteSmoke
        btnAceptar.EstiloBoton = CommandButtonUI.EstiloBootstrap.Success
        btnAceptar.Font = New Font("Century Gothic", 10F, FontStyle.Bold)
        btnAceptar.Icono = FontAwesome.Sharp.IconChar.Save
        btnAceptar.Location = New Point(1062, 8)
        btnAceptar.Name = "btnAceptar"
        btnAceptar.RadioBorde = 8
        btnAceptar.Size = New Size(144, 38)
        btnAceptar.TabIndex = 3
        btnAceptar.Text = "CommandButtonui1"
        btnAceptar.Texto = "Guardar"
        ' 
        ' frmRegistrarCompras
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1218, 596)
        Controls.Add(pnlContenido)
        Controls.Add(pnlEncabezado)
        Name = "frmRegistrarCompras"
        Text = "frmRegistrarCompras"
        pnlEncabezado.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents pnlContenido As Panel
    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents lblTitulo As HeaderUI
    Friend WithEvents btnExportarPdf As CommandButtonUI
    Friend WithEvents btnExportarExcel As CommandButtonUI
    Friend WithEvents btnAceptar As CommandButtonUI
End Class
