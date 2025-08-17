Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class ComboBoxLabelUI
    Inherits UserControl

    ' Controles internos
    Private lblTitulo As New Label()
    Private pnlFondo As New Panel()
    Private pnlSombra As New Panel()
    Private comboOrbital As New ComboBoxUI()
    Private lblError As New Label()

    ' Variables internas
    Private _tituloText As String = "Selecciona una opción:"
    Private _labelColor As Color = Color.WhiteSmoke
    Private _mensajeError As String = "Este campo es obligatorio."
    Private _mostrarError As Boolean = False
    Private _radiusPanel As Integer = 6
    Private _fontField As Font = New Font("Century Gothic", 10)
    Private _fontFields As Font = New Font("Century Gothic", 9)
    Private _campoRequerido As Boolean = True
    Private _borderColorPersonalizado As Color = Color.LightGray
    Private _sombraBackColor As Color = Color.LightGray
    Private _borderSize As Integer = 1
    Private _backColorx As Color = Color.WhiteSmoke
    Private cargarCombo As Boolean = False ' Evitar eventos en carga

    ' Eventos públicos
    Public Event SelectedIndexChangedCustom As EventHandler
    Public Event SelectionChangeCommittedCustom As EventHandler

    Public Sub New()
        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor Or
                    ControlStyles.UserPaint Or
                    ControlStyles.AllPaintingInWmPaint Or
                    ControlStyles.OptimizedDoubleBuffer, True)
        Me.UpdateStyles()
        Me.Size = New Size(300, 90)
        Me.BackColor = Color.Transparent

        ' Label título
        lblTitulo.Text = _tituloText
        lblTitulo.Font = _fontField
        lblTitulo.ForeColor = _labelColor
        lblTitulo.Dock = DockStyle.Top
        lblTitulo.Height = 20

        ' Sombra
        pnlSombra.Dock = DockStyle.None
        pnlSombra.BackColor = _sombraBackColor
        pnlSombra.Height = 38
        pnlSombra.Width = 900
        pnlSombra.Location = New Point(6, 23)

        ' Panel fondo
        pnlFondo.Dock = DockStyle.Top
        pnlFondo.Height = 38
        pnlFondo.Padding = New Padding(2)
        pnlFondo.BackColor = _backColorx
        pnlFondo.Controls.Add(comboOrbital)
        AddHandler pnlFondo.Resize, Sub()
                                        pnlFondo.Region = New Region(RoundedRectanglePath(pnlFondo.ClientRectangle, _radiusPanel))
                                    End Sub

        ' Combo
        comboOrbital.Dock = DockStyle.Fill
        comboOrbital.ForeColor = Color.Black
        AddHandler comboOrbital.Leave, Sub()
                                           If CampoRequerido Then ValidarCampo()
                                       End Sub
        AddHandler comboOrbital.SelectedIndexChanged, AddressOf comboOrbital_SelectedIndexChanged
        AddHandler comboOrbital.SelectionChangeCommitted, AddressOf comboOrbital_SelectionChangeCommitted

        ' Label error
        lblError.Text = ""
        lblError.ForeColor = Color.Firebrick
        lblError.Dock = DockStyle.Top
        lblError.TextAlign = ContentAlignment.MiddleRight
        lblError.Height = 20
        lblError.Visible = _mostrarError

        ' Agregar controles
        Me.Controls.Add(lblError)
        Me.Controls.Add(pnlFondo)
        Me.Controls.Add(pnlSombra)
        Me.Controls.Add(lblTitulo)
    End Sub

