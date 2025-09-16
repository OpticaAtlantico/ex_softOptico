Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports FontAwesome.Sharp

Public Class ComboBoxLayoutUI
    Inherits BaseComboBoxUI
    Implements IValidable

#Region "CONSTRUCTOR"
    Public Sub New()
        MyBase.New()
        lblTitulo.Text = "Texto:"
        Me.Placeholder = "Selecciones una Opcion..."
    End Sub

    Public Function EsValido() As Boolean Implements IValidable.EsValido
        If Not MyBase.EsValido() Then Return False
        If cmbCampo.Text.Length < 5 Then
            MostrarError("Debe tener al menos 5 caracteres.")
            Return False
        ElseIf cmbCampo.Text.Length = 0 Then
            MostrarError(AppMensajes.msgCampoRequerido)
            Return False
        End If
        Return True
    End Function
#End Region


End Class
