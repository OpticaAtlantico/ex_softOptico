Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Threading.Tasks
Imports System.Windows.Forms

Public Class SelectUI
    Inherits Control

    ' 🧩 Propiedades internas
    Private _items As New List(Of String)()
    Private _filteredItems As New List(Of String)()
    Private _selectedItem As String = ""
    Private _textColor As Color = AppColors._cTexto
    Private _borderRadius As Integer = AppLayout.BorderRadiusStandar
    Private _colorInternoFondo As Color = AppColors._cBlanco
    Private _borderColor As Color = AppColors._cBasePrimary

    ' 🎯 Controles visuales
    Private listaVisual As New ListBox()
    Private buscador As New TextBox()
    Private panelLista As Form
    Private desplegado As Boolean = False

#Region "PROPIEDADES"
    ' 📦 Propiedades públicas
    <Category("UI Orbital")> Public Property Items As List(Of String)
        Get
            Return _items
        End Get
        Set(value As List(Of String))
            _items = value
            _filteredItems = New List(Of String)(value)
            If Not value.Contains(_selectedItem) Then _selectedItem = ""
            ActualizarListaVisual()
        End Set
    End Property

    <Category("UI Orbital")> Public Property SelectedItem As String
        Get
            Return _selectedItem
        End Get
        Set(value As String)
            _selectedItem = value
            Me.Invalidate()
        End Set
    End Property

    <Category("UI Orbital")> Public Property TextColor As Color
        Get
            Return _textColor
        End Get
        Set(value As Color)
            _textColor = value
            Me.Invalidate()
        End Set
    End Property

    <Category("UI Orbital")> Public Property BorderRadius As Integer
        Get
            Return _borderRadius
        End Get
        Set(value As Integer)
            _borderRadius = value
            Me.Invalidate()
        End Set
    End Property

    <Category("UI Orbital")> Public Property ColorInternoFondo As Color
        Get
            Return _colorInternoFondo
        End Get
        Set(value As Color)
            _colorInternoFondo = value
            Me.Invalidate()
        End Set
    End Property

    <Category("UI Orbital")> Public Property BorderColor As Color
        Get
            Return _borderColor
        End Get
        Set(value As Color)
            _borderColor = value
            Me.Invalidate()
        End Set
    End Property
#End Region

#Region "CONSTRUCTOR"
    Public Sub New()
        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor Or
                    ControlStyles.UserPaint Or
                    ControlStyles.AllPaintingInWmPaint Or
                    ControlStyles.OptimizedDoubleBuffer, True)
        Me.UpdateStyles()
        Me.Size = New Size(250, 36)
        Me.Font = New Font(AppFonts.Century, AppFonts.SizeSmall)
        Me.BackColor = Color.Transparent

        buscador.Font = Me.Font
        buscador.BorderStyle = BorderStyle.FixedSingle
        buscador.BackColor = AppColors._cHoverInfo
        AddHandler buscador.TextChanged, AddressOf FiltrarLista

        listaVisual.Font = Me.Font
        listaVisual.BorderStyle = BorderStyle.None
        listaVisual.BackColor = AppColors._cTexto
        listaVisual.ItemHeight = 28
        AddHandler listaVisual.Click, AddressOf SeleccionarItem

        AddHandler Me.Click, AddressOf ToggleLista
    End Sub
#End Region



    ' 🎨 Fondo orbital simulado
    Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
        If Me.Parent IsNot Nothing Then
            Using b As New SolidBrush(Me.Parent.BackColor)
                e.Graphics.FillRectangle(b, Me.ClientRectangle)
            End Using
        Else
            MyBase.OnPaintBackground(e)
        End If
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect = New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)
        Using path = RoundedPath(rect, _borderRadius)
            Using fondoBrush As New SolidBrush(_colorInternoFondo)
                e.Graphics.FillPath(fondoBrush, path)
            End Using
            Using pen As New Pen(_borderColor, 1.5F)
                e.Graphics.DrawPath(pen, path)
            End Using
        End Using

        TextRenderer.DrawText(e.Graphics, _selectedItem, Me.Font, New Point(12, 8), _textColor)

        Dim flecha() As Point = {
            New Point(Me.Width - 18, Me.Height \ 2 - 3),
            New Point(Me.Width - 10, Me.Height \ 2 - 3),
            New Point(Me.Width - 14, Me.Height \ 2 + 4)
        }
        Using flechaBrush As New SolidBrush(_textColor)
            e.Graphics.FillPolygon(flechaBrush, flecha)
        End Using
    End Sub

    Private Async Sub ToggleLista(sender As Object, e As EventArgs)
        If Not desplegado Then
            If panelLista Is Nothing OrElse panelLista.IsDisposed Then
                panelLista = New Form() With {
                    .FormBorderStyle = FormBorderStyle.None,
                    .ShowInTaskbar = False,
                    .StartPosition = FormStartPosition.Manual,
                    .TopMost = True,
                    .BackColor = _colorInternoFondo,
                    .Width = Me.Width,
                    .Height = 230,
                    .Location = Me.PointToScreen(New Point(0, Me.Height)),
                    .Opacity = 0
                }

                buscador.Dock = DockStyle.Top
                listaVisual.Dock = DockStyle.Fill
                ActualizarListaVisual()

                Dim container As New Panel With {.Dock = DockStyle.Fill, .BackColor = _colorInternoFondo}
                container.Controls.Add(listaVisual)
                container.Controls.Add(buscador)
                panelLista.Controls.Add(container)
            End If

            panelLista.Show()
            buscador.Text = ""
            buscador.Focus()
            desplegado = True

            For i As Double = 0 To 1 Step 0.05
                Await Task.Delay(10)
                panelLista.Opacity = i
            Next
        Else
            Await OcultarLista()
        End If
    End Sub

    Private Async Function OcultarLista() As Task
        If panelLista IsNot Nothing AndAlso Not panelLista.IsDisposed AndAlso panelLista.Visible Then
            For i As Double = panelLista.Opacity To 0 Step -0.05
                Await Task.Delay(10)
                panelLista.Opacity = i
            Next
            panelLista.Hide()
            panelLista.Controls.Clear()
            desplegado = False
        End If
    End Function

    Private Async Sub SeleccionarItem(sender As Object, e As EventArgs)
        If listaVisual.SelectedItem IsNot Nothing Then
            Me.Focus()
            Dim seleccionado = listaVisual.SelectedItem.ToString()
            Await OcultarLista()
            _selectedItem = seleccionado
            Me.Invalidate()
        End If
    End Sub

    Private Sub FiltrarLista(sender As Object, e As EventArgs)
        Dim filtro = buscador.Text.Trim().ToLower()
        _filteredItems = _items.Where(Function(i) i.ToLower().Contains(filtro)).ToList()
        ActualizarListaVisual()
    End Sub

    Private Sub ActualizarListaVisual()
        If listaVisual IsNot Nothing Then
            listaVisual.Items.Clear()
            listaVisual.Items.AddRange(_filteredItems.ToArray())
        End If
    End Sub

    Private Function RoundedPath(rect As Rectangle, radius As Integer) As GraphicsPath
        Dim path As New GraphicsPath()
        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90)
        path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90)
        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
        path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90)
        path.CloseFigure()
        Return path
    End Function
End Class


''Como usarlo

''Dim categoriaUI As New SelectUI()
''categoriaUI.Items = New List(Of String) From {"General", "Administración", "Seguridad", "Desarrollo"}
''categoriaUI.SelectedItem = "General"
''categoriaUI.ColorInternoFondo = Color.FromArgb(240, 240, 240)
''Me.Controls.Add(categoriaUI)