#Region "Propiedades"

    <Category("ControlUI")>
    Public Property Titulo As String
        Get
            Return _tituloText
        End Get
        Set(value As String)
            _tituloText = value
            lblTitulo.Text = value
        End Set
    End Property

    <Category("ControlUI")>
    Public Property MensajeError As String
        Get
            Return _mensajeError
        End Get
        Set(value As String)
            _mensajeError = value
            lblError.Font = _fontFields
        End Set
    End Property

    <Category("ControlUI")>
    Public Property MostrarError As Boolean
        Get
            Return _mostrarError
        End Get
        Set(value As Boolean)
            _mostrarError = value
            lblError.Visible = value
        End Set
    End Property

    <Category("ControlUI")>
    Public Property RadioContornoPanel As Integer
        Get
            Return _radiusPanel
        End Get
        Set(value As Integer)
            _radiusPanel = value
            pnlFondo.Region = New Region(RoundedRectanglePath(pnlFondo.ClientRectangle, value))
        End Set
    End Property

    <Category("ControlUI")>
    Public ReadOnly Property OrbitalCombo As ComboBoxUI
        Get
            Return comboOrbital
        End Get
    End Property

    <Category("ControlUI")>
    Public Property CampoRequerido As Boolean
        Get
            Return _campoRequerido
        End Get
        Set(value As Boolean)
            _campoRequerido = value
        End Set
    End Property

    ' --- Equivalentes DisplayMember y ValueMember ---
    <Browsable(False)>
    Public Property ValorSeleccionado As Object
        Get
            Return comboOrbital.SelectedValue
        End Get
        Set(value As Object)
            comboOrbital.SelectedValue = value
        End Set
    End Property

    <Browsable(False)>
    Public ReadOnly Property NombreSeleccionado As String
        Get
            Return comboOrbital.GetItemText(comboOrbital.SelectedItem)
        End Get
    End Property

    ' Accesos rápidos
    <Browsable(False)>
    Public Property IndiceSeleccionado As Integer
        Get
            Return comboOrbital.SelectedIndex
        End Get
        Set(value As Integer)
            If value >= 0 AndAlso value < comboOrbital.Items.Count Then
                comboOrbital.SelectedIndex = value
            End If
        End Set
    End Property

    <Browsable(False)>
    Public ReadOnly Property TextoSeleccionado As String
        Get
            Return comboOrbital.Text
        End Get
    End Property

    <Browsable(False)>
    Public ReadOnly Property ItemSeleccionado As Object
        Get
            Return comboOrbital.SelectedItem
        End Get
    End Property

    ' Colores y estilo
    <Category("WilmerUI")>
    Public Property LabelColor As Color
        Get
            Return _labelColor
        End Get
        Set(value As Color)
            _labelColor = value
            lblTitulo.ForeColor = value
        End Set
    End Property

    <Category("WilmerUI")>
    Public Property SombraBackColor As Color
        Get
            Return _sombraBackColor
        End Get
        Set(value As Color)
            _sombraBackColor = value
            pnlSombra.BackColor = value
        End Set
    End Property

    <Category("WilmerUI")>
    Public Property BackColorPnl As Color
        Get
            Return _backColorx
        End Get
        Set(value As Color)
            _backColorx = value
            pnlFondo.BackColor = value
        End Set
    End Property

    <Category("WilmerUI")>
    Public Property BorderColor As Color
        Get
            Return _borderColorPersonalizado
        End Get
        Set(value As Color)
            _borderColorPersonalizado = value
        End Set
    End Property

    <Category("WilmerUI")>
    Public Property BorderSize As Integer
        Get
            Return _borderSize
        End Get
        Set(value As Integer)
            _borderSize = value
        End Set
    End Property

#End Region

#Region "Métodos Públicos"

    Public Sub Limpiar()
        comboOrbital.SelectedIndex = -1
        comboOrbital.Text = ""
        comboOrbital.Refresh()
    End Sub

    Public Sub IniciarCarga()
        cargarCombo = True
    End Sub

    Public Sub FinalizarCarga()
        cargarCombo = False
    End Sub

    Public Sub AddItems(item As LlenarComboBox.ComboItem, ParamArray items() As String)
        ' Puedes ajustar para limpiar antes si quieres
        comboOrbital.Items.AddRange(items)
        Me.Invalidate()
    End Sub


    Public Function ValidarCampo(Optional mensajePersonalizado As String = "") As Boolean
        Dim esValido As Boolean = comboOrbital.SelectedIndex >= 0
        MostrarError = Not esValido
        lblError.Text = If(esValido, "", If(String.IsNullOrEmpty(mensajePersonalizado), MensajeError, mensajePersonalizado))
        comboOrbital.BorderColor = If(esValido, comboOrbital.FocusColor, Color.Firebrick)
        comboOrbital.Invalidate()
        Return esValido
    End Function

#End Region

