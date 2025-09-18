Imports FontAwesome.Sharp

Public Class EmailTextBoxLabelUI
    Inherits BaseTextBoxLabelUI
    Implements IValidable

    Public Sub New()
        MyBase.New()
        lblTitulo.Text = "Correo electrónico:"
        iconoDerecha.IconChar = IconChar.Envelope
    End Sub

    Public Function EsValido() As Boolean Implements IValidable.EsValido
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
