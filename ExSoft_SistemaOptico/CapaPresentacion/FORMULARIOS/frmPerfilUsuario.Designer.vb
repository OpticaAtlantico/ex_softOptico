<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPerfilUsuario
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
        Label11 = New Label()
        pnlContenedor = New Panel()
        pnlEditarDatos = New Panel()
        lnk_EditarPass = New LinkLabel()
        btn_Cancelar = New Button()
        btn_Aceptar = New Button()
        txt_PassConfirmar = New TextBox()
        txt_PassNueva = New TextBox()
        txt_PassActual = New TextBox()
        txt_Usuario = New TextBox()
        Label10 = New Label()
        Label9 = New Label()
        Label8 = New Label()
        Label7 = New Label()
        Panel2 = New Panel()
        Label5 = New Label()
        Panel1 = New Panel()
        lnk_EditarPerfil = New LinkLabel()
        Panel3 = New Panel()
        lblCorreo = New Label()
        Label6 = New Label()
        lblPosicion = New Label()
        lblUsuario = New Label()
        lblApellido = New Label()
        lblNombres = New Label()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        IconPictureBox1 = New FontAwesome.Sharp.IconPictureBox()
        pnlContenedor.SuspendLayout()
        pnlEditarDatos.SuspendLayout()
        Panel1.SuspendLayout()
        CType(IconPictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Copperplate Gothic Light", 20F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label11.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        Label11.Location = New Point(12, 9)
        Label11.Name = "Label11"
        Label11.Size = New Size(150, 30)
        Label11.TabIndex = 16
        Label11.Text = "My Perfil"
        ' 
        ' pnlContenedor
        ' 
        pnlContenedor.Controls.Add(pnlEditarDatos)
        pnlContenedor.Controls.Add(Panel1)
        pnlContenedor.Dock = DockStyle.Fill
        pnlContenedor.Location = New Point(0, 0)
        pnlContenedor.Name = "pnlContenedor"
        pnlContenedor.Size = New Size(1015, 609)
        pnlContenedor.TabIndex = 3
        ' 
        ' pnlEditarDatos
        ' 
        pnlEditarDatos.BackColor = Color.FromArgb(CByte(51), CByte(51), CByte(80))
        pnlEditarDatos.Controls.Add(lnk_EditarPass)
        pnlEditarDatos.Controls.Add(btn_Cancelar)
        pnlEditarDatos.Controls.Add(btn_Aceptar)
        pnlEditarDatos.Controls.Add(txt_PassConfirmar)
        pnlEditarDatos.Controls.Add(txt_PassNueva)
        pnlEditarDatos.Controls.Add(txt_PassActual)
        pnlEditarDatos.Controls.Add(txt_Usuario)
        pnlEditarDatos.Controls.Add(Label10)
        pnlEditarDatos.Controls.Add(Label9)
        pnlEditarDatos.Controls.Add(Label8)
        pnlEditarDatos.Controls.Add(Label7)
        pnlEditarDatos.Controls.Add(Panel2)
        pnlEditarDatos.Controls.Add(Label5)
        pnlEditarDatos.Dock = DockStyle.Right
        pnlEditarDatos.Location = New Point(581, 0)
        pnlEditarDatos.Name = "pnlEditarDatos"
        pnlEditarDatos.Size = New Size(434, 609)
        pnlEditarDatos.TabIndex = 3
        ' 
        ' lnk_EditarPass
        ' 
        lnk_EditarPass.ActiveLinkColor = Color.FromArgb(CByte(17), CByte(97), CByte(238))
        lnk_EditarPass.AutoSize = True
        lnk_EditarPass.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lnk_EditarPass.ForeColor = Color.Silver
        lnk_EditarPass.LinkColor = Color.DarkCyan
        lnk_EditarPass.Location = New Point(155, 247)
        lnk_EditarPass.Name = "lnk_EditarPass"
        lnk_EditarPass.Size = New Size(45, 17)
        lnk_EditarPass.TabIndex = 16
        lnk_EditarPass.TabStop = True
        lnk_EditarPass.Text = "Editar"
        ' 
        ' btn_Cancelar
        ' 
        btn_Cancelar.BackColor = Color.IndianRed
        btn_Cancelar.Cursor = Cursors.Hand
        btn_Cancelar.FlatAppearance.BorderSize = 0
        btn_Cancelar.FlatStyle = FlatStyle.Flat
        btn_Cancelar.Font = New Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btn_Cancelar.ForeColor = Color.White
        btn_Cancelar.Location = New Point(42, 460)
        btn_Cancelar.Name = "btn_Cancelar"
        btn_Cancelar.Size = New Size(162, 54)
        btn_Cancelar.TabIndex = 24
        btn_Cancelar.Text = "Cancelar"
        btn_Cancelar.UseVisualStyleBackColor = False
        ' 
        ' btn_Aceptar
        ' 
        btn_Aceptar.BackColor = Color.FromArgb(CByte(17), CByte(97), CByte(238))
        btn_Aceptar.Cursor = Cursors.Hand
        btn_Aceptar.FlatAppearance.BorderSize = 0
        btn_Aceptar.FlatStyle = FlatStyle.Flat
        btn_Aceptar.Font = New Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btn_Aceptar.ForeColor = Color.White
        btn_Aceptar.Location = New Point(230, 460)
        btn_Aceptar.Name = "btn_Aceptar"
        btn_Aceptar.Size = New Size(162, 54)
        btn_Aceptar.TabIndex = 23
        btn_Aceptar.Text = "Aceptar"
        btn_Aceptar.UseVisualStyleBackColor = False
        ' 
        ' txt_PassConfirmar
        ' 
        txt_PassConfirmar.BackColor = Color.FromArgb(CByte(80), CByte(94), CByte(129))
        txt_PassConfirmar.BorderStyle = BorderStyle.None
        txt_PassConfirmar.Font = New Font("Century Gothic", 12F)
        txt_PassConfirmar.ForeColor = Color.White
        txt_PassConfirmar.Location = New Point(42, 343)
        txt_PassConfirmar.Name = "txt_PassConfirmar"
        txt_PassConfirmar.Size = New Size(350, 20)
        txt_PassConfirmar.TabIndex = 22
        ' 
        ' txt_PassNueva
        ' 
        txt_PassNueva.BackColor = Color.FromArgb(CByte(80), CByte(94), CByte(129))
        txt_PassNueva.BorderStyle = BorderStyle.None
        txt_PassNueva.Font = New Font("Century Gothic", 12F)
        txt_PassNueva.ForeColor = Color.White
        txt_PassNueva.Location = New Point(42, 270)
        txt_PassNueva.Name = "txt_PassNueva"
        txt_PassNueva.Size = New Size(350, 20)
        txt_PassNueva.TabIndex = 21
        ' 
        ' txt_PassActual
        ' 
        txt_PassActual.BackColor = Color.FromArgb(CByte(80), CByte(94), CByte(129))
        txt_PassActual.BorderStyle = BorderStyle.None
        txt_PassActual.Font = New Font("Century Gothic", 12F)
        txt_PassActual.ForeColor = Color.White
        txt_PassActual.Location = New Point(42, 197)
        txt_PassActual.Name = "txt_PassActual"
        txt_PassActual.Size = New Size(350, 20)
        txt_PassActual.TabIndex = 20
        ' 
        ' txt_Usuario
        ' 
        txt_Usuario.BackColor = Color.FromArgb(CByte(80), CByte(94), CByte(129))
        txt_Usuario.BorderStyle = BorderStyle.None
        txt_Usuario.Font = New Font("Century Gothic", 12F)
        txt_Usuario.ForeColor = Color.White
        txt_Usuario.Location = New Point(42, 124)
        txt_Usuario.Name = "txt_Usuario"
        txt_Usuario.Size = New Size(350, 20)
        txt_Usuario.TabIndex = 19
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label10.ForeColor = Color.WhiteSmoke
        Label10.Location = New Point(42, 170)
        Label10.Name = "Label10"
        Label10.Size = New Size(165, 21)
        Label10.TabIndex = 17
        Label10.Text = "Contraseña Actual:"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label9.ForeColor = Color.WhiteSmoke
        Label9.Location = New Point(42, 316)
        Label9.Name = "Label9"
        Label9.Size = New Size(188, 21)
        Label9.TabIndex = 16
        Label9.Text = "Confirmar Contraseña:"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label8.ForeColor = Color.WhiteSmoke
        Label8.Location = New Point(42, 243)
        Label8.Name = "Label8"
        Label8.Size = New Size(107, 21)
        Label8.TabIndex = 15
        Label8.Text = "Contraseña:"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.ForeColor = Color.WhiteSmoke
        Label7.Location = New Point(42, 97)
        Label7.Name = "Label7"
        Label7.Size = New Size(70, 21)
        Label7.TabIndex = 14
        Label7.Text = "Usuario:"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.LightGray
        Panel2.Location = New Point(15, 47)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(407, 3)
        Panel2.TabIndex = 13
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Copperplate Gothic Light", 20F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = Color.WhiteSmoke
        Label5.Location = New Point(17, 9)
        Label5.Name = "Label5"
        Label5.Size = New Size(256, 30)
        Label5.TabIndex = 12
        Label5.Text = "Editar mis Datos"
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.WhiteSmoke
        Panel1.Controls.Add(lnk_EditarPerfil)
        Panel1.Controls.Add(Label11)
        Panel1.Controls.Add(Panel3)
        Panel1.Controls.Add(lblCorreo)
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(lblPosicion)
        Panel1.Controls.Add(lblUsuario)
        Panel1.Controls.Add(lblApellido)
        Panel1.Controls.Add(lblNombres)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(IconPictureBox1)
        Panel1.Dock = DockStyle.Left
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(575, 609)
        Panel1.TabIndex = 2
        ' 
        ' lnk_EditarPerfil
        ' 
        lnk_EditarPerfil.ActiveLinkColor = Color.MidnightBlue
        lnk_EditarPerfil.AutoSize = True
        lnk_EditarPerfil.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lnk_EditarPerfil.ForeColor = Color.Silver
        lnk_EditarPerfil.LinkColor = Color.DarkCyan
        lnk_EditarPerfil.Location = New Point(267, 420)
        lnk_EditarPerfil.Name = "lnk_EditarPerfil"
        lnk_EditarPerfil.Size = New Size(79, 17)
        lnk_EditarPerfil.TabIndex = 15
        lnk_EditarPerfil.TabStop = True
        lnk_EditarPerfil.Text = "Editar Perfil"
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.LightGray
        Panel3.Location = New Point(277, 77)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(3, 305)
        Panel3.TabIndex = 14
        ' 
        ' lblCorreo
        ' 
        lblCorreo.AutoSize = True
        lblCorreo.FlatStyle = FlatStyle.Flat
        lblCorreo.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCorreo.ForeColor = Color.DimGray
        lblCorreo.Location = New Point(290, 283)
        lblCorreo.Name = "lblCorreo"
        lblCorreo.Size = New Size(138, 17)
        lblCorreo.TabIndex = 10
        lblCorreo.Text = "wiflores@gmail.com"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(290, 264)
        Label6.Name = "Label6"
        Label6.Size = New Size(65, 19)
        Label6.TabIndex = 9
        Label6.Text = "Correo:"
        ' 
        ' lblPosicion
        ' 
        lblPosicion.AutoSize = True
        lblPosicion.FlatStyle = FlatStyle.Flat
        lblPosicion.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblPosicion.ForeColor = Color.DimGray
        lblPosicion.Location = New Point(290, 340)
        lblPosicion.Name = "lblPosicion"
        lblPosicion.Size = New Size(98, 17)
        lblPosicion.TabIndex = 8
        lblPosicion.Text = "Administrador"
        ' 
        ' lblUsuario
        ' 
        lblUsuario.AutoSize = True
        lblUsuario.FlatStyle = FlatStyle.Flat
        lblUsuario.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblUsuario.ForeColor = Color.DimGray
        lblUsuario.Location = New Point(290, 226)
        lblUsuario.Name = "lblUsuario"
        lblUsuario.Size = New Size(56, 17)
        lblUsuario.TabIndex = 7
        lblUsuario.Text = "wiflores"
        ' 
        ' lblApellido
        ' 
        lblApellido.AutoSize = True
        lblApellido.FlatStyle = FlatStyle.Flat
        lblApellido.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblApellido.ForeColor = Color.DimGray
        lblApellido.Location = New Point(290, 169)
        lblApellido.Name = "lblApellido"
        lblApellido.Size = New Size(88, 17)
        lblApellido.TabIndex = 6
        lblApellido.Text = "Flores Parejo"
        ' 
        ' lblNombres
        ' 
        lblNombres.AutoSize = True
        lblNombres.FlatStyle = FlatStyle.Flat
        lblNombres.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblNombres.ForeColor = Color.DimGray
        lblNombres.Location = New Point(290, 112)
        lblNombres.Name = "lblNombres"
        lblNombres.Size = New Size(108, 17)
        lblNombres.TabIndex = 5
        lblNombres.Text = "Wilmer Delvalle"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(290, 321)
        Label4.Name = "Label4"
        Label4.Size = New Size(76, 19)
        Label4.TabIndex = 4
        Label4.Text = "Posición:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(290, 207)
        Label3.Name = "Label3"
        Label3.Size = New Size(69, 19)
        Label3.TabIndex = 3
        Label3.Text = "Usuario:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(290, 150)
        Label2.Name = "Label2"
        Label2.Size = New Size(85, 19)
        Label2.TabIndex = 2
        Label2.Text = "Apellidos:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(290, 93)
        Label1.Name = "Label1"
        Label1.Size = New Size(83, 19)
        Label1.TabIndex = 1
        Label1.Text = "Nombres:"
        ' 
        ' IconPictureBox1
        ' 
        IconPictureBox1.BackColor = Color.WhiteSmoke
        IconPictureBox1.ForeColor = SystemColors.ActiveCaption
        IconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.UserGear
        IconPictureBox1.IconColor = SystemColors.ActiveCaption
        IconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconPictureBox1.IconSize = 241
        IconPictureBox1.Location = New Point(30, 93)
        IconPictureBox1.Name = "IconPictureBox1"
        IconPictureBox1.Size = New Size(241, 247)
        IconPictureBox1.TabIndex = 0
        IconPictureBox1.TabStop = False
        ' 
        ' frmPerfilUsuario
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1015, 609)
        Controls.Add(pnlContenedor)
        Name = "frmPerfilUsuario"
        StartPosition = FormStartPosition.CenterScreen
        Text = "frmPerfilUsuario"
        pnlContenedor.ResumeLayout(False)
        pnlEditarDatos.ResumeLayout(False)
        pnlEditarDatos.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(IconPictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub
    Friend WithEvents pnlContenedor As Panel
    Friend WithEvents pnlEditarDatos As Panel
    Friend WithEvents lnk_EditarPass As LinkLabel
    Friend WithEvents btn_Cancelar As Button
    Friend WithEvents btn_Aceptar As Button
    Friend WithEvents txt_PassConfirmar As TextBox
    Friend WithEvents txt_PassNueva As TextBox
    Friend WithEvents txt_PassActual As TextBox
    Friend WithEvents txt_Usuario As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents lnk_EditarPerfil As LinkLabel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lblCorreo As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblPosicion As Label
    Friend WithEvents lblUsuario As Label
    Friend WithEvents lblApellido As Label
    Friend WithEvents lblNombres As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents IconPictureBox1 As FontAwesome.Sharp.IconPictureBox
End Class
