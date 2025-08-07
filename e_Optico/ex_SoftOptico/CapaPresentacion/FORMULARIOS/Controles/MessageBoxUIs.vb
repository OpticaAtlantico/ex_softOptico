Imports CapaPresentacion.MessageBoxUIs
Imports FontAwesome.Sharp
Imports System.Drawing.Drawing2D

Public Class MessageBoxUIs
    Inherits Form

    Private fondoOverlay As FondoOverlayUI

    ' Enum para tipos de mensaje
    Public Enum TipoMensaje
        Exito
        Advertencia
        Errors
        Informacion
    End Enum

    ' Enum para botones
    Public Enum Botones
        Aceptar
        AceptarCancelar
        SiNo
        SiNoCancelar
    End Enum

    ' Variables para configurar
    Private _tipoMensaje As TipoMensaje = TipoMensaje.Informacion
    Private _botones As Botones = Botones.Aceptar
    Private _titulo As String = "Título"
    Private _mensaje As String = "Mensaje"
    Private _icono As IconChar = IconChar.InfoCircle

    ' Controles
    Private lblTitulo As New Label()
    Private lblMensaje As New Label()
    Private iconoDecorativo As New IconPictureBox()
    Private btnAceptar As New Button()
    Private btnCancelar As New Button()
    Private btnSi As New Button()
    Private btnNo As New Button()
    Private pnlFondo As New Panel()

    Public Sub New()
        Me.FormBorderStyle = FormBorderStyle.None
        Me.StartPosition = FormStartPosition.CenterParent
        Me.Size = New Size(450, 220)
        Me.BackColor = Color.White
        Me.Region = New Region(GetRoundedRectPath(Me.ClientRectangle, 15))

        ' Panel fondo blanco (para simular borde por el contenedor)
        pnlFondo.Size = New Size(Me.Width - 20, Me.Height - 20)
        pnlFondo.Location = New Point(10, 10)
        pnlFondo.BackColor = Color.White
        pnlFondo.Region = New Region(GetRoundedRectPath(pnlFondo.ClientRectangle, 15))
        Me.Controls.Add(pnlFondo)

        ' Icono decorativo
        iconoDecorativo.IconColor = Color.DodgerBlue
        iconoDecorativo.IconSize = 48
        iconoDecorativo.Location = New Point(20, 18)
        iconoDecorativo.Size = New Size(48, 48)
        pnlFondo.Controls.Add(iconoDecorativo)

        ' Título
        lblTitulo.Font = New Font("Segoe UI Semibold", 14, FontStyle.Bold)
        lblTitulo.ForeColor = Color.DodgerBlue
        lblTitulo.Location = New Point(90, 20)
        lblTitulo.AutoSize = False
        lblTitulo.Size = New Size(pnlFondo.Width - 110, 30)
        pnlFondo.Controls.Add(lblTitulo)

        ' Mensaje
        lblMensaje.Font = New Font("Segoe UI", 11)
        lblMensaje.ForeColor = Color.FromArgb(64, 64, 64)
        lblMensaje.Location = New Point(90, 60)
        lblMensaje.Size = New Size(pnlFondo.Width - 110, 80)
        lblMensaje.AutoEllipsis = True
        pnlFondo.Controls.Add(lblMensaje)

        ' Botones - configuración, los agregamos pero se mostrarán según selección
        ' Aceptar
        ConfigurarBoton(btnAceptar, "Aceptar", New Point(90, 150), Color.DodgerBlue)
        AddHandler btnAceptar.Click, AddressOf BtnAceptar_Click
        pnlFondo.Controls.Add(btnAceptar)

        ' Cancelar
        ConfigurarBoton(btnCancelar, "Cancelar", New Point(250, 150), Color.OrangeRed)
        AddHandler btnCancelar.Click, AddressOf BtnCancelar_Click
        pnlFondo.Controls.Add(btnCancelar)

        ' Sí
        ConfigurarBoton(btnSi, "Sí", New Point(90, 150), Color.DodgerBlue)
        AddHandler btnSi.Click, AddressOf BtnSi_Click
        pnlFondo.Controls.Add(btnSi)

        ' No
        ConfigurarBoton(btnNo, "No", New Point(250, 150), Color.OrangeRed)
        AddHandler btnNo.Click, AddressOf BtnNo_Click
        pnlFondo.Controls.Add(btnNo)
    End Sub

    Private Sub ConfigurarBoton(btn As Button, texto As String, ubicacion As Point, colorFondo As Color)
        btn.Text = texto
        btn.BackColor = colorFondo
        btn.ForeColor = Color.White
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 0
        btn.Font = New Font("Segoe UI", 11, FontStyle.Regular)
        btn.Size = New Size(140, 40)
        btn.Location = ubicacion
        btn.Cursor = Cursors.Hand
    End Sub

    ' Propiedades públicas para configuración
    Public Property TipoMensajes As TipoMensaje
        Get
            Return _tipoMensaje
        End Get
        Set(value As TipoMensaje)
            _tipoMensaje = value
            AplicarEstiloPorTipo()
        End Set
    End Property

    Public Property Botons As Botones
        Get
            Return _botones
        End Get
        Set(value As Botones)
            _botones = value
            ConfigurarBotonesVisibles()
        End Set
    End Property

    Public Property Titulo As String
        Get
            Return _titulo
        End Get
        Set(value As String)
            _titulo = value
            lblTitulo.Text = value
        End Set
    End Property

    Public Property Mensaje As String
        Get
            Return _mensaje
        End Get
        Set(value As String)
            _mensaje = value
            lblMensaje.Text = value
            AjustarAlturaMensaje()
        End Set
    End Property

    Public Property IconoMensaje As IconChar
        Get
            Return _icono
        End Get
        Set(value As IconChar)
            _icono = value
            iconoDecorativo.IconChar = value
        End Set
    End Property

    ' Ajustar altura del label mensaje para que se adapte al texto
    Private Sub AjustarAlturaMensaje()
        Using g As Graphics = lblMensaje.CreateGraphics()
            Dim size = g.MeasureString(lblMensaje.Text, lblMensaje.Font, lblMensaje.Width)
            Dim nuevaAltura As Integer = CInt(Math.Ceiling(size.Height))
            lblMensaje.Height = nuevaAltura
        End Using
    End Sub

    ' Cambiar colores según tipo mensaje, en Me.BackColor (contenedor principal)
    Private Sub AplicarEstiloPorTipo()
        Select Case _tipoMensaje
            Case TipoMensaje.Exito
                Me.BackColor = Color.FromArgb(198, 239, 206) ' Verde claro borde
                lblTitulo.ForeColor = Color.FromArgb(0, 97, 0)
                iconoDecorativo.IconColor = Color.FromArgb(0, 97, 0)
            Case TipoMensaje.Advertencia
                Me.BackColor = Color.FromArgb(255, 235, 156) ' Amarillo claro borde
                lblTitulo.ForeColor = Color.FromArgb(156, 101, 0)
                iconoDecorativo.IconColor = Color.FromArgb(156, 101, 0)
            Case TipoMensaje.Errors
                Me.BackColor = Color.FromArgb(255, 199, 206) ' Rojo claro borde
                lblTitulo.ForeColor = Color.FromArgb(156, 0, 6)
                iconoDecorativo.IconColor = Color.FromArgb(156, 0, 6)
            Case TipoMensaje.Informacion
                Me.BackColor = Color.FromArgb(206, 230, 249) ' Azul claro borde
                lblTitulo.ForeColor = Color.FromArgb(0, 70, 134)
                iconoDecorativo.IconColor = Color.FromArgb(0, 70, 134)
        End Select
    End Sub

    ' Mostrar u ocultar botones según selección
    Private Sub ConfigurarBotonesVisibles()
        btnAceptar.Visible = False
        btnCancelar.Visible = False
        btnSi.Visible = False
        btnNo.Visible = False

        Select Case _botones
            Case Botones.Aceptar
                btnAceptar.Visible = True
                btnAceptar.Location = New Point((pnlFondo.Width - btnAceptar.Width) \ 2, 150)
            Case Botones.AceptarCancelar
                btnAceptar.Visible = True
                btnCancelar.Visible = True
                btnAceptar.Location = New Point(90, 150)
                btnCancelar.Location = New Point(250, 150)
            Case Botones.SiNo
                btnSi.Visible = True
                btnNo.Visible = True
                btnSi.Location = New Point(90, 150)
                btnNo.Location = New Point(250, 150)
            Case Botones.SiNoCancelar
                btnSi.Visible = True
                btnNo.Visible = True
                btnCancelar.Visible = True
                btnSi.Location = New Point(30, 150)
                btnNo.Location = New Point(170, 150)
                btnCancelar.Location = New Point(310, 150)
        End Select
    End Sub

    ' Botones: cerrar con resultado adecuado
    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs)
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs)
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BtnSi_Click(sender As Object, e As EventArgs)
        Me.DialogResult = DialogResult.Yes
        Me.Close()
    End Sub

    Private Sub BtnNo_Click(sender As Object, e As EventArgs)
        Me.DialogResult = DialogResult.No
        Me.Close()
    End Sub

    ' Método para obtener el path redondeado para bordes
    Private Function GetRoundedRectPath(rect As Rectangle, radius As Integer) As GraphicsPath
        Dim path As New GraphicsPath()
        path.StartFigure()
        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90)
        path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90)
        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
        path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90)
        path.CloseFigure()
        Return path
    End Function

    ' Función estática para mostrar el mensaje
    Public Shared Function Mostrar(owner As IWin32Window,
                                  titulo As String,
                                  mensaje As String,
                                  tipoMensaje As TipoMensaje,
                                  botones As Botones,
                                  icono As IconChar) As DialogResult
        Dim msg As New MessageBoxUIs()
        msg.Titulo = titulo
        msg.Mensaje = mensaje
        msg.TipoMensajes = tipoMensaje
        msg.Botons = botones
        msg.IconoMensaje = icono

        ' Mostrar overlay
        msg.fondoOverlay = New FondoOverlayUI()
        msg.fondoOverlay.Show(owner)

        Dim resultado = msg.ShowDialog(owner)

        ' Cerrar overlay
        If msg.fondoOverlay IsNot Nothing AndAlso Not msg.fondoOverlay.IsDisposed Then
            msg.fondoOverlay.Close()
            msg.fondoOverlay.Dispose()
            msg.fondoOverlay = Nothing
        End If

        Return resultado
    End Function

