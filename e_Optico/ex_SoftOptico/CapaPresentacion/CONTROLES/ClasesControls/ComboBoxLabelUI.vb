Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class ComboBoxLabelUI
    Inherits UserControl

    Private lblTitulo As New Label()
    Private pnlFondo As New Panel()
    Private cmbCampo As New ComboBoxUI() ' ← Tu control orbital personalizado
    Private lblError As New Label()

    ' Propiedades internas
    Private _labelText As String = "Selecciona una opción:"
    Private _mensajeError As String = "Este campo es obligatorio."
    Private _campoRequerido As Boolean = True
    Private _colorError As Color = Color.Firebrick

    Private _paddingAll As Integer = 3
    Private _fontField As Font = New Font("Century Gothic", 12)
    Private _panelBackColor As Color = Color.FromArgb(80, 94, 129) ' Color de fondo del panel

    Private _radiusBorde As Integer = 5
    Private _borderColorNormal As Color = Color.WhiteSmoke


    Public Sub New()
        Me.Size = New Size(700, 100)
        Me.DoubleBuffered = True
        Me.BackColor = Color.Transparent

        ' Título arriba
        lblTitulo.Text = _labelText
        lblTitulo.Font = New Font("Century Gothic", 12, FontStyle.Regular)
        lblTitulo.ForeColor = Color.WhiteSmoke
        lblTitulo.Dock = DockStyle.Top
        lblTitulo.Height = 20

        ' Panel con borde orbital
        pnlFondo.Height = 40
        pnlFondo.Width = cmbCampo.Width - 10
        pnlFondo.Dock = DockStyle.Top
        pnlFondo.BackColor = _panelBackColor
        pnlFondo.Padding = New Padding(_paddingAll)
        AddHandler pnlFondo.Paint, AddressOf DibujarFondoRedondeado

        ' ComboBoxUI dentro del panel
        cmbCampo.Dock = DockStyle.Fill
        cmbCampo.BorderColor = _panelBackColor
        cmbCampo.FocusColor = Color.DeepSkyBlue
        cmbCampo.BackgroundColor = _panelBackColor
        cmbCampo.TextColor = Color.WhiteSmoke
        pnlFondo.Controls.Add(cmbCampo)

        ' Mensaje de error debajo
        lblError.Text = ""
        lblError.ForeColor = _colorError
        lblError.Dock = DockStyle.Top
        lblError.Height = 20
        lblError.Visible = False

        Me.Controls.Add(lblError)
        Me.Controls.Add(pnlFondo)
        Me.Controls.Add(lblTitulo)

        ' Eventos orbitales
        AddHandler cmbCampo.SelectedIndexChanged, AddressOf ValidarCampo
        AddHandler cmbCampo.LostFocus, AddressOf ValidarCampo
        AddHandler pnlFondo.Resize, Sub()
                                        pnlFondo.Region = New Region(RoundedPath(pnlFondo.ClientRectangle, _radiusBorde))
                                        'pnlFondo.Invalidate()
                                    End Sub
    End Sub

    Private Sub DibujarFondoRedondeado(sender As Object, e As PaintEventArgs)
        'If _borderFlat Then
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
            Dim rect = pnlFondo.ClientRectangle
            rect.Inflate(-1, -1)

            Using path As GraphicsPath = RoundedPath(rect, _radiusBorde)
                Using brush As New SolidBrush(pnlFondo.BackColor)
                    e.Graphics.FillPath(brush, path)
                End Using
                Using pen As New Pen(_borderColorNormal, 1)
                    e.Graphics.DrawPath(pen, path)
                End Using
            End Using
        'End If
    End Sub
    Private Sub ValidarCampo(sender As Object, e As EventArgs)
        If _campoRequerido Then
            If cmbCampo.SelectedIndex < 0 Then
                lblError.Text = _mensajeError
                lblError.Visible = True
                cmbCampo.BorderColor = _colorError
            Else
                lblError.Visible = False
                cmbCampo.BorderColor = Color.Silver
            End If
        End If
        pnlFondo.Invalidate()
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
    Public Property MensajeError As String
        Get
            Return _mensajeError
        End Get
        Set(value As String)
            _mensajeError = value
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

    <Category("UI Estilo")>
    Public Property BorderRadius As Integer
        Get
            Return _radiusBorde
        End Get
        Set(value As Integer)
            _radiusBorde = value
            pnlFondo.Invalidate()
            pnlFondo.Region = New Region(RoundedPath(pnlFondo.ClientRectangle, _radiusBorde))
        End Set
    End Property

    <Category("UI Estilo")>
    Public Property FontField As Font
        Get
            Return _fontField
        End Get
        Set(value As Font)
            _fontField = value
            lblTitulo.Font = value
            lblError.Font = New Font(value.FontFamily, value.Size - 3)
        End Set
    End Property

    <Browsable(False)>
    Public ReadOnly Property ComboControl As ComboBoxUI
        Get
            Return cmbCampo
        End Get
    End Property

    <Browsable(False)>
    Public ReadOnly Property SelectedValue As Object
        Get
            Return cmbCampo.SelectedValue
        End Get
    End Property

End Class