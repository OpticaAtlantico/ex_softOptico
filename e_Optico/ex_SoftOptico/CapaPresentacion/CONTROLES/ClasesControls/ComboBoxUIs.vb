'Imports System.ComponentModel
'Imports System.Drawing
'Imports System.Drawing.Drawing2D
'Imports System.Windows.Forms

'Public Class ComboBoxUIs
'    Inherits UserControl

'    Private lblTitulo As New Label()
'    Private pnlFondo As New Panel()
'    Private cmbCampo As New ComboBox()
'    Private lblError As New Label()

'    Private _labelText As String = "Seleccionar:"
'    Private _labelColor As Color = Color.WhiteSmoke
'    Private _panelBackColor As Color = Color.FromArgb(80, 94, 129)
'    Private _textColor As Color = Color.WhiteSmoke
'    Private _fontField As Font = New Font("Century Gothic", 12)
'    Private _paddingAll As Integer = 10
'    Private _borderRadius As Integer = 5
'    Private _borderColor As Color = Color.LightGray
'    Private _borderColorError As Color = Color.Firebrick
'    Private _borderSize As Integer = 1

'    Private _campoRequerido As Boolean = True
'    Private _mensajeError As String = "Debe seleccionar una opción."
'    Private _errorVisible As Boolean = False

'    Public Sub New()
'        Me.Size = New Size(300, 100)
'        Me.DoubleBuffered = True
'        Me.BackColor = Color.Transparent

'        lblTitulo.Text = _labelText
'        lblTitulo.Font = New Font(_fontField.FontFamily, _fontField.Size - 2)
'        lblTitulo.ForeColor = _labelColor
'        lblTitulo.Dock = DockStyle.Top
'        lblTitulo.Height = 20

'        pnlFondo.Dock = DockStyle.Top
'        pnlFondo.BackColor = _panelBackColor
'        pnlFondo.Padding = New Padding(_paddingAll)
'        pnlFondo.Height = 37
'        pnlFondo.Margin = Padding.Empty

'        ' === ComboBox ===
'        cmbCampo.FlatStyle = FlatStyle.Flat
'        cmbCampo.DropDownStyle = ComboBoxStyle.DropDownList
'        cmbCampo.Font = _fontField
'        cmbCampo.ForeColor = _textColor
'        cmbCampo.BackColor = _panelBackColor
'        cmbCampo.Width = pnlFondo.Width - (_paddingAll * 2)
'        cmbCampo.Location = New Point(_paddingAll, (pnlFondo.Height - cmbCampo.Height) \ 2)
'        cmbCampo.Anchor = AnchorStyles.Left Or AnchorStyles.Top
'        cmbCampo.DrawMode = DrawMode.OwnerDrawFixed
'        cmbCampo.ItemHeight = 30

'        AddHandler cmbCampo.DrawItem, AddressOf DibujarItem
'        AddHandler cmbCampo.SelectedIndexChanged, AddressOf ValidarCampo

'        pnlFondo.Controls.Add(cmbCampo)

'        lblError.Text = ""
'        lblError.ForeColor = _borderColorError
'        lblError.Dock = DockStyle.Top
'        lblError.Height = 20
'        lblError.Visible = False
'        lblError.TextAlign = ContentAlignment.MiddleRight

'        AddHandler pnlFondo.Paint, AddressOf DibujarPanel

'        Me.Controls.Add(lblError)
'        Me.Controls.Add(pnlFondo)
'        Me.Controls.Add(lblTitulo)

'        AddHandler pnlFondo.Resize, Sub() pnlFondo.Region = New Region(RoundedPath(pnlFondo.ClientRectangle, _borderRadius))
'    End Sub

'    'Private Sub DibujarPanel(sender As Object, e As PaintEventArgs)
'    '    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
'    '    Dim rect = pnlFondo.ClientRectangle
'    '    rect.Inflate(-1, -1)

