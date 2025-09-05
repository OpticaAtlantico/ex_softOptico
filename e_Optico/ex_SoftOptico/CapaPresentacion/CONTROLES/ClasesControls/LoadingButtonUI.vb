Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports FontAwesome.Sharp

Public Class LoadingButtonUI
    Inherits Control

    Private _estadoProcesando As Boolean = False
    Private hovering As Boolean = False
    Private presionado As Boolean = False
    Private spinnerAngle As Integer = 0

    Private clickTimer As New Timer With {.Interval = 100}
    Private spinnerTimer As New Timer With {.Interval = 80}
    Private iconControl As New IconPictureBox()

#Region "PROPIEDADES"
    ' 📦 Propiedades principales
    <Category("Contenido UI")> Public Property Texto As String = "Guardar..."
    <Category("Contenido UI")> Public Property Icono As IconChar = IconChar.Save

    <Category("Estilo UI")> Public Property ColorBase As Color = AppColors._cBaseInfo
    <Category("Estilo UI")> Public Property ColorHover As Color = AppColors._cHoverInfo
    <Category("Estilo UI")> Public Property ColorPresionado As Color = AppColors._cPresionadoInfo
    <Category("Estilo UI")> Public Property ColorTexto As Color = AppColors._cBlanco
    <Category("Estilo UI")> Public Property RadioBorde As Integer = 8

    <Browsable(False)> Public Property ColorInternoFondo As Color = AppColors._cBaseSuccess

    ' 🔄 Spinner
    <Category("Spinner UI")> Public Property MostrarSpinner As Boolean = False
    <Category("Spinner UI")> Public Property SpinnerColor As Color = AppColors._cBlanco

    ' ⚙️ Estado de procesamiento
    <Category("Estado")>
    Public Property EstadoProcesando As Boolean
        Get
            Return _estadoProcesando
        End Get
        Set(value As Boolean)
            _estadoProcesando = value
            MostrarSpinner = value
            Me.Enabled = Not value
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

        iconControl.Size = New Size(24, 24)
        iconControl.SizeMode = PictureBoxSizeMode.CenterImage
        iconControl.BackColor = Color.Transparent
        iconControl.Enabled = False
        Me.Controls.Add(iconControl)

        AddHandler clickTimer.Tick, Sub()
                                        presionado = False
                                        clickTimer.Stop()
                                        Me.Invalidate()
                                    End Sub

        AddHandler spinnerTimer.Tick, Sub()
                                          spinnerAngle = (spinnerAngle + 30) Mod 360
                                          Me.Invalidate()
                                      End Sub
        spinnerTimer.Start()

        ColorInternoFondo = ColorBase
    End Sub
#End Region

#Region "DIBUJO"
    Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
        If Me.Parent IsNot Nothing Then
            Using b As New SolidBrush(Me.Parent.BackColor)
                e.Graphics.FillRectangle(b, Me.ClientRectangle)
            End Using
        Else
            MyBase.OnPaintBackground(e)
        End If
    End Sub
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim g = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.PixelOffsetMode = PixelOffsetMode.HighQuality

        Dim rect = New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)
        Using path = BordeRedondeado(rect, RadioBorde)
            Dim baseColor = If(hovering, ColorHover, ColorInternoFondo)
            If presionado Then baseColor = ColorPresionado
            Using brush = New SolidBrush(baseColor)
                g.FillPath(brush, path)
            End Using
        End Using

        Dim txtY = (Me.Height - Me.Font.Height) \ 2
        Dim txtX = If(MostrarSpinner, 40, 35)
        Using txtBrush As New SolidBrush(ColorTexto)
            g.DrawString(Texto, Me.Font, txtBrush, txtX, txtY)
        End Using

        iconControl.IconChar = Icono
        iconControl.IconColor = ColorTexto
        iconControl.Visible = Not MostrarSpinner
        iconControl.Location = New Point(Me.Width - iconControl.Width - 10, (Me.Height - iconControl.Height) \ 2)

        If MostrarSpinner Then
            Dim center = New Point(20, Me.Height \ 2)
            Dim radius = 6
            Dim segments = 8

            For i = 0 To segments - 1
                Dim alpha = 255 - i * 32
                Dim angleStep = (spinnerAngle + i * 360 \ segments) * Math.PI / 180
                Dim x = center.X + radius * Math.Cos(angleStep)
                Dim y = center.Y + radius * Math.Sin(angleStep)

                Using b As New SolidBrush(Color.FromArgb(alpha, SpinnerColor))
                    g.FillEllipse(b, CSng(x - 2), CSng(y - 2), 4, 4)
                End Using
            Next
        End If
    End Sub
    Private Function BordeRedondeado(rect As Rectangle, radio As Integer) As GraphicsPath
        Dim path As New GraphicsPath()
        path.AddArc(rect.X, rect.Y, radio, radio, 180, 90)
        path.AddArc(rect.Right - radio, rect.Y, radio, radio, 270, 90)
        path.AddArc(rect.Right - radio, rect.Bottom - radio, radio, radio, 0, 90)
        path.AddArc(rect.X, rect.Bottom - radio, radio, radio, 90, 90)
        path.CloseFigure()
        Return path
    End Function
#End Region

#Region "EVENTO INTERNO"
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
