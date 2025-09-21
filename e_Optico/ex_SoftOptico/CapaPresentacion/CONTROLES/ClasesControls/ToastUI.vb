Imports System.Threading.Tasks
Imports System.Drawing.Drawing2D
Imports FontAwesome.Sharp

Public Enum TipoToastUI
    Primary
    Success
    Errors
    Warning
    Info
End Enum

Public Class ToastUI
    Inherits Form

    Private lblMensaje As New Label()
    Private iconoToast As New IconPictureBox()
    Private tiempoEnPantalla As Integer = 3000 ' Tiempo visible en ms
    Private colorFondo As Color = AppColors._cBaseSuccess
    Private velocidadFade As Double = 0.08 ' Velocidad de transición
    Private radioBorde As Integer = AppLayout.BorderRadiusMedius
    Private paddingInterior As Integer = AppLayout.Padding15

    Public Sub New(mensaje As String, tipo As TipoToastUI)
        ' Configuración básica
        Me.FormBorderStyle = FormBorderStyle.None
        Me.StartPosition = FormStartPosition.Manual
        Me.ShowInTaskbar = False
        Me.TopMost = True
        Me.Size = New Size(400, 80)
        Me.Opacity = 0 ' Inicia invisible
        Me.DoubleBuffered = True ' Evita parpadeo

        ' Posicionar en esquina inferior derecha
        Dim screenBounds = Screen.PrimaryScreen.WorkingArea
        Me.Location = New Point(screenBounds.Width - Me.Width - 20,
                                screenBounds.Height - Me.Height - 20)

        ' Cambiar color según tipo y asignar icono
        Dim iconoChar As IconChar = IconChar.InfoCircle
        Select Case tipo
            Case TipoToastUI.Primary
                colorFondo = AppColors._cBasePrimary
                iconoChar = IconChar.Pen
            Case TipoToastUI.Success
                colorFondo = AppColors._cBaseSuccess
                iconoChar = IconChar.CheckCircle
            Case TipoToastUI.Errors
                colorFondo = AppColors._cBaseDanger
                iconoChar = IconChar.TimesCircle
            Case TipoToastUI.Warning
                colorFondo = AppColors._cBaseWarning
                iconoChar = IconChar.ExclamationTriangle
            Case TipoToastUI.Info
                colorFondo = AppColors._cBaseInfo
                iconoChar = IconChar.InfoCircle
        End Select
        Me.BackColor = colorFondo

        ' === Icono a la izquierda ===
        iconoToast.IconChar = iconoChar
        iconoToast.IconColor = AppColors._cBlanco
        iconoToast.IconSize = 32
        iconoToast.SizeMode = PictureBoxSizeMode.CenterImage
        iconoToast.Location = New Point(paddingInterior, (Me.Height - iconoToast.Height) \ 2)
        Me.Controls.Add(iconoToast)

        ' === Label del mensaje ===
        lblMensaje.Text = mensaje
        lblMensaje.ForeColor = AppColors._cBlanco
        lblMensaje.Font = New Font(AppFonts.Century, AppFonts.SizeMedium, AppFonts.Regular)
        lblMensaje.AutoSize = False
        lblMensaje.TextAlign = ContentAlignment.MiddleLeft
        lblMensaje.Location = New Point(iconoToast.Right + paddingInterior, 0)
        lblMensaje.Size = New Size(Me.Width - iconoToast.Right - 2 * paddingInterior, Me.Height)
        Me.Controls.Add(lblMensaje)
    End Sub

    ' --- Bordes redondeados + sombra dibujada ---
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect As New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)

        ' Fondo redondeado
        Using path As GraphicsPath = GetRoundedRectPath(rect, radioBorde)
            Using brush As New SolidBrush(colorFondo)
                e.Graphics.FillPath(brush, path)
            End Using
        End Using

        ' Sombra difusa hacia afuera
        For i As Integer = 1 To 6
            Using path As GraphicsPath = GetRoundedRectPath(rect, radioBorde)
                Using pen As New Pen(Color.FromArgb(40 - (i * 5), Color.Black), i * 2)
                    e.Graphics.DrawPath(pen, path)
                End Using
            End Using
        Next
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

    Public Async Sub Mostrar()
        ' Fade In
        Me.Show()
        While Me.Opacity < 1
            Me.Opacity += velocidadFade
            Await Task.Delay(30)
        End While

        ' Espera en pantalla
        Await Task.Delay(tiempoEnPantalla)

        ' Fade Out
        While Me.Opacity > 0
            Me.Opacity -= velocidadFade
            Await Task.Delay(30)
        End While

        Me.Close()
    End Sub
End Class

