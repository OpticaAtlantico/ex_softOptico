Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports FontAwesome.Sharp

Public Class MaskedTextBoxLabelUI
    Inherits UserControl

    ' === Controles ===
    Private lblTitulo As New Label()
    Private pnlFondo As New Panel()
    Private txtCampo As New MaskedTextBox()
    Private lblError As New Label()

    ' === Estilos ===
    Private _labelText As String = "Campo numérico:"
    Private _panelBackColor As Color = Color.FromArgb(80, 94, 129)
    Private _textColor As Color = Color.WhiteSmoke
    Private _fontField As Font = New Font("Century Gothic", 12)
    Private _paddingAll As Integer = 10
    Private _maxCaracteres As Integer = 0
    Private iconoDerecho As New IconPictureBox()
    Private _borderColorPersonalizado As Color = Color.LightGray
    Private _borderSize As Integer = 1
    Private _labelColor As Color = Color.WhiteSmoke

    Private WithEvents innerTextBox As New TextBox

    'Evento keypress
    Public Event CampoKeyPress(sender As Object, e As KeyPressEventArgs)

    ' === Validación ===
    Public Enum TipoEntradaNumerica
        Ninguno
        Entero
        Decimals
    End Enum

    Private _tipoNumerico As TipoEntradaNumerica = TipoEntradaNumerica.Ninguno
    Private _campoRequerido As Boolean = True
    Private _mensajeError As String = "Este campo es obligatorio."
    Private _colorError As Color = Color.Firebrick

    ' === Visual orbital ===
    Private _borderRadius As Integer = 5
    Private _borderColorNormal As Color = Color.LightGray

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

        AddHandler txtCampo.TextChanged, AddressOf OnTextChanged
        AddHandler txtCampo.Leave, AddressOf OnLeave
        AddHandler pnlFondo.Paint, AddressOf DibujarFondoRedondeado
        AddHandler pnlFondo.Resize, Sub() pnlFondo.Region = New Region(RoundedPath(pnlFondo.ClientRectangle, _borderRadius))
        AddHandler txtCampo.KeyPress, AddressOf OnKeyPressPropagado

    End Sub
    Private Sub OnKeyPressPropagado(sender As Object, e As KeyPressEventArgs)
        RaiseEvent CampoKeyPress(Me, e)
    End Sub


    ' === Validación automática orbital ===
    Private Function ValidarEntrada() As Boolean
        Dim texto As String = txtCampo.Text.Trim()
        Dim mensajeError As String = ""
        Dim valido As Boolean = True

        ' Validación requerida
        If _campoRequerido AndAlso String.IsNullOrEmpty(texto) Then
            mensajeError = _mensajeError
            valido = False

            ' Validación numérica
        ElseIf _tipoNumerico = TipoEntradaNumerica.Entero AndAlso Not Integer.TryParse(texto, Nothing) Then
            mensajeError = "Solo se permiten números enteros."
            valido = False

        ElseIf _tipoNumerico = TipoEntradaNumerica.Decimals AndAlso Not Decimal.TryParse(texto, Nothing) Then
            mensajeError = "Solo se permiten números decimales."
            valido = False

            ' Validación de longitud
        ElseIf _maxCaracteres > 0 AndAlso texto.Length > _maxCaracteres Then
            mensajeError = $"Máximo {_maxCaracteres} caracteres."
            valido = False
        End If

        ' Mostrar resultado
        If Not valido Then
            lblError.Text = mensajeError
            lblError.Visible = True
            _borderColorNormal = _colorError
        Else
            lblError.Visible = False
            _borderColorNormal = _borderColorPersonalizado
        End If

        pnlFondo.Invalidate()
        Return valido
    End Function

    Private Sub OnTextChanged(sender As Object, e As EventArgs)
        If Not String.IsNullOrWhiteSpace(txtCampo.Text) Then
            ValidarEntrada()
        End If
    End Sub

    Private Sub OnLeave(sender As Object, e As EventArgs)
        ValidarEntrada()
    End Sub

    Public Function EsValido() As Boolean
        Return ValidarEntrada()
    End Function

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

    Private Sub ValidarCampo(sender As Object, e As EventArgs)
        EsValido()
    End Sub

    Public Function TryGetDate() As DateTime?
        If String.IsNullOrWhiteSpace(Me.TextValue) Then Return Nothing

        Dim fecha As DateTime
        If DateTime.TryParse(Me.TextValue, fecha) Then Return fecha
        Return Nothing
    End Function


    ' === Propiedades orbitales ===

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
    Public Property TipoNumerico As TipoEntradaNumerica
        Get
            Return _tipoNumerico
        End Get
        Set(value As TipoEntradaNumerica)
            _tipoNumerico = value
        End Set
    End Property

    <Category("WilmerUI")>
    Public Property MascaraPersonalizada As String
        Get
            Return txtCampo.Mask
        End Get
        Set(value As String)
            txtCampo.Mask = value
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

    <Browsable(False)>
    Public Property TextoUsuario As String
        Get
            Return txtCampo.Text
        End Get
        Set(value As String)
            txtCampo.Text = value
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

    Public Property SelectionStart As Integer
        Get
            Return innerTextBox.SelectionStart
        End Get
        Set(value As Integer)
            innerTextBox.SelectionStart = value
        End Set
    End Property

    <Category("WilmerUI")>
    Public Property MaxCaracteres As Integer
        Get
            Return _maxCaracteres
        End Get
        Set(value As Integer)
            _maxCaracteres = value
        End Set
    End Property

    'Como cambio el icono dse la derecha

    'MaskedTextBoxLabelUI1.IconoDerechoChar = IconChar.ExclamationT

End Class