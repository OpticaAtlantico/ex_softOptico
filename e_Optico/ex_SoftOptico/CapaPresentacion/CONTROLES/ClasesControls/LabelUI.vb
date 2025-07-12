Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class LabelUI
    Inherits Label

    Private _textColor As Color = Color.Black
    Private _backgroundColor As Color = Color.Transparent
    Private _borderRadius As Integer = 8
    Private _shadowColor As Color = Color.FromArgb(30, Color.Black)

    Public Sub New()
        Me.DoubleBuffered = True
        Me.AutoSize = False
        Me.Size = New Size(200, 35)
        Me.Font = New Font("Century Gothic", 12, FontStyle.Regular)
        Me.TextAlign = ContentAlignment.MiddleLeft
        Me.Padding = New Padding(10, 0, 0, 0)
    End Sub

    ' 🧠 Propiedades extendidas
    <Category("UI Estilo")>
    Public Property TextColor As Color
        Get
            Return _textColor
        End Get
        Set(value As Color)
            _textColor = value
            Me.ForeColor = value
            Me.Invalidate()
        End Set
    End Property

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

    ' 📡 Integración con tema visual
    Public Sub AplicarEstiloDesdeTema()
        Me.BackgroundColor = ThemeManagerUI.ColorFondoBase
        Me.TextColor = ThemeManagerUI.ColorTextoBase
        Me.ShadowColor = ThemeManagerUI.ColorSombra
        Me.Invalidate()
    End Sub

    ' 🎨 Renderizado orbital
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect = New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)
        Dim path = RoundedPath(rect, _borderRadius)

        ' Sombra
        Dim sombraRect = New Rectangle(rect.X + 1, rect.Y + 1, rect.Width, rect.Height)
        Using sombraBrush As New SolidBrush(_shadowColor)
            e.Graphics.FillRectangle(sombraBrush, sombraRect)
        End Using

        ' Fondo orbital
        Using fondoBrush As New SolidBrush(_backgroundColor)
            e.Graphics.FillPath(fondoBrush, path)
        End Using

        ' Texto centrado en vertical
        TextRenderer.DrawText(e.Graphics, Me.Text, Me.Font, rect, _textColor, TextFormatFlags.Left Or TextFormatFlags.VerticalCenter)
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
End Class
