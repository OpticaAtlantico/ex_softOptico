Imports FontAwesome.Sharp

Public Class MessageBoxUI
    Inherits Form

    Private panelFondo As New Panel()
    Private icono As New IconPictureBox()
    Private lblTitulo As New Label()
    Private lblMensaje As New Label()

    Private btnAceptar As New CommandButtonUI()
    Private btnCancelar As New CommandButtonUI()
    Private btnSi As New CommandButtonUI()
    Private btnNo As New CommandButtonUI()

    Private blurFondo As New Form()

    Public Enum TipoMensaje
        Exito
        Errorr
        Advertencia
        Informacion
    End Enum

    Public Enum TipoBotones
        Aceptar
        AceptarCancelar
        SiNo
    End Enum

    Private _resultado As DialogResult = DialogResult.None
    Private _borderRadius As Integer = AppLayout.BorderRadiusMsg

#Region "CONSTRUCTOR"
    Public Sub New()
        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor Or
                    ControlStyles.UserPaint Or
                    ControlStyles.AllPaintingInWmPaint Or
                    ControlStyles.OptimizedDoubleBuffer, True)
        Me.UpdateStyles()

        ' 🪟 Configuración del Form
        Me.FormBorderStyle = FormBorderStyle.None
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(500, 250)
        Me.BackColor = AppColors._cBlancoOscuro
        Me.TopMost = True
        Me.ShowInTaskbar = False

        ' 🎨 Panel contenedor
        panelFondo.Dock = DockStyle.Fill
        panelFondo.BackColor = AppColors._cBlanco
        Me.Controls.Add(panelFondo)

        ' 🖼️ Icono principal
        icono.Size = New Size(AppLayout.IconMsg, AppLayout.IconMsg)
        icono.IconChar = IconChar.InfoCircle
        icono.IconColor = AppColors._cBasePrimary
        icono.IconSize = AppLayout.IconMax
        icono.Location = New Point(20, 20)
        panelFondo.Controls.Add(icono)

        ' 🔠 Título
        lblTitulo.Font = New Font(AppFonts.Century, AppFonts.SizeLarge, AppFonts.Bold)
        lblTitulo.AutoSize = True
        lblTitulo.Location = New Point(70, 25)
        panelFondo.Controls.Add(lblTitulo)

        ' 📄 Mensaje
        lblMensaje.Font = New Font(AppFonts.Century, AppFonts.SizeMedium)
        lblMensaje.MaximumSize = New Size(460, 0)
        lblMensaje.AutoSize = True
        lblMensaje.Location = New Point(20, 90)
        panelFondo.Controls.Add(lblMensaje)

        ' 🟩 Botón Aceptar
        btnAceptar.Texto = "Aceptar"
        btnAceptar.EstiloBoton = CommandButtonUI.EstiloBootstrap.Success
        btnAceptar.Size = New Size(140, 40)
        AddHandler btnAceptar.Click, AddressOf BtnAceptar_Click
        panelFondo.Controls.Add(btnAceptar)

        ' 🟨 Botón Cancelar
        btnCancelar.Texto = "Cancelar"
        btnCancelar.EstiloBoton = CommandButtonUI.EstiloBootstrap.Warning
        btnCancelar.Size = New Size(140, 40)
        AddHandler btnCancelar.Click, AddressOf BtnCancelar_Click
        panelFondo.Controls.Add(btnCancelar)

        ' 🟢 Botón Sí
        btnSi.Texto = "Sí"
        btnSi.EstiloBoton = CommandButtonUI.EstiloBootstrap.Success
        btnSi.Size = New Size(120, 40)
        AddHandler btnSi.Click, AddressOf BtnSi_Click
        panelFondo.Controls.Add(btnSi)

        ' 🔴 Botón No
        btnNo.Texto = "No"
        btnNo.EstiloBoton = CommandButtonUI.EstiloBootstrap.Danger
        btnNo.Size = New Size(120, 40)
        AddHandler btnNo.Click, AddressOf BtnNo_Click
        panelFondo.Controls.Add(btnNo)

        ' 🎭 Bordes redondeados
        RedondearBordes(_borderRadius)
    End Sub
    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H2000000  ' WS_EX_COMPOSITED
            Return cp
        End Get
    End Property
