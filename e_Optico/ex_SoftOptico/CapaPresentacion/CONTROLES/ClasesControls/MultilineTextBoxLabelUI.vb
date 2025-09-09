
Imports System.ComponentModel
Imports FontAwesome.Sharp

Public Class MultilineTextBoxLabelUI
    Inherits UserControl

    ' === Controles ===
    Private lblTitulo As New Label()
    Private pnlFondo As New Panel()
    Private pnlSombra As New Panel()
    Private txtCampo As New TextBox()
    Private lblError As New Label()

    ' === Visual orbital ===
    Private _alturaMultilinea As Integer = 40

    Private alturaObjetivo As Integer = 100
    Private alturaAnimadaActual As Integer = 40

    Private _campoRequerido As Boolean = True

    ' === Visual orbital ===
    Private _borderRadius As Integer = AppLayout.BorderRadiusStandar
    Private _borderColorNormal As Color = AppColors._cBorde

    ' === Estilos ===
    Private _labelText As String = "Texto:"
    Private _panelBackColor As Color = AppColors._cBlanco
    Private _sombraBackColor As Color = AppColors._cSombra
    Private _textColor As Color = AppColors._cTexto
    Private _fontField As Font = New Font(AppFonts.Century, AppFonts.SizeMedium)
    Private _paddingAll As Integer = AppLayout.Padding10
    Private _maxCaracteres As Integer = 0
    Private iconoDerecho As New IconPictureBox()
    Private _borderColorPersonalizado As Color = AppColors._cBorde
    Private _borderSize As Integer = AppLayout.BorderSizeMediun
    Private _labelColor As Color = AppColors._cLabel
    Private _focusColor As Color = AppColors._cBordeSel
    Private _mensajeError As String = AppMensajes.msgCampoRequerido
    Private _colorError As Color = AppColors._cMsgError
    Private WithEvents innerTextBox As New TextBox

    'Private WithEvents animadorAltura As New Timer() With {.Interval = 15}

#Region "PROPIEDADDES"
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
            If _borderRadius <> value Then
                _borderRadius = value
                ActualizarRegion()
                Me.Invalidate()
            End If
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
            pnlSombra.Height = value + 0.3
            txtCampo.Multiline = True
            txtCampo.Height = value - (_paddingAll * 2)
            RecalcularAlineacion(Nothing, Nothing)
            ActualizarRegion()
            pnlFondo.Invalidate()
            pnlSombra.Invalidate()
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
        lblTitulo.Font = New Font(AppFonts.Century, AppFonts.SizeSmall)
        lblTitulo.ForeColor = _labelColor
        lblTitulo.Dock = DockStyle.Top
        lblTitulo.Height = AppLayout.ControlLabelHeight

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
        iconoDerecho.IconColor = AppColors._cIcono
        iconoDerecho.Size = New Size(AppLayout.IconMedium, AppLayout.IconMedium)
        iconoDerecho.Location = New Point(pnlFondo.Width - iconoDerecho.Width - _paddingAll, (pnlFondo.Height - iconoDerecho.Height) \ 2)
        iconoDerecho.Anchor = AnchorStyles.Right Or AnchorStyles.Top
        iconoDerecho.BackColor = Color.Transparent
        iconoDerecho.SizeMode = PictureBoxSizeMode.Zoom
        pnlFondo.Controls.Add(iconoDerecho)

        ' === Label de error ===
        lblError.Text = ""
        lblError.ForeColor = _colorError
        lblError.Dock = DockStyle.Top
        lblError.Height = AppLayout.ControlLabelHeight
        lblError.Visible = False
        lblError.Margin = Padding.Empty
        lblError.TextAlign = ContentAlignment.MiddleRight

        Me.Controls.Add(lblError)
        Me.Controls.Add(pnlFondo)
        Me.Controls.Add(pnlSombra)
        Me.Controls.Add(lblTitulo)

        ' === Eventos ===
        AddHandler txtCampo.TextChanged, AddressOf OnTextChanged
        AddHandler txtCampo.Enter, AddressOf OnEnter
        AddHandler txtCampo.Leave, AddressOf OnLeave
        AddHandler pnlFondo.Resize, Sub() ActualizarRegion()
        AddHandler pnlFondo.Resize, Sub() ActualizarLayoutOrbital()

    End Sub
#End Region

#Region "EVENTOS INTERNOS"

    Private Sub OnEnter(sender As Object, e As EventArgs)
        _borderColorNormal = _focusColor
        pnlFondo.Invalidate()
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

#Region "VALIDACION"
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
#End Region

#Region "DIBUJO"
    ' === Fondo redondeado orbital ===
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

#End Region

#Region "PROCEDIMIENTO"
    Private Sub ActualizarRegion()
        If Me.ClientRectangle.Width > 0 AndAlso _borderRadius > 0 Then
            Me.Region = New Region(EstiloLayout.RoundedPath(Me.ClientRectangle, _borderRadius))
        End If
    End Sub
    Private Sub ActualizarLayoutOrbital()

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
        pnlSombra.Size = New Size(pnlFondo.Width + 12, pnlFondo.Height - 0.3)

        ' Alinear el ícono a la derecha si está visible
        If iconoDerecho.Visible Then
            iconoDerecho.Location = New Point(pnlFondo.Width - iconoDerecho.Width - _paddingAll, _paddingAll)
        End If

    End Sub

#End Region


End Class

