Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports FontAwesome.Sharp

Public Class BaseComboBoxUI
    Inherits UserControl

#Region "CONTROLES Y ESTÉTICA"
    ' === Controles internos ===
    Protected Friend lblTitulo As New Label()
    Public cmbCampo As New ComboBoxUI()
    Protected Friend lblError As New Label()
    Protected Friend pnlFondo As New Panel()
    Protected Friend iconoDerecha As New IconPictureBox()
    Protected Friend lblPlaceholder As New Label()

    ' === Estética ===
    Private _borderColor As Color = AppColors._cBasePrimary
    Private _borderColorFocus As Color = AppColors._cBordeSel
    Private _borderColorError As Color = AppColors._cBordeError
    Private _borderSize As Integer = AppLayout.BorderSizeMediun
    Private _borderRadius As Integer = AppLayout.BorderRadiusStandar
    Private _mostrarError As Boolean = False
    Private _shadowColor As Color = AppColors._cPanelSombracolor
    Private _shadowSize As Integer = 3

    ' === Colores y fuentes ===
    Private _labelColor As Color = AppColors._cLabel
    Private _panelBackColor As Color = AppColors._cBlanco
    Private _sombraBackColor As Color = AppColors._cSombra
    Private _textColor As Color = AppColors._cTexto
    Private _colorError As Color = AppColors._cMsgError

    Private _fontFieldTexto As Font = New Font(AppFonts.Century, AppFonts.SizeMedium)
    Private _fontFieldTitulo As Font = New Font(AppFonts.Century, AppFonts.SizeSmall)
    Private _fontFieldMsgError As Font = New Font(AppFonts.Segoe, AppFonts.SizeMini)

    Private _paddingAll As Integer = AppLayout.Padding10
    Private _labelText As String = "Texto:"

    ' === Placeholder ===
    Private _placeholder As String = "Selecciona una Opción..."
    Private _placeholderColor As Color = AppColors._cPlaceHolder
    Private _textColorNormal As Color = Color.Black

    Public Event SelectedIndexChangedCustom As EventHandler
    Public Event SelectionChangeCommittedCustom As EventHandler
    Private cargarCombo As Boolean = False ' Evitar eventos en carga

#End Region

#Region "PROPIEDADES PÚBLICAS"
    ' === Propiedades comunes ===
    <Category("WilmerUI")>
    Public Property CampoRequerido As Boolean = False

    <Category("WilmerUI")>
    Public Property MensajeError As String = AppMensajes.msgCampoRequerido

    <Category("WilmerUI")>
    Public Property TextoLabel As String
        Get
            Return lblTitulo.Text
        End Get
        Set(value As String)
            lblTitulo.Text = value
            Me.Invalidate()
        End Set
    End Property

    <Category("WilmerUI")>
    Public Property ColorTitulo As Color
        Get
            Return _labelColor
        End Get
        Set(value As Color)
            _labelColor = value
            lblTitulo.ForeColor = value
            Me.Invalidate()
        End Set
    End Property

    <Browsable(True), Category("OrbitalUI")>
    Public Property Placeholder As String
        Get
            Return _placeholder
        End Get
        Set(value As String)
            _placeholder = value
            lblPlaceholder.Text = value
            Me.Invalidate()
        End Set
    End Property

    <Browsable(True), Category("OrbitalUI")>
    Public Property PlaceholderColor As Color
        Get
            Return _placeholderColor
        End Get
        Set(value As Color)
            _placeholderColor = value
            lblPlaceholder.ForeColor = value
            Me.Invalidate()
        End Set
    End Property

    <Category("ControlUI")>
    Public ReadOnly Property ComboBoxUI As ComboBoxUI
        Get
            Return cmbCampo
        End Get
    End Property

    ' --- Equivalentes DisplayMember y ValueMember ---
    <Browsable(False)>
    Public Property ValorSeleccionado As Object
        Get
            Return cmbCampo.SelectedValue
        End Get
        Set(value As Object)
            cmbCampo.SelectedValue = value
        End Set
    End Property

    <Browsable(False)>
    Public ReadOnly Property NombreSeleccionado As String
        Get
            Return cmbCampo.GetItemText(cmbCampo.SelectedItem)
        End Get
    End Property

    ' Accesos rápidos
    <Browsable(False)>
    Public Property IndiceSeleccionado As Integer
        Get
            Return cmbCampo.SelectedIndex
        End Get
        Set(value As Integer)
            If value >= 0 AndAlso value < cmbCampo.Items.Count Then
                cmbCampo.SelectedIndex = value
            End If
        End Set
    End Property

    <Browsable(False)>
    Public ReadOnly Property TextoSeleccionado As String
        Get
            Return cmbCampo.Text
        End Get
    End Property

    <Browsable(False)>
    Public ReadOnly Property ItemSeleccionado As Object
        Get
            Return cmbCampo.SelectedItem
        End Get
    End Property

