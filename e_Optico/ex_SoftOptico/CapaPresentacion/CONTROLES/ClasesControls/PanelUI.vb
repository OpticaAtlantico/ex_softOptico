Imports System.ComponentModel
Imports System.Drawing.Drawing2D

Public Class PanelUI
    Inherits UserControl

    Private lblContenido As New Label()

    Private _borderRadius As Integer = AppLayout.BorderRadiusStandar
    Private _borderColor As Color = AppColors._cBasePrimary
    Private _borderSize As Integer = AppLayout.BorderSizeMediun
    Private _shadowColor As Color = AppColors._cSombra
    Private _shadowSize As Integer = AppLayout.PanelHeightStandar
    Private _backColorCard As Color = AppColors._cBlanco
    Private _textColor As Color = AppColors._cTexto
    Private _estilo As EstiloCard = EstiloCard.None

    Public Enum EstiloCard
        None
        Primary
        Success
        Info
        Warning
        Danger
    End Enum

#Region "PROPIDADES"
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
#End Region

#Region "CONSTRUCTOR"
    Public Sub New()
        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor Or
                    ControlStyles.UserPaint Or
                    ControlStyles.AllPaintingInWmPaint Or
                    ControlStyles.OptimizedDoubleBuffer, True)
        Me.UpdateStyles()
        Me.BackColor = Color.Transparent
        Me.Size = New Size(300, 100)

        With lblContenido
            .AutoSize = False
            .Dock = DockStyle.Fill
            .TextAlign = ContentAlignment.MiddleLeft
            .Padding = New Padding(AppLayout.Padding2)
            .Font = New Font(AppFonts.Century, AppFonts.SizeSmall, AppFonts.Regular)
        End With

        Me.Controls.Add(lblContenido)
        AplicarEstiloVisual()
    End Sub
#End Region

#Region "ESTILOS VISUALES"
    Private Sub AplicarEstiloVisual()
        Select Case _estilo
            Case EstiloCard.Primary
                _backColorCard = AppColors._cHoverPrimary
                _borderColor = AppColors._cBasePrimary
                _textColor = AppColors._cTextoPrimary
            Case EstiloCard.Success
                _backColorCard = AppColors._cHoverSuccess
                _borderColor = AppColors._cBaseSuccess
                _textColor = AppColors._cTextoSuccess
            Case EstiloCard.Info
                _backColorCard = AppColors._cHoverInfo
                _borderColor = AppColors._cBaseInfo
                _textColor = AppColors._cTextoInfo
            Case EstiloCard.Warning
                _backColorCard = AppColors._cHoverWarning
                _borderColor = AppColors._cBaseWarning
                _textColor = AppColors._cTextoWarning
            Case EstiloCard.Danger
                _backColorCard = AppColors._cHoverDanger
                _borderColor = AppColors._cBaseDanger
                _textColor = AppColors._cTextoDanger
            Case Else
                _backColorCard = AppColors._cBlancoOscuro
                _borderColor = AppColors._cBaseInfo
                _textColor = AppColors._cTexto
        End Select
        lblContenido.ForeColor = _textColor
        Me.Invalidate()
    End Sub
#End Region

#Region "DIBUJO"
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
        Dim diameter As Integer = radius
        path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90)
        path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90)
        path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90)
        path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90)
        path.CloseFigure()
        Return path
    End Function
#End Region

End Class
