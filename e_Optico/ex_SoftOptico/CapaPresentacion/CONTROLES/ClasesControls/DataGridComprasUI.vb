Imports CapaEntidad

Public Class DataGridComprasUI
    Inherits UserControl

    Private dgv As New DataGridView()
    Public Event TotalActualizado(subtotal As Decimal, impuesto As Decimal, totalFinal As Decimal)

    Public Sub Inicializar()
        ' Configurar columnas
        dgv.Dock = DockStyle.Fill
        dgv.AllowUserToAddRows = False
        dgv.Columns.Clear()

        dgv.Columns.Add("Producto", "Producto")
        dgv.Columns.Add("Cantidad", "Cantidad")
        dgv.Columns.Add("CostoUnitario", "Costo Unitario")
        dgv.Columns.Add("Subtotal", "Subtotal")

        ' Botón eliminar
        Dim btnEliminar As New DataGridViewButtonColumn()
        btnEliminar.Name = "Eliminar"
        btnEliminar.Text = "🗑"
        btnEliminar.UseColumnTextForButtonValue = True
        dgv.Columns.Add(btnEliminar)

        Me.Controls.Add(dgv)
        AddHandler dgv.CellValueChanged, AddressOf CalcularTotales
        AddHandler dgv.CellClick, AddressOf EliminarFila
    End Sub

    Public Function ObtenerDetalle() As List(Of TDetalleCompra)
        Dim lista As New List(Of TDetalleCompra)
        For Each fila As DataGridViewRow In dgv.Rows
            Dim detalle As New TDetalleCompra With {
                .ProductoID = fila.Cells("Producto").Tag, ' Usar Tag para ID
                .Cantidad = Convert.ToInt32(fila.Cells("Cantidad").Value),
                .CostoUnitario = Convert.ToDecimal(fila.Cells("CostoUnitario").Value),
                .Subtotal = Convert.ToDecimal(fila.Cells("Subtotal").Value),
                .ModoCargo = "Ex"
            }
            lista.Add(detalle)
        Next
        Return lista
    End Function

    Public Sub AgregarProducto(productoID As Integer, nombre As String, costo As Decimal)
        dgv.Rows.Add(nombre, 1, costo, costo)
        dgv.Rows(dgv.Rows.Count - 1).Cells("Producto").Tag = productoID
        CalcularTotales()
    End Sub

    Public Function CalcularTotal() As Decimal
        Dim total As Decimal = 0
        For Each fila As DataGridViewRow In dgv.Rows
            total += Convert.ToDecimal(fila.Cells("Subtotal").Value)
        Next
        Return total
    End Function

    Private Sub CalcularTotales()
        For Each fila As DataGridViewRow In dgv.Rows
            Dim cantidad As Decimal = Convert.ToDecimal(fila.Cells("Cantidad").Value)
            Dim costo As Decimal = Convert.ToDecimal(fila.Cells("CostoUnitario").Value)
            fila.Cells("Subtotal").Value = cantidad * costo
        Next

        ' Aquí podrías disparar el evento para actualizar los labels
        Dim subtotal = CalcularTotal()
        Dim impuesto = subtotal * 0.13D ' Provisional
        Dim total = subtotal + impuesto
        RaiseEvent TotalActualizado(subtotal, impuesto, total)
    End Sub

    Private Sub EliminarFila(sender As Object, e As DataGridViewCellEventArgs)
        If dgv.Columns(e.ColumnIndex).Name = "Eliminar" Then
            dgv.Rows.RemoveAt(e.RowIndex)
            CalcularTotales()
        End If
    End Sub

End Class

