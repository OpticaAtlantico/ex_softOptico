Imports System.Drawing.Drawing2D
Imports System.Drawing
Imports System.Windows.Forms
Public Class PanelWUI
    Inherits UserControl

    Private _borderRadius As Integer = 8
    Private _shadowColor As Color = Color.FromArgb(30, Color.Black)
    Private _backgroundColor As Color = Color.White
    Private _borderColor As Color = Color.LightGray

    Public Sub New()
        Me.Size = New Size(300, 150)
        Me.BackColor = Color.Transparent
        Me.DoubleBuffered = True
    End Sub

    ' 🧩 Propiedades públicas

    Public Property BorderRadius As Integer
        Get
            Return _borderRadius
        End Get
        Set(value As Integer)
            _borderRadius = value
            Me.Invalidate()
        End Set
    End Property

    Public Property ShadowColor As Color
        Get
            Return _shadowColor
        End Get
        Set(value As Color)
            _shadowColor = value
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

    ' 🎨 Render visual profesional

    Protected Overrides Sub OnPaint(pe As PaintEventArgs)
        Dim g = pe.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias

        Dim rect = New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)

        ' Sombra
        Dim shadowRect = New Rectangle(rect.X + 1, rect.Y + 1, rect.Width, rect.Height)
        g.FillRectangle(New SolidBrush(_shadowColor), shadowRect)

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
    End Sub
End Class
