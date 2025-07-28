Public Class GuardarControl
    Inherits UserControl

    Public Sub New()
        Me.Dock = DockStyle.Fill
        Me.BackColor = Color.White

        Dim lbl As New Label With {
            .Text = "Guardar el documento actual",
            .Font = New Font("Segoe UI", 16, FontStyle.Regular),
            .AutoSize = True,
            .Location = New Point(20, 20)
        }

        Me.Controls.Add(lbl)
    End Sub
End Class