#Region "Eventos Internos"

    Private Sub comboOrbital_SelectedIndexChanged(sender As Object, e As EventArgs)
        If cargarCombo Then Exit Sub
        RaiseEvent SelectedIndexChangedCustom(Me, e)
    End Sub

    Private Sub comboOrbital_SelectionChangeCommitted(sender As Object, e As EventArgs)
        If cargarCombo Then Exit Sub
        RaiseEvent SelectionChangeCommittedCustom(Me, e)
    End Sub

#End Region

#Region "Dibujo"

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

End Class

























'Imports System.ComponentModel
'Imports System.Drawing
'Imports System.Drawing.Drawing2D
'Imports System.Windows.Forms

'Public Class ComboBoxLabelUI
'    Inherits UserControl

'    Private lblTitulo As New Label()
'    Private pnlFondo As New Panel()
'    Private pnlSombra As New Panel()
'    Private comboOrbital As New ComboBoxUI()
'    Private lblError As New Label()

'    Private _tituloText As String = "Selecciona una opción:"
'    Private _labelColor As Color = Color.WhiteSmoke
'    Private _mensajeError As String = "Este campo es obligatorio."
'    Private _mostrarError As Boolean = False
'    Private _radiusPanel As Integer = 6
'    Private _fontField As Font = New Font("Century Gothic", 10)
'    Private _fontFields As Font = New Font("Century Gothic", 9)

'    Private _campoRequerido As Boolean = True

'    Private _borderColorPersonalizado As Color = Color.LightGray
'    Private _sombraBackColor As Color = Color.LightGray
'    Private _borderSize As Integer = 1
'    Private _backColorx As Color = Color.WhiteSmoke

'    ' Control interno para ignorar eventos mientras se carga
'    Private cargarCombo As Boolean = False

'    ' Eventos públicos para el formulario o consumidor del control
'    Public Event SelectedIndexChangedCustom As EventHandler
'    Public Event SelectionChangeCommittedCustom As EventHandler

'    Public Sub New()
'        Me.DoubleBuffered = True
'        Me.Size = New Size(300, 90)
'        Me.BackColor = Color.Transparent

'        ' Configurar label título
'        lblTitulo.Text = _tituloText
'        lblTitulo.Font = _fontField
'        lblTitulo.ForeColor = _labelColor
'        lblTitulo.Dock = DockStyle.Top
'        lblTitulo.Height = 20

'        ' Configurar sombra panel
'        pnlSombra.Dock = DockStyle.None
'        pnlSombra.BackColor = _sombraBackColor
'        pnlSombra.Height = 38
'        pnlSombra.Width = 900
'        pnlSombra.Margin = Padding.Empty
'        pnlSombra.Location = New Point(6, 23)

'        ' Panel contenedor combo
'        pnlFondo.Dock = DockStyle.Top
'        pnlFondo.Height = 38
'        pnlFondo.Padding = New Padding(2)
'        pnlFondo.BackColor = _backColorx
'        pnlFondo.Controls.Add(comboOrbital)
'        AddHandler pnlFondo.Resize, Sub()
'                                        pnlFondo.Region = New Region(RoundedRectanglePath(pnlFondo.ClientRectangle, _radiusPanel))
'                                    End Sub

'        ' Validación al salir del combo
'        AddHandler comboOrbital.Leave, Sub()
'                                           If CampoRequerido Then
'                                               ValidarCampo()
'                                           End If
'                                       End Sub

'        ' Quitar error visual si el usuario selecciona algo
'        AddHandler comboOrbital.SelectedIndexChanged, Sub()
'                                                          If comboOrbital.SelectedIndex >= 0 Then
'                                                              MostrarError = False
'                                                              lblError.Text = ""
'                                                              comboOrbital.BorderColor = comboOrbital.FocusColor
'                                                              comboOrbital.Invalidate()
'                                                          End If
'                                                      End Sub

'        ' Configurar combo
'        comboOrbital.Dock = DockStyle.Fill
'        comboOrbital.ForeColor = Color.Black

'        ' Mensaje error
'        lblError.Text = ""
'        lblError.ForeColor = Color.Firebrick
'        lblError.Dock = DockStyle.Top
'        lblError.TextAlign = ContentAlignment.MiddleRight
'        lblError.Height = 20
'        lblError.Visible = _mostrarError

