Imports FontAwesome.Sharp
Imports MaterialSkin3.Controls

Public Class PasswordTextBoxLabelUI
    Inherits BaseTextBoxLabelUI
    Implements IValidable

    Public Sub New()
        MyBase.New()
        lblTitulo.Text = "Contraseña:"
        txtCampo.UseSystemPasswordChar = True
        iconoDerecha.IconChar = IconChar.Lock
        Me.Placeholder = "Ingrese contraseña"
        txtCampo.PasswordChar = "*"c
        AddHandler txtCampo.KeyPress, AddressOf EsValido

    End Sub

    Public Function EsValido() As Boolean Implements IValidable.EsValido
        If Not MyBase.EsValido() Then Return False
        If txtCampo.Text.Length < 5 Then
            MostrarError("Debe tener al menos 5 caracteres.")
            Return False
        ElseIf txtCampo.Text.Length = 0 Then
            MostrarError(AppMensajes.msgCampoRequerido)
            Return False
        ElseIf txtCampo.Text.Length = 5 Then
            OnPanelResize(Nothing, Nothing)
            lblError.Visible = False
            Return True
        End If
        Return True
    End Function

End Class
