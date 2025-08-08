
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports FontAwesome.Sharp

Public Class MultilineTextBoxLabelUI
    Inherits UserControl

    ' === Controles ===
    Private lblTitulo As New Label()
    Private pnlFondo As New Panel()
    Private pnlSombra As New Panel()
    Private txtCampo As New TextBox()
    Private lblError As New Label()

    ' === Estilos ===
    Private _labelText As String = "Texto:"
    Private _labelColor As Color = Color.WhiteSmoke
    Private _panelBackColor As Color = Color.FromArgb(80, 94, 129)
    Private _sombraBackColor As Color = Color.LightGray
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
    Private _alturaMultilinea As Integer = 40

    Private alturaObjetivo As Integer = 100
    Private alturaAnimadaActual As Integer = 40

    Private _borderColorPersonalizado As Color = Color.LightGray
    Private _borderSize As Integer = 1

    Private _maxCaracteres As Integer = 0

    'Private WithEvents animadorAltura As New Timer() With {.Interval = 15}

    ' === Constructor ===
    Public Sub New()
        Me.Size = New Size(300, 100)
        Me.BackColor = Color.Transparent
        Me.DoubleBuffered = True

        ' === Label título ===
        lblTitulo.Text = _labelText
        lblTitulo.Dock = DockStyle.Top
        lblTitulo.Height = 20
        lblTitulo.ForeColor = _textColor
        lblTitulo.Font = New Font(_fontField.FontFamily, _fontField.Size - 2)

        pnlSombra.Dock = DockStyle.None
        pnlSombra.BackColor = _sombraBackColor
        pnlSombra.Height = _alturaMultilinea + 0.6
        pnlSombra.Width = 1500
        pnlSombra.Margin = Padding.Empty
        pnlSombra.Location = New Point(6, 23)

        ' === Panel contenedor ===
        pnlFondo.Dock = DockStyle.Top
        pnlFondo.Height = _alturaMultilinea ' usa respaldo privado
        pnlFondo.BackColor = _panelBackColor
        pnlFondo.Padding = New Padding(_paddingAll)
        pnlFondo.Margin = Padding.Empty
        'pnlFondo.Region = New Region(RoundedPath(pnlFondo.ClientRectangle, _borderRadius))

        ' === Campo de texto ===
        txtCampo.BorderStyle = BorderStyle.None
        txtCampo.Font = _fontField
        txtCampo.ForeColor = _textColor
        txtCampo.BackColor = _panelBackColor
        txtCampo.Multiline = True ' listo para expansión vertica
        txtCampo.Location = New Point(_paddingAll, _paddingAll)
        txtCampo.Anchor = AnchorStyles.Left Or AnchorStyles.Top
        pnlFondo.Controls.Add(txtCampo)

        ' === Ícono a la derecha ===
        iconoDerecho.IconChar = IconChar.InfoCircle
        iconoDerecho.IconColor = Color.White
        iconoDerecho.Size = New Size(24, 24)
        iconoDerecho.Location = New Point(pnlFondo.Width - iconoDerecho.Width - _paddingAll, (pnlFondo.Height - iconoDerecho.Height) \ 2)
        iconoDerecho.Anchor = AnchorStyles.Right Or AnchorStyles.Top
        iconoDerecho.BackColor = Color.Transparent
        iconoDerecho.SizeMode = PictureBoxSizeMode.Zoom
        pnlFondo.Controls.Add(iconoDerecho)
        'pnlFondo.Controls.Add(iconoDerecho)

        ' === Label de error ===
        lblError.Text = ""
        lblError.ForeColor = _colorError
        lblError.Dock = DockStyle.Top
        lblError.Height = 20
        lblError.Visible = False
        lblError.TextAlign = ContentAlignment.MiddleRight

        AddHandler pnlFondo.Resize, Sub()
                                        pnlFondo.Region = New Region(RoundedPath(pnlFondo.ClientRectangle, _borderRadius))
                                    End Sub

        AddHandler pnlFondo.Resize, Sub()
                                        Dim margenDerecho As Integer = If(iconoDerecho.Visible, iconoDerecho.Width + (_paddingAll * 2), _paddingAll)

                                        ' Si el TextBox es multilinea, usa todo el alto disponible menos padding
                                        If txtCampo.Multiline Then
                                            txtCampo.Size = New Size(pnlFondo.Width - _paddingAll - margenDerecho, pnlFondo.Height - (_paddingAll * 2))
                                            txtCampo.Location = New Point(_paddingAll, _paddingAll)
                                        Else
                                            ' Si no es multilinea, mantener altura fija y centrar verticalmente
                                            txtCampo.Size = New Size(pnlFondo.Width - _paddingAll - margenDerecho, 25)
                                            txtCampo.Location = New Point(_paddingAll, (pnlFondo.Height - txtCampo.Height) \ 2)
                                        End If

                                        ' Alinear el ícono a la derecha si está visible
                                        If iconoDerecho.Visible Then
                                            iconoDerecho.Location = New Point(pnlFondo.Width - iconoDerecho.Width - _paddingAll, (pnlFondo.Height - iconoDerecho.Height) \ 2)
                                        End If
                                    End Sub

        Me.Controls.Add(lblError)
        Me.Controls.Add(pnlFondo)
        Me.Controls.Add(pnlSombra)
        Me.Controls.Add(lblTitulo)

        ' === Eventos ===
        AddHandler txtCampo.TextChanged, AddressOf OnTextChanged
        AddHandler txtCampo.Leave, AddressOf ValidarCampoFinal
        AddHandler pnlFondo.Resize, AddressOf RecalcularAlineacion
        AddHandler pnlFondo.Paint, AddressOf DibujarFondoRedondeado
    End Sub

    Private Sub AjustarAlturaCampo()
        If txtCampo.Multiline Then
            pnlFondo.Height = alturaObjetivo  ' Puedes ajustar esta altura orbital según estilo
            txtCampo.TextAlign = HorizontalAlignment.Left
        Else
            pnlFondo.Height = alturaAnimadaActual
            txtCampo.TextAlign = HorizontalAlignment.Left
        End If
    End Sub

    Private Sub RecalcularAlineacion(sender As Object, e As EventArgs)
        Dim espacioIcono = If(iconoDerecho.Visible, iconoDerecho.Width + (_paddingAll * 2), 0)

        txtCampo.Size = New Size(pnlFondo.Width - espacioIcono - (_paddingAll * 2), txtCampo.Height)
        txtCampo.Location = New Point(_paddingAll, (pnlFondo.Height - txtCampo.Height) \ 2)

        If iconoDerecho.Visible Then
            iconoDerecho.Location = New Point(
                                                pnlFondo.Width - iconoDerecho.Width - _paddingAll,
                                                _paddingAll
                                            )
            iconoDerecho.BringToFront()
        End If
    End Sub

    Private Sub OnTextChanged(sender As Object, e As EventArgs)
        If lblError.Visible AndAlso Not String.IsNullOrWhiteSpace(txtCampo.Text) Then
            lblError.Visible = False
            _borderColorNormal = _borderColorPersonalizado
            pnlFondo.Invalidate()
        End If

        ' Validación opcional mientras escribe
        If Not String.IsNullOrWhiteSpace(txtCampo.Text) Then
            ValidarEntrada()
        End If

        txtCampo.Invalidate()
    End Sub

    Private Function ValidarEntrada() As Boolean
        Dim texto As String = txtCampo.Text.Trim()
        Dim mensajeError As String = ""
        Dim valido As Boolean = True

        If _campoRequerido AndAlso String.IsNullOrWhiteSpace(texto) Then
            mensajeError = _mensajeError
            valido = False
        ElseIf _maxCaracteres > 0 AndAlso texto.Length > _maxCaracteres Then
            mensajeError = $"Máximo {_maxCaracteres} caracteres."
            valido = False
        End If

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

    Private Sub ValidarCampoFinal(sender As Object, e As EventArgs)
        ' === Capitalización si está activada ===
        If CapitalizarTexto Then
            Dim textoOriginal As String = txtCampo.Text.Trim()

            If CapitalizarTodasLasPalabras Then
                Dim palabras = textoOriginal.Split(" "c)
                For i = 0 To palabras.Length - 1
                    If palabras(i).Length > 0 Then
                        palabras(i) = Char.ToUpper(palabras(i)(0)) & palabras(i).Substring(1).ToLower()
                    End If
                Next
                txtCampo.Text = String.Join(" ", palabras)
            ElseIf textoOriginal.Length > 0 Then
                txtCampo.Text = Char.ToUpper(textoOriginal(0)) & textoOriginal.Substring(1).ToLower()
            End If
        End If

        ' === Validación centralizada ===
        ValidarEntrada()
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

    ' === Propiedades orbitales ===

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

    <Category("WilmerUI")>
    Public Property Multilinea As Boolean
        Get
            Return txtCampo.Multiline
        End Get
        Set(value As Boolean)
            txtCampo.Multiline = value
            AjustarAlturaCampo()
            txtCampo.Invalidate()
        End Set
    End Property

    <Category("WilmerUI")>
    Public Property AlturaMultilinea As Integer
        Get
            Return _alturaMultilinea
        End Get
        Set(value As Integer)
            _alturaMultilinea = value
            pnlFondo.Height = value
            txtCampo.Multiline = True
            txtCampo.Height = value - (_paddingAll * 2)
            RecalcularAlineacion(Nothing, Nothing)
            pnlFondo.Region = New Region(RoundedPath(pnlFondo.ClientRectangle, _borderRadius))
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

End Class

