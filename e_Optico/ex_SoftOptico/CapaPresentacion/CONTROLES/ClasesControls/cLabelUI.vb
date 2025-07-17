Imports System.Drawing.Drawing2D
Imports FontAwesome.Sharp

Public Class cLabelUI
    Inherits UserControl

    Private _texto As String = "Etiqueta"
    Private _textoColor As Color = Color.Black
    Private _fondoColor As Color = Color.LightGray
    Private _borderRadius As Integer = 10
    Private _icono As IconChar = IconChar.InfoCircle
    Private _iconoColor As Color = Color.Black
    Private _hoverColor As Color = Color.DodgerBlue
    Private iconoControl As IconPictureBox
    Private lblTexto As Label

    Private _hovered As Boolean = False
    Private animationTimer As Timer
    Private fadeValue As Integer = 255

    Public Sub New()
        Me.DoubleBuffered = True
        Me.Size = New Size(200, 32)
        Me.BackColor = Color.Transparent

        lblTexto = New Label With {
            .Text = _texto,
            .ForeColor = _textoColor,
            .Font = New Font("Century Gotic", 12),
            .AutoSize = False,
            .TextAlign = ContentAlignment.MiddleLeft,
            .Padding = New Padding(8, 0, 0, 0),
            .Dock = DockStyle.Fill
        }
        Me.Controls.Add(lblTexto)

        iconoControl = New IconPictureBox With {
            .IconChar = _icono,
            .IconColor = _iconoColor,
            .Size = New Size(24, 24),
            .BackColor = Color.Transparent,
            .Location = New Point(Me.Width - 28, 4),
            .Cursor = Cursors.Hand
        }
        Me.Controls.Add(iconoControl)
        AddHandler Me.Resize, AddressOf AjustarIcono

        animationTimer = New Timer With {.Interval = 25}
        AddHandler animationTimer.Tick, AddressOf AnimarOpacidad

        AddHandler Me.MouseEnter, Sub()
                                      _hovered = True
                                      animationTimer.Start()
                                  End Sub

        AddHandler Me.MouseLeave, Sub()
                                      _hovered = False
                                      animationTimer.Start()
                                  End Sub
    End Sub

    ' ➤ Propiedades públicas
    Public Property Texto As String
        Get
            Return _texto
        End Get
        Set(value As String)
            _texto = value
            lblTexto.Text = value
            Me.Invalidate()
        End Set
    End Property

    Public Property TextoColor As Color
        Get
            Return _textoColor
        End Get
        Set(value As Color)
            _textoColor = value
            lblTexto.ForeColor = value
        End Set
    End Property

    Public Property FondoColor As Color
        Get
            Return _fondoColor
        End Get
        Set(value As Color)
            _fondoColor = value
            Me.Invalidate()
        End Set
    End Property

    Public Property HoverColor As Color
        Get
            Return _hoverColor
        End Get
        Set(value As Color)
            _hoverColor = value
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

    Public Property Icono As IconChar
        Get
            Return _icono
        End Get
        Set(value As IconChar)
            _icono = value
            iconoControl.IconChar = value
        End Set
    End Property

    Public Property IconoColor As Color
        Get
            Return _iconoColor
        End Get
        Set(value As Color)
            _iconoColor = value
            iconoControl.IconColor = value
        End Set
    End Property

    Private Sub AjustarIcono()
        If iconoControl IsNot Nothing Then
            iconoControl.Location = New Point(Me.Width - iconoControl.Width - 6, (Me.Height - iconoControl.Height) \ 2)
        End If
    End Sub

    ' ➤ Animación suave de fondo
    Private Sub AnimarOpacidad(sender As Object, e As EventArgs)
        Dim targetColor = If(_hovered, _hoverColor, _fondoColor)
        Dim blend = If(_hovered, 0.2F, 0.1F)

        _fondoColor = MezclarColor(_fondoColor, targetColor, blend)
        iconoControl.IconColor = MezclarColor(_iconoColor, targetColor, blend)
        Me.Invalidate()

        fadeValue = If(_hovered, Math.Min(fadeValue + 15, 255), Math.Max(fadeValue - 15, 180))
        If fadeValue = 255 OrElse fadeValue = 180 Then animationTimer.Stop()
    End Sub

    Private Function MezclarColor(base As Color, target As Color, factor As Single) As Color
        Dim r = base.R + (target.R - base.R) * factor
        Dim g = base.G + (target.G - base.G) * factor
        Dim b = base.B + (target.B - base.B) * factor
        Return Color.FromArgb(CInt(r), CInt(g), CInt(b))
    End Function

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim g = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias

        Dim path = New GraphicsPath()
        path.AddArc(0, 0, _borderRadius, _borderRadius, 180, 90)
        path.AddArc(Me.Width - _borderRadius, 0, _borderRadius, _borderRadius, 270, 90)
        path.AddArc(Me.Width - _borderRadius, Me.Height - _borderRadius, _borderRadius, _borderRadius, 0, 90)
        path.AddArc(0, Me.Height - _borderRadius, _borderRadius, _borderRadius, 90, 90)
        path.CloseFigure()

        Using brush As New SolidBrush(Color.FromArgb(fadeValue, _fondoColor))
            g.FillPath(brush, path)
        End Using
    End Sub
End Class