#End Region

#Region "BOTONES"
    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs)
        _resultado = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs)
        _resultado = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BtnSi_Click(sender As Object, e As EventArgs)
        _resultado = DialogResult.Yes
        Me.Close()
    End Sub

    Private Sub BtnNo_Click(sender As Object, e As EventArgs)
        _resultado = DialogResult.No
        Me.Close()
    End Sub
    Protected Overrides Sub OnShown(e As EventArgs)
        MyBase.OnShown(e)
        MostrarFondoOverlay()
    End Sub
    Protected Overrides Sub OnFormClosed(e As FormClosedEventArgs)
        MyBase.OnFormClosed(e)
        OcultarFondoOverlay()
    End Sub
#End Region

#Region "CONFIGURACIÓN"
    Public Shared Function Mostrar(titulo As String,
                                   mensaje As String,
                                   tipo As TipoMensaje,
                                   botones As TipoBotones) As DialogResult
        Dim msg As New MessageBoxUI()
        msg.lblTitulo.Text = titulo
        msg.lblMensaje.Text = mensaje

        ' 🎨 Configuración por tipo de mensaje
        Select Case tipo
            Case TipoMensaje.Exito
                msg.icono.IconChar = IconChar.CheckCircle
                msg.icono.IconColor = AppColors._cBaseSuccess
                msg.BackColor = AppColors._cBaseSuccess
            Case TipoMensaje.Errorr
                msg.icono.IconChar = IconChar.TimesCircle
                msg.icono.IconColor = AppColors._cBaseDanger
                msg.BackColor = AppColors._cBaseDanger
            Case TipoMensaje.Advertencia
                msg.icono.IconChar = IconChar.ExclamationTriangle
                msg.icono.IconColor = AppColors._cBaseWarning
                msg.BackColor = AppColors._cBaseWarning
            Case TipoMensaje.Informacion
                msg.icono.IconChar = IconChar.InfoCircle
                msg.icono.IconColor = AppColors._cBaseInfo
                msg.BackColor = AppColors._cBaseInfo
        End Select

        ' 🎛️ Configuración de botones
        msg.ConfigurarBotones(botones)

        msg.ShowDialog()
        Return msg._resultado
    End Function

    Private Sub ConfigurarBotones(botones As TipoBotones)
        ' Ocultar todos primero
        btnAceptar.Visible = False
        btnCancelar.Visible = False
        btnSi.Visible = False
        btnNo.Visible = False

        Select Case botones.ToString
            Case "Aceptar"
                btnAceptar.Visible = True
                btnAceptar.Location = New Point((panelFondo.Width - btnAceptar.Width) \ 2,
                                                panelFondo.Height - 60)

            Case "AceptarCancelar"
                btnAceptar.Visible = True
                btnCancelar.Visible = True
                btnAceptar.Location = New Point((panelFondo.Width \ 2) - btnAceptar.Width - 10,
                                                panelFondo.Height - 60)
                btnCancelar.Location = New Point((panelFondo.Width \ 2) + 10,
                                                 panelFondo.Height - 60)

            Case "SiNo"
                btnSi.Visible = True
                btnNo.Visible = True
                btnSi.Location = New Point((panelFondo.Width \ 2) - btnSi.Width - 10,
                                           panelFondo.Height - 60)
                btnNo.Location = New Point((panelFondo.Width \ 2) + 10,
                                           panelFondo.Height - 60)
        End Select
    End Sub
#End Region

