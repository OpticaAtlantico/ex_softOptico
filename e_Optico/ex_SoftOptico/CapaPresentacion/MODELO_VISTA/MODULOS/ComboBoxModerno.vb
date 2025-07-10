Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class ComboBoxModerno
    Inherits ComboBox

    Private _borderColor As Color = Color.Gray
    Private _focusBorderColor As Color = Color.DeepSkyBlue
    Private _borderRadius As Integer = 6
    Private _hasFocus As Boolean = False
    Private _backColorCustom As Color = Color.White
    Private _textColor As Color = Color.Black

    Public Sub New()
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.DrawMode = DrawMode.OwnerDrawFixed
        Me.DropDownStyle = ComboBoxStyle.DropDownList
        Me.Font = New Font("Segoe UI", 10)
        Me.Size = New Size(297, 35)
        Me.ItemHeight = 30
        Me.FlatStyle = FlatStyle.Flat
        Me.ForeColor = _textColor
    End Sub

    <Category("Material")>
    Public Property BorderColor As Color
        Get
            Return _borderColor
        End Get
        Set(value As Color)
            _borderColor = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Material")>
    Public Property FocusBorderColor As Color
        Get
            Return _focusBorderColor
        End Get
        Set(value As Color)
            _focusBorderColor = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Material")>
    Public Property BorderRadius As Integer
        Get
            Return _borderRadius
        End Get
        Set(value As Integer)
            _borderRadius = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Material")>
    Public Property BackgroundColor As Color
        Get
            Return _backColorCustom
        End Get
        Set(value As Color)
            _backColorCustom = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Material")>
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
        Dim rect = Me.ClientRectangle
        rect.Width -= 1
        rect.Height -= 1

        ' Bordes redondeados
        Dim path = New GraphicsPath()
        path.AddArc(0, 0, _borderRadius, _borderRadius, 180, 90)
        path.AddArc(rect.Width - _borderRadius, 0, _borderRadius, _borderRadius, 270, 90)
        path.AddArc(rect.Width - _borderRadius, rect.Height - _borderRadius, _borderRadius, _borderRadius, 0, 90)
        path.AddArc(0, rect.Height - _borderRadius, _borderRadius, _borderRadius, 90, 90)
        path.CloseAllFigures()

        pe.Graphics.FillPath(New SolidBrush(_backColorCustom), path)

        Dim penColor = If(_hasFocus, _focusBorderColor, _borderColor)
        Using pen As New Pen(penColor)
            pe.Graphics.DrawPath(pen, path)
        End Using

        ' Texto seleccionado
        If Me.SelectedIndex >= 0 Then
            Dim textRect = New Rectangle(10, 0, Me.Width - 30, Me.Height)
            TextRenderer.DrawText(pe.Graphics, Me.GetItemText(Me.Items(Me.SelectedIndex)), Me.Font, textRect, _textColor, TextFormatFlags.VerticalCenter)
        End If

        ' Ícono de flecha
        Dim triangle As Point() = {
            New Point(Me.Width - 20, Me.Height \ 2 - 4),
            New Point(Me.Width - 12, Me.Height \ 2 - 4),
            New Point(Me.Width - 16, Me.Height \ 2 + 2)
        }
        pe.Graphics.FillPolygon(Brushes.Gray, triangle)
    End Sub

    Protected Overrides Sub OnDrawItem(e As DrawItemEventArgs)
        If e.Index < 0 Then Return

        Dim itemText = Me.Items(e.Index).ToString()
        Dim bgColor = If((e.State And DrawItemState.Selected) = DrawItemState.Selected, Color.LightSkyBlue, _backColorCustom)

        e.Graphics.FillRectangle(New SolidBrush(bgColor), e.Bounds)
        TextRenderer.DrawText(e.Graphics, itemText, Me.Font, e.Bounds, _textColor, TextFormatFlags.Left Or TextFormatFlags.VerticalCenter)
    End Sub
End Class

