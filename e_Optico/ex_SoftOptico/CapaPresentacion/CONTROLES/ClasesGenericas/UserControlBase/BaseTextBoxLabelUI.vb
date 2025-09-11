Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports FontAwesome.Sharp

Public Class BaseTextBoxLabelUI
    Inherits UserControl

#Region "CONTROLES Y ESTÉTICA"
    ' === Controles internos ===
    Protected Friend lblTitulo As New Label()
    Protected Friend WithEvents txtCampo As New TextBox()
    Protected Friend lblError As New Label()
    Protected Friend pnlFondo As New Panel()
    Protected Friend pnlSombra As New Panel()
    Protected Friend iconoDerecha As New IconPictureBox()
    Private lblPlaceholder As New Label()

    ' === Estética ===
    Private _borderColor As Color = AppColors._cBasePrimary
    Private _borderColorFocus As Color = AppColors._cBordeSel
    Private _borderColorError As Color = AppColors._cBordeError
    Private _borderSize As Integer = AppLayout.BorderSizeMediun
    Private _borderRadius As Integer = AppLayout.BorderRadiusStandar

    ' === Colores y fuentes ===
    Private _labelColor As Color = AppColors._cLabel
    Private _panelBackColor As Color = AppColors._cBlanco
    Private _sombraBackColor As Color = AppColors._cSombra
    Private _textColor As Color = AppColors._cTexto
    Private _colorError As Color = AppColors._cMsgError
    Private _fontField As Font = New Font(AppFonts.Century, AppFonts.SizeMedium)
    Private _paddingAll As Integer = AppLayout.Padding10
    Private _labelText As String = "Texto:"

    ' === EVENTO KEYPRESS ===
    Public Event CampoKeyPress(sender As Object, e As KeyPressEventArgs)

    ' === Placeholder ===
    Private _placeholder As String = "Escriba aquí..."
    Private _placeholderColor As Color = AppColors._cPlaceHolder
    Private _textColorNormal As Color = Color.Black

#End Region

#Region "PROPIEDADES PÚBLICAS"
    ' === Propiedades comunes ===
    <Category("WilmerUI")>
    Public Property CampoRequerido As Boolean = False

    <Category("WilmerUI")>
    Public Property MensajeError As String = "Campo requerido."

    <Category("WilmerUI")>
    Public Property MaxCaracteres As Integer = 0

    <Category("WilmerUI")>
    Public Property CapitalizarTexto As Boolean = False

    <Category("WilmerUI")>
    Public Property CapitalizarTodasLasPalabras As Boolean = False

    <Category("WilmerUI")>
    Public Property TextoLabel As String
        Get
            Return lblTitulo.Text
        End Get
        Set(value As String)
            lblTitulo.Text = value
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

        lblTitulo.Text = _labelText
        lblTitulo.Font = New Font(AppFonts.Century, AppFonts.SizeSmall)
        lblTitulo.ForeColor = _labelColor
        lblTitulo.Dock = DockStyle.Top
        lblTitulo.Height = AppLayout.ControlLabelHeight

        pnlSombra.Dock = DockStyle.None
        pnlSombra.BackColor = _sombraBackColor
        pnlSombra.Height = AppLayout.PanelHeightStandar
        pnlSombra.Width = 900
        pnlSombra.Margin = Padding.Empty
        pnlSombra.Location = New Point(6, 23)

        pnlFondo.Dock = DockStyle.Top
        pnlFondo.BackColor = _panelBackColor
        pnlFondo.Padding = New Padding(_paddingAll)
        pnlFondo.Height = AppLayout.PanelHeightStandar
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
        lblError.Height = AppLayout.ControlLabelHeight
        lblError.Visible = False
        lblError.Margin = Padding.Empty
        lblError.TextAlign = ContentAlignment.MiddleRight
        lblError.BackColor = Color.Transparent

        iconoDerecha.IconChar = IconChar.InfoCircle
        iconoDerecha.IconColor = AppColors._cIcono
        iconoDerecha.Size = New Size(AppLayout.IconMedium, AppLayout.IconMedium)
        iconoDerecha.Location = New Point(pnlFondo.Width - iconoDerecha.Width - _paddingAll, (pnlFondo.Height - iconoDerecha.Height) \ 2)
        iconoDerecha.Anchor = AnchorStyles.Right Or AnchorStyles.Top
        iconoDerecha.BackColor = Color.Transparent
        iconoDerecha.SizeMode = PictureBoxSizeMode.Zoom
        pnlFondo.Controls.Add(iconoDerecha)

        ' === Placeholder ===
        lblPlaceholder.Text = _placeholder
        lblPlaceholder.ForeColor = _placeholderColor
        lblPlaceholder.BackColor = Color.Transparent
        lblPlaceholder.Font = txtCampo.Font
        lblPlaceholder.TextAlign = ContentAlignment.MiddleLeft
        lblPlaceholder.AutoSize = False
        lblPlaceholder.Location = txtCampo.Location
        lblPlaceholder.Size = txtCampo.Size
        lblPlaceholder.Enabled = False ' Para que no reciba foco ni eventos
        pnlFondo.Controls.Add(lblPlaceholder)
        lblPlaceholder.BringToFront()
        UpdatePlaceholderVisibility()

        Me.Controls.Add(lblError)
        Me.Controls.Add(pnlFondo)
        Me.Controls.Add(pnlSombra)
        Me.Controls.Add(lblTitulo)

        ' Eventos
        AddHandler txtCampo.Enter, AddressOf OnEnterCampo
        AddHandler txtCampo.Leave, AddressOf OnLeaveCampo
        AddHandler txtCampo.TextChanged, AddressOf OnTextChangedCampo
        AddHandler txtCampo.KeyPress, AddressOf OnKeyPressPropagado
        AddHandler pnlFondo.Paint, AddressOf DibujarFondoRedondeado
        AddHandler pnlFondo.Resize, AddressOf OnPanelResize
        AddHandler Me.Resize, AddressOf OnPanelResize

    End Sub
