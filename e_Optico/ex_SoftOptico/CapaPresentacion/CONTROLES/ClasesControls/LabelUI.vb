Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports FontAwesome.Sharp

Public Class LabelUI
    Inherits Control

    Public Enum EstiloBootstrap
        Primary
        Success
        Danger
        Warning
        Info
        Dark
    End Enum

    ' 📦 Propiedades orbitales
    <Category("Contenido Orbital")>
    Public Property Texto As String = "Mensaje informativo"

    <Category("Contenido Orbital")>
    Public Property Icono As IconChar = IconChar.InfoCircle

    <Category("Estilo Orbital")>
    Public Property RadioBorde As Integer = 6

    <Category("Estilo Orbital")>
    Public Property BloquearColorFondo As Boolean = True

    <Category("Estilo Orbital")>
    Public Property EstiloLabel As EstiloBootstrap
        Get
            Return _estiloLabel
        End Get
        Set(value As EstiloBootstrap)
            _estiloLabel = value
            AplicarEstilo(value)
            Me.Invalidate()
        End Set
    End Property
    Private _estiloLabel As EstiloBootstrap = EstiloBootstrap.Info

    ' 🛡 Fondo interno desacoplado del BackColor
    <Browsable(False)>
    Public Property ColorInternoFondo As Color
        Get
            Return _colorInterno
        End Get
        Set(value As Color)
            _colorInterno = value
            Me.Invalidate()
        End Set
    End Property
    Private _colorInterno As Color = Color.FromArgb(208, 233, 242) ' Info por defecto

    Private iconControl As New IconPictureBox()

    Public Sub New()
        Me.Size = New Size(280, 38)
        Me.Font = New Font("Century Gothic", 10, FontStyle.Regular)
        Me.DoubleBuffered = True

        ' ✅ Activar soporte de transparencia visual
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor Or
                    ControlStyles.UserPaint Or
                    ControlStyles.AllPaintingInWmPaint Or
                    ControlStyles.OptimizedDoubleBuffer, True)
        Me.BackColor = Color.Transparent

        ' ⭐ Ícono informativo
        iconControl.Size = New Size(20, 20)
        iconControl.SizeMode = PictureBoxSizeMode.CenterImage
        iconControl.BackColor = Color.Transparent
        iconControl.Enabled = False
        Me.Controls.Add(iconControl)

        Me.Padding = New Padding(10, 6, 10, 6)
        AplicarEstilo(_estiloLabel)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim g = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias

        Dim rect = New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)
        Using path = BordeRedondeado(rect, RadioBorde)
            ' 🎨 Pintar fondo orbital
            Using brush As New SolidBrush(ColorInternoFondo)
                g.FillPath(brush, path)
            End Using
            ' 🔲 Borde visible
            Using pen As New Pen(Color.FromArgb(180, Me.ForeColor), 1)
                g.DrawPath(pen, path)
            End Using
        End Using

        ' ✏️ Texto
        Dim txtX = iconControl.Right + 10
        Dim txtY = (Me.Height - TextRenderer.MeasureText(Texto, Me.Font).Height) \ 2
        Using brush As New SolidBrush(Me.ForeColor)
            g.DrawString(Texto, Me.Font, brush, txtX, txtY)
        End Using

        ' 🎯 Posicionar ícono
        iconControl.IconChar = Icono
        iconControl.IconColor = Me.ForeColor
        iconControl.Location = New Point(10, (Me.Height - iconControl.Height) \ 2)
    End Sub

    Private Sub AplicarEstilo(estilo As EstiloBootstrap)
        Select Case estilo
            Case EstiloBootstrap.Primary
                ColorInternoFondo = Color.FromArgb(217, 235, 255)
                Me.ForeColor = Color.FromArgb(33, 150, 243)
                Me.Icono = IconChar.InfoCircle

            Case EstiloBootstrap.Success
                ColorInternoFondo = Color.FromArgb(223, 240, 216)
                Me.ForeColor = Color.FromArgb(76, 175, 80)
                Me.Icono = IconChar.CheckCircle

            Case EstiloBootstrap.Danger
                ColorInternoFondo = Color.FromArgb(250, 221, 221)
                Me.ForeColor = Color.FromArgb(244, 67, 54)
                Me.Icono = IconChar.TimesCircle

            Case EstiloBootstrap.Warning
                ColorInternoFondo = Color.FromArgb(255, 243, 205)
                Me.ForeColor = Color.FromArgb(255, 193, 7)
                Me.Icono = IconChar.ExclamationTriangle

            Case EstiloBootstrap.Info
                ColorInternoFondo = Color.FromArgb(208, 233, 242)
                Me.ForeColor = Color.FromArgb(0, 188, 212)
                Me.Icono = IconChar.InfoCircle

            Case EstiloBootstrap.Dark
                ColorInternoFondo = Color.FromArgb(230, 230, 230)
                Me.ForeColor = Color.FromArgb(66, 66, 66)
                Me.Icono = IconChar.QuestionCircle
        End Select
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

    Protected Overrides Sub OnBackColorChanged(e As EventArgs)
        MyBase.OnBackColorChanged(e)
        If BloquearColorFondo Then Me.BackColor = Color.Transparent
    End Sub

    Protected Overrides Sub OnParentChanged(e As EventArgs)
        MyBase.OnParentChanged(e)
        If BloquearColorFondo Then Me.BackColor = Color.Transparent
    End Sub
End Class
