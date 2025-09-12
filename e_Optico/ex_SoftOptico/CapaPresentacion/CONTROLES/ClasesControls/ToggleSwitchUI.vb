Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class ToggleSwitchUI
    Inherits Control

    Private _isChecked As Boolean = False
    Private _backgroundOn As Color = Color.MediumSeaGreen
    Private _backgroundOff As Color = Color.LightGray
    Private _switchColor As Color = Color.White
    Private _borderRadius As Integer = 25
    Private _textOn As String = "Encendido"
    Private _textOff As String = "Apagado"
    Private _textColor As Color = Color.Black
    Private _animSpeed As Single = 0.2F
    Private _showStateText As Boolean = True

    ' Iconos (si se desea usar iconos en vez de texto)
    Private _useIcons As Boolean = False
    Private _iconOnGlyph As String = "✔"
    Private _iconOffGlyph As String = "✖"
    Private _iconFont As Font = New Font(AppFonts.Century, AppFonts.SizeMedium, AppFonts.Bold)

    ' Animación
    Private switchPosX As Single = 4
    Private targetPosX As Single = 4
    Private animColor As Color
    Private targetColor As Color
    Private WithEvents timerAnimacion As New Timer()

    ' Hover
    Private _hovering As Boolean = False

    Public Sub New()
        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor Or
                    ControlStyles.UserPaint Or
                    ControlStyles.AllPaintingInWmPaint Or
                    ControlStyles.OptimizedDoubleBuffer, True)
        Me.UpdateStyles()
        Me.Font = New Font(AppFonts.Century, AppFonts.SizeSmall, AppFonts.Regular)
        Me.Size = New Size(140, 36)
        Me.Cursor = Cursors.Hand

        timerAnimacion.Interval = 15
        animColor = _backgroundOff
        targetColor = _backgroundOff
    End Sub

#Region "Propiedades"

    <Category("UI Estilo")>
    Public Property BackgroundOn As Color
        Get
            Return _backgroundOn
        End Get
        Set(value As Color)
            _backgroundOn = value
            targetColor = If(_isChecked, _backgroundOn, _backgroundOff)
            Invalidate()
        End Set
    End Property

    <Category("UI Estilo")>
    Public Property BackgroundOff As Color
        Get
            Return _backgroundOff
        End Get
        Set(value As Color)
            _backgroundOff = value
            targetColor = If(_isChecked, _backgroundOn, _backgroundOff)
            Invalidate()
        End Set
    End Property

    <Category("UI Estilo")>
    Public Property SwitchColor As Color
        Get
            Return _switchColor
        End Get
        Set(value As Color)
            _switchColor = value
            Invalidate()
        End Set
    End Property

    <Category("UI Estilo")>
    Public Property BorderRadius As Integer
        Get
            Return _borderRadius
        End Get
        Set(value As Integer)
            _borderRadius = value
            Invalidate()
        End Set
    End Property

    <Category("UI Texto")>
    Public Property TextoEncendido As String
        Get
            Return _textOn
        End Get
        Set(value As String)
            _textOn = value
            Invalidate()
        End Set
    End Property

    <Category("UI Texto")>
    Public Property TextoApagado As String
        Get
            Return _textOff
        End Get
        Set(value As String)
            _textOff = value
            Invalidate()
        End Set
    End Property

    <Category("UI Texto")>
    Public Property MostrarTextoEstado As Boolean
        Get
            Return _showStateText
        End Get
        Set(value As Boolean)
            _showStateText = value
            Invalidate()
        End Set
    End Property

    <Category("UI Estilo")>
    Public Property TextColor As Color
        Get
            Return _textColor
        End Get
        Set(value As Color)
            _textColor = value
            Invalidate()
        End Set
    End Property

    <Category("UI Estilo")>
    Public Property VelocidadAnimacion As Single
        Get
            Return _animSpeed
        End Get
        Set(value As Single)
            _animSpeed = Math.Max(0.05F, Math.Min(1.0F, value))
        End Set
    End Property

    <Category("UI Iconos")>
    Public Property UseIcons As Boolean
        Get
            Return _useIcons
        End Get
        Set(value As Boolean)
            _useIcons = value
            Invalidate()
        End Set
    End Property

    <Category("UI Iconos")>
    Public Property IconOnGlyph As String
        Get
            Return _iconOnGlyph
        End Get
        Set(value As String)
            _iconOnGlyph = value
            Invalidate()
        End Set
    End Property

    <Category("UI Iconos")>
    Public Property IconOffGlyph As String
        Get
            Return _iconOffGlyph
        End Get
        Set(value As String)
            _iconOffGlyph = value
            Invalidate()
        End Set
    End Property

    <Category("Estado")>
    Public Property Checked As Boolean
        Get
            Return _isChecked
        End Get
        Set(value As Boolean)
            If _isChecked <> value Then
                _isChecked = value
                ' calcular posición destino según tamaño del switch
                Dim trackRectWidth = Math.Max(48, CInt(Me.Height * 1.4))
                Dim switchW = Math.Max(14, Me.Height - 8)
                targetPosX = If(_isChecked, trackRectWidth - switchW - 4, 4)
                targetColor = If(_isChecked, _backgroundOn, _backgroundOff)
                timerAnimacion.Start()
                OnCheckedChanged(EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property EstadoTexto As String

#End Region

#Region "Eventos"

    Public Event CheckedChanged As EventHandler
    Protected Overridable Sub OnCheckedChanged(e As EventArgs)
        RaiseEvent CheckedChanged(Me, e)
    End Sub

    Protected Overrides Sub OnClick(e As EventArgs)
        MyBase.OnClick(e)
        Me.Checked = Not Me.Checked
    End Sub

    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)
        _hovering = True
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        _hovering = False
        Invalidate()
    End Sub

