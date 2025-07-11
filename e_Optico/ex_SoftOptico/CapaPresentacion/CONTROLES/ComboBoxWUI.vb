Imports System.Drawing.Drawing2D
Imports System.Drawing
Imports System.Windows.Forms
Public Class ComboBoxWUI
    Inherits UserControl

    Private _combo As New ComboBox()
    Private _borderColor As Color = Color.Gray
    Private _focusColor As Color = Color.DeepSkyBlue
    Private _borderRadius As Integer = 6
    Private _shadowColor As Color = Color.FromArgb(40, Color.Black)
    Private _backgroundColor As Color = Color.White
    Private _textColor As Color = Color.Black
    Private _hasFocus As Boolean = False

    Public Sub New()
        Me.Size = New Size(297, 35)
        Me.BackColor = Color.Transparent
        Me.DoubleBuffered = True

        _combo.DropDownStyle = ComboBoxStyle.DropDownList
        _combo.FlatStyle = FlatStyle.Flat
        _combo.Font = New Font("Segoe UI", 10)
        _combo.ForeColor = _textColor
        _combo.BackColor = _backgroundColor
        _combo.Width = Me.Width - 20
        _combo.Location = New Point(10, 8)
        Me.Controls.Add(_combo)

        AddHandler _combo.GotFocus, Sub()
                                        _hasFocus = True
                                        Me.Invalidate()
                                    End Sub
        AddHandler _combo.LostFocus, Sub()
                                         _hasFocus = False
                                         Me.Invalidate()
                                     End Sub
    End Sub

    ' 🎛 Propiedades públicas

    Public Property BorderColor As Color
        Get
            Return _borderColor
        End Get
        Set(value As Color)
            _borderColor = value
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
            _combo.BackColor = value
            Me.Invalidate()
        End Set
    End Property

    Public Property TextColor As Color
        Get
            Return _textColor
        End Get
        Set(value As Color)
            _textColor = value
            _combo.ForeColor = value
            Me.Invalidate()
        End Set
    End Property

    Public ReadOnly Property ComboRef As ComboBox
        Get
            Return _combo
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
        Dim penColor = If(_hasFocus, _focusColor, _borderColor)
        Using pen As New Pen(penColor, 1.5F)
            g.DrawPath(pen, path)
        End Using
    End Sub

    'Dim cmbEstado As New ComboBoxUI()
    'cmbEstado.Location = New Point(20, 100)
    'cmbEstado.ComboRef.Items.AddRange({"Soltero", "Casado", "Viudo"})
    'cmbEstado.ComboRef.SelectedIndex = 0
    'cmbEstado.FocusColor = Color.DeepSkyBlue
    'Me.Controls.Add(cmbEstado)

End Class
