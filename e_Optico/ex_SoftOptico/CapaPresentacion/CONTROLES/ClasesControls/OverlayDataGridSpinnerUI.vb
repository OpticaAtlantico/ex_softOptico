Public Class OverlayDataGridSpinnerUI
    Inherits Panel

    Private spinnerIcon As Label

    Public Sub New()
        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor Or
                    ControlStyles.UserPaint Or
                    ControlStyles.AllPaintingInWmPaint Or
                    ControlStyles.OptimizedDoubleBuffer, True)
        Me.UpdateStyles()
        Me.Dock = DockStyle.Fill
        Me.BackColor = Color.FromArgb(50, Color.Black) ' Fondo semitransparente
        Me.Visible = False

        spinnerIcon = New Label() With {
            .AutoSize = True,
            .Font = New Font("Font Awesome 5 Free Solid", 26),
            .ForeColor = Color.White,
            .Text = Char.ConvertFromUtf32(CInt(FontAwesome.Sharp.IconChar.CircleNotch)),
            .Location = New Point(0, 0)
        }
        Me.Controls.Add(spinnerIcon)
    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        ' Centrar el spinner orbital
        spinnerIcon.Location = New Point((Me.Width - spinnerIcon.Width) \ 2,
                                         (Me.Height - spinnerIcon.Height) \ 2)
    End Sub

    Public Sub Mostrar()
        Me.Visible = True
        Me.BringToFront()
        Application.DoEvents()
    End Sub

    Public Sub Ocultar()
        Me.Visible = False
        Application.DoEvents()
    End Sub
End Class