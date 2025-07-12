Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class SelectUI
    Inherits Control

    Private _items As New List(Of String)()
    Private _selectedItem As String = ""
    Private _backgroundColor As Color = Color.White
    Private _textColor As Color = Color.Black
    Private _hoverColor As Color = Color.LightSkyBlue
    Private _selectedColor As Color = Color.DeepSkyBlue
    Private _borderRadius As Integer = 6
    Private listaVisual As New ListBox()
    Private desplegado As Boolean = False
    Private panelLista As Form

    Public Sub New()
        Me.DoubleBuffered = True
        Me.Size = New Size(250, 36)
        Me.Font = New Font("Century Gothic", 11)
        Me.BackColor = Color.Transparent

        listaVisual.Font = Me.Font
        listaVisual.BorderStyle = BorderStyle.None
        listaVisual.BackColor = _backgroundColor
        listaVisual.ForeColor = _textColor
        listaVisual.ItemHeight = 28

        AddHandler Me.Click, AddressOf ToggleLista
        AddHandler listaVisual.Click, AddressOf SeleccionarItem
    End Sub

    <Category("UI Estilo")>
    Public Property Items As List(Of String)
        Get
            Return _items
        End Get
        Set(value As List(Of String))
            _items = value
            listaVisual.Items.Clear()
            listaVisual.Items.AddRange(value.ToArray())
        End Set
    End Property

    <Category("UI Estilo")>
    Public Property SelectedItem As String
        Get
            Return _selectedItem
        End Get
        Set(value As String)
            _selectedItem = value
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
            listaVisual.BackColor = value
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
            listaVisual.ForeColor = value
            Me.Invalidate()
        End Set
    End Property

    <Category("UI Estilo")>
    Public Property ItemHoverColor As Color
        Get
            Return _hoverColor
        End Get
        Set(value As Color)
            _hoverColor = value
        End Set
    End Property

    <Category("UI Estilo")>
    Public Property SelectedItemColor As Color
        Get
            Return _selectedColor
        End Get
        Set(value As Color)
            _selectedColor = value
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

    Public Sub AplicarEstiloDesdeTema()
        Me.BackgroundColor = ThemeManagerUI.ColorFondoBase
        Me.TextColor = ThemeManagerUI.ColorTextoBase
        Me.SelectedItemColor = ThemeManagerUI.ColorPrimario
        Me.ItemHoverColor = ThemeManagerUI.ColorBorde
        Me.Invalidate()
    End Sub

    Private Async Sub ToggleLista(sender As Object, e As EventArgs)
        If Not desplegado Then
            panelLista = New Form()
            panelLista.FormBorderStyle = FormBorderStyle.None
            panelLista.ShowInTaskbar = False
            panelLista.StartPosition = FormStartPosition.Manual
            panelLista.TopMost = True
            panelLista.BackColor = _backgroundColor
            panelLista.Width = Me.Width
            panelLista.Height = Math.Min(200, _items.Count * 28)
            panelLista.Location = Me.PointToScreen(New Point(0, Me.Height))
            panelLista.Opacity = 0

            listaVisual.Dock = DockStyle.Fill
            listaVisual.Items.Clear()
            listaVisual.Items.AddRange(_items.ToArray())

            panelLista.Controls.Add(listaVisual)
            panelLista.Show()

            ' Fade in suave
            For i As Double = 0 To 1 Step 0.05
                Await Task.Delay(10)
                panelLista.Opacity = i
            Next

            desplegado = True
        Else
            OcultarLista()
        End If
    End Sub

    Private Async Sub OcultarLista()
        If panelLista IsNot Nothing Then
            For i As Double = panelLista.Opacity To 0 Step -0.05
                Await Task.Delay(10)
                panelLista.Opacity = i
            Next

            panelLista.Close()
            panelLista.Dispose()
            desplegado = False
        End If
    End Sub


    Private Sub SeleccionarItem(sender As Object, e As EventArgs)
        If listaVisual.SelectedItem IsNot Nothing Then
            _selectedItem = listaVisual.SelectedItem.ToString()
            OcultarLista()
            Me.Invalidate()
        End If
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect = New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)
        Dim path = RoundedPath(rect, _borderRadius)

        Using fondoBrush As New SolidBrush(_backgroundColor)
            e.Graphics.FillPath(fondoBrush, path)
        End Using

        Using pen As New Pen(_selectedColor, 1.5F)
            e.Graphics.DrawPath(pen, path)
        End Using

        ' Texto seleccionado
        TextRenderer.DrawText(e.Graphics, _selectedItem, Me.Font, New Point(12, 8), _textColor)

        ' Flecha decorativa
        Dim flecha() As Point = {
            New Point(Me.Width - 18, Me.Height \ 2 - 3),
            New Point(Me.Width - 10, Me.Height \ 2 - 3),
            New Point(Me.Width - 14, Me.Height \ 2 + 4)
        }
        Using flechaBrush As New SolidBrush(_textColor)
            e.Graphics.FillPolygon(flechaBrush, flecha)
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

    'Como se usa el control, se debe agregar al formulario o contenedor deseado.

    'Dim selectCategoria As New SelectUI()
    'selectCategoria.Items = New List(Of String) From {"General", "Administración", "Seguridad", "Desarrollo"}
    'selectCategoria.SelectedItem = "General"
    'Me.Controls.Add(selectCategoria)

End Class