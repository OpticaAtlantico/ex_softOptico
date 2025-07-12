Imports System.Drawing.Drawing2D
Imports System.ComponentModel

Public Class ComboBoxWUI
    Inherits UserControl

    Private WithEvents cboInterno As New ComboBox()

    Private _borderColor As Color = Color.Silver
    Private _focusColor As Color = Color.DeepSkyBlue
    Private _borderRadius As Integer = 6
    Private _hasFocus As Boolean = False
    Private _backgroundColorCustom As Color = Color.White
    Private _textColor As Color = Color.Black
    Private _shadowColor As Color = Color.FromArgb(30, Color.Black)

    Public Sub New()
        Me.DoubleBuffered = True
        Me.Size = New Size(300, 40)
        Me.Font = New Font("Century Gothic", 12, FontStyle.Regular)

        cboInterno.DropDownStyle = ComboBoxStyle.DropDownList
        cboInterno.FlatStyle = FlatStyle.Flat
        cboInterno.Font = Me.Font
        cboInterno.BackColor = _backgroundColorCustom
        cboInterno.ForeColor = _textColor
        cboInterno.Location = New Point(10, (Me.Height - cboInterno.Height) \ 2)
        cboInterno.Width = Me.Width - 30

        Me.Controls.Add(cboInterno)
        AddHandler Me.Resize, AddressOf AjustarAltura
    End Sub

    Private Sub AjustarAltura(sender As Object, e As EventArgs)
        cboInterno.Location = New Point(10, (Me.Height - cboInterno.Height) \ 2)
    End Sub

    ' 📦 Propiedades visuales
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
    Public Property FocusColor As Color
        Get
            Return _focusColor
        End Get
        Set(value As Color)
            _focusColor = value
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
    Public Property BackgroundColorCustom As Color
        Get
            Return _backgroundColorCustom
        End Get
        Set(value As Color)
            _backgroundColorCustom = value
            cboInterno.BackColor = value
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
            cboInterno.ForeColor = value
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

    ' 🎯 Accesos extendidos
    <Category("WilmerUI Acceso")>
    Public ReadOnly Property Items As ComboBox.ObjectCollection
        Get
            Return cboInterno.Items
        End Get
    End Property

    <Category("WilmerUI Acceso")>
    Public Property SelectedIndex As Integer
        Get
            Return cboInterno.SelectedIndex
        End Get
        Set(value As Integer)
            cboInterno.SelectedIndex = value
        End Set
    End Property

    <Category("WilmerUI Acceso")>
    Public ReadOnly Property SelectedItem As Object
        Get
            Return cboInterno.SelectedItem
        End Get
    End Property

    <Category("WilmerUI Acceso")>
    Public ReadOnly Property SelectedValue As Object
        Get
            Return cboInterno.SelectedItem
        End Get
    End Property

    <Category("WilmerUI Acceso")>
    Public ReadOnly Property ComboBoxRef As ComboBox
        Get
            Return cboInterno
        End Get
    End Property

    ' 🔁 Foco visual
    Private Sub cboInterno_GotFocus(sender As Object, e As EventArgs) Handles cboInterno.GotFocus
        _hasFocus = True
        Me.Invalidate()
    End Sub

    Private Sub cboInterno_LostFocus(sender As Object, e As EventArgs) Handles cboInterno.LostFocus
        _hasFocus = False
        Me.Invalidate()
    End Sub

    ' 🎨 Redibujado orbital
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

        ' Fondo
        Using fondoBrush As New SolidBrush(_backgroundColorCustom)
            e.Graphics.FillPath(fondoBrush, path)
        End Using

        ' Borde
        Using pen As New Pen(If(_hasFocus, _focusColor, _borderColor), 1.5F)
            e.Graphics.DrawPath(pen, path)
        End Using

        ' Flechita limpia
        Dim centerY = Me.Height \ 2
        Dim flechaPath As New GraphicsPath()
        flechaPath.AddPolygon({
            New Point(Me.Width - 18, centerY - 4),
            New Point(Me.Width - 10, centerY - 4),
            New Point(Me.Width - 14, centerY + 2)
        })
        Using flechaBrush As New SolidBrush(_textColor)
            e.Graphics.FillPath(flechaBrush, flechaPath)
        End Using
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

    ' 📡 Integración con tema
    Public Sub AplicarEstiloDesdeTema()
        Me.BackgroundColorCustom = ThemeManagerWUI.ColorFondoBase
        Me.BorderColor = ThemeManagerWUI.ColorBorde
        Me.FocusColor = ThemeManagerWUI.ColorPrimario
        Me.TextColor = ThemeManagerWUI.ColorTextoBase
        Me.Invalidate()
    End Sub
End Class