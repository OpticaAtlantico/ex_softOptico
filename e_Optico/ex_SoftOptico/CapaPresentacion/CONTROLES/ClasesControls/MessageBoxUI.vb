Imports System.Drawing.Drawing2D
Imports FontAwesome.Sharp

Public Enum TipoMensaje
    Exito
    Errors
    Advertencia
    Informacion
End Enum

Public Enum Botones
    Aceptar
    AceptarCancelar
    SiNo
End Enum

Public Class MessageBoxUI
    Inherits Form

    Private tipoBotonesActual As Botones

    Private lblTitulo As New Label()
    Private lblMensaje As New Label()
    Private icono As New IconPictureBox()
    Private btnAceptar As New Button()
    Private btnCancelar As New Button()
    Private btnSi As New Button()
    Private btnNo As New Button()
    Private panelFondo As New Panel()
    Private blurFondo As New Form()

    Public Property Resultado As DialogResult = DialogResult.None

    Public Sub New()
        ' Tamaño y estilo del Formulario MessageBoxUI
        Me.FormBorderStyle = FormBorderStyle.None
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(400, 250)
        Me.BackColor = Color.White
        Me.TopMost = True
        Me.ShowInTaskbar = False
        Me.DoubleBuffered = True

        ' Fondo redondeado
        RedondearBordes()

        ' Panel contenedor
        panelFondo.Dock = DockStyle.Fill
        panelFondo.BackColor = Color.White
        Me.Controls.Add(panelFondo)

        ' Icono
        icono.Size = New Size(55, 55)
        icono.IconChar = IconChar.InfoCircle
        icono.IconColor = Color.DodgerBlue
        icono.IconSize = 40
        icono.Location = New Point(20, 20)
        panelFondo.Controls.Add(icono)

        ' Título
        lblTitulo.Font = New Font("Segoe UI Semibold", 16, FontStyle.Bold)
        lblTitulo.AutoSize = True
        lblTitulo.Location = New Point(70, 25)
        panelFondo.Controls.Add(lblTitulo)

        ' Mensaje
        lblMensaje.Font = New Font("Segoe UI", 12)
        lblMensaje.MaximumSize = New Size(390, 0)
        lblMensaje.AutoSize = True
        lblMensaje.Location = New Point(20, 90)
        panelFondo.Controls.Add(lblMensaje)

        ' Botón Aceptar
        btnAceptar.Text = "Aceptar"
        btnAceptar.Size = New Size(100, 35)
        btnAceptar.FlatStyle = FlatStyle.Flat
        btnAceptar.FlatAppearance.BorderSize = 0
        btnAceptar.BackColor = Color.FromArgb(52, 152, 219)
        btnAceptar.ForeColor = Color.White
        AddHandler btnAceptar.Click, AddressOf BtnAceptar_Click
        panelFondo.Controls.Add(btnAceptar)

        ' Botón Cancelar
        btnCancelar.Text = "Cancelar"
        btnCancelar.Size = New Size(100, 35)
        btnCancelar.FlatStyle = FlatStyle.Flat
        btnCancelar.FlatAppearance.BorderSize = 0
        btnCancelar.BackColor = Color.Gray
        btnCancelar.ForeColor = Color.White
        AddHandler btnCancelar.Click, AddressOf BtnCancelar_Click
        panelFondo.Controls.Add(btnCancelar)

        btnSi.Text = "Sí"
        btnSi.Size = New Size(100, 35)
        btnSi.FlatStyle = FlatStyle.Flat
        btnSi.FlatAppearance.BorderSize = 0
        btnSi.BackColor = Color.FromArgb(52, 152, 219)
        btnSi.ForeColor = Color.White
        AddHandler btnSi.Click, AddressOf BtnSi_Click
        panelFondo.Controls.Add(btnSi)

        btnNo.Text = "No"
        btnNo.Size = New Size(100, 35)
        btnNo.FlatStyle = FlatStyle.Flat
        btnNo.FlatAppearance.BorderSize = 0
        btnNo.BackColor = Color.Gray
        btnNo.ForeColor = Color.White
        AddHandler btnNo.Click, AddressOf BtnNo_Click
        panelFondo.Controls.Add(btnNo)

    End Sub

    Public Sub Configurar(titulo As String, mensaje As String, tipo As TipoMensaje, botones As Botones)
        lblTitulo.Text = titulo
        lblMensaje.Text = mensaje

        ' Tipo de mensaje: colores e íconos
        Select Case tipo
            Case TipoMensaje.Exito
                icono.IconChar = IconChar.CheckCircle
                icono.IconColor = Color.SeaGreen
                Me.BackColor = Color.SeaGreen
            Case TipoMensaje.Errors
                icono.IconChar = IconChar.TimesCircle
                icono.IconColor = Color.Firebrick
                Me.BackColor = Color.Firebrick
            Case TipoMensaje.Advertencia
                icono.IconChar = IconChar.ExclamationTriangle
                icono.IconColor = Color.DarkOrange
                Me.BackColor = Color.DarkOrange
            Case TipoMensaje.Informacion
                icono.IconChar = IconChar.InfoCircle
                icono.IconColor = Color.DodgerBlue
                Me.BackColor = Color.DodgerBlue
        End Select

        ' Mostrar botones
        Select Case botones
            Case botones.Aceptar
                btnAceptar.Visible = True
                btnCancelar.Visible = False
                btnSi.Visible = False
                btnNo.Visible = False
                btnAceptar.Location = New Point((Me.Width - btnAceptar.Width) \ 2, Me.Height - 60)
            Case botones.AceptarCancelar
                btnAceptar.Visible = True
                btnCancelar.Visible = True
                btnSi.Visible = False
                btnNo.Visible = False
                btnAceptar.Location = New Point(Me.Width \ 2 - 110, Me.Height - 60)
                btnCancelar.Location = New Point(Me.Width \ 2 + 10, Me.Height - 60)
            Case Botones.SiNo
                btnSi.Visible = True
                btnNo.Visible = True
                btnAceptar.Visible = False
                btnCancelar.Visible = False
                btnSi.Location = New Point(Me.Width \ 2 - 110, Me.Height - 60)
                btnNo.Location = New Point(Me.Width \ 2 + 10, Me.Height - 60)
        End Select
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs)
        Resultado = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs)
        Resultado = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BtnSi_Click(sender As Object, e As EventArgs)
        Resultado = DialogResult.Yes
        Me.Close()
    End Sub

    Private Sub BtnNo_Click(sender As Object, e As EventArgs)
        Resultado = DialogResult.No
        Me.Close()
    End Sub

    ' Muestra el fondo semitransparente
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

    Protected Overrides Sub OnShown(e As EventArgs)
        MyBase.OnShown(e)
        MostrarFondoOverlay()
    End Sub

    Protected Overrides Sub OnFormClosed(e As FormClosedEventArgs)
        MyBase.OnFormClosed(e)
        OcultarFondoOverlay()
    End Sub

    ' Método público para usarlo de forma modal
    Public Shared Function Mostrar(titulo As String, mensaje As String, tipo As TipoMensaje, botones As Botones) As DialogResult
        Dim frm As New MessageBoxUI()
        frm.Configurar(titulo, mensaje, tipo, botones)
        frm.ShowDialog()
        Return frm.Resultado
    End Function

    Private Sub RedondearBordes(Optional radio As Integer = 20)
        Dim path As New GraphicsPath()
        path.StartFigure()
        path.AddArc(New Rectangle(0, 0, radio, radio), 180, 90)
        path.AddArc(New Rectangle(Me.Width - radio, 0, radio, radio), 270, 90)
        path.AddArc(New Rectangle(Me.Width - radio, Me.Height - radio, radio, radio), 0, 90)
        path.AddArc(New Rectangle(0, Me.Height - radio, radio, radio), 90, 90)
        path.CloseFigure()
        Me.Region = New Region(path)
    End Sub

End Class
