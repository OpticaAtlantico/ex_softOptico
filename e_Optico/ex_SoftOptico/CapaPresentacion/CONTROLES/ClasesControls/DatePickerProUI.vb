Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Globalization
Imports FontAwesome.Sharp

Public Class DatePickerProUI
    Inherits UserControl

    ' === Controles Base ===
    Private lblTitulo As New Label()
    Private pnlFondo As New Panel()
    Private txtCampo As New MaskedTextBox("00/00/0000")
    Private lblError As New Label()
    Private iconoDerecho As New IconPictureBox()

    '=== Controles del Calendario ===
    Private _btnCalendario As New IconButton()
    Private _pnlCalendario As New Panel()
    Private _lblMes As New Label()
    Private _btnPrev As New IconButton()
    Private _btnNext As New IconButton()
    Private _tblDias As New TableLayoutPanel()

    ' === Estilos y propiedades ===
    Private _labelText As String = "Fecha"
    Private _labelColor As Color = AppColors._cLabel
    Private _panelBackColor As Color = AppColors._cBlanco
    Private _textColor As Color = AppColors._cTexto

    Private _shadowColor As Color = AppColors._cPanelSombracolor
    Private _shadowSize As Integer = 3

    Private _fontFieldTitulo As Font = New Font(AppFonts.Century, AppFonts.SizeSmall)
    Private _fontFieldTexto As Font = New Font(AppFonts.Century, AppFonts.SizeMedium)
    Private _fontFieldError As Font = New Font(AppFonts.Segoe, AppFonts.SizeMini)

    Private _paddingAll As Integer = AppLayout.Padding10
    Private _borderColor As Color = AppColors._cBorde
    Private _borderSize As Integer = AppLayout.BorderSizeMediun
    Private _borderRadius As Integer = AppLayout.BorderRadiusStandar
    Private _iconoColor As Color = AppColors._cIcono
    Private _colorError As Color = AppColors._cMsgError
    Private _campoRequerido As Boolean = True
    Private _mensajeError As String = AppMensajes.msgCampoRequerido
    Private _borderColorPersonalizado As Color = AppColors._cBorde
    Private _borderColorNormal As Color = AppColors._cBorde
    Private _borderColorSuccess As Color = AppColors._cBaseSuccess
    Private _borderColorError As Color = AppColors._cBordeError
    Private _focusColor As Color = AppColors._cBordeSel
    'Evento keypress
    Public Event CampoKeyPress(sender As Object, e As KeyPressEventArgs)

    ' Estado interno
    Private _fechaActual As Date = Date.Today
    Private _fechaSeleccionada As Date? = Nothing

