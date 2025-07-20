Public Class OverlaySpinnerUI
    Inherits Control

    Private spinnerColor As Color = Color.DeepSkyBlue
    Private spinnerSize As Integer = 28
    Private mensajeCarga As String = "Cargando..."
    Private WithEvents spinTimer As New Timer() With {.Interval = 80}
    Private angulo As Integer = 0

    Public Sub New()
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or
                    ControlStyles.OptimizedDoubleBuffer Or
                    ControlStyles.UserPaint Or
                    ControlStyles.SupportsTransparentBackColor, True)
        Me.BackColor = Color.FromArgb(160, 0, 0, 0)
        Me.Dock = DockStyle.Fill
        Me.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        Me.Visible = False
    End Sub

    Public Property Mensaje As String
        Get
            Return mensajeCarga
        End Get
        Set(value As String)
            mensajeCarga = value
            Me.Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim g = e.Graphics
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        Dim centro = New Point(Me.Width \ 2, Me.Height \ 2 - 20)
        Dim radio = spinnerSize
        Dim segmentos = 12
        Dim alphaStep = 255 \ segmentos

        For i = 0 To segmentos - 1
            Dim ang = (angulo + i * 360 \ segmentos) Mod 360
            Dim a = Math.Max(30, 255 - i * alphaStep)
            Dim c = Color.FromArgb(a, spinnerColor)
            Using pen As New Pen(c, 4)
                Dim rad = ang * Math.PI / 180
                Dim x1 = centro.X + radio * Math.Cos(rad)
                Dim y1 = centro.Y + radio * Math.Sin(rad)
                Dim x2 = centro.X + (radio - 6) * Math.Cos(rad)
                Dim y2 = centro.Y + (radio - 6) * Math.Sin(rad)
                g.DrawLine(pen, CSng(x1), CSng(y1), CSng(x2), CSng(y2))
            End Using
        Next

        TextRenderer.DrawText(g, mensajeCarga, Me.Font, New Point(centro.X - 60, centro.Y + 30), Color.White)
    End Sub

    Protected Overrides Sub OnVisibleChanged(e As EventArgs)
        If Me.Visible Then
            spinTimer.Start()
        Else
            spinTimer.Stop()
        End If
        MyBase.OnVisibleChanged(e)
    End Sub

    Private Sub spinTimer_Tick(sender As Object, e As EventArgs) Handles spinTimer.Tick
        angulo = (angulo + 30) Mod 360
        Me.Invalidate()
    End Sub
End Class