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
#End Region

#Region "PROCEDIMIENTOS DEL COMBO"
    Protected Overrides Sub OnEnter(e As EventArgs)
        MyBase.OnEnter(e)
        ' 🔹 Siempre que el control compuesto recibe el foco, 
        ' lo pasamos directamente al cmbCampo
        cmbCampo.Focus()
    End Sub
#End Region

#Region "VALIDACIONES"
    Public Function EsValido() As Boolean Implements IValidable.EsValido
        If Not MyBase.EsValido() Then Return False
        Return True
    End Function

#End Region


End Class
