Imports System.Drawing.Drawing2D
Imports FontAwesome.Sharp

Public Enum TipoMensaje
    Exito
    Informacion
    Advertencia
    Errors
End Enum

Public Enum Botones
    Aceptar
    AceptarCancelar
End Enum

Public Class MssgBoxUI
    Inherits UserControl

    ' Resultado del MessageBox
    Private _resultado As DialogResult = DialogResult.None
    Public ReadOnly Property Resultado As DialogResult
        Get
            Return _resultado
        End Get
    End Property

    ' Controles
    Private panelBlur As New Panel()
    Private panelContenedor As New Panel()
    Private lblTitulo As New Label()
    Private lblMensaje As New Label()
    Private iconoDecorativo As New IconPictureBox()
    Private btnAceptar As New Button()
    Private btnCancelar As New Button()

    ' Variables internas
    Private _tipoMensaje As TipoMensaje = TipoMensaje.Informacion
    Private _botones As Botones = Botones.Aceptar

    Public Sub New()
        ' Inicializar UserControl
        Me.Dock = DockStyle.Fill
        Me.BackColor = Color.Transparent

        ' Panel que simula blur / fondo semitransparente
        panelBlur.Dock = DockStyle.Fill
        panelBlur.BackColor = Color.FromArgb(100, Color.Black)
        Me.Controls.Add(panelBlur)

        ' Panel contenedor con borde redondeado y fondo blanco
        panelContenedor.Size = New Size(400, 200)
        panelContenedor.BackColor = Color.White
        panelContenedor.Anchor = AnchorStyles.None
        panelContenedor.Location = New Point((Me.Width - panelContenedor.Width) \ 2, (Me.Height - panelContenedor.Height) \ 2)
        AddHandler panelContenedor.Resize, AddressOf PanelContenedor_Resize
        Me.Controls.Add(panelContenedor)
        panelContenedor.BringToFront()

        ' Borde redondeado para el panel contenedor
        AddHandler panelContenedor.Paint, AddressOf PanelContenedor_Paint

        ' Icono decorativo
        iconoDecorativo.IconSize = 48
        iconoDecorativo.Location = New Point(20, 20)
        iconoDecorativo.BackColor = Color.Transparent
        panelContenedor.Controls.Add(iconoDecorativo)

        ' Título
        lblTitulo.Font = New Font("Segoe UI Semibold", 14, FontStyle.Bold)
        lblTitulo.ForeColor = Color.FromArgb(40, 40, 40)
        lblTitulo.Location = New Point(80, 20)
        lblTitulo.AutoSize = True
        panelContenedor.Controls.Add(lblTitulo)

        ' Mensaje
        lblMensaje.Font = New Font("Segoe UI", 11)
        lblMensaje.ForeColor = Color.FromArgb(60, 60, 60)
        lblMensaje.Location = New Point(20, 70)
        lblMensaje.Size = New Size(panelContenedor.Width - 40, 70)
        lblMensaje.AutoEllipsis = True
        lblMensaje.MaximumSize = New Size(panelContenedor.Width - 40, 0)
        lblMensaje.AutoSize = True
        panelContenedor.Controls.Add(lblMensaje)

        ' Botones
        btnAceptar.Text = "Aceptar"
        btnAceptar.BackColor = Color.DodgerBlue
        btnAceptar.ForeColor = Color.White
        btnAceptar.FlatStyle = FlatStyle.Flat
        btnAceptar.FlatAppearance.BorderSize = 0
        btnAceptar.Size = New Size(130, 40)
        btnAceptar.Location = New Point(panelContenedor.Width - 150, panelContenedor.Height - 60)
        AddHandler btnAceptar.Click, AddressOf BtnAceptar_Click
        panelContenedor.Controls.Add(btnAceptar)

        btnCancelar.Text = "Cancelar"
        btnCancelar.BackColor = Color.OrangeRed
        btnCancelar.ForeColor = Color.White
        btnCancelar.FlatStyle = FlatStyle.Flat
        btnCancelar.FlatAppearance.BorderSize = 0
        btnCancelar.Size = New Size(130, 40)
        btnCancelar.Location = New Point(10, panelContenedor.Height - 60)
        AddHandler btnCancelar.Click, AddressOf BtnCancelar_Click
        panelContenedor.Controls.Add(btnCancelar)

        ' Por defecto ocultar botón cancelar
        btnCancelar.Visible = False

        ' Ajuste automático al redimensionar
        AddHandler Me.Resize, Sub(sender, e)
                                  panelContenedor.Location = New Point((Me.Width - panelContenedor.Width) \ 2, (Me.Height - panelContenedor.Height) \ 2)
                              End Sub

    End Sub

    ' Pinta el borde redondeado
    Private Sub PanelContenedor_Paint(sender As Object, e As PaintEventArgs)
        Dim rect As Rectangle = panelContenedor.ClientRectangle
        Dim radius As Integer = 20
        Using path As GraphicsPath = GetRoundedRectPath(rect, radius)
            Using pen As New Pen(Color.DodgerBlue, 3)
                e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                e.Graphics.DrawPath(pen, path)
            End Using
        End Using
    End Sub

    ' Mantiene posición al redimensionar
    Private Sub PanelContenedor_Resize(sender As Object, e As EventArgs)
        btnAceptar.Location = New Point(panelContenedor.Width - 150, panelContenedor.Height - 60)
        btnCancelar.Location = New Point(10, panelContenedor.Height - 60)
        lblMensaje.MaximumSize = New Size(panelContenedor.Width - 40, 0)
    End Sub

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

    ' Método público para configurar el MessageBoxUI
    Public Sub Configurar(titulo As String, mensaje As String, tipo As TipoMensaje, botones As Botones)
        _tipoMensaje = tipo
        _botones = botones

        lblTitulo.Text = titulo
        lblMensaje.Text = mensaje

        Select Case tipo
            Case TipoMensaje.Exito
                Me.BackColor = Color.FromArgb(220, 255, 220)
                iconoDecorativo.IconChar = IconChar.CheckCircle
                iconoDecorativo.IconColor = Color.Green
            Case TipoMensaje.Informacion
                Me.BackColor = Color.FromArgb(220, 235, 255)
                iconoDecorativo.IconChar = IconChar.InfoCircle
                iconoDecorativo.IconColor = Color.DodgerBlue
            Case TipoMensaje.Advertencia
                Me.BackColor = Color.FromArgb(255, 245, 220)
                iconoDecorativo.IconChar = IconChar.ExclamationTriangle
                iconoDecorativo.IconColor = Color.DarkOrange
            Case TipoMensaje.Errors
                Me.BackColor = Color.FromArgb(255, 220, 220)
                iconoDecorativo.IconChar = IconChar.TimesCircle
                iconoDecorativo.IconColor = Color.Red
        End Select

        ' Cambiar color del panelBlur para simular el blur con transparencia según tipo mensaje
        panelBlur.BackColor = Color.FromArgb(100, Me.BackColor.R, Me.BackColor.G, Me.BackColor.B)

        ' Botones
        btnAceptar.Text = "Aceptar"
        btnCancelar.Visible = False

        If botones = Botones.AceptarCancelar Then
            btnCancelar.Visible = True
            btnCancelar.Text = "Cancelar"
        End If
    End Sub

    ' Eventos botones
    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs)
        _resultado = DialogResult.OK
        RaiseEvent ResultadoCambiado(Me, EventArgs.Empty)
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs)
        _resultado = DialogResult.Cancel
        RaiseEvent ResultadoCambiado(Me, EventArgs.Empty)
    End Sub

    ' Evento para notificar cambio de resultado
    Public Event ResultadoCambiado(sender As Object, e As EventArgs)

