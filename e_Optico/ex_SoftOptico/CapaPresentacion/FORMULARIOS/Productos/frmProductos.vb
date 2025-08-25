Imports System.Windows.Controls.Primitives
Imports FontAwesome.Sharp

Public Class frmProductos
    Public Property TabPanelRef As TabPanelUI

    Private Sub frmProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim ucProductos As New ucProductos()
        Dim ucProveedor As New ucProveedor()
        Dim ucPrecios As New ucPrecios()
        Dim ucStock As New ucStock()

        Dim tab1 As New TabItemOrbitalAdv With {
            .Titulo = "Productos",
            .Icono = IconChar.Boxes,
            .Contenido = ucProductos
        }

        Dim tab2 As New TabItemOrbitalAdv With {
            .Titulo = "Proveedor",
            .Icono = IconChar.ExchangeAlt,
            .Contenido = ucProveedor
        }

        Dim tab3 As New TabItemOrbitalAdv With {
            .Titulo = "Precios",
            .Icono = IconChar.FileAlt,
            .Contenido = ucPrecios
        }

        Dim tab4 As New TabItemOrbitalAdv With {
            .Titulo = "Stocks",
            .Icono = IconChar.FileAlt,
            .Contenido = ucStock
        }

        Dim tabPanel As New TabPanelUI With {
            .Dock = DockStyle.Fill,
            .TabHeight = 48
        }

        tabPanel.AddTab(tab1)
        tabPanel.AddTab(tab2)
        tabPanel.AddTab(tab3)
        tabPanel.AddTab(tab4)

        Me.pnlContenido.Controls.Add(tabPanel)

        ucProductos.TabPanelRef = tabPanel
        ucProveedor.TabPanelRef = tabPanel
        ucPrecios.TabPanelRef = tabPanel
        ucStock.TabPanelRef = tabPanel

        AddHandler tabPanel.TabChanged, AddressOf TabPanel_TabChanged

    End Sub

    Private Sub TabPanel_TabChanged(index As Integer, titulo As String)

        Select Case index
            Case 0 'Productos

            Case 1 'Proveedor

            Case 2 'Precios

            Case 3 'stock

        End Select


    End Sub


End Class