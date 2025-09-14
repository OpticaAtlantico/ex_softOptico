Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports FontAwesome.Sharp

Public Class ComboUI
    Inherits BaseComboBoxUI

#Region "CONSTRUCTOR"
    Public Sub New()
        MyBase.New()
        lblTitulo.Text = "Texto:"
        Me.Placeholder = "Selecciones una Opcion..."
    End Sub
#End Region


End Class
