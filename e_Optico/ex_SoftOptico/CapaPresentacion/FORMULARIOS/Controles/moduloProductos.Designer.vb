<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class moduloProductos
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
        Panel1 = New Panel()
        Headerui1 = New HeaderUI()
        Panel2 = New Panel()
        MultilineTextBoxLabelui1 = New MultilineTextBoxLabelUI()
        Panel3 = New Panel()
        IconButton8 = New FontAwesome.Sharp.IconButton()
        IconButton7 = New FontAwesome.Sharp.IconButton()
        IconButton6 = New FontAwesome.Sharp.IconButton()
        IconButton5 = New FontAwesome.Sharp.IconButton()
        IconButton4 = New FontAwesome.Sharp.IconButton()
        IconButton3 = New FontAwesome.Sharp.IconButton()
        IconButton2 = New FontAwesome.Sharp.IconButton()
        IconButton1 = New FontAwesome.Sharp.IconButton()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(Headerui1)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(828, 62)
        Panel1.TabIndex = 0
        ' 
        ' Headerui1
        ' 
        Headerui1.ColorFondo = Color.FromArgb(CByte(240), CByte(240), CByte(240))
        Headerui1.ColorTexto = Color.FromArgb(CByte(45), CByte(45), CByte(45))
        Headerui1.Dock = DockStyle.Fill
        Headerui1.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Headerui1.Icono = FontAwesome.Sharp.IconChar.CircleInfo
        Headerui1.Location = New Point(0, 0)
        Headerui1.MostrarSeparador = True
        Headerui1.Name = "Headerui1"
        Headerui1.Size = New Size(828, 62)
        Headerui1.Subtitulo = "Subtítulo opcional"
        Headerui1.TabIndex = 0
        Headerui1.Text = "Headerui1"
        Headerui1.Titulo = "Título Principal"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.FromArgb(CByte(135), CByte(165), CByte(192))
        Panel2.Controls.Add(MultilineTextBoxLabelui1)
        Panel2.Dock = DockStyle.Fill
        Panel2.Location = New Point(0, 62)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(828, 465)
        Panel2.TabIndex = 0
        ' 
        ' MultilineTextBoxLabelui1
        ' 
        MultilineTextBoxLabelui1.AlturaMultilinea = 80
        MultilineTextBoxLabelui1.BackColor = Color.Transparent
        MultilineTextBoxLabelui1.BorderRadius = 5
        MultilineTextBoxLabelui1.CampoRequerido = True
        MultilineTextBoxLabelui1.ColorError = Color.Firebrick
        MultilineTextBoxLabelui1.FontField = New Font("Century Gothic", 12F)
        MultilineTextBoxLabelui1.IconoColor = Color.White
        MultilineTextBoxLabelui1.IconoDerechoChar = FontAwesome.Sharp.IconChar.CircleInfo
        MultilineTextBoxLabelui1.LabelText = "Texto:"
        MultilineTextBoxLabelui1.Location = New Point(239, 89)
        MultilineTextBoxLabelui1.MensajeError = "Este campo es obligatorio."
        MultilineTextBoxLabelui1.Multilinea = True
        MultilineTextBoxLabelui1.Name = "MultilineTextBoxLabelui1"
        MultilineTextBoxLabelui1.PaddingAll = 10
        MultilineTextBoxLabelui1.PanelBackColor = Color.FromArgb(CByte(80), CByte(94), CByte(129))
        MultilineTextBoxLabelui1.Size = New Size(283, 116)
        MultilineTextBoxLabelui1.TabIndex = 0
        MultilineTextBoxLabelui1.TextColor = Color.WhiteSmoke
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(IconButton8)
        Panel3.Controls.Add(IconButton7)
        Panel3.Controls.Add(IconButton6)
        Panel3.Controls.Add(IconButton5)
        Panel3.Controls.Add(IconButton4)
        Panel3.Controls.Add(IconButton3)
        Panel3.Controls.Add(IconButton2)
        Panel3.Controls.Add(IconButton1)
        Panel3.Dock = DockStyle.Bottom
        Panel3.Location = New Point(0, 459)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(828, 68)
        Panel3.TabIndex = 0
        ' 
        ' IconButton8
        ' 
        IconButton8.BackColor = Color.Transparent
        IconButton8.Cursor = Cursors.Hand
        IconButton8.Dock = DockStyle.Right
        IconButton8.FlatAppearance.BorderSize = 0
        IconButton8.IconChar = FontAwesome.Sharp.IconChar.Node
        IconButton8.IconColor = Color.FromArgb(CByte(0), CByte(192), CByte(0))
        IconButton8.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconButton8.IconSize = 60
        IconButton8.Location = New Point(292, 0)
        IconButton8.Name = "IconButton8"
        IconButton8.Size = New Size(67, 68)
        IconButton8.TabIndex = 7
        IconButton8.TextImageRelation = TextImageRelation.TextAboveImage
        IconButton8.UseVisualStyleBackColor = False
        ' 
        ' IconButton7
        ' 
        IconButton7.BackColor = Color.Transparent
        IconButton7.Cursor = Cursors.Hand
        IconButton7.Dock = DockStyle.Right
        IconButton7.FlatAppearance.BorderSize = 0
        IconButton7.IconChar = FontAwesome.Sharp.IconChar.Node
        IconButton7.IconColor = Color.FromArgb(CByte(0), CByte(192), CByte(0))
        IconButton7.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconButton7.IconSize = 60
        IconButton7.Location = New Point(359, 0)
        IconButton7.Name = "IconButton7"
        IconButton7.Size = New Size(67, 68)
        IconButton7.TabIndex = 6
        IconButton7.TextImageRelation = TextImageRelation.TextAboveImage
        IconButton7.UseVisualStyleBackColor = False
        ' 
        ' IconButton6
        ' 
        IconButton6.BackColor = Color.Transparent
        IconButton6.Cursor = Cursors.Hand
        IconButton6.Dock = DockStyle.Right
        IconButton6.FlatAppearance.BorderSize = 0
        IconButton6.IconChar = FontAwesome.Sharp.IconChar.Node
        IconButton6.IconColor = Color.FromArgb(CByte(0), CByte(192), CByte(0))
        IconButton6.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconButton6.IconSize = 60
        IconButton6.Location = New Point(426, 0)
        IconButton6.Name = "IconButton6"
        IconButton6.Size = New Size(67, 68)
        IconButton6.TabIndex = 5
        IconButton6.TextImageRelation = TextImageRelation.TextAboveImage
        IconButton6.UseVisualStyleBackColor = False
        ' 
        ' IconButton5
        ' 
        IconButton5.BackColor = Color.Transparent
        IconButton5.Cursor = Cursors.Hand
        IconButton5.Dock = DockStyle.Right
        IconButton5.FlatAppearance.BorderSize = 0
        IconButton5.IconChar = FontAwesome.Sharp.IconChar.Node
        IconButton5.IconColor = Color.FromArgb(CByte(0), CByte(192), CByte(0))
        IconButton5.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconButton5.IconSize = 60
        IconButton5.Location = New Point(493, 0)
        IconButton5.Name = "IconButton5"
        IconButton5.Size = New Size(67, 68)
        IconButton5.TabIndex = 4
        IconButton5.TextImageRelation = TextImageRelation.TextAboveImage
        IconButton5.UseVisualStyleBackColor = False
        ' 
        ' IconButton4
        ' 
        IconButton4.BackColor = Color.Transparent
        IconButton4.Cursor = Cursors.Hand
        IconButton4.Dock = DockStyle.Right
        IconButton4.FlatAppearance.BorderSize = 0
        IconButton4.IconChar = FontAwesome.Sharp.IconChar.Node
        IconButton4.IconColor = Color.FromArgb(CByte(0), CByte(192), CByte(0))
        IconButton4.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconButton4.IconSize = 60
        IconButton4.Location = New Point(560, 0)
        IconButton4.Name = "IconButton4"
        IconButton4.Size = New Size(67, 68)
        IconButton4.TabIndex = 3
        IconButton4.TextImageRelation = TextImageRelation.TextAboveImage
        IconButton4.UseVisualStyleBackColor = False
        ' 
        ' IconButton3
        ' 
        IconButton3.BackColor = Color.Transparent
        IconButton3.Cursor = Cursors.Hand
        IconButton3.Dock = DockStyle.Right
        IconButton3.FlatAppearance.BorderSize = 0
        IconButton3.IconChar = FontAwesome.Sharp.IconChar.Node
        IconButton3.IconColor = Color.FromArgb(CByte(0), CByte(192), CByte(0))
        IconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconButton3.IconSize = 60
        IconButton3.Location = New Point(627, 0)
        IconButton3.Name = "IconButton3"
        IconButton3.Size = New Size(67, 68)
        IconButton3.TabIndex = 2
        IconButton3.TextImageRelation = TextImageRelation.TextAboveImage
        IconButton3.UseVisualStyleBackColor = False
        ' 
        ' IconButton2
        ' 
        IconButton2.BackColor = Color.Transparent
        IconButton2.Cursor = Cursors.Hand
        IconButton2.Dock = DockStyle.Right
        IconButton2.FlatAppearance.BorderSize = 0
        IconButton2.IconChar = FontAwesome.Sharp.IconChar.Node
        IconButton2.IconColor = Color.FromArgb(CByte(0), CByte(192), CByte(0))
        IconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconButton2.IconSize = 60
        IconButton2.Location = New Point(694, 0)
        IconButton2.Name = "IconButton2"
        IconButton2.Size = New Size(67, 68)
        IconButton2.TabIndex = 1
        IconButton2.TextImageRelation = TextImageRelation.TextAboveImage
        IconButton2.UseVisualStyleBackColor = False
        ' 
        ' IconButton1
        ' 
        IconButton1.BackColor = Color.Transparent
        IconButton1.Cursor = Cursors.Hand
        IconButton1.Dock = DockStyle.Right
        IconButton1.FlatAppearance.BorderSize = 0
        IconButton1.IconChar = FontAwesome.Sharp.IconChar.Node
        IconButton1.IconColor = Color.FromArgb(CByte(0), CByte(192), CByte(0))
        IconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconButton1.IconSize = 60
        IconButton1.Location = New Point(761, 0)
        IconButton1.Name = "IconButton1"
        IconButton1.Size = New Size(67, 68)
        IconButton1.TabIndex = 0
        IconButton1.TextImageRelation = TextImageRelation.TextAboveImage
        IconButton1.UseVisualStyleBackColor = False
        ' 
        ' moduloProductos
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Name = "moduloProductos"
        Size = New Size(828, 527)
        Panel1.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Headerui1 As HeaderUI
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents IconButton1 As FontAwesome.Sharp.IconButton
    Friend WithEvents MultilineTextBoxLabelui1 As MultilineTextBoxLabelUI
    Friend WithEvents IconButton8 As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton7 As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton6 As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton5 As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton4 As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton3 As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton2 As FontAwesome.Sharp.IconButton

End Class