#Region "PROPIEDADES"
    ' === Propiedades públicas ===

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
            pnlFondo.Padding = New Padding(value)
        End Set
    End Property

    <Category("WilmerUI")>
    Public Property BorderRadius As Integer
        Get
            Return _borderRadius
        End Get
        Set(value As Integer)
            If _borderRadius <> value Then
                _borderRadius = value
                ActualizarRegion()
                Me.Invalidate()
            End If
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

    <Category("WilmerUI")>
    Public Property IconoDerechoChar As IconChar
        Get
            Return iconoDerecho.IconChar
        End Get
        Set(value As IconChar)
            iconoDerecho.IconChar = value
            iconoDerecho.Visible = (value <> IconChar.None)
        End Set
    End Property

    <Category("WilmerUI")>
    Public Property IconoColor As Color
        Get
            Return _iconoColor
        End Get
        Set(value As Color)
            _iconoColor = value
            iconoDerecho.IconColor = value
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
        End Set
    End Property

    <Browsable(False)>
    Public ReadOnly Property TextValue As String
        Get
            Return txtCampo.Text
        End Get
    End Property

    <Category("WilmerUI")>
    Public Property FechaSeleccionada As Date?
        Get
            Dim fecha As DateTime
            If DateTime.TryParseExact(txtCampo.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, fecha) Then
                Return fecha
            End If
            Return Date.Now
        End Get
        Set(value As Date?)
            If value.HasValue Then
                txtCampo.Text = value.Value.ToString("dd/MM/yyyy")
            Else
                txtCampo.Clear()
            End If
        End Set
    End Property
    Public Property ValorFecha As Date?
        Get
            Return FechaSeleccionada
        End Get
        Set(value As Date?)
            FechaSeleccionada = value
            If value.HasValue Then
                txtCampo.Text = value.Value.ToString("dd/MM/yyyy")
                _fechaActual = value.Value
            Else
                txtCampo.Clear()
            End If
            RenderCalendario()
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

        ' Label
        lblTitulo.Text = _labelText
        lblTitulo.Font = _fontFieldTitulo
        lblTitulo.ForeColor = _labelColor
        lblTitulo.Dock = DockStyle.Top
        lblTitulo.Height = AppLayout.ControlLabelHeight

        ' Panel fondo
        pnlFondo.Dock = DockStyle.Top
        pnlFondo.Height = AppLayout.PanelHeightStandar
        pnlFondo.BackColor = _panelBackColor
        pnlFondo.Padding = New Padding(_paddingAll)
        pnlFondo.Margin = Padding.Empty

        ' TextBox fecha
        txtCampo.BorderStyle = BorderStyle.None
        txtCampo.Font = _fontFieldTexto
        txtCampo.ForeColor = _textColor
        txtCampo.BackColor = _panelBackColor
        txtCampo.Mask = "00/00/0000"
        txtCampo.PromptChar = "_"c
        txtCampo.TextMaskFormat = MaskFormat.IncludePromptAndLiterals
        txtCampo.ValidatingType = GetType(DateTime)
        txtCampo.Size = New Size(pnlFondo.Width - 40, 30)
        txtCampo.Location = New Point(_paddingAll, (pnlFondo.Height - txtCampo.Height) \ 2)
        pnlFondo.Controls.Add(txtCampo)

        ' --- Botón calendario ---
        _btnCalendario.IconChar = IconChar.CalendarDays
        _btnCalendario.IconSize = AppLayout.IconMedium
        _btnCalendario.Width = AppLayout.IconMedium
        _btnCalendario.Dock = DockStyle.Right
        _btnCalendario.FlatStyle = FlatStyle.Flat
        _btnCalendario.FlatAppearance.BorderSize = 0
        _btnCalendario.Cursor = Cursors.Hand
        _btnCalendario.IconColor = _iconoColor
        pnlFondo.Controls.Add(_btnCalendario)

        ' Label error
        lblError.Text = ""
        lblError.ForeColor = _colorError
        lblError.Dock = DockStyle.Top
        lblError.Height = AppLayout.ControlLabelHeight
        lblError.Visible = False
        lblError.TextAlign = ContentAlignment.MiddleRight

        ' Añadir controles
        Me.Controls.Add(lblError)
        Me.Controls.Add(pnlFondo)
        Me.Controls.Add(lblTitulo)

        _pnlCalendario.BackColor = AppColors._cBlancoOscuro
        _pnlCalendario.Visible = False
        _pnlCalendario.Width = 280
        _pnlCalendario.Height = 300
        _pnlCalendario.Padding = New Padding(AppLayout.Padding5)
        _pnlCalendario.BorderStyle = BorderStyle.None

        ' --- Cabecera calendario ---
        _btnPrev.IconChar = IconChar.ChevronLeft
        _btnPrev.FlatStyle = FlatStyle.Flat
        _btnPrev.FlatAppearance.BorderSize = 0
        _btnPrev.Cursor = Cursors.Hand
        _btnPrev.ForeColor = BorderColor
        AddHandler _btnPrev.Click, AddressOf MesAnterior

        _btnNext.IconChar = IconChar.ChevronRight
        _btnNext.FlatStyle = FlatStyle.Flat
        _btnNext.FlatAppearance.BorderSize = 0
        _btnNext.Cursor = Cursors.Hand
        _btnNext.ForeColor = BorderColor
        AddHandler _btnNext.Click, AddressOf MesSiguiente

        _lblMes.TextAlign = ContentAlignment.MiddleCenter
        _lblMes.Dock = DockStyle.Fill
        _lblMes.Font = New Font(AppFonts.SegoeSB, AppFonts.SizeSmall, AppFonts.Bold)
        _lblMes.ForeColor = BorderColor

        Dim pnlHeader As New Panel With {.Dock = DockStyle.Top, .Height = 30, .BackColor = Color.WhiteSmoke}
        pnlHeader.Controls.Add(_lblMes)
        pnlHeader.Controls.Add(_btnPrev)
        pnlHeader.Controls.Add(_btnNext)
        _btnPrev.Dock = DockStyle.Left
        _btnNext.Dock = DockStyle.Right

        ' --- Tabla de días ---
        _tblDias.Dock = DockStyle.Fill
        _tblDias.ColumnCount = 7
        _tblDias.RowCount = 6
        For i = 0 To 6
            _tblDias.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 14.28!))
        Next
        For i = 0 To 5
            _tblDias.RowStyles.Add(New RowStyle(SizeType.Percent, 16.66!))
        Next

        _pnlCalendario.Controls.Add(_tblDias)
        _pnlCalendario.Controls.Add(pnlHeader)

        RenderCalendario()

        ' Reajuste al redimensionar
        AddHandler pnlFondo.Paint, AddressOf DibujarFondoRedondeado
        AddHandler pnlFondo.Resize, Sub() pnlFondo.Region = New Region(RoundedPath(pnlFondo.ClientRectangle, _borderRadius))
        AddHandler txtCampo.KeyPress, AddressOf OnKeyPressPropagado
        AddHandler txtCampo.Enter, AddressOf OnEnter
        AddHandler txtCampo.Leave, AddressOf OnLeave
        AddHandler txtCampo.TextChanged, AddressOf OnTextChanged

        AddHandler txtCampo.TypeValidationCompleted, AddressOf TxtFecha_Validation
        AddHandler txtCampo.Click, AddressOf ToggleCalendario
        AddHandler _btnCalendario.Click, AddressOf ToggleCalendario

    End Sub