#End Region

#Region "CONSTRUCTOR"
    ' === Constructor ===
    Public Sub New()
        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor Or
                    ControlStyles.UserPaint Or
                    ControlStyles.AllPaintingInWmPaint Or
                    ControlStyles.OptimizedDoubleBuffer, True)
        Me.UpdateStyles()
        Me.Size = New Size(300, 100)
        Me.BackColor = Color.Transparent

        ' === Label de título ===
        lblTitulo.Text = _labelText
        lblTitulo.Font = _fontFieldTitulo
        lblTitulo.ForeColor = _labelColor
        lblTitulo.Dock = DockStyle.Top
        lblTitulo.Height = AppLayout.ControlLabelHeight

        ' === Panel de fondo ===
        pnlFondo.Dock = DockStyle.Top
        pnlFondo.BackColor = _panelBackColor
        pnlFondo.Padding = New Padding(0)
        pnlFondo.Height = AppLayout.PanelHeightStandar
        pnlFondo.Margin = Padding.Empty

        ' === ComboBox ===
        cmbCampo.Dock = DockStyle.Fill
        cmbCampo.ForeColor = Color.Black
        pnlFondo.Controls.Add(cmbCampo)

        ' === Label de error ===
        lblError.Text = ""
        lblError.Font = _fontFieldMsgError
        lblError.ForeColor = _colorError
        lblError.Dock = DockStyle.Top
        lblError.Height = AppLayout.ControlLabelHeight
        lblError.Visible = False
        lblError.Margin = Padding.Empty
        lblError.TextAlign = ContentAlignment.MiddleRight
        lblError.BackColor = Color.Transparent

        ' === Placeholder ===
        lblPlaceholder.Text = _placeholder
        lblPlaceholder.ForeColor = _placeholderColor
        lblPlaceholder.BackColor = Color.Transparent
        lblPlaceholder.Font = _fontFieldTexto
        lblPlaceholder.TextAlign = ContentAlignment.MiddleLeft
        lblPlaceholder.AutoSize = False
        lblPlaceholder.Location = cmbCampo.Location
        lblPlaceholder.Size = New Size(cmbCampo.Width - 30, cmbCampo.Height - 10)
        lblPlaceholder.Enabled = False ' Para que no reciba foco ni eventos
        pnlFondo.Controls.Add(lblPlaceholder)
        lblPlaceholder.BringToFront()
        UpdatePlaceholderVisibility()

        ' === Icono derecha (opcional) ===
        Me.Controls.Add(lblError)
        Me.Controls.Add(pnlFondo)
        Me.Controls.Add(lblTitulo)

        ' Eventos
        AddHandler pnlFondo.Paint, AddressOf DibujarFondoRedondeado
        AddHandler pnlFondo.Resize, AddressOf OnPanelResize
        AddHandler Me.Resize, AddressOf OnPanelResize

        AddHandler cmbCampo.Leave, Sub()
                                       If CampoRequerido Then EsValido()
                                   End Sub
        AddHandler cmbCampo.Enter, Sub()
                                       If cmbCampo.Focused Then UpdatePlaceholderVisibility()
                                   End Sub
        AddHandler cmbCampo.SelectedIndexChanged, AddressOf cmbCampo_SelectedIndexChanged
        AddHandler cmbCampo.SelectionChangeCommitted, AddressOf cmbCampo_SelectionChangeCommitted

    End Sub
#End Region