#Region "Control Fondo"
    Private Sub MostrarFondoOverlay()
        blurFondo.FormBorderStyle = FormBorderStyle.None
        blurFondo.Bounds = Screen.PrimaryScreen.Bounds
        blurFondo.BackColor = Color.Black
        blurFondo.Opacity = 0.4
        blurFondo.StartPosition = FormStartPosition.Manual
        blurFondo.ShowInTaskbar = False
        blurFondo.TopMost = False
        blurFondo.Show()
    End Sub

    Private Sub OcultarFondoOverlay()
        If blurFondo IsNot Nothing AndAlso Not blurFondo.IsDisposed Then
            blurFondo.Close()
        End If
    End Sub

#End Region

#Region "BORDES"
    Private Sub RedondearBordes(radio As Integer)
        Dim path As New Drawing2D.GraphicsPath()
        path.AddArc(0, 0, radio, radio, 180, 90)
        path.AddArc(Me.Width - radio, 0, radio, radio, 270, 90)
        path.AddArc(Me.Width - radio, Me.Height - radio, radio, radio, 0, 90)
        path.AddArc(0, Me.Height - radio, radio, radio, 90, 90)
        path.CloseFigure()
        Me.Region = New Region(path)
    End Sub
#End Region

End Class







'Imports FontAwesome.Sharp

'Public Class MessageBoxUI
'    Inherits Form

'#Region "Controles Principales y Botones"
'    Private panelFondo As New Panel()
'    Private icono As New IconPictureBox()
'    Private lblTitulo As New Label()
'    Private lblMensaje As New Label()

'    ' Botones
'    Private btnAceptar As New CommandButtonUI()
'    Private btnCancelar As New CommandButtonUI()
'    Private btnSi As New CommandButtonUI()
'    Private btnNo As New CommandButtonUI()

'#End Region

'#Region "Enum"
'    Public Enum TipoMensaje
'        Exito
'        Errorr
'        Advertencia
'        Informacion
'    End Enum

'    Public Enum TipoBotones
'        Aceptar
'        AceptarCancelar
'        SiNo
'    End Enum

'#End Region

'#Region "Variables"
'    ' Configuración
'    Private _borderRadius As Integer = AppLayout.BorderRadiusMsg
'    Private blurFondo As New Form()

'#End Region

'#Region "Contructor"
'    Public Sub New(titulo As String, mensaje As String,
'                   tipo As TipoMensaje,
'                   botones As TipoBotones)

'        ' Configuración inicial del formulario
'        Me.DoubleBuffered = True
'        Me.SetStyle(ControlStyles.SupportsTransparentBackColor Or
'                    ControlStyles.UserPaint Or
'                    ControlStyles.AllPaintingInWmPaint Or
'                    ControlStyles.OptimizedDoubleBuffer, True)
'        Me.UpdateStyles()

'        Me.FormBorderStyle = FormBorderStyle.None
'        Me.StartPosition = FormStartPosition.CenterScreen
'        Me.Size = New Size(500, 250)
'        Me.TopMost = True
'        Me.ShowInTaskbar = False

'        ' Panel contenedor
'        panelFondo.Dock = DockStyle.Fill
'        panelFondo.BackColor = AppColors._cBlanco
'        Me.Controls.Add(panelFondo)

'        ' Icono
'        icono.Size = New Size(AppLayout.IconMsg, AppLayout.IconMsg)
'        icono.IconChar = IconChar.InfoCircle
'        icono.IconSize = AppLayout.IconMax
'        icono.Location = New Point(20, 20)
'        panelFondo.Controls.Add(icono)

'        ' Título
'        lblTitulo.Font = New Font(AppFonts.Century, AppFonts.SizeLarge, AppFonts.Bold)
'        lblTitulo.AutoSize = True
'        lblTitulo.Location = New Point(70, 25)
'        panelFondo.Controls.Add(lblTitulo)

'        ' Mensaje
'        lblMensaje.Font = New Font(AppFonts.Century, AppFonts.SizeMedium)
'        lblMensaje.MaximumSize = New Size(460, 0)
'        lblMensaje.AutoSize = True
'        lblMensaje.Location = New Point(20, 90)
'        panelFondo.Controls.Add(lblMensaje)