'        ' Añadir controles al UserControl
'        Me.Controls.Add(lblError)
'        Me.Controls.Add(pnlFondo)
'        Me.Controls.Add(pnlSombra)
'        Me.Controls.Add(lblTitulo)

'        ' Asociar eventos para exponerlos con RaiseEvent (solo si no está cargando)
'        AddHandler comboOrbital.SelectedIndexChanged, AddressOf comboOrbital_SelectedIndexChanged
'        AddHandler comboOrbital.SelectionChangeCommitted, AddressOf comboOrbital_SelectionChangeCommitted
'    End Sub

'    ' Propiedades públicas
'    <Category("ControlUI")>
'    Public Property Titulo As String
'        Get
'            Return _tituloText
'        End Get
'        Set(value As String)
'            _tituloText = value
'            lblTitulo.Text = value
'        End Set
'    End Property

'    <Category("ControlUI")>
'    Public Property MensajeError As String
'        Get
'            Return _mensajeError
'        End Get
'        Set(value As String)
'            _mensajeError = value
'            lblError.Text = value
'            lblError.Font = _fontFields
'        End Set
'    End Property

'    <Category("ControlUI")>
'    Public Property MostrarError As Boolean
'        Get
'            Return _mostrarError
'        End Get
'        Set(value As Boolean)
'            _mostrarError = value
'            lblError.Visible = value
'        End Set
'    End Property

'    <Category("ControlUI")>
'    Public Property RadioContornoPanel As Integer
'        Get
'            Return _radiusPanel
'        End Get
'        Set(value As Integer)
'            _radiusPanel = value
'            pnlFondo.Region = New Region(RoundedRectanglePath(pnlFondo.ClientRectangle, value))
'        End Set
'    End Property

'    <Category("ControlUI")>
'    Public ReadOnly Property OrbitalCombo As ComboBoxUI
'        Get
'            Return comboOrbital
'        End Get
'    End Property

'    <Category("ControlUI")>
'    Public Sub AddItems(item As LlenarComboBox.ComboItem, ParamArray items() As String)
'        ' Puedes ajustar para limpiar antes si quieres
'        comboOrbital.Items.AddRange(items)
'        Me.Invalidate()
'    End Sub

'    <Category("ControlUI")>
'    Public Property CampoRequerido As Boolean
'        Get
'            Return _campoRequerido
'        End Get
'        Set(value As Boolean)
'            _campoRequerido = value
'        End Set
'    End Property

'    <Category("ControlUI")>
'    Public ReadOnly Property idSeleccionado As Integer
'        Get
'            If comboOrbital.SelectedValue IsNot Nothing Then
'                Return Convert.ToString(comboOrbital.SelectedValue)
'            Else
'                Return -1 ' Valor orbital para indicar que no hay selección válida
'            End If
'        End Get
'    End Property

'    <Category("ControlUI")>
'    Public Property ValueMember As String
'        Get
'            Return comboOrbital.ValueMember
'        End Get
'        Set(value As String)
'            comboOrbital.ValueMember = value
'        End Set
'    End Property


'    <Category("ControlUI")>
'    Public ReadOnly Property NombreSeleccionado As String
'        Get
'            If comboOrbital.SelectedItem IsNot Nothing Then
'                Return comboOrbital.GetItemText(comboOrbital.SelectedItem)
'            Else
'                Return "" ' Devuelve cadena vacía si no hay selección
'            End If
'        End Get
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
'    Public Property SombraBackColor As Color
'        Get
'            Return _sombraBackColor
'        End Get
'        Set(value As Color)
'            _sombraBackColor = value
'            pnlSombra.BackColor = value
'        End Set
'    End Property

'    <Category("WilmerUI")>
'    Public Property BackColorPnl As Color
'        Get
'            Return _backColorx
'        End Get
'        Set(value As Color)
'            _backColorx = value
'            pnlFondo.BackColor = value
'            pnlFondo.Invalidate()
'        End Set
'    End Property

