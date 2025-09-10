Imports FontAwesome.Sharp

Public Class TextOnlyTextBoxLabelUI
    Inherits BaseTextBoxLabelUI

    Public Sub New()
        MyBase.New()
        lblTitulo.Text = "Texto:"
        iconoDerecha.IconChar = IconChar.Font
        Me.Placeholder = "Ingrese datos"
        AddHandler txtCampo.KeyPress, AddressOf ValidarLetras
    End Sub

    Private Sub ValidarLetras(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsLetter(e.KeyChar) AndAlso e.KeyChar <> " "c Then
            e.Handled = True
        End If
    End Sub
End Class
