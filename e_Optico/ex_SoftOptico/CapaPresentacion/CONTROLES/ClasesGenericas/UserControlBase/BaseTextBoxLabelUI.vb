Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports FontAwesome.Sharp

Public Class BaseTextBoxLabelUI
    Inherits UserControl
    Implements ILimpiable

#Region "CONTROLES Y ESTÉTICA"
    ' === Controles internos ===
    Protected Friend lblTitulo As New Label()
    Protected Friend WithEvents txtCampo As New TextBox()
    Protected Friend lblError As New Label()
    Protected Friend pnlFondo As New Panel()
    Protected Friend iconoDerecha As New IconPictureBox()
    Protected Friend lblPlaceholder As New Label()

    ' === Estética ===
    Private _borderColor As Color = AppColors._cBasePrimary
    Private _borderColorFocus As Color = AppColors._cBordeSel
    Private _borderColorError As Color = AppColors._cBordeError
    Private _borderColorSuccess As Color = AppColors._cBaseSuccess
    Private _borderSize As Integer = AppLayout.BorderSizeMediun
    Private _borderRadius As Integer = AppLayout.BorderRadiusStandar

    Private _shadowColor As Color = AppColors._cPanelSombracolor
    Private _shadowSize As Integer = 3

    ' === Colores y fuentes ===
    Private _labelColor As Color = AppColors._cLabel
    Private _panelBackColor As Color = AppColors._cBlanco
    Private _sombraBackColor As Color = AppColors._cSombra
    Private _textColor As Color = AppColors._cTexto
    Private _colorError As Color = AppColors._cMsgError
    Public _mostrarError As Boolean = False

    Private _fontFieldTexto As Font = New Font(AppFonts.Century, AppFonts.SizeMedium)
    Private _fontFieldTitulo As Font = New Font(AppFonts.Century, AppFonts.SizeSmall)
    Private _fontFieldMsgError As Font = New Font(AppFonts.Segoe, AppFonts.SizeMini)

    Private _paddingAll As Integer = AppLayout.Padding10
    Private _labelText As String = "Texto:"

    ' === EVENTO KEYPRESS ===
    Public Event CampoKeyPress(sender As Object, e As KeyPressEventArgs)

    ' === Placeholder ===
    Private _placeholder As String = "Escriba aquí..."
    Private _placeholderColor As Color = AppColors._cPlaceHolder
    Private _textColorNormal As Color = Color.Black

    Private _validarComoCorreo As Boolean = False
    Private _placeholderVisible As Boolean = True
#End Region