End Class

'Como usarlo

'Dim resultado As DialogResult = MessageBoxUI.Mostrar(Me,
'                                                    "Confirmación",
'                                                    "¿Está seguro que desea eliminar este empleado?",
'                                                    MessageBoxUI.TipoMensaje.Advertencia,
'                                                    MessageBoxUI.Botones.SiNoCancelar,
'                                                    FontAwesome.Sharp.IconChar.ExclamationTriangle)

'Select Case resultado
'Case DialogResult.Yes
'MessageBox.Show("Usuario eligió Sí")
'Case DialogResult.No
'MessageBox.Show("Usuario eligió No")
'Case DialogResult.Cancel
'MessageBox.Show("Usuario canceló")
'End Select



















'Imports System.Drawing.Drawing2D
'Imports FontAwesome.Sharp

'Public Class MessageBoxUI
'    Inherits Form

'    ' Enum para tipos de mensajes
'    Public Enum TipoMensajeUI
'        Exito
'        Errors
'        Advertencia
'        Informacion
'    End Enum

'    ' Enum para botones configurables
'    Public Enum TipoBotonesUI
'        Aceptar
'        AceptarCancelar
'        SiNo
'        SiNoCancelar
'    End Enum

'    Private fondoPanel As New Panel()
'    Private lblTitulo As New Label()
'    Private lblMensaje As New Label()
'    Private iconoMensaje As New IconPictureBox()
'    Private btnAceptar As New Button()
'    Private btnCancelar As New Button()
'    Private btnSi As New Button()
'    Private btnNo As New Button()

