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
    Private pnlSombra As New Panel()
    Private txtCampo As New MaskedTextBox()
    Private lblError As New Label()

    Private _tipoNumerico As TipoEntradaNumerica = TipoEntradaNumerica.Ninguno
    Private _campoRequerido As Boolean = True
    Private _mensajeError As String = "Este campo es obligatorio."
    Private _colorError As Color = AppColors._cMsgError

    ' === Visual orbital ===
    Private _borderRadius As Integer = 8
    Private _borderColorNormal As Color = AppColors._cBorde

    ' === Estilos ===
    Private _labelText As String = "Campo numérico:"
    Private _panelBackColor As Color = AppColors._cBlanco
    Private _sombraBackColor As Color = AppColors._cSombra
    Private _textColor As Color = AppColors._cTexto
    Private _fontField As Font = New Font(AppFonts.Century, AppFonts.SizeMedium)
    Private _paddingAll As Integer = 10
    Private _maxCaracteres As Integer = 0
    Private iconoDerecho As New IconPictureBox()
    Private _borderColorPersonalizado As Color = AppColors._cBorde
    Private _borderSize As Integer = 1
    Private _labelColor As Color = AppColors._cLabel
    Private _focusColor As Color = AppColors._cBordeSel
    Private WithEvents innerTextBox As New TextBox

    'Evento keypress
    Public Event CampoKeyPress(sender As Object, e As KeyPressEventArgs)

#Region "PROPIEDADES"

#End Region

#Region "TIPOS ENTRADAS"
    Public Enum TipoEntradaNumerica
        Ninguno
        Entero
        Decimals
    End Enum
#End Region

#Region "CONSTRUCTOR"
    ' === Constructor ===
    Public Sub New()
        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor Or
                    ControlStyles.UserPaint Or
                    ControlStyles.AllPaintingInWmPaint Or
                    ControlStyles.OptimizedDoubleBuffer, True)
        Me.UpdateStyles()
        Me.Size = New Size(300, 100)
        Me.BackColor = Color.Transparent

        lblTitulo.Text = _labelText
        lblTitulo.Font = New Font(_fontField.FontFamily, _fontField.Size - 2)
        lblTitulo.ForeColor = _labelColor
        lblTitulo.Dock = DockStyle.Top
        lblTitulo.Height = 20

        pnlSombra.Dock = DockStyle.None
        pnlSombra.BackColor = _sombraBackColor
        pnlSombra.Height = 37
        pnlSombra.Width = 900
        pnlSombra.Margin = Padding.Empty
        pnlSombra.Location = New Point(6, 23)

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
        iconoDerecho.IconColor = AppColors._cIcono
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
        Me.Controls.Add(pnlSombra)
        Me.Controls.Add(lblTitulo)

        AddHandler txtCampo.TextChanged, AddressOf OnTextChanged
        AddHandler txtCampo.Leave, AddressOf OnLeave
        AddHandler pnlFondo.Paint, AddressOf DibujarFondoRedondeado
        AddHandler pnlFondo.Resize, Sub() pnlFondo.Region = New Region(RoundedPath(pnlFondo.ClientRectangle, _borderRadius))
        AddHandler txtCampo.KeyPress, AddressOf OnKeyPressPropagado
        AddHandler txtCampo.Enter, AddressOf OnEnter

    End Sub
#End Region

#Region "PROPIEDADES"
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
    Public Property FocusColor As Color
        Get
            Return _focusColor
        End Get
        Set(value As Color)
            _focusColor = value
            Me.Invalidate()
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
    Public Property SombraBackColor As Color
        Get
            Return _sombraBackColor
        End Get
        Set(value As Color)
            _sombraBackColor = value
            pnlSombra.BackColor = value
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
            Return _borderColorNormal
        End Get
        Set(value As Color)
            _borderColorNormal = value
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
#End Region

#Region "EVENTOS INTERNOS"
    Public Function TryGetDate() As DateTime?
        If String.IsNullOrWhiteSpace(Me.TextValue) Then Return Nothing

        Dim fecha As DateTime
        If DateTime.TryParse(Me.TextValue, fecha) Then Return fecha
        Return Nothing
    End Function
    Private Sub OnKeyPressPropagado(sender As Object, e As KeyPressEventArgs)
        RaiseEvent CampoKeyPress(Me, e)
    End Sub

    Private Sub OnEnter(sender As Object, e As EventArgs)
        _borderColorNormal = _focusColor
        pnlFondo.Invalidate()
    End Sub
    Private Sub OnTextChanged(sender As Object, e As EventArgs)
        If Not String.IsNullOrWhiteSpace(txtCampo.Text) Then
            ValidarEntrada()
        End If
    End Sub

    Private Sub OnLeave(sender As Object, e As EventArgs)
        ValidarEntrada()
        If lblError.Visible Then
            _borderColorNormal = _colorError
        Else
            _borderColorNormal = _borderColorPersonalizado
        End If
        pnlFondo.Invalidate()
    End Sub

#End Region

#Region "VALIDACIONES"
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

    Public Function EsValido() As Boolean
        Return ValidarEntrada()
    End Function

    Private Sub ValidarCampo(sender As Object, e As EventArgs)
        EsValido()
    End Sub
#End Region

#Region "DIBUJO"
    ' === Fondo redondeado orbital ===
    Private Sub DibujarFondoRedondeado(sender As Object, e As PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect = pnlFondo.ClientRectangle
        rect.Inflate(-1, -1)

        Using path As GraphicsPath = RoundedPath(rect, _borderRadius)
            Using brush As New SolidBrush(pnlFondo.BackColor)
                e.Graphics.FillPath(brush, path)
            End Using
            Dim colorBorde As Color = If(lblError.Visible, _colorError, _borderColorNormal)
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

#End Region

    'Como cambio el icono dse la derecha

    'MaskedTextBoxLabelUI1.IconoDerechoChar = IconChar.ExclamationT

End Class