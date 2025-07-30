Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class ComboBoxLabelUI
    Inherits UserControl

    Private lblTitulo As New Label()
    Private pnlFondo As New Panel()
    Private comboOrbital As New ComboBoxUI()
    Private lblError As New Label()

    Private _tituloText As String = "Selecciona una opción:"
    Private _labelColor As Color = Color.WhiteSmoke
    Private _mensajeError As String = "Este campo es obligatorio."
    Private _mostrarError As Boolean = False
    Private _radiusPanel As Integer = 6
    Private _fontField As Font = New Font("Century Gothic", 10)
    Private _fontFields As Font = New Font("Century Gothic", 9)

    Private _campoRequerido As Boolean = True

    Private _borderColorPersonalizado As Color = Color.LightGray
    Private _borderSize As Integer = 1
    Private _backColorx As Color = Color.WhiteSmoke


    Public Sub New()
        Me.DoubleBuffered = True
        Me.Size = New Size(300, 90)
        Me.BackColor = Color.Transparent

        ' -- Título --
        lblTitulo.Text = _tituloText
        lblTitulo.Font = _fontField
        lblTitulo.ForeColor = Color.WhiteSmoke
        lblTitulo.Dock = DockStyle.Top
        lblTitulo.Height = 20

        ' -- Panel contenedor --
        pnlFondo.Dock = DockStyle.Top
        pnlFondo.Height = comboOrbital.Height + 6
        pnlFondo.Padding = New Padding(2)
        pnlFondo.BackColor = _backColorx
        pnlFondo.Controls.Add(comboOrbital)
        AddHandler pnlFondo.Resize, Sub()
                                        pnlFondo.Region = New Region(RoundedRectanglePath(pnlFondo.ClientRectangle, _radiusPanel))
                                    End Sub

        'EN CASO DE QUE QUEDE EL CAMPO VACIO EJECUTA LA FUNCIÓN VALIDARCAMPO
        AddHandler comboOrbital.Leave, Sub()
                                           If CampoRequerido Then
                                               ValidarCampo()
                                           End If
                                       End Sub

        'EN CASO DE QUE EL USUARIO HALLA SELECIONADO UN ITEM SE BORRA EL MENSAJE DE ERROR Y TODO VUELVE A LA NORMALIDAD
        AddHandler comboOrbital.SelectedIndexChanged, Sub()
                                                          If comboOrbital.SelectedIndex >= 0 Then
                                                              MostrarError = False
                                                              lblError.Text = ""
                                                              comboOrbital.BorderColor = comboOrbital.FocusColor
                                                              comboOrbital.Invalidate()
                                                          End If
                                                      End Sub



        ' -- ComboBox orbital --
        comboOrbital.Dock = DockStyle.Fill

        ' -- Mensaje de error --
        lblError.Text = ""
        lblError.ForeColor = Color.Firebrick
        lblError.Dock = DockStyle.Top
        lblError.TextAlign = ContentAlignment.MiddleRight
        lblError.Height = 20
        lblError.Visible = _mostrarError

        ' -- Añadir controles al UserControl --
        Me.Controls.Add(lblError)
        Me.Controls.Add(pnlFondo)
        Me.Controls.Add(lblTitulo)
    End Sub

    ' -- Propiedades Públicas --

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
            lblError.Text = value
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
    Public Sub AddItems(item As LlenarComboBox.ComboItem, ParamArray items() As String)
        'comboOrbital.Items.Clear()
        comboOrbital.Items.AddRange(items)
        Me.Invalidate()
    End Sub

    <Category("ControlUI")>
    Public Property CampoRequerido As Boolean
        Get
            Return _campoRequerido
        End Get
        Set(value As Boolean)
            _campoRequerido = value
        End Set
    End Property

    <Category("ControlUI")>
    Public ReadOnly Property idSeleccionado As Integer
        Get
            If comboOrbital.SelectedValue IsNot Nothing Then
                Return Convert.ToInt32(comboOrbital.SelectedValue)
            Else
                Return -1 'Valor orbital para indicar que no hay seleccion valida
            End If
        End Get
    End Property

    <Category("ControlUI")>
    Public ReadOnly Property NombreSeleccionado As String
        Get
            If comboOrbital.SelectedItem IsNot Nothing Then
                Return comboOrbital.GetItemText(comboOrbital.SelectedItem)
            Else
                Return -1 'Valor orbital para indicar que no hay seleccion valida
            End If
        End Get
    End Property

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
    Public Property BackColorPnl As Color
        Get
            Return _backColorx
        End Get
        Set(value As Color)
            _backColorx = value
            pnlFondo.Invalidate()
        End Set
    End Property

    <Category("WilmerUI")>
    Public Property BorderColor As Color
        Get
            Return _borderColorPersonalizado
        End Get
        Set(value As Color)
            _borderColorPersonalizado = value
            pnlFondo.Invalidate()
        End Set
    End Property

    <Category("WilmerUI")>
    Public Property BorderSize As Integer
        Get
            Return _borderSize
        End Get
        Set(value As Integer)
            _borderSize = value
            pnlFondo.Invalidate()
        End Set
    End Property

    ' -- Path para redondear el panel --
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

    Public Function ValidarCampo(Optional mensajePersonalizado As String = "") As Boolean
        Dim esValido As Boolean = comboOrbital.SelectedIndex >= 0

        MostrarError = Not esValido

        ' Si se pasa un mensaje personalizado, lo usa; sino el predeterminado
        lblError.Text = If(esValido, "", If(String.IsNullOrEmpty(mensajePersonalizado), MensajeError, mensajePersonalizado))

        ' Realce visual orbital
        comboOrbital.BorderColor = If(esValido, comboOrbital.FocusColor, Color.Firebrick)
        comboOrbital.Invalidate()

        Return esValido
    End Function


    ''''''''''''''COMO USARLO en caso de error 

    'ComboBoxGroupUI1.CampoRequerido = True
    'ComboBoxGroupUI1.MensajeError = "Por favor selecciona una opción válida."

    'If ComboBoxGroupUI1.ValidarCampo() Then
    '    ' Todo en orden
    '    Else
    '    ' Mensaje ya se muestra en lblError y borde en rojo
    '    End If

    ''''''''''''''COMO USAR IDSELECCIOANDO 

    'Dim idCiudad As Integer = ComboBoxGroupUI1.IdSeleccionado

    'If idCiudad <> -1 Then
    '' Guardar el id en la base de datos
    'Else
    '' Campo sin selección válida
    'End If

    '''''''''''''COMO USAR NOMBRESELECCIOANDO 

    'Dim nombreCiudad As String = ComboBoxGroupUI1.NombreSeleccionado

    'If Not String.IsNullOrEmpty(nombreCiudad) Then
    '' Puedes mostrarlo, guardar junto con el ID, o lo que necesites
    'Else
    '' No hay una selección válida
    'End If

End Class