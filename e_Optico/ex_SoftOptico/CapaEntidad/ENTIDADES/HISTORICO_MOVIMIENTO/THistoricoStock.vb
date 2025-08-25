Public Class THistoricoStock
    Public Property MovimientoID As Integer
    Public Property CodigoProducto As String
    Public Property UbicacionOrigenID As Integer 'Ubicacion de donde sale el producto 
    Public Property UbicacionDestinoID As Integer 'Ubicacion de entra en producto
    Public Property TipoMovimientoID As Integer 'Ej: 'Entrada por Compra', 'Salida por Venta', 'Traslado', 'Ajuste Positivo', 'Ajuste Negativo', 'Devolución Cliente', 'Devolución Proveedor'
    Public Property Cantidad As Integer
    Public Property FechaMovimiento As Date
    Public Property Referencia As String 'Ej: 'Venta #123', 'Compra #456', 'Nota Entrega #789', 'Ajuste Físico', 'Devolución'
    Public Property EmpleadoID As Integer 'Que empleado realizo el movimiento
    Public Property Notas As String
End Class
