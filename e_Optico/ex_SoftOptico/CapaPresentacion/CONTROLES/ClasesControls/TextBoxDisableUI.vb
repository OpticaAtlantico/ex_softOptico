Imports FontAwesome.Sharp
Imports System.Drawing

Public Class TextBoxDisableUI
    Inherits BaseTextBoxLabelUI

    Public Sub New()
        MyBase.New()

        ' Configuración por defecto
        lblTitulo.Text = "Texto:"
        iconoDerecha.IconChar = IconChar.Font
        IconoColor = AppColors._cFondoDisable
        PaddingIzquierdaIcono = 0
        ' 🔹 Forzar estado deshabilitado
        PaddingIzquierda = 1
        txtCampo.AutoSize = False
        txtCampo.Size = New Size(pnlFondo.Width, pnlFondo.Height - 7)
        txtCampo.ReadOnly = True
        txtCampo.Enabled = False
        txtCampo.BackColor = AppColors._cFondoDisable   ' gris de fondo
        txtCampo.ForeColor = Color.Gray                 ' texto gris
        lblPlaceholder.Visible = False

        ' 🔹 Quitar el highlight de foco
        Me.TabStop = False


    End Sub
End Class