'    '    Using path As GraphicsPath = RoundedPath(rect, _borderRadius)
'    '        Using fondoBrush As New SolidBrush(_panelBackColor)
'    '            e.Graphics.FillPath(fondoBrush, path)
'    '        End Using
'    '        Dim bordeColor = If(_errorVisible, _borderColorError, _borderColor)
'    '        Using pen As New Pen(bordeColor, _borderSize)
'    '            e.Graphics.DrawPath(pen, path)
'    '        End Using
'    '    End Using

'    '    ' === Flecha personalizada ===
'    '    Dim cy = pnlFondo.Height \ 2
'    '    Dim flecha() As Point = {
'    '        New Point(pnlFondo.Width - 18, cy - 4),
'    '        New Point(pnlFondo.Width - 10, cy - 4),
'    '        New Point(pnlFondo.Width - 14, cy + 2)
'    '    }
'    '    Using brush As New SolidBrush(Color.WhiteSmoke)
'    '        e.Graphics.FillPolygon(brush, flecha)
'    '    End Using
'    'End Sub

'    Protected Overrides Sub OnPaint(pe As PaintEventArgs)
'        pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias

'        Dim rect As New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)
'        Dim shadowRect As New Rectangle(rect.X + 1, rect.Y + 1, rect.Width, rect.Height)
'        Using shadowBrush As New SolidBrush(_shadowColor)
'            pe.Graphics.FillRectangle(shadowBrush, shadowRect)
'        End Using

'        Dim path = RoundedRectanglePath(rect, _borderRadius)

'        Using fondoBrush As New SolidBrush(_backgroundColor)
'            pe.Graphics.FillPath(fondoBrush, path)
'        End Using

'        Dim penColor = If(_hasFocus, _focusColor, _borderColor)
'        Using pen As New Pen(penColor, 1.5F)
'            pe.Graphics.DrawPath(pen, path)
'        End Using

'        ' Texto del ítem seleccionado
'        If Me.SelectedIndex >= 0 Then
'            Dim textRect As New Rectangle(10, 0, Me.Width - 30, Me.Height)
'            TextRenderer.DrawText(pe.Graphics, Me.GetItemText(Me.SelectedItem), Me.Font, textRect, Color.WhiteSmoke, TextFormatFlags.VerticalCenter)
'        End If

'        ' Flecha orbital dibujada manualmente
'        Dim cy = Me.Height \ 2
'        Dim flecha() As Point = {
'            New Point(Me.Width - 18, cy - 4),
'            New Point(Me.Width - 10, cy - 4),
'            New Point(Me.Width - 14, cy + 2)
'        }
'        Using brush As New SolidBrush(Color.WhiteSmoke)
'            pe.Graphics.FillPolygon(brush, flecha)
'        End Using
'    End Sub

'    Private Function RoundedPath(rect As Rectangle, radius As Integer) As GraphicsPath
'        Dim path As New GraphicsPath()
'        path.AddArc(rect.Left, rect.Top, radius, radius, 180, 90)
'        path.AddArc(rect.Right - radius, rect.Top, radius, radius, 270, 90)
'        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
'        path.AddArc(rect.Left, rect.Bottom - radius, radius, radius, 90, 90)
'        path.CloseFigure()
'        Return path
'    End Function

'    Private Sub DibujarItem(sender As Object, e As DrawItemEventArgs)
'        If e.Index < 0 Then Exit Sub
'        Dim seleccionado = (e.State And DrawItemState.Selected) = DrawItemState.Selected
'        Dim fondo = If(seleccionado, Color.LightSkyBlue, Color.White)
'        e.Graphics.FillRectangle(New SolidBrush(fondo), e.Bounds)

'        TextRenderer.DrawText(e.Graphics, cmbCampo.Items(e.Index).ToString(), _fontField, e.Bounds, _textColor, TextFormatFlags.Left Or TextFormatFlags.VerticalCenter)

'        e.DrawFocusRectangle()
'    End Sub

'    Private Sub ValidarCampo(sender As Object, e As EventArgs)
'        If _campoRequerido AndAlso cmbCampo.SelectedIndex = -1 Then
'            lblError.Text = _mensajeError
'            lblError.Visible = True
'            _errorVisible = True
'        Else
'            lblError.Visible = False
'            _errorVisible = False
'        End If
'        pnlFondo.Invalidate()
'    End Sub

