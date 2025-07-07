<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Login
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
        pnl_Titulo = New Panel()
        btn_Minimizar = New FontAwesome.Sharp.IconPictureBox()
        btn_Close = New FontAwesome.Sharp.IconPictureBox()
        Panel1 = New Panel()
        pnl_Controles = New Panel()
        cmb_Sucursal = New ComboBox()
        Label1 = New Label()
        IconPictureBox1 = New FontAwesome.Sharp.IconPictureBox()
        lnkPass = New LinkLabel()
        lbl_Linea = New Label()
        btn_Aceptar = New Button()
        chk_RecordarPass = New CheckBox()
        lbl_Password = New Label()
        lbl_Usuario = New Label()
        txt_Password = New TextBox()
        txt_Usuario = New TextBox()
        pnl_Titulo.SuspendLayout()
        CType(btn_Minimizar, ComponentModel.ISupportInitialize).BeginInit()
        CType(btn_Close, ComponentModel.ISupportInitialize).BeginInit()
        pnl_Controles.SuspendLayout()
        CType(IconPictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pnl_Titulo
        ' 
        pnl_Titulo.BackColor = Color.FromArgb(CByte(30), CByte(38), CByte(70))
        pnl_Titulo.Controls.Add(btn_Minimizar)
        pnl_Titulo.Controls.Add(btn_Close)
        pnl_Titulo.Dock = DockStyle.Top
        pnl_Titulo.Location = New Point(0, 0)
        pnl_Titulo.Name = "pnl_Titulo"
        pnl_Titulo.Size = New Size(473, 50)
        pnl_Titulo.TabIndex = 0
        ' 
        ' btn_Minimizar
        ' 
        btn_Minimizar.BackColor = Color.FromArgb(CByte(30), CByte(38), CByte(70))
        btn_Minimizar.Cursor = Cursors.Hand
        btn_Minimizar.ForeColor = Color.DarkGray
        btn_Minimizar.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize
        btn_Minimizar.IconColor = Color.DarkGray
        btn_Minimizar.IconFont = FontAwesome.Sharp.IconFont.Auto
        btn_Minimizar.IconSize = 22
        btn_Minimizar.Location = New Point(410, 12)
        btn_Minimizar.Name = "btn_Minimizar"
        btn_Minimizar.Size = New Size(22, 22)
        btn_Minimizar.TabIndex = 1
        btn_Minimizar.TabStop = False
        ' 
        ' btn_Close
        ' 
        btn_Close.BackColor = Color.FromArgb(CByte(30), CByte(38), CByte(70))
        btn_Close.Cursor = Cursors.Hand
        btn_Close.ForeColor = Color.DarkGray
        btn_Close.IconChar = FontAwesome.Sharp.IconChar.X
        btn_Close.IconColor = Color.DarkGray
        btn_Close.IconFont = FontAwesome.Sharp.IconFont.Auto
        btn_Close.IconSize = 22
        btn_Close.Location = New Point(439, 12)
        btn_Close.Name = "btn_Close"
        btn_Close.Size = New Size(22, 22)
        btn_Close.TabIndex = 0
        btn_Close.TabStop = False
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(30), CByte(38), CByte(70))
        Panel1.Dock = DockStyle.Bottom
        Panel1.Location = New Point(0, 701)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(473, 27)
        Panel1.TabIndex = 1
        ' 
        ' pnl_Controles
        ' 
        pnl_Controles.Controls.Add(cmb_Sucursal)
        pnl_Controles.Controls.Add(Label1)
        pnl_Controles.Controls.Add(IconPictureBox1)
        pnl_Controles.Controls.Add(lnkPass)
        pnl_Controles.Controls.Add(lbl_Linea)
        pnl_Controles.Controls.Add(btn_Aceptar)
        pnl_Controles.Controls.Add(chk_RecordarPass)
        pnl_Controles.Controls.Add(lbl_Password)
        pnl_Controles.Controls.Add(lbl_Usuario)
        pnl_Controles.Controls.Add(txt_Password)
        pnl_Controles.Controls.Add(txt_Usuario)
        pnl_Controles.Dock = DockStyle.Fill
        pnl_Controles.Location = New Point(0, 50)
        pnl_Controles.Name = "pnl_Controles"
        pnl_Controles.Size = New Size(473, 651)
        pnl_Controles.TabIndex = 2
        ' 
        ' cmb_Sucursal
        ' 
        cmb_Sucursal.BackColor = Color.FromArgb(CByte(80), CByte(94), CByte(129))
        cmb_Sucursal.Cursor = Cursors.Hand
        cmb_Sucursal.DropDownStyle = ComboBoxStyle.DropDownList
        cmb_Sucursal.FlatStyle = FlatStyle.Flat
        cmb_Sucursal.Font = New Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmb_Sucursal.ForeColor = Color.White
        cmb_Sucursal.FormattingEnabled = True
        cmb_Sucursal.Location = New Point(61, 415)
        cmb_Sucursal.Name = "cmb_Sucursal"
        cmb_Sucursal.Size = New Size(350, 29)
        cmb_Sucursal.Sorted = True
        cmb_Sucursal.TabIndex = 21
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Century Gothic", 12F)
        Label1.ForeColor = Color.Silver
        Label1.Location = New Point(61, 391)
        Label1.Name = "Label1"
        Label1.Size = New Size(103, 21)
        Label1.TabIndex = 20
        Label1.Text = "Contraseña"
        Label1.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' IconPictureBox1
        ' 
        IconPictureBox1.BackColor = Color.FromArgb(CByte(46), CByte(59), CByte(104))
        IconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Panorama
        IconPictureBox1.IconColor = Color.White
        IconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconPictureBox1.IconSize = 212
        IconPictureBox1.Location = New Point(61, 32)
        IconPictureBox1.Name = "IconPictureBox1"
        IconPictureBox1.Size = New Size(350, 212)
        IconPictureBox1.SizeMode = PictureBoxSizeMode.CenterImage
        IconPictureBox1.TabIndex = 19
        IconPictureBox1.TabStop = False
        ' 
        ' lnkPass
        ' 
        lnkPass.ActiveLinkColor = Color.FromArgb(CByte(17), CByte(97), CByte(238))
        lnkPass.AutoSize = True
        lnkPass.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lnkPass.ForeColor = Color.Silver
        lnkPass.LinkColor = Color.Silver
        lnkPass.Location = New Point(158, 613)
        lnkPass.Name = "lnkPass"
        lnkPass.Size = New Size(156, 17)
        lnkPass.TabIndex = 18
        lnkPass.TabStop = True
        lnkPass.Text = "Olvido su Contraseña?"
        ' 
        ' lbl_Linea
        ' 
        lbl_Linea.BackColor = Color.DarkGray
        lbl_Linea.FlatStyle = FlatStyle.Flat
        lbl_Linea.Location = New Point(61, 605)
        lbl_Linea.Name = "lbl_Linea"
        lbl_Linea.Size = New Size(350, 1)
        lbl_Linea.TabIndex = 17
        ' 
        ' btn_Aceptar
        ' 
        btn_Aceptar.BackColor = Color.FromArgb(CByte(17), CByte(97), CByte(238))
        btn_Aceptar.FlatAppearance.BorderSize = 0
        btn_Aceptar.FlatStyle = FlatStyle.Flat
        btn_Aceptar.Font = New Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btn_Aceptar.ForeColor = Color.White
        btn_Aceptar.Location = New Point(61, 525)
        btn_Aceptar.Name = "btn_Aceptar"
        btn_Aceptar.Size = New Size(350, 54)
        btn_Aceptar.TabIndex = 13
        btn_Aceptar.Text = "Aceptar"
        btn_Aceptar.UseVisualStyleBackColor = False
        ' 
        ' chk_RecordarPass
        ' 
        chk_RecordarPass.AutoSize = True
        chk_RecordarPass.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        chk_RecordarPass.ForeColor = Color.Silver
        chk_RecordarPass.Location = New Point(61, 468)
        chk_RecordarPass.Name = "chk_RecordarPass"
        chk_RecordarPass.Size = New Size(166, 21)
        chk_RecordarPass.TabIndex = 16
        chk_RecordarPass.Text = "Recordar Contraseña"
        chk_RecordarPass.UseVisualStyleBackColor = True
        ' 
        ' lbl_Password
        ' 
        lbl_Password.AutoSize = True
        lbl_Password.Font = New Font("Century Gothic", 12F)
        lbl_Password.ForeColor = Color.Silver
        lbl_Password.Location = New Point(61, 318)
        lbl_Password.Name = "lbl_Password"
        lbl_Password.Size = New Size(103, 21)
        lbl_Password.TabIndex = 14
        lbl_Password.Text = "Contraseña"
        lbl_Password.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lbl_Usuario
        ' 
        lbl_Usuario.AutoSize = True
        lbl_Usuario.Font = New Font("Century Gothic", 12F)
        lbl_Usuario.ForeColor = Color.Silver
        lbl_Usuario.Location = New Point(61, 247)
        lbl_Usuario.Name = "lbl_Usuario"
        lbl_Usuario.Size = New Size(66, 21)
        lbl_Usuario.TabIndex = 15
        lbl_Usuario.Text = "Usuario"
        lbl_Usuario.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txt_Password
        ' 
        txt_Password.BackColor = Color.FromArgb(CByte(80), CByte(94), CByte(129))
        txt_Password.BorderStyle = BorderStyle.None
        txt_Password.Font = New Font("Century Gothic", 12F)
        txt_Password.ForeColor = Color.White
        txt_Password.Location = New Point(61, 342)
        txt_Password.Name = "txt_Password"
        txt_Password.Size = New Size(350, 20)
        txt_Password.TabIndex = 12
        ' 
        ' txt_Usuario
        ' 
        txt_Usuario.BackColor = Color.FromArgb(CByte(80), CByte(94), CByte(129))
        txt_Usuario.BorderStyle = BorderStyle.None
        txt_Usuario.Font = New Font("Century Gothic", 12F)
        txt_Usuario.ForeColor = Color.White
        txt_Usuario.Location = New Point(61, 271)
        txt_Usuario.Name = "txt_Usuario"
        txt_Usuario.Size = New Size(350, 20)
        txt_Usuario.TabIndex = 11
        ' 
        ' frm_Login
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(46), CByte(59), CByte(104))
        ClientSize = New Size(473, 728)
        Controls.Add(pnl_Controles)
        Controls.Add(Panel1)
        Controls.Add(pnl_Titulo)
        FormBorderStyle = FormBorderStyle.None
        Name = "frm_Login"
        Opacity = 0.85R
        StartPosition = FormStartPosition.CenterScreen
        Text = "frm_Login"
        pnl_Titulo.ResumeLayout(False)
        CType(btn_Minimizar, ComponentModel.ISupportInitialize).EndInit()
        CType(btn_Close, ComponentModel.ISupportInitialize).EndInit()
        pnl_Controles.ResumeLayout(False)
        pnl_Controles.PerformLayout()
        CType(IconPictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnl_Titulo As Panel
    Friend WithEvents btn_Close As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btn_Minimizar As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents pnl_Controles As Panel
    Friend WithEvents cmb_Sucursal As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents IconPictureBox1 As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents lnkPass As LinkLabel
    Friend WithEvents lbl_Linea As Label
    Friend WithEvents btn_Aceptar As Button
    Friend WithEvents chk_RecordarPass As CheckBox
    Friend WithEvents lbl_Password As Label
    Friend WithEvents lbl_Usuario As Label
    Friend WithEvents txt_Password As TextBox
    Friend WithEvents txt_Usuario As TextBox
End Class
