Public Class frmListarProductos

    Public Property FormularioDestino As frmCompras
    Private WithEvents productosGrid As New DataGridViewGUI()

    Private Sub frmListarProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PrepararControl()
    End Sub

    Private Sub PrepararControl()
        productosGrid.Dock = DockStyle.Fill

        ' 👉 Simulamos datos de productos
        Dim tabla As New DataTable()
        tabla.Columns.Add("Codigo")
        tabla.Columns.Add("Descripcion")
        tabla.Columns.Add("PrecioVenta", GetType(Decimal))

        tabla.Rows.Add("P001", "Aceite", 4.5D)
        tabla.Rows.Add("P002", "Harina", 2.75D)
        tabla.Rows.Add("P003", "Detergente", 6.3D)

        ' 👉 Configurar columnas visuales ANTES de cargar datos
        Dim columnasVisibles = {"Codigo", "Descripcion", "PrecioVenta"}
        Dim anchos = New Dictionary(Of String, Integer) From {
            {"Codigo", 100},
            {"Descripcion", 200},
            {"PrecioVenta", 120}
        }
        Dim nombresColumnas = New Dictionary(Of String, String) From {
            {"Codigo", "Código"},
            {"Descripcion", "Descripción"},
            {"PrecioVenta", "Precio"}
        }

        productosGrid.ConfigurarColumnasVisualesPorTipo(tabla, columnasVisibles, anchos, nombresColumnas)

        ' 👉 Definir método de carga (usado si refrescas)
        productosGrid.MetodoCargaDatos = Function() tabla

        ' 👉 Cargar datos
        productosGrid.CargarDatos(tabla)

        ' 👉 Manejar evento
        AddHandler productosGrid.ProductoSeleccionado, AddressOf ProductoSeleccionado

        ' 👉 Agregar al formulario
        Me.Controls.Add(productosGrid)
    End Sub

    Private Sub ProductoSeleccionado(producto As DataRow)
        If FormularioDestino IsNot Nothing Then
            FormularioDestino.AgregarProductoAlDetalle(producto)
            Me.Close()
        End If
    End Sub

End Class
