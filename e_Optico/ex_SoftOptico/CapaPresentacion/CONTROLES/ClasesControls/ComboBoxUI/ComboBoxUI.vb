Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class ComboBoxUI
    Inherits ComboBox

    Public Enum BorderState
        Normal
        Focus
        Success
        ErrorState
    End Enum

    Private _borderColor As Color = AppColors._cBorde
    Private _focusColor As Color = AppColors._cBordeSel
    Private _successColor As Color = AppColors._cBaseSuccess
    Private _errorColor As Color = AppColors._cBordeError

    Private _borderRadius As Integer = AppLayout.BorderRadiusStandar
    Private _backgroundColor As Color = AppColors._cBlanco
    Private _textColor As Color = AppColors._cTexto

    Private _shadowColor As Color = AppColors._cPanelSombracolor
    Private _shadowSize As Integer = 3

    Private _state As BorderState = BorderState.Normal

#Region "CONSTRUCTOR"
    Public Sub New()
        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor Or
                    ControlStyles.UserPaint Or
                    ControlStyles.AllPaintingInWmPaint Or
                    ControlStyles.OptimizedDoubleBuffer, True)
        Me.UpdateStyles()
        Me.DrawMode = DrawMode.OwnerDrawFixed
        Me.DropDownStyle = ComboBoxStyle.DropDownList
        Me.Font = New Font(AppFonts.Century, AppFonts.SizeMedium, AppFonts.Regular)
        Me.ItemHeight = 30
        Me.FlatStyle = FlatStyle.Flat
        Me.ForeColor = AppColors._cTexto
        Me.Size = New Size(300, 36)
    End Sub
#End Region

#Region "PROPIEDADES"
    ' Propiedades orbitales
    <Category("UI Estilo")>
    Public Property BorderMode As BorderState
        Get
            Return _state
        End Get
        Set(value As BorderState)
            _state = value
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

    Public Property ValorSeleccionado As String
        Get
            Return If(Me.SelectedItem IsNot Nothing, Me.SelectedItem.ToString(), "")
        End Get
        Set(value As String)
            Me.SelectedItem = value
        End Set
    End Property

    Public ReadOnly Property ValorClave As Object
        Get
            If Me.SelectedItem IsNot Nothing AndAlso TypeOf Me.SelectedItem Is LlenarComboBox.ComboItem Then
                Return CType(Me.SelectedItem, LlenarComboBox.ComboItem).Valor
            End If
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property ValorTexto As String
        Get
            If Me.SelectedItem IsNot Nothing AndAlso TypeOf Me.SelectedItem Is LlenarComboBox.ComboItem Then
                Return CType(Me.SelectedItem, LlenarComboBox.ComboItem).Texto
            End If
            Return Me.Text
        End Get
    End Property

    <Category("UI Estilo")>
    Public Property SuccessColor As Color
        Get
            Return _successColor
        End Get
        Set(value As Color)
            _successColor = value
            Me.Invalidate()
        End Set
    End Property

    <Category("UI Estilo")>
    Public Property ErrorColor As Color
        Get
            Return _errorColor
        End Get
        Set(value As Color)
            _errorColor = value
            Me.Invalidate()
        End Set
    End Property
#End Region

#Region "DIBUJO"

    Protected Overrides Sub OnPaint(pe As PaintEventArgs)
        pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        Dim r = Math.Min(_borderRadius, Math.Min(Me.Width, Me.Height) \ 2)

        ' Rect principal (card)
        Dim rect As New Rectangle(0, 0, Me.Width - 3, Me.Height - 3)

        ' 🔹 Sombra redondeada tipo BaseTextBoxUI
        If _shadowSize > 0 Then
            Dim shadowRect As New Rectangle(rect.X + 3, rect.Y + 3, rect.Width, rect.Height)
            Using pathShadow As GraphicsPath = RoundedRectanglePath(shadowRect, r)
                Using brushShadow As New SolidBrush(_shadowColor)
                    pe.Graphics.FillPath(brushShadow, pathShadow)
                End Using
            End Using
        End If

        ' 🔹 Fondo del control
        Using pathCard As GraphicsPath = RoundedRectanglePath(rect, r)
            Using fondoBrush As New SolidBrush(_backgroundColor)
                pe.Graphics.FillPath(fondoBrush, pathCard)
            End Using

            ' 🔹 Borde según estado
            Dim penColor As Color
            Select Case _state
                Case BorderState.Focus : penColor = _focusColor
                Case BorderState.Success : penColor = _successColor
                Case BorderState.ErrorState : penColor = _errorColor
                Case Else : penColor = _borderColor
            End Select

            Using pen As New Pen(penColor, 1)
                pe.Graphics.DrawPath(pen, pathCard)
            End Using
        End Using

        ' 🔹 Texto del ítem seleccionado
        If Me.SelectedIndex >= 0 Then
            Dim textRect As New Rectangle(10, 0, Me.Width - 30, Me.Height)
            TextRenderer.DrawText(pe.Graphics,
                                  Me.GetItemText(Me.SelectedItem),
                                  Me.Font,
                                  textRect,
                                  _textColor,
                                  TextFormatFlags.VerticalCenter)
        End If

        ' 🔹 Flecha orbital personalizada
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
        Using bordePen As New Pen(_borderColor)
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
#End Region

#Region "EVENTOS INTERNOS"
    Protected Overrides Sub OnGotFocus(e As EventArgs)
        MyBase.OnGotFocus(e)
        Me.BorderMode = BorderState.Focus
    End Sub

    Protected Overrides Sub OnLostFocus(e As EventArgs)
        MyBase.OnLostFocus(e)
        If Me.SelectedIndex >= 0 Then
            Me.BorderMode = BorderState.Success
        Else
            Me.BorderMode = BorderState.Normal
        End If
    End Sub
#End Region

#Region "PROCEDIMIENTOS"
    Public Sub AddItem(item As Object)
        Me.Items.Add(item)
    End Sub

#End Region

End Class
'empleado.EstadoCivil = cmbEstadoCivilUI.ValorClave?.ToString()