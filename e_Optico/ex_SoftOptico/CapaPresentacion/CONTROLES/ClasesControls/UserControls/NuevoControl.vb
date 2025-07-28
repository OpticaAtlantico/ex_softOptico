Public Class NuevoControl
    Inherits UserControl

    Public Sub New()
        Me.Dock = DockStyle.Fill
        Me.BackColor = Color.White

        Dim lbl As New Label With {
            .Text = "Formulario: Nuevo Documento",
            .Font = New Font("Segoe UI", 18, FontStyle.Bold),
            .AutoSize = True,
            .Location = New Point(20, 20)
        }

        Me.Controls.Add(lbl)
    End Sub
End Class