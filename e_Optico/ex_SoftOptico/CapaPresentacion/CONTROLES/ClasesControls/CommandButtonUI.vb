Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports FontAwesome.Sharp

Public Class CommandButtonUI
    Inherits Control

    Private _colorInternoFondo As Color = AppColors._cBasePrimary
    Private _estiloBoton As EstiloBootstrap = EstiloBootstrap.Primary

    Private hovering As Boolean = False
    Private presionado As Boolean = False
    Private clickTimer As New Timer With {.Interval = 100}
    Private iconControl As New IconPictureBox()

    Public Enum EstiloBootstrap
        Primary
        Success
        Danger
        Warning
        Info
        Dark
    End Enum

#Region "PROPIEDADES"
    ' 🧩 Propiedades públicas
    <Category("Apariencia Orbital")>
    Public Property Texto As String = "Aceptar"

    <Category("Apariencia Orbital")>
    Public Property Icono As IconChar = IconChar.Check

    <Category("Apariencia Orbital")>
    Public Property ColorBase As Color = AppColors._cBasePrimary

    <Category("Apariencia Orbital")>
    Public Property ColorHover As Color = AppColors._cHoverPrimary

    <Category("Apariencia Orbital")>
    Public Property ColorPresionado As Color = AppColors._cPresionadoPrimary

    <Category("Apariencia Orbital")>
    Public Property ColorTexto As Color = AppColors._cBlancoOscuro

    <Category("Apariencia Orbital")>
    Public Property AnimarHover As Boolean = True

    <Category("Apariencia Orbital")>
    Public Property RadioBorde As Integer = AppLayout.BorderRadiusStandar

    <Category("Estilo Orbital")>
    Public Property ColorInternoFondo As Color
        Get
            Return _colorInternoFondo
        End Get
        Set(value As Color)
            _colorInternoFondo = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Estilo Bootstrap"), Description("Estilo visual tipo Bootstrap para el botón")>
    Public Property EstiloBoton As EstiloBootstrap
        Get
            Return _estiloBoton
        End Get
        Set(value As EstiloBootstrap)
            _estiloBoton = value
            AplicarEstilo(value)
            Me.Invalidate()
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

        Me.Size = New Size(160, 45)
        Me.Font = New Font(AppFonts.Century, AppFonts.SizeSmall, AppFonts.Bold)
        Me.Cursor = Cursors.Hand
        Me.BackColor = Color.Transparent

        iconControl.Size = New Size(AppLayout.IconLarge, AppLayout.IconLarge)
        iconControl.SizeMode = PictureBoxSizeMode.CenterImage
        iconControl.BackColor = Color.Transparent
        iconControl.Enabled = False
        Me.Controls.Add(iconControl)

        AddHandler clickTimer.Tick, Sub()
                                        presionado = False
                                        clickTimer.Stop()
                                        Me.Invalidate()
                                    End Sub

        AplicarEstilo(_estiloBoton)
    End Sub
#End Region

#Region "DIBUJO"
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim g = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.PixelOffsetMode = PixelOffsetMode.HighQuality

        Dim rect = New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)
        Using path = BordeRedondeado(rect, RadioBorde)
            Dim baseColor = If(hovering AndAlso AnimarHover, ColorHover, ColorBase)
            If presionado Then baseColor = ColorPresionado
            Using brush = New SolidBrush(baseColor)
                g.FillPath(brush, path)
            End Using
        End Using

        Dim txtSize = g.MeasureString(Texto, Me.Font)
        Dim txtX = 10
        Dim txtY = (Me.Height - txtSize.Height) / 2
        Using txtBrush = New SolidBrush(ColorTexto)
            g.DrawString(Texto, Me.Font, txtBrush, txtX, txtY)
        End Using

        iconControl.IconChar = Icono
        iconControl.IconColor = ColorTexto
        iconControl.Location = New Point(Me.Width - iconControl.Width - 10, (Me.Height - iconControl.Height) \ 2)
    End Sub

    Private Function BordeRedondeado(rect As Rectangle, radio As Integer) As GraphicsPath
        Dim path = New GraphicsPath()
        path.AddArc(rect.X, rect.Y, radio, radio, 180, 90)
        path.AddArc(rect.Right - radio, rect.Y, radio, radio, 270, 90)
        path.AddArc(rect.Right - radio, rect.Bottom - radio, radio, radio, 0, 90)
        path.AddArc(rect.X, rect.Bottom - radio, radio, radio, 90, 90)
        path.CloseFigure()
        Return path
    End Function
#End Region

#Region "PROCEDIMIENTO"
    Private Sub AplicarEstilo(estilo As EstiloBootstrap)
        Select Case estilo
            Case EstiloBootstrap.Primary
                ColorBase = AppColors._cBasePrimary
                ColorHover = AppColors._cHoverPrimary
                ColorPresionado = AppColors._cPresionadoPrimary
                ColorTexto = AppColors._cTextoPrimary
                Icono = IconChar.Bolt
                ColorInternoFondo = ColorBase

            Case EstiloBootstrap.Success
                ColorBase = AppColors._cBaseSuccess
                ColorHover = AppColors._cHoverSuccess
                ColorPresionado = AppColors._cPresionadoSuccess
                ColorTexto = AppColors._cTextoSuccess
                Icono = IconChar.CheckCircle
                ColorInternoFondo = ColorBase

            Case EstiloBootstrap.Danger
                ColorBase = AppColors._cBaseDanger
                ColorHover = AppColors._cHoverDanger
                ColorPresionado = AppColors._cPresionadoDanger
                ColorTexto = AppColors._cTextoDanger
                Icono = IconChar.TrashAlt
                ColorInternoFondo = ColorBase

            Case EstiloBootstrap.Warning
                ColorBase = AppColors._cBaseWarning
                ColorHover = AppColors._cHoverWarning
                ColorPresionado = AppColors._cPresionadoWarning
                ColorTexto = AppColors._cTextoWarning
                Icono = IconChar.ExclamationTriangle
                ColorInternoFondo = ColorBase

            Case EstiloBootstrap.Info
                ColorBase = AppColors._cBaseInfo
                ColorHover = AppColors._cHoverInfo
                ColorPresionado = AppColors._cPresionadoInfo
                ColorTexto = AppColors._cTextoInfo
                Icono = IconChar.InfoCircle
                ColorInternoFondo = ColorBase

            Case EstiloBootstrap.Dark
                ColorBase = AppColors._cBaseDark
                ColorHover = AppColors._cHoverDark
                ColorPresionado = AppColors._cPresionadoDark
                ColorTexto = AppColors._cTextoDark
                Icono = IconChar.Moon
                ColorInternoFondo = ColorBase
        End Select
    End Sub
#End Region

#Region "EVENTOS INTERNOS"
    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        hovering = True
        Me.Invalidate()
        MyBase.OnMouseEnter(e)
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        hovering = False
        Me.Invalidate()
        MyBase.OnMouseLeave(e)
    End Sub

    Protected Overrides Sub OnClick(e As EventArgs)
        presionado = True
        clickTimer.Start()
        Me.Invalidate()
        MyBase.OnClick(e)
    End Sub
#End Region

End Class

