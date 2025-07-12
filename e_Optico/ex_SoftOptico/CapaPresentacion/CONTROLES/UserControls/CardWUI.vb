Imports System.Drawing.Drawing2D
Imports System.Drawing
Imports System.Windows.Forms
Public Class CardWUI
    Inherits UserControl

    Private _titulo As String = "Título de la Tarjeta"
    Private _iconUnicode As String = ChrW(&HF007) ' fa-user
    Private _borderRadius As Integer = 10
    Private _titleHeight As Integer = 40
    Private _backgroundColor As Color = Color.White
    Private _borderColor As Color = Color.LightGray
    Private _textColor As Color = Color.Black
    Private _iconColor As Color = Color.Gray
    Private _fontAwesomeFont As New Font("Font Awesome 6 Free Solid", 10)

    Public Sub New()
        Me.Size = New Size(350, 180)
        Me.BackColor = Color.Transparent
        Me.DoubleBuffered = True
    End Sub

    ' 🎛 Propiedades públicas

    Public Property Titulo As String
        Get
            Return _titulo
        End Get
        Set(value As String)
            _titulo = value
            Me.Invalidate()
        End Set
    End Property

    Public Property IconUnicode As String
        Get
            Return _iconUnicode
        End Get
        Set(value As String)
            _iconUnicode = value
            Me.Invalidate()
        End Set
    End Property

    Public Property BackgroundColorCustom As Color
        Get
            Return _backgroundColor
        End Get
        Set(value As Color)
            _backgroundColor = value
            Me.Invalidate()
        End Set
    End Property

    Public Property BorderColor As Color
        Get
            Return _borderColor
        End Get
        Set(value As Color)
            _borderColor = value
            Me.Invalidate()
        End Set
    End Property

    Public Property BorderRadius As Integer
        Get
            Return _borderRadius
        End Get
        Set(value As Integer)
            _borderRadius = value
            Me.Invalidate()
        End Set
    End Property

    Public Property TextColor As Color
        Get
            Return _textColor
        End Get
        Set(value As Color)
            _textColor = value
            Me.Invalidate()
        End Set
    End Property

    Public Property IconColor As Color
        Get
            Return _iconColor
        End Get
        Set(value As Color)
            _iconColor = value
            Me.Invalidate()
        End Set
    End Property

    'Public Property ContenidoInterno As Control.ControlCollection
    '    Get
    '        Return Me.Controls
    '    End Get
    '    ' No se puede establecer directamente
    'End Property

    ' 🎨 Render visual

    Protected Overrides Sub OnPaint(pe As PaintEventArgs)
        Dim g = pe.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias

        Dim rect = New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)

        ' Bordes redondeados
        Dim path = New GraphicsPath()
        path.AddArc(rect.X, rect.Y, _borderRadius, _borderRadius, 180, 90)
        path.AddArc(rect.Right - _borderRadius, rect.Y, _borderRadius, _borderRadius, 270, 90)
        path.AddArc(rect.Right - _borderRadius, rect.Bottom - _borderRadius, _borderRadius, _borderRadius, 0, 90)
        path.AddArc(rect.X, rect.Bottom - _borderRadius, _borderRadius, _borderRadius, 90, 90)
        path.CloseAllFigures()

        g.FillPath(New SolidBrush(_backgroundColor), path)
        Using pen As New Pen(_borderColor, 1.5F)
            g.DrawPath(pen, path)
        End Using

        ' Título e ícono
        Dim iconRect = New Rectangle(10, 10, 20, 20)
        Dim textRect = New Rectangle(35, 8, Me.Width - 40, _titleHeight)
        TextRenderer.DrawText(g, _iconUnicode, _fontAwesomeFont, iconRect, _iconColor, TextFormatFlags.Left)
        TextRenderer.DrawText(g, _titulo, New Font("Segoe UI", 10, FontStyle.Bold), textRect, _textColor, TextFormatFlags.VerticalCenter)
    End Sub

    'Como usarlo

    'Dim cardUsuario As New CardWilmerUI()
    'cardUsuario.Location = New Point(20, 360)
    'cardUsuario.Titulo = "Datos del Usuario"
    'cardUsuario.IconUnicode = ChrW(&HF007) ' fa-user
    'cardUsuario.BackgroundColorCustom = Color.WhiteSmoke

    '' Agregar controles dentro
    'Dim txtNombreInterno As New TextBoxUI()
    'txtNombreInterno.Location = New Point(10, 50)
    'cardUsuario.Controls.Add(txtNombreInterno)

    'Me.Controls.Add(cardUsuario)

End Class
