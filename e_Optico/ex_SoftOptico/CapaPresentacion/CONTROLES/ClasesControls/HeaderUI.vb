Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.ComponentModel

Public Class HeaderUI
    Inherits Control

    Private _headerText As String = "Encabezado"
    Private _headerIcon As String = ChrW(&HF007) ' Ícono decorativo (ej: usuario)
    Private _textColor As Color = Color.Black
    Private _backgroundColor As Color = Color.WhiteSmoke
    Private _shadowColor As Color = Color.FromArgb(30, Color.Black)
    Private _borderRadius As Integer = 8

    Public Sub New()
        Me.DoubleBuffered = True
        Me.Font = New Font("Century Gothic", 12, FontStyle.Bold)
        Me.Size = New Size(300, 50)
    End Sub

    <Category("UI Estilo")>
    Public Property HeaderText As String
        Get
            Return _headerText
        End Get
        Set(value As String)
            _headerText = value
            Me.Invalidate()
        End Set
    End Property

    <Category("UI Estilo")>
    Public Property HeaderIcon As String
        Get
            Return _headerIcon
        End Get
        Set(value As String)
            _headerIcon = value
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
    Public Property BorderRadius As Integer
        Get
            Return _borderRadius
        End Get
        Set(value As Integer)
            _borderRadius = value
            Me.Invalidate()
        End Set
    End Property

    Public Sub AplicarEstiloDesdeTema()
        Me.BackgroundColor = ThemeManagerUI.ColorFondoBase
        Me.TextColor = ThemeManagerUI.ColorTextoBase
        Me.ShadowColor = ThemeManagerUI.ColorSombra
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        Dim rect = New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)
        Dim path = RoundedPath(rect, _borderRadius)

        ' Sombra
        Dim sombraRect = New Rectangle(rect.X + 1, rect.Y + 1, rect.Width, rect.Height)
        Using sombraBrush As New SolidBrush(_shadowColor)
            e.Graphics.FillRectangle(sombraBrush, sombraRect)
        End Using

        ' Fondo
        Using fondoBrush As New SolidBrush(_backgroundColor)
            e.Graphics.FillPath(fondoBrush, path)
        End Using

        ' Icono decorativo
        Dim iconRect As New Rectangle(12, 0, 32, Me.Height)
        TextRenderer.DrawText(e.Graphics, _headerIcon, Me.Font, iconRect, _textColor, TextFormatFlags.VerticalCenter Or TextFormatFlags.Left)

        ' Texto
        Dim textRect As New Rectangle(48, 0, Me.Width - 50, Me.Height)
        TextRenderer.DrawText(e.Graphics, _headerText, Me.Font, textRect, _textColor, TextFormatFlags.VerticalCenter Or TextFormatFlags.Left)
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

    'Como lo usas

    'Dim encabezado As New HeaderUI()
    'encabezado.HeaderText = "Datos del Sistema"
    'encabezado.HeaderIcon = ChrW(&HF085) ' Ej: engranaje FontAwesome
    'Me.Controls.Add(encabezado)

End Class
