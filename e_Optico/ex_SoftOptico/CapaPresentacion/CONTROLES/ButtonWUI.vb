Imports System.Drawing.Drawing2D
Imports System.Drawing
Imports System.Windows.Forms
Public Class ButtonWUI
    Inherits UserControl

    Private _text As String = "Botón"
    Private _baseColor As Color = Color.SteelBlue
    Private _textColor As Color = Color.White
    Private _rippleColor As Color = Color.FromArgb(100, Color.White)
    Private _rippleRadius As Integer = 0
    Private _rippleOrigin As Point
    Private _isRippling As Boolean = False
    Private _borderRadius As Integer = 6
    Private _flatStyle As Integer

    Public Sub New()
        Me.Size = New Size(120, 35)
        Me.BackColor = Color.Transparent
        Me.DoubleBuffered = True
    End Sub

    ' 🧩 Propiedades públicas

    Public Property BotonTexto As String
        Get
            Return _text
        End Get
        Set(value As String)
            _text = value
            Me.Invalidate()
        End Set
    End Property

    Public Property BaseColor As Color
        Get
            Return _baseColor
        End Get
        Set(value As Color)
            _baseColor = value
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

    Public Property RippleColor As Color
        Get
            Return _rippleColor
        End Get
        Set(value As Color)
            _rippleColor = value
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

    Public Property FlatStyle As Integer
        Get
            Return _flatStyle
        End Get
        Set(value As Integer)
            _flatStyle = value
            Me.Invalidate()
        End Set
    End Property

    ' 🎨 Render visual

    Protected Overrides Sub OnPaint(pe As PaintEventArgs)
        Dim g = pe.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias

        Dim rect = Me.ClientRectangle
        Dim path = New GraphicsPath()
        path.AddArc(0, 0, _borderRadius, _borderRadius, 180, 90)
        path.AddArc(rect.Width - _borderRadius, 0, _borderRadius, _borderRadius, 270, 90)
        path.AddArc(rect.Width - _borderRadius, rect.Height - _borderRadius, _borderRadius, _borderRadius, 0, 90)
        path.AddArc(0, rect.Height - _borderRadius, _borderRadius, _borderRadius, 90, 90)
        path.CloseFigure()

        ' Fondo
        g.FillPath(New SolidBrush(_baseColor), path)

        ' Ripple efecto
        If _isRippling Then
            Using rippleBrush As New SolidBrush(_rippleColor)
                g.FillEllipse(rippleBrush, _rippleOrigin.X - _rippleRadius, _rippleOrigin.Y - _rippleRadius, _rippleRadius * 2, _rippleRadius * 2)
            End Using
        End If

        ' Texto
        TextRenderer.DrawText(g, _text, New Font("Segoe UI", 10), rect, _textColor, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        _rippleOrigin = e.Location
        _rippleRadius = 0
        _isRippling = True

        Dim timer As New Timer With {.Interval = 15}
        AddHandler timer.Tick, Sub()
                                   _rippleRadius += 8
                                   If _rippleRadius > Me.Width * 2 Then
                                       _isRippling = False
                                       timer.Stop()
                                       timer.Dispose()
                                   End If
                                   Me.Invalidate()
                               End Sub
        timer.Start()

        RaiseEvent BotonClick(Me, EventArgs.Empty)
    End Sub

    ' 🎯 Evento público

    Public Event BotonClick As EventHandler


    'Dim btnGuardar As New ButtonUI()
    'btnGuardar.BotonTexto = "Guardar"
    'btnGuardar.BaseColor = Color.MediumSeaGreen
    'btnGuardar.RippleColor = Color.FromArgb(120, Color.White)
    'btnGuardar.TextColor = Color.White
    'AddHandler btnGuardar.BotonClick, Sub() MessageBox.Show("Guardado exitoso")
    'Me.Controls.Add(btnGuardar)

End Class
