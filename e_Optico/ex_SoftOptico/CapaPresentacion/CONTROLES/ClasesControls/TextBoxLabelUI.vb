Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows
Imports System.Windows.Forms

Public Class TextBoxLabelUI
    Inherits UserControl

    Private lblTitulo As New Label()
    Private pnlFondo As New Panel()
    Private txtCampo As New TextBox()

    Private _labelText As String = "Texto:"
    Private _panelBackColor As Color = Color.LightGray
    Private _textColor As Color = Color.Black
    Private _fontField As Font = New Font("Century Gothic", 12)
    Private _paddingAll As Integer = 15

    'Border Redondo
    Private _borderColor As Color = Color.LightGray
    Private _borderRadius As Integer = 10
    Private _borderWidth As Integer = 2
    Private _borderFlat As Boolean = True

    ' Placeholder
    Private _placeholderText As String = ""
    Private _placeholderColor As Color = Color.DarkGray
    Private _placeholderFont As Font = New Font("Century Gothic", 12, Drawing.FontStyle.Italic)

    Public Sub New()
        Me.Size = New Drawing.Size(300, 75)
        Me.DoubleBuffered = True
        Me.BackColor = Color.Transparent

        ' Label superior
        lblTitulo.Text = _labelText
        lblTitulo.Font = _fontField
        lblTitulo.ForeColor = Color.White
        lblTitulo.Dock = DockStyle.Top
        lblTitulo.Height = 20
        lblTitulo.BackColor = Color.Transparent
        Me.Controls.Add(lblTitulo)

        ' Panel de fondo
        pnlFondo.Dock = DockStyle.Fill
        pnlFondo.BackColor = _panelBackColor
        pnlFondo.Padding = New Padding(_paddingAll)
        'Bordes Redondo
        AddHandler pnlFondo.Paint, AddressOf DibujarBordeRedondeado
        Me.Controls.Add(pnlFondo)

        ' TextBox centrado
        txtCampo.BorderStyle = BorderStyle.None
        txtCampo.Font = _fontField
        txtCampo.ForeColor = _textColor
        txtCampo.BackColor = _panelBackColor
        txtCampo.Multiline = False
        txtCampo.Anchor = AnchorStyles.None
        txtCampo.TextAlign = System.Windows.HorizontalAlignment.Left
        pnlFondo.Controls.Add(txtCampo)

        ' Placeholder eventos
        AddHandler txtCampo.Paint, AddressOf DibujarPlaceholder
        AddHandler txtCampo.TextChanged, AddressOf ActualizarPlaceholder
        AddHandler txtCampo.GotFocus, AddressOf ActualizarPlaceholder
        AddHandler txtCampo.LostFocus, AddressOf ActualizarPlaceholder

        ' Centrado orbital
        AddHandler Me.Resize, AddressOf CentrarTextBox
        AddHandler pnlFondo.Resize, AddressOf CentrarTextBox
        CentrarTextBox(Nothing, Nothing)


    End Sub

    Private Sub CentrarTextBox(sender As Object, e As EventArgs)
        Dim ancho = Me.Width - (_paddingAll * 2)
        Dim alto = 35
        txtCampo.Size = New Drawing.Size(ancho, alto)

        Dim posX = (Me.Width - txtCampo.Width) \ 2
        Dim espacioVertical = Me.Height - lblTitulo.Height
        Dim posY = lblTitulo.Height + ((espacioVertical - txtCampo.Height) \ 2)

        txtCampo.Location = New Drawing.Point(posX, posY)
    End Sub

    Private Sub DibujarPlaceholder(sender As Object, e As PaintEventArgs)
        If String.IsNullOrEmpty(txtCampo.Text) AndAlso Not txtCampo.Focused AndAlso Not String.IsNullOrEmpty(_placeholderText) Then
            Using brush As New SolidBrush(_placeholderColor)
                Dim yOffset = (txtCampo.Height - _placeholderFont.Height) \ 2
                e.Graphics.DrawString(_placeholderText, _placeholderFont, brush, New PointF(4, yOffset))
            End Using
        End If
    End Sub

    Private Sub ActualizarPlaceholder(sender As Object, e As EventArgs)
        txtCampo.Invalidate()
    End Sub

    'Dibuja el borde reondo en el panelcon el evento paint
    Private Sub DibujarBordeRedondeado(sender As Object, e As PaintEventArgs)
        If _borderFlat Then
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
            Dim rect = pnlFondo.ClientRectangle
            'rect.Inflate(-1, -1) ' Margen visual
            rect.Inflate(-_borderWidth \ 2, -_borderWidth \ 2)
            Dim colorBorde = If(_borderFlat, pnlFondo.BackColor, _borderColor)

            Using path As GraphicsPath = RoundedPath(rect, _borderRadius),
              pen As New Pen(colorBorde, _borderWidth)
                e.Graphics.DrawPath(pen, path)
            End Using
        End If
    End Sub

    'El Helper
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

    <Category("UI Estilo")>
    Public Property LabelText As String
        Get
            Return _labelText
        End Get
        Set(value As String)
            _labelText = value
            lblTitulo.Text = value
        End Set
    End Property

    <Category("UI Estilo")>
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

    <Category("UI Estilo")>
    Public Property TextColor As Color
        Get
            Return _textColor
        End Get
        Set(value As Color)
            _textColor = value
            txtCampo.ForeColor = value
        End Set
    End Property

    <Category("UI Estilo")>
    Public Property FontField As Font
        Get
            Return _fontField
        End Get
        Set(value As Font)
            _fontField = value
            txtCampo.Font = value
            lblTitulo.Font = value
        End Set
    End Property

    <Category("UI Estilo")>
    Public Property PaddingAll As Integer
        Get
            Return _paddingAll
        End Get
        Set(value As Integer)
            _paddingAll = value
            CentrarTextBox(Nothing, Nothing)
        End Set
    End Property

    <Category("Placeholder")>
    Public Property PlaceholderText As String
        Get
            Return _placeholderText
        End Get
        Set(value As String)
            _placeholderText = value
            txtCampo.Invalidate()
        End Set
    End Property

    <Category("Placeholder")>
    Public Property PlaceholderColor As Color
        Get
            Return _placeholderColor
        End Get
        Set(value As Color)
            _placeholderColor = value
            txtCampo.Invalidate()
        End Set
    End Property

    <Category("Placeholder")>
    Public Property PlaceholderFont As Font
        Get
            Return _placeholderFont
        End Get
        Set(value As Font)
            _placeholderFont = value
            txtCampo.Invalidate()
        End Set
    End Property

    <Category("UI Estilo")>
    Public Property BorderRadius As Integer
        Get
            Return _borderRadius
        End Get
        Set(value As Integer)
            _borderRadius = value
            pnlFondo.Invalidate()
        End Set
    End Property

    <Category("UI Estilo")>
    Public Property BorderFlat As Boolean
        Get
            Return _borderFlat
        End Get
        Set(value As Boolean)
            _borderFlat = value
            pnlFondo.Invalidate()
        End Set
    End Property

    <Category("UI Estilo")>
    Public Property BorderWidth As Boolean
        Get
            Return _borderWidth
        End Get
        Set(value As Boolean)
            _borderWidth = value
            pnlFondo.Invalidate()
        End Set
    End Property

    <Category("UI Estilo")>
    Public Property BorderColor As Color
        Get
            Return _borderColor
        End Get
        Set(value As Color)
            _borderColor = value
            pnlFondo.Invalidate()
        End Set
    End Property

    Public ReadOnly Property TextValue As String
        Get
            Return txtCampo.Text
        End Get
    End Property
End Class