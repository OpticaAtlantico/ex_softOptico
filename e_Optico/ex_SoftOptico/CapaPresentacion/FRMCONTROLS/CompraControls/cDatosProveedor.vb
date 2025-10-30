Imports CapaEntidad

Public Class cDatosProveedor
    Public Property TabPanelRef As TabPanelUI
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

    End Sub
    Private Sub AvanzarEntrePestañas()
        If TabPanelRef IsNot Nothing Then
            TabPanelRef.AvanzarPestaña()
        End If
    End Sub
End Class
