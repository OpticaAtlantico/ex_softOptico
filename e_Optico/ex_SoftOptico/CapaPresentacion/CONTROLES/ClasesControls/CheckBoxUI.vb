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
        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor Or
                    ControlStyles.UserPaint Or
                    ControlStyles.AllPaintingInWmPaint Or
                    ControlStyles.OptimizedDoubleBuffer, True)
        Me.UpdateStyles()
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

