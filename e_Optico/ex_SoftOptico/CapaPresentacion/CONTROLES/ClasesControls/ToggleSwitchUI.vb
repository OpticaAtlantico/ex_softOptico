Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class ToggleSwitchUI
    Inherits Control

    Private _isChecked As Boolean = False
    Private _backgroundOn As Color = Color.SeaGreen
    Private _backgroundOff As Color = Color.Silver
    Private _switchColor As Color = Color.White
    Private _borderRadius As Integer = 16
    Private _text As String = "Estado"
    Private _textColor As Color = Color.Black

    Private switchPosX As Single = 4
    Private targetPosX As Single = 4
    Private WithEvents timerAnimacion As New Timer()

    Public Sub New()
        Me.DoubleBuffered = True
        Me.Font = New Font("Century Gothic", 11, FontStyle.Regular)
        Me.Size = New Size(120, 32)
        Me.Cursor = Cursors.Hand
        timerAnimacion.Interval = 10
    End Sub

    <Category("UI Estilo")>
    Public Property BackgroundOn As Color
        Get
            Return _backgroundOn
        End Get
        Set(value As Color)
            _backgroundOn = value
            Me.Invalidate()
        End Set
    End Property

    <Category("UI Estilo")>
    Public Property BackgroundOff As Color
        Get
            Return _backgroundOff
        End Get
        Set(value As Color)
            _backgroundOff = value
            Me.Invalidate()
        End Set
    End Property

    <Category("UI Estilo")>
    Public Property SwitchColor As Color
        Get
            Return _switchColor
        End Get
        Set(value As Color)
            _switchColor = value
            Me.Invalidate()
        End Set
    End Property

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
    Public Property EstadoTexto As String
        Get
            Return _text
        End Get
        Set(value As String)
            _text = value
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
            Me.Invalidate()
        End Set
    End Property

    Public Property Checked As Boolean
        Get
            Return _isChecked
        End Get
        Set(value As Boolean)
            If _isChecked <> value Then
                _isChecked = value
                targetPosX = If(_isChecked, 30, 4)
                timerAnimacion.Start()
                OnCheckedChanged(EventArgs.Empty)
            End If
        End Set
    End Property

    Public Event CheckedChanged As EventHandler
    Protected Overridable Sub OnCheckedChanged(e As EventArgs)
        RaiseEvent CheckedChanged(Me, e)
    End Sub

    Public Sub AplicarEstiloDesdeTema()
        Me.BackgroundOn = ThemeManagerUI.ColorPrimario
        Me.TextColor = ThemeManagerUI.ColorTextoBase
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnClick(e As EventArgs)
        MyBase.OnClick(e)
        Me.Checked = Not Me.Checked
    End Sub

    Private Sub timerAnimacion_Tick(sender As Object, e As EventArgs) Handles timerAnimacion.Tick
        If Math.Abs(switchPosX - targetPosX) < 1 Then
            switchPosX = targetPosX
            timerAnimacion.Stop()
        Else
            switchPosX += (targetPosX - switchPosX) * 0.25F
            Me.Invalidate()
        End If
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        Dim fondoColor = If(_isChecked, _backgroundOn, _backgroundOff)
        Dim rect = New Rectangle(0, 0, 50, Me.Height - 1)
        Dim path = RoundedPath(rect, _borderRadius)

        Using fondoBrush As New SolidBrush(fondoColor)
            e.Graphics.FillPath(fondoBrush, path)
        End Using

        Dim switchRect = New Rectangle(CInt(switchPosX), rect.Top + 4, 16, Me.Height - 8)
        Using switchBrush As New SolidBrush(_switchColor)
            e.Graphics.FillEllipse(switchBrush, switchRect)
        End Using

        Dim textRect = New Rectangle(60, 0, Me.Width - 65, Me.Height)
        TextRenderer.DrawText(e.Graphics, _text, Me.Font, textRect, _textColor, TextFormatFlags.Left Or TextFormatFlags.VerticalCenter)
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

    'Como se usa

    ' Dim interruptorModo As New ToggleSwitchUI()
    'interruptorModo.EstadoTexto = "Modo Experto"
    'Me.Controls.Add(interruptorModo)

End Class