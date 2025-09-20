
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports FontAwesome.Sharp

Public Class MultilineTextBoxLabelUI
    Inherits UserControl
    Implements ILimpiable

#Region "CONTROLES Y PROPIEDADES"
    ' === Controles ===
    Private lblTitulo As New Label()
    Private pnlFondo As New Panel()
    Private txtCampo As New TextBox()
    Private lblError As New Label()
    Private lblPlaceholder As New Label()

    ' === Estilos ===
    Private _borderRadius As Integer = AppLayout.BorderRadiusStandar
    Private _borderColorSuccess As Color = AppColors._cBaseSuccess 'Verde
    Private _borderColor As Color = AppColors._cBasePrimary 'Azul
    Private _borderColorFocus As Color = AppColors._cBordeSel 'Anaranjado
    Private _borderSize As Integer = AppLayout.BorderSizeMediun
    Private _borderColorError As Color = AppColors._cMsgError

    Private _shadowColor As Color = AppColors._cPanelSombracolor
    Private _shadowSize As Integer = 3

    '=== Panel y texto ===
    Private _labelText As String = "Texto:"
    Private _labelColor As Color = AppColors._cLabel
    Private _panelBackColor As Color = AppColors._cBlanco
    Private _sombraBackColor As Color = AppColors._cSombra
    Private _textColor As Color = AppColors._cTexto
    Private _fontFieldTexto As Font = New Font(AppFonts.Century, AppFonts.SizeMedium)
    Private _fontFieldTitulo As Font = New Font(AppFonts.Century, AppFonts.SizeSmall)
    Private _fontFieldMsgError As Font = New Font(AppFonts.Segoe, AppFonts.SizeMini)
    Private _paddingAll As Integer = AppLayout.Padding10
    Private iconoDerecho As New IconPictureBox()
    Private _campoRequerido As Boolean = True
    Private _mensajeError As String = AppMensajes.msgCampoRequerido

    Private _capitalizarTexto As Boolean = False
    Private _capitalizarTodasLasPalabras As Boolean = True
    Private _maxCaracteres As Integer = 0 ' 0 = sin límite

    ' === Visual orbital ===
    Private _alturaMultilinea As Integer = 40
    Private alturaObjetivo As Integer = 100
    Private alturaAnimadaActual As Integer = 40

    ' === Placeholder ===
    Private _placeholder As String = "Escriba aquí..."
    Private _placeholderColor As Color = AppColors._cPlaceHolder
#End Region

