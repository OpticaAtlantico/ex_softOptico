Public Class FondoOverlayUI
    Inherits Form

    Public Sub New()
        Me.FormBorderStyle = FormBorderStyle.None
        Me.StartPosition = FormStartPosition.Manual
        Me.ShowInTaskbar = False
        Me.TopMost = False
        Me.BackColor = Color.Black
        Me.Opacity = 0.4R ' Semitransparente
        Me.Bounds = Screen.PrimaryScreen.Bounds
    End Sub


End Class

