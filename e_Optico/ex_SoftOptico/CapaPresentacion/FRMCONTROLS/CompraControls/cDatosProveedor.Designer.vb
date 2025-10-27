<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cDatosProveedor
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
        Label1 = New Label()
        TableLayoutPanel4 = New TableLayoutPanel()
        Panel3 = New Panel()
        btnGenerarCodigo = New FontAwesome.Sharp.IconButton()
        tlpFooter = New TableLayoutPanel()
        Panel5 = New Panel()
        btnSiguiente = New CommandButtonUI()
        CommandButtonui2 = New CommandButtonUI()
        Panel4 = New Panel()
        CommandButtonui1 = New CommandButtonUI()
        pnlBtnIzquierdo = New Panel()
        pnlBtnDerecho = New Panel()
        TableLayoutPanel2 = New TableLayoutPanel()
        Label2 = New Label()
        TableLayoutPanel3 = New TableLayoutPanel()
        tlpContenido = New TableLayoutPanel()
        Panelui1 = New PanelUI()
        TableLayoutPanel4.SuspendLayout()
        Panel3.SuspendLayout()
        tlpFooter.SuspendLayout()
        Panel5.SuspendLayout()
        Panel4.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        TableLayoutPanel3.SuspendLayout()
        tlpContenido.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.DarkSlateGray
        Label1.Location = New Point(3, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(141, 17)
        Label1.TabIndex = 35
        Label1.Text = "Requiere Inventario?"
        ' 
        ' TableLayoutPanel4
        ' 
        TableLayoutPanel4.ColumnCount = 2
        TableLayoutPanel4.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 80F))
        TableLayoutPanel4.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20F))
        TableLayoutPanel4.Controls.Add(Panel3, 1, 0)
        TableLayoutPanel4.Dock = DockStyle.Fill
        TableLayoutPanel4.Location = New Point(3, 3)
        TableLayoutPanel4.Name = "TableLayoutPanel4"
        TableLayoutPanel4.RowCount = 1
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel4.Size = New Size(568, 74)
        TableLayoutPanel4.TabIndex = 37
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(btnGenerarCodigo)
        Panel3.Dock = DockStyle.Fill
        Panel3.Location = New Point(457, 3)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(108, 68)
        Panel3.TabIndex = 15
        ' 
        ' btnGenerarCodigo
        ' 
        btnGenerarCodigo.FlatAppearance.BorderSize = 0
        btnGenerarCodigo.FlatStyle = FlatStyle.Flat
        btnGenerarCodigo.Font = New Font("Century Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnGenerarCodigo.IconChar = FontAwesome.Sharp.IconChar.Refresh
        btnGenerarCodigo.IconColor = Color.FromArgb(CByte(57), CByte(103), CByte(208))
        btnGenerarCodigo.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnGenerarCodigo.IconSize = 40
        btnGenerarCodigo.ImageAlign = ContentAlignment.MiddleLeft
        btnGenerarCodigo.Location = New Point(-7, 22)
        btnGenerarCodigo.Margin = New Padding(0, 3, 3, 3)
        btnGenerarCodigo.Name = "btnGenerarCodigo"
        btnGenerarCodigo.Size = New Size(49, 35)
        btnGenerarCodigo.TabIndex = 29
        btnGenerarCodigo.TextAlign = ContentAlignment.MiddleLeft
        btnGenerarCodigo.UseVisualStyleBackColor = True
        ' 
        ' tlpFooter
        ' 
        tlpFooter.BackColor = Color.LightSkyBlue
        tlpFooter.ColumnCount = 2
        tlpFooter.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpFooter.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpFooter.Controls.Add(Panel5, 1, 0)
        tlpFooter.Controls.Add(Panel4, 0, 0)
        tlpFooter.Dock = DockStyle.Bottom
        tlpFooter.Location = New Point(0, 501)
        tlpFooter.Name = "tlpFooter"
        tlpFooter.RowCount = 1
        tlpFooter.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        tlpFooter.Size = New Size(1175, 66)
        tlpFooter.TabIndex = 5
        ' 
        ' Panel5
        ' 
        Panel5.Controls.Add(btnSiguiente)
        Panel5.Controls.Add(CommandButtonui2)
        Panel5.Dock = DockStyle.Fill
        Panel5.Location = New Point(590, 3)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(582, 60)
        Panel5.TabIndex = 15
        ' 
        ' btnSiguiente
        ' 
        btnSiguiente.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnSiguiente.AnimarHover = True
        btnSiguiente.BackColor = Color.Transparent
        btnSiguiente.ColorBase = Color.FromArgb(CByte(33), CByte(150), CByte(243))
        btnSiguiente.ColorHover = Color.FromArgb(CByte(30), CByte(136), CByte(229))
        btnSiguiente.ColorInternoFondo = Color.FromArgb(CByte(33), CByte(150), CByte(243))
        btnSiguiente.ColorPresionado = Color.FromArgb(CByte(25), CByte(118), CByte(210))
        btnSiguiente.ColorTexto = Color.WhiteSmoke
        btnSiguiente.EstiloBoton = CommandButtonUI.EstiloBootstrap.Primary
        btnSiguiente.Font = New Font("Century Gothic", 10F, FontStyle.Bold)
        btnSiguiente.Icono = FontAwesome.Sharp.IconChar.CircleRight
        btnSiguiente.Location = New Point(708, 8)
        btnSiguiente.Name = "btnSiguiente"
        btnSiguiente.RadioBorde = 8
        btnSiguiente.Size = New Size(200, 44)
        btnSiguiente.TabIndex = 2
        btnSiguiente.Text = "CommandButtonui1"
        btnSiguiente.Texto = "Siguiente..."
        ' 
        ' CommandButtonui2
        ' 
        CommandButtonui2.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        CommandButtonui2.AnimarHover = True
        CommandButtonui2.BackColor = Color.Transparent
        CommandButtonui2.ColorBase = Color.FromArgb(CByte(33), CByte(150), CByte(243))
        CommandButtonui2.ColorHover = Color.FromArgb(CByte(30), CByte(136), CByte(229))
        CommandButtonui2.ColorInternoFondo = Color.FromArgb(CByte(33), CByte(150), CByte(243))
        CommandButtonui2.ColorPresionado = Color.FromArgb(CByte(25), CByte(118), CByte(210))
        CommandButtonui2.ColorTexto = Color.WhiteSmoke
        CommandButtonui2.EstiloBoton = CommandButtonUI.EstiloBootstrap.Primary
        CommandButtonui2.Font = New Font("Century Gothic", 10F, FontStyle.Bold)
        CommandButtonui2.Icono = FontAwesome.Sharp.IconChar.CircleRight
        CommandButtonui2.Location = New Point(1054, 8)
        CommandButtonui2.Name = "CommandButtonui2"
        CommandButtonui2.RadioBorde = 8
        CommandButtonui2.Size = New Size(200, 44)
        CommandButtonui2.TabIndex = 1
        CommandButtonui2.Text = "CommandButtonui1"
        CommandButtonui2.Texto = "Siguiente..."
        ' 
        ' Panel4
        ' 
        Panel4.Controls.Add(CommandButtonui1)
        Panel4.Dock = DockStyle.Fill
        Panel4.Location = New Point(3, 3)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(581, 60)
        Panel4.TabIndex = 14
        ' 
        ' CommandButtonui1
        ' 
        CommandButtonui1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        CommandButtonui1.AnimarHover = True
        CommandButtonui1.BackColor = Color.Transparent
        CommandButtonui1.ColorBase = Color.FromArgb(CByte(33), CByte(150), CByte(243))
        CommandButtonui1.ColorHover = Color.FromArgb(CByte(30), CByte(136), CByte(229))
        CommandButtonui1.ColorInternoFondo = Color.FromArgb(CByte(33), CByte(150), CByte(243))
        CommandButtonui1.ColorPresionado = Color.FromArgb(CByte(25), CByte(118), CByte(210))
        CommandButtonui1.ColorTexto = Color.WhiteSmoke
        CommandButtonui1.EstiloBoton = CommandButtonUI.EstiloBootstrap.Primary
        CommandButtonui1.Font = New Font("Century Gothic", 10F, FontStyle.Bold)
        CommandButtonui1.Icono = FontAwesome.Sharp.IconChar.CircleRight
        CommandButtonui1.Location = New Point(1053, 8)
        CommandButtonui1.Name = "CommandButtonui1"
        CommandButtonui1.RadioBorde = 8
        CommandButtonui1.Size = New Size(200, 44)
        CommandButtonui1.TabIndex = 1
        CommandButtonui1.Text = "CommandButtonui1"
        CommandButtonui1.Texto = "Siguiente..."
        ' 
        ' pnlBtnIzquierdo
        ' 
        pnlBtnIzquierdo.Dock = DockStyle.Fill
        pnlBtnIzquierdo.Location = New Point(3, 373)
        pnlBtnIzquierdo.Name = "pnlBtnIzquierdo"
        pnlBtnIzquierdo.Size = New Size(568, 56)
        pnlBtnIzquierdo.TabIndex = 11
        ' 
        ' pnlBtnDerecho
        ' 
        pnlBtnDerecho.Dock = DockStyle.Fill
        pnlBtnDerecho.Location = New Point(577, 373)
        pnlBtnDerecho.Name = "pnlBtnDerecho"
        pnlBtnDerecho.Size = New Size(569, 56)
        pnlBtnDerecho.TabIndex = 12
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 1
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.Controls.Add(Label1, 0, 0)
        TableLayoutPanel2.Dock = DockStyle.Fill
        TableLayoutPanel2.Location = New Point(3, 243)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 2
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 30F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 70F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel2.Size = New Size(568, 74)
        TableLayoutPanel2.TabIndex = 35
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.DarkSlateGray
        Label2.Location = New Point(3, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(58, 17)
        Label2.TabIndex = 36
        Label2.Text = "Activo?"
        ' 
        ' TableLayoutPanel3
        ' 
        TableLayoutPanel3.ColumnCount = 1
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel3.Controls.Add(Label2, 0, 0)
        TableLayoutPanel3.Dock = DockStyle.Fill
        TableLayoutPanel3.Location = New Point(577, 243)
        TableLayoutPanel3.Name = "TableLayoutPanel3"
        TableLayoutPanel3.RowCount = 2
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 30F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 70F))
        TableLayoutPanel3.Size = New Size(569, 74)
        TableLayoutPanel3.TabIndex = 36
        ' 
        ' tlpContenido
        ' 
        tlpContenido.BackColor = Color.White
        tlpContenido.ColumnCount = 2
        tlpContenido.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpContenido.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpContenido.Controls.Add(TableLayoutPanel3, 1, 3)
        tlpContenido.Controls.Add(pnlBtnIzquierdo, 0, 5)
        tlpContenido.Controls.Add(pnlBtnDerecho, 1, 5)
        tlpContenido.Controls.Add(TableLayoutPanel2, 0, 3)
        tlpContenido.Controls.Add(TableLayoutPanel4, 0, 0)
        tlpContenido.Location = New Point(11, 13)
        tlpContenido.Name = "tlpContenido"
        tlpContenido.RowCount = 6
        tlpContenido.RowStyles.Add(New RowStyle(SizeType.Absolute, 80F))
        tlpContenido.RowStyles.Add(New RowStyle(SizeType.Absolute, 80F))
        tlpContenido.RowStyles.Add(New RowStyle(SizeType.Absolute, 80F))
        tlpContenido.RowStyles.Add(New RowStyle(SizeType.Absolute, 80F))
        tlpContenido.RowStyles.Add(New RowStyle(SizeType.Absolute, 50F))
        tlpContenido.RowStyles.Add(New RowStyle(SizeType.Absolute, 50F))
        tlpContenido.Size = New Size(1149, 432)
        tlpContenido.TabIndex = 4
        ' 
        ' Panelui1
        ' 
        Panelui1.BackColor = Color.Transparent
        Panelui1.BackColorContenedor = Color.Transparent
        Panelui1.BorderColor = Color.FromArgb(CByte(0), CByte(188), CByte(212))
        Panelui1.BorderRadius = 20
        Panelui1.BorderSize = 1
        Panelui1.CardBackColor = Color.White
        Panelui1.Estilo = PanelUI.EstiloCard.None
        Panelui1.Location = New Point(4, 7)
        Panelui1.Name = "Panelui1"
        Panelui1.ShadowColor = Color.LightGray
        Panelui1.Size = New Size(1168, 484)
        Panelui1.TabIndex = 6
        Panelui1.Texto = ""
        ' 
        ' cDatosProveedor
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.WhiteSmoke
        Controls.Add(tlpFooter)
        Controls.Add(tlpContenido)
        Controls.Add(Panelui1)
        Name = "cDatosProveedor"
        Size = New Size(1175, 567)
        TableLayoutPanel4.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        tlpFooter.ResumeLayout(False)
        Panel5.ResumeLayout(False)
        Panel4.ResumeLayout(False)
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel2.PerformLayout()
        TableLayoutPanel3.ResumeLayout(False)
        TableLayoutPanel3.PerformLayout()
        tlpContenido.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnGenerarCodigo As FontAwesome.Sharp.IconButton
    Friend WithEvents tlpFooter As TableLayoutPanel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents btnSiguiente As CommandButtonUI
    Friend WithEvents CommandButtonui2 As CommandButtonUI
    Friend WithEvents Panel4 As Panel
    Friend WithEvents CommandButtonui1 As CommandButtonUI
    Friend WithEvents pnlBtnIzquierdo As Panel
    Friend WithEvents pnlBtnDerecho As Panel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Label2 As Label
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents tlpContenido As TableLayoutPanel
    Friend WithEvents Panelui1 As PanelUI

End Class
