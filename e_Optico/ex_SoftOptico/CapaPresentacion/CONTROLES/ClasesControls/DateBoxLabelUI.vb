Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Globalization
Imports System.Windows.Forms
Imports FontAwesome.Sharp

Public Class DateBoxLabelUI
    Inherits UserControl

    ' === Controles ===
    Private lblTitulo As New Label()
    Private pnlFondo As New Panel()
    Private pnlSombra As New Panel()
    Private txtCampo As New MaskedTextBox()
    Private lblError As New Label()
    Private iconoDerecho As New IconPictureBox()

    ' === Estilos y propiedades ===
    Private _labelText As String = "Fecha"
    Private _labelColor As Color = AppColors._cLabel
    Private _panelBackColor As Color = AppColors._cBlanco
    Private _textColor As Color = AppColors._cTexto
    Private _fontField As Font = New Font(AppFonts.Century, AppFonts.SizeMedium)
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
    Private _focusColor As Color = AppColors._cBordeSel
    'Evento keypress
    Public Event CampoKeyPress(sender As Object, e As KeyPressEventArgs)

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
        lblTitulo.Font = New Font(_fontField.FontFamily, _fontField.Size - 2)
        lblTitulo.ForeColor = _labelColor
        lblTitulo.Dock = DockStyle.Top
        lblTitulo.Height = AppLayout.ControlLabelHeight

        pnlSombra.Dock = DockStyle.None
        pnlSombra.BackColor = AppColors._cSombra
        pnlSombra.Height = AppLayout.PanelHeightStandar
        pnlSombra.Width = 900
        pnlSombra.Margin = Padding.Empty
        pnlSombra.Location = New Point(6, 23)

        ' Panel fondo
        pnlFondo.Dock = DockStyle.Top
        pnlFondo.Height = AppLayout.PanelHeightStandar
        pnlFondo.BackColor = _panelBackColor
        pnlFondo.Padding = New Padding(_paddingAll)

        ' TextBox fecha
        txtCampo.BorderStyle = BorderStyle.None
        txtCampo.Font = _fontField
        txtCampo.ForeColor = _textColor
        txtCampo.BackColor = _panelBackColor
        txtCampo.Mask = "00/00/0000"
        txtCampo.PromptChar = "_"c
        txtCampo.TextMaskFormat = MaskFormat.IncludePromptAndLiterals
        txtCampo.ValidatingType = GetType(DateTime)
        txtCampo.Size = New Size(220, 30)
        AddHandler txtCampo.Leave, AddressOf ValidarCampo

        ' Icono derecho
        iconoDerecho.IconChar = IconChar.CalendarDays
        iconoDerecho.IconColor = _iconoColor
        iconoDerecho.Size = New Size(AppLayout.IconMedium, AppLayout.IconMedium)
        iconoDerecho.BackColor = Color.Transparent
        iconoDerecho.SizeMode = PictureBoxSizeMode.Zoom

        ' Label error
        lblError.Text = ""
        lblError.ForeColor = _colorError
        lblError.Dock = DockStyle.Top
        lblError.Height = AppLayout.ControlLabelHeight
        lblError.Visible = False
        lblError.TextAlign = ContentAlignment.MiddleRight

        ' Añadir controles
        pnlFondo.Controls.Add(txtCampo)
        pnlFondo.Controls.Add(iconoDerecho)
        Me.Controls.Add(lblError)
        Me.Controls.Add(pnlFondo)
        Me.Controls.Add(pnlSombra)
        Me.Controls.Add(lblTitulo)

        ' Reajuste al redimensionar
        AddHandler pnlFondo.Resize, Sub() ActualizarLayoutOrbital()
        AddHandler txtCampo.KeyPress, AddressOf OnKeyPressPropagado
        AddHandler txtCampo.Enter, AddressOf OnEnter
        AddHandler txtCampo.Leave, AddressOf OnLeave
        AddHandler txtCampo.TextChanged, AddressOf OnTextChanged
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
        _borderColor = _colorError
        pnlFondo.Invalidate()
    End Sub

    Private Sub OcultarError()
        lblError.Visible = False
        _borderColor = Color.LightGray
        pnlFondo.Invalidate()
    End Sub

    Public Function EsValido() As Boolean
        ValidarCampo(Nothing, Nothing)
        Return Not lblError.Visible
    End Function
#End Region

#Region "DIBUJO"

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim temaVisual As New ThemaVisualLayout With {
                .ColorNormal = AppColors._cBasePrimary,
                .ColorError = AppColors._cBordeError,
                .ColorValidado = AppColors._cBaseSuccess,
                .ColorHover = AppColors._cHoverColor,
                .ColorFocus = AppColors._cBordeSel
            }

        Dim motorVisual As New EstiloLayout(
            tema:=temaVisual,
            estadoFunc:=Function()
                            If lblError.Visible Then
                                Return EstiloLayout.EstadoVisual.Errors
                            ElseIf txtCampo.Focused Then
                                Return EstiloLayout.EstadoVisual.Focus
                            Else
                                Return EstiloLayout.EstadoVisual.Normal
                            End If
                        End Function
        )

        Dim estilosOrbitales As New Dictionary(Of Control, (Radius As Integer, BorderSize As Integer)) From {
                    {pnlFondo, (_borderRadius, _borderSize)}
                }

        motorVisual.Aplicar(
            pnlFondo,
            obtenerRadio:=Function() estilosOrbitales(pnlFondo).Radius,
            obtenerBordeSize:=Function() estilosOrbitales(pnlFondo).BorderSize
        )

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
            _borderColorNormal = _colorError
        Else
            _borderColorNormal = _borderColorPersonalizado
        End If
        pnlFondo.Invalidate()
    End Sub

#End Region

#Region "PROCEDIMIENTO"
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

End Class

'Como se usa

'DateBoxLabelUI1.FechaSeleccionada = Date.Today
'DateBoxLabelUI1.LabelText = "Fecha de nacimiento"
'DateBoxLabelUI1.BorderRadius = 10
'DateBoxLabelUI1.PanelBackColor = Color.Navy
'DateBoxLabelUI1.TextColor = Color.White

'If DateBoxLabelUI1.EsValido() Then
'Dim fecha As Date = DateBoxLabelUI1.FechaSeleccionada.Value
'MessageBox.Show("Fecha: " & fecha.ToShortDateString())
'End If
