Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class MaskedTextBoxUI
    Inherits UserControl

    Private WithEvents campoMask As New MaskedTextBox()
    Private _mask As String = ""
    Private _borderColor As Color = Color.Gray
    Private _focusColor As Color = Color.DeepSkyBlue
    Private _shadowColor As Color = Color.FromArgb(30, Color.Black)
    Private _borderRadius As Integer = 8
    Private enfocado As Boolean = False

    Public Sub New()
        Me.Size = New Size(200, 36)
        Me.DoubleBuffered = True
        Me.BackColor = Color.Transparent

        campoMask.Dock = DockStyle.Fill
        campoMask.BorderStyle = BorderStyle.None
        campoMask.Font = New Font("Century Gothic", 11)
        campoMask.Padding = New Padding(6)

        Me.Controls.Add(campoMask)
    End Sub

    <Category("UI Estilo")>
    Public Property Mask As String
        Get
            Return _mask
        End Get
        Set(value As String)
            _mask = value
            campoMask.Mask = value
            Me.Invalidate()
        End Set
    End Property

    <Category("UI Estilo")>
    Public Property BorderColor As Color
        Get
            Return _borderColor
        End Get
        Set(value As Color)
            _borderColor = value
            Me.Invalidate()
        End Set
    End Property

    <Category("UI Estilo")>
    Public Property FocusColor As Color
        Get
            Return _focusColor
        End Get
        Set(value As Color)
            _focusColor = value
            Me.Invalidate()
        End Set
    End Property

    <Category("UI Estilo")>
    Public Property ShadowColor As Color
        Get
            Return _shadowColor
        End Get
        Set(value As Color)
            _shadowColor = value
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

    Public ReadOnly Property TextMasked As String
        Get
            Return campoMask.Text
        End Get
    End Property

    Public Sub AplicarEstiloDesdeTema()
        Me.BorderColor = ThemeManagerUI.ColorBorde
        Me.FocusColor = ThemeManagerUI.ColorPrimario
        Me.ShadowColor = ThemeManagerUI.ColorSombra
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        Dim rect = New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)
        Dim path = RoundedPath(rect, _borderRadius)

        ' Sombra orbital
        Dim sombraRect = New Rectangle(rect.X + 1, rect.Y + 1, rect.Width, rect.Height)
        Using sombraBrush As New SolidBrush(_shadowColor)
            e.Graphics.FillRectangle(sombraBrush, sombraRect)
        End Using

        ' Fondo orbital
        Using fondoBrush As New SolidBrush(Me.BackColor)
            e.Graphics.FillPath(fondoBrush, path)
        End Using

        ' Borde orbital
        Dim colorBorde = If(enfocado, _focusColor, _borderColor)
        Using bordePen As New Pen(colorBorde, 1.5F)
            e.Graphics.DrawPath(bordePen, path)
        End Using
    End Sub

    Private Sub campoMask_Enter(sender As Object, e As EventArgs) Handles campoMask.Enter
        enfocado = True
        Me.Invalidate()
    End Sub

    Private Sub campoMask_Leave(sender As Object, e As EventArgs) Handles campoMask.Leave
        enfocado = False
        Me.Invalidate()
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

    'Como usarlo

    '    Dim txtCedula As New MaskedTextBoxUI()
    'txtCedula.Mask = "00000000"
    'txtCedula.BorderColor = Color.Gray
    'txtCedula.FocusColor = Color.RoyalBlue
    'Me.Controls.Add(txtCedula)

End Class