'        ' Configurar valores
'        lblTitulo.Text = titulo
'        lblMensaje.Text = mensaje
'        ConfigurarTipoMensaje(tipo)
'        ConfigurarBotones(botones)

'        ' Fondo redondeado
'        RedondearBordes(_borderRadius)
'    End Sub
'#End Region

'#Region "Configuración"
'    Private Sub ConfigurarBotones(tipo As TipoBotones)
'        ' Limpiar por si acaso
'        panelFondo.Controls.Remove(btnAceptar)
'        panelFondo.Controls.Remove(btnCancelar)
'        panelFondo.Controls.Remove(btnSi)
'        panelFondo.Controls.Remove(btnNo)

'        Select Case tipo
'            Case TipoBotones.Aceptar
'                btnAceptar.Text = "Aceptar"
'                btnAceptar.Size = New Size(160, 40)
'                btnAceptar.EstiloBoton = CommandButtonUI.EstiloBootstrap.Success
'                'btnAceptar.TextImageRelation = TextImageRelation.ImageBeforeText
'                btnAceptar.Padding = New Padding(10, 0, 0, 0)
'                AddHandler btnAceptar.Click, AddressOf BtnAceptar_Click
'                btnAceptar.Location = New Point((Me.Width - btnAceptar.Width) \ 2, 190)
'                panelFondo.Controls.Add(btnAceptar)

'            Case TipoBotones.AceptarCancelar
'                btnAceptar.Text = "Aceptar"
'                btnAceptar.Size = New Size(160, 40)
'                btnAceptar.EstiloBoton = CommandButtonUI.EstiloBootstrap.Success
'                'btnAceptar.TextImageRelation = TextImageRelation.ImageBeforeText
'                btnAceptar.Padding = New Padding(10, 0, 0, 0)
'                AddHandler btnAceptar.Click, AddressOf BtnAceptar_Click
'                btnAceptar.Location = New Point(90, 190)
'                panelFondo.Controls.Add(btnAceptar)

'                btnCancelar.Text = "Cancelar"
'                btnCancelar.Size = New Size(160, 40)
'                btnCancelar.EstiloBoton = CommandButtonUI.EstiloBootstrap.Warning
'                'btnCancelar.TextImageRelation = TextImageRelation.ImageBeforeText
'                btnCancelar.Padding = New Padding(10, 0, 0, 0)
'                AddHandler btnCancelar.Click, AddressOf BtnCancelar_Click
'                btnCancelar.Location = New Point(260, 190)
'                panelFondo.Controls.Add(btnCancelar)

'            Case TipoBotones.SiNo
'                btnSi.Text = "Sí"
'                btnSi.Size = New Size(120, 40)
'                btnSi.EstiloBoton = CommandButtonUI.EstiloBootstrap.Success
'                'btnSi.TextImageRelation = TextImageRelation.ImageBeforeText
'                btnSi.Padding = New Padding(10, 0, 0, 0)
'                AddHandler btnSi.Click, AddressOf BtnSi_Click
'                btnSi.Location = New Point(120, 190)
'                panelFondo.Controls.Add(btnSi)

'                btnNo.Text = "No"
'                btnNo.Size = New Size(120, 40)
'                btnNo.EstiloBoton = CommandButtonUI.EstiloBootstrap.Danger
'                'btnNo.TextImageRelation = TextImageRelation.ImageBeforeText
'                btnNo.Padding = New Padding(10, 0, 0, 0)
'                AddHandler btnNo.Click, AddressOf BtnNo_Click
'                btnNo.Location = New Point(260, 190)
'                panelFondo.Controls.Add(btnNo)
'        End Select
'    End Sub

'    ' -------------------------
'    ' Configuración de tipo de mensaje
'    ' -------------------------
'    Private Sub ConfigurarTipoMensaje(tipo As TipoMensaje)
'        Select Case tipo
'            Case TipoMensaje.Exito
'                Me.BackColor = AppColors._cBaseSuccess
'                icono.IconChar = IconChar.CheckCircle
'                icono.IconColor = AppColors._cBaseSuccess