#End Region

#Region "EVENTOS INTERNOS"
    Private Sub OnKeyPressPropagado(sender As Object, e As KeyPressEventArgs)
        RaiseEvent CampoKeyPress(Me, e)
    End Sub

    Private Sub OnEnter(sender As Object, e As EventArgs)
        _borderColorNormal = _focusColor
        pnlFondo.Invalidate()
    End Sub
    Private Sub OnTextChanged(sender As Object, e As EventArgs)
        If Not String.IsNullOrWhiteSpace(txtCampo.Text) Then
            EsValido()
        End If
    End Sub
    Private Sub OnLeave(sender As Object, e As EventArgs)
        EsValido()
        If lblError.Visible Then
            _borderColor = _borderColorError
        Else
            _borderColor = _borderColorSuccess
        End If
        pnlFondo.Invalidate()
    End Sub

#End Region

#Region "VALIDACIONES"
    ' === Validación ===
    Private Sub ValidarCampo(sender As Object, e As EventArgs)
        Dim sinSeparadores = txtCampo.Text.Replace("/", "").Replace("_", "").Trim()

        If _campoRequerido AndAlso sinSeparadores.Length < 8 Then
            MostrarError(_mensajeError)
        ElseIf Not FechaSeleccionada.HasValue Then
            MostrarError("Formato de fecha inválido.")
        Else
            OcultarError()
        End If
    End Sub

    Private Sub MostrarError(msg As String)
        lblError.Text = msg
        lblError.Visible = True
        _borderColor = _borderColorError
        pnlFondo.Invalidate()
    End Sub

    Private Sub OcultarError()
        lblError.Visible = False
        _borderColor = _borderColorSuccess
        pnlFondo.Invalidate()
    End Sub

    Public Function EsValido() As Boolean
        ValidarCampo(Nothing, Nothing)
        Return Not lblError.Visible
    End Function
#End Region

