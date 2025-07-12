Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class OptionButtonWUI
    Inherits UserControl

    Private _checkedColor As Color = Color.DeepSkyBlue
    Private _borderColor As Color = Color.Gray
    Private _shadowColor As Color = Color.FromArgb(30, Color.Black)
    Private _textColor As Color = Color.Black
    Private _circleSize As Integer = 18
    Private _isChecked As Boolean = False

    Public Sub New()
        Me.Size = New Size(160, 35)
        Me.BackColor = Color.Transparent
        Me.DoubleBuffered = True
    End Sub

    ' 🔘 Propiedades públicas

    Public Property CheckedColor As Color
        Get
            Return _checkedColor
        End Get
        Set(value As Color)
            _checkedColor = value
            Me.Invalidate()
        End Set
    End Property

    Public Property BorderColor As Color
        Get
            Return _borderColor
        End Get
        Set(value As Color)
            _borderColor = value
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

    Public Property TextColor As Color
        Get
            Return _textColor
        End Get
        Set(value As Color)
            _textColor = value
            Me.Invalidate()
        End Set
    End Property

    Public Property OpcionTexto As String
        Get
            Return Me.Text
        End Get
        Set(value As String)
            Me.Text = value
            Me.Invalidate()
        End Set
    End Property

    Public Property Checked As Boolean
        Get
            Return _isChecked
        End Get
        Set(value As Boolean)
            _isChecked = value
            Me.Invalidate()
            RaiseEvent CheckedChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Event CheckedChanged As EventHandler

    Protected Overrides Sub OnClick(e As EventArgs)
        MyBase.OnClick(e)
        Checked = Not Checked
    End Sub

    ' 🎨 Render visual del botón de opción

    Protected Overrides Sub OnPaint(pe As PaintEventArgs)
        Dim g = pe.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias

        Dim circleRect As New Rectangle(10, (Me.Height - _circleSize) \ 2, _circleSize, _circleSize)
        Dim textRect As New Rectangle(circleRect.Right + 10, 0, Me.Width - circleRect.Right - 20, Me.Height)

        ' Sombra externa
        Dim shadowRect = New Rectangle(circleRect.X + 1, circleRect.Y + 1, _circleSize, _circleSize)
        g.FillEllipse(New SolidBrush(_shadowColor), shadowRect)

        ' Círculo principal
        g.FillEllipse(New SolidBrush(Color.White), circleRect)
        g.DrawEllipse(New Pen(_borderColor, 1.5F), circleRect)

        ' Si está marcado: círculo interno
        If _isChecked Then
            Dim innerSize = _circleSize \ 2
            Dim innerRect = New Rectangle(circleRect.X + (_circleSize - innerSize) \ 2, circleRect.Y + (_circleSize - innerSize) \ 2, innerSize, innerSize)
            g.FillEllipse(New SolidBrush(_checkedColor), innerRect)
        End If

        ' Texto asociado
        TextRenderer.DrawText(g, Me.Text, New Font("Segoe UI", 10), textRect, _textColor, TextFormatFlags.Left Or TextFormatFlags.VerticalCenter)
    End Sub

    'Dim optMasculino As New OptionButtonUI()
    'optMasculino.OpcionTexto = "Masculino"
    'optMasculino.CheckedColor = Color.RoyalBlue
    'optMasculino.Location = New Point(20, 270)

    'Dim optFemenino As New OptionButtonUI()
    'optFemenino.OpcionTexto = "Femenino"
    'optFemenino.CheckedColor = Color.DeepPink
    'optFemenino.Location = New Point(160, 270)

    'Me.Controls.Add(optMasculino)
    'Me.Controls.Add(optFemenino)

End Class
