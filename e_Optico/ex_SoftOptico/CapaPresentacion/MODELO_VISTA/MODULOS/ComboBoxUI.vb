Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Drawing
Imports System.Windows.Forms

Public Class ComboBoxUI
    Inherits ComboBox

    Private _borderColor As Color = Color.LightGray
    Private _focusBorderColor As Color = Color.DeepSkyBlue
    Private _borderRadius As Integer = 6
    Private _hasFocus As Boolean = False
    Private _backColorCustom As Color = Color.White
    Private _textColor As Color = Color.Black
    Private _shadowColor As Color = Color.FromArgb(40, Color.Black)

    Public Sub New()
        Me.SetStyle(ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
        Me.DrawMode = DrawMode.OwnerDrawFixed
        Me.DropDownStyle = ComboBoxStyle.DropDownList
        Me.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        Me.Size = New Size(297, 35)
        Me.ItemHeight = 30
        Me.FlatStyle = FlatStyle.Flat
        Me.ForeColor = _textColor
        Me.BackColor = Color.White
    End Sub

    <Category("Material Estilo")>
    Public Property BorderColor As Color
        Get
            Return _borderColor
        End Get
        Set(value As Color)
            _borderColor = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Material Estilo")>
    Public Property FocusBorderColor As Color
        Get
            Return _focusBorderColor
        End Get
        Set(value As Color)
            _focusBorderColor = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Material Estilo")>
    Public Property BorderRadius As Integer
        Get
            Return _borderRadius
        End Get
        Set(value As Integer)
            _borderRadius = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Material Estilo")>
    Public Property BackgroundColor As Color
        Get
            Return _backColorCustom
        End Get
        Set(value As Color)
            _backColorCustom = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Material Estilo")>
    Public Property TextColor As Color
        Get
            Return _textColor
        End Get
        Set(value As Color)
            _textColor = value
            Me.ForeColor = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Material Estilo")>
    Public Property ShadowColor As Color
        Get
            Return _shadowColor
        End Get
        Set(value As Color)
            _shadowColor = value
            Me.Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnGotFocus(e As EventArgs)
        MyBase.OnGotFocus(e)
        _hasFocus = True
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnLostFocus(e As EventArgs)
        MyBase.OnLostFocus(e)
        _hasFocus = False
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(pe As PaintEventArgs)
        pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        Dim rect = New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)

        ' Sombra suave exterior
        Using shadowBrush As New SolidBrush(_shadowColor)
            Dim shadowRect = New Rectangle(rect.X + 1, rect.Y + 1, rect.Width, rect.Height)
            pe.Graphics.FillRectangle(shadowBrush, shadowRect)
        End Using

        ' Bordes redondeados
        Dim path = RoundedRectanglePath(rect, _borderRadius)

        ' Fondo principal
        pe.Graphics.FillPath(New SolidBrush(_backColorCustom), path)

        ' Borde color según foco
        Dim penColor = If(_hasFocus, _focusBorderColor, _borderColor)
        Using pen As New Pen(penColor, 1.5F)
            pe.Graphics.DrawPath(pen, path)
        End Using

        ' Texto seleccionado
        If Me.SelectedIndex >= 0 Then
            Dim textRect = New Rectangle(10, 0, Me.Width - 30, Me.Height)
            TextRenderer.DrawText(pe.Graphics, Me.GetItemText(Me.Items(Me.SelectedIndex)), Me.Font, textRect, _textColor, TextFormatFlags.VerticalCenter)
        End If

        ' Flechita elegante
        Dim centerY = Me.Height \ 2
        Dim triangle As Point() = {
                New Point(Me.Width - 18, centerY - 4),
                New Point(Me.Width - 10, centerY - 4),
                New Point(Me.Width - 14, centerY + 2)
            }
        pe.Graphics.FillPolygon(New SolidBrush(Color.WhiteSmoke), triangle)
    End Sub

    Protected Overrides Sub OnDrawItem(e As DrawItemEventArgs)
        If e.Index < 0 Then Return

        Dim itemText = Me.Items(e.Index).ToString()
        Dim bgColor = If((e.State And DrawItemState.Selected) = DrawItemState.Selected, Color.LightSkyBlue, _backColorCustom)

        e.Graphics.FillRectangle(New SolidBrush(bgColor), e.Bounds)
        TextRenderer.DrawText(e.Graphics, itemText, Me.Font, e.Bounds, _textColor, TextFormatFlags.Left Or TextFormatFlags.VerticalCenter)
    End Sub

    Private Function RoundedRectanglePath(rect As Rectangle, radius As Integer) As GraphicsPath
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
