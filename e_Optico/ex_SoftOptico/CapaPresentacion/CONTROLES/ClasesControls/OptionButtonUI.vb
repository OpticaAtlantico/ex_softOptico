Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Public Class OptionButtonUI
    Inherits RadioButton

    Private _borderColor As Color = Color.Silver
    Private _focusColor As Color = Color.DeepSkyBlue
    Private _shadowColor As Color = Color.FromArgb(30, Color.Black)
    Private _textColor As Color = Color.Black
    Private _borderRadius As Integer = 12

    Public Sub New()
        Me.DoubleBuffered = True
        Me.Font = New Font("Century Gothic", 12, FontStyle.Regular)
        Me.Size = New Size(160, 35)
        Me.TextAlign = ContentAlignment.MiddleLeft
        Me.Padding = New Padding(26, 0, 0, 0)
        Me.AutoSize = False
    End Sub

    ' 🌈 Propiedades orbitales
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
    Public Property BorderRadius As Integer
        Get
            Return _borderRadius
        End Get
        Set(value As Integer)
            _borderRadius = value
            Me.Invalidate()
        End Set
    End Property

    ' 📡 Integración con tema orbital
    Public Sub AplicarEstiloDesdeTema()
        Me.TextColor = ThemeManagerUI.ColorTextoBase
        Me.BorderColor = ThemeManagerUI.ColorBorde
        Me.FocusColor = ThemeManagerUI.ColorPrimario
        Me.ShadowColor = ThemeManagerUI.ColorSombra
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        ' Flecha orbital (círculo)
        Dim centerY = Me.Height \ 2
        Dim centerX = 12
        Dim radiusOuter = 12
        Dim radiusInner = 6

        Dim rectSombra = New Rectangle(centerX - radiusOuter + 1, centerY - radiusOuter + 1, radiusOuter * 2, radiusOuter * 2)
        Using sombraBrush As New SolidBrush(_shadowColor)
            e.Graphics.FillEllipse(sombraBrush, rectSombra)
        End Using

        Using bordeBrush As New SolidBrush(_borderColor)
            e.Graphics.FillEllipse(bordeBrush, New Rectangle(centerX - radiusOuter, centerY - radiusOuter, radiusOuter * 2, radiusOuter * 2))
        End Using

        If Me.Checked Then
            Using focoBrush As New SolidBrush(_focusColor)
                e.Graphics.FillEllipse(focoBrush, New Rectangle(centerX - radiusInner, centerY - radiusInner, radiusInner * 2, radiusInner * 2))
            End Using
        End If

        ' Texto
        Dim textRect = New Rectangle(32, 0, Me.Width - 40, Me.Height)
        TextRenderer.DrawText(e.Graphics, Me.Text, Me.Font, textRect, _textColor, TextFormatFlags.Left Or TextFormatFlags.VerticalCenter)
    End Sub

    'COMO USARLO

    'Dim opt1 As New OptionButtonUI()
    'opt1.Text = "Opción A"
    'opt1.Checked = True
    'Me.Controls.Add(opt1)

    '    Dim opt2 As New OptionButtonUI()
    'opt2.Text = "Opción B"
    'opt2.Location = New Point(opt1.Left, opt1.Bottom + 10)
    'Me.Controls.Add(opt2)

End Class
