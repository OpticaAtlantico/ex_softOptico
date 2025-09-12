Public Class prueba
    Private Sub prueba_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CommandButtonui1_Click(sender As Object, e As EventArgs) Handles CommandButtonui1.Click
        Dim alerta As New AlertUI()
        alerta.Tipo = AlertUI.AlertType.Danger
        alerta.Mensaje = "Ocurrió un error inesperado."
        alerta.Dock = DockStyle.Top
        Me.Controls.Add(alerta)
        alerta.BringToFront()
        alerta.Mostrar()
    End Sub
End Class