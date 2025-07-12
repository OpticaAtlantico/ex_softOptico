Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class CheckBoxUI
    Inherits CheckBox

    Private _borderRadius As Integer = 12
    Private _shadowColor As Color = Color.FromArgb(30, Color.Black)
    Private _checkColor As Color = Color.DeepSkyBlue
    Private _textColor As Color = Color.Black
    Private sombraActiva As Integer = 0
    Private WithEvents timerSombra As New Timer()

    Public Sub New()
        Me.DoubleBuffered = True
        Me.Font = New Font("Century Gothic", 11, FontStyle.Regular)
        Me.Size = New Size(180, 36)
        Me.Padding = New Padding(26, 0, 0, 0)
        Me.AutoSize = False
        Me.TextAlign = ContentAlignment.MiddleLeft
        timerSombra.Interval = 30
    End Sub

    <Category("UI Estilo")>
    Public Property BorderRadius As Integer
        Get
            Return _borderRadius
        End Get
        Set(value As Integer)
            _borderRadius = value
            Me.Invalidate()
        End Set
    End Property

    <Category("UI Estilo")>
    Public Property ShadowColor As Color
        Get
            Return _shadowColor
        End Get
        Set(value As Color)
            _shadowColor = value
            Me.Invalidate()
        End Set
    End Property

    <Category("UI Estilo")>
    Public Property CheckColor As Color
        Get
            Return _checkColor
        End Get
        Set(value As Color)
            _checkColor = value
            Me.Invalidate()
        End Set
    End Property

    <Category("UI Estilo")>
    Public Property TextColor As Color
        Get
            Return _textColor
        End Get
        Set(value As Color)
            _textColor = value
            Me.ForeColor = value
            Me.Invalidate()
        End Set
    End Property

    Public Sub AplicarEstiloDesdeTema()
        Me.CheckColor = ThemeManagerUI.ColorPrimario
        Me.TextColor = ThemeManagerUI.ColorTextoBase
        Me.ShadowColor = ThemeManagerUI.ColorSombra
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnCheckedChanged(e As EventArgs)
        MyBase.OnCheckedChanged(e)
        If Me.Checked Then
            sombraActiva = 0
            timerSombra.Start()
        Else
            sombraActiva = 0
            Me.Invalidate()
        End If
    End Sub

    Private Sub timerSombra_Tick(sender As Object, e As EventArgs) Handles timerSombra.Tick
        If sombraActiva < 10 Then
            sombraActiva += 1
            Me.Invalidate()
        Else
            timerSombra.Stop()
        End If
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        Dim centerY = Me.Height \ 2
        Dim centerX = 12
        Dim sizeBox = 20
        Dim rectBox = New Rectangle(centerX - sizeBox \ 2, centerY - sizeBox \ 2, sizeBox, sizeBox)
        Dim rectSombra = New Rectangle(rectBox.X - sombraActiva, rectBox.Y - sombraActiva, rectBox.Width + sombraActiva * 2, rectBox.Height + sombraActiva * 2)

        ' Sombra orbital creciente
        Using sombraBrush As New SolidBrush(_shadowColor)
            e.Graphics.FillEllipse(sombraBrush, rectSombra)
        End Using

        ' Contorno orbital
        Using penBox As New Pen(_checkColor, 1.5F)
            Dim path = RoundedPath(rectBox, _borderRadius)
            e.Graphics.DrawPath(penBox, path)
        End Using

        ' Relleno si está marcado
        If Me.Checked Then
            Using rellenoBrush As New SolidBrush(_checkColor)
                Dim innerBox = New Rectangle(rectBox.X + 4, rectBox.Y + 4, rectBox.Width - 8, rectBox.Height - 8)
                e.Graphics.FillEllipse(rellenoBrush, innerBox)
            End Using
        End If

        ' Texto orbital
        Dim textRect = New Rectangle(32, 0, Me.Width - 40, Me.Height)
        TextRenderer.DrawText(e.Graphics, Me.Text, Me.Font, textRect, _textColor, TextFormatFlags.Left Or TextFormatFlags.VerticalCenter)
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

    'Como usarlo:

    ' Agrega el control CheckBoxUI a tu formulario o contenedor deseado.
    ' Dim chkActivo As New CheckBoxUI()
    'chkActivo.Text = "Activar módulo"
    'chkActivo.Checked = False
    'Me.Controls.Add(chkActivo)



End Class
