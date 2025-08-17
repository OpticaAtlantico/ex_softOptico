Imports System.ComponentModel
Imports System.Drawing.Drawing2D

Public Class PanelUI
    Inherits UserControl

    Private lblContenido As New Label()

    Private _borderRadius As Integer = 12
    Private _borderColor As Color = Color.LightGray
    Private _borderSize As Integer = 1
    Private _shadowColor As Color = Color.FromArgb(50, 0, 0, 0)
    Private _shadowSize As Integer = 6
    Private _backColorCard As Color = Color.White
    Private _textColor As Color = Color.Black
    Private _estilo As EstiloCard = EstiloCard.None

    Public Enum EstiloCard
        None
        Success
        Info
        Warning
        Danger
    End Enum

    Public Sub New()
        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor Or
                    ControlStyles.UserPaint Or
                    ControlStyles.AllPaintingInWmPaint Or
                    ControlStyles.OptimizedDoubleBuffer, True)
        Me.UpdateStyles()
        Me.BackColor = Color.Transparent
        Me.Size = New Size(300, 80)

        With lblContenido
            .AutoSize = False
            .Dock = DockStyle.Fill
            .TextAlign = ContentAlignment.MiddleLeft
            .Padding = New Padding(12)
            .Font = New Font("Segoe UI", 10, FontStyle.Regular)
        End With

        Me.Controls.Add(lblContenido)
        AplicarEstiloVisual()
    End Sub

    ' === Estilo visual ===
    Private Sub AplicarEstiloVisual()
        Select Case _estilo
            Case EstiloCard.Success
                _backColorCard = Color.FromArgb(223, 240, 216)
                _borderColor = Color.FromArgb(60, 118, 61)
                _textColor = Color.FromArgb(60, 118, 61)
            Case EstiloCard.Info
                _backColorCard = Color.FromArgb(217, 237, 247)
                _borderColor = Color.FromArgb(49, 112, 143)
                _textColor = Color.FromArgb(49, 112, 143)
            Case EstiloCard.Warning
                _backColorCard = Color.FromArgb(252, 248, 227)
                _borderColor = Color.FromArgb(138, 109, 59)
                _textColor = Color.FromArgb(138, 109, 59)
            Case EstiloCard.Danger
                _backColorCard = Color.FromArgb(242, 222, 222)
                _borderColor = Color.FromArgb(169, 68, 66)
                _textColor = Color.FromArgb(169, 68, 66)
            Case Else
                _backColorCard = Color.White
                _borderColor = Color.LightGray
                _textColor = Color.Black
        End Select
        lblContenido.ForeColor = _textColor
        Me.Invalidate()
    End Sub

    ' === Dibujar tarjeta con sombra y bordes ===
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        Dim cardRect = Me.ClientRectangle
        cardRect.Inflate(-_shadowSize, -_shadowSize)

        ' === Sombra ===
        Dim shadowRect = Rectangle.Inflate(cardRect, _shadowSize, _shadowSize)
        Using pathShadow As GraphicsPath = RoundedPath(shadowRect, _borderRadius)
            Using brushShadow As New SolidBrush(_shadowColor)
                e.Graphics.FillPath(brushShadow, pathShadow)
            End Using
        End Using

        ' === Fondo ===
        Using pathCard As GraphicsPath = RoundedPath(cardRect, _borderRadius)
            Using brushCard As New SolidBrush(_backColorCard)
                e.Graphics.FillPath(brushCard, pathCard)
            End Using

            If _borderSize > 0 Then
                Using penBorder As New Pen(_borderColor, _borderSize)
                    e.Graphics.DrawPath(penBorder, pathCard)
                End Using
            End If

            Me.Region = New Region(pathCard)
        End Using
    End Sub

    Private Function RoundedPath(rect As Rectangle, radius As Integer) As GraphicsPath
        Dim path As New GraphicsPath()
        Dim diameter As Integer = radius * 2
        path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90)
        path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90)
        path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90)
        path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90)
        path.CloseFigure()
        Return path
    End Function

    ' === PROPIEDADES ===
    <Category("WilmerUI")>
    Public Property BorderRadius As Integer
        Get
            Return _borderRadius
        End Get
        Set(value As Integer)
            _borderRadius = value
            Me.Invalidate()
        End Set
    End Property

    <Category("WilmerUI")>
    Public Property BorderSize As Integer
        Get
            Return _borderSize
        End Get
        Set(value As Integer)
            _borderSize = value
            Me.Invalidate()
        End Set
    End Property

    <Category("WilmerUI")>
    Public Property BorderColor As Color
        Get
            Return _borderColor
        End Get
        Set(value As Color)
            _borderColor = value
            Me.Invalidate()
        End Set
    End Property

    <Category("WilmerUI")>
    Public Property CardBackColor As Color
        Get
            Return _backColorCard
        End Get
        Set(value As Color)
            _backColorCard = value
            Me.Invalidate()
        End Set
    End Property

    <Category("WilmerUI")>
    Public Property ShadowColor As Color
        Get
            Return _shadowColor
        End Get
        Set(value As Color)
            _shadowColor = value
            Me.Invalidate()
        End Set
    End Property

    <Category("WilmerUI")>
    Public Property Estilo As EstiloCard
        Get
            Return _estilo
        End Get
        Set(value As EstiloCard)
            _estilo = value
            AplicarEstiloVisual()
            Me.Invalidate()
        End Set
    End Property

    <Category("WilmerUI")>
    Public Property Texto As String
        Get
            Return lblContenido.Text
        End Get
        Set(value As String)
            lblContenido.Text = value
        End Set
    End Property
End Class
