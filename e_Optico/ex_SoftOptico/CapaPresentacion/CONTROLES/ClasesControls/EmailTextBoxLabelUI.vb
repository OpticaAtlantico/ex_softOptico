Imports FontAwesome.Sharp

Public Class EmailTextBoxLabelUI
    Inherits BaseTextBoxLabelUI
    Implements IValidable, ILimpiable

    Public Property TextString As String

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

    Public Sub New()
        MyBase.New()
        lblTitulo.Text = "Correo electrónico:"
        iconoDerecha.IconChar = IconChar.Envelope
    End Sub
    Public Sub Limpiar() Implements ILimpiable.Limpiar
        Me.TextString = ""
    End Sub
End Class