#Region "PROCEDIMIENTO"
    ' --- Render calendario ---
    Private Sub RenderCalendario()
        _tblDias.Controls.Clear()
        _lblMes.Text = _fechaActual.ToString("MMMM yyyy", CultureInfo.CreateSpecificCulture("es-ES"))

        Dim primerDia As Date = New Date(_fechaActual.Year, _fechaActual.Month, 1)
        Dim offset As Integer = (primerDia.DayOfWeek + 6) Mod 7
        Dim diasMes As Integer = Date.DaysInMonth(_fechaActual.Year, _fechaActual.Month)

        _tblDias.SuspendLayout()
        For i = 1 To diasMes
            Dim btnDia As New Button With {
                .Text = i.ToString(),
                .Dock = DockStyle.Fill,
                .FlatStyle = FlatStyle.Flat,
                .BackColor = Color.White,
                .Tag = New Date(_fechaActual.Year, _fechaActual.Month, i),
                .Cursor = Cursors.Hand
            }
            btnDia.FlatAppearance.BorderSize = 0
            btnDia.FlatAppearance.MouseOverBackColor = AppColors._cHoverPrimary
            btnDia.FlatAppearance.MouseDownBackColor = AppColors._cHoverSuccess

            If FechaSeleccionada.HasValue AndAlso CType(btnDia.Tag, Date) = FechaSeleccionada.Value Then
                btnDia.BackColor = BorderColor
                btnDia.ForeColor = Color.White
            End If

            AddHandler btnDia.Click,
                Sub(s, e)
                    FechaSeleccionada = CType(btnDia.Tag, Date)
                    txtCampo.Text = FechaSeleccionada.Value.ToString("dd/MM/yyyy")
                    _pnlCalendario.Visible = False
                End Sub

            _tblDias.Controls.Add(btnDia, (i - 1 + offset) Mod 7, (i - 1 + offset) \ 7)
        Next
        _tblDias.ResumeLayout()
    End Sub
    Private Sub ActualizarRegion()
        If Me.ClientRectangle.Width > 0 AndAlso _borderRadius > 0 Then
            Me.Region = New Region(EstiloLayout.RoundedPath(Me.ClientRectangle, _borderRadius))
        End If
    End Sub
    Private Sub ActualizarLayoutOrbital()
        Dim margenIcono = If(iconoDerecho.Visible, iconoDerecho.Width + (_paddingAll * 2), _paddingAll)
        txtCampo.Width = pnlFondo.Width - margenIcono - _paddingAll
        txtCampo.Location = New Point(_paddingAll, (pnlFondo.Height - txtCampo.Height) \ 2)
        iconoDerecho.Location = New Point(pnlFondo.Width - iconoDerecho.Width - _paddingAll, (pnlFondo.Height - iconoDerecho.Height) \ 2)
    End Sub


#End Region

#Region "EVENTOS INTERNOS DEL CALENDARIO"
    ' --- Mostrar/Ocultar calendario ---
    Private Sub ToggleCalendario(sender As Object, e As EventArgs)
        Dim frm As Form = Me.FindForm()
        If frm Is Nothing Then Return

        _pnlCalendario.Visible = Not _pnlCalendario.Visible
        If _pnlCalendario.Visible Then
            Dim p As Point = Me.PointToScreen(New Point(0, Me.Height))
            _pnlCalendario.Location = frm.PointToClient(p)
            If Not frm.Controls.Contains(_pnlCalendario) Then frm.Controls.Add(_pnlCalendario)
            _pnlCalendario.BringToFront()
        End If
    End Sub

    ' --- Validación MaskedTextBox ---
    Private Sub TxtFecha_Validation(sender As Object, e As TypeValidationEventArgs)
        If e.IsValidInput Then
            FechaSeleccionada = CDate(txtCampo.Text)
            _fechaActual = FechaSeleccionada.Value
            RenderCalendario()
        Else
            FechaSeleccionada = Nothing
            txtCampo.Clear()
        End If
    End Sub
    Private Sub MesAnterior(sender As Object, e As EventArgs)
        _fechaActual = _fechaActual.AddMonths(-1)
        RenderCalendario()
    End Sub

    Private Sub MesSiguiente(sender As Object, e As EventArgs)
        _fechaActual = _fechaActual.AddMonths(1)
        RenderCalendario()
    End Sub

#End Region

#Region "DIBUJO"
    ' --- Dibujar borde redondeado ---
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
