Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class LabelWUI
    Inherits UserControl

    Private _texto As String = "Etiqueta"
    Private _textoColor As Color = Color.Black
    Private _fondoColor As Color = Color.Transparent
    Private _fontSize As Integer = 9
    Private _fontStyle As FontStyle = FontStyle.Regular
    Private _iconoUnicode As String = ""
    Private _iconoColor As Color = Color.Black
    Private _borderRadius As Integer = 0
    Private _autoSizeLabel As Boolean = True
    Private _fontIcon As New Font("Font Awesome 6 Free Solid", 10)

    Public Sub New()
        Me.DoubleBuffered = True
        Me.BackColor = Color.Transparent
        Me.Size = New Size(150, 30)
    End Sub

    Public Property Texto As String
        Get
            Return _texto
        End Get
        Set(value As String)
            _texto = value
            If _autoSizeLabel Then AjustarTamaño()
            Me.Invalidate()
        End Set
    End Property

    Public Property TextoColor As Color
        Get
            Return _textoColor
        End Get
        Set(value As Color)
            _textoColor = value
            Me.Invalidate()
        End Set
    End Property

    Public Property FondoColor As Color
        Get
            Return _fondoColor
        End Get
        Set(value As Color)
            _fondoColor = value
            Me.Invalidate()
        End Set
    End Property

    Public Property TamañoFuente As Integer
        Get
            Return _fontSize
        End Get
        Set(value As Integer)
            _fontSize = value
            Me.Invalidate()
        End Set
    End Property

    Public Property EstiloFuente As FontStyle
        Get
            Return _fontStyle
        End Get
        Set(value As FontStyle)
            _fontStyle = value
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

    Public Property MostrarIconoUnicode As String
        Get
            Return _iconoUnicode
        End Get
        Set(value As String)
            _iconoUnicode = value
            Me.Invalidate()
        End Set
    End Property

    Public Property ColorIcono As Color
        Get
            Return _iconoColor
        End Get
        Set(value As Color)
            _iconoColor = value
            Me.Invalidate()
        End Set
    End Property

    Public Property AutoajustarAncho As Boolean
        Get
            Return _autoSizeLabel
        End Get
        Set(value As Boolean)
            _autoSizeLabel = value
            If value Then AjustarTamaño()
        End Set
    End Property

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim g = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias

        Dim rect = New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)
        Dim path = New GraphicsPath()

        If _borderRadius > 0 Then
            path.AddArc(rect.X, rect.Y, _borderRadius, _borderRadius, 180, 90)
            path.AddArc(rect.Right - _borderRadius, rect.Y, _borderRadius, _borderRadius, 270, 90)
            path.AddArc(rect.Right - _borderRadius, rect.Bottom - _borderRadius, _borderRadius, _borderRadius, 0, 90)
            path.AddArc(rect.X, rect.Bottom - _borderRadius, _borderRadius, _borderRadius, 90, 90)
            path.CloseAllFigures()
            g.FillPath(New SolidBrush(_fondoColor), path)
        Else
            g.FillRectangle(New SolidBrush(_fondoColor), rect)
        End If

        Dim textoFont = New Font("Segoe UI", _fontSize, _fontStyle)
        Dim iconOffset = If(String.IsNullOrEmpty(_iconoUnicode), 0, 20)

        If Not String.IsNullOrEmpty(_iconoUnicode) Then
            TextRenderer.DrawText(g, _iconoUnicode, _fontIcon, New Point(10, (Me.Height - 20) \ 2), _iconoColor)
        End If

        TextRenderer.DrawText(
                g,
                _texto,
                textoFont,
                New Rectangle(10 + iconOffset, 0, Me.Width - (20 + iconOffset), Me.Height),
                _textoColor,
                TextFormatFlags.VerticalCenter Or TextFormatFlags.Left
            )
    End Sub

    Private Sub AjustarTamaño()
        Dim tempLabel As New Label()
        tempLabel.Text = _texto
        tempLabel.Font = New Font("Segoe UI", _fontSize, _fontStyle)
        tempLabel.AutoSize = True
        Me.Width = tempLabel.Width + 30 + If(String.IsNullOrEmpty(_iconoUnicode), 0, 20)
        Me.Height = tempLabel.Height + 10
    End Sub

    'COMO USARLO

    'Dim lblEstado As New LabelWilmerUI()
    'lblEstado.Texto = "🟢 Conectado"
    'lblEstado.FondoColor = Color.LightGreen
    'lblEstado.TextoColor = Color.DarkGreen
    'lblEstado.MostrarIconoUnicode = ChrW(&HF00C) ' fa-check
    'lblEstado.ColorIcono = Color.DarkGreen
    'lblEstado.BorderRadius = 8
    'lblEstado.AutoajustarAncho = True
    'Me.Controls.Add(lblEstado)

End Class
