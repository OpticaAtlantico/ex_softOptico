Imports FontAwesome.Sharp

Public Class TextOnlyTextBoxLabelUI
    Inherits BaseTextBoxLabelUI
    Implements IValidable

    Public Sub New()
        MyBase.New()
        lblTitulo.Text = "Texto:"
        iconoDerecha.IconChar = IconChar.Font
        Me.Placeholder = "Ingrese datos"
        AddHandler txtCampo.KeyPress, AddressOf EsValido
    End Sub
    Public Function EsValido() As Boolean Implements IValidable.EsValido
        If Not MyBase.EsValido() Then Return False
        If txtCampo.Text.Length = 0 Then
            MostrarError(AppMensajes.msgCampoRequerido)
            Return False
        End If
        Return True
    End Function

End Class