'    Private _resultado As DialogResult = DialogResult.None
'    Private _tipoMensaje As TipoMensajeUI
'    Private _tipoBotones As TipoBotonesUI

'    Public Sub New()
'        Me.FormBorderStyle = FormBorderStyle.None
'        Me.StartPosition = FormStartPosition.CenterParent
'        Me.Size = New Size(450, 230)
'        Me.Padding = New Padding(8) ' Espacio para el borde de color en Me.BackColor
'        Me.BackColor = Color.Gray ' Default antes de cambiar por tipo mensaje
'        Me.ShowInTaskbar = False
'        Me.TopMost = True

'        Me.Region = New Region(GetRoundedRectPath(Me.ClientRectangle, 20))

'        CrearControles()
'    End Sub

'    Private Sub CrearControles()
'        ' Panel interior blanco con bordes redondeados
'        fondoPanel.Size = New Size(Me.ClientSize.Width - 16, Me.ClientSize.Height - 16) ' Respecto al padding
'        fondoPanel.Location = New Point(8, 8)
'        fondoPanel.BackColor = Color.White
'        fondoPanel.Region = New Region(GetRoundedRectPath(fondoPanel.ClientRectangle, 18))
'        Me.Controls.Add(fondoPanel)

'        ' Icono
'        iconoMensaje.IconSize = 50
'        iconoMensaje.Location = New Point(20, 20)
'        iconoMensaje.Size = New Size(50, 50)
'        fondoPanel.Controls.Add(iconoMensaje)

