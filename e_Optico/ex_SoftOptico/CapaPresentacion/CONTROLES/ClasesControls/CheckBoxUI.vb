Public Class CheckBoxUI
    Inherits Control

    Private _Checked As Boolean = False
    Private _CheckedColor As Color = Color.SeaGreen
    Private _UncheckedColor As Color = Color.Gray
    Private _BorderColor As Color = Color.DarkGray
    Private _AnimationProgress As Single = 0F
    Private _AnimationTimer As Timer
    Private _Texto As String = "Etiqueta"

    Public Property Texto As String
        Get
            Return _Texto
        End Get
        Set(value As String)
            _Texto = value
            Invalidate()
        End Set
    End Property


    Public Property CheckedColor As Color
        Get
            Return _CheckedColor
        End Get
        Set(value As Color)
            _CheckedColor = value : Invalidate()
        End Set
    End Property

    Public Property UncheckedColor As Color
        Get
            Return _UncheckedColor
        End Get
        Set(value As Color)
            _UncheckedColor = value : Invalidate()
        End Set
    End Property

    Public Property BorderColor As Color
        Get
            Return _BorderColor
        End Get
        Set(value As Color)
            _BorderColor = value : Invalidate()
        End Set
    End Property

    Public Property Checked As Boolean
        Get
            Return _Checked
        End Get
        Set(value As Boolean)
            If _Checked <> value Then
                _Checked = value
                RaiseEvent CheckedChanged(Me, EventArgs.Empty)
                _AnimationProgress = 0F
                _AnimationTimer.Start()
                Invalidate()
            End If
        End Set
    End Property

    Public Event CheckedChanged(sender As Object, e As EventArgs)

    Public Sub New()
        Me.Size = New Size(124, 24)
        Me.DoubleBuffered = True
        Me.Cursor = Cursors.Hand
        _AnimationTimer = New Timer() With {.Interval = 15}
        AddHandler _AnimationTimer.Tick, AddressOf AnimateSelection
    End Sub

    Private Sub AnimateSelection(sender As Object, e As EventArgs)
        _AnimationProgress += 0.1F
        If _AnimationProgress >= 1.0F Then
            _AnimationTimer.Stop()
            _AnimationProgress = 1.0F
        End If
        Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(pe As PaintEventArgs)
        Dim g = pe.Graphics
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        ' Base rectangle
        Dim rect = New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)
        Using b As New SolidBrush(If(Checked, CheckedColor, UncheckedColor))
            g.FillRectangle(b, rect)
        End Using

        ' Border
        Using p As New Pen(BorderColor, 1.5F)
            g.DrawRectangle(p, rect)
        End Using

        ' Check mark animation
        If Checked Then
            Dim thickness = 2.0F
            Dim checkPath As New Drawing2D.GraphicsPath()
            Dim scale = _AnimationProgress

            Dim x1 = CInt(Me.Width * 0.25)
            Dim y1 = CInt(Me.Height * 0.5)
            Dim x2 = CInt(Me.Width * 0.45)
            Dim y2 = CInt(Me.Height * 0.7)
            Dim x3 = CInt(Me.Width * 0.75)
            Dim y3 = CInt(Me.Height * 0.3)

            checkPath.AddLine(x1, y1, x2 * scale, y2 * scale)
            checkPath.AddLine(x2 * scale, y2 * scale, x3 * scale, y3 * scale)

            Using p As New Pen(Color.White, thickness)
                g.DrawPath(p, checkPath)
            End Using
        End If

        Using f As New Font("Segoe UI", 9.5F)
            Dim textoPos = New Point(Me.Height + 6, (Me.Height \ 2) - (f.Height \ 2))
            g.DrawString(_Texto, f, Brushes.Black, textoPos)
        End Using

    End Sub

    Protected Overrides Sub OnClick(e As EventArgs)
        MyBase.OnClick(e)
        Me.Checked = Not Me.Checked
    End Sub
End Class


'Imports System.ComponentModel
'Imports System.Drawing
'Imports System.Drawing.Drawing2D

'Public Class CheckBoxUI
'    Inherits CheckBox

'    Private _borderRadius As Integer = 12
'    Private _shadowColor As Color = Color.FromArgb(30, Color.Black)
'    Private _checkColor As Color = Color.DeepSkyBlue
'    Private _textColor As Color = Color.Black
'    Private sombraActiva As Integer = 0
'    Private WithEvents timerSombra As New Timer()

