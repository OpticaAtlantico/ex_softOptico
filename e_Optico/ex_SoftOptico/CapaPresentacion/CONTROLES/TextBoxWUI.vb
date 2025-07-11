Imports System.Drawing.Drawing2D
Imports System.Drawing
Imports System.Windows.Forms
Public Class TextBoxWUI
    Inherits UserControl

    Private _textBox As New TextBox()
    Private _borderColor As Color = Color.Gray
    Private _focusBorderColor As Color = Color.DeepSkyBlue
    Private _borderRadius As Integer = 6
    Private _shadowColor As Color = Color.FromArgb(40, Color.Black)
    Private _backgroundColor As Color = Color.White
    Private _hasFocus As Boolean = False

    Public Sub New()
        Me.Size = New Size(297, 35)
        Me.BackColor = Color.Transparent
        Me.DoubleBuffered = True

        _textBox.BorderStyle = BorderStyle.None
        _textBox.Font = New Font("Segoe UI", 10)
        _textBox.ForeColor = Color.Black
        _textBox.BackColor = Color.White
        _textBox.Location = New Point(10, 8)
        _textBox.Width = Me.Width - 20
        Me.Controls.Add(_textBox)

        AddHandler _textBox.GotFocus, Sub()
                                          _hasFocus = True
                                          Me.Invalidate()
                                      End Sub
        AddHandler _textBox.LostFocus, Sub()
                                           _hasFocus = False
                                           Me.Invalidate()
                                       End Sub
    End Sub

    ' 📎 Propiedades públicas

    Public Property BorderColor As Color
        Get
            Return _borderColor
        End Get
        Set(value As Color)
            _borderColor = value
            Me.Invalidate()
        End Set
    End Property

    Public Property FocusBorderColor As Color
        Get
            Return _focusBorderColor
        End Get
        Set(value As Color)
            _focusBorderColor = value
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

    Public Property BackgroundColorCustom As Color
        Get
            Return _backgroundColor
        End Get
        Set(value As Color)
            _backgroundColor = value
            _textBox.BackColor = value
            Me.Invalidate()
        End Set
    End Property

    Public Property ShadowColor As Color
        Get
            Return _shadowColor
        End Get
        Set(value As Color)
            _shadowColor = value
            Me.Invalidate()
        End Set
    End Property

    Public Property WilmerText As String
        Get
            Return _textBox.Text
        End Get
        Set(value As String)
            _textBox.Text = value
        End Set
    End Property

    Public ReadOnly Property TextBoxRef As TextBox
        Get
            Return _textBox
        End Get
    End Property

    ' 🎨 Render personalizado

    Protected Overrides Sub OnPaint(pe As PaintEventArgs)
        Dim g = pe.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias

        Dim rect = New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)

        ' Sombra
        Dim shadowRect = New Rectangle(rect.X + 1, rect.Y + 1, rect.Width, rect.Height)
        g.FillRectangle(New SolidBrush(_shadowColor), shadowRect)

        ' Borde redondeado
        Dim path = New GraphicsPath()
        path.AddArc(rect.X, rect.Y, _borderRadius, _borderRadius, 180, 90)
        path.AddArc(rect.Right - _borderRadius, rect.Y, _borderRadius, _borderRadius, 270, 90)
        path.AddArc(rect.Right - _borderRadius, rect.Bottom - _borderRadius, _borderRadius, _borderRadius, 0, 90)
        path.AddArc(rect.X, rect.Bottom - _borderRadius, _borderRadius, _borderRadius, 90, 90)
        path.CloseAllFigures()

        g.FillPath(New SolidBrush(_backgroundColor), path)
        Dim penColor = If(_hasFocus, _focusBorderColor, _borderColor)
        Using pen As New Pen(penColor, 1.5F)
            g.DrawPath(pen, path)
        End Using
    End Sub

    'COMO SE USA

    'Dim txtNombre As New TextBoxUI()
    'txtNombre.Location = New Point(20, 40)
    'txtNombre.BorderColor = Color.Gray
    'txtNombre.FocusBorderColor = Color.DeepSkyBlue
    'txtNombre.BackgroundColorCustom = Color.White
    'txtNombre.WilmerText = "Wilmer Dev"
    'Me.Controls.Add(txtNombre)

End Class