#Region "PROPIEDADES"
    ' === Propiedades orbitales ===

    Public Property TextoString As String

    ' Capitaliza al perder el foco
    Public Property CapitalizarTexto As Boolean
        Get
            Return _capitalizarTexto
        End Get
        Set(value As Boolean)
            _capitalizarTexto = value
        End Set
    End Property

    ' Capitalizar todas las palabras o solo la primera
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
            Return _fontFieldTexto
        End Get
        Set(value As Font)
            _fontFieldTexto = value
            txtCampo.Font = value
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
            Return _borderColorError
        End Get
        Set(value As Color)
            _borderColorError = value
            lblError.ForeColor = value
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
    Public Property TextString As String
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
    Public Property BorderColor As Color
        Get
            Return _borderColor
        End Get
        Set(value As Color)
            _borderColor = value
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
    <Browsable(True), Category("OrbitalUI")>
    Public Property Placeholder As String
        Get
            Return _placeholder
        End Get
        Set(value As String)
            _placeholder = value
            lblPlaceholder.Text = value
            Me.Invalidate()
        End Set
    End Property

    <Browsable(True), Category("OrbitalUI")>
    Public Property PlaceholderColor As Color
        Get
            Return _placeholderColor
        End Get
        Set(value As Color)
            _placeholderColor = value
            lblPlaceholder.ForeColor = value
            Me.Invalidate()
        End Set
    End Property
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

        ' === Label título ===
        lblTitulo.Text = _labelText
        lblTitulo.Dock = DockStyle.Top
        lblTitulo.Height = AppLayout.ControlLabelHeight
        lblTitulo.ForeColor = _textColor
        lblTitulo.Font = _fontFieldTitulo

        ' === Panel contenedor ===
        pnlFondo.Dock = DockStyle.Top
        pnlFondo.Height = _alturaMultilinea ' usa respaldo privado
        pnlFondo.BackColor = _panelBackColor
        pnlFondo.Padding = New Padding(_paddingAll)
        pnlFondo.Margin = Padding.Empty
        'pnlFondo.Region = New Region(RoundedPath(pnlFondo.ClientRectangle, _borderRadius))

        ' === Campo de texto ===
        txtCampo.BorderStyle = BorderStyle.None
        txtCampo.Font = _fontFieldTexto
        txtCampo.ForeColor = _textColor
        txtCampo.BackColor = _panelBackColor
        txtCampo.Multiline = True ' listo para expansión vertica
        txtCampo.Location = New Point(_paddingAll, _paddingAll)
        txtCampo.Anchor = AnchorStyles.Left Or AnchorStyles.Top
        pnlFondo.Controls.Add(txtCampo)

        ' === Ícono a la derecha ===
        iconoDerecho.IconChar = IconChar.InfoCircle
        iconoDerecho.IconColor = AppColors._cIcono
        iconoDerecho.Size = New Size(AppLayout.IconMedium, AppLayout.IconMedium)
        iconoDerecho.Location = New Point(pnlFondo.Width - iconoDerecho.Width - _paddingAll, (pnlFondo.Height - iconoDerecho.Height) \ 2)
        iconoDerecho.Anchor = AnchorStyles.Right Or AnchorStyles.Top
        iconoDerecho.BackColor = Color.Transparent
        iconoDerecho.SizeMode = PictureBoxSizeMode.Zoom
        pnlFondo.Controls.Add(iconoDerecho)

        ' === Label de error ===
        lblError.Text = ""
        lblError.Font = _fontFieldMsgError
        lblError.ForeColor = _borderColorError
        lblError.Dock = DockStyle.Top
        lblError.Height = AppLayout.ControlLabelHeight
        lblError.Visible = False
        lblError.TextAlign = ContentAlignment.MiddleRight
        lblError.BackColor = Color.Transparent

        ' === Placeholder ===
        lblPlaceholder.Text = _placeholder
        lblPlaceholder.ForeColor = _placeholderColor
        lblPlaceholder.BackColor = Color.Transparent
        lblPlaceholder.Font = txtCampo.Font
        lblPlaceholder.TextAlign = ContentAlignment.TopLeft ' 🔹 Mejor para multilinea
        lblPlaceholder.AutoSize = False
        lblPlaceholder.Enabled = False ' Para que no reciba foco ni eventos
        pnlFondo.Controls.Add(lblPlaceholder)
        lblPlaceholder.BringToFront()
        UpdatePlaceholderVisibility()

        AddHandler pnlFondo.Resize, Sub()
                                        pnlFondo.Region = New Region(RoundedPath(pnlFondo.ClientRectangle, _borderRadius))
                                    End Sub

        ' 🔹 Vincular placeholder al tamaño del txtCampo
        AddHandler txtCampo.Resize, Sub()
                                        lblPlaceholder.Location = txtCampo.Location
                                        lblPlaceholder.Size = txtCampo.Size
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
        Me.Controls.Add(lblTitulo)

        ' === Eventos ===
        AddHandler txtCampo.Leave, AddressOf ValidarCampoFinal
        AddHandler pnlFondo.Resize, AddressOf RecalcularAlineacion
        AddHandler pnlFondo.Paint, AddressOf DibujarFondoRedondeado

        AddHandler txtCampo.Enter, AddressOf OnEnterCampo
        AddHandler txtCampo.Leave, AddressOf OnLeaveCampo
        AddHandler txtCampo.TextChanged, AddressOf OnTextChangedCampo
    End Sub
#End Region