'            Case TipoMensaje.Errorr
'                Me.BackColor = AppColors._cBaseDanger
'                icono.IconChar = IconChar.TimesCircle
'                icono.IconColor = AppColors._cBaseDanger

'            Case TipoMensaje.Advertencia
'                Me.BackColor = AppColors._cBaseWarning
'                icono.IconChar = IconChar.ExclamationTriangle
'                icono.IconColor = AppColors._cBaseWarning

'            Case TipoMensaje.Informacion
'                Me.BackColor = AppColors._cBasePrimary
'                icono.IconChar = IconChar.InfoCircle
'                icono.IconColor = AppColors._cBasePrimary
'        End Select
'    End Sub
'#End Region

'#Region "Eventos"
'    ' -------------------------
'    ' Acciones de botones
'    ' -------------------------
'    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs)
'        Me.DialogResult = DialogResult.OK
'        Me.Close()
'    End Sub

'    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs)
'        Me.DialogResult = DialogResult.Cancel
'        Me.Close()
'    End Sub

'    Private Sub BtnSi_Click(sender As Object, e As EventArgs)
'        Me.DialogResult = DialogResult.Yes
'        Me.Close()
'    End Sub

'    Private Sub BtnNo_Click(sender As Object, e As EventArgs)
'        Me.DialogResult = DialogResult.No
'        Me.Close()
'    End Sub
'    Protected Overrides Sub OnShown(e As EventArgs)
'        MyBase.OnShown(e)
'        MostrarFondoOverlay()
'    End Sub
'    Protected Overrides Sub OnFormClosed(e As FormClosedEventArgs)
'        MyBase.OnFormClosed(e)
'        OcultarFondoOverlay()
'    End Sub
'#End Region

'#Region "Control Fondo"
'    Private Sub MostrarFondoOverlay()
'        blurFondo.FormBorderStyle = FormBorderStyle.None
'        blurFondo.Bounds = Screen.PrimaryScreen.Bounds
'        blurFondo.BackColor = Color.Black
'        blurFondo.Opacity = 0.4
'        blurFondo.StartPosition = FormStartPosition.Manual
'        blurFondo.ShowInTaskbar = False
'        blurFondo.TopMost = False
'        blurFondo.Show()
'    End Sub

'    Private Sub OcultarFondoOverlay()
'        If blurFondo IsNot Nothing AndAlso Not blurFondo.IsDisposed Then
'            blurFondo.Close()
'        End If
'    End Sub

'#End Region

'#Region "Dibujo"
'    ' -------------------------
'    ' Bordes redondeados
'    ' -------------------------
'    Private Sub RedondearBordes(radio As Integer)
'        Dim path As New Drawing2D.GraphicsPath()
'        path.StartFigure()
'        path.AddArc(New Rectangle(0, 0, radio, radio), 180, 90)
'        path.AddLine(radio, 0, Me.Width - radio, 0)
'        path.AddArc(New Rectangle(Me.Width - radio, 0, radio, radio), -90, 90)
'        path.AddLine(Me.Width, radio, Me.Width, Me.Height - radio)
'        path.AddArc(New Rectangle(Me.Width - radio, Me.Height - radio, radio, radio), 0, 90)
'        path.AddLine(Me.Width - radio, Me.Height, radio, Me.Height)
'        path.AddArc(New Rectangle(0, Me.Height - radio, radio, radio), 90, 90)
'        path.CloseFigure()
'        Me.Region = New Region(path)
'    End Sub
'#End Region

'#Region "Metodos"
'    ' -------------------------
'    ' Método estático para mostrar
'    ' -------------------------
'    Public Shared Function Mostrar(titulo As String, mensaje As String,
'                                   tipo As TipoMensaje,
'                                   botones As TipoBotones) As DialogResult
'        Using msg As New MessageBoxUI(titulo, mensaje, tipo, botones)
'            Return msg.ShowDialog()
'        End Using
'    End Function
'#End Region

'End Class