'    Public Function EsValido() As Boolean
'        If _campoRequerido AndAlso cmbCampo.SelectedIndex = -1 Then
'            lblError.Text = _mensajeError
'            lblError.Visible = True
'            _errorVisible = True
'            pnlFondo.Invalidate()
'            Return False
'        End If
'        _errorVisible = False
'        lblError.Visible = False
'        pnlFondo.Invalidate()
'        Return True
'    End Function

'    ' === Propiedades ===
'    <Category("WilmerUI")>
'    Public Property LabelText As String
'        Get
'            Return _labelText
'        End Get
'        Set(value As String)
'            _labelText = value
'            lblTitulo.Text = value
'        End Set
'    End Property

'    <Category("WilmerUI")>
'    Public Property LabelColor As Color
'        Get
'            Return _labelColor
'        End Get
'        Set(value As Color)
'            _labelColor = value
'            lblTitulo.ForeColor = value
'        End Set
'    End Property

'    <Category("WilmerUI")>
'    Public Property FontField As Font
'        Get
'            Return _fontField
'        End Get
'        Set(value As Font)
'            _fontField = value
'            cmbCampo.Font = value
'        End Set
'    End Property

'    <Category("WilmerUI")>
'    Public Property CampoRequerido As Boolean
'        Get
'            Return _campoRequerido
'        End Get
'        Set(value As Boolean)
'            _campoRequerido = value
'        End Set
'    End Property

'    <Category("WilmerUI")>
'    Public Property MensajeError As String
'        Get
'            Return _mensajeError
'        End Get
'        Set(value As String)
'            _mensajeError = value
'        End Set
'    End Property

'    <Category("WilmerUI")>
'    Public Property BorderColor As Color
'        Get
'            Return _borderColor
'        End Get
'        Set(value As Color)
'            _borderColor = value
'            pnlFondo.Invalidate()
'        End Set
'    End Property

'    <Category("WilmerUI")>
'    Public Property BorderColorError As Color
'        Get
'            Return _borderColorError
'        End Get
'        Set(value As Color)
'            _borderColorError = value
'        End Set
'    End Property

'    <Category("WilmerUI")>
'    Public Property BorderSize As Integer
'        Get
'            Return _borderSize
'        End Get
'        Set(value As Integer)
'            _borderSize = value
'            pnlFondo.Invalidate()
'        End Set
'    End Property

'    <Category("WilmerUI")>
'    Public Property BorderRadius As Integer
'        Get
'            Return _borderRadius
'        End Get
'        Set(value As Integer)
'            _borderRadius = value
'            pnlFondo.Region = New Region(RoundedPath(pnlFondo.ClientRectangle, _borderRadius))
'            pnlFondo.Invalidate()
'        End Set
'    End Property

'    <Category("WilmerUI")>
'    Public Property PanelBackColor As Color
'        Get
'            Return _panelBackColor
'        End Get
'        Set(value As Color)
'            _panelBackColor = value
'            pnlFondo.BackColor = value
'            cmbCampo.BackColor = value
'            pnlFondo.Invalidate()
'        End Set
'    End Property

'    <Category("WilmerUI")>
'    Public Property TextColor As Color
'        Get
'            Return _textColor
'        End Get
'        Set(value As Color)
'            _textColor = value
'            cmbCampo.ForeColor = value
'            cmbCampo.Invalidate()
'        End Set
'    End Property

'    <Category("WilmerUI")>
'    Public Property ItemsList As ComboBox.ObjectCollection
'        Get
'            Return cmbCampo.Items
'        End Get
'        Set(value As ComboBox.ObjectCollection)
'            cmbCampo.Items.Clear()
'            For Each item In value
'                cmbCampo.Items.Add(item)
'            Next
'        End Set
'    End Property

'    <Category("WilmerUI")>
'    Public ReadOnly Property SelectedTextValue As String
'        Get
'            Return If(cmbCampo.SelectedItem IsNot Nothing, cmbCampo.SelectedItem.ToString(), "")
'        End Get
'    End Property

'End Class
