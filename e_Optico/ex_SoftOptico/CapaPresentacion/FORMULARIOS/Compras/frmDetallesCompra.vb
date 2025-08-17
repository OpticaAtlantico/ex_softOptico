Imports System.ComponentModel
Imports CapaDatos
Imports CapaEntidad
Imports FontAwesome.Sharp
Public Class frmDetallesCompra
    Public Property FormularioDestino As frmCompras
    Private WithEvents productosGrid As New DataGridViewGUI()
    Public idCompra As Integer

    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        FadeManagerUI.ShowWithFade(Me, 0.2)

        ' Agregar cualquier inicialización después de la llamada a InitializeComponent().
        productosGrid = New DataGridViewGUI()

    End Sub

    Private Sub Componentes()
        Me.Text = "Listado de Detalle de Compra"
        Me.MinimumSize = New Size(900, 600)
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.BackColor = Color.White
        Me.MaximumSize = New Size(1000, 700)

        productosGrid.Titulo = "DETALLE DE COMPRA"
        productosGrid.Subtitulo = "Listado de productos comprados..."
        productosGrid.Icono = IconChar.ShoppingCart

        With productosGrid.btnEnviar
            .Visible = True
            .Texto = "Salir..."
            .BackColor = Color.FromArgb(57, 103, 208)
            .ForeColor = Color.White
            .Font = New Font("Segoe UI", 10, FontStyle.Bold)
            .Cursor = Cursors.Hand
            .Icono = IconChar.DoorOpen
        End With

        AddHandler productosGrid.btnEnviar.Click, Sub()
                                                      FadeManagerUI.ApplyOut(Me, 500)
                                                  End Sub
    End Sub

    Private Sub frmListarProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PrepararControl()
        Componentes()
    End Sub

    Private Sub PrepararControl()
        productosGrid.Dock = DockStyle.Fill

        ' Repositorio
        Dim repo As New Repositorio_Compra()

        Dim listaProductos As List(Of VDetalleCompras) = repo.GetDetalle(idCompra)
        Dim tabla As DataTable = ConvertirListaADataTable(listaProductos)

        ' Configurar columnas y cargar
        Dim columnasVisibles = {"Descripcion", "Cantidad", "ModoCargo", "CostoUnitario", "Subtotal"}
        Dim anchos = New Dictionary(Of String, Integer) From {
        {"Descripcion", 300},
        {"Cantidad", 80},
        {"ModoCargo", 150},
        {"CostoUnitario", 150},
        {"Subtotal", 150}
    }
        Dim nombresColumnas = New Dictionary(Of String, String) From {
        {"Descripcion", "Descripción"},
        {"Cantidad", "Cantidad"},
        {"ModoCargo", "Ex/G"},
        {"CostoUnitario", "Precio"},
        {"Subtotal", "Total"}
    }

        productosGrid.ConfigurarColumnasVisualesPorTipo(tabla, columnasVisibles, anchos, nombresColumnas)
        productosGrid.MetodoCargaDatos = Function() tabla
        productosGrid.CargarDatos(tabla)

        Me.Controls.Add(productosGrid)

    End Sub

End Class