'        ' Título
'        lblTitulo.Font = New Font("Segoe UI", 14, FontStyle.Bold)
'        lblTitulo.ForeColor = Color.FromArgb(40, 40, 40)
'        lblTitulo.Location = New Point(80, 20)
'        lblTitulo.Size = New Size(fondoPanel.Width - 100, 30)
'        fondoPanel.Controls.Add(lblTitulo)

'        ' Mensaje
'        lblMensaje.Font = New Font("Segoe UI", 11)
'        lblMensaje.ForeColor = Color.FromArgb(60, 60, 60)
'        lblMensaje.Location = New Point(20, 75)
'        lblMensaje.Size = New Size(fondoPanel.Width - 40, 70)
'        lblMensaje.AutoEllipsis = True
'        lblMensaje.MaximumSize = New Size(fondoPanel.Width - 40, 0)
'        lblMensaje.AutoSize = True
'        fondoPanel.Controls.Add(lblMensaje)

'        ' Botones
'        btnAceptar.Size = New Size(100, 35)
'        btnAceptar.Font = New Font("Segoe UI", 10, FontStyle.Regular)
'        btnAceptar.FlatStyle = FlatStyle.Flat
'        btnAceptar.BackColor = Color.FromArgb(0, 123, 255) ' Bootstrap Azul
'        btnAceptar.ForeColor = Color.White
'        btnAceptar.Text = "Aceptar"
'        btnAceptar.Location = New Point(fondoPanel.Width - 120, fondoPanel.Height - 50)
'        AddHandler btnAceptar.Click, AddressOf BtnAceptar_Click
'        fondoPanel.Controls.Add(btnAceptar)

'        btnCancelar.Size = btnAceptar.Size
'        btnCancelar.Font = btnAceptar.Font
'        btnCancelar.FlatStyle = FlatStyle.Flat
'        btnCancelar.BackColor = Color.FromArgb(220, 53, 69) ' Bootstrap Rojo
'        btnCancelar.ForeColor = Color.White
'        btnCancelar.Text = "Cancelar"
'        btnCancelar.Location = New Point(btnAceptar.Left - 110, btnAceptar.Top)
'        AddHandler btnCancelar.Click, AddressOf BtnCancelar_Click
'        fondoPanel.Controls.Add(btnCancelar)

'        btnSi.Size = btnAceptar.Size
'        btnSi.Font = btnAceptar.Font
'        btnSi.FlatStyle = FlatStyle.Flat
'        btnSi.BackColor = Color.FromArgb(40, 167, 69) ' Bootstrap Verde
'        btnSi.ForeColor = Color.White
'        btnSi.Text = "Sí"
'        btnSi.Location = New Point(btnAceptar.Left - 110, btnAceptar.Top)
'        AddHandler btnSi.Click, AddressOf BtnSi_Click
'        fondoPanel.Controls.Add(btnSi)

'        btnNo.Size = btnAceptar.Size
'        btnNo.Font = btnAceptar.Font
'        btnNo.FlatStyle = FlatStyle.Flat
'        btnNo.BackColor = Color.FromArgb(108, 117, 125) ' Bootstrap Gris
'        btnNo.ForeColor = Color.White
'        btnNo.Text = "No"
'        btnNo.Location = New Point(btnSi.Left - 110, btnSi.Top)
'        AddHandler btnNo.Click, AddressOf BtnNo_Click
'        fondoPanel.Controls.Add(btnNo)
'    End Sub

'    Private Sub AplicarEstiloPorTipoMensaje()
'        Select Case _tipoMensaje
'            Case TipoMensajeUI.Exito
'                Me.BackColor = Color.FromArgb(40, 167, 69) ' Verde Bootstrap
'                iconoMensaje.IconChar = IconChar.CheckCircle
'                iconoMensaje.IconColor = Color.FromArgb(40, 167, 69)

