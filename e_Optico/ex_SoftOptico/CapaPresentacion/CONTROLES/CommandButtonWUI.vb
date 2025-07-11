Imports System.Drawing.Drawing2D
Imports System.Drawing
Imports System.Windows.Forms
Public Class CommandButtonWUI
    Inherits UserControl

    Private _text As String = "Aceptar"
    Private _iconUnicode As String = ChrW(&HF00C) ' fa-check
    Private _iconColor As Color = Color.White
    Private _textColor As Color = Color.White
    Private _baseColor As Color = Color.SeaGreen
    Private _borderRadius As Integer = 6
    Private _fontAwesomeFont As New Font("Font Awesome 6 Free Solid", 10)

    Public Sub New()
        Me.Size = New Size(140, 35)
        Me.BackColor = Color.Transparent
        Me.DoubleBuffered = True
    End Sub

    ' 🧩 Propiedades públicas

    Public Property BotonTexto As String
        Get
            Return _text
        End Get
        Set(value As String)
            _text = value
            Me.Invalidate()
        End Set
    End Property

    Public Property IconUnicode As String
        Get
            Return _iconUnicode
        End Get
        Set(value As String)
            _iconUnicode = value
            Me.Invalidate()
        End Set
    End Property

    Public Property IconColor As Color
        Get
            Return _iconColor
        End Get
        Set(value As Color)
            _iconColor = value
            Me.Invalidate()
        End Set
    End Property

    Public Property TextColor As Color
        Get
            Return _textColor
        End Get
        Set(value As Color)
            _textColor = value
            Me.Invalidate()
        End Set
    End Property

    Public Property BaseColor As Color
        Get
            Return _baseColor
        End Get
        Set(value As Color)
            _baseColor = value
            Me.Invalidate()
        End Set
    End Property

    Public Property BorderRadius As Integer
        Get
            Return _borderRadius
        End Get
        Set(value As Integer)
            _borderRadius = value
            Me.Invalidate()
        End Set
    End Property

    ' 🚀 Evento personalizado

    Public Event BotonClick As EventHandler

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        RaiseEvent BotonClick(Me, EventArgs.Empty)
    End Sub

    ' 🎨 Render visual

    Protected Overrides Sub OnPaint(pe As PaintEventArgs)
        Dim g = pe.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias

        Dim rect = Me.ClientRectangle
        Dim path = New GraphicsPath()
        path.AddArc(0, 0, _borderRadius, _borderRadius, 180, 90)
        path.AddArc(rect.Width - _borderRadius, 0, _borderRadius, _borderRadius, 270, 90)
        path.AddArc(rect.Width - _borderRadius, rect.Height - _borderRadius, _borderRadius, _borderRadius, 0, 90)
        path.AddArc(0, rect.Height - _borderRadius, _borderRadius, _borderRadius, 90, 90)
        path.CloseFigure()

        g.FillPath(New SolidBrush(_baseColor), path)

        Dim textoCompleto = If(String.IsNullOrEmpty(_iconUnicode), _text, _iconUnicode & "  " & _text)
        Dim fontTotal = If(String.IsNullOrEmpty(_iconUnicode), New Font("Segoe UI", 10), _fontAwesomeFont)
        TextRenderer.DrawText(g, textoCompleto, fontTotal, rect, _textColor, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
    End Sub
End Class
