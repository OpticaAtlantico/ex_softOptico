Imports System.Drawing.Drawing2D
Imports FontAwesome.Sharp

Public Class MessageBoxUI
    Inherits Form

    Public Property Resultado As DialogResult = DialogResult.None

    ' === Controles ===
    Private fondoPanel As New Panel()
    Private lblTitulo As New Label()
    Private lblMensaje As New Label()
    Private iconoDecorativo As New IconPictureBox()
    Private btnAceptar As New Button()
    Private btnCancelar As New Button()
    Private btnSi As New Button()
    Private btnNo As New Button()

    Public Enum TipoBotones
        Aceptar
        AceptarCancelar
        SiNo
    End Enum

    Public Sub New()
        Me.FormBorderStyle = FormBorderStyle.None
        Me.StartPosition = FormStartPosition.CenterParent
        Me.Size = New Size(500, 220)
        Me.BackColor = Color.FromArgb(240, 240, 240) ' Color de fondo claro) 
        Me.Opacity = 0.95R
        Me.ShowInTaskbar = False
        Me.TopMost = True
        Me.DoubleBuffered = True
        Me.Padding = New Padding(3)
        Me.Region = New Region(RoundedPath(Me.ClientRectangle, 16))

        fondoPanel.Dock = DockStyle.Fill
        fondoPanel.BackColor = Color.White
        fondoPanel.Region = New Region(RoundedPath(Me.ClientRectangle, 16))
        fondoPanel.Padding = New Padding(20)
        Me.Controls.Add(fondoPanel)

        CrearControles()
    End Sub

    Private Sub CrearControles()
        ' Icono
        iconoDecorativo.Size = New Size(48, 48)
        iconoDecorativo.Location = New Point(20, 20)
        iconoDecorativo.IconColor = Color.DodgerBlue
        iconoDecorativo.IconChar = IconChar.CircleInfo
        fondoPanel.Controls.Add(iconoDecorativo)

        ' Título
        lblTitulo.Font = New Font("Century Gothic", 14, FontStyle.Bold)
        lblTitulo.Location = New Point(80, 20)
        lblTitulo.Size = New Size(290, 30)
        lblTitulo.ForeColor = Color.FromArgb(40, 40, 40)
        fondoPanel.Controls.Add(lblTitulo)

        ' Mensaje
        lblMensaje.Font = New Font("Century Gothic", 11)
        lblMensaje.ForeColor = Color.DimGray
        lblMensaje.Location = New Point(20, 70)
        lblMensaje.Size = New Size(450, 50)
        lblMensaje.TextAlign = ContentAlignment.MiddleLeft
        fondoPanel.Controls.Add(lblMensaje)

        ' Botón aceptar
        btnAceptar.Text = "Aceptar"
        btnAceptar.Size = New Size(100, 38)
        btnAceptar.Location = New Point(200, 150)
        btnAceptar.BackColor = Color.DodgerBlue
        btnAceptar.ForeColor = Color.White
        btnAceptar.FlatStyle = FlatStyle.Flat
        AddHandler btnAceptar.Click, Sub()
                                         Resultado = DialogResult.OK
                                         Me.Close()
                                     End Sub
        fondoPanel.Controls.Add(btnAceptar)

        ' Botón cancelar
        btnCancelar.Text = "Cancelar"
        btnCancelar.Size = New Size(100, 38)
        btnCancelar.Location = New Point(300, 150)
        btnCancelar.BackColor = Color.Gray
        btnCancelar.ForeColor = Color.White
        btnCancelar.FlatStyle = FlatStyle.Flat
        AddHandler btnCancelar.Click, Sub()
                                          Resultado = DialogResult.Cancel
                                          Me.Close()
                                      End Sub
        fondoPanel.Controls.Add(btnCancelar)

        ' Botón Sí
        btnSi.Text = "Sí"
        btnSi.Size = New Size(100, 38)
        btnSi.Location = New Point(130, 150)
        btnSi.BackColor = Color.SeaGreen
        btnSi.ForeColor = Color.White
        btnSi.FlatStyle = FlatStyle.Flat
        AddHandler btnSi.Click, Sub()
                                    Resultado = DialogResult.Yes
                                    Me.Close()
                                End Sub
        fondoPanel.Controls.Add(btnSi)

        ' Botón No
        btnNo.Text = "No"
        btnNo.Size = New Size(100, 38)
        btnNo.Location = New Point(260, 150)
        btnNo.BackColor = Color.IndianRed
        btnNo.ForeColor = Color.White
        btnNo.FlatStyle = FlatStyle.Flat
        AddHandler btnNo.Click, Sub()
                                    Resultado = DialogResult.No
                                    Me.Close()
                                End Sub
        fondoPanel.Controls.Add(btnNo)
    End Sub

    Private Function RoundedPath(rect As Rectangle, radius As Integer) As GraphicsPath
        Dim path As New GraphicsPath()
        path.StartFigure()
        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90)
        path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90)
        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
        path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90)
        path.CloseFigure()
        Return path
    End Function

    Public Shared Function Mostrar(mensaje As String,
                                   Optional titulo As String = "Mensaje",
                                   Optional tipoIcono As IconChar = IconChar.InfoCircle,
                                   Optional tipoBoton As TipoBotones = TipoBotones.Aceptar) As DialogResult

        Using frm As New MessageBoxUI()
            frm.lblTitulo.Text = titulo
            frm.lblMensaje.Text = mensaje
            frm.iconoDecorativo.IconChar = tipoIcono

            ' Ocultar todos los botones primero
            frm.btnAceptar.Visible = False
            frm.btnCancelar.Visible = False
            frm.btnSi.Visible = False
            frm.btnNo.Visible = False

            Select Case tipoBoton
                Case TipoBotones.Aceptar
                    frm.btnAceptar.Visible = True
                    frm.btnAceptar.Location = New Point(150, 140)
                Case TipoBotones.AceptarCancelar
                    frm.btnAceptar.Visible = True
                    frm.btnCancelar.Visible = True
                Case TipoBotones.SiNo
                    frm.btnSi.Visible = True
                    frm.btnNo.Visible = True
            End Select

            frm.ShowDialog()
            Return frm.Resultado
        End Using
    End Function
End Class
