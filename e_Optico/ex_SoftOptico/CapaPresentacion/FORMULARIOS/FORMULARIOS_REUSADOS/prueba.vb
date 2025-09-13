Public Class prueba
    Private Sub prueba_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CommandButtonui1_Click(sender As Object, e As EventArgs) Handles CommandButtonui1.Click
        AlertManagerUI.MostrarAlerta(Me, AlertType.Warning, "hola ara todos")
    End Sub
End Class