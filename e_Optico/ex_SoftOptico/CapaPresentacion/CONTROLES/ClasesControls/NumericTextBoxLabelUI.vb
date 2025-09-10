Imports FontAwesome.Sharp

Public Class NumericTextBoxLabelUI
    Inherits BaseTextBoxLabelUI

    Public Sub New()
        MyBase.New()
        lblTitulo.Text = "Número:"
        iconoDerecha.IconChar = IconChar.Hashtag
        Me.Placeholder = "Ingrese Número"
        AddHandler txtCampo.KeyPress, AddressOf ValidarNumeros
    End Sub

    Private Sub ValidarNumeros(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class