#Region "MÉTODOS PRIVADOS"
    Private Sub OnEnterCampo(sender As Object, e As EventArgs)
        _borderColor = _borderColorFocus
        pnlFondo.Invalidate()
        UpdatePlaceholderVisibility()
    End Sub

    Private Sub OnLeaveCampo(sender As Object, e As EventArgs)
        If Not EsValido() Then
            _borderColor = _borderColorError
        Else
            _borderColor = AppColors._cBaseSuccess
        End If
        CapitalizarSiEsNecesario()
        pnlFondo.Invalidate()
        UpdatePlaceholderVisibility()
    End Sub

    Private Sub OnTextChangedCampo(sender As Object, e As EventArgs)
        UpdatePlaceholderVisibility()
    End Sub
#End Region

#Region "PROCEDIMINTOS PRIVADOS"
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

    Private Sub UpdatePlaceholderVisibility()
        lblPlaceholder.Visible = Not txtCampo.Focused AndAlso String.IsNullOrEmpty(txtCampo.Text)
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
            _borderColor = _borderColorError
        Else
            lblError.Visible = False
            _borderColor = _borderColorSuccess
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
    Private Sub CapitalizarSiEsNecesario()
        If Not CapitalizarTexto Then Exit Sub

        Dim textoOriginal As String = txtCampo.Text.Trim()

        If CapitalizarTodasLasPalabras Then
            Dim palabras = textoOriginal.Split(" "c)
            For i = 0 To palabras.Length - 1
                If palabras(i).Length > 0 Then
                    palabras(i) = Char.ToUpper(palabras(i)(0)) & palabras(i).Substring(1).ToLower()
                End If
            Next
            txtCampo.Text = String.Join(" ", palabras)
        Else
            If textoOriginal.Length > 0 Then
                txtCampo.Text = Char.ToUpper(textoOriginal(0)) & textoOriginal.Substring(1).ToLower()
            End If
        End If
    End Sub

#End Region

#Region "ILimpiable"
    Public Sub Limpiar() Implements ILimpiable.Limpiar
        ' Borra solo el contenido
        Me.TextString = ""
        lblPlaceholder.Visible = True
        pnlFondo.Invalidate()
    End Sub

    Public Sub Resetear() Implements ILimpiable.Resetear
        ' Estado inicial: sin texto, sin error, borde normal
        Me.TextString = ""
        lblError.Text = ""
        lblError.Visible = False
        lblPlaceholder.Visible = True
        _borderColor = AppColors._cBasePrimary
        pnlFondo.Invalidate()
    End Sub
#End Region

#Region "DIBUJO"
    Private Sub DibujarFondoRedondeado(sender As Object, e As PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        Dim r = Math.Min(_borderRadius, Math.Min(pnlFondo.Width, pnlFondo.Height) \ 2)

        ' Rectángulo del panel principal (dejando espacio para sombra fuera)
        Dim rectPanel As New Rectangle(0, 0, pnlFondo.Width - 6, pnlFondo.Height - 6)

        ' === Sombra desplazada 3px abajo y derecha ===
        If _shadowSize > 0 Then
            Dim shadowRect As New Rectangle(rectPanel.X + 3, rectPanel.Y + 3, rectPanel.Width, rectPanel.Height)
            Using pathShadow As GraphicsPath = RoundedPath(shadowRect, r)
                Using brushShadow As New SolidBrush(_shadowColor)
                    e.Graphics.FillPath(brushShadow, pathShadow)
                End Using
            End Using
        End If

        ' === Fondo principal ===
        Using pathPanel As GraphicsPath = RoundedPath(rectPanel, r)
            Using brushPanel As New SolidBrush(pnlFondo.BackColor)
                e.Graphics.FillPath(brushPanel, pathPanel)
            End Using

            ' === Borde ===
            Dim penColor As Color = If(lblError.Visible, _borderColorError, _borderColor)
            If _borderSize > 0 Then
                Using pen As New Pen(penColor, _borderSize)
                    e.Graphics.DrawPath(pen, pathPanel)
                End Using
            End If
        End Using

        ' NO cambiar pnlFondo.Region, para que la sombra quede visible fuera
        ' pnlFondo.Region = New Region(pathPanel)
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

End Class