'    <Category("WilmerUI")>
'    Public Property BorderColor As Color
'        Get
'            Return _borderColorPersonalizado
'        End Get
'        Set(value As Color)
'            _borderColorPersonalizado = value
'            pnlFondo.Invalidate()
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

'    ' Propiedades para acceder directamente a selección
'    Public Property ValorSeleccionado As Object
'        Get
'            Return OrbitalCombo.SelectedValue
'        End Get
'        Set(value As Object)
'            OrbitalCombo.SelectedValue = value
'        End Set
'    End Property

'    Public Property IndiceSeleccionado As Integer
'        Get
'            Return OrbitalCombo.SelectedIndex
'        End Get
'        Set(value As Integer)
'            If value >= 0 AndAlso value < OrbitalCombo.Items.Count Then
'                OrbitalCombo.SelectedIndex = value
'            End If
'        End Set
'    End Property

'    <Browsable(False)>
'    Public ReadOnly Property TextoSeleccionado As String
'        Get
'            Return OrbitalCombo.Text
'        End Get
'    End Property

'    <Browsable(False)>
'    Public ReadOnly Property ItemSeleccionado As Object
'        Get
'            Return OrbitalCombo.SelectedItem
'        End Get
'    End Property

'    ' Limpia selección y texto
'    <Browsable(False)>
'    Public Sub Limpiar()
'        OrbitalCombo.SelectedIndex = -1
'        OrbitalCombo.Text = ""
'        OrbitalCombo.Refresh()
'        OrbitalCombo.Invalidate()
'    End Sub

'    ' Métodos para controlar carga (evitar disparar eventos)
'    Public Sub IniciarCarga()
'        cargarCombo = True
'    End Sub

'    Public Sub FinalizarCarga()
'        cargarCombo = False
'    End Sub

'    ' Eventos internos del ComboBox con RaiseEvent y control de carga
'    Private Sub comboOrbital_SelectedIndexChanged(sender As Object, e As EventArgs)
'        If cargarCombo Then Exit Sub
'        RaiseEvent SelectedIndexChangedCustom(Me, e)
'    End Sub

'    Private Sub comboOrbital_SelectionChangeCommitted(sender As Object, e As EventArgs)
'        If cargarCombo Then Exit Sub
'        RaiseEvent SelectionChangeCommittedCustom(Me, e)
'    End Sub

'    ' Método para redondear el panel
'    Private Function RoundedRectanglePath(rect As Rectangle, radius As Integer) As GraphicsPath
'        Dim path As New GraphicsPath()
'        path.StartFigure()
'        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90)
'        path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90)
'        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
'        path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90)
'        path.CloseFigure()
'        Return path
'    End Function

'    ' Validación del campo ComboBox
'    Public Function ValidarCampo(Optional mensajePersonalizado As String = "") As Boolean
'        Dim esValido As Boolean = comboOrbital.SelectedIndex >= 0

'        MostrarError = Not esValido

'        lblError.Text = If(esValido, "", If(String.IsNullOrEmpty(mensajePersonalizado), MensajeError, mensajePersonalizado))

'        comboOrbital.BorderColor = If(esValido, comboOrbital.FocusColor, Color.Firebrick)
'        comboOrbital.Invalidate()

'        Return esValido
'    End Function

'End Class


'''''''''''''''COMO USARLO en caso de error 

''ComboBoxGroupUI1.CampoRequerido = True
''ComboBoxGroupUI1.MensajeError = "Por favor selecciona una opción válida."

''If ComboBoxGroupUI1.ValidarCampo() Then
''    ' Todo en orden
''    Else
''    ' Mensaje ya se muestra en lblError y borde en rojo
''    End If

'''''''''''''''COMO USAR IDSELECCIOANDO 

''Dim idCiudad As Integer = ComboBoxGroupUI1.IdSeleccionado

''If idCiudad <> -1 Then
''' Guardar el id en la base de datos
''Else
''' Campo sin selección válida
''End If

''''''''''''''COMO USAR NOMBRESELECCIOANDO 

''Dim nombreCiudad As String = ComboBoxGroupUI1.NombreSeleccionado

''If Not String.IsNullOrEmpty(nombreCiudad) Then
''' Puedes mostrarlo, guardar junto con el ID, o lo que necesites
''Else
''' No hay una selección válida
''End If

