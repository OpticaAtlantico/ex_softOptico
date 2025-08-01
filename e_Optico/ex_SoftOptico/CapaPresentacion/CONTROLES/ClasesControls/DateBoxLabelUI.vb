﻿Imports System.ComponentModel
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
    Private txtCampo As New MaskedTextBox()
    Private lblError As New Label()
    Private iconoDerecho As New IconPictureBox()

    ' === Estilos y propiedades ===
    Private _labelText As String = "Fecha"
    Private _labelColor As Color = Color.WhiteSmoke
    Private _panelBackColor As Color = Color.FromArgb(80, 94, 129)
    Private _textColor As Color = Color.WhiteSmoke
    Private _fontField As Font = New Font("Century Gothic", 12)
    Private _paddingAll As Integer = 10
    Private _borderColor As Color = Color.LightGray
    Private _borderSize As Integer = 1
    Private _borderRadius As Integer = 6
    Private _iconoColor As Color = Color.White
    Private _colorError As Color = Color.Firebrick
    Private _campoRequerido As Boolean = True
    Private _mensajeError As String = "Este campo es obligatorio."

    'Evento keypress
    Public Event CampoKeyPress(sender As Object, e As KeyPressEventArgs)

    ' === Constructor ===
    Public Sub New()
        Me.Size = New Size(300, 100)
        Me.DoubleBuffered = True
        Me.BackColor = Color.Transparent

        ' Label
        lblTitulo.Text = _labelText
        lblTitulo.Font = New Font(_fontField.FontFamily, _fontField.Size - 2)
        lblTitulo.ForeColor = _labelColor
        lblTitulo.Dock = DockStyle.Top
        lblTitulo.Height = 20

        ' Panel fondo
        pnlFondo.Dock = DockStyle.Top
        pnlFondo.Height = 37
        pnlFondo.BackColor = _panelBackColor
        pnlFondo.Padding = New Padding(_paddingAll)
        AddHandler pnlFondo.Paint, AddressOf DibujarFondoRedondeado
        AddHandler pnlFondo.Resize, Sub() pnlFondo.Region = New Region(RoundedPath(pnlFondo.ClientRectangle, _borderRadius))

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
        iconoDerecho.IconChar = IconChar.CalendarAlt
        iconoDerecho.IconColor = _iconoColor
        iconoDerecho.Size = New Size(24, 24)
        iconoDerecho.BackColor = Color.Transparent
        iconoDerecho.SizeMode = PictureBoxSizeMode.Zoom

        ' Label error
        lblError.Text = ""
        lblError.ForeColor = _colorError
        lblError.Dock = DockStyle.Top
        lblError.Height = 20
        lblError.Visible = False
        lblError.TextAlign = ContentAlignment.MiddleRight

        ' Añadir controles
        pnlFondo.Controls.Add(txtCampo)
        pnlFondo.Controls.Add(iconoDerecho)
        Me.Controls.Add(lblError)
        Me.Controls.Add(pnlFondo)
        Me.Controls.Add(lblTitulo)

        ' Reajuste al redimensionar
        AddHandler pnlFondo.Resize, Sub()
                                        Dim margenIcono = If(iconoDerecho.Visible, iconoDerecho.Width + (_paddingAll * 2), _paddingAll)
                                        txtCampo.Width = pnlFondo.Width - margenIcono - _paddingAll
                                        txtCampo.Location = New Point(_paddingAll, (pnlFondo.Height - txtCampo.Height) \ 2)
                                        iconoDerecho.Location = New Point(pnlFondo.Width - iconoDerecho.Width - _paddingAll, (pnlFondo.Height - iconoDerecho.Height) \ 2)
                                    End Sub
        AddHandler txtCampo.KeyPress, AddressOf OnKeyPressPropagado
    End Sub

    Private Sub OnKeyPressPropagado(sender As Object, e As KeyPressEventArgs)
        RaiseEvent CampoKeyPress(Me, e)
    End Sub

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

    ' === Fondo redondeado ===
    Private Sub DibujarFondoRedondeado(sender As Object, e As PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect = pnlFondo.ClientRectangle
        rect.Inflate(-1, -1)
        Using path As GraphicsPath = RoundedPath(rect, _borderRadius)
            Using brush As New SolidBrush(pnlFondo.BackColor)
                e.Graphics.FillPath(brush, path)
            End Using
            Using pen As New Pen(_borderColor, _borderSize)
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
            _borderRadius = value
            pnlFondo.Region = New Region(RoundedPath(pnlFondo.ClientRectangle, value))
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

    Public Function EsValido() As Boolean
        ValidarCampo(Nothing, Nothing)
        Return Not lblError.Visible
    End Function
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
