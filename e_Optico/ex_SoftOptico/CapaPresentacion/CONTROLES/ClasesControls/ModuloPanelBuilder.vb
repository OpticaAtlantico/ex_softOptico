Public Class ModuloPanelBuilder

    Private ReadOnly panelContenedor As Control
    Private ReadOnly datos As DataTable

    Public Sub New(panel As Control, tablaDatos As DataTable)
        panelContenedor = panel
        datos = tablaDatos
    End Sub

    Public Sub Renderizar()
        panelContenedor.Controls.Clear()

        For Each fila As DataRow In datos.Rows
            Dim card As New Panel With {
                .Width = 250,
                .Height = 60,
                .BackColor = Color.White,
                .Margin = New Padding(5)
            }

            Dim lblNombre As New Label With {
                .Text = fila("Nombre").ToString(),
                .Dock = DockStyle.Fill,
                .Font = New Font("Segoe UI", 10, FontStyle.Regular)
            }

            card.Controls.Add(lblNombre)
            panelContenedor.Controls.Add(card)
        Next
    End Sub

End Class