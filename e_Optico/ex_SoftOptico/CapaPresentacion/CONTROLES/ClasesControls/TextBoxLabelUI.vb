Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports FontAwesome.Sharp

Public Class TextBoxLabelUI
    Inherits UserControl

    ' === Controles ===
    Private lblTitulo As New Label()
    Private pnlFondo As New Panel()
    Private txtCampo As New TextBox()
    Private lblError As New Label()

    ' === Estilos ===
    Private _labelText As String = "Texto:"
    Private _labelColor As Color = Color.WhiteSmoke
    Private _panelBackColor As Color = Color.FromArgb(80, 94, 129)
    Private _textColor As Color = Color.WhiteSmoke
    Private _fontField As Font = New Font("Century Gothic", 12)
    Private _paddingAll As Integer = 10

    Private iconoDerecho As New IconPictureBox()

    Private _campoRequerido As Boolean = True
    Private _mensajeError As String = "Este campo es obligatorio."
    Private _colorError As Color = Color.Firebrick

    ' === Visual orbital ===
    Private _borderRadius As Integer = 5
    Private _borderColorNormal As Color = Color.LightGray

    ' === Contraseña orbital ===
    Private _usarContraseña As Boolean = False
    Private _caracterContraseña As Char = "*"c

    Private _borderColorPersonalizado As Color = Color.LightGray
    Private _borderSize As Integer = 1

    Private _validarComoCorreo As Boolean = False

    ' === Constructor ===
    Public Sub New()
        Me.Size = New Size(300, 100)
        Me.DoubleBuffered = True
        Me.BackColor = Color.Transparent

        lblTitulo.Text = _labelText
        lblTitulo.Font = New Font(_fontField.FontFamily, _fontField.Size - 2)
        lblTitulo.ForeColor = Color.WhiteSmoke
        lblTitulo.Dock = DockStyle.Top
        lblTitulo.Height = 20

        pnlFondo.Dock = DockStyle.Top
        pnlFondo.BackColor = _panelBackColor
        pnlFondo.Padding = New Padding(_paddingAll)
        pnlFondo.Height = 37
        pnlFondo.Margin = Padding.Empty

        txtCampo.BorderStyle = BorderStyle.None
        txtCampo.Font = _fontField
        txtCampo.ForeColor = _textColor
        txtCampo.BackColor = _panelBackColor
        txtCampo.TextAlign = HorizontalAlignment.Left
        txtCampo.Size = New Size(pnlFondo.Width - 40, 30) ' ajusta ancho para dejar espacio al ícono
        txtCampo.Location = New Point(_paddingAll, (pnlFondo.Height - txtCampo.Height) \ 2)
        txtCampo.Anchor = AnchorStyles.Left Or AnchorStyles.Top
        pnlFondo.Controls.Add(txtCampo)

        lblError.Text = ""
        lblError.ForeColor = _colorError
        lblError.Dock = DockStyle.Top
        lblError.Height = 20
        lblError.Visible = False
        lblError.Margin = Padding.Empty
        lblError.TextAlign = ContentAlignment.MiddleRight

        iconoDerecho.IconChar = IconChar.InfoCircle
        iconoDerecho.IconColor = Color.White
        iconoDerecho.Size = New Size(24, 24)
        iconoDerecho.Location = New Point(pnlFondo.Width - iconoDerecho.Width - _paddingAll, (pnlFondo.Height - iconoDerecho.Height) \ 2)
        iconoDerecho.Anchor = AnchorStyles.Right Or AnchorStyles.Top
        iconoDerecho.BackColor = Color.Transparent
        iconoDerecho.SizeMode = PictureBoxSizeMode.Zoom
        pnlFondo.Controls.Add(iconoDerecho)

        AddHandler txtCampo.TextChanged, AddressOf ActualizarEstado
        AddHandler txtCampo.LostFocus, AddressOf ValidarCampo
        AddHandler pnlFondo.Resize, Sub()
                                        Dim tieneIcono As Boolean = iconoDerecho.Visible

                                        Dim margenIcono = If(tieneIcono, iconoDerecho.Width + (_paddingAll * 2), _paddingAll)
                                        txtCampo.Size = New Size(pnlFondo.Width - margenIcono - _paddingAll, 30)
                                        txtCampo.Location = New Point(_paddingAll, (pnlFondo.Height - txtCampo.Height) \ 2)

                                        If tieneIcono Then
                                            iconoDerecho.Location = New Point(pnlFondo.Width - iconoDerecho.Width - _paddingAll, (pnlFondo.Height - iconoDerecho.Height) \ 2)
                                        End If
                                    End Sub

        Me.Controls.Add(lblError)
        Me.Controls.Add(pnlFondo)
        Me.Controls.Add(lblTitulo)

        AddHandler pnlFondo.Paint, AddressOf DibujarFondoRedondeado
        AddHandler pnlFondo.Resize, Sub() pnlFondo.Region = New Region(RoundedPath(pnlFondo.ClientRectangle, _borderRadius))

    End Sub

    Private Sub ValidarCampo(sender As Object, e As EventArgs)
        If _campoRequerido Then
            If String.IsNullOrWhiteSpace(txtCampo.Text) Then
                lblError.Text = _mensajeError
                lblError.Visible = True
                _borderColorNormal = _colorError
            Else
                lblError.Visible = False
                _borderColorNormal = Color.LightGray
            End If
            pnlFondo.Invalidate()
        End If

        If ValidarComoCorreo AndAlso Not String.IsNullOrWhiteSpace(txtCampo.Text) Then
            If Not EsCorreoValido(txtCampo.Text.Trim()) Then
                lblError.Text = "Correo electrónico no válido."
                lblError.Visible = True
                _borderColorNormal = _colorError
            Else
                lblError.Visible = False
                _borderColorNormal = Color.LightGray
            End If
        End If

        CapitalizarSiEsNecesario(sender, e) ' Capitaliza al perder el foco
    End Sub

    Private Function EsCorreoValido(correo As String) As Boolean
        Try
            Dim addr As New System.Net.Mail.MailAddress(correo)
            Return addr.Address = correo
        Catch
            Return False
        End Try
    End Function

    Private Sub ActualizarEstado(sender As Object, e As EventArgs)
        If lblError.Visible AndAlso Not String.IsNullOrWhiteSpace(txtCampo.Text) Then
            lblError.Visible = False
            _borderColorNormal = Color.LightGray
            pnlFondo.Invalidate()
        End If
        txtCampo.Invalidate() ' Actualiza placeholder si necesario
    End Sub

    ' === Fondo redondeado orbital ===
    Private Sub DibujarFondoRedondeado(sender As Object, e As PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect = pnlFondo.ClientRectangle
        rect.Inflate(-1, -1)

        Using path As GraphicsPath = RoundedPath(rect, _borderRadius)
            Using brush As New SolidBrush(pnlFondo.BackColor)
                e.Graphics.FillPath(brush, path)
            End Using
            Dim colorBorde As Color = If(lblError.Visible, _colorError, _borderColorPersonalizado)
            Using pen As New Pen(colorBorde, _borderSize)
                e.Graphics.DrawPath(pen, path)
            End Using
        End Using
    End Sub

    Private Function RoundedPath(rect As Rectangle, radius As Integer) As GraphicsPath
        Dim path As New GraphicsPath()
        path.AddArc(rect.Left, rect.Top, radius, radius, 180, 90)
        path.AddArc(rect.Right - radius, rect.Top, radius, radius, 270, 90)
        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
        path.AddArc(rect.Left, rect.Bottom - radius, radius, radius, 90, 90)
        path.CloseFigure()
        Return path
    End Function

    ' === Campo requerido orbital ===
    Public Function EsValido() As Boolean
        If _campoRequerido AndAlso String.IsNullOrWhiteSpace(txtCampo.Text) Then
            lblError.Text = _mensajeError
            lblError.Visible = True
            _borderColorNormal = _colorError
            pnlFondo.Invalidate()
            Return False
        Else
            lblError.Visible = False
            _borderColorNormal = Color.LightGray
            pnlFondo.Invalidate()
            Return True
        End If
    End Function

    Private Sub CapitalizarSiEsNecesario(sender As Object, e As EventArgs)
        If Not CapitalizarTexto Then Exit Sub

        Dim textoOriginal As String = txtCampo.Text.Trim()

        If CapitalizarTodasLasPalabras Then
            ' Capitalizar cada palabra
            Dim palabras As String() = textoOriginal.Split(" "c)
            For i As Integer = 0 To palabras.Length - 1
                If palabras(i).Length > 0 Then
                    palabras(i) = Char.ToUpper(palabras(i)(0)) & palabras(i).Substring(1).ToLower()
                End If
            Next
            txtCampo.Text = String.Join(" ", palabras)
        Else
            ' Solo la primera letra de todo
            If textoOriginal.Length > 0 Then
                txtCampo.Text = Char.ToUpper(textoOriginal(0)) & textoOriginal.Substring(1).ToLower()
            End If
        End If
    End Sub




    ' === Propiedades orbitales ===

    Public Property ValidarComoCorreo As Boolean
        Get
            Return _validarComoCorreo
        End Get
        Set(value As Boolean)
            _validarComoCorreo = value
        End Set
    End Property

    ' Capitaliza al perder el foco
    Private _capitalizarTexto As Boolean = False
    Public Property CapitalizarTexto As Boolean
        Get
            Return _capitalizarTexto
        End Get
        Set(value As Boolean)
            _capitalizarTexto = value
        End Set
    End Property

    ' Capitalizar todas las palabras o solo la primera
    Private _capitalizarTodasLasPalabras As Boolean = True
    Public Property CapitalizarTodasLasPalabras As Boolean
        Get
            Return _capitalizarTodasLasPalabras
        End Get
        Set(value As Boolean)
            _capitalizarTodasLasPalabras = value
        End Set
    End Property



    <Category("WilmerUI")>
    Public Property LabelText As String
        Get
            Return _labelText
        End Get
        Set(value As String)
            _labelText = value
            lblTitulo.Text = value
        End Set
    End Property

    <Category("WilmerUI")>
    Public Property PanelBackColor As Color
        Get
            Return _panelBackColor
        End Get
        Set(value As Color)
            _panelBackColor = value
            pnlFondo.BackColor = value
            txtCampo.BackColor = value
        End Set
    End Property

    <Category("WilmerUI")>
    Public Property TextColor As Color
        Get
            Return _textColor
        End Get
        Set(value As Color)
            _textColor = value
            txtCampo.ForeColor = value
        End Set
    End Property

    <Category("WilmerUI")>
    Public Property FontField As Font
        Get
            Return _fontField
        End Get
        Set(value As Font)
            _fontField = value
            txtCampo.Font = value
            lblTitulo.Font = New Font(value.FontFamily, value.Size - 2)
            lblError.Font = New Font(value.FontFamily, value.Size - 3)
        End Set
    End Property

    <Category("WilmerUI")>
    Public Property PaddingAll As Integer
        Get
            Return _paddingAll
        End Get
        Set(value As Integer)
            _paddingAll = value
            pnlFondo.Padding = New Padding(_paddingAll)
        End Set
    End Property

    <Category("WilmerUI")>
    Public Property CampoRequerido As Boolean
        Get
            Return _campoRequerido
        End Get
        Set(value As Boolean)
            _campoRequerido = value
        End Set
    End Property

    <Category("WilmerUI")>
    Public Property MensajeError As String
        Get
            Return _mensajeError
        End Get
        Set(value As String)
            _mensajeError = value
            lblError.Text = value
        End Set
    End Property

    <Category("WilmerUI")>
    Public Property ColorError As Color
        Get
            Return _colorError
        End Get
        Set(value As Color)
            _colorError = value
            lblError.ForeColor = value
        End Set
    End Property

    <Category("WilmerUI")>
    Public Property BorderRadius As Integer
        Get
            Return _borderRadius
        End Get
        Set(value As Integer)
            _borderRadius = value
            pnlFondo.Region = New Region(RoundedPath(pnlFondo.ClientRectangle, _borderRadius))
            pnlFondo.Invalidate()
        End Set
    End Property

    <Category("WilmerUI")>
    Public Property IconoColor As Color
        Get
            Return iconoDerecho.IconColor
        End Get
        Set(value As Color)
            iconoDerecho.IconColor = value
            iconoDerecho.Invalidate()
        End Set
    End Property

    'Ocultar icono si no esta asignado
    <Category("WilmerUI")>
    Public Property IconoDerechoChar As IconChar
        Get
            Return iconoDerecho.IconChar
        End Get
        Set(value As IconChar)
            iconoDerecho.IconChar = value
            iconoDerecho.Visible = (value <> IconChar.None)
            pnlFondo.PerformLayout()  ' Recalcular alineación
            pnlFondo.Invalidate()
        End Set
    End Property

    Public ReadOnly Property TextValue As String
        Get
            Return txtCampo.Text
        End Get
    End Property

    <Category("WilmerUI")>
    Public Property UsarModoContraseña As Boolean
        Get
            Return _usarContraseña
        End Get
        Set(value As Boolean)
            _usarContraseña = value
            txtCampo.UseSystemPasswordChar = False
            txtCampo.PasswordChar = If(_usarContraseña, _caracterContraseña, ControlChars.NullChar)
        End Set
    End Property

    <Category("WilmerUI")>
    Public Property CaracterContraseña As Char
        Get
            Return _caracterContraseña
        End Get
        Set(value As Char)
            _caracterContraseña = value
            If _usarContraseña Then
                txtCampo.PasswordChar = _caracterContraseña
            End If
        End Set
    End Property

    <Category("WilmerUI")>
    Public Property LabelColor As Color
        Get
            Return _labelColor
        End Get
        Set(value As Color)
            _labelColor = value
            lblTitulo.ForeColor = value
        End Set
    End Property

    <Category("WilmerUI")>
    Public Property BorderColor As Color
        Get
            Return _borderColorPersonalizado
        End Get
        Set(value As Color)
            _borderColorPersonalizado = value
            pnlFondo.Invalidate()
        End Set
    End Property

    <Category("WilmerUI")>
    Public Property BorderSize As Integer
        Get
            Return _borderSize
        End Get
        Set(value As Integer)
            _borderSize = value
            pnlFondo.Invalidate()
        End Set
    End Property

    'Como cambio el icono dse la derecha

    'MaskedTextBoxLabelUI1.IconoDerechoChar = IconChar.ExclamationT

End Class
