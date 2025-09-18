Imports FontAwesome.Sharp

Public Class NumericTextBoxLabelUI
    Inherits BaseTextBoxLabelUI
    Implements ILimpiable
    Public Property TextString As String

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

    Protected Overrides Sub OnEnter(e As EventArgs)
        MyBase.OnEnter(e)
        ' 🔹 Siempre que el control compuesto recibe el foco, 
        ' lo pasamos directamente al txtCampo
        txtCampo.Focus()
    End Sub
    Public Sub Limpiar() Implements ILimpiable.Limpiar
        Me.TextString = ""
    End Sub
End Class
