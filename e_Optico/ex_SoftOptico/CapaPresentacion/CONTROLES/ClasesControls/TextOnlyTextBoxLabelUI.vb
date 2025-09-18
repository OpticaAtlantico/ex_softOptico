Imports DocumentFormat.OpenXml.Office2010.Excel
Imports FontAwesome.Sharp

Public Class TextOnlyTextBoxLabelUI
    Inherits BaseTextBoxLabelUI
    Implements IValidable
    Public Sub New()
        MyBase.New()
        lblTitulo.Text = "Texto:"
        iconoDerecha.IconChar = IconChar.Font
        Me.Placeholder = "Ingrese datos"
        'AddHandler txtCampo.KeyPress, AddressOf EsValido
    End Sub
    Public Function EsValido() As Boolean Implements IValidable.EsValido
        If Not MyBase.EsValido() Then Return False
        Return True
    End Function

    Protected Overrides Sub OnEnter(e As EventArgs)
        MyBase.OnEnter(e)
        ' 🔹 Siempre que el control compuesto recibe el foco, 
        ' lo pasamos directamente al txtCampo
        txtCampo.Focus()
    End Sub

End Class
