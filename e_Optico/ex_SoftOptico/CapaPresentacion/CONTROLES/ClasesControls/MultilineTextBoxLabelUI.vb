Option Explicit On
Option Strict On

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
    Private txtCampo As New MaskedTextBox()
    Private lblError As New Label()

    ' === Estilos ===
    Private _labelText As String = "Texto:"
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
    Private _alturaMultilinea As Integer = 40

    Private alturaObjetivo As Integer = 80
    Private alturaAnimadaActual As Integer = 40
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
        lblTitulo.Font = New Font(_fontField.FontFamily, _fontField.Size + 1)


        ' === Panel contenedor ===
        pnlFondo.Dock = DockStyle.Top
        pnlFondo.Height = _alturaMultilinea ' usa respaldo privado
        pnlFondo.BackColor = _panelBackColor
        pnlFondo.Padding = New Padding(_paddingAll)
        pnlFondo.Region = New Region(RoundedPath(pnlFondo.ClientRectangle, _borderRadius))
        AddHandler pnlFondo.Paint, AddressOf DibujarFondoRedondeado

        ' === Campo de texto ===
        txtCampo.BorderStyle = BorderStyle.None
        txtCampo.Font = _fontField
        txtCampo.ForeColor = _textColor
        txtCampo.BackColor = _panelBackColor
        txtCampo.Multiline = True ' listo para expansión vertical
        pnlFondo.Controls.Add(txtCampo)

        ' === Ícono a la derecha ===
        iconoDerecho.IconChar = IconChar.None
        iconoDerecho.IconColor = _textColor
        iconoDerecho.Size = New Size(24, 24)
        iconoDerecho.SizeMode = PictureBoxSizeMode.Zoom
        iconoDerecho.BackColor = Color.Transparent
        iconoDerecho.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        iconoDerecho.Visible = False
        pnlFondo.Controls.Add(iconoDerecho)

        ' === Label de error ===
        lblError.Text = ""
        lblError.ForeColor = _colorError
        lblError.Dock = DockStyle.Top
        lblError.Height = 20
        lblError.Visible = False

        Me.Controls.Add(lblError)
        Me.Controls.Add(pnlFondo)
        Me.Controls.Add(lblTitulo)

        ' === Eventos ===
        AddHandler txtCampo.TextChanged, AddressOf ValidarCampo
        AddHandler txtCampo.Leave, AddressOf ValidarCampo
        AddHandler pnlFondo.Resize, AddressOf RecalcularAlineacion
    End Sub

    'Private Sub animadorAltura_Tick(sender As Object, e As EventArgs) Handles animadorAltura.Tick
    '    If pnlFondo.Height <> alturaObjetivo Then
    '        Dim diferencia = alturaObjetivo - pnlFondo.Height
    '        Dim paso = Math.Sign(diferencia) * Math.Max(1, Math.Abs(diferencia) \ 5)
    '        pnlFondo.Height += paso
    '        pnlFondo.Invalidate()
    '    Else
    '        animadorAltura.Stop()
    '    End If
    'End Sub

    Private Sub AjustarAlturaCampo()
        If txtCampo.Multiline Then
            pnlFondo.Height = 80 ' Puedes ajustar esta altura orbital según estilo
            txtCampo.TextAlign = HorizontalAlignment.Left
        Else
            pnlFondo.Height = 40
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
    End Sub

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
            Using pen As New Pen(_borderColorNormal, 1)
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
            lblTitulo.Font = New Font(value.FontFamily, value.Size)
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

End Class

