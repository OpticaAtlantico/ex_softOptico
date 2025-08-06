' Formulario de compras que usa DataGridViewGUI para seleccionar productos
Public Class frmCompras

    ' Suponiendo que este control está en el formulario
    Private WithEvents productosGrid As New DataGridViewGUI()

    ' Grid donde se agregan los productos seleccionados
    Private dgvDetalleCompra As New DataGridView()

    Private Sub frmCompras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PrepararGrillaDetalle()
        PrepararGrillaProductos()
    End Sub

    Private Sub PrepararGrillaDetalle()
        dgvDetalleCompra.Dock = DockStyle.Bottom
        dgvDetalleCompra.Height = 250
        dgvDetalleCompra.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvDetalleCompra.AllowUserToAddRows = False
        dgvDetalleCompra.RowHeadersVisible = False

        dgvDetalleCompra.Columns.Add("Codigo", "Código")
        dgvDetalleCompra.Columns.Add("Descripcion", "Descripción")
        dgvDetalleCompra.Columns.Add("Precio", "Precio Unit.")
        dgvDetalleCompra.Columns.Add("Cantidad", "Cantidad")
        dgvDetalleCompra.Columns.Add("Subtotal", "Subtotal")

        Me.Controls.Add(dgvDetalleCompra)
    End Sub

    Private Sub PrepararGrillaProductos()
        productosGrid.Dock = DockStyle.Fill
        AddHandler productosGrid.ProductoSeleccionado, AddressOf AgregarProductoAlDetalle

        ' Simulamos una carga de productos
        productosGrid.MetodoCargaDatos = Function()
                                             Dim tabla As New DataTable()
                                             tabla.Columns.Add("Codigo")
                                             tabla.Columns.Add("Descripcion")
                                             tabla.Columns.Add("PrecioVenta", GetType(Decimal))

                                             tabla.Rows.Add("P001", "Producto 1", 12.5D)
                                             tabla.Rows.Add("P002", "Producto 2", 18D)
                                             tabla.Rows.Add("P003", "Producto 3", 9.99D)
                                             Return tabla
                                         End Function

        productosGrid.RefrescarTodo()
        Me.Controls.Add(productosGrid)
    End Sub

    Public Sub AgregarProductoAlDetalle(producto As DataRow)
        If producto Is Nothing Then Exit Sub

        Dim codigo = producto("Codigo").ToString()
        Dim descripcion = producto("Descripcion").ToString()
        Dim precio = Convert.ToDecimal(producto("PrecioVenta"))

        ' Validar si ya fue agregado
        For Each fila As DataGridViewRow In dgvDetalleCompra.Rows
            If fila.Cells("Codigo").Value?.ToString() = codigo Then
                fila.Cells("Cantidad").Value = CInt(fila.Cells("Cantidad").Value) + 1
                fila.Cells("Subtotal").Value = precio * CInt(fila.Cells("Cantidad").Value)
                Return
            End If
        Next

        ' Si no existe, agregar nuevo
        Dim index As Integer = dgvDetalleCompra.Rows.Add()
        dgvDetalleCompra.Rows(index).Cells("Codigo").Value = codigo
        dgvDetalleCompra.Rows(index).Cells("Descripcion").Value = descripcion
        dgvDetalleCompra.Rows(index).Cells("Precio").Value = precio
        dgvDetalleCompra.Rows(index).Cells("Cantidad").Value = 1
        dgvDetalleCompra.Rows(index).Cells("Subtotal").Value = precio
    End Sub

End Class
