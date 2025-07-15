Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class TextBoxLabelUI
    Inherits UserControl

    Private lblTitulo As New Label()
    Private pnlFondo As New Panel()
    Private txtCampo As New TextBox()
    Private lblError As New Label()

    ' Estilo general
    Private _labelText As String = "Texto:"
    Private _panelBackColor As Color = Color.FromArgb(80, 94, 129) ' Color de fondo del panel
    Private _textColor As Color = Color.WhiteSmoke
    Private _fontField As Font = New Font("Century Gothic", 12)
    Private _paddingAll As Integer = 10
    Private _alturaMultilinea As Integer = 80

    ' Placeholder
    Private _placeholderText As String = "Escribe algo..."
    Private _placeholderColor As Color = Color.Gray
    Private _placeholderFont As Font = New Font("Century Gothic", 12, FontStyle.Italic)

    ' Validación
    Private _campoRequerido As Boolean = True
    Private _colorError As Color = Color.Firebrick
    Private _mensajeError As String = "Este campo es obligatorio."

    ' Borde visual
    Private _borderRadius As Integer = 5
    Private _borderFlat As Boolean = True
    Private _borderColorNormal As Color = Color.LightGray

    Public Sub New()
        Me.Size = New Size(300, 100)
        Me.DoubleBuffered = True
        Me.BackColor = Color.Transparent

        ' === Etiqueta principal (título) ===
        lblTitulo.Text = _labelText
        lblTitulo.Font = New Font(_fontField.FontFamily, _fontField.Size + 1, FontStyle.Regular, unit:=GraphicsUnit.Point)
        lblTitulo.ForeColor = Color.WhiteSmoke
        lblTitulo.Height = 20
        lblTitulo.Dock = DockStyle.Top

        ' === Panel contenedor del TextBox ===
        pnlFondo.Height = 37
        pnlFondo.Dock = DockStyle.Top
        pnlFondo.BackColor = _panelBackColor
        pnlFondo.Padding = New Padding(_paddingAll)
        AddHandler pnlFondo.Paint, AddressOf DibujarFondoRedondeado

        ' === TextBox central ===
        txtCampo.BorderStyle = BorderStyle.None
        txtCampo.Font = _fontField
        txtCampo.ForeColor = _textColor
        txtCampo.BackColor = _panelBackColor
        txtCampo.Multiline = False
        txtCampo.Anchor = AnchorStyles.None
        txtCampo.TextAlign = HorizontalAlignment.Left
        pnlFondo.Controls.Add(txtCampo)

        ' === Etiqueta de error ===
        lblError.Text = ""
        lblError.ForeColor = _colorError
        lblError.Height = 20
        lblError.Dock = DockStyle.Top
        lblError.Visible = False

        ' === Agrega controles en el orden correcto ===
        Me.Controls.Add(lblError)    ' Abajo
        Me.Controls.Add(pnlFondo)    ' Centro
        Me.Controls.Add(lblTitulo)   ' Arriba

        ' === Eventos ===
        AddHandler pnlFondo.Paint, AddressOf DibujarPlaceholder
        AddHandler txtCampo.TextChanged, AddressOf ActualizarEstado
        AddHandler txtCampo.LostFocus, AddressOf ValidarCampo
        AddHandler Me.Resize, AddressOf CentrarTextBox
        AddHandler pnlFondo.Resize, AddressOf CentrarTextBox
        AddHandler pnlFondo.Resize, Sub(sender, e)
                                        pnlFondo.Region = New Region(RoundedPath(pnlFondo.ClientRectangle, _borderRadius))
                                    End Sub

        CentrarTextBox(Nothing, Nothing)
    End Sub

    Private Sub CentrarTextBox(sender As Object, e As EventArgs)
        Dim ancho = pnlFondo.ClientSize.Width - (_paddingAll * 2)
        Dim alto = 30
        txtCampo.Size = New Size(ancho, alto)

        Dim posX = (pnlFondo.ClientSize.Width - txtCampo.Width) \ 2
        Dim posY = (pnlFondo.ClientSize.Height - txtCampo.Height) \ 2
        txtCampo.Location = New Point(posX, posY)
    End Sub

    Private Sub ValidarCampo(sender As Object, e As EventArgs)
        If _campoRequerido Then
            If String.IsNullOrWhiteSpace(txtCampo.Text) Then
                lblError.Text = _mensajeError
                lblError.Visible = True
                _borderColorNormal = _colorError
            Else
                lblError.Visible = False
                _borderColorNormal = Color.LightGray
            End If
            pnlFondo.Invalidate()
        End If
    End Sub

    Private Sub ActualizarEstado(sender As Object, e As EventArgs)
        If lblError.Visible AndAlso Not String.IsNullOrWhiteSpace(txtCampo.Text) Then
            lblError.Visible = False
            _borderColorNormal = Color.LightGray
            pnlFondo.Invalidate()
        End If
        txtCampo.Invalidate() ' Actualiza placeholder si necesario
    End Sub

    Private Sub DibujarFondoRedondeado(sender As Object, e As PaintEventArgs)
        'If _borderFlat Then
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
            Dim rect = pnlFondo.ClientRectangle
            rect.Inflate(-1, -1)

            Using path As GraphicsPath = RoundedPath(rect, _borderRadius)
                Using brush As New SolidBrush(pnlFondo.BackColor)
                    e.Graphics.FillPath(brush, path)
                End Using
                Using pen As New Pen(_borderColorNormal, 1)
                    e.Graphics.DrawPath(pen, path)
                End Using
            End Using
        'End If
    End Sub

    Private Function RoundedPath(rect As Rectangle, radius As Integer) As GraphicsPath
        Dim path As New GraphicsPath()
        path.AddArc(rect.Left, rect.Top, radius, radius, 180, 90)
        path.AddArc(rect.Right - radius, rect.Top, radius, radius, 270, 90)
        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
        path.AddArc(rect.Left, rect.Bottom - radius, radius, radius, 90, 90)
        path.CloseFigure()
        Return path
    End Function

    Private Sub AjustarAlturaCampo()
        If txtCampo.Multiline Then
            pnlFondo.Height = AlturaMultilinea ' Puedes ajustar esta altura orbital según estilo
            txtCampo.TextAlign = HorizontalAlignment.Left
            txtCampo.ScrollBars = ScrollBars.Vertical 'Opcional
        Else
            pnlFondo.Height = 37
            txtCampo.TextAlign = HorizontalAlignment.Left
            txtCampo.ScrollBars = ScrollBars.None 'Opcional
        End If
    End Sub

    Private Sub DibujarPlaceholder(sender As Object, e As PaintEventArgs)
        If String.IsNullOrEmpty(txtCampo.Text) AndAlso Not txtCampo.Focused AndAlso Not String.IsNullOrEmpty(_placeholderText) Then
            Dim rectTexto As New Rectangle(txtCampo.Location, txtCampo.Size)

            Dim formato As New StringFormat With {
            .Alignment = StringAlignment.Near,
            .LineAlignment = StringAlignment.Center
        }

            Using pincel As New SolidBrush(_placeholderColor)
                e.Graphics.DrawString(_placeholderText, _placeholderFont, pincel, rectTexto, formato)
            End Using
        End If
    End Sub

    <Category("UI Estilo")>
    Public Property LabelText As String
        Get
            Return _labelText
        End Get
        Set(value As String)
            _labelText = value
            lblTitulo.Text = value
        End Set
    End Property

    <Category("UI Estilo")>
    Public Property PanelBackColor As Color
        Get
            Return _panelBackColor
        End Get
        Set(value As Color)
            _panelBackColor = value
            pnlFondo.BackColor = value
            txtCampo.BackColor = value
        End Set
    End Property

    <Category("UI Estilo")>
    Public Property TextColor As Color
        Get
            Return _textColor
        End Get
        Set(value As Color)
            _textColor = value
            txtCampo.ForeColor = value
        End Set
    End Property

    <Category("UI Estilo")>
    Public Property FontField As Font
        Get
            Return _fontField
        End Get
        Set(value As Font)
            _fontField = value
            txtCampo.Font = value
            lblTitulo.Font = value
            lblError.Font = New Font(value.FontFamily, value.Size - 3)
        End Set
    End Property

    <Category("UI Estilo")>
    Public Property PaddingAll As Integer
        Get
            Return _paddingAll
        End Get
        Set(value As Integer)
            _paddingAll = value
            pnlFondo.Padding = New Padding(_paddingAll)
            CentrarTextBox(Nothing, Nothing)
        End Set
    End Property

    <Category("Placeholder")>
    Public Property PlaceholderText As String
        Get
            Return _placeholderText
        End Get
        Set(value As String)
            _placeholderText = value
            txtCampo.Invalidate()
        End Set
    End Property

    <Category("Placeholder")>
    Public Property PlaceholderColor As Color
        Get
            Return _placeholderColor
        End Get
        Set(value As Color)
            _placeholderColor = value
            txtCampo.Invalidate()
        End Set
    End Property

    <Category("Placeholder")>
    Public Property PlaceholderFont As Font
        Get
            Return _placeholderFont
        End Get
        Set(value As Font)
            _placeholderFont = value
            txtCampo.Invalidate()
        End Set
    End Property

    <Category("Validación")>
    Public Property CampoRequerido As Boolean
        Get
            Return _campoRequerido
        End Get
        Set(value As Boolean)
            _campoRequerido = value
        End Set
    End Property

    <Category("Validación")>
    Public Property ColorError As Color
        Get
            Return _colorError
        End Get
        Set(value As Color)
            _colorError = value
            lblError.ForeColor = value
        End Set
    End Property

    <Category("Validación")>
    Public Property MensajeError As String
        Get
            Return _mensajeError
        End Get
        Set(value As String)
            _mensajeError = value
            lblError.Text = value
        End Set
    End Property

    <Category("UI Estilo")>
    Public Property BorderRadius As Integer
        Get
            Return _borderRadius
        End Get
        Set(value As Integer)
            _borderRadius = value
            pnlFondo.Invalidate()
            pnlFondo.Region = New Region(RoundedPath(pnlFondo.ClientRectangle, _borderRadius))
        End Set
    End Property

    <Category("UI Estilo")>
    Public Property BorderFlat As Boolean
        Get
            Return _borderFlat
        End Get
        Set(value As Boolean)
            _borderFlat = value
            pnlFondo.Invalidate()
        End Set
    End Property

    <Category("UI Estilo")>
    Public Property Multilinea As Boolean
        Get
            Return txtCampo.Multiline
        End Get
        Set(value As Boolean)
            txtCampo.Multiline = value
            AjustarAlturaCampo()
            CentrarTextBox(Nothing, Nothing)
            txtCampo.Invalidate()
        End Set
    End Property

    <Category("UI Estilo")>
    Public Property AlturaMultilinea As Integer
        Get
            Return _alturaMultilinea
        End Get
        Set(value As Integer)
            _alturaMultilinea = value
            AjustarAlturaCampo()
            pnlFondo.Invalidate()
            Me.Invalidate()
        End Set
    End Property

    Public ReadOnly Property TextValue As String
        Get
            Return txtCampo.Text
        End Get
    End Property

End Class