'    Public Sub New()
'        Me.DoubleBuffered = True
'        Me.Font = New Font("Century Gothic", 11, FontStyle.Regular)
'        Me.Size = New Size(180, 36)
'        Me.Padding = New Padding(26, 0, 0, 0)
'        Me.AutoSize = False
'        Me.TextAlign = ContentAlignment.MiddleLeft
'        timerSombra.Interval = 30
'    End Sub

'    <Category("UI Estilo")>
'    Public Property BorderRadius As Integer
'        Get
'            Return _borderRadius
'        End Get
'        Set(value As Integer)
'            _borderRadius = value
'            Me.Invalidate()
'        End Set
'    End Property

'    <Category("UI Estilo")>
'    Public Property ShadowColor As Color
'        Get
'            Return _shadowColor
'        End Get
'        Set(value As Color)
'            _shadowColor = value
'            Me.Invalidate()
'        End Set
'    End Property

'    <Category("UI Estilo")>
'    Public Property CheckColor As Color
'        Get
'            Return _checkColor
'        End Get
'        Set(value As Color)
'            _checkColor = value
'            Me.Invalidate()
'        End Set
'    End Property

'    <Category("UI Estilo")>
'    Public Property TextColor As Color
'        Get
'            Return _textColor
'        End Get
'        Set(value As Color)
'            _textColor = value
'            Me.ForeColor = value
'            Me.Invalidate()
'        End Set
'    End Property

'    Public Sub AplicarEstiloDesdeTema()
'        Me.CheckColor = ThemeManagerUI.ColorPrimario
'        Me.TextColor = ThemeManagerUI.ColorTextoBase
'        Me.ShadowColor = ThemeManagerUI.ColorSombra
'        Me.Invalidate()
'    End Sub

'    Protected Overrides Sub OnCheckedChanged(e As EventArgs)
'        MyBase.OnCheckedChanged(e)
'        If Me.Checked Then
'            sombraActiva = 0
'            timerSombra.Start()
'        Else
'            sombraActiva = 0
'            Me.Invalidate()
'        End If
'    End Sub

'    Private Sub timerSombra_Tick(sender As Object, e As EventArgs) Handles timerSombra.Tick
'        If sombraActiva < 10 Then
'            sombraActiva += 1
'            Me.Invalidate()
'        Else
'            timerSombra.Stop()
'        End If
'    End Sub

'    Protected Overrides Sub OnPaint(e As PaintEventArgs)
'        MyBase.OnPaint(e)
'        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

'        Dim centerY = Me.Height \ 2
'        Dim centerX = 12
'        Dim sizeBox = 20
'        Dim rectBox = New Rectangle(centerX - sizeBox \ 2, centerY - sizeBox \ 2, sizeBox, sizeBox)
'        Dim rectSombra = New Rectangle(rectBox.X - sombraActiva, rectBox.Y - sombraActiva, rectBox.Width + sombraActiva * 2, rectBox.Height + sombraActiva * 2)

'        ' Sombra orbital creciente
'        Using sombraBrush As New SolidBrush(_shadowColor)
'            e.Graphics.FillEllipse(sombraBrush, rectSombra)
'        End Using

'        ' Contorno orbital
'        Using penBox As New Pen(_checkColor, 1.5F)
'            Dim path = RoundedPath(rectBox, _borderRadius)
'            e.Graphics.DrawPath(penBox, path)
'        End Using

'        ' Relleno si está marcado
'        If Me.Checked Then
'            Using rellenoBrush As New SolidBrush(_checkColor)
'                Dim innerBox = New Rectangle(rectBox.X + 4, rectBox.Y + 4, rectBox.Width - 8, rectBox.Height - 8)
'                e.Graphics.FillEllipse(rellenoBrush, innerBox)
'            End Using
'        End If

'        ' Texto orbital
'        Dim textRect = New Rectangle(32, 0, Me.Width - 40, Me.Height)
'        TextRenderer.DrawText(e.Graphics, Me.Text, Me.Font, textRect, _textColor, TextFormatFlags.Left Or TextFormatFlags.VerticalCenter)
'    End Sub

'    Private Function RoundedPath(rect As Rectangle, radius As Integer) As GraphicsPath
'        Dim path As New GraphicsPath()
'        path.StartFigure()
'        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90)
'        path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90)
'        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
'        path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90)
'        path.CloseFigure()
'        Return path
'    End Function

'    'Como usarlo:

'    ' Agrega el control CheckBoxUI a tu formulario o contenedor deseado.
'    ' Dim chkActivo As New CheckBoxUI()
'    'chkActivo.Text = "Activar módulo"
'    'chkActivo.Checked = False
'    'Me.Controls.Add(chkActivo)



'End Class