#Region "DIBUJO"

    Private Sub DibujarFondoRedondeado(sender As Object, e As PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        Dim r = Math.Min(_borderRadius, Math.Min(pnlFondo.Width, pnlFondo.Height) \ 2)

        ' Rectángulo del panel principal (dejando espacio para sombra fuera)
        Dim rectPanel As New Rectangle(0, 0, pnlFondo.Width - 4, pnlFondo.Height - 4)

        '' === Sombra desplazada 3px abajo y derecha ===
        'If _shadowSize > 0 Then
        '    Dim shadowRect As New Rectangle(rectPanel.X + 3, rectPanel.Y + 3, rectPanel.Width, rectPanel.Height)
        '    Using pathShadow As GraphicsPath = RoundedPath(shadowRect, r)
        '        Using brushShadow As New SolidBrush(_shadowColor)
        '            e.Graphics.FillPath(brushShadow, pathShadow)
        '        End Using
        '    End Using
        'End If

        ' === Fondo principal ===
        Using pathPanel As GraphicsPath = RoundedPath(rectPanel, r)
            Using brushPanel As New SolidBrush(pnlFondo.BackColor)
                e.Graphics.FillPath(brushPanel, pathPanel)
            End Using

            ' === Borde ===
            Dim penColor As Color = If(lblError.Visible, _borderColorError, _borderColor)
            If _borderSize > 0 Then
                Using pen As New Pen(penColor, _borderSize)
                    e.Graphics.DrawPath(pen, pathPanel)
                End Using
            End If
        End Using

        ' NO cambiar pnlFondo.Region, para que la sombra quede visible fuera
        ' pnlFondo.Region = New Region(pathPanel)
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

    '' === Reposicionamiento (para placeholder e icono) ===
    Private Sub OnPanelResize(sender As Object, e As EventArgs)
        ' reajusta txtCampo ancho y posición
        cmbCampo.Location = New Point(8, (pnlFondo.Height - cmbCampo.Height) \ 2)
        cmbCampo.Width = pnlFondo.Width - 16

        ' placeholder usa la misma geometría del textbox
        lblPlaceholder.ForeColor = AppColors._cTextoInfo
        lblPlaceholder.Location = New Point(2, 2)
        lblPlaceholder.Size = New Size(cmbCampo.Width - 30, cmbCampo.Height - 10)
        lblPlaceholder.BringToFront()

    End Sub

#End Region

#Region "PROCEDIMIENTO"
    ' === Placeholder visibility update ===
    Private Sub UpdatePlaceholderVisibility()
        lblPlaceholder.Visible = Not cmbCampo.Focused AndAlso String.IsNullOrEmpty(cmbCampo.Text)
    End Sub

    Private Sub cmbCampo_SelectedIndexChanged(sender As Object, e As EventArgs)
        If cargarCombo Then Exit Sub
        RaiseEvent SelectedIndexChangedCustom(Me, e)
    End Sub

    Private Sub cmbCampo_SelectionChangeCommitted(sender As Object, e As EventArgs)
        If cargarCombo Then Exit Sub
        RaiseEvent SelectionChangeCommittedCustom(Me, e)
    End Sub

#End Region

#Region "Métodos Públicos"
    Public Sub Limpiar()
        cmbCampo.SelectedIndex = -1
        cmbCampo.Text = ""
        cmbCampo.Refresh()
    End Sub

    Public Sub IniciarCarga()
        cargarCombo = True
    End Sub

    Public Sub FinalizarCarga()
        cargarCombo = False
    End Sub

    Public Sub AddItems(item As LlenarComboBox.ComboItem, ParamArray items() As String)
        ' Puedes ajustar para limpiar antes si quieres
        cmbCampo.Items.AddRange(items)
        Me.Invalidate()
    End Sub
#End Region

#Region "Validación"
    ''' <summary>
    ''' Valida si el campo es requerido y si está vacío, muestra el mensaje de error.
    ''' </summary>
    ''' <returns>True si es válido, False si no lo es.</returns>

    Public Overridable Function EsValido() As Boolean
        Dim texto = cmbCampo.Text.Trim()
        If CampoRequerido AndAlso String.IsNullOrWhiteSpace(texto) Then
            MostrarError(MensajeError)
            Return False
        Else
            OcultarError()
            Return True
        End If
    End Function

    Protected Sub MostrarError(mensaje As String)
        lblError.Text = mensaje
        lblError.Visible = True
        _borderColor = _colorError
        pnlFondo.Invalidate()
    End Sub

    Protected Sub OcultarError()
        lblError.Text = ""
        lblError.Visible = False
        _borderColor = AppColors._cBaseSuccess
        pnlFondo.Invalidate()
    End Sub

#End Region

End Class

