Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Enum TipoToastUI
    Info
    Success
    Warning
    Errores
End Enum

Public Class ToastUI
    Inherits Form

    Private ReadOnly lblTexto As New Label()
    Private ReadOnly temporizador As New Timer()
    Private duracionMs As Integer = 3000

    Public Sub New()
        Me.FormBorderStyle = FormBorderStyle.None
        Me.ShowInTaskbar = False
        Me.StartPosition = FormStartPosition.Manual
        Me.TopMost = True
        Me.Size = New Size(300, 50)
        Me.Opacity = 0
        Me.DoubleBuffered = True
        Me.BackColor = Color.Black
        Me.Font = New Font("Century Gothic", 10)
        Me.Padding = New Padding(12, 8, 12, 8)

        lblTexto.Dock = DockStyle.Fill
        lblTexto.ForeColor = Color.White
        lblTexto.TextAlign = ContentAlignment.MiddleLeft
        Me.Controls.Add(lblTexto)

        AddHandler temporizador.Tick, AddressOf Timer_Tick
    End Sub

    Public Sub MostrarToast(mensaje As String, tipo As TipoToastUI, Optional tiempoMs As Integer = 3000)
        Me.duracionMs = tiempoMs
        lblTexto.Text = mensaje
        ConfigurarEstiloPorTipo(tipo)

        ' Posición en esquina inferior derecha del formulario activo
        Dim mainForm = Form.ActiveForm
        If mainForm IsNot Nothing Then
            Dim x = mainForm.Location.X + mainForm.Width - Me.Width - 20
            Dim y = mainForm.Location.Y + mainForm.Height - Me.Height - 40
            Me.Location = New Point(x, y)
        Else
            Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - Me.Width - 20,
                                    Screen.PrimaryScreen.WorkingArea.Height - Me.Height - 20)
        End If

        Me.Show()
        FadeIn()
        temporizador.Interval = duracionMs
        temporizador.Start()
    End Sub

    Private Sub ConfigurarEstiloPorTipo(tipo As TipoToastUI)
        Select Case tipo
            Case TipoToastUI.Info
                Me.BackColor = Color.DodgerBlue
                lblTexto.ForeColor = Color.White
            Case TipoToastUI.Success
                Me.BackColor = Color.SeaGreen
                lblTexto.ForeColor = Color.White
            Case TipoToastUI.Warning
                Me.BackColor = Color.DarkOrange
                lblTexto.ForeColor = Color.White
            Case TipoToastUI.Errores
                Me.BackColor = Color.Firebrick
                lblTexto.ForeColor = Color.White
        End Select
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs)
        temporizador.Stop()
        FadeOut()
    End Sub

    Private Async Sub FadeIn()
        While Me.Opacity < 1
            Await Task.Delay(20)
            Me.Opacity += 0.05
        End While
    End Sub

    Private Async Sub FadeOut()
        While Me.Opacity > 0
            Await Task.Delay(20)
            Me.Opacity -= 0.05
        End While
        Me.Close()
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim rect = New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)
        Dim path = RoundedPath(rect, 12)
        Using fondoBrush As New SolidBrush(Me.BackColor)
            e.Graphics.FillPath(fondoBrush, path)
        End Using
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

    'como usarlo

    'Dim toast As New ToastUI()
    'toast.MostrarToast("Guardado exitosamente", TipoToastUI.Success)

End Class
