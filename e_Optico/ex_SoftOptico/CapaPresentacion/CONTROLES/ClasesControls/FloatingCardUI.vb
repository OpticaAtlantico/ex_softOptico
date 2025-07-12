Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.ComponentModel

Public Class FloatingCardUI
    Inherits Panel

    Private _backgroundColor As Color = Color.White
    Private _borderRadius As Integer = 12
    Private _shadowColor As Color = Color.FromArgb(30, Color.Black)

    Public Sub New()
        Me.DoubleBuffered = True
        Me.Size = New Size(320, 160)
        Me.Padding = New Padding(12)
        Me.Font = New Font("Century Gothic", 11, FontStyle.Regular)
        Me.BackColor = Color.Transparent
    End Sub

    <Category("UI Estilo")>
    Public Property BackgroundColor As Color
        Get
            Return _backgroundColor
        End Get
        Set(value As Color)
            _backgroundColor = value
            Me.Invalidate()
        End Set
    End Property

    <Category("UI Estilo")>
    Public Property BorderRadius As Integer
        Get
            Return _borderRadius
        End Get
        Set(value As Integer)
            _borderRadius = value
            Me.Invalidate()
        End Set
    End Property

    <Category("UI Estilo")>
    Public Property ShadowColor As Color
        Get
            Return _shadowColor
        End Get
        Set(value As Color)
            _shadowColor = value
            Me.Invalidate()
        End Set
    End Property

    Public Sub AplicarEstiloDesdeTema()
        Me.BackgroundColor = ThemeManagerUI.ColorFondoBase
        Me.ShadowColor = ThemeManagerUI.ColorSombra
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        Dim rect = New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)
        Dim path = RoundedPath(rect, _borderRadius)

        ' Sombra orbital
        Dim sombraRect = New Rectangle(rect.X + 1, rect.Y + 1, rect.Width, rect.Height)
        Using sombraBrush As New SolidBrush(_shadowColor)
            e.Graphics.FillRectangle(sombraBrush, sombraRect)
        End Using

        ' Fondo orbital
        Using fondoBrush As New SolidBrush(_backgroundColor)
            e.Graphics.FillPath(fondoBrush, path)
        End Using
    End Sub

    Private Function RoundedPath(rect As Rectangle, radius As Integer) As GraphicsPath
        Dim path As New GraphicsPath()
        path.StartFigure()
        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90)
        path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90)
        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
        path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90)
        path.CloseFigure()
        Return path
    End Function

    'como lo usas

    'Dim cardInfo As New FloatingCardUI()
    'cardInfo.Location = New Point(40, 80)
    'cardInfo.Size = New Size(320, 140)
    'cardInfo.BackgroundColor = Color.WhiteSmoke
    'Me.Controls.Add(cardInfo)

    'Dim labelTitulo As New LabelUI()
    'labelTitulo.Text = "Detalles de Usuario"
    'labelTitulo.Dock = DockStyle.Top
    'cardInfo.Controls.Add(labelTitulo)

End Class