End Class













'' MessageBoxUI.vb (UserControl embebido profesional con efecto blur y colores por tipo)
'Imports System.Drawing.Drawing2D
'Imports FontAwesome.Sharp

'Public Class MssgBoxUI
'    Inherits UserControl

'    ' === Enumeraciones ===
'    Public Enum TipoMensaje
'        Exito
'        Errors
'        Advertencia
'        Informacion
'    End Enum

'    Public Enum BotonesMensaje
'        Aceptar
'        AceptarCancelar
'    End Enum

'    ' === Propiedades Públicas ===
'    Public Property Titulo As String = "Mensaje"
'    Public Property Mensaje As String = "Contenido del mensaje."
'    Public Property Tipo As TipoMensaje = TipoMensaje.Informacion
'    Public Property Botones As BotonesMensaje = BotonesMensaje.Aceptar

'    Public Property Resultado As DialogResult = DialogResult.None

'    ' === Controles Internos ===
'    Private WithEvents fondoOverlay As New Form()
'    Private contenedor As New Form() ' Formulario contenedor (blur y modal)
'    Private fondoPanel As New Panel()
'    Private lblTitulo As New Label()
'    Private lblMensaje As New Label()
'    Private btnAceptar As New Button()
'    Private btnCancelar As New Button()
'    Private icono As New IconPictureBox()

