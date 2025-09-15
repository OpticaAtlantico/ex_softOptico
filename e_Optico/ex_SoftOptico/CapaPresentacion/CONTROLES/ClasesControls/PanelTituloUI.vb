Imports System.ComponentModel
Imports System.Drawing.Drawing2D

Public Class PanelTituloUI
    Inherits UserControl

    Private lblContenido As New Label()
    Private contenedor As New Panel()
    Private WithEvents Titulo As New Panel()

    Private _borderRadius As Integer = AppLayout.BorderRadiusPanel
    Private _borderColor As Color = AppColors._cPanelBorderColor
    Private _borderSize As Integer = AppLayout.BorderSizeMediun
    Private _shadowColor As Color = AppColors._cPanelSombracolor
    Private _shadowSize As Integer = 3
    Private _backColorCard As Color = AppColors._cPanelBackColor
    Private _backColorContenedor As Color = Color.Transparent ' AppColors._cBlancoOscuro
    Private _backColorTitulo As Color = AppColors._cBasePrimary ' AppColors._cBlancoOscuro
    Private _borderColorTitulo As Color = AppColors._cBlanco
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

#Region "PROPIEDADES"
    <Category("WilmerUI")>
    Public Property BorderRadius As Integer
        Get
            Return _borderRadius
        End Get
        Set(value As Integer)
            _borderRadius = Math.Max(0, value)
            Me.Invalidate()
        End Set
    End Property

    <Category("WilmerUI")>
    Public Property BorderSize As Integer
        Get
            Return _borderSize
        End Get
        Set(value As Integer)
            _borderSize = Math.Max(0, value)
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
    Public Property BorderColorTitulo As Color
        Get
            Return _borderColorTitulo
        End Get
        Set(value As Color)
            _borderColorTitulo = value
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
    Public Property BackColorContenedor As Color
        Get
            Return _backColorContenedor
        End Get
        Set(value As Color)
            _backColorContenedor = value
            Me.Invalidate()
        End Set
    End Property

    <Category("WilmerUI")>
    Public Property BackColorTitulo As Color
        Get
            Return _backColorTitulo
        End Get
        Set(value As Color)
            _backColorTitulo = value
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

        With contenedor
            .Dock = DockStyle.Fill
            .BackColor = _backColorContenedor
            .Padding = New Padding(0, 0, 6, 0)
        End With

        With Titulo
            .Dock = DockStyle.Top
            .Height = 50
            .BorderStyle = BorderStyle.None
            .BackColor = _backColorTitulo
            .Padding = New Padding(AppLayout.Padding0)
        End With
        contenedor.Controls.Add(Titulo)

        'lblContenido.Controls.Add(contenedor)
        Me.Controls.Add(contenedor)
        AplicarEstiloVisual()

        AddHandler Titulo.Paint, AddressOf Titulo_Paint
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
                _backColorCard = AppColors._cPanelBackColor
                _borderColor = _borderColor
                _textColor = AppColors._cTexto
        End Select
        lblContenido.ForeColor = _textColor
        Me.Invalidate()
    End Sub
#End Region

#Region "DIBUJO"
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        Dim r = Math.Min(_borderRadius, Math.Min(Me.Width, Me.Height) \ 2)

        ' Rectángulo de la tarjeta (dejando espacio para sombra fuera)
        Dim rectCard As New Rectangle(0, 0, Me.Width - 6, Me.Height - 6)

        ' Sombra desplazada 3px abajo y derecha, queda fuera del panel
        If _shadowSize > 0 Then
            Dim shadowRect As New Rectangle(rectCard.X + 3, rectCard.Y + 3, rectCard.Width, rectCard.Height)
            Using pathShadow As GraphicsPath = RoundedPath(shadowRect, r)
                Using brushShadow As New SolidBrush(_shadowColor)
                    e.Graphics.FillPath(brushShadow, pathShadow)
                End Using
            End Using
        End If

        ' Fondo tarjeta
        Using pathCard As GraphicsPath = RoundedPath(rectCard, r)
            Using brushCard As New SolidBrush(_backColorCard)
                e.Graphics.FillPath(brushCard, pathCard)
            End Using

            ' Borde
            If _borderSize > 0 Then
                Using penBorder As New Pen(_borderColor, _borderSize)
                    e.Graphics.DrawPath(penBorder, pathCard)
                End Using
            End If
        End Using

        ' NO cambiar Me.Region, para que la sombra fuera del panel sea visible
        ' Me.Region = New Region(pathCard)
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

    Private Function RoundedTopPath(rect As Rectangle, radius As Integer) As GraphicsPath
        Dim path As New GraphicsPath()
        path.StartFigure()
        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90) ' arriba izquierda
        path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90) ' arriba derecha
        path.AddLine(rect.Right, rect.Bottom, rect.X, rect.Bottom) ' línea recta abajo
        path.CloseFigure()
        Return path
    End Function

    Private Sub Titulo_Paint(sender As Object, e As PaintEventArgs) Handles Titulo.Paint
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect As New Rectangle(0, 0, Titulo.Width, Titulo.Height)

        Using path As GraphicsPath = RoundedTopPath(rect, _borderRadius)
            ' 🔹 Asignar la región al panel (lo recorta físicamente)
            Titulo.Region = New Region(path)

            ' 🔹 Rellenar
            Using brush As New SolidBrush(AppColors._cFondoSemi)
                e.Graphics.FillPath(brush, path)
            End Using

            ' 🔹 Dibujar borde
            Using pen As New Pen(AppColors._cBlanco, 2)
                e.Graphics.DrawPath(pen, path)
            End Using
        End Using
    End Sub

#End Region

End Class

