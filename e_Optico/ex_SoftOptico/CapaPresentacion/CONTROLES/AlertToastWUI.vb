Imports System.Drawing
Imports System.Windows.Forms

Public Enum ToastType
    Success
    Warning
    Errores
    Info
End Enum

Public Class AlertToastWUI
    Inherits UserControl

    Private _mensaje As String = "Mensaje Toast"
    Private _tipo As ToastType = ToastType.Info
    Private _backColor As Color = Color.SkyBlue
    Private _iconUnicode As String = ChrW(&HF06A)
    Private _fontAwesome As New Font("Font Awesome 6 Free Solid", 10)
    Private _opacity As Integer = 0
    Private _slideInTimer As New Timer()
    Private _lifeTimer As New Timer()
    Private _fadeOutTimer As New Timer()
    Private _initialLeft As Integer = 0

    Public Sub New()
        Me.Size = New Size(300, 45)
        Me.BackColor = Color.Transparent
        Me.DoubleBuffered = True
        Me.Visible = False

        _slideInTimer.Interval = 20
        AddHandler _slideInTimer.Tick, AddressOf SlideInTick

        _lifeTimer.Interval = 3000
        AddHandler _lifeTimer.Tick, Sub()
                                        _lifeTimer.Stop()
                                        _fadeOutTimer.Start()
                                    End Sub

        _fadeOutTimer.Interval = 30
        AddHandler _fadeOutTimer.Tick, AddressOf FadeOutTick
    End Sub

    Public Property TipoToast As ToastType
        Get
            Return _tipo
        End Get
        Set(value As ToastType)
            _tipo = value
            Select Case value
                Case ToastType.Success
                    _backColor = Color.MediumSeaGreen
                    _iconUnicode = ChrW(&HF00C)
                Case ToastType.Warning
                    _backColor = Color.Goldenrod
                    _iconUnicode = ChrW(&HF071)
                Case ToastType.Errores
                    _backColor = Color.IndianRed
                    _iconUnicode = ChrW(&HF057)
                Case ToastType.Info
                    _backColor = Color.SkyBlue
                    _iconUnicode = ChrW(&HF06A)
            End Select
            Me.Invalidate()
        End Set
    End Property

    Public Property MensajeToast As String
        Get
            Return _mensaje
        End Get
        Set(value As String)
            _mensaje = value
            Me.Invalidate()
        End Set
    End Property

    Public Sub MostrarToast(form As Form)
        _opacity = 0
        Me.Visible = True

        ' Posicionar en esquina inferior derecha y afuera del contenedor
        Dim x = form.ClientSize.Width
        Dim y = form.ClientSize.Height - Me.Height - 20
        Me.Location = New Point(x, y)
        _initialLeft = x
        form.Controls.Add(Me)

        _slideInTimer.Start()
    End Sub

    Private Sub SlideInTick(sender As Object, e As EventArgs)
        _opacity += 30
        Me.Location = New Point(Me.Location.X - 15, Me.Location.Y)
        If Me.Location.X <= _initialLeft - Me.Width - 20 Then
            _slideInTimer.Stop()
            _lifeTimer.Start()
        End If
        Me.Invalidate()
    End Sub

    Private Sub FadeOutTick(sender As Object, e As EventArgs)
        _opacity -= 20
        If _opacity <= 0 Then
            _fadeOutTimer.Stop()
            Me.Dispose()
        Else
            Me.Invalidate()
        End If
    End Sub

    Protected Overrides Sub OnPaint(pe As PaintEventArgs)
        Dim g = pe.Graphics
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        Dim backCol = Color.FromArgb(Math.Max(_opacity, 0), _backColor)
        Dim textCol = Color.FromArgb(Math.Max(_opacity, 0), Color.White)

        g.FillRectangle(New SolidBrush(backCol), Me.ClientRectangle)
        g.DrawRectangle(New Pen(Color.White, 1), New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))

        TextRenderer.DrawText(g, _iconUnicode, _fontAwesome, New Point(10, 12), textCol)
        TextRenderer.DrawText(g, _mensaje, New Font("Segoe UI", 10), New Rectangle(40, 10, Me.Width - 50, 25), textCol)
    End Sub
End Class
