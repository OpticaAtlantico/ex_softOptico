Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class LoadingSpinnerUI
    Inherits Control

    Private _colorSpinner As Color = ThemeManagerUI.ColorPrimario
    Private _sizeSpinner As Integer = 36
    Private contadorAngulo As Integer = 0
    Private WithEvents timerAnimacion As New Timer()

    Public Sub New()
        Me.DoubleBuffered = True
        Me.Size = New Size(_sizeSpinner + 10, _sizeSpinner + 10)
        Me.BackColor = Color.Transparent
        timerAnimacion.Interval = 50
        timerAnimacion.Start()
    End Sub

    <Category("UI Estilo")>
    Public Property ColorSpinner As Color
        Get
            Return _colorSpinner
        End Get
        Set(value As Color)
            _colorSpinner = value
            Me.Invalidate()
        End Set
    End Property

    <Category("UI Estilo")>
    Public Property SizeSpinner As Integer
        Get
            Return _sizeSpinner
        End Get
        Set(value As Integer)
            _sizeSpinner = value
            Me.Size = New Size(value + 10, value + 10)
            Me.Invalidate()
        End Set
    End Property

    Public Sub AplicarEstiloDesdeTema()
        Me.ColorSpinner = ThemeManagerUI.ColorPrimario
        Me.Invalidate()
    End Sub

    Private Sub timerAnimacion_Tick(sender As Object, e As EventArgs) Handles timerAnimacion.Tick
        contadorAngulo += 15
        If contadorAngulo >= 360 Then contadorAngulo = 0
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        Dim centro = New Point(Me.Width \ 2, Me.Height \ 2)
        Dim radioExterno = _sizeSpinner \ 2
        Dim radioInterno = radioExterno \ 2

        Dim pathSpinner As New GraphicsPath()
        pathSpinner.AddArc(centro.X - radioExterno, centro.Y - radioExterno, radioExterno * 2, radioExterno * 2, contadorAngulo, 270)

        Using penSpinner As New Pen(_colorSpinner, 4)
            e.Graphics.DrawPath(penSpinner, pathSpinner)
        End Using
    End Sub

    'Como lo usas

    'Dim spinner As New LoadingSpinnerUI()
    'spinner.Location = New Point(300, 200)
    'Me.Controls.Add(spinner)

End Class
