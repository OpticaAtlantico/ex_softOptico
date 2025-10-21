Imports FontAwesome.Sharp

Public Class frmRegistrarCompras

    Public Property TabPanelRef As TabPanelUI

    Private Sub frmProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim ucProductos As New ucProductos()
        Dim ucProveedor As New ucProveedor()

        Dim tab1 As New TabItemOrbitalAdv With {
            .Titulo = "Datos del Proveedor",
            .Icono = IconChar.ExchangeAlt,
            .Contenido = ucProveedor
        }

        Dim tab2 As New TabItemOrbitalAdv With {
            .Titulo = "Datos de los Productos",
            .Icono = IconChar.Boxes,
            .Contenido = ucProductos
        }

        Dim tabPanel As New TabPanelUI With {
            .Dock = DockStyle.Fill,
            .TabHeight = 48
        }

        tabPanel.AddTab(tab1)
        tabPanel.AddTab(tab2)

        Me.pnlContenido.Controls.Add(tabPanel)

        'Permite avanzar entre pestañas
        ucProductos.TabPanelRef = tabPanel
        ucProveedor.TabPanelRef = tabPanel

        tabPanel.SeleccionarPestana(0) 'Selecciona la primera pestaña

        AddHandler tabPanel.TabChanged, AddressOf TabPanel_TabChanged
    End Sub

    Private Sub TabPanel_TabChanged(index As Integer, titulo As String)

        Select Case index
            Case 0 'DatosProductos

            Case 1 'DatosProveedor



        End Select


    End Sub

End Class