'    Public Sub New()
'        Inicializar()
'    End Sub

'    Private Sub Inicializar()
'        ' === FondoOscuro (blur) ===
'        fondoOverlay.FormBorderStyle = FormBorderStyle.None
'        fondoOverlay.Opacity = 0.4R
'        fondoOverlay.BackColor = Color.Black
'        fondoOverlay.ShowInTaskbar = False
'        fondoOverlay.StartPosition = FormStartPosition.Manual
'        fondoOverlay.Bounds = Screen.PrimaryScreen.Bounds
'        fondoOverlay.TopMost = True

'        ' === Formulario contenedor ===
'        contenedor.FormBorderStyle = FormBorderStyle.None
'        contenedor.StartPosition = FormStartPosition.CenterScreen
'        contenedor.BackColor = Color.White
'        contenedor.ShowInTaskbar = False
'        contenedor.TopMost = True
'        contenedor.Size = New Size(460, 240)
'        contenedor.Padding = New Padding(10)
'        contenedor.Controls.Add(Me)

'        ' === UserControl ===
'        Me.Dock = DockStyle.Fill
'        Me.BackColor = Color.White
'        Me.Region = New Region(RoundedPath(Me.ClientRectangle, 20))
'        Me.Margin = New Padding(0)
'        Me.Padding = New Padding(0)

'        ' === Panel Fondo ===
'        fondoPanel.Dock = DockStyle.Fill
'        fondoPanel.BackColor = Color.White
'        fondoPanel.Padding = New Padding(20)
'        fondoPanel.Region = New Region(RoundedPath(Me.ClientRectangle, 20))
'        Me.Controls.Add(fondoPanel)

'        ' === Icono ===
'        icono.IconChar = IconChar.InfoCircle
'        icono.IconColor = Color.DodgerBlue
'        icono.IconSize = 40
'        icono.Location = New Point(20, 20)
'        icono.Size = New Size(40, 40)
'        fondoPanel.Controls.Add(icono)

'        ' === Título ===
'        lblTitulo.Font = New Font("Segoe UI", 14, FontStyle.Bold)
'        lblTitulo.ForeColor = Color.Black
'        lblTitulo.AutoSize = True
'        lblTitulo.Location = New Point(70, 25)
'        fondoPanel.Controls.Add(lblTitulo)

'        ' === Mensaje ===
'        lblMensaje.Font = New Font("Segoe UI", 11, FontStyle.Regular)
'        lblMensaje.ForeColor = Color.DimGray
'        lblMensaje.AutoSize = False
'        lblMensaje.MaximumSize = New Size(400, 100)
'        lblMensaje.Location = New Point(20, 75)
'        lblMensaje.Size = New Size(400, 60)
'        fondoPanel.Controls.Add(lblMensaje)

'        ' === Botón Aceptar ===
'        btnAceptar.Text = "Aceptar"
'        btnAceptar.Font = New Font("Segoe UI", 11, FontStyle.Regular)
'        btnAceptar.Size = New Size(130, 40)
'        btnAceptar.BackColor = Color.DodgerBlue
'        btnAceptar.ForeColor = Color.White
'        btnAceptar.FlatStyle = FlatStyle.Flat
'        btnAceptar.FlatAppearance.BorderSize = 0
'        btnAceptar.Location = New Point(90, 150)
'        AddHandler btnAceptar.Click, AddressOf BtnAceptar_Click
'        fondoPanel.Controls.Add(btnAceptar)