#Region "PROPIEDADES PÚBLICAS"
    ' === Propiedades comunes ===
    <Category("WilmerUI")>
    Public Property CampoRequerido As Boolean = False
    <Category("WilmerUI")>
    Public Property PaddingIzquierda As Integer = 8
    <Category("WilmerUI")>
    Public Property PaddingIzquierdaIcono As Integer = 10
    <Category("WilmerUI")>
    Public Property MensajeError As String = AppMensajes.msgCampoRequerido

    <Category("WilmerUI")>
    Public Property MaxCaracteres As Integer = 0

    <Category("WilmerUI")>
    Public Property MinCaracteres As Integer = 0

    <Category("WilmerUI")>
    Public Property CapitalizarTexto As Boolean = False

    <Category("WilmerUI")>
    Public Property CapitalizarTodasLasPalabras As Boolean = False

    <Category("WilmerUI")>
    Public Property IconoColor As Color
        Get
            Return iconoDerecha.IconColor
        End Get
        Set(value As Color)
            iconoDerecha.IconColor = value
            iconoDerecha.Invalidate()
        End Set
    End Property

    'Ocultar icono si no esta asignado
    <Category("WilmerUI")>
    Public Property IconoDerechoChar As IconChar
        Get
            Return iconoDerecha.IconChar
        End Get
        Set(value As IconChar)
            iconoDerecha.IconChar = value
            iconoDerecha.Visible = (value <> IconChar.None)
            pnlFondo.PerformLayout()  ' Recalcular alineación
            pnlFondo.Invalidate()
        End Set
    End Property

    <Category("WilmerUI")>
    Public Property TextoLabel As String
        Get
            Return lblTitulo.Text
        End Get
        Set(value As String)
            lblTitulo.Text = value
            Me.Invalidate()
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
            UpdatePlaceholderVisibility()
        End Set
    End Property


    <Category("WilmerUI")>
    Public Property ColorTitulo As Color
        Get
            Return _labelColor
        End Get
        Set(value As Color)
            _labelColor = value
            lblTitulo.ForeColor = value
            Me.Invalidate()
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

    'Validar el correo
    Public Property ValidarComoCorreo As Boolean
        Get
            Return _validarComoCorreo
        End Get
        Set(value As Boolean)
            _validarComoCorreo = value
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

        ' === Configuración de controles ===
        ' === Título ===
        lblTitulo.Text = _labelText
        lblTitulo.Font = _fontFieldTitulo
        lblTitulo.ForeColor = _labelColor
        lblTitulo.Dock = DockStyle.Top
        lblTitulo.Height = AppLayout.ControlLabelHeight

        ' === Panel de fondo ===
        pnlFondo.Dock = DockStyle.Top
        pnlFondo.BackColor = _panelBackColor
        pnlFondo.Padding = New Padding(0)
        pnlFondo.Height = AppLayout.PanelHeightStandar
        pnlFondo.Margin = Padding.Empty

        ' === TextBox ===
        txtCampo.BorderStyle = BorderStyle.None
        txtCampo.Font = _fontFieldTexto
        txtCampo.ForeColor = _textColor
        txtCampo.BackColor = _panelBackColor
        txtCampo.TextAlign = HorizontalAlignment.Left
        txtCampo.Size = New Size(pnlFondo.Width - 30, 30) ' ajusta ancho para dejar espacio al ícono
        txtCampo.Location = New Point(PaddingIzquierda, (pnlFondo.Height - txtCampo.Height) \ 2 - 2)
        txtCampo.Anchor = AnchorStyles.Left Or AnchorStyles.Top
        pnlFondo.Controls.Add(txtCampo)

        ' === Label de error ===
        lblError.Text = ""
        lblError.Font = _fontFieldMsgError
        lblError.ForeColor = _colorError
        lblError.Dock = DockStyle.Top
        lblError.Height = AppLayout.ControlLabelHeight
        lblError.Visible = False
        lblError.Margin = Padding.Empty
        lblError.TextAlign = ContentAlignment.MiddleRight
        lblError.BackColor = Color.Transparent

        ' === Icono derecho ===
        iconoDerecha.IconChar = IconChar.InfoCircle
        iconoDerecha.IconColor = AppColors._cIcono
        iconoDerecha.Size = New Size(AppLayout.IconMedium, AppLayout.IconMedium)
        iconoDerecha.Location = New Point(pnlFondo.Width - iconoDerecha.Width - _paddingAll, (pnlFondo.Height - iconoDerecha.Height) \ 2)
        iconoDerecha.Anchor = AnchorStyles.Right Or AnchorStyles.Top
        iconoDerecha.BackColor = AppColors._cFondoTransparente
        iconoDerecha.SizeMode = PictureBoxSizeMode.Zoom
        pnlFondo.Controls.Add(iconoDerecha)

        ' === Placeholder ===
        lblPlaceholder.Text = _placeholder
        lblPlaceholder.ForeColor = _placeholderColor
        lblPlaceholder.BackColor = Color.Transparent
        lblPlaceholder.Font = _fontFieldTexto
        lblPlaceholder.TextAlign = ContentAlignment.MiddleLeft
        lblPlaceholder.AutoSize = False
        lblPlaceholder.Location = txtCampo.Location
        lblPlaceholder.Size = txtCampo.Size
        lblPlaceholder.Enabled = False ' Para que no reciba foco ni eventos
        pnlFondo.Controls.Add(lblPlaceholder)
        lblPlaceholder.BringToFront()
        UpdatePlaceholderVisibility()

        ' === Agregar controles al UserControl ===
        Me.Controls.Add(lblError)
        Me.Controls.Add(pnlFondo)
        Me.Controls.Add(lblTitulo)

        ' Eventos
        AddHandler txtCampo.Enter, AddressOf OnEnterCampo
        AddHandler txtCampo.Leave, AddressOf ValidarCampoFinal
        AddHandler txtCampo.TextChanged, AddressOf ValidarEnTiempoReal ' Para validar al cambiar texto
        AddHandler txtCampo.KeyPress, AddressOf OnKeyPressPropagado
        AddHandler pnlFondo.Paint, AddressOf DibujarFondoRedondeado
        AddHandler pnlFondo.Resize, AddressOf OnPanelResize
        AddHandler Me.Resize, AddressOf OnPanelResize

        AddHandler txtCampo.Leave, AddressOf OnLeaveCampo ' Para validar al perder foco
        AddHandler txtCampo.TextChanged, AddressOf OnTextChangedCampo
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

    Public Sub OnPanelResize(sender As Object, e As EventArgs)
        ' Ajusta el txtCampo verticalmente
        Dim tieneIcono As Boolean = iconoDerecha.Visible
        Dim margenIcono = If(tieneIcono, iconoDerecha.Width + PaddingIzquierdaIcono, 10)

        ' Aquí se ajusta la posición Y, restando el valor para subir el campo
        txtCampo.Location = New Point(PaddingIzquierda, (pnlFondo.Height - txtCampo.Height) \ 2 - 2) ' Ajusta a tu necesidad (valor negativo mueve hacia arriba)

        txtCampo.Width = pnlFondo.Width - margenIcono - 16

        ' Actualiza la posición del placeholder
        lblPlaceholder.ForeColor = AppColors._cTextoInfo
        lblPlaceholder.Location = txtCampo.Location
        lblPlaceholder.Size = New Size(txtCampo.Width, txtCampo.Height)
        lblPlaceholder.BringToFront()

        ' Reposicionar el icono si es visible
        If tieneIcono Then
            iconoDerecha.Location = New Point(pnlFondo.Width - iconoDerecha.Width - 8, (pnlFondo.Height - iconoDerecha.Height) \ 2)
        End If
    End Sub