'            Case TipoMensajeUI.Errors
'                Me.BackColor = Color.FromArgb(220, 53, 69) ' Rojo Bootstrap
'                iconoMensaje.IconChar = IconChar.TimesCircle
'                iconoMensaje.IconColor = Color.FromArgb(220, 53, 69)

'            Case TipoMensajeUI.Advertencia
'                Me.BackColor = Color.FromArgb(255, 193, 7) ' Amarillo Bootstrap
'                iconoMensaje.IconChar = IconChar.ExclamationTriangle
'                iconoMensaje.IconColor = Color.FromArgb(255, 193, 7)

'            Case TipoMensajeUI.Informacion
'                Me.BackColor = Color.FromArgb(23, 162, 184) ' Azul Bootstrap
'                iconoMensaje.IconChar = IconChar.InfoCircle
'                iconoMensaje.IconColor = Color.FromArgb(23, 162, 184)
'        End Select

'        fondoPanel.BackColor = Color.White
'        fondoPanel.Region = New Region(GetRoundedRectPath(fondoPanel.ClientRectangle, 18))
'    End Sub

'    Private Sub ConfigurarBotones()
'        ' Ocultar todos primero
'        btnAceptar.Visible = False
'        btnCancelar.Visible = False
'        btnSi.Visible = False
'        btnNo.Visible = False

'        Select Case _tipoBotones
'            Case TipoBotonesUI.Aceptar
'                btnAceptar.Visible = True
'                btnAceptar.Location = New Point((fondoPanel.Width - btnAceptar.Width) \ 2, fondoPanel.Height - 50)

'            Case TipoBotonesUI.AceptarCancelar
'                btnAceptar.Visible = True
'                btnCancelar.Visible = True
'                btnCancelar.Location = New Point(fondoPanel.Width - 230, fondoPanel.Height - 50)
'                btnAceptar.Location = New Point(fondoPanel.Width - 120, fondoPanel.Height - 50)

'            Case TipoBotonesUI.SiNo
'                btnSi.Visible = True
'                btnNo.Visible = True
'                btnNo.Location = New Point(fondoPanel.Width - 230, fondoPanel.Height - 50)
'                btnSi.Location = New Point(fondoPanel.Width - 120, fondoPanel.Height - 50)

'            Case TipoBotonesUI.SiNoCancelar
'                btnSi.Visible = True
'                btnNo.Visible = True
'                btnCancelar.Visible = True
'                btnCancelar.Location = New Point(fondoPanel.Width - 340, fondoPanel.Height - 50)
'                btnNo.Location = New Point(fondoPanel.Width - 230, fondoPanel.Height - 50)
'                btnSi.Location = New Point(fondoPanel.Width - 120, fondoPanel.Height - 50)
'        End Select
'    End Sub

'    Public Function Mostrar(titulo As String,
'                            mensaje As String,
'                            tipoMensaje As TipoMensajeUI,
'                            tipoBotones As TipoBotonesUI) As DialogResult

'        _tipoMensaje = tipoMensaje
'        _tipoBotones = tipoBotones

'        lblTitulo.Text = titulo
'        lblMensaje.Text = mensaje

'        AplicarEstiloPorTipoMensaje()
'        ConfigurarBotones()

'        Me.ShowDialog()
'        Return _resultado
'    End Function

'    ' Eventos de botones
'    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs)
'        _resultado = DialogResult.OK
'        Me.Close()
'    End Sub

'    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs)
'        _resultado = DialogResult.Cancel
'        Me.Close()
'    End Sub

'    Private Sub BtnSi_Click(sender As Object, e As EventArgs)
'        _resultado = DialogResult.Yes
'        Me.Close()
'    End Sub

'    Private Sub BtnNo_Click(sender As Object, e As EventArgs)
'        _resultado = DialogResult.No
'        Me.Close()
'    End Sub

'    ' Función para crear bordes redondeados
'    Private Function GetRoundedRectPath(rect As Rectangle, radius As Integer) As GraphicsPath
'        Dim path As New GraphicsPath()
'        path.StartFigure()
'        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90)
'        path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90)
'        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
'        path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90)
'        path.CloseFigure()
'        Return path
'    End Function

'End Class


