Imports FontAwesome.Sharp

Public Class EmailTextBoxLabelUI
    Inherits BaseTextBoxLabelUI

    Public Sub New()
        MyBase.New()
        lblTitulo.Text = "Correo electrónico:"
        iconoDerecha.IconChar = IconChar.Envelope
    End Sub

    Public Overrides Function EsValido() As Boolean
        If Not MyBase.EsValido() Then Return False
        Try
            Dim addr As New Net.Mail.MailAddress(txtCampo.Text.Trim())
            Return True
        Catch
            lblError.Text = "Correo inválido."
            lblError.Visible = True
            Return False
        End Try
    End Function
End Class
