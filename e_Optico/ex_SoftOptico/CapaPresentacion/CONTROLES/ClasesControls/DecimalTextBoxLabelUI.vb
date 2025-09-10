Imports FontAwesome.Sharp

Public Class DecimalTextBoxLabelUI
    Inherits BaseTextBoxLabelUI

    Private WithEvents txtDecimal As TextBox

    ' === Propiedades configurables ===
    Public Property DecimalesPermitidos As Integer = 2
    Public Property UsarSeparadorMiles As Boolean = True
    Public Property NumeroMinimo As Decimal = Decimal.MinValue
    Public Property NumeroMaximo As Decimal = Decimal.MaxValue
    Public Property MensajeErrorNumeroInvalido As String = "Ingrese un número válido."
    Public Property MensajeErrorRango As String = "El valor está fuera del rango permitido."

    Public Sub New()
        MyBase.New()
        Me.Placeholder = "Ingrese un número decimal..."

        ' Obtenemos el TextBox del Base
        txtDecimal = Me.Controls.OfType(Of Panel).First().Controls.OfType(Of TextBox).First()

        ' Alineación numérica a la derecha
        txtDecimal.TextAlign = HorizontalAlignment.Right
    End Sub

    ' === Restricción en tiempo real ===
    Private Sub txtDecimal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDecimal.KeyPress
        Dim separadorDecimal As String = Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator

        If Char.IsControl(e.KeyChar) Then
            Return
        End If

        If Char.IsDigit(e.KeyChar) Then
            Return
        End If

        ' Permitir un solo separador decimal
        If e.KeyChar.ToString() = separadorDecimal AndAlso Not txtDecimal.Text.Contains(separadorDecimal) Then
            Return
        End If

        e.Handled = True
    End Sub

    ' === Validar en tiempo real ===
    Private Sub txtDecimal_TextChanged(sender As Object, e As EventArgs) Handles txtDecimal.TextChanged
        EsValido()
    End Sub

    ' === Validar al perder foco ===
    Private Sub txtDecimal_Leave(sender As Object, e As EventArgs) Handles txtDecimal.Leave
        If String.IsNullOrWhiteSpace(txtDecimal.Text) Then
            EsValido()
            Exit Sub
        End If

        Dim valor As Decimal
        If Decimal.TryParse(txtDecimal.Text, valor) Then
            ' Formatear con separadores y decimales
            Dim formato As String = If(UsarSeparadorMiles, "N" & DecimalesPermitidos, "F" & DecimalesPermitidos)
            txtDecimal.Text = valor.ToString(formato)
        End If

        EsValido()
    End Sub

    ' === Validación principal ===
    Public Overrides Function EsValido() As Boolean
        Dim texto As String = txtDecimal.Text.Trim()
        Dim mensajeError As String = ""
        Dim _esValido As Boolean = True

        ' Campo requerido (del base)
        If CampoRequerido AndAlso String.IsNullOrWhiteSpace(texto) Then
            mensajeError = mensajeError
            _esValido = False

        ElseIf Not String.IsNullOrWhiteSpace(texto) Then
            Dim valor As Decimal
            If Not Decimal.TryParse(texto, valor) Then
                mensajeError = MensajeErrorNumeroInvalido
                _esValido = False
            ElseIf valor < NumeroMinimo OrElse valor > NumeroMaximo Then
                mensajeError = MensajeErrorRango
                _esValido = False
            End If
        End If

        ' Mostrar resultado visual
        If Not _esValido Then
            MostrarError(mensajeError)
        Else
            OcultarError()
        End If

        Return _esValido
    End Function
End Class
