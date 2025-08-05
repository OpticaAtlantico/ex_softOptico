Public Class frmListarProductos
    Public Event ProductoSeleccionado(productoID As Integer, nombre As String, costo As Decimal)

    Private Sub frmListarProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarProductos()
    End Sub

    Private Sub CargarProductos()
        Dim dt As DataTable = RepositorioProductos.ObtenerTodos()
        dgvProductos.DataSource = dt
    End Sub

    Private Sub dgvProductos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductos.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim fila As DataGridViewRow = dgvProductos.Rows(e.RowIndex)
            Dim productoID As Integer = fila.Cells("ProductoID").Value
            Dim nombre As String = fila.Cells("Nombre").Value.ToString()
            Dim costo As Decimal = fila.Cells("Costo").Value

            RaiseEvent ProductoSeleccionado(productoID, nombre, costo)
            Me.Close()
        End If
    End Sub

End Class