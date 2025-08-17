Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports FontAwesome.Sharp

Public Class CommandButtonUI
    Inherits Control
    Public Enum EstiloBootstrap
        Primary
        Success
        Danger
        Warning
        Info
        Dark
    End Enum

    ' 🧩 Propiedades públicas
    <Category("Apariencia Orbital")>
    Public Property Texto As String = "Aceptar"

    <Category("Apariencia Orbital")>
    Public Property Icono As IconChar = IconChar.Check

    <Category("Apariencia Orbital")>
    Public Property ColorBase As Color = Color.FromArgb(33, 150, 243)

    <Category("Apariencia Orbital")>
    Public Property ColorHover As Color = Color.FromArgb(30, 136, 229)

    <Category("Apariencia Orbital")>
    Public Property ColorPresionado As Color = Color.FromArgb(25, 118, 210)

    <Category("Apariencia Orbital")>
    Public Property ColorTexto As Color = Color.White

    <Category("Apariencia Orbital")>
    Public Property AnimarHover As Boolean = True

    <Category("Apariencia Orbital")>
    Public Property RadioBorde As Integer = 8

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
    Private _colorInternoFondo As Color = Color.FromArgb(33, 150, 243)

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
    Private _estiloBoton As EstiloBootstrap = EstiloBootstrap.Primary

    Private hovering As Boolean = False
    Private presionado As Boolean = False
    Private clickTimer As New Timer With {.Interval = 100}
    Private iconControl As New IconPictureBox()

    Public Sub New()
        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor Or
                    ControlStyles.UserPaint Or
                    ControlStyles.AllPaintingInWmPaint Or
                    ControlStyles.OptimizedDoubleBuffer, True)
        Me.UpdateStyles()
        Me.Size = New Size(160, 45)
        Me.Font = New Font("Century Gothic", 10, FontStyle.Bold)
        Me.Cursor = Cursors.Hand

        Me.SetStyle(ControlStyles.SupportsTransparentBackColor Or
                    ControlStyles.AllPaintingInWmPaint Or
                    ControlStyles.UserPaint Or
                    ControlStyles.OptimizedDoubleBuffer, True)
        Me.BackColor = Color.Transparent

        iconControl.Size = New Size(30, 30)
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

    Private Sub AplicarEstilo(estilo As EstiloBootstrap)
        Select Case estilo
            Case EstiloBootstrap.Primary
                ColorBase = Color.FromArgb(33, 150, 243)
                ColorHover = Color.FromArgb(30, 136, 229)
                ColorPresionado = Color.FromArgb(25, 118, 210)
                ColorTexto = Color.White
                Icono = IconChar.Bolt
                ColorInternoFondo = ColorBase

            Case EstiloBootstrap.Success
                ColorBase = Color.FromArgb(76, 175, 80)
                ColorHover = Color.FromArgb(67, 160, 71)
                ColorPresionado = Color.FromArgb(56, 142, 60)
                ColorTexto = Color.White
                Icono = IconChar.CheckCircle
                ColorInternoFondo = ColorBase

            Case EstiloBootstrap.Danger
                ColorBase = Color.FromArgb(244, 67, 54)
                ColorHover = Color.FromArgb(229, 57, 53)
                ColorPresionado = Color.FromArgb(211, 47, 47)
                ColorTexto = Color.White
                Icono = IconChar.TrashAlt
                ColorInternoFondo = ColorBase

            Case EstiloBootstrap.Warning
                ColorBase = Color.FromArgb(255, 193, 7)
                ColorHover = Color.FromArgb(255, 179, 0)
                ColorPresionado = Color.FromArgb(255, 160, 0)
                ColorTexto = Color.Black
                Icono = IconChar.ExclamationTriangle
                ColorInternoFondo = ColorBase

            Case EstiloBootstrap.Info
                ColorBase = Color.FromArgb(0, 188, 212)
                ColorHover = Color.FromArgb(0, 172, 193)
                ColorPresionado = Color.FromArgb(0, 151, 167)
                ColorTexto = Color.White
                Icono = IconChar.InfoCircle
                ColorInternoFondo = ColorBase

            Case EstiloBootstrap.Dark
                ColorBase = Color.FromArgb(66, 66, 66)
                ColorHover = Color.FromArgb(55, 55, 55)
                ColorPresionado = Color.FromArgb(40, 40, 40)
                ColorTexto = Color.White
                Icono = IconChar.Moon
                ColorInternoFondo = ColorBase
        End Select
    End Sub

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
End Class


'''miBotonUI.EstiloBoton = EstiloBootstrap.Success
