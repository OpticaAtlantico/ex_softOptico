Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class TextBoxUI
    Inherits TextBox

    Private _borderColor As Color = Color.Silver
    Private _focusColor As Color = Color.DeepSkyBlue
    Private _borderRadius As Integer = 6
    Private _shadowColor As Color = Color.FromArgb(30, Color.Black)
    Private _backgroundColorCustom As Color = Color.White
    Private _textColor As Color = Color.Black
    Private _hasFocus As Boolean = False

    Public Sub New()
        Me.SetStyle(ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
        Me.Font = New Font("Century Gothic", 12, FontStyle.Regular)
        Me.BorderStyle = BorderStyle.None
        Me.ForeColor = _textColor
        Me.BackColor = _backgroundColorCustom
        Me.Height = 35
        Me.TextAlign = HorizontalAlignment.Left
    End Sub

    ' 🎨 Propiedades extendidas
    <Category("UI Estilo")>
    Public Property BorderColor As Color
        Get
            Return _borderColor
        End Get
        Set(value As Color)
            _borderColor = value
            Me.Invalidate()
        End Set
    End Property

    <Category("UI Estilo")>
    Public Property FocusColor As Color
        Get
            Return _focusColor
        End Get
        Set(value As Color)
            _focusColor = value
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

    <Category("UI Estilo")>
    Public Property BackgroundColorCustom As Color
        Get
            Return _backgroundColorCustom
        End Get
        Set(value As Color)
            _backgroundColorCustom = value
            Me.BackColor = value
            Me.Invalidate()
        End Set
    End Property

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

    Protected Overrides Sub OnGotFocus(e As EventArgs)
        MyBase.OnGotFocus(e)
        _hasFocus = True
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnLostFocus(e As EventArgs)
        MyBase.OnLostFocus(e)
        _hasFocus = False
        Me.Invalidate()
    End Sub

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
        Using fondoBrush As New SolidBrush(_backgroundColorCustom)
            e.Graphics.FillPath(fondoBrush, path)
        End Using

        ' Borde dinámico
        Dim penColor = If(_hasFocus, _focusColor, _borderColor)
        Using pen As New Pen(penColor, 1.5F)
            e.Graphics.DrawPath(pen, path)
        End Using

        ' Texto
        Dim textRect = New Rectangle(10, 0, Me.Width - 20, Me.Height)
        TextRenderer.DrawText(e.Graphics, Me.Text, Me.Font, textRect, _textColor, TextFormatFlags.Left Or TextFormatFlags.VerticalCenter)
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

    ' 📡 Método orbital para temas
    Public Sub AplicarEstiloDesdeTema()
        Me.BackgroundColorCustom = ThemeManagerUI.ColorFondoBase
        Me.TextColor = ThemeManagerUI.ColorTextoBase
        Me.BorderColor = ThemeManagerUI.ColorBorde
        Me.FocusColor = ThemeManagerUI.ColorPrimario
        Me.ShadowColor = ThemeManagerUI.ColorSombra
        Me.Invalidate()
    End Sub
End Class
