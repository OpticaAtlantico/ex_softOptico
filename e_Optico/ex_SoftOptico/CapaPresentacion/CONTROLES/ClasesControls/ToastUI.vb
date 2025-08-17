Imports System.Runtime.InteropServices
Imports System.Threading.Tasks

Public Class ToastUI
    Inherits Form

    Private lblMensaje As New Label()
    Private tiempoEnPantalla As Integer = 3000 ' Tiempo visible en ms
    Private colorFondo As Color = Color.FromArgb(40, 167, 69) ' Verde éxito
    Private velocidadFade As Double = 0.08 ' Velocidad de transición

    Public Sub New(mensaje As String, tipo As TipoToastUI)
        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor Or
                    ControlStyles.UserPaint Or
                    ControlStyles.AllPaintingInWmPaint Or
                    ControlStyles.OptimizedDoubleBuffer, True)
        Me.UpdateStyles()
        ' Configuración básica
        Me.FormBorderStyle = FormBorderStyle.None
        Me.StartPosition = FormStartPosition.Manual
        Me.ShowInTaskbar = False
        Me.TopMost = True
        Me.BackColor = colorFondo
        Me.Size = New Size(300, 60)
        Me.Opacity = 0 ' Inicia invisible

        ' Posicionar en esquina inferior derecha
        Dim screenBounds = Screen.PrimaryScreen.WorkingArea
        Me.Location = New Point(screenBounds.Width - Me.Width - 20, screenBounds.Height - Me.Height - 20)

        ' Cambiar color según tipo
        Select Case tipo
            Case TipoToastUI.Success
                colorFondo = Color.FromArgb(40, 167, 69)
            Case TipoToastUI.Errors
                colorFondo = Color.FromArgb(220, 53, 69)
            Case TipoToastUI.Warning
                colorFondo = Color.FromArgb(255, 193, 7)
            Case TipoToastUI.Info
                colorFondo = Color.FromArgb(23, 162, 184)
        End Select
        Me.BackColor = colorFondo

        ' Texto del mensaje
        lblMensaje.Text = mensaje
        lblMensaje.Dock = DockStyle.Fill
        lblMensaje.ForeColor = Color.White
        lblMensaje.TextAlign = ContentAlignment.MiddleCenter
        lblMensaje.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        Me.Controls.Add(lblMensaje)
    End Sub

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

' Enumeración para tipos de toast
Public Enum TipoToastUI
    Success
    Errors
    Warning
    Info
End Enum

