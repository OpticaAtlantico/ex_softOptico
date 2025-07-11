Imports System.Drawing
Imports System.Windows.Forms

Public Class TextBoxIconWUI
    Inherits UserControl

    Private _iconUnicode As String = ChrW(&HF007) ' fa-user
    Private _iconColor As Color = Color.Gray
    Private _backgroundColor As Color = Color.White
    Private _textColor As Color = Color.Black
    Private _focusColor As Color = Color.DeepSkyBlue
    Private _fontAwesomeFont As New Font("Font Awesome 6 Free Solid", 10)
    Private _hasFocus As Boolean = False

    Private _textBox As New TextBox()

    Public Sub New()
        Me.Size = New Size(297, 35)
        Me.BackColor = Color.Transparent
        Me.DoubleBuffered = True

        _textBox.BorderStyle = BorderStyle.None
        _textBox.Font = New Font("Segoe UI", 10)
        _textBox.ForeColor = _textColor
        _textBox.BackColor = _backgroundColor
        _textBox.Location = New Point(35, 8)
        _textBox.Width = Me.Width - 45
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

    ' 🎛 Propiedades públicas

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

    Public Property FocusColor As Color
        Get
            Return _focusColor
        End Get
        Set(value As Color)
            _focusColor = value
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

    ' 🎨 Render visual

    Protected Overrides Sub OnPaint(pe As PaintEventArgs)
        Dim g = pe.Graphics
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        g.Clear(Me.BackColor)

        Dim borderColor As Color = If(_hasFocus, _focusColor, _iconColor)
        Using borderPen As New Pen(borderColor, 1.5F)
            g.DrawRectangle(borderPen, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
        End Using

        Dim iconRect = New Rectangle(8, 8, 20, 20)
        TextRenderer.DrawText(g, _iconUnicode, _fontAwesomeFont, iconRect, _iconColor, TextFormatFlags.NoPadding)
    End Sub

    'Dim txtUsuario As New TextBoxIconUI()
    'txtUsuario.IconUnicode = ChrW(&HF007) ' fa-user
    'txtUsuario.IconColor = Color.DarkGray
    'txtUsuario.WilmerText = "Wilmer Dev"
    'Me.Controls.Add(txtUsuario)

End Class