#End Region

#Region "DIBUJO"
    ' === Dibujar borde redondeado ===
    Private Sub DibujarFondoRedondeado(sender As Object, e As PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect As Rectangle = pnlFondo.ClientRectangle
        rect.Inflate(-1, -1)

        Using path As GraphicsPath = RoundedPath(rect, _borderRadius)
            Using brush As New SolidBrush(pnlFondo.BackColor)
                e.Graphics.FillPath(brush, path)
            End Using
            Dim penColor As Color = If(lblError.Visible, _borderColorError, _borderColor)
            Using pen As New Pen(penColor, _borderSize)
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

#Region "EVENTOS INTERNOS"
    ' === Eventos de foco ===
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
            CapitalizarSiEsNecesario()
        End If
        CapitalizarSiEsNecesario()
        pnlFondo.Invalidate()
        UpdatePlaceholderVisibility()
    End Sub

    Private Sub OnTextChangedCampo(sender As Object, e As EventArgs)
        UpdatePlaceholderVisibility()
    End Sub

    ' === Reposicionamiento (para placeholder e icono) ===
    Private Sub OnPanelResize(sender As Object, e As EventArgs)
        ' reajusta txtCampo ancho y posición
        Dim tieneIcono As Boolean = iconoDerecha.Visible
        Dim margenIcono = If(tieneIcono, iconoDerecha.Width + 10, 10)
        txtCampo.Location = New Point(8, (pnlFondo.Height - txtCampo.Height) \ 2)
        txtCampo.Width = pnlFondo.Width - margenIcono - 16

        ' placeholder usa la misma geometría del textbox
        lblPlaceholder.ForeColor = AppColors._cTextoInfo
        lblPlaceholder.Location = txtCampo.Location
        lblPlaceholder.Size = New Size(txtCampo.Width, txtCampo.Height)
        lblPlaceholder.BringToFront()

        If tieneIcono Then
            iconoDerecha.Location = New Point(pnlFondo.Width - iconoDerecha.Width - 8, (pnlFondo.Height - iconoDerecha.Height) \ 2)
        End If
    End Sub
    Private Sub OnKeyPressPropagado(sender As Object, e As KeyPressEventArgs)
        RaiseEvent CampoKeyPress(Me, e)
    End Sub
#End Region

#Region "PROCEDIMIENTO"
    ' === Placeholder visibility update ===
    Private Sub UpdatePlaceholderVisibility()
        lblPlaceholder.Visible = Not txtCampo.Focused AndAlso String.IsNullOrEmpty(txtCampo.Text)
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

#Region "VALIDACIONES"
    ' === Validación básica (sobrescribible) ===
    Public Overridable Function EsValido() As Boolean
        Dim texto = txtCampo.Text.Trim()
        If CampoRequerido AndAlso String.IsNullOrWhiteSpace(texto) Then
            lblError.Text = MensajeError
            lblError.Visible = True
            Return False
        End If

        If MaxCaracteres > 0 AndAlso texto.Length > MaxCaracteres Then
            lblError.Text = $"Máximo {MaxCaracteres} caracteres."
            lblError.Visible = True
            Return False
        End If

        lblError.Visible = False
        Return True
    End Function
    Protected Sub MostrarError(mensaje As String)
        lblError.Text = mensaje
        lblError.Visible = True
        _borderColor = _colorError
        pnlFondo.Invalidate()
    End Sub

    Protected Sub OcultarError()
        lblError.Text = ""
        lblError.Visible = False
        _borderColor = AppColors._cBasePrimary
        pnlFondo.Invalidate()
    End Sub

#End Region

End Class