#End Region

#Region "EVENTOS INTERNOS"
    ' === Eventos de foco ===
    Private Sub OnEnterCampo(sender As Object, e As EventArgs)
        _borderColor = _borderColorFocus
        UpdatePlaceholderVisibility()
        pnlFondo.Invalidate()
    End Sub

    Private Sub OnLeaveCampo(sender As Object, e As EventArgs)
        EsValido()
        If lblError.Visible Then
            _borderColor = _borderColorError
        Else
            _borderColor = AppColors._cBaseSuccess
            CapitalizarSiEsNecesario()
        End If
        UpdatePlaceholderVisibility()
        pnlFondo.Invalidate()
    End Sub

    Private Sub OnTextChangedCampo(sender As Object, e As EventArgs)
        If Not String.IsNullOrWhiteSpace(txtCampo.Text) Then
            EsValido()
        End If
        'UpdatePlaceholderVisibility()
    End Sub

    Private Sub OnKeyPressPropagado(sender As Object, e As KeyPressEventArgs)
        RaiseEvent CampoKeyPress(Me, e)
    End Sub
#End Region

#Region "PROCEDIMIENTO"
    ' === Placeholder visibility update ===
    Private Sub UpdatePlaceholderVisibility()
        'lblPlaceholder.Visible = (Not txtCampo.Focused) AndAlso String.IsNullOrEmpty(txtCampo.Text)
        Dim debeMostrar As Boolean = String.IsNullOrWhiteSpace(txtCampo.Text) AndAlso Not txtCampo.Focused

        ' Solo repintar si hay cambio real
        If debeMostrar <> _placeholderVisible Then
            lblPlaceholder.Visible = debeMostrar
            _placeholderVisible = debeMostrar
        End If
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
    Private Function EsCorreoValido(correo As String) As Boolean
        Try
            Dim addr As New System.Net.Mail.MailAddress(correo)
            Return addr.Address = correo
        Catch
            Return False
        End Try
    End Function

    Private Sub ValidarCampoFinal(sender As Object, e As EventArgs)
        CapitalizarSiEsNecesario()
        EsValido()
    End Sub
    Private Sub ValidarEnTiempoReal(sender As Object, e As EventArgs)
        EsValido()
    End Sub
#End Region

#Region "VALIDACIONES"

    Public Overridable Function EsValido() As Boolean
        Dim texto As String = txtCampo.Text.Trim()
        Dim mensajeError As String = ""
        Dim _esValido As Boolean = True

        ' === Campo requerido ===
        If _CampoRequerido AndAlso String.IsNullOrWhiteSpace(texto) Then
            mensajeError = _MensajeError
            _esValido = False

            ' === Validar como correo si aplica ===
        ElseIf ValidarComoCorreo AndAlso Not EsCorreoValido(texto) Then
            mensajeError = AppMensajes.msgCorreoInvalido
            _esValido = False

            ' === Validar longitud máxima ===
        ElseIf _MaxCaracteres > 0 AndAlso texto.Length > _MaxCaracteres Then
            mensajeError = $"Máximo {_MaxCaracteres} caracteres."
            _esValido = False

            ' === Validar longitud mínima ===
        ElseIf _MinCaracteres > 0 AndAlso texto.Length < _MinCaracteres Then
            mensajeError = $"Mínimo {_MinCaracteres} caracteres."
            _esValido = False

        End If

        ' === Mostrar resultado visual ===
        If Not _esValido Then
            lblError.Text = mensajeError
            lblError.Visible = True
            _borderColor = _colorError
        Else
            lblError.Visible = False
            _borderColor = _borderColorSuccess
        End If

        pnlFondo.Invalidate()
        Return _esValido
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
        _borderColor = _borderColorSuccess
        pnlFondo.Invalidate()
    End Sub
#End Region

#Region "ILimpiable"

    ''' <summary>
    ''' Limpia solo el contenido del campo (texto).
    ''' Mantiene errores o estado visual si ya estaban.
    ''' </summary>
    Public Overridable Sub Limpiar() Implements ILimpiable.Limpiar
        Me.TextString = ""
        lblPlaceholder.Visible = True
        pnlFondo.Invalidate()
    End Sub

    ''' <summary>
    ''' Restablece el control a su estado inicial: sin texto, sin error, sin borde rojo.
    ''' </summary>
    Public Overridable Sub Resetear() Implements ILimpiable.Resetear
        ' 🔹 Borrar texto
        Me.TextString = ""

        ' 🔹 Quitar error
        lblError.Text = ""
        lblError.Visible = False

        ' 🔹 Placeholder visible
        UpdatePlaceholderVisibility()

        ' 🔹 Borde normal
        txtCampo.BackColor = Color.White
        txtCampo.ForeColor = Color.Black

        ' 🔹 Color del fondo del border del panel
        _borderColor = AppColors._cBasePrimary

        ' 🔹 Forzar repintado
        pnlFondo.Invalidate()
    End Sub

#End Region

End Class