'        ' === Botón Cancelar ===
'        btnCancelar.Text = "Cancelar"
'        btnCancelar.Font = New Font("Segoe UI", 11, FontStyle.Regular)
'        btnCancelar.Size = New Size(130, 40)
'        btnCancelar.BackColor = Color.OrangeRed
'        btnCancelar.ForeColor = Color.White
'        btnCancelar.FlatStyle = FlatStyle.Flat
'        btnCancelar.FlatAppearance.BorderSize = 0
'        btnCancelar.Location = New Point(230, 150)
'        AddHandler btnCancelar.Click, AddressOf BtnCancelar_Click
'        fondoPanel.Controls.Add(btnCancelar)
'    End Sub

'    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs)
'        Resultado = DialogResult.OK
'        fondoOverlay.Close()
'        contenedor.Close()
'    End Sub

'    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs)
'        Resultado = DialogResult.Cancel
'        fondoOverlay.Close()
'        contenedor.Close()
'    End Sub

'    Public Function MostrarMensaje(titulo As String,
'                                   mensaje As String,
'                                   tipo As TipoMensaje,
'                                   botones As BotonesMensaje) As DialogResult

'        Me.Titulo = titulo
'        Me.Mensaje = mensaje
'        Me.Tipo = tipo
'        Me.Botones = botones

'        ' Establecer texto
'        lblTitulo.Text = titulo
'        lblMensaje.Text = mensaje

'        ' Establecer icono y color de fondo (BackColor del contenedor)
'        Select Case tipo
'            Case TipoMensaje.Exito
'                icono.IconChar = IconChar.CheckCircle
'                icono.IconColor = Color.SeaGreen
'                contenedor.BackColor = Color.SeaGreen
'            Case TipoMensaje.Errors
'                icono.IconChar = IconChar.TimesCircle
'                icono.IconColor = Color.Firebrick
'                contenedor.BackColor = Color.Firebrick
'            Case TipoMensaje.Advertencia
'                icono.IconChar = IconChar.ExclamationTriangle
'                icono.IconColor = Color.Goldenrod
'                contenedor.BackColor = Color.Goldenrod
'            Case TipoMensaje.Informacion
'                icono.IconChar = IconChar.InfoCircle
'                icono.IconColor = Color.DodgerBlue
'                contenedor.BackColor = Color.DodgerBlue
'        End Select

'        ' Mostrar u ocultar botones
'        Select Case botones
'            Case BotonesMensaje.Aceptar
'                btnAceptar.Visible = True
'                btnCancelar.Visible = False
'                btnAceptar.Location = New Point((Me.Width - btnAceptar.Width) \ 2, 150)
'            Case BotonesMensaje.AceptarCancelar
'                btnAceptar.Visible = True
'                btnCancelar.Visible = True
'        End Select

'        ' Mostrar fondoOverlay y luego el contenedor
'        fondoOverlay.Show()
'        contenedor.ShowDialog()

'        Return Resultado
'    End Function

'    Private Function RoundedPath(rect As Rectangle, radius As Integer) As GraphicsPath
'        Dim path As New GraphicsPath()
'        path.StartFigure()
'        path.AddArc(rect.Left, rect.Top, radius, radius, 180, 90)
'        path.AddArc(rect.Right - radius, rect.Top, radius, radius, 270, 90)
'        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
'        path.AddArc(rect.Left, rect.Bottom - radius, radius, radius, 90, 90)
'        path.CloseFigure()
'        Return path
'    End Function

'    ' === Método Estático (Shared) para usar fácilmente ===
'    Public Shared Function Show(titulo As String,
'                                mensaje As String,
'                                Optional tipo As TipoMensaje = TipoMensaje.Informacion,
'                                Optional botones As BotonesMensaje = BotonesMensaje.Aceptar) As DialogResult

'        Dim msgbox As New MssgBoxUI()
'        Return msgbox.MostrarMensaje(titulo, mensaje, tipo, botones)

'    End Function

'End Class