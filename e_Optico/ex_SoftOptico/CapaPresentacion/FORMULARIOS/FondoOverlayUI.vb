Public Class FondoOverlayUI
    Inherits Form

    Public Sub New()
        Me.FormBorderStyle = FormBorderStyle.None
        Me.WindowState = FormWindowState.Maximized
        Me.BackColor = Color.Black
        Me.Opacity = 0.5R ' Nivel de transparencia
        Me.ShowInTaskbar = False
        Me.TopMost = True
        Me.StartPosition = FormStartPosition.Manual
    End Sub

End Class