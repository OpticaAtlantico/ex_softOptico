Public Class ucProductos
    Inherits UserControl

    Public Property TabPanelRef As TabPanelUI
    Public LlenarCombo As New LlenarComboBox
    Public Sub New()
        Me.InitializeComponent()
        Me.Dock = DockStyle.Fill
        Me.AutoSize = False
        Me.Margin = New Padding(0)
        Me.Padding = New Padding(0)
        Me.BackColor = Color.White

        AddHandler btnSiguiente.Click, Sub()
                                           AvanzarEntrePestañas()
                                       End Sub

        ' LlenarCombo.Cargar(cmbCategoria, LlenarCombo.SQL_CARGOEMPLEADOS, "Descripcion", "CargoEmpleadoID")

    End Sub
    Private Sub AvanzarEntrePestañas()
        If TabPanelRef IsNot Nothing Then
            TabPanelRef.AvanzarPestaña()
        End If
    End Sub


    'Public Function Validar() As Boolean
    '    ' Validación básica
    '    Return Not String.IsNullOrWhiteSpace(txtNombre.Text)
    'End Function
End Class
