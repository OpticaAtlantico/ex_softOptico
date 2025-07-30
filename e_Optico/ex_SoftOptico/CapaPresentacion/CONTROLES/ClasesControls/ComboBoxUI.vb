Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class ComboBoxUI
    Inherits ComboBox

    Private _borderColor As Color = Color.FromArgb(57, 103, 208)
    Private _focusColor As Color = Color.DeepSkyBlue
    Private _borderRadius As Integer = 6
    Private _hasFocus As Boolean = False
    Private _backgroundColor As Color = Color.White
    Private _textColor As Color = Color.Black
    Private _shadowColor As Color = Color.FromArgb(30, Color.Black)

    Public Sub New()
        Me.SetStyle(ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
        Me.DrawMode = DrawMode.OwnerDrawFixed
        Me.DropDownStyle = ComboBoxStyle.DropDownList
        Me.Font = New Font("Century Gothic", 12, FontStyle.Regular)
        Me.ItemHeight = 30
        Me.FlatStyle = FlatStyle.Flat
        Me.ForeColor = Color.WhiteSmoke
        Me.Size = New Size(300, 30)
    End Sub

    ' Propiedades orbitales
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
    Public Property BorderRadius As Integer
        Get
            Return _borderRadius
        End Get
        Set(value As Integer)
            _borderRadius = value
            Me.Invalidate()
        End Set
    End Property

    <Category("UI Estilo")>
    Public Property BackgroundColor As Color
        Get
            Return _backgroundColor
        End Get
        Set(value As Color)
            _backgroundColor = value
            Me.Invalidate()
        End Set
    End Property

    <Category("UI Estilo")>
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

        Dim rect As New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)
        Dim shadowRect As New Rectangle(rect.X + 1, rect.Y + 1, rect.Width, rect.Height)
        Using shadowBrush As New SolidBrush(_shadowColor)
            pe.Graphics.FillRectangle(shadowBrush, shadowRect)
        End Using

        Dim path = RoundedRectanglePath(rect, _borderRadius)

        Using fondoBrush As New SolidBrush(_backgroundColor)
            pe.Graphics.FillPath(fondoBrush, path)
        End Using

        Dim penColor = If(_hasFocus, _focusColor, _borderColor)
        Using pen As New Pen(penColor, 1.5F)
            pe.Graphics.DrawPath(pen, path)
        End Using

        ' Texto del ítem seleccionado
        If Me.SelectedIndex >= 0 Then
            Dim textRect As New Rectangle(10, 0, Me.Width - 30, Me.Height)
            TextRenderer.DrawText(pe.Graphics, Me.GetItemText(Me.SelectedItem), Me.Font, textRect, Color.WhiteSmoke, TextFormatFlags.VerticalCenter)
        End If

        ' Flecha orbital dibujada manualmente
        Dim cy = Me.Height \ 2
        Dim flecha() As Point = {
            New Point(Me.Width - 18, cy - 4),
            New Point(Me.Width - 10, cy - 4),
            New Point(Me.Width - 14, cy + 2)
        }
        Using brush As New SolidBrush(Color.FromArgb(57, 103, 208))
            pe.Graphics.FillPolygon(brush, flecha)
        End Using
    End Sub

    Protected Overrides Sub OnDrawItem(e As DrawItemEventArgs)
        If e.Index < 0 Then Exit Sub

        Dim itemText = Me.Items(e.Index).ToString()
        Dim seleccionado = (e.State And DrawItemState.Selected) = DrawItemState.Selected

        ' Fondo blanco si no está seleccionado, celeste si lo está
        Dim bgColor As Color = If(seleccionado, Color.LightSkyBlue, Color.White)

        ' Pintar fondo del ítem
        e.Graphics.FillRectangle(New SolidBrush(bgColor), e.Bounds)

        ' Texto orbital
        TextRenderer.DrawText(e.Graphics, itemText, Me.Font, e.Bounds, _textColor, TextFormatFlags.Left Or TextFormatFlags.VerticalCenter)

        ' Opcional: borde inferior orbital entre ítems
        Using bordePen As New Pen(Color.LightGray)
            e.Graphics.DrawLine(bordePen, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1)
        End Using

        e.DrawFocusRectangle() ' Mantiene el efecto visual si lo deseas
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
