Imports System.ComponentModel
Imports System.Drawing.Drawing2D

Public Class TextBoxWUI
    Inherits UserControl

    Private WithEvents innerText As New TextBox()
    Private _borderColor As Color = Color.LightGray
    Private _focusBorderColor As Color = Color.DeepSkyBlue
    Private _borderRadius As Integer = 6
    Private _shadowColor As Color = Color.FromArgb(30, Color.Black)
    Private _backgroundColor As Color = Color.White
    Private _textColor As Color = Color.Black
    Private _tituloSuperior As String = ""
    Private _hasFocus As Boolean = False

    Public Sub New()
        Me.Size = New Size(300, 40)
        Me.Font = New Font("Century Gothic", 12, FontStyle.Regular)
        Me.DoubleBuffered = True
        innerText.BorderStyle = BorderStyle.None
        innerText.BackColor = _backgroundColor
        innerText.ForeColor = _textColor
        innerText.Location = New Point(10, (Me.Height - innerText.Height) \ 2)
        innerText.Width = Me.Width - 20
        Me.Controls.Add(innerText)
    End Sub

    ' 🧠 Propiedades públicas
    <Category("WilmerUI Estilo")>
    Public Property BorderColor As Color
        Get
            Return _borderColor
        End Get
        Set(value As Color)
            _borderColor = value
            Me.Invalidate()
        End Set
    End Property

    <Category("WilmerUI Estilo")>
    Public Property FocusBorderColor As Color
        Get
            Return _focusBorderColor
        End Get
        Set(value As Color)
            _focusBorderColor = value
            Me.Invalidate()
        End Set
    End Property

    <Category("WilmerUI Estilo")>
    Public Property BorderRadius As Integer
        Get
            Return _borderRadius
        End Get
        Set(value As Integer)
            _borderRadius = value
            Me.Invalidate()
        End Set
    End Property

    <Category("WilmerUI Estilo")>
    Public Property ShadowColor As Color
        Get
            Return _shadowColor
        End Get
        Set(value As Color)
            _shadowColor = value
            Me.Invalidate()
        End Set
    End Property

    <Category("WilmerUI Estilo")>
    Public Property BackgroundColor As Color
        Get
            Return _backgroundColor
        End Get
        Set(value As Color)
            _backgroundColor = value
            innerText.BackColor = value
            Me.Invalidate()
        End Set
    End Property

    <Category("WilmerUI Estilo")>
    Public Property TextColor As Color
        Get
            Return _textColor
        End Get
        Set(value As Color)
            _textColor = value
            innerText.ForeColor = value
            Me.Invalidate()
        End Set
    End Property

    <Category("WilmerUI Estilo")>
    Public Property TituloSuperior As String
        Get
            Return _tituloSuperior
        End Get
        Set(value As String)
            _tituloSuperior = value
            Me.Invalidate()
        End Set
    End Property

    ' ✨ Propiedad de texto accesible desde fuera
    Public Property Texto As String
        Get
            Return innerText.Text
        End Get
        Set(value As String)
            innerText.Text = value
        End Set
    End Property

    Public Property TextBox As Object

    ' 🔁 Foco visual
    Private Sub innerText_GotFocus(sender As Object, e As EventArgs) Handles innerText.GotFocus
        _hasFocus = True
        Me.Invalidate()
    End Sub

    Private Sub innerText_LostFocus(sender As Object, e As EventArgs) Handles innerText.LostFocus
        _hasFocus = False
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        Dim rect = New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)
        Dim path = RoundedPath(rect, _borderRadius)

        ' Sombra
        Dim sombraRect = New Rectangle(rect.X + 1, rect.Y + 1, rect.Width, rect.Height)
        Using sombraBrush As New SolidBrush(_shadowColor)
            e.Graphics.FillRectangle(sombraBrush, sombraRect)
        End Using

        ' Fondo principal
        Using fondoBrush As New SolidBrush(_backgroundColor)
            e.Graphics.FillPath(fondoBrush, path)
        End Using

        ' Borde
        Using pen As New Pen(If(_hasFocus, _focusBorderColor, _borderColor), 1.5F)
            e.Graphics.DrawPath(pen, path)
        End Using

        ' Etiqueta superior
        If Not String.IsNullOrWhiteSpace(_tituloSuperior) Then
            Dim fuenteTitulo As New Font("Century Gothic", 12, FontStyle.Regular)
            Using brush As New SolidBrush(Color.Gray)
                e.Graphics.DrawString(_tituloSuperior, fuenteTitulo, brush, New Point(10, 4))
            End Using
        End If
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
End Class