#End Region

#Region "Animación y utilidades"

    Private Sub timerAnimacion_Tick(sender As Object, e As EventArgs) Handles timerAnimacion.Tick
        ' Movimiento (ease-out style)
        switchPosX += (targetPosX - switchPosX) * _animSpeed

        ' Interpolar color de forma segura
        animColor = InterpolateColorSafe(animColor, targetColor, _animSpeed)

        ' condición de parada: posición y color cerca del objetivo
        Dim posClose As Boolean = Math.Abs(switchPosX - targetPosX) < 0.5F
        Dim colorClose As Boolean = ColorDistance(animColor, targetColor) < 6

        If posClose And colorClose Then
            switchPosX = targetPosX
            animColor = targetColor
            timerAnimacion.Stop()
        End If

        Invalidate()
    End Sub

    ' Comparar distancia simple entre colores por componentes
    Private Function ColorDistance(c1 As Color, c2 As Color) As Integer
        Dim dR As Integer = Math.Abs(CInt(c1.R) - CInt(c2.R))
        Dim dG As Integer = Math.Abs(CInt(c1.G) - CInt(c2.G))
        Dim dB As Integer = Math.Abs(CInt(c1.B) - CInt(c2.B))
        Return dR + dG + dB
    End Function

    ' Versión robusta y segura de la interpolación de colores (evita NaN/Overflow)
    Private Function InterpolateColorSafe(c1 As Color, c2 As Color, factorInput As Single) As Color
        Dim factor As Double = CDbl(factorInput)
        If Double.IsNaN(factor) OrElse Double.IsInfinity(factor) Then factor = 0.0
        If factor < 0 Then factor = 0
        If factor > 1 Then factor = 1

        Dim a1 As Double = c1.A, r1 As Double = c1.R, g1 As Double = c1.G, b1 As Double = c1.B
        Dim a2 As Double = c2.A, r2 As Double = c2.R, g2 As Double = c2.G, b2 As Double = c2.B

        Dim a As Integer = CInt(Math.Round(a1 + (a2 - a1) * factor))
        Dim r As Integer = CInt(Math.Round(r1 + (r2 - r1) * factor))
        Dim g As Integer = CInt(Math.Round(g1 + (g2 - g1) * factor))
        Dim b As Integer = CInt(Math.Round(b1 + (b2 - b1) * factor))

        a = Math.Min(255, Math.Max(0, a))
        r = Math.Min(255, Math.Max(0, r))
        g = Math.Min(255, Math.Max(0, g))
        b = Math.Min(255, Math.Max(0, b))

        Return Color.FromArgb(a, r, g, b)
    End Function

#End Region

#Region "Dibujo"

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        ' Track (fondo redondeado)
        Dim trackWidth As Integer = Math.Max(48, CInt(Me.Height * 1.4))
        Dim rect = New Rectangle(0, 0, trackWidth, Me.Height - 1)
        Using path As GraphicsPath = RoundedPath(rect, _borderRadius)
            Using fondoBrush As New SolidBrush(animColor)
                e.Graphics.FillPath(fondoBrush, path)
            End Using
        End Using

        ' Switch (círculo)
        Dim switchW As Integer = Math.Max(14, Me.Height - 8)
        Dim switchRect = New Rectangle(CInt(switchPosX), 4, switchW, Me.Height - 8)
        Using switchBrush As New SolidBrush(_switchColor)
            e.Graphics.FillEllipse(switchBrush, switchRect)
        End Using

        ' Hover glow
        If _hovering Then
            Using glow As New Pen(Color.FromArgb(60, Color.Black), 2)
                e.Graphics.DrawEllipse(glow, switchRect)
            End Using
        End If

        ' Texto o icono al lado derecho
        Dim drawX As Integer = trackWidth + 8
        Dim drawRect As New Rectangle(drawX, 0, Me.Width - drawX, Me.Height)

        If _useIcons Then
            Dim glyph As String = If(_isChecked, _iconOnGlyph, _iconOffGlyph)
            TextRenderer.DrawText(e.Graphics, glyph, _iconFont, drawRect, _textColor, TextFormatFlags.VerticalCenter Or TextFormatFlags.Left)
        ElseIf _showStateText Then
            Dim estadoTxt As String = If(_isChecked, _textOn, _textOff)
            TextRenderer.DrawText(e.Graphics, estadoTxt, Me.Font, drawRect, _textColor, TextFormatFlags.Left Or TextFormatFlags.VerticalCenter)
        End If
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

#End Region

End Class
