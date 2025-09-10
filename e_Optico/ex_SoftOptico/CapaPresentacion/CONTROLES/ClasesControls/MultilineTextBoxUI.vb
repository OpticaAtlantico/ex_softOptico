Public Class MultilineTextBoxUI
    Inherits BaseTextBoxLabelUI

    Private WithEvents txtMultilinea As TextBox

    Public Sub New()
        MyBase.New()
        Me.Placeholder = "Escriba un párrafo..."

        ' Obtenemos el TextBox original del BaseTextBoxLabelUI
        txtMultilinea = Me.Controls.OfType(Of Panel).First().Controls.OfType(Of TextBox).First()

        ' Configuración para párrafos largos
        txtMultilinea.Multiline = True
        txtMultilinea.ScrollBars = ScrollBars.Vertical
        txtMultilinea.Dock = DockStyle.Fill
        txtMultilinea.Margin = New Padding(5)

        ' Altura mínima inicial
        Me.MinimumSize = New Size(150, 100)
        Me.Height = 120
    End Sub

    ' Ajustamos automáticamente al redimensionar
    Private Sub MultilineTextBoxUI_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        ' El TextBox siempre ocupará todo el panel de fondo
        If txtMultilinea IsNot Nothing Then
            txtMultilinea.Dock = DockStyle.Fill
        End If
    End Sub
End Class
