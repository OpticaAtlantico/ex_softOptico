Imports FontAwesome.Sharp

Public Class PasswordTextBoxLabelUI
    Inherits BaseTextBoxLabelUI

    Public Sub New()
        MyBase.New()
        lblTitulo.Text = "Contraseña:"
        txtCampo.UseSystemPasswordChar = True
        iconoDerecha.IconChar = IconChar.Lock
        Me.Placeholder = "Ingrese contraseña"
        txtCampo.PasswordChar = "*"c
    End Sub

    Public Overrides Function EsValido() As Boolean
        If Not MyBase.EsValido() Then Return False
        If txtCampo.Text.Length < 6 Then
            lblError.Text = "Debe tener al menos 6 caracteres."
            lblError.Visible = True
            Return False
        End If
        Return True
    End Function
End Class
