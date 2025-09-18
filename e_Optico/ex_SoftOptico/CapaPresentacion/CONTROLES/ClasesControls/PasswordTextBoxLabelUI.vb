Imports FontAwesome.Sharp
Imports MaterialSkin3.Controls

Public Class PasswordTextBoxLabelUI
    Inherits BaseTextBoxLabelUI
    Implements IValidable, ILimpiable
    Public Property TextString As String
    Public Sub New()
        MyBase.New()
        lblTitulo.Text = "Contraseña:"
        txtCampo.UseSystemPasswordChar = True
        Me.MinCaracteres = 6
        iconoDerecha.IconChar = IconChar.Lock
        Me.Placeholder = "Ingrese contraseña"
        txtCampo.PasswordChar = "*"c
        'AddHandler txtCampo.KeyPress, AddressOf EsValido

    End Sub
    Protected Overrides Sub OnEnter(e As EventArgs)
        MyBase.OnEnter(e)
        ' 🔹 Siempre que el control compuesto recibe el foco, 
        ' lo pasamos directamente al txtCampo
        txtCampo.Focus()
    End Sub
    Public Function EsValido() As Boolean Implements IValidable.EsValido
        If Not MyBase.EsValido() Then Return False
        Return True
    End Function
    Public Sub Limpiar() Implements ILimpiable.Limpiar
        Me.TextString = ""
    End Sub

End Class
