Imports System.Drawing
Imports System.Windows.Forms
Imports FontAwesome.Sharp

Public Class cLabelUI
    Inherits UserControl

    Private innerLabel As New Label()
    Private orbitalIcon As New IconPictureBox()

    Private _borderRadius As Integer = 10
    Private _colorBase As Color = Color.Gray
    Private _colorHover As Color = Color.RoyalBlue
    Private _factorTransicion As Single = 0.0F
    Private WithEvents hoverTimer As New Timer() With {.Interval = 25}

    Public Sub New()
        Me.DoubleBuffered = True
        Me.BackColor = Color.Transparent
        Me.MinimumSize = New Size(100, 30)

        ' 🏷 Label orbital
        innerLabel.Location = New Point(5, 5)
        innerLabel.Size = New Size(Me.Width - 35, Me.Height - 10)
        innerLabel.ForeColor = _colorBase
        innerLabel.BackColor = Color.Transparent
        innerLabel.TextAlign = ContentAlignment.MiddleLeft
        innerLabel.Font = Me.Font
        Me.Controls.Add(innerLabel)

        ' 🧿 Ícono orbital
        orbitalIcon.Size = New Size(20, 20)
        orbitalIcon.IconChar = IconChar.Circle
        orbitalIcon.IconColor = _colorBase
        orbitalIcon.BackColor = Color.Transparent
        orbitalIcon.Location = New Point(Me.Width - 25, (Me.Height - 20) \ 2)
        Me.Controls.Add(orbitalIcon)

        ' 🔧 Ajuste al cambiar tamaño
        AddHandler Me.Resize, Sub()
                                  innerLabel.Size = New Size(Me.Width - 35, Me.Height - 10)
                                  orbitalIcon.Location = New Point(Me.Width - 25, (Me.Height - 20) \ 2)
                              End Sub
    End Sub

    ' 🌈 Interpolación segura
    Private Function InterpolateColor(baseColor As Color, targetColor As Color, factor As Single) As Color
        factor = Math.Max(0.0F, Math.Min(1.0F, factor))
        Dim r = CInt(Math.Round(baseColor.R + (targetColor.R - baseColor.R) * factor))
        Dim g = CInt(Math.Round(baseColor.G + (targetColor.G - baseColor.G) * factor))
        Dim b = CInt(Math.Round(baseColor.B + (targetColor.B - baseColor.B) * factor))
        Dim a = CInt(Math.Round(baseColor.A + (targetColor.A - baseColor.A) * factor))
        Return Color.FromArgb(a, Math.Min(255, Math.Max(0, r)),
                                 Math.Min(255, Math.Max(0, g)),
                                 Math.Min(255, Math.Max(0, b)))
    End Function

    Private Function GetRoundedPath(bounds As Rectangle, radius As Integer) As Drawing2D.GraphicsPath
        Dim path As New Drawing2D.GraphicsPath()
        path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90)
        path.AddArc(bounds.Right - radius, bounds.Y, radius, radius, 270, 90)
        path.AddArc(bounds.Right - radius, bounds.Bottom - radius, radius, radius, 0, 90)
        path.AddArc(bounds.X, bounds.Bottom - radius, radius, radius, 90, 90)
        path.CloseFigure()
        Return path
    End Function

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        Dim radius As Integer = 10 ' 🎨 radio de borde redondeado
        Dim path = GetRoundedPath(Me.ClientRectangle, _borderRadius)

        ' Establece la región para aplicar clipping visual
        Me.Region = New Region(path)

        ' Opcional: dibujar borde si lo deseas
        Using pen As New Pen(_colorBase, 1)
            e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            e.Graphics.DrawPath(pen, path)
        End Using
    End Sub

    Private Sub IniciarHover()
        _factorTransicion = 0.0F
        hoverTimer.Start()
    End Sub

    Private Sub hoverTimer_Tick(sender As Object, e As EventArgs) Handles hoverTimer.Tick
        If _factorTransicion < 1.0F Then
            _factorTransicion += 0.05F
            Dim colorActual = InterpolateColor(_colorBase, _colorHover, _factorTransicion)
            innerLabel.ForeColor = colorActual
            orbitalIcon.IconColor = colorActual
            Me.Invalidate()
        Else
            hoverTimer.Stop()
        End If
    End Sub

    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)
        IniciarHover()
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        hoverTimer.Stop()
        _factorTransicion = 0.0F
        innerLabel.ForeColor = _colorBase
        orbitalIcon.IconColor = _colorBase
        Me.Invalidate()
    End Sub

    <System.ComponentModel.Browsable(True)>
    Public Property BorderRadius As Integer
        Get
            Return _borderRadius
        End Get
        Set(value As Integer)
            _borderRadius = value
            Me.Invalidate()
        End Set
    End Property

    ' 🔧 Propiedades navegables
    Public Property HoverColor As Color
        Get
            Return _colorHover
        End Get
        Set(value As Color)
            _colorHover = value
        End Set
    End Property

    Public Property BaseColor As Color
        Get
            Return _colorBase
        End Get
        Set(value As Color)
            _colorBase = value
            innerLabel.ForeColor = value
            orbitalIcon.IconColor = value
        End Set
    End Property

    Public Shadows Property Font As Font
        Get
            Return innerLabel.Font
        End Get
        Set(value As Font)
            innerLabel.Font = value
        End Set
    End Property

    Public Property IconChar As IconChar
        Get
            Return orbitalIcon.IconChar
        End Get
        Set(value As IconChar)
            orbitalIcon.IconChar = value
        End Set
    End Property

    <System.ComponentModel.Browsable(True)>
    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)>
    Public Overrides Property Text As String
        Get
            Return innerLabel.Text
        End Get
        Set(value As String)
            innerLabel.Text = value
            innerLabel.Invalidate()
        End Set
    End Property
End Class